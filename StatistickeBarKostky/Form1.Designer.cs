namespace StatistickeBarKostky
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.log = new ASE.Controls.MujProtokol();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dice3 = new Dice.Dice();
            this.dice2 = new Dice.Dice();
            this.dice1 = new Dice.Dice();
            this.soucet = new System.Windows.Forms.Label();
            this.buttonHod = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelBar = new System.Windows.Forms.TableLayoutPanel();
            this.percentageBar16 = new PercentagePointerUseControl.PercentageBar();
            this.percentageBar15 = new PercentagePointerUseControl.PercentageBar();
            this.percentageBar14 = new PercentagePointerUseControl.PercentageBar();
            this.percentageBar13 = new PercentagePointerUseControl.PercentageBar();
            this.percentageBar12 = new PercentagePointerUseControl.PercentageBar();
            this.percentageBar11 = new PercentagePointerUseControl.PercentageBar();
            this.percentageBar10 = new PercentagePointerUseControl.PercentageBar();
            this.percentageBar9 = new PercentagePointerUseControl.PercentageBar();
            this.percentageBar8 = new PercentagePointerUseControl.PercentageBar();
            this.percentageBar7 = new PercentagePointerUseControl.PercentageBar();
            this.percentageBar6 = new PercentagePointerUseControl.PercentageBar();
            this.percentageBar5 = new PercentagePointerUseControl.PercentageBar();
            this.percentageBar4 = new PercentagePointerUseControl.PercentageBar();
            this.percentageBar3 = new PercentagePointerUseControl.PercentageBar();
            this.percentageBar2 = new PercentagePointerUseControl.PercentageBar();
            this.percentageBar1 = new PercentagePointerUseControl.PercentageBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSpeed = new System.Windows.Forms.Button();
            this.buttonAuto = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanelBar.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.log);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1082, 681);
            this.splitContainer1.SplitterDistance = 275;
            this.splitContainer1.TabIndex = 0;
            // 
            // log
            // 
            this.log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.log.FormattingEnabled = true;
            this.log.Location = new System.Drawing.Point(0, 0);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(275, 681);
            this.log.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.1593F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.81258F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.16198F));
            this.tableLayoutPanel1.Controls.Add(this.buttonClear, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.soucet, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonHod, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.66666F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(803, 681);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClear.Location = new System.Drawing.Point(346, 3);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(454, 98);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "Reset";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dice3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.dice2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.dice1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 107);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(179, 571);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dice3
            // 
            this.dice3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dice3.Location = new System.Drawing.Point(3, 383);
            this.dice3.Name = "dice3";
            this.dice3.Number = 6;
            this.dice3.Size = new System.Drawing.Size(173, 185);
            this.dice3.TabIndex = 2;
            this.dice3.Text = "dice3";
            // 
            // dice2
            // 
            this.dice2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dice2.Location = new System.Drawing.Point(3, 193);
            this.dice2.Name = "dice2";
            this.dice2.Number = 6;
            this.dice2.Size = new System.Drawing.Size(173, 184);
            this.dice2.TabIndex = 1;
            this.dice2.Text = "dice2";
            // 
            // dice1
            // 
            this.dice1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dice1.Location = new System.Drawing.Point(3, 3);
            this.dice1.Name = "dice1";
            this.dice1.Number = 6;
            this.dice1.Size = new System.Drawing.Size(173, 184);
            this.dice1.TabIndex = 0;
            this.dice1.Text = "dice1";
            this.dice1.Click += new System.EventHandler(this.dice1_Click);
            // 
            // soucet
            // 
            this.soucet.BackColor = System.Drawing.Color.DarkSlateGray;
            this.soucet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soucet.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.soucet.Location = new System.Drawing.Point(188, 104);
            this.soucet.Name = "soucet";
            this.soucet.Size = new System.Drawing.Size(152, 577);
            this.soucet.TabIndex = 1;
            this.soucet.Text = "Součet";
            this.soucet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonHod
            // 
            this.buttonHod.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.buttonHod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHod.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonHod.Location = new System.Drawing.Point(3, 3);
            this.buttonHod.Name = "buttonHod";
            this.buttonHod.Size = new System.Drawing.Size(179, 98);
            this.buttonHod.TabIndex = 2;
            this.buttonHod.Text = "Hod";
            this.buttonHod.UseVisualStyleBackColor = false;
            this.buttonHod.Click += new System.EventHandler(this.buttonHod_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.71564F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.28436F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.label9, 0, 8);
            this.tableLayoutPanel3.Controls.Add(this.label10, 0, 9);
            this.tableLayoutPanel3.Controls.Add(this.label11, 0, 10);
            this.tableLayoutPanel3.Controls.Add(this.label12, 0, 11);
            this.tableLayoutPanel3.Controls.Add(this.label13, 0, 12);
            this.tableLayoutPanel3.Controls.Add(this.label14, 0, 13);
            this.tableLayoutPanel3.Controls.Add(this.label15, 0, 14);
            this.tableLayoutPanel3.Controls.Add(this.label16, 0, 15);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanelBar, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(346, 107);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 16;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(454, 571);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // tableLayoutPanelBar
            // 
            this.tableLayoutPanelBar.ColumnCount = 1;
            this.tableLayoutPanelBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelBar.Controls.Add(this.percentageBar16, 0, 15);
            this.tableLayoutPanelBar.Controls.Add(this.percentageBar15, 0, 14);
            this.tableLayoutPanelBar.Controls.Add(this.percentageBar14, 0, 13);
            this.tableLayoutPanelBar.Controls.Add(this.percentageBar13, 0, 12);
            this.tableLayoutPanelBar.Controls.Add(this.percentageBar12, 0, 11);
            this.tableLayoutPanelBar.Controls.Add(this.percentageBar11, 0, 10);
            this.tableLayoutPanelBar.Controls.Add(this.percentageBar10, 0, 9);
            this.tableLayoutPanelBar.Controls.Add(this.percentageBar9, 0, 8);
            this.tableLayoutPanelBar.Controls.Add(this.percentageBar8, 0, 7);
            this.tableLayoutPanelBar.Controls.Add(this.percentageBar7, 0, 6);
            this.tableLayoutPanelBar.Controls.Add(this.percentageBar6, 0, 5);
            this.tableLayoutPanelBar.Controls.Add(this.percentageBar5, 0, 4);
            this.tableLayoutPanelBar.Controls.Add(this.percentageBar4, 0, 3);
            this.tableLayoutPanelBar.Controls.Add(this.percentageBar3, 0, 2);
            this.tableLayoutPanelBar.Controls.Add(this.percentageBar2, 0, 1);
            this.tableLayoutPanelBar.Controls.Add(this.percentageBar1, 0, 0);
            this.tableLayoutPanelBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelBar.Location = new System.Drawing.Point(47, 3);
            this.tableLayoutPanelBar.Name = "tableLayoutPanelBar";
            this.tableLayoutPanelBar.RowCount = 16;
            this.tableLayoutPanel3.SetRowSpan(this.tableLayoutPanelBar, 16);
            this.tableLayoutPanelBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanelBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanelBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanelBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanelBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanelBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanelBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanelBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanelBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanelBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanelBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanelBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanelBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanelBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanelBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanelBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25F));
            this.tableLayoutPanelBar.Size = new System.Drawing.Size(404, 565);
            this.tableLayoutPanelBar.TabIndex = 16;
            // 
            // percentageBar16
            // 
            this.percentageBar16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentageBar16.Location = new System.Drawing.Point(3, 528);
            this.percentageBar16.MaxValue = 100;
            this.percentageBar16.Name = "percentageBar16";
            this.percentageBar16.Size = new System.Drawing.Size(398, 34);
            this.percentageBar16.TabIndex = 15;
            this.percentageBar16.Tag = "18";
            this.percentageBar16.Text = "percentageBar16";
            this.percentageBar16.Value = 30;
            // 
            // percentageBar15
            // 
            this.percentageBar15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentageBar15.Location = new System.Drawing.Point(3, 493);
            this.percentageBar15.MaxValue = 100;
            this.percentageBar15.Name = "percentageBar15";
            this.percentageBar15.Size = new System.Drawing.Size(398, 29);
            this.percentageBar15.TabIndex = 14;
            this.percentageBar15.Tag = "17";
            this.percentageBar15.Text = "percentageBar15";
            this.percentageBar15.Value = 30;
            // 
            // percentageBar14
            // 
            this.percentageBar14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentageBar14.Location = new System.Drawing.Point(3, 458);
            this.percentageBar14.MaxValue = 100;
            this.percentageBar14.Name = "percentageBar14";
            this.percentageBar14.Size = new System.Drawing.Size(398, 29);
            this.percentageBar14.TabIndex = 13;
            this.percentageBar14.Tag = "16";
            this.percentageBar14.Text = "percentageBar14";
            this.percentageBar14.Value = 30;
            // 
            // percentageBar13
            // 
            this.percentageBar13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentageBar13.Location = new System.Drawing.Point(3, 423);
            this.percentageBar13.MaxValue = 100;
            this.percentageBar13.Name = "percentageBar13";
            this.percentageBar13.Size = new System.Drawing.Size(398, 29);
            this.percentageBar13.TabIndex = 12;
            this.percentageBar13.Tag = "15";
            this.percentageBar13.Text = "percentageBar13";
            this.percentageBar13.Value = 30;
            // 
            // percentageBar12
            // 
            this.percentageBar12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentageBar12.Location = new System.Drawing.Point(3, 388);
            this.percentageBar12.MaxValue = 100;
            this.percentageBar12.Name = "percentageBar12";
            this.percentageBar12.Size = new System.Drawing.Size(398, 29);
            this.percentageBar12.TabIndex = 11;
            this.percentageBar12.Tag = "14";
            this.percentageBar12.Text = "percentageBar12";
            this.percentageBar12.Value = 30;
            // 
            // percentageBar11
            // 
            this.percentageBar11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentageBar11.Location = new System.Drawing.Point(3, 353);
            this.percentageBar11.MaxValue = 100;
            this.percentageBar11.Name = "percentageBar11";
            this.percentageBar11.Size = new System.Drawing.Size(398, 29);
            this.percentageBar11.TabIndex = 10;
            this.percentageBar11.Tag = "13";
            this.percentageBar11.Text = "percentageBar11";
            this.percentageBar11.Value = 30;
            // 
            // percentageBar10
            // 
            this.percentageBar10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentageBar10.Location = new System.Drawing.Point(3, 318);
            this.percentageBar10.MaxValue = 100;
            this.percentageBar10.Name = "percentageBar10";
            this.percentageBar10.Size = new System.Drawing.Size(398, 29);
            this.percentageBar10.TabIndex = 9;
            this.percentageBar10.Tag = "12";
            this.percentageBar10.Text = "percentageBar10";
            this.percentageBar10.Value = 30;
            // 
            // percentageBar9
            // 
            this.percentageBar9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentageBar9.Location = new System.Drawing.Point(3, 283);
            this.percentageBar9.MaxValue = 100;
            this.percentageBar9.Name = "percentageBar9";
            this.percentageBar9.Size = new System.Drawing.Size(398, 29);
            this.percentageBar9.TabIndex = 8;
            this.percentageBar9.Tag = "11";
            this.percentageBar9.Text = "percentageBar9";
            this.percentageBar9.Value = 30;
            // 
            // percentageBar8
            // 
            this.percentageBar8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentageBar8.Location = new System.Drawing.Point(3, 248);
            this.percentageBar8.MaxValue = 100;
            this.percentageBar8.Name = "percentageBar8";
            this.percentageBar8.Size = new System.Drawing.Size(398, 29);
            this.percentageBar8.TabIndex = 7;
            this.percentageBar8.Tag = "10";
            this.percentageBar8.Text = "percentageBar8";
            this.percentageBar8.Value = 30;
            // 
            // percentageBar7
            // 
            this.percentageBar7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentageBar7.Location = new System.Drawing.Point(3, 213);
            this.percentageBar7.MaxValue = 100;
            this.percentageBar7.Name = "percentageBar7";
            this.percentageBar7.Size = new System.Drawing.Size(398, 29);
            this.percentageBar7.TabIndex = 6;
            this.percentageBar7.Tag = "9";
            this.percentageBar7.Text = "percentageBar7";
            this.percentageBar7.Value = 30;
            // 
            // percentageBar6
            // 
            this.percentageBar6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentageBar6.Location = new System.Drawing.Point(3, 178);
            this.percentageBar6.MaxValue = 100;
            this.percentageBar6.Name = "percentageBar6";
            this.percentageBar6.Size = new System.Drawing.Size(398, 29);
            this.percentageBar6.TabIndex = 5;
            this.percentageBar6.Tag = "8";
            this.percentageBar6.Text = "percentageBar6";
            this.percentageBar6.Value = 30;
            // 
            // percentageBar5
            // 
            this.percentageBar5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentageBar5.Location = new System.Drawing.Point(3, 143);
            this.percentageBar5.MaxValue = 100;
            this.percentageBar5.Name = "percentageBar5";
            this.percentageBar5.Size = new System.Drawing.Size(398, 29);
            this.percentageBar5.TabIndex = 4;
            this.percentageBar5.Tag = "7";
            this.percentageBar5.Text = "percentageBar5";
            this.percentageBar5.Value = 30;
            // 
            // percentageBar4
            // 
            this.percentageBar4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentageBar4.Location = new System.Drawing.Point(3, 108);
            this.percentageBar4.MaxValue = 100;
            this.percentageBar4.Name = "percentageBar4";
            this.percentageBar4.Size = new System.Drawing.Size(398, 29);
            this.percentageBar4.TabIndex = 3;
            this.percentageBar4.Tag = "6";
            this.percentageBar4.Text = "percentageBar4";
            this.percentageBar4.Value = 30;
            // 
            // percentageBar3
            // 
            this.percentageBar3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentageBar3.Location = new System.Drawing.Point(3, 73);
            this.percentageBar3.MaxValue = 100;
            this.percentageBar3.Name = "percentageBar3";
            this.percentageBar3.Size = new System.Drawing.Size(398, 29);
            this.percentageBar3.TabIndex = 2;
            this.percentageBar3.Tag = "5";
            this.percentageBar3.Text = "percentageBar3";
            this.percentageBar3.Value = 30;
            // 
            // percentageBar2
            // 
            this.percentageBar2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentageBar2.Location = new System.Drawing.Point(3, 38);
            this.percentageBar2.MaxValue = 100;
            this.percentageBar2.Name = "percentageBar2";
            this.percentageBar2.Size = new System.Drawing.Size(398, 29);
            this.percentageBar2.TabIndex = 1;
            this.percentageBar2.Tag = "4";
            this.percentageBar2.Text = "percentageBar2";
            this.percentageBar2.Value = 30;
            this.percentageBar2.Click += new System.EventHandler(this.percentageBar2_Click);
            // 
            // percentageBar1
            // 
            this.percentageBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentageBar1.Location = new System.Drawing.Point(3, 3);
            this.percentageBar1.MaxValue = 100;
            this.percentageBar1.Name = "percentageBar1";
            this.percentageBar1.Size = new System.Drawing.Size(398, 29);
            this.percentageBar1.TabIndex = 0;
            this.percentageBar1.Tag = "3";
            this.percentageBar1.Text = "percentageBar1";
            this.percentageBar1.Value = 30;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(3, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "4:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(3, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 35);
            this.label3.TabIndex = 2;
            this.label3.Text = "5:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(3, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 35);
            this.label4.TabIndex = 3;
            this.label4.Text = "6:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(3, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 35);
            this.label5.TabIndex = 4;
            this.label5.Text = "7:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(3, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 35);
            this.label6.TabIndex = 5;
            this.label6.Text = "8:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(3, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 35);
            this.label7.TabIndex = 6;
            this.label7.Text = "9:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(3, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 35);
            this.label8.TabIndex = 7;
            this.label8.Text = "10:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(3, 280);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 35);
            this.label9.TabIndex = 8;
            this.label9.Text = "11:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(3, 315);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 35);
            this.label10.TabIndex = 9;
            this.label10.Text = "12:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(3, 350);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 35);
            this.label11.TabIndex = 10;
            this.label11.Text = "13:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(3, 385);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 35);
            this.label12.TabIndex = 11;
            this.label12.Text = "14:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(3, 420);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 35);
            this.label13.TabIndex = 12;
            this.label13.Text = "15:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label14.Location = new System.Drawing.Point(3, 455);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 35);
            this.label14.TabIndex = 13;
            this.label14.Text = "16:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label15.Location = new System.Drawing.Point(3, 490);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 35);
            this.label15.TabIndex = 14;
            this.label15.Text = "17:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label16.Location = new System.Drawing.Point(3, 525);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 46);
            this.label16.TabIndex = 15;
            this.label16.Text = "18:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "3:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.buttonSpeed, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.buttonAuto, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(188, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(152, 98);
            this.tableLayoutPanel4.TabIndex = 6;
            // 
            // buttonSpeed
            // 
            this.buttonSpeed.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.buttonSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSpeed.Location = new System.Drawing.Point(3, 52);
            this.buttonSpeed.Name = "buttonSpeed";
            this.buttonSpeed.Size = new System.Drawing.Size(146, 43);
            this.buttonSpeed.TabIndex = 4;
            this.buttonSpeed.Text = "Rychle";
            this.buttonSpeed.UseVisualStyleBackColor = false;
            this.buttonSpeed.Click += new System.EventHandler(this.buttonSpeed_Click);
            // 
            // buttonAuto
            // 
            this.buttonAuto.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.buttonAuto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAuto.Location = new System.Drawing.Point(3, 3);
            this.buttonAuto.Name = "buttonAuto";
            this.buttonAuto.Size = new System.Drawing.Size(146, 43);
            this.buttonAuto.TabIndex = 3;
            this.buttonAuto.Text = "Auto";
            this.buttonAuto.UseVisualStyleBackColor = false;
            this.buttonAuto.Click += new System.EventHandler(this.buttonAuto_Click_1);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 681);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanelBar.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ASE.Controls.MujProtokol log;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonClear;
        private Dice.Dice dice3;
        private Dice.Dice dice2;
        private Dice.Dice dice1;
        private System.Windows.Forms.Label soucet;
        private System.Windows.Forms.Button buttonHod;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button buttonSpeed;
        private System.Windows.Forms.Button buttonAuto;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelBar;
        private PercentagePointerUseControl.PercentageBar percentageBar16;
        private PercentagePointerUseControl.PercentageBar percentageBar15;
        private PercentagePointerUseControl.PercentageBar percentageBar14;
        private PercentagePointerUseControl.PercentageBar percentageBar13;
        private PercentagePointerUseControl.PercentageBar percentageBar12;
        private PercentagePointerUseControl.PercentageBar percentageBar11;
        private PercentagePointerUseControl.PercentageBar percentageBar10;
        private PercentagePointerUseControl.PercentageBar percentageBar9;
        private PercentagePointerUseControl.PercentageBar percentageBar8;
        private PercentagePointerUseControl.PercentageBar percentageBar7;
        private PercentagePointerUseControl.PercentageBar percentageBar6;
        private PercentagePointerUseControl.PercentageBar percentageBar5;
        private PercentagePointerUseControl.PercentageBar percentageBar4;
        private PercentagePointerUseControl.PercentageBar percentageBar3;
        private PercentagePointerUseControl.PercentageBar percentageBar2;
        private PercentagePointerUseControl.PercentageBar percentageBar1;
    }
}

