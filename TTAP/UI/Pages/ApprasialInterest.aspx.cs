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

namespace TTAP.UI.Pages
{
    public partial class ApprasialInterest : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        CAFClass ObjCAFClass = new CAFClass();
        decimal InterestAmountPaid = 0;
        decimal SanctionedAmount = 0;
        decimal EligibleInterest = 0;
        decimal TotalPlintArea = 0, TotalOnetoNineValue = 0, TotalEighttoSeventeenValue = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindISCrrentClaimPeriodDtls("15136");// ("INCTEXT2022080519163");
                }
            }
            catch(Exception ex)
            {

            }
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
                    txtDCP_unit.Text = dsnew.Tables[1].Rows[0]["DCP"].ToString();
                }
                else
                {
                    GvInterestSubsidyPeriod.DataSource = null;
                    GvInterestSubsidyPeriod.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
        protected void btn_savegrdclaimperiodofloanadd_Click(object sender, EventArgs e)
        {
            DateTime? DateofCommencementofactivity = null;
            if (txtDCP_unit.Text != null)
            {
                DateofCommencementofactivity = Convert.ToDateTime(txtDCP_unit.Text);
            }
            try
            {
                // DataSet ds_loantype = new DataSet();
                DataTable dt_grid = new DataTable();
                dt_grid.Columns.Add("IncentiveId", typeof(string));
                dt_grid.Columns.Add("FinancialYear", typeof(string));
                dt_grid.Columns.Add("FinancialYearID", typeof(string));
                dt_grid.Columns.Add("FinancialYearName", typeof(string));
                dt_grid.Columns.Add("LoanNumber", typeof(int));

                //dt_grid.Columns.Add("DCPDATE", typeof(DateTime?));
                //dt_grid.Columns.Add("InstallmentStartdate", typeof(DateTime?));
                dt_grid.Columns.Add("DCPDATE", typeof(string));
                dt_grid.Columns.Add("InstallmentStartdate", typeof(string));
                dt_grid.Columns.Add("TotalTermLoanAmt", typeof(decimal));

                dt_grid.Columns.Add("PeriodofinstallmentID", typeof(string));
                dt_grid.Columns.Add("PeriodofinstallmentName", typeof(string));
                dt_grid.Columns.Add("Noofinstallment", typeof(int));

                dt_grid.Columns.Add("RateofInterest", typeof(string));
                dt_grid.Columns.Add("EglibleRateofInterestreimbursement", typeof(string));
                dt_grid.Columns.Add("InstallmentAmount", typeof(string));
                dt_grid.Columns.Add("NoofInstallmentCompleted", typeof(string));
                dt_grid.Columns.Add("PrincipalAmountthishalfyear", typeof(string));
                dt_grid.Columns.Add("GM_Rcon_Amount", typeof(string));

                string GM_Rcon_Amount = "0";
                if (Convert.ToString(Session["GM_Rcon_Amount"]) != "")
                {
                    GM_Rcon_Amount = Convert.ToString(Session["GM_Rcon_Amount"]);
                }
                if (Convert.ToString(txt_GMrecommendedamount.Text) != "")
                {
                    GM_Rcon_Amount = Convert.ToString(txt_GMrecommendedamount.Text);
                }


                for (int i = 0; i < GvInterestSubsidyPeriod.Rows.Count; i++)
                {
                    HiddenField hf_claimperiodofloanaddIncentiveId = GvInterestSubsidyPeriod.Rows[i].FindControl("hf_claimperiodofloanaddIncentiveId") as HiddenField;
                    HiddenField hf_claimperiodofloanaddFinancialYear = GvInterestSubsidyPeriod.Rows[i].FindControl("hf_claimperiodofloanaddFinancialYear") as HiddenField;
                    HiddenField hf_claimperiodofloanadd_ID = GvInterestSubsidyPeriod.Rows[i].FindControl("hf_claimperiodofloanadd_ID") as HiddenField;
                    Label lbl_claimperiodofloanaddname = GvInterestSubsidyPeriod.Rows[i].FindControl("lbl_claimperiodofloanaddname") as Label;
                    TextBox txt_claimperiodofloanaddNumber = GvInterestSubsidyPeriod.Rows[i].FindControl("txt_claimperiodofloanaddNumber") as TextBox;


                    if (!string.IsNullOrEmpty(txt_claimperiodofloanaddNumber.Text))
                    {
                        if (Convert.ToInt32(txt_claimperiodofloanaddNumber.Text) > 0)
                        {

                            for (int loanid = 0; loanid < Convert.ToInt32(txt_claimperiodofloanaddNumber.Text); loanid++)
                            {
                                DataRow drs = dt_grid.NewRow();
                                int test = loanid + 1;
                                drs["LoanNumber"] = loanid + 1;
                                drs["IncentiveId"] = Convert.ToString(hf_claimperiodofloanaddIncentiveId.Value);
                                drs["FinancialYear"] = Convert.ToString(hf_claimperiodofloanaddFinancialYear.Value);
                                drs["FinancialYearID"] = Convert.ToString(hf_claimperiodofloanadd_ID.Value);
                                drs["FinancialYearName"] = Convert.ToString(lbl_claimperiodofloanaddname.Text);
                                drs["DCPDATE"] = DateofCommencementofactivity;
                                drs["GM_Rcon_Amount"] = GM_Rcon_Amount;
                                dt_grid.Rows.Add(drs);
                            }

                            // txt_DateofCommencementofactivity.Text =Convert.ToDateTime(ds.Tables[0].Rows[0]["CommencmentOfCommrclProdcn_Date"]).ToString("dd/MM/yyyy");
                        }
                    }


                }

                DataSet ds_loantype = new DataSet();
                ds_loantype.Tables.Add(dt_grid);
                if (dt_grid.Rows.Count > 0)
                {
                    //grd_claimeglibleincentivesloanwise.DataSource = dt_grid;
                    //grd_claimeglibleincentivesloanwise.DataBind();
                    //grd_claimeglibleincentivesloanwise.Visible = true;
                    grd_eglibilepallavaddi.DataSource = dt_grid;
                    grd_eglibilepallavaddi.DataBind();
                    grd_eglibilepallavaddi.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void txt_claimeglibleincentivesloanwiseDateofCommencementofactivity_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");



            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void txt_claimeglibleincentivesloanwiseinstallmentstartdate_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount, hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void ddl_claimeglibleincentivesloanwiseperiodofinstallment_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList lnk_view = (DropDownList)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void txt_claimeglibleincentivesloanwisenoofinstallment_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void txt_claimeglibleincentivesloanwiseInstallmentamount_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount
    , hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void txt_claimeglibleincentivesloanwiseRateofInterest_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

        }

        protected void txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

        }

        protected void txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;
            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

        }

        protected void txt_grdeglibilepallavaddiEligibleperiodinmonths_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow gvgrd_eglibilepallavaddiRow = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

        }

        protected void txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

        }

        protected void txt_grdeglibilepallavaddiActualinterestamountpaid_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

        }

        protected void txt_grdeglibilepallavaddiInsertreimbursementcalculated_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest,
    lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

        }

        protected void txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");
            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

        }

        protected void rbtgrdeglibilepallavaddi_isbelated_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList lnk_view = (RadioButtonList)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");



            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

        }

        protected void txt_grdeglibilepallavaddiGMrecommendedamount_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }


        protected void lbl_grd_monthoneRateofinterest_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");



            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void lbl_grd_monthtwoRateofinterest_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void lbl_grd_monththreeRateofinterest_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");

            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest,
    lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void lbl_grd_monthfourRateofinterest_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void lbl_grd_monthfiveRateofinterest_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void lbl_grd_monthsixRateofinterest_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest
    , lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void txt_claimeglibleincentivesloanwiseConsideredAmountforInterest_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest,
    lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths_TextChanged(object sender, EventArgs e)
        {
            TextBox lnk_view = (TextBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest,
    lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }



        protected void chk_claimeglibleincenloanwisepreviousfymot_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox lnk_view = (CheckBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");



            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest,
    lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void chk_moratiumapplforthisclaimperiod_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox lnk_view = (CheckBox)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");


            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest,
    lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable);


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }

        protected void chk_grdclaimegliblerowstodisable_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBoxList lnk_view = (CheckBoxList)sender;
            GridViewRow grd_eglibilepallavaddi = (GridViewRow)lnk_view.Parent.Parent;

            //HiddenField hf_AdmissionID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //Label hf_AdmissionID = (Label)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //TextBox hf_AdmissionID = (TextBox)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //DropDownList hf_AdmissionID = (DropDownList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");
            //RadioButtonList hf_AdmissionID = (RadioButtonList)grd_eglibilepallavaddi.FindControl("hf_AdmissionID");

            HiddenField hf_grdeglibilepallavaddiIncentiveId = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiIncentiveId");
            HiddenField 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 = (HiddenField)grd_eglibilepallavaddi.FindControl("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");
            HiddenField hf_grdeglibilepallavaddiFY_ID = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_grdeglibilepallavaddiFY_ID");

            Label lbl_grdeglibilepallavaddiFYname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grdeglibilepallavaddiFYname");
            Label lbl_claimeglibleincentivesloanwiseLoanID = (Label)grd_eglibilepallavaddi.FindControl("lbl_claimeglibleincentivesloanwiseLoanID");

            TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseDateofCommencementofactivity");
            TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseinstallmentstartdate");
            TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement");
            DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment = (DropDownList)grd_eglibilepallavaddi.FindControl("ddl_claimeglibleincentivesloanwiseperiodofinstallment");
            TextBox txt_claimeglibleincentivesloanwisenoofinstallment = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisenoofinstallment");
            TextBox txt_claimeglibleincentivesloanwiseInstallmentamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseInstallmentamount");
            TextBox txt_claimeglibleincentivesloanwiseRateofInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseRateofInterest");
            TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");

            HiddenField hfgrd_monthoneid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthoneid");
            Label lbl_grd_monthonename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthonename");
            Label lbl_grd_monthnonePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthnonePrincipalamounntdue");
            Label lbl_grd_monthoneNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneNoofInstallment");
            TextBox lbl_grd_monthoneRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneRateofinterest");
            Label lbl_grd_monthoneInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneInterestamount");
            Label lbl_grd_monthoneUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneUnitHolderContribution");
            Label lbl_grd_monthoneEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleRateofinterest");
            Label lbl_grd_monthoneEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthoneEligibleInterestAmount");

            HiddenField hfgrd_monthtwoid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthtwoid");
            Label lbl_grd_monthtwoname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoname");
            Label lbl_grd_monthtwoPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoPrincipalamounntdue");
            Label lbl_grd_monthtwoNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoNoofInstallment");
            TextBox lbl_grd_monthtwoRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoRateofinterest");
            Label lbl_grd_monthtwoInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoInterestamount");
            Label lbl_grd_monthtwoUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoUnitHolderContribution");
            Label lbl_grd_monthtwoEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleRateofinterest");
            Label lbl_grd_monthtwoEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthtwoEligibleInterestAmount");

            HiddenField hfgrd_monththreeid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monththreeid");
            Label lbl_grd_monththreename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreename");
            Label lbl_grd_monththreePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreePrincipalamounntdue");
            Label lbl_grd_monththreeNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeNoofInstallment");
            TextBox lbl_grd_monththreeRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeRateofinterest");
            Label lbl_grd_monththreeInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeInterestamount");
            Label lbl_grd_monththreeUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeUnitHolderContribution");
            Label lbl_grd_monththreeEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleRateofinterest");
            Label lbl_grd_monththreeEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monththreeEligibleInterestAmount");

            HiddenField hfgrd_monthfourid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfourid");
            Label lbl_grd_monthfourname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourname");
            Label lbl_grd_monthfourPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourPrincipalamounntdue");
            Label lbl_grd_monthfourNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourNoofInstallment");
            TextBox lbl_grd_monthfourRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourRateofinterest");
            Label lbl_grd_monthfourInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourInterestamount");
            Label lbl_grd_monthfourUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourUnitHolderContribution");
            Label lbl_grd_monthfourEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleRateofinterest");
            Label lbl_grd_monthfourEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfourEligibleInterestAmount");

            HiddenField hfgrd_monthfiveid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthfiveid");
            Label lbl_grd_monthfivename = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivename");
            Label lbl_grd_monthfivePrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfivePrincipalamounntdue");
            Label lbl_grd_monthfiveNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveNoofInstallment");
            TextBox lbl_grd_monthfiveRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveRateofinterest");
            Label lbl_grd_monthfiveInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveInterestamount");
            Label lbl_grd_monthfiveUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveUnitHolderContribution");
            Label lbl_grd_monthfiveEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleRateofinterest");
            Label lbl_grd_monthfiveEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthfiveEligibleInterestAmount");

            HiddenField hfgrd_monthsixid = (HiddenField)grd_eglibilepallavaddi.FindControl("hfgrd_monthsixid");
            Label lbl_grd_monthsixname = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixname");
            Label lbl_grd_monthsixPrincipalamounntdue = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixPrincipalamounntdue");
            Label lbl_grd_monthsixNoofInstallment = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixNoofInstallment");
            TextBox lbl_grd_monthsixRateofinterest = (TextBox)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixRateofinterest");
            Label lbl_grd_monthsixInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixInterestamount");
            Label lbl_grd_monthsixUnitHolderContribution = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixUnitHolderContribution");
            Label lbl_grd_monthsixEligibleRateofinterest = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleRateofinterest");
            Label lbl_grd_monthsixEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_monthsixEligibleInterestAmount");

            TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleperiodinmonths");
            TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations");
            TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid");
            TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated");
            RadioButtonList rbtgrdeglibilepallavaddi_isbelated = (RadioButtonList)grd_eglibilepallavaddi.FindControl("rbtgrdeglibilepallavaddi_isbelated");
            TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype");
            TextBox txt_grdeglibilepallavaddiGMrecommendedamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiGMrecommendedamount");
            TextBox txt_grdeglibilepallavaddiEligibleamount = (TextBox)grd_eglibilepallavaddi.FindControl("txt_grdeglibilepallavaddiEligibleamount");

            TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest");
            Label lbl_grd_totmonthsInterestamount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsInterestamount");
            Label lbl_grd_totmonthsEligibleInterestAmount = (Label)grd_eglibilepallavaddi.FindControl("lbl_grd_totmonthsEligibleInterestAmount");

            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted");
            HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");
            HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR = (HiddenField)grd_eglibilepallavaddi.FindControl("hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR");
            TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths = (TextBox)grd_eglibilepallavaddi.FindControl("txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths");

            CheckBox chk_claimeglibleincenloanwisepreviousfymot = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_claimeglibleincenloanwisepreviousfymot");
            CheckBox chk_moratiumapplforthisclaimperiod = (CheckBox)grd_eglibilepallavaddi.FindControl("chk_moratiumapplforthisclaimperiod");
            CheckBoxList chk_grdclaimegliblerowstodisable = (CheckBoxList)grd_eglibilepallavaddi.FindControl("chk_grdclaimegliblerowstodisable");



            string errorgmsg = getdynamicallyeachrowdata_eligibleincentives(
    hf_grdeglibilepallavaddiIncentiveId, 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, hf_grdeglibilepallavaddiFY_ID, lbl_grdeglibilepallavaddiFYname,
    lbl_claimeglibleincentivesloanwiseLoanID, txt_claimeglibleincentivesloanwiseDateofCommencementofactivity,
    txt_claimeglibleincentivesloanwiseinstallmentstartdate, txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement,
    ddl_claimeglibleincentivesloanwiseperiodofinstallment, txt_claimeglibleincentivesloanwisenoofinstallment,
    txt_claimeglibleincentivesloanwiseInstallmentamount, txt_claimeglibleincentivesloanwiseRateofInterest,
    txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement, txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted,
    txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
    hfgrd_monthoneid, lbl_grd_monthonename, lbl_grd_monthnonePrincipalamounntdue, lbl_grd_monthoneNoofInstallment, lbl_grd_monthoneRateofinterest,
    lbl_grd_monthoneInterestamount, lbl_grd_monthoneUnitHolderContribution, lbl_grd_monthoneEligibleRateofinterest, lbl_grd_monthoneEligibleInterestAmount,
    hfgrd_monthtwoid, lbl_grd_monthtwoname, lbl_grd_monthtwoPrincipalamounntdue, lbl_grd_monthtwoNoofInstallment, lbl_grd_monthtwoRateofinterest,
    lbl_grd_monthtwoInterestamount, lbl_grd_monthtwoUnitHolderContribution, lbl_grd_monthtwoEligibleRateofinterest, lbl_grd_monthtwoEligibleInterestAmount,
    hfgrd_monththreeid, lbl_grd_monththreename, lbl_grd_monththreePrincipalamounntdue, lbl_grd_monththreeNoofInstallment,
    lbl_grd_monththreeRateofinterest, lbl_grd_monththreeInterestamount, lbl_grd_monththreeUnitHolderContribution,
    lbl_grd_monththreeEligibleRateofinterest, lbl_grd_monththreeEligibleInterestAmount,
    hfgrd_monthfourid, lbl_grd_monthfourname, lbl_grd_monthfourPrincipalamounntdue, lbl_grd_monthfourNoofInstallment,
    lbl_grd_monthfourRateofinterest, lbl_grd_monthfourInterestamount, lbl_grd_monthfourUnitHolderContribution,
    lbl_grd_monthfourEligibleRateofinterest, lbl_grd_monthfourEligibleInterestAmount,
    hfgrd_monthfiveid, lbl_grd_monthfivename, lbl_grd_monthfivePrincipalamounntdue, lbl_grd_monthfiveNoofInstallment,
    lbl_grd_monthfiveRateofinterest, lbl_grd_monthfiveInterestamount, lbl_grd_monthfiveUnitHolderContribution,
    lbl_grd_monthfiveEligibleRateofinterest, lbl_grd_monthfiveEligibleInterestAmount,
    hfgrd_monthsixid, lbl_grd_monthsixname, lbl_grd_monthsixPrincipalamounntdue, lbl_grd_monthsixNoofInstallment, lbl_grd_monthsixRateofinterest,
    lbl_grd_monthsixInterestamount, lbl_grd_monthsixUnitHolderContribution, lbl_grd_monthsixEligibleRateofinterest,
    lbl_grd_monthsixEligibleInterestAmount,
    txt_grdeglibilepallavaddiEligibleperiodinmonths, txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
    txt_grdeglibilepallavaddiActualinterestamountpaid, txt_grdeglibilepallavaddiInsertreimbursementcalculated,
    rbtgrdeglibilepallavaddi_isbelated, txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
    txt_grdeglibilepallavaddiGMrecommendedamount, txt_grdeglibilepallavaddiEligibleamount, txt_claimeglibleincentivesloanwiseConsideredAmountforInterest,
    lbl_grd_totmonthsInterestamount, lbl_grd_totmonthsEligibleInterestAmount,
    hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
    chk_claimeglibleincenloanwisepreviousfymot, chk_moratiumapplforthisclaimperiod, chk_grdclaimegliblerowstodisable
    );


            if (errorgmsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errorgmsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
        }
        public string getdynamicallyeachrowdata_eligibleincentives(
        HiddenField hf_grdeglibilepallavaddiIncentiveId, HiddenField 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, HiddenField hf_grdeglibilepallavaddiFY_ID,
        Label lbl_grdeglibilepallavaddiFYname, Label lbl_claimeglibleincentivesloanwiseLoanID,
        TextBox txt_claimeglibleincentivesloanwiseDateofCommencementofactivity, TextBox txt_claimeglibleincentivesloanwiseinstallmentstartdate,
        TextBox txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement, DropDownList ddl_claimeglibleincentivesloanwiseperiodofinstallment,
        TextBox txt_claimeglibleincentivesloanwisenoofinstallment, TextBox txt_claimeglibleincentivesloanwiseInstallmentamount,
        TextBox txt_claimeglibleincentivesloanwiseRateofInterest, TextBox txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement,
        TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted, TextBox txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR,
        HiddenField hfgrd_monthoneid, Label lbl_grd_monthonename, Label lbl_grd_monthnonePrincipalamounntdue, Label lbl_grd_monthoneNoofInstallment,
        TextBox lbl_grd_monthoneRateofinterest, Label lbl_grd_monthoneInterestamount, Label lbl_grd_monthoneUnitHolderContribution,
        Label lbl_grd_monthoneEligibleRateofinterest, Label lbl_grd_monthoneEligibleInterestAmount,
        HiddenField hfgrd_monthtwoid, Label lbl_grd_monthtwoname, Label lbl_grd_monthtwoPrincipalamounntdue, Label lbl_grd_monthtwoNoofInstallment,
        TextBox lbl_grd_monthtwoRateofinterest, Label lbl_grd_monthtwoInterestamount, Label lbl_grd_monthtwoUnitHolderContribution,
        Label lbl_grd_monthtwoEligibleRateofinterest, Label lbl_grd_monthtwoEligibleInterestAmount,
        HiddenField hfgrd_monththreeid, Label lbl_grd_monththreename, Label lbl_grd_monththreePrincipalamounntdue, Label lbl_grd_monththreeNoofInstallment,
        TextBox lbl_grd_monththreeRateofinterest, Label lbl_grd_monththreeInterestamount, Label lbl_grd_monththreeUnitHolderContribution,
        Label lbl_grd_monththreeEligibleRateofinterest, Label lbl_grd_monththreeEligibleInterestAmount,
        HiddenField hfgrd_monthfourid, Label lbl_grd_monthfourname, Label lbl_grd_monthfourPrincipalamounntdue, Label lbl_grd_monthfourNoofInstallment,
        TextBox lbl_grd_monthfourRateofinterest, Label lbl_grd_monthfourInterestamount, Label lbl_grd_monthfourUnitHolderContribution,
        Label lbl_grd_monthfourEligibleRateofinterest, Label lbl_grd_monthfourEligibleInterestAmount,
        HiddenField hfgrd_monthfiveid, Label lbl_grd_monthfivename, Label lbl_grd_monthfivePrincipalamounntdue, Label lbl_grd_monthfiveNoofInstallment,
        TextBox lbl_grd_monthfiveRateofinterest, Label lbl_grd_monthfiveInterestamount, Label lbl_grd_monthfiveUnitHolderContribution,
        Label lbl_grd_monthfiveEligibleRateofinterest, Label lbl_grd_monthfiveEligibleInterestAmount,
        HiddenField hfgrd_monthsixid, Label lbl_grd_monthsixname, Label lbl_grd_monthsixPrincipalamounntdue, Label lbl_grd_monthsixNoofInstallment,
        TextBox lbl_grd_monthsixRateofinterest, Label lbl_grd_monthsixInterestamount, Label lbl_grd_monthsixUnitHolderContribution,
        Label lbl_grd_monthsixEligibleRateofinterest, Label lbl_grd_monthsixEligibleInterestAmount,
        TextBox txt_grdeglibilepallavaddiEligibleperiodinmonths, TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations,
        TextBox txt_grdeglibilepallavaddiActualinterestamountpaid, TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated,
        RadioButtonList rbtgrdeglibilepallavaddi_isbelated, TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype,
        TextBox txt_grdeglibilepallavaddiGMrecommendedamount, TextBox txt_grdeglibilepallavaddiEligibleamount,
        TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest, Label lbl_grd_totmonthsInterestamount, Label lbl_grd_totmonthsEligibleInterestAmount,
        HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted, HiddenField hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
         HiddenField hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR, TextBox txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths,
         CheckBox chk_claimeglibleincenloanwisepreviousfymot, CheckBox chk_moratiumapplforthisclaimperiod, CheckBoxList chk_grdclaimegliblerowstodisable)
        {
            int slno = 1;
            string ErrorMsg = "";

            txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Enabled = false;
            txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths.Enabled = false;
            chk_claimeglibleincenloanwisepreviousfymot.Enabled = false;
            chk_moratiumapplforthisclaimperiod.Enabled = false;
            chk_grdclaimegliblerowstodisable.Enabled = false;

            DateTime dcpdate = DateTime.Now; DateTime installmentstartdate = DateTime.Now;
            decimal Totalamount = 0; int periodofinstallment = 0;
            int Totalinstallment = 0; decimal installmentamount = 0; int noofinstallmentcompleted = 0; decimal termprincipaldueamount = 0;
            int noofinstallmentcompletedMonths = 0;
            int Actualcalnoofinstallmentcompleted = 0; decimal Actualcaltermprincipaldueamount = 0; int ActualcalnoofinstallmentcompletedMonths = 0;
            int FYSlnoofIncentiveID = 0;
            int firstsecondhalfyearclaimtype = 0;
            int fyStartyear = 0;
            int fystartmonth = 0;
            int fyendyear = 0;
            int fyendmonth = 0;
            int totalclaimperiod = 6;
            bool previousmotrage = false;
            bool motrageforclaim = false;
            bool noofrowsdisablesel = false;
            int numSelected = 0; int unselectednumber = 0;
            decimal Toteglibleperiodinmonths = 0; decimal totalinterestforallfy = 0; decimal totaleglibleinterestforallfy = 0;

            decimal rateofinterestMonthone = 0, rateofinterestMonthtwo = 0, rateofinterestMonththree = 0, rateofinterestMonthfour = 0,
                rateofinterestMonthfive = 0, rateofinterestMonthsix = 0;

            //int InstallmentNoMonthone = 0,InstallmentNoMonthtwo = 0,InstallmentNoMonththree = 0,InstallmentNoMonthfour = 0,InstallmentNoMonthfive = 0,InstallmentNoMonthsix = 0;

            int dcpyearsofdate = 5;
            if (Convert.ToString(lbl_schemetide.Text) == "TTAP" )
            {
                dcpyearsofdate = 6;
            }

            //DateTime fiveyearsdate = dcpdate.AddYears(dcpyearsofdate);


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
            }

            if (txt_claimeglibleincentivesloanwiseDateofCommencementofactivity.Text.TrimStart().TrimEnd().Trim() != "")
            {

                dcpdate = Convert.ToDateTime(txt_claimeglibleincentivesloanwiseDateofCommencementofactivity.Text);
            }
            if (txt_claimeglibleincentivesloanwiseinstallmentstartdate.Text.TrimStart().TrimEnd().Trim() != "")
            {

                installmentstartdate = Convert.ToDateTime(txt_claimeglibleincentivesloanwiseinstallmentstartdate.Text);
            }

            if (txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement.Text != "")
            {
                Totalamount = Convert.ToDecimal(txt_claimeglibleincentivesloanwiseeglsacamountinterestreimbursement.Text);
            }

            if (ddl_claimeglibleincentivesloanwiseperiodofinstallment.SelectedIndex > 0)
            {
                periodofinstallment = Convert.ToInt32(ddl_claimeglibleincentivesloanwiseperiodofinstallment.SelectedValue);
            }

            if (txt_claimeglibleincentivesloanwisenoofinstallment.Text.TrimStart().TrimEnd().Trim() != "")
            {
                Totalinstallment = Convert.ToInt32(txt_claimeglibleincentivesloanwisenoofinstallment.Text);
            }
            if (Totalinstallment > 0 && Totalamount > 0)
            {
                installmentamount = Totalamount / Totalinstallment;
                txt_claimeglibleincentivesloanwiseInstallmentamount.Text = Convert.ToString(Math.Round(installmentamount, 2));
            }
            else
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Total installment above '0'/Total Term Loan Availed above zero \\n";
                slno = slno + 1;
            }

            if (lbl_grd_monthoneRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
            {
                rateofinterestMonthone = Convert.ToDecimal(lbl_grd_monthoneRateofinterest.Text);
            }
            if (lbl_grd_monthtwoRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
            {
                rateofinterestMonthtwo = Convert.ToDecimal(lbl_grd_monthtwoRateofinterest.Text);
            }
            if (lbl_grd_monththreeRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
            {
                rateofinterestMonththree = Convert.ToDecimal(lbl_grd_monththreeRateofinterest.Text);
            }
            if (lbl_grd_monthfourRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
            {
                rateofinterestMonthfour = Convert.ToDecimal(lbl_grd_monthfourRateofinterest.Text);
            }
            if (lbl_grd_monthfiveRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
            {
                rateofinterestMonthfive = Convert.ToDecimal(lbl_grd_monthfiveRateofinterest.Text);
            }
            if (lbl_grd_monthsixRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
            {
                rateofinterestMonthsix = Convert.ToDecimal(lbl_grd_monthsixRateofinterest.Text);
            }

            if (dcpdate.Date != DateTime.Now.Date)
            {
                if (installmentstartdate.Date != DateTime.Now.Date)
                {
                    //if (dcpdate.Date < DateTime.Now.Date && installmentstartdate.Date < DateTime.Now.Date)
                    //{
                    DateTime fiveyearsdate = dcpdate.AddYears(dcpyearsofdate);
                    DateTime Claimperiodstartdate = new DateTime(Convert.ToInt32(fyStartyear), fystartmonth, 01);
                    DateTime fyendstss = new DateTime(fyendyear, fyendmonth, 1);
                    DateTime Claimperiodenddate = fyendstss.AddMonths(1).AddDays(-1);
                    if (Totalamount > 0 && dcpdate != null && periodofinstallment > 0 &&
                     Totalinstallment > 0 && installmentamount > 0 && fyStartyear > 0 && fystartmonth > 0
                           && fyendyear > 0 && fyendmonth > 0 && installmentstartdate != null)
                    {

                        #region No of  Installment completed,Months

                        int totalmonthcal = 0;
                        int totaltwoyearscal = 0;
                        int totalmonthbwtwoyears = 0;
                        if (fyStartyear == installmentstartdate.Year)
                        {
                            totaltwoyearscal = 0;
                            if (fystartmonth > installmentstartdate.Month)
                            {
                                //dcp date start before financial year
                                totalmonthcal = (fystartmonth - installmentstartdate.Month);
                            }
                            else
                            {
                                totalmonthcal = 0;
                            }
                            totalmonthbwtwoyears = totaltwoyearscal + totalmonthcal;
                        }
                        else if (installmentstartdate.Year < fyStartyear)
                        {
                            totaltwoyearscal = ((fyStartyear - installmentstartdate.Year) * 12);
                            totalmonthcal = (fystartmonth - installmentstartdate.Month);

                            totalmonthbwtwoyears = totaltwoyearscal + totalmonthcal;
                        }
                        else if (installmentstartdate.Year > fyStartyear)
                        {
                            totaltwoyearscal = 0;
                            totalmonthcal = 0;
                            totalmonthbwtwoyears = totaltwoyearscal + totalmonthcal;
                        }

                        int quotientcompleted = 0;
                        if (periodofinstallment == 1)
                        {
                            //Yearly
                            quotientcompleted = totalmonthbwtwoyears / 12;
                            ActualcalnoofinstallmentcompletedMonths = totalmonthbwtwoyears % 12;
                            //noofinstallmentcompletedMonths = totalmonthbwtwoyears % 12;
                        }
                        else if (periodofinstallment == 2)
                        {
                            //halfyear
                            quotientcompleted = totalmonthbwtwoyears / 6;
                            ActualcalnoofinstallmentcompletedMonths = totalmonthbwtwoyears % 6;
                            //noofinstallmentcompletedMonths = totalmonthbwtwoyears % 6;
                        }
                        else if (periodofinstallment == 3)
                        {
                            //quaertly
                            quotientcompleted = totalmonthbwtwoyears / 3;
                            ActualcalnoofinstallmentcompletedMonths = totalmonthbwtwoyears % 3;
                            //noofinstallmentcompletedMonths = totalmonthbwtwoyears % 3;
                        }
                        else if (periodofinstallment == 4)
                        {
                            //Monthly
                            quotientcompleted = totalmonthbwtwoyears;
                            ActualcalnoofinstallmentcompletedMonths = 0;
                            //noofinstallmentcompletedMonths = 0;
                        }
                        // noofinstallmentcompleted = quotientcompleted;
                        //noofinstallmentcompletedMonths = ActualcalnoofinstallmentcompletedMonths;
                        Actualcalnoofinstallmentcompleted = quotientcompleted;

                        #endregion
                        #region moratorium condition
                        if (Claimperiodenddate.Date < installmentstartdate.Date)
                        {
                            //Installment start date did't in this finanical year
                            //ErrorMsg = ErrorMsg + slno + ". Installment start date did't in this finanical year Motage will not apply   \\n";
                            //slno = slno + 1;
                            noofinstallmentcompleted = Actualcalnoofinstallmentcompleted;
                            noofinstallmentcompletedMonths = ActualcalnoofinstallmentcompletedMonths;
                            chk_claimeglibleincenloanwisepreviousfymot.Checked = false;
                            chk_moratiumapplforthisclaimperiod.Checked = false;
                        }
                        else
                        {
                            if (Claimperiodstartdate.Date < installmentstartdate.Date)
                            {
                                //claim period started but,installment didn't started
                                //ErrorMsg = ErrorMsg + slno + ". Claim Period started,but Installment didn't started Motage will not apply   \\n";
                                //slno = slno + 1;
                                noofinstallmentcompleted = Actualcalnoofinstallmentcompleted;
                                noofinstallmentcompletedMonths = ActualcalnoofinstallmentcompletedMonths;
                                chk_claimeglibleincenloanwisepreviousfymot.Checked = false;
                                chk_moratiumapplforthisclaimperiod.Checked = false;
                            }
                            else
                            {
                                if (Actualcalnoofinstallmentcompleted > 0)
                                {
                                    chk_claimeglibleincenloanwisepreviousfymot.Enabled = true;
                                }
                                if (ActualcalnoofinstallmentcompletedMonths > 0)
                                {
                                    chk_claimeglibleincenloanwisepreviousfymot.Enabled = true;
                                }

                                chk_moratiumapplforthisclaimperiod.Enabled = true;
                                if (chk_claimeglibleincenloanwisepreviousfymot.Checked == true)
                                {
                                    //Previous motrage
                                    previousmotrage = true;
                                    txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Enabled = true;
                                    if (periodofinstallment != 4)
                                    {
                                        txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths.Enabled = true;
                                    }
                                }
                                if (chk_moratiumapplforthisclaimperiod.Checked == true)
                                {
                                    //Current motrage
                                    motrageforclaim = true;
                                    chk_grdclaimegliblerowstodisable.Enabled = true;
                                }
                                else
                                {
                                    foreach (ListItem li in chk_grdclaimegliblerowstodisable.Items)
                                    {
                                        li.Selected = false;
                                    }
                                }

                                if (chk_grdclaimegliblerowstodisable.Enabled == true)
                                {

                                    for (int m = 0; m < chk_grdclaimegliblerowstodisable.Items.Count; m++)
                                    {
                                        if (chk_grdclaimegliblerowstodisable.Items[m].Selected == true)// getting selected value from CheckBox List  
                                        {
                                            numSelected = numSelected + 1;
                                            if (m == 0)
                                            {
                                                lbl_grd_monthoneRateofinterest.Enabled = false;
                                                lbl_grd_monthoneRateofinterest.Text = "0";
                                                rateofinterestMonthone = 0;
                                            }
                                            if (m == 1)
                                            {
                                                lbl_grd_monthtwoRateofinterest.Enabled = false;
                                                lbl_grd_monthtwoRateofinterest.Text = "0";
                                                rateofinterestMonthtwo = 0;
                                            }
                                            if (m == 2)
                                            {
                                                lbl_grd_monththreeRateofinterest.Enabled = false;
                                                lbl_grd_monththreeRateofinterest.Text = "0";
                                                rateofinterestMonththree = 0;
                                            }
                                            if (m == 3)
                                            {
                                                lbl_grd_monthfourRateofinterest.Enabled = false;
                                                lbl_grd_monthfourRateofinterest.Text = "0";
                                                rateofinterestMonthfour = 0;
                                            }
                                            if (m == 4)
                                            {
                                                lbl_grd_monthfiveRateofinterest.Enabled = false;
                                                lbl_grd_monthfiveRateofinterest.Text = "0";
                                                rateofinterestMonthfive = 0;
                                            }
                                            if (m == 5)
                                            {
                                                lbl_grd_monthsixRateofinterest.Enabled = false;
                                                lbl_grd_monthsixRateofinterest.Text = "0";
                                                rateofinterestMonthsix = 0;
                                            }

                                        }
                                        else
                                        {
                                            if (m == 0)
                                            {
                                                lbl_grd_monthoneRateofinterest.Enabled = true;
                                                rateofinterestMonthone = Convert.ToDecimal(lbl_grd_monthoneRateofinterest.Text);
                                            }
                                            if (m == 1)
                                            {
                                                lbl_grd_monthtwoRateofinterest.Enabled = true;
                                                rateofinterestMonthtwo = Convert.ToDecimal(lbl_grd_monthtwoRateofinterest.Text);
                                            }
                                            if (m == 2)
                                            {
                                                lbl_grd_monththreeRateofinterest.Enabled = true;
                                                rateofinterestMonththree = Convert.ToDecimal(lbl_grd_monththreeRateofinterest.Text);
                                            }
                                            if (m == 3)
                                            {
                                                lbl_grd_monthfourRateofinterest.Enabled = true;
                                                rateofinterestMonthfour = Convert.ToDecimal(lbl_grd_monthfourRateofinterest.Text);
                                            }
                                            if (m == 4)
                                            {
                                                lbl_grd_monthfiveRateofinterest.Enabled = true;
                                                rateofinterestMonthfive = Convert.ToDecimal(lbl_grd_monthfiveRateofinterest.Text);
                                            }
                                            if (m == 5)
                                            {
                                                lbl_grd_monthsixRateofinterest.Enabled = true;
                                                rateofinterestMonthsix = Convert.ToDecimal(lbl_grd_monthsixRateofinterest.Text);
                                            }
                                        }

                                    }

                                    if (numSelected <= 0)
                                    {
                                        //Error
                                        ErrorMsg = ErrorMsg + slno + ". Please select the row month which are not eglible for the interest Amount \\n";
                                        slno = slno + 1;
                                    }
                                    else
                                    {
                                        noofrowsdisablesel = true;
                                    }
                                }
                                else
                                {
                                    lbl_grd_monthoneRateofinterest.Enabled = true;
                                    lbl_grd_monthtwoRateofinterest.Enabled = true;
                                    lbl_grd_monththreeRateofinterest.Enabled = true;
                                    lbl_grd_monthfourRateofinterest.Enabled = true;
                                    lbl_grd_monthfiveRateofinterest.Enabled = true;
                                    lbl_grd_monthsixRateofinterest.Enabled = true;
                                }

                                if (chk_claimeglibleincenloanwisepreviousfymot.Checked == true)
                                {
                                    //installment completed
                                    if (txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Text.TrimStart().TrimEnd().Trim() != "")
                                    {
                                        if (Convert.ToInt32(txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Text) > 0)
                                        {
                                            //Motrage installmennt completed should be less than actual installment completed
                                            if (Convert.ToInt32(txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Text) <= Actualcalnoofinstallmentcompleted)
                                            {
                                                noofinstallmentcompleted = Convert.ToInt32(txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Text);
                                            }
                                            else
                                            {
                                                noofinstallmentcompleted = Actualcalnoofinstallmentcompleted;
                                            }

                                        }
                                        else
                                        {
                                            noofinstallmentcompleted = Actualcalnoofinstallmentcompleted;
                                        }

                                    }
                                    else
                                    {
                                        noofinstallmentcompleted = Actualcalnoofinstallmentcompleted;
                                    }

                                    //installment completed months
                                    if (txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths.Text.TrimStart().TrimEnd().Trim() != "")
                                    {
                                        if (Convert.ToInt32(txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths.Text) > 0)
                                        {
                                            if (periodofinstallment == 4)
                                            {
                                                //monthly
                                                noofinstallmentcompletedMonths = 0;
                                            }
                                            else
                                            {
                                                noofinstallmentcompletedMonths = Convert.ToInt32(txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths.Text);
                                            }
                                        }
                                        else
                                        {
                                            noofinstallmentcompletedMonths = ActualcalnoofinstallmentcompletedMonths;
                                        }
                                    }
                                    else
                                    {
                                        noofinstallmentcompletedMonths = ActualcalnoofinstallmentcompletedMonths;
                                    }
                                }
                                else
                                {
                                    noofinstallmentcompleted = Actualcalnoofinstallmentcompleted;
                                    noofinstallmentcompletedMonths = ActualcalnoofinstallmentcompletedMonths;
                                }

                                if (periodofinstallment == 1)
                                {
                                    //Yearly
                                    if (noofinstallmentcompletedMonths >= 12)
                                    {
                                        ErrorMsg = ErrorMsg + slno + ". Please Enter Installment Completed Months b/W 0 to 11 \\n";
                                        slno = slno + 1;
                                    }
                                }
                                else if (periodofinstallment == 2)
                                {
                                    //halfyear
                                    if (noofinstallmentcompletedMonths >= 6)
                                    {
                                        ErrorMsg = ErrorMsg + slno + ". Please Enter Installment Completed Months b/W 0 to 6 \\n";
                                        slno = slno + 1;
                                    }
                                }
                                else if (periodofinstallment == 3)
                                {
                                    //quaertly
                                    if (noofinstallmentcompletedMonths >= 3)
                                    {
                                        ErrorMsg = ErrorMsg + slno + ". Please Enter Installment Completed Months b/W 0 to 3\\n";
                                        slno = slno + 1;
                                    }
                                }
                                else
                                {
                                    if (noofinstallmentcompletedMonths > 0)
                                    {
                                        ErrorMsg = ErrorMsg + slno + ". Please Enter Installment Completed Months Zero(0)\\n";
                                        slno = slno + 1;
                                    }
                                }

                            }
                        }

                        #endregion


                        #region principalamountdue amount for this half year

                        int pramounttotalmonthcal = 0;
                        int pramounttotaltwoyearscal = 0;
                        int pramounttotalmonthbwtwoyears = 0;
                        if (fyStartyear == dcpdate.Year)
                        {
                            if (dcpdate.Month < fystartmonth)
                            {
                                //dcp date started before financial year
                                pramounttotalmonthcal = (fystartmonth - dcpdate.Month);
                            }
                            else
                            {
                                //dcp date started after financial year/in same month
                                pramounttotalmonthcal = 0;
                            }
                            pramounttotalmonthbwtwoyears = pramounttotaltwoyearscal + pramounttotalmonthcal;
                        }
                        else
                        {
                            if (dcpdate.Year < fyStartyear)
                            {
                                //dcp date started before finanical year
                                pramounttotaltwoyearscal = ((fyStartyear - dcpdate.Year) * 12);
                                pramounttotalmonthcal = (fystartmonth - dcpdate.Month);
                                pramounttotalmonthbwtwoyears = pramounttotaltwoyearscal + pramounttotalmonthcal;
                            }
                            else
                            {
                                if (dcpdate.Year > fyStartyear)
                                {
                                    ////dcp date started after finanical year
                                    pramounttotaltwoyearscal = 0;
                                    pramounttotalmonthcal = 0;
                                    pramounttotalmonthbwtwoyears = pramounttotaltwoyearscal + pramounttotalmonthcal;

                                }
                            }

                        }
                        int pramountquotientcompleted = 0;
                        int pramountremaindercompleted = 0;
                        if (periodofinstallment == 1)
                        {
                            //Yearly
                            pramountquotientcompleted = totalmonthbwtwoyears / 12;
                            pramountremaindercompleted = totalmonthbwtwoyears % 12;

                        }
                        else if (periodofinstallment == 2)
                        {
                            //halfyear
                            pramountquotientcompleted = totalmonthbwtwoyears / 6;
                            pramountremaindercompleted = totalmonthbwtwoyears % 6;
                        }
                        else if (periodofinstallment == 3)
                        {
                            //quaertly
                            pramountquotientcompleted = totalmonthbwtwoyears / 3;
                            pramountremaindercompleted = totalmonthbwtwoyears % 3;
                        }
                        else if (periodofinstallment == 4)
                        {
                            //Monthly
                            pramountquotientcompleted = totalmonthbwtwoyears;
                        }
                        if (pramountquotientcompleted == 0)
                        {
                            Actualcaltermprincipaldueamount = Totalamount;
                        }
                        else
                        {
                            //noofinstallment = noofinstallmentcompleted + unselectednumber;
                            //Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));

                            if (pramountremaindercompleted == 0)
                            {
                                Actualcaltermprincipaldueamount = (Totalamount - (installmentamount * pramountquotientcompleted));
                            }
                            else
                            {
                                Actualcaltermprincipaldueamount = (Totalamount - (installmentamount * pramountquotientcompleted));
                            }
                        }


                        if (previousmotrage == true)
                        {
                            //noofinstallment = noofinstallmentcompleted + unselectednumber;
                            //Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                            if (noofinstallmentcompleted > 0)
                            {
                                termprincipaldueamount = (Totalamount - (installmentamount * noofinstallmentcompleted - 1));
                            }
                            else
                            {
                                termprincipaldueamount = Actualcaltermprincipaldueamount;
                            }
                        }
                        else if (motrageforclaim == true)
                        {
                            if (noofinstallmentcompleted > 0)
                            {
                                termprincipaldueamount = (Totalamount - (installmentamount * pramountquotientcompleted));
                            }
                            else
                            {
                                termprincipaldueamount = Actualcaltermprincipaldueamount;
                            }
                        }
                        else
                        {
                            termprincipaldueamount = Actualcaltermprincipaldueamount;
                        }


                        #endregion


                        bool finalmortagecheckallcorrect = true;//if moratorium applied and didn't  selected row then false and if moratorium for this claim didnn't selected by default true;
                        if (motrageforclaim == true)
                        {
                            if (noofrowsdisablesel == true)
                            {
                                if (numSelected <= 0)
                                {
                                    finalmortagecheckallcorrect = false;
                                }
                            }
                        }


                        if (finalmortagecheckallcorrect == true)
                        {


                            #region Gridview display
                            //check total installment with completed installments
                            if (noofinstallmentcompleted <= Totalinstallment)
                            {

                                //check completed installments Moth Acc period of installment
                                bool allmonthscorrect = true;
                                if (periodofinstallment == 1)
                                {
                                    //Yearly
                                    if (noofinstallmentcompletedMonths >= 12)
                                    {
                                        allmonthscorrect = false;
                                    }
                                }
                                else if (periodofinstallment == 2)
                                {
                                    //halfyear
                                    if (noofinstallmentcompletedMonths >= 6)
                                    {
                                        allmonthscorrect = false;
                                    }
                                }
                                else if (periodofinstallment == 3)
                                {
                                    //quaertly
                                    if (noofinstallmentcompletedMonths >= 3)
                                    {
                                        allmonthscorrect = false;
                                    }
                                }
                                else if (periodofinstallment == 4)
                                {
                                    //Monthly
                                    if (noofinstallmentcompletedMonths > 0)
                                    {
                                        allmonthscorrect = false;
                                    }
                                }

                                if (allmonthscorrect == true)
                                {
                                    if (termprincipaldueamount > 0)
                                    {
                                        DataTable dt_grid = new DataTable();
                                        dt_grid.Columns.Add("RateofInterest", typeof(string));
                                        dt_grid.Columns.Add("MonthYear", typeof(string));
                                        dt_grid.Columns.Add("MonthName_Year", typeof(string));
                                        dt_grid.Columns.Add("Principalamountdue", typeof(decimal));
                                        dt_grid.Columns.Add("noofinstallment", typeof(int));
                                        dt_grid.Columns.Add("InterestAmount", typeof(decimal));
                                        dt_grid.Columns.Add("UnitHolderContribution", typeof(decimal));
                                        dt_grid.Columns.Add("EligibleRateofInterest", typeof(decimal));
                                        dt_grid.Columns.Add("EligibleInterestAmount", typeof(decimal));

                                        // decimal forPresenthalfyeardueamount = 0;
                                        DateTime dateofmonthstart = new DateTime(Convert.ToInt32(fyStartyear), fystartmonth, 01);
                                        var dat = dateofmonthstart.AddMonths(1).AddDays(-1);


                                        #region forloop

                                        for (int k = 0; k < totalclaimperiod; k++)
                                        {

                                            //condition 1- from Dcp date to claim period start date up to 5 years only claim inserest amount is given  
                                            DataRow drs = dt_grid.NewRow();
                                            dat.AddMonths(k).ToString("d");
                                            string MonthYear = dat.AddMonths(k).Month + "/" + dat.AddMonths(k).Year;
                                            string MonthName = dat.AddMonths(k).ToString("MMMM") + "-" + dat.AddMonths(k).Year;
                                            //string MonthYear = 0+k + "/" + d1.Year;
                                            //string MonthName = 0 + k + "-" + d1.Year;
                                            int gridmonth = dat.AddMonths(k).Month;
                                            int gridyear = dat.AddMonths(k).Year;

                                            decimal Principalamountdue = 0; int noofinstallment = 0; decimal interestamount = 0;
                                            decimal UnitHolderContribution = 0; decimal EligibleRateofInterestofgrd = 0; decimal EligibleInterestAmount = 0;
                                            decimal rateofinterestofdt = 0;

                                            if (k == 0)
                                            {
                                                rateofinterestofdt = rateofinterestMonthone;
                                            }
                                            if (k == 1)
                                            {
                                                rateofinterestofdt = rateofinterestMonthtwo;
                                            }
                                            if (k == 2)
                                            {
                                                rateofinterestofdt = rateofinterestMonththree;
                                            }
                                            if (k == 3)
                                            {
                                                rateofinterestofdt = rateofinterestMonthfour;
                                            }
                                            if (k == 4)
                                            {
                                                rateofinterestofdt = rateofinterestMonthfive;
                                            }
                                            if (k == 5)
                                            {
                                                rateofinterestofdt = rateofinterestMonthsix;
                                            }


                                            if (gridyear >= installmentstartdate.Year)
                                            {

                                                if (motrageforclaim == true)
                                                {
                                                    if (chk_grdclaimegliblerowstodisable.Items[k].Selected == false)// getting selected value from CheckBox List  
                                                    {
                                                        unselectednumber = unselectednumber + 1;
                                                        if (periodofinstallment == 1)
                                                        {
                                                            //Yearly
                                                            int monthofmot = ((noofinstallmentcompleted * 12) + (noofinstallmentcompletedMonths + unselectednumber));
                                                            if ((monthofmot % 12) == 0)
                                                            {
                                                                noofinstallment = (monthofmot / 12);
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                            }
                                                            else if ((monthofmot % 12) == 1)
                                                            {
                                                                noofinstallment = (monthofmot / 12) + 1;
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                            }
                                                            else
                                                            {
                                                                noofinstallment = (monthofmot / 12) + 1;
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                            }
                                                        }
                                                        else if (periodofinstallment == 2)
                                                        {
                                                            //halfyear
                                                            int monthofmot = ((noofinstallmentcompleted * 6) + (noofinstallmentcompletedMonths + unselectednumber));
                                                            if ((monthofmot % 6) == 0)
                                                            {
                                                                noofinstallment = (monthofmot / 6);
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                            }
                                                            else if ((monthofmot % 6) == 1)
                                                            {
                                                                noofinstallment = (monthofmot / 6) + 1;
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                            }
                                                            else
                                                            {
                                                                noofinstallment = (monthofmot / 6) + 1;
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                            }
                                                        }
                                                        else if (periodofinstallment == 3)
                                                        {
                                                            //quaertly

                                                            int monthofmot = ((noofinstallmentcompleted * 3) + (noofinstallmentcompletedMonths + unselectednumber));
                                                            if ((monthofmot % 3) == 0)
                                                            {
                                                                noofinstallment = (monthofmot / 3);
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                            }
                                                            else if ((monthofmot % 3) == 1)
                                                            {
                                                                noofinstallment = (monthofmot / 3) + 1;
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                            }
                                                            else
                                                            {
                                                                noofinstallment = (monthofmot / 3) + 1;
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                            }
                                                        }
                                                        else if (periodofinstallment == 4)
                                                        {
                                                            noofinstallment = noofinstallmentcompleted + unselectednumber;
                                                            Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                        }
                                                    }
                                                    else
                                                    {
                                                        noofinstallment = 0;
                                                        Principalamountdue = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    if (previousmotrage == true)
                                                    {
                                                        if (periodofinstallment == 1)
                                                        {
                                                            //Yearly
                                                            int monthofmot = ((noofinstallmentcompleted * 12) + (noofinstallmentcompletedMonths + k + 1));

                                                            if ((monthofmot % 12) == 1)
                                                            {
                                                                noofinstallment = (monthofmot / 12);
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                            }
                                                            else
                                                            {
                                                                noofinstallment = (monthofmot / 12) + 1;
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                            }
                                                        }
                                                        else if (periodofinstallment == 2)
                                                        {
                                                            //halfyear
                                                            int monthofmot = ((noofinstallmentcompleted * 6) + (noofinstallmentcompletedMonths + k + 1));
                                                            if ((monthofmot % 6) == 1)
                                                            {
                                                                noofinstallment = (monthofmot / 6);
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                            }
                                                            else
                                                            {
                                                                noofinstallment = (monthofmot / 6) + 1;
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                            }
                                                        }
                                                        else if (periodofinstallment == 3)
                                                        {
                                                            //quaertly

                                                            int monthofmot = ((noofinstallmentcompleted * 3) + (noofinstallmentcompletedMonths + k + 1));
                                                            if ((monthofmot % 3) == 1)
                                                            {
                                                                noofinstallment = (monthofmot / 3);
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                            }
                                                            else
                                                            {
                                                                noofinstallment = (monthofmot / 3) + 1;
                                                                Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                            }
                                                        }
                                                        else if (periodofinstallment == 4)
                                                        {
                                                            noofinstallment = noofinstallmentcompleted + k + 1;
                                                            Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                        }

                                                    }
                                                    else
                                                    {


                                                        //installment start date  before/in this claim period
                                                        int gridtotaltwoyearscal = 0;
                                                        int gridtotalmonthcal = 0;
                                                        int gridtotalmonthbwyears = 0;
                                                        // int gridtotalmonthbwyears = ((gridyear - installmentstartdate.Year) * 12) + (gridmonth - installmentstartdate.Month);
                                                        if (gridyear == installmentstartdate.Year)
                                                        {
                                                            gridtotaltwoyearscal = 0;
                                                            if (gridmonth > installmentstartdate.Month)
                                                            {
                                                                //installmentstartdate start before financial year
                                                                gridtotalmonthcal = (gridmonth - installmentstartdate.Month);
                                                            }
                                                            else
                                                            {
                                                                gridtotalmonthcal = 0;
                                                                Principalamountdue = Actualcaltermprincipaldueamount;//added by madhuri
                                                                                                                     //installmentstartdate didn't start for that finanical year
                                                                                                                     //gridtotalmonthcal = 0;
                                                            }
                                                            gridtotalmonthbwyears = gridtotaltwoyearscal + gridtotalmonthcal;
                                                        }
                                                        else if (installmentstartdate.Year < gridyear)
                                                        {
                                                            gridtotaltwoyearscal = ((gridyear - installmentstartdate.Year) * 12);
                                                            gridtotalmonthcal = (gridmonth - installmentstartdate.Month);
                                                            gridtotalmonthbwyears = gridtotaltwoyearscal + gridtotalmonthcal;
                                                        }
                                                        else if (installmentstartdate.Year > gridyear)
                                                        {
                                                            //in that year installmentstartdate didn't started
                                                            gridtotaltwoyearscal = 0;
                                                            gridtotalmonthcal = 0;
                                                            gridtotalmonthbwyears = gridtotaltwoyearscal + gridtotalmonthcal;
                                                        }


                                                        //int gridtotalmonthbwyears = ((gridyear - dcpdate.Year) * 12) + (gridmonth - dcpdate.Month);
                                                        int gridquotientCompleted = 0;
                                                        int gridremainder = 0;
                                                        if (Convert.ToInt16(periodofinstallment) == 1)
                                                        {
                                                            //Yearly

                                                            gridquotientCompleted = gridtotalmonthbwyears / 12;
                                                            gridremainder = gridtotalmonthbwyears % 12;
                                                            if (gridquotientCompleted + 1 <= Totalinstallment)
                                                            {
                                                                if (gridquotientCompleted <= 0)
                                                                {
                                                                    if (gridremainder <= 0)
                                                                    {
                                                                        if (gridyear == installmentstartdate.Year)
                                                                        {
                                                                            if (gridmonth == installmentstartdate.Month)
                                                                            {
                                                                                noofinstallment = gridquotientCompleted + 1;
                                                                                Principalamountdue = Totalamount;
                                                                            }
                                                                            else
                                                                            {
                                                                                noofinstallment = gridquotientCompleted;
                                                                                Principalamountdue = 0;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            noofinstallment = gridquotientCompleted;
                                                                            Principalamountdue = 0;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        noofinstallment = gridquotientCompleted + 1;
                                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    noofinstallment = gridquotientCompleted + 1;
                                                                    if (gridremainder == 0)
                                                                    {
                                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                    }
                                                                    else
                                                                    {
                                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                    }
                                                                }

                                                            }
                                                        }
                                                        else if (Convert.ToInt16(periodofinstallment) == 2)
                                                        {
                                                            //Half yearly
                                                            gridquotientCompleted = gridtotalmonthbwyears / 6;
                                                            gridremainder = gridtotalmonthbwyears % 6;

                                                            if (gridquotientCompleted + 1 <= Totalinstallment)
                                                            {
                                                                if (gridquotientCompleted <= 0)
                                                                {
                                                                    if (gridremainder <= 0)
                                                                    {
                                                                        if (gridyear == installmentstartdate.Year)
                                                                        {
                                                                            if (gridmonth == installmentstartdate.Month)
                                                                            {
                                                                                noofinstallment = gridquotientCompleted + 1;
                                                                                Principalamountdue = Totalamount;
                                                                            }
                                                                            else
                                                                            {
                                                                                noofinstallment = gridquotientCompleted;
                                                                                Principalamountdue = 0;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            noofinstallment = gridquotientCompleted;
                                                                            Principalamountdue = 0;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        noofinstallment = gridquotientCompleted + 1;
                                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    noofinstallment = gridquotientCompleted + 1;
                                                                    if (gridremainder == 0)
                                                                    {
                                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                    }
                                                                    else
                                                                    {
                                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                    }
                                                                }

                                                            }
                                                        }
                                                        else if (Convert.ToInt16(periodofinstallment) == 3)
                                                        {
                                                            // Quarelty
                                                            gridquotientCompleted = gridtotalmonthbwyears / 3;
                                                            gridremainder = gridtotalmonthbwyears % 3;
                                                            if (gridquotientCompleted + 1 <= Totalinstallment)
                                                            {
                                                                if (gridquotientCompleted <= 0)
                                                                {
                                                                    if (gridremainder <= 0)
                                                                    {
                                                                        if (gridyear == installmentstartdate.Year)
                                                                        {
                                                                            if (gridmonth == installmentstartdate.Month)
                                                                            {
                                                                                noofinstallment = gridquotientCompleted + 1;
                                                                                Principalamountdue = Totalamount;
                                                                            }
                                                                            else
                                                                            {
                                                                                noofinstallment = gridquotientCompleted;
                                                                                //Principalamountdue = 0;
                                                                                Principalamountdue = Actualcaltermprincipaldueamount;//added by madhuri
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            noofinstallment = gridquotientCompleted;
                                                                            Principalamountdue = 0;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        noofinstallment = gridquotientCompleted + 1;
                                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment));
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    noofinstallment = gridquotientCompleted + 1;
                                                                    if (gridremainder == 0)
                                                                    {
                                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                    }
                                                                    else
                                                                    {
                                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                    }
                                                                }


                                                            }
                                                        }
                                                        else if (Convert.ToInt16(periodofinstallment) == 4)
                                                        {
                                                            //Monthly
                                                            if (gridquotientCompleted + 1 <= Totalinstallment)
                                                            {
                                                                if (gridyear == installmentstartdate.Year)
                                                                {
                                                                    if (gridtotalmonthbwyears == 0)
                                                                    {
                                                                        if (gridmonth == installmentstartdate.Month)
                                                                        {
                                                                            gridquotientCompleted = gridtotalmonthbwyears + 1;
                                                                            noofinstallment = (gridquotientCompleted);
                                                                            Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                        }
                                                                        else
                                                                        {
                                                                            gridquotientCompleted = 0;
                                                                            noofinstallment = (gridquotientCompleted);
                                                                            Principalamountdue = 0;
                                                                        }

                                                                    }
                                                                    else
                                                                    {
                                                                        gridquotientCompleted = gridtotalmonthbwyears + 1;
                                                                        noofinstallment = (gridquotientCompleted);
                                                                        Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    gridquotientCompleted = gridtotalmonthbwyears + 1;
                                                                    noofinstallment = (gridquotientCompleted);
                                                                    Principalamountdue = Totalamount - (installmentamount * (noofinstallment - 1));
                                                                }

                                                            }
                                                        }
                                                    }
                                                }




                                                #region interest amount check dcp date,5 years from current date

                                                //DateTime fiveyearsdate = dcpdate.AddYears(5);
                                                if (dat.AddMonths(k).Date <= fiveyearsdate.Date)
                                                {
                                                    //installment date is less than 5 year date
                                                    //then interest amount to be calculated  
                                                    if ((dat.AddMonths(k).Year == fiveyearsdate.Year) && (dat.AddMonths(k).Month == fiveyearsdate.Month))
                                                    {
                                                        //Above 5 years the interest amount is zero,
                                                        //if same year & Same month then calcfor that many days;
                                                        int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                        int daystopaid = (daysinamonth - fiveyearsdate.Day) + 1;
                                                        decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                        interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                    }
                                                    else
                                                    {
                                                        if (dat.AddMonths(k).Date > dcpdate.Date)
                                                        {
                                                            if (dat.AddMonths(k).Year > dcpdate.Year)
                                                            {
                                                                //installment started and dcp date started;
                                                                // interestamount = (Principalamountdue * rateofinterestofdt) / 1200;
                                                                if (noofinstallment > 0)
                                                                {
                                                                    interestamount = (Principalamountdue * rateofinterestofdt) / 1200;
                                                                }
                                                                else
                                                                {
                                                                    //installment not started,interest is given on term loan amount
                                                                    interestamount = (Totalamount * rateofinterestofdt) / 1200;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (dat.AddMonths(k).Year == dcpdate.Year)
                                                                {
                                                                    //if same year & Same month then calcfor that many days;
                                                                    if ((dat.AddMonths(k).Year == dcpdate.Year) && (dat.AddMonths(k).Month == dcpdate.Month))
                                                                    {
                                                                        if (noofinstallment > 0)
                                                                        {
                                                                            int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                                            int daystopaid = (daysinamonth - dcpdate.Day) + 1;
                                                                            decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                                            interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                                        }
                                                                        else
                                                                        {
                                                                            int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                                            int daystopaid = (daysinamonth - dcpdate.Day) + 1;
                                                                            decimal pramountpaidfordays = (Totalamount / daysinamonth) * daystopaid;
                                                                            interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                                        }

                                                                    }
                                                                    else
                                                                    {
                                                                        if (dat.AddMonths(k).Month > dcpdate.Month)
                                                                        {
                                                                            if (noofinstallment > 0)
                                                                            {
                                                                                interestamount = (Principalamountdue * rateofinterestofdt) / 1200;
                                                                            }
                                                                            else
                                                                            {
                                                                                //installment not started,interest is given on term loan amount
                                                                                interestamount = (Totalamount * rateofinterestofdt) / 1200;
                                                                            }
                                                                        }
                                                                    }
                                                                }

                                                            }
                                                        }
                                                        else
                                                        {
                                                            //installment date started,before the dcp date,then
                                                            //if same year & Same month then calcfor that many days;
                                                            if ((dat.AddMonths(k).Year == dcpdate.Year) && (dat.AddMonths(k).Month == dcpdate.Month))
                                                            {
                                                                if (noofinstallment > 0)
                                                                {

                                                                    int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                                    int daystopaid = (daysinamonth - dcpdate.Day) + 1;
                                                                    decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                                    interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                                }
                                                                else
                                                                {
                                                                    int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                                    int daystopaid = (daysinamonth - dcpdate.Day) + 1;
                                                                    decimal pramountpaidfordays = (Totalamount / daysinamonth) * daystopaid;
                                                                    interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                                }
                                                            }
                                                        }



                                                    }
                                                }
                                                else
                                                {
                                                    //Above 5 years the interest amount is zero,
                                                    //if same year & Same month then calcfor that many days;
                                                    if ((dat.AddMonths(k).Year == fiveyearsdate.Year) && (dat.AddMonths(k).Month == fiveyearsdate.Month))
                                                    {
                                                        int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                        int daystopaid = (daysinamonth - fiveyearsdate.Day) + 1;
                                                        decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                        interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                    }
                                                }

                                                #endregion

                                                //   interestamount = (Principalamountdue * rateofinterestofdt) / 1200;

                                            }
                                            else
                                            {
                                                //Finincal year started,installment date not started check with dcp date
                                                #region interest amount check dcp date,5 years from current date


                                                if (dat.AddMonths(k).Date <= fiveyearsdate.Date)
                                                {
                                                    //installment date is less than 5 year date
                                                    //then interest amount to be calculated  
                                                    if ((dat.AddMonths(k).Year == fiveyearsdate.Year) && (dat.AddMonths(k).Month == fiveyearsdate.Month))
                                                    {
                                                        //Above 5 years the interest amount is zero,
                                                        //if same year & Same month then calcfor that many days;
                                                        int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                        int daystopaid = (daysinamonth - fiveyearsdate.Day) + 1;
                                                        decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                        interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                    }
                                                    else
                                                    {
                                                        if (dat.AddMonths(k).Date > dcpdate.Date)
                                                        {
                                                            if (dat.AddMonths(k).Year > dcpdate.Year)
                                                            {
                                                                //installment started and dcp date started;
                                                                //interestamount = (Principalamountdue * rateofinterestofdt) / 1200;
                                                                if (noofinstallment > 0)
                                                                {
                                                                    interestamount = (Principalamountdue * rateofinterestofdt) / 1200;
                                                                }
                                                                else
                                                                {
                                                                    //installment not started,interest is given on term loan amount
                                                                    interestamount = (Totalamount * rateofinterestofdt) / 1200;
                                                                    Principalamountdue = Actualcaltermprincipaldueamount;//added by madhuri
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (dat.AddMonths(k).Year == dcpdate.Year)
                                                                {
                                                                    //if same year & Same month then calcfor that many days;
                                                                    if ((dat.AddMonths(k).Year == dcpdate.Year) && (dat.AddMonths(k).Month == dcpdate.Month))
                                                                    {
                                                                        if (noofinstallment > 0)
                                                                        {

                                                                            int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                                            int daystopaid = (daysinamonth - dcpdate.Day) + 1;
                                                                            decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                                            interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                                        }
                                                                        else
                                                                        {
                                                                            int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                                            int daystopaid = (daysinamonth - dcpdate.Day) + 1;
                                                                            decimal pramountpaidfordays = (Totalamount / daysinamonth) * daystopaid;
                                                                            interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                                            Principalamountdue = Actualcaltermprincipaldueamount;//added by madhuri
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (dat.AddMonths(k).Month > dcpdate.Month)
                                                                        {
                                                                            //installment not started,interest is given on term loan amount
                                                                            // interestamount = (Totalamount * rateofinterestofdt) / 1200;
                                                                            if (noofinstallment > 0)
                                                                            {
                                                                                interestamount = (Principalamountdue * rateofinterestofdt) / 1200;
                                                                            }
                                                                            else
                                                                            {
                                                                                //installment not started,interest is given on term loan amount
                                                                                interestamount = (Totalamount * rateofinterestofdt) / 1200;
                                                                                Principalamountdue = Actualcaltermprincipaldueamount;//added by madhuri
                                                                            }
                                                                        }
                                                                    }
                                                                }

                                                            }
                                                        }
                                                        else
                                                        {
                                                            //installment date started,before the dcp date,then
                                                            //if same year & Same month then calcfor that many days;
                                                            if ((dat.AddMonths(k).Year == dcpdate.Year) && (dat.AddMonths(k).Month == dcpdate.Month))
                                                            {
                                                                if (noofinstallment > 0)
                                                                {
                                                                    int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                                    int daystopaid = (daysinamonth - dcpdate.Day) + 1;
                                                                    decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                                    interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                                }
                                                                else
                                                                {
                                                                    int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                                    int daystopaid = (daysinamonth - dcpdate.Day) + 1;
                                                                    decimal pramountpaidfordays = (Totalamount / daysinamonth) * daystopaid;
                                                                    interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                                }
                                                            }
                                                        }



                                                    }
                                                }
                                                else
                                                {
                                                    //Above 5 years the interest amount is zero,
                                                    //if same year & Same month then calcfor that many days;
                                                    if ((dat.AddMonths(k).Year == fiveyearsdate.Year) && (dat.AddMonths(k).Month == fiveyearsdate.Month))
                                                    {
                                                        int daysinamonth = DateTime.DaysInMonth(dat.AddMonths(k).Year, dat.AddMonths(k).Month);
                                                        int daystopaid = (daysinamonth - fiveyearsdate.Day) + 1;
                                                        decimal pramountpaidfordays = (Principalamountdue / daysinamonth) * daystopaid;
                                                        interestamount = (pramountpaidfordays * rateofinterestofdt) / 1200;
                                                        Principalamountdue = Actualcaltermprincipaldueamount;//added by madhuri
                                                    }
                                                }

                                                #endregion
                                            }


                                            #region calculate unit holder

                                            if (interestamount > 0)
                                            {

                                                EligibleRateofInterestofgrd = rateofinterestofdt - 3;
                                                if (EligibleRateofInterestofgrd >= 9)
                                                {
                                                    EligibleRateofInterestofgrd = 9;
                                                }
                                                if (EligibleRateofInterestofgrd < 0)
                                                {
                                                    EligibleRateofInterestofgrd = 0;
                                                }
                                                UnitHolderContribution = rateofinterestofdt - EligibleRateofInterestofgrd;
                                                EligibleInterestAmount = (interestamount * EligibleRateofInterestofgrd) / rateofinterestofdt;


                                                if (gridyear == dcpdate.Year && gridmonth == dcpdate.Month)
                                                {
                                                    int daysinamonthofgrid = DateTime.DaysInMonth(gridyear, gridmonth);
                                                    double daysforcal = 1 - (Convert.ToDouble(dcpdate.Day) / Convert.ToDouble(daysinamonthofgrid));
                                                    Toteglibleperiodinmonths = Toteglibleperiodinmonths + Convert.ToDecimal(daysforcal);
                                                }
                                                else
                                                {
                                                    DateTime startDateofeachmonthgrd = new DateTime(gridyear, gridmonth, 1);
                                                    if (dcpdate.Date < startDateofeachmonthgrd.Date)
                                                    {
                                                        if (fiveyearsdate.Year == gridyear && gridmonth == fiveyearsdate.Month)
                                                        {
                                                            int daysinamonthofgrid = DateTime.DaysInMonth(gridyear, gridmonth);
                                                            //double daysforcal = 1 - (Convert.ToDouble(fiveyearsdate.Day) / Convert.ToDouble(daysinamonthofgrid));
                                                            //Toteglibleperiodinmonths = Toteglibleperiodinmonths + Convert.ToDecimal(daysforcal);
                                                            if (fiveyearsdate.Day == daysinamonthofgrid)
                                                            {
                                                                Toteglibleperiodinmonths = Toteglibleperiodinmonths + 1;
                                                            }
                                                            else
                                                            {
                                                                double daysforcal = 1 - (Convert.ToDouble(fiveyearsdate.Day) / Convert.ToDouble(daysinamonthofgrid));
                                                                Toteglibleperiodinmonths = Toteglibleperiodinmonths + Convert.ToDecimal(daysforcal);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Toteglibleperiodinmonths = Toteglibleperiodinmonths + 1;
                                                        }

                                                    }
                                                    else
                                                    {

                                                    }


                                                }
                                            }

                                            #endregion

                                            totalinterestforallfy = totalinterestforallfy + interestamount;
                                            totaleglibleinterestforallfy = totaleglibleinterestforallfy + EligibleInterestAmount;



                                            drs["MonthYear"] = MonthYear;
                                            drs["MonthName_Year"] = MonthName;
                                            drs["Principalamountdue"] = Convert.ToString(Math.Round(Principalamountdue, 2));
                                            drs["noofinstallment"] = noofinstallment;
                                            drs["InterestAmount"] = Convert.ToString(Math.Round(interestamount, 2));
                                            drs["RateofInterest"] = rateofinterestofdt;
                                            drs["EligibleRateofInterest"] = EligibleRateofInterestofgrd;
                                            drs["UnitHolderContribution"] = UnitHolderContribution;
                                            drs["EligibleInterestAmount"] = Convert.ToString(Math.Round(EligibleInterestAmount));
                                            dt_grid.Rows.Add(drs);
                                        }


                                        #endregion






                                        DataSet dsmain = new DataSet();
                                        dsmain.Tables.Add(dt_grid);

                                        if (dt_grid.Rows.Count > 0)
                                        {
                                            for (int t = 0; t < dt_grid.Rows.Count; t++)
                                            {
                                                if (t == 0)
                                                {
                                                    hfgrd_monthoneid.Value = Convert.ToString(dt_grid.Rows[0]["MonthYear"]);
                                                    lbl_grd_monthonename.Text = Convert.ToString(dt_grid.Rows[0]["MonthName_Year"]);
                                                    lbl_grd_monthnonePrincipalamounntdue.Text = Convert.ToString(dt_grid.Rows[0]["Principalamountdue"]);
                                                    lbl_grd_monthoneNoofInstallment.Text = Convert.ToString(dt_grid.Rows[0]["noofinstallment"]);
                                                    lbl_grd_monthoneRateofinterest.Text = Convert.ToString(dt_grid.Rows[0]["RateofInterest"]);
                                                    lbl_grd_monthoneInterestamount.Text = Convert.ToString(dt_grid.Rows[0]["InterestAmount"]);
                                                    lbl_grd_monthoneUnitHolderContribution.Text = Convert.ToString(dt_grid.Rows[0]["UnitHolderContribution"]);
                                                    lbl_grd_monthoneEligibleRateofinterest.Text = Convert.ToString(dt_grid.Rows[0]["EligibleRateofInterest"]);
                                                    lbl_grd_monthoneEligibleInterestAmount.Text = Convert.ToString(dt_grid.Rows[0]["EligibleInterestAmount"]);
                                                }
                                                if (t == 1)
                                                {
                                                    hfgrd_monthtwoid.Value = Convert.ToString(dt_grid.Rows[1]["MonthYear"]);
                                                    lbl_grd_monthtwoname.Text = Convert.ToString(dt_grid.Rows[1]["MonthName_Year"]);
                                                    lbl_grd_monthtwoPrincipalamounntdue.Text = Convert.ToString(dt_grid.Rows[1]["Principalamountdue"]);
                                                    lbl_grd_monthtwoNoofInstallment.Text = Convert.ToString(dt_grid.Rows[1]["noofinstallment"]);
                                                    lbl_grd_monthtwoRateofinterest.Text = Convert.ToString(dt_grid.Rows[1]["RateofInterest"]);
                                                    lbl_grd_monthtwoInterestamount.Text = Convert.ToString(dt_grid.Rows[1]["InterestAmount"]);
                                                    lbl_grd_monthtwoUnitHolderContribution.Text = Convert.ToString(dt_grid.Rows[1]["UnitHolderContribution"]);
                                                    lbl_grd_monthtwoEligibleRateofinterest.Text = Convert.ToString(dt_grid.Rows[1]["EligibleRateofInterest"]);
                                                    lbl_grd_monthtwoEligibleInterestAmount.Text = Convert.ToString(dt_grid.Rows[1]["EligibleInterestAmount"]);
                                                }
                                                if (t == 2)
                                                {
                                                    hfgrd_monththreeid.Value = Convert.ToString(dt_grid.Rows[2]["MonthYear"]);
                                                    lbl_grd_monththreename.Text = Convert.ToString(dt_grid.Rows[2]["MonthName_Year"]);
                                                    lbl_grd_monththreePrincipalamounntdue.Text = Convert.ToString(dt_grid.Rows[2]["Principalamountdue"]);
                                                    lbl_grd_monththreeNoofInstallment.Text = Convert.ToString(dt_grid.Rows[2]["noofinstallment"]);
                                                    lbl_grd_monththreeRateofinterest.Text = Convert.ToString(dt_grid.Rows[2]["RateofInterest"]);
                                                    lbl_grd_monththreeInterestamount.Text = Convert.ToString(dt_grid.Rows[2]["InterestAmount"]);
                                                    lbl_grd_monththreeUnitHolderContribution.Text = Convert.ToString(dt_grid.Rows[2]["UnitHolderContribution"]);
                                                    lbl_grd_monththreeEligibleRateofinterest.Text = Convert.ToString(dt_grid.Rows[2]["EligibleRateofInterest"]);
                                                    lbl_grd_monththreeEligibleInterestAmount.Text = Convert.ToString(dt_grid.Rows[2]["EligibleInterestAmount"]);
                                                }
                                                if (t == 3)
                                                {
                                                    hfgrd_monthfourid.Value = Convert.ToString(dt_grid.Rows[3]["MonthYear"]);
                                                    lbl_grd_monthfourname.Text = Convert.ToString(dt_grid.Rows[3]["MonthName_Year"]);
                                                    lbl_grd_monthfourPrincipalamounntdue.Text = Convert.ToString(dt_grid.Rows[3]["Principalamountdue"]);
                                                    lbl_grd_monthfourNoofInstallment.Text = Convert.ToString(dt_grid.Rows[3]["noofinstallment"]);
                                                    lbl_grd_monthfourRateofinterest.Text = Convert.ToString(dt_grid.Rows[3]["RateofInterest"]);
                                                    lbl_grd_monthfourInterestamount.Text = Convert.ToString(dt_grid.Rows[3]["InterestAmount"]);
                                                    lbl_grd_monthfourUnitHolderContribution.Text = Convert.ToString(dt_grid.Rows[3]["UnitHolderContribution"]);
                                                    lbl_grd_monthfourEligibleRateofinterest.Text = Convert.ToString(dt_grid.Rows[3]["EligibleRateofInterest"]);
                                                    lbl_grd_monthfourEligibleInterestAmount.Text = Convert.ToString(dt_grid.Rows[3]["EligibleInterestAmount"]);
                                                }
                                                if (t == 4)
                                                {
                                                    hfgrd_monthfiveid.Value = Convert.ToString(dt_grid.Rows[4]["MonthYear"]);
                                                    lbl_grd_monthfivename.Text = Convert.ToString(dt_grid.Rows[4]["MonthName_Year"]);
                                                    lbl_grd_monthfivePrincipalamounntdue.Text = Convert.ToString(dt_grid.Rows[4]["Principalamountdue"]);
                                                    lbl_grd_monthfiveNoofInstallment.Text = Convert.ToString(dt_grid.Rows[4]["noofinstallment"]);
                                                    lbl_grd_monthfiveRateofinterest.Text = Convert.ToString(dt_grid.Rows[4]["RateofInterest"]);
                                                    lbl_grd_monthfiveInterestamount.Text = Convert.ToString(dt_grid.Rows[4]["InterestAmount"]);
                                                    lbl_grd_monthfiveUnitHolderContribution.Text = Convert.ToString(dt_grid.Rows[4]["UnitHolderContribution"]);
                                                    lbl_grd_monthfiveEligibleRateofinterest.Text = Convert.ToString(dt_grid.Rows[4]["EligibleRateofInterest"]);
                                                    lbl_grd_monthfiveEligibleInterestAmount.Text = Convert.ToString(dt_grid.Rows[4]["EligibleInterestAmount"]);
                                                }
                                                if (t == 5)
                                                {
                                                    hfgrd_monthsixid.Value = Convert.ToString(dt_grid.Rows[5]["MonthYear"]);
                                                    lbl_grd_monthsixname.Text = Convert.ToString(dt_grid.Rows[5]["MonthName_Year"]);
                                                    lbl_grd_monthsixPrincipalamounntdue.Text = Convert.ToString(dt_grid.Rows[5]["Principalamountdue"]);
                                                    lbl_grd_monthsixNoofInstallment.Text = Convert.ToString(dt_grid.Rows[5]["noofinstallment"]);
                                                    lbl_grd_monthsixRateofinterest.Text = Convert.ToString(dt_grid.Rows[5]["RateofInterest"]);
                                                    lbl_grd_monthsixInterestamount.Text = Convert.ToString(dt_grid.Rows[5]["InterestAmount"]);
                                                    lbl_grd_monthsixUnitHolderContribution.Text = Convert.ToString(dt_grid.Rows[5]["UnitHolderContribution"]);
                                                    lbl_grd_monthsixEligibleRateofinterest.Text = Convert.ToString(dt_grid.Rows[5]["EligibleRateofInterest"]);
                                                    lbl_grd_monthsixEligibleInterestAmount.Text = Convert.ToString(dt_grid.Rows[5]["EligibleInterestAmount"]);
                                                }
                                            }
                                        }


                                    }
                                    else
                                    {
                                        ErrorMsg = ErrorMsg + slno + ". Due amount of next half year should be above zero \\n";
                                        slno = slno + 1;
                                    }
                                }
                                else
                                {
                                    ErrorMsg = ErrorMsg + slno + ". Please Enter Installment Completed Months b/W 0 to 11/0 to 5/0 to 2 \\n";
                                    slno = slno + 1;
                                }
                            }
                            else
                            {
                                ErrorMsg = ErrorMsg + slno + ". completed total installment should be less than total installment   \\n";
                                slno = slno + 1;
                            }


                            #endregion

                        }
                        else
                        {
                            ErrorMsg = ErrorMsg + slno + ". select no of rows for disable for moratorium\\n";
                            slno = slno + 1;
                        }


                    }
                    else
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter DCP date/Installment start/Total Amount/Period of installment/No of installments/Installment Amount\\n";
                        slno = slno + 1;
                    }

                    //}
                    //else
                    //{
                    //    ErrorMsg = ErrorMsg + slno + ". Please Enter DCP date/Installment start date Should be less than current date \\n";
                    //    slno = slno + 1;
                    //}
                }
            }













            txt_grdeglibilepallavaddiEligibleperiodinmonths.Text = Convert.ToString(Math.Round(Toteglibleperiodinmonths, 2));
            txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations.Text = Convert.ToString(Math.Round(totalinterestforallfy, 2));

            hf_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Value = Convert.ToString(Actualcalnoofinstallmentcompleted);
            txt_claimeglibleincentivesloanwiseNoofinstallmentscompleted.Text = Convert.ToString(noofinstallmentcompleted);
            hf_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths.Value = Convert.ToString(ActualcalnoofinstallmentcompletedMonths);
            txt_claimeglibleincentivesloanwiseNoofinstallmentscompletedMonths.Text = Convert.ToString(noofinstallmentcompletedMonths);
            hf_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR.Value = Convert.ToString(Math.Round(Actualcaltermprincipaldueamount, 2));
            txt_claimeglibleincentivesloanwisePrincipalamountbecomeDUEbeforethisHALFYEAR.Text = Convert.ToString(Math.Round(termprincipaldueamount, 2));



            lbl_grd_totmonthsInterestamount.Text = Convert.ToString(Math.Round(totalinterestforallfy, 2));
            lbl_grd_totmonthsEligibleInterestAmount.Text = Convert.ToString(Math.Round(totaleglibleinterestforallfy, 2));

            decimal totalgridinterestamount = 0; decimal actualinterestamountpaid = 0; decimal interestamountcondisered = 0;
            decimal rateofinterest = 0; decimal egliblerateofinterest = 0; decimal interestegliblereimbursement = 0;
            decimal eglibleamountofreimbursementbyeglibletype = 0; decimal GMrecommendedamount = 0; decimal finalegibleamountdisscussed = 0;

            if (txt_grdeglibilepallavaddiGMrecommendedamount.Text != "")
            {
                GMrecommendedamount = Convert.ToDecimal(txt_grdeglibilepallavaddiGMrecommendedamount.Text);
            }

            if (txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations.Text != "")
            {
                totalgridinterestamount = Convert.ToDecimal(txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations.Text);
            }

            if (txt_grdeglibilepallavaddiActualinterestamountpaid.Text != "")
            {
                actualinterestamountpaid = Convert.ToDecimal(txt_grdeglibilepallavaddiActualinterestamountpaid.Text);
            }
            if (txt_claimeglibleincentivesloanwiseRateofInterest.Text.TrimStart().TrimEnd().Trim() != "")
            {
                rateofinterest = Convert.ToDecimal(txt_claimeglibleincentivesloanwiseRateofInterest.Text);
                if (rateofinterest == 0)
                {
                    if (lbl_grd_monthsixRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
                    {
                        rateofinterest = Convert.ToDecimal(lbl_grd_monthsixRateofinterest.Text);
                    }
                    else
                    {
                        if (rateofinterest == 0)
                        {
                            if (lbl_grd_monthoneRateofinterest.Text.TrimStart().TrimEnd().Trim() != "")
                            {
                                rateofinterest = Convert.ToDecimal(lbl_grd_monthoneRateofinterest.Text);
                            }
                        }
                    }
                }
            }

            if (totalgridinterestamount > 0)
            {
                if (totalgridinterestamount > 0)
                {
                    if (rateofinterest != 0)
                    {
                        if (rateofinterest > 3)
                        {
                            egliblerateofinterest = rateofinterest - 3;
                            if (egliblerateofinterest > 9)
                            {
                                egliblerateofinterest = 9;
                            }
                            if (egliblerateofinterest > 0)
                            {
                                if (totalgridinterestamount < actualinterestamountpaid)
                                {
                                    interestamountcondisered = totalgridinterestamount;
                                }
                                else
                                {
                                    interestamountcondisered = actualinterestamountpaid;
                                }
                                interestegliblereimbursement = (interestamountcondisered * egliblerateofinterest) / rateofinterest;
                            }
                            else
                            {
                                //Please Enter Eglible Rate of interest
                                ErrorMsg = ErrorMsg + slno + ". Please Enter Eglible rate of remibursement less than zero \\n";
                                slno = slno + 1;
                            }
                        }
                        else
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Enter rate of interest above 3 \\n";
                            slno = slno + 1;
                        }
                    }
                    else
                    {
                        //Please Enter Rate of interest
                        ErrorMsg = ErrorMsg + slno + ". Please Enter rate of interest \\n";
                        slno = slno + 1;
                    }
                }
                else
                {
                    //Please enter Actual interest amount paid
                }
            }
            else
            {
                //then error insert amount can't be zero
            }

            if (interestegliblereimbursement > 0)
            {
                if (rbtgrdeglibilepallavaddi_isbelated.SelectedValue == "0")
                {
                    //More than an Year
                    eglibleamountofreimbursementbyeglibletype = 0;
                    txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(eglibleamountofreimbursementbyeglibletype);

                }
                else if (rbtgrdeglibilepallavaddi_isbelated.SelectedValue == "Y")
                {
                    //Regular
                    eglibleamountofreimbursementbyeglibletype = interestegliblereimbursement;
                    txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(Math.Round(eglibleamountofreimbursementbyeglibletype, 2));
                }
                else if (rbtgrdeglibilepallavaddi_isbelated.SelectedValue == "N")
                {
                    //Belated
                    eglibleamountofreimbursementbyeglibletype = interestegliblereimbursement / 2;
                    txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(Math.Round(eglibleamountofreimbursementbyeglibletype, 2));
                }
                else
                {
                    //Please Select Eglible Type
                }
            }

            if (GMrecommendedamount < eglibleamountofreimbursementbyeglibletype)
            {
                finalegibleamountdisscussed = GMrecommendedamount;
            }

            else
            {
                finalegibleamountdisscussed = eglibleamountofreimbursementbyeglibletype;
            }

            txt_claimeglibleincentivesloanwiseEligiblerateofreimbursement.Text = Convert.ToString(egliblerateofinterest);
            txt_grdeglibilepallavaddiInsertreimbursementcalculated.Text = Convert.ToString(Math.Round(interestegliblereimbursement, 2));
            txt_grdeglibilepallavaddiEligibleamount.Text = Convert.ToString(Math.Round(finalegibleamountdisscussed, 2));
            txt_claimeglibleincentivesloanwiseConsideredAmountforInterest.Text = Convert.ToString(Math.Round(interestamountcondisered, 2));
            interestamountcalacutionsofgrdeligible();
            return ErrorMsg;
        }


        protected void txt_GMrecommendedamount_TextChanged(object sender, EventArgs e)
        {
            interestamountcalacutionsofgrdeligible();
        }

        void interestamountcalacutionsofgrdeligible()
        {
            decimal totalgridinterestamount = 0; decimal actualinterestamountpaid = 0; decimal interestamountcondisered = 0;
            decimal interestegliblereimbursement = 0; decimal eglibleamountofreimbursementbyeglibletype = 0;
            decimal GMrecommendedamount = 0; decimal finalegibleamountdisscussed = 0;

            for (int i = 0; i < grd_eglibilepallavaddi.Rows.Count; i++)
            {
                TextBox txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations = grd_eglibilepallavaddi.Rows[i].FindControl("txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations") as TextBox;
                TextBox txt_grdeglibilepallavaddiActualinterestamountpaid = grd_eglibilepallavaddi.Rows[i].FindControl("txt_grdeglibilepallavaddiActualinterestamountpaid") as TextBox;
                TextBox txt_grdeglibilepallavaddiInsertreimbursementcalculated = grd_eglibilepallavaddi.Rows[i].FindControl("txt_grdeglibilepallavaddiInsertreimbursementcalculated") as TextBox;
                TextBox txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype = grd_eglibilepallavaddi.Rows[i].FindControl("txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype") as TextBox;
                TextBox txt_claimeglibleincentivesloanwiseConsideredAmountforInterest = grd_eglibilepallavaddi.Rows[i].FindControl("txt_claimeglibleincentivesloanwiseConsideredAmountforInterest") as TextBox;

                if (!string.IsNullOrEmpty(txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations.Text))
                {
                    totalgridinterestamount = totalgridinterestamount + Convert.ToDecimal(txt_grdeglibilepallavaddiInsertamounttobepaidaspercalculations.Text);
                }

                if (!string.IsNullOrEmpty(txt_grdeglibilepallavaddiActualinterestamountpaid.Text))
                {
                    actualinterestamountpaid = actualinterestamountpaid + Convert.ToDecimal(txt_grdeglibilepallavaddiActualinterestamountpaid.Text);
                }

                if (!string.IsNullOrEmpty(txt_grdeglibilepallavaddiInsertreimbursementcalculated.Text))
                {
                    interestegliblereimbursement = interestegliblereimbursement + Convert.ToDecimal(txt_grdeglibilepallavaddiInsertreimbursementcalculated.Text);
                }

                if (!string.IsNullOrEmpty(txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype.Text))
                {
                    eglibleamountofreimbursementbyeglibletype = eglibleamountofreimbursementbyeglibletype + Convert.ToDecimal(txt_grdeglibilepallavaddieglibleamountofreimbursementbyeglibletype.Text);
                }

                if (!string.IsNullOrEmpty(txt_claimeglibleincentivesloanwiseConsideredAmountforInterest.Text))
                {
                    interestamountcondisered = interestamountcondisered + Convert.ToDecimal(txt_claimeglibleincentivesloanwiseConsideredAmountforInterest.Text);
                }

            }

            txt_Insertamounttobepaidaspercalculations.Text = Convert.ToString(totalgridinterestamount);
            txt_Actualinterestamountpaid.Text = Convert.ToString(actualinterestamountpaid);
            txt_Insertreimbursementcalculated.Text = Convert.ToString(interestegliblereimbursement);
            txt_eglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(eglibleamountofreimbursementbyeglibletype);
            txt_ConsideredAmountofInterest.Text = Convert.ToString(interestamountcondisered);
            if (txt_GMrecommendedamount.Text != "")
            {
                GMrecommendedamount = Convert.ToDecimal(txt_GMrecommendedamount.Text);
            }
            if (GMrecommendedamount < eglibleamountofreimbursementbyeglibletype)
            {
                finalegibleamountdisscussed = GMrecommendedamount;
            }
            else
            {
                finalegibleamountdisscussed = eglibleamountofreimbursementbyeglibletype;
            }
            txt_Eligibleamount.Text = Convert.ToString(Math.Round(finalegibleamountdisscussed, 2));
        }
    }
}