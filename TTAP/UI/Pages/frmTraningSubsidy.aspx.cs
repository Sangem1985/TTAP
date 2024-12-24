using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class frmTraningSubsidy : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        General Gen = new General();
        BusinessLogic.DML objDml = new BusinessLogic.DML();

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
                            DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 16);
                            if (drs.Length > 0)
                            {
                                DataSet dsnew = new DataSet();
                                GetTrainingSubsidyDetails(userid, IncentveID);
                                BindTraineeDtls(IncentveID.ToString());
                                //dsnew = Gen.GetIncentivesISdata(IncentveID, "6");
                                //Filldata(dsnew);
                            }
                            else
                            {
                                if (Request.QueryString[0].ToString() == "N")
                                {
                                    Response.Redirect("frmAssistanceTraningInfrastructutre.aspx?next=" + "N");
                                }
                                else
                                {
                                    Response.Redirect("frmassistancedevelopment.aspx?Previous=" + "P");
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
        public void GetTrainingSubsidyDetails(string uid, string incentiveid)
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

                            btnUpload1.Enabled = false;
                            Button1.Enabled = false;
                            btnemployeesEPFESIremittances.Enabled = false;
                            btnCharteredAccountantCertificatetraining.Enabled = false;

                            DivTraineeDetails.Visible = false;
                            GvTraineeDtls.Columns[7].Visible = false;
                            GvTraineeDtls.Columns[6].Visible = false;
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

                ds = Gen.GenericFillDs("USP_GET_Training_Subsidy", p);


                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.ToString() != "" && ds.Tables[0].Rows.ToString() != null)
                {
                    txtNumberofEmployees.Text = ds.Tables[0].Rows[0]["NumberofEmployees"].ToString();
                    txtSkillName.Text = ds.Tables[0].Rows[0]["SkillName"].ToString();
                    txtTrainingInstituteName.Text = ds.Tables[0].Rows[0]["TrainingInstituteName"].ToString();
                    txtNumberofEmployeesTrained.Text = ds.Tables[0].Rows[0]["NumberofEmployeesTrained"].ToString();
                    txtExpenditureIncurredTraining.Text = ds.Tables[0].Rows[0]["ExpenditureIncurredTraining"].ToString();
                    txtMonthsEmployment.Text = ds.Tables[0].Rows[0]["MonthsEmployment"].ToString();
                    txtCurrentClaim.Text = ds.Tables[0].Rows[0]["CurrentClaim"].ToString();

                    txtAmountAvailed.Text = ds.Tables[0].Rows[0]["AmountAvailed"].ToString();
                    txtSanctionOrderNo.Text = ds.Tables[0].Rows[0]["SanctionOrderNo"].ToString();
                    txtDateAvailed.Text = ds.Tables[0].Rows[0]["DateAvailedDDMMYY"].ToString();
                    txtNumberofEmployeesTrainedNonLocal.Text = ds.Tables[0].Rows[0]["NumberofEmployeesTrainedNonLocal"].ToString();

                    txtNumberofEmployeesTrained_TextChanged(this, EventArgs.Empty);
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
                                if (Docid == "161001")
                                {
                                    objClsFileUpload.AssignPath(lblUpload1, Path);
                                }
                                else if (Docid == "161002")
                                {
                                    objClsFileUpload.AssignPath(HyperLink2, Path);
                                }
                                else if (Docid == "161003")
                                {
                                    objClsFileUpload.AssignPath(hyemployeesEPFESIremittances, Path);
                                }
                                else if (Docid == "161004")
                                {
                                    objClsFileUpload.AssignPath(hyCharteredAccountantCertificatetraining, Path);
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


            if (txtNumberofEmployees.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Number of Employees \\n";
                slno = slno + 1;
            }
            if (txtSkillName.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Name of the skill development Programme (new skills or upgradation) \\n";
                slno = slno + 1;
            }
            if (txtTrainingInstituteName.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Name of the training institute & duration (Empanelled by the DH&T department) \\n";
                slno = slno + 1;
            }
            if (txtNumberofEmployeesTrained.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter No of Local employees trained by the establishment \\n";
                slno = slno + 1;
            }
            if (txtNumberofEmployeesTrainedNonLocal.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter No of Non Local employees trained by the establishment \\n";
                slno = slno + 1;
            }

            if (txtExpenditureIncurredTraining.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Expenditure incurred for training Programme per employee (In Rupees) \\n";
                slno = slno + 1;
            }
            if (txtMonthsEmployment.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Months of employment in the Organization\\n";
                slno = slno + 1;
            }

            if (txtCurrentClaim.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Current Claim Amount (In Rupees) \\n";
                slno = slno + 1;
            }
            if (GvTraineeDtls.Rows.Count < 1)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Add Trainee details \\n";
                slno = slno + 1;
            }

            return ErrorMsg;
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
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuDocuments1, lblUpload1, "CertificateInstituteParticipants", Session["IncentiveID"].ToString(), "16", "161001", Session["uid"].ToString(), "USER");
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (fuTrainingprogramdocument.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuTrainingprogramdocument);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuTrainingprogramdocument);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuTrainingprogramdocument, HyperLink2, "IndicatingCostIncurredTrainingprogramme", Session["IncentiveID"].ToString(), "16", "161002", Session["uid"].ToString(), "USER");

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
                    string errormsgAttach = ObjCAFClass.ValidateMandatoryAttachments(Session["IncentiveID"].ToString(), "16");
                    if (errormsgAttach.Trim().TrimStart() != "")
                    {
                        string message = "alert('" + errormsgAttach + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }

                    TrainingSubsidy objsubsidy = new TrainingSubsidy();

                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    objsubsidy.IncentiveId = Session["IncentiveID"].ToString();

                    objsubsidy.NumberofEmployees = GetDecimalNullValue(txtNumberofEmployees.Text.Trim().TrimStart());
                    objsubsidy.SkillName = txtSkillName.Text.Trim().TrimStart();
                    objsubsidy.TrainingInstituteName = txtTrainingInstituteName.Text.Trim().TrimStart();
                    objsubsidy.NumberofEmployeesTrained = GetDecimalNullValue(txtNumberofEmployeesTrained.Text.Trim().TrimStart());
                    objsubsidy.ExpenditureIncurredTraining = GetDecimalNullValue(txtExpenditureIncurredTraining.Text.Trim().TrimStart());
                    objsubsidy.MonthsEmployment = txtMonthsEmployment.Text.Trim().TrimStart();
                    objsubsidy.CurrentClaim = GetDecimalNullValue(txtCurrentClaim.Text.Trim().TrimStart());

                    objsubsidy.AmountAvailed = GetDecimalNullValue(txtAmountAvailed.Text.Trim().TrimStart());
                    objsubsidy.SanctionOrderNo = txtSanctionOrderNo.Text.Trim().TrimStart();
                    objsubsidy.DateAvailed = GetFromatedDateDDMMYYYY(txtDateAvailed.Text.Trim().TrimStart());
                    objsubsidy.NumberofEmployeesTrainedNonLocal = txtNumberofEmployeesTrainedNonLocal.Text.Trim().TrimStart();

                    objsubsidy.CreatedBy = ObjLoginNewvo.uid;
                    string Validstatus = ObjCAFClass.InsertingOfTrainingSubsidyDtls(objsubsidy);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        Response.Redirect("frmAssistanceTraningInfrastructutre.aspx?next=" + "N");
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
        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmassistancedevelopment.aspx?Previous=" + "P");
        }

        protected void btnemployeesEPFESIremittances_Click(object sender, EventArgs e)
        {
            if (fuemployeesEPFESIremittances.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuemployeesEPFESIremittances);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuemployeesEPFESIremittances);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuemployeesEPFESIremittances, hyemployeesEPFESIremittances, "employeesEPFESIremittances", Session["IncentiveID"].ToString(), "16", "161003", Session["uid"].ToString(), "USER");

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

        protected void btnCharteredAccountantCertificatetraining_Click(object sender, EventArgs e)
        {
            if (fuCharteredAccountantCertificatetraining.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuCharteredAccountantCertificatetraining);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuCharteredAccountantCertificatetraining);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuCharteredAccountantCertificatetraining, hyCharteredAccountantCertificatetraining, "CharteredAccountantCertificatetraining", Session["IncentiveID"].ToString(), "16", "161004", Session["uid"].ToString(), "USER");

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

        protected void txtNumberofEmployeesTrained_TextChanged(object sender, EventArgs e)
        {
            txtTotalemployees.Text = (Convert.ToInt32(GetDecimalNullValue(txtNumberofEmployeesTrained.Text)) + Convert.ToInt32(GetDecimalNullValue(txtNumberofEmployeesTrainedNonLocal.Text))).ToString();
        }

        protected void txtNumberofEmployeesTrainedNonLocal_TextChanged(object sender, EventArgs e)
        {
            txtTotalemployees.Text = (Convert.ToInt32(GetDecimalNullValue(txtNumberofEmployeesTrained.Text)) + Convert.ToInt32(GetDecimalNullValue(txtNumberofEmployeesTrainedNonLocal.Text))).ToString();
        }
        public string ValidateTraineeDtls()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (txtNameoftheTrainee.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Eneter Name of the Trainee \\n";
                slno = slno + 1;
            }
            if (ddlTypeofTraining.SelectMethod == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Type of Training \\n";
                slno = slno + 1;
            }
            if (ddlTraineeLocalization.SelectMethod == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Trainee Localization \\n";
                slno = slno + 1;
            }

            if (txtTrainingfromdate.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select From Date of Training \\n";
                slno = slno + 1;
            }
            if (txtTrainingtodate.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select To Date of Training \\n";
                slno = slno + 1;
            }
            if (txtExpenditureIncurred.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Expenditure Incurred for Training \\n";
                slno = slno + 1;
            }


            return ErrorMsg;
        }
        protected void btnaddTraineeDtls_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["Trainee_ID"] == null)
                {
                    ViewState["Trainee_ID"] = "0";
                }

                string errormsg = ValidateTraineeDtls();
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

                    TraineeDetailsBO objTraineeDetailsBO = new TraineeDetailsBO();

                    objTraineeDetailsBO.Trainee_ID = ViewState["Trainee_ID"].ToString();
                    objTraineeDetailsBO.TransType = "INS";
                    objTraineeDetailsBO.IncentiveId = Session["IncentiveID"].ToString();
                    objTraineeDetailsBO.CreatedBy = ObjLoginNewvo.uid;

                    objTraineeDetailsBO.NameoftheTrainee = txtNameoftheTrainee.Text.Trim().TrimStart();

                    objTraineeDetailsBO.TypeofTraining = ddlTypeofTraining.SelectedValue;
                    objTraineeDetailsBO.TraineeLocalization = ddlTraineeLocalization.SelectedValue;

                    objTraineeDetailsBO.TypeofTrainingText = ddlTypeofTraining.SelectedItem.Text;
                    objTraineeDetailsBO.TraineeLocalizationText = ddlTraineeLocalization.SelectedItem.Text;

                    string[] Ld6 = null;
                    string ConvertedDt56 = "";
                    if (txtTrainingfromdate.Text.Trim().TrimStart() != "")
                    {
                        Ld6 = txtTrainingfromdate.Text.Trim().TrimStart().Split('/');
                        ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();
                        objTraineeDetailsBO.Trainingfromdate = ConvertedDt56;
                    }
                    else
                    {
                        objTraineeDetailsBO.Trainingfromdate = null;
                    }

                    Ld6 = null;
                    ConvertedDt56 = "";

                    if (txtTrainingtodate.Text.Trim().TrimStart() != "")
                    {
                        Ld6 = txtTrainingtodate.Text.Trim().TrimStart().Split('/');
                        ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();
                        objTraineeDetailsBO.Trainingtodate = ConvertedDt56;
                    }
                    else
                    {
                        objTraineeDetailsBO.Trainingtodate = null;
                    }

                    objTraineeDetailsBO.ExpenditureIncurred = txtExpenditureIncurred.Text.Trim().TrimStart();


                    string Validstatus = ObjCAFClass.InsertTraineeDetails(objTraineeDetailsBO);
                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        btnaddTraineeDtls.Text = "Add New";
                        ViewState["Trainee_ID"] = "0";

                        txtNameoftheTrainee.Text = "";
                        txtTrainingfromdate.Text = "";
                        txtTrainingtodate.Text = "";
                        txtExpenditureIncurred.Text = "";

                        BindTraineeDtls(Session["IncentiveID"].ToString());
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

        protected void BindTraineeDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetTraineeDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    GvTraineeDtls.DataSource = dsnew.Tables[0];
                    GvTraineeDtls.DataBind();
                    int Local = 0;
                    int NonLocal = 0;
                    string TraineeLocalization = "";
                    foreach (GridViewRow gvrow in GvTraineeDtls.Rows)
                    {
                        TraineeLocalization = "";
                        TraineeLocalization = ((Label)gvrow.FindControl("lblTraineeLocalizationID")).Text;
                        if (TraineeLocalization == "1")
                        {
                            Local = Local + 1;
                        }
                        else
                        {
                            NonLocal = NonLocal + 1;
                        }
                    }

                    txtNumberofEmployeesTrained.Text = Local.ToString();
                    txtNumberofEmployeesTrainedNonLocal.Text = NonLocal.ToString();
                    txtTotalemployees.Text = (Local + NonLocal).ToString();
                }
                else
                {
                    GvTraineeDtls.DataSource = null;
                    GvTraineeDtls.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void GvTraineeDtls_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                // txtNameofDirector.Text = ((Label)(gr.FindControl("lblDirectorName"))).Text;

                txtNameoftheTrainee.Text = ((Label)(gr.FindControl("lblNameoftheTrainee"))).Text;
                txtTrainingfromdate.Text = ((Label)(gr.FindControl("lblPeriodoftrainingFrom"))).Text;
                txtTrainingtodate.Text = ((Label)(gr.FindControl("lblPeriodoftrainingTo"))).Text;
                txtExpenditureIncurred.Text = ((Label)(gr.FindControl("lblExpenditureIncurred"))).Text;

                ddlTypeofTraining.SelectedValue = ((Label)(gr.FindControl("lblTypeofTrainingID"))).Text;
                ddlTraineeLocalization.SelectedValue = ((Label)(gr.FindControl("lblTraineeLocalizationID"))).Text;

                ViewState["Trainee_ID"] = ((Label)(gr.FindControl("lblTrainee_ID"))).Text;
                btnaddTraineeDtls.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                TraineeDetailsBO objTraineeDetailsBO = new TraineeDetailsBO();

                objTraineeDetailsBO.Trainee_ID = ((Label)(gr.FindControl("lblTrainee_ID"))).Text;
                objTraineeDetailsBO.TransType = "DLT";
                objTraineeDetailsBO.IncentiveId = Session["IncentiveID"].ToString();
                objTraineeDetailsBO.CreatedBy = ObjLoginNewvo.uid;

                string Validstatus = ObjCAFClass.InsertTraineeDetails(objTraineeDetailsBO);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnaddTraineeDtls.Text = "Add New";
                    ViewState["Trainee_ID"] = "0";

                    txtNameoftheTrainee.Text = "";
                    txtTrainingfromdate.Text = "";
                    txtTrainingtodate.Text = "";
                    txtExpenditureIncurred.Text = "";

                    BindTraineeDtls(Session["IncentiveID"].ToString());
                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }
        public DataSet GetTraineeDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_Trainee_DTLS", pp);
            return Dsnew;
        }
    }
}