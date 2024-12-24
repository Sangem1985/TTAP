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
    public partial class frmTransportSubsidyAnnexure : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        CAFClass ObjCAFClass = new CAFClass();
        General Gen = new General();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IncentiveID"] != null)
            {
                string IncentiveID = Request.QueryString["IncentiveID"].ToString();
                GetTransportSubsidy("", IncentiveID);
                BindExportIntensiveTextileDtls(IncentiveID);
                BindExportRevenueDtls(IncentiveID);
                BindCurrentClaimDtls(IncentiveID);
                GetIncetiveAttachements(IncentiveID, "N", "9");
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

        public void GetTransportSubsidy(string uid, string IncentiveID)
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
                }

                DataSet ds = new DataSet();
                SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@created_BY",SqlDbType.VarChar),
                    new SqlParameter("@IncentiveID",SqlDbType.VarChar)
                };
                p[0].Value = uid;
                p[1].Value = IncentiveID;
                ds = Gen.GenericFillDs("USP_GET_Transport_Export_Intensive_Textile", p);
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.ToString() != "" && ds.Tables[0].Rows.ToString() != null)
                {

                    string TypeofInfrastructure = ds.Tables[0].Rows[0]["NatureofBusiness"].ToString();
                    if (TypeofInfrastructure != "")
                    {
                        string[] TypeofInfrastructureVal = TypeofInfrastructure.Split(',');

                        foreach (string Value in TypeofInfrastructureVal)
                        {
                            int Index = chkNatureofBusiness.Items.IndexOf(chkNatureofBusiness.Items.FindByValue(Value));
                            chkNatureofBusiness.Items[Index].Selected = true;
                        }
                    }

                    txtDateofEstablishmentofUnit.InnerHtml = ds.Tables[0].Rows[0]["DateofEstablishmentofUnit"].ToString();
                    txtPercentageTotalRevenue.InnerHtml = ds.Tables[0].Rows[0]["PercentageTotalRevenue"].ToString();
                    txtNearestAirport.InnerHtml = ds.Tables[0].Rows[0]["NearestAirport"].ToString();
                    txtNearestSeaport.InnerHtml = ds.Tables[0].Rows[0]["NearestSeaport"].ToString();
                    txtNearestDryPort.InnerHtml = ds.Tables[0].Rows[0]["NearestDryPort"].ToString();
                    ddlTypeofExport.InnerHtml = ds.Tables[0].Rows[0]["TypeofExportText"].ToString();
                    lblModeofTransport.InnerHtml = ds.Tables[0].Rows[0]["ModeofTransport"].ToString();
                    txtDetailsRawMaterialsImported.InnerHtml = ds.Tables[0].Rows[0]["DetailsRawMaterialsImported"].ToString();
                    txtFinishedProducts.InnerHtml = ds.Tables[0].Rows[0]["DetailsFinishedProducts"].ToString();
                    txtFinishedProductsExported.InnerHtml = ds.Tables[0].Rows[0]["FinishedProductsExported"].ToString();
                    txtCurrentClaim.InnerHtml = ds.Tables[0].Rows[0]["CurrentClaim"].ToString();
                    //txtExportRevenue.InnerHtml = ds.Tables[0].Rows[0]["ExportRevenue"].ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void BindExportIntensiveTextileDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetExportIntensiveTextileDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    grdSGSTReimbursement.DataSource = dsnew.Tables[0];
                    grdSGSTReimbursement.DataBind();
                }
                else
                {
                    grdSGSTReimbursement.DataSource = null;
                    grdSGSTReimbursement.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetExportIntensiveTextileDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_Export_Intensive_TextileDTLS", pp);
            return Dsnew;
        }
        protected void BindExportRevenueDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetExportRevenueDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    gvExportRevenueDetails.DataSource = dsnew.Tables[0];
                    gvExportRevenueDetails.DataBind();
                }
                else
                {
                    gvExportRevenueDetails.DataSource = null;
                    gvExportRevenueDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetExportRevenueDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GEt_ExportRevenueDTLS", pp);
            return Dsnew;
        }

        protected void BindCurrentClaimDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetCurrentClaimDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    GvCurrentClaimPeriod.DataSource = dsnew.Tables[0];
                    GvCurrentClaimPeriod.DataBind();
                }
                else
                {
                    GvCurrentClaimPeriod.DataSource = null;
                    GvCurrentClaimPeriod.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCurrentClaimDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_CURRENTFINANCIALCLAIMDTLS", pp);
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