using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.A_M_D;
using Store_Management_System.User_Control.Fournisseur.Add_Edit;
using Store_Management_System.User_Control.Fournisseur.ListALL;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur
{
    public partial class MainFournisseur : System.Windows.Forms.UserControl
    {
        private readonly int IDFOUR;
        public string Period = DateTime.Now.ToString();
        private readonly string ENTREPRISE;
        public int load = 0;
        public MainFournisseur(int ID, string NFour)
        {
            InitializeComponent();
            IDFOUR = ID;
            ENTREPRISE = NFour;
        }
        public void SetMyCustomFormat()
        {
            // Set the Format type and the CustomFormat string. 
            //dateTimePicker2.CustomFormat = "MMMM yyyy";
            //dateTimePicker2.ShowUpDown = true;

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MMMM yyyy";
        }
        private void Fournisseur_Load(object sender, EventArgs e)
        {
            label1.Text = ENTREPRISE;
            Button();
            dateTimePicker2.Value = DateTime.Now;
            SetMyCustomFormat();
            Period = DateTime.Now.ToString();

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
            panel6.Visible = false;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            PanelCHQ.Visible = false;
            PanelDataProduit.Visible = false;
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
            load = 1;
            PanelDataProduit.Visible = false;
            panel2.Controls.Clear();
            List_Main_Four MFour = new List_Main_Four(IDFOUR, panel2, 1, Period, dateTimePicker2.Value.Year);
            MainClass.ShowControl(MFour, panel2);
            PanelCMD.Visible = false;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            load = 3;
            PanelDataProduit.Visible = false;
            PanelCHQ.Visible = false;
            panel2.Controls.Clear();
            List_Main_Four MFour = new List_Main_Four(IDFOUR, panel2, 3, Period, dateTimePicker2.Value.Year);
            MainClass.ShowControl(MFour, panel2);

        }
        private void Button()
        {
            //Button Delete, Edit
            MainClass.Button_DGV(dataGridView1, "Edit", "edit");
            dataGridView1.Columns["Edit"].Width = 80;
            MainClass.Button_DGV(dataGridView1, "Delete", "delete");
            dataGridView1.Columns["Delete"].Width = 80;
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            load = 2;
            PanelProduit.Visible = false;
            panel2.Controls.Clear();
            List_Main_Four MFour = new List_Main_Four(IDFOUR, panel2, 2, Period, dateTimePicker2.Value.Year);
            MainClass.ShowControl(MFour, panel2);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            PanelCHQ.Visible = false;
            PanelDataProduit.Visible = false;
            panel2.Controls.Clear();
            Add_ESP_Four MFour = new Add_ESP_Four(IDFOUR, panel2);
            MainClass.ShowControl(MFour, panel2);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            load = 4;
            panel6.Visible = false;
            panel2.Controls.Clear();
            List_Main_Four MFour = new List_Main_Four(IDFOUR, panel2, 4, Period, dateTimePicker2.Value.Year);
            MainClass.ShowControl(MFour, panel2);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
            PanelCHQ.Visible = false;
            PanelCMD.Visible = false;
            PanelProduit.Visible = false;
        }

        private void panel2_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }
        private void loadList(object sender, EventArgs e)
        {

            if (load == 1)
            {
                button2_Click(sender, e);
            }
            else if (load == 3)
            {
                button9_Click(sender, e);
            }
            else if (load == 4)
            {
                button12_Click(sender, e);
            }
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            SetMyCustomFormat();
            Period = dateTimePicker2.Value.ToString();
            loadList(sender, e);
        }


        private void button13_Click(object sender, EventArgs e)
        {
            Period = "Tous";
            loadList(sender, e);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
