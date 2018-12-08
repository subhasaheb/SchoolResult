using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolResult
{
    public partial class Security : Form
    {
        public Security()
        {
            InitializeComponent();
        }

        private void Security_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Admin" && textBox2.Text.ToString() == "123")
            {
                menu page2 = new menu();
                page2.Show();
                Hide();
            }
            else
            {
                lblErrorText.Text = "Invalid username or password";
                lblErrorText.ForeColor = Color.Red;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
