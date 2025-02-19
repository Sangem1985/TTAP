using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class PowerSubsidyAppraisalPrint : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPowerSubsidy();
            }
        }
        public void BindPowerSubsidy()
        {
            try
            {
               // string IncentiveId = Request.QueryString["incid"].ToString();
                string IncentiveId = "18157";
                DataSet dsnew = new DataSet();
                dsnew = GetPowerSubsidyDtls(IncentiveId);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    lblUnitName.Text = dsnew.Tables[0].Rows[0]["UNIT_NAME"].ToString();
                    lblAddress.Text = dsnew.Tables[0].Rows[0]["UNIT_ADDRESS"].ToString();
                    lblProprietor.Text = dsnew.Tables[0].Rows[0]["PROPRIETOR_NAME"].ToString();
                    lblConstitutionOfIndustrial.Text = dsnew.Tables[0].Rows[0]["ORGANIZATION_CONSTITUTION"].ToString();
                    lblSocialStatus.Text = dsnew.Tables[0].Rows[0]["SOCIAL_STATUS"].ToString();
                    lblShareofSCSTWomenEnterprenue.Text = dsnew.Tables[0].Rows[0]["SC_ST_WOMEN"].ToString();
                    lblRegistrationNumber.Text = dsnew.Tables[0].Rows[0]["REG_NUMBER"].ToString();
                    lblTypeofApplicant.Text = dsnew.Tables[0].Rows[0]["TYPE_OF_UNIT"].ToString();
                    

                    lblCategoryofUnit.Text = dsnew.Tables[0].Rows[0]["CATEGORY"].ToString();
                    lblApplicationDateDIC.Text = dsnew.Tables[0].Rows[0]["TYPE_OF_SECTOR"].ToString();
                    lblTypeofTexttile.Text = dsnew.Tables[0].Rows[0]["TYPE_OF_TEXTILE"].ToString();
                    lblTechnicalTextileType.Text = dsnew.Tables[0].Rows[0]["TECHNICAL_TEXTILE_TYPE"].ToString();
                    lblActivityoftheUnit.Text = dsnew.Tables[0].Rows[0]["NATURE_OF_INDUSTRY"].ToString();
                    lblUIDNumber.Text = dsnew.Tables[0].Rows[0]["UID_NO"].ToString();
                    lblCommonApplicationNumber.Text = dsnew.Tables[0].Rows[0]["APPLICATION_NO"].ToString();
                    lblPowerConnectionReleaseDate.Text = dsnew.Tables[0].Rows[0]["POWER_CON_RELEASE_DT"].ToString();
                    lblDCPdate.Text = dsnew.Tables[0].Rows[0]["DCP"].ToString();
                    lblReceiptDate.Text = dsnew.Tables[0].Rows[0]["APPLIED_DATE"].ToString();
                    lblelbPromoter.Text = dsnew.Tables[0].Rows[0]["TYPE_OF_TEXTILE_INS"].ToString();


                    lblAmount.Text = dsnew.Tables[0].Rows[0]["TOTAL_AMOUNT"].ToString();
                    lblBelated.Text = dsnew.Tables[0].Rows[0]["ELIGIBILITY_TYPE"].ToString();
                    lblEligibletotal.Text = dsnew.Tables[0].Rows[0]["TOTAL_ELIGIBLE_AMOUNT"].ToString();
                    lblGMRecommend.Text = dsnew.Tables[0].Rows[0]["GM_REC_AMOUNT"].ToString();
                    lblDepartment.Text = dsnew.Tables[0].Rows[0]["FINAL_ELIGIBLE_AMOUNT"].ToString();
                    string worksheetPath = dsnew.Tables[0].Rows[0]["WORKSHEET_PATH"].ToString().Trim();
                  //  hypworksheet.NavigateUrl = dsnew.Tables[0].Rows[0]["WORKSHEET_PATH"].ToString();

                    if (string.IsNullOrEmpty(worksheetPath))
                    {
                        worksheet.Visible = false;
                        hypworksheet.Visible = false;
                    }
                    else
                    {
                        worksheet.Visible = true;
                        hypworksheet.NavigateUrl = worksheetPath;
                        hypworksheet.Visible = true;
                    }

                    if (lblTypeofApplicant.Text == "New Industry")
                   {
                        Claimperiod.Visible = true;
                        units.Visible = true;
                        MonthWise.Visible = true;

                        Year1.Text = dsnew.Tables[0].Rows[0]["LAST3FINANCIALYEAR1"].ToString();
                        Unit1.Text = dsnew.Tables[0].Rows[0]["LAST3UTILISEDUNITS1"].ToString();
                        RateUnit1.Text = dsnew.Tables[0].Rows[0]["LAST3RATEPERUNIT1"].ToString();
                        Total1.Text = dsnew.Tables[0].Rows[0]["LAST3TOTALPAID1"].ToString();

                        Year2.Text = dsnew.Tables[0].Rows[0]["LAST3FINANCIALYEAR2"].ToString();
                        Unit2.Text = dsnew.Tables[0].Rows[0]["LAST3UTILISEDUNITS2"].ToString();
                        RateUnit2.Text = dsnew.Tables[0].Rows[0]["LAST3RATEPERUNIT2"].ToString();
                        Total2.Text = dsnew.Tables[0].Rows[0]["LAST3TOTALPAID2"].ToString();

                        Year3.Text = dsnew.Tables[0].Rows[0]["LAST3FINANCIALYEAR3"].ToString();
                        Unit3.Text = dsnew.Tables[0].Rows[0]["LAST3UTILISEDUNITS3"].ToString();
                        RateUnit3.Text = dsnew.Tables[0].Rows[0]["LAST3RATEPERUNIT3"].ToString();
                        Total3.Text = dsnew.Tables[0].Rows[0]["LAST3TOTALPAID3"].ToString();

                        lblConsume3year.Text = dsnew.Tables[0].Rows[0]["UNITSCONSUMEDPRIOR3YRS"].ToString();
                        lblEMUnits.Text = dsnew.Tables[0].Rows[0]["AVGUNITSEM"].ToString();
                        lblFixedYear.Text = dsnew.Tables[0].Rows[0]["BASEPOWERCONSUMPTION"].ToString();
                        lblMonth.Text = dsnew.Tables[0].Rows[0]["PERMONTH"].ToString();

                        Month1.Text = dsnew.Tables[0].Rows[0]["BASEFIXEDPERMONTH1"].ToString();
                        Financial1.Text = dsnew.Tables[0].Rows[0]["FINANCIAL_YEAR"].ToString();
                        ConsumedNO1.Text = dsnew.Tables[0].Rows[0]["UNITS_CONSUMED1"].ToString();
                        AmountBill1.Text = dsnew.Tables[0].Rows[0]["PAID_BILL_AMOUNT1"].ToString();
                        FixedMonth1.Text = dsnew.Tables[0].Rows[0]["BASEFIXEDPERMONTH1"].ToString();
                        EligibleUnits1.Text = dsnew.Tables[0].Rows[0]["ELIGIBLEUNITSABOVEBASE1"].ToString();
                        Reimbursement1.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_RATE1"].ToString();
                        Eligibleamount1.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_AMOUNT1"].ToString();


                        Month2.Text = dsnew.Tables[0].Rows[0]["BASEFIXEDPERMONTH2"].ToString();
                        Financial2.Text = dsnew.Tables[0].Rows[0]["FINANCIAL_YEAR"].ToString();
                        ConsumedNO2.Text = dsnew.Tables[0].Rows[0]["UNITS_CONSUMED2"].ToString();
                        AmountBill2.Text = dsnew.Tables[0].Rows[0]["PAID_BILL_AMOUNT2"].ToString();
                        FixedMonth2.Text = dsnew.Tables[0].Rows[0]["BASEFIXEDPERMONTH2"].ToString();
                        EligibleUnits2.Text = dsnew.Tables[0].Rows[0]["ELIGIBLEUNITSABOVEBASE2"].ToString();
                        Reimbursement2.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_RATE2"].ToString();
                        Eligibleamount2.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_AMOUNT2"].ToString();

                        Month3.Text = dsnew.Tables[0].Rows[0]["BASEFIXEDPERMONTH3"].ToString();
                        Financial3.Text = dsnew.Tables[0].Rows[0]["FINANCIAL_YEAR"].ToString();
                        ConsumedNO3.Text = dsnew.Tables[0].Rows[0]["UNITS_CONSUMED3"].ToString();
                        AmountBill3.Text = dsnew.Tables[0].Rows[0]["PAID_BILL_AMOUNT3"].ToString();
                        FixedMonth3.Text = dsnew.Tables[0].Rows[0]["BASEFIXEDPERMONTH3"].ToString();
                        EligibleUnits3.Text = dsnew.Tables[0].Rows[0]["ELIGIBLEUNITSABOVEBASE3"].ToString();
                        Reimbursement3.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_RATE3"].ToString();
                        Eligibleamount3.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_AMOUNT3"].ToString();

                        Month4.Text = dsnew.Tables[0].Rows[0]["BASEFIXEDPERMONTH4"].ToString();
                        Financial4.Text = dsnew.Tables[0].Rows[0]["FINANCIAL_YEAR"].ToString();
                        ConsumedNO4.Text = dsnew.Tables[0].Rows[0]["UNITS_CONSUMED4"].ToString();
                        AmountBill4.Text = dsnew.Tables[0].Rows[0]["PAID_BILL_AMOUNT4"].ToString();
                        FixedMonth4.Text = dsnew.Tables[0].Rows[0]["BASEFIXEDPERMONTH4"].ToString();
                        EligibleUnits4.Text = dsnew.Tables[0].Rows[0]["ELIGIBLEUNITSABOVEBASE4"].ToString();
                        Reimbursement4.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_RATE4"].ToString();
                        Eligibleamount4.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_AMOUNT4"].ToString();

                        Month5.Text = dsnew.Tables[0].Rows[0]["BASEFIXEDPERMONTH5"].ToString();
                        Financial5.Text = dsnew.Tables[0].Rows[0]["FINANCIAL_YEAR"].ToString();
                        ConsumedNO5.Text = dsnew.Tables[0].Rows[0]["UNITS_CONSUMED5"].ToString();
                        AmountBill5.Text = dsnew.Tables[0].Rows[0]["PAID_BILL_AMOUNT5"].ToString();
                        FixedMont5.Text = dsnew.Tables[0].Rows[0]["BASEFIXEDPERMONTH5"].ToString();
                        EligibleUnits5.Text = dsnew.Tables[0].Rows[0]["ELIGIBLEUNITSABOVEBASE5"].ToString();
                        Reimbursement5.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_RATE5"].ToString();
                        Eligibleamount5.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_AMOUNT5"].ToString();

                        Month6.Text = dsnew.Tables[0].Rows[0]["BASEFIXEDPERMONTH6"].ToString();
                        Financial6.Text = dsnew.Tables[0].Rows[0]["FINANCIAL_YEAR"].ToString();
                        ConsumedNO6.Text = dsnew.Tables[0].Rows[0]["UNITS_CONSUMED6"].ToString();
                        AmountBill6.Text = dsnew.Tables[0].Rows[0]["PAID_BILL_AMOUNT6"].ToString();
                        FixedMonth6.Text = dsnew.Tables[0].Rows[0]["BASEFIXEDPERMONTH6"].ToString();
                        EligibleUnits6.Text = dsnew.Tables[0].Rows[0]["ELIGIBLEUNITSABOVEBASE6"].ToString();
                        Reimbursement6.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_RATE6"].ToString();
                        Eligibleamount6.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_AMOUNT6"].ToString();
                    }
                    else
                    {
                        EligibleINC.Visible = true;

                        lblMonth1.Text = dsnew.Tables[0].Rows[0]["MONTH1"].ToString();
                        lblMonth2.Text = dsnew.Tables[0].Rows[0]["MONTH2"].ToString();
                        lblMonth3.Text = dsnew.Tables[0].Rows[0]["MONTH3"].ToString();
                        lblMonth4.Text = dsnew.Tables[0].Rows[0]["MONTH4"].ToString();
                        lblMonth5.Text = dsnew.Tables[0].Rows[0]["MONTH5"].ToString();
                        lblMonth6.Text = dsnew.Tables[0].Rows[0]["MONTH6"].ToString();

                        lblLand_ProjectCost.Text = dsnew.Tables[0].Rows[0]["UNITS_CONSUMED1"].ToString();
                        lblBuilding_ProjectCost.Text = dsnew.Tables[0].Rows[0]["UNITS_CONSUMED2"].ToString();
                        lblPlantMachry_ProjectCost.Text = dsnew.Tables[0].Rows[0]["UNITS_CONSUMED3"].ToString();
                        lblFeasibilityStudyCharges_ProjectCost.Text = dsnew.Tables[0].Rows[0]["UNITS_CONSUMED4"].ToString();
                        lblVehicles_ProjectCost.Text = dsnew.Tables[0].Rows[0]["UNITS_CONSUMED5"].ToString();
                        lblOthersEligible_ProjectCost.Text = dsnew.Tables[0].Rows[0]["UNITS_CONSUMED6"].ToString();

                        lblLand_ValueRecommendedByGM.Text = dsnew.Tables[0].Rows[0]["PAID_BILL_AMOUNT1"].ToString();
                        lblBuilding_ValueRecommendedByGM.Text = dsnew.Tables[0].Rows[0]["PAID_BILL_AMOUNT2"].ToString();
                        lblPlantMachry_ValueRecommendedByGM.Text = dsnew.Tables[0].Rows[0]["PAID_BILL_AMOUNT3"].ToString();
                        lblFeasibilityStudyCharges_ValueRecommendedByGM.Text = dsnew.Tables[0].Rows[0]["PAID_BILL_AMOUNT4"].ToString();
                        lblVehicles_ValueRecommendedByGM.Text = dsnew.Tables[0].Rows[0]["PAID_BILL_AMOUNT5"].ToString();
                        lblOthersEligible_ValueRecommendedByGM.Text = dsnew.Tables[0].Rows[0]["PAID_BILL_AMOUNT6"].ToString();

                        lblLandComputed.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_RATE1"].ToString();
                        lblBuildingComputed.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_RATE2"].ToString();
                        lblPlantMachryComputed.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_RATE3"].ToString();
                        lblFeasibilityStudyChargesComputed.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_RATE4"].ToString();
                        lblVehiclesComputed.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_RATE5"].ToString();
                        lblOthersEligibleComputed.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_RATE6"].ToString();

                        lblLand_GMRec.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_AMOUNT1"].ToString();
                        lblBuilding_GMRec.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_AMOUNT2"].ToString();
                        lblPlantMachry_GMRec.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_AMOUNT3"].ToString();
                        lblFeasibilityStudyCharges_GMRec.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_AMOUNT4"].ToString();
                        lblVehicles_GMRec.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_AMOUNT5"].ToString();
                        lblOthersEligible_GMRec.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_AMOUNT6"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetPowerSubsidyDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
               //new SqlParameter("@MasterIncentiveId",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            // pp[1].Value = MasterIncentiveId;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GETTBL_APPRAISAL_POWERSUBSIDY", pp);
            return Dsnew;
        }
    }
}