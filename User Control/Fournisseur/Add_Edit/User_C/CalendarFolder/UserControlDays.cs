using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.Add_Edit.User_C.CalendarFolder
{
    public partial class UserControlDays : UserControl
    {
        public UserControlDays(int numday)
        {
            InitializeComponent();
            lbdays.Text = numday + "";
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }
       
    }
}
