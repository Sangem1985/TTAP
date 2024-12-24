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
    public partial class frmOtherInfrastructure : System.Web.UI.Page
    {
        General Gen = new General();
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
                            DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 13);
                            if (drs.Length > 0)
                            {
                                DataSet dsnew = new DataSet();
                                GetInfrastructureDetails(userid, IncentveID);
                                //dsnew = Gen.GetIncentivesISdata(IncentveID, "6");
                                //Filldata(dsnew);
                            }
                            else
                            {
                                if (Request.QueryString[0].ToString() == "N")
                                {
                                    Response.Redirect("frmRebateCharges.aspx?next=" + "N");
                                }
                                else
                                {
                                    Response.Redirect("frmRentalSubsidy.aspx?Previous=" + "P");
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
        public void GetInfrastructureDetails(string uid, string incentiveid)
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

                    txtCategoryofBusiness.Text = dsnew.Tables[0].Rows[0]["Category"].ToString();

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

                            btnNewProductReport.Enabled = false;
                            btnUndertakingContinuationoperation.Enabled = false;
                            btnCertificationLineDepartments.Enabled = false;
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

                ds = Gen.GenericFillDs("USP_GET__Other_Infrastructure_Support_Dtls", p);


                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0] != null && ds.Tables[0].ToString() != "")
                {
                    RbtnIndustrialArea.SelectedValue = ds.Tables[0].Rows[0]["IndustrialArea"].ToString();
                    txtCategoryofBusiness.Text = ds.Tables[0].Rows[0]["CategoryofBusiness"].ToString();
                    txtYearsofOperation.Text = ds.Tables[0].Rows[0]["YearsofOperation"].ToString();
                    txtJustificationforlocation.Text = ds.Tables[0].Rows[0]["Justificationforlocation"].ToString();
                    txtProposedInfrastructureJustification.Text = ds.Tables[0].Rows[0]["ProposedInfrastructureJustification"].ToString();
                    txtSourceOfFinance.Text = ds.Tables[0].Rows[0]["SourceOfFinance"].ToString();
                    txtRoadsPowerWaterDescription.Text = ds.Tables[0].Rows[0]["RoadsPowerWaterDescription"].ToString();
                    txtSupportInfrastructureDescription.Text = ds.Tables[0].Rows[0]["SupportInfrastructureDescription"].ToString();
                    txtSupportEstimateCost.Text = ds.Tables[0].Rows[0]["SupportEstimateCost"].ToString();
                    txtEstimateCostRoadsPowerWater.Text = ds.Tables[0].Rows[0]["EstimateCostRoadsPowerWater"].ToString();

                    txtEstimateCostPower.Text = ds.Tables[0].Rows[0]["EstimateCostPower"].ToString();
                    txtEstimateCostWater.Text = ds.Tables[0].Rows[0]["EstimateCostWater"].ToString();
                    txtEstimateCostDrainageLine.Text = ds.Tables[0].Rows[0]["EstimateCostDrainageLine"].ToString();

                    txtCharteredEngineerName.Text = ds.Tables[0].Rows[0]["CharteredEngineerName"].ToString();
                    txtEstimateCostSupport15.Text = ds.Tables[0].Rows[0]["EstimateCostSupport15"].ToString();

                    txtEstimateCostRoadsPowerWater15.Text = ds.Tables[0].Rows[0]["EstimateCostRoadsPowerWater15"].ToString();
                    txtEstimateCostPower15.Text = ds.Tables[0].Rows[0]["EstimateCostPower15"].ToString();
                    txtEstimateCostWater15.Text = ds.Tables[0].Rows[0]["EstimateCostWater15"].ToString();

                    txtProjectDuration.Text = ds.Tables[0].Rows[0]["ProjectDuration"].ToString();
                    txtMeasuresproposed.Text = ds.Tables[0].Rows[0]["Measuresproposed"].ToString();
                    txtmaintenancecost.Text = ds.Tables[0].Rows[0]["maintenancecost"].ToString();
                    RbtnAssistanceAvailed.SelectedValue = ds.Tables[0].Rows[0]["AssistanceAvailed"].ToString();
                    if (RbtnAssistanceAvailed.SelectedValue == "Y")
                    {
                        txtAmountAvailed.Text = ds.Tables[0].Rows[0]["AmountAvailed"].ToString();
                        txtSanctionOrderNo.Text = ds.Tables[0].Rows[0]["SanctionOrderNo"].ToString();
                        txtDateAvailed.Text = ds.Tables[0].Rows[0]["DateAvailedDDMMYY"].ToString();
                    }
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
                                if (Docid == "131001")
                                {
                                    objClsFileUpload.AssignPath(hyNewProductReport, Path);
                                }
                                else if (Docid == "131002")
                                {
                                    objClsFileUpload.AssignPath(hyCertificationLineDepartments, Path);
                                }
                                else if (Docid == "131003")
                                {
                                    objClsFileUpload.AssignPath(hyUndertakingContinuationoperation, Path);
                                }
                                else if (Docid == "131004")
                                {
                                    objClsFileUpload.AssignPath(HyCharteredEngineerCertificate, Path);
                                }
                                else if (Docid == "131005")
                                {
                                    objClsFileUpload.AssignPath(HyFinancialAssistance, Path);
                                }
                                else if (Docid == "131006")
                                {
                                    objClsFileUpload.AssignPath(hyDepartmentsNodepartmentalFunds, Path);
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
                string errorMsg = ex.Message;
                throw;
            }
        }

        public string GeneralInformationcheck()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (txtCategoryofBusiness.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter the Category of Business \\n";
                slno = slno + 1;
            }
            if (txtYearsofOperation.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Years of Operation from Date of Commencement \\n";
                slno = slno + 1;
            }
            if (txtSourceOfFinance.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter the source of Finance \\n";
                slno = slno + 1;
            }
            if (txtRoadsPowerWaterDescription.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Description of the infrastructure facilities required and its objective for Roads, Power, Water \\n";
                slno = slno + 1;
            }
            if (txtSupportInfrastructureDescription.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Description of the infrastructure facilities required and its objective for Support Infrastructure \\n";
                slno = slno + 1;
            }
            if (txtSupportEstimateCost.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Estimate Cost of Infrastructure facilities (Support) \\n";
                slno = slno + 1;
            }
            //if (txtEstimateCostRoadsPowerWater.Text.TrimStart().Trim() == "")
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Enter Estimate Cost of Infrastructure facilities (Roads, Power, Water, Drainage Line) \\n";
            //    slno = slno + 1;
            //}


            if (txtCharteredEngineerName.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Name of the Chartered Engineer/Agency who prepared the Estimates  \\n";
                slno = slno + 1;
            }
            if (txtEstimateCostSupport15.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter 15 % Estimate Cost of Infrastructure facilities (Support) \\n";
                slno = slno + 1;
            }
            //if (txtEstimateCostRoadsPowerWater15.Text.TrimStart().Trim() == "")
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Enter 15 % Estimate Cost of Infrastructure facilities (Roads, Power, Water) \\n";
            //    slno = slno + 1;
            //}

            if (txtProjectDuration.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter the Duration of the Project  \\n";
                slno = slno + 1;
            }
            if (txtMeasuresproposed.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Measures proposed to maintain the infrastructure created \\n";
                slno = slno + 1;
            }
            if (txtmaintenancecost.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter maintenance cost per annum for Measures proposed infrastructure created   \\n";
                slno = slno + 1;
            }
            if (RbtnAssistanceAvailed.SelectedValue == "Y")
            {
                if (txtAmountAvailed.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Amount Availed  \\n";
                    slno = slno + 1;
                }
                if (txtSanctionOrderNo.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Amount Availed Sanction Order No \\n";
                    slno = slno + 1;
                }
                if (txtDateAvailed.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Date of Availed  \\n";
                    slno = slno + 1;
                }
            }
            return ErrorMsg;
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
                    string errormsgAttach = ObjCAFClass.ValidateMandatoryAttachments(Session["IncentiveID"].ToString(), "13");
                    if (errormsgAttach.Trim().TrimStart() != "")
                    {
                        string message = "alert('" + errormsgAttach + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                    OtherInfrastructure objInfrastructure = new OtherInfrastructure();

                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    objInfrastructure.IncentiveId = Session["IncentiveID"].ToString();

                    objInfrastructure.IndustrialArea = RbtnIndustrialArea.SelectedValue;
                    objInfrastructure.CategoryofBusiness = txtCategoryofBusiness.Text.Trim().TrimStart();
                    objInfrastructure.YearsofOperation = GetDecimalNullValue(txtYearsofOperation.Text.Trim().TrimStart());
                    objInfrastructure.Justificationforlocation = txtJustificationforlocation.Text.Trim().TrimStart();
                    objInfrastructure.ProposedInfrastructureJustification = txtProposedInfrastructureJustification.Text.Trim().TrimStart();
                    objInfrastructure.SourceOfFinance = txtSourceOfFinance.Text.Trim().TrimStart();
                    objInfrastructure.RoadsPowerWaterDescription = txtRoadsPowerWaterDescription.Text.Trim().TrimStart();
                    objInfrastructure.SupportInfrastructureDescription = txtSupportInfrastructureDescription.Text.Trim().TrimStart();
                    objInfrastructure.SupportEstimateCost = GetDecimalNullValue(txtSupportEstimateCost.Text.Trim().TrimStart());

                    objInfrastructure.EstimateCostRoadsPowerWater = GetDecimalNullValue(txtEstimateCostRoadsPowerWater.Text.Trim().TrimStart());
                    objInfrastructure.EstimateCostPower = GetDecimalNullValue(txtEstimateCostPower.Text.Trim().TrimStart());
                    objInfrastructure.EstimateCostWater = GetDecimalNullValue(txtEstimateCostWater.Text.Trim().TrimStart());
                    objInfrastructure.EstimateCostDrainageLine = GetDecimalNullValue(txtEstimateCostDrainageLine.Text.Trim().TrimStart());

                    objInfrastructure.CharteredEngineerName = txtCharteredEngineerName.Text.Trim().TrimStart();
                    objInfrastructure.EstimateCostSupport15 = GetDecimalNullValue(txtEstimateCostSupport15.Text.Trim().TrimStart());

                    objInfrastructure.EstimateCostRoadsPowerWater15 = GetDecimalNullValue(txtEstimateCostRoadsPowerWater15.Text.Trim().TrimStart());
                    objInfrastructure.EstimateCostPower15 = GetDecimalNullValue(txtEstimateCostPower15.Text.Trim().TrimStart());
                    objInfrastructure.EstimateCostWater15 = GetDecimalNullValue(txtEstimateCostWater15.Text.Trim().TrimStart());

                    objInfrastructure.ProjectDuration = txtProjectDuration.Text.Trim().TrimStart();
                    objInfrastructure.Measuresproposed = GetDecimalNullValue(txtMeasuresproposed.Text.Trim().TrimStart());
                    objInfrastructure.maintenancecost = GetDecimalNullValue(txtmaintenancecost.Text.Trim().TrimStart());
                    objInfrastructure.AssistanceAvailed = RbtnAssistanceAvailed.SelectedValue;
                    if (objInfrastructure.AssistanceAvailed == "Y")
                    {
                        objInfrastructure.AmountAvailed = GetDecimalNullValue(txtAmountAvailed.Text.Trim().TrimStart());
                        objInfrastructure.SanctionOrderNo = txtSanctionOrderNo.Text.Trim().TrimStart();
                        objInfrastructure.DateAvailed = GetFromatedDateDDMMYYYY(txtDateAvailed.Text.Trim().TrimStart());
                    }

                    objInfrastructure.CreatedBy = ObjLoginNewvo.uid;
                    string Validstatus = ObjCAFClass.InsertingOfInfrastructureSupportDtls(objInfrastructure);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        Response.Redirect("frmRebateCharges.aspx?next=" + "N");
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
            Response.Redirect("frmRentalSubsidy.aspx?Previous=" + "P");
        }


        protected void btnNewProductReport_Click(object sender, EventArgs e)
        {
            if (fuNewProductReport.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuNewProductReport);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuNewProductReport);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuNewProductReport, hyNewProductReport, "Projectapprovalreport", Session["IncentiveID"].ToString(), "13", "131001", Session["uid"].ToString(), "USER");

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

        protected void btnCertificationLineDepartments_Click(object sender, EventArgs e)
        {
            if (fuCertificationLineDepartments.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuCertificationLineDepartments);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuCertificationLineDepartments);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuCertificationLineDepartments, hyCertificationLineDepartments, "CertificationLineDepartments", Session["IncentiveID"].ToString(), "13", "131002", Session["uid"].ToString(), "USER");

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

        protected void btnUndertakingContinuationoperation_Click(object sender, EventArgs e)
        {
            if (fuUndertakingContinuationoperation.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuUndertakingContinuationoperation);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuUndertakingContinuationoperation);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuUndertakingContinuationoperation, hyUndertakingContinuationoperation, "UndertakingContinuationoperation", Session["IncentiveID"].ToString(), "13", "131003", Session["uid"].ToString(), "USER");

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

        protected void RbtnAssistanceAvailed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RbtnAssistanceAvailed.SelectedValue == "Y")
            {
                divSubsidyAvailed.Visible = true;
            }
            else
            {
                divSubsidyAvailed.Visible = false;
            }
        }

        protected void btnCharteredEngineerCertificate_Click(object sender, EventArgs e)
        {
            if (fuCharteredEngineerCertificate.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuCharteredEngineerCertificate);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuCharteredEngineerCertificate);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuCharteredEngineerCertificate, HyCharteredEngineerCertificate, "CharteredEngineerCertificate", Session["IncentiveID"].ToString(), "13", "131004", Session["uid"].ToString(), "USER");

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

        protected void btnFinancialAssistance_Click(object sender, EventArgs e)
        {
            if (fuFinancialAssistance.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuFinancialAssistance);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuFinancialAssistance);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuFinancialAssistance, HyFinancialAssistance, "FinancialAssistance", Session["IncentiveID"].ToString(), "13", "131005", Session["uid"].ToString(), "USER");

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

        protected void btnDepartmentsNodepartmentalFunds_Click(object sender, EventArgs e)
        {
            if (fuDepartmentsNodepartmentalFunds.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuDepartmentsNodepartmentalFunds);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuDepartmentsNodepartmentalFunds);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuDepartmentsNodepartmentalFunds, hyDepartmentsNodepartmentalFunds, "NoDepartmentalFundsCertification", Session["IncentiveID"].ToString(), "13", "131006", Session["uid"].ToString(), "USER");

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

        protected void txtEstimateCostRoadsPowerWater_TextChanged(object sender, EventArgs e)
        {
            GetTotalvalueOfEstimateCost();

            if (txtEstimateCostRoadsPowerWater.Text.Trim().TrimStart() != "" && txtEstimateCostRoadsPowerWater.Text.Trim().TrimStart() != "0")
            {
                txtEstimateCostRoadsPowerWater15.Text = ((Convert.ToDecimal(txtEstimateCostRoadsPowerWater.Text.Trim().TrimStart()) * 15) / 100).ToString("#.##");
                txtEstimateCostRoadsPowerWater15.Enabled = false;
            }
            if (txtEstimateCostPower.Text.Trim().TrimStart() != "" && txtEstimateCostPower.Text.Trim().TrimStart() != "0")
            {
                txtEstimateCostPower15.Text = ((Convert.ToDecimal(txtEstimateCostPower.Text.Trim().TrimStart()) * 15) / 100).ToString("#.##");
                txtEstimateCostPower15.Enabled = false;
            }
            if (txtEstimateCostWater.Text.Trim().TrimStart() != "" && txtEstimateCostWater.Text.Trim().TrimStart() != "0")
            {
                txtEstimateCostWater15.Text = ((Convert.ToDecimal(txtEstimateCostWater.Text.Trim().TrimStart()) * 15) / 100).ToString("#.##");
                txtEstimateCostWater15.Enabled = false;
            }

            decimal TotalValueofInfra = 0;
            TotalValueofInfra = Convert.ToDecimal(((Convert.ToDecimal(GetDecimalNullValue(txtEstimateCostRoadsPowerWater.Text.Trim().TrimStart())) +
               Convert.ToDecimal(GetDecimalNullValue(txtEstimateCostPower.Text.Trim().TrimStart())) +
               Convert.ToDecimal(GetDecimalNullValue(txtEstimateCostWater.Text.Trim().TrimStart()))).ToString("#.##")));


            if (TotalValueofInfra != 0)
            {
                txtEstimateCostSupport15.Text = ((TotalValueofInfra * 15) / 100).ToString("#.##");
            }
        }

        public void GetTotalvalueOfEstimateCost()
        {
            txtSupportEstimateCost.Text = (Convert.ToDecimal(GetDecimalNullValue(txtEstimateCostRoadsPowerWater.Text.Trim().TrimStart())) +
                Convert.ToDecimal(GetDecimalNullValue(txtEstimateCostPower.Text.Trim().TrimStart())) +
                Convert.ToDecimal(GetDecimalNullValue(txtEstimateCostWater.Text.Trim().TrimStart())) +
                Convert.ToDecimal(GetDecimalNullValue(txtEstimateCostDrainageLine.Text.Trim().TrimStart()))).ToString();
        }
    }
}