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
    public partial class Emploi : Form
    {
        public Emploi()
        {
            InitializeComponent();
        }
        public string a;
        public string b;
        public string c;
        public string d;
        public string t;
        public string k=" ";
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Gestion().Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox8.Visible = true;
            pictureBox2.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            new Execution().Show();

        }

        private void Emploi_Load(object sender, EventArgs e)
        {
            pictureBox8.Visible = false;
            pictureBox2.Visible = false;
            groupBox1.Visible = false;
            ADDG.Enabled = false;
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                Connexion.cmd = new OleDbCommand("select Groupe.codegroupe from Groupe", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                while (Connexion.dr.Read())
                {
                    comboBox1.Items.Add(Connexion.dr[0]);
                }
                Connexion.dr.Close();
                Connexion.cmd = new OleDbCommand("select Filiere.idfiliere from Filiere", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                while (Connexion.dr.Read())
                {
                    comboBox2.Items.Add(Connexion.dr[0]);
                }
                Connexion.dr.Close();
                Connexion.cmd = new OleDbCommand("select salle.idsalle from salle", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                while (Connexion.dr.Read())
                {
                    comboBox3.Items.Add(Connexion.dr[0]);
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            a =(string) comboBox1.SelectedItem.ToString();
            textBox1.Text = a;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            b = (string) comboBox2.SelectedItem.ToString();
            textBox1.Text = a + "_" + b;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            c = dateTimePicker1.Text;
            textBox1.Text = a + "_" + b + "_ " + c;
            ADDG.Enabled = true;

        }

        private void ADDG_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && dateTimePicker1.Text != "")
            {
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                dateTimePicker1.Enabled = false;
                try
                {
                    t = "INSERT INTO emploi VALUES('" + textBox1.Text.ToString() + "','" + dateTimePicker1.Value + "',date(),'" + comboBox1.SelectedItem.ToString() + "')";
                    Connexion.maj(t);
                }
                catch (Exception MSG)
                {
                    MessageBox.Show(MSG.Message);
                }
            }
            else
                MessageBox.Show("remplir les champs", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                comboBox8.Items.Clear();
                Connexion.cmd = new OleDbCommand("select idmodule from FilMod where idfiliere=(select idfiliere from Formateur where nom_prenom='" + comboBox5.SelectedItem + "')", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                while (Connexion.dr.Read())
                {
                    comboBox8.Items.Add(Connexion.dr[0]);
                }
                Connexion.dr.Close();
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

        private void UPG_Click(object sender, EventArgs e)
        {
             
            dataGridView1.Rows.Add(comboBox4.SelectedItem, comboBox5.SelectedItem, comboBox6.SelectedItem, comboBox7.SelectedItem, comboBox8.SelectedItem,comboBox3.SelectedItem);
        }
     
        private void RemoveG_Click(object sender, EventArgs e)
        {
            int q = 0;
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                for (int i = 0; i < (int)dataGridView1.Rows.Count; i++)
                {
                    Connexion.cmd = new OleDbCommand("INSERT INTO Seance VALUES('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "_" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "_" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "_" + textBox1.Text + "','" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + a + "', '" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "', '" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + a + "_" + b + "_ " + c + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "')", Connexion.cn);
                    Connexion.cmd.ExecuteNonQuery();
                    q = 1;
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
            
            if (q == 1)
            {
                MessageBox.Show("Operation avec succee", "Mise a jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            }                

        private void button1_Click(object sender, EventArgs e)
        {
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                dateTimePicker1.Enabled = true;    
                comboBox1.Text = " ";
                comboBox2.Text = " ";
                dateTimePicker1.Refresh();
                textBox1.Text = " ";
                comboBox4.Text="";
                comboBox5.Text="";
                comboBox6.Text="";
                comboBox7.Text="";
                comboBox8.Text="";
                dataGridView1.Rows.Clear();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                Connexion.cmd = new OleDbCommand("select nom_prenom from Formateur where idfiliere='" + comboBox2.Text + "' and nom_prenom not in(select idformateur from Seance where  jour ='" + comboBox4.SelectedItem + "' and periode = '" + comboBox6.SelectedItem + "' and typeseance ='" + comboBox7.SelectedItem + "' and version =(select version from emploi where idgroupe<>'" + comboBox1.SelectedItem + "' and datediff('d',emploi.apartir,date())<=all(select datediff('d',emploi.apartir,date()) from emploi where idgroupe<>'" + comboBox1.SelectedItem + "' ))) ", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                while (Connexion.dr.Read())
                {
                    comboBox5.Items.Add(Connexion.dr[0]);
                }
                Connexion.dr.Close();
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            pictureBox8.Visible = false;
            groupBox1.Visible = true;
            groupBox2.Visible = true;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }
        }
    }
