 
using Store_Management_System.Class;
using Store_Management_System.User_Control.Fournisseur.Add_Edit.Forms;
using Store_Management_System.User_Control.Save;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Policy;
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
                    string Statut;

                    Conx.Open();
                    SqlDataReader Read = Cmd.ExecuteReader();


                    // DataGridView.DefaultCellStyle.Font = new Font("Tahoma", 15);
                    this.dataGridView1.Rows.Clear();
                    if (Read.HasRows)
                    {

                        while (Read.Read())
                        {
                            if ((bool)Read["Statut"])
                            {
                                Statut = "Done";
                             }
                            else
                            {
                                Statut = "Not Done";
                             }
                            this.dataGridView1.Rows.Add(Read["IdTask"],Read["Details"], Read["Category"], Statut, Read["PriorityLevel"]);
                            if (Statut == "Done")
                            {
                               
                                dataGridView1.Rows[dataGridView1.RowCount-1].Cells["Statut"].Style.BackColor = Color.LightGreen;
                            }
                            else
                            {
                                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells["Statut"].Style.BackColor = Color.Red;
                            }

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

        private object convertToBool(object v)
        {
            throw new NotImplementedException();
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
                       
                    }else if (ColName == "Done")
                    {
                        try
                        {
                            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                            { 
                                SqlCommand Cmd = new SqlCommand($"UPDATE Task SET Statut = '{1}' where IdTask = @IdTask ", Conx);
                                Cmd.Parameters.AddWithValue("IdTask", Convert.ToInt32(Row.Cells[0].Value));
                                Conx.Open();
                                Cmd.ExecuteNonQuery();

                                MessageBox.Show("la tâche est réalisé");

                                PanelDGV.Controls.Clear();
                                DGVTask UC = new DGVTask(Query, PanelDGV);
                                MainClass.ShowControl(UC, PanelDGV);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }else if (ColName == "NotDone")
                    {
                        try
                        {
                            using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                            {
                                SqlCommand Cmd = new SqlCommand($"UPDATE Task SET Statut = '{0}' where IdTask = @IdTask ", Conx);
                                Cmd.Parameters.AddWithValue("IdTask", Convert.ToInt32(Row.Cells[0].Value));
                                Conx.Open();
                                Cmd.ExecuteNonQuery();

                                MessageBox.Show("task not done");

                                PanelDGV.Controls.Clear();
                                DGVTask UC = new DGVTask(Query, PanelDGV);
                                MainClass.ShowControl(UC, PanelDGV);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
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
            this.dataGridView1.Columns["Edit"].Width = 90;
            MainClass.Button_DGV(dataGridView1, "Delete", "delete");
            this.dataGridView1.Columns["Delete"].Width = 90;
    
        }
        private void DGVTask_Load(object sender, EventArgs e)
        {
            InitializeButtons();
            if (Calendar.Done == true)
            {
                MainClass.Button_DGV(dataGridView1, "Done", "done");
                this.dataGridView1.Columns["Done"].Width = 60;
            }
            else
            {
                MainClass.Button_DGV(dataGridView1, "NotDone", "notdone");
                this.dataGridView1.Columns["NotDone"].Width = 60;
            }
            LoadTasks(Query);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                PrintPdfXlsx.Pdf(dataGridView1);
            }
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            if (dataGridView1.Rows.Count > 0)
            {
                PrintPdfXlsx.Xlsx(dataGridView1);
            }
        }
    }
}
