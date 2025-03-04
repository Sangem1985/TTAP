using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using TTAP.Classfiles;

namespace TTAP.UI
{
    public partial class UserMaster : System.Web.UI.MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        //private string _antiXsrfTokenValue;
        protected string strSessionexp = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            ascaleUpgarde.ServerClick += new EventHandler(fnSetNewControls_Click);
            anchoetag.HRef = "";


            if (Session["ObjLoginvo"] == null)
            {
                fnSetNewControls_Click(this, EventArgs.Empty);
            }

            UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
            ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];


            if (!IsPostBack)
            {
                string guid = Guid.NewGuid().ToString("N");
                Session[AntiXsrfTokenKey] = guid;
                hdnUToken.Value = guid;
                if (Session["LoggedIn"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
                {
                    if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                    {
                        Killsession();
                    }
                    else
                    {
                        strSessionexp = (Session.Timeout * 60 * 1000).ToString();
                        Page.Header.DataBind();
                    }
                }
                else
                {
                    //  lblMessage.Text = "You are not logged in.";

                    // lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                if (Session[AntiXsrfTokenKey] != null && hdnUToken != null)
                {

                    if (!Session[AntiXsrfTokenKey].ToString().Equals(hdnUToken.Value))
                    {
                        //fnSetNewControls_Click(sender, e);
                        //throw new InvalidOperationException("Validation of  Anti-XSRF token failed.");
                    }
                }
            }

            //CheckMultiUsers(ObjLoginvo.uid);

            if (Session["uid"] == null)
            {
                fnSetNewControls_Click(sender, e);
            }
            if (Session["ObjLoginvo"] == null)
            {
                fnSetNewControls_Click(sender, e);
            }


            lblusername.Text = ObjLoginvo.FirstName != "" ? ObjLoginvo.FirstName : ObjLoginvo.user_id;
            if (!IsPostBack)
            {
                if (ObjLoginvo.userlevel == "1")
                {
                    if (ObjLoginvo.Role_Code == "ADDL")
                    {
                        anchoetag.HRef = "~/UI/Pages/frmDashBoard.aspx";

                        applicanthd.Visible = false;
                        liApplicantIncentivedashbiard.Visible = false;
                        liSvcEntry.Visible = true;
                        liIncentiveDeptDashboard.Visible = true;
                        anchdeptincdashboard.HRef = "~/UI/Pages/frmJDDashboard.aspx";
                        lichangepwd.Visible = true;
                        lireleases.Visible = true;
                        liIncentiveTracker.Visible = true;
                        liAppraisal.Visible = true;
                        lblClerk.Visible = false;
                        lblSUPDT.Visible = false;
                        lblAD.Visible = false;
                        lblDD.Visible = false;

                    }
                    else if (ObjLoginvo.Role_Code == "ADPP")
                    {
                        anchoetag.HRef = "~/UI/Pages/frmDashBoard.aspx";

                        applicanthd.Visible = false;
                        liApplicantIncentivedashbiard.Visible = false;

                        liIncentiveDeptDashboard.Visible = false;
                        //anchdeptincdashboard.HRef = "~/UI/frmAssistantDirectorPPdashboard.aspx";
                        lichangepwd.Visible = true;
                        liQueryGeneration.Visible = true;
                        liAdmin.Visible = true;
                        lblClerk.Visible = false;
                        lblSUPDT.Visible = false;
                        lblAD.Visible = false;
                        lblDD.Visible = false;
                    }
                    else if (ObjLoginvo.Role_Code == "IPOPP")
                    {
                        anchoetag.HRef = "~/UI/Pages/frmDashBoard.aspx";

                        applicanthd.Visible = false;
                        liApplicantIncentivedashbiard.Visible = false;

                        liIncentiveDeptDashboard.Visible = false;
                        //anchdeptincdashboard.HRef = "~/UI/frmAssistantDirectorPPdashboard.aspx";
                        lichangepwd.Visible = true;
                        liQueryGeneration.Visible = true;
                        liAdmin.Visible = true;
                        lblClerk.Visible = false;
                        lblSUPDT.Visible = false;
                        lblAD.Visible = false;
                        lblDD.Visible = false;
                    }
                    else if (ObjLoginvo.Role_Code == "JD")
                    {
                        anchoetag.HRef = "~/UI/Pages/frmDashBoard.aspx";

                        applicanthd.Visible = false;
                        liApplicantIncentivedashbiard.Visible = false;
                        liIncentiveDeptDashboard.Visible = true;
                        anchdeptincdashboard.HRef = "~/UI/Pages/COI/JdDashboard.aspx";
                        lichangepwd.Visible = true;
                        liQueryGeneration.Visible = true;
                        liSvcEntry.Visible = true;
                        liIncentiveTracker.Visible = true;
                        liAppraisal.Visible = true;
                        lblClerk.Visible = false;
                        lblSUPDT.Visible = false;
                        lblAD.Visible = false;
                        lblDD.Visible = false;

                    }
                    else if (ObjLoginvo.Role_Code == "COI-CLERK")
                    {                        
                        lblClerk.Visible = true;
                        lblclerkDashboard.HRef = "~/UI/Pages/COI/ClerkDashboard.aspx";
                        lblSUPDT.Visible = false;
                        lblAD.Visible = false;
                        lblDD.Visible = false;
                        liApplicationTracker.Visible = true;
                        LiTrackers.Visible = true;

                    }
                    else if (ObjLoginvo.Role_Code == "COI-SUPDT")
                    {
                        lblSUPDT.Visible = true;
                        lblSupdted.HRef = "~/UI/Pages/COI/SuperintendentDashboard.aspx";
                        lblClerk.Visible = false;
                        lblAD.Visible = false;
                        lblDD.Visible = false;
                        LiTrackers.Visible = true;

                    }
                    else if (ObjLoginvo.Role_Code == "COI-AD")
                    {
                        lblAD.Visible = true;
                        lblDashboard.HRef = "~/UI/Pages/COI/AdDashboard.aspx";
                        lblClerk.Visible = false;
                        lblSUPDT.Visible = false;
                        lblDD.Visible = false;
                        LiTrackers.Visible = true;

                    }
                    else if (ObjLoginvo.Role_Code == "COI-DD")
                    {
                        lblDD.Visible = true;
                        lblDashboarddd.HRef = "~/UI/Pages/COI/DdDashboard.aspx";
                        lblClerk.Visible = false;
                        lblSUPDT.Visible = false;
                        lblAD.Visible = false;
                        LiTrackers.Visible = true;
                    }
                    else if (ObjLoginvo.Role_Code == "COMM")
                    {
                        if (Session["IPASSFlag"] != null)
                        {
                            if (Session["IPASSFlag"].ToString() == "Y") 
                            {
                                anchoetag.HRef = "~/UI/Pages/frmDashBoard.aspx";

                                applicanthd.Visible = false;
                                liApplicantIncentivedashbiard.Visible = false;
                                liSvcEntry.Visible = true;
                                liIncentiveDeptDashboard.Visible = true;
                                anchdeptincdashboard.HRef = "~/UI/Pages/COI/CommissionerDashBoard.aspx";
                            }
                        }
                        else
                        {
                            anchoetag.HRef = "~/UI/Pages/frmDashBoard.aspx";

                            applicanthd.Visible = false;
                            liApplicantIncentivedashbiard.Visible = false;
                            liSvcEntry.Visible = true;
                            liIncentiveDeptDashboard.Visible = true;

                            anchdeptincdashboard.HRef = "~/UI/Pages/frmCommissionerDashboard.aspx";
                        }
                    }
                    else
                    {
                        anchoetag.HRef = "~/UI/Pages/frmDashBoard.aspx";

                        applicanthd.Visible = true;
                    }
                }
                else if (ObjLoginvo.userlevel == "13")
                {
                    anchoetag.HRef = "~/UI/UserDashBoard.aspx";
                    applicanthd.Visible = true;
                    liApplicantIncentivedashbiard.Visible = true;
                    liIncentiveDeptDashboard.Visible = false;
                    lblClerk.Visible = false;
                    lblSUPDT.Visible = false;
                    lblAD.Visible = false;
                    lblDD.Visible = false;
                }
                else if (ObjLoginvo.userlevel == "10")
                {
                    if (ObjLoginvo.Role_Code == "DLO")
                    {
                        anchoetag.HRef = "~/UI/Pages/frmDashBoard.aspx";
                        applicanthd.Visible = true;
                        liApplicantIncentivedashbiard.Visible = false;
                        liIncentiveDeptDashboard.Visible = true;
                        anchdeptincdashboard.HRef = "~/UI/Pages/frmDLODashboard.aspx";
                        lichangepwd.Visible = true;
                        liQueryGeneration.Visible = true;
                        liIncentiveReports.Visible = true;
                        lidloWorkingStatus.Visible = true;
                        liApplicationTracker.Visible = false;
                        lblClerk.Visible = false;
                        lblSUPDT.Visible = false;
                        lblAD.Visible = false;
                        lblDD.Visible = false;
                    }
                    if (ObjLoginvo.Role_Code == "AD" || ObjLoginvo.Role_Code == "IPO" || ObjLoginvo.Role_Code == "DD")
                    {
                        anchoetag.HRef = "~/UI/Pages/frmDashBoard.aspx";
                        applicanthd.Visible = true;
                        liApplicantIncentivedashbiard.Visible = false;
                        liIncentiveDeptDashboard.Visible = true;
                        anchdeptincdashboard.HRef = "~/UI/Pages/frmIPOIncentiveDashboard.aspx";
                        lichangepwd.Visible = true;
                        liQueryGeneration.Visible = true;
                        liIncentiveReports.Visible = true;
                        lidloWorkingStatus.Visible = true;
                        liApplicationTracker.Visible = true;
                        liIncentiveTracker.Visible = true;
                        lblClerk.Visible = false;
                        lblSUPDT.Visible = false;
                        lblAD.Visible = false;
                        lblDD.Visible = false;
                    }
                    if (ObjLoginvo.Role_Code == "GM")
                    {
                        anchoetag.HRef = "~/UI/Pages/frmDashBoard.aspx";
                        applicanthd.Visible = true;
                        liApplicantIncentivedashbiard.Visible = false;
                        liIncentiveDeptDashboard.Visible = true;
                        anchdeptincdashboard.HRef = "~/UI/Pages/frmGMDashboard.aspx";
                        lichangepwd.Visible = true;
                        liQueryGeneration.Visible = true;
                        liIncentiveReports.Visible = true;
                        lidloWorkingStatus.Visible = true;
                        liApplicationTracker.Visible = true;
                        liIncentiveTracker.Visible = true;
                        lblClerk.Visible = false;
                        lblSUPDT.Visible = false;
                        lblAD.Visible = false;
                        lblDD.Visible = false;
                    }
                    else if (ObjLoginvo.Role_Code == "ADPP")
                    {
                        anchoetag.HRef = "~/UI/Pages/frmDashBoard.aspx";
                        lipayment.Visible = true;
                        lichangepwd.Visible = true;
                    }
                    else if (ObjLoginvo.Role_Code == "ADMN")
                    {
                        anchoetag.HRef = "~/UI/Pages/frmDashBoard.aspx";
                        liAdmin.Visible = true;
                        lichangepwd.Visible = true;
                        liIncentiveDeptDashboard.Visible = true;
                        anchdeptincdashboard.HRef = "~/UI/Pages/frmDLODashboard.aspx";
                        liSvcEntry.Visible = true;
                        liPlantMachinery.Visible = true;
                        liQueryGeneration.Visible = false;

                        if (ObjLoginvo.DummyLogin=="Y")//(ObjLoginvo.uid == "58260")
                        {
                            liQueryGeneration.Visible = false;
                            liIncentiveDeptDashboard.Visible = false;
                        }
                        if (ObjLoginvo.DummyLogin == "P")
                        {
                            liAdmin.Visible = false;
                        }
                        if (ObjLoginvo.user_id == "RDD-Warangal" || ObjLoginvo.user_id == "RDD-Hyderabad")
                        {
                            anchRDD.HRef = "~/UI/Pages/FormRDDDashboard.aspx";
                            liIncentiveDeptDashboard.Visible = true;
                            liQueryGeneration.Visible = false;
                            liIncentiveDeptDashboardchild.Visible = false;
                            liPlantMachinery.Visible = false;
                            liApplicationTracker.Visible = false;
                            liSvcEntry.Visible = false;
                            liIncentiveTracker.Visible = false;
                            lidloWorkingStatus.Visible = false;
                            liAdmin.Visible = false;
                            lichangepwd.Visible = true;
                            liIncentiveReports.Visible = true;
                            liRDDDashboard.Visible = false;
                        }
                    }
                    if (ObjLoginvo.Role_Code == "IND")
                    {
                        anchoetag.HRef = "~/UI/Pages/frmDashBoard.aspx";
                        applicanthd.Visible = true;
                        liApplicantIncentivedashbiard.Visible = false;
                        liIncentiveDeptDashboard.Visible = true;
                        anchdeptincdashboard.HRef = "~/UI/Pages/frmDLODashboard.aspx";
                        lichangepwd.Visible = true;
                        liQueryGeneration.Visible = true;
                        liIncentiveReports.Visible = false;
                        liApplicationTracker.Visible = false;
                    }
                }
                else if (ObjLoginvo.userlevel == "2")
                {
                    anchoetag.HRef = "~/UI/Pages/Helpdesk/HdDashBoard.aspx";
                    Lidepartment.Visible = true;
                    lichangepwd.Visible = true;

                    if (ObjLoginvo.uid == "60261")
                    {
                        LiAdmin1.Visible = true;
                        liModuleMaster.Visible = true;
                        liSubModuleMaster.Visible = true;
                        liUserMaaping.Visible = true;
                    }
                }

                applicanthd.Visible = false;
                LiAdmin1.Visible = false;
                liModuleMaster.Visible = false;
                liSubModuleMaster.Visible = false;
                liUserMaaping.Visible = false;
            }
        }
        protected void fnSetNewControls_Click(object sender, EventArgs e)
        {
            //Userdtls = (UserLoginDtls)Session["UserDetails"];
            //Objins.UserLogOut(Userdtls.UserName);
            
            if (Session["IPASSFlag"] != null)
            {
                if (Session["IPASSFlag"].ToString() == "Y")
                {
                    string IntUserId = Session["uid"].ToString();
                    string UserName = Session["user_id"].ToString();
                    string Password = Session["password"].ToString();
                    string PwdEncryflag = Session["PwdEncryflag"].ToString();
                    Killsession();
                    Session["UserDetails"] = null;
                    Session.Abandon();
                    Response.Redirect("https://ipass.telangana.gov.in/IpassLogin.aspx?IntUserId=" + IntUserId + "&UserName=" + UserName + "&Password=" +
                                        Password + "&PwdEncryflag=" + PwdEncryflag + "&IsTtap=Y");
                }
            }
            else
            {
                Killsession();
                Session["UserDetails"] = null;
                Session.Abandon();
                Response.Redirect("~/loginReg.aspx");
            }
        }
        public void Killsession()
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            Session.RemoveAll();
            Session.Clear();
            Session.Abandon();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetNoStore();
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Private);
            Response.AppendHeader("Cache-Control", "no-cache; private; no-store; must-revalidate; max-stale=0; post-check=0; pre-check=0; max-age=0"); // HTTP 1.1
            Response.AppendHeader("Pragma", "no-cache");
            Response.AppendHeader("Expires", "Mon, 26 Jul 1997 05:00:00 GMT");
            Response.ClearHeaders();
            Response.Buffer = false;
            Response.Cookies.Clear();
            Request.Cookies.Clear();
        }

        protected void btnIpass_Click(object sender, EventArgs e)
        {

            string IntUserId = Session["uid"].ToString();
            string UserName = Session["user_id"].ToString();
            string Password = Session["password"].ToString();
            string PwdEncryflag = Session["PwdEncryflag"].ToString();
            Response.Redirect("https://ipass.telangana.gov.in/IpassLogin.aspx?IntUserId=" + IntUserId + "&UserName=" + UserName + "&Password=" +
                                Password + "&PwdEncryflag=" + PwdEncryflag + "&IsTtap=Y");
        }

        //    public void CheckMultiUsers(string CurrentUser)
        //    {

        //        if (LoggedUserName.Value == "")
        //        {
        //            LoggedUserName.Value = CurrentUser;
        //        }
        //        else
        //        {
        //            if (LoggedUserName.Value != CurrentUser)
        //            {
        //                fnSetNewControls_Click(this, EventArgs.Empty);
        //            }
        //        }
        //    }
    }
}