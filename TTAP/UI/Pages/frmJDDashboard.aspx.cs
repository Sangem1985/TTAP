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
    public partial class frmJDDashboard : System.Web.UI.Page
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

                        DistId = Convert.ToInt32(Session["DistrictId"].ToString());
                        dss = GetJDDashboard(userid.ToString());
                        if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
                        {
                            lblAppl.Text = dss.Tables[0].Rows[0]["NoofapplicationsRcvd"].ToString();
                            //lblPendingWithin.Text = dss.Tables[0].Rows[0]["PendingWithin"].ToString();
                            //lblPendingBeyond.Text = dss.Tables[0].Rows[0]["PendingBeyond"].ToString();
                            //lblpendingTotal.Text = dss.Tables[0].Rows[0]["PendingTotal"].ToString();

                            lblPendingWithin.Text = dss.Tables[0].Rows[0]["ADDLPendingWithin"].ToString();
                            lblPendingBeyond.Text = dss.Tables[0].Rows[0]["ADDLPendingBeyond"].ToString();
                            lblpendingTotal.Text = dss.Tables[0].Rows[0]["ADDLPendingTotal"].ToString();

                            lblcomWithin.Text = dss.Tables[0].Rows[0]["CompletdWithin"].ToString();
                            lblcombeyond.Text = dss.Tables[0].Rows[0]["CompletdBeyond"].ToString();
                            lblDLrejected.Text = dss.Tables[0].Rows[0]["CompletdRejected"].ToString();


                            lblTotalQuery.Text = dss.Tables[0].Rows[0]["QueryRaised"].ToString();
                            lblOpenQuery.Text = dss.Tables[0].Rows[0]["QueryAwaiting"].ToString();
                            lblRepliedQueryWITHIN.Text = dss.Tables[0].Rows[0]["QueryResponseWithin"].ToString();
                            lblRepliedQueryBEYOND.Text = dss.Tables[0].Rows[0]["QueryResponsebeyond"].ToString();
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
                            lblIssuedSanctionLetters.Text = dss.Tables[0].Rows[0]["SanctionedLettersIssued"].ToString();
                            lblPendingIssueSanctions.Text = dss.Tables[0].Rows[0]["SanctionedLettersPending"].ToString();
                            
                        }
                    }
                }
            }
            catch (Exception ex)

            {

                throw ex;
            }
        }

        public DataSet GetJDDashboard(string UserID)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
           };
            pp[0].Value = UserID;

            //Dsnew = caf.GenericFillDs("getDLODashboard", pp);
            Dsnew = caf.GenericFillDs("USP_GET_JD_DASHBOARD_DTLS", pp);
            return Dsnew;
        }

        public DataSet GetDLODLCDashboard(int UserID)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.Int),
           };
            pp[0].Value = UserID;

            //Dsnew = caf.GenericFillDs("getDLODashboard", pp);
            Dsnew = caf.GenericFillDs("USP_GET_SVC_SLC_DASHBOARD", pp);
            return Dsnew;
        }
    }
}