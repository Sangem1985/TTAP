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
    public partial class CaptialSubsidyAppraisalNote : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        CAFClass ObjCAFClass = new CAFClass();
        AppraisalClass objappraisalClass = new AppraisalClass();
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    string incentiveid = Request.QueryString["IncentiveID"].ToString();
                    txtIncID.Text = incentiveid;
                    BindBesicdata(incentiveid, "1", "");
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
                    ddlindustryStatus(TypeOfIndustry.Trim().TrimStart().TrimEnd(), TextileProcessName);
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
                    //lblRecommended.InnerText = "100000";
                    lblActivityoftheUnit.InnerText = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();
                    //ddlCategory.SelectedValue = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    hdnActualCategory.Value = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    lblTypeofTexttile.InnerText = dsnew.Tables[0].Rows[0]["TypeofTexttileText"].ToString();
                    //ddlTypeofTextile.SelectedValue = dsnew.Tables[0].Rows[0]["TypeofTexttile"].ToString();
                    hdnActualTextile.Value = dsnew.Tables[0].Rows[0]["TypeofTexttile"].ToString();

                    lblAddress.InnerText = dsnew.Tables[0].Rows[0]["UnitTotalAddress"].ToString();
                    lblProprietor.InnerText = dsnew.Tables[0].Rows[0]["AuthorisedPerson"].ToString();
                    lblOrganization.InnerText = dsnew.Tables[0].Rows[0]["ConstitutionUnit"].ToString();
                    lblSocialStatus.InnerText = dsnew.Tables[0].Rows[0]["SocialStatusText"].ToString();
                    lblRegistrationNumber.InnerText = dsnew.Tables[0].Rows[0]["IncorpRegistranNumber"].ToString();
                    lblTechnicalTextileType.InnerText = dsnew.Tables[0].Rows[0]["TechnicalTextile"].ToString();
                    lblPowerConnectionReleaseDate.InnerText = dsnew.Tables[0].Rows[0]["NewPowerReleaseDate"].ToString();
                    //if (dsnew != null && dsnew.Tables.Count > 1 && dsnew.Tables[1].Rows.Count > 0)
                    //{
                    //    txt_GMrecommendedamount.Text = dsnew.Tables[1].Rows[0]["OfficerRecommendedAmount"].ToString();
                    //}
                }
            }
            catch (Exception ex)
            { }
        }
        protected void ddlindustryStatus(string SelectedValue, string TextileProcessName)
        {
            try
            {
                if (SelectedValue == "1")
                {

                    // Investment 

                    trFixedCapitalexpansion.Visible = false;
                    //trFixedCapitalland.Visible = false;
                    trFixedCapitalBuilding.Visible = false;
                    trFixedCapitalMach.Visible = false;

                    //Td3.Visible = false;
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
                    //trFixedCapitalland.Visible = true;
                    trFixedCapitalBuilding.Visible = true;
                    trFixedCapitalMach.Visible = true;

                    //Td3.Visible = true;
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
                    //trFixedCapitalland.Visible = true;
                    trFixedCapitalBuilding.Visible = true;
                    trFixedCapitalMach.Visible = true;

                    //Td3.Visible = true;
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
        protected void TextBox33_TextChanged(object sender, EventArgs e)
        {
            if (TextBox37.Text == "")
            {
                TextBox37.Text = "0";
            }
            if (TextBox41.Text == "")
            {
                TextBox41.Text = "0";
            }
            if (TextBox44.Text == "")
            {
                TextBox44.Text = "0";
            }

            TextBox1.Text = (Convert.ToDecimal(TextBox33.Text) + Convert.ToDecimal(TextBox37.Text) + Convert.ToDecimal(TextBox41.Text) + Convert.ToDecimal(TextBox44.Text)).ToString();
        }
        protected void TextBox56_TextChanged(object sender, EventArgs e)
        {
            if (TextBox57.Text == "")
            {
                TextBox57.Text = "0";
            }
            if (TextBox58.Text == "")
            {
                TextBox58.Text = "0";
            }
            if (TextBox45.Text == "")
            {
                TextBox45.Text = "0";
            }
            TextBox2.Text = (Convert.ToDecimal(TextBox56.Text) + Convert.ToDecimal(TextBox57.Text) + Convert.ToDecimal(TextBox58.Text) + Convert.ToDecimal(TextBox45.Text)).ToString();
        }
        protected void TextBox37_TextChanged(object sender, EventArgs e)
        {
            if (TextBox33.Text == "")
            {
                TextBox33.Text = "0";
            }
            if (TextBox41.Text == "")
            {
                TextBox41.Text = "0";
            }
            if (TextBox44.Text == "")
            {
                TextBox44.Text = "0";
            }
            TextBox1.Text = (Convert.ToDecimal(TextBox33.Text) + Convert.ToDecimal(TextBox37.Text) + Convert.ToDecimal(TextBox41.Text) + Convert.ToDecimal(TextBox44.Text)).ToString();
        }
        protected void TextBox57_TextChanged(object sender, EventArgs e)
        {
            if (TextBox56.Text == "")
            {
                TextBox56.Text = "0";
            }
            if (TextBox58.Text == "")
            {
                TextBox58.Text = "0";
            }
            if (TextBox45.Text == "")
            {
                TextBox45.Text = "0";
            }
            TextBox2.Text = (Convert.ToDecimal(TextBox56.Text) + Convert.ToDecimal(TextBox57.Text) + Convert.ToDecimal(TextBox58.Text) + Convert.ToDecimal(TextBox45.Text)).ToString();
        }
        protected void TextBox41_TextChanged(object sender, EventArgs e)
        {
            if (TextBox33.Text == "")
            {
                TextBox33.Text = "0";
            }
            if (TextBox37.Text == "")
            {
                TextBox37.Text = "0";
            }
            if (TextBox44.Text == "")
            {
                TextBox44.Text = "0";
            }
            TextBox1.Text = (Convert.ToDecimal(TextBox33.Text) + Convert.ToDecimal(TextBox37.Text) + Convert.ToDecimal(TextBox41.Text) + Convert.ToDecimal(TextBox44.Text)).ToString();
        }
        protected void TextBox58_TextChanged(object sender, EventArgs e)
        {
            if (TextBox56.Text == "")
            {
                TextBox56.Text = "0";
            }
            if (TextBox57.Text == "")
            {
                TextBox57.Text = "0";
            }
            if (TextBox45.Text == "")
            {
                TextBox45.Text = "0";
            }
            TextBox2.Text = (Convert.ToDecimal(TextBox56.Text) + Convert.ToDecimal(TextBox57.Text) + Convert.ToDecimal(TextBox58.Text) + Convert.ToDecimal(TextBox45.Text)).ToString();
        }
        protected void TextBox44_TextChanged(object sender, EventArgs e)
        {
            if (TextBox33.Text == "")
            {
                TextBox33.Text = "0";
            }
            if (TextBox37.Text == "")
            {
                TextBox37.Text = "0";
            }
            if (TextBox41.Text == "")
            {
                TextBox41.Text = "0";
            }
            TextBox1.Text = (Convert.ToDecimal(TextBox33.Text) + Convert.ToDecimal(TextBox37.Text) + Convert.ToDecimal(TextBox41.Text) + Convert.ToDecimal(TextBox44.Text)).ToString();
        }
        protected void TextBox45_TextChanged(object sender, EventArgs e)
        {
            if (TextBox56.Text == "")
            {
                TextBox56.Text = "0";
            }
            if (TextBox57.Text == "")
            {
                TextBox57.Text = "0";
            }
            if (TextBox58.Text == "")
            {
                TextBox58.Text = "0";
            }
            TextBox2.Text = (Convert.ToDecimal(TextBox56.Text) + Convert.ToDecimal(TextBox57.Text) + Convert.ToDecimal(TextBox58.Text) + Convert.ToDecimal(TextBox45.Text)).ToString();
        }

        protected void rdlmv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdlmv.SelectedValue != "")
                {
                    trmenwomen.Visible = true;
                    //rdmenwomen.SelectedValue = "";
                    //rdeligibility.SelectedValue = "";
                    rdmenwomen.Focus();
                    rdmenwomen.ClearSelection();
                    rdeligibility.ClearSelection();
                    TextBox59.Text = "";
                    txt423guideline.Text = "";
                    treligibility.Visible = false;


                }
                else
                {
                    trmenwomen.Visible = false;
                    treligibility.Visible = false;
                }


            }
            catch (Exception ex)
            {
            }
        }
        protected void rdexpansion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdexpansion.SelectedValue != "")
                {

                    if (rdexpansion.SelectedValue == "Y")
                    {
                        txtTSSFCnorms423.Enabled = true;
                        txt423guideline.Enabled = true;
                    }

                    else
                    {
                        txtTSSFCnorms423.Enabled = false;
                        txt423guideline.Enabled = false;
                    }
                }
                else
                {

                }


            }
            catch (Exception ex)
            {
            }
        }
        protected void rdmenwomen_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdmenwomen.SelectedValue != "")
                {
                    treligibility.Visible = true;
                    //trexpansion.Visible = true;
                    if (rdeligibility.SelectedValue != "")
                    {
                        //rdeligibility.SelectedValue = "";
                        rdeligibility.ClearSelection();
                        TextBox56.Text = "";
                        TextBox56_TextChanged(sender, e);
                    }
                    rdeligibility.Focus();
                }
                else
                {
                    treligibility.Visible = false;
                    //trexpansion.Visible = false;
                }

            }
            catch (Exception ex)
            {
            }
        }
        protected void rdeligibility_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdeligibility.SelectedValue != "")
                {
                    Eligible.Visible = true;
                    trEligible.Visible = true;
                    TextBox59.Focus();
                    if (rdeligibility.SelectedValue == "Regular")
                    {
                        if (rdlmv.SelectedValue == "NONLMV")
                        {
                            if (rdmenwomen.SelectedValue == "Men")
                            {
                                if (rdeligibility.SelectedValue == "Regular")
                                {
                                    TextBox59.Text = "35";
                                    txtTSSFCnorms423.Text = "0";
                                    TextBox59_TextChanged(sender, e);
                                    //txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                }

                            }
                            else if (rdmenwomen.SelectedValue == "Women")
                            {
                                if (rdeligibility.SelectedValue == "Regular")
                                {
                                    TextBox59.Text = "35";
                                    txtTSSFCnorms423.Text = "10";
                                    TextBox59_TextChanged(sender, e);
                                    //txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                }
                            }
                        }
                        else if (rdlmv.SelectedValue == "LMV")
                        {
                            if (rdmenwomen.SelectedValue == "Men")
                            {
                                if (rdeligibility.SelectedValue == "Regular")
                                {
                                    TextBox59.Text = "35";
                                    txtTSSFCnorms423.Text = "0";
                                    TextBox59_TextChanged(sender, e);
                                    //txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                }

                            }
                            else if (rdmenwomen.SelectedValue == "Women")
                            {
                                if (rdeligibility.SelectedValue == "Regular")
                                {
                                    TextBox59.Text = "35";
                                    txtTSSFCnorms423.Text = "10";
                                    TextBox59_TextChanged(sender, e);
                                    //txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                }
                            }
                        }
                        else if (rdlmv.SelectedValue == "GENERAL")
                        {
                            if (rdmenwomen.SelectedValue == "Men")
                            {
                                if (rdeligibility.SelectedValue == "Regular")
                                {
                                    TextBox59.Text = "15";
                                    txtTSSFCnorms423.Text = "0";
                                    TextBox59_TextChanged(sender, e);
                                    //txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                }

                            }
                            else if (rdmenwomen.SelectedValue == "Women")
                            {
                                if (rdeligibility.SelectedValue == "Regular")
                                {
                                    TextBox59.Text = "15";
                                    txtTSSFCnorms423.Text = "10";
                                    TextBox59_TextChanged(sender, e);
                                    //txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                }
                            }
                        }
                    }
                    else if (rdeligibility.SelectedValue == "Belated")
                    {
                        if (rdlmv.SelectedValue == "NONLMV")
                        {
                            if (rdmenwomen.SelectedValue == "Men")
                            {
                                // txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                TextBox59.Text = "17.5";
                                txtTSSFCnorms423.Text = "0";
                                TextBox59_TextChanged(sender, e);
                            }
                            else if (rdmenwomen.SelectedValue == "Women")
                            {
                                // txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                TextBox59.Text = "17.5";
                                txtTSSFCnorms423.Text = "5";
                                TextBox59_TextChanged(sender, e);
                            }
                        }
                        else if (rdlmv.SelectedValue == "LMV")
                        {
                            if (rdmenwomen.SelectedValue == "Men")
                            {
                                // txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                TextBox59.Text = "17.5";
                                txtTSSFCnorms423.Text = "0";
                                TextBox59_TextChanged(sender, e);
                            }
                            else if (rdmenwomen.SelectedValue == "Women")
                            {
                                // txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                TextBox59.Text = "17.5";
                                txtTSSFCnorms423.Text = "5";
                                TextBox59_TextChanged(sender, e);
                            }
                        }
                        else if (rdlmv.SelectedValue == "GENERAL")
                        {
                            if (rdmenwomen.SelectedValue == "Men")
                            {
                                // txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                TextBox59.Text = "7.5";
                                txtTSSFCnorms423.Text = "0";
                                TextBox59_TextChanged(sender, e);
                            }
                            else if (rdmenwomen.SelectedValue == "Women")
                            {
                                // txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                TextBox59.Text = "7.5";
                                txtTSSFCnorms423.Text = "2.5";
                                TextBox59_TextChanged(sender, e);
                            }
                        }
                    }
                    else if (rdeligibility.SelectedValue == "OneYear")
                    {
                        if (rdlmv.SelectedValue == "NONLMV")
                        {
                            if (rdmenwomen.SelectedValue == "Men")
                            {
                                //txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                TextBox59.Text = "0";
                                txtTSSFCnorms423.Text = "0";
                                TextBox59_TextChanged(sender, e);
                            }
                            else if (rdmenwomen.SelectedValue == "Women")
                            {
                                //txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                TextBox59.Text = "0";
                                txtTSSFCnorms423.Text = "0";
                                TextBox59_TextChanged(sender, e);
                            }
                        }
                        else if (rdlmv.SelectedValue == "LMV")
                        {
                            if (rdmenwomen.SelectedValue == "Men")
                            {
                                //txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                TextBox59.Text = "0";
                                txtTSSFCnorms423.Text = "0";
                                TextBox59_TextChanged(sender, e);
                            }
                            else if (rdmenwomen.SelectedValue == "Women")
                            {
                                //txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                TextBox59.Text = "0";
                                txtTSSFCnorms423.Text = "0";
                                TextBox59_TextChanged(sender, e);
                            }
                        }
                        else if (rdlmv.SelectedValue == "GENERAL")
                        {
                            if (rdmenwomen.SelectedValue == "Men")
                            {
                                //txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                TextBox59.Text = "0";
                                txtTSSFCnorms423.Text = "0";
                                TextBox59_TextChanged(sender, e);
                            }
                            else if (rdmenwomen.SelectedValue == "Women")
                            {
                                //txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                                TextBox59.Text = "0";
                                txtTSSFCnorms423.Text = "0";
                                TextBox59_TextChanged(sender, e);
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
            }

        }
        protected void TextBox59_TextChanged(object sender, EventArgs e)
        {
            if (TextBox59.Text != "" && TextBox57.Text != "" && TextBox58.Text != "" && TextBox45.Text != "")
            {
                if (rdlmv.SelectedValue == "NONLMV")
                {
                    if (rdmenwomen.SelectedValue == "Men")
                    {
                        if (rdeligibility.SelectedValue == "Regular")
                        {
                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                            txtTSSFCnorms423.Text = "0";
                        }
                        if (rdeligibility.SelectedValue == "Belated")
                        {
                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                            txtTSSFCnorms423.Text = "0";
                        }
                        if (rdeligibility.SelectedValue == "OneYear")
                        {
                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                            txtTSSFCnorms423.Text = "0";
                        }
                    }
                    else if (rdmenwomen.SelectedValue == "Women")
                    {
                        if (rdeligibility.SelectedValue == "Regular")
                        {
                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                            txtTSSFCnorms423.Text = (((Convert.ToDecimal(TextBox2.Text)) * 10) / 100).ToString();
                            if (Convert.ToDecimal(txtTSSFCnorms423.Text) >= 1000000)
                            {
                                txtTSSFCnorms423.Text = "1000000";
                            }

                        }
                        if (rdeligibility.SelectedValue == "Belated")
                        {
                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                            txtTSSFCnorms423.Text = (((Convert.ToDecimal(TextBox2.Text)) * 5) / 100).ToString();
                            if (Convert.ToDecimal(txtTSSFCnorms423.Text) >= 1000000)
                            {
                                txtTSSFCnorms423.Text = "500000";
                            }
                        }
                        if (rdeligibility.SelectedValue == "OneYear")
                        {
                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                            txtTSSFCnorms423.Text = (((Convert.ToDecimal(TextBox2.Text)) * 10) / 100).ToString();
                            if (Convert.ToDecimal(txtTSSFCnorms423.Text) >= 1000000)
                            {
                                txtTSSFCnorms423.Text = "0";
                            }
                        }
                    }
                }
                else if (rdlmv.SelectedValue == "LMV")
                {
                    if (rdmenwomen.SelectedValue == "Men")
                    {
                        if (rdeligibility.SelectedValue == "Regular")
                        {
                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                            txtTSSFCnorms423.Text = "0";
                        }
                        if (rdeligibility.SelectedValue == "Belated")
                        {
                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                            txtTSSFCnorms423.Text = "0";
                        }
                        if (rdeligibility.SelectedValue == "OneYear")
                        {
                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                            txtTSSFCnorms423.Text = "0";
                        }
                    }
                    else if (rdmenwomen.SelectedValue == "Women")
                    {
                        if (rdeligibility.SelectedValue == "Regular")
                        {
                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                            txtTSSFCnorms423.Text = (((Convert.ToDecimal(TextBox2.Text)) * 10) / 100).ToString();
                            if (Convert.ToDecimal(txtTSSFCnorms423.Text) >= 1000000)
                            {
                                txtTSSFCnorms423.Text = "1000000";
                            }
                        }
                        if (rdeligibility.SelectedValue == "Belated")
                        {
                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                            txtTSSFCnorms423.Text = (((Convert.ToDecimal(TextBox2.Text)) * 5) / 100).ToString();
                            if (Convert.ToDecimal(txtTSSFCnorms423.Text) >= 800000)
                            {
                                txtTSSFCnorms423.Text = "1000000";
                            }
                        }
                        if (rdeligibility.SelectedValue == "OneYear")
                        {
                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                            txtTSSFCnorms423.Text = (((Convert.ToDecimal(TextBox2.Text)) * 10) / 100).ToString();
                            if (Convert.ToDecimal(txtTSSFCnorms423.Text) >= 800000)
                            {
                                txtTSSFCnorms423.Text = "0";
                            }
                        }
                    }

                }
                else if (rdlmv.SelectedValue == "GENERAL")
                {
                    if (rdmenwomen.SelectedValue == "Men")
                    {
                        if (rdeligibility.SelectedValue == "Regular")
                        {
                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                            txtTSSFCnorms423.Text = "0";
                            if (Convert.ToDecimal(txt423guideline.Text) >= 2000000)
                            {
                                txt423guideline.Text = "2000000";
                            }
                        }
                        if (rdeligibility.SelectedValue == "Belated")
                        {
                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                            txtTSSFCnorms423.Text = "0";
                            if (Convert.ToDecimal(txt423guideline.Text) >= 1000000)
                            {
                                txt423guideline.Text = "1000000";
                            }
                        }
                        if (rdeligibility.SelectedValue == "OneYear")
                        {
                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                            txtTSSFCnorms423.Text = "0";
                        }
                    }
                    else if (rdmenwomen.SelectedValue == "Women")
                    {
                        if (rdeligibility.SelectedValue == "Regular")
                        {
                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                            txtTSSFCnorms423.Text = (((Convert.ToDecimal(TextBox2.Text)) * 10) / 100).ToString();
                            if (Convert.ToDecimal(txt423guideline.Text) >= 2000000)
                            {
                                txt423guideline.Text = "2000000";
                            }

                            if (Convert.ToDecimal(txtTSSFCnorms423.Text) >= 1000000)
                            {
                                txtTSSFCnorms423.Text = "1000000";
                            }
                        }
                        if (rdeligibility.SelectedValue == "Belated")
                        {
                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                            txtTSSFCnorms423.Text = (((Convert.ToDecimal(TextBox2.Text)) * 5) / 100).ToString();
                            if (Convert.ToDecimal(txt423guideline.Text) >= 1000000)
                            {
                                txt423guideline.Text = "1000000";
                            }
                            if (Convert.ToDecimal(txtTSSFCnorms423.Text) >= 500000)
                            {
                                txtTSSFCnorms423.Text = "500000";
                            }
                        }
                        if (rdeligibility.SelectedValue == "OneYear")
                        {
                            txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();
                            txtTSSFCnorms423.Text = (((Convert.ToDecimal(TextBox2.Text)) * 10) / 100).ToString();
                            if (Convert.ToDecimal(txtTSSFCnorms423.Text) >= 800000)
                            {
                                txtTSSFCnorms423.Text = "0";
                            }
                        }
                    }

                }
                //txt423guideline.Text = (((Convert.ToDecimal(TextBox2.Text)) * Convert.ToDecimal(TextBox59.Text)) / 100).ToString();

                //if (lblAllwomen.Value.ToString() == "Y")
                //{
                //    txtTSSFCnorms423.Text = (((Convert.ToDecimal(TextBox2.Text)) * 10) / 100).ToString();
                //    if (Convert.ToDecimal(txtTSSFCnorms423.Text) >= 1000000)
                //    {
                //        txtTSSFCnorms423.Text = "1000000";
                //    }
                //}
                //else
                //{
                //    txtTSSFCnorms423.Text = "0";
                //}


                txtvalue424.Text = (Convert.ToDecimal(txtTSSFCnorms423.Text) + Convert.ToDecimal(txt423guideline.Text)).ToString();
                if (rdlmv.SelectedValue == "LMV")
                {
                    if (Convert.ToDecimal(txtvalue424.Text) >= 800000)
                    {
                        txtvalue424.Text = "800000";
                        txtvalue424.Enabled = false;
                    }
                }
                else if (rdlmv.SelectedValue == "NONLMV")
                {
                    if (Convert.ToDecimal(txtvalue424.Text) >= 7500000)
                    {
                        txtvalue424.Text = "7500000";
                    }
                }
                else if (rdlmv.SelectedValue == "GENERAL")
                {
                    if (Convert.ToDecimal(txtvalue424.Text) >= 3000000)
                    {
                        txtvalue424.Text = "3000000";
                    }
                }


            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please enter all the details in Abstract - Computed as eligible investment');", true);
                TextBox59.Text = "";
            }
        }
        public string ValidateControls()
        {
            int slno = 1;
            string ErrorMsg = "";
             
            if (TextBox33.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Landas per approved costs \\n";
                slno = slno + 1;
            }
            if (TextBox37.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Buildingas per approved costs \\n";
                slno = slno + 1;
            }
            if (TextBox41.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Plant and Machineryas per approved costs \\n";
                slno = slno + 1;
            }
            if (TextBox44.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Technical Know-how feasibility studyas per approved costs \\n";
                slno = slno + 1;
            }
            if (TextBox56.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computed as eligible Investment \\n";
                slno = slno + 1;
            }
            if (TextBox57.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computed as eligible Investment \\n";
                slno = slno + 1;
            }
            if (TextBox58.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computed as eligible Investment \\n";
                slno = slno + 1;
            }
            if (TextBox45.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter all values of Computed as eligible Investment \\n";
                slno = slno + 1;
            } 


            if (rdlmv.SelectedValue.TrimStart().TrimEnd().Trim() == "" || rdlmv.SelectedValue.TrimStart().TrimEnd().Trim() == "0" || rdlmv.SelectedValue.TrimStart().TrimEnd().Trim() == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select LMV/Non LMV \\n";
                slno = slno + 1;
            }

            if (rdmenwomen.SelectedValue.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Men or Women \\n";
                slno = slno + 1;
            }

            if (rdeligibility.SelectedValue.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select type of Eligiblity \\n";
                slno = slno + 1;
            }

            return ErrorMsg;
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            ValidateControls();
            if (save())
            {
                string message = "alert('Appraisal note submitted successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                //..btn
                BtnSave.Enabled = false;
                BtnSave.Visible = false;
                Response.Redirect("ClerkDashboard.aspx");
            }
        }
        public bool save()
        {
            UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
            ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

            ApprasialProperties objApprasialProperties = new ApprasialProperties();
            bool status = true;
            try
            {
                // TextBox txt_Eligibleamount = new TextBox();
                //objApprasialProperties.FINALELIGIBLEAMOUNT = Convert.ToDecimal(txt_Eligibleamount.Text);
                //AssignValuestoVosFromcontrols();
                objApprasialProperties.INCENTIVEID = txtIncID.Text;
                objApprasialProperties.NAMEOFINDUSTRIAL = lblUnitName.InnerText;
                objApprasialProperties.LOCATIONOFINDUSTRIAL = lblAddress.InnerText;
                objApprasialProperties.NAMEOFPROMOTER = lblUnitName.InnerText;
                objApprasialProperties.ConstitutionOFINDUSTRIAL = lblOrganization.InnerText;
                objApprasialProperties.SOCIALSTATUS = lblSocialStatus.InnerText;
                objApprasialProperties.WOMENENTERPRENEUR = lblShareofSCSTWomenEnterprenue.InnerText;
                objApprasialProperties.PMTSSIREGISTRATIONNO = lblRegistrationNumber.InnerText;
                objApprasialProperties.PMTSSIREGISTRATIONDATE = lblReceiptDate.InnerText;
                objApprasialProperties.NED_UNIT = lblCategoryofUnit.InnerText;
                objApprasialProperties.DATEOFPRODUCTION = lblDCPdate.InnerText;
                objApprasialProperties.DICFILLINGDATE = lblReceiptDate.InnerText;
                objApprasialProperties.NAMEFINANCINGUNIT = lblUnitName.InnerText;
                objApprasialProperties.CASTE = lblSocialStatus.InnerText;
                objApprasialProperties.GENDER = lblSocialStatus.InnerText;
                objApprasialProperties.CATEGORY = lblCategoryofUnit.InnerText;
                objApprasialProperties.ENTERPRISE = lblTypeofApplicant.InnerText;
                objApprasialProperties.SECTOR = lblTypeofSector.InnerText;
                objApprasialProperties.CREATEDBY = ObjLoginNewvo.uid;
                objApprasialProperties.TextBox59 = TextBox59.Text;
                objApprasialProperties.txt423guideline = txt423guideline.Text;
                objApprasialProperties.txtTSSFCnorms423 = txtTSSFCnorms423.Text;
                objApprasialProperties.txtvalue424 = txtvalue424.Text;
                objApprasialProperties.lmv = rdlmv.SelectedValue;
                objApprasialProperties.womenmen = rdmenwomen.SelectedValue;
                objApprasialProperties.ELIGIBLETYPE = rdeligibility.SelectedValue;
                objApprasialProperties.Remarks = txtremarks.Text;
                objApprasialProperties.SUBINCENTIVEID = Request.QueryString["MstIncentiveId"].ToString();
                objApprasialProperties.Scheme = "TTAP";
                string returnval = "0";
                returnval = ObjCAFClass.InterestSubsidyCommonDetails(objApprasialProperties);
                if (!string.IsNullOrEmpty(returnval) && returnval.Trim() != "")
                { 
                    string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
                    DLOApplication DLODetails = new DLOApplication();
                    if (txtvalue424.Text != "")
                    {
                        DLODetails.RECOMMENDEAMOUNT = objApprasialProperties.txtvalue424;
                    }
                    else
                    {
                        DLODetails.RECOMMENDEAMOUNT = Convert.ToString(objApprasialProperties.FINALELIGIBLEAMOUNT);
                    }

                    DLODetails.INCENTIVEID = txtIncID.Text;
                    DLODetails.SUBINCENTIVEID = "3";
                    DLODetails.ACTIONID = "1";
                    DLODetails.FORWARDTO = ddlDepartment.SelectedItem.Text;
                    DLODetails.CREATEDBY = ObjLoginNewvo.uid;


                    string result = ObjCAFClass.InsertClerkDetails(DLODetails);

                    if (result == "1")
                    {
                        lblmsg.Text = "Application Process Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Application Process Submitted Successfully.');", true);

                    }

                }
                else
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Appraisal note submitted.');", true);
                    //ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "message", message, true);
                    //return false;
                    status = false;
                }
            }
            catch (Exception ex)
            {

            }
            return status;
        }
        protected void BtnClearall_Click(object sender, EventArgs e)
        {
            this.Page_Load(null, null);
        }

        protected void btm_previous_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClerkDashboard.aspx");

        }

        protected void BtnSave3_Click(object sender, EventArgs e)
        {

        }
    }
}