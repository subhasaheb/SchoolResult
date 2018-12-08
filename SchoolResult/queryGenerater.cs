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
    public partial class queryGenerater : Form
    {
        public queryGenerater()
        {
            InitializeComponent();
        }

        private void queryGenerater_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            rd5to8Formative.Checked = true;
        }

        public string GenerateQuery(DataTable dt)
        {
            string query = string.Empty;
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    query += "INSERT INTO [StudentFormativeResult5to8] (StudentId, StudentSec, StudentClass, StudentRoll, StudentUnit, Year) VALUES  (";
                    query += row["StudentId"].ToString() + ", '" + row["StudentSection"].ToString() + "'," + row["StudentClass"].ToString() + ",";
                    query += row["StudentRoll"].ToString() + ", 1, " + row["Year"].ToString() + ")";
                    query += Environment.NewLine;

                    query += "INSERT INTO [StudentFormativeResult5to8] (StudentId, StudentSec, StudentClass, StudentRoll, StudentUnit, Year) VALUES  (";
                    query += row["StudentId"].ToString() + ", '" + row["StudentSection"].ToString() + "'," + row["StudentClass"].ToString() + ",";
                    query += row["StudentRoll"].ToString() + ", 2, " + row["Year"].ToString() + ")";
                    query += Environment.NewLine;

                    query += "INSERT INTO [StudentFormativeResult5to8] (StudentId, StudentSec, StudentClass, StudentRoll, StudentUnit, Year) VALUES  (";
                    query += row["StudentId"].ToString() + ", '" + row["StudentSection"].ToString() + "'," + row["StudentClass"].ToString() + ",";
                    query += row["StudentRoll"].ToString() + ", 3, " + row["Year"].ToString() + ")";
                    query += Environment.NewLine;
                    query += Environment.NewLine;
                    query += Environment.NewLine;
                }
                
            }

            return query;
        }

        public string GenerateQuery5to8Summative(DataTable dt)
        {
            string query = string.Empty;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    query += "INSERT INTO [StudentResult5to8] (StudentId, StudentSec, StudentClass, StudentRoll, StudentUnit, Year) VALUES  (";
                    query += row["StudentId"].ToString() + ", '" + row["StudentSection"].ToString() + "'," + row["StudentClass"].ToString() + ",";
                    query += row["StudentRoll"].ToString() + ", 1, " + row["Year"].ToString() + ")";
                    query += Environment.NewLine;

                    query += "INSERT INTO [StudentResult5to8] (StudentId, StudentSec, StudentClass, StudentRoll, StudentUnit, Year) VALUES  (";
                    query += row["StudentId"].ToString() + ", '" + row["StudentSection"].ToString() + "'," + row["StudentClass"].ToString() + ",";
                    query += row["StudentRoll"].ToString() + ", 2, " + row["Year"].ToString() + ")";
                    query += Environment.NewLine;

                    query += "INSERT INTO [StudentResult5to8] (StudentId, StudentSec, StudentClass, StudentRoll, StudentUnit, Year) VALUES  (";
                    query += row["StudentId"].ToString() + ", '" + row["StudentSection"].ToString() + "'," + row["StudentClass"].ToString() + ",";
                    query += row["StudentRoll"].ToString() + ", 3, " + row["Year"].ToString() + ")";
                    query += Environment.NewLine;
                    query += Environment.NewLine;
                    query += Environment.NewLine;
                }

            }

            return query;
        }

        public string GenerateQuery9to10(DataTable dt)
        {
            string query = string.Empty;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    query += "INSERT INTO [StudentResultFromNine] (StudentId, StudentSec, StudentClass, StudentRoll, StudentUnit, Year) VALUES  (";
                    query += row["StudentId"].ToString() + ", '" + row["StudentSection"].ToString() + "'," + row["StudentClass"].ToString() + ",";
                    query += row["StudentRoll"].ToString() + ", 1, " + row["Year"].ToString() + ")";
                    query += Environment.NewLine;

                    query += "INSERT INTO [StudentResultFromNine] (StudentId, StudentSec, StudentClass, StudentRoll, StudentUnit, Year) VALUES  (";
                    query += row["StudentId"].ToString() + ", '" + row["StudentSection"].ToString() + "'," + row["StudentClass"].ToString() + ",";
                    query += row["StudentRoll"].ToString() + ", 2, " + row["Year"].ToString() + ")";
                    query += Environment.NewLine;

                    query += "INSERT INTO [StudentResultFromNine] (StudentId, StudentSec, StudentClass, StudentRoll, StudentUnit, Year) VALUES  (";
                    query += row["StudentId"].ToString() + ", '" + row["StudentSection"].ToString() + "'," + row["StudentClass"].ToString() + ",";
                    query += row["StudentRoll"].ToString() + ", 3, " + row["Year"].ToString() + ")";
                    query += Environment.NewLine;
                    query += Environment.NewLine;
                    query += Environment.NewLine;
                }

            }

            return query;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string constring = @"Data Source=localhost;Initial Catalog=SchholResult;Integrated Security=SSPI;";
            using (SqlConnection con = new SqlConnection(constring))
            {

                try
                {
                    string generateSQL = string.Empty;
                    if(rd5to8Formative.Checked == true)
                    {
                        generateSQL = @"select StudentId, StudentSection,StudentClass, StudentRoll, Year from [StudentInfo] WHERE Year = 2016 and StudentClass in (5,6,7,8)";
                    }
                    else if(rd5to8Summative.Checked == true)
                    {
                        generateSQL = @"select StudentId, StudentSection,StudentClass, StudentRoll, Year from [StudentInfo] WHERE Year = 2016 and StudentClass in (5,6,7,8)";
                    }
                    else if (rdResult9to10.Checked == true)
                    {
                        generateSQL = @"select StudentId, StudentSection,StudentClass, StudentRoll, Year from [StudentInfo] WHERE Year = 2016 and StudentClass in (9,10)";
                    }

                    string generateSQLScript = string.Empty;
                    using (SqlCommand cmd = new SqlCommand(generateSQL, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        if (rd5to8Formative.Checked == true)
                        {
                            generateSQLScript = GenerateQuery(dt);
                        } 
                        else if(rd5to8Summative.Checked == true)
                        {
                            generateSQLScript = GenerateQuery5to8Summative(dt);
                        }
                        else if (rdResult9to10.Checked == true)
                        {
                            generateSQLScript = GenerateQuery9to10(dt);
                        }
                        
                        txtQuery.Text = generateSQLScript;
                        con.Close();

                    }


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=SchholResult;Integrated Security=SSPI;");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        private void btnUpdateDB_Click(object sender, EventArgs e)
        {
            try
            {
                string generateSQL = txtQuery.Text;
                cmd = new SqlCommand(generateSQL, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Updated successfully!!");
            }
            catch
            {
                MessageBox.Show("Something wrong happend!!");
            }
            
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
            menu screen = new menu();
            screen.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtQuery.Text = "";
        }

        private void rd5to8Summative_CheckedChanged(object sender, EventArgs e)
        {
            txtQuery.Text = "";
        }
    }
}
