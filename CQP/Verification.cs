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
    public partial class Verification : Form
    {
        public Verification()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Gestion().Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                Connexion.cmd = new OleDbCommand("select  masse_horraire from FilMod where  idmodule like'" + comboBox1.SelectedItem + "' ", Connexion.cn);
                double res = (double)Connexion.cmd.ExecuteScalar();
                Connexion.dt.Columns.Clear();
                Connexion.dt.Rows.Clear();
                Connexion.cmd = new OleDbCommand("select (count(Eexecution.idseance)*2.5) as 'total realisé' ,((count(Eexecution.idseance)*2.5)*" + res + "/100) as'pourcentage',seance.idmodule from seance,Eexecution where seance.idseance=Eexecution.idseance and  seance.idmodule like'" + comboBox1.SelectedItem + "'  and  Eexecution.dateex between #" + dateTimePicker1.Value.Date + "# and #" + dateTimePicker2.Value.Date + "# group by seance.idmodule ", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                Connexion.dt.Load(Connexion.dr);
                dataGridView1.DataSource = Connexion.dt;
                Connexion.dr.Close();
                comboBox2.Items.Clear();
                Connexion.cmd = new OleDbCommand("select codegroupe from groupe where idfiliere in(select idfiliere from FilMod where idmodule like'" + comboBox1.SelectedItem + "') ", Connexion.cn);
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
            finally
            {
                Connexion.cn.Close();
            }
     
        }
        double d;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != " ")
            {
                try
                {
                    Connexion.cn.Close();
                    Connexion.cn.Open();
                    Connexion.cmd = new OleDbCommand("select count(idseance) as 'totalrealisé' from Eexecution where  dateex between #" + dateTimePicker1.Value.Date + "# and   #" + dateTimePicker2.Value.Date + "# and execute like'Oui' and idseance in(select idseance from seance where idgroupe like'" + comboBox2.SelectedItem + "' and idmodule like'" + comboBox1.SelectedItem + "')  ", Connexion.cn);
                    d = (int)Connexion.cmd.ExecuteScalar() * 2.5;
                    label6.Text = d.ToString();
                    Connexion.cmd = new OleDbCommand("select  masse_horraire from FilMod where  idmodule like'" + comboBox1.SelectedItem + "' and idfiliere in(select idfiliere from groupe where Codegroupe like'" + comboBox2.SelectedItem + "'  )", Connexion.cn);
                    double pc = (double)Connexion.cmd.ExecuteScalar();
                    label7.Text = (d * pc / 100).ToString() + "%";
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
            else MessageBox.Show("selectionné le module","attention",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void Verification_Load(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                comboBox1.Items.Clear();
                Connexion.cmd = new OleDbCommand("select idmodule from modules", Connexion.cn);
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
    }
}
