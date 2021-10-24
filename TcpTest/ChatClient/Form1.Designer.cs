namespace ChatClient
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.zpravyTextBox = new System.Windows.Forms.TextBox();
            this.zpravaTextBox = new System.Windows.Forms.TextBox();
            this.buttonOdeslat = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // zpravyTextBox
            // 
            this.zpravyTextBox.Location = new System.Drawing.Point(0, 0);
            this.zpravyTextBox.Multiline = true;
            this.zpravyTextBox.Name = "zpravyTextBox";
            this.zpravyTextBox.Size = new System.Drawing.Size(327, 228);
            this.zpravyTextBox.TabIndex = 0;
            // 
            // zpravaTextBox
            // 
            this.zpravaTextBox.Location = new System.Drawing.Point(0, 234);
            this.zpravaTextBox.Name = "zpravaTextBox";
            this.zpravaTextBox.Size = new System.Drawing.Size(259, 20);
            this.zpravaTextBox.TabIndex = 1;
            // 
            // buttonOdeslat
            // 
            this.buttonOdeslat.Location = new System.Drawing.Point(265, 234);
            this.buttonOdeslat.Name = "buttonOdeslat";
            this.buttonOdeslat.Size = new System.Drawing.Size(62, 23);
            this.buttonOdeslat.TabIndex = 2;
            this.buttonOdeslat.Text = "Odeslat";
            this.buttonOdeslat.UseVisualStyleBackColor = true;
            this.buttonOdeslat.Click += new System.EventHandler(this.buttonOdeslat_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 263);
            this.Controls.Add(this.buttonOdeslat);
            this.Controls.Add(this.zpravaTextBox);
            this.Controls.Add(this.zpravyTextBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DevbookChat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox zpravyTextBox;
        private System.Windows.Forms.TextBox zpravaTextBox;
        private System.Windows.Forms.Button buttonOdeslat;
        private System.Windows.Forms.Timer timer1;
    }
}

