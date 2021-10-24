namespace SerialKomunikator
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
            this.comboBoxSerial1 = new System.Windows.Forms.ComboBox();
            this.comboBoxBaudRate1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttoncrc2 = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.listBoxpakety2 = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listBoxread2 = new System.Windows.Forms.ListBox();
            this.buttonautoread2 = new System.Windows.Forms.Button();
            this.buttonclear2 = new System.Windows.Forms.Button();
            this.buttonread2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxstatus2 = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonAutoSend2 = new System.Windows.Forms.Button();
            this.buttonRandomsend2 = new System.Windows.Forms.Button();
            this.buttonsend2 = new System.Windows.Forms.Button();
            this.textBoxsend2 = new System.Windows.Forms.TextBox();
            this.closeport2 = new System.Windows.Forms.Button();
            this.openport2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxSerial2 = new System.Windows.Forms.ComboBox();
            this.comboBoxBaudRate2 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttoncrc1 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.listBoxpakety1 = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listBoxread1 = new System.Windows.Forms.ListBox();
            this.buttonautoread1 = new System.Windows.Forms.Button();
            this.buttonclear1 = new System.Windows.Forms.Button();
            this.buttonread1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxstatus1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonAutoSend1 = new System.Windows.Forms.Button();
            this.buttonRandomsend1 = new System.Windows.Forms.Button();
            this.buttonsend1 = new System.Windows.Forms.Button();
            this.textBoxsend1 = new System.Windows.Forms.TextBox();
            this.closeport1 = new System.Windows.Forms.Button();
            this.openport1 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.timer6 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxSerial1
            // 
            this.comboBoxSerial1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSerial1.FormattingEnabled = true;
            this.comboBoxSerial1.Location = new System.Drawing.Point(8, 43);
            this.comboBoxSerial1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxSerial1.Name = "comboBoxSerial1";
            this.comboBoxSerial1.Size = new System.Drawing.Size(160, 24);
            this.comboBoxSerial1.TabIndex = 0;
            // 
            // comboBoxBaudRate1
            // 
            this.comboBoxBaudRate1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate1.FormattingEnabled = true;
            this.comboBoxBaudRate1.Items.AddRange(new object[] {
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "76800",
            "115200"});
            this.comboBoxBaudRate1.Location = new System.Drawing.Point(240, 43);
            this.comboBoxBaudRate1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxBaudRate1.Name = "comboBoxBaudRate1";
            this.comboBoxBaudRate1.Size = new System.Drawing.Size(159, 24);
            this.comboBoxBaudRate1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Serial Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baud Rate";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1663, 597);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttoncrc2);
            this.groupBox2.Controls.Add(this.groupBox8);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxstatus2);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.closeport2);
            this.groupBox2.Controls.Add(this.openport2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.comboBoxSerial2);
            this.groupBox2.Controls.Add(this.comboBoxBaudRate2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(835, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(824, 589);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Second Port";
            // 
            // buttoncrc2
            // 
            this.buttoncrc2.Enabled = false;
            this.buttoncrc2.Location = new System.Drawing.Point(8, 484);
            this.buttoncrc2.Name = "buttoncrc2";
            this.buttoncrc2.Size = new System.Drawing.Size(387, 69);
            this.buttoncrc2.TabIndex = 20;
            this.buttoncrc2.Text = "Spočítej CRC";
            this.buttoncrc2.UseVisualStyleBackColor = true;
            this.buttoncrc2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.listBoxpakety2);
            this.groupBox8.Location = new System.Drawing.Point(10, 337);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox8.Size = new System.Drawing.Size(387, 174);
            this.groupBox8.TabIndex = 19;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Packets";
            // 
            // listBoxpakety2
            // 
            this.listBoxpakety2.Enabled = false;
            this.listBoxpakety2.FormattingEnabled = true;
            this.listBoxpakety2.ItemHeight = 16;
            this.listBoxpakety2.Location = new System.Drawing.Point(0, 37);
            this.listBoxpakety2.Name = "listBoxpakety2";
            this.listBoxpakety2.Size = new System.Drawing.Size(387, 100);
            this.listBoxpakety2.TabIndex = 19;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listBoxread2);
            this.groupBox5.Controls.Add(this.buttonautoread2);
            this.groupBox5.Controls.Add(this.buttonclear2);
            this.groupBox5.Controls.Add(this.buttonread2);
            this.groupBox5.Location = new System.Drawing.Point(408, 146);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(412, 407);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Recieved";
            // 
            // listBoxread2
            // 
            this.listBoxread2.FormattingEnabled = true;
            this.listBoxread2.ItemHeight = 16;
            this.listBoxread2.Location = new System.Drawing.Point(1, 39);
            this.listBoxread2.Name = "listBoxread2";
            this.listBoxread2.Size = new System.Drawing.Size(384, 292);
            this.listBoxread2.TabIndex = 18;
            // 
            // buttonautoread2
            // 
            this.buttonautoread2.Enabled = false;
            this.buttonautoread2.Location = new System.Drawing.Point(25, 338);
            this.buttonautoread2.Margin = new System.Windows.Forms.Padding(4);
            this.buttonautoread2.Name = "buttonautoread2";
            this.buttonautoread2.Size = new System.Drawing.Size(115, 36);
            this.buttonautoread2.TabIndex = 4;
            this.buttonautoread2.Text = "Auto Read";
            this.buttonautoread2.UseVisualStyleBackColor = true;
            this.buttonautoread2.Click += new System.EventHandler(this.buttonautoread2_Click);
            // 
            // buttonclear2
            // 
            this.buttonclear2.Enabled = false;
            this.buttonclear2.Location = new System.Drawing.Point(148, 338);
            this.buttonclear2.Margin = new System.Windows.Forms.Padding(4);
            this.buttonclear2.Name = "buttonclear2";
            this.buttonclear2.Size = new System.Drawing.Size(115, 36);
            this.buttonclear2.TabIndex = 3;
            this.buttonclear2.Text = "Clear";
            this.buttonclear2.UseVisualStyleBackColor = true;
            this.buttonclear2.Click += new System.EventHandler(this.buttonclear2_Click);
            // 
            // buttonread2
            // 
            this.buttonread2.Enabled = false;
            this.buttonread2.Location = new System.Drawing.Point(270, 338);
            this.buttonread2.Margin = new System.Windows.Forms.Padding(4);
            this.buttonread2.Name = "buttonread2";
            this.buttonread2.Size = new System.Drawing.Size(115, 36);
            this.buttonread2.TabIndex = 1;
            this.buttonread2.Text = "Read";
            this.buttonread2.UseVisualStyleBackColor = true;
            this.buttonread2.Click += new System.EventHandler(this.buttonread2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 80);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "Status";
            // 
            // textBoxstatus2
            // 
            this.textBoxstatus2.Location = new System.Drawing.Point(10, 100);
            this.textBoxstatus2.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxstatus2.Name = "textBoxstatus2";
            this.textBoxstatus2.ReadOnly = true;
            this.textBoxstatus2.Size = new System.Drawing.Size(387, 22);
            this.textBoxstatus2.TabIndex = 16;
            this.textBoxstatus2.Text = "Port is Close";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.buttonAutoSend2);
            this.groupBox6.Controls.Add(this.buttonRandomsend2);
            this.groupBox6.Controls.Add(this.buttonsend2);
            this.groupBox6.Controls.Add(this.textBoxsend2);
            this.groupBox6.Location = new System.Drawing.Point(7, 155);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(407, 174);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Send";
            // 
            // buttonAutoSend2
            // 
            this.buttonAutoSend2.Enabled = false;
            this.buttonAutoSend2.Location = new System.Drawing.Point(31, 131);
            this.buttonAutoSend2.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAutoSend2.Name = "buttonAutoSend2";
            this.buttonAutoSend2.Size = new System.Drawing.Size(115, 36);
            this.buttonAutoSend2.TabIndex = 4;
            this.buttonAutoSend2.Text = "Auto Send";
            this.buttonAutoSend2.UseVisualStyleBackColor = true;
            this.buttonAutoSend2.Click += new System.EventHandler(this.buttonAutoSend2_Click_1);
            // 
            // buttonRandomsend2
            // 
            this.buttonRandomsend2.Enabled = false;
            this.buttonRandomsend2.Location = new System.Drawing.Point(154, 130);
            this.buttonRandomsend2.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRandomsend2.Name = "buttonRandomsend2";
            this.buttonRandomsend2.Size = new System.Drawing.Size(115, 36);
            this.buttonRandomsend2.TabIndex = 3;
            this.buttonRandomsend2.Text = "Random Send";
            this.buttonRandomsend2.UseVisualStyleBackColor = true;
            this.buttonRandomsend2.Click += new System.EventHandler(this.buttonautosend2_Click);
            // 
            // buttonsend2
            // 
            this.buttonsend2.Enabled = false;
            this.buttonsend2.Location = new System.Drawing.Point(277, 130);
            this.buttonsend2.Margin = new System.Windows.Forms.Padding(4);
            this.buttonsend2.Name = "buttonsend2";
            this.buttonsend2.Size = new System.Drawing.Size(115, 36);
            this.buttonsend2.TabIndex = 1;
            this.buttonsend2.Text = "Send";
            this.buttonsend2.UseVisualStyleBackColor = true;
            this.buttonsend2.Click += new System.EventHandler(this.buttonsend2_Click);
            // 
            // textBoxsend2
            // 
            this.textBoxsend2.Enabled = false;
            this.textBoxsend2.Location = new System.Drawing.Point(3, 34);
            this.textBoxsend2.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxsend2.Multiline = true;
            this.textBoxsend2.Name = "textBoxsend2";
            this.textBoxsend2.Size = new System.Drawing.Size(387, 89);
            this.textBoxsend2.TabIndex = 0;
            // 
            // closeport2
            // 
            this.closeport2.Enabled = false;
            this.closeport2.Location = new System.Drawing.Point(576, 35);
            this.closeport2.Margin = new System.Windows.Forms.Padding(4);
            this.closeport2.Name = "closeport2";
            this.closeport2.Size = new System.Drawing.Size(160, 87);
            this.closeport2.TabIndex = 9;
            this.closeport2.Text = "Close Port";
            this.closeport2.UseVisualStyleBackColor = true;
            this.closeport2.Click += new System.EventHandler(this.closeport2_Click);
            // 
            // openport2
            // 
            this.openport2.Location = new System.Drawing.Point(408, 35);
            this.openport2.Margin = new System.Windows.Forms.Padding(4);
            this.openport2.Name = "openport2";
            this.openport2.Size = new System.Drawing.Size(160, 87);
            this.openport2.TabIndex = 8;
            this.openport2.Text = "Open Port";
            this.openport2.UseVisualStyleBackColor = true;
            this.openport2.Click += new System.EventHandler(this.openport2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Serial Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(236, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Baud Rate";
            // 
            // comboBoxSerial2
            // 
            this.comboBoxSerial2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSerial2.FormattingEnabled = true;
            this.comboBoxSerial2.Location = new System.Drawing.Point(8, 43);
            this.comboBoxSerial2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxSerial2.Name = "comboBoxSerial2";
            this.comboBoxSerial2.Size = new System.Drawing.Size(160, 24);
            this.comboBoxSerial2.TabIndex = 4;
            // 
            // comboBoxBaudRate2
            // 
            this.comboBoxBaudRate2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate2.FormattingEnabled = true;
            this.comboBoxBaudRate2.Items.AddRange(new object[] {
            "9600",
            "14400",
            "19200",
            "38400",
            "56000",
            "57600",
            "76800",
            "115200"});
            this.comboBoxBaudRate2.Location = new System.Drawing.Point(240, 43);
            this.comboBoxBaudRate2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxBaudRate2.Name = "comboBoxBaudRate2";
            this.comboBoxBaudRate2.Size = new System.Drawing.Size(160, 24);
            this.comboBoxBaudRate2.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxstatus1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.closeport1);
            this.groupBox1.Controls.Add(this.openport1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxSerial1);
            this.groupBox1.Controls.Add(this.comboBoxBaudRate1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(823, 589);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "First Port";
            // 
            // buttoncrc1
            // 
            this.buttoncrc1.Enabled = false;
            this.buttoncrc1.Location = new System.Drawing.Point(12, 147);
            this.buttoncrc1.Name = "buttoncrc1";
            this.buttoncrc1.Size = new System.Drawing.Size(388, 69);
            this.buttoncrc1.TabIndex = 16;
            this.buttoncrc1.Text = "Spočítej CRC";
            this.buttoncrc1.UseVisualStyleBackColor = true;
            this.buttoncrc1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.buttoncrc1);
            this.groupBox7.Controls.Add(this.listBoxpakety1);
            this.groupBox7.Location = new System.Drawing.Point(3, 337);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox7.Size = new System.Drawing.Size(411, 393);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Packets";
            // 
            // listBoxpakety1
            // 
            this.listBoxpakety1.Enabled = false;
            this.listBoxpakety1.FormattingEnabled = true;
            this.listBoxpakety1.ItemHeight = 16;
            this.listBoxpakety1.Location = new System.Drawing.Point(12, 50);
            this.listBoxpakety1.Name = "listBoxpakety1";
            this.listBoxpakety1.Size = new System.Drawing.Size(387, 84);
            this.listBoxpakety1.TabIndex = 18;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.listBoxread1);
            this.groupBox4.Controls.Add(this.buttonautoread1);
            this.groupBox4.Controls.Add(this.buttonclear1);
            this.groupBox4.Controls.Add(this.buttonread1);
            this.groupBox4.Location = new System.Drawing.Point(422, 146);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(411, 407);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Recieved";
            // 
            // listBoxread1
            // 
            this.listBoxread1.FormattingEnabled = true;
            this.listBoxread1.ItemHeight = 16;
            this.listBoxread1.Location = new System.Drawing.Point(7, 39);
            this.listBoxread1.Name = "listBoxread1";
            this.listBoxread1.Size = new System.Drawing.Size(384, 292);
            this.listBoxread1.TabIndex = 17;
            // 
            // buttonautoread1
            // 
            this.buttonautoread1.Enabled = false;
            this.buttonautoread1.Location = new System.Drawing.Point(33, 338);
            this.buttonautoread1.Margin = new System.Windows.Forms.Padding(4);
            this.buttonautoread1.Name = "buttonautoread1";
            this.buttonautoread1.Size = new System.Drawing.Size(115, 36);
            this.buttonautoread1.TabIndex = 5;
            this.buttonautoread1.Text = "Auto Read";
            this.buttonautoread1.UseVisualStyleBackColor = true;
            this.buttonautoread1.Click += new System.EventHandler(this.buttonautoread1_Click);
            // 
            // buttonclear1
            // 
            this.buttonclear1.Enabled = false;
            this.buttonclear1.Location = new System.Drawing.Point(156, 338);
            this.buttonclear1.Margin = new System.Windows.Forms.Padding(4);
            this.buttonclear1.Name = "buttonclear1";
            this.buttonclear1.Size = new System.Drawing.Size(115, 36);
            this.buttonclear1.TabIndex = 2;
            this.buttonclear1.Text = "Clear";
            this.buttonclear1.UseVisualStyleBackColor = true;
            this.buttonclear1.Click += new System.EventHandler(this.buttonclear1_Click);
            // 
            // buttonread1
            // 
            this.buttonread1.Enabled = false;
            this.buttonread1.Location = new System.Drawing.Point(278, 338);
            this.buttonread1.Margin = new System.Windows.Forms.Padding(4);
            this.buttonread1.Name = "buttonread1";
            this.buttonread1.Size = new System.Drawing.Size(115, 36);
            this.buttonread1.TabIndex = 1;
            this.buttonread1.Text = "Read";
            this.buttonread1.UseVisualStyleBackColor = true;
            this.buttonread1.Click += new System.EventHandler(this.buttonread1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 80);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Status";
            // 
            // textBoxstatus1
            // 
            this.textBoxstatus1.Location = new System.Drawing.Point(7, 100);
            this.textBoxstatus1.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxstatus1.Name = "textBoxstatus1";
            this.textBoxstatus1.ReadOnly = true;
            this.textBoxstatus1.Size = new System.Drawing.Size(392, 22);
            this.textBoxstatus1.TabIndex = 12;
            this.textBoxstatus1.Text = "Port is Close";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonAutoSend1);
            this.groupBox3.Controls.Add(this.buttonRandomsend1);
            this.groupBox3.Controls.Add(this.buttonsend1);
            this.groupBox3.Controls.Add(this.textBoxsend1);
            this.groupBox3.Location = new System.Drawing.Point(8, 146);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(407, 174);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Send";
            // 
            // buttonAutoSend1
            // 
            this.buttonAutoSend1.Enabled = false;
            this.buttonAutoSend1.Location = new System.Drawing.Point(31, 130);
            this.buttonAutoSend1.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAutoSend1.Name = "buttonAutoSend1";
            this.buttonAutoSend1.Size = new System.Drawing.Size(115, 36);
            this.buttonAutoSend1.TabIndex = 3;
            this.buttonAutoSend1.Text = "Auto Send";
            this.buttonAutoSend1.UseVisualStyleBackColor = true;
            this.buttonAutoSend1.Click += new System.EventHandler(this.buttonAutoSend1_Click);
            // 
            // buttonRandomsend1
            // 
            this.buttonRandomsend1.Enabled = false;
            this.buttonRandomsend1.Location = new System.Drawing.Point(154, 130);
            this.buttonRandomsend1.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRandomsend1.Name = "buttonRandomsend1";
            this.buttonRandomsend1.Size = new System.Drawing.Size(115, 36);
            this.buttonRandomsend1.TabIndex = 2;
            this.buttonRandomsend1.Text = "Random Send";
            this.buttonRandomsend1.UseVisualStyleBackColor = true;
            this.buttonRandomsend1.Click += new System.EventHandler(this.buttonautosend1_Click);
            // 
            // buttonsend1
            // 
            this.buttonsend1.Enabled = false;
            this.buttonsend1.Location = new System.Drawing.Point(277, 130);
            this.buttonsend1.Margin = new System.Windows.Forms.Padding(4);
            this.buttonsend1.Name = "buttonsend1";
            this.buttonsend1.Size = new System.Drawing.Size(115, 36);
            this.buttonsend1.TabIndex = 1;
            this.buttonsend1.Text = "Send";
            this.buttonsend1.UseVisualStyleBackColor = true;
            this.buttonsend1.Click += new System.EventHandler(this.buttonsend1_Click);
            // 
            // textBoxsend1
            // 
            this.textBoxsend1.Enabled = false;
            this.textBoxsend1.Location = new System.Drawing.Point(4, 34);
            this.textBoxsend1.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxsend1.Multiline = true;
            this.textBoxsend1.Name = "textBoxsend1";
            this.textBoxsend1.Size = new System.Drawing.Size(387, 89);
            this.textBoxsend1.TabIndex = 0;
            // 
            // closeport1
            // 
            this.closeport1.Enabled = false;
            this.closeport1.Location = new System.Drawing.Point(590, 35);
            this.closeport1.Margin = new System.Windows.Forms.Padding(4);
            this.closeport1.Name = "closeport1";
            this.closeport1.Size = new System.Drawing.Size(160, 87);
            this.closeport1.TabIndex = 5;
            this.closeport1.Text = "Close Port";
            this.closeport1.UseVisualStyleBackColor = true;
            this.closeport1.Click += new System.EventHandler(this.closeport1_Click);
            // 
            // openport1
            // 
            this.openport1.Location = new System.Drawing.Point(422, 35);
            this.openport1.Margin = new System.Windows.Forms.Padding(4);
            this.openport1.Name = "openport1";
            this.openport1.Size = new System.Drawing.Size(160, 87);
            this.openport1.TabIndex = 4;
            this.openport1.Text = "Open Port";
            this.openport1.UseVisualStyleBackColor = true;
            this.openport1.Click += new System.EventHandler(this.openport1_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // serialPort2
            // 
            this.serialPort2.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort2_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 500;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Interval = 500;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // timer5
            // 
            this.timer5.Interval = 500;
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // timer6
            // 
            this.timer6.Interval = 500;
            this.timer6.Tick += new System.EventHandler(this.timer6_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1663, 597);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Serial Communication";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSerial1;
        private System.Windows.Forms.ComboBox comboBoxBaudRate1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxSerial2;
        private System.Windows.Forms.ComboBox comboBoxBaudRate2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button closeport1;
        private System.Windows.Forms.Button openport1;
        private System.Windows.Forms.Button closeport2;
        private System.Windows.Forms.Button openport2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonread2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxstatus2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button buttonsend2;
        private System.Windows.Forms.TextBox textBoxsend2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonread1;
        private System.Windows.Forms.TextBox textBoxread12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxstatus1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonsend1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.IO.Ports.SerialPort serialPort2;
        private System.Windows.Forms.Button buttonclear2;
        private System.Windows.Forms.Button buttonclear1;
        private System.Windows.Forms.Button buttonautoread2;
        private System.Windows.Forms.Button buttonautoread1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button buttonRandomsend1;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Button buttonRandomsend2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button buttoncrc1;
        private System.Windows.Forms.Button buttoncrc2;
        private System.Windows.Forms.ListBox listBoxread1;
        private System.Windows.Forms.TextBox textBoxsend1;
        private System.Windows.Forms.ListBox listBoxpakety1;
        private System.Windows.Forms.ListBox listBoxpakety2;
        private System.Windows.Forms.ListBox listBoxread2;
        private System.Windows.Forms.Button buttonAutoSend1;
        private System.Windows.Forms.Button buttonAutoSend2;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Timer timer6;
    }
}

