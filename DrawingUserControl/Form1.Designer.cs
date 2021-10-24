namespace DrawingUserControl
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
            this.myDrawContorl1 = new DrawingUserControl.MyDrawContorl();
            this.classDrawing1 = new DrawingUserControl.ClassDrawing();
            this.textDawing1 = new DrawingUserControl.TextDawing();
            this.textDawing2 = new DrawingUserControl.TextDawing();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.myDrawContorl1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.classDrawing1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textDawing1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textDawing2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(684, 508);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // myDrawContorl1
            // 
            this.myDrawContorl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDrawContorl1.Location = new System.Drawing.Point(345, 3);
            this.myDrawContorl1.Name = "myDrawContorl1";
            this.myDrawContorl1.Size = new System.Drawing.Size(336, 248);
            this.myDrawContorl1.TabIndex = 1;
            this.myDrawContorl1.Text = "myDrawContorl1";
            // 
            // classDrawing1
            // 
            this.classDrawing1.Color1 = System.Drawing.Color.Red;
            this.classDrawing1.Color2 = System.Drawing.Color.PowderBlue;
            this.classDrawing1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classDrawing1.ForeColor = System.Drawing.Color.LightBlue;
            this.classDrawing1.Location = new System.Drawing.Point(3, 257);
            this.classDrawing1.Name = "classDrawing1";
            this.classDrawing1.Size = new System.Drawing.Size(336, 248);
            this.classDrawing1.TabIndex = 2;
            this.classDrawing1.Text = "classDrawing1";
            // 
            // textDawing1
            // 
            this.textDawing1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textDawing1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textDawing1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textDawing1.ForeColor = System.Drawing.Color.NavajoWhite;
            this.textDawing1.Location = new System.Drawing.Point(345, 257);
            this.textDawing1.Name = "textDawing1";
            this.textDawing1.Size = new System.Drawing.Size(336, 248);
            this.textDawing1.TabIndex = 3;
            this.textDawing1.Text = "Bum";
            // 
            // textDawing2
            // 
            this.textDawing2.Location = new System.Drawing.Point(3, 3);
            this.textDawing2.Name = "textDawing2";
            this.textDawing2.Size = new System.Drawing.Size(241, 202);
            this.textDawing2.TabIndex = 4;
            this.textDawing2.Text = "textDawing2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 508);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MyDrawContorl myDrawContorl1;
        private ClassDrawing classDrawing1;
        private TextDawing textDawing1;
        private TextDawing textDawing2;
    }
}

