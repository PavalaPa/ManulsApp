namespace ManulsApp {
    partial class Form7 {
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(182, 227);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(152, 52);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(309, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Тестирование переопределения";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(182, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(152, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(29, 72);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(147, 207);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(29, 285);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(305, 240);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(353, 72);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(265, 444);
            this.richTextBox2.TabIndex = 6;
            this.richTextBox2.Text = "";
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(630, 528);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.985074F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form7";
            this.Text = "Form7";
            this.Load += new System.EventHandler(this.Form7_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}