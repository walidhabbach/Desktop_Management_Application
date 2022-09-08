using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.Add_Edit
{
    public partial class AddCMDFOUR : UserControl
    {
        readonly int IDFOUR;
        readonly string ENTREPRISE;
        public AddCMDFOUR(int ID, string Four)
        {
            InitializeComponent();
            IDFOUR = ID;
            ENTREPRISE = Four;
        }
    }
}
