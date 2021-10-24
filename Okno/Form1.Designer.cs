namespace Okno
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
      this.button1 = new System.Windows.Forms.Button();
      this.btnDruhej = new System.Windows.Forms.Button();
      this.btnQuit = new System.Windows.Forms.Button();
      this.lblPocet = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
      this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.button1.ForeColor = System.Drawing.Color.White;
      this.button1.Location = new System.Drawing.Point(12, 12);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(169, 82);
      this.button1.TabIndex = 0;
      this.button1.Text = "Press me";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new System.EventHandler(this.PressMe_Click);
      // 
      // btnDruhej
      // 
      this.btnDruhej.BackColor = System.Drawing.SystemColors.ButtonFace;
      this.btnDruhej.Location = new System.Drawing.Point(12, 125);
      this.btnDruhej.Name = "btnDruhej";
      this.btnDruhej.Size = new System.Drawing.Size(169, 124);
      this.btnDruhej.TabIndex = 1;
      this.btnDruhej.Text = "Druhej";
      this.btnDruhej.UseVisualStyleBackColor = false;
      this.btnDruhej.MouseLeave += new System.EventHandler(this.btnDruhej_MouseLeave);
      this.btnDruhej.MouseHover += new System.EventHandler(this.btnDruhej_MouseHover);
      // 
      // btnQuit
      // 
      this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.btnQuit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
      this.btnQuit.Location = new System.Drawing.Point(203, 12);
      this.btnQuit.Name = "btnQuit";
      this.btnQuit.Size = new System.Drawing.Size(169, 82);
      this.btnQuit.TabIndex = 2;
      this.btnQuit.Text = "Konec";
      this.btnQuit.UseVisualStyleBackColor = true;
      this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
      // 
      // lblPocet
      // 
      this.lblPocet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.lblPocet.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblPocet.Location = new System.Drawing.Point(203, 125);
      this.lblPocet.Name = "lblPocet";
      this.lblPocet.Size = new System.Drawing.Size(169, 124);
      this.lblPocet.TabIndex = 3;
      this.lblPocet.Text = "??";
      this.lblPocet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(532, 450);
      this.Controls.Add(this.lblPocet);
      this.Controls.Add(this.btnQuit);
      this.Controls.Add(this.btnDruhej);
      this.Controls.Add(this.button1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button btnDruhej;
    private System.Windows.Forms.Button btnQuit;
    private System.Windows.Forms.Label lblPocet;
  }
}

