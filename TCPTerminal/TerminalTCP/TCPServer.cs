using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Atasoft.TCP
{
  class TCPServer : TCPBase, IDisposable
  {
    SocketObject _sck = null;       // listener

    List<SocketObject> lClients = new List<SocketObject>();

    public bool Listen(int port)
    {
      if (_sck != null)
      {
        LogError("Listenning in progress");
        //TODO maybe Stop Listening ??
        return false;
      }

      SocketPermission perm = new SocketPermission(NetworkAccess.Accept, TransportType.Tcp, "", SocketPermission.AllPorts);
      _sck = new SocketObject()
      {
        sock = new Socket(SocketType.Stream, ProtocolType.Tcp)
      };

      LogInfo("Binding to listening at " + port);
      try
      {
        _sck.sock.Bind(new IPEndPoint(IPAddress.Any, port));
      }
      catch(SocketException ex)
      {
        LogError("BIND Error: " + ex.SocketErrorCode);
        return false;
      }

      _sck.sock.Listen(10);     // num of connecting peer (?)
      _sck.sock.BeginAccept(new AsyncCallback(ClientAccept), _sck.sock);
      return true;
    }

    private void ClientAccept(IAsyncResult ar)
    {
      Socket listener = ar.AsyncState as Socket;
      if (listener == null)     // not Socket ?
        return;                 // do nothing

      Socket client = null;
      try
      {
        client = listener.EndAccept(ar);
      }
      catch (ObjectDisposedException dex)
      {
        LogError("EndAccept - Socket disposed " + dex.Message);
        // ?        return;     // don't continue with more listening
      }

      if (client != null)
      {
        SocketObject so = new SocketObject()
        {
          sock = client,
          recvBuf = new byte[SocketObject.DEF_BUF_SIZE]
        };
        lClients.Add(so);

        client.BeginReceive(so.recvBuf, 0, so.recvBuf.Length, SocketFlags.None, 
          new AsyncCallback(ReceiveCallback), so);      // listen data from connection

        OnClientConnected?.Invoke(this, new TCPClientConnectedEventArgs()
        {
          clientIPE = so.sock.RemoteEndPoint as IPEndPoint
        });
      }

      try
      {
        listener.BeginAccept(new AsyncCallback(ClientAccept), listener);     // and wait for others clients
      }
      catch (ObjectDisposedException dex)
      {
        LogError("BeginAccept - Socket disposed " + dex.Message);
      }
    }

    //TODO make it common with Client
    private void ReceiveCallback(IAsyncResult ar)
    {
      SocketObject so = ar.AsyncState as SocketObject;
      if (so == null)
        return;

      // https://stackoverflow.com/questions/2582036/an-existing-connection-was-forcibly-closed-by-the-remote-host
      SocketError serr;
      int len = 0;
      if (so.sock == null)
        serr = SocketError.NotSocket;
      else
      {
        try
        {
          len = so.sock.EndReceive(ar, out serr);
        }
        catch (ObjectDisposedException ex)
        {
          serr = SocketError.NotSocket;
        }
      }

      switch (serr)
      {
        case SocketError.Success:
          {
            if (len > 0)
            {
              LogInfo(String.Format("Received {0}[B] from {1}", len, so.sock.RemoteEndPoint));

              ProcessRecvData(so, len);

              so.sock.BeginReceive(so.recvBuf, 0, so.recvBuf.Length, SocketFlags.None,
                new AsyncCallback(ReceiveCallback), so);
            }
            else
            {
              /* nesmim delat Close, pak bude Socket disposed a pri pristim Open vyhodi chybu
              sock.Shutdown(SocketShutdown.Both);      // melo by skoncit vsechny prenosy, aby na to necekal Close
              sock.Close();
              LogInfo("Zero data = Close");
              */
              so.sock.Disconnect(true);
              LogInfo("Zero data = Disconnect");
            }
          }
          break;
        case SocketError.ConnectionReset:
          so.sock.Disconnect(true);
          LogInfo("ConnectionReset = Disconnect");
          break;
        default:
          LogError("Sock ERR: " + serr);
          break;
      }
    }

    public bool StopListening(bool fromDispose = false)
    {
      if (_sck == null)
      {
        if (!fromDispose)
          LogError("Not Listenning");
        return false;
      }

      foreach (SocketObject ci in lClients)
        ci.sock.Close();

      lClients.Clear();

      _sck.sock.Close();
      Thread.Sleep(50);

      lock (_sck.sock)
      {
        _sck.sock.Dispose();
        _sck.sock = null;
      }

      _sck = null;
      return true;
    }

    public IPEndPoint[] ConnectedClients()
    {
      List<IPEndPoint> lipe = new List<IPEndPoint>();

      if ((_sck == null) || (lClients == null))
        return null;

      foreach (SocketObject so in lClients)
        lipe.Add(so.sock.RemoteEndPoint as IPEndPoint);
      return lipe.ToArray();
    }

    public bool Send(byte b, IPEndPoint ipeClient)
    {
      SocketObject so = lClients.Single(x => (x.sock.RemoteEndPoint == ipeClient));
      return (so == null) ? false : Send2Socket(b, so.sock);
    }

    public bool Send(char c, IPEndPoint ipeClient)
    {
      SocketObject so = lClients.Single(x => (x.sock.RemoteEndPoint == ipeClient));
      return (so == null) ? false : Send2Socket(c, so.sock);
    }

    public bool Send(String str, IPEndPoint ipeClient)
    {
      SocketObject so = lClients.Single(x => (x.sock.RemoteEndPoint == ipeClient));
      return (so == null) ? false : Send2Socket(str, so.sock);
    }

    public bool Send(byte[] ba, IPEndPoint ipeClient)
    {
      SocketObject so = lClients.Single(x => (x.sock.RemoteEndPoint == ipeClient));
      return (so == null) ? false : Send2Socket(ba, so.sock);
    }

    public void Dispose()
    {
      if (_sck != null)       // exists ?
      {
        StopListening(true);
      }
    }
  }
}
