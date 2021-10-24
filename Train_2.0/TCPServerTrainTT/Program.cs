using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.IO.Ports;
using TCPServerTrainTT.Properties;
using System.Collections.Concurrent;
using TrainTTLibrary;
using Console = Colorful.Console;



namespace TCPServerTrainTT
{

    public class Program
    {
        private static TCPServer server = null;

        private static SerialPort serialPort = new SerialPort();
        
        private static ConcurrentQueue<Packet> packet = new ConcurrentQueue<Packet>();

        private static List<byte> packetInCheck = new List<byte>();

        private static List<byte> secondCheckPacket = new List<byte>();

        private static bool chcekPacket = false;

        private static List<Section> occupancySections = new List<Section>();

        private static List<TrainMotionPacket> trainMotionPackets = new List<TrainMotionPacket>();

        private static List<TrainMotionInstructionPacket> trainMotionInstructions = new List<TrainMotionInstructionPacket>();

        private static List<MyTimer> StopTimers = new List<MyTimer>();

        private static System.Timers.Timer timerSerialSend;

        private static System.Timers.Timer timerTCPsend;

        private static object locking = new object();

        private static Color TCPInfo = Color.Yellow;
        private static Color TCPError = Color.Red;
        private static Color TCPDataRecived = Color.LightSkyBlue;
        private static Color TCPDataSend = Color.LightGreen;
        
        private static void ConnectToSerialPort()
        {
            try
            {

                serialPort.PortName = Settings.Default.VirtualPort; //Port jsou vláčky, VirtualPort je můj virtuální pro odladování
                serialPort.BaudRate = 115200;
                serialPort.ReadBufferSize = 4096;
                serialPort.Open();

                serialPort.DataReceived += SerialDataReceived;

                Console.WriteLine(String.Format("Connected to serial port: {0}", serialPort.PortName), TCPInfo);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message,TCPError);

                Console.ReadKey();

                Environment.Exit(0);

            }

        }

        private static void StartTCPServer()
        {

            server = new TCPServer();

            server.DataType = eRecvDataType.dataStringNL;
            server.DataReceived += TCP_DataRecv;
            server.OnClientConnected += TCP_NewClient;
            server.OnClientDisconnected += TCP_DisconnectClient;

            server.Listen(8080);

            Console.WriteLine("TCP server ready on port " + 8080 , TCPInfo);

        }

        private static void StartTimers()
        {
            foreach (Locomotive locomotive in LocomotiveInfo.listOfLocomotives)
            {
                MyTimer t = new MyTimer();
                t.TrainMotionPacket = new TrainMotionPacket(locomotive,false,0);
                t.Interval = 10;
                t.Elapsed += MyTimer_Elapsed;
                

                StopTimers.Add(t);
            }

            timerTCPsend = new System.Timers.Timer(50);
            timerSerialSend = new System.Timers.Timer(50);

            timerSerialSend.Elapsed += SendSerialData_Tick;
            timerTCPsend.Elapsed += SendTCPData_Tick;

            timerSerialSend.AutoReset = true;
            timerTCPsend.AutoReset = true;

            timerSerialSend.Enabled = true;
            timerTCPsend.Enabled = true;
        }

        private static void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            if (e.EventType == SerialData.Chars)
            {

                while ((serialPort.IsOpen) && (serialPort.BytesToRead > 0)) // dokud je co číst z portu a zároveň je pot otevřený tak prováděj cyklus
                {
                    lock (locking)
                    {

                        byte data; // příprava proměnné do které budu ukládat data po dobu zpracování a zkoumání smysluplnosti

                        if (secondCheckPacket.Count > 1) //jestlize je co číst z paketu který jsem zkoumal a vyhodnotil jako paket falešný, musím jeho části opět prozkoumat, tentokrát bez prvního byte který se falešn tvářil jako hlavička
                        {
                            secondCheckPacket.RemoveAt(0); // tady provádím odstraňování byte z listu podruhé kontorolovaných byte
                            data = secondCheckPacket[0]; //uložím do "data" byte který je potřeba prozkoumat
                        }
                        else // pokud je "secondCheck" prázdný, bereme data normálně ze serial portu
                        {
                            if (!serialPort.IsOpen) //bezprostřední test jestli se port neodpojil respektive jestli je co číst
                            {
                                return;
                            }
                            data = (byte)serialPort.ReadByte(); // čti byte ze serial portu
                        }

                        //continue;

                        if ((data > 0) && (data <= 8) && (!chcekPacket)) // jestliže je byte (HEX: 01 až 08), což jsou možné začátky datových paketů a zároveň se žádný paket právě teď neprozkoumává (to zančí proměnná chceckPacket)
                        {
                            packetInCheck.Add(data); // přidej do "packetInCheck" tento byte (přidá se na první místo, jak z kontextu vyplívá)
                            chcekPacket = true; // zapni signalizaci že se již zkoumá některý paket
                        }
                        else if (chcekPacket) // pokud první podmínka není splněna a zároveň je některý paket právě zkoumaný, provede se tento cyklus
                        {
                            if ((packetInCheck.Count) == ((packetInCheck[0]) + 3)) // hlavička paketu mi říká, kolik datových byte paket obsahuje, tudíž pokud je zkoumaný paket dlouhý jako hodnota této hlavičky + 3 (protože k datovým paketům je ještě jeden byte hlavička a dva byte asresa), tak by další byte měl být CRC, to se testuje níže
                            {
                                byte crc = Packet.VypocetCRC(packetInCheck); // vypočtu si kolik vychází CRC z dosavadního paketu, tato hodnota by se měla rovnat poslednímu byte který přijde

                                packetInCheck.Add(data); // doplním poslední byte který obsahuje informaci CRC

                                if (packetInCheck[packetInCheck.Count - 1] == crc) // pokud se tento poslední byte rovná s byte "crc" který jsme vypočítali, našli jsme plnohodnotný paket a máme vyhráno
                                {
                                    Packet p = new Packet();

                                    p.SetPropetiesFromByte(packetInCheck.ToArray());

                                    packet.Enqueue(p); // do fronty přidáme paket zabalený ve string

                                }
                                else // pokud CRC nesedí, vyhodím z kontrolovaného paketu první byte
                                {
                                    packetInCheck.RemoveAt(0);
                                    secondCheckPacket.AddRange(packetInCheck);// a falešný paket, teď už bez prvního byte(faešné hlavičky) nahraji do listu a "prohledej ho znovu"                          
                                }

                                chcekPacket = false; // ať už paket dopadl jako plnohodnotný a odeslal se do fronty nebo falešný a odeslal se do listu byte které je potřeba znovu zkontrolovat, musím ukončit signalizaci že zrovna některý z paketů kontroluji, to značí proměná "chcekPacket"
                                packetInCheck.Clear(); // stejně tak, ať už paket byl nebo nebyl plnohodnotný, musíme tento paket smazat abychom mohli zkoumat paket nový 

                            }
                            else // pokud není prohledávaný paket u teoreticky svého posledního byte, prostě jenom načti další byte
                            {
                                packetInCheck.Add(data);
                            }
                        }
                    }
                }
            }

        }

        private static void SendTCPData_Tick(object source, System.Timers.ElapsedEventArgs e)
        {


            while (packet.Count > 0)
            {
                lock (locking)
                {

                    Packet p;

                    if (!packet.TryDequeue(out p))
                    {

                        Console.Write("Error, data from queue are not retrieved", TCPError);

                        return;
                    }

                    if (Packet.RecognizeTCPType(p.Type) == Packet.dataType.occupancy_section)
                    {
                        OccupancySectionPacket occupancySectionPacket = new OccupancySectionPacket(p.BytePacket.ToArray());
                        Console.Write("DATA SEND: " + occupancySectionPacket.TCPPacket, TCPDataSend);
                        server.Send(occupancySectionPacket.TCPPacket, null);

                        SaveOccupancySection(occupancySectionPacket.Sections);

                    }

                    if (Packet.RecognizeTCPType(p.Type) == Packet.dataType.unit_info)
                    {
                        UnitInfoPacket unitInfoPacket = new UnitInfoPacket(p.BytePacket.ToArray());
                        if (unitInfoPacket.UnitInfo == Packet.unitInstruction.restart_mikroprocesoru)
                        {
                            Console.Write("DATA SEND: " + unitInfoPacket.TCPPacket, TCPError);
                        }
                        else
                        {
                            Console.Write("DATA SEND: " + unitInfoPacket.TCPPacket, TCPDataSend);
                        }

                        server.Send(unitInfoPacket.TCPPacket, null);
                    }

                   /* if (Packet.RecognizeTCPType(p.Type) == Packet.dataType.oled_info)
                    {
                        OLEDInformationPacket OLEDInfoPacket = new OLEDInformationPacket(p.TCPPacket); // čas

                        server.Send(OLEDInfoPacket.TCPPacket, null);
                    } */

                }

            }
        }

        private static void SaveOccupancySection(List<Section> newOccupancySection)
        {
            bool alreadyInPackets = false;

            for (int j = 0; j < newOccupancySection.Count; j++)
            {
                for (int i = 0; i < occupancySections.Count; i++)
                {

                    if (occupancySections[i].Name == newOccupancySection[j].Name)
                    {
                        occupancySections[i] = newOccupancySection[j];

                        alreadyInPackets = true;

                        break;
                    }
                }

                if (!alreadyInPackets)
                {
                    occupancySections.Add(newOccupancySection[j]);
                }
            }

        }

        static void Main(string[] args)
        {
            StartTCPServer();

            ConnectToSerialPort();

            StartTimers();

            bool bbLoop = true;
            while (bbLoop)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);

                    if (cki.Key == ConsoleKey.Q)
                    {

                        bbLoop = false;
                        break;

                    }
                }

               // server.Send("Pokus", null);

                Thread.Sleep(10);

            }

            Console.WriteLine("\nFinish");

            server.Dispose();
            server = null;
        }

        private static void SendTrainMotionPacket()
        {
            for (int i = 0; i < trainMotionPackets.Count; i++)
            {

                SendSerialData(trainMotionPackets[i].BytePacket);


                if (trainMotionPackets[i].Speed < 4)
                {
                    foreach (MyTimer myTimer in StopTimers)
                    {
                        if (trainMotionPackets[i].ID == myTimer.TrainMotionPacket.ID)
                        {
                            myTimer.TrainMotionPacket = trainMotionPackets[i];
                            myTimer.Counter = 0;
                            myTimer.Count = 0;
                            myTimer.Enable = true;
                            trainMotionPackets.RemoveAt(i);
                            i--;

                            break;
                        }

                    }

                }
            }
        }

        private static void SendTrainMotionInstruction()
        {
            if (occupancySections.Count > 0)
            {
                lock (locking)
                {
                    for (int i = 0; i < trainMotionInstructions.Count; i++)
                    {
                        Section occupancySection = null;

                        for (int j = 0; j < occupancySections.Count; j++)
                        {
                            if (trainMotionInstructions[i].Section.Name == occupancySections[j].Name)
                            {

                                occupancySection = occupancySections[j];
                                break;

                            }
                        }

                        if (occupancySection == null)
                        {
                            break;
                        }

                        if (!occupancySection.Occupancy)
                        {

                            SendSerialData(trainMotionInstructions[i].TrainMoveInfo.BytePacket);

                        }
                        else
                        {

                           // if (trainMotionInstructions.Count > i)
                           // {

                                foreach (MyTimer myTimer in StopTimers)
                                {
                                    if (trainMotionInstructions[i].TrainMoveInfo.Name == myTimer.TrainMotionPacket.Name)
                                    {
                                        myTimer.TrainMotionPacket = trainMotionInstructions[i].TrainMoveInfo;
                                        myTimer.Count = (trainMotionInstructions[i].WaitTime) / (uint)myTimer.Interval;
                                        myTimer.Counter = 0;
                                        myTimer.Enabled = true;

                                        trainMotionInstructions.RemoveAt(i);
                                        i--;

                                        break;
                                    }

                                }
                           // }
                        }
                    }
                }

            }
        }

        private static void SendSerialData_Tick(object source, System.Timers.ElapsedEventArgs e)
        {
            lock (locking)
            {
                SendTrainMotionInstruction();

                SendTrainMotionPacket();

            }
        }

        private static void MyTimer_Elapsed(object sender, EventArgs e) // časovač pro zastavení vlaku
        {
            lock (locking)
            {
                MyTimer timer = sender as MyTimer;
                if (timer == null)
                {
                    return;
                }

                timer.Counter++;

                if (timer.Counter > timer.Count)
                {
                    TrainMotionPacket motionPacket = new TrainMotionPacket(new Locomotive(timer.TrainMotionPacket.Name), false, 0);

                    SendSerialData(motionPacket.BytePacket);

                    timer.Enabled = false; //časovač pro zastavení vlaku vypni  

                }
                /*else if (timer.Counter > (timer.Count / 2))
                {
                    TrainMotionPacket motionPacket = new TrainMotionPacket(new Locomotive(timer.TrainMotionPacket.ID), timer.TrainMotionPacket.Reverse, (byte)(timer.TrainMotionPacket.Speed * 2 / 3));
                    SendSerialData(motionPacket.BytePacket);
                }
                else
                {
                    TrainMotionPacket motionPacket = new TrainMotionPacket(new Locomotive(timer.TrainMotionPacket.ID), timer.TrainMotionPacket.Reverse, (byte)(timer.TrainMotionPacket.Speed * 3 / 4));
                    SendSerialData(motionPacket.BytePacket);
                }*/

                else
                {
                    TrainMotionPacket motionPacket = new TrainMotionPacket(new Locomotive(timer.TrainMotionPacket.ID), timer.TrainMotionPacket.Reverse, (byte)(timer.TrainMotionPacket.Speed * (1-((double)timer.Counter / (double)timer.Count))));
                    SendSerialData(motionPacket.BytePacket);
                }
            }
        }

        private static void TCP_NewClient(object sender, TCPClientConnectedEventArgs e)
        {
            Console.WriteLine("Client: " + e.clientIPE.Port + " is connected", TCPInfo);
        }

        private static void TCP_DisconnectClient(object sender, TCPClientConnectedEventArgs e)
        {
            Console.WriteLine("Client: " + e.clientIPE.Port + " is disconnected", TCPInfo);
        }

        private static void TCP_DataRecv(object sender, TCPReceivedEventArgs e)
        {
            lock (locking)
            {

                IPEndPoint ipeClient = null;

                SocketObject so = sender as SocketObject;

                if ((so != null) && (so.sock != null))
                {
                    ipeClient = so.sock.RemoteEndPoint as IPEndPoint;
                }

                if (e.data is String)
                {

                    String s = e.data as String;

                    Console.Write("DATA RECEIVED: Client: " + ipeClient.Port + " send: ", TCPDataRecived);

                    if (Packet.RecognizeTCPType(s) == (Packet.dataType.train_move))
                    {
                        TrainMotionPacket trainMotionPacket = new TrainMotionPacket(s);

                        Console.WriteLine(trainMotionPacket.TCPPacket, TCPDataRecived);

                        if (trainMotionPacket.Type == Packet.dataType.unknow.ToString())
                        {
                            return;
                        }


                        // pokud měl vlak instrukci o dojetí někam, na tuhle insktrukci se dál vyprdne a bude jezdit jak mu říkám 

                        for (int i = 0; i < trainMotionInstructions.Count; i++)
                        {

                            if (trainMotionInstructions[i].TrainMoveInfo.ID == trainMotionPacket.ID)
                            {
                                trainMotionInstructions.RemoveAt(i);
                                break;

                            }
                        }

                        bool alreadyInPackets = false;

                        for (int i = 0; i < trainMotionPackets.Count; i++)
                        {

                            if (trainMotionPackets[i].ID == trainMotionPacket.ID)
                            {
                                trainMotionPackets[i] = trainMotionPacket;

                                alreadyInPackets = true;

                                break;
                            }
                        }

                        if (!alreadyInPackets)
                        {
                            trainMotionPackets.Add(trainMotionPacket);
                        }

                    }
                    else if (Packet.RecognizeTCPType(s) == (Packet.dataType.train_move_to_place))
                    {
                        TrainMotionInstructionPacket trainMotionInstruction = new TrainMotionInstructionPacket(s);

                        Console.WriteLine(trainMotionInstruction.TCPPacket, TCPDataRecived);

                        if (trainMotionInstruction.Type == Packet.dataType.unknow.ToString())
                        {
                            return;
                        }

                        // pokud byl vlak řízený, to jak byl řízený se ignoruje a splní instrukci 

                        for (int i = 0; i < trainMotionPackets.Count; i++)
                        {

                            if (trainMotionPackets[i].ID == trainMotionInstruction.TrainMoveInfo.ID)
                            {
                                trainMotionPackets.RemoveAt(i);

                                break;

                            }
                        }

                        foreach (Section section in occupancySections)
                        {

                            if (trainMotionInstruction.Section.Name == section.Name)
                            {
                                if (section.Occupancy)
                                {


                                    foreach (MyTimer myTimer in StopTimers)
                                    {
                                        if (trainMotionInstruction.TrainMoveInfo.Name == myTimer.TrainMotionPacket.Name)
                                        {

                                            myTimer.Interval = 10;
                                            myTimer.TrainMotionPacket = trainMotionInstruction.TrainMoveInfo;
                                            myTimer.Count = 0;
                                            myTimer.Counter = 0;
                                            myTimer.Enabled = true;
                                            break;
                                        }

                                    }
                                    return;
                                }
                                else
                                {
                                    break;
                                }
                            }

                        }

                        bool alreadyInPackets = false;

                        for (int i = 0; i < trainMotionInstructions.Count; i++)
                        {

                            if (trainMotionInstructions[i].TrainMoveInfo.ID == trainMotionInstruction.TrainMoveInfo.ID)
                            {
                                trainMotionInstructions[i] = trainMotionInstruction;

                                alreadyInPackets = true;
                            }
                        }

                        if (!alreadyInPackets)
                        {
                            trainMotionInstructions.Add(trainMotionInstruction);
                        }

                    }
                    else if (Packet.RecognizeTCPType(s) == (Packet.dataType.train_function))
                    {
                        TrainFunctionPacket trainFunctionPacket = new TrainFunctionPacket(s);

                        Console.WriteLine(trainFunctionPacket.TCPPacket, TCPDataRecived);

                        if (trainFunctionPacket.Type == Packet.dataType.unknow.ToString())
                        {
                            return;
                        }

                        SendSerialData(trainFunctionPacket.BytePacket);

                    }
                    else if (Packet.RecognizeTCPType(s) == (Packet.dataType.unit_instruction))
                    {
                        UnitInstructionPacket unitInstructionPacket = new UnitInstructionPacket(s);

                        Console.WriteLine(unitInstructionPacket.TCPPacket, TCPDataRecived);

                        if (unitInstructionPacket.Type == Packet.dataType.unknow.ToString())
                        {
                            return;
                        }

                        SendSerialData(unitInstructionPacket.BytePacket);

                    }
                    else if (Packet.RecognizeTCPType(s) == (Packet.dataType.oled_info))
                    {
                        OLEDInformationPacket oledInformationPacket = new OLEDInformationPacket(s);

                        Console.WriteLine(oledInformationPacket.TCPPacket, TCPInfo);

                        if (oledInformationPacket.Type == Packet.dataType.unknow.ToString())
                        {
                            return;
                        }

                        server.Send(oledInformationPacket.TCPPacket, null);

                    }
                    else
                    {
                        Console.WriteLine("unknow:" + s, TCPError);

                    }


                }
            }
        }

        private static void SendSerialData(List<byte> p)
        {
            lock (locking)
            {
                p[p.Count - 1] = 0xff;

                byte[] array = p.ToArray();

                serialPort.Write(array, 0, array.Length);
            }
        }
    }
    public class MyTimer : System.Timers.Timer
    {
        public TrainMotionPacket TrainMotionPacket { get; set; }
        public uint Counter { get; set; }
        public uint Count { get; set; }
        public bool Enable { get; internal set; }
    }
}