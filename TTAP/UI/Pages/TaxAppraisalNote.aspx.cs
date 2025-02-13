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
    public partial class TaxAppraisalNote : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        CAFClass ObjCAFClass = new CAFClass();
        AppraisalClass objappraisalClass = new AppraisalClass();
        string casteGenderGmUpdate = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
            ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
            ViewState["UID"] = ObjLoginNewvo.uid;
            try
            {
                if (Session["ObjLoginvo"] != null)
                {
                    if (!IsPostBack)
                    {
                        string incentiveid = "";
                        //Request.QueryString["IncentiveID"] = incentiveid;
                        if (Request.QueryString["IncentiveID"] != null)
                        {
                            incentiveid = Request.QueryString["IncentiveID"].ToString();
                        }
                        txtIncID.Text = incentiveid;
                        BindBesicdata(incentiveid, "1", "");
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
                    }
                    else
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCPExp"].ToString();
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

                    txtlandexisting.InnerHtml = dsnew.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString();
                    //TextBox33.Text = dsnew.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString();
                    txtlandcapacity.InnerHtml = dsnew.Tables[0].Rows[0]["ExpansionDiversificationLand"].ToString();
                    txtlandpercentage.InnerHtml = dsnew.Tables[0].Rows[0]["LandFixedCapitalInvestPercentage"].ToString();

                    txtbuildingexisting.InnerHtml = dsnew.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString();
                    // TextBox37.Text = dsnew.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString();
                    txtbuildingcapacity.InnerHtml = dsnew.Tables[0].Rows[0]["ExpDiversBuilding"].ToString();
                    txtbuildingpercentage.InnerHtml = dsnew.Tables[0].Rows[0]["BuildingFixedCapitalInvestPercentage"].ToString();

                    txtplantexisting.InnerHtml = dsnew.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString();
                    // TextBox41.Text = dsnew.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString();
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
                    txtgmRecommend.Text = dsnew.Tables[1].Rows[0]["OfficerRecommendedAmount"].ToString();

                    CalculateCurrInvTot(TypeOfIndustry);
                   
                   
                }
            }
            catch (Exception ex)
            { }
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
        protected void DDLSCHEME_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLSCHEME.SelectedValue == "IIPP 2010-15")
            {
                TRTOTALSALESTAXSANCTIONED.Visible = false;
                TRCAPITALELIGIBLEINVESTMENT.Visible = false;
            }
            //if (DDLSCHEME.SelectedValue == "T-IDEA")
            else
            {
                TRTOTALSALESTAXSANCTIONED.Visible = true;
                TRCAPITALELIGIBLEINVESTMENT.Visible = true;
            }
        }
        protected void RBTTYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (RBTTYPE.SelectedValue != "")
                {


                    if (RBTTYPE.SelectedValue == "NEW/REGULAR")
                    {
                        TXTBASEPRODUCTION.Enabled = false;
                        TXTBASEPRODUCTION.Text = "0";
                    }
                    //else if (RBTTYPE.SelectedValue == "REGULAR")
                    //{
                    //    TXTBASEPRODUCTION.Enabled = false;
                    //    TXTBASEPRODUCTION.Text = "0";
                    //}
                    else
                    {
                        TXTBASEPRODUCTION.Enabled = true;
                        TXTBASEPRODUCTION.Text = "";
                        //TXTBASEPRODUCTION.Focus();
                    }

                }

            }
            catch (Exception ex)
            {
            }
        }
        protected void TXTPRODUCTION_TextChanged(object sender, EventArgs e)
        {
            if (RBTTYPE.SelectedValue == "NEW/REGULAR")
            {
                if (TXTPRODUCTION.Text != "")
                {
                    TXTELIGIBLEPRODUCTIONQTY.Text = TXTPRODUCTION.Text;
                }
            }
        }
        protected void TXTTAXPAID_TextChanged(object sender, EventArgs e)
        {
            if (RBTTYPE.SelectedValue == "NEW/REGULAR")
            {
                if (TXTTAXPAID.Text != "")
                {
                    TXTPROPORTINATESGSTVALUE.Text = ((Convert.ToDecimal(TXTELIGIBLEPRODUCTIONQTY.Text) * (Convert.ToDecimal(TXTTAXPAID.Text))) / (Convert.ToDecimal(TXTPRODUCTION.Text))).ToString();
                }
            }
        }
        protected void TXTBASEPRODUCTION_TextChanged(object sender, EventArgs e)
        {
            if (TXTPRODUCTION.Text == "" || TXTPRODUCTION.Text == null)
            {
                TXTBASEPRODUCTION.Text = "";
                TXTPRODUCTION.Focus();
            }
            if ((TXTPRODUCTION.Text != "" || TXTPRODUCTION.Text != null) && (TXTTAXPAID.Text != "") && (TXTBASEPRODUCTION.Text != ""))
            {

                //if (Convert.ToDecimal(TXTBASEPRODUCTION.Text) > Convert.ToDecimal(TXTPRODUCTION.Text))
                //{
                //    //SCRIPT MANAGER ALERT CODE
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Sir, Base Production should always less than Production');", true);
                //    TXTBASEPRODUCTION.Text = "";
                //    TXTBASEPRODUCTION.Focus();
                //}
                //else
                //{
                TXTELIGIBLEPRODUCTIONQTY.Text = (Convert.ToDecimal(TXTPRODUCTION.Text) - (Convert.ToDecimal(TXTBASEPRODUCTION.Text))).ToString();
                TXTPROPORTINATESGSTVALUE.Text = ((Convert.ToDecimal(TXTELIGIBLEPRODUCTIONQTY.Text) * (Convert.ToDecimal(TXTTAXPAID.Text))) / (Convert.ToDecimal(TXTPRODUCTION.Text))).ToString();
                DDLCATEGORY.ClearSelection();
                DDLCATEGORY_SelectedIndexChanged(this, EventArgs.Empty);
                // }
            }

        }
        protected void TXTSALESTAXSANCTIONED_TextChanged(object sender, EventArgs e)
        {
            if (TXTCAPITALELIGIBLEINVESTMENT.Text == null || TXTCAPITALELIGIBLEINVESTMENT.Text == "")
            {
                TXTSALESTAXSANCTIONED.Text = "";
                TXTCAPITALELIGIBLEINVESTMENT.Focus();
            }
            else if (Convert.ToDecimal(TXTSALESTAXSANCTIONED.Text) > Convert.ToDecimal(TXTCAPITALELIGIBLEINVESTMENT.Text))
            {
                TXTSALESTAXSANCTIONED.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('TOTAL SALES TAX ALREADY SANCTIONED PRIOR TO THIS CLAIM SHOLUD LESS THAN TOTAL CAPITAL ELIGIBLE INVESTMENT');", true);
            }
            else
            {
                HDNAMOUNT.Value = (Convert.ToDecimal(TXTCAPITALELIGIBLEINVESTMENT.Text) - Convert.ToDecimal(TXTSALESTAXSANCTIONED.Text)).ToString();
            }
        }
        protected void DDLCATEGORY_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLCATEGORY.SelectedValue == "0" || DDLCATEGORY.SelectedItem.Text == "--Select--")
            {
                TRMEGA.Visible = false;
                TRLARGE.Visible = false;
                TRMEDIUM.Visible = false;
                TRSMALL.Visible = false;
                TRMICRO.Visible = false;
                TXTMEGA.Enabled = true;
                TXTELIGIBLEAMOUNT.Text = "";
                rdeligibility.ClearSelection();
                TXTFINALELIGIBLEAMOUNT.Text = "";
            }
            if (DDLSCHEME.SelectedValue == "IIPP 2010-15")
            {
                if (DDLCATEGORY.SelectedValue == "1")
                {
                    TRMEGA.Visible = true;
                    TRLARGE.Visible = false;
                    TRMEDIUM.Visible = false;
                    TRSMALL.Visible = false;
                    TRMICRO.Visible = false;
                    TXTMEGA.Enabled = true;
                }
                else if (DDLCATEGORY.SelectedValue == "2")
                {
                    TXTLARGE.Enabled = false;
                    TRMEGA.Visible = false;
                    TRLARGE.Visible = true;
                    TRMEDIUM.Visible = false;
                    TRSMALL.Visible = false;
                    TRMICRO.Visible = false;
                    TXTLARGE.Text = "25%";
                    if (TXTLARGE.Text == "25%")
                    {
                        TXTLARGE.Text = "25";
                    }

                    TXTELIGIBLEAMOUNT.Text = (Convert.ToDecimal(TXTPROPORTINATESGSTVALUE.Text) * Convert.ToDecimal(TXTLARGE.Text) / 100).ToString();
                }
                else if (DDLCATEGORY.SelectedValue == "3")
                {
                    TXTMEDIUM.Enabled = false;
                    TRMEGA.Visible = false;
                    TRLARGE.Visible = false;
                    TRMEDIUM.Visible = true;
                    TRSMALL.Visible = false;
                    TRMICRO.Visible = false;
                    TXTMEDIUM.Text = "25%";
                    if (TXTMEDIUM.Text == "25%")
                    {
                        TXTMEDIUM.Text = "25";
                    }
                    TXTELIGIBLEAMOUNT.Text = (Convert.ToDecimal(TXTPROPORTINATESGSTVALUE.Text) * Convert.ToDecimal(TXTMEDIUM.Text) / 100).ToString();
                }
                else if (DDLCATEGORY.SelectedValue == "4")
                {
                    TXTSMALL.Enabled = false;
                    TRMEGA.Visible = false;
                    TRLARGE.Visible = false;
                    TRMEDIUM.Visible = false;
                    TRSMALL.Visible = true;
                    TRMICRO.Visible = false;
                    TXTSMALL.Text = "50%";
                    if (TXTSMALL.Text == "50%")
                    {
                        TXTSMALL.Text = "50";
                    }
                    TXTELIGIBLEAMOUNT.Text = (Convert.ToDecimal(TXTPROPORTINATESGSTVALUE.Text) * Convert.ToDecimal(TXTSMALL.Text) / 100).ToString();
                }
                else
                {
                    TXTMICRO.Enabled = false;
                    TRMEGA.Visible = false;
                    TRLARGE.Visible = false;
                    TRMEDIUM.Visible = false;
                    TRSMALL.Visible = false;
                    TRMICRO.Visible = true;
                    TXTMICRO.Text = "100%";
                    if (TXTMICRO.Text == "100%")
                    {
                        TXTMICRO.Text = "100";
                    }
                    TXTELIGIBLEAMOUNT.Text = (Convert.ToDecimal(TXTPROPORTINATESGSTVALUE.Text) * Convert.ToDecimal(TXTMICRO.Text) / 100).ToString();
                }
            }
            else
            {
                if (DDLCATEGORY.SelectedValue == "1")
                {
                    TRMEGA.Visible = true;
                    TRLARGE.Visible = false;
                    TRMEDIUM.Visible = false;
                    TRSMALL.Visible = false;
                    TRMICRO.Visible = false;
                    TXTMEGA.Enabled = true;
                }
                else if (DDLCATEGORY.SelectedValue == "2")
                {
                    TXTLARGE.Enabled = false;
                    TRMEGA.Visible = false;
                    TRLARGE.Visible = true;
                    TRMEDIUM.Visible = false;
                    TRSMALL.Visible = false;
                    TRMICRO.Visible = false;
                    TXTLARGE.Text = "50%";
                    if (TXTLARGE.Text == "50%")
                    {
                        TXTLARGE.Text = "50";
                    }

                    TXTELIGIBLEAMOUNT.Text = (Convert.ToDecimal(TXTPROPORTINATESGSTVALUE.Text) * Convert.ToDecimal(TXTLARGE.Text) / 100).ToString();
                }
                else if (DDLCATEGORY.SelectedValue == "3")
                {
                    TXTMEDIUM.Enabled = false;
                    TRMEGA.Visible = false;
                    TRLARGE.Visible = false;
                    TRMEDIUM.Visible = true;
                    TRSMALL.Visible = false;
                    TRMICRO.Visible = false;
                    TXTMEDIUM.Text = "75%";
                    if (TXTMEDIUM.Text == "75%")
                    {
                        TXTMEDIUM.Text = "75";
                    }
                    TXTELIGIBLEAMOUNT.Text = (Convert.ToDecimal(TXTPROPORTINATESGSTVALUE.Text) * Convert.ToDecimal(TXTMEDIUM.Text) / 100).ToString();
                }
                else if (DDLCATEGORY.SelectedValue == "4")
                {
                    TXTSMALL.Enabled = false;
                    TRMEGA.Visible = false;
                    TRLARGE.Visible = false;
                    TRMEDIUM.Visible = false;
                    TRSMALL.Visible = true;
                    TRMICRO.Visible = false;
                    TXTSMALL.Text = "100%";
                    if (TXTSMALL.Text == "100%")
                    {
                        TXTSMALL.Text = "100";
                    }
                    if (TXTPROPORTINATESGSTVALUE.Text != "" && TXTPROPORTINATESGSTVALUE.Text != "")
                    {
                        TXTELIGIBLEAMOUNT.Text = (Convert.ToDecimal(TXTPROPORTINATESGSTVALUE.Text) * Convert.ToDecimal(TXTSMALL.Text) / 100).ToString();
                    }

                }
                else
                {
                    TXTMICRO.Enabled = false;
                    TRMEGA.Visible = false;
                    TRLARGE.Visible = false;
                    TRMEDIUM.Visible = false;
                    TRSMALL.Visible = false;
                    TRMICRO.Visible = true;
                    TXTMICRO.Text = "100%";
                    if (TXTMICRO.Text == "100%")
                    {
                        TXTMICRO.Text = "100";
                    }
                    TXTELIGIBLEAMOUNT.Text = (Convert.ToDecimal(TXTPROPORTINATESGSTVALUE.Text) * Convert.ToDecimal(TXTMICRO.Text) / 100).ToString();
                }
            }

        }
        protected void TXTMEGA_TextChanged(object sender, EventArgs e)
        {
            if (TXTMEGA.Text != null && TXTMEGA.Text != "")
            {
                TXTELIGIBLEAMOUNT.Text = (Convert.ToDecimal(TXTPROPORTINATESGSTVALUE.Text) * Convert.ToDecimal(TXTMEGA.Text) / 100).ToString();
            }
        }
        protected void rdeligibility_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RBTTYPE.SelectedValue == "EXPANSION")
            {
                if (Convert.ToDecimal(TXTBASEPRODUCTION.Text) > Convert.ToDecimal(TXTPRODUCTION.Text))
                {
                    TXTFINALSUBSIDYAMOUNT.Enabled = true;
                }
            }
            if (rdeligibility.SelectedValue == "Regular")
            {
                if (DDLSCHEME.SelectedValue == "IIPP 2010-15")
                {
                    TXTFINALELIGIBLEAMOUNT.Text = TXTELIGIBLEAMOUNT.Text;
                }
                else
                {
                    if (Convert.ToDecimal(TXTELIGIBLEAMOUNT.Text) <= Convert.ToDecimal(HDNAMOUNT.Value))
                    {
                        TXTFINALELIGIBLEAMOUNT.Text = TXTELIGIBLEAMOUNT.Text;
                    }
                    else
                    {
                        TXTFINALELIGIBLEAMOUNT.Text = HDNAMOUNT.Value;
                    }
                }
            }
            else if (rdeligibility.SelectedValue == "Belated")
            {
                if (DDLSCHEME.SelectedValue == "IIPP 2010-15")
                {
                    TXTFINALELIGIBLEAMOUNT.Text = (Convert.ToDecimal(TXTELIGIBLEAMOUNT.Text) / 2).ToString();
                }
                else
                {
                    if ((Convert.ToDecimal(TXTELIGIBLEAMOUNT.Text) / 2) <= Convert.ToDecimal(HDNAMOUNT.Value))
                    {
                        TXTFINALELIGIBLEAMOUNT.Text = (Convert.ToDecimal(TXTELIGIBLEAMOUNT.Text) / 2).ToString();
                    }
                    else
                    {
                        TXTFINALELIGIBLEAMOUNT.Text = HDNAMOUNT.Value;
                    }
                }
            }
            else
            {
                TXTFINALELIGIBLEAMOUNT.Text = "0";
            }
            if (Convert.ToDecimal(TXTFINALELIGIBLEAMOUNT.Text) < Convert.ToDecimal(txtgmRecommend.Text))
            {
                TXTFINALSUBSIDYAMOUNT.Text = TXTFINALELIGIBLEAMOUNT.Text;
            }
            else
            {
                TXTFINALSUBSIDYAMOUNT.Text = txtgmRecommend.Text;
            }
        }
       
       
        protected void Button3_Click(object sender, EventArgs e)
        {
            string errormsg = ValidateControls();
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            else
            {
                if (save())
                {
                    string message = "alert('Appraisal note submitted successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    Button3.Visible = false;
                }
            }
        }
        public string ValidateControls()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (RBTTYPE.SelectedValue.ToString()=="" || RBTTYPE.SelectedValue.ToString()==null || RBTTYPE.SelectedValue.ToString()=="0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please 	Select Type of Industry \\n";
                slno = slno + 1;
            }
            if (TXTPRODUCTION.Text== "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Production \\n";
                slno = slno + 1;
            }
            if (TXTTAXPAID.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Tax Paid(SGST) \\n";
                slno = slno + 1;
            }
            if (TXTBASEPRODUCTION.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Base Production \\n";
                slno = slno + 1;
            }
            if (TXTELIGIBLEPRODUCTIONQTY.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Eligible Production Qty over and above base production \\n";
                slno = slno + 1;
            }
            if (TXTPROPORTINATESGSTVALUE.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Proportinate SGST value on eligible production \\n";
                slno = slno + 1;
            }
            if (TXTCAPITALELIGIBLEINVESTMENT.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Total Capital Eligible Investment \\n";
                slno = slno + 1;
            }
            if (TXTSALESTAXSANCTIONED.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Total Sales Tax already sanctioned prior to this claim \\n";
                slno = slno + 1;
            }
            if (DDLCATEGORY.SelectedValue=="0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Category \\n";
                slno = slno + 1;
            }
            if (TXTELIGIBLEAMOUNT.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter AMOUNT \\n";
                slno = slno + 1;
            }
            if (rdeligibility.SelectedValue == null || rdeligibility.SelectedValue == "" || rdeligibility.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Eligibility Type \\n";
                slno = slno + 1;
            }
            if (TXTFINALELIGIBLEAMOUNT.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Eligible Amount \\n";
                slno = slno + 1;
            }
            if (ddlDepartment.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select whom you want to forward this to. \\n";
                slno = slno + 1;
            }
            if (hypWorksheet.NavigateUrl == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Upload Worksheet Pdf File \\n";
                slno = slno + 1;
            }
            return ErrorMsg;
        }
        public bool save()
        {
            UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
            ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

            ApprasialProperties objApprasialProperties = new ApprasialProperties();
            bool status = false;
            try
            {
                //Chanikya
                objApprasialProperties.INCENTIVEID = txtIncID.Text;
                objApprasialProperties.NAMEOFINDUSTRIAL = lblUnitName.InnerText;
                objApprasialProperties.LOCATIONOFINDUSTRIAL = lblAddress.InnerText;
                objApprasialProperties.NAMEOFPROMOTER = lblUnitName.InnerText;
                objApprasialProperties.ConstitutionOFINDUSTRIAL = lblOrganization.InnerText;
                objApprasialProperties.SOCIALSTATUS = lblSocialStatus.InnerText;
                objApprasialProperties.WOMENENTERPRENEUR = lblShareofSCSTWomenEnterprenue.InnerText;
                objApprasialProperties.PMTSSIREGISTRATIONNO = lblRegistrationNumber.InnerText;
                objApprasialProperties.TypeOfUnit = lblTypeofApplicant.InnerText;
                objApprasialProperties.CATEGORY = lblCategoryofUnit.InnerText;
                objApprasialProperties.SECTOR = lblTypeofSector.InnerText;
                objApprasialProperties.TextileType = lblTypeofTexttile.InnerText;
                objApprasialProperties.TechnicalTextileType = lblTechnicalTextileType.InnerText;
                objApprasialProperties.ActivityOfUnit = lblActivityoftheUnit.InnerText;
                objApprasialProperties.UID_NO = lblTSIPassUIDNumber.InnerText.ToString();
                objApprasialProperties.Application_No = lblCommonApplicationNumber.InnerText.ToString();
                objApprasialProperties.DATEOFPRODUCTION = Convert.ToDateTime(lblDCPdate.InnerText).ToString("yyyy-MM-dd");
                objApprasialProperties.DICFILLINGDATE = Convert.ToDateTime(lblReceiptDate.InnerText).ToString("yyyy-MM-dd");
                objApprasialProperties.PowerConnectionRlsDate = Convert.ToDateTime(lblPowerConnectionReleaseDate.InnerText).ToString("yyyy-MM-dd");
                objApprasialProperties.NAMEFINANCINGUNIT = lblUnitName.InnerText;

                objApprasialProperties.TypeOfUnitIns = RBTTYPE.SelectedValue.ToString();
                objApprasialProperties.Production = TXTPRODUCTION.Text;
                objApprasialProperties.TaxPaidSGST = TXTTAXPAID.Text;
                objApprasialProperties.BaseProduction = TXTBASEPRODUCTION.Text;
                objApprasialProperties.EligibleProductionQty = TXTELIGIBLEPRODUCTIONQTY.Text;
                objApprasialProperties.ProportinateSGST = TXTPROPORTINATESGSTVALUE.Text;
                objApprasialProperties.CapitalEligibleInv = TXTCAPITALELIGIBLEINVESTMENT.Text;
                objApprasialProperties.AlreadySanctionedAmount = TXTSALESTAXSANCTIONED.Text;
                objApprasialProperties.CategoryAsPerInspection = DDLCATEGORY.SelectedValue.ToString();
                objApprasialProperties.AMOUNT = TXTELIGIBLEAMOUNT.Text;
                objApprasialProperties.Type = rdeligibility.SelectedValue.ToString();

                objApprasialProperties.GMRecommendedAmount = txtgmRecommend.Text;
                objApprasialProperties.EligibleSubsidyAmount = TXTFINALELIGIBLEAMOUNT.Text;
                objApprasialProperties.TotalSubsidyAmount = TXTFINALSUBSIDYAMOUNT.Text;
                objApprasialProperties.Remarks = txtremarks.Text;
                objApprasialProperties.WorkSheetPath = hypWorksheet.NavigateUrl.ToString();
                objApprasialProperties.CREATEDBY = ObjLoginNewvo.uid;
                objApprasialProperties.CREATEDBYIP = "";

                objApprasialProperties.Scheme = "TTAP";
                string returnval = "0";
                returnval = ObjCAFClass.InsertTaxAppraisal(objApprasialProperties);
                if (!string.IsNullOrEmpty(returnval) && returnval.Trim() != "")
                {
                    string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
                    DLOApplication DLODetails = new DLOApplication();
                    if (TXTFINALSUBSIDYAMOUNT.Text != "")
                    {
                        DLODetails.RECOMMENDEAMOUNT = TXTFINALSUBSIDYAMOUNT.Text;
                    }
                    else
                    {
                        DLODetails.RECOMMENDEAMOUNT = Convert.ToString(objApprasialProperties.TotalSubsidyAmount);
                    }

                    DLODetails.INCENTIVEID = txtIncID.Text;
                    DLODetails.SUBINCENTIVEID = "6";
                    DLODetails.ACTIONID = "1";
                    DLODetails.FORWARDTO = ddlDepartment.SelectedItem.Text;
                    DLODetails.CREATEDBY = ObjLoginNewvo.uid;

                    string result = ObjCAFClass.InsertClerkDetails(DLODetails);

                    if (result == "1")
                    {
                        status = true;
                        /*lblmsg.Text = "Application Process Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Application Process Submitted Successfully.');", true);*/
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Appraisal note submitted.');", true);
                    status = false;
                }
            }
            catch (Exception ex)
            {

            }
            return status;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string IncentiveId = txtIncID.Text;
            string SubIncentiveId = "6";

            if (fuWorksheet.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuWorksheet);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuWorksheet);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.WorkSheetFileUploading("~\\WorkSheets", Server.MapPath("~\\WorkSheets"), fuWorksheet, hypWorksheet, "WorkSheet", IncentiveId, SubIncentiveId, ViewState["UID"].ToString(), "USER", "WORKSHEET");
                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        hypWorksheet.Visible = true;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Only pdf files allowed !');", true);
                }
            }
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("COI/ClerkDashboard.aspx");
        }
    }
}