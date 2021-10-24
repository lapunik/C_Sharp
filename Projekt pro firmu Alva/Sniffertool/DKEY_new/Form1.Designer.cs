namespace DKEY_new
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.button_clear_log = new System.Windows.Forms.Button();
            this.button_connect = new System.Windows.Forms.Button();
            this.button_import = new System.Windows.Forms.Button();
            this.button_time_reset = new System.Windows.Forms.Button();
            this.checkBox_auto_scroll = new System.Windows.Forms.CheckBox();
            this.button_help = new System.Windows.Forms.Button();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button_connect5 = new System.Windows.Forms.Button();
            this.button_connect4 = new System.Windows.Forms.Button();
            this.button_connect3 = new System.Windows.Forms.Button();
            this.button_connect2 = new System.Windows.Forms.Button();
            this.button_connect1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listView1 = new DKEY_new.ListViewNF();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.listView1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1352, 445);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(180, 445);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.button_clear_log, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.button_connect, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.button_import, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.button_time_reset, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.checkBox_auto_scroll, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.button_help, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.buttonFilter, 0, 5);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 140);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 8;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(180, 305);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // button_clear_log
            // 
            this.button_clear_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_clear_log.Location = new System.Drawing.Point(3, 33);
            this.button_clear_log.Name = "button_clear_log";
            this.button_clear_log.Size = new System.Drawing.Size(174, 24);
            this.button_clear_log.TabIndex = 1;
            this.button_clear_log.Text = "Clear list";
            this.button_clear_log.UseVisualStyleBackColor = true;
            this.button_clear_log.Click += new System.EventHandler(this.button_clear_log_Click);
            // 
            // button_connect
            // 
            this.button_connect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_connect.Location = new System.Drawing.Point(3, 3);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(174, 24);
            this.button_connect.TabIndex = 0;
            this.button_connect.Text = "Connect All";
            this.button_connect.UseVisualStyleBackColor = true;
            this.button_connect.Click += new System.EventHandler(this.button_connect_all_Click);
            // 
            // button_import
            // 
            this.button_import.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_import.Location = new System.Drawing.Point(3, 63);
            this.button_import.Name = "button_import";
            this.button_import.Size = new System.Drawing.Size(174, 24);
            this.button_import.TabIndex = 4;
            this.button_import.Text = "Import log file";
            this.button_import.UseVisualStyleBackColor = true;
            this.button_import.Click += new System.EventHandler(this.button_import_Click);
            // 
            // button_time_reset
            // 
            this.button_time_reset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_time_reset.Enabled = false;
            this.button_time_reset.Location = new System.Drawing.Point(3, 93);
            this.button_time_reset.Name = "button_time_reset";
            this.button_time_reset.Size = new System.Drawing.Size(174, 24);
            this.button_time_reset.TabIndex = 3;
            this.button_time_reset.Text = "Time reset";
            this.button_time_reset.UseVisualStyleBackColor = true;
            this.button_time_reset.Click += new System.EventHandler(this.button_time_reset_Click);
            // 
            // checkBox_auto_scroll
            // 
            this.checkBox_auto_scroll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_auto_scroll.Checked = true;
            this.checkBox_auto_scroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_auto_scroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_auto_scroll.Location = new System.Drawing.Point(3, 123);
            this.checkBox_auto_scroll.Name = "checkBox_auto_scroll";
            this.checkBox_auto_scroll.Size = new System.Drawing.Size(174, 24);
            this.checkBox_auto_scroll.TabIndex = 5;
            this.checkBox_auto_scroll.Text = "Auto scroll";
            this.checkBox_auto_scroll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox_auto_scroll.UseVisualStyleBackColor = true;
            // 
            // button_help
            // 
            this.button_help.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_help.Location = new System.Drawing.Point(3, 183);
            this.button_help.Name = "button_help";
            this.button_help.Size = new System.Drawing.Size(174, 24);
            this.button_help.TabIndex = 6;
            this.button_help.Text = "Help";
            this.button_help.UseVisualStyleBackColor = true;
            this.button_help.Click += new System.EventHandler(this.button_help_Click);
            // 
            // buttonFilter
            // 
            this.buttonFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFilter.Location = new System.Drawing.Point(3, 153);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(174, 24);
            this.buttonFilter.TabIndex = 7;
            this.buttonFilter.Text = "Filter";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(180, 140);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.comboBox1, 0, 4);
            this.tableLayoutPanel6.Controls.Add(this.comboBox2, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.comboBox3, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.comboBox4, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.comboBox5, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 5;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(90, 140);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.LightCoral;
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 115);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(84, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Tag = "0";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            this.comboBox1.Click += new System.EventHandler(this.comboBox5_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.LightCoral;
            this.comboBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(3, 87);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(84, 21);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.Tag = "1";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            this.comboBox2.SelectedValueChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            this.comboBox2.TextChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            this.comboBox2.Click += new System.EventHandler(this.comboBox5_Click);
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.Color.LightCoral;
            this.comboBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(3, 59);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(84, 21);
            this.comboBox3.TabIndex = 2;
            this.comboBox3.Tag = "2";
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            this.comboBox3.SelectedValueChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            this.comboBox3.TextChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            this.comboBox3.Click += new System.EventHandler(this.comboBox5_Click);
            // 
            // comboBox4
            // 
            this.comboBox4.BackColor = System.Drawing.Color.LightCoral;
            this.comboBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Location = new System.Drawing.Point(3, 31);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(84, 21);
            this.comboBox4.TabIndex = 3;
            this.comboBox4.Tag = "3";
            this.comboBox4.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            this.comboBox4.SelectedValueChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            this.comboBox4.TextChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            this.comboBox4.Click += new System.EventHandler(this.comboBox5_Click);
            // 
            // comboBox5
            // 
            this.comboBox5.BackColor = System.Drawing.Color.LightCoral;
            this.comboBox5.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(3, 3);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(84, 21);
            this.comboBox5.TabIndex = 4;
            this.comboBox5.Tag = "4";
            this.comboBox5.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            this.comboBox5.SelectedValueChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            this.comboBox5.TextChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            this.comboBox5.Click += new System.EventHandler(this.comboBox5_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.button_connect5, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.button_connect4, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.button_connect3, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.button_connect2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.button_connect1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(90, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(90, 140);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // button_connect5
            // 
            this.button_connect5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_connect5.Location = new System.Drawing.Point(3, 115);
            this.button_connect5.Name = "button_connect5";
            this.button_connect5.Size = new System.Drawing.Size(84, 22);
            this.button_connect5.TabIndex = 0;
            this.button_connect5.Text = "Connect";
            this.button_connect5.UseVisualStyleBackColor = true;
            this.button_connect5.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // button_connect4
            // 
            this.button_connect4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_connect4.Location = new System.Drawing.Point(3, 87);
            this.button_connect4.Name = "button_connect4";
            this.button_connect4.Size = new System.Drawing.Size(84, 22);
            this.button_connect4.TabIndex = 1;
            this.button_connect4.Text = "Connect";
            this.button_connect4.UseVisualStyleBackColor = true;
            this.button_connect4.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // button_connect3
            // 
            this.button_connect3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_connect3.Location = new System.Drawing.Point(3, 59);
            this.button_connect3.Name = "button_connect3";
            this.button_connect3.Size = new System.Drawing.Size(84, 22);
            this.button_connect3.TabIndex = 2;
            this.button_connect3.Text = "Connect";
            this.button_connect3.UseVisualStyleBackColor = true;
            this.button_connect3.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // button_connect2
            // 
            this.button_connect2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_connect2.Location = new System.Drawing.Point(3, 31);
            this.button_connect2.Name = "button_connect2";
            this.button_connect2.Size = new System.Drawing.Size(84, 22);
            this.button_connect2.TabIndex = 3;
            this.button_connect2.Text = "Connect";
            this.button_connect2.UseVisualStyleBackColor = true;
            this.button_connect2.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // button_connect1
            // 
            this.button_connect1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_connect1.Location = new System.Drawing.Point(3, 3);
            this.button_connect1.Name = "button_connect1";
            this.button_connect1.Size = new System.Drawing.Size(84, 22);
            this.button_connect1.TabIndex = 4;
            this.button_connect1.Text = "Connect";
            this.button_connect1.UseVisualStyleBackColor = true;
            this.button_connect1.Click += new System.EventHandler(this.button_connect_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 102;
            this.dataGridView1.Size = new System.Drawing.Size(1, 439);
            this.dataGridView1.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(183, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1166, 439);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date and Time";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Timestamp";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Type";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Data";
            this.columnHeader4.Width = 400;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Value";
            this.columnHeader5.Width = 800;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 445);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "DKEY Sniffertool v3.1.5rc2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.Button button_time_reset;
        private System.Windows.Forms.Button button_clear_log;
        private System.Windows.Forms.Button button_import;
        private System.Windows.Forms.CheckBox checkBox_auto_scroll;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button_connect5;
        private System.Windows.Forms.Button button_connect4;
        private System.Windows.Forms.Button button_connect3;
        private System.Windows.Forms.Button button_connect2;
        private System.Windows.Forms.Button button_connect1;
        private ListViewNF listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Button button_help;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

