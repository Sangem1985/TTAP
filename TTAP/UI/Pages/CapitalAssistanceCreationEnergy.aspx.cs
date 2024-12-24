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
    public partial class CapitalAssistanceCreationEnergy : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        CapAssCreationEnergyBO objBO = new CapAssCreationEnergyBO();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        List<EquipmentDetailsBO> listGridBO = new List<EquipmentDetailsBO>();
        CAFClass ObjCAFClass = new CAFClass();

        DataSet ds = new DataSet();
        General Gen = new General();
        decimal Cat1 = 0, Cat2 = 0, Cat3 = 0, Cat4 = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["uid"] != null)
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
                            DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 2);
                            if (drs.Length > 0)
                            {
                                DataSet dsnew = new DataSet();
                                GetCapitalAssistanceCreationEnergy(userid, IncentveID);
                                BindEquipmentDtls(Session["IncentiveID"].ToString());
                            }
                            else
                            {
                                if (Request.QueryString[0].ToString() == "N")
                                {
                                    Response.Redirect("InterestSubsidy.aspx?next=" + "N");
                                }
                                else
                                {
                                    Response.Redirect("frmCapitalAssistanceExistingUnit.aspx?Previous=" + "P");
                                }
                            }
                            EnableDisableForm(divClaimAmount.Controls, false);
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

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            try
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
                    string errormsgAttach = ObjCAFClass.ValidateMandatoryAttachments(Session["IncentiveID"].ToString(), "2");
                    if (errormsgAttach.Trim().TrimStart() != "")
                    {
                        string message = "alert('" + errormsgAttach + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }

                    CapAssCreationEnergyBO objBO = new CapAssCreationEnergyBO();
                    objBO.IncentiveID = Session["IncentiveID"].ToString();

                    string Typeofinfra = "";
                    foreach (ListItem li in chkTypeofInfrastructure.Items)
                    {
                        if (li.Selected)
                        {
                            if (Typeofinfra == "")
                            {
                                Typeofinfra = li.Value;
                            }
                            else
                            {
                                Typeofinfra = Typeofinfra + "," + li.Value;
                            }
                        }
                    }

                    objBO.TypeofInfrastructure = Typeofinfra;
                    objBO.CreatedCETP = RbtnCETPcreated.SelectedValue;
                    objBO.TextTileType = RbtnTextTileType.SelectedValue;
                    objBO.TotalCostCapital = (txtTotalCostCapital.Text.Trim().TrimStart() != "") ? txtTotalCostCapital.Text.Trim().TrimStart() : "0";
                    objBO.OperationalCostMLDofInputWater = (txtMLDofInputWater.Text.Trim().TrimStart() != "") ? txtMLDofInputWater.Text.Trim().TrimStart() : "0";


                    objBO.GOI = (txtGOI.Text.Trim().TrimStart() != "") ? txtGOI.Text.Trim().TrimStart() : "0";
                    objBO.StateGovt = (txtStateGovt.Text.Trim().TrimStart() != "") ? txtStateGovt.Text.Trim().TrimStart() : "0";
                    objBO.Beneficiary = (txtBeneficiary.Text.Trim().TrimStart() != "") ? txtBeneficiary.Text.Trim().TrimStart() : "0";
                    objBO.Bank = (txtBank.Text.Trim().TrimStart() != "") ? txtBank.Text.Trim().TrimStart() : "0";

                    objBO.EnergyEquipment = GetDecimalNullValue(txtEnergyEquipment.Text.Trim());
                    objBO.WaterEquipment = GetDecimalNullValue(txtWaterEquipment.Text.Trim());
                    objBO.EnvironmentalEquipment = GetDecimalNullValue(txtEnvironmentalEquipment.Text.Trim());
                    objBO.EffluentTreatment = GetDecimalNullValue(txtEffluentTreatment.Text.Trim());
                    ////objBO.Instalment1 = txtInstalment1.Text.Trim();
                    ////objBO.Instalment2 = txtInstalment2.Text.Trim();
                    objBO.AmountSubsidyClaimedEnergy = (txtSubsidyClaimedEnergyWaterEnvironmental.Text.Trim().TrimStart() != "") ? txtSubsidyClaimedEnergyWaterEnvironmental.Text.Trim().TrimStart() : "0";
                    objBO.AmountSubsidyClaimedEffluent = (txtSubsidyClaimedforCommonEffluentTreatment.Text.Trim().TrimStart() != "") ? txtSubsidyClaimedforCommonEffluentTreatment.Text.Trim().TrimStart() : "0";
                    objBO.CreatedBy = Session["uid"].ToString();
                    // int result = objDAL.insertCapAssCreationEnergyDB(objBO, listGridBO);
                    string Validstatus = ObjCAFClass.InsertingOfCapitalAssistanceEnergy(objBO);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        Response.Redirect("InterestSubsidy.aspx?next=" + "N");
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
        public string GetDecimalNullValue(string Input)
        {
            string InputValue = "";

            InputValue = (Input != "") ? Input : "0";

            return InputValue;
        }
        public string ValidateControls()
        {
            int slno = 1;
            string ErrorMsg = "";

            int selectedCount = chkTypeofInfrastructure.Items.Cast<ListItem>().Count(li => li.Selected);
            if (selectedCount == 0)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select at Least One Type of Infrastructure Created \\n";
                slno = slno + 1;
            }

            if (txtTotalCostCapital.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Eneter Total Cost of Capital \\n";
                slno = slno + 1;
            }
            if (txtMLDofInputWater.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Eneter Operational Cost per MLD of Input Water \\n";
                slno = slno + 1;
            }

            if (txtGOI.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Eneter Percentage Share of GOI \\n";
                slno = slno + 1;
            }
            if (txtStateGovt.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Eneter Percentage Share of State Govt \\n";
                slno = slno + 1;
            }
            if (txtBeneficiary.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Eneter Percentage Share of Beneficiary \\n";
                slno = slno + 1;
            }
            if (txtBank.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Eneter Percentage Share of Bank \\n";
                slno = slno + 1;
            }

            if (txtEnergyEquipment.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Eneter Cost of Equipment for Energy Conservation Infra \\n";
                slno = slno + 1;
            }
            if (txtWaterEquipment.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Eneter Cost of Equipment for Water Conservation Infra \\n";
                slno = slno + 1;
            }
            if (txtEnvironmentalEquipment.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Eneter Cost of Equipment for Environmental Conservation Infra \\n";
                slno = slno + 1;
            }
            if (txtEffluentTreatment.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Eneter Cost of Common Effluent Treatment Plant at Industrial Park / Cluster \\n";
                slno = slno + 1;
            }


            if (GvEquipmentDtls.Rows.Count < 1)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Add Details of Equipment Purchased for Cleaner Production Measures \\n";
                slno = slno + 1;
            }
            if (txtSubsidyClaimedEnergyWaterEnvironmental.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Eneter Amount of Subsidy Claimed for Creation of Energy, Water and Environmental Conservation Infrastructure \\n";
                slno = slno + 1;
            }
            if (txtSubsidyClaimedforCommonEffluentTreatment.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Eneter Amount of Subsidy Claimed for Common Effluent Treatment Plant \\n";
                slno = slno + 1;
            }

            return ErrorMsg;
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

        public void GetCapitalAssistanceCreationEnergy(string uid, string IncentiveID)
        {

            try
            {

                DataSet dsnew = new DataSet();
                dsnew = GetapplicationDtls(uid, IncentiveID);
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    lblTSIPassUIDNumber.InnerText = dsnew.Tables[0].Rows[0]["Uid_NO"].ToString();
                    lblCommonApplicationNumber.InnerText = dsnew.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                    lblTypeofApplicant.InnerText = dsnew.Tables[0].Rows[0]["TypeOfIndustryText"].ToString();
                    lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCP"].ToString();

                    string ENABLINGCONTRILS = dsnew.Tables[0].Rows[0]["ENABLINGCONTRILS"].ToString();
                    if ((dsnew.Tables[0].Rows[0]["intStatusid"].ToString() == null || dsnew.Tables[0].Rows[0]["intStatusid"].ToString() == "")) //&& ENABLINGCONTRILS == "N")
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
                        if (Convert.ToInt32(applicationStatus) >= 2 || ENABLINGCONTRILS == "Y")
                        {
                            EnableDisableForm(Page.Controls, false);

                            DivDirectorDetails.Visible = false;

                            GvEquipmentDtls.Columns[16].Visible = false;
                            GvEquipmentDtls.Columns[15].Visible = false;

                            btnDocumentaryproof.Enabled = false;
                            btnProjectCompletion.Enabled = false;
                            btnCopyofdocuments.Enabled = false;
                            btnCopyofApproval.Enabled = false;
                            btnClearanceLocal.Enabled = false;
                            btnConsenttoEstablish.Enabled = false;
                            btnDetailedProject.Enabled = false;
                            btnLandregistration.Enabled = false;
                            btnCharteredEngineerCertificate.Enabled = false;
                            btnProjectCertificate.Enabled = false;
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
                p[1].Value = IncentiveID;
                ds = Gen.GenericFillDs("USP_GET_CAPITALASSISTANCEFORCREATIONENERGY", p);
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.ToString() != "" && ds.Tables[0].Rows.ToString() != null)
                {
                    string TypeofInfrastructure = ds.Tables[0].Rows[0]["TypeofInfrastructure"].ToString();
                    if (TypeofInfrastructure != "")
                    {
                        string[] TypeofInfrastructureVal = TypeofInfrastructure.Split(',');

                        foreach (string Value in TypeofInfrastructureVal)
                        {
                            int Index = chkTypeofInfrastructure.Items.IndexOf(chkTypeofInfrastructure.Items.FindByValue(Value));
                            chkTypeofInfrastructure.Items[Index].Selected = true;
                        }
                    }
                    // chkTypeofInfrastructure.SelectedValue = ds.Tables[0].Rows[0]["TypeofInfrastructure"].ToString();
                    RbtnCETPcreated.SelectedValue = ds.Tables[0].Rows[0]["CreatedCETP"].ToString();

                    if (ds.Tables[0].Rows[0]["TextTileType"].ToString() != "")
                        RbtnTextTileType.SelectedValue = ds.Tables[0].Rows[0]["TextTileType"].ToString();

                    txtTotalCostCapital.Text = ds.Tables[0].Rows[0]["TotalCostCapital"].ToString();
                    txtMLDofInputWater.Text = ds.Tables[0].Rows[0]["OperationalCostMLDofInputWater"].ToString();

                    txtGOI.Text = ds.Tables[0].Rows[0]["GOI"].ToString();
                    txtStateGovt.Text = ds.Tables[0].Rows[0]["StateGovt"].ToString();
                    txtBeneficiary.Text = ds.Tables[0].Rows[0]["Beneficiary"].ToString();
                    txtBank.Text = ds.Tables[0].Rows[0]["Bank"].ToString();

                    txtEnergyEquipment.Text = ds.Tables[0].Rows[0]["EnergyEquipment"].ToString();
                    txtWaterEquipment.Text = ds.Tables[0].Rows[0]["WaterEquipment"].ToString();
                    txtEnvironmentalEquipment.Text = ds.Tables[0].Rows[0]["EnvironmentalEquipment"].ToString();
                    txtEffluentTreatment.Text = ds.Tables[0].Rows[0]["EffluentTreatment"].ToString();

                    //txtCostofEnergy.Text = ds.Tables[0].Rows[0]["CostofEnergy"].ToString();
                    //txtCostofWater.Text = ds.Tables[0].Rows[0]["CostofWater"].ToString();
                    //txtCostofEnvironmental.Text = ds.Tables[0].Rows[0]["CostofEnvironmental"].ToString();
                    //txtCostofEffluent.Text = ds.Tables[0].Rows[0]["CostofEffluent"].ToString();
                    //txtInstalment1.Text = ds.Tables[0].Rows[0]["Instalment1"].ToString();
                    //txtInstalment2.Text = ds.Tables[0].Rows[0]["Instalment2"].ToString();
                    txtSubsidyClaimedEnergyWaterEnvironmental.Text = ds.Tables[0].Rows[0]["AmountSubsidyClaimedEnergy"].ToString();
                    txtSubsidyClaimedforCommonEffluentTreatment.Text = ds.Tables[0].Rows[0]["AmountSubsidyClaimedEffluent"].ToString();
                }

                //DataSet dsattachments = Gen.GETINCENTIVESCHECKLIST(uid, IncentiveID);
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
                                if (Docid == "21001")
                                {
                                    objClsFileUpload.AssignPath(hyLandregistration, Path);
                                }
                                else if (Docid == "21002")
                                {
                                    objClsFileUpload.AssignPath(hyDetailedProject, Path);
                                }
                                else if (Docid == "21003")
                                {
                                    objClsFileUpload.AssignPath(hyConsenttoEstablish, Path);
                                }
                                else if (Docid == "21004")
                                {
                                    objClsFileUpload.AssignPath(hyClearanceLocal, Path);
                                }
                                else if (Docid == "21005")
                                {
                                    objClsFileUpload.AssignPath(hyCopyofApproval, Path);
                                }
                                else if (Docid == "21006")
                                {
                                    objClsFileUpload.AssignPath(hyCopyofdocuments, Path);
                                }
                                else if (Docid == "21007")
                                {
                                    objClsFileUpload.AssignPath(HyProjectCompletion, Path);
                                }
                                else if (Docid == "21008")
                                {
                                    objClsFileUpload.AssignPath(HyDocumentaryproof, Path);
                                }
                                else if (Docid == "21009")
                                {
                                    objClsFileUpload.AssignPath(HyCharteredEngineerCertificate, Path);
                                }
                                else if (Docid == "21010")
                                {
                                    objClsFileUpload.AssignPath(HyProjectCertificate, Path);
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
        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCapitalAssistanceExistingUnit.aspx?Previous=" + "P");
        }

        //protected void BtnNext_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("InterestSubsidy.aspx?next=" + "N");

        //}
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

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }


        protected void btnLandregistration_Click(object sender, EventArgs e)
        {
            if (fuLandregistration.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuLandregistration);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuLandregistration);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "LandregistrationandLandUsedocuments", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");

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

        protected void btnDetailedProject_Click(object sender, EventArgs e)
        {

            if (fuDetailedProject.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuDetailedProject);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuDetailedProject);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuDetailedProject, hyDetailedProject, "DetailedProjectReportCETPETP", Session["IncentiveID"].ToString(), "2", "21002", Session["uid"].ToString(), "USER");

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

        protected void btnConsenttoEstablish_Click(object sender, EventArgs e)
        {
            if (fuConsenttoEstablish.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuConsenttoEstablish);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuConsenttoEstablish);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuConsenttoEstablish, hyConsenttoEstablish, "EstablishandOperatefromPollutionControlBoard", Session["IncentiveID"].ToString(), "2", "21003", Session["uid"].ToString(), "USER");

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

        protected void btnClearanceLocal_Click(object sender, EventArgs e)
        {

            if (fuClearanceLocal.HasFile)
            {
                string Mimetype = objClsFileUpload.getmimetype(fuClearanceLocal);
                if (Mimetype == "application/pdf")
                {

                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuClearanceLocal, hyClearanceLocal, "ClearancefromLocalAuthority", Session["IncentiveID"].ToString(), "2", "21004", Session["uid"].ToString(), "USER");

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

        protected void btnCopyofApproval_Click(object sender, EventArgs e)
        {

            if (fuCopyofApproval.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuCopyofApproval);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuCopyofApproval);
                if (Mimetype == "application/pdf")
                {

                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuCopyofApproval, hyCopyofApproval, "ApprovalletterfromGovernmentofIndia", Session["IncentiveID"].ToString(), "2", "21005", Session["uid"].ToString(), "USER");

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

        protected void btnCopyofdocuments_Click(object sender, EventArgs e)
        {

            if (fuCopyofdocuments.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuCopyofdocuments);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuCopyofdocuments);
                if (Mimetype == "application/pdf")
                {

                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuCopyofdocuments, hyCopyofdocuments, "DocumentsReceipts", Session["IncentiveID"].ToString(), "2", "21006", Session["uid"].ToString(), "USER");

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

        protected void btnProjectCompletion_Click(object sender, EventArgs e)
        {

            if (fuProjectCompletion.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuProjectCompletion);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuProjectCompletion);
                if (Mimetype == "application/pdf")
                {

                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuProjectCompletion, HyProjectCompletion, "ProjectCompletionCertificateAgenciesDepartments", Session["IncentiveID"].ToString(), "2", "21007", Session["uid"].ToString(), "USER");

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

        protected void btnDocumentaryproof_Click(object sender, EventArgs e)
        {

            if (fuDocumentaryproof.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuDocumentaryproof);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuDocumentaryproof);
                if (Mimetype == "application/pdf")
                {

                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuDocumentaryproof, HyDocumentaryproof, "NatureActivityHandloomCluster", Session["IncentiveID"].ToString(), "2", "21008", Session["uid"].ToString(), "USER");

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
        public string ValidateEquipmentDtls()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (ddlTypeofEquipment.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Type of Equipment \\n";
                slno = slno + 1;
            }
            if (txtNameoftheEquipment.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Name of the Equipment \\n";
                slno = slno + 1;
            }
            if (txtEquipmentNameAddressofSupplier.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Name & Address of Supplier \\n";
                slno = slno + 1;
            }
            if (txtEquipmentInvoiceNo.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Invoice No \\n";
                slno = slno + 1;
            }
            if (txtEquipmentInvoiceDate.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Invoice Date \\n";
                slno = slno + 1;
            }
            if (txtEquipmentDateOfLanding.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Date Of Landing \\n";
                slno = slno + 1;
            }
            if (txtEquipmentDateOfCommissioning.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Date of Commissioning \\n";
                slno = slno + 1;
            }
            if (txtEquipmentWayBillNumber.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Way Bill Number \\n";
                slno = slno + 1;
            }
            if (txtEquipmentDateOfWayBill.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Way Bill Date \\n";
                slno = slno + 1;
            }

            if (txtEquipmentcgst.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter CGST(in Rs) \\n";
                slno = slno + 1;
            }
            if (txtEquipmentsgst.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter SGST(in Rs) \\n";
                slno = slno + 1;
            }
            if (txtEquipmentFreightCharges.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Freight Charges(in Rs) \\n";
                slno = slno + 1;
            }
            if (txtEquipmentInitiationCharges.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Initiation Charges(in Rs) \\n";
                slno = slno + 1;
            }

            return ErrorMsg;
        }
        protected void btnEquipmentDtls_Click(object sender, EventArgs e)
        {

            try
            {
                if (ViewState["Equipment_ID"] == null)
                {
                    ViewState["Equipment_ID"] = "0";
                }

                string errormsg = ValidateEquipmentDtls();
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

                    EquipmentDetailsBO objEquipmentDetailsBO = new EquipmentDetailsBO();

                    objEquipmentDetailsBO.Equipment_ID = ViewState["Equipment_ID"].ToString();
                    objEquipmentDetailsBO.TransType = "INS";
                    objEquipmentDetailsBO.IncentiveId = Session["IncentiveID"].ToString();
                    objEquipmentDetailsBO.Created_by = ObjLoginNewvo.uid;


                    objEquipmentDetailsBO.NameoftheEquipment = txtNameoftheEquipment.Text.Trim().TrimStart();
                    objEquipmentDetailsBO.EquipmentNameAddressofSupplier = txtEquipmentNameAddressofSupplier.Text.Trim().TrimStart();
                    objEquipmentDetailsBO.EquipmentInvoiceNo = txtEquipmentInvoiceNo.Text.Trim().TrimStart();
                    objEquipmentDetailsBO.TypeofEquipmentId = ddlTypeofEquipment.SelectedValue.ToString();
                    objEquipmentDetailsBO.TypeofEquipmentName = ddlTypeofEquipment.SelectedItem.ToString();


                    string[] Ld6 = null;
                    string ConvertedDt56 = "";
                    if (txtEquipmentInvoiceDate.Text.Trim().TrimStart() != "")
                    {
                        Ld6 = txtEquipmentInvoiceDate.Text.Trim().TrimStart().Split('/');
                        ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();
                        objEquipmentDetailsBO.EquipmentInvoiceDate = ConvertedDt56;
                    }
                    else
                    {
                        objEquipmentDetailsBO.EquipmentInvoiceDate = null;
                    }

                    Ld6 = null;
                    ConvertedDt56 = "";

                    if (txtEquipmentDateOfLanding.Text.Trim().TrimStart() != "")
                    {
                        Ld6 = txtEquipmentDateOfLanding.Text.Trim().TrimStart().Split('/');
                        ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();
                        objEquipmentDetailsBO.EquipmentDateOfLanding = ConvertedDt56;
                    }
                    else
                    {
                        objEquipmentDetailsBO.EquipmentDateOfLanding = null;
                    }

                    Ld6 = null;
                    ConvertedDt56 = "";

                    if (txtEquipmentDateOfCommissioning.Text.Trim().TrimStart() != "")
                    {
                        Ld6 = txtEquipmentDateOfCommissioning.Text.Trim().TrimStart().Split('/');
                        ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();
                        objEquipmentDetailsBO.EquipmentDateOfCommissioning = ConvertedDt56;
                    }
                    else
                    {
                        objEquipmentDetailsBO.EquipmentDateOfCommissioning = null;
                    }


                    objEquipmentDetailsBO.EquipmentWayBillNumber = txtEquipmentWayBillNumber.Text.Trim().TrimStart();

                    Ld6 = null;
                    ConvertedDt56 = "";

                    if (txtEquipmentDateOfWayBill.Text.Trim().TrimStart() != "")
                    {
                        Ld6 = txtEquipmentDateOfWayBill.Text.Trim().TrimStart().Split('/');
                        ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();
                        objEquipmentDetailsBO.EquipmentDateOfWayBill = ConvertedDt56;
                    }
                    else
                    {
                        objEquipmentDetailsBO.EquipmentDateOfWayBill = null;
                    }

                    objEquipmentDetailsBO.CostofEquipment = (txtCostofEquipment.Text != "") ? txtCostofEquipment.Text.Trim().TrimStart() : "0";
                    objEquipmentDetailsBO.Equipmentcgst = (txtEquipmentcgst.Text != "") ? txtEquipmentcgst.Text.Trim().TrimStart() : "0";
                    objEquipmentDetailsBO.Equipmentsgst = (txtEquipmentsgst.Text != "") ? txtEquipmentsgst.Text.Trim().TrimStart() : "0";
                    objEquipmentDetailsBO.EquipmentFreightCharges = (txtEquipmentFreightCharges.Text != "") ? txtEquipmentFreightCharges.Text.Trim().TrimStart() : "0";
                    objEquipmentDetailsBO.EquipmentInitiationCharges = (txtEquipmentInitiationCharges.Text != "") ? txtEquipmentInitiationCharges.Text.Trim().TrimStart() : "0";

                    objEquipmentDetailsBO.Total = GetTotal(objEquipmentDetailsBO);


                    string Validstatus = ObjCAFClass.InsertCapitalAssistanceEquipmentDetails(objEquipmentDetailsBO);
                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        if (Validstatus == "EXISTS")
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invoice Number already Exists');", true);
                            return;
                        }
                        else
                        {
                            btnEquipmentDtls.Text = "Add New";
                            ViewState["Equipment_ID"] = "0";

                            ddlTypeofEquipment.SelectedValue = "0";
                            txtNameoftheEquipment.Text = "";
                            txtEquipmentNameAddressofSupplier.Text = "";
                            txtEquipmentInvoiceNo.Text = "";
                            txtEquipmentInvoiceDate.Text = "";
                            txtEquipmentDateOfLanding.Text = "";
                            txtEquipmentDateOfCommissioning.Text = "";
                            txtEquipmentWayBillNumber.Text = "";
                            txtEquipmentDateOfWayBill.Text = "";
                            txtCostofEquipment.Text = "";
                            txtEquipmentcgst.Text = "";
                            txtEquipmentsgst.Text = "";
                            txtEquipmentFreightCharges.Text = "";
                            txtEquipmentInitiationCharges.Text = "";
                            txttotal.Text = "";

                            BindEquipmentDtls(Session["IncentiveID"].ToString());
                            lblmsg.Text = "Saved Successfully";
                            Failure.Visible = false;
                            success.Visible = true;
                        }
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

        public string GetTotal(EquipmentDetailsBO objEquipmentDetailsBO)
        {
            string Total = "0";
            decimal CostofEquipment = 0;
            decimal Equipmentcgst = 0;
            decimal Equipmentsgst = 0;
            decimal EquipmentFreightCharges = 0;
            decimal EquipmentInitiationCharges = 0;

            CostofEquipment = Convert.ToDecimal(objEquipmentDetailsBO.CostofEquipment);
            Equipmentcgst = Convert.ToDecimal(objEquipmentDetailsBO.Equipmentcgst);
            Equipmentsgst = Convert.ToDecimal(objEquipmentDetailsBO.Equipmentsgst);
            EquipmentFreightCharges = Convert.ToDecimal(objEquipmentDetailsBO.EquipmentFreightCharges);
            EquipmentInitiationCharges = Convert.ToDecimal(objEquipmentDetailsBO.EquipmentInitiationCharges);

            return Total = (CostofEquipment + Equipmentcgst + Equipmentsgst + EquipmentFreightCharges + EquipmentInitiationCharges).ToString();
        }

        protected void GvEquipmentDtls_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                // txtNameofDirector.Text = ((Label)(gr.FindControl("lblDirectorName"))).Text;

                txtNameoftheEquipment.Text = ((Label)(gr.FindControl("lblNameoftheEquipment"))).Text;
                txtEquipmentNameAddressofSupplier.Text = ((Label)(gr.FindControl("lblEquipmentNameAddressofSupplier"))).Text;
                txtEquipmentInvoiceNo.Text = ((Label)(gr.FindControl("lblEquipmentInvoiceNo"))).Text;
                txtEquipmentInvoiceDate.Text = ((Label)(gr.FindControl("lblEquipmentInvoiceDate"))).Text;
                txtEquipmentDateOfLanding.Text = ((Label)(gr.FindControl("lblEquipmentDateOfLanding"))).Text;
                txtEquipmentDateOfCommissioning.Text = ((Label)(gr.FindControl("lblEquipmentDateOfCommissioning"))).Text;
                txtEquipmentWayBillNumber.Text = ((Label)(gr.FindControl("lblEquipmentWayBillNumber"))).Text;
                txtEquipmentDateOfWayBill.Text = ((Label)(gr.FindControl("lblEquipmentDateOfWayBill"))).Text;
                txtCostofEquipment.Text = ((Label)(gr.FindControl("lblCostofEquipment"))).Text;
                txtEquipmentcgst.Text = ((Label)(gr.FindControl("lblEquipmentcgst"))).Text;
                txtEquipmentsgst.Text = ((Label)(gr.FindControl("lblEquipmentsgst"))).Text;
                txtEquipmentFreightCharges.Text = ((Label)(gr.FindControl("lblEquipmentFreightCharges"))).Text;
                txtEquipmentInitiationCharges.Text = ((Label)(gr.FindControl("lblEquipmentInitiationCharges"))).Text;
                ddlTypeofEquipment.SelectedValue = ((Label)(gr.FindControl("lblTypeofEquipmentId"))).Text;

                ViewState["Equipment_ID"] = ((Label)(gr.FindControl("lblEquipment_ID"))).Text;
                btnEquipmentDtls.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                EquipmentDetailsBO objEquipmentDetailsBO = new EquipmentDetailsBO();

                objEquipmentDetailsBO.Equipment_ID = ((Label)(gr.FindControl("lblEquipment_ID"))).Text;
                objEquipmentDetailsBO.TransType = "DLT";
                objEquipmentDetailsBO.IncentiveId = Session["IncentiveID"].ToString();
                objEquipmentDetailsBO.Created_by = ObjLoginNewvo.uid;

                string Validstatus = ObjCAFClass.InsertCapitalAssistanceEquipmentDetails(objEquipmentDetailsBO);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnEquipmentDtls.Text = "Add New";
                    ViewState["Equipment_ID"] = "0";

                    txtNameoftheEquipment.Text = "";
                    txtEquipmentNameAddressofSupplier.Text = "";
                    txtEquipmentInvoiceNo.Text = "";
                    txtEquipmentInvoiceDate.Text = "";
                    txtEquipmentDateOfLanding.Text = "";
                    txtEquipmentDateOfCommissioning.Text = "";
                    txtEquipmentWayBillNumber.Text = "";
                    txtEquipmentDateOfWayBill.Text = "";
                    txtCostofEquipment.Text = "";
                    txtEquipmentcgst.Text = "";
                    txtEquipmentsgst.Text = "";
                    txtEquipmentFreightCharges.Text = "";
                    txtEquipmentInitiationCharges.Text = "";

                    BindEquipmentDtls(Session["IncentiveID"].ToString());
                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
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

        protected void txtCostofEquipment_TextChanged(object sender, EventArgs e)
        {
            decimal Cost = 0, CGST=0, SGST=0, Freight=0, Initiation=0, Total=0;
            if (txtCostofEquipment.Text != "")
            {
                Cost = Convert.ToDecimal(txtCostofEquipment.Text.ToString());
            }
            if (txtEquipmentcgst.Text != "")
            {
                CGST = Convert.ToDecimal(txtEquipmentcgst.Text.ToString());
            }
            if (txtEquipmentsgst.Text != "")
            {
                SGST = Convert.ToDecimal(txtEquipmentsgst.Text.ToString());
            }
            if (txtEquipmentFreightCharges.Text != "")
            {
                Freight = Convert.ToDecimal(txtEquipmentFreightCharges.Text.ToString());
            }
            if (txtEquipmentInitiationCharges.Text != "")
            {
                Initiation = Convert.ToDecimal(txtEquipmentInitiationCharges.Text.ToString());
            }
            Total = Cost + CGST + SGST + Freight + Initiation;
            txttotal.Text = Total.ToString();
            return;
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
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuCharteredEngineerCertificate, HyCharteredEngineerCertificate, "FromIIICharteredEngineerCertificate", Session["IncentiveID"].ToString(), "2", "21009", Session["uid"].ToString(), "USER");
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

        protected void btnProjectCertificate_Click(object sender, EventArgs e)
        {
            if (fuProjectCertificate.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuProjectCertificate);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuProjectCertificate);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuProjectCertificate, HyProjectCertificate, "FromIIIProjectCertificate", Session["IncentiveID"].ToString(), "2", "21010", Session["uid"].ToString(), "USER");
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

        protected void GvEquipmentDtls_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {   
                string Category = DataBinder.Eval(e.Row.DataItem, "Category").ToString();
                if (Category == "1")
                {
                    decimal Cat1_1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total"));
                    Cat1 = Cat1_1 + Cat1;
                    e.Row.Style.Add("background-color", "darkseagreen");
                }
                if (Category == "2")
                {
                    decimal Cat2_1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total"));
                    Cat2 = Cat2_1 + Cat2;
                    e.Row.Style.Add("background-color", "gainsboro");
                }
                if (Category == "3")
                {
                    decimal Cat3_1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total"));
                    Cat3 = Cat3_1 + Cat3;
                    e.Row.Style.Add("background-color", "darkkhaki");
                }
                if (Category == "4")
                {
                    decimal Cat4_1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Total"));
                    Cat4 = Cat4_1 + Cat4;
                    e.Row.Style.Add("background-color", "darkgrey");
                }
            }
            txtEnergyEquipment.Text = Cat1.ToString();
            txtWaterEquipment.Text = Cat2.ToString();
            txtEnvironmentalEquipment.Text = Cat3.ToString();
            txtEffluentTreatment.Text = Cat4.ToString();
        }
    }
}