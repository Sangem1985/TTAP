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
using System.Xml.Linq;

namespace TTAP.UI.Pages
{
    public partial class PowerSubsidyAppraisalNote : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        CAFClass ObjCAFClass = new CAFClass();
        AppraisalClass objappraisalClass = new AppraisalClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
            ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

            try
            {
                if (Session["ObjLoginvo"] != null)
                {
                    if (!IsPostBack)
                    {
                        string incentiveid = "";
                        ViewState["UID"] = ObjLoginNewvo.uid;
                        if (Request.QueryString["IncentiveID"] != null)
                        {
                            incentiveid = Request.QueryString["IncentiveID"].ToString();
                        }
                        txtIncID.Text = incentiveid;
                        BindBesicdata(incentiveid, "4", "");
                        GetClaimPeriod(incentiveid, "4");
                        rdbTypeofTextile_SelectedIndexChanged(this, EventArgs.Empty); ;
                        DataSet dsnew1 = new DataSet();
                    }
                }
                else
                {
                    Response.Redirect("~/LoginReg.aspx");
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void BindBesicdata(string IncentiveID, string SubIncentiveId, string DistrictID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = objappraisalClass.GetapplicationDtls("0", IncentiveID);
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    lblUnitName.InnerText = dsnew.Tables[0].Rows[0]["UnitName"].ToString();
                    lblTSIPassUIDNumber.InnerText = dsnew.Tables[0].Rows[0]["Uid_NO"].ToString();
                    lblCommonApplicationNumber.InnerText = dsnew.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                    hdnApplication.Value = dsnew.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                    lblTypeofApplicant.InnerText = dsnew.Tables[0].Rows[0]["TypeOfIndustryText"].ToString();
                    string TypeOfIndustry = dsnew.Tables[0].Rows[0]["TypeOfIndustry"].ToString();
                    string TextileProcessName = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();
                    //ddlindustryStatus(TypeOfIndustry.Trim().TrimStart().TrimEnd(), TextileProcessName);
                    hdnTypeOfIndustry.Value = dsnew.Tables[0].Rows[0]["TypeOfIndustry"].ToString();
                    if (TypeOfIndustry == "1")
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCP"].ToString();
                    }
                    else
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCPExp"].ToString();
                    }

                    lblReceiptDate.InnerHtml = dsnew.Tables[0].Rows[0]["ApplicationFiledDate"].ToString();
                    lblcategory.InnerText = dsnew.Tables[0].Rows[0]["SocialStatusText"].ToString();
                    lblCategoryofUnit.InnerText = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    rdbCategory.SelectedValue = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    lblActivityoftheUnit.InnerText = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();
                    ddlNature.SelectedValue = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();
                    hdnActualCategory.Value = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    lblTypeofTexttile.InnerText = dsnew.Tables[0].Rows[0]["TypeofTexttileText"].ToString();
                    if (dsnew.Tables[0].Rows[0]["TypeofTexttile"].ToString() == "0")
                    {
                        rdbTypeofTextile.SelectedValue = "1";
                    }
                    else
                    {
                        rdbTypeofTextile.SelectedValue = "2";
                    }

                    hdnActualTextile.Value = dsnew.Tables[0].Rows[0]["TypeofTexttile"].ToString();

                    lblAddress.InnerText = dsnew.Tables[0].Rows[0]["UnitTotalAddress"].ToString();
                    lblProprietor.InnerText = dsnew.Tables[0].Rows[0]["AuthorisedPerson"].ToString();
                    lblOrganization.InnerText = dsnew.Tables[0].Rows[0]["ConstitutionUnit"].ToString();
                    lblSocialStatus.InnerText = dsnew.Tables[0].Rows[0]["SocialStatusText"].ToString();
                    lblRegistrationNumber.InnerText = dsnew.Tables[0].Rows[0]["IncorpRegistranNumber"].ToString();
                    lblTechnicalTextileType.InnerText = dsnew.Tables[0].Rows[0]["TechnicalTextile"].ToString();
                    lblPowerConnectionReleaseDate.InnerText = dsnew.Tables[0].Rows[0]["NewPowerReleaseDate"].ToString();

                }
            }
            catch (Exception ex)
            { }
        }
        public void GetClaimPeriod(string IncentiveID, string SubIncentiveId)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = objappraisalClass.GetCliamPeroid(IncentiveID, SubIncentiveId);
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    lblClaimPeroid.Text = dsnew.Tables[0].Rows[0]["ClaimPeriod"].ToString();
                    txtMonth1.Text = dsnew.Tables[1].Rows[0][0].ToString();
                    txtMonth2.Text = dsnew.Tables[1].Rows[1][0].ToString();
                    txtMonth3.Text = dsnew.Tables[1].Rows[2][0].ToString();
                    txtMonth4.Text = dsnew.Tables[1].Rows[3][0].ToString();
                    txtMonth5.Text = dsnew.Tables[1].Rows[4][0].ToString();
                    txtMonth6.Text = dsnew.Tables[1].Rows[5][0].ToString();

                    txtYear1.Text = dsnew.Tables[1].Rows[0][2].ToString();
                    txtYear2.Text = dsnew.Tables[1].Rows[1][2].ToString();
                    txtYear3.Text = dsnew.Tables[1].Rows[2][2].ToString();
                    txtYear4.Text = dsnew.Tables[1].Rows[3][2].ToString();
                    txtYear5.Text = dsnew.Tables[1].Rows[4][2].ToString();
                    txtYear6.Text = dsnew.Tables[1].Rows[5][2].ToString();
                }
            }
            catch (Exception ex)
            { }
        }

        protected void rdbTypeofTextile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((rdbTypeofTextile.SelectedValue.ToString() != null && rdbTypeofTextile.SelectedValue.ToString() != "")
                && (rdbCategory.SelectedValue.ToString() != null && rdbCategory.SelectedValue.ToString() != ""))
            {
                string Type = rdbTypeofTextile.SelectedValue.ToString();
                string Category = rdbCategory.SelectedValue.ToString();
                if (ddlNature.SelectedValue.ToString() == "Ginning")
                {
                    txtEligibleRate1.Text = "1";
                    txtEligibleRate2.Text = "1";
                    txtEligibleRate3.Text = "1";
                    txtEligibleRate4.Text = "1";
                    txtEligibleRate5.Text = "1";
                    txtEligibleRate6.Text = "1";
                }
                else
                {
                    if (Type == "1")
                    {
                        if (Category == "A1" || Category == "A2")
                        {
                            txtEligibleRate1.Text = "1";
                            txtEligibleRate2.Text = "1";
                            txtEligibleRate3.Text = "1";
                            txtEligibleRate4.Text = "1";
                            txtEligibleRate5.Text = "1";
                            txtEligibleRate6.Text = "1";
                        }
                        if (Category == "A3")
                        {
                            txtEligibleRate1.Text = "1.5";
                            txtEligibleRate2.Text = "1.5";
                            txtEligibleRate3.Text = "1.5";
                            txtEligibleRate4.Text = "1.5";
                            txtEligibleRate5.Text = "1.5";
                            txtEligibleRate6.Text = "1.5";
                        }
                        if (Category == "A4")
                        {
                            txtEligibleRate1.Text = "1.75";
                            txtEligibleRate2.Text = "1.75";
                            txtEligibleRate3.Text = "1.75";
                            txtEligibleRate4.Text = "1.75";
                            txtEligibleRate5.Text = "1.75";
                            txtEligibleRate6.Text = "1.75";
                        }
                        if (Category == "A5")
                        {
                            txtEligibleRate1.Text = "2";
                            txtEligibleRate2.Text = "2";
                            txtEligibleRate3.Text = "2";
                            txtEligibleRate4.Text = "2";
                            txtEligibleRate5.Text = "2";
                            txtEligibleRate6.Text = "2";
                        }
                    }
                    else
                    {
                        if (Category == "A1" || Category == "A2")
                        {
                            txtEligibleRate1.Text = "1.50";
                            txtEligibleRate2.Text = "1.50";
                            txtEligibleRate3.Text = "1.50";
                            txtEligibleRate4.Text = "1.50";
                            txtEligibleRate5.Text = "1.50";
                            txtEligibleRate6.Text = "1.50";
                        }
                        if (Category == "A3")
                        {
                            txtEligibleRate1.Text = "2";
                            txtEligibleRate2.Text = "2";
                            txtEligibleRate3.Text = "2";
                            txtEligibleRate4.Text = "2";
                            txtEligibleRate5.Text = "2";
                            txtEligibleRate6.Text = "2";
                        }
                        if (Category == "A4")
                        {
                            txtEligibleRate1.Text = "2.25";
                            txtEligibleRate2.Text = "2.25";
                            txtEligibleRate3.Text = "2.25";
                            txtEligibleRate4.Text = "2.25";
                            txtEligibleRate5.Text = "2.25";
                            txtEligibleRate6.Text = "2.25";
                        }
                        if (Category == "A5")
                        {
                            txtEligibleRate1.Text = "2.50";
                            txtEligibleRate2.Text = "2.50";
                            txtEligibleRate3.Text = "2.50";
                            txtEligibleRate4.Text = "2.50";
                            txtEligibleRate5.Text = "2.50";
                            txtEligibleRate6.Text = "2.50";
                        }
                    }
                }
            }
        }

        protected void CalculateElgibleAmount(object sender, EventArgs e)
        {
            if ((rdbTypeofTextile.SelectedValue.ToString() != null && rdbTypeofTextile.SelectedValue.ToString() != "")
                && (rdbCategory.SelectedValue.ToString() != null && rdbCategory.SelectedValue.ToString() != ""))
            {
                string EUnits1 = "0", EUnits2 = "0", EUnits3 = "0", EUnits4 = "0", EUnits5 = "0", EUnits6 = "0";
                if (txtUnitsConsumed1.Text != "") { EUnits1 = txtUnitsConsumed1.Text.ToString(); }
                if (txtUnitsConsumed2.Text != "") { EUnits2 = txtUnitsConsumed2.Text.ToString(); }
                if (txtUnitsConsumed3.Text != "") { EUnits3 = txtUnitsConsumed3.Text.ToString(); }
                if (txtUnitsConsumed4.Text != "") { EUnits4 = txtUnitsConsumed4.Text.ToString(); }
                if (txtUnitsConsumed5.Text != "") { EUnits5 = txtUnitsConsumed5.Text.ToString(); }
                if (txtUnitsConsumed6.Text != "") { EUnits6 = txtUnitsConsumed6.Text.ToString(); }

                txtEligibleAmount1.Text = (Convert.ToDecimal(EUnits1) * (Convert.ToDecimal(txtEligibleRate1.Text.ToString()))).ToString();
                txtEligibleAmount2.Text = (Convert.ToDecimal(EUnits2) * (Convert.ToDecimal(txtEligibleRate2.Text.ToString()))).ToString();
                txtEligibleAmount3.Text = (Convert.ToDecimal(EUnits3) * (Convert.ToDecimal(txtEligibleRate3.Text.ToString()))).ToString();
                txtEligibleAmount4.Text = (Convert.ToDecimal(EUnits4) * (Convert.ToDecimal(txtEligibleRate4.Text.ToString()))).ToString();
                txtEligibleAmount5.Text = (Convert.ToDecimal(EUnits5) * (Convert.ToDecimal(txtEligibleRate5.Text.ToString()))).ToString();
                txtEligibleAmount6.Text = (Convert.ToDecimal(EUnits6) * (Convert.ToDecimal(txtEligibleRate6.Text.ToString()))).ToString();

                lblTotalAmount.InnerText = (Convert.ToDecimal(txtEligibleAmount1.Text.ToString()) + Convert.ToDecimal(txtEligibleAmount2.Text.ToString()) + Convert.ToDecimal(txtEligibleAmount3.Text.ToString()) +
                    Convert.ToDecimal(txtEligibleAmount4.Text.ToString()) + Convert.ToDecimal(txtEligibleAmount5.Text.ToString()) + Convert.ToDecimal(txtEligibleAmount6.Text.ToString())).ToString();
            }
        }

        protected void rdbEligibleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblTotalAmount.InnerText == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Calculate Total Amount !');", true);
                return;
            }
            else
            {
                if (rdbEligibleType.SelectedValue != null || rdbEligibleType.SelectedValue != "")
                {
                    if (rdbEligibleType.SelectedValue.ToString() == "1")
                    {
                        lblEligibleAmount.InnerText = lblTotalAmount.InnerText.ToString();
                    }
                    if (rdbEligibleType.SelectedValue.ToString() == "2")
                    {
                        string ElgAmount = "";
                        ElgAmount = (Convert.ToDecimal(lblTotalAmount.InnerText.ToString()) / 2).ToString();
                        lblEligibleAmount.InnerText = ElgAmount;
                    }
                    if (rdbEligibleType.SelectedValue.ToString() == "3")
                    {
                        lblEligibleAmount.InnerText = "0";
                    }
                    decimal Val1 = (decimal)Convert.ToDecimal(lblEligibleAmount.InnerText.ToString());
                    decimal Val2 = (decimal)Convert.ToDecimal(lblGMAmount.InnerText.ToString());
                    decimal minValue = Math.Min(Val1, Val2);
                    lblFinalElgAmount.InnerText = minValue.ToString();
                }
            }
        }

        protected void ddlNature_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
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
                if (save())
                {
                    string message = "alert('Appraisal Note submitted successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    btnSubmit.Visible = false;
                }
                else 
                {
                    string message = "alert('Failed to Submit')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
        }
        public string ValidateControls()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (rdbTypeofTextile.SelectedValue.ToString() == "" || rdbTypeofTextile.SelectedValue.ToString() == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Type of Textile as per Inspection \\n";
                slno = slno + 1;
            }
            if (rdbCategory.SelectedValue.ToString() == "" || rdbCategory.SelectedValue.ToString() == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Category as per Inspection \\n";
                slno = slno + 1;
            }
            if (ddlNature.SelectedValue.ToString() == "" || rdbCategory.SelectedValue.ToString() == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Nature of Industry as per Inspection \\n";
                slno = slno + 1;
            }
            if (txtUnitsConsumed1.Text == "" || txtUnitsConsumed2.Text == "" || txtUnitsConsumed3.Text == "" || txtUnitsConsumed4.Text == ""
                || txtUnitsConsumed5.Text == "" || txtUnitsConsumed6.Text == "" ) 
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter all Months of Units Consumed \\n";
                slno = slno + 1;
            }
            if (txtAmountPaid1.Text == "" || txtAmountPaid2.Text == "" || txtAmountPaid3.Text == "" || txtAmountPaid4.Text == ""
                || txtAmountPaid5.Text == "" || txtAmountPaid6.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter all Months of Amount Paid as per Bill  \\n";
                slno = slno + 1;
            }
            if (txtEligibleRate1.Text == "" || txtEligibleRate2.Text == "" || txtEligibleRate3.Text == "" || txtEligibleRate4.Text == ""
                || txtEligibleRate5.Text == "" || txtEligibleRate6.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter all Months of Eligible rate Re-Imbursement  \\n";
                slno = slno + 1;
            }
            if (txtEligibleAmount1.Text == "" || txtEligibleAmount2.Text == "" || txtEligibleAmount3.Text == "" || txtEligibleAmount4.Text == ""
                || txtEligibleAmount5.Text == "" || txtEligibleAmount6.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter all Months of Eligible Amount Re-Imbursement  \\n";
                slno = slno + 1;
            }
            if (lblTotalAmount.InnerText == "" || lblEligibleAmount.InnerText == "" || lblGMAmount.InnerText == "" || lblFinalElgAmount.InnerText == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please calculate Eligible Subsidy Amount By entering all required Details \\n";
                slno = slno + 1;
            }
            if (ddlDepartment.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select whom you want to forward this to. \\n";
                slno = slno + 1;
            }
            return ErrorMsg;
        }
        public bool save()
        {
            UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
            ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

            ApprasialProperties objApprasialProperties = new ApprasialProperties();
            bool status = false;
            try
            {
                //Chanikya
                objApprasialProperties.INCENTIVEID = txtIncID.Text;
                objApprasialProperties.NAMEOFINDUSTRIAL = lblUnitName.InnerText;
                objApprasialProperties.LOCATIONOFINDUSTRIAL = lblAddress.InnerText;
                objApprasialProperties.NAMEOFPROMOTER = lblUnitName.InnerText;
                objApprasialProperties.ConstitutionOFINDUSTRIAL = lblOrganization.InnerText;
                objApprasialProperties.SOCIALSTATUS = lblSocialStatus.InnerText;
                objApprasialProperties.WOMENENTERPRENEUR = lblShareofSCSTWomenEnterprenue.InnerText;
                objApprasialProperties.PMTSSIREGISTRATIONNO = lblRegistrationNumber.InnerText;
                objApprasialProperties.TypeOfUnit = lblTypeofApplicant.InnerText;
                objApprasialProperties.CATEGORY = lblCategoryofUnit.InnerText;
                objApprasialProperties.SECTOR = lblTypeofSector.InnerText;
                objApprasialProperties.TextileType = lblTypeofTexttile.InnerText;
                objApprasialProperties.TechnicalTextileType = lblTechnicalTextileType.InnerText;
                objApprasialProperties.ActivityOfUnit = lblActivityoftheUnit.InnerText;
                objApprasialProperties.UID_NO = lblTSIPassUIDNumber.InnerText.ToString();
                objApprasialProperties.Application_No = lblCommonApplicationNumber.InnerText.ToString();
                objApprasialProperties.DATEOFPRODUCTION = Convert.ToDateTime(lblDCPdate.InnerText).ToString("yyyy-MM-dd");
                objApprasialProperties.DICFILLINGDATE = Convert.ToDateTime(lblReceiptDate.InnerText).ToString("yyyy-MM-dd");
                objApprasialProperties.PowerConnectionRlsDate = Convert.ToDateTime(lblPowerConnectionReleaseDate.InnerText).ToString("yyyy-MM-dd");
                objApprasialProperties.NAMEFINANCINGUNIT = lblUnitName.InnerText;

                objApprasialProperties.TextileTypeAsPerInspection = rdbTypeofTextile.SelectedItem.Text.ToString();
                objApprasialProperties.CategoryAsPerInspection = rdbCategory.SelectedValue.ToString();
                objApprasialProperties.NatureAsPerInspection = ddlNature.SelectedValue.ToString();
                objApprasialProperties.CLAIMPERIOD = lblClaimPeroid.Text.ToString();
                objApprasialProperties.FinancialYear = txtYear1.Text.ToString();

                objApprasialProperties.Month1 = txtMonth1.Text.ToString();
                objApprasialProperties.Month2 = txtMonth2.Text.ToString();
                objApprasialProperties.Month3 = txtMonth3.Text.ToString();
                objApprasialProperties.Month4 = txtMonth4.Text.ToString();
                objApprasialProperties.Month5 = txtMonth5.Text.ToString();
                objApprasialProperties.Month6 = txtMonth6.Text.ToString();

                objApprasialProperties.UnitsConsumed1 = txtUnitsConsumed1.Text.ToString();
                objApprasialProperties.UnitsConsumed2 = txtUnitsConsumed2.Text.ToString();
                objApprasialProperties.UnitsConsumed3 = txtUnitsConsumed3.Text.ToString();
                objApprasialProperties.UnitsConsumed4 = txtUnitsConsumed4.Text.ToString();
                objApprasialProperties.UnitsConsumed5 = txtUnitsConsumed5.Text.ToString();
                objApprasialProperties.UnitsConsumed6 = txtUnitsConsumed6.Text.ToString();

                objApprasialProperties.PaidBillAmount1 = txtAmountPaid1.Text.ToString();
                objApprasialProperties.PaidBillAmount2 = txtAmountPaid2.Text.ToString();
                objApprasialProperties.PaidBillAmount3 = txtAmountPaid3.Text.ToString();
                objApprasialProperties.PaidBillAmount4 = txtAmountPaid4.Text.ToString();
                objApprasialProperties.PaidBillAmount5 = txtAmountPaid5.Text.ToString();
                objApprasialProperties.PaidBillAmount6 = txtAmountPaid6.Text.ToString();

                objApprasialProperties.EligibleRate1 = txtEligibleRate1.Text.ToString();
                objApprasialProperties.EligibleRate2 = txtEligibleRate2.Text.ToString();
                objApprasialProperties.EligibleRate3 = txtEligibleRate3.Text.ToString();
                objApprasialProperties.EligibleRate4 = txtEligibleRate4.Text.ToString();
                objApprasialProperties.EligibleRate5 = txtEligibleRate5.Text.ToString();
                objApprasialProperties.EligibleRate6 = txtEligibleRate6.Text.ToString();

                objApprasialProperties.EligibleAmount1 = txtEligibleAmount1.Text.ToString();
                objApprasialProperties.EligibleAmount2 = txtEligibleAmount2.Text.ToString();
                objApprasialProperties.EligibleAmount3 = txtEligibleAmount3.Text.ToString();
                objApprasialProperties.EligibleAmount4 = txtEligibleAmount4.Text.ToString();
                objApprasialProperties.EligibleAmount5 = txtEligibleAmount5.Text.ToString();
                objApprasialProperties.EligibleAmount6 = txtEligibleAmount6.Text.ToString();

                objApprasialProperties.ComputedTotalCost = lblTotalAmount.InnerText.ToString();
                objApprasialProperties.Type = rdbEligibleType.SelectedItem.Text.ToString();
                objApprasialProperties.EligibleSubsidyAmount = lblEligibleAmount.InnerText.ToString();
                objApprasialProperties.GMRecommendedAmount = lblGMAmount.InnerText.ToString();
                objApprasialProperties.TotalSubsidyAmount = lblFinalElgAmount.InnerText.ToString();
                objApprasialProperties.Remarks = txtRemarks.Text.ToString();
                objApprasialProperties.WorkSheetPath = hypWorksheet.NavigateUrl.ToString();
                objApprasialProperties.CREATEDBY = ObjLoginNewvo.uid;
                objApprasialProperties.CREATEDBYIP = "";
                objApprasialProperties.Scheme = "TTAP";
                string returnval = "0";
                returnval = ObjCAFClass.InsertPowerAppraisal(objApprasialProperties);
                if (!string.IsNullOrEmpty(returnval) && returnval.Trim() != "")
                {
                    string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
                    DLOApplication DLODetails = new DLOApplication();
                    if (lblFinalElgAmount.InnerText != "")
                    {
                        DLODetails.RECOMMENDEAMOUNT = lblFinalElgAmount.InnerText;
                    }
                    else
                    {
                        DLODetails.RECOMMENDEAMOUNT = Convert.ToString(objApprasialProperties.TotalSubsidyAmount);
                    }

                    DLODetails.INCENTIVEID = txtIncID.Text;
                    DLODetails.SUBINCENTIVEID = "4";
                    DLODetails.ACTIONID = "1";
                    DLODetails.FORWARDTO = ddlDepartment.SelectedItem.Text;
                    DLODetails.CREATEDBY = ObjLoginNewvo.uid;

                    string result = ObjCAFClass.InsertClerkDetails(DLODetails);

                    if (result == "1")
                    {
                        status = true;
                        lblmsg.Text = "Appraisal note submitted";
                        /*lblmsg.Text = "Application Process Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Application Process Submitted Successfully.');", true);*/
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Action Failed');", true);
                    status = false;
                }
            }
            catch (Exception ex)
            {

            }
            return status;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string IncentiveId = txtIncID.Text;
            string SubIncentiveId = "4";

            if (fuWorksheet.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuWorksheet);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuWorksheet);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.WorkSheetFileUploading("~\\WorkSheets", Server.MapPath("~\\WorkSheets"), fuWorksheet, hypWorksheet, "WorkSheet", IncentiveId, SubIncentiveId, ViewState["UID"].ToString(), "USER", "WORKSHEET");
                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        hypWorksheet.Visible = true;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Only pdf files allowed !');", true);
                }
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("COI/ClerkDashboard.aspx");
        }
    }
}