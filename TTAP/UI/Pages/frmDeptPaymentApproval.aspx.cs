using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class frmDeptPaymentApproval : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] != null)
            {
                if (!IsPostBack)
                {
                    string PostBackUrl = Request.UrlReferrer.AbsoluteUri;

                    //if (Request.QueryString["Search"] != null)
                    //{
                    //   string search = Request.QueryString["Search"].ToString();
                    //   PostBackUrl= PostBackUrl + "&Search=" + search.Trim().TrimStart();
                    //}

                    lbtnback.PostBackUrl = PostBackUrl;

                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    string IncentiveID = Request.QueryString["Id"].ToString();
                    DataSet ds = new DataSet();
                    ds = GetAllIncentives(IncentiveID);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        grdDetails.DataSource = ds;
                        grdDetails.DataBind();

                        string PaymentEnableFlag = ds.Tables[0].Rows[0]["PaymentEnableFlag"].ToString();
                        string PAYMENTFLAG = ds.Tables[0].Rows[0]["PAYMENTFLAG"].ToString();

                        if (ObjLoginNewvo.Role_Code == "ADPP" && ObjLoginNewvo.userlevel == "10")
                        {
                            if (PAYMENTFLAG.Trim().TrimStart() == "Y")
                            {
                                divbuttons.Visible = false;
                                PaymentSelection.Visible = false;
                            }
                        }
                        else
                        {
                            divbuttons.Visible = false;
                            PaymentSelection.Visible = false;
                        }
                        
                        double TotalValue = 0;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            double Value = Convert.ToDouble(row["TotalAmount"].ToString());
                            TotalValue = TotalValue + Value;
                        }
                        lblTotalAmount.InnerHtml = TotalValue.ToString();

                        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                        {
                            gvPaymentDetails.DataSource = ds.Tables[1];
                            gvPaymentDetails.DataBind();
                            divrtgspayment.Visible = true;
                        }
                    }
                }
            }
            else
            {

            }
        }
        public DataSet GetAllIncentives(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("[USP_GET_PAYMENT_DTLS_INCENTIVES]", pp);
            return Dsnew;
        }
        public string ValidateControls()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (ddlPaymentMode.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Status Of Payment\\n";
                slno = slno + 1;
            }
            if (txtRemarks.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Remarks\\n";
                slno = slno + 1;
            }

            return ErrorMsg;
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                string errormsg = ValidateControls();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    string IncentiveID = Request.QueryString["Id"].ToString();
                    DeptPaymentApprovalStatus ObjDeptPaymentApprovalStatus = new DeptPaymentApprovalStatus();

                    ObjDeptPaymentApprovalStatus.CreatedBy = ObjLoginNewvo.uid;
                    ObjDeptPaymentApprovalStatus.IncentiveID = IncentiveID;
                    ObjDeptPaymentApprovalStatus.Status = ddlPaymentMode.SelectedValue;
                    ObjDeptPaymentApprovalStatus.Remarks = txtRemarks.Text.Trim().TrimStart();
                    ObjDeptPaymentApprovalStatus.OnlineOrderNumber = (gvPaymentDetails.Rows[0].FindControl("lblOnlineBillerID") as Label).Text;

                    string Status = ObjCAFClass.UpdateNEFTRTGSPaymentStatus(ObjDeptPaymentApprovalStatus);

                    if (Status == "1")
                    {
                        PaymentSelection.Visible = false;
                        divbuttons.Visible = false;


                        //string Successmsg = "Payment Details Updated Successfully and Application has been Submitted to Respective DLO";
                        string Successmsg = "Payment Details Updated Successfully and Application has been Sent to Commissioner Tray for Scrutiny";
                        lblmsg.Text = Successmsg;
                        Failure.Visible = false;
                        success.Visible = true;

                        try
                        {
                            ClsSMSandMail ClsSMSandMailobj = new ClsSMSandMail();
                            ClsSMSandMailobj.SendSmsEmail(IncentiveID, "", "USER", "USERFILLING", "Incentives");
                        }
                        catch (Exception ex)
                        {
                            string errorMsg = ex.Message;
                        }
                        string message = "alert('" + Successmsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
    }
}