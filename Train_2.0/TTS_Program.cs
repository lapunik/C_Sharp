using Atasoft.TCP;
using Eink32_CommonLib;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace Eink32_TTS_cmd
{
  class TTS_Program
  {
    static TCPServer server = null;
    static ConfigMain cfg = null;

    static void Log(String txt)   // cannot use default parameter of Color type
    {
      Log(txt, Color.Transparent);
    }

    static void Log(String txt, Color color)
    {
      String s = String.Format("{0:HH:mm:ss.fff} - {1}", DateTime.Now, txt);

      if (color == Color.Transparent)
        Console.WriteLine(s);
      else
        Console.WriteLine(s, color);
    }

    static void Main(string[] args)
    {
      cfg = ConfigMain.Load();

      Log("TTS cmd - START", Color.Yellow);

      server = new TCPServer();

      server.DataType = eRecvDataType.dataStringNL;
      server.OnError += TCP_MsgError;
      server.OnMessage += TCP_MsgInfo;
      server.DataReceived += TCP_DataRecv;
      server.OnClientConnected += TCP_NewClient;

      server.Listen(cfg.TTS_PortTCP);

      Log("TCP server ready on port " + cfg.TTS_PortTCP, Color.LightGreen);

      ReadVoices();

      Log("Search voice for CZ names");
      sCZVoice = FullVoiceName(cfg.VoiceCZNames);
      Log("Voice for CZ names: " + sCZVoice);

      bool bbLoop = true;
      while (bbLoop)
      {
        if (Console.KeyAvailable)
        {
          ConsoleKeyInfo cki = Console.ReadKey(true);

          switch (cki.Key)
          {
            case ConsoleKey.H:
              Log("HELP");
              Log("H = help");
              Log("Q = quit");
              Log("V = update Voices-list");
              Log("W = enable/disable EPOS web alternative");

              break;
            case ConsoleKey.Q:
              bbLoop = false;
              break;
            case ConsoleKey.V:
              ReadVoices();
              break;
            case ConsoleKey.W:
              cfg.WebTTSEnable = !cfg.WebTTSEnable;
              Log("Enable EPOS web: " + cfg.WebTTSEnable);
              break;
          }
        }

        Thread.Sleep(10);
      }

      Log("\nFinish");

      server.Dispose();
      server = null;

      if (thrTTS != null)
      {
        Log("Stop TTS thread");

        runTTSThread = false;
        Thread.Sleep(200);      // interne spi 50ms, cili s rezervou

        if (thrTTS.IsAlive)
        {
          Log("Abort", Color.OrangeRed);
          thrTTS.Abort();
        }
        else
        {
        }

        thrTTS = null;
      }
    }

    private static void TCP_NewClient(object sender, TCPClientConnectedEventArgs e)
    {
      Log("Pripojen klient " + e.clientIPE);
    }

    private static void TCP_MsgInfo(object sender, TCPMsgEventArgs e)
    {
      Log("Info: " + e.Text, Color.LightCyan);
    }

    private static void TCP_MsgError(object sender, TCPMsgEventArgs e)
    {
      Log("ERR: " + e.Text, Color.OrangeRed);
    }

    static char[] _caSplitDouble = new char[] { ':' };
    static char[] _caSplitEqual = new char[] { '=' };

    private static void TCP_DataRecv(object sender, TCPReceivedEventArgs e)
    {
      IPEndPoint ipeClient = null;
      SocketObject so = sender as SocketObject;
      if ((so != null) && (so.sock != null))
        ipeClient = so.sock.RemoteEndPoint as IPEndPoint;

      if (e.data is String)
      {
        String s = e.data as String;

        if (s.StartsWith("say:", StringComparison.InvariantCultureIgnoreCase))
        {
          bool bbSay = false;
          int id = 0;
          String[] sa = s.Split(_caSplitDouble);
          if (sa.Length >= 3)   // SAY:id:text
          {
            if (int.TryParse(sa[1], out id) && (id > 0))    // v sa[0] je "SAY"
              bbSay = TTS_Say(String.Join(_caSplitDouble[0].ToString(), sa, 2, sa.Length - 2), id);
            else
              bbSay = TTS_Say(String.Join(_caSplitDouble[0].ToString(), sa, 1, sa.Length - 1));
          }
          else
            bbSay = TTS_Say(sa[1]);

          if (!bbSay)
            server.Send("ERR:No voice!\n", ipeClient);

          return;
        }

        if (s.StartsWith("set:", StringComparison.InvariantCultureIgnoreCase))
        {
          Log("Settings: " + s);

          String[] sa = s.ToLower().Substring(4).Split(_caSplitEqual);       // length of "set:"
          if (sa.Length == 2)
          {
            switch (sa[0])
            {
              case "voice":
                String str = sa[1].Trim().ToLower();

                bool bb = false;
                foreach(LangVoice lv in cfg.InstalledVoices)
                {
                  if (lv.Voice.ToLower() == str)
                  {
                    Log("Detected voice for " + lv.Lang, Color.Green);
                    bb = true;
                    break;
                  }
                }

                if (!bb)
                  Log("Voice not in list", Color.LightPink);

                {
                  String sx = FullVoiceName(str);
                  if (!String.IsNullOrEmpty(sx))
                  {
                    sVoice = sx;
                    server.Send("OK:voice set\n", ipeClient);
                    return;
                  }
                }

                Log("Unknown lang " + str, Color.Red);
                server.Send("ERR:voice unknown\n", ipeClient);
                return;
              default:
                Log("Error settings type", Color.Red);
                server.Send("ERR:Settings type\n", ipeClient);
                return;
            }

            server.Send(String.Format("OK:{0}\n", s.Substring(4)), ipeClient);      // after "set:"
          }
          else
          {
            Log("Error settings format", Color.Red);
            server.Send("ERR:Settings format\n", ipeClient);
          }
          return;
        }

        Log("Unknown command: " + s, Color.OrangeRed);
        server.Send("ERR\n", null);
      }
      else
        Log("No String Recv Data, real: " + e.data.GetType(), Color.OrangeRed);
    }

    static String FullVoiceName(String str)
    {
      foreach (VoiceInfo vi in lVoices)     // search equal lang name
      {
        if (vi.Name.ToLower() == str)
        {
          Log("New eq lang " + sVoice, Color.LightGreen);
          return vi.Name;
        }
      }

      foreach (VoiceInfo vi in lVoices)     // search substring name
      {
        if (vi.Name.ToLower().Contains(str))
        {
          Log("New sub lang " + sVoice, Color.LightGreen);
          return vi.Name;
        }
      }

      return String.Empty;
    }

    static List<VoiceInfo> lVoices = new List<VoiceInfo>();
    static String sVoice = String.Empty;

    static void ReadVoices()
    {
      lVoices.Clear();

      using (SpeechSynthesizer s = new SpeechSynthesizer())
      {
        foreach (InstalledVoice v in s.GetInstalledVoices())
        {
          Log("VOICE: " + v.VoiceInfo.Name + "  culture = " + v.VoiceInfo.Culture.DisplayName);
          foreach (var x in v.VoiceInfo.AdditionalInfo)
            Log("... " + x.Key + " = " + x.Value);

          if (v.VoiceInfo.Name.Contains("obile"))
            Log("Mobile Voice, can't use", Color.OrangeRed);
          else
            lVoices.Add(v.VoiceInfo);
        }
      }
    }

    static bool TTS_Say(String s, int id = 0)
    {
      Log("Saying: " + s, Color.YellowGreen);

      bool bbOk = false;
      if (!String.IsNullOrEmpty(sVoice))
        bbOk = SpeakLocal(sVoice, s, id);

      if (!bbOk)      // nic se zatim nereklo ?
      {
        Log("Cannot speak with " + sVoice, Color.OrangeRed);

        if (lVoices.Count > 0)
          SpeakLocal(lVoices[0].Name, "Voice select Error!");
        else
        {
          Log("No local voices !!!", Color.OrangeRed);
        }

        return false;
      }

      Log("Saying finished");
      return true;
    }

    /*
    static bool TTS_Say(String s, int id = 0)
    {
      Log("Saying: " + s, Color.YellowGreen);

      //TODO set voice from SET command 
      String strVoice = null;
      foreach (VoiceInfo vi in lVoices)     // search CZ voice
      {
        if (vi.Culture.Name == "cs-CZ")
        {
          strVoice = vi.Name;
          break;
        }
      }

      // proces: je CZ lokal ? = rekni, je spojeni ? = pouzij ke generovani WAV, jinak anglicky
      bool bbOk = false;
      if (!String.IsNullOrEmpty(strVoice))     // je nejaky cesky ?
        bbOk = SpeakLocal(strVoice, s, id);
      else
        bbOk = SpeakRemoteWav(cfg.WebTTSDefaultVoice, s, id);

      if (!bbOk)      // nic se zatim nereklo ?
      {
        Log("Cannot speak CZ", Color.OrangeRed);

        // České hlasová syntéza dostupná pouze při připojení internetu nebo nainstalování českého hlasu.
        if (lVoices.Count > 0)
          SpeakLocal(lVoices[0].Name, "Czech voice synthesis available only when connecting the Internet or installing a Czech voice.");
        else
        {
          Log("No local voices !!!", Color.OrangeRed);
          server.SendString("ERR\n");
        }
      }

      Log("Saying finished");
      return true;
    }
*/
/*
    static Dictionary<char, String> dConvUTF2Iso8592 = new Dictionary<char, string>()
    {
      {' ', "+" },
      {'+', "%2B" },
      {'Š', "%A9" },
      {'Ť', "%AB" },
      {'Ž', "%AE" },
      {'ť', "%BB" },
      {'ž', "%BE" },
      {'š', "%B9" },
      {'Á', "%C1" },
      {'Č', "%C8" },
      {'É', "%C9" },
      {'Ě', "%CC" },
      {'Í', "%CD" },
      {'Ď', "%CF" },
      {'Ň', "%D2" },
      {'Ó', "%D3" },
      {'Ř', "%D8" },
      {'Ů', "%D9" },
      {'Ú', "%DA" },
      {'Ý', "%DD" },
      {'á', "%E1" },
      {'č', "%E8" },
      {'é', "%E9" },
      {'ě', "%EC" },
      {'í', "%ED" },
      {'ď', "%EF" },
      {'ň', "%F2" },
      {'ó', "%F3" },
      {'ř', "%F8" },
      {'ů', "%F9" },
      {'ú', "%FA" },
      {'ý', "%FD" }
    };

    private static bool SpeakRemoteWav(string voice, string txt, int idMsg = 0)
    {
      if (!cfg.WebTTSEnable)
      {
        server.SendString("ERR\n");
        return false;
      }

      using (Ping px = new Ping())
      {
        try
        {
          PingReply preply = px.Send("http://epos.ufe.cz", 1000);   // timeout 1sec
          if (preply.Status != IPStatus.Success)
          {
            Log("PING to EPOS failed", Color.Red);
            return false;
          }
        }
        catch(Exception ex)
        {
          Log(ex.Message, Color.Red);
        }
      }

      if (String.IsNullOrEmpty(voice))
        voice = cfg.WebTTSDefaultVoice;

      StringBuilder sb = new StringBuilder();
      foreach (char c in txt.ToCharArray())
      {
        if (dConvUTF2Iso8592.ContainsKey(c))
          sb.Append(dConvUTF2Iso8592[c]);
        else
          sb.Append(c);
      }

      String encText = sb.ToString();
      String strReq = String.Format("http://epos.ufe.cz/cgi-bin/say.cgi?word={0}&lang=czech&voice={1}",
        encText, voice);

      Log("Req: " + strReq);

      byte[] data = null;
      using (WebClient clnt = new WebClient())
      {
        try
        {
          clnt.Headers.Add(HttpRequestHeader.ContentType, "text/html; charset=iso-8859-2");
          data = clnt.DownloadData(strReq);
        }
        catch (Exception ex)
        {
          Log(ex.Message, Color.OrangeRed);
          Log(ex.GetType().ToString(), Color.OrangeRed);
        }
      }

      Log("Downloaded: " + ((data == null) ? -1 : data.Length));

      bool bbOk = false;
      if (data != null)
      {
        Log("Start playing");

        try
        {
          using (MemoryStream ms = new MemoryStream(data))
          {
            using (System.Media.SoundPlayer pl = new System.Media.SoundPlayer())
            {
              pl.Stream = ms;
              pl.Stream.Position = 0;
              pl.PlaySync();

              //TODO jak to udelat, aby se OK posialalo az po dohrani ??

              bbOk = true;
            }
          }
        }
        catch (Exception ex)
        {
          Log(ex.Message, Color.OrangeRed);
          Log(ex.GetType().ToString(), Color.OrangeRed);
        }
      }

      if (bbOk)
      {
        if (idMsg > 0)
          server.SendString(String.Format("OK:{0}:{1}\n", idMsg, voice));
        else
          server.SendString("OK\n");
      }
      else
      {
        if (idMsg > 0)
          server.SendString(String.Format("ERR:{0}\n", idMsg));
        else
          server.SendString("ERR\n");
      }

      return bbOk;
    }
*/
    static Thread thrTTS = null;
    static bool runTTSThread = false;
    static ConcurrentQueue<LocalTTSObject> qTTTS = new ConcurrentQueue<LocalTTSObject>();
    static String sCZVoice = String.Empty;

    private static bool SpeakLocal(string voiceName, string txt, int idMsg = 0)
    {
      Log(String.Format("TTS voice: {0}, text: {1}", voiceName, txt));

      if (thrTTS == null)     // neni zatim funkcni
      {
        thrTTS = new Thread(thrTTSfunc);

        runTTSThread = true;
        thrTTS.Start();
      }

      qTTTS.Enqueue(new LocalTTSObject() { voice = voiceName, text = txt, id = idMsg });
      return true;    //TODO detect problem ?
    }

    static void SpeakLowLevel(String voiceSynth, String txt)
    {
      using (SpeechSynthesizer s = new SpeechSynthesizer())
      {
        s.SelectVoice(voiceSynth);       // zacina vybrany jazyk
        s.Speak(txt.Trim());                       //! blocking call
      }
    }

    static void thrTTSfunc()
    {
      while (runTTSThread)
      {
        if (qTTTS.Count > 0)
        {
          LocalTTSObject lto;
          if (qTTTS.TryDequeue(out lto))
          {
            Log(String.Format("DeQ: {0} : {1}", lto.voice, lto.text));
            bool ok = false;
            try
            {
              String voi = lto.voice;
              StringBuilder sb = new StringBuilder();
              foreach (char c in lto.text)
              {
                if (c == '<')
                {
                  if (sb.Length > 0)
                  {
                    voi = sCZVoice;
                    SpeakLowLevel(voi, sb.ToString());
                    voi = lto.voice;
                  }

                  sb.Clear();
                  continue;
                }

                if (c == '>')
                {
                  if (sb.Length > 0)
                  {
                    voi = lto.voice;
                    SpeakLowLevel(voi, sb.ToString());
                  }

                  sb.Clear();
                  continue;
                }

                sb.Append(c);
              }

              if (sb.Length > 0)          // neco dorict ?
                SpeakLowLevel(voi, sb.ToString());

              ok = true;
              /*
              using (SpeechSynthesizer s = new SpeechSynthesizer())
              {
                s.SelectVoice(lto.voice);       // zacina vybrany jazyk

                StringBuilder sb = new StringBuilder();
                foreach(char c in lto.text)
                {
                  if (c == '<')
                  {
                    if (sb.Length > 0)
                      s.Speak(sb.ToString());

                    s.SelectVoice(lto.voice);     // zpatky vybrany hlas
                    sb.Clear();
                    continue;
                  }

                  if (c == '>')
                  {
                    if (sb.Length > 0)
                      s.Speak(sb.ToString());

                    s.SelectVoice(sCZVoice);     // cesky hlas
                    sb.Clear();
                    continue;
                  }

                  sb.Append(c);
                }

                if (sb.Length > 0)          // neco dorict ?
                  s.Speak(sb.ToString());   //! blocking call

                ok = true;
              }
              */
            }
            catch (Exception ex)
            {
              Log(ex.Message, Color.OrangeRed);
              Log(ex.GetType().ToString(), Color.OrangeRed);
            }

            if (ok)
            {
              if (lto.id > 0)
                server.Send(String.Format("OK:{0}:{1}\n", lto.id, lto.voice), null);
              else
                server.Send("OK\n", null);

            }
            else
            {
              if (lto.id > 0)
                server.Send(String.Format("ERR:{0}\n", lto.id), null);
              else
                server.Send("ERR\n", null);
            }
          }

          Thread.Sleep(50);
        }
      }
    }
  }

  public class LocalTTSObject
  {
    public String voice = null;
    public String text = null;
    public int id = 0;
  }
}
