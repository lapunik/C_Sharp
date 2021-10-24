namespace _PrvniKlikacka
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnDruhej = new System.Windows.Forms.Button();
            this.Konec = new System.Windows.Forms.Button();
            this.lblPocet = new System.Windows.Forms.Label();
            this.picture = new System.Windows.Forms.PictureBox();
            this.button = new System.Windows.Forms.Button();
            this.PressMe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDruhej
            // 
            this.btnDruhej.BackColor = System.Drawing.Color.Black;
            this.btnDruhej.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDruhej.ForeColor = System.Drawing.Color.SeaShell;
            this.btnDruhej.Location = new System.Drawing.Point(402, 55);
            this.btnDruhej.Name = "btnDruhej";
            this.btnDruhej.Size = new System.Drawing.Size(261, 300);
            this.btnDruhej.TabIndex = 1;
            this.btnDruhej.Text = "Druhej";
            this.btnDruhej.UseVisualStyleBackColor = false;
            this.btnDruhej.MouseLeave += new System.EventHandler(this.btnDruhej_MouseLeave);
            this.btnDruhej.MouseHover += new System.EventHandler(this.btnDruhej_MouseHover);
            // 
            // Konec
            // 
            this.Konec.BackColor = System.Drawing.Color.Red;
            this.Konec.Cursor = System.Windows.Forms.Cursors.No;
            this.Konec.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Konec.ForeColor = System.Drawing.Color.Snow;
            this.Konec.Location = new System.Drawing.Point(27, 218);
            this.Konec.Name = "Konec";
            this.Konec.Size = new System.Drawing.Size(237, 137);
            this.Konec.TabIndex = 2;
            this.Konec.Text = "Konec";
            this.Konec.UseVisualStyleBackColor = false;
            this.Konec.Click += new System.EventHandler(this.Konec_Click);
            // 
            // lblPocet
            // 
            this.lblPocet.BackColor = System.Drawing.Color.Orange;
            this.lblPocet.Font = new System.Drawing.Font("Segoe Print", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPocet.Location = new System.Drawing.Point(16, 417);
            this.lblPocet.Name = "lblPocet";
            this.lblPocet.Size = new System.Drawing.Size(647, 137);
            this.lblPocet.TabIndex = 4;
            this.lblPocet.Text = "Pocet";
            this.lblPocet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPocet.Click += new System.EventHandler(this.lblPocet_Click);
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.Color.LightGreen;
            this.picture.Image = global::_PrvniKlikacka.Properties.Resources.wizard_36676_960_720;
            this.picture.Location = new System.Drawing.Point(718, 55);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(532, 499);
            this.picture.TabIndex = 7;
            this.picture.TabStop = false;
            this.picture.Click += new System.EventHandler(this.picture_Click);
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.Color.Purple;
            this.button.BackgroundImage = global::_PrvniKlikacka.Properties.Resources.stažený_soubor;
            this.button.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button.ForeColor = System.Drawing.Color.Azure;
            this.button.Location = new System.Drawing.Point(290, 55);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 300);
            this.button.TabIndex = 5;
            this.button.Text = "MAGIC";
            this.button.UseVisualStyleBackColor = false;
            this.button.Click += new System.EventHandler(this.Magic_Click);
            // 
            // PressMe
            // 
            this.PressMe.BackColor = System.Drawing.Color.Blue;
            this.PressMe.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PressMe.BackgroundImage")));
            this.PressMe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PressMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PressMe.ForeColor = System.Drawing.Color.Snow;
            this.PressMe.Location = new System.Drawing.Point(27, 55);
            this.PressMe.Name = "PressMe";
            this.PressMe.Size = new System.Drawing.Size(237, 131);
            this.PressMe.TabIndex = 0;
            this.PressMe.Text = "Press me";
            this.PressMe.UseVisualStyleBackColor = false;
            this.PressMe.Click += new System.EventHandler(this.PressMe_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 586);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.button);
            this.Controls.Add(this.lblPocet);
            this.Controls.Add(this.Konec);
            this.Controls.Add(this.btnDruhej);
            this.Controls.Add(this.PressMe);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PressMe;
        private System.Windows.Forms.Button btnDruhej;
        private System.Windows.Forms.Button Konec;
        private System.Windows.Forms.Label lblPocet;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.PictureBox picture;
    }
}

