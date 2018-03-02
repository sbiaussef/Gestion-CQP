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
    public partial class Maj_Groupe : Form
    {
        public Maj_Groupe()
        {
            InitializeComponent();
        }
        public string s;
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                try
                {
                    s = "update Groupe set effectif=" + textBox2.Text + ",responsable='" + textBox3.Text + "',supleant='" + textBox4.Text + "',idfiliere='" + comboBox1.SelectedItem + "' where Codegroupe='" + comboBox2.SelectedItem + "'";
                    Connexion.maj(s);
                    Maj_Groupe_Load(sender, e);
                    comboBox2.Text = " ";
                    textBox2.Text = " ";
                    textBox3.Text = " ";
                    textBox4.Text = " ";
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != " ")
            {
                try
                {
                    s = "delete from Groupe where Codegroupe='" + comboBox2.Text + "'";
                    Connexion.maj(s);
                    Maj_Groupe_Load(sender, e);
                    comboBox2.Text = " ";
                    textBox2.Text = " ";
                    textBox3.Text = " ";
                    textBox4.Text = " ";
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

        private void Maj_Groupe_Load(object sender, EventArgs e)
        {
                        
          try  {
                Connexion.cn.Close();
                Connexion.cn.Open();
                comboBox2.Items.Clear();
                Connexion.cmd = new OleDbCommand("select codegroupe from groupe", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                while (Connexion.dr.Read())
                {

                    comboBox2.Items.Add(Connexion.dr[0].ToString());
                }
                Connexion.dr.Close();
                comboBox1.Items.Clear();
                Connexion.cmd = new OleDbCommand("select idfiliere from filiere", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                while (Connexion.dr.Read())
                {

                    comboBox1.Items.Add(Connexion.dr[0].ToString());
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
                Connexion.dr.Close();
                Connexion.cmd = new OleDbCommand("select * from groupe where codegroupe='"+comboBox2.SelectedItem+"'", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                while (Connexion.dr.Read())
                {

                    textBox2.Text = Connexion.dr[1].ToString();
                    textBox3.Text = Connexion.dr[2].ToString();
                    textBox4.Text = Connexion.dr[3].ToString();
                    comboBox1.Text = Connexion.dr[4].ToString();
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            comboBox1.Text = " ";
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true; 
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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
