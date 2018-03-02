namespace CQP
{
    partial class conventionelle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(conventionelle));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UPFil = new System.Windows.Forms.Button();
            this.ADDFil = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(608, 252);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(188, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(608, 278);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(188, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(490, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Année Scolaire";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(490, 281);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Valeur";
            // 
            // UPFil
            // 
            this.UPFil.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.UPFil.Location = new System.Drawing.Point(711, 325);
            this.UPFil.Name = "UPFil";
            this.UPFil.Size = new System.Drawing.Size(101, 36);
            this.UPFil.TabIndex = 37;
            this.UPFil.Text = "CANCEL";
            this.UPFil.UseVisualStyleBackColor = true;
            this.UPFil.Click += new System.EventHandler(this.UPFil_Click);
            // 
            // ADDFil
            // 
            this.ADDFil.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.ADDFil.Location = new System.Drawing.Point(581, 325);
            this.ADDFil.Name = "ADDFil";
            this.ADDFil.Size = new System.Drawing.Size(101, 36);
            this.ADDFil.TabIndex = 36;
            this.ADDFil.Text = "ADD";
            this.ADDFil.UseVisualStyleBackColor = true;
            this.ADDFil.Click += new System.EventHandler(this.ADDFil_Click);
            // 
            // conventionelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1284, 561);
            this.Controls.Add(this.UPFil);
            this.Controls.Add(this.ADDFil);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1300, 599);
            this.MinimumSize = new System.Drawing.Size(1300, 599);
            this.Name = "conventionelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Masse Horraire conventionelle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button UPFil;
        private System.Windows.Forms.Button ADDFil;
    }
}