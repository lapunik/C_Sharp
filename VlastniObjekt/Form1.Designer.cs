namespace SeriovyPort
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
            this.grid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxAutoSet = new System.Windows.Forms.CheckBox();
            this.buttonAddData = new System.Windows.Forms.Button();
            this.buttonChange5 = new System.Windows.Forms.Button();
            this.buttonFirst10 = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.log);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grid);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1065, 622);
            this.splitContainer1.SplitterDistance = 354;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // log
            // 
            this.log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.log.FormattingEnabled = true;
            this.log.Location = new System.Drawing.Point(0, 0);
            this.log.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(354, 622);
            this.log.TabIndex = 0;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 81);
            this.grid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grid.Name = "grid";
            this.grid.RowTemplate.Height = 24;
            this.grid.Size = new System.Drawing.Size(708, 541);
            this.grid.TabIndex = 1;
            this.grid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grid_DataError);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.checkBoxAutoSet);
            this.panel1.Controls.Add(this.buttonAddData);
            this.panel1.Controls.Add(this.buttonChange5);
            this.panel1.Controls.Add(this.buttonFirst10);
            this.panel1.Controls.Add(this.buttonLoad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 81);
            this.panel1.TabIndex = 0;
            // 
            // checkBoxAutoSet
            // 
            this.checkBoxAutoSet.AutoSize = true;
            this.checkBoxAutoSet.Location = new System.Drawing.Point(615, 32);
            this.checkBoxAutoSet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxAutoSet.Name = "checkBoxAutoSet";
            this.checkBoxAutoSet.Size = new System.Drawing.Size(64, 17);
            this.checkBoxAutoSet.TabIndex = 4;
            this.checkBoxAutoSet.Text = "AutoSet";
            this.checkBoxAutoSet.UseVisualStyleBackColor = true;
            this.checkBoxAutoSet.CheckedChanged += new System.EventHandler(this.checkBoxAutoSet_CheckedChanged);
            // 
            // buttonAddData
            // 
            this.buttonAddData.Location = new System.Drawing.Point(448, 2);
            this.buttonAddData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAddData.Name = "buttonAddData";
            this.buttonAddData.Size = new System.Drawing.Size(144, 74);
            this.buttonAddData.TabIndex = 3;
            this.buttonAddData.Text = "Add Data";
            this.buttonAddData.UseVisualStyleBackColor = true;
            this.buttonAddData.Click += new System.EventHandler(this.buttonAddData_Click);
            // 
            // buttonChange5
            // 
            this.buttonChange5.Location = new System.Drawing.Point(299, 2);
            this.buttonChange5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonChange5.Name = "buttonChange5";
            this.buttonChange5.Size = new System.Drawing.Size(144, 74);
            this.buttonChange5.TabIndex = 2;
            this.buttonChange5.Text = "Change 5";
            this.buttonChange5.UseVisualStyleBackColor = true;
            this.buttonChange5.Click += new System.EventHandler(this.buttonChange5_Click);
            // 
            // buttonFirst10
            // 
            this.buttonFirst10.Location = new System.Drawing.Point(151, 2);
            this.buttonFirst10.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFirst10.Name = "buttonFirst10";
            this.buttonFirst10.Size = new System.Drawing.Size(144, 74);
            this.buttonFirst10.TabIndex = 1;
            this.buttonFirst10.Text = "First 10";
            this.buttonFirst10.UseVisualStyleBackColor = true;
            this.buttonFirst10.Click += new System.EventHandler(this.buttonFirst10_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(2, 2);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(144, 74);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 622);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ASE.Controls.MujProtokol log;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonFirst10;
        private System.Windows.Forms.Button buttonChange5;
        private System.Windows.Forms.Button buttonAddData;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBoxAutoSet;
    }
}

