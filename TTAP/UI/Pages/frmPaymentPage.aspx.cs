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
    public partial class frmPaymentPage : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Form.Enctype = "multipart/form-data";

                if (Session["ObjLoginvo"] != null)
                {
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    if (hdnUserID.Value == "")
                    {
                        hdnUserID.Value = ObjLoginNewvo.uid;
                    }
                    else
                    {
                        PageName pageName = new PageName();
                        string Valid = pageName.ValidateUser(hdnUserID.Value, ObjLoginNewvo.uid);
                        if (Valid == "1")
                        {
                            Session.RemoveAll();
                            Session.Clear();
                            Session.Abandon();
                            Response.Redirect("~/LoginReg.aspx");
                        }
                    }
                    if (!IsPostBack)
                    {
                        DataSet ds = new DataSet();
                        ds = GetAllIncentives(Session["uid"].ToString(), Session["IncentiveID"].ToString());
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            ViewState["AppliedIncentives"] = ds;
                            grdDetails.DataSource = ds;
                            grdDetails.DataBind();

                            string PaymentEnableFlag = ds.Tables[0].Rows[0]["PaymentEnableFlag"].ToString();
                            string PAYMENTFLAG = ds.Tables[0].Rows[0]["PAYMENTFLAG"].ToString();

                            if (PAYMENTFLAG.Trim().TrimStart() == "Y")
                            {
                                Response.Redirect("FinalPage.aspx");
                            }
                            else if (PaymentEnableFlag == "N")
                            {
                                divbuttons.Visible = false;
                                divrtgsPaymentDtls.Visible = false;
                                PaymentSelection.Visible = false;
                            }

                            double TotalValue = 0;
                            foreach (DataRow row in ds.Tables[0].Rows)
                            {
                                double Value = Convert.ToDouble(row["TotalAmount"].ToString());
                                TotalValue = TotalValue + Value;
                            }
                            lblTotalAmount.InnerHtml = TotalValue.ToString();
                            ViewState["ActualTotalAmount"] = TotalValue.ToString();

                            DataSet dsnew = new DataSet();
                            dsnew = GetapplicationDtls("0", Session["IncentiveID"].ToString());
                            if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                            {
                                Session["ApplicationNumber"] = dsnew.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                            }
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
                    Response.Redirect("~/LoginReg.aspx");
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                string uid = "0";
                if (Session["uid"] != null)
                {
                    uid = Session["uid"].ToString();
                }

                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, uid);
            }
        }
        public DataSet GetapplicationDtls(string USERID, string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@CREATEDBY",SqlDbType.VarChar),
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = USERID;
            pp[1].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_INCENTIVES_CAF_DATA", pp);
            return Dsnew;
        }
        public DataSet GetAllIncentives(string USERID, string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@CREATEDBY",SqlDbType.VarChar),
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = USERID;
            pp[1].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("[FetchIncentives_CAF_PAYMENT]", pp);
            return Dsnew;
        }

        protected void rblPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            divbuttons.Visible = true;
            if (rblPaymentMode.SelectedValue == "NEFT" || rblPaymentMode.SelectedValue == "RTGS")
            {
                divrtgsPaymentDtls.Visible = true;
                divcondtions.Visible = false;
            }
            else
            {
                divrtgsPaymentDtls.Visible = false;
                divcondtions.Visible = true;
            }
        }

        protected void btnPaymentProof_Click(object sender, EventArgs e)
        {
            if (fuPaymentProof.HasFile)
            {
                string Mimetype = objClsFileUpload.getmimetype(fuPaymentProof);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuPaymentProof, hyPaymentProof, "PaymentProof", Session["IncentiveID"].ToString(), "100", "551001", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
            else
            {
                MessageBox("Select a File!");
            }
        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {

        }
        public string GetDecimalNullValue(string Input)
        {
            string InputValue = "";

            InputValue = (Input != "") ? Input : "0";

            return InputValue;
        }
        public string GetFromatedDateDDMMYYYY(string Date)
        {
            string Dateformat = "";
            string[] Ld6 = null;
            string ConvertedDt56 = "";
            if (Date != "")
            {
                Ld6 = Date.Split('/');
                ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();
                Dateformat = ConvertedDt56;
            }
            else
            {
                Dateformat = null;
            }
            return Dateformat;
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            string TTAPBillerID = "Bill" + DateTime.Now.ToString("yyyyMMddHHmmss").ToString();
            UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
            ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

            RTGSNEFTPayment objRTGSNEFTPayment = new RTGSNEFTPayment();
            double ApplicationFee = 0;
            double TaxAmount = 0;
            double TotalAmount = 0;

            objRTGSNEFTPayment.ApplicationNumber = Session["ApplicationNumber"].ToString();
            objRTGSNEFTPayment.IncentiveID = Session["IncentiveId"].ToString();
            objRTGSNEFTPayment.TTAPBillerID = TTAPBillerID;
            objRTGSNEFTPayment.PaymentMode = "TSIPASS";
            objRTGSNEFTPayment.ApplicationFee = ApplicationFee.ToString();
            objRTGSNEFTPayment.Tax_Amount = TaxAmount.ToString();
            objRTGSNEFTPayment.Total_Amount = TotalAmount.ToString();
            objRTGSNEFTPayment.PGRefNo = "TSIPASS";
            objRTGSNEFTPayment.CreatedBy = ObjLoginNewvo.uid;
            int Status = ObjCAFClass.RTGSNEFTPaymentDtls_1(objRTGSNEFTPayment);
            if (Status > 0)
            {
                string Message = "  Dear Entrepreneur, Your Incentive Application has been sent to concern Department";
                lblmsg.Text = Message;
                success.Visible = true;
                btnDash.Visible = true;
                Failure.Visible = false;
                BtnSubmit.Visible = false;
                divrtgsPaymentDtls.Visible = false;
                PaymentSelection.Visible = false;
            }
        }
        protected void BtnSubmit_Click1(object sender, EventArgs e)/* This Methos is for  NEFT/RTGS Payments Methods*/
        {
            string TTAPBillerID = "Bill" + DateTime.Now.ToString("yyyyMMddHHmmss").ToString();
            UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
            ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

            if (rblPaymentMode.SelectedValue == "NEFT" || rblPaymentMode.SelectedValue == "RTGS")
            {
                string errormsg = ValidateControls();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    RTGSNEFTPayment objRTGSNEFTPayment = new RTGSNEFTPayment();

                    objRTGSNEFTPayment.IncentiveID = Session["IncentiveID"].ToString();
                    objRTGSNEFTPayment.TTAPBillerID = TTAPBillerID;
                    objRTGSNEFTPayment.PaymentMode = rblPaymentMode.SelectedValue;
                    objRTGSNEFTPayment.UTRNo = txtUTRNo.Text.Trim().TrimStart();
                    objRTGSNEFTPayment.DateofRemittance = GetFromatedDateDDMMYYYY(txtTransferredDate.Text.Trim().TrimStart());
                    objRTGSNEFTPayment.ACTUALAMOUNT = ViewState["ActualTotalAmount"].ToString();
                    objRTGSNEFTPayment.Amount = GetDecimalNullValue(txtAmountpaid.Text.Trim().TrimStart());
                    objRTGSNEFTPayment.NameoftheBank = txtNameoftheBank.Text.Trim().TrimStart();
                    objRTGSNEFTPayment.Branch = txtBranch.Text.Trim().TrimStart();
                    objRTGSNEFTPayment.CreatedBy = ObjLoginNewvo.uid;

                    List<OnlinePaymentDtls> lstOnlinePaymentDtls = new List<OnlinePaymentDtls>();
                    DataSet ds = new DataSet();
                    ds = (DataSet)ViewState["AppliedIncentives"];
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        OnlinePaymentDtls objOnlinePaymentDtls = new OnlinePaymentDtls();
                        double ApplicationFee = Convert.ToDouble(row["ApplicationFee"].ToString());
                        double TaxAmount = Convert.ToDouble(row["TaxAmount"].ToString());
                        double TotalAmount = Convert.ToDouble(row["TotalAmount"].ToString());

                        objOnlinePaymentDtls.ApplicationNumber = Session["ApplicationNumber"].ToString();
                        objOnlinePaymentDtls.IncentiveID = Session["IncentiveID"].ToString();
                        objOnlinePaymentDtls.SubIncentiveID = row["SubIncentiveID"].ToString();
                        objOnlinePaymentDtls.TTAPBillerID = TTAPBillerID;
                        objOnlinePaymentDtls.PaymentMode = rblPaymentMode.SelectedValue;
                        objOnlinePaymentDtls.ApplicationFee = ApplicationFee.ToString();
                        objOnlinePaymentDtls.Tax_Amount = TaxAmount.ToString();
                        objOnlinePaymentDtls.Total_Amount = TotalAmount.ToString();
                        objOnlinePaymentDtls.CreatedBy = ObjLoginNewvo.uid;

                        lstOnlinePaymentDtls.Add(objOnlinePaymentDtls);
                    }

                    int Status = ObjCAFClass.RTGSNEFTPaymentDtls(objRTGSNEFTPayment, lstOnlinePaymentDtls);
                    if (Status > 0)
                    {
                        string Message = "  Dear Entrepreneur, Your Payment Details Has Been Sent To Department For Verification. " +
                            "The Application Will be Submitted Once Your Payment Details Veriifed by the Department";

                        lblmsg.Text = Message;
                        success.Visible = true;
                        Failure.Visible = false;
                        divbuttons.Visible = false;
                        divrtgsPaymentDtls.Visible = false;
                        PaymentSelection.Visible = false;
                    }
                }
            }
            else
            {
                List<OnlinePaymentDtls> lstOnlinePaymentDtls = new List<OnlinePaymentDtls>();
                DataSet ds = new DataSet();
                ds = (DataSet)ViewState["AppliedIncentives"];
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    OnlinePaymentDtls objOnlinePaymentDtls = new OnlinePaymentDtls();
                    double ApplicationFee = Convert.ToDouble(row["ApplicationFee"].ToString());
                    double TaxAmount = Convert.ToDouble(row["TaxAmount"].ToString());
                    double TotalAmount = Convert.ToDouble(row["TotalAmount"].ToString());

                    objOnlinePaymentDtls.ApplicationNumber = Session["ApplicationNumber"].ToString();
                    objOnlinePaymentDtls.IncentiveID = Session["IncentiveID"].ToString();
                    objOnlinePaymentDtls.SubIncentiveID = row["SubIncentiveID"].ToString();
                    objOnlinePaymentDtls.TTAPBillerID = TTAPBillerID;
                    objOnlinePaymentDtls.PaymentMode = rblPaymentMode.SelectedValue;
                    objOnlinePaymentDtls.ApplicationFee = ApplicationFee.ToString();
                    objOnlinePaymentDtls.Tax_Amount = TaxAmount.ToString();
                    objOnlinePaymentDtls.Total_Amount = TotalAmount.ToString();
                    objOnlinePaymentDtls.CreatedBy = ObjLoginNewvo.uid;

                    lstOnlinePaymentDtls.Add(objOnlinePaymentDtls);
                }
                int Status = ObjCAFClass.OnlinePaymentDtls(lstOnlinePaymentDtls);
                if (Status > 0)
                {
                    Session["onlinetransId"] = TTAPBillerID;
                    Response.Redirect("BilldeskPaymentPage.aspx");
                }
            }
        }

        public string ValidateControls()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (txtUTRNo.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter UTR No\\n";
                slno = slno + 1;
            }

            if (txtTransferredDate.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Date of Remittance\\n";
                slno = slno + 1;
            }
            else
            {
                string[] Date = txtTransferredDate.Text.Trim().Split('/');
                DateTime Todate = Convert.ToDateTime(Date[2] + "/" + Date[1] + "/" + Date[0]);
                DateTime fromdate = DateTime.Now;
                if (Todate > fromdate)
                {
                    ErrorMsg = ErrorMsg + slno + ". Date of Remittance Cannot be Future Date\\n";
                    slno = slno + 1;
                }
            }
            if (txtAmountpaid.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Transferred  Amount\\n";
                slno = slno + 1;
            }
            else if (Convert.ToDouble(ViewState["ActualTotalAmount"].ToString()) > Convert.ToDouble(txtAmountpaid.Text.TrimStart().TrimEnd().Trim()))
            {
                ErrorMsg = ErrorMsg + slno + ".The Transferred Amount Should not be lesser then the Total amount\\n";
                slno = slno + 1;
            }
            if (txtNameoftheBank.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Bank Name\\n";
                slno = slno + 1;
            }
            if (txtNameoftheBank.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter  Branch Name\\n";
                slno = slno + 1;
            }
            if (hyPaymentProof.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Upload Payment Proof\\n";
                slno = slno + 1;
            }
            return ErrorMsg;
        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            string PaymentMode = rdbPaymentType.SelectedValue.ToString();
            string IncentiveId = Session["IncentiveID"].ToString();
            string TTAPBillerID = "Bill" + IncentiveId + DateTime.Now.ToString("yyyyMMddHHmmss").ToString();
            Response.Redirect("~/UI/Pages/BilldeskPaymentPage.aspx?PMode=" + PaymentMode + "&IncentiveId=" + IncentiveId + "&BillerID=" + TTAPBillerID);
        }

        protected void rdbPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal Charges = 0;
            string PaymentMode = rdbPaymentType.SelectedValue.ToString();
            if (PaymentMode == "NB" || PaymentMode == "NBS" || PaymentMode == "NBH" || PaymentMode == "NBI")
            {
                 Charges= Convert.ToDecimal(15.00 + 2.70);
            }
            if (PaymentMode == "CC")
            {
                 Charges = Convert.ToDecimal(12.50 + 2.25);
            }
            if (PaymentMode == "DC")
            {
                 Charges = Convert.ToDecimal(6.50 + 0.97);
            }
            string Text = "Included ₹ " + Charges + " Charges";
            lblTaxes.InnerText = Text;
        }

        protected void btnDash_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UI/Pages/ApplicantIncentivesHistory.aspx");
        }
    }
}