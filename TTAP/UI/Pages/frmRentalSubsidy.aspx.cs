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
    public partial class frmRentalSubsidy : System.Web.UI.Page
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
                            DataRow[] drs1 = ds.Tables[0].Select("IncentiveID = " + 12);
                            if (drs1.Length > 0)
                            {
                                BindFinancialYears(ddlFinYear, "10", Session["IncentiveID"].ToString());
                                BindFinancialYears(ddlClaimFinYear, "5", Session["IncentiveID"].ToString());

                                DataSet dsnew = new DataSet();
                                GetRentalSubsidyDetails(userid, IncentveID);
                                BindRentalReimbursementAvailedDtls(Session["IncentiveID"].ToString());
                                BindRentalReimbursementCurrentClaimDtls(Session["IncentiveID"].ToString());
                            }
                            else
                            {
                                if (Request.QueryString[0].ToString() == "N")
                                {
                                    Response.Redirect("frmOtherInfrastructure.aspx?next=" + "N");
                                }
                                else
                                {
                                    Response.Redirect("frmLandCostSubsidy.aspx?Previous=" + "P");
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
        public void GetRentalSubsidyDetails(string uid, string incentiveid)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetapplicationDtls(uid, incentiveid);
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
                    txtDateofEstablishmentofUnit.Text = dsnew.Tables[0].Rows[0]["DateOfIncorporation"].ToString();
                    if (txtDateofEstablishmentofUnit.Text != "")
                    {
                        txtDateofEstablishmentofUnit.Enabled = false;
                        txtDateofEstablishmentofUnit.ReadOnly = true;
                    }
                    lblCategoryofUnit.InnerText = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    lblActivityoftheUnit.InnerText = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();

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

                            DivSGSTReimbursement.Visible = false;
                            grdSGSTReimbursement.Columns[5].Visible = false;
                            grdSGSTReimbursement.Columns[4].Visible = false;

                            DivSGSTReimbursementClaim.Visible = false;
                            grdSGSTReimbursementClaim.Columns[5].Visible = false;
                            grdSGSTReimbursementClaim.Columns[4].Visible = false;

                            btnRentagrement.Enabled = false;
                            btnBankCertificate.Enabled = false;
                            btnPowerCertificate.Enabled = false;
                            btnPaymentProof.Enabled = false;
                            btnRentedLayout.Enabled = false;
                            btnProofClaim.Enabled = false;
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
                p[1].Value = incentiveid;

                ds = Gen.GenericFillDs("USP_GET_Rental_Lease_Subsidy_Built_Space_Dtls", p);


                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0] != null && ds.Tables[0].ToString() != "")
                {
                    if (ds.Tables[0].Rows[0]["TypeOfUse"].ToString() != "")
                    {
                        ddlTypeOfUse.SelectedValue = ds.Tables[0].Rows[0]["TypeOfUse"].ToString();
                        ddlTypeOfUse_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    txtProductionPersonsTrained.Text = ds.Tables[0].Rows[0]["ProductionPersonsTrained"].ToString();
                    txtDateofEstablishmentofUnit.Text = ds.Tables[0].Rows[0]["DateofEstablishmentofUnit"].ToString();
                    RbtnTextileOrApparelArea.SelectedValue = ds.Tables[0].Rows[0]["TextileOrApparelArea"].ToString();


                    string TypeofInfrastructure = ds.Tables[0].Rows[0]["RentalInformationType"].ToString();
                    if (TypeofInfrastructure != "")
                    {
                        string[] TypeofInfrastructureVal = TypeofInfrastructure.Split(',');

                        foreach (string Value in TypeofInfrastructureVal)
                        {
                            int Index = chkRentalInformationType.Items.IndexOf(chkRentalInformationType.Items.FindByValue(Value));
                            chkRentalInformationType.Items[Index].Selected = true;
                        }
                    }

                    RbtnRentalLeasedeed.SelectedValue = ds.Tables[0].Rows[0]["RentalLeaseReg"].ToString();
                    RbtnRentalLeasedeed_SelectedIndexChanged(this, EventArgs.Empty);

                    txtDeedNumber.Text = ds.Tables[0].Rows[0]["DeedNumber"].ToString();
                    txtDeedDate.Text = ds.Tables[0].Rows[0]["Deeddate"].ToString();

                    chkRentalInformationType_SelectedIndexChanged(this, EventArgs.Empty);
                    txtOtherLeasingArrangement.Text = ds.Tables[0].Rows[0]["OtherLeasingArrangement"].ToString();
                    txtBuiltUpSpaceOccupied.Text = ds.Tables[0].Rows[0]["BuiltUpSpaceOccupied"].ToString();
                    txtRentLeaseAmountPerSqMtr.Text = ds.Tables[0].Rows[0]["RentLeaseAmountPerSqMtr"].ToString();
                    txtTotalMonthlyNetRent.Text = ds.Tables[0].Rows[0]["TotalMonthlyNetRent"].ToString();
                    txtPeriodofLeaseFromDate.Text = ds.Tables[0].Rows[0]["PeriodofLeaseFromDate"].ToString();
                    txtPeriodofLeaseToDate.Text = ds.Tables[0].Rows[0]["PeriodofLeaseToDate"].ToString();
                    RbtnIsAnyothersubsidy.SelectedValue = ds.Tables[0].Rows[0]["IsAnyothersubsidy"].ToString();
                    RbtnIsAnyothersubsidy_SelectedIndexChanged(this, EventArgs.Empty);
                    txtSubsidySource.Text = ds.Tables[0].Rows[0]["SubsidySource"].ToString();
                    txtSubsidySourceAmount.Text = ds.Tables[0].Rows[0]["SubsidySourceAmount"].ToString();
                    txtClaimApplicationsubmitted.Text = ds.Tables[0].Rows[0]["ClaimApplicationsubmitted"].ToString();
                    //txtFromDateOfClaimAmount.Text = ds.Tables[0].Rows[0]["FromDateOfClaimAmount"].ToString();
                    //txtToDateOfClaimAmount.Text = ds.Tables[0].Rows[0]["ToDateOfClaimAmount"].ToString();

                    txtReimbursementAmountClaimed.Text = ds.Tables[0].Rows[0]["ReimbursementAmountClaimed"].ToString();
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
                                if (Docid == "121001")
                                {
                                    objClsFileUpload.AssignPath(hyRentagrement, Path);
                                }
                                else if (Docid == "121002")
                                {
                                    objClsFileUpload.AssignPath(hyPowerCertificate, Path);
                                }
                                else if (Docid == "121003")
                                {
                                    objClsFileUpload.AssignPath(hyPaymentProof, Path);
                                }
                                else if (Docid == "121004")
                                {
                                    objClsFileUpload.AssignPath(hyRentedLayout, Path);
                                }
                                else if (Docid == "121005")
                                {
                                    objClsFileUpload.AssignPath(hyProofClaim, Path);
                                }
                                else if (Docid == "121006")
                                {
                                    objClsFileUpload.AssignPath(hyBankCertificate, Path);
                                }
                                else if (Docid == "121007")
                                {
                                    objClsFileUpload.AssignPath(hyRentalCertified, Path);
                                }
                                else if (Docid == "121008")
                                {
                                    objClsFileUpload.AssignPath(hyProductionSalesCA, Path);
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
            if (ddlTypeOfUse.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Type Of Use \\n";
                slno = slno + 1;
            }
            else
            {
                if (txtProductionPersonsTrained.Text.Trim().TrimStart() == "" && ddlTypeOfUse.SelectedValue == "1")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Annual Production In Rs. \\n";
                    slno = slno + 1;
                }
                else if (txtProductionPersonsTrained.Text.Trim().TrimStart() == "" && ddlTypeOfUse.SelectedValue == "2")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Persons Trained \\n";
                    slno = slno + 1;
                }
            }

            if (txtDateofEstablishmentofUnit.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Date Of Incorporation of Unit \\n";
                slno = slno + 1;
            }
            if (RbtnTextileOrApparelArea.SelectedIndex == -1)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Whether the unit is located in the Textile /Apparel Park declared by the Government of Telangana \\n";
                slno = slno + 1;
            }
            if (RbtnRentalLeasedeed.SelectedIndex == -1)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Whether the Rental / Lease deed is registered or Not \\n";
                slno = slno + 1;
            }
            else if (RbtnRentalLeasedeed.SelectedValue == "Y")
            {
                if (txtDeedNumber.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Rental / Lease deed Number \\n";
                    slno = slno + 1;
                }
                else if (txtDeedDate.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Date of Deed \\n";
                    slno = slno + 1;
                }
            }
            else if (RbtnRentalLeasedeed.SelectedValue == "N")
            {
                ErrorMsg = ErrorMsg + slno + ". Dear Entrepreneur, You are not Eligible to apply this Subsidy.\\n";
                slno = slno + 1;
            }

            int selectedCount = chkRentalInformationType.Items.Cast<ListItem>().Count(li => li.Selected);
            if (selectedCount == 0)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Rental Information \\n";
                slno = slno + 1;
            }
            if (divotherLeasingArrangement.Visible && txtOtherLeasingArrangement.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Other Leasing Arrangement Details \\n";
                slno = slno + 1;
            }
            if (txtBuiltUpSpaceOccupied.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Built up space occupied by the Industry/Enterprise in the Textile /Apparel park ( in Sq Meters) \\n";
                slno = slno + 1;
            }

            if (txtRentLeaseAmountPerSqMtr.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Rent/Lease Amount (per Sq Meter) (In Rupees) \\n";
                slno = slno + 1;
            }
            if (txtTotalMonthlyNetRent.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Total Monthly net rent (In Rupees) \\n";
                slno = slno + 1;
            }
            if (txtPeriodofLeaseFromDate.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select  Lease From Date  \\n";
                slno = slno + 1;
            }
            else
            {
                DateTime PeriodofLeaseFromDate = Convert.ToDateTime(GetFromatedDateDDMMYYYY(txtPeriodofLeaseFromDate.Text.Trim()));
                DateTime Date1 = Convert.ToDateTime("2017/08/18");
                if (PeriodofLeaseFromDate < Date1)
                {
                    ErrorMsg = ErrorMsg + slno + ". Date of Lease(Lease From Date) Should be on or after August of 18th 2017\\n";
                    slno = slno + 1;
                }
            }
            if (txtPeriodofLeaseToDate.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select  Lease To Date \\n";
                slno = slno + 1;
            }
            if (RbtnIsAnyothersubsidy.SelectedValue == "Y")
            {
                if (txtSubsidySource.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Subsidy Source \\n";
                    slno = slno + 1;
                }
                if (txtSubsidySourceAmount.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Subsidy Availed Amount (In Rupees) \\n";
                    slno = slno + 1;
                }
            }
            //if (txtFromDateOfClaimAmount.Text.Trim().TrimStart() == "")
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Select From Date of claim amount \\n";
            //    slno = slno + 1;
            //}
            //if (txtToDateOfClaimAmount.Text.Trim().TrimStart() == "")
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Select To Date of claim amount\\n";
            //    slno = slno + 1;
            //}
            if (grdSGSTReimbursementClaim.Rows.Count < 1)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Add Reimbursement Amount claimed by the Industry/Enterprise (Period of claim amount)\\n";
                slno = slno + 1;
            }
            if (txtReimbursementAmountClaimed.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Reimbursement Amount claimed by the Industry/Enterprise (In Rs)\\n";
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

        protected void btnRentagrement_Click(object sender, EventArgs e)
        {
            if (fuRentagrement.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuRentagrement);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuRentagrement);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuRentagrement, hyRentagrement, "Rentleaseagreement", Session["IncentiveID"].ToString(), "12", "121001", Session["uid"].ToString(), "USER");

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

        protected void btnPowerCertificate_Click(object sender, EventArgs e)
        {
            if (fuPowerCertificate.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuPowerCertificate);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuPowerCertificate);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuPowerCertificate, hyPowerCertificate, "PowerreleasecertificateDISCOM", Session["IncentiveID"].ToString(), "12", "121002", Session["uid"].ToString(), "USER");

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
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuPaymentProof, hyPaymentProof, "PowerBillPaymentProofReceiptsDISCOM", Session["IncentiveID"].ToString(), "12", "121003", Session["uid"].ToString(), "USER");

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

        protected void btnRentedLayout_Click(object sender, EventArgs e)
        {
            if (fuRentedLayout.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuRentedLayout);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuRentedLayout);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuRentedLayout, hyRentedLayout, "Layoutdemarcatingrentedleasedbuiltupspaceoccupied", Session["IncentiveID"].ToString(), "12", "121004", Session["uid"].ToString(), "USER");

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

        protected void btnProofClaim_Click(object sender, EventArgs e)
        {
            if (fuProofClaim.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuProofClaim);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuProofClaim);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuProofClaim, hyProofClaim, "Anyothervaliddocumentssubstantiateproofclaimamount", Session["IncentiveID"].ToString(), "12", "121005", Session["uid"].ToString(), "USER");

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

        protected void btnBankCertificate_Click(object sender, EventArgs e)
        {
            if (fluBankCertificate.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fluBankCertificate);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fluBankCertificate);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fluBankCertificate, hyBankCertificate, "CertificatefromBankFinancialInstitutions", Session["IncentiveID"].ToString(), "12", "121006", Session["uid"].ToString(), "USER");

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
                string errormsgAttach = ObjCAFClass.ValidateMandatoryAttachments(Session["IncentiveID"].ToString(), "12");
                if (errormsgAttach.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsgAttach + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }


                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                RentalSubsify ObjProduct = new RentalSubsify();

                ObjProduct.IncentiveId = Session["IncentiveID"].ToString();
                ObjProduct.CreatedBy = ObjLoginNewvo.uid;

                ObjProduct.TypeOfUse = ddlTypeOfUse.SelectedValue;
                ObjProduct.ProductionPersonsTrained = txtProductionPersonsTrained.Text.Trim().TrimStart();
                ObjProduct.DateofEstablishmentofUnit = GetFromatedDateDDMMYYYY(txtDateofEstablishmentofUnit.Text.Trim().TrimStart());
                ObjProduct.TextileOrApparelArea = RbtnTextileOrApparelArea.SelectedValue;

                string Typeofinfra = "";
                foreach (ListItem li in chkRentalInformationType.Items)
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
                ObjProduct.RentalInformationType = Typeofinfra;
                ObjProduct.OtherLeasingArrangement = txtOtherLeasingArrangement.Text.Trim().TrimStart();
                ObjProduct.BuiltUpSpaceOccupied = GetDecimalNullValue(txtBuiltUpSpaceOccupied.Text.Trim().TrimStart());
                ObjProduct.RentLeaseAmountPerSqMtr = GetDecimalNullValue(txtRentLeaseAmountPerSqMtr.Text.Trim().TrimStart());
                ObjProduct.TotalMonthlyNetRent = GetDecimalNullValue(txtTotalMonthlyNetRent.Text.Trim().TrimStart());
                ObjProduct.PeriodofLeaseFromDate = GetFromatedDateDDMMYYYY(txtPeriodofLeaseFromDate.Text.Trim().TrimStart());
                ObjProduct.PeriodofLeaseToDate = GetFromatedDateDDMMYYYY(txtPeriodofLeaseToDate.Text.Trim().TrimStart());
                ObjProduct.IsAnyothersubsidy = RbtnIsAnyothersubsidy.SelectedValue;
                ObjProduct.SubsidySource = txtSubsidySource.Text.Trim().TrimStart();
                ObjProduct.SubsidySourceAmount = GetDecimalNullValue(txtSubsidySourceAmount.Text.Trim().TrimStart());
                ObjProduct.ClaimApplicationsubmitted = txtClaimApplicationsubmitted.Text.Trim().TrimStart();
                //ObjProduct.FromDateOfClaimAmount = GetFromatedDateDDMMYYYY(txtFromDateOfClaimAmount.Text.Trim().TrimStart());
                //ObjProduct.ToDateOfClaimAmount = GetFromatedDateDDMMYYYY(txtToDateOfClaimAmount.Text.Trim().TrimStart());
                ObjProduct.ReimbursementAmountClaimed = GetDecimalNullValue(txtReimbursementAmountClaimed.Text.Trim().TrimStart());

                ObjProduct.RentalLeaseReg = RbtnRentalLeasedeed.SelectedValue;
                ObjProduct.DeedNumber = txtDeedNumber.Text.Trim().TrimStart();
                ObjProduct.Deeddate = GetFromatedDateDDMMYYYY(txtDeedDate.Text.Trim().TrimStart());

                string Validstatus = ObjCAFClass.InsertingOfRentalLeaseSubsidyBuiltSpaceDtls(ObjProduct);

                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    Response.Redirect("frmOtherInfrastructure.aspx?next=" + "N");
                }
            }



        }

        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmLandCostSubsidy.aspx?Previous=" + "P");
        }

        // Add Multiple

        public DataSet GetFinancialYearIncentives(string Count, string incentiveid)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@YEARS",SqlDbType.VarChar),
                new SqlParameter("@incentiveid",SqlDbType.VarChar)
           };
            pp[0].Value = Count;
            pp[1].Value = incentiveid;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_FINANCIALYEARS", pp);
            return Dsnew;
        }
        private void BindFinancialYears(DropDownList ddl, string Count, string incentiveid)
        {
            comFunctions cmf = new comFunctions();
            General Gen = new General();
            DataSet dsYears = new DataSet();
            ddl.Items.Clear();
            dsYears = GetFinancialYearIncentives(Count, incentiveid);
            if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = dsYears.Tables[0];
                ddl.DataTextField = "FinancialYear";
                ddl.DataValueField = "SlNo";
                ddl.DataBind();
            }
            AddSelect(ddl);
        }
        public void AddSelect(DropDownList ddl)
        {
            try
            {
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }
        }

        public string ValidateDtls()
        {
            int slno = 1;
            string ErrorMsg = "";


            if (ddlFinYear.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Financial Year \\n";
                slno = slno + 1;
            }
            if (ddlFin1stOr2ndHalfyear.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Financial Half Year \\n";
                slno = slno + 1;
            }

            if (txtAmountPaid.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Total Amount(In Rupees) \\n";
                slno = slno + 1;
            }


            return ErrorMsg;
        }
        protected void btnSGSTReimbursementAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["Rental_SubsidyAvailed_ID"] == null)
                {
                    ViewState["Rental_SubsidyAvailed_ID"] = "0";
                }

                string errormsg = ValidateDtls();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    EnergyConsumedBO objEnergyConsumedBO = new EnergyConsumedBO();

                    objEnergyConsumedBO.EnergyConsumed_ID = ViewState["Rental_SubsidyAvailed_ID"].ToString();
                    objEnergyConsumedBO.TransType = "INS";
                    objEnergyConsumedBO.IncentiveId = Session["IncentiveID"].ToString();
                    objEnergyConsumedBO.Created_by = ObjLoginNewvo.uid;

                    objEnergyConsumedBO.FinancialYear = ddlFinYear.SelectedValue;
                    objEnergyConsumedBO.FinancialYearText = ddlFinYear.SelectedItem.Text;

                    objEnergyConsumedBO.TypeOfFinancialYear = ddlFin1stOr2ndHalfyear.SelectedValue;
                    objEnergyConsumedBO.TypeOfFinancialYearText = ddlFin1stOr2ndHalfyear.SelectedItem.Text;

                    objEnergyConsumedBO.TotalAmount = (txtAmountPaid.Text.Trim().TrimStart() != "") ? txtAmountPaid.Text.Trim().TrimStart() : null;

                    string Validstatus = ObjCAFClass.InsertRentalSubsidyReimbursementAvailedDetails(objEnergyConsumedBO);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        btnSGSTReimbursementAdd.Text = "Add New";
                        ViewState["Rental_SubsidyAvailed_ID"] = "0";

                        ddlFinYear.SelectedValue = "0";
                        ddlFin1stOr2ndHalfyear.SelectedValue = "0";
                        txtAmountPaid.Text = "";

                        BindRentalReimbursementAvailedDtls(Session["IncentiveID"].ToString());
                        lblmsg.Text = "Saved Successfully";
                        Failure.Visible = false;
                        success.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        protected void grdSGSTReimbursement_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                ddlFinYear.SelectedValue = ((Label)(gr.FindControl("lblEnergyFinancialYearID"))).Text;
                ddlFin1stOr2ndHalfyear.SelectedValue = ((Label)(gr.FindControl("lblTypeOfFinancialYear"))).Text;

                txtAmountPaid.Text = ((Label)(gr.FindControl("lblEnergyConsumedAmountPaid"))).Text;

                ViewState["Rental_SubsidyAvailed_ID"] = ((Label)(gr.FindControl("lblEnergyconsumedID"))).Text;
                btnSGSTReimbursementAdd.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];


                EnergyConsumedBO objEnergyConsumedBO = new EnergyConsumedBO();

                objEnergyConsumedBO.EnergyConsumed_ID = ((Label)(gr.FindControl("lblEnergyconsumedID"))).Text;
                objEnergyConsumedBO.TransType = "DLT";
                objEnergyConsumedBO.IncentiveId = Session["IncentiveID"].ToString();
                objEnergyConsumedBO.Created_by = ObjLoginNewvo.uid;


                string Validstatus = ObjCAFClass.InsertRentalSubsidyReimbursementAvailedDetails(objEnergyConsumedBO);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnSGSTReimbursementAdd.Text = "Add New";
                    ViewState["Rental_SubsidyAvailed_ID"] = "0";

                    ddlFinYear.SelectedValue = "0";
                    ddlFin1stOr2ndHalfyear.SelectedValue = "0";
                    txtAmountPaid.Text = "";

                    BindRentalReimbursementAvailedDtls(Session["IncentiveID"].ToString());

                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }

        protected void BindRentalReimbursementAvailedDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetRentalReimbursementAvailedDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    grdSGSTReimbursement.DataSource = dsnew.Tables[0];
                    grdSGSTReimbursement.DataBind();
                }
                else
                {
                    grdSGSTReimbursement.DataSource = null;
                    grdSGSTReimbursement.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindRentalReimbursementCurrentClaimDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetRentalReimbursementCurrentClaimDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    grdSGSTReimbursementClaim.DataSource = dsnew.Tables[0];
                    grdSGSTReimbursementClaim.DataBind();

                    decimal TotalClaimAmount = 0;
                    foreach (GridViewRow gvrow in grdSGSTReimbursementClaim.Rows)
                    {
                        decimal Value = Convert.ToDecimal(((Label)gvrow.FindControl("lblEnergyConsumedAmountPaid")).Text);
                        TotalClaimAmount = TotalClaimAmount + Value;
                    }

                    txtReimbursementAmountClaimed.Text = TotalClaimAmount.ToString();
                }
                else
                {
                    grdSGSTReimbursementClaim.DataSource = null;
                    grdSGSTReimbursementClaim.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetRentalReimbursementCurrentClaimDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_RentalSubsidy_Reimbursement_CurrentClaim", pp);
            return Dsnew;
        }
        public DataSet GetRentalReimbursementAvailedDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_RentalSubsidy_Reimbursement_AvailedDTLS", pp);
            return Dsnew;
        }

        protected void chkRentalInformationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            divotherLeasingArrangement.Visible = false;
            foreach (ListItem li in chkRentalInformationType.Items)
            {
                if (li.Selected)
                {
                    if (li.Value == "2")
                    {
                        divotherLeasingArrangement.Visible = true;
                    }
                }
            }
        }

        protected void RbtnIsAnyothersubsidy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RbtnIsAnyothersubsidy.SelectedValue == "Y")
            {
                divSubsidy.Visible = true;
                divAmount.Visible = true;
            }
            else
            {
                divSubsidy.Visible = false;
                divAmount.Visible = false;
            }
        }

        protected void ddlTypeOfUse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTypeOfUse.SelectedValue == "1")
            {
                lblProductionPersonsTrained.InnerHtml = "Annual Production in Rs.";
            }
            else if (ddlTypeOfUse.SelectedValue == "2")
            {
                lblProductionPersonsTrained.InnerHtml = "Persons Trained";
            }
            else
            {
                lblProductionPersonsTrained.InnerHtml = "Annual Production in Rs./Persons Trained";
            }
        }

        protected void btnRentalCertified_Click(object sender, EventArgs e)
        {
            if (fuRentalCertified.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuRentalCertified);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuRentalCertified);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuRentalCertified, hyRentalCertified, "RentalCertified", Session["IncentiveID"].ToString(), "12", "121007", Session["uid"].ToString(), "USER");

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

        protected void btnProductionSalesCA_Click(object sender, EventArgs e)
        {
            if (fuProductionSalesCA.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuProductionSalesCA);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuProductionSalesCA);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuProductionSalesCA, hyProductionSalesCA, "ProductionSalesDetailsCharteredAccountant", Session["IncentiveID"].ToString(), "12", "121008", Session["uid"].ToString(), "USER");

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

        protected void RbtnRentalLeasedeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RbtnRentalLeasedeed.SelectedValue == "Y")
            {
                RentalLeasedeed1.Visible = true;
                RentalLeasedeed2.Visible = true;
            }
            else
            {
                RentalLeasedeed1.Visible = false;
                RentalLeasedeed2.Visible = false;
            }
        }

        public string ValidateDtlsClaim()
        {
            int slno = 1;
            string ErrorMsg = "";


            if (ddlClaimFinYear.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Financial Year \\n";
                slno = slno + 1;
            }
            if (ddlClaimFin1stOr2ndHalfyear.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Financial Half Year \\n";
                slno = slno + 1;
            }

            if (txtClaimAmountPaid.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Total Amount(In Rupees) \\n";
                slno = slno + 1;
            }


            return ErrorMsg;
        }
        protected void btnSGSTReimbursementClaimAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["Rental_SubsidyAvailedClaim_ID"] == null)
                {
                    ViewState["Rental_SubsidyAvailedClaim_ID"] = "0";
                }

                string errormsg = ValidateDtlsClaim();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    EnergyConsumedBO objEnergyConsumedBO = new EnergyConsumedBO();

                    objEnergyConsumedBO.EnergyConsumed_ID = ViewState["Rental_SubsidyAvailedClaim_ID"].ToString();
                    objEnergyConsumedBO.TransType = "INS";
                    objEnergyConsumedBO.IncentiveId = Session["IncentiveID"].ToString();
                    objEnergyConsumedBO.Created_by = ObjLoginNewvo.uid;

                    objEnergyConsumedBO.FinancialYear = ddlClaimFinYear.SelectedValue;
                    objEnergyConsumedBO.FinancialYearText = ddlClaimFinYear.SelectedItem.Text;

                    objEnergyConsumedBO.TypeOfFinancialYear = ddlClaimFin1stOr2ndHalfyear.SelectedValue;
                    objEnergyConsumedBO.TypeOfFinancialYearText = ddlClaimFin1stOr2ndHalfyear.SelectedItem.Text;

                    objEnergyConsumedBO.TotalAmount = (txtClaimAmountPaid.Text.Trim().TrimStart() != "") ? txtClaimAmountPaid.Text.Trim().TrimStart() : null;

                    string Validstatus = ObjCAFClass.InsertRentalSubsidyReimbursementCurrentClaimDetails(objEnergyConsumedBO);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        btnSGSTReimbursementClaimAdd.Text = "Add New";
                        ViewState["Rental_SubsidyAvailedClaim_ID"] = "0";

                        ddlClaimFinYear.SelectedValue = "0";
                        ddlClaimFin1stOr2ndHalfyear.SelectedValue = "0";
                        txtClaimAmountPaid.Text = "";

                        BindRentalReimbursementCurrentClaimDtls(Session["IncentiveID"].ToString());
                        lblmsg.Text = "Saved Successfully";
                        Failure.Visible = false;
                        success.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        protected void grdSGSTReimbursementClaim_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                ddlClaimFinYear.SelectedValue = ((Label)(gr.FindControl("lblEnergyFinancialYearID"))).Text;
                ddlClaimFin1stOr2ndHalfyear.SelectedValue = ((Label)(gr.FindControl("lblTypeOfFinancialYear"))).Text;

                txtClaimAmountPaid.Text = ((Label)(gr.FindControl("lblEnergyConsumedAmountPaid"))).Text;

                ViewState["Rental_SubsidyAvailedClaim_ID"] = ((Label)(gr.FindControl("lblEnergyconsumedID"))).Text;
                btnSGSTReimbursementClaimAdd.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];


                EnergyConsumedBO objEnergyConsumedBO = new EnergyConsumedBO();

                objEnergyConsumedBO.EnergyConsumed_ID = ((Label)(gr.FindControl("lblEnergyconsumedID"))).Text;
                objEnergyConsumedBO.TransType = "DLT";
                objEnergyConsumedBO.IncentiveId = Session["IncentiveID"].ToString();
                objEnergyConsumedBO.Created_by = ObjLoginNewvo.uid;


                string Validstatus = ObjCAFClass.InsertRentalSubsidyReimbursementCurrentClaimDetails(objEnergyConsumedBO);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnSGSTReimbursementClaimAdd.Text = "Add New";
                    ViewState["Rental_SubsidyAvailedClaim_ID"] = "0";

                    ddlClaimFinYear.SelectedValue = "0";
                    ddlClaimFin1stOr2ndHalfyear.SelectedValue = "0";
                    txtClaimAmountPaid.Text = "";

                    BindRentalReimbursementCurrentClaimDtls(Session["IncentiveID"].ToString());

                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }
    }
}