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

namespace TTAP.UI
{
    public partial class UserDashBoard : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();
        string CheckEligibility = "N";
        string IsFirstTime = "N";
        protected void Page_Load(object sender, EventArgs e)
        {
            int DistId = 0;
            if (Session["ObjLoginvo"] == null)
            {
                Response.Redirect("~/LoginReg.aspx");
            }
            if (!IsPostBack)
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();

                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                string rolecode = ObjLoginNewvo.Role_Code;
                string roletype = ObjLoginNewvo.Type;
                string UnitId = ObjLoginNewvo.uid;
                if (rolecode == "GM")
                {
                    Response.Redirect("Pages/frmGMDashboard.aspx");
                }
                if (rolecode == "IPO" || rolecode == "AD" || rolecode == "DD")
                {
                    Response.Redirect("Pages/frmIPOIncentiveDashboard.aspx");
                }
                if (rolecode == "DLO" || rolecode=="IND")
                {
                    Response.Redirect("Pages/frmDLODashboard.aspx");
                }
                if (roletype == "Enterprenuer")
                {
                    //IsFirstTime = caf.Check_Applicant_Eligibility(UnitId.ToString());
                    dss = GetReminders(UnitId.ToString());
                    int count = Convert.ToInt32(dss.Tables[0].Rows[0]["NewReminders"].ToString());
                    if (count > 0) {
                        NewReminders.InnerHtml = dss.Tables[0].Rows[0]["NewReminders"].ToString() + " " + "new Query Reminder(s) received(Click on Dashboard to View Reminders).";
                        divReminders.Visible = true;
                    }
                    CheckEligibility = caf.Check_Applicant_Eligibility(UnitId.ToString());
                    hdnEligibility.Value = CheckEligibility;
                    if (CheckEligibility == "N")
                    {
                        scrolltext.InnerHtml = "You are not eligible to apply Incentives";
                    }
                }
                
                if (roletype != "Enterprenuer")
                {
                    dss = GetRTGSPaymentVerification("58251");
                    int count = Convert.ToInt32(dss.Tables[0].Rows[0]["Pending"].ToString());
                    if (count > 0)
                    {   
                        if (count > 0)
                            pendingapps.InnerHtml = dss.Tables[0].Rows[0]["Pending"].ToString() + " " + "new Application(s) received.";
                        divpendingappspmnt.Visible = true;
                    }
                }
                if (rolecode == "COMM")
                {
                    divAdmin.Visible = false;
                    divHO.Visible = true;
                    dss = GetDLODashboardComm(DistId);
                    PDLOPending.InnerHtml = "No. of Incentives not acted upon within 7 days of receipt of application - " + dss.Tables[0].Rows[0]["DLOPendingWithin"].ToString();
                    PInspectionPending.InnerHtml = "No. of Incentives not acted upon within 7 days of Inspection Scheduled - " + dss.Tables[0].Rows[0]["InspectionPendingWithin"].ToString();
                    scrolltext.Visible = false;
                }
            }
        }
        public DataSet GetRTGSPaymentVerification(string UserID)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UserID",SqlDbType.VarChar),
           };
            pp[0].Value = UserID;

           
            Dsnew = caf.GenericFillDs("USP_GET_NEFTVERIFICATION_DASHBOARD_DTLS", pp);
            return Dsnew;
        }
        public DataSet GetReminders(string UnitId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UnitId",SqlDbType.VarChar),
           };
            pp[0].Value = UnitId;
            Dsnew = caf.GenericFillDs("USP_GET_QUERY_REMINDER_COUNT", pp);
            return Dsnew;
        }
        public DataSet GetDLODashboardComm(int DistId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DistId",SqlDbType.Int),
           };
            pp[0].Value = DistId;
            Dsnew = caf.GenericFillDs("USP_GET_DLO_DASHBOARD_DTLS_COMM", pp);
            return Dsnew;
        }
    }
}