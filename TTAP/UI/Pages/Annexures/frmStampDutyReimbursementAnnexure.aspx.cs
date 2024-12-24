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
    public partial class frmStampDutyReimbursementAnnexure : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        CAFClass ObjCAFClass = new CAFClass();
        General Gen = new General();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IncentiveID"] != null)
            {
                string IncentiveID = Request.QueryString["IncentiveID"].ToString();
                GetStampDutyDetails("", IncentiveID);
                GetIncetiveAttachements(IncentiveID, "N", "5");
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
        public void GetStampDutyDetails(string uid, string IncentiveID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetapplicationDtls(uid, IncentiveID);
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

                    lblCategoryofUnit.InnerText = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    lblActivityoftheUnit.InnerText = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();
                    txtLineofActivity.InnerText = dsnew.Tables[0].Rows[0]["ProductDtls"].ToString();
                }


                DataSet ds = new DataSet();
                SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@created_BY",SqlDbType.VarChar),
                    new SqlParameter("@IncentiveID",SqlDbType.VarChar)
                };
                p[0].Value = uid;
                p[1].Value = IncentiveID;
                ds = Gen.GenericFillDs("USP_GET_STAMPDUTY", p);
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.ToString() != "" && ds.Tables[0].Rows.ToString() != null)
                {
                    ddlNatureofAsset.InnerHtml = ds.Tables[0].Rows[0]["NatureofAssetText"].ToString();
                    txtLandPurchased.InnerHtml = ds.Tables[0].Rows[0]["LandPurchased_Sqmtrs"].ToString();
                    txtPlinthAreaoftheBuilding.InnerHtml = ds.Tables[0].Rows[0]["PlinthAreaBuilding"].ToString();
                    txtLandPurchasedCostPersqmtrs.InnerHtml = ds.Tables[0].Rows[0]["LandPurchasedCostPersqmtrs"].ToString();
                    txtPlinthFactoryBuildings.InnerHtml = ds.Tables[0].Rows[0]["PlinthAreaofFactoryFiveTmes"].ToString();
                    txtFactoryappraisal.InnerHtml = ds.Tables[0].Rows[0]["Arearequiredappraisal"].ToString();
                    txtTSPCB.InnerHtml = ds.Tables[0].Rows[0]["ArearequiredTSPCB"].ToString();
                    ddlNatureofTransaction.InnerHtml = ds.Tables[0].Rows[0]["NatureofTransactionText"].ToString();
                    txtDateofRegistration.InnerHtml = ds.Tables[0].Rows[0]["DateofRegistration"].ToString();
                    SubRegistrar.InnerHtml = ds.Tables[0].Rows[0]["SubRegistrarOffice"].ToString();
                    txtStampDutyTransferDutyPaid.InnerHtml = ds.Tables[0].Rows[0]["StampDuty_TransferDuty_Paid"].ToString();
                    txtMortgageHypothecationDutyPaid.InnerHtml = ds.Tables[0].Rows[0]["MortgageHypothecationDutyPaid"].ToString();
                    txtStampDutyExemptionalreadyAvailed.InnerHtml = ds.Tables[0].Rows[0]["StampDutyExemptionAvailed"].ToString();
                    Termloan14.InnerHtml = ds.Tables[0].Rows[0]["Termloan"].ToString();
                    txtCurrentClaimStampTransferDuty.InnerHtml = ds.Tables[0].Rows[0]["CurrentClaimStampDutyTransferDuty"].ToString();
                    txtCurrentClaimMortgageHypothecationDuty.InnerHtml = ds.Tables[0].Rows[0]["CurrentClaimMortgageHypothecationDuty"].ToString();

                    txtAmountAvailed.InnerHtml = ds.Tables[0].Rows[0]["AmountAvailed"].ToString();
                    txtSanctionOrderNo.InnerHtml = ds.Tables[0].Rows[0]["SanctionOrderNo"].ToString();
                    txtDateAvailed.InnerHtml = ds.Tables[0].Rows[0]["DateAvailedDDMMYY"].ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void GetIncetiveAttachements(string IncentiveId, string CAFFLAG, string SubIncentiveId)
        {
            DataSet dsnew1 = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentveID",SqlDbType.Int),
                new SqlParameter("@CAFFLAG",SqlDbType.VarChar),
                new SqlParameter("@SubIncentiveId1",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = CAFFLAG;
            pp[2].Value = SubIncentiveId;
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
    }
}