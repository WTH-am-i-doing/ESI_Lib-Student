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
    public partial class HomePage : Form
    {
        public HomePage()
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
        private void HomePage_Load(object sender, EventArgs e)
        {

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
    }
}
