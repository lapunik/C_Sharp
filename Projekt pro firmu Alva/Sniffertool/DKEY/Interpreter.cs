using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKEY
{


    class Interpreter
    {
        public static readonly byte[] g_tab_crc4 =
        {
            0, 3, 6, 5,
            12, 15, 10, 9,
            11, 8, 13, 14,
            7, 4, 1, 2
        };
        public enum MsgType
        {
            NotDetected = 0,
            LF_WUP,
            CACG_AC,
            CACG_Chall,
            CACG_Res,
        }

        private int Check_AC_crc4(byte[] dataBuf, int length, int fc)
        {
            int crc= 0xF;
            //byte first_byte = 0xA0 | fc;
            crc ^= 0xA;  //just an help to make an event bytes
            crc = g_tab_crc4[crc];
            crc ^= fc & 0xF;
            crc = g_tab_crc4[crc];

            for (int k = 0; k < length; k++)
            {
                crc ^= dataBuf[k] >> 4;
                crc = g_tab_crc4[crc];
                crc ^= dataBuf[k] & 0xF;
                crc = g_tab_crc4[crc];
            }
            return crc;
        }

        public MsgType MsgInterpreter(string inMsg, byte[] outArr)
        {
            MsgType msgType = MsgType.NotDetected;
            int amtRxByte = (inMsg.Length / 3); //amount of bytes in the received string
            byte[] arrAll = new byte[amtRxByte];
            amtRxByte -= 3;  // three first bytes are only header
           

            if (ConvertHexStringToByteArray(inMsg, 0, arrAll))
            {
                int baudrate = arrAll[0] & 0x0F;
                int commDirection = (arrAll[0] & 0xF0) >> 4;
                for (int i = 0; i < amtRxByte; i++) //copy only payload
                {
                    outArr[i] = arrAll[i+3];
                }

                if (baudrate == 1)  // -->8 kbit/s
                {

                } else if(baudrate == 2) // -->19.2 kbit/s
                {
                    switch (commDirection)
                    {
                        case 0:  //key->Car  - AC or Response?
                        case 1:
                            if ((amtRxByte > 4) && (amtRxByte < 10)) //Anti-collision lenght plus tolerance
                            {
                                //check crc4
                                int crc4Value = Check_AC_crc4(outArr, 4, 0xd);
                                int crc4Received = outArr[4] >> 4;
                                if (crc4Value == crc4Received )//Check_AC_crc4(outArr, 5, 0x9) == (outArr[4] >> 4))
                                {
                                    msgType = MsgType.CACG_AC;
                                }
                                else
                                {
                                    //ToDo - CRC with the FC 0xE or AC with a wrong CRC?
                                }
                            }
                            else
                            {

                            }

                            break;
                        case 2: //Car->key challange?
                        case 3:
                            break;
                        default:
                            
                            break;
                    }

                } else if(baudrate == 3)  //--> 2kbit/s
                {

                }


            }

            return msgType;
        }

        public bool ConvertHexStringToByteArray(string hexString, int firstBytePosition, byte[] outBuff)
        {
            /*if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(System.Globalization.CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }*/
            int dataLen = hexString.Length / 3;
            string byteValue = "";
            int indexString = firstBytePosition;
            int indexBuff = 0;
            while ((indexString < hexString.Length)/*&& indexBuff< sizeof(outBuff[])*/)
            {
                byteValue = hexString.Substring(indexString, 1);
                if (byteValue == "/n") return true;
                if (byteValue == " ")
                {
                    indexString++;
                }
                else
                {
                    byteValue = hexString.Substring(indexString, 2);
                    /* outBuff[indexBuff] = Convert.ToByte(byteValue, 16);*/
                    outBuff[indexBuff] = byte.Parse(byteValue, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture);
                    indexBuff++;
                    indexString += 3; //nex time new number - plus 3 characters
                }


            }

            return true;
        }
    }
}
