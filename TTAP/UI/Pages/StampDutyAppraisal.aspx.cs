using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    public partial class StampDutyAppraisal : System.Web.UI.Page
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

            try
            {
                if (Session["ObjLoginvo"] != null)
                {
                    if (!IsPostBack)
                    {
                        string incentiveid = "";
                        ViewState["UID"] = ObjLoginNewvo.uid;
                        //Request.QueryString["IncentiveID"] = incentiveid;
                        if (Request.QueryString["IncentiveID"] != null)
                        {
                            incentiveid = Request.QueryString["IncentiveID"].ToString();
                        }
                        txtIncID.Text = incentiveid;
                        BindBesicdata(incentiveid, "6", "");
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
                //string IncentiveId = Request.QueryString["incid"].ToString();
                //string MasterIncentiveId = Request.QueryString["mstid"].ToString();
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
                    txtGmRecom.Text = dsnew.Tables[1].Rows[0]["OfficerRecommendedAmount"].ToString();

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

        protected void RBTTYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            StampdutyCalculation();
        }
             
             
        protected void DDLSCHEME_SelectedIndexChanged(object sender, EventArgs e)
        {
            StampdutyCalculation();
        }

        protected void txtland_TextChanged(object sender, EventArgs e)
        {
            StampdutyCalculation();
        }

        protected void txtstampduty_TextChanged(object sender, EventArgs e)
        {
            StampdutyCalculation();
        }

        protected void txtplinth_TextChanged(object sender, EventArgs e)
        {
            StampdutyCalculation();

        }

        protected void txtplinth5_TextChanged(object sender, EventArgs e)
        {
            StampdutyCalculation();
        }

        protected void txtproportionate_TextChanged(object sender, EventArgs e)
        {
            StampdutyCalculation();
        }

        protected void btnback_Click(object sender, EventArgs e)
        {

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {

        }

        public void StampdutyCalculation()
        {
            try
            {
                if (txtland.Text.Trim() != "")
                {
                    if (txtstampduty.Text.Trim() != "")
                    {
                        if(txtplinth.Text.Trim() !="")
                        {
                            txtplinth5.Text = Math.Round(Convert.ToDecimal(txtplinth.Text.Trim()) * 5, 2).ToString();
                            txtproportionate.Text  = ((Convert.ToDecimal(txtplinth5.Text.Trim()) / Convert.ToDecimal(txtland.Text.Trim()))* (Convert.ToDecimal(txtstampduty.Text.Trim()))).ToString();
                            txtvaluecomputed.Text  = txtstampduty.Text.Trim();
                            if(RBTTYPE.SelectedValue !="")
                            {
                                if (rdeligibility.SelectedValue == "Regular")
                                {
                                    txtEligible.Text = txtstampduty.Text.Trim();
                                }

                                else if (rdeligibility.SelectedValue == "Belated")
                                {
                                    txtEligible.Text = ((Convert.ToDecimal(txtstampduty.Text.Trim()))/2).ToString();
                                }
                                else if (rdeligibility.SelectedValue == "OneYear")
                                {
                                    txtEligible.Text = "0";
                                }
                            }
                          
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        protected void rdeligibility_SelectedIndexChanged(object sender, EventArgs e)
        {
            StampdutyCalculation();
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string IncentiveId = txtIncID.Text;
            string SubIncentiveId = "1";

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
    }
}