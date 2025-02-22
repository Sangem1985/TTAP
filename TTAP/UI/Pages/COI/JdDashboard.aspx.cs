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
    public partial class JdDashboard : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
                    ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    if (ObjLoginvo.userlevel == "1")
                    {
                        if (ObjLoginvo.Role_Code == "ADDL")
                        {
                            divdashboardheadername.InnerHtml = "Additional Director Dashboard";
                        }
                        else if (ObjLoginvo.Role_Code == "JD")
                        {
                            divdashboardheadername.InnerHtml = "Joint Director Dashboard";
                        }
                    }
                    if (Session["uid"] != null)
                    {
                        string userid = Session["uid"].ToString();
                        AssignDashBoardCounts(userid);
                    }
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
        public void AssignDashBoardCounts(string userid)
        {
            dss = GetJDDashboard(userid.ToString());
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                lblAppsRcvdFrmGM.Text = dss.Tables[0].Rows[0]["NoofapplicationsRcvdGM"].ToString();
                lblScrntyPendingWithin.Text = dss.Tables[0].Rows[0]["ScrutinyPendingWithin"].ToString();
                lblScrntyPendingBeyond.Text = dss.Tables[0].Rows[0]["ScrutinyPendingBeyond"].ToString();
                lblScrntypendingTotal.Text = (Convert.ToInt32(dss.Tables[0].Rows[0]["ScrutinyPendingWithin"].ToString()) + Convert.ToInt32(dss.Tables[0].Rows[0]["ScrutinyPendingBeyond"].ToString())).ToString();

                lblFwdFrmADDDWithin.Text = dss.Tables[0].Rows[0]["FwdFromAD_DDWithin"].ToString();
                lblFwdFrmADDDbeyond.Text = dss.Tables[0].Rows[0]["FwdFromAD_DDBeyond"].ToString();
                lblTotalFwdFrmADDD.Text = (Convert.ToInt32(dss.Tables[0].Rows[0]["FwdFromAD_DDWithin"].ToString()) + Convert.ToInt32(dss.Tables[0].Rows[0]["FwdFromAD_DDBeyond"].ToString())).ToString();
                lblDeptRtrndAppsSVC.Text = dss.Tables[0].Rows[0]["DeptRtrndAppsSVC"].ToString();
                lblDeptPrcsdAppsSVC.Text = dss.Tables[0].Rows[0]["DeptProcessedSVC"].ToString();
                lblADDLReturned.Text = dss.Tables[0].Rows[0]["AddlReturned"].ToString();

                lblScrtnyCompFwdtoAddlWithin.Text = dss.Tables[0].Rows[0]["FwdtoAddlWithin"].ToString();
                lblScrtnyCompFwdtoAddlBeyond.Text = dss.Tables[0].Rows[0]["FwdtoAddlBeyond"].ToString();
                lblTotScrtnyCompFwdtoAddl.Text = (Convert.ToInt32(dss.Tables[0].Rows[0]["FwdtoAddlWithin"].ToString()) + Convert.ToInt32(dss.Tables[0].Rows[0]["FwdtoAddlBeyond"].ToString())).ToString();
                lblRejected.Text = dss.Tables[0].Rows[0]["JDRejected"].ToString();

                lblQueryYettoRspnd.Text = dss.Tables[0].Rows[0]["QueriesYettoRespond"].ToString();
                lblRepliedQueryWITHIN.Text = dss.Tables[0].Rows[0]["QueriesRespondedWithin"].ToString();
                lblRepliedQueryBEYOND.Text = dss.Tables[0].Rows[0]["QueriesRespondedBeyond"].ToString();
                lblTotalQueryRspnd.Text = (Convert.ToInt32(dss.Tables[0].Rows[0]["QueriesRespondedWithin"].ToString()) + Convert.ToInt32(dss.Tables[0].Rows[0]["QueriesRespondedBeyond"].ToString())).ToString();
                lblQueriesRespWithin.Text = dss.Tables[0].Rows[0]["DQueriesRespondedWithin"].ToString();
                lblQueriesRespBeyond.Text = dss.Tables[0].Rows[0]["DQueriesRespondedBeyond"].ToString();
                lblTotalQueriesRspndd.Text = (Convert.ToInt32(dss.Tables[0].Rows[0]["DQueriesRespondedWithin"].ToString()) + Convert.ToInt32(dss.Tables[0].Rows[0]["DQueriesRespondedBeyond"].ToString())).ToString();

                lblAbeyance.Text = dss.Tables[0].Rows[0]["AbeyancedAtSPDNT"].ToString();
                lblTotalAbeyance.Text = dss.Tables[0].Rows[0]["AbeyancedAtAddl"].ToString();
                lblRjctedpreSVC.Text = dss.Tables[0].Rows[0]["RejectedAtPreSVC"].ToString();
                lblRjctedSVC.Text = dss.Tables[0].Rows[0]["RejectedAtSVC"].ToString();
                lblRjctdSLC.Text = dss.Tables[0].Rows[0]["RejectedAtSLC"].ToString();
                lblQrsNotRespbyGM.Text = dss.Tables[0].Rows[0]["QueriesNotRspndByGM"].ToString();
                lblQrsRespbyGM.Text = dss.Tables[0].Rows[0]["QueriesRspndByGM"].ToString();
                lblTotalQrsRespbyJD.Text = dss.Tables[0].Rows[0]["QueriesRespondedByJD"].ToString();
                lblQrsRasiedbyADD.Text = dss.Tables[0].Rows[0]["QueriesRaisedByAddl"].ToString();
                lblApprovedSLC.Text = dss.Tables[0].Rows[0]["ApprovedBySLC"].ToString();
                lblSLCRlsProceed.Text = dss.Tables[0].Rows[0]["SLCReleaseProceedings"].ToString();
                lblWrkStatusbyGM.Text = dss.Tables[0].Rows[0]["WorkingStatusUpdatedByGM"].ToString();
                lblWrkStatusNotbyGM.Text = dss.Tables[0].Rows[0]["WorkingStatusNotUpdatedByGM"].ToString();
                lblApprovedDIPC.Text = dss.Tables[0].Rows[0]["ApprovedByDIPC"].ToString();
                lblDIPCRlsProceed.Text = dss.Tables[0].Rows[0]["DIPCReleaseProceedings"].ToString();
                lblWrkStatusbyGMDIPC.Text = dss.Tables[0].Rows[0]["WorkingStatusUpdatedByGMDIPC"].ToString();
                lblWrkStatusNotbyGMDIPC.Text = dss.Tables[0].Rows[0]["WorkingStatusNotUpdatedByGMDIPC"].ToString();
                lblPndngGenCheque.Text = dss.Tables[0].Rows[0]["PendingGeneratingCheque"].ToString();
                lblGenCheque.Text = dss.Tables[0].Rows[0]["GeneratedCheque"].ToString();
                lblUploadChequeSLC.Text = dss.Tables[0].Rows[0]["UploadChequeSLC"].ToString();
                lblChequeClearence.Text = dss.Tables[0].Rows[0]["UploadChequeClearanceSLC"].ToString();
                lblNotUplodedCheques.Text = dss.Tables[0].Rows[0]["ChequeNotUploaded"].ToString();
                lblChequeNumber.Text = dss.Tables[0].Rows[0]["ChequeNumberDtls"].ToString();
                lblChequeUTR.Text = dss.Tables[0].Rows[0]["ChequeWithUTR"].ToString();
                lblPndngGenChequeDIPC.Text = dss.Tables[0].Rows[0]["PendingGeneratingChequeDIPC"].ToString();
                lblGenChequeDIPC.Text = dss.Tables[0].Rows[0]["GeneratedChequeDIPC"].ToString();
                lblUploadChequeDIPC.Text = dss.Tables[0].Rows[0]["UploadChequeDIPC"].ToString();
                lblChequeClearenceDIPC.Text = dss.Tables[0].Rows[0]["UploadChequeClearanceDIPC"].ToString();
                lblUTRWithCheque.Text = dss.Tables[0].Rows[0]["EnterUTRWithChequeNo"].ToString();
                lblChequeStatus.Text = dss.Tables[0].Rows[0]["ChequeStatus"].ToString();
            }
        }
        public DataSet GetJDDashboard(string UserID)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
           };
            pp[0].Value = UserID;
            Dsnew = caf.GenericFillDs("USP_GET_NEW_JD_DASHBOARD", pp);
            return Dsnew;
        }
    }
}