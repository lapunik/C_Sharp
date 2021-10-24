namespace DKEY
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.labelDevice5 = new System.Windows.Forms.Label();
            this.labelDevice4 = new System.Windows.Forms.Label();
            this.labelDevice3 = new System.Windows.Forms.Label();
            this.labelDevice2 = new System.Windows.Forms.Label();
            this.labelDevice1 = new System.Windows.Forms.Label();
            this.cBoxCOM5 = new System.Windows.Forms.ComboBox();
            this.cBoxCOM4 = new System.Windows.Forms.ComboBox();
            this.cBoxCOM3 = new System.Windows.Forms.ComboBox();
            this.cBoxCOM2 = new System.Windows.Forms.ComboBox();
            this.cBoxCOM1 = new System.Windows.Forms.ComboBox();
            this.serialPort_com1 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort_com2 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort_com3 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort_com4 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort_com5 = new System.IO.Ports.SerialPort(this.components);
            this.tBoxDataOut = new System.Windows.Forms.RichTextBox();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnReadLog = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.checkBox_autoscroll = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnDisconnect);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.labelDevice5);
            this.groupBox1.Controls.Add(this.labelDevice4);
            this.groupBox1.Controls.Add(this.labelDevice3);
            this.groupBox1.Controls.Add(this.labelDevice2);
            this.groupBox1.Controls.Add(this.labelDevice1);
            this.groupBox1.Controls.Add(this.cBoxCOM5);
            this.groupBox1.Controls.Add(this.cBoxCOM4);
            this.groupBox1.Controls.Add(this.cBoxCOM3);
            this.groupBox1.Controls.Add(this.cBoxCOM2);
            this.groupBox1.Controls.Add(this.cBoxCOM1);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "COM ports configuration";
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(431, 78);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(121, 36);
            this.btnReset.TabIndex = 13;
            this.btnReset.Text = "Reset time";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(431, 49);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(121, 23);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Refresh ports";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(9, 78);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(360, 36);
            this.btnDisconnect.TabIndex = 12;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Visible = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(9, 78);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(360, 36);
            this.btnConnect.TabIndex = 11;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // labelDevice5
            // 
            this.labelDevice5.AutoSize = true;
            this.labelDevice5.Location = new System.Drawing.Point(375, 22);
            this.labelDevice5.Name = "labelDevice5";
            this.labelDevice5.Size = new System.Drawing.Size(50, 13);
            this.labelDevice5.TabIndex = 10;
            this.labelDevice5.Text = "Device 5";
            // 
            // labelDevice4
            // 
            this.labelDevice4.AutoSize = true;
            this.labelDevice4.Location = new System.Drawing.Point(192, 54);
            this.labelDevice4.Name = "labelDevice4";
            this.labelDevice4.Size = new System.Drawing.Size(50, 13);
            this.labelDevice4.TabIndex = 9;
            this.labelDevice4.Text = "Device 4";
            // 
            // labelDevice3
            // 
            this.labelDevice3.AutoSize = true;
            this.labelDevice3.Location = new System.Drawing.Point(192, 22);
            this.labelDevice3.Name = "labelDevice3";
            this.labelDevice3.Size = new System.Drawing.Size(50, 13);
            this.labelDevice3.TabIndex = 8;
            this.labelDevice3.Text = "Device 3";
            // 
            // labelDevice2
            // 
            this.labelDevice2.AutoSize = true;
            this.labelDevice2.Location = new System.Drawing.Point(6, 49);
            this.labelDevice2.Name = "labelDevice2";
            this.labelDevice2.Size = new System.Drawing.Size(50, 13);
            this.labelDevice2.TabIndex = 7;
            this.labelDevice2.Text = "Device 2";
            // 
            // labelDevice1
            // 
            this.labelDevice1.AutoSize = true;
            this.labelDevice1.Location = new System.Drawing.Point(6, 22);
            this.labelDevice1.Name = "labelDevice1";
            this.labelDevice1.Size = new System.Drawing.Size(50, 13);
            this.labelDevice1.TabIndex = 6;
            this.labelDevice1.Text = "Device 1";
            // 
            // cBoxCOM5
            // 
            this.cBoxCOM5.FormattingEnabled = true;
            this.cBoxCOM5.Location = new System.Drawing.Point(431, 19);
            this.cBoxCOM5.Name = "cBoxCOM5";
            this.cBoxCOM5.Size = new System.Drawing.Size(121, 21);
            this.cBoxCOM5.TabIndex = 5;
            // 
            // cBoxCOM4
            // 
            this.cBoxCOM4.FormattingEnabled = true;
            this.cBoxCOM4.Location = new System.Drawing.Point(248, 51);
            this.cBoxCOM4.Name = "cBoxCOM4";
            this.cBoxCOM4.Size = new System.Drawing.Size(121, 21);
            this.cBoxCOM4.TabIndex = 4;
            // 
            // cBoxCOM3
            // 
            this.cBoxCOM3.FormattingEnabled = true;
            this.cBoxCOM3.Location = new System.Drawing.Point(248, 19);
            this.cBoxCOM3.Name = "cBoxCOM3";
            this.cBoxCOM3.Size = new System.Drawing.Size(121, 21);
            this.cBoxCOM3.TabIndex = 3;
            // 
            // cBoxCOM2
            // 
            this.cBoxCOM2.FormattingEnabled = true;
            this.cBoxCOM2.Location = new System.Drawing.Point(65, 46);
            this.cBoxCOM2.Name = "cBoxCOM2";
            this.cBoxCOM2.Size = new System.Drawing.Size(121, 21);
            this.cBoxCOM2.TabIndex = 2;
            // 
            // cBoxCOM1
            // 
            this.cBoxCOM1.FormattingEnabled = true;
            this.cBoxCOM1.Location = new System.Drawing.Point(65, 19);
            this.cBoxCOM1.Name = "cBoxCOM1";
            this.cBoxCOM1.Size = new System.Drawing.Size(121, 21);
            this.cBoxCOM1.TabIndex = 1;
            // 
            // serialPort_com1
            // 
            this.serialPort_com1.BaudRate = 115200;
            // 
            // serialPort_com2
            // 
            this.serialPort_com2.BaudRate = 115200;
            // 
            // serialPort_com3
            // 
            this.serialPort_com3.BaudRate = 115200;
            // 
            // serialPort_com4
            // 
            this.serialPort_com4.BaudRate = 115200;
            // 
            // serialPort_com5
            // 
            this.serialPort_com5.BaudRate = 115200;
            // 
            // tBoxDataOut
            // 
            this.tBoxDataOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tBoxDataOut.BackColor = System.Drawing.SystemColors.Window;
            this.tBoxDataOut.DetectUrls = false;
            this.tBoxDataOut.Location = new System.Drawing.Point(12, 140);
            this.tBoxDataOut.MinimumSize = new System.Drawing.Size(928, 420);
            this.tBoxDataOut.Name = "tBoxDataOut";
            this.tBoxDataOut.ReadOnly = true;
            this.tBoxDataOut.ShortcutsEnabled = false;
            this.tBoxDataOut.Size = new System.Drawing.Size(928, 452);
            this.tBoxDataOut.TabIndex = 2;
            this.tBoxDataOut.Text = "";
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxMessage.Location = new System.Drawing.Point(12, 140);
            this.textBoxMessage.MinimumSize = new System.Drawing.Size(928, 26);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(928, 26);
            this.textBoxMessage.TabIndex = 3;
            this.textBoxMessage.Visible = false;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(865, 104);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 23);
            this.btnHelp.TabIndex = 4;
            this.btnHelp.Text = "HELP";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnReadLog
            // 
            this.btnReadLog.Location = new System.Drawing.Point(579, 12);
            this.btnReadLog.Name = "btnReadLog";
            this.btnReadLog.Size = new System.Drawing.Size(121, 36);
            this.btnReadLog.TabIndex = 14;
            this.btnReadLog.Text = "Read Log";
            this.btnReadLog.UseVisualStyleBackColor = true;
            this.btnReadLog.Visible = false;
            this.btnReadLog.Click += new System.EventHandler(this.ReadLog_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(784, 104);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 15;
            this.btnClearLog.Text = "Clear log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.ClearLog_Click);
            // 
            // checkBox_autoscroll
            // 
            this.checkBox_autoscroll.AutoSize = true;
            this.checkBox_autoscroll.Checked = true;
            this.checkBox_autoscroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_autoscroll.Location = new System.Drawing.Point(579, 110);
            this.checkBox_autoscroll.Name = "checkBox_autoscroll";
            this.checkBox_autoscroll.Size = new System.Drawing.Size(75, 17);
            this.checkBox_autoscroll.TabIndex = 16;
            this.checkBox_autoscroll.Text = "Auto scroll";
            this.checkBox_autoscroll.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 604);
            this.Controls.Add(this.checkBox_autoscroll);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.btnReadLog);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.tBoxDataOut);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(968, 642);
            this.Name = "Form1";
            this.Text = "DKEY Sniffertool v3.0.1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cBoxCOM1;
        private System.Windows.Forms.ComboBox cBoxCOM5;
        private System.Windows.Forms.ComboBox cBoxCOM4;
        private System.Windows.Forms.ComboBox cBoxCOM3;
        private System.Windows.Forms.ComboBox cBoxCOM2;
        private System.Windows.Forms.Label labelDevice1;
        private System.Windows.Forms.Label labelDevice4;
        private System.Windows.Forms.Label labelDevice3;
        private System.Windows.Forms.Label labelDevice2;
        private System.Windows.Forms.Label labelDevice5;
        private System.Windows.Forms.Button btnConnect;
        private System.IO.Ports.SerialPort serialPort_com1;
        private System.IO.Ports.SerialPort serialPort_com2;
        private System.IO.Ports.SerialPort serialPort_com3;
        private System.IO.Ports.SerialPort serialPort_com4;
        private System.IO.Ports.SerialPort serialPort_com5;
        private System.Windows.Forms.RichTextBox tBoxDataOut;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnReadLog;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.CheckBox checkBox_autoscroll;
    }
}

