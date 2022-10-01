
using Store_Management_System.Properties;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;



namespace Store_Management_System.Class
{
    class MainClass
    {

        //public static String ConnectionString = ConfigurationManager.ConnectionStrings["Store_Management_System.Properties.Settings.DataBaseMagasinConnectionString"].ConnectionString;
        public static string ConnectionDataBase()
        {
            return ConfigurationManager.ConnectionStrings["Store_Management_System.Properties.Settings.DataBaseMagasinConnectionString"].ConnectionString;
        }
        public static int ConvertToNumber(string Mois)
        {
            //recherche du mois
            String[] tabMois = { "Janvier", "Fevrier", "Mars", "Avril", "Mai", "Juin", "Juillet", "Aout", "Septembre", "Octobre", "Novembre", "Decembre" };

            for (int i = 0; i < tabMois.Length; i++)
            {
                if (Mois.ToLower() == tabMois[i].ToLower())
                {
                    return (i + 1);
                }
            }
            return 0;
        }
        public static bool TypeCheckFloat(string input)
        {
            float Value;
            return float.TryParse(input, out Value);
        }
        public static void ShowControl(Control control, Panel Content)
        {
            Content.Controls.Clear();
            control.Dock = DockStyle.Fill;
            try
            {
                Content.Controls.Add(control);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }

        }

        public static void DataGridMod(DataGridView DGV)
        {
            //DGV.DefaultCellStyle.Font = new Font("Tahoma", 15);
            //DGV.RowHeadersVisible = false;
            //DGV.EnableHeadersVisualStyles = false;
            //DGV.RowTemplate.Height = 40;
        }

        //Retrieve number of columns in SQL Table 
        public static int NColumns(String Query)
        {
            // "SELECT count(*) FROM FOURNISSEUR"
            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                Conx.Open();
                SqlCommand Cmd = new SqlCommand(Query, Conx);

                return (Int32)Cmd.ExecuteScalar();

            }

        }

        

        // Add Edit , Delete , Print Buttons
        public static void Button_DGV(DataGridView DGV, string BtnName, string IconName)
        {

            ResourceManager Rm = Resources.ResourceManager;
            Bitmap icon = (Bitmap)Rm.GetObject(IconName);
            DataGridViewImageColumn Btn = new DataGridViewImageColumn
            {
                Name = BtnName,
                HeaderText = BtnName,
                Image = icon
            };

            //Btn.HeaderCell.Style.Padding = new Padding(10, 0, 10, 0);
            DGV.Columns.Add(Btn);

        }


    }

}
