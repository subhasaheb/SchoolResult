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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ExtractResult window = new ExtractResult();
            window.Show();
            this.Hide();
        }

        private void btnResult5to8_Click(object sender, EventArgs e)
        {
            //result9to10 rslt = new result9to10();
            //rslt.Show();
            //Hide();
            AddStudent screen = new AddStudent();
            this.Close();
            
            screen.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BulkResult9to10 blRe = new BulkResult9to10();
            blRe.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BulkResult5to8 window = new BulkResult5to8();
            window.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExtractResult9to10 window = new ExtractResult9to10();
            window.Show();
            this.Hide();
        }

        private void btnResult9to10_Click(object sender, EventArgs e)
        {
            queryGenerater window = new queryGenerater();
            this.Close();
            window.Show();
        }

        private void menu_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
