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
    public partial class frmApllicationsforQuery : System.Web.UI.Page
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
                        if (Request.QueryString["Stg"] != null)
                        {
                            Stg = Convert.ToInt32(Request.QueryString["Stg"].ToString());
                        }
                        dss = GetApplicationsToGenerateQuery(Session["uid"].ToString(), Stg);
                        if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                        {
                            gvdetailsnew.DataSource = dss;
                            gvdetailsnew.DataBind();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
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
        public DataSet GetApplicationsToGenerateQuery(string UserID, int StageId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UserID",SqlDbType.VarChar),
               new SqlParameter("@StageId",SqlDbType.Int)
           };
            pp[0].Value = UserID;
            pp[1].Value = StageId;

            Dsnew = caf.GenericFillDs("USP_GET_ALLAPPLICATIONS_YETTOGENERATE__DTLS", pp);

            return Dsnew;
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            Button ddlDeptnameFnl2 = (Button)sender;
            GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
            Label lblIncentiveID = (Label)row.FindControl("lblIncentiveID");
            Button Button1 = (Button)row.FindControl("btnProcess");

            int Stg = 0;
            if (Request.QueryString["Stg"] != null)
            {
                Stg = Convert.ToInt32(Request.QueryString["Stg"].ToString());
            }

            //string newurl = "~/UI/Pages/frmDeptPaymentApproval.aspx?Id=" + lblIncentiveID.Text.Trim() + "&Sts=" + Stg;
            //Response.Redirect(newurl);

            //string newurl = "~/UI/Pages/QueryGeneration/frmGenerateQuery.aspx?Id=" + lblIncentiveID.Text.Trim() + "&Sts=" + Stg;
            string newurl = "~/UI/Pages/QueryGeneration/frmApllicationsforQueryDrill.aspx?Id=" + lblIncentiveID.Text.Trim() + "&Stg=" + Stg;
            
            Response.Redirect(newurl);
        }
    }
}