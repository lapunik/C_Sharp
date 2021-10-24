using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKEY
{
    class Msg
    {
        public const int SizeBuff = 48;  //maximum size of Rx buffer
        public byte[] rxArr = new byte[SizeBuff];
        public int time;
        public int fc = 0;
        public Int32 keyID = 0;
        public int msgLength;


        public Msg()
        {
            for (int i = 0; i < SizeBuff; i++)  //constructor to prepare buffer with nulls if no input
            {
                this.rxArr[i] = 0;

            }
            this.time = 0;
        }
        public Msg(byte[] inputArr)         //conctructor to copy full buffer
        {
            for (int i = 0; i < SizeBuff; i++)
            {
                this.rxArr[i] = inputArr[i];
            }
            this.time = 0;
        }
        public Msg(int inTime, byte[] inputArr)         //conctructor to copy full buffer
        {
            for (int i = 0; i < SizeBuff; i++)
            {
                this.rxArr[i] = inputArr[i];
            }
            this.time = inTime;
        }
        public Msg(byte[] inputArr, int length)  //conctructor to copy amount of bytes from input parameter and rest of buffer fill with nulls
        {
            for (int i = 0; i < SizeBuff; i++)
            {
                if (i < length)
                {
                    this.rxArr[i] = inputArr[i];
                }
                else
                {
                    this.rxArr[i] = 0;
                }
            }
            this.time = 0;
            this.msgLength = length;
        }
        public Msg(int inTime, byte[] inputArr, int length)  //conctructor to fill time and copy amount of bytes from input parameter and rest of buffer fill with nulls
        {
            for (int i = 0; i < SizeBuff; i++)
            {
                if (i < length)
                {
                    this.rxArr[i] = inputArr[i];
                }
                else
                {
                    this.rxArr[i] = 0;
                }
            }
            this.time = inTime;
            this.msgLength = length;
        }

        public void SetID(byte[] inArr, int position)
        {
            this.keyID = inArr[position + 3] + (inArr[position + 2] << 8) + (inArr[position + 1] << 16) + (inArr[position] << 24);
        }

        public virtual bool CheckMsg() { return false; } //virtual method 

        public int Crc8(byte[] p_data, int length)
        {
            int count;
            int crc_value = 0xFF;  // 0xff => init value of CRC

            for (count = 0; count < length; count++)
            {
                crc_value = crc8Table[crc_value ^ p_data[count]];
            }
            return crc_value;
        }

        public int Crc8_hybrid(byte[] p_data, int msgLeng)  // count crc if message use not completed bytes
        {
            int index;
            int crc = 0xFF, length, last_byte;    // init value of CRC

            length = msgLeng - 1;
            // compute the first x byte of data using table computation method
            for (index = 0; index < length; index++)
            {
                crc = crc8Table[crc ^ p_data[index]];
            }


            last_byte = (p_data[length] >> 4);
            last_byte = (last_byte << 4);

            // XOR the current CRC
            crc ^= last_byte;

            // XOR the bits
            for (index = 0; index < 4; index++) // < 4 - half of one byte
            {
                if ((crc & 0x80) != 0)// is the bit in the first position on or zero
                {
                    crc <<= 1; // right bit shift of one bits
                    crc &= 0xFF;
                    crc ^= 0x1d; // Xor with GP
                }
                else
                {
                    crc <<= 1; // right bit shift of one bits
                }
            }
            return crc;
        }

        private static readonly byte[] crc8Table =
        {
            0x00, 0x1d, 0x3a, 0x27,
            0x74, 0x69, 0x4e, 0x53,
            0xe8, 0xf5, 0xd2, 0xcf,
            0x9c, 0x81, 0xa6, 0xbb,
            0xcd, 0xd0, 0xf7, 0xea,
            0xb9, 0xa4, 0x83, 0x9e,
            0x25, 0x38, 0x1f, 0x02,
            0x51, 0x4c, 0x6b, 0x76,
            0x87, 0x9a, 0xbd, 0xa0,
            0xf3, 0xee, 0xc9, 0xd4,
            0x6f, 0x72, 0x55, 0x48,
            0x1b, 0x06, 0x21, 0x3c,
            0x4a, 0x57, 0x70, 0x6d,
            0x3e, 0x23, 0x04, 0x19,
            0xa2, 0xbf, 0x98, 0x85,
            0xd6, 0xcb, 0xec, 0xf1,
            0x13, 0x0e, 0x29, 0x34,
            0x67, 0x7a, 0x5d, 0x40,
            0xfb, 0xe6, 0xc1, 0xdc,
            0x8f, 0x92, 0xb5, 0xa8,
            0xde, 0xc3, 0xe4, 0xf9,
            0xaa, 0xb7, 0x90, 0x8d,
            0x36, 0x2b, 0x0c, 0x11,
            0x42, 0x5f, 0x78, 0x65,
            0x94, 0x89, 0xae, 0xb3,
            0xe0, 0xfd, 0xda, 0xc7,
            0x7c, 0x61, 0x46, 0x5b,
            0x08, 0x15, 0x32, 0x2f,
            0x59, 0x44, 0x63, 0x7e,
            0x2d, 0x30, 0x17, 0x0a,
            0xb1, 0xac, 0x8b, 0x96,
            0xc5, 0xd8, 0xff, 0xe2,
            0x26, 0x3b, 0x1c, 0x01,
            0x52, 0x4f, 0x68, 0x75,
            0xce, 0xd3, 0xf4, 0xe9,
            0xba, 0xa7, 0x80, 0x9d,
            0xeb, 0xf6, 0xd1, 0xcc,
            0x9f, 0x82, 0xa5, 0xb8,
            0x03, 0x1e, 0x39, 0x24,
            0x77, 0x6a, 0x4d, 0x50,
            0xa1, 0xbc, 0x9b, 0x86,
            0xd5, 0xc8, 0xef, 0xf2,
            0x49, 0x54, 0x73, 0x6e,
            0x3d, 0x20, 0x07, 0x1a,
            0x6c, 0x71, 0x56, 0x4b,
            0x18, 0x05, 0x22, 0x3f,
            0x84, 0x99, 0xbe, 0xa3,
            0xf0, 0xed, 0xca, 0xd7,
            0x35, 0x28, 0x0f, 0x12,
            0x41, 0x5c, 0x7b, 0x66,
            0xdd, 0xc0, 0xe7, 0xfa,
            0xa9, 0xb4, 0x93, 0x8e,
            0xf8, 0xe5, 0xc2, 0xdf,
            0x8c, 0x91, 0xb6, 0xab,
            0x10, 0x0d, 0x2a, 0x37,
            0x64, 0x79, 0x5e, 0x43,
            0xb2, 0xaf, 0x88, 0x95,
            0xc6, 0xdb, 0xfc, 0xe1,
            0x5a, 0x47, 0x60, 0x7d,
            0x2e, 0x33, 0x14, 0x09,
            0x7f, 0x62, 0x45, 0x58,
            0x0b, 0x16, 0x31, 0x2c,
            0x97, 0x8a, 0xad, 0xb0,
            0xe3, 0xfe, 0xd9, 0xc4
        };
        public static readonly byte[] g_tab_crc4 =
        {
            0, 3, 6, 5,
            12, 15, 10, 9,
            11, 8, 13, 14,
            7, 4, 1, 2
        };
    }

    class ChallReq : Msg
    {
        public Int32 carWUP = 0;
        public int button = 0;
        public int f = 0;
        public enum RkeChallReqType
        {
            NotIdent = 0,
            RkeChallReq,
            SleepRequest,
            GoToSleep,
        }
        public RkeChallReqType rkeChR_Type = RkeChallReqType.NotIdent;

        public ChallReq(int inTime, byte[] inputArr, int length)
             : base(inTime, inputArr, length) { } //constructor inherited from parent class 

        public override bool CheckMsg()
        {
            int crc8Value = Crc8(this.rxArr, 10);
            int crc8Received = rxArr[10];
            if (crc8Value == crc8Received)
            {
                SetWUP(rxArr, 0);
                SetID(rxArr, 6);
                fc = rxArr[4] >> 4;
                f = (rxArr[4] >> 2) & 0x03;
                button = rxArr[5];
                if (f == 2)
                {
                    if (button == 0x44)
                    {
                        rkeChR_Type = RkeChallReqType.GoToSleep;
                    }
                    else
                    {
                        rkeChR_Type = RkeChallReqType.SleepRequest;
                    }
                }
                else
                {
                    rkeChR_Type = RkeChallReqType.RkeChallReq;
                }
                return true;
            }
            else return false;
        }

        public void SetWUP(byte[] inArr, int position)
        {
            this.carWUP = inArr[position + 3] + (inArr[position + 2] << 8) + (inArr[position + 1] << 16) + (inArr[position] << 24);
        }
    }

    class RkeChallenge : Msg
    {
        public int halfID = 0;

        public RkeChallenge(int inTime, byte[] inputArr, int length)
            : base(inTime, inputArr, length) { }//constructor inherited from parent class 

        public override bool CheckMsg()
        {
            int crc8Value = Crc8_hybrid(this.rxArr, 8);
            int crc8Received = (((rxArr[8] & 0xf0) >> 4) | (rxArr[7] << 4)) & 0xFF;
            if (crc8Value == crc8Received)
            {
                fc = rxArr[2] >> 4;
                halfID = rxArr[1] | (rxArr[0] << 8);
                return true;
            }
            else return false;
        }
    }

    class RkeResponse : Msg
    {
        public int button = 0;
        public int f = 0;
        public bool lfPing = false;
        public int lfPingValue = 0;

        public RkeResponse(int inTime, byte[] inputArr, int length)
             : base(inTime, inputArr, length) { }//constructor inherited from parent class 

        public override bool CheckMsg()
        {
            fc = rxArr[4] >> 4;
            button = rxArr[5];
            SetID(rxArr, 0);
            f = (rxArr[4] & 0x0c) >> 2;
            if (f == 1)
            {
                lfPingValue = rxArr[8];
                lfPing = true;
            }
            if (fc == 9) //there is no CRC but we can check Function Code
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    class RcpResponse : Msg
    {
        public int rcpSignal = 0;
        public int f = 0;
        public int rcpActive = 0;
        public int lfPingState = 0;
        public int lfPingValue = 0;


        public RcpResponse(int inTime, byte[] inputArr, int length)
             : base(inTime, inputArr, length) { }//constructor inherited from parent class 

        public override bool CheckMsg()
        {
            fc = rxArr[4] >> 4;

            if (fc == 12) //there is no CRC but we can check Function Code
            {
                rcpSignal = rxArr[5];
                SetID(rxArr, 0);
                rcpActive = (rxArr[6] & 0x30) >> 4;
                lfPingState = (rxArr[6] & 0xc0) >> 6;
                lfPingValue = (rxArr[12] << 8) | rxArr[13];
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    class THS_ChallReq : Msg
    {
        public THS_ChallReq(int inTime, byte[] inputArr, int length)
            : base(inTime, inputArr, length) { }//constructor inherited from parent class 

        public override bool CheckMsg()
        {
            fc = rxArr[2] >> 4;
            if (fc == 0x0b)
            {
                SetID(rxArr, 7);
                return true;
            }
            return false;
        }
    }
    class THS_Response : Msg
    {
        public bool crcPass = false;

        public THS_Response(int inTime, byte[] inputArr, int length)
            : base(inTime, inputArr, length) { }//constructor inherited from parent class 

        public override bool CheckMsg()
        {
            fc = rxArr[2] >> 4;
            if ((Interpreter.lastMsgType == Interpreter.MsgType.THS_ChallReq) || (Interpreter.lastMsgType == Interpreter.MsgType.THS_Chall) || (fc == 0x0a))
            {
                byte[] arr = new byte[21];
                for (int i = 0; i < 11; i++)
                {
                    arr[i] = Interpreter.lastTHSChallReq.rxArr[i];
                }
                for (int i = 0; i < 10; i++)
                {
                    arr[i + 11] = rxArr[i];
                }
                int crc8Value = Crc8(arr, 21);  //crc would need to be computed over Challange Request
                int crc8Received = rxArr[10];
                if (crc8Value == crc8Received)
                {
                    fc = rxArr[2] >> 4;
                    crcPass = true;
                }
                return true;
            }
            return false;
        }
    }
    class THS_Challenge : Msg
    {
        public THS_Challenge(int inTime, byte[] inputArr, int length)
            : base(inTime, inputArr, length) { }//constructor inherited from parent class 

        public override bool CheckMsg()
        {

            int crc8Value = Crc8(this.rxArr, 8);
            int crc8Received = rxArr[8];
            if (crc8Value == crc8Received)
            {
                fc = rxArr[2] >> 4;
                return true;
            }
            else return false;
        }
    }
    class THS_Status1 : Msg
    {
        public THS_Status1(int inTime, byte[] inputArr, int length)
            : base(inTime, inputArr, length) { }//constructor inherited from parent class 
        public override bool CheckMsg()
        {
            fc = rxArr[2] >> 4;
            if (fc == 4)
            {

                return true;
            }
            return false;
        }
    }
    class THS_Status2 : Msg
    {
        public THS_Status2(int inTime, byte[] inputArr, int length)
            : base(inTime, inputArr, length) { }//constructor inherited from parent class 
        public override bool CheckMsg()
        {
            fc = rxArr[2] >> 4;
            if (fc == 5)
            {

                return true;
            }
            return false;
        }
    }
    class THS_Status3 : Msg
    {
        public byte[] statusAll = new byte[18];  //buffer to store complete Status message -> from Status1 to Status3
        public THS_Status3(int inTime, byte[] inputArr, int length)
            : base(inTime, inputArr, length) { }//constructor inherited from parent class 

        public override bool CheckMsg()
        {
            fc = rxArr[2] >> 4;
            if (fc == 6)
            {
                if ((Interpreter.lastTHSStat1 != null) && (Interpreter.lastTHSStat2 != null))
                {
                    int i;
                    for (i = 0; i < 6; i++)
                    {
                        statusAll[i] = Interpreter.lastTHSStat1.rxArr[i];
                    }
                    for (i = 0; i < 6; i++)
                    {
                        statusAll[i + 6] = Interpreter.lastTHSStat2.rxArr[i];
                    }
                    for (i = 0; i < 6; i++)
                    {
                        statusAll[i + 12] = rxArr[i];
                    }
                    int crc8Value = Crc8(statusAll, 17); //check CRC over all messages
                    int crc8Received = statusAll[17];
                    if (crc8Value == crc8Received)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    class KI_Req1 : Msg
    {
        public KI_Req1(int inTime, byte[] inputArr, int length)
            : base(inTime, inputArr, length) { }//constructor inherited from parent class 

    }

    class KI_Req2 : Msg
    {
        int indexKI = 0;
        string kiType = "";
        public byte[] kiRequest = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public KI_Req2(int inTime, byte[] inputArr, int length)
            : base(inTime, inputArr, length) { }//constructor inherited from parent class 

        public override bool CheckMsg()
        {
            if (Interpreter.lastKiReq1 != null)
            {
                kiRequest[0] = Interpreter.lastKiReq1.rxArr[0];
                kiRequest[1] = Interpreter.lastKiReq1.rxArr[1];
                for (int i = 0; i < 8; i++)
                {
                    kiRequest[i + 2] = rxArr[i];
                }

                int crc8Value = Crc8(kiRequest, 9);
                int crc8Received = kiRequest[9];
                if (crc8Value == crc8Received)
                {
                    SetID(rxArr, 3);
                    fc = rxArr[2] >> 4;
                    indexKI = rxArr[2] & 0x0F;
                    return true;
                }

            }
            else { } // we do not have first part of KI Request -> we cannot compute CRC



            return false;
        }

        public string getKiType()
        {
            string strKi;

            switch (this.indexKI)
            {
                case 5:
                    strKi = "DWA";
                    break;
                case 8:
                    strKi = "Centerlock";
                    break;
                case 9:
                    strKi = "Coding";
                    break;
                case 10:
                    strKi = "Range";
                    break;
                default:
                    strKi = "Not valid Index";
                    break;
            }
            return strKi;
        }

    }

    class KI_Stat1 : Msg
    {
        public int indexKI = 0;
        public string kiType = "";
        public byte[] statusH = { 0, 0, 0, 0 };

        public KI_Stat1(int inTime, byte[] inputArr, int length)
            : base(inTime, inputArr, length) { }//constructor inherited from parent class 

        public override bool CheckMsg()
        {
            fc = rxArr[2] >> 4;
            if (fc == 2)
            {
                for (int i = 0; i < 4; i++)
                {
                    statusH[i] = rxArr[6 - i];
                }
                indexKI = rxArr[2] & 0x0F;
                return true;
            }
            else return false;
        }

        public string getKiType()
        {
            string strKi;

            switch (this.indexKI)
            {
                case 5:
                    strKi = "DWA";
                    break;
                case 8:
                    strKi = "Centerlock";
                    break;
                case 9:
                    strKi = "Coding";
                    break;
                case 10:
                    strKi = "Range";
                    break;

                default:
                    strKi = " _ ";
                    break;

            }
            return strKi;
        }
    }

    class KI_Stat2 : Msg
    {
        public byte[] status = { 0, 0, 0, 0, 0, 0, 0, 0 };

        public KI_Stat2(int inTime, byte[] inputArr, int length)
            : base(inTime, inputArr, length) { }//constructor inherited from parent class 

        public override bool CheckMsg()
        {
            if (true)
            {
                for (int i = 0; i < 4; i++)
                {
                    status[i] = rxArr[6 - i];  //status is in the bytes nr.3 -6, but I want the oposit order
                }
                for (int i = 0; i < 4; i++)
                {
                    status[i + 4] = Interpreter.lastKiStat1.statusH[i];  //status is in the bytes nr.3 -6, but I want the oposit order
                }
                return true;
            }
            else return false;
        }

        public string GetStringStatus()
        {
            string[] sarr = new string[8];
            for (int i = 0; i < 8; i++)
            {
                sarr[i] = status[i].ToString("X2");
            }
            return string.Join(" ", sarr);
        }
    }
    class CaChall : Msg
    {
        public int f = 0;
        public CaChall(int inTime, byte[] inputArr, int length)
             : base(inTime, inputArr, length) { } //constructor inherited from parent class 

        public override bool CheckMsg()
        {
            int crc8Value;
            int crc8Received;

            fc = rxArr[0] >> 4;
            if (fc == 10) //RCP Challange includes also RCP Status
            {
                crc8Value = Crc8(rxArr, 21);
                crc8Received = rxArr[21];
            }
            else
            {
                crc8Value = Crc8(rxArr, 17);
                crc8Received = rxArr[17];
            }
            if (crc8Value == crc8Received)
            {
                SetID(rxArr, 1);
                f = (rxArr[0] & 0x06) >> 2;
                return true;
            }
            return false;
        }
    }

    class CaResponse : Msg
    {
        public int f = 0;   //"f" signal
        public int amtHFM = 0; //how many RSSI measurements are included
        public double[,] dRssi; // 8 bytes array for Antennas RSSI
        public CaResponse(int inTime, byte[] inputArr, int length)
             : base(inTime, inputArr, length) { } //constructor inherited from parent class 

        public override bool CheckMsg()
        {
            if (this.msgLength >= 10)
            {
                int crc8 = 0;
                int crcReceived = 0;
                fc = rxArr[0] >> 4;
                f = (rxArr[0] & 0x6) >> 2;
                if (this.msgLength < 15)
                {
                    crc8 = Crc8(rxArr, 9);
                    crcReceived = rxArr[9];
                    if (crc8 == crcReceived)
                    {
                        amtHFM = 0;
                        return true;
                    }
                }
                else
                {
                    amtHFM = (this.msgLength - 11) / 4;  //how many HFM (CA Antenna measuremens can be in the message?
                    if (amtHFM <= 8)
                    {
                        int posCrc = 10 + amtHFM * 4;
                        dRssi = new double[amtHFM, 4];
                        crc8 = Crc8(rxArr, posCrc);
                        crcReceived = rxArr[posCrc];
                        if (crc8 == crcReceived)
                        {
                            //RSSI interpretation
                            for (int i = 0; i < amtHFM; i++)
                            {
                                const int fst = 9;
                                double xval, yval, zval, xyzval = 0;
                                int mantisse, exponent, val = 0;
                                int xyzvalue = (rxArr[i * 4 + fst] << 24) | (rxArr[i * 4 + fst + 1] << 16) | (rxArr[i * 4 + fst + 2] << 8) | (rxArr[i * 4 + fst + 3]); //to make it easier, first only copy one Antenna in one integer

                                /* X-Axis */
                                val = xyzvalue & 0x7FF;
                                mantisse = val & 0x7F;
                                exponent = (val >> 7) & 0x0F;
                                xval = (Math.Pow(2, exponent) / 2) + ((double)mantisse * Math.Pow(2, exponent) / 256);

                                /* Y-Axis */
                                val = (xyzvalue >> 11) & 0x7FF;
                                mantisse = val & 0x7F;
                                exponent = (val >> 7) & 0x0F;
                                yval = (Math.Pow(2, exponent) / 2) + ((double)mantisse * Math.Pow(2, exponent) / 256);


                                /* Z-Axis */
                                val = (xyzvalue >> 22) & 0x3FF;
                                int pom = rxArr[posCrc - 1];
                                int pom2 = (0x01 << i);
                                int pom3 = pom & pom2;

                                if (pom3 != 0)//((rxArr[posCrc - 1] & (0x01 << i)) != 0)
                                {
                                    val = val | 0x400;
                                }
                                mantisse = val & 0x7F;
                                exponent = (val >> 7) & 0x0F;
                                zval = (Math.Pow(2, exponent) / 2) + ((double)mantisse * Math.Pow(2, exponent) / 256);

                                xyzval = Math.Sqrt(xval * xval + yval * yval + zval * zval);  //sum of all axis

                                dRssi[i, 0] = xval; //copy all values to a two dimentional array where will be results stored and later used
                                dRssi[i, 1] = yval;
                                dRssi[i, 2] = zval;
                                dRssi[i, 3] = xyzval;
                            }
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }

    class AntiColl : Msg
    {

        public AntiColl(int inTime, byte[] inputArr, int length)
             : base(inTime, inputArr, length) { } //constructor inherited from parent class 



        public override bool CheckMsg()
        {
            //check crc4
            int crc4Value = Check_AC_crc4(this.rxArr, 4, 0xd);
            int crc4Received = rxArr[4] >> 4;
            if (crc4Value == crc4Received)//Check_AC_crc4(outArr, 5, 0x9) == (outArr[4] >> 4))
            {
                fc = 0xd;
                SetID(rxArr, 0);
                return true;
            }
            else
            {
                //ToDo - CRC with the FC 0xE or AC with a wrong CRC?
                crc4Value = Check_AC_crc4(rxArr, 4, 0xe);
                if (crc4Value == crc4Received)//Check_AC_crc4(outArr, 5, 0x9) == (outArr[4] >> 4))
                {
                    fc = 0xe;
                    SetID(rxArr, 0);
                    return true;
                }

            }
            return false;

        }

        private int Check_AC_crc4(byte[] dataBuf, int length, int fc)
        {
            int crc = 0xF;
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

    }

    class LfMsg : Msg
    {
        public bool crcCheck = false;
        public byte[] wupArr = { 0, 0, 0, 0 };
        public int seq = 0;
        public int irBit = 0;
        public int channel = 0;
        public int anzHFM = 0;
        public int anzAC = 0;
        public enum LFType
        {
            NotIdent = 0,
            Ckt,
            Ce,
            Cg,
            Ki,
            Sds,
            LFpingSP21,
            SleepRq,
            LFpingSP18,
            CktControl,
            rcp,
        }
        public LFType lfType = LFType.NotIdent;

        public LfMsg(int inTime, byte[] inputArr, int length)
            : base(inTime, inputArr, length) { } //constructor inherited from parent class 

        public override bool CheckMsg()
        {
            if (msgLength >= 5)
            {
                if (msgLength >= 7)  //Keysearch
                {
                    bool ret = true; //return true, also if FC is OK and CRC4 does not match....
                    fc = rxArr[4] >> 4;
                    switch (fc)
                    {
                        case 0:
                            lfType = LFType.Ce;
                            break;
                        case 1:
                            lfType = LFType.Cg;
                            break;
                        case 2:
                            lfType = LFType.Ki;
                            break;
                        case 3:
                            lfType = LFType.Sds;
                            break;
                        case 7:
                            lfType = LFType.LFpingSP21;
                            break;
                        case 8:
                            lfType = LFType.SleepRq;
                            break;
                        case 10:
                            lfType = LFType.CktControl;
                            seq = (rxArr[4] >> 2) & 0x03;
                            SetWup();
                            return false;
                            break;
                        case 12:
                            lfType = LFType.rcp;
                            break;
                        default:
                            ret = false;
                            break;
                    }
                    crcCheck = CheckCRC4(lfType);
                    if(crcCheck)
                    {
                        seq = rxArr[6] >> 6;
                        channel = (rxArr[4] & 0x04) >> 2;
                        anzHFM = rxArr[5] >> 4;
                        anzAC = rxArr[5] & 0x0F;
                        irBit = (rxArr[6] & 0x20) >> 5;
                        SetWup();
                        ret = true;
                    }
                    return ret;
                }
                else
                {
                    lfType = LFType.LFpingSP18;
                    if ((rxArr[4] & 0x70) == 0x70)
                    {
                        lfType = LFType.LFpingSP21;
                    }
                }

                
            }
            else if (msgLength >= 3) //LF Ping or CKT
            {
                //for ckt Zone we need to know complete WUP -> we can search for it in the old messages -> CKT usually begins with Keysearch..
                lfType = LFType.Ckt;

            }
            return false;
        }
        public void SetWup()
        {
            for(int i =0; i<4;i++)
            {
                this.wupArr[i] = rxArr[i];
            }
        }
        private bool CheckCRC4(LFType inlfType)
        {
            int crc = 0xF;

            //crc = g_tab_crc4[crc];
            for (int k = 4; k < 6; k++)
            {
                crc ^= rxArr[k] >> 4;
                crc = g_tab_crc4[crc];
                crc ^= rxArr[k] & 0xF;
                crc = g_tab_crc4[crc];
            }
            crc ^= rxArr[6] >> 4;
            crc = g_tab_crc4[crc];

            if (inlfType == LFType.Sds)
            {
                for (int k = 7; k < 11; k++)
                {
                    crc ^= rxArr[k] >> 4;
                    crc = g_tab_crc4[crc];
                    crc ^= rxArr[k] & 0xF;
                    crc = g_tab_crc4[crc];
                }
            }
            if (crc == (rxArr[6] & 0x0f))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class LfCkt : Msg
    {
        public int cktZone = 0;
        public int seq = 0;
        public int crcOverWup = 0;
        public bool crcCheck = false;

        public LfCkt(int inTime, byte[] inputArr, int length)
            : base(inTime, inputArr, length) { } //constructor inherited from parent class 

        public override bool CheckMsg()
        {
            if ((msgLength >= 3) & (msgLength < 5)) //set reasonable tolerance for CKT WUP
            {
                if (Crc4Check())
                {
                    crcCheck = true;
                    seq = rxArr[0] >> 6;
                    cktZone = (rxArr[0] >> 4) & 0x03;
                }
                else
                {
                    crcCheck = false;
                }
                return true;
            }
            return false;
        }
        private bool Crc4Check()
        {
            bool retVal = false;
            int crc = 0x0F;  //init value for CRC4
            if ((Interpreter.lastLfCkt != null) && (Interpreter.lastLfCkt.crcCheck)) //was there already CKT wup where we could compute CRC4?
            {
                crc = Interpreter.lastLfCkt.crcOverWup;
                crc ^= rxArr[0] >> 4;
                crc = g_tab_crc4[crc];
                retVal = true;
            }
            else if (Interpreter.lastLfMsg != null) //first check if there is already last LF message with the complete WUP stored
            {
                for (int i = 0; i < 4; i++)
                {
                    int val = Interpreter.lastLfMsg.wupArr[i];
                    if (val != 0)
                        retVal = true;  //set indicator, that we have read a valid WUP and not only zeros...
                    crc ^= Interpreter.lastLfMsg.wupArr[i] >> 4;
                    crc = g_tab_crc4[crc];
                    crc ^= Interpreter.lastLfMsg.wupArr[i] & 0xF;
                    crc = g_tab_crc4[crc];
                }
                this.crcOverWup = crc;
                crc ^= rxArr[2] >> 4;
                crc = g_tab_crc4[crc];
            }
            if (retVal)
            {
                if (crc == (rxArr[2] & 0x0f))
                {
                    retVal = true;

                }
                else retVal = false;
            }
            return retVal;
        }
    }

    class LfCktCtr : Msg
    {
        public Int32 cktCtr_i32 = 0;
        public int seq = 0;
        public byte[] wupArr= { 0, 0, 0, 0 };
        

        public LfCktCtr(int inTime, byte[] inputArr, int length)
            : base(inTime, inputArr, length) { } //constructor inherited from parent class 

        public override bool CheckMsg()
        {
            if ((msgLength >= 12) & (msgLength <= 13)) //set reasonable tolerance for CKT&MEMS conrtol
            {
                cktCtr_i32 = (rxArr[5] << 24) | (rxArr[6] << 16) | (rxArr[7] << 8) | (rxArr[8]);
                SetWup();
                return true;
            }
            return false;
        }

        public void SetWup()
        {
            for (int i = 0; i < 4; i++)
            {
                this.wupArr[i] = rxArr[i];
            }
        }
    }
}
