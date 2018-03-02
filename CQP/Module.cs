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
    public partial class Module : Form
    {
        public Module()
        {
            InitializeComponent();
        }
        public void vider()
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            comboBox1.Text = " ";
            textBox5.Text = " ";
        
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Connexion.pic = 2;
            this.Hide();

        }

        private void ADDM_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != " ")
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                OleDbTransaction t = Connexion.cn.BeginTransaction();
                try
                {
                    
                    Connexion.cmd.Transaction = t;
                    Connexion.cmd.CommandText = "INSERT INTO Modules VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "')";
                    Connexion.cmd.ExecuteNonQuery();
                    Connexion.cmd.CommandText = "INSERT INTO FilMod VALUES('" + comboBox1.SelectedItem + "','" + textBox1.Text + "'," + textBox3.Text + "," + textBox5.Text + ")";
                    Connexion.cmd.ExecuteNonQuery();
                    t.Commit();
                    MessageBox.Show("Operation avec succee", "Mise a jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Module_Load(sender, e);
                    vider();
                }
                catch (Exception MSG)
                {
                   
                    MessageBox.Show(MSG.Message);
                    t.Rollback();
                }
                finally
                {
                    Connexion.cn.Close();
                }
            }
            else
            { MessageBox.Show("remplir les champs", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void UpM_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                OleDbTransaction ts = Connexion.cn.BeginTransaction();
                try
                {
                    
                    Connexion.cmd.Transaction = ts;
                    Connexion.cmd.CommandText = "update Modules set intituleModule='" + textBox2.Text + "',Nmodule='" + textBox4.Text + "' where idmodule='" + textBox1.Text + "'";
                    Connexion.cmd.ExecuteNonQuery();
                    Connexion.cmd.CommandText = "update FilMod set masse_horraire="+textBox3.Text+",decoupage="+textBox5.Text+" where idmodule='" + textBox1.Text + "'and idfiliere='" + comboBox1.SelectedItem + "'";
                    Connexion.cmd.ExecuteNonQuery();
                    ts.Commit();
                    MessageBox.Show("Operation avec succee", "Mise a jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Module_Load(sender, e);
                    vider();
                }
                catch (Exception MSG)
                {
                    
                    MessageBox.Show(MSG.Message);
                    ts.Rollback();
                }
                finally
                {
                    Connexion.cn.Close();
                }
            }
            else
            { MessageBox.Show("remplir les champs", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void RemoveM_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Connexion.cn.Open();
                OleDbTransaction t = Connexion.cn.BeginTransaction();
                try
                {
                    
                    Connexion.cmd.Transaction = t;
                    Connexion.cmd.CommandText = "delete from Modules where idmodule='" + textBox1.Text + "'";
                    Connexion.cmd.ExecuteNonQuery();
                    Connexion.cmd.CommandText = "delete from FilMod where idmodule='" + textBox1.Text + "'and idfiliere='" + comboBox1.SelectedItem + "'";
                    Connexion.cmd.ExecuteNonQuery();
                    t.Commit();
                    MessageBox.Show("Operation avec succee", "Mise a jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Module_Load(sender, e);
                    vider();

                }
                catch (Exception MSG)
                {
                    
                    MessageBox.Show(MSG.Message);
                    t.Rollback();
                }
                finally
                {
                    Connexion.cn.Close();
                }
            }
            else
            { MessageBox.Show("remplir les champs", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void Module_Load(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                Connexion.dt.Columns.Clear();
                Connexion.dt.Rows.Clear();
                Connexion.cmd = new OleDbCommand("select Modules.idmodule as idmodule,Modules.intituleModule as intitule,Modules.Nmodule as Numero,FilMod.idfiliere as idFiliere,FilMod.masse_horraire as Masses_horraires,FilMod.decoupage as Decoupages from Modules,FilMod where Modules.idmodule=FilMod.idmodule", Connexion.cn);
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
            }
            
          
                Connexion.cn.Close();
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
    }
}
