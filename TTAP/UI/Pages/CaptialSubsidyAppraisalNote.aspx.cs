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
    public partial class CaptialSubsidyAppraisalNote : System.Web.UI.Page
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
                if (!IsPostBack)
                {
                    string incentiveid = "";
                    ViewState["UID"] = ObjLoginNewvo.uid;
                    if (Request.QueryString["IncentiveID"] != null)
                    {
                        incentiveid = Request.QueryString["IncentiveID"].ToString();
                    }
                    txtIncID.Text = incentiveid;
                    BindBesicdata(incentiveid, "1", "");
                    TextBox41_TextChanged(null, EventArgs.Empty);
                    DataSet dsnew1 = new DataSet();
                }
            }
            catch (Exception ex)
            {

            }
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
                    if (dsnew != null && dsnew.Tables.Count > 1 && dsnew.Tables[1].Rows.Count > 0)
                    {
                        txtGMAmount.Text = dsnew.Tables[1].Rows[0]["OfficerRecommendedAmount"].ToString();
                    }
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
                    if (dsnew1.Tables[0].Rows[0]["NumberofEmployees_Training_Subsidy"].ToString()  !="")
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
        protected void TextBox59_TextChanged(object sender, EventArgs e)
        {
            if (TextBox59.Text != "" && TextBox57.Text != "" && TextBox58.Text != "" && TextBox45.Text != "")
            {
                TTAPCategory();
                CapitalsubsidyCalculation();   
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please enter all the details in Abstract - Computed as eligible investment');", true);
                TextBox59.Text = "";
            }
        }

        public void CapitalsubsidyCalculation()
        {
            try
            {
                if (TextBox57.Text != "" && TextBox58.Text != "" && TextBox45.Text != "")
                {
                    Eligible.Visible = true;
                    trEligible.Visible = true;
                    tr4231.Visible = true;
                    tr4232.Visible = true;
                    tr4233.Visible = true;
                    if (ddlIndustryStatus.SelectedValue=="1")
                    {
                        if (rdcoventinaltech.SelectedValue == "Conventional Textile Unit")
                        {
                            if(rdcategoryofunit.SelectedValue=="A1")
                            {
                                if (rdlmv.SelectedValue == "GENERAL")
                                {
                                    if(rdmenwomen.SelectedValue== "Men")
                                    {
                                        trEligible.Visible = true;
                                        TextBox59.Text = "25";
                                        txtTSSFCnorms423.Text = "0";
                                        if (rdeligibility.SelectedValue == "Regular")
                                        {
                                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                            if (Convert.ToDecimal(txt423guideline.Text) >= 10000000)
                                            {
                                                txt423guideline.Text = "10000000";
                                            }
                                        }
                                        if (rdeligibility.SelectedValue == "Belated")
                                        {
                                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                            if (Convert.ToDecimal(txt423guideline.Text) >= 5000000)
                                            {
                                                txt423guideline.Text = "5000000";
                                            }

                                        }
                                        if (rdeligibility.SelectedValue == "OneYear")
                                        {
                                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                            
                                        }
                                    }                                   
                                }
                                else
                                {
                                    TextBox59.Text = "25";
                                    txtTSSFCnorms423.Text = "5";
                                    if (rdeligibility.SelectedValue == "Regular")
                                    {
                                        txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                        txtTSSFCnorms423.Text = (((Convert.ToDecimal(TextBox2.Text)) * 5) / 100).ToString(); 
                                    }
                                    if (rdeligibility.SelectedValue == "Belated")
                                    {
                                        txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                        txtTSSFCnorms423.Text = "5";
                                    }
                                    if (rdeligibility.SelectedValue == "OneYear")
                                    {
                                        txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                        txtTSSFCnorms423.Text = "5";
                                    }
                                }
                            }
                            txtvalue424.Text = (Convert.ToDecimal(txtTSSFCnorms423.Text) + Convert.ToDecimal(txt423guideline.Text)).ToString();
                        }
                        else
                        {
                            if (rdcategoryofunit.SelectedValue == "A1")
                            {
                                if (rdlmv.SelectedValue == "GENERAL")
                                {
                                    if (rdmenwomen.SelectedValue == "Men")
                                    {
                                        
                                        TextBox59.Text = "35";
                                        txtTSSFCnorms423.Text = "0";
                                        if (rdeligibility.SelectedValue == "Regular")
                                        {
                                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                            if (Convert.ToDecimal(txt423guideline.Text) >= 20000000)
                                            {
                                                txt423guideline.Text = "20000000";
                                            }
                                        }
                                        if (rdeligibility.SelectedValue == "Belated")
                                        {
                                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                            if (Convert.ToDecimal(txt423guideline.Text) >= 10000000)
                                            {
                                                txt423guideline.Text = "10000000";
                                            }

                                        }
                                        if (rdeligibility.SelectedValue == "OneYear")
                                        {
                                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();

                                        }
                                    }
                                }
                                else
                                {
                                    TextBox59.Text = "35";
                                    txtTSSFCnorms423.Text = "5";
                                    if (rdeligibility.SelectedValue == "Regular")
                                    {
                                        txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                        txtTSSFCnorms423.Text = (((Convert.ToDecimal(TextBox2.Text)) * 5) / 100).ToString();
                                    }
                                    if (rdeligibility.SelectedValue == "Belated")
                                    {
                                        txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                        txtTSSFCnorms423.Text = "5";
                                    }
                                    if (rdeligibility.SelectedValue == "OneYear")
                                    {
                                        txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                        txtTSSFCnorms423.Text = "5";
                                    }
                                }
                            }
                            else if (rdcategoryofunit.SelectedValue == "A2")
                            {
                                if (rdlmv.SelectedValue == "GENERAL")
                                {
                                    if (rdmenwomen.SelectedValue == "Men")
                                    {
                                        trEligible.Visible = true;
                                        TextBox59.Text = "35";
                                        txtTSSFCnorms423.Text = "0";
                                        if (rdeligibility.SelectedValue == "Regular")
                                        {
                                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                            if (Convert.ToDecimal(txt423guideline.Text) >= 50000000)
                                            {
                                                txt423guideline.Text = "50000000";
                                            }
                                        }
                                        if (rdeligibility.SelectedValue == "Belated")
                                        {
                                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                            if (Convert.ToDecimal(txt423guideline.Text) >= 25000000)
                                            {
                                                txt423guideline.Text = "25000000";
                                            }

                                        }
                                        if (rdeligibility.SelectedValue == "OneYear")
                                        {
                                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();

                                        }
                                    }
                                }
                                else
                                {
                                    TextBox59.Text = "35";
                                    txtTSSFCnorms423.Text = "5";
                                    if (rdeligibility.SelectedValue == "Regular")
                                    {
                                        txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                        txtTSSFCnorms423.Text = (((Convert.ToDecimal(TextBox2.Text)) * 5) / 100).ToString();
                                    }
                                    if (rdeligibility.SelectedValue == "Belated")
                                    {
                                        txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                        txtTSSFCnorms423.Text = "5";
                                    }
                                    if (rdeligibility.SelectedValue == "OneYear")
                                    {
                                        txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                        txtTSSFCnorms423.Text = "5";
                                    }
                                }
                            }
                            else if (rdcategoryofunit.SelectedValue == "A3")
                            {
                                if (rdlmv.SelectedValue == "GENERAL")
                                {
                                    if (rdmenwomen.SelectedValue == "Men")
                                    {
                                        trEligible.Visible = true;
                                        TextBox59.Text = "35";
                                        txtTSSFCnorms423.Text = "0";
                                        if (rdeligibility.SelectedValue == "Regular")
                                        {
                                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                            if (Convert.ToDecimal(txt423guideline.Text) >= 100000000)
                                            {
                                                txt423guideline.Text = "100000000";
                                            }
                                        }
                                        if (rdeligibility.SelectedValue == "Belated")
                                        {
                                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                            if (Convert.ToDecimal(txt423guideline.Text) >= 50000000)
                                            {
                                                txt423guideline.Text = "50000000";
                                            }

                                        }
                                        if (rdeligibility.SelectedValue == "OneYear")
                                        {
                                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();

                                        }
                                    }
                                }
                                else
                                {
                                    TextBox59.Text = "35";
                                    txtTSSFCnorms423.Text = "5";
                                    if (rdeligibility.SelectedValue == "Regular")
                                    {
                                        txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                        txtTSSFCnorms423.Text = (((Convert.ToDecimal(TextBox2.Text)) * 5) / 100).ToString();
                                    }
                                    if (rdeligibility.SelectedValue == "Belated")
                                    {
                                        txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                        txtTSSFCnorms423.Text = "5";
                                    }
                                    if (rdeligibility.SelectedValue == "OneYear")
                                    {
                                        txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                        txtTSSFCnorms423.Text = "5";
                                    }
                                }
                            }
                            else if (rdcategoryofunit.SelectedValue == "A4")
                            {
                                if (rdlmv.SelectedValue == "GENERAL")
                                {
                                    if (rdmenwomen.SelectedValue == "Men")
                                    {
                                        trEligible.Visible = true;
                                        TextBox59.Text = "35";
                                        txtTSSFCnorms423.Text = "0";
                                        if (rdeligibility.SelectedValue == "Regular")
                                        {
                                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                            if (Convert.ToDecimal(txt423guideline.Text) >= 200000000)
                                            {
                                                txt423guideline.Text = "200000000";
                                            }
                                        }
                                        if (rdeligibility.SelectedValue == "Belated")
                                        {
                                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                            if (Convert.ToDecimal(txt423guideline.Text) >= 100000000)
                                            {
                                                txt423guideline.Text = "100000000";
                                            }

                                        }
                                        if (rdeligibility.SelectedValue == "OneYear")
                                        {
                                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();

                                        }
                                    }
                                }
                                else
                                {
                                    TextBox59.Text = "35";
                                    txtTSSFCnorms423.Text = "5";
                                    if (rdeligibility.SelectedValue == "Regular")
                                    {
                                        txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                        txtTSSFCnorms423.Text = (((Convert.ToDecimal(TextBox2.Text)) * 5) / 100).ToString();
                                    }
                                    if (rdeligibility.SelectedValue == "Belated")
                                    {
                                        txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                        txtTSSFCnorms423.Text = "5";
                                    }
                                    if (rdeligibility.SelectedValue == "OneYear")
                                    {
                                        txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                        txtTSSFCnorms423.Text = "5";
                                    }
                                }
                            }
                            else if (rdcategoryofunit.SelectedValue == "A5")
                            {
                                if (rdlmv.SelectedValue == "GENERAL")
                                {
                                    if (rdmenwomen.SelectedValue == "Men")
                                    {
                                        trEligible.Visible = true;
                                        TextBox59.Text = "35";
                                        txtTSSFCnorms423.Text = "0";
                                        if (rdeligibility.SelectedValue == "Regular")
                                        {
                                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                            if (Convert.ToDecimal(txt423guideline.Text) >= 400000000)
                                            {
                                                txt423guideline.Text = "400000000";
                                            }
                                        }
                                        if (rdeligibility.SelectedValue == "Belated")
                                        {
                                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                            if (Convert.ToDecimal(txt423guideline.Text) >= 200000000)
                                            {
                                                txt423guideline.Text = "200000000";
                                            }

                                        }
                                        if (rdeligibility.SelectedValue == "OneYear")
                                        {
                                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();

                                        }
                                    }
                                }
                                else
                                {
                                    TextBox59.Text = "35";
                                    txtTSSFCnorms423.Text = "5";
                                    if (rdeligibility.SelectedValue == "Regular")
                                    {
                                        txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                        txtTSSFCnorms423.Text = (((Convert.ToDecimal(TextBox2.Text)) * 5) / 100).ToString();
                                    }
                                    if (rdeligibility.SelectedValue == "Belated")
                                    {
                                        txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                        txtTSSFCnorms423.Text = "5";
                                    }
                                    if (rdeligibility.SelectedValue == "OneYear")
                                    {
                                        txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                        txtTSSFCnorms423.Text = "5";
                                    }
                                }
                            }
                            txtvalue424.Text = (Convert.ToDecimal(txtTSSFCnorms423.Text) + Convert.ToDecimal(txt423guideline.Text)).ToString();
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void txtTSSFCnorms423_TextChanged(object sender, EventArgs e)
        {
            if (txtTSSFCnorms423.Text == "" || txtTSSFCnorms423.Text == null)
            {
                txtTSSFCnorms423.Text = "0";
            }

            txtvalue424.Text = (Convert.ToDecimal(txtTSSFCnorms423.Text) + Convert.ToDecimal(txt423guideline.Text)).ToString();
        }
        protected void btnsub_Click(object sender, EventArgs e)
        {
            // BindISCrrentClaimPeriodDtls(txtIncID.Text.ToString());
            BindBesicdata(txtIncID.Text.ToString(), "3", "");
        }
        public string ValidateControls()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (TextBox33.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Land as per approved costs \\n";
                slno = slno + 1;
            }
            if (TextBox37.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Buildingas per approved costs \\n";
                slno = slno + 1;
            }
            if (TextBox41.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Plant and Machineryas per approved costs \\n";
                slno = slno + 1;
            }
            if (TextBox44.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Technical Know-how feasibility studyas per approved costs \\n";
                slno = slno + 1;
            }
            if (TextBox56.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computed as eligible Investment \\n";
                slno = slno + 1;
            }
            if (TextBox57.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computed as eligible Investment \\n";
                slno = slno + 1;
            }
            if (TextBox58.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computed as eligible Investment \\n";
                slno = slno + 1;
            }
            if (TextBox45.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computed as eligible Investment \\n";
                slno = slno + 1;
            }
            if (txtemployement.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Employment \\n";
                slno = slno + 1;
            }
            if (ddlIndustryStatus.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Industry Status \\n";
                slno = slno + 1;
            }
            if (rdcoventinaltech.SelectedValue == "0" || rdcoventinaltech.SelectedValue == "" || rdcoventinaltech.SelectedValue == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Textile Type \\n";
                slno = slno + 1;
            }
            if (ddlTextileProcessType.SelectedValue == "0" || ddlTextileProcessType.SelectedValue == "" || ddlTextileProcessType.SelectedValue == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Nature of Industry \\n";
                slno = slno + 1;
            }
            if (rdcategoryofunit.SelectedValue == "0" || rdcategoryofunit.SelectedValue == "" || rdcategoryofunit.SelectedValue == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Category of Unit \\n";
                slno = slno + 1;
            }
            if (rdlmv.SelectedValue.TrimStart().TrimEnd().Trim() == "" || rdlmv.SelectedValue.TrimStart().TrimEnd().Trim() == "0" || rdlmv.SelectedValue.TrimStart().TrimEnd().Trim() == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Social Status \\n";
                slno = slno + 1;
            }
            if (rdmenwomen.SelectedValue.TrimStart().TrimEnd().Trim() == "" || rdmenwomen.SelectedValue.TrimStart().TrimEnd().Trim() == "0" || rdmenwomen.SelectedValue.TrimStart().TrimEnd().Trim() == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Gender \\n";
                slno = slno + 1;
            }
            if (rdeligibility.SelectedValue.TrimStart().TrimEnd().Trim() == "" || rdeligibility.SelectedValue.TrimStart().TrimEnd().Trim() == "0"|| rdeligibility.SelectedValue.TrimStart().TrimEnd().Trim() == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select type of Eligiblity \\n";
                slno = slno + 1;
            }
            if (txtGMAmount.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter GM Recommended Amount \\n";
                slno = slno + 1;
            }
            if (ddlDepartment.SelectedValue.TrimStart().TrimEnd().Trim() == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select whom you want to forward this to. \\n";
                slno = slno + 1;
            }
           /* if (hypWorksheet.NavigateUrl=="")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Upload Worksheet Pdf File \\n";
                slno = slno + 1;
            }*/

            return ErrorMsg;
        }
        protected void BtnSave_Click(object sender, EventArgs e)
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
                    string message = "alert('Appraisal note submitted successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    //..btn
                    BtnSave.Enabled = false;
                    BtnSave.Visible = false;
                    BtnClearall.Visible = false;
                    //Response.Redirect("~/ClerkDashboard.aspx");
                }
            }
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
                // TextBox txt_Eligibleamount = new TextBox();
                //objApprasialProperties.FINALELIGIBLEAMOUNT = Convert.ToDecimal(txt_Eligibleamount.Text);
                //AssignValuestoVosFromcontrols();
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
                objApprasialProperties.DATEOFPRODUCTION = lblDCPdate.InnerText;
                objApprasialProperties.DICFILLINGDATE = lblReceiptDate.InnerText;
                objApprasialProperties.PowerConnectionRlsDate = lblPowerConnectionReleaseDate.InnerText;
                objApprasialProperties.NAMEFINANCINGUNIT = lblUnitName.InnerText;

                objApprasialProperties.ApprovedLandCost = TextBox33.Text;
                objApprasialProperties.ApprovedBuildingCost = TextBox37.Text;
                objApprasialProperties.ApprovedPMCost = TextBox41.Text;
                objApprasialProperties.ApprovedKeyCost = TextBox44.Text;
                objApprasialProperties.ApprovedTotalCost = TextBox1.Text;
                objApprasialProperties.ComputedLandCost = TextBox56.Text;
                objApprasialProperties.ComputedBuildingCost = TextBox57.Text;
                objApprasialProperties.ComputedPMCost = TextBox58.Text;
                objApprasialProperties.ComputedKeyCost = TextBox45.Text;
                objApprasialProperties.ComputedTotalCost = TextBox2.Text;
                objApprasialProperties.EmploymentInspection = txtemployement.Text;

                objApprasialProperties.IndustryStatus = ddlIndustryStatus.SelectedItem.Text.ToString();
                objApprasialProperties.TextileTypeAsPerInspection = rdcoventinaltech.SelectedValue.ToString();
                objApprasialProperties.NatureAsPerInspection = ddlTextileProcessType.SelectedItem.Text.ToString();
                objApprasialProperties.CategoryAsPerInspection = rdcategoryofunit.SelectedValue.ToString();
                objApprasialProperties.SocialStatusAsPerInspection = rdlmv.SelectedValue.ToString();
                objApprasialProperties.GenderAsPerInspection = rdmenwomen.SelectedValue.ToString();
                objApprasialProperties.Type = rdeligibility.SelectedValue.ToString();
                objApprasialProperties.EligiblePercentage = TextBox59.Text;
                objApprasialProperties.EligibleSubsidyAmount = txt423guideline.Text;
                objApprasialProperties.AdditionalSubsidyAmount = txtTSSFCnorms423.Text;
                objApprasialProperties.TotalSubsidyAmount = txtvalue424.Text;
                objApprasialProperties.ForwardTo = ddlDepartment.SelectedValue.ToString();
                objApprasialProperties.WorkSheetPath = hypWorksheet.NavigateUrl.ToString();
                objApprasialProperties.Remarks = txtremarks.Text;
                objApprasialProperties.CREATEDBY = ObjLoginNewvo.uid;
                objApprasialProperties.GMRecommendedAmount = txtGMAmount.Text.ToString();

                objApprasialProperties.Scheme = "TTAP";
                string returnval = "0";
                returnval = ObjCAFClass.InsertCaptialSubsidyAppraisal(objApprasialProperties);
                if (!string.IsNullOrEmpty(returnval) && returnval.Trim() != "")
                {
                    string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
                    DLOApplication DLODetails = new DLOApplication();
                    if (txtvalue424.Text != "")
                    {
                        DLODetails.RECOMMENDEAMOUNT = txtvalue424.Text.ToString();
                    }
                    else
                    {
                        DLODetails.RECOMMENDEAMOUNT = Convert.ToString(objApprasialProperties.FINALELIGIBLEAMOUNT);
                    }

                    DLODetails.INCENTIVEID = txtIncID.Text;
                    DLODetails.SUBINCENTIVEID = "1";
                    DLODetails.ACTIONID = "1";
                    DLODetails.FORWARDTO = ddlDepartment.SelectedItem.Text;
                    DLODetails.CREATEDBY = ObjLoginNewvo.uid;


                    string result = ObjCAFClass.InsertClerkDetails(DLODetails);

                    if (result == "1")
                    {
                        status = true;
                        /*lblmsg.Text = "Application Process Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Application Process Submitted Successfully.');", true);*/
                    }

                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Appraisal note submitted.');", true);
                    //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "message", message, true);
                    //return false;
                    status = false;
                }
            }
            catch (Exception ex)
            {

            }
            return status;
        }
        protected void BtnClearall_Click(object sender, EventArgs e)
        {
            this.Page_Load(null, null);
        }

        protected void btm_previous_Click(object sender, EventArgs e)
        {
            Response.Redirect("COI/ClerkDashboard.aspx");

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

        protected void ddlTextileProcessType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TTAPCategory();
            CapitalsubsidyCalculation();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string IncentiveId = txtIncID.Text;
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
    }
}