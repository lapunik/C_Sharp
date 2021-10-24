using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TrainTTLibrary
{
  public enum eRecvDataType { dataChar, dataByte, dataStringNL, dataBlockBytes, STX, unknown };

  public abstract class TCPBase
  {
    public EventHandler<TCPMsgEventArgs> OnError = null;
    public EventHandler<TCPMsgEventArgs> OnMessage = null;

    public EventHandler<TCPClientConnectedEventArgs> OnClientConnected = null;
        public EventHandler<TCPClientConnectedEventArgs> OnClientDisconnected = null;
        public EventHandler<TCPReceivedEventArgs> DataReceived = null;

    protected void LogError(String s)
    {
      OnError?.Invoke(this, new TCPMsgEventArgs(s));
    }

    protected void LogInfo(String s)
    {
      OnMessage?.Invoke(this, new TCPMsgEventArgs(s));
    }

    /// <summary>
    /// Priznak, jestli se ma posilat chyba "prazdny radek" pri prijmu textu, defaultne zapnuto
    /// </summary>
    public bool EmitErrorEmptyLineRecv { get; set; } = true;

    protected eRecvDataType _dataType = eRecvDataType.dataByte;
    public eRecvDataType DataType
    {
      get { return _dataType; }
      set
      {
        _dataType = value;
        //TODO update internal structures
      }
    }

    const int DEF_BLOCK_SIZE = 1024;

    protected int _dataBlockSize = 0;
    protected int _dataCurrPtr = 0;
    protected byte[] _dataBlock = null;
    protected byte[] _dataStartReq = null;

    public void ReqDataBlockSize(int size)
    {
      _dataBlockSize = size;
    }

    public void ReqDataStartPattern(byte[] ba)
    {
      if (ba == null)
        _dataStartReq = null;
      else
      {
        _dataStartReq = new byte[ba.Length];
        Array.Copy(ba, _dataStartReq, ba.Length);
      }
    }

    static char[] _caSplitNL = new char[] { /*'\r',*/ '\n' };

    protected void ProcessRecvData(SocketObject co, int dataLen)
    {
      switch (_dataType)
      {
        case eRecvDataType.dataByte:
          for (int i = 0; i < dataLen; i++)
          {
            DataReceived?.Invoke(this, new TCPReceivedEventArgs()
            {
              data = co.recvBuf[i],
              dataType = eRecvDataType.dataByte
            });
          }
          break;
        case eRecvDataType.dataChar:
          char[] ca = null;

          try
          {
            ca = Encoding.UTF8.GetChars(co.recvBuf, 0, dataLen);
          }
          catch (Exception ex)
          {
            LogError(ex.Message);
          }

          if ((ca != null) && (ca.Length > 0))
          {
            foreach (char c in ca)
              DataReceived?.Invoke(this, new TCPReceivedEventArgs()
              {
                data = c,
                dataType = eRecvDataType.dataChar
              });
          }
          break;
        case eRecvDataType.dataStringNL:
          {
            String str = Encoding.UTF8.GetString(co.recvBuf, 0, dataLen);
            LogInfo(String.Format("Content: {0}", str));

            if (str.Contains('\n'))
            {
              String[] saLines = str.Split(_caSplitNL, StringSplitOptions.None); // NE !! .RemoveEmptyEntries);
              foreach (String s in saLines)
              {
                co.sbRecv.Append(s.TrimEnd());

                String sPar = co.sbRecv.ToString();
                if (String.IsNullOrEmpty(sPar))
                {
                  if (EmitErrorEmptyLineRecv)
                    LogError("Empty text or whitespaces");
                }
                else
                  DataReceived?.Invoke(co, new TCPReceivedEventArgs()
                  {
                    data = sPar,
                    dataType = eRecvDataType.dataStringNL
                  });

                co.sbRecv.Clear();
              }
            }
            else
              co.sbRecv.Append(str.Trim());
          }
          break;
        case eRecvDataType.dataBlockBytes:
//          if (_dataBlockSize > 0)
          {
            if (_dataCurrPtr == 0)      // first data block ?
            {
              if (_dataStartReq != null)      // some req atarting mask ?
              {
                if (dataLen < _dataStartReq.Length)    // smaller ?
                {
                  LogError("Start block size < start pattern");
                  break;                      // throw away
                }

                bool eq = true;
                for (int i = 0; i < _dataStartReq.Length; i++)
                  if (_dataStartReq[i] != co.recvBuf[i])
                    eq = false;

                if (!eq)
                {
                  LogError("Start block not match start pattern");
                  break;                      // throw away
                }
              }

              _dataBlock = new byte[(_dataBlockSize == 0) ? DEF_BLOCK_SIZE : _dataBlockSize];
              // alloc complete buffer
            }

            //TODO check _dataCurrPtr + dataLen > _dataBlock.Length !!
            Array.Copy(co.recvBuf, 0, _dataBlock, _dataCurrPtr, dataLen);
            _dataCurrPtr += dataLen;

            if (_dataCurrPtr >= _dataBlockSize)
            {
              DataReceived?.Invoke(this, new TCPReceivedEventArgs()
              {
                data = _dataBlock,
                dataType = eRecvDataType.dataBlockBytes
              });

              _dataBlock = null;
              _dataCurrPtr = 0;
            }
          }
//          else
//            LogError("Block size == 0");
          break;
        case eRecvDataType.STX:
          if (_dataBlock == null)
            _dataBlock = new byte[(_dataBlockSize == 0) ? DEF_BLOCK_SIZE : _dataBlockSize];

          for(int i =0;i<dataLen;i++)     // all received data
          {
            byte b = co.recvBuf[i]; 
          
            if (_dataCurrPtr == 0)        // start waiting for SOH
            {
              if (b != 0x01)            // SOH - required as packet start
                continue;               // next
            }

            _dataBlock[_dataCurrPtr] = b;
            _dataCurrPtr++;
            if (b == 0x03)                // was ETX - finish byte
            {
              byte[] rdata = new byte[_dataCurrPtr];
              Array.Copy(_dataBlock, 0, rdata, 0, _dataCurrPtr);
              DataReceived?.Invoke(this, new TCPReceivedEventArgs()
              {
                data = rdata,
                dataType = eRecvDataType.STX
              });
              _dataCurrPtr = 0;
            }

            if (_dataCurrPtr >= _dataBlock.Length)
              _dataCurrPtr = _dataBlock.Length - 1;     // overwrite last position
          }
          break;
        default:
          throw new NotImplementedException("Processing for data type " + _dataType + " not implented");
      }
    }

    protected bool Send2Socket(byte b, Socket sock)
    {
      byte[] ba = new byte[1] { b };
      return Send2Socket(ba, sock);
    }

    protected bool Send2Socket(char c, Socket sock)
    {
      byte[] ba = Encoding.UTF8.GetBytes(new char[] { c });
      return Send2Socket(ba, sock);
    }

    protected bool Send2Socket(String str, Socket sock)
    {
      if (String.IsNullOrEmpty(str))
        return false;

      return Send2Socket(Encoding.UTF8.GetBytes(str), sock);
    }

    protected bool Send2Socket(byte[] ba, Socket sock)    //TODO variant with offset, length
    {
      if ((ba == null) || (ba.Length == 0))
      {
        LogError("Send - empty data");
        return false;
      }

      if (sock.Connected)       // last succesfull action ?
      {
        SocketError serr = SocketError.Success;
        int x = sock.Send(ba, 0, ba.Length, SocketFlags.None, out serr);

        if (serr != SocketError.Success)
          LogError("Send - " + serr);

        return (x > 0);     // succesfully sended bytes
        /*
        bool bb = false;
        try
        {
          bb = 0 < sock.Send(ba);
        }
        catch (Exception ex)
        {
          LogError("SOCK SEND: " + ex.Message);
        }

        return bb;
        */
      }
      else
        return false;
    }
  }

  public class TCPMsgEventArgs : EventArgs
  {
    public TCPMsgEventArgs()
    {    }

    public TCPMsgEventArgs(String msg) : this ()
    {
      Text = msg;
    }

    public String Text = String.Empty;
  }

  public class TCPClientConnectedEventArgs : EventArgs
  {
    public IPEndPoint clientIPE = null;
  }

  public class TCPReceivedEventArgs : EventArgs
  {
    public object data = null;
    public eRecvDataType dataType = eRecvDataType.unknown;
  }

  public class SocketObject
  {
    public Socket sock = null;
    public const int DEF_BUF_SIZE = 10 * 1024;      // 10kB
    public byte[] recvBuf = null;
    public StringBuilder sbRecv = new StringBuilder();

    public SocketObject() : this(DEF_BUF_SIZE)
    { }

    public SocketObject(int bufSize)
    {
      recvBuf = new byte[bufSize];
    }
  }
}
