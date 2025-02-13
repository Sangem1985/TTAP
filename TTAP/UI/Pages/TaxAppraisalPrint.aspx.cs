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
    public partial class TaxAppraisalPrint : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        string IncentiveID;
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
                DataSet dsnew = new DataSet();
                dsnew = GetSalesTaxDtls("22183", "161017"); //IncentiveID

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    lblUnitName.Text = dsnew.Tables[0].Rows[0]["UNITNAME"].ToString();
                    lblAddress.Text = dsnew.Tables[0].Rows[0]["ADDRESS"].ToString();
                    lblProprietor.Text = dsnew.Tables[0].Rows[0]["PROPRIETOR_NAME"].ToString();
                    lblOrganization.Text = dsnew.Tables[0].Rows[0]["CONSTITUTION_ORGANIZATION"].ToString();
                    lblSocialStatus.Text = dsnew.Tables[0].Rows[0]["SOCIAL_STATUS"].ToString();
                    lblShareofSCSTWomenEnterprenue.Text = dsnew.Tables[0].Rows[0]["SHARE_OF_SC_ST_WOMEN"].ToString();
                    lblRegistrationNumber.Text = dsnew.Tables[0].Rows[0]["REGISTRATION_NO"].ToString();
                    lblTypeofApplicant.Text = dsnew.Tables[0].Rows[0]["TYPE_OF_UNIT"].ToString();
                    lblCategoryofUnit.Text = dsnew.Tables[0].Rows[0]["CATEGORY"].ToString();
                    lblTypeofSector.Text = dsnew.Tables[0].Rows[0]["TYPE_OF_SECTOR"].ToString();
                    lblTypeofTexttile.Text = dsnew.Tables[0].Rows[0]["TYPE_OF_TEXTILE"].ToString();
                    lblTechnicalTextileType.Text = dsnew.Tables[0].Rows[0]["TECHNICAL_TEXTILE_TYPE"].ToString();
                    lblActivityoftheUnit.Text = dsnew.Tables[0].Rows[0]["ACTIVITY"].ToString();
                    lblUIDNumber.Text = dsnew.Tables[0].Rows[0]["UID_NO"].ToString();
                    lblCommonApplicationNumber.Text = dsnew.Tables[0].Rows[0]["APPLICATION_NO"].ToString();
                    lblPowerConnectionReleaseDate.Text = dsnew.Tables[0].Rows[0]["POWER_CONNECTION_RELEASE_DT"].ToString();
                    lblDCPdate.Text = dsnew.Tables[0].Rows[0]["DCP"].ToString();
                    lblReceiptDate.Text = dsnew.Tables[0].Rows[0]["APPLIEDDATE"].ToString();
                    // lblcategoryes.Text = dsnew.Tables[0].Rows[0]["TYPE_OF_UNIT_INS"].ToString();

                    // lblscheme.Text = dsnew.Tables[0].Rows[0][""].ToString();
                    lblType.Text = dsnew.Tables[0].Rows[0]["TYPE_OF_UNIT_INS"].ToString();
                    lblProduct.Text = dsnew.Tables[0].Rows[0]["PRODUCTION"].ToString();
                    lblGST.Text = dsnew.Tables[0].Rows[0]["TAX_PAID_SGST"].ToString();
                    lblBaseProc.Text = dsnew.Tables[0].Rows[0]["BASE_PRODUCTION"].ToString();
                    lblQty.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_PRODUCTION_QTY"].ToString();
                    lblSGSTEligible.Text = dsnew.Tables[0].Rows[0]["PROPORTINATE_SGST"].ToString();
                    lblCategory.Text = dsnew.Tables[0].Rows[0]["CATEGORY_INS"].ToString();
                    lblamount.Text = dsnew.Tables[0].Rows[0]["AMOUNT"].ToString();
                    lblSelectType.Text = dsnew.Tables[0].Rows[0]["ELIGIBILITY_TYPE"].ToString();
                    lblGMAmounted.Text = dsnew.Tables[0].Rows[0]["GM_REC_AMOUNT"].ToString();
                    lblEligibleamount.Text = dsnew.Tables[0].Rows[0]["ELIGIBLE_AMOUNT"].ToString();
                    lblSubsidyAmount.Text = dsnew.Tables[0].Rows[0]["FINAL_SUBSIDY_AMOUNT"].ToString();
                    lblRemark.Text = dsnew.Tables[0].Rows[0]["REMARKS"].ToString();
                    hypsheet.Text = dsnew.Tables[0].Rows[0]["WORKSHEET_PATH"].ToString();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetSalesTaxDtls(string INCENTIVEID, string USERID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar),
               new SqlParameter("@CREATEDBY",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            pp[1].Value = USERID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_APPRAISAL_TAX", pp);
            return Dsnew;
        }
    }
}