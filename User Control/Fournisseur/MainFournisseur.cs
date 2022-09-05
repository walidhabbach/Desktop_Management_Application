using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.A_M_D;
using Store_Management_System.User_Control.Fournisseur.Add_Edit;
using Store_Management_System.User_Control.Fournisseur.ListALL;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur
{
    public partial class MainFournisseur : UserControl
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
            panel2.Controls.Clear();
            ListCMD MFour = new ListCMD(IDFOUR);
            MainClass.ShowControl(MFour, panel2);
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        


        private void Button1_Click_1(object sender, EventArgs e)
        {
            if(comboBox1.Text == "Ajouter")
            {
                Add_CMD_Four Form = new Add_CMD_Four(IDFOUR, ENTREPRISE);
                Form.Show();
                
            }
            else
            {
                panel2.Controls.Clear();
                ListCMD MFour = new ListCMD(IDFOUR);
                MainClass.ShowControl(MFour, panel2);               
            }
        }

        

        private void Button3_Click(object sender, EventArgs e)
        {
            Add_Produit Form = new Add_Produit(IDFOUR);
            Form.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
