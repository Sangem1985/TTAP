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

namespace eTicketingSystem.UI.Pages.Helpdesk
{
    public partial class RaiseHelpDesk : System.Web.UI.Page
    {
        CAFClass Objret = new CAFClass();
        static DataTable dtMyTableCertificate;
        static DataTable dtMyTable;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Page.Form.Attributes.Add("enctype", "multipart/form-data");
                //ScriptManager.GetCurrent(this).RegisterPostBackControl(Button8);

                if (Session.Count <= 0)
                {
                    Response.Redirect("~/LoginReg.aspx");
                }

                UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
                ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];


                if (!IsPostBack)
                {
                    //if (ObjLoginvo.userlevel == "1")
                    //{
                    //    ehome.HRef = "~/ApplicantDashBaord.aspx";
                    //}
                    //else if (ObjLoginvo.userlevel == "2")
                    //{
                    //    ehome.HRef = "~/HdDashBoard.aspx";
                    //}
                    //else if (ObjLoginvo.userlevel == "13")
                    //{
                    //    ehome.HRef = "~/UI/Pages/frmDashBoard.aspx";
                    //}
                    
                    BindApplicationDetails();
                    DataSet dsuserdata = new DataSet();

                    dsuserdata = GetUserData(ObjLoginvo.uid, ObjLoginvo.userlevel);
                    if (dsuserdata != null && dsuserdata.Tables.Count > 0 && dsuserdata.Tables[0].Rows.Count > 0)
                    {
                        lblapplicantname.InnerHtml = dsuserdata.Tables[0].Rows[0]["ApplciantName"].ToString(); //ObjLoginvo.LastName + " " + ObjLoginvo.FirstName;
                                                                                                               //lblusername.Text = dsuserdata.Tables[0].Rows[0]["User_id"].ToString(); //ObjLoginvo.username;
                        lblUnitname.InnerHtml = dsuserdata.Tables[0].Rows[0]["District_Name"].ToString(); //ObjLoginvo.UnitName;
                        lblMandal.InnerHtml = dsuserdata.Tables[0].Rows[0]["Manda_lName"].ToString();
                        tdunitdeptname.InnerHtml = "District";

                        if (ObjLoginvo.Role_Code == "USER")
                        {
                            //if (ddlApplication.Items.FindByText(ObjLoginvo.Application_Name) != null)
                            //{
                            //    ddlApplication.SelectedIndex = ddlApplication.Items.IndexOf(ddlApplication.Items.FindByText(ObjLoginvo.Application_Name));
                            //    ddlApplication.Enabled = false;
                            //}
                        }
                        else if (ObjLoginvo.Role_Code == "ADPP")
                        {
                            divPriorityInput.Visible = true;
                        }
                    }

                    dtMyTableCertificate = createtablecrtificate();
                    Session["CertificateTb2"] = dtMyTableCertificate;
                    DataSet ds = new DataSet();
                    ds = GetApplicationNo("HDID", ObjLoginvo.uid, "0", "New");
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["Hd_Id"] = ds.Tables[0].Rows[0]["Hd_Id"].ToString();
                        ViewState["Hd_Sub_Id"] = ds.Tables[0].Rows[0]["Hd_Sub_Id"].ToString();
                    }

                    DataSet dsfeed = new DataSet();

                    dsfeed = GeFeedbacktypes();
                    if (dsfeed != null && dsfeed.Tables.Count > 0 && dsfeed.Tables[0].Rows.Count > 0)
                    {
                        ddlfeedback.DataSource = dsfeed.Tables[0].DefaultView;
                        ddlfeedback.DataTextField = "Fb_Type";
                        ddlfeedback.DataValueField = "intfb_id";
                        ddlfeedback.DataBind();
                        AddSelect(ddlfeedback);
                    }

                    if (Request.QueryString.Count > 0)
                    {
                        if (Request.QueryString["AGAIN"] == "AGAIN")
                        {
                            ds = GetapplicationDtlsOld(Request.QueryString["OldHd_Id"].ToString(), ObjLoginvo.uid, Request.QueryString["OldHd_Sub_Id"].ToString(), "VIEW");
                            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                            {
                                if (ds.Tables[0].Rows[0]["FeedBackType"].ToString() != "")
                                {
                                    ddlfeedback.SelectedValue = ds.Tables[0].Rows[0]["FeedBackType"].ToString();
                                    ddlfeedback.Enabled = false;
                                }
                                else
                                {
                                    ddlfeedback.Enabled = true;
                                }

                                if (ds.Tables[0].Rows[0]["GroupID"].ToString() != "")
                                {
                                    ddlModule.SelectedValue = ds.Tables[0].Rows[0]["GroupID"].ToString();
                                    ddlModule.Enabled = false;
                                    ddlModule_SelectedIndexChanged(sender, e);
                                }
                                else
                                {
                                    ddlModule.Enabled = true;
                                }

                                if (ds.Tables[0].Rows[0]["Module_Code"].ToString() != "")
                                {
                                    ddlSubModule.SelectedValue = ds.Tables[0].Rows[0]["Module_Code"].ToString();
                                    ddlSubModule.Enabled = false;
                                }
                                else
                                {
                                    ddlSubModule.Enabled = true;
                                }

                                txtMobileno.Text = ds.Tables[0].Rows[0]["MobileNumber"].ToString();

                            }

                            string Viewbutton = ds.Tables[0].Rows[0]["Viewbutton"].ToString();
                            if (Viewbutton == "N")
                            {
                                string HDID_CURRENTOPEND = ds.Tables[0].Rows[0]["HDID_CURRENTOPEND"].ToString();
                                string SUBHDID_CURRENTOPEND = ds.Tables[0].Rows[0]["SUBHDID_CURRENTOPEND"].ToString();

                                BtnSave.Visible = false;
                                BtnClosebatchClear.Visible = false;
                                Response.Redirect("~/UI/HelpdeskSolution.aspx?Hd_Id=" + HDID_CURRENTOPEND + "&SubHDID=" + SUBHDID_CURRENTOPEND + "&UserId=" + ObjLoginvo.uid + "&ViewType=VIEW");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                string UID = "0";
                if (Session["uid"] != null)
                {
                    UID = Session["uid"].ToString();
                }
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, UID);
            }
        }
        public void AddSelect(DropDownList ddl)
        {
            try
            {
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                //lblmsg0.Text = ex.Message;
                //Failure.Visible = true;
                //success.Visible = false;
            }
        }
        public DataSet GetApplicationNo(string TYPE, string USERID, string PREREQID, string REQUESTYPE)
        {
            DataSet Dsnew = new DataSet();
            try
            {


                SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@TYPE",SqlDbType.VarChar),
               new SqlParameter("@USERID",SqlDbType.VarChar),
               new SqlParameter("@PREREQID",SqlDbType.VarChar),
               new SqlParameter("@REQUESTYPE",SqlDbType.VarChar),
           };
                pp[0].Value = TYPE;
                pp[1].Value = USERID;
                pp[2].Value = PREREQID;
                pp[3].Value = REQUESTYPE;
                Dsnew = Objret.GenericFillDs("USP_GET_HDSLNO", pp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Dsnew;
        }

        public DataSet GetapplicationDtlsOld(string Hd_Id, string UserName, string SubHDID, string ViewType)
        {
            DataSet Dsnew = new DataSet();
            try
            {
                SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@Hd_Id",SqlDbType.VarChar),
               new SqlParameter("@USERID",SqlDbType.VarChar),
               new SqlParameter("@SubHDID",SqlDbType.VarChar),
               new SqlParameter("@ViewType",SqlDbType.VarChar)

               };
                pp[0].Value = Hd_Id;
                pp[1].Value = UserName;
                pp[2].Value = SubHDID;
                pp[3].Value = ViewType;
                Dsnew = Objret.GenericFillDs("USP_GET_RAISED_HD_USER_DTLS", pp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Dsnew;
        }

        public DataSet GeFeedbacktypes()
        {
            DataSet Dsnew = new DataSet();
            try
            {

                Dsnew = Objret.GenericFillDs("[USP_GET_FEEDBACKTYPES]");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Dsnew;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string errormsg = GeneralInformationcheck();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
                    ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    HdClassVo HdVo = new HdClassVo();

                    HdVo.Created_by = ObjLoginvo.uid;
                    HdVo.Sysip = getclientIP();
                    HdVo.Hd_Id = ViewState["Hd_Id"].ToString();
                    HdVo.Hd_Sub_Id = ViewState["Hd_Sub_Id"].ToString();
                    HdVo.Hd_Remarks = txtsubjet.Text.Trim().TrimStart().TrimEnd();
                    HdVo.FeedBackType = ddlfeedback.SelectedValue;

                    HdVo.MainModule = ddlModule.SelectedValue;
                    HdVo.SubModule = ddlSubModule.SelectedValue;
                    HdVo.ProblemType = ddlProblemWhile.SelectedItem.Text;
                    HdVo.MobileNumber = txtMobileno.Text.Trim().TrimStart();
                    HdVo.ApplicationCode = ddlApplication.SelectedValue;
                    if (ObjLoginvo.Role_Code == "ADPP")
                    {
                        HdVo.PriorityId = ddlPriorityInput.SelectedValue;
                    }
                    HdVo.Status = "Open";

                    if (Request.QueryString.Count > 0)
                    {
                        if (Request.QueryString["AGAIN"] == "AGAIN")
                        {
                            HdVo.FeedbackReg = "AGAIN";
                            HdVo.MainHd_Id = Request.QueryString["OldHd_Id"].ToString();
                            HdVo.MainHd_Sub_Id = Request.QueryString["OldHd_Sub_Id"].ToString();
                        }
                        else
                        {
                            HdVo.FeedbackReg = "New";
                        }
                    }
                    else
                    {
                        HdVo.FeedbackReg = "New";
                    }
                    string Result = RegisterHds(HdVo);
                    if (Result == "1")
                    {
                        string TicketNumber = "HD" + HdVo.Hd_Id + "-SUB" + HdVo.Hd_Sub_Id;

                        string message = "alert('e-Ticket Registered Successfully. Ticket Number : " + TicketNumber + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        BtnSave.Enabled = false;

                        lblmsg.Text = " e-Ticket Registered Successfully. Ticket Number :" + TicketNumber;
                        Failure.Visible = false;
                        success.Visible = true;

                        //if (txtMobileno.Text.Trim().TrimStart() != "")
                        //{
                        //    try
                        //    {
                        //        string Msg = "Dear User, Your Ticket Number " + TicketNumber + " Has Been Registered Successfully.";
                        //        string Responce = Objret.SendSingleSMSnew(txtMobileno.Text.Trim().TrimStart(), Msg, "1007980384866185365");

                        //        #region SMSLog
                        //        SMSLogText objSMSLogText = new SMSLogText();
                        //        objSMSLogText.MobileNo = txtMobileno.Text.Trim().TrimStart();
                        //        objSMSLogText.OTPRefNo = "";
                        //        objSMSLogText.OTPValue = "";
                        //        objSMSLogText.SMSText = Msg;
                        //        objSMSLogText.SMSStatus = Responce;
                        //        objSMSLogText.UserId = ObjLoginvo.uid;
                        //        Objret.InsertSMSLog(objSMSLogText);
                        //        #endregion SMSLog
                        //    }
                        //    catch (Exception ex)
                        //    {

                        //    }
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                // Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                string UID = "0";
                if (Session["uid"] != null)
                {
                    UID = Session["uid"].ToString();
                }
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, UID);
            }
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            Response.Redirect("RaiseHelpDesk.aspx");
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            try
            {
                UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
                ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

                string newPath = "";
                gvCertificate.Visible = true;

                if (FileUpload10.HasFile)
                {
                    string OnlineApplicantID = ObjLoginvo.uid;
                    string Hd_Id = ViewState["Hd_Id"].ToString();
                    string Hd_Sub_Id = ViewState["Hd_Sub_Id"].ToString();

                    if ((FileUpload10.PostedFile != null) && (FileUpload10.PostedFile.ContentLength > 0))
                    {
                        string sFileName = System.IO.Path.GetFileName(FileUpload10.PostedFile.FileName);
                        try
                        {
                            string[] fileType = FileUpload10.PostedFile.FileName.Split('.');
                            int i = fileType.Length;
                            //if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "PPT" || fileType[i - 1].ToUpper().Trim() == "PPTX" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX")
                            //{
                            string serverpath = Server.MapPath("~\\Hdattachments\\" + OnlineApplicantID + "\\" + Hd_Sub_Id);  // incentiveid2
                            if (!Directory.Exists(serverpath))
                                Directory.CreateDirectory(serverpath);

                            FileUpload10.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                            string CrtdUser = "0";

                            string Path = serverpath;
                            string FileName = sFileName;

                            string Attachmentidnew = OnlineApplicantID + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                            string statusupload = UploadFiles(Hd_Id, Hd_Sub_Id, OnlineApplicantID, Attachmentidnew, fileType[i - 1].ToUpper().Trim(), serverpath, sFileName, "HDApplicant", OnlineApplicantID, getclientIP());

                            string File_Path_Text = System.IO.Path.GetFullPath(FileUpload10.PostedFile.FileName);
                            string FilePath = "~\\Hdattachments\\" + OnlineApplicantID + "\\" + Hd_Sub_Id + "\\" + sFileName;

                            AddDataToTableCeertificate(sFileName, FilePath, (DataTable)Session["CertificateTb2"]);
                            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                            this.gvCertificate.DataBind();
                            lblmsg.Text = "";

                            lblmsg.Text = "<font color='green'> Attachment Successfully Added..!</font>";
                            success.Visible = true;
                            Failure.Visible = false;
                            lblmsg.Focus();
                            //}
                            //else
                            //{
                            //    lblmsg0.Text = "Upload word, excel, pdf or ppt files only..!";
                            //    lblmsg0.Visible = true;
                            //    success.Visible = false;
                            //    Failure.Visible = true;
                            //}
                        }
                        catch (Exception)//in case of an error
                        {
                            DeleteFile(newPath + "\\" + sFileName);
                            lblmsg0.Text = "File Not Upload Successfully..!";
                            lblmsg0.Visible = true;
                            success.Visible = false;
                            Failure.Visible = true;
                        }
                    }
                }
                else
                {
                    lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                    success.Visible = false;
                    Failure.Visible = true;
                }

                gvCertificate.Visible = true;

            }
            catch (Exception ex)
            {
                // Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                string UID = "0";
                if (Session["uid"] != null)
                {
                    UID = Session["uid"].ToString();
                }
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, UID);
            }
        }
        public void DeleteFile(string strFileName)
        {
            if (strFileName.Trim().Length > 0)
            {
                FileInfo fi = new FileInfo(strFileName);
                if (fi.Exists)
                {
                    fi.Delete();
                }
            }
        }
        public static string getclientIP()
        {
            string result = string.Empty;
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ip))
            {
                string[] ipRange = ip.Split(',');
                int le = ipRange.Length - 1;
                result = ipRange[0];
            }
            else
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return result;
        }
        private void AddDataToTableCeertificate(string Filename, string filepath, DataTable myTable)
        {//totStartDate, string totEndDate, string totSummary,
            try
            {
                DataRow Row;
                Row = myTable.NewRow();

                dtMyTable = new DataTable("CertificateTb2");
                Row["FileName"] = Filename;
                Row["filepath"] = filepath;
                myTable.Rows.Add(Row);
            }
            catch (Exception ex)
            {
                throw ex;
                //  ((DataTable)Session["myDatatable"]).Rows.Clear();
                //  Response.Redirect("~/EmpFacility.aspx");
            }
        }
        protected DataTable createtablecrtificate()
        {
            dtMyTable = new DataTable("CertificateTb2");

            // dtMyTable.Columns.Add("new", typeof(string));
            dtMyTable.Columns.Add("FileName", typeof(string));
            dtMyTable.Columns.Add("filepath", typeof(string));
            return dtMyTable;
        }

        public string UploadFiles(string Hd_Id, string Hd_Sub_Id, string strApplicationId, string attachmentid, string FileType, string FilePath, string FileName, string FileDescription, string Created_by, string Sysip)
        {
            string str = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            string validup = "";
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                SqlCommand cmdEnj = new SqlCommand("USP_INS_ATTACHMENT", connection);
                cmdEnj.CommandType = CommandType.StoredProcedure;
                cmdEnj.Transaction = transaction;
                cmdEnj.Connection = connection;

                //SqlDataAdapter da1 = new SqlDataAdapter(cmdEnj);
                cmdEnj.Parameters.AddWithValue("@Hd_Id", SqlDbType.Int).Value = Convert.ToInt64(Hd_Id);
                cmdEnj.Parameters.AddWithValue("@Hd_Sub_Id", SqlDbType.Int).Value = Convert.ToInt64(Hd_Sub_Id);
                cmdEnj.Parameters.AddWithValue("@ApplicationId", SqlDbType.Int).Value = Convert.ToInt64(strApplicationId);
                cmdEnj.Parameters.AddWithValue("@AttachmentId", attachmentid);
                cmdEnj.Parameters.AddWithValue("@FileType", FileType);
                cmdEnj.Parameters.AddWithValue("@FilePath", FilePath);
                cmdEnj.Parameters.AddWithValue("@FileName", FileName);
                cmdEnj.Parameters.AddWithValue("@FileDescription", FileDescription);
                cmdEnj.Parameters.AddWithValue("@Created_by", Created_by);
                cmdEnj.Parameters.AddWithValue("@SysIp", Sysip);

                cmdEnj.Parameters.Add("@VALID", SqlDbType.Int, 500);
                cmdEnj.Parameters["@VALID"].Direction = ParameterDirection.Output;

                cmdEnj.ExecuteNonQuery();

                validup = cmdEnj.Parameters["@VALID"].Value.ToString();
                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return validup;
        }

        public string RegisterHds(HdClassVo HdVo)
        {
            string str = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            string validup = "";
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                SqlCommand cmdEnj = new SqlCommand("USP_INS_USER_HD", connection);
                cmdEnj.CommandType = CommandType.StoredProcedure;
                cmdEnj.Transaction = transaction;
                cmdEnj.Connection = connection;

                //SqlDataAdapter da1 = new SqlDataAdapter(cmdEnj);
                cmdEnj.Parameters.AddWithValue("@Hd_Id", SqlDbType.Int).Value = Convert.ToInt64(HdVo.Hd_Id);
                cmdEnj.Parameters.AddWithValue("@Hd_Sub_Id", SqlDbType.Int).Value = Convert.ToInt64(HdVo.Hd_Sub_Id);
                cmdEnj.Parameters.AddWithValue("@FeedBackType", HdVo.FeedBackType);
                cmdEnj.Parameters.AddWithValue("@FeedbackReg", HdVo.FeedbackReg);
                cmdEnj.Parameters.AddWithValue("@Status", HdVo.Status);
                cmdEnj.Parameters.AddWithValue("@Hd_Remarks", HdVo.Hd_Remarks);
                cmdEnj.Parameters.AddWithValue("@Created_by", HdVo.Created_by);
                cmdEnj.Parameters.AddWithValue("@SysIp", HdVo.Sysip);

                cmdEnj.Parameters.AddWithValue("@MainHd_Id", SqlDbType.VarChar).Value = HdVo.MainHd_Id;
                cmdEnj.Parameters.AddWithValue("@MainHd_Sub_Id", SqlDbType.VarChar).Value = HdVo.MainHd_Sub_Id;

                cmdEnj.Parameters.AddWithValue("@MainModule", HdVo.MainModule);
                cmdEnj.Parameters.AddWithValue("@SubModule", HdVo.SubModule);
                cmdEnj.Parameters.AddWithValue("@ProblemType", HdVo.ProblemType);
                cmdEnj.Parameters.AddWithValue("@MobileNumber", HdVo.MobileNumber);
                cmdEnj.Parameters.AddWithValue("@ApplicationCode", HdVo.ApplicationCode);

                cmdEnj.Parameters.AddWithValue("@PriorityId", HdVo.PriorityId);

                cmdEnj.Parameters.Add("@VALID", SqlDbType.Int, 500);
                cmdEnj.Parameters["@VALID"].Direction = ParameterDirection.Output;

                cmdEnj.ExecuteNonQuery();

                validup = cmdEnj.Parameters["@VALID"].Value.ToString();
                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return validup;
        }

        public string GeneralInformationcheck()
        {
            int slno = 1;
            string ErrorMsg = "";
            if (ddlApplication.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Application \\n";
                slno = slno + 1;
            }
            if (ddlModule.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Main Module \\n";
                slno = slno + 1;
            }
            if (ddlSubModule.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Sub Module \\n";
                slno = slno + 1;
            }
            if (ddlProblemWhile.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Problem Type where it occur  \\n";
                slno = slno + 1;
            }
            if (txtMobileno.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Mobile Number \\n";
                slno = slno + 1;
            }
            if (ddlfeedback.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Type of Feedback \\n";
                slno = slno + 1;
            }
            if (txtsubjet.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Your Query \\n";
                slno = slno + 1;
            }
            if (divPriorityInput.Visible)
            {
                if (ddlPriorityInput.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Ticket Priority \\n";
                    slno = slno + 1;
                }
            }
            return ErrorMsg;
        }

        public DataSet GetUserData(string USERID, string UserLevel)
        {
            DataSet Dsnew = new DataSet();
            try
            {
                SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
               new SqlParameter("@UserLevel",SqlDbType.VarChar)
                };
                pp[0].Value = USERID;
                pp[1].Value = UserLevel;

                Dsnew = Objret.GenericFillDs("USP_GET_HD_BASICDATA", pp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Dsnew;
        }

        private void BindMainModule()
        {
            DataSet dsYears = new DataSet();
            try
            {
                ddlModule.Items.Clear();
                SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@ApplicationID",SqlDbType.VarChar) };

                pp[0].Value = ddlApplication.SelectedValue;

                dsYears = Objret.GenericFillDs("USP_GET_Main_Module_Master", pp);
                if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
                {
                    ddlModule.DataSource = dsYears.Tables[0];
                    ddlModule.DataTextField = "GroupName";
                    ddlModule.DataValueField = "GroupID";
                    ddlModule.DataBind();
                }
                AddSelect(ddlModule);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void BindSubMainModule(string MainModuleCode)
        {
            try
            {
                DataSet dsYears = new DataSet();
                ddlSubModule.Items.Clear();

                SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@Main_Module",SqlDbType.VarChar)
           };
                pp[0].Value = MainModuleCode;


                dsYears = Objret.GenericFillDs("USP_GET_Module_Master", pp);
                if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
                {
                    ddlSubModule.DataSource = dsYears.Tables[0];
                    ddlSubModule.DataTextField = "Module_Desc";
                    ddlSubModule.DataValueField = "Module_Code";
                    ddlSubModule.DataBind();
                }
                AddSelect(ddlSubModule);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindSubMainModule(ddlModule.SelectedValue);
            }
            catch (Exception ex)
            {
                // Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                string UID = "0";
                if (Session["uid"] != null)
                {
                    UID = Session["uid"].ToString();
                }
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, UID);
            }
        }

        private void BindApplicationDetails()
        {
            try
            {
                DataSet dsYears = new DataSet();
                ddlApplication.Items.Clear();
                dsYears = Objret.GenericFillDs("USP_GET_Application_MST");
                if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
                {
                    ddlApplication.DataSource = dsYears.Tables[0];
                    ddlApplication.DataTextField = "Application_Name";
                    ddlApplication.DataValueField = "Application_code";
                    ddlApplication.DataBind();
                }
                AddSelect(ddlApplication);
            }
            catch (Exception ex)
            {
                // Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                string UID = "0";
                if (Session["uid"] != null)
                {
                    UID = Session["uid"].ToString();
                }
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, UID);
            }
        }

        protected void ddlApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMainModule();
        }
    }
}