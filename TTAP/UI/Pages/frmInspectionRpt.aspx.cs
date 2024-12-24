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
    public partial class frmInspectionRpt : System.Web.UI.Page
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
                        /*if (SubIncentiveId == "1" || SubIncentiveId == "19")
                        {
                            trImage1.Visible = true;
                            trImage2.Visible = true;
                            trImage3.Visible = true;
                            trImage4.Visible = true;
                            GetUploadedImages(IncentiveID, SubIncentiveId);
                        }*/

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
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_INSPECTION_DTLS", pp);
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
            decimal DLORecommendedTotalAmount = 0;
            foreach (GridViewRow gvrow in gvAdditionalInformation.Rows)
            {
                TextBox txtDLOEligibleInterest = ((TextBox)(gvrow.FindControl("txtDLOEligibleInterest")));
                decimal DLOEligibleInterest = Convert.ToDecimal(txtDLOEligibleInterest.Text.Trim().ToString());
                DLORecommendedTotalAmount = DLORecommendedTotalAmount + DLOEligibleInterest;
            }
            lblDLOSuggestedAmount.Text = DLORecommendedTotalAmount.ToString();
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

    }
}
