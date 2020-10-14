using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ESI_Admin
{
    public partial class booklist : Form
    {
        List<Request> reqs;

        private async void booklist_Load(object sender, EventArgs e)
        {
            reqs = await (new FirebaseHelper()).GetRequests();
            AddBookRequest();
            
        }


        public booklist()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int i = 0;
        private void AddBookRequest()
        {
            //string query = "SELECT * from Books ";
            //SQLiteCommand selectCommand = new SQLiteCommand(query, dbobject.myConnection);
            //dbobject.OpenConnection();
            //SQLiteDataReader resault = selectCommand.ExecuteReader();
            foreach(var req in reqs)
            {
                request br = new request();
                br._Reqnum = req.ReqKey;
                br._useremail = req.UserEmail;
                br._booktitle = req.BookTitle;
                br._bookIsbn = req.BookISBN;
                if (flowLayoutPanel1.Controls.Count < 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                }
                else
                {
                    flowLayoutPanel1.Controls.Add(br);
                }
                
            }
            //if (resault.HasRows)
            //{
            //    while (resault.Read())
            //    {
            //        BookRens br = new BookRens();
            //        br._Title2 = resault["Title"].ToString();
            //        br._numavailable = resault["NumAvailable"].ToString();
                    
            //        if (flowLayoutPanel1.Controls.Count < 0)
            //        {
            //            flowLayoutPanel1.Controls.Clear();
            //        }
            //        else
            //        {
            //            flowLayoutPanel1.Controls.Add(br);
            //        }

            //    }
            //    dbobject.CloseConnection();
            //}
            
        }

        private void bookRens1_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
