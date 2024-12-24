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
    public partial class frmDraftApplication : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
            ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

            string incentiveID = "0";
            if (Session["IncentiveID"] != null)
            {
                incentiveID = Session["IncentiveID"].ToString();
            }
            else if (Request.QueryString["EntrpId"] != null && Request.QueryString["EntrpId"].ToString() != "")
            {
                incentiveID = Request.QueryString["EntrpId"].ToString();
            }

            BindApplicationDtls(ObjLoginNewvo.uid, incentiveID);

            if (incentiveID== "2063")
            {
                divPMRatio.Visible = true;
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
        public void BindApplicationDtls(string UserId, string IncentiveID)
        {
            hdnIncentiveId.Value = IncentiveID;
            DataSet ds = new DataSet();
            ds = GetapplicationDtls(UserId, IncentiveID);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                lblTSIPassUIDNumber.InnerHtml = ds.Tables[0].Rows[0]["Uid_NO"].ToString();
                lblCommonApplicationNumber.InnerHtml = ds.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                lblCategoryofUnit.InnerHtml = ds.Tables[0].Rows[0]["Category"].ToString();
                lblTypeofUnit.InnerHtml = ds.Tables[0].Rows[0]["TypeOfIndustryText"].ToString();

                if (ds.Tables[0].Rows[0]["TypeOfIndustryOldText"].ToString() != "")
                {
                    divIndustryTSIPASS.Visible = true;
                    lblTypeofUnitTsipassold.InnerHtml = ds.Tables[0].Rows[0]["TypeOfIndustryOldText"].ToString();
                }

                rblCaste.InnerHtml = ds.Tables[0].Rows[0]["SocialStatusText"].ToString();
                rblSector.InnerHtml = "Textiles";
                txtUnitName.InnerHtml = ds.Tables[0].Rows[0]["UnitName"].ToString();
                rdl_TypeofUnit.InnerHtml = ds.Tables[0].Rows[0]["TypeofTexttileText"].ToString();

                txtCountryofOrigin.InnerHtml = ds.Tables[0].Rows[0]["CountryOrigin"].ToString();
                txtDateOfIncorporation.InnerHtml = ds.Tables[0].Rows[0]["DateOfIncorporation"].ToString();
                txtIncorpRegistranNumber.InnerHtml = ds.Tables[0].Rows[0]["IncorpRegistranNumber"].ToString();

                txtTinNO.InnerHtml = ds.Tables[0].Rows[0]["TinNO"].ToString();
                txtPanNo.InnerHtml = ds.Tables[0].Rows[0]["PanNo"].ToString();
                txtEINIEMILNumber.InnerHtml = ds.Tables[0].Rows[0]["EIN_IEM_IL_Number"].ToString();
                txtEINIEMILDate.InnerHtml = ds.Tables[0].Rows[0]["EIN_IEM_IL_REG_DATE"].ToString();
                ddlOrgType.InnerHtml = ds.Tables[0].Rows[0]["ConstitutionUnit"].ToString();

                txtApplciantName.InnerHtml = ds.Tables[0].Rows[0]["ApplicantName"].ToString();
                ddlgender.InnerHtml = ds.Tables[0].Rows[0]["GenderText"].ToString();
                txtYearsOfExpinTexttile.InnerHtml = ds.Tables[0].Rows[0]["YearsOfExpinTexttile"].ToString();
                ddlDifferentlyabled.InnerHtml = ds.Tables[0].Rows[0]["IsDifferentlyAbledText"].ToString();

                ddlUnitstate.InnerHtml = ds.Tables[0].Rows[0]["State_Name"].ToString();
                ddlUnitDIst.InnerHtml = ds.Tables[0].Rows[0]["District_Name"].ToString();
                ddlUnitMandal.InnerHtml = ds.Tables[0].Rows[0]["Manda_lName"].ToString();
                ddlVillageunit.InnerHtml = ds.Tables[0].Rows[0]["Village_Name"].ToString();
                txtUnitHNO.InnerHtml = ds.Tables[0].Rows[0]["UnitHNO"].ToString();
                txtUnitStreet.InnerHtml = ds.Tables[0].Rows[0]["UnitStreet"].ToString();
                txtunitmobileno.InnerHtml = ds.Tables[0].Rows[0]["UnitMObileNo"].ToString();
                txtunitemailid.InnerHtml = ds.Tables[0].Rows[0]["UnitEmail"].ToString();

                string AdharNumber = ds.Tables[0].Rows[0]["AadharNumber"].ToString();
                txtadhar1.InnerHtml = AdharNumber;

                //Office District Binding 
                ddloffcstate.InnerHtml = ds.Tables[0].Rows[0]["OffState_Name"].ToString();
                if (ds.Tables[0].Rows[0]["OffcState"].ToString() == "31")
                {
                    ddlOffcDIst.InnerHtml = ds.Tables[0].Rows[0]["OffDistrict_Name"].ToString();
                    ddlOffcMandal.InnerHtml = ds.Tables[0].Rows[0]["OffManda_lName"].ToString();
                    ddlOffcVil.InnerHtml = ds.Tables[0].Rows[0]["OffVillage_Name"].ToString();
                }
                else
                {
                    ddlOffcDIst.InnerHtml = ds.Tables[0].Rows[0]["OffcOtherDist"].ToString();
                    ddlOffcMandal.InnerHtml = ds.Tables[0].Rows[0]["OffcOtherMandal"].ToString();
                    ddlOffcVil.InnerHtml = ds.Tables[0].Rows[0]["OffcOtherVillage"].ToString();
                }

                txtOffSurveyNo.InnerHtml = ds.Tables[0].Rows[0]["OffcHNO"].ToString();
                txtOffcStreet.InnerHtml = ds.Tables[0].Rows[0]["OffcStreet"].ToString();
                txtOffcMobileNO.InnerHtml = ds.Tables[0].Rows[0]["OffcMobileNO"].ToString();
                txtOffcEmail.InnerHtml = ds.Tables[0].Rows[0]["OffcEmail"].ToString();

                // Tab 2
                string TypeOfIndustry = ds.Tables[0].Rows[0]["TypeOfIndustry"].ToString();
                hdnTypeOfIndustry.Value = TypeOfIndustry;
                string TextileProcessName = ds.Tables[0].Rows[0]["TextileProcessName"].ToString();
                ddlindustryStatus(TypeOfIndustry.Trim().TrimStart().TrimEnd(), TextileProcessName);

                ddlTextileProcessType.InnerHtml = ds.Tables[0].Rows[0]["TextileProcessName"].ToString();

                if (TypeOfIndustry == "1")
                {
                    lblDCPdate.InnerText = ds.Tables[0].Rows[0]["DCP"].ToString();
                    trDCPExp.Visible = false;
                    GetFinancialYears(GetFromatedDateDDMMYYYY(ds.Tables[0].Rows[0]["DCP"].ToString()));
                }
                else
                {
                    lblDCPdate.InnerText = ds.Tables[0].Rows[0]["DCP"].ToString();
                    tdexistingunit.InnerHtml = "Commencement of Commercial Production of Exsting Unit";
                    lblDCPexpdate.InnerText = ds.Tables[0].Rows[0]["DCPExp"].ToString();
                    trDCPExp.Visible = true;
                    GetFinancialYears(GetFromatedDateDDMMYYYY(ds.Tables[0].Rows[0]["DCPExp"].ToString()));
                }

                txtGovermentOrderNumber.InnerHtml = ds.Tables[0].Rows[0]["GovermentOrderNumber"].ToString();
                txtGovermentOrderDate.InnerHtml = ds.Tables[0].Rows[0]["GovermentOrderDate"].ToString();
                lblTechnicalTextileType.InnerHtml = ds.Tables[0].Rows[0]["TechnicalTextile"].ToString();

                BindLineofActivityDtls(IncentiveID, "New");
                BindLineofActivityDtls(IncentiveID, "Exp");
                BindDirectorDtls(IncentiveID);

                txtAuthorisedPerson.InnerHtml = ds.Tables[0].Rows[0]["AuthorisedPerson"].ToString();
                ddlAuthorisedSignDesignation.InnerHtml = ds.Tables[0].Rows[0]["AuthorisedSignatoryDesignationText"].ToString();
                txtPanNoAuthorised.InnerHtml = ds.Tables[0].Rows[0]["Authorized_PAN_NO"].ToString();
                txtemailAuthorised.InnerHtml = ds.Tables[0].Rows[0]["Authorized_EmailId"].ToString();
                txtMobileNumberAuthorised.InnerHtml = ds.Tables[0].Rows[0]["Authorized_MobileNo"].ToString();
                txtCorrespondenceAddress.InnerHtml = ds.Tables[0].Rows[0]["Authorized_CorresponAdderess"].ToString();

                // TAB 3
                txtstaffMale.InnerHtml = ds.Tables[0].Rows[0]["ManagementStaffMale"].ToString();
                txtfemale.InnerHtml = ds.Tables[0].Rows[0]["ManagementStaffFemale"].ToString();
                txtsupermalecount.InnerHtml = ds.Tables[0].Rows[0]["SupervisoryMale"].ToString();
                txtsuperfemalecount.InnerHtml = ds.Tables[0].Rows[0]["SupervisoryFemale"].ToString();
                txtSkilledWorkersMale.InnerHtml = ds.Tables[0].Rows[0]["SkilledWorkersMale"].ToString();
                txtSkilledWorkersFemale.InnerHtml = ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString();
                txtSemiSkilledWorkersMale.InnerHtml = ds.Tables[0].Rows[0]["SemiSkilledWorkersMale"].ToString();
                txtSemiSkilledWorkersFemale.InnerHtml = ds.Tables[0].Rows[0]["SemiSkilledWorkersFemale"].ToString();

                txtstaffMaleNonLocal.InnerHtml = ds.Tables[0].Rows[0]["ManagementStaffMaleNonLocal"].ToString();
                txtfemaleNonLocal.InnerHtml = ds.Tables[0].Rows[0]["ManagementStaffFemaleNonLocal"].ToString();
                txtsupermalecountNonLocal.InnerHtml = ds.Tables[0].Rows[0]["SupervisoryMaleNonLocal"].ToString();
                txtsuperfemalecountNonLocal.InnerHtml = ds.Tables[0].Rows[0]["SupervisoryFemaleNonLocal"].ToString();
                txtSkilledWorkersMaleNonLocal.InnerHtml = ds.Tables[0].Rows[0]["SkilledWorkersMaleNonLocal"].ToString();
                txtSkilledWorkersFemaleNonLocal.InnerHtml = ds.Tables[0].Rows[0]["SkilledWorkersFemaleNonLocal"].ToString();
                txtSemiSkilledWorkersMaleNonLocal.InnerHtml = ds.Tables[0].Rows[0]["SemiSkilledWorkersMaleNonLocal"].ToString();
                txtSemiSkilledWorkersFemaleNonLocal.InnerHtml = ds.Tables[0].Rows[0]["SemiSkilledWorkersFemaleNonLocal"].ToString();

                txtEmpDirectLocalMaleOther.InnerHtml = ds.Tables[0].Rows[0]["EmpDirectLocalMaleOther"].ToString();
                txtEmpDirectLocalFemaleOther.InnerHtml = ds.Tables[0].Rows[0]["EmpDirectLocalFemaleOther"].ToString();
                txtEmpDirectNonLocalMaleOther.InnerHtml = ds.Tables[0].Rows[0]["EmpDirectNonLocalMaleOther"].ToString();
                txtEmpDirectNonLocalFemaleOther.InnerHtml = ds.Tables[0].Rows[0]["EmpDirectNonLocalFemaleOther"].ToString();

                CalculatationofEmployemnt("1");
                CalculatationofEmployemnt("2");
                CalculatationofEmployemnt("3");
                CalculatationofEmployemnt("4");
                CalculatationofEmployemnt("5");
                CalculatationofEmployemnt("6");
                CalculatationofEmployemnt("7");

                BindIndirectEmploymentDtls(IncentiveID);
                
                txtlandexisting.InnerHtml = ds.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString();
                txtlandcapacity.InnerHtml = ds.Tables[0].Rows[0]["ExpansionDiversificationLand"].ToString();
                txtlandpercentage.InnerHtml = ds.Tables[0].Rows[0]["LandFixedCapitalInvestPercentage"].ToString();

                txtbuildingexisting.InnerHtml = ds.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString();
                txtbuildingcapacity.InnerHtml = ds.Tables[0].Rows[0]["ExpDiversBuilding"].ToString();
                txtbuildingpercentage.InnerHtml = ds.Tables[0].Rows[0]["BuildingFixedCapitalInvestPercentage"].ToString();

                txtplantexisting.InnerHtml = ds.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString();
                txtplantcapacity.InnerHtml = ds.Tables[0].Rows[0]["ExpDiversPlantMachinery"].ToString();
                txtplantpercentage.InnerHtml = ds.Tables[0].Rows[0]["PlantMachFixedCapitalInvestPercentage"].ToString();

                CalculatationEnterprise1("1");
                CalculatationEnterprise1("2");
                CalculatationEnterprise1("3");

                txtcurrInvLandValue.InnerHtml = ds.Tables[0].Rows[0]["CurrentInvestmentLandvalue"].ToString();
                txtcurrInvBuldvalue.InnerHtml = ds.Tables[0].Rows[0]["CurrentInvestmentBuildingvalue"].ToString();
                txtcurrInvplantMechValue.InnerHtml = ds.Tables[0].Rows[0]["CurrentInvestmentplantMechValue"].ToString();
                txtcurrentInvothers.InnerHtml = ds.Tables[0].Rows[0]["CurrentInvestmentOtherValue"].ToString();

                txtExpansionLandValue.InnerHtml = ds.Tables[0].Rows[0]["ActualLandvalue"].ToString();
                txtExpansionBuildingValue.InnerHtml = ds.Tables[0].Rows[0]["ActualBuildingValue"].ToString();
                txtExpansionplantMechValue.InnerHtml = ds.Tables[0].Rows[0]["ActualPMValue"].ToString();
                txtExpansionInvothers.InnerHtml = ds.Tables[0].Rows[0]["ActualOtherValue"].ToString();

                CalculateCurrInvTot(TypeOfIndustry);

                string IsPowerApplicableValues = ds.Tables[0].Rows[0]["IsPowerApplicableValues"].ToString();
                //ddlIspowApplicable_SelectedIndexChanged(this, EventArgs.Empty);
                string IsWaterSourceApplicableValues = ds.Tables[0].Rows[0]["IsWaterSourceApplicableValues"].ToString();
                // ddlWaterSource_SelectedIndexChanged(this, EventArgs.Empty);
                if (IsPowerApplicableValues == "1")
                {
                    ddlIspowApplicable.InnerHtml = "Yes";
                }
                else
                {
                    ddlIspowApplicable.InnerHtml = "No";
                }

                if (IsWaterSourceApplicableValues == "1")
                {
                    ddlWaterSource.InnerHtml = "Yes";
                }
                else
                {
                    ddlWaterSource.InnerHtml = "No";
                }

                IspowApplicable(IsPowerApplicableValues, TypeOfIndustry.Trim().TrimStart().TrimEnd());
                ddlWaterSourceStatus(TypeOfIndustry.Trim().TrimStart().TrimEnd());

                if (IsPowerApplicableValues == "1")
                {
                    if (TypeOfIndustry == "1")
                    {
                        txtNewPowerUniqueID.InnerHtml = ds.Tables[0].Rows[0]["NewPowerUniqueID"].ToString();
                        txtNewPowerCompany.InnerHtml = ds.Tables[0].Rows[0]["NewPowerCompany"].ToString();

                        txtNewPowerReleaseDate.InnerHtml = ds.Tables[0].Rows[0]["NewPowerReleaseDate"].ToString();
                        txtPowerConnectedLoad.InnerHtml = ds.Tables[0].Rows[0]["NewConnectedLoad"].ToString();
                        txtNewContractedLoad.InnerHtml = ds.Tables[0].Rows[0]["NewContractedLoad"].ToString();
                        txtServiceRateUnit.InnerHtml = ds.Tables[0].Rows[0]["NewServiceRateUnit"].ToString();
                    }
                    else
                    {
                        txtExistingPowerUniqueID.InnerHtml = ds.Tables[0].Rows[0]["ExistingPowerUniqueID"].ToString();
                        txtExistingPowerCompany.InnerHtml = ds.Tables[0].Rows[0]["ExistingPowerCompany"].ToString();

                        txtExistingPowerReleaseDate.InnerHtml = ds.Tables[0].Rows[0]["ExistingPowerReleaseDate"].ToString();
                        txtExistingPowerConnectedLoad.InnerHtml = ds.Tables[0].Rows[0]["ExistingConnectedLoad"].ToString();
                        txtExistingContractedLoad.InnerHtml = ds.Tables[0].Rows[0]["ExistingContractedLoad"].ToString();
                        txtExistingRateUnit.InnerHtml = ds.Tables[0].Rows[0]["ExistingServiceRateUnit"].ToString();

                        txtExpanDiverPowerUniqueID.InnerHtml = ds.Tables[0].Rows[0]["ExpanDiverPowerUniqueID"].ToString();
                        txtExpanDiverPowerCompany.InnerHtml = ds.Tables[0].Rows[0]["ExpanDiverPowerCompany"].ToString();

                        txtExpanDiverPowerReleaseDate.InnerHtml = ds.Tables[0].Rows[0]["ExpanDiverPowerReleaseDate"].ToString();
                        txtExpanDiverPowerConnectedLoad.InnerHtml = ds.Tables[0].Rows[0]["ExpanDiverConnectedLoad"].ToString();
                        txtExpanDiverContractedLoad.InnerHtml = ds.Tables[0].Rows[0]["ExpanDiverContractedLoad"].ToString();
                        txtExpanDiverRateUnit.InnerHtml = ds.Tables[0].Rows[0]["ExpanServiceRateUnit"].ToString();
                    }
                }

                txtwaterSource.InnerHtml = ds.Tables[0].Rows[0]["waterSource"].ToString();
                txtwaterRequirement.InnerHtml = ds.Tables[0].Rows[0]["waterRequirement"].ToString();
                txtwaterRateperunit.InnerHtml = ds.Tables[0].Rows[0]["waterRateperunit"].ToString();
                lblNoofMachines.InnerHtml= ds.Tables[0].Rows[0]["TotalNoOfMachines"].ToString();
                lblMachinaryValue.InnerHtml= ds.Tables[0].Rows[0]["ActualPMValue"].ToString();

                /* BindPMabstractDtls(IncentiveID);
                 BindPandMGrid(0, Convert.ToInt32(IncentiveID), TypeOfIndustry);
                 BindGrossBlockPandMGrid(0, Convert.ToInt32(IncentiveID));

                 if (gvGrossblockPandM.Rows.Count > 0)
                 {
                     trGrosblockdetails.Visible = true;
                 }
                 else
                 {
                     trGrosblockdetails.Visible = false;
                 }
                 BindPMPaymentDtls(IncentiveID, TypeOfIndustry);*/
                // TAB 4

                txtTurnoverYear1.InnerHtml = ds.Tables[0].Rows[0]["TurnOver_1stYear"].ToString();
                txtTurnoverYear2.InnerHtml = ds.Tables[0].Rows[0]["TurnOver_2ndYear"].ToString();
                txtTurnoverYear3.InnerHtml = ds.Tables[0].Rows[0]["TurnOver_3rdYear"].ToString();
                txtEBITDAYear1.InnerHtml = ds.Tables[0].Rows[0]["EBITDA_1stYear"].ToString();
                txtEBITDAYear2.InnerHtml = ds.Tables[0].Rows[0]["EBITDA_2ndYear"].ToString();
                txtEBITDAYear3.InnerHtml = ds.Tables[0].Rows[0]["EBITDA_3rdYear"].ToString();
                txtNetworthYear1.InnerHtml = ds.Tables[0].Rows[0]["Networth_1stYear"].ToString();
                txtNetworthYear2.InnerHtml = ds.Tables[0].Rows[0]["Networth_2ndYear"].ToString();
                txtNetworthYear3.InnerHtml = ds.Tables[0].Rows[0]["Networth_3rdYear"].ToString();
                txtReservesYear1.InnerHtml = ds.Tables[0].Rows[0]["ReservesSurplus_1stYear"].ToString();
                txtReservesYear2.InnerHtml = ds.Tables[0].Rows[0]["ReservesSurplus_2ndYear"].ToString();
                txtReservesYear3.InnerHtml = ds.Tables[0].Rows[0]["ReservesSurplus_3rdYear"].ToString();
                txtShareCapitalYear1.InnerHtml = ds.Tables[0].Rows[0]["Share_Capital_1stYear"].ToString();
                txtShareCapitalYear2.InnerHtml = ds.Tables[0].Rows[0]["Share_Capital_2ndYear"].ToString();
                txtShareCapitalYear3.InnerHtml = ds.Tables[0].Rows[0]["Share_Capital_3rdYear"].ToString();

                lblProductionYear1.InnerHtml = ds.Tables[0].Rows[0]["ProductionYear1"].ToString();
                txtProductionQuantity1.InnerHtml = ds.Tables[0].Rows[0]["ProductionQuantity1"].ToString();
                txtProductionValue1.InnerHtml = ds.Tables[0].Rows[0]["ProductionValue1"].ToString();

                lblProductionYear2.InnerHtml = ds.Tables[0].Rows[0]["ProductionYear2"].ToString();
                txtProductionQuantity2.InnerHtml = ds.Tables[0].Rows[0]["ProductionQuantity2"].ToString();
                txtProductionValue2.InnerHtml = ds.Tables[0].Rows[0]["ProductionValue2"].ToString();

                lblProductionYear3.InnerHtml = ds.Tables[0].Rows[0]["ProductionYear3"].ToString();
                txtProductionQuantity3.InnerHtml = ds.Tables[0].Rows[0]["ProductionQuantity3"].ToString();
                txtProductionValue3.InnerHtml = ds.Tables[0].Rows[0]["ProductionValue3"].ToString();

                lblProductionQuantityTotal.InnerHtml = (Convert.ToDecimal(GetDecimalNullValue(txtProductionQuantity1.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(txtProductionQuantity2.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(txtProductionQuantity3.InnerHtml))).ToString();

                lblProductionValueTotal.InnerHtml = (Convert.ToDecimal(GetDecimalNullValue(txtProductionValue1.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(txtProductionValue2.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(txtProductionValue3.InnerHtml))).ToString();

                txtPromoterEquity.InnerHtml = ds.Tables[0].Rows[0]["PromotersEquity_MF"].ToString();
                txtInstitutionsEquity.InnerHtml = ds.Tables[0].Rows[0]["InstitutionEquity_MF"].ToString();
                txtTearmLoans.InnerHtml = ds.Tables[0].Rows[0]["TermsLoans_M"].ToString();
                txtMeansFinanceOthers.InnerHtml = ds.Tables[0].Rows[0]["Others_MF"].ToString();
                txtSeedCapital.InnerHtml = ds.Tables[0].Rows[0]["SeedCapital_MF"].ToString();
                txtSubsidyagencies.InnerHtml = ds.Tables[0].Rows[0]["SubsidyGrantsAgencies_MF"].ToString();

                string IsTermLoanAvailed = ds.Tables[0].Rows[0]["IsTermLoanAvailed"].ToString();
                if (IsTermLoanAvailed == "1")
                {
                    tblTermLoanDtls.Visible = true;
                    ddlIsTermLoanAvailed.InnerHtml = "Yes";
                    BindTearmLoanDtls(IncentiveID);
                }
                else
                {
                    ddlIsTermLoanAvailed.InnerHtml = "No";
                    tblTermLoanDtls.Visible = false;
                }

                txtLand2.InnerHtml = ds.Tables[0].Rows[0]["LandApprovedProjectCost"].ToString();
                txtLand3.InnerHtml = ds.Tables[0].Rows[0]["LandLoanSactioned"].ToString();
                txtLand4.InnerHtml = ds.Tables[0].Rows[0]["LandPromotersEquity"].ToString();
                txtLand5.InnerHtml = ds.Tables[0].Rows[0]["LandLoanAmountReleased"].ToString();
                txtLand6.InnerHtml = ds.Tables[0].Rows[0]["LandAssetsValuebyFinInstitution"].ToString();
                txtLand7.InnerHtml = ds.Tables[0].Rows[0]["LandAssetsValuebyCA"].ToString();
                txtBuilding2.InnerHtml = ds.Tables[0].Rows[0]["BuildingApprovedProjectCost"].ToString();
                txtBuilding3.InnerHtml = ds.Tables[0].Rows[0]["BuildingLoanSactioned"].ToString();
                txtBuilding4.InnerHtml = ds.Tables[0].Rows[0]["BuildingPromotersEquity"].ToString();
                txtBuilding5.InnerHtml = ds.Tables[0].Rows[0]["BuildingLoanAmountReleased"].ToString();
                txtBuilding6.InnerHtml = ds.Tables[0].Rows[0]["BuildingAssetsValuebyFinInstitution"].ToString();
                txtBuilding7.InnerHtml = ds.Tables[0].Rows[0]["BuildingAssetsValuebyCA"].ToString();
                txtPM2.InnerHtml = ds.Tables[0].Rows[0]["PlantMachineryApprovedProjectCost"].ToString();
                txtPM3.InnerHtml = ds.Tables[0].Rows[0]["PlantMachineryLoanSactioned"].ToString();
                txtPM4.InnerHtml = ds.Tables[0].Rows[0]["PlantMachineryPromotersEquity"].ToString();
                txtPM5.InnerHtml = ds.Tables[0].Rows[0]["PlantMachineryLoanAmountReleased"].ToString();
                txtPM6.InnerHtml = ds.Tables[0].Rows[0]["PlantMachineryAssetsValuebyFinInstitution"].ToString();
                txtPM7.InnerHtml = ds.Tables[0].Rows[0]["PlantMachineryAssetsValuebyCA"].ToString();
                txtMCont2.InnerHtml = ds.Tables[0].Rows[0]["MachineryContingenciesApprovedProjectCost"].ToString();
                txtMCont3.InnerHtml = ds.Tables[0].Rows[0]["MachineryContingenciesLoanSactioned"].ToString();
                txtMCont4.InnerHtml = ds.Tables[0].Rows[0]["MachineryContingenciesPromotersEquity"].ToString();
                txtMCont5.InnerHtml = ds.Tables[0].Rows[0]["MachineryContingenciesLoanAmountReleased"].ToString();
                txtMCont6.InnerHtml = ds.Tables[0].Rows[0]["MachineryContingenciesAssetsValuebyFinInstitution"].ToString();
                txtMCont7.InnerHtml = ds.Tables[0].Rows[0]["MachineryContingenciesAssetsValuebyCA"].ToString();
                txtErec2.InnerHtml = ds.Tables[0].Rows[0]["ErectionApprovedProjectCost"].ToString();
                txtErec3.InnerHtml = ds.Tables[0].Rows[0]["ErectionLoanSactioned"].ToString();
                txtErec4.InnerHtml = ds.Tables[0].Rows[0]["ErectionPromotersEquity"].ToString();
                txtErec5.InnerHtml = ds.Tables[0].Rows[0]["ErectionLoanAmountReleased"].ToString();
                txtErec6.InnerHtml = ds.Tables[0].Rows[0]["ErectionAssetsValuebyFinInstitution"].ToString();
                txtErec7.InnerHtml = ds.Tables[0].Rows[0]["ErectionAssetsValuebyCA"].ToString();
                txtTFS2.InnerHtml = ds.Tables[0].Rows[0]["TechnicalfeasibilityApprovedProjectCost"].ToString();
                txtTFS3.InnerHtml = ds.Tables[0].Rows[0]["TechnicalfeasibilityLoanSactioned"].ToString();
                txtTFS4.InnerHtml = ds.Tables[0].Rows[0]["TechnicalfeasibilityPromotersEquity"].ToString();
                txtTFS5.InnerHtml = ds.Tables[0].Rows[0]["TechnicalfeasibilityLoanAmountReleased"].ToString();
                txtTFS6.InnerHtml = ds.Tables[0].Rows[0]["TechnicalfeasibilityAssetsValuebyFinInstitution"].ToString();
                txtTFS7.InnerHtml = ds.Tables[0].Rows[0]["TechnicalfeasibilityAssetsValuebyCA"].ToString();
                txtWC2.InnerHtml = ds.Tables[0].Rows[0]["WorkingCapitalApprovedProjectCost"].ToString();
                txtWC3.InnerHtml = ds.Tables[0].Rows[0]["WorkingCapitalLoanSactioned"].ToString();
                txtWC4.InnerHtml = ds.Tables[0].Rows[0]["WorkingCapitalPromotersEquity"].ToString();
                txtWC5.InnerHtml = ds.Tables[0].Rows[0]["WorkingCapitalLoanAmountReleased"].ToString();
                txtWC6.InnerHtml = ds.Tables[0].Rows[0]["WorkingCapitalAssetsValuebyFinInstitution"].ToString();
                txtWC7.InnerHtml = ds.Tables[0].Rows[0]["WorkingCapitalAssetsValuebyCA"].ToString();

                CalculateInvSanctionTermloan("1");
                CalculateInvSanctionTermloan("2");
                CalculateInvSanctionTermloan("3");
                CalculateInvSanctionTermloan("4");
                CalculateInvSanctionTermloan("5");
                CalculateInvSanctionTermloan("6");


                // TAB 5


                ddlBank.InnerHtml = ds.Tables[0].Rows[0]["TBMBankName"].ToString();
                txtBranchName.InnerHtml = ds.Tables[0].Rows[0]["BranchName"].ToString();
                txtAccNumber.InnerHtml = ds.Tables[0].Rows[0]["AccNo"].ToString();
                txtIfscCode.InnerHtml = ds.Tables[0].Rows[0]["IFSCCode"].ToString();
                txtAccountName.InnerHtml = ds.Tables[0].Rows[0]["BankAccountName"].ToString();
                ddlAccountType.InnerHtml = ds.Tables[0].Rows[0]["AccountTypeName"].ToString();
                txtaccountauthorizedPerson.InnerHtml = ds.Tables[0].Rows[0]["AccountauthorizedPerson"].ToString();
                txtaccountauthorizedPersonDesignation.InnerHtml = ds.Tables[0].Rows[0]["DesignationOfAccountauthorizedPerson"].ToString();

                GetIncetiveAttachements(IncentiveID, "Y");
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
                    tblTermLoanDtls.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void IspowApplicable(string IspowApplicableSelectedValue, string IndustryIspowApplicable)
        {
            if (IspowApplicableSelectedValue == "2")
            {
                trpower.Visible = false;
                tblpower1.Visible = false;
                tblpower1A.Visible = false;
                tblpower1B.Visible = false;
                tblpower1C.Visible = false;
                tblpower2.Visible = false;
                tblpower2A.Visible = false;
                tblpower2B.Visible = false;
                tblpower2C.Visible = false;
                tblpower2D.Visible = false;

                tblpower3.Visible = false;
                tblpower3A.Visible = false;
                tblpower3B.Visible = false;
                tblpower3C.Visible = false;
                tblpower3D.Visible = false;
            }
            else if (IspowApplicableSelectedValue == "1")
            {
                if (IndustryIspowApplicable == "1")
                {
                    trpowerSpace.Visible = true;
                    trpower.Visible = true;
                    tblpower1.Visible = true;
                    tblpower1A.Visible = true;
                    tblpower1B.Visible = true;
                    tblpower1C.Visible = true;

                    tblpower2.Visible = false;
                    tblpower2A.Visible = false;
                    tblpower2B.Visible = false;
                    tblpower2C.Visible = false;
                    tblpower2D.Visible = false;

                    tblpower3.Visible = false;
                    tblpower3A.Visible = false;
                    tblpower3B.Visible = false;
                    tblpower3C.Visible = false;
                    tblpower3D.Visible = false;
                }
                if (IndustryIspowApplicable == "2" || IndustryIspowApplicable == "3" || IndustryIspowApplicable == "4")
                {
                    trpower.Visible = false;
                    tblpower1.Visible = false;
                    tblpower1A.Visible = false;
                    tblpower1B.Visible = false;
                    tblpower1C.Visible = false;

                    tblpower2.Visible = true;
                    tblpower2A.Visible = true;
                    tblpower2B.Visible = true;
                    tblpower2C.Visible = true;
                    tblpower2D.Visible = true;

                    tblpower3.Visible = true;
                    tblpower3A.Visible = true;
                    tblpower3B.Visible = true;
                    tblpower3C.Visible = true;
                    tblpower3D.Visible = true;
                }

            }
        }
        protected void ddlWaterSourceStatus(string SelectedValue)
        {
            if (SelectedValue == "2")
            {
                DivWater.Visible = false;
                TrWater1.Visible = false;
                TrWater2.Visible = false;
            }
            if (SelectedValue == "1")
            {
                DivWater.Visible = true;
                TrWater1.Visible = true;
                TrWater2.Visible = true;
            }
        }
        protected void ddlindustryStatus(string SelectedValue, string TextileProcessName)
        {
            try
            {
                if (SelectedValue == "1")
                {
                    lblIndustryHeading.InnerHtml = "New Enterprise Product Details : ";

                    trNewIndustry.Visible = true;
                    trexpansionnew.Visible = false;
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

                    thApprovedProjectCost.InnerHtml = "New Enterprise Value (in Rs.)";

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
                    lblIndustryHeading.InnerHtml = "Existing Enterprise Product Details : ";
                    lblexpansionnewHeading.InnerHtml = "Expansion of Enterprise Product Details";

                    trNewIndustry.Visible = true;
                    trexpansionnew.Visible = true;


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
                    lblexistingpower.InnerHtml = "Power Details - Existing Enterprise production details";
                    lblexpandiverpower.InnerHtml = "Power Details - " + lblTypeofUnit.InnerHtml;

                    thApprovedProjectCost.InnerHtml = "Existing Enterprise Value (in Rs.)";
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
                    lblIndustryHeading.InnerHtml = "Existing Enterprise Product Details : ";
                    lblexpansionnewHeading.InnerHtml = TextileProcessName + " of Enterprise Product Details";
                    trNewIndustry.Visible = true;

                    trexpansionnew.Visible = true;

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

                    lblexistingpower.InnerHtml = "Power Details - Existing Enterprise production details";
                    lblexpandiverpower.InnerHtml = "Power Details - " + lblTypeofUnit.InnerHtml;

                    thApprovedProjectCost.InnerHtml = "Existing Enterprise Value (in Rs.)";
                    trFixedCapitalexpansion.InnerHtml = lblTypeofUnit.InnerHtml + " Enterprise Value (in Rs.)";
                    trFixedCapitalexpnPercent.InnerHtml = "% of Increase Under " + lblTypeofUnit.InnerHtml;

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

                    thExpansionActual.InnerHtml = lblTypeofUnit.InnerHtml + " Enterprise Value (in Rs.)";
                    trActualCapitalexpnPercent.InnerHtml = "% of Increase Under " + lblTypeofUnit.InnerHtml ;
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

        protected void BindLineofActivityDtls(string INCENTIVEID, string LOAType)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetLineofActivityDtls(INCENTIVEID, LOAType);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    if (LOAType == "New")
                    {
                        GvLineOfactivityDetails.DataSource = dsnew.Tables[0];
                        GvLineOfactivityDetails.DataBind();
                    }
                    else
                    {
                        GvLineOfactivityExpnsionDetails.DataSource = dsnew.Tables[0];
                        GvLineOfactivityExpnsionDetails.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void BindDirectorDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetDirectorDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    GvPartnerDetails.DataSource = dsnew.Tables[0];
                    GvPartnerDetails.DataBind();
                }
                else
                {
                    GvPartnerDetails.DataSource = null;
                    GvPartnerDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetLineofActivityDtls(string INCENTIVEID, string LOAType)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@LOAType",SqlDbType.VarChar),
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = LOAType;
            pp[1].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_INCENTIVE_LOA_DTLS", pp);
            return Dsnew;
        }
        public DataSet GetDirectorDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_DIRECTOR_PARTNER_DTLS", pp);
            return Dsnew;
        }
        public DataSet GetIndirectEmploymentDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_INCENTIVE_INDIRECTEMP_DTLS", pp);
            return Dsnew;
        }
        public void BindPandMGrid(int PMId, int IncentiveId,string TypeOfIndustry)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = GetPandM(PMId, IncentiveId, TypeOfIndustry);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdPandM.DataSource = ds.Tables[0];
                    grdPandM.DataBind();

                    grdPandM2.DataSource = ds.Tables[0];
                    grdPandM2.DataBind();

                    grdPandM3.DataSource = ds.Tables[0];
                    grdPandM3.DataBind();
                    decimal TotalValueofNewMachinery = 0, Secondhandmachinery = 0;
                    decimal TotalValueofTextileProducts = 0, TotalValueofNonTextileProducts = 0, TotalValueofAllTextileProducts;

                    foreach (GridViewRow gvrow in grdPandM3.Rows)
                    {
                        string Value = (gvrow.FindControl("lblMachineCost") as Label).Text;
                        string lblInstalledMachineryText = (gvrow.FindControl("lblInstalledMachineryText") as Label).Text;
                        if (lblInstalledMachineryText.ToUpper() == "NEW")
                        {
                            TotalValueofNewMachinery = TotalValueofNewMachinery + Convert.ToDecimal(GetDecimalNullValue(Value));
                        }
                        else
                        {
                            Secondhandmachinery = Secondhandmachinery + Convert.ToDecimal(GetDecimalNullValue(Value));
                        }

                        //

                        string lblClassificationofMachinery = (gvrow.FindControl("lblClassificationofMachinery") as Label).Text;
                        if (lblClassificationofMachinery.ToUpper().Contains("NON TEXTILE PRODUCTS"))
                        {
                            TotalValueofNonTextileProducts = TotalValueofNonTextileProducts + Convert.ToDecimal(GetDecimalNullValue(Value));
                        }
                        else if (lblClassificationofMachinery.ToUpper().Contains("TEXTILE PRODUCTS"))
                        {
                            TotalValueofTextileProducts = TotalValueofTextileProducts + Convert.ToDecimal(GetDecimalNullValue(Value));
                        }

                    }

                    lblTotalValueofNewMachinery.InnerHtml = TotalValueofNewMachinery.ToString();
                    lblSecondhandmachinery.InnerHtml = Secondhandmachinery.ToString();


                    lblTotalValueofTextileProducts.InnerHtml = TotalValueofTextileProducts.ToString();
                    lblTotalValueofNonTextileProducts.InnerHtml = TotalValueofNonTextileProducts.ToString();

                    lblTotalValueofAllTextileProducts.InnerHtml = (TotalValueofTextileProducts + TotalValueofNonTextileProducts).ToString();
                    TotalValueofAllTextileProducts = (TotalValueofTextileProducts + TotalValueofNonTextileProducts);

                    if (TotalValueofTextileProducts > 0)
                    {
                        lblValueofTextileProductsPercentage.InnerHtml = (Convert.ToDecimal(Convert.ToDecimal(TotalValueofTextileProducts / TotalValueofAllTextileProducts) * Convert.ToDecimal(100.00))).ToString("#.##");
                    }
                    else
                    {
                        lblValueofTextileProductsPercentage.InnerHtml = "0";
                    }
                    if (TotalValueofNonTextileProducts > 0)
                    {
                        lblValueofNonTextileProductsPercentage.InnerHtml = (Convert.ToDecimal(Convert.ToDecimal(TotalValueofNonTextileProducts / TotalValueofAllTextileProducts) * Convert.ToDecimal(100.00))).ToString("#.##");
                    }
                    else
                    {
                        lblValueofNonTextileProductsPercentage.InnerHtml = "0";
                    }
                }
                else
                {
                    trpmdetails.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetPandM(int PMId, int IncentiveId,string TypeOfIndustry)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@PMId",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = PMId;
            if (TypeOfIndustry == "1")
            {
                Dsnew = ObjCAFClass.GenericFillDs("USP_GET_PLANTANDMACHINERY", pp);
            }
            else
            {
                Dsnew = ObjCAFClass.GenericFillDs("USP_GET_PLANTANDMACHINERY_ExistingUnit", pp);
            }
            return Dsnew;
        }
        public string GetDecimalNullValue(string Input)
        {
            string InputValue = "";

            InputValue = (Input != "") ? Input : "0";

            return InputValue;
        }
        protected void BindIndirectEmploymentDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetIndirectEmploymentDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    DivIndirectEmp.Visible = true;
                    gvIndirectEmployment.DataSource = dsnew.Tables[0];
                    gvIndirectEmployment.DataBind();
                }
                else
                {
                    DivIndirectEmp.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void CalculatationofEmployemnt(string Step)
        {
            try
            {
                decimal ManagementStaffDirectMale = 0, SupervisoryDirectMale = 0, SkilledworkersDirectMale = 0, SemiskilledworkersDirectMale = 0, EmpDirectLocalMaleOther = 0;
                decimal ManagementStaffDirectMaleNonLocal = 0, SupervisoryDirectMaleNonLocal = 0, SkilledworkersDirectMaleNonLocal = 0, SemiskilledworkersDirectMaleNonLocal = 0, EmpDirectNonLocalMaleOther = 0;

                decimal ManagementStaffDirectFeMale = 0, SupervisoryDirectFeMale = 0, SkilledworkersDirectFeMale = 0, SemiskilledworkersDirectFeMale = 0, EmpDirectLocalFemaleOther = 0;
                decimal ManagementStaffDirectFeMaleNonLocal = 0, SupervisoryDirectFeMaleNonLocal = 0, SkilledworkersDirectFeMaleNonLocal = 0, SemiskilledworkersDirectFeMaleNonLocal = 0, EmpDirectNonLocalFemaleOther = 0;

                decimal FinalTotal = 0;
                if (Step == "1")
                {
                    if (txtstaffMale.InnerHtml != "")
                    {
                        ManagementStaffDirectMale = Convert.ToDecimal(txtstaffMale.InnerHtml.Trim());
                    }
                    else
                    {
                        ManagementStaffDirectMale = 0;
                    }

                    if (txtsupermalecount.InnerHtml != "")
                    {
                        SupervisoryDirectMale = Convert.ToDecimal(txtsupermalecount.InnerHtml.Trim());
                    }
                    else
                    {
                        SupervisoryDirectMale = 0;
                    }

                    if (txtSkilledWorkersMale.InnerHtml != "")
                    {
                        SkilledworkersDirectMale = Convert.ToDecimal(txtSkilledWorkersMale.InnerHtml.Trim());
                    }
                    else
                    {
                        SkilledworkersDirectMale = 0;
                    }

                    if (txtSemiSkilledWorkersMale.InnerHtml != "")
                    {
                        SemiskilledworkersDirectMale = Convert.ToDecimal(txtSemiSkilledWorkersMale.InnerHtml.Trim());
                    }
                    else
                    {
                        SemiskilledworkersDirectMale = 0;
                    }

                    if (txtEmpDirectLocalMaleOther.InnerHtml != "")
                    {
                        EmpDirectLocalMaleOther = Convert.ToDecimal(txtEmpDirectLocalMaleOther.InnerHtml.Trim());
                    }
                    else
                    {
                        EmpDirectLocalMaleOther = 0;
                    }

                    FinalTotal = ManagementStaffDirectMale + SupervisoryDirectMale + SkilledworkersDirectMale + SemiskilledworkersDirectMale + EmpDirectLocalMaleOther;
                    lblDirectMale.Text = FinalTotal.ToString();
                }
                else if (Step == "2")
                {
                    if (txtfemale.InnerHtml != "")
                    {
                        ManagementStaffDirectFeMale = Convert.ToDecimal(txtfemale.InnerHtml.Trim());
                    }
                    else
                    {
                        ManagementStaffDirectFeMale = 0;
                    }
                    if (txtsuperfemalecount.InnerHtml != "")
                    {
                        SupervisoryDirectFeMale = Convert.ToDecimal(txtsuperfemalecount.InnerHtml.Trim());
                    }
                    else
                    {
                        SupervisoryDirectFeMale = 0;
                    }
                    if (txtSkilledWorkersFemale.InnerHtml != "")
                    {
                        SkilledworkersDirectFeMale = Convert.ToDecimal(txtSkilledWorkersFemale.InnerHtml.Trim());
                    }
                    else
                    {
                        SkilledworkersDirectFeMale = 0;
                    }
                    if (txtSemiSkilledWorkersFemale.InnerHtml != "")
                    {
                        SemiskilledworkersDirectFeMale = Convert.ToDecimal(txtSemiSkilledWorkersFemale.InnerHtml.Trim());
                    }
                    else
                    {
                        SemiskilledworkersDirectFeMale = 0;
                    }

                    if (txtEmpDirectLocalFemaleOther.InnerHtml != "")
                    {
                        EmpDirectLocalFemaleOther = Convert.ToDecimal(txtEmpDirectLocalFemaleOther.InnerHtml.Trim());
                    }
                    else
                    {
                        EmpDirectLocalFemaleOther = 0;
                    }

                    FinalTotal = ManagementStaffDirectFeMale + SupervisoryDirectFeMale + SkilledworkersDirectFeMale + SemiskilledworkersDirectFeMale + EmpDirectLocalFemaleOther;
                    lblDirectFeMale.Text = FinalTotal.ToString();
                }
                else if (Step == "5")
                {
                    if (txtstaffMaleNonLocal.InnerHtml != "")
                    {
                        ManagementStaffDirectMaleNonLocal = Convert.ToDecimal(txtstaffMaleNonLocal.InnerHtml.Trim());
                    }
                    else
                    {
                        ManagementStaffDirectMaleNonLocal = 0;
                    }
                    if (txtsupermalecountNonLocal.InnerHtml != "")
                    {
                        SupervisoryDirectMaleNonLocal = Convert.ToDecimal(txtsupermalecountNonLocal.InnerHtml.Trim());
                    }
                    else
                    {
                        SupervisoryDirectMaleNonLocal = 0;
                    }
                    if (txtSkilledWorkersMaleNonLocal.InnerHtml != "")
                    {
                        SkilledworkersDirectMaleNonLocal = Convert.ToDecimal(txtSkilledWorkersMaleNonLocal.InnerHtml.Trim());
                    }
                    else
                    {
                        SkilledworkersDirectMaleNonLocal = 0;
                    }
                    if (txtSemiSkilledWorkersMaleNonLocal.InnerHtml != "")
                    {
                        SemiskilledworkersDirectMaleNonLocal = Convert.ToDecimal(txtSemiSkilledWorkersMaleNonLocal.InnerHtml.Trim());
                    }
                    else
                    {
                        SemiskilledworkersDirectMaleNonLocal = 0;
                    }

                    if (txtEmpDirectNonLocalMaleOther.InnerHtml != "")
                    {
                        EmpDirectNonLocalMaleOther = Convert.ToDecimal(txtEmpDirectNonLocalMaleOther.InnerHtml.Trim());
                    }
                    else
                    {
                        EmpDirectNonLocalMaleOther = 0;
                    }

                    FinalTotal = ManagementStaffDirectMaleNonLocal + SupervisoryDirectMaleNonLocal + SkilledworkersDirectMaleNonLocal + SemiskilledworkersDirectMaleNonLocal + EmpDirectNonLocalMaleOther;
                    lblDirectMaleNonLocal.Text = FinalTotal.ToString();

                }
                else if (Step == "6")
                {
                    if (txtfemaleNonLocal.InnerHtml != "")
                    {
                        ManagementStaffDirectFeMaleNonLocal = Convert.ToDecimal(txtfemaleNonLocal.InnerHtml.Trim());
                    }
                    else
                    {
                        ManagementStaffDirectFeMaleNonLocal = 0;
                    }
                    if (txtsuperfemalecountNonLocal.InnerHtml != "")
                    {
                        SupervisoryDirectFeMaleNonLocal = Convert.ToDecimal(txtsuperfemalecountNonLocal.InnerHtml.Trim());
                    }
                    else
                    {
                        SupervisoryDirectFeMaleNonLocal = 0;
                    }
                    if (txtSkilledWorkersFemaleNonLocal.InnerHtml != "")
                    {
                        SkilledworkersDirectFeMaleNonLocal = Convert.ToDecimal(txtSkilledWorkersFemaleNonLocal.InnerHtml.Trim());
                    }
                    else
                    {
                        SkilledworkersDirectFeMaleNonLocal = 0;
                    }

                    if (txtSemiSkilledWorkersFemaleNonLocal.InnerHtml != "")
                    {
                        SemiskilledworkersDirectFeMaleNonLocal = Convert.ToDecimal(txtSemiSkilledWorkersFemaleNonLocal.InnerHtml.Trim());
                    }
                    else
                    {
                        SemiskilledworkersDirectFeMaleNonLocal = 0;
                    }

                    if (txtEmpDirectNonLocalFemaleOther.InnerHtml != "")
                    {
                        EmpDirectNonLocalFemaleOther = Convert.ToDecimal(txtEmpDirectNonLocalFemaleOther.InnerHtml.Trim());
                    }
                    else
                    {
                        EmpDirectNonLocalFemaleOther = 0;
                    }

                    FinalTotal = ManagementStaffDirectFeMaleNonLocal + SupervisoryDirectFeMaleNonLocal + SkilledworkersDirectFeMaleNonLocal + SemiskilledworkersDirectFeMaleNonLocal + EmpDirectNonLocalFemaleOther;
                    lblDirectFeMaleNonLocal.Text = FinalTotal.ToString();
                }
                else if (Step == "7")
                {
                    lblDirectStaffTotal.InnerHtml = (Convert.ToInt32(GetDecimalNullValue(txtstaffMale.InnerHtml)) + Convert.ToInt32(GetDecimalNullValue(txtfemale.InnerHtml))).ToString();
                    lblInDirectStaffTotal.InnerHtml = (Convert.ToInt32(GetDecimalNullValue(txtstaffMaleNonLocal.InnerHtml)) + Convert.ToInt32(GetDecimalNullValue(txtfemaleNonLocal.InnerHtml))).ToString();
                    lblStaffgrandTotal.InnerHtml = (Convert.ToInt32(GetDecimalNullValue(lblDirectStaffTotal.InnerHtml)) + Convert.ToInt32(GetDecimalNullValue(lblInDirectStaffTotal.InnerHtml))).ToString();

                    lblDirectSupervisoryTotal.InnerHtml = (Convert.ToInt32(GetDecimalNullValue(txtsupermalecount.InnerHtml)) + Convert.ToInt32(GetDecimalNullValue(txtsuperfemalecount.InnerHtml))).ToString();
                    lblInDirectSupervisoryTotal.InnerHtml = (Convert.ToInt32(GetDecimalNullValue(txtsupermalecountNonLocal.InnerHtml)) + Convert.ToInt32(GetDecimalNullValue(txtsuperfemalecountNonLocal.InnerHtml))).ToString();
                    lblSupervisoryGrandTotal.InnerHtml = (Convert.ToInt32(GetDecimalNullValue(lblDirectSupervisoryTotal.InnerHtml)) + Convert.ToInt32(GetDecimalNullValue(lblInDirectSupervisoryTotal.InnerHtml))).ToString();

                    lblDirectSkilledworkersTotal.InnerHtml = (Convert.ToInt32(GetDecimalNullValue(txtSkilledWorkersMale.InnerHtml)) + Convert.ToInt32(GetDecimalNullValue(txtSkilledWorkersFemale.InnerHtml))).ToString();
                    lblInDirectSkilledworkersTotal.InnerHtml = (Convert.ToInt32(GetDecimalNullValue(txtSkilledWorkersMaleNonLocal.InnerHtml)) + Convert.ToInt32(GetDecimalNullValue(txtSkilledWorkersFemaleNonLocal.InnerHtml))).ToString();
                    lblSkilledworkersGrandTotal.InnerHtml = (Convert.ToInt32(GetDecimalNullValue(lblDirectSkilledworkersTotal.InnerHtml)) + Convert.ToInt32(GetDecimalNullValue(lblInDirectSkilledworkersTotal.InnerHtml))).ToString();

                    lblDirectSemiSkilledworkersTotal.InnerHtml = (Convert.ToInt32(GetDecimalNullValue(txtSemiSkilledWorkersMale.InnerHtml)) + Convert.ToInt32(GetDecimalNullValue(txtSemiSkilledWorkersFemale.InnerHtml))).ToString();
                    lblInDirectSemiSkilledworkersTotal.InnerHtml = (Convert.ToInt32(GetDecimalNullValue(txtSemiSkilledWorkersMaleNonLocal.InnerHtml)) + Convert.ToInt32(GetDecimalNullValue(txtSemiSkilledWorkersFemaleNonLocal.InnerHtml))).ToString();
                    lblSemiSkilledworkersGrandTotal.InnerHtml = (Convert.ToInt32(GetDecimalNullValue(lblDirectSemiSkilledworkersTotal.InnerHtml)) + Convert.ToInt32(GetDecimalNullValue(lblInDirectSemiSkilledworkersTotal.InnerHtml))).ToString();

                    lblDirectUnSkilledworkersTotal.InnerHtml = (Convert.ToInt32(GetDecimalNullValue(txtEmpDirectLocalMaleOther.InnerHtml)) + Convert.ToInt32(GetDecimalNullValue(txtEmpDirectLocalFemaleOther.InnerHtml))).ToString();
                    lblInDirectUnSkilledworkersTotal.InnerHtml = (Convert.ToInt32(GetDecimalNullValue(txtEmpDirectNonLocalMaleOther.InnerHtml)) + Convert.ToInt32(GetDecimalNullValue(txtEmpDirectNonLocalFemaleOther.InnerHtml))).ToString();
                    lblUnSkilledworkersGrandTotal.InnerHtml = (Convert.ToInt32(GetDecimalNullValue(lblDirectUnSkilledworkersTotal.InnerHtml)) + Convert.ToInt32(GetDecimalNullValue(lblInDirectUnSkilledworkersTotal.InnerHtml))).ToString();

                    lblDirectGrandTotal.InnerHtml = (Convert.ToInt32(GetDecimalNullValue(lblDirectMale.Text)) + Convert.ToInt32(GetDecimalNullValue(lblDirectFeMale.Text))).ToString();
                    lblInDirectGrandTotal.InnerHtml = (Convert.ToInt32(GetDecimalNullValue(lblDirectMaleNonLocal.Text)) + Convert.ToInt32(GetDecimalNullValue(lblDirectFeMaleNonLocal.Text))).ToString();
                    lblgrandemptotal.InnerHtml = (Convert.ToInt32(GetDecimalNullValue(lblDirectGrandTotal.InnerHtml)) + Convert.ToInt32(GetDecimalNullValue(lblInDirectGrandTotal.InnerHtml))).ToString();
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
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
                    lblnewinv.Text = PlantMachValFinal.ToString();
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
                    lblexpinv.Text = PlantMachValFinal.ToString();
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

                    PlantMachValFinal = Convert.ToDecimal((landcapacityPer + buildingcapacityPer + PlantMachValPer + OthernewPer) / 3);

                    lbltotperinv.Text = PlantMachValFinal.ToString("#.##");
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }

        public void CalculateInvSanctionTermloan(string Step)
        {
            try
            {
                decimal FinalTotal = 0;
                decimal Land2 = 0, Building2 = 0, PM2 = 0, MCont2 = 0, Erec2 = 0, TFS2 = 0, WC2 = 0;
                if (Step == "1")
                {
                    if (txtLand2.InnerHtml != "") { Land2 = Convert.ToDecimal(txtLand2.InnerHtml.Trim()); } else { Land2 = 0; }
                    if (txtBuilding2.InnerHtml != "") { Building2 = Convert.ToDecimal(txtBuilding2.InnerHtml.Trim()); } else { Building2 = 0; }
                    if (txtPM2.InnerHtml != "") { PM2 = Convert.ToDecimal(txtPM2.InnerHtml.Trim()); } else { PM2 = 0; }
                    if (txtMCont2.InnerHtml != "") { MCont2 = Convert.ToDecimal(txtMCont2.InnerHtml.Trim()); } else { MCont2 = 0; }
                    if (txtErec2.InnerHtml != "") { Erec2 = Convert.ToDecimal(txtErec2.InnerHtml.Trim()); } else { Erec2 = 0; }
                    if (txtTFS2.InnerHtml != "") { TFS2 = Convert.ToDecimal(txtTFS2.InnerHtml.Trim()); } else { TFS2 = 0; }
                    if (txtWC2.InnerHtml != "") { WC2 = Convert.ToDecimal(txtWC2.InnerHtml.Trim()); } else { WC2 = 0; }
                    FinalTotal = Land2 + Building2 + PM2 + MCont2 + Erec2 + TFS2 + WC2;
                    lbltotal2.Text = FinalTotal.ToString();
                }
                else if (Step == "2")
                {
                    decimal Land3 = 0, Building3 = 0, PM3 = 0, MCont3 = 0, Erec3 = 0, TFS3 = 0, WC3 = 0;
                    if (txtLand3.InnerHtml != "") { Land3 = Convert.ToDecimal(txtLand3.InnerHtml.Trim()); } else { Land3 = 0; }
                    if (txtBuilding3.InnerHtml != "") { Building3 = Convert.ToDecimal(txtBuilding3.InnerHtml.Trim()); } else { Building3 = 0; }
                    if (txtPM3.InnerHtml != "") { PM3 = Convert.ToDecimal(txtPM3.InnerHtml.Trim()); } else { PM3 = 0; }
                    if (txtMCont3.InnerHtml != "") { MCont3 = Convert.ToDecimal(txtMCont3.InnerHtml.Trim()); } else { MCont3 = 0; }
                    if (txtErec3.InnerHtml != "") { Erec3 = Convert.ToDecimal(txtErec3.InnerHtml.Trim()); } else { Erec3 = 0; }
                    if (txtTFS3.InnerHtml != "") { TFS3 = Convert.ToDecimal(txtTFS3.InnerHtml.Trim()); } else { TFS3 = 0; }
                    if (txtWC3.InnerHtml != "") { WC3 = Convert.ToDecimal(txtWC3.InnerHtml.Trim()); } else { WC3 = 0; }
                    FinalTotal = Land3 + Building3 + PM3 + MCont3 + Erec3 + TFS3 + WC3;
                    lbltotal3.Text = FinalTotal.ToString();
                }
                else if (Step == "3")
                {
                    decimal Land4 = 0, Building4 = 0, PM4 = 0, MCont4 = 0, Erec4 = 0, TFS4 = 0, WC4 = 0;
                    if (txtLand4.InnerHtml != "") { Land4 = Convert.ToDecimal(txtLand4.InnerHtml.Trim()); } else { Land4 = 0; }
                    if (txtBuilding4.InnerHtml != "") { Building4 = Convert.ToDecimal(txtBuilding4.InnerHtml.Trim()); } else { Building4 = 0; }
                    if (txtPM4.InnerHtml != "") { PM4 = Convert.ToDecimal(txtPM4.InnerHtml.Trim()); } else { PM4 = 0; }
                    if (txtMCont4.InnerHtml != "") { MCont4 = Convert.ToDecimal(txtMCont4.InnerHtml.Trim()); } else { MCont4 = 0; }
                    if (txtErec4.InnerHtml != "") { Erec4 = Convert.ToDecimal(txtErec4.InnerHtml.Trim()); } else { Erec4 = 0; }
                    if (txtTFS4.InnerHtml != "") { TFS4 = Convert.ToDecimal(txtTFS4.InnerHtml.Trim()); } else { TFS4 = 0; }
                    if (txtWC4.InnerHtml != "") { WC4 = Convert.ToDecimal(txtWC4.InnerHtml.Trim()); } else { WC4 = 0; }
                    FinalTotal = Land4 + Building4 + PM4 + MCont4 + Erec4 + TFS4 + WC4;
                    lbltotal4.Text = FinalTotal.ToString();
                }
                else if (Step == "4")
                {
                    decimal Land5 = 0, Building5 = 0, PM5 = 0, MCont5 = 0, Erec5 = 0, TFS5 = 0, WC5 = 0;
                    if (txtLand5.InnerHtml != "") { Land5 = Convert.ToDecimal(txtLand5.InnerHtml.Trim()); } else { Land5 = 0; }
                    if (txtBuilding5.InnerHtml != "") { Building5 = Convert.ToDecimal(txtBuilding5.InnerHtml.Trim()); } else { Building5 = 0; }
                    if (txtPM5.InnerHtml != "") { PM5 = Convert.ToDecimal(txtPM5.InnerHtml.Trim()); } else { PM5 = 0; }
                    if (txtMCont5.InnerHtml != "") { MCont5 = Convert.ToDecimal(txtMCont5.InnerHtml.Trim()); } else { MCont5 = 0; }
                    if (txtErec5.InnerHtml != "") { Erec5 = Convert.ToDecimal(txtErec5.InnerHtml.Trim()); } else { Erec5 = 0; }
                    if (txtTFS5.InnerHtml != "") { TFS5 = Convert.ToDecimal(txtTFS5.InnerHtml.Trim()); } else { TFS5 = 0; }
                    if (txtWC5.InnerHtml != "") { WC5 = Convert.ToDecimal(txtWC5.InnerHtml.Trim()); } else { WC5 = 0; }
                    FinalTotal = Land5 + Building5 + PM5 + MCont5 + Erec5 + TFS5 + WC5;
                    lbltotal5.Text = FinalTotal.ToString();
                }
                else if (Step == "5")
                {
                    decimal Land6 = 0, Building6 = 0, PM6 = 0, MCont6 = 0, Erec6 = 0, TFS6 = 0, WC6 = 0;
                    if (txtLand6.InnerHtml != "") { Land6 = Convert.ToDecimal(txtLand6.InnerHtml.Trim()); } else { Land6 = 0; }
                    if (txtBuilding6.InnerHtml != "") { Building6 = Convert.ToDecimal(txtBuilding6.InnerHtml.Trim()); } else { Building6 = 0; }
                    if (txtPM6.InnerHtml != "") { PM6 = Convert.ToDecimal(txtPM6.InnerHtml.Trim()); } else { PM6 = 0; }
                    if (txtMCont6.InnerHtml != "") { MCont6 = Convert.ToDecimal(txtMCont6.InnerHtml.Trim()); } else { MCont6 = 0; }
                    if (txtErec6.InnerHtml != "") { Erec6 = Convert.ToDecimal(txtErec6.InnerHtml.Trim()); } else { Erec6 = 0; }
                    if (txtTFS6.InnerHtml != "") { TFS6 = Convert.ToDecimal(txtTFS6.InnerHtml.Trim()); } else { TFS6 = 0; }
                    if (txtWC6.InnerHtml != "") { WC6 = Convert.ToDecimal(txtWC6.InnerHtml.Trim()); } else { WC6 = 0; }
                    FinalTotal = Land6 + Building6 + PM6 + MCont6 + Erec6 + TFS6 + WC6;
                    lbltotal6.Text = FinalTotal.ToString();
                }
                else if (Step == "6")
                {
                    decimal Land7 = 0, Building7 = 0, PM7 = 0, MCont7 = 0, Erec7 = 0, TFS7 = 0, WC7 = 0;
                    if (txtLand7.InnerHtml != "") { Land7 = Convert.ToDecimal(txtLand7.InnerHtml.Trim()); } else { Land7 = 0; }
                    if (txtBuilding7.InnerHtml != "") { Building7 = Convert.ToDecimal(txtBuilding7.InnerHtml.Trim()); } else { Building7 = 0; }
                    if (txtPM7.InnerHtml != "") { PM7 = Convert.ToDecimal(txtPM7.InnerHtml.Trim()); } else { PM7 = 0; }
                    if (txtMCont7.InnerHtml != "") { MCont7 = Convert.ToDecimal(txtMCont7.InnerHtml.Trim()); } else { MCont7 = 0; }
                    if (txtErec7.InnerHtml != "") { Erec7 = Convert.ToDecimal(txtErec7.InnerHtml.Trim()); } else { Erec7 = 0; }
                    if (txtTFS7.InnerHtml != "") { TFS7 = Convert.ToDecimal(txtTFS7.InnerHtml.Trim()); } else { TFS7 = 0; }
                    if (txtWC7.InnerHtml != "") { WC7 = Convert.ToDecimal(txtWC7.InnerHtml.Trim()); } else { WC7 = 0; }
                    FinalTotal = Land7 + Building7 + PM7 + MCont7 + Erec7 + TFS7 + WC7;
                    lbltotal7.Text = FinalTotal.ToString();
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }

        }

        protected void btnInstalledcap_Click(object sender, EventArgs e)
        {
            UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
            ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

            if (ObjLoginNewvo.userlevel == "13")
            {
                Response.Redirect("~/UI/UserDashBoard.aspx");
            }
            else
            {
                Response.Redirect("~/UI/frmDashBoard.aspx");
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
        public void GetFinancialYears(string Date)
        {
            DataSet dsFinancialYears = new DataSet();
            dsFinancialYears = ObjCAFClass.GetFinancialYears(Date);

            if (dsFinancialYears != null && dsFinancialYears.Tables.Count > 0 && dsFinancialYears.Tables[0].Rows.Count > 2)
            {
                thYear1.InnerHtml = dsFinancialYears.Tables[0].Rows[0]["FinancialYear"].ToString();
                thYear2.InnerHtml = dsFinancialYears.Tables[0].Rows[1]["FinancialYear"].ToString();
                thYear3.InnerHtml = dsFinancialYears.Tables[0].Rows[2]["FinancialYear"].ToString();
            }
        }

        public DataSet GetPMabstractDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_INCENTIVE_PMAbstract_DTLS", pp);
            return Dsnew;
        }
        protected void BindPMabstractDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetPMabstractDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    gvPMAbstract.DataSource = dsnew.Tables[0];
                    gvPMAbstract.DataBind();
                }
                if (dsnew != null && dsnew.Tables.Count > 1 && dsnew.Tables[1].Rows.Count > 0)
                {
                    lbltotalMachinaries.InnerHtml = dsnew.Tables[1].Rows[0]["TOTALTypeOfMachinery"].ToString();
                    lblTotalMachines.InnerHtml = dsnew.Tables[1].Rows[0]["TOTALNoofmachines"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void GetIncetiveAttachements(string IncentiveId, string CAFFLAG)
        {
            DataSet dsnew1 = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentveID",SqlDbType.Int),
                new SqlParameter("@CAFFLAG",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = CAFFLAG;
            dsnew1 = ObjCAFClass.GenericFillDs("[USP_GET_ALLINCENTIVES_APPLICANT_DRAFT]", pp);

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

                    string Category = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Category"));
                    if (Category.Trim().TrimStart() != "")
                    {
                        lbl.Text = Category.Trim().TrimStart();
                        e.Row.Font.Bold = true;
                    }

                   
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                //lblmsg0.Text = "Internal error has occured. Please try after some time";
                // lblmsg0.Text = ex.Message;
                //Failure.Visible = true;
                // LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
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
                    txtExpansionLandPer.InnerHtml = ((float)System.Math.Round((ExpansionLandValue / currInvLandValue)*100,2)).ToString();// ("#.##");
                    if (txtExpansionLandPer.InnerHtml == "∞" || txtExpansionLandPer.InnerHtml =="0")
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

        public void BindGrossBlockPandMGrid(int GBId, int IncentiveId)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = GetGrossBlockPandM(GBId, IncentiveId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvGrossblockPandM.DataSource = ds.Tables[0];
                    gvGrossblockPandM.DataBind();
                    trGrosblockdetails.Visible = true;
                }
                else
                {
                    gvGrossblockPandM.DataSource = ds.Tables[0];
                    gvGrossblockPandM.DataBind();
                    trGrosblockdetails.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetGrossBlockPandM(int GBId, int IncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@GBId",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = GBId;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_PM_GROSSBLOCK_DTLS", pp);
            return Dsnew;
        }

        public DataSet GetPMPaymentDtls(string INCENTIVEID, string TransType)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar),
               new SqlParameter("@TransType",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            pp[1].Value = TransType;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_PMPAYMENT_DTLS", pp);
            return Dsnew;
        }
        protected void BindPMPaymentDtls(string INCENTIVEID, string TransType)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetPMPaymentDtls(INCENTIVEID, TransType);
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    trPMPaymentDetails.Visible = true;
                    GvPMPaymentDtls.DataSource = dsnew.Tables[0];
                    GvPMPaymentDtls.DataBind();
                }
                else
                {
                    trPMPaymentDetails.Visible = false;
                    GvPMPaymentDtls.DataSource = null;
                    GvPMPaymentDtls.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            BindPMabstractDtls(hdnIncentiveId.Value.ToString());
            BindPandMGrid(0, Convert.ToInt32(hdnIncentiveId.Value.ToString()), hdnTypeOfIndustry.Value);
            BindGrossBlockPandMGrid(0, Convert.ToInt32(hdnIncentiveId.Value.ToString()));

            if (gvGrossblockPandM.Rows.Count > 0)
            {
                trGrosblockdetails.Visible = true;
            }
            else
            {
                trGrosblockdetails.Visible = false;
            }
            BindPMPaymentDtls(hdnIncentiveId.Value.ToString(), hdnTypeOfIndustry.Value);
            divMachinary.Visible = true;
            trShowMachine.Visible = false;
        }
    }
}