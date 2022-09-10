using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur;
using Store_Management_System.User_Control.Fournisseur.A_M_D;
using Store_Management_System.User_Control.Fournisseur.List;
using Store_Management_System.User_Control.Fournisseur.ListALL;
using Store_Management_System.User_Control.Fournisseur.ListFour;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            comboBox2.Text = "Tous";
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
            if (comboBox2.Text == "Tous")
            {
                ListFour LFour = new ListFour();
                MainClass.ShowControl(LFour, PanelFourListe);
                
            }
            else if (SearshFournisseur(comboBox2.Text.ToString()) != 0)
            {
                MainPanel_Four.Controls.Clear();
                //MainFournisseur Four = new MainFournisseur(Convert.ToInt32(comboBox2.SelectedValue));
               
                MainFournisseur Four = new MainFournisseur(SearshFournisseur(comboBox2.Text), comboBox2.Text);
                MainClass.ShowControl(Four, MainPanel_Four);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            List_Cmd_AllFour LFour = new List_Cmd_AllFour(PanelFourListe);
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
        private void FillCombobox()
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Tous");
            
            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                String Query = "SELECT * From FOURNISSEUR;";
                SqlCommand Cmd = new SqlCommand(Query, Conx);

                Conx.Open();
                SqlDataReader ReadFour = Cmd.ExecuteReader();


                // DataGridView.DefaultCellStyle.Font = new Font("Tahoma", 15);

                if (ReadFour.HasRows)
                {

                    while (ReadFour.Read())
                    {
                        comboBox2.Items.Add(ReadFour["ENTREPRISE"].ToString());   
                    }
                    Conx.Close();
                   
                }
                else
                {
                    MessageBox.Show("La Table Fournisseur est vide !!!");
                }
            }
           

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
        private int SearshFournisseur(string Four)
        {
            comboBox2.Items.Clear();
            comboBox2.Items.Add("Tous");
            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                String Query = "SELECT IDFOUR  From FOURNISSEUR WHERE ENTREPRISE = @Four;";
                SqlCommand Cmd = new SqlCommand(Query, Conx);
                Cmd.Parameters.AddWithValue("Four", Four);
                Conx.Open();
                SqlDataReader ReadFour = Cmd.ExecuteReader();


                // DataGridView.DefaultCellStyle.Font = new Font("Tahoma", 15);

                if (ReadFour.HasRows)
                {
                    while (ReadFour.Read())
                    {
                        return int.Parse(ReadFour["IDFOUR"].ToString());
                    }
                    Conx.Close();
                }
                else
                {
                    MessageBox.Show("La Table Fournisseur est vide !!!"); 
                }
            }
            return 0;

        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Display_Click(sender, e);
        }

        private void PanelFourListe_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
