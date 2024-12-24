using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogic;
using TTAP.Classfiles;
using System.Data.SqlClient;

namespace TTAP.UI.Pages
{
    public partial class FinalPage : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        General Gen = new General();
        Fetch objFetch = new Fetch();
        comFunctions cmf = new comFunctions();
        comFunctions obcmf = new comFunctions();

        DataSet ds = new DataSet();
        DataSet dsCAF = new DataSet();
        string incentiveid = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] != null)
            {
                try
                {
                    if (!IsPostBack)
                    {

                        if (Session["IncentiveID"] != null)
                        {
                            incentiveid = Session["IncentiveID"].ToString();
                            if (Request.QueryString["BillId"] != null)
                            {
                                string FailMsg = "Payment Failed at Bank.Your Reference Bill No - " + Request.QueryString["BillId"].ToString() +
                                    ". Please Contact TTAP Help Desk with Reference Bill Number if Amount is Debited from your Account";
                                lblFails.Text = FailMsg;
                                tr1.Visible = true;
                            }
                            else
                            {
                                BindAppliedAnnexures(incentiveid);
                                Sendmessages(incentiveid);
                                divdraftpage.Visible = false;
                                divheadermsg.Visible = true;
                                string url = "../Pages/ApplicantIncentivesHistory.aspx";
                                Response.Redirect(url);
                                /*DataSet dscaste = new DataSet();
                                dscaste = GetIncentivesCaste(Session["uid"].ToString(), incentiveid);
                                if (dscaste != null && dscaste.Tables.Count > 0 && dscaste.Tables[0].Rows.Count > 0)
                                {
                                    string applicationStatus = dscaste.Tables[0].Rows[0]["intstatusid"].ToString();
                                    string PaymentFlag = dscaste.Tables[0].Rows[0]["PaymentFlag"].ToString();
                                    if (PaymentFlag == "Y")
                                    {
                                        BindAppliedAnnexures(incentiveid);
                                        divdraftpage.Visible = true;
                                        divheadermsg.Visible = true;
                                    }
                                }*/
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string errorMsg = ex.Message;
                }
            }
        }

        public void SendSmsEmail(string incentiveid, DataSet dscaste)
        {
            string useridnew = Session["uid"].ToString();
            string IncentveID = incentiveid;
            DataSet dsAppliedIncentives = new DataSet();
            string UnitName = "", UnitMobileNo = "", UnitEmail = "", ApplicantName = "", AppliedIncentives = "", ApplicationDate = "", DistrictName = "";

            dsAppliedIncentives = Gen.GetAllIncentivesDeptView(incentiveid);
            if (dsAppliedIncentives != null && dsAppliedIncentives.Tables.Count > 0 && dsAppliedIncentives.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsAppliedIncentives.Tables[0].Rows.Count; i++)
                {
                    if (dsAppliedIncentives.Tables[0].Rows[i]["IncentiveName"] != null && dsAppliedIncentives.Tables[0].Rows[i]["IncentiveName"].ToString() != "")
                    {
                        AppliedIncentives += dsAppliedIncentives.Tables[0].Rows[i]["IncentiveName"].ToString() + ", ";
                    }
                }
            }

            //DataSet dscaste = new DataSet();
            //dscaste = Gen.GetIncentivesCaste(useridnew, IncentveID);        

            if (dscaste != null && dscaste.Tables.Count > 0 && dscaste.Tables[0].Rows.Count > 0)
            {
                string applicationStatus = dscaste.Tables[0].Rows[0]["intstatusid"].ToString();

                UnitName = dscaste.Tables[0].Rows[0]["UnitName"].ToString();
                ApplicantName = dscaste.Tables[0].Rows[0]["ApplciantName"].ToString();
                UnitEmail = dscaste.Tables[0].Rows[0]["UnitEmail"].ToString();
                UnitMobileNo = dscaste.Tables[0].Rows[0]["UnitMObileNo"].ToString();
                ApplicationDate = dscaste.Tables[0].Rows[0]["Created_dtNew"].ToString();
                DistrictName = dscaste.Tables[0].Rows[0]["District"].ToString();
            }

            DataTable dtMandt = objFetch.FetchIncentiveMandatoryDocuments(Convert.ToInt32(incentiveid));

            System.Text.StringBuilder strMandt = new System.Text.StringBuilder();
            string nameuid = UnitEmail.Replace("@", "(at)");
            for (int i = 0; i < dtMandt.Rows.Count - 1; i++) strMandt.Append(dtMandt.Rows[i]["AttachmentName"].ToString() + "<br />");

            try
            {
                cmf.SendMailIncentive(UnitEmail, "You have successfully filed claim application of M/s " + UnitName + " for the following incentives " + AppliedIncentives + "on Date " + ApplicationDate + ", <br /> Thank You, GM, DIC -" + DistrictName + ",<br />  Govt. of Telangana.");
                
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
            try
            {
                cmf.SendSingleSMS(UnitMobileNo, "You have successfully filed claim application of M/s " + UnitName + " for the following incentives " + AppliedIncentives + "on Date " + ApplicationDate + " and a detail mail is sent to " + nameuid + "," + '\n' + "Thank You," + '\n' + "GM, DIC -" + DistrictName + "," + '\n' + "Govt. of Telangana.");

            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }

        }
       
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            //Response.Redirect("../../UI/Pages/InscentiveView_AttachmentsNewIncType.aspx?EntrpId=" + Session["IncentiveID"].ToString());
            Response.Redirect("../../UI/Pages/frmacknowledgement.aspx?EntrpId=" + Session["IncentiveID"].ToString() + "&MailFlag=N");
        }

        protected void LinkDraftCopy_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../UI/Pages/frmDraftApplication.aspx?EntrpId=" + Session["IncentiveID"].ToString(), true);
        }

        public DataSet GetIncentivesCaste(string USERID, string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@CREATEDBY",SqlDbType.VarChar),
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = USERID;
            pp[1].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_INCENTIVES_DATA", pp);
            return Dsnew;
        }

        public DataSet UpdateIncentivesCAFStatus(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_UPDATE_CAF_STATUS", pp);
            return Dsnew;
        }
        public void BindAppliedAnnexures(string INCENTIVEID)
        {
            DataSet ds = new DataSet();
            ds = GetAppliedAnnexures(INCENTIVEID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvSubsidy.DataSource = ds.Tables[0];
                gvSubsidy.DataBind();
            }
        }

        public DataSet GetAppliedAnnexures(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_APPLIED_INCENTIVE_ANNEXURES", pp);
            return Dsnew;
        }
        public void Sendmessages(string IncentiveId)
        {
            string msg = ""; string msg1 = ""; string msg2 = "";
            try
            {
                ClsSMSandMail ClsSMSandMailobj = new ClsSMSandMail();
                ClsSMSandMailobj.SendSmsEmail(IncentiveId, "", "ADMN", "INFOTODLO", "Incentives");
                msg = ClsSMSandMailobj.SendSmsWebService(IncentiveId, "", "Incentives", "1", "USERFILLING");
                msg1 = ClsSMSandMailobj.SendSmsWebService(IncentiveId, "", "Incentives", "2", "USERFILLING");
                msg2 = ClsSMSandMailobj.SendSmsWebService(IncentiveId, "", "Incentives", "3", "USERFILLING");
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }
    }
}