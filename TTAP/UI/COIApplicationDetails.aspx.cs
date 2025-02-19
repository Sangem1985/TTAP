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
using System.Linq;


namespace TTAP.UI
{
    public partial class COIApplicationDetails : System.Web.UI.Page
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
                                        string IncentiveType = DSIncentiveList.Tables[0].Rows[0]["Incentive_Type"].ToString();
                                        if (IncentiveType == "3")
                                        {
                                            divplantandmachinaryview.Visible = false;
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
                                    SpanApplcationStatusHistory.InnerHtml = "Applcation Status History (DLO - " + DistrictName + ")";
                                    SpanApplcationStatusHistoryAfterInspection.InnerHtml = "Applcation Status History - After Inspection (DLO - " + DistrictName + ")";

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
                                    if (Role_Code == "GM")
                                    {
                                        BindYetAssignedIncentives(IncentiveId, Role_Code);
                                    }
                                    if (Role_Code == "IPO" || Role_Code == "IND" || Role_Code == "DLO")
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
                                            gvUpdateInspectionDetails.Columns[7].Visible = false;
                                        }
                                        SpnAfterInspection.InnerHtml = "Verification of Applcation-After Inspection (DLO - " + DistrictName + ")";
                                        BindCompletedInspectionIncentives(IncentiveId, Role_Code);
                                    }

                                    if (Role_Code == "JD" || Role_Code == "ADDL" || Role_Code == "ADMN")
                                    {
                                        SpanApplcationStatusDLCStatus.InnerHtml = "Applcation Status History - SLC";
                                        SpanApplcationStatusSVCStatus.InnerHtml = "Applcation Status History - SVC";

                                        //SpnJDVerificationOfapplication.InnerHtml = "Verification of Applcation-After Inspection (DLO - " + DistrictName + ")";
                                        //  BindDLORecomendedIncentives(IncentiveId, Role_Code);
                                    }
                                    if (Role_Code == "COI-CLERK" || Role_Code == "COI-SUPDT" || Role_Code == "COI-AD" || Role_Code == "COI-DD" || Role_Code == "JD")
                                    {

                                        BindRecomendedIncentivesDetails(IncentiveId, Role_Code);
                                    }
                                    if (Role_Code == "IND")
                                    {
                                        gvUpdateInspectionDetails.Columns[7].Visible = false;
                                        SpanInspectionReport.InnerHtml = "Update Inspection Report (DIC - " + DistrictName + ")";
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

                //div5.Visible = true;
                //ddlIncentive.DataSource = dsapprovals.Tables["Table"];
                //ddlIncentive.DataValueField = "SubIncentiveID";
                //ddlIncentive.DataTextField = "IncentiveName";
                //ddlIncentive.DataBind();
            }
            else
            {
                div2.Visible = false;
            }
            AddSelect(ddlAppliedIncenties);
            // AddSelect(ddlIncentive);
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
                GetInspectingOfficers();
            }
            else
            {
                GvYetAssign.DataSource = null;
                GvYetAssign.DataBind();
                divGMVerification.Visible = false;
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

        /*  public void BindDLORecomendedIncentives(string incentiveID, string RoleCode)
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
          } */
        public void BindRecomendedIncentivesDetails(string incentiveID, string RoleCode)
        {

            try
            {
                ddlClerkIncentive.Items.Clear();
                ddlSupdtIncentive.Items.Clear();
                ddlADIncentive.Items.Clear();
                ddlDDIncentive.Items.Clear();

                DataSet dsapprovals = new DataSet();
                dsapprovals = GetIncetiveDropDownList(incentiveID, RoleCode);
                if (dsapprovals != null && dsapprovals.Tables.Count > 0 && dsapprovals.Tables[0].Rows.Count > 0)
                {
                    if (RoleCode == "COI-CLERK")
                    {
                        ViewState["divInspectionCompleted"] = dsapprovals;
                        ddlClerkIncentive.DataSource = dsapprovals.Tables["Table"];
                        ddlClerkIncentive.DataValueField = "SubIncentiveID";
                        ddlClerkIncentive.DataTextField = "IncentiveName";
                        ddlClerkIncentive.DataBind();
                        divClerklevel.Visible = true;
                    }
                    else { divClerklevel.Visible = false; }

                    if (RoleCode == "COI-SUPDT")
                    {
                        ViewState["divInspectionCompleted"] = dsapprovals;
                        ddlSupdtIncentive.DataSource = dsapprovals.Tables["Table"];
                        ddlSupdtIncentive.DataValueField = "SubIncentiveID";
                        ddlSupdtIncentive.DataTextField = "IncentiveName";
                        ddlSupdtIncentive.DataBind();
                        divSupdtlevel.Visible = true;
                    }
                    else { divSupdtlevel.Visible = false; }

                    if (RoleCode == "COI-AD")
                    {
                        ViewState["divInspectionCompleted"] = dsapprovals;
                        ddlADIncentive.DataSource = dsapprovals.Tables["Table"];
                        ddlADIncentive.DataValueField = "SubIncentiveID";
                        ddlADIncentive.DataTextField = "IncentiveName";
                        ddlADIncentive.DataBind();
                        divADlevel.Visible = true;

                    }
                    else { divADlevel.Visible = false; }

                    if (RoleCode == "COI-DD")
                    {
                        ViewState["divInspectionCompleted"] = dsapprovals;
                        ddlDDIncentive.DataSource = dsapprovals.Tables["Table"];
                        ddlDDIncentive.DataValueField = "SubIncentiveID";
                        ddlDDIncentive.DataTextField = "IncentiveName";
                        ddlDDIncentive.DataBind();
                        divDDlevel.Visible = true;
                    }
                    else { divDDlevel.Visible = false; }
                    if (RoleCode == "JD")
                    {
                        ViewState["divInspectionCompleted"] = dsapprovals;
                        ddlJDlevelInc.DataSource = dsapprovals.Tables["Table"];
                        ddlJDlevelInc.DataValueField = "SubIncentiveID";
                        ddlJDlevelInc.DataTextField = "IncentiveName";
                        ddlJDlevelInc.DataBind();
                        ddlJDlevelInc.Visible = true;
                    }
                    else { divJDlevel.Visible = false; }

                }
                else
                {
                    ViewState["divInspectionCompleted"] = null;
                    // Clerklevel.Visible = false;
                }
                AddSelect(ddlClerkIncentive);
                AddSelect(ddlSupdtIncentive);
                AddSelect(ddlADIncentive);
                AddSelect(ddlDDIncentive);
                AddSelect(ddlJDlevelInc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        /*   public string JDRecommendValidateControls()
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
           } */

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
            if (dss.Tables[3].Rows[0]["IsPaymentGateway"].ToString() == "Y")
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
            }
        }

        protected void ddlstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlstatus.SelectedValue == "1")
                {
                    Remarks.Visible = false;
                    Amount.Visible = true;
                    Query.Visible = false;
                    Div7.Visible = false;
                }
                else if (ddlstatus.SelectedValue == "Select")
                {
                    Remarks.Visible = false;
                    Query.Visible = false;
                    Amount.Visible = false;
                    Div7.Visible = false;
                }
                else if (ddlstatus.SelectedValue == "2")
                {
                    Query.Visible = true;
                    Remarks.Visible = false;
                    Amount.Visible = false;
                    Div7.Visible = false;
                }
                else if (ddlstatus.SelectedValue == "3")
                {
                    Div7.Visible = true;
                    Query.Visible = false;
                    Remarks.Visible = false;
                    Amount.Visible = false;
                }
                else
                {
                    Remarks.Visible = true;
                    Query.Visible = false;
                    Amount.Visible = false;
                    Div7.Visible = false;
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnlevel_Click(object sender, EventArgs e)
        {
            try
            {
                string Erromsg = ValidateControls1();
                if (Erromsg == "")
                {

                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    if (string.IsNullOrEmpty(ddlClerkIncentive.SelectedItem.Text) ||
                        string.IsNullOrEmpty(ddlstatus.SelectedItem.Text) ||
                        string.IsNullOrEmpty(ddlDepartment.SelectedValue))
                    {
                        lblmsg0.Text = "Please Enter All Details of Clerk Level";
                        Failure.Visible = true;
                    }
                    else
                    {
                        if (ddlstatus.SelectedValue == "1")
                        {
                            if (ddlClerkIncentive.SelectedValue == "3")
                            {
                                Response.Redirect("~/UI/Pages/ApprasialInterest.aspx?IncentiveID=" + ViewState["IncentiveId"] + "&SubIncentiveId=" + ddlClerkIncentive.SelectedValue.Trim().TrimStart());
                            }
                            else if (ddlClerkIncentive.SelectedValue == "1")
                            {
                                Response.Redirect("~/UI/Pages/CaptialSubsidyAppraisalNote.aspx?IncentiveID=" + ViewState["IncentiveId"] + "&SubIncentiveId=" + ddlClerkIncentive.SelectedValue.Trim().TrimStart());
                            }
                            else if (ddlClerkIncentive.SelectedValue == "6")
                            {
                                Response.Redirect("~/UI/Pages/TaxAppraisalNote.aspx?IncentiveID=" + ViewState["IncentiveId"] + "&SubIncentiveId=" + ddlClerkIncentive.SelectedValue.Trim().TrimStart());
                            }
                            else if (ddlClerkIncentive.SelectedValue == "4")
                            {
                                Response.Redirect("~/UI/Pages/PowerSubsidyAppraisalNote.aspx?IncentiveID=" + ViewState["IncentiveId"] + "&SubIncentiveId=" + ddlClerkIncentive.SelectedValue.Trim().TrimStart());
                            }
                            else if (ddlClerkIncentive.SelectedValue == "5")
                            {
                                Response.Redirect("~/UI/Pages/StampDutyAppraisal.aspx?IncentiveID=" + ViewState["IncentiveId"] + "&SubIncentiveId=" + ddlClerkIncentive.SelectedValue.Trim().TrimStart());
                            }
                            

                        }
                        else
                        {
                            DataTable dt = new DataTable();

                            if (ViewState["Clerklevel"] == null)
                            {
                                dt.Columns.Add("SubIncentiveID", typeof(string));
                                dt.Columns.Add("IncentiveName", typeof(string));
                                dt.Columns.Add("IncentiveId", typeof(string));
                                dt.Columns.Add("StatusName", typeof(string));
                                dt.Columns.Add("StatusId", typeof(string));
                                dt.Columns.Add("CLERK_Forwardto", typeof(string));
                                dt.Columns.Add("Recommendation", typeof(string));
                                dt.Columns.Add("Query", typeof(string));
                                dt.Columns.Add("Inspection", typeof(string));
                                dt.Columns.Add("Abeyance", typeof(string));
                            }
                            else
                            {
                                dt = (DataTable)ViewState["Clerklevel"];
                            }

                            DataRow dr = dt.NewRow();
                            dr["SubIncentiveID"] = ddlClerkIncentive.SelectedValue;
                            dr["IncentiveName"] = ddlClerkIncentive.SelectedItem.Text;
                            dr["IncentiveId"] = ViewState["IncentiveId"];
                            dr["StatusName"] = ddlstatus.SelectedItem.Text;
                            dr["StatusId"] = ddlstatus.SelectedValue;
                            dr["CLERK_Forwardto"] = ddlDepartment.SelectedValue;

                            switch (ddlstatus.SelectedValue)
                            {
                                case "1":
                                    dr["Recommendation"] = txtAmount.Text;
                                    break;
                                case "2":
                                    dr["Query"] = txtQuery.Text;
                                    break;
                                case "3":
                                    dr["Inspection"] = txtSSCRemarks.Text;
                                    break;
                                case "4":
                                    dr["Abeyance"] = txtRemark.Text;
                                    break;
                            }

                            dt.Rows.Add(dr);
                            GVDLO.Visible = true;
                            GVDLO.DataSource = dt;
                            GVDLO.DataBind();


                            ViewState["Clerklevel"] = dt;

                            ddlClerkIncentive.ClearSelection();
                            ddlstatus.ClearSelection();
                            ddlDepartment.ClearSelection();
                            txtAmount.Text = string.Empty;
                            txtQuery.Text = string.Empty;
                            txtSSCRemarks.Text = string.Empty;
                            txtRemark.Text = string.Empty;
                            if (GVDLO.Rows.Count > 0)
                            {
                                CLERK.Visible = true;
                                btnClerklevel.Visible = true;
                            }
                            else { btnClerklevel.Visible = false; CLERK.Visible = false; }

                        }
                    }
                }
                else
                {

                    string message = "alert('" + Erromsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = "An error occurred: " + ex.Message;
                Failure.Visible = true;
            }

        }
        public string ValidateControls1()
        {
            int slno = 1;
            string ErrorMsg = "";
            if (ddlClerkIncentive.SelectedIndex == -1 || ddlClerkIncentive.SelectedItem.Text == "--Select--")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Type of Incentive \\n";
                slno = slno + 1;
            }
            if (ddlstatus.SelectedIndex == -1 || ddlstatus.SelectedItem.Text == "--Select--")
            {

                ErrorMsg = ErrorMsg + slno + ". Please Select Status \\n";
                slno = slno + 1;
            }

            if (ddlstatus.SelectedValue == "1")
            {
                if (ddlClerkIncentive.SelectedValue != "3" && ddlClerkIncentive.SelectedValue != "1" && ddlClerkIncentive.SelectedValue != "6" && ddlClerkIncentive.SelectedValue != "4")
                {
                    if (txtAmount.Text == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Fill the Details Recommended Amount \\n";
                        slno = slno + 1;
                    }
                }
            }
            if (ddlstatus.SelectedValue == "2")
            {
                if (txtQuery.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Fill the Details Query Description \\n";
                    slno = slno + 1;
                }
            }
            if (ddlstatus.SelectedValue == "3")
            {
                if (txtSSCRemarks.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Fill the Details Remarks \\n";
                    slno = slno + 1;
                }
            }
            if (ddlstatus.SelectedValue == "4")
            {
                if (txtRemark.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Fill the Details  Abeyance Remarks \\n";
                    slno = slno + 1;
                }
            }

            if (ddlDepartment.SelectedIndex == -1 || ddlDepartment.SelectedItem.Text == "--Select--")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Forward To \\n";
                slno = slno + 1;
            }

            return ErrorMsg;
        }
        protected void GVDLO_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVDLO.Rows.Count > 0)
                {
                    ((DataTable)ViewState["Clerklevel"]).Rows.RemoveAt(e.RowIndex);
                    this.GVDLO.DataSource = ((DataTable)ViewState["Clerklevel"]).DefaultView;
                    this.GVDLO.DataBind();
                    GVDLO.Visible = true;
                    GVDLO.Focus();
                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }

                if (GVDLO.Rows.Count > 0)
                {
                    CLERK.Visible = true;
                    btnClerklevel.Visible = true;
                }
                else { btnClerklevel.Visible = false; CLERK.Visible = false; }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void GVDLO_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "StatusId").ToString();


                Label lblRecommand = (Label)e.Row.FindControl("lblRecommand");
                Label lblQuery = (Label)e.Row.FindControl("lblQuery");
                Label lblSSCInspection = (Label)e.Row.FindControl("lblSSCInspection");
                Label lblAbeyance = (Label)e.Row.FindControl("lblAbeyance");

                if (status == "1")
                {
                    lblRecommand.Visible = true;
                    lblQuery.Visible = false;
                    lblSSCInspection.Visible = false;
                    lblAbeyance.Visible = false;
                }
                else if (status == "2")
                {
                    lblRecommand.Visible = false;
                    lblQuery.Visible = true;
                    lblSSCInspection.Visible = false;
                    lblAbeyance.Visible = false;
                }
                else if (status == "3")
                {
                    lblRecommand.Visible = false;
                    lblQuery.Visible = false;
                    lblSSCInspection.Visible = true;
                    lblAbeyance.Visible = false;
                }
                else if (status == "4")
                {
                    lblRecommand.Visible = false;
                    lblQuery.Visible = false;
                    lblSSCInspection.Visible = false;
                    lblAbeyance.Visible = true;
                }
            }
        }

        protected void ddlStatus1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            try
            {
                if (ddlStatus1.SelectedValue == "Select")
                {
                    Forward.Visible = false;
                    Return.Visible = false;
                    Div5.Visible = false;
                    Div8.Visible = false;
                    Div9.Visible = false;
                    Div10.Visible = false;
                    ReturnRemarks.Visible = false;
                }
                else if (ddlStatus1.SelectedValue == "5")
                {
                    Return.Visible = true;
                    ReturnRemarks.Visible = true;
                    Forward.Visible = false;
                    Div5.Visible = false;
                    Div8.Visible = false;
                    Div9.Visible = false;
                    Div10.Visible = false;
                }
                else if (ddlStatus1.SelectedValue == "1")
                {
                    Div5.Visible = true;
                    Forward.Visible = true;
                    Return.Visible = false;
                    Div8.Visible = false;
                    Div9.Visible = false;
                    Div10.Visible = false;
                    ReturnRemarks.Visible = false;
                }
                else if (ddlStatus1.SelectedValue == "2")
                {
                    Div8.Visible = true;
                    Forward.Visible = true;
                    Div5.Visible = false;
                    Div9.Visible = false;
                    Div10.Visible = false;
                    Return.Visible = false;
                    ReturnRemarks.Visible = false;
                }
                else if (ddlStatus1.SelectedValue == "3")
                {
                    Div9.Visible = true;
                    Forward.Visible = true;
                    Return.Visible = false;
                    Div8.Visible = false;
                    Div10.Visible = false;
                    Div5.Visible = false;
                    ReturnRemarks.Visible = false;
                }
                else if (ddlStatus1.SelectedValue == "4")
                {
                    Div10.Visible = true;
                    Forward.Visible = true;
                    Div9.Visible = false;
                    Return.Visible = false;
                    Div8.Visible = false;
                    Div5.Visible = false;
                    ReturnRemarks.Visible = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ddlSupdtIncentive.SelectedItem.Text) ||
                    string.IsNullOrEmpty(ddlStatus1.SelectedItem.Text))
                {
                    lblmsg0.Text = "Please Enter All Details of Supdt Level";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();

                    if (ViewState["SUPDTLEVEL"] == null)
                    {

                        dt.Columns.Add("SubIncentiveID", typeof(string));
                        dt.Columns.Add("IncentiveName", typeof(string));
                        dt.Columns.Add("IncentiveId", typeof(string));
                        dt.Columns.Add("StatusName", typeof(string));
                        dt.Columns.Add("StatusId", typeof(string));
                        dt.Columns.Add("SUPDT_Forwardto", typeof(string));
                        dt.Columns.Add("SUPDT_Return", typeof(string));
                        dt.Columns.Add("Recommendation", typeof(string));
                        dt.Columns.Add("Query", typeof(string));
                        dt.Columns.Add("Inspection", typeof(string));
                        dt.Columns.Add("Abeyance", typeof(string));
                        dt.Columns.Add("ReturnRemark", typeof(string));


                    }
                    else
                    {
                        dt = (DataTable)ViewState["SUPDTLEVEL"];
                    }

                    DataRow dr = dt.NewRow();

                    dr["SubIncentiveID"] = ddlSupdtIncentive.SelectedValue;
                    dr["IncentiveName"] = ddlSupdtIncentive.SelectedItem.Text;
                    dr["IncentiveId"] = ViewState["IncentiveId"];
                    dr["StatusName"] = ddlStatus1.SelectedItem.Text;
                    dr["StatusId"] = ddlStatus1.SelectedValue;
                    if (ddlStatus1.SelectedValue == "5")
                    {
                        dr["SUPDT_Forwardto"] = ddlreturn.SelectedValue;
                    }
                    else { dr["SUPDT_Forwardto"] = ddlForward.SelectedValue; }



                    switch (ddlStatus1.SelectedValue)
                    {

                        case "1":
                            dr["Recommendation"] = txtRecomAmount.Text;
                            break;
                        case "2":
                            dr["Query"] = txtDescQuery.Text;
                            break;
                        case "3":
                            dr["Inspection"] = txtRemarkes.Text;
                            break;
                        case "4":
                            dr["Abeyance"] = txtAbeyanceRemark.Text;
                            break;
                        case "5":
                            dr["ReturnRemark"] = txtReturnRemark.Text;
                            break;

                    }

                    dt.Rows.Add(dr);
                    GVSUPDT.Visible = true;
                    GVSUPDT.DataSource = dt;
                    GVSUPDT.DataBind();


                    ViewState["SUPDTLEVEL"] = dt;

                    ddlSupdtIncentive.ClearSelection();
                    ddlStatus1.ClearSelection();
                    ddlForward.ClearSelection();
                    txtRecomAmount.Text = string.Empty;
                    txtDescQuery.Text = string.Empty;
                    txtRemarkes.Text = string.Empty;
                    txtAbeyanceRemark.Text = string.Empty;
                    SUPDTDetails.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = "An error occurred: " + ex.Message;
                Failure.Visible = true;
            }

        }

        protected void GVSUPDT_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "StatusId").ToString();

                Label lblRecommand = (Label)e.Row.FindControl("lblRecommand");
                Label lblQuery = (Label)e.Row.FindControl("lblQuery");
                Label lblInspection = (Label)e.Row.FindControl("lblSSCInspection");
                Label lblAbeyance = (Label)e.Row.FindControl("lblAbeyance");
                Label lblRemarks = (Label)e.Row.FindControl("lblReturn");

                if (status == "1")
                {
                    lblRecommand.Visible = true;
                    lblRemarks.Visible = false;
                    lblQuery.Visible = false;
                    lblInspection.Visible = false;
                    lblAbeyance.Visible = false;

                }
                else if (status == "2")
                {
                    lblRecommand.Visible = false;
                    lblQuery.Visible = true;
                    lblRemarks.Visible = false;
                    lblInspection.Visible = false;
                    lblAbeyance.Visible = false;

                }
                else if (status == "3")
                {
                    lblRecommand.Visible = false;
                    lblQuery.Visible = false;
                    lblInspection.Visible = true;
                    lblRemarks.Visible = false;
                    lblAbeyance.Visible = false;

                }
                else if (status == "4")
                {
                    lblRecommand.Visible = false;
                    lblQuery.Visible = false;
                    lblInspection.Visible = false;
                    lblAbeyance.Visible = true;
                    lblRemarks.Visible = false;

                }
                else if (status == "5")
                {
                    lblRecommand.Visible = false;
                    lblQuery.Visible = false;
                    lblInspection.Visible = false;
                    lblRemarks.Visible = true;
                    lblAbeyance.Visible = false;

                }

            }
        }

        protected void GVSUPDT_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                if (GVSUPDT.Rows.Count > 0)
                {
                    ((DataTable)ViewState["SUPDTLEVEL"]).Rows.RemoveAt(e.RowIndex);
                    this.GVSUPDT.DataSource = ((DataTable)ViewState["SUPDTLEVEL"]).DefaultView;
                    this.GVSUPDT.DataBind();
                    GVSUPDT.Visible = true;
                    GVSUPDT.Focus();
                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void btnaddbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ddlADIncentive.SelectedItem.Text) ||
                    string.IsNullOrEmpty(ddlsendstatus.SelectedItem.Text))
                {
                    lblmsg0.Text = "Please Enter All Details of AD Level";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();

                    if (ViewState["ADLEVEL"] == null)
                    {

                        dt.Columns.Add("SubIncentiveID", typeof(string));
                        dt.Columns.Add("IncentiveName", typeof(string));
                        dt.Columns.Add("IncentiveId", typeof(string));
                        dt.Columns.Add("StatusName", typeof(string));
                        dt.Columns.Add("StatusId", typeof(string));
                        dt.Columns.Add("AD_Forwardto", typeof(string));
                        //  dt.Columns.Add("SUPDT_Return", typeof(string));
                        dt.Columns.Add("Recommendation", typeof(string));
                        dt.Columns.Add("Query", typeof(string));
                        dt.Columns.Add("Inspection", typeof(string));
                        dt.Columns.Add("Abeyance", typeof(string));
                        dt.Columns.Add("ReturnRemark", typeof(string));
                    }
                    else
                    {
                        dt = (DataTable)ViewState["ADLEVEL"];
                    }

                    DataRow dr = dt.NewRow();

                    dr["SubIncentiveID"] = ddlADIncentive.SelectedValue;
                    dr["IncentiveName"] = ddlADIncentive.SelectedItem.Text;
                    dr["IncentiveId"] = ViewState["IncentiveId"];
                    dr["StatusName"] = ddlsendstatus.SelectedItem.Text;
                    dr["StatusId"] = ddlsendstatus.SelectedValue;
                    if (ddlsendstatus.SelectedValue == "5")
                    {
                        dr["AD_Forwardto"] = ddlsupdt.SelectedValue;
                    }
                    else { dr["AD_Forwardto"] = ddlsend.SelectedValue; }



                    switch (ddlsendstatus.SelectedValue)
                    {

                        case "1":
                            dr["Recommendation"] = txtAmounted.Text;
                            break;
                        case "2":
                            dr["Query"] = txtQueryDesced.Text;
                            break;
                        case "3":
                            dr["Inspection"] = txtRemarked.Text;
                            break;
                        case "4":
                            dr["Abeyance"] = txtAbeyRemark.Text;
                            break;
                        case "5":
                            dr["ReturnRemark"] = txtRemarkReturn.Text;
                            break;

                    }

                    dt.Rows.Add(dr);
                    GVAD.Visible = true;
                    GVAD.DataSource = dt;
                    GVAD.DataBind();


                    ViewState["ADLEVEL"] = dt;
                    ADLEVEL.Visible = true;

                    ddlADIncentive.ClearSelection();
                    ddlsendstatus.ClearSelection();
                    txtAmounted.Text = string.Empty;
                    txtQueryDesced.Text = string.Empty;
                    txtRemarked.Text = string.Empty;
                    txtAbeyRemark.Text = string.Empty;
                    txtRemarkReturn.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlsendstatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlsendstatus.SelectedValue == "Select")
                {
                    Div11.Visible = false;
                    Div12.Visible = false;
                    lblReturnto.Visible = false;
                    Div13.Visible = false;
                    Div14.Visible = false;
                    Div15.Visible = false;
                    Div16.Visible = false;
                }
                else if (ddlsendstatus.SelectedValue == "1")
                {
                    Div11.Visible = true;
                    Div13.Visible = true;
                    Div12.Visible = false;
                    Div14.Visible = false;
                    lblReturnto.Visible = false;
                    Div15.Visible = false;
                    Div16.Visible = false;

                }
                else if (ddlsendstatus.SelectedValue == "2")
                {
                    Div14.Visible = true;
                    Div11.Visible = true;
                    Div12.Visible = false;
                    lblReturnto.Visible = false;
                    Div13.Visible = false;
                    Div15.Visible = false;
                    Div16.Visible = false;
                }
                else if (ddlsendstatus.SelectedValue == "3")
                {
                    Div15.Visible = true;
                    Div11.Visible = true;
                    Div12.Visible = false;
                    lblReturnto.Visible = false;
                    Div13.Visible = false;
                    Div16.Visible = false;
                    Div14.Visible = false;
                }
                else if (ddlsendstatus.SelectedValue == "4")
                {
                    Div16.Visible = true;
                    Div11.Visible = true;
                    Div12.Visible = false;
                    lblReturnto.Visible = false;
                    Div13.Visible = false;
                    Div15.Visible = false;
                    Div14.Visible = false;
                }
                else if (ddlsendstatus.SelectedValue == "5")
                {
                    Div12.Visible = true;
                    lblReturnto.Visible = true;
                    Div11.Visible = false;
                    Div13.Visible = false;
                    Div14.Visible = false;
                    Div15.Visible = false;
                    Div16.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GVDD_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVAD.Rows.Count > 0)
                {
                    ((DataTable)ViewState["ADLEVEL"]).Rows.RemoveAt(e.RowIndex);
                    this.GVAD.DataSource = ((DataTable)ViewState["ADLEVEL"]).DefaultView;
                    this.GVAD.DataBind();
                    GVAD.Visible = true;
                    GVAD.Focus();
                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlStatused_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlStatused.SelectedValue == "Select")
                {
                    Div17.Visible = false;
                    Div18.Visible = false;
                    Div19.Visible = false;
                    Div20.Visible = false;
                    Div21.Visible = false;
                    Div22.Visible = false;
                    lblReturned.Visible = false;
                }
                else if (ddlStatused.SelectedValue == "1")
                {
                    Div17.Visible = true;
                    Div18.Visible = false;
                    Div19.Visible = true;
                    Div20.Visible = false;
                    Div21.Visible = false;
                    Div22.Visible = false;
                    lblReturned.Visible = false;
                }
                else if (ddlStatused.SelectedValue == "2")
                {
                    Div17.Visible = true;
                    Div18.Visible = false;
                    Div19.Visible = false;
                    Div20.Visible = true;
                    Div21.Visible = false;
                    Div22.Visible = false;
                    lblReturned.Visible = false;
                }
                else if (ddlStatused.SelectedValue == "3")
                {
                    Div17.Visible = true;
                    Div18.Visible = false;
                    Div19.Visible = false;
                    Div20.Visible = false;
                    Div21.Visible = true;
                    Div22.Visible = false;
                    lblReturned.Visible = false;
                }
                else if (ddlStatused.SelectedValue == "4")
                {
                    Div17.Visible = true;
                    Div18.Visible = false;
                    Div19.Visible = false;
                    Div20.Visible = false;
                    Div21.Visible = false;
                    Div22.Visible = true;
                    lblReturned.Visible = false;
                }
                else if (ddlStatused.SelectedValue == "5")
                {
                    Div17.Visible = false;
                    Div18.Visible = true;
                    lblReturned.Visible = true;
                    Div19.Visible = false;
                    Div20.Visible = false;
                    Div21.Visible = false;
                    Div22.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAdded_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ddlDDIncentive.SelectedItem.Text) ||
                    string.IsNullOrEmpty(ddlStatused.SelectedItem.Text))
                {
                    lblmsg0.Text = "Please Enter All Details of DD Level";
                    Failure.Visible = true;
                }
                else
                {
                    DataTable dt = new DataTable();

                    if (ViewState["DDLEVEL"] == null)
                    {
                        //dt.Columns.Add("Incentive", typeof(string));
                        //dt.Columns.Add("Status", typeof(string));
                        //dt.Columns.Add("Status2", typeof(string));
                        //dt.Columns.Add("Forward", typeof(string));
                        //// dt.Columns.Add("Clerk", typeof(string));
                        //dt.Columns.Add("Shape", typeof(string));
                        //dt.Columns.Add("Query", typeof(string));
                        //dt.Columns.Add("Inspection", typeof(string));
                        //dt.Columns.Add("Remarks", typeof(string));

                        dt.Columns.Add("SubIncentiveID", typeof(string));
                        dt.Columns.Add("IncentiveName", typeof(string));
                        dt.Columns.Add("IncentiveId", typeof(string));
                        dt.Columns.Add("StatusName", typeof(string));
                        dt.Columns.Add("StatusId", typeof(string));
                        dt.Columns.Add("DD_Forwardto", typeof(string));
                        dt.Columns.Add("Recommendation", typeof(string));
                        dt.Columns.Add("Query", typeof(string));
                        dt.Columns.Add("Inspection", typeof(string));
                        dt.Columns.Add("Abeyance", typeof(string));
                        dt.Columns.Add("ReturnRemark", typeof(string));

                    }
                    else
                    {
                        dt = (DataTable)ViewState["DDLEVEL"];
                    }

                    DataRow dr = dt.NewRow();
                    //dr["Incentive"] = ddlDDIncentive.SelectedItem.Text;
                    //dr["Status"] = ddlStatused.SelectedItem.Text;
                    //dr["Status2"] = ddlStatused.SelectedValue;
                    //dr["Forward"] = ddlSendedto.SelectedValue;

                    dr["SubIncentiveID"] = ddlDDIncentive.SelectedValue;
                    dr["IncentiveName"] = ddlDDIncentive.SelectedItem.Text;
                    dr["IncentiveId"] = ViewState["IncentiveId"];
                    dr["StatusName"] = ddlStatused.SelectedItem.Text;
                    dr["StatusId"] = ddlStatused.SelectedValue;
                    if (ddlStatused.SelectedValue == "5")
                    {
                        dr["DD_Forwardto"] = ddlReturnto.SelectedValue;
                    }
                    else { dr["DD_Forwardto"] = ddlSendedto.SelectedValue; }



                    switch (ddlStatused.SelectedValue)
                    {

                        case "1":
                            dr["Recommendation"] = txtAmountRe.Text;
                            break;
                        case "2":
                            dr["Query"] = txtdescQuery1.Text;
                            break;
                        case "3":
                            dr["Inspection"] = txtIncepctioned.Text;
                            break;
                        case "4":
                            dr["Abeyance"] = txtAbeyanceRemar.Text;
                            break;
                        case "5":
                            dr["ReturnRemark"] = txtRetrned.Text;
                            break;

                    }

                    dt.Rows.Add(dr);
                    GVDD.Visible = true;
                    GVDD.DataSource = dt;
                    GVDD.DataBind();


                    ViewState["DDLEVEL"] = dt;

                    DDLEVEL.Visible = true;

                    ddlDDIncentive.ClearSelection();
                    ddlStatused.ClearSelection();
                    txtAmountRe.Text = string.Empty;
                    txtdescQuery1.Text = string.Empty;
                    txtIncepctioned.Text = string.Empty;
                    txtAbeyanceRemar.Text = string.Empty;
                    txtRetrned.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GVDD_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (GVDD.Rows.Count > 0)
                {
                    ((DataTable)ViewState["DDLEVEL"]).Rows.RemoveAt(e.RowIndex);
                    this.GVDD.DataSource = ((DataTable)ViewState["DDLEVEL"]).DefaultView;
                    this.GVDD.DataBind();
                    GVDD.Visible = true;
                    GVDD.Focus();
                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnClerklevel_Click(object sender, EventArgs e)
        {
            try
            {

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                DLOApplication DLODetails = new DLOApplication();

                for (int i = 0; i < GVDLO.Rows.Count; i++)
                {
                    Label lblstatus = (Label)GVDLO.Rows[i].FindControl("lblstatus");
                    Label lblSubIncID = (Label)GVDLO.Rows[i].FindControl("lblSubIncID");
                    Label lblRecommand = (Label)GVDLO.Rows[i].FindControl("lblRecommand");
                    Label lblQuery = (Label)GVDLO.Rows[i].FindControl("lblQuery");
                    Label lblSSCInspection = (Label)GVDLO.Rows[i].FindControl("lblSSCInspection");
                    Label lblAbeyance = (Label)GVDLO.Rows[i].FindControl("lblAbeyance");

                    DLODetails.INCENTIVEID = ViewState["IncentiveId"].ToString();
                    DLODetails.SUBINCENTIVEID = lblSubIncID.Text;
                    DLODetails.ACTIONID = lblstatus.Text;
                    DLODetails.RECOMMENDEAMOUNT = lblRecommand.Text;
                    DLODetails.QUERY_REMARKS = lblQuery.Text;
                    DLODetails.SSCINSP_REMARKS = lblSSCInspection.Text;
                    DLODetails.ABEYANCE_REMARKS = lblAbeyance.Text;
                    DLODetails.FORWARDTO = GVDLO.Rows[i].Cells[5].Text;
                    DLODetails.CREATEDBY = ObjLoginNewvo.uid;


                    string result = ObjCAFClass.InsertClerkDetails(DLODetails);

                    if (result == "1")
                    {
                        lblmsg.Text = "Application Process Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        ClerkProcess.Visible = true;
                        BindCoiProcess();
                    }
                    else { Failure.Visible = false; }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ValidateControls2()
        {
            int slno = 1;
            string ErrorMsg = "";
            if (ddlClerkIncentive.SelectedIndex == -1)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Type of Incentive \\n";
                slno = slno + 1;
            }
            if (ddlstatus.SelectedValue == "0")
            {

            }

            return ErrorMsg;
        }


        protected void btnSUPDTLevl_Click(object sender, EventArgs e)
        {
            try
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                DLOApplication DLODetails = new DLOApplication();

                for (int i = 0; i < GVSUPDT.Rows.Count; i++)
                {
                    Label lblstatus = (Label)GVSUPDT.Rows[i].FindControl("lblstatus");
                    Label lblSubIncID = (Label)GVSUPDT.Rows[i].FindControl("lblSubIncID");
                    Label lblRecommand = (Label)GVSUPDT.Rows[i].FindControl("lblRecommand");
                    Label lblQuery = (Label)GVSUPDT.Rows[i].FindControl("lblQuery");
                    Label lblSSCInspection = (Label)GVSUPDT.Rows[i].FindControl("lblSSCInspection");
                    Label lblAbeyance = (Label)GVSUPDT.Rows[i].FindControl("lblAbeyance");
                    Label lblSend = (Label)GVSUPDT.Rows[i].FindControl("lblSend");
                    Label lblReturn = (Label)GVSUPDT.Rows[i].FindControl("lblReturn");

                    DLODetails.INCENTIVEID = ViewState["IncentiveId"].ToString();
                    DLODetails.SUBINCENTIVEID = lblSubIncID.Text;
                    DLODetails.ACTIONID = lblstatus.Text;
                    DLODetails.RECOMMENDEAMOUNT = lblRecommand.Text;
                    DLODetails.QUERY_REMARKS = lblQuery.Text;
                    DLODetails.SSCINSP_REMARKS = lblSSCInspection.Text;
                    DLODetails.ABEYANCE_REMARKS = lblAbeyance.Text;
                    DLODetails.FORWARDTO = lblSend.Text;
                    DLODetails.RETURN_REMARKS = lblReturn.Text;
                    DLODetails.CREATEDBY = ObjLoginNewvo.uid;

                    string result = ObjCAFClass.InsertSUPDTLevel(DLODetails);

                    if (result == "1")
                    {
                        //success.Visible = true;
                        //lblmsg.Text = " Details Submitted Successfully";
                        success.Visible = true;
                        lblmsg.Text = "Application Process Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        divSupdtlevel.Visible = false;
                        BindCoiProcess();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                    //if (dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                    //{
                    //    if ((dss.Tables[0].Rows[0]["Stageid"]?.ToString() == "26" || dss.Tables[0].Rows[0]["Stageid"]?.ToString() == "65" || dss.Tables[0].Rows[0]["Stageid"]?.ToString() == "68" || dss.Tables[0].Rows[0]["Stageid"]?.ToString() == "71" || dss.Tables[0].Rows[0]["CLERK_Process_CompleteFlg"] == null) && ObjLoginNewvo.Role_Code == "COI-CLERK")
                    //    {
                    //        divClerklevel.Visible = true;
                    //    }
                    //    else { divClerklevel.Visible = false; }
                    //    if ((dss.Tables[0].Rows[0]["Stageid"]?.ToString() == "58" || dss.Tables[0].Rows[0]["Stageid"]?.ToString() == "69" || dss.Tables[0].Rows[0]["Stageid"]?.ToString() == "72" || dss.Tables[0].Rows[0]["SUPDT_Process_CompleteFlg"] == null) && ObjLoginNewvo.Role_Code == "COI-SUPDT")
                    //    {
                    //        divSupdtlevel.Visible = true;
                    //    }
                    //    else { divSupdtlevel.Visible = false; }
                    //    if ((dss.Tables[0].Rows[0]["Stageid"]?.ToString() == "62" || dss.Tables[0].Rows[0]["Stageid"]?.ToString() == "73" || dss.Tables[0].Rows[0]["Stageid"]?.ToString() == "59" || dss.Tables[0].Rows[0]["AD_Process_CompleteFlg"] == null) && ObjLoginNewvo.Role_Code == "COI-AD")
                    //    {
                    //        divADlevel.Visible = true;
                    //    }
                    //    else { divADlevel.Visible = false; }

                    //    if ((dss.Tables[0].Rows[0]["Stageid"]?.ToString() == "60" || dss.Tables[0].Rows[0]["Stageid"]?.ToString() == "66" || dss.Tables[0].Rows[0]["Stageid"]?.ToString() == "74" || dss.Tables[0].Rows[0]["Stageid"]?.ToString() == "63" || dss.Tables[0].Rows[0]["DD_Process_CompleteFlg"] == null) && ObjLoginNewvo.Role_Code == "COI-DD")
                    //    {
                    //        divDDlevel.Visible = true;
                    //    }
                    //    else { divDDlevel.Visible = false; }

                    //}
                    if (dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
                        {
                            if ((dss.Tables[0].Rows[i]["Stageid"]?.ToString() == "26" || dss.Tables[0].Rows[i]["Stageid"]?.ToString() == "65" || dss.Tables[0].Rows[i]["Stageid"]?.ToString() == "68" || dss.Tables[0].Rows[i]["Stageid"]?.ToString() == "71" || dss.Tables[0].Rows[i]["CLERK_Process_CompleteFlg"] == null) && ObjLoginNewvo.Role_Code == "COI-CLERK")
                            {
                                divClerklevel.Visible = true;
                            }

                            // else { divClerklevel.Visible = false; }
                            if ((dss.Tables[0].Rows[i]["Stageid"]?.ToString() == "58" || dss.Tables[0].Rows[i]["Stageid"]?.ToString() == "69" || dss.Tables[0].Rows[i]["Stageid"]?.ToString() == "72" || dss.Tables[0].Rows[i]["SUPDT_Process_CompleteFlg"] == null) && ObjLoginNewvo.Role_Code == "COI-SUPDT")
                            {
                                divSupdtlevel.Visible = true;
                            }
                            //else { divSupdtlevel.Visible = false; }
                            if ((dss.Tables[0].Rows[i]["Stageid"]?.ToString() == "59" || dss.Tables[0].Rows[i]["Stageid"]?.ToString() == "62" || dss.Tables[0].Rows[i]["Stageid"]?.ToString() == "73" || dss.Tables[0].Rows[i]["AD_Process_CompleteFlg"] == null) && ObjLoginNewvo.Role_Code == "COI-AD")
                            {
                                divADlevel.Visible = true;
                            }
                            // else { divADlevel.Visible = false; }

                            if ((dss.Tables[0].Rows[i]["Stageid"]?.ToString() == "60" || dss.Tables[0].Rows[i]["Stageid"]?.ToString() == "66" || dss.Tables[0].Rows[i]["Stageid"]?.ToString() == "77" || dss.Tables[0].Rows[i]["Stageid"]?.ToString() == "63" || dss.Tables[0].Rows[0]["DD_Process_CompleteFlg"] == null) && ObjLoginNewvo.Role_Code == "COI-DD")
                            {
                                divDDlevel.Visible = true;
                            }
                            if ((dss.Tables[0].Rows[i]["Stageid"]?.ToString() == "70" || dss.Tables[0].Rows[i]["Stageid"]?.ToString() == "67" || dss.Tables[0].Rows[i]["Stageid"]?.ToString() == "64" || dss.Tables[0].Rows[i]["Stageid"]?.ToString() == "61" || dss.Tables[0].Rows[0]["DD_Process_CompleteFlg"] == null) && ObjLoginNewvo.Role_Code == "JD")
                            {
                                divJDlevel.Visible = true;
                            }
                            //else { divDDlevel.Visible = false; }
                        }
                    }
                    if (dss != null && dss.Tables.Count > 0 && dss.Tables[1].Rows.Count > 0)
                    {


                        GVRemark.DataSource = dss.Tables[1];
                        GVRemark.DataBind();
                        ClerkProcess.Visible = true;
                        Rmarkes1.Visible = true;
                        for (int i = 0; i < dss.Tables[1].Rows.Count; i++)
                        {
                            Label enterid = (Label)GVRemark.Rows[i].FindControl("lblIncentiveID");
                            Label lblMstIncentiveId = (Label)GVRemark.Rows[i].FindControl("lblSubIncentiveId");
                            if (lblMstIncentiveId.Text == "3")
                            {
                                (GVRemark.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl =
        "~/UI/Pages/InterestSubsidyAppraisalNote.aspx?incid=" + enterid.Text.Trim() +
        "&mstid=" + lblMstIncentiveId.Text.Trim();
                            }
                            if (lblMstIncentiveId.Text == "1")
                            {
                                (GVRemark.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl =
        "~/UI/Pages/CapitalSubsidy.aspx?incid=" + enterid.Text.Trim() +
        "&mstid=" + lblMstIncentiveId.Text.Trim();
                            }
                            if (lblMstIncentiveId.Text == "6")
                            {
                                (GVRemark.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl =
        "~/UI/Pages/TaxAppraisalPrint.aspx?incid=" + enterid.Text.Trim() +
        "&mstid=" + lblMstIncentiveId.Text.Trim();
                            }
                            if (lblMstIncentiveId.Text == "4")
                            {
                                (GVRemark.Rows[i].FindControl("anchortagGMCertificate") as HyperLink).NavigateUrl =
        "~/UI/Pages/PowerSubsidyAppraisalPrint.aspx?incid=" + enterid.Text.Trim() +
        "&mstid=" + lblMstIncentiveId.Text.Trim();
                            }
                            else
                            {

                            }

                        }

                    }
                    if (dss != null && dss.Tables.Count > 0 && dss.Tables[2].Rows.Count > 0)
                    {
                        GVSUPDTPROC.DataSource = dss.Tables[2];
                        GVSUPDTPROC.DataBind();
                        SUPDTPROCDET.Visible = true;
                        SupdtDetailsProc.Visible = true;
                        // divSupdtlevel.Visible = false;
                    }
                    if (dss != null && dss.Tables.Count > 0 && dss.Tables[3].Rows.Count > 0)
                    {
                        GVADPROC.DataSource = dss.Tables[3];
                        GVADPROC.DataBind();
                        ADPROCESSED.Visible = true;
                        ADPROCESS.Visible = true;
                        // divADlevel.Visible = false;
                    }
                    if (dss != null && dss.Tables.Count > 0 && dss.Tables[4].Rows.Count > 0)
                    {
                        GVDDPROC.DataSource = dss.Tables[4];
                        GVDDPROC.DataBind();
                        DDPROCESSEDDET.Visible = true;
                        DDProcessed.Visible = true;
                        //  divDDlevel.Visible = false;
                    }
                    ////sowjanya
                    if (dss != null && dss.Tables.Count > 0 && dss.Tables[5].Rows.Count > 0)
                    {
                        grdJDProcess.DataSource = dss.Tables[5];
                        grdJDProcess.DataBind();
                        divJDProcess.Visible = true;

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

        protected void btnAd_Click(object sender, EventArgs e)
        {
            try
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                DLOApplication DLODetails = new DLOApplication();

                for (int i = 0; i < GVAD.Rows.Count; i++)
                {
                    Label lblstatus = (Label)GVAD.Rows[i].FindControl("lblstatus");
                    Label lblSubIncID = (Label)GVAD.Rows[i].FindControl("lblSubIncID");
                    Label lblRecommand = (Label)GVAD.Rows[i].FindControl("lblRecommand");
                    Label lblQuery = (Label)GVAD.Rows[i].FindControl("lblQuery");
                    Label lblSSCInspection = (Label)GVAD.Rows[i].FindControl("lblSSCInspection");
                    Label lblAbeyance = (Label)GVAD.Rows[i].FindControl("lblAbeyance");
                    Label lblSend = (Label)GVAD.Rows[i].FindControl("lblSend");
                    Label lblReturn = (Label)GVAD.Rows[i].FindControl("lblReturn");

                    DLODetails.INCENTIVEID = ViewState["IncentiveId"].ToString();
                    DLODetails.SUBINCENTIVEID = lblSubIncID.Text;
                    DLODetails.ACTIONID = lblstatus.Text;
                    DLODetails.RECOMMENDEAMOUNT = lblRecommand.Text;
                    DLODetails.QUERY_REMARKS = lblQuery.Text;
                    DLODetails.SSCINSP_REMARKS = lblSSCInspection.Text;
                    DLODetails.ABEYANCE_REMARKS = lblAbeyance.Text;
                    DLODetails.FORWARDTO = lblSend.Text;
                    DLODetails.RETURN_REMARKS = lblReturn.Text;
                    DLODetails.CREATEDBY = ObjLoginNewvo.uid;

                    string result = ObjCAFClass.InsertADLevel(DLODetails);

                    if (result == "1")
                    {
                        //success.Visible = true;
                        //lblmsg.Text = " Details Submitted Successfully";
                        success.Visible = true;
                        lblmsg.Text = "Application Process Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        divADlevel.Visible = false;
                        BindCoiProcess();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnDDlevel_Click(object sender, EventArgs e)
        {
            try
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                DLOApplication DLODetails = new DLOApplication();

                for (int i = 0; i < GVDD.Rows.Count; i++)
                {
                    Label lblstatus = (Label)GVDD.Rows[i].FindControl("lblstatus");
                    Label lblSubIncID = (Label)GVDD.Rows[i].FindControl("lblSubIncID");
                    Label lblRecommand = (Label)GVDD.Rows[i].FindControl("lblRecommand");
                    Label lblQuery = (Label)GVDD.Rows[i].FindControl("lblQuery");
                    Label lblSSCInspection = (Label)GVDD.Rows[i].FindControl("lblSSCInspection");
                    Label lblAbeyance = (Label)GVDD.Rows[i].FindControl("lblAbeyance");
                    Label lblSend = (Label)GVDD.Rows[i].FindControl("lblSend");
                    Label lblReturn = (Label)GVDD.Rows[i].FindControl("lblReturn");

                    DLODetails.INCENTIVEID = ViewState["IncentiveId"].ToString();
                    DLODetails.SUBINCENTIVEID = lblSubIncID.Text;
                    DLODetails.ACTIONID = lblstatus.Text;
                    DLODetails.RECOMMENDEAMOUNT = lblRecommand.Text;
                    DLODetails.QUERY_REMARKS = lblQuery.Text;
                    DLODetails.SSCINSP_REMARKS = lblSSCInspection.Text;
                    DLODetails.ABEYANCE_REMARKS = lblAbeyance.Text;
                    DLODetails.FORWARDTO = lblSend.Text;
                    DLODetails.RETURN_REMARKS = lblReturn.Text;
                    DLODetails.CREATEDBY = ObjLoginNewvo.uid;

                    string result = ObjCAFClass.InsertDDLevel(DLODetails);

                    if (result == "1")
                    {
                        //success.Visible = true;
                        //lblmsg.Text = " Details Submitted Successfully";
                        success.Visible = true;
                        lblmsg.Text = "Application Process Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                        divDDlevel.Visible = false;
                        BindCoiProcess();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // ------------------------------sowjanya-----------------------------------
        protected void ddlJDAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlJDAction.SelectedValue != "0")
                {

                    if (ddlJDAction.SelectedValue == "1")
                    {
                        divJDRecmnd.Visible = true;
                        if (GVDDPROC.Rows.Count > 0)
                        {
                            foreach (GridViewRow gvrow in GVDDPROC.Rows)
                            {
                                int rowIndex = gvrow.RowIndex;
                                string SubIncentiveID = ((Label)gvrow.FindControl("lblSubIncID")).Text.ToString();
                                string Remarkstype = ((Label)gvrow.FindControl("lblREMARKS_TYPE")).Text.ToString();
                                string Remarks = ((Label)gvrow.FindControl("lblREMARKS")).Text.ToString();
                                if (ddlJDlevelInc.SelectedValue == SubIncentiveID && Remarkstype == "RECOMMENDED")
                                {
                                    txtJDRecAmount.Text = Remarks;
                                    break;
                                }
                            }

                        }
                        divJDQuery.Visible = false;
                        divJDreturn.Visible = false;
                        divJDSSCinsp.Visible = false;
                        divJDAbeyance.Visible = false;
                        divJDReject.Visible = false;

                        txtJDQueryRemarks.Text = ""; txtJDRejectRemarks.Text = "";
                        txtJDReturnRemarks.Text = ""; ddlJDReturnto.SelectedValue = "0";
                        txtJDSSCRemarks.Text = "";
                        txtJDAbeyanceRemarks.Text = "";
                    }
                    else if (ddlJDAction.SelectedValue == "2")
                    {
                        divJDRecmnd.Visible = false;
                        divJDQuery.Visible = true;
                        if (GVDDPROC.Rows.Count > 0)
                        {
                            foreach (GridViewRow gvrow in GVDDPROC.Rows)
                            {
                                int rowIndex = gvrow.RowIndex;
                                string SubIncentiveID = ((Label)gvrow.FindControl("lblSubIncID")).Text.ToString();
                                string Remarkstype = ((Label)gvrow.FindControl("lblREMARKS_TYPE")).Text.ToString();
                                string Remarks = ((Label)gvrow.FindControl("lblREMARKS")).Text.ToString();
                                if (ddlJDlevelInc.SelectedValue == SubIncentiveID && Remarkstype == "QUERY")
                                {
                                    txtJDQueryRemarks.Text = Remarks;
                                    break;
                                }
                            }
                        }
                        divJDreturn.Visible = false;
                        divJDSSCinsp.Visible = false;
                        divJDAbeyance.Visible = false;
                        divJDReject.Visible = false;

                        txtJDRecAmount.Text = ""; txtJDRejectRemarks.Text = "";
                        txtJDReturnRemarks.Text = ""; ddlJDReturnto.SelectedValue = "0";
                        txtJDSSCRemarks.Text = "";
                        txtJDAbeyanceRemarks.Text = "";
                    }
                    else if (ddlJDAction.SelectedValue == "3")
                    {
                        divJDRecmnd.Visible = false;
                        divJDQuery.Visible = false;
                        divJDreturn.Visible = false;
                        divJDSSCinsp.Visible = true;
                        if (GVDDPROC.Rows.Count > 0)
                        {
                            foreach (GridViewRow gvrow in GVDDPROC.Rows)
                            {
                                int rowIndex = gvrow.RowIndex;
                                string SubIncentiveID = ((Label)gvrow.FindControl("lblSubIncID")).Text.ToString();
                                string Remarkstype = ((Label)gvrow.FindControl("lblREMARKS_TYPE")).Text.ToString();
                                string Remarks = ((Label)gvrow.FindControl("lblREMARKS")).Text.ToString();
                                if (ddlJDlevelInc.SelectedValue == SubIncentiveID && Remarkstype == "SSC INSPECTION")
                                {
                                    txtJDSSCRemarks.Text = Remarks;
                                    break;
                                }
                            }
                        }
                        divJDAbeyance.Visible = false;
                        divJDReject.Visible = false;


                        txtJDRecAmount.Text = ""; txtJDQueryRemarks.Text = "";
                        txtJDReturnRemarks.Text = ""; ddlJDReturnto.ClearSelection();
                        txtJDAbeyanceRemarks.Text = ""; txtJDRejectRemarks.Text = "";
                    }
                    else if (ddlJDAction.SelectedValue == "4")
                    {
                        divJDRecmnd.Visible = false;
                        divJDQuery.Visible = false;
                        divJDreturn.Visible = false;
                        divJDSSCinsp.Visible = false;
                        divJDAbeyance.Visible = true;
                        if (GVDDPROC.Rows.Count > 0)
                        {
                            foreach (GridViewRow gvrow in GVDDPROC.Rows)
                            {
                                int rowIndex = gvrow.RowIndex;
                                string SubIncentiveID = ((Label)gvrow.FindControl("lblSubIncID")).Text.ToString();
                                string Remarkstype = ((Label)gvrow.FindControl("lblREMARKS_TYPE")).Text.ToString();
                                string Remarks = ((Label)gvrow.FindControl("lblREMARKS")).Text.ToString();
                                if (ddlJDlevelInc.SelectedValue == SubIncentiveID && Remarkstype == "ABEYANCE")
                                {
                                    txtJDAbeyanceRemarks.Text = Remarks;
                                    break;
                                }
                            }
                        }
                        divJDReject.Visible = false;

                        txtJDRecAmount.Text = ""; txtJDQueryRemarks.Text = "";
                        txtJDReturnRemarks.Text = ""; ddlJDReturnto.ClearSelection();
                        txtJDSSCRemarks.Text = ""; txtJDRejectRemarks.Text = "";
                    }
                    else if (ddlJDAction.SelectedValue == "5")
                    {
                        divJDRecmnd.Visible = false;
                        divJDQuery.Visible = false;
                        divJDreturn.Visible = true;
                        divJDSSCinsp.Visible = false;
                        divJDAbeyance.Visible = false;
                        divJDReject.Visible = false;
                        txtJDRecAmount.Text = ""; txtJDQueryRemarks.Text = "";
                        txtJDSSCRemarks.Text = ""; txtJDAbeyanceRemarks.Text = "";
                        txtJDRejectRemarks.Text = "";
                    }
                    else if (ddlJDAction.SelectedValue == "6")
                    {
                        divJDReject.Visible = true;
                        divJDRecmnd.Visible = false;
                        divJDQuery.Visible = false;
                        divJDreturn.Visible = false;
                        divJDSSCinsp.Visible = false;
                        divJDAbeyance.Visible = false;
                        txtJDRecAmount.Text = ""; txtJDQueryRemarks.Text = "";
                        txtJDReturnRemarks.Text = ""; ddlJDReturnto.ClearSelection();
                        txtJDSSCRemarks.Text = ""; txtJDAbeyanceRemarks.Text = "";
                    }
                }
                else
                {
                    divJDRecmnd.Visible = false;
                    divJDQuery.Visible = false;
                    divJDreturn.Visible = false;
                    divJDSSCinsp.Visible = false;
                    divJDAbeyance.Visible = false;
                    txtJDRecAmount.Text = ""; txtJDQueryRemarks.Text = "";
                    txtJDReturnRemarks.Text = ""; ddlJDReturnto.ClearSelection();
                    txtJDSSCRemarks.Text = ""; txtJDAbeyanceRemarks.Text = "";
                    txtJDRejectRemarks.Text = "";
                }
            }
            catch (Exception ex) { throw ex; }

        }

        protected void btnJDActionAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlJDlevelInc.Items.Count != 1)
                {
                    if (ddlJDlevelInc.SelectedValue == "0")
                    {
                        lblmsg0.Text = "Please Select Incentive Type";
                        Failure.Visible = true;
                    }
                    if (ddlJDAction.SelectedValue == "0")
                    {
                        lblmsg0.Text = "Please Select Option to Process";
                        Failure.Visible = true;
                    }
                    else if (ddlJDAction.SelectedValue == "1" && txtJDRecAmount.Text.Trim() == "")
                    {
                        lblmsg0.Text = "Please Enter Recommended Amount";
                        Failure.Visible = true;

                    }
                    else if (ddlJDAction.SelectedValue == "2" && txtJDQueryRemarks.Text.Trim() == "")
                    {
                        lblmsg0.Text = "Please Enter Query Remarks";
                        Failure.Visible = true;

                    }
                    else if (ddlJDAction.SelectedValue == "3" && txtJDSSCRemarks.Text.Trim() == "")
                    {
                        lblmsg0.Text = "Please Enter SSC Inspection Remarks";
                        Failure.Visible = true;

                    }
                    else if (ddlJDAction.SelectedValue == "4" && txtJDAbeyanceRemarks.Text.Trim() == "")
                    {
                        lblmsg0.Text = "Please Enter Abeyance Remarks";
                        Failure.Visible = true;

                    }
                    else if (ddlJDAction.SelectedValue == "5" && (txtJDReturnRemarks.Text.Trim() == "" || ddlJDReturnto.SelectedValue == "0"))
                    {
                        if (txtJDReturnRemarks.Text.Trim() == "")
                        {
                            lblmsg0.Text = "Please Enter Return Remarks";
                            Failure.Visible = true;
                        }
                        if (ddlJDReturnto.SelectedValue == "0")
                        {
                            lblmsg0.Text = lblmsg0.Text + " \n" + "Please select officer to Return";
                            Failure.Visible = true;
                        }
                    }
                    else if (ddlJDAction.SelectedValue == "6" && txtJDRejectRemarks.Text.Trim() == "")
                    {
                        lblmsg0.Text = "Please Enter Rejection Remarks";
                        Failure.Visible = true;

                    }
                    else
                    {
                        DataTable dt = new DataTable();

                        if (ViewState["JDLEVEL"] == null)
                        {

                            dt.Columns.Add("SubIncentiveID", typeof(string));
                            dt.Columns.Add("IncentiveName", typeof(string));
                            dt.Columns.Add("IncentiveId", typeof(string));
                            dt.Columns.Add("StatusName", typeof(string));
                            dt.Columns.Add("StatusId", typeof(string));
                            dt.Columns.Add("JD_Returnto", typeof(string));
                            dt.Columns.Add("RecmndAmount", typeof(string));
                            dt.Columns.Add("QueryRemarks", typeof(string));
                            dt.Columns.Add("SSCRemarks", typeof(string));
                            dt.Columns.Add("AbeyanceRemarks", typeof(string));
                            dt.Columns.Add("ReturnRemarks", typeof(string));
                            dt.Columns.Add("RejectRemarks", typeof(string));

                        }
                        else
                        {
                            dt = (DataTable)ViewState["JDLEVEL"];
                        }

                        DataRow dr = dt.NewRow();

                        dr["SubIncentiveID"] = ddlJDlevelInc.SelectedValue;
                        dr["IncentiveName"] = ddlJDlevelInc.SelectedItem.Text;
                        dr["IncentiveId"] = ViewState["IncentiveId"];
                        dr["StatusName"] = ddlJDAction.SelectedItem.Text;
                        dr["StatusId"] = ddlJDAction.SelectedValue;
                        dr["RecmndAmount"] = txtJDRecAmount.Text;
                        dr["QueryRemarks"] = txtJDQueryRemarks.Text;
                        dr["SSCRemarks"] = txtJDSSCRemarks.Text;
                        dr["AbeyanceRemarks"] = txtJDAbeyanceRemarks.Text;
                        dr["ReturnRemarks"] = txtJDReturnRemarks.Text;
                        dr["RejectRemarks"] = txtJDRejectRemarks.Text;
                        if (ddlJDAction.SelectedValue == "5")
                        {
                            dr["JD_Returnto"] = ddlJDReturnto.SelectedValue;
                        }


                        dt.Rows.Add(dr);
                        grdJDAction.Visible = true;
                        grdJDAction.DataSource = dt;
                        grdJDAction.DataBind();
                        btnJDSubmitAction.Visible = true;

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (Convert.ToString(dr["StatusId"]) == "5")
                            {
                                grdJDAction.Columns[5].Visible = true;
                                break;
                            }
                        }
                        ViewState["JDLEVEL"] = dt;


                        ddlJDlevelInc.Items.Remove(ddlJDlevelInc.Items.FindByValue(ddlJDlevelInc.SelectedValue));
                        ddlJDlevelInc.ClearSelection();
                        ddlJDAction.ClearSelection();
                        ddlJDAction_SelectedIndexChanged(sender, e);

                        txtJDRecAmount.Text = string.Empty;
                        txtJDQueryRemarks.Text = string.Empty;
                        txtJDSSCRemarks.Text = string.Empty;
                        txtJDReturnRemarks.Text = string.Empty;
                        txtJDRejectRemarks.Text = string.Empty;
                        ddlJDReturnto.ClearSelection();


                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnJDSubmitAction_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdJDAction.Rows.Count > 0)
                {
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                    DLOApplication DLODetails = new DLOApplication();

                    for (int i = 0; i < grdJDAction.Rows.Count; i++)
                    {
                        Label lblstatus = (Label)grdJDAction.Rows[i].FindControl("lblstatus");
                        Label lblSubIncID = (Label)grdJDAction.Rows[i].FindControl("lblSubIncID");
                        Label lblRecommand = (Label)grdJDAction.Rows[i].FindControl("lblRecommand");
                        Label lblQuery = (Label)grdJDAction.Rows[i].FindControl("lblQuery");
                        Label lblSSCInspection = (Label)grdJDAction.Rows[i].FindControl("lblSSCInspection");
                        Label lblAbeyance = (Label)grdJDAction.Rows[i].FindControl("lblAbeyance");
                        Label lblSend = (Label)grdJDAction.Rows[i].FindControl("lblSend");
                        Label lblReturn = (Label)grdJDAction.Rows[i].FindControl("lblReturn");
                        Label lblReject = (Label)grdJDAction.Rows[i].FindControl("lblReject");

                        DLODetails.INCENTIVEID = ViewState["IncentiveId"].ToString();
                        DLODetails.SUBINCENTIVEID = lblSubIncID.Text;
                        DLODetails.ACTIONID = lblstatus.Text;
                        DLODetails.RECOMMENDEAMOUNT = lblRecommand.Text;
                        DLODetails.QUERY_REMARKS = lblQuery.Text;
                        DLODetails.SSCINSP_REMARKS = lblSSCInspection.Text;
                        DLODetails.ABEYANCE_REMARKS = lblAbeyance.Text;
                        DLODetails.FORWARDTO = lblSend.Text;
                        DLODetails.RETURN_REMARKS = lblReturn.Text;
                        DLODetails.REJECTION_REMARKS = lblReject.Text;
                        DLODetails.CREATEDBY = ObjLoginNewvo.uid;

                        string result = ObjCAFClass.InsertJDLevel(DLODetails);

                        if (result == "1")
                        {
                            success.Visible = true;
                            lblmsg.Text = "Application Process Submitted Successfully";
                            string message = "alert('" + lblmsg.Text + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);

                            btnJDSubmitAction.Enabled = false;

                        }
                    }
                    BindCoiProcess();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void grdJDAction_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (grdJDAction.Rows.Count > 0)
                {
                    string IncentiveName = grdJDAction.Rows[e.RowIndex].Cells[1].Text;
                    string lblSubIncID = ((Label)grdJDAction.Rows[e.RowIndex].FindControl("lblSubIncID")).Text.ToString().Trim();
                    ListItem li = new ListItem();
                    li.Text = IncentiveName;
                    li.Value = lblSubIncID;
                    ddlJDlevelInc.Items.Add(li);

                    ((DataTable)ViewState["JDLEVEL"]).Rows.RemoveAt(e.RowIndex);
                    this.grdJDAction.DataSource = ((DataTable)ViewState["JDLEVEL"]).DefaultView;
                    this.grdJDAction.DataBind();
                    grdJDAction.Visible = true;
                    grdJDAction.Focus();
                    if (grdJDAction.Rows.Count > 0)
                        btnJDSubmitAction.Visible = true;
                    else
                        btnJDSubmitAction.Visible = false;

                }
                else
                {
                    Failure.Visible = true;
                    lblmsg0.Text = "";
                }

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }

        protected void grdJDAction_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}