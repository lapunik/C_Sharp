using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DKEY_new.Properties;
using DKEY;
using System.Globalization;

namespace DKEY_new
{
    public partial class Form1 : Form
    {
        private static List<SerialPort> serial_ports_list = new List<SerialPort>(); // List pěti sériových portů
                                                                                    // private static List<MyTimer> watchdog_timers = new List<MyTimer>();
        private static bool[] already_alive = new bool[5];
        private static List<string> input_buffer_string = new List<string>();
        private static List<Timer> start_timers = new List<Timer>();
        bool all_ports_disconnect = true;
        bool new_log = true;
        uint overtiming = 0;
        private static bool[] light_off = { false, false, false, false, false, };
        private static bool[] connection_check = { false, false, false, false, false, };
      //  private static List<MySecondTimer> connection_check_timers = new List<MySecondTimer>();
        Message last_message;
        private static ConcurrentQueue<Message> messages_list = new ConcurrentQueue<Message>(); // List pěti front, kam se postupně načítají zprávy seskládané z input_buffer

      //  private static ConcurrentQueue<string> str_list = new ConcurrentQueue<string>();
      //  private static BindingList<LLog> str_log = new BindingList<LLog>();


        private static BindingList<Message> log = new BindingList<Message>(); // pro jednodušší práci se souborem
        private static string[] com_ports = new string[5];
        private static int filter_minimum_length_HF = 1;
        private static int filter_minimum_length_LF = 1;
        private static List<int> filter_id = new List<int>() {0x0, 0x101, 0x102, 0x110, 0x115, 0x710, 0x711, 0x718, 0x723, 0x801, 0x802, 0x724, 0x72D, 0x72C, 0x601, 0x602, 0x604, 0x605, 0x610, 0x611, 0x613, 0x614, 0x615, 0x616 };
        private static byte[] filter_wup;
        private static bool filter_wup_on = false;
        private static List<int> filter_com = new List<int>() {0,1,2,3,4 };
        private bool ignore_message = false;
        string pureLogFileName = "SniffLog_" + DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm") + ".asc";
        string LogFileName = "SniffLogText_" + DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm") + ".txt";
        string auto_import_name = "";
        bool pause = false;
        int log_name = 1;
        bool import_state = false;
        const int overtime_constant = (0xFFFF * 10);

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                already_alive[i] = false;
                input_buffer_string.Add("");
                start_timers.Add(new Timer() { Interval = 2000, Tag = i });
               // connection_check_timers.Add(new MySecondTimer() { Interval = 30000, Tag = i, State = false });
            }

            foreach (Timer t in start_timers)
            {
                t.Tick += start_timers_Tick;
            }
            /*
            foreach (Timer t in connection_check_timers)
            {
                t.Tick += connection_chck_timers_Tick;
            }
            */
            string[] ports = SerialPort.GetPortNames();
            foreach (ComboBox comboBox in tableLayoutPanel6.Controls)
            {
                comboBox.Items.AddRange(ports);
            }

            foreach (Button button in tableLayoutPanel3.Controls)
            {
                button.Enabled = false;
            }

            button_connect.Enabled = false;

            Create_serial_ports();

            comboBox1.SelectedItem = Settings.Default.com1;
            comboBox2.SelectedItem = Settings.Default.com2;
            comboBox3.SelectedItem = Settings.Default.com3;
            comboBox4.SelectedItem = Settings.Default.com4;
            comboBox5.SelectedItem = Settings.Default.com5;

           // dataGridView1.DataSource = str_log;

            timer1.Start();

        }

        private void Create_serial_ports()
        {

            for (int i = 0; i < 5; i++)
            {
                SerialPort serialPort = new SerialPort();
                serialPort.BaudRate = 115200;
                serialPort.WriteTimeout = 500;
                serial_ports_list.Add(serialPort);

            }
        }

        private bool OpenSerialPort(int num)
        {

            input_buffer_string[num] = ""; // odstraň zbytky předešlé kominukace


            if (serial_ports_list.ElementAt(num).IsOpen)
            {
                return true;
            }

            string com = (tableLayoutPanel6.Controls[num] as ComboBox).Text.ToString();

            serial_ports_list.ElementAt(num).PortName = com;

            try
            {

                serial_ports_list.ElementAt(num).Open();
                serial_ports_list.ElementAt(num).DiscardInBuffer();
                serial_ports_list.ElementAt(num).DiscardOutBuffer();
                serial_ports_list.ElementAt(num).DataReceived += DataReceived;

                start_timers[num].Enabled = true;
                start_timers[num].Tag = num;
                //alive_message[num] = false;
  //              connection_check_timers[num].Enabled = true;
//                connection_check_timers[num].Tag = num;

                return true;
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Error text", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private bool CloseSerialPort(int num)
        {
         //   connection_check_timers[num].Enabled = false;

            if (!serial_ports_list.ElementAt(num).IsOpen)
            {
                return true;
            }

            // odešli stop do portu

            SendMessage(new Message(Message.message_type.HFLFSpyStop.ToString().Replace("_", " "), num));
            System.Threading.Thread.Sleep(100);
            SendMessage(new Message(Message.message_type.LCM_Backlight_on.ToString().Replace("_", " "), num));
            light_off[num] = false;

            try
            {
                serial_ports_list.ElementAt(num).DataReceived -= DataReceived;
                serial_ports_list.ElementAt(num).Close();


                already_alive[num] = false;

                return true;
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Error text", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void DataReceived(object sender, SerialDataReceivedEventArgs e) // metoda která reaguje na přijmutá data po sériovém portu (vždy když se data dostaví a jsou smysluplná, uloží je do frony)
        {

            SerialPort sp = sender as SerialPort;
            if (sp == null)
            {
                return;
            }

            int port_ID = 6;

            for (int i = 0; i < 5; i++)
            {
                if (sp == serial_ports_list[i])
                {
                    port_ID = i;
                }
            }

            if (port_ID == 6)
            {
                MessageBox.Show("Unknow port", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            /*
            if (!sp.IsOpen)
            {
                MessageBox.Show("The port is closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                (tableLayoutPanel6.Controls[port_ID] as ComboBox).BackColor = Color.LightCoral;
                return;

            }
            */

            if (e.EventType == SerialData.Chars)
            {

                while ((sp.IsOpen) && (sp.BytesToRead > 0)) // dokud je co číst z portu a zároveň je pot otevřený tak prováděj cyklus
                {

                    string ss = sp.ReadExisting();

                  //  str_list.Enqueue(ss);

                    input_buffer_string[port_ID] += ss;

                    input_buffer_string[port_ID] = input_buffer_string[port_ID].Replace("\r", ""); // odstraň lomítka r (\r)

                    while (input_buffer_string[port_ID].Contains("\n"))
                    {
                        string[] split_string = input_buffer_string[port_ID].Split('\n');

                        if (split_string[0].Length > 3)
                        {
                            Message mess = new Message(split_string[0], port_ID);

                            messages_list.Enqueue(mess);

                        }

                        input_buffer_string[port_ID] = "";

                        for (int i = 1; i < split_string.Length; i++)
                        {
                            if (split_string[i] != "")
                            {
                                input_buffer_string[port_ID] += (split_string[i] + "\n");
                            }
                        }
                    }

                }

            }


        }

        private void button_connect_all_Click(object sender, EventArgs e)
        {
            bool pom = button_connect.Text == "Connect All";

            for(int i = 0; i < tableLayoutPanel3.Controls.Count;i++)
            //foreach (Button button in tableLayoutPanel3.Controls)
            {

                    if (pom) // všechny připoj
                {
                    if (tableLayoutPanel3.Controls[i].Text == "Connect")
                    {
                        if (serial_ports_list.ElementAt(tableLayoutPanel3.Controls[i].TabIndex).IsOpen)
                        {
                            (tableLayoutPanel3.Controls[i] as Button).Text = "Disconnect";
                            continue;
                        }

                        button_connect_Click(tableLayoutPanel3.Controls[i], null);
                    }
                }
                else // všechny odpoj
                {
                    if (tableLayoutPanel3.Controls[i].Text == "Disconnect")
                    {
                        if (!serial_ports_list.ElementAt(tableLayoutPanel3.Controls[i].TabIndex).IsOpen)
                        {
                            (tableLayoutPanel3.Controls[i] as Button).Text = "Connect";
                            continue;
                        }

                        button_connect_Click(tableLayoutPanel3.Controls[i], null);
                    }
                }

            }

        }

        private void button_connect_Click(object sender, EventArgs e)
        {

            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            if (button.Text == "Disconnect")
            {

                if (!CloseSerialPort(button.TabIndex))// zavři port
                {

                    MessageBox.Show("The port " + serial_ports_list.ElementAt(button.TabIndex).PortName + " cannot be closed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // port nelze zavřít
                }
                else
                {
                    (tableLayoutPanel6.Controls[(button.TabIndex)] as ComboBox).BackColor = Color.LightCoral;
                    (tableLayoutPanel6.Controls[(button.TabIndex)] as ComboBox).DropDownStyle = ComboBoxStyle.DropDown;
                    listView1.Items.Add(new ListViewItem("Device " + (5 - button.TabIndex) + " disconnected "));
                   // connection_check_timers[button.TabIndex].Enabled = false;

                }

                //  alive_message[(button.TabIndex)] = false;
            }
            else
            {
                if (!OpenSerialPort(button.TabIndex)) // otevři port
                {
                    MessageBox.Show("The port " + serial_ports_list.ElementAt(button.TabIndex).PortName + " cannot be opened", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // port nelze otevřít
                }
                else
                {

                    if (import_state)
                    {
                        button_clear_log_Click(new Button() { Text = "Import log file" }, null);
                        button_clear_log.Enabled = true;
                        import_state = false;
                    }

                    (tableLayoutPanel6.Controls[(button.TabIndex)] as ComboBox).BackColor = Color.NavajoWhite;
                    (tableLayoutPanel6.Controls[(button.TabIndex)] as ComboBox).DropDownStyle = ComboBoxStyle.Simple;  // aby nešli měnit comboxy při otevřených portech

                    auto_import_name = pureLogFileName;
                }
            }



            if (serial_ports_list[button.TabIndex].IsOpen)
            {
                (tableLayoutPanel3.Controls[(button.TabIndex)] as Button).Text = "Disconnect";
                (tableLayoutPanel6.Controls[(button.TabIndex)] as ComboBox).BackColor = Color.NavajoWhite;
                (tableLayoutPanel6.Controls[(button.TabIndex)] as ComboBox).DropDownStyle = ComboBoxStyle.Simple;  // aby nešli měnit comboxy při otevřených portech
            }
            else
            {
                (tableLayoutPanel3.Controls[(button.TabIndex)] as Button).Text = "Connect";
                (tableLayoutPanel6.Controls[(button.TabIndex)] as ComboBox).BackColor = Color.LightCoral;
                (tableLayoutPanel6.Controls[(button.TabIndex)] as ComboBox).DropDownStyle = ComboBoxStyle.DropDown;
            }

            // disconnect/connect u celkového tlačítka

            bool pom = true;

            foreach (Button button_all in tableLayoutPanel3.Controls)
            {
                if (!(button_all.Text == "Disconnect"))
                {
                    pom = false;
                }

            }

            if (pom)
            {
                button_connect.Text = "Disconnect All";
            }
            else
            {
                button_connect.Text = "Connect All";
            }


            // vynulování přetečení času

            pom = true;

            foreach (Button button_all in tableLayoutPanel3.Controls)
            {
                if ((button_all.Text == "Disconnect"))
                {
                    pom = false;
                }

            }

            if (pom)
            {
                overtiming = 0;
                button_import.Enabled = true;
                button_time_reset.Enabled = false;
                // všechny porty jsou odpojeny

                buttonFilter.Enabled = true;
                last_message = null;
                all_ports_disconnect = true;

                messages_list = new ConcurrentQueue<Message>();
                for (int i = 0; i < 5; i++)
                {

                    input_buffer_string[i] = "";
                    // first_message[i] = true;
                }


            }
            else
            {
                button_import.Enabled = false;
                button_time_reset.Enabled = true;
                buttonFilter.Enabled = false;

            }


        }

        private void Color_rows(Message mess)
        {
            /*
            switch (mess.ID)
            {
                case 1:
                    {
                        listView1.Items[listView1.Items.Count - 1].BackColor = Color.LightGreen;
                        break;
                    }
                case 2:
                    {
                        listView1.Items[listView1.Items.Count - 1].BackColor = Color.LightCoral;
                        break;
                    }
                case 3:
                    {
                        listView1.Items[listView1.Items.Count - 1].BackColor = Color.LightGoldenrodYellow;
                        break;
                    }
                case 4:
                    {
                        listView1.Items[listView1.Items.Count - 1].BackColor = Color.LightSkyBlue;
                        break;
                    }
                case 5:
                    {
                        listView1.Items[listView1.Items.Count - 1].BackColor = Color.LightSalmon;
                        break;
                    }

            }
            */


            // zobrazení barvy podle přijatých dat ve zprávě, místo na základě COM portu


            if (mess.Message_type != Message.message_type.data)
            {
                listView1.Items[listView1.Items.Count - 1].BackColor = Color.White;
                return;
            }

            if (mess.Communication_type == Message.communication_type.Car_to_key_CH1)
            {
                listView1.Items[listView1.Items.Count - 1].BackColor = Color.LightCoral;
            }
            else if (mess.Communication_type == Message.communication_type.Car_to_key_CH2)
            {
                listView1.Items[listView1.Items.Count - 1].BackColor = Color.LightSkyBlue;
            }
            else if (mess.Communication_type == Message.communication_type.Key_to_Car_CH1)
            {
                listView1.Items[listView1.Items.Count - 1].BackColor = Color.LightGreen;
            }
            else if (mess.Communication_type == Message.communication_type.Key_to_Car_CH2)
            {
                listView1.Items[listView1.Items.Count - 1].BackColor = Color.LightGoldenrodYellow;
            }
            else if (mess.Communication_type == Message.communication_type.Car_to_key_LF)
            {
                listView1.Items[listView1.Items.Count - 1].BackColor = Color.LightSalmon;
            }
            else
            {
                listView1.Items[listView1.Items.Count - 1].BackColor = Color.White;
            }
        }

        private void SendMessage(Message mess)
        {


            string str = mess.Message_type.ToString().Replace("_", " ");
            Message message = new Message(str, 5 - mess.ID);
            if (SendSerialData(str, 5 - mess.ID))
            {/*
                listView1.Items.Add(new ListViewItem(message.ToStringArray()));
                //log.Add(message);
                Color_rows(message);


                if (listView1.Items.Count > 0)
                {
                    if (checkBox_auto_scroll.CheckState == CheckState.Checked)
                    {
                        listView1.Items[listView1.Items.Count - 1].EnsureVisible();
                    }
                }
                
                */
            }
        }

        private void start_timers_Tick(object sender, EventArgs e)
        {
            Timer tim = sender as Timer;
            if (tim == null)
            {
                return;
            }

            tim.Enabled = false;

            // if (!alive_message[(int)tim.Tag])
            // {
            SendMessage(new Message(Message.message_type.HFLFSpyStop.ToString().Replace("_", " "), (int)tim.Tag)); //odeslání start stop při 
            System.Threading.Thread.Sleep(100);
            SendMessage(new Message(Message.message_type.LCM_Backlight_on.ToString().Replace("_", " "), (int)tim.Tag));
            System.Threading.Thread.Sleep(100);
            //  }

            SendMessage(new Message(Message.message_type.HFLFSpyStart.ToString().Replace("_", " "), (int)tim.Tag));
            System.Threading.Thread.Sleep(100);
            SendMessage(new Message(Message.message_type.LCM_Backlight_off.ToString().Replace("_", " "), (int)tim.Tag));
            System.Threading.Thread.Sleep(100);
            SendMessage(new Message(Message.message_type.EN5VSWITCH_Set_on.ToString().Replace("_", " "), (int)tim.Tag));
            light_off[(int)tim.Tag] = true;

            //  alive_message[(int)tim.Tag] = false;



        }

        private void connection_chck_timers_Tick(object sender, EventArgs e)
        {
            MySecondTimer tim = sender as MySecondTimer;
            if (tim == null)
            {
                return;
            }

            //if (connection_check[(int)tim.Tag])
            if (tim.State)
            {
                if (connection_check[(int)tim.Tag])
                {
                    // v pořádku
                    (tableLayoutPanel6.Controls[(int)tim.Tag] as ComboBox).BackColor = Color.PaleGreen;
                }
                else
                {
                    // nedostali jsme odpoved
                    (tableLayoutPanel6.Controls[(int)tim.Tag] as ComboBox).BackColor = Color.NavajoWhite;
                }

                connection_check[(int)tim.Tag] = false;

                tim.Interval = 30000;
                tim.State = false;
            }
            else
            {
                tim.Interval = 100;
                tim.State = true;
                connection_check[(int)tim.Tag] = false;
                SendMessage(new Message(Message.message_type.productid_get.ToString().Replace("_", " "), (int)tim.Tag));
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*string fff;
            while (str_list.Count > 0)
            {
                if (!str_list.TryDequeue(out fff))
                {
                    // chbya
                }
                else
                {
                    str_log.Insert(0, new LLog(fff));
                }
            }
            */

            if (pause)
            {
                return;
            }

            while (messages_list.Count > 0)
            {
                Message mess;

                if (!messages_list.TryDequeue(out mess))
                {
                    // chbya
                }
                else
                {

                    if (mess.Message_type == Message.message_type.data)
                    {
                        if (mess.Value_byte == null)
                        {
                            return;
                        }

                        if (((int)mess.Communication_type < 0) || ((int)mess.Communication_type > 4) || (mess.Value_byte.Count < 1))
                        {
                            return;
                        }

                        if (!light_off[5 - mess.ID])
                        {
                            SendMessage(new Message(Message.message_type.LCM_Backlight_off.ToString().Replace("_", " "), 5 - mess.ID));
                            SendMessage(new Message(Message.message_type.EN5VSWITCH_Set_on.ToString().Replace("_", " "), 5 - mess.ID));
                        }


                        if (all_ports_disconnect)
                        {
                            // všechny porty byli disconnect, ale teď je jeden z nich connect
                            last_message = null;
                            overtiming = 0;
                            all_ports_disconnect = false;
                            ignore_message = true;
                        }

                        // najdi poslední zprávu z daného klíčku:
                        if (last_message != null)
                        {

                            if ((mess.Timestamp + (overtime_constant * overtiming) + (overtime_constant / 2)) < last_message.Timestamp)
                            {
                                overtiming++;
                            }
                        }

                        mess.Timestamp += (int)(overtime_constant * overtiming);

                        last_message = mess;

                    }

                    // pokud je seriový port uzavřen, nechci ji již zobrazit

                    if (serial_ports_list[5 - mess.ID].IsOpen)
                    {
                        if (start_timers[5 - mess.ID].Enabled == false)
                        {

                            // nuluj check timer
                            /*
                            connection_check_timers[5 - mess.ID].Stop();
                            connection_check_timers[5 - mess.ID].Start();
                            connection_check_timers[5 - mess.ID].Interval = 30000;
                            connection_check_timers[5 - mess.ID].State = false;
                           */ connection_check[5 - mess.ID] = false;
                            
                            if (mess.Message_type == Message.message_type.data)
                            {

                                if ((tableLayoutPanel6.Controls[5 - mess.ID] as ComboBox).BackColor != Color.PaleGreen)
                                {
                                    (tableLayoutPanel6.Controls[5 - mess.ID] as ComboBox).BackColor = Color.PaleGreen;
                                }


                                if (!ignore_message && (mess.Timestamp != 0))
                                {
                                    
                                    
                                    if (filter_com.Contains((int)mess.Communication_type))
                                    {

                                        if (filter_id.Contains(mess.Interpreter_ID))
                                        {
                                            if (mess.Communication_type == Message.communication_type.Car_to_key_LF)
                                            {

                                                if (filter_minimum_length_LF <= mess.Value_byte.Count)
                                                {
                                                    if (filter_wup == null)
                                                    {
                                                        listView1.Items.Add(new ListViewItem(mess.ToStringArray()));
                                                        Color_rows(mess);
                                                    }
                                                    else
                                                    {
                                                        if ((filter_wup.Length == 0) || (!filter_wup_on))
                                                        {
                                                            listView1.Items.Add(new ListViewItem(mess.ToStringArray()));
                                                            Color_rows(mess);
                                                        }
                                                        else
                                                        {
                                                            if (filter_wup == mess.WUP)
                                                            {
                                                                listView1.Items.Add(new ListViewItem(mess.ToStringArray()));
                                                                Color_rows(mess);
                                                            }
                                                        }
                                                    }


                                                }

                                            }
                                            else
                                            {

                                                if (filter_minimum_length_HF <= mess.Value_byte.Count)
                                                {
                                                    if ((!filter_wup_on))
                                                    {
                                                        listView1.Items.Add(new ListViewItem(mess.ToStringArray()));
                                                        Color_rows(mess);
                                                    }
                                                }

                                            }
                                        }
                                    }
                                    log.Add(mess); // přidání do seznamu, abych s ní mohl pak dále pracovat
                                                   //ExportLog();
                                }

                                if(mess.Timestamp < 500)
                                {
                                    ignore_message = false;
                                }

                       
                                
                            }

                            if (mess.Message_type == Message.message_type.REQUEST)
                            {
                                listView1.Items.Add(new ListViewItem("Device " + mess.ID + " connected "));
                            }

                        }

                        if (mess.Message_type == Message.message_type.FTM_Ready)
                        {
                            if (!already_alive[5 - mess.ID])
                            {
                                already_alive[5 - mess.ID] = true;

                                SendMessage(new Message(Message.message_type.FTM_Alive.ToString().Replace("_", " "), 5 - mess.ID));
                                System.Threading.Thread.Sleep(100);

                                // alive_message[5 - mess.ID] = true;

                                /*
                                 * SendMessage(new Message(Message.message_type.HFLFSpyStart.ToString().Replace("_", " "), 5 - mess.ID));
                                System.Threading.Thread.Sleep(100);
                                SendMessage(new Message(Message.message_type.LCM_Backlight_off.ToString().Replace("_", " "), 5 - mess.ID));
                                light_off[5 - mess.ID] = true;
                                */
                                (tableLayoutPanel6.Controls[5 - mess.ID] as ComboBox).BackColor = Color.PaleGreen;
                            }
                        }

                        if (mess.Message_type == Message.message_type.ProductID)
                        {
                            connection_check[5 - mess.ID] = true;
                        }

                        ExportLog();

                        if ((checkBox_auto_scroll.CheckState == CheckState.Checked) && (listView1.Items.Count != 0))
                        {
                            listView1.Items[listView1.Items.Count - 1].EnsureVisible();
                        }

                    }

                }

            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            ComboBox comboBox = sender as ComboBox;
            if (comboBox == null)
            {
                return;
            }

            try
            {

                com_ports[comboBox.TabIndex] = comboBox.SelectedItem.ToString();


                bool pom = false;

                foreach (string str in SerialPort.GetPortNames())
                {
                    if (str == comboBox.Text)
                    {
                        pom = true;
                    }
                }

            (tableLayoutPanel3.Controls[(comboBox.TabIndex)] as Button).Enabled = pom;

                // pro celkové tlačítko
                pom = true;

                foreach (Button button in tableLayoutPanel3.Controls)
                {
                    if (!button.Enabled)
                    {
                        pom = false;
                    }

                }

                button_connect.Enabled = pom;
            }
            catch (Exception ex)
            {
                // chyba
            }
        }

        private bool SendSerialData(string s, int num)
        {
            string str = s + "\n";

            byte[] array = Encoding.ASCII.GetBytes(str);

            try
            {

                if (serial_ports_list[num].IsOpen)
                {
                    serial_ports_list[num].Write(array, 0, array.Length);
                    return true;
                }
                else
                {
                    (tableLayoutPanel6.Controls[(num)] as ComboBox).BackColor = Color.LightCoral;
                    (tableLayoutPanel6.Controls[(num)] as ComboBox).DropDownStyle = ComboBoxStyle.DropDown;
                    (tableLayoutPanel3.Controls[(num)] as Button).Text = "Connect";

                    already_alive[num] = false;
                    start_timers[num].Enabled = false;
                    return false;
                }
            }
            catch (Exception ex)
            {

                (tableLayoutPanel6.Controls[(num)] as ComboBox).BackColor = Color.LightCoral;
                (tableLayoutPanel6.Controls[(num)] as ComboBox).DropDownStyle = ComboBoxStyle.DropDown;
                (tableLayoutPanel3.Controls[(num)] as Button).Text = "Connect";

                already_alive[num] = false;
                start_timers[num].Enabled = false;
                return false;
                // chyba
            }

        }

        private void button_clear_log_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            all_ports_disconnect = true;
            overtiming = 0;

            if (button.Text == "Import log file")
            {
                log.Clear();
                listView1.Items.Clear();
                return;
            }

            DialogResult res = MessageBox.Show("Do you want to create new log files?", "Clear list", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (DialogResult.Cancel == res)
            {
                return;

            }
            else
            {

                log.Clear();
                listView1.Items.Clear();

                if (DialogResult.No == res)
                {
                    return;

                }
                else if (DialogResult.Yes == res)
                {

                    if ((pureLogFileName == "SniffLog_" + DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm") + ".asc") || (pureLogFileName == "SniffLog_" + DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm") + "_" + log_name + ".asc"))
                    {
                        log_name++;
                        pureLogFileName = "SniffLog_" + DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm") + "_" + log_name + ".asc";
                        LogFileName = "SniffLogText_" + DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm") + "_" + log_name + ".txt";
                    }
                    else
                    {
                        pureLogFileName = "SniffLog_" + DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm") + ".asc";
                        LogFileName = "SniffLogText_" + DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm") + ".txt";
                        log_name = 1;
                    }
                    new_log = true;
                    return;
                }

                return;
            }

        }

        private void ExportLog()
        {
            if (log.Count < 1)
                return;

            try
            {
                if (log[0].Message_type == Message.message_type.data)
                {
                    if (new_log)
                    {
                        File.AppendAllText(pureLogFileName, String.Format("date {0}", DateTime.UtcNow.ToString("ddd MMM dd HH:mm:ss yyyy", new CultureInfo("en-US"))) + Environment.NewLine
                            + "base hex  timestamps absolute" + Environment.NewLine + "no internal events logged" + Environment.NewLine + Environment.NewLine
                            + "Information: der Status einer MOST-Spy-Nachricht ist immer auf 0 gesetzt." + Environment.NewLine + Environment.NewLine
                            + "CAN 1: BCP_CAN_FD" + Environment.NewLine + Environment.NewLine, Encoding.GetEncoding("Windows-1250"));

                        new_log = false;
                    }

                    string line = log[0].ToExportPureLog();

                    File.AppendAllText(pureLogFileName, line + Environment.NewLine, Encoding.GetEncoding("Windows-1250"));

                    line = log[0].ToExportLog();

                    File.AppendAllText(LogFileName, line + Environment.NewLine, Encoding.GetEncoding("Windows-1250"));
                }

                log.RemoveAt(0);
            }
            catch (IOException e)
            {
            }

        }

        private void comboBox5_Click(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox == null)
            {
                return;
            }

            string[] ports = SerialPort.GetPortNames();

            foreach (ComboBox combo in tableLayoutPanel6.Controls)
            {
                combo.Items.Clear();
                combo.Items.AddRange(ports);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // před zavíráním ukončit všechny thredy a odpojit COM porty!!!!!!!!!!!!!!!!!!!!
            if (com_ports[0] != null)
            {
                if (com_ports[0] != "")
                {
                    Settings.Default.com1 = com_ports[0];
                }
            }
            if (com_ports[1] != null)
            {
                if (com_ports[1] != "")
                {
                    Settings.Default.com2 = com_ports[1];
                }
            }
            if (com_ports[2] != null)
            {
                if (com_ports[2] != "")
                {
                    Settings.Default.com3 = com_ports[2];
                }
            }
            if (com_ports[3] != null)
            {
                if (com_ports[3] != "")
                {
                    Settings.Default.com4 = com_ports[3];
                }
            }
            if (com_ports[4] != null)
            {
                if (com_ports[4] != "")
                {
                    Settings.Default.com5 = com_ports[4];
                }
            }
            Settings.Default.Save();

            for (int i = 0; i < 5; i++)
            {
                CloseSerialPort(i);
            }

        }

        private void button_time_reset_Click(object sender, EventArgs e)
        {


            for (int i = 0; i < 5; i++)
            {
                SendMessage(new Message(Message.message_type.HFLFSpyStop.ToString().Replace("_", " "), i)); //odeslání start stop při
                System.Threading.Thread.Sleep(100);
                SendMessage(new Message(Message.message_type.LCM_Backlight_on.ToString().Replace("_", " "), i));
                light_off[i] = false;
                listView1.Items.Add(new ListViewItem("Device " + (6 - i) + " restarted "));


                // first_message[i] = true;

            }

            System.Threading.Thread.Sleep(100);

            for (int i = 0; i < 5; i++)
            {
                SendMessage(new Message(Message.message_type.HFLFSpyStart.ToString().Replace("_", " "), i)); //odeslání start stop při 
                System.Threading.Thread.Sleep(100);
                SendMessage(new Message(Message.message_type.LCM_Backlight_off.ToString().Replace("_", " "), i));
                System.Threading.Thread.Sleep(100);
                SendMessage(new Message(Message.message_type.EN5VSWITCH_Set_on.ToString().Replace("_", " "), i));
                light_off[i] = true;
                
            }

            overtiming = 0;
            all_ports_disconnect = true;

        }

        private void button_import_Click(object sender, EventArgs e)
        {
            button_clear_log_Click(sender, null);

            String fileName = String.Empty;

            string window_name = "Import in progress...";

            if ((string)(sender as Button).Tag == "Filter")
            {
               // fileName = pureLogFileName;
                fileName = auto_import_name;

                window_name = "Applying filter...";

            }
            else
            {
                
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Soubory dat (*.asc)|*.asc|Vsechny|*.*";

                    if (DialogResult.OK == openFileDialog.ShowDialog())
                    {
                        fileName = openFileDialog.FileName;

                        if (fileName.Substring(fileName.Length - 3, 3) != "asc")
                        {
                            MessageBox.Show("Invalid file type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            return;
                        }

                    }
                    else
                    {
                        return;
                    }
                }
            }
            bool fileExist = File.Exists(fileName);

            if (!fileExist)
            {
                new_log = true;
            }

            if (!String.IsNullOrEmpty(fileName))
            {

                try
                {
                    String[] lines = File.ReadAllLines(fileName, Encoding.GetEncoding("Windows-1250"));

                    // import starých dat

                    Form_Loading openForm = new Form_Loading(lines.Length,window_name);
                    openForm.Show();

                    int preteceni = 0;

                    DateTime t = DateTime.UtcNow;

                    for (int i = 0; i < lines.Length; i++)
                    {
                        openForm.Progre();

                        if (lines[i] == "")
                        {
                            continue;
                        }

                        if (lines[i].Contains("date"))
                        {

                            t = DateTime.ParseExact(lines[i].Substring(5), "ddd MMM dd HH:mm:ss yyyy", System.Globalization.CultureInfo.InvariantCulture);

                            continue;
                        }

                        if (lines[i].Contains("base hex  timestamps absolute") || lines[i].Contains("no internal events logged") || lines[i].Contains("Information: der Status einer MOST-Spy-Nachricht ist immer auf 0 gesetzt.") || lines[i].Contains("CAN 1: BCP_CAN_FD"))
                        {
                            continue;
                        }

                        string str = lines[i].Substring(48);

                        string[] d = str.TrimStart().Split(' ');

                        List<byte> list = new List<byte>();

                        for (int j = 0; j < d.Length - 9; j++)
                        {
                            if (d[j] != "")
                                try
                                {
                                    list.Add(Convert.ToByte(d[j], 16));
                                }
                                catch (Exception exc)
                                {
                                    openForm.Close();
                                    return;
                                }
                        }

                        if (list.Count == 0)
                        {

                            openForm.Close();
                            return;

                        }

                        int id = 4 - (list.ElementAt(0) >> 4);

                        Message mess = new Message(str.TrimStart().Substring(0, str.Length - 20), id);
                        
                        if (log.Count > 0)
                        {
                            if ((mess.Timestamp + (overtime_constant * preteceni) + (overtime_constant / 2)) < log[log.Count - 1].Timestamp)
                            {
                                preteceni++;
                            }
                        }
                        mess.Timestamp += (int)(overtime_constant * preteceni);

                        DateTime tt = t;

                        tt = tt.AddMilliseconds(mess.Timestamp);

                        if (filter_com.Contains((int)mess.Communication_type))
                        {

                            if (filter_id.Contains(mess.Interpreter_ID))
                            {
                                if (mess.Communication_type == Message.communication_type.Car_to_key_LF)
                                {

                                    if (filter_minimum_length_LF <= mess.Value_byte.Count)
                                    {
                                        if (filter_wup == null)
                                        {
                                            listView1.Items.Add(new ListViewItem(mess.ToStringArray(tt)));
                                            Color_rows(mess);
                                        }
                                        else
                                        {
                                            if ((filter_wup.Length == 0) || (!filter_wup_on))
                                            {
                                                listView1.Items.Add(new ListViewItem(mess.ToStringArray(tt)));
                                                Color_rows(mess);
                                            }
                                            else
                                            {
                                                
                                                if ((filter_wup[0] == mess.WUP[0])&&(filter_wup[1] == mess.WUP[1]) && (filter_wup[2] == mess.WUP[2]) && (filter_wup[3] == mess.WUP[3]))
                                                {
                                                    listView1.Items.Add(new ListViewItem(mess.ToStringArray(tt)));
                                                    Color_rows(mess);
                                                }
                                            }
                                        }


                                    }

                                }
                                else
                                {

                                    if (filter_minimum_length_HF <= mess.Value_byte.Count)
                                    {
                                        if ((!filter_wup_on))
                                        {
                                            listView1.Items.Add(new ListViewItem(mess.ToStringArray(tt)));
                                            Color_rows(mess);
                                        }
                                    }

                                }
                            }

                        }
                       
                        log.Add(mess); // přidání do seznamu, abych s ní mohl pak dále pracovat
                        if (!fileExist)
                        {
                            ExportLog();
                        }
                        

                    }
                    openForm.Close();
                    last_message = null;
                    import_state = true;
                    button_clear_log.Enabled = false;

                    auto_import_name = fileName;


                }
                catch (IOException ex)
                {
                    MessageBox.Show("An I/O error occurred while opening the file...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("Empty file...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void button_help_Click(object sender, EventArgs e)
        {

            Form_Help openForm = new Form_Help();
            openForm.Show();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "D")
            {
                button_clear_log_Click(new Button(), null);
            }
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            using (Filter filter = new Filter(filter_minimum_length_HF, filter_minimum_length_LF, filter_id, filter_wup,filter_wup_on,filter_com))
            {

                filter.ShowDialog();

                filter_minimum_length_HF = filter.filter_minimum_length_HF;
                filter_minimum_length_LF = filter.filter_minimum_length_LF;

                filter_id = filter.filter_id;
                filter_com = filter.filter_com;

                filter_wup = filter.wup;
                filter_wup_on = filter.wup_bb;

                // znovu načtení zpráv s respektováním filtru

            }

            pause = true;

            //if (File.Exists(pureLogFileName))
            //{
                Button button = new Button() { Text = "Import log file", Tag = "Filter" };

                button_import_Click(button, null);
            //}
            pause = false;

        }
    } 
    public class Message
    {
        public List<byte> Value_byte { get; set; }
        public string Value_string { get; set; }
        public int Timestamp { get; set; }
        public int Interpreter_ID { get; set; }

        [DisplayName("Communication type")]
        public communication_type Communication_type { get; set; }
        public baudrate Baudrate { get; set; }
        
        [DisplayName("Data")]
        public string Received_data { get; set; }
        public string Value { get; set; }
        public int ID { get; set; }
        public message_type Message_type { get; set; }
        public byte[] WUP { get; set; }
        public enum communication_type
        {
            Key_to_Car_CH1,
            Key_to_Car_CH2,
            Car_to_key_CH1,
            Car_to_key_CH2,
            Car_to_key_LF

        }

        public enum baudrate
        {
            _8kBit = 1,
            _19_2kBit,
            _2kBit,
        }

        public enum message_type
        {
            data,
            FTM_Ready,
            FTM_Alive,
            HFLFSpyStart,
            Start_LFHF_thread,
            HFLFSpyStop,
            Stop_LFHF_thread,
            Cancel_and_join_thread,
            usb_cable_connected,
            Error_Message,
            API_status,
            REQUEST,
            HFLF_already_running,
            LCM_Backlight_off,
            LCM_Backlight_on,
            productid_get,
            ProductID,
            EN5VSWITCH_Set_on,

        }

        public Message(string value, int id)
        {

            if (value == "")
            {
                return;
            }

            Load_Message(value, id);
        }

        private void Load_Message(string str, int id)
        {
            ID = 5 - id;

            if (str == "FTM Ready")
            {
                Message_type = message_type.FTM_Ready;
            }
            else if (str == "FTM Alive")
            {
                Message_type = message_type.FTM_Alive;
            }
            else if (str == "HFLFSpyStart")
            {
                Message_type = message_type.HFLFSpyStart;
            }
            else if (str == "Start LFHF thread")
            {
                Message_type = message_type.Start_LFHF_thread;
            }
            else if (str == "HFLFSpyStop")
            {
                Message_type = message_type.HFLFSpyStop;
            }
            else if (str == "Stop LFHF thread")
            {
                Message_type = message_type.Stop_LFHF_thread;
            }
            else if (str == "Cancel and join thread")
            {
                Message_type = message_type.Cancel_and_join_thread;
            }
            else if (str == "REQUEST=84 00 00 00 00 00 00 00")
            {
                Message_type = message_type.REQUEST;
            }
            else if (str == "API status=ok")
            {
                Message_type = message_type.API_status;
            }
            else if (str == "Error Message=Non")
            {
                Message_type = message_type.Error_Message;
            }
            else if (str == "usb cable connected")
            {
                Message_type = message_type.usb_cable_connected;
            }
            else if (str == "HFLF already running")
            {
                Message_type = message_type.HFLF_already_running;
            }
            else if (str == "LCM Backlight off")
            {
                Message_type = message_type.LCM_Backlight_off;
            }
            else if (str == "LCM Backlight on")
            {
                Message_type = message_type.LCM_Backlight_on;
            }
            else if (str == "ProductID=ST84301786N1")
            {
                Message_type = message_type.ProductID;
            }
            else if (str == "productid get")
            {
                Message_type = message_type.productid_get;
            }
            else if (str == "EN5VSWITCH Set on")
            {
                Message_type = message_type.EN5VSWITCH_Set_on;
            }
            else
            {
                Message_type = message_type.data;
            }

            if (Message_type == message_type.data)
            {

                Value_string = str;

                string[] d = str.Split(' ');
            
                List<byte> list = new List<byte>();

                for (int i = 0; i < d.Length; i++)
                {
                    if (d[i] != "")
                        try
                        {
                            list.Add(Convert.ToByte(d[i], 16));
                        }
                        catch(Exception e)
                        {
                            return;
                        }
                }

                if (list.Count == 0)
                {
                    return;
                }

                Communication_type = (communication_type)(list.ElementAt(0) >> 4);
                Baudrate = (baudrate)(list.ElementAt(0) & 0xF);
                list.RemoveAt(0);
                Timestamp = (((list.ElementAt(0)) | (list.ElementAt(1) << 8)) * 10);
                list.RemoveAt(0);
                list.RemoveAt(0);
                Received_data = "";

                Value_byte = new List<byte>();

                foreach (byte b in list)
                {
                    Value_byte.Add(b); 
                    Received_data += String.Format("{0,2:X2}  ", b);
                }

                Value = Not_my_code(str,Timestamp);

            }
        }

        private string Not_my_code(string str, int Timestamp)
        {
            try
            {
                Interpreter msg = new Interpreter();
                byte[] rxArr = new byte[100];
                for (int i = 0; i < 100; i++) rxArr[i] = 0;  // nemám tušení k čemu to tady je

                Interpreter.MsgType msgType = msg.MsgInterpreter(Timestamp, str, rxArr);

                Interpreter_ID = (int)msgType;

                try
                {
                    if (Interpreter.lastLfMsg != null)
                    {
                        WUP = Interpreter.lastLfMsg.wupArr;
                    }

                }
                catch (NullReferenceException exx)
                {
                    WUP = null;
                }

                switch (msgType)  //Write interpretation of the message
                {
                    case Interpreter.MsgType.RKE_challReq:
                        return "->  RKE Challange Request" + "   \tID " + Interpreter.lastRKEChallReq.keyID.ToString("X4") + " \tWUP = 0x" + Interpreter.lastRKEChallReq.carWUP.ToString("X4") + " \tFC = 0x" + Interpreter.lastRKEChallReq.fc.ToString("X") + " \tbutton is " + msg.InterpretButton(Interpreter.lastRKEChallReq.button);

                    case Interpreter.MsgType.SleepReq:
                        return "->  Sleep Request" + "   \tID " + Interpreter.lastRKEChallReq.keyID.ToString("X4") + " \tWUP = 0x" + Interpreter.lastRKEChallReq.carWUP.ToString("X4");

                    case Interpreter.MsgType.GoToSleep:
                        return "->  Go to sleep" + "   \tID " + Interpreter.lastRKEChallReq.keyID.ToString("X4") + " \tWUP = 0x" + Interpreter.lastRKEChallReq.carWUP.ToString("X4");

                    case Interpreter.MsgType.RKE_Res:
                        if (Interpreter.lastRKERes.lfPing)
                        {
                            return "-> RKE Response" + "   \tID " + Interpreter.lastRKERes.keyID.ToString("X4") + " \tFC = 0x" + Interpreter.lastRKERes.fc.ToString("X") + " \tbutton " + msg.InterpretButton(Interpreter.lastRKERes.button) + " \tLF Ping value " + Interpreter.lastRKERes.lfPingValue.ToString("X");
                        }
                        else
                        {
                            return "-> RKE Response" + "   \tID " + Interpreter.lastRKERes.keyID.ToString("X4") + " \tFC = 0x" + Interpreter.lastRKERes.fc.ToString("X") + " \tbutton " + msg.InterpretButton(Interpreter.lastRKERes.button);
                        }

                    case Interpreter.MsgType.RCP_Res:
                        if (Interpreter.lastRCPRes.lfPingState != 0)
                        {
                            return "-> RCP Response" + "   \tID " + Interpreter.lastRKERes.keyID.ToString("X4") + " \tFC = 0x" + Interpreter.lastRKERes.fc.ToString("X") + " \tbutton " + msg.InterpretButton(Interpreter.lastRKERes.button);
                        }
                        else
                        {
                            return "-> RCP Response" + "   \tID " + Interpreter.lastRKERes.keyID.ToString("X4") + " \tFC = 0x" + Interpreter.lastRKERes.fc.ToString("X") + " \tbutton " + msg.InterpretButton(Interpreter.lastRKERes.button) + " \tLF Ping value " + Interpreter.lastRKERes.lfPingValue.ToString("X2");
                        }


                    case Interpreter.MsgType.RKE_chall:
                        return "-> RKE Acknowlege & Challenge" + "   \t two bytes of ID =0x" + Interpreter.lastRKEChall.halfID.ToString("X2") + " \tFC = 0x" + Interpreter.lastRKEChall.fc.ToString("X");

                    case Interpreter.MsgType.CACG_AC:
                        return "-> Anti-collision CRC4 OK with FC 0x" + Interpreter.lastAC.fc.ToString("X") + "   \tID " + Interpreter.lastAC.keyID.ToString("X4");

                    case Interpreter.MsgType.CKT_AC:
                        return "-> CKT Anti-collision CRC4 OK with FC 0x" + Interpreter.lastCktAC.fc.ToString("X") + "   \tID " + Interpreter.lastCktAC.keyID.ToString("X4");

                    case Interpreter.MsgType.CACG_Chall:
                        return "-> CACG Challange for key ID: " + Interpreter.lastCaChall.keyID.ToString("X4");

                    case Interpreter.MsgType.CACG_Res:
                        if (Interpreter.lastCaRes.amtHFM > 0)
                        {
                            string stt = "-> CACG Response with RSSI:";
                            for (int i = 0; i < Interpreter.lastCaRes.amtHFM; i++)
                            {
                                stt += @"\" + " Antenna" + (i + 1).ToString() + ":  " + Interpreter.lastCaRes.dRssi[i, 3].ToString("{#000.0}") + " nT \t X: " + Interpreter.lastCaRes.dRssi[i, 0].ToString("{##00.0}") + "    Y: " + Interpreter.lastCaRes.dRssi[i, 1].ToString("{##00.0}") + "    Z: " + Interpreter.lastCaRes.dRssi[i, 2].ToString("{##00.0}");
                            }

                            return stt;
                        }
                        else
                        {
                            return "-> CACG Response without HFM measurement";
                        }


                    case Interpreter.MsgType.KI_Req1:
                        return "-> Key Info Request first part ";

                    case Interpreter.MsgType.KI_Req:
                        return "-> Key Info Request   \"" + Interpreter.lastKiReq.getKiType() + "\"  ID " + Interpreter.lastKiReq.keyID.ToString("X4");

                    case Interpreter.MsgType.KI_Stat1:
                        return "-> Key Info Status1 " + Interpreter.lastKiStat1.getKiType();

                    case Interpreter.MsgType.KI_Stat2:
                        return "-> Key Info Status2   " + Interpreter.lastKiStat2.GetStringStatus();

                    case Interpreter.MsgType.THS_ChallReq:
                        return "-> THS Challenge Request " + "   \tID " + Interpreter.lastTHSChallReq.keyID.ToString("X4");

                    case Interpreter.MsgType.THS_Chall:
                        return "-> THS Challenge ";

                    case Interpreter.MsgType.THS_Res:
                        if (Interpreter.lastTHSRes.crcPass)
                        {
                            return "-> THS Response ";
                        }
                        else
                        {
                            return "-> THS Response but not CRC not valid!!!";
                        }

                    case Interpreter.MsgType.THS_St1:
                        return "-> THS Status1 ";

                    case Interpreter.MsgType.THS_St2:
                        return "-> THS Status2 ";

                    case Interpreter.MsgType.THS_St3:
                        return "-> THS Status3 ";

                    case Interpreter.MsgType.LF_WUP:
                        if ((Interpreter.lastLfMsg != null) && Interpreter.lastLfMsg.crcCheck)
                        {
                            return "Key Search,  SEQ " + Interpreter.lastLfMsg.seq.ToString() + "  FC " + Interpreter.lastLfMsg.fc.ToString() + "  channel " + Interpreter.lastLfMsg.channel.ToString() + "  anzHFM " + Interpreter.lastLfMsg.anzHFM.ToString() + "  anzAC " + Interpreter.lastLfMsg.anzAC.ToString();
                        }
                        else
                        {
                            return "LF WUP, but CRC4 not valid)";
                        }

                    case Interpreter.MsgType.LF_CktControl:
                        return "CKT Control" + " \t SEQ " + Interpreter.lastCktCtr.seq.ToString() + " \t control:" + Interpreter.lastCktCtr.cktCtr_i32.ToString("X4");

                    case Interpreter.MsgType.LF_Ping:
                        return "LF Ping";

                    case Interpreter.MsgType.LF_WUP_Short:
                        if ((Interpreter.lastLfCkt != null) && (Interpreter.lastLfCkt.crcCheck))
                        {
                            return "CKT,  SEQ " + Interpreter.lastLfCkt.seq.ToString() + "  ZONE " + Interpreter.lastLfCkt.cktZone.ToString();
                        }
                        else
                        {
                            return "CKT (CRC4 not proved)";
                        }

                    default:
                        return "";

                }

            }catch(Exception ex)
            {
                return "";
            }
        }

        public string[] ToStringArray()
        {
            
            if (Message_type == message_type.data)
            {
            return new string[] { DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff"), Timestamp.ToString(), Communication_type.ToString().Replace('_', ' '), Received_data, Value };
            }
            else if(Message_type == message_type.REQUEST)
            {
                return new string[] { Message_type.ToString().Replace("_", " ")+ "=84 00 00 00 00 00 00 00" };
            }
            else if (Message_type == message_type.Error_Message)
            {
                return new string[] { Message_type.ToString().Replace("_", " ")+"=Non" };
            }
            else if (Message_type == message_type.API_status)
            {
                return new string[] { Message_type.ToString().Replace("_", " ")+"=ok" };
            }
            else if (Message_type == message_type.ProductID)
            {
                return new string[] { Message_type.ToString().Replace("_", " ") + "=ST84301786N1" };
            }
            else
            {
               return new string[] { Message_type.ToString().Replace("_", " ") };
            }
        }

        public string[] ToStringArray(DateTime time)
        {

            if (Message_type == message_type.data)
            {
                return new string[] { time.ToString("yyyy-MM-dd HH:mm:ss.fff"), Timestamp.ToString(), Communication_type.ToString().Replace('_', ' '), Received_data, Value };
            }
            else if (Message_type == message_type.REQUEST)
            {
                return new string[] { Message_type.ToString().Replace("_", " ") + "=84 00 00 00 00 00 00 00" };
            }
            else if (Message_type == message_type.Error_Message)
            {
                return new string[] { Message_type.ToString().Replace("_", " ") + "=Non" };
            }
            else if (Message_type == message_type.API_status)
            {
                return new string[] { Message_type.ToString().Replace("_", " ") + "=ok" };
            }
            else if (Message_type == message_type.ProductID)
            {
                return new string[] { Message_type.ToString().Replace("_", " ") + "=ST84301786N1" };
            }
            else
            {
                return new string[] { Message_type.ToString().Replace("_", " ") };
            }
        }

        public string ToExportLog()
        {

            if (Message_type == message_type.data)
            {
                int length = Received_data.Length;

                int spaces = 90 - length;

                string space = "";

                for (int i = 0; i < spaces; i++)
                {
                    space += " ";
                }

                return String.Format("{0,30}{1,20}{2,30}      {3}{4}{5}", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff"), Timestamp.ToString(), Communication_type.ToString().Replace('_', ' '), Received_data, space, Value);
            
            }
            else
            {
                return "";
                // return String.Format(Message_type.ToString().Replace("_", " ")); // systémové hlášky
            }
        }

        public string ToExportPureLog()
        {
            if (Message_type == message_type.data)
            {
                float f = (float)Timestamp;
                f /= 1000;

                string s = String.Format("{0,16:F3} CANFD 1 Rx{1,4:X}        1 0 c {2,2} {3} 0 0 3000 0 0 0 0 0", f, Interpreter_ID,((Value_string.Length+1)/3),Value_string);

                return s.Replace(',','.');
            }
            else
            {
                return "";
            }
        }
    }

    public class MyTimer : Timer
    {
        public DateTime Time { get; set; }

    }

    public class MySecondTimer : Timer
    {
        public bool State { get; set; }

    }

    public class LLog
    {
        public String str { get; set; }

        public LLog(string sss)
        {
            str = sss;
        }
    }

}