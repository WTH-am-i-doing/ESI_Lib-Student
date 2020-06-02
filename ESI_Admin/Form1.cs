using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shitty_shit
{
    public partial class Form1 : Form
    {
        DBAccess obj = new DBAccess();
        DataTable dtUsers = new DataTable();
        public static string id1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;

            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;

            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            string UserEmail = textBox1.Text;
            string UserPassword = textBox2.Text;
            if (UserEmail == "")
            {
                MessageBox.Show("please enter your adress!");
            }
            else if (UserPassword == "")
            {
                MessageBox.Show("please enter your password");
            }
            else
            {
                
                string query = "Select * from admins Where email='" + UserEmail + "'AND password ='" + UserPassword + "' ";
                obj.readDatathroughAdapter(query, dtUsers);

                if (dtUsers.Rows.Count == 1)
                {
                    id1 = dtUsers.Rows[0]["id"].ToString();
                    obj.closeConn();
                    this.Hide();
                    HomePage home = new HomePage();
                    home.Show();
                }
                else
                {
                    MessageBox.Show("wrong email or password!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            PasswordReq passreq = new PasswordReq();
            passreq.Show();
        }
    }
}
