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

                        string incentiveid = "17155";
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
                        divNewMonth.Visible = true;
                    }

                    lblReceiptDate.InnerHtml = dsnew.Tables[0].Rows[0]["ApplicationFiledDate"].ToString();
                    lblcategory.InnerText = dsnew.Tables[0].Rows[0]["SocialStatusText"].ToString();
                    lblCategoryofUnit.InnerText = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    lblActivityoftheUnit.InnerText = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();
                    hdnActualCategory.Value = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    lblTypeofTexttile.InnerText = dsnew.Tables[0].Rows[0]["TypeofTexttileText"].ToString();
                    hdnActualTextile.Value = dsnew.Tables[0].Rows[0]["TypeofTexttile"].ToString();

                    lblAddress.InnerText = dsnew.Tables[0].Rows[0]["UnitTotalAddress"].ToString();
                    lblProprietor.InnerText = dsnew.Tables[0].Rows[0]["AuthorisedPerson"].ToString();
                    lblOrganization.InnerText = dsnew.Tables[0].Rows[0]["ConstitutionUnit"].ToString();
                    lblSocialStatus.InnerText = dsnew.Tables[0].Rows[0]["SocialStatusText"].ToString();
                    lblRegistrationNumber.InnerText = dsnew.Tables[0].Rows[0]["IncorpRegistranNumber"].ToString();
                    lblTechnicalTextileType.InnerText = dsnew.Tables[0].Rows[0]["TechnicalTextile"].ToString();
                    lblPowerConnectionReleaseDate.InnerText = dsnew.Tables[0].Rows[0]["NewPowerReleaseDate"].ToString();

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
                        FinancialYearId = Convert.ToString(hf_claimperiodofloanadd_ID.Value),
                        Dcp = Convert.ToDateTime(lblDCPdate.InnerText.ToString()),
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
                SqlCommand cmd = new SqlCommand("USP_GET_CURRENT_CLAIMPERIOD_MONTHS", con);
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
                        FinancialYear = reader["FinancialYear"].ToString(),
                        MonthYear = reader["MonthYear"].ToString()
                    });
                }
            }
            return months;
        }
        public class FinancialYear
        {
            public string FinancialYearText { get; set; }
            public string LoanNumber { get; set; }
            public DateTime Dcp { get; set; }
            public string FinancialYearName { get; set; }
            public string HalfYearType { get; set; }
            public string FinancialYearId { get; set; }
            public List<MonthDetail> Months { get; set; }
        }

        public class MonthDetail
        {
            public string Month { get; set; }
            public string FinancialYear { get; set; }
            public string MonthYear { get; set; }
            public int UnitsConsumed { get; set; }
            public decimal AmountPaid { get; set; }
            public decimal EligibleRate { get; set; }
            public decimal EligibleAmount { get; set; }
        }

        protected void txtRptLoanInstallmentStartDt_TextChanged1(object sender, EventArgs e)
        {

            TextBox txt = (TextBox)sender;
            RepeaterItem item = (RepeaterItem)txt.NamingContainer;

            TextBox txtRptLoanInstallmentStartDt = (TextBox)item.FindControl("txtRptLoanInstallmentStartDt");
            TextBox txtRptDCP = (TextBox)item.FindControl("txtRptDCP");
            DropDownList ddlRptPeriodOfInstallment = (DropDownList)item.FindControl("ddlRptPeriodOfInstallment");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)item.FindControl("hf_grdeglibilepallavaddiFY_ID");
            
            /*TextBox txtEligibleAmount = (TextBox)item.FindControl("txtEligibleAmount");
            TextBox txtBaseFixed = (TextBox)item.FindControl("txtBaseFixed");
            TextBox txtEligibleUnitsBase = (TextBox)item.FindControl("txtEligibleUnitsBase");*/
           
        }
        private void HandleInstallmentStartDateChange(RepeaterItem item)
        {
            TextBox txtRptLoanInstallmentStartDt = (TextBox)item.FindControl("txtRptLoanInstallmentStartDt");
            TextBox txtRptDCP = (TextBox)item.FindControl("txtRptDCP");
            TextBox txtRptNoofInstallmentsCompleted = (TextBox)item.FindControl("txtRptNoofInstallmentsCompleted");
            TextBox txtRptTermLoanAvailed = (TextBox)item.FindControl("txtRptTermLoanAvailed");
            TextBox txtRptNoofInstallments = (TextBox)item.FindControl("txtRptNoofInstallments");
            TextBox txtRptInstallmentAmount = (TextBox)item.FindControl("txtRptInstallmentAmount");
            TextBox txtRptPrincipalAmountDUE = (TextBox)item.FindControl("txtRptPrincipalAmountDUE");
            DropDownList ddlRptPeriodOfInstallment = (DropDownList)item.FindControl("ddlRptPeriodOfInstallment");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)item.FindControl("hf_grdeglibilepallavaddiFY_ID");

            int slno = 1;
            string ErrorMsg = "";

            DateTime dcpdate = DateTime.Now; DateTime installmentstartdate = DateTime.Now;
            int noofinstallmentcompleted = 0;
            int FYSlnoofIncentiveID = 0;
            int fyStartyear = 0;
            int fystartmonth = 0;
            int fyendyear = 0;
            int fyendmonth = 0;
            int firstsecondhalfyearclaimtype = 0;
            int totalclaimperiod = 6;

            decimal PrincipleDueAmount = 0,CompletedPrincipleAmount=0;


            if (!string.IsNullOrEmpty(hf_grdeglibilepallavaddiFY_ID.Value) || hf_grdeglibilepallavaddiFY_ID.Value != "")
            {
                string claimperiodddlvalue = hf_grdeglibilepallavaddiFY_ID.Value;
                string[] argclaimperiod = new string[5];
                argclaimperiod = claimperiodddlvalue.Split('/'); //32012/1/2016-2017
                FYSlnoofIncentiveID = Convert.ToInt32(argclaimperiod[0]);
                firstsecondhalfyearclaimtype = Convert.ToInt16(argclaimperiod[1]);
                string yeardata = Convert.ToString(argclaimperiod[2]);
                string[] argyearclaimperiod = new string[5];
                argyearclaimperiod = yeardata.Split('-');
                fyStartyear = Convert.ToInt32(argyearclaimperiod[0]);
                fyendyear = Convert.ToInt32(argyearclaimperiod[1]);
                if (firstsecondhalfyearclaimtype > 0)
                {
                    if (firstsecondhalfyearclaimtype == 1)
                    {
                        fystartmonth = 4;
                        fyendmonth = 9;
                        totalclaimperiod = 6;
                    }
                    if (firstsecondhalfyearclaimtype == 2)
                    {
                        fystartmonth = 10;
                        fyendmonth = 3;
                        totalclaimperiod = 6;
                    }
                    if (firstsecondhalfyearclaimtype == 3)
                    {
                        fystartmonth = 4;
                        fyendmonth = 3;
                        totalclaimperiod = 12;
                    }
                }
                if (txtRptDCP.Text.TrimStart().TrimEnd().Trim() != "")
                {

                    dcpdate = Convert.ToDateTime(txtRptDCP.Text);
                }
                if (txtRptLoanInstallmentStartDt.Text.TrimStart().TrimEnd().Trim() != "")
                {

                    installmentstartdate = Convert.ToDateTime(txtRptLoanInstallmentStartDt.Text);
                }
                if (txtRptTermLoanAvailed.Text != "" && txtRptNoofInstallments.Text != "")
                {
                    txtRptInstallmentAmount.Text = Math.Round((Convert.ToDecimal(txtRptTermLoanAvailed.Text.Trim()) / Convert.ToInt32(txtRptNoofInstallments.Text.ToString())),2).ToString();
                }
               
                if (dcpdate.Date != DateTime.Now.Date)
                {
                    if (installmentstartdate.Date != DateTime.Now.Date)
                    {   
                        DateTime Claimperiodstartdate = new DateTime(Convert.ToInt32(fyStartyear), fystartmonth, 01);
                        /*DateTime fyendstss = new DateTime(fyendyear, fyendmonth, 1);*/
                     

                        int MonthsDifference = GetMonthsDifference(installmentstartdate, Claimperiodstartdate);

                        if (ddlRptPeriodOfInstallment.SelectedValue != "0")
                        {
                            string PeriodOfInstallment = ddlRptPeriodOfInstallment.SelectedValue.ToString();
                            if (PeriodOfInstallment == "1")
                            {
                                noofinstallmentcompleted = MonthsDifference / 12;
                            }
                            if (PeriodOfInstallment == "2")
                            {
                                noofinstallmentcompleted = MonthsDifference / 6;
                            }
                            if (PeriodOfInstallment == "3")
                            {
                                noofinstallmentcompleted = MonthsDifference / 3;
                            }
                            if (PeriodOfInstallment == "4")
                            {
                                noofinstallmentcompleted = MonthsDifference;
                            }
                            txtRptNoofInstallmentsCompleted.Text = noofinstallmentcompleted.ToString();
                        }
                        if (txtRptInstallmentAmount.Text != "" && txtRptNoofInstallmentsCompleted.Text != "")
                        {
                            CompletedPrincipleAmount = Convert.ToDecimal((Convert.ToDecimal(txtRptInstallmentAmount.Text.Trim()) * Convert.ToInt32(txtRptNoofInstallmentsCompleted.Text.Trim())).ToString());
                            txtRptPrincipalAmountDUE.Text = Math.Round((Convert.ToDecimal(txtRptTermLoanAvailed.Text) - CompletedPrincipleAmount),2).ToString();
                        }
                    }
                }
                if (txtRptPrincipalAmountDUE.Text != "")
                {
                    decimal ActualPrincipleDue = Convert.ToDecimal(txtRptPrincipalAmountDUE.Text), InstallmentAmount = Convert.ToDecimal(txtRptInstallmentAmount.Text);
                    decimal NewPrincipleDue = 0;
                    int NewInstallmentNo, CompletedInstallments;
                    foreach (RepeaterItem tt in rpt_eglibilepallavaddi.Items)
                    {
                        Repeater rptMonths = (Repeater)tt.FindControl("rptMonths");
                        foreach (RepeaterItem Row in rptMonths.Items)
                        {
                            Label lblPrincipalAmountDue = (Label)Row.FindControl("lblPrincipalAmountDue");
                            Label lblInstallmentNo = (Label)Row.FindControl("lblInstallmentNo");
                            if (Row.ItemIndex == 0)
                            {
                                lblPrincipalAmountDue.Text = ActualPrincipleDue.ToString();
                                NewPrincipleDue = ActualPrincipleDue - InstallmentAmount;
                                lblInstallmentNo.Text = (Convert.ToInt32(txtRptNoofInstallmentsCompleted.Text) + 1).ToString();
                            }
                            if (Row.ItemIndex == 1)
                            {
                                lblPrincipalAmountDue.Text = NewPrincipleDue.ToString();
                                NewPrincipleDue = NewPrincipleDue - InstallmentAmount;
                                lblInstallmentNo.Text = (Convert.ToInt32(txtRptNoofInstallmentsCompleted.Text) + 2).ToString();
                            }
                            if (Row.ItemIndex == 2)
                            {
                                lblPrincipalAmountDue.Text = NewPrincipleDue.ToString();
                                NewPrincipleDue = NewPrincipleDue - InstallmentAmount;
                                lblInstallmentNo.Text = (Convert.ToInt32(txtRptNoofInstallmentsCompleted.Text) + 3).ToString();
                            }
                            if (Row.ItemIndex == 3)
                            {
                                lblPrincipalAmountDue.Text = NewPrincipleDue.ToString();
                                NewPrincipleDue = NewPrincipleDue - InstallmentAmount;
                                lblInstallmentNo.Text = (Convert.ToInt32(txtRptNoofInstallmentsCompleted.Text) + 4).ToString();
                            }
                            if (Row.ItemIndex == 4)
                            {
                                lblPrincipalAmountDue.Text = NewPrincipleDue.ToString();
                                NewPrincipleDue = NewPrincipleDue - InstallmentAmount;
                                lblInstallmentNo.Text = (Convert.ToInt32(txtRptNoofInstallmentsCompleted.Text) + 5).ToString();
                            }
                            if (Row.ItemIndex == 5)
                            {
                                lblPrincipalAmountDue.Text = NewPrincipleDue.ToString();
                                NewPrincipleDue = NewPrincipleDue - InstallmentAmount;
                                lblInstallmentNo.Text = (Convert.ToInt32(txtRptNoofInstallmentsCompleted.Text) + 6).ToString();
                            }
                        }
                    }
                }
            }
        }
        protected void txtRptLoanInstallmentStartDt_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            RepeaterItem item = (RepeaterItem)txt.NamingContainer;
            HandleInstallmentStartDateChange(item);
        }
        protected void ddlRptPeriodOfInstallment_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            RepeaterItem item = (RepeaterItem)ddl.NamingContainer;

            HandleInstallmentStartDateChange(item);
        }
        protected void txtRateofInterest_TextChanged(object sender, EventArgs e)
        {
            /*TextBox txtRateofInterest = (TextBox)sender;
            RepeaterItem item = (RepeaterItem)txtRateofInterest.NamingContainer;*/

            foreach (RepeaterItem tt in rpt_eglibilepallavaddi.Items)
            {
                Repeater rptMonths = (Repeater)tt.FindControl("rptMonths");
                foreach (RepeaterItem Row in rptMonths.Items)
                {
                    Label lblPrincipalAmountDue = (Label)Row.FindControl("lblPrincipalAmountDue");
                    Label lblInstallmentNo = (Label)Row.FindControl("lblInstallmentNo");
                    Label lblInterestDue = (Label)Row.FindControl("lblInterestDue");
                    Label lbl75onInterestDue = (Label)Row.FindControl("lbl75onInterestDue");
                    Label lblInterestDue8 = (Label)Row.FindControl("lblInterestDue8");
                    TextBox txtRateofInterest = (TextBox)Row.FindControl("txtRateofInterest");
                    int RateOfInterest = 0;
                    decimal IntrstDue75 = 0;
                    if (txtRateofInterest.Text != "")
                    {
                        RateOfInterest = Convert.ToInt32(txtRateofInterest.Text);
                        if (lblInterestDue.Text != "") { IntrstDue75 = Convert.ToDecimal(lblInterestDue.Text); }
                        lblInterestDue.Text = ((Convert.ToDecimal(lblPrincipalAmountDue.Text) * RateOfInterest) / 1200).ToString();
                        //lbl75onInterestDue.Text = (IntrstDue75 * 0.75).ToString();
                        lblInterestDue8.Text= ((Convert.ToDecimal(lblPrincipalAmountDue.Text) * 8) / 1200).ToString();
                    }
                }
            }
        }
       public static int GetMonthsDifference(DateTime start, DateTime end)
        {
            
            /*if (start > end)
            {
                var temp = start;
                start = end;
                end = temp;
            }*/

            int months = (end.Year - start.Year) * 12 + end.Month - start.Month;

           
            /*if (end.Day < start.Day)
                months--;*/

            return months;
        }
    }
}