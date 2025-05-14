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
    public partial class TransportSubsidyAppraisalNotePrint : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        public void BindData()
        {
            try
            {
                string IncentiveId = Request.QueryString["incid"].ToString();
                //string IncentiveId = "48403";
                DataSet dsnew = new DataSet();
                dsnew = GetTransportSubsidyDtls(IncentiveId);

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
                    if (dsnew.Tables[0].Rows[0]["TYPE_OF_UNIT"].ToString() == "New Industry")
                    {
                        divNewUnit.Visible = true;
                        lblRevenueOfUnit.Text = dsnew.Tables[0].Rows[0]["TOTAL_REVENUE_OF_UNIT"].ToString();
                        lblExportValueOfUnit.Text = dsnew.Tables[0].Rows[0]["EXPORT_VALUE_OF_UNIT"].ToString();
                    }
                    else 
                    {
                        divExpansionUnit.Visible = true;
                        lblAverageRevenue.Text = dsnew.Tables[0].Rows[0]["AVERAGE_REVENUE"].ToString();
                        lblRevenueAfterExpansion.Text = dsnew.Tables[0].Rows[0]["REVENUE_AFTER_EXPANSION"].ToString();
                        lblIncrementalRevenue.Text = dsnew.Tables[0].Rows[0]["INCREMENTAL_REVENUE"].ToString();
                        lblAverageFrightCharges.Text = dsnew.Tables[0].Rows[0]["AVERAGE_FRIGHT_CHARGES"].ToString();
                        lblTotalFreightChargesAfterExp.Text = dsnew.Tables[0].Rows[0]["FREIGHT_CHARGES_AFTER_EXPANSION"].ToString();
                    }

                    lblCalculatedSubsidyAmount.Text = dsnew.Tables[0].Rows[0]["CALCULATED_SUBSISDY_AMOUNT"].ToString();
                    lblGMAmount.Text = dsnew.Tables[0].Rows[0]["GM_REC_AMOUNT"].ToString();
                    lblEligibletotal.Text = dsnew.Tables[0].Rows[0]["TOTAL_ELIGIBLE_AMOUNT"].ToString();
                    lblEligibilityType.Text = dsnew.Tables[0].Rows[0]["ELIGIBILITY_TYPE"].ToString();
                    lblFinalSubsudyAmount.Text = dsnew.Tables[0].Rows[0]["FINAL_ELIGIBLE_AMOUNT"].ToString();
                    lblDepartment.Text = dsnew.Tables[0].Rows[0]["FORWARD_TO"].ToString();
                    string Remarks= dsnew.Tables[0].Rows[0]["REMARKS"].ToString().Trim();
                    string worksheetPath = dsnew.Tables[0].Rows[0]["WORKSHEET_PATH"].ToString().Trim();
                    if (string.IsNullOrEmpty(Remarks))
                    {
                        trRemarks.Visible = false;
                    }
                    else
                    {
                        trRemarks.Visible = true;
                        lblRemarks.Text = Remarks;
                    }
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
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetTransportSubsidyDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_TRANSPORT_SUBSIDY_APPRAISAL", pp);
            return Dsnew;
        }
    }
}