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
    public partial class Execution : Form
    {
        public Execution()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Execution_Load(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                comboBox2.Items.Clear();
                Connexion.cmd = new OleDbCommand("select idfiliere from filiere", Connexion.cn);
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Connexion.cn.Close();
                Connexion.cn.Open();
                comboBox1.Items.Clear();
                Connexion.cmd = new OleDbCommand("select codegroupe from groupe where idfiliere='" + comboBox2.SelectedItem + "'", Connexion.cn);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != " ")
            {

                try
                {
                    Connexion.cn.Close();
                    Connexion.cn.Open();
                    dataGridView1.Rows.Clear();
                    Connexion.dt.Columns.Clear();
                    Connexion.dt.Rows.Clear();
                    Connexion.cmd = new OleDbCommand("select jour,periode,typeseance,idformateur,idmodule,idseance from seance where idgroupe='" + comboBox1.SelectedItem + "' and version in(select version from emploi where datediff('d',apartir,now())>=0 and datediff('d',apartir,now())<=(select min(datediff('d',apartir,now())) from emploi where  idgroupe='" + comboBox1.SelectedItem + "' and datediff('d',apartir,now())>=0 )) ", Connexion.cn);
                    Connexion.dr = Connexion.cmd.ExecuteReader();
                    Connexion.dt.Load(Connexion.dr);
                    for (int i = 0; i < Connexion.dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add(Connexion.dt.Rows[i][0], Connexion.dt.Rows[i][1], Connexion.dt.Rows[i][2], Connexion.dt.Rows[i][3], Connexion.dt.Rows[i][4]);
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
            else MessageBox.Show("selectionné la filiere svp", "attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                try
                {
                    Connexion.cn.Close();
                    Connexion.cn.Open();
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        Connexion.cmd = new OleDbCommand("select count(idexecution) from Eexecution", Connexion.cn);
                        int c = (int)Connexion.cmd.ExecuteScalar() + 1;
                        Connexion.cmd = new OleDbCommand("INSERT INTO Eexecution VALUES(" + c + ",'" + dataGridView1.Rows[i].Cells[5].Value + "',date(),'" + Connexion.dt.Rows[i][5] + "')", Connexion.cn);
                        Connexion.cmd.ExecuteNonQuery();

                    } MessageBox.Show("Operation avec succee", "Mise a jour", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
