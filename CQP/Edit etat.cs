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
    public partial class Edit_etat : Form
    {
        public Edit_etat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                new Report3().Show();
                this.Hide();
            }
            else
            {
                new Report2().Show();
                this.Hide();
            }
        }
    }
}
