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
    public partial class StampDutyAppraisalPrint : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStampDutyAppraisal();
            }
        }
        public void BindStampDutyAppraisal()
        {
            try
            {
                string IncentiveId = Request.QueryString["incid"].ToString();
                string MasterIncentiveId = Request.QueryString["mstid"].ToString();
                DataSet dsnew = new DataSet();
                dsnew = GetStampDutyAppraisalDtls(IncentiveId, MasterIncentiveId);

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
                lblActivityoftheUnit.Text = dsnew.Tables[0].Rows[0]["ACTIVITYOFUNIT"].ToString();
                lblUIDNumber.Text = dsnew.Tables[0].Rows[0]["UID_NO"].ToString();
                lblCommonApplicationNumber.Text = dsnew.Tables[0].Rows[0]["APPLICATION_NO"].ToString();
                lblPowerConnectionReleaseDate.Text = dsnew.Tables[0].Rows[0]["POWER_CON_RELEASE_DT"].ToString();
                lblDCPdate.Text = dsnew.Tables[0].Rows[0]["DCP"].ToString();
                lblReceiptDate.Text = dsnew.Tables[0].Rows[0]["APPLIED_DATE"].ToString();
                lblelbPromoter.Text = dsnew.Tables[0].Rows[0]["PROMOTERDETELIGIBLESUBSIDY"].ToString();


                lblscheme.Text = dsnew.Tables[0].Rows[0]["SCHEME"].ToString();
                lblselect.Text = dsnew.Tables[0].Rows[0]["SELECT_TYPE"].ToString();
                lblLandMeasure.Text = dsnew.Tables[0].Rows[0]["LANDMEASURE"].ToString();
                lblstamppaid.Text = dsnew.Tables[0].Rows[0]["STAMP_DUTY"].ToString();
                lblBuildingarea.Text = dsnew.Tables[0].Rows[0]["BUILDING_PLANTAREA"].ToString();
                lblBuildingarea5.Text = dsnew.Tables[0].Rows[0]["BUILDING_PLINTHAREA"].ToString();
                lblProporation.Text = dsnew.Tables[0].Rows[0]["PROPORTIONATEAREA"].ToString();
                lblGMDIC.Text = dsnew.Tables[0].Rows[0]["GMRECOMMENDED_DIC"].ToString();
                lblComputedValue.Text = dsnew.Tables[0].Rows[0]["COMPUTED_RS"].ToString();
                lblSelectType.Text = dsnew.Tables[0].Rows[0]["SELECTED_TYPE"].ToString();
                lblEligibleAmount.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_AMOUNT"].ToString();
                lblRemarks.Text = dsnew.Tables[0].Rows[0]["REMARKS"].ToString();
                lblForward.Text = dsnew.Tables[0].Rows[0]["FORWARD_TO"].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetStampDutyAppraisalDtls(string INCENTIVEID, string MasterIncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar),
               new SqlParameter("@MasterIncentiveId",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            pp[1].Value = MasterIncentiveId;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GETAPPRAISAL_STAMPDUTY", pp);
            return Dsnew;
        }
    }
}