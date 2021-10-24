using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace TrainTTLibrary
{
    public class Packet
    {
        public List<byte> BytePacket { set; get; }

        public string TCPPacket { set; get; }

        public string Type { set; get; }

        public byte Head { set; get; }

        public List<byte> Adress { set; get; }

        public List<byte> Data { set; get; }

        public byte CRC { set; get; }

        public UInt32 NumberOfUnit { set; get; }

        public UInt32 NumberOfAdress { set; get; }

        public void SetPropetiesFromByte(byte[] bytePacket)
        {
            BytePacket = new List<byte>(bytePacket);

            Adress = new List<byte>();

            Data = new List<byte>();

            for (int i = 0; i < 2; i++)
            {
                Adress.Add(bytePacket[i + 1]);
            }

            Head = bytePacket[0];

            for (int i = 0; i < Head; i++)
            {
                Data.Add(bytePacket[i + 3]);
            }

            CRC = bytePacket[bytePacket.Length - 1];

            AdressToNumberOfAdressAndUnit();

            AssingType();

            TCPPacket = (Type + ":");
        }

        protected void SetPropetiesFromTCP(string TCPPacket)
        {
            BytePacket = new List<byte>();

            Adress = new List<byte>();

            Data = new List<byte>();

            this.TCPPacket = TCPPacket;

            string[] s = TCPPacket.Split(':');

            Type = (s[0] + ":");

            if (RecognizeTCPType(Type) == dataType.unknow)
            {
                this.TCPPacket = UnknowPacket(this.TCPPacket);
            }

        }

        protected void AssingType()
        {

            switch (NumberOfAdress)
            {
                case (int)unitAdress.emergency_W:

                    Type = dataType.emergency.ToString();
                    break;

                case (int)unitAdress.generator_DCC_W:


                    if ((Data[1] >= 0x01) && (Data[1] <= 0x7f))// (0x00) = broadcast, (0x01 až 0x7f) = lokomotivní dekodéry, (0x80 až 0xbf) = dekodéry pro příslušenství
                    {
                        Type = dataType.train_move.ToString();
                    }
                    else if ((Data[1] >= 0x80) && (Data[1] <= 0xbf))
                    {
                        Type = dataType.train_function.ToString();
                    }
                    else
                    {
                        Type = dataType.unknow.ToString();
                    }
                    break;

                case (int)unitAdress.generator_DCC_R: // message from generator DCC

                    if ((Head == 0x01) && (Data[0] == 0x55)) // watchdog message: 01 20 20 55 88
                    {
                        Type = dataType.watchdog.ToString();
                        break;
                    }
                    else
                    {

                        Type = dataType.unknow.ToString();
                        break;
                    }

                case (int)unitAdress.zesilovac_DCC_1_R: // message from DCC amplifier

                    if (Head == 0x08)
                    {
                        Type = dataType.occupancy_section.ToString();
                    }
                    else if ((Head == 0x08) || (Head == 0x01))
                    {
                        Type = Type = dataType.unit_info.ToString(); // Prodleva odesílání změřených hodnot změněna, zdroj vypnut, zdroj zapnut, h můstek v provozu, chyba H můstku
                    }
                    else
                    {
                        Type = dataType.unknow.ToString();
                    }
                    break;

                case (int)unitAdress.zesilovac_DCC_2_R:

                    Type = dataType.unknow.ToString();

                    break;

                case (int)unitAdress.zesilovac_DCC_1_W:
                    {
                        if ((Head == 0x02) || (Head == 0x01))
                        {
                            Type = dataType.unit_instruction.ToString();
                        }
                        else if (Head == 0x01)
                        {
                            Type = dataType.unknow.ToString();
                        }

                        break;
                    }
                case (int)unitAdress.zesilovac_DCC_2_W:

                    Type = dataType.unknow.ToString();
                    break;

                case (int)unitAdress.vyhybky_W:

                    Type = dataType.unknow.ToString();
                    break;

                case (int)unitAdress.vyhybky_R:

                    Type = dataType.unknow.ToString();
                    break;

                case (int)unitAdress.navestidla_W:

                    Type = dataType.unknow.ToString();
                    break;

                case (int)unitAdress.tocna_W:

                    Type = dataType.unknow.ToString();
                    break;

                case (int)unitAdress.tocna_R:

                    Type = dataType.unknow.ToString();
                    break;

                default:

                    Type = dataType.unknow.ToString();
                    break;
            }

        }

        public static dataType RecognizeTCPType(String str)
        {

            string[] s = str.Split(':');

            dataType type;

            if (!Enum.TryParse(s[0], out type))
            {
                return dataType.unknow;
            }

            return type ;

        }
        
        public static byte VypocetCRC(List<byte> paket)
        {
            byte crc = 0;
            byte icrc, ucrc;

            byte CRC_POLYNOM = 0xd8;
            byte TOP_BIT = 0x80;

            for (ucrc = 0; ucrc < paket.Count; ucrc++)
            {
                crc ^= paket[ucrc];

                for (icrc = 8; icrc > 0; --icrc)
                {


                    if ((crc & TOP_BIT) != 0)
                    {
                        crc = (byte)(crc << 1);
                        crc = (byte)(crc ^ CRC_POLYNOM);
                    }
                    else
                    {
                        crc <<= 1;
                    }
                }
            }

            return (byte)crc;
        }

        protected void AdressToNumberOfAdressAndUnit() // z HEX adresy vyčíst číslo jednotky a adresu jednotky 
        {

            UInt32 adr = (uint)((Adress[0] << 8) | Adress[1]);

            adr = adr >> 5;

            NumberOfAdress = adr >> 7;

            NumberOfUnit = adr & ((UInt32)0x7f); // 0x7f = 1111111

        }

        protected void NumberOfAdressAndUnitToAdress() // z čísla jednotky a adresy jednotky vytvořit HEX adresu pro paket 
        {
            UInt32 i = ((NumberOfAdress << 12) | (NumberOfUnit << 5));

            Adress.Add((byte)(i >> 8));

            Adress.Add((byte)(i & 0xff));

        }

        protected void SetBytePacket()
        {

            BytePacket.Add(Head);

            BytePacket.AddRange(Adress);

            BytePacket.AddRange(Data);

            CRC = VypocetCRC(BytePacket);

            BytePacket.Add(CRC);

        }

        static public string UnknowPacket(string tcpPacket)
        {
            string[] s = tcpPacket.Split(':');

            tcpPacket = s[1];

            return dataType.unknow.ToString() + ":" + s[1];
        }

        public static string GapToUnderLine(string str)
        {

            string[] s = str.Split(' ');

            string a = "";

            for (int i = 0; i < s.Length; i++)
            {
                a += (i == (s.Length - 1)) ? s[i] : (s[i] + "_");
            }

            return a;
        }

        public static string UnderLineToGap(string str)
        {
            string[] s = str.Split('_');

            string a = "";

            for (int i = 0; i < s.Length; i++)
            {
                a += (i == (s.Length - 1)) ? s[i] : (s[i] + " ");
            }

            return a;
        }

        public enum dataType
        {
            watchdog,
            occupancy_section,
            unit_info,
            // zprávy odesílané řídící jednotkou
            train_move,
            train_function,
            train_move_to_place,
            unit_instruction,
            // zprávy pro řídící jednotku
            unknow, // neznámý typ zprávy
            oled_info, // textové zprávy mezi TCP uživateli s bíže nespecifikovanými parametry
            emergency,// adresa 0000
            // zprávy pro komunikaci

        };

        public enum unitAdress
        {
            emergency_W,
            generator_DCC_W,
            generator_DCC_R,
            zesilovac_DCC_1_R,
            zesilovac_DCC_2_R,
            zesilovac_DCC_1_W,
            zesilovac_DCC_2_W,
            vyhybky_W,
            vyhybky_R,
            navestidla_W,
            tocna_W,
            tocna_R,
        };

        public enum unitInstruction
        {
            prodleva_odesilani_zmerenych_proudu,
            zapnuti_zdroje,
            vypnuti_zdroje,
            restart_H_mustku,
            restart_mikroprocesoru,
            err,
        }

    }

    public class UnitInstructionPacket : Packet
    {
        unitInstruction UnitInstruction { set; get; }

        public UnitInstructionPacket(unitInstruction type,uint numberOfUnit,byte data)
        {

            BytePacket = new List<byte>();

            Adress = new List<byte>();

            Data = new List<byte>();

            UnitInstruction = type;

            NumberOfAdress = (uint)unitAdress.zesilovac_DCC_1_W;

            NumberOfUnit = numberOfUnit;

            if (type == unitInstruction.prodleva_odesilani_zmerenych_proudu)
            {
                Head = 0x02;

                AssingType();

                NumberOfAdressAndUnitToAdress();

                Data.Add(0x00);

                Data.Add(data);

                SetBytePacket();

                TCPPacket = (Type + ":" + UnitInstruction.ToString() + "," + NumberOfUnit + "," + Data[1] + "\n");
            }
            else
            {
                Head = 0x01;

                AssingType();

                NumberOfAdressAndUnitToAdress();

                Data.Add(data);

                SetBytePacket();

                TCPPacket = (Type + ":" + UnitInstruction.ToString() + "," + NumberOfUnit + "\n");
            }

        }

        public UnitInstructionPacket(byte[] bytePacket)
        {
            SetPropetiesFromByte(bytePacket);

            UnitInstruction = (unitInstruction)Enum.ToObject(typeof(unitInstruction),Data[0]);                        
           
            TCPPacket += (UnitInstruction.ToString() + "," + NumberOfUnit + ((UnitInstruction == unitInstruction.prodleva_odesilani_zmerenych_proudu)?"\n": ("," + Data[1] + "\n")));

        }

        public UnitInstructionPacket(string tcpPacket)
        {
            SetPropetiesFromTCP(tcpPacket);

            string[] s = tcpPacket.Split(':');

            tcpPacket = s[1];
                       
            s = tcpPacket.Split(',');

            UnitInstruction = stringToUnitInstruction(s[0]);

            if (UnitInstruction == unitInstruction.err)
            {
                TCPPacket = UnknowPacket(TCPPacket);
                Type = dataType.unknow.ToString();
                return;
            }

            NumberOfAdress = (uint)unitAdress.zesilovac_DCC_1_W;

            uint a;

            if (!uint.TryParse(s[1], out a))
            {
                TCPPacket = UnknowPacket(TCPPacket);
                Type = dataType.unknow.ToString();
                return;
            }

            NumberOfUnit = a;

            Data.Add((byte)UnitInstruction);

            if (UnitInstruction == unitInstruction.prodleva_odesilani_zmerenych_proudu)
            {
                
                Head = 0x02;

                NumberOfAdressAndUnitToAdress();

                byte b;

                if (!byte.TryParse(s[2], out b))
                {
                    TCPPacket = UnknowPacket(TCPPacket);
                    Type = dataType.unknow.ToString();
                    return;
                }

                Data.Add(b);

            }
            else
            {
                Head = 0x01;

                NumberOfAdressAndUnitToAdress();
            }

            SetBytePacket();
        }

        public static unitInstruction stringToUnitInstruction(string str)
        {
            unitInstruction type;

            if (!Enum.TryParse(str, out type))
            {
                return unitInstruction.err;
            }

            return type;

        }

    }

    public class TrainMotionPacket : Packet
    {
        public string Name { set; get; }

        public bool Reverse { set; get; }

        public byte Speed { set; get; }

        public uint ID { set; get; }

        public TrainMotionPacket(byte[] bytePacket)
        {
            SetPropetiesFromByte(bytePacket);

            Name = LocomotiveInfo.IDToName(Data[0]);
            
            ID = Data[0];

            Speed = (byte)(Data[1] & 0x1f);

            Reverse = (((Data[1] >> 5) & 0x1) == 1) ? false : true ;

            TCPPacket += (Name + "," + Speed + "," + ((Reverse)? "reverse\n" : "ahead\n"));

        }

        public TrainMotionPacket(Locomotive locomotive, bool reverse, byte speed)
        {
            BytePacket = new List<byte>();

            Adress = new List<byte>();

            Data = new List<byte>();

            ID = locomotive.ID;

            Name = locomotive.Name;

            Speed = speed;

            Reverse = reverse;

            ComposeByte();

            AssingType();
            
            TCPPacket = (Type + ":" + Name + "," + Speed + "," + ((Reverse) ? "reverse\n" : "ahead\n"));
            

        }

        public TrainMotionPacket(string tcpPacket)
        {
            SetPropetiesFromTCP(tcpPacket);

            string[] s = tcpPacket.Split(':');

            tcpPacket = s[1];

            s = tcpPacket.Split(',');

            Name = s[0];

            ID = LocomotiveInfo.NameToID(Name);
            
            byte a;

            if (!byte.TryParse(s[1], out a))
            {
                TCPPacket = UnknowPacket(TCPPacket);
                Type = dataType.unknow.ToString();
                return;
            }

            Speed = a;

            bool unknowPacket = false;

            if (s[2] == "reverse")
            {
                Reverse = true;
            }
            else if (s[2] == "ahead")
            {
                Reverse = false;
            }
            else
            {
                unknowPacket = true;
            }

            if ((ID == 0) || (Speed > 31) || (Speed < 0) || (unknowPacket))
            {
                TCPPacket = UnknowPacket(TCPPacket);
                Type = dataType.unknow.ToString();
            }

            ComposeByte();
        }

        private void ComposeByte()
        {

            NumberOfAdress = (uint)unitAdress.generator_DCC_W;

            NumberOfUnit = 1;

            Head = 0x08;

            NumberOfAdressAndUnitToAdress();

            Data.Add((byte)ID);

            Data.Add(SecondByte());

            for (int i = 0; i < 6; i++)
            {
                Data.Add(0);
            }

            SetBytePacket();

        }

        private byte SecondByte()
        {

            string secondDataByte = "01";

            if (Reverse)
            {
                secondDataByte += "0";
            }
            else
            {
                secondDataByte += "1";
            }

            string s = Convert.ToString(Speed, 2);

            while (s.Length < 5)
            {
                s = "0" + s;
            }

            secondDataByte += s;

            return (byte)Convert.ToUInt32(secondDataByte, 2);
        }
       
    }

    public class TrainMotionInstructionPacket : Packet
    {
        public TrainMotionPacket TrainMoveInfo { set; get; }

        public Section Section { set; get; }

        public uint WaitTime { set; get; }

        public TrainMotionInstructionPacket(string tcpPacket)
        {
            SetPropetiesFromTCP(tcpPacket);

            TrainMoveInfo = new TrainMotionPacket(TCPPacket);

            if (TrainMoveInfo.Type == dataType.unknow.ToString())
            {
                TCPPacket = UnknowPacket(TCPPacket);
                Type = dataType.unknow.ToString();
            }

            if (TrainMoveInfo.Speed < 4)
            {
                TCPPacket = UnknowPacket(TCPPacket);
                Type = dataType.unknow.ToString();
            }

            string[] s = tcpPacket.Split(':');

            tcpPacket = s[1];

            s = tcpPacket.Split(',');

            foreach (Section section in SectionInfo.listOfSection)
            {
                if (section.Name == s[3])
                {
                    Section = section;
                }
            }

            if (Section == null)
            {
                TCPPacket = UnknowPacket(TCPPacket);
                Type = dataType.unknow.ToString();
                return;
            }

            uint a;

            if (!uint.TryParse(s[4], out a))
            {
                TCPPacket = UnknowPacket(TCPPacket);
                Type = dataType.unknow.ToString();
                return;
            }

            WaitTime = a;
        }

        public TrainMotionInstructionPacket(Locomotive locomotive, bool reverse, byte speed, Section section, uint waitTime)
        {
            TrainMoveInfo = new TrainMotionPacket(locomotive, reverse, speed);

            Section = section;

            WaitTime = waitTime;

            Type = dataType.train_move_to_place.ToString();

            TCPPacket = TrainMoveInfo.TCPPacket.TrimEnd() + "," + Section + "," + WaitTime + "\n";

            string[] s = TCPPacket.Split(':');

            TCPPacket = Type + ":" + s[1];
        }
    }

    public class TrainFunctionPacket : Packet
    {

        public bool Lights { set; get; }

        public string Name { set; get; }

        public uint ID { set; get; }

        public TrainFunctionPacket(byte[] bytePacket)
        {
            SetPropetiesFromByte(bytePacket);

            ID = Data[0];

            Name = LocomotiveInfo.IDToName(ID);

            TCPPacket += (Name + ",");

            Lights = (((Data[1] >> 4) & 0x1) == 1) ? true : false;

            TCPPacket += ((Lights) ? "on\n" : "off\n");

        }

        public TrainFunctionPacket(Locomotive locomotive, bool lights)
        {            
            BytePacket = new List<byte>();

            Adress = new List<byte>();

            Data = new List<byte>();

            ID = locomotive.ID;

            Name = locomotive.Name;

            Lights = lights;

            ComposeByte();

            AssingType();
                        
            TCPPacket += (Type + ":" + Name + "," + ((Lights) ? "on\n" : "off\n"));
            
        }

        public TrainFunctionPacket(string tcpPacket)
        {
            SetPropetiesFromTCP(tcpPacket);

            string[] s = tcpPacket.Split(':');

            tcpPacket = s[1];

            s = tcpPacket.Split(',');

            Name = s[0];

            ID = LocomotiveInfo.NameToID(Name);

            bool unknowPacket = false;

            if (s[1] == "on")
            {
                Lights = true;
            }
            else if (s[1] == "off")
            {
                Lights = false;
            }
            else
            {
                unknowPacket = true;
            }

            if ((ID == 0) || (unknowPacket))
            {
                TCPPacket = UnknowPacket(TCPPacket);
            }

            ComposeByte();
        }

        private void ComposeByte()
        {
            NumberOfAdress = (uint)unitAdress.generator_DCC_W;

            NumberOfUnit = 1;

            Head = 0x08;

            NumberOfAdressAndUnitToAdress();

            Data.Add((byte)ID);

            Data.Add(SecondByte());

            for (int i = 0; i < 6; i++)
            {
                Data.Add(0);
            }

            SetBytePacket();
        }

        private byte SecondByte()
        {

            string secondDataByte = "100";

            if (Lights)
            {
                secondDataByte += "1";
            }
            else
            {
                secondDataByte += "0";
            }

            secondDataByte += "0000";

           return (byte)Convert.ToUInt32(secondDataByte, 2);
        }


    }

    public class UnitInfoPacket : Packet
    {
        public unitInstruction UnitInfo { set; get; }

        public UnitInfoPacket(byte[] bytePacket)
        {
            SetPropetiesFromByte(bytePacket);

            UnitInfo = (unitInstruction)Enum.ToObject(typeof(unitInstruction), Data[0]);

            TCPPacket += (UnitInfo.ToString() + "," + NumberOfUnit + "\n");
        }

        public UnitInfoPacket(string tcpPacket)
        {

            SetPropetiesFromTCP(tcpPacket);

            string[] s = tcpPacket.Split(':');

            tcpPacket = s[1];

            s = tcpPacket.Split(',');

            UnitInfo = UnitInstructionPacket.stringToUnitInstruction(s[0]);

            NumberOfAdress = (uint)unitAdress.zesilovac_DCC_1_R;

            NumberOfUnit = uint.Parse(s[1]);

            Data.Add((byte)UnitInfo);

            Head = 0x01;

            NumberOfAdressAndUnitToAdress();

            SetBytePacket();
        }

        public UnitInfoPacket(unitInstruction type, uint numberOfUnit, byte data)
        {

            BytePacket = new List<byte>();

            Adress = new List<byte>();

            Data = new List<byte>();

            UnitInfo = type;

            NumberOfAdress = (uint)unitAdress.zesilovac_DCC_1_R;

            NumberOfUnit = numberOfUnit;

            Head = 0x01;

            AssingType();

            NumberOfAdressAndUnitToAdress();

            Data.Add(data);

            SetBytePacket();

            TCPPacket = (Type + ":" + UnitInfo.ToString() + "," + NumberOfUnit + "\n");

        }
    }

    public class OccupancySectionPacket : Packet
    {
        public List<Section> Sections { set; get; }

        public OccupancySectionPacket(byte[] bytePacket)
        {
            Sections = new List<Section>();

            SetPropetiesFromByte(bytePacket);

            RecognizeUnit();

            foreach (Section s in Sections)
            {
                s.Current = Data[Sections.IndexOf(s)];
                TCPPacket += (s.Name + "=" + s.Current + ",");
            }

            TCPPacket = TCPPacket.Substring(0, TCPPacket.Length - 1);

            TCPPacket += "\n";
        }

        public OccupancySectionPacket(string tcpPacket)
        {
            Sections = new List<Section>();

            SetPropetiesFromTCP(tcpPacket);

            NumberOfAdress = (uint)unitAdress.zesilovac_DCC_1_R;

            RecognizeSection(tcpPacket);

            NumberOfAdressAndUnitToAdress();

            Head = 0x08;

            foreach (Section section in Sections)
            {
                Data.Add((byte)section.Current);
            }

        }

        private void RecognizeSection(string tcpPacket)
        {
            string[] s = tcpPacket.Split(':');

            tcpPacket = s[1];

            string[] sec = tcpPacket.Split(',');

            string[] sectio = sec[0].Split('=');

            foreach (Section section in SectionInfo.listOfSection)
            {
                if (section.Name == sectio[0])
                {
                    NumberOfUnit = section.NumberOfUnit;
                    break;
                }
            }

            foreach (string sect in sec)
            {
                string[] secti = sect.Split('=');

                Sections.Add(new Section(secti[0], NumberOfUnit, uint.Parse(secti[1])));
            }
        }

        private void RecognizeUnit()
        {
            switch (NumberOfUnit)
            {
                case 3:
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            Sections.Add(SectionInfo.listOfSection[i]);
                        }
                        break;
                    }
                // pouze ukázka, až se zde přidá další úseková jednotka, např. num. 4, připíšou se do konfiguráku section další názvy úseků 
                  /*                
                  case 4: 
                    {
                        for (int i = 8; i < 16; i++)
                        {
                            Sections.Add(SectionInfo.listOfSection[i]);
                        }
                        break;
                    }
                    */
            }
        }
    }

    public class OLEDInformationPacket : Packet
    {
        public int Time { set; get; }

        public OLEDInformationPacket(string tcpPacket)
        {

            TCPPacket = tcpPacket;
            
            string[] s = TCPPacket.Split(':');

            Type = (s[0] + ":");

            if (RecognizeTCPType(Type) == dataType.unknow)
            {
                this.TCPPacket = UnknowPacket(this.TCPPacket);
            }

            Time = int.Parse(s[1]);

        }

        public OLEDInformationPacket(int time)
        {

            Time = time;
            
            Type = dataType.oled_info.ToString();

            TCPPacket = (Type + ":" + time + "\n");
            
        }
    }

    public class LocomotiveInfo
    {
        public static List<Locomotive> listOfLocomotives = Initloco();
            
        private static List<Locomotive> Initloco()
        {
            
            List<Locomotive> list = new List<Locomotive>();

            ConfigItem configItems = new ConfigItem("C:\\Users\\Lapunik\\Dropbox\\C#\\Train_2.0\\TrainTTLibrary\\locomotives.xml");
            
            foreach (Item item in configItems.Items)
            {
                list.Add(new Locomotive(item.Str,item.Num));
            }
            
            return list;
           
        }

        public static string IDToName(uint id) 
        {

            foreach (Locomotive locomotive in LocomotiveInfo.listOfLocomotives)
            {

                if (locomotive.ID == id)
                {
                    return locomotive.Name;
                }

            }

            return "Error";

        }

        public static uint NameToID(string name)
        {

            foreach (Locomotive locomotive in LocomotiveInfo.listOfLocomotives)
            {

                if (locomotive.Name == name)
                {
                    return locomotive.ID;
                }

            }

            return 0;

        }

    }

    public class SectionInfo
    {
        public static List<Section> listOfSection = InitSection();

        private static List<Section> InitSection()
        {

            List<Section> list = new List<Section>();

            ConfigItem configItems = new ConfigItem("C:\\Users\\Lapunik\\Dropbox\\C#\\Train_2.0\\TrainTTLibrary\\sections.xml");

            foreach (Item item in configItems.Items)
            {
                list.Add(new Section(item.Str, item.Num));
            }

            return list;

        }
    }

    public class Locomotive
    {
        public string Name { set; get; }
        public uint ID { set; get; }

        public Locomotive(string name)
        {
            Name = name;
            ID = LocomotiveInfo.NameToID(name);

        }

        public Locomotive(uint id)
        {
            ID = id;
            Name = LocomotiveInfo.IDToName(id);
        }

        public Locomotive(string name, uint id)
        {
            ID = id;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

    }

    public class Section
    {
        public string Name { set; get; }
        public uint NumberOfUnit { set; get; }

        public uint current;
        public uint Current
        {
            set
            {
                current = value;
                OccupancySection();

            }
            get
            {
                return current;
            }
        }
        public bool Occupancy { set; get; }

        public Section(string name, uint numberOfUnit)
        {
            Name = name;
            NumberOfUnit = numberOfUnit;
            Current = 0;
            Occupancy =  false;
        }

        public Section(string name,uint numberOfUnit,uint current)
        {
            Name = name;
            NumberOfUnit = numberOfUnit;
            Current = current;
            OccupancySection();

        }

        public Section(string name)
        {
            Name = name;

            foreach (Section section in SectionInfo.listOfSection)
            {
                if(section.Name == name)
                {
                    NumberOfUnit = section.NumberOfUnit;
                    break;
                }
            }
            Current = 0;
            OccupancySection();

        }

        private void OccupancySection()
        {
            Occupancy = (Current > 40) ? true : false;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Item
    {
        public string Str { get; set; }
        public uint Num { get; set; }
       
    }

    public class ConfigItem
    {
        public List<Item> Items = new List<Item>();

        public ConfigItem(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    XmlSerializer serializer = new XmlSerializer(Items.GetType());
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        Items = (List<Item>)serializer.Deserialize(sr);
                    }
                }
                else throw new FileNotFoundException("File not found");
            }
            catch (Exception ex)
            {

            }
        }
      
        public void Serialize()
        {

            Items.Add(new Item() { Str ="Karlstejn", Num = 3 });
            Items.Add(new Item() { Str = "Beroun", Num = 12 });



            XmlSerializer serializer = new XmlSerializer(typeof(List<Item>));

                using (StreamWriter sw = new StreamWriter("C:\\Users\\Lapunik\\Dropbox\\C#\\Train_2.0\\TrainTTLibrary\\sections.xml"))
                {

                    serializer.Serialize(sw, Items);
                }
            
        }

    }

}