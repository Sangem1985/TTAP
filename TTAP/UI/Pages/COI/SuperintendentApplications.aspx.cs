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
    public partial class SuperintendentApplications : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
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

                        lbtnback.PostBackUrl = "SuperintendentDashboard.aspx";
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

        protected void lbtnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Pages/COI/SuperintendentDashboard.aspx");
        }
        public void BindApplicationData()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = GetSupdtApplicationDrilldown(Session["uid"].ToString(), Status);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvdetailsnew.DataSource = ds;
                    gvdetailsnew.DataBind();
                }
                else
                {
                    gvdetailsnew.DataSource = ds;
                    gvdetailsnew.DataBind();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetSupdtApplicationDrilldown(string USERID, string STATUS)
        {
            try
            {
                DataSet Ds = new DataSet();
                SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
               new SqlParameter("@STATUS",SqlDbType.VarChar)
               };
                pp[0].Value = USERID;
                pp[1].Value = STATUS;
                Ds = caf.GenericFillDs("SP_SUPDTDASHBOARD_DRILLDOWN", pp);
                return Ds;
            }
            catch(Exception ex)
            {
                throw ex;
            }
          
            
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