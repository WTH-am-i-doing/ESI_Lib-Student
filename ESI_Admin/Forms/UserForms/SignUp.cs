using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace shitty_shit
{
    public partial class SignUp : Form
    {
        DBAccess dbobj = new DBAccess();
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
                MessageBox.Show("bla blablabla!");
            }
            else if (userpassword.Equals(""))
            {
                MessageBox.Show("bla blablabla!");
            }
            else
            {
                SqlCommand insertCommand = new SqlCommand("insert into admins(email,password) values(@useremail,@userpassword)");
                insertCommand.Parameters.AddWithValue("@useremail", useremail);
                insertCommand.Parameters.AddWithValue("@userpassword", userpassword);

                int row=dbobj.executeQuery(insertCommand);
                if (row == 1)
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
    }
}
