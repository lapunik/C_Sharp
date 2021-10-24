namespace OdporovyDelic
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.uin = new System.Windows.Forms.TextBox();
            this.uout = new System.Windows.Forms.TextBox();
            this.log = new ASE.Controls.MujProtokol();
            this.vypocitej = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rezim2 = new System.Windows.Forms.RadioButton();
            this.rezim1 = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.r1 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.r2 = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.uin, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.uout, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.log, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.vypocitej, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(525, 421);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(178, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 84);
            this.label1.TabIndex = 0;
            this.label1.Text = "U in:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(178, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 84);
            this.label2.TabIndex = 1;
            this.label2.Text = "R1:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(178, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 84);
            this.label3.TabIndex = 2;
            this.label3.Text = "R2:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(178, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 84);
            this.label4.TabIndex = 3;
            this.label4.Text = "U out:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uin
            // 
            this.uin.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uin.Location = new System.Drawing.Point(353, 3);
            this.uin.Multiline = true;
            this.uin.Name = "uin";
            this.uin.Size = new System.Drawing.Size(162, 78);
            this.uin.TabIndex = 4;
            // 
            // uout
            // 
            this.uout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uout.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uout.Location = new System.Drawing.Point(353, 255);
            this.uout.Multiline = true;
            this.uout.Name = "uout";
            this.uout.Size = new System.Drawing.Size(169, 78);
            this.uout.TabIndex = 5;
            // 
            // log
            // 
            this.log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.log.FormattingEnabled = true;
            this.log.Location = new System.Drawing.Point(3, 3);
            this.log.Name = "log";
            this.tableLayoutPanel1.SetRowSpan(this.log, 5);
            this.log.Size = new System.Drawing.Size(169, 415);
            this.log.TabIndex = 8;
            // 
            // vypocitej
            // 
            this.vypocitej.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vypocitej.Location = new System.Drawing.Point(353, 339);
            this.vypocitej.Name = "vypocitej";
            this.vypocitej.Size = new System.Drawing.Size(169, 79);
            this.vypocitej.TabIndex = 9;
            this.vypocitej.Text = "Vypčítej";
            this.vypocitej.UseVisualStyleBackColor = true;
            this.vypocitej.Click += new System.EventHandler(this.vypocitej_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rezim2);
            this.groupBox1.Controls.Add(this.rezim1);
            this.groupBox1.Location = new System.Drawing.Point(178, 339);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 79);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Režim";
            // 
            // rezim2
            // 
            this.rezim2.AutoSize = true;
            this.rezim2.Location = new System.Drawing.Point(10, 43);
            this.rezim2.Name = "rezim2";
            this.rezim2.Size = new System.Drawing.Size(112, 17);
            this.rezim2.TabIndex = 1;
            this.rezim2.Text = "Zadávám Ui, Uout";
            this.rezim2.UseVisualStyleBackColor = true;
            this.rezim2.CheckedChanged += new System.EventHandler(this.rezim2_CheckedChanged);
            // 
            // rezim1
            // 
            this.rezim1.AutoSize = true;
            this.rezim1.Checked = true;
            this.rezim1.Location = new System.Drawing.Point(10, 20);
            this.rezim1.Name = "rezim1";
            this.rezim1.Size = new System.Drawing.Size(129, 17);
            this.rezim1.TabIndex = 0;
            this.rezim1.TabStop = true;
            this.rezim1.Text = "Zadávám Uin, R1, R2";
            this.rezim1.UseVisualStyleBackColor = true;
            this.rezim1.CheckedChanged += new System.EventHandler(this.rezim1_CheckedChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.r1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBox1, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(353, 87);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(162, 78);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // r1
            // 
            this.r1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.r1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.r1.FormattingEnabled = true;
            this.r1.Items.AddRange(new object[] {
            "1",
            "1,5",
            "2,2",
            "3,3",
            "4,7",
            "6,8",
            "10",
            "15",
            "22",
            "33",
            "47",
            "68",
            "100",
            "150",
            "220",
            "330",
            "470",
            "680",
            "1000",
            "1500",
            "2200",
            "3300",
            "4700",
            "6800",
            "10000",
            "15000",
            "22000",
            "33000",
            "47000",
            "68000",
            "100000",
            "150000",
            "220000",
            "330000",
            "470000",
            "680000",
            "1000000",
            "1500000",
            "2200000",
            "3300000",
            "4700000",
            "6800000",
            "10000000"});
            this.r1.Location = new System.Drawing.Point(3, 3);
            this.r1.Name = "r1";
            this.r1.Size = new System.Drawing.Size(156, 45);
            this.r1.TabIndex = 6;
            this.r1.SelectedIndexChanged += new System.EventHandler(this.r1_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 54);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(74, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Zamknout";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.checkBox2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.r2, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(353, 171);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(162, 78);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(3, 54);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(74, 17);
            this.checkBox2.TabIndex = 7;
            this.checkBox2.Text = "Zamknout";
            this.checkBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // r2
            // 
            this.r2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.r2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.r2.FormattingEnabled = true;
            this.r2.Items.AddRange(new object[] {
            "1",
            "1,5",
            "2,2",
            "3,3",
            "4,7",
            "6,8",
            "10",
            "15",
            "22",
            "33",
            "47",
            "68",
            "100",
            "150",
            "220",
            "330",
            "470",
            "680",
            "1000",
            "1500",
            "2200",
            "3300",
            "4700",
            "6800",
            "10000",
            "15000",
            "22000",
            "33000",
            "47000",
            "68000",
            "100000",
            "150000",
            "220000",
            "330000",
            "470000",
            "680000",
            "1000000",
            "1500000",
            "2200000",
            "3300000",
            "4700000",
            "6800000",
            "10000000"});
            this.r2.Location = new System.Drawing.Point(3, 3);
            this.r2.Name = "r2";
            this.r2.Size = new System.Drawing.Size(156, 45);
            this.r2.TabIndex = 7;
            this.r2.SelectedIndexChanged += new System.EventHandler(this.r2_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 421);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox r2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox uin;
        private System.Windows.Forms.TextBox uout;
        private System.Windows.Forms.ComboBox r1;
        private ASE.Controls.MujProtokol log;
        private System.Windows.Forms.Button vypocitej;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rezim2;
        private System.Windows.Forms.RadioButton rezim1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}

