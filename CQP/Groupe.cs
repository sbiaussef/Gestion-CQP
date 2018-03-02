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
    public partial class Groupe : Form
    {
        public Groupe()
        {
            InitializeComponent();
        }
        public string s;

        private void button3_Click(object sender, EventArgs e)
        {
             if (textBox1.Text != " ")
             {
                 try
                 {
                     s = "INSERT INTO Groupe VALUES('" + textBox1.Text + "'," + textBox2.Text + ",'" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.SelectedItem + "')";
                     Connexion.maj(s);
                     Groupe_Load(sender, e);
                     textBox1.Text = " ";
                     textBox2.Text = " ";
                     textBox3.Text = " ";
                     textBox4.Text = " ";
                     comboBox1.Text = " ";
                 }
                 catch (Exception MSG)
                 {
                     MessageBox.Show(MSG.Message);
                 }
             }
             else
             {
                 MessageBox.Show("remplir les champs", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             if (textBox1.Text != "")
            {
                  try
                    {
                        s = "update Groupe set effectif=" + textBox2.Text + ",responsable='" + textBox3.Text + "',supleant='" + textBox4.Text + "',idfiliere='" + comboBox1.SelectedItem + "' where Codegroupe='" + textBox1.Text + "'";
                        Connexion.maj(s);
                        Groupe_Load(sender, e);
                        textBox1.Text = " ";
                        textBox2.Text = " ";
                        textBox3.Text = " ";
                        textBox4.Text = " ";
                        comboBox1.Text = " ";
                    }
                    catch (Exception MSG)
                    {
                        MessageBox.Show(MSG.Message);
                    }
                }
                    else
                    {
                        MessageBox.Show("remplir les champs", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != " ")
            {
                try
                {
                    s = "delete from Groupe where Codegroupe='" + textBox1.Text + "'";
                    Connexion.maj(s);
                    Groupe_Load(sender, e);
                    textBox1.Text = " ";
                    textBox2.Text = " ";
                    textBox3.Text = " ";
                    textBox4.Text = " ";
                    comboBox1.Text = " ";
                }
                catch (Exception MSG)
                {
                    MessageBox.Show(MSG.Message);
                }
            }
            else
            {
                MessageBox.Show("remplir les champs", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void Groupe_Load(object sender, EventArgs e)
        {
            Connexion.cn.Close();
            comboBox1.Items.Clear();
            Connexion.cn.Open();
            Connexion.dt.Columns.Clear();
            Connexion.dt.Rows.Clear();
            Connexion.cmd = new OleDbCommand("select * from groupe", Connexion.cn);
            Connexion.dr = Connexion.cmd.ExecuteReader();
            Connexion.dt.Load(Connexion.dr);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Connexion.dt;
            Connexion.dr.Close();
            Connexion.cmd = new OleDbCommand("select idfiliere from filiere", Connexion.cn);
            Connexion.dr = Connexion.cmd.ExecuteReader();
            while (Connexion.dr.Read())
            {
                
                comboBox1.Items.Add(Connexion.dr[0]);
            }
            Connexion.cn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
