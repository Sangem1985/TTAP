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
    public partial class AdApplications : System.Web.UI.Page
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

                        lbtnBack.PostBackUrl = "AdDashboard.aspx";
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
            try
            {
                DataSet ds = new DataSet();
                ds = GetADApplicationDrilldown(Session["uid"].ToString(), Status);
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
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetADApplicationDrilldown(string USERID, string STATUS)
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
                Ds = caf.GenericFillDs("SP_ADDASHBOARD_DRILLDOWN", pp);
                return Ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        protected void lbtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/UI/Pages/COI/AdDashboard.aspx");
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
                //newurl = newurl + "&Search=" + txtsearch.Text.Trim().TrimStart();
            }
            //string status = ViewState["status"].ToString();//  Request.QueryString["Stg"].ToString().Trim();
            string newurl = "~/UI/COIApplicationDetails.aspx?Id=" + lblIncentiveID.Text.Trim() + "&status=" + Status;
            Response.Redirect(newurl);
        }
    }
}