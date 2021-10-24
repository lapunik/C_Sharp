namespace Protokol
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
            this.lbProtokol = new System.Windows.Forms.ListBox();
            this.numericPocet = new System.Windows.Forms.NumericUpDown();
            this.chkRunTimer = new System.Windows.Forms.CheckBox();
            this.chkAddToTop = new System.Windows.Forms.CheckBox();
            this.btnAction = new System.Windows.Forms.Button();
            this.timer100ms = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPocet)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.lbProtokol);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.numericPocet);
            this.splitContainer1.Panel2.Controls.Add(this.chkRunTimer);
            this.splitContainer1.Panel2.Controls.Add(this.chkAddToTop);
            this.splitContainer1.Panel2.Controls.Add(this.btnAction);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // lbProtokol
            // 
            this.lbProtokol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbProtokol.FormattingEnabled = true;
            this.lbProtokol.ItemHeight = 16;
            this.lbProtokol.Location = new System.Drawing.Point(0, 0);
            this.lbProtokol.Name = "lbProtokol";
            this.lbProtokol.Size = new System.Drawing.Size(266, 450);
            this.lbProtokol.TabIndex = 0;
            // 
            // numericPocet
            // 
            this.numericPocet.Location = new System.Drawing.Point(15, 233);
            this.numericPocet.Name = "numericPocet";
            this.numericPocet.Size = new System.Drawing.Size(120, 22);
            this.numericPocet.TabIndex = 3;
            this.numericPocet.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // chkRunTimer
            // 
            this.chkRunTimer.AutoSize = true;
            this.chkRunTimer.Location = new System.Drawing.Point(15, 206);
            this.chkRunTimer.Name = "chkRunTimer";
            this.chkRunTimer.Size = new System.Drawing.Size(96, 21);
            this.chkRunTimer.TabIndex = 2;
            this.chkRunTimer.Text = "Timer běží";
            this.chkRunTimer.UseVisualStyleBackColor = true;
            this.chkRunTimer.CheckedChanged += new System.EventHandler(this.chkRunTimer_CheckedChanged);
            // 
            // chkAddToTop
            // 
            this.chkAddToTop.AutoSize = true;
            this.chkAddToTop.Location = new System.Drawing.Point(15, 179);
            this.chkAddToTop.Name = "chkAddToTop";
            this.chkAddToTop.Size = new System.Drawing.Size(154, 21);
            this.chkAddToTop.TabIndex = 1;
            this.chkAddToTop.Text = "Přidávej na začátek";
            this.chkAddToTop.UseVisualStyleBackColor = true;
            // 
            // btnAction
            // 
            this.btnAction.Location = new System.Drawing.Point(15, 12);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(171, 137);
            this.btnAction.TabIndex = 0;
            this.btnAction.Text = "Akce";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // timer100ms
            // 
            this.timer100ms.Tick += new System.EventHandler(this.timer100ms_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericPocet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lbProtokol;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.CheckBox chkAddToTop;
        private System.Windows.Forms.Timer timer100ms;
        private System.Windows.Forms.CheckBox chkRunTimer;
        private System.Windows.Forms.NumericUpDown numericPocet;
    }
}

