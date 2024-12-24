using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class frmConcessionsgsts : System.Web.UI.Page
    {
        General Gen = new General();
        static DataTable dtMyTableCertificate2;
        static DataTable dtMyTableCertificate4;
        ConcessionSGST objConcessionSGST = new ConcessionSGST();
        ClsFileUpload objClsFileUpload = new ClsFileUpload();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] != null)
            {
                Session["IncentiveID"] = "121";
                GetConcessionSGSTDetails(Session["uid"].ToString(), Session["IncentiveID"].ToString());

                //    if (Session["incentivedata"] != null)
                //    {
                //        string userid = Session["uid"].ToString();
                //        string IncentveID = Session["IncentiveID"].ToString();
                //        DataSet ds = new DataSet();
                //        ds = (DataSet)Session["incentivedata"];
                //        DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 6);
                //        if (drs.Length > 0)
                //        {
                //            //DataSet dsnew = new DataSet();
                //            //dsnew =

                //            GetConcessionSGSTDetails(userid, IncentveID);

                //            //dsnew = Gen.GetIncentivesISdata(IncentveID, "6");
                //            //Filldata(dsnew);
                //        }
                //        else
                //        {
                //            if (Request.QueryString[0].ToString() == "N")
                //            {
                //                Response.Redirect("frmAssistanceEnergy.aspx?next=" + "N");
                //            }
                //            else
                //            {
                //                Response.Redirect("frmStampDuty.aspx?Previous=" + "P");
                //            }
                //        }
                //    }
            }
        }


        public string GeneralInformationcheck()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (txtInstalledCapacity.Text.TrimStart().Trim() == "")
            {
                if (txtInstalledCapacity.Text.TrimStart().Trim() == "") ErrorMsg = ErrorMsg + slno + ". Please Enter Installedcapacity \\n";
                slno = slno + 1;
            }
            if (txtClaimApplication.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter ClaimApplication required \\n";
                slno = slno + 1;
            }
            if (txtTaxpaid.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter the Taxpaid  \\n";
                slno = slno + 1;
            }
            if (txtCurrentClaim.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter CurrentClaim1 \\n";
                slno = slno + 1;
            }

            return ErrorMsg;
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmAssistanceEnergy.aspx?next=" + "N");
        }

        protected void btnclear_Click(object sender, EventArgs e)
        {

        }

        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmStampDuty.aspx?Previous=" + "P");
        }

        public void GetConcessionSGSTDetails(string uid, string IncentiveID)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@created_BY",SqlDbType.Int),
                    new SqlParameter("@IncentiveID",SqlDbType.Int)
                };
                p[0].Value = uid;
                p[1].Value = IncentiveID;
                ds = Gen.GenericFillDs("USP_GET_CONCESSIONSGST", p);
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.ToString() != "" && ds.Tables[0].Rows.ToString() != null)
                {
                    txtInstalledCapacity.Text = ds.Tables[0].Rows[0]["Installedcapacity"].ToString();
                    txtClaimApplication.Text = ds.Tables[0].Rows[0]["ClaimApplication"].ToString();
                    txtTaxpaid.Text = ds.Tables[0].Rows[0]["Taxpaid"].ToString();
                    txtCurrentClaim.Text = ds.Tables[0].Rows[0]["CurrentClaim1"].ToString();
                    txtYear1.Text = ds.Tables[0].Rows[0]["Year1"].ToString();
                    txtYear2.Text = ds.Tables[0].Rows[0]["Year2"].ToString();
                    txtYear3.Text = ds.Tables[0].Rows[0]["Year3"].ToString();
                    txtEnterprises1.Text = ds.Tables[0].Rows[0]["Enterprises1"].ToString();
                    txtEnterprises2.Text = ds.Tables[0].Rows[0]["Enterprises2"].ToString();
                    txtEnterprises3.Text = ds.Tables[0].Rows[0]["Enterprises3"].ToString();
                    txthalfyear1.Text = ds.Tables[0].Rows[0]["HalfYear1"].ToString();
                    txtToatalproduction1.Text = ds.Tables[0].Rows[0]["TotalProduction1"].ToString();
                    txtToatalproduction2.Text = ds.Tables[0].Rows[0]["TotalProduction2"].ToString();
                    txtToatalproduction3.Text = ds.Tables[0].Rows[0]["TotalProduction3"].ToString();
                    txtTotal.Text = ds.Tables[0].Rows[0]["Total"].ToString();
                    txtHalfyear11.Text = ds.Tables[0].Rows[0]["HalfYear11"].ToString();
                    txtHalfyear2.Text = ds.Tables[0].Rows[0]["HalfYear2"].ToString();
                    txtHalfyear22.Text = ds.Tables[0].Rows[0]["HalfYear22"].ToString();
                    txthalfyear3.Text = ds.Tables[0].Rows[0]["HalfYear3"].ToString();
                    txthalfyear33.Text = ds.Tables[0].Rows[0]["HalfYear33"].ToString();
                    txthalfYear44.Text = ds.Tables[0].Rows[0]["HalfYear4"].ToString();

                    txthalfyear4.Text = ds.Tables[0].Rows[0]["HalfYear44"].ToString();





                }

                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    try
                    {
                        int RowsCount = ds.Tables[1].Rows.Count;
                        string Path, Docid;
                        for (int i = 0; i < RowsCount; i++)
                        {
                            Path = ds.Tables[1].Rows[i]["link"].ToString();
                            Docid = ds.Tables[1].Rows[i]["AttachmentId"].ToString();
                            if (!string.IsNullOrEmpty(Path))
                            {
                                if (Docid == "61001")
                                {
                                    objClsFileUpload.AssignPath(hySaleInvoice, Path);
                                }
                                else if (Docid == "61002")
                                {
                                    objClsFileUpload.AssignPath(hypconcernedCTo, Path);
                                }
                                else if (Docid == "61003")
                                {
                                    objClsFileUpload.AssignPath(hyroductionParticulars, Path);
                                }
                                else if (Docid == "61004")
                                {
                                    objClsFileUpload.AssignPath(hyTSPCBOperation, Path);
                                }


                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

                //if (ds.Tables[1].Rows.Count > 0 && ds.Tables[1].Rows.Count.ToString() != "" && ds.Tables[1].Rows.Count.ToString() != null)
                //{
                //    int c = ds.Tables[1].Rows.Count;
                //    string sen, sen1, sen2, senid;

                //    int i = 0;


                //    DataTable dt1 = new DataTable();
                //    dt1.Columns.Add("link");
                //    dt1.Columns.Add("FileName");

                //    DataTable dt2 = new DataTable();
                //    dt2.Columns.Add("link");
                //    dt2.Columns.Add("FileName");

                //    while (i < c)
                //    {
                //        senid = ds.Tables[1].Rows[i][0].ToString();
                //        sen2 = ds.Tables[1].Rows[i][1].ToString();
                //        sen1 = sen2.Replace(@"\", @"/");
                //        sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");//sen1.Replace(@"E:/Newfloder(2)\", "~/");

                //        if (senid.Contains("61001"))
                //        {
                //            hySaleInvoice.NavigateUrl = sen;
                //            hySaleInvoice.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblSaleInvoice.Text = ds.Tables[1].Rows[i][1].ToString();

                //            lblSaleInvoice.Visible = false;

                //        }
                //        if (senid.Contains("61002"))
                //        {
                //            hypconcernedCTo.NavigateUrl = sen;
                //            hypconcernedCTo.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblconcernedCTo.Text = ds.Tables[1].Rows[i][1].ToString();

                //            lblconcernedCTo.Visible = false;

                //        }


                //        if (senid.Contains("61003"))
                //        {
                //            hyroductionParticulars.NavigateUrl = sen;
                //            hyroductionParticulars.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblroductionParticulars.Text = ds.Tables[1].Rows[i][1].ToString();

                //            lblroductionParticulars.Visible = false;

                //        }


                //        if (senid.Contains("61004"))
                //        {
                //            hyTSPCBOperation.NavigateUrl = sen;
                //            hyTSPCBOperation.Text = ds.Tables[1].Rows[i][1].ToString();
                //            lblTSPCBOperation.Text = ds.Tables[1].Rows[i][1].ToString();

                //            lblTSPCBOperation.Visible = false;

                //        }




                //        i++;
                //    }

                //}


            }
            catch (Exception ex)
            {

                throw ex;
            }

            //return ds;
        }
        public int InsertTTAPAttachments(string Incentiveid, string AttachmentFilename, string AttachmentFilePath, string Created_by, int attachmentid)
        {
            try
            {

                string str = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;

                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlDataAdapter myDataAdapter;

                myDataAdapter = new SqlDataAdapter("USP_INS_TTapAttachments", con);
                myDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;


                if (Incentiveid == null || Incentiveid == " ")
                {
                    myDataAdapter.SelectCommand.Parameters.Add("@IncentiveID", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    myDataAdapter.SelectCommand.Parameters.Add("@IncentiveID", SqlDbType.VarChar).Value = Incentiveid;
                }

                if (AttachmentFilename.Trim() == "" || AttachmentFilename.Trim() == null || AttachmentFilename.Trim() == "--Select--")
                {
                    myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    myDataAdapter.SelectCommand.Parameters.Add("@FileName", SqlDbType.VarChar).Value = AttachmentFilename.Trim();
                }

                if (AttachmentFilePath.Trim() == "" || AttachmentFilePath.Trim() == null || AttachmentFilePath.Trim() == "--Select--")
                {
                    myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    myDataAdapter.SelectCommand.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = AttachmentFilePath.Trim();
                }

                if (attachmentid == 0 || attachmentid == null)
                {
                    myDataAdapter.SelectCommand.Parameters.Add("@Attachmentid", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    myDataAdapter.SelectCommand.Parameters.Add("@Attachmentid", SqlDbType.VarChar).Value = Convert.ToInt32(attachmentid);
                }


                if (Created_by == "" || Created_by == null)
                {
                    myDataAdapter.SelectCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    myDataAdapter.SelectCommand.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = Convert.ToInt64(Created_by);
                }
                myDataAdapter.SelectCommand.Parameters.Add("@Result", SqlDbType.VarChar, 500);
                myDataAdapter.SelectCommand.Parameters["@Result"].Direction = ParameterDirection.Output;

                int n = myDataAdapter.SelectCommand.ExecuteNonQuery();


                if (n > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {

                throw ex;

            }
            finally
            {
            }
        }


        protected void btnSaleInvoice_Click(object sender, EventArgs e)
        {
            //string newPath = "";
            ////string sFileDir = Server.MapPath("~\\Attachments");
            ////string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            //string sFileDir = Server.MapPath("~\\IncentivesAttachmentsNew");
            //General t1 = new General();
            //if (fuSaleInvoice.HasFile)
            //{
            //    if ((fuSaleInvoice.PostedFile != null) && (fuSaleInvoice.PostedFile.ContentLength > 0))
            //    {
            //        string sFileName = System.IO.Path.GetFileName(fuSaleInvoice.PostedFile.FileName);
            //        try
            //        {
            //            string[] fileType = fuSaleInvoice.PostedFile.FileName.Split('.');
            //            int i = fileType.Length;
            //            if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
            //            {
            //                //Create a new subfolder under the current active folder
            //                newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\61001");

            //                // Create the subfolder
            //                if (!Directory.Exists(newPath))

            //                    System.IO.Directory.CreateDirectory(newPath);
            //                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
            //                int count = dir.GetFiles().Length;
            //                if (count == 0)
            //                    fuSaleInvoice.PostedFile.SaveAs(newPath + "\\" + sFileName);
            //                else
            //                {
            //                    if (count == 1)
            //                    {
            //                        string[] Files = Directory.GetFiles(newPath);

            //                        foreach (string file in Files)
            //                        {
            //                            File.Delete(file);
            //                        }
            //                        fuSaleInvoice.PostedFile.SaveAs(newPath + "\\" + sFileName);
            //                    }
            //                }
            //                int result = 0;
            //                result = InsertTTAPAttachments(Session["IncentiveID"].ToString(), sFileName, newPath, Session["uid"].ToString(), 61001);


            //                if (result > 0)
            //                {
            //                    lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
            //                    hySaleInvoice.Text = fuSaleInvoice.FileName;
            //                    lblSaleInvoice.Text = fuSaleInvoice.FileName;
            //                    lblSaleInvoice.Visible = false;
            //                    hySaleInvoice.Visible = true;
            //                }

            //                else
            //                {
            //                    lblmsg.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
            //                    lblmsg.Visible = false;
            //                    lblmsg.Visible = true;
            //                }



            //            }

            //        }
            //        catch (Exception)//in case of an error
            //        {
            //            DeleteFile(newPath + "\\" + sFileName);
            //        }
            //    }
            //}
            //else
            //{
            //    lblmsg.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            //    lblmsg.Visible = false;
            //    lblmsg.Visible = true;
            //    //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            //}

            if (fuSaleInvoice.HasFile)
            {
                string Mimetype = objClsFileUpload.getmimetype(fuSaleInvoice);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuSaleInvoice, hySaleInvoice, "First Sale Invoice", Session["IncentiveID"].ToString(), "6", "61001", Session["uid"].ToString(), "USER");

                    if (OutPut == "1")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
        }

        public void DeleteFile(string strFileName)
        {//Delete file from the server
            if (strFileName.Trim().Length > 0)
            {
                FileInfo fi = new FileInfo(strFileName);
                if (fi.Exists)//if file exists delete it
                {
                    fi.Delete();
                }
            }
        }

        protected void btnconcernedCTo_Click(object sender, EventArgs e)
        {
            //string newPath = "";
            ////string sFileDir = Server.MapPath("~\\Attachments");
            ////string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            //string sFileDir = Server.MapPath("~\\IncentivesAttachmentsNew");
            //General t1 = new General();
            //if (fuconcernedCTo.HasFile)
            //{
            //    if ((fuconcernedCTo.PostedFile != null) && (fuconcernedCTo.PostedFile.ContentLength > 0))
            //    {
            //        string sFileName = System.IO.Path.GetFileName(fuconcernedCTo.PostedFile.FileName);
            //        try
            //        {
            //            string[] fileType = fuconcernedCTo.PostedFile.FileName.Split('.');
            //            int i = fileType.Length;
            //            if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
            //            {
            //                //Create a new subfolder under the current active folder
            //                newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\61002");

            //                // Create the subfolder
            //                if (!Directory.Exists(newPath))

            //                    System.IO.Directory.CreateDirectory(newPath);
            //                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
            //                int count = dir.GetFiles().Length;
            //                if (count == 0)
            //                    fuconcernedCTo.PostedFile.SaveAs(newPath + "\\" + sFileName);
            //                else
            //                {
            //                    if (count == 1)
            //                    {
            //                        string[] Files = Directory.GetFiles(newPath);

            //                        foreach (string file in Files)
            //                        {
            //                            File.Delete(file);
            //                        }
            //                        fuconcernedCTo.PostedFile.SaveAs(newPath + "\\" + sFileName);
            //                    }
            //                }
            //                int result = 0;
            //                result = InsertTTAPAttachments(Session["IncentiveID"].ToString(), sFileName, newPath, Session["uid"].ToString(), 61002);


            //                if (result > 0)
            //                {
            //                    lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
            //                    hypconcernedCTo.Text = fuconcernedCTo.FileName;
            //                    lblconcernedCTo.Text = fuconcernedCTo.FileName;
            //                    lblconcernedCTo.Visible = false;
            //                    hypconcernedCTo.Visible = true;
            //                }

            //                else
            //                {
            //                    lblmsg.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
            //                    lblmsg.Visible = false;
            //                    lblmsg.Visible = true;
            //                }



            //            }

            //        }
            //        catch (Exception)//in case of an error
            //        {
            //            DeleteFile(newPath + "\\" + sFileName);
            //        }
            //    }
            //}
            //else
            //{
            //    lblmsg.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            //    lblmsg.Visible = false;
            //    lblmsg.Visible = true;
            //    //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            //}

            if (fuconcernedCTo.HasFile)
            {
                string Mimetype = objClsFileUpload.getmimetype(fuconcernedCTo);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuconcernedCTo, hypconcernedCTo, "Certificate from concerned CTO as prescribed at Form No A", Session["IncentiveID"].ToString(), "6", "61002", Session["uid"].ToString(), "USER");

                    if (OutPut == "1")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
        }

        protected void btnproductionParticulars_Click(object sender, EventArgs e)
        {
            //string newPath = "";
            ////string sFileDir = Server.MapPath("~\\Attachments");
            ////string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            //string sFileDir = Server.MapPath("~\\IncentivesAttachmentsNew");
            //General t1 = new General();
            //if (fuProductionParticulars.HasFile)
            //{
            //    if ((fuProductionParticulars.PostedFile != null) && (fuProductionParticulars.PostedFile.ContentLength > 0))
            //    {
            //        string sFileName = System.IO.Path.GetFileName(fuProductionParticulars.PostedFile.FileName);
            //        try
            //        {
            //            string[] fileType = fuProductionParticulars.PostedFile.FileName.Split('.');
            //            int i = fileType.Length;
            //            if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
            //            {
            //                //Create a new subfolder under the current active folder
            //                newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\61003");

            //                // Create the subfolder
            //                if (!Directory.Exists(newPath))

            //                    System.IO.Directory.CreateDirectory(newPath);
            //                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
            //                int count = dir.GetFiles().Length;
            //                if (count == 0)
            //                    fuProductionParticulars.PostedFile.SaveAs(newPath + "\\" + sFileName);
            //                else
            //                {
            //                    if (count == 1)
            //                    {
            //                        string[] Files = Directory.GetFiles(newPath);

            //                        foreach (string file in Files)
            //                        {
            //                            File.Delete(file);
            //                        }
            //                        fuProductionParticulars.PostedFile.SaveAs(newPath + "\\" + sFileName);
            //                    }
            //                }
            //                int result = 0;
            //                result = InsertTTAPAttachments(Session["IncentiveID"].ToString(), sFileName, newPath, Session["uid"].ToString(), 61003);


            //                if (result > 0)
            //                {
            //                    lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
            //                    hyroductionParticulars.Text = fuProductionParticulars.FileName;
            //                    lblroductionParticulars.Text = fuProductionParticulars.FileName;
            //                    lblroductionParticulars.Visible = false;
            //                    hyroductionParticulars.Visible = true;
            //                }

            //                else
            //                {
            //                    lblmsg.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
            //                    lblmsg.Visible = false;
            //                    lblmsg.Visible = true;
            //                }



            //            }

            //        }
            //        catch (Exception)//in case of an error
            //        {
            //            DeleteFile(newPath + "\\" + sFileName);
            //        }
            //    }
            //}
            //else
            //{
            //    lblmsg.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            //    lblmsg.Visible = false;
            //    lblmsg.Visible = true;
            //    //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            //}

            if (fuProductionParticulars.HasFile)
            {
                string Mimetype = objClsFileUpload.getmimetype(fuProductionParticulars);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuProductionParticulars, hyroductionParticulars, "Production Particulars for the last 3 years", Session["IncentiveID"].ToString(), "6", "61003", Session["uid"].ToString(), "USER");

                    if (OutPut == "1")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }


        protected void btnTSPCBOperation_Click(object sender, EventArgs e)
        {
            //string newPath = "";
            ////string sFileDir = Server.MapPath("~\\Attachments");
            ////string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            //string sFileDir = Server.MapPath("~\\IncentivesAttachmentsNew");
            //General t1 = new General();
            //if (fuTSPCBOperation.HasFile)
            //{
            //    if ((fuTSPCBOperation.PostedFile != null) && (fuTSPCBOperation.PostedFile.ContentLength > 0))
            //    {
            //        string sFileName = System.IO.Path.GetFileName(fuTSPCBOperation.PostedFile.FileName);
            //        try
            //        {
            //            string[] fileType = fuTSPCBOperation.PostedFile.FileName.Split('.');
            //            int i = fileType.Length;
            //            if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
            //            {
            //                //Create a new subfolder under the current active folder
            //                newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\61004");

            //                // Create the subfolder
            //                if (!Directory.Exists(newPath))

            //                    System.IO.Directory.CreateDirectory(newPath);
            //                System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
            //                int count = dir.GetFiles().Length;
            //                if (count == 0)
            //                    fuTSPCBOperation.PostedFile.SaveAs(newPath + "\\" + sFileName);
            //                else
            //                {
            //                    if (count == 1)
            //                    {
            //                        string[] Files = Directory.GetFiles(newPath);

            //                        foreach (string file in Files)
            //                        {
            //                            File.Delete(file);
            //                        }
            //                        fuTSPCBOperation.PostedFile.SaveAs(newPath + "\\" + sFileName);
            //                    }
            //                }
            //                int result = 0;
            //                result = InsertTTAPAttachments(Session["IncentiveID"].ToString(), sFileName, newPath, Session["uid"].ToString(), 61004);


            //                if (result > 0)
            //                {
            //                    lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
            //                    hyTSPCBOperation.Text = fuTSPCBOperation.FileName;
            //                    lblTSPCBOperation.Text = fuTSPCBOperation.FileName;
            //                    lblTSPCBOperation.Visible = false;
            //                    hyTSPCBOperation.Visible = true;
            //                }

            //                else
            //                {
            //                    lblmsg.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
            //                    lblmsg.Visible = false;
            //                    lblmsg.Visible = true;
            //                }



            //            }

            //        }
            //        catch (Exception)//in case of an error
            //        {
            //            DeleteFile(newPath + "\\" + sFileName);
            //        }
            //    }
            //}
            //else
            //{
            //    lblmsg.Text = "<font color='red'>Please Select a file To Upload..!</font>";
            //    lblmsg.Visible = false;
            //    lblmsg.Visible = true;
            //    //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            //}

            if (fuTSPCBOperation.HasFile)
            {
                string Mimetype = objClsFileUpload.getmimetype(fuTSPCBOperation);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuTSPCBOperation, hyTSPCBOperation, "Valid Consent for Operation CFO from TSPCB Acknowledgement from General Manager", Session["IncentiveID"].ToString(), "6", "61004", Session["uid"].ToString(), "USER");

                    if (OutPut == "1")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
        }

        public bool save()
        {
            try
            {



                AssignValuestoVosFromcontrols();

                string validsss = Gen.InsertConcessionSGST(objConcessionSGST);

                if (validsss == "1")
                {

                    lblmsg.Text = "Submitted Successfully";
                    lblmsg.Visible = true;

                }

            }
            catch (Exception ex)
            {

                lblmsg.Text = ex.Message;
                lblmsg.Visible = true;
            }

            return true;
        }


        public void AssignValuestoVosFromcontrols()
        {
            try
            {

                objConcessionSGST.insentiveid = "111";
                objConcessionSGST.Installedcapacity = txtInstalledCapacity.Text;
                objConcessionSGST.ClaimApplication = txtClaimApplication.Text;
                objConcessionSGST.Taxpaid = txtTaxpaid.Text;
                objConcessionSGST.CurrentClaim1 = txtCurrentClaim.Text;
                objConcessionSGST.Year1 = txtYear1.Text;
                objConcessionSGST.Year2 = txtYear2.Text;
                objConcessionSGST.Year3 = txtYear3.Text;
                objConcessionSGST.Enterprises1 = txtEnterprises1.Text;
                objConcessionSGST.Enterprises2 = txtEnterprises2.Text;
                objConcessionSGST.Enterprises3 = txtEnterprises3.Text;
                objConcessionSGST.ToatlProduction1 = txtToatalproduction1.Text;
                objConcessionSGST.ToatlProduction2 = txtToatalproduction2.Text;
                objConcessionSGST.ToatlProduction3 = txtToatalproduction3.Text;
                objConcessionSGST.HalfYear1 = txthalfyear1.Text;
                objConcessionSGST.HalfYear11 = txtHalfyear11.Text;
                objConcessionSGST.HalfYear2 = txtHalfyear2.Text;
                objConcessionSGST.HalfYear22 = txtHalfyear22.Text;
                objConcessionSGST.HalfYear3 = txthalfyear3.Text;
                objConcessionSGST.HalfYear33 = txthalfyear33.Text;
                objConcessionSGST.HalfYear4 = txthalfyear4.Text;
                objConcessionSGST.HalfYear44 = txthalfYear44.Text;
                objConcessionSGST.Total = txtTotal.Text;

                objConcessionSGST.createdby = Session["uid"].ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BtnSave1_Click(object sender, EventArgs e)
        {
            string errormsg = GeneralInformationcheck();

            if (lblSaleInvoice.Text != "" && lblconcernedCTo.Text != "" && lblroductionParticulars.Text != "" && lblTSPCBOperation.Text != "")
            {
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                save();

            }
            else
            {
                Failure.Visible = true;
                lblmsg.Visible = true;
                lblmsg.Text = "Please upload Mandatory Document(s).";

            }
        }
    }
}