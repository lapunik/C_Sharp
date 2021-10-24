namespace Casovace
{
  partial class FormCasovace
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.lbProtocol = new System.Windows.Forms.ListBox();
      this.lblVisual = new System.Windows.Forms.Label();
      this.tmrVisual = new System.Windows.Forms.Timer(this.components);
      this.btnVisual = new System.Windows.Forms.Button();
      this.lblTimers = new System.Windows.Forms.Label();
      this.btnTimers = new System.Windows.Forms.Button();
      this.lblThreads = new System.Windows.Forms.Label();
      this.btnThreading = new System.Windows.Forms.Button();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.ColumnCount = 4;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
      this.tableLayoutPanel1.Controls.Add(this.btnThreading, 2, 1);
      this.tableLayoutPanel1.Controls.Add(this.lblThreads, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.lblTimers, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.lbProtocol, 3, 0);
      this.tableLayoutPanel1.Controls.Add(this.lblVisual, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.btnVisual, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.btnTimers, 1, 1);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(469, 487);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // lbProtocol
      // 
      this.lbProtocol.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lbProtocol.FormattingEnabled = true;
      this.lbProtocol.Location = new System.Drawing.Point(354, 3);
      this.lbProtocol.Name = "lbProtocol";
      this.tableLayoutPanel1.SetRowSpan(this.lbProtocol, 2);
      this.lbProtocol.Size = new System.Drawing.Size(112, 481);
      this.lbProtocol.TabIndex = 0;
      // 
      // lblVisual
      // 
      this.lblVisual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
      this.lblVisual.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblVisual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblVisual.Location = new System.Drawing.Point(3, 0);
      this.lblVisual.Name = "lblVisual";
      this.lblVisual.Size = new System.Drawing.Size(111, 243);
      this.lblVisual.TabIndex = 1;
      this.lblVisual.Text = "label1";
      this.lblVisual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // tmrVisual
      // 
      this.tmrVisual.Enabled = true;
      this.tmrVisual.Interval = 500;
      this.tmrVisual.Tick += new System.EventHandler(this.tmrVisual_Tick);
      // 
      // btnVisual
      // 
      this.btnVisual.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btnVisual.Location = new System.Drawing.Point(15, 258);
      this.btnVisual.Margin = new System.Windows.Forms.Padding(15);
      this.btnVisual.Name = "btnVisual";
      this.btnVisual.Size = new System.Drawing.Size(87, 214);
      this.btnVisual.TabIndex = 2;
      this.btnVisual.Text = "Visual on/off";
      this.btnVisual.UseVisualStyleBackColor = true;
      this.btnVisual.Click += new System.EventHandler(this.btnVisual_Click);
      // 
      // lblTimers
      // 
      this.lblTimers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
      this.lblTimers.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblTimers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblTimers.Location = new System.Drawing.Point(120, 0);
      this.lblTimers.Name = "lblTimers";
      this.lblTimers.Size = new System.Drawing.Size(111, 243);
      this.lblTimers.TabIndex = 3;
      this.lblTimers.Text = "label1";
      this.lblTimers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // btnTimers
      // 
      this.btnTimers.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btnTimers.Location = new System.Drawing.Point(132, 258);
      this.btnTimers.Margin = new System.Windows.Forms.Padding(15);
      this.btnTimers.Name = "btnTimers";
      this.btnTimers.Size = new System.Drawing.Size(87, 214);
      this.btnTimers.TabIndex = 4;
      this.btnTimers.Text = "Timers on/off";
      this.btnTimers.UseVisualStyleBackColor = true;
      this.btnTimers.Click += new System.EventHandler(this.btnTimers_Click);
      // 
      // lblThreads
      // 
      this.lblThreads.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.lblThreads.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lblThreads.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.lblThreads.ForeColor = System.Drawing.Color.White;
      this.lblThreads.Location = new System.Drawing.Point(237, 0);
      this.lblThreads.Name = "lblThreads";
      this.lblThreads.Size = new System.Drawing.Size(111, 243);
      this.lblThreads.TabIndex = 5;
      this.lblThreads.Text = "label1";
      this.lblThreads.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // btnThreading
      // 
      this.btnThreading.Dock = System.Windows.Forms.DockStyle.Fill;
      this.btnThreading.Location = new System.Drawing.Point(249, 258);
      this.btnThreading.Margin = new System.Windows.Forms.Padding(15);
      this.btnThreading.Name = "btnThreading";
      this.btnThreading.Size = new System.Drawing.Size(87, 214);
      this.btnThreading.TabIndex = 6;
      this.btnThreading.Text = "Threading on/off";
      this.btnThreading.UseVisualStyleBackColor = true;
      this.btnThreading.Click += new System.EventHandler(this.btnThreading_Click);
      // 
      // FormCasovace
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(469, 487);
      this.Controls.Add(this.tableLayoutPanel1);
      this.Name = "FormCasovace";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.FormCasovace_Load);
      this.tableLayoutPanel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.ListBox lbProtocol;
    private System.Windows.Forms.Label lblVisual;
    private System.Windows.Forms.Timer tmrVisual;
    private System.Windows.Forms.Button btnVisual;
    private System.Windows.Forms.Label lblTimers;
    private System.Windows.Forms.Button btnTimers;
    private System.Windows.Forms.Label lblThreads;
    private System.Windows.Forms.Button btnThreading;
  }
}

