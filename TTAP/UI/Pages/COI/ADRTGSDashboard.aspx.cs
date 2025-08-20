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
    public partial class ADRTGSDashboard : System.Web.UI.Page
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
                        GetClerkDashboard();
                    }
                   
                }
            }
            catch (Exception ex)

            {

                throw ex;
            }



        }
        public void GetClerkDashboard()
        {
            string userid = Session["uid"].ToString();           
           
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
                };
            pp[0].Value = userid;

            dss = caf.GenericFillDs("USP_ADRTGSDASHBOARD", pp);
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                 
                lblSLC_Approved.Text = dss.Tables[0].Rows[0]["SLC_Approved"].ToString();
                lblSLC_ReleaseProcCompleted.Text = dss.Tables[0].Rows[0]["SLC_ReleaseProcCompleted"].ToString();
                lblSLC_UCUpdated.Text = dss.Tables[0].Rows[0]["SLC_UCUpdated"].ToString();
                lblSLC_UCNotUpdated.Text = dss.Tables[0].Rows[0]["SLC_UCNotUpdated"].ToString();
                lblSLC_ToGenerateCheque.Text = dss.Tables[0].Rows[0]["SLC_ToGenerateCheque"].ToString();
                lblSLC_GeneratedCheque.Text = dss.Tables[0].Rows[0]["SLC_GeneratedCheque"].ToString();
                lblSLC_ChequeNotUploaded.Text = dss.Tables[0].Rows[0]["SLC_ChequeNotUploaded"].ToString();
                lblSLC_Cheque_withNo.Text = dss.Tables[0].Rows[0]["SLC_Cheque_withNo"].ToString();
                lblSLC_Cheque_withUTR.Text = dss.Tables[0].Rows[0]["SLC_Cheque_withUTR"].ToString();

                lblDIPC_Approved.Text = dss.Tables[0].Rows[0]["DIPC_Approved"].ToString();
                lblDIPC_ReleaseProcCompleted.Text = dss.Tables[0].Rows[0]["DIPC_ReleaseProcCompleted"].ToString();
                lblDIPC_UCUpdated.Text = dss.Tables[0].Rows[0]["DIPC_UCUpdated"].ToString();
                lblDIPC_UCNotUpdated.Text = dss.Tables[0].Rows[0]["DIPC_UCNotUpdated"].ToString();
                lblDIPC_ToGenerateCheque.Text = dss.Tables[0].Rows[0]["DIPC_ToGenerateCheque"].ToString();
                lblDIPC_GeneratedCheque.Text = dss.Tables[0].Rows[0]["DIPC_GeneratedCheque"].ToString();
                lblDIPC_ChequeNotUploaded.Text = dss.Tables[0].Rows[0]["DIPC_ChequeNotUploaded"].ToString();
                lblDIPC_Cheque_withNo.Text = dss.Tables[0].Rows[0]["DIPC_Cheque_withNo"].ToString();
                lblDIPC_Cheque_withUTR.Text = dss.Tables[0].Rows[0]["DIPC_Cheque_withUTR"].ToString();

            }


        }
    }
}