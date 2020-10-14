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
    public partial class HomePage : Form
    {
        Database dbobject = new Database();
        List<Book> book;
        public  HomePage()
        {
            InitializeComponent();
            //customisedesign();
           
        }

        private Form activeForm = null;
        private void OpenChildForms(Form childform)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            ChildFormContainer.Controls.Add(childform);
            ChildFormContainer.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sidemenupanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void customisedesign()
        {
            panel1.Visible = false;
        }

        private void HidesubMenu()
        {
            if (panel1.Visible == true)
                panel1.Visible = false;
        }

        private void ShowSubMenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                //HidesubMenu();
                submenu.Visible = true;
            }
            //else
            //{
            //    submenu.Visible = false;
            //}
        }
        private async void HomePage_Load(object sender, EventArgs e)
        {
            book = await(new FirebaseHelper()).GetAllBooks();
            AddBookRes();

        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            //ShowSubMenu(panel1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // HidesubMenu();
           OpenChildForms(new add());
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // HidesubMenu();
           OpenChildForms(new remove());
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // HidesubMenu();
           OpenChildForms(new update());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           OpenChildForms(new booklist());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenChildForms(new acntsettings());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            
        }
        private void AddBookRes()
        {
            foreach (var bok in book)
            {
                BookRens br = new BookRens();
                br._Title2 = bok.Title;
                br._numavailable = bok.Available;
                br._Isbn = bok.ISBN;
                if (flowLayoutPanel1.Controls.Count < 0)
                {
                    flowLayoutPanel1.Controls.Clear();
                }
                else
                {
                    flowLayoutPanel1.Controls.Add(br);
                }

            }


            //string query = "SELECT * from Books ";
            //SQLiteCommand selectCommand = new SQLiteCommand(query, dbobject.myConnection);
            //dbobject.OpenConnection();
            //SQLiteDataReader resault = selectCommand.ExecuteReader();
            //if (resault.HasRows)
            //{
            //    while (resault.Read())
            //    {
            //        BookRens br = new BookRens();
            //        br._Title2 = resault["Title"].ToString();
            //        br._numavailable = resault["NumAvailable"].ToString();

            //        if (panel2.Controls.Count < 0)
            //        {
            //            panel2.Controls.Clear();
            //        }
            //        else
            //        {
            //            panel2.Controls.Add(br);
            //        }

            //    }
            //    dbobject.CloseConnection();
            //}

        }

        private void button8_Click(object sender, EventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button7_Click_2(object sender, EventArgs e)
        {

        }

        private void button7_Click_3(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
