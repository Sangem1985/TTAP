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

namespace TTAP.UI.Pages
{
    public partial class frmRebateCharges : System.Web.UI.Page
    {
        General Gen = new General();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        CAFClass ObjCAFClass = new CAFClass();

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
                            DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 14);
                            if (drs.Length > 0)
                            {
                                DataSet dsnew = new DataSet();
                                BindFinancialYears(ddlFinYear, "5", Session["IncentiveID"].ToString());
                                BindOnMComponents();
                                GetRebatechargesDetails(userid, IncentveID);
                                BindETPChargesDtls(Session["IncentiveID"].ToString());
                            }
                            else
                            {
                                if (Request.QueryString[0].ToString() == "N")
                                {
                                    Response.Redirect("frmassistancedevelopment.aspx?next=" + "N");
                                }
                                else
                                {
                                    Response.Redirect("frmOtherInfrastructure.aspx?Previous=" + "P");
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
        public DataSet GetFinancialYearIncentives(string Count, string incentiveid)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@YEARS",SqlDbType.VarChar),
                new SqlParameter("@incentiveid",SqlDbType.VarChar)
           };
            pp[0].Value = Count;
            pp[1].Value = incentiveid;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_FINANCIALYEARS", pp);
            return Dsnew;
        }
        private void BindFinancialYears(DropDownList ddl, string Count, string incentiveid)
        {
            comFunctions cmf = new comFunctions();
            General Gen = new General();
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
        public void GetRebatechargesDetails(string uid, string incentiveid)
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
                    }
                    else
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCPExp"].ToString();
                    }


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

                            DivPowerutilizeLast3yrsdDetails.Visible = false;
                            grdETPDetails.Columns[7].Visible = false;
                            grdETPDetails.Columns[6].Visible = false;

                            btnOperatorRate.Enabled = false;
                            btnEffulent.Enabled = false;
                            btnOtherRelevant.Enabled = false;
                            btnBills.Enabled = false;
                            btnUtilisation.Enabled = false;
                            btnCharteredEngineerCETPETP.Enabled = false;
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

                ds = Gen.GenericFillDs("USP_GET_CETP_ETP_Environment_Dtls", p);


                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0] != null && ds.Tables[0].ToString() != "")
                {
                    RbtnTypeofETP.SelectedValue = ds.Tables[0].Rows[0]["TypeofETP"].ToString();
                    RbtnTypeofETP_SelectedIndexChanged(this, EventArgs.Empty);
                    txtOtherETP.Text = ds.Tables[0].Rows[0]["OtherETP"].ToString();
                    txtCETPETPDetails.Text = ds.Tables[0].Rows[0]["CETPETPDetails"].ToString();
                    txtCaptiveCommonETP.Text = ds.Tables[0].Rows[0]["CaptiveCommonETP"].ToString();
                    txtETPCost.Text = ds.Tables[0].Rows[0]["ETPCost"].ToString();
                    txtRebateClaimed.Text = ds.Tables[0].Rows[0]["RebateClaimed"].ToString();
                    txtYearoftheClaim.Text = ds.Tables[0].Rows[0]["YearoftheClaim"].ToString();
                    txtAnyGovtAgency.Text = ds.Tables[0].Rows[0]["AnyGovtAgency"].ToString();
                    txtYearsCommercialProduction.Text = ds.Tables[0].Rows[0]["YearsCommercialProduction"].ToString();
                    txtCommencementCommercialOperation.Text = ds.Tables[0].Rows[0]["CommencementCommercialOperation"].ToString();
                    txtDateofCommencementUtilization.Text = ds.Tables[0].Rows[0]["DateofCommencementUtilization"].ToString();
                    txtCurrentClaim.Text = ds.Tables[0].Rows[0]["CurrentClaim"].ToString();
                    txtApprovedProjectCost.Text = ds.Tables[0].Rows[0]["ApprovedProjectCost"].ToString();
                    txtActualCostInvested.Text = ds.Tables[0].Rows[0]["ActualCostInvested"].ToString();
                    if (ds.Tables[0].Rows[0]["UtilizationETPCETP"].ToString() != "")
                    {
                        ddlUtilizationETPCETP.SelectedValue = ds.Tables[0].Rows[0]["UtilizationETPCETP"].ToString();
                    }
                    ddlUtilizationETPCETP_SelectedIndexChanged(this, EventArgs.Empty);

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
                                if (Docid == "141001")
                                {
                                    objClsFileUpload.AssignPath(hyOperatorRate, Path);
                                }
                                else if (Docid == "141002")
                                {
                                    objClsFileUpload.AssignPath(hyEffulent, Path);
                                }
                                else if (Docid == "141003")
                                {
                                    objClsFileUpload.AssignPath(hyBills, Path);
                                }
                                else if (Docid == "141004")
                                {
                                    objClsFileUpload.AssignPath(hyUtilisation, Path);
                                }
                                else if (Docid == "141005")
                                {
                                    objClsFileUpload.AssignPath(hyOtherRelevant, Path);
                                }
                                else if (Docid == "141006")
                                {
                                    objClsFileUpload.AssignPath(hyCharteredEngineerCETPETP, Path);
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


        public string GeneralInformationcheck()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (RbtnTypeofETP.SelectedValue == "2" && txtOtherETP.Text.Trim().TrimEnd() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Specify Effluent Treatment Plant (ETP)/Common Effluent Treatment Plant \\n";
                slno = slno + 1;
            }
            if (ddlUtilizationETPCETP.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Utilization ETP/CETP  \\n";
                slno = slno + 1;
            }
            else if (ddlUtilizationETPCETP.SelectedValue == "1")
            {
                if (txtCaptiveCommonETP.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Captive or Common ETP \\n";
                    slno = slno + 1;
                }
                if (txtETPCost.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Cost of the ETP \\n";
                    slno = slno + 1;
                }
                if (txtRebateClaimed.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Rebate Claimed  \\n";
                    slno = slno + 1;
                }
                if (txtYearoftheClaim.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Year of the Claim \\n";
                    slno = slno + 1;
                }
                if (txtYearsCommercialProduction.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Years of Commercial Production  \\n";
                    slno = slno + 1;
                }
            }
            if (txtApprovedProjectCost.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Approved Project Cost (In Rs)  \\n";
                slno = slno + 1;
            }
            if (txtActualCostInvested.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Actual Cost Invested (In Rs)  \\n";
                slno = slno + 1;
            }
            if (txtCETPETPDetails.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Details of the CETP/ETP -O&M Operator/Agency/Firm  \\n";
                slno = slno + 1;
            }
            
            if (grdETPDetails.Rows.Count < 1)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Add Details of Effluent Treatment Charges(O&M charges) during last 6 months(half year) \\n";
                slno = slno + 1;
            }
            
            if (txtCommencementCommercialOperation.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Commencement of Commercial Operation of Industry/Enterprise   \\n";
                slno = slno + 1;
            }
            if (txtDateofCommencementUtilization.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Date of Commencement of Utilization of CETP/ETP \\n";
                slno = slno + 1;
            }
            if (txtCurrentClaim.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Current Claim (In Rupees)  \\n";
                slno = slno + 1;
            }
            return ErrorMsg;
        }
        protected void btnOperatorRate_Click(object sender, EventArgs e)
        {

            if (fuOperatorRate.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuOperatorRate);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuOperatorRate);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuOperatorRate, hyOperatorRate, "OperatorRateChart", Session["IncentiveID"].ToString(), "14", "141001", Session["uid"].ToString(), "USER");
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

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        protected void btnEffulent_Click(object sender, EventArgs e)
        {

            if (fluEffluent.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fluEffluent);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fluEffluent);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fluEffluent, hyEffulent, "RecordInflowOutflowETPDischargeTSPCB", Session["IncentiveID"].ToString(), "14", "141002", Session["uid"].ToString(), "USER");

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

        protected void btnBills_Click(object sender, EventArgs e)
        {

            if (fuBills.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuBills);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuBills);
                if (Mimetype == "application/pdf")
                {

                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuBills, hyBills, "BillsGeneratedCETPOM", Session["IncentiveID"].ToString(), "14", "141003", Session["uid"].ToString(), "USER");

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

        protected void btnUtilisation_Click(object sender, EventArgs e)
        {

            if (fuUtilisation.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuUtilisation);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuUtilisation);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuUtilisation, hyUtilisation, "DateofCommencementofutilisationCETP", Session["IncentiveID"].ToString(), "14", "141004", Session["uid"].ToString(), "USER");

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

        public void DeleteFile(string strFileName)
        {//Delete file from the server
            if (strFileName.Trim().Length > 0)
            {
                FileInfo fi = new FileInfo(strFileName);
                if (fi.Exists)//if file exists delete it
                {
                    fi.Delete();
                }
            }
        }

        protected void btnOtherRelevant_Click(object sender, EventArgs e)
        {

            if (fuOtherRelevant.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuOtherRelevant);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuOtherRelevant);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuOtherRelevant, hyOtherRelevant, "OtherRelevantUtilizationCertificates", Session["IncentiveID"].ToString(), "14", "141005", Session["uid"].ToString(), "USER");

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
                    string errormsgAttach = ObjCAFClass.ValidateMandatoryAttachments(Session["IncentiveID"].ToString(), "14");
                    if (errormsgAttach.Trim().TrimStart() != "")
                    {
                        string message = "alert('" + errormsgAttach + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }

                    RebateCharges ObjRebateCharges = new RebateCharges();

                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    ObjRebateCharges.IncentiveId = Session["IncentiveID"].ToString();


                    ObjRebateCharges.TypeofETP = RbtnTypeofETP.SelectedValue;
                    ObjRebateCharges.OtherETP = txtOtherETP.Text.Trim().TrimStart();
                    ObjRebateCharges.CETPETPDetails = txtCETPETPDetails.Text.Trim().TrimStart();
                    ObjRebateCharges.CaptiveCommonETP = GetDecimalNullValue(txtCaptiveCommonETP.Text.Trim().TrimStart());
                    ObjRebateCharges.ETPCost = GetDecimalNullValue(txtETPCost.Text.Trim().TrimStart());
                    ObjRebateCharges.RebateClaimed = GetDecimalNullValue(txtRebateClaimed.Text.Trim().TrimStart());
                    ObjRebateCharges.YearoftheClaim = GetDecimalNullValue(txtYearoftheClaim.Text.Trim().TrimStart());
                    ObjRebateCharges.AnyGovtAgency = GetDecimalNullValue(txtAnyGovtAgency.Text.Trim().TrimStart());
                    ObjRebateCharges.YearsCommercialProduction = GetDecimalNullValue(txtYearsCommercialProduction.Text.Trim().TrimStart());
                    ObjRebateCharges.CommencementCommercialOperation = GetFromatedDateDDMMYYYY(txtCommencementCommercialOperation.Text.Trim().TrimStart());
                    ObjRebateCharges.DateofCommencementUtilization = GetFromatedDateDDMMYYYY(txtDateofCommencementUtilization.Text.Trim().TrimStart());
                    ObjRebateCharges.CurrentClaim = txtCurrentClaim.Text.Trim().TrimStart();
                    ObjRebateCharges.ApprovedProjectCost = GetDecimalNullValue(txtApprovedProjectCost.Text.Trim().TrimStart());
                    ObjRebateCharges.ActualCostInvested = GetDecimalNullValue(txtActualCostInvested.Text.Trim().TrimStart());
                    ObjRebateCharges.UtilizationETPCETP = ddlUtilizationETPCETP.SelectedValue;

                    ObjRebateCharges.AmountAvailed = GetDecimalNullValue(txtAmountAvailed.Text.Trim().TrimStart());
                    ObjRebateCharges.SanctionOrderNo = txtSanctionOrderNo.Text.Trim().TrimStart();
                    ObjRebateCharges.DateAvailed = GetFromatedDateDDMMYYYY(txtDateAvailed.Text.Trim().TrimStart());

                    ObjRebateCharges.CreatedBy = ObjLoginNewvo.uid;
                    string Validstatus = ObjCAFClass.InsertingOfCETPETPDtls(ObjRebateCharges);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        Response.Redirect("frmassistancedevelopment.aspx?next=" + "N");
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

        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmOtherInfrastructure.aspx?Previous=" + "P");
        }

        protected void RbtnTypeofETP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RbtnTypeofETP.SelectedValue == "2")
            {
                divETPOthers.Visible = true;
            }
            else
            {
                divETPOthers.Visible = false;
            }
        }

        public string ValidatePowerDtls()
        {
            int slno = 1;
            string ErrorMsg = "";

            //if (txtMonthYear.Text.Trim().TrimStart() == "")
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Select Month & Year \\n";
            //    slno = slno + 1;
            //}
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
            if (ddlOMComponents.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select O&M Component \\n";
                slno = slno + 1;
            }
            if (txtEffluentTreated.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Eneter Effluent Treated (in KL) \\n";
                slno = slno + 1;
            }
            if (txtEffluentTreatmentCharges.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Eneter Effluent Treatment Charges (In Rupees) \\n";
                slno = slno + 1;
            }


            return ErrorMsg;
        }
        protected void btnPowerutilizedadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["ETPCharges_ID"] == null)
                {
                    ViewState["ETPCharges_ID"] = "0";
                }

                string errormsg = ValidatePowerDtls();
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

                    EPTChargesVo objEPTChargesVo = new EPTChargesVo();

                    objEPTChargesVo.ETPCharges_ID = ViewState["ETPCharges_ID"].ToString();
                    objEPTChargesVo.TransType = "INS";
                    objEPTChargesVo.IncentiveId = Session["IncentiveID"].ToString();
                    objEPTChargesVo.Created_by = ObjLoginNewvo.uid;

                    objEPTChargesVo.FinancialYear = ddlFinYear.SelectedValue;
                    objEPTChargesVo.FinancialYearText = ddlFinYear.SelectedItem.Text;

                    objEPTChargesVo.TypeOfFinancialYear = ddlFin1stOr2ndHalfyear.SelectedValue;
                    objEPTChargesVo.TypeOfFinancialYearText = ddlFin1stOr2ndHalfyear.SelectedItem.Text;
                    objEPTChargesVo.ComponentId = ddlOMComponents.SelectedValue;

                    //objEPTChargesVo.MonthYear = GetFromatedDateDDMMYYYY(txtMonthYear.Text.Trim().TrimStart());
                    objEPTChargesVo.EffluentTreated = GetDecimalNullValue(txtEffluentTreated.Text.Trim().TrimStart());
                    objEPTChargesVo.EffluentTreatmentCharges = GetDecimalNullValue(txtEffluentTreatmentCharges.Text.Trim().TrimStart());


                    string Validstatus = ObjCAFClass.InsertETPChargesLastSixmonthsDetails(objEPTChargesVo);
                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        btnPowerutilizedadd.Text = "Add New";
                        ViewState["ETPCharges_ID"] = "0";

                        //txtMonthYear.Text = "";
                        ddlFinYear.SelectedValue = "0";
                        ddlFin1stOr2ndHalfyear.SelectedValue = "0";
                        ddlOMComponents.SelectedValue = "0";

                        txtEffluentTreated.Text = "";
                        txtEffluentTreatmentCharges.Text = "";

                        BindETPChargesDtls(Session["IncentiveID"].ToString());
                        lblmsg.Text = "Saved Successfully";
                        Failure.Visible = false;
                        success.Visible = true;
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
        protected void grdETPDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                //txtMonthYear.Text = ((Label)(gr.FindControl("lblMonthYear"))).Text;
                ddlFinYear.SelectedValue = ((Label)(gr.FindControl("lblEnergyFinancialYearID"))).Text;
                ddlFin1stOr2ndHalfyear.SelectedValue = ((Label)(gr.FindControl("lblTypeOfFinancialYear"))).Text;
                ddlOMComponents.SelectedValue = ((Label)(gr.FindControl("lblComponentId"))).Text;

                txtEffluentTreated.Text = ((Label)(gr.FindControl("lblEffluentTreated"))).Text;
                txtEffluentTreatmentCharges.Text = ((Label)(gr.FindControl("lblEffluentTreatmentCharges"))).Text;

                ViewState["ETPCharges_ID"] = ((Label)(gr.FindControl("lblETPChargesID"))).Text;
                btnPowerutilizedadd.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];


                EPTChargesVo objEPTChargesVo = new EPTChargesVo();

                objEPTChargesVo.ETPCharges_ID = ((Label)(gr.FindControl("lblETPChargesID"))).Text;
                objEPTChargesVo.TransType = "DLT";
                objEPTChargesVo.IncentiveId = Session["IncentiveID"].ToString();
                objEPTChargesVo.Created_by = ObjLoginNewvo.uid;


                string Validstatus = ObjCAFClass.InsertETPChargesLastSixmonthsDetails(objEPTChargesVo);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnPowerutilizedadd.Text = "Add New";
                    ViewState["ETPCharges_ID"] = "0";

                    //txtMonthYear.Text = "";
                    ddlFinYear.SelectedValue = "0";
                    ddlFin1stOr2ndHalfyear.SelectedValue = "0";
                    ddlOMComponents.SelectedValue = "0";
                    txtEffluentTreated.Text = "";
                    txtEffluentTreatmentCharges.Text = "";

                    BindETPChargesDtls(Session["IncentiveID"].ToString());
                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }

        protected void BindETPChargesDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GeTETPChargesDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    grdETPDetails.DataSource = dsnew.Tables[0];
                    grdETPDetails.DataBind();
                }
                else
                {
                    grdETPDetails.DataSource = null;
                    grdETPDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GeTETPChargesDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_ETPCharges_DTLS", pp);
            return Dsnew;
        }

        protected void btnCharteredEngineerCETPETP_Click(object sender, EventArgs e)
        {
            if (fuCharteredEngineerCETPETP.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuCharteredEngineerCETPETP);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuCharteredEngineerCETPETP);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuCharteredEngineerCETPETP, hyCharteredEngineerCETPETP, "CharteredEngineerCETPETP", Session["IncentiveID"].ToString(), "14", "141006", Session["uid"].ToString(), "USER");

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

        protected void ddlUtilizationETPCETP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUtilizationETPCETP.SelectedValue == "2")
            {
                divcommon1.Visible = false;
                divcommon2.Visible = false;
            }
            else
            {
                divcommon1.Visible = true;
                divcommon2.Visible = true;
            }
        }

        public void BindOnMComponents()
        {
            General Objgeneral = new General();
            try
            {
                ddlOMComponents.Items.Clear();
                DataSet dsdorg = new DataSet();
                dsdorg = Objgeneral.GetOnMComponents();
                if (dsdorg != null && dsdorg.Tables.Count > 0 && dsdorg.Tables[0].Rows.Count > 0)
                {
                    ddlOMComponents.DataSource = dsdorg.Tables[0];
                    ddlOMComponents.DataValueField = "ComponentId";
                    ddlOMComponents.DataTextField = "Component";
                    ddlOMComponents.DataBind();
                }
                AddSelect(ddlOMComponents);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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