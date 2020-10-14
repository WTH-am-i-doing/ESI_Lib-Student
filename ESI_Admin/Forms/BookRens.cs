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
    public partial class BookRens : UserControl
    {
        public BookRens()
        {
            InitializeComponent();
        }
        #region properties

        private string Title;
        private string Isbn;
        private int num_avail;
        private Image Icon;

        [Category("custum props")]
        public string _Title2
        {
            get { return Title; }
            set { Title = value; label2.Text = value;  }
        }

        [Category("custum props")]
        public int _numavailable
        {
            get { return num_avail; }
            set { num_avail = value; label3.Text = value.ToString(); }
        }

        [Category("custum props")]
        public Image _icon
        {
            get { return Icon ; }
            set { Icon = value; pictureBox1.Image = value; }
        }
        public string _Isbn
        {
            get { return Isbn; }
            set { Isbn = value; label6.Text = value; }
        }

        #endregion


        public void BookRens_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
