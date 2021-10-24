namespace Dialogy
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
            this.buttonSet2 = new System.Windows.Forms.Button();
            this.buttonSetShow = new System.Windows.Forms.Button();
            this.checkBoxTimer = new System.Windows.Forms.CheckBox();
            this.buttonSet = new System.Windows.Forms.Button();
            this.buttonColor = new System.Windows.Forms.Button();
            this.timer100ms = new System.Windows.Forms.Timer(this.components);
            this.log = new ASE.Controls.MujProtokol();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.buttonSet2);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSetShow);
            this.splitContainer1.Panel2.Controls.Add(this.checkBoxTimer);
            this.splitContainer1.Panel2.Controls.Add(this.buttonSet);
            this.splitContainer1.Panel2.Controls.Add(this.buttonColor);
            this.splitContainer1.Size = new System.Drawing.Size(665, 366);
            this.splitContainer1.SplitterDistance = 306;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // buttonSet2
            // 
            this.buttonSet2.Location = new System.Drawing.Point(194, 253);
            this.buttonSet2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSet2.Name = "buttonSet2";
            this.buttonSet2.Size = new System.Drawing.Size(152, 103);
            this.buttonSet2.TabIndex = 4;
            this.buttonSet2.Text = "Vice Nastaveni";
            this.buttonSet2.UseVisualStyleBackColor = true;
            this.buttonSet2.Click += new System.EventHandler(this.buttonSet2_Click);
            // 
            // buttonSetShow
            // 
            this.buttonSetShow.Location = new System.Drawing.Point(194, 126);
            this.buttonSetShow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSetShow.Name = "buttonSetShow";
            this.buttonSetShow.Size = new System.Drawing.Size(152, 103);
            this.buttonSetShow.TabIndex = 3;
            this.buttonSetShow.Text = "Nastaveni jen Show";
            this.buttonSetShow.UseVisualStyleBackColor = true;
            this.buttonSetShow.Click += new System.EventHandler(this.buttonSetShow_Click);
            // 
            // checkBoxTimer
            // 
            this.checkBoxTimer.AutoSize = true;
            this.checkBoxTimer.Location = new System.Drawing.Point(9, 126);
            this.checkBoxTimer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxTimer.Name = "checkBoxTimer";
            this.checkBoxTimer.Size = new System.Drawing.Size(77, 17);
            this.checkBoxTimer.TabIndex = 2;
            this.checkBoxTimer.Text = "Timer Start";
            this.checkBoxTimer.UseVisualStyleBackColor = true;
            this.checkBoxTimer.CheckedChanged += new System.EventHandler(this.checkBoxTimer_CheckedChanged);
            // 
            // buttonSet
            // 
            this.buttonSet.Location = new System.Drawing.Point(194, 10);
            this.buttonSet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(152, 103);
            this.buttonSet.TabIndex = 1;
            this.buttonSet.Text = "Nastaveni";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // buttonColor
            // 
            this.buttonColor.Location = new System.Drawing.Point(9, 10);
            this.buttonColor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(152, 103);
            this.buttonColor.TabIndex = 0;
            this.buttonColor.Text = "Barva";
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // timer100ms
            // 
            this.timer100ms.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // log
            // 
            this.log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.log.FormattingEnabled = true;
            this.log.Location = new System.Drawing.Point(0, 0);
            this.log.Margin = new System.Windows.Forms.Padding(2);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(306, 366);
            this.log.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 366);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonColor;
        private ASE.Controls.MujProtokol log;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.Timer timer100ms;
        private System.Windows.Forms.CheckBox checkBoxTimer;
        private System.Windows.Forms.Button buttonSetShow;
        private System.Windows.Forms.Button buttonSet2;
    }
}

