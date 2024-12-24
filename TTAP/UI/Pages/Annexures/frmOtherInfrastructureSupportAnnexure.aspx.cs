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
    public partial class frmOtherInfrastructureSupportAnnexure : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        CAFClass ObjCAFClass = new CAFClass();
        General Gen = new General();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IncentiveID"] != null)
            {
                string IncentiveID = Request.QueryString["IncentiveID"].ToString();
                GetInfrastructureDetails("", IncentiveID);
                GetIncetiveAttachements(IncentiveID, "N", "13");
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
        public void GetInfrastructureDetails(string uid, string incentiveid)
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

                ds = Gen.GenericFillDs("USP_GET__Other_Infrastructure_Support_Dtls", p);


                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0] != null && ds.Tables[0].ToString() != "")
                {
                    RbtnIndustrialArea.InnerHtml = ds.Tables[0].Rows[0]["IndustrialAreaText"].ToString();
                    txtCategoryofBusiness.InnerHtml = ds.Tables[0].Rows[0]["CategoryofBusiness"].ToString();
                    txtYearsofOperation.InnerHtml = ds.Tables[0].Rows[0]["YearsofOperation"].ToString();
                    txtJustificationforlocation.InnerHtml = ds.Tables[0].Rows[0]["Justificationforlocation"].ToString();
                    txtProposedInfrastructureJustification.InnerHtml = ds.Tables[0].Rows[0]["ProposedInfrastructureJustification"].ToString();
                    txtSourceOfFinance.InnerHtml = ds.Tables[0].Rows[0]["SourceOfFinance"].ToString();
                    txtRoadsPowerWaterDescription.InnerHtml = ds.Tables[0].Rows[0]["RoadsPowerWaterDescription"].ToString();
                    txtSupportInfrastructureDescription.InnerHtml = ds.Tables[0].Rows[0]["SupportInfrastructureDescription"].ToString();
                    txtSupportEstimateCost.InnerHtml = ds.Tables[0].Rows[0]["SupportEstimateCost"].ToString();
                    txtEstimateCostRoadsPowerWater.InnerHtml = ds.Tables[0].Rows[0]["EstimateCostRoadsPowerWater"].ToString();
                    txtEstimateCostPower.InnerHtml = ds.Tables[0].Rows[0]["EstimateCostPower"].ToString();
                    txtEstimateCostWater.InnerHtml = ds.Tables[0].Rows[0]["EstimateCostWater"].ToString();
                    txtEstimateCostDrainageLine.InnerHtml = ds.Tables[0].Rows[0]["EstimateCostDrainageLine"].ToString();

                    txtCharteredEngineerName.InnerHtml = ds.Tables[0].Rows[0]["CharteredEngineerName"].ToString();
                    txtEstimateCostSupport15.InnerHtml = ds.Tables[0].Rows[0]["EstimateCostSupport15"].ToString();
                    txtEstimateCostRoadsPowerWater15.InnerHtml = ds.Tables[0].Rows[0]["EstimateCostRoadsPowerWater15"].ToString();
                    txtEstimateCostPower15.InnerHtml = ds.Tables[0].Rows[0]["EstimateCostPower15"].ToString();
                    txtEstimateCostWater15.InnerHtml = ds.Tables[0].Rows[0]["EstimateCostWater15"].ToString();

                    txtProjectDuration.InnerHtml = ds.Tables[0].Rows[0]["ProjectDuration"].ToString();
                    txtMeasuresproposed.InnerHtml = ds.Tables[0].Rows[0]["Measuresproposed"].ToString() + ",<br/> Maintenance Cost Per Annum : " + ds.Tables[0].Rows[0]["maintenancecost"].ToString();

                    RbtnAssistanceAvailed.InnerHtml = ds.Tables[0].Rows[0]["AssistanceAvailedText"].ToString();
                    if (ds.Tables[0].Rows[0]["AssistanceAvailed"].ToString() == "Y")
                    {
                        txtAmountAvailed.InnerHtml = ds.Tables[0].Rows[0]["AmountAvailed"].ToString();
                        txtSanctionOrderNo.InnerHtml = ds.Tables[0].Rows[0]["SanctionOrderNo"].ToString();
                        txtDateAvailed.InnerHtml = ds.Tables[0].Rows[0]["DateAvailedDDMMYY"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
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