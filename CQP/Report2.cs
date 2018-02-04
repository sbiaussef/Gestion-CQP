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
    public partial class Report2 : Form
    {
        public Report2()
        {
            InitializeComponent();
        }
        OleDbDataAdapter da;
        DataSet1 ds=new DataSet1();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Report2_Load(object sender, EventArgs e)
        {
            ds.EnforceConstraints = false;
            try
            {
                ds.Clear();
                da = new OleDbDataAdapter("select seance.idseance,seance.jour,seance.periode,seance.typeseance,seance.idformateur,seance.idmodule,seance.version,seance.idsalle,seance.idgroupe,groupe.idfiliere from seance,emploi e1,emploi e2,groupe where seance.idgroupe=groupe.codegroupe and seance.version=e1.version and datediff('d',e1.apartir,now())>=0 and seance.idgroupe=e1.idgroupe and datediff('d',e1.apartir,date())<=(select min( datediff('d',e2.apartir,date())) from emploi e2 where seance.idgroupe=e2.idgroupe and  datediff('d',e2.apartir,now())>=0)group by seance.idseance, seance.jour,seance.periode,seance.typeseance,seance.idformateur,seance.idmodule,seance.version,seance.idsalle,seance.idgroupe,groupe.idfiliere", Connexion.cn);
                da.Fill(ds, "seance");
                jourReport eta = new jourReport();
                eta.SetDataSource(ds.Tables["seance"]);
                crystalReportViewer1.ReportSource = eta;
                crystalReportViewer1.Refresh();

            }

            catch (Exception MSG)
            {
                foreach (System.Data.DataRow currentError in ds.Seance.GetErrors())
                {
                    MessageBox.Show(currentError.RowError);
                }
                MessageBox.Show(MSG.Message);
            }
            finally
            {
                Connexion.cn.Close();
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
