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

namespace TTAP.UI.Pages.COI
{
    public partial class CommissionerDashBoard : System.Web.UI.Page
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
                    UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
                    ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];
                    
                    if (Session["uid"] != null)
                    {
                        string userid = Session["uid"].ToString();

                        DistId = Convert.ToInt32(Session["DistrictId"].ToString());
                        dss = GetDashboardCounts(userid.ToString());
                        if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                        {
                            lblPending.Text= dss.Tables[0].Rows[0]["Pending"].ToString();
                            lblApproved.Text = dss.Tables[0].Rows[0]["Approved"].ToString();
                            lblReturned.Text = dss.Tables[0].Rows[0]["Returned"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)

            {

                throw ex;
            }
        }
        public DataSet GetDashboardCounts(string UserID)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
           };
            pp[0].Value = UserID;
            Dsnew = caf.GenericFillDs("USP_GET_COMMISSIONER_DASHBOARD", pp);
            return Dsnew;
        }
    }
}