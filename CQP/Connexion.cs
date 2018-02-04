using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace CQP
{
    class Connexion
    {
        public static OleDbConnection cn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\sbia\Desktop\CQP\CQP\CQP.mdb");
        public static OleDbCommand cmd=cn.CreateCommand();
        public static OleDbDataReader dr;
        public static DataTable dt = new DataTable();
        public static int pic;
        

        public static void maj(string s)
        {
            cn.Close();
            cn.Open();
            cmd = new OleDbCommand(s, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Operation avec succee","Mise a jour",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        public static void sean(string s)
        {
            cn.Close();
            cn.Open();
            cmd = new OleDbCommand(s, cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            
        }
        public static void grid(DataGridView d,string s)
        {
            cn.Close();
            cn.Open();
            dt.Columns.Clear();
            dt.Rows.Clear();
            cmd = new OleDbCommand(s, cn);
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            d.DataSource = dt;
            dr.Close();
            cn.Close();
            
        
        }

        public static void comb(ComboBox c,string s)
        {

            cn.Open();
            cmd = new OleDbCommand(s, cn);
            dr=cmd.ExecuteReader();
            while (dr.Read())
            {
                c.Items.Add(dr[0]);
            }
            cn.Close();
        }
        
    }
}
