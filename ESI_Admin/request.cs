using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESI_Admin
{
    public partial class request : UserControl
    {
        #region properties
        private string Reqnum;
        private string useremail;
        private string booktitle;
        private string bookIsbn;
        
        public request()
        {
            InitializeComponent();
        }

        [Category("custum props")]
        public string _Reqnum
        {
            get { return Reqnum; }
            set { Reqnum = value; label2.Text = value; }
        }
        [Category("custum props")]
        public string _useremail
        {
            get { return this.useremail; }
            set { this.useremail = value; label3.Text = value; }
        }
        [Category("custum props")]
        public string _booktitle
        {
            get { return this.booktitle; }
            set { this.booktitle= value; label4.Text = value; }
        }
        [Category("custum props")]
        public string _bookIsbn
        {
            get { return this.bookIsbn; }
            set { this.bookIsbn = value; label7.Text = value; }
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void request_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // ((Form)this.TopLevelControl)).close();
            await (new FirebaseHelper()).UpdateRequest(Reqnum,true);
            Hide();
         

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            
        }

        
    }
}
