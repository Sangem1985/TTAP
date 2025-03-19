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

namespace TTAP.UI.Pages.Annexures
{
    public partial class frmInspectionRptView : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        CAFClass ObjCAFClass = new CAFClass();
        decimal AMachineCost = 0, NAMachineCost = 0;
        decimal AEqpCost = 0, NAEqpCost = 0;
        decimal TotalPlintArea = 0, TotalOnetoNineValue=0, TotalEighttoSeventeenValue = 0;
        decimal InterestAmountPaid = 0;
        decimal SanctionedAmount = 0;
        decimal EligibleInterest = 0;
        decimal DLORecommendedInterest = 0;
        string Role = "";
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
                        Role = ObjLoginNewvo.Role_Code;
                        hdnUserRole.Value = Role;
                        string IncentiveID = Request.QueryString["IncentiveID"].ToString();
                        string SubIncentiveId = Request.QueryString["SubIncentiveId"].ToString();
                        hdnSubIncentiveId.Value= Request.QueryString["SubIncentiveId"].ToString();
                        BindBesicdata(IncentiveID, SubIncentiveId, ObjLoginNewvo.DistrictID);
                        bool strKey = Convert.ToBoolean(ConfigurationManager.AppSettings["SysCalamount"].ToString());
                        bool strKeyDLO = Convert.ToBoolean(ConfigurationManager.AppSettings["DLOSysCalamount"].ToString());
                        /*tdsysSubsidy.Visible = false;
                        tdsysSubsidy1.Visible = false;
                        trcapitalsubsidy.Visible = false;*/
                        if (Role == "DLO")
                        {   /*tdsysSubsidy.Visible = strKeyDLO;
                            tdsysSubsidy1.Visible = strKeyDLO;
                            trcapitalsubsidy.Visible = strKeyDLO;*/
                            chkShow.Visible = true;
                        }

                    }
                }
            }
           
        }

        public void BindBesicdata(string IncentiveID, string SubIncentiveId, string DistrictID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetapplicationDtls("0", IncentiveID);
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    txtUnitName.InnerHtml = dsnew.Tables[0].Rows[0]["UnitName"].ToString();
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
                    lblReceiptDate.InnerHtml = dsnew.Tables[0].Rows[0]["ApplicationFiledDate"].ToString();
                    lblcategory.InnerText = dsnew.Tables[0].Rows[0]["SocialStatusText"].ToString();
                    lblCategoryofUnit.InnerText = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    lblActivityoftheUnit.InnerText = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();

                    TypeofTexttile.InnerText = dsnew.Tables[0].Rows[0]["TypeofTexttileText"].ToString();
                    ddlindustryStatus(TypeOfIndustry.Trim().TrimStart().TrimEnd(), dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString());

                    DataSet dsnew1 = new DataSet();
                    dsnew1 = GetSubsidyApplicationDeatils(IncentiveID, SubIncentiveId, DistrictID);
                    if (dsnew1 != null && dsnew1.Tables.Count > 0 && dsnew1.Tables[0].Rows.Count > 0)
                    {
                        HMainheading.InnerHtml = "PART  B <br/> " + dsnew1.Tables[0].Rows[0]["IncentiveName"].ToString() + "<br/> Inspecting Officer Report";
                        if (dsnew1.Tables[0].Rows[0]["IndustryDeptFlag"].ToString() != "")
                        {
                            trIndustryDeptDtls.Visible = true;
                            trIndustryDeptRemarks.Visible = true;
                            lblIndustriesPerosnName.InnerText = dsnew1.Tables[0].Rows[0]["IndustryDeptPersonName"].ToString();
                            lblIndustryReportDate.InnerText = dsnew1.Tables[0].Rows[0]["IndustryDeptUpdatedOn"].ToString();
                            txtIndustriesRemarks.InnerText= dsnew1.Tables[0].Rows[0]["IndustryDeptRemarks"].ToString();
                        }
                        if (SubIncentiveId == "1" || SubIncentiveId == "19")
                        {
                            tr1.Visible = false;
                            Capitalsub.Visible = true;
                            lblIndustryPersonName.Visible = true;
                            divplantmachinary.Visible = true;
                            BindPandMGrid(0, Convert.ToInt32(IncentiveID), TypeOfIndustry,hdnUserRole.Value.ToString());
                            if (SubIncentiveId == "1")
                            {
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

                                trApprovedProject.Visible = true;
                                trActualInvestment.Visible = true;

                                trcapitalsubsidy.Visible = true;
                                trAmountofSubsidyRecommendedAbstract.Visible = true;

                                lblCalcLandValue.Text = dsnew1.Tables[0].Rows[0]["DLOLandCalculatedAmount"].ToString();
                                lblCalcBuildingValue.Text = dsnew1.Tables[0].Rows[0]["DLOBuildingCalculatedAmount"].ToString();
                                lblCalcPMValue.Text = dsnew1.Tables[0].Rows[0]["DLOPMCalculatedAmount"].ToString();

                                lblSystemTotal.InnerHtml = dsnew1.Tables[0].Rows[0]["SystemRecommendedAmount"].ToString();
                                lblSystemSubsidy.InnerHtml = dsnew1.Tables[0].Rows[0]["SystemCapitalSubsidyAmount"].ToString();
                                lblSystemAdditionalCapitalSubsidy.InnerHtml = dsnew1.Tables[0].Rows[0]["SystemAdditionalCapitalSubsidyAmount"].ToString();

                                txtInspectingOfficerSubsidy.InnerHtml = dsnew1.Tables[0].Rows[0]["CapitalSubsidyAmount"].ToString();
                                txtInspectingOfficerAdditionalCapitalSubsidy.InnerHtml = dsnew1.Tables[0].Rows[0]["AdditionalCapitalSubsidyAmount"].ToString();
                                lblInspectingOfficerTotal.InnerHtml = dsnew1.Tables[0].Rows[0]["OfficerRecommendedAmount"].ToString();
                                GetCapitalSubsidyBuildingDtls(IncentiveID, SubIncentiveId);
                                trBuildingDetails.Visible = true;
                                trLandDetails.Visible = true;
                                BindDLOLanddata(IncentiveID);

                            }
                            else
                            {
                                trcapitalsubsidy.Visible = false;
                            }
                        }
                        if (SubIncentiveId == "2")
                        {
                            BindEquipments(Convert.ToInt32(IncentiveID));
                            trEqiupment.Visible = true;
                        }

                        if (SubIncentiveId == "3")
                        {
                            BindISCrrentClaimPeriodDtls(IncentiveID.ToString());
                            BindTearmLoanDtls(IncentiveID.ToString());
                            BindTermLoanRepaid(0, Convert.ToInt32(IncentiveID));
                            BindAdditionalInformationDtls(IncentiveID.ToString());
                            BindMoratoriumPeriodDetails(0, Convert.ToInt32(IncentiveID.ToString()));
                            divIntrestSubsidy.Visible = true;
                            if (dsnew1.Tables.Count > 1)
                            {
                                if (dsnew1.Tables[1].Rows[0]["SanctionOrderNo"].ToString() != "")
                                {
                                    lblAmountAvailed.Text = dsnew1.Tables[1].Rows[0]["AmountAvailed"].ToString();
                                    lblSanctionOrderNo.Text = dsnew1.Tables[1].Rows[0]["SanctionOrderNo"].ToString();
                                    lblSanctionOrderNo.Text = dsnew1.Tables[1].Rows[0]["DateAvailedDDMMYY"].ToString();
                                    lblGOAgency.Text = "Yes";
                                    divGOAgency.Visible = true;
                                }
                                else
                                {
                                    lblGOAgency.Text = "No";
                                }
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

                        lblInspectingOfficerName.InnerHtml = dsnew1.Tables[0].Rows[0]["Name"].ToString();
                        lblInspectionSchduledDate.InnerHtml = dsnew1.Tables[0].Rows[0]["SchduledDate"].ToString();

                        lblquerydate.InnerHtml = dsnew1.Tables[0].Rows[0]["QueryDate"].ToString();
                        lblresponsedate.InnerHtml = dsnew1.Tables[0].Rows[0]["QueryResponseDare"].ToString();

                        lblSubsidyClaimedUnit.InnerHtml = dsnew1.Tables[0].Rows[0]["UnitClaimedAmount"].ToString();
                        SubsidySystemRecommended.InnerHtml = dsnew1.Tables[0].Rows[0]["SystemRecommendedAmount"].ToString();

                        txtAmountSubsidyRecommended.InnerHtml = dsnew1.Tables[0].Rows[0]["OfficerRecommendedAmount"].ToString();
                        txtAppDateofInspection.InnerHtml = dsnew1.Tables[0].Rows[0]["InspectionDoneOn"].ToString();
                        txtRemarks.InnerHtml = dsnew1.Tables[0].Rows[0]["Remarks"].ToString();

                        lblIndustryPersonName.InnerHtml = dsnew1.Tables[0].Rows[0]["IndustryPersonName"].ToString();
                        lblRevisedCategory.InnerHtml= dsnew1.Tables[0].Rows[0]["Ins_Category"].ToString();
                        lblRevisedTypeTextile.InnerHtml = dsnew1.Tables[0].Rows[0]["Ins_TypeOfTextile"].ToString();
                        lblInsAmount.InnerHtml= dsnew1.Tables[0].Rows[0]["Actual_SystemRecommended"].ToString();
                        lblClaimPeriod.InnerHtml = dsnew1.Tables[0].Rows[0]["ClaimPeriod"].ToString();


                        string DIPCFlag = dsnew1.Tables[0].Rows[0]["DIPC_FLAG"].ToString();
                        string INSFlag = dsnew1.Tables[0].Rows[0]["Ins_Flag"].ToString();
                        if (INSFlag == "Y")
                        {
                            trInsFlag.Visible = true;
                            trInsAmount.Visible = false;
                        }
                        if (DIPCFlag != "Y")
                        {
                            //spnRDD.Visible = true;
                            //spnRDDname.Visible = false;
                            divSLCFIle.Visible = true;
                        }
                        else
                        {
                            //spnRDD.Visible = false;
                            divSLCFIle.Visible = false;
                            spnDLO.Style.Clear();
                            //spnDLO.Style.Remove("padding-left");
                            spnDLO.Style.Add("font-weight", "bold");

                        }

                        GetIncetiveAttachements(IncentiveID, SubIncentiveId);
                        GetSnos();
                    }
                }
                else
                {

                }

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                DataSet Dsofficer = new DataSet();
                Dsofficer = GetInspectionOfficerDtls(IncentiveID, SubIncentiveId, ObjLoginNewvo.uid, ObjLoginNewvo.Role_Code, "INSPECTION");
                if (Dsofficer != null && Dsofficer.Tables.Count > 0 && Dsofficer.Tables[0].Rows.Count > 0)
                {
                    lblGMname.Text = Dsofficer.Tables[0].Rows[0]["OfficerName"].ToString() + "</br>" + Dsofficer.Tables[0].Rows[0]["Designation"].ToString() + "</br>" + "" + Dsofficer.Tables[0].Rows[0]["WorkingDistrict"].ToString();
                    lblplace.Text = "Date : " + Dsofficer.Tables[0].Rows[0]["CurrentDate"].ToString() + "</br> Location : " + Dsofficer.Tables[0].Rows[0]["Place"].ToString();

                    lblRDDname.Text = Dsofficer.Tables[0].Rows[0]["RDDOfficerName"].ToString() + "</br>" + Dsofficer.Tables[0].Rows[0]["RDDDesignation"].ToString() + "</br>" + "" + Dsofficer.Tables[0].Rows[0]["RDDWorkingDistrict"].ToString();

                    lblDLORDOName.Text = "<b>" + Dsofficer.Tables[0].Rows[0]["OfficerName"].ToString() + "</b>," + Dsofficer.Tables[0].Rows[0]["Designation"].ToString() + "," + "" + Dsofficer.Tables[0].Rows[0]["WorkingDistrict"].ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void BindDLOLanddata(string IncentiveID)
        {
            DataSet dsnew1 = new DataSet();
            dsnew1 = GetDLOInspectedLandDetails(IncentiveID);
            if (dsnew1 != null && dsnew1.Tables.Count > 0)
            {
                lblExtentActual.Text = dsnew1.Tables[0].Rows[0]["PurchasedLandExtent"].ToString();
                lblExtentDLO.Text= dsnew1.Tables[0].Rows[0]["LandExtentAsPerDLO"].ToString();
                lblAcreCostActual.Text = dsnew1.Tables[0].Rows[0]["PurchasedLandValue"].ToString();
                lblTotalLanndCostApproved.Text= dsnew1.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString();
                lblTotalLanndCostActual.Text = dsnew1.Tables[0].Rows[0]["ACTUALINV_LAND"].ToString();
                lblTotalLanndCostDLO.Text = dsnew1.Tables[0].Rows[0]["DLOLandCalculatedAmount"].ToString();
                lblAcreCostDLO.Text = dsnew1.Tables[0].Rows[0]["DLOLandPerAcreAmount"].ToString();
                lblLandCostSaledeed.Text = dsnew1.Tables[0].Rows[0]["LandValueSaleDeed"].ToString();
                lblExtentSaledeed.Text = dsnew1.Tables[0].Rows[0]["DLORecommendedLandExtent"].ToString();
                lblAcreCostSaledeed.Text = dsnew1.Tables[0].Rows[0]["DLOLandPerAcreAmount"].ToString();
                trCalcLandBuilding.Visible = true;
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
               new SqlParameter("@DistID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            pp[1].Value = SubIncentiveId;
            pp[2].Value = DistID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_INSPECTION_DTLS_VIEW", pp);
            return Dsnew;
        }
        public DataSet GetDLOInspectedLandDetails(string IncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveId;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_DLO_INSPECTION_LAND_DATA", pp);
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
        public void GetSnos()
        {
            int slno = 0;
            foreach (GridViewRow row in gvSubsidy.Rows)
            {
                string Date = (row.FindControl("lblverified") as Label).Text;
                if (Date != "")
                {
                    slno = slno + 1;
                    row.Cells[0].Text = Convert.ToString(slno);
                }
                else
                {
                    row.Cells[0].Text = "";
                }
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
                //dsnew1.Tables[0].Rows.Add("1", "2", "3", "4", "5", "6", "7", "8");
                GvBuildingDetails.DataSource = dsnew1.Tables[0];
                GvBuildingDetails.DataBind();
            }
            else
            {
                GvBuildingDetails.DataSource = null;
                GvBuildingDetails.DataBind();
            }
            if (dsnew1.Tables[1].Rows.Count > 0)
            {

                txtPLExtent.Text = dsnew1.Tables[1].Rows[0]["PurchasedLandExtent"].ToString();
                txtPLValue.Text = dsnew1.Tables[1].Rows[0]["PurchasedLandValue"].ToString();
                txtLLExtent.Text = dsnew1.Tables[1].Rows[0]["LeasedLandExtent"].ToString();
                txtLLValue.Text = dsnew1.Tables[1].Rows[0]["LeasedLandValue"].ToString();
                txtILExtent.Text = dsnew1.Tables[1].Rows[0]["InheritedLandExtent"].ToString();
                txtILValue.Text = dsnew1.Tables[1].Rows[0]["InheritedLandValue"].ToString();
                txtGLExtent.Text = dsnew1.Tables[1].Rows[0]["GovtLandExtent"].ToString();
                txtGLValue.Text = dsnew1.Tables[1].Rows[0]["GovtLandValue"].ToString();

                BindTotalLandValue("1");
                BindTotalLandValue("2");
                BindTotalLandValue("3");
                BindTotalLandValue("4");
            }
        }
        public void BindTotalLandValue(string LandTypeSlno)
        {
            Double Extent = 0, LandValue = 0;
            if (LandTypeSlno == "1")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(txtPLExtent.Text.TrimStart().TrimEnd()));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtPLValue.Text.TrimStart().TrimEnd()));

                lblPLTotalValue.Text = (Extent * LandValue).ToString();
            }
            else if (LandTypeSlno == "2")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(txtLLExtent.Text.TrimStart().TrimEnd()));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtLLValue.Text.TrimStart().TrimEnd()));

                lblLLTotalValue.Text = (Extent * LandValue).ToString();
            }
            else if (LandTypeSlno == "3")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(txtILExtent.Text.TrimStart().TrimEnd()));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtILValue.Text.TrimStart().TrimEnd()));

                lblILTotalValue.Text = (Extent * LandValue).ToString();
            }
            else if (LandTypeSlno == "4")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(txtGLExtent.Text.TrimStart().TrimEnd()));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtGLValue.Text.TrimStart().TrimEnd()));

                lblGLTotalValue.Text = (Extent * LandValue).ToString();
            }
        }
        public string GetDecimalNullValue(string Input)
        {
            string InputValue = "";

            InputValue = (Input != "") ? Input : "0";

            return InputValue;
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
                string errorMsg = ex.Message;
                //lblmsg0.Text = "Internal error has occured. Please try after some time";
                //lblmsg0.Text = ex.Message;
                //Failure.Visible = true;
                // LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        public DataSet GetInspectionOfficerDtls(string incentiveid, string SubIncentiveID, string createdby, string RoleCode, string TYPEOFTRANSACTION)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@Incentiveid",SqlDbType.VarChar),
               new SqlParameter("@SubIncentiveID",SqlDbType.VarChar),
               new SqlParameter("@Created_by",SqlDbType.VarChar),
               new SqlParameter("@RoleCode",SqlDbType.VarChar),
               new SqlParameter("@TYPEOFTRANSACTION",SqlDbType.VarChar)
           };
            pp[0].Value = incentiveid;
            pp[1].Value = SubIncentiveID;
            pp[2].Value = createdby;
            pp[3].Value = RoleCode;
            pp[4].Value = TYPEOFTRANSACTION;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_OFFICER_NAME", pp);
            return Dsnew;
        }

        public void BindPandMGrid(int PMId, int IncentiveId, string IndusType,string Role)
        {
            DataSet ds = new DataSet();
            try
            {

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
                //lblmsg0.Text = ex.Message;
                //Failure.Visible = true;
                //success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
        public DataSet GetPandM(int PMId, int IncentiveId, string IndusType,string Role)
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
            return Dsnew;
        }

        protected void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow.Checked == true)
            {
                tdsysSubsidy.Visible = true;
                tdsysSubsidy1.Visible = true;
                trcapitalsubsidy.Visible = true;
            }
            else
            {
                tdsysSubsidy.Visible = false;
                tdsysSubsidy1.Visible = false;
                trcapitalsubsidy.Visible = false;
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

                   // Td3.Visible = false;
                    Td6.Visible = false;

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

                    //Td3.Visible = true;
                    Td6.Visible = true;

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

                    //Td3.Visible = true;
                    Td6.Visible = true;

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

        protected void GvBuildingDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string BuildingId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BUILDINGID"));
                    if (BuildingId == "1" || BuildingId == "2" || BuildingId == "3" || BuildingId == "4" || BuildingId == "5" || BuildingId == "6" || BuildingId == "7")
                    {
                        string PlinthArea = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DLORecommendedPlinthArea"));
                        TotalPlintArea = TotalPlintArea + Convert.ToDecimal(PlinthArea);
                    }
                    if (BuildingId == "1" || BuildingId == "2" || BuildingId == "3" || BuildingId == "4" || BuildingId == "5" || BuildingId == "6" || BuildingId == "7" || BuildingId == "8" || BuildingId == "9")
                    {
                        string OnetoNineValue = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DLORecommendedAmount"));
                        TotalOnetoNineValue = TotalOnetoNineValue + Convert.ToDecimal(OnetoNineValue);
                    }
                    if (BuildingId == "8" || BuildingId == "9" || BuildingId == "10" || BuildingId == "11" || BuildingId == "12" || BuildingId == "13" 
                        || BuildingId == "14" || BuildingId == "15" || BuildingId == "16" || BuildingId == "17")
                    {
                        string EighttoSeventeenValue = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DLORecommendedAmount"));
                        TotalEighttoSeventeenValue = TotalEighttoSeventeenValue + Convert.ToDecimal(EighttoSeventeenValue);
                    }
                }
                lbl1to7Plinth.InnerText = TotalPlintArea.ToString();
                lbl1to9Value.InnerText = TotalOnetoNineValue.ToString();
                lbl8to17Value.InnerText = TotalEighttoSeventeenValue.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        protected void grdPandM_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    string Actiontaken = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MachineAvailability"));
                    string MachineCost = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DLOFinalRecommendedMachineCost"));
                    if (Actiontaken == "A")
                    {
                        e.Row.Style.Add("background-color", "darkseagreen");
                    }
                    if (Actiontaken == "Y" || Actiontaken == "A")
                    {
                        AMachineCost = AMachineCost + Convert.ToDecimal(MachineCost);
                    }
                    else
                    {
                        e.Row.Style.Add("background-color", "darkkhaki");
                        NAMachineCost = NAMachineCost + Convert.ToDecimal(MachineCost);
                    }
                }

                lblTotalValueofAvailabile.InnerText = AMachineCost.ToString();
                lblTotalValueofNonAvailabile.InnerText = NAMachineCost.ToString();

                lblTotalValueMachinery.InnerText = (AMachineCost + NAMachineCost).ToString();
            }
            catch (Exception ex)
            {

            }
        }
        protected void gvEquipments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    string Actiontaken = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "EqipmentAvailability"));
                    string EqpCost = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DLORecommendedEqipmentCost"));
                    Label lblEqipmentAvailability = (e.Row.FindControl("lblEqipmentAvailability") as Label);
                    if (Actiontaken == "A")
                    {
                        e.Row.Style.Add("background-color", "darkseagreen");
                        lblEqipmentAvailability.Text = "Equipment in Running Condition but DLO Recommended Modified Amount";
                    }
                    if (Actiontaken == "Y")
                    {
                        lblEqipmentAvailability.Text = "Yes";
                    }
                    if (Actiontaken == "Y" || Actiontaken == "A")
                    {
                        AEqpCost = AEqpCost + Convert.ToDecimal(EqpCost);
                    }
                    else
                    {
                        e.Row.Style.Add("background-color", "darkkhaki");
                        NAEqpCost = NAEqpCost + Convert.ToDecimal(EqpCost);
                        lblEqipmentAvailability.Text = "No";
                    }
                }

                lblTotalValueofAvailabileEq.InnerText = AEqpCost.ToString();
                lblTotalValueofNonAvailabileEq.InnerText = NAEqpCost.ToString();
                lblTotalValueEquipment.InnerText = (AEqpCost + NAEqpCost).ToString();
            }
            catch (Exception ex)
            {

            }
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
        public void BindEquipments(int IncentiveId)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = GetEquipmentsDetails(IncentiveId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvEquipments.DataSource = ds.Tables[0];
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
        public DataSet GetEquipmentsDetails(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_Equipment_DTLS", pp);
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
                e.Row.Cells[7].Text = "Total";
                e.Row.Cells[8].Text = InterestAmountPaid.ToString();
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
                if (DataBinder.Eval(e.Row.DataItem, "DLORecommendedInterest").ToString() != "" && DataBinder.Eval(e.Row.DataItem, "DLORecommendedInterest").ToString() != null)
                {
                    decimal DLORecommendedInterest1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DLORecommendedInterest"));
                    DLORecommendedInterest = DLORecommendedInterest1 + DLORecommendedInterest;
                }
                
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[10].Text = "Total";
                e.Row.Cells[11].Text = EligibleInterest.ToString();
                e.Row.Cells[12].Text = DLORecommendedInterest.ToString();
            }
        }
    }
}