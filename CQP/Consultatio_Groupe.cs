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
    public partial class Consultatio_Groupe : Form
    {
        public Consultatio_Groupe()
        {
            InitializeComponent();
        }

        private void Consultatio_Groupe_Load(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                Connexion.dt.Columns.Clear();
                Connexion.dt.Rows.Clear();
                Connexion.cmd = new OleDbCommand("select Codegroupe as Groupe,effectif,responsable,supleant,idfiliere as Filiere from groupe", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                Connexion.dt.Load(Connexion.dr);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Connexion.dt;
                Connexion.dr.Close();
                comboBox1.Items.Clear();
                Connexion.cmd = new OleDbCommand("select codegroupe from groupe", Connexion.cn);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                Connexion.dt.Columns.Clear();
                Connexion.dt.Rows.Clear();
                Connexion.cmd = new OleDbCommand("select Codegroupe as Groupe,effectif,responsable,supleant,idfiliere as Filiere from groupe where codegroupe='"+comboBox1.SelectedItem+"'", Connexion.cn);
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
