using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class InterestSubsidy : System.Web.UI.Page
    {
        InterestSubsidyBO objBO = new InterestSubsidyBO();
        General Gen = new General();
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        comFunctions cmf = new comFunctions();
        Fetch objFetch = new Fetch();
        List<TermLoanBO> listTermLoanBO = new List<TermLoanBO>();
        List<TermLoanRepaidBO> listTermLoanRepaidBO = new List<TermLoanRepaidBO>();
        CAFClass caf = new CAFClass();
        DataRetrivalClass ObjDataRetrivalClass = new DataRetrivalClass();
        DataSet ds = new DataSet();

        decimal EligibleInterest1 = 0;
        decimal EligibleInterest2 = 0;
        decimal EligibleInterest3 = 0;
        decimal TotalClaimAmount = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["ObjLoginvo"] != null)
                {
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    if (hdnUserID.Value == "")
                    {
                        hdnUserID.Value = ObjLoginNewvo.uid;
                    }
                    else
                    {
                        PageName pageName = new PageName();
                        string Valid = pageName.ValidateUser(hdnUserID.Value, ObjLoginNewvo.uid);
                        if (Valid == "1")
                        {
                            //Session.RemoveAll();
                            //Session.Clear();
                            //Session.Abandon();
                            //Response.Redirect("~/LoginReg.aspx");
                        }
                    }
                    if (!IsPostBack)
                    {
                        if (Session["uid"] != null)
                        {
                            if (Session["incentivedata"] != null)
                            {
                                string userid = Session["uid"].ToString();
                                string IncentveID = Session["IncentiveID"].ToString();
                                DataSet ds = new DataSet();
                                ds = (DataSet)Session["incentivedata"];
                                DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 3);
                                if (drs.Length > 0)
                                {
                                    DataSet dsnew = new DataSet();
                                    BindFinancialYears(ddlFinYear, "7", Session["IncentiveID"].ToString());
                                    //BindClaimFinancialYears(ddlFinYear, "7", Session["IncentiveID"].ToString(), "3");
                                    BindFinancialYears(lblFinYearRepaid, "7", Session["IncentiveID"].ToString());

                                    cmf.BindCtlto(true, ddlBankAvail, objFetch.FetchBankMst(), 1, 0, false);
                                    cmf.BindCtlto(true, ddlBankrepaid, objFetch.FetchBankMst(), 1, 0, false);
                                    cmf.BindCtlto(true, ddlbankTotalrepaid, objFetch.FetchBankMst(), 1, 0, false);
                                    cmf.BindCtlto(true, ddlMoratoriumBank, objFetch.FetchBankMst(), 1, 0, false);

                                    cmf.BindCtlto(true, ddlBankTL, objFetch.FetchBankMst(), 1, 0, false);
                                    cmf.BindCtlto(true, ddlBankTL2, objFetch.FetchBankMst(), 1, 0, false);
                                    cmf.BindCtlto(true, ddlBankTL3, objFetch.FetchBankMst(), 1, 0, false);

                                    BindTermLoanAvailed(0, Convert.ToInt32(Session["IncentiveID"].ToString()));
                                    BindTermLoanRepaid(0, Convert.ToInt32(Session["IncentiveID"].ToString()));
                                    BindInterestSubsidy(userid, Convert.ToInt32(Session["IncentiveID"].ToString()));
                                    BindISCrrentClaimPeriodDtls(Session["IncentiveID"].ToString());
                                    BindAdditionalInformationDtls(Session["IncentiveID"].ToString());
                                    BindAdditionalInformationDtls2(Session["IncentiveID"].ToString());
                                    BindAdditionalInformationDtls3(Session["IncentiveID"].ToString());
                                    BindTotalTermLoanRepaid(0, Convert.ToInt32(Session["IncentiveID"].ToString()));
                                    BindMoratoriumPeriodDetails(0, Convert.ToInt32(Session["IncentiveID"].ToString()));
                                }
                                else
                                {
                                    if (Request.QueryString[0].ToString() == "N")
                                    {
                                        Response.Redirect("PowerTariffSubsidy.aspx?next=" + "N");
                                    }
                                    else
                                    {
                                        Response.Redirect("CapitalAssistanceCreationEnergy.aspx?Previous=" + "P");
                                    }
                                }
                            }
                            if (hdnUserID.Value == "87298") {
                                divSingleAccount.Visible = true;
                            }
                        }
                    }

                }
                else
                {
                    Response.Redirect("~/LoginReg.aspx");
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                string uid = "0";
                if (Session["uid"] != null)
                {
                    uid = Session["uid"].ToString();
                }

                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, uid);
            }
        }
        private void BindFinancialYears(DropDownList ddl, string Count, string incentiveid)
        {
            DataSet dsYears = new DataSet();
            ddl.Items.Clear();
            dsYears = GetFinancialYearIncentives(Count, incentiveid);
            if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = dsYears.Tables[0];
                ddl.DataTextField = "FinancialYear";
                ddl.DataValueField = "SlNo";
                ddl.DataBind();
            }
            AddSelect(ddl);
        }
        private void BindMonths1(string HalfYear,string Flag,string IncentiveId,string TermLoan)
        {
            DataSet dsMonths = new DataSet();

            dsMonths = GetFinancialYearMonths(HalfYear, Flag, IncentiveId, TermLoan);
            if (dsMonths != null && dsMonths.Tables.Count > 0 && dsMonths.Tables[0].Rows.Count > 0)
            {
                ddlMonthTL1.DataSource = dsMonths.Tables[0];
                ddlMonthTL1.DataTextField = "MonthName";
                ddlMonthTL1.DataValueField = "MonthId";
                ddlMonthTL1.DataBind();
            }
            AddSelect(ddlMonthTL1);
        }
        private void BindMonths2(string HalfYear, string Flag, string IncentiveId, string TermLoan)
        {
            DataSet dsMonths = new DataSet();

            dsMonths = GetFinancialYearMonths(HalfYear, Flag, IncentiveId, TermLoan);
            if (dsMonths != null && dsMonths.Tables.Count > 0 && dsMonths.Tables[0].Rows.Count > 0)
            {
                ddlMonthTL2.DataSource = dsMonths.Tables[0];
                ddlMonthTL2.DataTextField = "MonthName";
                ddlMonthTL2.DataValueField = "MonthId";
                ddlMonthTL2.DataBind();
            }
            AddSelect(ddlMonthTL2);
        }
        private void BindMonths3(string HalfYear, string Flag, string IncentiveId, string TermLoan)
        {
            DataSet dsMonths = new DataSet();

            dsMonths = GetFinancialYearMonths(HalfYear, Flag, IncentiveId, TermLoan);
            if (dsMonths != null && dsMonths.Tables.Count > 0 && dsMonths.Tables[0].Rows.Count > 0)
            {  
                ddlMonthTL3.DataSource = dsMonths.Tables[0];
                ddlMonthTL3.DataTextField = "MonthName";
                ddlMonthTL3.DataValueField = "MonthId";
                ddlMonthTL3.DataBind();
            }
            AddSelect(ddlMonthTL3);
        }
        public void AddSelect(DropDownList ddl)
        {
            try
            {
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }
        }

        public string GetFromatedDateDDMMYYYY(string Date)
        {
            string Dateformat = "";
            string[] Ld6 = null;
            string ConvertedDt56 = "";
            if (Date != "")
            {
                Ld6 = Date.Split('/');
                ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();
                Dateformat = ConvertedDt56;
            }
            else
            {
                Dateformat = null;
            }
            return Dateformat;
        }
        public string GetDecimalNullValue(string Input)
        {
            string InputValue = "";

            InputValue = (Input != "") ? Input : "0";

            return InputValue;
        }
        protected void btnAddBankDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["ISId"] == null)
                {
                    ViewState["ISId"] = "0";
                }

                string errormsg = ValidateTLAControls();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {

                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    TermLoanAvaied tla = new TermLoanAvaied();

                    tla.ISId = Convert.ToInt32(ViewState["ISId"].ToString());
                    tla.IncentiveId = Convert.ToInt32(Session["IncentiveID"].ToString());
                    tla.SubIncentiveId = 3;
                    tla.BankId = Convert.ToInt32(ddlBankAvail.SelectedValue);
                    tla.BankName = ddlBankAvail.SelectedItem.Text;
                    tla.BranchName = txtTLABranch.Text;
                    tla.IFSCode = txtTLAIFSCode.Text;
                    tla.LoanAccNo = txtTLALACNo.Text;
                    tla.SanctionOrderNo = txtTLASONo.Text;
                    tla.SanctionOrderDate = GetFromatedDateDDMMYYYY(txtTLASODate.Text);
                    tla.SanctionedAmount = GetDecimalNullValue(txtTLASAmount.Text);
                    tla.ReleasedDate = GetFromatedDateDDMMYYYY(txtTLAReleasedDate.Text);
                    tla.Created_by = ObjLoginNewvo.uid;
                    tla.TransType = "INS";
                    string Validstatus = caf.InsertTermLoanAvailed(tla);
                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        // string message = "alert('" + "Saved Successfully" + "')";
                        // ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        //  Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Saved/Updated Successfully');", true);
                        //  BindPandMGrid(0, Convert.ToInt32(Session["IncentiveID"].ToString()));
                        clearTLAControls();
                        BindTermLoanAvailed(0, Convert.ToInt32(Session["IncentiveID"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void clearTLAControls()
        {
            ddlBankAvail.SelectedValue = "0";
            txtTLABranch.Text = "";
            txtTLAIFSCode.Text = "";
            txtTLALACNo.Text = "";
            txtTLASONo.Text = "";
            txtTLASODate.Text = "";
            txtTLASAmount.Text = "";
            txtTLAReleasedDate.Text = "";
        }
        public void BindTermLoanAvailed(int ISId, int IncentiveId)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = GetTermLoanAvailed(ISId, IncentiveId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdTermLoanAvailed.DataSource = ds.Tables[0];
                    grdTermLoanAvailed.DataBind();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetTermLoanAvailed(int ISId, int IncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@ISId",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = ISId;
            Dsnew = caf.GenericFillDs("USP_GET_TERMLOANAVAILED", pp);
            return Dsnew;
        }


        public void clearTLRControls()
        {
            ddlBankrepaid.SelectedValue = "0";
            //txtTLRFInYear.Text = "";
            txtPrincipal.Text = "";
            txtRateofInterest.Text = "";
            txtInterest.Text = "";
            txtDOP.Text = "";
            txtAccountNo.Text = "";
            txtOpeningBal.Text = "";
            txtClosingBal.Text = "";
            lblFinYearRepaid.SelectedValue = "0";
            ddlhalfYearRepaid.SelectedValue = "0";
        }
        public void BindTermLoanRepaid(int TLRId, int IncentiveId)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = GetTermLoanRepaid(TLRId, IncentiveId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdTermLoanRepaid.DataSource = ds.Tables[0];
                    grdTermLoanRepaid.DataBind();
                    if (grdTermLoanRepaid.Rows.Count == 1)
                    {
                        string Termloan = ds.Tables[0].Rows[0]["TermLoanNo"].ToString();
                        if (Termloan == "TermLoan1")
                        {
                            DivAdditionalinformation.Visible = true;
                            hdnTermloan1Active.Value = "Y";
                        }
                        if (Termloan == "TermLoan2")
                        {
                            DivTerm2.Visible = true;
                            hdnTermloan2Active.Value = "Y";
                        }
                        if (Termloan == "TermLoan3")
                        {
                            DivTerm3.Visible = true;
                            hdnTermloan3Active.Value = "Y";
                        }
                    }
                    if (grdTermLoanRepaid.Rows.Count == 2)
                    {
                        string Termloan1 = ds.Tables[0].Rows[0]["TermLoanNo"].ToString();
                        if (Termloan1 == "TermLoan1")
                        {
                            DivAdditionalinformation.Visible = true;
                            hdnTermloan1Active.Value = "Y";
                        }
                        if (Termloan1 == "TermLoan2")
                        {
                            DivTerm2.Visible = true;
                            hdnTermloan2Active.Value = "Y";
                        }
                        if (Termloan1 == "TermLoan3")
                        {
                            DivTerm3.Visible = true;
                            hdnTermloan3Active.Value = "Y";
                        }

                        string Termloan2 = ds.Tables[0].Rows[1]["TermLoanNo"].ToString();
                        if (Termloan2 == "TermLoan1")
                        {
                            DivAdditionalinformation.Visible = true;
                            hdnTermloan1Active.Value = "Y";
                        }
                        if (Termloan2 == "TermLoan2")
                        {
                            DivTerm2.Visible = true;
                            hdnTermloan2Active.Value = "Y";
                        }
                        if (Termloan2 == "TermLoan3")
                        {
                            DivTerm3.Visible = true;
                            hdnTermloan3Active.Value = "Y";
                        }

                    }
                    if (grdTermLoanRepaid.Rows.Count == 3)
                    {
                        DivAdditionalinformation.Visible = true;
                        DivTerm2.Visible = true;
                        DivTerm3.Visible = true;

                        hdnTermloan1Active.Value = "Y";
                        hdnTermloan2Active.Value = "Y";
                        hdnTermloan3Active.Value = "Y";
                    }
                }
                else
                {
                    grdTermLoanRepaid.DataSource = null;
                    grdTermLoanRepaid.DataBind();
                    if (grdTermLoanRepaid.Rows.Count == 0)
                    {   
                        DivAdditionalinformation.Visible = false;
                        DivTerm2.Visible = false;
                        DivTerm3.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetTermLoanRepaid(int TLRId, int IncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@TLRId",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = TLRId;
            Dsnew = caf.GenericFillDs("USP_GET_TERMLOANREPAID", pp);
            return Dsnew;
        }

        protected void btnISNext_Click(object sender, EventArgs e)
        {
            string errormsg = ValidateAllControls();
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            else
            {
                try
                {

                    string errormsgAttach = caf.ValidateMandatoryAttachments(Session["IncentiveID"].ToString(), "3");
                    if (errormsgAttach.Trim().TrimStart() != "")
                    {
                        string message = "alert('" + errormsgAttach + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }

                    InterestSubsidy1 tlr = new InterestSubsidy1();

                    tlr.IncentiveId = Convert.ToInt32(Session["IncentiveID"].ToString());
                    tlr.SubIncentiveId = 3;
                    //tlr.CCP_From = txtCCPFrom.Text;
                    //tlr.CCP_To = txtCCPTo.Text;
                    //tlr.CCP_Type = Convert.ToInt32(ddlCCPType.SelectedValue);

                    tlr.CCA = Convert.ToDecimal(txtCCA.Text);
                    tlr.IsMoratorium = Convert.ToInt32(rbtnMoratoriumYesNo.SelectedValue.ToString());
                    tlr.IsOtherAgency = Convert.ToInt32(rbtnOtherAgency.SelectedValue.ToString());

                    tlr.AmountAvailed = GetDecimalNullValue(txtAmountAvailed.Text.Trim().TrimStart());
                    tlr.SanctionOrderNo = txtSanctionOrderNo.Text.Trim().TrimStart();
                    tlr.DateAvailed = GetFromatedDateDDMMYYYY(txtDateAvailed.Text.Trim().TrimStart());

                    int result = caf.InsertInterestSubsidy(tlr);
                    if (result > 0)
                    {
                        Response.Redirect("PowerTariffSubsidy.aspx?next=" + "N");
                        //Add to Grid Method
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Saved/Updated Successfully');", true);

                        //clearAllControls();
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public void clearAllControls()
        {
            txtCCPFrom.Text = "";
            txtCCPTo.Text = "";
            ddlCCPType.SelectedValue = "0";
            txtCCA.Text = "";
        }
        public void EnableDisableForm(ControlCollection ctrls, bool status)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Enabled = status;

                // if (ctrl is Button)      // commented to enable the Button Controls
                //    ((Button)ctrl).Enabled = status;

                else if (ctrl is DropDownList)
                    ((DropDownList)ctrl).Enabled = status;
                else if (ctrl is CheckBox)
                    ((CheckBox)ctrl).Enabled = status;
                else if (ctrl is RadioButton)
                    ((RadioButton)ctrl).Enabled = status;
                else if (ctrl is RadioButtonList)
                    ((RadioButtonList)ctrl).Enabled = status;
                else if (ctrl is CheckBoxList)
                    ((CheckBoxList)ctrl).Enabled = status;

                EnableDisableForm(ctrl.Controls, status);

            }
        }
        public void BindInterestSubsidy(string uid, int IncentiveID)
        {
            DataSet ds = new DataSet();
            DataSet dsnew = new DataSet();
            dsnew = GetapplicationDtls(uid, IncentiveID);
            if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
            {
                lblTSIPassUIDNumber.InnerText = dsnew.Tables[0].Rows[0]["Uid_NO"].ToString();
                lblCommonApplicationNumber.InnerText = dsnew.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                lblTypeofApplicant.InnerText = dsnew.Tables[0].Rows[0]["TypeOfIndustryText"].ToString();
                //lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCP"].ToString();

                BindTearmLoanDtls(IncentiveID.ToString());
                BindTearmLoanDtlsDDL(IncentiveID.ToString(),"I");


                string TypeOfIndustry = dsnew.Tables[0].Rows[0]["TypeOfIndustry"].ToString();
                if (TypeOfIndustry == "1")
                {
                    lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCP"].ToString();
                    trFixedCapitalexpansion.Visible = false;
                    trFixedCapitalland.Visible = false;
                    trFixedCapitalBuilding.Visible = false;
                    trFixedCapitalMach.Visible = false;

                    Td3.Visible = false;
                    Td4.Visible = false;

                    trFixedCapitalexpnPercent.Visible = false;
                    txtbuildcapacityPercet.Visible = false;
                    trFixedCapitMachPercent.Visible = false;
                    trFixedCapitBuildPercent.Visible = false;
                }
                else
                {
                    lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCPExp"].ToString();
                    trFixedCapitalexpansion.Visible = true;
                    trFixedCapitalland.Visible = true;
                    trFixedCapitalBuilding.Visible = true;
                    trFixedCapitalMach.Visible = true;

                    Td3.Visible = true;
                    Td4.Visible = true;

                    trFixedCapitalexpnPercent.Visible = true;
                    txtbuildcapacityPercet.Visible = true;
                    trFixedCapitMachPercent.Visible = true;
                    trFixedCapitBuildPercent.Visible = true;
                }

                txtlandexisting.Text = dsnew.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString();
                txtlandcapacity.Text = dsnew.Tables[0].Rows[0]["ExpansionDiversificationLand"].ToString();
                txtlandpercentage.Text = dsnew.Tables[0].Rows[0]["LandFixedCapitalInvestPercentage"].ToString();

                txtbuildingexisting.Text = dsnew.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString();
                txtbuildingcapacity.Text = dsnew.Tables[0].Rows[0]["ExpDiversBuilding"].ToString();
                txtbuildingpercentage.Text = dsnew.Tables[0].Rows[0]["BuildingFixedCapitalInvestPercentage"].ToString();

                txtplantexisting.Text = dsnew.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString();
                txtplantcapacity.Text = dsnew.Tables[0].Rows[0]["ExpDiversPlantMachinery"].ToString();
                txtplantpercentage.Text = dsnew.Tables[0].Rows[0]["PlantMachFixedCapitalInvestPercentage"].ToString();

                CalculatationEnterprise1("1");
                CalculatationEnterprise1("2");
                CalculatationEnterprise1("3");

                string ENABLINGCONTRILS = dsnew.Tables[0].Rows[0]["ENABLINGCONTRILS"].ToString();
                if ((dsnew.Tables[0].Rows[0]["intStatusid"].ToString() == null || dsnew.Tables[0].Rows[0]["intStatusid"].ToString() == ""))// && ENABLINGCONTRILS == "N")
                {
                    EnableDisableForm(Page.Controls, true);
                }
                else
                {
                    string applicationStatus = "";
                    applicationStatus = dsnew.Tables[0].Rows[0]["intStatusid"].ToString();
                    if (applicationStatus == "")
                    {
                        applicationStatus = "0";
                    }
                    if (Convert.ToInt32(applicationStatus) >= 2 || ENABLINGCONTRILS == "Y")  //3  changed on 17.11.2017 
                    {
                        EnableDisableForm(Page.Controls, false);
                        DivTermLoanavailedwithAmountDetails.Visible = false;
                        DivTermloanrepaidDetails.Visible = false;
                        //grdTermLoanAvailed.Columns[10].Visible = false;
                        //grdTermLoanAvailed.Columns[9].Visible = false;

                        grdTermLoanRepaid.Columns[9].Visible = false;
                        grdTermLoanRepaid.Columns[8].Visible = false;

                        DivCurrentClaimPeriod.Visible = false;
                        GvInterestSubsidyPeriod.Columns[5].Visible = false;
                        GvInterestSubsidyPeriod.Columns[4].Visible = false;

                        DivAdditionalinformation.Visible = false;
                        gvAdditionalInformation.Columns[11].Visible = false;
                        gvAdditionalInformation.Columns[10].Visible = false;

                        DivTotalLoanAmountRepaid.Visible = false;
                        grdTotalTermLoanRepaid.Columns[6].Visible = false;
                        grdTotalTermLoanRepaid.Columns[5].Visible = false;

                        DivMoratoriumPeriod.Visible = false;
                        GvMoratoriumPeriod.Columns[7].Visible = false;
                        GvMoratoriumPeriod.Columns[6].Visible = false;


                        btnLoanCertificate.Enabled = false;
                        btnCertification.Enabled = false;
                        btnCopyoftheloan.Enabled = false;
                        btnDocuments.Enabled = false;
                        btnStatementofactual.Enabled = false;
                        btnBankCertificateOverdue.Enabled = false;

                    }
                    else
                    {
                        EnableDisableForm(Page.Controls, true);
                    }
                }
            }
            try
            {

                ds = GetInterestSubsidy(IncentiveID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    //txtCCPFrom.Text = ds.Tables[0].Rows[0]["CCP_From"].ToString();
                    //txtCCPTo.Text = ds.Tables[0].Rows[0]["CCP_To"].ToString();
                    txtCCA.Text = ds.Tables[0].Rows[0]["CCA"].ToString();
                    //ddlCCPType.SelectedValue = ds.Tables[0].Rows[0]["CCP_Type"].ToString();
                    txtAmountAvailed.Text = ds.Tables[0].Rows[0]["AmountAvailed"].ToString();
                    txtSanctionOrderNo.Text = ds.Tables[0].Rows[0]["SanctionOrderNo"].ToString();
                    txtDateAvailed.Text = ds.Tables[0].Rows[0]["DateAvailedDDMMYY"].ToString();
                }


                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    try
                    {
                        int RowsCount = ds.Tables[1].Rows.Count;
                        string Path, Docid;
                        for (int i = 0; i < RowsCount; i++)
                        {
                            Path = ds.Tables[1].Rows[i]["link"].ToString();
                            Docid = ds.Tables[1].Rows[i]["AttachmentId"].ToString();
                            if (!string.IsNullOrEmpty(Path))
                            {
                                if (Docid == "31001")
                                {
                                    objClsFileUpload.AssignPath(hyLoanCertificate, Path);
                                }
                                else if (Docid == "31002")
                                {
                                    objClsFileUpload.AssignPath(hyCertification, Path);
                                }
                                else if (Docid == "31003")
                                {
                                    objClsFileUpload.AssignPath(hyCopyoftheloan, Path);
                                }
                                else if (Docid == "31004")
                                {
                                    objClsFileUpload.AssignPath(hyDocuments, Path);
                                }
                                else if (Docid == "31005")
                                {
                                    objClsFileUpload.AssignPath(hyStatementofactual, Path);
                                }
                                else if (Docid == "31006")
                                {
                                    objClsFileUpload.AssignPath(hyBankCertificateOverdue, Path);
                                }
                                else if (Docid == "31007")
                                {
                                    objClsFileUpload.AssignPath(hyLoanStatement, Path);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string errorMsg = ex.Message;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CalculatationEnterprise1(string Step)
        {
            try
            {
                decimal PlantMachValexisting = 0;
                decimal PlantMachValexpansion = 0;
                decimal PlantMachValFinal = 0;


                decimal landexisting = 0, landcapacity = 0;

                decimal buildingexisting = 0, buildingcapacity = 0;

                decimal Othernew = 0, OtherExisting = 0;

                decimal PlantMachValPer = 0;
                decimal landcapacityPer = 0;
                decimal buildingcapacityPer = 0;
                decimal OthernewPer = 0;

                if (Step == "1")
                {
                    if (txtlandexisting.Text != null && txtlandexisting.Text != "" && txtlandexisting.Text != string.Empty)
                    {
                        landexisting = Convert.ToDecimal(txtlandexisting.Text.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        landexisting = 0;
                    }
                    if (txtbuildingexisting.Text != null && txtbuildingexisting.Text != "" && txtbuildingexisting.Text != string.Empty)
                    {
                        buildingexisting = Convert.ToDecimal(txtbuildingexisting.Text.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        buildingexisting = 0;
                    }

                    if (txtplantexisting.Text != null && txtplantexisting.Text != "" && txtplantexisting.Text != string.Empty)
                    {
                        PlantMachValexisting = Convert.ToDecimal(txtplantexisting.Text.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        PlantMachValexisting = 0;
                    }
                    //if (txtnewothers.Text != null && txtnewothers.Text != "" && txtnewothers.Text != string.Empty)
                    //{
                    //    Othernew = Convert.ToDecimal(txtnewothers.Text.Trim());  // expansion Plant Mach value   
                    //}
                    //else
                    //{
                    //    Othernew = 0;
                    //}

                    PlantMachValFinal = (PlantMachValexisting + landexisting + buildingexisting + Othernew);
                    lblnewinv.Text = PlantMachValFinal.ToString();
                }
                else if (Step == "2")
                {
                    //--------------------------------
                    if (txtlandcapacity.Text != null && txtlandcapacity.Text != "" && txtlandcapacity.Text != string.Empty)
                    {
                        landcapacity = Convert.ToDecimal(txtlandcapacity.Text.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        landcapacity = 0;
                    }
                    if (txtbuildingcapacity.Text != null && txtbuildingcapacity.Text != "" && txtbuildingcapacity.Text != string.Empty)
                    {
                        buildingcapacity = Convert.ToDecimal(txtbuildingcapacity.Text.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        buildingcapacity = 0;
                    }

                    // -------------------------------

                    if (txtplantcapacity.Text != null && txtplantcapacity.Text != "" && txtplantcapacity.Text != string.Empty)
                    {
                        PlantMachValexpansion = Convert.ToDecimal(txtplantcapacity.Text.Trim());  // expansion Plant Mach value   
                    }
                    else
                    {
                        PlantMachValexpansion = 0;
                    }
                    //-----------------


                    //if (txtexistother.Text != null && txtexistother.Text != "" && txtexistother.Text != string.Empty)
                    //{
                    //    OtherExisting = Convert.ToDecimal(txtexistother.Text.Trim());  // expansion Plant Mach value   
                    //}
                    //else
                    //{
                    //    OtherExisting = 0;
                    //}
                    PlantMachValFinal = (PlantMachValexpansion + landcapacity + buildingcapacity + OtherExisting);
                    lblexpinv.Text = PlantMachValFinal.ToString();
                }
                else if (Step == "3")
                {
                    if (txtlandpercentage.Text != null && txtlandpercentage.Text != "" && txtlandpercentage.Text != string.Empty)
                    {
                        landcapacityPer = Convert.ToDecimal(txtlandpercentage.Text.Trim());  // expansion Plant Mach value   
                    }
                    else
                    {
                        landcapacityPer = 0;
                    }

                    if (txtbuildingpercentage.Text != null && txtbuildingpercentage.Text != "" && txtbuildingpercentage.Text != string.Empty)
                    {
                        buildingcapacityPer = Convert.ToDecimal(txtbuildingpercentage.Text.Trim());  // expansion Plant Mach value   
                    }
                    else
                    {
                        buildingcapacityPer = 0;
                    }

                    if (txtplantpercentage.Text != null && txtplantpercentage.Text != "" && txtplantpercentage.Text != string.Empty)
                    {
                        PlantMachValPer = Convert.ToDecimal(txtplantpercentage.Text.Trim());  // expansion Plant Mach value   
                    }
                    else
                    {
                        PlantMachValPer = 0;
                    }

                    //if (txtotherpersangage.Text != null && txtotherpersangage.Text != "" && txtotherpersangage.Text != string.Empty)
                    //{
                    //    OthernewPer = Convert.ToDecimal(txtotherpersangage.Text.Trim());  // expansion Plant Mach value   
                    //}
                    //else
                    //{
                    //    OthernewPer = 0;
                    //}

                    PlantMachValFinal = Convert.ToDecimal((landcapacityPer + buildingcapacityPer + PlantMachValPer + OthernewPer) / 3);

                    lbltotperinv.Text = PlantMachValFinal.ToString("#.##");
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }
        }
        public DataSet GetapplicationDtls(string USERID, int INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@CREATEDBY",SqlDbType.VarChar),
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = USERID;
            pp[1].Value = INCENTIVEID;
            Dsnew = caf.GenericFillDs("USP_GET_INCENTIVES_CAF_DATA", pp);
            return Dsnew;
        }
        public DataSet GetInterestSubsidy(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
           };
            pp[0].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_INCENTIVE_INTERESTSUBSIDY", pp);
            return Dsnew;
        }

        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("CapitalAssistanceCreationEnergy.aspx?Previous=" + "P");

        }

        public string ValidateTLAControls()
        {
            int slno = 1;
            string ErrorMsg = "";
            if (ddlBankAvail.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Bank\\n";
                slno = slno + 1;
            }
            if (txtTLABranch.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Brabch Name\\n";
                slno = slno + 1;
            }
            if (txtTLAIFSCode.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter IFSCode Name\\n";
                slno = slno + 1;
            }
            if (txtTLALACNo.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Loan Account Number\\n";
                slno = slno + 1;
            }
            if (txtTLASONo.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Sanction Order Number\\n";
                slno = slno + 1;
            }
            if (txtTLASODate.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Sanction Order Date\\n";
                slno = slno + 1;
            }
            if (txtTLASAmount.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Sanctioned Amount\\n";
                slno = slno + 1;
            }
            if (txtTLAReleasedDate.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Amount Released Date\\n";
                slno = slno + 1;
            }
            return ErrorMsg;
        }
        public string ValidateTLRControls()
        {
            int slno = 1;
            string ErrorMsg = "";
            //if (txtTLRFInYear.Text.TrimStart().TrimEnd().Trim() == "")
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Enter Financial Year\\n";
            //    slno = slno + 1;
            //}

            /* if (lblFinYearRepaid.SelectedValue == "0")
             {
                 ErrorMsg = ErrorMsg + slno + ". Please Select Financial Year\\n";
                 slno = slno + 1;
             }
             if (ddlhalfYearRepaid.SelectedValue == "0")
             {
                 ErrorMsg = ErrorMsg + slno + ". Please Select Financial 1st/2nd half Year\\n";
                 slno = slno + 1;
             }*/
            if (ddlTermLoan.SelectedValue == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Term Loan\\n";
                slno = slno + 1;
            }
            if (ddlBankrepaid.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Bank\\n";
                slno = slno + 1;
            }
            if (txtPrincipal.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Principal Amount\\n";
                slno = slno + 1;
            }
            if (txtRateofInterest.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Rate of Interest\\n";
                slno = slno + 1;
            }

            if (txtInterest.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Interest Amount\\n";
                slno = slno + 1;
            }
            if (txtDOP.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Payment Date\\n";
                slno = slno + 1;
            }
            if (txtAccountNo.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Account No\\n";
                slno = slno + 1;
            }
            if (txtOpeningBal.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Opening Balance at the Start of Half Year\\n";
                slno = slno + 1;
            }
            if (txtClosingBal.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Closing Balance at the End of Half Year\\n";
                slno = slno + 1;
            }
            return ErrorMsg;
        }
        public string ValidateAllControls()
        {
            int slno = 1;
            string ErrorMsg = "";
            //if (grdTermLoanAvailed.Rows.Count <= 0)
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Add Loan availed Details \\n";
            //    slno = slno + 1;
            //}
            if (GVTermLoandtls.Rows.Count < 1)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Add Term Loan details \\n";
                slno = slno + 1;
            }
            /*if (gvAdditionalInformation.Rows.Count < 1)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Add Additional Information details \\n";
                slno = slno + 1;
            } */
            if (grdTermLoanRepaid.Rows.Count <= 0)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Add Loan repayment Details \\n";
                slno = slno + 1;
            }
            //if (txtCCPFrom.Text.TrimStart().TrimEnd().Trim() == "")
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Enter Current Fin. Year From \\n";
            //    slno = slno + 1;
            //}
            //if (txtCCPTo.Text.TrimStart().TrimEnd().Trim() == "")
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Enter Current Fin. Year From\\n";
            //    slno = slno + 1;
            //}
            if (txtCCA.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Amount\\n";
                slno = slno + 1;
            }
            /*if (grdTermLoanRepaid.Rows.Count > 0)
            {
                string TermLoan = "";
                foreach (GridViewRow gvrow in grdTermLoanRepaid.Rows)
                {
                    Label lblTermLoanNo = (Label)gvrow.FindControl("lblTermLoanNo");
                     TermLoan = lblTermLoanNo.Text.ToString();
                }
                if (TermLoan == "TermLoan1")
                {
                    if (ddlMonthTL1.Items.Count < 6)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please add Total Six Months Cliam Details of TermLoan1\\n";
                        slno = slno + 1;
                    }
                }
                if (TermLoan == "TermLoan2")
                {
                    if (ddlMonthTL2.Items.Count < 6)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please add Total Six Months Cliam Details of TermLoan2\\n";
                        slno = slno + 1;
                    }
                }
                if (TermLoan == "TermLoan3")
                {
                    if (ddlMonthTL3.Items.Count < 6)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please add Total Six Months Cliam Details of TermLoan3\\n";
                        slno = slno + 1;
                    }
                }
            }*/
            if (hdnTermloan1Active.Value == "Y")
            {
                if (gvAdditionalInformation.Rows.Count < 6)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please add Total Six Months Cliam Details of TermLoan1\\n";
                    slno = slno + 1;
                }
            }
            if (hdnTermloan2Active.Value == "Y")
            {
                if (gvAdditionalInformation2.Rows.Count < 6)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please add Total Six Months Cliam Details of TermLoan2\\n";
                    slno = slno + 1;
                }
            }
            if (hdnTermloan3Active.Value == "Y")
            {
                if (gvAdditionalInformation3.Rows.Count < 6)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please add Total Six Months Cliam Details of TermLoan3\\n";
                    slno = slno + 1;
                }
            }
            if (rbtnMoratoriumYesNo.SelectedValue == "1")
            {
                if (GvMoratoriumPeriod.Rows.Count < 1)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please add Moratorium Period for RePayment of Loan Details\\n";
                    slno = slno + 1;
                }
            }
            if (rbtnOtherAgency.SelectedValue == "1")
            {
                if (txtAmountAvailed.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ".Please enter Amount Availed of Govt. of India or any other Agency\\n";
                    slno = slno + 1;
                }
                if (txtSanctionOrderNo.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Sanction Order No of Govt. of India or any other Agency\\n";
                    slno = slno + 1;
                }
                if (txtDateAvailed.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please select Availed Date of Govt. of India or any other Agency\\n";
                    slno = slno + 1;
                }
            }
                return ErrorMsg;
        }

        protected void grdTermLoanAvailed_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                ddlBankAvail.SelectedValue = ((Label)(gr.FindControl("lblBankId"))).Text;

                txtTLABranch.Text = ((Label)(gr.FindControl("lblb"))).Text;
                txtTLAIFSCode.Text = ((Label)(gr.FindControl("lblc"))).Text;
                txtTLALACNo.Text = ((Label)(gr.FindControl("lbld"))).Text;
                txtTLASONo.Text = ((Label)(gr.FindControl("lble"))).Text;
                txtTLASODate.Text = ((Label)(gr.FindControl("lblf"))).Text;
                txtTLASAmount.Text = ((Label)(gr.FindControl("lblg"))).Text;
                txtTLAReleasedDate.Text = ((Label)(gr.FindControl("lblh"))).Text;

                ViewState["ISId"] = ((Label)(gr.FindControl("lblISId"))).Text;
                btnAddBankDetails.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                TermLoanAvaied tla = new TermLoanAvaied();

                tla.ISId = Convert.ToInt32(((Label)(gr.FindControl("lblISId"))).Text);
                tla.TransType = "DLT";
                tla.IncentiveId = Convert.ToInt32(Session["IncentiveID"].ToString());
                tla.Created_by = ObjLoginNewvo.uid;


                string Validstatus = caf.InsertTermLoanAvailed(tla);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnAddBankDetails.Text = "Add New";
                    ViewState["ISId"] = "0";

                    clearTLAControls();
                    BindTermLoanAvailed(0, Convert.ToInt32(Session["IncentiveID"].ToString()));

                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }
        protected void btnRepaymentAdd_Click(object sender, EventArgs e)
        {

            try
            {
                if (ViewState["TLRId"] == null)
                {
                    ViewState["TLRId"] = "0";
                }
                
                string errormsg = ValidateTLRControls();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    TermLoanRepaid tlr = new TermLoanRepaid();
                    tlr.TLRId = Convert.ToInt32(ViewState["TLRId"].ToString());
                    tlr.IncentiveId = Convert.ToInt32(Session["IncentiveID"].ToString());
                    tlr.SubIncentiveId = 3;
                    //tlr.FinYear = txtTLRFInYear.Text;
                    tlr.FinYear = lblFinYearRepaid.SelectedValue;
                    tlr.HalfFinYear = ddlhalfYearRepaid.SelectedValue;

                    tlr.BankId = Convert.ToInt32(ddlBankrepaid.SelectedValue);
                    tlr.BankName = ddlBankrepaid.SelectedItem.Text;
                    tlr.PrincipalAmt = Convert.ToDecimal(GetDecimalNullValue(txtPrincipal.Text));
                    tlr.RateOfInterest = Convert.ToDecimal(GetDecimalNullValue(txtRateofInterest.Text));
                    tlr.InterestAmt = Convert.ToDecimal(GetDecimalNullValue(txtInterest.Text));
                    tlr.PaymentDate = GetFromatedDateDDMMYYYY(txtDOP.Text);
                    tlr.Created_by = ObjLoginNewvo.uid;
                    /*added on 11-05-2023*/
                    tlr.TermLoanNo = ddlTermLoan.SelectedItem.ToString();
                    tlr.AccountNo = txtAccountNo.Text.ToString();
                    tlr.OpeningBalanceStartofHalfYear = Convert.ToDecimal(txtOpeningBal.Text.ToString());
                    tlr.ClosingBalanceEndofHalfYear = Convert.ToDecimal(txtClosingBal.Text.ToString());
                    /**/
                    tlr.TransType = "INS";

                    string Validstatus = caf.InsertTermLoanRepaid(tlr);
                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        if (ddlTermLoan.SelectedValue == "TermLoan1")
                        {
                            ddlBankTL.SelectedValue = ddlBankrepaid.SelectedValue.ToString();
                            ddlBankTL.Enabled = false;
                            if (ddlAccountsNo.SelectedValue == "1")
                            {
                                txtAcNo.Text = txtAccountNo.Text.ToString();
                                txtAcNo.Enabled = false;
                            }
                        }
                        if (ddlTermLoan.SelectedValue == "TermLoan2")
                        {
                            ddlBankTL2.SelectedValue = ddlBankrepaid.SelectedValue.ToString();
                            ddlBankTL2.Enabled = false;
                            if (ddlAccountsNo.SelectedValue == "1")
                            {
                                txtAcNo2.Text = txtAccountNo.Text.ToString();
                                txtAcNo2.Enabled = false;
                            }
                        }
                        if (ddlTermLoan.SelectedValue == "TermLoan3")
                        {
                            ddlBankTL3.SelectedValue = ddlBankrepaid.SelectedValue.ToString();
                            ddlBankTL3.Enabled = false;
                            if (ddlAccountsNo.SelectedValue == "1")
                            {
                                txtAcNo3.Text = txtAccountNo.Text.ToString();
                                txtAcNo3.Enabled = false;
                            }
                        }
                        clearTLRControls();
                        BindTermLoanRepaid(0, Convert.ToInt32(Session["IncentiveID"].ToString()));
                        btnRepaymentAdd.Text = "Add";
                        ddlTermLoan.Items.Clear();
                        BindTearmLoanDtlsDDL(Session["IncentiveID"].ToString(), "I");
                        /*BindMonthWise(grdTermLoanRepaid.Rows.Count);*/
                        
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
        protected void grdTermLoanRepaid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                /* lblFinYearRepaid.SelectedValue = ((Label)(gr.FindControl("lblISRepaidFinancialYearID"))).Text.Trim();

                 if (((Label)(gr.FindControl("lblRepaidTypeOfFinancialYear"))).Text.Trim() != "")
                 {
                     ddlhalfYearRepaid.SelectedValue = ((Label)(gr.FindControl("lblRepaidTypeOfFinancialYear"))).Text.Trim();
                 }*/
                BindTearmLoanDtlsDDL(Session["IncentiveID"].ToString(), "U");
                ddlBankrepaid.SelectedValue = ((Label)(gr.FindControl("lblbankidrp"))).Text;

                txtPrincipal.Text = ((Label)(gr.FindControl("lblPrincipalAmt"))).Text;
                txtRateofInterest.Text = ((Label)(gr.FindControl("lblRateOfInterest"))).Text;
                txtInterest.Text = ((Label)(gr.FindControl("lblInterestAmt"))).Text;
                txtDOP.Text = ((Label)(gr.FindControl("lblPaymentDate"))).Text;
                ddlTermLoan.SelectedValue= ((Label)(gr.FindControl("lblTermLoanNo"))).Text.Trim();
                txtAccountNo.Text= ((Label)(gr.FindControl("lblLoanAccountNumber"))).Text;
                txtOpeningBal.Text= ((Label)(gr.FindControl("lblBalanceattheStarting"))).Text;
                txtClosingBal.Text= ((Label)(gr.FindControl("lblBalanceattheEnd"))).Text;
                
                ViewState["TLRId"] = ((Label)(gr.FindControl("lblTLRId"))).Text;
                btnRepaymentAdd.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                TermLoanRepaid tlr = new TermLoanRepaid();

                tlr.TLRId = Convert.ToInt32(((Label)(gr.FindControl("lblTLRId"))).Text);
                tlr.TransType = "DLT";
                tlr.IncentiveId = Convert.ToInt32(Session["IncentiveID"].ToString());
                tlr.Created_by = ObjLoginNewvo.uid;


                string Validstatus = caf.InsertTermLoanRepaid(tlr);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnRepaymentAdd.Text = "Add New";
                    ViewState["TLRId"] = "0";

                    clearTLRControls();
                    BindTermLoanRepaid(0, Convert.ToInt32(Session["IncentiveID"].ToString()));
                    BindTearmLoanDtlsDDL(Session["IncentiveID"].ToString(), "I");
                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }
        public DataSet GetTermLoanDtlsDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = caf.GenericFillDs("USP_GET_TERMLOAN_DTLS", pp);
            return Dsnew;
        }
        public DataSet GetTermLoanDtlsDtlsDDL(string INCENTIVEID,string Flag)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar),
               new SqlParameter("@FLAG",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            pp[1].Value = Flag;
            Dsnew = caf.GenericFillDs("USP_GET_TERMLOAN_DTLS_FOR_REPAID", pp);
            return Dsnew;
        }
        protected void BindTearmLoanDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetTermLoanDtlsDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    GVTermLoandtls.DataSource = dsnew.Tables[0];
                    GVTermLoandtls.DataBind();
                }
                else
                {
                    GVTermLoandtls.DataSource = null;
                    GVTermLoandtls.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BindTearmLoanDtlsDDL(string INCENTIVEID,string Flag)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetTermLoanDtlsDtlsDDL(INCENTIVEID, Flag);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {   
                    ddlTermLoan.DataSource = dsnew.Tables[0];
                    ddlTermLoan.DataTextField = "AvailedTermLoan";
                    ddlTermLoan.DataValueField = "AvailedTermLoan";
                    ddlTermLoan.DataBind();
                }
                else
                {
                    ddlTermLoan.DataSource = null;
                    ddlTermLoan.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        protected void btnLoanCertificate_Click(object sender, EventArgs e)
        {
            if (fuLoanCertificate.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuLoanCertificate);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuLoanCertificate);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLoanCertificate, hyLoanCertificate, "FromIVLoanCertificate", Session["IncentiveID"].ToString(), "3", "31001", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                        hyLoanCertificate.Visible = true;
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
            else
            {
                MessageBox("Select File!");

            }
        }

        protected void btnCertification_Click(object sender, EventArgs e)
        {
            if (fuCertification.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuCertification);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuCertification);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuCertification, hyCertification, "FromIVObligationsCertification", Session["IncentiveID"].ToString(), "3", "31002", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                        hyCertification.Visible = true;
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
            else
            {
                MessageBox("Select File!");

            }
        }

        protected void btnCopyoftheloan_Click(object sender, EventArgs e)
        {
            if (fuCopyoftheloan.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuCopyoftheloan);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuCopyoftheloan);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuCopyoftheloan, hyCopyoftheloan, "FromIVCopyoftheloanappraisal", Session["IncentiveID"].ToString(), "3", "31003", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                        hyCopyoftheloan.Visible = true;
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
            else
            {
                MessageBox("Select File!");

            }
        }

        protected void btnDocuments_Click(object sender, EventArgs e)
        {
            if (fuDocuments.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuDocuments);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuDocuments);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuDocuments, hyDocuments, "FromIVinterestsubsidyavailedDocuments", Session["IncentiveID"].ToString(), "3", "31004", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                        hyDocuments.Visible = true;
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
            else
            {
                MessageBox("Select File!");

            }
        }

        protected void btnStatementofactual_Click(object sender, EventArgs e)
        {
            if (fuStatementofactual.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuStatementofactual);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuStatementofactual);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuStatementofactual, hyStatementofactual, "FromIVactualinterestpaidtothebank", Session["IncentiveID"].ToString(), "3", "31005", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                        hyStatementofactual.Visible = true;
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
            else
            {
                MessageBox("Select File!");

            }
        }

        protected void btnBankCertificateOverdue_Click(object sender, EventArgs e)
        {
            if (fuBankCertificateOverdue.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuBankCertificateOverdue);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuBankCertificateOverdue);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuBankCertificateOverdue, hyBankCertificateOverdue, "FromIVBankCertificateOverdue", Session["IncentiveID"].ToString(), "3", "31006", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                        hyBankCertificateOverdue.Visible = true;
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
            else
            {
                MessageBox("Select File!");

            }
        }
        protected void btnLoanStatement_Click(object sender, EventArgs e)
        {
            if (fuLoanStatement.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuLoanStatement);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuLoanStatement);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLoanStatement, hyLoanStatement, "FromIVLoanStatement", Session["IncentiveID"].ToString(), "3", "31007", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        /*success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";*/
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Attachment Successfully Uploaded');", true);
                        hyLoanStatement.Visible = true;
                    }
                }
                else
                {
                   /* MessageBox("Only pdf files allowed!");*/
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Only pdf files allowed!');", true);
                }
            }
            else
            {
                /*MessageBox("Select File!");*/
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Select File!');", true);

            }
        }
        public string ValidateAdditionalInformationDtls()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (ddlMonthTL1.SelectedValue=="0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Month \\n";
                slno = slno + 1;
            }
            if (ddlBankTL.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Bank/Financial Institution \\n";
                slno = slno + 1;
            }
            if (txtAcNo.Text=="")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Account Number \\n";
                slno = slno + 1;
            }
            if (txtTearmLoanAmount.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Term Loan Amount / O.B (In Rupees) \\n";
                slno = slno + 1;
            }
            if (txtNoOfInstallments.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Installment No. \\n";
                slno = slno + 1;
            }
            if (txtRateofInterestAmountDue.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Rate of Interest (%) \\n";
                slno = slno + 1;
            }
            if (txtInterstPaid.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Interest Paid (In Rupees) \\n";
                slno = slno + 1;
            }
            if (txtClosingBalance.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Closing Balance (In Rupees) \\n";
                slno = slno + 1;
            }
            if (txtEligibleRateInterest.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Eligible Rate of Interest (In Rupees) \\n";
                slno = slno + 1;
            }
            if (txtEligibleInterest.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Eligible Interest Amount (In Rupees) \\n";
                slno = slno + 1;
            }

            return ErrorMsg;
        }
        public string ValidateAdditionalInformationDtls2()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (ddlMonthTL2.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Month \\n";
                slno = slno + 1;
            }
            if (ddlBankTL2.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Bank/Financial Institution \\n";
                slno = slno + 1;
            }
            if (txtAcNo2.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Account Number \\n";
                slno = slno + 1;
            }
            if (txtTearmLoanAmount2.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Term Loan Amount / O.B (In Rupees) \\n";
                slno = slno + 1;
            }
            if (txtNoOfInstallments2.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Installment No. \\n";
                slno = slno + 1;
            }
            if (txtRateofInterestAmountDue2.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Rate of Interest (%) \\n";
                slno = slno + 1;
            }
            if (txtInterstPaid2.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Interest Paid (In Rupees) \\n";
                slno = slno + 1;
            }
            if (txtClosingBalance2.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Closing Balance (In Rupees) \\n";
                slno = slno + 1;
            }
            if (txtEligibleRateInterest2.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Eligible Rate of Interest (In Rupees) \\n";
                slno = slno + 1;
            }
            if (txtEligibleInterest2.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Eligible Interest Amount (In Rupees) \\n";
                slno = slno + 1;
            }

            return ErrorMsg;
        }
        public string ValidateAdditionalInformationDtls3()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (ddlMonthTL3.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Month \\n";
                slno = slno + 1;
            }
            if (ddlBankTL3.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Bank/Financial Institution \\n";
                slno = slno + 1;
            }
            if (txtAcNo3.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Account Number \\n";
                slno = slno + 1;
            }
            if (txtTearmLoanAmount3.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Term Loan Amount / O.B (In Rupees) \\n";
                slno = slno + 1;
            }
            if (txtNoOfInstallments3.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Installment No. \\n";
                slno = slno + 1;
            }
            if (txtRateofInterestAmountDue3.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Rate of Interest (%) \\n";
                slno = slno + 1;
            }
            if (txtInterstPaid3.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Interest Paid (In Rupees) \\n";
                slno = slno + 1;
            }
            if (txtClosingBalance3.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Closing Balance (In Rupees) \\n";
                slno = slno + 1;
            }
            if (txtEligibleRateInterest3.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Eligible Rate of Interest (In Rupees) \\n";
                slno = slno + 1;
            }
            if (txtEligibleInterest3.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Eligible Interest Amount (In Rupees) \\n";
                slno = slno + 1;
            }

            return ErrorMsg;
        }
        public string ValidateDtls()
        {
            int slno = 1;
            string ErrorMsg = "";


            if (ddlFinYear.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Financial Year \\n";
                slno = slno + 1;
            }
            if (ddlFin1stOr2ndHalfyear.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Financial Half Year \\n";
                slno = slno + 1;
            }

            /*if (txtAmountPaid.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Total Amount(In Rupees) \\n";
                slno = slno + 1;
            }*/

            //if (GvInterestSubsidyPeriod.Rows.Count > 0)
            //{
            //    string FinYear = ddlFinYear.SelectedValue;
            //    string Fin1stOr2ndHalfyear = ddlFin1stOr2ndHalfyear.SelectedValue;

            //    foreach (GridViewRow gridViewRow in GvInterestSubsidyPeriod.Rows)
            //    {
            //        string lblISFinancialYearID = (gridViewRow.FindControl("lblISFinancialYearID") as Label).ToString();
            //        string lblTypeOfFinancialYear = (gridViewRow.FindControl("lblTypeOfFinancialYear") as Label).ToString();

            //        if(FinYear== lblISFinancialYearID && Fin1stOr2ndHalfyear== lblTypeOfFinancialYear)
            //        {
            //            ErrorMsg = ErrorMsg + slno + ".The Enetered Claim Period has been Added already\\n";
            //            slno = slno + 1;
            //        }
            //        break;
            //    }
            //}


            return ErrorMsg;
        }
        protected void btnInterestSubsidyPeriodAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["ISClaimPeriod_ID"] == null)
                {
                    ViewState["ISClaimPeriod_ID"] = "0";
                }
                if (GvInterestSubsidyPeriod.Rows.Count > 0)
                {
                    string errormsg1 = "Only one Half Year allowed";
                    string message = "alert('" + errormsg1 + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string errormsg = ValidateDtls();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    EnergyConsumedBO objEnergyConsumedBO = new EnergyConsumedBO();

                    objEnergyConsumedBO.EnergyConsumed_ID = ViewState["ISClaimPeriod_ID"].ToString();
                    objEnergyConsumedBO.TransType = "INS";
                    objEnergyConsumedBO.IncentiveId = Session["IncentiveID"].ToString();
                    objEnergyConsumedBO.Created_by = ObjLoginNewvo.uid;
                    objEnergyConsumedBO.FinancialYear = ddlFinYear.SelectedValue;
                    objEnergyConsumedBO.FinancialYearText = ddlFinYear.SelectedItem.Text;
                    objEnergyConsumedBO.TypeOfFinancialYear = ddlFin1stOr2ndHalfyear.SelectedValue;
                    objEnergyConsumedBO.TypeOfFinancialYearText = ddlFin1stOr2ndHalfyear.SelectedItem.Text;

                    /*objEnergyConsumedBO.TotalAmount = (txtAmountPaid.Text.Trim().TrimStart() != "") ? txtAmountPaid.Text.Trim().TrimStart() : null;*/

                    string DbErrorMsg = "";
                    string Validstatus = caf.InsertISCurrentCliamDetails(objEnergyConsumedBO,out DbErrorMsg);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0" && DbErrorMsg == "")
                    {
                        //BindClaimFinancialYears(ddlFinYear, "7", Session["IncentiveID"].ToString(), "3");
                        btnInterestSubsidyPeriodAdd.Text = "Add New";
                        ViewState["ISClaimPeriod_ID"] = "0";

                        ddlFinYear.SelectedValue = "0";
                        ddlFin1stOr2ndHalfyear.SelectedValue = "0";
                        ddlFinYear.Enabled = false;
                        ddlFin1stOr2ndHalfyear.Enabled = false;

                        BindISCrrentClaimPeriodDtls(Session["IncentiveID"].ToString());
                        lblmsg.Text = "Saved Successfully";
                        Failure.Visible = false;
                        success.Visible = true;
                    }
                    else
                    {
                        string Dbmessage = "alert('" + DbErrorMsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", Dbmessage, true);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        protected void GvInterestSubsidyPeriod_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                ddlFinYear.Enabled = true;
                ddlFin1stOr2ndHalfyear.Enabled = true;
                ddlFinYear.SelectedValue = ((Label)(gr.FindControl("lblISFinancialYearID"))).Text;
                ddlFin1stOr2ndHalfyear.SelectedValue = ((Label)(gr.FindControl("lblTypeOfFinancialYear"))).Text;
                ViewState["ISClaimPeriod_ID"] = ((Label)(gr.FindControl("lblISClaimPeriod_ID"))).Text;
                btnInterestSubsidyPeriodAdd.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                EnergyConsumedBO objEnergyConsumedBO = new EnergyConsumedBO();

                objEnergyConsumedBO.EnergyConsumed_ID = ((Label)(gr.FindControl("lblISClaimPeriod_ID"))).Text;
                objEnergyConsumedBO.TransType = "DLT";
                objEnergyConsumedBO.IncentiveId = Session["IncentiveID"].ToString();
                objEnergyConsumedBO.Created_by = ObjLoginNewvo.uid;
                string DbErrorMsg = "";
                string Validstatus = caf.InsertISCurrentCliamDetails(objEnergyConsumedBO, out DbErrorMsg);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnInterestSubsidyPeriodAdd.Text = "Add New";
                    ViewState["ISClaimPeriod_ID"] = "0";

                    ddlFinYear.SelectedValue = "0";
                    ddlFin1stOr2ndHalfyear.SelectedValue = "0";
                    txtAmountPaid.Text = "";

                    BindISCrrentClaimPeriodDtls(Session["IncentiveID"].ToString());

                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
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

                    ddlFinYear.Enabled = false; ddlFin1stOr2ndHalfyear.Enabled = false;
                    ddlFinYear.SelectedValue= dsnew.Tables[0].Rows[0]["FinancialYear"].ToString();
                    ddlFin1stOr2ndHalfyear.SelectedValue= dsnew.Tables[0].Rows[0]["TypeOfFinancialYear"].ToString();
                    hdnHalfYear.Value = dsnew.Tables[0].Rows[0]["TypeOfFinancialYear"].ToString();
                    string IncentiveId = Session["IncentiveID"].ToString();
                    BindMonths1(ddlFin1stOr2ndHalfyear.SelectedValue.ToString(), "H", IncentiveId, "TermLoan1");
                    BindMonths2(ddlFin1stOr2ndHalfyear.SelectedValue.ToString(), "H", IncentiveId, "TermLoan2");
                    BindMonths3(ddlFin1stOr2ndHalfyear.SelectedValue.ToString(), "H", IncentiveId, "TermLoan3");
                    

                    /*double TotalAmount = 0;
                    foreach (GridViewRow Gvrow in GvInterestSubsidyPeriod.Rows)
                    {
                        string Value = (Gvrow.FindControl("lblAmountPaid") as Label).Text;
                        TotalAmount = Convert.ToDouble(GetDecimalNullValue(Value)) + Convert.ToDouble(TotalAmount);
                    }
                    txtCCA.Text = TotalAmount.ToString();*/
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
            Dsnew = caf.GenericFillDs("USP_GET_IS_CURRENTCLAIM_PERIOD_DTLS", pp);
            return Dsnew;
        }
        public DataSet GetFinancialYearIncentives(string Count, string incentiveid)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@YEARS",SqlDbType.VarChar),
                new SqlParameter("@incentiveid",SqlDbType.VarChar)
           };
            pp[0].Value = Count;
            pp[1].Value = incentiveid;
            Dsnew = caf.GenericFillDs("USP_GET_FINANCIALYEARS", pp);
            return Dsnew;
        }
        public DataSet GetFinancialYearMonths(string HalfYear, string Flag, string IncentiveId, string TermLoan)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@HalfYear",SqlDbType.VarChar),
               new SqlParameter("@Flag",SqlDbType.VarChar),
               new SqlParameter("@IncentiveId",SqlDbType.VarChar),
               new SqlParameter("@TermLoan",SqlDbType.VarChar),
           };
            pp[0].Value = HalfYear;
            pp[1].Value = Flag;
            pp[2].Value = IncentiveId;
            pp[3].Value = TermLoan;
            Dsnew = caf.GenericFillDs("USP_GET_HALF_YEAR_MONTHS", pp);
            return Dsnew;
        }

        protected void btnadditionalInformationAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["AdditionalinformationId"] == null)
                {
                    ViewState["AdditionalinformationId"] = "0";
                }

                string errormsg = ValidateAdditionalInformationDtls();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    AdditionalinformationBO objAdditionalinformationBO = new AdditionalinformationBO();

                    objAdditionalinformationBO.AdditionalinformationId = ViewState["AdditionalinformationId"].ToString();
                    objAdditionalinformationBO.TransType = "INS";
                    objAdditionalinformationBO.IncentiveId = Session["IncentiveID"].ToString();
                    objAdditionalinformationBO.Created_by = ObjLoginNewvo.uid;

                    /*objAdditionalinformationBO.AmountDueDate = GetFromatedDateDDMMYYYY(txtAmountDueDate.Text.Trim().TrimStart());
                     objAdditionalinformationBO.InterestDue = GetDecimalNullValue(txtInterestDue.Text.Trim().TrimStart());
                     objAdditionalinformationBO.UnitHolderContribution = GetDecimalNullValue(txtUnitHolderContribution.Text.Trim().TrimStart()); */

                    objAdditionalinformationBO.TermLoan = "TermLoan1";
                    objAdditionalinformationBO.MonthId = ddlMonthTL1.SelectedValue.ToString();
                    objAdditionalinformationBO.Months = ddlMonthTL1.SelectedItem.ToString();
                    objAdditionalinformationBO.BankId = Convert.ToInt32(ddlBankTL.SelectedValue.ToString());
                    objAdditionalinformationBO.BankName = ddlBankTL.SelectedItem.ToString();
                    objAdditionalinformationBO.AccountNumber = txtAcNo.Text.ToString();
                    objAdditionalinformationBO.TearmLoanAmount = GetDecimalNullValue(txtTearmLoanAmount.Text.Trim().TrimStart());
                    objAdditionalinformationBO.InstallmentNo = Convert.ToInt32(txtNoOfInstallments.Text.ToString());
                    objAdditionalinformationBO.RateofInterestAmountDue = GetDecimalNullValue(txtRateofInterestAmountDue.Text.Trim().TrimStart());
                    objAdditionalinformationBO.InterestPaid = GetDecimalNullValue(txtInterstPaid.Text.Trim().TrimStart());
                    objAdditionalinformationBO.ClosingBalance = GetDecimalNullValue(txtClosingBalance.Text.Trim().TrimStart());
                    objAdditionalinformationBO.EligibleRateInterest = GetDecimalNullValue(txtEligibleRateInterest.Text.Trim().TrimStart());
                    objAdditionalinformationBO.EligibleInterest = GetDecimalNullValue(txtEligibleInterest.Text.Trim().TrimStart());

                    string Validstatus = caf.InsertISAdditionalInformationDetails(objAdditionalinformationBO);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        btnadditionalInformationAdd.Text = "Add New";
                        ViewState["AdditionalinformationId"] = "0";
                       
                        txtTearmLoanAmount.Text = "";
                        txtRateofInterestAmountDue.Text = "";
                        txtInterestDue.Text = "";
                        txtUnitHolderContribution.Text = "";
                        txtNoOfInstallments.Text = "";
                        txtEligibleRateInterest.Text = "";
                        txtEligibleInterest.Text = "";
                        txtInterstPaid.Text = "";
                        txtClosingBalance.Text = "";
                        /*ddlBankTL.SelectedValue = "0";
                         txtAcNo.Text = "";
                         */
                        ddlMonthTL1.Enabled = true;
                        /*BindMonths1(ddlFin1stOr2ndHalfyear.SelectedValue.ToString(), "H", Session["IncentiveID"].ToString(), "TermLoan1");*/
                        BindAdditionalInformationDtls(Session["IncentiveID"].ToString());
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Saved/Updated Successfully');", true);
                       /* lblmsg.Text = "Saved Successfully";
                        Failure.Visible = false;
                        success.Visible = true;*/
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        protected void btnadditionalInformationAdd2_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["AdditionalinformationId"] == null)
                {
                    ViewState["AdditionalinformationId"] = "0";
                }

                string errormsg = ValidateAdditionalInformationDtls2();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    AdditionalinformationBO objAdditionalinformationBO = new AdditionalinformationBO();

                    objAdditionalinformationBO.AdditionalinformationId = ViewState["AdditionalinformationId"].ToString();
                    objAdditionalinformationBO.TransType = "INS";
                    objAdditionalinformationBO.IncentiveId = Session["IncentiveID"].ToString();
                    objAdditionalinformationBO.Created_by = ObjLoginNewvo.uid;

                    /*objAdditionalinformationBO.AmountDueDate = GetFromatedDateDDMMYYYY(txtAmountDueDate.Text.Trim().TrimStart());
                     objAdditionalinformationBO.InterestDue = GetDecimalNullValue(txtInterestDue.Text.Trim().TrimStart());
                     objAdditionalinformationBO.UnitHolderContribution = GetDecimalNullValue(txtUnitHolderContribution.Text.Trim().TrimStart()); */

                    objAdditionalinformationBO.TermLoan = "TermLoan2";
                    objAdditionalinformationBO.MonthId = ddlMonthTL2.SelectedValue.ToString();
                    objAdditionalinformationBO.Months = ddlMonthTL2.SelectedItem.ToString();
                    objAdditionalinformationBO.BankId = Convert.ToInt32(ddlBankTL2.SelectedValue.ToString());
                    objAdditionalinformationBO.BankName = ddlBankTL2.SelectedItem.ToString();
                    objAdditionalinformationBO.AccountNumber = txtAcNo2.Text.ToString();
                    objAdditionalinformationBO.TearmLoanAmount = GetDecimalNullValue(txtTearmLoanAmount2.Text.Trim().TrimStart());
                    objAdditionalinformationBO.InstallmentNo = Convert.ToInt32(txtNoOfInstallments2.Text.ToString());
                    objAdditionalinformationBO.RateofInterestAmountDue = GetDecimalNullValue(txtRateofInterestAmountDue2.Text.Trim().TrimStart());
                    objAdditionalinformationBO.InterestPaid = GetDecimalNullValue(txtInterstPaid2.Text.Trim().TrimStart());
                    objAdditionalinformationBO.ClosingBalance = GetDecimalNullValue(txtClosingBalance2.Text.Trim().TrimStart());
                    objAdditionalinformationBO.EligibleRateInterest = GetDecimalNullValue(txtEligibleRateInterest2.Text.Trim().TrimStart());
                    objAdditionalinformationBO.EligibleInterest = GetDecimalNullValue(txtEligibleInterest2.Text.Trim().TrimStart());

                    string Validstatus = caf.InsertISAdditionalInformationDetails(objAdditionalinformationBO);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        btnadditionalInformationAdd.Text = "Add New";
                        ViewState["AdditionalinformationId"] = "0";

                        txtTearmLoanAmount2.Text = "";
                        txtRateofInterestAmountDue2.Text = "";
                        txtInterestDue2.Text = "";
                        txtUnitHolderContribution2.Text = "";
                        txtNoOfInstallments2.Text = "";
                        txtEligibleRateInterest2.Text = "";
                        txtEligibleInterest2.Text = "";
                        txtInterstPaid2.Text = "";
                        txtClosingBalance2.Text = "";
                        ddlMonthTL2.Enabled = true;
                        /* ddlBankTL2.SelectedValue = "0";
                          txtAcNo2.Text = "";
                          BindMonths2(ddlFin1stOr2ndHalfyear.SelectedValue.ToString(), "H", Session["IncentiveID"].ToString(), "TermLoan2");*/
                        BindAdditionalInformationDtls2(Session["IncentiveID"].ToString());
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Saved/Updated Successfully');", true);
                        /*lblmsg.Text = "Saved Successfully";
                        Failure.Visible = false;
                        success.Visible = true;*/
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        protected void btnadditionalInformationAdd3_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["AdditionalinformationId"] == null)
                {
                    ViewState["AdditionalinformationId"] = "0";
                }

                string errormsg = ValidateAdditionalInformationDtls3();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    AdditionalinformationBO objAdditionalinformationBO = new AdditionalinformationBO();

                    objAdditionalinformationBO.AdditionalinformationId = ViewState["AdditionalinformationId"].ToString();
                    objAdditionalinformationBO.TransType = "INS";
                    objAdditionalinformationBO.IncentiveId = Session["IncentiveID"].ToString();
                    objAdditionalinformationBO.Created_by = ObjLoginNewvo.uid;

                    /*objAdditionalinformationBO.AmountDueDate = GetFromatedDateDDMMYYYY(txtAmountDueDate.Text.Trim().TrimStart());
                     objAdditionalinformationBO.InterestDue = GetDecimalNullValue(txtInterestDue.Text.Trim().TrimStart());
                     objAdditionalinformationBO.UnitHolderContribution = GetDecimalNullValue(txtUnitHolderContribution.Text.Trim().TrimStart()); */

                    objAdditionalinformationBO.TermLoan = "TermLoan3";
                    objAdditionalinformationBO.MonthId = ddlMonthTL3.SelectedValue.ToString();
                    objAdditionalinformationBO.Months = ddlMonthTL3.SelectedItem.ToString();
                    objAdditionalinformationBO.BankId = Convert.ToInt32(ddlBankTL3.SelectedValue.ToString());
                    objAdditionalinformationBO.BankName = ddlBankTL3.SelectedItem.ToString();
                    objAdditionalinformationBO.AccountNumber = txtAcNo3.Text.ToString();
                    objAdditionalinformationBO.TearmLoanAmount = GetDecimalNullValue(txtTearmLoanAmount3.Text.Trim().TrimStart());
                    objAdditionalinformationBO.InstallmentNo = Convert.ToInt32(txtNoOfInstallments3.Text.ToString());
                    objAdditionalinformationBO.RateofInterestAmountDue = GetDecimalNullValue(txtRateofInterestAmountDue3.Text.Trim().TrimStart());
                    objAdditionalinformationBO.InterestPaid = GetDecimalNullValue(txtInterstPaid3.Text.Trim().TrimStart());
                    objAdditionalinformationBO.ClosingBalance = GetDecimalNullValue(txtClosingBalance3.Text.Trim().TrimStart());
                    objAdditionalinformationBO.EligibleRateInterest = GetDecimalNullValue(txtEligibleRateInterest3.Text.Trim().TrimStart());
                    objAdditionalinformationBO.EligibleInterest = GetDecimalNullValue(txtEligibleInterest3.Text.Trim().TrimStart());

                    string Validstatus = caf.InsertISAdditionalInformationDetails(objAdditionalinformationBO);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        btnadditionalInformationAdd.Text = "Add New";
                        ViewState["AdditionalinformationId"] = "0";

                        txtTearmLoanAmount3.Text = "";
                        txtRateofInterestAmountDue3.Text = "";
                        txtInterestDue3.Text = "";
                        txtUnitHolderContribution3.Text = "";
                        txtNoOfInstallments3.Text = "";
                        txtEligibleRateInterest3.Text = "";
                        txtEligibleInterest3.Text = "";
                        txtInterstPaid3.Text = "";
                        txtClosingBalance3.Text = "";
                        ddlMonthTL3.Enabled = true;
                        /* ddlBankTL3.SelectedValue = "0";
                           txtAcNo3.Text = "";
                           BindMonths3(ddlFin1stOr2ndHalfyear.SelectedValue.ToString(), "H", Session["IncentiveID"].ToString(), "TermLoan3");
                         */
                        BindAdditionalInformationDtls3(Session["IncentiveID"].ToString());
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Saved/Updated Successfully');", true);
                        /*lblmsg.Text = "Saved Successfully";
                        Failure.Visible = false;
                        success.Visible = true;*/
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        protected void BindAdditionalInformationDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetAdditionalInformationDtls(INCENTIVEID,"TermLoan1");

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    gvAdditionalInformation.DataSource = dsnew.Tables[0];
                    gvAdditionalInformation.DataBind();
                }
                else
                {
                    gvAdditionalInformation.DataSource = null;
                    gvAdditionalInformation.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindAdditionalInformationDtls2(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetAdditionalInformationDtls(INCENTIVEID, "TermLoan2");

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    gvAdditionalInformation2.DataSource = dsnew.Tables[0];
                    gvAdditionalInformation2.DataBind();
                }
                else
                {
                    gvAdditionalInformation2.DataSource = null;
                    gvAdditionalInformation2.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindAdditionalInformationDtls3(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetAdditionalInformationDtls(INCENTIVEID, "TermLoan3");

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    gvAdditionalInformation3.DataSource = dsnew.Tables[0];
                    gvAdditionalInformation3.DataBind();
                }
                else
                {
                    gvAdditionalInformation3.DataSource = null;
                    gvAdditionalInformation3.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetAdditionalInformationDtls(string INCENTIVEID,string TermLoan)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar),
               new SqlParameter("@TERMLOAN",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            pp[1].Value = TermLoan;
            Dsnew = caf.GenericFillDs("USP_GET_IS_ADITIONALINFORMATION_DTLS_BY_TERMLOAN", pp);
            return Dsnew;
        }

        protected void gvAdditionalInformation_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                string IncentiveId = Session["IncentiveID"].ToString();
                BindMonths1(ddlFin1stOr2ndHalfyear.SelectedValue.ToString(), "N", IncentiveId, "TermLoan1");
                ddlMonthTL1.SelectedValue= ((Label)(gr.FindControl("lblMonthId"))).Text;
                ddlBankTL.SelectedValue= ((Label)(gr.FindControl("lblBankId"))).Text;
                txtAcNo.Text= ((Label)(gr.FindControl("lblAccountNo"))).Text;
                txtTearmLoanAmount.Text = ((Label)(gr.FindControl("lblTearmLoanAmount"))).Text;
                txtNoOfInstallments.Text = ((Label)(gr.FindControl("lblInstallmentNo"))).Text;
                txtRateofInterestAmountDue.Text = ((Label)(gr.FindControl("lblRateofInterestAmountDue"))).Text;
                txtInterstPaid.Text= ((Label)(gr.FindControl("lblInterestPaid"))).Text;
                txtClosingBalance.Text = ((Label)(gr.FindControl("lblClosingBal"))).Text;
                txtEligibleRateInterest.Text = ((Label)(gr.FindControl("lblEligibleRateInterest"))).Text;
                txtEligibleInterest.Text = ((Label)(gr.FindControl("lblEligibleInterest"))).Text;

                ViewState["AdditionalinformationId"] = ((Label)(gr.FindControl("lblAdditionalinformationId"))).Text;
                ddlMonthTL1.Enabled = false;
                btnadditionalInformationAdd.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];


                AdditionalinformationBO objAdditionalinformationBO = new AdditionalinformationBO();

                objAdditionalinformationBO.AdditionalinformationId = ((Label)(gr.FindControl("lblAdditionalinformationId"))).Text;
                objAdditionalinformationBO.TransType = "DLT";
                objAdditionalinformationBO.IncentiveId = Session["IncentiveID"].ToString();
                objAdditionalinformationBO.Created_by = ObjLoginNewvo.uid;


                string Validstatus = caf.InsertISAdditionalInformationDetails(objAdditionalinformationBO);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnadditionalInformationAdd.Text = "Add New";
                    ViewState["AdditionalinformationId"] = "0";


                    txtTearmLoanAmount.Text = "";
                    txtRateofInterestAmountDue.Text = "";
                    txtInterestDue.Text = "";
                    txtUnitHolderContribution.Text = "";
                    txtNoOfInstallments.Text = "";
                    txtEligibleRateInterest.Text = "";
                    txtEligibleInterest.Text = "";
                    txtInterstPaid.Text = "";
                    txtAcNo.Text = "";
                    txtClosingBalance.Text = "";
                    ddlBankTL.SelectedValue = "0";

                    BindAdditionalInformationDtls(Session["IncentiveID"].ToString());

                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }
        protected void gvAdditionalInformation2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                string IncentiveId = Session["IncentiveID"].ToString();
                BindMonths2(ddlFin1stOr2ndHalfyear.SelectedValue.ToString(), "N", IncentiveId, "TermLoan2");
                ddlMonthTL2.SelectedValue = ((Label)(gr.FindControl("lblMonthId"))).Text;
                ddlBankTL2.SelectedValue = ((Label)(gr.FindControl("lblBankId"))).Text;
                txtAcNo2.Text = ((Label)(gr.FindControl("lblAccountNo"))).Text;
                txtTearmLoanAmount2.Text = ((Label)(gr.FindControl("lblTearmLoanAmount"))).Text;
                txtNoOfInstallments2.Text = ((Label)(gr.FindControl("lblInstallmentNo"))).Text;
                txtRateofInterestAmountDue2.Text = ((Label)(gr.FindControl("lblRateofInterestAmountDue"))).Text;
                txtInterstPaid2.Text = ((Label)(gr.FindControl("lblInterestPaid"))).Text;
                txtClosingBalance2.Text = ((Label)(gr.FindControl("lblClosingBal"))).Text;
                txtEligibleRateInterest2.Text = ((Label)(gr.FindControl("lblEligibleRateInterest"))).Text;
                txtEligibleInterest2.Text = ((Label)(gr.FindControl("lblEligibleInterest"))).Text;

                ViewState["AdditionalinformationId"] = ((Label)(gr.FindControl("lblAdditionalinformationId"))).Text;
                ddlMonthTL2.Enabled = false;
                btnadditionalInformationAdd2.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];


                AdditionalinformationBO objAdditionalinformationBO = new AdditionalinformationBO();

                objAdditionalinformationBO.AdditionalinformationId = ((Label)(gr.FindControl("lblAdditionalinformationId"))).Text;
                objAdditionalinformationBO.TransType = "DLT";
                objAdditionalinformationBO.IncentiveId = Session["IncentiveID"].ToString();
                objAdditionalinformationBO.Created_by = ObjLoginNewvo.uid;


                string Validstatus = caf.InsertISAdditionalInformationDetails(objAdditionalinformationBO);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnadditionalInformationAdd.Text = "Add New";
                    ViewState["AdditionalinformationId"] = "0";

                    txtTearmLoanAmount2.Text = "";
                    txtRateofInterestAmountDue2.Text = "";
                    txtInterestDue2.Text = "";
                    txtUnitHolderContribution2.Text = "";
                    txtNoOfInstallments2.Text = "";
                    txtEligibleRateInterest2.Text = "";
                    txtEligibleInterest2.Text = "";
                    txtInterstPaid2.Text = "";
                    txtAcNo2.Text = "";
                    txtClosingBalance2.Text = "";
                    ddlBankTL2.SelectedValue = "0";

                    BindAdditionalInformationDtls2(Session["IncentiveID"].ToString());

                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }
        protected void gvAdditionalInformation3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                string IncentiveId = Session["IncentiveID"].ToString();
                BindMonths3(ddlFin1stOr2ndHalfyear.SelectedValue.ToString(), "N", IncentiveId, "TermLoan3");
                ddlMonthTL3.SelectedValue = ((Label)(gr.FindControl("lblMonthId"))).Text;
                ddlBankTL3.SelectedValue = ((Label)(gr.FindControl("lblBankId"))).Text;
                txtAcNo3.Text = ((Label)(gr.FindControl("lblAccountNo"))).Text;
                txtTearmLoanAmount3.Text = ((Label)(gr.FindControl("lblTearmLoanAmount"))).Text;
                txtNoOfInstallments3.Text = ((Label)(gr.FindControl("lblInstallmentNo"))).Text;
                txtRateofInterestAmountDue3.Text = ((Label)(gr.FindControl("lblRateofInterestAmountDue"))).Text;
                txtInterstPaid3.Text = ((Label)(gr.FindControl("lblInterestPaid"))).Text;
                txtClosingBalance3.Text = ((Label)(gr.FindControl("lblClosingBal"))).Text;
                txtEligibleRateInterest3.Text = ((Label)(gr.FindControl("lblEligibleRateInterest"))).Text;
                txtEligibleInterest3.Text = ((Label)(gr.FindControl("lblEligibleInterest"))).Text;

                ViewState["AdditionalinformationId"] = ((Label)(gr.FindControl("lblAdditionalinformationId"))).Text;
                ddlMonthTL3.Enabled = false;
                btnadditionalInformationAdd3.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];


                AdditionalinformationBO objAdditionalinformationBO = new AdditionalinformationBO();

                objAdditionalinformationBO.AdditionalinformationId = ((Label)(gr.FindControl("lblAdditionalinformationId"))).Text;
                objAdditionalinformationBO.TransType = "DLT";
                objAdditionalinformationBO.IncentiveId = Session["IncentiveID"].ToString();
                objAdditionalinformationBO.Created_by = ObjLoginNewvo.uid;


                string Validstatus = caf.InsertISAdditionalInformationDetails(objAdditionalinformationBO);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnadditionalInformationAdd.Text = "Add New";
                    ViewState["AdditionalinformationId"] = "0";

                    txtTearmLoanAmount3.Text = "";
                    txtRateofInterestAmountDue3.Text = "";
                    txtInterestDue3.Text = "";
                    txtUnitHolderContribution3.Text = "";
                    txtNoOfInstallments3.Text = "";
                    txtEligibleRateInterest3.Text = "";
                    txtEligibleInterest3.Text = "";
                    txtInterstPaid3.Text = "";
                    txtAcNo3.Text = "";
                    txtClosingBalance3.Text = "";
                    ddlBankTL3.SelectedValue = "0";

                    BindAdditionalInformationDtls3(Session["IncentiveID"].ToString());

                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }
        public string ValidateTTLRControls()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (ddlbankTotalrepaid.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Bank\\n";
                slno = slno + 1;
            }
            if (txtInstallments.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Total No of Installments\\n";
                slno = slno + 1;
            }
            if (txtInstallmentAmount.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Installment Amount (Rs.)\\n";
                slno = slno + 1;
            }
            if (txtTotalAmountRepaid.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Total Amount Repaid (Interest + Principal) (Rs.)\\n";
                slno = slno + 1;
            }
            return ErrorMsg;
        }
        public void clearTTLRControls()
        {
            ddlBankrepaid.SelectedValue = "0";
            txtInstallments.Text = "";
            txtInstallmentAmount.Text = "";
            txtTotalAmountRepaid.Text = "";
        }
        protected void btnTotalLoanAmountRepayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["TTLRId"] == null)
                {
                    ViewState["TTLRId"] = "0";
                }

                string errormsg = ValidateTTLRControls();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    TotalTermLoanRepaid tlr = new TotalTermLoanRepaid();
                    tlr.TTLRId = Convert.ToInt32(ViewState["TTLRId"].ToString());
                    tlr.IncentiveId = Convert.ToInt32(Session["IncentiveID"].ToString());
                    tlr.SubIncentiveId = 3;
                    tlr.BankId = Convert.ToInt32(ddlbankTotalrepaid.SelectedValue);
                    tlr.BankName = ddlbankTotalrepaid.SelectedItem.Text;
                    tlr.TotalNoofInstallments = txtInstallments.Text.Trim().TrimStart();
                    tlr.InstallmentAmount = Convert.ToDecimal(GetDecimalNullValue(txtInstallmentAmount.Text));
                    tlr.TotalAmountRepaid = Convert.ToDecimal(GetDecimalNullValue(txtTotalAmountRepaid.Text));

                    tlr.Created_by = ObjLoginNewvo.uid;
                    tlr.TransType = "INS";

                    string Validstatus = caf.InsertTotalTermLoanRepaid(tlr);
                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        clearTTLRControls();
                        BindTotalTermLoanRepaid(0, Convert.ToInt32(Session["IncentiveID"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        public void BindTotalTermLoanRepaid(int TTLRId, int IncentiveId)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = GetTotalTermLoanRepaid(TTLRId, IncentiveId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdTotalTermLoanRepaid.DataSource = ds.Tables[0];
                    grdTotalTermLoanRepaid.DataBind();
                }
                else
                {
                    grdTotalTermLoanRepaid.DataSource = null;
                    grdTotalTermLoanRepaid.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetTotalTermLoanRepaid(int TTLRId, int IncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@TLRId",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = TTLRId;
            Dsnew = caf.GenericFillDs("USP_GET_TOTALTERMLOANREPAID", pp);
            return Dsnew;
        }

        protected void grdTotalTermLoanRepaid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                ddlbankTotalrepaid.SelectedValue = ((Label)(gr.FindControl("lblbankidrp"))).Text;
                txtInstallments.Text = ((Label)(gr.FindControl("lblTermLoanInstallments"))).Text;
                txtInstallmentAmount.Text = ((Label)(gr.FindControl("lblInstallmentAmount"))).Text;
                txtTotalAmountRepaid.Text = ((Label)(gr.FindControl("lblTotalAmountRepaid"))).Text;

                ViewState["TTLRId"] = ((Label)(gr.FindControl("lblTTLRId"))).Text;
                btnTotalLoanAmountRepayment.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                TotalTermLoanRepaid tlr = new TotalTermLoanRepaid();

                tlr.TTLRId = Convert.ToInt32(((Label)(gr.FindControl("lblTTLRId"))).Text);
                tlr.TransType = "DLT";
                tlr.IncentiveId = Convert.ToInt32(Session["IncentiveID"].ToString());
                tlr.Created_by = ObjLoginNewvo.uid;

                string Validstatus = caf.InsertTotalTermLoanRepaid(tlr);

                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnTotalLoanAmountRepayment.Text = "Add New";
                    ViewState["TTLRId"] = "0";

                    clearTTLRControls();
                    BindTotalTermLoanRepaid(0, Convert.ToInt32(Session["IncentiveID"].ToString()));

                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }
        public string MoratoriumValidateDtls()
        {
            int slno = 1;
            string ErrorMsg = "";


            if (ddlCCPType.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Financial Half Year \\n";
                slno = slno + 1;
            }
            if (txtCCPFrom.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Total Amount(In Rupees) \\n";
                slno = slno + 1;
            }
            if (txtCCPTo.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Total Amount(In Rupees) \\n";
                slno = slno + 1;
            }
            if (txtMoratoriumRateOfInterest.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Moratorium Rate Of Interest(In Rupees) \\n";
                slno = slno + 1;
            }
            if (ddlMoratoriumBank.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Bank \\n";
                slno = slno + 1;
            }

            if (txtCCPFrom.Text.Trim().TrimStart() != "" && txtCCPTo.Text.Trim().TrimStart() != "")
            {
                DateTime date1 = Convert.ToDateTime(GetFromatedDateDDMMYYYY(txtCCPFrom.Text.Trim().TrimStart()));
                DateTime date2 = Convert.ToDateTime(GetFromatedDateDDMMYYYY(txtCCPTo.Text.Trim().TrimStart()));
                TimeSpan days = date2 - date1;
                int TDays = days.Days;
                if (TDays > 183)
                {
                    ErrorMsg = ErrorMsg + slno + ". You selected more than Half Year.Please correct your Dates.\\n";
                    slno = slno + 1;
                }
                if (date1 < date2)
                {
                    int Year = date1.Year;
                    if (ddlFin1stOr2ndHalfyear.SelectedValue == "1")
                    {

                        DateTime date3 = Convert.ToDateTime(Year.ToString() + "/" + "04/01");
                        DateTime date4 = Convert.ToDateTime(Year.ToString() + "/" + "09/30");

                        if (date3 >= date1 && date4 <= date2)
                        {

                        }
                        else
                        {
                            ErrorMsg = ErrorMsg + slno + ". Moratorium From date should be in between April 1st to September 30th (1st Half Year)\\n";
                            slno = slno + 1;
                        }
                        /*if (date3 >= date1 && date4 <= date1)
                        {

                        }
                        else
                        {
                            ErrorMsg = ErrorMsg + slno + ". Moratorium From date should be in between April 1st to September 30th (1st Half Year)\\n";
                            slno = slno + 1;
                        }
                        if (date3 >= date2 && date4 <= date2)
                        {

                        }
                        else
                        {
                            ErrorMsg = ErrorMsg + slno + ". Moratorium To date should be in between April 1st to September 30th (1st Half Year)\\n";
                            slno = slno + 1;
                        }*/
                    }
                    if (ddlFin1stOr2ndHalfyear.SelectedValue == "2")
                    {
                        DateTime date3, date4;
                        int Year1 = date1.Year;
                        int Year2 = date2.Year;

                        int Month1 = date1.Month;
                        int Month2 = date1.Month;

                        if (Year1 == Year2 && Month1 >= 1 && Month1 <= 3)
                        {
                            date3 = Convert.ToDateTime((Year - 1).ToString() + "/" + "10/01");
                            date4 = Convert.ToDateTime((Year).ToString() + "/" + "03/31");
                        }
                        else if (Year1 == Year2 && Month1 >= 10)
                        {
                            date3 = Convert.ToDateTime((Year).ToString() + "/" + "10/01");
                            date4 = Convert.ToDateTime((Year + 1).ToString() + "/" + "03/31");
                        }
                        else
                        {
                            date3 = Convert.ToDateTime((Year).ToString() + "/" + "10/01");
                            date4 = Convert.ToDateTime((Year + 1).ToString() + "/" + "03/31");
                        }

                        if (date3 >= date1 && date4 <= date2)
                        {

                        }
                        else
                        {
                            ErrorMsg = ErrorMsg + slno + ". Moratorium From date should be in between October 1st to March 31st (2nd Half Year)\\n";
                            slno = slno + 1;
                        }
                       /* if (date3 >= date2 && date4 <= date2)
                        {

                        }
                        else
                        {
                            ErrorMsg = ErrorMsg + slno + ". Moratorium To date should be in between October 1st to March 31st (2nd Half Year)\\n";
                            slno = slno + 1;
                        }*/
                    }
                }
                else
                {
                    ErrorMsg = ErrorMsg + slno + ". Moratorium From date should not be greater then To Date \\n";
                    slno = slno + 1;
                }
            }

            return ErrorMsg;
        }
        protected void btnMoratoriumPeriodAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["MoratoriumPeriod_ID"] == null)
                {
                    ViewState["MoratoriumPeriod_ID"] = "0";
                }

                string errormsg = MoratoriumValidateDtls();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    MoratoriumPeriodBO objMoratoriumPeriodBO = new MoratoriumPeriodBO();

                    objMoratoriumPeriodBO.MoratoriumPeriod_ID = ViewState["MoratoriumPeriod_ID"].ToString();
                    objMoratoriumPeriodBO.TransType = "INS";
                    objMoratoriumPeriodBO.IncentiveId = Session["IncentiveID"].ToString();
                    objMoratoriumPeriodBO.Created_by = ObjLoginNewvo.uid;

                    objMoratoriumPeriodBO.TypeOfFinancialYear = ddlCCPType.SelectedValue;
                    objMoratoriumPeriodBO.TypeOfFinancialYearText = ddlCCPType.SelectedItem.Text;

                    objMoratoriumPeriodBO.RateofInterest = GetDecimalNullValue(txtMoratoriumRateOfInterest.Text.TrimStart().TrimEnd());
                    objMoratoriumPeriodBO.FromDate = GetFromatedDateDDMMYYYY(txtCCPFrom.Text.TrimStart().TrimEnd());
                    objMoratoriumPeriodBO.Todate = GetFromatedDateDDMMYYYY(txtCCPTo.Text.TrimStart().TrimEnd());
                    objMoratoriumPeriodBO.BankID = ddlMoratoriumBank.SelectedValue;

                    string Validstatus = caf.InsertISMoratoriumPeriodDetails(objMoratoriumPeriodBO);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        btnMoratoriumPeriodAdd.Text = "Add New";
                        ViewState["MoratoriumPeriod_ID"] = "0";

                        ddlMoratoriumBank.SelectedValue = "0";
                        ddlFin1stOr2ndHalfyear.SelectedValue = "0";
                        txtCCPFrom.Text = "";
                        txtCCPTo.Text = "";
                        txtMoratoriumRateOfInterest.Text = "";

                        BindMoratoriumPeriodDetails(0, Convert.ToInt32(Session["IncentiveID"].ToString()));
                        lblmsg.Text = "Saved Successfully";
                        Failure.Visible = false;
                        success.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        public void BindMoratoriumPeriodDetails(int MoratoriumPeriod_ID, int IncentiveId)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = GetMoratoriumPeriodDetails(MoratoriumPeriod_ID, IncentiveId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    GvMoratoriumPeriod.DataSource = ds.Tables[0];
                    GvMoratoriumPeriod.DataBind();
                }
                else
                {
                    GvMoratoriumPeriod.DataSource = null;
                    GvMoratoriumPeriod.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetMoratoriumPeriodDetails(int MoratoriumPeriod_ID, int IncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@MoratoriumPeriod_ID",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = MoratoriumPeriod_ID;
            Dsnew = caf.GenericFillDs("USP_GET_MORATORIUM_PERIOD_DTLS", pp);
            return Dsnew;
        }

        protected void GvMoratoriumPeriod_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {

                ddlCCPType.SelectedValue = ((Label)(gr.FindControl("lblTypeOfFinancialYear"))).Text;
                ddlMoratoriumBank.SelectedValue = ((Label)(gr.FindControl("lblbankidrp"))).Text;

                txtCCPFrom.Text = ((Label)(gr.FindControl("lblFromDate"))).Text;
                txtCCPTo.Text = ((Label)(gr.FindControl("lblToDate"))).Text;

                txtMoratoriumRateOfInterest.Text = ((Label)(gr.FindControl("lblMoratoriumRateOfInterest"))).Text;

                ViewState["MoratoriumPeriod_ID"] = ((Label)(gr.FindControl("lblMoratoriumPeriod_ID"))).Text;
                btnMoratoriumPeriodAdd.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];


                MoratoriumPeriodBO objMoratoriumPeriodBO = new MoratoriumPeriodBO();

                objMoratoriumPeriodBO.MoratoriumPeriod_ID = ((Label)(gr.FindControl("lblMoratoriumPeriod_ID"))).Text;
                objMoratoriumPeriodBO.TransType = "DLT";
                objMoratoriumPeriodBO.IncentiveId = Session["IncentiveID"].ToString();
                objMoratoriumPeriodBO.Created_by = ObjLoginNewvo.uid;


                string Validstatus = caf.InsertISMoratoriumPeriodDetails(objMoratoriumPeriodBO);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnMoratoriumPeriodAdd.Text = "Add New";
                    ViewState["MoratoriumPeriod_ID"] = "0";

                    ddlMoratoriumBank.SelectedValue = "0";
                    ddlFin1stOr2ndHalfyear.SelectedValue = "0";
                    txtCCPFrom.Text = "";
                    txtCCPTo.Text = "";
                    txtMoratoriumRateOfInterest.Text = "";

                    BindMoratoriumPeriodDetails(0, Convert.ToInt32(Session["IncentiveID"].ToString()));

                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }

        protected void ddlFin1stOr2ndHalfyear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string IncentiveId = Session["IncentiveID"].ToString();
            BindMonths1(ddlFin1stOr2ndHalfyear.SelectedValue.ToString(),"H", IncentiveId, "TermLoan1");
            BindMonths2(ddlFin1stOr2ndHalfyear.SelectedValue.ToString(), "H", IncentiveId, "TermLoan2");
            BindMonths3(ddlFin1stOr2ndHalfyear.SelectedValue.ToString(), "H", IncentiveId, "TermLoan3");
        }

        protected void rbtnMoratoriumYesNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtnMoratoriumYesNo.SelectedValue == "1")
            {
                DivMoratoriumPeriod.Visible = true;
                GvMoratoriumPeriod.Visible = true;
            }
            else
            {
                DivMoratoriumPeriod.Visible = false;
                GvMoratoriumPeriod.Visible = false;
            }
        }
        protected void rbtnOtherAgency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtnOtherAgency.SelectedValue == "1")
            {
                divOtherAgency.Visible = true;
            }
            else
            {
                divOtherAgency.Visible = false;
            }
        }

        protected void gvAdditionalInformation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "EligibleInterest").ToString() != "" && DataBinder.Eval(e.Row.DataItem, "EligibleInterest").ToString() != null)
                {
                    decimal EligibleInterest11 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EligibleInterest"));
                    EligibleInterest1 = EligibleInterest11 + EligibleInterest1;
                    hdnTerm1Amount.Value = EligibleInterest1.ToString();
                    txtCCA.Text = (Convert.ToDecimal(hdnTerm1Amount.Value) + Convert.ToDecimal(hdnTerm2Amount.Value) + Convert.ToDecimal(hdnTerm3Amount.Value)).ToString();
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[10].Text = "Total";
                e.Row.Cells[11].Text = EligibleInterest1.ToString();
            }

        }

        protected void gvAdditionalInformation2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "EligibleInterest").ToString() != "" && DataBinder.Eval(e.Row.DataItem, "EligibleInterest").ToString() != null)
                {
                    decimal EligibleInterest21 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EligibleInterest"));
                    EligibleInterest2 = EligibleInterest21 + EligibleInterest2;
                    hdnTerm2Amount.Value = EligibleInterest2.ToString();
                    txtCCA.Text = (Convert.ToDecimal(hdnTerm1Amount.Value) + Convert.ToDecimal(hdnTerm2Amount.Value) + Convert.ToDecimal(hdnTerm3Amount.Value)).ToString();
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[10].Text = "Total";
                e.Row.Cells[11].Text = EligibleInterest2.ToString();
            }
        }

        protected void gvAdditionalInformation3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "EligibleInterest").ToString() != "" && DataBinder.Eval(e.Row.DataItem, "EligibleInterest").ToString() != null)
                {
                    decimal EligibleInterest31 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EligibleInterest"));
                    EligibleInterest3 = EligibleInterest31 + EligibleInterest3;
                    hdnTerm3Amount.Value = EligibleInterest3.ToString();
                    txtCCA.Text = (Convert.ToDecimal(hdnTerm1Amount.Value) + Convert.ToDecimal(hdnTerm2Amount.Value) + Convert.ToDecimal(hdnTerm3Amount.Value)).ToString();
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[10].Text = "Total";
                e.Row.Cells[11].Text = EligibleInterest3.ToString();
            }
        }

        protected void ddlAccountsNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAccountsNo.SelectedValue == "1")
            {
                txtAccountNo.Text = "";
                txtAccountNo.Enabled = true;
            }
            else
            {
                txtAccountNo.Text = "Multiple Accounts";
                txtAccountNo.Enabled = false;
            }

        }
        //public void BindClaimFinancialYears(DropDownList ddl, string Count, string incentiveid, string SubIncentiveID)
        //{
        //    ViewState["ClaimFinancialYears"] = null;
        //    DataSet dsYears = new DataSet();
        //    ddl.Items.Clear();
        //    dsYears = caf.GetClaimFinancialYear(Count, incentiveid, SubIncentiveID);
        //    if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
        //    {
        //        ViewState["ClaimFinancialYears"] = dsYears;
        //        ddl.DataSource = dsYears.Tables[0];
        //        ddl.DataTextField = "FinancialYear";
        //        ddl.DataValueField = "FID";
        //        ddl.DataBind();
        //    }
        //    AddSelect(ddl);
        //}

        //protected void ddlFinYear_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    bindFin1stOr2ndHalfyear();
        //    DataSet dsYears = new DataSet();
        //    dsYears = (DataSet)ViewState["ClaimFinancialYears"];
        //    if (ddlFinYear.SelectedValue != "0")
        //    {
        //        if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
        //        {
        //            DataRow[] drs = dsYears.Tables[0].Select("FID = " + ddlFinYear.SelectedValue + " and F_HALFYEAR='Y'");
        //            if (drs.Length > 0)
        //            {
        //                int Itemindex = ddlFin1stOr2ndHalfyear.Items.IndexOf(ddlFin1stOr2ndHalfyear.Items.FindByValue("1"));
        //                ddlFin1stOr2ndHalfyear.Items.RemoveAt(Itemindex);
        //            }

        //            DataRow[] drs1 = dsYears.Tables[0].Select("FID = " + ddlFinYear.SelectedValue + " and S_HALFYEAR='Y'");
        //            if (drs1.Length > 0)
        //            {
        //                int Itemindex = ddlFin1stOr2ndHalfyear.Items.IndexOf(ddlFin1stOr2ndHalfyear.Items.FindByValue("2"));
        //                ddlFin1stOr2ndHalfyear.Items.RemoveAt(Itemindex);
        //            }
        //        }
        //    }
        //}

        //private void bindFin1stOr2ndHalfyear()
        //{
        //    DataTable dt = new DataTable();

        //    dt.Columns.Add("ID", typeof(string));
        //    dt.Columns.Add("Fin1stOr2ndHalfyear", typeof(string));

        //    DataRow _1st = dt.NewRow();
        //    _1st["ID"] = "1";
        //    _1st["Fin1stOr2ndHalfyear"] = "1st half Year";
        //    dt.Rows.Add(_1st);

        //    DataRow _2nd = dt.NewRow();
        //    _2nd["ID"] = "2";
        //    _2nd["Fin1stOr2ndHalfyear"] = "2nd half Year";
        //    dt.Rows.Add(_2nd);

        //    ddlFin1stOr2ndHalfyear.Items.Clear();
        //    ddlFin1stOr2ndHalfyear.DataSource = dt;
        //    ddlFin1stOr2ndHalfyear.DataTextField = "Fin1stOr2ndHalfyear";
        //    ddlFin1stOr2ndHalfyear.DataValueField = "ID";
        //    ddlFin1stOr2ndHalfyear.DataBind();
        //    AddSelect(ddlFin1stOr2ndHalfyear);
        //}
    }
}