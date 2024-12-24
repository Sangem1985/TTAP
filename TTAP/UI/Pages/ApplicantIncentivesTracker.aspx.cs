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
    public partial class ApplicantIncentivesTracker : System.Web.UI.Page
    {
        General Gen = new General();
        comFunctions cmf = new comFunctions();
        comFunctions obcmf = new comFunctions();
        Fetch objFetch = new Fetch();
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtsearch.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter the text in Searchbox')", true);
                return;
            }
            DataSet ds = new DataSet();
            ds = GetApplicantIncentivesHistory(txtsearch.Text.Trim(), rdbSelection.SelectedValue);
            try
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();
                    tr1.Visible = false;
                }
                else
                {
                    tr1.Visible = true;
                }

                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    tradminqueris.Visible = true;
                    gvcommqueries.DataSource = ds.Tables[1];
                    gvcommqueries.DataBind();
                    tr1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = null;
            txtsearch.Text = "";
            grdDetails.DataSource = ds;
            grdDetails.DataBind();
            gvcommqueries.DataSource = ds;
            gvcommqueries.DataBind();
            tr1.Visible = false;
            tradminqueris.Visible = false;

        }
        protected void gvcommqueries_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label enterid = (e.Row.FindControl("lblIncentiveID") as Label);

                    Label lblQueryAtPendingQueries = (e.Row.FindControl("lblQueryAtPendingQueries") as Label);
                    
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
                   
                    (e.Row.FindControl("anchortaglinkStatus") as HyperLink).NavigateUrl = "IncentivesTracker.aspx?Enterid=" + enterid.Text.Trim();
                    (e.Row.FindControl("anchortaglinkIncentives") as HyperLink).NavigateUrl = "IncentivesTracker.aspx?Enterid=" + enterid.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }

        public DataSet GetApplicantIncentivesHistory(string SearchText, string Flag)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@SearchText",SqlDbType.VarChar),
               new SqlParameter("@FLAG",SqlDbType.VarChar)

           };
            pp[0].Value = SearchText;
            pp[1].Value = Flag;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_APPLICANT_INCENTIVES_TRACKER", pp);
            return Dsnew;
        }

    }
}

/*
  (e.Row.FindControl("anchortaglink") as HyperLink).NavigateUrl = "frmDraftApplication.aspx?EntrpId=" + enterid.Text.Trim();
  (e.Row.FindControl("anchortaglinkAcknowledgement") as HyperLink).NavigateUrl = "frmacknowledgement.aspx?EntrpId=" + enterid.Text.Trim() + "&MailFlag=N";
  Label lblPendingQueries = (e.Row.FindControl("lblPendingQueries") as Label);

                    int Pendingqueriescount = 0;
                    Pendingqueriescount = Convert.ToInt32(lblPendingQueries.Text.ToString());

                    if (Pendingqueriescount > 0)
                    {
                        (e.Row.FindControl("anchortaglinkPendingQueries") as HyperLink).Visible = true;
                        (e.Row.FindControl("anchortaglinkPendingQueries") as HyperLink).NavigateUrl = "EnterQueryResponse.aspx?EntrpId=" + enterid.Text.Trim() + "&COMM=" + lblQueryAtPendingQueries.Text + "&ViewType=H";
                    }
                    else
                    {
                        (e.Row.FindControl("anchortaglinkPendingQueries") as HyperLink).Visible = false;
                    }

     (e.Row.FindControl("anchortaglinkPendingQueries") as HyperLink).NavigateUrl = "EnterQueryResponse.aspx?EntrpId=" + enterid.Text.Trim() + "&ViewType=H";

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
                    (e.Row.FindControl("anchortagpaymentDetails") as HyperLink).NavigateUrl = "frmUserPaymentDetails.aspx?Id=" + enterid.Text.Trim();

    grid2

    (e.Row.FindControl("anchortagApplicationNo") as HyperLink).NavigateUrl = "frmNewIncentive.aspx?IncentveID=" + enterid.Text.Trim();
(e.Row.FindControl("anchortagpaymentDetails") as HyperLink).NavigateUrl = "frmUserPaymentDetails.aspx?Id=" + enterid.Text.Trim();
     */
