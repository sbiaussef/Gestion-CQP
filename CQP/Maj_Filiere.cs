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
    public partial class Maj_Filiere : Form
    {
        public Maj_Filiere()
        {
            InitializeComponent();
        }
        public string t;

        private void UPFil_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                try
                {
                    t = "update Filiere set intitulefiliere='" + textBox2.Text + "' where idfiliere='" + comboBox2.Text + "'";
                    Connexion.sean(t);
                    t = "update Niv_fil set plafond_horraire=" + textBox3.Text + " where idniveau='" + comboBox1.Text + "' and idfiliere='" + comboBox2.Text + "' and annee=" + comboBox3.Text + "";
                    Connexion.maj(t);
                    Maj_Filiere_Load(sender, e);
                    comboBox2.Text = " ";
                    textBox2.Text = " ";
                    textBox3.Text = " ";
                    comboBox1.Text = " ";
                    comboBox3.Text = " ";
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

        private void RemoveFil_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                try
                {
                    t = "delete from Niv_fil where idniveau='" + comboBox1.Text + "' and idfiliere='" + comboBox2.Text + "' and annee=" + comboBox3.Text + "";
                    Connexion.maj(t);
                    Maj_Filiere_Load(sender, e);
                    comboBox2.Text = " ";
                    textBox2.Text = " ";
                    textBox3.Text = " ";
                    comboBox1.Text = " ";
                    comboBox3.Text = " ";
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

        private void Maj_Filiere_Load(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                comboBox2.Items.Clear();
                Connexion.cmd = new OleDbCommand("select idfiliere from filiere", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                while (Connexion.dr.Read())
                {

                    comboBox2.Items.Add(Connexion.dr[0]);
                }
            }
            catch (Exception MSG)
            {
                MessageBox.Show(MSG.Message);
            }
            finally{
            Connexion.cn.Close();}
            comboBox1.Items.Clear();
            comboBox1.Items.Add("TS"); comboBox1.Items.Add("T"); comboBox1.Items.Add("Q"); comboBox1.Items.Add("S");

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ADDFil_Click(object sender, EventArgs e)
        {
            comboBox2.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            comboBox1.Text = " ";
            comboBox3.Text = " ";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true; 
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                Connexion.dt.Columns.Clear();
                Connexion.dt.Rows.Clear();
                Connexion.cmd = new OleDbCommand("select Filiere.intitulefiliere as'Filiere',niv_fil.plafond_horraire as 'plafond horraire' from Filiere,niv_fil where Filiere.idfiliere= niv_fil.idfiliere and Filiere.idfiliere='" + comboBox2.Text + "'and niv_fil.idniveau='" + comboBox1.Text + "' and niv_fil.annee=" + comboBox3.Text + "", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                while (Connexion.dr.Read())
                {
                    textBox2.Text = Connexion.dr[0].ToString();
                    textBox3.Text = Connexion.dr[1].ToString();
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
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true; 
        }
    }
}
