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
    public partial class frmCommissionerDashboard : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            //int DistId = 0;
            try
            {
                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {
                        string userid = Session["uid"].ToString();

                        dss = GetRTGSPaymentVerification(userid);
                        if (dss.Tables.Count > 0)
                        {
                            lblAppl.Text = dss.Tables[0].Rows[0]["NoofapplicationsRcvd"].ToString();
                            lblPendingWithin.Text = dss.Tables[0].Rows[0]["Pending"].ToString();
                            lblpendingTotal.Text = dss.Tables[0].Rows[0]["Completed"].ToString();
                            lblrejected.Text = dss.Tables[0].Rows[0]["CommRejected"].ToString();

                            lblTotalQuery.Text = dss.Tables[0].Rows[0]["TOTALQUERIES"].ToString();
                            lblRepliedQueryWITHIN.Text = dss.Tables[0].Rows[0]["RESPQUERIES"].ToString();
                            lblOpenQuery.Text = dss.Tables[0].Rows[0]["AWATINGRESPQUERIES"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetRTGSPaymentVerification(string UserID)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UserID",SqlDbType.VarChar),
           };
            pp[0].Value = UserID;

            //Dsnew = caf.GenericFillDs("getDLODashboard", pp);
            Dsnew = caf.GenericFillDs("USP_GET_NEFTVERIFICATION_DASHBOARD_DTLS", pp);
            return Dsnew;
        }
    }
}