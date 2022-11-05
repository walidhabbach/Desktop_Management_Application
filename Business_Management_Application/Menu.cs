using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Store_Management_System.User_Control;
using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.Add_Edit.User_C;
using Store_Management_System.User_Control.Home;

namespace Store_Management_System
{
    public partial class Menu : Form
    {
        
        public Menu()
        {
            InitializeComponent();
        }

        private void Display_Click(object sender, EventArgs e)
        {
           

        }
        public void Menu_Four_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            MenuFournisseur MFour = new MenuFournisseur();
            MainClass.ShowControl(MFour,PanelContent);
     
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            Calendar MFour = new Calendar(PanelContent);
            MainClass.ShowControl(MFour, PanelContent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Backup Form = new Backup();
            Form.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PanelContent.Controls.Clear();
            Home MFour = new Home();
            MainClass.ShowControl(MFour, PanelContent);
        }

        private void PanelContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
