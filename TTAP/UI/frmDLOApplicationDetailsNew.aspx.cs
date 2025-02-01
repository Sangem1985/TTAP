using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using TTAP.Classfiles;
using System.IO;
using System.Net;

namespace TTAP.UI
{
    public partial class frmDLOApplicationDetailsNew : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();
        CAFClass ObjCAFClass = new CAFClass();
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        DataSet DSIncentiveList = new DataSet();
        string PhaseView = "";
        int TextileMachines;
        decimal TextileMachinesValue;
        int NontextileMachines;
        decimal NontextileMachinesValue;
        decimal TotalMachinaryValue;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Enctype = "multipart/form-data";
            try
            {
                if (!IsPostBack)
                {
                    try
                    {
                        // lbtnback.PostBackUrl = Request.UrlReferrer.AbsoluteUri;
                    }
                    catch (Exception ex)
                    {

                    }
                    if (Session["ObjLoginvo"] != null)
                    {
                        UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                        ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                        string IncentiveId = "0";
                        string Role_Code = ObjLoginNewvo.Role_Code;
                        hdnUserRole.Value = Role_Code;
                        hdnDistId.Value = ObjLoginNewvo.DistrictID;

                        if (Request.QueryString.Count > 0)
                        {
                            if (Request.QueryString["Id"] != null)
                            {
                                IncentiveId = Request.QueryString["Id"].ToString();
                                ViewState["IncentiveId"] = IncentiveId;
                                DataSet dsnew = new DataSet();
                                dsnew = GetapplicationDtls("0", IncentiveId);
                                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                                {
                                    string TSIPassUIDNumber = dsnew.Tables[0].Rows[0]["Uid_NO"].ToString();
                                    hdnUID.Value = dsnew.Tables[0].Rows[0]["Uid_NO"].ToString();
                                    ViewState["UID"] = dsnew.Tables[0].Rows[0]["Uid_NO"].ToString();
                                    string DistrictName = dsnew.Tables[0].Rows[0]["District_Name"].ToString();

                                    mainheading.InnerHtml = "Application - " + dsnew.Tables[0].Rows[0]["UnitName"].ToString().ToUpper() + " (" + dsnew.Tables[0].Rows[0]["ApplicationNumber"].ToString() + ") - Applied on " + dsnew.Tables[0].Rows[0]["SubmissionDate"].ToString();
                                    //System.Web.UI.HtmlControls.HtmlIframe iframeapplication1 = new System.Web.UI.HtmlControls.HtmlIframe();
                                    //iframeapplication1.ID = "iframeapplication1";
                                    // iframeapplication1.Src = "~/UI/Pages/Application.aspx?EntrpId=" + IncentiveId;
                                    iframeapplication1.Src = "~/UI/Pages/frmDraftApplication.aspx?EntrpId=" + IncentiveId;
                                    iframeapplication1.Style["width"] = "100%";
                                    iframeapplication1.Style["height"] = "500px";
                                    //string testts = iframeapplication1.InnerHtml;
                                    //Receipt.Controls.Add(iframeapplication1);

                                    // Payment Details

                                    if (ObjLoginNewvo.Role_Code == "ADPP" || ObjLoginNewvo.Role_Code == "ADMN" || ObjLoginNewvo.Role_Code == "ADDL" || ObjLoginNewvo.Role_Code == "COMM" || ObjLoginNewvo.Role_Code == "JD")
                                    {
                                        divviewpaymentDtls.Visible = true;
                                        HypPayment.NavigateUrl = "~/UI/Pages/frmDeptPaymentApproval.aspx?Id=" + IncentiveId + "&Sts=0";
                                    }
                                    else
                                    {
                                        divviewpaymentDtls.Visible = false;
                                    }

                                    string IndusType = dsnew.Tables[0].Rows[0]["TypeOfIndustry"].ToString();
                                    hdnIndusType.Value = dsnew.Tables[0].Rows[0]["TypeOfIndustry"].ToString();
                                    BindAppliedAnnexures(IncentiveId, ObjLoginNewvo.uid);

                                    if (GvAnnexures.Rows.Count == 1)
                                    {
                                        if (DSIncentiveList != null && DSIncentiveList.Tables.Count > 0 && DSIncentiveList.Tables[0].Rows.Count > 0)
                                        {
                                            string IncentiveType = DSIncentiveList.Tables[0].Rows[0]["Incentive_Type"].ToString();
                                            if (IncentiveType == "3")
                                            {
                                                divplantandmachinaryview.Visible = false;
                                            }
                                        }
                                    }

                                    /*if (IncentiveId == "2063")
                                    {
                                        divPMRatio.Visible = true;
                                    }*/
                                    BindOldApplications(Convert.ToInt32(IncentiveId));
                                    GetIncetiveAttachements(IncentiveId);
                                    GetSnos();
                                    BindTsipassApprovals(TSIPassUIDNumber);
                                    BindCommQueries();
                                    BindQueries();
                                    BindGMHistory();
                                    BindIPOHistory();
                                    BindInspections();
                                    BindReInspections();
                                    BindRecomendedIncentives();
                                    BindDLCApprovedIncentives();
                                    BindDLSVCApprovedIncentives();
                                    //----- JD BINDING
                                    BindJDQueries();
                                    BindJDRecomendedIncentives();
                                    BindJDSenttoDLOIncentives();
                                    BindJDSenttoDLCIncentives();
                                    // ----------------
                                    SpanApplcationStatusHistory.InnerHtml = "Applcation Status History (Inspecting Officer - " + DistrictName + ")";
                                    SpanApplcationStatusHistoryAfterInspection.InnerHtml = "Applcation Status History - After Inspection (Inspecting Officer - " + DistrictName + ")";

                                    SpanApplcationStatusDLCStatus.InnerHtml = "Applcation Status History - DLC (DLO - " + DistrictName + ")";
                                    SpanApplcationStatusSVCStatus.InnerHtml = "Applcation Status History - DL-SVC (DLO - " + DistrictName + ")";
                                    //if (Role_Code == "DLO")
                                    if (Role_Code == "COMM")
                                    {
                                        string AdminVerifiedFlag = dsnew.Tables[0].Rows[0]["AdminVerifiedFlag"].ToString();
                                        if (AdminVerifiedFlag == "" || AdminVerifiedFlag == "P")
                                        {
                                            divcomm.Visible = true;
                                        }
                                        else
                                        {
                                            divcomm.Visible = false;
                                        }
                                        //SpanDLOApplcation.InnerHtml = "Verification of Applcation (DLO - " + DistrictName + ")";
                                    }
                                    if (Role_Code == "GM" && ObjLoginNewvo.DummyLogin.ToString() != "P")
                                    {
                                        BindYetAssignedIncentives(IncentiveId, Role_Code);
                                        BindIPOQueries();
                                        BindGMVerifications();
                                    }
                                    if (Role_Code == "IPO" || Role_Code == "IND" || Role_Code == "DLO" || Role_Code == "DD" || Role_Code == "AD")
                                    {
                                        SpanApplcationStatusDLCStatus.InnerHtml = "Applcation Status History - DLC (" + Role_Code + " - " + DistrictName + ")";
                                        SpanApplcationStatusSVCStatus.InnerHtml = "Applcation Status History - DL-SVC (" + Role_Code + " - " + DistrictName + ")";

                                        SpanDLOApplcation.InnerHtml = "Verification of Applcation (" + Role_Code + " - " + DistrictName + ")";
                                        SpanInspectionReport.InnerHtml = "Update Inspection Report (" + Role_Code + " - " + DistrictName + ")";

                                        BindAppliedIncentives(IncentiveId, Role_Code);
                                        BindPendingInspections(IncentiveId, Role_Code);
                                        BindPendingReInspections(IncentiveId, Role_Code);
                                        if (hdnDistId.Value != "6")
                                        {
                                            //gvUpdateInspectionDetails.Columns[7].Visible = false;
                                        }
                                        SpnAfterInspection.InnerHtml = "Verification of Applcation-After Inspection (DLO - " + DistrictName + ")";
                                        BindCompletedInspectionIncentives(IncentiveId, Role_Code);
                                    }

                                    if (Role_Code == "JD" || Role_Code == "ADDL" || Role_Code == "ADMN")
                                    {
                                        SpanApplcationStatusDLCStatus.InnerHtml = "Applcation Status History - SLC";
                                        SpanApplcationStatusSVCStatus.InnerHtml = "Applcation Status History - SVC";

                                        //SpnJDVerificationOfapplication.InnerHtml = "Verification of Applcation-After Inspection (DLO - " + DistrictName + ")";
                                        BindDLORecomendedIncentives(IncentiveId, Role_Code);
                                    }
                                    if (Role_Code == "IND")
                                    {
                                        // gvUpdateInspectionDetails.Columns[7].Visible = false;
                                        SpanInspectionReport.InnerHtml = "Update Inspection Report (DIC - " + DistrictName + ")";
                                    }
                                    if (Role_Code == "COI-CLERK" || Role_Code == "COI-SUPDT" || Role_Code == "COI-AD" || Role_Code == "COI-DD")
                                    {

                                        // BindRecomendedIncentivesDetails(IncentiveId, Role_Code);
                                    }
                                    BindCoiProcess();
                                    //BindSubIncentives();
                                    // BindCapitalInvestment();
                                }
                            }
                        }

                        //if (Role_Code == "ADMN")
                        //{
                        //    div2.Visible = false;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void BindJDQueries()
        {
            dss = GetJDQueriesById(Convert.ToInt32(Request.QueryString["Id"].ToString()));
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                grdQueriesJD.DataSource = dss.Tables[0];
                grdQueriesJD.DataBind();
                DivQueryDetailsJD.Visible = true;
                divQueriesJD.Visible = true;
            }
            else
            {
                DivQueryDetailsJD.Visible = false;
            }

            if (dss != null && dss.Tables.Count > 1 && dss.Tables[1].Rows.Count > 0)
            {
                grdQueriesResponseJD.DataSource = dss.Tables[1];
                grdQueriesResponseJD.DataBind();
                DivQueryResponseJD.Visible = true;
                divQueriesJD.Visible = true;
            }
            else
            {
                DivQueryResponseJD.Visible = false;
            }

            if (dss != null && dss.Tables.Count > 2 && dss.Tables[2].Rows.Count > 0)
            {
                gvRejectedApplicationsJD.DataSource = dss.Tables[2];
                gvRejectedApplicationsJD.DataBind();
                DivRejectedApplicationsJD.Visible = true;
                divQueriesJD.Visible = true;
            }
            else
            {
                DivRejectedApplicationsJD.Visible = false;
            }
        }
        public void BindQueries()
        {
            dss = GetQueriesById(Convert.ToInt32(Request.QueryString["Id"].ToString()));
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                grdQueries.DataSource = dss;
                grdQueries.DataBind();
                DivQueryDetails.Visible = true;
                divQueries.Visible = true;
            }
            else
            {
                DivQueryDetails.Visible = false;
            }

            if (dss != null && dss.Tables.Count > 1 && dss.Tables[1].Rows.Count > 0)
            {
                grdQueriesResponse.DataSource = dss.Tables[1];
                grdQueriesResponse.DataBind();
                DivQueryResponse.Visible = true;
                divQueries.Visible = true;
            }
            else
            {
                DivQueryResponse.Visible = false;
            }

            if (dss != null && dss.Tables.Count > 2 && dss.Tables[2].Rows.Count > 0)
            {
                gvRejectedApplications.DataSource = dss.Tables[2];
                gvRejectedApplications.DataBind();
                DivRejectedApplications.Visible = true;
                divQueries.Visible = true;
            }
            else
            {
                DivRejectedApplications.Visible = false;
            }
            //----------------------------------------------AFTER INSPECTION QUERY DTLS BINDING -------------------------------------------------

            if (dss != null && dss.Tables.Count > 3 && dss.Tables[3].Rows.Count > 0)
            {
                grdQueriesAfterInspection.DataSource = dss.Tables[3];
                grdQueriesAfterInspection.DataBind();
                DivQueryDetailsAfterInspection.Visible = true;
                divQueriesAfterInspection.Visible = true;
            }
            else
            {
                DivQueryDetailsAfterInspection.Visible = false;
            }

            if (dss != null && dss.Tables.Count > 4 && dss.Tables[4].Rows.Count > 0)
            {
                grdQueriesResponseAfterInspection.DataSource = dss.Tables[4];
                grdQueriesResponseAfterInspection.DataBind();
                DivQueryResponseAfterInspection.Visible = true;
                divQueriesAfterInspection.Visible = true;
            }
            else
            {
                DivQueryResponseAfterInspection.Visible = false;
            }

            if (dss != null && dss.Tables.Count > 5 && dss.Tables[5].Rows.Count > 0)
            {
                gvRejectedApplicationsAfterInspection.DataSource = dss.Tables[5];
                gvRejectedApplicationsAfterInspection.DataBind();
                DivRejectedApplicationsAfterInspection.Visible = true;
                divQueriesAfterInspection.Visible = true;
            }
            else
            {
                DivRejectedApplicationsAfterInspection.Visible = false;
            }
            if (dss != null && dss.Tables.Count >= 7 && dss.Tables[7].Rows.Count > 0)
            {
                gvIPOQueryAfterInsp.DataSource = dss.Tables[7];
                gvIPOQueryAfterInsp.DataBind();

                //gvIPOQueryAfterInsp.DataSource = dss.Tables[7]; CHANIKYA
                //gvIPOQueryAfterInsp.DataBind();
                divIPOQueryAfterInsp.Visible = true;
                divQueriesAfterInspection.Visible = true;
            }
        }
        public void BindInspections()
        {
            dss = GetInspectionsById(Convert.ToInt32(Request.QueryString["Id"].ToString()));
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvInspectionStatus.DataSource = dss;
                gvInspectionStatus.DataBind();
                DivInspectionDetails.Visible = true;
                divQueries.Visible = true;
                bool strKey = Convert.ToBoolean(ConfigurationManager.AppSettings["SysCalamount"].ToString());
                if (strKey == false)
                {
                    gvInspectionStatus.Columns[6].Visible = strKey;
                }
            }
            else
            {
                DivInspectionDetails.Visible = false;
            }
        }
        public void BindReInspections()
        {
            dss = GetReInspectionsById(Convert.ToInt32(Request.QueryString["Id"].ToString()));
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvReInspectionStatus.DataSource = dss;
                gvReInspectionStatus.DataBind();
                DivReInspectionDetails.Visible = true;
                divQueries.Visible = true;
                bool strKey = Convert.ToBoolean(ConfigurationManager.AppSettings["SysCalamount"].ToString());
                if (strKey == false)
                {
                    gvReInspectionStatus.Columns[6].Visible = strKey;
                }
            }
            else
            {
                DivReInspectionDetails.Visible = false;
            }
        }

        //public void BindCapitalInvestment()
        //{
        //    dss = GetCapitalInvestmentById(Convert.ToInt32(Request.QueryString["Id"].ToString()));
        //    if (dss.Tables.Count > 0)
        //    {
        //        if (dss.Tables[0].Rows.Count > 0)
        //        {
        //            grdCapitalFin.DataSource = dss;
        //            grdCapitalFin.DataBind();
        //        }
        //    }
        //}
        public DataSet GetJDQueriesById(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
           };
            pp[0].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_JDQUERIES", pp);
            return Dsnew;
        }

        public DataSet GetQueriesById(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
           };
            pp[0].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_QUERIES", pp);
            return Dsnew;
        }
        public DataSet GetCommQueriesById(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
           };
            pp[0].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_COMM_QUERIES", pp);
            return Dsnew;
        }
        public DataSet GetQueryResponsesById(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
           };
            pp[0].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_QUERIES", pp);
            return Dsnew;
        }
        public DataSet GetSubIncentivesById(int IncentiveId, int status)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@Status",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = status;
            Dsnew = caf.GenericFillDs("USP_GET_SUBINCENTIVEDETAILS", pp);
            return Dsnew;
        }

        public DataSet GetInspectionsById(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
           };
            pp[0].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_INSPECTIONS", pp);
            return Dsnew;
        }
        public DataSet GetReInspectionsById(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
           };
            pp[0].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_REVISED_INSPECTIONS", pp);
            return Dsnew;
        }

        public DataSet GetCapitalInvestmentById(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
           };
            pp[0].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_CAPITAL_INVESTMENT", pp);
            return Dsnew;
        }
        public DataSet GetIPOHistoryById(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
           };
            pp[0].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_IPO_HISTORY", pp);
            return Dsnew;
        }
        public DataSet GetGMHistoryById(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
           };
            pp[0].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_GM_HISTORY", pp);
            return Dsnew;
        }
        public DataSet GetGMVerificationsById(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
           };
            pp[0].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_GM_VERIFICATION_GRIDS", pp);
            return Dsnew;
        }

        protected void ddlAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList lb = (DropDownList)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            TextBox txtRemarks = (TextBox)gvRow.FindControl("txtQuery");
            TextBox txtInsDate = (TextBox)gvRow.FindControl("txtDateofInspection");
            string a = lb.SelectedValue.ToString();

            if (a == "1")
            {
                txtRemarks.Visible = true;
                txtInsDate.Visible = false;
            }
            else if (a == "2")
            {
                txtRemarks.Visible = false;
                txtInsDate.Visible = true;
            }
            else
            {
                txtRemarks.Visible = false;
                txtInsDate.Visible = false;

            }
        }

        //protected void SelectCheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    decimal sum = 0;
        //    foreach (GridViewRow row in grdCapitalFin.Rows)
        //    {
        //        if (row.RowType == DataControlRowType.DataRow)
        //        {
        //            CheckBox chkRow = (row.Cells[0].FindControl("SelectCheckBox") as CheckBox);
        //            if (chkRow.Checked)
        //            {
        //                Label lbl = (Label)row.FindControl("lblFinalCost");
        //                sum = sum + Convert.ToDecimal(lbl.Text);
        //            }
        //        }
        //    }
        //    Label lblTo = grdCapitalFin.FooterRow.FindControl("lblFinalTotal") as Label;
        //    lblTo.Text = sum.ToString();
        //}

        //protected void grdCapitalFin_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        CheckBox chk = (CheckBox)e.Row.FindControl("SelectCheckBox");
        //        int str = e.Row.RowIndex;
        //        if (str == 1 || str == 2 || str == 3 || str == 4 || str == 5 || str == 6 || str == 0)
        //        {
        //            chk.Checked = true;
        //            Label lbl = (Label)e.Row.FindControl("lblFinalCost");
        //            if (str == 0)
        //            {
        //                Session["sum"] = Convert.ToDecimal(lbl.Text);
        //            }
        //            else
        //            {
        //                Session["sum"] = Convert.ToDecimal(Session["sum"]) + Convert.ToDecimal(lbl.Text);
        //            }

        //        }

        //    }
        //    if (e.Row.RowType == DataControlRowType.Footer)
        //    {
        //        Label lblTo = e.Row.FindControl("lblFinalTotal") as Label;
        //        lblTo.Text = Session["sum"].ToString();

        //    }

        //}

        protected void gvSubsidy_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbl = (e.Row.FindControl("lbl") as Label);
                    HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);

                    string Category = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Category"));
                    if (Category.Trim().TrimStart() != "")
                    {
                        lbl.Text = Category.Trim().TrimStart();
                        e.Row.Font.Bold = true;
                        e.Row.Style.Add("color", "#d30000");
                        HyperLinkSubsidy.Visible = false;
                    }

                    if (HyperLinkSubsidy.NavigateUrl == "")
                    {
                        HyperLinkSubsidy.Visible = false;
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

        protected void GVInspectionReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbl = (e.Row.FindControl("lbl") as Label);
                    HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);

                    string Category = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Category"));
                    if (Category.Trim().TrimStart() != "")
                    {
                        lbl.Text = Category.Trim().TrimStart();
                        e.Row.Font.Bold = true;
                        HyperLinkSubsidy.Visible = false;
                    }

                    if (HyperLinkSubsidy.NavigateUrl == "")
                    {
                        HyperLinkSubsidy.Visible = false;
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
        protected void GVReInspectionReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbl = (e.Row.FindControl("lbl") as Label);
                    HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);

                    string Category = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Category"));
                    if (Category.Trim().TrimStart() != "")
                    {
                        lbl.Text = Category.Trim().TrimStart();
                        e.Row.Font.Bold = true;
                        HyperLinkSubsidy.Visible = false;
                    }

                    if (HyperLinkSubsidy.NavigateUrl == "")
                    {
                        HyperLinkSubsidy.Visible = false;
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
        protected void GVRevisedInspectionMemo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbl = (e.Row.FindControl("lbl") as Label);
                    HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);

                    string Category = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Category"));
                    if (Category.Trim().TrimStart() != "")
                    {
                        lbl.Text = Category.Trim().TrimStart();
                        e.Row.Font.Bold = true;
                        HyperLinkSubsidy.Visible = false;
                    }

                    if (HyperLinkSubsidy.NavigateUrl == "")
                    {
                        HyperLinkSubsidy.Visible = false;
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
        protected void QueryUploads_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbl = (e.Row.FindControl("lbl") as Label);
                    HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyQueryUploads") as HyperLink);

                    string Category = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Category"));
                    if (Category.Trim().TrimStart() != "")
                    {
                        lbl.Text = Category.Trim().TrimStart();
                        e.Row.Font.Bold = true;
                        HyperLinkSubsidy.Visible = false;
                    }

                    if (HyperLinkSubsidy.NavigateUrl == "")
                    {
                        HyperLinkSubsidy.Visible = false;
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
        public void GetIncetiveAttachements(string IncentiveId)
        {
            DataSet dsnew1 = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentveID",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;

            dsnew1 = caf.GenericFillDs("[USP_GET_ALLINCENTIVES_APPLICANT]", pp);

            if (dsnew1 != null && dsnew1.Tables.Count > 0 && dsnew1.Tables[0].Rows.Count > 0)
            {
                gvSubsidy.DataSource = dsnew1.Tables[0];
                gvSubsidy.DataBind();
            }
            if (dsnew1 != null && dsnew1.Tables.Count > 1 && dsnew1.Tables[1].Rows.Count > 0)  // Inspection Reports
            {
                GVInspectionReport.DataSource = dsnew1.Tables[1];
                GVInspectionReport.DataBind();
                divUploadedInspection.Visible = true;
            }
            if (dsnew1 != null && dsnew1.Tables.Count > 2 && dsnew1.Tables[2].Rows.Count > 0)  // Query Responce Uploads
            {
                gvQueryUploads.DataSource = dsnew1.Tables[2];
                gvQueryUploads.DataBind();
                divQueryUploads.Visible = true;
            }
            if (dsnew1 != null && dsnew1.Tables.Count > 2 && dsnew1.Tables[3].Rows.Count > 0)  // Not Uploaded
            {
                gvnotuploaded.DataSource = dsnew1.Tables[3];
                gvnotuploaded.DataBind();
                divNotUploaded.Visible = true;
            }
            if (dsnew1 != null && dsnew1.Tables.Count > 2 && dsnew1.Tables[4].Rows.Count > 0)  // Revised Inspection Reports
            {
                GVReInspectionReport.DataSource = dsnew1.Tables[4];
                GVReInspectionReport.DataBind();
                divUploadedRevisedInspections.Visible = true;
            }
            if (dsnew1 != null && dsnew1.Tables.Count > 2 && dsnew1.Tables[5].Rows.Count > 0)  // Inspection Images
            {
                GVInspectionImages.DataSource = dsnew1.Tables[5];
                GVInspectionImages.DataBind();
                divInspectionImages.Visible = true;
            }
            if (dsnew1 != null && dsnew1.Tables.Count > 2 && dsnew1.Tables[6].Rows.Count > 0)  // Inspection Images
            {
                GVRevisedInspectionMemo.DataSource = dsnew1.Tables[6];
                GVRevisedInspectionMemo.DataBind();
                divRevisedInspectionMemo.Visible = true;
            }
            if (dsnew1 != null && dsnew1.Tables.Count > 2 && dsnew1.Tables[7].Rows.Count > 0)
            {
                gvJointInspectionReport.DataSource = dsnew1.Tables[7];
                gvJointInspectionReport.DataBind();
                divJointInspectionReport.Visible = true;
            }
        }
        public void GetSnos()
        {
            int slno = 0;
            foreach (GridViewRow row in gvSubsidy.Rows)
            {
                string Date = (row.FindControl("lblverified") as Label).Text;
                if (Date != "")
                {
                    slno = slno + 1;
                    row.Cells[0].Text = Convert.ToString(slno);
                }
                else
                {
                    row.Cells[0].Text = "";
                }
            }
        }


        public void BindAppliedAnnexures(string INCENTIVEID, string USERID)
        {
            DataSet ds = new DataSet();
            ds = GetAppliedAnnexures(INCENTIVEID, USERID);
            DSIncentiveList = ds;
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                GvAnnexures.DataSource = ds.Tables[0];
                GvAnnexures.DataBind();
            }
        }

        public DataSet GetAppliedAnnexures(string INCENTIVEID, string USERID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.VarChar),
                new SqlParameter("@USERID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            pp[1].Value = USERID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_APPLIED_INCENTIVE_ANNEXURES", pp);
            return Dsnew;
        }

        public void BindTsipassApprovals(string UIDNumber)
        {

            DataSet dsapprovals = new DataSet();
            TSIPASSSERVICE.DepartmentApprovalSystem IpassDataCFE = new TSIPASSSERVICE.DepartmentApprovalSystem();
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
            SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            string outputCFE = IpassDataCFE.GetTSIPASSTrackeronUIDnumber(UIDNumber, "");
            DataSet theDataSetCFE = new DataSet();
            if (outputCFE != "<NewDataSet />")
            {
                string xmlCFE = "<NewDataSet>" + ' ' + outputCFE + ' ' + "</NewDataSet>";
                StringReader Reader = new StringReader(xmlCFE);

                theDataSetCFE.ReadXml(Reader);
                dsapprovals = theDataSetCFE;
            }
            /*dsapprovals = GetApplicationTrackerDetailed_CFE(UIDNumber);*/

            if (dsapprovals != null && dsapprovals.Tables.Count > 0 && dsapprovals.Tables[1].Rows.Count > 0)
            {
                gvtsipassapprovals.DataSource = dsapprovals.Tables[1];
                gvtsipassapprovals.DataBind();
            }
        }
        public DataSet GetApplicationTrackerDetailed_CFE(string UIDNO)
        {
            DataRetrivalClass dataRetrivalClass = new DataRetrivalClass();
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UIDNOTTAP",SqlDbType.VarChar)
           };
            pp[0].Value = UIDNO;
            Dsnew = dataRetrivalClass.GenericFillDs("[USP_GET_CFETRACKER_DTLS_TTAP]", pp);
            return Dsnew;
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

        public void BindAppliedIncentives(string incentiveID, string RoleCode)
        {
            ddlAppliedIncenties.Items.Clear();
            DataSet dsapprovals = new DataSet();
            dsapprovals = GetIncetiveDropDownList(incentiveID, RoleCode);
            if (dsapprovals != null && dsapprovals.Tables.Count > 0 && dsapprovals.Tables[0].Rows.Count > 0)
            {
                div2.Visible = true;
                ddlAppliedIncenties.DataSource = dsapprovals.Tables["Table"];
                ddlAppliedIncenties.DataValueField = "SubIncentiveID";
                ddlAppliedIncenties.DataTextField = "IncentiveName";
                ddlAppliedIncenties.DataBind();
            }
            else
            {
                div2.Visible = false;
            }
            AddSelect(ddlAppliedIncenties);
        }
        public void BindYetAssignedIncentives(string incentiveID, string RoleCode)
        {
            DataSet dsInc = new DataSet();
            dsInc = GetIncetiveDropDownList(incentiveID, RoleCode);
            if (dsInc != null && dsInc.Tables.Count > 0 && dsInc.Tables[0].Rows.Count > 0)
            {
                divGMVerification.Visible = true;
                GvYetAssign.DataSource = dsInc.Tables[0];
                GvYetAssign.DataBind();
                divBeforeAssign.Visible = true;
                GetInspectingOfficers();
            }
            else
            {
                GvYetAssign.DataSource = null;
                GvYetAssign.DataBind();
                divGMVerification.Visible = false;
                divBeforeAssign.Visible = false;
            }
        }
        public void BindIPOQueries()
        {
            DataSet dsIPO = new DataSet();
            dsIPO = GetQueriesById(Convert.ToInt32(Request.QueryString["Id"].ToString()));
            if (dsIPO != null && dsIPO.Tables.Count > 0 && dsIPO.Tables[0].Rows.Count > 0)
            {
                divGMVerification.Visible = true;
                gvQueriesFromIPO.DataSource = dsIPO;
                gvQueriesFromIPO.DataBind();
                divIPOQueryBeforeInsp.Visible = true;
                divQueriesFromIPO.Visible = true;
            }
            else
            {
                gvQueriesFromIPO.DataSource = null;
                gvQueriesFromIPO.DataBind();
                divIPOQueryBeforeInsp.Visible = false;
                divQueriesFromIPO.Visible = false;
            }
            if (dsIPO.Tables[6].Rows.Count > 0)
            {
                divGMVerification.Visible = true;
                gvGMActionIPOQueryAfterInsp.DataSource = dsIPO.Tables[6];
                gvGMActionIPOQueryAfterInsp.DataBind();
                divGMActionIPOQueryAfterInsp.Visible = true;
                //divQueriesFromIPO.Visible = true;
            }
            else
            {
                gvGMActionIPOQueryAfterInsp.DataSource = null;
                gvGMActionIPOQueryAfterInsp.DataBind();
                divGMActionIPOQueryAfterInsp.Visible = false;
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
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_APPLIEDINCENTIVES_DROPDOWNLIST", pp);
            return Dsnew;
        }
        public DataSet GetIPOQueriesBeforeInsp(string incentiveID, string RoleCode)
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
        public DataSet GetInspctionCompletedIncetiveDropDownList(string incentiveID, string RoleCode)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentveID",SqlDbType.VarChar),
               new SqlParameter("@RoleCode",SqlDbType.VarChar)
            };
            pp[0].Value = incentiveID;
            pp[1].Value = RoleCode;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_INSPECTIONCOMPLETEDINCENTIVES_LIST", pp);
            return Dsnew;
        }
        /*  public void BindFinancialYears(int IncentiveId, int SubIncentiveId)
          {
              ddlHalfyear.Items.Clear();
              DataSet dsapprovals = new DataSet();
              dsapprovals = GetFinancialYears(IncentiveId, SubIncentiveId);
              if (dsapprovals != null && dsapprovals.Tables.Count > 0 && dsapprovals.Tables[0].Rows.Count > 0)
              {

                  ddlHalfyear.DataSource = dsapprovals.Tables[0];
                  ddlHalfyear.DataValueField = "TypeOfFinancialYear";
                  ddlHalfyear.DataTextField = "FinancialYearText";
                  ddlHalfyear.DataBind();
              }
              else
              {

              }
              AddSelect(ddlHalfyear);
          }*/
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }
        }
        protected void gvtsipassapprovals_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string Statusid = DataBinder.Eval(e.Row.DataItem, "intStageid").ToString();
                    if (Statusid != "")
                    {
                        int Statusidnew = Convert.ToInt32(Statusid);
                        if (Statusidnew == 13 || Statusidnew == 14 || Statusidnew == 15 || Statusidnew == 16 || Statusidnew == 22 || Statusidnew == 11)
                        {
                            e.Row.FindControl("lblverified").Visible = false;
                            e.Row.FindControl("HyperLinkSubsidy").Visible = true;
                            e.Row.FindControl("HyperLinkSubsidyAlterNate").Visible = true;
                        }
                        else
                        {
                            e.Row.FindControl("lblverified").Visible = true;
                            e.Row.FindControl("HyperLinkSubsidy").Visible = false;
                            e.Row.FindControl("HyperLinkSubsidyAlterNate").Visible = false;
                        }
                        if (((HyperLink)e.Row.FindControl("HyperLinkSubsidy")).NavigateUrl == "")
                        {
                            e.Row.FindControl("lblverified").Visible = true;
                            e.Row.FindControl("HyperLinkSubsidy").Visible = false;
                            e.Row.FindControl("HyperLinkSubsidyAlterNate").Visible = false;
                        }
                    }
                    if ((Session["uid"].ToString() == "1222" || Session["uid"].ToString() == "1238" || Session["uid"].ToString() == "3377"))
                    {
                        string intApprovalid = DataBinder.Eval(e.Row.DataItem, "intApprovalid").ToString();
                        if ((intApprovalid == "6" || intApprovalid == "45") && Statusid != "22" && Statusid != "2" && Statusid != "1")
                        {
                            e.Row.FindControl("lblapprovalname").Visible = false;
                            e.Row.FindControl("hplkapprovalsname").Visible = true;
                        }
                        else
                        {
                            e.Row.FindControl("lblapprovalname").Visible = true;
                            e.Row.FindControl("hplkapprovalsname").Visible = false;
                        }
                    }
                    else
                    {
                        e.Row.FindControl("lblapprovalname").Visible = true;
                        e.Row.FindControl("hplkapprovalsname").Visible = false;
                    }
                    string Text = ((Label)e.Row.FindControl("lblText")).Text.ToString();
                    string CFEID = ((Label)e.Row.FindControl("lblcfeid")).Text.ToString();
                    if (Text.Contains("ipass.telangana.gov.in/Attachments") == true)
                    {
                        ((HyperLink)e.Row.FindControl("HyperLinkSubsidy")).Attributes["href"] = "../UI/Pages/FileApi.aspx?filepath=" + HttpUtility.UrlEncode(Text) + "&cfeid=" + CFEID + "&module=CFE";
                        //((HyperLink)e.Row.FindControl("HyperLinkSubsidy")).Attributes["href"] = HttpUtility.UrlEncode("/UI/Pages/FileApi.aspx?filepath=" + Text + "&cfeid=" + CFEID + "&module=CFE");
                    }
                }
            }
            catch (Exception ex)
            {
                //lblmsg0.Text = "Internal error has occured. Please try after some time";
                lblmsg.Text = ex.Message;
            }
        }

        protected void Rbtnstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            divQuery.Visible = false;
            divQueryLetter.Visible = false;
            divInspectionDate.Visible = false;

            if (Rbtnstatus.SelectedValue == "1")
            {
                divQuery.Visible = false;
                divQueryLetter.Visible = false;
                divInspectionDate.Visible = true;
            }
            else if (Rbtnstatus.SelectedValue == "2")
            {
                divQuery.Visible = true;
                divQueryLetter.Visible = true;
                divInspectionDate.Visible = false;
                lblQueryStatus.InnerHtml = "Query";
            }
            else if (Rbtnstatus.SelectedValue == "3")
            {
                divQuery.Visible = true;
                divQueryLetter.Visible = false;
                divInspectionDate.Visible = false;
                lblQueryStatus.InnerHtml = "Remarks";
            }
        }

        public string ValidateControls()
        {
            int slno = 1;
            string ErrorMsg = "";
            if (ddlAppliedIncenties.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Incentive \\n";
                slno = slno + 1;
            }
            if (Rbtnstatus.SelectedIndex == -1)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Application Status \\n";
                slno = slno + 1;
            }
            if (fuQueryLetter.HasFile)
            {
                string Mimetype = objClsFileUpload.getmimetype(fuQueryLetter);
                if (Mimetype != "application/pdf")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select pdf files only \\n";
                    slno = slno + 1;
                }
            }

            if (Rbtnstatus.SelectedValue == "1")
            {
                if (txtAppDateofInspection.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Inspection Date \\n";
                    slno = slno + 1;
                }
                else
                {
                    string Inspdate = GetFromatedDateDDMMYYYY(txtAppDateofInspection.Text.Trim().TrimStart());
                    if (ViewState["CURRENTDATE"] != null)
                    {
                        if (Convert.ToDateTime(ViewState["CURRENTDATE"].ToString()) > Convert.ToDateTime(Inspdate))
                        {
                            ErrorMsg = ErrorMsg + slno + ". Inspection Date Should be Futer Date \\n";
                            slno = slno + 1;
                        }
                    }
                }
            }
            else if (Rbtnstatus.SelectedValue == "2")
            {
                if (txtQueryRemarks.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Query Remarks \\n";
                    slno = slno + 1;
                }
            }
            else if (Rbtnstatus.SelectedValue == "3")
            {
                if (txtQueryRemarks.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Rejected Remarks \\n";
                    slno = slno + 1;
                }
            }
            return ErrorMsg;
        }

        public string GetDecimalNullValue(string Input)
        {
            string InputValue = "";

            InputValue = (Input != "") ? Input : "0";

            return InputValue;
        }
        public string GetFromatedDateDDMMYYYY(string Date)
        {
            string Dateformat = "";
            string[] Ld6 = null;
            string ConvertedDt56 = "";
            if (Date != "")
            {
                Ld6 = Date.Split('/');
                ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();
                Dateformat = ConvertedDt56;
            }
            else
            {
                Dateformat = null;
            }
            return Dateformat;
        }
        protected void btnProcessApplication_Click(object sender, EventArgs e)
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

                    ObjApplicationStatus.IncentiveId = ViewState["IncentiveId"].ToString();
                    ObjApplicationStatus.SubIncentiveId = ddlAppliedIncenties.SelectedValue;
                    ObjApplicationStatus.CreatedBy = ObjLoginNewvo.uid;
                    ObjApplicationStatus.TransType = Rbtnstatus.SelectedValue;
                    if (txtAppDateofInspection.Text.Trim().TrimStart() != "")
                    {
                        ObjApplicationStatus.InspectionDate = GetFromatedDateDDMMYYYY(txtAppDateofInspection.Text.Trim().TrimStart());
                    }
                    ObjApplicationStatus.Remarks = txtQueryRemarks.Text.Trim().TrimStart();
                    if (fuQueryLetter.HasFile)
                    {
                        HyperLink hypconcernedCTo = new HyperLink();
                        string Attachmentidnew = ObjApplicationStatus.IncentiveId + "020" + ObjApplicationStatus.SubIncentiveId + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                        string OutPut = objClsFileUpload.IncentiveFileUploadingQuery("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuQueryLetter, hypconcernedCTo, ObjLoginNewvo.Role_Code + "QueryLetter", ObjApplicationStatus.IncentiveId, ObjApplicationStatus.SubIncentiveId, Attachmentidnew, Session["uid"].ToString(), "OFFICER", "0", "QueryLetter");
                        ObjApplicationStatus.QueryLetterID = OutPut;
                    }

                    string Status = ObjCAFClass.UpdateApplicationStatusDLOStage1(ObjApplicationStatus);

                    if (Convert.ToInt32(Status) > 0)
                    {
                        string Successmsg = "";
                        BindYetAssignedIncentives(ViewState["IncentiveId"].ToString(), ObjLoginNewvo.Role_Code);
                        BindAppliedIncentives(ViewState["IncentiveId"].ToString(), ObjLoginNewvo.Role_Code);
                        BindQueries();
                        BindInspections();
                        BindReInspections();
                        ddlAppliedIncenties.SelectedValue = "0";
                        txtAppDateofInspection.Text = "";
                        txtQueryRemarks.Text = "";
                        string TransactionId = ""; string SubModule = "";
                        if (Rbtnstatus.SelectedValue == "1")
                        {
                            Successmsg = "Inspection Date Scheduled Successfully";
                            TransactionId = "4";
                            SubModule = "INSPECTION";
                        }
                        else if (Rbtnstatus.SelectedValue == "2")
                        {
                            TransactionId = "5";
                            Successmsg = "Query Raised Successfully";
                            SubModule = "QUERYRAISED";
                        }
                        else if (Rbtnstatus.SelectedValue == "3")
                        {
                            TransactionId = "7";
                            Successmsg = "Application Rejected Successfully";
                            SubModule = "REJECTED";
                        }

                        string msg = "";
                        string IncentiveId = ViewState["IncentiveId"].ToString();
                        string SubIncentiveId = ddlAppliedIncenties.SelectedValue;
                        ObjApplicationStatus.TransType = Rbtnstatus.SelectedValue;
                        try
                        {
                            ClsSMSandMail ClsSMSandMailobj = new ClsSMSandMail();
                            /*msg = ClsSMSandMailobj.SendSmsWebService(IncentiveId, SubIncentiveId, "Incentives", TransactionId, SubModule);*/
                            if (Rbtnstatus.SelectedValue == "3")
                            {
                                /*msg = ClsSMSandMailobj.SendSmsWebService(IncentiveId, SubIncentiveId, "Incentives", "8", SubModule);*/
                            }
                        }
                        catch (Exception ex)
                        {
                            string errorMsg = ex.Message;
                        }

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

        public void BindPendingInspections(string incentiveID, string RoleCode)
        {
            dss = GetPendingInspectionsById(incentiveID, RoleCode);
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                hdnInspection.Value = "Y";
                gvUpdateInspectionDetails.DataSource = dss;
                gvUpdateInspectionDetails.DataBind();
                divmainUpdateInspectionDetails.Visible = true;
                DivUpdateInspectionDetails.Visible = true;
            }
            else
            {
                divmainUpdateInspectionDetails.Visible = false;
                DivUpdateInspectionDetails.Visible = false;
            }
        }
        public void BindPendingReInspections(string incentiveID, string RoleCode)
        {
            dss = GetPendingReInspectionsById(incentiveID, RoleCode);
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {

                gvUpdateReInspectionDetails.DataSource = dss;
                gvUpdateReInspectionDetails.DataBind();
                divmainUpdateInspectionDetails.Visible = true;
                DivUpdateReInspectionDetails.Visible = true;
            }
            else
            {
                if (hdnInspection.Value == "Y")
                {
                    divmainUpdateInspectionDetails.Visible = true;
                }
                else
                {
                    divmainUpdateInspectionDetails.Visible = false;
                }
                DivUpdateReInspectionDetails.Visible = false;
            }
        }

        public DataSet GetPendingInspectionsById(string IncentiveId, string RoleCode)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.VarChar),
               new SqlParameter("@RoleCode",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = RoleCode;
            Dsnew = caf.GenericFillDs("USP_GET_PENDING_INSPECTIONS_DLO", pp);
            return Dsnew;
        }
        public DataSet GetPendingReInspectionsById(string IncentiveId, string RoleCode)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.VarChar),
               new SqlParameter("@RoleCode",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = RoleCode;
            Dsnew = caf.GenericFillDs("USP_GET_PENDING_REINSPECTIONS_DLO", pp);
            return Dsnew;
        }

        protected void gvUpdateInspectionDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink hyperLink = (e.Row.FindControl("anchortaglinkView") as HyperLink);
                HyperLink hyperLink1 = (e.Row.FindControl("anchDownloadDraftInspectionReport") as HyperLink);
                HyperLink HyperLinkDelay = (e.Row.FindControl("anchortaglinkInspDelay") as HyperLink);

                Label IncentiveID = (e.Row.FindControl("lblIncentiveID") as Label);
                Label MstIncentiveId = (e.Row.FindControl("lblSubIncentiveId") as Label);
                Label lblInspflag = (e.Row.FindControl("lblInspflag") as Label);
                Label lblIndDeptFlag = (e.Row.FindControl("lblIndDeptFlag") as Label);
                Label lblInspectionId = (e.Row.FindControl("lblInspectionId") as Label);
                Button Button1 = (e.Row.FindControl("btnIndustries") as Button);
                hyperLink.NavigateUrl = "~/UI/Pages/frmInspectionRpt.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();

                hyperLink1.NavigateUrl = "~/UI/Pages/Annexures/DraftfrmInspectionRptView.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                hyperLink1.Visible = false;
                hyperLink.Visible = false;
                if (lblInspflag.Text.Trim().TrimStart() == "O")
                {
                    hyperLink.Visible = true;
                    hyperLink1.Visible = true;
                }
                if (lblIndDeptFlag.Text == "P" || lblIndDeptFlag.Text == "C")
                {
                    Button1.Enabled = false;
                }
                if (lblIndDeptFlag.Text == "C" && hdnUserRole.Value == "IND")
                {
                    hyperLink.Text = "View Report";
                }

                HyperLinkDelay.NavigateUrl = "~/UI/Pages//InspectionDelayNotes.aspx?IncentiveId=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart() + "&InspectionId=" + lblInspectionId.Text.Trim().TrimStart();

                /* if (MstIncentiveId.Text.Trim().TrimStart() == "1")
                 {
                     hyperLink.NavigateUrl = "~/UI/Pages/frmInspectionRpt.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                 }
                 else if (MstIncentiveId.Text.Trim().TrimStart() == "2")
                 {
                     hyperLink.NavigateUrl = "frmInspectionRpt.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                 }
                 else if (MstIncentiveId.Text.Trim().TrimStart() == "3")
                 {
                     hyperLink.NavigateUrl = "frmInspectionRpt.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                 }
                 else if (MstIncentiveId.Text.Trim().TrimStart() == "4")
                 {
                     hyperLink.NavigateUrl = "frmInspectionRpt.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                 }
                 else if (MstIncentiveId.Text.Trim().TrimStart() == "5")
                 {
                     hyperLink.NavigateUrl = "frmInspectionRpt.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                 }
                 else if (MstIncentiveId.Text.Trim().TrimStart() == "6")
                 {
                     hyperLink.NavigateUrl = "frmInspectionRpt.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                 }
                 else if (MstIncentiveId.Text.Trim().TrimStart() == "7")
                 {
                     hyperLink.NavigateUrl = "frmInspectionRpt.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                 }
                 else if (MstIncentiveId.Text.Trim().TrimStart() == "8")
                 {
                     hyperLink.NavigateUrl = "frmInspectionRpt.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                 }
                 else if (MstIncentiveId.Text.Trim().TrimStart() == "9")
                 {
                     hyperLink.NavigateUrl = "frmInspectionRpt.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                 }
                 else if (MstIncentiveId.Text.Trim().TrimStart() == "10")
                 {
                     hyperLink.NavigateUrl = "frmInspectionRpt.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                 }
                 else if (MstIncentiveId.Text.Trim().TrimStart() == "11")
                 {
                     hyperLink.NavigateUrl = "frmInspectionRpt.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                 }
                 else if (MstIncentiveId.Text.Trim().TrimStart() == "12")
                 {
                     hyperLink.NavigateUrl = "frmInspectionRpt.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                 }
                 else if (MstIncentiveId.Text.Trim().TrimStart() == "13")
                 {
                     hyperLink.NavigateUrl = "frmInspectionRpt.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                 }
                 else if (MstIncentiveId.Text.Trim().TrimStart() == "14")
                 {
                     hyperLink.NavigateUrl = "frmInspectionRpt.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                 }
                 else if (MstIncentiveId.Text.Trim().TrimStart() == "15")
                 {
                     hyperLink.NavigateUrl = "frmInspectionRpt.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                 }
                 else if (MstIncentiveId.Text.Trim().TrimStart() == "16")
                 {
                     hyperLink.NavigateUrl = "frmInspectionRpt.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                 }
                 else if (MstIncentiveId.Text.Trim().TrimStart() == "17")
                 {
                     hyperLink.NavigateUrl = "frmInspectionRpt.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                 }
                 else if (MstIncentiveId.Text.Trim().TrimStart() == "18")
                 {
                     hyperLink.NavigateUrl = "frmInspectionRpt.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                 }*/
            }
        }

        protected void gvUpdateReInspectionDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink hyperLink = (e.Row.FindControl("ReanchortaglinkView") as HyperLink);
                HyperLink hyperLink1 = (e.Row.FindControl("anchDownloadDraftInspectionReport") as HyperLink);

                Label IncentiveID = (e.Row.FindControl("lblIncentiveID") as Label);
                Label MstIncentiveId = (e.Row.FindControl("lblSubIncentiveId") as Label);
                Label lblInspflag = (e.Row.FindControl("lblInspflag") as Label);
                hyperLink.NavigateUrl = "~/UI/Pages/frmReInspectionReport.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();

                hyperLink1.NavigateUrl = "~/UI/Pages/Annexures/DraftfrmInspectionRptView.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                hyperLink1.Visible = false;
                hyperLink.Visible = false;
                if (lblInspflag.Text.Trim().TrimStart() == "O")
                {
                    hyperLink.Visible = true;
                    hyperLink1.Visible = true;
                }
            }
        }

        protected void gvInspectionStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink hyperLink = (e.Row.FindControl("anchortaglinkView") as HyperLink);
                //HyperLink hyperLink1 = (e.Row.FindControl("anchDownloadDraftInspectionReport") as HyperLink);

                Label IncentiveID = (e.Row.FindControl("lblIncentiveID") as Label);
                Label MstIncentiveId = (e.Row.FindControl("lblSubIncentiveId") as Label);
                Label lblInspflag = (e.Row.FindControl("lblInspflag") as Label);

                hyperLink.NavigateUrl = "~/UI/Pages/Annexures/frmInspectionRptView.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                //hyperLink1.NavigateUrl = "~/UI/Pages/Annexures/DraftfrmInspectionRptView.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();
                //hyperLink1.Visible = false;
                if (lblInspflag.Text.Trim().TrimStart() == "O")
                {
                    hyperLink.Visible = false;
                    //hyperLink1.Visible = true;
                }
            }
        }
        protected void gvReInspectionStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink hyperLink = (e.Row.FindControl("anchortaglinkViewRep") as HyperLink);

                Label IncentiveID = (e.Row.FindControl("lblIncentiveID") as Label);
                Label MstIncentiveId = (e.Row.FindControl("lblSubIncentiveId") as Label);
                Label lblInspflag = (e.Row.FindControl("lblInspflag") as Label);

                hyperLink.NavigateUrl = "~/UI/Pages/Annexures/frmRevisedInspectionRptViewaspx.aspx?IncentiveID=" + IncentiveID.Text + "&SubIncentiveId=" + MstIncentiveId.Text.Trim().TrimStart();

                if (lblInspflag.Text.Trim().TrimStart() == "O")
                {
                    hyperLink.Visible = false;
                }
            }
        }

        public void BindCompletedInspectionIncentives(string incentiveID, string RoleCode)
        {
            ddlInspectionCompletedIncentives.Items.Clear();
            DataSet dsapprovals = new DataSet();
            dsapprovals = GetInspctionCompletedIncetiveDropDownList(incentiveID, RoleCode);
            if (dsapprovals != null && dsapprovals.Tables.Count > 0 && dsapprovals.Tables[0].Rows.Count > 0)
            {
                ViewState["InspectionCompletedIncentives"] = dsapprovals;
                divInspectionCompleted.Visible = true;
                ddlInspectionCompletedIncentives.DataSource = dsapprovals.Tables["Table"];
                ddlInspectionCompletedIncentives.DataValueField = "SubIncentiveID";
                ddlInspectionCompletedIncentives.DataTextField = "IncentiveName";
                ddlInspectionCompletedIncentives.DataBind();

            }
            else
            {
                ViewState["InspectionCompletedIncentives"] = null;
                divInspectionCompleted.Visible = false;
            }
            AddSelect(ddlInspectionCompletedIncentives);

            btnAfterInspection.Enabled = false;
        }

        public void BindDLORecomendedIncentives(string incentiveID, string RoleCode)
        {
            ddlDLORecommendedIncentives.Items.Clear();
            DataSet dsapprovals = new DataSet();
            dsapprovals = GetInspctionCompletedIncetiveDropDownList(incentiveID, RoleCode);
            if (dsapprovals != null && dsapprovals.Tables.Count > 0 && dsapprovals.Tables[0].Rows.Count > 0)
            {
                ViewState["divInspectionCompleted"] = dsapprovals;
                divJDVerificationOfapplication.Visible = true;
                ddlDLORecommendedIncentives.DataSource = dsapprovals.Tables["Table"];
                ddlDLORecommendedIncentives.DataValueField = "SubIncentiveID";
                ddlDLORecommendedIncentives.DataTextField = "IncentiveName";
                ddlDLORecommendedIncentives.DataBind();

            }
            else
            {
                ViewState["divInspectionCompleted"] = null;
                divJDVerificationOfapplication.Visible = false;
            }
            AddSelect(ddlDLORecommendedIncentives);

            btnJDHeadOffice.Enabled = false;
        }

        protected void RbtnAfterInspectionstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            divAfterInspectionQuery.Visible = false;
            //divAfterInspectionRecommended.Visible = false;

            if (RbtnAfterInspectionstatus.SelectedValue == "1")
            {
                divAfterInspectionQuery.Visible = true;
                lblAfterInspectionQueryStatus.InnerHtml = "Recommended Remarks";
                //divAfterInspectionRecommended.Visible = true;
            }
            else if (RbtnAfterInspectionstatus.SelectedValue == "2")
            {
                divAfterInspectionQuery.Visible = true;
                //divAfterInspectionRecommended.Visible = false;
                lblAfterInspectionQueryStatus.InnerHtml = "Query";
            }
            else if (RbtnAfterInspectionstatus.SelectedValue == "3")
            {
                divAfterInspectionQuery.Visible = true;
                //divAfterInspectionRecommended.Visible = false;
                lblAfterInspectionQueryStatus.InnerHtml = "Remarks";
            }
            else if (RbtnAfterInspectionstatus.SelectedValue == "4")
            {
                divAfterInspectionQuery.Visible = true;
                lblAfterInspectionQueryStatus.InnerHtml = "Revised Inspection Report Reason/Remarks";
            }
        }

        protected void RbtnHeadOfficestatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            divHeadOfficeJdQuery.Visible = false;
            divMemoLetter.Visible = false;
            //divAfterInspectionRecommended.Visible = false;

            if (RbtnHeadOfficestatus.SelectedValue == "1")
            {
                divHeadOfficeJdQuery.Visible = true;
                lblvHeadOfficeJdQueryStatus.InnerHtml = "Recommended Remarks";
                if (ViewState["UID"].ToString() == "MEG006003126211")
                {
                    divJointInspReport.Visible = true;
                }
                string SubIncId = ddlDLORecommendedIncentives.SelectedValue.ToString();
                if (SubIncId == "3" || SubIncId == "4" || SubIncId == "9" || SubIncId == "6" || SubIncId == "14")
                {
                    divrdbHalfyear.Visible = true;
                }
                else
                {
                    divrdbHalfyear.Visible = false;
                }
                //divAfterInspectionRecommended.Visible = true;
            }
            else if (RbtnHeadOfficestatus.SelectedValue == "2")
            {
                divHeadOfficeJdQuery.Visible = true;
                //divAfterInspectionRecommended.Visible = false;
                lblvHeadOfficeJdQueryStatus.InnerHtml = "Query";
                divrdbHalfyear.Visible = false;
                divFullPartialRemarks.Visible = false;
            }
            else if (RbtnHeadOfficestatus.SelectedValue == "3")
            {
                divHeadOfficeJdQuery.Visible = true;
                //divAfterInspectionRecommended.Visible = false;
                lblvHeadOfficeJdQueryStatus.InnerHtml = "Remarks";
                divrdbHalfyear.Visible = false;
                divFullPartialRemarks.Visible = false;
            }
            else if (RbtnHeadOfficestatus.SelectedValue == "4")
            {
                divHeadOfficeJdQuery.Visible = true;
                //divAfterInspectionRecommended.Visible = false;
                lblvHeadOfficeJdQueryStatus.InnerHtml = "Revised Inspection Report Reason/Remarks";
                divMemoLetter.Visible = true;
                divrdbHalfyear.Visible = false;
                divFullPartialRemarks.Visible = false;
            }
            else if (RbtnHeadOfficestatus.SelectedValue == "5")
            {
                divHeadOfficeJdQuery.Visible = true;
                lblvHeadOfficeJdQueryStatus.InnerHtml = "Remarks";
                divrdbHalfyear.Visible = false;
                divFullPartialRemarks.Visible = false;
            }
            btnJDHeadOffice.Enabled = true;
        }

        protected void ddlInspectionCompletedIncentives_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlInspectionCompletedIncentives.SelectedValue != "0")
            {
                if (ViewState["InspectionCompletedIncentives"] != null)
                {
                    btnAfterInspection.Enabled = true;
                    DataSet dsapprovals = new DataSet();
                    dsapprovals = (DataSet)ViewState["InspectionCompletedIncentives"];
                    if (dsapprovals != null && dsapprovals.Tables.Count > 0 && dsapprovals.Tables[0].Rows.Count > 0)
                    {
                        DataRow[] drs = dsapprovals.Tables[0].Select("SubIncentiveID = " + ddlInspectionCompletedIncentives.SelectedValue + "and DIPCFLAG ='Y'");
                        if (drs.Length > 0)
                        {
                            RbtnAfterInspectionstatus.Items[0].Text = "Recommend to DL-SVC";
                        }
                        else
                        {
                            RbtnAfterInspectionstatus.Items[0].Text = "Recommend to Head Office";
                        }
                    }
                }
            }
            else
            {
                btnAfterInspection.Enabled = false;
            }
            string Incentive_id = ViewState["IncentiveId"].ToString();
            string CheckEligibilitytoReVisedInsp = ObjCAFClass.Check_RevisedInspectionReport(Incentive_id, ddlInspectionCompletedIncentives.SelectedValue.ToString());
            if (CheckEligibilitytoReVisedInsp == "N")
            {
                RbtnAfterInspectionstatus.Items[3].Attributes.Add("style", "display:none");
            }
        }
        public string RecommendValidateControls()
        {
            int slno = 1;
            string ErrorMsg = "";
            if (ddlInspectionCompletedIncentives.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Incentive \\n";
                slno = slno + 1;
            }
            if (RbtnAfterInspectionstatus.SelectedIndex == -1)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Application Status \\n";
                slno = slno + 1;
            }
            if (RbtnAfterInspectionstatus.SelectedValue == "1")
            {
                if (txtAfterInspectionQueryRemarks.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Recommended Remarks \\n";
                    slno = slno + 1;
                }
            }
            else if (RbtnAfterInspectionstatus.SelectedValue == "2")
            {
                if (txtAfterInspectionQueryRemarks.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Query Remarks \\n";
                    slno = slno + 1;
                }
            }
            else if (RbtnAfterInspectionstatus.SelectedValue == "3")
            {
                if (txtAfterInspectionQueryRemarks.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Rejected Remarks \\n";
                    slno = slno + 1;
                }
            }
            else if (RbtnAfterInspectionstatus.SelectedValue == "4")
            {
                if (txtAfterInspectionQueryRemarks.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Re-Inspection Remarks/Reason \\n";
                    slno = slno + 1;
                }
            }
            return ErrorMsg;
        }
        protected void btnAfterInspection_Click(object sender, EventArgs e)
        {
            try
            {
                string errormsg = RecommendValidateControls();
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

                    ObjApplicationStatus.IncentiveId = ViewState["IncentiveId"].ToString();
                    ObjApplicationStatus.SubIncentiveId = ddlInspectionCompletedIncentives.SelectedValue;
                    ObjApplicationStatus.CreatedBy = ObjLoginNewvo.uid;
                    ObjApplicationStatus.TransType = RbtnAfterInspectionstatus.SelectedValue;
                    //if (txtAppDateofInspection.Text.Trim().TrimStart() != "")
                    //if (txtAppDateofInspection.Text.Trim().TrimStart() != "")
                    //{
                    //    ObjApplicationStatus.InspectionDate = GetFromatedDateDDMMYYYY(txtAppDateofInspection.Text.Trim().TrimStart());
                    //}
                    ObjApplicationStatus.ReInspectionDate = txtReInspectionDate.Text.Trim().TrimStart();
                    ObjApplicationStatus.Remarks = txtAfterInspectionQueryRemarks.Text.Trim().TrimStart();

                    string Status = ObjCAFClass.UpdateApplicationStatusDLOStage3(ObjApplicationStatus);

                    if (Convert.ToInt32(Status) > 0)
                    {
                        string Successmsg = "";
                        BindCompletedInspectionIncentives(ViewState["IncentiveId"].ToString(), ObjLoginNewvo.Role_Code);
                        BindQueries();
                        BindRecomendedIncentives();
                        ddlInspectionCompletedIncentives.SelectedValue = "0";
                        txtAfterInspectionQueryRemarks.Text = "";

                        if (RbtnAfterInspectionstatus.SelectedValue == "1")
                        {
                            Successmsg = "Application Recommended Successfully";
                        }
                        else if (RbtnAfterInspectionstatus.SelectedValue == "2")
                        {
                            Successmsg = "Query Raised Successfully";
                        }
                        else if (RbtnAfterInspectionstatus.SelectedValue == "3")
                        {
                            Successmsg = "Application Rejected Successfully";
                        }
                        else if (RbtnAfterInspectionstatus.SelectedValue == "4")
                        {
                            Successmsg = "Application Sent for Revised Inspection";
                        }
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

        public string JDRecommendValidateControls()
        {
            int slno = 1;
            string ErrorMsg = "";
            if (ddlDLORecommendedIncentives.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Incentive \\n";
                slno = slno + 1;
            }
            if (RbtnHeadOfficestatus.SelectedIndex == -1)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Application Status \\n";
                slno = slno + 1;
            }
            string SubIncId = ddlDLORecommendedIncentives.SelectedValue.ToString();
            if (SubIncId == "3" || SubIncId == "4" || SubIncId == "6" || SubIncId == "9" || SubIncId == "14")
            {
                if (rdbFullPartial.SelectedValue == "P" || rdbFullPartial.SelectedValue == "CP")
                {
                    if (txtPartialRecommendedAmount.Text == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please enter JD Recommended amount \\n";
                        slno = slno + 1;
                    }
                    if (txtFullPartialRemarks.Text == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please enter Remarks of Partial Process \\n";
                        slno = slno + 1;
                    }
                }
            }

            if (RbtnHeadOfficestatus.SelectedValue == "1")
            {
                if (txtvHeadOfficeJdQueryRemarks.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Recommended Remarks \\n";
                    slno = slno + 1;
                }
                else if (fuJointInspReport.HasFile)
                {
                    string errormsg = objClsFileUpload.CheckFileSize(fuJointInspReport);
                    if (errormsg != "")
                    {
                        ErrorMsg = ErrorMsg + slno + "." + errormsg + " \\n";
                        slno = slno + 1;
                    }

                    string Mimetype = objClsFileUpload.getmimetype(fuJointInspReport);
                    if (Mimetype == "application/pdf")
                    {

                    }
                    else
                    {
                        ErrorMsg = ErrorMsg + slno + ". Only pdf files allowed! \\n";
                        slno = slno + 1;
                    }
                }

            }
            else if (RbtnHeadOfficestatus.SelectedValue == "2")
            {
                if (txtvHeadOfficeJdQueryRemarks.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Query Remarks \\n";
                    slno = slno + 1;
                }
            }
            else if (RbtnHeadOfficestatus.SelectedValue == "3")
            {
                if (txtvHeadOfficeJdQueryRemarks.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Rejected Remarks \\n";
                    slno = slno + 1;
                }
            }
            else if (RbtnHeadOfficestatus.SelectedValue == "4")
            {
                if (txtvHeadOfficeJdQueryRemarks.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Re-Inspection Remarks/Reason \\n";
                    slno = slno + 1;
                }
                else if (fuMemoLetter.HasFile)
                {
                    string errormsg = objClsFileUpload.CheckFileSize(fuMemoLetter);
                    if (errormsg != "")
                    {
                        // string message = "alert('" + errormsg + "')";
                        ErrorMsg = ErrorMsg + slno + "." + errormsg + " \\n";
                        slno = slno + 1;
                    }

                    string Mimetype = objClsFileUpload.getmimetype(fuMemoLetter);
                    if (Mimetype == "application/pdf")
                    {

                    }
                    else
                    {
                        ErrorMsg = ErrorMsg + slno + ". Only pdf files allowed! \\n";
                        slno = slno + 1;
                    }
                }
            }
            return ErrorMsg;
        }
        protected void btnJDHeadOffice_Click(object sender, EventArgs e)
        {
            try
            {
                string errormsg = JDRecommendValidateControls();
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

                    ObjApplicationStatus.IncentiveId = ViewState["IncentiveId"].ToString();
                    ObjApplicationStatus.SubIncentiveId = ddlDLORecommendedIncentives.SelectedValue;
                    ObjApplicationStatus.CreatedBy = ObjLoginNewvo.uid;
                    ObjApplicationStatus.TransType = RbtnHeadOfficestatus.SelectedValue;
                    string SubIncId = ddlDLORecommendedIncentives.SelectedValue.ToString();
                    if (SubIncId == "3" || SubIncId == "4" || SubIncId == "6" || SubIncId == "9" || SubIncId == "14")
                    {
                        if (rdbFullPartial.SelectedValue == "P" || rdbFullPartial.SelectedValue == "CP")
                        {
                            ObjApplicationStatus.PartialSanction = rdbFullPartial.SelectedValue;
                            ObjApplicationStatus.JDRecommendedAmount = txtPartialRecommendedAmount.Text.Trim();
                            ObjApplicationStatus.PartialRemarks = txtFullPartialRemarks.Text;
                        }
                    }
                    ObjApplicationStatus.Remarks = txtvHeadOfficeJdQueryRemarks.Text.Trim().TrimStart();
                    HyperLink hypconcernedCTo = new HyperLink();
                    if (RbtnHeadOfficestatus.SelectedValue == "4")
                    {
                        objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuMemoLetter, hypconcernedCTo, "JDReInspectionMemo", ObjApplicationStatus.IncentiveId, ObjApplicationStatus.SubIncentiveId, "181111", Session["uid"].ToString(), "JD");
                    }
                    if (RbtnHeadOfficestatus.SelectedValue == "1")
                    {
                        if (ViewState["UID"].ToString() == "MEG006003126211")
                        {
                            objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuJointInspReport, hypconcernedCTo, "JointInspectionReport", ObjApplicationStatus.IncentiveId, ObjApplicationStatus.SubIncentiveId, "181112", Session["uid"].ToString(), "JD");
                        }
                    }
                    string OutPut = "1";
                    if (OutPut == "1")
                    {
                        string Status = ObjCAFClass.UpdateApplicationStatusJDStage4(ObjApplicationStatus);

                        if (Convert.ToInt32(Status) > 0)
                        {
                            string Successmsg = "";
                            BindDLORecomendedIncentives(ViewState["IncentiveId"].ToString(), ObjLoginNewvo.Role_Code);
                            BindJDQueries();
                            BindJDRecomendedIncentives();
                            BindJDSenttoDLOIncentives();
                            ddlDLORecommendedIncentives.SelectedValue = "0";
                            txtvHeadOfficeJdQueryRemarks.Text = "";

                            if (RbtnHeadOfficestatus.SelectedValue == "1")
                            {
                                Successmsg = "Application Recommended Successfully";
                            }
                            else if (RbtnHeadOfficestatus.SelectedValue == "2")
                            {
                                Successmsg = "Query Raised Successfully";
                            }
                            else if (RbtnHeadOfficestatus.SelectedValue == "3")
                            {
                                Successmsg = "Application Rejected Successfully";
                            }
                            else if (RbtnHeadOfficestatus.SelectedValue == "4")
                            {
                                Successmsg = "Application Sent to DLO for Revised Inspection Report Successfully";
                            }
                            else if (RbtnHeadOfficestatus.SelectedValue == "5")
                            {
                                Successmsg = "Application Sent to DLC Successfully";
                            }
                            RbtnHeadOfficestatus.SelectedIndex = -1;

                            string message = "alert('" + Successmsg + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        string message = "alert('" + "Error...! Uploading File" + "')";
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
        public void BindJDRecomendedIncentives()
        {
            dss = GetJDRecomendedIncentivesById(Convert.ToInt32(Request.QueryString["Id"].ToString()));
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvRefferedApplicationStatusJD.DataSource = dss;
                gvRefferedApplicationStatusJD.DataBind();
                DivRefferedApplicationDetailsJD.Visible = true;
                divQueriesJD.Visible = true;
            }
            else
            {
                DivRefferedApplicationDetailsJD.Visible = false;
            }
        }
        public void BindJDSenttoDLOIncentives()
        {
            dss = GetJDSenttoDLOIncentivesById(Convert.ToInt32(Request.QueryString["Id"].ToString()));
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvSentDloRevisedInsp.DataSource = dss;
                gvSentDloRevisedInsp.DataBind();
                divJDSenttoDLOforReInspect.Visible = true;
                divQueriesJD.Visible = true;
            }
            else
            {
                divJDSenttoDLOforReInspect.Visible = false;
            }
        }
        public void BindJDSenttoDLCIncentives()
        {
            dss = GetJDSenttoDLCIncentivesById(Convert.ToInt32(Request.QueryString["Id"].ToString()));
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvJDtoDLC.DataSource = dss;
                gvJDtoDLC.DataBind();
                divJDtoDLC.Visible = true;
                divQueriesJD.Visible = true;
            }
            else
            {
                divJDtoDLC.Visible = false;
            }
        }
        public DataSet GetJDRecomendedIncentivesById(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
           };
            pp[0].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_JD_RECOMMENDED_INCENTIVES", pp);
            return Dsnew;
        }
        public DataSet GetJDSenttoDLOIncentivesById(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
           };
            pp[0].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_JD_TO_DLO_RECOMMENDED_INCENTIVES", pp);
            return Dsnew;
        }
        public DataSet GetJDSenttoDLCIncentivesById(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
           };
            pp[0].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_JD_TO_DLC_RECOMMENDED_INCENTIVES", pp);
            return Dsnew;
        }
        public void BindRecomendedIncentives()
        {
            dss = GetRecomendedIncentivesById(Convert.ToInt32(Request.QueryString["Id"].ToString()));
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvRefferedApplicationStatus.DataSource = dss;
                gvRefferedApplicationStatus.DataBind();
                DivRefferedApplicationDetails.Visible = true;
                divQueriesAfterInspection.Visible = true;
                divDLOCoveringLetter.Visible = true;
                HyCoveringLetter.NavigateUrl = "~/UI/Pages/RecommendationLetters/DLOCoveringLetter.aspx?IncentiveID=" + Convert.ToInt32(Request.QueryString["Id"].ToString());

                if (dss.Tables[1].Rows.Count > 0)
                {
                    gvRefferedApplicationStatusReInspection.DataSource = dss.Tables[1];
                    gvRefferedApplicationStatusReInspection.DataBind();
                    DivRefferedApplicationDetailsReInspection.Visible = true;
                }
            }
            else
            {
                DivRefferedApplicationDetails.Visible = false;
                divDLOCoveringLetter.Visible = false;
            }
        }
        public DataSet GetRecomendedIncentivesById(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
           };
            pp[0].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_SLCDLC_RECOMMENDED_INCENTIVES", pp);
            return Dsnew;
        }
        public DataSet GetDLCApprovedIncentivesById(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
           };
            pp[0].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_DLC_APPROVED_REJECTED_APPLICATIONS", pp);
            return Dsnew;
        }

        public void BindDLCApprovedIncentives()
        {
            dss = GetDLCApprovedIncentivesById(Convert.ToInt32(Request.QueryString["Id"].ToString()));
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvApprovedApplicationDetailsDLC.DataSource = dss;
                gvApprovedApplicationDetailsDLC.DataBind();
                DivApprovedApplicationDetailsDLC.Visible = true;
                divDLCStatus.Visible = true;
            }
            else
            {
                DivApprovedApplicationDetailsDLC.Visible = false;
            }

            if (dss != null && dss.Tables.Count > 1 && dss.Tables[1].Rows.Count > 0)
            {
                gvRejectedApplicationsDLC.DataSource = dss.Tables[1];
                gvRejectedApplicationsDLC.DataBind();
                DivRejectedApplicationsDLC.Visible = true;
                divDLCStatus.Visible = true;
            }
            else
            {
                DivRejectedApplicationsDLC.Visible = false;
            }
        }
        public DataSet GetSVCApprovedIncentivesById(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
           };
            pp[0].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_SVC_APPROVED_REJECTED_APPLICATIONS", pp);
            return Dsnew;
        }
        public void BindDLSVCApprovedIncentives()
        {
            dss = GetSVCApprovedIncentivesById(Convert.ToInt32(Request.QueryString["Id"].ToString()));
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvApprovedApplicationDetailsSVC.DataSource = dss;
                gvApprovedApplicationDetailsSVC.DataBind();
                DivApprovedApplicationDetailsSVC.Visible = true;
                divSVCStatus.Visible = true;
            }
            else
            {
                DivApprovedApplicationDetailsSVC.Visible = false;
            }

            if (dss != null && dss.Tables.Count > 1 && dss.Tables[1].Rows.Count > 0)
            {
                gvRejectedApplicationsSVC.DataSource = dss.Tables[1];
                gvRejectedApplicationsSVC.DataBind();
                DivRejectedApplicationsSVC.Visible = true;
                divSVCStatus.Visible = true;
            }
            else
            {
                DivRejectedApplicationsSVC.Visible = false;
            }
        }

        protected void RbtnCommstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RbtnCommstatus.SelectedValue == "1")
            {
                divadminquery.Visible = false;
                divQueryLetterComm.Visible = false;
            }
            else if (RbtnCommstatus.SelectedValue == "2")
            {
                divadminquery.Visible = true;
                divQueryLetterComm.Visible = true;
                lblcommQuery.InnerHtml = "Query";
            }
            else if (RbtnCommstatus.SelectedValue == "3")
            {
                lblcommQuery.InnerHtml = "Rejection Remarks";
                divadminquery.Visible = true;
                divQueryLetterComm.Visible = false;
            }
        }
        public string AdminValidateControls()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (RbtnCommstatus.SelectedIndex == -1)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Application Status \\n";
                slno = slno + 1;
            }
            if (RbtnCommstatus.SelectedValue == "2")
            {
                if (txtcommquery.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Query Remarks \\n";
                    slno = slno + 1;
                }
            }
            else if (Rbtnstatus.SelectedValue == "3")
            {
                if (txtcommquery.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Rejected Remarks \\n";
                    slno = slno + 1;
                }
            }
            if (fuQueryLetterComm.HasFile)
            {
                string Mimetype = objClsFileUpload.getmimetype(fuQueryLetterComm);
                if (Mimetype != "application/pdf")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select pdf files only \\n";
                    slno = slno + 1;
                }
            }
            return ErrorMsg;
        }
        protected void BtnadminProcess_Click(object sender, EventArgs e)
        {
            try
            {
                string errormsg = AdminValidateControls();
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

                    ObjApplicationStatus.IncentiveId = ViewState["IncentiveId"].ToString();

                    ObjApplicationStatus.CreatedBy = ObjLoginNewvo.uid;
                    ObjApplicationStatus.TransType = RbtnCommstatus.SelectedValue;

                    ObjApplicationStatus.Remarks = txtcommquery.Text.Trim().TrimStart();
                    if (fuQueryLetterComm.HasFile)
                    {
                        HyperLink hypconcernedCTo = new HyperLink();
                        string Attachmentidnew = ObjApplicationStatus.IncentiveId + "020" + ObjApplicationStatus.SubIncentiveId + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                        string OutPut = objClsFileUpload.IncentiveFileUploadingQuery("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuQueryLetterComm, hypconcernedCTo, ObjLoginNewvo.Role_Code + "QueryLetter", ObjApplicationStatus.IncentiveId, ObjApplicationStatus.SubIncentiveId, Attachmentidnew, Session["uid"].ToString(), "OFFICER", "0", "QueryLetter");
                        ObjApplicationStatus.QueryLetterID = OutPut;
                    }

                    string Status = ObjCAFClass.UpdateApplicationStatusAdmin(ObjApplicationStatus);

                    if (Convert.ToInt32(Status) > 0)
                    {
                        string Successmsg = "";
                        BindCommQueries();
                        txtcommquery.Text = "";
                        divcomm.Visible = false;
                        if (RbtnCommstatus.SelectedValue == "1")
                        {
                            Successmsg = "Application has been Submitted to Respective DLO";
                        }
                        else if (RbtnCommstatus.SelectedValue == "2")
                        {
                            Successmsg = "Query Raised Successfully";
                        }
                        else if (RbtnCommstatus.SelectedValue == "3")
                        {
                            Successmsg = "Application Rejected Successfully";
                        }

                        RbtnCommstatus.SelectedIndex = -1;

                        try
                        {
                            ClsSMSandMail ClsSMSandMailobj = new ClsSMSandMail();
                            string IncentiveID = ViewState["IncentiveId"].ToString();
                            ClsSMSandMailobj.SendSmsEmail(IncentiveID, "", "ADMN", "INFOTODLO", "Incentives");
                        }
                        catch (Exception ex)
                        {
                            string errorMsg = ex.Message;
                        }

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
        public void BindCommQueries()
        {
            dss = GetCommQueriesById(Convert.ToInt32(Request.QueryString["Id"].ToString()));
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                GvcommQueryYetRespondDetails.DataSource = dss;
                GvcommQueryYetRespondDetails.DataBind();
                DivcommQueryYetRespond.Visible = true;
                divcommhistory.Visible = true;
            }
            else
            {
                DivcommQueryYetRespond.Visible = false;
            }

            if (dss != null && dss.Tables.Count > 1 && dss.Tables[1].Rows.Count > 0)
            {
                GvCommQueryRespondDetails.DataSource = dss.Tables[1];
                GvCommQueryRespondDetails.DataBind();
                DivcommQueryRespond.Visible = true;
                divcommhistory.Visible = true;
            }
            else
            {
                DivcommQueryRespond.Visible = false;
            }

            if (dss != null && dss.Tables.Count > 2 && dss.Tables[2].Rows.Count > 0)
            {
                gvCommRejected.DataSource = dss.Tables[2];
                gvCommRejected.DataBind();
                DivcommRejected.Visible = true;
                divcommhistory.Visible = true;
            }
            else
            {
                DivcommRejected.Visible = false;
            }

            if (dss != null && dss.Tables.Count > 3 && dss.Tables[3].Rows.Count > 0)
            {
                gvcommcompletedverification.DataSource = dss.Tables[3];
                gvcommcompletedverification.DataBind();
                Divcommcompleted.Visible = true;
                divcommhistory.Visible = true;
            }
            else
            {
                Divcommcompleted.Visible = false;
            }
            if (dss != null && dss.Tables.Count > 3 && dss.Tables[3].Rows.Count > 0 && dss.Tables[3].Rows[0]["IsPaymentGateway"].ToString() == "Y")
            {
                divcommhistory.Visible = false;
            }
        }
        public void BindPandMGrid(int PMId, int IncentiveId, string IndusType)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = GetPandM(PMId, IncentiveId, IndusType);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    PhaseView = ds.Tables[0].Rows[0]["Phase"].ToString();
                    grdPandM.DataSource = ds.Tables[0];
                    grdPandM.DataBind();

                    decimal TotalValueofNewMachinery = 0, Secondhandmachinery = 0;
                    /*decimal TotalValueofTextileProducts = 0, TotalValueofNonTextileProducts = 0, TotalValueofAllTextileProducts;

                    foreach (GridViewRow gvrow in grdPandM.Rows)
                    {
                        string Value = (gvrow.FindControl("lblMachineCost") as Label).Text;
                        string lblInstalledMachineryText = (gvrow.FindControl("lblInstalledMachineryText") as Label).Text;
                        if (lblInstalledMachineryText.ToUpper() == "NEW")
                        {
                            TotalValueofNewMachinery = TotalValueofNewMachinery + Convert.ToDecimal(GetDecimalNullValue(Value));
                        }
                        else
                        {
                            Secondhandmachinery = Secondhandmachinery + Convert.ToDecimal(GetDecimalNullValue(Value));
                        }

                        //

                        string lblClassificationofMachinery = (gvrow.FindControl("lblClassificationofMachinery") as Label).Text;
                        if (lblClassificationofMachinery.ToUpper().Contains("NON TEXTILE PRODUCTS"))
                        {
                            TotalValueofNonTextileProducts = TotalValueofNonTextileProducts + Convert.ToDecimal(GetDecimalNullValue(Value));
                        }
                        else if (lblClassificationofMachinery.ToUpper().Contains("TEXTILE PRODUCTS"))
                        {
                            TotalValueofTextileProducts = TotalValueofTextileProducts + Convert.ToDecimal(GetDecimalNullValue(Value));
                        }

                    }*/

                    lblTotalValueofNewMachinery.InnerHtml = ds.Tables[1].Rows[0]["NewMachineCostSum"].ToString();
                    lblSecondhandmachinery.InnerHtml = ds.Tables[1].Rows[0]["SecondMachineCostSum"].ToString();


                    /*lblTotalValueofTextileProducts.InnerHtml = TotalValueofTextileProducts.ToString();
                    lblTotalValueofNonTextileProducts.InnerHtml = TotalValueofNonTextileProducts.ToString();

                    lblTotalValueofAllTextileProducts.InnerHtml = (TotalValueofTextileProducts + TotalValueofNonTextileProducts).ToString();
                    TotalValueofAllTextileProducts = (TotalValueofTextileProducts + TotalValueofNonTextileProducts);

                    if (TotalValueofTextileProducts > 0)
                    {
                        lblValueofTextileProductsPercentage.InnerHtml = (Convert.ToDecimal(Convert.ToDecimal(TotalValueofTextileProducts / TotalValueofAllTextileProducts) * Convert.ToDecimal(100.00))).ToString("#.##");
                    }
                    else
                    {
                        lblValueofTextileProductsPercentage.InnerHtml = "0";
                    }
                    if (TotalValueofNonTextileProducts > 0)
                    {
                        lblValueofNonTextileProductsPercentage.InnerHtml = (Convert.ToDecimal(Convert.ToDecimal(TotalValueofNonTextileProducts / TotalValueofAllTextileProducts) * Convert.ToDecimal(100.00))).ToString("#.##");
                    }
                    else
                    {
                        lblValueofNonTextileProductsPercentage.InnerHtml = "0";
                    }*/
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void BindPhaseWiseGrid(string IncentiveId)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = GetPhaseWiseGrid(IncentiveId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvPhaseView.DataSource = ds.Tables[0];
                    gvPhaseView.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetPandM(int PMId, int IncentiveId, string IndusType)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@PMId",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = PMId;
            string ProcName = "";
            if (IndusType == "1")
            {
                ProcName = "USP_GET_PLANTANDMACHINERY";
            }
            else
            {
                ProcName = "USP_GET_PLANTANDMACHINERY_ExistingUnit";
            }
            Dsnew = ObjCAFClass.GenericFillDs(ProcName, pp);
            return Dsnew;
        }
        public DataSet GetPhaseWiseGrid(string IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_PHASEWISE_PLANTANDMACHINERY", pp);
            return Dsnew;
        }

        public DataSet GetOldApplications(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;

            // Dsnew = caf.GenericFillDs("USP_GET_DLOAPPLICATIONS", pp);
            Dsnew = caf.GenericFillDs("USP_GET_OLDAPPLICATIONS_DTLS", pp);

            return Dsnew;
        }
        public DataSet GetFinancialYears(int IncentiveId, int SubIncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@SubIncentiveId",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = SubIncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_FINANCIAL_YEARS_BY_SUBINCENTIVE", pp);

            return Dsnew;
        }

        public void BindOldApplications(int IncentiveId)
        {
            DataSet ds = new DataSet();
            ds = GetOldApplications(IncentiveId);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                divMainOldApplications.Visible = true;
                GvOldApplications.DataSource = ds;
                GvOldApplications.DataBind();
            }
            else
            {
                divMainOldApplications.Visible = false;
            }
        }

        protected void grdPandM_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (this.grdPandM.Rows.Count > 0)
            {
                grdPandM.UseAccessibleHeader = true;
                grdPandM.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        protected void gvPhaseView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int TextileMachines1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TextileMachines"));
                TextileMachines = TextileMachines1 + TextileMachines;

                decimal TextileMachinesValue1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TextileMachinesValue"));
                TextileMachinesValue = TextileMachinesValue1 + TextileMachinesValue;

                int NontextileMachines1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NontextileMachines"));
                NontextileMachines = NontextileMachines1 + NontextileMachines;

                decimal NontextileMachinesValue1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "NontextileMachinesValue"));
                NontextileMachinesValue = NontextileMachinesValue1 + NontextileMachinesValue;

                decimal TotalMachinaryValue1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalMachinaryValue"));
                TotalMachinaryValue = TotalMachinaryValue1 + TotalMachinaryValue;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[0].Text = "Total";
                e.Row.Cells[1].Text = TextileMachines.ToString();
                e.Row.Cells[2].Text = TextileMachinesValue.ToString();
                e.Row.Cells[3].Text = NontextileMachines.ToString();
                e.Row.Cells[4].Text = NontextileMachinesValue.ToString();
                e.Row.Cells[5].Text = TotalMachinaryValue.ToString();
            }
        }
        protected void BtnExportExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
        protected void ExportToExcel()
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=PMReport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                divPMprint.Style["width"] = "680px";

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    grdPandM.AllowPaging = false;
                    //this.fillgrid();

                    grdPandM.HeaderRow.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in grdPandM.HeaderRow.Cells)
                    {
                        cell.BackColor = grdPandM.HeaderStyle.BackColor;
                        cell.ForeColor = System.Drawing.Color.Black;
                    }
                    foreach (TableCell cell in grdPandM.FooterRow.Cells)
                    {
                        cell.BackColor = System.Drawing.Color.Black;
                        cell.ForeColor = System.Drawing.Color.Black;
                        // cell.
                    }


                    foreach (TableCell cell in grdPandM.FooterRow.Cells)
                    {

                        cell.CssClass = "textmode";
                        List<Control> controls = new List<Control>();
                        foreach (Control control in cell.Controls)
                        {
                            switch (control.GetType().Name)
                            {
                                case "HyperLink":
                                    controls.Add(control);
                                    break;
                                case "TextBox":
                                    controls.Add(control);
                                    break;
                                case "LinkButton":
                                    controls.Add(control);
                                    break;
                                case "CheckBox":
                                    controls.Add(control);
                                    break;
                                case "RadioButton":
                                    controls.Add(control);
                                    break;
                            }
                        }
                        foreach (Control control in controls)
                        {
                            switch (control.GetType().Name)
                            {
                                case "HyperLink":
                                    cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
                                    break;
                                case "TextBox":
                                    cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                                    break;
                                case "LinkButton":
                                    cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                    break;
                                case "CheckBox":
                                    cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                                    break;
                                case "RadioButton":
                                    cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                                    break;
                            }
                            cell.Controls.Remove(control);
                        }
                    }
                    foreach (GridViewRow row in grdPandM.Rows)
                    {
                        row.BackColor = System.Drawing.Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = grdPandM.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = grdPandM.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                            List<Control> controls = new List<Control>();
                            foreach (Control control in cell.Controls)
                            {
                                switch (control.GetType().Name)
                                {
                                    case "HyperLink":
                                        controls.Add(control);
                                        break;
                                    case "TextBox":
                                        controls.Add(control);
                                        break;
                                    case "LinkButton":
                                        controls.Add(control);
                                        break;
                                    case "CheckBox":
                                        controls.Add(control);
                                        break;
                                    case "RadioButton":
                                        controls.Add(control);
                                        break;
                                }
                            }
                            foreach (Control control in controls)
                            {
                                switch (control.GetType().Name)
                                {
                                    case "HyperLink":
                                        cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
                                        break;
                                    case "TextBox":
                                        cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                                        break;
                                    case "LinkButton":
                                        cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                        break;
                                    case "CheckBox":
                                        cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                                        break;
                                    case "RadioButton":
                                        cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                                        break;
                                }
                                cell.Controls.Remove(control);
                            }
                        }
                    }

                    divPMprint.RenderControl(hw);

                    //style to format numbers to string
                    string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }

            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }

        protected void ddlDLORecommendedIncentives_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Incentive_id = ViewState["IncentiveId"].ToString();
            string CheckEligibilitytoReVisedInsp = ObjCAFClass.Check_RevisedInspectionReport(Incentive_id, ddlDLORecommendedIncentives.SelectedValue.ToString());
            if (CheckEligibilitytoReVisedInsp == "N")
            {
                RbtnHeadOfficestatus.Items[3].Attributes.Add("style", "display:none");
            }
            RbtnHeadOfficestatus_SelectedIndexChanged(this, EventArgs.Empty);
        }

        protected void btnIndustries_Click(object sender, EventArgs e)
        {
            try
            {
                Button ddlDeptnameFnl2 = (Button)sender;
                GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
                Label lblIncentiveID = (Label)row.FindControl("lblIncentiveID");
                Label lblSubIncentiveId = (Label)row.FindControl("lblSubIncentiveId");
                Button Button1 = (Button)row.FindControl("btnIndustries");
                string IncentiveId = lblIncentiveID.Text.ToString();
                string SubIncentiveId = lblSubIncentiveId.Text.ToString();
                string Validstatus = ObjCAFClass.UpdatetoIndustriesDept(IncentiveId, SubIncentiveId);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    Button1.Enabled = false;
                    string message = "alert('Forwarded to DIC Successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        protected void grdQueries_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string INCId = Request.QueryString["Id"].ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (e.Row.FindControl("lblSubIncentiveId") as Label);
                HyperLink HyperLinkSubsidy = (e.Row.FindControl("hyQueryReminders") as HyperLink);
                HyperLinkSubsidy.NavigateUrl = "~/UI/Pages//ReminderQueries.aspx?IncentiveId=" + INCId + "&SubIncentiveId=" + lbl.Text.ToString();
            }
        }

        protected void gvJointInspectionReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbl = (e.Row.FindControl("lbl") as Label);
                    HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);

                    string Category = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Category"));
                    if (Category.Trim().TrimStart() != "")
                    {
                        lbl.Text = Category.Trim().TrimStart();
                        e.Row.Font.Bold = true;
                        HyperLinkSubsidy.Visible = false;
                    }

                    if (HyperLinkSubsidy.NavigateUrl == "")
                    {
                        HyperLinkSubsidy.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void rdbFullPartial_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SubIncId = ddlDLORecommendedIncentives.SelectedValue.ToString();
            if (SubIncId == "3" || SubIncId == "4" || SubIncId == "6" || SubIncId == "9" || SubIncId == "14")
            {
                if (rdbFullPartial.SelectedValue.ToString() == "P" || rdbFullPartial.SelectedValue.ToString() == "CP")
                {
                    divFullPartialRemarks.Visible = true;
                }
                else
                {
                    divFullPartialRemarks.Visible = false;
                }
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            Button btnclick = (Button)sender;
            GridViewRow row = (GridViewRow)btnclick.NamingContainer;
            Label lblfilepath = (Label)row.FindControl("lblfilepath");
            Label lblcfeid = (Label)row.FindControl("lblcfeid");
            Label lblmodule = (Label)row.FindControl("lblmodule");
            Response.Redirect("~/UI/Pages/FileApi.aspx?filepath=" + lblfilepath.Text.Trim() + "&cfeid=" + lblcfeid.Text.Trim() + "&module=" + lblmodule.Text);
        }

        protected void btnShowPM_Click(object sender, EventArgs e)
        {
            BindPandMGrid(0, Convert.ToInt32(Request.QueryString["Id"].ToString()), hdnIndusType.Value.ToString());
            if (PhaseView != "")
            {
                BindPhaseWiseGrid(Request.QueryString["Id"].ToString());
                DivPhaseDetails.Visible = true;
            }
            btnShowPM.Visible = false;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                btnNext.Visible = false;

                DataTable tblfullshap = new DataTable();
                tblfullshap.Columns.Add("IncentiveName", typeof(string));
                tblfullshap.Columns.Add("MstIncentiveId", typeof(string));
                tblfullshap.Columns.Add("EnterperIncentiveID", typeof(string));

                DataTable tblNotfullshap = new DataTable();
                tblNotfullshap.Columns.Add("IncentiveName", typeof(string));
                tblNotfullshap.Columns.Add("MstIncentiveId", typeof(string));
                tblNotfullshap.Columns.Add("EnterperIncentiveID", typeof(string));
                tblNotfullshap.Columns.Add("Query", typeof(string));

                DataTable tblRejected = new DataTable();
                tblRejected.Columns.Add("IncentiveName", typeof(string));
                tblRejected.Columns.Add("MstIncentiveId", typeof(string));
                tblRejected.Columns.Add("EnterperIncentiveID", typeof(string));
                tblRejected.Columns.Add("RejectedReason", typeof(string));


                int selectedcount = 0;
                foreach (GridViewRow gvrow in GvYetAssign.Rows)
                {
                    int rowIndex = gvrow.RowIndex;
                    string EnterperIncentiveID = ((Label)gvrow.FindControl("lblIncentiveId")).Text.ToString();
                    string IncentiveName = ((Label)gvrow.FindControl("lblIncentiveName")).Text.ToString();
                    string MstIncentiveId = ((Label)gvrow.FindControl("lblSubIncentiveId")).Text.ToString();
                    string FullShape = ((RadioButtonList)gvrow.FindControl("rdbyesno")).SelectedValue;
                    RadioButtonList ControlFullShape = ((RadioButtonList)gvrow.FindControl("rdbyesno"));

                    if (FullShape == "Y")
                    {
                        DataRow Row;
                        Row = tblfullshap.NewRow();
                        Row["IncentiveName"] = IncentiveName;
                        Row["EnterperIncentiveID"] = EnterperIncentiveID;
                        Row["MstIncentiveId"] = MstIncentiveId;
                        tblfullshap.Rows.Add(Row);
                        selectedcount = selectedcount + 1;
                    }
                    else if (FullShape == "N" && ControlFullShape.Enabled == true)
                    {
                        DataRow Row;
                        Row = tblNotfullshap.NewRow();
                        Row["IncentiveName"] = IncentiveName;
                        Row["EnterperIncentiveID"] = EnterperIncentiveID;
                        Row["MstIncentiveId"] = MstIncentiveId;
                        Row["Query"] = "";
                        tblNotfullshap.Rows.Add(Row);
                        selectedcount = selectedcount + 1;
                    }
                    else if (FullShape == "R" && ControlFullShape.Enabled == true)
                    {
                        DataRow Row;
                        Row = tblRejected.NewRow();
                        Row["IncentiveName"] = IncentiveName;
                        Row["EnterperIncentiveID"] = EnterperIncentiveID;
                        Row["MstIncentiveId"] = MstIncentiveId;
                        Row["RejectedReason"] = "";
                        tblRejected.Rows.Add(Row);
                        selectedcount = selectedcount + 1;
                    }
                    else if (ControlFullShape.Enabled == false && FullShape == "N")
                    {
                        selectedcount = selectedcount + 1;
                    }
                }
                if (GvYetAssign.Rows.Count != selectedcount)
                {
                    string message = "alert('Kindly Check whether the incentive full shape or not')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                gvYes.DataSource = tblfullshap;
                gvYes.DataBind();

                gvNo.DataSource = tblNotfullshap;
                gvNo.DataBind();

                gvReject.DataSource = tblRejected;
                gvReject.DataBind();

                divYesControls.Visible = false;
                divQueryControl.Visible = false;
                divRejectControl.Visible = false;

                if (gvYes.Rows.Count > 0)
                {
                    gvYes.Visible = true;
                    divYesControls.Visible = true;
                }
                if (gvNo.Rows.Count > 0)
                {
                    gvNo.Visible = true;
                    divQueryControl.Visible = true;
                }
                if (gvReject.Rows.Count > 0)
                {
                    gvReject.Visible = true;
                    divRejectControl.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlOfficer.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please select Inspecting Officer');", true);
                    return;
                }
                int IncCount = 0;
                ApplicationStatus ObjApplicationStatus = new ApplicationStatus();
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                foreach (GridViewRow gvrow in gvYes.Rows)
                {
                    string SubIncentiveId;
                    SubIncentiveId = ((Label)gvrow.FindControl("lblSubIncentiveId")).Text.ToString();

                    ObjApplicationStatus.IncentiveId = ViewState["IncentiveId"].ToString();
                    ObjApplicationStatus.SubIncentiveId = SubIncentiveId;
                    ObjApplicationStatus.CreatedBy = ObjLoginNewvo.uid;
                    ObjApplicationStatus.OfficerId = ddlOfficer.SelectedValue.ToString();
                    ObjApplicationStatus.TransType = "1";
                    ObjApplicationStatus.QueryReason = "";
                    string Status = ObjCAFClass.AssignInspectingOfficer(ObjApplicationStatus);
                    if (Convert.ToInt32(Status) > 0)
                    {
                        UpdateYettoAssignGrid(SubIncentiveId);
                        IncCount = IncCount + 1;
                    }
                }
                if (gvYes.Rows.Count == IncCount)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Assigned Successfully');", true);
                    gvYes.Visible = false;
                    divYesControls.Visible = false;
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Assigning failed');", true);
                    return;
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

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {

                int IncCount = 0;
                ApplicationStatus ObjApplicationStatus = new ApplicationStatus();
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                foreach (GridViewRow gvrow in gvNo.Rows)
                {
                    string SubIncentiveId;
                    SubIncentiveId = ((Label)gvrow.FindControl("lblSubIncentiveId")).Text.ToString();
                    string Query = ((TextBox)gvrow.FindControl("txtQuery")).Text.ToString();
                    if (Query == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter Query Description');", true);
                        return;
                    }
                    ObjApplicationStatus.IncentiveId = ViewState["IncentiveId"].ToString();
                    ObjApplicationStatus.SubIncentiveId = SubIncentiveId;
                    ObjApplicationStatus.CreatedBy = ObjLoginNewvo.uid;
                    ObjApplicationStatus.OfficerId = "0";
                    ObjApplicationStatus.TransType = "2";
                    ObjApplicationStatus.QueryReason = Query;
                    string Status = ObjCAFClass.AssignInspectingOfficer(ObjApplicationStatus);
                    if (Convert.ToInt32(Status) > 0)
                    {
                        UpdateYettoAssignGrid(SubIncentiveId);
                        IncCount = IncCount + 1;
                    }
                }
                if (gvNo.Rows.Count == IncCount)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Query Raised Successfully');", true);
                    gvNo.Visible = false;
                    divQueryControl.Visible = false;
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Action failed');", true);
                    return;
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

        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {

                int IncCount = 0;
                ApplicationStatus ObjApplicationStatus = new ApplicationStatus();
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                foreach (GridViewRow gvrow in gvReject.Rows)
                {
                    string SubIncentiveId;
                    SubIncentiveId = ((Label)gvrow.FindControl("lblSubIncentiveId")).Text.ToString();
                    string Reason = ((TextBox)gvrow.FindControl("txtReasons")).Text.ToString();
                    if (Reason == "")
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter Reject Reason');", true);
                        return;
                    }
                    ObjApplicationStatus.IncentiveId = ViewState["IncentiveId"].ToString();
                    ObjApplicationStatus.SubIncentiveId = SubIncentiveId;
                    ObjApplicationStatus.CreatedBy = ObjLoginNewvo.uid;
                    ObjApplicationStatus.OfficerId = "0";
                    ObjApplicationStatus.TransType = "3";
                    ObjApplicationStatus.QueryReason = Reason;
                    string Status = ObjCAFClass.AssignInspectingOfficer(ObjApplicationStatus);
                    if (Convert.ToInt32(Status) > 0)
                    {
                        UpdateYettoAssignGrid(SubIncentiveId);
                        IncCount = IncCount + 1;
                    }
                }
                if (gvReject.Rows.Count == IncCount)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Incentive Application Rejected Successfully');", true);
                    gvReject.Visible = false;
                    divRejectControl.Visible = false;
                    return;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Action failed');", true);
                    return;
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

        protected void rdbyesno_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvYes.Visible = false;
            gvNo.Visible = false;
            gvReject.Visible = false;
            divYesControls.Visible = false;
            divQueryControl.Visible = false;
            divRejectControl.Visible = false;
            btnNext.Visible = true;
        }
        public void GetInspectingOfficers()
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetTSIpassInspectingOfficers(Session["DistrictID"].ToString());
                ddlOfficer.DataSource = dsnew.Tables[0];
                ddlOfficer.DataTextField = "Dept_Name";
                ddlOfficer.DataValueField = "Dept_Id";
                ddlOfficer.DataBind();
                AddSelect(ddlOfficer);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
        public void UpdateYettoAssignGrid(string SubIncId)
        {
            try
            {
                foreach (GridViewRow gvrow in GvYetAssign.Rows)
                {
                    if (SubIncId != "0")
                    {
                        Label lblMstIncentiveId = (Label)gvrow.FindControl("lblSubIncentiveId");
                        if (lblMstIncentiveId.Text.Trim() == SubIncId)
                        {
                            RadioButtonList rdbyesno = (RadioButtonList)gvrow.FindControl("rdbyesno");
                            rdbyesno.SelectedValue = "Y";
                            rdbyesno.Enabled = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
        public DataSet GetTSIpassInspectingOfficers(string DistId)
        {
            DataRetrivalClass dataRetrivalClass = new DataRetrivalClass();
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@Dept_ID",SqlDbType.VarChar)
           };
            pp[0].Value = DistId;
            Dsnew = dataRetrivalClass.GenericFillDs("[GetDepartmentIncentive_NEW]", pp);
            return Dsnew;
        }
        public void BindGMHistory()
        {
            dss = GetGMHistoryById(Convert.ToInt32(Request.QueryString["Id"].ToString()));
            if (dss != null && dss.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
                {
                    divGMHistory.Visible = true;
                    gvGMAssigned.DataSource = dss.Tables[0];
                    gvGMAssigned.DataBind();
                    divAssignedDtls.Visible = true;
                }
                if (dss.Tables[1].Rows.Count > 0)
                {
                    divGMHistory.Visible = true;
                    gvGMQuery.DataSource = dss.Tables[1];
                    gvGMQuery.DataBind();
                    divGMQuery.Visible = true;
                }
                if (dss.Tables[2].Rows.Count > 0)
                {
                    divGMHistory.Visible = true;
                    gvGMReject.DataSource = dss.Tables[2];
                    gvGMReject.DataBind();
                    divGMReject.Visible = true;
                }
                if (dss.Tables[3].Rows.Count > 0)
                {
                    divGMHistory.Visible = true;
                    gvGMResponseIPOQuery.DataSource = dss.Tables[3];
                    gvGMResponseIPOQuery.DataBind();
                    divGMResponseIPOQuery.Visible = true;
                }
                if (dss.Tables[4].Rows.Count > 0)
                {
                    divGMHistory.Visible = true;
                    gvGMForwardtoApplicant.DataSource = dss.Tables[4];
                    gvGMForwardtoApplicant.DataBind();
                    divGMForwardtoApplicant.Visible = true;
                }
                if (dss.Tables[5].Rows.Count > 0)
                {
                    divGMHistory.Visible = true;
                    gvGMResponseIPOQueryAfterInsp.DataSource = dss.Tables[5];
                    gvGMResponseIPOQueryAfterInsp.DataBind();
                    divGMResponseIPOQueryAfterInsp.Visible = true;
                }
                if (dss.Tables[6].Rows.Count > 0)
                {
                    divGMHistory.Visible = true;
                    gvGMForwardtoAppAfterInsp.DataSource = dss.Tables[6];
                    gvGMForwardtoAppAfterInsp.DataBind();
                    divGMForwardtoAppAfterInsp.Visible = true;
                }
                if (dss.Tables[7].Rows.Count > 0)
                {
                    divGMHistory.Visible = true;
                    gvGMToCOIHis.DataSource = dss.Tables[7];
                    gvGMToCOIHis.DataBind();
                    divGMToCOIHis.Visible = true;
                }
            }
        }
        public void BindIPOHistory()
        {
            dss = GetIPOHistoryById(Convert.ToInt32(Request.QueryString["Id"].ToString()));
            if (dss != null && dss.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
                {
                    divQueries.Visible = true;
                    gvIPOQueryBI.DataSource = dss.Tables[0];
                    gvIPOQueryBI.DataBind();
                    divIPOQueryBI.Visible = true;
                }
            }
        }
        public void BindGMVerifications()
        {
            dss = GetGMVerificationsById(Convert.ToInt32(Request.QueryString["Id"].ToString()));
            if (dss != null && dss.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
                {
                    divGMVerification.Visible = true;
                    gvFwdAppResptoIPO.DataSource = dss.Tables[0];
                    gvFwdAppResptoIPO.DataBind();
                    divForwardApplicantResponsetoIPO.Visible = true;
                }
                if (dss.Tables[1].Rows.Count > 0)
                {
                    divGMVerification.Visible = true;
                    gvdivGMRecommendCOI.DataSource = dss.Tables[1];
                    gvdivGMRecommendCOI.DataBind();
                    divGMRecommendCOI.Visible = true;
                }
            }
        }
        protected void btnResponsetoIPOBeforeInsp_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationStatus ObjApplicationStatus = new ApplicationStatus();
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

                ObjApplicationStatus.IncentiveId = ((Label)gvQueriesFromIPO.Rows[indexing].FindControl("lblIncentiveId")).Text.ToString();
                ObjApplicationStatus.SubIncentiveId = ((Label)gvQueriesFromIPO.Rows[indexing].FindControl("lblSubIncentiveId")).Text.ToString();
                ObjApplicationStatus.QueryId = ((Label)gvQueriesFromIPO.Rows[indexing].FindControl("lblQueryId")).Text.ToString();
                ObjApplicationStatus.CreatedBy = ObjLoginNewvo.uid;
                ObjApplicationStatus.Remarks = ((TextBox)gvQueriesFromIPO.Rows[indexing].FindControl("txtIPOQueryReply")).Text.ToString();
                Button btnResponsetoIPOBeforeInsp = (Button)gvQueriesFromIPO.Rows[indexing].FindControl("btnResponsetoIPOBeforeInsp");
                Button btnFwdtoApplicantBeforeInsp = (Button)gvQueriesFromIPO.Rows[indexing].FindControl("btnFwdtoApplicantBeforeInsp");
                ScriptManager.GetCurrent(this).RegisterPostBackControl(btnResponsetoIPOBeforeInsp);
                HyperLink hypconcernedCTo = new HyperLink();
                hypconcernedCTo = ((HyperLink)gvQueriesFromIPO.Rows[indexing].FindControl("hyGMRespFile"));
                if (ObjApplicationStatus.Remarks == "")
                {
                    string info = "Please Enter Response";
                    string message = "alert('" + info + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                ObjApplicationStatus.TransType = "GMTOIPO";
                FileUpload fuGMReplyIPOQuery = (FileUpload)gvQueriesFromIPO.Rows[indexing].FindControl("fuGMReplyIPOQuery");
                if (fuGMReplyIPOQuery.HasFile)
                {
                    string Mimetype = objClsFileUpload.getmimetype(fuGMReplyIPOQuery);
                    if (Mimetype == "application/pdf")
                    {
                        string Attachmentidnew = ObjApplicationStatus.IncentiveId + "020" + ObjApplicationStatus.SubIncentiveId + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                        string OutPut = objClsFileUpload.IncentiveFileUploadingQuery("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuGMReplyIPOQuery, hypconcernedCTo, ObjLoginNewvo.Role_Code + "Response", ObjApplicationStatus.IncentiveId, ObjApplicationStatus.SubIncentiveId, Attachmentidnew, Session["uid"].ToString(), ObjLoginNewvo.Role_Code, ObjApplicationStatus.QueryId, "IPOQuery");
                        ObjApplicationStatus.QueryLetterID = OutPut;
                    }
                    else
                    {
                        string errormsg = "Only pdf files allowed !";
                        string message = "alert('" + errormsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                }

                string Status = ObjCAFClass.UpdateGMResponseIPOBeforeInsp(ObjApplicationStatus);
                if (Convert.ToInt32(Status) > 0)
                {
                    btnResponsetoIPOBeforeInsp.Visible = false;
                    btnFwdtoApplicantBeforeInsp.Visible = false;
                    hypconcernedCTo.Visible = true;
                    BindGMHistory();
                    string Successmsg = "";
                    Successmsg = "Response Submitted Successfully to IPO";
                    string message = "alert('" + Successmsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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

        protected void btnFwdtoApplicantBeforeInsp_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationStatus ObjApplicationStatus = new ApplicationStatus();
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

                ObjApplicationStatus.IncentiveId = ((Label)gvQueriesFromIPO.Rows[indexing].FindControl("lblIncentiveId")).Text.ToString();
                ObjApplicationStatus.SubIncentiveId = ((Label)gvQueriesFromIPO.Rows[indexing].FindControl("lblSubIncentiveId")).Text.ToString();
                ObjApplicationStatus.QueryId = ((Label)gvQueriesFromIPO.Rows[indexing].FindControl("lblQueryId")).Text.ToString();
                ObjApplicationStatus.CreatedBy = ObjLoginNewvo.uid;
                ObjApplicationStatus.Remarks = ((TextBox)gvQueriesFromIPO.Rows[indexing].FindControl("txtIPOQueryReply")).Text.ToString();
                Button btnResponsetoIPOBeforeInsp = (Button)gvQueriesFromIPO.Rows[indexing].FindControl("btnResponsetoIPOBeforeInsp");
                Button btnFwdtoApplicantBeforeInsp = (Button)gvQueriesFromIPO.Rows[indexing].FindControl("btnFwdtoApplicantBeforeInsp");
                ScriptManager.GetCurrent(this).RegisterPostBackControl(btnFwdtoApplicantBeforeInsp);
                HyperLink hypconcernedCTo = new HyperLink();
                hypconcernedCTo = ((HyperLink)gvQueriesFromIPO.Rows[indexing].FindControl("hyGMRespFile"));
                if (ObjApplicationStatus.Remarks == "")
                {
                    string info = "Please Enter Response";
                    string message = "alert('" + info + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                ObjApplicationStatus.TransType = "GMTOAPP";
                FileUpload fuGMReplyIPOQuery = (FileUpload)gvQueriesFromIPO.Rows[indexing].FindControl("fuGMReplyIPOQuery");
                if (fuGMReplyIPOQuery.HasFile)
                {
                    string Mimetype = objClsFileUpload.getmimetype(fuGMReplyIPOQuery);
                    if (Mimetype == "application/pdf")
                    {
                        string Attachmentidnew = ObjApplicationStatus.IncentiveId + "020" + ObjApplicationStatus.SubIncentiveId + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                        string OutPut = objClsFileUpload.IncentiveFileUploadingQuery("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuGMReplyIPOQuery, hypconcernedCTo, ObjLoginNewvo.Role_Code + "Response", ObjApplicationStatus.IncentiveId, ObjApplicationStatus.SubIncentiveId, Attachmentidnew, Session["uid"].ToString(), ObjLoginNewvo.Role_Code, ObjApplicationStatus.QueryId, "IPOQuery");
                        ObjApplicationStatus.QueryLetterID = OutPut;
                    }
                    else
                    {
                        string errormsg = "Only pdf files allowed !";
                        string message = "alert('" + errormsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                }

                string Status = ObjCAFClass.UpdateGMResponseIPOBeforeInsp(ObjApplicationStatus);
                if (Convert.ToInt32(Status) > 0)
                {
                    string Successmsg = "";
                    btnResponsetoIPOBeforeInsp.Visible = false;
                    btnFwdtoApplicantBeforeInsp.Visible = false;
                    hypconcernedCTo.Visible = true;
                    BindGMHistory();
                    Successmsg = "Query Forwarded Successfully to Applicant";
                    string message = "alert('" + Successmsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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

        protected void ddlInsOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

            DropDownList ddlInsOption = (DropDownList)gvUpdateInspectionDetails.Rows[indexing].FindControl("ddlInsOption");
            HyperLink anchortaglinkView = (HyperLink)gvUpdateInspectionDetails.Rows[indexing].FindControl("anchortaglinkView");
            TextBox txtAfterInspQuery = (TextBox)gvUpdateInspectionDetails.Rows[indexing].FindControl("txtAfterInspQuery");
            Button btnRaiseQuery = (Button)gvUpdateInspectionDetails.Rows[indexing].FindControl("btnRaiseQuery");

            if (ddlInsOption.SelectedValue == "1")
            {
                anchortaglinkView.Visible = true;
                txtAfterInspQuery.Visible = false;
                btnRaiseQuery.Visible = false;
            }
            else
            {
                anchortaglinkView.Visible = false;
                txtAfterInspQuery.Visible = true;
                btnRaiseQuery.Visible = true;
            }
        }

        protected void btnRaiseQuery_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationStatus ObjApplicationStatus = new ApplicationStatus();
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
                TextBox txtAfterInspQuery = (TextBox)gvUpdateInspectionDetails.Rows[indexing].FindControl("txtAfterInspQuery");

                ObjApplicationStatus.IncentiveId = ((Label)gvUpdateInspectionDetails.Rows[indexing].FindControl("lblIncentiveID")).Text.ToString();
                ObjApplicationStatus.SubIncentiveId = ((Label)gvUpdateInspectionDetails.Rows[indexing].FindControl("lblSubIncentiveId")).Text.ToString();
                ObjApplicationStatus.CreatedBy = ObjLoginNewvo.uid;
                ObjApplicationStatus.TransType = "4";
                ObjApplicationStatus.Remarks = ((TextBox)gvUpdateInspectionDetails.Rows[indexing].FindControl("txtAfterInspQuery")).Text.ToString();

                string Status = ObjCAFClass.UpdateApplicationStatusDLOStage1(ObjApplicationStatus);

                if (Convert.ToInt32(Status) > 0)
                {
                    string Successmsg = "";
                    txtAfterInspQuery.Text = "";
                    Successmsg = "Query Raised Successfully";
                    string message = "alert('" + Successmsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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

        protected void btnResponsetoIPOAfterInsp_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationStatus ObjApplicationStatus = new ApplicationStatus();
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

                ObjApplicationStatus.IncentiveId = ((Label)gvGMActionIPOQueryAfterInsp.Rows[indexing].FindControl("lblIncentiveId")).Text.ToString();
                ObjApplicationStatus.SubIncentiveId = ((Label)gvGMActionIPOQueryAfterInsp.Rows[indexing].FindControl("lblSubIncentiveId")).Text.ToString();
                ObjApplicationStatus.QueryId = ((Label)gvGMActionIPOQueryAfterInsp.Rows[indexing].FindControl("lblQueryId")).Text.ToString();
                ObjApplicationStatus.CreatedBy = ObjLoginNewvo.uid;
                ObjApplicationStatus.Remarks = ((TextBox)gvGMActionIPOQueryAfterInsp.Rows[indexing].FindControl("txtIPOQueryReplyInsp")).Text.ToString();
                Button btnResponsetoIPOAfterInsp = (Button)gvGMActionIPOQueryAfterInsp.Rows[indexing].FindControl("btnResponsetoIPOAfterInsp");
                Button btnFwdtoApplicantAfterInsp = (Button)gvGMActionIPOQueryAfterInsp.Rows[indexing].FindControl("btnFwdtoApplicantAfterInsp");
                ScriptManager.GetCurrent(this).RegisterPostBackControl(btnResponsetoIPOAfterInsp);
                HyperLink hypconcernedCTo = new HyperLink();
                hypconcernedCTo = ((HyperLink)gvGMActionIPOQueryAfterInsp.Rows[indexing].FindControl("hyGMRespFileInsp"));
                if (ObjApplicationStatus.Remarks == "")
                {
                    string info = "Please Enter Response";
                    string message = "alert('" + info + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                ObjApplicationStatus.TransType = "GMTOIPOINSP";
                FileUpload fuGMReplyIPOQueryInsp = (FileUpload)gvGMActionIPOQueryAfterInsp.Rows[indexing].FindControl("fuGMReplyIPOQueryInsp");
                if (fuGMReplyIPOQueryInsp.HasFile)
                {
                    string Mimetype = objClsFileUpload.getmimetype(fuGMReplyIPOQueryInsp);
                    if (Mimetype == "application/pdf")
                    {
                        string Attachmentidnew = ObjApplicationStatus.IncentiveId + "020" + ObjApplicationStatus.SubIncentiveId + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                        string OutPut = objClsFileUpload.IncentiveFileUploadingQuery("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuGMReplyIPOQueryInsp, hypconcernedCTo, ObjLoginNewvo.Role_Code + "Response", ObjApplicationStatus.IncentiveId, ObjApplicationStatus.SubIncentiveId, Attachmentidnew, Session["uid"].ToString(), ObjLoginNewvo.Role_Code, ObjApplicationStatus.QueryId, "IPOQueryAfterInsp");
                        ObjApplicationStatus.QueryLetterID = OutPut;
                    }
                    else
                    {
                        string errormsg = "Only pdf files allowed !";
                        string message = "alert('" + errormsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                }

                string Status = ObjCAFClass.UpdateGMResponseIPOBeforeInsp(ObjApplicationStatus);
                if (Convert.ToInt32(Status) > 0)
                {
                    btnResponsetoIPOAfterInsp.Visible = false;
                    btnFwdtoApplicantAfterInsp.Visible = false;
                    hypconcernedCTo.Visible = true;
                    BindGMHistory();
                    string Successmsg = "";
                    Successmsg = "Response Submitted Successfully to IPO";
                    string message = "alert('" + Successmsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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

        protected void btnFwdtoApplicantAfterInsp_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationStatus ObjApplicationStatus = new ApplicationStatus();
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

                ObjApplicationStatus.IncentiveId = ((Label)gvGMActionIPOQueryAfterInsp.Rows[indexing].FindControl("lblIncentiveId")).Text.ToString();
                ObjApplicationStatus.SubIncentiveId = ((Label)gvGMActionIPOQueryAfterInsp.Rows[indexing].FindControl("lblSubIncentiveId")).Text.ToString();
                ObjApplicationStatus.QueryId = ((Label)gvGMActionIPOQueryAfterInsp.Rows[indexing].FindControl("lblQueryId")).Text.ToString();
                ObjApplicationStatus.CreatedBy = ObjLoginNewvo.uid;
                ObjApplicationStatus.Remarks = ((TextBox)gvGMActionIPOQueryAfterInsp.Rows[indexing].FindControl("txtIPOQueryReplyInsp")).Text.ToString();
                Button btnResponsetoIPOAfterInsp = (Button)gvGMActionIPOQueryAfterInsp.Rows[indexing].FindControl("btnResponsetoIPOAfterInsp");
                Button btnFwdtoApplicantAfterInsp = (Button)gvGMActionIPOQueryAfterInsp.Rows[indexing].FindControl("btnFwdtoApplicantAfterInsp");
                ScriptManager.GetCurrent(this).RegisterPostBackControl(btnResponsetoIPOAfterInsp);
                HyperLink hypconcernedCTo = new HyperLink();
                hypconcernedCTo = ((HyperLink)gvGMActionIPOQueryAfterInsp.Rows[indexing].FindControl("hyGMRespFileInsp"));
                if (ObjApplicationStatus.Remarks == "")
                {
                    string info = "Please Enter Response";
                    string message = "alert('" + info + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                ObjApplicationStatus.TransType = "GMTOAPPINSP";
                FileUpload fuGMReplyIPOQueryInsp = (FileUpload)gvGMActionIPOQueryAfterInsp.Rows[indexing].FindControl("fuGMReplyIPOQueryInsp");
                if (fuGMReplyIPOQueryInsp.HasFile)
                {
                    string Mimetype = objClsFileUpload.getmimetype(fuGMReplyIPOQueryInsp);
                    if (Mimetype == "application/pdf")
                    {
                        string Attachmentidnew = ObjApplicationStatus.IncentiveId + "020" + ObjApplicationStatus.SubIncentiveId + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                        string OutPut = objClsFileUpload.IncentiveFileUploadingQuery("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuGMReplyIPOQueryInsp, hypconcernedCTo, ObjLoginNewvo.Role_Code + "Forward", ObjApplicationStatus.IncentiveId, ObjApplicationStatus.SubIncentiveId, Attachmentidnew, Session["uid"].ToString(), ObjLoginNewvo.Role_Code, ObjApplicationStatus.QueryId, "IPOQueryAfterInsp");
                        ObjApplicationStatus.QueryLetterID = OutPut;
                    }
                    else
                    {
                        string errormsg = "Only pdf files allowed !";
                        string message = "alert('" + errormsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                }

                string Status = ObjCAFClass.UpdateGMResponseIPOBeforeInsp(ObjApplicationStatus);
                if (Convert.ToInt32(Status) > 0)
                {
                    btnResponsetoIPOAfterInsp.Visible = false;
                    btnFwdtoApplicantAfterInsp.Visible = false;
                    hypconcernedCTo.Visible = true;
                    BindGMHistory();
                    string Successmsg = "";
                    Successmsg = "Query Forwarded Successfully to Applicant";
                    string message = "alert('" + Successmsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
        public void BindApplicantResponses()
        {
            dss = GetQueriesById(Convert.ToInt32(Request.QueryString["Id"].ToString()));
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                grdQueries.DataSource = dss;
                grdQueries.DataBind();
                DivQueryDetails.Visible = true;
                divQueries.Visible = true;
            }
            else
            {
                DivQueryDetails.Visible = false;
            }
        }

        protected void btnForwardtoIPOAftrResp_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationStatus ObjApplicationStatus = new ApplicationStatus();
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

                ObjApplicationStatus.IncentiveId = ((Label)gvFwdAppResptoIPO.Rows[indexing].FindControl("lblIncentiveId")).Text.ToString();
                ObjApplicationStatus.SubIncentiveId = ((Label)gvFwdAppResptoIPO.Rows[indexing].FindControl("lblSubIncentiveId")).Text.ToString();
                ObjApplicationStatus.QueryId = ((Label)gvFwdAppResptoIPO.Rows[indexing].FindControl("lblQueryId")).Text.ToString();
                ObjApplicationStatus.CreatedBy = ObjLoginNewvo.uid;
                ObjApplicationStatus.Remarks = ((TextBox)gvFwdAppResptoIPO.Rows[indexing].FindControl("txtIPOQueryReplyInsp")).Text.ToString();
                Button btnForwardtoIPOAftrResp = (Button)gvFwdAppResptoIPO.Rows[indexing].FindControl("btnForwardtoIPOAftrResp");
                Button btnRaiseQueryAftrResp = (Button)gvFwdAppResptoIPO.Rows[indexing].FindControl("btnRaiseQueryAftrResp");
                ScriptManager.GetCurrent(this).RegisterPostBackControl(btnForwardtoIPOAftrResp);
                HyperLink hypconcernedCTo = new HyperLink();
                hypconcernedCTo = ((HyperLink)gvFwdAppResptoIPO.Rows[indexing].FindControl("hyGMRespFileInsp"));
                if (ObjApplicationStatus.Remarks == "")
                {
                    string info = "Please Enter Remarks";
                    string message = "alert('" + info + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                ObjApplicationStatus.TransType = "QRSPGMTOIPOBFR";
                FileUpload fuGMFwdAppRespInsp = (FileUpload)gvFwdAppResptoIPO.Rows[indexing].FindControl("fuGMFwdAppRespInsp");
                if (fuGMFwdAppRespInsp.HasFile)
                {
                    string Mimetype = objClsFileUpload.getmimetype(fuGMFwdAppRespInsp);
                    if (Mimetype == "application/pdf")
                    {
                        string Attachmentidnew = ObjApplicationStatus.IncentiveId + "020" + ObjApplicationStatus.SubIncentiveId + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                        string OutPut = objClsFileUpload.IncentiveFileUploadingQuery("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuGMFwdAppRespInsp, hypconcernedCTo, ObjLoginNewvo.Role_Code + "ForwartoIPO", ObjApplicationStatus.IncentiveId, ObjApplicationStatus.SubIncentiveId, Attachmentidnew, Session["uid"].ToString(), ObjLoginNewvo.Role_Code, ObjApplicationStatus.QueryId, "IPOQueryBeforeInsp");
                        ObjApplicationStatus.QueryLetterID = OutPut;
                    }
                    else
                    {
                        string errormsg = "Only pdf files allowed !";
                        string message = "alert('" + errormsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                }

                string Status = ObjCAFClass.UpdateGMResponseIPOBeforeInsp(ObjApplicationStatus);
                if (Convert.ToInt32(Status) > 0)
                {
                    btnForwardtoIPOAftrResp.Visible = false;
                    btnRaiseQueryAftrResp.Visible = false;
                    hypconcernedCTo.Visible = true;
                    BindGMHistory();
                    string Successmsg = "";
                    Successmsg = "Applicant Response Forwarded Successfully to IPO";
                    string message = "alert('" + Successmsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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
        protected void btnRaiseQueryAftrResp_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationStatus ObjApplicationStatus = new ApplicationStatus();
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

                ObjApplicationStatus.IncentiveId = ((Label)gvFwdAppResptoIPO.Rows[indexing].FindControl("lblIncentiveId")).Text.ToString();
                ObjApplicationStatus.SubIncentiveId = ((Label)gvFwdAppResptoIPO.Rows[indexing].FindControl("lblSubIncentiveId")).Text.ToString();
                ObjApplicationStatus.QueryId = ((Label)gvFwdAppResptoIPO.Rows[indexing].FindControl("lblQueryId")).Text.ToString();
                ObjApplicationStatus.CreatedBy = ObjLoginNewvo.uid;
                ObjApplicationStatus.Remarks = ((TextBox)gvFwdAppResptoIPO.Rows[indexing].FindControl("txtIPOQueryReplyInsp")).Text.ToString();
                Button btnForwardtoIPOAftrResp = (Button)gvFwdAppResptoIPO.Rows[indexing].FindControl("btnForwardtoIPOAftrResp");
                Button btnRaiseQueryAftrResp = (Button)gvFwdAppResptoIPO.Rows[indexing].FindControl("btnRaiseQueryAftrResp");
                ScriptManager.GetCurrent(this).RegisterPostBackControl(btnRaiseQueryAftrResp);
                HyperLink hypconcernedCTo = new HyperLink();
                hypconcernedCTo = ((HyperLink)gvFwdAppResptoIPO.Rows[indexing].FindControl("hyGMRespFileInsp"));
                if (ObjApplicationStatus.Remarks == "")
                {
                    string info = "Please Enter Remarks";
                    string message = "alert('" + info + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                ObjApplicationStatus.TransType = "QRYAFTRRESP";
                FileUpload fuGMFwdAppRespInsp = (FileUpload)gvFwdAppResptoIPO.Rows[indexing].FindControl("fuGMFwdAppRespInsp");
                if (fuGMFwdAppRespInsp.HasFile)
                {
                    string Mimetype = objClsFileUpload.getmimetype(fuGMFwdAppRespInsp);
                    if (Mimetype == "application/pdf")
                    {
                        string Attachmentidnew = ObjApplicationStatus.IncentiveId + "020" + ObjApplicationStatus.SubIncentiveId + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                        string OutPut = objClsFileUpload.IncentiveFileUploadingQuery("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuGMFwdAppRespInsp, hypconcernedCTo, ObjLoginNewvo.Role_Code + "ForwartoIPO", ObjApplicationStatus.IncentiveId, ObjApplicationStatus.SubIncentiveId, Attachmentidnew, Session["uid"].ToString(), ObjLoginNewvo.Role_Code, ObjApplicationStatus.QueryId, "IPOQueryBeforeInsp");
                        ObjApplicationStatus.QueryLetterID = OutPut;
                    }
                    else
                    {
                        string errormsg = "Only pdf files allowed !";
                        string message = "alert('" + errormsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                }

                string Status = ObjCAFClass.UpdateGMResponseIPOBeforeInsp(ObjApplicationStatus);
                if (Convert.ToInt32(Status) > 0)
                {
                    btnForwardtoIPOAftrResp.Visible = false;
                    btnRaiseQueryAftrResp.Visible = false;
                    hypconcernedCTo.Visible = true;
                    BindGMHistory();
                    string Successmsg = "";
                    Successmsg = "Query Raised Successfully";
                    string message = "alert('" + Successmsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
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

        public void BindCoiProcess()
        {
            try
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];


                dss = GetCoiProcessById(Convert.ToInt32(Request.QueryString["Id"].ToString()));

                if (dss != null && dss.Tables.Count > 0)
                {
                    if (dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                    {
                        /*  if (dss.Tables[0].Rows[0]["CLERK_Process_CompleteFlg"] == null && ObjLoginNewvo.Role_Code == "COI-CLERK")
                          {
                              divClerklevel.Visible = true;
                          }
                          else if (dss.Tables[0].Rows[0]["SUPDT_Process_CompleteFlg"] == null && ObjLoginNewvo.Role_Code == "COI-SUPDT")
                          {
                              divSupdtlevel.Visible = true;
                          }
                          else if (dss.Tables[0].Rows[0]["AD_Process_CompleteFlg"] == null && ObjLoginNewvo.Role_Code == "COI-AD")
                          {
                              divADlevel.Visible = true;
                          }
                          else if (dss.Tables[0].Rows[0]["DD_Process_CompleteFlg"] == null && ObjLoginNewvo.Role_Code == "COI-DD")
                          {
                              divDDlevel.Visible = true;
                          } */
                        // string[] validStageIds = { "61", "64", "67", "70" };
                        if ((dss.Tables[0].Rows[0]["Stageid"]?.ToString() == "61" || dss.Tables[0].Rows[0]["Stageid"]?.ToString() == "64" || dss.Tables[0].Rows[0]["Stageid"]?.ToString() == "67" ||
                            dss.Tables[0].Rows[0]["Stageid"]?.ToString() == "70"))
                        {
                            // divJDVerificationOfapplication.Visible = true;
                            // TSIPASS.Visible = true;
                        }
                        else
                        {

                        }
                        // else { TSIPASS.Visible = false; }//divJDVerificationOfapplication.Visible = false; }

                    }
                    if (dss != null && dss.Tables.Count > 0 && dss.Tables[1].Rows.Count > 0)
                    {
                        GVRemark.DataSource = dss.Tables[1];
                        GVRemark.DataBind();
                        ClerkProcess.Visible = true;
                        Rmarkes1.Visible = true;

                    }
                    if (dss != null && dss.Tables.Count > 0 && dss.Tables[2].Rows.Count > 0)
                    {
                        GVSUPDTPROC.DataSource = dss.Tables[2];
                        GVSUPDTPROC.DataBind();
                        SUPDTPROCDET.Visible = true;
                        SupdtDetailsProc.Visible = true;
                    }
                    if (dss != null && dss.Tables.Count > 0 && dss.Tables[3].Rows.Count > 0)
                    {
                        GVADPROC.DataSource = dss.Tables[3];
                        GVADPROC.DataBind();
                        ADPROCESSED.Visible = true;
                        ADPROCESS.Visible = true;
                    }
                    if (dss != null && dss.Tables.Count > 0 && dss.Tables[4].Rows.Count > 0)
                    {
                        GVDDPROC.DataSource = dss.Tables[4];
                        GVDDPROC.DataBind();
                        DDPROCESSEDDET.Visible = true;
                        DDProcessed.Visible = true;

                    }

                }
                else
                {
                    Failure.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCoiProcessById(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
           };
            pp[0].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GETCOIOFFICERS_PROCESS", pp);
            return Dsnew;
        }

        protected void btnGMCOIUpload_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmitGMtoCOI_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationStatus ObjApplicationStatus = new ApplicationStatus();
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

                string ActionType = ((DropDownList)gvdivGMRecommendCOI.Rows[indexing].FindControl("ddlActionType")).SelectedValue.ToString();

                ObjApplicationStatus.IncentiveId = ((Label)gvdivGMRecommendCOI.Rows[indexing].FindControl("lblIncentiveId")).Text.ToString();
                ObjApplicationStatus.SubIncentiveId = ((Label)gvdivGMRecommendCOI.Rows[indexing].FindControl("lblSubIncentiveId")).Text.ToString();
                ObjApplicationStatus.CreatedBy = ObjLoginNewvo.uid;
                ObjApplicationStatus.Remarks = ((TextBox)gvdivGMRecommendCOI.Rows[indexing].FindControl("txtGMRemarksCOI")).Text.ToString();
                ObjApplicationStatus.GMRecommendedAmount = ((TextBox)gvdivGMRecommendCOI.Rows[indexing].FindControl("txtGMAmount")).Text.ToString();
                ObjApplicationStatus.TransType = ActionType;

                HyperLink hypconcernedCTo = new HyperLink();
                hypconcernedCTo = ((HyperLink)gvdivGMRecommendCOI.Rows[indexing].FindControl("hyGMRecFile"));

                string Status = ObjCAFClass.UpdateGMRecommendationtoCoi(ObjApplicationStatus);
                if (Convert.ToInt32(Status) > 0)
                {
                    string Successmsg = "";
                    divGMVerification.Visible = false;
                    if (ActionType == "1") { Successmsg = "Query Raised Successfully"; }
                    if (ActionType == "2") { Successmsg = "Application Recommend to COI"; }
                    if (ActionType == "3") { Successmsg = "Application Rejected"; }
                    if (ActionType == "4") { Successmsg = "Application Rolled back to IO"; }
                    string message = "alert('" + Successmsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    BindGMHistory();

                }
                else
                {
                    string msg = "Action Failed";
                    string message = "alert('" + msg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
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