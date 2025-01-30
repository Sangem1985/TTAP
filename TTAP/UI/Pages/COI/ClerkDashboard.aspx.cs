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
    public partial class ClerkDashboard : System.Web.UI.Page
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
                        string userid = Session["uid"].ToString();

                        
                        dss = GetClerkDashboard(userid.ToString());
                        if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                        {                   

                            lblGMTotal.Text = dss.Tables[0].Rows[0]["TOTALNOOFAPPLICATIONS"].ToString();
                            lblPendingWithin.Text = dss.Tables[0].Rows[0]["PSCPENDINGWITHIN"].ToString();
                            lblPendingBeyond.Text = dss.Tables[0].Rows[0]["PSCPENDINGBEYOND"].ToString();
                            lblpendingTotal.Text = dss.Tables[0].Rows[0]["PSCPENDINGTOTAL"].ToString();
                            SUPDTRETURNED.Text = dss.Tables[0].Rows[0]["TOTALAPPLRETURNEDFROMSUPDT"].ToString();

                            lblQueryRes.Text = dss.Tables[0].Rows[0]["QUERIESRAISEDBYJD"].ToString();
                            lblQueryWITHIN.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDEDWITHIN"].ToString();
                            lblQueryBEYOND.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDEDBEYOND"].ToString();
                            lblTotalQueryRes.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDED"].ToString();
                            lblTotalRejected.Text = dss.Tables[0].Rows[0]["TOTALAUTOREJECTED"].ToString();

                            lblSendSUPDT.Text = dss.Tables[0].Rows[0]["TOTALAPPLFORWARDEDTOSUPDT"].ToString();

                            lblQRSPW.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDED_PENDINGWITHIN"].ToString();
                            lblQRSPB.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDED_PENDINGBEYOND"].ToString();
                            lblQRSPTotal.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDED_PENDINGTOTAL"].ToString();
                            lblQRRSUPDT.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDED_RETURNEDFROMSUPDT"].ToString();

                            lblQRForwardSUPDT.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDED_FORWARDEDTOSUPDT"].ToString();
                        }


                    }
                }
            }
            catch (Exception ex)

            {

                throw ex;
            }


            
        }


        public DataSet GetClerkDashboard(string UserID)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
                };
            pp[0].Value = UserID;

            //Dsnew = caf.GenericFillDs("getDLODashboard", pp);
            Dsnew = caf.GenericFillDs("SP_CLERKDASHBOARD", pp);
            return Dsnew;
        }
    }
}