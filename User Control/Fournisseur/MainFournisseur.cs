using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.A_M_D;
using Store_Management_System.User_Control.Fournisseur.Add_Edit;
using Store_Management_System.User_Control.Fournisseur.ListALL;
using System;

namespace Store_Management_System.User_Control.Fournisseur
{
    public partial class MainFournisseur : System.Windows.Forms.UserControl
    {
        private readonly int IDFOUR;
        private readonly string ENTREPRISE;
        public MainFournisseur(int ID, string NFour)
        {
            InitializeComponent();
            IDFOUR = ID;
            ENTREPRISE = NFour;
        }

        private void Fournisseur_Load(object sender, EventArgs e)
        {
            label1.Text = ENTREPRISE;
            comboBox1.Text = "Lister";
            comboBox2.Text = "Lister";
            panel2.Controls.Clear();
            ListCMD MFour = new ListCMD(IDFOUR, panel2);
            MainClass.ShowControl(MFour, panel2);
        }


        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Ajouter")
            {
                Add_CMD_Four Form = new Add_CMD_Four(IDFOUR, ENTREPRISE);
                Form.Show();

            }
            else
            {
                panel2.Controls.Clear();
                ListCMD MFour = new ListCMD(IDFOUR, panel2);
                MainClass.ShowControl(MFour, panel2);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Add_Produit Form = new Add_Produit(IDFOUR, ENTREPRISE);
            Form.Show();
        }

    }
}
