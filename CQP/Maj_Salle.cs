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
    public partial class Maj_Salle : Form
    {
        public Maj_Salle()
        {
            InitializeComponent();
        }
        public string s;
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != " ")
            {
                try
                {
                    s = "update salle set typesalle='" + comboBox1.SelectedItem + "' where idsalle='" + comboBox2.Text + "'";
                    Connexion.maj(s);
                    Maj_Salle_Load(sender, e);
                    comboBox2.Text = " ";
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
                    s = "delete from salle where idsalle='" + comboBox2.Text + "'";
                    Connexion.maj(s);
                    Maj_Salle_Load(sender, e);
                    comboBox2.Text = " ";
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

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.Text = " ";
            comboBox1.Text = " ";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                Connexion.cmd = new OleDbCommand("select * from salle where idsalle='" + comboBox2.Text + "'", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                while (Connexion.dr.Read())
                {

                    comboBox1.Text=Connexion.dr[1].ToString();
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

        private void Maj_Salle_Load(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                comboBox2.Items.Clear();
                Connexion.cmd = new OleDbCommand("select idsalle from salle", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                while (Connexion.dr.Read())
                {

                    comboBox2.Items.Add(Connexion.dr[0].ToString());
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
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Cours");
            comboBox1.Items.Add("Pratique");
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true; 
        }
    }
}
