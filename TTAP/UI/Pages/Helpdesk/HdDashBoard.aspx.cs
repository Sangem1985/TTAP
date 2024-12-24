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

namespace eTicketingSystem.UI.Pages.Helpdesk
{
    public partial class HdDashBoard : System.Web.UI.Page
    {
        CAFClass Objret = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/LoginReg.aspx");
            }

            UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
            ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                ds = GetapplicationDtls(ObjLoginvo.uid, ObjLoginvo.userlevel,ObjLoginvo.DistrictID, ObjLoginvo.Mandal_Id);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lblmeetings.Text = ds.Tables[0].Rows[0]["MEETINTCOUNT"].ToString();
                    lbldailyusersvisit.Text = ds.Tables[0].Rows[0]["TOTALLOGINUSERSTODAY"].ToString();
                    lbltodayreg.Text = ds.Tables[0].Rows[0]["TODAYREGISTREDUSERS"].ToString();
                    lbltotalusers.Text = ds.Tables[0].Rows[0]["TOTALREGISTREDUSERS"].ToString();

                    lbltotaliises.Text = ds.Tables[0].Rows[0]["TOTALHD"].ToString();
                    lblcompleted.Text = ds.Tables[0].Rows[0]["CLOSEDHD"].ToString();
                    lblpending.Text = ds.Tables[0].Rows[0]["PENDINGHD"].ToString();
                    lblrejected.Text = ds.Tables[0].Rows[0]["REJECTED"].ToString();
                    spanTotalhds.InnerHtml = "Total ET's Received";
                    if (ObjLoginvo.userlevel == "2" && (ObjLoginvo.Role_Code == "DO" || ObjLoginvo.Role_Code == "DEPT"))
                    {
                        divDoUser.Visible = true;
                        divDoUserPending.Visible = true;
                        divDoUserClosed.Visible = true;

                        lblTotalHDForwarded.Text = ds.Tables[0].Rows[0]["FWDTOTALHD"].ToString();
                        lblPendingHDForwarded.Text = ds.Tables[0].Rows[0]["FWDPENDINGHD"].ToString();
                        lblClosedHDForwarded.Text = ds.Tables[0].Rows[0]["FWDCLOSEDHD"].ToString();
                    }
                    else
                    {
                        divDoUser.Visible = false;
                        divDoUserPending.Visible = false;
                        divDoUserClosed.Visible = false;
                    }


                    if (ObjLoginvo.userlevel == "2" && ObjLoginvo.Role_Code == "")
                    {
                        DivTechTeamDashboard.Visible = true;


                        lblTotalApproval.Text = ds.Tables[0].Rows[0]["FWDTOTALAPPROVALHD"].ToString();
                        lblPendinglApproval.Text = ds.Tables[0].Rows[0]["FWDPENDINGAPPROVALHD"].ToString();
                        lblReceivedApproval.Text = ds.Tables[0].Rows[0]["FWDCLOSEDAPPROVALHD"].ToString();
                        lblClosedApproval.Text = ds.Tables[0].Rows[0]["FWDCLOSEDAPPROVALHDTECH"].ToString();
                    }
                    else
                    {
                        DivTechTeamDashboard.Visible = false;
                    }
                }
            }
        }

        public DataSet GetapplicationDtls(string USERID, string USERTYPE, string DistrictID, string Mandal_Id)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
               new SqlParameter("@USERTYPE",SqlDbType.VarChar),
                new SqlParameter("@DistrictID",SqlDbType.VarChar),
                  new SqlParameter("@Mandal_Id",SqlDbType.VarChar)
           };
            pp[0].Value = USERID;
            pp[1].Value = USERTYPE;
            pp[2].Value = DistrictID;
            pp[3].Value = Mandal_Id;
            Dsnew = Objret.GenericFillDs("USP_GET_DEPARTMENTDASHBOARD", pp);
            return Dsnew;
        }
    }
}