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
    public partial class ExtractResult : Form
    {
        public ExtractResult()
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
            System.Data.DataTable dt1 = new System.Data.DataTable();
            System.Data.DataTable dtFinal = new System.Data.DataTable();

            using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {

                    string generateSQL = string.Empty;
                    ExtractQuery eRes = new ExtractQuery();
                    generateSQL = eRes.ExtractQueryforExtraction(Convert.ToInt32(cmbClass.Text), Convert.ToInt32(cmbUnit.Text), cmbSec.Text.ToString());

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
            //Object oTemplatePath = @"C:\Subha\G\code\School Project\Final_School_Result_windows\5to8template.doc";
            //Object oTemplatePath = @"C:\Subha\G\code\School Project\Final_School_Result_windows\Final_Result\final_5_a\5to8template.doc";
            Object oTemplatePath = ConfigurationManager.AppSettings["5to8template"];
            //


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

                        // THE PROGRAMMER CAN HAVE HIS OWN IMPLEMENTATIONS HERE

                        if (fieldName == "pf111")
                        {

                            myMergeField.Select();
                            if (item["Participation"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["Participation"].ToString());
                            }
                        }
                        else if (fieldName == "sname")
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
                                    case "5":
                                        wordApp.Selection.TypeText("V");
                                        break;
                                    case "6":
                                        wordApp.Selection.TypeText("VI");
                                        break;
                                    case "7":
                                        wordApp.Selection.TypeText("VII");
                                        break;
                                    case "8":
                                        wordApp.Selection.TypeText("VIII");
                                        break;
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
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        //else if (fieldName == "qf1")
                        //{
                        //    myMergeField.Select();
                        //    if (item["QuestionExperiment"] != DBNull.Value)
                        //    {
                        //        if (Convert.ToInt32(item["StudentUnit"]) == 1)
                        //        {
                        //            wordApp.Selection.TypeText(item["QuestionExperiment"].ToString());
                        //        }
                        //        else
                        //        {
                        //            wordApp.Selection.TypeText(" ");
                        //        }
                        //    }
                        //}
                        //else if (fieldName == "qf1")
                        //{
                        //    myMergeField.Select();
                        //    if (item["QuestionExperiment"] != DBNull.Value)
                        //    {
                        //        if (Convert.ToInt32(item["StudentUnit"]) == 1)
                        //        {
                        //            wordApp.Selection.TypeText(item["QuestionExperiment"].ToString());
                        //        }
                        //        else
                        //        {
                        //            wordApp.Selection.TypeText(" ");
                        //        }

                        //    }
                        //}
                        //else if (fieldName == "if1")
                        //{
                        //    myMergeField.Select();
                        //    if (item["InterApplication"] != DBNull.Value)
                        //    {
                        //        if (Convert.ToInt32(item["StudentUnit"]) == 1)
                        //        {
                        //            wordApp.Selection.TypeText(item["InterApplication"].ToString());
                        //        }
                        //        else
                        //        {
                        //            wordApp.Selection.TypeText(" ");
                        //        }

                        //    }
                        //}
                        //else if (fieldName == "ef1")
                        //{
                        //    myMergeField.Select();
                        //    if (item["EmpaCooperation"] != DBNull.Value)
                        //    {
                        //        if (Convert.ToInt32(item["StudentUnit"]) == 1)
                        //        {
                        //            wordApp.Selection.TypeText(item["EmpaCooperation"].ToString());
                        //        }
                        //        else
                        //        {
                        //            wordApp.Selection.TypeText(" ");
                        //        }

                        //    }
                        //}
                        //else if (fieldName == "cf1")
                        //{
                        //    myMergeField.Select();
                        //    if (item["CreativeAesthe"] != DBNull.Value)
                        //    {
                        //        if (Convert.ToInt32(item["StudentUnit"]) == 1)
                        //        {
                        //            wordApp.Selection.TypeText(item["CreativeAesthe"].ToString());
                        //        }
                        //        else
                        //        {
                        //            wordApp.Selection.TypeText(" ");
                        //        }

                        //    }
                        //}
                        else if (fieldName == "1ls1")
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
                        else if (fieldName == "2ls1")
                        {
                            myMergeField.Select();
                            if (item["SecndLan"] != DBNull.Value)
                            {

                                wordApp.Selection.TypeText(item["SecndLan"].ToString());

                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "3rs1")
                        {
                            myMergeField.Select();
                            if (item["ThrdLan"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["ThrdLan"].ToString());

                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "ms1")
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
                        else if (fieldName == "ss1")
                        {
                            myMergeField.Select();
                            if (item["Science"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["Science"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "hs1")
                        {
                            myMergeField.Select();
                            if (item["EnvHis"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["EnvHis"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "gs1")
                        {
                            myMergeField.Select();
                            if (item["EnvironGeo"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["EnvironGeo"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "cs1")
                        {
                            myMergeField.Select();
                            if (item["Computer"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["Computer"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "as1")
                        {
                            myMergeField.Select();
                            if (item["PhysArt"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["PhysArt"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        //second unit

                        else if (fieldName == "1ls2")
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
                        else if (fieldName == "2ls2")
                        {
                            myMergeField.Select();
                            if (item["SecndLan1"] != DBNull.Value)
                            {

                                wordApp.Selection.TypeText(item["SecndLan1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "3rs2")
                        {
                            myMergeField.Select();
                            if (item["ThrdLan1"] != DBNull.Value)
                            {

                                wordApp.Selection.TypeText(item["ThrdLan1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "ms2")
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
                        else if (fieldName == "ss2")
                        {
                            myMergeField.Select();
                            if (item["Science1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["Science1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "hs2")
                        {
                            myMergeField.Select();
                            if (item["EnvHis1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["EnvHis1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "gs2")
                        {
                            myMergeField.Select();
                            if (item["EnvironGeo1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["EnvironGeo1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "cs2")
                        {
                            myMergeField.Select();
                            if (item["Computer1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["Computer1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "as2")
                        {
                            myMergeField.Select();
                            if (item["PhysArt1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["PhysArt1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }

                        //Third Unit
                        // unit

                        else if (fieldName == "1ls3")
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
                        else if (fieldName == "2ls3")
                        {
                            myMergeField.Select();
                            if (item["SecndLan2"] != DBNull.Value)
                            {

                                wordApp.Selection.TypeText(item["SecndLan2"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "3rs3")
                        {
                            myMergeField.Select();
                            if (item["ThrdLan2"] != DBNull.Value)
                            {

                                wordApp.Selection.TypeText(item["ThrdLan2"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "ms3")
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
                        else if (fieldName == "ss3")
                        {
                            myMergeField.Select();
                            if (item["Science2"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["Science2"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "hs3")
                        {
                            myMergeField.Select();
                            if (item["EnvHis2"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["EnvHis2"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "gs3")
                        {
                            myMergeField.Select();
                            if (item["EnvironGeo2"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["EnvironGeo2"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "cs3")
                        {
                            myMergeField.Select();
                            if (item["Computer2"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["Computer2"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "as3")
                        {
                            myMergeField.Select();
                            if (item["PhysArt2"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["PhysArt2"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        //third unit end

                        //Summative Total
                        #region Summative Total
                        if (item["StudentUnit"] != null)
                        {
                            //if (Convert.ToInt32(item["StudentUnit"]) == 3)
                            if (Convert.ToInt32(cmbUnit.Text) == 3)
                            {
                                if (fieldName == "1lst")
                                {
                                    myMergeField.Select();
                                    int res = (item["FirstLan"] == DBNull.Value ? 0 : Convert.ToInt32(item["FirstLan"])) + (item["FirstLan1"] == DBNull.Value ? 0 : Convert.ToInt32(item["FirstLan1"])) + (item["FirstLan2"] == DBNull.Value ? 0 : Convert.ToInt32(item["FirstLan2"]));
                                    wordApp.Selection.TypeText(res.ToString());

                                }
                                else if (fieldName == "g1l")
                                {
                                    myMergeField.Select();
                                    int res = (item["FirstLan"] == DBNull.Value ? 0 : Convert.ToInt32(item["FirstLan"])) + (item["FirstLan1"] == DBNull.Value ? 0 : Convert.ToInt32(item["FirstLan1"])) + (item["FirstLan2"] == DBNull.Value ? 0 : Convert.ToInt32(item["FirstLan2"]));
                                    wordApp.Selection.TypeText(GradeSelection(res));

                                }
                                else if (fieldName == "2lst")
                                {
                                    myMergeField.Select();
                                    int res = (item["SecndLan"] == DBNull.Value ? 0 : Convert.ToInt32(item["SecndLan"])) + (item["SecndLan1"] == DBNull.Value ? 0 : Convert.ToInt32(item["SecndLan1"])) + (item["SecndLan2"] == DBNull.Value ? 0 : Convert.ToInt32(item["SecndLan2"]));
                                    wordApp.Selection.TypeText(res.ToString());

                                }
                                else if (fieldName == "g2l")
                                {
                                    myMergeField.Select();
                                    int res = (item["SecndLan"] == DBNull.Value ? 0 : Convert.ToInt32(item["SecndLan"])) + (item["SecndLan1"] == DBNull.Value ? 0 : Convert.ToInt32(item["SecndLan1"])) + (item["SecndLan2"] == DBNull.Value ? 0 : Convert.ToInt32(item["SecndLan2"]));
                                    wordApp.Selection.TypeText(GradeSelection(res));

                                }
                                else if (fieldName == "3rst")
                                {
                                    myMergeField.Select();
                                    if (Convert.ToInt32(cmbClass.Text) == 5 || Convert.ToInt32(cmbClass.Text) == 6)
                                    {
                                        wordApp.Selection.TypeText(" ");
                                    }
                                    else
                                    {
                                        decimal res = (item["ThrdLan"] == DBNull.Value ? 0 : Convert.ToInt32(item["ThrdLan"])) + (item["ThrdLan1"] == DBNull.Value ? 0 : Convert.ToInt32(item["ThrdLan1"])) + (item["ThrdLan2"] == DBNull.Value ? 0 : Convert.ToInt32(item["ThrdLan2"]));
                                        wordApp.Selection.TypeText(res.ToString());
                                    }
                                    

                                }
                                else if (fieldName == "g3r")
                                {
                                    myMergeField.Select();
                                    if (Convert.ToInt32(cmbClass.Text) == 5)
                                    {
                                        wordApp.Selection.TypeText(" ");
                                    }
                                    else
                                    {
                                        decimal res = (item["ThrdLan"] == DBNull.Value ? 0 : Convert.ToInt32(item["ThrdLan"])) + (item["ThrdLan1"] == DBNull.Value ? 0 : Convert.ToInt32(item["ThrdLan1"])) + (item["ThrdLan2"] == DBNull.Value ? 0 : Convert.ToInt32(item["ThrdLan2"]));
                                        wordApp.Selection.TypeText(GradeSelection(res));
                                    }
                                    

                                }
                                else if (fieldName == "mst")
                                {
                                    myMergeField.Select();
                                    decimal res = (item["Mathematics"] == DBNull.Value ? 0 : Convert.ToInt32(item["Mathematics"])) + (item["Mathematics1"] == DBNull.Value ? 0 : Convert.ToInt32(item["Mathematics1"])) + (item["Mathematics2"] == DBNull.Value ? 0 : Convert.ToInt32(item["Mathematics2"]));
                                    wordApp.Selection.TypeText(res.ToString());

                                }
                                else if (fieldName == "gm")
                                {
                                    myMergeField.Select();
                                    decimal res = (item["Mathematics"] == DBNull.Value ? 0 : Convert.ToInt32(item["Mathematics"])) + (item["Mathematics1"] == DBNull.Value ? 0 : Convert.ToInt32(item["Mathematics1"])) + (item["Mathematics2"] == DBNull.Value ? 0 : Convert.ToInt32(item["Mathematics2"]));
                                    wordApp.Selection.TypeText(GradeSelection(res));

                                }
                                else if (fieldName == "sst")
                                {
                                    myMergeField.Select();
                                    decimal res = (item["Science"] == DBNull.Value ? 0 : Convert.ToInt32(item["Science"])) + (item["Science1"] == DBNull.Value ? 0 : Convert.ToInt32(item["Science1"])) + (item["Science2"] == DBNull.Value ? 0 : Convert.ToInt32(item["Science2"]));
                                    wordApp.Selection.TypeText(res.ToString());

                                }
                                else if (fieldName == "gs")
                                {
                                    myMergeField.Select();
                                    decimal res = (item["Science"] == DBNull.Value ? 0 : Convert.ToInt32(item["Science"])) + (item["Science1"] == DBNull.Value ? 0 : Convert.ToInt32(item["Science1"])) + (item["Science2"] == DBNull.Value ? 0 : Convert.ToInt32(item["Science2"]));
                                    wordApp.Selection.TypeText(GradeSelection(res));

                                }
                                else if (fieldName == "hst")
                                {
                                    myMergeField.Select();
                                    if(Convert.ToInt32(cmbClass.Text) == 5)
                                    {
                                        wordApp.Selection.TypeText(" ");
                                    }
                                    else
                                    {
                                        decimal res = (item["EnvHis"] == DBNull.Value ? 0 : Convert.ToInt32(item["EnvHis"])) + (item["EnvHis1"] == DBNull.Value ? 0 : Convert.ToInt32(item["EnvHis1"])) + (item["EnvHis2"] == DBNull.Value ? 0 : Convert.ToInt32(item["EnvHis2"]));
                                        wordApp.Selection.TypeText(res.ToString());
                                    }
                                    

                                }
                                else if (fieldName == "gh")
                                {
                                    myMergeField.Select();
                                    if(Convert.ToInt32(cmbClass.Text) == 5)
                                    {
                                        wordApp.Selection.TypeText(" ");
                                    }
                                    else
                                    {
                                        decimal res = (item["EnvHis"] == DBNull.Value ? 0 : Convert.ToInt32(item["EnvHis"])) + (item["EnvHis1"] == DBNull.Value ? 0 : Convert.ToInt32(item["EnvHis1"])) + (item["EnvHis2"] == DBNull.Value ? 0 : Convert.ToInt32(item["EnvHis2"]));
                                        wordApp.Selection.TypeText(GradeSelection(res));
                                    }
                                    

                                }
                                else if (fieldName == "gst")
                                {
                                    myMergeField.Select();
                                    
                                        if (Convert.ToInt32(cmbClass.Text) == 5)
                                        {
                                            wordApp.Selection.TypeText(" ");
                                        }
                                        else
                                        {
                                            decimal res = (item["EnvironGeo"] == DBNull.Value ? 0 : Convert.ToInt32(item["EnvironGeo"])) + (item["EnvironGeo1"] == DBNull.Value ? 0 : Convert.ToInt32(item["EnvironGeo1"])) + (item["EnvironGeo2"] == DBNull.Value ? 0 : Convert.ToInt32(item["EnvironGeo2"]));
                                            wordApp.Selection.TypeText(res.ToString());
                                        }
                                    

                                }
                                else if (fieldName == "gg")
                                {
                                    myMergeField.Select();
                                    if (Convert.ToInt32(cmbClass.Text) == 5)
                                    {
                                        wordApp.Selection.TypeText(" ");
                                    }
                                    else
                                    {
                                        decimal res = (item["EnvironGeo"] == DBNull.Value ? 0 : Convert.ToInt32(item["EnvironGeo"])) + (item["EnvironGeo1"] == DBNull.Value ? 0 : Convert.ToInt32(item["EnvironGeo1"])) + (item["EnvironGeo2"] == DBNull.Value ? 0 : Convert.ToInt32(item["EnvironGeo2"]));
                                        wordApp.Selection.TypeText(GradeSelection(res));
                                    }
                                    

                                }
                                else if (fieldName == "cst")
                                {
                                    myMergeField.Select();
                                    if (item["Computer"] == DBNull.Value && item["Computer1"] == DBNull.Value && item["Computer2"] == DBNull.Value)
                                    {
                                        wordApp.Selection.TypeText(" ");
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(cmbClass.Text) == 5)
                                        {
                                            wordApp.Selection.TypeText(" ");
                                        }
                                        else
                                        {
                                            //decimal res = (item["Computer"] == DBNull.Value ? 0 : Convert.ToInt32(item["Computer2"])) + (item["Computer1"] == DBNull.Value ? 0 : Convert.ToInt32(item["Computer1"])) + (item["Computer2"] == DBNull.Value ? 0 : Convert.ToInt32(item["Computer2"]));
                                            //wordApp.Selection.TypeText(res.ToString());
                                            decimal res = (item["Computer"] == DBNull.Value ? 0 : Convert.ToInt32(item["Computer2"])) + (item["Computer1"] == DBNull.Value ? 0 : Convert.ToInt32(item["Computer1"])) + (item["Computer2"] == DBNull.Value ? 0 : Convert.ToInt32(item["Computer2"]));
                                            //multiplying computer with 2
                                            if (Convert.ToInt32(cmbClass.Text) == 5)
                                            {
                                                res = (res * 80) / 50;
                                            }
                                            else if (Convert.ToInt32(cmbClass.Text) == 6 || Convert.ToInt32(cmbClass.Text) == 7 || Convert.ToInt32(cmbClass.Text) == 8)
                                            {
                                                res = (res * 110) / 50;
                                            }

                                            wordApp.Selection.TypeText(res.ToString());
                                        }
                                    }
                                    
                                    

                                }
                                else if (fieldName == "gc")
                                {
                                    myMergeField.Select();
                                    if (item["Computer"] == DBNull.Value && item["Computer1"] == DBNull.Value && item["Computer2"] == DBNull.Value)
                                    {
                                        wordApp.Selection.TypeText(" ");
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(cmbClass.Text) == 5)
                                        {
                                            wordApp.Selection.TypeText(" ");
                                        }
                                        else
                                        {
                                            decimal res = (item["Computer"] == DBNull.Value ? 0 : Convert.ToInt32(item["Computer2"])) + (item["Computer1"] == DBNull.Value ? 0 : Convert.ToInt32(item["Computer1"])) + (item["Computer2"] == DBNull.Value ? 0 : Convert.ToInt32(item["Computer2"]));
                                            //multiplying computer with 2
                                            if(Convert.ToInt32(cmbClass.Text) == 5)
                                            {
                                                res = (res * 80) / 50;
                                            }
                                            else if (Convert.ToInt32(cmbClass.Text) == 6 || Convert.ToInt32(cmbClass.Text) == 7 || Convert.ToInt32(cmbClass.Text) == 8)
                                            {
                                                res = (res * 110) / 50;
                                            }
                                            
                                            wordApp.Selection.TypeText(GradeSelection(res));
                                        }
                                    }                                   
                                    

                                }
                                else if (fieldName == "ast")
                                {
                                    myMergeField.Select();
                                    if (item["PhysArt"] == DBNull.Value && item["PhysArt1"] == DBNull.Value && item["PhysArt2"] == DBNull.Value)
                                    {
                                        wordApp.Selection.TypeText(" ");
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(cmbClass.Text) == 5)
                                        {
                                            wordApp.Selection.TypeText(" ");
                                        }
                                        else
                                        {
                                            decimal res = (item["PhysArt"] == DBNull.Value ? 0 : Convert.ToInt32(item["PhysArt"])) + (item["PhysArt1"] == DBNull.Value ? 0 : Convert.ToInt32(item["PhysArt1"])) + (item["PhysArt2"] == DBNull.Value ? 0 : Convert.ToInt32(item["PhysArt2"]));
                                            wordApp.Selection.TypeText(res.ToString());
                                        }
                                    
                                    }
                                    

                                }
                                else if (fieldName == "ga")
                                {
                                    myMergeField.Select();
                                    if (item["PhysArt"] == DBNull.Value && item["PhysArt1"] == DBNull.Value && item["PhysArt2"] == DBNull.Value)
                                    {
                                        wordApp.Selection.TypeText(" ");
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(cmbClass.Text) == 5)
                                        {
                                            wordApp.Selection.TypeText(" ");
                                        }
                                        else
                                        {
                                            decimal res = (item["PhysArt"] == DBNull.Value ? 0 : Convert.ToInt32(item["PhysArt"])) + (item["PhysArt1"] == DBNull.Value ? 0 : Convert.ToInt32(item["PhysArt1"])) + (item["PhysArt2"] == DBNull.Value ? 0 : Convert.ToInt32(item["PhysArt2"]));
                                            wordApp.Selection.TypeText(GradeSelection(res));
                                        }
                                    }
                                    
                                    

                                }
                            }
                            else
                            {
                                #region Summative Total with No Data
                                if (fieldName == "1lst")
                                {
                                    myMergeField.Select();                                    
                                    wordApp.Selection.TypeText(" ");

                                }
                                else if (fieldName == "2lst")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");

                                }
                                else if (fieldName == "3rst")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");

                                }
                                else if (fieldName == "mst")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");

                                }
                                else if (fieldName == "sst")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");

                                }
                                else if (fieldName == "hst")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");


                                }
                                else if (fieldName == "gst")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");


                                }
                                else if (fieldName == "cst")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");

                                }
                                else if (fieldName == "ast")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");

                                }
                                else if (fieldName == "g1l")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");
                                }
                                else if (fieldName == "g2l")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");
                                }
                                else if (fieldName == "g3r")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");
                                }
                                else if (fieldName == "gm")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");
                                }
                                else if (fieldName == "gs")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");
                                }
                                else if (fieldName == "gh")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");
                                }
                                else if (fieldName == "gg")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");
                                }
                                else if (fieldName == "gc")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");
                                }
                                else if (fieldName == "ga")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");
                                }   

                                #endregion
                            }
                        }
                        #endregion
                        //Summative Total End

                    //Formative Result Start
                        #region Formative

                        #region unit 1
                        if (fieldName == "pf1")
                        {
                            myMergeField.Select();
                            if (item["Participation"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["Participation"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "qf1")
                        {
                            myMergeField.Select();
                            if (item["QuestionExperiment"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["QuestionExperiment"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "if1")
                        {
                            myMergeField.Select();
                            if (item["InterApplication"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["InterApplication"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "ef1")
                        {
                            myMergeField.Select();
                            if (item["EmpaCooperation"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["EmpaCooperation"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "cf1")
                        {
                            myMergeField.Select();
                            if (item["CreativeAesthe"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["CreativeAesthe"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        #endregion

                        #region unit 2
                        else if (fieldName == "pf2")
                        {
                            myMergeField.Select();
                            if (item["Participation1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["Participation1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "qf2")
                        {
                            myMergeField.Select();
                            if (item["QuestionExperiment1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["QuestionExperiment1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "if2")
                        {
                            myMergeField.Select();
                            if (item["InterApplication1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["InterApplication1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "ef2")
                        {
                            myMergeField.Select();
                            if (item["EmpaCooperation1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["EmpaCooperation1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "cf2")
                        {
                            myMergeField.Select();
                            if (item["CreativeAesthe1"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["CreativeAesthe1"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        #endregion

                        #region unit 3
                        else if (fieldName == "pf3")
                        {
                            myMergeField.Select();
                            if (item["Participation2"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["Participation2"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "qf3")
                        {
                            myMergeField.Select();
                            if (item["QuestionExperiment2"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["QuestionExperiment2"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "if3")
                        {
                            myMergeField.Select();
                            if (item["InterApplication2"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["InterApplication2"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "ef3")
                        {
                            myMergeField.Select();
                            if (item["EmpaCooperation2"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["EmpaCooperation2"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        else if (fieldName == "cf3")
                        {
                            myMergeField.Select();
                            if (item["CreativeAesthe2"] != DBNull.Value)
                            {
                                wordApp.Selection.TypeText(item["CreativeAesthe2"].ToString());
                            }
                            else
                            {
                                wordApp.Selection.TypeText(" ");
                            }
                        }
                        #endregion

                        #endregion
                        //Formative Result End
                        //Formative Total
                        if (item["StudentUnit"] != null)
                        {
                            //if (Convert.ToInt32(item["StudentUnit"]) == 3)
                            if (Convert.ToInt32(cmbUnit.Text) == 3)
                            {
                                # region formative total with data
                                if (fieldName == "pft")
                                {
                                    myMergeField.Select();
                                    int res = (item["Participation"] == DBNull.Value ? 0 : Convert.ToInt32(item["Participation"])) + (item["Participation1"] == DBNull.Value ? 0 : Convert.ToInt32(item["Participation1"])) + (item["Participation2"] == DBNull.Value ? 0 : Convert.ToInt32(item["Participation2"]));
                                    wordApp.Selection.TypeText(res.ToString());
                                }
                                else if (fieldName == "qft")
                                {
                                    myMergeField.Select();
                                    int res = (item["QuestionExperiment"] == DBNull.Value ? 0 : Convert.ToInt32(item["QuestionExperiment"])) + (item["QuestionExperiment1"] == DBNull.Value ? 0 : Convert.ToInt32(item["QuestionExperiment1"])) + (item["QuestionExperiment2"] == DBNull.Value ? 0 : Convert.ToInt32(item["QuestionExperiment2"]));
                                    wordApp.Selection.TypeText(res.ToString());

                                }
                                else if (fieldName == "ift")
                                {
                                    myMergeField.Select();
                                    int res = (item["InterApplication"] == DBNull.Value ? 0 : Convert.ToInt32(item["InterApplication"])) + (item["InterApplication1"] == DBNull.Value ? 0 : Convert.ToInt32(item["InterApplication1"])) + (item["InterApplication2"] == DBNull.Value ? 0 : Convert.ToInt32(item["InterApplication2"]));
                                    wordApp.Selection.TypeText(res.ToString());

                                }
                                else if (fieldName == "eft")
                                {
                                    myMergeField.Select();
                                    int res = (item["EmpaCooperation"] == DBNull.Value ? 0 : Convert.ToInt32(item["EmpaCooperation"])) + (item["EmpaCooperation1"] == DBNull.Value ? 0 : Convert.ToInt32(item["EmpaCooperation1"])) + (item["EmpaCooperation2"] == DBNull.Value ? 0 : Convert.ToInt32(item["EmpaCooperation2"]));
                                    wordApp.Selection.TypeText(res.ToString());

                                }
                                else if (fieldName == "cft")
                                {

                                    myMergeField.Select();
                                    int res = (item["CreativeAesthe"] == DBNull.Value ? 0 : Convert.ToInt32(item["CreativeAesthe"])) + (item["CreativeAesthe1"] == DBNull.Value ? 0 : Convert.ToInt32(item["CreativeAesthe1"])) + (item["CreativeAesthe2"] == DBNull.Value ? 0 : Convert.ToInt32(item["CreativeAesthe2"]));
                                    wordApp.Selection.TypeText(res.ToString());

                                }
                                #endregion
                            }
                            else
                            {
                                # region formative total with No data
                                if (fieldName == "pft")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");
                                }
                                else if (fieldName == "qft")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");

                                }
                                else if (fieldName == "ift")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");

                                }
                                else if (fieldName == "eft")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");

                                }
                                else if (fieldName == "cft")
                                {
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(" ");

                                }
                                #endregion
                            }
                        }


                    }

                }
                string docName = item["StudentRoll"] + "_" + item["StudentName"] + "_" + item["StudentClass"] + "_" + item["StudentSec"] + "_" + item["StudentRoll"] + ".doc";
                //wordDoc.SaveAs(item["StudentName"] + "_" + item["StudentClass"] + "_" + item["StudentSec"] + "_" + item["StudentRoll"] + ".doc");
                //wordApp.Documents.Open("myFile.doc");
                string stringNameUtil = string.Empty;
                string stringNameUtilFolder = string.Empty;
                stringNameUtilFolder = saveDocFolder(item["StudentClass"].ToString(), item["StudentSec"].ToString(), item["StudentUnit"].ToString(), "");
                stringNameUtil = saveDocFolder(item["StudentClass"].ToString(), item["StudentSec"].ToString(), item["StudentUnit"].ToString(), docName);
                if(isExist == "No")
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
        //22_12
        private string GradeSelection(decimal number)
        {
           int number1 = Convert.ToInt32(number);
            if(Convert.ToInt32(cmbClass.Text) == 5)
            {
                number1 = (number1 * 100) / 80;
            }
            else if(Convert.ToInt32(cmbClass.Text) == 6 || Convert.ToInt32(cmbClass.Text) == 7 || Convert.ToInt32(cmbClass.Text) == 8 )
            {
                number1 = (number1 * 100) / 110;
            }
            //string testNumber = number.ToString();
            //if (testNumber.Contains("5"))
            //{
            //    testNumber = testNumber.Replace(".5", "");
            //    int testIntNum = Convert.ToInt32(testNumber);
            //    number = testIntNum + 1;
            //}

            if (number1 < 25)
            {
                return "D";
            }
            else if (number1 >= 25 && number1 <= 44)
            {
                return "C";
            }
            else if (number1 >= 45 && number1 <= 59)
            {
                return "C+";
            }
            else if (number1 >= 60 && number1 <= 69)
            {
                return "B";
            }
            else if (number1 >= 70 && number1 <= 79)
            {
                return "B+";
            }
            else if (number1 >= 80 && number1 <= 89)
            {
                return "A";
            }
            else if (number1 >= 90 && number1 <= 100)
            {
                return "A+";
            }
            return " ";
        }

        public string saveDocFolder(string className, string sec, string unit, string docname)
        {
            //C:\Subha\G\code\School Project\Final_School_Result_windows\Result\Unit\1\class\5\sec

            string pathAndDoc = string.Empty;

            //pathAndDoc = pathAndDoc + @"C:\Subha\G\code\School Project\Final_School_Result_windows\Result\Unit";
            pathAndDoc = ConfigurationManager.AppSettings["ExtractPath"].ToString();
            pathAndDoc = pathAndDoc + "\\class\\" + className + "\\sec\\" + sec + "\\" + docname;

            return pathAndDoc;

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            this.Close();
            menu.Show();
        }

        private void ExtractResult_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            cmbClass.Items.Add(5);
            cmbClass.Items.Add(6);
            cmbClass.Items.Add(7);
            cmbClass.Items.Add(8);

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
