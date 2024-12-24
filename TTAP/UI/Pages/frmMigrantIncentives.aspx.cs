using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class frmMigrantIncentives : System.Web.UI.Page
    {
        General Gen = new General();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        CAFClass ObjCAFClass = new CAFClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Form.Enctype = "multipart/form-data";

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
                            Session.RemoveAll();
                            Session.Clear();
                            Session.Abandon();
                            Response.Redirect("~/LoginReg.aspx");
                        }
                    }
                    if (!IsPostBack)
                    {
                        if (Session["incentivedata"] != null)
                        {
                            string userid = Session["uid"].ToString();
                            string IncentveID = Session["IncentiveID"].ToString();
                            DataSet ds = new DataSet();
                            ds = (DataSet)Session["incentivedata"];
                            DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 18);
                            if (drs.Length > 0)
                            {
                                DataSet dsnew = new DataSet();
                                GetRentalSubsidyDetails(userid, IncentveID);
                                //dsnew = Gen.GetIncentivesISdata(IncentveID, "6");
                                //Filldata(dsnew);
                            }
                            else
                            {
                                if (Request.QueryString[0].ToString() == "N")
                                {
                                    // Response.Redirect("FinalPage.aspx?next=" + "N");
                                    Response.Redirect("frmPaymentPage.aspx?next=" + "N");

                                }
                                else
                                {
                                    Response.Redirect("frmAssistanceTraningInfrastructutre.aspx?Previous=" + "P");
                                }
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
        public void GetRentalSubsidyDetails(string uid, string incentiveid)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetapplicationDtls(uid, incentiveid);
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    lblTSIPassUIDNumber.InnerText = dsnew.Tables[0].Rows[0]["Uid_NO"].ToString();
                    lblCommonApplicationNumber.InnerText = dsnew.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                    lblTypeofApplicant.InnerText = dsnew.Tables[0].Rows[0]["TypeOfIndustryText"].ToString();

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

                            btnUpload1.Enabled = false;
                            Button1.Enabled = false;
                            btnCharteredEngineer.Enabled = false;
                            btnMigrationcompetentauthorities.Enabled = false;
                            //grdPandM.Columns[19].Visible = false;
                            //grdPandM.Columns[18].Visible = false;
                        }
                        else
                        {
                            EnableDisableForm(Page.Controls, true);
                        }
                    }
                }

                DataSet ds = new DataSet();
                SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@created_BY",SqlDbType.Int),
                     new SqlParameter("@IncentiveID",SqlDbType.Int)


                };
                p[0].Value = uid;
                p[1].Value = incentiveid;

                ds = Gen.GenericFillDs("USP_GET_Returning_Migrants_Dtls", p);


                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.ToString() != "" && ds.Tables[0].Rows.ToString() != null)
                {
                    //txtCapitalInvestment.Text = ds.Tables[0].Rows[0]["CapitalInvestment"].ToString();
                    txtScheme.Text = ds.Tables[0].Rows[0]["Scheme"].ToString();
                    txtWeaversPercentage.Text = ds.Tables[0].Rows[0]["WeaversPercentage"].ToString();
                    txtContributiontoinvestment.Text = ds.Tables[0].Rows[0]["Contributiontoinvestment"].ToString();
                    txtBuilding.Text = ds.Tables[0].Rows[0]["Building"].ToString();
                    txtPlantMachinery.Text = ds.Tables[0].Rows[0]["PlantMachinery"].ToString();
                    txtInstallationCharges.Text = ds.Tables[0].Rows[0]["InstallationCharges"].ToString();
                    txtElectrification.Text = ds.Tables[0].Rows[0]["Electrification"].ToString();
                    txtOthers.Text = ds.Tables[0].Rows[0]["Others"].ToString();
                    lblTotalInvestment.InnerHtml = GetTotalInv();
                    txtCurrentClaim.Text = ds.Tables[0].Rows[0]["CurrentClaim"].ToString();

                    txtAmountAvailed.Text = ds.Tables[0].Rows[0]["AmountAvailed"].ToString();
                    txtSanctionOrderNo.Text = ds.Tables[0].Rows[0]["SanctionOrderNo"].ToString();
                    txtDateAvailed.Text = ds.Tables[0].Rows[0]["DateAvailedDDMMYY"].ToString();

                    txtPercentageGOIContribution.Text = ds.Tables[0].Rows[0]["PercentageGOIContribution"].ToString();
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
                                if (Docid == "181001")
                                {
                                    objClsFileUpload.AssignPath(HyperLink2, Path);
                                }
                                else if (Docid == "181002")
                                {
                                    objClsFileUpload.AssignPath(lblUpload1, Path);
                                }
                                else if (Docid == "181003")
                                {
                                    objClsFileUpload.AssignPath(hyCharteredEngineer, Path);
                                }
                                else if (Docid == "181004")
                                {
                                    objClsFileUpload.AssignPath(hyMigrationcompetentauthorities, Path);
                                }
                                else if (Docid == "181005")
                                {
                                    objClsFileUpload.AssignPath(hyPermissionsLineDepartments, Path);
                                }
                                else if (Docid == "181006")
                                {
                                    objClsFileUpload.AssignPath(hyGovtSanctionOrderSITP, Path);
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
        public string GeneralInformationcheck()
        {
            int slno = 1;
            string ErrorMsg = "";

            //if (txtCapitalInvestment.Text.TrimStart().Trim() == "")
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Enter Capital Investment \\n";
            //    slno = slno + 1;
            //}
            if (txtWeaversPercentage.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Percentage of Members as Weavers \\n";
                slno = slno + 1;
            }
            if (txtScheme.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Scheme: SITP, GOI MSME Cluster Development \\n";
                slno = slno + 1;
            }
            if (txtContributiontoinvestment.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Contribution to investment by beneficiary groups in Rs \\n";
                slno = slno + 1;
            }
            if (txtPercentageGOIContribution.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Percentage GOI contribution in Capital Investment \\n";
                slno = slno + 1;
            }


            if (txtCurrentClaim.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter the Current Claim  Amount (In Rupees) \\n";
                slno = slno + 1;
            }


            return ErrorMsg;
        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (flUploadCACertificate.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(flUploadCACertificate);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(flUploadCACertificate);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), flUploadCACertificate, HyperLink2, "CACertificateinvestmentsTrainingInfrastructure", Session["IncentiveID"].ToString(), "18", "181001", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
        }
        protected void btnUpload1_Click(object sender, EventArgs e)
        {
            if (fuDocuments1.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuDocuments1);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuDocuments1);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuDocuments1, lblUpload1, "CredentialsInstitutesettingInfrastructureApparelDesignandDevelopment", Session["IncentiveID"].ToString(), "18", "181002", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
        }

        protected void btnCharteredEngineer_Click(object sender, EventArgs e)
        {
            if (fuCharteredEngineer.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuCharteredEngineer);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuCharteredEngineer);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuCharteredEngineer, hyCharteredEngineer, "CertificateCharteredEngineer", Session["IncentiveID"].ToString(), "18", "181003", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
        }

        public string GetDecimalNullValue(string Input)
        {
            string InputValue = "";

            InputValue = (Input != "") ? Input : "0";

            return InputValue;
        }

        public string GetTotalInv()
        {
            double Total = 0;

            Total = Convert.ToDouble(GetDecimalNullValue(txtBuilding.Text.Trim().TrimStart())) +
                Convert.ToDouble(GetDecimalNullValue(txtPlantMachinery.Text.Trim().TrimStart())) +
                Convert.ToDouble(GetDecimalNullValue(txtInstallationCharges.Text.Trim().TrimStart())) +
                Convert.ToDouble(GetDecimalNullValue(txtElectrification.Text.Trim().TrimStart())) +
                Convert.ToDouble(GetDecimalNullValue(txtOthers.Text.Trim().TrimStart()));

            return Total.ToString();

        }

        protected void txtBuilding_TextChanged(object sender, EventArgs e)
        {
            lblTotalInvestment.InnerHtml = GetTotalInv();
        }


        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmAssistanceTraningInfrastructutre.aspx?Previous=" + "P");

        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {

            try
            {
                string errormsg = GeneralInformationcheck();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {

                    string errormsgAttach = ObjCAFClass.ValidateMandatoryAttachments(Session["IncentiveID"].ToString(), "18");
                    if (errormsgAttach.Trim().TrimStart() != "")
                    {
                        string message = "alert('" + errormsgAttach + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }

                    MigratIncentive ObjTraning = new MigratIncentive();

                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    ObjTraning.IncentiveId = Session["IncentiveID"].ToString();
                    ObjTraning.CreatedBy = ObjLoginNewvo.uid;

                    // ObjTraning.CapitalInvestment = GetDecimalNullValue(txtCapitalInvestment.Text.Trim().TrimStart());
                    ObjTraning.CapitalInvestment = "0";
                    ObjTraning.Scheme = txtScheme.Text.Trim().TrimStart();
                    ObjTraning.WeaversPercentage = GetDecimalNullValue(txtWeaversPercentage.Text.Trim().TrimStart());
                    ObjTraning.Contributiontoinvestment = GetDecimalNullValue(txtContributiontoinvestment.Text.Trim().TrimStart());
                    ObjTraning.Building = GetDecimalNullValue(txtBuilding.Text.Trim().TrimStart());
                    ObjTraning.PlantMachinery = GetDecimalNullValue(txtPlantMachinery.Text.Trim().TrimStart());
                    ObjTraning.InstallationCharges = GetDecimalNullValue(txtInstallationCharges.Text.Trim().TrimStart());
                    ObjTraning.Electrification = GetDecimalNullValue(txtElectrification.Text.Trim().TrimStart());
                    ObjTraning.Others = GetDecimalNullValue(txtOthers.Text.Trim().TrimStart());
                    ObjTraning.TotalInvestment = GetTotalInv();
                    ObjTraning.CurrentClaim = GetDecimalNullValue(txtCurrentClaim.Text.Trim().TrimStart());

                    ObjTraning.AmountAvailed = GetDecimalNullValue(txtAmountAvailed.Text.Trim().TrimStart());
                    ObjTraning.SanctionOrderNo = txtSanctionOrderNo.Text.Trim().TrimStart();
                    ObjTraning.DateAvailed = GetFromatedDateDDMMYYYY(txtDateAvailed.Text.Trim().TrimStart());

                    ObjTraning.PercentageGOIContribution = GetDecimalNullValue(txtPercentageGOIContribution.Text.Trim().TrimStart());

                    string Validstatus = ObjCAFClass.InsertingOfReturningMigrantsDtls(ObjTraning);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        // Response.Redirect("FinalPage.aspx");
                        Response.Redirect("frmPaymentPage.aspx?next=" + "N");
                    }
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
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
        protected void btnMigrationcompetentauthorities_Click(object sender, EventArgs e)
        {
            if (fuMigrationcompetentauthorities.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuMigrationcompetentauthorities);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuMigrationcompetentauthorities);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuMigrationcompetentauthorities, hyMigrationcompetentauthorities, "Migrationcompetentauthorities", Session["IncentiveID"].ToString(), "18", "181004", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
        }

        protected void btnPermissionsLineDepartments_Click(object sender, EventArgs e)
        {
            if (fuPermissionsLineDepartments.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuPermissionsLineDepartments);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuPermissionsLineDepartments);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuPermissionsLineDepartments, hyPermissionsLineDepartments, "PermissionsLineDepartments", Session["IncentiveID"].ToString(), "18", "181005", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
        }

        protected void btnGovtSanctionOrderSITP_Click(object sender, EventArgs e)
        {
            if (fuGovtSanctionOrderSITP.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuGovtSanctionOrderSITP);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuGovtSanctionOrderSITP);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuGovtSanctionOrderSITP, hyGovtSanctionOrderSITP, "GovtSanctionOrderSITP", Session["IncentiveID"].ToString(), "18", "181006", Session["uid"].ToString(), "USER");

                    if (OutPut != "0")
                    {
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
        }
    }
}