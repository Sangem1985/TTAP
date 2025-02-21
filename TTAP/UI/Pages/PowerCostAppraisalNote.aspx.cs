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
using System.Web.UI.HtmlControls;

namespace TTAP.UI.Pages
{
    public partial class PowerCostAppraisalNote : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        CAFClass ObjCAFClass = new CAFClass();
        AppraisalClass objappraisalClass = new AppraisalClass();
        private decimal totalEligibleAmount = 0;
        private decimal grandTotal = 0;
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
                        BindFinancialYears(incentiveid,"4");
                        GetClaimPeriod(incentiveid, "4");
                        rdbTypeofTextile_SelectedIndexChanged(this, EventArgs.Empty);
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
                        divNewMonth.Visible = true;
                    }
                    else
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCPExp"].ToString();
                        divLastThreeDtls.Visible = true;
                        divExpansionDtls.Visible = true;
                        divNewMonth.Visible = true;
                        BindLastThreeYrs(Convert.ToDateTime(dsnew.Tables[0].Rows[0]["DCPExp"].ToString()).ToString("yyyy/MM/dd"));
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
                    lblGMAmount.InnerText = dsnew.Tables[1].Rows[0]["OfficerRecommendedAmount"].ToString();

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
                dsnew = objappraisalClass.GetCliamPeroidNew(IncentiveID, SubIncentiveId, "N");
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    lblClaimPeroid.Text = dsnew.Tables[0].Rows[0]["ClaimPeriod"].ToString();
                }
            }
            catch (Exception ex)
            { }
        }
        protected void rdbEligibleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblTotalAmount.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Calculate Total Amount !');", true);
                return;
            }
            else
            {
                if (rdbEligibleType.SelectedValue != null && rdbEligibleType.SelectedValue != "")
                {
                    if (rdbEligibleType.SelectedValue.ToString() == "1")
                    {
                        lblEligibleAmount.Text = lblTotalAmount.Text.ToString();
                    }
                    if (rdbEligibleType.SelectedValue.ToString() == "2")
                    {
                        string ElgAmount = "";
                        ElgAmount = (Convert.ToDecimal(lblTotalAmount.Text.ToString()) / 2).ToString();
                        lblEligibleAmount.Text = ElgAmount;
                    }
                    if (rdbEligibleType.SelectedValue.ToString() == "3")
                    {
                        lblEligibleAmount.Text = "0";
                    }
                    decimal Val1 = (decimal)Convert.ToDecimal(lblEligibleAmount.Text.ToString());
                    decimal Val2 = (decimal)Convert.ToDecimal(lblGMAmount.InnerText.ToString());
                    decimal minValue = Math.Min(Val1, Val2);
                    lblFinalElgAmount.Text = minValue.ToString();
                }
            }
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

            if (hdnTypeOfIndustry.Value == "1")
            {
                if (ddlFinYear1.SelectedValue == "0" || ddlFinYear2.SelectedValue == "0" || ddlFinYear3.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please select Financial Year in Last three Years details  \\n";
                    slno = slno + 1;
                }
                if (txtUtilizedUnits1.Text == "" || txtUtilizedUnits2.Text == "" || txtUtilizedUnits3.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter No of Units Utilised Details in Last three Years details  \\n";
                    slno = slno + 1;
                }
                if (txtRatePerUnit1.Text == "" || txtRatePerUnit2.Text == "" || txtRatePerUnit3.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter Rate per Unit Details in Last three Years details  \\n";
                    slno = slno + 1;
                }
                if (txtTotalPaid1.Text == "" || txtTotalPaid2.Text == "" || txtTotalPaid3.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter Total Paid by the unit Details in Last three Years details  \\n";
                    slno = slno + 1;
                }
                if (txtPrior3Yrs.Text == "" || txtAvgUnitsEM.Text == "" || txtBasePower.Text == "" || txtPerMonth.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Calculate Total units consumed prior to 3 Years/Average units EM/Base power consumption fixed per year/Per month.  \\n";
                    slno = slno + 1;
                }
            }
            if (lblTotalAmount.Text == "" || lblEligibleAmount.Text == "" || lblGMAmount.InnerText == "" || lblFinalElgAmount.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please calculate Eligible Subsidy Amount By entering all required Details \\n";
                slno = slno + 1;
            }
            if (ddlDepartment.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select whom you want to forward this to. \\n";
                slno = slno + 1;
            }

            foreach (RepeaterItem item in rptFinancialYears.Items)
            {
                Repeater rptMonths = (Repeater)item.FindControl("rptMonths");

                if (rptMonths != null)
                {

                    for (int j = 0; j < rptMonths.Items.Count; j++)
                    {
                        RepeaterItem innerItem = rptMonths.Items[j];

                        if (innerItem.ItemType == ListItemType.Item || innerItem.ItemType == ListItemType.AlternatingItem)
                        {
                            TextBox txtMonth = (TextBox)innerItem.FindControl("txtMonth");
                            TextBox txtYear = (TextBox)innerItem.FindControl("txtYear");
                            TextBox txtUnits = (TextBox)innerItem.FindControl("txtUnits");
                            TextBox txtAmount = (TextBox)innerItem.FindControl("txtAmount");
                            TextBox txtEligibleRate = (TextBox)innerItem.FindControl("txtEligibleRate");
                            TextBox txtEligibleAmount = (TextBox)innerItem.FindControl("txtEligibleAmount");
                            TextBox txtBaseFixed = (TextBox)innerItem.FindControl("txtBaseFixed");
                            TextBox txtEligibleUnitsBase = (TextBox)innerItem.FindControl("txtEligibleUnitsBase");
                            if (txtUnits.Text == "" || txtAmount.Text == "" || txtAmount.Text == "" || txtEligibleRate.Text == "" || txtEligibleAmount.Text == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please enter Every Financial All Month wise Details \\n";
                                slno = slno + 1;
                            }
                            if (hdnTypeOfIndustry.Value == "2")
                            {
                                if (txtBaseFixed.Text == "" || txtEligibleUnitsBase.Text == "")
                                {
                                    ErrorMsg = ErrorMsg + slno + ". Please enter Every Financial All Month wise Details \\n";
                                    slno = slno + 1;
                                }
                            }
                        }
                    }
                }
            }
                return ErrorMsg;
        }
        public bool save()
        {
            UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
            ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

            ApprasialProperties objApprasialProperties = new ApprasialProperties();
            bool status = false;
            int Scount = 0;
            int RCount = 0;
            try
            {   
                    RCount = rptFinancialYears.Items.Count;
                foreach (RepeaterItem item in rptFinancialYears.Items)
                {
                    TextBox txtFinYear = (TextBox)item.FindControl("txtFinYear");
                    TextBox txtHalfYearType = (TextBox)item.FindControl("txtHalfYearType");

                    objApprasialProperties.FinancialYearId = txtFinYear.Text;
                    objApprasialProperties.HalfYearId = txtHalfYearType.Text;
                    objApprasialProperties.INCENTIVEID = txtIncID.Text;
                    objApprasialProperties.NAMEOFINDUSTRIAL = lblUnitName.InnerText;
                    objApprasialProperties.LOCATIONOFINDUSTRIAL = lblAddress.InnerText;
                    objApprasialProperties.NAMEOFPROMOTER = lblProprietor.InnerText;
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

                    if (lblDCPdate.InnerText != "")
                    {
                        objApprasialProperties.DATEOFPRODUCTION = Convert.ToDateTime(lblDCPdate.InnerText).ToString("yyyy-MM-dd");
                    }
                    else 
                    {
                        objApprasialProperties.DATEOFPRODUCTION = "";
                    }
                    if (lblReceiptDate.InnerText != "")
                    {
                        objApprasialProperties.DICFILLINGDATE = Convert.ToDateTime(lblReceiptDate.InnerText).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        objApprasialProperties.DATEOFPRODUCTION = "";
                    }
                    if (lblPowerConnectionReleaseDate.InnerText != "")
                    {
                        objApprasialProperties.PowerConnectionRlsDate = Convert.ToDateTime(lblPowerConnectionReleaseDate.InnerText).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        objApprasialProperties.PowerConnectionRlsDate = "";
                    }
                    objApprasialProperties.TextileTypeAsPerInspection = rdbTypeofTextile.SelectedItem.Text.ToString();
                    objApprasialProperties.CategoryAsPerInspection = rdbCategory.SelectedValue.ToString();
                    objApprasialProperties.NatureAsPerInspection = ddlNature.SelectedValue.ToString();
                    objApprasialProperties.CLAIMPERIOD = lblClaimPeroid.Text.ToString();

                    if (hdnTypeOfIndustry.Value == "1")
                    {
                        objApprasialProperties.Last3FinancialYear1 = "";
                        objApprasialProperties.Last3FinancialYear2 = "";
                        objApprasialProperties.Last3FinancialYear3 = "";
                    }
                    else
                    {
                        objApprasialProperties.Last3FinancialYear1 = ddlFinYear1.SelectedValue.ToString();
                        objApprasialProperties.Last3FinancialYear2 = ddlFinYear2.SelectedValue.ToString();
                        objApprasialProperties.Last3FinancialYear3 = ddlFinYear3.SelectedValue.ToString();
                    }
                    objApprasialProperties.Last3UtilisedUnits1 = txtUtilizedUnits1.Text.ToString();
                    objApprasialProperties.Last3UtilisedUnits2 = txtUtilizedUnits2.Text.ToString();
                    objApprasialProperties.Last3UtilisedUnits3 = txtUtilizedUnits3.Text.ToString();

                    objApprasialProperties.Last3RatePerUnit1 = txtRatePerUnit1.Text.ToString();
                    objApprasialProperties.Last3RatePerUnit2 = txtRatePerUnit2.Text.ToString();
                    objApprasialProperties.Last3RatePerUnit3 = txtRatePerUnit3.Text.ToString();

                    objApprasialProperties.Last3TotalPaid1 = txtTotalPaid1.Text.ToString();
                    objApprasialProperties.Last3TotalPaid2 = txtTotalPaid2.Text.ToString();
                    objApprasialProperties.Last3TotalPaid3 = txtTotalPaid3.Text.ToString();

                    objApprasialProperties.UnitsConsumedPrior3Yrs = txtPrior3Yrs.Text.ToString();
                    objApprasialProperties.AvgUnitsEM = txtAvgUnitsEM.Text.ToString();
                    objApprasialProperties.BasePowerConsumption = txtBasePower.Text.ToString();
                    objApprasialProperties.PerMonth = txtPerMonth.Text.ToString();

                    objApprasialProperties.ComputedTotalCost = lblTotalAmount.Text.ToString();
                    objApprasialProperties.Type = rdbEligibleType.SelectedItem.Text.ToString();
                    objApprasialProperties.EligibleSubsidyAmount = lblEligibleAmount.Text.ToString();
                    objApprasialProperties.GMRecommendedAmount = lblGMAmount.InnerText.ToString();
                    objApprasialProperties.TotalSubsidyAmount = lblFinalElgAmount.Text.ToString();
                    objApprasialProperties.Remarks = txtRemarks.Text.ToString();
                    objApprasialProperties.WorkSheetPath = hypWorksheet.NavigateUrl.ToString();
                    objApprasialProperties.CREATEDBY = ObjLoginNewvo.uid;
                    objApprasialProperties.CREATEDBYIP = getclientIP();
                    objApprasialProperties.Scheme = "TTAP";


                    Repeater rptMonths = (Repeater)item.FindControl("rptMonths");

                    if (rptMonths != null)
                    {

                        for (int j = 0; j < rptMonths.Items.Count; j++)
                        {
                            RepeaterItem innerItem = rptMonths.Items[j];

                            if (innerItem.ItemType == ListItemType.Item || innerItem.ItemType == ListItemType.AlternatingItem)
                            {

                                TextBox txtMonth = (TextBox)innerItem.FindControl("txtMonth");
                                TextBox txtYear = (TextBox)innerItem.FindControl("txtYear");
                                TextBox txtUnits = (TextBox)innerItem.FindControl("txtUnits");
                                TextBox txtAmount = (TextBox)innerItem.FindControl("txtAmount");
                                TextBox txtEligibleRate = (TextBox)innerItem.FindControl("txtEligibleRate");
                                TextBox txtEligibleAmount = (TextBox)innerItem.FindControl("txtEligibleAmount");
                                TextBox txtBaseFixed = (TextBox)innerItem.FindControl("txtBaseFixed");
                                TextBox txtEligibleUnitsBase = (TextBox)innerItem.FindControl("txtEligibleUnitsBase");

                                if (j == 0)
                                {
                                    objApprasialProperties.Month1 = txtMonth.Text.ToString();
                                    objApprasialProperties.UnitsConsumed1 = txtUnits.Text.ToString();
                                    objApprasialProperties.PaidBillAmount1 = txtAmount.Text.ToString();
                                    objApprasialProperties.EligibleRate1 = txtEligibleRate.Text.ToString();
                                    objApprasialProperties.EligibleAmount1 = txtEligibleAmount.Text.ToString();
                                    objApprasialProperties.BasefixedPerMonth1 = txtBaseFixed.Text.ToString();
                                    objApprasialProperties.EligibleUnitsAboveBase1 = txtEligibleUnitsBase.Text.ToString();
                                    objApprasialProperties.FinancialYear = txtYear.Text.ToString();
                                }
                                if (j == 1)
                                {
                                    objApprasialProperties.Month2 = txtMonth.Text.ToString();
                                    objApprasialProperties.UnitsConsumed2 = txtUnits.Text.ToString();
                                    objApprasialProperties.PaidBillAmount2 = txtAmount.Text.ToString();
                                    objApprasialProperties.EligibleRate2 = txtEligibleRate.Text.ToString();
                                    objApprasialProperties.EligibleAmount2 = txtEligibleAmount.Text.ToString();
                                    objApprasialProperties.BasefixedPerMonth2 = txtBaseFixed.Text.ToString();
                                    objApprasialProperties.EligibleUnitsAboveBase2 = txtEligibleUnitsBase.Text.ToString();
                                }
                                if (j == 2)
                                {
                                    objApprasialProperties.Month3 = txtMonth.Text.ToString();
                                    objApprasialProperties.UnitsConsumed3 = txtUnits.Text.ToString();
                                    objApprasialProperties.PaidBillAmount3 = txtAmount.Text.ToString();
                                    objApprasialProperties.EligibleRate3 = txtEligibleRate.Text.ToString();
                                    objApprasialProperties.EligibleAmount3 = txtEligibleAmount.Text.ToString();
                                    objApprasialProperties.BasefixedPerMonth3 = txtBaseFixed.Text.ToString();
                                    objApprasialProperties.EligibleUnitsAboveBase3 = txtEligibleUnitsBase.Text.ToString();
                                }
                                if (j == 3)
                                {
                                    objApprasialProperties.Month4 = txtMonth.Text.ToString();
                                    objApprasialProperties.UnitsConsumed4 = txtUnits.Text.ToString();
                                    objApprasialProperties.PaidBillAmount4 = txtAmount.Text.ToString();
                                    objApprasialProperties.EligibleRate4 = txtEligibleRate.Text.ToString();
                                    objApprasialProperties.EligibleAmount4 = txtEligibleAmount.Text.ToString();
                                    objApprasialProperties.BasefixedPerMonth4 = txtBaseFixed.Text.ToString();
                                    objApprasialProperties.EligibleUnitsAboveBase4 = txtEligibleUnitsBase.Text.ToString();
                                }
                                if (j == 4)
                                {
                                    objApprasialProperties.Month5 = txtMonth.Text.ToString();
                                    objApprasialProperties.UnitsConsumed5 = txtUnits.Text.ToString();
                                    objApprasialProperties.PaidBillAmount5 = txtAmount.Text.ToString();
                                    objApprasialProperties.EligibleRate5 = txtEligibleRate.Text.ToString();
                                    objApprasialProperties.EligibleAmount5 = txtEligibleAmount.Text.ToString();
                                    objApprasialProperties.BasefixedPerMonth5 = txtBaseFixed.Text.ToString();
                                    objApprasialProperties.EligibleUnitsAboveBase5 = txtEligibleUnitsBase.Text.ToString();
                                }
                                if (j == 5)
                                {
                                    objApprasialProperties.Month6 = txtMonth.Text.ToString();
                                    objApprasialProperties.UnitsConsumed6 = txtUnits.Text.ToString();
                                    objApprasialProperties.PaidBillAmount6 = txtAmount.Text.ToString();
                                    objApprasialProperties.EligibleRate6 = txtEligibleRate.Text.ToString();
                                    objApprasialProperties.EligibleAmount6 = txtEligibleAmount.Text.ToString();
                                    objApprasialProperties.BasefixedPerMonth6 = txtBaseFixed.Text.ToString();
                                    objApprasialProperties.EligibleUnitsAboveBase6 = txtEligibleUnitsBase.Text.ToString();
                                }
                            }
                        }
                    }
                    string returnval = "0";
                    returnval = ObjCAFClass.InsertPowerAppraisal(objApprasialProperties);
                    if (!string.IsNullOrEmpty(returnval) && returnval.Trim() != "")
                    {
                        Scount = Scount + 1;
                    }
                }
               
               
                if (RCount == Scount)
                {
                    string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
                    DLOApplication DLODetails = new DLOApplication();
                    if (lblFinalElgAmount.Text != "")
                    {
                        DLODetails.RECOMMENDEAMOUNT = lblFinalElgAmount.Text;
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
                    }
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

        protected void CalLastThree(object sender, EventArgs e)
        {
            string Unit1 = "0", Unit2 = "0", Unit3 = "0";
            string Rate1 = "0", Rate2 = "0", Rate3 = "0";
            if (txtUtilizedUnits1.Text != "") { Unit1 = txtUtilizedUnits1.Text.ToString(); }
            if (txtUtilizedUnits2.Text != "") { Unit2 = txtUtilizedUnits2.Text.ToString(); }
            if (txtUtilizedUnits3.Text != "") { Unit3 = txtUtilizedUnits3.Text.ToString(); }

            if (txtRatePerUnit1.Text != "") { Rate1 = txtRatePerUnit1.Text.ToString(); }
            if (txtRatePerUnit2.Text != "") { Rate2 = txtRatePerUnit2.Text.ToString(); }
            if (txtRatePerUnit3.Text != "") { Rate3 = txtRatePerUnit3.Text.ToString(); }

            string amt1 = txtTotalPaid1.Text = (Convert.ToDecimal(Unit1) * Convert.ToDecimal(Rate1)).ToString();
            string amt2 = txtTotalPaid2.Text = (Convert.ToDecimal(Unit2) * Convert.ToDecimal(Rate2)).ToString();
            string amt3 = txtTotalPaid3.Text = (Convert.ToDecimal(Unit3) * Convert.ToDecimal(Rate3)).ToString();

            string TotalUnits = (Convert.ToInt32(Unit1) + Convert.ToInt32(Unit2) + Convert.ToInt32(Unit3)).ToString();
            txtPrior3Yrs.Text = TotalUnits.ToString();
            string TotalAmount = txtBasePower.Text = (Convert.ToDecimal(amt1) + Convert.ToDecimal(amt2) + Convert.ToDecimal(amt3)).ToString();
            txtAvgUnitsEM.Text = ((Convert.ToInt32(TotalUnits)) / 3).ToString("0.00");
            txtBasePower.Text = ((Convert.ToInt32(TotalUnits)) / 3).ToString("0.00");
            txtPerMonth.Text = (Convert.ToDecimal(txtBasePower.Text) / 12).ToString("0.00");
          
            foreach (RepeaterItem item in rptFinancialYears.Items)
            {
                Repeater rptMonths = (Repeater)item.FindControl("rptMonths");

                if (rptMonths != null)
                {
                    foreach (RepeaterItem monthItem in rptMonths.Items)
                    {
                        TextBox txtBaseFixed = (TextBox)monthItem.FindControl("txtBaseFixed");
                        txtBaseFixed.Text = txtPerMonth.Text;
                    }
                }
            }
        }
        public void BindLastThreeYrs(string Date)
        {
            DataSet Dsnew = new DataSet();
            Dsnew = ObjCAFClass.GetFinancialYears(Date);
            if (Dsnew != null && Dsnew.Tables.Count > 0 && Dsnew.Tables[0].Rows.Count > 0)
            {
                ddlFinYear1.DataSource = Dsnew.Tables[0];
                ddlFinYear1.DataTextField = "FinancialYear";
                ddlFinYear1.DataValueField = "FinancialYear";
                ddlFinYear1.DataBind();

                ddlFinYear2.DataSource = Dsnew.Tables[0];
                ddlFinYear2.DataTextField = "FinancialYear";
                ddlFinYear2.DataValueField = "FinancialYear";
                ddlFinYear2.DataBind();

                ddlFinYear3.DataSource = Dsnew.Tables[0];
                ddlFinYear3.DataTextField = "FinancialYear";
                ddlFinYear3.DataValueField = "FinancialYear";
                ddlFinYear3.DataBind();
            }
            AddSelect(ddlFinYear1);
            AddSelect(ddlFinYear2);
            AddSelect(ddlFinYear3);
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
        private void BindFinancialYears(string IncentiveId ,string SubIncentiveId)
        {
            List<FinancialYear> financialYears = new List<FinancialYear>();
            string CS = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("USP_GET_CURRENT_CLAIMPERIOD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@INCENTIVEID",
                    Value = IncentiveId
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@SUBINCENTIVEID",
                    Value = "4"
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@FLAG",
                    Value = "Y"
                });
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string Finyear = reader["FinancialYear"].ToString();
                    string year = reader["FinancialYearText"].ToString();
                    string Halfyear = reader["TypeOfFinancialYearText"].ToString();
                    string HalfyearId = reader["TypeOfFinancialYear"].ToString();
                    string YearType= reader["TypeOfFinancialYear"].ToString();
                    financialYears.Add(new FinancialYear
                    {
                        FinancialYearName = year,
                        FinancialYearText= year+"("+ Halfyear+")",
                        HalfYearType = HalfyearId,
                        FinancialYearId= Finyear,
                        Months = GetMonthWiseDetails(year, YearType),
                    });
                }
            }

            rptFinancialYears.DataSource = financialYears;
            rptFinancialYears.DataBind();
        }
        private List<MonthDetail> GetMonthWiseDetails(string year,string YearType)
        {
            List<MonthDetail> months = new List<MonthDetail>();
            string CS = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("USP_GET_CURRENT_CLAIMPERIOD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@INCENTIVEID",
                    Value = txtIncID.Text
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@SUBINCENTIVEID",
                    Value = "4"
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@FLAG",
                    Value = "M"
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@FINANCIALYEAR",
                    Value = year
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@HALFYEAR",
                    Value = YearType
                });
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    months.Add(new MonthDetail
                    {
                        Month = reader["Month"].ToString(),
                        FinancialYear = reader["FinancialYear"].ToString()
                    });
                }
            }
            return months;
        }
        protected void rdbTypeofTextile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((rdbTypeofTextile.SelectedValue.ToString() != null && rdbTypeofTextile.SelectedValue.ToString() != "")
                && (rdbCategory.SelectedValue.ToString() != null && rdbCategory.SelectedValue.ToString() != ""))
            {
                string Type = rdbTypeofTextile.SelectedValue.ToString();
                string Category = rdbCategory.SelectedValue.ToString();
                string Rate = "0";
                if (ddlNature.SelectedValue.ToString() == "Ginning")
                {
                    Rate = "1";
                }
                else
                {
                    if (Type == "1")
                    {
                        if (Category == "A1" || Category == "A2")
                        {
                            Rate = "1";
                        }
                        if (Category == "A3")
                        {
                            Rate = "1.5";
                        }
                        if (Category == "A4")
                        {
                            Rate = "1.75";
                        }
                        if (Category == "A5")
                        {
                            Rate = "2";
                        }
                    }
                    else
                    {
                        if (Category == "A1" || Category == "A2")
                        {
                            Rate = "1.50";
                        }
                        if (Category == "A3")
                        {
                            Rate = "2";
                        }
                        if (Category == "A4")
                        {
                            Rate = "2.25";
                        }
                        if (Category == "A5")
                        {
                            Rate = "2.50";
                        }
                    }
                }

                foreach (RepeaterItem item in rptFinancialYears.Items)
                {
                    Repeater rptMonths = (Repeater)item.FindControl("rptMonths");

                    if (rptMonths != null)
                    {
                        foreach (RepeaterItem monthItem in rptMonths.Items)
                        {   
                            TextBox txtEligibleRate = (TextBox)monthItem.FindControl("txtEligibleRate");
                            txtEligibleRate.Text = Rate;
                        }
                    }
                }
                CalculateChange();
            }
        }
        
        protected void txtUnits_TextChanged(object sender, EventArgs e)
        {
            TextBox txtUnits = (TextBox)sender;
            RepeaterItem item = (RepeaterItem)txtUnits.NamingContainer;

            TextBox txtEligibleRate = (TextBox)item.FindControl("txtEligibleRate");
            TextBox txtEligibleAmount = (TextBox)item.FindControl("txtEligibleAmount");
            TextBox txtBaseFixed = (TextBox)item.FindControl("txtBaseFixed");
            TextBox txtEligibleUnitsBase = (TextBox)item.FindControl("txtEligibleUnitsBase");
            decimal units = 0;
            decimal rate = 0;
            decimal FixedUnits = 0;
            decimal EligibleBaseUnits = 0;

            if (hdnTypeOfIndustry.Value == "1")
            {
                
                if (decimal.TryParse(txtUnits.Text, out units) && txtEligibleRate != null && txtEligibleAmount != null)
                {
                    if (decimal.TryParse(txtEligibleRate.Text, out rate))
                    {
                        txtEligibleAmount.Text = (units * rate).ToString("N2");
                    }
                    else
                    {
                        txtEligibleAmount.Text = "0.00";
                    }
                }
            }
            else 
            {
                if (decimal.TryParse(txtUnits.Text, out units) && txtEligibleRate != null && txtBaseFixed != null && txtEligibleUnitsBase != null && txtEligibleAmount != null)
                {
                    if (decimal.TryParse(txtBaseFixed.Text, out FixedUnits))
                    {
                        txtEligibleUnitsBase.Text = (units - FixedUnits).ToString("N2");

                        if (decimal.TryParse(txtEligibleUnitsBase.Text, out EligibleBaseUnits) && decimal.TryParse(txtEligibleRate.Text, out rate))
                        {

                            txtEligibleAmount.Text = (EligibleBaseUnits * rate).ToString("N2");
                        }
                        else 
                        {
                            txtEligibleAmount.Text = "0.00";
                        }
                    }
                    else
                    {
                        txtEligibleUnitsBase.Text = "0.00";
                        txtEligibleAmount.Text = "0.00";
                    }
                }
            }
            Repeater rptMonths = (Repeater)item.NamingContainer;
            CalculateFooterTotal(rptMonths);
            CalculateTotalFromRepeaters();
        }
        protected void rptMonths_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (hdnTypeOfIndustry.Value == "1")
            {

                if (e.Item.ItemType == ListItemType.Header)
                {
                    PlaceHolder phThBaseFixed = (PlaceHolder)e.Item.FindControl("phThBaseFixed");
                    PlaceHolder phThEligibleUnitsBase = (PlaceHolder)e.Item.FindControl("phThEligibleUnitsBase");
                    phThBaseFixed.Visible = false;
                    phThEligibleUnitsBase.Visible = false;
                }

                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    PlaceHolder phTdBaseFixed = (PlaceHolder)e.Item.FindControl("phTdBaseFixed");
                    PlaceHolder phTdEligibleUnitsBase = (PlaceHolder)e.Item.FindControl("phTdEligibleUnitsBase");
                    phTdBaseFixed.Visible = false;
                    phTdEligibleUnitsBase.Visible = false;

                    TextBox txtEligibleAmount = (TextBox)e.Item.FindControl("txtEligibleAmount");
                    if (!string.IsNullOrEmpty(txtEligibleAmount.Text))
                    {
                        decimal eligibleAmount;
                        if (decimal.TryParse(txtEligibleAmount.Text, out eligibleAmount))
                        {
                            totalEligibleAmount += eligibleAmount;
                        }
                    }
                }

                if (e.Item.ItemType == ListItemType.Footer)
                {
                    Label lblTotalEligibleAmount = (Label)e.Item.FindControl("lblTotalEligibleAmount");
                    lblTotalEligibleAmount.Text = totalEligibleAmount.ToString("N2");
                    totalEligibleAmount = 0;
                }
                Repeater rptMonths = (Repeater)e.Item.NamingContainer;
            }
            else 
            {
            
            }
            
        }
        private void CalculateFooterTotal(Repeater rptMonths)
        {
            totalEligibleAmount = 0;
            foreach (RepeaterItem item in rptMonths.Items)
            {
                TextBox txtEligibleAmount = (TextBox)item.FindControl("txtEligibleAmount");
                if (txtEligibleAmount != null && !string.IsNullOrEmpty(txtEligibleAmount.Text))
                {
                    decimal eligibleAmount;
                    if (decimal.TryParse(txtEligibleAmount.Text, out eligibleAmount))
                    {
                        totalEligibleAmount += eligibleAmount;
                    }
                }
            }

            RepeaterItem footerItem = rptMonths.Controls[rptMonths.Controls.Count - 1] as RepeaterItem;
            if (footerItem != null)
            {
                Label lblTotalEligibleAmount = (Label)footerItem.FindControl("lblTotalEligibleAmount");
                if (lblTotalEligibleAmount != null)
                {
                    lblTotalEligibleAmount.Text = totalEligibleAmount.ToString("N2");
                }
            }
           
        }
        private void CalculateTotalFromRepeaters()
        {
            decimal grandTotal = 0;
            foreach (RepeaterItem outerItem in rptFinancialYears.Items)
            {
                if (outerItem.ItemType == ListItemType.Item || outerItem.ItemType == ListItemType.AlternatingItem)
                { 
                    Repeater rptMonths = outerItem.FindControl("rptMonths") as Repeater;

                    if (rptMonths != null && rptMonths.Items.Count > 0)
                    {
                        RepeaterItem footerItem = rptMonths.Controls[rptMonths.Controls.Count - 1] as RepeaterItem;

                        if (footerItem != null && footerItem.ItemType == ListItemType.Footer)
                        {
                            Label lblTotalEligibleAmount = footerItem.FindControl("lblTotalEligibleAmount") as Label;

                            if (lblTotalEligibleAmount != null && !string.IsNullOrEmpty(lblTotalEligibleAmount.Text))
                            {
                                if (decimal.TryParse(lblTotalEligibleAmount.Text, out decimal footerTotal))
                                {
                                    grandTotal += footerTotal;
                                }
                            }
                        }
                    }
                }
            }
            lblTotalAmount.Text = grandTotal.ToString("N2");
            rdbEligibleType_SelectedIndexChanged(this, EventArgs.Empty);
        }

        private void CalculateChange()
        {
            foreach (RepeaterItem item in rptFinancialYears.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {  
                    Repeater rptMonths = (Repeater)item.FindControl("rptMonths");
                    if (rptMonths != null)
                    {
                        foreach (RepeaterItem innerItem in rptMonths.Items) 
                        {
                            if (innerItem.ItemType == ListItemType.Item || innerItem.ItemType == ListItemType.AlternatingItem)
                            {
                                TextBox txtUnits = (TextBox)innerItem.FindControl("txtUnits");
                                TextBox txtEligibleRate = (TextBox)innerItem.FindControl("txtEligibleRate");
                                TextBox txtEligibleAmount = (TextBox)innerItem.FindControl("txtEligibleAmount");
                                decimal units = 0;
                                decimal rate = 0;
                                if (decimal.TryParse(txtUnits.Text, out units) && txtEligibleRate != null && txtEligibleAmount != null)
                                {
                                    if (decimal.TryParse(txtEligibleRate.Text, out rate))
                                    {
                                        txtEligibleAmount.Text = (units * rate).ToString("N2");
                                    }
                                    else
                                    {
                                        txtEligibleAmount.Text = "0.00";
                                    }
                                }
                            }
                            CalculateFooterTotal(rptMonths);
                        }
                    }
                }
            }
            CalculateTotalFromRepeaters();
        }
        protected void txtEligibleAmount_TextChanged(object sender, EventArgs e)
        {
            TextBox txtEligibleAmount = (TextBox)sender;
            RepeaterItem item = (RepeaterItem)txtEligibleAmount.NamingContainer;

            Repeater rptMonths = (Repeater)item.NamingContainer;
            CalculateFooterTotal(rptMonths);
            CalculateTotalFromRepeaters();
        }
        public static string getclientIP()
        {
            string result = string.Empty;
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ip))
            {
                string[] ipRange = ip.Split(',');
                int le = ipRange.Length - 1;
                result = ipRange[0];
            }
            else
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return result;
        }
        public class FinancialYear
        {
            public string FinancialYearText { get; set; }
            public string FinancialYearName { get; set; }
            public string HalfYearType { get; set; }
            public string FinancialYearId { get; set; }
            public List<MonthDetail> Months { get; set; }
        }

        public class MonthDetail
        {
            public string Month { get; set; }
            public string FinancialYear { get; set; }
            public int UnitsConsumed { get; set; }
            public decimal AmountPaid { get; set; }
            public decimal EligibleRate { get; set; }
            public decimal EligibleAmount { get; set; }
        }
    }
}