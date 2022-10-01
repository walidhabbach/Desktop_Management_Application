using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.WinForms;
using Store_Management_System.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReportDataSource = Microsoft.Reporting.WinForms.ReportDataSource;

namespace Store_Management_System.User_Control.Save
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
 
                SqlCommand Cmd = new SqlCommand($"EXECUTE CHEQUE_FOURNISSEUR_All '{2022}';", Conx);
                Conx.Open();  
                SqlDataAdapter data = new SqlDataAdapter(Cmd);
                DataTable dt = new DataTable(); 
                data.Fill(dt);
                ReportDataSource rds = new ReportDataSource("DataSet1",dt);
                reportViewer1.LocalReport.ReportPath = @"C:\\Users\\MT\\Documents\\code blocks\\csharp\\Magasin\\Desktop App\\User Control\\Save\\Report.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
         

            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
        }
    }
}
