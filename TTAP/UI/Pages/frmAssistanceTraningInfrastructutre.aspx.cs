using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class frmAssistanceTraningInfrastructutre : System.Web.UI.Page
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
                            DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 17);
                            if (drs.Length > 0)
                            {
                                DataSet dsnew = new DataSet();
                                GetTrainingInfrastructure(userid, IncentveID);
                                BindTraineeDtls(Session["IncentiveID"].ToString());
                            }
                            else
                            {
                                if (Request.QueryString[0].ToString() == "N")
                                {
                                    Response.Redirect("frmMigrantIncentives.aspx?next=" + "N");
                                }
                                else
                                {
                                    Response.Redirect("frmTraningSubsidy.aspx?Previous=" + "P");
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
        public void GetTrainingInfrastructure(string uid, string incentiveid)
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
                        if (Convert.ToInt32(applicationStatus) >= 2 || ENABLINGCONTRILS == "Y")
                        {
                            EnableDisableForm(Page.Controls, false);

                            btnUpload1.Enabled = false;
                            Button1.Enabled = false;
                            btnCharteredEngineer.Enabled = false;

                            DivTraineeDetails.Visible = false;
                            GvTraineeDtls.Columns[7].Visible = false;
                            GvTraineeDtls.Columns[6].Visible = false;
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

                ds = Gen.GenericFillDs("USP_GET_Training_Infrastructure_Apparel_Design_Development", p);


                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.ToString() != "" && ds.Tables[0].Rows.ToString() != null)
                {

                    txtNameofTrainingCentre.Text = ds.Tables[0].Rows[0]["NameofTrainingCentre"].ToString();
                    txtEmpanelledDHT.Text = ds.Tables[0].Rows[0]["EmpanelledDHT"].ToString();
                    txtLocationofTrainingCentre.Text = ds.Tables[0].Rows[0]["LocationofTrainingCentre"].ToString();
                    txtCoursesoffered.Text = ds.Tables[0].Rows[0]["Coursesoffered"].ToString();
                    txtBuilding.Text = ds.Tables[0].Rows[0]["Building"].ToString();
                    txtPlantMachinery.Text = ds.Tables[0].Rows[0]["PlantMachinery"].ToString();
                    txtInstallationCharges.Text = ds.Tables[0].Rows[0]["InstallationCharges"].ToString();
                    txtElectrification.Text = ds.Tables[0].Rows[0]["Electrification"].ToString();
                    txtTrainingAids.Text = ds.Tables[0].Rows[0]["TrainingAids"].ToString();
                    txtFurniture.Text = ds.Tables[0].Rows[0]["Furniture"].ToString();
                    lblTotalInvestment.InnerHtml = GetTotalInv();
                    txtCurrentClaim.Text = ds.Tables[0].Rows[0]["CurrentClaim"].ToString();
                    if (ds.Tables[0].Rows[0]["TypeofTrainingCentre"].ToString() != "")
                    {
                        ddlTypeofTrainingCentre.SelectedValue = ds.Tables[0].Rows[0]["TypeofTrainingCentre"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["TrainingCentrePurpose"].ToString() != "")
                    {
                        ddlPurpose.SelectedValue = ds.Tables[0].Rows[0]["TrainingCentrePurpose"].ToString();
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
                                if (Docid == "171001")
                                {
                                    objClsFileUpload.AssignPath(HyperLink2, Path);
                                }
                                else if (Docid == "171002")
                                {
                                    objClsFileUpload.AssignPath(lblUpload1, Path);
                                }
                                else if (Docid == "171003")
                                {
                                    objClsFileUpload.AssignPath(hyCharteredEngineer, Path);
                                }
                                else if (Docid == "171004")
                                {
                                    objClsFileUpload.AssignPath(hyRegistrationTrainingInstitute, Path);
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

            if (txtNameofTrainingCentre.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Name of Training Centre \\n";
                slno = slno + 1;
            }
            if (ddlTypeofTrainingCentre.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Type of Training Centre \\n";
                slno = slno + 1;
            }
            if (ddlPurpose.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Training Centre Purpose\\n";
                slno = slno + 1;
            }

            if (txtEmpanelledDHT.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Empanelled DH&T \\n";
                slno = slno + 1;
            }
            if (txtLocationofTrainingCentre.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Location of Training Centre \\n";
                slno = slno + 1;
            }
            if (txtCoursesoffered.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Courses Offered in the Training Centre \\n";
                slno = slno + 1;
            }

            if (txtCurrentClaim.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter the Current Claim  Amount (In Rupees) \\n";
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
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), flUploadCACertificate, HyperLink2, "CACertificateinvestmentsTrainingInfrastructure", Session["IncentiveID"].ToString(), "17", "171001", Session["uid"].ToString(), "USER");

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
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuDocuments1, lblUpload1, "CredentialsInstitutesettingInfrastructureApparelDesignandDevelopment", Session["IncentiveID"].ToString(), "17", "171002", Session["uid"].ToString(), "USER");

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

                    string errormsgAttach = ObjCAFClass.ValidateMandatoryAttachments(Session["IncentiveID"].ToString(), "17");
                    if (errormsgAttach.Trim().TrimStart() != "")
                    {
                        string message = "alert('" + errormsgAttach + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }

                    TraningInfrastructure ObjTraning = new TraningInfrastructure();

                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    ObjTraning.IncentiveId = Session["IncentiveID"].ToString();
                    ObjTraning.CreatedBy = ObjLoginNewvo.uid;

                    ObjTraning.NameofTrainingCentre = txtNameofTrainingCentre.Text.Trim().TrimStart();
                    ObjTraning.EmpanelledDHT = txtEmpanelledDHT.Text.Trim().TrimStart();
                    ObjTraning.LocationofTrainingCentre = txtLocationofTrainingCentre.Text.Trim().TrimStart();
                    ObjTraning.Coursesoffered = txtCoursesoffered.Text.Trim().TrimStart();
                    ObjTraning.Building = GetDecimalNullValue(txtBuilding.Text.Trim().TrimStart());
                    ObjTraning.PlantMachinery = GetDecimalNullValue(txtPlantMachinery.Text.Trim().TrimStart());
                    ObjTraning.InstallationCharges = GetDecimalNullValue(txtInstallationCharges.Text.Trim().TrimStart());
                    ObjTraning.Electrification = GetDecimalNullValue(txtElectrification.Text.Trim().TrimStart());
                    ObjTraning.TrainingAids = GetDecimalNullValue(txtTrainingAids.Text.Trim().TrimStart());
                    ObjTraning.Furniture = GetDecimalNullValue(txtFurniture.Text.Trim().TrimStart());
                    ObjTraning.TotalInvestment = GetTotalInv();
                    ObjTraning.CurrentClaim = GetDecimalNullValue(txtCurrentClaim.Text.Trim().TrimStart());
                    ObjTraning.TrainingCentrePurpose = ddlPurpose.SelectedValue;

                    ObjTraning.TypeofTrainingCentre = ddlTypeofTrainingCentre.SelectedValue;

                    string Validstatus = ObjCAFClass.InsertingOfTrainingInfrastructureApparelDesignDevelopmentDtls(ObjTraning);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        Response.Redirect("frmMigrantIncentives.aspx?next=" + "N");
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
            Response.Redirect("frmTraningSubsidy.aspx?Previous=" + "P");
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
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuCharteredEngineer, hyCharteredEngineer, "CertificateCharteredEngineer", Session["IncentiveID"].ToString(), "17", "171003", Session["uid"].ToString(), "USER");

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
                Convert.ToDouble(GetDecimalNullValue(txtTrainingAids.Text.Trim().TrimStart())) +
                Convert.ToDouble(GetDecimalNullValue(txtFurniture.Text.Trim().TrimStart()));

            return Total.ToString();

        }

        protected void txtBuilding_TextChanged(object sender, EventArgs e)
        {
            lblTotalInvestment.InnerHtml = GetTotalInv();
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

        protected void btnRegistrationTrainingInstitute_Click(object sender, EventArgs e)
        {
            if (fuRegistrationTrainingInstitute.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuRegistrationTrainingInstitute);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuRegistrationTrainingInstitute);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuRegistrationTrainingInstitute, hyRegistrationTrainingInstitute, "RegistrationTrainingInstitute", Session["IncentiveID"].ToString(), "17", "171004", Session["uid"].ToString(), "USER");

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