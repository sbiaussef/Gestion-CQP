using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CQP
{
    public partial class conventionelle : Form
    {
        public conventionelle()
        {
            InitializeComponent();
        }

        private void UPFil_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox3.Text = "";
        }
        public string t;
        private void ADDFil_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != " ")
            {
                try
                {
                    t = "insert into parametrage values('" + textBox1.Text + "','MHC','" + textBox3.Text + "')";
                    Connexion.maj(t);
                    textBox1.Text = " ";
                    textBox3.Text = " ";
                }
                catch (Exception MSG)
                {
                    MessageBox.Show(MSG.Message);
                }
            }
            else
            {
                MessageBox.Show("remplir les champs", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true; 
        }
    }
}
