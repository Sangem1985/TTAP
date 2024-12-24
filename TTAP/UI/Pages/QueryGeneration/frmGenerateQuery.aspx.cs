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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Xml.Linq;
using System.Text;

namespace TTAP.UI.Pages.QueryGeneration
{
    public partial class frmGenerateQuery : System.Web.UI.Page
    {
        General Gen = new General();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        //CAFClass caf = new CAFClass();
        CAFClass ObjCAFClass = new CAFClass();

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
                        if (Session["uid"] != null)
                        {
                            string userid = Session["uid"].ToString();
                            BindHeadOfficeUsers(userid);
                            BindControls();


                            if (ObjLoginNewvo.Role_Code == "DLO")
                            {
                                divApproveactionlabel.Visible = false;
                                divApproveaction.Visible = false;
                                divdeptusers.Visible = false;
                                ddlApproveaction.SelectedValue = "A";
                                divbtndeptusers.Attributes.Add("class", "col-sm-12 text-center");
                            }
                            else
                            {
                                divApproveaction.Visible = true;
                                ddlApproveaction.SelectedValue = "0";
                                divbtndeptusers.Attributes.Add("class", "col-sm-3 text-left");
                            }
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
        public void BindControls()
        {
            try
            {
                DataSet dsnew = new DataSet();
                string IncentiveID = "0";
                string Stg = "0";
                string MainQueryID = "0";
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                if (Request.QueryString.Count > 0 && Request.QueryString["Id"] != null && Request.QueryString["Id"].ToString() != "")
                {
                    IncentiveID = Request.QueryString["Id"].ToString();
                    if (Request.QueryString["MainQueryID"] != null && Request.QueryString["MainQueryID"].ToString() != "")
                    {
                        MainQueryID = Request.QueryString["MainQueryID"].ToString();
                    }

                    if (Request.QueryString["Stg"] != null && Request.QueryString["Stg"].ToString() != "")
                    {
                        Stg = Request.QueryString["Stg"].ToString();
                    }

                    string newurl = "~/UI/frmDLOApplicationDetailsNew.aspx?Id=" + IncentiveID + "&Sts=" + Stg;
                    HyplinkViewApplication.NavigateUrl = newurl;
                    ViewState["IncentiveID"] = IncentiveID;
                    ViewState["MainQueryID"] = MainQueryID;
                    DataSet dsQueryDtls = new DataSet();
                    dsQueryDtls = BindIncentiveQueryDtls(IncentiveID, MainQueryID);
                    if (dsQueryDtls != null && dsQueryDtls.Tables.Count > 1 && dsQueryDtls.Tables[1].Rows.Count > 0)
                    {
                        lblLetterNumber.InnerText = dsQueryDtls.Tables[1].Rows[0]["LetterNo"].ToString();
                        lblLetterInitiationDate.InnerText = dsQueryDtls.Tables[1].Rows[0]["LetterDate"].ToString();
                        lblLetterApprovedDate.InnerText = dsQueryDtls.Tables[1].Rows[0]["LetterApprovalDate"].ToString();
                        lblLetterInitiationby.InnerText = dsQueryDtls.Tables[1].Rows[0]["LetterInitiationby"].ToString();
                        divletterdtls.Visible = true;
                        btnGenerateLetter.Visible = true;
                        btnGenerateLetter2.Visible = true;
                    }
                    else
                    {
                        divletterdtls.Visible = false;
                        btnGenerateLetter.Visible = false;
                        btnGenerateLetter2.Visible = false;
                        divApprove.Visible = false;
                    }
                    if (dsQueryDtls != null && dsQueryDtls.Tables.Count > 3 && dsQueryDtls.Tables[3].Rows.Count > 0)
                    {
                        string TransferTo = "", Flag = "", CreatedBy = "";
                        TransferTo = dsQueryDtls.Tables[3].Rows[0]["TransferTo"].ToString();
                        Flag = dsQueryDtls.Tables[3].Rows[0]["Flag"].ToString();
                        CreatedBy = dsQueryDtls.Tables[3].Rows[0]["CreatedBy"].ToString();

                        if (Flag == "A")
                        {
                            divApprove.Visible = false;
                            BtnSaveDraft.Visible = false;
                            DivSalesDetails.Visible = false;
                            gvsalesDetails.Columns[4].Visible = false;
                            gvsalesDetails.Columns[3].Visible = false;
                        }
                        else
                        {
                            if (CreatedBy == ObjLoginNewvo.uid && TransferTo != ObjLoginNewvo.uid)
                            {
                                divApprove.Visible = false;
                                BtnSaveDraft.Visible = false;
                                DivSalesDetails.Visible = false;
                                gvsalesDetails.Columns[4].Visible = false;
                                gvsalesDetails.Columns[3].Visible = false;
                            }
                            else if (TransferTo != ObjLoginNewvo.uid)
                            {
                                divApprove.Visible = false;
                                BtnSaveDraft.Visible = false;
                                DivSalesDetails.Visible = false;
                                gvsalesDetails.Columns[4].Visible = false;
                                gvsalesDetails.Columns[3].Visible = false;
                            }
                        }

                        if (dsQueryDtls != null && dsQueryDtls.Tables.Count > 4 && dsQueryDtls.Tables[4].Rows.Count > 0)
                        {
                            divstepperMain.Visible = true;
                            StringBuilder strBuilder = new StringBuilder();
                            int Rowscount = dsQueryDtls.Tables[4].Rows.Count;
                            int Slno = 1;
                            foreach (DataRow dr in dsQueryDtls.Tables[4].Rows)
                            {
                                string TransferDate = dr["TransferDate"].ToString();
                                string TransferDatetime = dr["TransferDatetime"].ToString();
                                string Transferedby = dr["Transferedby"].ToString();
                                string TransferedbyDesignation = dr["TransferedbyDesignation"].ToString();
                                string TransferedTo = dr["TransferedTo"].ToString();
                                string TransferedToDesignation = dr["TransferedToDesignation"].ToString();
                                string FlagNew = dr["Flag"].ToString();

                                if (FlagNew == "F")
                                {
                                    strBuilder.Append("<div class='stepper-item completed'>");
                                    strBuilder.Append("<div class='step-counter'>" + Slno.ToString() + "</div>");
                                    strBuilder.Append("<div class='step-name'> " + Transferedby.ToString() + ", <span class='c - stepper__desc'>" + TransferedbyDesignation + "</span></div>");
                                    strBuilder.Append("<div class='step-name'> " + TransferDate.ToString() + "  <span class='c - stepper__desc'>" + TransferDatetime + "</span></div>");
                                    strBuilder.Append("</div>");
                                }
                                else if (FlagNew == "A")
                                {
                                    strBuilder.Append("<div class='stepper-item completed'>");
                                    strBuilder.Append("<div class='step-counter'>" + Slno.ToString() + "</div>");
                                    strBuilder.Append("<div class='step-name'> " + Transferedby.ToString() + ", <span class='c - stepper__desc'>" + TransferedbyDesignation + "</span></div>");
                                    strBuilder.Append("<div class='step-name'> " + TransferDate.ToString() + "  <span class='c - stepper__desc'>" + TransferDatetime + "</span></div>");
                                    strBuilder.Append("<div class='step-name'>File Approved</div>");
                                    strBuilder.Append("</div>");
                                }

                                if (Rowscount == Slno && FlagNew == "F")
                                {
                                    Slno = Slno + 1;
                                    strBuilder.Append("<div class='stepper-item active'>");
                                    strBuilder.Append("<div class='step-counter'>" + Slno.ToString() + "</div>");
                                    strBuilder.Append("<div class='step-name'> " + TransferedTo.ToString() + ", <span class='c - stepper__desc'>" + TransferedToDesignation + "</span></div>");
                                    strBuilder.Append("<div class='step-name'> In Progress </div>");
                                    strBuilder.Append("</div>");
                                }
                                Slno = Slno + 1;
                            }
                            divstepper.InnerHtml = strBuilder.ToString();
                        }
                        else
                        {
                            divstepperMain.Visible = false;
                        }
                    }
                    GetIncetiveAttachements(IncentiveID, MainQueryID);
                }
                dsnew = GetapplicationDtls(Session["uid"].ToString(), IncentiveID);
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    lblTSIPassUIDNumber.InnerText = dsnew.Tables[0].Rows[0]["Uid_NO"].ToString();
                    lblCommonApplicationNumber.InnerText = dsnew.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                    lblTypeofApplicant.InnerText = dsnew.Tables[0].Rows[0]["TypeOfIndustryText"].ToString();
                    string TypeOfIndustry = dsnew.Tables[0].Rows[0]["TypeOfIndustry"].ToString();
                    if (TypeOfIndustry == "1")
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCP"].ToString();
                    }
                    else
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCPExp"].ToString();
                    }

                    BindAppliedIncentives(IncentiveID, ObjLoginNewvo.Role_Code);
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

        public DataSet GetIncetiveDropDownList(string incentiveID, string RoleCode)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentveID",SqlDbType.VarChar),
               new SqlParameter("@RoleCode",SqlDbType.VarChar)
            };
            pp[0].Value = incentiveID;
            pp[1].Value = RoleCode;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_APPLIEDINCENTIVES_QUERYLETTER", pp);
            return Dsnew;
        }
        public void BindAppliedIncentives(string incentiveID, string RoleCode)
        {
            ddlAppliedIncenties.Items.Clear();
            DataSet dsapprovals = new DataSet();
            dsapprovals = GetIncetiveDropDownList(incentiveID, RoleCode);
            if (dsapprovals != null && dsapprovals.Tables.Count > 0 && dsapprovals.Tables[0].Rows.Count > 0)
            {
                //DivSalesDetails.Visible = true;
                ddlAppliedIncenties.DataSource = dsapprovals.Tables["Table"];
                ddlAppliedIncenties.DataValueField = "SubIncentiveID";
                ddlAppliedIncenties.DataTextField = "IncentiveName";
                ddlAppliedIncenties.DataBind();
            }
            else
            {
                DivSalesDetails.Visible = false;
            }
            AddSelect(ddlAppliedIncenties);
        }
        public void AddSelect(DropDownList ddl)
        {
            try
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
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
        public string ValidateQueryDtls()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (ddlAppliedIncenties.SelectedValue == "-1")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Incentive \\n";
                slno = slno + 1;
            }
            if (txtQueryRemarks.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Query \\n";
                slno = slno + 1;
            }
            return ErrorMsg;
        }
        protected void btnAddQueries_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["QueryId"] == null)
                {
                    ViewState["QueryId"] = "0";
                }
                if (ViewState["MainQueryID"] == null || ViewState["MainQueryID"].ToString() == "")
                {
                    ViewState["MainQueryID"] = "0";
                }
                string errormsg = ValidateQueryDtls();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    QueryGenerationVo objQueryGenerationVo = new QueryGenerationVo();

                    objQueryGenerationVo.QueryId = ViewState["QueryId"].ToString();
                    objQueryGenerationVo.MainQueryID = ViewState["MainQueryID"].ToString();
                    objQueryGenerationVo.TransType = "INS";
                    objQueryGenerationVo.IncentiveId = ViewState["IncentiveID"].ToString();
                    objQueryGenerationVo.Created_by = ObjLoginNewvo.uid;

                    objQueryGenerationVo.SubIncentiveID = ddlAppliedIncenties.SelectedValue;
                    objQueryGenerationVo.Query = txtQueryRemarks.Text.Trim().TrimStart().TrimEnd();

                    string MainQueryID = "0";
                    string Validstatus = ObjCAFClass.InsertQueryletterGenerationDetails(objQueryGenerationVo, out MainQueryID);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        if ((ViewState["MainQueryID"] == null || ViewState["MainQueryID"].ToString() == "" || ViewState["MainQueryID"].ToString() == "0") && MainQueryID != "" && MainQueryID != "0")
                        {
                            ViewState["MainQueryID"] = MainQueryID;
                        }

                        btnAddQueries.Text = "Add New";
                        ViewState["QueryId"] = "0";

                        ddlAppliedIncenties.SelectedValue = "0";
                        txtQueryRemarks.Text = "";

                        DataSet dsQueryDtls = new DataSet();
                        dsQueryDtls = BindIncentiveQueryDtls(ViewState["IncentiveID"].ToString(), ViewState["MainQueryID"].ToString());

                        if (dsQueryDtls != null && dsQueryDtls.Tables.Count > 1 && dsQueryDtls.Tables[1].Rows.Count > 0 && gvsalesDetails.Rows.Count == 1)
                        {
                            lblLetterNumber.InnerText = dsQueryDtls.Tables[1].Rows[0]["LetterNo"].ToString();
                            lblLetterInitiationDate.InnerText = dsQueryDtls.Tables[1].Rows[0]["LetterDate"].ToString();
                            lblLetterApprovedDate.InnerText = dsQueryDtls.Tables[1].Rows[0]["LetterApprovalDate"].ToString();
                            lblLetterInitiationby.InnerText = dsQueryDtls.Tables[1].Rows[0]["LetterInitiationby"].ToString();
                            divletterdtls.Visible = true;
                            btnGenerateLetter.Visible = true;
                            btnGenerateLetter2.Visible = true;
                        }

                        lblmsg.Text = "Saved Successfully";
                        Failure.Visible = false;
                        success.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        protected void gvsalesDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                ddlAppliedIncenties.SelectedValue = ((Label)(gr.FindControl("lblSubIncentiveID"))).Text;
                txtQueryRemarks.Text = ((Label)(gr.FindControl("lblQuery"))).Text;

                ViewState["QueryId"] = ((Label)(gr.FindControl("lblQueryId"))).Text;
                btnAddQueries.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                QueryGenerationVo objQueryGenerationVo = new QueryGenerationVo();

                objQueryGenerationVo.MainQueryID = ((Label)(gr.FindControl("lblMainQueryID"))).Text;
                objQueryGenerationVo.QueryId = ((Label)(gr.FindControl("lblQueryId"))).Text;
                objQueryGenerationVo.TransType = "DLT";
                objQueryGenerationVo.IncentiveId = ((Label)(gr.FindControl("lblIncentiveId"))).Text;
                objQueryGenerationVo.SubIncentiveID = ((Label)(gr.FindControl("lblSubIncentiveID"))).Text;
                objQueryGenerationVo.Created_by = ObjLoginNewvo.uid;

                string MainQueryID = "0";
                string Validstatus = ObjCAFClass.InsertQueryletterGenerationDetails(objQueryGenerationVo, out MainQueryID);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnAddQueries.Text = "Add New";
                    ViewState["QueryId"] = "0";

                    ddlAppliedIncenties.SelectedValue = "0";
                    txtQueryRemarks.Text = "";

                    BindIncentiveQueryDtls(ViewState["IncentiveID"].ToString(), ViewState["MainQueryID"].ToString());

                    if (gvsalesDetails.Rows.Count < 1)
                    {
                        divletterdtls.Visible = false;
                        btnGenerateLetter.Visible = false;
                        btnGenerateLetter2.Visible = false;
                    }


                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }

            foreach (GridViewRow gvrow in gvsalesDetails.Rows)
            {
                Label lblQueryId = (gvrow.FindControl("lblQueryId") as Label);
                if (lblQueryId.Text.Trim().TrimStart() == "")
                {
                    gvrow.Cells.RemoveAt(4);
                }
                //gvrow.Cells[1].ColumnSpan = 2;
            }
        }

        protected DataSet BindIncentiveQueryDtls(string INCENTIVEID, string MainQueryID)
        {
            DataSet dsnew = new DataSet();
            try
            {
                dsnew = GetIncentiveQuery(INCENTIVEID, MainQueryID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    gvsalesDetails.DataSource = dsnew.Tables[0];
                    gvsalesDetails.DataBind();
                }
                else
                {
                    gvsalesDetails.DataSource = null;
                    gvsalesDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dsnew;
        }

        public DataSet GetIncentiveQuery(string INCENTIVEID, string MainQueryID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar),
                new SqlParameter("@MainQueryID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            pp[1].Value = MainQueryID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_ADMIN_GENERATED_QUERY_DTLS", pp);
            return Dsnew;
        }

        protected void gvsalesDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblQueryId = (e.Row.FindControl("lblQueryId") as Label);
                    Button btnlSaleEdit = (e.Row.FindControl("btnlSaleEdit") as Button);
                    Button btnlSaleDelete = (e.Row.FindControl("btnlSaleDelete") as Button);
                    Label lblSNo = (e.Row.FindControl("lblSNo") as Label);

                    if (lblSNo.Text.Trim().TrimStart() == "0")
                    {
                        lblSNo.Text = "";
                    }
                    if (lblQueryId.Text.Trim().TrimStart() == "")
                    {
                        e.Row.Font.Bold = true;
                        e.Row.Cells.RemoveAt(1);
                        e.Row.Cells[1].ColumnSpan = 2;
                        btnlSaleEdit.Visible = false;
                        btnlSaleDelete.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                //lblmsg0.Text = "Internal error has occured. Please try after some time";
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                // LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        protected void BtnSaveDraft_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in gvsalesDetails.Rows)
            {
                Label lblQueryId = (gvrow.FindControl("lblQueryId") as Label);
                if (lblQueryId.Text.Trim().TrimStart() == "")
                {
                    gvrow.Cells.RemoveAt(4);
                }
                //gvrow.Cells[1].ColumnSpan = 2;
            }

            int slno = 1;
            string ErrorMsg = "";
            try
            {
                foreach (GridViewRow gvrow in gvSubsidy.Rows)
                {
                    DropDownList ddlAction = (gvrow.FindControl("ddlAction") as DropDownList);
                    TextBox txtRemarks = (gvrow.FindControl("txtRemarks") as TextBox);
                    Label lblSNo = (gvrow.FindControl("lblSNo") as Label);

                    string Category = Convert.ToString(DataBinder.Eval(gvrow.DataItem, "Category"));

                    if (Category.Trim().TrimStart() == "")
                    {
                        //if (ddlAction.SelectedValue == "0")
                        //{
                        //    ErrorMsg = ErrorMsg + slno + ". Please Select Action to be Taken at Sno " + lblSNo.Text + " \\n";
                        //    slno = slno + 1;
                        //}
                        //else 
                        if (ddlAction.SelectedValue == "1" && txtRemarks.Text.Trim().TrimStart() == "")
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Enter Remarks at Sno " + lblSNo.Text + " \\n";
                            slno = slno + 1;
                        }
                    }
                }
                if (ErrorMsg != "")
                {
                    string message = "alert('" + ErrorMsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
                else
                {
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    List<AttachmentsQueries> lstAttachmentsQueries = new List<AttachmentsQueries>();

                    foreach (GridViewRow gvrow in gvSubsidy.Rows)
                    {
                        DropDownList ddlAction = (gvrow.FindControl("ddlAction") as DropDownList);
                        TextBox txtRemarks = (gvrow.FindControl("txtRemarks") as TextBox);
                        Label lblAttachmentId = (gvrow.FindControl("lblAttachmentId") as Label);
                        Label lblSubIncentiveId = (gvrow.FindControl("lblSubIncentiveId") as Label);
                        Label lblCAFFlag = (gvrow.FindControl("lblCAFFlag") as Label);
                        if (lblAttachmentId.Text.Trim() != "")
                        {
                            lstAttachmentsQueries.Add(new AttachmentsQueries
                            {
                                MainQueryID = ViewState["MainQueryID"].ToString(),
                                TransType = "INS",
                                IncentiveId = ViewState["IncentiveID"].ToString(),
                                Created_by = ObjLoginNewvo.uid,
                                SubIncentiveID = lblSubIncentiveId.Text,
                                Remarks = txtRemarks.Text.Trim(),
                                AttachmentId = lblAttachmentId.Text.Trim(),
                                ActionTaken = ddlAction.SelectedValue,
                                CAFFlag = lblCAFFlag.Text.Trim()
                            });
                        }
                    }

                    XElement xmlPMUpload = new XElement("xmlAttachmentsQueries_xml",
                    from PMs in lstAttachmentsQueries
                    select new XElement("AttachmentsQueries",
                    new XElement("MainQueryID", PMs.MainQueryID),
                    new XElement("TransType", PMs.TransType),
                    new XElement("IncentiveId", PMs.IncentiveId),
                    new XElement("Created_by", PMs.Created_by),
                    new XElement("SubIncentiveID", PMs.SubIncentiveID),
                    new XElement("Remarks", PMs.Remarks),
                    new XElement("AttachmentId", PMs.AttachmentId),
                    new XElement("ActionTaken", PMs.ActionTaken),
                    new XElement("CAFFlag", PMs.CAFFlag)
                    ));

                    AttachmentsQueriesParent ObjAttachmentsQueriesParent = new AttachmentsQueriesParent();

                    ObjAttachmentsQueriesParent.Created_by = ObjLoginNewvo.uid;
                    ObjAttachmentsQueriesParent.MainQueryID = ViewState["MainQueryID"].ToString();
                    ObjAttachmentsQueriesParent.TransType = "INS";
                    ObjAttachmentsQueriesParent.IncentiveId = ViewState["IncentiveID"].ToString();
                    ObjAttachmentsQueriesParent.xml = xmlPMUpload.ToString();

                    string Status = ObjCAFClass.QueryGenerationAttachemntDetails(ObjAttachmentsQueriesParent);
                    if (Convert.ToInt32(Status) > 0)
                    {
                        string Successmsg = "";
                        Successmsg = "Details Saved Successfully";
                        btnGenerateLetter.Visible = true;
                        btnGenerateLetter2.Visible = true;
                        string message = "alert('" + Successmsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
        protected void gvSubsidy_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbl = (e.Row.FindControl("lbl") as Label);
                    Label lblSNo = (e.Row.FindControl("lblSNo") as Label);

                    DropDownList ddlAction = (e.Row.FindControl("ddlAction") as DropDownList);
                    TextBox txtRemarks = (e.Row.FindControl("txtRemarks") as TextBox);

                    string Category = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Category"));
                    string Actiontaken = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Actiontaken"));

                    if (Category.Trim().TrimStart() != "")
                    {
                        lbl.Text = Category.Trim().TrimStart();
                        e.Row.Font.Bold = true;
                        ddlAction.Visible = false;
                        txtRemarks.Visible = false;
                        lblSNo.Text = "";
                    }
                    else
                    {
                        ddlAction.SelectedValue = Actiontaken;
                        ddlAction.Visible = true;
                        txtRemarks.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                //lblmsg0.Text = "Internal error has occured. Please try after some time";
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                // LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        public DataSet GetIncetiveAttachements(string IncentiveId, string MainQueryID)
        {
            DataSet dsnew1 = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentveID",SqlDbType.Int),
               new SqlParameter("@MainQueryID",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = MainQueryID;

            dsnew1 = ObjCAFClass.GenericFillDs("[USP_GET_ATTACHEMNTS_QUERY]", pp);

            if (dsnew1 != null && dsnew1.Tables.Count > 0 && dsnew1.Tables[0].Rows.Count > 0)
            {
                gvSubsidy.DataSource = dsnew1.Tables[0];
                gvSubsidy.DataBind();
            }
            return dsnew1;
        }
        public DataSet GetIncetiveAttachementsView(string IncentiveId, string MainQueryID)
        {
            DataSet dsnew1 = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentveID",SqlDbType.Int),
               new SqlParameter("@MainQueryID",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = MainQueryID;

            dsnew1 = ObjCAFClass.GenericFillDs("[USP_GET_ATTACHEMNTS_QUERY_VIEW]", pp);
            return dsnew1;
        }
        // Generating Query Letter

        public static string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900);
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }

        public void GeneratePdf()
        {
            try
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                //DataSet dsIncentiveList = new DataSet();
                //dsIncentiveList = Gen.GetAllIncentives(UserID);
                //Session["incentivedata"] = dsIncentiveList;
                string LetterNumber = "";
                string LetterInitiationDate = "";
                string LetterApprovedDate = "";
                string ApplicationNumber = "";
                string ApplicationFiledDate = "";
                string UnitName = "";
                string UnitHNO = "";
                string UnitStreet = "";
                string District_Name = "";
                string Manda_lName = "";
                string Village_Name = "";


                DataSet ds = new DataSet();
                ds = GetIncentiveQuery(ViewState["IncentiveID"].ToString(), ViewState["MainQueryID"].ToString());
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    LetterNumber = ds.Tables[1].Rows[0]["LetterNo"].ToString();
                    LetterInitiationDate = ds.Tables[1].Rows[0]["LetterDate"].ToString();
                    LetterApprovedDate = ds.Tables[1].Rows[0]["LetterApprovalDate"].ToString();
                }
                if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                {
                    ApplicationNumber = ds.Tables[2].Rows[0]["ApplicationNumber"].ToString();
                    ApplicationFiledDate = ds.Tables[2].Rows[0]["ApplicationFiledDate"].ToString();
                    UnitName = ds.Tables[2].Rows[0]["UnitName"].ToString();
                    UnitHNO = ds.Tables[2].Rows[0]["UnitHNO"].ToString();
                    UnitStreet = ds.Tables[2].Rows[0]["UnitStreet"].ToString();
                    District_Name = ds.Tables[2].Rows[0]["District_Name"].ToString();
                    Manda_lName = ds.Tables[2].Rows[0]["Manda_lName"].ToString();
                    Village_Name = ds.Tables[2].Rows[0]["Village_Name"].ToString();
                }

                Document document = new Document(PageSize.A4, 20f, 20f, 20f, 50f);
                Font NormalFont = FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, BaseColor.BLACK);

                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                    Phrase phrase = null;
                    PdfPCell cell = null;
                    PdfPTable table = null;
                    PdfPTable tablenew = null;
                    // BaseColor color = null;

                    document.Open();
                    writer.PageEvent = new Footer();
                    //Header Table
                    PdfContentByte contentBytenew = writer.DirectContent;
                    //table = new PdfPTable(1);
                    //table.TotalWidth = document.PageSize.Width - 60f;
                    //table.SetWidths(new float[] { 1f });
                    //table.LockedWidth = true;

                    table = new PdfPTable(3);
                    table.TotalWidth = document.PageSize.Width - 60f;
                    table.SetWidths(new float[] { 0.1f, 0.8f, 0.1f });
                    table.LockedWidth = true;

                    cell = ImageCell("~/images/logo.png", 6f, PdfPCell.ALIGN_CENTER);
                    cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                    table.AddCell(cell);
                    // trebuchet ms
                    phrase = new Phrase();
                    phrase.Add(new Chunk("Department of Handlooms and Textiles\n\n".ToUpper(), FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    phrase.Add(new Chunk("GOVERNMENT OF TELANGANA", FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
                    cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.Colspan = 2;
                    table.AddCell(cell);

                    phrase = new Phrase();
                    phrase.Add(new Chunk("SHORTFALL INTIMATION LETTER\n", FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    // phrase.Add(new Chunk("\n" + tcMergePackage, FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                    cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.Colspan = 3;
                    cell.PaddingTop = 15f;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    document.Add(table);

                    table = new PdfPTable(2);
                    table.TotalWidth = document.PageSize.Width - 60f;
                    table.SetWidths(new float[] { 0.5f, 0.5f });
                    table.LockedWidth = true;

                    BaseColor colorline = new BaseColor(6, 170, 26);
                    DrawLineMiddleline(writer, 2f, document.Top - 55f, document.PageSize.Width - 2f, document.Top - 55f, colorline);

                    phrase = new Phrase();
                    phrase.Add(new Chunk("File No :" + LetterNumber, FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                    cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                    cell.PaddingTop = 5f;
                    //cell.PaddingBottom = 20f;
                    table.AddCell(cell);


                    phrase = new Phrase();
                    phrase.Add(new Chunk("Dated :" + LetterInitiationDate, FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
                    cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    cell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;

                    cell.PaddingTop = 5f;
                    //cell.PaddingBottom = 20f;
                    table.AddCell(cell);

                    //phrase = new Phrase();
                    //phrase.Add(new Chunk(LetterNumber+ ", Dated: "+ LetterInitiationDate + "\n", FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    //// phrase.Add(new Chunk("\n" + tcMergePackage, FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
                    //cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                    //cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                    //cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    //cell.Colspan = 2;
                    //cell.PaddingTop = 15f;
                    //cell.PaddingBottom = 10f;
                    //table.AddCell(cell);

                    phrase = new Phrase();
                    phrase.Add(new Chunk("To,\n", FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    phrase.Add(new Chunk(UnitName + ",\n", FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));
                    phrase.Add(new Chunk(UnitHNO + ", ", FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));
                    phrase.Add(new Chunk(Village_Name + ", " + Manda_lName + ",\n", FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));
                    phrase.Add(new Chunk(District_Name + ".\n", FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                    cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                    cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    cell.Colspan = 2;
                    cell.PaddingTop = 10f;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);
                    //document.Add(table);


                    phrase = new Phrase();
                    phrase.Add(new Chunk("Dear Sir/Madam,\n", FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));

                    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                    cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                    cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    cell.Colspan = 2;
                    cell.PaddingTop = 15f;
                    //cell.PaddingBottom = 10f;
                    table.AddCell(cell);


                    phrase = new Phrase();
                    phrase.Add(new Chunk("       With Reference to Your T-TAP Incentive Claim Application No. ", FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));
                    phrase.Add(new Chunk(ApplicationNumber + ". Dated " + ApplicationFiledDate, FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    phrase.Add(new Chunk(", It is to Inform You That Your Incentive Claim Applications has been Verified and Found the Following Deficiencies.,\n\n", FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                    cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                    cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    cell.Colspan = 2;
                    cell.PaddingTop = 10f;
                    //cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    document.Add(table);

                    string Slno = "";
                    //string Heading = "";
                    string QueryID = "";
                    string Query = "";
                    DataTable dtQueries = new DataTable();
                    dtQueries.Clear();
                    dtQueries.Columns.Add("SNo");
                    dtQueries.Columns.Add("QueryID");
                    dtQueries.Columns.Add("Query");

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
                        {
                            DataRow Data = dtQueries.NewRow();
                            Data["SNo"] = dr["SNo"].ToString();
                            Data["QueryID"] = dr["QueryId"].ToString();
                            Data["Query"] = dr["Query"].ToString();
                            dtQueries.Rows.Add(Data);
                        }

                        int CountColumns = dtQueries.Columns.Count;

                        tablenew = new PdfPTable(2);
                        tablenew.SetWidths(new float[] { 0.05f, 0.95f });
                        tablenew.TotalWidth = document.PageSize.Width - 60f;
                        tablenew.LockedWidth = true;
                        tablenew.SpacingBefore = 5f;
                        tablenew.HorizontalAlignment = Element.ALIGN_MIDDLE;

                        int RomanNumber = 1;

                        for (int i = 0; i < dtQueries.Rows.Count; i++)
                        {
                            Slno = dtQueries.Rows[i]["SNo"].ToString();
                            QueryID = dtQueries.Rows[i]["QueryID"].ToString();
                            Query = dtQueries.Rows[i]["Query"].ToString();

                            string cellText = "";

                            phrase = new Phrase();

                            if (Slno == "0")
                            {
                                Slno = "";
                                cellText = ToRoman(RomanNumber) + "). " + Query;
                                cellText = Server.HtmlDecode(cellText);
                                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                                //cell.PaddingBottom = 10f;
                                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                                cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                cell.Colspan = 2;
                                cell.PaddingTop = 15f;
                                cell.PaddingBottom = 5;
                                cell.MinimumHeight = 20f;

                                //cell.BorderWidthRight = 0.5f;
                                //cell.BorderWidthLeft = 0.5f;
                                //cell.BorderWidthTop = 0.5f;
                                //cell.BorderWidthBottom = 0.5f;
                                //cell.BorderColorBottom = BaseColor.BLACK;
                                //cell.BorderColorTop = BaseColor.BLACK;
                                //cell.BorderColorLeft = BaseColor.BLACK;
                                //cell.BorderColorRight = BaseColor.BLACK;

                                tablenew.AddCell(cell);
                                RomanNumber = RomanNumber + 1;
                            }
                            else
                            {
                                phrase = new Phrase();
                                cellText = Slno + ". ";
                                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));
                                cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
                                cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                                cell.HorizontalAlignment = Element.ALIGN_RIGHT;

                                cell.PaddingBottom = 10;
                                cell.MinimumHeight = 20f;
                                tablenew.AddCell(cell);

                                phrase = new Phrase();
                                cellText = Server.HtmlDecode(Query);
                                phrase.Add(new Chunk("Query ID :" + QueryID + "\n\n", FontFactory.GetFont("Calibri", 10, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK)));
                                //phrase.SetLeading(1.0f, 3.0f);
                                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));
                                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                                cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                                cell.HorizontalAlignment = Element.ALIGN_LEFT;

                                cell.PaddingBottom = 10;
                                cell.MinimumHeight = 20f;

                                //cell.BorderWidthRight = 0.5f;
                                //cell.BorderWidthLeft = 0.5f;
                                //cell.BorderWidthTop = 0.5f;
                                //cell.BorderWidthBottom = 0.5f;
                                //cell.BorderColorBottom = BaseColor.BLACK;
                                //cell.BorderColorTop = BaseColor.BLACK;
                                //cell.BorderColorLeft = BaseColor.BLACK;
                                //cell.BorderColorRight = BaseColor.BLACK;

                                tablenew.AddCell(cell);
                            }
                        }

                        document.Add(tablenew);

                        DataSet dsattachment = new DataSet();
                        dsattachment = GetIncetiveAttachementsView(ViewState["IncentiveID"].ToString(), ViewState["MainQueryID"].ToString());
                        if (dsattachment != null && dsattachment.Tables.Count > 0 && dsattachment.Tables[0].Rows.Count > 0)
                        {
                            int CountColumns1 = dsattachment.Tables[0].Columns.Count;
                            tablenew = new PdfPTable(CountColumns1); //3
                            tablenew.SetWidths(new float[] { 0.05f, 0.4f, 0.55f });
                            tablenew.TotalWidth = document.PageSize.Width - 60f;
                            tablenew.LockedWidth = true;
                            tablenew.SpacingBefore = 5f;
                            tablenew.HorizontalAlignment = Element.ALIGN_MIDDLE;


                            for (int i = 0; i < CountColumns1; i++)
                            {
                                string cellText = "";
                                cellText = Server.HtmlDecode(dsattachment.Tables[0].Columns[i].ColumnName);
                                phrase = new Phrase();
                                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, BaseColor.BLACK)));
                                cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                                cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#D3D3D3"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
                                cell.PaddingBottom = 5;
                                cell.MinimumHeight = 30f;
                                cell.BorderWidthRight = 0.5f;
                                cell.BorderWidthLeft = 0.5f;
                                cell.BorderWidthTop = 0.5f;
                                cell.BorderWidthBottom = 0.5f;
                                cell.BorderColorBottom = BaseColor.BLACK;
                                cell.BorderColorTop = BaseColor.BLACK;
                                cell.BorderColorLeft = BaseColor.BLACK;
                                cell.BorderColorRight = BaseColor.BLACK;
                                tablenew.AddCell(cell);
                            }
                            for (int i = 0; i < dsattachment.Tables[0].Rows.Count; i++)
                            {
                                string Header = dsattachment.Tables[0].Rows[i]["SNO"].ToString();
                                for (int j = 0; j < CountColumns1; j++)
                                {
                                    string cellText = "";
                                    //HyperLink h4 = null;
                                    phrase = new Phrase();

                                    cellText = Server.HtmlDecode(dsattachment.Tables[0].Rows[i][j].ToString());
                                    if (j == 0 && Header == "0")
                                    {
                                        cellText = "";
                                    }
                                    else if (j == 1 && Header == "0")
                                    {
                                        phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 10, Font.BOLD, BaseColor.BLACK)));
                                    }
                                    else
                                    {
                                        phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 10, Font.NORMAL, BaseColor.BLACK)));
                                    }

                                    if (j == 0)
                                    {
                                        cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                                        cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                    }
                                    else //if (j == 1)
                                    {
                                        cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                                        cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                    }
                                    //else
                                    //{
                                    //    cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
                                    //    cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                                    //    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                                    //}


                                    cell.BorderWidthRight = 0.5f;
                                    cell.BorderWidthLeft = 0.5f;
                                    cell.BorderWidthTop = 0.5f;
                                    cell.BorderWidthBottom = 0.5f;

                                    cell.BorderColorBottom = BaseColor.BLACK;
                                    cell.BorderColorTop = BaseColor.BLACK;
                                    cell.BorderColorLeft = BaseColor.BLACK;
                                    cell.BorderColorRight = BaseColor.BLACK;
                                    if (j == 1 && Header == "0")
                                    {
                                        cell.Colspan = 2;
                                    }
                                    else if (j > 1 && Header == "0")
                                    {
                                        continue;
                                    }
                                    cell.PaddingBottom = 5;
                                    cell.PaddingLeft = 5;
                                    cell.MinimumHeight = 30f;
                                    tablenew.AddCell(cell);
                                }

                                var remainingPageSpace = writer.GetVerticalPosition(false) - document.BottomMargin;
                                var initialPosition = writer.GetVerticalPosition(false);
                                var tablehiht = tablenew.TotalHeight;

                                if (remainingPageSpace >= tablehiht && remainingPageSpace - 50 <= tablehiht)
                                {
                                    BaseColor Color2 = new BaseColor(6, 170, 26);
                                    contentBytenew.SetColorStroke(Color2);
                                    contentBytenew.Circle(document.PageSize.Width - 23f, document.PageSize.Bottom + 23f, 10f);
                                    contentBytenew.Stroke();

                                    ColumnText.ShowTextAligned(contentBytenew, Element.ALIGN_RIGHT, new Phrase((writer.PageNumber).ToString(), FontFactory.GetFont("Trebuchet MS", 12, Font.BOLD, BaseColor.BLACK)), document.PageSize.Width - 20f, document.PageSize.Bottom + 20f, 2);

                                    document.Add(tablenew);
                                    document.NewPage();
                                    tablenew.DeleteBodyRows();

                                    for (int k = 0; k < CountColumns1; k++)
                                    {
                                        string cellText = "";
                                        cellText = Server.HtmlDecode(dsattachment.Tables[0].Columns[k].ColumnName);
                                        phrase = new Phrase();
                                        phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, BaseColor.BLACK)));
                                        cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                                        cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                        cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#D3D3D3"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
                                        cell.PaddingBottom = 5;
                                        cell.MinimumHeight = 30f;
                                        cell.BorderWidthRight = 0.5f;
                                        cell.BorderWidthLeft = 0.5f;
                                        cell.BorderWidthTop = 0.5f;
                                        cell.BorderWidthBottom = 0.5f;
                                        cell.BorderColorBottom = BaseColor.BLACK;
                                        cell.BorderColorTop = BaseColor.BLACK;
                                        cell.BorderColorLeft = BaseColor.BLACK;
                                        cell.BorderColorRight = BaseColor.BLACK;
                                        tablenew.AddCell(cell);
                                    }
                                }
                            }
                            document.Add(tablenew);
                        }

                        tablenew = new PdfPTable(2);
                        tablenew.SetWidths(new float[] { 0.5f, 0.5f });
                        tablenew.TotalWidth = document.PageSize.Width - 60f;
                        tablenew.LockedWidth = true;
                        tablenew.SpacingBefore = 5f;
                        tablenew.HorizontalAlignment = Element.ALIGN_MIDDLE;


                        phrase = new Phrase();
                        phrase.Add(new Chunk("      You are requested to comply the above objections within 45 days from date of communication of this letter, failing which the application shall be rejected.\n\n", FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));

                        cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.Colspan = 2;
                        cell.PaddingTop = 15f;
                        cell.PaddingBottom = 10f;
                        tablenew.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("", FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));
                        cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.PaddingTop = 15f;
                        cell.PaddingBottom = 10f;
                        tablenew.AddCell(cell);

                        phrase = new Phrase();


                        if (ObjLoginNewvo.Role_Code == "DLO")
                        {
                            phrase.Add(new Chunk("Sd/- DLO-" + District_Name + ",\n for Commissioner H&T & AEPs", FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));
                        }
                        else
                        {
                            phrase.Add(new Chunk("Sd/- Tasneem Athar Jahan,\n for Commissioner H&T & AEPs", FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));
                        }
                        cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        //cell.Colspan = 2;
                        cell.PaddingTop = 15f;
                        cell.PaddingBottom = 10f;
                        tablenew.AddCell(cell);

                        if (ObjLoginNewvo.Role_Code != "DLO")
                        {
                            phrase = new Phrase();
                            phrase.Add(new Chunk("Assistant Director (H&T)\n", FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));
                            // phrase.Add(new Chunk("\n" + tcMergePackage, FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
                            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            cell.Colspan = 2;
                            cell.PaddingTop = 15f;
                            cell.PaddingBottom = 10f;
                            tablenew.AddCell(cell);
                        }
                        document.Add(tablenew);
                    }

                    // Page Number
                    BaseColor Color1 = new BaseColor(6, 170, 26);
                    contentBytenew.SetColorStroke(Color1);
                    contentBytenew.Circle(document.PageSize.Width - 23f, document.PageSize.Bottom + 23f, 10f);
                    contentBytenew.Stroke();
                    ColumnText.ShowTextAligned(contentBytenew, Element.ALIGN_RIGHT, new Phrase((writer.PageNumber).ToString(), FontFactory.GetFont("Trebuchet MS", 12, Font.BOLD, BaseColor.BLACK)), document.PageSize.Width - 20f, document.PageSize.Bottom + 20f, 2);
                    //document.Add(tablenew);

                    document.Close();
                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "attachment; filename=Shortfall_" + ApplicationNumber + "_" + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
                    Response.ContentType = "application/pdf";

                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();
                    Response.Close();
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        public partial class Footer : PdfPageEventHelper
        {
            //new Color(127, 127, 127)
            public override void OnEndPage(PdfWriter writer, Document doc)
            {
                Paragraph footer = new Paragraph(char.ConvertFromUtf32(169).ToString() + " Government of Telangana.", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK));
                footer.Alignment = Element.ALIGN_LEFT;
                PdfPTable footerTbl = new PdfPTable(1);
                footerTbl.TotalWidth = 500f;
                footerTbl.HorizontalAlignment = Element.ALIGN_LEFT;
                PdfPCell cell = new PdfPCell(footer);
                cell.Border = 0;
                cell.PaddingLeft = 10;
                footerTbl.AddCell(cell);
                footerTbl.WriteSelectedRows(0, -1, 30, 40, writer.DirectContent);
            }
        }
        private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, BaseColor color)
        {
            PdfContentByte contentByte = writer.DirectContent;
            contentByte.SetColorStroke(color);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.SetLineWidth(1f);
            contentByte.Stroke();
        }
        private static void DrawLineMiddleline(PdfWriter writer, float x1, float y1, float x2, float y2, BaseColor color)
        {
            PdfContentByte contentByte = writer.DirectContent;
            contentByte.SetColorStroke(color);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.SetLineWidth(2f);
            contentByte.Stroke();
        }
        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            //added by chandrika
            //cell.Border = 0;
            //cell.BorderColorLeft = BaseColor.BLACK;
            //cell.BorderWidthLeft = .5f;
            //cell.BorderColorTop = BaseColor.BLACK;
            //cell.BorderWidthTop = .5f;
            //cell.BorderColorBottom = BaseColor.BLACK;
            //cell.BorderWidthBottom = .5f;
            //cell.BorderColorRight = BaseColor.BLACK;
            //cell.BorderWidthRight = .5f;
            //uptohere
            return cell;
        }

        private static PdfPCell PhraseCellnew(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = align;
            //cell.PaddingBottom = 5f;
            //cell.PaddingTop = 5f;
            cell.BorderWidthRight = 0.5f;
            cell.BorderWidthLeft = 0.5f;
            cell.BorderWidthTop = 0.5f;
            cell.BorderWidthBottom = 0.5f;
            cell.BorderColorBottom = BaseColor.BLACK;
            cell.BorderColorTop = BaseColor.BLACK;
            cell.BorderColorLeft = BaseColor.BLACK;
            cell.BorderColorRight = BaseColor.BLACK;
            // cell.MinimumHeight = 30f;
            cell.Padding = 5f;

            return cell;
        }
        private static PdfPCell PhraseCellData(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.BLACK;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.Colspan = 1;
            // cell.Padding = 5;
            // cell.FixedHeight = 25f;
            cell.Border = 0;
            cell.BorderColorLeft = BaseColor.BLACK;
            cell.BorderWidthLeft = .5f;
            cell.BorderColorTop = BaseColor.BLACK;
            cell.BorderWidthTop = .5f;
            cell.BorderColorBottom = BaseColor.BLACK;
            cell.BorderWidthBottom = .5f;
            cell.BorderColorRight = BaseColor.BLACK;
            cell.BorderWidthRight = .5f;
            return cell;
        }
        private static PdfPCell ImageCell(string path, float scale, int align)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
            image.ScalePercent(scale);
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 0f;
            cell.PaddingTop = 0f;

            //cell.BorderColorLeft = BaseColor.BLACK;
            //cell.BorderWidthLeft = .5f;
            //cell.BorderColorTop = BaseColor.BLACK;
            //cell.BorderWidthTop = .5f;
            //cell.BorderColorBottom = BaseColor.BLACK;
            //cell.BorderWidthBottom = .5f;
            //cell.BorderColorRight = BaseColor.BLACK;
            //cell.BorderWidthRight = .5f;

            return cell;
        }
        public string DisplayWithSuffix(int num)
        {
            if (num.ToString().EndsWith("11")) return num.ToString() + "th";
            if (num.ToString().EndsWith("12")) return num.ToString() + "th";
            if (num.ToString().EndsWith("13")) return num.ToString() + "th";
            if (num.ToString().EndsWith("1")) return num.ToString() + "st";
            if (num.ToString().EndsWith("2")) return num.ToString() + "nd";
            if (num.ToString().EndsWith("3")) return num.ToString() + "rd";
            return num.ToString() + "th";
        }
        private static PdfPCell PhraseCellForallheadings(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            cell.Border = 0;
            return cell;
        }
        private static PdfPCell PhraseCellheadings(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            return cell;
        }

        protected void btnGenerateLetter_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in gvsalesDetails.Rows)
            {
                Label lblQueryId = (gvrow.FindControl("lblQueryId") as Label);
                if (lblQueryId.Text.Trim().TrimStart() == "")
                {
                    gvrow.Cells.RemoveAt(4);
                }
                //gvrow.Cells[1].ColumnSpan = 2;
            }
            GeneratePdf();
        }

        protected void ddlApproveaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlApproveaction.SelectedValue == "F")
            {
                divdeptusers.Visible = true;
                ddldeptusers.SelectedValue = "-1";
                btnApprove.Text = "Forward";
            }
            else
            {
                divdeptusers.Visible = false;
                btnApprove.Text = "Approve";
            }
        }
        public DataSet GetHeadOfficeUsers(string UserID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UserId",SqlDbType.VarChar)
            };
            pp[0].Value = UserID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_HEADOFFICE_USERS", pp);
            return Dsnew;
        }
        public void BindHeadOfficeUsers(string UserID)
        {
            ddlAppliedIncenties.Items.Clear();
            DataSet dsapprovals = new DataSet();
            dsapprovals = GetHeadOfficeUsers(UserID);
            if (dsapprovals != null && dsapprovals.Tables.Count > 0 && dsapprovals.Tables[0].Rows.Count > 0)
            {
                ddldeptusers.DataSource = dsapprovals.Tables["Table"];
                ddldeptusers.DataValueField = "intUserid";
                ddldeptusers.DataTextField = "Emp_Name";
                ddldeptusers.DataBind();
            }
            AddSelect(ddldeptusers);
        }
        public string ValidateQueryApprovalProcess()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (ddlApproveaction.SelectedValue == "-1")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Action to be taken \\n";
                slno = slno + 1;
            }

            if (ddldeptusers.SelectedValue == "-1" && ddlApproveaction.SelectedValue == "F")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select User to Transfer \\n";
                slno = slno + 1;
            }
            return ErrorMsg;
        }
        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                //btnGenerateLetter_Click(sender, e);
                if (ViewState["MainQueryID"] == null || ViewState["MainQueryID"].ToString() == "")
                {
                    ViewState["MainQueryID"] = "0";
                }
                string errormsg = ValidateQueryApprovalProcess();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    QueryGenerationVo objQueryGenerationVo = new QueryGenerationVo();

                    objQueryGenerationVo.IncentiveId = ViewState["IncentiveID"].ToString();
                    objQueryGenerationVo.MainQueryID = ViewState["MainQueryID"].ToString();
                    objQueryGenerationVo.TransType = ddlApproveaction.SelectedValue;
                    objQueryGenerationVo.Created_by = ObjLoginNewvo.uid;
                    if (ddlApproveaction.SelectedValue == "F")
                    {
                        objQueryGenerationVo.Transfered = ddldeptusers.SelectedValue;
                    }
                    else if (ddlApproveaction.SelectedValue == "A")
                    {
                        objQueryGenerationVo.Transfered = ObjLoginNewvo.uid;
                    }
                    string Validstatus = ObjCAFClass.InsertQueryletterApprovals(objQueryGenerationVo);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        if (ddlApproveaction.SelectedValue == "F")
                        {
                            lblmsg.Text = "Forwarded Successfully";
                            Failure.Visible = false;
                            success.Visible = true;
                        }
                        else
                        {
                            lblmsg.Text = "File Approved Successfully";
                            Failure.Visible = false;
                            success.Visible = true;
                        }
                        divApprove.Visible = false;
                        BtnSaveDraft.Visible = false;
                        DivSalesDetails.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
    }
}