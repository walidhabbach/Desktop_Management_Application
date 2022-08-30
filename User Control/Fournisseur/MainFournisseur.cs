using Store_Management_System.User_Control.Fournisseur.A_M_D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur
{
    public partial class MainFournisseur : UserControl
    {
        public int IDFOUR;
        public MainFournisseur(int ID)
        {
            InitializeComponent();
            IDFOUR = ID;
        }

        private void Fournisseur_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_CMD_Four Form = new Add_CMD_Four(IDFOUR);
            Form.Show();
        }

        private void Display_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
