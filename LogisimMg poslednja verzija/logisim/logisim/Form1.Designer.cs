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
            this.treeView1 = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ipic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ilipic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lanpic)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(417, 44);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(664, 588);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(49, 544);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(199, 180);
            this.listBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 524);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Ipic
            // 
            this.Ipic.Location = new System.Drawing.Point(49, 44);
            this.Ipic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Ipic.Name = "Ipic";
            this.Ipic.Size = new System.Drawing.Size(180, 145);
            this.Ipic.TabIndex = 3;
            this.Ipic.TabStop = false;
            this.Ipic.Click += new System.EventHandler(this.Ipic_Click);
            this.Ipic.Paint += new System.Windows.Forms.PaintEventHandler(this.Ipic_Paint_1);
            // 
            // Ilipic
            // 
            this.Ilipic.Location = new System.Drawing.Point(49, 197);
            this.Ilipic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Ilipic.Name = "Ilipic";
            this.Ilipic.Size = new System.Drawing.Size(180, 129);
            this.Ilipic.TabIndex = 4;
            this.Ilipic.TabStop = false;
            this.Ilipic.Click += new System.EventHandler(this.Ilipic_Click);
            this.Ilipic.Paint += new System.Windows.Forms.PaintEventHandler(this.Ilipic_Paint);
            // 
            // lanpic
            // 
            this.lanpic.Location = new System.Drawing.Point(49, 334);
            this.lanpic.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lanpic.Name = "lanpic";
            this.lanpic.Size = new System.Drawing.Size(180, 148);
            this.lanpic.TabIndex = 5;
            this.lanpic.TabStop = false;
            this.lanpic.Click += new System.EventHandler(this.lanpic_Click);
            this.lanpic.Paint += new System.Windows.Forms.PaintEventHandler(this.lanpic_Paint);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(1139, 128);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(251, 345);
            this.treeView1.TabIndex = 6;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 740);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.lanpic);
            this.Controls.Add(this.Ilipic);
            this.Controls.Add(this.Ipic);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.TreeView treeView1;
    }
}

