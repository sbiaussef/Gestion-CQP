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
    public partial class Maj_Module : Form
    {
        public Maj_Module()
        {
            InitializeComponent();
        }
        public void vider()
        {
            comboBox2.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            comboBox1.Text = " ";
            textBox5.Text = " ";

        }
        private void UpM_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                OleDbTransaction ts = Connexion.cn.BeginTransaction();
                try
                {

                    Connexion.cmd.Transaction = ts;
                    Connexion.cmd.CommandText = "update Modules set intituleModule='" + textBox2.Text + "',Nmodule='" + textBox4.Text + "' where idmodule='" + comboBox2.Text + "'";
                    Connexion.cmd.ExecuteNonQuery();
                    Connexion.cmd.CommandText = "update FilMod set masse_horraire=" + textBox3.Text + ",decoupage=" + textBox5.Text + " where idmodule='" + comboBox2.Text + "'and idfiliere='" + comboBox1.SelectedItem + "'";
                    Connexion.cmd.ExecuteNonQuery();
                    ts.Commit();
                    MessageBox.Show("Operation avec succee", "Mise a jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vider();
                    Maj_Module_Load(sender, e);
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
         if (comboBox2.Text != "")
            {
                Connexion.cn.Open();
                OleDbTransaction t = Connexion.cn.BeginTransaction();
                try
                {
                    
                    Connexion.cmd.Transaction = t;
                    Connexion.cmd.CommandText = "delete from Modules where idmodule='" + comboBox2.Text + "'";
                    Connexion.cmd.ExecuteNonQuery();
                    Connexion.cmd.CommandText = "delete from FilMod where idmodule='" + comboBox2.Text + "'and idfiliere='" + comboBox1.SelectedItem + "'";
                    Connexion.cmd.ExecuteNonQuery();
                    t.Commit();
                    MessageBox.Show("Operation avec succee", "Mise a jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vider();
                    Maj_Module_Load(sender, e);

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

        private void Maj_Module_Load(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                comboBox1.Items.Clear();
                Connexion.cmd = new OleDbCommand("select idfiliere from FilMod where idmodule='"+comboBox2.SelectedItem+"'", Connexion.cn);
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
                Connexion.dr.Close();
                Connexion.cmd = new OleDbCommand("select modules.intituleModule,modules.Nmodule,filmod.masse_horraire,filmod.decoupage from modules,filmod where modules.idmodule=filmod.idmodule and modules.idmodule='" + comboBox2.SelectedItem + "' and filmod.idfiliere='" + comboBox1.SelectedItem + "'", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                while (Connexion.dr.Read())
                {

                    textBox4.Text = Connexion.dr[1].ToString();
                    textBox2.Text = Connexion.dr[0].ToString();
                    textBox3.Text = Connexion.dr[2].ToString();
                    textBox5.Text = Connexion.dr[3].ToString();

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

        private void ADDM_Click(object sender, EventArgs e)
        {
            vider();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true; 
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true; 
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true; 
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true; 
        }
        }
    }

