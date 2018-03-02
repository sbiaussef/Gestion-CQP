using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CQP
{
    public partial class Edit_etat_avc : Form
    {
        public Edit_etat_avc()
        {
            InitializeComponent();
        }


       public static string s;
       public static string r;
        private void button1_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                
                s = "in";
                r = "Achever";
                new Report1_2().Show();
                this.Hide();
            }
            else if (radioButton2.Checked)
            {
                
                s = "not in";
                r = "En cours";
                new Report1_2().Show();
                this.Hide();
            }
            else
            {
                new Report1().Show();
                this.Hide();
             
            }
            
            
        }

        private void Edit_etat_Load(object sender, EventArgs e)
        {

        }
    }
}
