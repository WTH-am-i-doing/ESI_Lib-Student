using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace ESI_Admin
{
    public partial class remove : Form
    {
        DBAccess objct = new DBAccess();
        public string id, isbn, title, author, description, numAvailable;
        DataTable dtbooks = new DataTable();
        

        private void remove_Load(object sender, EventArgs e)
        {

        }

        public remove()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            //once you enter 
            isbn = textBox1.Text; //could be null or not
            title = textBox2.Text; //must not be null or not
           
            if (title == "" && isbn == "")
            {
                MessageBox.Show("please enter a title or an isbn!");
            }
            else
            {
                string query = "Select * from books Where isbn ='" + isbn + "' OR title ='" + title + "' ";
                objct.readDatathroughAdapter(query, dtbooks);

                if (dtbooks.Rows.Count == 1)
                {

                    label6.Text = "available";
                    objct.closeConn();
                    id = dtbooks.Rows[0]["id"].ToString();
               
                }
                else
                {
                    label6.Text = "not available";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label6.Text == "available")
            {
                DialogResult dialog = MessageBox.Show("are you sure you want to delete this book?", "Delete Book", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    string query = "DELETE from books where id = '" + id + "'";
                    SqlCommand deleteCommand = new SqlCommand(query);

                    

                    int row = objct.executeQuery(deleteCommand);
                    if (row == 1)
                    {
                        MessageBox.Show("done deletting!");
                    }
                    else
                    {
                        MessageBox.Show("error retry!");
                    }
                }
            }
            else
            {
                MessageBox.Show("this book is not available , you can't affect this operation!");
            }
        }
    }
}
