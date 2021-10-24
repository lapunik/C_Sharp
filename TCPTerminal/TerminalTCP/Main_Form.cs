using Atasoft.TCP;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TerminalTCP.Properties;

namespace TerminalTCP
{
  public partial class Main_Form : Form
  {
    public Main_Form()
    {
      InitializeComponent();
    }

    List<TextBox> ltxSend = new List<TextBox>();

    private void Main_Form_Load(object sender, EventArgs e)
    {
      log.Add("Start APP");

      ltxSend.Add(txSend1);
      ltxSend.Add(txSend2);
      ltxSend.Add(txSend3);
      ltxSend.Add(txSend4);

      if (Settings.Default.TextBoxes != null)
      {
        for (int i = 0; i < Settings.Default.TextBoxes.Count; i++)
        {
          if (ltxSend.Count > i)
            ltxSend[i].Text = Settings.Default.TextBoxes[i];
          else
            break;
        }
      }

      cbKlientType.DataSource = Enum.GetValues(typeof(eRecvDataType));
      cbKlientType.SelectedItem = String.IsNullOrEmpty(Settings.Default.KlientDataType)
        ? eRecvDataType.dataChar
        : Enum.Parse(typeof(eRecvDataType), Settings.Default.KlientDataType);

      txClientIP.Text = Settings.Default.KlientIP;
      txClientPort.Text = Settings.Default.KlientPort.ToString();
      txServerPort.Text = Settings.Default.ServerPort.ToString();
    }

    private void Main_Form_FormClosed(object sender, FormClosedEventArgs e)
    {
      List<String> ls = new List<String>();

      foreach (TextBox tx in ltxSend)
        ls.Add(tx.Text.Trim());

      StringCollection scol = new StringCollection();
      scol.AddRange(ls.ToArray());
      Settings.Default.TextBoxes = scol;

      Settings.Default.KlientDataType = cbKlientType.SelectedItem.ToString();
      Settings.Default.KlientIP = txClientIP.Text;

      int x = 0;
      if (!int.TryParse(txClientPort.Text, out x))
        x = 0;
      Settings.Default.KlientPort = x;

      x = 0;
      if (!int.TryParse(txServerPort.Text, out x))
        x = 0;
      Settings.Default.ServerPort = x;

      Settings.Default.Save();
    }

    private void buttonSend_Click(object sender, EventArgs e)
    {
      Button btn = sender as Button;
      if (btn == null)
        return;

      String sTag = btn.Tag as String;
      if (String.IsNullOrEmpty(sTag))
      {
        log.Add("Send: Invalid TAG");
        return;
      }

      TextBox tx = ltxSend.Find(x => ((x.Tag as String) == sTag));
      if (tx == null)
        log.Add("Send TX not found " + sTag);
      else
      {
        String s = tx.Text.Trim();
        if (String.IsNullOrEmpty(s))
          log.Add("Nothing to send");
        else
        {
          bool bb = false;

          if (_klient != null)
          {
            log.Add("Send " + s);
            _klient.Send(s);
            bb = true;
          }

          if (_server!=null)
          {
            foreach(IPEndPoint ipe in _server.ConnectedClients())
            {
              log.Add("Send to " + ipe);
              _server.Send(s, ipe);
            }

            bb = true;
          }

          if (!bb)
            log.Add("SEND - Not connected");
        }
      }
    }

    TCPClient _klient = null;

    private void btnConnectClient_Click(object sender, EventArgs e)
    {
      if (_klient != null)
      {
        log.Add("Disconnecting");

        Klient_CleanUp();
      }
      else
      {
        txClientIP.BackColor = SystemColors.Window;
        txClientPort.BackColor = SystemColors.Window;

        bool bbOk = true;
        IPAddress ipa;
        UInt16 port;

        if (!IPAddress.TryParse(txClientIP.Text.Trim(), out ipa))
        {
          if (String.Compare(txClientIP.Text.Trim(), "localhost", true) == 0)
            ipa = IPAddress.Loopback;
          else
          {
            log.Add("Invalid IP address");
            txClientIP.BackColor = Color.LightPink;
            bbOk = false;
          }
        }

        if (!UInt16.TryParse(txClientPort.Text.Trim(), out port))
        {
          log.Add("Invalid TCP Port");
          txClientPort.BackColor = Color.LightPink;
          bbOk = false;
        }

        if (!bbOk)
        {
          log.Add("Cannot start connect");
          return;
        }

        _klient = new TCPClient(ipa, port);

        if (cbKlientType.SelectedIndex >= 0)
          _klient.DataType = (eRecvDataType)cbKlientType.SelectedItem;

        _klient.OnClientConnected += KlientConnected;
        _klient.DataReceived += Klient_DataReceived;
        _klient.OnError += Klient_OnError;
        _klient.OnMessage += Klient_OnMessage;

        if (_klient.Connect())     // connect successfull
        {
          txClientIP.Enabled = false;
          txClientPort.Enabled = false;
          cbKlientType.Enabled = false;

          btnConnectClient.Text = "Disconnect";
        }
        else
          Klient_CleanUp();       // tak nic
      }
    }

    private void KlientConnected(object sender, TCPClientConnectedEventArgs e)
    {
      if (InvokeRequired)
      {
        Invoke(new Action<object, TCPClientConnectedEventArgs>(KlientConnected),
          new object[] { sender, e });
        return;
      }

      if (e == null)        // not success
        Klient_CleanUp();
      else
        log.Add("Connected to " + e.clientIPE);
    }

    private void Klient_CleanUp()
    {
      if (_klient != null)
      {
        _klient.Disconnect();

        _klient.OnClientConnected -= KlientConnected;
        _klient.DataReceived -= Klient_DataReceived;
        _klient.OnError -= Klient_OnError;
        _klient.OnMessage -= Klient_OnMessage;

        _klient.Dispose();      // emits Close internally
        _klient = null;
      }

      txClientIP.Enabled = true;
      txClientPort.Enabled = true;
      cbKlientType.Enabled = true;
      btnConnectClient.Text = "Connect";
    }

    private void Klient_OnMessage(object sender, TCPMsgEventArgs e)
    {
      log.Add("C-Msg: " + e.Text);
    }

    private void Klient_OnError(object sender, TCPMsgEventArgs e)
    {
      log.Add("C-ERR: " + e.Text);
    }

    private void Klient_DataReceived(object sender, TCPReceivedEventArgs e)
    {
      ProcessData(e.dataType, e.data, rtxKlient);
    }

    private void ProcessData(eRecvDataType dataType, Object data, RichTextBox rtx)
    {
      if(this.InvokeRequired)
      {
        this.BeginInvoke(new Action<eRecvDataType, Object, RichTextBox>(ProcessData), 
          new object[] { dataType, data, rtx });
        return;
      }

      switch (dataType)
      {
        case eRecvDataType.dataChar:
          rtx.AppendText(data.ToString(), Color.DeepPink);    // internally char
          break;
        case eRecvDataType.dataByte:
          rtx.AppendText(((byte)data).ToString("X02"), Color.Red);
          break;
        case eRecvDataType.dataBlockBytes:
          rtx.AppendText(String.Format("> bytes: {0} <", ((byte[])data).Length), Color.DarkGreen);
          break;
        case eRecvDataType.dataStringNL:
          rtx.AppendText(data as String);
          break;
        case eRecvDataType.STX:
          rtx.AppendText(BitConverter.ToString((byte[])data), Color.DarkBlue);
          break;
        default:
          log.Add("C-Recv: " + dataType);
          break;
      }
    }

    private void CbKlientType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void BtnKlientClear_Click(object sender, EventArgs e)
    {
      rtxKlient.Clear();
//      rtxKlient.AppendText(@"{\rtf1\ansi")
    }

    private void BtnServerClear_Click(object sender, EventArgs e)
    {
      rtxServer.Clear();
    }

    TCPServer _server = null;

    private void BtnListen_Click(object sender, EventArgs e)
    {
      if (_server != null)
      {
        log.Add("Stop listening");

        Server_CleanUp();
      }
      else
      {
        txServerPort.BackColor = SystemColors.Window;

        bool bbOk = true;
        UInt16 port;

        if (!UInt16.TryParse(txServerPort.Text.Trim(), out port))
        {
          log.Add("Invalid TCP Port");
          txServerPort.BackColor = Color.LightPink;
          bbOk = false;
        }

        if (!bbOk)
        {
          log.Add("Cannot start listenning");
          return;
        }

        _server = new TCPServer();

        _server.OnClientConnected += Server_ClientConnected;
        _server.DataReceived += Server_DataReceived;
        _server.OnError += Server_OnError;
        _server.OnMessage += Server_OnMessage;

        if (_server.Listen(port))     // start successfull
        {
          txServerPort.Enabled = false;

          btnConnectClient.Text = "Stop listen...";
        }
        else
          Server_CleanUp();       // tak nic
      }
    }

    private void Server_ClientConnected(object sender, TCPClientConnectedEventArgs e)
    {
      log.Add("New client " + e.clientIPE);
    }

    private void Server_CleanUp()
    {
      if (_server != null)
      {
        _server.OnClientConnected -= Server_ClientConnected;
        _server.DataReceived -= Server_DataReceived;
        _server.OnError -= Server_OnError;
        _server.OnMessage -= Server_OnMessage;

        _server.Dispose();      // emits Close internally
        _server = null;
      }

      txServerPort.Enabled = true;
      btnListen.Text = "Listen";
    }

    private void Server_OnMessage(object sender, TCPMsgEventArgs e)
    {
      log.Add("S-Msg: " + e.Text);
    }

    private void Server_OnError(object sender, TCPMsgEventArgs e)
    {
      log.Add("S-ERR: " + e.Text);
    }

    private void Server_DataReceived(object sender, TCPReceivedEventArgs e)
    {
      ProcessData(e.dataType, e.data, rtxServer);
    }

    private void BtnListClients_Click(object sender, EventArgs e)
    {
      if (_server == null)
        log.Add("ERR - no server active");
      else
        foreach (IPEndPoint ipe in _server.ConnectedClients())
          log.Add("Client: " + ipe);
    }
  }
}
