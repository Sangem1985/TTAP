using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class frmCommonAttachments : System.Web.UI.Page
    {
        General objDAL = new General();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        EnclosuresBO objBO = new EnclosuresBO();
        //string attachValue = "0";
        DataSet ds = new DataSet();

        //string IncentiveId = "123";
        //string createdby = "1";

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            try
            {
                //Session["IncentiveID"] = IncentiveId;
                DataSet dstap = new DataSet();
                DataTable dt = new DataTable();
                if (!IsPostBack)
                {
                    //dstap = objDAL.IncentiveEnclosures_ChecklistDB(Convert.ToInt32(createdby), Convert.ToInt32(IncentiveId));
                    //FillDetails(dstap);

                    TSIPASSSERVICE.DepartmentApprovalSystem tsipass = new TSIPASSSERVICE.DepartmentApprovalSystem();
                    string output = tsipass.GetdataCFEApprovaldocument("", Session["uid"].ToString());
                    StringReader str1 = new StringReader(output);
                    DataSet ds = new DataSet();
                    ds.ReadXml(str1);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        dt = ds.Tables[0];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string deptname = dt.Rows[i]["Dept_Full_name"].ToString();

                            if (deptname == "Factories")
                            {
                                ddlCSApprovalDirectorFactories.SelectedValue = "Y";
                                ddlCSApprovalDirectorFactories_SelectedIndexChanged(this, EventArgs.Empty);

                            }
                            if (deptname == "Boiler")
                            {
                                ddlCSBoilersCertificate.SelectedValue = "Y";

                                ddlCSBoilersCertificate_SelectedIndexChanged(this, EventArgs.Empty);

                            }
                            if (deptname == "Town and Country Planning")
                            {
                                ddlCSApprovalDirectorTownCountryPlanningUDA.SelectedValue = "Y";

                                ddlCSApprovalDirectorTownCountryPlanningUDA_SelectedIndexChanged(this, EventArgs.Empty);

                            }
                            if (deptname == "Panchayat Raj")
                            {
                                ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat.SelectedValue = "Y";

                                ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat_SelectedIndexChanged(this, EventArgs.Empty);

                            }

                            if (deptname == "Pollution Control Board")
                            {
                                ddlCSOperationTSPCBAcknowledgementGM.SelectedValue = "Y";

                                ddlCSOperationTSPCBAcknowledgementGM_SelectedIndexChanged(this, EventArgs.Empty);

                            }

                            if (deptname == "TSNPDCL" || deptname == "TSSPDCL")
                            {
                                ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM.SelectedValue = "Y";

                                ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM_SelectedIndexChanged(this, EventArgs.Empty);

                            }
                        }
                    }
                    //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    //{
                    //    DataTable table = ds.Tables[0];
                    //    string sen, sen1, sen2;

                    //    foreach (DataRow dr in table.Rows)
                    //    {
                    //        string attachmentid = dr["Dept_Full_name"].ToString();
                    //        sen2 = dr["link"].ToString();
                    //        sen1 = sen2.Replace(@"\", @"/");
                    //        sen = dr["link"].ToString();// sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                    //        if (attachmentid == "Factories")
                    //        {
                    //            HyperLink201.NavigateUrl = sen;
                    //            HyperLink201.Text = dr["FileName"].ToString(); // hyperlink 
                    //            Label201.Text = dr["FileName"].ToString();  // label                  

                    //            HyperLink201.Visible = true;
                    //            Label201.Visible = false;
                    //        }
                    //        //if (attachmentid == "30")
                    //        //{
                    //        //    HyperLink202.NavigateUrl = sen;
                    //        //    HyperLink202.Text = dr["FileNm"].ToString();  // hyperlink 
                    //        //    Label202.Text = dr["FileNm"].ToString();  // label                  

                    //        //    HyperLink202.Visible = true;
                    //        //    Label202.Visible = false;
                    //        //}
                    //        if (attachmentid == "Town and Country Planning")
                    //        {
                    //            HyperLink203.NavigateUrl = sen;
                    //            HyperLink203.Text = dr["FileName"].ToString(); // hyperlink 
                    //            Label203.Text = dr["FileName"].ToString();  // label                  

                    //            HyperLink203.Visible = true;
                    //            Label203.Visible = false;
                    //        }
                    //        if (attachmentid.Contains("Panchayat Raj"))
                    //        {
                    //            HyperLink204.NavigateUrl = sen;
                    //            HyperLink204.Text = dr["FileName"].ToString();  // hyperlink 
                    //            Label204.Text = dr["FileName"].ToString();  // label                  

                    //            HyperLink204.Visible = true;
                    //            Label204.Visible = false;
                    //        }
                    //        if (attachmentid == "Pollution Control Board")
                    //        {
                    //            HyperLink205.NavigateUrl = sen;
                    //            HyperLink205.Text = dr["FileName"].ToString();  // hyperlink 
                    //            Label205.Text = dr["FileName"].ToString();  // label                  

                    //            HyperLink205.Visible = true;
                    //            Label205.Visible = false;
                    //        }
                    //        if (attachmentid == "TSNPDCL" || attachmentid == "TSSPDCL")
                    //        {
                    //            HyperLink206.NavigateUrl = sen;
                    //            HyperLink206.Text = dr["FileName"].ToString();  // hyperlink 
                    //            Label206.Text = dr["FileName"].ToString();  // label                  

                    //            HyperLink206.Visible = true;
                    //            Label206.Visible = false;
                    //        }
                    //        // i++;


                    //    }
                    //}


                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        public void FillDetails(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlCSApprovalDirectorFactories.SelectedValue = ds.Tables[0].Rows[0]["CSApprovalDirectorFactories"].ToString().Trim();
                ddlCSBoilersCertificate.SelectedValue = ds.Tables[0].Rows[0]["CSBoilersCertificate"].ToString().Trim();
                ddlCSApprovalDirectorTownCountryPlanningUDA.SelectedValue = ds.Tables[0].Rows[0]["CSApprovalDirectorTownCountryPlanningUDA"].ToString().Trim();
                ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat.SelectedValue = ds.Tables[0].Rows[0]["CSRegularbuildingplansapprovalofMunicipalityGramPanchayat"].ToString().Trim();
                ddlCSOperationTSPCBAcknowledgementGM.SelectedValue = ds.Tables[0].Rows[0]["CSOperationTSPCBAcknowledgementGM"].ToString().Trim();
                ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM.SelectedValue = ds.Tables[0].Rows[0]["CSPowerreleaseCertificatefrmTSTRANSCODISCOM"].ToString().Trim();

                #region  " ddl selected change events"

                if (ddlCSApprovalDirectorFactories.SelectedValue == "Y")
                {
                    ddlCSApprovalDirectorFactories_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSBoilersCertificate.SelectedValue == "Y")
                {
                    ddlCSBoilersCertificate_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSApprovalDirectorTownCountryPlanningUDA.SelectedValue == "Y")
                {
                    ddlCSApprovalDirectorTownCountryPlanningUDA_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat.SelectedValue == "Y")
                {
                    ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSOperationTSPCBAcknowledgementGM.SelectedValue == "Y")
                {
                    ddlCSOperationTSPCBAcknowledgementGM_SelectedIndexChanged(this, EventArgs.Empty);
                }
                if (ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM.SelectedValue == "Y")
                {
                    ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM_SelectedIndexChanged(this, EventArgs.Empty);
                }

                #endregion

                //BtnSave.Enabled = false;

            }
            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                DataTable table = ds.Tables[1];
                string sen, sen1, sen2;

                foreach (DataRow dr in table.Rows)
                {
                    string attachmentid = dr["AttachmentId"].ToString();
                    sen2 = dr["link"].ToString();
                    sen1 = sen2.Replace(@"\", @"/");
                    sen = sen1.Replace(@"D:/TS-iPASSFinal/", "~/");

                    if (attachmentid == "29")
                    {
                        HyperLink201.NavigateUrl = sen;
                        HyperLink201.Text = dr["FileNm"].ToString(); // hyperlink 
                        Label201.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink201.Visible = true;
                        Label201.Visible = false;
                    }
                    if (attachmentid == "30")
                    {
                        HyperLink202.NavigateUrl = sen;
                        HyperLink202.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label202.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink202.Visible = true;
                        Label202.Visible = false;
                    }
                    if (attachmentid == "31")
                    {
                        HyperLink203.NavigateUrl = sen;
                        HyperLink203.Text = dr["FileNm"].ToString(); // hyperlink 
                        Label203.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink203.Visible = true;
                        Label203.Visible = false;
                    }
                    if (attachmentid == "32")
                    {
                        HyperLink204.NavigateUrl = sen;
                        HyperLink204.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label204.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink204.Visible = true;
                        Label204.Visible = false;
                    }
                    if (attachmentid == "33")
                    {
                        HyperLink205.NavigateUrl = sen;
                        HyperLink205.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label205.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink205.Visible = true;
                        Label205.Visible = false;
                    }
                    if (attachmentid == "34")
                    {
                        HyperLink206.NavigateUrl = sen;
                        HyperLink206.Text = dr["FileNm"].ToString();  // hyperlink 
                        Label206.Text = dr["FileNm"].ToString();  // label                  

                        HyperLink206.Visible = true;
                        Label206.Visible = false;
                    }

                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            int valid = 0;
            try
            {
                int i = Convert.ToInt32(ValidateFileUploads());
                if (i == 1)
                {
                    lblmsg0.Text = "<font color=Red>Please Upload Mandatory File Uploads</font></br>";
                    success.Visible = false;
                    Failure.Visible = true;
                    lblmsg0.Visible = true;
                }
                else
                {
                    AssignValuesToVosFromControls();
                    valid = objDAL.InsertCheckListDB(objBO);

                    if (valid >= 1)
                    {
                        string message = "alert('Checkslips Uploaded Successfully')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                        //BtnNext.Enabled = true;
                        //BtnSave.Enabled = false;
                    }
                    else
                    {
                        lblmsg0.Text = "<font color=Red>Submission Failed</font>";
                        success.Visible = false;
                        Failure.Visible = true;
                        //BtnNext.Visible = false;
                    }
                }

            }

            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        public int ValidateFileUploads()
        {
            int i = 0;

            if (ddlCSApprovalDirectorFactories.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label201.Text == "" || Label201.Text == null || Label201.Text == string.Empty)
                {
                    i = 1;
                }


            }
            if (ddlCSBoilersCertificate.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label202.Text == "" || Label202.Text == null || Label202.Text == string.Empty)
                {
                    i = 1;
                }

            }
            if (ddlCSApprovalDirectorTownCountryPlanningUDA.SelectedItem.Text.ToUpper() == "YES")
            {
                if (Label203.Text == "" || Label203.Text == null || Label203.Text == string.Empty)
                {
                    i = 1;
                }

            }

            if (ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label204.Text == "" || Label204.Text == null || Label204.Text == string.Empty)
                {
                    i = 1;
                }
            }
            if (ddlCSOperationTSPCBAcknowledgementGM.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label205.Text == "" || Label205.Text == null || Label205.Text == string.Empty)
                {
                    i = 1;
                }
            }


            if (ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM.SelectedItem.Text.ToUpper() == "YES")
            {

                if (Label206.Text == "" || Label206.Text == null || Label206.Text == string.Empty)
                {
                    i = 1;
                }
            }
            return i;
        }

        public void AssignValuesToVosFromControls()
        {
            try
            {
                objBO.CSCreatedBy = Convert.ToInt32(Session["uid"].ToString());
                objBO.CSIncentiveId = Convert.ToInt32(Session["IncentiveID"].ToString());
                objBO.CSApprovalDirectorFactories = ddlCSApprovalDirectorFactories.SelectedValue.Trim();
                objBO.CSBoilersCertificate = ddlCSBoilersCertificate.SelectedValue.Trim();
                objBO.CSApprovalDirectorTownCountryPlanningUDA = ddlCSApprovalDirectorTownCountryPlanningUDA.SelectedValue.Trim();
                objBO.CSRegularbuildingplansapprovalofMunicipalityGramPanchayat = ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat.SelectedValue.Trim();
                objBO.CSOperationTSPCBAcknowledgementGM = ddlCSOperationTSPCBAcknowledgementGM.SelectedValue.Trim();
                objBO.CSPowerreleaseCertificatefrmTSTRANSCODISCOM = ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM.SelectedValue.Trim();

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void ddlCSApprovalDirectorFactories_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSApprovalDirectorFactories.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload201.Visible = true;
                Button201.Visible = true;
                HyperLink201.Visible = true;
                Label201.Visible = false;
            }
            else
            {
                FileUpload201.Visible = false;
                Button201.Visible = false;
                HyperLink201.Visible = false;
                Label201.Visible = false;
            }

        }

        protected void ddlCSBoilersCertificate_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSBoilersCertificate.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload202.Visible = true;
                Button202.Visible = true;
                HyperLink202.Visible = true;
                Label202.Visible = false;
            }
            else
            {
                FileUpload202.Visible = false;
                Button202.Visible = false;
                HyperLink202.Visible = false;
                Label202.Visible = false;
            }
        }

        protected void ddlCSApprovalDirectorTownCountryPlanningUDA_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSApprovalDirectorTownCountryPlanningUDA.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload203.Visible = true;
                Button203.Visible = true;
                HyperLink203.Visible = true;
                Label203.Visible = false;
            }
            else
            {
                FileUpload203.Visible = false;
                Button203.Visible = false;
                HyperLink203.Visible = false;
                Label203.Visible = false;
            }

        }

        protected void ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSRegularbuildingplansapprovalofMunicipalityGramPanchayat.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload204.Visible = true;
                Button204.Visible = true;
                HyperLink204.Visible = true;
                Label204.Visible = false;
            }
            else
            {
                FileUpload204.Visible = false;
                Button204.Visible = false;
                HyperLink204.Visible = false;
                Label204.Visible = false;
            }

        }

        protected void ddlCSOperationTSPCBAcknowledgementGM_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Failure.Visible = false;
            if (ddlCSOperationTSPCBAcknowledgementGM.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload205.Visible = true;
                Button205.Visible = true;
                HyperLink205.Visible = true;
                Label205.Visible = false;
            }
            else
            {
                FileUpload205.Visible = false;
                Button205.Visible = false;
                HyperLink205.Visible = false;
                Label205.Visible = false;
            }

        }

        protected void ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  Failure.Visible = false;
            if (ddlCSPowerreleaseCertificatefrmTSTRANSCODISCOM.SelectedItem.Text.ToUpper() == "YES")
            {
                FileUpload206.Visible = true;
                Button206.Visible = true;
                HyperLink206.Visible = true;
                Label206.Visible = false;
            }
            else
            {
                FileUpload206.Visible = false;
                Button206.Visible = false;
                HyperLink206.Visible = false;
                Label206.Visible = false;
            }
        }

        protected void Button201_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload201.HasFile)
            {
                if ((FileUpload201.PostedFile != null) && (FileUpload201.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload201.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload201.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\29");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload201.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload201.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDAL.InsertEnclosures_DB(Session["IncentiveID"].ToString(), 29, sFileName, newPath, Session["uid"].ToString());
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label201.Text = FileUpload201.FileName;
                            //  Label201.Visible = true;
                            HyperLink201.NavigateUrl = path;
                            HyperLink201.Text = FileUpload201.FileName;
                            HyperLink201.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        DeleteFile(newPath + "\\" + sFileName);
                    }
                }
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = false;
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }

        protected void Button202_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload202.HasFile)
            {
                if ((FileUpload202.PostedFile != null) && (FileUpload202.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload202.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload202.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\30");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload202.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload202.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDAL.InsertEnclosures_DB(Session["IncentiveID"].ToString(), 30, sFileName, newPath, Session["uid"].ToString());
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label202.Text = FileUpload202.FileName;
                            // Label202.Visible = true;
                            HyperLink202.NavigateUrl = path;
                            HyperLink202.Text = FileUpload202.FileName;
                            HyperLink202.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        DeleteFile(newPath + "\\" + sFileName);
                    }
                }
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = false;
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }

        protected void Button203_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload203.HasFile)
            {
                if ((FileUpload203.PostedFile != null) && (FileUpload203.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload203.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload203.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\31");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload203.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload203.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }
                            objDAL.InsertEnclosures_DB(Session["IncentiveID"].ToString(), 31, sFileName, newPath, Session["uid"].ToString());
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label203.Text = FileUpload203.FileName;
                            // Label203.Visible = true;
                            HyperLink203.NavigateUrl = path;
                            HyperLink203.Text = FileUpload203.FileName;
                            HyperLink203.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        DeleteFile(newPath + "\\" + sFileName);
                    }
                }
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = false;
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }

        protected void Button204_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload204.HasFile)
            {
                if ((FileUpload204.PostedFile != null) && (FileUpload204.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload204.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload204.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\32");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload204.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload204.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDAL.InsertEnclosures_DB(Session["IncentiveID"].ToString(), 32, sFileName, newPath, Session["uid"].ToString());
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label204.Text = FileUpload204.FileName;
                            //Label204.Visible = true;
                            HyperLink204.NavigateUrl = path;
                            HyperLink204.Text = FileUpload204.FileName;
                            HyperLink204.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        DeleteFile(newPath + "\\" + sFileName);
                    }
                }
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = false;
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }

        protected void Button205_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload205.HasFile)
            {
                if ((FileUpload205.PostedFile != null) && (FileUpload205.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload205.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload205.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\33");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload205.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload205.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDAL.InsertEnclosures_DB(Session["IncentiveID"].ToString(), 33, sFileName, newPath, Session["uid"].ToString());
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label205.Text = FileUpload205.FileName;
                            // Label205.Visible = true;
                            HyperLink205.NavigateUrl = path;
                            HyperLink205.Text = FileUpload205.FileName;
                            HyperLink205.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        DeleteFile(newPath + "\\" + sFileName);
                    }
                }
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = false;
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
            }
        }

        protected void Button206_Click(object sender, EventArgs e)
        {
            string newPath = "";
            //string sFileDir = Server.MapPath("~\\Attachments");
            string sFileDir = Server.MapPath("~\\IncentivesAttachments");
            if (FileUpload206.HasFile)
            {
                if ((FileUpload206.PostedFile != null) && (FileUpload206.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload206.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload206.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            //Create a new subfolder under the current active folder
                            newPath = System.IO.Path.Combine(sFileDir, Session["IncentiveID"].ToString() + "\\34");

                            // Create the subfolder
                            if (!Directory.Exists(newPath))

                                System.IO.Directory.CreateDirectory(newPath);
                            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(newPath);
                            int count = dir.GetFiles().Length;
                            if (count == 0)
                                FileUpload206.PostedFile.SaveAs(newPath + "\\" + sFileName);
                            else
                            {
                                if (count == 1)
                                {
                                    string[] Files = Directory.GetFiles(newPath);

                                    foreach (string file in Files)
                                    {
                                        File.Delete(file);
                                    }
                                    FileUpload206.PostedFile.SaveAs(newPath + "\\" + sFileName);
                                }
                            }

                            objDAL.InsertEnclosures_DB(Session["IncentiveID"].ToString(), 34, sFileName, newPath, Session["uid"].ToString());
                            string path = newPath + "\\" + sFileName;
                            lblmsg.Text = "<font color='green'>Attachment Successfully Added..!</font>";
                            Label206.Text = FileUpload206.FileName;
                            //Label206.Visible = true;
                            HyperLink206.NavigateUrl = path;
                            HyperLink206.Text = FileUpload206.FileName;
                            HyperLink206.Visible = true;
                            //success.Visible = true;
                            //Failure.Visible = false;
                        }
                        else
                        {
                            lblmsg0.Text = "<font color='red'>Upload PDF,Doc,JPG, ZIP or RAR files only..!</font>";
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        DeleteFile(newPath + "\\" + sFileName);
                    }
                }
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = false;
                //  Response.Write("<script>alert('  ')</script> "); //+ fileType[1].Trim(); 
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

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncentiveCheckSlip.aspx?next=" + "N");
        }
        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncentiveFormTTap.aspx?Previous=" + "P");
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {

        }
    }
}