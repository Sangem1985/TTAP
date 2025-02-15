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
                string IncentiveId = Request.QueryString["incid"].ToString();
                string MasterIncentiveId = Request.QueryString["mstid"].ToString();
                DataSet dsnew = new DataSet();
                dsnew = GetPowerSubsidyDtls(IncentiveId, MasterIncentiveId);

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


                    lblAmount.Text = dsnew.Tables[0].Rows[0]["TOTAL_AMOUNT"].ToString();
                    lblBelated.Text = dsnew.Tables[0].Rows[0]["ELIGIBILITY_TYPE"].ToString();
                    lblEligibletotal.Text = dsnew.Tables[0].Rows[0]["TOTAL_ELIGIBLE_AMOUNT"].ToString();
                    lblGMRecommend.Text = dsnew.Tables[0].Rows[0]["GM_REC_AMOUNT"].ToString();
                    lblDepartment.Text = dsnew.Tables[0].Rows[0]["FINAL_ELIGIBLE_AMOUNT"].ToString();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetPowerSubsidyDtls(string INCENTIVEID, string MasterIncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar),
               new SqlParameter("@MasterIncentiveId",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            pp[1].Value = MasterIncentiveId;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GETTBL_APPRAISAL_POWERSUBSIDY", pp);
            return Dsnew;
        }
    }
}