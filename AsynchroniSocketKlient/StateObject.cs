using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace AsynchroniSocketKlient
{
    // Objekt pro příjem vzdáleného zařízení  
    public class StateObject
    {
        // Klientský  socket
        public Socket workSocket = null;
        // Velikost vyrovnávacího bufferu pro příjem 
        public const int BufferSize = 256;
        // vyrovnávací buffer
        public byte[] buffer = new byte[BufferSize];
        // Přijatý datový řetězec 
        public StringBuilder sb = new StringBuilder();
    }
}
