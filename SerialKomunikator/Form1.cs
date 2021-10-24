using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Collections.Concurrent;

namespace SerialKomunikator
{
    public partial class Form1 : Form
    {
        ConcurrentQueue<byte> queue1 = new ConcurrentQueue<byte>();
        ConcurrentQueue<byte> queue2 = new ConcurrentQueue<byte>();

        private Random nahodneCislo = new Random();

        List<byte> paket1 = new List<byte>();
        List<byte> paket2 = new List<byte>();


        bool kontrolapaketu1 = false;
        bool kontrolapaketu2 = false;

        public Form1()
        {
            InitializeComponent();
            ZpristupniPorty();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxSerial1.Text = "COM1";
            comboBoxSerial2.Text = "COM2";
            comboBoxBaudRate1.Text = "115200";
            comboBoxBaudRate2.Text = "115200";
        }

        private void ZpristupniPorty()
        {
            string[] porty = SerialPort.GetPortNames();
            comboBoxSerial1.Items.AddRange(porty);
            comboBoxSerial2.Items.AddRange(porty);

        }

        private void openport1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((comboBoxSerial1.Text == "") || (comboBoxBaudRate1.Text == ""))
                {

                    textBoxstatus1.Text = String.Format("The values are not entered");

                }
                else
                {

                    serialPort1.PortName = comboBoxSerial1.Text;
                    serialPort1.BaudRate = Convert.ToInt32(comboBoxBaudRate1.Text);
                    serialPort1.Open();
                    textBoxstatus1.Text = String.Format("Port {0} is open", serialPort1.PortName);
                    listBoxread1.Enabled = true;
                    textBoxsend1.Enabled = true;
                    buttonread1.Enabled = true;
                    buttonsend1.Enabled = true;
                    buttonautoread1.Enabled = true;
                    closeport1.Enabled = true;
                    openport1.Enabled = false;
                    buttonclear1.Enabled = true;
                    buttonAutoSend1.Enabled = true;
                    buttonRandomsend1.Enabled = true;
                    buttoncrc1.Enabled = true;
                    listBoxpakety1.Enabled = true;

                }

            }
            catch (UnauthorizedAccessException)
            {

                textBoxstatus1.Text = String.Format("Unauthorized access");

            }
        }

        private void closeport1_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            textBoxstatus1.Text = String.Format("Port {0} is close", serialPort1.PortName);
            listBoxpakety1.Items.Clear();
            listBoxread1.Items.Clear();
            textBoxsend1.Text = "";
            listBoxread1.Enabled = false;
            textBoxsend1.Enabled = false;
            buttonread1.Enabled = false;
            buttonsend1.Enabled = false;
            openport1.Enabled = true;
            closeport1.Enabled = false;
            buttonclear1.Enabled = false;
            buttonautoread1.Enabled = false;
            buttonRandomsend1.Enabled = false;
            buttoncrc1.Enabled = false;
            listBoxpakety1.Enabled = false;
            buttonAutoSend1.Enabled = false;


        }

        private void openport2_Click(object sender, EventArgs e)
        {
            try
            {
                if ((comboBoxSerial2.Text == "") || (comboBoxBaudRate2.Text == ""))
                {

                    textBoxstatus2.Text = String.Format("The values are not entered");

                }
                else
                {

                    serialPort2.PortName = comboBoxSerial2.Text;
                    serialPort2.BaudRate = Convert.ToInt32(comboBoxBaudRate2.Text);
                    serialPort2.Open();
                    textBoxstatus2.Text = String.Format("Port {0} is open", serialPort2.PortName);
                    listBoxread2.Enabled = true;
                    textBoxsend2.Enabled = true;
                    buttonread2.Enabled = true;
                    buttonsend2.Enabled = true;
                    closeport2.Enabled = true;
                    openport2.Enabled = false;
                    buttonclear2.Enabled = true;
                    buttonautoread2.Enabled = true;
                    buttonRandomsend2.Enabled = true;
                    buttoncrc2.Enabled = true;
                    listBoxpakety2.Enabled = true;
                    buttonAutoSend2.Enabled = true;



                }

            }
            catch (UnauthorizedAccessException)
            {

                textBoxstatus2.Text = String.Format("Unauthorized access");

            }
        }

        private void closeport2_Click(object sender, EventArgs e)
        {
            serialPort2.Close();
            textBoxstatus2.Text = String.Format("Port {0} is close", serialPort2.PortName);
            listBoxread2.Enabled = false;
            listBoxpakety2.Items.Clear();
            listBoxread2.Items.Clear();
            textBoxsend2.Text = "";
            textBoxsend2.Enabled = false;
            buttonread2.Enabled = false;
            buttonsend2.Enabled = false;
            openport2.Enabled = true;
            closeport2.Enabled = false;
            buttonclear2.Enabled = false;
            buttonautoread2.Enabled = false;
            buttonRandomsend2.Enabled = false;
            buttoncrc2.Enabled = false;
            listBoxpakety2.Enabled = false;
            buttonAutoSend2.Enabled = false;
        }

        private void buttonsend1_Click(object sender, EventArgs e)
        {

            buttoncrc2.Text = String.Format("Spočítej CRC");

            string[] znaky = textBoxsend1.Text.Split(' ','}','{');

            for (int i = 0; i < znaky.Length; i++)
            {
                byte[] znak = new byte[1];


                if (byte.TryParse(znaky[i], System.Globalization.NumberStyles.HexNumber, null as IFormatProvider, out znak[0]))
                {
                    serialPort1.Write(znak, 0, 1);
                }

            }
           // textBoxsend1.Text = "";
        }

        private void buttonread1_Click(object sender, EventArgs e)
        {
            ZpracujPrijateByte1();
        }

        private void buttonsend2_Click(object sender, EventArgs e)
        {

            buttoncrc1.Text = String.Format("Spočítej CRC");

            string[] znaky = textBoxsend2.Text.Split(' ');

            for (int i = 0; i < znaky.Length; i++)
            {
                byte[] znak = new byte[1];


                if (byte.TryParse(znaky[i], System.Globalization.NumberStyles.HexNumber, null as IFormatProvider, out znak[0]))
                {
                    serialPort2.Write(znak, 0, 1);
                }
               
            }
          //  textBoxsend2.Text = "";
        }

        private void buttonread2_Click(object sender, EventArgs e)
        {
            ZpracujPrijateByte2();
        }

        private void buttonclear1_Click(object sender, EventArgs e)
        {
            listBoxread1.Items.Clear();
        }

        private void buttonclear2_Click(object sender, EventArgs e)
        {
            listBoxread2.Items.Clear();
        }

        private void buttonautoread1_Click(object sender, EventArgs e)
        {
            if (buttonautoread1.Text == "Auto Read")
            {
                timer1.Enabled = true;
                buttonautoread1.Text = String.Format("Off");
            }
            else
            {
                timer1.Enabled = false;
                buttonautoread1.Text = String.Format("Auto Read");
            }
        }

        private void buttonautoread2_Click(object sender, EventArgs e)
        {
            if (buttonautoread2.Text == "Auto Read")
            {
                timer2.Enabled = true;
                buttonautoread2.Text = String.Format("Off");
            }
            else
            {
                timer2.Enabled = false;
                buttonautoread2.Text = String.Format("Auto Read");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

             ZpracujPrijateByte1(); 

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
                ZpracujPrijateByte2();
        }

        private void buttonautosend1_Click(object sender, EventArgs e)
        {
            if (buttonRandomsend1.Text == "Random Send")
            {
                timer3.Enabled = true;
                buttonRandomsend1.Text = String.Format("Off");
            }
            else
            {
                timer3.Enabled = false;
                buttonRandomsend1.Text = String.Format("Random Send");
            }
        }

        private void buttonautosend2_Click(object sender, EventArgs e)
        {
            if (buttonRandomsend2.Text == "Random Send")
            {
                timer4.Enabled = true;
                buttonRandomsend2.Text = String.Format("Off");
            }
            else
            {
                timer4.Enabled = false;
                buttonRandomsend2.Text = String.Format("Random Send");
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            byte[] znak = new byte[1];

            znak[0] = (byte)(nahodneCislo.Next(0, 255));

            textBoxsend1.Text = String.Format("{0,3:X2}", znak[0]);

            serialPort1.Write(znak, 0, 1);

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            byte[] znak = new byte[1];

            znak[0] = (byte)(nahodneCislo.Next(0, 255));


            textBoxsend2.Text = String.Format("{0,3:X2}", znak[0]);

            serialPort2.Write(znak, 0, 1);

        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (e.EventType == SerialData.Chars)
            {

                while (serialPort1.BytesToRead > 0)
                {
                    byte b = (byte)serialPort1.ReadByte();

                    if (queue1.Count > 1000)
                        return;

                    queue1.Enqueue(b);
                }

            }
        }

        private void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (e.EventType == SerialData.Chars)
            {

                while (serialPort2.BytesToRead > 0)
                {
                    byte b = (byte)serialPort2.ReadByte();

                    if (queue2.Count < 1000)
                        queue2.Enqueue(b);

                }

            }
        }

        private void ZpracujPrijateByte1()
        {
            while ((queue1.Count > 0))
            {
                byte data;

                if (!queue1.TryDequeue(out data))
                {
                    break;

                }

                if ((data > 0) && (data <= 8) && (kontrolapaketu1 == false)) // HEX: 01 až 08
                {
                    paket1.Add(data);

                    kontrolapaketu1 = true;

                    ListBoxAdd(listBoxread1, data);
                }
                else if (kontrolapaketu1 == true)
                {

                    if ((paket1.Count) == ((paket1[0]) + 3)) //3 protože: 1byte head, 2byte adress, a 1byte CRC tady ještě nemám, ten tam dodám až o dva řádky níže
                    {
                        byte crc = VypocetCRC(paket1);

                        paket1.Add(data);

                        if (paket1[paket1.Count - 1] == crc)
                        {
                            kontrolapaketu1 = false;

                            string p = "";

                            for (int i = 0; i < paket1.Count; i++)
                            {
                                p += String.Format(" {0:X2}", paket1[i]);
                            }

                            listBoxpakety1.Items.Insert(0,p);
                            
                            listBoxpakety1.SelectedIndex = 0;


                            ListBoxAdd(listBoxread1, data);

                        }
                        else
                        {
                            kontrolapaketu1 = false;
                            ListBoxAdd(listBoxread1, data);

                            //smažu první člen v testovaném paketu
                            paket1.RemoveAt(0);
                            //do paketů přidám celý obsah fronty
                            paket1.AddRange(queue1);
                            //smažu všechno z fronty
                            while (queue1.TryDequeue(out byte ignored))
                            {

                            }
                            //zapíšu všechno do fronty
                            foreach (byte fronta in paket1)
                            {
                                queue1.Enqueue(fronta);
                            }
                        }
                        
                        //smažu všechny v paketu
                        paket1.Clear();

                    }
                    else
                    {

                        paket1.Add(data);
                        ListBoxAdd(listBoxread1, data);

                    }
                }
                else
                {
                    ListBoxAdd(listBoxread1, data);

                }                

            }
        }

        private void ZpracujPrijateByte2()
        {
            while ((queue2.Count > 0))
            {
                byte data;

                if (!queue2.TryDequeue(out data))
                {
                    break;

                }

                if ((data > 0) && (data <= 8) && (kontrolapaketu2 == false)) // HEX: 01 až 08
                {
                    paket2.Add(data);

                    kontrolapaketu2 = true;

                    ListBoxAdd(listBoxread2, data);
                }
                else if (kontrolapaketu2 == true)
                {

                    if ((paket2.Count) == ((paket2[0]) + 3))
                    {
                        byte crc = VypocetCRC(paket2);

                        paket2.Add(data);

                        if (paket2[paket2.Count - 1] == crc)
                        {
                            kontrolapaketu2 = false;

                            string p = "";

                            for (int i = 0; i < paket2.Count; i++)
                            {
                                p += String.Format(" {0:X2}", paket2[i]);
                            }

                           // listBoxpakety2.Items.Add(p);

                            listBoxpakety2.Items.Insert(0, p);

                            listBoxpakety2.SelectedIndex = 0;

                            ListBoxAdd(listBoxread2, data);

                        }
                        else
                        {
                            kontrolapaketu2 = false;
                            ListBoxAdd(listBoxread2, data);

                            //smažu první člen v testovaném paketu
                            paket2.RemoveAt(0);
                            //do paketů přidám celý obsah fronty
                            paket2.AddRange(queue2);
                            //smažu všechno z fronty
                            while (queue2.TryDequeue(out byte ignored))
                            {

                            }
                            //zapíšu všechno do fronty
                            foreach (byte fronta in paket2)
                            {
                                queue2.Enqueue(fronta);
                            }
                        }

                        //smažu všechny v paketu
                        paket2.Clear();

                    }
                    else
                    {

                        paket2.Add(data);
                        ListBoxAdd(listBoxread2, data);

                    }
                }
                else
                {
                    ListBoxAdd(listBoxread2, data);

                }

            }
        }

        private void ListBoxAdd(ListBox listBox, byte item)
        {
            listBox.Items.Insert(0, String.Format("{0,3:X2}", item));
            listBox.SelectedIndex = 0;

            while (listBox.Items.Count > 14)
            {
                listBox.Items.RemoveAt(listBox.Items.Count - 1);
            }

        }

        private byte VypocetCRC(List<byte> paket)
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


                    if ((crc & TOP_BIT)!=0)
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

        private void button1_Click(object sender, EventArgs e)
        {

            buttoncrc1.Text = String.Format("{0:X2}",VypocetCRC(paket1));
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttoncrc2.Text = String.Format("{0:X2}", VypocetCRC(paket2));
        }

        private void buttonAutoSend1_Click(object sender, EventArgs e)
        {
            if (buttonAutoSend1.Text == "Auto Send")
            {
                timer5.Enabled = true;
                buttonAutoSend1.Text = String.Format("Off");
            }
            else
            {
                timer5.Enabled = false;
                buttonAutoSend1.Text = String.Format("Auto Send");
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {

            buttoncrc2.Text = String.Format("Spočítej CRC");

            string[] znaky = textBoxsend1.Text.Split(' ','}','{');

            for (int i = 0; i < znaky.Length; i++)
            {
                byte[] znak = new byte[1];


                if (byte.TryParse(znaky[i], System.Globalization.NumberStyles.HexNumber, null as IFormatProvider, out znak[0]))
                {
                    serialPort1.Write(znak, 0, 1);
                }

            }

        }

        private void timer6_Tick(object sender, EventArgs e)
        {

            {

                buttoncrc1.Text = String.Format("Spočítej CRC");

                string[] znaky = textBoxsend2.Text.Split(' ', '}', '{');

                for (int i = 0; i < znaky.Length; i++)
                {
                    byte[] znak = new byte[1];


                    if (byte.TryParse(znaky[i], System.Globalization.NumberStyles.HexNumber, null as IFormatProvider, out znak[0]))
                    {
                        serialPort2.Write(znak, 0, 1);
                    }

                }
                //  textBoxsend2.Text = "";
            }

        }

        private void buttonAutoSend2_Click_1(object sender, EventArgs e)
        {
            if (buttonAutoSend2.Text == "Auto Send")
            {
                timer6.Enabled = true;
                buttonAutoSend2.Text = String.Format("Off");
            }
            else
            {
                timer6.Enabled = false;
                buttonAutoSend2.Text = String.Format("Auto Send");
            }
        }
    }
}
