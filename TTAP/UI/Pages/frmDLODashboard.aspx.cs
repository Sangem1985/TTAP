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
    public partial class frmDLODashboard : System.Web.UI.Page
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
                        dss = GetDLODashboard(DistId);
                        if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                        {
                            //string TotalApp = dss.Tables[0].Rows[0]["totalApp"].ToString();
                            //string YettoProcess = dss.Tables[1].Rows[0]["YettoProcess"].ToString();
                            //string OpenQuery= dss.Tables[2].Rows[0]["QueryRaised"].ToString();
                            //string ClosedQuery = dss.Tables[3].Rows[0]["QueryReplied"].ToString();
                            //lblAppl.Text = TotalApp;
                            //lblPendingWithin.Text = YettoProcess;
                            //lblOpenQuery.Text = OpenQuery;
                            //lblRepliedQuery.Text = ClosedQuery;

                            lblAppl.Text = dss.Tables[0].Rows[0]["NoofapplicationsRcvd"].ToString();
                            lblPendingWithin.Text = dss.Tables[0].Rows[0]["DLOPendingWithin"].ToString();
                            lblPendingBeyond.Text = dss.Tables[0].Rows[0]["DLOPendingBeyond"].ToString();
                            lblpendingTotal.Text = dss.Tables[0].Rows[0]["DLOPendingTotal"].ToString();

                            lblcomWithin.Text = dss.Tables[0].Rows[0]["DLOCompletdWithin"].ToString();
                            lblcombeyond.Text = dss.Tables[0].Rows[0]["DLOCompletdBeyond"].ToString();
                            lblDLrejected.Text = dss.Tables[0].Rows[0]["DLOCompletdRejected"].ToString();


                            lblTotalQuery.Text = dss.Tables[0].Rows[0]["DLOQueryRaised"].ToString();
                            lblOpenQuery.Text = dss.Tables[0].Rows[0]["DLOQueryAwaiting"].ToString();
                            lblRepliedQueryWITHIN.Text = dss.Tables[0].Rows[0]["QueryResponseWithin"].ToString();
                            lblRepliedQueryBEYOND.Text = dss.Tables[0].Rows[0]["QueryResponsebeyond"].ToString();

                            lblInspectionPendingWithin.Text = dss.Tables[0].Rows[0]["InspectionPendingWithin"].ToString();
                            lblInspectionPendingBeyond.Text = dss.Tables[0].Rows[0]["InspectionPendingBeyond"].ToString();
                            lblInspectionPendingTotal.Text = dss.Tables[0].Rows[0]["InspectionPendingTotal"].ToString();

                            lblInspectionCompletedWithin.Text = dss.Tables[0].Rows[0]["InspectionCompletedWithin"].ToString();
                            lblInspectionCompletedBeyond.Text = dss.Tables[0].Rows[0]["InspectionCompletedBeyond"].ToString();
                            lblInspectionCompletedTotal.Text = dss.Tables[0].Rows[0]["InspectionCompletedTotal"].ToString();

                            lblReInspectionPending.Text = dss.Tables[0].Rows[0]["ReInspectionPending"].ToString();
                            lblReInspectionCompleted.Text = dss.Tables[0].Rows[0]["ReInspectionCompleted"].ToString();

                            lblpendingtoberefferdW.Text = dss.Tables[0].Rows[0]["PendingToSendDLCSLCWithin"].ToString();
                            lblpendingtoberefferdB.Text = dss.Tables[0].Rows[0]["PendingToSendDLCSLCBeyond"].ToString();
                            lblpendingtoreffer.Text = dss.Tables[0].Rows[0]["PendingToSendDLCSLCTotal"].ToString();

                            lblcompletedtoberefferdW.Text = dss.Tables[0].Rows[0]["CompletedToSendDLCSLCWithin"].ToString();
                            lblcompletedtoberefferdB.Text = dss.Tables[0].Rows[0]["CompletedToSendDLCSLCBeyond"].ToString();
                            lblrejectedafterinsp.Text = dss.Tables[0].Rows[0]["RejectedToSendDLCSLC"].ToString();
                            lblCompletedtoreffer.Text = dss.Tables[0].Rows[0]["CompletedToSendDLCSLCTotal"].ToString();

                            lblTotalQueryafterInspection.Text = dss.Tables[0].Rows[0]["DLOQueryRaisedAfterInspection"].ToString();
                            lblOpenQueryafterInspection.Text = dss.Tables[0].Rows[0]["DLOQueryAwaitingAfterInspection"].ToString();
                            lblRepliedQueryWITHINafterInspection.Text = dss.Tables[0].Rows[0]["QueryResponseWithinAfterInspection"].ToString();
                            lblRepliedQueryBEYONDafterInspection.Text = dss.Tables[0].Rows[0]["QueryResponsebeyondAfterInspection"].ToString();
                            if (Convert.ToInt32(dss.Tables[0].Rows[0]["PendingApplicationsWitnin"].ToString()) > 0)
                            {
                                lblnewApps.InnerHtml = dss.Tables[0].Rows[0]["PendingApplicationsWitnin"].ToString() + " " + "new Application(s) received.";
                                lblnewApps.Visible = true;
                            }
                            if (Session["Role_code"].ToString() == "IND")
                            {
                                lblInspectionPendingTotal.Text = dss.Tables[0].Rows[0]["InspectionPendingWithinInd"].ToString();
                                lblInspectionCompletedTotal.Text = dss.Tables[0].Rows[0]["InspectionCompletedInd"].ToString();
                                AncTotalInsPending.HRef = "frmDLOApplications.aspx?Stg=32";
                                AnctotalInsCompleted.HRef = "frmDLOApplications.aspx?Stg=33";
                                lblnewApps.Visible = false;
                            }
                        }

                        dss = new DataSet();
                        dss = GetDLODLCDashboard(DistId);
                        if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                        {
                            lblDLCReceived.Text = dss.Tables[0].Rows[0]["TotalApplicationsRcvdToDLC"].ToString();
                            lblDIPCAgendaWithin.Text = dss.Tables[0].Rows[0]["YetTogenerateAgendaWithin"].ToString();
                            lblDIPCAgendaBeyond.Text = dss.Tables[0].Rows[0]["YetTogenerateAgendaBeyond"].ToString();
                            lblTotalYettogenerateAgenda.Text = dss.Tables[0].Rows[0]["YetTogenerateAgendaTotal"].ToString();

                            lblDIPCUploadProcWithin.Text = dss.Tables[0].Rows[0]["YetToUpdateAgendaWithin"].ToString();
                            lblDIPCUploadProcBeyond.Text = dss.Tables[0].Rows[0]["YetToUpdateAgendaBeyond"].ToString();
                            lblDIPCUploadProc.Text = dss.Tables[0].Rows[0]["YetToUpdateAgendaTotal"].ToString();

                            lblDIPCReleasePendingsWithin.Text = dss.Tables[0].Rows[0]["CompletedAgendaWithin"].ToString();
                            lblDIPCReleasePendingsBeyond.Text = dss.Tables[0].Rows[0]["CompletedAgendaBeyond"].ToString();
                            DLCrejected.Text = dss.Tables[0].Rows[0]["RejectedAgenda"].ToString();
                            lblDLCCompleted.Text = dss.Tables[0].Rows[0]["CompletedAgendaTotal"].ToString();

                            //---------------------------------SVC DASHBAORD -----------------------------------------------

                            lblSVCReceived.Text = dss.Tables[0].Rows[0]["SVCTotalApplicationsRcvdToDLC"].ToString();
                            lblSVCAgendaWithin.Text = dss.Tables[0].Rows[0]["SVCYetTogenerateAgendaWithin"].ToString();
                            lblSVCAgendaBeyond.Text = dss.Tables[0].Rows[0]["SVCYetTogenerateAgendaBeyond"].ToString();
                            lblSVCTotalYettogenerateAgenda.Text = dss.Tables[0].Rows[0]["SVCYetTogenerateAgendaTotal"].ToString();

                            lblSVCUploadProcWithin.Text = dss.Tables[0].Rows[0]["SVCYetToUpdateAgendaWithin"].ToString();
                            lblSVCUploadProcBeyond.Text = dss.Tables[0].Rows[0]["SVCYetToUpdateAgendaBeyond"].ToString();
                            lblSVCUploadProc.Text = dss.Tables[0].Rows[0]["SVCYetToUpdateAgendaTotal"].ToString();

                            lblSVCReleasePendingsWithin.Text = dss.Tables[0].Rows[0]["SVCCompletedAgendaWithin"].ToString();
                            lblSVCReleasePendingsBeyond.Text = dss.Tables[0].Rows[0]["SVCCompletedAgendaBeyond"].ToString();
                            lblSVCrejected.Text = dss.Tables[0].Rows[0]["SVCRejectedAgenda"].ToString();
                            lblSVCCompleted.Text = dss.Tables[0].Rows[0]["SVCCompletedAgendaTotal"].ToString();
                        }
                        if (Session["Role_code"].ToString() == "IND")
                        {
                            trsection6.Visible = false;
                            Div1.Visible = false;
                            Div2.Visible = false;
                            Div3.Visible = false;
                            AncWithInInsPending.Visible = false;
                            AncBeyondInsPending.Visible = false;
                            AncWithInInsCompleted.Visible = false;
                            AncBeyondInsCompleted.Visible = false;
                            TableSVC.Visible = false;
                            Table2.Visible = false;
                            trsection1.Visible = false;
                            divline1.Visible = false;
                            divline2.Visible = false;
                            divline3.Visible = false;
                            divline4.Visible = false;
                            divline5.Visible = false;
                            Headerdic.InnerText = "DIC Dashboard";
                            lidashboard.InnerText= "DIC Dashboard";
                        }
                    }
                }
            }
            catch (Exception ex)

            {

                throw ex;
            }

        }
        public int GetDistrictIdofDLO(string UserId)
        {
            DataSet Dsnew = new DataSet();
            int distid = 0;
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UserId",SqlDbType.NVarChar),
           };
            pp[0].Value = UserId;

            Dsnew = caf.GenericFillDs("getDistrictIdbyUserId", pp);
            if (Dsnew.Tables.Count > 0)
            {
                if (Dsnew.Tables[0].Rows.Count > 0)
                {
                    distid = Convert.ToInt32(Dsnew.Tables[0].Rows[0]["DistId"].ToString());
                }
            }
            return distid;
        }

        public DataSet GetDLODashboard(int DistId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DistId",SqlDbType.Int),
           };
            pp[0].Value = DistId;

            //Dsnew = caf.GenericFillDs("getDLODashboard", pp);
            Dsnew = caf.GenericFillDs("USP_GET_DLO_DASHBOARD_DTLS", pp);
            return Dsnew;
        }

        public DataSet GetDLODLCDashboard(int DistId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DistId",SqlDbType.Int),
           };
            pp[0].Value = DistId;

            //Dsnew = caf.GenericFillDs("getDLODashboard", pp);
            Dsnew = caf.GenericFillDs("USP_GET_DLO_DLC_DASHBOARD", pp);
            return Dsnew;
        }
    }
}