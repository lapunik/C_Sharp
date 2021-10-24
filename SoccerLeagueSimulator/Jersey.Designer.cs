namespace InregularShapeButton
{
    partial class Jersey
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

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainColor = new System.Windows.Forms.Button();
            this.PlayersName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MainColor
            // 
            this.MainColor.BackColor = System.Drawing.Color.Transparent;
            this.MainColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MainColor.Location = new System.Drawing.Point(41, 0);
            this.MainColor.Name = "MainColor";
            this.MainColor.Size = new System.Drawing.Size(90, 120);
            this.MainColor.TabIndex = 0;
            this.MainColor.Text = "#";
            this.MainColor.UseVisualStyleBackColor = false;
            this.MainColor.Click += new System.EventHandler(this.MainColor_Click);
            // 
            // PlayersName
            // 
            this.PlayersName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PlayersName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PlayersName.Location = new System.Drawing.Point(0, 97);
            this.PlayersName.Name = "PlayersName";
            this.PlayersName.Size = new System.Drawing.Size(171, 23);
            this.PlayersName.TabIndex = 1;
            this.PlayersName.Text = "Name";
            this.PlayersName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Jersey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PlayersName);
            this.Controls.Add(this.MainColor);
            this.Name = "Jersey";
            this.Size = new System.Drawing.Size(171, 120);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MainColor;
        private System.Windows.Forms.Label PlayersName;
    }
}
