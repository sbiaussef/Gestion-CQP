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
    public partial class Consultatio_Filiere : Form
    {
        public Consultatio_Filiere()
        {
            InitializeComponent();
        }

        private void Consultatio_Filiere_Load(object sender, EventArgs e)
        {
            comboBox2.Enabled = false;
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                Connexion.dt.Columns.Clear();
                Connexion.dt.Rows.Clear();
                Connexion.cmd = new OleDbCommand("select Filiere.idfiliere as abréviation,Filiere.intitulefiliere as Filiere,niv_fil.idniveau as Niveau,niv_fil.annee,niv_fil.plafond_horraire as plafond_horraire from Filiere,niv_fil where Filiere.idfiliere= niv_fil.idfiliere  ", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                Connexion.dt.Load(Connexion.dr);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Connexion.dt;
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
            } comboBox2.Items.Clear();
            comboBox2.Items.Add("TS"); comboBox2.Items.Add("T"); comboBox2.Items.Add("Q"); comboBox2.Items.Add("S");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                Connexion.dt.Columns.Clear();
                Connexion.dt.Rows.Clear();
                Connexion.cmd = new OleDbCommand("select Filiere.idfiliere as abréviation,Filiere.intitulefiliere as Filiere,niv_fil.idniveau as Niveau,niv_fil.annee,niv_fil.plafond_horraire as plafond_horraire from Filiere,niv_fil where Filiere.idfiliere= niv_fil.idfiliere and Filiere.idfiliere='" + comboBox1.Text + "'and niv_fil.idniveau='" + comboBox2.Text + "'", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                Connexion.dt.Load(Connexion.dr);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Connexion.dt;

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
    }
}
