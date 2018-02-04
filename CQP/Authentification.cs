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
    public partial class Authentification : Form
    {
        public Authentification()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();

                Connexion.cmd = new OleDbCommand("select username from Uuser where username='" + textBox1.Text + "' and password='" + textBox2.Text + "'", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                    if (Connexion.dr.HasRows)
                    {
                        
                        this.Hide();
                        new Gestion().Show();

                    }
                    else { MessageBox.Show(" user or password is incorrect", "attention", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
