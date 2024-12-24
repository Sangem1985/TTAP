using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class IncentiveFormDraftView : System.Web.UI.Page
    {
        General objGen = new General();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string IncentiveId = Session["IncentiveID"].ToString();// Request.QueryString["IncentiveId"].ToString(); // 38207;
                string createdby = Session["uid"].ToString();//Request.QueryString["uid"].ToString(); //17083;

                GetCAFdetails(Convert.ToInt32(IncentiveId) , Convert.ToInt32(createdby));
            }
        }

        public void GetCAFdetails(int IncentiveId, int createdby)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = objGen.GetCAFdetails_DB(IncentiveId, createdby);

                if (dt != null && dt.Rows.Count > 0)
                {
                    lblNameEnterprise.Text = dt.Rows[0]["UnitName"].ToString();
                    lblNameEnterprise.Text = dt.Rows[0]["UnitName"].ToString();
                    lblCountryofOrigin.Text = dt.Rows[0]["CountryOrigin"].ToString();
                    lblNewPlotArea.Text = dt.Rows[0]["UnitStreet"].ToString() + " " + dt.Rows[0]["UnitHNO"].ToString();
                    lblNewCityTownVillage.Text = dt.Rows[0]["UnitVill"].ToString();
                    lblNewDistrict.Text = dt.Rows[0]["UnitDIst"].ToString();
                    lblNewState.Text = dt.Rows[0]["UnitState"].ToString();
                    lblCorrespondencePlotNoArea.Text = dt.Rows[0]["OffcHNO"].ToString() + " " + dt.Rows[0]["OffcStreet"].ToString();
                    lblCorrespondenceCityTownVillage.Text = dt.Rows[0]["OffcVill"].ToString();
                    lblCorrespondenceDistrict.Text = dt.Rows[0]["OffcDIst"].ToString();
                    lblCorrespondenceState.Text = dt.Rows[0]["OffcState"].ToString();
                    lblCorrespondencePhoneNumber.Text = dt.Rows[0]["OffcMobileNO"].ToString();
                    lblCorrespondenceTextileProcessType.Text = dt.Rows[0]["TextileProcessType"].ToString();
                    lblCorrespondenceEmailAddress.Text = dt.Rows[0]["OffcEmail"].ToString();
                    lblDateofIncorporation.Text = dt.Rows[0]["DateOfIncorporation"].ToString();
                    lblIncorporationRegistrationNumber.Text = dt.Rows[0]["IncorpRegistranNumber"].ToString();
                    lblNewGSTRegistrationNumber.Text = dt.Rows[0]["GSTNO"].ToString();
                    lblNewPANandTANNumber.Text = dt.Rows[0]["PanNo"].ToString();
                    lblNewSocialStatus.Text = dt.Rows[0]["SocialStatus"].ToString();
                    lblFirstName.Text = dt.Rows[0]["ApplciantName"].ToString();
                    lblDesignationCompany.Text = dt.Rows[0]["AuthorisedSignatoryDesignation"].ToString();
                    lblPhoneNumber.Text = dt.Rows[0]["UnitMObileNo"].ToString();
                    lblMobileNumber.Text = dt.Rows[0]["OffcMobileNO"].ToString();
                    lblEmailAddress.Text = dt.Rows[0]["OffcEmail"].ToString();
                    lblEducationalQualification.Text = dt.Rows[0]["EducationalQual"].ToString();
                    lblExperienceTextiles.Text = dt.Rows[0]["YearsOfExpinTexttile"].ToString();
                    lblFirstName2.Text = dt.Rows[0]["ApplciantName"].ToString();
                    lblDesignationCompany2.Text = dt.Rows[0]["AuthorisedSignatoryDesignation"].ToString();
                    lblCorrespondenceAddress.Text = dt.Rows[0]["Authorized_CorresponAdderess"].ToString();
                    lblPhoneNumbe2.Text = dt.Rows[0]["Authorized_MobileNo"].ToString();
                    lblEmailAddress2.Text = dt.Rows[0]["Authorized_EmailId"].ToString();
                    lblPANNumber2.Text = dt.Rows[0]["Authorized_PAN_NO"].ToString();
                    lblYearofEstablishment.Text = dt.Rows[0]["EstablishmentYear"].ToString();
                    lblNumberofEmployees.Text = dt.Rows[0]["NumberofEmployees"].ToString();
                    lblProductsManufactured.Text = dt.Rows[0]["Products_Manufactured"].ToString();
                    lblExistingEstablishments.Text = dt.Rows[0]["NO_OtherEstablishments"].ToString();
                    lblNatureIndustry.Text = dt.Rows[0]["Nature_Industry"].ToString();
                    lblGSTRegistrationNumber.Text = dt.Rows[0]["GSTNO"].ToString();
                    lblSocialStatus.Text = dt.Rows[0]["SocialStatus"].ToString();
                    lblFactoryBuildingConstructed.Text = dt.Rows[0]["PlinthArea"].ToString();
                    lblNewRateperAcre.Text = dt.Rows[0]["RateperAcre"].ToString();
                    lblNewTotalInvestmentLand.Text = dt.Rows[0]["TotalInvestment"].ToString();
                    lblBuildipArea1.Text = dt.Rows[0]["ExistEnterpriseBuilding"].ToString();
                    lblBuildipArea2.Text = dt.Rows[0]["ExpDiversBuilding"].ToString();
                    lblBuildipArea3.Text = dt.Rows[0]["BuildingFixedCapitalInvestPercentage"].ToString();
                    lblInfrastructure1.Text = dt.Rows[0]["Infrastructure1"].ToString();
                    lblInfrastructure2.Text = dt.Rows[0]["Infrastructure2"].ToString();
                    lblInfrastructure3.Text = dt.Rows[0]["Infrastructure3"].ToString();
                    lblOtherProductive1.Text = dt.Rows[0]["OtherProductive1"].ToString();
                    lblOtherProductive2.Text = dt.Rows[0]["OtherProductive2"].ToString();
                    lblOtherProductive3.Text = dt.Rows[0]["OtherProductive3"].ToString();
                    lblTotalInvestmentBuilding.Text = dt.Rows[0]["TotalInvestmentBuilding"].ToString();
                    lblPlantmachinery.Text = dt.Rows[0]["ExistEnterprisePlantMachinery"].ToString();
                    lblTransportation.Text = dt.Rows[0]["Transportation"].ToString();
                    lblErection.Text = dt.Rows[0]["Erection"].ToString();
                    lblElectrification.Text = dt.Rows[0]["Electrification"].ToString();
                    lblOtherAssets.Text = dt.Rows[0]["OtherAssets"].ToString();
                    lblTotalInvestmentPlant.Text = dt.Rows[0]["TotalPlantMechinery"].ToString();
                    lblTotalFixedCapitalInvestment.Text = dt.Rows[0]["TotalCapitalInvestment"].ToString();
                    lblMale1.Text = dt.Rows[0]["ManagementStaffMale"].ToString();
                    lblfemale1.Text = dt.Rows[0]["ManagementStaffFemale"].ToString();
                    lblMale2.Text = dt.Rows[0]["SupervisoryMale"].ToString();
                    lblfemale2.Text = dt.Rows[0]["SupervisoryFemale"].ToString();
                    lblMale3.Text = dt.Rows[0]["SkilledWorkersMale"].ToString();
                    lblfemale3.Text = dt.Rows[0]["SkilledWorkersFemale"].ToString();
                    lblMale4.Text = dt.Rows[0]["SemiSkilledWorkersMale"].ToString();
                    lblfemale4.Text = dt.Rows[0]["SemiSkilledWorkersFemale"].ToString();
                    lblPromoterEquity.Text = dt.Rows[0]["LandPromotersEquity"].ToString();
                    lblInstitutionEquity.Text = dt.Rows[0]["InstitutionEquity_MF"].ToString();
                    lblFinanceOthers.Text = dt.Rows[0]["Others_MF"].ToString();
                    lblSeedCapital.Text = dt.Rows[0]["SeedCapital_MF"].ToString();
                    lblSubsidyGrants.Text = dt.Rows[0]["SubsidyGrantsAgencies_MF"].ToString();
                    lblNameBank.Text = dt.Rows[0]["BankName"].ToString();
                    lblTermLoanSanctionDate.Text = dt.Rows[0]["TermloanSandate"].ToString();
                    //lblReleaseDate.Text = dt.Rows[0]["TermLoanReleaseddate"].ToString();
                    lblContractedLoad.Text = dt.Rows[0]["NewConnectedLoad"].ToString();
                    lblRateperunitRupees.Text = dt.Rows[0]["PowNewContractUnit"].ToString();
                    lblSource.Text = dt.Rows[0]["Source"].ToString();
                    lblRequirement.Text = dt.Rows[0]["Requirement"].ToString();
                    lblWaterRateperunitRupees.Text = dt.Rows[0]["RateperUnit"].ToString();
                    lblSubsidies.Text = dt.Rows[0]["IsSubsidiesIncentives"].ToString();
                    IfYesAmount.Text = dt.Rows[0]["IsSubsidiesIncentivesAmount"].ToString();
                    lblNameoftheScheme.Text = dt.Rows[0]["NameoftheScheme"].ToString();
                    lblExistingState.Text = dt.Rows[0]["UnitState"].ToString();
                    lblExistingNatureofIndustry.Text = dt.Rows[0]["Nature_Industry"].ToString();
                    //lblLineofActivity1.Text = dt.Rows[0]["LineOfActivity"].ToString();
                    //lblInstalledCapacity1.Text = dt.Rows[0]["InstalledCapacity"].ToString();
                    lblpercentageIncrease1.Text = dt.Rows[0]["ExistingPercentageincreaseunderExpansionORDiversification"].ToString();
                    //lblLineofActivity2.Text = dt.Rows[0]["LineOfActivity"].ToString();
                    //lblInstalledCapacity2.Text = dt.Rows[0]["InstalledCapacity"].ToString();
                    lblpercentageIncrease2.Text = dt.Rows[0]["ExistingPercentageincreaseunderExpansionORDiversification"].ToString();
                    lblExpansionBuildipArea1.Text = dt.Rows[0]["ExistEnterpriseBuilding"].ToString();
                    lblExpansionBuildipArea2.Text = dt.Rows[0]["ExpDiversBuilding"].ToString();
                    lblExpansionBuildipArea3.Text = dt.Rows[0]["BuildingFixedCapitalInvestPercentage"].ToString();
                    lblExpansionInfrastructure1.Text = dt.Rows[0]["Infrastructure1"].ToString();
                    lblExpansionInfrastructure2.Text = dt.Rows[0]["Infrastructure2"].ToString();
                    lblExpansionInfrastructure3.Text = dt.Rows[0]["Infrastructure3"].ToString();
                    lblExpansionOtherProductive1.Text = dt.Rows[0]["OtherProductive1"].ToString();
                    lblExpansionOtherProductive2.Text = dt.Rows[0]["OtherProductive2"].ToString();
                    lblExpansionOtherProductive3.Text = dt.Rows[0]["OtherProductive3"].ToString();
                    lblExpansionTotalInvestmentBuilding.Text = dt.Rows[0]["TotalInvestmentBuilding"].ToString();
                    lblExpansionPlantmachinery.Text = dt.Rows[0]["ExistEnterprisePlantMachinery"].ToString();
                    lblExpansionTransportation.Text = dt.Rows[0]["Transportation"].ToString();
                    lblExpansionErection.Text = dt.Rows[0]["Erection"].ToString();
                    lblExpansionElectrification.Text = dt.Rows[0]["Electrification"].ToString();
                    lblExpansionOtherAssets.Text = dt.Rows[0]["OtherAssets"].ToString();
                    lblExpansionTotalInvestmentPlant.Text = dt.Rows[0]["TotalPlantMechinery"].ToString();
                    lblExpansionTotalFixedCapitalInvestment.Text = dt.Rows[0]["TotalCapitalInvestment"].ToString();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}