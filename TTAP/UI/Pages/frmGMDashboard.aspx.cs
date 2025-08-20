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
    public partial class frmGMDashboard : System.Web.UI.Page
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
                        dss = GetGMDashboard(DistId.ToString());
                        if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                        {
                            lblAppl.Text = dss.Tables[0].Rows[0]["NoofapplicationsRcvd"].ToString();
                            lblYetotoAssignWithin.Text = dss.Tables[0].Rows[0]["YetToAssignWithIn"].ToString();
                            lblYetotoAssignBeyond.Text = dss.Tables[0].Rows[0]["YetToAssignBeyond"].ToString();
                            lblYetotoAssignTotal.Text = dss.Tables[0].Rows[0]["YetToAssignTotal"].ToString();

                            lblGMQueryWithIn.Text = dss.Tables[0].Rows[0]["GMQueryRaisedBeforeAssignWitnin"].ToString();
                            lblGMQueryBeyond.Text = dss.Tables[0].Rows[0]["GMQueryRaisedBeforeAssignBeyond"].ToString();
                            lblGMQueryTotal.Text = dss.Tables[0].Rows[0]["GMQueryRaisedBeforeAssignTotal"].ToString();
                            lblRepliedtoGMQuery.Text = dss.Tables[0].Rows[0]["GMQueryResponded"].ToString();
                            lblNotRepliedtoGMQuery.Text = dss.Tables[0].Rows[0]["GMAwaitingResponse"].ToString();
                            //-----------------------------------------------------------------------------------------//
                            lblAssignedWithIn.Text = dss.Tables[0].Rows[0]["AssignedWithIn"].ToString();
                            lblAssignedBeyond.Text = dss.Tables[0].Rows[0]["AssignedBeyond"].ToString();
                            lblAssignedTotal.Text = dss.Tables[0].Rows[0]["AssignedTotal"].ToString();

                            lblAutoRejectedatGM.Text = dss.Tables[0].Rows[0]["AutoRejected_GMQueryBased"].ToString();
                            lblRejectedByGM.Text = dss.Tables[0].Rows[0]["GMRejectedBeforeAssign"].ToString();
                            lblTotalRejectedatGM.Text = dss.Tables[0].Rows[0]["TotalRejectedatGM"].ToString();
                            //-----------------------------------------------------------------------------------------//
                            lblIPOQueries.Text = dss.Tables[0].Rows[0]["IPOQueriesRaised"].ToString();
                            lblIPOQueryFwdtoApp.Text = dss.Tables[0].Rows[0]["IPOQueryForwardtoApplicant"].ToString();
                            lblAppResptoIPOQry.Text = dss.Tables[0].Rows[0]["ApplicantResponsetoIPOQuery"].ToString();
                            lblGMYettoFwdtoApplicantIQ.Text = dss.Tables[0].Rows[0]["IPOQueryGMYetToForwardToApplicant"].ToString();
                            lblGMYettoRespondtoAppResp.Text = dss.Tables[0].Rows[0]["AplicntRspdIPOQueryGMYetToRespond"].ToString();

                            lblCOIQueriesTotalRaised.Text = dss.Tables[0].Rows[0]["COIQueriesTotalRaised"].ToString();
                            lblCOIQueriesYettoRespondByApplicant.Text = dss.Tables[0].Rows[0]["COIQueriesYettoRespondByApplicant"].ToString();
                            lblCOIQueriesYettoRespondByGM.Text = dss.Tables[0].Rows[0]["COIQueriesYettoRespondByGM"].ToString();
                            lblCOIQueriesRespondedByGM.Text = dss.Tables[0].Rows[0]["COIQueriesRespondedByGM"].ToString();
                            lblCOIQueries_QueryRaisedbyGM.Text = dss.Tables[0].Rows[0]["COIQueries_QueryRaisedbyGM"].ToString();
                            lblSSCInsp_GMyettoForward.Text = dss.Tables[0].Rows[0]["SSCInsp_GMyettoForward"].ToString();
                            //-----------------------------------------------------------------------------------------//
                            lblPendingDIPCWithin.Text = dss.Tables[0].Rows[0]["PendingtoDIPCWithin"].ToString();
                            lblPendingDIPCBeyond.Text = dss.Tables[0].Rows[0]["PendingtoDIPCBeyond"].ToString();
                            lblPendingDIPCTotal.Text = dss.Tables[0].Rows[0]["PendingtoDIPCTotal"].ToString();
                            //--------------------------------------------------------------------------------------//

                            lblAfterWithin.Text = dss.Tables[0].Rows[0]["GMQueryRaisedAfterInspWithin"].ToString();
                            lblAfterBeyond.Text = dss.Tables[0].Rows[0]["GMQueryRaisedAfterInspBeyond"].ToString();
                            lblAfterTotal.Text = dss.Tables[0].Rows[0]["GMQueryRaisedAfterInspTotal"].ToString();
                            lblReInspectionCompleted.Text = dss.Tables[0].Rows[0]["GMQueryRespondByApplicant"].ToString();
                            lblAwaitingResp.Text = dss.Tables[0].Rows[0]["GMQueryYettoRespondByApplicant"].ToString();
                            //-----------------------------------------------------------------------------------//
                            lblCOIWithin.Text = dss.Tables[0].Rows[0]["SenttoCOIWithin"].ToString();
                            lblCOIBeyond.Text = dss.Tables[0].Rows[0]["SenttoCOIBeyond"].ToString();
                            lblCOITotal.Text = dss.Tables[0].Rows[0]["SenttoCOITotal"].ToString();
                            lblGMRejectedAfterInsp.Text = dss.Tables[0].Rows[0]["GMRejectedAfterInsp"].ToString();
                            //----------------------------------------------------------------------------------//

                            lblWithinDIPC.Text = dss.Tables[0].Rows[0]["SenttoDIPCWithin"].ToString();
                            lblBeyondDIPC.Text = dss.Tables[0].Rows[0]["SenttoDIPCBeyond"].ToString();
                            lblDIPCTotal.Text = dss.Tables[0].Rows[0]["SenttoDIPCTotal"].ToString();
                            //---------------------------------------------------------------------------------//

                            lblRejectedJD.Text = dss.Tables[0].Rows[0]["COIRejectedJD"].ToString();
                            lblRejectAD.Text = dss.Tables[0].Rows[0]["COIRejectedADDL"].ToString();
                            lblRejectSVC.Text = dss.Tables[0].Rows[0]["COIRejectedSVC"].ToString();
                            lblRejectSLC.Text = dss.Tables[0].Rows[0]["COIRejectedSLC"].ToString();
                            lblAbeyancedJDLevel.Text = dss.Tables[0].Rows[0]["COIAbeyancedJD"].ToString();
                            lblAbeyancedAD.Text = dss.Tables[0].Rows[0]["COIAbeyancedADDL"].ToString();
                            lblAnctionedwithin.Text = dss.Tables[0].Rows[0]["SanctionedWithin"].ToString();
                            lblSanctionedBeyond.Text = dss.Tables[0].Rows[0]["SanctionedBeyond"].ToString();
                            lblTotalSanctionedINC.Text = dss.Tables[0].Rows[0]["SanctionedTotal"].ToString();
                            lblReleWithin.Text = dss.Tables[0].Rows[0]["Releasedwithin"].ToString();
                            lblReleBeyond.Text = dss.Tables[0].Rows[0]["ReleasedBeyond"].ToString();
                            lblTotalReleINC.Text = dss.Tables[0].Rows[0]["ReleasedTotal"].ToString();

                            lblReleaseSLC.Text = dss.Tables[0].Rows[0]["SLCWorkingStatus"].ToString();
                            lblReleaseDIPC.Text = dss.Tables[0].Rows[0]["DIPCWorkingStatus"].ToString();


                            lblWorkingStatusSLC.Text = dss.Tables[0].Rows[0]["PrintSLCWorkingStatus"].ToString();
                            lblCloseStatusSLC.Text = dss.Tables[0].Rows[0]["PrintSLCCloseWorkingStatus"].ToString();
                            lblAbencyStatusSLC.Text = dss.Tables[0].Rows[0]["PrintSLCAbencyWorkingStatus"].ToString();
                            lblWorkingStatusDIPC.Text = dss.Tables[0].Rows[0]["PrintDIPCWorkingStatus"].ToString();
                            lblCloseStatusDIPC.Text = dss.Tables[0].Rows[0]["PrintDIPCCloseWorkingStatus"].ToString();
                            lblAbencyStatusDIPC.Text = dss.Tables[0].Rows[0]["PrintDIPCAbencyWorkingStatus"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetGMDashboard(string userid)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DistId",SqlDbType.VarChar),
           };
            pp[0].Value = userid;
            Dsnew = caf.GenericFillDs("USP_GET_GM_DASHBOARD_DTLS", pp);
            return Dsnew;
        }
    }
}