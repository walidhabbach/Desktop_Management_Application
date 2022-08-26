﻿using Store_Management_System.Class;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using System.Reflection.Emit;
using System.Net.NetworkInformation;
using Store_Management_System.User_Control.Fournisseur.A_M_D;

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
                
                    MainClass.DataGridMod(this.DataGridView);

                    DataGridView.Columns["IDFOUR"].Width = 150;
                    DataGridView.Columns["ENTREPRISE"].Width = 300;
                    DataGridView.Columns["TELEPHONE"].Width = 300;
                    DataGridView.Columns["CATEGORIE"].Width = 300;
                    DataGridView.Columns["ADRESSE"].Width = 300;
                    DataGridView.Columns["ENTREPRISE"].DefaultCellStyle.Font = new Font("Tahoma", 15, FontStyle.Bold);


                    //Button Delete, Edit
                        MainClass.Button_DGV(DataGridView, "Edit", "edit");
                        DataGridView.Columns["Edit"].Width = 50;
                        MainClass.Button_DGV(DataGridView, "Delete", "delete");
                        DataGridView.Columns["Delete"].Width = 50;

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
        private void Edit(int IDFOUR)
        {
            Edit_Four Form = new Edit_Four(IDFOUR);
            Form.Show();
        }
        private void Delete(int IDFour)
        {
            //int position = this.DataGridView.CurrentRow.Index;
            //int IDFour = int.Parse(this.DataGridView.Rows[position].Cells[0].Value);

            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
            {

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
            DialogResult Dialog;
            String ColName = this.DataGridView.Columns[e.ColumnIndex].Name;
            DataGridViewRow Row = DataGridView.Rows[e.RowIndex];
            Row.Selected = true;
            int IDFour = Convert.ToInt32(Row.Cells["IDFOUR"].Value);

      
            if (ColName == "Edit")
            {
                Edit(IDFour);
            }
            else if(ColName == "Delete")
            {

                Dialog = MessageBox.Show("Do You Want To Delete " + this.DataGridView.Rows[this.DataGridView.CurrentRow.Index].Cells[1].Value.ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Dialog == DialogResult.No)
                {
                    return;
                }
                Delete(IDFour);

            }

        }

        private void DataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            String ColName = this.DataGridView.Columns[e.ColumnIndex].Name;

            if(ColName != "BtnEdit" && ColName != "BtnDelete")
            {
                DataGridView.Cursor = Cursors.Default;
            }
            else
            {
                DataGridView.Cursor = Cursors.Hand;
            }

        }
    }
}
