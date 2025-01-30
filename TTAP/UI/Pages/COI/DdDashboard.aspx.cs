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
    public partial class DdDashboard : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //  Session["uid"] = "33065";

                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {
                        string userid = Session["uid"].ToString();

                        dss = GetDdDashboard(userid);
                        if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                        {
                            lblAppl.Text = dss.Tables[0].Rows[0]["TOTALNOOFAPPLICATIONS"].ToString();
                            lblPendingWithin.Text = dss.Tables[0].Rows[0]["COIPENDINGWITHIN"].ToString();
                            lblPendingBeyond.Text = dss.Tables[0].Rows[0]["COIPENDINGBEYOND"].ToString();
                            lblpendingTotal.Text = dss.Tables[0].Rows[0]["COIPENDINGTOTAL"].ToString();

                            lblSPWith.Text = dss.Tables[0].Rows[0]["PSCPENDINGWITHIN"].ToString();
                            lblSPBeyond.Text = dss.Tables[0].Rows[0]["PSCPENDINGBEYOND"].ToString();
                            lblSCPTotal.Text = dss.Tables[0].Rows[0]["PSCPENDINGTOTAL"].ToString();
                            lblAD.Text = dss.Tables[0].Rows[0]["TOTALAPPLRETURNEDFROMJD"].ToString();

                            lblSendtoJd.Text = dss.Tables[0].Rows[0]["TOTALAPPLFORWARDEDTOJD"].ToString();

                            lblQueryRespond.Text = dss.Tables[0].Rows[0]["QUERIESRAISEDBYJD"].ToString();
                            lblRepliedQueryWITHIN.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDEDWITHIN"].ToString();
                            lblRepliedQueryBEYOND.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDEDBEYOND"].ToString();
                            lblTotalQueryRespond.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDED"].ToString();
                            lblAutoRejected.Text = dss.Tables[0].Rows[0]["TOTALAUTOREJECTED"].ToString();


                            lblQRSCPW.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDED_PENDINGWITHIN"].ToString();
                            lblQRSPB.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDED_PENDINGBEYOND"].ToString();
                            lblQRSCPTotal.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDED_PENDINGTOTAL"].ToString();
                            lblQRSPDD.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDED_RETURNEDFROMJD"].ToString();

                            lblWQRReturnDD.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDED_FORWARDEDTOJD"].ToString();
                            

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetDdDashboard(string UserID)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
                };
            pp[0].Value = UserID;

            Dsnew = caf.GenericFillDs("SP_DDDASHBOARD", pp);
            return Dsnew;
        }
    }
}