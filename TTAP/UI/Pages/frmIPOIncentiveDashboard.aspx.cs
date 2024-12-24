using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class frmIPOIncentiveDashboard : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            int DistId = 0;
            try
            {
                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {
                        string userid = Session["uid"].ToString();

                        DistId = Convert.ToInt32(Session["DistrictId"].ToString());
                        if (Request.QueryString["DistId"] != null)
                        {
                            DistId = Convert.ToInt32(Request.QueryString["DistId"].ToString());
                            Session["DistrictId"] = DistId;
                        }
                        dss = GetIPODashboard(userid);
                        if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                        {
                            lblAppl.Text= dss.Tables[0].Rows[0]["NoofapplicationsRcvd"].ToString();
                            lblYettoInspectWithin.Text = dss.Tables[0].Rows[0]["YetToInspectWithIn"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetIPODashboard(string userid)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UserId",SqlDbType.VarChar),
           };
            pp[0].Value = userid;
            Dsnew = caf.GenericFillDs("USP_GET_IPO_DASHBOARD_DTLS", pp);
            return Dsnew;
        }
    }
}