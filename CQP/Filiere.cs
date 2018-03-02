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
    public partial class Filiere : Form
    {
        public Filiere()
        {
            InitializeComponent();
        }
        public static string t;
       
        private void ADDFil_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                try
                {
                    t = "INSERT INTO Filiere VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.SelectedItem + "'," + textBox3.Text + ")";
                    Connexion.maj(t);
                    Filiere_Load(sender, e);
                    textBox1.Text = " ";
                    textBox2.Text = " ";
                    textBox3.Text = " ";
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

        private void UPFil_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    t = "update Filiere set intitulefiliere='" + textBox2.Text + "',niveau_enseigne='" + comboBox1.Text + "',plafond_horraire=" + textBox3.Text + " where idfiliere='" + textBox1.Text + "'";
                    Connexion.maj(t);
                    Filiere_Load(sender, e);
                    textBox1.Text = " ";
                    textBox2.Text = " ";
                    textBox3.Text = " ";
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

        private void RemoveFil_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    t = "delete from Filiere where idfiliere='" + textBox1.Text + "'";
                    Connexion.maj(t);
                    Filiere_Load(sender,e);
                    textBox1.Text = " ";
                    textBox2.Text = " ";
                    textBox3.Text = " ";
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
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void Filiere_Load(object sender, EventArgs e)
        {
            
            Connexion.cn.Close();
            Connexion.cn.Open();
            Connexion.dt.Columns.Clear();
            Connexion.dt.Rows.Clear();
            Connexion.cmd = new OleDbCommand("select * from Filiere", Connexion.cn);
            Connexion.dr = Connexion.cmd.ExecuteReader();
            Connexion.dt.Load(Connexion.dr);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Connexion.dt;
            Connexion.cn.Close();
        
     
        }
    }
}
