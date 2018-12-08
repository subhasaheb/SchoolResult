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
    public partial class BulkResult5to8 : Form
    {
        public BulkResult5to8()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=SchholResult;Integrated Security=SSPI;");
        SqlCommand cmd;
        SqlDataAdapter adapt;

        private void BulkResult5to8_Load(object sender, EventArgs e)
        {
            //autoselect summative
            rdSummative.Checked = true;
            rdFirstLan.Checked = true;

            //populating class
            cmbClass.Items.Add(5);
            cmbClass.Items.Add(6);
            cmbClass.Items.Add(7);
            cmbClass.Items.Add(8);


            //populating section
            cmbSec.Items.Add("A");
            cmbSec.Items.Add("B");
            cmbSec.Items.Add("C");

            //populating
            cmbUnit.Items.Add(1);
            cmbUnit.Items.Add(2);
            cmbUnit.Items.Add(3);


            this.CenterToScreen();


        }

        public string updateColumnName()
        {
            if (rdFirstLan.Checked)
            {
                return "FirstLan";
            }
            else if (rdEnvGeo.Checked)
            {
                return "EnvironGeo";
            }
            else if (rdEnvHis.Checked)
            {
                return "EnvHis";
            }
            else if (rdScience.Checked)
            {
                return "Science";
            }
            else if (rdThirdLan.Checked)
            {
                return "ThrdLan";
            }
            else if (rdMathematics.Checked)
            {
                return "Mathematics";
            }
            else if (rdSecndLan.Checked)
            {
                return "SecndLan";
            }
            else if (rdComputer.Checked)
            {
                return "Computer";
            }
            else if (rdPhyArtEdu.Checked)
            {
                return "PhysArt";
            }
            //formative radio button
            else if (rdParticipation.Checked)
            {
                return "Participation";
            }
            else if (rdQuesExper.Checked)
            {
                return "QuestionExperiment";
            }
            else if (rdInterApp.Checked)
            {
                return "InterApplication";
            }
            else if (rdEmpCoop.Checked)
            {
                return "EmpaCooperation";
            }
            else if (rdCreaAesExpre.Checked)
            {
                return "CreativeAesthe";
            }

            return "FirstLan";
        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cmbClass.SelectedIndex > -1 && cmbSec.SelectedIndex > -1 && cmbUnit.SelectedIndex > -1)
            {
                BindResultGrid();
            }
            else
            {
                MessageBox.Show("Class, Section and Unit is mandatory");
                return;
            }


        }

        public bool BindResultGrid()
        {
            string constring = @"Data Source=localhost;Initial Catalog=SchholResult;Integrated Security=SSPI;";
            using (SqlConnection con = new SqlConnection(constring))
            {

                try
                {
                    string generateSQL = string.Empty;
                    generateSQL = @"Select std.StudentId, std.StudentSec,stf.StudentName, std.StudentRoll, StudentUnit, " + updateColumnName() + " from  [StudentResult5to8]  std left join [StudentInfo] stf on std.StudentId = stf.StudentId  where std.StudentClass = " + Convert.ToInt32(cmbClass.Text);
                    generateSQL += " AND std.StudentSec = '" + cmbSec.Text.ToString() + "'  AND std.StudentUnit = " + Convert.ToInt32(cmbUnit.Text);

                    using (SqlCommand cmd = new SqlCommand(generateSQL, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        rstGrid1.DataSource = dt;
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

        public bool BindResultGridFormative()
        {
            string constring = @"Data Source=localhost;Initial Catalog=SchholResult;Integrated Security=SSPI;";
            using (SqlConnection con = new SqlConnection(constring))
            {

                try
                {
                    string generateSQL = string.Empty;
                    generateSQL = @"Select std.StudentId, std.StudentSec,stf.StudentName, std.StudentRoll, StudentUnit, " + updateColumnName() + " from  [StudentFormativeResult5to8]  std left join [StudentInfo] stf on std.StudentId = stf.StudentId  where std.StudentClass = " + Convert.ToInt32(cmbClass.Text);
                    generateSQL += " AND std.StudentSec = '" + cmbSec.Text.ToString() + "'  AND std.StudentUnit = " + Convert.ToInt32(cmbUnit.Text);

                    using (SqlCommand cmd = new SqlCommand(generateSQL, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());
                        rstGrid1.DataSource = dt;
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

        public string GenerateUpdateSQL()
        {

            if (rstGrid1.Rows.Count < 1)
            {
                return "No Data";
            }
            string SQLString = string.Empty;
            SQLString = "BEGIN TRAN" + Environment.NewLine;

            string columnName = rstGrid1.Columns[5].Name.ToString();

            foreach (DataGridViewRow row in rstGrid1.Rows)
            {
                if (row.Cells[columnName].Value != null)
                {
                    if (row.Cells[columnName].Value.ToString() != "")
                    {

                        SQLString = SQLString + "UPDATE StudentResult5to8 SET " + columnName + " = " + row.Cells[columnName].Value + " WHERE StudentId = " + row.Cells["StudentId"].Value + " and studentSec = '" + row.Cells["studentSec"].Value + "' AND StudentRoll = " + row.Cells["StudentRoll"].Value + " AND StudentUnit = " + row.Cells["StudentUnit"].Value;
                        SQLString = SQLString + Environment.NewLine;
                    }
                }
            }
            SQLString = SQLString + "COMMIT TRAN";


            return SQLString;

        }

        public string GenerateUpdateSQLFormative()
        {

            if (rstGrid1.Rows.Count < 1)
            {
                return "No Data";
            }
            string SQLString = string.Empty;
            SQLString = "BEGIN TRAN" + Environment.NewLine;

            string columnName = rstGrid1.Columns[5].Name.ToString();

            foreach (DataGridViewRow row in rstGrid1.Rows)
            {
                if (row.Cells[columnName].Value != null)
                {
                    if (row.Cells[columnName].Value.ToString() != "")
                    {

                        SQLString = SQLString + "UPDATE StudentFormativeResult5to8 SET " + columnName + " = " + row.Cells[columnName].Value + " WHERE StudentId = " + row.Cells["StudentId"].Value + " and studentSec = '" + row.Cells["studentSec"].Value + "' AND StudentRoll = " + row.Cells["StudentRoll"].Value + " AND StudentUnit = " + row.Cells["StudentUnit"].Value;
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
            rstGrid1.Columns["StudentId"].ReadOnly = true;
            rstGrid1.Columns["StudentId"].Visible = false;

            rstGrid1.Columns["StudentSec"].ReadOnly = true;
            //rstGrid1.Columns["StudentSec"].Name = "Section";
            rstGrid1.Columns["StudentRoll"].ReadOnly = true;
            //rstGrid1.Columns["StudentRoll"].Name = "Roll";
            rstGrid1.Columns["StudentUnit"].ReadOnly = true;
            //rstGrid1.Columns["StudentUnit"].Name = "Unit";
            //rstGrid.Columns[6].ReadOnly = true;

            if (rstGrid1.Columns["StudentId"] != null)
                rstGrid1.Columns["StudentId"].HeaderText = "Student ID";

            if (rstGrid1.Columns["StudentSec"] != null)
                rstGrid1.Columns["StudentSec"].HeaderText = "Section";
            rstGrid1.Columns["StudentSec"].Visible = false;

            if (rstGrid1.Columns["StudentRoll"] != null)
                rstGrid1.Columns["StudentRoll"].HeaderText = "Roll";

            if (rstGrid1.Columns["StudentUnit"] != null)
                rstGrid1.Columns["StudentUnit"].HeaderText = "Unit";
            rstGrid1.Columns["StudentUnit"].Visible = false;

            if (rstGrid1.Columns["StudentName"] != null)
            {
                rstGrid1.Columns["StudentName"].HeaderText = "Name";
                rstGrid1.Columns["StudentName"].Width = 200;
                rstGrid1.Columns["StudentName"].ReadOnly = true;
            }
            if (rstGrid1.Columns["PhysArt"] != null)
            {
                rstGrid1.Columns["PhysArt"].HeaderText = "Physical Art Education";
                rstGrid1.Columns["PhysArt"].Width = 200;
            }
            if (rstGrid1.Columns["FirstLan"] != null)
            {
                rstGrid1.Columns["FirstLan"].HeaderText = "First Language";
                rstGrid1.Columns["FirstLan"].Width = 200;
            }
            if (rstGrid1.Columns["SecndLan"] != null)
            {
                rstGrid1.Columns["SecndLan"].HeaderText = "Second Language";
                rstGrid1.Columns["SecndLan"].Width = 200;
            }
            if (rstGrid1.Columns["ThrdLan"] != null)
            {
                rstGrid1.Columns["ThrdLan"].HeaderText = "Third Language";
                rstGrid1.Columns["ThrdLan"].Width = 200;
            }
            if (rstGrid1.Columns["EnvironGeo"] != null)
            {
                rstGrid1.Columns["EnvironGeo"].HeaderText = "Environment Geography";
                rstGrid1.Columns["EnvironGeo"].Width = 200;
            }
            if (rstGrid1.Columns["EnvHis"] != null)
            {
                rstGrid1.Columns["EnvHis"].HeaderText = "Environment History";
                rstGrid1.Columns["EnvHis"].Width = 200;
            }
            if (rstGrid1.Columns["Participation"] != null)
            {
                rstGrid1.Columns["Participation"].HeaderText = "Participation";
                rstGrid1.Columns["Participation"].Width = 200;
            }
            if (rstGrid1.Columns["QuestionExperiment"] != null)
            {
                rstGrid1.Columns["QuestionExperiment"].HeaderText = "Question and Experimentation";
                rstGrid1.Columns["QuestionExperiment"].Width = 250;
            }
            if (rstGrid1.Columns["InterApplication"] != null)
            {
                rstGrid1.Columns["InterApplication"].HeaderText = "Interpretation and Application";
                rstGrid1.Columns["InterApplication"].Width = 250;
            }
            if (rstGrid1.Columns["EmpaCooperation"] != null)
            {
                rstGrid1.Columns["EmpaCooperation"].HeaderText = "Empathy and Cooperation";
                rstGrid1.Columns["EmpaCooperation"].Width = 250;
            }
            if (rstGrid1.Columns["CreativeAesthe"] != null)
            {
                rstGrid1.Columns["CreativeAesthe"].HeaderText = "Creative and Aesthetic Expression";
                rstGrid1.Columns["CreativeAesthe"].Width = 250;
            }


        }

        private void rdGeograph_CheckedChanged(object sender, EventArgs e)
        {
            rstGrid1.DataSource = null;
        }

        private void rstGrid_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //int i = 0;
            //bool result = int.TryParse(rstGrid1[e.ColumnIndex, e.RowIndex].Value.ToString(), out i);
            //if (!result)
            //{
            //    MessageBox.Show("The field must be numeric");
            //    //rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
            //    rstGrid1[e.ColumnIndex, e.RowIndex].Value = 0;
            //}
        }

        private void rstGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //rstGrid.Rows[e.RowIndex].Cells["FirstLan"].Value
            try
            {
                int i = 0;
                bool result = int.TryParse(rstGrid1[e.ColumnIndex, e.RowIndex].Value.ToString(), out i);
                if (!result)
                {
                    MessageBox.Show("The field must be numeric");
                    //rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                    rstGrid1[e.ColumnIndex, e.RowIndex].Value = 0;
                    return;
                }


                if(rdSummative.Checked == true)
                {
                    if (Convert.ToInt32(cmbClass.Text) == 5)
                    {
                        if (Convert.ToInt32(rstGrid1["StudentUnit", e.RowIndex].Value) == 1)
                        {
                            try
                            {
                                if (Convert.ToInt32(rstGrid1[e.ColumnIndex, e.RowIndex].Value) > 10)
                                {
                                    MessageBox.Show("Number can not be greater than 10");
                                    rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("The field must be numeric");
                                rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                            }
                        }
                        else if (Convert.ToInt32(rstGrid1["StudentUnit", e.RowIndex].Value) == 2)
                        {
                            try
                            {
                                if (Convert.ToInt32(rstGrid1[e.ColumnIndex, e.RowIndex].Value) > 20)
                                {
                                    MessageBox.Show("Number can not be greater than 20");
                                    rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("The field must be numeric");
                                rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                            }
                        }
                        else if (Convert.ToInt32(rstGrid1["StudentUnit", e.RowIndex].Value) == 3)
                        {
                            try
                            {
                                if (Convert.ToInt32(rstGrid1[e.ColumnIndex, e.RowIndex].Value) > 50)
                                {
                                    MessageBox.Show("Number can not be greater than 50");
                                    rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("The field must be numeric");
                                rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                            }
                        }
                    }
                    else if (Convert.ToInt32(cmbClass.Text) == 6 || Convert.ToInt32(cmbClass.Text) == 7 || Convert.ToInt32(cmbClass.Text) == 8)
                    {
                        if (Convert.ToInt32(rstGrid1["StudentUnit", e.RowIndex].Value) == 1)
                        {
                            try
                            {
                                if (Convert.ToInt32(rstGrid1[e.ColumnIndex, e.RowIndex].Value) > 15)
                                {
                                    MessageBox.Show("Number can not be greater than 15");
                                    rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("The field must be numeric");
                                rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                            }
                        }
                        else if (Convert.ToInt32(rstGrid1["StudentUnit", e.RowIndex].Value) == 2)
                        {
                            try
                            {
                                if (Convert.ToInt32(rstGrid1[e.ColumnIndex, e.RowIndex].Value) > 25)
                                {
                                    MessageBox.Show("Number can not be greater than 25");
                                    rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("The field must be numeric");
                                rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                            }
                        }
                        else if (Convert.ToInt32(rstGrid1["StudentUnit", e.RowIndex].Value) == 3)
                        {
                            try
                            {
                                if (Convert.ToInt32(rstGrid1[e.ColumnIndex, e.RowIndex].Value) > 70)
                                {
                                    MessageBox.Show("Number can not be greater than 70");
                                    rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("The field must be numeric");
                                rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                            }
                        }
                    }
                    
                   
                }
                else if(rdFormative.Checked == true)
                {
                    if (Convert.ToInt32(cmbClass.Text) == 5)
                    {
                        if (Convert.ToInt32(rstGrid1["StudentUnit", e.RowIndex].Value) == 1)
                        {
                            try
                            {
                                if (Convert.ToInt32(rstGrid1[e.ColumnIndex, e.RowIndex].Value) > 10)
                                {
                                    MessageBox.Show("Number can not be greater than 10");
                                    rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("The field must be numeric");
                                rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                            }
                        }
                        else if (Convert.ToInt32(rstGrid1["StudentUnit", e.RowIndex].Value) == 2)
                        {
                            try
                            {
                                if (Convert.ToInt32(rstGrid1[e.ColumnIndex, e.RowIndex].Value) > 20)
                                {
                                    MessageBox.Show("Number can not be greater than 20");
                                    rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("The field must be numeric");
                                rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                            }
                        }
                        else if (Convert.ToInt32(rstGrid1["StudentUnit", e.RowIndex].Value) == 3)
                        {
                            try
                            {
                                if (Convert.ToInt32(rstGrid1[e.ColumnIndex, e.RowIndex].Value) > 20)
                                {
                                    MessageBox.Show("Number can not be greater than 20");
                                    rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("The field must be numeric");
                                rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                            }
                        }
                    }
                    else if (Convert.ToInt32(cmbClass.Text) == 6 || Convert.ToInt32(cmbClass.Text) == 7 || Convert.ToInt32(cmbClass.Text) == 8)
                    {
                        if (Convert.ToInt32(rstGrid1["StudentUnit", e.RowIndex].Value) == 1)
                        {
                            try
                            {
                                if (Convert.ToInt32(rstGrid1[e.ColumnIndex, e.RowIndex].Value) > 20)
                                {
                                    MessageBox.Show("Number can not be greater than 20");
                                    rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("The field must be numeric");
                                rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                            }
                        }
                        else if (Convert.ToInt32(rstGrid1["StudentUnit", e.RowIndex].Value) == 2)
                        {
                            try
                            {
                                if (Convert.ToInt32(rstGrid1[e.ColumnIndex, e.RowIndex].Value) > 20)
                                {
                                    MessageBox.Show("Number can not be greater than 20");
                                    rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("The field must be numeric");
                                rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                            }
                        }
                        else if (Convert.ToInt32(rstGrid1["StudentUnit", e.RowIndex].Value) == 3)
                        {
                            try
                            {
                                if (Convert.ToInt32(rstGrid1[e.ColumnIndex, e.RowIndex].Value) > 20)
                                {
                                    MessageBox.Show("Number can not be greater than 20");
                                    rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("The field must be numeric");
                                rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
                            }
                        }
                    }
                }
                

            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            this.Close();
            menu.Show();
        }

        private void btnGenerateFor_Click(object sender, EventArgs e)
        {
            if (cmbClass.SelectedIndex > -1 && cmbSec.SelectedIndex > -1 && cmbUnit.SelectedIndex > -1)
            {
                BindResultGridFormative();
            }
            else
            {
                MessageBox.Show("Class, Section and Unit is mandatory");
                return;
            }
        }

        private void btnFormative_Click(object sender, EventArgs e)
        {
            string sqlQuery = GenerateUpdateSQLFormative();

            cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Record updated successfully");
        }

        private void rdSummative_CheckedChanged(object sender, EventArgs e)
        {
            if (rdSummative.Checked == true)
            {
                rdFirstLan.Checked = true;
                groupBox2.Enabled = true;
                groupBox4.Enabled = false;
                //radio button disabled
                rdParticipation.Checked = false;
                rdQuesExper.Checked = false;
                rdInterApp.Checked = false;
                rdEmpCoop.Checked = false;
                rdCreaAesExpre.Checked = false;
                //Button enable/Disable
                btnUpdate.Enabled = true;
                btnFormative.Enabled = false;
                rdFirstLan.Checked = true;
            }
            else if (rdFormative.Checked == true)
            {
                rdParticipation.Checked = true;
                groupBox2.Enabled = false;
                groupBox4.Enabled = true;

                //radio button
                rdFirstLan.Checked = false;
                rdSecndLan.Checked = false;
                rdThirdLan.Checked = false;
                rdMathematics.Checked = false;
                rdScience.Checked = false;
                rdEnvHis.Checked = false;
                rdPhyArtEdu.Checked = false;
                rdComputer.Checked = false;
                rdEnvGeo.Checked = false;
                //Button enable/Disable
                btnUpdate.Enabled = false;
                btnFormative.Enabled = true;
                rdParticipation.Checked = true;
            }
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            rstGrid1.DataSource = null;
        }

        private void cmbSec_SelectedIndexChanged(object sender, EventArgs e)
        {
            rstGrid1.DataSource = null;
        }

        private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            rstGrid1.DataSource = null;
        }

        private void rstGrid1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
        }

        private void rstGrid1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("The field must be numeric");
            //rstGrid1[e.ColumnIndex, e.RowIndex].Value = System.DBNull.Value;
            rstGrid1[e.ColumnIndex, e.RowIndex].Value = 0;
        }


    }
}
