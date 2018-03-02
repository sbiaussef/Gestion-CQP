namespace CQP
{
    partial class Maj_Formateur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Maj_Formateur));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.RemoveF = new System.Windows.Forms.Button();
            this.UpF = new System.Windows.Forms.Button();
            this.AddF = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(526, 301);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(285, 21);
            this.comboBox1.TabIndex = 30;
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // RemoveF
            // 
            this.RemoveF.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.RemoveF.Location = new System.Drawing.Point(601, 371);
            this.RemoveF.Name = "RemoveF";
            this.RemoveF.Size = new System.Drawing.Size(101, 32);
            this.RemoveF.TabIndex = 29;
            this.RemoveF.Text = "REMOVE";
            this.RemoveF.UseVisualStyleBackColor = true;
            this.RemoveF.Click += new System.EventHandler(this.RemoveF_Click);
            // 
            // UpF
            // 
            this.UpF.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.UpF.Location = new System.Drawing.Point(433, 371);
            this.UpF.Name = "UpF";
            this.UpF.Size = new System.Drawing.Size(101, 32);
            this.UpF.TabIndex = 28;
            this.UpF.Text = "UPDATE";
            this.UpF.UseVisualStyleBackColor = true;
            this.UpF.Click += new System.EventHandler(this.UpF_Click);
            // 
            // AddF
            // 
            this.AddF.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.AddF.Location = new System.Drawing.Point(770, 371);
            this.AddF.Name = "AddF";
            this.AddF.Size = new System.Drawing.Size(101, 32);
            this.AddF.TabIndex = 27;
            this.AddF.Text = "CANCEL";
            this.AddF.UseVisualStyleBackColor = true;
            this.AddF.Click += new System.EventHandler(this.AddF_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(526, 271);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(285, 20);
            this.textBox2.TabIndex = 25;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(446, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Specialité";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(445, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Matricule";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(445, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Nom Complet";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(526, 240);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(285, 21);
            this.comboBox2.TabIndex = 31;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // Maj_Formateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1284, 561);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.RemoveF);
            this.Controls.Add(this.UpF);
            this.Controls.Add(this.AddF);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1300, 599);
            this.MinimumSize = new System.Drawing.Size(1300, 599);
            this.Name = "Maj_Formateur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formateur";
            this.Load += new System.EventHandler(this.Maj_Formateur_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button RemoveF;
        private System.Windows.Forms.Button UpF;
        private System.Windows.Forms.Button AddF;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}