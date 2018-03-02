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
    public partial class Maj_Formateur : Form
    {
        public Maj_Formateur()
        {
            InitializeComponent();
        }
        public string s;
        private void UpF_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != " ")
            {
                try
                {
                    s = "update Formateur set matricule='" + textBox2.Text + "',idfiliere='" + comboBox1.SelectedItem + "' where nom_prenom='" + comboBox2.Text + "'";
                    Connexion.maj(s);
                    Maj_Formateur_Load(sender, e);
                    comboBox2.Text = " ";
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
            if (comboBox2.Text != " ")
            {
                try
                {
                    s = "delete from Formateur where nom_prenom='" + comboBox2.Text + "'";
                    Connexion.maj(s);
                    Maj_Formateur_Load(sender, e);
                    comboBox2.Text = " ";
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

        private void Maj_Formateur_Load(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                Connexion.dr.Close();
                comboBox2.Items.Clear();
                Connexion.cmd = new OleDbCommand("select nom_prenom from Formateur", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                while (Connexion.dr.Read())
                {

                    comboBox2.Items.Add(Connexion.dr[0]);
                }
                Connexion.dr.Close();
                comboBox1.Items.Clear();
                Connexion.cmd = new OleDbCommand("select idfiliere from filiere", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                while (Connexion.dr.Read())
                {

                    comboBox1.Items.Add(Connexion.dr[0]);
                }
            }
            catch (Exception MSG)
            {
                MessageBox.Show(MSG.Message);
            }
            finally
            {
                Connexion.cn.Close();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                Connexion.cmd = new OleDbCommand("select nom_prenom as 'Formateur',matricule,idfiliere as 'Filiere' from Formateur where nom_prenom='" + comboBox2.Text + "'", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                while (Connexion.dr.Read())
                {
                    textBox2.Text = Connexion.dr[1].ToString();
                    comboBox1.Text = Connexion.dr[2].ToString();
                }
            }
            catch (Exception MSG)
            {
                MessageBox.Show(MSG.Message);
            }
            finally
            {
                Connexion.cn.Close();
            }
        }

        private void AddF_Click(object sender, EventArgs e)
        {
            comboBox2.Text = " ";
            textBox2.Text = " ";
            comboBox1.Text = " ";
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true; 
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true; 
        }
    }
}
