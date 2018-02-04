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
    public partial class Gestion : Form
    {
        public Gestion()
        {
            InitializeComponent();
        }
        public static string s;
       
      
        private void pictureBox1_Click(object sender, EventArgs e)
        {   
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        { 
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {  
        }

        private void Acceuil_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {          
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {           
        }

        private void nouveauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Ajouter_Filiere().Show();
           
        }

        private void miseÀJourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Maj_Filiere().Show();
        }

        private void consultationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Consultatio_Filiere().Show();
        }

        private void nouveauToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Ajouter_Formateur().Show();
        }

        private void miseÀJourToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Maj_Formateur().Show();
        }

        private void consultationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Consultatio_Formateur().Show();
        }

        private void nouveauToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new Ajouter_Module().Show();
        }

        private void miseÀJourToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new Maj_Module().Show();
        }

        private void consultationToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new Consultatio_Module().Show();
        }

        private void nouveauToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new Ajouter_Groupe().Show();
        }

        private void miseÀJoueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Maj_Groupe().Show();
        }

        private void consultationToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new Consultatio_Groupe().Show();
        }

        private void nouveauToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            new Ajouter_Salle().Show();
        }

        private void miseÀJourToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new Maj_Salle().Show();
        }

        private void consultationToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            new Consultatio_Salle().Show();
        }

        private void nouveauToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            new Emploi().Show();
        }

        private void consulationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Execution().Show();
        }

        private void editeÉtatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Edit_etat().Show();
        }

        private void avancementDesProgrammesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void realisationDesFormateursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Realisation_formateur().Show();
        }

        private void masseHorraireConventienelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new conventionelle().Show();
        }

        private void verificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Avancement().Show();
        }

        private void editEtatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Edit_etat_avc().Show();
        }



      
                

                
            }
        }

        

      
        
   
   
//}
