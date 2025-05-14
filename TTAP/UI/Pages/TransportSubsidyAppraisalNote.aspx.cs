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
    public partial class TransportSubsidyAppraisalNote : System.Web.UI.Page
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
                        BindBesicdata(incentiveid, "9", "");
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
                    //TypeOfIndustry = "2";
                    //hdnTypeOfIndustry.Value = "2";
                    if (TypeOfIndustry == "1")
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCP"].ToString();
                        divNewUnit.Visible = true;

                    }
                    else
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCPExp"].ToString();
                        divExpansion.Visible = true;
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

        protected void CalucalteNewUnitSubsidy(object sender, EventArgs e)
        {
            if (txtRevenueOfUnit.Text.Trim() != "" && txtExportValueOfUnit.Text.Trim() != "")
            {
                decimal Revenue = 0, Export = 0, Total = 0, GMAmount = 0;decimal CalAmount = 0;
                if (txtGMRecommendedAmount.Text.Trim() != "") { GMAmount = Convert.ToDecimal(txtGMRecommendedAmount.Text.Trim().ToString()); }
                if (txtRevenueOfUnit.Text.Trim() != "") { Revenue = Convert.ToDecimal(txtRevenueOfUnit.Text.Trim()); }
                if (txtExportValueOfUnit.Text.Trim() != "") { Export = Convert.ToDecimal(txtExportValueOfUnit.Text.Trim()); }
                if (Export < Revenue)
                {
                    Total = (Export / Revenue) * 100;
                    if (Convert.ToInt32(Total) >= 30)
                    {
                        divInfoNotEligible.Visible = false;
                        txtCalcSubsidyAmount.Enabled = true;
                        txtEligibleAmount.Enabled = true;
                        txtFinalSubsidyAmount.Enabled = true;
                        rdbEligbleType.Enabled = true;
                        CalAmount = Convert.ToDecimal(txtCalcSubsidyAmount.Text.Trim());
                        decimal minValue = Math.Min(CalAmount, GMAmount);
                        txtEligibleAmount.Text = minValue.ToString();

                        if (rdbEligbleType.SelectedValue != null && rdbEligbleType.SelectedValue != "")
                        {
                            if (rdbEligbleType.SelectedValue.ToString() == "1")
                            {
                                txtFinalSubsidyAmount.Text = minValue.ToString();
                            }
                            if (rdbEligbleType.SelectedValue.ToString() == "2")
                            {
                                txtFinalSubsidyAmount.Text = (minValue / 2).ToString();
                            }
                            if (rdbEligbleType.SelectedValue.ToString() == "3")
                            {
                                txtFinalSubsidyAmount.Text = "0";
                            }
                        }
                        else
                        {
                            txtFinalSubsidyAmount.Text = "";
                        }
                    }
                    else
                    {
                        txtRemarks.Text = lblNotEligible.InnerText.ToString();
                        divInfoNotEligible.Visible = true;
                        txtCalcSubsidyAmount.Text = "0"; txtCalcSubsidyAmount.Enabled = false;
                        txtEligibleAmount.Text = "0"; txtEligibleAmount.Enabled = false;
                        txtFinalSubsidyAmount.Text = "0"; txtFinalSubsidyAmount.Enabled = false;
                    }
                }
                else 
                {
                    txtCalcSubsidyAmount.Text = "0";
                    txtEligibleAmount.Text = "0";
                    txtFinalSubsidyAmount.Text = "0";
                    txtExportValueOfUnit.Text = ""; txtExportValueOfUnit.Focus();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Revenue value should higher than Export Value');", true);
                    return;
                }
            }
        }

        protected void CalucalteExpansionSubsidy(object sender, EventArgs e)
        {
            if (txtAverageRevenue.Text.Trim() != "" && txtRevenueAfterExpansion.Text.Trim() != "")
            {
                decimal AvgRevenue = 0, RvnuAfterExp = 0, IncrementalRevenue = 0, GMAmount = 0, IncrementalRevenuePercentage = 0;
                decimal AvgFreightCharges = 0, TotalFrightCharges = 0, ElgFreightCharges = 0;
                if (txtGMRecommendedAmount.Text.Trim() != "") { GMAmount = Convert.ToDecimal(txtGMRecommendedAmount.Text.Trim().ToString()); }

                if (txtAverageRevenue.Text.Trim() != "") { AvgRevenue = Convert.ToDecimal(txtAverageRevenue.Text.Trim()); }
                if (txtRevenueAfterExpansion.Text.Trim() != "") { RvnuAfterExp = Convert.ToDecimal(txtRevenueAfterExpansion.Text.Trim()); }
                if (txtAverageFrightCharges.Text.Trim() != "") { AvgFreightCharges = Convert.ToDecimal(txtAverageFrightCharges.Text.Trim()); }
                if (txtFreightChargesAfterExpansion.Text.Trim() != "") { TotalFrightCharges = Convert.ToDecimal(txtFreightChargesAfterExpansion.Text.Trim()); }

                IncrementalRevenue = RvnuAfterExp - AvgRevenue;
                txtIncrementalRevenue.Text = IncrementalRevenue.ToString();
                IncrementalRevenuePercentage = (IncrementalRevenue / RvnuAfterExp) * 100;
                if (IncrementalRevenuePercentage >= 30)
                {
                    divInfoNotEligible.Visible = false;
                    txtCalcSubsidyAmount.Enabled = true;
                    txtEligibleAmount.Enabled = true;
                    txtFinalSubsidyAmount.Enabled = true;
                    rdbEligbleType.Enabled = true;
                    if (txtAverageFrightCharges.Text.Trim() != "" && txtFreightChargesAfterExpansion.Text.Trim() != "")
                    {
                        if (AvgFreightCharges < TotalFrightCharges)
                        {
                            ElgFreightCharges = TotalFrightCharges - AvgFreightCharges;
                            txtCalcSubsidyAmount.Text = ElgFreightCharges.ToString();
                            decimal minValue = Math.Min(ElgFreightCharges, GMAmount);
                            txtEligibleAmount.Text = minValue.ToString();

                            if (rdbEligbleType.SelectedValue != null && rdbEligbleType.SelectedValue != "")
                            {
                                if (rdbEligbleType.SelectedValue.ToString() == "1")
                                {
                                    txtFinalSubsidyAmount.Text = minValue.ToString();
                                }
                                if (rdbEligbleType.SelectedValue.ToString() == "2")
                                {
                                    txtFinalSubsidyAmount.Text = (minValue / 2).ToString();
                                }
                                if (rdbEligbleType.SelectedValue.ToString() == "3")
                                {
                                    txtFinalSubsidyAmount.Text = "0";
                                }
                            }
                            else
                            {
                                txtFinalSubsidyAmount.Text = "";
                            }
                        }
                        else 
                        {
                            txtCalcSubsidyAmount.Text = "0";
                            txtEligibleAmount.Text = "0";
                            txtFinalSubsidyAmount.Text = "0";
                            txtFreightChargesAfterExpansion.Text = ""; txtFreightChargesAfterExpansion.Focus();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Total Frieght Charges after Expansion value should higher than Average Freight Charges of Last 3 Yrs Value');", true);
                            return;
                        }
                    }
                }
                else
                {
                    divInfoNotEligible.Visible = true;
                    txtRemarks.Text = lblNotEligible.InnerText.ToString();
                    txtCalcSubsidyAmount.Text = "0"; txtCalcSubsidyAmount.Enabled = false;
                    txtEligibleAmount.Text = "0"; txtEligibleAmount.Enabled = false;
                    txtFinalSubsidyAmount.Text = "0"; txtFinalSubsidyAmount.Enabled = false;
                }
            }
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
            if (hdnTypeOfIndustry.Value == "1")
            {
                if (txtRevenueOfUnit.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter Total Revenue of the Unit \\n";
                    slno = slno + 1;
                }
                if (txtExportValueOfUnit.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Total Export Value of the Unit \\n";
                    slno = slno + 1;
                }
            }
            if (hdnTypeOfIndustry.Value == "2")
            {
                if (txtAverageRevenue.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter Average Revenue(Last Three Years) \\n";
                    slno = slno + 1;
                }
                if (txtRevenueAfterExpansion.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter Revenue After Expansion \\n";
                    slno = slno + 1;
                }
                if (txtAverageFrightCharges.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter Average Fright Charges(Last Three Years) \\n";
                    slno = slno + 1;
                }
                if (txtFreightChargesAfterExpansion.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please enter Total Freight Charges After Expansion \\n";
                    slno = slno + 1;
                }
            }
            if (txtCalcSubsidyAmount.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Calculated Subsisdy Amount \\n";
                slno = slno + 1;
            }
            if (txtGMRecommendedAmount.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter GM Recommended Amount \\n";
                slno = slno + 1;
            }
            if (txtEligibleAmount.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Eligible Subsidy Amount \\n";
                slno = slno + 1;
            }
            if (txtFinalSubsidyAmount.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Final Subsidy Amount \\n";
                slno = slno + 1;
            }

            if (ddlDepartment.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select whom you want to forward this to. \\n";
                slno = slno + 1;
            }

            return ErrorMsg;
        }

        protected void rdbEligbleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hdnTypeOfIndustry.Value == "1")
            {
                CalucalteNewUnitSubsidy(this, EventArgs.Empty);
            }
            else
            {
                CalucalteExpansionSubsidy(this, EventArgs.Empty);
            }
        }
        public bool save()
        {
            UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
            ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
            ApprasialProperties objApprasialProperties = new ApprasialProperties();

            bool status = false;

            try
            {   
                objApprasialProperties.INCENTIVEID = txtIncID.Text;
                objApprasialProperties.NAMEOFINDUSTRIAL = lblUnitName.InnerText;
                objApprasialProperties.LOCATIONOFINDUSTRIAL = lblAddress.InnerText;
                objApprasialProperties.NAMEOFPROMOTER = lblProprietor.InnerText;
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

                if (lblDCPdate.InnerText != "")
                {
                    objApprasialProperties.DATEOFPRODUCTION = Convert.ToDateTime(lblDCPdate.InnerText).ToString("yyyy-MM-dd");
                }
                else
                {
                    objApprasialProperties.DATEOFPRODUCTION = "";
                }
                if (lblReceiptDate.InnerText != "")
                {
                    objApprasialProperties.DICFILLINGDATE = Convert.ToDateTime(lblReceiptDate.InnerText).ToString("yyyy-MM-dd");
                }
                else
                {
                    objApprasialProperties.DATEOFPRODUCTION = "";
                }
                if (lblPowerConnectionReleaseDate.InnerText != "")
                {
                    objApprasialProperties.PowerConnectionRlsDate = Convert.ToDateTime(lblPowerConnectionReleaseDate.InnerText).ToString("yyyy-MM-dd");
                }
                else
                {
                    objApprasialProperties.PowerConnectionRlsDate = "";
                }

                objApprasialProperties.TotalRevenueofUnit = txtRevenueOfUnit.Text.ToString();
                objApprasialProperties.ExportValueofUnit = txtExportValueOfUnit.Text.ToString();
                objApprasialProperties.AverageRevenue = txtAverageRevenue.Text.ToString();
                objApprasialProperties.RevenueAfterExpansion = txtRevenueAfterExpansion.Text.ToString();
                objApprasialProperties.IncrementalRevenue = txtIncrementalRevenue.Text.ToString();
                objApprasialProperties.AverageFrightCharges = txtAverageFrightCharges.Text.ToString();
                objApprasialProperties.FreightChargesAfterExpansion = txtFreightChargesAfterExpansion.Text.ToString();

                objApprasialProperties.ComputedTotalCost = txtCalcSubsidyAmount.Text.ToString();
                objApprasialProperties.Type = rdbEligbleType.SelectedValue.ToString();
                objApprasialProperties.EligibleSubsidyAmount = txtEligibleAmount.Text.ToString();
                objApprasialProperties.GMRecommendedAmount = txtGMRecommendedAmount.Text.ToString();
                objApprasialProperties.TotalSubsidyAmount = txtFinalSubsidyAmount.Text.ToString();
                objApprasialProperties.Remarks = txtRemarks.Text.ToString();
                objApprasialProperties.WorkSheetPath = hypWorksheet.NavigateUrl.ToString();
                objApprasialProperties.CREATEDBY = ObjLoginNewvo.uid;
                objApprasialProperties.CREATEDBYIP = getclientIP();

                string returnval = "0";
                returnval = ObjCAFClass.InsertTransportAppraisal(objApprasialProperties);
                if (!string.IsNullOrEmpty(returnval) && returnval.Trim() != "" && returnval.Trim() != "0")
                {
                    string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
                    DLOApplication DLODetails = new DLOApplication();
                    if (txtFinalSubsidyAmount.Text != "")
                    {
                        DLODetails.RECOMMENDEAMOUNT = txtFinalSubsidyAmount.Text;
                    }
                    else
                    {
                        DLODetails.RECOMMENDEAMOUNT = Convert.ToString(objApprasialProperties.TotalSubsidyAmount);
                    }

                    DLODetails.INCENTIVEID = txtIncID.Text;
                    DLODetails.SUBINCENTIVEID = "9";
                    DLODetails.ACTIONID = "1";
                    DLODetails.FORWARDTO = ddlDepartment.SelectedItem.Text;
                    DLODetails.CREATEDBY = ObjLoginNewvo.uid;

                    string result = ObjCAFClass.InsertClerkDetails(DLODetails);

                    if (result == "1")
                    {
                        status = true;
                        lblmsg.Text = "Appraisal note submitted";
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return status;
        }
        public static string getclientIP()
        {
            string result = string.Empty;
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ip))
            {
                string[] ipRange = ip.Split(',');
                int le = ipRange.Length - 1;
                result = ipRange[0];
            }
            else
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return result;
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("COI/ClerkDashboard.aspx");
        }
        protected void txtFinalSubsidyAmount_TextChanged(object sender, EventArgs e)
        {
            if (rdbEligbleType.SelectedValue != null && rdbEligbleType.SelectedValue != "")
            {
                decimal Value = Convert.ToDecimal(txtFinalSubsidyAmount.Text.Trim().ToString());
                if (rdbEligbleType.SelectedValue.ToString() == "1")
                {
                    txtFinalSubsidyAmount.Text = Value.ToString();
                }
                if (rdbEligbleType.SelectedValue.ToString() == "2")
                {
                    txtFinalSubsidyAmount.Text = (Value / 2).ToString();
                }
                if (rdbEligbleType.SelectedValue.ToString() == "3")
                {
                    txtFinalSubsidyAmount.Text = "0";
                }
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string IncentiveId = txtIncID.Text;
            string SubIncentiveId = "9";

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