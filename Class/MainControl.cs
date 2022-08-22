using Store_Management_System.User_Control.Fournisseur.ListFour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace Store_Management_System.Class
{
      class MainControl
     {


        public static void ShowControl(Control control ,Panel Content)
        {
            Content.Controls.Clear();
            control.Dock = DockStyle.Fill;
            Content.Controls.Add(control);

           
        }

     }
}
