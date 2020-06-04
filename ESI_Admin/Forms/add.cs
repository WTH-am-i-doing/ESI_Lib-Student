﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ESI_Admin
{
    public partial class add : Form
    {
        DBAccess dbobj = new DBAccess();
        private FirebaseHelper helper = new FirebaseHelper();

        public add()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var bk = new Book() {
                Author = author.Text,
                Available = (int)available.Value,
                Coverurl = CoverURL.Text,
                Description = description.Text,
                ISBN = isbn.Text,
                Title = title.Text
            };
            await helper.AddBook(bk);


            /*//description??
            string isbn = textBox1.Text; //could be null
            string title = textBox2.Text; //must not be null
            string author = textBox3.Text; //must not be null
            string description = textBox5.Text; //could be null
            string numAvailable =textBox4.Text; //could be null

            //condition so the user fill the important parts
            if (title.Equals(""))
            {
                MessageBox.Show("please enter title");
            }
            else if (author.Equals(""))
            {
                MessageBox.Show("please enter author");
            }
            else
            {
                SqlCommand insertCommand = new SqlCommand("insert into books(isbn,title,author,description,available) values(@isbn, @title, @author, @description, @numAvailable)");
                insertCommand.Parameters.AddWithValue("@isbn", isbn);
                insertCommand.Parameters.AddWithValue("@title", title);
                insertCommand.Parameters.AddWithValue("@author", author);
                insertCommand.Parameters.AddWithValue("@description", description);
                insertCommand.Parameters.AddWithValue("@numAvailable", numAvailable);

                int row = dbobj.executeQuery(insertCommand);
                if (row == 1)
                {
                    MessageBox.Show("done!");
                }
                else
                {
                    MessageBox.Show("error retry!");
                }
                
                //MessageBox.Show("Book Added", "The Book Has Beed Added to The Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
*/
        
        }

        private void add_Load(object sender, EventArgs e)
        {

        }


        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var book = await Isbn.GetBook(isbn.Text);
                if (book != null)
                {
                    title.Text = book.Title;
                    author.Text = book.Author;
                    description.Text = book.Description;
                    CoverURL.Text = book.Coverurl;
                }
            }
            catch
            {
                MessageBox.Show("Couldn't Fin The Book Using The API", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
