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

namespace TTAP.UI.Pages
{
    public partial class frmStampDuty : System.Web.UI.Page
    {
        General Gen = new General();
        BusinessLogic.DML objDml = new BusinessLogic.DML();

        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        CAFClass ObjCAFClass = new CAFClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
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
                        if (Session["incentivedata"] != null)
                        {
                            string userid = Session["uid"].ToString();
                            string IncentveID = Session["IncentiveID"].ToString();
                            DataSet ds = new DataSet();
                            ds = (DataSet)Session["incentivedata"];
                            DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 5);
                            if (drs.Length > 0)
                            {
                                DataSet dsnew = new DataSet();
                                GetStampDutyDetails(userid, IncentveID);
                            }
                            else
                            {
                                if (Request.QueryString[0].ToString() == "N")
                                {
                                    Response.Redirect("frmConcessionSGST.aspx?next=" + "N");
                                }
                                else
                                {
                                    Response.Redirect("PowerTariffSubsidy.aspx?Previous=" + "P");
                                }
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
        public void EnableDisableForm(ControlCollection ctrls, bool status)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Enabled = status;

                // if (ctrl is Button)      // commented to enable the Button Controls
                //    ((Button)ctrl).Enabled = status;

                else if (ctrl is DropDownList)
                    ((DropDownList)ctrl).Enabled = status;
                else if (ctrl is CheckBox)
                    ((CheckBox)ctrl).Enabled = status;
                else if (ctrl is RadioButton)
                    ((RadioButton)ctrl).Enabled = status;
                else if (ctrl is RadioButtonList)
                    ((RadioButtonList)ctrl).Enabled = status;
                else if (ctrl is CheckBoxList)
                    ((CheckBoxList)ctrl).Enabled = status;

                EnableDisableForm(ctrl.Controls, status);

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
        public void GetStampDutyDetails(string uid, string IncentiveID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetapplicationDtls(uid, IncentiveID);
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    lblTSIPassUIDNumber.InnerText = dsnew.Tables[0].Rows[0]["Uid_NO"].ToString();
                    lblCommonApplicationNumber.InnerText = dsnew.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                    lblTypeofApplicant.InnerText = dsnew.Tables[0].Rows[0]["TypeOfIndustryText"].ToString();
                    string TypeOfIndustry = dsnew.Tables[0].Rows[0]["TypeOfIndustry"].ToString();
                    if (TypeOfIndustry == "1")
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCP"].ToString();
                    }
                    else
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCPExp"].ToString();
                    }

                    txtLineofActivity.Text = dsnew.Tables[0].Rows[0]["ProductDtls"].ToString();

                    string ENABLINGCONTRILS = dsnew.Tables[0].Rows[0]["ENABLINGCONTRILS"].ToString();
                    if ((dsnew.Tables[0].Rows[0]["intStatusid"].ToString() == null || dsnew.Tables[0].Rows[0]["intStatusid"].ToString() == ""))// && ENABLINGCONTRILS == "N")
                    {
                        EnableDisableForm(Page.Controls, true);
                    }
                    else
                    {
                        string applicationStatus = "";
                        applicationStatus = dsnew.Tables[0].Rows[0]["intStatusid"].ToString();
                        if (applicationStatus == "")
                        {
                            applicationStatus = "0";
                        }
                        if (Convert.ToInt32(applicationStatus) >= 2 || ENABLINGCONTRILS == "Y")  //3  changed on 17.11.2017 
                        {
                            EnableDisableForm(Page.Controls, false);
                            btnRegisteredLandSale.Enabled = false;
                            btnPaymentProof.Enabled = false;
                            //grdPandM.Columns[19].Visible = false;
                            //grdPandM.Columns[18].Visible = false;
                        }
                        else
                        {
                            EnableDisableForm(Page.Controls, true);
                        }
                    }
                }


                DataSet ds = new DataSet();
                SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@created_BY",SqlDbType.Int),
                    new SqlParameter("@IncentiveID",SqlDbType.Int)
                };
                p[0].Value = uid;
                p[1].Value = IncentiveID;
                ds = Gen.GenericFillDs("USP_GET_STAMPDUTY", p);
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.ToString() != "" && ds.Tables[0].Rows.ToString() != null)
                {

                    ddlNatureofAsset.SelectedValue = ds.Tables[0].Rows[0]["NatureofAsset"].ToString();
                    txtLandPurchased.Text = ds.Tables[0].Rows[0]["LandPurchased_Sqmtrs"].ToString();
                    txtLandPurchasedCostPersqmtrs.Text = ds.Tables[0].Rows[0]["LandPurchasedCostPersqmtrs"].ToString();
                    txtPlinthAreaoftheBuilding.Text = ds.Tables[0].Rows[0]["PlinthAreaBuilding"].ToString();
                    txtPlinthFactoryBuildings.Text = ds.Tables[0].Rows[0]["PlinthAreaofFactoryFiveTmes"].ToString();
                    txtFactoryappraisal.Text = ds.Tables[0].Rows[0]["Arearequiredappraisal"].ToString();
                    txtTSPCB.Text = ds.Tables[0].Rows[0]["ArearequiredTSPCB"].ToString();
                    ddlNatureofTransaction.SelectedValue = ds.Tables[0].Rows[0]["NatureofTransaction"].ToString();
                    txtDateofRegistration.Text = ds.Tables[0].Rows[0]["DateofRegistration"].ToString();
                    SubRegistrar.Text = ds.Tables[0].Rows[0]["SubRegistrarOffice"].ToString();
                    txtStampDutyTransferDutyPaid.Text = ds.Tables[0].Rows[0]["StampDuty_TransferDuty_Paid"].ToString();
                    txtMortgageHypothecationDutyPaid.Text = ds.Tables[0].Rows[0]["MortgageHypothecationDutyPaid"].ToString();
                    txtStampDutyExemptionalreadyAvailed.Text = ds.Tables[0].Rows[0]["StampDutyExemptionAvailed"].ToString();
                    Termloan14.Text = ds.Tables[0].Rows[0]["Termloan"].ToString();
                    txtCurrentClaimStampTransferDuty.Text = ds.Tables[0].Rows[0]["CurrentClaimStampDutyTransferDuty"].ToString();
                    txtCurrentClaimMortgageHypothecationDuty.Text = ds.Tables[0].Rows[0]["CurrentClaimMortgageHypothecationDuty"].ToString();

                    txtAmountAvailed.Text = ds.Tables[0].Rows[0]["AmountAvailed"].ToString();
                    txtSanctionOrderNo.Text = ds.Tables[0].Rows[0]["SanctionOrderNo"].ToString();
                    txtDateAvailed.Text = ds.Tables[0].Rows[0]["DateAvailedDDMMYY"].ToString();
                    txtLineofActivity.Text = ds.Tables[0].Rows[0]["LineofActivity"].ToString();
                }

                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    try
                    {
                        int RowsCount = ds.Tables[1].Rows.Count;
                        string Path, Docid;
                        for (int i = 0; i < RowsCount; i++)
                        {
                            Path = ds.Tables[1].Rows[i]["link"].ToString();
                            Docid = ds.Tables[1].Rows[i]["AttachmentId"].ToString();
                            if (!string.IsNullOrEmpty(Path))
                            {
                                if (Docid == "51001")
                                {
                                    objClsFileUpload.AssignPath(hyRegisteredlandSale, Path);
                                }
                                else if (Docid == "51002")
                                {
                                    objClsFileUpload.AssignPath(hyPayment, Path);
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
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string GeneralInformationcheck()
        {
            int slno = 1;
            string ErrorMsg = "";
            if (ddlNatureofAsset.SelectedIndex == -1)
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Nature of Asset \\n";
                slno = slno + 1;
            }

            if (txtLandPurchased.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Land Purchased – As per the Registered Sale Deed (In sq mtrs) \\n";
                slno = slno + 1;
            }
            if (txtLandPurchasedCostPersqmtrs.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Land Purchased Cost per sq mtr) \\n";
                slno = slno + 1;
            }
            if (txtPlinthAreaoftheBuilding.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Plinth Area of the Building – As per the Approved Building Plan by HUDA / DT & CP / IALA (In sq mtrs) \\n";
                slno = slno + 1;
            }
            if (txtPlinthFactoryBuildings.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter 5 times of the Plinth Area of Factory Buildings (In sq mtrs) \\n";
                slno = slno + 1;
            }

            if (txtFactoryappraisal.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Area required for the Factory as per the appraisal (In sq mtrs) \\n";
                slno = slno + 1;
            }
            if (txtTSPCB.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Area required for the Factory as per the norms of TSPCB or any other State Government Department (In sq mtrs) \\n";
                slno = slno + 1;
            }
            if (ddlNatureofTransaction.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Nature of Transaction / Deed Registered for Industrial Use (Sale / Lease or Lease-cum-sale Transfer Deed / Financial Deeds and Mortgages etc)\\n";
                slno = slno + 1;
            }
            if (txtDateofRegistration.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Date of Registration \\n";
                slno = slno + 1;
            }
            if (SubRegistrar.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Name of Sub-Registrar Office, where registered \\n";
                slno = slno + 1;
            }
            if (txtStampDutyTransferDutyPaid.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter  Stamp Duty / Transfer Duty Paid \\n";
                slno = slno + 1;
            }
            if (txtMortgageHypothecationDutyPaid.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Mortgage & Hypothecation Duty Paid  \\n";
                slno = slno + 1;
            }
            if (txtLineofActivity.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Line of Activity of The Unit  \\n";
                slno = slno + 1;
            }

            if (txtCurrentClaimStampTransferDuty.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Claim  Stamp Duty / Transfer Duty Paid \\n";
                slno = slno + 1;
            }
            if (txtCurrentClaimMortgageHypothecationDuty.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Claim Mortgage & Hypothecation Duty Paid  \\n";
                slno = slno + 1;
            }
            return ErrorMsg;
        }


        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }


        public void DeleteFile(string strFileName)
        {//Delete file from the server
            if (strFileName.Trim().Length > 0)
            {
                FileInfo fi = new FileInfo(strFileName);
                if (fi.Exists)//if file exists delete it
                {
                    fi.Delete();
                }
            }
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            try
            {
                string errormsg = GeneralInformationcheck();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {

                    string errormsgAttach = ObjCAFClass.ValidateMandatoryAttachments(Session["IncentiveID"].ToString(), "5");
                    if (errormsgAttach.Trim().TrimStart() != "")
                    {
                        string message = "alert('" + errormsgAttach + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    FormVIStampDutyVo ObjFormVIStampDutyVo = new FormVIStampDutyVo();

                    ObjFormVIStampDutyVo.IncentiveId = Session["IncentiveID"].ToString();
                    ObjFormVIStampDutyVo.CreatedBy = ObjLoginNewvo.uid;

                    ObjFormVIStampDutyVo.NatureofAsset = ddlNatureofAsset.SelectedValue;
                    ObjFormVIStampDutyVo.LandPurchased_Sqmtrs = txtLandPurchased.Text.Trim().TrimStart();
                    ObjFormVIStampDutyVo.LandPurchasedCostPersqmtrs = GetDecimalNullValue(txtLandPurchasedCostPersqmtrs.Text.Trim().TrimStart());
                    ObjFormVIStampDutyVo.PlinthAreaBuilding = GetDecimalNullValue(txtPlinthAreaoftheBuilding.Text.Trim().TrimStart());
                    ObjFormVIStampDutyVo.PlinthAreaofFactoryFiveTmes = GetDecimalNullValue(txtPlinthFactoryBuildings.Text.Trim().TrimStart());
                    ObjFormVIStampDutyVo.Arearequiredappraisal = txtFactoryappraisal.Text.Trim().TrimStart();
                    ObjFormVIStampDutyVo.ArearequiredTSPCB = txtTSPCB.Text.Trim().TrimStart();
                    ObjFormVIStampDutyVo.NatureofTransaction = ddlNatureofTransaction.SelectedValue;
                    //ObjFormVIStampDutyVo.DateofRegistration= txtDateofRegistration.Text.Trim().TrimStart();
                    string[] Ld6 = null;
                    string ConvertedDt56 = "";
                    if (txtDateofRegistration.Text.Trim().TrimStart() != "")
                    {
                        Ld6 = txtDateofRegistration.Text.Trim().TrimStart().Split('/');
                        ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();
                        ObjFormVIStampDutyVo.DateofRegistration = ConvertedDt56;
                    }
                    else
                    {
                        ObjFormVIStampDutyVo.DateofRegistration = null;
                    }
                    ObjFormVIStampDutyVo.SubRegistrarOffice = SubRegistrar.Text.Trim().TrimStart();
                    ObjFormVIStampDutyVo.StampDuty_TransferDuty_Paid = txtStampDutyTransferDutyPaid.Text.Trim().TrimStart();
                    ObjFormVIStampDutyVo.MortgageHypothecationDutyPaid = txtMortgageHypothecationDutyPaid.Text.Trim().TrimStart();
                    ObjFormVIStampDutyVo.StampDutyExemptionAvailed = txtStampDutyExemptionalreadyAvailed.Text.Trim().TrimStart();

                    ObjFormVIStampDutyVo.Termloan = Termloan14.Text.Trim().TrimStart();
                    ObjFormVIStampDutyVo.CurrentClaimStampDutyTransferDuty = txtCurrentClaimStampTransferDuty.Text.Trim().TrimStart();
                    ObjFormVIStampDutyVo.CurrentClaimMortgageHypothecationDuty = txtCurrentClaimMortgageHypothecationDuty.Text.Trim().TrimStart();

                    ObjFormVIStampDutyVo.AmountAvailed = GetDecimalNullValue(txtAmountAvailed.Text.Trim().TrimStart());
                    ObjFormVIStampDutyVo.SanctionOrderNo = txtSanctionOrderNo.Text.Trim().TrimStart();
                    ObjFormVIStampDutyVo.DateAvailed = GetFromatedDateDDMMYYYY(txtDateAvailed.Text.Trim().TrimStart());
                    ObjFormVIStampDutyVo.LineofActivity = txtLineofActivity.Text.Trim().TrimStart();

                    string Validstatus = ObjCAFClass.InsertingOfStampdutyDtls(ObjFormVIStampDutyVo);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        Response.Redirect("frmConcessionSGST.aspx?next=" + "N");
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
        public string GetDecimalNullValue(string Input)
        {
            string InputValue = "";

            InputValue = (Input != "") ? Input : "0";

            return InputValue;
        }
        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("PowerTariffSubsidy.aspx?Previous=" + "P");
        }

        protected void btnRegisteredLandSale_Click(object sender, EventArgs e)
        {

            if (fuRegisteredLandSale.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuRegisteredLandSale);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuRegisteredLandSale);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuRegisteredLandSale, hyRegisteredlandSale, "RegisteredLandSaleDeedLeaseDeedTransferDeed", Session["IncentiveID"].ToString(), "5", "51001", Session["uid"].ToString(), "USER");

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
        }

        protected void btnPaymentProof_Click(object sender, EventArgs e)
        {
            if (fuPaymentProof.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuPaymentProof);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuPaymentProof);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuPaymentProof, hyPayment, "PaymentProof", Session["IncentiveID"].ToString(), "5", "51002", Session["uid"].ToString(), "USER");

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
        }

        protected void txtPlinthAreaoftheBuilding_TextChanged(object sender, EventArgs e)
        {
            if (txtPlinthAreaoftheBuilding.Text.Trim() != "")
            {
                txtPlinthFactoryBuildings.Text = (Convert.ToDecimal("5.00") * Convert.ToDecimal(txtPlinthAreaoftheBuilding.Text.Trim())).ToString();
            }
            else
            {
                txtPlinthFactoryBuildings.Text = "0";
            }
        }
    }
}