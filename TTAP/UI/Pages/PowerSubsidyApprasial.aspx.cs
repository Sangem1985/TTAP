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
    public partial class PowerSubsidyApprasial : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        CAFClass ObjCAFClass = new CAFClass();
        AppraisalClass objappraisalClass = new AppraisalClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
            ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
            ViewState["UID"] = ObjLoginNewvo.uid;
            try
            {
                if (!IsPostBack)
                {
                    string incentiveid = "8301";
                    //Request.QueryString["IncentiveID"] = incentiveid;
                    //if (Request.QueryString["IncentiveID"] != null)
                    //{
                    //    incentiveid = Request.QueryString["IncentiveID"].ToString();
                    //}
                    txtIncID.Text = incentiveid;
                    BindBesicdata(incentiveid, "4", "");
                    DataSet dsnew1 = new DataSet();
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void btnsub_Click(object sender, EventArgs e)
        {
            // BindISCrrentClaimPeriodDtls(txtIncID.Text.ToString());
            BindBesicdata(txtIncID.Text.ToString(), "4", "");
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
                    ddlindustryStatus(TypeOfIndustry.Trim().TrimStart().TrimEnd(), TextileProcessName);
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
                    //lblRecommended.InnerText = "100000";
                    lblActivityoftheUnit.InnerText = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();
                    //ddlCategory.SelectedValue = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    hdnActualCategory.Value = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    lblTypeofTexttile.InnerText = dsnew.Tables[0].Rows[0]["TypeofTexttileText"].ToString();
                    //ddlTypeofTextile.SelectedValue = dsnew.Tables[0].Rows[0]["TypeofTexttile"].ToString();
                    hdnActualTextile.Value = dsnew.Tables[0].Rows[0]["TypeofTexttile"].ToString();

                    lblAddress.InnerText = dsnew.Tables[0].Rows[0]["UnitTotalAddress"].ToString();
                    lblProprietor.InnerText = dsnew.Tables[0].Rows[0]["AuthorisedPerson"].ToString();
                    lblOrganization.InnerText = dsnew.Tables[0].Rows[0]["ConstitutionUnit"].ToString();
                    lblSocialStatus.InnerText = dsnew.Tables[0].Rows[0]["SocialStatusText"].ToString();
                    lblRegistrationNumber.InnerText = dsnew.Tables[0].Rows[0]["IncorpRegistranNumber"].ToString();
                    lblTechnicalTextileType.InnerText = dsnew.Tables[0].Rows[0]["TechnicalTextile"].ToString();
                    lblPowerConnectionReleaseDate.InnerText = dsnew.Tables[0].Rows[0]["NewPowerReleaseDate"].ToString();
                    //if (dsnew != null && dsnew.Tables.Count > 1 && dsnew.Tables[1].Rows.Count > 0)
                    //{
                    //    txt_GMrecommendedamount.Text = dsnew.Tables[1].Rows[0]["OfficerRecommendedAmount"].ToString();
                    //}
                    txtlandexisting.InnerHtml = dsnew.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString();
                    TextBox33.Text = dsnew.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString();
                    txtlandcapacity.InnerHtml = dsnew.Tables[0].Rows[0]["ExpansionDiversificationLand"].ToString();
                    txtlandpercentage.InnerHtml = dsnew.Tables[0].Rows[0]["LandFixedCapitalInvestPercentage"].ToString();

                    txtbuildingexisting.InnerHtml = dsnew.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString();
                    TextBox37.Text = dsnew.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString();
                    txtbuildingcapacity.InnerHtml = dsnew.Tables[0].Rows[0]["ExpDiversBuilding"].ToString();
                    txtbuildingpercentage.InnerHtml = dsnew.Tables[0].Rows[0]["BuildingFixedCapitalInvestPercentage"].ToString();

                    txtplantexisting.InnerHtml = dsnew.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString();
                    TextBox41.Text = dsnew.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString();
                    txtplantcapacity.InnerHtml = dsnew.Tables[0].Rows[0]["ExpDiversPlantMachinery"].ToString();
                    txtplantpercentage.InnerHtml = dsnew.Tables[0].Rows[0]["PlantMachFixedCapitalInvestPercentage"].ToString();

                    CalculatationEnterprise1("1");
                    CalculatationEnterprise1("2");
                    CalculatationEnterprise1("3");

                    txtcurrInvLandValue.InnerHtml = dsnew.Tables[0].Rows[0]["CurrentInvestmentLandvalue"].ToString();
                    txtcurrInvBuldvalue.InnerHtml = dsnew.Tables[0].Rows[0]["CurrentInvestmentBuildingvalue"].ToString();
                    txtcurrInvplantMechValue.InnerHtml = dsnew.Tables[0].Rows[0]["CurrentInvestmentplantMechValue"].ToString();
                    txtcurrentInvothers.InnerHtml = dsnew.Tables[0].Rows[0]["CurrentInvestmentOtherValue"].ToString();

                    txtExpansionLandValue.InnerHtml = dsnew.Tables[0].Rows[0]["ActualLandvalue"].ToString();
                    txtExpansionBuildingValue.InnerHtml = dsnew.Tables[0].Rows[0]["ActualBuildingValue"].ToString();
                    txtExpansionplantMechValue.InnerHtml = dsnew.Tables[0].Rows[0]["ActualPMValue"].ToString();
                    txtExpansionInvothers.InnerHtml = dsnew.Tables[0].Rows[0]["ActualOtherValue"].ToString();

                    CalculateCurrInvTot(TypeOfIndustry);
                    DataSet dsnew1 = new DataSet();
                    dsnew1 = objappraisalClass.GetSubsidyApplicationDeatils(IncentiveID, SubIncentiveId, "");
                    TextBox56.Text = dsnew1.Tables[0].Rows[0]["DLOLandCalculatedAmount"].ToString();
                    TextBox56_TextChanged(this, EventArgs.Empty);
                    TextBox57.Text = dsnew1.Tables[0].Rows[0]["DLOBuildingCalculatedAmount"].ToString();
                    TextBox57_TextChanged(this, EventArgs.Empty);
                    TextBox58.Text = dsnew1.Tables[0].Rows[0]["DLOPMCalculatedAmount"].ToString();
                    TextBox58_TextChanged(this, EventArgs.Empty);
                    if (dsnew1.Tables[0].Rows[0]["NumberofEmployees_Training_Subsidy"].ToString() != "")
                    {
                        txtemployement.Text = dsnew1.Tables[0].Rows[0]["NumberofEmployees_Training_Subsidy"].ToString();
                    }
                    if (!string.IsNullOrEmpty(lblTypeofApplicant.InnerText))
                    {
                        ListItem item = ddlIndustryStatus.Items.FindByText(lblTypeofApplicant.InnerText);

                        if (item != null)
                        {
                            ddlIndustryStatus.ClearSelection(); // Clear previous selection
                            item.Selected = true; // Set new selection
                        }
                    }
                    if (lblCategoryofUnit.InnerText != null && lblCategoryofUnit.InnerText != "")
                    {
                        rdcategoryofunit.SelectedValue = lblCategoryofUnit.InnerText;
                    }
                    if (lblTypeofTexttile.InnerText != null && lblTypeofTexttile.InnerText != "")
                    {
                        rdcoventinaltech.SelectedValue = lblTypeofTexttile.InnerText;
                    }
                    if (!string.IsNullOrEmpty(lblActivityoftheUnit.InnerText))
                    {
                        ListItem item = ddlTextileProcessType.Items.FindByText(lblActivityoftheUnit.InnerText);

                        if (item != null)
                        {
                            ddlTextileProcessType.ClearSelection(); // Clear previous selection
                            item.Selected = true; // Set new selection
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public void CalculateCurrInvTot(string TypeOfIndustry)
        {
            if (TypeOfIndustry == "1")
            {
                // based on entry
                decimal ExpansionLandValue = Convert.ToDecimal(GetDecimalNullValue(txtExpansionLandValue.InnerHtml.Trim().TrimStart()));
                decimal ExpansionBuildingValue = Convert.ToDecimal(GetDecimalNullValue(txtExpansionBuildingValue.InnerHtml.Trim().TrimStart()));
                decimal ExpansionplantMechValue = Convert.ToDecimal(GetDecimalNullValue(txtExpansionplantMechValue.InnerHtml.Trim().TrimStart()));
                decimal ExpansionInvothers = Convert.ToDecimal(GetDecimalNullValue(txtExpansionInvothers.InnerHtml.Trim().TrimStart()));

                lblExpansionInvTot.InnerHtml = (ExpansionLandValue + ExpansionBuildingValue + ExpansionplantMechValue + ExpansionInvothers).ToString();
            }
            else
            {
                // common application form values (existing industry)
                decimal currInvLandValue = Convert.ToDecimal(GetDecimalNullValue(txtcurrInvLandValue.InnerHtml.Trim().TrimStart()));
                decimal currInvBuldvalue = Convert.ToDecimal(GetDecimalNullValue(txtcurrInvBuldvalue.InnerHtml.Trim().TrimStart()));
                decimal currInvplantMechValue = Convert.ToDecimal(GetDecimalNullValue(txtcurrInvplantMechValue.InnerHtml.Trim().TrimStart()));
                decimal currentInvothers = Convert.ToDecimal(GetDecimalNullValue(txtcurrentInvothers.InnerHtml.Trim().TrimStart()));

                // based on entry
                decimal ExpansionLandValue = Convert.ToDecimal(GetDecimalNullValue(txtExpansionLandValue.InnerHtml.Trim().TrimStart()));
                decimal ExpansionBuildingValue = Convert.ToDecimal(GetDecimalNullValue(txtExpansionBuildingValue.InnerHtml.Trim().TrimStart()));
                decimal ExpansionplantMechValue = Convert.ToDecimal(GetDecimalNullValue(txtExpansionplantMechValue.InnerHtml.Trim().TrimStart()));
                decimal ExpansionInvothers = Convert.ToDecimal(GetDecimalNullValue(txtExpansionInvothers.InnerHtml.Trim().TrimStart()));

                lblExpansionInvTot.InnerHtml = (ExpansionLandValue + ExpansionBuildingValue + ExpansionplantMechValue + ExpansionInvothers).ToString();
                lblCurrInvTot.InnerHtml = (currInvLandValue + currInvBuldvalue + currInvplantMechValue + currentInvothers).ToString();

                try
                {
                    txtExpansionLandPer.InnerHtml = ((float)System.Math.Round((ExpansionLandValue / currInvLandValue) * 100, 2)).ToString();// ("#.##");
                    if (txtExpansionLandPer.InnerHtml == "∞" || txtExpansionLandPer.InnerHtml == "0")
                    {
                        txtExpansionLandPer.InnerHtml = "0";
                    }
                }
                catch (Exception ex)
                {
                    string errorMsg = ex.Message;
                    txtExpansionLandPer.InnerHtml = "0";
                }
                try
                {
                    txtExpansionBuildingPer.InnerHtml = ((float)System.Math.Round((ExpansionBuildingValue / currInvBuldvalue) * 100, 2)).ToString();//("#.##");
                    if (txtExpansionBuildingPer.InnerHtml == "∞" || txtExpansionBuildingPer.InnerHtml == "0")
                    {
                        txtExpansionBuildingPer.InnerHtml = "0";
                    }
                }
                catch (Exception ex)
                {
                    string errorMsg = ex.Message;
                }
                try
                {
                    txtExpansionPMPer.InnerHtml = ((float)System.Math.Round((ExpansionplantMechValue / currInvplantMechValue) * 100, 2)).ToString();//("#.##");
                    if (txtExpansionPMPer.InnerHtml == "∞" || txtExpansionPMPer.InnerHtml == "0")
                    {
                        txtExpansionPMPer.InnerHtml = "0";
                    }
                }
                catch (Exception ex)
                {
                    string errorMsg = ex.Message;
                    txtExpansionPMPer.InnerHtml = "0";
                }
                try
                {
                    txtExpansionOthersPer.InnerHtml = ((float)System.Math.Round((ExpansionInvothers / currentInvothers) * 100, 2)).ToString();//("#.##");
                    if (txtExpansionOthersPer.InnerHtml == "∞" || txtExpansionOthersPer.InnerHtml == "0")
                    {
                        txtExpansionOthersPer.InnerHtml = "0";
                    }
                }
                catch (Exception ex)
                {
                    string errorMsg = ex.Message;
                    txtExpansionOthersPer.InnerHtml = "0";
                }
                decimal ExpansionInvTot = Convert.ToDecimal(GetDecimalNullValue(lblExpansionInvTot.InnerHtml.Trim().TrimStart()));
                decimal CurrInvTot = Convert.ToDecimal(GetDecimalNullValue(lblCurrInvTot.InnerHtml.Trim().TrimStart()));
                try
                {
                    txtExpansionTotalPer.InnerHtml = ((float)System.Math.Round((ExpansionInvTot / CurrInvTot) * 100, 2)).ToString();//("#.##");
                    if (txtExpansionTotalPer.InnerHtml == "∞" || txtExpansionTotalPer.InnerHtml == "0")
                    {
                        txtExpansionTotalPer.InnerHtml = "0";
                    }
                }
                catch (Exception ex)
                {
                    string errorMsg = ex.Message;
                    txtExpansionTotalPer.InnerHtml = "0";
                }
            }
        }
        public string GetDecimalNullValue(string Input)
        {
            string InputValue = "";

            InputValue = (Input != "") ? Input : "0";

            return InputValue;
        }
        protected void ddlindustryStatus(string SelectedValue, string TextileProcessName)
        {
            try
            {
                if (SelectedValue == "1")
                {

                    // Investment 

                    trFixedCapitalexpansion.Visible = false;
                    //trFixedCapitalland.Visible = false;
                    trFixedCapitalBuilding.Visible = false;
                    trFixedCapitalMach.Visible = false;

                    //Td3.Visible = false;
                    Td4.Visible = false;

                    trFixedCapitalexpnPercent.Visible = false;
                    txtbuildcapacityPercet.Visible = false;
                    trFixedCapitMachPercent.Visible = false;
                    trFixedCapitBuildPercent.Visible = false;



                    thExistingActual.Visible = false;
                    thExistingLandActual.Visible = false;
                    thExistingBuildingActual.Visible = false;
                    thExistingPMActual.Visible = false;
                    thExistingOthersActual.Visible = false;
                    thExistingTotalActual.Visible = false;

                    trActualCapitalexpnPercent.Visible = false;
                    thExpansionLandActualPer.Visible = false;
                    thExpansionBuildingPer.Visible = false;
                    thExpansionPMPer.Visible = false;
                    thExpansionOthersPer.Visible = false;
                    thExpansionTotalPer.Visible = false;


                    thExpansionActual.InnerHtml = "New Enterprise Value (in Rs.)";
                    // Power
                    //ddlIspowApplicable_SelectedIndexChanged(sender, e);
                }
                else if (SelectedValue == "2")
                {

                    trFixedCapitalexpansion.Visible = true;
                    //trFixedCapitalland.Visible = true;
                    trFixedCapitalBuilding.Visible = true;
                    trFixedCapitalMach.Visible = true;

                    //Td3.Visible = true;
                    Td4.Visible = true;

                    trFixedCapitalexpnPercent.Visible = true;
                    txtbuildcapacityPercet.Visible = true;
                    trFixedCapitMachPercent.Visible = true;
                    trFixedCapitBuildPercent.Visible = true;

                    trFixedCapitalexpansion.InnerHtml = "Expansion Enterprise Value (in Rs.)";
                    trFixedCapitalexpnPercent.InnerHtml = "% of Increase Under Expansion Enterprise";


                    thExistingActual.Visible = true;
                    thExistingLandActual.Visible = true;
                    thExistingBuildingActual.Visible = true;
                    thExistingPMActual.Visible = true;
                    thExistingOthersActual.Visible = true;
                    thExistingTotalActual.Visible = true;

                    trActualCapitalexpnPercent.Visible = true;
                    thExpansionLandActualPer.Visible = true;
                    thExpansionBuildingPer.Visible = true;
                    thExpansionPMPer.Visible = true;
                    thExpansionOthersPer.Visible = true;
                    thExpansionTotalPer.Visible = true;

                    thExpansionActual.InnerHtml = "Expansion Enterprise Value (in Rs.)";
                    trActualCapitalexpnPercent.InnerHtml = "% of Increase Under Expansion Enterprise";
                }
                else if (SelectedValue == "3" || SelectedValue == "4")
                {

                    trFixedCapitalexpansion.Visible = true;
                    //trFixedCapitalland.Visible = true;
                    trFixedCapitalBuilding.Visible = true;
                    trFixedCapitalMach.Visible = true;

                    //Td3.Visible = true;
                    Td4.Visible = true;

                    trFixedCapitalexpnPercent.Visible = true;
                    txtbuildcapacityPercet.Visible = true;
                    trFixedCapitMachPercent.Visible = true;
                    trFixedCapitBuildPercent.Visible = true;
                    // Power
                    //ddlIspowApplicable_SelectedIndexChanged(sender, e);

                    thExistingActual.Visible = true;
                    thExistingLandActual.Visible = true;
                    thExistingBuildingActual.Visible = true;
                    thExistingPMActual.Visible = true;
                    thExistingOthersActual.Visible = true;
                    thExistingTotalActual.Visible = true;

                    trActualCapitalexpnPercent.Visible = true;
                    thExpansionLandActualPer.Visible = true;
                    thExpansionBuildingPer.Visible = true;
                    thExpansionPMPer.Visible = true;
                    thExpansionOthersPer.Visible = true;
                    thExpansionTotalPer.Visible = true;

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void TextBox33_TextChanged(object sender, EventArgs e)
        {
            if (TextBox37.Text == "")
            {
                TextBox37.Text = "0";
            }
            if (TextBox41.Text == "")
            {
                TextBox41.Text = "0";
            }
            if (TextBox44.Text == "")
            {
                TextBox44.Text = "0";
            }

            TextBox1.Text = (Convert.ToDecimal(TextBox33.Text) + Convert.ToDecimal(TextBox37.Text) + Convert.ToDecimal(TextBox41.Text) + Convert.ToDecimal(TextBox44.Text)).ToString();
        }
        protected void TextBox56_TextChanged(object sender, EventArgs e)
        {
            if (TextBox57.Text == "")
            {
                TextBox57.Text = "0";
            }
            if (TextBox58.Text == "")
            {
                TextBox58.Text = "0";
            }
            if (TextBox45.Text == "")
            {
                TextBox45.Text = "0";
            }
            TextBox2.Text = (Convert.ToDecimal(TextBox56.Text) + Convert.ToDecimal(TextBox57.Text) + Convert.ToDecimal(TextBox58.Text) + Convert.ToDecimal(TextBox45.Text)).ToString();
        }
        protected void TextBox37_TextChanged(object sender, EventArgs e)
        {
            if (TextBox33.Text == "")
            {
                TextBox33.Text = "0";
            }
            if (TextBox41.Text == "")
            {
                TextBox41.Text = "0";
            }
            if (TextBox44.Text == "")
            {
                TextBox44.Text = "0";
            }
            TextBox1.Text = (Convert.ToDecimal(TextBox33.Text) + Convert.ToDecimal(TextBox37.Text) + Convert.ToDecimal(TextBox41.Text) + Convert.ToDecimal(TextBox44.Text)).ToString();
        }
        protected void TextBox57_TextChanged(object sender, EventArgs e)
        {
            if (TextBox56.Text == "")
            {
                TextBox56.Text = "0";
            }
            if (TextBox58.Text == "")
            {
                TextBox58.Text = "0";
            }
            if (TextBox45.Text == "")
            {
                TextBox45.Text = "0";
            }
            TextBox2.Text = (Convert.ToDecimal(TextBox56.Text) + Convert.ToDecimal(TextBox57.Text) + Convert.ToDecimal(TextBox58.Text) + Convert.ToDecimal(TextBox45.Text)).ToString();
        }
        protected void TextBox41_TextChanged(object sender, EventArgs e)
        {
            if (TextBox33.Text == "")
            {
                TextBox33.Text = "0";
            }
            if (TextBox37.Text == "")
            {
                TextBox37.Text = "0";
            }
            if (TextBox44.Text == "")
            {
                TextBox44.Text = "0";
            }
            TextBox1.Text = (Convert.ToDecimal(TextBox33.Text) + Convert.ToDecimal(TextBox37.Text) + Convert.ToDecimal(TextBox41.Text) + Convert.ToDecimal(TextBox44.Text)).ToString();
        }
        protected void TextBox58_TextChanged(object sender, EventArgs e)
        {
            if (TextBox56.Text == "")
            {
                TextBox56.Text = "0";
            }
            if (TextBox57.Text == "")
            {
                TextBox57.Text = "0";
            }
            if (TextBox45.Text == "")
            {
                TextBox45.Text = "0";
            }
            TextBox2.Text = (Convert.ToDecimal(TextBox56.Text) + Convert.ToDecimal(TextBox57.Text) + Convert.ToDecimal(TextBox58.Text) + Convert.ToDecimal(TextBox45.Text)).ToString();
        }
        protected void TextBox44_TextChanged(object sender, EventArgs e)
        {
            if (TextBox33.Text == "")
            {
                TextBox33.Text = "0";
            }
            if (TextBox37.Text == "")
            {
                TextBox37.Text = "0";
            }
            if (TextBox41.Text == "")
            {
                TextBox41.Text = "0";
            }
            TextBox1.Text = (Convert.ToDecimal(TextBox33.Text) + Convert.ToDecimal(TextBox37.Text) + Convert.ToDecimal(TextBox41.Text) + Convert.ToDecimal(TextBox44.Text)).ToString();
        }
        protected void TextBox45_TextChanged(object sender, EventArgs e)
        {
            if (TextBox56.Text == "")
            {
                TextBox56.Text = "0";
            }
            if (TextBox57.Text == "")
            {
                TextBox57.Text = "0";
            }
            if (TextBox58.Text == "")
            {
                TextBox58.Text = "0";
            }
            TextBox2.Text = (Convert.ToDecimal(TextBox56.Text) + Convert.ToDecimal(TextBox57.Text) + Convert.ToDecimal(TextBox58.Text) + Convert.ToDecimal(TextBox45.Text)).ToString();
        }
        protected void rdbFinYearBothList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdbFinYearBothList.SelectedIndex == 1)
                {
                    if (lblTypeofApplicant.InnerText == "Expansion")
                    {
                        tbl_monthyeardataExpansion.Visible = true;
                        tblNewUnit.Visible = false;
                    }
                    if (lblTypeofApplicant.InnerText == "New")
                    {
                        tbl_monthyeardataExpansion.Visible = false;
                        tblNewUnit.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public void CalculatationEnterprise1(string Step)
        {
            try
            {
                decimal PlantMachValexisting = 0;
                decimal PlantMachValexpansion = 0;
                decimal PlantMachValFinal = 0;


                decimal landexisting = 0, landcapacity = 0;

                decimal buildingexisting = 0, buildingcapacity = 0;

                decimal Othernew = 0, OtherExisting = 0;

                decimal PlantMachValPer = 0;
                decimal landcapacityPer = 0;
                decimal buildingcapacityPer = 0;
                decimal OthernewPer = 0;

                if (Step == "1")
                {
                    if (txtlandexisting.InnerHtml != null && txtlandexisting.InnerHtml != "" && txtlandexisting.InnerHtml != string.Empty)
                    {
                        landexisting = Convert.ToDecimal(txtlandexisting.InnerHtml.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        landexisting = 0;
                    }
                    if (txtbuildingexisting.InnerHtml != null && txtbuildingexisting.InnerHtml != "" && txtbuildingexisting.InnerHtml != string.Empty)
                    {
                        buildingexisting = Convert.ToDecimal(txtbuildingexisting.InnerHtml.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        buildingexisting = 0;
                    }

                    if (txtplantexisting.InnerHtml != null && txtplantexisting.InnerHtml != "" && txtplantexisting.InnerHtml != string.Empty)
                    {
                        PlantMachValexisting = Convert.ToDecimal(txtplantexisting.InnerHtml.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        PlantMachValexisting = 0;
                    }
                    //if (txtnewothers.InnerHtml != null && txtnewothers.InnerHtml != "" && txtnewothers.InnerHtml != string.Empty)
                    //{
                    //    Othernew = Convert.ToDecimal(txtnewothers.InnerHtml.Trim());  // expansion Plant Mach value   
                    //}
                    //else
                    //{
                    //    Othernew = 0;
                    //}

                    PlantMachValFinal = (PlantMachValexisting + landexisting + buildingexisting + Othernew);
                    lblnewinv.InnerHtml = PlantMachValFinal.ToString();
                }
                else if (Step == "2")
                {
                    //--------------------------------
                    if (txtlandcapacity.InnerHtml != null && txtlandcapacity.InnerHtml != "" && txtlandcapacity.InnerHtml != string.Empty)
                    {
                        landcapacity = Convert.ToDecimal(txtlandcapacity.InnerHtml.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        landcapacity = 0;
                    }
                    if (txtbuildingcapacity.InnerHtml != null && txtbuildingcapacity.InnerHtml != "" && txtbuildingcapacity.InnerHtml != string.Empty)
                    {
                        buildingcapacity = Convert.ToDecimal(txtbuildingcapacity.InnerHtml.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        buildingcapacity = 0;
                    }

                    // -------------------------------

                    if (txtplantcapacity.InnerHtml != null && txtplantcapacity.InnerHtml != "" && txtplantcapacity.InnerHtml != string.Empty)
                    {
                        PlantMachValexpansion = Convert.ToDecimal(txtplantcapacity.InnerHtml.Trim());  // expansion Plant Mach value   
                    }
                    else
                    {
                        PlantMachValexpansion = 0;
                    }
                    //-----------------


                    //if (txtexistother.InnerHtml != null && txtexistother.InnerHtml != "" && txtexistother.InnerHtml != string.Empty)
                    //{
                    //    OtherExisting = Convert.ToDecimal(txtexistother.InnerHtml.Trim());  // expansion Plant Mach value   
                    //}
                    //else
                    //{
                    //    OtherExisting = 0;
                    //}
                    PlantMachValFinal = (PlantMachValexpansion + landcapacity + buildingcapacity + OtherExisting);
                    lblexpinv.InnerHtml = PlantMachValFinal.ToString();
                }
                else if (Step == "3")
                {
                    if (txtlandpercentage.InnerHtml != null && txtlandpercentage.InnerHtml != "" && txtlandpercentage.InnerHtml != string.Empty)
                    {
                        landcapacityPer = Convert.ToDecimal(txtlandpercentage.InnerHtml.Trim());  // expansion Plant Mach value   
                    }
                    else
                    {
                        landcapacityPer = 0;
                    }

                    if (txtbuildingpercentage.InnerHtml != null && txtbuildingpercentage.InnerHtml != "" && txtbuildingpercentage.InnerHtml != string.Empty)
                    {
                        buildingcapacityPer = Convert.ToDecimal(txtbuildingpercentage.InnerHtml.Trim());  // expansion Plant Mach value   
                    }
                    else
                    {
                        buildingcapacityPer = 0;
                    }

                    if (txtplantpercentage.InnerHtml != null && txtplantpercentage.InnerHtml != "" && txtplantpercentage.InnerHtml != string.Empty)
                    {
                        PlantMachValPer = Convert.ToDecimal(txtplantpercentage.InnerHtml.Trim());  // expansion Plant Mach value   
                    }
                    else
                    {
                        PlantMachValPer = 0;
                    }

                    //if (txtotherpersangage.InnerHtml != null && txtotherpersangage.InnerHtml != "" && txtotherpersangage.InnerHtml != string.Empty)
                    //{
                    //    OthernewPer = Convert.ToDecimal(txtotherpersangage.InnerHtml.Trim());  // expansion Plant Mach value   
                    //}
                    //else
                    //{
                    //    OthernewPer = 0;
                    //}

                    PlantMachValFinal = Convert.ToDecimal((landcapacityPer + buildingcapacityPer + PlantMachValPer + OthernewPer) / 3);

                    lbltotperinv.InnerHtml = PlantMachValFinal.ToString("#.##");
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                //lblmsg0.InnerHtml = ex.Message;
                //Failure.Visible = true;
                //success.Visible = false;
            }
        }
        protected void txtemployement_TextChanged(object sender, EventArgs e)
        {
            TTAPCategory();
            CapitalsubsidyCalculation();
        }
        public void TTAPCategory()
        {
            int TotalEmployement = 0;
            double totalinvestment = 0.00;
            if (txtemployement.Text != "" && txtemployement.Text != null)
            {
                TotalEmployement = Convert.ToInt32(txtemployement.Text);
            }
            if (TextBox2.Text != "" && TextBox2.Text != null)
            {
                totalinvestment = Convert.ToDouble(TextBox2.Text);
            }

            if (totalinvestment > 0)
            {
                totalinvestment = ((totalinvestment + 0.00) / 10000000);
            }

            string NatureOfIndustry = "";
            string Category = "";
            if (ddlIndustryStatus.SelectedValue == "1")
            {
                NatureOfIndustry = ddlTextileProcessType.SelectedValue;
            }
            else
            {
                NatureOfIndustry = ddlTextileProcessType.SelectedValue;
            }

            if (totalinvestment > 200 || TotalEmployement >= 1000)
            {
                Category = "A5";
                rdcategoryofunit.SelectedValue = "A5";
            }
            else if ((totalinvestment > 100 && totalinvestment <= 200) || TotalEmployement >= 500)
            {
                Category = "A4";
                rdcategoryofunit.SelectedValue = "A4";
            }
            else if ((totalinvestment > 50 && totalinvestment <= 100) || TotalEmployement >= 300)
            {
                Category = "A3";
                rdcategoryofunit.SelectedValue = "A3";
            }
            else if ((totalinvestment > 10 && totalinvestment <= 50) && (TotalEmployement > 50) && NatureOfIndustry != "3")
            {
                Category = "A2";
                rdcategoryofunit.SelectedValue = "A2";
            }
            else if (((totalinvestment > 10 && totalinvestment <= 50) || (TotalEmployement > 50)) && NatureOfIndustry == "3")
            {
                Category = "A2";
                rdcategoryofunit.SelectedValue = "A2";
            }
            else if (totalinvestment <= 10 && TotalEmployement >= 50 && NatureOfIndustry != "3")
            {
                Category = "A1";
                rdcategoryofunit.SelectedValue = "A1";
            }
            else if ((totalinvestment <= 10 || TotalEmployement >= 50) && NatureOfIndustry == "3")
            {
                Category = "A1";
                rdcategoryofunit.SelectedValue = "A1";
            }

            // lblEnterpriseCategory.Text = Category;
            HiddenFieldEnterpriseCategory.Value = Category;
            //Session["SCategoryofUnit"] = Category;
        }
        protected void ddlIndustryStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            TTAPCategory();
            CapitalsubsidyCalculation();
        }
        public void CapitalsubsidyCalculation()
        {
            try
            {
            }
            catch (Exception ex)
            {

            }
        }
        protected void rdlmv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdlmv.SelectedValue != "")
                {
                    trmenwomen.Visible = true;
                    //rdmenwomen.SelectedValue = "";
                    //rdeligibility.SelectedValue = "";
                    rdmenwomen.Focus();
                    rdmenwomen.ClearSelection();
                    rdeligibility.ClearSelection();
                    TextBox59.Text = "";
                    txt423guideline.Text = "";
                    treligibility.Visible = false;


                }
                else
                {
                    trmenwomen.Visible = false;
                    treligibility.Visible = false;
                }


            }
            catch (Exception ex)
            {
            }
        }
        protected void rdmenwomen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdmenwomen.SelectedValue != "")
                {
                    treligibility.Visible = true;
                    //trexpansion.Visible = true;
                    if (rdeligibility.SelectedValue != "")
                    {
                        //rdeligibility.SelectedValue = "";
                        rdeligibility.ClearSelection();
                        TextBox56.Text = "";
                        TextBox56_TextChanged(sender, e);
                    }
                    rdeligibility.Focus();
                }
                else
                {
                    treligibility.Visible = false;
                    //trexpansion.Visible = false;
                }

            }
            catch (Exception ex)
            {
            }
        }
        protected void rdeligibility_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TTAPCategory();
                CapitalsubsidyCalculation();
            }
            catch (Exception ex)
            {
            }

        }
        protected void rdcoventinaltech_SelectedIndexChanged(object sender, EventArgs e)
        {
            TTAPCategory();
            CapitalsubsidyCalculation();
        }
        protected void rdcategoryofunit_SelectedIndexChanged(object sender, EventArgs e)
        {
            TTAPCategory();
            CapitalsubsidyCalculation();

        } 
        protected void ddlTextileProcessType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TTAPCategory();
            CapitalsubsidyCalculation();
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string IncentiveId = "48440";
            string SubIncentiveId = "1";

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

        protected void txt_grdyear1rateperunit_TextChanged1(object sender, EventArgs e)
        {
            //(TextBox7775.Text).ToString();

            //if (Convert.ToDecimal(TextBox7775.Text) < Convert.ToDecimal(txt_grdyear1rateperunit.Text))//txt_grdyear1eligibleunits.Text 
            //{
            txt_grdyear1eligiblerateofreimbursement.Text = (Convert.ToDecimal(txt_grdyear1rateperunit.Text) - Convert.ToDecimal(TextBox7775.Text)).ToString();




            //}
            //else if (Convert.ToDecimal(txt_grdyear1rateperunit.Text) < Convert.ToDecimal(TextBox7775.Text))
            //{
            //    txt_grdyear1eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear1rateperunit.Text)).ToString();

            //}
            //else if (Convert.ToDecimal(txt_grdyear1rateperunit.Text) == Convert.ToDecimal(TextBox7775.Text))
            //{
            //    txt_grdyear1eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear1rateperunit.Text)).ToString();

            //}
            if (txt_grdyear1eligiblerateofreimbursement.Text != "" && txt_grdyear1eligibleamountforreimbursement.Text != "")
            {
                TextBox75.Text = ((Convert.ToDecimal(txt_grdyear1eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear1eligibleamountforreimbursement.Text))).ToString();
            }


        }

        protected void txt_grdyear2rateperunit_TextChanged1(object sender, EventArgs e)
        {
            //if (Convert.ToDecimal(TextBox7775.Text) < Convert.ToDecimal(txt_grdyear2rateperunit.Text))//txt_grdyear1eligibleunits.Text 
            //{
            txt_grdyear2eligiblerateofreimbursement.Text = (Convert.ToDecimal(txt_grdyear2rateperunit.Text) - Convert.ToDecimal(TextBox7775.Text)).ToString();

            //}
            //else if (Convert.ToDecimal(txt_grdyear2rateperunit.Text) < Convert.ToDecimal(TextBox7775.Text))
            //{
            //    txt_grdyear2eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear2rateperunit.Text)).ToString();

            //}
            //else if (Convert.ToDecimal(txt_grdyear2rateperunit.Text) == Convert.ToDecimal(TextBox7775.Text))
            //{
            //    txt_grdyear2eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear2rateperunit.Text)).ToString();

            //}

            if (txt_grdyear2eligiblerateofreimbursement.Text != "" && txt_grdyear2eligibleamountforreimbursement.Text != "")
            {
                TextBox76.Text = ((Convert.ToDecimal(txt_grdyear2eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear2eligibleamountforreimbursement.Text))).ToString();
            }


        }

        protected void txt_grdyear3rateperunit_TextChanged1(object sender, EventArgs e)
        {
            //if (Convert.ToDecimal(TextBox7775.Text) < Convert.ToDecimal(txt_grdyear3rateperunit.Text))//txt_grdyear1eligibleunits.Text 
            //{
            txt_grdyear3eligiblerateofreimbursement.Text = (Convert.ToDecimal(txt_grdyear3rateperunit.Text) - Convert.ToDecimal(TextBox7775.Text)).ToString();

            //}
            //else if (Convert.ToDecimal(txt_grdyear3rateperunit.Text) < Convert.ToDecimal(TextBox7775.Text))
            //{
            //    txt_grdyear3eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear3rateperunit.Text)).ToString();

            //}
            //else if (Convert.ToDecimal(txt_grdyear3rateperunit.Text) == Convert.ToDecimal(TextBox7775.Text))
            //{
            //    txt_grdyear3eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear3rateperunit.Text)).ToString();

            //}

            if (txt_grdyear3eligiblerateofreimbursement.Text != "" && txt_grdyear3eligibleamountforreimbursement.Text != "")
            {
                TextBox77.Text = ((Convert.ToDecimal(txt_grdyear3eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear3eligibleamountforreimbursement.Text))).ToString();
            }

        }

        protected void txt_grdyear4rateperunit_TextChanged1(object sender, EventArgs e)
        {
            //if (Convert.ToDecimal(TextBox7775.Text) < Convert.ToDecimal(txt_grdyear4rateperunit.Text))//txt_grdyear1eligibleunits.Text 
            //{
            txt_grdyear4eligiblerateofreimbursement.Text = (Convert.ToDecimal(txt_grdyear4rateperunit.Text) - Convert.ToDecimal(TextBox7775.Text)).ToString();

            //}
            //else if (Convert.ToDecimal(txt_grdyear4rateperunit.Text) < Convert.ToDecimal(TextBox7775.Text))
            //{
            //    txt_grdyear4eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear4rateperunit.Text)).ToString();

            //}
            //else if (Convert.ToDecimal(txt_grdyear4rateperunit.Text) == Convert.ToDecimal(TextBox7775.Text))
            //{
            //    txt_grdyear4eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear4rateperunit.Text)).ToString();

            //}
            if (txt_grdyear4eligiblerateofreimbursement.Text != "" && txt_grdyear4eligibleamountforreimbursement.Text != "")
            {
                TextBox78.Text = ((Convert.ToDecimal(txt_grdyear4eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear4eligibleamountforreimbursement.Text))).ToString();
            }

        }

        protected void txt_grdyear5rateperunit_TextChanged1(object sender, EventArgs e)
        {
            //if (Convert.ToDecimal(TextBox7775.Text) < Convert.ToDecimal(txt_grdyear5rateperunit.Text))//txt_grdyear1eligibleunits.Text 
            //{
            txt_grdyear5eligiblerateofreimbursement.Text = (Convert.ToDecimal(txt_grdyear5rateperunit.Text) - Convert.ToDecimal(TextBox7775.Text)).ToString();

            //}
            //else if (Convert.ToDecimal(txt_grdyear5rateperunit.Text) < Convert.ToDecimal(TextBox7775.Text))
            //{
            //    txt_grdyear5eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear5rateperunit.Text)).ToString();

            //}
            //else if (Convert.ToDecimal(txt_grdyear5rateperunit.Text) == Convert.ToDecimal(TextBox7775.Text))
            //{
            //    txt_grdyear5eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear5rateperunit.Text)).ToString();

            //}
            if (txt_grdyear5eligiblerateofreimbursement.Text != "" && txt_grdyear5eligibleamountforreimbursement.Text != "")
            {
                TextBox82.Text = ((Convert.ToDecimal(txt_grdyear5eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear5eligibleamountforreimbursement.Text))).ToString();
            }

        }

        protected void txt_grdyear6rateperunit_TextChanged1(object sender, EventArgs e)
        {
            //if (Convert.ToDecimal(TextBox7775.Text) < Convert.ToDecimal(txt_grdyear6rateperunit.Text))//txt_grdyear1eligibleunits.Text 
            //{
            txt_grdyear6eligiblerateofreimbursement.Text = (Convert.ToDecimal(txt_grdyear6rateperunit.Text) - Convert.ToDecimal(TextBox7775.Text)).ToString();

            //}
            //else if (Convert.ToDecimal(txt_grdyear6rateperunit.Text) < Convert.ToDecimal(TextBox7775.Text))
            //{
            //    txt_grdyear6eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear6rateperunit.Text)).ToString();

            //}
            //else if (Convert.ToDecimal(txt_grdyear6rateperunit.Text) == Convert.ToDecimal(TextBox7775.Text))
            //{
            //    txt_grdyear6eligiblerateofreimbursement.Text = (Convert.ToDecimal(TextBox7775.Text) - Convert.ToDecimal(txt_grdyear6rateperunit.Text)).ToString();

            //}
            if (txt_grdyear6eligiblerateofreimbursement.Text != "" && txt_grdyear6eligibleamountforreimbursement.Text != "")
            {
                TextBox83.Text = ((Convert.ToDecimal(txt_grdyear6eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear6eligibleamountforreimbursement.Text))).ToString();
            }


            if (TextBox75.Text != "" && TextBox76.Text != "" && TextBox77.Text != "" && TextBox78.Text != "" && TextBox82.Text != "" && TextBox83.Text != "")
            {
                lbl_grdtoteligibleamount.Text = (Convert.ToDecimal(TextBox75.Text) + Convert.ToDecimal(TextBox76.Text) + Convert.ToDecimal(TextBox77.Text) + Convert.ToDecimal(TextBox78.Text) + Convert.ToDecimal(TextBox82.Text) + Convert.ToDecimal(TextBox83.Text)).ToString();
            }

        }

        protected void txt_grdyear1eligibleamountforreimbursement_TextChanged(object sender, EventArgs e)
        {
            TextBox75.Text = (Convert.ToDecimal(txt_grdyear1eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear1eligibleamountforreimbursement.Text)).ToString();
            if (TextBox75.Text != "" && TextBox76.Text != "" && TextBox77.Text != "" && TextBox78.Text != "" && TextBox82.Text != "" && TextBox83.Text != "")
            {
                lbl_grdtoteligibleamount.Text = (Convert.ToDecimal(TextBox75.Text) + Convert.ToDecimal(TextBox76.Text) + Convert.ToDecimal(TextBox77.Text) + Convert.ToDecimal(TextBox78.Text) + Convert.ToDecimal(TextBox82.Text) + Convert.ToDecimal(TextBox83.Text)).ToString();
            }
        }

        protected void txt_grdyear2eligibleamountforreimbursement_TextChanged(object sender, EventArgs e)
        {
            TextBox76.Text = (Convert.ToDecimal(txt_grdyear2eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear2eligibleamountforreimbursement.Text)).ToString();
            if (TextBox75.Text != "" && TextBox76.Text != "" && TextBox77.Text != "" && TextBox78.Text != "" && TextBox82.Text != "" && TextBox83.Text != "")
            {
                lbl_grdtoteligibleamount.Text = (Convert.ToDecimal(TextBox75.Text) + Convert.ToDecimal(TextBox76.Text) + Convert.ToDecimal(TextBox77.Text) + Convert.ToDecimal(TextBox78.Text) + Convert.ToDecimal(TextBox82.Text) + Convert.ToDecimal(TextBox83.Text)).ToString();
            }
        }

        protected void txt_grdyear3eligibleamountforreimbursement_TextChanged(object sender, EventArgs e)
        {
            TextBox77.Text = (Convert.ToDecimal(txt_grdyear3eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear3eligibleamountforreimbursement.Text)).ToString();
            if (TextBox75.Text != "" && TextBox76.Text != "" && TextBox77.Text != "" && TextBox78.Text != "" && TextBox82.Text != "" && TextBox83.Text != "")
            {
                lbl_grdtoteligibleamount.Text = (Convert.ToDecimal(TextBox75.Text) + Convert.ToDecimal(TextBox76.Text) + Convert.ToDecimal(TextBox77.Text) + Convert.ToDecimal(TextBox78.Text) + Convert.ToDecimal(TextBox82.Text) + Convert.ToDecimal(TextBox83.Text)).ToString();
            }
        }

        protected void txt_grdyear4eligibleamountforreimbursement_TextChanged(object sender, EventArgs e)
        {
            TextBox78.Text = (Convert.ToDecimal(txt_grdyear4eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear4eligibleamountforreimbursement.Text)).ToString();
            if (TextBox75.Text != "" && TextBox76.Text != "" && TextBox77.Text != "" && TextBox78.Text != "" && TextBox82.Text != "" && TextBox83.Text != "")
            {
                lbl_grdtoteligibleamount.Text = (Convert.ToDecimal(TextBox75.Text) + Convert.ToDecimal(TextBox76.Text) + Convert.ToDecimal(TextBox77.Text) + Convert.ToDecimal(TextBox78.Text) + Convert.ToDecimal(TextBox82.Text) + Convert.ToDecimal(TextBox83.Text)).ToString();
            }
        }



        protected void txt_grdyear5eligibleamountforreimbursement_TextChanged(object sender, EventArgs e)
        {
            TextBox82.Text = (Convert.ToDecimal(txt_grdyear5eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear5eligibleamountforreimbursement.Text)).ToString();
            if (TextBox75.Text != "" && TextBox76.Text != "" && TextBox77.Text != "" && TextBox78.Text != "" && TextBox82.Text != "" && TextBox83.Text != "")
            {
                lbl_grdtoteligibleamount.Text = (Convert.ToDecimal(TextBox75.Text) + Convert.ToDecimal(TextBox76.Text) + Convert.ToDecimal(TextBox77.Text) + Convert.ToDecimal(TextBox78.Text) + Convert.ToDecimal(TextBox82.Text) + Convert.ToDecimal(TextBox83.Text)).ToString();
            }
        }

        protected void txt_grdyear6eligibleamountforreimbursement_TextChanged(object sender, EventArgs e)
        {
            TextBox83.Text = (Convert.ToDecimal(txt_grdyear6eligiblerateofreimbursement.Text) * Convert.ToDecimal(txt_grdyear6eligibleamountforreimbursement.Text)).ToString();
            if (TextBox75.Text != "" && TextBox76.Text != "" && TextBox77.Text != "" && TextBox78.Text != "" && TextBox82.Text != "" && TextBox83.Text != "")
            {
                lbl_grdtoteligibleamount.Text = (Convert.ToDecimal(TextBox75.Text) + Convert.ToDecimal(TextBox76.Text) + Convert.ToDecimal(TextBox77.Text) + Convert.ToDecimal(TextBox78.Text) + Convert.ToDecimal(TextBox82.Text) + Convert.ToDecimal(TextBox83.Text)).ToString();
            }
        }
        protected void txt_grdyear1unitsconsumed_TextChanged(object sender, EventArgs e)
        {
            //string errormsg = gridvaluestotal();
            //if (errormsg.Trim().TrimStart() != "")
            //{
            //    string message = "alert('" + errormsg + "')";
            //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
            //    return;
            //}

        }
        protected void TextBox7775_TextChanged(object sender, EventArgs e)
        {
            string test = Session["socialStatus"].ToString();
            txt_grdyear1eligibleunits.Text = TextBox7775.Text;
            txt_grdyear2eligibleunits.Text = TextBox7775.Text;
            txt_grdyear3eligibleunits.Text = TextBox7775.Text;
            txt_grdyear4eligibleunits.Text = TextBox7775.Text;
            txt_grdyear5eligibleunits.Text = TextBox7775.Text;
            txt_grdyear6eligibleunits.Text = TextBox7775.Text;

            if (lblSchemeName.Text == "IIPP Scheme 2005 - 2010")
            {
                if (Session["socialStatus"].ToString() == "General" || Session["socialStatus"].ToString() == "OBC")
                {
                    txt_grdyear1eligibleamountforreimbursement.Text = "0.75";
                    txt_grdyear2eligibleamountforreimbursement.Text = "0.75";
                    txt_grdyear3eligibleamountforreimbursement.Text = "0.75";
                    txt_grdyear4eligibleamountforreimbursement.Text = "0.75";
                    txt_grdyear5eligibleamountforreimbursement.Text = "0.75";
                    txt_grdyear6eligibleamountforreimbursement.Text = "0.75";



                    //txt_grdyear1eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear2eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear3eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear4eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear5eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear6eligibleamountforreimbursement.Enabled = false;



                }
                else if (Session["socialStatus"].ToString() == "SC" || Session["socialStatus"].ToString() == "ST")
                {


                    txt_grdyear1eligibleamountforreimbursement.Text = "1";
                    txt_grdyear2eligibleamountforreimbursement.Text = "1";
                    txt_grdyear3eligibleamountforreimbursement.Text = "1";
                    txt_grdyear4eligibleamountforreimbursement.Text = "1";
                    txt_grdyear5eligibleamountforreimbursement.Text = "1";
                    txt_grdyear6eligibleamountforreimbursement.Text = "1";



                    //txt_grdyear1eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear2eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear3eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear4eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear5eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear6eligibleamountforreimbursement.Enabled = false;


                }


            }

            else if (lblSchemeName.Text == "IIPP Scheme 2010 - 2015")
            {
                if (Session["socialStatus"].ToString() == "General" || Session["socialStatus"].ToString() == "OBC")
                {


                    txt_grdyear1eligibleamountforreimbursement.Text = "0.75";
                    txt_grdyear2eligibleamountforreimbursement.Text = "0.75";
                    txt_grdyear3eligibleamountforreimbursement.Text = "0.75";
                    txt_grdyear4eligibleamountforreimbursement.Text = "0.75";
                    txt_grdyear5eligibleamountforreimbursement.Text = "0.75";
                    txt_grdyear6eligibleamountforreimbursement.Text = "0.75";



                    //txt_grdyear1eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear2eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear3eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear4eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear5eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear6eligibleamountforreimbursement.Enabled = false;


                }
                else if (Session["socialStatus"].ToString() == "SC" || Session["socialStatus"].ToString() == "ST")
                {




                    txt_grdyear1eligibleamountforreimbursement.Text = "1";
                    txt_grdyear2eligibleamountforreimbursement.Text = "1";
                    txt_grdyear3eligibleamountforreimbursement.Text = "1";
                    txt_grdyear4eligibleamountforreimbursement.Text = "1";
                    txt_grdyear5eligibleamountforreimbursement.Text = "1";
                    txt_grdyear6eligibleamountforreimbursement.Text = "1";



                    //txt_grdyear1eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear2eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear3eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear4eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear5eligibleamountforreimbursement.Enabled = false;
                    //txt_grdyear6eligibleamountforreimbursement.Enabled = false;
                }

            }
            else if (lblSchemeName.Text == "T-IDEA")
            {

                txt_grdyear1eligibleamountforreimbursement.Text = "1";
                txt_grdyear2eligibleamountforreimbursement.Text = "1";
                txt_grdyear3eligibleamountforreimbursement.Text = "1";
                txt_grdyear4eligibleamountforreimbursement.Text = "1";
                txt_grdyear5eligibleamountforreimbursement.Text = "1";
                txt_grdyear6eligibleamountforreimbursement.Text = "1";



                //txt_grdyear1eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear2eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear3eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear4eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear5eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear6eligibleamountforreimbursement.Enabled = false;



            }
            else if (lblSchemeName.Text == "T-PRIDE")
            {


                txt_grdyear1eligibleamountforreimbursement.Text = "1.5";
                txt_grdyear2eligibleamountforreimbursement.Text = "1.5";
                txt_grdyear3eligibleamountforreimbursement.Text = "1.5";
                txt_grdyear4eligibleamountforreimbursement.Text = "1.5";
                txt_grdyear5eligibleamountforreimbursement.Text = "1.5";
                txt_grdyear6eligibleamountforreimbursement.Text = "1.5";



                //txt_grdyear1eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear2eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear3eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear4eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear5eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear6eligibleamountforreimbursement.Enabled = false;

            }
            else if (lblSchemeName.Text == "T-PRIDE(PHC)" && lblSchemeName.Text != "IIPP Scheme 2010 - 2015" && lblSchemeName.Text == "IIPP Scheme 2005 - 2010")
            {


                txt_grdyear1eligibleamountforreimbursement.Text = "1.5";
                txt_grdyear2eligibleamountforreimbursement.Text = "1.5";
                txt_grdyear3eligibleamountforreimbursement.Text = "1.5";
                txt_grdyear4eligibleamountforreimbursement.Text = "1.5";
                txt_grdyear5eligibleamountforreimbursement.Text = "1.5";
                txt_grdyear6eligibleamountforreimbursement.Text = "1.5";



                //txt_grdyear1eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear2eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear3eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear4eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear5eligibleamountforreimbursement.Enabled = false;
                //txt_grdyear6eligibleamountforreimbursement.Enabled = false;


            }


        }
        protected void txt_grdyear1amountpaid_TextChanged(object sender, EventArgs e)
        {
            if (txt_grdyear1rateperunit.Text != "" && txt_grdyear1amountpaid.Text != "")
            {
                txt_grdyear1basefixedunitspermonth.Text = (Convert.ToDecimal(txt_grdyear1rateperunit.Text) * Convert.ToDecimal(txt_grdyear1amountpaid.Text)).ToString();
            }
        }
        protected void txt_grdyear2amountpaid_TextChanged(object sender, EventArgs e)
        {
            if (txt_grdyear2rateperunit.Text != "" && txt_grdyear2amountpaid.Text != "")
            {
                //txt_grdyear2basefixedunitspermonth
                txt_grdyear2basefixedunitspermonth.Text = (Convert.ToDecimal(txt_grdyear2rateperunit.Text) * Convert.ToDecimal(txt_grdyear2amountpaid.Text)).ToString();
            }
        }

        protected void txt_grdyear3amountpaid_TextChanged(object sender, EventArgs e)
        {
            if (txt_grdyear3rateperunit.Text != "" && txt_grdyear3amountpaid.Text != "")
            {
                txt_grdyear3basefixedunitspermonth.Text = (Convert.ToDecimal(txt_grdyear3rateperunit.Text) * Convert.ToDecimal(txt_grdyear3amountpaid.Text)).ToString();
            }
        }

        protected void txt_grdyear4amountpaid_TextChanged(object sender, EventArgs e)
        {
            if (txt_grdyear4rateperunit.Text != "" && txt_grdyear4amountpaid.Text != "")
            {
                txt_grdyear4basefixedunitspermonth.Text = (Convert.ToDecimal(txt_grdyear4rateperunit.Text) * Convert.ToDecimal(txt_grdyear4amountpaid.Text)).ToString();
            }
        }

        protected void txt_grdyear5amountpaid_TextChanged(object sender, EventArgs e)
        {
            if (txt_grdyear5rateperunit.Text != "" && txt_grdyear5amountpaid.Text != "")
            {
                txt_grdyear5basefixedunitspermonth.Text = (Convert.ToDecimal(txt_grdyear5rateperunit.Text) * Convert.ToDecimal(txt_grdyear5amountpaid.Text)).ToString();
            }

        }

        protected void txt_grdyear6amountpaid_TextChanged(object sender, EventArgs e)
        {
            if (txt_grdyear6rateperunit.Text != "" && txt_grdyear6amountpaid.Text != "")
            {
                txt_grdyear6basefixedunitspermonth.Text = (Convert.ToDecimal(txt_grdyear6rateperunit.Text) * Convert.ToDecimal(txt_grdyear6amountpaid.Text)).ToString();
            }

        }

        protected void TextBox23_TextChanged(object sender, EventArgs e)
        {
            if (TextBox23.Text != "" && TextBox24.Text != "")
            {
                TextBox25.Text = (Convert.ToDecimal(TextBox23.Text) * Convert.ToDecimal(TextBox24.Text)).ToString();

                if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
                {
                    lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();

                    lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();


                }



            }
        }

        protected void TextBox50_TextChanged(object sender, EventArgs e)
        {
            if (TextBox50.Text != "" && TextBox51.Text != "")
            {
                TextBox52.Text = (Convert.ToDecimal(TextBox50.Text) * Convert.ToDecimal(TextBox51.Text)).ToString();
                if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
                {
                    lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();
                    lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();

                }



            }
        }

        protected void TextBox63_TextChanged(object sender, EventArgs e)
        {
            if (TextBox63.Text != "" && TextBox64.Text != "")
            {
                TextBox65.Text = (Convert.ToDecimal(TextBox63.Text) * Convert.ToDecimal(TextBox64.Text)).ToString();
                if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
                {
                    lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();
                    lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();

                }


            }
        }

        protected void TextBox71_TextChanged(object sender, EventArgs e)
        {
            if (TextBox71.Text != "" && TextBox72.Text != "")
            {
                TextBox73.Text = (Convert.ToDecimal(TextBox71.Text) * Convert.ToDecimal(TextBox72.Text)).ToString();
                if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
                {
                    lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();
                    lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();

                }
                //if (TextBox23.Text != "" && TextBox21.Text != "")
                //{
                //    TextBox28.Text = (Convert.ToDecimal(TextBox23.Text) * Convert.ToDecimal(TextBox21.Text)).ToString();
                //    lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();

                //}
                //if (TextBox50.Text != "" && TextBox22.Text != "")
                //{
                //    TextBox29.Text = (Convert.ToDecimal(TextBox50.Text) * Convert.ToDecimal(TextBox22.Text)).ToString();
                //    lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                //}
                //if (TextBox63.Text != "" && TextBox26.Text != "")
                //{
                //    TextBox49.Text = (Convert.ToDecimal(TextBox63.Text) * Convert.ToDecimal(TextBox26.Text)).ToString();
                //    lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                //}
                //if (TextBox71.Text != "" && TextBox27.Text != "")
                //{
                //    TextBox53.Text = (Convert.ToDecimal(TextBox71.Text) * Convert.ToDecimal(TextBox27.Text)).ToString();
                //    lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                //}
                //if (TextBox79.Text != "" && TextBox95.Text != "")
                //{
                //    TextBox54.Text = (Convert.ToDecimal(TextBox79.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                //    lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                //}
                //if (TextBox87.Text != "" && TextBox95.Text != "")
                //{
                //    TextBox55.Text = (Convert.ToDecimal(TextBox87.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                //    lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                //}



            }
        }

        protected void TextBox79_TextChanged(object sender, EventArgs e)
        {
            if (TextBox79.Text != "" && TextBox80.Text != "")
            {
                TextBox81.Text = (Convert.ToDecimal(TextBox79.Text) * Convert.ToDecimal(TextBox80.Text)).ToString();
                if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
                {
                    lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();
                    lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();

                }


            }
        }

        protected void TextBox87_TextChanged(object sender, EventArgs e)
        {
            if (TextBox87.Text != "" && TextBox88.Text != "")
            {
                TextBox89.Text = (Convert.ToDecimal(TextBox87.Text) * Convert.ToDecimal(TextBox88.Text)).ToString();
                if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
                {
                    lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();
                    lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();

                }


            }
        }
        protected void TextBox24_TextChanged(object sender, EventArgs e)
        {
            if (TextBox21.Text == "" || TextBox22.Text == "" || TextBox26.Text == "" || TextBox27.Text == "" || TextBox95.Text == "" || TextBox96.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all Eligible rate Re-imbursement per units to proceed further!');", true);
                TextBox23.Text = "";
                TextBox50.Text = "";
                TextBox63.Text = "";
                TextBox71.Text = "";
                TextBox79.Text = "";
                TextBox87.Text = "";

                TextBox24.Text = "";
                TextBox51.Text = "";
                TextBox64.Text = "";
                TextBox72.Text = "";
                TextBox80.Text = "";
                TextBox88.Text = "";
            }
            else
            {
                if (TextBox23.Text != "" && TextBox24.Text != "")
                {
                    TextBox25.Text = (Convert.ToDecimal(TextBox23.Text) * Convert.ToDecimal(TextBox24.Text)).ToString();

                    if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();

                        lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();


                    }

                    if (TextBox23.Text != "" && TextBox21.Text != "")
                    {
                        TextBox28.Text = (Convert.ToDecimal(TextBox23.Text) * Convert.ToDecimal(TextBox21.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }


                    }
                    if (TextBox50.Text != "" && TextBox22.Text != "")
                    {
                        TextBox29.Text = (Convert.ToDecimal(TextBox50.Text) * Convert.ToDecimal(TextBox22.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox63.Text != "" && TextBox26.Text != "")
                    {
                        TextBox49.Text = (Convert.ToDecimal(TextBox63.Text) * Convert.ToDecimal(TextBox26.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox71.Text != "" && TextBox27.Text != "")
                    {
                        TextBox53.Text = (Convert.ToDecimal(TextBox71.Text) * Convert.ToDecimal(TextBox27.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox79.Text != "" && TextBox95.Text != "")
                    {
                        TextBox54.Text = (Convert.ToDecimal(TextBox79.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox87.Text != "" && TextBox95.Text != "")
                    {
                        TextBox55.Text = (Convert.ToDecimal(TextBox87.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }




                }
            }

        }

        protected void TextBox51_TextChanged(object sender, EventArgs e)
        {
            if (TextBox21.Text == "" || TextBox22.Text == "" || TextBox26.Text == "" || TextBox27.Text == "" || TextBox95.Text == "" || TextBox96.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all Eligible rate Re-imbursement per units to proceed further!');", true);
                TextBox23.Text = "";
                TextBox50.Text = "";
                TextBox63.Text = "";
                TextBox71.Text = "";
                TextBox79.Text = "";
                TextBox87.Text = "";

                TextBox24.Text = "";
                TextBox51.Text = "";
                TextBox64.Text = "";
                TextBox72.Text = "";
                TextBox80.Text = "";
                TextBox88.Text = "";
            }
            else
            {
                if (TextBox50.Text != "" && TextBox51.Text != "")
                {
                    TextBox52.Text = (Convert.ToDecimal(TextBox50.Text) * Convert.ToDecimal(TextBox51.Text)).ToString();
                    if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();
                        lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();

                    }

                    if (TextBox23.Text != "" && TextBox21.Text != "")
                    {
                        TextBox28.Text = (Convert.ToDecimal(TextBox23.Text) * Convert.ToDecimal(TextBox21.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }


                    }
                    if (TextBox50.Text != "" && TextBox22.Text != "")
                    {
                        TextBox29.Text = (Convert.ToDecimal(TextBox50.Text) * Convert.ToDecimal(TextBox22.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox63.Text != "" && TextBox26.Text != "")
                    {
                        TextBox49.Text = (Convert.ToDecimal(TextBox63.Text) * Convert.ToDecimal(TextBox26.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox71.Text != "" && TextBox27.Text != "")
                    {
                        TextBox53.Text = (Convert.ToDecimal(TextBox71.Text) * Convert.ToDecimal(TextBox27.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox79.Text != "" && TextBox95.Text != "")
                    {
                        TextBox54.Text = (Convert.ToDecimal(TextBox79.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox87.Text != "" && TextBox95.Text != "")
                    {
                        TextBox55.Text = (Convert.ToDecimal(TextBox87.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }


                }
            }


        }

        protected void TextBox64_TextChanged(object sender, EventArgs e)
        {
            if (TextBox21.Text == "" || TextBox22.Text == "" || TextBox26.Text == "" || TextBox27.Text == "" || TextBox95.Text == "" || TextBox96.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all Eligible rate Re-imbursement per units to proceed further!');", true);
                TextBox23.Text = "";
                TextBox50.Text = "";
                TextBox63.Text = "";
                TextBox71.Text = "";
                TextBox79.Text = "";
                TextBox87.Text = "";

                TextBox24.Text = "";
                TextBox51.Text = "";
                TextBox64.Text = "";
                TextBox72.Text = "";
                TextBox80.Text = "";
                TextBox88.Text = "";
            }
            else
            {
                if (TextBox63.Text != "" && TextBox64.Text != "")
                {
                    TextBox65.Text = (Convert.ToDecimal(TextBox63.Text) * Convert.ToDecimal(TextBox64.Text)).ToString();
                    if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();
                        lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();

                    }
                    if (TextBox23.Text != "" && TextBox21.Text != "")
                    {
                        TextBox28.Text = (Convert.ToDecimal(TextBox23.Text) * Convert.ToDecimal(TextBox21.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }


                    }
                    if (TextBox50.Text != "" && TextBox22.Text != "")
                    {
                        TextBox29.Text = (Convert.ToDecimal(TextBox50.Text) * Convert.ToDecimal(TextBox22.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox63.Text != "" && TextBox26.Text != "")
                    {
                        TextBox49.Text = (Convert.ToDecimal(TextBox63.Text) * Convert.ToDecimal(TextBox26.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox71.Text != "" && TextBox27.Text != "")
                    {
                        TextBox53.Text = (Convert.ToDecimal(TextBox71.Text) * Convert.ToDecimal(TextBox27.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox79.Text != "" && TextBox95.Text != "")
                    {
                        TextBox54.Text = (Convert.ToDecimal(TextBox79.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox87.Text != "" && TextBox95.Text != "")
                    {
                        TextBox55.Text = (Convert.ToDecimal(TextBox87.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }



                }
            }
        }

        protected void TextBox72_TextChanged(object sender, EventArgs e)
        {
            if (TextBox21.Text == "" || TextBox22.Text == "" || TextBox26.Text == "" || TextBox27.Text == "" || TextBox95.Text == "" || TextBox96.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all Eligible rate Re-imbursement per units to proceed further!');", true);
                TextBox23.Text = "";
                TextBox50.Text = "";
                TextBox63.Text = "";
                TextBox71.Text = "";
                TextBox79.Text = "";
                TextBox87.Text = "";

                TextBox24.Text = "";
                TextBox51.Text = "";
                TextBox64.Text = "";
                TextBox72.Text = "";
                TextBox80.Text = "";
                TextBox88.Text = "";
            }
            else
            {
                if (TextBox71.Text != "" && TextBox72.Text != "")
                {
                    TextBox73.Text = (Convert.ToDecimal(TextBox71.Text) * Convert.ToDecimal(TextBox72.Text)).ToString();
                    if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();
                        lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();

                    }

                    if (TextBox23.Text != "" && TextBox21.Text != "")
                    {
                        TextBox28.Text = (Convert.ToDecimal(TextBox23.Text) * Convert.ToDecimal(TextBox21.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }


                    }
                    if (TextBox50.Text != "" && TextBox22.Text != "")
                    {
                        TextBox29.Text = (Convert.ToDecimal(TextBox50.Text) * Convert.ToDecimal(TextBox22.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox63.Text != "" && TextBox26.Text != "")
                    {
                        TextBox49.Text = (Convert.ToDecimal(TextBox63.Text) * Convert.ToDecimal(TextBox26.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox71.Text != "" && TextBox27.Text != "")
                    {
                        TextBox53.Text = (Convert.ToDecimal(TextBox71.Text) * Convert.ToDecimal(TextBox27.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox79.Text != "" && TextBox95.Text != "")
                    {
                        TextBox54.Text = (Convert.ToDecimal(TextBox79.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox87.Text != "" && TextBox95.Text != "")
                    {
                        TextBox55.Text = (Convert.ToDecimal(TextBox87.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }

                }
            }
        }

        protected void TextBox80_TextChanged(object sender, EventArgs e)
        {
            if (TextBox21.Text == "" || TextBox22.Text == "" || TextBox26.Text == "" || TextBox27.Text == "" || TextBox95.Text == "" || TextBox96.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all Eligible rate Re-imbursement per units to proceed further!');", true);
                TextBox23.Text = "";
                TextBox50.Text = "";
                TextBox63.Text = "";
                TextBox71.Text = "";
                TextBox79.Text = "";
                TextBox87.Text = "";

                TextBox24.Text = "";
                TextBox51.Text = "";
                TextBox64.Text = "";
                TextBox72.Text = "";
                TextBox80.Text = "";
                TextBox88.Text = "";
            }
            else
            {
                if (TextBox79.Text != "" && TextBox80.Text != "")
                {
                    TextBox81.Text = (Convert.ToDecimal(TextBox79.Text) * Convert.ToDecimal(TextBox80.Text)).ToString();
                    if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();
                        lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();

                    }

                    if (TextBox23.Text != "" && TextBox21.Text != "")
                    {
                        TextBox28.Text = (Convert.ToDecimal(TextBox23.Text) * Convert.ToDecimal(TextBox21.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }


                    }
                    if (TextBox50.Text != "" && TextBox22.Text != "")
                    {
                        TextBox29.Text = (Convert.ToDecimal(TextBox50.Text) * Convert.ToDecimal(TextBox22.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox63.Text != "" && TextBox26.Text != "")
                    {
                        TextBox49.Text = (Convert.ToDecimal(TextBox63.Text) * Convert.ToDecimal(TextBox26.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox71.Text != "" && TextBox27.Text != "")
                    {
                        TextBox53.Text = (Convert.ToDecimal(TextBox71.Text) * Convert.ToDecimal(TextBox27.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox79.Text != "" && TextBox95.Text != "")
                    {
                        TextBox54.Text = (Convert.ToDecimal(TextBox79.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox87.Text != "" && TextBox95.Text != "")
                    {
                        TextBox55.Text = (Convert.ToDecimal(TextBox87.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }

                }
            }
        }


        protected void TextBox88_TextChanged(object sender, EventArgs e)
        {
            if (TextBox21.Text == "" || TextBox22.Text == "" || TextBox26.Text == "" || TextBox27.Text == "" || TextBox95.Text == "" || TextBox96.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter all Eligible rate Re-imbursement per units to proceed further!');", true);
                TextBox23.Text = "";
                TextBox50.Text = "";
                TextBox63.Text = "";
                TextBox71.Text = "";
                TextBox79.Text = "";
                TextBox87.Text = "";

                TextBox24.Text = "";
                TextBox51.Text = "";
                TextBox64.Text = "";
                TextBox72.Text = "";
                TextBox80.Text = "";
                TextBox88.Text = "";
            }
            else
            {
                if (TextBox87.Text != "" && TextBox88.Text != "")
                {
                    TextBox89.Text = (Convert.ToDecimal(TextBox87.Text) * Convert.ToDecimal(TextBox88.Text)).ToString();
                    if (TextBox25.Text != "" && TextBox52.Text != "" && TextBox65.Text != "" && TextBox73.Text != "" && TextBox81.Text != "" && TextBox89.Text != "")
                    {
                        lblGmAmount0.Text = (Convert.ToDecimal(TextBox25.Text) + Convert.ToDecimal(TextBox52.Text) + Convert.ToDecimal(TextBox65.Text) + Convert.ToDecimal(TextBox73.Text) + Convert.ToDecimal(TextBox81.Text) + Convert.ToDecimal(TextBox89.Text)).ToString();
                        lblGmAmount.Text = Session["GM_Rcon_Amount"].ToString();

                    }

                    if (TextBox23.Text != "" && TextBox21.Text != "")
                    {
                        TextBox28.Text = (Convert.ToDecimal(TextBox23.Text) * Convert.ToDecimal(TextBox21.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }


                    }
                    if (TextBox50.Text != "" && TextBox22.Text != "")
                    {
                        TextBox29.Text = (Convert.ToDecimal(TextBox50.Text) * Convert.ToDecimal(TextBox22.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox63.Text != "" && TextBox26.Text != "")
                    {
                        TextBox49.Text = (Convert.ToDecimal(TextBox63.Text) * Convert.ToDecimal(TextBox26.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox71.Text != "" && TextBox27.Text != "")
                    {
                        TextBox53.Text = (Convert.ToDecimal(TextBox71.Text) * Convert.ToDecimal(TextBox27.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox79.Text != "" && TextBox95.Text != "")
                    {
                        TextBox54.Text = (Convert.ToDecimal(TextBox79.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }
                    if (TextBox87.Text != "" && TextBox95.Text != "")
                    {
                        TextBox55.Text = (Convert.ToDecimal(TextBox87.Text) * Convert.ToDecimal(TextBox95.Text)).ToString();
                        if (TextBox28.Text != "" && TextBox29.Text != "" && TextBox49.Text != "" && TextBox53.Text != "" && TextBox54.Text != "" && TextBox55.Text != "")
                        {
                            lblGmAmount0.Text = (Convert.ToDecimal(TextBox28.Text) + Convert.ToDecimal(TextBox29.Text) + Convert.ToDecimal(TextBox49.Text) + Convert.ToDecimal(TextBox53.Text) + Convert.ToDecimal(TextBox54.Text) + Convert.ToDecimal(TextBox55.Text)).ToString();
                        }

                    }

                }
            }

        }

        protected void txtTSSFCnorms423_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox59_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btm_previous_Click(object sender, EventArgs e)
        {

        }

        protected void BtnClearall_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {

        }
    }
}