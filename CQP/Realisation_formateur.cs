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
    public partial class Realisation_formateur : Form
    {
        public Realisation_formateur()
        {
            InitializeComponent();
        }

        private void Realisation_formateur_Load(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                Connexion.dt.Columns.Clear();
                Connexion.dt.Rows.Clear();
                Connexion.cmd = new OleDbCommand("select seance.idformateur as Formateur,count(Eexecution.idseance)*2.5 as Total_realisé,count(Eexecution.idseance)*2.5*100/parametrage.valeur as poucentage,parametrage.valeur as Masse_horraire from Eexecution,parametrage,seance where Eexecution.idseance=seance.idseance  group by seance.idformateur,parametrage.valeur  ", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                Connexion.dt.Load(Connexion.dr);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Connexion.dt;
                Connexion.dr.Close();
                comboBox1.Items.Clear();
                Connexion.cmd = new OleDbCommand("select nom_prenom from formateur", Connexion.cn);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                Connexion.dt.Columns.Clear();
                Connexion.dt.Rows.Clear();
                Connexion.cmd = new OleDbCommand("select seance.idformateur as Formateur,count(Eexecution.idseance)*2.5 as Total_realisé,count(Eexecution.idseance)*2.5*100/parametrage.valeur as poucentage,parametrage.valeur as Masse_horraire from Eexecution,parametrage,seance where Eexecution.idseance=seance.idseance and idformateur='" + comboBox1.SelectedItem + "' group by seance.idformateur,parametrage.valeur  ", Connexion.cn);
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
