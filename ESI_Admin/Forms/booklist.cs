using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESI_Admin
{
    public partial class booklist : Form
    {

        DBAccess objt = new DBAccess();
        DataTable dtbooks = new DataTable();
        public string id, isbn, title, author, description, numAvailable;
        

        private void booklist_Load(object sender, EventArgs e)
        {
            string query = "Select * from books ";
            objt.readDatathroughAdapter(query, dtbooks);
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
            

            int i = 0;
            foreach (DataRow bok in dtbooks.Rows)
            {
                BookRens br = new BookRens();

                br._Title2 = dtbooks.Rows[i]["title"].ToString();
                br._numavailable = dtbooks.Rows[i]["available"].ToString();
                i++;
                if (flowLayoutPanel1.Controls.Count < 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                }
                else
                {
                    flowLayoutPanel1.Controls.Add(br);
                }
                
            }

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
