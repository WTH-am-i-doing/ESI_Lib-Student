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

        //DBAccess objt = new DBAccess();
        //DataTable dtbooks = new DataTable();
        //public string id, isbn, title, author, description, numAvailable;
        Database dbobject = new Database();


        private void booklist_Load(object sender, EventArgs e)
        {
            //string query = "Select * from books ";
            //objt.readDatathroughAdapter(query, dtbooks);
            
            
            AddBookRes();
        }

        public booklist()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddBookRes()
        {
            

            
            string query = "SELECT * from Books ";
            SQLiteCommand selectCommand = new SQLiteCommand(query, dbobject.myConnection);
            dbobject.OpenConnection();
            SQLiteDataReader resault = selectCommand.ExecuteReader();
            if (resault.HasRows)
            {
                while (resault.Read())
                {
                    BookRens br = new BookRens();
                    br._Title2 = resault["Title"].ToString();
                    br._numavailable = resault["NumAvailable"].ToString();
                    
                    if (flowLayoutPanel1.Controls.Count < 0)
                    {
                        flowLayoutPanel1.Controls.Clear();
                    }
                    else
                    {
                        flowLayoutPanel1.Controls.Add(br);
                    }

                }
                dbobject.CloseConnection();
            }
            //foreach (DataRow bok in dtbooks.Rows)
            //{
            //    BookRens br = new BookRens();

            //    br._Title2 = dtbooks.Rows[i]["title"].ToString();
            //    br._numavailable = dtbooks.Rows[i]["available"].ToString();
            //    i++;
            //    if (flowLayoutPanel1.Controls.Count < 0)
            //    {
            //        flowLayoutPanel1.Controls.Clear();
            //    }
            //    else
            //    {
            //        flowLayoutPanel1.Controls.Add(br);
            //    }
                
            //}

        }

        private void bookRens1_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            //string query = "Select * from books ";
            //objt.readDatathroughAdapter(query, dtbooks);
            //BookRens br = new BookRens();

            //if (dtbooks.Rows.Count == 1)
            //{
                

           
                


            //}
        }
    }
}
