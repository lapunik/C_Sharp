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

namespace VisualDebugControlTrainTT
{
    public partial class VisualDebugControl : Form
    {
        private static TCPClient klient = null;

        private List<string> comboBoxOldState = new List<string>();

        private bool IsConnect = false;

        public VisualDebugControl()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartTCPClient();
        }

        private void StartTCPClient()
        {

            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[1];

            klient = new TCPClient(ipAddress, 8080);

            klient.DataType = eRecvDataType.dataStringNL;
            klient.OnClientConnected += KlientConnected;
            klient.OnClientDisconnected += TCPDisconnectClient;
            klient.DataReceived += TCPDataRecv;
            if (!klient.Connect())
            {
                KlientCleanUp();
            }
        }

        private void KlientConnected(object sender, TCPClientConnectedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, TCPClientConnectedEventArgs>(KlientConnected),
                  new object[] { sender, e });
                return;
            }


            if (e == null)
            {
                IsConnect = false;

                KlientCleanUp();

            }
            else
            {
                log.Add("Client connected to " + e.clientIPE);
                IsConnect = true;
            }
                                

        }

        private void TCPDisconnectClient(object sender, TCPClientConnectedEventArgs e)
        {
            IsConnect = false;
        }

        private void KlientCleanUp()
        {
            if (klient != null)
            {
                klient.Disconnect();

                klient.OnClientConnected -= KlientConnected;
                klient.DataReceived -= TCPDataRecv;
                klient.OnClientDisconnected -= TCPDisconnectClient;

                klient.Dispose();
                klient = null;
            }

        }

        private void TCPDataRecv(object sender, TCPReceivedEventArgs e)
        {

            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action<TCPReceivedEventArgs>(DataProcessing), new object[] { e });
                return;
            }

        }

        private void DataProcessing(TCPReceivedEventArgs e)
        {

            if (e.data is String)
            {
                String s = e.data as String;

                if (Packet.RecognizeTCPType(s) == Packet.dataType.occupancy_section)
                {

                    OccupancySectionPacket occupancySectionPacket = new OccupancySectionPacket(s);

                    GetSectionInformations(occupancySectionPacket);

                }
                else if ((Packet.RecognizeTCPType(s) != Packet.dataType.watchdog) && (Packet.RecognizeTCPType(s) != Packet.dataType.occupancy_section))
                {

                    log.Add("Data from server[ " + s + " ]");

                }
            }
        }

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

        private void StopAll()
        {
            foreach (Locomotive locomotive in LocomotiveInfo.listOfLocomotives)
            {

                TrainMotionPacket trainMotionPacket = new TrainMotionPacket(locomotive, false, 3);

                SendTCPData(trainMotionPacket.TCPPacket);
            }

        }

        private void GetSectionInformations(OccupancySectionPacket packet)
        {

            bool alredyContains = false;

            foreach (Control control in tableLayoutPanelDiodeSection.Controls)
            {
                if ((control.Text) == Packet.UnderLineToGap(packet.Sections[0].Name))
                {
                    alredyContains = true;
                }
            }

            if (alredyContains)
            {
                SetSections(packet);
            }
            else
            {
                AddSections(packet);
            }
        }

        private void AddSections(OccupancySectionPacket packet)
        {

            for (int i = 0; i < packet.Sections.Count; i++)
            {
                tableLayoutPanelDiodeSection.RowStyles.Add(new RowStyle());
                tableLayoutPanelDiodeSection.RowCount = tableLayoutPanelDiodeSection.RowStyles.Count;

                DiodePanel diode = new DiodePanel()
                {
                    View3D = 3,
                    Text = Packet.UnderLineToGap(packet.Sections[i].Name),
                    Font = new Font("Microsoft Sans Serif", 10),
                    Color = Color.Lime,
                    SecondColor = Color.LightGray,
                    BColor = Color.Gray,
                    Notification = packet.Sections[i].Occupancy,
                    Dock = DockStyle.Fill,
                };

                tableLayoutPanelDiodeSection.Controls.Add(diode);

            }

            foreach (RowStyle rs in tableLayoutPanelDiodeSection.RowStyles)
            {
                rs.SizeType = SizeType.Absolute;
                rs.Height = 40;
            }



        }

        private void SetSections(OccupancySectionPacket packet)
        {
            for (int i = 0; i < packet.Sections.Count; i++) // osmkrát
            {
                for (int j = 0; j < tableLayoutPanelDiodeSection.Controls.Count; j++) // projed diody
                {
                    if ((tableLayoutPanelDiodeSection.Controls[j] as DiodePanel).Text == Packet.UnderLineToGap(packet.Sections[i].Name))
                    {
                        (tableLayoutPanelDiodeSection.Controls[j] as DiodePanel).Notification = packet.Sections[i].Occupancy;
                    }
                }
            }
        }

        private void buttonAddLocomotive_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanelName.RowStyles.Count > LocomotiveInfo.listOfLocomotives.Count) // máme místo jen pro 13 lokomotiv (více jich není k disozici)
            {
                return;
            }

            tableLayoutPanelName.RowStyles.Add(new RowStyle()); // sekvence přidání místa pro ovladací prvky a nastavení jejich velikostí
            tableLayoutPanelName.RowCount = tableLayoutPanelName.RowStyles.Count;
            tableLayoutPanelSpeed.RowStyles.Add(new RowStyle());
            tableLayoutPanelSpeed.RowCount = tableLayoutPanelDirection.RowStyles.Count;
            tableLayoutPanelDirection.RowStyles.Add(new RowStyle());
            tableLayoutPanelDirection.RowCount = tableLayoutPanelSpeed.RowStyles.Count;
            tableLayoutPanelLights.RowStyles.Add(new RowStyle());
            tableLayoutPanelLights.RowCount = tableLayoutPanelLights.RowStyles.Count;
            tableLayoutPanelStart.RowStyles.Add(new RowStyle());
            tableLayoutPanelStart.RowCount = tableLayoutPanelStart.RowStyles.Count;

            foreach (RowStyle rs in tableLayoutPanelName.RowStyles)
            {
                rs.SizeType = SizeType.Absolute;
                rs.Height = 40;
            }
            foreach (RowStyle rs in tableLayoutPanelDirection.RowStyles)
            {
                rs.SizeType = SizeType.Absolute;
                rs.Height = 40;
            }
            foreach (RowStyle rs in tableLayoutPanelSpeed.RowStyles)
            {
                rs.SizeType = SizeType.Absolute;
                rs.Height = 40;
            }
            foreach (RowStyle rs in tableLayoutPanelStart.RowStyles)
            {
                rs.SizeType = SizeType.Absolute;
                rs.Height = 40;
            }
            foreach (RowStyle rs in tableLayoutPanelLights.RowStyles)
            {
                rs.SizeType = SizeType.Absolute;
                rs.Height = 40;
            }

            ComboBox comboBox = new ComboBox()
            {
                Tag = String.Format("{0}", tableLayoutPanelName.RowStyles.Count - 2),
                Font = new Font("Microsoft Sans Serif", 10),
                Dock = DockStyle.Fill,
            };

            comboBox.Items.Add("Select locomotive");

            for (int i = 0; i < LocomotiveInfo.listOfLocomotives.Count; i++)
            {
                comboBox.Items.Add(Packet.UnderLineToGap(LocomotiveInfo.listOfLocomotives[i].Name));
            }
            
            comboBox.SelectedIndex = 0;

            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox.SelectedIndexChanged += comboBoxName_SelectedIndexChanged;

            tableLayoutPanelName.Controls.Add(comboBox);

            CheckBox checkBoxD = new CheckBox()
            {
                Tag = String.Format("{0}", tableLayoutPanelName.RowStyles.Count - 2),
                Text = "Reverse",
                Font = new Font("Microsoft Sans Serif", 10),
                Dock = DockStyle.Top,
            };

            checkBoxD.CheckedChanged += checkBoxReverse_CheckedChanged;

            tableLayoutPanelDirection.Controls.Add(checkBoxD);


            CheckBox checkBoxL = new CheckBox()
            {
                Tag = String.Format("{0}", tableLayoutPanelName.RowStyles.Count - 2),
                Text = "Lights",
                Font = new Font("Microsoft Sans Serif", 10),
                Dock = DockStyle.Top,
            };

            checkBoxL.CheckedChanged += checkBoxLight_CheckedChanged;

            tableLayoutPanelLights.Controls.Add(checkBoxL);



            TrackBar trackBar = new TrackBar()
            {
                Tag = String.Format("{0}", tableLayoutPanelName.RowStyles.Count - 2),
                Minimum = 3, 
                Maximum = 31,
                Dock = DockStyle.Top,
            };

            trackBar.Scroll += trackBar_Scroll;

            tableLayoutPanelSpeed.Controls.Add(trackBar);

            Button buttonStart = new Button()
            {
                Tag = String.Format("{0}", tableLayoutPanelName.RowStyles.Count - 2),
                Text = "Start",
                Dock = DockStyle.Top,
                Font = new Font("Microsoft Sans Serif", 10),
            };

            buttonStart.Click += buttonStart_Click;

            tableLayoutPanelStart.Controls.Add(buttonStart);


        }

        private void buttonRemoveLocomotive_Click(object sender, EventArgs e)
        {
            ComboBox comboBox = tableLayoutPanelName.Controls[tableLayoutPanelName.Controls.Count - 1] as ComboBox;
            if (comboBox == null)
            {
                return;
            }

            if (comboBox.SelectedIndex != 1)
            {
                SendTrainMotionPacket(int.Parse(comboBox.Tag.ToString()), true);
            }


            if (tableLayoutPanelName.RowStyles.Count > 1)
            {
                tableLayoutPanelName.Controls.RemoveAt(tableLayoutPanelName.Controls.Count - 1);
                tableLayoutPanelName.RowStyles.RemoveAt(tableLayoutPanelName.RowStyles.Count - 1);
                tableLayoutPanelName.RowCount = tableLayoutPanelName.RowStyles.Count;
                tableLayoutPanelDirection.Controls.RemoveAt(tableLayoutPanelDirection.Controls.Count - 1);
                tableLayoutPanelDirection.RowStyles.RemoveAt(tableLayoutPanelDirection.RowStyles.Count - 1);
                tableLayoutPanelDirection.RowCount = tableLayoutPanelDirection.RowStyles.Count;
                tableLayoutPanelLights.Controls.RemoveAt(tableLayoutPanelLights.Controls.Count - 1);
                tableLayoutPanelLights.RowStyles.RemoveAt(tableLayoutPanelLights.RowStyles.Count - 1);
                tableLayoutPanelLights.RowCount = tableLayoutPanelLights.RowStyles.Count;
                tableLayoutPanelSpeed.Controls.RemoveAt(tableLayoutPanelSpeed.Controls.Count - 1);
                tableLayoutPanelSpeed.RowStyles.RemoveAt(tableLayoutPanelSpeed.RowStyles.Count - 1);
                tableLayoutPanelSpeed.RowCount = tableLayoutPanelSpeed.RowStyles.Count;
                tableLayoutPanelStart.Controls.RemoveAt(tableLayoutPanelStart.Controls.Count - 1);
                tableLayoutPanelStart.RowStyles.RemoveAt(tableLayoutPanelStart.RowStyles.Count - 1);
                tableLayoutPanelStart.RowCount = tableLayoutPanelStart.RowStyles.Count;
            }
        }

        private void SendTrainMotionPacket(int tag, bool stop)
        {

            Locomotive locomotive = new Locomotive(Packet.GapToUnderLine((tableLayoutPanelName.Controls[tag] as ComboBox).Text));

            if (!stop)
            {
                if ((tableLayoutPanelStart.Controls[tag] as Button).Text == "Stop")
                {

                    bool reverse = ((tableLayoutPanelDirection.Controls[tag] as CheckBox).CheckState == CheckState.Checked) ? true : false;

                    byte speed = (byte)(tableLayoutPanelSpeed.Controls[tag] as TrackBar).Value;

                    if (speed == 3)
                    {
                        speed = 0;
                    }

                    TrainMotionPacket trainMotionPacket = new TrainMotionPacket(locomotive, reverse, speed);

                    SendTCPData(trainMotionPacket.TCPPacket);

                }
            }
            else
            {
                TrainMotionPacket trainMotionPacket = new TrainMotionPacket(locomotive, false, 0);

                SendTCPData(trainMotionPacket.TCPPacket);
            }
        
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            int tag = int.Parse(button.Tag.ToString());

            if ((tableLayoutPanelName.Controls[tag] as ComboBox).Text == "Select locomotive")
            {
                return;
            }
            
            if (button.Text == "Stop")
            {
                button.Text = "Start";

                SendTrainMotionPacket(tag, true);
            }
            else
            {
                button.Text = "Stop";

                SendTrainMotionPacket(tag,false);
            }


        }

        private void checkBoxLight_CheckedChanged(object sender, EventArgs e)
        {

            CheckBox checkBox = sender as CheckBox;
            if (checkBox == null)
            {
                return;
            }

            int tag = int.Parse(checkBox.Tag.ToString());

            if ((tableLayoutPanelName.Controls[tag] as ComboBox).Text == "Select locomotive")
            {

                checkBox.CheckState = CheckState.Unchecked;
                return;
            }

            Locomotive locomotive = new Locomotive(Packet.GapToUnderLine((tableLayoutPanelName.Controls[tag] as ComboBox).Text));

            TrainFunctionPacket trainFunctionPacket = new TrainFunctionPacket(locomotive, (checkBox.CheckState == CheckState.Checked));

            SendTCPData(trainFunctionPacket.TCPPacket);

        }

        private void SendTCPData(string str)
        {
            while ((!IsConnect) || !klient.Send(str))
            {
                

                if (DialogResult.Cancel == MessageBox.Show("Server not found\nDo you want to try to reconnect?", "Error: Server not found", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning))
                {

                    Close();

                }

                StartTCPClient();
                Thread.Sleep(200);
             
            }

        }

        private void checkBoxReverse_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox == null)
            {
                return;
            }

            int tag = int.Parse(checkBox.Tag.ToString());

            if ((tableLayoutPanelName.Controls[tag] as ComboBox).Text == "Select locomotive")
            {

                checkBox.CheckState = CheckState.Unchecked;
                return;
            }

            SendTrainMotionPacket(tag, false);
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            TrackBar trackBar = sender as TrackBar;
            if (trackBar == null)
            {
                return;
            }

            int tag = int.Parse(trackBar.Tag.ToString());
                       
            SendTrainMotionPacket(tag, false);
        }

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBoxName = sender as ComboBox;

            if (comboBoxName == null)
            {
                return;
            }

            foreach (Control control in tableLayoutPanelName.Controls)
            {
                if ((control.Tag != comboBoxName.Tag) && (control.Text != "Select locomotive") && (control.Text == comboBoxName.Text))
                {
                    comboBoxName.Text = "Select locomotive";
                }
            }

            int tag = int.Parse(comboBoxName.Tag.ToString());

            for(int i = 0 ; i < comboBoxOldState.Count;i++)
            {
                bool IsTrainInComboBox = false;

                foreach (Control control in tableLayoutPanelName.Controls)
                {
                    if (control.Text == comboBoxOldState[i])
                    {
                        IsTrainInComboBox = true;
                    }
                }

                if (!IsTrainInComboBox)
                {
                    Locomotive locomotive = new Locomotive(Packet.GapToUnderLine(comboBoxOldState[i]));

                    TrainMotionPacket trainMotionPacket = new TrainMotionPacket(locomotive, false, 0);

                    SendTCPData(trainMotionPacket.TCPPacket);

                    comboBoxOldState.RemoveAt(i);

                    i--;
                }

            }
            

            CheckBox checkBoxD = tableLayoutPanelDirection.Controls[tag] as CheckBox; 
            CheckBox checkBoxL = tableLayoutPanelLights.Controls[tag] as CheckBox;
            TrackBar trackBar = tableLayoutPanelSpeed.Controls[tag] as TrackBar;
            Button buttonStart = tableLayoutPanelStart.Controls[tag] as Button;

            if ((checkBoxD == null) || (checkBoxL == null) || (trackBar == null) || (buttonStart == null))
            {
                return;
            }
            if (comboBoxName.Text != "Select locomotive")
            {
                comboBoxOldState.Add(comboBoxName.Text);
            }

            checkBoxL.CheckState = CheckState.Unchecked;
            checkBoxLight_CheckedChanged(checkBoxL, null);
            checkBoxD.CheckState = CheckState.Unchecked;
            trackBar.Value = 3;
            buttonStart.Text = String.Format("Start");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonCentralStop_Click(object sender, EventArgs e)
        {
            foreach (Control button in tableLayoutPanelStart.Controls)
            {
                int tag = int.Parse(button.Tag.ToString());
                                 

                (tableLayoutPanelName.Controls[tag] as ComboBox).SelectedIndex = 0;
                (tableLayoutPanelLights.Controls[tag] as CheckBox).CheckState = CheckState.Unchecked;
                (tableLayoutPanelDirection.Controls[tag] as CheckBox).CheckState = CheckState.Unchecked;
                (tableLayoutPanelStart.Controls[tag] as Button).Text = "Start";

            }

            StopAll();
        }

        private void buttonSupllyOn_Click(object sender, EventArgs e)
        {
            UnitInstructionPacket unitInstruction = new UnitInstructionPacket(Packet.unitInstruction.zapnuti_zdroje,(uint)numericUpUnit.Value,0);

            SendTCPData(unitInstruction.TCPPacket);
        }

        private void buttonSupllyOff_Click(object sender, EventArgs e)
        {
            UnitInstructionPacket unitInstruction = new UnitInstructionPacket(Packet.unitInstruction.vypnuti_zdroje, (uint)numericUpUnit.Value, 0);

            SendTCPData(unitInstruction.TCPPacket);
        }

        private void buttonResetBridge_Click(object sender, EventArgs e)
        {
            UnitInstructionPacket unitInstruction = new UnitInstructionPacket(Packet.unitInstruction.restart_H_mustku, (uint)numericUpUnit.Value, 0);

            SendTCPData(unitInstruction.TCPPacket);
        }

        private void buttonResetMikro_Click(object sender, EventArgs e)
        {
            UnitInstructionPacket unitInstruction = new UnitInstructionPacket(Packet.unitInstruction.restart_mikroprocesoru, (uint)numericUpUnit.Value, 0);

            SendTCPData(unitInstruction.TCPPacket);
        }

        private void numericUpDelay_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = sender as NumericUpDown;
            if(numericUpDown == null)
            {
                return;
            }

            UnitInstructionPacket unitInstruction = new UnitInstructionPacket(Packet.unitInstruction.prodleva_odesilani_zmerenych_proudu, (uint)numericUpUnit.Value,(byte)numericUpDown.Value);

            SendTCPData(unitInstruction.TCPPacket);
        }
    }
}
