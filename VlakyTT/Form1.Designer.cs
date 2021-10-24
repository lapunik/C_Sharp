namespace VlakyTT
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonOpenPort = new System.Windows.Forms.Button();
            this.listBoxPackets = new System.Windows.Forms.ListBox();
            this.comboBoxSerialPort = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxstatus = new System.Windows.Forms.TextBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.buttonClosePort = new System.Windows.Forms.Button();
            this.timerReadSerialPort = new System.Windows.Forms.Timer(this.components);
            this.buttonAutoSend = new System.Windows.Forms.Button();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.timerSend = new System.Windows.Forms.Timer(this.components);
            this.barGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tablePanelEngines = new System.Windows.Forms.TableLayoutPanel();
            this.tablePanelStart = new System.Windows.Forms.TableLayoutPanel();
            this.tablePanelSpeed = new System.Windows.Forms.TableLayoutPanel();
            this.tablePanelDirection = new System.Windows.Forms.TableLayoutPanel();
            this.tablePanelName = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddEngine = new System.Windows.Forms.Button();
            this.buttonRemoveEngine = new System.Windows.Forms.Button();
            this.buttonStopShowPackets = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.dataGridTimetable = new System.Windows.Forms.DataGridView();
            this.buttonFormTimetable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.barGraph)).BeginInit();
            this.tablePanelEngines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTimetable)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOpenPort
            // 
            this.buttonOpenPort.Location = new System.Drawing.Point(21, 73);
            this.buttonOpenPort.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOpenPort.Name = "buttonOpenPort";
            this.buttonOpenPort.Size = new System.Drawing.Size(128, 94);
            this.buttonOpenPort.TabIndex = 0;
            this.buttonOpenPort.Text = "Open Port";
            this.buttonOpenPort.UseVisualStyleBackColor = true;
            this.buttonOpenPort.Click += new System.EventHandler(this.buttonOpenPort_Click);
            // 
            // listBoxPackets
            // 
            this.listBoxPackets.FormattingEnabled = true;
            this.listBoxPackets.Location = new System.Drawing.Point(310, 75);
            this.listBoxPackets.Margin = new System.Windows.Forms.Padding(2);
            this.listBoxPackets.Name = "listBoxPackets";
            this.listBoxPackets.Size = new System.Drawing.Size(286, 199);
            this.listBoxPackets.TabIndex = 1;
            // 
            // comboBoxSerialPort
            // 
            this.comboBoxSerialPort.FormattingEnabled = true;
            this.comboBoxSerialPort.Location = new System.Drawing.Point(21, 17);
            this.comboBoxSerialPort.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSerialPort.Name = "comboBoxSerialPort";
            this.comboBoxSerialPort.Size = new System.Drawing.Size(129, 21);
            this.comboBoxSerialPort.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Status";
            // 
            // textBoxstatus
            // 
            this.textBoxstatus.Location = new System.Drawing.Point(18, 197);
            this.textBoxstatus.Name = "textBoxstatus";
            this.textBoxstatus.ReadOnly = true;
            this.textBoxstatus.Size = new System.Drawing.Size(284, 20);
            this.textBoxstatus.TabIndex = 14;
            this.textBoxstatus.Text = "Port is Close";
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 115200;
            this.serialPort.PortName = "COM4";
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // buttonClosePort
            // 
            this.buttonClosePort.Enabled = false;
            this.buttonClosePort.Location = new System.Drawing.Point(176, 73);
            this.buttonClosePort.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClosePort.Name = "buttonClosePort";
            this.buttonClosePort.Size = new System.Drawing.Size(128, 94);
            this.buttonClosePort.TabIndex = 16;
            this.buttonClosePort.Text = "Close Port";
            this.buttonClosePort.UseVisualStyleBackColor = true;
            this.buttonClosePort.Click += new System.EventHandler(this.buttonClosePort_Click);
            // 
            // timerReadSerialPort
            // 
            this.timerReadSerialPort.Interval = 200;
            this.timerReadSerialPort.Tick += new System.EventHandler(this.timerReadSerialPort_Tick);
            // 
            // buttonAutoSend
            // 
            this.buttonAutoSend.Enabled = false;
            this.buttonAutoSend.Location = new System.Drawing.Point(230, 275);
            this.buttonAutoSend.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAutoSend.Name = "buttonAutoSend";
            this.buttonAutoSend.Size = new System.Drawing.Size(70, 29);
            this.buttonAutoSend.TabIndex = 18;
            this.buttonAutoSend.Text = "Auto Send";
            this.buttonAutoSend.UseVisualStyleBackColor = true;
            this.buttonAutoSend.Click += new System.EventHandler(this.buttonAutoSend_Click);
            // 
            // textBoxSend
            // 
            this.textBoxSend.Enabled = false;
            this.textBoxSend.Location = new System.Drawing.Point(21, 226);
            this.textBoxSend.Multiline = true;
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.Size = new System.Drawing.Size(281, 44);
            this.textBoxSend.TabIndex = 19;
            // 
            // timerSend
            // 
            this.timerSend.Interval = 25;
            this.timerSend.Tick += new System.EventHandler(this.timerSend_Tick);
            // 
            // barGraph
            // 
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX.Title = "Section";
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            chartArea1.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.Title = "Current";
            chartArea1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.BottomLeft;
            chartArea1.Name = "ChartArea1";
            this.barGraph.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.barGraph.Legends.Add(legend1);
            this.barGraph.Location = new System.Drawing.Point(1186, 73);
            this.barGraph.Margin = new System.Windows.Forms.Padding(2);
            this.barGraph.Name = "barGraph";
            this.barGraph.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Black;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Section";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.Points.Add(dataPoint5);
            series1.Points.Add(dataPoint6);
            series1.Points.Add(dataPoint7);
            series1.Points.Add(dataPoint8);
            this.barGraph.Series.Add(series1);
            this.barGraph.Size = new System.Drawing.Size(284, 507);
            this.barGraph.TabIndex = 17;
            this.barGraph.Text = "chart1";
            // 
            // tablePanelEngines
            // 
            this.tablePanelEngines.ColumnCount = 4;
            this.tablePanelEngines.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.21784F));
            this.tablePanelEngines.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.52487F));
            this.tablePanelEngines.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.79074F));
            this.tablePanelEngines.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.8096F));
            this.tablePanelEngines.Controls.Add(this.tablePanelStart, 3, 0);
            this.tablePanelEngines.Controls.Add(this.tablePanelSpeed, 2, 0);
            this.tablePanelEngines.Controls.Add(this.tablePanelDirection, 1, 0);
            this.tablePanelEngines.Controls.Add(this.tablePanelName, 0, 0);
            this.tablePanelEngines.Location = new System.Drawing.Point(608, 73);
            this.tablePanelEngines.Margin = new System.Windows.Forms.Padding(2);
            this.tablePanelEngines.Name = "tablePanelEngines";
            this.tablePanelEngines.RowCount = 1;
            this.tablePanelEngines.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanelEngines.Size = new System.Drawing.Size(574, 509);
            this.tablePanelEngines.TabIndex = 24;
            // 
            // tablePanelStart
            // 
            this.tablePanelStart.ColumnCount = 1;
            this.tablePanelStart.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanelStart.Location = new System.Drawing.Point(478, 2);
            this.tablePanelStart.Margin = new System.Windows.Forms.Padding(2);
            this.tablePanelStart.Name = "tablePanelStart";
            this.tablePanelStart.RowCount = 1;
            this.tablePanelStart.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelStart.Size = new System.Drawing.Size(94, 505);
            this.tablePanelStart.TabIndex = 27;
            // 
            // tablePanelSpeed
            // 
            this.tablePanelSpeed.ColumnCount = 1;
            this.tablePanelSpeed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanelSpeed.Location = new System.Drawing.Point(285, 2);
            this.tablePanelSpeed.Margin = new System.Windows.Forms.Padding(2);
            this.tablePanelSpeed.Name = "tablePanelSpeed";
            this.tablePanelSpeed.RowCount = 1;
            this.tablePanelSpeed.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelSpeed.Size = new System.Drawing.Size(189, 505);
            this.tablePanelSpeed.TabIndex = 26;
            // 
            // tablePanelDirection
            // 
            this.tablePanelDirection.ColumnCount = 1;
            this.tablePanelDirection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanelDirection.Location = new System.Drawing.Point(180, 2);
            this.tablePanelDirection.Margin = new System.Windows.Forms.Padding(2);
            this.tablePanelDirection.Name = "tablePanelDirection";
            this.tablePanelDirection.RowCount = 1;
            this.tablePanelDirection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelDirection.Size = new System.Drawing.Size(101, 505);
            this.tablePanelDirection.TabIndex = 25;
            // 
            // tablePanelName
            // 
            this.tablePanelName.ColumnCount = 1;
            this.tablePanelName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanelName.Location = new System.Drawing.Point(2, 2);
            this.tablePanelName.Margin = new System.Windows.Forms.Padding(2);
            this.tablePanelName.Name = "tablePanelName";
            this.tablePanelName.RowCount = 1;
            this.tablePanelName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 512F));
            this.tablePanelName.Size = new System.Drawing.Size(174, 505);
            this.tablePanelName.TabIndex = 24;
            // 
            // buttonAddEngine
            // 
            this.buttonAddEngine.Enabled = false;
            this.buttonAddEngine.Location = new System.Drawing.Point(608, 17);
            this.buttonAddEngine.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAddEngine.Name = "buttonAddEngine";
            this.buttonAddEngine.Size = new System.Drawing.Size(98, 50);
            this.buttonAddEngine.TabIndex = 26;
            this.buttonAddEngine.Text = "Add Engine";
            this.buttonAddEngine.UseVisualStyleBackColor = true;
            this.buttonAddEngine.Click += new System.EventHandler(this.buttonAddEngine_Click);
            // 
            // buttonRemoveEngine
            // 
            this.buttonRemoveEngine.Enabled = false;
            this.buttonRemoveEngine.Location = new System.Drawing.Point(710, 17);
            this.buttonRemoveEngine.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRemoveEngine.Name = "buttonRemoveEngine";
            this.buttonRemoveEngine.Size = new System.Drawing.Size(98, 50);
            this.buttonRemoveEngine.TabIndex = 27;
            this.buttonRemoveEngine.Text = "Remove Engine";
            this.buttonRemoveEngine.UseVisualStyleBackColor = true;
            this.buttonRemoveEngine.Click += new System.EventHandler(this.buttonRemoveEngine_Click);
            // 
            // buttonStopShowPackets
            // 
            this.buttonStopShowPackets.Enabled = false;
            this.buttonStopShowPackets.Location = new System.Drawing.Point(526, 275);
            this.buttonStopShowPackets.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStopShowPackets.Name = "buttonStopShowPackets";
            this.buttonStopShowPackets.Size = new System.Drawing.Size(70, 29);
            this.buttonStopShowPackets.TabIndex = 28;
            this.buttonStopShowPackets.Text = "Stop";
            this.buttonStopShowPackets.UseVisualStyleBackColor = true;
            this.buttonStopShowPackets.Click += new System.EventHandler(this.ButtonStopShowPackets_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Enabled = false;
            this.buttonSend.Location = new System.Drawing.Point(156, 275);
            this.buttonSend.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(70, 29);
            this.buttonSend.TabIndex = 29;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // dataGridTimetable
            // 
            this.dataGridTimetable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTimetable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTimetable.Location = new System.Drawing.Point(18, 315);
            this.dataGridTimetable.Name = "dataGridTimetable";
            this.dataGridTimetable.Size = new System.Drawing.Size(578, 210);
            this.dataGridTimetable.TabIndex = 30;
            // 
            // buttonFormTimetable
            // 
            this.buttonFormTimetable.Enabled = false;
            this.buttonFormTimetable.Location = new System.Drawing.Point(498, 532);
            this.buttonFormTimetable.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFormTimetable.Name = "buttonFormTimetable";
            this.buttonFormTimetable.Size = new System.Drawing.Size(98, 50);
            this.buttonFormTimetable.TabIndex = 32;
            this.buttonFormTimetable.Text = "Start Timetable";
            this.buttonFormTimetable.UseVisualStyleBackColor = true;
            this.buttonFormTimetable.Click += new System.EventHandler(this.buttonFormTimetable_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 598);
            this.Controls.Add(this.buttonFormTimetable);
            this.Controls.Add(this.dataGridTimetable);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonStopShowPackets);
            this.Controls.Add(this.buttonRemoveEngine);
            this.Controls.Add(this.buttonAddEngine);
            this.Controls.Add(this.tablePanelEngines);
            this.Controls.Add(this.textBoxSend);
            this.Controls.Add(this.buttonAutoSend);
            this.Controls.Add(this.barGraph);
            this.Controls.Add(this.buttonClosePort);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxstatus);
            this.Controls.Add(this.comboBoxSerialPort);
            this.Controls.Add(this.listBoxPackets);
            this.Controls.Add(this.buttonOpenPort);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Train TT";
            ((System.ComponentModel.ISupportInitialize)(this.barGraph)).EndInit();
            this.tablePanelEngines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTimetable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenPort;
        private System.Windows.Forms.ListBox listBoxPackets;
        private System.Windows.Forms.ComboBox comboBoxSerialPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxstatus;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Button buttonClosePort;
        private System.Windows.Forms.Timer timerReadSerialPort;
        private System.Windows.Forms.DataVisualization.Charting.Chart barGraph;
        private System.Windows.Forms.Button buttonAutoSend;
        private System.Windows.Forms.TextBox textBoxSend;
        private System.Windows.Forms.Timer timerSend;
        private System.Windows.Forms.TableLayoutPanel tablePanelEngines;
        private System.Windows.Forms.Button buttonAddEngine;
        private System.Windows.Forms.Button buttonRemoveEngine;
        private System.Windows.Forms.TableLayoutPanel tablePanelStart;
        private System.Windows.Forms.TableLayoutPanel tablePanelSpeed;
        private System.Windows.Forms.TableLayoutPanel tablePanelDirection;
        private System.Windows.Forms.TableLayoutPanel tablePanelName;
        private System.Windows.Forms.Button buttonStopShowPackets;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.DataGridView dataGridTimetable;
        private System.Windows.Forms.Button buttonFormTimetable;
    }
}

