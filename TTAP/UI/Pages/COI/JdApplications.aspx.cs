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
    public partial class JdApplications : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();
        String Status = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {

                        if (Request.QueryString["Stg"] != null)
                        {
                            Status = Request.QueryString["Stg"].ToString();
                        }
                        if (Session["Search"] != null)
                        {
                            txtsearch.Text = Session["Search"].ToString();
                        }

                        lbtnback.PostBackUrl = "JdDashboard.aspx";
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

            dss = GetJDkApplications(Session["uid"].ToString(), Status);
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
        public DataSet GetJDkApplications(String USERID, String STATUS)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
               new SqlParameter("@STATUS",SqlDbType.VarChar)
           };
            pp[0].Value = USERID;
            pp[1].Value = STATUS;

            Dsnew = caf.GenericFillDs("SP_JDDASHBOARD_DRILLDOWN", pp);

            return Dsnew;
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                Button ddlDeptnameFnl2 = (Button)sender;
                GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
                Label lblIncentiveID = (Label)row.FindControl("lblIncentiveID");
                Button Button1 = (Button)row.FindControl("btnProcess");

                if (Request.QueryString["Stg"] != null)
                {
                    Status = Request.QueryString["Stg"].ToString();
                }
                if (txtsearch.Text.Trim().TrimStart() != "")
                {
                    Session["Search"] = txtsearch.Text.Trim().TrimStart();
                }
                string newurl = "~/UI/COIApplicationDetails.aspx?Id=" + lblIncentiveID.Text.Trim() + "&Sts=" + Status;
                Response.Redirect(newurl);
            }
            catch (Exception ex)
            {

            }
        }
    }
}