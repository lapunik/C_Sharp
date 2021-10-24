using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Timers;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

namespace DKEY
{
    public partial class Form1 : Form
    {
        string DisplayData = "";
        string DisplayDataAll = "";
        string WriteData = "";
        string LogFileName = "SniffLog_" + DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm") + ".txt";
        bool reconnected = false;
        string pressedbutton_check;
        string releasedbutton_check;

        private static System.Timers.Timer TimerCH1Key;
        private static System.Timers.Timer TimerCH1Bdc;
        private static System.Timers.Timer TimerCH2Key;
        private static System.Timers.Timer TimerCH2Bdc;
        private static System.Timers.Timer TimerLF;

        private static System.Timers.Timer ResetTimerCom1;
        private static System.Timers.Timer ResetTimerCom2;
        private static System.Timers.Timer ResetTimerCom3;
        private static System.Timers.Timer ResetTimerCom4;
        private static System.Timers.Timer ResetTimerCom5;

        string buffer1 = "";
        string buffer2 = "";
        string buffer3 = "";
        string buffer4 = "";
        string buffer5 = "";

        string buffer1_short = "";
        string buffer2_short = "";
        string buffer3_short = "";
        string buffer4_short = "";
        string buffer5_short = "";
        string bufferall_short = "";

        string keyid_pressed = "";
        string keyid_released = "";
        string SYSmsg1 = "";
        string SYSmsg2 = "";
        string SYSmsg3 = "";
        string SYSmsg4 = "";
        string SYSmsg5 = "";

        string pokus = "";

        bool writed1 = false;
        bool writed2 = false;
        bool writed3 = false;
        bool writed4 = false;
        bool writed5 = false;

        string DataOut1 = "";
        string DataOut2 = "";
        string DataOut3 = "";
        string DataOut4 = "";
        string DataOut5 = "";

        string color = "";
        string shortmessage = "";
        string timemessage = "";
        string com_type = "";
        string IntTime = "";
        string IntTime1 = "";
        string IntTime2 = "";
        string IntTime3 = "";
        string IntTime4 = "";
        string IntTime5 = "";

        string DataOutFile1 = "";
        string DataOutFile2 = "";
        string DataOutFile3 = "";
        string DataOutFile4 = "";
        string DataOutFile5 = "";

        bool complete1 = false;
        bool complete2 = false;
        bool complete3 = false;
        bool complete4 = false;
        bool complete5 = false;

        bool started1 = false;
        bool started2 = false;
        bool started3 = false;
        bool started4 = false;
        bool started5 = false;

        bool StartCom1 = true;
        bool StartCom2 = true;
        bool StartCom3 = true;
        bool StartCom4 = true;
        bool StartCom5 = true;

        bool AutoStart1 = true;
        bool AutoStart2 = true;
        bool AutoStart3 = true;
        bool AutoStart4 = true;
        bool AutoStart5 = true;

        bool StopCom1 = false;
        bool StopCom2 = false;
        bool StopCom3 = false;
        bool StopCom4 = false;
        bool StopCom5 = false;

        bool ResetCom1 = false;
        bool ResetCom2 = false;
        bool ResetCom3 = false;
        bool ResetCom4 = false;
        bool ResetCom5 = false;

        bool button1pressed = false;
        bool button2pressed = false;
        bool button3pressed = false;
        bool button4pressed = false;

        bool Com1connected = false;
        bool Com2connected = false;
        bool Com3connected = false;
        bool Com4connected = false;
        bool Com5connected = false;

        bool Com1 = false;
        bool Com2 = false;
        bool Com3 = false;
        bool Com4 = false;
        bool Com5 = false;

        string lastMsg1 = "";
        string lastMsg2 = "";
        string lastMsg3 = "";
        string lastMsg4 = "";
        string lastMsg5 = "";


        [DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
string[] ports = SerialPort.GetPortNames();
            cBoxCOM1.Items.AddRange(ports);
            cBoxCOM2.Items.AddRange(ports);
            cBoxCOM3.Items.AddRange(ports);
            cBoxCOM4.Items.AddRange(ports);
            cBoxCOM5.Items.AddRange(ports);
            
            btnConnect.Visible = true;

            //cBoxCOM1.Text = "COM4";
            //cBoxCOM2.Text = "COM5";
            //cBoxCOM3.Text = "COM6";
            //cBoxCOM4.Text = "COM7";
            //cBoxCOM5.Text = "COM8";

        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (serialPort_com1.IsOpen == false)
            {
                try
                {
                    serialPort_com1.PortName = cBoxCOM1.Text;
                }
                catch
                {
                    MessageBox.Show("Device 1 port is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (serialPort_com2.IsOpen == false)
            {
                try
                {
                    serialPort_com2.PortName = cBoxCOM2.Text;
                }
                catch
                {
                    MessageBox.Show("Device 2 port is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (serialPort_com3.IsOpen == false)
            {
                try
                {
                    serialPort_com3.PortName = cBoxCOM3.Text;
                }
                catch
                {
                    MessageBox.Show("Device 3 port is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (serialPort_com4.IsOpen == false)
            {
                try
                {
                    serialPort_com4.PortName = cBoxCOM4.Text;
                }
                catch
                {
                    MessageBox.Show("Device 4 port is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (serialPort_com5.IsOpen == false)
            {
                try
                {
                    serialPort_com5.PortName = cBoxCOM5.Text;
                }
                catch
                {
                    MessageBox.Show("Device 5 port is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            ////CONNECTING
            if (Com1connected == false && cBoxCOM1.Text != "")
            {
                try
                {
                    serialPort_com1.DataReceived += new SerialDataReceivedEventHandler(serialPort_com1_DataReceived);
                    serialPort_com1.Open();
                    serialPort_com1.DiscardOutBuffer(); //flush buffer
                    if (serialPort_com1.IsOpen == true)
                    {
                        labelDevice1.BackColor = Color.Orange;
                        Com1connected = true;
                    }
                    else
                    {
                        labelDevice1.BackColor = Color.Red;
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (Com2connected == false && cBoxCOM2.Text != "")
            {
                try
                {
                    serialPort_com2.DataReceived += new SerialDataReceivedEventHandler(serialPort_com2_DataReceived);
                    serialPort_com2.Open();
                    serialPort_com2.DiscardOutBuffer(); //flush buffer
                    if (serialPort_com2.IsOpen == true)
                    {
                        labelDevice2.BackColor = Color.Orange;
                        Com2connected = true;
                    }
                    else
                    {
                        labelDevice2.BackColor = Color.Red;
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            if (Com3connected == false && cBoxCOM3.Text != "")
            {
                try
                {
                    serialPort_com3.DataReceived += new SerialDataReceivedEventHandler(serialPort_com3_DataReceived);
                    serialPort_com3.Open();
                    serialPort_com3.DiscardOutBuffer(); //flush buffer
                    if (serialPort_com3.IsOpen == true)
                    {
                        labelDevice3.BackColor = Color.Orange;
                        Com3connected = true;
                    }
                    else
                    {
                        labelDevice3.BackColor = Color.Red;
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (Com4connected == false && cBoxCOM4.Text != "")
            {
                try
                {
                    serialPort_com4.DataReceived += new SerialDataReceivedEventHandler(serialPort_com4_DataReceived);
                    serialPort_com4.Open();
                    serialPort_com4.DiscardOutBuffer(); //flush buffer
                    if (serialPort_com4.IsOpen == true)
                    {
                        labelDevice4.BackColor = Color.Orange;
                        Com4connected = true;
                    }
                    else
                    {
                        labelDevice4.BackColor = Color.Red;
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            if (Com5connected == false && cBoxCOM5.Text != "")
            {
                try
                {
                    serialPort_com5.DataReceived += new SerialDataReceivedEventHandler(serialPort_com5_DataReceived);
                    serialPort_com5.Open();
                    serialPort_com5.DiscardOutBuffer(); //flush buffer
                    if (serialPort_com5.IsOpen == true)
                    {
                        labelDevice5.BackColor = Color.Orange;
                        Com5connected = true;
                    }
                    else
                    {
                        labelDevice5.BackColor = Color.Red;
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            if (serialPort_com1.IsOpen && serialPort_com2.IsOpen && serialPort_com3.IsOpen && serialPort_com4.IsOpen && serialPort_com5.IsOpen)
            {
                btnConnect.Visible = false;
                btnDisconnect.Visible = true;
                btnReset.Enabled = true;
            }

            ////RECONNECTING
            if (reconnected == true)
            {
                if (serialPort_com1.IsOpen)
                {
                    try
                    {
                        serialPort_com1.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                        SYSmsg1 = "DEVICE 1 CONNECTED";
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (serialPort_com2.IsOpen)
                {
                    try
                    {
                        serialPort_com2.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                        SYSmsg2 = "DEVICE 2 CONNECTED";
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (serialPort_com3.IsOpen)
                {
                    try
                    {
                        serialPort_com3.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                        SYSmsg3 = "DEVICE 3 CONNECTED";
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (serialPort_com4.IsOpen)
                {
                    try
                    {
                        serialPort_com4.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                        SYSmsg4 = "DEVICE 4 CONNECTED";
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (serialPort_com5.IsOpen)
                {
                    try
                    {
                        serialPort_com5.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                        SYSmsg5 = "DEVICE 5 CONNECTED";
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //if (ResetCom1 == false && ResetCom2 == false)// && ResetCom3 == false && ResetCom4 == false && ResetCom5 == false)
                //{
                //    btnReset.Enabled = true;
                //}
            }
            SetTimer();
            reconnected = false;
        }

        private void serialPort_com1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytestoreadCom1 = 0;
            try
            {
                bytestoreadCom1 = serialPort_com1.BytesToRead;
            }
            catch (InvalidOperationException err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (serialPort_com1.IsOpen)
            {
                labelDevice1.BackColor = Color.LightGreen;
                try
                {
                    buffer1 = serialPort_com1.ReadExisting();
                }
                catch
                {

                }


                if (lastMsg1 != "")
                {
                    buffer1 = lastMsg1 + buffer1;
                }
                string[] split = buffer1.Split(new Char[] { '\n' });
                foreach (string s1 in split)
                {
                bool showvalue=false;
                if (s1.Trim() != "")
                {
                    buffer1_short = s1;
                    lastMsg1 = s1;
                }
                else
                {
                    lastMsg1 = "";
                }
                if (buffer1_short.Contains("FTM Ready") && started1 == false)
                {
                    AutoStart1 = false;
                    serialPort_com1.WriteLine("FTM Alive\n");
                    started1 = true;
                    buffer1_short = string.Empty;
                    serialPort_com1.DiscardOutBuffer();
                    buffer1 = string.Empty;
                    return;
                }
                else if (buffer1_short.Contains("FTM Ready") && started1 == true && complete1 == false)
                    {
                    serialPort_com1.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                    complete1 = true;
                    SYSmsg1 = "DEVICE 1 CONNECTED";
                    buffer1_short = string.Empty;
                    serialPort_com1.DiscardOutBuffer();
                    buffer1 = string.Empty;
                    return;
                    }
                    //if (started1 == true && complete1 == false && reconnected == false)
                    //{
                    //    serialPort_com1.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                    //    complete1 = true;
                    //    SYSmsg1 = "DEVICE 1 CONNECTED";
                    //}
                    //else if ((buffer1_short.Contains("Cancel and join thread") || buffer1_short.Contains("No HFLF running")) && (StartCom1 == true && AutoStart1 == true))
                    //{
                    //    serialPort_com1.WriteLine("HFLFSpyStop\nLCM Backlight on\nHFLFSpyStart\nLCM Backlight off\n");
                    //    SYSmsg1 = "DEVICE 1 CONNECTED";
                    //    ResetCom1 = false;
                    //    AutoStart1 = false;
                    //}
                    //else if ((buffer1_short.Contains("Cancel and join thread") || buffer1_short.Contains("No HFLF running")) && ResetCom1 == true && complete1 == false)
                    //{
                    //    serialPort_com1.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                    //    SYSmsg1 = "DEVICE 1 TIME RESET";
                    //    ResetCom1 = false;
                    //    AutoStart1 = false;
                    //}
                    else if ((buffer1_short.Contains("Cancel and join thread") || buffer1_short.Contains("No HFLF running")) && AutoStart1 == true && complete1 == false)
                    {
                        serialPort_com1.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                        SYSmsg1 = "DEVICE 1 AUTOSTART";
                        ResetCom1 = false;
                        AutoStart1 = false;
                    }
                    else if (buffer1_short.Contains("Cancel and join thread") && StopCom1 == true)
                {
                    serialPort_com1.Close();
                    labelDevice1.BackColor = Color.Red;
                    SYSmsg1 = "DEVICE 1 DISCONNECTED";
                    buffer1_short = string.Empty;
                    StopCom1 = false;
                }
                if (buffer1_short.Length > 2)
                {
                    string latestChars = buffer1_short.Substring(buffer1_short.Length - 1);
                    if (latestChars == "\r")
                    {
                        showvalue = true;
                        lastMsg1 = "";
                    }
                    else { showvalue = false; }
                }
                    buffer1_short.TrimStart('\r', '\n');
                    buffer1_short = Regex.Replace(buffer1_short, "[@,\r,\n]", string.Empty);
                    buffer1_short.Trim();
                if (buffer1_short != "" && showvalue == true)
                {
                    string message_check1 = buffer1_short.Substring(0, 1);
                    if (message_check1 == "0" || message_check1 == "1" || message_check1 == "2" || message_check1 == "3" || message_check1 == "4") // zpravy
                    {
                        try
                        {
                        string int_time1 = buffer1_short.Substring(6, 2);
                        string int_time2 = buffer1_short.Substring(3, 2);
                        string int_time0 = int_time1 + int_time2;
                        int int_time = Convert.ToInt32(int_time0, 16) * 10;
                        IntTime1 = int_time.ToString().PadLeft(10);
                        }
                        catch
                        {
                        }
                    }
                    else { IntTime1 = "0"; }
                    labelDevice1.BackColor = Color.LightGreen;
                    if (message_check1 == "0" || message_check1 == "1" || message_check1 == "2" || message_check1 == "3" || message_check1 == "4") // zpravy
                    {
                        bufferall_short += "1=" + buffer1_short + "\n";
                    }
                    DataOutFile1 = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime1 + "  ms  \t" + buffer1_short + "\n";
                    DataOut1 = buffer1_short;
                    writed1 = false;
                    StartCom1 = false;
                    //AutoStart1 = false;
                    Com1 = true;
                    color = "cf1";
                }
                //if (SYSmsg1 != string.Empty)
                //{
                //    bufferall_short += SYSmsg1;
                //}
                if (buffer1_short != "" || SYSmsg1 != "")
                {
                    this.Invoke(new EventHandler(ShowData));
                    buffer1_short = string.Empty;
                    SYSmsg1 = string.Empty;
                }
                }
                buffer1 = string.Empty;
            }
            else
            {
                return;
            }
        }

        private void serialPort_com2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytestoreadCom2 = 0;
            try
            {
                bytestoreadCom2 = serialPort_com2.BytesToRead;
            }
            catch (InvalidOperationException err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (serialPort_com2.IsOpen)
            {
                labelDevice2.BackColor = Color.LightGreen;
                try
                {
                    buffer2 += serialPort_com2.ReadExisting();
                }
                catch { }
                if (lastMsg2 != "")
                {
                    buffer2 = lastMsg2 + buffer2;
                }
                string[] split = buffer2.Split(new Char[] { '\n' });
                foreach (string s2 in split)
                {
                    bool showvalue = false;
                    if (s2.Trim() != "")
                    {
                        buffer2_short = s2;
                        lastMsg2 = s2;
                    }
                    else
                    {
                        lastMsg2 = "";
                    }
                    if (buffer2_short.Contains("FTM Ready") && started2 == false)
                    {
                        AutoStart2 = false;
                        serialPort_com2.WriteLine("FTM Alive\n");
                        started2 = true;
                        buffer2_short = string.Empty;
                        serialPort_com2.DiscardOutBuffer();
                        buffer2 = string.Empty;
                        return;
                    }
                    else if (buffer2_short.Contains("FTM Ready") && started2 == true && complete2 == false)
                    {
                        serialPort_com2.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                        complete2 = true;
                        SYSmsg2 = "DEVICE 2 CONNECTED";
                        buffer2_short = string.Empty;
                        serialPort_com2.DiscardOutBuffer();
                        buffer2 = string.Empty;
                        return;
                    }
                    //if (started2 == true && complete2 == false && reconnected == false)
                    //{
                    //    serialPort_com2.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                    //    complete2 = true;
                    //    SYSmsg2 = "DEVICE 2 CONNECTED";
                    //}
                    //else if ((buffer2_short.Contains("Cancel and join thread") || buffer2_short.Contains("No HFLF running")) && (StartCom2 == true && AutoStart2 == true))
                    //{
                    //    serialPort_com2.WriteLine("HFLFSpyStop\nLCM Backlight on\nHFLFSpyStart\nLCM Backlight off\n");
                    //    SYSmsg2 = "DEVICE 2 CONNECTED";
                    //    ResetCom2 = false;
                    //    AutoStart2 = false;
                    //}
                    //else if ((buffer2_short.Contains("Cancel and join thread") || buffer2_short.Contains("No HFLF running")) && ResetCom2 == true && complete2 == false)
                    //{
                    //    serialPort_com2.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                    //    SYSmsg2 = "DEVICE 2 TIME RESET";
                    //    ResetCom2 = false;
                    //    AutoStart2 = false;
                    //}
                    else if ((buffer2_short.Contains("Cancel and join thread") || buffer2_short.Contains("No HFLF running")) && AutoStart2 == true && complete2 == false)
                    {
                        serialPort_com2.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                        SYSmsg2 = "DEVICE 2 AUTOSTART";
                        ResetCom2 = false;
                        AutoStart2 = false;
                    }
                    else if (buffer2_short.Contains("Cancel and join thread") && StopCom2 == true)
                    {
                        serialPort_com2.Close();
                        labelDevice2.BackColor = Color.Red;
                        SYSmsg2 = "DEVICE 2 DISCONNECTED";
                        buffer2_short = string.Empty;
                        StopCom2 = false;
                    }
                    if (buffer2_short.Length > 2)
                    {
                        string latestChars = buffer2_short.Substring(buffer2_short.Length - 1);
                        if (latestChars == "\r")
                        {
                            showvalue = true;
                            lastMsg2 = "";
                        }
                        else { showvalue = false; }
                    }
                    buffer2_short.TrimStart('\r', '\n');
                    buffer2_short = Regex.Replace(buffer2_short, "[@,\r,\n]", string.Empty);
                    buffer2_short.Trim();
                    if (buffer2_short != "" && showvalue == true)
                    {
                        string message_check2 = buffer2_short.Substring(0, 1);
                        if (message_check2 == "0" || message_check2 == "1" || message_check2 == "2" || message_check2 == "3" || message_check2 == "4") // zpravy
                        {
                            try
                            {
                                string int_time1 = buffer2_short.Substring(6, 2);
                                string int_time2 = buffer2_short.Substring(3, 2);
                                string int_time0 = int_time1 + int_time2;
                                int int_time = Convert.ToInt32(int_time0, 16) * 10;
                                IntTime2 = int_time.ToString().PadLeft(10);
                            }
                            catch
                            {
                            }
                        }
                        else { IntTime2 = "0"; }
                        labelDevice2.BackColor = Color.LightGreen;
                        if (message_check2 == "0" || message_check2 == "1" || message_check2 == "2" || message_check2 == "3" || message_check2 == "4") // zpravy
                        {
                            bufferall_short += "2=" + buffer2_short + "\n";
                        }
                        DataOutFile2 = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime2 + "  ms  \t" + buffer2_short + "\n";
                        DataOut2 = buffer2_short;
                        writed2 = false;
                        StartCom2 = false;
                        //AutoStart2 = false;
                        Com2 = true;
                        color = "cf2";
                    }
                    //if (SYSmsg2 != string.Empty)
                    //{
                    //    bufferall_short += SYSmsg2;
                    //}
                    if (buffer2_short != "" || SYSmsg2 != "")
                    {
                        this.Invoke(new EventHandler(ShowData));
                        buffer2_short = string.Empty;
                        SYSmsg2 = string.Empty;
                    }
                }
                buffer2 = string.Empty;
            }
            else
            {
                return;
            }
        }

        private void serialPort_com3_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytestoreadCom3 = 0;
            try
            {
                bytestoreadCom3 = serialPort_com3.BytesToRead;
            }
            catch (InvalidOperationException err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (serialPort_com3.IsOpen)
            {
                labelDevice3.BackColor = Color.LightGreen;
                try
                {
                    buffer3 += serialPort_com3.ReadExisting();
                }
                catch { }
                if (lastMsg3 != "")
                {
                    buffer3 = lastMsg3 + buffer3;
                }
                string[] split = buffer3.Split(new Char[] { '\n' });
                foreach (string s3 in split)
                {
                    bool showvalue = false;
                    if (s3.Trim() != "")
                    {
                        buffer3_short = s3;
                        lastMsg3 = s3;
                    }
                    else
                    {
                        lastMsg3 = "";
                    }
                    if (buffer3_short.Contains("FTM Ready") && started3 == false)
                    {
                        AutoStart3 = false;
                        serialPort_com3.WriteLine("FTM Alive\n");
                        started3 = true;
                        buffer3_short = string.Empty;
                        serialPort_com3.DiscardOutBuffer();
                        buffer3 = string.Empty;
                        return;
                    }
                    else if (buffer3_short.Contains("FTM Ready") && started3 == true && complete3 == false)
                    {
                        serialPort_com3.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                        complete3 = true;
                        SYSmsg3 = "DEVICE 3 CONNECTED";
                        buffer3_short = string.Empty;
                        serialPort_com3.DiscardOutBuffer();
                        buffer3 = string.Empty;
                        return;
                    }
                    //if (started3 == true && complete3 == false && reconnected == false)
                    //{
                    //    serialPort_com3.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                    //    complete3 = true;
                    //    SYSmsg3 = "DEVICE 3 CONNECTED";
                    //}
                    //else if ((buffer3_short.Contains("Cancel and join thread") || buffer3_short.Contains("No HFLF running")) && (StartCom3 == true && AutoStart3 == true))
                    //{
                    //    serialPort_com3.WriteLine("HFLFSpyStop\nLCM Backlight on\nHFLFSpyStart\nLCM Backlight off\n");
                    //    SYSmsg3 = "DEVICE 3 CONNECTED";
                    //    ResetCom3 = false;
                    //    AutoStart3 = false;
                    //}
                    //else if ((buffer3_short.Contains("Cancel and join thread") || buffer3_short.Contains("No HFLF running")) && ResetCom3 == true && complete3 == false)
                    //{
                    //    serialPort_com3.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                    //    SYSmsg3 = "DEVICE 3 TIME RESET";
                    //    ResetCom3 = false;
                    //    AutoStart3 = false;
                    //}
                    else if ((buffer3_short.Contains("Cancel and join thread") || buffer3_short.Contains("No HFLF running")) && AutoStart3 == true && complete3 == false)
                    {
                        serialPort_com3.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                        SYSmsg3 = "DEVICE 3 AUTOSTART";
                        ResetCom3 = false;
                        AutoStart3 = false;
                    }
                    else if (buffer3_short.Contains("Cancel and join thread") && StopCom3 == true)
                    {
                        serialPort_com3.Close();
                        labelDevice3.BackColor = Color.Red;
                        SYSmsg3 = "DEVICE 3 DISCONNECTED";
                        buffer3_short = string.Empty;
                        StopCom3 = false;
                    }
                    if (buffer3_short.Length > 2)
                    {
                        string latestChars = buffer3_short.Substring(buffer3_short.Length - 1);
                        if (latestChars == "\r")
                        {
                            showvalue = true;
                            lastMsg3 = "";
                        }
                        else { showvalue = false; }
                    }
                    buffer3_short.TrimStart('\r', '\n');
                    buffer3_short = Regex.Replace(buffer3_short, "[@,\r,\n]", string.Empty);
                    buffer3_short.Trim();
                    if (buffer3_short != "" && showvalue == true)
                    {
                        string message_check3 = buffer3_short.Substring(0, 1);
                        if (message_check3 == "0" || message_check3 == "1" || message_check3 == "2" || message_check3 == "3" || message_check3 == "4") // zpravy
                        {
                            try
                            {
                                string int_time1 = buffer3_short.Substring(6, 2);
                                string int_time2 = buffer3_short.Substring(3, 2);
                                string int_time0 = int_time1 + int_time2;
                                int int_time = Convert.ToInt32(int_time0, 16) * 10;
                                IntTime3 = int_time.ToString().PadLeft(10);
                            }
                            catch
                            {
                            }
                        }
                        else { IntTime3 = "0"; }
                        labelDevice3.BackColor = Color.LightGreen;
                        if (message_check3 == "0" || message_check3 == "1" || message_check3 == "2" || message_check3 == "3" || message_check3 == "4") // zpravy
                        {
                            bufferall_short += "3=" + buffer3_short + "\n";
                        }
                        DataOutFile3 = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime3 + "  ms  \t" + buffer3_short + "\n";
                        DataOut3 = buffer3_short;
                        writed3 = false;
                        StartCom3 = false;
                        //AutoStart3 = false;
                        Com3 = true;
                        color = "cf3";
                    }
                    //if (SYSmsg3 != string.Empty)
                    //{
                    //    bufferall_short += SYSmsg3;
                    //}
                    if (buffer3_short != "" || SYSmsg3 != "")
                    {
                        this.Invoke(new EventHandler(ShowData));
                        buffer3_short = string.Empty;
                        SYSmsg3 = string.Empty;
                    }
                }
                buffer3 = string.Empty;
            }
            else
            {
                return;
            }
        }

        private void serialPort_com4_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytestoreadCom4 = 0;
            try
            {
                bytestoreadCom4 = serialPort_com4.BytesToRead;
            }
            catch (InvalidOperationException err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (serialPort_com4.IsOpen)
            {
                labelDevice4.BackColor = Color.LightGreen;
                try
                {
                    buffer4 += serialPort_com4.ReadExisting();
                }
                catch { }
                if (lastMsg4 != "")
                {
                    buffer4 = lastMsg4 + buffer4;
                }
                string[] split = buffer4.Split(new Char[] { '\n' });
                foreach (string s4 in split)
                {
                    bool showvalue = false;
                    if (s4.Trim() != "")
                    {
                        buffer4_short = s4;
                        lastMsg4 = s4;
                    }
                    else
                    {
                        lastMsg4 = "";
                    }
                    if (buffer4_short.Contains("FTM Ready") && started4 == false)
                    {
                        AutoStart4 = false;
                        serialPort_com4.WriteLine("FTM Alive\n");
                        started4 = true;
                        buffer4_short = string.Empty;
                        serialPort_com4.DiscardOutBuffer();
                        buffer4 = string.Empty;
                        return;
                    }
                    else if (buffer4_short.Contains("FTM Ready") && started4 == true && complete4 == false)
                    {
                        serialPort_com4.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                        complete4 = true;
                        SYSmsg4 = "DEVICE 4 CONNECTED";
                        buffer4_short = string.Empty;
                        serialPort_com4.DiscardOutBuffer();
                        buffer4 = string.Empty;
                        return;
                    }
                    //if (started4 == true && complete4 == false && reconnected == false)
                    //{
                    //    serialPort_com4.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                    //    complete4 = true;
                    //    SYSmsg4 = "DEVICE 4 CONNECTED";
                    //}
                    //else if ((buffer4_short.Contains("Cancel and join thread") || buffer4_short.Contains("No HFLF running")) && (StartCom4 == true && AutoStart4 == true))
                    //{
                    //    serialPort_com4.WriteLine("HFLFSpyStop\nLCM Backlight on\nHFLFSpyStart\nLCM Backlight off\n");
                    //    SYSmsg4 = "DEVICE 4 CONNECTED";
                    //    ResetCom4 = false;
                    //    AutoStart4 = false;
                    //}
                    //else if ((buffer4_short.Contains("Cancel and join thread") || buffer4_short.Contains("No HFLF running")) && ResetCom4 == true && complete4 == false)
                    //{
                    //    serialPort_com4.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                    //    SYSmsg4 = "DEVICE 4 TIME RESET";
                    //    ResetCom4 = false;
                    //    AutoStart4 = false;
                    //}
                    else if ((buffer4_short.Contains("Cancel and join thread") || buffer4_short.Contains("No HFLF running")) && AutoStart4 == true && complete4 == false)
                    {
                        serialPort_com4.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                        SYSmsg4 = "DEVICE 4 AUTOSTART";
                        ResetCom4 = false;
                        AutoStart4 = false;
                    }
                    else if (buffer4_short.Contains("Cancel and join thread") && StopCom4 == true)
                    {
                        serialPort_com4.Close();
                        labelDevice4.BackColor = Color.Red;
                        SYSmsg4 = "DEVICE 4 DISCONNECTED";
                        buffer4_short = string.Empty;
                        StopCom4 = false;
                    }
                    if (buffer4_short.Length > 2)
                    {
                        string latestChars = buffer4_short.Substring(buffer4_short.Length - 1);
                        if (latestChars == "\r")
                        {
                            showvalue = true;
                            lastMsg4 = "";
                        }
                        else { showvalue = false; }
                    }
                    buffer4_short.TrimStart('\r', '\n');
                    buffer4_short = Regex.Replace(buffer4_short, "[@,\r,\n]", string.Empty);
                    buffer4_short.Trim();
                    if (buffer4_short != "" && showvalue == true)
                    {
                        string message_check4 = buffer4_short.Substring(0, 1);
                        if (message_check4 == "0" || message_check4 == "1" || message_check4 == "2" || message_check4 == "3" || message_check4 == "4") // zpravy
                        {
                            try
                            {
                                string int_time1 = buffer4_short.Substring(6, 2);
                                string int_time2 = buffer4_short.Substring(3, 2);
                                string int_time0 = int_time1 + int_time2;
                                int int_time = Convert.ToInt32(int_time0, 16) * 10;
                                IntTime4 = int_time.ToString().PadLeft(10);
                            }
                            catch
                            {
                            }
                        }
                        else { IntTime4 = "0"; }
                        labelDevice4.BackColor = Color.LightGreen;
                        if (message_check4 == "0" || message_check4 == "1" || message_check4 == "2" || message_check4 == "3" || message_check4 == "4") // zpravy
                        {
                            bufferall_short += "4=" + buffer4_short + "\n";
                        }
                        DataOutFile4 = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime4 + "  ms  \t" + buffer4_short + "\n";
                        DataOut4 = buffer4_short;
                        writed4 = false;
                        StartCom4 = false;
                        //AutoStart4 = false;
                        Com4 = true;
                        color = "cf4";
                    }
                    //if (SYSmsg4 != string.Empty)
                    //{
                    //    bufferall_short += SYSmsg4;
                    //}
                    if (buffer4_short != "" || SYSmsg4 != "")
                    {
                        this.Invoke(new EventHandler(ShowData));
                        buffer4_short = string.Empty;
                        SYSmsg4 = string.Empty;
                    }
                }
                buffer4 = string.Empty;
            }
            else
            {
                return;
            }
        }

        private void serialPort_com5_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytestoreadCom5 = 0;
            try
            {
                bytestoreadCom5 = serialPort_com5.BytesToRead;
            }
            catch (InvalidOperationException err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (serialPort_com5.IsOpen)
            {
                labelDevice5.BackColor = Color.LightGreen;
                try
                {
                    buffer5 += serialPort_com5.ReadExisting();
                }
                catch { }
                if (lastMsg5 != "")
                {
                    buffer5 = lastMsg5 + buffer5;
                }
                string[] split = buffer5.Split(new Char[] { '\n' });
                foreach (string s5 in split)
                {
                    bool showvalue = false;
                    if (s5.Trim() != "")
                    {
                        buffer5_short = s5;
                        lastMsg5 = s5;
                    }
                    else
                    {
                        lastMsg5 = "";
                    }
                    if (buffer5_short.Contains("FTM Ready") && started5 == false)
                    {
                        AutoStart5 = false;
                        serialPort_com5.WriteLine("FTM Alive\n");
                        started5 = true;
                        buffer5_short = string.Empty;
                        serialPort_com5.DiscardOutBuffer();
                        buffer5 = string.Empty;
                        return;
                    }
                    else if (buffer5_short.Contains("FTM Ready") && started5 == true && complete5 == false)
                    {
                        serialPort_com5.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                        complete5 = true;
                        SYSmsg5 = "DEVICE 5 CONNECTED";
                        buffer5_short = string.Empty;
                        serialPort_com5.DiscardOutBuffer();
                        buffer5 = string.Empty;
                        return;
                    }
                    //if (started5 == true && complete5 == false && reconnected == false)
                    //{
                    //    serialPort_com5.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                    //    complete5 = true;
                    //    SYSmsg5 = "DEVICE 5 CONNECTED";
                    //}
                    //else if ((buffer5_short.Contains("Cancel and join thread") || buffer5_short.Contains("No HFLF running")) && (StartCom5 == true && AutoStart5 == true))
                    //{
                    //    serialPort_com5.WriteLine("HFLFSpyStop\nLCM Backlight on\nHFLFSpyStart\nLCM Backlight off\n");
                    //    SYSmsg5 = "DEVICE 5 CONNECTED";
                    //    ResetCom5 = false;
                    //    AutoStart5 = false;
                    //}
                    //else if ((buffer5_short.Contains("Cancel and join thread") || buffer5_short.Contains("No HFLF running")) && ResetCom5 == true && complete5 == false)
                    //{
                    //    serialPort_com5.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                    //    SYSmsg5 = "DEVICE 5 TIME RESET";
                    //    ResetCom5 = false;
                    //    AutoStart5 = false;
                    //}
                    else if ((buffer5_short.Contains("Cancel and join thread") || buffer5_short.Contains("No HFLF running")) && AutoStart5 == true && complete5 == false)
                    {
                        serialPort_com5.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                        SYSmsg5 = "DEVICE 5 AUTOSTART";
                        ResetCom5 = false;
                        AutoStart5 = false;
                    }
                    else if (buffer5_short.Contains("Cancel and join thread") && StopCom5 == true)
                    {
                        serialPort_com5.Close();
                        labelDevice5.BackColor = Color.Red;
                        SYSmsg5 = "DEVICE 5 DISCONNECTED";
                        buffer5_short = string.Empty;
                        StopCom5 = false;
                    }
                    if (buffer5_short.Length > 2)
                    {
                        string latestChars = buffer5_short.Substring(buffer5_short.Length - 1);
                        if (latestChars == "\r")
                        {
                            showvalue = true;
                            lastMsg5 = "";
                        }
                        else { showvalue = false; }
                    }
                    buffer5_short.TrimStart('\r', '\n');
                    buffer5_short = Regex.Replace(buffer5_short, "[@,\r,\n]", string.Empty);
                    buffer5_short.Trim();
                    if (buffer5_short != "" && showvalue == true)
                    {
                        string message_check5 = buffer5_short.Substring(0, 1);
                        if (message_check5 == "0" || message_check5 == "1" || message_check5 == "2" || message_check5 == "3" || message_check5 == "4") // zpravy
                        {
                            try
                            {
                                string int_time1 = buffer5_short.Substring(6, 2);
                                string int_time2 = buffer5_short.Substring(3, 2);
                                string int_time0 = int_time1 + int_time2;
                                int int_time = Convert.ToInt32(int_time0, 16) * 10;
                                IntTime5 = int_time.ToString().PadLeft(10);
                            }
                            catch
                            {
                            }
                        }
                        else { IntTime5 = "0"; }
                        labelDevice5.BackColor = Color.LightGreen;
                        if (message_check5 == "0" || message_check5 == "1" || message_check5 == "2" || message_check5 == "3" || message_check5 == "4") // zpravy
                        {
                            bufferall_short += "5=" + buffer5_short + "\n";
                        }
                        DataOutFile5 = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime5 + "  ms  \t" + buffer5_short + "\n";
                        DataOut5 = buffer5_short;
                        writed5 = false;
                        StartCom5 = false;
                        //AutoStart5 = false;
                        Com5 = true;
                        color = "cf5";
                    }
                    //if (SYSmsg5 != string.Empty)
                    //{
                    //    bufferall_short += SYSmsg5;
                    //}
                    if (buffer5_short != "" || SYSmsg5 != "")
                    {
                        this.Invoke(new EventHandler(ShowData));
                        buffer5_short = string.Empty;
                        SYSmsg5 = string.Empty;
                    }
                }
                buffer5 = string.Empty;
            }
            else
            {
                return;
            }
        }

        private void ShowData(object sender, EventArgs e)
        {
            // bool ch1key_car = false;
            //bool ch2key_car = false;
            // bool ch1car_key = false;
            // bool ch2car_key = false;
            // bool lfcar_key = false;
            // bool br8kbit = false;
            //  bool br19kbit = false;
            //  bool br2kbit = false;
            int int_time = 0;
            bool textmessage = true;

            if (bufferall_short.Length > 3)//VZW: size of string buffer has to be lager as 9 characters, oterwise exeption will be thrown VZW -
            {

                string[] split = bufferall_short.Split(new Char[] { '\n' });
                foreach (string s1 in split)
                {
                    color = "cf" + bufferall_short.Substring(0, 1);
                    if (s1.Trim() != "")
                    {
                string shortMSG = s1.Substring(2, s1.Length - 2);
                shortMSG.TrimStart('\n');
                string channel_check = shortMSG.Substring(0, 1);
                string bautrate_check = shortMSG.Substring(1, 1);
                int bufferlength = shortMSG.Length - 9;
                if (channel_check == "0" || channel_check == "1" || channel_check == "2" || channel_check == "3" || channel_check == "4") // zpravy
                {
                    string int_time1 = shortMSG.Substring(6, 2);
                    string int_time2 = shortMSG.Substring(3, 2);
                    string int_time0 = int_time1 + int_time2;
                    //string int_time0 = "0";
                    int_time = Convert.ToInt32(int_time0, 16) * 10;
                    IntTime = int_time.ToString().PadLeft(10);
                    textmessage = false;
                    shortmessage = shortMSG.Substring(9, bufferlength);
                    com_type = shortMSG.Substring(0, 2).PadLeft(2);
                    timemessage = shortMSG.Substring(3, 5).PadLeft(5);

                    byte[] rxArr = new byte[100];
                    for (int i = 0; i < 100; i++) rxArr[i] = 0;  //fill with nulls
                    Interpreter msg = new Interpreter();

                    switch (msg.MsgInterpreter(int_time, shortMSG, rxArr))  //Write interpretation of the message
                    {
                        case Interpreter.MsgType.RKE_challReq:
                            DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " -> RKE Challange Request" + "   \tID " + Interpreter.lastRKEChallReq.keyID.ToString("X4") + " \tWUP = 0x" + Interpreter.lastRKEChallReq.carWUP.ToString("X4") + " \tFC = 0x" + Interpreter.lastRKEChallReq.fc.ToString("X") + " \tbutton is " + msg.InterpretButton(Interpreter.lastRKEChallReq.button) + @"\line";
                            break;
                        case Interpreter.MsgType.SleepReq:
                            DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " ->  Sleep Request" + "   \tID " + Interpreter.lastRKEChallReq.keyID.ToString("X4") + " \tWUP = 0x" + Interpreter.lastRKEChallReq.carWUP.ToString("X4") + @"\line";
                            break;
                        case Interpreter.MsgType.GoToSleep:
                            DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " ->  Go to sleep" + "   \tID " + Interpreter.lastRKEChallReq.keyID.ToString("X4") + " \tWUP = 0x" + Interpreter.lastRKEChallReq.carWUP.ToString("X4") + @"\line";
                            break;
                        case Interpreter.MsgType.RKE_Res:
                            if (Interpreter.lastRKERes.lfPing)
                            {
                                DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " -> RKE Response" + "   \tID " + Interpreter.lastRKERes.keyID.ToString("X4") + " \tFC = 0x" + Interpreter.lastRKERes.fc.ToString("X") + " \tbutton " + msg.InterpretButton(Interpreter.lastRKERes.button) + " \tLF Ping value " + Interpreter.lastRKERes.lfPingValue.ToString("X") + @"\line";
                            }
                            else
                            {
                                DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " -> RKE Response" + "   \tID " + Interpreter.lastRKERes.keyID.ToString("X4") + " \tFC = 0x" + Interpreter.lastRKERes.fc.ToString("X") + " \tbutton " + msg.InterpretButton(Interpreter.lastRKERes.button) + @"\line";
                            }
                            break;
                        case Interpreter.MsgType.RCP_Res:
                            if (Interpreter.lastRCPRes.lfPingState != 0)
                            {
                                DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " -> RCP Response" + "   \tID " + Interpreter.lastRKERes.keyID.ToString("X4") + " \tFC = 0x" + Interpreter.lastRKERes.fc.ToString("X") + " \tbutton " + msg.InterpretButton(Interpreter.lastRKERes.button) + @"\line";
                            }
                            else
                            {
                                DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " -> RCP Response" + "   \tID " + Interpreter.lastRKERes.keyID.ToString("X4") + " \tFC = 0x" + Interpreter.lastRKERes.fc.ToString("X") + " \tbutton " + msg.InterpretButton(Interpreter.lastRKERes.button) + " \tLF Ping value " + Interpreter.lastRKERes.lfPingValue.ToString("X2") + @"\line";
                            }

                            break;
                        case Interpreter.MsgType.RKE_chall:
                            DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " -> RKE Acknowlege & Challenge" + "   \t two bytes of ID =0x" + Interpreter.lastRKEChall.halfID.ToString("X2") + " \tFC = 0x" + Interpreter.lastRKEChall.fc.ToString("X") + @"\line";
                            break;
                        case Interpreter.MsgType.CACG_AC:
                            DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " -> Anti-collision CRC4 OK with FC 0x" + Interpreter.lastAC.fc.ToString("X") + "   \tID " + Interpreter.lastAC.keyID.ToString("X4") + @"\line";
                            break;

                        case Interpreter.MsgType.CACG_Chall:
                            DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " -> CACG Challange for key ID: " + Interpreter.lastCaChall.keyID.ToString("X4") + @"\line";
                            break;
                        case Interpreter.MsgType.CACG_Res:
                            if (Interpreter.lastCaRes.amtHFM > 0)
                            {
                                DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " -> CACG Response with RSSI:" + @"\line";
                                for (int i = 0; i < Interpreter.lastCaRes.amtHFM; i++)
                                {
                                    DisplayData += @"\" + " Antenna" + (i + 1).ToString() + ":  " + Interpreter.lastCaRes.dRssi[i, 3].ToString("{#000.0}") + " nT \t X: " + Interpreter.lastCaRes.dRssi[i, 0].ToString("{##00.0}") + "    Y: " + Interpreter.lastCaRes.dRssi[i, 1].ToString("{##00.0}") + "    Z: " + Interpreter.lastCaRes.dRssi[i, 2].ToString("{##00.0}") + @"\line";
                                }
                                DisplayData += @"\line";
                            }
                            else
                            {
                                DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " -> CACG Response without HFM measurement" + @"\line";
                            }

                            break;
                        case Interpreter.MsgType.KI_Req1:
                            DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + "\t\t\t-> Key Info Request first part " + @"\line";
                            break;
                        case Interpreter.MsgType.KI_Req:
                            DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " \t -> Key Info Request   \"" + Interpreter.lastKiReq.getKiType() + "\"  ID " + Interpreter.lastKiReq.keyID.ToString("X4") + @"\line";
                            break;
                        case Interpreter.MsgType.KI_Stat1:
                            DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " \t -> Key Info Status1 " + Interpreter.lastKiStat1.getKiType() + @"\line";
                            break;
                        case Interpreter.MsgType.KI_Stat2:
                            DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " \t -> Key Info Status2   " + Interpreter.lastKiStat2.GetStringStatus() + @"\line";
                            break;
                        case Interpreter.MsgType.THS_ChallReq:
                            DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " -> THS Challenge Request " + "   \tID " + Interpreter.lastTHSChallReq.keyID.ToString("X4") + @"\line";
                            break;
                        case Interpreter.MsgType.THS_Chall:
                            DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " -> THS Challenge " + @"\line";
                            break;
                        case Interpreter.MsgType.THS_Res:
                            if (Interpreter.lastTHSRes.crcPass)
                            {
                                DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " -> THS Response " + @"\line";
                            }
                            else
                            {
                                DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " -> THS Response but not CRC not valid!!!" + @"\line";
                            }
                            break;
                        case Interpreter.MsgType.THS_St1:
                            DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " \t -> THS Status1 " + @"\line";
                            break;
                        case Interpreter.MsgType.THS_St2:
                            DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " \t -> THS Status2 " + @"\line";
                            break;
                        case Interpreter.MsgType.THS_St3:
                            DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " \t -> THS Status3 " + @"\line";
                            break;
                        case Interpreter.MsgType.LF_WUP:
                            if ((Interpreter.lastLfMsg != null) && Interpreter.lastLfMsg.crcCheck)
                            {
                                DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " \t Key Search,  SEQ " + Interpreter.lastLfMsg.seq.ToString() + "  FC " + Interpreter.lastLfMsg.fc.ToString() + "  channel " + Interpreter.lastLfMsg.channel.ToString() + "  anzHFM " + Interpreter.lastLfMsg.anzHFM.ToString() + "  anzAC " + Interpreter.lastLfMsg.anzAC.ToString() + @"\line";
                            }
                            else
                            {
                                DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " \t LF WUP, but CRC4 not valid)" + @"\line";
                            }
                            break;
                        case Interpreter.MsgType.LF_CktControl:
                            DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " \t CKT Control" + " \t SEQ " + Interpreter.lastCktCtr.seq.ToString() + " \t control:" + Interpreter.lastCktCtr.cktCtr_i32.ToString("X4") + @"\line";
                            break;
                        case Interpreter.MsgType.LF_Ping:
                            DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " \t LF Ping" + @"\line";
                            break;
                        case Interpreter.MsgType.LF_WUP_Short:
                            if ((Interpreter.lastLfCkt != null) && (Interpreter.lastLfCkt.crcCheck))
                            {
                                DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " \t CKT,  SEQ " + Interpreter.lastLfCkt.seq.ToString() + "  ZONE " + Interpreter.lastLfCkt.cktZone.ToString() + @"\line";
                            }
                            else
                            {
                                DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + " \t CKT (CRC4 not proved)" + @"\line";
                            }
                            break;
                        default:
                            DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "\t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + @"\line";
                            break;
                    }
                }
                else if (shortMSG != "" && shortMSG != " ") //textove zpravy
                {
                    shortmessage = shortMSG;
                    IntTime = "0".PadLeft(10);
                    com_type = string.Empty;
                    timemessage = string.Empty;
                    keyid_pressed = string.Empty;
                    keyid_released = string.Empty;
                    pressedbutton_check = string.Empty;
                    textmessage = true;
                }

                if (textmessage == false)
                {


                }

                //************************************************************
                else if (color != "" && IntTime != "" && shortmessage != "")
                {
                    DisplayData += @"\" + color + " " + DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff") + "   \t" + IntTime + "  ms\t" + com_type + "\t" + shortmessage + @"\line";
                    //shortmessage = string.Empty;
                }
            }

        }
                }
            else
            {

            }
            if (DisplayData != "")
            {
                //LockWindowUpdate(tBoxDataOut.Handle);
                DisplayDataAll += DisplayData;
                tBoxDataOut.Rtf = @"{\rtf1\ansi\deff0 {\colortbl;\red255\green0\blue0;\red0\green255\blue0;\red0\green0\blue255;\red0\green100\blue100;\red255\green178\blue102;}" + DisplayDataAll + "}";

                if (checkBox_autoscroll.Checked)
                {
                    tBoxDataOut.SelectionLength = 0;
                    tBoxDataOut.SelectionStart = tBoxDataOut.Text.Length;
                    tBoxDataOut.ScrollToCaret();
                    //tBoxDataOut.Focus();
                    //tBoxDataOut.SelectionStart = tBoxDataOut.Text.Length;
                    //tBoxDataOut.SelectionLength = 0;
                    //ActiveControl = tBoxDataOut;
                }
                else
                {
                    tBoxDataOut.SelectionLength = 0;
                }
            }
            bufferall_short = string.Empty;
            DisplayData = string.Empty;
            color = string.Empty;
        
            Com1 = false;
            Com2 = false;
            Com3 = false;
            Com4 = false;
            Com5 = false;

            if (writed1 == false)
            {
                WriteData += DataOutFile1;
                TextWriter logFile = new StreamWriter(LogFileName);
                logFile.WriteLine(WriteData);
                logFile.Close();
                writed1 = true;
            }

            if (writed2 == false)
            {
                WriteData += DataOutFile2;
                TextWriter logFile = new StreamWriter(LogFileName);
                logFile.WriteLine(WriteData);
                logFile.Close();
                writed2 = true;
            }

            if (writed3 == false)
            {
                WriteData += DataOutFile3;
                TextWriter logFile = new StreamWriter(LogFileName);
                logFile.WriteLine(WriteData);
                logFile.Close();
                writed3 = true;
            }

            if (writed4 == false)
            {
                WriteData += DataOutFile4;
                TextWriter logFile = new StreamWriter(LogFileName);
                logFile.WriteLine(WriteData);
                logFile.Close();
                writed4 = true;
            }

            if (writed5 == false)
            {
                WriteData += DataOutFile5;
                TextWriter logFile = new StreamWriter(LogFileName);
                logFile.WriteLine(WriteData);
                logFile.Close();
                writed5 = true;
            }

            if (ResetCom1 == false && ResetCom2 == false && ResetCom3 == false && ResetCom4 == false && ResetCom5 == false)
            {
                btnReset.Enabled = true;
            }

            LockWindowUpdate(IntPtr.Zero);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (serialPort_com1.IsOpen)
            {
                StopCom1 = true;
                try
                {
                    serialPort_com1.WriteLine("HFLFSpyStop\nLCM Backlight on\n");
                    serialPort_com1.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                labelDevice1.BackColor = Color.Red;
                Com1connected = false;
            }
            else
            {
                Com1connected = false;
                StopCom1 = true;
                labelDevice1.BackColor = Color.Red;
            }

            if (serialPort_com2.IsOpen)
            {
                StopCom2 = true;
                try
                {
                    serialPort_com2.WriteLine("HFLFSpyStop\nLCM Backlight on\n");
                    serialPort_com2.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                labelDevice2.BackColor = Color.Red;
                Com2connected = false;
            }
            else
            {
                Com2connected = false;
                StopCom2 = true;
                labelDevice2.BackColor = Color.Red;
            }

            if (serialPort_com3.IsOpen)
            {
                StopCom3 = true;
                try
                {
                    serialPort_com3.WriteLine("HFLFSpyStop\nLCM Backlight on\n");
                    serialPort_com3.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                labelDevice3.BackColor = Color.Red;
                Com3connected = false;
            }
            else
            {
                Com3connected = false;
                StopCom3 = true;
                labelDevice3.BackColor = Color.Red;
            }

            if (serialPort_com4.IsOpen)
            {
                StopCom4 = true;
                try
                {
                    serialPort_com4.WriteLine("HFLFSpyStop\nLCM Backlight on\n");
                    serialPort_com4.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                labelDevice4.BackColor = Color.Red;
                Com4connected = false;
            }
            else
            {
                Com4connected = false;
                StopCom4 = true;
                labelDevice4.BackColor = Color.Red;
            }

            if (serialPort_com5.IsOpen)
            {
                StopCom5 = true;
                try
                {
                    serialPort_com5.WriteLine("HFLFSpyStop\nLCM Backlight on\n");
                    serialPort_com5.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                labelDevice5.BackColor = Color.Red;
                Com5connected = false;
            }
            else
            {
                Com5connected = false;
                StopCom5 = true;
                labelDevice5.BackColor = Color.Red;
            }

            if (StopCom1 == true && StopCom2 == true && StopCom3 == true && StopCom4 == true && StopCom5 == true)
            {
                btnDisconnect.Visible = false;
                btnConnect.Visible = true;
                reconnected = true;
                btnReset.Enabled = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (serialPort_com1.IsOpen)
            {
                    serialPort_com1.WriteLine("HFLFSpyStop\nLCM Backlight on\n");
                    labelDevice1.BackColor = Color.Orange;
                    ResetCom1Timer();
            }

            if (serialPort_com2.IsOpen)
            {
                    serialPort_com2.WriteLine("HFLFSpyStop\nLCM Backlight on\n");
                    labelDevice2.BackColor = Color.Orange;
                    ResetCom2Timer();
            }

            if (serialPort_com3.IsOpen)
            {
                    serialPort_com3.WriteLine("HFLFSpyStop\nLCM Backlight on\n");
                    labelDevice3.BackColor = Color.Orange;
                    ResetCom3Timer();
            }

            if (serialPort_com4.IsOpen)
            {
                    serialPort_com4.WriteLine("HFLFSpyStop\nLCM Backlight on\n");
                    labelDevice4.BackColor = Color.Orange;
                    ResetCom4Timer();
            }

            if (serialPort_com5.IsOpen)
            {
                    serialPort_com5.WriteLine("HFLFSpyStop\nLCM Backlight on\n");
                    labelDevice5.BackColor = Color.Orange;
                    ResetCom5Timer();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cBoxCOM1.Items.Clear();
            foreach (string port in ports)
            {
                cBoxCOM1.Items.Add(port);
            }

            cBoxCOM2.Items.Clear();
            foreach (string port in ports)
            {
                cBoxCOM2.Items.Add(port);
            }

            cBoxCOM3.Items.Clear();
            foreach (string port in ports)
            {
                cBoxCOM3.Items.Add(port);
            }

            cBoxCOM4.Items.Clear();
            foreach (string port in ports)
            {
                cBoxCOM4.Items.Add(port);
            }

            cBoxCOM5.Items.Clear();
            foreach (string port in ports)
            {
                cBoxCOM5.Items.Add(port);
            }
        }

        private void SetTimer()
        {
            TimerCH1Key = new System.Timers.Timer(2000);
            TimerCH1Key.Elapsed += AutoStartCom1;
            TimerCH1Key.AutoReset = false;
            TimerCH1Key.Enabled = true;

            TimerCH1Bdc = new System.Timers.Timer(2000);
            TimerCH1Bdc.Elapsed += AutoStartCom2;
            TimerCH1Bdc.AutoReset = false;
            TimerCH1Bdc.Enabled = true;

            TimerCH2Key = new System.Timers.Timer(2000);
            TimerCH2Key.Elapsed += AutoStartCom3;
            TimerCH2Key.AutoReset = false;
            TimerCH2Key.Enabled = true;

            TimerCH2Bdc = new System.Timers.Timer(2000);
            TimerCH2Bdc.Elapsed += AutoStartCom4;
            TimerCH2Bdc.AutoReset = false;
            TimerCH2Bdc.Enabled = true;

            TimerLF = new System.Timers.Timer(2000);
            TimerLF.Elapsed += AutoStartCom5;
            TimerLF.AutoReset = false;
            TimerLF.Enabled = true;
        }

        private void ResetCom1Timer()
        {
            ResetTimerCom1 = new System.Timers.Timer(2000);
            ResetTimerCom1.Elapsed += AutoResetCom1;
            ResetTimerCom1.AutoReset = false;
            ResetTimerCom1.Enabled = true;
        }
        private void ResetCom2Timer()
        {
            ResetTimerCom2 = new System.Timers.Timer(2000);
            ResetTimerCom2.Elapsed += AutoResetCom2;
            ResetTimerCom2.AutoReset = false;
            ResetTimerCom2.Enabled = true;
        }
        private void ResetCom3Timer()
        {
            ResetTimerCom3 = new System.Timers.Timer(2000);
            ResetTimerCom3.Elapsed += AutoResetCom3;
            ResetTimerCom3.AutoReset = false;
            ResetTimerCom3.Enabled = true;
        }
        private void ResetCom4Timer()
        {
            ResetTimerCom4 = new System.Timers.Timer(2000);
            ResetTimerCom4.Elapsed += AutoResetCom4;
            ResetTimerCom4.AutoReset = false;
            ResetTimerCom4.Enabled = true;
        }
        private void ResetCom5Timer()
        {
            ResetTimerCom5 = new System.Timers.Timer(2000);
            ResetTimerCom5.Elapsed += AutoResetCom5;
            ResetTimerCom5.AutoReset = false;
            ResetTimerCom5.Enabled = true;
        }

        private void AutoStartCom1(Object source, ElapsedEventArgs e)
        {
            if (serialPort_com1.IsOpen && StartCom1 == true && AutoStart1 == true)
            {
                try
                {
                    serialPort_com1.WriteLine("HFLFSpyStop\nLCM Backlight on\n");
                    //buffer1 = string.Empty;
                    complete1 = false;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AutoStartCom2(Object source, ElapsedEventArgs e)
        {
            if (serialPort_com2.IsOpen && StartCom2 == true && AutoStart2 == true)
            {
                try
                {
                    serialPort_com2.WriteLine("HFLFSpyStop\nLCM Backlight on\n");
                    //buffer2 = string.Empty;
                    complete2 = false;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AutoStartCom3(Object source, ElapsedEventArgs e)
        {
            if (serialPort_com3.IsOpen && StartCom3 == true && AutoStart3 == true)
            {
                try
                {
                    serialPort_com3.WriteLine("HFLFSpyStop\nLCM Backlight on\n");
                    //buffer3 = string.Empty;
                    complete3 = false;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AutoStartCom4(Object source, ElapsedEventArgs e)
        {
            if (serialPort_com4.IsOpen && StartCom4 == true && AutoStart4 == true)
            {
                try
                {
                    serialPort_com4.WriteLine("HFLFSpyStop\nLCM Backlight on\n");
                    //buffer4 = string.Empty;
                    complete4 = false;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AutoStartCom5(Object source, ElapsedEventArgs e)
        {
            if (serialPort_com5.IsOpen && StartCom5 == true && AutoStart5 == true)
            {
                try
                {
                    serialPort_com5.WriteLine("HFLFSpyStop\nLCM Backlight on\n");
                    //buffer5 = string.Empty;
                    complete5 = false;
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AutoResetCom1(Object source, ElapsedEventArgs e)
        {
                    serialPort_com1.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                    ResetCom1 = false;
        }
        private void AutoResetCom2(Object source, ElapsedEventArgs e)
        {
                    serialPort_com2.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                    ResetCom2 = false;
        }
        private void AutoResetCom3(Object source, ElapsedEventArgs e)
        {
                    serialPort_com3.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                    ResetCom3 = false;
        }
        private void AutoResetCom4(Object source, ElapsedEventArgs e)
        {
                    serialPort_com4.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                    ResetCom4 = false;
        }
        private void AutoResetCom5(Object source, ElapsedEventArgs e)
        {
                    serialPort_com5.WriteLine("HFLFSpyStart\nLCM Backlight off\n");
                    ResetCom5 = false;
        }

        private void flushBuffers()
        {
            try { serialPort_com1.DiscardOutBuffer(); }
            catch { }
            try { serialPort_com2.DiscardOutBuffer(); }
            catch { }
            try { serialPort_com3.DiscardOutBuffer(); }
            catch { }
            try { serialPort_com4.DiscardOutBuffer(); }
            catch { }
            try { serialPort_com5.DiscardOutBuffer(); }
            catch { }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Form_Help openForm = new Form_Help();
            openForm.Show();
        }

        private void ReadLog_Click(object sender, EventArgs e)
        {
            ReadLog openForm = new ReadLog();
            openForm.Show();
        }

        private void ClearLog_Click(object sender, EventArgs e)
        {
            tBoxDataOut.Clear();
            DisplayData = string.Empty;
            DisplayDataAll = string.Empty;
        }
    }
}