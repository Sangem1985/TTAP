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


namespace TTAP.UI.Pages.MISReports
{
    public partial class frmIncentiveAbstractDrill : System.Web.UI.Page
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
                        
                        string Level="", DistrictId="";
                        if (Request.QueryString["Level"] != null)
                        {
                            Level = Request.QueryString["Level"].ToString();
                        }
                        
                        if (Request.QueryString["DistrictId"] != null)
                        {
                            DistrictId = Request.QueryString["DistrictId"].ToString();
                        }

                        lbtnback.PostBackUrl = "~/UI/Pages/MISReports/frmIncentiveAbstract.aspx";

                        dss = GetIncentiveAbstarctDrill(Level, DistrictId);
                        if (dss.Tables.Count > 0)
                        {
                            if (dss.Tables[0].Rows.Count > 0)
                            {
                                gvdetailsnew.DataSource = dss;
                                gvdetailsnew.DataBind();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
        public DataSet GetIncentiveAbstarctDrill(string Level, string DistrictId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@LEVEL",SqlDbType.VarChar),
               new SqlParameter("@DistrictId",SqlDbType.VarChar)
           };
            pp[0].Value = Level;
            pp[1].Value = DistrictId;

            Dsnew = caf.GenericFillDs("USP_GET_INCENTIVE_ABSTRACT_DRRIL", pp);

            return Dsnew;
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            Button ddlDeptnameFnl2 = (Button)sender;
            GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
            Label lblIncentiveID = (Label)row.FindControl("lblIncentiveID");
            Button Button1 = (Button)row.FindControl("btnProcess");

            string Level="", DistrictId="";
            if (Request.QueryString["Level"] != null)
            {
                Level = Request.QueryString["Level"].ToString();
            }

            if (Request.QueryString["DistrictId"] != null)
            {
                DistrictId = Request.QueryString["Level"].ToString();
            }
            //string status = ViewState["status"].ToString();//  Request.QueryString["Stg"].ToString().Trim();
            string newurl = "~/UI/frmDLOApplicationDetailsNew.aspx?Id=" + lblIncentiveID.Text.Trim() + "&Sts=" + Level;
            Response.Redirect(newurl);
        }
    }
}