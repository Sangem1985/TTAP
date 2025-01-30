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
    public partial class AdDashboard : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {
                        string userid = Session["uid"].ToString();
                        ds = GetADDashboard(userid.ToString());
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {                            

                            lblGMTotal.Text = ds.Tables[0].Rows[0]["TOTALNOOFAPPLICATIONS"].ToString();
                            lblPendingWithin.Text = ds.Tables[0].Rows[0]["COIPENDINGWITHIN"].ToString();
                            lblPendingBeyond.Text = ds.Tables[0].Rows[0]["COIPENDINGBEYOND"].ToString();
                            lblSPTotal.Text = ds.Tables[0].Rows[0]["COIPENDINGTOTAL"].ToString();

                            lblWithin.Text = ds.Tables[0].Rows[0]["PSCPENDINGWITHIN"].ToString();
                            lblBeyond.Text = ds.Tables[0].Rows[0]["PSCPENDINGBEYOND"].ToString();
                            lblTotal.Text = ds.Tables[0].Rows[0]["PSCPENDINGTOTAL"].ToString();
                            lblDDReturn.Text = ds.Tables[0].Rows[0]["TOTALAPPLRETURNEDFROMDD"].ToString();
                            lblForwardDD.Text = ds.Tables[0].Rows[0]["TOTALAPPLFORWARDEDTODD"].ToString();

                            lblTotalQuery.Text = ds.Tables[0].Rows[0]["QUERIESRAISEDBYJD"].ToString();
                            lblRepliedQueryWITHIN.Text = ds.Tables[0].Rows[0]["QUERIESRESPNDEDWITHIN"].ToString();
                            lblRepliedQueryBEYOND.Text = ds.Tables[0].Rows[0]["QUERIESRESPNDEDBEYOND"].ToString();
                            lblQueryResponded.Text = ds.Tables[0].Rows[0]["QUERIESRESPNDED"].ToString();
                            lblttlautorejected.Text = ds.Tables[0].Rows[0]["TOTALAUTOREJECTED"].ToString();

                            lblQRSCPW.Text = ds.Tables[0].Rows[0]["QUERIESRESPNDED_PENDINGWITHIN"].ToString();
                            lblQRSPB.Text = ds.Tables[0].Rows[0]["QUERIESRESPNDED_PENDINGBEYOND"].ToString();
                            lblQRSCPTotal.Text = ds.Tables[0].Rows[0]["QUERIESRESPNDED_PENDINGTOTAL"].ToString();
                            lblQRSPDD.Text = ds.Tables[0].Rows[0]["QUERIESRESPNDED_RETURNEDFROMDD"].ToString();
                            lblWQRReturnDD.Text = ds.Tables[0].Rows[0]["QUERIESRESPNDED_FORWARDEDTODD"].ToString();
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetADDashboard(string UserID)
        {
            try
            {
                DataSet Ds = new DataSet();
                SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
                };
                pp[0].Value = UserID;

                //Dsnew = caf.GenericFillDs("getDLODashboard", pp);
                Ds = caf.GenericFillDs("SP_ADDASHBOARD", pp);
                return Ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}