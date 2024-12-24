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
    public partial class frmRebateCETPETPAnnexure : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        CAFClass ObjCAFClass = new CAFClass();
        General Gen = new General();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IncentiveID"] != null)
            {
                string IncentiveID = Request.QueryString["IncentiveID"].ToString();

                GetRebatechargesDetails("", IncentiveID);
                BindETPChargesDtls(IncentiveID);
                GetIncetiveAttachements(IncentiveID, "N", "14");
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
        public void GetRebatechargesDetails(string uid, string incentiveid)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetapplicationDtls(uid, incentiveid);
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
                }

                DataSet ds = new DataSet();
                SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@created_BY",SqlDbType.VarChar),
                    new SqlParameter("@IncentiveID",SqlDbType.VarChar)
                };
                p[0].Value = uid;
                p[1].Value = incentiveid;

                ds = Gen.GenericFillDs("USP_GET_CETP_ETP_Environment_Dtls", p);

                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0] != null && ds.Tables[0].ToString() != "")
                {
                    RbtnTypeofETP.InnerHtml = ds.Tables[0].Rows[0]["TypeofETPText"].ToString();
                    if (ds.Tables[0].Rows[0]["TypeofETP"].ToString() == "2")
                    {
                        txtOtherETP.InnerHtml = ds.Tables[0].Rows[0]["OtherETP"].ToString();
                    }
                    txtCETPETPDetails.InnerHtml = ds.Tables[0].Rows[0]["CETPETPDetails"].ToString();
                    txtCaptiveCommonETP.InnerHtml = ds.Tables[0].Rows[0]["CaptiveCommonETP"].ToString();
                    txtETPCost.InnerHtml = ds.Tables[0].Rows[0]["ETPCost"].ToString();
                    txtRebateClaimed.InnerHtml = ds.Tables[0].Rows[0]["RebateClaimed"].ToString();
                    txtYearoftheClaim.InnerHtml = ds.Tables[0].Rows[0]["YearoftheClaim"].ToString();
                    txtAnyGovtAgency.InnerHtml = ds.Tables[0].Rows[0]["AnyGovtAgency"].ToString();
                    txtYearsCommercialProduction.InnerHtml = ds.Tables[0].Rows[0]["YearsCommercialProduction"].ToString();
                    txtCommencementCommercialOperation.InnerHtml = ds.Tables[0].Rows[0]["CommencementCommercialOperation"].ToString();
                    txtDateofCommencementUtilization.InnerHtml = ds.Tables[0].Rows[0]["DateofCommencementUtilization"].ToString();
                    txtCurrentClaim.InnerHtml = ds.Tables[0].Rows[0]["CurrentClaim"].ToString();

                    txtApprovedProjectCost.InnerHtml = ds.Tables[0].Rows[0]["ApprovedProjectCost"].ToString();
                    ddlUtilizationETPCETP.InnerHtml = ds.Tables[0].Rows[0]["UtilizationETPCETPTEXT"].ToString();

                    txtActualCostInvested.InnerHtml = ds.Tables[0].Rows[0]["ActualCostInvested"].ToString();

                    txtAmountAvailed.InnerHtml = ds.Tables[0].Rows[0]["AmountAvailed"].ToString();
                    txtSource.InnerHtml = ds.Tables[0].Rows[0]["SanctionOrderNo"].ToString();
                    txtDateAvailed.InnerHtml = ds.Tables[0].Rows[0]["DateAvailedDDMMYY"].ToString();

                    string UtilizationETPCETP= ds.Tables[0].Rows[0]["UtilizationETPCETP"].ToString();
                    if (UtilizationETPCETP == "2")
                    {
                        divcommon1.Visible = false;
                        divcommon2.Visible = false;
                        divcommon3.Visible = false;
                        divcommon4.Visible = false;
                        divcommon5.Visible = false;
                        divcommon6.Visible = false;
                        td15.InnerHtml = "11";
                        td16.InnerHtml = "12";
                        td17.InnerHtml = "13";
                        td18.InnerHtml = "14";
                    }
                    else
                    {
                        divcommon1.Visible = true;
                        divcommon2.Visible = true;
                        divcommon3.Visible = true;
                        divcommon4.Visible = true;
                        divcommon5.Visible = true;
                        divcommon6.Visible = true;
                        td15.InnerHtml = "15";
                        td16.InnerHtml = "16";
                        td17.InnerHtml = "17";
                        td18.InnerHtml = "18";
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void BindETPChargesDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GeTETPChargesDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    grdETPDetails.DataSource = dsnew.Tables[0];
                    grdETPDetails.DataBind();
                }
                else
                {
                    grdETPDetails.DataSource = null;
                    grdETPDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GeTETPChargesDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_ETPCharges_DTLS", pp);
            return Dsnew;
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