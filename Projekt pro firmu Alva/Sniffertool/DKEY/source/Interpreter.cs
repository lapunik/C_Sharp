using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKEY
{
    class Interpreter
    {
        public static AntiColl lastAC;
        public static CaResponse lastCaRes;
        public static CaChall lastCaChall;
        public static ChallReq lastRKEChallReq;
        public static RkeChallenge lastRKEChall;
        public static RkeResponse lastRKERes;
        public static RcpResponse lastRCPRes;
        public static KI_Req1 lastKiReq1;
        public static KI_Req2 lastKiReq;
        public static KI_Stat1 lastKiStat1;
        public static KI_Stat2 lastKiStat2;
        public static THS_ChallReq lastTHSChallReq;
        public static THS_Challenge lastTHSChall;
        public static THS_Response lastTHSRes;
        public static THS_Status1 lastTHSStat1;
        public static THS_Status2 lastTHSStat2;
        public static THS_Status3 lastTHSStat3;
        public static LfMsg lastLfMsg;
        public static LfCkt lastLfCkt;
        public static LfCktCtr lastCktCtr;

        public enum MsgType
        {
            NotDetected = 0,
            LF_WUP,
            LF_WUP_Short,
            LF_CktControl,
            LF_Ping,
            CACG_AC,
            CACG_Chall,
            CACG_Res,
            RKE_challReq,
            SleepReq,
            GoToSleep,
            RKE_chall,
            RKE_Res,
            RCP_Res,
            KI_Req1,
            KI_Req,
            KI_Stat1,
            KI_Stat2,
            THS_ChallReq,
            THS_Chall,
            THS_Res,
            THS_St1,
            THS_St2,
            THS_St3
        }

        public static MsgType lastMsgType = MsgType.NotDetected;

        public MsgType MsgInterpreter(int time, string inMsg, byte[] outArr)
        {
            MsgType msgType = MsgType.NotDetected;
            int amtRxByte = ((inMsg.Length + 1)/ 3); //amount of bytes in the received string
            byte[] arrAll = new byte[amtRxByte];
            amtRxByte -= 3;  // three first bytes are only header


            if ((amtRxByte > 1) && (amtRxByte < 100) && (ConvertHexStringToByteArray(inMsg, 0, arrAll)))
            {
                int baudrate = arrAll[0] & 0x0F;
                int commDirection = (arrAll[0] & 0xF0) >> 4;
                for (int i = 0; i < amtRxByte; i++) //copy only payload
                {
                    outArr[i] = arrAll[i+3];
                }
                if (commDirection == 4)  //--> LF sniffer
                {
                    if ((amtRxByte >= 5)) //the possible range for the LF message with the long WUP
                    {
                        if (amtRxByte < 18)
                        {
                            LfMsg lf = new LfMsg(time, outArr, amtRxByte);
                            if (lf.CheckMsg())  //be awere, this message is true also if CRC4 is not valid, it need to be checked separately (lf.crcCheck)
                            {
                                msgType = MsgType.LF_WUP;
                                lastLfMsg = lf; //message is stored even if CRC4 is not valid
                            }
                            else
                            {
                                if (lf.lfType == LfMsg.LFType.CktControl)
                                {
                                    LfCktCtr lfCktCtr = new LfCktCtr(time, outArr, amtRxByte);
                                    if (lfCktCtr.CheckMsg())
                                    {
                                        msgType = MsgType.LF_CktControl;
                                        lastCktCtr = lfCktCtr;
                                    }
                                }
                                else if ((lf.lfType == LfMsg.LFType.LFpingSP18) || (lf.lfType == LfMsg.LFType.LFpingSP21))
                                {
                                    msgType = MsgType.LF_Ping;
                                }
                                else { }
                            }
                          /*  if ((amtRxByte == 12) && ((outArr[4] >> 4) == 0x0A))  //ckt control??
                            {
                                msgType = MsgType.LF_CktControl;
                            }
                            else
                            {

                            }*/


                        }
                        else { }
                    }
                    else if (amtRxByte >= 3) // possible range for CKT Wup
                    {
                        LfCkt ckt = new LfCkt(time, outArr, 3);
                        if (ckt.CheckMsg())
                        {
                            if (ckt.crcCheck)  //store the message only of CRC4 was right
                            {
                                lastLfCkt = ckt;
                            }
                            msgType = MsgType.LF_WUP_Short;
                        }

                    }
                    else { }
                }
                if (baudrate == 1)  // -->8 kbit/s
                {
                    switch (commDirection)
                    {
                        case 0:  //key->Car  - Challange Reques or Response, or CKT AC?
                        case 1:
                            if ((amtRxByte >= 11) && (amtRxByte <= 13)) //is length plausible for Challange request (11bytes)? (with small reserve) 
                            {
                                ChallReq chRq = new ChallReq(time, outArr, 11);
                                if (chRq.CheckMsg())//check if crc for challange request would match
                                {
                                    if(chRq.rkeChR_Type == ChallReq.RkeChallReqType.SleepRequest)
                                    {
                                        msgType = MsgType.SleepReq;
                                    }else if (chRq.rkeChR_Type == ChallReq.RkeChallReqType.GoToSleep)
                                    {
                                        msgType = MsgType.GoToSleep;
                                    }
                                    else
                                    {
                                        msgType = MsgType.RKE_challReq;
                                    }                                
                                    lastRKEChallReq = chRq;
                                }
                                else // if crc for challange request does not match, try if it is RKE Response
                                {
                                    RkeResponse rkeRes = new RkeResponse(time, outArr, 11);

                                    if (rkeRes.CheckMsg())   //check for RKE Response -> only FC is compared here // TODO - check for previous messages
                                    {
                                        lastRKERes = rkeRes;
                                        msgType = MsgType.RKE_Res;
                                    }

                                }
                            }
                            else
                            {
                                //RCP response?


                            }

                            break;
                        case 2: //Car->key RKE challange?
                        case 3:
                            if ((amtRxByte >= 9) && (amtRxByte <= 10))
                            {
                                RkeChallenge ackChall = new RkeChallenge(time, outArr, 9);
                                if (ackChall.CheckMsg())
                                {
                                    lastRKEChall = ackChall;
                                    msgType = MsgType.RKE_chall;
                                }

                            }
                            break;
                        default:

                            break;
                    }

                }
                else if (baudrate == 2) // -->19.2 kbit/s
                {
                    switch (commDirection)
                    {
                        case 0:  //key->Car  - AC or Response?
                        case 1:
                            if ((amtRxByte >= 5) && (amtRxByte < 10)) //Anti-collision lenght plus tolerance
                            {
                                AntiColl ac = new AntiColl(time, outArr, 5);
                                if (ac.CheckMsg())
                                {
                                    msgType = MsgType.CACG_AC;
                                    lastAC = ac;
                                }
                                else
                                {
                                    //ToDo - AC with a wrong CRC?
                                }
                            }
                            else  //probably CA response
                            {
                                if (amtRxByte < 48)
                                {
                                    CaResponse res = new CaResponse(time, outArr, amtRxByte);
                                    if (res.CheckMsg())
                                    {
                                        lastCaRes = res;
                                        msgType = MsgType.CACG_Res;
                                    }
                                }
                            }

                            break;
                        case 2: //Car->key challange?
                        case 3:
                            if (amtRxByte >= 18)
                            {
                                CaChall chall = new CaChall(time, outArr, amtRxByte);
                                if (chall.CheckMsg())
                                {
                                    lastCaChall = chall;
                                    msgType = MsgType.CACG_Chall;
                                }
                            }
                            break;
                        default:

                            break;
                    }

                }
                else if (baudrate == 3)  //--> 2kbit/s
                {
                    switch (commDirection)
                    {
                        case 0:  //key->Car  - KI or THS?
                        case 1:
                            if (amtRxByte > 11)  // it has to be THS request
                            {
                                if ((Interpreter.lastMsgType == MsgType.THS_Chall) || (Interpreter.lastMsgType == MsgType.THS_ChallReq)) //is there a probability that the message is Response instead of Request? 
                                {
                                    THS_Response thsRes = new THS_Response(time, outArr, 11);
                                    if (thsRes.CheckMsg())
                                    {
                                        msgType = MsgType.THS_Res;
                                        lastTHSRes = thsRes;
                                    }
                                }
                                if (msgType != MsgType.THS_Res) //message is not a response, lets check the Challange Request
                                {
                                    THS_ChallReq thsChallReq = new THS_ChallReq(time, outArr, 11);
                                    if (thsChallReq.CheckMsg())
                                    {
                                        msgType = MsgType.THS_ChallReq;
                                        lastTHSChallReq = thsChallReq;
                                    }
                                }
                            }
                            else if (amtRxByte >= 8) //Request lenght plus tolerance
                            {
                                KI_Req2 kiR2 = new KI_Req2(time, outArr, 8);
                                if (kiR2.CheckMsg())
                                {
                                    msgType = MsgType.KI_Req;
                                    lastKiReq = kiR2;
                                }
                            }
                            else
                            {
                                if (amtRxByte <= 3)  //KI Request1 - two bytes of the WUP
                                {
                                    KI_Req1 kiR1 = new KI_Req1(time, outArr, 2);
                                    msgType = MsgType.KI_Req1;
                                    lastKiReq1 = kiR1;
                                }
                            }

                            break;
                        case 2: //Car->key KI or THS Status?
                        case 3:
                            if ((amtRxByte <= 7) && (amtRxByte >= 6))  //THS Statuses heve length 6 bytes
                            {
                                int fcCheck = 0; //since there are 3 possible THS Status messages, the fastest way will be to check Function code which is 4bist of the third byte
                                fcCheck = outArr[2] >> 4;
                                switch (fcCheck)
                                {
                                    case 4: //THS Status 1
                                        THS_Status1 thsStat1 = new THS_Status1(time, outArr, 6);
                                        if (thsStat1.CheckMsg())
                                        {
                                            Interpreter.lastTHSStat1 = thsStat1;
                                            msgType = MsgType.THS_St1;
                                        }
                                        break;
                                    case 5: //THS Status 2
                                        THS_Status2 thsStat2 = new THS_Status2(time, outArr, 6);
                                        if (thsStat2.CheckMsg())
                                        {
                                            Interpreter.lastTHSStat2 = thsStat2;
                                            msgType = MsgType.THS_St2;
                                        }
                                        break;
                                    case 6: //THS Status 3
                                        THS_Status3 thsStat3 = new THS_Status3(time, outArr, 6);
                                        if (thsStat3.CheckMsg())
                                        {
                                            Interpreter.lastTHSStat3 = thsStat3;
                                            msgType = MsgType.THS_St3;
                                        }
                                        break;
                                    case 2: // it mind be a KI Status
                                        KI_Stat1 kiS1 = new KI_Stat1(time, outArr, 7);
                                        if (kiS1.CheckMsg())
                                        {
                                            msgType = MsgType.KI_Stat1;
                                            lastKiStat1 = kiS1;
                                        }
                                        break;
                                    default:
                                        if (Interpreter.lastMsgType == MsgType.KI_Stat1) //check it could be KI Status1 message - just for a case receiver sopped reception exactly with the last 8th byte..
                                        {
                                            KI_Stat2 kiS2 = new KI_Stat2(time, outArr, 7);
                                            if (kiS2.CheckMsg())
                                            {
                                                msgType = MsgType.KI_Stat2;
                                                lastKiStat2 = kiS2;
                                            }
                                        }
                                        break;
                                }
                            }
                            else if ((amtRxByte <= 8)) // KI Status length is 8 bytes
                            {
                                if (Interpreter.lastMsgType == MsgType.KI_Stat1)
                                {
                                    KI_Stat2 kiS2 = new KI_Stat2(time, outArr, 7);
                                    if (kiS2.CheckMsg())
                                    {
                                        msgType = MsgType.KI_Stat2;
                                        lastKiStat2 = kiS2;
                                    }
                                }
                                else
                                {
                                    KI_Stat1 kiS1 = new KI_Stat1(time, outArr, 7);
                                    if (kiS1.CheckMsg())
                                    {
                                        msgType = MsgType.KI_Stat1;
                                        lastKiStat1 = kiS1;
                                    }
                                }
                            }
                            else if (amtRxByte >= 9)//message is longer then 8 bytes and THS Challange has 9 bytes
                            {
                                THS_Challenge thsCHall = new THS_Challenge(time, outArr, 9);
                                if (thsCHall.CheckMsg())
                                {
                                    msgType = MsgType.THS_Chall;
                                    lastTHSChall = thsCHall;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                else { }

                
            }
            if(msgType != MsgType.NotDetected)
            {
                lastMsgType = msgType;
            }
            return msgType;
        }

        public bool ConvertHexStringToByteArray(string hexString, int firstBytePosition, byte[] outBuff)
        {

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
                    if((indexString + 2) <= hexString.Length)
                    {

                        try
                        {
                            byteValue = hexString.Substring(indexString, 2);
                            outBuff[indexBuff] = byte.Parse(byteValue, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture);
                            indexBuff++;
                            indexString += 3; //nex time new number - plus 3 characters
                        }
                        catch
                        {
                            break;
                        }
                    }
                }
            }
            return true;
        }

        public string InterpretButton(int buttonCode)
        {
            string strbutton;
            switch (buttonCode)
            {
                case 0:
                    strbutton = "released";
                    break;
                case 1:
                    strbutton = "LOCK";
                    break;
                case 2:
                    strbutton = "UNLOCK";
                    break;
                case 4:
                    strbutton = "TRUNK";
                    break;
                case 8:
                    strbutton = "PANIC";
                    break;
                default:
                    strbutton = buttonCode.ToString();
                    break;
            }
            return strbutton;
        }
    }

}
