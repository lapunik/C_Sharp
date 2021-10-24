using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using TrainTTLibrary;
using System.IO;

namespace TimetableControlTrainTT
{
    public partial class Form1 : Form
    {
        private static TCPClient klient = null;

        // private static List<Section> occupancySections = new List<Section>();

        private BindingList<NoteInTimetable> timetable = new BindingList<NoteInTimetable>();

        private List<DataForTimetable> dataForTimetable = new List<DataForTimetable>();

        private String fileName;

        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer() { Interval = 1000 };

        private bool IsConnect = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            timer.Tick += timer_Tick;

            TimetableEnabled(false);

            dataGridView1.DataSource = timetable;

            dataGridView1.Columns[3].DefaultCellStyle.Format = "HH:mm:ss";

            dataGridView1.Font = new Font("Microsoft Sans Serif", 10);
            
            while (!StartTCPClient())
            {
                Thread.Sleep(100);
            }
            

            string[] parameter = Environment.GetCommandLineArgs();

            if (parameter.Length > 1)
            {

               LoadTimeTable(parameter[1]);

            }
        }

        private bool StartTCPClient()
        {

            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[1];

            klient = new TCPClient(ipAddress, 8080);

            klient.DataType = eRecvDataType.dataStringNL;
            klient.OnClientConnected += KlientConnected;
            klient.OnClientDisconnected += TCPDisconnectClient;
           // klient.DataReceived += TCP_DataRecv;
            if (!klient.Connect())
            {
                KlientCleanUp();
                return false;
            }
            else
            {
                return true;
            }

        }

        private void KlientConnected(object sender, TCPClientConnectedEventArgs e)
        {

            if (e == null)
            {
                IsConnect = false;

                KlientCleanUp();

            }
            else
            {
                IsConnect = true;
            }


        }

        private void KlientCleanUp()
        {
            if (klient != null)
            {
                klient.Disconnect();

                klient.OnClientConnected -= KlientConnected;
                //klient.DataReceived -= TCP_DataRecv;
                klient.OnClientDisconnected -= TCPDisconnectClient;

                klient.Dispose();
                klient = null;
            }

        }

       /* private void TCP_DataRecv(object sender, TCPReceivedEventArgs e)
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<TCPReceivedEventArgs>(DataProcessing), new object[] { e });
                return;
            }

        } */

        private void TCPDisconnectClient(object sender, TCPClientConnectedEventArgs e)
        {
            IsConnect = false;
        }

        /* private void DataProcessing(TCPReceivedEventArgs e)
        {

            if (e.data is String)
            {
                String s = e.data as String;

                if (Packet.RecognizeTCPType(s) == Packet.dataType.occupancy_section)
                {

                    OccupancySectionPacket occupancySectionPacket = new OccupancySectionPacket(s);

                    GetSectionInformations(occupancySectionPacket);

                }
            }
        }

        private void GetSectionInformations(OccupancySectionPacket packet)
        {

            foreach (Section packetSection in packet.Sections)
            {
                bool inSection = false;

                foreach (Section section in occupancySections)
                {

                    if ((section.Name) == packetSection.Name)
                    {
                        section.Current = packetSection.Current;
                        inSection = true;
                        break;
                    }
                }

                if (!inSection)
                {
                    occupancySections.Add(packetSection);
                }


            }
        }
        */
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (IsConnect)
            {
                StopAll();
            }


            Thread.Sleep(30);


            if (klient != null)
            {
                klient.Dispose();
                klient = null;
            }

        }

        private void LoadTimeTable(string s)
        {
            String fileName = String.Empty;

            if (s == "")
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Soubory dat (*.csv)|*.csv|Vsechny|*.*";

                    if (DialogResult.OK == openFileDialog.ShowDialog())
                    {
                        fileName = openFileDialog.FileName;
                        this.fileName = fileName;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                fileName = s;
            }

            if (!String.IsNullOrEmpty(fileName))
            {
                try
                {
                    String[] lines = File.ReadAllLines(fileName, Encoding.GetEncoding("Windows-1250"));

                    timetable.Clear();

                    dataGridView1.DataSource = timetable;

                    dataForTimetable.Clear();

                    foreach (String line in lines)
                    {
                        if (line.Contains("***"))
                        {
                            DataForTimetable data = new DataForTimetable(line);
                            dataForTimetable.Add(data);

                        }
                        else
                        {
                            NoteInTimetable note = new NoteInTimetable(line);
                            timetable.Add(note);
                        }
                    }

                    BindingList<NoteInTimetable> onScreen = new BindingList<NoteInTimetable>();

                    for (int i = 0; i < timetable.Count; i++)
                    {
                        onScreen.Add(timetable[i]);
                        onScreen[i].FinalStation.Name = Packet.UnderLineToGap(onScreen[i].FinalStation.Name);
                        onScreen[i].StartStation.Name = Packet.UnderLineToGap(onScreen[i].StartStation.Name);
                    }

                    dataGridView1.DataSource = onScreen;
                    
                    TimetableEnabled(true);
                }
                catch (IOException e)
                {
                    MessageBox.Show("An I/O error occurred while opening the file...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                TimetableEnabled(false);

                MessageBox.Show("Empty file...", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

        }

        private void SendTCPData(string str)
        {
            if ((!IsConnect) || !klient.Send(str))
            {
                int counter = 0;

                while (!IsConnect)
                {
                    StartTCPClient();

                    Thread.Sleep(1000);

                    Console.Beep(800,200);

                    counter++;

                    if (counter > 15)
                    {
                        Close();
                        Environ­ment.Exit(0);
                    }
                }

                PreparePosition();

            }

        }

        private void StopAll()
        {
            foreach (Locomotive locomotive in LocomotiveInfo.listOfLocomotives)
            {

                TrainMotionPacket trainMotionPacket = new TrainMotionPacket(locomotive, false, 3);

                SendTCPData(trainMotionPacket.TCPPacket);
            }

        }

        private void buttonCentralStop_Click(object sender, EventArgs e)
        {
            TimetableEnabled(false);
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Enabled = false;
                StopAll();
                buttonPause.Text = "Start";
            }
            else
            {
                PreparePosition();
                buttonPause.Text = "Pause";
                timer.Enabled = true;
            }


        }

        private void TimetableEnabled(bool b)
        {
            if (b)
            {
                buttonLoad.Enabled = false;
                while (DateTime.Now.Millisecond == 0) ;
                timer.Enabled = true;
                buttonPause.Enabled = true;
                buttonChangeTrainData.Enabled = true;
                PreparePosition();
                if (tableLayoutPanel3.ColumnCount == 1)
                {
                    buttonClock_Click(null, null);
                }
            }
            else
            {
                timetable.Clear();
                dataGridView1.DataSource = timetable;
                buttonLoad.Enabled = true;
                timer.Enabled = false;
                buttonPause.Enabled = false;
                buttonChangeTrainData.Enabled = false;
                if (IsConnect)
                {
                    StopAll();
                }
            }

        }

        private void PreparePosition()
        {
            bool first = true;

            foreach (DataForTimetable dataForTimetable in this.dataForTimetable)
            {
                bool complete = false;

                for (int i = 0; i < timetable.Count; i++)
                {
                    DateTime now = new DateTime(1, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                    DateTime inTimetable = new DateTime(1, 1, 1, timetable[i].Departure.Hour, timetable[i].Departure.Minute, timetable[i].Departure.Second);
                    
                    if (now <= inTimetable)
                    {
                        if (first)
                        {
                            if ((i - 1) >= 0)
                            {
                                DataGridViewInvalidate(i - 1);
                                first = false;
                            }
                        }


                        if (dataForTimetable.Type == timetable[i].Type)
                        {
                            complete = true;

                            NoteInTimetable note = new NoteInTimetable(timetable[i].Type,timetable[i].FinalStation, timetable[i].StartStation, timetable[i].Departure);

                            SendTrainInstructionPacket(dataForTimetable, note);
                            
                        }
                    }

                    if (complete)
                    {
                        break;
                    }
                }
            }
        }

        private void buttonLoadTimetable_Click(object sender, EventArgs e)
        {
            LoadTimeTable("");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < timetable.Count;i++)
            {
                DateTime now = new DateTime(1, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                DateTime inTimetable = new DateTime(1, 1, 1, timetable[i].Departure.Hour, timetable[i].Departure.Minute, timetable[i].Departure.Second);

                if (now < inTimetable)
                {
                    break;
                }
                               
                if (now == inTimetable)
                {
                    foreach(DataForTimetable dataForTimetable in this.dataForTimetable)
                    {
                        if (dataForTimetable.Type == timetable[i].Type)
                        {

                            SendTrainInstructionPacket(dataForTimetable,timetable[i]);

                            DataGridViewInvalidate(i);
                        }
                    }
                }
            }

        }

        private void DataGridViewInvalidate(int i)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0];
                dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                dataGridView1.Rows[i].Selected = true;
                
            }

            SendInfoAboutNearestDeparture(timetable[i + 1]);
        }

        private void SendInfoAboutNearestDeparture(NoteInTimetable noteInTimetable)
        {
            
            List<string> mess = new List<string>();

            int time = noteInTimetable.Departure.Hour * 60 + noteInTimetable.Departure.Minute;

            OLEDInformationPacket messagePacket = new OLEDInformationPacket(time);

            SendTCPData(messagePacket.TCPPacket); // message jaký vlak pojede další

        }

        private void SendTrainInstructionPacket(DataForTimetable dataForTimetable, NoteInTimetable noteInTimetable)
        {
            Locomotive locomotive = dataForTimetable.Locomotive;

            byte speed = (byte)(31 * dataForTimetable.Speed);

            bool reverse;

            Section section;

            uint waitTime;

            

            if (Packet.GapToUnderLine(noteInTimetable.FinalStation.Name) == dataForTimetable.Station1.Name)
            {
                reverse = dataForTimetable.Reverse1;

                section = dataForTimetable.Station1;

                waitTime = dataForTimetable.WaitTime1;
            }
            else
            {
                reverse = dataForTimetable.Reverse2;

                section = dataForTimetable.Station2;

                waitTime = dataForTimetable.WaitTime2;
            }

            TrainMotionInstructionPacket trainMotionInstruction = new TrainMotionInstructionPacket(locomotive, reverse, speed, section, waitTime);

            SendTCPData(trainMotionInstruction.TCPPacket);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonClock_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel3.ColumnStyles.Count > 1)
            {
                tableLayoutPanel3.Controls.RemoveAt(tableLayoutPanel3.Controls.Count - 1);
                tableLayoutPanel3.ColumnStyles.RemoveAt(tableLayoutPanel3.RowStyles.Count - 1);
                tableLayoutPanel3.ColumnCount = tableLayoutPanel3.RowStyles.Count;
            }
            else
            {
                tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
                tableLayoutPanel3.ColumnCount = tableLayoutPanel3.ColumnStyles.Count;

                ClockAnalog clockAnalog = new ClockAnalog()
                {
                    Dock = DockStyle.Fill,
                    ColorBackground = Color.White,
                };

                tableLayoutPanel3.Controls.Add(clockAnalog);

            }

            foreach (ColumnStyle cs in tableLayoutPanel3.ColumnStyles)
            {
                cs.SizeType = SizeType.Percent;
                cs.Width = 50;
            }
        }

        private void buttonChangeTrainData_Click(object sender, EventArgs e)
        {
            using (ChangeTrainData form = new ChangeTrainData())
            {

                form.timetable = timetable;

                form.dataForTimetable = dataForTimetable;

                form.fileName = fileName;

                DialogResult result = form.ShowDialog();
                                             
                if (result == DialogResult.OK)
                {
                    timetable = form.timetable;

                    dataForTimetable = form.dataForTimetable;
                                      
                    BindingList<NoteInTimetable> onScreen = new BindingList<NoteInTimetable>();

                    for (int i = 0; i < timetable.Count; i++)
                    {
                        onScreen.Add(timetable[i]);
                        onScreen[i].FinalStation.Name = Packet.UnderLineToGap(onScreen[i].FinalStation.Name);
                        onScreen[i].StartStation.Name = Packet.UnderLineToGap(onScreen[i].StartStation.Name);
                    }

                    dataGridView1.DataSource = onScreen;

                    dataGridView1.Invalidate();
                    for (int i = 0; i < timetable.Count; i++)
                    {
                        DateTime now = new DateTime(1, 1, 1, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                        DateTime inTimetable = new DateTime(1, 1, 1, timetable[i].Departure.Hour, timetable[i].Departure.Minute, timetable[i].Departure.Second);

                        if (now <= inTimetable)
                        {
                            DataGridViewInvalidate(i);
                            break;
                        }

                    }
                }
            }
        }

        private void buttonFullScreen_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
                buttonFullScreen.Text = "Normal size";
                buttonClock.Enabled = false;
                if (tableLayoutPanel3.ColumnStyles.Count > 1) { buttonClock_Click(null, null);}
                dataGridView1.Font = new Font("Microsoft Sans Serif", 32);

            }
            else
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                WindowState = FormWindowState.Normal;
                buttonFullScreen.Text = "Full screen";
                buttonClock.Enabled = true;
                dataGridView1.Font = new Font("Microsoft Sans Serif", 10);

            }
        }

    }
}
    

