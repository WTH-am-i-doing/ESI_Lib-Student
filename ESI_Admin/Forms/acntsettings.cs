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
    public partial class acntsettings : Form
    {

        DBAccess dbobjt = new DBAccess();
        DataTable dtadmins = new DataTable();
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
                string query = "Select * from admins Where id ='" + Form1.id1 + "' ";
                dbobjt.readDatathroughAdapter(query, dtadmins);

                if (oldPass == dtadmins.Rows[0]["password"].ToString())
                {
                    
                    //you can change it
                    string query1 = "Update admins SET password='" + @newPass + "' where id='" + @Form1.id1 + "'";
                    SqlCommand updateCommand = new SqlCommand(query1);
                    updateCommand.Parameters.AddWithValue("@newPass", newPass);


                    int row = dbobjt.executeQuery(updateCommand);
                    if (row == 1)
                    {
                        MessageBox.Show("your password has changed succefully!");
                        this.Hide();
                        Form1 f1 = new Form1();
                        HomePage hp = new HomePage();
                        hp.Hide();
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
            }
        }
    
    }
}
