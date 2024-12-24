using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BusinessLogic;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class frmacknowledgement : System.Web.UI.Page
    {
        comFunctions obcmf = new comFunctions();
        Fetch objFetch = new Fetch();
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session.Count <= 0)
                {
                    Response.Redirect("~/LoginReg.aspx", false);
                    return;
                }

                string IncentiveID = "";
                if (Session["IncentiveID"] != null)
                {
                    IncentiveID = Session["IncentiveID"].ToString();
                }
                else if (Request.QueryString.Count > 0 && Request.QueryString["EntrpId"] != null)
                {
                    IncentiveID = Request.QueryString["EntrpId"].ToString();
                }

                // UpdateIncentivesCAFStatus(IncentiveID);
                Fetch obj = new Fetch();
                DataTable dt = obj.FetchIncentiveDtlsbyIncentiveID_NewIncType(IncentiveID);
                lblUidNO.Text = dt.Rows[0]["Uid_NO"].ToString();
                lblUnitName.Text = dt.Rows[0]["UnitName"].ToString() + dt.Rows[0]["District_Name"].ToString()
                    + dt.Rows[0]["Manda_lName"].ToString()
                    + dt.Rows[0]["Village_Name"].ToString();
                lblapplicationnumber.Text = dt.Rows[0]["ApplicationNumber"].ToString();
                lblDateofAppln.Text = dt.Rows[0]["lblDateofAppln"].ToString();

                try
                {
                    ClsSMSandMail ClsSMSandMailobj = new ClsSMSandMail();
                    if (Request.QueryString.Count > 0 && Request.QueryString["MailFlag"] != null)
                    {
                        if (Request.QueryString["MailFlag"] == "Y")
                        {
                            ClsSMSandMailobj.SendSmsEmail(IncentiveID, "", "USER", "USERFILLING", "Incentives");
                        }
                    }
                    //else if (Request.QueryString.Count > 0 && Request.QueryString["MailFlag"] != null)
                    //{
                    //    ClsSMSandMailobj.SendSmsEmail(IncentiveID, "", "USER", "USERFILLING", "Incentives");
                    //}
                }
                catch (Exception ex)
                {
                    string errorMsg = ex.Message;
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }
        public DataSet UpdateIncentivesCAFStatus(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_UPDATE_CAF_STATUS_AKNOWLDGEMENT", pp);
            return Dsnew;
        }

        protected void btnInstalledcap_Click(object sender, EventArgs e)
        {
            UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
            ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

            if (ObjLoginNewvo.userlevel == "13")
            {
                Response.Redirect("~/UI/UserDashBoard.aspx");
            }
            else
            {
                Response.Redirect("~/UI/frmDashBoard.aspx");
            }
        }
    }
}