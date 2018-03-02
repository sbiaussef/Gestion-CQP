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
    public partial class Ajouter_Module : Form
    {
        public Ajouter_Module()
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



        private void Module_Load(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
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

        private void UpM_Click(object sender, EventArgs e)
        {
            vider();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true; 
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true; 
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true; 
        }

 
    }
}
