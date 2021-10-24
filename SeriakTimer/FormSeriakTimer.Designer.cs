namespace SeriakTimer
{
  partial class FormSeriakTimer
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
      this.btnQuit = new System.Windows.Forms.Button();
      this.btnSend = new System.Windows.Forms.Button();
      this.txSend = new System.Windows.Forms.TextBox();
      this.lblStatus = new System.Windows.Forms.Label();
      this.btnConnect = new System.Windows.Forms.Button();
      this.cbPorty = new System.Windows.Forms.ComboBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.lblData = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnQuit
      // 
      this.btnQuit.Location = new System.Drawing.Point(13, 281);
      this.btnQuit.Name = "btnQuit";
      this.btnQuit.Size = new System.Drawing.Size(150, 40);
      this.btnQuit.TabIndex = 5;
      this.btnQuit.Text = "Konec";
      this.btnQuit.UseVisualStyleBackColor = true;
      this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
      // 
      // btnSend
      // 
      this.btnSend.Location = new System.Drawing.Point(13, 196);
      this.btnSend.Name = "btnSend";
      this.btnSend.Size = new System.Drawing.Size(150, 32);
      this.btnSend.TabIndex = 4;
      this.btnSend.Text = "Odeslat";
      this.btnSend.UseVisualStyleBackColor = true;
      this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
      // 
      // txSend
      // 
      this.txSend.Location = new System.Drawing.Point(12, 169);
      this.txSend.Name = "txSend";
      this.txSend.Size = new System.Drawing.Size(151, 20);
      this.txSend.TabIndex = 3;
      // 
      // lblStatus
      // 
      this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblStatus.Location = new System.Drawing.Point(12, 81);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new System.Drawing.Size(151, 36);
      this.lblStatus.TabIndex = 2;
      this.lblStatus.Text = "label1";
      // 
      // btnConnect
      // 
      this.btnConnect.Location = new System.Drawing.Point(13, 40);
      this.btnConnect.Name = "btnConnect";
      this.btnConnect.Size = new System.Drawing.Size(150, 34);
      this.btnConnect.TabIndex = 1;
      this.btnConnect.Text = "Pripojit/odpojit";
      this.btnConnect.UseVisualStyleBackColor = true;
      this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
      // 
      // cbPorty
      // 
      this.cbPorty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cbPorty.FormattingEnabled = true;
      this.cbPorty.Location = new System.Drawing.Point(12, 12);
      this.cbPorty.Name = "cbPorty";
      this.cbPorty.Size = new System.Drawing.Size(151, 21);
      this.cbPorty.TabIndex = 0;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnQuit);
      this.panel1.Controls.Add(this.btnSend);
      this.panel1.Controls.Add(this.txSend);
      this.panel1.Controls.Add(this.lblStatus);
      this.panel1.Controls.Add(this.btnConnect);
      this.panel1.Controls.Add(this.cbPorty);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(169, 432);
      this.panel1.TabIndex = 1;
      // 
      // lblData
      // 
      this.lblData.BackColor = System.Drawing.Color.Black;
      this.lblData.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblData.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
      this.lblData.Location = new System.Drawing.Point(169, 0);
      this.lblData.Name = "lblData";
      this.lblData.Size = new System.Drawing.Size(359, 432);
      this.lblData.TabIndex = 2;
      this.lblData.Text = "label1";
      // 
      // FormSeriakTimer
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(528, 432);
      this.Controls.Add(this.lblData);
      this.Controls.Add(this.panel1);
      this.Name = "FormSeriakTimer";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.FormSeriakTimer_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnQuit;
    private System.Windows.Forms.Button btnSend;
    private System.Windows.Forms.TextBox txSend;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.Button btnConnect;
    private System.Windows.Forms.ComboBox cbPorty;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label lblData;
  }
}

