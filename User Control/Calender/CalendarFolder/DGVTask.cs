using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.Add_Edit.Forms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Store_Management_System.User_Control.Fournisseur.Add_Edit.User_C.CalendarFolder
{
    public partial class DGVTask : UserControl
    {
        private readonly string  Query;
        private Panel PanelDGV;
        public DGVTask(string query , Panel panel)
        {
            InitializeComponent();
            Query = query;
            PanelDGV = panel;
        }
        private void LoadTasks(string Query)
        {
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    Conx.ConnectionString = MainClass.ConnectionDataBase();
                    SqlCommand Cmd = new SqlCommand(Query, Conx);

                    Conx.Open();
                    SqlDataReader Read = Cmd.ExecuteReader();


                    // DataGridView.DefaultCellStyle.Font = new Font("Tahoma", 15);
                    this.dataGridView1.Rows.Clear();
                    if (Read.HasRows)
                    {
                        while (Read.Read())
                        {
                            this.dataGridView1.Rows.Add(Read["IdTask"],Read["Details"], Read["Category"], Read["Statut"], Read["PriorityLevel"]);
                        }
                    }
                    else
                    {
                        //MessageBox.Show("No Tasks existed !!!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Edit(int ID)
        {
            Edit_Task Form = new Edit_Task(ID, PanelDGV);
            Form.Show();
          
        }
        private void Delete(int IdTask)
        {
            //int position = this.DataGridView.CurrentRow.Index;
            //int IDFour = int.Parse(this.DataGridView.Rows[position].Cells[0].Value);
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {

                    SqlCommand Cmd = new SqlCommand($"DELETE FROM Task WHERE IdTask = '{IdTask}';", Conx);

                    Conx.Open();
                    Cmd.ExecuteNonQuery();
                    Conx.Close();
                }
                LoadTasks(Query);

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow Row;
                    DialogResult Dialog;
                    String ColName = this.dataGridView1.Columns[e.ColumnIndex].Name;

                    Row = dataGridView1.Rows[e.RowIndex];
                    Row.Selected = true;

                    if (ColName == "Edit")
                    {
                        Edit(Convert.ToInt32(Row.Cells[0].Value));
                    }
                    else if (ColName == "Delete")
                    {

                        Dialog = MessageBox.Show("Do You Want To Delete " + this.dataGridView1.Rows[this.dataGridView1.CurrentRow.Index].Cells[1].Value.ToString(), "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Dialog == DialogResult.No)
                        {
                            return;
                        }
                        else
                        {
                            Delete(Convert.ToInt32(Row.Cells["IdTask"].Value));
                        }
                       
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void InitializeButtons()
        {
            //Button Delete, Edit
            MainClass.Button_DGV(dataGridView1, "Edit", "edit");
            this.dataGridView1.Columns["Edit"].Width = 70;
            MainClass.Button_DGV(dataGridView1, "Delete", "delete");
            this.dataGridView1.Columns["Delete"].Width = 70;
            
        }
        private void DGVTask_Load(object sender, EventArgs e)
        {
            InitializeButtons();
            LoadTasks(Query);
        }
    }
}
