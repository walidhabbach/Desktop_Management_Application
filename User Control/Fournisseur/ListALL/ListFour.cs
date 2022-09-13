using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.A_M_D;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

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
                    this.DataGridView.Rows.Clear();
                    DataGridView.Columns["IDFOUR"].Width = 150;
                    DataGridView.Columns["ENTREPRISE"].Width = 300;
                    DataGridView.Columns["TELEPHONE"].Width = 300;
                    DataGridView.Columns["CATEGORIE"].Width = 300;
                    DataGridView.Columns["ADRESSE"].Width = 300;
                    DataGridView.Columns["ENTREPRISE"].DefaultCellStyle.Font = new Font("Tahoma", 15, FontStyle.Bold);
                    DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


                    //Button Delete, Edit
                    MainClass.Button_DGV(DataGridView, "Edit", "edit");
                    DataGridView.Columns["Edit"].Width = 50;
                    MainClass.Button_DGV(DataGridView, "Delete", "delete");
                    DataGridView.Columns["Delete"].Width = 50;
                    
                    while (ReadFour.Read())
                    {
                        this.DataGridView.Rows.Add(ReadFour["IDFOUR"], ReadFour["ENTREPRISE"], ReadFour["TELEPHONE"], ReadFour["CATEGORIE"], ReadFour["ADRESSE"]);
                    }
                    Conx.Close();

                    MainClass.DataGridMod(this.DataGridView);

                    

                }
                else
                {
                    MessageBox.Show("La Table Fournisseur est vide !!!");
                }

                /*if (ReadFour.HasRows)
                  {
                      
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
        {   int IDFour;
            DialogResult Dialog;
            String ColName ;
            DataGridViewRow Row;
            
           if (e.RowIndex >= 0)
            {
                Row = DataGridView.Rows[e.RowIndex];
                Row.Selected = true;
                IDFour = Convert.ToInt32(Row.Cells["IDFOUR"].Value);
                ColName = this.DataGridView.Columns[e.ColumnIndex].Name;
                if (ColName == "Edit")
                {
                    Edit(IDFour);
                }
                else if (ColName == "Delete")
                {

                    Dialog = MessageBox.Show("Do You Want To Delete " + this.DataGridView.Rows[this.DataGridView.CurrentRow.Index].Cells[1].Value.ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Dialog == DialogResult.No)
                    {
                        return;
                    }
                    Delete(IDFour);

                }
            }
        }

        private void DataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                string ColName = this.DataGridView.Columns[e.ColumnIndex].Name;

                if (ColName != "BtnEdit" && ColName != "BtnDelete")
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
}
