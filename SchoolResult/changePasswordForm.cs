using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SchoolResult
{
    public partial class changePasswordForm : Form
    {
        protected internal String savedUser;
        protected internal String savedPassword;
        
        public changePasswordForm()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (oldPasstextBox.Text == savedPassword)
            {
                if (newPasstextBox.Text != "" && newPasstextBox.Text == retypePasstextBox.Text)
                {
                    string path = @"Data\Login\";
                    path += savedUser;

                    try
                    {
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine(loginPage.Encrypt(newPasstextBox.Text));
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                    MessageBox.Show("Sorry! Please provide correct new password.");
            }
            else
            {
                MessageBox.Show("Sorry! Incorrect password.");
            }

            var backForm = (loginPage)Tag;
            backForm.Show();
            this.Hide();
        }

        private void changePasswordForm_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
