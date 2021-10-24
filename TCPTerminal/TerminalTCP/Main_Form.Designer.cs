namespace TerminalTCP
{
  partial class Main_Form
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPageClient = new System.Windows.Forms.TabPage();
            this.rtxKlient = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnConnectClient = new System.Windows.Forms.Button();
            this.txClientIP = new System.Windows.Forms.TextBox();
            this.txClientPort = new System.Windows.Forms.TextBox();
            this.cbKlientType = new System.Windows.Forms.ComboBox();
            this.btnKlientClear = new System.Windows.Forms.Button();
            this.tabPageServer = new System.Windows.Forms.TabPage();
            this.rtxServer = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnListCleints = new System.Windows.Forms.Button();
            this.btnListen = new System.Windows.Forms.Button();
            this.txServerPort = new System.Windows.Forms.TextBox();
            this.btnServerClear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txSend1 = new System.Windows.Forms.TextBox();
            this.txSend2 = new System.Windows.Forms.TextBox();
            this.txSend3 = new System.Windows.Forms.TextBox();
            this.txSend4 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPageClient.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPageServer.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabMain);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(800, 583);
            this.splitContainer1.SplitterDistance = 265;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPageClient);
            this.tabMain.Controls.Add(this.tabPageServer);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 45);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(531, 430);
            this.tabMain.TabIndex = 0;
            // 
            // tabPageClient
            // 
            this.tabPageClient.Controls.Add(this.rtxKlient);
            this.tabPageClient.Controls.Add(this.tableLayoutPanel1);
            this.tabPageClient.Location = new System.Drawing.Point(4, 22);
            this.tabPageClient.Name = "tabPageClient";
            this.tabPageClient.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClient.Size = new System.Drawing.Size(523, 404);
            this.tabPageClient.TabIndex = 0;
            this.tabPageClient.Text = "TCP Client";
            this.tabPageClient.UseVisualStyleBackColor = true;
            // 
            // rtxKlient
            // 
            this.rtxKlient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxKlient.Location = new System.Drawing.Point(3, 61);
            this.rtxKlient.Margin = new System.Windows.Forms.Padding(0);
            this.rtxKlient.Name = "rtxKlient";
            this.rtxKlient.Size = new System.Drawing.Size(517, 340);
            this.rtxKlient.TabIndex = 1;
            this.rtxKlient.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.btnConnectClient, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txClientIP, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txClientPort, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbKlientType, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnKlientClear, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(517, 58);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnConnectClient
            // 
            this.btnConnectClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnectClient.Location = new System.Drawing.Point(261, 3);
            this.btnConnectClient.Name = "btnConnectClient";
            this.btnConnectClient.Size = new System.Drawing.Size(123, 23);
            this.btnConnectClient.TabIndex = 2;
            this.btnConnectClient.Text = "Connect";
            this.btnConnectClient.UseVisualStyleBackColor = true;
            this.btnConnectClient.Click += new System.EventHandler(this.btnConnectClient_Click);
            // 
            // txClientIP
            // 
            this.txClientIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txClientIP.Location = new System.Drawing.Point(3, 3);
            this.txClientIP.Name = "txClientIP";
            this.txClientIP.Size = new System.Drawing.Size(123, 20);
            this.txClientIP.TabIndex = 3;
            // 
            // txClientPort
            // 
            this.txClientPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txClientPort.Location = new System.Drawing.Point(132, 3);
            this.txClientPort.Name = "txClientPort";
            this.txClientPort.Size = new System.Drawing.Size(123, 20);
            this.txClientPort.TabIndex = 4;
            // 
            // cbKlientType
            // 
            this.cbKlientType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbKlientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKlientType.FormattingEnabled = true;
            this.cbKlientType.Location = new System.Drawing.Point(389, 2);
            this.cbKlientType.Margin = new System.Windows.Forms.Padding(2);
            this.cbKlientType.Name = "cbKlientType";
            this.cbKlientType.Size = new System.Drawing.Size(126, 21);
            this.cbKlientType.TabIndex = 5;
            this.cbKlientType.SelectedIndexChanged += new System.EventHandler(this.CbKlientType_SelectedIndexChanged);
            // 
            // btnKlientClear
            // 
            this.btnKlientClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnKlientClear.Location = new System.Drawing.Point(389, 31);
            this.btnKlientClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnKlientClear.Name = "btnKlientClear";
            this.btnKlientClear.Size = new System.Drawing.Size(126, 25);
            this.btnKlientClear.TabIndex = 6;
            this.btnKlientClear.Text = "Clear";
            this.btnKlientClear.UseVisualStyleBackColor = true;
            this.btnKlientClear.Click += new System.EventHandler(this.BtnKlientClear_Click);
            // 
            // tabPageServer
            // 
            this.tabPageServer.Controls.Add(this.rtxServer);
            this.tabPageServer.Controls.Add(this.tableLayoutPanel3);
            this.tabPageServer.Location = new System.Drawing.Point(4, 22);
            this.tabPageServer.Name = "tabPageServer";
            this.tabPageServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageServer.Size = new System.Drawing.Size(523, 404);
            this.tabPageServer.TabIndex = 1;
            this.tabPageServer.Text = "TCP Server";
            this.tabPageServer.UseVisualStyleBackColor = true;
            // 
            // rtxServer
            // 
            this.rtxServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxServer.Location = new System.Drawing.Point(3, 61);
            this.rtxServer.Margin = new System.Windows.Forms.Padding(0);
            this.rtxServer.Name = "rtxServer";
            this.rtxServer.Size = new System.Drawing.Size(517, 340);
            this.rtxServer.TabIndex = 2;
            this.rtxServer.Text = "";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.btnListCleints, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnListen, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.txServerPort, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnServerClear, 3, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(517, 58);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // btnListCleints
            // 
            this.btnListCleints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnListCleints.Location = new System.Drawing.Point(390, 3);
            this.btnListCleints.Name = "btnListCleints";
            this.btnListCleints.Size = new System.Drawing.Size(124, 23);
            this.btnListCleints.TabIndex = 7;
            this.btnListCleints.Text = "List Clients";
            this.btnListCleints.UseVisualStyleBackColor = true;
            this.btnListCleints.Click += new System.EventHandler(this.BtnListClients_Click);
            // 
            // btnListen
            // 
            this.btnListen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnListen.Location = new System.Drawing.Point(261, 3);
            this.btnListen.Name = "btnListen";
            this.btnListen.Size = new System.Drawing.Size(123, 23);
            this.btnListen.TabIndex = 2;
            this.btnListen.Text = "Listen";
            this.btnListen.UseVisualStyleBackColor = true;
            this.btnListen.Click += new System.EventHandler(this.BtnListen_Click);
            // 
            // txServerPort
            // 
            this.txServerPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txServerPort.Location = new System.Drawing.Point(132, 3);
            this.txServerPort.Name = "txServerPort";
            this.txServerPort.Size = new System.Drawing.Size(123, 20);
            this.txServerPort.TabIndex = 4;
            // 
            // btnServerClear
            // 
            this.btnServerClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnServerClear.Location = new System.Drawing.Point(389, 31);
            this.btnServerClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnServerClear.Name = "btnServerClear";
            this.btnServerClear.Size = new System.Drawing.Size(126, 25);
            this.btnServerClear.TabIndex = 6;
            this.btnServerClear.Text = "Clear";
            this.btnServerClear.UseVisualStyleBackColor = true;
            this.btnServerClear.Click += new System.EventHandler(this.BtnServerClear_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 45);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel2.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.button2, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.button3, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.button4, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.txSend1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txSend2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txSend3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txSend4, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 475);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(531, 108);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(470, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 21);
            this.button1.TabIndex = 0;
            this.button1.Tag = "1";
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(470, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(58, 21);
            this.button2.TabIndex = 1;
            this.button2.Tag = "2";
            this.button2.Text = "Send";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(470, 57);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 21);
            this.button3.TabIndex = 2;
            this.button3.Tag = "3";
            this.button3.Text = "Send";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(470, 84);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(58, 21);
            this.button4.TabIndex = 3;
            this.button4.Tag = "4";
            this.button4.Text = "Send";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // txSend1
            // 
            this.txSend1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txSend1.Location = new System.Drawing.Point(3, 3);
            this.txSend1.Name = "txSend1";
            this.txSend1.Size = new System.Drawing.Size(429, 20);
            this.txSend1.TabIndex = 4;
            this.txSend1.Tag = "1";
            // 
            // txSend2
            // 
            this.txSend2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txSend2.Location = new System.Drawing.Point(3, 30);
            this.txSend2.Name = "txSend2";
            this.txSend2.Size = new System.Drawing.Size(429, 20);
            this.txSend2.TabIndex = 5;
            this.txSend2.Tag = "2";
            // 
            // txSend3
            // 
            this.txSend3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txSend3.Location = new System.Drawing.Point(3, 57);
            this.txSend3.Name = "txSend3";
            this.txSend3.Size = new System.Drawing.Size(429, 20);
            this.txSend3.TabIndex = 6;
            this.txSend3.Tag = "3";
            // 
            // txSend4
            // 
            this.txSend4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txSend4.Location = new System.Drawing.Point(3, 84);
            this.txSend4.Name = "txSend4";
            this.txSend4.Size = new System.Drawing.Size(429, 20);
            this.txSend4.TabIndex = 7;
            this.txSend4.Tag = "4";
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 583);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Main_Form";
            this.Text = "TCP Terminal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_Form_FormClosed);
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabPageClient.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPageServer.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private ASE.Controls.MujProtokol log;
    private System.Windows.Forms.TabControl tabMain;
    private System.Windows.Forms.TabPage tabPageClient;
    private System.Windows.Forms.TabPage tabPageServer;
    private System.Windows.Forms.RichTextBox rtxKlient;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnConnectClient;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.TextBox txSend1;
    private System.Windows.Forms.TextBox txSend2;
    private System.Windows.Forms.TextBox txSend3;
    private System.Windows.Forms.TextBox txSend4;
    private System.Windows.Forms.TextBox txClientIP;
    private System.Windows.Forms.TextBox txClientPort;
    private System.Windows.Forms.ComboBox cbKlientType;
    private System.Windows.Forms.Button btnKlientClear;
    private System.Windows.Forms.RichTextBox rtxServer;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    private System.Windows.Forms.Button btnListen;
    private System.Windows.Forms.TextBox txServerPort;
    private System.Windows.Forms.Button btnServerClear;
    private System.Windows.Forms.Button btnListCleints;
  }
}

