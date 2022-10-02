using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.Add_Edit.User_C;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.Add_Edit.Forms
{
    public partial class Category : Form
    {
        Panel PanelContent;
        public Category(Panel PanelContent)
        {
            InitializeComponent();
            this.PanelContent = PanelContent;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Button2.Visible == false)
            {
                this.dataGridView1.Rows.Add();
            }

            Button2.Visible = true;

        }
        private void LoadCategory()
        {
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    Conx.ConnectionString = MainClass.ConnectionDataBase();
                    String Query = "SELECT * From CALENDAR;";
                    SqlCommand Cmd = new SqlCommand(Query, Conx);

                    Conx.Open();
                    SqlDataReader Read = Cmd.ExecuteReader();


                    // DataGridView.DefaultCellStyle.Font = new Font("Tahoma", 15);

                    if (Read.HasRows)
                    {
                        this.dataGridView1.Rows.Clear();

                        while (Read.Read())
                        {
                            // add new header
                            this.dataGridView1.Rows.Add(Read[0], Read[1]);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Aucune catégorie existe !!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Category_Load(object sender, EventArgs e)
        {
            AddButtons();
            LoadCategory();
        }

        private void AddButtons()
        {
            //Button Delete, Edit
            MainClass.Button_DGV(dataGridView1, "Edit", "edit3");
            dataGridView1.Columns["Edit"].Width = 40;
            MainClass.Button_DGV(dataGridView1, "Delete", "delete3");
            dataGridView1.Columns["Delete"].Width = 40;
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[1].Value == null || this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[1].Value == DBNull.Value || String.IsNullOrWhiteSpace((string)this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[1].Value))
                {
                    return;
                }
                string temp = this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[1].Value.ToString();

                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    Conx.ConnectionString = MainClass.ConnectionDataBase();
                    String Query = $"INSERT INTO CALENDAR (Category) VALUES('{temp}') ;";
                    SqlCommand Cmd = new SqlCommand(Query, Conx);

                    Conx.Open();
                    Cmd.ExecuteNonQuery();

                    PanelContent.Controls.Clear();
                    Calendar MFour = new Calendar(PanelContent);
                    MainClass.ShowControl(MFour, PanelContent);

                }
                MessageBox.Show("Enregistrer avec succès");
                Button2.Visible = false;
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void Edit(int id, string category)
        {
            try
            {

                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    string Query = $"UPDATE CALENDAR SET Category = '{category}' WHERE idCalendar = '{id}' ;";
                    SqlCommand Cmd = new SqlCommand(Query, Conx);

                    Conx.Open();
                    Cmd.ExecuteNonQuery();

                    Conx.Close();
                }

                LoadCategory();
                MessageBox.Show("Modifie avec succès");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Delete(int id)
        {
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {

                    SqlCommand Cmd = new SqlCommand
                    {
                        Connection = Conx,
                        CommandText = $"DELETE FROM CALENDAR WHERE idCalendar = '{id}' ;"
                    };

                    Conx.Open();
                    Cmd.ExecuteNonQuery();
                    Conx.Close();
                    LoadCategory();
                    MessageBox.Show("Suppression  avec succès");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {

                    DialogResult Dialog;
                    String ColName;
                    DataGridViewRow Row;
                    Row = dataGridView1.Rows[e.RowIndex];
                    Row.Selected = true;

                    ColName = this.dataGridView1.Columns[e.ColumnIndex].Name;

                    if (ColName == "Edit" && Button2.Visible == false)
                    {
                        if (Row.Cells[1].Value == null || Row.Cells[1].Value == DBNull.Value)
                        {
                            return;
                        }
                        else
                        {

                            Edit(Convert.ToInt32(Row.Cells[0].Value), Row.Cells[1].Value.ToString());
                            PanelContent.Controls.Clear();
                            Calendar MFour = new Calendar(PanelContent);
                            MainClass.ShowControl(MFour, PanelContent);
                        }

                    }
                    else if (ColName == "Delete" && Button2.Visible == false)
                    {
                        Dialog = MessageBox.Show("Do You Want To Delete " + this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[1].Value.ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Dialog == DialogResult.No)
                        {
                            return;
                        }
                        Delete(Convert.ToInt32(Row.Cells[0].Value));

                    }
                    else if (ColName == "Delete" && Button2.Visible == true)
                    {
                        this.dataGridView1.Rows.RemoveAt(e.RowIndex);
                        Button2.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                string ColName = this.dataGridView1.Columns[e.ColumnIndex].Name;

                if (ColName != "Edit" && ColName != "Delete")
                {
                    dataGridView1.Cursor = Cursors.Default;
                }
                else
                {
                    dataGridView1.Cursor = Cursors.Hand;
                }
            }
        }
    }
}
