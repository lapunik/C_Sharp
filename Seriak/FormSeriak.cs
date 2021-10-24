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

namespace Seriak
{
  public partial class FormSeriak : Form
  {
    public FormSeriak()
    {
      InitializeComponent();
    }

    private void btnQuit_Click(object sender, EventArgs e)
    {
      if (port.IsOpen)
        port.Close();

      this.Close();
    }

    private void btnSend_Click(object sender, EventArgs e)
    {
      if (port.IsOpen)
        port.Write(txSend.Text);
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

    byte[] data = new byte[256];
    int dataPos = 0;

    private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      if (e.EventType != SerialData.Chars)
        return;

      while (port.BytesToRead > 0)
      {
        if (dataPos < data.Length)
          data[dataPos] = (byte)port.ReadByte();
        else
        {
          port.ReadByte();

          if (dataPos == data.Length)
            MessageBox.Show("Dalsi data zahazuju !!");
        }

        dataPos++;
      }

      vypisData();
    }

    void vypisData()
    {
      if (lblData.InvokeRequired)
      {
        lblData.BeginInvoke(new MethodInvoker(vypisData));
        return;
      }

      lblData.Text = Encoding.ASCII.GetString(data);
    }

    private void FormSeriak_Load(object sender, EventArgs e)
    {
      cbPorty.Items.Clear();
      foreach (String s in SerialPort.GetPortNames())
      {
        cbPorty.Items.Add(s);
      }

      if (cbPorty.Items.Count > 0)
        cbPorty.SelectedIndex = 0;
    }
  }
}
