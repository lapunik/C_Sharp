namespace DiodeUserControl
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
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.diode1 = new DiodeUserControl.Diode();
            this.diodePanel1 = new DiodeUserControl.DiodePanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(439, 273);
            this.button1.TabIndex = 1;
            this.button1.Text = "On/Off";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.diode1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.diodePanel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(891, 559);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(3, 282);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(439, 274);
            this.button2.TabIndex = 4;
            this.button2.Text = "3D";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // diode1
            // 
            this.diode1.BColor = System.Drawing.Color.Gray;
            this.diode1.Color = System.Drawing.Color.Lime;
            this.diode1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diode1.Location = new System.Drawing.Point(448, 3);
            this.diode1.Name = "diode1";
            this.diode1.Notification = false;
            this.diode1.SecondColor = System.Drawing.Color.DarkGray;
            this.diode1.Size = new System.Drawing.Size(440, 273);
            this.diode1.TabIndex = 5;
            this.diode1.Text = "diode1";
            this.diode1.View3D = 2;
            // 
            // diodePanel1
            // 
            this.diodePanel1.BColor = System.Drawing.Color.DarkGray;
            this.diodePanel1.Color = System.Drawing.Color.Lime;
            this.diodePanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.diodePanel1.Location = new System.Drawing.Point(447, 281);
            this.diodePanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.diodePanel1.Name = "diodePanel1";
            this.diodePanel1.Notification = false;
            this.diodePanel1.SecondColor = System.Drawing.Color.LightGray;
            this.diodePanel1.Size = new System.Drawing.Size(135, 39);
            this.diodePanel1.TabIndex = 6;
            this.diodePanel1.Text = "Beroun";
            this.diodePanel1.View3D = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 559);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button2;
        private Diode diode1;
        private DiodePanel diodePanel1;
    }
}

