namespace Kino
{
    partial class KinoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kinoSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.kinoPictureBox = new System.Windows.Forms.PictureBox();
            this.ulozitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.kinoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // kinoPictureBox
            // 
            this.kinoPictureBox.Location = new System.Drawing.Point(12, 12);
            this.kinoPictureBox.Name = "kinoPictureBox";
            this.kinoPictureBox.Size = new System.Drawing.Size(540, 312);
            this.kinoPictureBox.TabIndex = 0;
            this.kinoPictureBox.TabStop = false;
            this.kinoPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.kinoPictureBox_Paint);
            // 
            // ulozitButton
            // 
            this.ulozitButton.Location = new System.Drawing.Point(244, 345);
            this.ulozitButton.Name = "ulozitButton";
            this.ulozitButton.Size = new System.Drawing.Size(75, 23);
            this.ulozitButton.TabIndex = 1;
            this.ulozitButton.Text = "Uložit";
            this.ulozitButton.UseVisualStyleBackColor = true;
            // 
            // KinoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 380);
            this.Controls.Add(this.ulozitButton);
            this.Controls.Add(this.kinoPictureBox);
            this.Name = "KinoForm";
            this.Text = "Evidence kinosálu";
            ((System.ComponentModel.ISupportInitialize)(this.kinoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog kinoSaveFileDialog;
        private System.Windows.Forms.PictureBox kinoPictureBox;
        private System.Windows.Forms.Button ulozitButton;
    }
}

