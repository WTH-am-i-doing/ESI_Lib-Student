using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace ESI_Admin
{
    public partial class acntsettings : Form
    {
        Database dbobject = new Database();
        //DBAccess dbobjt = new DBAccess();
        //DataTable dtadmins = new DataTable();
        public string oldPass,newPass;
        public acntsettings()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void acntsettings_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.UseSystemPasswordChar = false;
            }
            else
            {
                textBox1.UseSystemPasswordChar = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //change button
        private void button1_Click(object sender, EventArgs e)
        {
            oldPass = textBox1.Text;
            newPass= textBox2.Text; 

            if (oldPass == "" && newPass == "")
            {
                MessageBox.Show("you have to enter the old password and the new one !");
            }
            else
            {
                string query = "SELECT * from Users where ID ='" + Form1.IDUser + "'";
                SQLiteCommand selectcommand = new SQLiteCommand(query, dbobject.myConnection);
                dbobject.OpenConnection();
                SQLiteDataReader resault = selectcommand.ExecuteReader();
                if (resault.HasRows)
                {
                    while (resault.Read())
                    {
                        if (oldPass == resault["PassWord"].ToString())
                        {
                            string query1 = "Update Users SET PassWord='" + @newPass + "'where ID ='" + Form1.IDUser + "'";
                            SQLiteCommand updateCommand = new SQLiteCommand(query1, dbobject.myConnection);
                            dbobject.OpenConnection();
                            updateCommand.Parameters.AddWithValue("@newPass", newPass);
                            var resaults = updateCommand.ExecuteNonQuery();
                            if (resaults == 1)
                            {
                                MessageBox.Show("your password has changed succefully!");
                                this.Hide();
                                Form1 f1 = new Form1();
                                
                                this.Hide();
                                f1.Show();
                            }
                            else
                            {
                                MessageBox.Show("error retry!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("sorry, the password that you entered is wrong please try again!", "wrong password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    }
                }
            }
           // else
           // {

                //string query = "Select * from Users Where Id ='" + Form1.IDUser + "' ";
                //dbobjt.readDatathroughAdapter(query, dtadmins);

                //if (oldPass == dtadmins.Rows[0]["password"].ToString())
                //{
                    
                //    //you can change it
                //    string query1 = "Update admins SET password='" + @newPass + "' where id='" + @Form1.IDUser + "'";
                //    SqlCommand updateCommand = new SqlCommand(query1);
                //    updateCommand.Parameters.AddWithValue("@newPass", newPass);


                //    int row = dbobjt.executeQuery(updateCommand);
                //    if (row == 1)
                //    {
                //        MessageBox.Show("your password has changed succefully!");
                //        this.Hide();
                //        Form1 f1 = new Form1();
                //        HomePage hp = new HomePage();
                //        hp.Hide();
                //        f1.Show();                     
                //    }
                //    else
                //    {
                //        MessageBox.Show("error retry!");
                //    }
                   

              //  }

                //else
                //{
                //    MessageBox.Show("sorry, the password that you entered is wrong please try again!", "wrong password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
          
        }
    
    }
}
