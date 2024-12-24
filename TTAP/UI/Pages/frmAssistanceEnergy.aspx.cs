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
    public partial class frmAssistanceEnergy : System.Web.UI.Page
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
                        //Session["IncentiveID"] = "123";
                        if (Session["uid"] != null)
                        {
                            // GetAssistanceEnergyDetails(Session["uid"].ToString(), Session["IncentiveID"].ToString());
                            if (Session["incentivedata"] != null)
                            {
                                string userid = Session["uid"].ToString();
                                string IncentveID = Session["IncentiveID"].ToString();
                                DataSet ds = new DataSet();
                                ds = (DataSet)Session["incentivedata"];
                                DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 7);
                                if (drs.Length > 0)
                                {
                                    DataSet dsnew = new DataSet();
                                    GetAssistanceEnergyDetails(userid, IncentveID);
                                    //dsnew = Gen.GetIncentivesISdata(IncentveID, "6");
                                    //Filldata(dsnew);
                                }
                                else
                                {
                                    if (Request.QueryString[0].ToString() == "N")
                                    {
                                        Response.Redirect("frmAssistanceAcquisition.aspx?next=" + "N");
                                    }
                                    else
                                    {
                                        Response.Redirect("frmConcessionSGST.aspx?Previous=" + "P");
                                    }
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
        public void GetAssistanceEnergyDetails(string uid, string IncentiveID)
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

                    txtDateofEstablishmentofUnit.Text = dsnew.Tables[0].Rows[0]["DateOfIncorporation"].ToString();
                    if (txtDateofEstablishmentofUnit.Text != "")
                    {
                        txtDateofEstablishmentofUnit.Enabled = false;
                        txtDateofEstablishmentofUnit.ReadOnly = true;
                    }

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
                            //grdPandM.Columns[19].Visible = false;
                            //grdPandM.Columns[18].Visible = false;

                            btnSaleInvoice.Enabled = false;
                            btnCostIncurred.Enabled = false;
                            btnAcrreditationDetails.Enabled = false;
                            btnImplementationEnergy.Enabled = false;
                            btnLoanSanction.Enabled = false;
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
                ds = Gen.GenericFillDs("USP_GET_AssistanceEnergyExistingUnits", p);
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.ToString() != "" && ds.Tables[0].Rows.ToString() != null)
                {
                    // rblApplicationType.SelectedValue = ds.Tables[0].Rows[0]["NatureofExpenses"].ToString();

                    txtDateofEstablishmentofUnit.Text = ds.Tables[0].Rows[0]["DateofEstablishmentofUnit"].ToString();
                    RbtnCommercialProduction.SelectedValue = ds.Tables[0].Rows[0]["CommercialProduction"].ToString();


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

                    TypeofInfrastructure = ds.Tables[0].Rows[0]["AssistanceRequired"].ToString();
                    if (TypeofInfrastructure != "")
                    {
                        string[] TypeofInfrastructureVal = TypeofInfrastructure.Split(',');

                        foreach (string Value in TypeofInfrastructureVal)
                        {
                            int Index = chkAssistanceRequired.Items.IndexOf(chkAssistanceRequired.Items.FindByValue(Value));
                            chkAssistanceRequired.Items[Index].Selected = true;
                        }
                    }

                    chkAssistanceRequired_SelectedIndexChanged(this, EventArgs.Empty);

                    //if (divEnergyAuditConducted.Visible)
                    //{
                    txtEnergyAuditDateofAudit.Text = ds.Tables[0].Rows[0]["EnergyAuditDateofAudit"].ToString();
                    txtEnergyAuditNameofAuditorAuditFirm.Text = ds.Tables[0].Rows[0]["EnergyAuditNameofAuditorAuditFirm"].ToString();
                    txtEnergyAuditCostIncurred.Text = ds.Tables[0].Rows[0]["EnergyAuditCostIncurred"].ToString();
                    txtEnergyAuditInvoiceNumber.Text = ds.Tables[0].Rows[0]["EnergyAuditInvoiceNumber"].ToString();
                    txtEnergyAuditDateofInvoice.Text = ds.Tables[0].Rows[0]["EnergyAuditDateofInvoice"].ToString();
                    //}
                    //if (divWaterAuditConducted.Visible)
                    //{
                    txtWaterDateofAudit.Text = ds.Tables[0].Rows[0]["WaterDateofAudit"].ToString();
                    txtWaterNameofAuditorAuditFirm.Text = ds.Tables[0].Rows[0]["WaterNameofAuditorAuditFirm"].ToString();
                    txtWaterCostIncurred.Text = ds.Tables[0].Rows[0]["WaterCostIncurred"].ToString();
                    txtWaterInvoiceNumber.Text = ds.Tables[0].Rows[0]["WaterInvoiceNumber"].ToString();
                    txtWaterDateofInvoice.Text = ds.Tables[0].Rows[0]["WaterDateofInvoice"].ToString();
                    //}
                    //if (divEnvironmentalCompliance.Visible)
                    //{
                    txtEnvironmentalComplianceDateofAudit.Text = ds.Tables[0].Rows[0]["EnvironmentalComplianceDateofAudit"].ToString();
                    txtNameofCompliance.Text = ds.Tables[0].Rows[0]["NameofCompliance"].ToString();
                    txtCertifyingAgency.Text = ds.Tables[0].Rows[0]["CertifyingAgency"].ToString();
                    txtEnvironmentalComplianceCostIncurred.Text = ds.Tables[0].Rows[0]["EnvironmentalComplianceCostIncurred"].ToString();
                    txtEnvironmentalComplianceInvoiceNumber.Text = ds.Tables[0].Rows[0]["EnvironmentalComplianceInvoiceNumber"].ToString();
                    txtEnvironmentalComplianceDateofInvoice.Text = ds.Tables[0].Rows[0]["EnvironmentalComplianceDateofInvoice"].ToString();
                    //}

                    txtDateofLastClaim.Text = ds.Tables[0].Rows[0]["DateofLastClaim"].ToString();


                    TypeofInfrastructure = ds.Tables[0].Rows[0]["NatureofExpenses"].ToString();
                    if (TypeofInfrastructure != "")
                    {
                        string[] TypeofInfrastructureVal = TypeofInfrastructure.Split(',');

                        foreach (string Value in TypeofInfrastructureVal)
                        {
                            int Index = chkNatureofExpenses.Items.IndexOf(chkNatureofExpenses.Items.FindByValue(Value));
                            chkNatureofExpenses.Items[Index].Selected = true;
                        }
                    }

                    txtClaimAmount.Text = ds.Tables[0].Rows[0]["ClaimAmount"].ToString();
                    txtReimbursementReceived.Text = ds.Tables[0].Rows[0]["ReimbursementReceived"].ToString();
                    txtGovernmentAmountAvailed.Text = ds.Tables[0].Rows[0]["GovernmentAmountAvailed"].ToString();
                    txtGovernmentDateAvailed.Text = ds.Tables[0].Rows[0]["GovernmentDateAvailed"].ToString();
                    txtCurrentClaimEnergyAudit.Text = ds.Tables[0].Rows[0]["CurrentClaimEnergyAudit"].ToString();
                    txtCurrentClaimWaterAudit.Text = ds.Tables[0].Rows[0]["CurrentClaimWaterAudit"].ToString();
                    txtCurrentClaimEnvironmentalCompliance.Text = ds.Tables[0].Rows[0]["CurrentClaimEnvironmentalCompliance"].ToString();
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
                                if (Docid == "71001")
                                {
                                    objClsFileUpload.AssignPath(hysaleInvoice, Path);
                                }
                                else if (Docid == "71002")
                                {
                                    objClsFileUpload.AssignPath(hyCostincurred, Path);
                                }
                                else if (Docid == "71003")
                                {
                                    objClsFileUpload.AssignPath(hyAcrreditationDetails, Path);
                                }
                                else if (Docid == "71004")
                                {
                                    objClsFileUpload.AssignPath(hyImplementationEnergy, Path);
                                }
                                else if (Docid == "71005")
                                {
                                    objClsFileUpload.AssignPath(hyLoanSanction, Path);
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

            if (txtDateofEstablishmentofUnit.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Date Of Incorporation of Unit  \\n";
                slno = slno + 1;
            }

            int selectedCount = chkTypeofInfrastructure.Items.Cast<ListItem>().Count(li => li.Selected);
            if (selectedCount == 0)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select at Least One Type of Infrastructure Installed \\n";
                slno = slno + 1;
            }

            int selectedCount1 = chkAssistanceRequired.Items.Cast<ListItem>().Count(li => li.Selected);
            if (selectedCount1 == 0)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select at Least One Assistance Required For \\n";
                slno = slno + 1;
            }
            if (divEnergyAuditConducted.Visible)
            {
                if (txtEnergyAuditDateofAudit.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Date of Audit Under Energy Audit Conducted \\n";
                    slno = slno + 1;
                }
                if (txtEnergyAuditNameofAuditorAuditFirm.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Name of Auditor / Audit Firm Under Energy Audit Conducted \\n";
                    slno = slno + 1;
                }
                if (txtEnergyAuditCostIncurred.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Cost Incurred (In Rupees) Under Energy Audit Conducted\\n";
                    slno = slno + 1;
                }

                if (txtEnergyAuditInvoiceNumber.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Invoice Number Under Energy Audit Conducted \\n";
                    slno = slno + 1;
                }
                if (txtEnergyAuditDateofInvoice.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Date of Invoice Under Energy Audit Conducted\\n";
                    slno = slno + 1;
                }
            }
            if (divWaterAuditConducted.Visible)
            {
                if (txtWaterDateofAudit.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Date of Audit Under Water Audit Conducted \\n";
                    slno = slno + 1;
                }
                if (txtWaterNameofAuditorAuditFirm.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Name of Auditor / Audit Firm Under Water Audit Conducted \\n";
                    slno = slno + 1;
                }
                if (txtWaterCostIncurred.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Cost Incurred (In Rupees) Under Water Audit Conducted\\n";
                    slno = slno + 1;
                }

                if (txtWaterInvoiceNumber.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Invoice Number Under Water Audit Conducted \\n";
                    slno = slno + 1;
                }
                if (txtWaterDateofInvoice.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Date of Invoice Under Water Audit Conducted\\n";
                    slno = slno + 1;
                }
            }
            if (divEnvironmentalCompliance.Visible)
            {
                if (txtEnvironmentalComplianceDateofAudit.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Date of Receipt of Compliance Under Environmental Compliance \\n";
                    slno = slno + 1;
                }
                if (txtNameofCompliance.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Name of Compliance Under Environmental Compliance \\n";
                    slno = slno + 1;
                }
                if (txtCertifyingAgency.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Certifying Agency Under Environmental Compliance \\n";
                    slno = slno + 1;
                }
                if (txtEnvironmentalComplianceCostIncurred.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please EnterCost Incurred (In Rupees) Under Environmental Compliance \\n";
                    slno = slno + 1;
                }

                if (txtEnvironmentalComplianceInvoiceNumber.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Invoice Number Under Environmental Compliance \\n";
                    slno = slno + 1;
                }
                if (txtEnvironmentalComplianceDateofInvoice.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Date of Invoice Under Environmental Compliance \\n";
                    slno = slno + 1;
                }
            }

            //if (txtDateofLastClaim.Text.TrimStart().Trim() == "")
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Select Date of Receipt of Compliance\\n";
            //    slno = slno + 1;
            //}
            //int selectedCount2 = chkNatureofExpenses.Items.Cast<ListItem>().Count(li => li.Selected);
            //if (selectedCount2 == 0)
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Select at Least One Nature of Expense \\n";
            //    slno = slno + 1;
            //}

            //if (txtClaimAmount.Text.TrimStart().Trim() == "")
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Select Date of Invoice Under Environmental Compliance \\n";
            //    slno = slno + 1;
            //}
            if (txtCurrentClaimEnergyAudit.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Current Claim for Energy Audit  (In Rupees) \\n";
                slno = slno + 1;
            }
            if (txtCurrentClaimWaterAudit.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Current Claim for Water Audit  (In Rupees) \\n";
                slno = slno + 1;
            }
            if (txtCurrentClaimEnvironmentalCompliance.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Current Claim for Environmental Compliance  (In Rupees) \\n";
                slno = slno + 1;
            }

            return ErrorMsg;
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
            string errormsg = GeneralInformationcheck();

            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            else
            {

                string errormsgAttach = ObjCAFClass.ValidateMandatoryAttachments(Session["IncentiveID"].ToString(), "7");
                if (errormsgAttach.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsgAttach + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                AssistanceEnergy objAssistanceEnergy = new AssistanceEnergy();

                objAssistanceEnergy.IncentiveId = Session["IncentiveID"].ToString();
                objAssistanceEnergy.CreatedBy = ObjLoginNewvo.uid;

                objAssistanceEnergy.DateofEstablishmentofUnit = GetFromatedDateDDMMYYYY(txtDateofEstablishmentofUnit.Text.Trim().TrimStart());

                objAssistanceEnergy.CommercialProduction = RbtnCommercialProduction.SelectedValue;

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
                objAssistanceEnergy.TypeofInfrastructure = Typeofinfra;

                Typeofinfra = "";
                foreach (ListItem li in chkAssistanceRequired.Items)
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
                objAssistanceEnergy.AssistanceRequired = Typeofinfra;
                if (divEnergyAuditConducted.Visible)
                {
                    objAssistanceEnergy.EnergyAuditDateofAudit = GetFromatedDateDDMMYYYY(txtEnergyAuditDateofAudit.Text.Trim().TrimStart());
                    objAssistanceEnergy.EnergyAuditNameofAuditorAuditFirm = txtEnergyAuditNameofAuditorAuditFirm.Text.Trim().TrimStart();
                    objAssistanceEnergy.EnergyAuditCostIncurred = GetDecimalNullValue(txtEnergyAuditCostIncurred.Text.Trim().TrimStart());
                    objAssistanceEnergy.EnergyAuditInvoiceNumber = txtEnergyAuditInvoiceNumber.Text.Trim().TrimStart();
                    objAssistanceEnergy.EnergyAuditDateofInvoice = GetFromatedDateDDMMYYYY(txtEnergyAuditDateofInvoice.Text.Trim().TrimStart());
                }
                if (divWaterAuditConducted.Visible)
                {
                    objAssistanceEnergy.WaterDateofAudit = GetFromatedDateDDMMYYYY(txtWaterDateofAudit.Text.Trim().TrimStart());
                    objAssistanceEnergy.WaterNameofAuditorAuditFirm = txtWaterNameofAuditorAuditFirm.Text.Trim().TrimStart();
                    objAssistanceEnergy.WaterCostIncurred = GetDecimalNullValue(txtWaterCostIncurred.Text.Trim().TrimStart());
                    objAssistanceEnergy.WaterInvoiceNumber = txtWaterInvoiceNumber.Text.Trim().TrimStart();
                    objAssistanceEnergy.WaterDateofInvoice = GetFromatedDateDDMMYYYY(txtWaterDateofInvoice.Text.Trim().TrimStart());
                }
                if (divEnvironmentalCompliance.Visible)
                {
                    objAssistanceEnergy.EnvironmentalComplianceDateofAudit = GetFromatedDateDDMMYYYY(txtEnvironmentalComplianceDateofAudit.Text.Trim().TrimStart());
                    objAssistanceEnergy.NameofCompliance = txtNameofCompliance.Text.Trim().TrimStart();
                    objAssistanceEnergy.CertifyingAgency = txtCertifyingAgency.Text.Trim().TrimStart();
                    objAssistanceEnergy.EnvironmentalComplianceCostIncurred = GetDecimalNullValue(txtEnvironmentalComplianceCostIncurred.Text.Trim().TrimStart());
                    objAssistanceEnergy.EnvironmentalComplianceInvoiceNumber = txtEnvironmentalComplianceInvoiceNumber.Text.Trim().TrimStart();
                    objAssistanceEnergy.EnvironmentalComplianceDateofInvoice = GetFromatedDateDDMMYYYY(txtEnvironmentalComplianceDateofInvoice.Text.Trim().TrimStart());
                }


                objAssistanceEnergy.DateofLastClaim = GetFromatedDateDDMMYYYY(txtDateofLastClaim.Text.Trim().TrimStart());
                Typeofinfra = "";
                foreach (ListItem li in chkNatureofExpenses.Items)
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
                objAssistanceEnergy.NatureofExpenses = Typeofinfra;
                objAssistanceEnergy.ClaimAmount = GetDecimalNullValue(txtClaimAmount.Text.Trim().TrimStart());
                objAssistanceEnergy.ReimbursementReceived = GetDecimalNullValue(txtReimbursementReceived.Text.Trim().TrimStart());
                objAssistanceEnergy.GovernmentAmountAvailed = GetDecimalNullValue(txtGovernmentAmountAvailed.Text.Trim().TrimStart());
                objAssistanceEnergy.GovernmentDateAvailed = GetFromatedDateDDMMYYYY(txtGovernmentDateAvailed.Text.Trim().TrimStart());
                objAssistanceEnergy.CurrentClaimEnergyAudit = GetDecimalNullValue(txtCurrentClaimEnergyAudit.Text.Trim().TrimStart());
                objAssistanceEnergy.CurrentClaimWaterAudit = GetDecimalNullValue(txtCurrentClaimWaterAudit.Text.Trim().TrimStart());
                objAssistanceEnergy.CurrentClaimEnvironmentalCompliance = GetDecimalNullValue(txtCurrentClaimEnvironmentalCompliance.Text.Trim().TrimStart());


                string Validstatus = ObjCAFClass.InsertingOfAssistanceforEnergyDtls(objAssistanceEnergy);

                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    Response.Redirect("frmAssistanceAcquisition.aspx?next=" + "N");
                }
            }

        }

        protected void btnclear_Click(object sender, EventArgs e)
        {

        }

        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmConcessionSGST.aspx?Previous=" + "P");
        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        protected void btnAcrreditationDetails_Click(object sender, EventArgs e)
        {
            if (fuAcrreditationDetails.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuAcrreditationDetails);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuAcrreditationDetails);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuAcrreditationDetails, hyAcrreditationDetails, "AccreditationEnergyWaterAuditorwithDetails", Session["IncentiveID"].ToString(), "7", "71003", Session["uid"].ToString(), "USER");

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

        protected void btnImplementationEnergy_Click(object sender, EventArgs e)
        {

            if (fuImplementationEnergy.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuImplementationEnergy);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuImplementationEnergy);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuImplementationEnergy, hyImplementationEnergy, "DocumentEnergyWaterEnvironmentalAudit", Session["IncentiveID"].ToString(), "7", "71004", Session["uid"].ToString(), "USER");

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

        protected void btnLoanSanction_Click(object sender, EventArgs e)
        {

            if (fuLoanSanction.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuLoanSanction);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuLoanSanction);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLoanSanction, hyLoanSanction, "LoansanctionorderconductingAuditBank", Session["IncentiveID"].ToString(), "7", "71005", Session["uid"].ToString(), "USER");

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

        protected void btnCostIncurred_Click(object sender, EventArgs e)
        {

            if (fuCostincurred.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuCostincurred);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuCostincurred);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuCostincurred, hyCostincurred, "CostEnergyWaterAuditEnvironmental", Session["IncentiveID"].ToString(), "7", "71002", Session["uid"].ToString(), "USER");

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

        protected void btnSaleInvoice_Click(object sender, EventArgs e)
        {
            if (fuSaleInvoice.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuSaleInvoice);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuSaleInvoice);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuSaleInvoice, hysaleInvoice, "FirstSaleInvoice", Session["IncentiveID"].ToString(), "7", "71001", Session["uid"].ToString(), "USER");

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

        protected void chkAssistanceRequired_SelectedIndexChanged(object sender, EventArgs e)
        {
            divEnergyAuditConducted.Visible = false;
            divWaterAuditConducted.Visible = false;
            divEnvironmentalCompliance.Visible = false;
            foreach (ListItem li in chkAssistanceRequired.Items)
            {
                if (li.Selected)
                {
                    if (li.Value == "1")
                    {
                        divEnergyAuditConducted.Visible = true;
                    }
                    if (li.Value == "2")
                    {
                        divWaterAuditConducted.Visible = true;
                    }
                    if (li.Value == "3")
                    {
                        divEnvironmentalCompliance.Visible = true;
                    }
                }
            }
        }
    }

}
