using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shitty_shit
{
    public partial class PasswordReq : Form
    {
        public PasswordReq()
        {
            InitializeComponent();
        }

        private void PasswordReq_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("0000"))
            {
                this.Hide();
                SignUp singup = new SignUp();
                singup.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
