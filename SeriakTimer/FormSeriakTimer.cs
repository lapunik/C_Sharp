using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeriakTimer
{
  public partial class FormSeriakTimer : Form
  {
    SerialPort port = new SerialPort();
    Timer tmr = new Timer();

    public FormSeriakTimer()
    {
      InitializeComponent();
    }

    private void FormSeriakTimer_Load(object sender, EventArgs e)
    {
      port.BaudRate = 9600;
      port.DataBits = 8;
      port.StopBits = StopBits.One;
      port.Parity = Parity.None;

      tmr.Interval = 250;
      tmr.Enabled = true;
      tmr.Tick += tmr_Tick;

      cbPorty.Items.Clear();
      foreach (String s in SerialPort.GetPortNames())
      {
        cbPorty.Items.Add(s);
      }

      if (cbPorty.Items.Count > 0)
        cbPorty.SelectedIndex = 0;
    }

    byte[] data = new byte[256];
    int dataPos = 0;

    void tmr_Tick(object sender, EventArgs e)
    {
      if (!port.IsOpen)
        return;

      while (port.BytesToRead > 0)
      {
        if (dataPos < data.Length)
          data[dataPos] = (byte)port.ReadByte();
        else
        {
          port.ReadByte();

          if (dataPos == data.Length)
          {
            dataPos++;
            MessageBox.Show("Dalsi data zahazuju !!");
          }
        }

        dataPos++;
      }

      lblData.Text = Encoding.ASCII.GetString(data);
    }

    private void btnConnect_Click(object sender, EventArgs e)
    {
      if (port.IsOpen)
      {
        port.Close();
        lblStatus.Text = String.Format("Port {0} uzavren", port.PortName);
      }
      else
      {
        if (cbPorty.SelectedIndex < 0)
        {
          lblStatus.Text = "Neni vybran port !!";
        }
        else
        {
          //cbPorty.Items[cbPorty.SelectedIndex]

          port.PortName = cbPorty.SelectedItem as String;

          port.Open();

          lblStatus.Text = String.Format("Port {0} otevren", port.PortName);

          port.DtrEnable = true;
          port.DtrEnable = false;
        }
      }
    }

    private void btnSend_Click(object sender, EventArgs e)
    {
      if (port.IsOpen)
        port.Write(txSend.Text);
    }

    private void btnQuit_Click(object sender, EventArgs e)
    {
      if (port.IsOpen)
        port.Close();

      this.Close();
    }
  }
}
