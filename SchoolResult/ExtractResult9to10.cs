using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


namespace SchoolResult
{
    public partial class ExtractResult9to10 : Form
    {
        public ExtractResult9to10()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=SchholResult;Integrated Security=SSPI;");
        SqlCommand cmd;
        SqlDataAdapter adapt;

        public System.Data.DataTable BindResultGrid()
        {
            string constring = @"Data Source=localhost;Initial Catalog=SchholResult;Integrated Security=SSPI;";
            System.Data.DataTable dt = new System.Data.DataTable();
            using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {
                    string generateSQL = string.Empty;
                    //generateSQL = "Select StudentId, StudentSec, StudentRoll, StudentUnit, " + updateColumnName() + " from  [StudentResult5to8]";
                    ExtractQuery eRes = new ExtractQuery();
                    generateSQL = eRes.ExtractQueryforExtractionFor9to10(Convert.ToInt32(cmbClass.Text), Convert.ToInt32(cmbUnit.Text), cmbSec.Text.ToString());

                    using (SqlCommand cmd = new SqlCommand(generateSQL, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();

                        dt.Load(cmd.ExecuteReader());
                        //rstGrid.DataSource = dt;
                        con.Close();
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return dt;

        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            if (cmbClass.SelectedIndex > -1 && cmbUnit.SelectedIndex > -1)
            {
                System.Data.DataTable sourceData = new System.Data.DataTable();
                sourceData = BindResultGrid();
                ExtractMergeResult(sourceData);
            }
            else
            {
                MessageBox.Show("Class and Unit is mandatory");
                return;
            }


        }

        public void ExtractMergeResult(System.Data.DataTable mergeData)
        {
            //OBJECT OF MISSING "NULL VALUE"


            Object oMissing = System.Reflection.Missing.Value;
            //Object oTemplatePath = @"C:\Subha\G\code\School Project\Final_School_Result_windows\Final_Result\9_10\9to10template.doc";
            Object oTemplatePath = ConfigurationManager.AppSettings["9to10template"];


            progressBar1.Minimum = 0;
            progressBar1.Maximum = mergeData.Rows.Count;
            int progressBarCounter = 0;
            string isExist = "No";
            int count = 0;
            ////wordDoc = wordApp.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);
            foreach (DataRow item in mergeData.Rows)
            {
                count++;
                //if (count > 10)
                //{
                //    MessageBox.Show("Done!!");
                //    return;
                //}
                    


                progressBarCounter++;
                progressBar1.Value = progressBarCounter;


                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                Document wordDoc = new Document();
                wordDoc = wordApp.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);


                foreach (Field myMergeField in wordDoc.Fields)
                {

                    Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;
                    // ONLY GETTING THE MAILMERGE FIELDS

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        // THE TEXT COMES IN THE FORMAT OF
                        // MERGEFIELD  MyFieldName  \\* MERGEFORMAT
                        // THIS HAS TO BE EDITED TO GET ONLY THE FIELDNAME "MyFieldName"

                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);
                        // GIVES THE FIELDNAMES AS THE USER HAD ENTERED IN .dot FILE

                        fieldName = fieldName.Trim();

                        // **** FIELD REPLACEMENT IMPLEMENTATION GOES HERE ****//




                        if (fieldName == "sname")
                        {
                            myMergeField.Select();
                            if (item["StudentName"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["StudentName"].ToString());
                            }
                        }
                        else if (fieldName == "sclass")
                        {
                            myMergeField.Select();
                            if (item["StudentClass"] != DBNull.Value)
                            {
                                switch (item["StudentClass"].ToString())
                                {
                                    case "9":
                                        wordApp.Selection.TypeText("IX");
                                        break;
                                    case "10":
                                        wordApp.Selection.TypeText("X");
                                        break;
                                    default:
                                        wordApp.Selection.TypeText("X");
                                        break;
                                }
                                //wordApp.Selection.TypeText(item["StudentClass"].ToString());
                            }
                        }
                        else if (fieldName == "ssec")
                        {
                            myMergeField.Select();
                            if (item["StudentSec"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["StudentSec"].ToString());
                            }
                        }
                        else if (fieldName == "sroll")
                        {
                            myMergeField.Select();
                            if (item["StudentRoll"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["StudentRoll"].ToString());
                            }
                        }
                        else if (fieldName == "1lt1")
                        {
                            myMergeField.Select();
                            if (item["FirstLanTheo"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["FirstLanTheo"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "1la1")
                        {
                            myMergeField.Select();
                            if (item["FirstLan"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["FirstLan"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "1lp1")
                        {
                            myMergeField.Select();
                            if (item["FirstLanPrac"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["FirstLanPrac"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "2lt1")
                        {
                            myMergeField.Select();
                            if (item["SecondLanTheo"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["SecondLanTheo"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "2lp1")
                        {
                            myMergeField.Select();
                            if (item["SecondLanPrac"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["SecondLanPrac"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "2la1")
                        {
                            myMergeField.Select();
                            if (item["SecondLan"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["SecondLan"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "3rt1" || fieldName == "3rp1" || fieldName == "3ra1" || fieldName == "3ra")
                        {
                            myMergeField.Select();
                            wordApp.Selection.TypeText(" ");
                        }
                        else if (fieldName == "mt1")
                        {
                            myMergeField.Select();
                            if (item["MathematicsTheo"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["MathematicsTheo"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "mp1")
                        {
                            myMergeField.Select();
                            if (item["MathematicsPrac"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["MathematicsPrac"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "ma1")
                        {
                            myMergeField.Select();
                            if (item["Mathematics"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["Mathematics"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "pst1")
                        {
                            myMergeField.Select();
                            if (item["PhysicalScienceTheo"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["PhysicalScienceTheo"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "psp1")
                        {
                            myMergeField.Select();
                            if (item["PhysicalSciencePrac"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["PhysicalSciencePrac"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "psa1")
                        {
                            myMergeField.Select();
                            if (item["PhysicalScience"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["PhysicalScience"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "lst1")
                        {
                            myMergeField.Select();
                            if (item["LifeScienceTheo"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["LifeScienceTheo"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "lsp1")
                        {
                            myMergeField.Select();
                            if (item["LifeSciencePrac"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["LifeSciencePrac"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "lsa1")
                        {
                            myMergeField.Select();
                            if (item["LifeScience"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["LifeScience"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "ht1")
                        {
                            myMergeField.Select();
                            if (item["HistoryTheo"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["HistoryTheo"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "hp1")
                        {
                            myMergeField.Select();
                            if (item["HistoryPrac"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["HistoryPrac"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "ha1")
                        {
                            myMergeField.Select();
                            if (item["History"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["History"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "gt1")
                        {
                            myMergeField.Select();
                            if (item["GeographyTheo"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["GeographyTheo"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "gp1")
                        {
                            myMergeField.Select();
                            if (item["GeographyPrac"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["GeographyPrac"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "ga1")
                        {
                            myMergeField.Select();
                            if (item["Geography"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["Geography"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }

                        else if (fieldName == "wt1" || fieldName == "wp1" || fieldName == "wa1")
                        {
                            myMergeField.Select();
                            wordApp.Selection.TypeText(" ");
                        }
                        else if (fieldName == "ct1" || fieldName == "cp1" || fieldName == "ca1")
                        {
                            myMergeField.Select();
                            wordApp.Selection.TypeText(" ");
                        }
                        #region  Second unit
                        //Second unit

                        else if (fieldName == "1lt2")
                        {
                            myMergeField.Select();
                            if (item["FirstLanTheo1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["FirstLanTheo1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "1la2")
                        {
                            myMergeField.Select();
                            if (item["FirstLan1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["FirstLan1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "1lp2")
                        {
                            myMergeField.Select();
                            if (item["FirstLanPrac1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["FirstLanPrac1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "2lt2")
                        {
                            myMergeField.Select();
                            if (item["SecondLanTheo1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["SecondLanTheo1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "2lp2")
                        {
                            myMergeField.Select();
                            if (item["SecondLanPrac1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["SecondLanPrac1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "2la2")
                        {
                            myMergeField.Select();
                            if (item["SecondLan1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["SecondLan1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "3rt2" || fieldName == "3rp2" || fieldName == "3ra2")
                        {
                            myMergeField.Select();
                            wordApp.Selection.TypeText(" ");
                        }
                        else if (fieldName == "mt2")
                        {
                            myMergeField.Select();
                            if (item["MathematicsTheo1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["MathematicsTheo1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "mp2")
                        {
                            myMergeField.Select();
                            if (item["MathematicsPrac1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["MathematicsPrac1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "ma2")
                        {
                            myMergeField.Select();
                            if (item["Mathematics1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["Mathematics1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "pst2")
                        {
                            myMergeField.Select();
                            if (item["PhysicalScienceTheo1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["PhysicalScienceTheo1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "psp2")
                        {
                            myMergeField.Select();
                            if (item["PhysicalSciencePrac1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["PhysicalSciencePrac1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "psa2")
                        {
                            myMergeField.Select();
                            if (item["PhysicalScience1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["PhysicalScience1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "lst2")
                        {
                            myMergeField.Select();
                            if (item["LifeScienceTheo1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["LifeScienceTheo1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "lsp2")
                        {
                            myMergeField.Select();
                            if (item["LifeSciencePrac1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["LifeSciencePrac1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "lsa2")
                        {
                            myMergeField.Select();
                            if (item["LifeScience1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["LifeScience1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "ht2")
                        {
                            myMergeField.Select();
                            if (item["HistoryTheo1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["HistoryTheo1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "hp2")
                        {
                            myMergeField.Select();
                            if (item["HistoryPrac1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["HistoryPrac1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "ha2")
                        {
                            myMergeField.Select();
                            if (item["History1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["History1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "gt2")
                        {
                            myMergeField.Select();
                            if (item["GeographyTheo1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["GeographyTheo1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "gp2")
                        {
                            myMergeField.Select();
                            if (item["GeographyPrac1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["GeographyPrac1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "ga2")
                        {
                            myMergeField.Select();
                            if (item["Geography1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["Geography1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }

                        else if (fieldName == "wt2" || fieldName == "wp2" || fieldName == "wa2")
                        {
                            myMergeField.Select();
                            wordApp.Selection.TypeText(" ");
                        }
                        else if (fieldName == "ct2" || fieldName == "cp2" || fieldName == "ca2")
                        {
                            myMergeField.Select();
                            wordApp.Selection.TypeText(" ");
                        }

                        #endregion

                        //if (Convert.ToInt32(item["StudentUnit"]) == 3)
                        //{
                            #region  Third unit
                            //Third unit

                        else if (fieldName == "1lt3")
                            {
                                myMergeField.Select();
                                if (item["FirstLanTheo2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["FirstLanTheo2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "1la3")
                            {
                                myMergeField.Select();
                                if (item["FirstLan2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["FirstLan2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                           
                            else if (fieldName == "1lp3")
                            {
                                myMergeField.Select();
                                if (item["FirstLanPrac2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["FirstLanPrac2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "1la")
                            {
                                myMergeField.Select();
                                if (item["FirstLan"] != DBNull.Value && item["FirstLan1"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText((Convert.ToInt32(item["FirstLan"]) + Convert.ToInt32(item["FirstLan1"])).ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "1la4")
                            {
                                myMergeField.Select();
                                if (item["FirstLan"] != DBNull.Value && item["FirstLan1"] != DBNull.Value && item["FirstLan2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText((Convert.ToInt32(item["FirstLan"]) + Convert.ToInt32(item["FirstLan1"]) + Convert.ToInt32(item["FirstLan2"])).ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "g1l")
                            {
                                myMergeField.Select();
                                if (item["FirstLan"] != DBNull.Value && item["FirstLan1"] != DBNull.Value && item["FirstLan2"] != DBNull.Value)
                                {
                                    decimal res = (Convert.ToDecimal(item["FirstLan"]) + Convert.ToDecimal(item["FirstLan1"]) + Convert.ToDecimal(item["FirstLan2"])) / 2;
                                    wordApp.Selection.TypeText(GradeSelection(res));
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                                
                            }
                        else if (fieldName == "av1l")
                        {
                            myMergeField.Select();
                            if (item["FirstLan"] != DBNull.Value && item["FirstLan1"] != DBNull.Value && item["FirstLan2"] != DBNull.Value)
                            {
                                decimal res = (Convert.ToDecimal(item["FirstLan"]) + Convert.ToDecimal(item["FirstLan1"]) + Convert.ToDecimal(item["FirstLan2"])) / 2;
                                wordApp.Selection.TypeText(res.ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }

                        }
                            else if (fieldName == "2lt3")
                            {
                                myMergeField.Select();
                                if (item["SecondLanTheo2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["SecondLanTheo2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "2lp3")
                            {
                                myMergeField.Select();
                                if (item["SecondLanPrac2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["SecondLanPrac2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "2la3")
                            {
                                myMergeField.Select();
                                if (item["SecondLan2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["SecondLan2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "2la")
                            {
                                myMergeField.Select();
                                if (item["SecondLan"] != DBNull.Value && item["SecondLan1"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText((Convert.ToInt32(item["SecondLan"]) + Convert.ToInt32(item["SecondLan1"])).ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "2la4")
                            {
                                myMergeField.Select();
                                if (item["SecondLan"] != DBNull.Value && item["SecondLan1"] != DBNull.Value && item["SecondLan2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText((Convert.ToInt32(item["SecondLan"]) + Convert.ToInt32(item["SecondLan1"]) + Convert.ToInt32(item["SecondLan2"])).ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "g2l")
                            {
                                myMergeField.Select();
                                if (item["SecondLan"] != DBNull.Value && item["SecondLan1"] != DBNull.Value && item["SecondLan2"] != DBNull.Value)
                                {
                                    decimal res = (Convert.ToDecimal(item["SecondLan"]) + Convert.ToDecimal(item["SecondLan1"]) + Convert.ToDecimal(item["SecondLan2"])) / 2;
                                    wordApp.Selection.TypeText(GradeSelection(res));
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                        else if (fieldName == "av2l")
                        {
                            myMergeField.Select();
                            if (item["SecondLan"] != DBNull.Value && item["SecondLan1"] != DBNull.Value && item["SecondLan2"] != DBNull.Value)
                            {
                                decimal res = (Convert.ToDecimal(item["SecondLan"]) + Convert.ToDecimal(item["SecondLan1"]) + Convert.ToDecimal(item["SecondLan2"])) / 2;
                                wordApp.Selection.TypeText(res.ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                            
                            else if (fieldName == "3rt3" || fieldName == "3rp3" || fieldName == "3ra3" || fieldName == "3ra4" || fieldName == "g3r")
                            {
                                myMergeField.Select();
                                wordApp.Selection.TypeText(" ");
                            }
                            else if (fieldName == "mt3")
                            {
                                myMergeField.Select();
                                if (item["MathematicsTheo2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["MathematicsTheo2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "mp3")
                            {
                                myMergeField.Select();
                                if (item["MathematicsPrac2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["MathematicsPrac2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "ma3")
                            {
                                myMergeField.Select();
                                if (item["Mathematics2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["Mathematics2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "ma")
                            {
                                myMergeField.Select();
                                if (item["Mathematics"] != DBNull.Value && item["Mathematics1"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText((Convert.ToInt32(item["Mathematics"]) + Convert.ToInt32(item["Mathematics1"])).ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "ma4")
                            {
                                myMergeField.Select();
                                if (item["Mathematics"] != DBNull.Value && item["Mathematics1"] != DBNull.Value && item["Mathematics2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText((Convert.ToInt32(item["Mathematics"]) + Convert.ToInt32(item["Mathematics1"]) + Convert.ToInt32(item["Mathematics2"])).ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "gm")
                            {
                                myMergeField.Select();
                                if (item["Mathematics"] != DBNull.Value && item["Mathematics1"] != DBNull.Value && item["Mathematics2"] != DBNull.Value)
                                {
                                    decimal res = (Convert.ToDecimal(item["Mathematics"]) + Convert.ToDecimal(item["Mathematics1"]) + Convert.ToDecimal(item["Mathematics2"])) / 2;
                                    wordApp.Selection.TypeText(GradeSelection(res));
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                        else if (fieldName == "avm")
                        {
                            myMergeField.Select();
                            if (item["Mathematics"] != DBNull.Value && item["Mathematics1"] != DBNull.Value && item["Mathematics2"] != DBNull.Value)
                            {
                                decimal res = (Convert.ToDecimal(item["Mathematics"]) + Convert.ToDecimal(item["Mathematics1"]) + Convert.ToDecimal(item["Mathematics2"])) / 2;
                                wordApp.Selection.TypeText(res.ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                            else if (fieldName == "pst3")
                            {
                                myMergeField.Select();
                                if (item["PhysicalScienceTheo2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["PhysicalScienceTheo2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "psp3")
                            {
                                myMergeField.Select();
                                if (item["PhysicalSciencePrac2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["PhysicalSciencePrac2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "psa3")
                            {
                                myMergeField.Select();
                                if (item["PhysicalScience2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["PhysicalScience2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "psa")
                            {
                                myMergeField.Select();
                                if (item["PhysicalScience"] != DBNull.Value && item["PhysicalScience1"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText((Convert.ToInt32(item["PhysicalScience"]) + Convert.ToInt32(item["PhysicalScience1"])).ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "psa4")
                            {
                                myMergeField.Select();
                                if (item["PhysicalScience"] != DBNull.Value && item["PhysicalScience1"] != DBNull.Value && item["PhysicalScience2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText((Convert.ToInt32(item["PhysicalScience"]) + Convert.ToInt32(item["PhysicalScience1"]) + Convert.ToInt32(item["PhysicalScience2"])).ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "gps")
                            {
                                myMergeField.Select();
                                if (item["PhysicalScience"] != DBNull.Value && item["PhysicalScience1"] != DBNull.Value && item["PhysicalScience2"] != DBNull.Value)
                                {
                                    decimal res = (Convert.ToDecimal(item["PhysicalScience"]) + Convert.ToDecimal(item["PhysicalScience1"]) + Convert.ToDecimal(item["PhysicalScience2"])) / 2;
                                    wordApp.Selection.TypeText(GradeSelection(res));
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                        else if (fieldName == "avp")
                        {
                            myMergeField.Select();
                            if (item["PhysicalScience"] != DBNull.Value && item["PhysicalScience1"] != DBNull.Value && item["PhysicalScience2"] != DBNull.Value)
                            {
                                decimal res = (Convert.ToDecimal(item["PhysicalScience"]) + Convert.ToDecimal(item["PhysicalScience1"]) + Convert.ToDecimal(item["PhysicalScience2"])) / 2;
                                wordApp.Selection.TypeText(res.ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                            else if (fieldName == "lst3")
                            {
                                myMergeField.Select();
                                if (item["LifeScienceTheo2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["LifeScienceTheo2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "lsp3")
                            {
                                myMergeField.Select();
                                if (item["LifeSciencePrac2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["LifeSciencePrac2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "lsa3")
                            {
                                myMergeField.Select();
                                if (item["LifeScience2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["LifeScience2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "lsa")
                            {
                                myMergeField.Select();
                                if (item["LifeScience"] != DBNull.Value && item["LifeScience1"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText((Convert.ToInt32(item["LifeScience"]) + Convert.ToInt32(item["LifeScience1"])).ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "lsa4")
                            {
                                myMergeField.Select();
                                if (item["LifeScience"] != DBNull.Value && item["LifeScience1"] != DBNull.Value && item["LifeScience2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText((Convert.ToInt32(item["LifeScience"]) + Convert.ToInt32(item["LifeScience1"]) + Convert.ToInt32(item["LifeScience2"])).ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "gls")
                            {
                                myMergeField.Select();
                                if (item["LifeScience"] != DBNull.Value && item["LifeScience1"] != DBNull.Value && item["LifeScience2"] != DBNull.Value)
                                {
                                    decimal res = (Convert.ToDecimal(item["LifeScience"]) + Convert.ToDecimal(item["LifeScience1"]) + Convert.ToDecimal(item["LifeScience2"])) / 2;
                                    wordApp.Selection.TypeText(GradeSelection(res));
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                        else if (fieldName == "avl")
                        {
                            myMergeField.Select();
                            if (item["LifeScience"] != DBNull.Value && item["LifeScience1"] != DBNull.Value && item["LifeScience2"] != DBNull.Value)
                            {
                                decimal res = (Convert.ToDecimal(item["LifeScience"]) + Convert.ToDecimal(item["LifeScience1"]) + Convert.ToDecimal(item["LifeScience2"])) / 2;
                                wordApp.Selection.TypeText(res.ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                            else if (fieldName == "ht3")
                            {
                                myMergeField.Select();
                                if (item["HistoryTheo2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["HistoryTheo2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "hp3")
                            {
                                myMergeField.Select();
                                if (item["HistoryPrac2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["HistoryPrac2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "ha3")
                            {
                                myMergeField.Select();
                                if (item["History2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["History2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "ha")
                            {
                                myMergeField.Select();
                                if (item["History"] != DBNull.Value && item["History1"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText((Convert.ToInt32(item["History"]) + Convert.ToInt32(item["History1"])).ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "ha4")
                            {
                                myMergeField.Select();
                                if (item["History"] != DBNull.Value && item["History1"] != DBNull.Value && item["History2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText((Convert.ToInt32(item["History"]) + Convert.ToInt32(item["History1"]) + Convert.ToInt32(item["History2"])).ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "gh")
                            {
                                myMergeField.Select();
                                if (item["History"] != DBNull.Value && item["History1"] != DBNull.Value && item["History2"] != DBNull.Value)
                                {
                                    decimal res = (Convert.ToDecimal(item["History"]) + Convert.ToDecimal(item["History1"]) + Convert.ToDecimal(item["History2"])) / 2;
                                    wordApp.Selection.TypeText(GradeSelection(res));
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                        else if (fieldName == "avh")
                        {
                            myMergeField.Select();
                            if (item["History"] != DBNull.Value && item["History1"] != DBNull.Value && item["History2"] != DBNull.Value)
                            {
                                decimal res = (Convert.ToDecimal(item["History"]) + Convert.ToDecimal(item["History1"]) + Convert.ToDecimal(item["History2"])) / 2;
                                wordApp.Selection.TypeText(res.ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }   
                            else if (fieldName == "gt3")
                            {
                                myMergeField.Select();
                                if (item["GeographyTheo2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["GeographyTheo2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "gp3")
                            {
                                myMergeField.Select();
                                if (item["GeographyPrac2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["GeographyPrac2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "ga3")
                            {
                                myMergeField.Select();
                                if (item["Geography2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["Geography2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }

                            else if (fieldName == "ga")
                            {
                                myMergeField.Select();
                                if (item["Geography"] != DBNull.Value && item["Geography1"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText((Convert.ToInt32(item["Geography"]) + Convert.ToInt32(item["Geography1"])).ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "ga4")
                            {
                                myMergeField.Select();
                                if (item["Geography"] != DBNull.Value && item["Geography1"] != DBNull.Value && item["Geography2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText((Convert.ToInt32(item["Geography"]) + Convert.ToInt32(item["Geography1"]) + Convert.ToInt32(item["Geography2"])).ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                           else if (fieldName == "gg")
                            {
                                myMergeField.Select();
                                if (item["Geography"] != DBNull.Value && item["Geography1"] != DBNull.Value && item["Geography2"] != DBNull.Value)
                                {
                                    decimal res = (Convert.ToDecimal(item["Geography"]) + Convert.ToDecimal(item["Geography1"]) + Convert.ToDecimal(item["Geography2"])) / 2;
                                    wordApp.Selection.TypeText(GradeSelection(res));
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                        else if (fieldName == "avg")
                        {
                            myMergeField.Select();
                            if (item["Geography"] != DBNull.Value && item["Geography1"] != DBNull.Value && item["Geography2"] != DBNull.Value)
                            {
                                decimal res = (Convert.ToDecimal(item["Geography"]) + Convert.ToDecimal(item["Geography1"]) + Convert.ToDecimal(item["Geography2"])) / 2;
                                wordApp.Selection.TypeText(res.ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }

                            else if (fieldName == "wt3")
                            {
                                myMergeField.Select();
                                if (item["WorkEduTheo2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["WorkEduTheo2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "wp3")
                            {
                                myMergeField.Select();
                                if (item["WorkEduPrac2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["WorkEduPrac2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "wa3")
                            {
                                myMergeField.Select();
                                if (item["WorkEdu2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["WorkEdu2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "wa")
                            {
                                myMergeField.Select();
                                if (item["WorkEdu"] != DBNull.Value && item["WorkEdu1"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText((Convert.ToInt32(item["WorkEdu"]) + Convert.ToInt32(item["WorkEdu1"])).ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "wa4")
                            {
                                myMergeField.Select();
                                wordApp.Selection.TypeText(" ");
                                //if (item["WorkEdu2"] != DBNull.Value)
                                //{
                                //    //wordApp.Selection.TypeText((Convert.ToInt32(item["WorkEdu"]) + Convert.ToInt32(item["WorkEdu1"]) + Convert.ToInt32(item["WorkEdu2"])).ToString());
                                //    wordApp.Selection.TypeText(Convert.ToInt32(item["WorkEdu2"]).ToString());
                                //}
                                //else
                                //{
                                //    wordApp.Selection.TypeText(" ");
                                //}
                            }
                            else if (fieldName == "gw")
                            {
                                myMergeField.Select();
                                if (item["WorkEdu2"] != DBNull.Value)
                                {
                                    //wordApp.Selection.TypeText((Convert.ToInt32(item["WorkEdu"]) + Convert.ToInt32(item["WorkEdu1"]) + Convert.ToInt32(item["WorkEdu2"])).ToString());
                                    decimal res = Convert.ToInt32(item["WorkEdu2"]);
                                    wordApp.Selection.TypeText(GradeSelection(res));
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                        else if (fieldName == "avw")
                        {
                            myMergeField.Select();
                            if (item["WorkEdu2"] != DBNull.Value)
                            {
                                //wordApp.Selection.TypeText((Convert.ToInt32(item["WorkEdu"]) + Convert.ToInt32(item["WorkEdu1"]) + Convert.ToInt32(item["WorkEdu2"])).ToString());
                                decimal res = Convert.ToInt32(item["WorkEdu2"]);
                                wordApp.Selection.TypeText(res.ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }

                            else if (fieldName == "ct3")
                            {
                                myMergeField.Select();
                                if (item["ComputerTheo2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["ComputerTheo2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "cp3")
                            {
                                myMergeField.Select();
                                if (item["ComputerPrac2"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText(item["ComputerPrac2"].ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "ca3")
                            {
                                myMergeField.Select();
                                if (item["Computer2"] != DBNull.Value)
                                {
                                    int num = Convert.ToInt32(item["Computer2"]) * 2;
                                    wordApp.Selection.TypeText(num.ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "ca")
                            {
                                myMergeField.Select();
                                if (item["Computer"] != DBNull.Value && item["Computer1"] != DBNull.Value)
                                {
                                    wordApp.Selection.TypeText((Convert.ToInt32(item["Computer"]) + Convert.ToInt32(item["Computer1"])).ToString());
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                            }
                            else if (fieldName == "ca4")
                            {
                                myMergeField.Select();
                                wordApp.Selection.TypeText(" ");
                                //if (item["Computer2"] != DBNull.Value)
                                //{
                                //    int res = Convert.ToInt32(item["Computer2"]);
                                //    wordApp.Selection.TypeText(res.ToString());
                                //}
                                //else
                                //{
                                //    wordApp.Selection.TypeText(" ");
                                //}
                            }
                        else if (fieldName == "gc")
                        {
                            myMergeField.Select();
                            if (item["Computer2"] != DBNull.Value)
                            {
                                //wordApp.Selection.TypeText((Convert.ToInt32(item["WorkEdu"]) + Convert.ToInt32(item["WorkEdu1"]) + Convert.ToInt32(item["WorkEdu2"])).ToString());
                                decimal res = Convert.ToInt32(item["Computer2"]);
                                res = res * 2;
                                wordApp.Selection.TypeText(GradeSelection(res));
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "avc")
                        {
                            myMergeField.Select();
                            if (item["Computer2"] != DBNull.Value)
                            {
                                //wordApp.Selection.TypeText((Convert.ToInt32(item["WorkEdu"]) + Convert.ToInt32(item["WorkEdu1"]) + Convert.ToInt32(item["WorkEdu2"])).ToString());
                                decimal res = Convert.ToInt32(item["Computer2"]);
                                res = res * 2;
                                wordApp.Selection.TypeText(res.ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }



                            //else if (fieldName == "wt2" || fieldName == "wp2" || fieldName == "wa2")
                            //{
                            //    myMergeField.Select();
                            //    wordApp.Selection.TypeText(" ");
                            //}
                            //else if (fieldName == "ct2" || fieldName == "cp2" || fieldName == "ca2")
                            //{
                            //    myMergeField.Select();
                            //    wordApp.Selection.TypeText(" ");
                            //}

                            #endregion
                        //}

                    }

                }
                string docName = item["StudentRoll"] + "_" + item["StudentName"] + "_" + item["StudentClass"] + "_" + item["StudentSec"] + "_" + item["StudentRoll"] + ".doc";
                //wordDoc.SaveAs(item["StudentName"] + "_" + item["StudentClass"] + "_" + item["StudentSec"] + "_" + item["StudentRoll"] + ".doc");
                //wordApp.Documents.Open("myFile.doc");
                
                string stringNameUtil = string.Empty;
                string stringNameUtilFolder = string.Empty;
                stringNameUtilFolder = saveDocFolder(item["StudentClass"].ToString(), item["StudentSec"].ToString(), item["StudentUnit"].ToString(), "");
                stringNameUtil = saveDocFolder(item["StudentClass"].ToString(), item["StudentSec"].ToString(), item["StudentUnit"].ToString(), docName);

                if (isExist == "No")
                {
                    if (!Directory.Exists(stringNameUtilFolder))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(stringNameUtilFolder);
                        isExist = "Yes";
                    }
                }


                wordDoc.SaveAs(stringNameUtil);
                wordApp.Application.Quit();
                wordApp = null;
                wordDoc = null;

            }

            MessageBox.Show("Extraction successfull");
            isExist = "No";
        }

        private string GradeSelection(decimal number)
        {
            
            string testNumber = number.ToString();
            if(testNumber.Contains("5"))
            {
                testNumber = testNumber.Replace(".5","");
                int testIntNum = Convert.ToInt32(testNumber);
                number = testIntNum + 1;
            }
            if (number < 25)
            {
                return "D";
            }
            else if (number >= 25 && number <= 34)
            {
                return "C";
            }
            else if (number >= 35 && number <= 44)
            {
                return "B";
            }
            else if (number >= 45 && number <= 59)
            {
                return "B+";
            }
            else if (number >= 60 && number <= 79)
            {
                return "A";
            }
            else if (number >= 80 && number <= 89)
            {
                return "A+";
            }
            else if (number >= 90 && number <= 100)
            {
                return "AA";
            }
            return "";
        }

        public string saveDocFolder(string className, string sec, string unit, string docname)
        {
            //C:\Subha\G\code\School Project\Final_School_Result_windows\Result\Unit\1\class\5\sec

            string pathAndDoc = string.Empty;

            pathAndDoc = ConfigurationManager.AppSettings["ExtractPath"].ToString();
            pathAndDoc = pathAndDoc + "\\class\\" + className + "\\sec\\" + sec + "\\" + docname;

            //pathAndDoc = pathAndDoc + @"C:\Subha\G\code\School Project\Final_School_Result_windows\Result\Unit";
            //pathAndDoc = pathAndDoc + "\\class\\" + className + "\\sec\\" + sec + "\\" + docname;

            return pathAndDoc;

        }

        private void ExtractResult9to10_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            cmbClass.Items.Add(9);
            cmbClass.Items.Add(10);


            cmbUnit.Items.Add(1);
            cmbUnit.Items.Add(2);
            cmbUnit.Items.Add(3);

            cmbSec.Items.Add("A");
            cmbSec.Items.Add("B");
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            menu menu = new menu();
            this.Close();
            menu.Show();
        }
      
    }
}
