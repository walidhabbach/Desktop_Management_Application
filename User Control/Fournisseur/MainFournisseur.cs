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
            panel2.Controls.Clear();
            ListCMD MFour = new ListCMD(IDFOUR, panel2, 1);
            MainClass.ShowControl(MFour, panel2);
        }


        private void Button1_Click_1(object sender, EventArgs e)
        {
            PanelCMD.Visible = true;
            PanelProduit.Visible = false;
            PanelCHQ.Visible = false;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            PanelProduit.Visible = true;
            PanelCHQ.Visible = false;
            PanelCMD.Visible = false;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Add_Produit Form = new Add_Produit(IDFOUR, ENTREPRISE);
            Form.Show();
            PanelProduit.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PanelCHQ.Visible = true;
            PanelCMD.Visible = false;
            PanelProduit.Visible = false;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            PanelCHQ.Visible = false;
            panel2.Controls.Clear();
            Add_CHQ_Four MFour = new Add_CHQ_Four(IDFOUR, panel2);
            MainClass.ShowControl(MFour, panel2);

        }
        private void button5_Click(object sender, EventArgs e)
        {
            Add_CMD_Four Form = new Add_CMD_Four(IDFOUR, ENTREPRISE);
            Form.Show();
            PanelCMD.Visible = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            ListCMD MFour = new ListCMD(IDFOUR, panel2,1);
            MainClass.ShowControl(MFour, panel2);
            PanelCMD.Visible = false;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            PanelCHQ.Visible = false;
            panel2.Controls.Clear();
            ListCMD MFour = new ListCMD(IDFOUR, panel2,2);
            MainClass.ShowControl(MFour, panel2);

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            PanelCHQ.Visible = false;
            panel2.Controls.Clear();
            Add_ESP_Four MFour = new Add_ESP_Four(IDFOUR, panel2);
            MainClass.ShowControl(MFour, panel2);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            PanelCHQ.Visible = false;
            panel2.Controls.Clear();
            ListCMD MFour = new ListCMD(IDFOUR, panel2, 3);
            MainClass.ShowControl(MFour, panel2);
        }

        private void button10_Click(object sender, EventArgs e)
        {
           panel6.Visible = true;
        }
    }
}
