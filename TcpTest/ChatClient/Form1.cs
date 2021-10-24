using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        TcpClient client = null;
        string prezdivka;

        public Form1()
        {
            InitializeComponent();
            // Adresa serveru
            String server = "localhost";

            try
            {
                // Vyvolá připojovací dotaz na server
                client = new TcpClient(server, 8080);

                PrezdivkaForm pf = new PrezdivkaForm();
                pf.ShowDialog();
                
                prezdivka = pf.prezdivka;
                PosilacRetezcu.PosliString(client, prezdivka);

                timer1.Enabled = true;
                timer1.Start();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Environment.Exit(-1);
            }
        }

        private void buttonOdeslat_Click(object sender, EventArgs e)
        {
            PosilacRetezcu.PosliString(client, zpravaTextBox.Text);
            zpravyTextBox.AppendText(prezdivka + ": " + zpravaTextBox.Text + "\n");
            zpravaTextBox.Text = "";
        }

        /// <summary>
        /// Kontroluje zda nečekají data od někoho
        /// </summary>        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (client.GetStream().DataAvailable)
            {
                zpravyTextBox.AppendText(PosilacRetezcu.PrijmiString(client) + "\n");
            }
        }
    }
}
