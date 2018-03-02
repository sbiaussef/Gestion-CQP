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
    public partial class Ajouter_Formateur : Form
    {
        public Ajouter_Formateur()
        {
            InitializeComponent();
        }
        public string s;

        private void Formateur_Load(object sender, EventArgs e)
        {
            Connexion.cn.Close();
            comboBox1.Items.Clear();
            Connexion.cn.Open();

            Connexion.cmd = new OleDbCommand("select idfiliere from filiere", Connexion.cn);
            Connexion.dr = Connexion.cmd.ExecuteReader();
            while (Connexion.dr.Read())
            {

                comboBox1.Items.Add(Connexion.dr[0]);
            }
            Connexion.cn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

 

        private void UpF_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != " ")
            {
                try
                {
                    s = "update Formateur set matricule='" + textBox2.Text + "',idfiliere='" + comboBox1.SelectedItem + "' where nom_prenom='"+textBox1.Text+"'";
                    Connexion.maj(s);
                    Formateur_Load(sender, e);
                    textBox1.Text = " ";
                    textBox2.Text = " ";
                    comboBox1.Text = " ";
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

        private void RemoveF_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != " ")
            {
                try
                {
                    s = "delete from Formateur where nom_prenom='" + textBox1.Text + "'";
                    Connexion.maj(s);
                    Formateur_Load(sender, e);
                    textBox1.Text = " ";
                    textBox2.Text = " ";
                    comboBox1.Text = " ";
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



        private void AddF_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != " ")
            {
                try
                {
                    s = "INSERT INTO Formateur VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.SelectedItem + "')";
                    Connexion.maj(s);
                    textBox1.Text = " ";
                    textBox2.Text = " ";
                    comboBox1.Text = " ";
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

        private void UpF_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            comboBox1.Text = " ";
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
