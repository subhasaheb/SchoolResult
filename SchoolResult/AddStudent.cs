using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolResult
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(BlankValidationCheck())
            {
                DataInsert(GeneratingUniqId());
            }
        }
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=SchholResult;Integrated Security=SSPI;");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public void DataInsert(string uid)
        {

            if (!UidPresent(uid))
            {
                //string constring = @"Data Source=localhost;Initial Catalog=SchholResult;Integrated Security=SSPI;";
                string generateSQL = @"INSERT INTO [dbo].[StudentInfo]
               ([StudentId],[StudentName],[StudentClass],[StudentSection],[StudentRoll],[Year])
                VALUES ('" + uid + "','" + txtName.Text + "'," + Convert.ToInt32(cmbClass.Text) + ",'" + cmbSec.Text + "'," + Convert.ToInt32(txtRoll.Text) + "," + Convert.ToInt32(cmbSess.Text) + ")";

                cmd = new SqlCommand(generateSQL, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Record updated successfully");
            
            }
            else
            {
                MessageBox.Show("Correct the value. Either Roll/class/Sec has duplicate values");
            }
        }
        public bool UidPresent( string uid)
        {
            string constring = @"Data Source=localhost;Initial Catalog=SchholResult;Integrated Security=SSPI;";
            using (SqlConnection con = new SqlConnection(constring))
            {

                try
                {
                    string generateSQL = string.Empty;
                    generateSQL = "select StudentId from [dbo].[StudentInfo] where StudentId = '" + uid + "'";

                    using (SqlCommand cmd = new SqlCommand(generateSQL, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());                       
                        con.Close();
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                return true;
                            }
                            else
                                return false;
                        }
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string GeneratingUniqId()
        {
            string uid = cmbSess.Text + cmbClass.Text + cmbSec.Text + txtRoll.Text;
            return uid;
        }
        public bool BlankValidationCheck()
        {
            if(txtName.Text == "" || cmbClass.Text == "" || cmbSec.Text == "" || cmbSess.Text == "" || txtRoll.Text == "" )
            {
                return false;
            }
            
            return true;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            this.Close();
            menu.Show();
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            
            cmbClass.Items.Add(5);
            cmbClass.Items.Add(6);
            cmbClass.Items.Add(7);
            cmbClass.Items.Add(8);
            cmbClass.Items.Add(9);
            cmbClass.Items.Add(10);

            cmbSec.Items.Add("A");
            cmbSec.Items.Add("B");
            cmbSec.Items.Add("C");

            cmbSess.Items.Add(DateTime.Today.Year);
            cmbSess.Items.Add(DateTime.Today.Year + 1);

            cmbClassUp.Items.Add(5);
            cmbClassUp.Items.Add(6);
            cmbClassUp.Items.Add(7);
            cmbClassUp.Items.Add(8);
            cmbClassUp.Items.Add(9);
            cmbClassUp.Items.Add(10);

            cmbSecUp.Items.Add("A");
            cmbSecUp.Items.Add("B");
            cmbSecUp.Items.Add("C");

            cmbSessUp.Items.Add(DateTime.Today.Year);
            cmbSessUp.Items.Add(DateTime.Today.Year + 1);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            BindResultGrid();
        }

        public bool BindResultGrid()
        {

            if (cmbClassUp.Text == "" || cmbSecUp.Text == "" || cmbSessUp.Text == "")
            {
                MessageBox.Show("All dropdowns are Mandatory!!");
                return false;
            }
            string constring = @"Data Source=localhost;Initial Catalog=SchholResult;Integrated Security=SSPI;";
            using (SqlConnection con = new SqlConnection(constring))
            {

                try
                {
                    string generateSQL = string.Empty;
                    //generateSQL = "Select StudentId, StudentSec, StudentRoll, StudentUnit, " + updateColumnName() + "Theo" + ", " + updateColumnName() + "Prac, " + updateColumnName() + " from  [StudentResultFromNine]";

                    generateSQL = "select StudentId,StudentName,StudentClass,StudentSection,StudentRoll from  [dbo].[StudentInfo] where StudentClass = " + Convert.ToInt32(cmbClassUp.Text) + " and StudentSection = '" + cmbSecUp.Text + "' and Year = " + Convert.ToInt32(cmbSessUp.Text);
                    

                    using (SqlCommand cmd = new SqlCommand(generateSQL, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        rstGrid.DataSource = dt;
                        con.Close();

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return true;

        }
    }
}
