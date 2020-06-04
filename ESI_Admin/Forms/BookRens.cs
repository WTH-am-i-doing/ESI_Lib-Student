using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shitty_shit
{
    public partial class BookRens : UserControl
    {
        public BookRens()
        {
            InitializeComponent();
        }
        #region properties

        private string Title;
        private string num_avail;
        private Image Icon;

        [Category("custum props")]
        public string _Title2
        {
            get { return Title; }
            set { Title = value; label2.Text = value;  }
        }

        [Category("custum props")]
        public string _numavailable
        {
            get { return num_avail; }
            set { num_avail = value; label6.Text = value; }
        }

        [Category("custum props")]
        public Image _icon
        {
            get { return Icon ; }
            set { Icon = value; pictureBox1.Image = value; }
        }

        #endregion


        public void BookRens_Load(object sender, EventArgs e)
        {

        }
    }
}
