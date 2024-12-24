using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TTAP.Classfiles;
using BusinessLogic;
using System.Data.SqlClient;

namespace TTAP.UI.Pages
{
    public partial class ApplicantIncentivesHistory : System.Web.UI.Page
    {
        General Gen = new General();
        comFunctions cmf = new comFunctions();
        comFunctions obcmf = new comFunctions();
        Fetch objFetch = new Fetch();
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (Session["uid"] == null)
            {
                Response.Redirect("~/loginReg.aspx");
            }
            ds = GetApplicantIncentivesHistory(Session["uid"].ToString());

            try
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();
                    trApplyAgainbtn.Visible = true;
                    trApplyAgainNote.Visible = true;
                    tr1.Visible = false;
                }
                else
                {
                    trApplyAgainbtn.Visible = false;
                    trApplyAgainNote.Visible = false;
                    tr1.Visible = true;
                }

                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    tradminqueris.Visible = true;
                    gvcommqueries.DataSource = ds.Tables[1];
                    gvcommqueries.DataBind();

                    //trhd1.Visible = false;
                    //trhd2.Visible = false;
                    //trhd3.Visible = false;
                    //trhd4.Visible = false;
                    tr1.Visible = false;
                    trApplyAgainbtn.Visible = false;
                    trApplyAgainNote.Visible = false;
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }
        protected void gvcommqueries_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label enterid = (e.Row.FindControl("lblIncentiveID") as Label);

                    Label lblQueryAtPendingQueries = (e.Row.FindControl("lblQueryAtPendingQueries") as Label);

                    Label lblPendingQueries = (e.Row.FindControl("lblPendingQueries") as Label);
                    

                    int Pendingqueriescount = 0;
                    Pendingqueriescount = Convert.ToInt32(lblPendingQueries.Text.ToString());

                    if (Pendingqueriescount > 0)
                    {
                        (e.Row.FindControl("anchortaglinkPendingQueries") as HyperLink).Visible = true;
                        (e.Row.FindControl("anchortaglinkPendingQueries") as HyperLink).NavigateUrl = "EnterQueryResponse.aspx?EntrpId=" + enterid.Text.Trim() + "&COMM=" + lblQueryAtPendingQueries.Text;
                    }
                    else
                    {
                        (e.Row.FindControl("anchortaglinkPendingQueries") as HyperLink).Visible = false;
                    }
                   

                    (e.Row.FindControl("anchortagApplicationNo") as HyperLink).NavigateUrl = "frmNewIncentive.aspx?IncentveID=" + enterid.Text.Trim();
                    (e.Row.FindControl("anchortagpaymentDetails") as HyperLink).NavigateUrl = "frmUserPaymentDetails.aspx?Id=" + enterid.Text.Trim();
                    (e.Row.FindControl("anchortaglinkSubmittedIncentives") as HyperLink).NavigateUrl = "frmNewIncentive.aspx?IncentveID=" + enterid.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }
        protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label enterid = (e.Row.FindControl("lblIncentiveID") as Label);
                    Label MstIncentiveId = (e.Row.FindControl("lblMstIncentiveId") as Label);

                    Label lblApplicationNo = (e.Row.FindControl("lblApplicationNo") as Label);
                    Label lblApplicationFiledDate = (e.Row.FindControl("lblApplicationFiledDate") as Label);
                    Label lblanchortaglinkPendingQueriesAtLevel = (e.Row.FindControl("anchortaglinkPendingQueriesAtLevel") as Label);
                    Label lblReminderQueries = (e.Row.FindControl("lblReminderQueries") as Label);
                    Label lblWorkingStatus = (e.Row.FindControl("lblWorkingStatus") as Label);

                    (e.Row.FindControl("anchortaglink") as HyperLink).NavigateUrl = "frmDraftApplication.aspx?EntrpId=" + enterid.Text.Trim();
                    (e.Row.FindControl("anchortaglinkStatus") as HyperLink).NavigateUrl = "IncentivesTracker.aspx?Enterid=" + enterid.Text.Trim();
                    (e.Row.FindControl("anchortaglinkIncentives") as HyperLink).NavigateUrl = "IncentivesTracker.aspx?Enterid=" + enterid.Text.Trim();

                    (e.Row.FindControl("anchortaglinkAcknowledgement") as HyperLink).NavigateUrl = "frmacknowledgement.aspx?EntrpId=" + enterid.Text.Trim() + "&MailFlag=N";
                    (e.Row.FindControl("anchortaglinkPendingQueries") as HyperLink).NavigateUrl = "EnterQueryResponse.aspx?EntrpId=" + enterid.Text.Trim();
                    (e.Row.FindControl("anchortagApplicationNo") as HyperLink).NavigateUrl = "frmNewIncentive.aspx?IncentveID=" + enterid.Text.Trim() +"&ViewType=V";

                    Label lblPendingQueries = (e.Row.FindControl("lblPendingQueries") as Label);
                    int Pendingqueriescount = 0;
                    Pendingqueriescount = Convert.ToInt32(lblPendingQueries.Text.ToString());

                    if (Pendingqueriescount > 0)
                    {
                        (e.Row.FindControl("anchortaglinkPendingQueries") as HyperLink).Visible = true;
                    }
                    else
                    {
                        (e.Row.FindControl("anchortaglinkPendingQueries") as HyperLink).Visible = false;
                    }
                    int ReminderQueries = 0;int WorkingStatusQuery = 0;
                    ReminderQueries = Convert.ToInt32(lblReminderQueries.Text.ToString());
                    WorkingStatusQuery = Convert.ToInt32(lblWorkingStatus.Text.ToString());
                    if (ReminderQueries > 0)
                    {
                        (e.Row.FindControl("anchortaglinkReminder") as HyperLink).Visible = true;
                        (e.Row.FindControl("anchortaglinkReminder") as HyperLink).NavigateUrl = "~/UI/Pages//ReminderQueries.aspx?IncentiveId=" + enterid.Text.Trim() + "&UserType=UH";
                    }
                    else
                    {
                        (e.Row.FindControl("anchortaglinkReminder") as HyperLink).Visible = false;
                    }
                    if (WorkingStatusQuery > 0)
                    {
                        (e.Row.FindControl("anchortaglinkWorkingStatus") as HyperLink).Visible = true;
                        (e.Row.FindControl("anchortaglinkWorkingStatus") as HyperLink).NavigateUrl = "~/UI/Pages//FormWorkingStatusUpdate.aspx?IncentiveId=" + enterid.Text.Trim() + "&UserType=UH";
                    }
                    else
                    {
                        (e.Row.FindControl("anchortaglinkWorkingStatus") as HyperLink).Visible = false;
                    }

                    (e.Row.FindControl("anchortagpaymentDetails") as HyperLink).NavigateUrl = "frmUserPaymentDetails.aspx?Id=" + enterid.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }

        protected void btnApplyAgain_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Pages/frmNewIncentive.aspx");
        }

        public DataSet GetApplicantIncentivesHistory(string USERID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UserID",SqlDbType.VarChar)

           };
            pp[0].Value = USERID;

            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_APPLICANT_INCENTIVES_HISTORY", pp);
            return Dsnew;
        }

    }
}