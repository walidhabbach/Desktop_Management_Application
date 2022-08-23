using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur;
using Store_Management_System.User_Control.Fournisseur.A_M_D;
using Store_Management_System.User_Control.Fournisseur.List;
using Store_Management_System.User_Control.Fournisseur.ListFour;
using System;

using System.Windows.Forms;


namespace Store_Management_System.User_Control
{
    public partial class MenuFournisseur : UserControl
    {
        public MenuFournisseur()
        {
            InitializeComponent();
        }

        private void MenuFournisseur_Load(object sender, EventArgs e)
        {
            ListFour LFour = new ListFour();
            MainClass.ShowControl(LFour, PanelFourListe);
        }

        /*public void DisplayListFour()
        {
            PanelFourListe.Controls.Clear();
            ListFour LFour = new ListFour();
            LFour.Dock = DockStyle.Fill;
            PanelFourListe.Controls.Add(LFour);
        }*/
        private void Display_Click(object sender, EventArgs e)
        {
            ListFour LFour = new ListFour();
            MainClass.ShowControl(LFour, PanelFourListe);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List_Cmd_AllFour LFour = new List_Cmd_AllFour();
            MainClass.ShowControl(LFour, PanelFourListe);

        }


        private void button2_Click(object sender, EventArgs e)
        {
            List_CHQ_AllFour LFour = new List_CHQ_AllFour();
            MainClass.ShowControl(LFour, PanelFourListe);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Add_Four myNewForm = new Add_Four();
            myNewForm.Show();
        }

        private void PanelFourListe_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OperationPanel_Enter(object sender, EventArgs e)
        {

        }
    }
}
