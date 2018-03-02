using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace CQP
{
    public partial class Ajouter_Filiere : Form
    {
        public Ajouter_Filiere()
        {
            InitializeComponent();
        }
        public static string t;
       

        private void Filiere_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true; 
        }

        private void ADDFil_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != " ")
            {
                try
                {
                    t = "insert into filiere values('" + textBox1.Text + "','" + textBox2.Text + "')";
                    Connexion.sean(t);
                    t = "insert into Niv_fil values('" + comboBox1.SelectedItem + "','" + textBox1.Text + "'," + comboBox2.SelectedItem + "," + textBox3.Text + ")";
                    Connexion.maj(t);
                    textBox1.Text = " ";
                    textBox2.Text = " ";
                    textBox3.Text = " ";
                    comboBox1.Text = " ";
                    comboBox2.Text = " ";
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

        private void UPFil_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            comboBox1.Text = " ";
            comboBox2.Text = " ";
        }

        private void textBox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true; 
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true; 
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true; 
        }
    }
}
