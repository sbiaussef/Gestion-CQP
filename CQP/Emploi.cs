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

 
        private void Emploi_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox2.Enabled = false;
            UPG.Enabled = false;
            RemoveG.Enabled = false;
            button1.Enabled = false;
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
          

        private void button1_Click(object sender, EventArgs e)
        {
                comboBox3.Text = "";
                comboBox4.Text="";
                comboBox5.Text="";
                comboBox6.Text="";
                comboBox7.Text="";
                comboBox8.Text="";
                dataGridView1.Rows.Clear();
        }


        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            c = dateTimePicker1.Text;
            groupBox2.Enabled = true;
     
        }

        private void comboBox5_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                comboBox8.Items.Clear();
                Connexion.cmd = new OleDbCommand("select idmodule from FilMod where idfiliere=(select idfiliere from Formateur where nom_prenom='"+ comboBox5.SelectedItem +"')", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                while (Connexion.dr.Read())
                {
                    comboBox8.Items.Add(Connexion.dr[0]);
                }
                Connexion.dr.Close();
                Connexion.cmd = new OleDbCommand("select count(idseance) from seance where  idgroupe <>'"+ comboBox1.Text +"' and idformateur='"+ comboBox5.SelectedItem +"' and  idseance in(select idseance from Eexecution where  datediff('d',dateex,date())<=7) ", Connexion.cn);
                int  res = (int)Connexion.cmd.ExecuteScalar();
                label12.Text = (res*2.5).ToString()+" h/s";
                groupBox4.Enabled = true;
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

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            b = (string)comboBox1.SelectedItem.ToString();
            textBox1.Text = a + "_" + b + "_ " + c;
            ADDG.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            a = (string)comboBox2.SelectedItem.ToString();
            textBox1.Text = a;
        }

        private void comboBox7_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                comboBox5.Items.Clear();
                Connexion.cmd = new OleDbCommand("select nom_prenom from Formateur where  nom_prenom not in(select idformateur from Seance where  jour ='" + comboBox4.SelectedItem + "' and periode = '" + comboBox6.SelectedItem + "' and typeseance ='" + comboBox7.SelectedItem + "' and version =(select version from emploi where idgroupe<>'" + comboBox1.SelectedItem + "' and datediff('d',emploi.apartir,date())<=all(select datediff('d',emploi.apartir,date()) from emploi where idgroupe<>'" + comboBox1.SelectedItem + "' ))) ", Connexion.cn);
                Connexion.dr = Connexion.cmd.ExecuteReader();
                while (Connexion.dr.Read())
                {
                    comboBox5.Items.Add(Connexion.dr[0]);
                }
                Connexion.dr.Close();
                groupBox3.Enabled = true;
                
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

        private void ADDG_Click_1(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            
            
            button1.Enabled = true;
            if (comboBox1.Text != "" && comboBox2.Text != "" && dateTimePicker1.Text != "")
            {
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                dateTimePicker1.Enabled = false;
                try
                {
                    t = "INSERT INTO emploi VALUES('" + textBox1.Text.ToString() + "','" + dateTimePicker1.Value + "',date(),'" + comboBox1.SelectedItem.ToString() + "')";
                    Connexion.sean(t);
                }
                catch (Exception MSG)
                {
                    MessageBox.Show(MSG.Message);
                }
            }
            else
                MessageBox.Show("remplir les champs", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void UPG_Click_1(object sender, EventArgs e)
        {
            if (comboBox3.Text != " " && comboBox4.Text != " " && comboBox5.Text != " " && comboBox6.Text != " " && comboBox7.Text != " " && comboBox7.Text != " " && comboBox8.Text != " ")
            {
                dataGridView1.Rows.Add(comboBox4.Text, comboBox5.Text, comboBox6.Text, comboBox7.Text, comboBox8.Text, comboBox3.Text);
            }
            else
            {
                MessageBox.Show("remplir les champs", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (comboBox6.Text == "Après-midi" && comboBox7.Text == "Seance 2")
            {
                comboBox3.Text = "";
                comboBox4.Text = "";
                comboBox5.Text = "";
                comboBox6.Text = "";
                comboBox7.Text = "";
                comboBox8.Text = "";
            }
            else if (comboBox7.Text == "Seance 2" )
            {
                comboBox3.Text = "";               
                comboBox5.Text = "";
                comboBox6.Text = "";
                comboBox7.Text = "";
                comboBox8.Text = "";
            }
            RemoveG.Enabled = true;
        }

        private void RemoveG_Click_1(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
                {
                    Connexion.cmd = new OleDbCommand("INSERT INTO Seance VALUES('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "_" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "_" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "_" + textBox1.Text + "','" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + a + "', '" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "', '" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + a + "_" + b + "_ " + c + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "')", Connexion.cn);
                    Connexion.cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Operation avec succee", "Mise a jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            comboBox8.Text = "";
            dataGridView1.Rows.Clear();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            UPG.Enabled = true;
            
        }
        public string s;
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != " ")
            {
                try
                {
                    s = "delete from Emploi where version='" + textBox1.Text + "'";
                    Connexion.maj(s);
                    textBox1.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    comboBox4.Text = "";
                    comboBox5.Text = "";
                    comboBox6.Text = "";
                    comboBox7.Text = "";
                    comboBox8.Text = "";
                    dataGridView1.Rows.Clear();
                    dateTimePicker1.Enabled = true;
                    Emploi_Load(sender, e);

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
  
        }
    }
