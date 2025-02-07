using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataAccessLayer;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class InterestSubsidyAppraisalNote : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString);
        General Gen = new General();


        protected void Page_Load(object sender, EventArgs e)
        {
           // getDetails();
           // string incid = Request.QueryString["incid"].ToString();
        }
        public void getLOAData(DataSet ds1)
        {
            if (ds1 != null && ds1.Tables.Count > 1 && ds1.Tables[1].Rows.Count > 0)
            {
                gvInstalledCap.DataSource = ds1.Tables[1];
                gvInstalledCap.DataBind();
            }

        }
        public void getDetails()
        {
            string IncentiveId = Request.QueryString["incid"].ToString();
            string MasterIncentiveId = Request.QueryString["mstid"].ToString();
            DataSet ds2 = new DataSet();
            ds2 = Gen.GetBasicUnitDetails_Proforma_lettersPSR(IncentiveId, MasterIncentiveId);
            if (MasterIncentiveId == "1" || MasterIncentiveId == "3" || MasterIncentiveId == "5")
            {
                TRCLAIMPERIOD.Visible = true;
                lblclaimperiod.Text = ds2.Tables[1].Rows[0]["GMclaimedfinyear"].ToString();

            }
            SqlConnection osqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
            osqlConnection.Open();
            SqlDataAdapter da;
            da = new SqlDataAdapter("USP_GETDETAILSFORSECTION_Appraisal_IS_New1", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = IncentiveId;
            da.SelectCommand.Parameters.Add("@mstincentiveid", SqlDbType.VarChar).Value = MasterIncentiveId;
            da.Fill(ds);

            getLOAData(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Downloadlink"].ToString() != null && ds.Tables[0].Rows[0]["Downloadlink"].ToString() != "")
                {
                    clerkattachment.Visible = true;
                    hylinkattachment.Visible = true;
                    //hylinkattachment.NavigateUrl = ds.Tables[0].Rows[0]["Downloadlink"].ToString();
                    string encpassword = Gen.Encrypt(ds.Tables[0].Rows[0]["Downloadlink"].ToString(), "SYSTIME");
                    hylinkattachment.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                }
                else
                {
                    clerkattachment.Visible = false;
                    hylinkattachment.Visible = false;
                }

                if (MasterIncentiveId == "3" || MasterIncentiveId == "5")
                {
                    TRSCHEME.Visible = true;
                    LBLSCHEME.Text = ds.Tables[0].Rows[0]["Scheme"].ToString();

                }
                if (ds.Tables[0].Rows[0]["lblTideaTpride"].ToString() == "Y")
                {
                    tprideTr.Visible = false;
                    tideaTr.Visible = true;
                }
                else if (ds.Tables[0].Rows[0]["lblTideaTpride"].ToString() == "N")
                {
                    tprideTr.Visible = true;
                    tideaTr.Visible = false;
                    //tprideTr.Visible = false;
                    //tideaTr.Visible = true;
                    if (ds.Tables[0].Rows[0]["CASTE"].ToString() != "")
                    {
                        if (ds.Tables[0].Rows[0]["CASTE"].ToString() == "SC")
                        {
                            LBLCASTE.Text = "SCSDF (SCP)";
                            LBLCASTE.Visible = true;
                            LBLCASTE2.Text = "- SCSDF (SCP)";
                            LBLCASTE2.Visible = true;
                        }
                        if (ds.Tables[0].Rows[0]["CASTE"].ToString() == "ST")
                        {
                            LBLCASTE.Text = "STSDF (TSP)";
                            LBLCASTE.Visible = true;
                            LBLCASTE2.Text = "- STSDF (TSP)";
                            LBLCASTE2.Visible = true;
                        }
                    }
                }
                if (ds.Tables[0].Rows[0]["DetailsGm"].ToString() != "")
                    lblDetailsConfirmed.Text = ds.Tables[0].Rows[0]["DetailsGm"].ToString();
                else
                    lblDetailsConfirmed.Text = "NA";
                lblApplication_no.Text = ds.Tables[0].Rows[0]["lblApplicationno"].ToString();
                lblUnitname.Text = ds.Tables[0].Rows[0]["txtunitnames"].ToString();
                lblLocaddress.Text = ds.Tables[0].Rows[0]["txtLocofUnit"].ToString();
                lblConstitutionOfIndustrial.Text = ds.Tables[0].Rows[0]["ddlOrddlorgtypes"].ToString();
                lblSocialStatus.Text = ds.Tables[0].Rows[0]["CASTE"].ToString();
                lblPromoterName.Text = ds.Tables[0].Rows[0]["ApplciantName"].ToString();
                lblEntrprName.Text = ds.Tables[0].Rows[0]["ApplciantName"].ToString();
                lblSSIRegn.Text = ds.Tables[0].Rows[0]["txtPersonIndustry"].ToString();
                lblNewExpnDiver.Text = ds.Tables[0].Rows[0]["IdsustryStatus"].ToString();
                lblCommencmentOfCommrclProdcn_Date.Text = ds.Tables[0].Rows[0]["txtDCP_unit"].ToString();
                //lblApplicationDateDIC.Text = ds.Tables[0].Rows[0]["txtcompdate_dic"].ToString();
                //lblApplicationDateDIC.Text = ds.Tables[0].Rows[0]["txtcompdate_coi"].ToString(); commented on 21.01.2020
                lblApplicationDateDIC.Text = ds.Tables[0].Rows[0]["txtDateOfapplnFile"].ToString();
                lblFinInstn.Text = ds.Tables[0].Rows[0]["txtNameofFinIns"].ToString();

                //lblTotal_ProjectCost.Text = ds.Tables[0].Rows[0]["txtWC2"].ToString();
                string A;
                string B;
                string C;
                if (ds.Tables[0].Rows[0]["txtLand2"].ToString() == "" || ds.Tables[0].Rows[0]["txtLand2"].ToString() == null)
                {
                    A = "0";
                }
                else
                {
                    A = ds.Tables[0].Rows[0]["txtLand2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["txtBuilding2"].ToString() == "" || ds.Tables[0].Rows[0]["txtBuilding2"].ToString() == null)
                {
                    B = "0";
                }
                else
                {
                    B = ds.Tables[0].Rows[0]["txtBuilding2"].ToString();
                }
                if (ds.Tables[0].Rows[0]["txtPM2"].ToString() == "" || ds.Tables[0].Rows[0]["txtPM2"].ToString() == null)
                {
                    C = "0";
                }
                else
                {
                    C = ds.Tables[0].Rows[0]["txtPM2"].ToString();
                }

                lblTotal_ProjectCost.Text = (Convert.ToDecimal(A) + Convert.ToDecimal(B) + Convert.ToDecimal(C)).ToString();

                //lblTotal_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["txtWC7"].ToString();
                string D;
                string E;
                string F;
                if (ds.Tables[0].Rows[0]["txtLand7"].ToString() == "" || ds.Tables[0].Rows[0]["txtLand7"].ToString() == null)
                {
                    D = "0";
                }
                else
                {
                    D = ds.Tables[0].Rows[0]["txtLand7"].ToString();
                }
                if (ds.Tables[0].Rows[0]["txtBuilding7"].ToString() == "" || ds.Tables[0].Rows[0]["txtBuilding7"].ToString() == null)
                {
                    E = "0";
                }
                else
                {
                    E = ds.Tables[0].Rows[0]["txtBuilding7"].ToString();
                }
                if (ds.Tables[0].Rows[0]["txtPM7"].ToString() == "" || ds.Tables[0].Rows[0]["txtPM7"].ToString() == null)
                {
                    F = "0";
                }
                else
                {
                    F = ds.Tables[0].Rows[0]["txtPM7"].ToString();
                }
                lblTotal_ValueRecommendedByGM.Text = (Convert.ToDecimal(D) + Convert.ToDecimal(E) + Convert.ToDecimal(F)).ToString();

                //lblTotalComputed.Text = ds.Tables[0].Rows[0]["TextBox2"].ToString();
                string G;
                string H;
                string I;
                if (ds.Tables[0].Rows[0]["TextBox56"].ToString() == "" || ds.Tables[0].Rows[0]["TextBox56"].ToString() == null)
                {
                    G = "0";
                }
                else
                {
                    G = ds.Tables[0].Rows[0]["TextBox56"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TextBox57"].ToString() == "" || ds.Tables[0].Rows[0]["TextBox57"].ToString() == null)
                {
                    H = "0";
                }
                else
                {
                    H = ds.Tables[0].Rows[0]["TextBox57"].ToString();
                }
                if (ds.Tables[0].Rows[0]["TextBox58"].ToString() == "" || ds.Tables[0].Rows[0]["TextBox58"].ToString() == null)
                {
                    I = "0";
                }
                else
                {
                    I = ds.Tables[0].Rows[0]["TextBox58"].ToString();
                }
                lblTotalComputed.Text = (Convert.ToDecimal(G) + Convert.ToDecimal(H) + Convert.ToDecimal(I)).ToString();

                lblLand_ProjectCost.Text = ds.Tables[0].Rows[0]["txtLandcostCompc"].ToString();

                lblPlantMachry_ProjectCost.Text = ds.Tables[0].Rows[0]["TextBox30"].ToString();
                lblFeasibilityStudyCharges_ProjectCost.Text = ds.Tables[0].Rows[0]["TextBox32"].ToString();

                lblVehicles_ProjectCost.Text = ds.Tables[0].Rows[0]["txtErec2"].ToString();
                lblVehicles_ValueRecommendedByGM.Text = "-";
                lblVehiclesComputed.Text = "-";
                lblVehicles_GMRec.Text = "-";


                lblOthersEligible_ProjectCost.Text = ds.Tables[0].Rows[0]["txtTFS2"].ToString();
                lblOthersEligible_ValueRecommendedByGM.Text = "-";
                lblOthersEligibleComputed.Text = "-";
                lblOthersEligible_GMRec.Text = "-";

                lblFeasibilityStudyCharges_ProjectCost.Text = ds.Tables[0].Rows[0]["TextBox44"].ToString();
                lblFeasibilityStudyCharges_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["TextBox45"].ToString();
                lblFeasibilityStudyChargesComputed.Text = "-";
                lblFeasibilityStudyCharges_GMRec.Text = "-";

                lblPlantMachry_ProjectCost.Text = ds.Tables[0].Rows[0]["txtPM2"].ToString();
                //lblPlantMachry_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["TextBox58"].ToString();
                ////lblPlantMachryComputed.Text = ds.Tables[0].Rows[0]["TextBox58"].ToString();
                ////lblPlantMachry_GMRec.Text = "-";
                //lblPlantMachryComputed.Text = ds.Tables[0].Rows[0]["TextBox42"].ToString();
                lblPlantMachry_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["txtPM7"].ToString();
                lblPlantMachryComputed.Text = ds.Tables[0].Rows[0]["TextBox58"].ToString();
                lblPlantMachry_GMRec.Text = ds.Tables[0].Rows[0]["TextBox47"].ToString();

                lblBuilding_ProjectCost.Text = ds.Tables[0].Rows[0]["txtBuilding2"].ToString();
                //lblBuilding_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["TextBox57"].ToString();
                ////lblBuildingComputed.Text = "-";
                ////lblBuilding_GMRec.Text = "-";
                //lblBuildingComputed.Text = ds.Tables[0].Rows[0]["txtCompvalCompc"].ToString();
                lblBuilding_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["txtBuilding7"].ToString();
                lblBuildingComputed.Text = ds.Tables[0].Rows[0]["TextBox57"].ToString();
                lblBuilding_GMRec.Text = ds.Tables[0].Rows[0]["txtrsnCompc"].ToString();

                lblLand_ProjectCost.Text = ds.Tables[0].Rows[0]["txtLand2"].ToString();
                //lblLand_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["TextBox56"].ToString();
                ////lblLandComputed.Text = "-";
                ////lblLand_GMRec.Text = "-";
                //lblLandComputed.Text = ds.Tables[0].Rows[0]["txtvalCompc1"].ToString();
                lblLand_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["txtLand7"].ToString();
                lblLandComputed.Text = ds.Tables[0].Rows[0]["TextBox56"].ToString();
                lblLand_GMRec.Text = ds.Tables[0].Rows[0]["txtresonsCompc"].ToString();


                lblPercent.Text = ds.Tables[0].Rows[0]["TextBox59"].ToString();
                lblStateInvesSubsidy.Text = ds.Tables[0].Rows[0]["txt423guideline"].ToString();
                lblAddlSubWomen.Text = ds.Tables[0].Rows[0]["txtTSSFCnorms423"].ToString();
                lblEligi_TotalSubsidy.Text = ds.Tables[0].Rows[0]["txtvalue424"].ToString();

                if (MasterIncentiveId == "6")
                {
                    lblSancIncentiveName.Text = "Sanction of Investment Subsidy";
                    lblapplicationtype_IS.Text = ds.Tables[0].Rows[0]["ELIGIBLETYPE"].ToString();
                    lbllmvornonlmv.Text = ds.Tables[0].Rows[0]["LMV"].ToString();
                    lblmenorwomen.Text = ds.Tables[0].Rows[0]["WOMENMEN"].ToString();
                    if (lblmenorwomen.Text == "Women")
                    {
                        lblwomen.Visible = true;
                        lblwomen.Text = "| Women Entrepreneur : (100% Share)";

                    }
                    else
                    {
                        lblwomen.Visible = false;
                    }
                    if (lblapplicationtype_IS.Text == "Regular" && lblmenorwomen.Text == "Women")
                    {
                        lblpercentage_is.Text = "10%";
                    }
                    //else
                    //{
                    //    lblpercentage_is.Text = "0%";
                    //}
                    else if (lblapplicationtype_IS.Text == "Belated" && lblmenorwomen.Text == "Women")
                    {
                        lblpercentage_is.Text = "5%";
                    }
                    //else
                    //{
                    //    lblpercentage_is.Text = "0%";
                    //}
                    else if (lblapplicationtype_IS.Text == "OneYear" && lblmenorwomen.Text == "Women")
                    {
                        lblpercentage_is.Text = "0%";
                    }
                    else
                    {
                        lblpercentage_is.Text = "0%";
                    }
                }
                //
                lblFinalSchemeName.Text = ds.Tables[0].Rows[0]["Scheme"].ToString();
                //distName
                LblDICName.Text = ds.Tables[0].Rows[0]["distName"].ToString();
                if (ds.Tables[0].Rows[0]["Remarks"].ToString() != "" && ds.Tables[0].Rows[0]["Remarks"].ToString() != null)
                {
                    LBLREMARKS.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();//UNCOMMENTED BY MADHURI ON 26/09/2022 don't commented again
                }


            }

            if (MasterIncentiveId == "5")   //salestax  
            {
                divcoal.Visible = false;
                DIVWOOD.Visible = false;
                Div3.Visible = false;
                Div3.Visible = false;
                divLandconversion.Visible = false;
                divmortgage.Visible = false;
                divlandcost.Visible = false;
                divStampduty.Visible = false;
                DIVSALESTAX.Visible = true;

                LBLSCHEMETYPE.Text = ds.Tables[0].Rows[0]["SCHEMETYPE"].ToString();
                lblapplicationtype.Text = ds.Tables[0].Rows[0]["APPLICATIONTYPE"].ToString();
                lblproduction.Text = ds.Tables[0].Rows[0]["PRODUCTION"].ToString();
                lbltaxpaid.Text = ds.Tables[0].Rows[0]["TAXPAIDSGST"].ToString();
                lblbaseproduction.Text = ds.Tables[0].Rows[0]["BASEPRODUCTION"].ToString();
                lblelgprodqty.Text = ds.Tables[0].Rows[0]["ELIGIBLEPRODUCTIONQUANTITY"].ToString();
                lblproportionatesgst.Text = ds.Tables[0].Rows[0]["PROPORTINATESGST"].ToString();
                lblgmrecommendedvalue.Text = ds.Tables[0].Rows[0]["GMVALUE"].ToString();
                lblcategory.Text = ds.Tables[0].Rows[0]["CATEGORYNAME"].ToString();
                if (lblcategory.Text == "Mega")
                {
                    lblpercentage.Text = ds.Tables[0].Rows[0]["MEGA"].ToString();
                }
                if (lblcategory.Text == "Large")
                {
                    lblpercentage.Text = ds.Tables[0].Rows[0]["LARGE"].ToString();
                }
                if (lblcategory.Text == "Medium")
                {
                    lblpercentage.Text = ds.Tables[0].Rows[0]["MEDIUM"].ToString();
                }
                if (lblcategory.Text == "Small")
                {
                    lblpercentage.Text = ds.Tables[0].Rows[0]["SMALL"].ToString();
                }
                if (lblcategory.Text == "Micro")
                {
                    lblpercentage.Text = ds.Tables[0].Rows[0]["MICRO"].ToString();
                }
                if (LBLSCHEMETYPE.Text == "T-IDEA")
                {
                    trcapitaleligibleinvestment.Visible = true;
                    trsalestaxsanctionedonthisclaim.Visible = true;
                    lblcapitalelginvestment.Text = ds.Tables[0].Rows[0]["TOTALCAPITALELIGIBLEINVESTMENT"].ToString();
                    lblsalestaxsanctioned.Text = ds.Tables[0].Rows[0]["TOTALSALESTAXSANCTIONEDONTHISCLAIM"].ToString();
                }
                else
                {
                    trcapitaleligibleinvestment.Visible = false;
                    trsalestaxsanctionedonthisclaim.Visible = false;
                }
                lbleligibleamount.Text = ds.Tables[0].Rows[0]["FINALSUBSIDYAMOUNT"].ToString();
                lbltypeofclaim.Text = ds.Tables[0].Rows[0]["ELIGIBLETYPE"].ToString();

                lblremarks_salestax.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                lblSancIncentiveName.Text = "Sanction of Reimbursement of Sales Tax";


            }

            if (MasterIncentiveId == "16")  //land conversion 
            {
                Div3.Visible = false;
                divcoal.Visible = false;
                DIVWOOD.Visible = false;
                divLandconversion.Visible = true;
                divmortgage.Visible = false;
                divlandcost.Visible = false;
                divStampduty.Visible = false;
                Div3.Visible = false;
                DIVSALESTAX.Visible = false;
                lblLConLandMeasure.Text = ds.Tables[0].Rows[0]["landmeasuring"].ToString();
                LblLconPurchaseValue.Text = ds.Tables[0].Rows[0]["purchasevalue"].ToString();
                lblLconBuildingPlnth.Text = ds.Tables[0].Rows[0]["buildingplntharea"].ToString();
                lblfietimesplintharea.Text = ds.Tables[0].Rows[0]["buildingplnthareaFveTimes"].ToString();

                lblLconProportionate.Text = ds.Tables[0].Rows[0]["proportionatevalue"].ToString();
                lblLconLandValueComputed.Text = ds.Tables[0].Rows[0]["landvaluecomputed"].ToString();
                lblLconTwntyFveComputed.Text = ds.Tables[0].Rows[0]["twntyfveComputed"].ToString();
                lblLConEligibleLandConversion.Text = ds.Tables[0].Rows[0]["Finaleligibleamount"].ToString();
                lblLconValueGMRecom.Text = ds.Tables[0].Rows[0]["valuerecndgm"].ToString();


                lblLconClaimType.Text = ds.Tables[0].Rows[0]["applicantType"].ToString();
                LBLREMARKS_LANDCONVERSION.Text = ds.Tables[0].Rows[0]["mortgageRemarks"].ToString();

                lblSancIncentiveName.Text = "Sanction of Reimbursement of Land Conversion";


            }
            if (MasterIncentiveId == "15")  //mortgage 
            {
                Div3.Visible = false;
                Div3.Visible = false;
                divLandconversion.Visible = false;
                divmortgage.Visible = true;
                divlandcost.Visible = false;
                divStampduty.Visible = false;
                DIVSALESTAX.Visible = false;
                divcoal.Visible = false;
                DIVWOOD.Visible = false;

                lblMortFinancialIns.Text = ds.Tables[0].Rows[0]["FinInstitution"].ToString();
                lblMortTermLoan.Text = ds.Tables[0].Rows[0]["TermLoanSancctioned"].ToString();
                lblMortMortgageDutyPaid.Text = ds.Tables[0].Rows[0]["MortgagePaid"].ToString();
                lblMortTermloanAvailed.Text = ds.Tables[0].Rows[0]["TermLoanAvailed"].ToString();
                lblMortProportionateMortgage.Text = ds.Tables[0].Rows[0]["PropMortgageDuty"].ToString();
                lblMortMortgageDuty.Text = ds.Tables[0].Rows[0]["Mortgage_gM"].ToString();
                lblMortElgibleReimbursement.Text = ds.Tables[0].Rows[0]["FINAL_Mortgage_Reimbursement"].ToString();
                lblMortTypeofClaim.Text = ds.Tables[0].Rows[0]["applicantType"].ToString();
                lblremarks_mortegage.Text = ds.Tables[0].Rows[0]["mortgageRemarks"].ToString();
                divcoal.Visible = false;
                lblSancIncentiveName.Text = "Sanction of Reimbursement of Mortgage";
                //lblamount.Text = ds.Tables[0].Rows[0]["FINAL_Mortgage_Reimbursement"].ToString();

            }
            if (MasterIncentiveId == "17")   //land cost  
            {
                Div3.Visible = false;
                Div3.Visible = false;
                divLandconversion.Visible = false;
                divmortgage.Visible = false;
                divlandcost.Visible = true;
                divStampduty.Visible = false;
                DIVSALESTAX.Visible = false;
                divcoal.Visible = false;
                DIVWOOD.Visible = false;

                //lblLCEligibleLandCost.Text = ds.Tables[0].Rows[0]["ELIGIBLELANDCOST"].ToString();
                lblLcLandPurchase.Text = ds.Tables[0].Rows[0]["LANDPURCHASE"].ToString();
                lblLCLandvalue.Text = ds.Tables[0].Rows[0]["LANDVALUE"].ToString();
                lblLCPlnthArea.Text = ds.Tables[0].Rows[0]["BuildingPlinth"].ToString();
                lblLCfiveTimes.Text = ds.Tables[0].Rows[0]["TotalBuildingPlinth_CALCULATED"].ToString();
                lblLCProportionate.Text = ds.Tables[0].Rows[0]["Proportionatearea"].ToString();
                lblLCValueRecmGM.Text = ds.Tables[0].Rows[0]["GMValue"].ToString();
                lblLCEligibleLandCost.Text = ds.Tables[0].Rows[0]["FINALELIGIBLELANDCOST"].ToString();
                lbltypeofclainlandcost.Text = ds.Tables[0].Rows[0]["ELIGIBLETYPE"].ToString();

                //lblLCfiveTimes
                //lblLcLandPurchase
                lblremarks_landcost.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();

                lblSancIncentiveName.Text = "Sanction of Reimbursement of Land Cost";


            }
            if (MasterIncentiveId == "14")   //stampduty  
            {
                Div3.Visible = false;
                Div3.Visible = false;
                divLandconversion.Visible = false;
                divmortgage.Visible = false;
                divlandcost.Visible = false;
                divStampduty.Visible = true;
                DIVSALESTAX.Visible = false;
                divcoal.Visible = false;
                DIVWOOD.Visible = false;

                lblSDBuildingplnthfvTimes.Text = ds.Tables[0].Rows[0]["StampBuildingPlinth"].ToString();
                lblSDBuildingPlinth.Text = ds.Tables[0].Rows[0]["BuildingPlinth"].ToString();
                lblSDLandmeasuring.Text = ds.Tables[0].Rows[0]["LandSqmt"].ToString();
                lblSDStampduty.Text = ds.Tables[0].Rows[0]["StampDuty"].ToString();
                lblSDProportionateVAlue.Text = ds.Tables[0].Rows[0]["Proportionatearea"].ToString();
                lblSDValueRecomndGM.Text = ds.Tables[0].Rows[0]["GMValue"].ToString();
                lblSDValueComputed.Text = ds.Tables[0].Rows[0]["FINALELIGIBLEAMOUNT"].ToString();
                LBLTYPEOFCLAIM_STAMPDUTY.Text = ds.Tables[0].Rows[0]["ELIGIBLETYPE"].ToString();
                //lblSDBuildingPlinth.Text = ds.Tables[0].Rows[0]["StampSubTotal"].ToString();
                //lblSDValueComputed.Text = ds.Tables[0].Rows[0]["StampBuildingPlinth"].ToString();
                lblSancIncentiveName.Text = "Sanction of Reimbursement of stamp Duty/Transfer Duty";
                lblremarks_stampduty.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();


            }
            if (MasterIncentiveId == "11")   //Quality Certification  
            {
                Div3.Visible = false;
                // trAsperDecisionIS.Visible = false;
                divLandconversion.Visible = false;
                divmortgage.Visible = false;
                divlandcost.Visible = false;
                divStampduty.Visible = false;
                DIVSALESTAX.Visible = false;
                DIVQUALITYCERTIFICATION.Visible = true;
                divcoal.Visible = false;
                DIVWOOD.Visible = false;

                lblqualitycertificationcgargespaid.Text = ds.Tables[0].Rows[0]["QUALITYCERTIFICATIONCHARESPAID"].ToString();
                lblfiftypercentage.Text = ds.Tables[0].Rows[0]["FIFTYPEROFCHARGESPAID"].ToString();
                lblgmrecomamount.Text = ds.Tables[0].Rows[0]["GMValue"].ToString();
                lbllesselegibleamount.Text = ds.Tables[0].Rows[0]["ELEGIBLEWHICHEVERLESS"].ToString();
                lbltypeofclaim_quality.Text = ds.Tables[0].Rows[0]["ELIGIBLETYPE"].ToString();
                lblremarks_qualitycertification.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();



                lblSancIncentiveName.Text = "Sanction of Reimbursement of Quality Certification";


            }
            if (MasterIncentiveId == "8")   //Quality Certification  
            {
                Div3.Visible = false;
                // trAsperDecisionIS.Visible = false;
                divLandconversion.Visible = false;
                divmortgage.Visible = false;
                divlandcost.Visible = false;
                divStampduty.Visible = false;
                DIVSALESTAX.Visible = false;
                DIVQUALITYCERTIFICATION.Visible = false;
                DIVSKILLUPGRADE.Visible = true;
                divcoal.Visible = false;
                DIVWOOD.Visible = false;

                lblskillupchargespaid.Text = ds.Tables[0].Rows[0]["SKILLUPGRADECHARESPAID"].ToString();
                lbl50perskillupchargespaid.Text = ds.Tables[0].Rows[0]["FIFTYPEROFCHARGESPAID"].ToString();
                lblgmrecomamount_skillupgrade.Text = ds.Tables[0].Rows[0]["GMValue"].ToString();
                lblelegamountless_skillupgrade.Text = ds.Tables[0].Rows[0]["ELEGIBLEWHICHEVERLESS"].ToString();
                lbltypeofclaim_skillupgrade.Text = ds.Tables[0].Rows[0]["ELIGIBLETYPE"].ToString();
                lblremarks_skillupgrade.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();



                lblSancIncentiveName.Text = "Sanction of Reimbursement of cost involved in skill upgradation and training";


            }
            if (MasterIncentiveId == "7")  // iidf
            {
                Div3.Visible = false;
                // trAsperDecisionIS.Visible = false;
                divLandconversion.Visible = false;
                divmortgage.Visible = false;
                divlandcost.Visible = false;
                divStampduty.Visible = false;
                DIVSALESTAX.Visible = false;
                DIVQUALITYCERTIFICATION.Visible = false;
                DIVSKILLUPGRADE.Visible = false;
                DIVIIDF.Visible = true;
                divcoal.Visible = false;
                DIVWOOD.Visible = false;

                lbliidfchargespaid.Text = ds.Tables[0].Rows[0]["IIDFCHARESPAID"].ToString();
                lbl50perofiidf.Text = ds.Tables[0].Rows[0]["FIFTYPEROFCHARGESPAID"].ToString();
                lbl15perofcompcost.Text = ds.Tables[0].Rows[0]["FIFTEENPEROFCHARGESPAID"].ToString();
                lblgmrecomamount_iidf.Text = ds.Tables[0].Rows[0]["GMValue"].ToString();
                lblelegamountless_iidf.Text = ds.Tables[0].Rows[0]["ELEGIBLEWHICHEVERLESS"].ToString();
                lbltypeofclaim_iidf.Text = ds.Tables[0].Rows[0]["ELIGIBLETYPE"].ToString();
                lblremarks_iidf.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();



                lblSancIncentiveName.Text = "Industrial Infrastructure Development Fund(IIDF)";


            }

            if (MasterIncentiveId == "18")   //Reimbursement of Coal  
            {
                Div3.Visible = false;
                // trAsperDecisionIS.Visible = false;
                divLandconversion.Visible = false;
                divmortgage.Visible = false;
                divlandcost.Visible = false;
                divStampduty.Visible = false;
                DIVSALESTAX.Visible = false;
                DIVQUALITYCERTIFICATION.Visible = false;
                divcoal.Visible = true;
                DIVWOOD.Visible = false;

                lblcoalquantity.Text = ds.Tables[0].Rows[0]["COALQUANTITY"].ToString();
                lbleligibleamount_coal.Text = ds.Tables[0].Rows[0]["ELIGIBLEAMOUNT"].ToString();
                lblgmrecommendedvalue_coal.Text = ds.Tables[0].Rows[0]["GMVALUE"].ToString();
                lblfinalsubsidyamount_coal.Text = ds.Tables[0].Rows[0]["FINALSUBSIDYAMOUNT"].ToString();
                lblremark_coal.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                lblSancIncentiveName.Text = "Sanction of Reimbursement of Coal";
            }
            if (MasterIncentiveId == "19")   //Reimbursement of Wood  
            {
                Div3.Visible = false;
                // trAsperDecisionIS.Visible = false;
                divLandconversion.Visible = false;
                divmortgage.Visible = false;
                divlandcost.Visible = false;
                divStampduty.Visible = false;
                DIVSALESTAX.Visible = false;
                DIVQUALITYCERTIFICATION.Visible = false;
                divcoal.Visible = false;
                DIVWOOD.Visible = true;

                LBLQUANTITY_WOOD.Text = ds.Tables[0].Rows[0]["WOODQUANTITY"].ToString();
                LBLELIGIBLEAMOUNT_WOOD.Text = ds.Tables[0].Rows[0]["ELIGIBLEAMOUNT"].ToString();
                LBLGMRECOMMENDEDVALUE_WOOD.Text = ds.Tables[0].Rows[0]["GMVALUE"].ToString();
                LBLFINALSUBSIDYAMOUNT_WOOD.Text = ds.Tables[0].Rows[0]["FINALSUBSIDYAMOUNT"].ToString();
                LBLREMARKS_WOOD.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                lblSancIncentiveName.Text = "Reimbursement of Wood";
            }
            if (MasterIncentiveId == "20")
            {
                DIVTRANSPORTDUTY.Visible = true;
                Div3.Visible = false;
                Div3.Visible = false;
                divLandconversion.Visible = false;
                divmortgage.Visible = false;
                divlandcost.Visible = false;
                divStampduty.Visible = false;
                DIVSALESTAX.Visible = false;

                lblmonth1.Text = ds.Tables[0].Rows[0]["month1"].ToString();
                lblfinyear1.Text = ds.Tables[0].Rows[0]["month1_year"].ToString();
                lblunitsconsumed1.Text = ds.Tables[0].Rows[0]["month1amountpaid"].ToString();
                lblelegamount1.Text = ds.Tables[0].Rows[0]["month1eligiblesubsidy"].ToString();

                lblmonth2.Text = ds.Tables[0].Rows[0]["month2"].ToString();
                lblfinyear2.Text = ds.Tables[0].Rows[0]["month2_year"].ToString();
                lblunitsconsumed2.Text = ds.Tables[0].Rows[0]["month2amountpaid"].ToString();
                lblelegamount2.Text = ds.Tables[0].Rows[0]["month2eligiblesubsidy"].ToString();

                lblmonth3.Text = ds.Tables[0].Rows[0]["month3"].ToString();
                lblfinyear3.Text = ds.Tables[0].Rows[0]["month3_year"].ToString();
                lblunitsconsumed3.Text = ds.Tables[0].Rows[0]["month3amountpaid"].ToString();
                lblelegamount3.Text = ds.Tables[0].Rows[0]["month3eligiblesubsidy"].ToString();

                lblmonth4.Text = ds.Tables[0].Rows[0]["month4"].ToString();
                lblfinyear4.Text = ds.Tables[0].Rows[0]["month4_year"].ToString();
                lblunitsconsumed4.Text = ds.Tables[0].Rows[0]["month4amountpaid"].ToString();
                lblelegamount4.Text = ds.Tables[0].Rows[0]["month4eligiblesubsidy"].ToString();

                lblmonth5.Text = ds.Tables[0].Rows[0]["month5"].ToString();
                lblfinyear5.Text = ds.Tables[0].Rows[0]["month5_year"].ToString();
                lblunitsconsumed5.Text = ds.Tables[0].Rows[0]["month5amountpaid"].ToString();
                lblelegamount5.Text = ds.Tables[0].Rows[0]["month5eligiblesubsidy"].ToString();

                lblmonth6.Text = ds.Tables[0].Rows[0]["month6"].ToString();
                lblfinyear6.Text = ds.Tables[0].Rows[0]["month6_year"].ToString();
                lblunitsconsumed6.Text = ds.Tables[0].Rows[0]["month6amountpaid"].ToString();
                lblelegamount6.Text = ds.Tables[0].Rows[0]["month6eligiblesubsidy"].ToString();


                lbltotalmaount.Text = ds.Tables[0].Rows[0]["ELIGIBLEAMOUNT"].ToString();
                lbltype.Text = ds.Tables[0].Rows[0]["ELIGIBLETYPE"].ToString();
                lblGMreconamount.Text = ds.Tables[0].Rows[0]["GMVALUE"].ToString();
                lblfinanelgamount.Text = ds.Tables[0].Rows[0]["FINALSUBSIDYAMOUNT"].ToString();
                lblremarks_TRDUTY.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();


            }

            if (MasterIncentiveId == "3")
            {
                Div3.Visible = false;
                Div3.Visible = false;
                divLandconversion.Visible = false;
                divmortgage.Visible = false;
                divlandcost.Visible = false;
                divStampduty.Visible = false;
                DIVSALESTAX.Visible = false;
                divcoal.Visible = false;
                DIVWOOD.Visible = false;

                //lblamount.Text = ds.Tables[0].Rows[0]["finalsubsidyamount_systemcalculated"].ToString();


                if (ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() == "New")
                {
                    if (ds.Tables[0].Rows[0]["bothOrnot"].ToString() == "Y")
                    {
                        tblNewUnitBoth.Visible = true;
                        txt_grdmonthyear1NewBoth.Text = ds.Tables[0].Rows[0]["finyear1Both_new"].ToString();
                        txt_grdmonthyear2NewBoth.Text = ds.Tables[0].Rows[0]["finyear2Both_new"].ToString();
                        txt_grdmonthyear3NewBoth.Text = ds.Tables[0].Rows[0]["finyear3Both_new"].ToString();
                        txt_grdmonthyear4NewBoth.Text = ds.Tables[0].Rows[0]["finyear4Both_new"].ToString();
                        txt_grdmonthyear5NewBoth.Text = ds.Tables[0].Rows[0]["finyear5Both_new"].ToString();
                        txt_grdmonthyear6NewBoth.Text = ds.Tables[0].Rows[0]["finyear6Both_new"].ToString();
                    }
                    tbl_monthyeardataExpansion.Visible = false;
                    tblNewUnit.Visible = true;
                    lblSancIncentiveName.Text = "Sanction of Reimbursement of Power Cost";
                    txt_grdmonthyear1New.Text = ds.Tables[0].Rows[0]["finyear1_new"].ToString();
                    txt_grdmonthyear2New.Text = ds.Tables[0].Rows[0]["finyear2_new"].ToString();
                    txt_grdmonthyear3New.Text = ds.Tables[0].Rows[0]["finyear3_new"].ToString();
                    txt_grdmonthyear4New.Text = ds.Tables[0].Rows[0]["finyear4_new"].ToString();
                    txt_grdmonthyear5New.Text = ds.Tables[0].Rows[0]["finyear5_new"].ToString();
                    txt_grdmonthyear6New.Text = ds.Tables[0].Rows[0]["finyear6_new"].ToString();

                    txt_grdmonthyear1NewFinyear.Text = ds.Tables[0].Rows[0]["finyearMonth1_new"].ToString();
                    txt_grdmonthyear2NewFinyear.Text = ds.Tables[0].Rows[0]["finyearMonth2_new"].ToString();
                    txt_grdmonthyear3NewFinyear.Text = ds.Tables[0].Rows[0]["finyearMonth3_new"].ToString();
                    txt_grdmonthyear4NewFinyear.Text = ds.Tables[0].Rows[0]["finyearMonth4_new"].ToString();
                    txt_grdmonthyear5NewFinyear.Text = ds.Tables[0].Rows[0]["finyearMonth5_new"].ToString();
                    txt_grdmonthyear6NewFinyear.Text = ds.Tables[0].Rows[0]["finyearMonth6_new"].ToString();
                    if (ds.Tables[0].Rows[0]["bothOrnot"].ToString() == "Y")
                    {
                        txt_grdmonthyear1NewFinyearBoth.Text = ds.Tables[0].Rows[0]["finyearMonth1Both_new"].ToString();
                        txt_grdmonthyear2NewFinyearBoth.Text = ds.Tables[0].Rows[0]["finyearMonth2Both_new"].ToString();
                        txt_grdmonthyear3NewFinyearBoth.Text = ds.Tables[0].Rows[0]["finyearMonth3Both_new"].ToString();
                        txt_grdmonthyear4NewFinyearBoth.Text = ds.Tables[0].Rows[0]["finyearMonth4Both_new"].ToString();
                        txt_grdmonthyear5NewFinyearBoth.Text = ds.Tables[0].Rows[0]["finyearMonth5Both_new"].ToString();
                        txt_grdmonthyear6NewFinyearBoth.Text = ds.Tables[0].Rows[0]["finyearMonth6Both_new"].ToString();
                    }

                    TextBox23.Text = ds.Tables[0].Rows[0]["unitsconsumedMonth1_new"].ToString();
                    TextBox50.Text = ds.Tables[0].Rows[0]["unitsconsumedMonth2_new"].ToString();
                    TextBox63.Text = ds.Tables[0].Rows[0]["unitsconsumedMonth3_new"].ToString();
                    TextBox71.Text = ds.Tables[0].Rows[0]["unitsconsumedMonth4_new"].ToString();
                    TextBox79.Text = ds.Tables[0].Rows[0]["unitsconsumedMonth5_new"].ToString();
                    TextBox87.Text = ds.Tables[0].Rows[0]["unitsconsumedMonth6_new"].ToString();
                    if (ds.Tables[0].Rows[0]["bothOrnot"].ToString() == "Y")
                    {
                        TextBox23Both.Text = ds.Tables[0].Rows[0]["unitsconsumedMonth1Both_new"].ToString();
                        TextBox50Both.Text = ds.Tables[0].Rows[0]["unitsconsumedMonth2Both_new"].ToString();
                        TextBox63Both.Text = ds.Tables[0].Rows[0]["unitsconsumedMonth3Both_new"].ToString();
                        TextBox71Both.Text = ds.Tables[0].Rows[0]["unitsconsumedMonth4Both_new"].ToString();
                        TextBox79Both.Text = ds.Tables[0].Rows[0]["unitsconsumedMonth5Both_new"].ToString();
                        TextBox87Both.Text = ds.Tables[0].Rows[0]["unitsconsumedMonth6Both_new"].ToString();
                    }

                    TextBox24.Text = ds.Tables[0].Rows[0]["rateperunitsMonth1_new"].ToString();
                    TextBox51.Text = ds.Tables[0].Rows[0]["rateperunitsMonth2_new"].ToString();
                    TextBox64.Text = ds.Tables[0].Rows[0]["rateperunitsMonth3_new"].ToString();
                    TextBox72.Text = ds.Tables[0].Rows[0]["rateperunitsMonth4_new"].ToString();
                    TextBox80.Text = ds.Tables[0].Rows[0]["rateperunitsMonth5_new"].ToString();
                    TextBox88.Text = ds.Tables[0].Rows[0]["rateperunitsMonth6_new"].ToString();
                    if (ds.Tables[0].Rows[0]["bothOrnot"].ToString() == "Y")
                    {

                        TextBox24Both.Text = ds.Tables[0].Rows[0]["rateperunitsMonth1Both_new"].ToString();
                        TextBox51Both.Text = ds.Tables[0].Rows[0]["rateperunitsMonth2Both_new"].ToString();
                        TextBox64Both.Text = ds.Tables[0].Rows[0]["rateperunitsMonth3Both_new"].ToString();
                        TextBox72Both.Text = ds.Tables[0].Rows[0]["rateperunitsMonth4Both_new"].ToString();
                        TextBox80Both.Text = ds.Tables[0].Rows[0]["rateperunitsMonth5Both_new"].ToString();
                        TextBox88Both.Text = ds.Tables[0].Rows[0]["rateperunitsMonth6Both_new"].ToString();
                    }

                    TextBox25.Text = ds.Tables[0].Rows[0]["amountPaidMonth1_new"].ToString();
                    TextBox52.Text = ds.Tables[0].Rows[0]["amountPaidMonth2_new"].ToString();
                    TextBox65.Text = ds.Tables[0].Rows[0]["amountPaidMonth3_new"].ToString();
                    TextBox73.Text = ds.Tables[0].Rows[0]["amountPaidMonth4_new"].ToString();
                    TextBox81.Text = ds.Tables[0].Rows[0]["amountPaidMonth5_new"].ToString();
                    TextBox89.Text = ds.Tables[0].Rows[0]["amountPaidMonth6_new"].ToString();
                    if (ds.Tables[0].Rows[0]["bothOrnot"].ToString() == "Y")
                    {
                        TextBox25Both.Text = ds.Tables[0].Rows[0]["amountPaidMonth1Both_new"].ToString();
                        TextBox52Both.Text = ds.Tables[0].Rows[0]["amountPaidMonth2Both_new"].ToString();
                        TextBox65Both.Text = ds.Tables[0].Rows[0]["amountPaidMonth3Both_new"].ToString();
                        TextBox73Both.Text = ds.Tables[0].Rows[0]["amountPaidMonth4Both_new"].ToString();
                        TextBox81Both.Text = ds.Tables[0].Rows[0]["amountPaidMonth5Both_new"].ToString();
                        TextBox89Both.Text = ds.Tables[0].Rows[0]["amountPaidMonth6Both_new"].ToString();
                    }

                    TextBox21.Text = ds.Tables[0].Rows[0]["eligiblerateunitMonth1_new"].ToString();
                    TextBox22.Text = ds.Tables[0].Rows[0]["eligiblerateunitMonth2_new"].ToString();
                    TextBox26.Text = ds.Tables[0].Rows[0]["eligiblerateunitMonth3_new"].ToString();
                    TextBox27.Text = ds.Tables[0].Rows[0]["eligiblerateunitMonth4_new"].ToString();
                    TextBox95.Text = ds.Tables[0].Rows[0]["eligiblerateunitMonth5_new"].ToString();
                    TextBox96.Text = ds.Tables[0].Rows[0]["eligiblerateunitMonth6_new"].ToString();

                    if (ds.Tables[0].Rows[0]["bothOrnot"].ToString() == "Y")
                    {
                        TextBox21Both.Text = ds.Tables[0].Rows[0]["eligiblerateunitMonth1Both_new"].ToString();
                        TextBox22Both.Text = ds.Tables[0].Rows[0]["eligiblerateunitMonth2Both_new"].ToString();
                        TextBox26Both.Text = ds.Tables[0].Rows[0]["eligiblerateunitMonth3Both_new"].ToString();
                        TextBox27Both.Text = ds.Tables[0].Rows[0]["eligiblerateunitMonth4Both_new"].ToString();
                        TextBox95Both.Text = ds.Tables[0].Rows[0]["eligiblerateunitMonth5Both_new"].ToString();
                        TextBox96Both.Text = ds.Tables[0].Rows[0]["eligiblerateunitMonth6Both_new"].ToString();
                    }


                    TextBox28.Text = ds.Tables[0].Rows[0]["eligiblerateamountMonth1_new"].ToString();
                    TextBox29.Text = ds.Tables[0].Rows[0]["eligiblerateamountMonth2_new"].ToString();
                    TextBox49.Text = ds.Tables[0].Rows[0]["eligiblerateamountMonth3_new"].ToString();
                    TextBox53.Text = ds.Tables[0].Rows[0]["eligiblerateamountMonth4_new"].ToString();
                    TextBox54.Text = ds.Tables[0].Rows[0]["eligiblerateamountMonth5_new"].ToString();
                    TextBox55.Text = ds.Tables[0].Rows[0]["eligiblerateamountMonth6_new"].ToString();
                    if (ds.Tables[0].Rows[0]["bothOrnot"].ToString() == "Y")
                    {
                        TextBox28Both.Text = ds.Tables[0].Rows[0]["eligiblerateamountMonth1Both_new"].ToString();
                        TextBox29Both.Text = ds.Tables[0].Rows[0]["eligiblerateamountMonth2Both_new"].ToString();
                        TextBox49Both.Text = ds.Tables[0].Rows[0]["eligiblerateamountMonth3Both_new"].ToString();
                        TextBox53Both.Text = ds.Tables[0].Rows[0]["eligiblerateamountMonth4Both_new"].ToString();
                        TextBox54Both.Text = ds.Tables[0].Rows[0]["eligiblerateamountMonth5Both_new"].ToString();
                        TextBox55Both.Text = ds.Tables[0].Rows[0]["eligiblerateamountMonth6Both_new"].ToString();
                    }


                    lblGmAmount0.Text = ds.Tables[0].Rows[0]["totaleligibleamount_new"].ToString();
                    lblTotalEligibleAm0.Text = ds.Tables[0].Rows[0]["isbelated_new"].ToString();
                    lblTotalEligibleAm.Text = ds.Tables[0].Rows[0]["totaleligible_fin"].ToString();
                    lblGmAmount.Text = ds.Tables[0].Rows[0]["GM_Rcon_Amount"].ToString();
                    lblremarks_powernew.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();

                    if (ds.Tables[0].Rows[0]["bothOrnot"].ToString() == "Y")
                    {
                        lblGmAmount0Both.Text = ds.Tables[0].Rows[0]["totaleligibleamountBoth_new"].ToString();
                        lblTotalEligibleAm0Both.Text = ds.Tables[0].Rows[0]["isbelatedBoth_new"].ToString();
                        if (ds.Tables[0].Rows[0]["isbelatedBoth_new"].ToString() == "Y")
                        {
                            lblTotalEligibleAm0Both.Text = "Regular";
                        }
                        if (ds.Tables[0].Rows[0]["isbelatedBoth_new"].ToString() != "Y")
                        {
                            lblTotalEligibleAm0Both.Text = "Belated";
                        }
                        lblTotalEligibleAmBoth.Text = ds.Tables[0].Rows[0]["totaleligibleamountBoth_new"].ToString();
                        lblGmAmountBoth.Text = ds.Tables[0].Rows[0]["GM_Rcon_Amount"].ToString();
                        lblremarks_powernewBoth.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                    }

                    //										





                }
                if (ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() == "Expansion" || ds.Tables[0].Rows[0]["IdsustryStatus"].ToString() == "Diversification")
                {
                    tbl_monthyeardataExpansion.Visible = true;
                    tblNewUnit.Visible = false;
                    lblSancIncentiveName.Text = "Sanction of Reimbursement of Power Cost";
                    txt_grdmonthyear1.Text = ds.Tables[0].Rows[0]["finyear1_expn"].ToString();
                    txt_grdmonthyear2.Text = ds.Tables[0].Rows[0]["finyear2_expn"].ToString();
                    txt_grdmonthyear3.Text = ds.Tables[0].Rows[0]["finyear3_expn"].ToString();
                    txt_grdmonthyear4.Text = ds.Tables[0].Rows[0]["finyear4_expn"].ToString();
                    txt_grdmonthyear5.Text = ds.Tables[0].Rows[0]["finyear5_expn"].ToString();
                    txt_grdmonthyear6.Text = ds.Tables[0].Rows[0]["finyear6_expn"].ToString();

                    txt_grdyear1unitsconsumed.Text = ds.Tables[0].Rows[0]["finyearMonth1_expn"].ToString();
                    txt_grdyear2unitsconsumed.Text = ds.Tables[0].Rows[0]["finyearMonth2_expn"].ToString();
                    txt_grdyear3unitsconsumed.Text = ds.Tables[0].Rows[0]["finyearMonth3_expn"].ToString();
                    txt_grdyear4unitsconsumed.Text = ds.Tables[0].Rows[0]["finyearMonth4_expn"].ToString();
                    txt_grdyear5unitsconsumed.Text = ds.Tables[0].Rows[0]["finyearMonth5_expn"].ToString();
                    txt_grdyear6unitsconsumed.Text = ds.Tables[0].Rows[0]["finyearMonth6_expn"].ToString();

                    txt_grdyear1rateperunit.Text = ds.Tables[0].Rows[0]["unitsconsumedMonth1_expn"].ToString();
                    txt_grdyear2rateperunit.Text = ds.Tables[0].Rows[0]["unitsconsumedMonth2_expn"].ToString();
                    txt_grdyear3rateperunit.Text = ds.Tables[0].Rows[0]["unitsconsumedMonth3_expn"].ToString();
                    txt_grdyear4rateperunit.Text = ds.Tables[0].Rows[0]["unitsconsumedMonth4_expn"].ToString();
                    txt_grdyear5rateperunit.Text = ds.Tables[0].Rows[0]["unitsconsumedMonth5_expn"].ToString();
                    txt_grdyear6rateperunit.Text = ds.Tables[0].Rows[0]["unitsconsumedMonth6_expn"].ToString();

                    txt_grdyear1amountpaid.Text = ds.Tables[0].Rows[0]["rateperunitsMonth1_expn"].ToString();
                    txt_grdyear2amountpaid.Text = ds.Tables[0].Rows[0]["rateperunitsMonth2_expn"].ToString();
                    txt_grdyear3amountpaid.Text = ds.Tables[0].Rows[0]["rateperunitsMonth3_expn"].ToString();
                    txt_grdyear4amountpaid.Text = ds.Tables[0].Rows[0]["rateperunitsMonth4_expn"].ToString();
                    txt_grdyear5amountpaid.Text = ds.Tables[0].Rows[0]["rateperunitsMonth5_expn"].ToString();
                    txt_grdyear6amountpaid.Text = ds.Tables[0].Rows[0]["rateperunitsMonth6_expn"].ToString();

                    txt_grdyear1basefixedunitspermonth.Text = ds.Tables[0].Rows[0]["amountPaidMonth1_expn"].ToString();
                    txt_grdyear2basefixedunitspermonth.Text = ds.Tables[0].Rows[0]["amountPaidMonth2_expn"].ToString();
                    txt_grdyear3basefixedunitspermonth.Text = ds.Tables[0].Rows[0]["amountPaidMonth3_expn"].ToString();
                    txt_grdyear4basefixedunitspermonth.Text = ds.Tables[0].Rows[0]["amountPaidMonth4_expn"].ToString();
                    txt_grdyear5basefixedunitspermonth.Text = ds.Tables[0].Rows[0]["amountPaidMonth5_expn"].ToString();
                    txt_grdyear6basefixedunitspermonth.Text = ds.Tables[0].Rows[0]["amountPaidMonth6_expn"].ToString();

                    txt_grdyear1eligibleunits.Text = ds.Tables[0].Rows[0]["basefixedpermonth1_expn"].ToString();
                    txt_grdyear2eligibleunits.Text = ds.Tables[0].Rows[0]["basefixedpermonth2_expn"].ToString();
                    txt_grdyear3eligibleunits.Text = ds.Tables[0].Rows[0]["basefixedpermonth3_expn"].ToString();
                    txt_grdyear4eligibleunits.Text = ds.Tables[0].Rows[0]["basefixedpermonth4_expn"].ToString();
                    txt_grdyear5eligibleunits.Text = ds.Tables[0].Rows[0]["basefixedpermonth5_expn"].ToString();
                    txt_grdyear6eligibleunits.Text = ds.Tables[0].Rows[0]["basefixedpermonth6_expn"].ToString();

                    txt_grdyear1eligiblerateofreimbursement.Text = ds.Tables[0].Rows[0]["eligibleunitsover1_expn"].ToString();
                    txt_grdyear2eligiblerateofreimbursement.Text = ds.Tables[0].Rows[0]["eligibleunitsover2_expn"].ToString();
                    txt_grdyear3eligiblerateofreimbursement.Text = ds.Tables[0].Rows[0]["eligibleunitsover3_expn"].ToString();
                    txt_grdyear4eligiblerateofreimbursement.Text = ds.Tables[0].Rows[0]["eligibleunitsover4_expn"].ToString();
                    txt_grdyear5eligiblerateofreimbursement.Text = ds.Tables[0].Rows[0]["eligibleunitsover5_expn"].ToString();
                    txt_grdyear6eligiblerateofreimbursement.Text = ds.Tables[0].Rows[0]["eligibleunitsover6_expn"].ToString();

                    txt_grdyear1eligibleamountforreimbursement.Text = ds.Tables[0].Rows[0]["eligiblerateforreimbursementperunits1_expn"].ToString();
                    txt_grdyear2eligibleamountforreimbursement.Text = ds.Tables[0].Rows[0]["eligiblerateforreimbursementperunits2_expn"].ToString();
                    txt_grdyear3eligibleamountforreimbursement.Text = ds.Tables[0].Rows[0]["eligiblerateforreimbursementperunits3_expn"].ToString();
                    txt_grdyear4eligibleamountforreimbursement.Text = ds.Tables[0].Rows[0]["eligiblerateforreimbursementperunits4_expn"].ToString();
                    txt_grdyear5eligibleamountforreimbursement.Text = ds.Tables[0].Rows[0]["eligiblerateforreimbursementperunits5_expn"].ToString();
                    txt_grdyear6eligibleamountforreimbursement.Text = ds.Tables[0].Rows[0]["eligiblerateforreimbursementperunits6_expn"].ToString();

                    TextBox75.Text = ds.Tables[0].Rows[0]["eligibleamountforreimbursementperunits1_expn"].ToString();
                    TextBox76.Text = ds.Tables[0].Rows[0]["eligibleamountforreimbursementperunits2_expn"].ToString();
                    TextBox77.Text = ds.Tables[0].Rows[0]["eligibleamountforreimbursementperunits3_expn"].ToString();
                    TextBox78.Text = ds.Tables[0].Rows[0]["eligibleamountforreimbursementperunits4_expn"].ToString();
                    TextBox82.Text = ds.Tables[0].Rows[0]["eligibleamountforreimbursementperunits5_expn"].ToString();
                    TextBox83.Text = ds.Tables[0].Rows[0]["eligibleamountforreimbursementperunits6_expn"].ToString();

                    Label1.Text = ds.Tables[0].Rows[0]["totaleligibleamount_expn"].ToString();
                    Label2.Text = ds.Tables[0].Rows[0]["isbelated_expn"].ToString();
                    Label3.Text = ds.Tables[0].Rows[0]["totaleligibleamount_expn_belated"].ToString();
                    Label4.Text = ds.Tables[0].Rows[0]["GM_Rcon_Amount"].ToString();
                    lblremarks_monthyearexp.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();

                }

            }
            if (MasterIncentiveId == "1")
            {
                //Pallavaddi 
                div_pallavaddi.Visible = true;
                Div3.Visible = false;
                USP_GETDETAILSFORSECTION(Convert.ToString(Request.QueryString["incid"]));
                //string incid = Request.QueryString["incid"].ToString();
                lblSancIncentiveName.Text = "Sanction of Pavala Vaddi";
            }
            if (MasterIncentiveId == "4")   // Specific Cleaner Production measures
            {
                Div3.Visible = false;
                //trAsperDecisionIS.Visible = false;
                divLandconversion.Visible = false;
                divmortgage.Visible = false;
                divlandcost.Visible = false;
                divStampduty.Visible = false;
                divspecificcleaner.Visible = true;

                lblExpenditure.Text = ds.Tables[0].Rows[0]["ExpenditureIncurred"].ToString();
                lblExpenditure25.Text = ds.Tables[0].Rows[0]["ExpenditureIncurred_25prcnt"].ToString();

                //lblLCEligibleLandCost.Text = ds.Tables[0].Rows[0]["ELIGIBLELANDCOST"].ToString();
                //lblLcLandPurchase.Text = ds.Tables[0].Rows[0]["LANDPURCHASE"].ToString();
                //lblLCLandvalue.Text = ds.Tables[0].Rows[0]["LANDVALUE"].ToString();
                //lblLCPlnthArea.Text = ds.Tables[0].Rows[0]["BuildingPlinth"].ToString();
                //lblLCfiveTimes.Text = ds.Tables[0].Rows[0]["TotalBuildingPlinth_CALCULATED"].ToString();
                //lblLCProportionate.Text = ds.Tables[0].Rows[0]["Proportionatearea"].ToString();
                lblgmspecific.Text = ds.Tables[0].Rows[0]["GMValue"].ToString();
                lvlfinalpecific.Text = ds.Tables[0].Rows[0]["FINALELIGIBLESPECIFICCLEANER"].ToString();

                //lblLCfiveTimes
                //lblLcLandPurchase
                lblSancIncentiveName.Text = "Sanction of Specific Cleaner Production measures";


            }
        }


        public void USP_GETDETAILSFORSECTION(string IncentiveId)
        {
            DataSet ds = DB_apprasialnote2pallavaddi(IncentiveId, "");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //MstIncentiveId = "1";

                        //txt_eglsacamountinterestreimbursement.Text = Convert.ToString(ds.Tables[0].Rows[0]["ELIGIBLESANCTIONEDAMOUNT"]);
                        //ddl_ClaimPeriod.Text = Convert.ToString(ds.Tables[0].Rows[0]["CLAIMPERIOD"]);
                        //txt_DateofCommencementofactivity.Text = Convert.ToString(ds.Tables[0].Rows[0]["DATEOFCOMMENCEMENTOFACTIVITY"]);
                        //txt_Eligibleperiodinmonths.Text = Convert.ToString(ds.Tables[0].Rows[0]["INSTALMENTPERIOD"]);
                        //txt_noofinstallment.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOOFINSTALMENTS"]);
                        //txt_Installmentamount.Text = Convert.ToString(ds.Tables[0].Rows[0]["INSTALMENTAMOUNT"]);
                        //txt_installmentstartdate.Text = Convert.ToString(ds.Tables[0].Rows[0]["INSTALMENTSTARTMONTHYEAR_ID"]);
                        //txt_RateofInterest.Text = Convert.ToString(ds.Tables[0].Rows[0]["RATEOFINTEREST"]);
                        //txt_Eligiblerateofreimbursement.Text = Convert.ToString(ds.Tables[0].Rows[0]["ELIGIBLERATEOFREUMBERSEMENT"]);
                        //txt_Noofinstallmentscompleted.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOOFINSTALMENTS_COMPLETED"]);
                        //txt_PrincipalamountbecomeDUEbeforethisHALFYEAR.Text = Convert.ToString(ds.Tables[0].Rows[0]["PRINCIPALAMOUNTBECOMEDUE_BEFORETHISHALFYEAR"]);
                        //txt_Insertamounttobepaidaspercalculations.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTAMOUNT_TOBEPAIDASPERCALCULATIONS"]);
                        //txt_Actualinterestamountpaid.Text = Convert.ToString(ds.Tables[0].Rows[0]["ACTUALINTERESTAMOUNT_PAID"]);
                        //txt_Insertreimbursementcalculated.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTREIMBURSEMENTCALCULATED"]);
                        //txt_Insertreimbursementcalculated.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTREIMBURSEMENTCALCULATED_FINAL"]);
                        //txt_GMrecommendedamount.Text = Convert.ToString(ds.Tables[0].Rows[0]["GMRECOMMENDEDAMOUNT"]);
                        //txt_Eligibleamount.Text = Convert.ToString(ds.Tables[0].Rows[0]["FINALELIGIBLEAMOUNT"]);
                        ////rbtgrd_isbelated.Text = Convert.ToString(ds.Tables[0].Rows[0]["EglibleTypeName"]);
                        //txt_eglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTREIMBURSEMENTCALCULATEDaftereglibletype"]);
                        ////ddl_periodofinstallment.Text = Convert.ToString(ds.Tables[0].Rows[0]["PERIODOFINSTALMENTName"]);


                        txt_Insertamounttobepaidaspercalculations.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTAMOUNT_TOBEPAIDASPERCALCULATIONS"]);
                        txt_Actualinterestamountpaid.Text = Convert.ToString(ds.Tables[0].Rows[0]["ACTUALINTERESTAMOUNT_PAID"]);
                        txt_ConsideredAmountofInterest.Text = Convert.ToString(ds.Tables[0].Rows[0]["Conreburismentamount"]);
                        txt_Insertreimbursementcalculated.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTREIMBURSEMENTCALCULATED"]);
                        txt_Insertreimbursementcalculated.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTREIMBURSEMENTCALCULATED_FINAL"]);
                        txt_GMrecommendedamount.Text = Convert.ToString(ds.Tables[0].Rows[0]["GMRECOMMENDEDAMOUNT"]);
                        txt_Eligibleamount.Text = Convert.ToString(ds.Tables[0].Rows[0]["FINALELIGIBLEAMOUNT"]);

                        txt_eglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTREIMBURSEMENTCALCULATEDaftereglibletype"]);
                        lbl_pavallavaddiremarksbyclerk.Text = Convert.ToString(ds.Tables[0].Rows[0]["Remarks"]);
                    }

                    if (ds.Tables.Count >= 1)
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            //grd_financalyeargrid.DataSource = ds.Tables[1];
                            //grd_financalyeargrid.DataBind();
                        }

                    }

                    grd_claimperiodofloanadd.Visible = false;
                    if (ds.Tables.Count >= 3)
                    {
                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            grd_claimperiodofloanadd.DataSource = ds.Tables[3];
                            grd_claimperiodofloanadd.DataBind();
                            grd_claimperiodofloanadd.Visible = true;
                        }

                    }
                    grd_eglibilepallavaddi.Visible = false;
                    if (ds.Tables.Count >= 4)
                    {
                        if (ds.Tables[4].Rows.Count > 0)
                        {
                            grd_eglibilepallavaddi.Visible = true;
                            grd_eglibilepallavaddi.DataSource = ds.Tables[4];
                            grd_eglibilepallavaddi.DataBind();
                        }

                    }
                }
            }
        }
        protected void grd_financalyeargrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string CLAIMPERIOD_Grid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CLAIMPERIOD_Grid"));
                // string CLAIMPERIOD_Grid = grd_financalyeargrid.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView grd_Addclaimperiod = e.Row.FindControl("grd_Addclaimperiod") as GridView;
                DataSet ds_data = DB_apprasialnote2pallavaddi(Convert.ToString(Request.QueryString["incid"]), CLAIMPERIOD_Grid);
                if (ds_data != null)
                {
                    if (ds_data.Tables.Count > 0)
                    {
                        if (ds_data.Tables.Count >= 2)
                        {
                            if (ds_data.Tables[2].Rows.Count > 0)
                            {
                                grd_Addclaimperiod.DataSource = ds_data.Tables[2];
                                grd_Addclaimperiod.DataBind();
                            }

                        }
                    }
                }
            }
        }

        public DataSet DB_apprasialnote2pallavaddi(string IncentiveId, string CLAIMPERIOD_Grid)
        {
            try
            {
                SqlConnection osqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TSiPASSSkils"].ConnectionString);
                osqlConnection.Open();
                SqlDataAdapter da;
                da = new SqlDataAdapter("pv_apprasialnote2pallavaddi", osqlConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                if (IncentiveId.Trim() == "" || IncentiveId.Trim() == null)
                    da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = IncentiveId.ToString();
                if (CLAIMPERIOD_Grid.Trim() == "" || CLAIMPERIOD_Grid.Trim() == null)
                    da.SelectCommand.Parameters.Add("@CLAIMPERIOD_Grid", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    da.SelectCommand.Parameters.Add("@CLAIMPERIOD_Grid", SqlDbType.VarChar).Value = CLAIMPERIOD_Grid.ToString();


                da.Fill(ds);
                return ds;



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }
}