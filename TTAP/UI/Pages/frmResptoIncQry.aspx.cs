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
    public partial class frmResptoIncQry : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        ClsFileUpload objClsFileUpload = new ClsFileUpload();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["ObjLoginvo"] != null)
                {
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    if (hdnUserID.Value == "")
                    {
                        hdnUserID.Value = ObjLoginNewvo.uid;
                    }
                    else
                    {
                        PageName pageName = new PageName();
                        string Valid = pageName.ValidateUser(hdnUserID.Value, ObjLoginNewvo.uid);
                        if (Valid == "1")
                        {
                            Session.RemoveAll();
                            Session.Clear();
                            Session.Abandon();
                            Response.Redirect("~/LoginReg.aspx");
                        }
                    }
                    if (!IsPostBack)
                    {
                        string IncentiveID = "", SubIncentiveID = "", OfficerRole = "";
                        ViewState["IncentiveID"] = null;
                        ViewState["SubIncentiveID"] = null;
                        ViewState["OfficerRole"] = null;

                        if (Request.QueryString["EntrpId"] != null)
                        {
                            IncentiveID = Request.QueryString["EntrpId"].ToString();
                        }
                        if (Request.QueryString["Inctypeid"] != null)
                        {
                            SubIncentiveID = Request.QueryString["Inctypeid"].ToString();
                        }
                        if (Request.QueryString["JdOrGMflag"] != null)
                        {
                            OfficerRole = Request.QueryString["JdOrGMflag"].ToString();
                        }

                        ViewState["IncentiveID"] = IncentiveID;
                        ViewState["SubIncentiveID"] = SubIncentiveID;
                        ViewState["OfficerRole"] = OfficerRole;

                        BindBasicData(ObjLoginNewvo.uid, IncentiveID, SubIncentiveID, OfficerRole);
                        if (OfficerRole == "ADMIN-COMM")
                        {
                            BindAppliedIncentives(IncentiveID, ObjLoginNewvo.Role_Code);
                        }
                        else
                        {
                            DivIncentiveList.Visible = false;
                        }
                    }
                }
                else
                {
                    Response.Redirect("~/LoginReg.aspx");
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                string uid = "0";
                if (Session["uid"] != null)
                {
                    uid = Session["uid"].ToString();
                }

                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, uid);
            }
        }
        public DataSet GetapplicationDtls(string USERID, string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@CREATEDBY",SqlDbType.VarChar),
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = USERID;
            pp[1].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_INCENTIVES_CAF_DATA", pp);
            return Dsnew;
        }
        public void BindBasicData(string uid, string IncentiveID, string SubIncentiveID, string OfficerRole)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetapplicationDtls(uid, IncentiveID);
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    lblTSIPassUIDNumber.InnerText = dsnew.Tables[0].Rows[0]["Uid_NO"].ToString();
                    lblCommonApplicationNumber.InnerText = dsnew.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                    lblTypeofApplicant.InnerText = dsnew.Tables[0].Rows[0]["TypeOfIndustryText"].ToString();
                    lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCP"].ToString();

                    lblCategoryofUnit.InnerText = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    lblActivityoftheUnit.InnerText = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();
                }
                if (SubIncentiveID == "")
                {
                    SubIncentiveID = "0";
                }
                DataSet dss = new DataSet();
                dss = GetQueriesById(Convert.ToInt32(IncentiveID), Convert.ToInt32(SubIncentiveID), OfficerRole);
                if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                {
                    ViewState["QueryId"] = dss.Tables[0].Rows[0]["QueryId"].ToString();
                    grdQueries.DataSource = dss;
                    grdQueries.DataBind();

                    GetIncetiveAttachements(IncentiveID, SubIncentiveID, ViewState["QueryId"].ToString());
                    BtnSave.Visible = true;
                    btnUpload1.Visible = true;
                }
                else
                {
                    grdQueries.DataSource = null;
                    grdQueries.DataBind();
                    BtnSave.Visible = false;
                    btnUpload1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
        public DataSet GetQueriesById(int IncentiveId, int SubIncentiveID, string OfficerRole)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@SubIncentiveID",SqlDbType.Int),
               new SqlParameter("@OfficerRole",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = SubIncentiveID;
            pp[2].Value = OfficerRole;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_QUERIES_APPLICANT", pp);
            return Dsnew;
        }
        public DataSet GetIncetiveDropDownList(string incentiveID, string RoleCode)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentveID",SqlDbType.VarChar),
               new SqlParameter("@RoleCode",SqlDbType.VarChar)
            };
            pp[0].Value = incentiveID;
            pp[1].Value = RoleCode;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_APPLIEDINCENTIVES_DROPDOWNLIST", pp);
            return Dsnew;
        }
        public void BindAppliedIncentives(string incentiveID, string RoleCode)
        {
            ddlAppliedIncenties.Items.Clear();
            DataSet dsapprovals = new DataSet();
            dsapprovals = GetIncetiveDropDownList(incentiveID, RoleCode);
            if (dsapprovals != null && dsapprovals.Tables.Count > 0 && dsapprovals.Tables[0].Rows.Count > 0)
            {
                DivIncentiveList.Visible = true;
                ddlAppliedIncenties.DataSource = dsapprovals.Tables["Table"];
                ddlAppliedIncenties.DataValueField = "SubIncentiveID";
                ddlAppliedIncenties.DataTextField = "IncentiveName";
                ddlAppliedIncenties.DataBind();
            }
            else
            {
                DivIncentiveList.Visible = false;
            }
            AddSelect(ddlAppliedIncenties);
        }
        public void AddSelect(DropDownList ddl)
        {
            try
            {
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "-1";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }
        }
        protected void btnUpload1_Click(object sender, EventArgs e)
        {
            try
            {
                //ViewState["IncentiveID"] 
                //ViewState["SubIncentiveID"]
                //ViewState["OfficerRole"]
                if (DivQueryDetails.Visible == true && ViewState["OfficerRole"].ToString() == "ADMIN-COMM" && ddlAppliedIncenties.SelectedValue == "-1")
                {
                    string errormsg = "Please Select Incentive !";
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }

                string SubIncentiveID = "";
                if (ViewState["SubIncentiveID"].ToString() != "" && ViewState["SubIncentiveID"].ToString() != "0")
                {
                    SubIncentiveID = ViewState["SubIncentiveID"].ToString();
                }
                else if (DivQueryDetails.Visible == true && ViewState["OfficerRole"].ToString() == "ADMIN-COMM")
                {
                    SubIncentiveID = ddlAppliedIncenties.SelectedValue;
                }
                else
                {
                    SubIncentiveID = "0";
                }

                if (txtfileDescription.Text.Trim().TrimStart() == "")
                {
                    string errormsg = "Please Enter Name Of the File";
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                if (fuDocuments1.HasFile)
                {
                    string Mimetype = objClsFileUpload.getmimetype(fuDocuments1);
                    if (Mimetype == "application/pdf")
                    {
                        //string ext = Path.GetExtension(sFileName);
                        //string sFileNameonly = Path.GetFileNameWithoutExtension(sFileName);
                        string Attachmentidnew = ViewState["IncentiveID"].ToString() + "020" + SubIncentiveID.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

                        //sFileName = sFileNameonly + Attachmentidnew + ext;

                        HyperLink hypconcernedCTo = new HyperLink();
                        //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                        string OutPut = objClsFileUpload.IncentiveFileUploadingQuery("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuDocuments1, hypconcernedCTo, ViewState["OfficerRole"].ToString() + "QueryResponse", ViewState["IncentiveID"].ToString(), SubIncentiveID.ToString(), Attachmentidnew, Session["uid"].ToString(), "USER", ViewState["QueryId"].ToString(), "Query");
                        if (OutPut != "0")
                        {
                            string DocStatus = ObjCAFClass.UpdateUplodedFileName(ViewState["IncentiveID"].ToString(), SubIncentiveID.ToString(), txtfileDescription.Text.Trim().TrimStart(), OutPut);
                            success.Visible = true;
                            Failure.Visible = false;
                            lblmsg.Text = "Attachment Successfully Added..!";
                        }

                        GetIncetiveAttachements(ViewState["IncentiveID"].ToString(), SubIncentiveID.ToString(), ViewState["QueryId"].ToString());
                    }
                    else
                    {
                        string errormsg = "Only pdf files allowed !";
                        string message = "alert('" + errormsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
                else
                {
                    string errormsg = "Please Select Files to Upload";
                    lblmsg0.Text = errormsg;
                    Failure.Visible = true;
                    success.Visible = false;
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                // Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        public void GetIncetiveAttachements(string IncentiveId, string SubIncentiveID, string QueryId)
        {
            DataSet dsnew1 = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentveID",SqlDbType.VarChar),
               new SqlParameter("@SubIncentiveID",SqlDbType.VarChar),
               new SqlParameter("@QueryId",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = SubIncentiveID;
            pp[2].Value = QueryId;

            dsnew1 = ObjCAFClass.GenericFillDs("[USP_GET_QUERYATTACHMENTS_APPLICANT]", pp);

            if (dsnew1 != null && dsnew1.Tables.Count > 0 && dsnew1.Tables[0].Rows.Count > 0)
            {
                gvSubsidy.DataSource = dsnew1.Tables[0];
                gvSubsidy.DataBind();
                DivAttachments.Visible = true;
            }
            else
            {
                DivAttachments.Visible = false;
            }
        }

        public string ValidateControls()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (txtdiscription.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Response \\n";
                slno = slno + 1;
            }

            return ErrorMsg;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string errormsg = ValidateControls();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {

                    ApplicationStatus ObjApplicationStatus = new ApplicationStatus();
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    ObjApplicationStatus.QueryId = ViewState["QueryId"].ToString();
                    ObjApplicationStatus.IncentiveId = ViewState["IncentiveID"].ToString();
                    ObjApplicationStatus.SubIncentiveId = ViewState["SubIncentiveID"].ToString();
                    ObjApplicationStatus.CreatedBy = ObjLoginNewvo.uid;
                    ObjApplicationStatus.TransType = ViewState["OfficerRole"].ToString();
                    ObjApplicationStatus.Remarks = txtdiscription.Text.Trim().TrimStart();

                    string Status = ObjCAFClass.UpdateQueryResponseofApplicant(ObjApplicationStatus);

                    if (Convert.ToInt32(Status) > 0)
                    {
                        string Successmsg = "";
                        txtdiscription.Text = "";

                        Successmsg = "Response Submitted Successfully";

                        BtnSave.Enabled = false;
                        string message = "alert('" + Successmsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        protected void gvSubsidy_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

                if (e.CommandName == "RowDdelete")
                {
                    ApplicationStatus ObjApplicationStatus = new ApplicationStatus();
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    ObjApplicationStatus.AttachmentUploadedID = ((Label)(gr.FindControl("lblUploadedID"))).Text;
                    ObjApplicationStatus.CreatedBy = ObjLoginNewvo.uid;
                    ObjApplicationStatus.TransType = "DLT";


                    string Validstatus = ObjCAFClass.DeleteUploadedAttachment(ObjApplicationStatus);
                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        lblmsg.Text = "Deleted Successfully";
                        Failure.Visible = false;
                        success.Visible = true;

                        string SubIncentiveID = "";
                        if (ViewState["SubIncentiveID"].ToString() != "" && ViewState["SubIncentiveID"].ToString() != "0")
                        {
                            SubIncentiveID = ViewState["SubIncentiveID"].ToString();
                        }
                        else if (DivQueryDetails.Visible == true && ViewState["OfficerRole"].ToString() == "ADMIN-COMM")
                        {
                            SubIncentiveID = ddlAppliedIncenties.SelectedValue;
                        }
                        else
                        {
                            SubIncentiveID = "0";
                        }

                        GetIncetiveAttachements(ViewState["IncentiveID"].ToString(), SubIncentiveID.ToString(), ViewState["QueryId"].ToString());
                    }
                    else
                    {
                        lblmsg0.Text = "File have not been deleted";
                        Failure.Visible = true;
                        success.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
    }
}