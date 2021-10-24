using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpTestServer
{

    // Obsahuje logiku pro posílání a přijímání řetězců přes TcpClient
    public static class PosilacRetezcu
    {
        public const int separator = 0;
        
        // Pošle textový řetězec danému klientovi
        public static void PosliString(TcpClient klient, string zprava) // klient který zprávu posílá a samotná zpráva ve string
        {
            byte[] byteBuffer = Encoding.UTF8.GetBytes(zprava); //převedení do byte zásobníku
            NetworkStream netStream = klient.GetStream(); // networkStream se rovná neworkStream klienta který posílá zprávu
            netStream.Write(byteBuffer, 0, byteBuffer.Length); //zapiš byte zásobník od nuly až do konce
            netStream.Write(new byte[] { separator }, 0, sizeof(byte)); // nemám páru proč to tady je
            netStream.Flush();
        }

        // Přijme řetězec od daného klienta
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
