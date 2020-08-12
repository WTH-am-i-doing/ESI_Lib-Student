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
    public partial class update : Form
    {
        private FirebaseHelper helper = new FirebaseHelper();
        Database dbobject = new Database();
        public int IDBook;
        public update()
        {
            InitializeComponent();
        }

        //DBAccess objt = new DBAccess();
        //DataTable dtbooks = new DataTable();
        public string id ,isbn, title, author, description, numAvailable,bookurl;
        //FirebaseHelper firebasehelper = new FirebaseHelper();



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        //fetch button
        private async void button1_Click(object sender, EventArgs e)
        {
            if (title == "" && isbn == "" )
            {
                MessageBox.Show("please enter a title or an isbn!");
            }
            else
            {
                var bok = await helper.GetBook(bkISBN.Text);
                if (bok != null)
                {

                    label6.Text = "Available";
                    bkTitle.Text = bok.Title;
                    bkAuthor.Text = bok.Author;
                    numericUpDown1.Value = bok.Available;
                    bkDesc.Text = bok.Description;
                    bookurl = bok.Coverurl;
                }
                else
                {
                    string query = "Select * from Books Where ISBN ='" + isbn + "' OR Title ='" + title + "' ";
                    SQLiteCommand selectCommand = new SQLiteCommand(query, dbobject.myConnection);
                    dbobject.OpenConnection();
                    SQLiteDataReader resault = selectCommand.ExecuteReader();
                    //objt.readDatathroughAdapter(query, dtbooks);

                    if (resault.HasRows)
                    {
                        while (resault.Read())
                        {
                            IDBook = Convert.ToInt32(resault["ID"]);
                            bkISBN.Text = resault["ISBN"].ToString();
                            bkTitle.Text = resault["Title"].ToString();
                            bkAuthor.Text = resault["Author"].ToString();
                            bkDesc.Text = resault["Description"].ToString();
                            numericUpDown1.Value = Convert.ToInt32(resault["NumAvailable"]);
                            break;
                        }
                    }

                    //    objt.closeConn();
                    //    id = dtbooks.Rows[0]["id"].ToString();
                    //    textBox1.Text = dtbooks.Rows[0]["isbn"].ToString();
                    //    textBox2.Text = dtbooks.Rows[0]["title"].ToString();
                    //    textBox3.Text = dtbooks.Rows[0]["author"].ToString();
                    //    textBox5.Text = dtbooks.Rows[0]["description"].ToString();
                    //    textBox4.Text = dtbooks.Rows[0]["available"].ToString();


                    //}
                    else
                    {
                        label6.Text = "not available";
                    }
                    dbobject.CloseConnection();
                }
            }
        }

        //update button
        private async void button3_Click(object sender, EventArgs e)
        {
            isbn = bkISBN.Text; //could be null or not
            title = bkTitle.Text; //must not be null or not
            author = bkAuthor.Text; //could be null
            description = bkDesc.Text; //could be null
            var number = numericUpDown1.Value;
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
            else if (number <= 0)
            {
                MessageBox.Show("please enter the number of books available!");
            }
            else
            {
                //var boktoUpdate = new Book() {
                //    Description = bkDesc.Text,
                //    Author = bkAuthor.Text,
                //    Available = (int)numericUpDown1.Value,
                //    Coverurl = bookurl,
                //    ISBN = bkISBN.Text,
                //    Title = bkTitle.Text,
                //};
                //await helper.UpdateBook(bkISBN.Text, boktoUpdate);

                string query = "Update Books SET ISBN='" + @isbn + "' , Title= '" + @title + "' , Author= '" + @author + "', Description= '" + @description + "' , NumAvailable ='" + @numAvailable + "' where ID='" + IDBook + "'";
                SQLiteCommand updateCommand = new SQLiteCommand(query,dbobject.myConnection);
                dbobject.OpenConnection();
                updateCommand.Parameters.AddWithValue("@isbn", isbn);
                updateCommand.Parameters.AddWithValue("@title", title);
                updateCommand.Parameters.AddWithValue("@author", author);
                updateCommand.Parameters.AddWithValue("@description", description);
                updateCommand.Parameters.AddWithValue("@numAvailable", numAvailable);
                var resault = updateCommand.ExecuteNonQuery();
                //int row = objt.executeQuery(updateCommand);
                if (resault==1)
                {
                    MessageBox.Show("done updating!");
                }
                else
                {
                    MessageBox.Show("error retry!");
                }
                

            }
        }
    }



}

