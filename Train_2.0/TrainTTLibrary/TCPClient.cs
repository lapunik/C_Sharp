using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TrainTTLibrary
{
  public class TCPClient : TCPBase, IDisposable
  {
    IPAddress _adr = null;
    public byte [] AddressBytes
    {
      get { return _adr == null ? null : _adr.GetAddressBytes(); }
    }
    int _port = 0;
    public int Port { get { return _port; } }

    public bool ShowRecvInfo { get; set; } = true;

    SocketObject _sck = null;

    protected TCPClient()
    {    }

    public TCPClient(IPAddress adr, int port)
    {
      _adr = adr;
      _port = port;
    }

    public TCPClient(String sadr, int port) : this(IPAddress.Parse(sadr), port)   // emits exceptions !!
    { }

    public bool IsConnected
    {
      get
      {
        try
        {
          return (_sck != null) && (_sck.sock != null) && _sck.sock.Connected;     // hm, hazelo to chybu
        }
        catch (Exception ex)
        {
          LogError(ex.Message);
        }

        return false;
      }
    }

    public bool Connect()
    {
      if (_sck == null)       // not connected yet ?
      {
        _sck = new SocketObject()
        {
          sock = new Socket(SocketType.Stream, ProtocolType.Tcp)
        };

        //TODO set other socket parameters
      }
      else
      {
        //TODO try to implement reconnect yes/no
      }

      if (_sck.sock.Connected)        // detected last comm state !!
        Disconnect();

      bool bbOk = false;

      try
      {
        _sck.sock.BeginConnect(_adr, _port, new AsyncCallback(ClntConnected), _sck);


        bbOk = true;
      }
      catch (Exception ex)
      {
        LogError("Error BeginConnect: " + ex.Message);
        _sck.sock.Dispose();
        _sck.sock = null;
        _sck = null;
      }

      return bbOk;
    }

    private void ClntConnected(IAsyncResult ar)
    {
      SocketObject so = ar.AsyncState as SocketObject;
      if (so == null)
        return;

      bool bbOk = false;

      if (so.sock == null)
        LogError("ClntConnected: sock == null");
      else
      {
        try
        {
          so.sock.EndConnect(ar);
          bbOk = true;
        }
        catch (SocketException ex)
        {
          LogError("ERR-Sock: " + ex.SocketErrorCode + " = " + ex.Message);
        }
      }

      if (bbOk)
      {
        LogInfo(String.Format("BeginConnected to {0} (local port  {1})",
          so.sock.RemoteEndPoint, (so.sock.LocalEndPoint as IPEndPoint).Port));

        OnClientConnected?.Invoke(this, new TCPClientConnectedEventArgs()
        {
          clientIPE = so.sock.RemoteEndPoint as IPEndPoint
        });

        _dataCurrPtr = 0;

        _sck.sock.BeginReceive(_sck.recvBuf, 0, _sck.recvBuf.Length, SocketFlags.None,
          new AsyncCallback(ClntDataReceived), so);
      }
      else
      {
        OnClientConnected?.Invoke(this, null);
      }
    }

    private void ClntDataReceived(IAsyncResult ar)
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
              if (ShowRecvInfo)
                LogInfo(String.Format("Received {0}[B] from {1}", len, so.sock.RemoteEndPoint));

              ProcessRecvData(so, len);

              so.sock.BeginReceive(so.recvBuf, 0, so.recvBuf.Length, SocketFlags.None,
                new AsyncCallback(ClntDataReceived), so);
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

              OnClientDisconnected?.Invoke(this, new TCPClientConnectedEventArgs()
              {
                  clientIPE = so.sock.RemoteEndPoint as IPEndPoint
              });

            }            
            

          }
          break;
        case SocketError.ConnectionReset:
          so.sock.Disconnect(true);
          LogInfo("ConnectionReset = Disconnect");
                    OnClientDisconnected?.Invoke(this, new TCPClientConnectedEventArgs()
                    {
                        clientIPE = so.sock.RemoteEndPoint as IPEndPoint
                    });

                    break;
        default:
          LogError("Sock ERR: " + serr);
          break;
      }
    }

    public bool Disconnect()
    {
      if (_sck == null)       // not connected yet ?
      {
        LogError("Cannot disconnect - connection not exists");
        return false;
      }

      _sck.sock.Close();
      _sck.sock.Dispose();
      _sck.sock = null;
      _sck = null;

      LogInfo("Disconnect OK");
      return true;
    }

    public bool Send(byte b)
    {
      return (_sck == null) ? false : Send2Socket(b, _sck.sock);
    }

    public bool Send(char c)
    {
      return (_sck == null) ? false : Send2Socket(c, _sck.sock);
    }

    public bool Send(String str)
    {
      return (_sck == null) ? false : Send2Socket(str, _sck.sock);
    }

    public bool Send(byte[] ba)
    {
      return (_sck == null) ? false : Send2Socket(ba, _sck.sock);
    }

    public void Dispose()
    {
      if (_sck != null)       // exists ?
      {
        _sck.sock.Close();
        _sck.sock.Dispose();
        _sck.sock = null;
        _sck = null;
      }
    }
  }
} 
