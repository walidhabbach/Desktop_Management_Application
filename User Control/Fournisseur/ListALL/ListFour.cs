﻿using Store_Management_System.Class;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using System.Reflection.Emit;

namespace Store_Management_System.User_Control.Fournisseur.ListFour
{
    public partial class ListFour : UserControl
    {
     
        public ListFour()
        {
            InitializeComponent();
        }

        private void ListFour_Load(object sender, EventArgs e)
        {
  
            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {
                Conx.ConnectionString = MainClass.ConnectionDataBase(); 
                String Query = "SELECT * From FOURNISSEUR;";
                SqlCommand Cmd = new SqlCommand(Query, Conx);

                Conx.Open();
                SqlDataReader ReadFour = Cmd.ExecuteReader();

                    
                // DataGridView.DefaultCellStyle.Font = new Font("Tahoma", 15);

                if (ReadFour.HasRows)
                {
                    
                    DataTable Data = new DataTable();
                    DataGridView.Columns.Clear();

                    Data.Load(ReadFour);
                    DataGridView.DataSource = Data;
                
                    MainClass.DataGridMod(DataGridView , 40);
                    DataGridView.Columns["IDFOUR"].Width = 150;
                    DataGridView.Columns["ENTREPRISE"].Width = 300;
                    DataGridView.Columns["TELEPHONE"].Width = 300;
                    DataGridView.Columns["CATEGORIE"].Width = 300;
                    DataGridView.Columns["ADRESSE"].Width = 300;
                    DataGridView.Columns["ENTREPRISE"].DefaultCellStyle.Font = new Font("Tahoma", 15, FontStyle.Bold);

                }
                else
                {
                    MessageBox.Show("La Table Fournisseur est vide !!!");
                }

                /*if (ReadFour.HasRows)
                  {
                      this.DataGridView.Rows.Clear();
                      while (ReadFour.Read())
                      {
                          this.DataGridView.Rows.Add(ReadFour["IDFOUR"], ReadFour["ENTREPRISE"], ReadFour["TELEPHONE"], ReadFour["CATEGORIE"], ReadFour["ADRESSE"]);

                      }
                      Conx.Close();
                  }
                  else
                  {
                      MessageBox.Show("La Table Fournisseur est vide !!!");

                  }*/
            }
        }

        private void DataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int position = this.DataGridView.CurrentRow.Index;
            int IDFour = int.Parse(this.DataGridView.Rows[position].Cells[0].Value.ToString());

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {

                DialogResult Dialog = MessageBox.Show("Do You Want To Delete "+ this.DataGridView.Rows[position].Cells[1].Value, "Confirmation", MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if(Dialog == DialogResult.No)
                {
                    return;
                }
                SqlCommand Cmd = new SqlCommand
                {
                    Connection = Conx,
                    CommandText = "DELETE FROM FOURNISSEUR WHERE IDFOUR = @IDFour;"
                };
                
                try
                {
                    Cmd.Parameters.AddWithValue("@IDFour", IDFour);
                    Conx.Open();
                    Cmd.ExecuteNonQuery();
                    Conx.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            

            }
    }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
