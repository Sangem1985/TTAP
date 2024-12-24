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
    public partial class HelpdeskSolution : System.Web.UI.Page
    {
        CAFClass Objret = new CAFClass();

        static DataTable dtMyTableCertificate;
        static DataTable dtMyTable;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session.Count <= 0)
                {
                    Response.Redirect("~/LoginReg.aspx");
                }

                //Page.Form.Attributes.Add("enctype", "multipart/form-data");
                //ScriptManager.GetCurrent(this).RegisterPostBackControl(Button8);
                HdClassVoDepartment Objdepartment = new HdClassVoDepartment();
                UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
                ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];
                if (!IsPostBack)
                {
                    //if (ObjLoginvo.Role_Code == "CO")
                    //{
                    //    Response.Redirect("~/LoginReg.aspx");
                    //}
                    //if (ObjLoginvo.userlevel == "13")
                    //{
                    //    tdunitdeptname.InnerHtml = "Unit Name";
                    //}
                    //else
                    //{
                    // tdunitdeptname.InnerHtml = "District";
                    // }
                    dtMyTableCertificate = createtablecrtificate();
                    Session["CertificateTb2"] = dtMyTableCertificate;
                    DataSet ds = new DataSet();
                    string HDID = Request.QueryString["Hd_Id"].ToString();
                    string SubHDID = Request.QueryString["SubHDID"].ToString();
                    string UserId = Request.QueryString["UserId"].ToString();
                    string ViewType = Request.QueryString["ViewType"].ToString();

                    if (ObjLoginvo.userlevel != "2" || ViewType == "VIEW")
                    {
                        DivDeptOptions.Visible = false;
                        trdeptsave.Visible = false;
                        deptcomments.Visible = false;

                        trdeptupoads.Visible = false;
                        trDOUserFwd.Visible = false;
                    }


                    ds = GetapplicationDtls(HDID, UserId, SubHDID, ViewType);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["dsdata"] = ds;
                        Objdepartment.Hd_Id = HDID;
                        Objdepartment.Hd_Sub_Id = SubHDID;
                        Objdepartment.UserId = UserId;
                        Session["HDVosDpt"] = Objdepartment;
                        lblapplicantname.InnerHtml = ds.Tables[0].Rows[0]["APPLICANTNAME"].ToString();
                        // lblusername.Text = ds.Tables[0].Rows[0]["UserName"].ToString();
                        lblUnitname.InnerHtml = ds.Tables[0].Rows[0]["UnitName"].ToString();
                        lblfeedback.InnerHtml = ds.Tables[0].Rows[0]["Fb_Type"].ToString();
                        lblraiseddate.InnerHtml = ds.Tables[0].Rows[0]["SUBMITIONDATE"].ToString();
                        lblreuestid.InnerHtml = ds.Tables[0].Rows[0]["REQID"].ToString();
                        lblusercomments.InnerHtml = ds.Tables[0].Rows[0]["Hd_Remarks"].ToString();
                        lblcurrentstatus.InnerHtml = ds.Tables[0].Rows[0]["Ostatus"].ToString();
                        lblMandal.InnerHtml = ds.Tables[0].Rows[0]["Manda_lName"].ToString();
                        lblForwardedRemarks.InnerHtml = ds.Tables[0].Rows[0]["ForwardResponse"].ToString();

                        lblDepartmentRemarks.InnerHtml = ds.Tables[0].Rows[0]["DepartmentRemarks"].ToString();
                        if (lblDepartmentRemarks.InnerText != "")
                        {
                            divDepartmentRemarks.Visible = true;
                        }
                        else
                        {
                            divDepartmentRemarks.Visible = false;
                        }
                        lblMobileNumber.InnerHtml = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                        lblProblemWhile.InnerHtml = ds.Tables[0].Rows[0]["ProblemType"].ToString();
                        lblMainModule.InnerHtml = ds.Tables[0].Rows[0]["GroupName"].ToString();
                        lblsubmodule.InnerHtml = ds.Tables[0].Rows[0]["Module_Desc"].ToString();
                        lblApplication.InnerHtml = ds.Tables[0].Rows[0]["Application"].ToString();

                        string Status = ds.Tables[0].Rows[0]["Status"].ToString();
                        string OStatus = ds.Tables[0].Rows[0]["ostatus"].ToString();

                        string ForwardFlag = ds.Tables[0].Rows[0]["ForwardFlag"].ToString();

                        string TickerRegisteredBy = ds.Tables[0].Rows[0]["TickerRegisteredBy"].ToString();

                        string NeedApprovalFlag = ds.Tables[0].Rows[0]["NeedApprovalFlag"].ToString();
                        ViewState["NeedApprovalFlag"] = NeedApprovalFlag;
                        string ETRaisedRoleCode = ds.Tables[0].Rows[0]["ETRaisedRole_Code"].ToString();

                        string DeptFwdFlag = ds.Tables[0].Rows[0]["DepartmentForwardFlag"].ToString();

                        string AssignedTo_DeptUser = ds.Tables[0].Rows[0]["AssignedTo_DeptUser"].ToString();

                        lblPendingWith.InnerHtml = ds.Tables[0].Rows[0]["Pending_with"].ToString();
                        //if (ObjLoginvo.Role_Code == "")
                        //{
                        //    ViewState["AssignedTo_DeptUser"] = AssignedTo_DeptUser;
                        //}
                        //else
                        //{
                        //    ViewState["AssignedTo_DeptUser"] = AssignedTo_DeptUser;
                        //}

                        lblPriority.InnerHtml = ds.Tables[0].Rows[0]["Priority"].ToString();

                        if (lblPriority.InnerHtml != "")
                        {
                            divPriority.Visible = true;
                        }

                        if (ObjLoginvo.userlevel == "2")
                        {
                            if (ObjLoginvo.Role_Code == "")
                            {
                                divAssignMain.Visible = true;
                                DivDevTeamComments.Visible = true;
                                trDOUserFwd.Visible = true;
                                ddlAction.SelectedValue = "2";
                                ddlAction.Items.RemoveAt(ddlAction.Items.IndexOf(ddlAction.Items.FindByValue("1")));
                                GetUsersToAssign(ObjLoginvo.Role_Code, ObjLoginvo.uid);
                                if (Convert.ToString(ds.Tables[0].Rows[0]["AssignedTO"]) == null || Convert.ToString(ds.Tables[0].Rows[0]["AssignedTO"]) == "")
                                {
                                    divAssign.Visible = false;
                                    divbtnAssign.Visible = false;
                                    ViewState["Assigned"] = "0";
                                }
                                else
                                {
                                    ddlAsignedto.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["AssignedTO"]);
                                    ddlAsignedto.Enabled = false;
                                    divAssign.Visible = true;
                                    divbtnAssign.Visible = false;
                                    ViewState["Assigned"] = "1";
                                }

                                ViewState["AssignedTo_DeptUser"] = ds.Tables[0].Rows[0]["AssignedTO"].ToString();

                                if (ETRaisedRoleCode == "CO" && ForwardFlag == "")
                                {
                                    DivDeptOptions.Visible = false;
                                    trdeptsave.Visible = false;
                                    deptcomments.Visible = false;
                                    trdeptupoads.Visible = false;
                                    trDOUserFwd.Visible = false;
                                    DivDevTeamComments.Visible = false;
                                    if (Status.ToUpper() != "CLOSED")
                                    {
                                        string message = "alert('This Ticket has been Pending with DRP')";
                                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                                    }
                                    else
                                    {
                                        string message = "alert('This issue has been already resolved')";
                                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                                    }
                                }
                                else if (ETRaisedRoleCode == "CO" && ForwardFlag == "Y" && DeptFwdFlag == "")
                                {
                                    DivDeptOptions.Visible = false;
                                    trdeptsave.Visible = false;
                                    deptcomments.Visible = false;
                                    trdeptupoads.Visible = false;
                                    trDOUserFwd.Visible = false;
                                    DivDevTeamComments.Visible = false;
                                    if (Status.ToUpper() != "CLOSED")
                                    {
                                        string message = "alert('This Ticket has been Pending with CRD Department')";
                                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                                    }
                                    else
                                    {
                                        string message = "alert('This issue has been already resolved')";
                                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                                    }
                                }
                                else if (ETRaisedRoleCode == "DO" && DeptFwdFlag == "")
                                {
                                    DivDeptOptions.Visible = false;
                                    trdeptsave.Visible = false;
                                    deptcomments.Visible = false;
                                    trdeptupoads.Visible = false;
                                    trDOUserFwd.Visible = false;
                                    DivDevTeamComments.Visible = false;
                                    if (Status.ToUpper() != "CLOSED")
                                    {
                                        string message = "alert('This Ticket has been Pending with CRD Department')";
                                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                                    }
                                    else
                                    {
                                        string message = "alert('This issue has been already resolved')";
                                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                                    }
                                }
                                string DevTeamRemarks = ds.Tables[0].Rows[0]["DevTeam_Remarks"].ToString();
                                if (DevTeamRemarks != "")
                                {
                                    DivolustionDevTeamComments.Visible = true;
                                    DivSolustionDevTeamComments.InnerHtml = DevTeamRemarks;
                                }
                                else
                                {
                                    DivolustionDevTeamComments.Visible = false;
                                }

                                DivDeptOptions.Visible = false;
                                if (lblForwardedRemarks.InnerText != "")
                                {
                                    TrForwardedRemark.Visible = true;
                                }
                                else
                                {
                                    TrForwardedRemark.Visible = false;
                                }

                                if (NeedApprovalFlag == "Y")
                                {
                                    trdeptsave.Visible = false;
                                    deptcomments.Visible = false;
                                    trdeptupoads.Visible = false;
                                    trDOUserFwd.Visible = false;
                                }
                                else
                                {
                                    //DivDevTeamComments.Visible = true;
                                }
                            }
                            else if (ObjLoginvo.Role_Code == "DO")
                            {
                                DivDeptOptions.Visible = false;
                                ddlAction.Items.RemoveAt(ddlAction.Items.IndexOf(ddlAction.Items.FindByValue("3")));

                                if (ForwardFlag == "Y")
                                {
                                    trdeptsave.Visible = false;
                                    deptcomments.Visible = false;
                                    trdeptupoads.Visible = false;
                                    trDOUserFwd.Visible = false;
                                    //TrForwardedRemark.Visible = true;
                                    if (lblForwardedRemarks.InnerText != "")
                                    {
                                        TrForwardedRemark.Visible = true;
                                    }
                                    else
                                    {
                                        TrForwardedRemark.Visible = false;
                                    }
                                }
                            }
                            else if (ObjLoginvo.Role_Code == "DEPT")
                            {

                                ViewState["AssignedTo_DeptUser"] = AssignedTo_DeptUser;

                                divAssignMain.Visible = true;
                                trDOUserFwd.Visible = false;
                                ddlAction.SelectedValue = "2";
                                //TrForwardedRemark.Visible = true;
                                if (lblForwardedRemarks.InnerText != "")
                                {
                                    TrForwardedRemark.Visible = true;
                                }
                                else
                                {
                                    TrForwardedRemark.Visible = false;
                                }
                                GetUsersToAssign(ObjLoginvo.Role_Code, ObjLoginvo.uid);
                                //if (Convert.ToString(ds.Tables[0].Rows[0]["AssignedTO"]) == null || Convert.ToString(ds.Tables[0].Rows[0]["AssignedTO"]) == "")
                                //{
                                //    divAssign.Visible = false;
                                //    divbtnAssign.Visible = false;
                                //    ViewState["Assigned"] = "0";
                                //}
                                //else
                                //{
                                //    ddlAsignedto.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["AssignedTO"]);
                                //    ddlAsignedto.Enabled = false;
                                //    divAssign.Visible = true;
                                //    divbtnAssign.Visible = false;
                                //    ViewState["Assigned"] = "1";
                                //}
                                
                                if (NeedApprovalFlag == "" && DeptFwdFlag == "Y")
                                {
                                    trdeptsave.Visible = false;
                                    deptcomments.Visible = false;
                                    trdeptupoads.Visible = false;
                                    trDOUserFwd.Visible = false;
                                    DivDeptOptions.Visible = false;
                                    divPriorityInput.Visible = false;
                                }
                                if (NeedApprovalFlag == "" && DeptFwdFlag == "")
                                {
                                    trDOUserFwd.Visible = true;
                                    divPriorityInput.Visible = true;
                                    ddlAction.Items.RemoveAt(ddlAction.Items.IndexOf(ddlAction.Items.FindByValue("3")));
                                }
                                else if (NeedApprovalFlag == "Y")
                                {
                                    DivDeptOptions.Visible = true;
                                }

                                if (AssignedTo_DeptUser != ObjLoginvo.uid)
                                {
                                    trdeptsave.Visible = false;
                                    deptcomments.Visible = false;
                                    trdeptupoads.Visible = false;
                                    trDOUserFwd.Visible = false;
                                    DivDeptOptions.Visible = false;
                                    divPriorityInput.Visible = false;

                                    string message = "alert('This Ticket has been assigned to another User')";
                                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                                }
                            }
                        }
                        else if (ObjLoginvo.Role_Code == "CO")
                        {
                            if (ForwardFlag == "Y")
                            {
                                TrForwardedRemark.Visible = true;
                            }
                        }
                        if (ObjLoginvo.userlevel != "2")
                        {
                            if (ds.Tables[0].Columns.Contains("Viewbutton"))
                            {
                                string Viewbutton = ds.Tables[0].Rows[0]["Viewbutton"].ToString();
                                if (Viewbutton == "Y")
                                {
                                    trnotresolved.Visible = true;
                                }
                                else
                                {
                                    trnotresolved.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            trnotresolved.Visible = false;
                        }

                        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                        {
                            gvqueryresponse.DataSource = ds.Tables[1];
                            gvqueryresponse.DataBind();
                            Trqueryresponceattachemnts.Visible = true;
                        }
                        else
                        {
                            Trqueryresponceattachemnts.Visible = false;
                        }
                        if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                        {
                            divTicketHistory.Visible = true;
                            grdDetails.DataSource = ds.Tables[2];
                            grdDetails.DataBind();
                        }
                        else
                        {
                            divTicketHistory.Visible = false;
                        }

                        if ((Status.ToUpper() == "CLOSED") || (OStatus.ToUpper() == "CLOSED") || ObjLoginvo.uid == TickerRegisteredBy)
                        {
                            DivDeptOptions.Visible = false;
                            trdeptsave.Visible = false;
                            deptcomments.Visible = false;
                            trdeptupoads.Visible = false;
                            trDOUserFwd.Visible = false;
                            DivDevTeamComments.Visible = false;
                            divPriorityInput.Visible = false;
                        }
                        else if (Status.ToUpper() == "OPEN" && (ObjLoginvo.userlevel == "13"))
                        {
                            trnotresolved.Visible = false;
                        }

                        if ((Status.ToUpper() == "CLOSED") && (OStatus.ToUpper() == "CLOSED") && (ObjLoginvo.uid == TickerRegisteredBy))
                        {
                            trnotresolved.Visible = true;
                        }

                    }
                    else
                    {
                        trdeptsave.Visible = false;
                        trnotresolved.Visible = false;
                    }
                    DataSet dsapproval = new DataSet();
                    dsapproval = GetApprovalRequestDtls(HDID, UserId, SubHDID, ViewType);
                    if (dsapproval != null && dsapproval.Tables.Count > 0 && dsapproval.Tables[0].Rows.Count > 0)
                    {
                        gvApprovalRequestStatus.DataSource = dsapproval.Tables[0];
                        gvApprovalRequestStatus.DataBind();
                    }
                    else
                    {
                        DivApprovalRequestStatus.Visible = false;
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
        protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (((HyperLink)e.Row.FindControl("HyperLinkSubsidy")).NavigateUrl == "")
                    {
                        e.Row.FindControl("HyperLinkSubsidy").Visible = false;
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
        public DataSet GetUsersToAssign(string RoleCode, string intUserID)
        {
            DataSet Dsnew = new DataSet();
            try
            {
                SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@RoleCode",SqlDbType.VarChar),
               new SqlParameter("@intUserID",SqlDbType.VarChar) };

                pp[0].Value = RoleCode;
                pp[1].Value = intUserID;

                Dsnew = Objret.GenericFillDs("USP_GET_USERS_TO_ASSIGN", pp);
                if (Dsnew != null && Dsnew.Tables.Count > 0 && Dsnew.Tables[0].Rows.Count > 0)
                {
                    ddlAsignedto.DataSource = Dsnew.Tables[0];
                    ddlAsignedto.DataTextField = "User_name";
                    ddlAsignedto.DataValueField = "intUserID";
                    ddlAsignedto.DataBind();

                }
                AddSelect(ddlAsignedto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Dsnew;
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
                throw ex;
            }
        }

        public DataSet GetapplicationDtls(string Hd_Id, string UserName, string SubHDID, string ViewType)
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

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
                ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];


                string errormsg = GeneralInformationcheck();
               
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                { 
                    HdClassVoDepartment Objdepartment = new HdClassVoDepartment();
                    Objdepartment = (HdClassVoDepartment)Session["HDVosDpt"];

                    HdClassVo HdVo = new HdClassVo();
                    HdVo.Created_by = ObjLoginvo.uid;
                    HdVo.Sysip = getclientIP();
                    HdVo.Hd_Id = Objdepartment.Hd_Id;
                    HdVo.Hd_Sub_Id = Objdepartment.Hd_Sub_Id;
                    HdVo.UserUserId = Objdepartment.UserId;
                    HdVo.Hd_Remarks = txtsubjet.Text.Trim().TrimStart().TrimEnd();
                    if (ObjLoginvo.userlevel == "2" && ObjLoginvo.Role_Code == "")
                    {
                        HdVo.Hd_Remarks_DevTeam = txtDevTeamComments.Text.Trim().TrimStart().TrimEnd();
                    }
                    if (ddlAction.SelectedValue == "1")
                    {
                        HdVo.FeedbackReg = "Forward";
                        HdVo.Status = "Open";
                        HdVo.FwdFlag = "Y";
                        if (ObjLoginvo.Role_Code == "DEPT")
                        {
                            HdVo.PriorityId = ddlPriorityInput.SelectedValue;
                        }
                    }
                    else if (ddlAction.SelectedValue == "2")
                    {
                        if (ObjLoginvo.Role_Code == "DEPT" && ViewState["NeedApprovalFlag"].ToString() == "Y")
                        {
                            HdVo.FeedbackReg = "ApprovalResponse";
                            HdVo.Status = "Open";
                            HdVo.FwdFlag = null;
                            HdVo.ApprovalStaus = ddldeptApproval.SelectedItem.Text;
                        }
                        else
                        {
                            HdVo.FeedbackReg = "Reply";
                            HdVo.Status = "Closed";
                            HdVo.FwdFlag = null;
                        }
                    }
                    else if (ddlAction.SelectedValue == "3")
                    {
                        HdVo.FeedbackReg = "ApprovalRequest";
                        HdVo.Status = "Open";
                        HdVo.FwdFlag = "Y";
                    }



                    string Result = RegisterHds(HdVo);
                    if (Result == "1")
                    {
                        string Messagedis = "";
                        string message = string.Empty;
                        if (ddlAction.SelectedValue == "1" && ObjLoginvo.Role_Code == "DEPT")
                        {
                            message = "alert('Ticket has been Forwarded to Technical Team Successfully')";
                            Messagedis = "Ticket has been Forwarded to Technical Team Successfully";

                            trDOUserFwd.Visible = false;
                            divPriorityInput.Visible= false;
                            divAssignMain.Visible = false;
                        }
                        else if (ddlAction.SelectedValue == "1" && ObjLoginvo.Role_Code == "DO")
                        {
                            message = "alert('Ticket has been Forwarded to CRD Successfully')";
                            Messagedis = "Ticket has been Forwarded to CRD Successfully";
                        }
                        else if (ddlAction.SelectedValue == "2")
                        {
                            //if (HdVo.Status == "Closed" && lblMobileNumber.InnerText.Trim().TrimStart() != "")
                            //{
                            //    try
                            //    {
                            //        string Msg = "Dear User, Your Ticket Number " + lblreuestid.InnerHtml + " is Closed.";
                            //        string Responce = Objret.SendSingleSMSnew(lblMobileNumber.InnerText.Trim().TrimStart(), Msg, "1007443883129255770");
                            //        #region SMSLog
                            //        SMSLogText objSMSLogText = new SMSLogText();
                            //        objSMSLogText.MobileNo = lblMobileNumber.InnerText.Trim().TrimStart();
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
                            message = "alert('Responce Submitted Successfully')";
                            Messagedis = "Responce Submitted Successfully";
                        }
                        else
                        {
                            message = "alert('Ticket has been Sent to Department Successfully')";
                            Messagedis = "Ticket has been Sent to Department Successfully";
                        }
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        BtnSave.Enabled = false;
                        BtnSave.Visible = false;
                        lblmsg.Text = Messagedis;
                        Failure.Visible = false;
                        success.Visible = true;
                    }
                    else if (Result == "2")
                    {
                        string message = "alert('Already The Ticket has been Closed')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
            Response.Redirect("HelpdeskSolution.aspx");
        }
        protected void ddlAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
            ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

            if (ddlAction.SelectedValue == "4")
            {
                divAssignMain.Visible = true;
                divAssign.Visible = true;
                divbtnAssign.Visible = true;
                ddlAsignedto.Enabled = true;
                trdeptsave.Visible = false;
            }
            else
            {
                trdeptsave.Visible = true;
                if (ObjLoginvo.Role_Code == "DEPT" && (ddlAction.SelectedValue == "1" || ddlAction.SelectedValue == "2"))
                {
                    divAssignMain.Visible = false;
                }
                else
                {
                    if (ViewState["Assigned"] != null && ViewState["Assigned"].ToString() == "0")
                    {
                        divAssign.Visible = false;
                        divbtnAssign.Visible = false;
                    }
                    else
                    {
                        ddlAsignedto.Enabled = false;
                        divAssign.Visible = true;
                        divbtnAssign.Visible = false;
                    }
                }
            }
        }
        protected void btnAssign_Click(object sender, EventArgs e)
        {


            string str = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            string validup = "";
            try
            {

                UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
                ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

                if (ObjLoginvo.Role_Code == "DEPT" && ObjLoginvo.uid != ViewState["AssignedTo_DeptUser"].ToString())
                {
                    string message1 = "alert('already This Ticket has been assigned to another user')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message1, true);
                    return;
                }

                connection.Open();
                transaction = connection.BeginTransaction();
                SqlCommand cmdEnj = new SqlCommand("USP_AssignTicket", connection);
                cmdEnj.CommandType = CommandType.StoredProcedure;
                cmdEnj.Transaction = transaction;
                cmdEnj.Connection = connection;

                //SqlDataAdapter da1 = new SqlDataAdapter(cmdEnj);
                cmdEnj.Parameters.AddWithValue("@Hd_Id", SqlDbType.Int).Value = Request.QueryString["Hd_Id"].ToString();
                cmdEnj.Parameters.AddWithValue("@SubHDID", SqlDbType.Int).Value = Request.QueryString["SubHDID"].ToString();
                cmdEnj.Parameters.AddWithValue("@USERID", Convert.ToInt32(ObjLoginvo.uid));
                cmdEnj.Parameters.AddWithValue("@AssignedTo", Convert.ToInt32(ddlAsignedto.SelectedValue));
                cmdEnj.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();

                ViewState["AssignedTo_DeptUser"] = ddlAsignedto.SelectedValue;

                if (ObjLoginvo.Role_Code == "DEPT")
                {
                    ddlAction.Enabled = false;
                    btnAssign.Visible = false;
                    ddlAsignedto.Enabled = false;
                }
                
                string message = "alert('Ticket has been assigned to " + ddlAsignedto.SelectedItem.Text + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }

        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            try
            {
                UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
                ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

                HdClassVoDepartment Objdepartment = new HdClassVoDepartment();
                Objdepartment = (HdClassVoDepartment)Session["HDVosDpt"];

                string newPath = "";
                gvCertificate.Visible = true;

                if (FileUpload10.HasFile)
                {
                    string OnlineApplicantID = Objdepartment.UserId;
                    string Hd_Id = Objdepartment.Hd_Id;
                    string Hd_Sub_Id = Objdepartment.Hd_Sub_Id;

                    if ((FileUpload10.PostedFile != null) && (FileUpload10.PostedFile.ContentLength > 0))
                    {
                        string sFileName = System.IO.Path.GetFileName(FileUpload10.PostedFile.FileName);
                        try
                        {
                            string[] fileType = FileUpload10.PostedFile.FileName.Split('.');
                            int i = fileType.Length;
                            //if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "PPT" || fileType[i - 1].ToUpper().Trim() == "PPTX" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX")
                            //{
                            string serverpath = Server.MapPath("~\\Hdattachments\\HDDepartment\\" + OnlineApplicantID + "\\" + Hd_Sub_Id);  // incentiveid2
                            if (!Directory.Exists(serverpath))
                                Directory.CreateDirectory(serverpath);

                            FileUpload10.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                            string CrtdUser = "0";

                            string Path = serverpath;
                            string FileName = sFileName;

                            string Attachmentidnew = OnlineApplicantID + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                            string statusupload = UploadFiles(Hd_Id, Hd_Sub_Id, OnlineApplicantID, Attachmentidnew, fileType[i - 1].ToUpper().Trim(), serverpath, sFileName, "HDDepartment", ObjLoginvo.uid, getclientIP());

                            string File_Path_Text = System.IO.Path.GetFullPath(FileUpload10.PostedFile.FileName);
                            string FilePath = "~\\Hdattachments\\HDDepartment\\" + OnlineApplicantID + "\\" + Hd_Sub_Id + "\\" + sFileName;

                            AddDataToTableCeertificate(sFileName, FilePath, (DataTable)Session["CertificateTb2"]);
                            this.gvCertificate.DataSource = ((DataTable)Session["CertificateTb2"]).DefaultView;
                            this.gvCertificate.DataBind();
                            lblmsg.Text = "";

                            lblmsg.Text = "<font color='green'> Attachment Successfully Added..!</font>";
                            success.Visible = true;
                            Failure.Visible = false;
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
                SqlCommand cmdEnj = new SqlCommand("USP_UPD_USER_HD_DEPT", connection);
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
                cmdEnj.Parameters.AddWithValue("@UserUserId", HdVo.UserUserId);
                cmdEnj.Parameters.AddWithValue("@Created_by", HdVo.Created_by);
                cmdEnj.Parameters.AddWithValue("@SysIp", HdVo.Sysip);
                cmdEnj.Parameters.AddWithValue("@FwdFlag", HdVo.FwdFlag);
                cmdEnj.Parameters.AddWithValue("@ApprovalStaus", HdVo.ApprovalStaus);
                cmdEnj.Parameters.AddWithValue("@Hd_Remarks_DevTeam", HdVo.Hd_Remarks_DevTeam);
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

            if (txtsubjet.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Your Response \\n";
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
            if (trDOUserFwd.Visible)
            {
                if (ddlAction.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Action Taken \\n";
                    slno = slno + 1;
                }
            }
            if (DivDeptOptions.Visible)
            {
                if (ddldeptApproval.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Action Taken \\n";
                    slno = slno + 1;
                }
            }
            

            UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
            ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

            if (ObjLoginvo.Role_Code == "" && Convert.ToString(ViewState["AssignedTo_DeptUser"].ToString()) != "" && Convert.ToString(ViewState["AssignedTo_DeptUser"].ToString()) != "0")
            {
                if (Convert.ToString(ViewState["AssignedTo_DeptUser"].ToString()) != ObjLoginvo.uid)
                {
                    ErrorMsg = ErrorMsg + slno + "This Ticket is Assigned to another User";
                    slno = slno + 1;
                }
            }
            if (ObjLoginvo.Role_Code == "DEPT")
            {
                if (Convert.ToString(ViewState["AssignedTo_DeptUser"].ToString()) != ObjLoginvo.uid)
                {
                    ErrorMsg = ErrorMsg + slno + "This Ticket is Assigned to another User";
                    slno = slno + 1;
                }
            }
            return ErrorMsg;
        }

        protected void btnopenticket_Click(object sender, EventArgs e)
        {
            try
            {
                string MainHDid = "";
                string MainSubHDid = "";
                DataSet ds = new DataSet();
                ds = (DataSet)ViewState["dsdata"];
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    MainHDid = ds.Tables[0].Rows[0]["Hd_Id"].ToString();
                    MainSubHDid = ds.Tables[0].Rows[0]["Hd_Sub_Id"].ToString();
                    Response.Redirect("RaiseHelpDesk.aspx?OldHd_Id=" + MainHDid + "&OldHd_Sub_Id=" + MainSubHDid + "&AGAIN=AGAIN");
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

        public DataSet GetApprovalRequestDtls(string Hd_Id, string UserName, string SubHDID, string ViewType)
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
                Dsnew = Objret.GenericFillDs("[USP_GET_DEPT_APPROVAL_DTLS]", pp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Dsnew;
        }
    }
}