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


namespace TTAP.UI.Pages.Annexures
{
    public partial class frmInterestSubsidyAnnexureNew : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        CAFClass ObjCAFClass = new CAFClass();
        General Gen = new General();
        decimal InterestAmountPaid = 0;
        decimal SanctionedAmount = 0;
        decimal EligibleInterest = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IncentiveID"] != null)
            {
                string IncentiveID = Request.QueryString["IncentiveID"].ToString();

                BindTermLoanAvailed(0, Convert.ToInt32(IncentiveID));
                BindTermLoanRepaid(0, Convert.ToInt32(IncentiveID));
                BindInterestSubsidy("0", Convert.ToInt32(IncentiveID));
                BindTotalTermLoanRepaid(0, Convert.ToInt32(IncentiveID));
                GetIncetiveAttachements(IncentiveID, "N", "3");
            }
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

                    //grdTermLoanRepaid2.DataSource = ds.Tables[0];
                    //grdTermLoanRepaid2.DataBind();

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
        public DataSet GetTermLoanRepaid(int TLRId, int IncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@TLRId",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = TLRId;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_TERMLOANREPAID", pp);
            return Dsnew;
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
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_TERMLOANAVAILED", pp);
            return Dsnew;
        }
        public DataSet GetTermLoanDtlsDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_TERMLOAN_DTLS", pp);
            return Dsnew;
        }
        protected void BindTearmLoanDtls(string INCENTIVEID)
        {
            try
            {
                GVTermLoandtls.DataSource = null;
                GVTermLoandtls.DataBind();

                GVTermLoandtls2.DataSource = null;
                GVTermLoandtls2.DataBind();

                DataSet dsnew = new DataSet();
                dsnew = GetTermLoanDtlsDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    GVTermLoandtls.DataSource = dsnew.Tables[0];
                    GVTermLoandtls.DataBind();

                    GVTermLoandtls2.DataSource = dsnew.Tables[0];
                    GVTermLoandtls2.DataBind();
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
        public void BindInterestSubsidy(string uid, int IncentiveID)
        {
            DataSet ds = new DataSet();
            DataSet dsnew = new DataSet();
            dsnew = GetapplicationDtls(uid, IncentiveID);
            if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
            {
                txtUnitName.InnerHtml = dsnew.Tables[0].Rows[0]["UnitName"].ToString();
                lblTSIPassUIDNumber.InnerText = dsnew.Tables[0].Rows[0]["Uid_NO"].ToString();
                lblCommonApplicationNumber.InnerText = dsnew.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                lblTypeofApplicant.InnerText = dsnew.Tables[0].Rows[0]["TypeOfIndustryText"].ToString();


                lblCategoryofUnit.InnerText = dsnew.Tables[0].Rows[0]["Category"].ToString();
                lblActivityoftheUnit.InnerText = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();

                lblAddress.InnerText = dsnew.Tables[0].Rows[0]["UnitTotalAddress"].ToString();
                lblProprietor.InnerText = dsnew.Tables[0].Rows[0]["AuthorisedPerson"].ToString();
                lblOrganization.InnerText = dsnew.Tables[0].Rows[0]["ConstitutionUnit"].ToString();
                lblSocialStatus.InnerText = dsnew.Tables[0].Rows[0]["SocialStatusText"].ToString();
                lblRegistrationNumber.InnerText = dsnew.Tables[0].Rows[0]["IncorpRegistranNumber"].ToString();
                lblTypeofSector.InnerText = "Textiles";
                lblTypeofTextile.InnerText = dsnew.Tables[0].Rows[0]["TypeofTexttileText"].ToString();
                lblTechnicalTextileType.InnerText = dsnew.Tables[0].Rows[0]["TechnicalTextile"].ToString();
                lblPowerConnectionReleaseDate.InnerText = dsnew.Tables[0].Rows[0]["NewPowerReleaseDate"].ToString();
                lblApplicationDt.InnerText = dsnew.Tables[0].Rows[0]["SubmissionDate"].ToString();

                BindTearmLoanDtls(IncentiveID.ToString());


                string TypeOfIndustry = dsnew.Tables[0].Rows[0]["TypeOfIndustry"].ToString();
                string TextileProcessName = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();
                ddlindustryStatus(TypeOfIndustry.Trim().TrimStart().TrimEnd(), TextileProcessName);
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

                txtlandexisting.InnerHtml = dsnew.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString();
                txtlandcapacity.InnerHtml = dsnew.Tables[0].Rows[0]["ExpansionDiversificationLand"].ToString();
                txtlandpercentage.InnerHtml = dsnew.Tables[0].Rows[0]["LandFixedCapitalInvestPercentage"].ToString();

                txtbuildingexisting.InnerHtml = dsnew.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString();
                txtbuildingcapacity.InnerHtml = dsnew.Tables[0].Rows[0]["ExpDiversBuilding"].ToString();
                txtbuildingpercentage.InnerHtml = dsnew.Tables[0].Rows[0]["BuildingFixedCapitalInvestPercentage"].ToString();

                txtplantexisting.InnerHtml = dsnew.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString();
                txtplantcapacity.InnerHtml = dsnew.Tables[0].Rows[0]["ExpDiversPlantMachinery"].ToString();
                txtplantpercentage.InnerHtml = dsnew.Tables[0].Rows[0]["PlantMachFixedCapitalInvestPercentage"].ToString();

                CalculatationEnterprise1("1");
                CalculatationEnterprise1("2");
                CalculatationEnterprise1("3");

                txtcurrInvLandValue.InnerHtml = dsnew.Tables[0].Rows[0]["CurrentInvestmentLandvalue"].ToString();
                txtcurrInvBuldvalue.InnerHtml = dsnew.Tables[0].Rows[0]["CurrentInvestmentBuildingvalue"].ToString();
                txtcurrInvplantMechValue.InnerHtml = dsnew.Tables[0].Rows[0]["CurrentInvestmentplantMechValue"].ToString();
                txtcurrentInvothers.InnerHtml = dsnew.Tables[0].Rows[0]["CurrentInvestmentOtherValue"].ToString();

                txtExpansionLandValue.InnerHtml = dsnew.Tables[0].Rows[0]["ActualLandvalue"].ToString();
                txtExpansionBuildingValue.InnerHtml = dsnew.Tables[0].Rows[0]["ActualBuildingValue"].ToString();
                txtExpansionplantMechValue.InnerHtml = dsnew.Tables[0].Rows[0]["ActualPMValue"].ToString();
                txtExpansionInvothers.InnerHtml = dsnew.Tables[0].Rows[0]["ActualOtherValue"].ToString();

                CalculateCurrInvTot(TypeOfIndustry);

            }
            try
            {
                ds = GetInterestSubsidy(IncentiveID);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    //txtCCPFrom.InnerHtml ="From Date : " + ds.Tables[0].Rows[0]["CCP_From"].ToString() + " <br/>To Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: " + ds.Tables[0].Rows[0]["CCP_To"].ToString() + " <br/>Half Year&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: " + ds.Tables[0].Rows[0]["CCP_TypeTEXT"].ToString();
                    txtCCA.InnerHtml = ds.Tables[0].Rows[0]["CCA"].ToString();

                    if (ds.Tables[0].Rows[0]["IsOtherAgency"].ToString() == "1")
                    {
                        lblAgency.Text = "Yes";
                        txtAmountAvailed.InnerHtml = ds.Tables[0].Rows[0]["AmountAvailed"].ToString();
                        txtSanctionOrderNo.InnerHtml = ds.Tables[0].Rows[0]["SanctionOrderNo"].ToString();
                        txtDateAvailed.InnerHtml = ds.Tables[0].Rows[0]["DateAvailedDDMMYY"].ToString();
                        trGO2.Visible = true; trGO3.Visible = true; trGO4.Visible = true;
                    }
                    else
                    {
                        lblAgency.Text = "No";
                    }
                    if (ds.Tables[0].Rows[0]["IsMoratorium"].ToString() == "1")
                    {
                        lblMoratorium.Text = "Yes";
                        trMoratoriumGrid.Visible = true;
                    }
                    else
                    {
                        lblMoratorium.Text = "No";
                    }
                    
                    // ddlCCPType.InnerHtml = ds.Tables[0].Rows[0]["CCP_TypeTEXT"].ToString();

                    BindISCrrentClaimPeriodDtls(IncentiveID.ToString());
                    BindAdditionalInformationDtls(IncentiveID.ToString());
                    BindMoratoriumPeriodDetails(0, IncentiveID);
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
        protected void ddlindustryStatus(string SelectedValue, string TextileProcessName)
        {
            try
            {
                if (SelectedValue == "1")
                {

                    // Investment 

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



                    thExistingActual.Visible = false;
                    thExistingLandActual.Visible = false;
                    thExistingBuildingActual.Visible = false;
                    thExistingPMActual.Visible = false;
                    thExistingOthersActual.Visible = false;
                    thExistingTotalActual.Visible = false;

                    trActualCapitalexpnPercent.Visible = false;
                    thExpansionLandActualPer.Visible = false;
                    thExpansionBuildingPer.Visible = false;
                    thExpansionPMPer.Visible = false;
                    thExpansionOthersPer.Visible = false;
                    thExpansionTotalPer.Visible = false;


                    thExpansionActual.InnerHtml = "New Enterprise Value (in Rs.)";
                    // Power
                    //ddlIspowApplicable_SelectedIndexChanged(sender, e);
                }
                else if (SelectedValue == "2")
                {

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

                    trFixedCapitalexpansion.InnerHtml = "Expansion Enterprise Value (in Rs.)";
                    trFixedCapitalexpnPercent.InnerHtml = "% of Increase Under Expansion Enterprise";


                    thExistingActual.Visible = true;
                    thExistingLandActual.Visible = true;
                    thExistingBuildingActual.Visible = true;
                    thExistingPMActual.Visible = true;
                    thExistingOthersActual.Visible = true;
                    thExistingTotalActual.Visible = true;

                    trActualCapitalexpnPercent.Visible = true;
                    thExpansionLandActualPer.Visible = true;
                    thExpansionBuildingPer.Visible = true;
                    thExpansionPMPer.Visible = true;
                    thExpansionOthersPer.Visible = true;
                    thExpansionTotalPer.Visible = true;

                    thExpansionActual.InnerHtml = "Expansion Enterprise Value (in Rs.)";
                    trActualCapitalexpnPercent.InnerHtml = "% of Increase Under Expansion Enterprise";
                }
                else if (SelectedValue == "3" || SelectedValue == "4")
                {

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
                    // Power
                    //ddlIspowApplicable_SelectedIndexChanged(sender, e);

                    thExistingActual.Visible = true;
                    thExistingLandActual.Visible = true;
                    thExistingBuildingActual.Visible = true;
                    thExistingPMActual.Visible = true;
                    thExistingOthersActual.Visible = true;
                    thExistingTotalActual.Visible = true;

                    trActualCapitalexpnPercent.Visible = true;
                    thExpansionLandActualPer.Visible = true;
                    thExpansionBuildingPer.Visible = true;
                    thExpansionPMPer.Visible = true;
                    thExpansionOthersPer.Visible = true;
                    thExpansionTotalPer.Visible = true;

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
        public void CalculateCurrInvTot(string TypeOfIndustry)
        {
            if (TypeOfIndustry == "1")
            {
                // based on entry
                decimal ExpansionLandValue = Convert.ToDecimal(GetDecimalNullValue(txtExpansionLandValue.InnerHtml.Trim().TrimStart()));
                decimal ExpansionBuildingValue = Convert.ToDecimal(GetDecimalNullValue(txtExpansionBuildingValue.InnerHtml.Trim().TrimStart()));
                decimal ExpansionplantMechValue = Convert.ToDecimal(GetDecimalNullValue(txtExpansionplantMechValue.InnerHtml.Trim().TrimStart()));
                decimal ExpansionInvothers = Convert.ToDecimal(GetDecimalNullValue(txtExpansionInvothers.InnerHtml.Trim().TrimStart()));

                lblExpansionInvTot.InnerHtml = (ExpansionLandValue + ExpansionBuildingValue + ExpansionplantMechValue + ExpansionInvothers).ToString();
            }
            else
            {
                // common application form values (existing industry)
                decimal currInvLandValue = Convert.ToDecimal(GetDecimalNullValue(txtcurrInvLandValue.InnerHtml.Trim().TrimStart()));
                decimal currInvBuldvalue = Convert.ToDecimal(GetDecimalNullValue(txtcurrInvBuldvalue.InnerHtml.Trim().TrimStart()));
                decimal currInvplantMechValue = Convert.ToDecimal(GetDecimalNullValue(txtcurrInvplantMechValue.InnerHtml.Trim().TrimStart()));
                decimal currentInvothers = Convert.ToDecimal(GetDecimalNullValue(txtcurrentInvothers.InnerHtml.Trim().TrimStart()));

                // based on entry
                decimal ExpansionLandValue = Convert.ToDecimal(GetDecimalNullValue(txtExpansionLandValue.InnerHtml.Trim().TrimStart()));
                decimal ExpansionBuildingValue = Convert.ToDecimal(GetDecimalNullValue(txtExpansionBuildingValue.InnerHtml.Trim().TrimStart()));
                decimal ExpansionplantMechValue = Convert.ToDecimal(GetDecimalNullValue(txtExpansionplantMechValue.InnerHtml.Trim().TrimStart()));
                decimal ExpansionInvothers = Convert.ToDecimal(GetDecimalNullValue(txtExpansionInvothers.InnerHtml.Trim().TrimStart()));

                lblExpansionInvTot.InnerHtml = (ExpansionLandValue + ExpansionBuildingValue + ExpansionplantMechValue + ExpansionInvothers).ToString();
                lblCurrInvTot.InnerHtml = (currInvLandValue + currInvBuldvalue + currInvplantMechValue + currentInvothers).ToString();

                try
                {
                    txtExpansionLandPer.InnerHtml = ((float)System.Math.Round((ExpansionLandValue / currInvLandValue) * 100, 2)).ToString();// ("#.##");
                    if (txtExpansionLandPer.InnerHtml == "∞" || txtExpansionLandPer.InnerHtml == "0")
                    {
                        txtExpansionLandPer.InnerHtml = "0";
                    }
                }
                catch (Exception ex)
                {
                    string errorMsg = ex.Message;
                    txtExpansionLandPer.InnerHtml = "0";
                }
                try
                {
                    txtExpansionBuildingPer.InnerHtml = ((float)System.Math.Round((ExpansionBuildingValue / currInvBuldvalue) * 100, 2)).ToString();//("#.##");
                    if (txtExpansionBuildingPer.InnerHtml == "∞" || txtExpansionBuildingPer.InnerHtml == "0")
                    {
                        txtExpansionBuildingPer.InnerHtml = "0";
                    }
                }
                catch (Exception ex)
                {
                    string errorMsg = ex.Message;
                }
                try
                {
                    txtExpansionPMPer.InnerHtml = ((float)System.Math.Round((ExpansionplantMechValue / currInvplantMechValue) * 100, 2)).ToString();//("#.##");
                    if (txtExpansionPMPer.InnerHtml == "∞" || txtExpansionPMPer.InnerHtml == "0")
                    {
                        txtExpansionPMPer.InnerHtml = "0";
                    }
                }
                catch (Exception ex)
                {
                    string errorMsg = ex.Message;
                    txtExpansionPMPer.InnerHtml = "0";
                }
                try
                {
                    txtExpansionOthersPer.InnerHtml = ((float)System.Math.Round((ExpansionInvothers / currentInvothers) * 100, 2)).ToString();//("#.##");
                    if (txtExpansionOthersPer.InnerHtml == "∞" || txtExpansionOthersPer.InnerHtml == "0")
                    {
                        txtExpansionOthersPer.InnerHtml = "0";
                    }
                }
                catch (Exception ex)
                {
                    string errorMsg = ex.Message;
                    txtExpansionOthersPer.InnerHtml = "0";
                }
                decimal ExpansionInvTot = Convert.ToDecimal(GetDecimalNullValue(lblExpansionInvTot.InnerHtml.Trim().TrimStart()));
                decimal CurrInvTot = Convert.ToDecimal(GetDecimalNullValue(lblCurrInvTot.InnerHtml.Trim().TrimStart()));
                try
                {
                    txtExpansionTotalPer.InnerHtml = ((float)System.Math.Round((ExpansionInvTot / CurrInvTot) * 100, 2)).ToString();//("#.##");
                    if (txtExpansionTotalPer.InnerHtml == "∞" || txtExpansionTotalPer.InnerHtml == "0")
                    {
                        txtExpansionTotalPer.InnerHtml = "0";
                    }
                }
                catch (Exception ex)
                {
                    string errorMsg = ex.Message;
                    txtExpansionTotalPer.InnerHtml = "0";
                }
            }
        }
        public string GetDecimalNullValue(string Input)
        {
            string InputValue = "";

            InputValue = (Input != "") ? Input : "0";

            return InputValue;
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
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_MORATORIUM_PERIOD_DTLS", pp);
            return Dsnew;
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
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_IS_CURRENTCLAIM_PERIOD_DTLS", pp);
            return Dsnew;
        }

        protected void BindAdditionalInformationDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetAdditionalInformationDtls(INCENTIVEID);

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

        public DataSet GetAdditionalInformationDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_IS_ADITIONALINFORMATION_DTLS", pp);
            return Dsnew;
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
                    if (txtlandexisting.InnerHtml != null && txtlandexisting.InnerHtml != "" && txtlandexisting.InnerHtml != string.Empty)
                    {
                        landexisting = Convert.ToDecimal(txtlandexisting.InnerHtml.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        landexisting = 0;
                    }
                    if (txtbuildingexisting.InnerHtml != null && txtbuildingexisting.InnerHtml != "" && txtbuildingexisting.InnerHtml != string.Empty)
                    {
                        buildingexisting = Convert.ToDecimal(txtbuildingexisting.InnerHtml.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        buildingexisting = 0;
                    }

                    if (txtplantexisting.InnerHtml != null && txtplantexisting.InnerHtml != "" && txtplantexisting.InnerHtml != string.Empty)
                    {
                        PlantMachValexisting = Convert.ToDecimal(txtplantexisting.InnerHtml.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        PlantMachValexisting = 0;
                    }
                    //if (txtnewothers.InnerHtml != null && txtnewothers.InnerHtml != "" && txtnewothers.InnerHtml != string.Empty)
                    //{
                    //    Othernew = Convert.ToDecimal(txtnewothers.InnerHtml.Trim());  // expansion Plant Mach value   
                    //}
                    //else
                    //{
                    //    Othernew = 0;
                    //}

                    PlantMachValFinal = (PlantMachValexisting + landexisting + buildingexisting + Othernew);
                    lblnewinv.InnerHtml = PlantMachValFinal.ToString();
                }
                else if (Step == "2")
                {
                    //--------------------------------
                    if (txtlandcapacity.InnerHtml != null && txtlandcapacity.InnerHtml != "" && txtlandcapacity.InnerHtml != string.Empty)
                    {
                        landcapacity = Convert.ToDecimal(txtlandcapacity.InnerHtml.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        landcapacity = 0;
                    }
                    if (txtbuildingcapacity.InnerHtml != null && txtbuildingcapacity.InnerHtml != "" && txtbuildingcapacity.InnerHtml != string.Empty)
                    {
                        buildingcapacity = Convert.ToDecimal(txtbuildingcapacity.InnerHtml.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        buildingcapacity = 0;
                    }

                    // -------------------------------

                    if (txtplantcapacity.InnerHtml != null && txtplantcapacity.InnerHtml != "" && txtplantcapacity.InnerHtml != string.Empty)
                    {
                        PlantMachValexpansion = Convert.ToDecimal(txtplantcapacity.InnerHtml.Trim());  // expansion Plant Mach value   
                    }
                    else
                    {
                        PlantMachValexpansion = 0;
                    }
                    //-----------------


                    //if (txtexistother.InnerHtml != null && txtexistother.InnerHtml != "" && txtexistother.InnerHtml != string.Empty)
                    //{
                    //    OtherExisting = Convert.ToDecimal(txtexistother.InnerHtml.Trim());  // expansion Plant Mach value   
                    //}
                    //else
                    //{
                    //    OtherExisting = 0;
                    //}
                    PlantMachValFinal = (PlantMachValexpansion + landcapacity + buildingcapacity + OtherExisting);
                    lblexpinv.InnerHtml = PlantMachValFinal.ToString();
                }
                else if (Step == "3")
                {
                    if (txtlandpercentage.InnerHtml != null && txtlandpercentage.InnerHtml != "" && txtlandpercentage.InnerHtml != string.Empty)
                    {
                        landcapacityPer = Convert.ToDecimal(txtlandpercentage.InnerHtml.Trim());  // expansion Plant Mach value   
                    }
                    else
                    {
                        landcapacityPer = 0;
                    }

                    if (txtbuildingpercentage.InnerHtml != null && txtbuildingpercentage.InnerHtml != "" && txtbuildingpercentage.InnerHtml != string.Empty)
                    {
                        buildingcapacityPer = Convert.ToDecimal(txtbuildingpercentage.InnerHtml.Trim());  // expansion Plant Mach value   
                    }
                    else
                    {
                        buildingcapacityPer = 0;
                    }

                    if (txtplantpercentage.InnerHtml != null && txtplantpercentage.InnerHtml != "" && txtplantpercentage.InnerHtml != string.Empty)
                    {
                        PlantMachValPer = Convert.ToDecimal(txtplantpercentage.InnerHtml.Trim());  // expansion Plant Mach value   
                    }
                    else
                    {
                        PlantMachValPer = 0;
                    }

                    //if (txtotherpersangage.InnerHtml != null && txtotherpersangage.InnerHtml != "" && txtotherpersangage.InnerHtml != string.Empty)
                    //{
                    //    OthernewPer = Convert.ToDecimal(txtotherpersangage.InnerHtml.Trim());  // expansion Plant Mach value   
                    //}
                    //else
                    //{
                    //    OthernewPer = 0;
                    //}

                    PlantMachValFinal = Convert.ToDecimal((landcapacityPer + buildingcapacityPer + PlantMachValPer + OthernewPer) / 3);

                    lbltotperinv.InnerHtml = PlantMachValFinal.ToString("#.##");
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                //lblmsg0.InnerHtml = ex.Message;
                //Failure.Visible = true;
                //success.Visible = false;
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
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_INCENTIVES_CAF_DATA", pp);
            return Dsnew;
        }
        public DataSet GetInterestSubsidy(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
           };
            pp[0].Value = IncentiveId;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_INCENTIVE_INTERESTSUBSIDY", pp);
            return Dsnew;
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
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_TOTALTERMLOANREPAID", pp);
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

        protected void grdTermLoanRepaid_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "InterestAmt").ToString() != "" && DataBinder.Eval(e.Row.DataItem, "InterestAmt").ToString() != null)
                {
                    decimal InterestAmountPaid1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "InterestAmt"));
                    InterestAmountPaid = InterestAmountPaid1 + InterestAmountPaid;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[7].Text = "Total";
                e.Row.Cells[8].Text = InterestAmountPaid.ToString();
            }
        }

        protected void GVTermLoandtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "SanctionedAmount").ToString() != "" && DataBinder.Eval(e.Row.DataItem, "SanctionedAmount").ToString() != null)
                {
                    decimal SanctionedAmount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SanctionedAmount"));
                    SanctionedAmount = SanctionedAmount1 + SanctionedAmount;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[5].Text = "Total";
                e.Row.Cells[6].Text = SanctionedAmount.ToString();
            }
        }


        protected void GVTermLoandtls2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[3].Text = "Total";
            }
        }

        protected void gvAdditionalInformation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "EligibleInterest").ToString() != "" && DataBinder.Eval(e.Row.DataItem, "EligibleInterest").ToString() != null)
                {
                    decimal EligibleInterest1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "EligibleInterest"));
                    EligibleInterest = EligibleInterest1 + EligibleInterest;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[10].Text = "Total";
                e.Row.Cells[11].Text = EligibleInterest.ToString();
            }
        }
    }
}