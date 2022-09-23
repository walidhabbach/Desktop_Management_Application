using Store_Management_System.Class;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Store_Management_System.User_Control
{
    public partial class Backup : Form
    {
        public Backup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg  = new FolderBrowserDialog();   
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dlg.SelectedPath;
                BackupButton.Enabled = true;
            }
        }

        private void BackupButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    string database = Conx.Database.ToString();

                    if (textBox1.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter backup file location");
                    }
                    else
                    {
                        string cmd = "BACKUP DATABASE [" + database + "] TO DISK= '" + textBox1.Text + "\\" + "database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";

                        Conx.Open();
                        SqlCommand command = new SqlCommand(cmd,Conx);

                        command.ExecuteNonQuery();
                        Conx.Close();

                        BackupButton.Enabled = false;
                        MessageBox.Show("Database backup done succesufly");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "SQL SERVER database backup files|*.bak";
            dlg.Title = "Database restore";
            if (dlg.ShowDialog()==DialogResult.OK )
            {
                textBox2.Text = dlg.FileName;

                button2.Enabled = true;

            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection Conx = new SqlConnection(MainClass.ConnectionDataBase()))
                {
                    string database = Conx.Database.ToString();
                    MessageBox.Show(database);
                    if (textBox2.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter backup file location");
                    }
                    else
                    {
                        Conx.Open();

                        string str = string.Format("USE master;");
                        SqlCommand cmd = new SqlCommand(str, Conx);
                        cmd.ExecuteNonQuery();

                        string str1 = string.Format("ALTER DATABASE [" + database + "] set SINGLE_USER WITH ROLLBACK IMMEDIATE");
                        SqlCommand cmd1 = new SqlCommand(str1, Conx);
                        cmd1.ExecuteNonQuery();

                        string str2 = string.Format("USE master RESTORE DATABASE [" + database + "] FROM DISK= '" + textBox2.Text + "' WITH REPLACE ;");
                        SqlCommand cmd2 = new SqlCommand(str2, Conx);
                        cmd2.ExecuteNonQuery();  
                        
                        string str3 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER ;");
                        SqlCommand cmd3 = new SqlCommand(str3, Conx);
                        cmd3.ExecuteNonQuery();


                        Conx.Close();
                        button2.Enabled = false;
                        MessageBox.Show("Database restore done");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "2002")
            {
                panel1.Visible = true;
            }
            else
            {
                MessageBox.Show("Invalid Password !!!");
            }
        }
    }
}
