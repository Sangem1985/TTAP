using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTAP.Classfiles;

namespace TTAP.UI.Pages.COI
{
    public partial class DdApplications : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();
        string Status;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {
                        if (Request.QueryString["status"] != null)
                        {
                            Status = Request.QueryString["status"].ToString();
                        }
                        if (Session["Search"] != null)
                        {
                            txtsearch.Text = Session["Search"].ToString();
                        }

                        lbtnback.PostBackUrl = "DdDashboard.aspx";
                        BindApplicationData();
                        Session["Search"] = null;
                    }
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }

        }
        public void BindApplicationData()
        {

            dss = GetDDApplications(Session["uid"].ToString(), Status);
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
        public DataSet GetDDApplications(String USERID, String STATUS)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
               new SqlParameter("@STATUS",SqlDbType.VarChar)
           };
            pp[0].Value = USERID;
            pp[1].Value = STATUS;

            // Dsnew = caf.GenericFillDs("USP_GET_DLOAPPLICATIONS", pp);
            Dsnew = caf.GenericFillDs("SP_DDDASHBOARD_DRILLDOWN", pp);

            return Dsnew;
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            Button ddlDeptnameFnl2 = (Button)sender;
            GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
            Label lblIncentiveID = (Label)row.FindControl("lblIncentiveID");
            Button Button1 = (Button)row.FindControl("btnProcess");

            if (Request.QueryString["status"] != null)
            {
                Status = Request.QueryString["status"].ToString();
            }
            if (txtsearch.Text.Trim().TrimStart() != "")
            {
                Session["Search"] = txtsearch.Text.Trim().TrimStart();
            }
            string newurl = "~/UI/COIApplicationDetails.aspx?Id=" + lblIncentiveID.Text.Trim() + "&Sts=" + Status;
            Response.Redirect(newurl);
        }
    }
}