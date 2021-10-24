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

namespace SeriovyPort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            log.Add("Start appp");
            button1_Click(null, null);

            dataGridView1.DataSource = seznam;
            graph.DataSource = seznam;

            graph.Series["x"].YValueMembers = "DataX";

            }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            if (radio == null)
            {
                return;
            }

            if (!radio.Checked)
            {
                return;
            }
            if (radio.Tag.ToString()=="Horizontal")
            {
                log.Add("Radio Horizotal is checked");
            }

            if (radio.Tag.ToString() == "Vertical")
            {
                log.Add("Radio Vertical is checked");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (sender == null)
            {
                log.Add("Auto scan");
            }
            else
            {
                log.Add("Manual scan");
            }
            

            /*
             * comboBox1.Items.Clear();
            foreach (string port in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(port);
                //log.Add(port);
            }
            */
            comboBox1.DataSource = SerialPort.GetPortNames();

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
             
            }

            comboBox2.DataSource = new int[] { 32, 64, 128, 512 };
            comboBox2.SelectedIndex = 0;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            log.Add("Open/Close button");

            if (uart.IsOpen)
            {
                uart.Close();
            }
            else
            {

                if (comboBox1.SelectedIndex < 0)
                {
                    log.Add("Nevybran");
                }
                else
                {

                    uart.PortName = comboBox1.SelectedItem as string;

                    try
                    {
                        uart.Open();
                    }
                    catch(Exception ex)
                    {
                        log.Add(ex.Message);
                    }
                    
                }
            }
            log.Add(uart.PortName + " " + uart.IsOpen);
        }

        byte[] lineBuffer = new byte[128];
        int poziceLineBufferu = 0;

        private void timer50ms_Tick(object sender, EventArgs e)
        {
            if (!uart.IsOpen)
            {
                return;
            }


            while (uart.BytesToRead > 0)
            {

                byte b = (byte)uart.ReadByte();

                if ((b == '\n') || (b == '\r'))
                {
                    if (poziceLineBufferu == 0)
                    {
                        continue;
                    }

                    ProcessLine(Encoding.UTF8.GetString(lineBuffer, 0, poziceLineBufferu));

                    poziceLineBufferu = 0;

                    continue;

                }

                lineBuffer[poziceLineBufferu] = b;

                poziceLineBufferu ++;

                if (poziceLineBufferu >= lineBuffer.Length)
                {
                    poziceLineBufferu = lineBuffer.Length - 1; //TODO vypis overflow
                }

            }
        }

        BindingList<cv5data> seznam = new BindingList<cv5data>();

        private void ProcessLine(string line)
        {

            if (comboBox2.SelectedIndex >= 0)
            {
                while (seznam.Count > (int)comboBox2.SelectedItem)
                {
                    seznam.RemoveAt(0);
                }
            }

            cv5data data = new cv5data(line);

            //log.Add(data);

            seznam.Add(data);


            graph.Series["K"].Points.Clear();

            graph.Series["K"].Points.AddY(data.DataX);
            graph.Series["K"].Points.AddY(data.DataY);
            graph.Series["K"].Points.AddY(data.DataZ);

            barX.Value = data.DataX;
            barY.Value = data.DataY;
            barZ.Value = data.DataZ;



            graph.DataBind(); // protoze graf funguje naprd, musim mu rict aby se prekreslil                       

        }

    }
}
