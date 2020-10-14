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
using System.Data.SQLite;

namespace ESI_Admin
{
    public partial class remove : Form
    {
        //DBAccess objct = new DBAccess();
        public string  isbn, title, author, description, numAvailable;
        public int IDBook;
        //DataTable dtbooks = new DataTable();
        Database dbobject = new Database();


        private void remove_Load(object sender, EventArgs e)
        {

        }

        public remove()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
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
                string query = "Select * from Books Where ISBN ='" + isbn + "' OR Title ='" + title + "' ";
                SQLiteCommand selectCommand = new SQLiteCommand(query, dbobject.myConnection);
                dbobject.OpenConnection();
                SQLiteDataReader resault = selectCommand.ExecuteReader();
                if (resault.HasRows)
                {   
                    label6.Text = "available";
                    while (resault.Read())
                    {
                        IDBook = Convert.ToInt32(resault["ID"]);
                        break;
                    }
                }
                else
                {
                    label6.Text = "not available";
                }
                dbobject.CloseConnection();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label6.Text == "available")
            {
                DialogResult dialog = MessageBox.Show("are you sure you want to delete this book?", "Delete Book", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialog == DialogResult.Yes)
                {
                    string query = "DELETE from Books where ID = '" + IDBook + "'";
                    SQLiteCommand deleteCommand = new SQLiteCommand(query,dbobject.myConnection);
                    dbobject.OpenConnection();
                    var resault = deleteCommand.ExecuteNonQuery();
                    dbobject.CloseConnection();

                    if (resault==1)
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
