using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Casovace
{
  public partial class FormCasovace : Form
  {
    System.Timers.Timer tmrTimers = null;

    System.Threading.Timer tmrThreading = null;

    public FormCasovace()
    {
      InitializeComponent();

      tmrTimers = new System.Timers.Timer(300);
      tmrTimers.Enabled = true;
      tmrTimers.Elapsed += tmrTimers_Elapsed;

      tmrThreading = new System.Threading.Timer(
        new System.Threading.TimerCallback(tmrThread_Tick));
      tmrThreading.Change(1000, 250);
    }

    int iThreading = 0;
    private void tmrThread_Tick(object state)
    {
      prehodTreadThreadings();
    }

    void prehodTreadThreadings()
    {
      if (this.InvokeRequired)
      {
        this.BeginInvoke(new MethodInvoker(prehodTreadThreadings));
        return;
      }

      iThreading++;
      lblThreads.Text = iThreading.ToString();

      AddProtocol("TICK Threading");
    }

    int iTimers = 0;
    void tmrTimers_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
      prehodThreadTimers();
    }

    void prehodThreadTimers()
    {
      if (this.InvokeRequired)
      {
        this.BeginInvoke(new MethodInvoker(prehodThreadTimers));
        return;
      }

      iTimers++;
      lblTimers.Text = iTimers.ToString();

      AddProtocol("TICK Timers");
    }

    void AddProtocol(String txt)
    {
      lbProtocol.Items.Add(
        String.Format("{0:HH:mm:ss} - {1}", DateTime.Now, txt));
      lbProtocol.SelectedIndex = lbProtocol.Items.Count - 1;
      lbProtocol.SelectedIndex = -1;
    }

    private void FormCasovace_Load(object sender, EventArgs e)
    {
      AddProtocol("Start aplikace");
    }

    int iVisual = 0;
    private void tmrVisual_Tick(object sender, EventArgs e)
    {
      iVisual++;
      lblVisual.Text = iVisual.ToString();

      AddProtocol("TICK Visual");
    }

    private void btnVisual_Click(object sender, EventArgs e)
    {
      tmrVisual.Enabled = !tmrVisual.Enabled; 
    }

    private void btnTimers_Click(object sender, EventArgs e)
    {
      tmrTimers.Enabled = !tmrTimers.Enabled;
    }

    bool tmrIsRunning = true;
    private void btnThreading_Click(object sender, EventArgs e)
    {
      if (tmrIsRunning)
        tmrThreading.Change(0, System.Threading.Timeout.Infinite);
      else
        tmrThreading.Change(0, 250);

      tmrIsRunning = !tmrIsRunning;
    }
  }
}
