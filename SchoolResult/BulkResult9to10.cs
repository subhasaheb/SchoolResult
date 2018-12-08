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
    public partial class BulkResult9to10 : Form
    {
        public BulkResult9to10()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=SchholResult;Integrated Security=SSPI;");
        SqlCommand cmd;
        SqlDataAdapter adapt;

        private void BulkResult5to8_Load(object sender, EventArgs e)
        {
            //populating class
            cmbClass.Items.Add(9);
            cmbClass.Items.Add(10);
          

            //populating section
            cmbSec.Items.Add("A");
            cmbSec.Items.Add("B");
            cmbSec.Items.Add("C");

            //populating
            cmbUnit.Items.Add(1);
            cmbUnit.Items.Add(2);
            cmbUnit.Items.Add(3);

            rdFirstLan.Checked = true;

            this.CenterToScreen();


        }

        public string updateColumnName()
        {
            if(rdFirstLan.Checked)
            {
                return "FirstLan";
            }
            else if(rdGeograph.Checked)
            {
                return "Geography";
            }
            else if (rdHistory.Checked)
            {
                return "History";
            }
            else if (rdLifeScnc.Checked)
            {
                return "LifeScience";
            }
            else if (rdMathematics.Checked)
            {
                return "Mathematics";
            }
            else if (rdPhyScnc.Checked)
            {
                return "PhysicalScience";
            }
            else if (rdSecndLan.Checked)
            {
                return "SecondLan";
            }
            else if(rdComputer.Checked)
            {
                return "Computer";
            }
            else if (rdWorkEdu.Checked)
            {
                return "WorkEdu";
            }

            return "No Subject";
        }
        public bool ReturnTrueIfanyRadioButtonisChecked()
        {
            var checkedButton = Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            if (checkedButton == null)
                return false;
            else
                return
                    true;
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cmbClass.SelectedIndex > -1 && cmbSec.SelectedIndex > -1 && cmbUnit.SelectedIndex > -1)
            {
                //if (ReturnTrueIfanyRadioButtonisChecked() != false)
                //{
                    BindResultGrid();
                //}
                
            }
            else
            {
                MessageBox.Show("Class, Section and Unit is mandatory");
                return;
            }

            
        }

        public bool BindResultGrid()
        {

            if(updateColumnName() == "No Subject")
            {
                MessageBox.Show("Please select a subject from  radio button group!!");
                return false;
            }
            string constring = @"Data Source=localhost;Initial Catalog=SchholResult;Integrated Security=SSPI;";
            using (SqlConnection con = new SqlConnection(constring))
            {

                try
                {
                    string generateSQL = string.Empty;
                    //generateSQL = "Select StudentId, StudentSec, StudentRoll, StudentUnit, " + updateColumnName() + "Theo" + ", " + updateColumnName() + "Prac, " + updateColumnName() + " from  [StudentResultFromNine]";

                    generateSQL = "Select std.StudentId, std.StudentSec,stf.StudentName, std.StudentRoll, StudentUnit, " + updateColumnName() + "Theo" + ", " + updateColumnName() + "Prac, " + updateColumnName() + " from  [StudentResultFromNine] std left join [StudentInfo] stf on std.StudentId = stf.StudentId  where std.StudentClass = " + Convert.ToInt32(cmbClass.Text);
                    generateSQL += " AND std.StudentSec = '" + cmbSec.Text.ToString() + "'  AND std.StudentUnit = " + Convert.ToInt32(cmbUnit.Text);

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
                catch(Exception ex)
                {
                    throw ex;
                }
            }

            return true;

        }

        public string GenerateUpdateSQL()
        {
            
            if(rstGrid.Rows.Count < 1)
            {
                return "No Data";
            }
            string SQLString = string.Empty;
            SQLString = "BEGIN TRAN" + Environment.NewLine;

            string columnName = rstGrid.Columns[7].Name.ToString();

            foreach (DataGridViewRow row in rstGrid.Rows)
            {
                if (row.Cells[columnName].Value != null)
                {
                    if (row.Cells[columnName].Value.ToString() != "")
                    {
                        if (row.Cells[5].Value.ToString() == "")
                        {
                            row.Cells[5].Value = 0;
                        }
                        if (row.Cells[6].Value.ToString() == "")
                        {
                            row.Cells[6].Value = 0;
                        }
                        SQLString = SQLString + "UPDATE StudentResultFromNine SET " + columnName + " = " + row.Cells[columnName].Value + ", " + columnName + "Theo = " +  row.Cells[5].Value + ", " + columnName + "Prac = " + row.Cells[6].Value + " WHERE StudentId = " + row.Cells["StudentId"].Value + " and studentSec = '" + row.Cells["studentSec"].Value + "' AND StudentRoll = " + row.Cells["StudentRoll"].Value + " AND StudentUnit = " + row.Cells["StudentUnit"].Value;
                        SQLString = SQLString + Environment.NewLine;
                    }
                }
            }
            SQLString = SQLString + "COMMIT TRAN";


            return SQLString;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sqlQuery = GenerateUpdateSQL();

            cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Record updated successfully");
        }

        private void rstGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            rstGrid.Columns["StudentId"].ReadOnly = true;
            rstGrid.Columns["StudentId"].Visible = false;
            
            rstGrid.Columns["StudentSec"].ReadOnly = true;
            rstGrid.Columns["StudentSec"].Visible = false;
            rstGrid.Columns["StudentRoll"].ReadOnly = true;
            rstGrid.Columns["StudentUnit"].ReadOnly = true;
            rstGrid.Columns["StudentUnit"].Visible = false;
            rstGrid.Columns[0].ReadOnly = true;
            rstGrid.Columns[1].ReadOnly = true;
            rstGrid.Columns[2].ReadOnly = true;
            rstGrid.Columns[3].ReadOnly = true;
            rstGrid.Columns[4].ReadOnly = true;
            rstGrid.Columns[7].ReadOnly = true;

            
            rstGrid.Columns["StudentId"].HeaderText = "Student ID";
            rstGrid.Columns["StudentSec"].HeaderText = "Section";
            rstGrid.Columns["StudentRoll"].HeaderText = "Roll";
            rstGrid.Columns["StudentUnit"].HeaderText = "Unit";
            rstGrid.Columns["StudentName"].HeaderText = "Name";
            rstGrid.Columns["StudentName"].Width = 200;


            //if (rstGrid.Columns["StudentName"] != null)
            //{
            //    rstGrid.Columns["StudentName"].HeaderText = "Name";
            //    rstGrid.Columns["StudentName"].Width = 200;
            //}

        }

        private void rdGeograph_CheckedChanged(object sender, EventArgs e)
        {
            rstGrid.DataSource = null;
        }

        private void rstGrid_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void rstGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //rstGrid.Rows[e.RowIndex].Cells["FirstLan"].Value
            //if (rstGrid["StudentUnit", e.RowIndex].Value.ToString() != "")
            //{
            //    if (Convert.ToInt32(rstGrid["StudentUnit", e.RowIndex].Value) == 1)
            //    {
            //        if (rstGrid[e.ColumnIndex, e.RowIndex].Value.ToString() != "")
            //        {
            //            if (Convert.ToInt32(rstGrid[e.ColumnIndex, e.RowIndex].Value) > 20)
            //            {
            //                MessageBox.Show("Number can not be greater than 20");
            //                rstGrid[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
            //            }
            //        }
            //        //rstGrid.Rows[e.RowIndex].Cells[7].Value = (rstGrid.Rows[e.RowIndex].Cells[5].Value.ToString() == "" ? 0 : Convert.ToDecimal(rstGrid.Rows[e.RowIndex].Cells[5].Value.ToString())) + (rstGrid.Rows[e.RowIndex].Cells[6].Value.ToString() == "" ? 0 : Convert.ToDecimal(rstGrid.Rows[e.RowIndex].Cells[6].Value.ToString()));

            //    }

            //    rstGrid.Rows[e.RowIndex].Cells[7].Value = (rstGrid.Rows[e.RowIndex].Cells[5].Value.ToString() == "" ? 0 : Convert.ToDecimal(rstGrid.Rows[e.RowIndex].Cells[5].Value.ToString())) + (rstGrid.Rows[e.RowIndex].Cells[6].Value.ToString() == "" ? 0 : Convert.ToDecimal(rstGrid.Rows[e.RowIndex].Cells[6].Value.ToString()));
            //}
            //rstGrid.Rows[e.RowIndex].Cells["FirstLan"].Value
            if (rstGrid["StudentUnit", e.RowIndex].Value.ToString() != "")
            {
                if (rstGrid[e.ColumnIndex, e.RowIndex].Value.ToString() != "")
                {
                    Int32 unit = Convert.ToInt32(rstGrid["StudentUnit", e.RowIndex].Value);
                    if (unit == 1 || unit == 2 || unit == 3)
                    {
                        //If control comes for Theo, e.ColumnIndex should be 5.
                        //So, for column 5 maximum value can be 40.
                        //If constol comes for Prac, e.ColumnIndex should be 6.
                        //So, for column 6 maximum value can be 10.
                        Int32 MAXTHEOMARKS = unit == 3 ? 90 : 40;
                        Int32 column = e.ColumnIndex;
                        Int32 marks = Convert.ToInt32(rstGrid[e.ColumnIndex, e.RowIndex].Value);
                        if (marks < 0)
                        {
                            MessageBox.Show("All marks should be positive.");
                            rstGrid[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                            return;
                        }
                        else if (column == 5 && marks > MAXTHEOMARKS)
                        {
                            MessageBox.Show("Theory marks can not be greater than " + MAXTHEOMARKS);
                            rstGrid[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                            return;
                        }
                        else if (column == 6 && marks > 10)
                        {
                            MessageBox.Show("Practical marks can not be greater than 10.");
                            rstGrid[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                            return;
                        }
                    }
                    //rstGrid.Rows[e.RowIndex].Cells[7].Value = (rstGrid.Rows[e.RowIndex].Cells[5].Value.ToString() == "" ? 0 : Convert.ToDecimal(rstGrid.Rows[e.RowIndex].Cells[5].Value.ToString())) + (rstGrid.Rows[e.RowIndex].Cells[6].Value.ToString() == "" ? 0 : Convert.ToDecimal(rstGrid.Rows[e.RowIndex].Cells[6].Value.ToString()));
                }
                rstGrid.Rows[e.RowIndex].Cells[7].Value = (rstGrid.Rows[e.RowIndex].Cells[5].Value.ToString() == "" ? 0 : Convert.ToDecimal(rstGrid.Rows[e.RowIndex].Cells[5].Value.ToString())) + (rstGrid.Rows[e.RowIndex].Cells[6].Value.ToString() == "" ? 0 : Convert.ToDecimal(rstGrid.Rows[e.RowIndex].Cells[6].Value.ToString()));
            }

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            this.Close();
            menu.Show();
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            rstGrid.DataSource = null;
        }

        private void cmbSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            rstGrid.DataSource = null;
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            rstGrid.DataSource = null;
        }

        private void rstGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("The field must be numeric");
            //rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
            rstGrid[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
        }


    }
}
