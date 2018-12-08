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
using System.Security.Cryptography;
using SchoolResult;

namespace SchoolResult
{
    public partial class loginPage : Form
    {
        protected internal String userName;

        protected internal menu mainMenu = new menu();

        public enum Action
        {
            CREATE = 0,
            DELETE,
            LOGIN,
            CHANGEPASSWORD
        }

        public loginPage()
        {
            InitializeComponent();
            InitialiseLoginPage();
        }

        private void InitialiseLoginPage()
        {
            System.IO.Directory.CreateDirectory("Data");
            System.IO.Directory.CreateDirectory("Data\\Login");
            System.IO.Directory.CreateDirectory("Data\\History");

            using (StreamWriter sw = new StreamWriter(@"Data\Login\superUser"))
                sw.WriteLine(Encrypt("Jely1Mota2Tua3!"));

            using (StreamWriter sw = new StreamWriter(@"Data\History\lastLoginInfo.log"))
            {
                sw.WriteLine("=======================================");
                String dd = DateTime.Now.Day.ToString(); //formMainMenu.CurrentDateMonthYear().Day.ToString();
                String mm = DateTime.Now.Month.ToString();
                String yyyy = DateTime.Now.Year.ToString();
                String hh = DateTime.Now.Hour.ToString();
                String min = DateTime.Now.Minute.ToString();
                String sec = DateTime.Now.Second.ToString();
                sw.WriteLine("Application Started: (dd/mm/yyyy - hh:mm:ss)" + dd + "/" + mm + "/" + yyyy + 
                    " - " + hh + ":" + min + ":" + sec);
                sw.WriteLine("=======================================");
            }

            
            delAccButton.Hide();
            rstAllAccButton.Hide();
        }

        public void UserNamePasswordValidation(Action ac)
        {
            string path = @"Data\Login\";
            path += usrnmTextBox.Text;

            if (ac == Action.CREATE)
            {
                if (usrnmTextBox.Text == "User Name" || usrnmTextBox.Text == "")
                {
                    MessageBox.Show("Error! Enter valid username!");
                    usrnmTextBox.Focus();
                }
                else if (passwordTextBox.Text == "Password" || passwordTextBox.Text == "")
                {
                    MessageBox.Show("Error! Enter valid password!");
                    passwordTextBox.Focus();
                }
                else // UserName and Password are non-empty. We can create account.
                {
                    try
                    {
                        if (File.Exists(path))
                        {
                            MessageBox.Show("Sorry! User already exists.");
                            return;
                        }
                        // Create a file to write to.
                        using (StreamWriter sw = File.CreateText(path))
                        {
                            sw.WriteLine(Encrypt(passwordTextBox.Text));
                        }
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            else if (ac == Action.LOGIN)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string password;
                        password = sr.ReadLine();
                        if (Decrypt(password) == passwordTextBox.Text)
                        {
                            mainMenu.Tag = this;
                            mainMenu.Show(this);
                            Hide();
                        }
                        else
                        {
                            MessageBox.Show("Sorry! Incorrect password! Try again.");
                        }
                    }
                }
                catch (Exception e)
                {
                    // Let the user know what went wrong.
                    MessageBox.Show("Sorry! User doesn't exists!");
                }
            }

            else if (ac == Action.CHANGEPASSWORD)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        string password;
                        password = sr.ReadLine();
                        sr.Close();

                        changePasswordForm chPassForm = new changePasswordForm();
                        chPassForm.savedPassword = Decrypt(password);
                        chPassForm.savedUser = usrnmTextBox.Text;
                        chPassForm.Tag = this;
                        chPassForm.ShowDialog(this);
                  }
                }
                catch (Exception e)
                {
                    // Let the user know what went wrong.
                    MessageBox.Show("Sorry! User doesn't exists!");
                }
            }
        }

        private void crtAccButton_Click(object sender, EventArgs e)
        {
            UserNamePasswordValidation(Action.CREATE);
        }

        #region ENCRYPTION and DECRYPTION

        static readonly string PasswordHash = "P@5Sw0rd";
        static readonly string SaltKey = "S@LT*KeY";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";

        public static string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }

        #endregion

        private void exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chngPassbutton_Click(object sender, EventArgs e)
        {
            UserNamePasswordValidation(Action.CHANGEPASSWORD);
        }

        private void usrnmTextBox_Enter(object sender, EventArgs e)
        {
            usrnmTextBox.Clear();
        }

        private void passwordTextBox_Enter(object sender, EventArgs e)
        {
            passwordTextBox.Clear();
            passwordTextBox.PasswordChar = '*';
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            UserNamePasswordValidation(Action.LOGIN);
        }

        private void loginPage_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
