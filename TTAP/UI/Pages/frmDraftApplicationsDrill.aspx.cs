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

namespace TTAP.UI.Pages
{
    public partial class frmDraftApplicationsDrill : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();

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
                        if (Session["Search"] != null)
                        {
                            txtsearch.Text = Session["Search"].ToString();
                        }

                        lbtnback.PostBackUrl = "~/UI/Pages/frmDeptAdminDashBoard.aspx";

                        BindDraftApplications();
                        Session["Search"] = null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindDraftApplications()
        {
            DataSet dss = new DataSet();

            int Stg = 0;
            if (Request.QueryString["Stg"] != null)
            {
                Stg = Convert.ToInt32(Request.QueryString["Stg"].ToString());
            }

            dss = GetDraftApplications(Session["uid"].ToString(), Stg, txtsearch.Text.Trim().TrimStart());
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = dss;
                gvdetailsnew.DataBind();
            }
            else
            {
                gvdetailsnew.DataSource = dss;
                gvdetailsnew.DataBind();
            }
        }
        public DataSet GetDraftApplications(string UserID, int StageId, string UnitName)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UserID",SqlDbType.VarChar),
               new SqlParameter("@StageId",SqlDbType.Int),
               new SqlParameter("@UnitName",SqlDbType.VarChar)
           };
            pp[0].Value = UserID;
            pp[1].Value = StageId;
            pp[2].Value = UnitName;
            // Dsnew = caf.GenericFillDs("USP_GET_DLOAPPLICATIONS", pp);
            Dsnew = caf.GenericFillDs("USP_GET_DRAFTAPPLICATIONS_DTLS", pp);

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

            //string newurl = "~/UI/frmDLOApplicationDetailsNew.aspx?Id=" + lblIncentiveID.Text.Trim() + "&Sts=" + Stg;
            //Response.Redirect(newurl);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindDraftApplications();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtsearch.Text = "";
            BindDraftApplications();
        }
    }
}