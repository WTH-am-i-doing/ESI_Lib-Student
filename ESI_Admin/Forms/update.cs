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
    public partial class update : Form
    {
        public update()
        {
            InitializeComponent();
        }

        DBAccess objt = new DBAccess();
        DataTable dtbooks = new DataTable();
        public string id ,isbn, title, author, description, numAvailable;
        //FirebaseHelper firebasehelper = new FirebaseHelper();



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //once you enter 
            isbn = textBox1.Text; //could be null or not
            title = textBox2.Text; //must not be null or not
            author = textBox3.Text; //could be null
            description = textBox5.Text; //could be null
            numAvailable = textBox4.Text; //could be null

            if (title == "" && isbn == "")
            {
                MessageBox.Show("please enter a title or an isbn!");
            }
            else
            {
                string query = "Select * from books Where isbn ='" + isbn + "' OR title ='" + title + "' ";
                objt.readDatathroughAdapter(query, dtbooks);

                if (dtbooks.Rows.Count == 1)
                {
                    

                    label6.Text= "available";
                    objt.closeConn();
                    id = dtbooks.Rows[0]["id"].ToString();
                    textBox1.Text = dtbooks.Rows[0]["isbn"].ToString();
                    textBox2.Text = dtbooks.Rows[0]["title"].ToString();
                    textBox3.Text = dtbooks.Rows[0]["author"].ToString();
                    textBox5.Text = dtbooks.Rows[0]["description"].ToString();
                    textBox4.Text = dtbooks.Rows[0]["available"].ToString();


                }
                else
                {
                    label6.Text = "not available";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isbn = textBox1.Text; //could be null or not
            title = textBox2.Text; //must not be null or not
            author = textBox3.Text; //could be null
            description = textBox5.Text; //could be null
            numAvailable = textBox4.Text;
            if (isbn.Equals(""))
            {
                MessageBox.Show("please enter an isbn!");
            }
            else if (title.Equals(""))
            {
                MessageBox.Show("please enter a title!");
            }
            else if (author.Equals(""))
            {
                MessageBox.Show("please enter an author!");
            }
            else if (description.Equals(""))
            {
                MessageBox.Show("please enter a description!");
            }
            else if (numAvailable.Equals(""))
            {
                MessageBox.Show("please enter the number of books available!");
            }
            else
            {
                string query = "Update books SET isbn='" + @isbn + "' , title= '" + @title + "' , author= '" + @author + "', description= '" + @description + "' , available ='" + @numAvailable + "' where id='" + id + "'";
                SqlCommand updateCommand = new SqlCommand(query);
                updateCommand.Parameters.AddWithValue("@isbn", isbn);
                updateCommand.Parameters.AddWithValue("@title", title);
                updateCommand.Parameters.AddWithValue("@author", author);
                updateCommand.Parameters.AddWithValue("@description", description);
                updateCommand.Parameters.AddWithValue("@numAvailable", numAvailable);

                int row = objt.executeQuery(updateCommand);
                if (row == 1)
                {
                    MessageBox.Show("done updating!");
                }
                else
                {
                    MessageBox.Show("error retry!");
                }

                //try
                //{
                //    await firebasehelper.UpdateBook(isbnup.Text, new Book { Title = title1.Text, Author = author1.Text, Description = desc1.Text, Available = (int)numericUpDown2.Value, ISBN = isbnup.Text });
                //    MessageBox.Show("Book Updated", "The Book Has Beed Updated In The Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //catch
                //{
                //    MessageBox.Show("Book Couldn't Be Updated", "The Book Has Not Beed Updated to The Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }
    }



}

