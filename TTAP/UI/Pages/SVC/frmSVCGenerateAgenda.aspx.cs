using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TTAP.Classfiles;

namespace TTAP.UI.Pages.SVC
{
    public partial class frmSVCGenerateAgenda : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["ObjLoginvo"] != null && Request.QueryString.Count > 0)
                    {
                        int DistId = 0;
                        string status = Request.QueryString["Stage"].ToString().Trim();
                        DistId = Convert.ToInt32(Session["DistrictId"].ToString());
                        GetSLCGenerateDAgendaProposedDates(DistId.ToString(), status);
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
        public void GetSLCGenerateDAgendaProposedDates(string DistId, string status)
        {
            DataSet ds = new DataSet();
            string PartialSanction = "N";
            if (chkPartial.Checked == true)
            {
                PartialSanction = "Y";
            }
            ds = ObjCAFClass.GetSVCYetGenerateAgenda(DistId.ToString(), status, PartialSanction);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = ds.Tables[0];
                gvdetailsnew.DataBind();
            }
        }
        protected void gvdetailsnew_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSubIncentiveID = (e.Row.FindControl("lblSubIncentiveID") as Label);
                Button btnGenerate = (e.Row.FindControl("btnGenerate") as Button);
                if (lblSubIncentiveID.Text == "")
                {
                    btnGenerate.Visible = false;
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProposedDLCDate.Text.Trim().TrimStart().TrimEnd() == "")
                {
                    string message = "alert('Please Select Proposed DIPC Date')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    string PartialSanction = "N";
                    if (chkPartial.Checked == true)
                    {
                        PartialSanction = "Y";
                    }
                    int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
                    string lblMstIncentiveId = ((Label)gvdetailsnew.Rows[indexing].FindControl("lblSubIncentiveID")).Text;
                    string lblCategory1 = ((Label)gvdetailsnew.Rows[indexing].FindControl("lblCategoryid")).Text;
                    string Status = Request.QueryString["Stage"].ToString();
                    Response.Redirect("frmSVCGenerateAgendaList.aspx?Cast=" + lblCategory1 + "&SubIncentiveID=" + lblMstIncentiveId + "&ProposedDLCDate=" + txtProposedDLCDate.Text + "&Status=" + Status + "&PartialSanction=" + PartialSanction);
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }
        protected void chkPartial_CheckedChanged(object sender, EventArgs e)
        {   
            string status = Request.QueryString["Stage"].ToString().Trim();
            string DistId = "0";
            GetSLCGenerateDAgendaProposedDates(DistId, status);
        }
    }
}