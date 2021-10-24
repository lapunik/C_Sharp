using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{


    public static class PosilacRetezcu
    {
        public const int separator = 0;
        public static void PosliString(TcpClient klient, string zprava)
        {
            byte[] byteBuffer = Encoding.UTF8.GetBytes(zprava);
            NetworkStream netStream = klient.GetStream();
            netStream.Write(byteBuffer, 0, byteBuffer.Length);
            netStream.Write(new byte[] { separator }, 0, sizeof(byte));
            netStream.Flush();
        }

        public static string PrijmiString(TcpClient klient)
        {
            List<int> buffer = new List<int>();
            NetworkStream stream = klient.GetStream();
            int readByte;
            while ((readByte = stream.ReadByte()) != 0)
            {
                buffer.Add(readByte);
            }
            return Encoding.UTF8.GetString(buffer.Select<int, byte>(b => (byte)b).ToArray(), 0, buffer.Count);
        }

    }
}
