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
    public partial class Impession : Form
    {
        public Impession()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Report2().Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Report1().Show();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Gestion().Show();
        }
    }
}
