namespace Logika_ba
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Ipic = new System.Windows.Forms.PictureBox();
            this.Ilipic = new System.Windows.Forms.PictureBox();
            this.lanpic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ipic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ilipic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lanpic)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(313, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(498, 478);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(37, 442);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(150, 147);
            this.listBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 426);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Ipic
            // 
            this.Ipic.Location = new System.Drawing.Point(37, 36);
            this.Ipic.Name = "Ipic";
            this.Ipic.Size = new System.Drawing.Size(135, 118);
            this.Ipic.TabIndex = 3;
            this.Ipic.TabStop = false;
            this.Ipic.Click += new System.EventHandler(this.Ipic_Click);
            this.Ipic.Paint += new System.Windows.Forms.PaintEventHandler(this.Ipic_Paint_1);
            // 
            // Ilipic
            // 
            this.Ilipic.Location = new System.Drawing.Point(37, 160);
            this.Ilipic.Name = "Ilipic";
            this.Ilipic.Size = new System.Drawing.Size(135, 105);
            this.Ilipic.TabIndex = 4;
            this.Ilipic.TabStop = false;
            this.Ilipic.Click += new System.EventHandler(this.Ilipic_Click);
            this.Ilipic.Paint += new System.Windows.Forms.PaintEventHandler(this.Ilipic_Paint);
            // 
            // lanpic
            // 
            this.lanpic.Location = new System.Drawing.Point(37, 271);
            this.lanpic.Name = "lanpic";
            this.lanpic.Size = new System.Drawing.Size(135, 120);
            this.lanpic.TabIndex = 5;
            this.lanpic.TabStop = false;
            this.lanpic.Click += new System.EventHandler(this.lanpic_Click);
            this.lanpic.Paint += new System.Windows.Forms.PaintEventHandler(this.lanpic_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 601);
            this.Controls.Add(this.lanpic);
            this.Controls.Add(this.Ilipic);
            this.Controls.Add(this.Ipic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ipic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ilipic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lanpic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox Ipic;
        private System.Windows.Forms.PictureBox Ilipic;
        private System.Windows.Forms.PictureBox lanpic;
    }
}

