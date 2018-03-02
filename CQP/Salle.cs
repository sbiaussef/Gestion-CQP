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
    public partial class Salle : Form
    {
        public Salle()
        {
            InitializeComponent();
        }
        public string s;
        private void Salle_Load(object sender, EventArgs e)
        {
            Connexion.cn.Close();
            Connexion.cn.Open();
            Connexion.dt.Columns.Clear();
            Connexion.dt.Rows.Clear();
            Connexion.cmd = new OleDbCommand("select * from salle", Connexion.cn);
            Connexion.dr = Connexion.cmd.ExecuteReader();
            Connexion.dt.Load(Connexion.dr);
            dataGridView1.DataSource = Connexion.dt;
            Connexion.dr.Close();
            Connexion.cn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != " ")
            {
                try
                {
                    s = "INSERT INTO Formateur VALUES('" + textBox1.Text + "','" + comboBox1.SelectedItem + "')";
                    Connexion.maj(s);
                    Salle_Load(sender, e);
                    textBox1.Text = " ";                    
                    comboBox1.Text = " ";
                }
                catch (Exception MSG)
                {
                    MessageBox.Show(MSG.Message);
                    comboBox1.Equals(" ");
                }
            }
            else
            {
                MessageBox.Show("remplir les champs", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != " ")
            {
                try
                {
                    s = "update Formateur set typesalle='" + comboBox1.SelectedItem + "' where idsalle='" + textBox1.Text + "'";
                    Connexion.maj(s);
                    Salle_Load(sender, e);
                    textBox1.Text = " ";
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
                    s = "delete from Formateur where idsalle='" + textBox1.Text + "'";
                    Connexion.maj(s);
                    Salle_Load(sender, e);
                    textBox1.Text = " ";
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
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
