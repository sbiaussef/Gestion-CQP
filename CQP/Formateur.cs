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
    public partial class Formateur : Form
    {
        public Formateur()
        {
            InitializeComponent();
        }
        public string s;

        private void Formateur_Load(object sender, EventArgs e)
        {
            Connexion.cn.Close();
            comboBox1.Items.Clear();
            Connexion.cn.Open();
            Connexion.dt.Columns.Clear();
            Connexion.dt.Rows.Clear();
            Connexion.cmd = new OleDbCommand("select * from formateur", Connexion.cn);
            Connexion.dr = Connexion.cmd.ExecuteReader();
            Connexion.dt.Load(Connexion.dr);
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

        private void AddF_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != " ")
            {
                try
                {
                    s = "INSERT INTO Formateur VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.SelectedItem + "')";
                    Connexion.maj(s);
                    Formateur_Load(sender, e);
                    textBox1.Text = " ";
                    textBox2.Text = " ";                
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

        private void UpF_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != " ")
            {
                try
                {
                    s = "update Formateur set matricule='" + textBox2.Text + "',idfiliere='" + comboBox1.SelectedItem + "' where nom_prenom='"+textBox1.Text+"'";
                    Connexion.maj(s);
                    Formateur_Load(sender, e);
                    textBox1.Text = " ";
                    textBox2.Text = " ";
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

        private void RemoveF_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != " ")
            {
                try
                {
                    s = "delete from Formateur where nom_prenom='" + textBox1.Text + "'";
                    Connexion.maj(s);
                    Formateur_Load(sender, e);
                    textBox1.Text = " ";
                    textBox2.Text = " ";
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
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
