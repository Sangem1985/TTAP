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
    public partial class PowerSubsidyAppraisalNote : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        CAFClass ObjCAFClass = new CAFClass();
        AppraisalClass objappraisalClass = new AppraisalClass();
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
                        if (Request.QueryString["IncentiveID"] != null)
                        {
                            incentiveid = Request.QueryString["IncentiveID"].ToString();
                        }
                        txtIncID.Text = incentiveid;
                        BindBesicdata(incentiveid, "4", "");
                        GetClaimPeriod(incentiveid, "4");
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
                        divNewUnit.Visible = true;
                    }
                    else
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCPExp"].ToString();
                        divLastThreeDtls.Visible = true;
                        divExpansionDtls.Visible = true;
                        dixExpansion.Visible = true;
                        BindLastThreeYrs(Convert.ToDateTime(dsnew.Tables[0].Rows[0]["DCPExp"].ToString()).ToString("yyyy/MM/dd"));
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
                    lblGMAmount.InnerText= dsnew.Tables[1].Rows[0]["OfficerRecommendedAmount"].ToString();

                }
            }
            catch (Exception ex)
            { }
        }
        public void GetClaimPeriod(string IncentiveID, string SubIncentiveId)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = objappraisalClass.GetCliamPeroid(IncentiveID, SubIncentiveId);
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    lblClaimPeroid.Text = dsnew.Tables[0].Rows[0]["ClaimPeriod"].ToString();
                    if (hdnTypeOfIndustry.Value == "1")
                    {   
                        txtMonth1.Text = dsnew.Tables[1].Rows[0][0].ToString();
                        txtMonth2.Text = dsnew.Tables[1].Rows[1][0].ToString();
                        txtMonth3.Text = dsnew.Tables[1].Rows[2][0].ToString();
                        txtMonth4.Text = dsnew.Tables[1].Rows[3][0].ToString();
                        txtMonth5.Text = dsnew.Tables[1].Rows[4][0].ToString();
                        txtMonth6.Text = dsnew.Tables[1].Rows[5][0].ToString();

                        txtYear1.Text = dsnew.Tables[1].Rows[0][2].ToString();
                        txtYear2.Text = dsnew.Tables[1].Rows[1][2].ToString();
                        txtYear3.Text = dsnew.Tables[1].Rows[2][2].ToString();
                        txtYear4.Text = dsnew.Tables[1].Rows[3][2].ToString();
                        txtYear5.Text = dsnew.Tables[1].Rows[4][2].ToString();
                        txtYear6.Text = dsnew.Tables[1].Rows[5][2].ToString();
                    }
                    else 
                    {
                        txtMonthExp1.Text = dsnew.Tables[1].Rows[0][0].ToString();
                        txtMonthExp2.Text = dsnew.Tables[1].Rows[1][0].ToString();
                        txtMonthExp3.Text = dsnew.Tables[1].Rows[2][0].ToString();
                        txtMonthExp4.Text = dsnew.Tables[1].Rows[3][0].ToString();
                        txtMonthExp5.Text = dsnew.Tables[1].Rows[4][0].ToString();
                        txtMonthExp6.Text = dsnew.Tables[1].Rows[5][0].ToString();

                        txtYearExp1.Text = dsnew.Tables[1].Rows[0][2].ToString();
                        txtYearExp2.Text = dsnew.Tables[1].Rows[1][2].ToString();
                        txtYearExp3.Text = dsnew.Tables[1].Rows[2][2].ToString();
                        txtYearExp4.Text = dsnew.Tables[1].Rows[3][2].ToString();
                        txtYearExp5.Text = dsnew.Tables[1].Rows[4][2].ToString();
                        txtYearExp6.Text = dsnew.Tables[1].Rows[5][2].ToString();
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        protected void rdbTypeofTextile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((rdbTypeofTextile.SelectedValue.ToString() != null && rdbTypeofTextile.SelectedValue.ToString() != "")
                && (rdbCategory.SelectedValue.ToString() != null && rdbCategory.SelectedValue.ToString() != ""))
            {
                string Type = rdbTypeofTextile.SelectedValue.ToString();
                string Category = rdbCategory.SelectedValue.ToString();
                if (ddlNature.SelectedValue.ToString() == "Ginning")
                {
                    if (hdnTypeOfIndustry.Value == "1")
                    {
                        txtEligibleRate1.Text = "1";
                        txtEligibleRate2.Text = "1";
                        txtEligibleRate3.Text = "1";
                        txtEligibleRate4.Text = "1";
                        txtEligibleRate5.Text = "1";
                        txtEligibleRate6.Text = "1";
                    }
                    else 
                    {
                        txtEligibleRateExp1.Text = "1";
                        txtEligibleRateExp2.Text = "1";
                        txtEligibleRateExp3.Text = "1";
                        txtEligibleRateExp4.Text = "1";
                        txtEligibleRateExp5.Text = "1";
                        txtEligibleRateExp6.Text = "1";
                    }
                }
                else
                {
                    if (Type == "1")
                    {
                        if (Category == "A1" || Category == "A2")
                        {
                            if (hdnTypeOfIndustry.Value == "1")
                            {
                                txtEligibleRate1.Text = "1";
                                txtEligibleRate2.Text = "1";
                                txtEligibleRate3.Text = "1";
                                txtEligibleRate4.Text = "1";
                                txtEligibleRate5.Text = "1";
                                txtEligibleRate6.Text = "1";
                            }
                            else 
                            {
                                txtEligibleRateExp1.Text = "1";
                                txtEligibleRateExp2.Text = "1";
                                txtEligibleRateExp3.Text = "1";
                                txtEligibleRateExp4.Text = "1";
                                txtEligibleRateExp5.Text = "1";
                                txtEligibleRateExp6.Text = "1";
                            }
                        }
                        if (Category == "A3")
                        {
                            if (hdnTypeOfIndustry.Value == "1")
                            {
                                txtEligibleRate1.Text = "1.5";
                                txtEligibleRate2.Text = "1.5";
                                txtEligibleRate3.Text = "1.5";
                                txtEligibleRate4.Text = "1.5";
                                txtEligibleRate5.Text = "1.5";
                                txtEligibleRate6.Text = "1.5";
                            }
                            else 
                            {
                                txtEligibleRateExp1.Text = "1.5";
                                txtEligibleRateExp2.Text = "1.5";
                                txtEligibleRateExp3.Text = "1.5";
                                txtEligibleRateExp4.Text = "1.5";
                                txtEligibleRateExp5.Text = "1.5";
                                txtEligibleRateExp6.Text = "1.5";
                            }
                        }
                        if (Category == "A4")
                        {
                            if (hdnTypeOfIndustry.Value == "1")
                            {
                                txtEligibleRate1.Text = "1.75";
                                txtEligibleRate2.Text = "1.75";
                                txtEligibleRate3.Text = "1.75";
                                txtEligibleRate4.Text = "1.75";
                                txtEligibleRate5.Text = "1.75";
                                txtEligibleRate6.Text = "1.75";
                            }
                            else 
                            {
                                txtEligibleRateExp1.Text = "1.75";
                                txtEligibleRateExp2.Text = "1.75";
                                txtEligibleRateExp3.Text = "1.75";
                                txtEligibleRateExp4.Text = "1.75";
                                txtEligibleRateExp5.Text = "1.75";
                                txtEligibleRateExp6.Text = "1.75";
                            }
                        }
                        if (Category == "A5")
                        {
                            if (hdnTypeOfIndustry.Value == "1")
                            {
                                txtEligibleRate1.Text = "2";
                                txtEligibleRate2.Text = "2";
                                txtEligibleRate3.Text = "2";
                                txtEligibleRate4.Text = "2";
                                txtEligibleRate5.Text = "2";
                                txtEligibleRate6.Text = "2";
                            }
                            else
                            {
                                txtEligibleRateExp1.Text = "2";
                                txtEligibleRateExp2.Text = "2";
                                txtEligibleRateExp3.Text = "2";
                                txtEligibleRateExp4.Text = "2";
                                txtEligibleRateExp5.Text = "2";
                                txtEligibleRateExp6.Text = "2";
                            }
                        }
                    }
                    else
                    {
                        if (Category == "A1" || Category == "A2")
                        {
                            if (hdnTypeOfIndustry.Value == "1")
                            {
                                txtEligibleRate1.Text = "1.50";
                                txtEligibleRate2.Text = "1.50";
                                txtEligibleRate3.Text = "1.50";
                                txtEligibleRate4.Text = "1.50";
                                txtEligibleRate5.Text = "1.50";
                                txtEligibleRate6.Text = "1.50";
                            }
                            else
                            {
                                txtEligibleRateExp1.Text = "1.50";
                                txtEligibleRateExp2.Text = "1.50";
                                txtEligibleRateExp3.Text = "1.50";
                                txtEligibleRateExp4.Text = "1.50";
                                txtEligibleRateExp5.Text = "1.50";
                                txtEligibleRateExp6.Text = "1.50";
                            }
                        }
                        if (Category == "A3")
                        {
                            if (hdnTypeOfIndustry.Value == "1")
                            {
                                txtEligibleRate1.Text = "2";
                                txtEligibleRate2.Text = "2";
                                txtEligibleRate3.Text = "2";
                                txtEligibleRate4.Text = "2";
                                txtEligibleRate5.Text = "2";
                                txtEligibleRate6.Text = "2";
                            }
                            else
                            {
                                txtEligibleRateExp1.Text = "2";
                                txtEligibleRateExp2.Text = "2";
                                txtEligibleRateExp3.Text = "2";
                                txtEligibleRateExp4.Text = "2";
                                txtEligibleRateExp5.Text = "2";
                                txtEligibleRateExp6.Text = "2";
                            }
                        }
                        if (Category == "A4")
                        {
                            if (hdnTypeOfIndustry.Value == "1")
                            {
                                txtEligibleRate1.Text = "2.25";
                                txtEligibleRate2.Text = "2.25";
                                txtEligibleRate3.Text = "2.25";
                                txtEligibleRate4.Text = "2.25";
                                txtEligibleRate5.Text = "2.25";
                                txtEligibleRate6.Text = "2.25";
                            }
                            else 
                            {
                                txtEligibleRateExp1.Text = "2.25";
                                txtEligibleRateExp2.Text = "2.25";
                                txtEligibleRateExp3.Text = "2.25";
                                txtEligibleRateExp4.Text = "2.25";
                                txtEligibleRateExp5.Text = "2.25";
                                txtEligibleRateExp6.Text = "2.25";
                            }
                        }
                        if (Category == "A5")
                        {
                            if (hdnTypeOfIndustry.Value == "1")
                            {
                                txtEligibleRate1.Text = "2.50";
                                txtEligibleRate2.Text = "2.50";
                                txtEligibleRate3.Text = "2.50";
                                txtEligibleRate4.Text = "2.50";
                                txtEligibleRate5.Text = "2.50";
                                txtEligibleRate6.Text = "2.50";
                            }
                            else 
                            {
                                txtEligibleRateExp1.Text = "2.50";
                                txtEligibleRateExp2.Text = "2.50";
                                txtEligibleRateExp3.Text = "2.50";
                                txtEligibleRateExp4.Text = "2.50";
                                txtEligibleRateExp5.Text = "2.50";
                                txtEligibleRateExp6.Text = "2.50";
                            }
                        }
                    }
                }
                CalculateElgibleAmount(this, EventArgs.Empty);
            }
        }

        protected void CalculateElgibleAmount(object sender, EventArgs e)
        {
            if ((rdbTypeofTextile.SelectedValue.ToString() != null && rdbTypeofTextile.SelectedValue.ToString() != "")
                && (rdbCategory.SelectedValue.ToString() != null && rdbCategory.SelectedValue.ToString() != ""))
            {
                string EUnits1 = "0", EUnits2 = "0", EUnits3 = "0", EUnits4 = "0", EUnits5 = "0", EUnits6 = "0";
                string BUnits1 = "0", BUnits2 = "0", BUnits3 = "0", BUnits4 = "0", BUnits5 = "0", BUnits6 = "0";
                if (hdnTypeOfIndustry.Value == "1")
                {
                    if (txtUnitsConsumed1.Text != "") { EUnits1 = txtUnitsConsumed1.Text.ToString(); }
                    if (txtUnitsConsumed2.Text != "") { EUnits2 = txtUnitsConsumed2.Text.ToString(); }
                    if (txtUnitsConsumed3.Text != "") { EUnits3 = txtUnitsConsumed3.Text.ToString(); }
                    if (txtUnitsConsumed4.Text != "") { EUnits4 = txtUnitsConsumed4.Text.ToString(); }
                    if (txtUnitsConsumed5.Text != "") { EUnits5 = txtUnitsConsumed5.Text.ToString(); }
                    if (txtUnitsConsumed6.Text != "") { EUnits6 = txtUnitsConsumed6.Text.ToString(); }

                    txtEligibleAmount1.Text = (Convert.ToDecimal(EUnits1) * (Convert.ToDecimal(txtEligibleRate1.Text.ToString()))).ToString();
                    txtEligibleAmount2.Text = (Convert.ToDecimal(EUnits2) * (Convert.ToDecimal(txtEligibleRate2.Text.ToString()))).ToString();
                    txtEligibleAmount3.Text = (Convert.ToDecimal(EUnits3) * (Convert.ToDecimal(txtEligibleRate3.Text.ToString()))).ToString();
                    txtEligibleAmount4.Text = (Convert.ToDecimal(EUnits4) * (Convert.ToDecimal(txtEligibleRate4.Text.ToString()))).ToString();
                    txtEligibleAmount5.Text = (Convert.ToDecimal(EUnits5) * (Convert.ToDecimal(txtEligibleRate5.Text.ToString()))).ToString();
                    txtEligibleAmount6.Text = (Convert.ToDecimal(EUnits6) * (Convert.ToDecimal(txtEligibleRate6.Text.ToString()))).ToString();

                    lblTotalAmount.Text = (Convert.ToDecimal(txtEligibleAmount1.Text.ToString()) + Convert.ToDecimal(txtEligibleAmount2.Text.ToString()) + Convert.ToDecimal(txtEligibleAmount3.Text.ToString()) +
                        Convert.ToDecimal(txtEligibleAmount4.Text.ToString()) + Convert.ToDecimal(txtEligibleAmount5.Text.ToString()) + Convert.ToDecimal(txtEligibleAmount6.Text.ToString())).ToString();
                }
                else 
                {
                    if (txtUnitsConsumedExp1.Text != "") { EUnits1 = txtUnitsConsumedExp1.Text.ToString(); }
                    if (txtUnitsConsumedExp2.Text != "") { EUnits2 = txtUnitsConsumedExp2.Text.ToString(); }
                    if (txtUnitsConsumedExp3.Text != "") { EUnits3 = txtUnitsConsumedExp3.Text.ToString(); }
                    if (txtUnitsConsumedExp4.Text != "") { EUnits4 = txtUnitsConsumedExp4.Text.ToString(); }
                    if (txtUnitsConsumedExp5.Text != "") { EUnits5 = txtUnitsConsumedExp5.Text.ToString(); }
                    if (txtUnitsConsumedExp6.Text != "") { EUnits6 = txtUnitsConsumedExp6.Text.ToString(); }

                    if (txtBaseFixedExp1.Text != "") { BUnits1 = txtBaseFixedExp1.Text.ToString(); }
                    if (txtBaseFixedExp2.Text != "") { BUnits2 = txtBaseFixedExp2.Text.ToString(); }
                    if (txtBaseFixedExp3.Text != "") { BUnits3 = txtBaseFixedExp3.Text.ToString(); }
                    if (txtBaseFixedExp4.Text != "") { BUnits4 = txtBaseFixedExp4.Text.ToString(); }
                    if (txtBaseFixedExp5.Text != "") { BUnits5 = txtBaseFixedExp5.Text.ToString(); }
                    if (txtBaseFixedExp6.Text != "") { BUnits6 = txtBaseFixedExp6.Text.ToString(); }

                    txtEligibleUnitsBaseExp1.Text = (Convert.ToDecimal(EUnits1) - Convert.ToDecimal(BUnits1)).ToString();
                    txtEligibleUnitsBaseExp2.Text = (Convert.ToDecimal(EUnits2) - Convert.ToDecimal(BUnits2)).ToString();
                    txtEligibleUnitsBaseExp3.Text = (Convert.ToDecimal(EUnits3) - Convert.ToDecimal(BUnits3)).ToString();
                    txtEligibleUnitsBaseExp4.Text = (Convert.ToDecimal(EUnits4) - Convert.ToDecimal(BUnits4)).ToString();
                    txtEligibleUnitsBaseExp5.Text = (Convert.ToDecimal(EUnits5) - Convert.ToDecimal(BUnits5)).ToString();
                    txtEligibleUnitsBaseExp6.Text = (Convert.ToDecimal(EUnits6) - Convert.ToDecimal(BUnits6)).ToString();

                    string TA1 = txtEligibleAmountExp1.Text = (Convert.ToDecimal(txtEligibleUnitsBaseExp1.Text) * Convert.ToDecimal(txtEligibleRateExp1.Text)).ToString();
                    string TA2 = txtEligibleAmountExp2.Text = (Convert.ToDecimal(txtEligibleUnitsBaseExp2.Text) * Convert.ToDecimal(txtEligibleRateExp2.Text)).ToString();
                    string TA3 = txtEligibleAmountExp3.Text = (Convert.ToDecimal(txtEligibleUnitsBaseExp3.Text) * Convert.ToDecimal(txtEligibleRateExp3.Text)).ToString();
                    string TA4 = txtEligibleAmountExp4.Text = (Convert.ToDecimal(txtEligibleUnitsBaseExp4.Text) * Convert.ToDecimal(txtEligibleRateExp4.Text)).ToString();
                    string TA5 = txtEligibleAmountExp5.Text = (Convert.ToDecimal(txtEligibleUnitsBaseExp5.Text) * Convert.ToDecimal(txtEligibleRateExp5.Text)).ToString();
                    string TA6 = txtEligibleAmountExp6.Text = (Convert.ToDecimal(txtEligibleUnitsBaseExp6.Text) * Convert.ToDecimal(txtEligibleRateExp6.Text)).ToString();

                    lblTotalAmount.Text = (Convert.ToDecimal(TA1) + Convert.ToDecimal(TA2) + Convert.ToDecimal(TA3) + Convert.ToDecimal(TA4) +
                        Convert.ToDecimal(TA5) + Convert.ToDecimal(TA6)).ToString();
                }
            }
        }

        protected void rdbEligibleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lblTotalAmount.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please Calculate Total Amount !');", true);
                return;
            }
            else
            {
                if (rdbEligibleType.SelectedValue != null || rdbEligibleType.SelectedValue != "")
                {
                    if (rdbEligibleType.SelectedValue.ToString() == "1")
                    {
                        lblEligibleAmount.Text = lblTotalAmount.Text.ToString();
                    }
                    if (rdbEligibleType.SelectedValue.ToString() == "2")
                    {
                        string ElgAmount = "";
                        ElgAmount = (Convert.ToDecimal(lblTotalAmount.Text.ToString()) / 2).ToString();
                        lblEligibleAmount.Text = ElgAmount;
                    }
                    if (rdbEligibleType.SelectedValue.ToString() == "3")
                    {
                        lblEligibleAmount.Text = "0";
                    }
                    decimal Val1 = (decimal)Convert.ToDecimal(lblEligibleAmount.Text.ToString());
                    decimal Val2 = (decimal)Convert.ToDecimal(lblGMAmount.InnerText.ToString());
                    decimal minValue = Math.Min(Val1, Val2);
                    lblFinalElgAmount.Text = minValue.ToString();
                }
            }
        }

        protected void ddlNature_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
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
                    string message = "alert('Appraisal Note submitted successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    btnSubmit.Visible = false;
                }
                else 
                {
                    string message = "alert('Failed to Submit')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
        }
        public string ValidateControls()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (rdbTypeofTextile.SelectedValue.ToString() == "" || rdbTypeofTextile.SelectedValue.ToString() == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Type of Textile as per Inspection \\n";
                slno = slno + 1;
            }
            if (rdbCategory.SelectedValue.ToString() == "" || rdbCategory.SelectedValue.ToString() == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Category as per Inspection \\n";
                slno = slno + 1;
            }
            if (ddlNature.SelectedValue.ToString() == "" || rdbCategory.SelectedValue.ToString() == null)
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Nature of Industry as per Inspection \\n";
                slno = slno + 1;
            }
            if (hdnTypeOfIndustry.Value == "1")
            {
                if (txtUnitsConsumed1.Text == "" || txtUnitsConsumed2.Text == "" || txtUnitsConsumed3.Text == "" || txtUnitsConsumed4.Text == ""
                || txtUnitsConsumed5.Text == "" || txtUnitsConsumed6.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter all Months of Units Consumed \\n";
                    slno = slno + 1;
                }
                if (txtAmountPaid1.Text == "" || txtAmountPaid2.Text == "" || txtAmountPaid3.Text == "" || txtAmountPaid4.Text == ""
                    || txtAmountPaid5.Text == "" || txtAmountPaid6.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter all Months of Amount Paid as per Bill  \\n";
                    slno = slno + 1;
                }
                if (txtEligibleRate1.Text == "" || txtEligibleRate2.Text == "" || txtEligibleRate3.Text == "" || txtEligibleRate4.Text == ""
                    || txtEligibleRate5.Text == "" || txtEligibleRate6.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter all Months of Eligible rate Re-Imbursement  \\n";
                    slno = slno + 1;
                }
                if (txtEligibleAmount1.Text == "" || txtEligibleAmount2.Text == "" || txtEligibleAmount3.Text == "" || txtEligibleAmount4.Text == ""
                    || txtEligibleAmount5.Text == "" || txtEligibleAmount6.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter all Months of Eligible Amount Re-Imbursement  \\n";
                    slno = slno + 1;
                }
            }
            else 
            {
                if (txtUnitsConsumedExp1.Text == "" || txtUnitsConsumedExp2.Text == "" || txtUnitsConsumedExp3.Text == "" || txtUnitsConsumedExp4.Text == ""
                    || txtUnitsConsumedExp5.Text == "" || txtUnitsConsumedExp6.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter all Months of Units Consumed \\n";
                    slno = slno + 1;
                }
                if (txtAmountPaidExp1.Text == "" || txtAmountPaidExp2.Text == "" || txtAmountPaidExp3.Text == "" || txtAmountPaidExp4.Text == ""
                    || txtAmountPaidExp5.Text == "" || txtAmountPaidExp6.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter all Months of Amount Paid as per Bill  \\n";
                    slno = slno + 1;
                }
                if (txtEligibleRateExp1.Text == "" || txtEligibleRateExp2.Text == "" || txtEligibleRateExp3.Text == "" || txtEligibleRateExp4.Text == ""
                    || txtEligibleRateExp5.Text == "" || txtEligibleRateExp6.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter all Months of Eligible rate Re-Imbursement  \\n";
                    slno = slno + 1;
                }
                if (txtEligibleAmountExp1.Text == "" || txtEligibleAmountExp2.Text == "" || txtEligibleAmountExp3.Text == "" || txtEligibleAmountExp4.Text == ""
                    || txtEligibleAmountExp5.Text == "" || txtEligibleAmountExp6.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter all Months of Eligible Amount Re-Imbursement  \\n";
                    slno = slno + 1;
                }
                if (txtBaseFixedExp1.Text == "" || txtBaseFixedExp2.Text == "" || txtBaseFixedExp3.Text == "" || txtBaseFixedExp4.Text == ""
                    || txtBaseFixedExp5.Text == "" || txtBaseFixedExp6.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter all Months of Eligible Amount Re-Imbursement  \\n";
                    slno = slno + 1;
                }
                if (txtEligibleUnitsBaseExp1.Text == "" || txtEligibleUnitsBaseExp2.Text == "" || txtEligibleUnitsBaseExp3.Text == "" || txtEligibleUnitsBaseExp4.Text == ""
                    || txtEligibleUnitsBaseExp5.Text == "" || txtEligibleUnitsBaseExp6.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter all Months of Eligible Amount Re-Imbursement  \\n";
                    slno = slno + 1;
                }
                if (ddlFinYear1.SelectedValue == "0" || ddlFinYear2.SelectedValue == "0" || ddlFinYear3.SelectedValue == "0") 
                {
                    ErrorMsg = ErrorMsg + slno + ". Please select Financial Year in Last three Years details  \\n";
                    slno = slno + 1;
                }
                if (txtUtilizedUnits1.Text == "" || txtUtilizedUnits2.Text == "" || txtUtilizedUnits3.Text == "") 
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter No of Units Utilised Details in Last three Years details  \\n";
                    slno = slno + 1;
                }
                if (txtRatePerUnit1.Text == "" || txtRatePerUnit2.Text == "" || txtRatePerUnit3.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter Rate per Unit Details in Last three Years details  \\n";
                    slno = slno + 1;
                }
                if (txtTotalPaid1.Text == "" || txtTotalPaid2.Text == "" || txtTotalPaid3.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter Total Paid by the unit Details in Last three Years details  \\n";
                    slno = slno + 1;
                }
                if (txtPrior3Yrs.Text == "" || txtAvgUnitsEM.Text == "" || txtBasePower.Text == "" || txtPerMonth.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Calculate Total units consumed prior to 3 Years/Average units EM/Base power consumption fixed per year/Per month.  \\n";
                    slno = slno + 1;
                }
            }
            if (lblTotalAmount.Text == "" || lblEligibleAmount.Text == "" || lblGMAmount.InnerText == "" || lblFinalElgAmount.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please calculate Eligible Subsidy Amount By entering all required Details \\n";
                slno = slno + 1;
            }
            if (ddlDepartment.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select whom you want to forward this to. \\n";
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

                objApprasialProperties.TextileTypeAsPerInspection = rdbTypeofTextile.SelectedItem.Text.ToString();
                objApprasialProperties.CategoryAsPerInspection = rdbCategory.SelectedValue.ToString();
                objApprasialProperties.NatureAsPerInspection = ddlNature.SelectedValue.ToString();
                objApprasialProperties.CLAIMPERIOD = lblClaimPeroid.Text.ToString();
                
                if (hdnTypeOfIndustry.Value == "1")
                {
                    objApprasialProperties.FinancialYear = txtYear1.Text.ToString();
                    objApprasialProperties.Month1 = txtMonth1.Text.ToString();
                    objApprasialProperties.Month2 = txtMonth2.Text.ToString();
                    objApprasialProperties.Month3 = txtMonth3.Text.ToString();
                    objApprasialProperties.Month4 = txtMonth4.Text.ToString();
                    objApprasialProperties.Month5 = txtMonth5.Text.ToString();
                    objApprasialProperties.Month6 = txtMonth6.Text.ToString();

                    objApprasialProperties.UnitsConsumed1 = txtUnitsConsumed1.Text.ToString();
                    objApprasialProperties.UnitsConsumed2 = txtUnitsConsumed2.Text.ToString();
                    objApprasialProperties.UnitsConsumed3 = txtUnitsConsumed3.Text.ToString();
                    objApprasialProperties.UnitsConsumed4 = txtUnitsConsumed4.Text.ToString();
                    objApprasialProperties.UnitsConsumed5 = txtUnitsConsumed5.Text.ToString();
                    objApprasialProperties.UnitsConsumed6 = txtUnitsConsumed6.Text.ToString();

                    objApprasialProperties.PaidBillAmount1 = txtAmountPaid1.Text.ToString();
                    objApprasialProperties.PaidBillAmount2 = txtAmountPaid2.Text.ToString();
                    objApprasialProperties.PaidBillAmount3 = txtAmountPaid3.Text.ToString();
                    objApprasialProperties.PaidBillAmount4 = txtAmountPaid4.Text.ToString();
                    objApprasialProperties.PaidBillAmount5 = txtAmountPaid5.Text.ToString();
                    objApprasialProperties.PaidBillAmount6 = txtAmountPaid6.Text.ToString();

                    objApprasialProperties.EligibleRate1 = txtEligibleRate1.Text.ToString();
                    objApprasialProperties.EligibleRate2 = txtEligibleRate2.Text.ToString();
                    objApprasialProperties.EligibleRate3 = txtEligibleRate3.Text.ToString();
                    objApprasialProperties.EligibleRate4 = txtEligibleRate4.Text.ToString();
                    objApprasialProperties.EligibleRate5 = txtEligibleRate5.Text.ToString();
                    objApprasialProperties.EligibleRate6 = txtEligibleRate6.Text.ToString();

                    objApprasialProperties.EligibleAmount1 = txtEligibleAmount1.Text.ToString();
                    objApprasialProperties.EligibleAmount2 = txtEligibleAmount2.Text.ToString();
                    objApprasialProperties.EligibleAmount3 = txtEligibleAmount3.Text.ToString();
                    objApprasialProperties.EligibleAmount4 = txtEligibleAmount4.Text.ToString();
                    objApprasialProperties.EligibleAmount5 = txtEligibleAmount5.Text.ToString();
                    objApprasialProperties.EligibleAmount6 = txtEligibleAmount6.Text.ToString();
                }
                else 
                {
                    objApprasialProperties.FinancialYear = txtYearExp1.Text.ToString();
                    objApprasialProperties.Month1 = txtMonthExp1.Text.ToString();
                    objApprasialProperties.Month2 = txtMonthExp2.Text.ToString();
                    objApprasialProperties.Month3 = txtMonthExp3.Text.ToString();
                    objApprasialProperties.Month4 = txtMonthExp4.Text.ToString();
                    objApprasialProperties.Month5 = txtMonthExp5.Text.ToString();
                    objApprasialProperties.Month6 = txtMonthExp6.Text.ToString();

                    objApprasialProperties.UnitsConsumed1 = txtUnitsConsumedExp1.Text.ToString();
                    objApprasialProperties.UnitsConsumed2 = txtUnitsConsumedExp2.Text.ToString();
                    objApprasialProperties.UnitsConsumed3 = txtUnitsConsumedExp3.Text.ToString();
                    objApprasialProperties.UnitsConsumed4 = txtUnitsConsumedExp4.Text.ToString();
                    objApprasialProperties.UnitsConsumed5 = txtUnitsConsumedExp5.Text.ToString();
                    objApprasialProperties.UnitsConsumed6 = txtUnitsConsumedExp6.Text.ToString();

                    objApprasialProperties.PaidBillAmount1 = txtAmountPaidExp1.Text.ToString();
                    objApprasialProperties.PaidBillAmount2 = txtAmountPaidExp2.Text.ToString();
                    objApprasialProperties.PaidBillAmount3 = txtAmountPaidExp3.Text.ToString();
                    objApprasialProperties.PaidBillAmount4 = txtAmountPaidExp4.Text.ToString();
                    objApprasialProperties.PaidBillAmount5 = txtAmountPaidExp5.Text.ToString();
                    objApprasialProperties.PaidBillAmount6 = txtAmountPaidExp6.Text.ToString();

                    objApprasialProperties.EligibleRate1 = txtEligibleRateExp1.Text.ToString();
                    objApprasialProperties.EligibleRate2 = txtEligibleRateExp2.Text.ToString();
                    objApprasialProperties.EligibleRate3 = txtEligibleRateExp3.Text.ToString();
                    objApprasialProperties.EligibleRate4 = txtEligibleRateExp4.Text.ToString();
                    objApprasialProperties.EligibleRate5 = txtEligibleRateExp5.Text.ToString();
                    objApprasialProperties.EligibleRate6 = txtEligibleRateExp6.Text.ToString();

                    objApprasialProperties.EligibleAmount1 = txtEligibleAmountExp1.Text.ToString();
                    objApprasialProperties.EligibleAmount2 = txtEligibleAmountExp2.Text.ToString();
                    objApprasialProperties.EligibleAmount3 = txtEligibleAmountExp3.Text.ToString();
                    objApprasialProperties.EligibleAmount4 = txtEligibleAmountExp4.Text.ToString();
                    objApprasialProperties.EligibleAmount5 = txtEligibleAmountExp5.Text.ToString();
                    objApprasialProperties.EligibleAmount6 = txtEligibleAmountExp6.Text.ToString();
                }
                objApprasialProperties.BasefixedPerMonth1 = txtBaseFixedExp1.Text.ToString();
                objApprasialProperties.BasefixedPerMonth2 = txtBaseFixedExp2.Text.ToString();
                objApprasialProperties.BasefixedPerMonth3 = txtBaseFixedExp3.Text.ToString();
                objApprasialProperties.BasefixedPerMonth4 = txtBaseFixedExp4.Text.ToString();
                objApprasialProperties.BasefixedPerMonth5 = txtBaseFixedExp5.Text.ToString();
                objApprasialProperties.BasefixedPerMonth6 = txtBaseFixedExp6.Text.ToString();

                objApprasialProperties.EligibleUnitsAboveBase1 = txtEligibleUnitsBaseExp1.Text.ToString();
                objApprasialProperties.EligibleUnitsAboveBase2 = txtEligibleUnitsBaseExp2.Text.ToString();
                objApprasialProperties.EligibleUnitsAboveBase3 = txtEligibleUnitsBaseExp3.Text.ToString();
                objApprasialProperties.EligibleUnitsAboveBase4 = txtEligibleUnitsBaseExp4.Text.ToString();
                objApprasialProperties.EligibleUnitsAboveBase5 = txtEligibleUnitsBaseExp5.Text.ToString();
                objApprasialProperties.EligibleUnitsAboveBase6 = txtEligibleUnitsBaseExp6.Text.ToString();

                objApprasialProperties.Last3FinancialYear1 = ddlFinYear1.SelectedValue.ToString();
                objApprasialProperties.Last3FinancialYear2 = ddlFinYear2.SelectedValue.ToString();
                objApprasialProperties.Last3FinancialYear3 = ddlFinYear3.SelectedValue.ToString();

                objApprasialProperties.Last3UtilisedUnits1 = txtUtilizedUnits1.Text.ToString();
                objApprasialProperties.Last3UtilisedUnits2 = txtUtilizedUnits2.Text.ToString();
                objApprasialProperties.Last3UtilisedUnits3 = txtUtilizedUnits3.Text.ToString();

                objApprasialProperties.Last3RatePerUnit1 = txtRatePerUnit1.Text.ToString();
                objApprasialProperties.Last3RatePerUnit2 = txtRatePerUnit2.Text.ToString();
                objApprasialProperties.Last3RatePerUnit3 = txtRatePerUnit3.Text.ToString();

                objApprasialProperties.Last3TotalPaid1 = txtTotalPaid1.Text.ToString();
                objApprasialProperties.Last3TotalPaid2 = txtTotalPaid2.Text.ToString();
                objApprasialProperties.Last3TotalPaid3 = txtTotalPaid3.Text.ToString();

                objApprasialProperties.UnitsConsumedPrior3Yrs = txtPrior3Yrs.Text.ToString();
                objApprasialProperties.AvgUnitsEM = txtAvgUnitsEM.Text.ToString();
                objApprasialProperties.BasePowerConsumption = txtBasePower.Text.ToString();
                objApprasialProperties.PerMonth = txtPerMonth.Text.ToString();

                objApprasialProperties.ComputedTotalCost = lblTotalAmount.Text.ToString();
                objApprasialProperties.Type = rdbEligibleType.SelectedItem.Text.ToString();
                objApprasialProperties.EligibleSubsidyAmount = lblEligibleAmount.Text.ToString();
                objApprasialProperties.GMRecommendedAmount = lblGMAmount.InnerText.ToString();
                objApprasialProperties.TotalSubsidyAmount = lblFinalElgAmount.Text.ToString();
                objApprasialProperties.Remarks = txtRemarks.Text.ToString();
                objApprasialProperties.WorkSheetPath = hypWorksheet.NavigateUrl.ToString();
                objApprasialProperties.CREATEDBY = ObjLoginNewvo.uid;
                objApprasialProperties.CREATEDBYIP = "";
                objApprasialProperties.Scheme = "TTAP";
                string returnval = "0";
                returnval = ObjCAFClass.InsertPowerAppraisal(objApprasialProperties);
                if (!string.IsNullOrEmpty(returnval) && returnval.Trim() != "")
                {
                    string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
                    DLOApplication DLODetails = new DLOApplication();
                    if (lblFinalElgAmount.Text != "")
                    {
                        DLODetails.RECOMMENDEAMOUNT = lblFinalElgAmount.Text;
                    }
                    else
                    {
                        DLODetails.RECOMMENDEAMOUNT = Convert.ToString(objApprasialProperties.TotalSubsidyAmount);
                    }

                    DLODetails.INCENTIVEID = txtIncID.Text;
                    DLODetails.SUBINCENTIVEID = "4";
                    DLODetails.ACTIONID = "1";
                    DLODetails.FORWARDTO = ddlDepartment.SelectedItem.Text;
                    DLODetails.CREATEDBY = ObjLoginNewvo.uid;

                    string result = ObjCAFClass.InsertClerkDetails(DLODetails);

                    if (result == "1")
                    {
                        status = true;
                        lblmsg.Text = "Appraisal note submitted";
                        /*lblmsg.Text = "Application Process Submitted Successfully";
                        string message = "alert('" + lblmsg.Text + "')";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Application Process Submitted Successfully.');", true);*/
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Action Failed');", true);
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
            string SubIncentiveId = "4";

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

        protected void CalLastThree(object sender, EventArgs e)
        {
            string Unit1 = "0", Unit2 = "0", Unit3 = "0";
            string Rate1 = "0", Rate2 = "0", Rate3 = "0";
            if (txtUtilizedUnits1.Text != "") { Unit1 = txtUtilizedUnits1.Text.ToString(); }
            if (txtUtilizedUnits2.Text != "") { Unit2 = txtUtilizedUnits2.Text.ToString(); }
            if (txtUtilizedUnits3.Text != "") { Unit3 = txtUtilizedUnits3.Text.ToString(); }

            if (txtRatePerUnit1.Text != "") { Rate1 = txtRatePerUnit1.Text.ToString(); }
            if (txtRatePerUnit2.Text != "") { Rate2 = txtRatePerUnit2.Text.ToString(); }
            if (txtRatePerUnit3.Text != "") { Rate3 = txtRatePerUnit3.Text.ToString(); }

            string amt1 = txtTotalPaid1.Text = (Convert.ToDecimal(Unit1) * Convert.ToDecimal(Rate1)).ToString();
            string amt2 = txtTotalPaid2.Text = (Convert.ToDecimal(Unit2) * Convert.ToDecimal(Rate2)).ToString();
            string amt3 = txtTotalPaid3.Text = (Convert.ToDecimal(Unit3) * Convert.ToDecimal(Rate3)).ToString();

            string TotalUnits = (Convert.ToInt32(Unit1) + Convert.ToInt32(Unit2) + Convert.ToInt32(Unit3)).ToString();
            txtPrior3Yrs.Text = TotalUnits.ToString();
            string TotalAmount = txtBasePower.Text = (Convert.ToDecimal(amt1) + Convert.ToDecimal(amt2) + Convert.ToDecimal(amt3)).ToString();
            txtAvgUnitsEM.Text = ((Convert.ToInt32(TotalUnits)) / 3).ToString("0.00");
            txtBasePower.Text = ((Convert.ToInt32(TotalUnits)) / 3).ToString("0.00");
            txtPerMonth.Text = (Convert.ToDecimal(txtBasePower.Text) / 12).ToString("0.00");
        }
        public void BindLastThreeYrs(string Date)
        {
            DataSet Dsnew = new DataSet();
            Dsnew = ObjCAFClass.GetFinancialYears(Date);
            if (Dsnew != null && Dsnew.Tables.Count > 0 && Dsnew.Tables[0].Rows.Count > 0)
            {
                ddlFinYear1.DataSource = Dsnew.Tables[0];
                ddlFinYear1.DataTextField = "FinancialYear";
                ddlFinYear1.DataValueField = "FinancialYear";
                ddlFinYear1.DataBind();

                ddlFinYear2.DataSource = Dsnew.Tables[0];
                ddlFinYear2.DataTextField = "FinancialYear";
                ddlFinYear2.DataValueField = "FinancialYear";
                ddlFinYear2.DataBind();

                ddlFinYear3.DataSource = Dsnew.Tables[0];
                ddlFinYear3.DataTextField = "FinancialYear";
                ddlFinYear3.DataValueField = "FinancialYear";
                ddlFinYear3.DataBind();
            }
            AddSelect(ddlFinYear1);
            AddSelect(ddlFinYear2);
            AddSelect(ddlFinYear3);
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
    }
}