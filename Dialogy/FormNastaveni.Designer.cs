namespace Dialogy
{
    partial class FormNastaveni
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.textData = new System.Windows.Forms.TextBox();
            this.groupBoxBarva = new System.Windows.Forms.GroupBox();
            this.radioButtonModra = new System.Windows.Forms.RadioButton();
            this.radioButtonZelena = new System.Windows.Forms.RadioButton();
            this.radioButtonCervena = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBoxBarva.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Maroon;
            this.flowLayoutPanel1.Controls.Add(this.buttonClose);
            this.flowLayoutPanel1.Controls.Add(this.buttonOk);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 365);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 6, 6, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 104);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(658, 9);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(133, 85);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(519, 9);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(133, 85);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // textData
            // 
            this.textData.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textData.Location = new System.Drawing.Point(13, 12);
            this.textData.Multiline = true;
            this.textData.Name = "textData";
            this.textData.Size = new System.Drawing.Size(775, 129);
            this.textData.TabIndex = 1;
            // 
            // groupBoxBarva
            // 
            this.groupBoxBarva.Controls.Add(this.radioButtonModra);
            this.groupBoxBarva.Controls.Add(this.radioButtonZelena);
            this.groupBoxBarva.Controls.Add(this.radioButtonCervena);
            this.groupBoxBarva.Location = new System.Drawing.Point(13, 148);
            this.groupBoxBarva.Name = "groupBoxBarva";
            this.groupBoxBarva.Size = new System.Drawing.Size(146, 146);
            this.groupBoxBarva.TabIndex = 2;
            this.groupBoxBarva.TabStop = false;
            this.groupBoxBarva.Text = "Barva";
            // 
            // radioButtonModra
            // 
            this.radioButtonModra.AutoSize = true;
            this.radioButtonModra.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonModra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.radioButtonModra.Location = new System.Drawing.Point(36, 99);
            this.radioButtonModra.Name = "radioButtonModra";
            this.radioButtonModra.Size = new System.Drawing.Size(74, 21);
            this.radioButtonModra.TabIndex = 2;
            this.radioButtonModra.TabStop = true;
            this.radioButtonModra.Text = "Modrá";
            this.radioButtonModra.UseVisualStyleBackColor = true;
            // 
            // radioButtonZelena
            // 
            this.radioButtonZelena.AutoSize = true;
            this.radioButtonZelena.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonZelena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.radioButtonZelena.Location = new System.Drawing.Point(36, 72);
            this.radioButtonZelena.Name = "radioButtonZelena";
            this.radioButtonZelena.Size = new System.Drawing.Size(79, 21);
            this.radioButtonZelena.TabIndex = 1;
            this.radioButtonZelena.TabStop = true;
            this.radioButtonZelena.Text = "Zelená";
            this.radioButtonZelena.UseVisualStyleBackColor = true;
            // 
            // radioButtonCervena
            // 
            this.radioButtonCervena.AutoSize = true;
            this.radioButtonCervena.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonCervena.ForeColor = System.Drawing.Color.Maroon;
            this.radioButtonCervena.Location = new System.Drawing.Point(36, 45);
            this.radioButtonCervena.Name = "radioButtonCervena";
            this.radioButtonCervena.Size = new System.Drawing.Size(89, 21);
            this.radioButtonCervena.TabIndex = 0;
            this.radioButtonCervena.TabStop = true;
            this.radioButtonCervena.Text = "Červená";
            this.radioButtonCervena.UseVisualStyleBackColor = true;
            // 
            // FormNastaveni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(800, 469);
            this.Controls.Add(this.groupBoxBarva);
            this.Controls.Add(this.textData);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FormNastaveni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormNastaveni";
            this.Load += new System.EventHandler(this.FormNastaveni_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBoxBarva.ResumeLayout(false);
            this.groupBoxBarva.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox textData;
        private System.Windows.Forms.GroupBox groupBoxBarva;
        private System.Windows.Forms.RadioButton radioButtonModra;
        private System.Windows.Forms.RadioButton radioButtonZelena;
        private System.Windows.Forms.RadioButton radioButtonCervena;
    }
}