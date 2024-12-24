using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class Application : System.Web.UI.Page
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
        }

        public void BindApplicationDtls(string userid, string incentiveid)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = viewapplication(userid, incentiveid);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //Session["IncentiveID"] = ds.Tables[0].Rows[0]["IncentiveID"].ToString();
                        //applicationStatus1 = ds.Tables[0].Rows[0]["intStatusid"].ToString();

                        // step1
                        if (ds.Tables[0].Rows[0]["Uid_NO"].ToString() != "")
                        {
                            lbl_TSIPassUIDNumber.Text = ds.Tables[0].Rows[0]["Uid_NO"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["SectorID"].ToString() != "")
                        {
                            lbl_TypeofSector.Text = "Textiles";
                            //ds.Tables[0].Rows[0]["SectorID"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["UnitName"].ToString() != "")
                        {
                            lbl_NameofTheEnterprise.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                        }
                        lbl_CountryofOrigin.Text = ds.Tables[0].Rows[0]["CountryOrigin"].ToString();
                        lbl_DateOfIncorporation.Text = ds.Tables[0].Rows[0]["DateOfIncorporation"].ToString();
                        lbl_IncorporationRegistrationNo.Text = ds.Tables[0].Rows[0]["IncorpRegistranNumber"].ToString();
                        if (ds.Tables[0].Rows[0]["TinNO"].ToString() != "")
                        {
                            lbl_GSTNumber.Text = ds.Tables[0].Rows[0]["TinNO"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["PanNo"].ToString() != "")
                        {
                            lbl_PANNumber.Text = ds.Tables[0].Rows[0]["PanNo"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["EIN_IEM_IL_Number"].ToString() != "")
                        {
                            lbl_EIN_IEM_ILNumber.Text = ds.Tables[0].Rows[0]["EIN_IEM_IL_Number"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["EIN_IEM_IL_REG_DATE"].ToString() != "")
                        {
                            lbl_date.Text = ds.Tables[0].Rows[0]["EIN_IEM_IL_REG_DATE"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["OrgType"].ToString() != "")
                        {
                            lbl_constitutionoforganization.Text = ds.Tables[0].Rows[0]["ConstitutionUnit"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["SocialStatus"].ToString() != "")
                        {
                            string caste = ""; string SubCaste = "";
                            if (Convert.ToString(ds.Tables[0].Rows[0]["SocialStatus"]) == "1")
                            {
                                lbl_SocialStatus.Text = "General";
                            }
                            else
                            {
                                if (Convert.ToString(ds.Tables[0].Rows[0]["SocialStatus"]) == "2")
                                {
                                    caste = "OBC";
                                }
                                if (Convert.ToString(ds.Tables[0].Rows[0]["SocialStatus"]) == "3")
                                {
                                    caste = "SC";
                                }
                                if (Convert.ToString(ds.Tables[0].Rows[0]["SocialStatus"]) == "4")
                                {
                                    caste = "ST";
                                }
                                if (Convert.ToString(ds.Tables[0].Rows[0]["SocialStatus"]) == "5")
                                {
                                    caste = "Minority";
                                }

                                if (Convert.ToString(ds.Tables[0].Rows[0]["SubCaste"]) == "1")
                                {
                                    SubCaste = "BC-A";
                                }
                                if (Convert.ToString(ds.Tables[0].Rows[0]["SubCaste"]) == "2")
                                {
                                    SubCaste = "BC-B";
                                }
                                if (Convert.ToString(ds.Tables[0].Rows[0]["SubCaste"]) == "3")
                                {
                                    SubCaste = "BC-C";
                                }
                                if (Convert.ToString(ds.Tables[0].Rows[0]["SubCaste"]) == "4")
                                {
                                    SubCaste = "BC-D";
                                }
                                if (Convert.ToString(ds.Tables[0].Rows[0]["SubCaste"]) == "5")
                                {
                                    SubCaste = "BC-E";
                                }
                                lbl_SocialStatus.Text = caste + "[" + SubCaste + "]";
                            }

                        }
                        if (ds.Tables[0].Rows[0]["ApplicantName"].ToString() != "")
                        {
                            lblApplicantName.Text = ds.Tables[0].Rows[0]["ApplicantName"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["Gender"].ToString() != "")
                        {
                            lbl_gender.Text = ds.Tables[0].Rows[0]["Gender"].ToString();
                        }
                        lbl_noofyearExpinTextiles.Text = ds.Tables[0].Rows[0]["YearsOfExpinTexttile"].ToString();

                        if (ds.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString() != "")
                        {
                            lbl_Physicallyhandicapped.Text = ds.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString();
                        }


                        if (ds.Tables[0].Rows[0]["UnitState"].ToString() != "")
                        {
                            lbl_RAEState.Text = ds.Tables[0].Rows[0]["UnitStatename"].ToString();
                        }

                        if (ds.Tables[0].Rows[0]["UnitDIst"].ToString() != "")
                        {
                            lbl_RAEDistrict.Text = ds.Tables[0].Rows[0]["UnitDIstname"].ToString();
                        }

                        if (ds.Tables[0].Rows[0]["UnitMandal"].ToString() != "")
                        {
                            lbl_RAEmandal.Text = ds.Tables[0].Rows[0]["UnitMandalname"].ToString();
                        }

                        if (ds.Tables[0].Rows[0]["UnitVill"].ToString() != "")
                        {
                            lbl_RAEVillage.Text = ds.Tables[0].Rows[0]["UnitVillname"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["UnitHNO"].ToString() != "")
                        {
                            lbl_RAEGrampanchayat_IE_IDA.Text = ds.Tables[0].Rows[0]["UnitHNO"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["UnitStreet"].ToString() != "")
                        {
                            lbl_RAESurveyPlotNo.Text = ds.Tables[0].Rows[0]["UnitStreet"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["UnitMObileNo"].ToString() != "")
                        {
                            lbl_RAEMobileNo.Text = ds.Tables[0].Rows[0]["UnitMObileNo"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["UnitEmail"].ToString() != "")
                        {
                            lbl_RAEEmailid.Text = ds.Tables[0].Rows[0]["UnitEmail"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["OffcState"].ToString() != "")
                        {
                            lbl_CAState.Text = ds.Tables[0].Rows[0]["OffcStatename"].ToString();
                        }
                        //Office District Binding 
                        if (ds.Tables[0].Rows[0]["OffcState"].ToString() != "")
                        {
                            lbl_CAState.Text = ds.Tables[0].Rows[0]["OffcStatename"].ToString();
                            if (ds.Tables[0].Rows[0]["OffcState"].ToString() == "31")
                            {


                                if (ds.Tables[0].Rows[0]["OffcDIst"].ToString() != "")
                                {
                                    lbl_CADistrict.Text = ds.Tables[0].Rows[0]["OffcDIstname"].ToString();
                                }
                                if (ds.Tables[0].Rows[0]["OffcMandal"].ToString() != "")
                                {
                                    lbl_CAMandal.Text = ds.Tables[0].Rows[0]["OffcMandalname"].ToString();
                                }
                                if (ds.Tables[0].Rows[0]["OffcVill"].ToString() != "")
                                {
                                    lbl_CAVillage.Text = ds.Tables[0].Rows[0]["OffcVillname"].ToString();
                                }
                            }
                            else
                            {
                                if (ds.Tables[0].Rows[0]["OffcOtherDist"].ToString() != "")
                                {
                                    lbl_CADistrict.Text = ds.Tables[0].Rows[0]["OffcOtherDist"].ToString();
                                }
                                if (ds.Tables[0].Rows[0]["OffcOtherMandal"].ToString() != "")
                                {
                                    lbl_CAMandal.Text = ds.Tables[0].Rows[0]["OffcOtherMandal"].ToString();
                                }
                                if (ds.Tables[0].Rows[0]["OffcOtherVillage"].ToString() != "")
                                {
                                    lbl_CAVillage.Text = ds.Tables[0].Rows[0]["OffcOtherVillage"].ToString();
                                }
                            }
                        }
                        if (ds.Tables[0].Rows[0]["OffcHNO"].ToString() != "")
                        {
                            lbl_CASurveyplotno.Text = ds.Tables[0].Rows[0]["OffcHNO"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["OffcStreet"].ToString() != "")
                        {
                            lbl_CAGrampanchayat_IE_IDA.Text = ds.Tables[0].Rows[0]["OffcStreet"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["OffcMobileNO"].ToString() != "")
                        {
                            lbl_CAMobileNo.Text = ds.Tables[0].Rows[0]["OffcMobileNO"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["OffcEmail"].ToString() != "")
                        {
                            lbl_CAEmailID.Text = ds.Tables[0].Rows[0]["OffcEmail"].ToString();
                        }

                        //  Tab 2 Bindings

                        if (ds.Tables[0].Rows[0]["TypeOfIndustry"].ToString() != "")
                        {
                            if (Convert.ToString(ds.Tables[0].Rows[0]["TypeOfIndustry"]) == "1")
                            {
                                lblhead_industryname.Text = "New Enterprise";
                                lbl_headexmoddivname.Text = "";
                                lbl_IndustryStatusName.Text = "New Industry";
                                div_projecrdetailsexpdivmod.Visible = false;
                                div_expan.Visible = false;
                                div_expandata.Visible = false;
                                div_existgriddata.Visible = false;
                                div_existingdata.Visible = false;
                                lbl_headofgridallindu.Text = "New Industry Product Details";
                            }
                            if (Convert.ToString(ds.Tables[0].Rows[0]["TypeOfIndustry"]) == "2")
                            {
                                lbl_IndustryStatusName.Text = "Expansion";
                                div_projecrdetailsexpdivmod.Visible = true;
                                lblhead_industryname.Text = "Existing Enterprise";
                                lbl_headexmoddivname.Text = "Expansion Enterprise";
                                div_projecrdetailsexpdivmod.Visible = true;
                                div_expan.Visible = true;
                                div_expandata.Visible = true;
                                div_existgriddata.Visible = true;
                                div_existingdata.Visible = true;
                                lbl_headofgridallindu.Text = "Expansion Enterprise Product Details";
                            }
                            if (Convert.ToString(ds.Tables[0].Rows[0]["TypeOfIndustry"]) == "3")
                            {
                                lbl_IndustryStatusName.Text = "Diversification";
                                div_projecrdetailsexpdivmod.Visible = true;
                                lblhead_industryname.Text = "Existing Enterprise";
                                lbl_headexmoddivname.Text = "Diversification Enterprise";
                                div_projecrdetailsexpdivmod.Visible = false;
                                div_expan.Visible = true;
                                div_expandata.Visible = true;
                                div_existgriddata.Visible = true;
                                div_existingdata.Visible = true;
                                lbl_headofgridallindu.Text = "Diversification Enterprise Product Details";
                            }
                            if (Convert.ToString(ds.Tables[0].Rows[0]["TypeOfIndustry"]) == "4")
                            {
                                lbl_IndustryStatusName.Text = "Modification";
                                div_projecrdetailsexpdivmod.Visible = true;
                                lblhead_industryname.Text = "Existing Enterprise";
                                lbl_headexmoddivname.Text = "Modification Enterprise";
                                div_projecrdetailsexpdivmod.Visible = false;
                                div_expan.Visible = true;
                                div_expandata.Visible = true;
                                div_existgriddata.Visible = true;
                                div_existingdata.Visible = true;
                                lbl_headofgridallindu.Text = "Modification Enterprise Product Details";
                            }
                        }
                        if (ds.Tables[0].Rows[0]["IndustryExpansionType"].ToString() != "")
                        {
                            if(Convert.ToString(ds.Tables[0].Rows[0]["IndustryExpansionType"]) =="1")
                            {
                                lbl_ExpanisionNatureOfIndustry.Text = "Expansion1";
                            }
                            if (Convert.ToString(ds.Tables[0].Rows[0]["IndustryExpansionType"]) == "2")
                            {
                                lbl_ExpanisionNatureOfIndustry.Text = "Expansion2";
                            }
                            if (Convert.ToString(ds.Tables[0].Rows[0]["IndustryExpansionType"]) == "3")
                            {
                                lbl_ExpanisionNatureOfIndustry.Text = "Expansion3";
                            }
                        }
               


                        if (ds.Tables[0].Rows[0]["DCP"].ToString() != "")
                        {
                            lbl_DateofCommencement.Text = ds.Tables[0].Rows[0]["DCP"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["DCPExp"].ToString() != "")
                        {
                            lbl_ExpansionEnterpriseDateofCommencement.Text = ds.Tables[0].Rows[0]["DCPExp"].ToString();
                        }

                        if (ds.Tables[0].Rows[0]["TextileProcessType"].ToString() != "")
                        {
                            if (Convert.ToString(ds.Tables[0].Rows[0]["TextileProcessType"]) == "1")
                            {
                                lbl_NatureOfIndustry.Text = "Ginning";
                            }
                            if (Convert.ToString(ds.Tables[0].Rows[0]["TextileProcessType"]) == "2")
                            {
                                lbl_NatureOfIndustry.Text = "Spinning";
                            }
                            if (Convert.ToString(ds.Tables[0].Rows[0]["TextileProcessType"]) == "3")
                            {
                                lbl_NatureOfIndustry.Text = "Weaving";
                            }
                            if (Convert.ToString(ds.Tables[0].Rows[0]["TextileProcessType"]) == "4")
                            {
                                lbl_NatureOfIndustry.Text = "Garmenting";
                            }
                        }
                        if (ds.Tables[0].Rows[0]["TextileProcessTypeExp"].ToString() != "")
                        {
                            if(Convert.ToString(ds.Tables[0].Rows[0]["TextileProcessTypeExp"])=="1")
                            {
                                lbl_ExpanisionNatureOfIndustry.Text = "Ginning";
                            }
                            if (Convert.ToString(ds.Tables[0].Rows[0]["TextileProcessTypeExp"]) == "2")
                            {
                                lbl_ExpanisionNatureOfIndustry.Text = "Spinning";
                            }
                            if (Convert.ToString(ds.Tables[0].Rows[0]["TextileProcessTypeExp"]) == "3")
                            {
                                lbl_ExpanisionNatureOfIndustry.Text = "Weaving";
                            }
                            if (Convert.ToString(ds.Tables[0].Rows[0]["TextileProcessTypeExp"]) == "4")
                            {
                                lbl_ExpanisionNatureOfIndustry.Text = "Garmenting";
                            }
                           
                        }

                        lbl_ASCPName.Text = ds.Tables[0].Rows[0]["AuthorisedPerson"].ToString();
                        if (ds.Tables[0].Rows[0]["AuthorisedSignatoryDesignation"].ToString() != "")
                        {
                            lbl_ASCPDesignation.Text = ds.Tables[0].Rows[0]["AuthorisedSignatoryDisignationname"].ToString();
                        }

                        lbl_ASCPPANNumber.Text = ds.Tables[0].Rows[0]["Authorized_PAN_NO"].ToString();
                        lbl_ASCPEmailID.Text = ds.Tables[0].Rows[0]["Authorized_EmailId"].ToString();
                        lbl_ASCPMobileNumber.Text = ds.Tables[0].Rows[0]["Authorized_MobileNo"].ToString();
                        lbl_ASCpCorrespAddress.Text = ds.Tables[0].Rows[0]["Authorized_CorresponAdderess"].ToString();


                        // TAB 3
                        lbl_staffMale.Text = ds.Tables[0].Rows[0]["ManagementStaffMale"].ToString();
                        lbl_female.Text = ds.Tables[0].Rows[0]["ManagementStaffFemale"].ToString();
                        lbl_supermalecount.Text = ds.Tables[0].Rows[0]["SupervisoryMale"].ToString();
                        lbl_superfemalecount.Text = ds.Tables[0].Rows[0]["SupervisoryFemale"].ToString();
                        lbl_SkilledWorkersMale.Text = ds.Tables[0].Rows[0]["SkilledWorkersMale"].ToString();
                        lbl_SkilledWorkersFemale.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString();
                        lbl_SemiSkilledWorkersMale.Text = ds.Tables[0].Rows[0]["SemiSkilledWorkersMale"].ToString();
                        lbl_SemiSkilledWorkersFemale.Text = ds.Tables[0].Rows[0]["SemiSkilledWorkersFemale"].ToString();

                        //CalculatationofEmployemnt("1");
                        //CalculatationofEmployemnt("2");
                        //CalculatationofEmployemnt("3");
                        //CalculatationofEmployemnt("4");

                        lbl_landexisting.Text = ds.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString();
                        lbl_landcapacity.Text = ds.Tables[0].Rows[0]["ExpansionDiversificationLand"].ToString();
                        lbl_landpercentage.Text = ds.Tables[0].Rows[0]["LandFixedCapitalInvestPercentage"].ToString();

                        lbl_buildingexisting.Text = ds.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString();
                        lbl_buildingcapacity.Text = ds.Tables[0].Rows[0]["ExpDiversBuilding"].ToString();
                        lbl_buildingpercentage.Text = ds.Tables[0].Rows[0]["BuildingFixedCapitalInvestPercentage"].ToString();

                        lbl_plantexisting.Text = ds.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString();
                        lbl_plantcapacity.Text = ds.Tables[0].Rows[0]["ExpDiversPlantMachinery"].ToString();
                        lbl_plantpercentage.Text = ds.Tables[0].Rows[0]["PlantMachFixedCapitalInvestPercentage"].ToString();

                        //CalculatationEnterprise1("1");
                        //CalculatationEnterprise1("2");
                        //CalculatationEnterprise1("3");
                        if (Convert.ToString(ds.Tables[0].Rows[0]["Category"]) != "")
                        {
                            lbl_industryCategory.Text = Convert.ToString(ds.Tables[0].Rows[0]["Category"]);
                        }



                        if (Convert.ToString(ds.Tables[0].Rows[0]["IsWaterSourceApplicableValues"]) == "1")
                        {
                            lbl_IsWaterapplicable.Text = "Yes";
                        }
                        else
                        {
                            lbl_IsWaterapplicable.Text = "No";
                        }
                        if (Convert.ToString(ds.Tables[0].Rows[0]["IsPowerApplicableValues"]) == "1")
                        {
                            lbl_Ispowerapplicable.Text = "Yes";
                        }
                        else
                        {
                            lbl_Ispowerapplicable.Text = "No";
                        }
                        lbl_newpowereleasedate.Text = ds.Tables[0].Rows[0]["NewPowerReleaseDate"].ToString();
                        lbl_newConnectedLoad.Text = ds.Tables[0].Rows[0]["NewConnectedLoad"].ToString();
                        lbl_newcontractedload.Text = ds.Tables[0].Rows[0]["NewContractedLoad"].ToString();
                        lbl_newrateperunit.Text = ds.Tables[0].Rows[0]["NewServiceRateUnit"].ToString();

                        lbl_PowerReleaseDate.Text = ds.Tables[0].Rows[0]["ExistingPowerReleaseDate"].ToString();
                        lbl_powerConnectedLoad.Text = ds.Tables[0].Rows[0]["ExistingConnectedLoad"].ToString();
                        lbl_powerContractedLoad.Text = ds.Tables[0].Rows[0]["ExistingContractedLoad"].ToString();
                        lbl_ServiceRateUnit.Text = ds.Tables[0].Rows[0]["ExistingServiceRateUnit"].ToString();

                        lbl_ExistingPowerReleaseDate.Text = ds.Tables[0].Rows[0]["ExpanDiverPowerReleaseDate"].ToString();
                        lbl_ExistingPowerConnectedLoad.Text = ds.Tables[0].Rows[0]["ExpanDiverConnectedLoad"].ToString();
                        lbl_ExistingContractedLoad.Text = ds.Tables[0].Rows[0]["ExpanDiverContractedLoad"].ToString();
                        lbl_ExistingRateUnit.Text = ds.Tables[0].Rows[0]["ExpanServiceRateUnit"].ToString();

                        lbl_waterSource.Text = ds.Tables[0].Rows[0]["waterSource"].ToString();
                        lbl_waterRequirement.Text = ds.Tables[0].Rows[0]["waterRequirement"].ToString();
                        lbl_waterRateperunit.Text = ds.Tables[0].Rows[0]["waterRateperunit"].ToString();

                        // TAB 4

                        lbl_TurnoverYear1.Text = ds.Tables[0].Rows[0]["TurnOver_1stYear"].ToString();
                        lbl_TurnoverYear2.Text = ds.Tables[0].Rows[0]["TurnOver_2ndYear"].ToString();
                        lbl_TurnoverYear3.Text = ds.Tables[0].Rows[0]["TurnOver_3rdYear"].ToString();
                        lbl_EBITDAYear1.Text = ds.Tables[0].Rows[0]["EBITDA_1stYear"].ToString();
                        lbl_EBITDAYear2.Text = ds.Tables[0].Rows[0]["EBITDA_2ndYear"].ToString();
                        lbl_EBITDAYear3.Text = ds.Tables[0].Rows[0]["EBITDA_3rdYear"].ToString();
                        lbl_NetworthYear1.Text = ds.Tables[0].Rows[0]["Networth_1stYear"].ToString();
                        lbl_NetworthYear2.Text = ds.Tables[0].Rows[0]["Networth_2ndYear"].ToString();
                        lbl_NetworthYear3.Text = ds.Tables[0].Rows[0]["Networth_3rdYear"].ToString();
                        lbl_ReservesYear1.Text = ds.Tables[0].Rows[0]["ReservesSurplus_1stYear"].ToString();
                        lbl_ReservesYear2.Text = ds.Tables[0].Rows[0]["ReservesSurplus_2ndYear"].ToString();
                        lbl_ReservesYear3.Text = ds.Tables[0].Rows[0]["ReservesSurplus_3rdYear"].ToString();
                        lbl_ShareCapitalYear1.Text = ds.Tables[0].Rows[0]["Share_Capital_1stYear"].ToString();
                        lbl_ShareCapitalYear2.Text = ds.Tables[0].Rows[0]["Share_Capital_2ndYear"].ToString();
                        lbl_ShareCapitalYear3.Text = ds.Tables[0].Rows[0]["Share_Capital_3rdYear"].ToString();
                        lbl_PromoterEquity.Text = ds.Tables[0].Rows[0]["PromotersEquity_MF"].ToString();
                        lbl_InstitutionsEquity.Text = ds.Tables[0].Rows[0]["InstitutionEquity_MF"].ToString();
                        lbl_TearmLoans.Text = ds.Tables[0].Rows[0]["TermsLoans_M"].ToString();
                        lbl_MeansFinanceOthers.Text = ds.Tables[0].Rows[0]["Others_MF"].ToString();
                        lbl_SeedCapital.Text = ds.Tables[0].Rows[0]["SeedCapital_MF"].ToString();
                        lbl_Subsidyagencies.Text = ds.Tables[0].Rows[0]["SubsidyGrantsAgencies_MF"].ToString();



                        if (Convert.ToString(ds.Tables[0].Rows[0]["IsTermLoanAvailed"]) == "1")
                        {
                            lbl_IsTermLoanAvailed.Text = "Yes";
                        }
                        else
                        {
                            lbl_IsTermLoanAvailed.Text = "No";
                        }
                        //BindTearmLoanDtls(Session["IncentiveID"].ToString());  // Method Call

                        lbl_Land2.Text = ds.Tables[0].Rows[0]["LandApprovedProjectCost"].ToString();
                        lbl_Land3.Text = ds.Tables[0].Rows[0]["LandLoanSactioned"].ToString();
                        lbl_Land4.Text = ds.Tables[0].Rows[0]["LandPromotersEquity"].ToString();
                        lbl_Land5.Text = ds.Tables[0].Rows[0]["LandLoanAmountReleased"].ToString();
                        lbl_Land6.Text = ds.Tables[0].Rows[0]["LandAssetsValuebyFinInstitution"].ToString();
                        lbl_Land7.Text = ds.Tables[0].Rows[0]["LandAssetsValuebyCA"].ToString();
                        lbl_Building2.Text = ds.Tables[0].Rows[0]["BuildingApprovedProjectCost"].ToString();
                        lbl_Building3.Text = ds.Tables[0].Rows[0]["BuildingLoanSactioned"].ToString();
                        lbl_Building4.Text = ds.Tables[0].Rows[0]["BuildingPromotersEquity"].ToString();
                        lbl_Building5.Text = ds.Tables[0].Rows[0]["BuildingLoanAmountReleased"].ToString();
                        lbl_Building6.Text = ds.Tables[0].Rows[0]["BuildingAssetsValuebyFinInstitution"].ToString();
                        lbl_Building7.Text = ds.Tables[0].Rows[0]["BuildingAssetsValuebyCA"].ToString();
                        lbl_PM2.Text = ds.Tables[0].Rows[0]["PlantMachineryApprovedProjectCost"].ToString();
                        lbl_PM3.Text = ds.Tables[0].Rows[0]["PlantMachineryLoanSactioned"].ToString();
                        lbl_PM4.Text = ds.Tables[0].Rows[0]["PlantMachineryPromotersEquity"].ToString();
                        lbl_PM5.Text = ds.Tables[0].Rows[0]["PlantMachineryLoanAmountReleased"].ToString();
                        lbl_PM6.Text = ds.Tables[0].Rows[0]["PlantMachineryAssetsValuebyFinInstitution"].ToString();
                        lbl_PM7.Text = ds.Tables[0].Rows[0]["PlantMachineryAssetsValuebyCA"].ToString();
                        lbl_MCont2.Text = ds.Tables[0].Rows[0]["MachineryContingenciesApprovedProjectCost"].ToString();
                        lbl_MCont3.Text = ds.Tables[0].Rows[0]["MachineryContingenciesLoanSactioned"].ToString();
                        lbl_MCont4.Text = ds.Tables[0].Rows[0]["MachineryContingenciesPromotersEquity"].ToString();
                        lbl_MCont5.Text = ds.Tables[0].Rows[0]["MachineryContingenciesLoanAmountReleased"].ToString();
                        lbl_MCont6.Text = ds.Tables[0].Rows[0]["MachineryContingenciesAssetsValuebyFinInstitution"].ToString();
                        lbl_MCont7.Text = ds.Tables[0].Rows[0]["MachineryContingenciesAssetsValuebyCA"].ToString();
                        lbl_Erec2.Text = ds.Tables[0].Rows[0]["ErectionApprovedProjectCost"].ToString();
                        lbl_Erec3.Text = ds.Tables[0].Rows[0]["ErectionLoanSactioned"].ToString();
                        lbl_Erec4.Text = ds.Tables[0].Rows[0]["ErectionPromotersEquity"].ToString();
                        lbl_Erec5.Text = ds.Tables[0].Rows[0]["ErectionLoanAmountReleased"].ToString();
                        lbl_Erec6.Text = ds.Tables[0].Rows[0]["ErectionAssetsValuebyFinInstitution"].ToString();
                        lbl_Erec7.Text = ds.Tables[0].Rows[0]["ErectionAssetsValuebyCA"].ToString();
                        lbl_TFS2.Text = ds.Tables[0].Rows[0]["TechnicalfeasibilityApprovedProjectCost"].ToString();
                        lbl_TFS3.Text = ds.Tables[0].Rows[0]["TechnicalfeasibilityLoanSactioned"].ToString();
                        lbl_TFS4.Text = ds.Tables[0].Rows[0]["TechnicalfeasibilityPromotersEquity"].ToString();
                        lbl_TFS5.Text = ds.Tables[0].Rows[0]["TechnicalfeasibilityLoanAmountReleased"].ToString();
                        lbl_TFS6.Text = ds.Tables[0].Rows[0]["TechnicalfeasibilityAssetsValuebyFinInstitution"].ToString();
                        lbl_TFS7.Text = ds.Tables[0].Rows[0]["TechnicalfeasibilityAssetsValuebyCA"].ToString();
                        lbl_WC2.Text = ds.Tables[0].Rows[0]["WorkingCapitalApprovedProjectCost"].ToString();
                        lbl_WC3.Text = ds.Tables[0].Rows[0]["WorkingCapitalLoanSactioned"].ToString();
                        lbl_WC4.Text = ds.Tables[0].Rows[0]["WorkingCapitalPromotersEquity"].ToString();
                        lbl_WC5.Text = ds.Tables[0].Rows[0]["WorkingCapitalLoanAmountReleased"].ToString();
                        lbl_WC6.Text = ds.Tables[0].Rows[0]["WorkingCapitalAssetsValuebyFinInstitution"].ToString();
                        lbl_WC7.Text = ds.Tables[0].Rows[0]["WorkingCapitalAssetsValuebyCA"].ToString();

                        // TAB 5

                        if (ds.Tables[0].Rows[0]["BankName"].ToString() != "")
                        {
                            lbl_NametheBank.Text = ds.Tables[0].Rows[0]["BankNamebyID"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["BranchName"].ToString() != "")
                        {
                            lbl_BranchName.Text = ds.Tables[0].Rows[0]["BranchName"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["AccNo"].ToString() != "")
                        {
                            lbl_AccountNumber.Text = ds.Tables[0].Rows[0]["AccNo"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["IFSCCode"].ToString() != "")
                        {
                            lbl_IFSCCode.Text = ds.Tables[0].Rows[0]["IFSCCode"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["BankAccountName"].ToString() != "")
                        {
                            lbl_AccountHolderName.Text = ds.Tables[0].Rows[0]["BankAccountName"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["BankAccType"].ToString() != "")
                        {
                            lbl_AccountType.Text = ds.Tables[0].Rows[0]["AccountTypeName"].ToString();
                        }


                        
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        GVTermLoandtls.DataSource = ds.Tables[1];
                        GVTermLoandtls.DataBind();
                    }

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        GvPartnerDetails.DataSource = ds.Tables[2];
                        GvPartnerDetails.DataBind();
                    }

                    if (ds.Tables[3].Rows.Count > 0)
                    {                      
                            GvLineOfactivityDetails.DataSource = ds.Tables[3];
                            GvLineOfactivityDetails.DataBind();
                    }
                    if (ds.Tables[4].Rows.Count > 0)
                    {
                        GvLineOfactivityExpnsionDetails.DataSource = ds.Tables[4];
                        GvLineOfactivityExpnsionDetails.DataBind();
                    }
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
        public DataSet viewapplication(string USERID, string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@CREATEDBY",SqlDbType.VarChar),
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = USERID;
            pp[1].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("TTAP_ApplicationView", pp);
            return Dsnew;
        }
    }
}