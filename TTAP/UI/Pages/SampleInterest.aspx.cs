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
using System.Xml.Linq;
using System.Web.UI.HtmlControls;

namespace TTAP.UI.Pages
{
    public partial class SampleInterest : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        CAFClass ObjCAFClass = new CAFClass();
        AppraisalClass objappraisalClass = new AppraisalClass();
        private decimal totalEligibleAmount = 0;
        private decimal grandTotal = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
            ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

            try
            {
                if (Session["ObjLoginvo"] != null)
                {
                    if (!IsPostBack)
                    {

                        string incentiveid = "2063";
                        ViewState["UID"] = ObjLoginNewvo.uid;
                        if (Request.QueryString["IncentiveID"] != null)
                        {
                            incentiveid = Request.QueryString["IncentiveID"].ToString();
                        }
                        txtIncID.Text = incentiveid;
                        BindBesicdata(incentiveid, "3", "");
                        BindISCrrentClaimPeriodDtls(incentiveid);
                        rdbTypeofTextile_SelectedIndexChanged(this, EventArgs.Empty);
                        DataSet dsnew1 = new DataSet();
                    }
                }
                else
                {
                    Response.Redirect("~/LoginReg.aspx");
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void BindBesicdata(string IncentiveID, string SubIncentiveId, string DistrictID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = objappraisalClass.GetapplicationDtls("0", IncentiveID);
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    lblUnitName.InnerText = dsnew.Tables[0].Rows[0]["UnitName"].ToString();
                    lblTSIPassUIDNumber.InnerText = dsnew.Tables[0].Rows[0]["Uid_NO"].ToString();
                    lblCommonApplicationNumber.InnerText = dsnew.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                    hdnApplication.Value = dsnew.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                    lblTypeofApplicant.InnerText = dsnew.Tables[0].Rows[0]["TypeOfIndustryText"].ToString();
                    string TypeOfIndustry = dsnew.Tables[0].Rows[0]["TypeOfIndustry"].ToString();
                    string TextileProcessName = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();
                    //ddlindustryStatus(TypeOfIndustry.Trim().TrimStart().TrimEnd(), TextileProcessName);
                    hdnTypeOfIndustry.Value = dsnew.Tables[0].Rows[0]["TypeOfIndustry"].ToString();
                    if (TypeOfIndustry == "1")
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCP"].ToString();
                        divNewMonth.Visible = true;
                    }
                    else
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCPExp"].ToString();
                        divLastThreeDtls.Visible = true;
                        divExpansionDtls.Visible = true;
                        divNewMonth.Visible = true;
                    }

                    lblReceiptDate.InnerHtml = dsnew.Tables[0].Rows[0]["ApplicationFiledDate"].ToString();
                    lblcategory.InnerText = dsnew.Tables[0].Rows[0]["SocialStatusText"].ToString();
                    lblCategoryofUnit.InnerText = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    rdbCategory.SelectedValue = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    lblActivityoftheUnit.InnerText = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();
                    ddlNature.SelectedValue = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();
                    hdnActualCategory.Value = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    lblTypeofTexttile.InnerText = dsnew.Tables[0].Rows[0]["TypeofTexttileText"].ToString();
                    if (dsnew.Tables[0].Rows[0]["TypeofTexttile"].ToString() == "0")
                    {
                        rdbTypeofTextile.SelectedValue = "1";
                    }
                    else
                    {
                        rdbTypeofTextile.SelectedValue = "2";
                    }

                    hdnActualTextile.Value = dsnew.Tables[0].Rows[0]["TypeofTexttile"].ToString();

                    lblAddress.InnerText = dsnew.Tables[0].Rows[0]["UnitTotalAddress"].ToString();
                    lblProprietor.InnerText = dsnew.Tables[0].Rows[0]["AuthorisedPerson"].ToString();
                    lblOrganization.InnerText = dsnew.Tables[0].Rows[0]["ConstitutionUnit"].ToString();
                    lblSocialStatus.InnerText = dsnew.Tables[0].Rows[0]["SocialStatusText"].ToString();
                    lblRegistrationNumber.InnerText = dsnew.Tables[0].Rows[0]["IncorpRegistranNumber"].ToString();
                    lblTechnicalTextileType.InnerText = dsnew.Tables[0].Rows[0]["TechnicalTextile"].ToString();
                    lblPowerConnectionReleaseDate.InnerText = dsnew.Tables[0].Rows[0]["NewPowerReleaseDate"].ToString();
                    lblGMAmount.InnerText = dsnew.Tables[1].Rows[0]["OfficerRecommendedAmount"].ToString();

                }
            }
            catch (Exception ex)
            { }
        }
        protected void BindISCrrentClaimPeriodDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetISCrrentClaimPeriodDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    GvInterestSubsidyPeriod.DataSource = dsnew.Tables[0];
                    GvInterestSubsidyPeriod.DataBind();
                    divClaimPeroid.Visible = true;
                    // txtDCP_unit.Text = dsnew.Tables[1].Rows[0]["DCP"].ToString();
                }
                else
                {
                    GvInterestSubsidyPeriod.DataSource = null;
                    GvInterestSubsidyPeriod.DataBind();
                }
                if (dsnew != null && dsnew.Tables.Count > 1 && dsnew.Tables[1].Rows.Count > 0)
                {
                    lblGMAmount.InnerText = dsnew.Tables[1].Rows[0]["OfficerRecommendedAmount"].ToString();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void rdbTypeofTextile_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
        public DataSet GetISCrrentClaimPeriodDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_IS_CURRENTCLAIM_PERIOD_DTLS_APPRASIAL", pp);
            return Dsnew;
        }

       
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            DataTable dt_grid = new DataTable();
            List<FinancialYear> financialYears = new List<FinancialYear>();
            dt_grid.Columns.Add("IncentiveId", typeof(string));
            dt_grid.Columns.Add("FinancialYear", typeof(string));
            dt_grid.Columns.Add("FinancialYearID", typeof(string));
            dt_grid.Columns.Add("FinancialYearName", typeof(string));
            dt_grid.Columns.Add("Months", typeof(string));
            dt_grid.Columns.Add("LoanNumber", typeof(int));
            foreach (GridViewRow gvrows in GvInterestSubsidyPeriod.Rows)
            {   
                Label lbl_claimperiodofloanaddname = (Label)gvrows.FindControl("lbl_claimperiodofloanaddname");
                TextBox txt_claimperiodofloanaddNumber = (TextBox)gvrows.FindControl("txt_claimperiodofloanaddNumber");
                HiddenField hf_claimperiodofloanaddFinancialYear = (HiddenField)gvrows.FindControl("hf_claimperiodofloanaddFinancialYear");
                HiddenField hf_claimperiodofloanadd_ID = (HiddenField)gvrows.FindControl("hf_claimperiodofloanadd_ID");
                HiddenField hf_Fin1stOr2ndHalfYear = (HiddenField)gvrows.FindControl("hf_Fin1stOr2ndHalfYear");
                HiddenField hf_claimperiodofloanaddIncentiveId = (HiddenField)gvrows.FindControl("hf_claimperiodofloanaddIncentiveId");
                int count = Convert.ToInt32(txt_claimperiodofloanaddNumber.Text.ToString());
                for (int i = 0; i < count; i++)
                {
                    DataRow drs = dt_grid.NewRow();
                    drs["LoanNumber"] = i + 1;
                    drs["FinancialYearName"] = Convert.ToString(lbl_claimperiodofloanaddname.Text);
                    dt_grid.Rows.Add(drs);
                    financialYears.Add(new FinancialYear
                    {
                        LoanNumber = Convert.ToInt32(i + 1).ToString(),
                        FinancialYearName = Convert.ToString(lbl_claimperiodofloanaddname.Text),
                        Months = GetMonthWiseDetails(hf_claimperiodofloanaddFinancialYear.Value, hf_Fin1stOr2ndHalfYear.Value),
                    });
                }
            }
            rpt_eglibilepallavaddi.DataSource = financialYears;
            rpt_eglibilepallavaddi.DataBind();
        }
        private List<MonthDetail> GetMonthWiseDetails(string year, string YearType)
        {
            List<MonthDetail> months = new List<MonthDetail>();
            string CS = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("USP_GET_CURRENT_CLAIMPERIOD", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@INCENTIVEID",
                    Value = txtIncID.Text
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@SUBINCENTIVEID",
                    Value = "4"
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@FLAG",
                    Value = "M"
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@FINANCIALYEAR",
                    Value = year
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@HALFYEAR",
                    Value = YearType
                });
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    months.Add(new MonthDetail
                    {
                        Month = reader["Month"].ToString(),
                        FinancialYear = reader["FinancialYear"].ToString()
                    });
                }
            }
            return months;
        }
        public class FinancialYear
        {
            public string FinancialYearText { get; set; }
            public string LoanNumber { get; set; }
            public string FinancialYearName { get; set; }
            public string HalfYearType { get; set; }
            public string FinancialYearId { get; set; }
            public List<MonthDetail> Months { get; set; }
        }

        public class MonthDetail
        {
            public string Month { get; set; }
            public string FinancialYear { get; set; }
            public int UnitsConsumed { get; set; }
            public decimal AmountPaid { get; set; }
            public decimal EligibleRate { get; set; }
            public decimal EligibleAmount { get; set; }
        }
    }
}