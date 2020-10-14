using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace ESI_Admin
{
    public partial class SignUp : Form
    {
        Database dbobject = new Database();
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
           
            label1.BackColor = Color.Transparent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string useremail = textBox1.Text;
            string userpassword = textBox2.Text;
            if (useremail.Equals(""))
            {
                MessageBox.Show("you may enter an E-mail Address please !");
            }
            else if (userpassword.Equals(""))
            {
                MessageBox.Show("you may enter a Password please!");
            }
            else
            {
                //SqlCommand insertCommand = new SqlCommand("insert into admins(email,password) values(@useremail,@userpassword)");
                //insertCommand.Parameters.AddWithValue("@useremail", useremail);
                //insertCommand.Parameters.AddWithValue("@userpassword", userpassword);

                //int row=dbobj.executeQuery(insertCommand);
                //if (row == 1)
                //{
                //    MessageBox.Show("done!");
                //}
                //else
                //{
                //    MessageBox.Show("error retry!");
                //}

                string query = "INSERT into Users (Email,PassWord) values (@useremail,@userpassword)";
                SQLiteCommand insertCommand = new SQLiteCommand(query, dbobject.myConnection);
                dbobject.OpenConnection();
                insertCommand.Parameters.AddWithValue("@useremail", useremail);
                insertCommand.Parameters.AddWithValue("@userpassword", userpassword);
                var resault =insertCommand.ExecuteNonQuery();
                dbobject.CloseConnection();
                if (resault == 1)
                {
                    MessageBox.Show("done!");
                }
                else
                {
                    MessageBox.Show("error retry!");
                }
                this.Hide();
            }
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
