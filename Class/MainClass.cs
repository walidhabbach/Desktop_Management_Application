
using System.Configuration;
using System.Windows.Forms;



namespace Store_Management_System.Class
{
      class MainClass
     {
        //public static String ConnectionString = ConfigurationManager.ConnectionStrings["Store_Management_System.Properties.Settings.DataBaseMagasinConnectionString"].ConnectionString;
        public static string ConnectionDataBase()
        {
            return ConfigurationManager.ConnectionStrings["Store_Management_System.Properties.Settings.DataBaseMagasinConnectionString"].ConnectionString ;
        }
        public static void ShowControl(Control control ,Panel Content)
        {
            Content.Controls.Clear();
            control.Dock = DockStyle.Fill;
            Content.Controls.Add(control);

           
        }


    }

}
