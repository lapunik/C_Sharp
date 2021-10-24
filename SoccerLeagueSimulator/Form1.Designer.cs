namespace SoccerLeagueSimulator
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
            this.tableLayoutPanelControls = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPlayersTeamsTable = new System.Windows.Forms.Button();
            this.buttonLoadData = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonStat = new System.Windows.Forms.Button();
            this.buttonShowRoster = new System.Windows.Forms.Button();
            this.comboBoxTeams = new System.Windows.Forms.ComboBox();
            this.labelGameMin = new System.Windows.Forms.Label();
            this.buttonSimulate = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSlow = new System.Windows.Forms.Button();
            this.buttonFast = new System.Windows.Forms.Button();
            this.tableLayoutPanelDataGrid = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewStandings = new System.Windows.Forms.DataGridView();
            this.dataGridViewScore = new System.Windows.Forms.DataGridView();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.log = new ASE.Controls.MujProtokol();
            this.tableLayoutPanelControls.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanelDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStandings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelControls
            // 
            this.tableLayoutPanelControls.ColumnCount = 6;
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelControls.Controls.Add(this.buttonPlayersTeamsTable, 0, 0);
            this.tableLayoutPanelControls.Controls.Add(this.buttonLoadData, 0, 0);
            this.tableLayoutPanelControls.Controls.Add(this.tableLayoutPanel1, 2, 0);
            this.tableLayoutPanelControls.Controls.Add(this.labelGameMin, 5, 0);
            this.tableLayoutPanelControls.Controls.Add(this.buttonSimulate, 4, 0);
            this.tableLayoutPanelControls.Controls.Add(this.tableLayoutPanel2, 3, 0);
            this.tableLayoutPanelControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelControls.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelControls.Name = "tableLayoutPanelControls";
            this.tableLayoutPanelControls.RowCount = 1;
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelControls.Size = new System.Drawing.Size(1178, 97);
            this.tableLayoutPanelControls.TabIndex = 1;
            // 
            // buttonPlayersTeamsTable
            // 
            this.buttonPlayersTeamsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPlayersTeamsTable.Enabled = false;
            this.buttonPlayersTeamsTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonPlayersTeamsTable.Location = new System.Drawing.Point(199, 3);
            this.buttonPlayersTeamsTable.Name = "buttonPlayersTeamsTable";
            this.buttonPlayersTeamsTable.Size = new System.Drawing.Size(190, 91);
            this.buttonPlayersTeamsTable.TabIndex = 4;
            this.buttonPlayersTeamsTable.Text = "Players";
            this.buttonPlayersTeamsTable.UseVisualStyleBackColor = true;
            this.buttonPlayersTeamsTable.Click += new System.EventHandler(this.buttonPlayersTeamsTable_Click);
            // 
            // buttonLoadData
            // 
            this.buttonLoadData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLoadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLoadData.Location = new System.Drawing.Point(3, 3);
            this.buttonLoadData.Name = "buttonLoadData";
            this.buttonLoadData.Size = new System.Drawing.Size(190, 91);
            this.buttonLoadData.TabIndex = 0;
            this.buttonLoadData.Text = "Load League";
            this.buttonLoadData.UseVisualStyleBackColor = true;
            this.buttonLoadData.Click += new System.EventHandler(this.buttonLoadData_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.buttonStat, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonShowRoster, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxTeams, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(395, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(190, 91);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // buttonStat
            // 
            this.buttonStat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStat.Enabled = false;
            this.buttonStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonStat.Location = new System.Drawing.Point(3, 48);
            this.buttonStat.Name = "buttonStat";
            this.buttonStat.Size = new System.Drawing.Size(89, 40);
            this.buttonStat.TabIndex = 3;
            this.buttonStat.Text = "Statistics";
            this.buttonStat.UseVisualStyleBackColor = true;
            this.buttonStat.Click += new System.EventHandler(this.buttonStat_Click);
            // 
            // buttonShowRoster
            // 
            this.buttonShowRoster.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonShowRoster.Enabled = false;
            this.buttonShowRoster.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonShowRoster.Location = new System.Drawing.Point(98, 48);
            this.buttonShowRoster.Name = "buttonShowRoster";
            this.buttonShowRoster.Size = new System.Drawing.Size(89, 40);
            this.buttonShowRoster.TabIndex = 2;
            this.buttonShowRoster.Text = "Roster";
            this.buttonShowRoster.UseVisualStyleBackColor = true;
            this.buttonShowRoster.Click += new System.EventHandler(this.buttonShowRoster_Click);
            // 
            // comboBoxTeams
            // 
            this.comboBoxTeams.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.SetColumnSpan(this.comboBoxTeams, 2);
            this.comboBoxTeams.Enabled = false;
            this.comboBoxTeams.FormattingEnabled = true;
            this.comboBoxTeams.Location = new System.Drawing.Point(3, 12);
            this.comboBoxTeams.Name = "comboBoxTeams";
            this.comboBoxTeams.Size = new System.Drawing.Size(184, 21);
            this.comboBoxTeams.TabIndex = 0;
            // 
            // labelGameMin
            // 
            this.labelGameMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelGameMin.Location = new System.Drawing.Point(983, 0);
            this.labelGameMin.Name = "labelGameMin";
            this.labelGameMin.Size = new System.Drawing.Size(185, 97);
            this.labelGameMin.TabIndex = 2;
            this.labelGameMin.Text = "Game: 1 min: 0";
            this.labelGameMin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSimulate
            // 
            this.buttonSimulate.Enabled = false;
            this.buttonSimulate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSimulate.Location = new System.Drawing.Point(787, 3);
            this.buttonSimulate.Name = "buttonSimulate";
            this.buttonSimulate.Size = new System.Drawing.Size(190, 91);
            this.buttonSimulate.TabIndex = 1;
            this.buttonSimulate.Text = "Simulate";
            this.buttonSimulate.UseVisualStyleBackColor = true;
            this.buttonSimulate.Click += new System.EventHandler(this.buttonSimulate_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.buttonSlow, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonFast, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(591, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(190, 91);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // buttonSlow
            // 
            this.buttonSlow.Enabled = false;
            this.buttonSlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSlow.Location = new System.Drawing.Point(3, 48);
            this.buttonSlow.Name = "buttonSlow";
            this.buttonSlow.Size = new System.Drawing.Size(183, 40);
            this.buttonSlow.TabIndex = 3;
            this.buttonSlow.Text = "Slow";
            this.buttonSlow.UseVisualStyleBackColor = true;
            this.buttonSlow.Click += new System.EventHandler(this.buttonSlow_Click);
            // 
            // buttonFast
            // 
            this.buttonFast.Enabled = false;
            this.buttonFast.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonFast.Location = new System.Drawing.Point(3, 3);
            this.buttonFast.Name = "buttonFast";
            this.buttonFast.Size = new System.Drawing.Size(183, 39);
            this.buttonFast.TabIndex = 2;
            this.buttonFast.Text = "Fast";
            this.buttonFast.UseVisualStyleBackColor = true;
            this.buttonFast.Click += new System.EventHandler(this.buttonFast_Click);
            // 
            // tableLayoutPanelDataGrid
            // 
            this.tableLayoutPanelDataGrid.ColumnCount = 2;
            this.tableLayoutPanelDataGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDataGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDataGrid.Controls.Add(this.dataGridViewStandings, 0, 0);
            this.tableLayoutPanelDataGrid.Controls.Add(this.dataGridViewScore, 1, 0);
            this.tableLayoutPanelDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelDataGrid.Location = new System.Drawing.Point(0, 97);
            this.tableLayoutPanelDataGrid.Name = "tableLayoutPanelDataGrid";
            this.tableLayoutPanelDataGrid.RowCount = 1;
            this.tableLayoutPanelDataGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelDataGrid.Size = new System.Drawing.Size(1178, 499);
            this.tableLayoutPanelDataGrid.TabIndex = 2;
            // 
            // dataGridViewStandings
            // 
            this.dataGridViewStandings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStandings.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewStandings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStandings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStandings.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewStandings.Name = "dataGridViewStandings";
            this.dataGridViewStandings.Size = new System.Drawing.Size(583, 493);
            this.dataGridViewStandings.TabIndex = 0;
            // 
            // dataGridViewScore
            // 
            this.dataGridViewScore.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewScore.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewScore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewScore.Location = new System.Drawing.Point(592, 3);
            this.dataGridViewScore.Name = "dataGridViewScore";
            this.dataGridViewScore.Size = new System.Drawing.Size(583, 493);
            this.dataGridViewScore.TabIndex = 1;
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
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
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanelDataGrid);
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanelControls);
            this.splitContainer1.Size = new System.Drawing.Size(1528, 596);
            this.splitContainer1.SplitterDistance = 346;
            this.splitContainer1.TabIndex = 3;
            // 
            // log
            // 
            this.log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.log.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.log.FormattingEnabled = true;
            this.log.ItemHeight = 20;
            this.log.Location = new System.Drawing.Point(0, 0);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(346, 596);
            this.log.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1528, 596);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanelControls.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanelDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStandings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScore)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ASE.Controls.MujProtokol log;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelControls;
        private System.Windows.Forms.Button buttonLoadData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDataGrid;
        private System.Windows.Forms.DataGridView dataGridViewStandings;
        private System.Windows.Forms.DataGridView dataGridViewScore;
        private System.Windows.Forms.Button buttonSimulate;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label labelGameMin;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonShowRoster;
        private System.Windows.Forms.ComboBox comboBoxTeams;
        private System.Windows.Forms.Button buttonPlayersTeamsTable;
        private System.Windows.Forms.Button buttonStat;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonSlow;
        private System.Windows.Forms.Button buttonFast;
    }
}

