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
    public partial class frmLandCostSubsidy : System.Web.UI.Page
    {
        General Gen = new General();
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        CAFClass ObjCAFClass = new CAFClass();

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
                        if (Session["incentivedata"] != null)
                        {
                            string userid = Session["uid"].ToString();
                            string IncentveID = Session["IncentiveID"].ToString();
                            DataSet ds = new DataSet();
                            ds = (DataSet)Session["incentivedata"];
                            DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 11);
                            if (drs.Length > 0)
                            {
                                DataSet dsnew = new DataSet();
                                GetLandCostSubsidy(userid, IncentveID);
                            }
                            else
                            {
                                if (Request.QueryString[0].ToString() == "N")
                                {
                                    Response.Redirect("frmRentalSubsidy.aspx?next=" + "N");
                                }
                                else
                                {
                                    Response.Redirect("frmProductDevelopment.aspx?Previous=" + "P");
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

        public void GetLandCostSubsidy(string uid, string IncentiveID)
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

                    txtDateofEstablishmentofUnit.Text = dsnew.Tables[0].Rows[0]["DateOfIncorporation"].ToString();
                    if (txtDateofEstablishmentofUnit.Text != "")
                    {
                        txtDateofEstablishmentofUnit.Enabled = false;
                    }

                    string TypeOfIndustry = dsnew.Tables[0].Rows[0]["TypeOfIndustry"].ToString();
                    if (TypeOfIndustry == "1")
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCP"].ToString();
                    }
                    else
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCPExp"].ToString();
                    }

                    lblActivityoftheUnit.InnerText = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();
                    lblTextileType.InnerText = dsnew.Tables[0].Rows[0]["TypeofTexttileText"].ToString();


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

                            btnRegisteredLandSaleLeaseTransferConversion.Enabled = false;
                            btnCertificateFromBank.Enabled = false;
                            btnApprovalofProjectReport.Enabled = false;
                            btnLayoutDemarcating.Enabled = false;
                            btnProjectCompletionCertificate.Enabled = false;
                            btnSaleInvoice.Enabled = false;
                            btnEvidencingTechnicalTextileUnit.Enabled = false;
                            btnFirstTimeClaimPARTA.Enabled = false;
                            btnSupportingDocuments.Enabled = false;
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
                ds = Gen.GenericFillDs("USP_GET_LANDCOSTSUBSIDY_Dtls", p);
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.ToString() != "" && ds.Tables[0].Rows.ToString() != null)
                {
                    txtDateofEstablishmentofUnit.Text = ds.Tables[0].Rows[0]["DateofEstablishmentofUnit"].ToString();
                    ddlUtilizationETPCETP.SelectedValue = ds.Tables[0].Rows[0]["UtilizationETPCETP"].ToString();
                    RbtnTexttileLocationTS.SelectedValue = ds.Tables[0].Rows[0]["TexttileLocationTS"].ToString();
                    string LandAllotmentInformation = ds.Tables[0].Rows[0]["LandAllotmentInformation"].ToString();
                    if (LandAllotmentInformation != "")
                    {
                        string[] TypeofInfrastructureVal = LandAllotmentInformation.Split(',');

                        foreach (string Value in TypeofInfrastructureVal)
                        {
                            int Index = chkLandAllotmentInformation.Items.IndexOf(chkLandAllotmentInformation.Items.FindByValue(Value));
                            chkLandAllotmentInformation.Items[Index].Selected = true;
                        }
                    }
                    txtTotalPlinthArea.Text = ds.Tables[0].Rows[0]["TotalPlinthArea"].ToString();
                    txtTotalExtentOfLandPurchased.Text = ds.Tables[0].Rows[0]["TotalExtentOfLandPurchased"].ToString();
                    txtRatePerAcre.Text = ds.Tables[0].Rows[0]["RatePerAcre"].ToString();
                    txtTotalInvestmentinLand.Text = ds.Tables[0].Rows[0]["TotalInvestmentinLand"].ToString();
                    txtAmountAvailed.Text = ds.Tables[0].Rows[0]["AmountAvailed"].ToString();
                    txtSource.Text = ds.Tables[0].Rows[0]["Source"].ToString();
                    txtDateAvailed.Text = ds.Tables[0].Rows[0]["DateAvailed"].ToString();
                    txtCurrentClaim.Text = ds.Tables[0].Rows[0]["CurrentClaim"].ToString();
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
                                if (Docid == "111001")
                                {
                                    objClsFileUpload.AssignPath(hyRegisteredLandSaleLeaseTransferConversion, Path);
                                }
                                else if (Docid == "111002")
                                {
                                    objClsFileUpload.AssignPath(hyCertificateFromBank, Path);
                                }
                                else if (Docid == "111003")
                                {
                                    objClsFileUpload.AssignPath(hyApprovalofProjectReport, Path);
                                }
                                else if (Docid == "111004")
                                {
                                    objClsFileUpload.AssignPath(hyLayoutDemarcating, Path);
                                }
                                else if (Docid == "111005")
                                {
                                    objClsFileUpload.AssignPath(hyProjectCompletionCertificate, Path);
                                }
                                else if (Docid == "111006")
                                {
                                    objClsFileUpload.AssignPath(hySaleInvoice, Path);
                                }
                                else if (Docid == "111007")
                                {
                                    objClsFileUpload.AssignPath(hyEvidencingTechnicalTextileUnit, Path);
                                }
                                else if (Docid == "111008")
                                {
                                    objClsFileUpload.AssignPath(hyFirstTimeClaimPARTA, Path);
                                }
                                else if (Docid == "111009")
                                {
                                    objClsFileUpload.AssignPath(hySupportingDocuments, Path);
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

        public string GeneralInformationcheck()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (txtDateofEstablishmentofUnit.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Date Of Incorporation of Unit \\n";
                slno = slno + 1;
            }
            if (ddlUtilizationETPCETP.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Category/Defination of the Unit \\n";
                slno = slno + 1;
            }
            int selectedCount = chkLandAllotmentInformation.Items.Cast<ListItem>().Count(li => li.Selected);
            if (selectedCount == 0)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select at Least One Land Allotment Information \\n";
                slno = slno + 1;
            }

            if (txtTotalPlinthArea.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Total Plinth Area of Factory Building (In Square Meters) \\n";
                slno = slno + 1;
            }
            if (txtTotalExtentOfLandPurchased.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Total Extent Of Land Purchased (In Acres) \\n";
                slno = slno + 1;
            }

            if (txtRatePerAcre.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Rate Per Acre (In Rs) \\n";
                slno = slno + 1;
            }
            if (txtTotalInvestmentinLand.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Total Investment in Land (In Rs) \\n";
                slno = slno + 1;
            }
            if (txtCurrentClaim.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Reimbursement Amount Claimed (In Rs) \\n";
                slno = slno + 1;
            }
            return ErrorMsg;
        }

        protected void BtnNext_Click(object sender, EventArgs e)
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
                string errormsgAttach = ObjCAFClass.ValidateMandatoryAttachments(Session["IncentiveID"].ToString(), "11");
                if (errormsgAttach.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsgAttach + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                LandCostSubsidy objLandCostSubsidy = new LandCostSubsidy();

                objLandCostSubsidy.IncentiveId = Session["IncentiveID"].ToString();
                objLandCostSubsidy.CreatedBy = ObjLoginNewvo.uid;

                objLandCostSubsidy.DateofEstablishmentofUnit = GetFromatedDateDDMMYYYY(txtDateofEstablishmentofUnit.Text.Trim().TrimStart());


                objLandCostSubsidy.UtilizationETPCETP = ddlUtilizationETPCETP.SelectedValue;
                objLandCostSubsidy.TexttileLocationTS = RbtnTexttileLocationTS.SelectedValue;
                string Typeofinfra = "";
                foreach (ListItem li in chkLandAllotmentInformation.Items)
                {
                    if (li.Selected)
                    {
                        if (Typeofinfra == "")
                        {
                            Typeofinfra = li.Value;
                        }
                        else
                        {
                            Typeofinfra = Typeofinfra + "," + li.Value;
                        }
                    }
                }
                objLandCostSubsidy.LandAllotmentInformation = Typeofinfra;
                objLandCostSubsidy.TotalPlinthArea = GetDecimalNullValue(txtTotalPlinthArea.Text.Trim().TrimStart());
                objLandCostSubsidy.TotalExtentOfLandPurchased = GetDecimalNullValue(txtTotalExtentOfLandPurchased.Text.Trim().TrimStart());
                objLandCostSubsidy.RatePerAcre = GetDecimalNullValue(txtRatePerAcre.Text.Trim().TrimStart());
                objLandCostSubsidy.TotalInvestmentinLand = GetDecimalNullValue(txtTotalInvestmentinLand.Text.Trim().TrimStart());
                objLandCostSubsidy.AmountAvailed = GetDecimalNullValue(txtAmountAvailed.Text.Trim().TrimStart());
                objLandCostSubsidy.Source = txtSource.Text.Trim().TrimStart();
                objLandCostSubsidy.DateAvailed = GetFromatedDateDDMMYYYY(txtDateAvailed.Text.Trim().TrimStart());

                objLandCostSubsidy.CurrentClaim = GetDecimalNullValue(txtCurrentClaim.Text.Trim().TrimStart());

                string Validstatus = ObjCAFClass.InsertingOfLandCostDtls(objLandCostSubsidy);

                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    Response.Redirect("frmRentalSubsidy.aspx?next=" + "N");
                }
            }
        }

        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmProductDevelopment.aspx?Previous=" + "P");
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
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        protected void btnRegisteredLandSaleLeaseTransferConversion_Click(object sender, EventArgs e)
        {
            if (fuRegisteredLandSaleLeaseTransferConversion.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuRegisteredLandSaleLeaseTransferConversion);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuRegisteredLandSaleLeaseTransferConversion);
                if (Mimetype == "application/pdf")
                {

                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuRegisteredLandSaleLeaseTransferConversion, hyRegisteredLandSaleLeaseTransferConversion, "RegisteredLandSaleLeaseTransferConversion", Session["IncentiveID"].ToString(), "11", "111001", Session["uid"].ToString(), "USER");

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

        protected void btnCertificateFromBank_Click(object sender, EventArgs e)
        {
            if (fuCertificateFromBank.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuCertificateFromBank);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuCertificateFromBank);
                if (Mimetype == "application/pdf")
                {

                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuCertificateFromBank, hyCertificateFromBank, "CertificateFromBank", Session["IncentiveID"].ToString(), "11", "111002", Session["uid"].ToString(), "USER");

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

        protected void btnApprovalofProjectReport_Click(object sender, EventArgs e)
        {
            if (fuApprovalofProjectReport.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuApprovalofProjectReport);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuApprovalofProjectReport);
                if (Mimetype == "application/pdf")
                {

                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuApprovalofProjectReport, hyApprovalofProjectReport, "ApprovalofProjectReport", Session["IncentiveID"].ToString(), "11", "111003", Session["uid"].ToString(), "USER");

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

        protected void btnLayoutDemarcating_Click(object sender, EventArgs e)
        {
            if (fuLayoutDemarcating.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuLayoutDemarcating);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuLayoutDemarcating);
                if (Mimetype == "application/pdf")
                {

                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLayoutDemarcating, hyLayoutDemarcating, "LayoutDemarcating", Session["IncentiveID"].ToString(), "11", "111004", Session["uid"].ToString(), "USER");

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

        protected void btnProjectCompletionCertificate_Click(object sender, EventArgs e)
        {
            if (fuProjectCompletionCertificate.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuProjectCompletionCertificate);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuProjectCompletionCertificate);
                if (Mimetype == "application/pdf")
                {

                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuProjectCompletionCertificate, hyProjectCompletionCertificate, "ProjectCompletionCertificate", Session["IncentiveID"].ToString(), "11", "111005", Session["uid"].ToString(), "USER");

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

        protected void btnSaleInvoice_Click(object sender, EventArgs e)
        {
            if (fuSaleInvoice.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuSaleInvoice);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuSaleInvoice);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuSaleInvoice, hySaleInvoice, "SaleInvoice", Session["IncentiveID"].ToString(), "11", "111006", Session["uid"].ToString(), "USER");

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

        protected void btnEvidencingTechnicalTextileUnit_Click(object sender, EventArgs e)
        {
            if (fuEvidencingTechnicalTextileUnit.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuEvidencingTechnicalTextileUnit);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuEvidencingTechnicalTextileUnit);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuEvidencingTechnicalTextileUnit, hyEvidencingTechnicalTextileUnit, "EvidencingTechnicalTextileUnit", Session["IncentiveID"].ToString(), "11", "111007", Session["uid"].ToString(), "USER");

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

        protected void btnFirstTimeClaimPARTA_Click(object sender, EventArgs e)
        {
            if (fuFirstTimeClaimPARTA.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuFirstTimeClaimPARTA);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuFirstTimeClaimPARTA);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuFirstTimeClaimPARTA, hyFirstTimeClaimPARTA, "FirstTimeClaimPARTA", Session["IncentiveID"].ToString(), "11", "111008", Session["uid"].ToString(), "USER");

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

        protected void btnSupportingDocuments_Click(object sender, EventArgs e)
        {
            if (fuSupportingDocuments.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuSupportingDocuments);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuSupportingDocuments);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuSupportingDocuments, hySupportingDocuments, "SupportingDocuments", Session["IncentiveID"].ToString(), "11", "111009", Session["uid"].ToString(), "USER");

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
    }
}