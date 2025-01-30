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
    public partial class SuperintendentDashboard : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SUPDTBindData();
            }

        }
        public void SUPDTBindData()
        {
            try
            {

                if (Session["uid"] != null)
                {
                    string userid = Session["uid"].ToString();

                    dss = GetSUPDashboard(userid.ToString());
                    if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                    {                      

                        lblGMTotal.Text = dss.Tables[0].Rows[0]["TOTALNOOFAPPLICATIONS"].ToString();
                        lblPendingWithin.Text = dss.Tables[0].Rows[0]["COIPENDINGWITHIN"].ToString();
                        lblPendingBeyond.Text = dss.Tables[0].Rows[0]["COIPENDINGBEYOND"].ToString();
                        lblSPTotal.Text = dss.Tables[0].Rows[0]["COIPENDINGTOTAL"].ToString();

                        lblWithin.Text = dss.Tables[0].Rows[0]["PSCPENDINGWITHIN"].ToString();
                        lblBeyond.Text = dss.Tables[0].Rows[0]["PSCPENDINGBEYOND"].ToString();
                        lblTotal.Text = dss.Tables[0].Rows[0]["PSCPENDINGTOTAL"].ToString();
                        lblADReturn.Text = dss.Tables[0].Rows[0]["TOTALAPPLRETURNEDFROMAD"].ToString();

                        lblForwardAD.Text = dss.Tables[0].Rows[0]["TOTALAPPLFORWARDEDTOAD"].ToString();

                        lblTotalQuery.Text = dss.Tables[0].Rows[0]["QUERIESRAISEDBYJD"].ToString();
                        lblRepliedQueryWITHIN.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDEDWITHIN"].ToString();
                        lblRepliedQueryBEYOND.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDEDBEYOND"].ToString();
                        lblQueryResponded.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDED"].ToString();
                        lblttlautorejected.Text = dss.Tables[0].Rows[0]["TOTALAUTOREJECTED"].ToString();

                        lblQRSCPW.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDED_PENDINGWITHIN"].ToString();
                        lblQRSPB.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDED_PENDINGBEYOND"].ToString();
                        lblQRSPTotal.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDED_PENDINGTOTAL"].ToString();
                        lblWQRReturnAD.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDED_RETURNEDFROMAD"].ToString();

                        lblQRForwardAD.Text = dss.Tables[0].Rows[0]["QUERIESRESPNDED_FORWARDEDTOAD"].ToString();
                    }


                }

            }
            catch (Exception ex)

            {

                throw ex;
            }
        }

        public DataSet GetSUPDashboard(string UserID)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
                };
            pp[0].Value = UserID;

            Dsnew = caf.GenericFillDs("SP_SUPDTDASHBOARD", pp);
            return Dsnew;
        }
    }
}