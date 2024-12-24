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

namespace TTAP.UI.Pages.QueryGeneration
{
    public partial class frmApllicationsforQueryDrill : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {
                        int Stg = 0;
                        int IncentiveID = 0;
                        if (Request.QueryString["Stg"] != null)
                        {
                            Stg = Convert.ToInt32(Request.QueryString["Stg"].ToString());
                        }
                        if (Request.QueryString["Id"] != null)
                        {
                            IncentiveID = Convert.ToInt32(Request.QueryString["Id"].ToString());
                        }
                        dss = GetApplicationsToGenerateQuery(Session["uid"].ToString(), Stg, IncentiveID);
                        if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                        {
                            gvdetailsnew.DataSource = dss;
                            gvdetailsnew.DataBind();
                        }
                        else
                        {
                            string newurl = "~/UI/Pages/QueryGeneration/frmGenerateQuery.aspx?Id=" + IncentiveID + "&Sts=" + Stg + "&MainQueryID=0";
                            Response.Redirect(newurl);
                        }
                    }
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
        public DataSet GetApplicationsToGenerateQuery(string UserID, int StageId, int IncentiveID)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UserID",SqlDbType.VarChar),
               new SqlParameter("@StageId",SqlDbType.Int),
                new SqlParameter("@IncentiveID",SqlDbType.Int)
           };
            pp[0].Value = UserID;
            pp[1].Value = StageId;
            pp[2].Value = IncentiveID;

            Dsnew = caf.GenericFillDs("USP_GET_GENERATED_APPS_QUERY_LETTERS", pp);

            return Dsnew;
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            Button ddlDeptnameFnl2 = (Button)sender;
            GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
            Label lblIncentiveID = (Label)row.FindControl("lblIncentiveID");
            Label lblMainQueryID = (Label)row.FindControl("lblMainQueryID");
            Button Button1 = (Button)row.FindControl("btnProcess");

            int Stg = 0;
            if (Request.QueryString["Stg"] != null)
            {
                Stg = Convert.ToInt32(Request.QueryString["Stg"].ToString());
            }

            //string newurl = "~/UI/Pages/frmDeptPaymentApproval.aspx?Id=" + lblIncentiveID.Text.Trim() + "&Sts=" + Stg;
            //Response.Redirect(newurl);

            string newurl = "~/UI/Pages/QueryGeneration/frmGenerateQuery.aspx?Id=" + lblIncentiveID.Text.Trim() + "&Sts=" + Stg + "&MainQueryID="+ lblMainQueryID.Text.Trim();
            Response.Redirect(newurl);
        }

        protected void btnGenerateQueryLetter_Click(object sender, EventArgs e)
        {
            int Stg = 0;
            int IncentiveID = 0;
            if (Request.QueryString["Stg"] != null)
            {
                Stg = Convert.ToInt32(Request.QueryString["Stg"].ToString());
            }
            if (Request.QueryString["Id"] != null)
            {
                IncentiveID = Convert.ToInt32(Request.QueryString["Id"].ToString());
            }

            string newurl = "~/UI/Pages/QueryGeneration/frmGenerateQuery.aspx?Id=" + IncentiveID + "&Sts=" + Stg + "&MainQueryID=0";
            Response.Redirect(newurl);
        }
    }
}