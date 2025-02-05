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
    public partial class HeadOfficeInspectionReport : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        CAFClass ObjCAFClass = new CAFClass();
        decimal InterestAmountPaid = 0;
        decimal SanctionedAmount = 0;
        decimal EligibleInterest = 0;
        decimal TotalPlintArea = 0, TotalOnetoNineValue = 0, TotalEighttoSeventeenValue = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["uid"] != null)
                {

                    if (Request.QueryString.Count > 1)
                    {
                        UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                        ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                        string IncentiveID = Request.QueryString["IncentiveID"].ToString();
                        string SubIncentiveId = Request.QueryString["SubIncentiveId"].ToString();
                        hdnIncentiveId.Value = Request.QueryString["IncentiveID"].ToString();
                        hdnSubIncentiveId.Value = Request.QueryString["SubIncentiveId"].ToString();
                        hdnDistrictId.Value = ObjLoginNewvo.DistrictID;
                        hdnUserId.Value = ObjLoginNewvo.uid;
                        hdnrUserRole.Value = ObjLoginNewvo.Role_Code;
                        BindBesicdata(IncentiveID, SubIncentiveId, ObjLoginNewvo.DistrictID);
                        if (ObjLoginNewvo.Role_Code == "IND")
                        {
                            txtIndDeptName.ReadOnly = false;
                            BtnSave.Visible = false;
                            divBuildingDtls.Visible = false;
                            divChangerequest.Visible = false;
                            divChangerequestNote.Visible = false;
                            trInspectionReportFileUpload.Visible = false;
                            trIndCheckBox.Visible = true;
                            btndraft.Text = "Submit to DLO(H&T)";
                            spnIndLastUpdatedon.InnerText = "Report Last Updated on";
                            txtIndustryRemarks.Enabled = true;
                        }

                    }
                }
            }

            bool strKey = Convert.ToBoolean(ConfigurationManager.AppSettings["DLOSysCalamount"].ToString());
            tdsysSubsidy.Visible = strKey;
            tdsysSubsidy1.Visible = strKey;
        }
        public void BindBesicdata(string IncentiveID, string SubIncentiveId, string DistrictID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetapplicationDtls("0", IncentiveID);
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
                    lblActivityoftheUnit.InnerText = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();
                    ddlCategory.SelectedValue = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    hdnActualCategory.Value = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    lblTypeofTexttile.InnerText = dsnew.Tables[0].Rows[0]["TypeofTexttileText"].ToString();
                    ddlTypeofTextile.SelectedValue = dsnew.Tables[0].Rows[0]["TypeofTexttile"].ToString();
                    hdnActualTextile.Value = dsnew.Tables[0].Rows[0]["TypeofTexttile"].ToString();

                    lblAddress.InnerText = dsnew.Tables[0].Rows[0]["UnitTotalAddress"].ToString();
                    lblProprietor.InnerText = dsnew.Tables[0].Rows[0]["AuthorisedPerson"].ToString();
                    lblOrganization.InnerText = dsnew.Tables[0].Rows[0]["ConstitutionUnit"].ToString();
                    lblSocialStatus.InnerText = dsnew.Tables[0].Rows[0]["SocialStatusText"].ToString();
                    lblRegistrationNumber.InnerText = dsnew.Tables[0].Rows[0]["IncorpRegistranNumber"].ToString();
                    lblTechnicalTextileType.InnerText = dsnew.Tables[0].Rows[0]["TechnicalTextile"].ToString();
                    lblPowerConnectionReleaseDate.InnerText = dsnew.Tables[0].Rows[0]["NewPowerReleaseDate"].ToString();

                    if (TypeOfIndustry == "1")
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCP"].ToString();
                        trFixedCapitalexpansion.Visible = false;
                        trFixedCapitalland.Visible = false;
                        trFixedCapitalBuilding.Visible = false;
                        trFixedCapitalMach.Visible = false;

                        Td3.Visible = false;
                        Td4.Visible = false;

                        trFixedCapitalexpnPercent.Visible = false;
                        txtbuildcapacityPercet.Visible = false;
                        trFixedCapitMachPercent.Visible = false;
                        trFixedCapitBuildPercent.Visible = false;
                    }
                    else
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCPExp"].ToString();
                        trFixedCapitalexpansion.Visible = true;
                        trFixedCapitalland.Visible = true;
                        trFixedCapitalBuilding.Visible = true;
                        trFixedCapitalMach.Visible = true;

                        Td3.Visible = true;
                        Td4.Visible = true;

                        trFixedCapitalexpnPercent.Visible = true;
                        txtbuildcapacityPercet.Visible = true;
                        trFixedCapitMachPercent.Visible = true;
                        trFixedCapitBuildPercent.Visible = true;
                    }

                    txtlandexisting.InnerHtml = dsnew.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString();
                    txtlandcapacity.InnerHtml = dsnew.Tables[0].Rows[0]["ExpansionDiversificationLand"].ToString();
                    txtlandpercentage.InnerHtml = dsnew.Tables[0].Rows[0]["LandFixedCapitalInvestPercentage"].ToString();

                    txtbuildingexisting.InnerHtml = dsnew.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString();
                    txtbuildingcapacity.InnerHtml = dsnew.Tables[0].Rows[0]["ExpDiversBuilding"].ToString();
                    txtbuildingpercentage.InnerHtml = dsnew.Tables[0].Rows[0]["BuildingFixedCapitalInvestPercentage"].ToString();

                    txtplantexisting.InnerHtml = dsnew.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString();
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

                    BindSLCDetails(IncentiveID, SubIncentiveId);

                    DataSet dsnew1 = new DataSet();
                    dsnew1 = GetSubsidyApplicationDeatils(IncentiveID, SubIncentiveId, DistrictID);
                    if (dsnew1 != null && dsnew1.Tables.Count > 0 && dsnew1.Tables[0].Rows.Count > 0)
                    {

                        lblSubsidyClaimedUnit.InnerHtml = dsnew1.Tables[0].Rows[0]["UnitClaimedAmount"].ToString();
                        SubsidySystemRecommended.InnerHtml = dsnew1.Tables[0].Rows[0]["SystemRecommendedAmount"].ToString();
                        hdnSubsidySystemRecommended.Value = dsnew1.Tables[0].Rows[0]["SystemRecommendedAmount"].ToString();

                        txtAmountSubsidyRecommended.Text = dsnew1.Tables[0].Rows[0]["SystemRecommendedAmount"].ToString();

                        if (SubIncentiveId == "1" || SubIncentiveId == "19")
                        {
                            Capitalsub.Visible = true;
                            txtIndustryPersonName.Visible = true;
                            if (SubIncentiveId == "1")
                            {
                                DataSet dsData = GetCAFNewUnitData(Session["uid"].ToString(), Convert.ToInt32(IncentiveID));

                                if (dsData.Tables.Count > 0)
                                {
                                    if (dsData.Tables[0].Rows.Count > 0)
                                    {
                                        txtPLExtent.InnerHtml = dsData.Tables[0].Rows[0]["PurchasedLandExtent"].ToString();
                                        txtPLValue.InnerHtml = dsData.Tables[0].Rows[0]["PurchasedLandValue"].ToString();
                                        txtDLOLandRecomendAmountPerAcre.Text = dsData.Tables[2].Rows[0]["DLOLandPerAcreAmount"].ToString();
                                        txtDLOLandRemarks.Text = dsData.Tables[2].Rows[0]["DLOLandPerAcreRemarks"].ToString();
                                        txtLLExtent.InnerHtml = dsData.Tables[0].Rows[0]["LeasedLandExtent"].ToString();
                                        txtLLValue.InnerHtml = dsData.Tables[0].Rows[0]["LeasedLandValue"].ToString();
                                        txtILExtent.InnerHtml = dsData.Tables[0].Rows[0]["InheritedLandExtent"].ToString();
                                        txtILValue.InnerHtml = dsData.Tables[0].Rows[0]["InheritedLandValue"].ToString();
                                        txtGLExtent.InnerHtml = dsData.Tables[0].Rows[0]["GovtLandExtent"].ToString();
                                        txtGLValue.InnerHtml = dsData.Tables[0].Rows[0]["GovtLandValue"].ToString();
                                        BindTotalLandValue("1");
                                        BindTotalLandValue("2");
                                        BindTotalLandValue("3");
                                        BindTotalLandValue("4");
                                        BindTotalLandValue("5");
                                        BindTotalLandValue("7");
                                    }
                                }

                                bool strKey1 = Convert.ToBoolean(ConfigurationManager.AppSettings["DLOSysCalamount"].ToString());
                                trcapitalsubsidy.Visible = strKey1;
                                tdIORecommended.Visible = false;
                                tdIORecommended1.Visible = false;
                                trAmountofSubsidyRecommendedAbstract.Visible = true;
                                trLandDetails.Visible = true;
                                trApprovedProjectCost.Visible = true;
                                trActualInvestment.Visible = true;

                                lblSystemTotal.InnerHtml = dsnew1.Tables[0].Rows[0]["SystemRecommendedAmount"].ToString();
                                lblSystemSubsidy.InnerHtml = dsnew1.Tables[0].Rows[0]["CalSystemSubsidy"].ToString();
                                hdnSystemSubsidy.Value = dsnew1.Tables[0].Rows[0]["CalSystemSubsidy"].ToString();
                                lblSystemAdditionalCapitalSubsidy.InnerHtml = dsnew1.Tables[0].Rows[0]["CalSystemAdditionalCapitalSubsidy"].ToString();
                                hdnSystemAdditionalCapitalSubsidy.Value = dsnew1.Tables[0].Rows[0]["CalSystemAdditionalCapitalSubsidy"].ToString();
                            }
                            else
                            {
                                trcapitalsubsidy.Visible = false;
                            }
                            divplantmachinary.Visible = true;
                            BindPandMGrid(0, Convert.ToInt32(IncentiveID), TypeOfIndustry, hdnrUserRole.Value);
                        }
                        if (SubIncentiveId == "2")
                        {
                            Form3.Visible = true;
                            BindEquipmentDtls(IncentiveID);
                        }

                        if (SubIncentiveId == "3")
                        {
                            BindISCrrentClaimPeriodDtls(IncentiveID.ToString());
                            BindTearmLoanDtls(IncentiveID.ToString());
                            BindTermLoanRepaid(0, Convert.ToInt32(IncentiveID));
                            BindAdditionalInformationDtls(IncentiveID.ToString());
                            BindMoratoriumPeriodDetails(0, Convert.ToInt32(IncentiveID.ToString()));
                            txtDLOEligibleInterest_TextChanged(this, EventArgs.Empty);
                            divIntrestSubsidy.Visible = true;
                            lblCCA.Text = dsnew1.Tables[0].Rows[0]["InterestSubsidyCCA"].ToString();
                            if (dsnew1.Tables[0].Rows[0]["Interest_SanctionOrderNo"].ToString() != "")
                            {
                                lblAmountAvailed.Text = dsnew1.Tables[0].Rows[0]["Interest_AmountAvailed"].ToString();
                                lblSanctionOrderNo.Text = dsnew1.Tables[0].Rows[0]["Interest_SanctionOrderNo"].ToString();
                                lblSanctionOrderNo.Text = dsnew1.Tables[0].Rows[0]["Interest_DateAvailed"].ToString();
                                lblGOAgency.Text = "Yes";
                                divGOAgency.Visible = true;
                            }
                            else
                            {
                                lblGOAgency.Text = "No";
                            }
                        }
                        if (SubIncentiveId == "5")
                        {
                            trStampDuty.Visible = true;
                            lblNatureofAsset.InnerHtml = dsnew1.Tables[0].Rows[0]["NatureofAsset_Stampduty"].ToString();
                            lblavailedamount.InnerHtml = dsnew1.Tables[0].Rows[0]["Availedamount_Stampduty"].ToString();
                        }
                        if (SubIncentiveId == "7")
                        {
                            trAssistanceforEnergyWaterEnvironmental.Visible = true;
                            trAssistanceforEnergyWaterEnvironmental1.Visible = true;

                            string TypeofInfrastructure = dsnew1.Tables[0].Rows[0]["AssistanceRequired_AssistanceEnergy"].ToString();
                            if (TypeofInfrastructure != "")
                            {
                                string[] TypeofInfrastructureVal = TypeofInfrastructure.Split(',');

                                foreach (string Value in TypeofInfrastructureVal)
                                {
                                    int Index = chkAssistanceRequired.Items.IndexOf(chkAssistanceRequired.Items.FindByValue(Value));
                                    chkAssistanceRequired.Items[Index].Selected = true;
                                }
                            }

                            RbtnCommercialProduction.InnerText = dsnew1.Tables[0].Rows[0]["CommercialProductionText_AssistanceEnergy"].ToString();
                            txtReimbursementReceived.InnerHtml = dsnew1.Tables[0].Rows[0]["ReimbursementReceived_AssistanceEnergy"].ToString();
                        }

                        if (SubIncentiveId == "16")
                        {
                            trTrainingSubsidy.Visible = true;
                            trTrainingSubsidy1.Visible = true;

                            txtNumberofEmployees.InnerHtml = dsnew1.Tables[0].Rows[0]["NumberofEmployees_Training_Subsidy"].ToString();
                            txtNumberofEmployeesTrained.InnerHtml = dsnew1.Tables[0].Rows[0]["NumberofEmployeesTrained_Training_Subsidy"].ToString();
                            txtExpenditureIncurredTraining.InnerHtml = dsnew1.Tables[0].Rows[0]["ExpenditureIncurredTraining_Training_Subsidy"].ToString();
                        }
                        if (SubIncentiveId == "17")
                        {
                            trTrainingInfrastructureSubsidy1.Visible = true;
                            trTrainingInfrastructureSubsidy2.Visible = true;
                            trTrainingInfrastructureSubsidy3.Visible = true;
                            trTrainingInfrastructureSubsidy4.Visible = true;
                            trTrainingInfrastructureSubsidy5.Visible = true;

                            txtBuilding.InnerHtml = dsnew1.Tables[0].Rows[0]["Building_TrainingInfrastructure"].ToString();
                            txtPlantMachinery.InnerHtml = dsnew1.Tables[0].Rows[0]["PlantMachinery_TrainingInfrastructure"].ToString();
                            txtInstallationCharges.InnerHtml = dsnew1.Tables[0].Rows[0]["InstallationCharges_TrainingInfrastructure"].ToString();
                            txtElectrification.InnerHtml = dsnew1.Tables[0].Rows[0]["Electrification_TrainingInfrastructure"].ToString();
                            txtTrainingAids.InnerHtml = dsnew1.Tables[0].Rows[0]["TrainingAids_TrainingInfrastructure"].ToString();
                            txtFurniture.InnerHtml = dsnew1.Tables[0].Rows[0]["Furniture_TrainingInfrastructure"].ToString();
                            lblTotalInvestment.InnerHtml = dsnew1.Tables[0].Rows[0]["TotalInvestment_TrainingInfrastructure"].ToString();
                        }
                        // HMainheading.InnerHtml = dsnew1.Tables[0].Rows[0]["IncentiveName"].ToString() + " Inspection Report";
                        HMainheading.InnerHtml = "PART  B <br/> " + dsnew1.Tables[0].Rows[0]["IncentiveName"].ToString() + "<br/> Inspecting Officer Report";
                        lblInspectingOfficerName.InnerHtml = dsnew1.Tables[0].Rows[0]["Name"].ToString();
                        lblInspectionSchduledDate.InnerHtml = dsnew1.Tables[0].Rows[0]["SchduledDate"].ToString();

                        txtAppDateofInspection.Text = dsnew1.Tables[0].Rows[0]["SchduledDate"].ToString();

                        lblquerydate.InnerHtml = dsnew1.Tables[0].Rows[0]["QueryDate"].ToString();
                        lblresponsedate.InnerHtml = dsnew1.Tables[0].Rows[0]["QueryResponseDare"].ToString();

                        txtAppDateofInspection.Text = dsnew1.Tables[0].Rows[0]["InspectionDoneOn"].ToString();
                        txtRemarks.Text = dsnew1.Tables[0].Rows[0]["Remarks"].ToString();
                        txtIndustryPersonName.Text = dsnew1.Tables[0].Rows[0]["IndustryPersonName"].ToString();
                        txtDLOExtent.Text = dsnew1.Tables[0].Rows[0]["DLORecommendedLandExtent"].ToString();
                        txtIndDeptName.Text = dsnew1.Tables[0].Rows[0]["IndustryDeptPersonName"].ToString();
                        txtIndustryRemarks.Text = dsnew1.Tables[0].Rows[0]["IndustryDeptRemarks"].ToString();
                        txtDateofIndustriesDept.Text = dsnew1.Tables[0].Rows[0]["IndustryDeptUpdatedOn"].ToString();
                        txtIndustryDepartmentReportStatus.Text = dsnew1.Tables[0].Rows[0]["IndustryDeptReportStatus"].ToString();
                        hyplreportview.NavigateUrl = dsnew1.Tables[0].Rows[0]["UploadReportLink"].ToString();
                        if (dsnew1.Tables[0].Rows[0]["Ins_Flag"].ToString() == "Y")
                        {
                            ChkChangeReqest.Checked = true;
                            if (dsnew1.Tables[0].Rows[0]["Ins_Category"].ToString() != "" && dsnew1.Tables[0].Rows[0]["Ins_TypeOfTextile"].ToString() != "")
                            {
                                ddlCategory.SelectedValue = dsnew1.Tables[0].Rows[0]["Ins_Category"].ToString();
                                ddlTypeofTextile.SelectedValue = dsnew1.Tables[0].Rows[0]["Ins_TypeOfTextile"].ToString();
                            }
                        }
                        if (dsnew1.Tables[0].Rows[0]["IndustryDeptFlag"].ToString() == "")
                        {
                            trIndustryDeptPerson.Visible = false;
                            trIndustryDeptPerson1.Visible = false;
                        }
                        if (hyplreportview.NavigateUrl != "")
                        {
                            hyplreportview.Visible = true;
                        }
                        else
                        {
                            hyplreportview.Visible = false;
                        }

                        GetIncetiveAttachements(IncentiveID, SubIncentiveId);

                        if (SubIncentiveId == "1")
                        {
                            trcapitalsubisdy.Visible = true;
                            GetCapitalSubsidyBuildingDtls(IncentiveID, SubIncentiveId);
                            rbtnmachinesavailableYes_SelectedIndexChanged(this, EventArgs.Empty);
                        }
                        else
                        {
                            trcapitalsubisdy.Visible = false;
                        }
                        if (SubIncentiveId == "2")
                        {
                            rbtnEquipmentavailableYes_SelectedIndexChanged(this, EventArgs.Empty);
                        }
                        if (dsnew1.Tables[0].Rows[0]["IndustryDeptFlag"].ToString() == "C" && hdnrUserRole.Value == "IND")
                        {
                            btndraft.Visible = false;
                            EnableDisableForm(Page.Controls, false);
                        }
                    }
                    else
                    {
                        BtnSave.Visible = false;
                    }
                }
                else
                {
                    BtnSave.Visible = false;
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
        protected void ddlindustryStatus(string SelectedValue, string TextileProcessName)
        {
            try
            {
                if (SelectedValue == "1")
                {

                    // Investment 

                    trFixedCapitalexpansion.Visible = false;
                    trFixedCapitalland.Visible = false;
                    trFixedCapitalBuilding.Visible = false;
                    trFixedCapitalMach.Visible = false;

                    Td3.Visible = false;
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
                    trFixedCapitalland.Visible = true;
                    trFixedCapitalBuilding.Visible = true;
                    trFixedCapitalMach.Visible = true;

                    Td3.Visible = true;
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
                    trFixedCapitalland.Visible = true;
                    trFixedCapitalBuilding.Visible = true;
                    trFixedCapitalMach.Visible = true;

                    Td3.Visible = true;
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
        public void BindTotalLandValue(string LandTypeSlno)
        {
            Double Extent = 0, LandValue = 0;
            if (LandTypeSlno == "1")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(txtPLExtent.InnerHtml.TrimStart().TrimEnd()));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtPLValue.InnerHtml.TrimStart().TrimEnd()));

                lblPLTotalValue.InnerHtml = (Extent * LandValue).ToString();
                decimal DLORecommnededLandValue = 0;
                DLORecommnededLandValue = Convert.ToDecimal(Extent * LandValue);
            }
            else if (LandTypeSlno == "2")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(txtLLExtent.InnerHtml.TrimStart().TrimEnd()));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtLLValue.InnerHtml.TrimStart().TrimEnd()));

                lblLLTotalValue.InnerHtml = (Extent * LandValue).ToString();
            }
            else if (LandTypeSlno == "3")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(txtILExtent.InnerHtml.TrimStart().TrimEnd()));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtILValue.InnerHtml.TrimStart().TrimEnd()));

                lblILTotalValue.InnerHtml = (Extent * LandValue).ToString();
            }
            else if (LandTypeSlno == "4")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(txtGLExtent.InnerHtml.TrimStart().TrimEnd()));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtGLValue.InnerHtml.TrimStart().TrimEnd()));

                lblGLTotalValue.InnerHtml = (Extent * LandValue).ToString();
            }
            else if (LandTypeSlno == "5")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(lblPLTotalValue.InnerHtml));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtGLValue.InnerHtml.TrimStart().TrimEnd()));

                lblGLTotalValue.InnerHtml = (Extent * LandValue).ToString();
            }
            else if (LandTypeSlno == "7")
            {

                lblTotalExtentinAcre.InnerHtml = (Convert.ToDouble(GetDecimalNullValue(txtPLExtent.InnerHtml)) +
                    Convert.ToDouble(GetDecimalNullValue(txtLLExtent.InnerHtml)) +
                    Convert.ToDouble(GetDecimalNullValue(txtILExtent.InnerHtml)) +
                    Convert.ToDouble(GetDecimalNullValue(txtGLExtent.InnerHtml))).ToString();

                lblTotalValueOfLand.InnerHtml = (Convert.ToDouble(GetDecimalNullValue(lblPLTotalValue.InnerHtml)) +
                    Convert.ToDouble(GetDecimalNullValue(lblLLTotalValue.InnerHtml)) +
                    Convert.ToDouble(GetDecimalNullValue(lblILTotalValue.InnerHtml)) +
                    Convert.ToDouble(GetDecimalNullValue(lblGLTotalValue.InnerHtml))).ToString();
            }
        }

        public DataSet GetCAFNewUnitData(string UserId, int IncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UserId",SqlDbType.VarChar),
               new SqlParameter("@IncentiveId",SqlDbType.VarChar)
           };
            pp[0].Value = UserId;
            pp[1].Value = IncentiveId;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_INCENTIVE_CAF_NEWUNIT", pp);
            return Dsnew;
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

        public DataSet GetSubsidyApplicationDeatils(string INCENTIVEID, string SubIncentiveId, string DistID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar),
               new SqlParameter("@SubIncentiveId",SqlDbType.VarChar),
               new SqlParameter("@InsType",SqlDbType.VarChar),
               new SqlParameter("@DistID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            pp[1].Value = SubIncentiveId;
            pp[2].Value = "N";
            pp[3].Value = DistID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_INSPECTION_DTLS_HO", pp);
            return Dsnew;
        }
        public DataSet GetSubsidyApplicationDeatils_Modify(string INCENTIVEID, string SubIncentiveId, string DistID, string Category, string TypeOfTextile)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar),
               new SqlParameter("@SubIncentiveId",SqlDbType.VarChar),
               new SqlParameter("@DistID",SqlDbType.VarChar),
               new SqlParameter("@UnitCategory",SqlDbType.VarChar),
               new SqlParameter("@UnitTypeofTextile",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            pp[1].Value = SubIncentiveId;
            pp[2].Value = DistID;
            pp[3].Value = Category;
            pp[4].Value = TypeOfTextile;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_INSPECTION_DTLS_MODIFY", pp);
            return Dsnew;
        }
        public void GetIncetiveAttachements(string IncentiveId, string SubIncentiveId)
        {
            DataSet dsnew1 = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentveID",SqlDbType.VarChar),
              new SqlParameter("@SubIncentiveId",SqlDbType.VarChar),
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = SubIncentiveId;
            dsnew1 = ObjCAFClass.GenericFillDs("[USP_GET_ATTACHMENTS_SUBSIDY]", pp);

            if (dsnew1 != null && dsnew1.Tables.Count > 0 && dsnew1.Tables[0].Rows.Count > 0)
            {
                gvSubsidy.DataSource = dsnew1.Tables[0];
                gvSubsidy.DataBind();
            }
        }

        protected void gvSubsidy_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbl = (e.Row.FindControl("lbl") as Label);
                    HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);

                    string Category = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Category"));
                    if (Category.Trim().TrimStart() != "")
                    {
                        lbl.Text = Category.Trim().TrimStart();
                        e.Row.Font.Bold = true;
                        HyperLinkSubsidy.Visible = false;
                    }

                    if (HyperLinkSubsidy.NavigateUrl == "")
                    {
                        HyperLinkSubsidy.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                //lblmsg0.Text = "Internal error has occured. Please try after some time";
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                // LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        public string ValidateControls()
        {
            int slno = 1;
            string ErrorMsg = "";
            if (hdnrUserRole.Value == "IND")
            {
                ErrorMsg = ErrorMsg + slno + ".You dont have permission to submit the Inspection Report \\n";
                slno = slno + 1;
            }
            if (txtAppDateofInspection.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Date of Inspection \\n";
                slno = slno + 1;
            }
            //if (Request.QueryString["SubIncentiveId"] == "1")
            //{
            //    if (txtInspectingOfficerSubsidy.Text.Trim().TrimStart() == "")
            //    {
            //        ErrorMsg = ErrorMsg + slno + ". Please Eneter Amount of Capital Subsidy Recommended (in Rs)\\n";
            //        slno = slno + 1;
            //    }
            //    if (txtInspectingOfficerAdditionalCapitalSubsidy.Text.Trim().TrimStart() == "")
            //    {
            //        ErrorMsg = ErrorMsg + slno + ". Please Eneter Amount of Additional Capital Subsidy for SC/ST, Women entrepreneurs or PWD  Recommended (in Rs)\\n";
            //        slno = slno + 1;
            //    }
            //}
            //else
            //{
            //    if (txtAmountSubsidyRecommended.Text.Trim().TrimStart() == "")
            //    {
            //        ErrorMsg = ErrorMsg + slno + ". Please Eneter Amount of Subsidy Recommended \\n";
            //        slno = slno + 1;
            //    }
            //}
            if (txtIndustryPersonName.Text.Trim().TrimStart().TrimEnd() == "")// && (Request.QueryString["SubIncentiveId"] == "1" || Request.QueryString["SubIncentiveId"] == "19"))
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Person from the Industry present at the time of Inspection \\n";
                slno = slno + 1;
            }

            if (fpdSpecimen.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fpdSpecimen);
                if (errormsg != "")
                {
                    // string message = "alert('" + errormsg + "')";
                    ErrorMsg = ErrorMsg + slno + "." + errormsg + " \\n";
                    slno = slno + 1;
                }

                string Mimetype = objClsFileUpload.getmimetype(fpdSpecimen);
                if (Mimetype == "application/pdf")
                {

                }
                else
                {
                    ErrorMsg = ErrorMsg + slno + ". Only pdf files allowed! \\n";
                    slno = slno + 1;
                }
            }
            else if (hyplreportview.NavigateUrl == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Upload Inspection Report (Only pdf files allowed) \\n";
                slno = slno + 1;
            }

            if (Request.QueryString["SubIncentiveId"].ToString() == "1" || Request.QueryString["SubIncentiveId"].ToString() == "19")
            {
                /*if (hypNamePlate.NavigateUrl == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Upload Unit Name Plate Photo \\n";
                    slno = slno + 1;
                }
                if (hypPM1.NavigateUrl == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Photo of Plant & Machinary-1 \\n";
                    slno = slno + 1;
                }
                if (hypPM2.NavigateUrl == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Photo of Plant & Machinary-2 \\n";
                    slno = slno + 1;
                }
                if (hypPM3.NavigateUrl == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Photo of Plant & Machinary-3 \\n";
                    slno = slno + 1;
                }*/
                foreach (GridViewRow gvrow in grdPandM.Rows)
                {
                    RadioButtonList rbtnList = (RadioButtonList)gvrow.FindControl("rbtnmachinesavailableYes");
                    TextBox txtremarks = (TextBox)gvrow.FindControl("txtremarks");
                    TextBox txtAdmissibleAmount = (TextBox)gvrow.FindControl("txtAdmissibleAmount");
                    if (rbtnList.SelectedIndex == -1)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Check Availability of the Machine in Running Condition under Plant and Machinary at Sno " + (gvrow.RowIndex + 1).ToString() + " \\n";
                        slno = slno + 1;
                        break;
                    }
                    else if ((rbtnList.SelectedValue == "N" || rbtnList.SelectedValue == "A") && txtremarks.Text.Trim().TrimStart() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter the Reasons for the Discrepancy at Sno " + (gvrow.RowIndex + 1).ToString() + " \\n";
                        slno = slno + 1;
                        break;
                    }
                    else if (rbtnList.SelectedValue == "R")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Check either Yes or No of Availability of the Machine in Running Condition under Plant and Machinary at Sno " + (gvrow.RowIndex + 1).ToString() + " \\n";
                        slno = slno + 1;
                        break;
                    }
                    else if (rbtnList.SelectedValue == "A" && txtAdmissibleAmount.Text.Trim().TrimStart() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter the Admissible Amount at Sno " + (gvrow.RowIndex + 1).ToString() + " \\n";
                        slno = slno + 1;
                        break;
                    }
                }
            }
            if (Request.QueryString["SubIncentiveId"].ToString() == "2")
            {
                foreach (GridViewRow gvrow in gvEquipments.Rows)
                {
                    RadioButtonList rbtnList = (RadioButtonList)gvrow.FindControl("rbtnEquipmentavailableYes");
                    TextBox txtremarks = (TextBox)gvrow.FindControl("txtremarksEq");
                    TextBox txtAdmissibleAmount = (TextBox)gvrow.FindControl("txtAdmissibleAmountEq");
                    if (rbtnList.SelectedIndex == -1)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Check Availability of the Equipment in Running Condition under Equipment Section at S.No " + (gvrow.RowIndex + 1).ToString() + " \\n";
                        slno = slno + 1;
                        break;
                    }
                    else if ((rbtnList.SelectedValue == "N" || rbtnList.SelectedValue == "A") && txtremarks.Text.Trim().TrimStart() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter the Reasons for the Discrepancy at Sno " + (gvrow.RowIndex + 1).ToString() + " \\n";
                        slno = slno + 1;
                        break;
                    }
                    else if (rbtnList.SelectedValue == "A" && txtAdmissibleAmount.Text.Trim().TrimStart() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter the Admissible Amount at S.No " + (gvrow.RowIndex + 1).ToString() + " \\n";
                        slno = slno + 1;
                        break;
                    }
                }
            }

            return ErrorMsg;
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
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
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
                    foreach (GridViewRow gvrow in gvSubsidy.Rows)
                    {
                        RadioButtonList rbtnList = (RadioButtonList)gvrow.FindControl("rbtVerify");
                        Label Attachment = (Label)gvrow.FindControl("lbl");
                        Label Category = (Label)gvrow.FindControl("lblAttachmentName");

                        if (rbtnList.SelectedValue == "" && Category.Text != "Y")
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Verified or not for " + Attachment.Text + "');", true);
                            return;
                        }
                    }

                    ApplicationStatus ObjApplicationStatus = new ApplicationStatus();
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    string IncentiveID = Request.QueryString["IncentiveID"].ToString();
                    string SubIncentiveId = Request.QueryString["SubIncentiveId"].ToString();

                    ObjApplicationStatus.IncentiveId = IncentiveID;
                    ObjApplicationStatus.SubIncentiveId = SubIncentiveId;
                    ObjApplicationStatus.CreatedBy = ObjLoginNewvo.uid;

                    if (txtAppDateofInspection.Text.Trim().TrimStart() != "")
                    {
                        ObjApplicationStatus.InspectionDate = GetFromatedDateDDMMYYYY(txtAppDateofInspection.Text.Trim().TrimStart());
                    }
                    if (SubIncentiveId == "1")
                    {

                        List<InspectionBuildingDetails> lstBuildings = new List<InspectionBuildingDetails>();
                        foreach (GridViewRow gvrow in GvBuildingDetails.Rows)
                        {
                            Label lblBUILDINGIDADD = ((Label)(gvrow.FindControl("lblBUILDINGID")));
                            CheckBox CHKIncentiveADD = ((CheckBox)(gvrow.FindControl("CHKIncentive")));
                            Label lblBuildingId = ((Label)(gvrow.FindControl("lblBUILDINGID")));
                            Label lblCivilworks = ((Label)(gvrow.FindControl("lblCivilworks")));
                            TextBox txtDLOAmount = ((TextBox)(gvrow.FindControl("txtDLOAmount")));
                            TextBox txtBuildingRemarks = ((TextBox)(gvrow.FindControl("txtBuildingRemarks")));
                            TextBox txtDLOPlinthArea = ((TextBox)(gvrow.FindControl("txtDLOPlinthArea")));
                            TextBox txtDLOSqmterValue = ((TextBox)(gvrow.FindControl("txtDLOSqmterValue")));
                            string DLOPlinthArea = "", DLOSqmterValue = "";
                            DLOPlinthArea = txtDLOPlinthArea.Text.Trim();
                            if (txtDLOSqmterValue.Text.Trim() == "" || txtDLOSqmterValue.Text.Trim() == null)
                            {
                                DLOPlinthArea = "0.00";
                            }
                            else
                            {
                                DLOSqmterValue = txtDLOSqmterValue.Text.Trim();
                            }

                            lstBuildings.Add(new InspectionBuildingDetails
                            {
                                BuildingId = lblBuildingId.Text.Trim(),
                                CivilWorkName = lblCivilworks.Text.Trim(),
                                DLOValue = txtDLOAmount.Text.Trim(),
                                DLORemarks = txtBuildingRemarks.Text.Trim(),
                                DLOPlinthArea = DLOPlinthArea,
                                DLOSqmterValue = DLOSqmterValue
                            });
                        }

                        XElement xmlBuilding = new XElement("xmlBuilding_xml",
                                   from Building in lstBuildings
                                   select new XElement("BuildingTable",
                                   new XElement("BuildingId", Building.BuildingId),
                                   new XElement("CivilWorkName", Building.CivilWorkName),
                                   new XElement("DLOValue", Building.DLOValue),
                                   new XElement("DLORemarks", Building.DLORemarks),
                                   new XElement("DLOPlinthArea", Building.DLOPlinthArea),
                                   new XElement("DLOSqmterValue", Building.DLOSqmterValue)
                                   ));

                        ObjApplicationStatus.BuildingXml = xmlBuilding.ToString();
                        ObjApplicationStatus.DLOCalculatedLandAmount = hdnLandValue.Value;
                        ObjApplicationStatus.DLOCalculatedBuildingAmount = hdnBuildingValue.Value;
                        ObjApplicationStatus.DLOCalculatedPMAmount = hdnPMValue.Value;
                        ObjApplicationStatus.DLOCalculatedOthersAmount = hdnOthersValue.Value;
                        ObjApplicationStatus.DLOLandPerAcreValue = txtDLOLandRecomendAmountPerAcre.Text.Trim();
                        ObjApplicationStatus.DLORecommendedLandExtent = txtDLOExtent.Text.Trim();
                        ObjApplicationStatus.DLOLandPerAcreRemarks = txtDLOLandRemarks.Text;

                        ObjApplicationStatus.RecommendedAmount = GetDecimalNullValue(lblInspectingOfficerTotal.InnerHtml.Trim().TrimStart());
                        ObjApplicationStatus.CapitalSubsidyAmount = GetDecimalNullValue(txtInspectingOfficerSubsidy.Text.Trim().TrimStart());
                        ObjApplicationStatus.AdditionalCapitalSubsidyAmount = GetDecimalNullValue(txtInspectingOfficerAdditionalCapitalSubsidy.Text.Trim().TrimStart());

                        ObjApplicationStatus.SystemCapitalSubsidyAmount = GetDecimalNullValue(lblSystemSubsidy.InnerHtml.Trim().TrimStart());
                        ObjApplicationStatus.SystemAdditionalCapitalSubsidyAmount = GetDecimalNullValue(lblSystemAdditionalCapitalSubsidy.InnerHtml.Trim().TrimStart());
                        //chanikya
                        ObjApplicationStatus.Actual_RecommendedAmount = GetDecimalNullValue(hdnSubsidySystemRecommended.Value.Trim().TrimStart());
                        ObjApplicationStatus.Actual_CapitalSubsidyAmount = GetDecimalNullValue(hdnSubsidySystemRecommended.Value.Trim().TrimStart());
                        ObjApplicationStatus.Actual_AdditionalCapitalSubsidyAmount = GetDecimalNullValue(hdnSystemAdditionalCapitalSubsidy.Value.Trim().TrimStart());

                        ObjApplicationStatus.Actual_SystemCapitalSubsidyAmount = GetDecimalNullValue(hdnSystemSubsidy.Value.Trim().TrimStart());
                        ObjApplicationStatus.Actual_SystemAdditionalCapitalSubsidyAmount = GetDecimalNullValue(hdnSystemAdditionalCapitalSubsidy.Value.Trim().TrimStart());

                    }
                    else
                    {
                        ObjApplicationStatus.RecommendedAmount = GetDecimalNullValue(txtAmountSubsidyRecommended.Text.Trim().TrimStart());
                        ObjApplicationStatus.Actual_RecommendedAmount = GetDecimalNullValue(hdnSubsidySystemRecommended.Value.Trim().TrimStart());
                    }
                    if (SubIncentiveId == "1" || SubIncentiveId == "19")
                    {
                        List<InspectionPlantandMachinary> lstPMs = new List<InspectionPlantandMachinary>();

                        foreach (GridViewRow gvrow in grdPandM.Rows)
                        {
                            RadioButtonList rbtnList = (RadioButtonList)gvrow.FindControl("rbtnmachinesavailableYes");
                            TextBox txtremarks = (TextBox)gvrow.FindControl("txtremarks");
                            Label lblPMId = (Label)gvrow.FindControl("lblPMId");
                            Label lblIncentiveId = (Label)gvrow.FindControl("lblIncentiveId");
                            TextBox txtAdmissibleAmount = (TextBox)gvrow.FindControl("txtAdmissibleAmount");

                            lstPMs.Add(new InspectionPlantandMachinary
                            {
                                PMID = lblPMId.Text,
                                IncentiveId = lblIncentiveId.Text,
                                MachineAvailability = rbtnList.SelectedValue,
                                Remarks = txtremarks.Text,
                                MachineCost = txtAdmissibleAmount.Text
                            });
                        }

                        XElement xmlPMUpload = new XElement("xmlPMUpload_xml",
                        from PMs in lstPMs
                        select new XElement("PMsTable",
                        new XElement("PMID", PMs.PMID),
                        new XElement("IncentiveId", PMs.IncentiveId),
                        new XElement("MachineAvailability", PMs.MachineAvailability),
                        new XElement("Remarks", PMs.Remarks),
                        new XElement("MachineCost", PMs.MachineCost)
                        ));

                        ObjApplicationStatus.PMXml = xmlPMUpload.ToString();
                    }
                    if (SubIncentiveId == "2")
                    {
                        List<InspectionEquipment> lstPMs = new List<InspectionEquipment>();

                        foreach (GridViewRow gvrow in gvEquipments.Rows)
                        {
                            Label lblEquipment_ID = ((Label)(gvrow.FindControl("lblEquipment_ID")));
                            Label lblIncentiveId = ((Label)(gvrow.FindControl("lblIncentiveId")));
                            Label lblTotal = ((Label)(gvrow.FindControl("lblTotal")));
                            Label lblCategoryId = ((Label)(gvrow.FindControl("lblCategoryId")));
                            Label lblNameoftheEquipment = ((Label)(gvrow.FindControl("lblNameoftheEquipment")));
                            TextBox txtAdmissibleAmountEq = ((TextBox)(gvrow.FindControl("txtAdmissibleAmountEq")));
                            TextBox txtremarksEq = ((TextBox)(gvrow.FindControl("txtremarksEq")));
                            RadioButtonList rbtnEquipmentavailableYes = ((RadioButtonList)(gvrow.FindControl("rbtnEquipmentavailableYes")));

                            lstPMs.Add(new InspectionEquipment
                            {
                                EquipmentId = lblEquipment_ID.Text,
                                IncentiveId = lblIncentiveId.Text,
                                EquipmentName = lblNameoftheEquipment.Text.Trim(),
                                EquipmentAvailability = rbtnEquipmentavailableYes.SelectedValue,
                                Remarks = txtremarksEq.Text,
                                EquipmentCost = txtAdmissibleAmountEq.Text,
                                Category = lblCategoryId.Text
                            });
                        }

                        XElement xmlEqppload = new XElement("xmlEqpUpload_xml",
                        from PMs in lstPMs
                        select new XElement("EqpsTable",
                        new XElement("EquipmentId", PMs.EquipmentId),
                        new XElement("IncentiveId", PMs.IncentiveId),
                        new XElement("EquipmentName", PMs.EquipmentName),
                        new XElement("EquipmentAvailability", PMs.EquipmentAvailability),
                        new XElement("Remarks", PMs.Remarks),
                        new XElement("EquipmentCost", PMs.EquipmentCost),
                        new XElement("Category", PMs.Category)
                        ));

                        ObjApplicationStatus.EquipmentXml = xmlEqppload.ToString();
                    }
                    if (SubIncentiveId == "3")
                    {
                        List<InspectionInterestSubsidy> lstInterest = new List<InspectionInterestSubsidy>();

                        foreach (GridViewRow gvrow in gvAdditionalInformation.Rows)
                        {

                            TextBox txtDLORemarks = (TextBox)gvrow.FindControl("txtDLORemarks");
                            Label lblAdditionalinformationId = (Label)gvrow.FindControl("lblAdditionalinformationId");
                            Label lblIncentiveId = (Label)gvrow.FindControl("lblIncentiveId");
                            Label lblEligibleInterest = (Label)gvrow.FindControl("lblEligibleInterest");
                            TextBox txtDLOEligibleInterest = (TextBox)gvrow.FindControl("txtDLOEligibleInterest");

                            lstInterest.Add(new InspectionInterestSubsidy
                            {
                                AdditionalinformationId = lblAdditionalinformationId.Text,
                                IncentiveId = lblIncentiveId.Text,
                                ActualEligibleInterest = lblEligibleInterest.Text,
                                Remarks = txtDLORemarks.Text,
                                DLORecommendedEligibleInterest = txtDLOEligibleInterest.Text
                            });
                        }
                        XElement xmlInterest = new XElement("xmlInterest_xml",
                       from Interest in lstInterest
                       select new XElement("InterestTable",
                       new XElement("AdditionalinformationId", Interest.AdditionalinformationId),
                       new XElement("IncentiveId", Interest.IncentiveId),
                       new XElement("ActualEligibleInterest", Interest.ActualEligibleInterest),
                       new XElement("Remarks", Interest.Remarks),
                       new XElement("DLORecommendedEligibleInterest", Interest.DLORecommendedEligibleInterest)
                       ));

                        ObjApplicationStatus.InterestXml = xmlInterest.ToString();
                    }

                    List<InspectionAttachments> lstAttachmentss = new List<InspectionAttachments>();

                    foreach (GridViewRow gvrows in gvSubsidy.Rows)
                    {
                        RadioButtonList rbtnList = (RadioButtonList)gvrows.FindControl("rbtVerify");
                        Label Attachment = (Label)gvrows.FindControl("lbl");
                        Label AttachmentId = (Label)gvrows.FindControl("lblAttachmentId");
                        Label Category = (Label)gvrows.FindControl("lblAttachmentName");
                        Label MstIncentiveId = (Label)gvrows.FindControl("lblMstIncentiveId");
                        Label Verifieddt = (Label)gvrows.FindControl("lblverified");

                        lstAttachmentss.Add(new InspectionAttachments
                        {
                            Category = Category.Text,
                            AttachmentId = AttachmentId.Text,
                            AttachmentName = Attachment.Text,
                            MstIncentiveId = MstIncentiveId.Text,
                            VerifyStatus = rbtnList.SelectedValue,
                            IncentiveId = IncentiveID,
                            SubIncentiveId = SubIncentiveId,
                            Verifieddt = Verifieddt.Text
                        });
                    }

                    XElement xmlAttachmentsUpload = new XElement("xmlPMUpload_xml",
                    from Atc in lstAttachmentss
                    select new XElement("AttachmentsTable",
                    new XElement("Category", Atc.Category),
                    new XElement("AttachmentId", Atc.AttachmentId),
                    new XElement("AttachmentName", Atc.AttachmentName),
                    new XElement("MstIncentiveId", Atc.MstIncentiveId),
                    new XElement("VerifyStatus", Atc.VerifyStatus),
                    new XElement("IncentiveId", Atc.IncentiveId),
                    new XElement("SubIncentiveId", Atc.SubIncentiveId),
                    new XElement("Verifieddt", Atc.Verifieddt)
                    ));

                    ObjApplicationStatus.AttachmentXml = xmlAttachmentsUpload.ToString();

                    ObjApplicationStatus.Remarks = txtRemarks.Text.Trim().TrimStart();
                    ObjApplicationStatus.IndustryPersonName = txtIndustryPersonName.Text.Trim().TrimStart();
                    ObjApplicationStatus.SystemRecommended = SubsidySystemRecommended.InnerHtml;
                    ObjApplicationStatus.Actual_SystemRecommended = GetDecimalNullValue(hdnSubsidySystemRecommended.Value.Trim().TrimStart());
                    if (ddlCategory.SelectedValue != hdnActualCategory.Value || ddlTypeofTextile.SelectedValue != hdnActualTextile.Value)
                    {
                        ObjApplicationStatus.Ins_Flag = "Y";
                    }
                    else
                    {
                        ObjApplicationStatus.Ins_Flag = "N";
                    }
                    ObjApplicationStatus.Ins_Category = ddlCategory.SelectedValue;
                    ObjApplicationStatus.Ins_TypeOfTextile = ddlTypeofTextile.SelectedValue;
                    ObjApplicationStatus.DLOManualRecommendAmount = lblDLOSuggestedAmount.Text;

                    //HyperLink HylUpload1 = new HyperLink();
                    objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fpdSpecimen, hyplreportview, "DLOInspectionReport", ObjApplicationStatus.IncentiveId, ObjApplicationStatus.SubIncentiveId, "161111", Session["uid"].ToString(), "INSPECTINGOFFICER");
                    hyplreportview.Visible = true;
                    string OutPut = "1";
                    if (OutPut == "1")
                    {
                        string Status = ObjCAFClass.UpdateInspectionReport(ObjApplicationStatus);
                        if (Convert.ToInt32(Status) > 0)
                        {
                            string Successmsg = "";

                            txtAppDateofInspection.Text = "";
                            txtAmountSubsidyRecommended.Text = "";

                            BtnSave.Enabled = false;

                            Successmsg = "Inspection Report Submitted Successfully";

                            string message = "alert('" + Successmsg + "')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                    else
                    {
                        string message = "alert('" + "Error...! Uploading File" + "')";
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


        public void GetCapitalSubsidyBuildingDtls(string IncentiveId, string SubIncentiveId)
        {
            DataSet dsnew1 = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentveID",SqlDbType.VarChar),
              new SqlParameter("@SubIncentiveId",SqlDbType.VarChar),
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = SubIncentiveId;
            dsnew1 = ObjCAFClass.GenericFillDs("[USP_GET_CAPITAL_SUBSIDY_INPSECTIONBUILDINGDTLS]", pp);

            if (dsnew1 != null && dsnew1.Tables.Count > 0 && dsnew1.Tables[0].Rows.Count > 0)
            {
                GvBuildingDetails.DataSource = dsnew1.Tables[0];
                GvBuildingDetails.DataBind();
            }
            else
            {
                GvBuildingDetails.DataSource = null;
                GvBuildingDetails.DataBind();
            }
        }

        protected void ChkChangeReqest_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkChangeReqest.Checked == true)
            {
                ddlCategory.Enabled = true;
                ddlTypeofTextile.Enabled = true;
                /*ChkChangeReqest.Enabled = false;*/
            }
            else
            {
                ddlCategory.Enabled = false;
                ddlTypeofTextile.Enabled = false;
            }
        }
        private void BindModifiedSubsidyAmount()
        {
            try
            {
                string IncentiveID = hdnIncentiveId.Value;
                string SubIncentiveId = hdnSubIncentiveId.Value;
                string DistrictID = hdnDistrictId.Value;
                string Category = ddlCategory.SelectedValue;
                string TypeOfTextile = ddlTypeofTextile.SelectedValue;
                DataSet dsnew1 = new DataSet();
                //dsnew1 = GetSubsidyApplicationDeatils(IncentiveID, SubIncentiveId, DistrictID);
                dsnew1 = GetSubsidyApplicationDeatils_Modify(IncentiveID, SubIncentiveId, DistrictID, Category, TypeOfTextile);

                if (dsnew1 != null && dsnew1.Tables.Count > 0 && dsnew1.Tables[0].Rows.Count > 0)
                {

                    lblSubsidyClaimedUnit.InnerHtml = dsnew1.Tables[0].Rows[0]["UnitClaimedAmount"].ToString();
                    SubsidySystemRecommended.InnerHtml = dsnew1.Tables[0].Rows[0]["SystemRecommendedAmount"].ToString();

                    txtAmountSubsidyRecommended.Text = dsnew1.Tables[0].Rows[0]["SystemRecommendedAmount"].ToString();

                    if (SubIncentiveId == "1" || SubIncentiveId == "19")
                    {
                        Capitalsub.Visible = true;
                        txtIndustryPersonName.Visible = true;
                        if (SubIncentiveId == "1")
                        {
                            trcapitalsubsidy.Visible = true;
                            tdIORecommended.Visible = false;
                            tdIORecommended1.Visible = false;

                            lblSystemTotal.InnerHtml = dsnew1.Tables[0].Rows[0]["SystemRecommendedAmount"].ToString();
                            lblSystemSubsidy.InnerHtml = dsnew1.Tables[0].Rows[0]["CalSystemSubsidy"].ToString();
                            lblSystemAdditionalCapitalSubsidy.InnerHtml = dsnew1.Tables[0].Rows[0]["CalSystemAdditionalCapitalSubsidy"].ToString();
                        }
                        else
                        {
                            trcapitalsubsidy.Visible = false;
                        }

                        divplantmachinary.Visible = true;
                        grdPandM.DataSource = null;
                        grdPandM.DataBind();
                        BindPandMGrid(0, Convert.ToInt32(IncentiveID), hdnTypeOfIndustry.Value, hdnrUserRole.Value);
                        rbtnmachinesavailableYes_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (SubIncentiveId == "5")
                    {
                        trStampDuty.Visible = true;
                        lblNatureofAsset.InnerHtml = dsnew1.Tables[0].Rows[0]["NatureofAsset_Stampduty"].ToString();
                        lblavailedamount.InnerHtml = dsnew1.Tables[0].Rows[0]["Availedamount_Stampduty"].ToString();
                    }
                    if (SubIncentiveId == "7")
                    {
                        trAssistanceforEnergyWaterEnvironmental.Visible = true;
                        trAssistanceforEnergyWaterEnvironmental1.Visible = true;

                        string TypeofInfrastructure = dsnew1.Tables[0].Rows[0]["AssistanceRequired_AssistanceEnergy"].ToString();
                        if (TypeofInfrastructure != "")
                        {
                            string[] TypeofInfrastructureVal = TypeofInfrastructure.Split(',');

                            foreach (string Value in TypeofInfrastructureVal)
                            {
                                int Index = chkAssistanceRequired.Items.IndexOf(chkAssistanceRequired.Items.FindByValue(Value));
                                chkAssistanceRequired.Items[Index].Selected = true;
                            }
                        }

                        RbtnCommercialProduction.InnerText = dsnew1.Tables[0].Rows[0]["CommercialProductionText_AssistanceEnergy"].ToString();
                        txtReimbursementReceived.InnerHtml = dsnew1.Tables[0].Rows[0]["ReimbursementReceived_AssistanceEnergy"].ToString();
                    }

                    if (SubIncentiveId == "16")
                    {
                        trTrainingSubsidy.Visible = true;
                        trTrainingSubsidy1.Visible = true;

                        txtNumberofEmployees.InnerHtml = dsnew1.Tables[0].Rows[0]["NumberofEmployees_Training_Subsidy"].ToString();
                        txtNumberofEmployeesTrained.InnerHtml = dsnew1.Tables[0].Rows[0]["NumberofEmployeesTrained_Training_Subsidy"].ToString();
                        txtExpenditureIncurredTraining.InnerHtml = dsnew1.Tables[0].Rows[0]["ExpenditureIncurredTraining_Training_Subsidy"].ToString();
                    }
                    if (SubIncentiveId == "17")
                    {
                        trTrainingInfrastructureSubsidy1.Visible = true;
                        trTrainingInfrastructureSubsidy2.Visible = true;
                        trTrainingInfrastructureSubsidy3.Visible = true;
                        trTrainingInfrastructureSubsidy4.Visible = true;
                        trTrainingInfrastructureSubsidy5.Visible = true;

                        txtBuilding.InnerHtml = dsnew1.Tables[0].Rows[0]["Building_TrainingInfrastructure"].ToString();
                        txtPlantMachinery.InnerHtml = dsnew1.Tables[0].Rows[0]["PlantMachinery_TrainingInfrastructure"].ToString();
                        txtInstallationCharges.InnerHtml = dsnew1.Tables[0].Rows[0]["InstallationCharges_TrainingInfrastructure"].ToString();
                        txtElectrification.InnerHtml = dsnew1.Tables[0].Rows[0]["Electrification_TrainingInfrastructure"].ToString();
                        txtTrainingAids.InnerHtml = dsnew1.Tables[0].Rows[0]["TrainingAids_TrainingInfrastructure"].ToString();
                        txtFurniture.InnerHtml = dsnew1.Tables[0].Rows[0]["Furniture_TrainingInfrastructure"].ToString();
                        lblTotalInvestment.InnerHtml = dsnew1.Tables[0].Rows[0]["TotalInvestment_TrainingInfrastructure"].ToString();
                    }
                    // HMainheading.InnerHtml = dsnew1.Tables[0].Rows[0]["IncentiveName"].ToString() + " Inspection Report";
                    HMainheading.InnerHtml = "PART  B <br/> " + dsnew1.Tables[0].Rows[0]["IncentiveName"].ToString() + "<br/> Inspecting Officer Report";
                    lblInspectingOfficerName.InnerHtml = dsnew1.Tables[0].Rows[0]["Name"].ToString();
                    lblInspectionSchduledDate.InnerHtml = dsnew1.Tables[0].Rows[0]["SchduledDate"].ToString();

                    txtAppDateofInspection.Text = dsnew1.Tables[0].Rows[0]["SchduledDate"].ToString();

                    lblquerydate.InnerHtml = dsnew1.Tables[0].Rows[0]["QueryDate"].ToString();
                    lblresponsedate.InnerHtml = dsnew1.Tables[0].Rows[0]["QueryResponseDare"].ToString();



                    txtAppDateofInspection.Text = dsnew1.Tables[0].Rows[0]["InspectionDoneOn"].ToString();
                    txtRemarks.Text = dsnew1.Tables[0].Rows[0]["Remarks"].ToString();
                    txtIndustryPersonName.Text = dsnew1.Tables[0].Rows[0]["IndustryPersonName"].ToString();
                    txtIndDeptName.Text = dsnew1.Tables[0].Rows[0]["IndustryDeptPersonName"].ToString();
                    txtIndustryRemarks.Text = dsnew1.Tables[0].Rows[0]["IndustryDeptRemarks"].ToString();

                    hyplreportview.NavigateUrl = dsnew1.Tables[0].Rows[0]["UploadReportLink"].ToString();
                    if (hyplreportview.NavigateUrl != "")
                    {
                        hyplreportview.Visible = true;
                    }
                    else
                    {
                        hyplreportview.Visible = false;
                    }

                    GetIncetiveAttachements(IncentiveID, SubIncentiveId);

                    if (SubIncentiveId == "1")
                    {
                        trcapitalsubisdy.Visible = true;
                        GetCapitalSubsidyBuildingDtls(IncentiveID, SubIncentiveId);
                        // GvBuildingDetails
                    }
                    else
                    {
                        trcapitalsubisdy.Visible = false;
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
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*BindModifiedSubsidyAmount();*/
            if (hdnSubIncentiveId.Value == "2")
            {
                rbtnEquipmentavailableYes_SelectedIndexChanged(this, EventArgs.Empty);
            }
            else
            {
                rbtnmachinesavailableYes_SelectedIndexChanged(this, EventArgs.Empty);
            }
        }
        protected void ddlTypeofTextile_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*BindModifiedSubsidyAmount();*/
            if (hdnSubIncentiveId.Value == "2")
            {
                rbtnEquipmentavailableYes_SelectedIndexChanged(this, EventArgs.Empty);
            }
            else
            {
                rbtnmachinesavailableYes_SelectedIndexChanged(this, EventArgs.Empty);
            }
        }

        protected void CHKIncentive_CheckedChanged(object sender, EventArgs e)
        {
            ApplicationStatus ObjApplicationStatus = new ApplicationStatus();
            CheckBox chkbox = (CheckBox)sender;
            GridViewRow gr = (GridViewRow)chkbox.NamingContainer;

            string IncentiveID = Request.QueryString["IncentiveID"].ToString();
            string SubIncentiveId = Request.QueryString["SubIncentiveId"].ToString();

            // GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            Label lblBUILDINGID = ((Label)(gr.FindControl("lblBUILDINGID")));

            CheckBox CHKIncentive = ((CheckBox)(gr.FindControl("CHKIncentive")));
            if (Convert.ToInt32(lblBUILDINGID.Text) > 7)
            {
                string SelectedIds = "";
                List<InspectionBuildingDetails> lstBuildings = new List<InspectionBuildingDetails>();
                foreach (GridViewRow gvrow in GvBuildingDetails.Rows)
                {
                    Label lblBUILDINGIDADD = ((Label)(gvrow.FindControl("lblBUILDINGID")));
                    CheckBox CHKIncentiveADD = ((CheckBox)(gvrow.FindControl("CHKIncentive")));
                    Label lblBuildingId = ((Label)(gvrow.FindControl("lblBUILDINGID")));
                    Label lblCivilworks = ((Label)(gvrow.FindControl("lblCivilworks")));
                    TextBox txtDLOAmount = ((TextBox)(gvrow.FindControl("txtDLOAmount")));
                    TextBox txtBuildingRemarks = ((TextBox)(gvrow.FindControl("txtBuildingRemarks")));
                    if (Convert.ToInt32(lblBUILDINGIDADD.Text) > 7 && CHKIncentiveADD.Checked)
                    {
                        if (SelectedIds == "")
                        {
                            SelectedIds = lblBUILDINGIDADD.Text;
                        }
                        else
                        {
                            SelectedIds = SelectedIds + "," + lblBUILDINGIDADD.Text;
                        }
                    }
                    lstBuildings.Add(new InspectionBuildingDetails
                    {
                        BuildingId = lblBuildingId.Text.Trim(),
                        CivilWorkName = lblCivilworks.Text.Trim(),
                        DLOValue = txtDLOAmount.Text.Trim(),
                        DLORemarks = txtBuildingRemarks.Text.Trim(),
                        PurchasedLandValueDLO = txtDLOLandRecomendAmountPerAcre.Text.Trim()
                    });
                }

                XElement xmlBuilding = new XElement("xmlBuilding_xml",
                       from Building in lstBuildings
                       select new XElement("BuildingTable",
                       new XElement("BuildingId", Building.BuildingId),
                       new XElement("CivilWorkName", Building.CivilWorkName),
                       new XElement("DLOValue", Building.DLOValue),
                       new XElement("DLORemarks", Building.DLORemarks),
                       new XElement("PurchasedLandValueDLO", Building.PurchasedLandValueDLO)
                       ));

                ObjApplicationStatus.BuildingXml = xmlBuilding.ToString();

                string PmSelectedIds = "";
                List<InspectionPlantandMachinary> lstPMs = new List<InspectionPlantandMachinary>();
                foreach (GridViewRow gvrow in grdPandM.Rows)
                {
                    Label lblPMId = ((Label)(gvrow.FindControl("lblPMId")));
                    RadioButtonList rbtnmachinesavailableYes = ((RadioButtonList)(gvrow.FindControl("rbtnmachinesavailableYes")));
                    TextBox txtAdmissibleAmount = ((TextBox)(gvrow.FindControl("txtAdmissibleAmount")));
                    Label lblMachineCost = ((Label)(gvrow.FindControl("lblMachineCost")));

                    if (rbtnmachinesavailableYes.SelectedValue == "A")
                    {
                        txtAdmissibleAmount.Enabled = true;
                        if (txtAdmissibleAmount.Text == "")
                        {
                            txtAdmissibleAmount.Text = lblMachineCost.Text;
                        }
                    }

                    if (rbtnmachinesavailableYes.SelectedValue == "A")
                    {
                        lstPMs.Add(new InspectionPlantandMachinary
                        {
                            PMID = lblPMId.Text,
                            MachineCost = txtAdmissibleAmount.Text
                        });
                    }

                    if (rbtnmachinesavailableYes.SelectedValue == "N" || rbtnmachinesavailableYes.SelectedValue == "A")
                    {
                        if (PmSelectedIds == "")
                        {
                            PmSelectedIds = lblPMId.Text;
                        }
                        else
                        {
                            PmSelectedIds = PmSelectedIds + "," + lblPMId.Text;
                        }
                    }
                }

                XElement xmlPMUpload = new XElement("xmlPMUpload_xml",
                           from PMs in lstPMs
                           select new XElement("PMsTable",
                           new XElement("PMID", PMs.PMID),
                           new XElement("MachineCost", PMs.MachineCost)
                           ));

                ObjApplicationStatus.PMXml = xmlPMUpload.ToString();

                string CalSystemSubsidy = "", CalSystemAdditionalCapitalSubsidy = "", Flag = "N", LandValue = "", BuildingValue = "", PMValue = "", OthersValue = "";
                string Category = ddlCategory.SelectedValue;
                string TypeOfTextile = ddlTypeofTextile.SelectedValue;
                if (ChkChangeReqest.Checked == true) { Flag = "Y"; };

                string SystemRecommendedAmount = ObjCAFClass.GetCapitalSubsidySelected(IncentiveID, SubIncentiveId, SelectedIds, PmSelectedIds, Category, TypeOfTextile, Flag, ObjApplicationStatus, out CalSystemSubsidy, out CalSystemAdditionalCapitalSubsidy, out LandValue, out BuildingValue, out PMValue, out OthersValue);

                SubsidySystemRecommended.InnerHtml = SystemRecommendedAmount;
                txtAmountSubsidyRecommended.Text = SystemRecommendedAmount;
                hdnLandValue.Value = LandValue;
                hdnBuildingValue.Value = BuildingValue;
                hdnPMValue.Value = PMValue;
                hdnOthersValue.Value = OthersValue;

                lblSystemSubsidy.InnerHtml = CalSystemSubsidy;
                lblSystemAdditionalCapitalSubsidy.InnerHtml = CalSystemAdditionalCapitalSubsidy;
                if (ChkChangeReqest.Checked == false)
                {
                    hdnSubsidySystemRecommended.Value = SystemRecommendedAmount;
                    hdnSystemSubsidy.Value = CalSystemSubsidy;
                    hdnSystemAdditionalCapitalSubsidy.Value = CalSystemAdditionalCapitalSubsidy;
                    hdnSystemTotal.Value = SystemRecommendedAmount;
                }
            }
        }

        protected void txtInspectingOfficerSubsidy_TextChanged(object sender, EventArgs e)
        {
            decimal InspectingOfficerSubsidy = 0;
            decimal InspectingOfficerAdditionalCapitalSubsidy = 0;
            if (txtInspectingOfficerSubsidy.Text.Trim() != "")
            {
                InspectingOfficerSubsidy = Convert.ToDecimal(GetDecimalNullValue(txtInspectingOfficerSubsidy.Text.Trim()));
            }
            if (txtInspectingOfficerAdditionalCapitalSubsidy.Text.Trim() != "")
            {
                InspectingOfficerAdditionalCapitalSubsidy = Convert.ToDecimal(GetDecimalNullValue(txtInspectingOfficerAdditionalCapitalSubsidy.Text.Trim()));
            }

            lblInspectingOfficerTotal.InnerHtml = (InspectingOfficerSubsidy + InspectingOfficerAdditionalCapitalSubsidy).ToString();
        }

        public void BindPandMGrid(int PMId, int IncentiveId, string IndusType, string Role)
        {
            DataSet ds = new DataSet();
            try
            {
                grdPandM.DataSource = null;
                grdPandM.DataBind();
                ds = GetPandM(PMId, IncentiveId, IndusType, Role);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdPandM.DataSource = ds.Tables[0];
                    grdPandM.DataBind();
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
        public DataSet GetPandM(int PMId, int IncentiveId, string IndusType, string Role)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@PMId",SqlDbType.Int),
               new SqlParameter("@Role",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = PMId;
            pp[2].Value = Role;
            string ProcName = "";
            if (IndusType == "1")
            {
                ProcName = "USP_GET_PLANTANDMACHINERY";
            }
            else
            {
                ProcName = "USP_GET_PLANTANDMACHINERY_ExistingUnit";
            }
            Dsnew = ObjCAFClass.GenericFillDs(ProcName, pp);
            //Dsnew = ObjCAFClass.GenericFillDs("USP_GET_PLANTANDMACHINERY", pp);
            return Dsnew;
        }
        protected void BindEquipmentDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetEquipmentDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    gvEquipments.DataSource = dsnew.Tables[0];
                    gvEquipments.DataBind();
                }
                else
                {
                    gvEquipments.DataSource = null;
                    gvEquipments.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetEquipmentDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_Equipment_DTLS", pp);
            return Dsnew;
        }

        protected void rbtnmachinesavailableYes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RadioButtonList rbtnlist = (RadioButtonList)sender;
            //GridViewRow gvr = (GridViewRow)rbtnlist.NamingContainer;

            //TextBox txtremarks = (TextBox)gvr.FindControl("txtremarks");
            //txtremarks.Visible = true;

            ApplicationStatus ObjApplicationStatus = new ApplicationStatus();

            string IncentiveID = Request.QueryString["IncentiveID"].ToString();
            string SubIncentiveId = Request.QueryString["SubIncentiveId"].ToString();

            string SelectedIds = "";
            List<InspectionBuildingDetails> lstBuildings = new List<InspectionBuildingDetails>();
            foreach (GridViewRow gvrow in GvBuildingDetails.Rows)
            {
                Label lblBUILDINGIDADD = ((Label)(gvrow.FindControl("lblBUILDINGID")));
                CheckBox CHKIncentiveADD = ((CheckBox)(gvrow.FindControl("CHKIncentive")));
                Label lblBuildingId = ((Label)(gvrow.FindControl("lblBUILDINGID")));
                Label lblCivilworks = ((Label)(gvrow.FindControl("lblCivilworks")));
                TextBox txtDLOAmount = ((TextBox)(gvrow.FindControl("txtDLOAmount")));
                TextBox txtBuildingRemarks = ((TextBox)(gvrow.FindControl("txtBuildingRemarks")));
                TextBox txtDLOPlinthArea = ((TextBox)(gvrow.FindControl("txtDLOPlinthArea")));
                string DLOPlinthArea = "";
                if (CHKIncentiveADD.Checked == true)
                {
                    DLOPlinthArea = txtDLOPlinthArea.Text.Trim();
                }
                else
                {
                    DLOPlinthArea = "0.00";
                }
                if (Convert.ToInt32(lblBUILDINGIDADD.Text) > 7 && CHKIncentiveADD.Checked)
                {
                    if (SelectedIds == "")
                    {
                        SelectedIds = lblBUILDINGIDADD.Text;
                    }
                    else
                    {
                        SelectedIds = SelectedIds + "," + lblBUILDINGIDADD.Text;
                    }
                }
                lstBuildings.Add(new InspectionBuildingDetails
                {
                    BuildingId = lblBuildingId.Text.Trim(),
                    CivilWorkName = lblCivilworks.Text.Trim(),
                    DLOValue = txtDLOAmount.Text.Trim(),
                    DLORemarks = txtBuildingRemarks.Text.Trim(),
                    DLOPlinthArea = DLOPlinthArea,
                    DLOLandPerAcreValue = txtDLOLandRecomendAmountPerAcre.Text.Trim(),
                    ApprovedLandValue = txtlandexisting.InnerText.Trim(),
                    InvestedLandValue = txtExpansionLandValue.InnerText.Trim(),
                    ApprovedBuildingValue = txtbuildingexisting.InnerText.Trim(),
                    InvestedBuildingValue = txtExpansionBuildingValue.InnerText.Trim(),
                    ApprovedPMValue = txtplantexisting.InnerText.Trim(),
                    InvestedPMValue = txtExpansionplantMechValue.InnerText.Trim()
                });
            }


            XElement xmlBuilding = new XElement("xmlBuilding_xml",
                       from Building in lstBuildings
                       select new XElement("BuildingTable",
                       new XElement("BuildingId", Building.BuildingId),
                       new XElement("CivilWorkName", Building.CivilWorkName),
                       new XElement("DLOValue", Building.DLOValue),
                       new XElement("DLORemarks", Building.DLORemarks),
                       new XElement("DLOPlinthArea", Building.DLOPlinthArea),
                       new XElement("DLOLandPerAcreValue", Building.DLOLandPerAcreValue),
                       new XElement("ApprovedLandValue", Building.ApprovedLandValue),
                       new XElement("InvestedLandValue", Building.InvestedLandValue),
                       new XElement("ApprovedBuildingValue", Building.ApprovedBuildingValue),
                       new XElement("InvestedBuildingValue", Building.InvestedBuildingValue),
                       new XElement("ApprovedPMValue", Building.ApprovedPMValue),
                       new XElement("InvestedPMValue", Building.InvestedPMValue)
                       ));

            ObjApplicationStatus.BuildingXml = xmlBuilding.ToString();


            string PmSelectedIds = "";
            List<InspectionPlantandMachinary> lstPMs = new List<InspectionPlantandMachinary>();
            foreach (GridViewRow gvrow in grdPandM.Rows)
            {
                Label lblPMId = ((Label)(gvrow.FindControl("lblPMId")));
                Label lblMachineCost = ((Label)(gvrow.FindControl("lblMachineCost")));
                TextBox txtAdmissibleAmount = ((TextBox)(gvrow.FindControl("txtAdmissibleAmount")));
                RadioButtonList rbtnmachinesavailableYes = ((RadioButtonList)(gvrow.FindControl("rbtnmachinesavailableYes")));

                if (rbtnmachinesavailableYes.SelectedValue == "A")
                {
                    txtAdmissibleAmount.Enabled = true;
                    if (txtAdmissibleAmount.Text == "")
                    {
                        txtAdmissibleAmount.Text = lblMachineCost.Text;
                    }
                }

                if (rbtnmachinesavailableYes.SelectedValue == "A")
                {
                    lstPMs.Add(new InspectionPlantandMachinary
                    {
                        PMID = lblPMId.Text,
                        MachineCost = txtAdmissibleAmount.Text
                    });
                }

                if (rbtnmachinesavailableYes.SelectedValue == "N" || rbtnmachinesavailableYes.SelectedValue == "A")
                {
                    if (PmSelectedIds == "")
                    {
                        PmSelectedIds = lblPMId.Text;
                    }
                    else
                    {
                        PmSelectedIds = PmSelectedIds + "," + lblPMId.Text;
                    }
                }
            }

            XElement xmlPMUpload = new XElement("xmlPMUpload_xml",
                       from PMs in lstPMs
                       select new XElement("PMsTable",
                       new XElement("PMID", PMs.PMID),
                       new XElement("MachineCost", PMs.MachineCost)
                       ));

            ObjApplicationStatus.PMXml = xmlPMUpload.ToString();

            string CalSystemSubsidy = "", CalSystemAdditionalCapitalSubsidy = "", Flag = "N", LandValue = "", BuildingValue = "", PMValue = "", OthersValue = "";
            string Category = ddlCategory.SelectedValue;
            string TypeOfTextile = ddlTypeofTextile.SelectedValue;
            if (ChkChangeReqest.Checked == true) { Flag = "Y"; }
            string SystemRecommendedAmount = ObjCAFClass.GetCapitalSubsidySelected(IncentiveID, SubIncentiveId, SelectedIds, PmSelectedIds, Category, TypeOfTextile, Flag, ObjApplicationStatus, out CalSystemSubsidy, out CalSystemAdditionalCapitalSubsidy, out LandValue, out BuildingValue, out PMValue, out OthersValue);

            SubsidySystemRecommended.InnerHtml = SystemRecommendedAmount;
            txtAmountSubsidyRecommended.Text = SystemRecommendedAmount;
            hdnLandValue.Value = LandValue;
            hdnBuildingValue.Value = BuildingValue;
            hdnPMValue.Value = PMValue;
            hdnOthersValue.Value = OthersValue;
            lblCalcLandValue.Text = LandValue;
            lblCalcBuildingValue.Text = BuildingValue;
            lblCalcPMValue.Text = PMValue;
            if (SubIncentiveId == "1")
            {
                CalculateBuildingData();
            }
            lblSystemSubsidy.InnerHtml = CalSystemSubsidy;
            lblSystemAdditionalCapitalSubsidy.InnerHtml = CalSystemAdditionalCapitalSubsidy;
            lblSystemTotal.InnerHtml = SystemRecommendedAmount;


            if (ChkChangeReqest.Checked == false)
            {
                hdnSubsidySystemRecommended.Value = SystemRecommendedAmount;
                hdnSystemSubsidy.Value = CalSystemSubsidy;
                hdnSystemAdditionalCapitalSubsidy.Value = CalSystemAdditionalCapitalSubsidy;
                hdnSystemTotal.Value = SystemRecommendedAmount;
            }

        }
        public string ValidateControlsdraft()
        {
            int slno = 1;
            string ErrorMsg = "";
            if (hdnrUserRole.Value != "IND")
            {
                if (txtAppDateofInspection.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Date of Inspection \\n";
                    slno = slno + 1;
                }
                if (txtIndustryPersonName.Text.Trim().TrimStart().TrimEnd() == "")// && (Request.QueryString["SubIncentiveId"] == "1" || Request.QueryString["SubIncentiveId"] == "19"))
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Eneter Person from the Industry present at the time of Inspection \\n";
                    slno = slno + 1;
                }
            }
            if (hdnrUserRole.Value == "IND")
            {
                if (txtIndDeptName.Text.Trim().TrimStart().TrimEnd() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ".Please Enter Name of the Industries Department Person who Updating the Report \\n";
                    slno = slno + 1;
                }
            }
            if (fpdSpecimen.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fpdSpecimen);
                if (errormsg != "")
                {
                    // string message = "alert('" + errormsg + "')";
                    ErrorMsg = ErrorMsg + slno + "." + errormsg + " \\n";
                    slno = slno + 1;
                }

                string Mimetype = objClsFileUpload.getmimetype(fpdSpecimen);
                if (Mimetype == "application/pdf")
                {

                }
                else
                {
                    ErrorMsg = ErrorMsg + slno + ". Only pdf files allowed! \\n";
                    slno = slno + 1;
                }
            }


            if (Request.QueryString["SubIncentiveId"] == "1" || Request.QueryString["SubIncentiveId"] == "19")
            {
                foreach (GridViewRow gvrow in grdPandM.Rows)
                {
                    RadioButtonList rbtnList = (RadioButtonList)gvrow.FindControl("rbtnmachinesavailableYes");
                    TextBox txtremarks = (TextBox)gvrow.FindControl("txtremarks");
                    TextBox txtAdmissibleAmount = (TextBox)gvrow.FindControl("txtAdmissibleAmount");
                    if (rbtnList.SelectedIndex == -1)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Check Availability of the Machine in Running Condition under Plant and Machinary at Sno " + (gvrow.RowIndex + 1).ToString() + " \\n";
                        slno = slno + 1;
                        break;
                    }
                    else if ((rbtnList.SelectedValue == "N" || rbtnList.SelectedValue == "A") && txtremarks.Text.Trim().TrimStart() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter the Reasons for the Discrepancy at Sno " + (gvrow.RowIndex + 1).ToString() + " \\n";
                        slno = slno + 1;
                        break;
                    }
                    else if (rbtnList.SelectedValue == "A" && txtAdmissibleAmount.Text.Trim().TrimStart() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter the Admissible Amount at Sno " + (gvrow.RowIndex + 1).ToString() + " \\n";
                        slno = slno + 1;
                        break;
                    }

                }
            }

            return ErrorMsg;
        }
        protected void btndraft_Click(object sender, EventArgs e)
        {
            try
            {
                string errormsg = ValidateControlsdraft();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {

                    ApplicationStatus ObjApplicationStatus = new ApplicationStatus();
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    string IncentiveID = Request.QueryString["IncentiveID"].ToString();
                    string SubIncentiveId = Request.QueryString["SubIncentiveId"].ToString();

                    ObjApplicationStatus.IncentiveId = IncentiveID;
                    ObjApplicationStatus.SubIncentiveId = SubIncentiveId;
                    ObjApplicationStatus.CreatedBy = ObjLoginNewvo.uid;

                    if (txtAppDateofInspection.Text.Trim().TrimStart() != "")
                    {
                        ObjApplicationStatus.InspectionDate = GetFromatedDateDDMMYYYY(txtAppDateofInspection.Text.Trim().TrimStart());
                    }
                    if (SubIncentiveId == "1")
                    {

                        List<InspectionBuildingDetails> lstBuildings = new List<InspectionBuildingDetails>();
                        foreach (GridViewRow gvrow in GvBuildingDetails.Rows)
                        {
                            Label lblBUILDINGIDADD = ((Label)(gvrow.FindControl("lblBUILDINGID")));
                            CheckBox CHKIncentiveADD = ((CheckBox)(gvrow.FindControl("CHKIncentive")));
                            Label lblBuildingId = ((Label)(gvrow.FindControl("lblBUILDINGID")));
                            Label lblCivilworks = ((Label)(gvrow.FindControl("lblCivilworks")));
                            TextBox txtDLOAmount = ((TextBox)(gvrow.FindControl("txtDLOAmount")));
                            TextBox txtBuildingRemarks = ((TextBox)(gvrow.FindControl("txtBuildingRemarks")));
                            TextBox txtDLOPlinthArea = ((TextBox)(gvrow.FindControl("txtDLOPlinthArea")));
                            TextBox txtDLOSqmterValue = ((TextBox)(gvrow.FindControl("txtDLOSqmterValue")));
                            string DLOPlinthArea = "", DLOSqmterValue = "";
                            DLOPlinthArea = txtDLOPlinthArea.Text.Trim();
                            if (txtDLOSqmterValue.Text.Trim() == "" || txtDLOSqmterValue.Text.Trim() == null)
                            {
                                DLOPlinthArea = "0.00";
                            }
                            else
                            {
                                DLOSqmterValue = txtDLOSqmterValue.Text.Trim();
                            }

                            lstBuildings.Add(new InspectionBuildingDetails
                            {
                                BuildingId = lblBuildingId.Text.Trim(),
                                CivilWorkName = lblCivilworks.Text.Trim(),
                                DLOValue = txtDLOAmount.Text.Trim(),
                                DLORemarks = txtBuildingRemarks.Text.Trim(),
                                DLOPlinthArea = DLOPlinthArea,
                                DLOSqmterValue = DLOSqmterValue
                            });
                        }

                        XElement xmlBuilding = new XElement("xmlBuilding_xml",
                                   from Building in lstBuildings
                                   select new XElement("BuildingTable",
                                   new XElement("BuildingId", Building.BuildingId),
                                   new XElement("CivilWorkName", Building.CivilWorkName),
                                   new XElement("DLOValue", Building.DLOValue),
                                   new XElement("DLORemarks", Building.DLORemarks),
                                   new XElement("DLOPlinthArea", Building.DLOPlinthArea),
                                   new XElement("DLOSqmterValue", Building.DLOSqmterValue)
                                   ));

                        ObjApplicationStatus.BuildingXml = xmlBuilding.ToString();
                        ObjApplicationStatus.DLOCalculatedLandAmount = hdnLandValue.Value;
                        ObjApplicationStatus.DLOCalculatedBuildingAmount = hdnBuildingValue.Value;
                        ObjApplicationStatus.DLOCalculatedPMAmount = hdnPMValue.Value;
                        ObjApplicationStatus.DLOCalculatedOthersAmount = hdnOthersValue.Value;
                        ObjApplicationStatus.DLOLandPerAcreValue = txtDLOLandRecomendAmountPerAcre.Text.Trim();
                        ObjApplicationStatus.DLORecommendedLandExtent = txtDLOExtent.Text.Trim();
                        ObjApplicationStatus.DLOLandPerAcreRemarks = txtDLOLandRemarks.Text;

                        ObjApplicationStatus.RecommendedAmount = GetDecimalNullValue(lblInspectingOfficerTotal.InnerHtml.Trim().TrimStart());
                        ObjApplicationStatus.CapitalSubsidyAmount = GetDecimalNullValue(txtInspectingOfficerSubsidy.Text.Trim().TrimStart());
                        ObjApplicationStatus.AdditionalCapitalSubsidyAmount = GetDecimalNullValue(txtInspectingOfficerAdditionalCapitalSubsidy.Text.Trim().TrimStart());

                        ObjApplicationStatus.SystemCapitalSubsidyAmount = GetDecimalNullValue(lblSystemSubsidy.InnerHtml.Trim().TrimStart());
                        ObjApplicationStatus.SystemAdditionalCapitalSubsidyAmount = GetDecimalNullValue(lblSystemAdditionalCapitalSubsidy.InnerHtml.Trim().TrimStart());

                        ObjApplicationStatus.Actual_RecommendedAmount = GetDecimalNullValue(hdnSubsidySystemRecommended.Value.Trim().TrimStart());
                        ObjApplicationStatus.Actual_CapitalSubsidyAmount = GetDecimalNullValue(hdnSubsidySystemRecommended.Value.Trim().TrimStart());
                        ObjApplicationStatus.Actual_AdditionalCapitalSubsidyAmount = GetDecimalNullValue(hdnSystemAdditionalCapitalSubsidy.Value.Trim().TrimStart());
                        ObjApplicationStatus.Actual_SystemCapitalSubsidyAmount = GetDecimalNullValue(hdnSystemSubsidy.Value.Trim().TrimStart());
                        ObjApplicationStatus.Actual_SystemAdditionalCapitalSubsidyAmount = GetDecimalNullValue(hdnSystemAdditionalCapitalSubsidy.Value.Trim().TrimStart());
                    }
                    else
                    {
                        ObjApplicationStatus.RecommendedAmount = GetDecimalNullValue(txtAmountSubsidyRecommended.Text.Trim().TrimStart());
                        ObjApplicationStatus.Actual_RecommendedAmount = GetDecimalNullValue(hdnSubsidySystemRecommended.Value.Trim().TrimStart());
                    }
                    if (SubIncentiveId == "1" || SubIncentiveId == "19")
                    {

                        List<InspectionPlantandMachinary> lstPMs = new List<InspectionPlantandMachinary>();

                        foreach (GridViewRow gvrow in grdPandM.Rows)
                        {
                            RadioButtonList rbtnList = (RadioButtonList)gvrow.FindControl("rbtnmachinesavailableYes");
                            TextBox txtremarks = (TextBox)gvrow.FindControl("txtremarks");
                            Label lblPMId = (Label)gvrow.FindControl("lblPMId");
                            Label lblIncentiveId = (Label)gvrow.FindControl("lblIncentiveId");
                            TextBox txtAdmissibleAmount = (TextBox)gvrow.FindControl("txtAdmissibleAmount");

                            lstPMs.Add(new InspectionPlantandMachinary
                            {
                                PMID = lblPMId.Text,
                                IncentiveId = lblIncentiveId.Text,
                                MachineAvailability = rbtnList.SelectedValue,
                                Remarks = txtremarks.Text,
                                MachineCost = txtAdmissibleAmount.Text
                            });
                        }

                        XElement xmlPMUpload = new XElement("xmlPMUpload_xml",
                        from PMs in lstPMs
                        select new XElement("PMsTable",
                        new XElement("PMID", PMs.PMID),
                        new XElement("IncentiveId", PMs.IncentiveId),
                        new XElement("MachineAvailability", PMs.MachineAvailability),
                        new XElement("Remarks", PMs.Remarks),
                        new XElement("MachineCost", PMs.MachineCost)
                        ));

                        ObjApplicationStatus.PMXml = xmlPMUpload.ToString();
                    }
                    if (SubIncentiveId == "2")
                    {
                        List<InspectionEquipment> lstPMs = new List<InspectionEquipment>();

                        foreach (GridViewRow gvrow in gvEquipments.Rows)
                        {
                            Label lblEquipment_ID = ((Label)(gvrow.FindControl("lblEquipment_ID")));
                            Label lblIncentiveId = ((Label)(gvrow.FindControl("lblIncentiveId")));
                            Label lblTotal = ((Label)(gvrow.FindControl("lblTotal")));
                            Label lblCategoryId = ((Label)(gvrow.FindControl("lblCategoryId")));
                            Label lblNameoftheEquipment = ((Label)(gvrow.FindControl("lblNameoftheEquipment")));
                            TextBox txtAdmissibleAmountEq = ((TextBox)(gvrow.FindControl("txtAdmissibleAmountEq")));
                            TextBox txtremarksEq = ((TextBox)(gvrow.FindControl("txtremarksEq")));
                            RadioButtonList rbtnEquipmentavailableYes = ((RadioButtonList)(gvrow.FindControl("rbtnEquipmentavailableYes")));

                            lstPMs.Add(new InspectionEquipment
                            {
                                EquipmentId = lblEquipment_ID.Text,
                                IncentiveId = lblIncentiveId.Text,
                                EquipmentName = lblNameoftheEquipment.Text.Trim(),
                                EquipmentAvailability = rbtnEquipmentavailableYes.SelectedValue,
                                Remarks = txtremarksEq.Text,
                                EquipmentCost = txtAdmissibleAmountEq.Text,
                                Category = lblCategoryId.Text
                            });
                        }

                        XElement xmlEqppload = new XElement("xmlEqpUpload_xml",
                        from PMs in lstPMs
                        select new XElement("EqpsTable",
                        new XElement("EquipmentId", PMs.EquipmentId),
                        new XElement("IncentiveId", PMs.IncentiveId),
                        new XElement("EquipmentName", PMs.EquipmentName),
                        new XElement("EquipmentAvailability", PMs.EquipmentAvailability),
                        new XElement("Remarks", PMs.Remarks),
                        new XElement("EquipmentCost", PMs.EquipmentCost),
                        new XElement("Category", PMs.Category)
                        ));

                        ObjApplicationStatus.EquipmentXml = xmlEqppload.ToString();
                    }
                    if (SubIncentiveId == "3")
                    {
                        List<InspectionInterestSubsidy> lstInterest = new List<InspectionInterestSubsidy>();

                        foreach (GridViewRow gvrow in gvAdditionalInformation.Rows)
                        {

                            TextBox txtDLORemarks = (TextBox)gvrow.FindControl("txtDLORemarks");
                            Label lblAdditionalinformationId = (Label)gvrow.FindControl("lblAdditionalinformationId");
                            Label lblIncentiveId = (Label)gvrow.FindControl("lblIncentiveId");
                            Label lblEligibleInterest = (Label)gvrow.FindControl("lblEligibleInterest");
                            TextBox txtDLOEligibleInterest = (TextBox)gvrow.FindControl("txtDLOEligibleInterest");

                            lstInterest.Add(new InspectionInterestSubsidy
                            {
                                AdditionalinformationId = lblAdditionalinformationId.Text,
                                IncentiveId = lblIncentiveId.Text,
                                ActualEligibleInterest = lblEligibleInterest.Text,
                                Remarks = txtDLORemarks.Text,
                                DLORecommendedEligibleInterest = txtDLOEligibleInterest.Text
                            });
                        }
                        XElement xmlInterest = new XElement("xmlInterest_xml",
                       from Interest in lstInterest
                       select new XElement("InterestTable",
                       new XElement("AdditionalinformationId", Interest.AdditionalinformationId),
                       new XElement("IncentiveId", Interest.IncentiveId),
                       new XElement("ActualEligibleInterest", Interest.ActualEligibleInterest),
                       new XElement("Remarks", Interest.Remarks),
                       new XElement("DLORecommendedEligibleInterest", Interest.DLORecommendedEligibleInterest)
                       ));

                        ObjApplicationStatus.InterestXml = xmlInterest.ToString();
                    }

                    ObjApplicationStatus.Remarks = txtRemarks.Text.Trim().TrimStart();
                    ObjApplicationStatus.IndustryPersonName = txtIndustryPersonName.Text.Trim().TrimStart();
                    ObjApplicationStatus.SystemRecommended = SubsidySystemRecommended.InnerHtml;
                    ObjApplicationStatus.Actual_SystemRecommended = GetDecimalNullValue(hdnSubsidySystemRecommended.Value.Trim().TrimStart());
                    if (ddlCategory.SelectedValue != hdnActualCategory.Value || ddlTypeofTextile.SelectedValue != hdnActualTextile.Value)
                    {
                        ObjApplicationStatus.Ins_Flag = "Y";
                    }
                    else
                    {
                        ObjApplicationStatus.Ins_Flag = "N";
                    }
                    ObjApplicationStatus.Ins_Category = ddlCategory.SelectedValue;
                    ObjApplicationStatus.Ins_TypeOfTextile = ddlTypeofTextile.SelectedValue;
                    ObjApplicationStatus.IndustryDeptFlag = "";
                    ObjApplicationStatus.IndustryDeptRemarks = txtIndustryRemarks.Text;
                    ObjApplicationStatus.DLOManualRecommendAmount = lblDLOSuggestedAmount.Text;

                    if (hdnrUserRole.Value == "IND")
                    {
                        ObjApplicationStatus.IndustryDeptFlag = "Y";
                        if (chkind.Checked == true)
                        {
                            ObjApplicationStatus.IndustryDeptReportStatus = "C";
                        }
                        else
                        {
                            ObjApplicationStatus.IndustryDeptReportStatus = "P";
                        }

                    }
                    ObjApplicationStatus.IndustryDeptPersonName = txtIndDeptName.Text;

                    //HyperLink HylUpload1 = new HyperLink();
                    objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fpdSpecimen, hyplreportview, "DLOInspectionReport", ObjApplicationStatus.IncentiveId, ObjApplicationStatus.SubIncentiveId, "161111", Session["uid"].ToString(), "INSPECTINGOFFICER");
                    hyplreportview.Visible = true;
                    string OutPut = "1";
                    if (OutPut == "1")
                    {
                        string Status = ObjCAFClass.UpdateInspectionReportdraft(ObjApplicationStatus);
                        if (Convert.ToInt32(Status) > 0)
                        {
                            string Successmsg = "";

                            txtAppDateofInspection.Text = "";
                            txtAmountSubsidyRecommended.Text = "";

                            BtnSave.Enabled = false;
                            if (chkind.Checked == true)
                            {
                                Successmsg = "Inspection Report Details Submitted to DLO Successfully";
                                string message = "alert('" + Successmsg + "')";
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            }
                            else
                            {
                                Successmsg = "Inspection Report Details Saved Successfully";
                                string message = "alert('" + Successmsg + "')";
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                            }
                        }
                    }
                    else
                    {
                        string message = "alert('" + "Error...! Uploading File" + "')";
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

        protected void grdPandM_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    RadioButtonList ddlAction = (e.Row.FindControl("rbtnmachinesavailableYes") as RadioButtonList);
                    string Actiontaken = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MachineAvailability"));
                    if (Actiontaken != "")
                    {
                        ddlAction.SelectedValue = Actiontaken;
                    }
                }
            }
            catch (Exception ex)
            {
                //lblmsg0.Text = "Internal error has occured. Please try after some time";
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                // LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        protected void btnImgNamePlate_Click(object sender, EventArgs e)
        {
            string IncentiveID = Request.QueryString["IncentiveID"].ToString();
            string SubIncentiveId = Request.QueryString["SubIncentiveId"].ToString();
            try
            {
                if (fuNamePlate.HasFile)
                {
                    string errormsg = objClsFileUpload.CheckFileSize(fuNamePlate);
                    if (errormsg != "")
                    {
                        string message = "alert('" + errormsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                    string Mimetype = objClsFileUpload.getmimetype(fuNamePlate);
                    if (Mimetype == "image/pjpeg" || Mimetype == "image/jpeg")
                    {
                        string OutPut = objClsFileUpload.DLOImageUploading("~\\InspectionImages", Server.MapPath("~\\InspectionImages"), fuNamePlate, hypNamePlate, "ImageUploads", IncentiveID, SubIncentiveId, hdnUserId.Value, "DLO", "1");
                        if (OutPut != "0")
                        {
                            success.Visible = false;
                            Failure.Visible = false;
                            hypNamePlate.Visible = true;
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Image Uploaded Successfully');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Only Image files allowed ');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Image');", true);
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
        protected void btnImgPM1_Click(object sender, EventArgs e)
        {
            string IncentiveID = Request.QueryString["IncentiveID"].ToString();
            string SubIncentiveId = Request.QueryString["SubIncentiveId"].ToString();
            try
            {
                if (fuPM1.HasFile)
                {
                    string errormsg = objClsFileUpload.CheckFileSize(fuPM1);
                    if (errormsg != "")
                    {
                        string message = "alert('" + errormsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                    string Mimetype = objClsFileUpload.getmimetype(fuPM1);
                    if (Mimetype == "image/pjpeg" || Mimetype == "image/jpeg")
                    {
                        string OutPut = objClsFileUpload.DLOImageUploading("~\\InspectionImages", Server.MapPath("~\\InspectionImages"), fuPM1, hypPM1, "ImageUploads", IncentiveID, SubIncentiveId, hdnUserId.Value, "DLO", "2");
                        if (OutPut != "0")
                        {
                            success.Visible = false;
                            Failure.Visible = false;
                            hypPM1.Visible = true;
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Image Uploaded Successfully');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Only Image files allowed');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Image');", true);
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

        protected void btnImgPM2_Click(object sender, EventArgs e)
        {
            string IncentiveID = Request.QueryString["IncentiveID"].ToString();
            string SubIncentiveId = Request.QueryString["SubIncentiveId"].ToString();
            try
            {
                if (fuPM2.HasFile)
                {
                    string errormsg = objClsFileUpload.CheckFileSize(fuPM2);
                    if (errormsg != "")
                    {
                        string message = "alert('" + errormsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                    string Mimetype = objClsFileUpload.getmimetype(fuPM2);
                    if (Mimetype == "image/pjpeg" || Mimetype == "image/jpeg")
                    {
                        string OutPut = objClsFileUpload.DLOImageUploading("~\\InspectionImages", Server.MapPath("~\\InspectionImages"), fuPM2, hypPM2, "ImageUploads", IncentiveID, SubIncentiveId, hdnUserId.Value, "DLO", "3");
                        if (OutPut != "0")
                        {
                            success.Visible = false;
                            Failure.Visible = false;
                            hypPM2.Visible = true;
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Image Uploaded Successfully');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Only Image files allowed');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Image');", true);
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

        protected void btnImgPM3_Click(object sender, EventArgs e)
        {
            string IncentiveID = Request.QueryString["IncentiveID"].ToString();
            string SubIncentiveId = Request.QueryString["SubIncentiveId"].ToString();
            try
            {
                if (fuPM3.HasFile)
                {
                    string errormsg = objClsFileUpload.CheckFileSize(fuPM3);
                    if (errormsg != "")
                    {
                        string message = "alert('" + errormsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                    string Mimetype = objClsFileUpload.getmimetype(fuPM3);
                    if (Mimetype == "image/pjpeg" || Mimetype == "image/jpeg")
                    {
                        string OutPut = objClsFileUpload.DLOImageUploading("~\\InspectionImages", Server.MapPath("~\\InspectionImages"), fuPM3, hypPM3, "ImageUploads", IncentiveID, SubIncentiveId, hdnUserId.Value, "DLO", "4");
                        if (OutPut != "0")
                        {
                            success.Visible = false;
                            Failure.Visible = false;
                            hypPM3.Visible = true;
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Image Uploaded Successfully');", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Only Image files allowed');", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Please select Image');", true);
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
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        public void GetUploadedImages(string IncentiveId, string SubIncentiveId)
        {
            DataSet dsnew1 = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.VarChar),
               new SqlParameter("@SubIncentiveId",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = SubIncentiveId;
            dsnew1 = ObjCAFClass.GenericFillDs("[USP_GET_INSPECTION_IMAGES]", pp);

            if (dsnew1 != null && dsnew1.Tables.Count > 0 && dsnew1.Tables[0].Rows.Count > 0)
            {
                try
                {
                    string Image1 = dsnew1.Tables[0].Rows[0]["Image1"].ToString();
                    string Image2 = dsnew1.Tables[0].Rows[0]["Image2"].ToString();
                    string Image3 = dsnew1.Tables[0].Rows[0]["Image3"].ToString();
                    string Image4 = dsnew1.Tables[0].Rows[0]["Image4"].ToString();

                    objClsFileUpload.AssignPath(hypNamePlate, Image1);
                    objClsFileUpload.AssignPath(hypPM1, Image2);
                    objClsFileUpload.AssignPath(hypPM2, Image3);
                    objClsFileUpload.AssignPath(hypPM3, Image4);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void chkind_CheckedChanged(object sender, EventArgs e)
        {
            if (chkind.Checked == true)
            {

            }
            else
            {
                btndraft.Text = "Save the Details";
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
        protected void txtAdmissibleAmount_TextChanged(object sender, EventArgs e)
        {
            rbtnmachinesavailableYes_SelectedIndexChanged(this, EventArgs.Empty);
        }
        protected void BindTearmLoanDtls(string INCENTIVEID)
        {
            try
            {
                GVTermLoandtls.DataSource = null;
                GVTermLoandtls.DataBind();

                GVTermLoandtls2.DataSource = null;
                GVTermLoandtls2.DataBind();

                DataSet dsnew = new DataSet();
                dsnew = GetTermLoanDtlsDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    GVTermLoandtls.DataSource = dsnew.Tables[0];
                    GVTermLoandtls.DataBind();

                    GVTermLoandtls2.DataSource = dsnew.Tables[0];
                    GVTermLoandtls2.DataBind();
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
        public DataSet GetTermLoanDtlsDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_TERMLOAN_DTLS", pp);
            return Dsnew;
        }
        public void BindTermLoanRepaid(int TLRId, int IncentiveId)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = GetTermLoanRepaid(TLRId, IncentiveId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdTermLoanRepaid.DataSource = ds.Tables[0];
                    grdTermLoanRepaid.DataBind();
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
        public DataSet GetTermLoanRepaid(int TLRId, int IncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@TLRId",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = TLRId;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_TERMLOANREPAID", pp);
            return Dsnew;
        }
        protected void BindAdditionalInformationDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetAdditionalInformationDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    gvAdditionalInformation.DataSource = dsnew.Tables[0];
                    gvAdditionalInformation.DataBind();
                }
                else
                {
                    gvAdditionalInformation.DataSource = null;
                    gvAdditionalInformation.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAdditionalInformationDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_IS_ADITIONALINFORMATION_DTLS", pp);
            return Dsnew;
        }
        public void BindMoratoriumPeriodDetails(int MoratoriumPeriod_ID, int IncentiveId)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = GetMoratoriumPeriodDetails(MoratoriumPeriod_ID, IncentiveId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GvMoratoriumPeriod.DataSource = ds.Tables[0];
                    GvMoratoriumPeriod.DataBind();
                    lblMoratoriumYesNo.Text = "Yes";
                    trMoratorium.Visible = true;
                }
                else
                {
                    GvMoratoriumPeriod.DataSource = null;
                    GvMoratoriumPeriod.DataBind();
                    lblMoratoriumYesNo.Text = "No";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindSLCDetails(string IncentiveId, string SubIncentiveId)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = GetSLCData(IncentiveId, SubIncentiveId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdSLCData.DataSource = ds.Tables[0];
                    grdSLCData.DataBind();
                }
                else
                {
                    grdSLCData.DataSource = null;
                    grdSLCData.DataBind();
                    trSanctionedIncentives.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetMoratoriumPeriodDetails(int MoratoriumPeriod_ID, int IncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@MoratoriumPeriod_ID",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = MoratoriumPeriod_ID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_MORATORIUM_PERIOD_DTLS", pp);
            return Dsnew;
        }

        public DataSet GetSLCData(string IncentiveId, string SubIncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@SubIncentiveId",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = SubIncentiveId;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_SLC_DATA_BY_INCENTIVE", pp);
            return Dsnew;
        }
        protected void BindISCrrentClaimPeriodDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetISCrrentClaimPeriodDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    GvInterestSubsidyPeriod.DataSource = dsnew.Tables[0];
                    GvInterestSubsidyPeriod.DataBind();
                }
                else
                {
                    GvInterestSubsidyPeriod.DataSource = null;
                    GvInterestSubsidyPeriod.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetISCrrentClaimPeriodDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_IS_CURRENTCLAIM_PERIOD_DTLS", pp);
            return Dsnew;
        }
        protected void grdTermLoanRepaid_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "InterestAmt").ToString() != "" && DataBinder.Eval(e.Row.DataItem, "InterestAmt").ToString() != null)
                {
                    decimal InterestAmountPaid1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "InterestAmt"));
                    InterestAmountPaid = InterestAmountPaid1 + InterestAmountPaid;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[8].Text = "Total";
                e.Row.Cells[9].Text = InterestAmountPaid.ToString();
            }
        }

        protected void GVTermLoandtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "SanctionedAmount").ToString() != "" && DataBinder.Eval(e.Row.DataItem, "SanctionedAmount").ToString() != null)
                {
                    decimal SanctionedAmount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SanctionedAmount"));
                    SanctionedAmount = SanctionedAmount1 + SanctionedAmount;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[5].Text = "Total";
                e.Row.Cells[6].Text = SanctionedAmount.ToString();
            }
        }

        protected void GVTermLoandtls2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[4].Text = "Total";
            }
        }

        protected void gvAdditionalInformation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "EligibleInterest").ToString() != "" && DataBinder.Eval(e.Row.DataItem, "EligibleInterest").ToString() != null)
                {
                    decimal EligibleInterest1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EligibleInterest"));
                    EligibleInterest = EligibleInterest1 + EligibleInterest;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[10].Text = "Total";
                e.Row.Cells[11].Text = EligibleInterest.ToString();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        protected void BtnExportExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        protected void ExportToExcel()
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=PlantandMachinaryList.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                //divPMprint.Style["width"] = "680px";

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);

                    grdPandM.AllowPaging = false;
                    //this.fillgrid();

                    grdPandM.HeaderRow.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in grdPandM.HeaderRow.Cells)
                    {
                        cell.BackColor = grdPandM.HeaderStyle.BackColor;
                        cell.ForeColor = System.Drawing.Color.Black;
                    }
                    foreach (TableCell cell in grdPandM.FooterRow.Cells)
                    {
                        cell.BackColor = System.Drawing.Color.Black;
                        cell.ForeColor = System.Drawing.Color.Black;
                        // cell.
                    }

                    foreach (GridViewRow row in grdPandM.Rows)
                    {
                        row.BackColor = System.Drawing.Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = grdPandM.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = grdPandM.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }

                    grdPandM.RenderControl(hw);



                    string label1text = "Plant and Machinary - " + hdnApplication.Value.ToString();
                    string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='13'><h4>" + label1text + "</h4></td></td></tr></table>";
                    HttpContext.Current.Response.Write(headerTable);
                    HttpContext.Current.Response.Write(sw.ToString());
                    HttpContext.Current.Response.End();

                    //style to format numbers to string
                    string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }

            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }

        protected void grdSLCData_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void txtDLOEligibleInterest_TextChanged(object sender, EventArgs e)
        {
            decimal FinalRecommendedTotalAmount = 0;
            foreach (GridViewRow gvrow in gvAdditionalInformation.Rows)
            {
                TextBox txtDLOEligibleInterest = ((TextBox)(gvrow.FindControl("txtDLOEligibleInterest")));
                TextBox txtHOEligibleInterest = ((TextBox)(gvrow.FindControl("txtHOEligibleInterest")));
                TextBox txtFinalEligibleInterest = ((TextBox)(gvrow.FindControl("txtFinalEligibleInterest")));
                decimal[] numbers = { Convert.ToDecimal(txtDLOEligibleInterest.Text.ToString()), Convert.ToDecimal(txtHOEligibleInterest.Text.ToString()) };
                decimal SmallAmount = numbers.Min();
                //decimal DLOEligibleInterest = Convert.ToDecimal(txtDLOEligibleInterest.Text.Trim().ToString());
                txtFinalEligibleInterest.Text = SmallAmount.ToString();
                FinalRecommendedTotalAmount = FinalRecommendedTotalAmount + SmallAmount;
            }
            lblDLOSuggestedAmount.Text = FinalRecommendedTotalAmount.ToString();
        }

        protected void txtDLOAmount_TextChanged(object sender, EventArgs e)
        {
            rbtnmachinesavailableYes_SelectedIndexChanged(this, EventArgs.Empty);
        }

        protected void txtDLOPlinthArea_TextChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in GvBuildingDetails.Rows)
            {
                Label lblPlinthArea = ((Label)(gvrow.FindControl("lblPlinthArea")));
                Label lblBUILDINGID = ((Label)(gvrow.FindControl("lblBUILDINGID")));
                TextBox txtDLOPlinthArea = ((TextBox)(gvrow.FindControl("txtDLOPlinthArea")));
                TextBox txtDLOSqmterValue = ((TextBox)(gvrow.FindControl("txtDLOSqmterValue")));
                TextBox txtDLOAmount = ((TextBox)(gvrow.FindControl("txtDLOAmount")));
                if (lblBUILDINGID.Text != "9")
                {
                    if (hdnUserId.Value != "58249")
                    {
                        if (Convert.ToDecimal(txtDLOPlinthArea.Text.Trim().ToString()) > Convert.ToDecimal(lblPlinthArea.Text.Trim().ToString()))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('DLO Recommended Plinth area should not exceed actual Plinth area');", true);
                            txtDLOPlinthArea.Text = lblPlinthArea.Text.Trim().ToString();
                        }
                    }
                }
                if (txtDLOPlinthArea.Text.Trim() == "")
                {
                    txtDLOPlinthArea.Text = "0.00";
                }
                if (txtDLOSqmterValue.Text.Trim() == "")
                {
                    txtDLOSqmterValue.Text = "0.00";
                }
                decimal Amount = 0;
                if (lblBUILDINGID.Text == "9")
                {
                    txtDLOAmount.Enabled = true;
                }
                else
                {
                    Amount = (Convert.ToDecimal(txtDLOPlinthArea.Text.Trim().ToString()) * Convert.ToDecimal(txtDLOSqmterValue.Text.Trim().ToString()));
                    txtDLOAmount.Text = Amount.ToString("0.00");
                }
            }
            rbtnmachinesavailableYes_SelectedIndexChanged(this, EventArgs.Empty);
        }

        protected void gvEquipments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    RadioButtonList ddlAction = (e.Row.FindControl("rbtnEquipmentavailableYes") as RadioButtonList);
                    string Actiontaken = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EqipmentAvailability"));
                    if (Actiontaken != "")
                    {
                        ddlAction.SelectedValue = Actiontaken;
                    }
                }
            }
            catch (Exception ex)
            {
                //lblmsg0.Text = "Internal error has occured. Please try after some time";
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                // LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        protected void rbtnEquipmentavailableYes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplicationStatus ObjApplicationStatus = new ApplicationStatus();

            string IncentiveID = Request.QueryString["IncentiveID"].ToString();
            string SubIncentiveId = Request.QueryString["SubIncentiveId"].ToString();
            string SelectedEquipmentIds = "";
            List<InspectionEquipment> lstEqs = new List<InspectionEquipment>();
            foreach (GridViewRow gvrow in gvEquipments.Rows)
            {
                Label lblEquipment_ID = ((Label)(gvrow.FindControl("lblEquipment_ID")));
                Label lblTotal = ((Label)(gvrow.FindControl("lblTotal")));
                TextBox txtAdmissibleAmountEq = ((TextBox)(gvrow.FindControl("txtAdmissibleAmountEq")));
                RadioButtonList rbtnEquipmentavailableYes = ((RadioButtonList)(gvrow.FindControl("rbtnEquipmentavailableYes")));

                if (rbtnEquipmentavailableYes.SelectedValue == "A")
                {
                    txtAdmissibleAmountEq.Enabled = true;
                    if (txtAdmissibleAmountEq.Text == "")
                    {
                        txtAdmissibleAmountEq.Text = lblTotal.Text;
                    }
                }

                if (rbtnEquipmentavailableYes.SelectedValue == "A")
                {
                    lstEqs.Add(new InspectionEquipment
                    {
                        EquipmentId = lblEquipment_ID.Text,
                        EquipmentCost = txtAdmissibleAmountEq.Text,
                        Category = txtAdmissibleAmountEq.Text
                    });
                }

                if (rbtnEquipmentavailableYes.SelectedValue == "N" || rbtnEquipmentavailableYes.SelectedValue == "A")
                {
                    if (SelectedEquipmentIds == "")
                    {
                        SelectedEquipmentIds = lblEquipment_ID.Text;
                    }
                    else
                    {
                        SelectedEquipmentIds = SelectedEquipmentIds + "," + lblEquipment_ID.Text;
                    }
                }
            }

            XElement xmlEquipmentUpload = new XElement("xmlEquipment_xml",
                       from PMs in lstEqs
                       select new XElement("EqpTable",
                       new XElement("EquipmentId", PMs.EquipmentId),
                       new XElement("EquipmentCost", PMs.EquipmentCost)
                       ));

            ObjApplicationStatus.PMXml = xmlEquipmentUpload.ToString();

            string CalSystemSubsidy = "", CalSystemAdditionalCapitalSubsidy = "", Flag = "N", LandValue = "", BuildingValue = "", PMValue = "", OthersValue = "";
            string Category = ddlCategory.SelectedValue;
            string TypeOfTextile = ddlTypeofTextile.SelectedValue;
            if (ChkChangeReqest.Checked == true) { Flag = "Y"; }
            string SystemRecommendedAmount = ObjCAFClass.GetCapitalSubsidySelected(IncentiveID, SubIncentiveId, "", SelectedEquipmentIds, Category, TypeOfTextile, Flag, ObjApplicationStatus, out CalSystemSubsidy, out CalSystemAdditionalCapitalSubsidy, out LandValue, out BuildingValue, out PMValue, out OthersValue);

            SubsidySystemRecommended.InnerHtml = SystemRecommendedAmount;
            txtAmountSubsidyRecommended.Text = SystemRecommendedAmount;
            lblSystemTotal.InnerHtml = SystemRecommendedAmount;


            if (ChkChangeReqest.Checked == false)
            {
                hdnSystemTotal.Value = SystemRecommendedAmount;
            }
        }

        protected void txt_claimeglibleincentivesloanwiseDateofCommencementofactivity_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");



            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }
        public string getdynamicallyeachrowdata_eligibleincentives(
 HiddenField hf_grdeglibilepallavaddiIncentiveId, HiddenField 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, HiddenField hf_grdeglibilepallavaddiFY_ID,
 Label lbl_grdeglibilepallavaddiFYname, Label lbl_claimeglibleincentivesloanwiseLoanID,
 TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity, TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate,
 TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement, DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment,
 TextBox txt_claimeglibleincentivesloanwisenoofinstallment, TextBox txt_claimeglibleincentivesloanwiseInstallmentamount,
 TextBox txt_claimeglibleincentivesloanwiseRateofInterest, TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement,
 TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted, TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
 HiddenField hfgrd_monthoneid, Label lbl_grd_monthonename, Label lbl_grd_monthnonePrincipalamounntdue, Label lbl_grd_monthoneNoofInstallment,
 TextBox lbl_grd_monthoneRateofinterest, Label lbl_grd_monthoneInterestamount, Label lbl_grd_monthoneUnitHolderContribution,
 Label lbl_grd_monthoneEligibleRateofinterest, Label lbl_grd_monthoneEligibleInterestAmount,
 HiddenField hfgrd_monthtwoid, Label lbl_grd_monthtwoname, Label lbl_grd_monthtwoPrincipalamounntdue, Label lbl_grd_monthtwoNoofInstallment,
 TextBox lbl_grd_monthtwoRateofinterest, Label lbl_grd_monthtwoInterestamount, Label lbl_grd_monthtwoUnitHolderContribution,
 Label lbl_grd_monthtwoEligibleRateofinterest, Label lbl_grd_monthtwoEligibleInterestAmount,
 HiddenField hfgrd_monththreeid, Label lbl_grd_monththreename, Label lbl_grd_monththreePrincipalamounntdue, Label lbl_grd_monththreeNoofInstallment,
 TextBox lbl_grd_monththreeRateofinterest, Label lbl_grd_monththreeInterestamount, Label lbl_grd_monththreeUnitHolderContribution,
 Label lbl_grd_monththreeEligibleRateofinterest, Label lbl_grd_monththreeEligibleInterestAmount,
 HiddenField hfgrd_monthfourid, Label lbl_grd_monthfourname, Label lbl_grd_monthfourPrincipalamounntdue, Label lbl_grd_monthfourNoofInstallment,
 TextBox lbl_grd_monthfourRateofinterest, Label lbl_grd_monthfourInterestamount, Label lbl_grd_monthfourUnitHolderContribution,
 Label lbl_grd_monthfourEligibleRateofinterest, Label lbl_grd_monthfourEligibleInterestAmount,
 HiddenField hfgrd_monthfiveid, Label lbl_grd_monthfivename, Label lbl_grd_monthfivePrincipalamounntdue, Label lbl_grd_monthfiveNoofInstallment,
 TextBox lbl_grd_monthfiveRateofinterest, Label lbl_grd_monthfiveInterestamount, Label lbl_grd_monthfiveUnitHolderContribution,
 Label lbl_grd_monthfiveEligibleRateofinterest, Label lbl_grd_monthfiveEligibleInterestAmount,
 HiddenField hfgrd_monthsixid, Label lbl_grd_monthsixname, Label lbl_grd_monthsixPrincipalamounntdue, Label lbl_grd_monthsixNoofInstallment,
 TextBox lbl_grd_monthsixRateofinterest, Label lbl_grd_monthsixInterestamount, Label lbl_grd_monthsixUnitHolderContribution,
 Label lbl_grd_monthsixEligibleRateofinterest, Label lbl_grd_monthsixEligibleInterestAmount,
 TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths, TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
 TextBox txt_grdeglibilepallavaddiActualinterestamountpaid, TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated,
 RadioButtonList rbtgrdeglibilepallavaddi_isbelated, TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
 TextBox txt_grdeglibilepallavaddiGMrecommendedamount, TextBox txt_grdeglibilepallavaddiEligibleamount,
 TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest, Label lbl_grd_totmonthsInterestamount, Label lbl_grd_totmonthsEligibleInterestAmount,
 HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
  HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
  CheckBox chk_claimeglibleincenloanwisepreviousfymot, CheckBox chk_moratiumapplforthisclaimperiod, CheckBoxList chk_grdclaimegliblerowstodisable)
        {
            int slno = 1;
            string ErrorMsg = "";

            txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Enabled = false;
            txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths.Enabled = false;
            chk_claimeglibleincenloanwisepreviousfymot.Enabled = false;
            chk_moratiumapplforthisclaimperiod.Enabled = false;
            chk_grdclaimegliblerowstodisable.Enabled = false;

            DateTime dcpdate = DateTime.Now; DateTime installmentstartdate = DateTime.Now;
            decimal Totalamount = 0; int periodofinstallment = 0;
            int Totalinstallment = 0; decimal installmentamount = 0; int noofinstallmentcompleted = 0; decimal termprincipaldueamount = 0;
            int noofinstallmentcompletedMonths = 0;
            int Actualcalnoofinstallmentcompleted = 0; decimal Actualcaltermprincipaldueamount = 0; int ActualcalnoofinstallmentcompletedMonths = 0;
            int FYSlnoofIncentiveID = 0;
            int firstsecondhalfyearclaimtype = 0;
            int fyStartyear = 0;
            int fystartmonth = 0;
            int fyendyear = 0;
            int fyendmonth = 0;
            int totalclaimperiod = 6;
            bool previousmotrage = false;
            bool motrageforclaim = false;
            bool noofrowsdisablesel = false;
            int numSelected = 0; int unselectednumber = 0;
            decimal Toteglibleperiodinmonths = 0; decimal totalinterestforallfy = 0; decimal totaleglibleinterestforallfy = 0;

            decimal rateofinterestMonthone = 0, rateofinterestMonthtwo = 0, rateofinterestMonththree = 0, rateofinterestMonthfour = 0,
                rateofinterestMonthfive = 0, rateofinterestMonthsix = 0;

            //int InstallmentNoMonthone = 0,InstallmentNoMonthtwo = 0,InstallmentNoMonththree = 0,InstallmentNoMonthfour = 0,InstallmentNoMonthfive = 0,InstallmentNoMonthsix = 0;

            int dcpyearsofdate = 5;
            //if (Convert.ToString(lbl_schemetide.Text) == "TPRIDE" || Convert.ToString(lbl_schemetide.Text) == "T-PRIDE" ||
            //    Convert.ToString(lbl_schemetide.Text).ToLower() == "tpride" || Convert.ToString(lbl_schemetide.Text).ToLower() == "t-pride")
            //{
            //    dcpyearsofdate = 6;
            //}

            //DateTime fiveyearsdate = dcpdate.AddYears(dcpyearsofdate);


            if (!string.IsNullOrEmpty(hf_grdeglibilepallavaddiFY_ID.Value) || hf_grdeglibilepallavaddiFY_ID.Value != "")
            {
                string claimperiodddlvalue = hf_grdeglibilepallavaddiFY_ID.Value;
                string[] argclaimperiod = new string[5];
                argclaimperiod = claimperiodddlvalue.Split('/'); //32012/1/2016-2017
                FYSlnoofIncentiveID = Convert.ToInt32(argclaimperiod[0]);
                firstsecondhalfyearclaimtype = Convert.ToInt16(argclaimperiod[1]);
                string yeardata = Convert.ToString(argclaimperiod[2]);
                string[] argyearclaimperiod = new string[5];
                argyearclaimperiod = yeardata.Split('-');
                fyStartyear = Convert.ToInt32(argyearclaimperiod[0]);
                fyendyear = Convert.ToInt32(argyearclaimperiod[1]);
                if (firstsecondhalfyearclaimtype > 0)
                {
                    if (firstsecondhalfyearclaimtype == 1)
                    {
                        fystartmonth = 4;
                        fyendmonth = 9;
                        totalclaimperiod = 6;
                    }
                    if (firstsecondhalfyearclaimtype == 2)
                    {
                        fystartmonth = 10;
                        fyendmonth = 3;
                        totalclaimperiod = 6;
                    }
                    if (firstsecondhalfyearclaimtype == 3)
                    {
                        fystartmonth = 4;
                        fyendmonth = 3;
                        totalclaimperiod = 12;
                    }
                }
            }

            if (txt_claimeglibleincentivesloanwiseDateofCommencementofactivity.Text.TrimStart().TrimEnd().Trim() != "")
            {

                dcpdate = Convert.ToDateTime(txt_claimeglibleincentivesloanwiseDateofCommencementofactivity.Text);
            }
            if (txt_claimeglibleincentivesloanwiseinstallmentstartdate.Text.TrimStart().TrimEnd().Trim() != "")
            {

                installmentstartdate = Convert.ToDateTime(txt_claimeglibleincentivesloanwiseinstallmentstartdate.Text);
            }

            if (txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement.Text != "")
            {
                Totalamount = Convert.ToDecimal(txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement.Text);
            }

            if (ddl_claimeglibleincentivesloanwiseperiodofinstallment.SelectedIndex > 0)
            {
                periodofinstallment = Convert.ToInt32(ddl_claimeglibleincentivesloanwiseperiodofinstallment.SelectedValue);
            }

            if (txt_claimeglibleincentivesloanwisenoofinstallment.Text.TrimStart().TrimEnd().Trim() != "")
            {
                Totalinstallment = Convert.ToInt32(txt_claimeglibleincentivesloanwisenoofinstallment.Text);
            }
            if (Totalinstallment > 0 && Totalamount > 0)
            {
                installmentamount = Totalamount / Totalinstallment;
                txt_claimeglibleincentivesloanwiseInstallmentamount.Text = Convert.ToString(Math.Round(installmentamount, 2));
            }
            else
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Total installment above '0'/Total Term Loan Availed above zero \\n";
                slno = slno + 1;
            }

            if (lbl_grd_monthoneRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
            {
                rateofinterestMonthone = Convert.ToDecimal(lbl_grd_monthoneRateofinterest.Text);
            }
            if (lbl_grd_monthtwoRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
            {
                rateofinterestMonthtwo = Convert.ToDecimal(lbl_grd_monthtwoRateofinterest.Text);
            }
            if (lbl_grd_monththreeRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
            {
                rateofinterestMonththree = Convert.ToDecimal(lbl_grd_monththreeRateofinterest.Text);
            }
            if (lbl_grd_monthfourRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
            {
                rateofinterestMonthfour = Convert.ToDecimal(lbl_grd_monthfourRateofinterest.Text);
            }
            if (lbl_grd_monthfiveRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
            {
                rateofinterestMonthfive = Convert.ToDecimal(lbl_grd_monthfiveRateofinterest.Text);
            }
            if (lbl_grd_monthsixRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
            {
                rateofinterestMonthsix = Convert.ToDecimal(lbl_grd_monthsixRateofinterest.Text);
            }

            if (dcpdate.Date != DateTime.Now.Date)
            {
                if (installmentstartdate.Date != DateTime.Now.Date)
                {
                    if (dcpdate.Date < DateTime.Now.Date && installmentstartdate.Date < DateTime.Now.Date)
                    {
                        DateTime fiveyearsdate = dcpdate.AddYears(dcpyearsofdate);
                        DateTime Claimperiodstartdate = new DateTime(Convert.ToInt32(fyStartyear), fystartmonth, 01);
                        DateTime fyendstss = new DateTime(fyendyear, fyendmonth, 1);
                        DateTime Claimperiodenddate = fyendstss.AddMonths(1).AddDays(-1);
                        if (Totalamount > 0 && dcpdate != null && periodofinstallment > 0 &&
                         Totalinstallment > 0 && installmentamount > 0 && fyStartyear > 0 && fystartmonth > 0
                               && fyendyear > 0 && fyendmonth > 0 && installmentstartdate != null)
                        {

                            #region No of  Installment completed,Months

                            int totalmonthcal = 0;
                            int totaltwoyearscal = 0;
                            int totalmonthbwtwoyears = 0;
                            if (fyStartyear == installmentstartdate.Year)
                            {
                                totaltwoyearscal = 0;
                                if (fystartmonth > installmentstartdate.Month)
                                {
                                    //dcp date start before financial year
                                    totalmonthcal = (fystartmonth - installmentstartdate.Month);
                                }
                                else
                                {
                                    totalmonthcal = 0;
                                }
                                totalmonthbwtwoyears = totaltwoyearscal + totalmonthcal;
                            }
                            else if (installmentstartdate.Year < fyStartyear)
                            {
                                totaltwoyearscal = ((fyStartyear - installmentstartdate.Year) * 12);
                                totalmonthcal = (fystartmonth - installmentstartdate.Month);

                                totalmonthbwtwoyears = totaltwoyearscal + totalmonthcal;
                            }
                            else if (installmentstartdate.Year > fyStartyear)
                            {
                                totaltwoyearscal = 0;
                                totalmonthcal = 0;
                                totalmonthbwtwoyears = totaltwoyearscal + totalmonthcal;
                            }

                            int quotientcompleted = 0;
                            if (periodofinstallment == 1)
                            {
                                //Yearly
                                quotientcompleted = totalmonthbwtwoyears / 12;
                                ActualcalnoofinstallmentcompletedMonths = totalmonthbwtwoyears % 12;
                                //noofinstallmentcompletedMonths = totalmonthbwtwoyears % 12;
                            }
                            else if (periodofinstallment == 2)
                            {
                                //halfyear
                                quotientcompleted = totalmonthbwtwoyears / 6;
                                ActualcalnoofinstallmentcompletedMonths = totalmonthbwtwoyears % 6;
                                //noofinstallmentcompletedMonths = totalmonthbwtwoyears % 6;
                            }
                            else if (periodofinstallment == 3)
                            {
                                //quaertly
                                quotientcompleted = totalmonthbwtwoyears / 3;
                                ActualcalnoofinstallmentcompletedMonths = totalmonthbwtwoyears % 3;
                                //noofinstallmentcompletedMonths = totalmonthbwtwoyears % 3;
                            }
                            else if (periodofinstallment == 4)
                            {
                                //Monthly
                                quotientcompleted = totalmonthbwtwoyears;
                                ActualcalnoofinstallmentcompletedMonths = 0;
                                //noofinstallmentcompletedMonths = 0;
                            }
                            // noofinstallmentcompleted = quotientcompleted;
                            //noofinstallmentcompletedMonths = ActualcalnoofinstallmentcompletedMonths;
                            Actualcalnoofinstallmentcompleted = quotientcompleted;

                            #endregion
                            #region moratorium condition
                            if (Claimperiodenddate.Date < installmentstartdate.Date)
                            {
                                //Installment start date did't in this finanical year
                                //ErrorMsg = ErrorMsg + slno + ". Installment start date did't in this finanical year Motage will not apply   \\n";
                                //slno = slno + 1;
                                noofinstallmentcompleted = Actualcalnoofinstallmentcompleted;
                                noofinstallmentcompletedMonths = ActualcalnoofinstallmentcompletedMonths;
                                chk_claimeglibleincenloanwisepreviousfymot.Checked = false;
                                chk_moratiumapplforthisclaimperiod.Checked = false;
                            }
                            else
                            {
                                if (Claimperiodstartdate.Date < installmentstartdate.Date)
                                {
                                    //claim period started but,installment didn't started
                                    //ErrorMsg = ErrorMsg + slno + ". Claim Period started,but Installment didn't started Motage will not apply   \\n";
                                    //slno = slno + 1;
                                    noofinstallmentcompleted = Actualcalnoofinstallmentcompleted;
                                    noofinstallmentcompletedMonths = ActualcalnoofinstallmentcompletedMonths;
                                    chk_claimeglibleincenloanwisepreviousfymot.Checked = false;
                                    chk_moratiumapplforthisclaimperiod.Checked = false;
                                }
                                else
                                {
                                    if (Actualcalnoofinstallmentcompleted > 0)
                                    {
                                        chk_claimeglibleincenloanwisepreviousfymot.Enabled = true;
                                    }
                                    if (ActualcalnoofinstallmentcompletedMonths > 0)
                                    {
                                        chk_claimeglibleincenloanwisepreviousfymot.Enabled = true;
                                    }

                                    chk_moratiumapplforthisclaimperiod.Enabled = true;
                                    if (chk_claimeglibleincenloanwisepreviousfymot.Checked == true)
                                    {
                                        //Previous motrage
                                        previousmotrage = true;
                                        txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Enabled = true;
                                        if (periodofinstallment != 4)
                                        {
                                            txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths.Enabled = true;
                                        }
                                    }
                                    if (chk_moratiumapplforthisclaimperiod.Checked == true)
                                    {
                                        //Current motrage
                                        motrageforclaim = true;
                                        chk_grdclaimegliblerowstodisable.Enabled = true;
                                    }
                                    else
                                    {
                                        foreach (ListItem li in chk_grdclaimegliblerowstodisable.Items)
                                        {
                                            li.Selected = false;
                                        }
                                    }

                                    if (chk_grdclaimegliblerowstodisable.Enabled == true)
                                    {

                                        for (int m = 0; m < chk_grdclaimegliblerowstodisable.Items.Count; m++)
                                        {
                                            if (chk_grdclaimegliblerowstodisable.Items[m].Selected == true)// getting selected value from CheckBox List  
                                            {
                                                numSelected = numSelected + 1;
                                                if (m == 0)
                                                {
                                                    lbl_grd_monthoneRateofinterest.Enabled = false;
                                                    lbl_grd_monthoneRateofinterest.Text = "0";
                                                    rateofinterestMonthone = 0;
                                                }
                                                if (m == 1)
                                                {
                                                    lbl_grd_monthtwoRateofinterest.Enabled = false;
                                                    lbl_grd_monthtwoRateofinterest.Text = "0";
                                                    rateofinterestMonthtwo = 0;
                                                }
                                                if (m == 2)
                                                {
                                                    lbl_grd_monththreeRateofinterest.Enabled = false;
                                                    lbl_grd_monththreeRateofinterest.Text = "0";
                                                    rateofinterestMonththree = 0;
                                                }
                                                if (m == 3)
                                                {
                                                    lbl_grd_monthfourRateofinterest.Enabled = false;
                                                    lbl_grd_monthfourRateofinterest.Text = "0";
                                                    rateofinterestMonthfour = 0;
                                                }
                                                if (m == 4)
                                                {
                                                    lbl_grd_monthfiveRateofinterest.Enabled = false;
                                                    lbl_grd_monthfiveRateofinterest.Text = "0";
                                                    rateofinterestMonthfive = 0;
                                                }
                                                if (m == 5)
                                                {
                                                    lbl_grd_monthsixRateofinterest.Enabled = false;
                                                    lbl_grd_monthsixRateofinterest.Text = "0";
                                                    rateofinterestMonthsix = 0;
                                                }

                                            }
                                            else
                                            {
                                                if (m == 0)
                                                {
                                                    lbl_grd_monthoneRateofinterest.Enabled = true;
                                                    rateofinterestMonthone = Convert.ToDecimal(lbl_grd_monthoneRateofinterest.Text);
                                                }
                                                if (m == 1)
                                                {
                                                    lbl_grd_monthtwoRateofinterest.Enabled = true;
                                                    rateofinterestMonthtwo = Convert.ToDecimal(lbl_grd_monthtwoRateofinterest.Text);
                                                }
                                                if (m == 2)
                                                {
                                                    lbl_grd_monththreeRateofinterest.Enabled = true;
                                                    rateofinterestMonththree = Convert.ToDecimal(lbl_grd_monththreeRateofinterest.Text);
                                                }
                                                if (m == 3)
                                                {
                                                    lbl_grd_monthfourRateofinterest.Enabled = true;
                                                    rateofinterestMonthfour = Convert.ToDecimal(lbl_grd_monthfourRateofinterest.Text);
                                                }
                                                if (m == 4)
                                                {
                                                    lbl_grd_monthfiveRateofinterest.Enabled = true;
                                                    rateofinterestMonthfive = Convert.ToDecimal(lbl_grd_monthfiveRateofinterest.Text);
                                                }
                                                if (m == 5)
                                                {
                                                    lbl_grd_monthsixRateofinterest.Enabled = true;
                                                    rateofinterestMonthsix = Convert.ToDecimal(lbl_grd_monthsixRateofinterest.Text);
                                                }
                                            }

                                        }

                                        if (numSelected <= 0)
                                        {
                                            //Error
                                            ErrorMsg = ErrorMsg + slno + ". Please select the row month which are not eglible for the interest Amount \\n";
                                            slno = slno + 1;
                                        }
                                        else
                                        {
                                            noofrowsdisablesel = true;
                                        }
                                    }
                                    else
                                    {
                                        lbl_grd_monthoneRateofinterest.Enabled = true;
                                        lbl_grd_monthtwoRateofinterest.Enabled = true;
                                        lbl_grd_monththreeRateofinterest.Enabled = true;
                                        lbl_grd_monthfourRateofinterest.Enabled = true;
                                        lbl_grd_monthfiveRateofinterest.Enabled = true;
                                        lbl_grd_monthsixRateofinterest.Enabled = true;
                                    }

                                    if (chk_claimeglibleincenloanwisepreviousfymot.Checked == true)
                                    {
                                        //installment completed
                                        if (txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Text.TrimStart().TrimEnd().Trim() != "")
                                        {
                                            if (Convert.ToInt32(txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Text) > 0)
                                            {
                                                //Motrage installmennt completed should be less than actual installment completed
                                                if (Convert.ToInt32(txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Text) <= Actualcalnoofinstallmentcompleted)
                                                {
                                                    noofinstallmentcompleted = Convert.ToInt32(txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Text);
                                                }
                                                else
                                                {
                                                    noofinstallmentcompleted = Actualcalnoofinstallmentcompleted;
                                                }

                                            }
                                            else
                                            {
                                                noofinstallmentcompleted = Actualcalnoofinstallmentcompleted;
                                            }

                                        }
                                        else
                                        {
                                            noofinstallmentcompleted = Actualcalnoofinstallmentcompleted;
                                        }

                                        //installment completed months
                                        if (txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths.Text.TrimStart().TrimEnd().Trim() != "")
                                        {
                                            if (Convert.ToInt32(txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths.Text) > 0)
                                            {
                                                if (periodofinstallment == 4)
                                                {
                                                    //monthly
                                                    noofinstallmentcompletedMonths = 0;
                                                }
                                                else
                                                {
                                                    noofinstallmentcompletedMonths = Convert.ToInt32(txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths.Text);
                                                }
                                            }
                                            else
                                            {
                                                noofinstallmentcompletedMonths = ActualcalnoofinstallmentcompletedMonths;
                                            }
                                        }
                                        else
                                        {
                                            noofinstallmentcompletedMonths = ActualcalnoofinstallmentcompletedMonths;
                                        }
                                    }
                                    else
                                    {
                                        noofinstallmentcompleted = Actualcalnoofinstallmentcompleted;
                                        noofinstallmentcompletedMonths = ActualcalnoofinstallmentcompletedMonths;
                                    }

                                    if (periodofinstallment == 1)
                                    {
                                        //Yearly
                                        if (noofinstallmentcompletedMonths >= 12)
                                        {
                                            ErrorMsg = ErrorMsg + slno + ". Please Enter Installment Completed Months b/W 0 to 11 \\n";
                                            slno = slno + 1;
                                        }
                                    }
                                    else if (periodofinstallment == 2)
                                    {
                                        //halfyear
                                        if (noofinstallmentcompletedMonths >= 6)
                                        {
                                            ErrorMsg = ErrorMsg + slno + ". Please Enter Installment Completed Months b/W 0 to 6 \\n";
                                            slno = slno + 1;
                                        }
                                    }
                                    else if (periodofinstallment == 3)
                                    {
                                        //quaertly
                                        if (noofinstallmentcompletedMonths >= 3)
                                        {
                                            ErrorMsg = ErrorMsg + slno + ". Please Enter Installment Completed Months b/W 0 to 3\\n";
                                            slno = slno + 1;
                                        }
                                    }
                                    else
                                    {
                                        if (noofinstallmentcompletedMonths > 0)
                                        {
                                            ErrorMsg = ErrorMsg + slno + ". Please Enter Installment Completed Months Zero(0)\\n";
                                            slno = slno + 1;
                                        }
                                    }

                                }
                            }

                            #endregion


                            #region principalamountdue amount for this half year

                            int pramounttotalmonthcal = 0;
                            int pramounttotaltwoyearscal = 0;
                            int pramounttotalmonthbwtwoyears = 0;
                            if (fyStartyear == dcpdate.Year)
                            {
                                if (dcpdate.Month < fystartmonth)
                                {
                                    //dcp date started before financial year
                                    pramounttotalmonthcal = (fystartmonth - dcpdate.Month);
                                }
                                else
                                {
                                    //dcp date started after financial year/in same month
                                    pramounttotalmonthcal = 0;
                                }
                                pramounttotalmonthbwtwoyears = pramounttotaltwoyearscal + pramounttotalmonthcal;
                            }
                            else
                            {
                                if (dcpdate.Year < fyStartyear)
                                {
                                    //dcp date started before finanical year
                                    pramounttotaltwoyearscal = ((fyStartyear - dcpdate.Year) * 12);
                                    pramounttotalmonthcal = (fystartmonth - dcpdate.Month);
                                    pramounttotalmonthbwtwoyears = pramounttotaltwoyearscal + pramounttotalmonthcal;
                                }
                                else
                                {
                                    if (dcpdate.Year > fyStartyear)
                                    {
                                        ////dcp date started after finanical year
                                        pramounttotaltwoyearscal = 0;
                                        pramounttotalmonthcal = 0;
                                        pramounttotalmonthbwtwoyears = pramounttotaltwoyearscal + pramounttotalmonthcal;

                                    }
                                }

                            }
                            int pramountquotientcompleted = 0;
                            int pramountremaindercompleted = 0;
                            if (periodofinstallment == 1)
                            {
                                //Yearly
                                pramountquotientcompleted = totalmonthbwtwoyears / 12;
                                pramountremaindercompleted = totalmonthbwtwoyears % 12;

                            }
                            else if (periodofinstallment == 2)
                            {
                                //halfyear
                                pramountquotientcompleted = totalmonthbwtwoyears / 6;
                                pramountremaindercompleted = totalmonthbwtwoyears % 6;
                            }
                            else if (periodofinstallment == 3)
                            {
                                //quaertly
                                pramountquotientcompleted = totalmonthbwtwoyears / 3;
                                pramountremaindercompleted = totalmonthbwtwoyears % 3;
                            }
                            else if (periodofinstallment == 4)
                            {
                                //Monthly
                                pramountquotientcompleted = totalmonthbwtwoyears;
                            }
                            if (pramountquotientcompleted == 0)
                            {
                                Actualcaltermprincipaldueamount = Totalamount;
                            }
                            else
                            {
                                if (pramountremaindercompleted == 0)
                                {
                                    Actualcaltermprincipaldueamount = (Totalamount - (installmentamount * pramountquotientcompleted));
                                }
                                else
                                {
                                    Actualcaltermprincipaldueamount = (Totalamount - (installmentamount * pramountquotientcompleted));
                                }
                            }


                            if (previousmotrage == true)
                            {
                                if (noofinstallmentcompleted > 0)
                                {
                                    //termprincipaldueamount = (Totalamount - (installmentamount * pramountquotientcompleted));//Commented by 05/07/2022 by Madhuri
                                    termprincipaldueamount = (Totalamount - (installmentamount * noofinstallmentcompleted));
                                }
                                else
                                {
                                    termprincipaldueamount = Actualcaltermprincipaldueamount;
                                }
                            }
                            else if (motrageforclaim == true)
                            {
                                if (noofinstallmentcompleted > 0)
                                {
                                    termprincipaldueamount = (Totalamount - (installmentamount * pramountquotientcompleted));

                                }
                                else
                                {
                                    termprincipaldueamount = Actualcaltermprincipaldueamount;
                                }
                            }
                            else
                            {
                                termprincipaldueamount = Actualcaltermprincipaldueamount;
                            }


                            #endregion


                            bool finalmortagecheckallcorrect = true;//if moratorium applied and didn't  selected row then false and if moratorium for this claim didnn't selected by default true;
                            if (motrageforclaim == true)
                            {
                                if (noofrowsdisablesel == true)
                                {
                                    if (numSelected <= 0)
                                    {
                                        finalmortagecheckallcorrect = false;
                                    }
                                }
                            }


                            if (finalmortagecheckallcorrect == true)
                            {


                                #region Gridview display
                                //check total installment with completed installments
                                if (noofinstallmentcompleted <= Totalinstallment)
                                {

                                    //check completed installments Moth Acc period of installment
                                    bool allmonthscorrect = true;
                                    if (periodofinstallment == 1)
                                    {
                                        //Yearly
                                        if (noofinstallmentcompletedMonths >= 12)
                                        {
                                            allmonthscorrect = false;
                                        }
                                    }
                                    else if (periodofinstallment == 2)
                                    {
                                        //halfyear
                                        if (noofinstallmentcompletedMonths >= 6)
                                        {
                                            allmonthscorrect = false;
                                        }
                                    }
                                    else if (periodofinstallment == 3)
                                    {
                                        //quaertly
                                        if (noofinstallmentcompletedMonths >= 3)
                                        {
                                            allmonthscorrect = false;
                                        }
                                    }
                                    else if (periodofinstallment == 4)
                                    {
                                        //Monthly
                                        if (noofinstallmentcompletedMonths > 0)
                                        {
                                            allmonthscorrect = false;
                                        }
                                    }

                                    if (allmonthscorrect == true)
                                    {
                                        if (termprincipaldueamount > 0)
                                        {
                                            DataTable dt_grid = new DataTable();
                                            dt_grid.Columns.Add("RateofInterest", typeof(string));
                                            dt_grid.Columns.Add("MonthYear", typeof(string));
                                            dt_grid.Columns.Add("MonthName_Year", typeof(string));
                                            dt_grid.Columns.Add("Principalamountdue", typeof(decimal));
                                            dt_grid.Columns.Add("noofinstallment", typeof(int));
                                            dt_grid.Columns.Add("InterestAmount", typeof(decimal));
                                            dt_grid.Columns.Add("UnitHolderContribution", typeof(decimal));
                                            dt_grid.Columns.Add("EligibleRateofInterest", typeof(decimal));
                                            dt_grid.Columns.Add("EligibleInterestAmount", typeof(decimal));

                                            // decimal forPresenthalfyeardueamount = 0;
                                            DateTime dateofmonthstart = new DateTime(Convert.ToInt32(fyStartyear), fystartmonth, 01);
                                            var dat = dateofmonthstart.AddMonths(1).AddDays(-1);


                                            #region forloop

                                            for (int k = 0; k < totalclaimperiod; k++)
                                            {

                                                //condition 1- from Dcp date to claim period start date up to 5 years only claim inserest amount is given  
                                                DataRow drs = dt_grid.NewRow();
                                                dat.AddMonths(k).ToString("d");
                                                string MonthYear = dat.AddMonths(k).Month + "/" + dat.AddMonths(k).Year;
                                                string MonthName = dat.AddMonths(k).ToString("MMMM") + "-" + dat.AddMonths(k).Year;
                                                //string MonthYear = 0+k + "/" + d1.Year;
                                                //string MonthName = 0 + k + "-" + d1.Year;
                                                int gridmonth = dat.AddMonths(k).Month;
                                                int gridyear = dat.AddMonths(k).Year;

                                                decimal Principalamountdue = 0; int noofinstallment = 0; decimal interestamount = 0;
                                                decimal UnitHolderContribution = 0; decimal EligibleRateofInterestofgrd = 0; decimal EligibleInterestAmount = 0;
                                                decimal rateofinterestofdt = 0;

                                                if (k == 0)
                                                {
                                                    rateofinterestofdt = rateofinterestMonthone;
                                                }
                                                if (k == 1)
                                                {
                                                    rateofinterestofdt = rateofinterestMonthtwo;
                                                }
                                                if (k == 2)
                                                {
                                                    rateofinterestofdt = rateofinterestMonththree;
                                                }
                                                if (k == 3)
                                                {
                                                    rateofinterestofdt = rateofinterestMonthfour;
                                                }
                                                if (k == 4)
                                                {
                                                    rateofinterestofdt = rateofinterestMonthfive;
                                                }
                                                if (k == 5)
                                                {
                                                    rateofinterestofdt = rateofinterestMonthsix;
                                                }


                                                if (gridyear >= installmentstartdate.Year)
                                                {

                                                    if (motrageforclaim == true)
                                                    {
                                                        if (chk_grdclaimegliblerowstodisable.Items[k].Selected == false)// getting selected value from CheckBox List  
                                                        {
                                                            unselectednumber = unselectednumber + 1;
                                                            if (periodofinstallment == 1)
                                                            {
                                                                //Yearly
                                                                int monthofmot = ((noofinstallmentcompleted * 12) + (noofinstallmentcompletedMonths + unselectednumber));
                                                                if ((monthofmot % 12) == 0)
                                                                {
                                                                    noofinstallment = (monthofmot / 12);
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                }
                                                                else if ((monthofmot % 12) == 1)
                                                                {
                                                                    noofinstallment = (monthofmot / 12) + 1;
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                }
                                                                else
                                                                {
                                                                    noofinstallment = (monthofmot / 12) + 1;
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                }
                                                            }
                                                            else if (periodofinstallment == 2)
                                                            {
                                                                //halfyear
                                                                int monthofmot = ((noofinstallmentcompleted * 6) + (noofinstallmentcompletedMonths + unselectednumber));
                                                                if ((monthofmot % 6) == 0)
                                                                {
                                                                    noofinstallment = (monthofmot / 6);
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                }
                                                                else if ((monthofmot % 6) == 1)
                                                                {
                                                                    noofinstallment = (monthofmot / 6) + 1;
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                }
                                                                else
                                                                {
                                                                    noofinstallment = (monthofmot / 6) + 1;
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                }
                                                            }
                                                            else if (periodofinstallment == 3)
                                                            {
                                                                //quaertly

                                                                int monthofmot = ((noofinstallmentcompleted * 3) + (noofinstallmentcompletedMonths + unselectednumber));
                                                                if ((monthofmot % 3) == 0)
                                                                {
                                                                    noofinstallment = (monthofmot / 3);
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                }
                                                                else if ((monthofmot % 3) == 1)
                                                                {
                                                                    noofinstallment = (monthofmot / 3) + 1;
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                }
                                                                else
                                                                {
                                                                    noofinstallment = (monthofmot / 3) + 1;
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                }
                                                            }
                                                            else if (periodofinstallment == 4)
                                                            {
                                                                noofinstallment = noofinstallmentcompleted + unselectednumber;
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                            }
                                                        }
                                                        else
                                                        {
                                                            noofinstallment = 0;
                                                            Principalamountdue = 0;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (previousmotrage == true)
                                                        {
                                                            if (periodofinstallment == 1)
                                                            {
                                                                //Yearly
                                                                int monthofmot = ((noofinstallmentcompleted * 12) + (noofinstallmentcompletedMonths + k + 1));

                                                                if ((monthofmot % 12) == 1)
                                                                {
                                                                    noofinstallment = (monthofmot / 12);
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                }
                                                                else
                                                                {
                                                                    noofinstallment = (monthofmot / 12) + 1;
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                }
                                                            }
                                                            else if (periodofinstallment == 2)
                                                            {
                                                                //halfyear
                                                                int monthofmot = ((noofinstallmentcompleted * 6) + (noofinstallmentcompletedMonths + k + 1));
                                                                if ((monthofmot % 6) == 1)
                                                                {
                                                                    noofinstallment = (monthofmot / 6);
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                }
                                                                else
                                                                {
                                                                    noofinstallment = (monthofmot / 6) + 1;
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                }
                                                            }
                                                            else if (periodofinstallment == 3)
                                                            {
                                                                //quaertly

                                                                int monthofmot = ((noofinstallmentcompleted * 3) + (noofinstallmentcompletedMonths + k + 1));
                                                                if ((monthofmot % 3) == 1)
                                                                {
                                                                    noofinstallment = (monthofmot / 3);
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                }
                                                                else
                                                                {
                                                                    noofinstallment = (monthofmot / 3) + 1;
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                }
                                                            }
                                                            else if (periodofinstallment == 4)
                                                            {
                                                                noofinstallment = noofinstallmentcompleted + k + 1;
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                            }

                                                        }
                                                        else
                                                        {


                                                            //installment start date  before/in this claim period
                                                            int gridtotaltwoyearscal = 0;
                                                            int gridtotalmonthcal = 0;
                                                            int gridtotalmonthbwyears = 0;
                                                            // int gridtotalmonthbwyears = ((gridyear - installmentstartdate.Year) * 12) + (gridmonth - installmentstartdate.Month);
                                                            if (gridyear == installmentstartdate.Year)
                                                            {
                                                                gridtotaltwoyearscal = 0;
                                                                if (gridmonth > installmentstartdate.Month)
                                                                {
                                                                    //installmentstartdate start before financial year
                                                                    gridtotalmonthcal = (gridmonth - installmentstartdate.Month);
                                                                }
                                                                else
                                                                {
                                                                    gridtotalmonthcal = 0;
                                                                    //installmentstartdate didn't start for that finanical year
                                                                    //gridtotalmonthcal = 0;
                                                                }
                                                                gridtotalmonthbwyears = gridtotaltwoyearscal + gridtotalmonthcal;
                                                            }
                                                            else if (installmentstartdate.Year < gridyear)
                                                            {
                                                                gridtotaltwoyearscal = ((gridyear - installmentstartdate.Year) * 12);
                                                                gridtotalmonthcal = (gridmonth - installmentstartdate.Month);
                                                                gridtotalmonthbwyears = gridtotaltwoyearscal + gridtotalmonthcal;
                                                            }
                                                            else if (installmentstartdate.Year > gridyear)
                                                            {
                                                                //in that year installmentstartdate didn't started
                                                                gridtotaltwoyearscal = 0;
                                                                gridtotalmonthcal = 0;
                                                                gridtotalmonthbwyears = gridtotaltwoyearscal + gridtotalmonthcal;
                                                            }


                                                            //int gridtotalmonthbwyears = ((gridyear - dcpdate.Year) * 12) + (gridmonth - dcpdate.Month);
                                                            int gridquotientCompleted = 0;
                                                            int gridremainder = 0;
                                                            if (Convert.ToInt16(periodofinstallment) == 1)
                                                            {
                                                                //Yearly

                                                                gridquotientCompleted = gridtotalmonthbwyears / 12;
                                                                gridremainder = gridtotalmonthbwyears % 12;
                                                                if (gridquotientCompleted + 1 <= Totalinstallment)
                                                                {
                                                                    if (gridquotientCompleted <= 0)
                                                                    {
                                                                        if (gridremainder <= 0)
                                                                        {
                                                                            if (gridyear == installmentstartdate.Year)
                                                                            {
                                                                                if (gridmonth == installmentstartdate.Month)
                                                                                {
                                                                                    noofinstallment = gridquotientCompleted + 1;
                                                                                    Principalamountdue = Totalamount;
                                                                                }
                                                                                else
                                                                                {
                                                                                    noofinstallment = gridquotientCompleted;
                                                                                    Principalamountdue = 0;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                noofinstallment = gridquotientCompleted;
                                                                                Principalamountdue = 0;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            noofinstallment = gridquotientCompleted + 1;
                                                                            Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        noofinstallment = gridquotientCompleted + 1;
                                                                        if (gridremainder == 0)
                                                                        {
                                                                            Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                        }
                                                                        else
                                                                        {
                                                                            Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                        }
                                                                    }

                                                                }
                                                            }
                                                            else if (Convert.ToInt16(periodofinstallment) == 2)
                                                            {
                                                                //Half yearly
                                                                gridquotientCompleted = gridtotalmonthbwyears / 6;
                                                                gridremainder = gridtotalmonthbwyears % 6;

                                                                if (gridquotientCompleted + 1 <= Totalinstallment)
                                                                {
                                                                    if (gridquotientCompleted <= 0)
                                                                    {
                                                                        if (gridremainder <= 0)
                                                                        {
                                                                            if (gridyear == installmentstartdate.Year)
                                                                            {
                                                                                if (gridmonth == installmentstartdate.Month)
                                                                                {
                                                                                    noofinstallment = gridquotientCompleted + 1;
                                                                                    Principalamountdue = Totalamount;
                                                                                }
                                                                                else
                                                                                {
                                                                                    noofinstallment = gridquotientCompleted;
                                                                                    Principalamountdue = 0;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                noofinstallment = gridquotientCompleted;
                                                                                Principalamountdue = 0;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            noofinstallment = gridquotientCompleted + 1;
                                                                            Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        noofinstallment = gridquotientCompleted + 1;
                                                                        if (gridremainder == 0)
                                                                        {
                                                                            Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                        }
                                                                        else
                                                                        {
                                                                            Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                        }
                                                                    }

                                                                }
                                                            }
                                                            else if (Convert.ToInt16(periodofinstallment) == 3)
                                                            {
                                                                // Quarelty
                                                                gridquotientCompleted = gridtotalmonthbwyears / 3;
                                                                gridremainder = gridtotalmonthbwyears % 3;
                                                                if (gridquotientCompleted + 1 <= Totalinstallment)
                                                                {
                                                                    if (gridquotientCompleted <= 0)
                                                                    {
                                                                        if (gridremainder <= 0)
                                                                        {
                                                                            if (gridyear == installmentstartdate.Year)
                                                                            {
                                                                                if (gridmonth == installmentstartdate.Month)
                                                                                {
                                                                                    noofinstallment = gridquotientCompleted + 1;
                                                                                    Principalamountdue = Totalamount;
                                                                                }
                                                                                else
                                                                                {
                                                                                    noofinstallment = gridquotientCompleted;
                                                                                    Principalamountdue = 0;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                noofinstallment = gridquotientCompleted;
                                                                                Principalamountdue = 0;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            noofinstallment = gridquotientCompleted + 1;
                                                                            Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        noofinstallment = gridquotientCompleted + 1;
                                                                        if (gridremainder == 0)
                                                                        {
                                                                            Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                        }
                                                                        else
                                                                        {
                                                                            Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                        }
                                                                    }


                                                                }
                                                            }
                                                            else if (Convert.ToInt16(periodofinstallment) == 4)
                                                            {
                                                                //Monthly
                                                                if (gridquotientCompleted + 1 <= Totalinstallment)
                                                                {
                                                                    if (gridyear == installmentstartdate.Year)
                                                                    {
                                                                        if (gridtotalmonthbwyears == 0)
                                                                        {
                                                                            if (gridmonth == installmentstartdate.Month)
                                                                            {
                                                                                gridquotientCompleted = gridtotalmonthbwyears + 1;
                                                                                noofinstallment = (gridquotientCompleted);
                                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                            }
                                                                            else
                                                                            {
                                                                                gridquotientCompleted = 0;
                                                                                noofinstallment = (gridquotientCompleted);
                                                                                Principalamountdue = 0;
                                                                            }

                                                                        }
                                                                        else
                                                                        {
                                                                            gridquotientCompleted = gridtotalmonthbwyears + 1;
                                                                            noofinstallment = (gridquotientCompleted);
                                                                            Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        gridquotientCompleted = gridtotalmonthbwyears + 1;
                                                                        noofinstallment = (gridquotientCompleted);
                                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                    }

                                                                }
                                                            }
                                                        }
                                                    }




                                                    #region interest amount check dcp date,5 years from current date

                                                    //DateTime fiveyearsdate = dcpdate.AddYears(5);
                                                    if (dat.AddMonths(k).Date <= fiveyearsdate.Date)
                                                    {
                                                        //installment date is less than 5 year date
                                                        //then interest amount to be calculated  
                                                        if ((dat.AddMonths(k).Year == fiveyearsdate.Year) && (dat.AddMonths(k).Month == fiveyearsdate.Month))
                                                        {
                                                            //Above 5 years the interest amount is zero,
                                                            //if same year & Same month then calcfor that many days;
                                                            int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                            int daystopaid = (daysinamonth - fiveyearsdate.Day) + 1;
                                                            decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                            interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                        }
                                                        else
                                                        {
                                                            if (dat.AddMonths(k).Date > dcpdate.Date)
                                                            {
                                                                if (dat.AddMonths(k).Year > dcpdate.Year)
                                                                {
                                                                    //installment started and dcp date started;
                                                                    // interestamount = (Principalamountdue * rateofinterestofdt) / 1200;
                                                                    if (noofinstallment > 0)
                                                                    {
                                                                        interestamount = (Principalamountdue * rateofinterestofdt) / 1200;
                                                                    }
                                                                    else
                                                                    {
                                                                        //installment not started,interest is given on term loan amount
                                                                        interestamount = (Totalamount * rateofinterestofdt) / 1200;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (dat.AddMonths(k).Year == dcpdate.Year)
                                                                    {
                                                                        //if same year & Same month then calcfor that many days;
                                                                        if ((dat.AddMonths(k).Year == dcpdate.Year) && (dat.AddMonths(k).Month == dcpdate.Month))
                                                                        {
                                                                            if (noofinstallment > 0)
                                                                            {
                                                                                int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                                                int daystopaid = (daysinamonth - dcpdate.Day) + 1;
                                                                                decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                                                interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                                            }
                                                                            else
                                                                            {
                                                                                int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                                                int daystopaid = (daysinamonth - dcpdate.Day) + 1;
                                                                                decimal pramountpaidfordays = (Totalamount / daysinamonth) * daystopaid;
                                                                                interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                                            }

                                                                        }
                                                                        else
                                                                        {
                                                                            if (dat.AddMonths(k).Month > dcpdate.Month)
                                                                            {
                                                                                if (noofinstallment > 0)
                                                                                {
                                                                                    interestamount = (Principalamountdue * rateofinterestofdt) / 1200;
                                                                                }
                                                                                else
                                                                                {
                                                                                    //installment not started,interest is given on term loan amount
                                                                                    interestamount = (Totalamount * rateofinterestofdt) / 1200;
                                                                                }
                                                                            }
                                                                        }
                                                                    }

                                                                }
                                                            }
                                                            else
                                                            {
                                                                //installment date started,before the dcp date,then
                                                                //if same year & Same month then calcfor that many days;
                                                                if ((dat.AddMonths(k).Year == dcpdate.Year) && (dat.AddMonths(k).Month == dcpdate.Month))
                                                                {
                                                                    if (noofinstallment > 0)
                                                                    {

                                                                        int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                                        int daystopaid = (daysinamonth - dcpdate.Day) + 1;
                                                                        decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                                        interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                                    }
                                                                    else
                                                                    {
                                                                        int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                                        int daystopaid = (daysinamonth - dcpdate.Day) + 1;
                                                                        decimal pramountpaidfordays = (Totalamount / daysinamonth) * daystopaid;
                                                                        interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                                    }
                                                                }
                                                            }



                                                        }
                                                    }
                                                    else
                                                    {
                                                        //Above 5 years the interest amount is zero,
                                                        //if same year & Same month then calcfor that many days;
                                                        if ((dat.AddMonths(k).Year == fiveyearsdate.Year) && (dat.AddMonths(k).Month == fiveyearsdate.Month))
                                                        {
                                                            int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                            int daystopaid = (daysinamonth - fiveyearsdate.Day) + 1;
                                                            decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                            interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                        }
                                                    }

                                                    #endregion

                                                    //   interestamount = (Principalamountdue * rateofinterestofdt) / 1200;

                                                }
                                                else
                                                {
                                                    //Finincal year started,installment date not started check with dcp date
                                                    #region interest amount check dcp date,5 years from current date


                                                    if (dat.AddMonths(k).Date <= fiveyearsdate.Date)
                                                    {
                                                        //installment date is less than 5 year date
                                                        //then interest amount to be calculated  
                                                        if ((dat.AddMonths(k).Year == fiveyearsdate.Year) && (dat.AddMonths(k).Month == fiveyearsdate.Month))
                                                        {
                                                            //Above 5 years the interest amount is zero,
                                                            //if same year & Same month then calcfor that many days;
                                                            int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                            int daystopaid = (daysinamonth - fiveyearsdate.Day) + 1;
                                                            decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                            interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                        }
                                                        else
                                                        {
                                                            if (dat.AddMonths(k).Date > dcpdate.Date)
                                                            {
                                                                if (dat.AddMonths(k).Year > dcpdate.Year)
                                                                {
                                                                    //installment started and dcp date started;
                                                                    //interestamount = (Principalamountdue * rateofinterestofdt) / 1200;
                                                                    if (noofinstallment > 0)
                                                                    {
                                                                        interestamount = (Principalamountdue * rateofinterestofdt) / 1200;
                                                                    }
                                                                    else
                                                                    {
                                                                        //installment not started,interest is given on term loan amount
                                                                        interestamount = (Totalamount * rateofinterestofdt) / 1200;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (dat.AddMonths(k).Year == dcpdate.Year)
                                                                    {
                                                                        //if same year & Same month then calcfor that many days;
                                                                        if ((dat.AddMonths(k).Year == dcpdate.Year) && (dat.AddMonths(k).Month == dcpdate.Month))
                                                                        {
                                                                            if (noofinstallment > 0)
                                                                            {

                                                                                int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                                                int daystopaid = (daysinamonth - dcpdate.Day) + 1;
                                                                                decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                                                interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                                            }
                                                                            else
                                                                            {
                                                                                int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                                                int daystopaid = (daysinamonth - dcpdate.Day) + 1;
                                                                                decimal pramountpaidfordays = (Totalamount / daysinamonth) * daystopaid;
                                                                                interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (dat.AddMonths(k).Month > dcpdate.Month)
                                                                            {
                                                                                //installment not started,interest is given on term loan amount
                                                                                // interestamount = (Totalamount * rateofinterestofdt) / 1200;
                                                                                if (noofinstallment > 0)
                                                                                {
                                                                                    interestamount = (Principalamountdue * rateofinterestofdt) / 1200;
                                                                                }
                                                                                else
                                                                                {
                                                                                    //installment not started,interest is given on term loan amount
                                                                                    interestamount = (Totalamount * rateofinterestofdt) / 1200;
                                                                                }
                                                                            }
                                                                        }
                                                                    }

                                                                }
                                                            }
                                                            else
                                                            {
                                                                //installment date started,before the dcp date,then
                                                                //if same year & Same month then calcfor that many days;
                                                                if ((dat.AddMonths(k).Year == dcpdate.Year) && (dat.AddMonths(k).Month == dcpdate.Month))
                                                                {
                                                                    if (noofinstallment > 0)
                                                                    {
                                                                        int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                                        int daystopaid = (daysinamonth - dcpdate.Day) + 1;
                                                                        decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                                        interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                                    }
                                                                    else
                                                                    {
                                                                        int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                                        int daystopaid = (daysinamonth - dcpdate.Day) + 1;
                                                                        decimal pramountpaidfordays = (Totalamount / daysinamonth) * daystopaid;
                                                                        interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                                    }
                                                                }
                                                            }



                                                        }
                                                    }
                                                    else
                                                    {
                                                        //Above 5 years the interest amount is zero,
                                                        //if same year & Same month then calcfor that many days;
                                                        if ((dat.AddMonths(k).Year == fiveyearsdate.Year) && (dat.AddMonths(k).Month == fiveyearsdate.Month))
                                                        {
                                                            int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                            int daystopaid = (daysinamonth - fiveyearsdate.Day) + 1;
                                                            decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                            interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                        }
                                                    }

                                                    #endregion
                                                }


                                                #region calculate unit holder

                                                if (interestamount > 0)
                                                {

                                                    EligibleRateofInterestofgrd = rateofinterestofdt - 3;
                                                    if (EligibleRateofInterestofgrd >= 9)
                                                    {
                                                        EligibleRateofInterestofgrd = 9;
                                                    }
                                                    if (EligibleRateofInterestofgrd < 0)
                                                    {
                                                        EligibleRateofInterestofgrd = 0;
                                                    }
                                                    UnitHolderContribution = rateofinterestofdt - EligibleRateofInterestofgrd;
                                                    EligibleInterestAmount = (interestamount * EligibleRateofInterestofgrd) / rateofinterestofdt;


                                                    if (gridyear == dcpdate.Year && gridmonth == dcpdate.Month)
                                                    {
                                                        int daysinamonthofgrid = DateTime.DaysInMonth(gridyear, gridmonth);
                                                        double daysforcal = 1 - (Convert.ToDouble(dcpdate.Day) / Convert.ToDouble(daysinamonthofgrid));
                                                        Toteglibleperiodinmonths = Toteglibleperiodinmonths + Convert.ToDecimal(daysforcal);
                                                    }
                                                    else
                                                    {
                                                        DateTime startDateofeachmonthgrd = new DateTime(gridyear, gridmonth, 1);
                                                        if (dcpdate.Date < startDateofeachmonthgrd.Date)
                                                        {
                                                            if (fiveyearsdate.Year == gridyear && gridmonth == fiveyearsdate.Month)
                                                            {
                                                                int daysinamonthofgrid = DateTime.DaysInMonth(gridyear, gridmonth);
                                                                //double daysforcal = 1 - (Convert.ToDouble(fiveyearsdate.Day) / Convert.ToDouble(daysinamonthofgrid));
                                                                //Toteglibleperiodinmonths = Toteglibleperiodinmonths + Convert.ToDecimal(daysforcal);
                                                                if (fiveyearsdate.Day == daysinamonthofgrid)
                                                                {
                                                                    Toteglibleperiodinmonths = Toteglibleperiodinmonths + 1;
                                                                }
                                                                else
                                                                {
                                                                    double daysforcal = 1 - (Convert.ToDouble(fiveyearsdate.Day) / Convert.ToDouble(daysinamonthofgrid));
                                                                    Toteglibleperiodinmonths = Toteglibleperiodinmonths + Convert.ToDecimal(daysforcal);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Toteglibleperiodinmonths = Toteglibleperiodinmonths + 1;
                                                            }

                                                        }
                                                        else
                                                        {

                                                        }


                                                    }
                                                }

                                                #endregion

                                                totalinterestforallfy = totalinterestforallfy + interestamount;
                                                totaleglibleinterestforallfy = totaleglibleinterestforallfy + EligibleInterestAmount;



                                                drs["MonthYear"] = MonthYear;
                                                drs["MonthName_Year"] = MonthName;
                                                drs["Principalamountdue"] = Convert.ToString(Math.Round(Principalamountdue, 2));
                                                drs["noofinstallment"] = noofinstallment;
                                                drs["InterestAmount"] = Convert.ToString(Math.Round(interestamount, 2));
                                                drs["RateofInterest"] = rateofinterestofdt;
                                                drs["EligibleRateofInterest"] = EligibleRateofInterestofgrd;
                                                drs["UnitHolderContribution"] = UnitHolderContribution;
                                                drs["EligibleInterestAmount"] = Convert.ToString(Math.Round(EligibleInterestAmount));
                                                dt_grid.Rows.Add(drs);
                                            }


                                            #endregion






                                            DataSet dsmain = new DataSet();
                                            dsmain.Tables.Add(dt_grid);

                                            if (dt_grid.Rows.Count > 0)
                                            {
                                                for (int t = 0; t < dt_grid.Rows.Count; t++)
                                                {
                                                    if (t == 0)
                                                    {
                                                        hfgrd_monthoneid.Value = Convert.ToString(dt_grid.Rows[0]["MonthYear"]);
                                                        lbl_grd_monthonename.Text = Convert.ToString(dt_grid.Rows[0]["MonthName_Year"]);
                                                        lbl_grd_monthnonePrincipalamounntdue.Text = Convert.ToString(dt_grid.Rows[0]["Principalamountdue"]);
                                                        lbl_grd_monthoneNoofInstallment.Text = Convert.ToString(dt_grid.Rows[0]["noofinstallment"]);
                                                        lbl_grd_monthoneRateofinterest.Text = Convert.ToString(dt_grid.Rows[0]["RateofInterest"]);
                                                        lbl_grd_monthoneInterestamount.Text = Convert.ToString(dt_grid.Rows[0]["InterestAmount"]);
                                                        lbl_grd_monthoneUnitHolderContribution.Text = Convert.ToString(dt_grid.Rows[0]["UnitHolderContribution"]);
                                                        lbl_grd_monthoneEligibleRateofinterest.Text = Convert.ToString(dt_grid.Rows[0]["EligibleRateofInterest"]);
                                                        lbl_grd_monthoneEligibleInterestAmount.Text = Convert.ToString(dt_grid.Rows[0]["EligibleInterestAmount"]);
                                                    }
                                                    if (t == 1)
                                                    {
                                                        hfgrd_monthtwoid.Value = Convert.ToString(dt_grid.Rows[1]["MonthYear"]);
                                                        lbl_grd_monthtwoname.Text = Convert.ToString(dt_grid.Rows[1]["MonthName_Year"]);
                                                        lbl_grd_monthtwoPrincipalamounntdue.Text = Convert.ToString(dt_grid.Rows[1]["Principalamountdue"]);
                                                        lbl_grd_monthtwoNoofInstallment.Text = Convert.ToString(dt_grid.Rows[1]["noofinstallment"]);
                                                        lbl_grd_monthtwoRateofinterest.Text = Convert.ToString(dt_grid.Rows[1]["RateofInterest"]);
                                                        lbl_grd_monthtwoInterestamount.Text = Convert.ToString(dt_grid.Rows[1]["InterestAmount"]);
                                                        lbl_grd_monthtwoUnitHolderContribution.Text = Convert.ToString(dt_grid.Rows[1]["UnitHolderContribution"]);
                                                        lbl_grd_monthtwoEligibleRateofinterest.Text = Convert.ToString(dt_grid.Rows[1]["EligibleRateofInterest"]);
                                                        lbl_grd_monthtwoEligibleInterestAmount.Text = Convert.ToString(dt_grid.Rows[1]["EligibleInterestAmount"]);
                                                    }
                                                    if (t == 2)
                                                    {
                                                        hfgrd_monththreeid.Value = Convert.ToString(dt_grid.Rows[2]["MonthYear"]);
                                                        lbl_grd_monththreename.Text = Convert.ToString(dt_grid.Rows[2]["MonthName_Year"]);
                                                        lbl_grd_monththreePrincipalamounntdue.Text = Convert.ToString(dt_grid.Rows[2]["Principalamountdue"]);
                                                        lbl_grd_monththreeNoofInstallment.Text = Convert.ToString(dt_grid.Rows[2]["noofinstallment"]);
                                                        lbl_grd_monththreeRateofinterest.Text = Convert.ToString(dt_grid.Rows[2]["RateofInterest"]);
                                                        lbl_grd_monththreeInterestamount.Text = Convert.ToString(dt_grid.Rows[2]["InterestAmount"]);
                                                        lbl_grd_monththreeUnitHolderContribution.Text = Convert.ToString(dt_grid.Rows[2]["UnitHolderContribution"]);
                                                        lbl_grd_monththreeEligibleRateofinterest.Text = Convert.ToString(dt_grid.Rows[2]["EligibleRateofInterest"]);
                                                        lbl_grd_monththreeEligibleInterestAmount.Text = Convert.ToString(dt_grid.Rows[2]["EligibleInterestAmount"]);
                                                    }
                                                    if (t == 3)
                                                    {
                                                        hfgrd_monthfourid.Value = Convert.ToString(dt_grid.Rows[3]["MonthYear"]);
                                                        lbl_grd_monthfourname.Text = Convert.ToString(dt_grid.Rows[3]["MonthName_Year"]);
                                                        lbl_grd_monthfourPrincipalamounntdue.Text = Convert.ToString(dt_grid.Rows[3]["Principalamountdue"]);
                                                        lbl_grd_monthfourNoofInstallment.Text = Convert.ToString(dt_grid.Rows[3]["noofinstallment"]);
                                                        lbl_grd_monthfourRateofinterest.Text = Convert.ToString(dt_grid.Rows[3]["RateofInterest"]);
                                                        lbl_grd_monthfourInterestamount.Text = Convert.ToString(dt_grid.Rows[3]["InterestAmount"]);
                                                        lbl_grd_monthfourUnitHolderContribution.Text = Convert.ToString(dt_grid.Rows[3]["UnitHolderContribution"]);
                                                        lbl_grd_monthfourEligibleRateofinterest.Text = Convert.ToString(dt_grid.Rows[3]["EligibleRateofInterest"]);
                                                        lbl_grd_monthfourEligibleInterestAmount.Text = Convert.ToString(dt_grid.Rows[3]["EligibleInterestAmount"]);
                                                    }
                                                    if (t == 4)
                                                    {
                                                        hfgrd_monthfiveid.Value = Convert.ToString(dt_grid.Rows[4]["MonthYear"]);
                                                        lbl_grd_monthfivename.Text = Convert.ToString(dt_grid.Rows[4]["MonthName_Year"]);
                                                        lbl_grd_monthfivePrincipalamounntdue.Text = Convert.ToString(dt_grid.Rows[4]["Principalamountdue"]);
                                                        lbl_grd_monthfiveNoofInstallment.Text = Convert.ToString(dt_grid.Rows[4]["noofinstallment"]);
                                                        lbl_grd_monthfiveRateofinterest.Text = Convert.ToString(dt_grid.Rows[4]["RateofInterest"]);
                                                        lbl_grd_monthfiveInterestamount.Text = Convert.ToString(dt_grid.Rows[4]["InterestAmount"]);
                                                        lbl_grd_monthfiveUnitHolderContribution.Text = Convert.ToString(dt_grid.Rows[4]["UnitHolderContribution"]);
                                                        lbl_grd_monthfiveEligibleRateofinterest.Text = Convert.ToString(dt_grid.Rows[4]["EligibleRateofInterest"]);
                                                        lbl_grd_monthfiveEligibleInterestAmount.Text = Convert.ToString(dt_grid.Rows[4]["EligibleInterestAmount"]);
                                                    }
                                                    if (t == 5)
                                                    {
                                                        hfgrd_monthsixid.Value = Convert.ToString(dt_grid.Rows[5]["MonthYear"]);
                                                        lbl_grd_monthsixname.Text = Convert.ToString(dt_grid.Rows[5]["MonthName_Year"]);
                                                        lbl_grd_monthsixPrincipalamounntdue.Text = Convert.ToString(dt_grid.Rows[5]["Principalamountdue"]);
                                                        lbl_grd_monthsixNoofInstallment.Text = Convert.ToString(dt_grid.Rows[5]["noofinstallment"]);
                                                        lbl_grd_monthsixRateofinterest.Text = Convert.ToString(dt_grid.Rows[5]["RateofInterest"]);
                                                        lbl_grd_monthsixInterestamount.Text = Convert.ToString(dt_grid.Rows[5]["InterestAmount"]);
                                                        lbl_grd_monthsixUnitHolderContribution.Text = Convert.ToString(dt_grid.Rows[5]["UnitHolderContribution"]);
                                                        lbl_grd_monthsixEligibleRateofinterest.Text = Convert.ToString(dt_grid.Rows[5]["EligibleRateofInterest"]);
                                                        lbl_grd_monthsixEligibleInterestAmount.Text = Convert.ToString(dt_grid.Rows[5]["EligibleInterestAmount"]);
                                                    }
                                                }
                                            }


                                        }
                                        else
                                        {
                                            ErrorMsg = ErrorMsg + slno + ". Due amount of next half year should be above zero \\n";
                                            slno = slno + 1;
                                        }
                                    }
                                    else
                                    {
                                        ErrorMsg = ErrorMsg + slno + ". Please Enter Installment Completed Months b/W 0 to 11/0 to 5/0 to 2 \\n";
                                        slno = slno + 1;
                                    }
                                }
                                else
                                {
                                    ErrorMsg = ErrorMsg + slno + ". completed total installment should be less than total installment   \\n";
                                    slno = slno + 1;
                                }


                                #endregion

                            }
                            else
                            {
                                ErrorMsg = ErrorMsg + slno + ". select no of rows for disable for moratorium\\n";
                                slno = slno + 1;
                            }


                        }
                        else
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Enter DCP date/Installment start/Total Amount/Period of installment/No of installments/Installment Amount\\n";
                            slno = slno + 1;
                        }

                    }
                    else
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter DCP date/Installment start date Should be less than current date \\n";
                        slno = slno + 1;
                    }
                }
            }


            txt_grdeglibilepallavaddiEligibleperiodinmonths.Text = Convert.ToString(Math.Round(Toteglibleperiodinmonths, 2));
            txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations.Text = Convert.ToString(Math.Round(totalinterestforallfy, 2));

            hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Value = Convert.ToString(Actualcalnoofinstallmentcompleted);
            txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Text = Convert.ToString(noofinstallmentcompleted);
            hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths.Value = Convert.ToString(ActualcalnoofinstallmentcompletedMonths);
            txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths.Text = Convert.ToString(noofinstallmentcompletedMonths);
            hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR.Value = Convert.ToString(Math.Round(Actualcaltermprincipaldueamount, 2));
            txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR.Text = Convert.ToString(Math.Round(termprincipaldueamount, 2));

            lbl_grd_totmonthsInterestamount.Text = Convert.ToString(Math.Round(totalinterestforallfy, 2));
            lbl_grd_totmonthsEligibleInterestAmount.Text = Convert.ToString(Math.Round(totaleglibleinterestforallfy, 2));

            decimal totalgridinterestamount = 0; decimal actualinterestamountpaid = 0; decimal interestamountcondisered = 0;
            decimal rateofinterest = 0; decimal egliblerateofinterest = 0; decimal interestegliblereimbursement = 0;
            decimal eglibleamountofreimbursementbyeglibletype = 0; decimal GMrecommendedamount = 0; decimal finalegibleamountdisscussed = 0;

            if (txt_grdeglibilepallavaddiGMrecommendedamount.Text != "")
            {
                GMrecommendedamount = Convert.ToDecimal(txt_grdeglibilepallavaddiGMrecommendedamount.Text);
            }

            if (txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations.Text != "")
            {
                totalgridinterestamount = Convert.ToDecimal(txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations.Text);
            }

            if (txt_grdeglibilepallavaddiActualinterestamountpaid.Text != "")
            {
                actualinterestamountpaid = Convert.ToDecimal(txt_grdeglibilepallavaddiActualinterestamountpaid.Text);
            }
            if (txt_claimeglibleincentivesloanwiseRateofInterest.Text.TrimStart().TrimEnd().Trim() != "")
            {
                rateofinterest = Convert.ToDecimal(txt_claimeglibleincentivesloanwiseRateofInterest.Text);
                if (rateofinterest == 0)
                {
                    if (lbl_grd_monthsixRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
                    {
                        rateofinterest = Convert.ToDecimal(lbl_grd_monthsixRateofinterest.Text);
                    }
                    else
                    {
                        if (rateofinterest == 0)
                        {
                            if (lbl_grd_monthoneRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
                            {
                                rateofinterest = Convert.ToDecimal(lbl_grd_monthoneRateofinterest.Text);
                            }
                        }
                    }
                }
            }

            if (totalgridinterestamount > 0)
            {
                if (totalgridinterestamount > 0)
                {
                    if (rateofinterest != 0)
                    {
                        if (rateofinterest > 3)
                        {
                            egliblerateofinterest = rateofinterest - 3;
                            if (egliblerateofinterest > 9)
                            {
                                egliblerateofinterest = 9;
                            }
                            if (egliblerateofinterest > 0)
                            {
                                if (totalgridinterestamount < actualinterestamountpaid)
                                {
                                    interestamountcondisered = totalgridinterestamount;
                                }
                                else
                                {
                                    interestamountcondisered = actualinterestamountpaid;
                                }
                                interestegliblereimbursement = (interestamountcondisered * egliblerateofinterest) / rateofinterest;
                            }
                            else
                            {
                                //Please Enter Eglible Rate of interest
                                ErrorMsg = ErrorMsg + slno + ". Please Enter Eglible rate of remibursement less than zero \\n";
                                slno = slno + 1;
                            }
                        }
                        else
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Enter rate of interest above 3 \\n";
                            slno = slno + 1;
                        }
                    }
                    else
                    {
                        //Please Enter Rate of interest
                        ErrorMsg = ErrorMsg + slno + ". Please Enter rate of interest \\n";
                        slno = slno + 1;
                    }
                }
                else
                {
                    //Please enter Actual interest amount paid
                }
            }
            else
            {
                //then error insert amount can't be zero
            }

            if (interestegliblereimbursement > 0)
            {
                if (rbtgrdeglibilepallavaddi_isbelated.SelectedValue == "0")
                {
                    //More than an Year
                    eglibleamountofreimbursementbyeglibletype = 0;
                    txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(eglibleamountofreimbursementbyeglibletype);

                }
                else if (rbtgrdeglibilepallavaddi_isbelated.SelectedValue == "Y")
                {
                    //Regular
                    eglibleamountofreimbursementbyeglibletype = interestegliblereimbursement;
                    txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(Math.Round(eglibleamountofreimbursementbyeglibletype, 2));
                }
                else if (rbtgrdeglibilepallavaddi_isbelated.SelectedValue == "N")
                {
                    //Belated
                    eglibleamountofreimbursementbyeglibletype = interestegliblereimbursement / 2;
                    txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(Math.Round(eglibleamountofreimbursementbyeglibletype, 2));
                }
                else
                {
                    //Please Select Eglible Type
                }
            }

            if (GMrecommendedamount < eglibleamountofreimbursementbyeglibletype)
            {
                finalegibleamountdisscussed = GMrecommendedamount;
            }

            else
            {
                finalegibleamountdisscussed = eglibleamountofreimbursementbyeglibletype;
            }

            txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement.Text = Convert.ToString(egliblerateofinterest);
            txt_grdeglibilepallavaddiInsertreimbursementcalculated.Text = Convert.ToString(Math.Round(interestegliblereimbursement, 2));
            txt_grdeglibilepallavaddiEligibleamount.Text = Convert.ToString(Math.Round(finalegibleamountdisscussed, 2));
            txt_claimeglibleincentivesloanwiseConsideredAmountforInterest.Text = Convert.ToString(Math.Round(interestamountcondisered, 2));
            interestamountcalacutionsofgrdeligible();
            return ErrorMsg;
        }
        void interestamountcalacutionsofgrdeligible()
        {
            decimal totalgridinterestamount = 0; decimal actualinterestamountpaid = 0; decimal interestamountcondisered = 0;
            decimal interestegliblereimbursement = 0; decimal eglibleamountofreimbursementbyeglibletype = 0;
            decimal GMrecommendedamount = 0; decimal finalegibleamountdisscussed = 0;

            for (int i = 0; i < grd_eglibilepallavaddi.Rows.Count; i++)
            {
                TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = grd_eglibilepallavaddi.Rows[i].FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations") as TextBox;
                TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = grd_eglibilepallavaddi.Rows[i].FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid") as TextBox;
                TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = grd_eglibilepallavaddi.Rows[i].FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated") as TextBox;
                TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = grd_eglibilepallavaddi.Rows[i].FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype") as TextBox;
                TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = grd_eglibilepallavaddi.Rows[i].FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest") as TextBox;

                if (!string.IsNullOrEmpty(txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations.Text))
                {
                    totalgridinterestamount = totalgridinterestamount + Convert.ToDecimal(txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations.Text);
                }

                if (!string.IsNullOrEmpty(txt_grdeglibilepallavaddiActualinterestamountpaid.Text))
                {
                    actualinterestamountpaid = actualinterestamountpaid + Convert.ToDecimal(txt_grdeglibilepallavaddiActualinterestamountpaid.Text);
                }

                if (!string.IsNullOrEmpty(txt_grdeglibilepallavaddiInsertreimbursementcalculated.Text))
                {
                    interestegliblereimbursement = interestegliblereimbursement + Convert.ToDecimal(txt_grdeglibilepallavaddiInsertreimbursementcalculated.Text);
                }

                if (!string.IsNullOrEmpty(txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype.Text))
                {
                    eglibleamountofreimbursementbyeglibletype = eglibleamountofreimbursementbyeglibletype + Convert.ToDecimal(txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype.Text);
                }

                if (!string.IsNullOrEmpty(txt_claimeglibleincentivesloanwiseConsideredAmountforInterest.Text))
                {
                    interestamountcondisered = interestamountcondisered + Convert.ToDecimal(txt_claimeglibleincentivesloanwiseConsideredAmountforInterest.Text);
                }

            }

            txt_Insertamounttobepaidaspercalculations.Text = Convert.ToString(totalgridinterestamount);
            txt_Actualinterestamountpaid.Text = Convert.ToString(actualinterestamountpaid);
            txt_Insertreimbursementcalculated.Text = Convert.ToString(interestegliblereimbursement);
            txt_eglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(eglibleamountofreimbursementbyeglibletype);
            txt_ConsideredAmountofInterest.Text = Convert.ToString(interestamountcondisered);
            if (txt_GMrecommendedamount.Text != "")
            {
                GMrecommendedamount = Convert.ToDecimal(txt_GMrecommendedamount.Text);
            }
            if (GMrecommendedamount < eglibleamountofreimbursementbyeglibletype)
            {
                finalegibleamountdisscussed = GMrecommendedamount;
            }
            else
            {
                finalegibleamountdisscussed = eglibleamountofreimbursementbyeglibletype;
            }
            txt_Eligibleamount.Text = Convert.ToString(Math.Round(finalegibleamountdisscussed, 2));
        }
        protected void txt_claimeglibleincentivesloanwiseinstallmentstartdate_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount, hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }


        protected void ddl_claimeglibleincentivesloanwiseperiodofinstallment_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList lnk_view = (DropDownList)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }


        protected void txt_claimeglibleincentivesloanwisenoofinstallment_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void txt_claimeglibleincentivesloanwiseInstallmentamount_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount
    , hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

        }


        protected void txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;
            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

        }

        protected void txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest,
    lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }


        protected void chk_claimeglibleincenloanwisepreviousfymot_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox lnk_view = (CheckBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");



            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest,
    lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void chk_moratiumapplforthisclaimperiod_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox lnk_view = (CheckBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest,
    lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void chk_grdclaimegliblerowstodisable_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBoxList lnk_view = (CheckBoxList)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");



            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest,
    lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable
    );


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }


        protected void txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }
        protected void GvBuildingDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            foreach (GridViewRow gvrow in GvBuildingDetails.Rows)
            {
                TextBox txtDLOSqmterValue = ((TextBox)(gvrow.FindControl("txtDLOSqmterValue")));
                if (txtDLOSqmterValue.Text == "" || txtDLOSqmterValue.Text == null)
                {
                    txtDLOSqmterValue.Text = "0.00";
                }
            }
        }
        public void CalculateBuildingData()
        {
            foreach (GridViewRow gvrow in GvBuildingDetails.Rows)
            {
                Label lblBUILDINGID = ((Label)(gvrow.FindControl("lblBUILDINGID")));
                TextBox txtDLOPlinthArea = ((TextBox)(gvrow.FindControl("txtDLOPlinthArea")));
                TextBox txtDLOSqmterValue = ((TextBox)(gvrow.FindControl("txtDLOSqmterValue")));
                TextBox txtDLOAmount = ((TextBox)(gvrow.FindControl("txtDLOAmount")));
                string BuildingId = lblBUILDINGID.Text.ToString();

                if (BuildingId == "1" || BuildingId == "2" || BuildingId == "3" || BuildingId == "4" || BuildingId == "5" || BuildingId == "6" || BuildingId == "7")
                {
                    string PlinthArea = txtDLOPlinthArea.Text.ToString();
                    TotalPlintArea = TotalPlintArea + Convert.ToDecimal(PlinthArea);
                }
                if (BuildingId == "1" || BuildingId == "2" || BuildingId == "3" || BuildingId == "4" || BuildingId == "5" || BuildingId == "6" || BuildingId == "7" || BuildingId == "8" || BuildingId == "9")
                {
                    string OnetoNineValue = txtDLOAmount.Text.ToString();
                    TotalOnetoNineValue = TotalOnetoNineValue + Convert.ToDecimal(OnetoNineValue);
                }
                if (BuildingId == "8" || BuildingId == "9" || BuildingId == "10" || BuildingId == "11" || BuildingId == "12" || BuildingId == "13"
                    || BuildingId == "14" || BuildingId == "15" || BuildingId == "16" || BuildingId == "17")
                {
                    string EighttoSeventeenValue = txtDLOAmount.Text.ToString();
                    TotalEighttoSeventeenValue = TotalEighttoSeventeenValue + Convert.ToDecimal(EighttoSeventeenValue);
                }
            }
            decimal TenPerofOnetoNineValue = 0;
            TenPerofOnetoNineValue = TotalOnetoNineValue * Convert.ToDecimal(0.10);
            lbl1to7Plinth.InnerText = TotalPlintArea.ToString();
            lbl1to9Value.InnerText = TotalOnetoNineValue.ToString();
            lbl8to17Value.InnerText = TotalEighttoSeventeenValue.ToString();
            if (TotalEighttoSeventeenValue > TenPerofOnetoNineValue)
            {
                divExceed.Visible = true;
            }
            else
            {
                divExceed.Visible = false;
            }
        }
        protected void btn_savegrdclaimperiodofloanadd_Click(object sender, EventArgs e)
        {
            DateTime? DateofCommencementofactivity = null;
            if (lblDCPdate.InnerText != null)
            {
                DateofCommencementofactivity = Convert.ToDateTime(lblDCPdate.InnerText);
            }
            try
            {

                DataTable dt_grid = new DataTable();
                dt_grid.Columns.Add("IncentiveId", typeof(string));
                dt_grid.Columns.Add("FinancialYear", typeof(string));
                dt_grid.Columns.Add("FinancialYearID", typeof(string));
                dt_grid.Columns.Add("FinancialYearName", typeof(string));
                dt_grid.Columns.Add("LoanNumber", typeof(int));


                dt_grid.Columns.Add("DCPDATE", typeof(string));
                dt_grid.Columns.Add("InstallmentStartdate", typeof(string));
                dt_grid.Columns.Add("TotalTermLoanAmt", typeof(decimal));

                dt_grid.Columns.Add("PeriodofinstallmentID", typeof(string));
                dt_grid.Columns.Add("PeriodofinstallmentName", typeof(string));
                dt_grid.Columns.Add("Noofinstallment", typeof(int));

                dt_grid.Columns.Add("RateofInterest", typeof(string));
                dt_grid.Columns.Add("EglibleRateofInterestreimbursement", typeof(string));
                dt_grid.Columns.Add("InstallmentAmount", typeof(string));
                dt_grid.Columns.Add("NoofInstallmentCompleted", typeof(string));
                dt_grid.Columns.Add("PrincipalAmountthishalfyear", typeof(string));
                dt_grid.Columns.Add("GM_Rcon_Amount", typeof(string));

                string GM_Rcon_Amount = "0";
                if (Convert.ToString(Session["GM_Rcon_Amount"]) != "")
                {
                    GM_Rcon_Amount = Convert.ToString(Session["GM_Rcon_Amount"]);
                }
                if (Convert.ToString(SubsidySystemRecommended.InnerText) != "")
                {
                    GM_Rcon_Amount = Convert.ToString(SubsidySystemRecommended.InnerText);
                }


                for (int i = 0; i < GvInterestSubsidyPeriod.Rows.Count; i++)
                {
                    HiddenField hf_claimperiodofloanaddIncentiveId = GvInterestSubsidyPeriod.Rows[i].FindControl("hf_claimperiodofloanaddIncentiveId") as HiddenField;
                    Label hf_claimperiodofloanaddFinancialYear = GvInterestSubsidyPeriod.Rows[i].FindControl("lblFinancialYear") as Label;
                    HiddenField hf_claimperiodofloanadd_ID = GvInterestSubsidyPeriod.Rows[i].FindControl("hf_claimperiodofloanadd_ID") as HiddenField;
                    Label lbl_claimperiodofloanaddname = GvInterestSubsidyPeriod.Rows[i].FindControl("lblHalfYearFlag") as Label;
                    TextBox txt_claimperiodofloanaddNumber = GvInterestSubsidyPeriod.Rows[i].FindControl("txt_claimperiodofloanaddNumber") as TextBox;


                    if (!string.IsNullOrEmpty(txt_claimperiodofloanaddNumber.Text))
                    {
                        if (Convert.ToInt32(txt_claimperiodofloanaddNumber.Text) > 0)
                        {

                            for (int loanid = 0; loanid < Convert.ToInt32(txt_claimperiodofloanaddNumber.Text); loanid++)
                            {
                                DataRow drs = dt_grid.NewRow();
                                int test = loanid + 1;
                                drs["LoanNumber"] = loanid + 1;
                                drs["IncentiveId"] = Convert.ToString(hf_claimperiodofloanaddIncentiveId.Value);
                                drs["FinancialYear"] = Convert.ToString(hf_claimperiodofloanaddFinancialYear.Text);
                                drs["FinancialYearID"] = Convert.ToString(hf_claimperiodofloanadd_ID.Value);
                                drs["FinancialYearName"] = Convert.ToString(lbl_claimperiodofloanaddname.Text);
                                drs["DCPDATE"] = DateofCommencementofactivity;
                                drs["GM_Rcon_Amount"] = GM_Rcon_Amount;
                                dt_grid.Rows.Add(drs);
                            }

                            // txt_DateofCommencementofactivity.Text =Convert.ToDateTime(ds.Tables[0].Rows[0]["CommencmentOfCommrclProdcn_Date"]).ToString("dd/MM/yyyy");
                        }
                    }


                }

                DataSet ds_loantype = new DataSet();
                ds_loantype.Tables.Add(dt_grid);
                if (dt_grid.Rows.Count > 0)
                {
                    //grd_claimeglibleincentivesloanwise.DataSource = dt_grid;
                    //grd_claimeglibleincentivesloanwise.DataBind();
                    //grd_claimeglibleincentivesloanwise.Visible = true;
                    grd_eglibilepallavaddi.DataSource = dt_grid;
                    grd_eglibilepallavaddi.DataBind();
                    grd_eglibilepallavaddi.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }
        }


        protected void txt_GMrecommendedamount_TextChanged(object sender, EventArgs e)
        {
            interestamountcalacutionsofgrdeligible();
        }

        protected void BtnSave3_Click(object sender, EventArgs e)
        {


            string newPath = "";

            General t1 = new General();
            if (FileUpload1.HasFile)
            {
                string incentiveid = ""; //txtINCNoEntry.Text;// Session["EntprIncentive"].ToString();
                string masterincentiveid = "1";
                if ((FileUpload1.PostedFile != null) && (FileUpload1.PostedFile.ContentLength > 0))
                {
                    string sFileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                    try
                    {
                        string[] fileType = FileUpload1.PostedFile.FileName.Split('.');
                        int i = fileType.Length;
                        if (fileType[i - 1].ToUpper().Trim() == "PDF" || fileType[i - 1].ToUpper().Trim() == "DOC" || fileType[i - 1].ToUpper().Trim() == "JPG" || fileType[i - 1].ToUpper().Trim() == "XLS" || fileType[i - 1].ToUpper().Trim() == "XLSX" || fileType[i - 1].ToUpper().Trim() == "DOCX" || fileType[i - 1].ToUpper().Trim() == "ZIP" || fileType[i - 1].ToUpper().Trim() == "RAR" || fileType[i - 1].ToUpper().Trim() == "JPEG" || fileType[i - 1].ToUpper().Trim() == "PNG")
                        {
                            string sFileDir = ConfigurationManager.AppSettings["INCfilePath"];

                            //string serverpath = Server.MapPath("~\\IncentivesAttachments\\" + incentiveid.ToString() + "\\49");  // incentiveid2
                            // string serverpath = System.IO.Path.Combine(sFileDir + "ADWORKSHEET_SALESTAX" + "\\" + incentiveid.ToString() + "\\" + masterincentiveid.ToString());
                            string serverpath = System.IO.Path.Combine(sFileDir + incentiveid.ToString() + "\\" + "ADWORKSHEET_PAVALLAVADDI" + "\\" + masterincentiveid.ToString());


                            if (!Directory.Exists(serverpath))
                                Directory.CreateDirectory(serverpath);

                            FileUpload1.PostedFile.SaveAs(serverpath + "\\" + sFileName);
                            string CrtdUser = Session["uid"].ToString();

                            string Path = serverpath;
                            string FileName = sFileName;


                            //t1.InsertIncentiveAttachment(incentiveid, "100018", sFileName, serverpath, CrtdUser);
                           // t1.InsertIncentiveAttachmentInspReports(incentiveid, "1111120", sFileName, serverpath, CrtdUser, masterincentiveid.ToString(), "WorkSheet");

                            lblFileName.NavigateUrl = serverpath + sFileName;
                            lblFileName.Text = sFileName;
                            lblFileName.Visible = true;
                            success.Visible = true;
                            lblmsg.Text = "File uploaded successfully.";
                            Failure.Visible = false;
                            //troptpbutton.Visible = true;
                        }
                        else
                        {
                            success.Visible = false;
                            Failure.Visible = true;
                        }

                    }
                    catch (Exception)//in case of an error
                    {
                        DeleteFile(newPath + "\\" + sFileName);
                    }
                }
            }
            else
            {
                lblmsg0.Text = "<font color='red'>Please Select a file To Upload..!</font>";
                success.Visible = false;
                Failure.Visible = true;
            }
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
        protected void txt_grdeglibilepallavaddiEligibleperiodinmonths_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow gvgrd_eglibilepallavaddiRow = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

        }

        protected void txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

        }

        protected void txt_grdeglibilepallavaddiActualinterestamountpaid_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

        }

        protected void txt_grdeglibilepallavaddiInsertreimbursementcalculated_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest,
    lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

        }

        protected void txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

        }

        protected void rbtgrdeglibilepallavaddi_isbelated_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList lnk_view = (RadioButtonList)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");



            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

        }

        protected void txt_grdeglibilepallavaddiGMrecommendedamount_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void txt_claimeglibleincentivesloanwiseRateofInterest_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

        }

        protected void txt_claimeglibleincentivesloanwiseConsideredAmountforInterest_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest,
    lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }
    }

}