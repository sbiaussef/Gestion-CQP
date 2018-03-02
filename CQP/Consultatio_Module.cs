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
    public partial class Consultatio_Module : Form
    {
        public Consultatio_Module()
        {
            InitializeComponent();
        }

        private void Consultatio_Module_Load(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();                
                Connexion.dt.Columns.Clear();
                Connexion.dt.Rows.Clear();
                Connexion.cmd = new OleDbCommand("select modules.idmodule as Modules,modules.intituleModule as intitulé,modules.Nmodule as Numero,filmod.masse_horraire as Masse_Horraire,filmod.decoupage as Decoupage,filmod.idfiliere as filiere from modules,filmod where modules.idmodule=filmod.idmodule ", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                Connexion.dt.Load(Connexion.dr);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Connexion.dt;
                Connexion.dr.Close();
                comboBox2.Items.Clear();
                Connexion.cmd = new OleDbCommand("select idmodule from modules", Connexion.cn);
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                Connexion.dr.Close();
                Connexion.dt.Columns.Clear();
                Connexion.dt.Rows.Clear();
                Connexion.cmd = new OleDbCommand("select modules.idmodule as Modules,modules.intituleModule as intitulé,modules.Nmodule as Numero,filmod.masse_horraire as Masse_Horraire,filmod.decoupage as Decoupage,filmod.idfiliere as filiere from modules,filmod where modules.idmodule=filmod.idmodule and modules.idmodule='" + comboBox2.SelectedItem + "' and filmod.idfiliere='" + comboBox1.SelectedItem + "'", Connexion.cn);
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                Connexion.dr.Close();
                Connexion.dt.Columns.Clear();
                Connexion.dt.Rows.Clear();
                Connexion.cmd = new OleDbCommand("select modules.idmodule as Modules,modules.intituleModule as intitulé,modules.Nmodule as Numero,filmod.masse_horraire as Masse_Horraire,filmod.decoupage as Decoupage ,filmod.idfiliere as filiere from modules,filmod where modules.idmodule=filmod.idmodule and modules.idmodule='" + comboBox2.SelectedItem + "' ", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                Connexion.dt.Load(Connexion.dr);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Connexion.dt;
                comboBox1.Items.Clear();
                Connexion.cmd = new OleDbCommand("select idfiliere from FilMod where idmodule='" + comboBox2.SelectedItem + "'", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                while (Connexion.dr.Read())
                {

                    comboBox1.Items.Add(Connexion.dr[0].ToString());
                }
                comboBox1.Enabled = true;

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
