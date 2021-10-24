namespace VlastniKontrol
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.chkTop = new System.Windows.Forms.CheckBox();
      this.log = new VlastniKontrol.MujProtokol();
      this.SuspendLayout();
      // 
      // timer1
      // 
      this.timer1.Enabled = true;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // chkTop
      // 
      this.chkTop.AutoSize = true;
      this.chkTop.Location = new System.Drawing.Point(305, 12);
      this.chkTop.Name = "chkTop";
      this.chkTop.Size = new System.Drawing.Size(131, 21);
      this.chkTop.TabIndex = 1;
      this.chkTop.Text = "Pridavat nahoru";
      this.chkTop.UseVisualStyleBackColor = true;
      this.chkTop.CheckedChanged += new System.EventHandler(this.chkTop_CheckedChanged);
      // 
      // log
      // 
      this.log.Dock = System.Windows.Forms.DockStyle.Left;
      this.log.FormattingEnabled = true;
      this.log.ItemHeight = 16;
      this.log.Location = new System.Drawing.Point(0, 0);
      this.log.Name = "log";
      this.log.PocetRadku = 40;
      this.log.Size = new System.Drawing.Size(299, 450);
      this.log.TabIndex = 0;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(647, 450);
      this.Controls.Add(this.chkTop);
      this.Controls.Add(this.log);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private MujProtokol log;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.CheckBox chkTop;
  }
}

