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
    public partial class Ajouter_Salle : Form
    {
        public Ajouter_Salle()
        {
            InitializeComponent();
        }
        public string s;
        private void Salle_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Cours");
            comboBox1.Items.Add("Pratique");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != " ")
            {
                try
                {
                    s = "INSERT INTO salle VALUES('" + textBox1.Text + "','" + comboBox1.SelectedItem + "')";
                    Connexion.maj(s);
                    Salle_Load(sender, e);
                    textBox1.Text = " ";                    
                    comboBox1.Text = " ";
                }
                catch (Exception MSG)
                {
                    MessageBox.Show(MSG.Message);
                    comboBox1.Equals(" ");
                }
            }
            else
            {
                MessageBox.Show("remplir les champs", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            comboBox1.Text = " ";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true; 
        }





    }
}
