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
    public partial class result9to10 : Form
    {
        //Set the Page Size.
        int PageSize = 5;
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=SchholResult;Integrated Security=SSPI;");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public result9to10()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BindGrid(int pageIndex)
        {
            //"Data Source=localhost;Initial Catalog=northwind;Integrated Security=SSPI;"
            //string constring = @"Data Source=.\SQL2005;Initial Catalog=Northwind;Integrated Security=true";
            string constring = @"Data Source=localhost;Initial Catalog=SchholResult;Integrated Security=SSPI;";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("GetStudentResultPageWise", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                    cmd.Parameters.AddWithValue("@PageSize", PageSize);
                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4);
                    cmd.Parameters["@RecordCount"].Direction = ParameterDirection.Output;
                    con.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    rstGrid.DataSource = dt;
                    con.Close();
                    int recordCount = Convert.ToInt32(cmd.Parameters["@RecordCount"].Value);
                    this.PopulatePager(recordCount, pageIndex);
                }
            }
        }

        public class Page
        {
            public string Text { get; set; }
            public string Value { get; set; }
            public bool Selected { get; set; }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            this.BindGrid(1);
        }

        private void PopulatePager(int recordCount, int currentPage)
        {
            List<Page> pages = new List<Page>();
            int startIndex, endIndex;
            int pagerSpan = 5;

            //Calculate the Start and End Index of pages to be displayed.
            double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(PageSize));
            int pageCount = (int)Math.Ceiling(dblPageCount);
            startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
            endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
            if (currentPage > pagerSpan % 2)
            {
                if (currentPage == 2)
                {
                    endIndex = 5;
                }
                else
                {
                    endIndex = currentPage + 2;
                }
            }
            else
            {
                endIndex = (pagerSpan - currentPage) + 1;
            }

            if (endIndex - (pagerSpan - 1) > startIndex)
            {
                startIndex = endIndex - (pagerSpan - 1);
            }

            if (endIndex > pageCount)
            {
                endIndex = pageCount;
                startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
            }

            //Add the First Page Button.
            if (currentPage > 1)
            {
                pages.Add(new Page { Text = "First", Value = "1" });
            }

            //Add the Previous Button.
            if (currentPage > 1)
            {
                pages.Add(new Page { Text = "<<", Value = (currentPage - 1).ToString() });
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                pages.Add(new Page { Text = i.ToString(), Value = i.ToString(), Selected = i == currentPage });
            }

            //Add the Next Button.
            if (currentPage < pageCount)
            {
                pages.Add(new Page { Text = ">>", Value = (currentPage + 1).ToString() });
            }

            //Add the Last Button.
            if (currentPage != pageCount)
            {
                pages.Add(new Page { Text = "Last", Value = pageCount.ToString() });
            }

            //Clear existing Pager Buttons.
            pnlPager.Controls.Clear();

            //Loop and add Buttons for Pager.
            int count = 0;
            foreach (Page page in pages)
            {
                Button btnPage = new Button();
                btnPage.Location = new System.Drawing.Point(38 * count, 5);
                btnPage.Size = new System.Drawing.Size(35, 20);
                btnPage.Name = page.Value;
                btnPage.Text = page.Text;
                btnPage.Enabled = !page.Selected;
                btnPage.Click += new System.EventHandler(this.Page_Click);
                pnlPager.Controls.Add(btnPage);
                count++;
            }
        }

        private void Page_Click(object sender, EventArgs e)
        {
            Button btnPager = (sender as Button);
            this.BindGrid(int.Parse(btnPager.Name));
        }

        private void rstGrid_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtName.Text = rstGrid.Rows[e.RowIndex].Cells["StudentName"].Value.ToString();
            txtRoll.Text = rstGrid.Rows[e.RowIndex].Cells["StudentRoll"].Value.ToString();
            txtUnit.Text = rstGrid.Rows[e.RowIndex].Cells["StudentUnit"].Value.ToString();
            

            txtFrstLan.Text = rstGrid.Rows[e.RowIndex].Cells["FirstLan"].Value == null ? string.Empty : rstGrid.Rows[e.RowIndex].Cells["FirstLan"].Value.ToString();
            txtGeograph.Text = rstGrid.Rows[e.RowIndex].Cells["Geography"].Value == null ? string.Empty : rstGrid.Rows[e.RowIndex].Cells["Geography"].Value.ToString();
            txtHistory.Text = rstGrid.Rows[e.RowIndex].Cells["History"].Value == null ? string.Empty : rstGrid.Rows[e.RowIndex].Cells["History"].Value.ToString();
            txtLifeScnc.Text = rstGrid.Rows[e.RowIndex].Cells["LifeScience"].Value == null ? string.Empty : rstGrid.Rows[e.RowIndex].Cells["LifeScience"].Value.ToString();
            txtMath.Text = rstGrid.Rows[e.RowIndex].Cells["Mathematics"].Value == null ? string.Empty : rstGrid.Rows[e.RowIndex].Cells["Mathematics"].Value.ToString();
            txtScndLan.Text = rstGrid.Rows[e.RowIndex].Cells["SecondLan"].Value == null ? string.Empty : rstGrid.Rows[e.RowIndex].Cells["SecondLan"].Value.ToString();
            txtPhscSci.Text = rstGrid.Rows[e.RowIndex].Cells["PhysicalScience"].Value == null ? string.Empty : rstGrid.Rows[e.RowIndex].Cells["PhysicalScience"].Value.ToString();
            txtRemarks.Text =  rstGrid.Rows[e.RowIndex].Cells["Remarks"].Value == null ? string.Empty : rstGrid.Rows[e.RowIndex].Cells["Remarks"].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sqlQuery = @"UPDATE [dbo].[StudentResultFromNine]
               SET [FirstLan] = @FirstLan
                  ,[SecondLan] = @SecondLan
                  ,[Mathematics] = @Mathematics
                  ,[PhysicalScience] = @PhysicalScience
                  ,[LifeScience] = @LifeScience
                  ,[History] = @History
                  ,[Geography] = @Geography
                  ,[Remarks] = @Remarks 
             WHERE  StudentRoll = @StudentRoll and StudentUnit = @StudentUnit ";

            cmd = new SqlCommand(sqlQuery, con);
            con.Open();
            cmd.Parameters.AddWithValue("@FirstLan", txtFrstLan.Text);
            cmd.Parameters.AddWithValue("@SecondLan", txtScndLan.Text);
            cmd.Parameters.AddWithValue("@Mathematics", txtMath.Text);
            cmd.Parameters.AddWithValue("@PhysicalScience", txtPhscSci.Text);
            cmd.Parameters.AddWithValue("@LifeScience", txtLifeScnc.Text);
            cmd.Parameters.AddWithValue("@History", txtHistory.Text);
            cmd.Parameters.AddWithValue("@Geography", txtGeograph.Text);
            cmd.Parameters.AddWithValue("@Remarks", txtRemarks.Text);
            cmd.Parameters.AddWithValue("@StudentRoll", txtRoll.Text);
            cmd.Parameters.AddWithValue("@StudentUnit", txtUnit.Text);            
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
            con.Close();
            BindGrid(1);
            


        }

        private void txtFrstLan_Leave(object sender, EventArgs e)
        {
            var resultString = (((System.Windows.Forms.MaskedTextBox)(sender)).Text.ToString());
            int iResul  = 0;
            bool isNumeric = int.TryParse(resultString, out iResul);
            if(!isNumeric)
            {
                ((System.Windows.Forms.MaskedTextBox)(sender)).Text = "";
                return;
            }
        }

    }
}
