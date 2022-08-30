using Store_Management_System.Class;

using Store_Management_System.User_Control.Fournisseur;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using Store_Management_System.User_Control.Fournisseur.ListFour;
using Store_Management_System.User_Control.Fournisseur.List;
using Store_Management_System.User_Control.Fournisseur.A_M_D;

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
            FillCombobox();
            

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
            if(comboBox2.Text == "Tous")
            {
                ListFour LFour = new ListFour();
                MainClass.ShowControl(LFour, PanelFourListe);
                FillCombobox();
            }
            else
            {
                MainPanel_Four.Controls.Clear();
                //MainFournisseur Four = new MainFournisseur(Convert.ToInt32(comboBox2.SelectedValue));
                MainFournisseur Four = new MainFournisseur(2);
                MainClass.ShowControl(Four, MainPanel_Four);
            }
            
            
            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            List_Cmd_AllFour LFour = new List_Cmd_AllFour();
            MainClass.ShowControl(LFour, PanelFourListe);

        }


        private void Button2_Click(object sender, EventArgs e)
        {
            List_CHQ_AllFour LFour = new List_CHQ_AllFour();
            MainClass.ShowControl(LFour, PanelFourListe);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Add_Four myNewForm = new Add_Four();
            myNewForm.Show();
        }
        public void FillCombobox()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Tous");
            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                Conx.ConnectionString = MainClass.ConnectionDataBase();
                String Query = "SELECT * From FOURNISSEUR;";
                SqlCommand Cmd = new SqlCommand(Query, Conx);
                SqlDataAdapter Da = new SqlDataAdapter(Cmd);
                DataSet Ds = new DataSet();

                Da.Fill(Ds);
                Conx.Open();
                Cmd.ExecuteNonQuery();
                Conx.Close();

                comboBox2.DataSource = Ds.Tables[0];
                comboBox2.DisplayMember = "ENTREPRISE";
                comboBox2.ValueMember = "IDFOUR";
                
                /*
                try
                {
                    Conx.Open();
                    SqlDataReader ReadFour = Cmd.ExecuteReader();
                    if (ReadFour.HasRows)
                    {
                        while (ReadFour.Read())
                        {
                           comboBox2.Items.Add(ReadFour.GetString(1));
                        }
                    }
                    else
                    {
                        MessageBox.Show("La Table Fournisseur est vide !!!");
                    }

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }*/

            }
        }

        private void PanelFourListe_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
