using System;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.Add_Edit
{
    public partial class Add_Produit : Form
    {
        private readonly int IDFOUR;
        public Add_Produit(int ID)
        {
            InitializeComponent();
            IDFOUR = ID;
        }


        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
