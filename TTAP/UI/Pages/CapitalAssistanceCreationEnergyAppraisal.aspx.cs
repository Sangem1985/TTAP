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
    public partial class CapitalAssistanceCreationEnergyAppraisal : System.Web.UI.Page
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
                        BindBesicdata(incentiveid, "2", "");
                        GetCapitalAssistanceCreationEnergy(ViewState["UID"].ToString(), txtIncID.Text);
                        BindEquipmentDtls(incentiveid);
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
                    txtGMRecommendedAmount.Text= dsnew.Tables[1].Rows[0]["OfficerRecommendedAmount"].ToString();


                }
            }
            catch (Exception ex)
            { }
        }
        public void GetCapitalAssistanceCreationEnergy(string uid, string IncentiveID)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@created_BY",SqlDbType.VarChar),
                    new SqlParameter("@IncentiveID",SqlDbType.VarChar)
                };
                p[0].Value = uid;
                p[1].Value = IncentiveID;
                ds = ObjCAFClass.GenericFillDs("USP_GET_CAPITALASSISTANCEFORCREATIONENERGY", p);
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.ToString() != "" && ds.Tables[0].Rows.ToString() != null)
                {   
                    lblTextTileType.InnerText= ds.Tables[0].Rows[0]["TextTileTypeText"].ToString();
                    hdnTextileType.Value= ds.Tables[0].Rows[0]["TextTileType"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindEquipmentDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetEquipmentDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    GvEquipmentDtls.DataSource = dsnew.Tables[0];
                    GvEquipmentDtls.DataBind();
                }
                else
                {
                    GvEquipmentDtls.DataSource = null;
                    GvEquipmentDtls.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetEquipmentDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_Equipment_DTLS", pp);
            return Dsnew;
        }

        protected void ddlTypeofEquipment_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal EnergyConservation = 0; decimal WaterConservation = 0;
            decimal EnvironmentalConservation = 0; decimal EffluentTreatment = 0;
            decimal TotalCalculatedAmount = 0;
            foreach (GridViewRow gvrow in GvEquipmentDtls.Rows)
            {
                Label lblEquipment_ID = ((Label)(gvrow.FindControl("lblEquipment_ID")));
                DropDownList ddlTypeofEquipment = ((DropDownList)(gvrow.FindControl("ddlTypeofEquipment")));
                TextBox txtTotal = ((TextBox)(gvrow.FindControl("txtTotal")));
                

                if (ddlTypeofEquipment.SelectedValue == "1")
                {
                    if (txtTotal.Text != "")
                    {
                        EnergyConservation = EnergyConservation + Convert.ToDecimal(txtTotal.Text.Trim());
                    }
                }
                if (ddlTypeofEquipment.SelectedValue == "2")
                {
                    if (txtTotal.Text != "")
                    {
                        WaterConservation = WaterConservation + Convert.ToDecimal(txtTotal.Text.Trim());
                    }
                }
                if (ddlTypeofEquipment.SelectedValue == "3")
                {
                    if (txtTotal.Text != "")
                    {
                        EnvironmentalConservation = EnvironmentalConservation + Convert.ToDecimal(txtTotal.Text.Trim());
                    }
                }
                if (ddlTypeofEquipment.SelectedValue == "4")
                {
                    if (txtTotal.Text != "")
                    {
                        EffluentTreatment = EffluentTreatment + Convert.ToDecimal(txtTotal.Text.Trim());
                    }
                }
            }
            txtEnergyEquipmentTotal.Text = EnergyConservation.ToString();
            txtWaterEquipmentTotal.Text = WaterConservation.ToString();
            txttxtEnvironmentalEquipmentTotal.Text = EnvironmentalConservation.ToString();
            txttxtEffluentTreatmentCotal.Text = EffluentTreatment.ToString();

            decimal ElgEnergyConservation = (EnergyConservation * Convert.ToDecimal(0.40));
            decimal ElgWaterConservation = (WaterConservation * Convert.ToDecimal(0.40));
            decimal ElgEnvironmentalConservation = (EnvironmentalConservation * Convert.ToDecimal(0.40));
            decimal ElgEffluentTreatment = 0;
            if (hdnTextileType.Value == "HD")
            {
                ElgEffluentTreatment = (EffluentTreatment * Convert.ToDecimal(0.70));
            }
            else 
            {
                ElgEffluentTreatment = (EffluentTreatment * Convert.ToDecimal(0.50));
            }
            txtEnergyEquipment.Text = ElgEnergyConservation.ToString();
            txtWaterEquipment.Text = ElgWaterConservation.ToString();
            txtEnvironmentalEquipment.Text = ElgEnvironmentalConservation.ToString();
            txtEffluentTreatment.Text = ElgEffluentTreatment.ToString();

            if (ElgEnergyConservation > 5000000) { txtEnergyEquipment.Text = "5000000"; }
            if (ElgWaterConservation > 5000000) { txtEnergyEquipment.Text = "5000000"; }
            if (ElgEnvironmentalConservation > 5000000) { txtEnergyEquipment.Text = "5000000"; }
            if (hdnTextileType.Value == "HD")
            {
                if (ElgEffluentTreatment > 100000000) { txtEffluentTreatment.Text = "100000000"; }
            }
            else 
            {
                if (ElgEffluentTreatment > 20000000) { txtEffluentTreatment.Text = "20000000"; }
            }

            TotalCalculatedAmount = (Convert.ToDecimal(txtEnergyEquipment.Text) + Convert.ToDecimal(txtWaterEquipment.Text) + Convert.ToDecimal(txtEnvironmentalEquipment.Text) +
                Convert.ToDecimal(txtEffluentTreatment.Text));

            txtSysCalculatedAmount.Text = TotalCalculatedAmount.ToString();

            decimal FinalEligibleAmount = 0;
            FinalEligibleAmount = Math.Min(TotalCalculatedAmount, Convert.ToDecimal(txtGMRecommendedAmount.Text.ToString()));
            if (rdbEligbleType.SelectedValue != "" && rdbEligbleType.SelectedValue != null)
            {
                if (rdbEligbleType.SelectedValue == "Y") { txtEligibleAmount.Text = FinalEligibleAmount.ToString(); }
                else if (rdbEligbleType.SelectedValue == "N") { txtEligibleAmount.Text = (FinalEligibleAmount / 2).ToString(); }
                else { txtEligibleAmount.Text = "0"; }
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string IncentiveId = txtIncID.Text;
            string SubIncentiveId = "2";

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
                    string message = "alert('Appraisal note submitted successfully')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    btnSubmit.Visible = false;
                }
            }
        }
        public string ValidateControls()
        {
            int slno = 1;
            string ErrorMsg = "";
            
            if (txtEnergyEquipmentTotal.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Total Cost of Equipment for Energy Conservation Infra \\n";
                slno = slno + 1;
            }
            if (txtWaterEquipmentTotal.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Total Cost of Equipment for Energy Conservation Infra \\n";
                slno = slno + 1;
            }
            if (txttxtEnvironmentalEquipmentTotal.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Total Cost of Equipment for Environmental Conservation Infra \\n";
                slno = slno + 1;
            }
            if (txttxtEffluentTreatmentCotal.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Total Cost of CET Plant at Industrial Park / Cluster \\n";
                slno = slno + 1;
            }
            if (txtEnergyEquipment.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Cost of Equipment for Energy Conservation Infra \\n";
                slno = slno + 1;
            }
            if (txtWaterEquipment.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Cost of Equipment for Water Conservation Infra \\n";
                slno = slno + 1;
            }
            if (txtEnvironmentalEquipment.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Cost of Equipment for Environmental Conservation Infra \\n";
                slno = slno + 1;
            }
            if (txtEffluentTreatment.Text == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Cost of Common Effluent Treatment Plant at Industrial Park / Cluster \\n";
                slno = slno + 1;
            }
            if (txtSysCalculatedAmount.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Total Calculated Subsidy Amount \\n";
                slno = slno + 1;
            }
            if (rdbEligbleType.SelectedValue == null || rdbEligbleType.SelectedValue == "" || rdbEligbleType.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Eligibility Type \\n";
                slno = slno + 1;
            }
            if (txtEligibleAmount.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please enter Eligible Subsidy Amount \\n";
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
                List<InspectionEquipment> lstEqps = new List<InspectionEquipment>();
                foreach (GridViewRow gvrow in GvEquipmentDtls.Rows)
                {
                    Label lblEquipment_ID = ((Label)(gvrow.FindControl("lblEquipment_ID")));
                    Label lblNameoftheEquipment = ((Label)(gvrow.FindControl("lblNameoftheEquipment")));
                    DropDownList ddlTypeofEquipment = ((DropDownList)(gvrow.FindControl("ddlTypeofEquipment")));
                    TextBox txtTotal = ((TextBox)(gvrow.FindControl("txtTotal")));
                    TextBox txtEqpRemarks = ((TextBox)(gvrow.FindControl("txtEqpRemarks")));

                    if (ddlTypeofEquipment.SelectedValue == "0")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please select Type of the Equipment.');", true);
                        return false;
                    }
                    if (txtTotal.Text.Trim() == "")
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Please enter Amount of Equipment.');", true);
                        return false;
                    }
                    lstEqps.Add(new InspectionEquipment
                    {
                        EquipmentId = lblEquipment_ID.Text,
                        IncentiveId = txtIncID.Text.Trim(),
                        EquipmentName = lblNameoftheEquipment.Text.Trim(),
                        EquipmentCost = txtTotal.Text,
                        Remarks = txtEqpRemarks.Text,
                        Category = ddlTypeofEquipment.SelectedValue.ToString(),
                        CategoryName = ddlTypeofEquipment.SelectedItem.Text.ToString()
                    });

                    XElement xmlEqppload = new XElement("xmlEqpUpload_xml",
                        from Eqp in lstEqps
                        select new XElement("EqpsTable",
                        new XElement("EQID", Eqp.EquipmentId),
                        new XElement("IncentiveId", Eqp.IncentiveId),
                        new XElement("EquipmentName", Eqp.EquipmentName),
                        new XElement("EquipmentCost", Eqp.EquipmentCost),
                        new XElement("Remarks", Eqp.Remarks),
                        new XElement("CategoryId", Eqp.Category),
                        new XElement("CategoryName", Eqp.CategoryName)
                        ));

                    objApprasialProperties.EquipmentXml = xmlEqppload.ToString();


                }
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

                objApprasialProperties.TotalCostofEnergyConservation = txtEnergyEquipmentTotal.Text;
                objApprasialProperties.TotalCostofWaterConservation = txtWaterEquipmentTotal.Text;
                objApprasialProperties.TotalCostofEquipmentEnvironmental = txttxtEnvironmentalEquipmentTotal.Text;
                objApprasialProperties.TotalCostofCetPlantCluster = txttxtEffluentTreatmentCotal.Text;

                objApprasialProperties.EligibleCostofEnergyConservation = txtEnergyEquipment.Text;
                objApprasialProperties.EligibleCostofWaterConservation = txtWaterEquipment.Text;
                objApprasialProperties.EligibleCostofEquipmentEnvironmental = txtEnvironmentalEquipment.Text;
                objApprasialProperties.EligibleCostofCetPlantCluster = txtEffluentTreatment.Text;

                objApprasialProperties.CalculatedSubsisdyAmount = txtSysCalculatedAmount.Text;
                objApprasialProperties.GMRecommendedAmount = txtGMRecommendedAmount.Text;
                objApprasialProperties.ELIGIBLETYPE = rdbEligbleType.SelectedItem.Text;
                objApprasialProperties.TotalSubsidyAmount = txtEligibleAmount.Text;
                objApprasialProperties.ForwardTo = ddlDepartment.SelectedValue;
                objApprasialProperties.Remarks = txtRemarks.Text;
                objApprasialProperties.WorkSheetPath = hypWorksheet.Text;
                objApprasialProperties.CREATEDBY = ObjLoginNewvo.uid;
                objApprasialProperties.CREATEDBYIP = getclientIP();


                string returnval = "0";
                returnval = ObjCAFClass.InsertCACEWECIAppraisal(objApprasialProperties);
                if (!string.IsNullOrEmpty(returnval) && returnval.Trim() != "")
                {
                    string Role_Code = Session["Role_Code"].ToString().Trim().TrimStart();
                    DLOApplication DLODetails = new DLOApplication();
                    if (txtEligibleAmount.Text != "")
                    {
                        DLODetails.RECOMMENDEAMOUNT = txtEligibleAmount.Text;
                    }
                    else
                    {
                        DLODetails.RECOMMENDEAMOUNT = Convert.ToString(objApprasialProperties.TotalSubsidyAmount);
                    }

                    DLODetails.INCENTIVEID = txtIncID.Text;
                    DLODetails.SUBINCENTIVEID = "2";
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

        protected void GvEquipmentDtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow gvrow in GvEquipmentDtls.Rows)
                {
                    Label lblTypeofEquipmentId = ((Label)(gvrow.FindControl("lblTypeofEquipmentId")));
                    DropDownList ddlTypeofEquipment = ((DropDownList)(gvrow.FindControl("ddlTypeofEquipment")));
                    if (lblTypeofEquipmentId.Text == "" || lblTypeofEquipmentId.Text == null)
                    {
                        ddlTypeofEquipment.SelectedValue = "0";
                    }
                    else
                    {
                        ddlTypeofEquipment.SelectedValue = lblTypeofEquipmentId.Text.ToString();
                    }

                }
            }
            catch (Exception ex)
            {
                
            }
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
    }
}