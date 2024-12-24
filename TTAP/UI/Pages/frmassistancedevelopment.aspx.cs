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
    public partial class frmassistancedevelopment : System.Web.UI.Page
    {
        General Gen = new General();

        ClsFileUpload objClsFileUpload = new ClsFileUpload();
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
                            DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 15);
                            if (drs.Length > 0)
                            {
                                DataSet dsnew = new DataSet();
                                GetWorkingHouseDetails(userid, IncentveID);
                                //dsnew = Gen.GetIncentivesISdata(IncentveID, "6");
                                //Filldata(dsnew);
                            }
                            else
                            {
                                if (Request.QueryString[0].ToString() == "N")
                                {
                                    Response.Redirect("frmTraningSubsidy.aspx?next=" + "N");
                                }
                                else
                                {
                                    Response.Redirect("frmRebateCharges.aspx?Previous=" + "P");
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
        public void GetWorkingHouseDetails(string uid, string incentiveid)
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

                    txtDateofEstablishmentofUnit.Text = dsnew.Tables[0].Rows[0]["DateOfIncorporation"].ToString();
                    if (txtDateofEstablishmentofUnit.Text != "")
                    {
                        txtDateofEstablishmentofUnit.Enabled = false;
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

                            btnUpload1.Enabled = false;
                            btnPaymentProof.Enabled = false;
                            btnWorkerHousing.Enabled = false;
                            btnCACertificate.Enabled = false;
                            btnChartedCertificate.Enabled = false;
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

                ds = Gen.GenericFillDs("USP_GET_WorkerHousing_Dormitories", p);
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.ToString() != "" && ds.Tables[0].Rows.ToString() != null)
                {
                    txtDateofEstablishmentofUnit.Text = ds.Tables[0].Rows[0]["DateofEstablishmentofUnit"].ToString();
                    txtWorkerHousingLocation.Text = ds.Tables[0].Rows[0]["WorkerHousingLocation"].ToString();
                    txtLandpurchased.Text = ds.Tables[0].Rows[0]["Landpurchased"].ToString();
                    txtBuildingPlinthArea.Text = ds.Tables[0].Rows[0]["BuildingPlinthArea"].ToString();
                    txtBuildingAreaRequired.Text = ds.Tables[0].Rows[0]["BuildingAreaRequired"].ToString();
                    txtLandInvestment.Text = ds.Tables[0].Rows[0]["LandInvestment"].ToString();
                    txtLandConversionCharges.Text = ds.Tables[0].Rows[0]["LandConversionCharges"].ToString();
                    txtPurchasedLandCost.Text = ds.Tables[0].Rows[0]["PurchasedLandCost"].ToString();
                    txtHousingOccupantsLoad.Text = ds.Tables[0].Rows[0]["HousingOccupantsLoad"].ToString();
                    txtOccupancyRate.Text = ds.Tables[0].Rows[0]["OccupancyRate"].ToString();
                    txtQuartersStartDate.Text = ds.Tables[0].Rows[0]["QuartersStartDate"].ToString();
                    txtQuartersEndDate.Text = ds.Tables[0].Rows[0]["QuartersEndDate"].ToString();
                    txtCurrentClaim.Text = ds.Tables[0].Rows[0]["CurrentClaim"].ToString();

                    RbtnTextileOrApparelArea.Text = ds.Tables[0].Rows[0]["TextileOrApparelArea"].ToString();
                    txtTotallandusedworker.Text = ds.Tables[0].Rows[0]["TotalLandUsedForWorker"].ToString();
                    txtLandpurchasedrateper.Text = ds.Tables[0].Rows[0]["Landpurchasedrateper"].ToString();
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
                                if (Docid == "151001")
                                {
                                    objClsFileUpload.AssignPath(lblSaleDeed, Path);
                                }
                                else if (Docid == "151002")
                                {
                                    objClsFileUpload.AssignPath(hyppaymentProof, Path);
                                }
                                else if (Docid == "151003")
                                {
                                    objClsFileUpload.AssignPath(hypWorkerHousing, Path);
                                }
                                else if (Docid == "151004")
                                {
                                    objClsFileUpload.AssignPath(hypCACertificate, Path);
                                }
                                else if (Docid == "151005")
                                {
                                    objClsFileUpload.AssignPath(hypChartedCertificate, Path);
                                }
                                else if (Docid == "151006")
                                {
                                    objClsFileUpload.AssignPath(hyWorkersDetails, Path);
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
        public string GeneralInformationcheck()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (txtDateofEstablishmentofUnit.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Date Of Incorporation of Unit \\n";
                slno = slno + 1;
            }
            if (txtWorkerHousingLocation.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter the Location of the Worker Housing /Dormitory  \\n";
                slno = slno + 1;
            }
            if (txtLandpurchased.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter the  Land purchased (in Sq. Mtrs.)  \\n";
                slno = slno + 1;
            }
            if (txtBuildingPlinthArea.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Plinth Area of the Building for Worker Housing/Dormitory (in Sq. Mtrs.)  \\n";
                slno = slno + 1;
            }

            if (txtBuildingAreaRequired.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Area required for the Building for Worker Housing/Dormitory as per the appraisal (in Sq. Mtrs.) \\n";
                slno = slno + 1;
            }
            if (txtLandInvestment.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Investment in the land used for ( Worker Housing /Dormitory) (Amount in Rupees) \\n";
                slno = slno + 1;
            }
            if (txtHousingOccupantsLoad.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Total Occupants load for Worker Housing/Dormitory  \\n";
                slno = slno + 1;
            }
            if (txtOccupancyRate.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Occupancy rate in the Worker Housing /Dormitory (%)  \\n";
                slno = slno + 1;
            }

            if (txtQuartersStartDate.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter the Start Date of usage of Workers   \\n";
                slno = slno + 1;
            }
            if (txtQuartersEndDate.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter the end Date of usage of Workers   \\n";
                slno = slno + 1;
            }
            if (RbtnTextileOrApparelArea.SelectedIndex == -1)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Whether the unit is located in the Textile /Apparel Park declared by the Government of Telangana \\n";
                slno = slno + 1;
            }
            if (txtTotallandusedworker.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Total land used for worker housing(in acre) \\n";
                slno = slno + 1;
            }
            if (txtLandpurchasedrateper.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Land purchased rate per acre(In Rs) \\n";
                slno = slno + 1;
            }

            if (txtCurrentClaim.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Current Claim \\n";
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
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuDocuments1, lblSaleDeed, "RegisteredLandSaleDeed", Session["IncentiveID"].ToString(), "15", "151001", Session["uid"].ToString(), "USER");

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

        protected void btnPaymentProof_Click(object sender, EventArgs e)
        {

            if (fuPaymentProof.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuPaymentProof);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuPaymentProof);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuPaymentProof, hyppaymentProof, "Paymentproof", Session["IncentiveID"].ToString(), "15", "151002", Session["uid"].ToString(), "USER");

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

        protected void btnWorkerHousing_Click(object sender, EventArgs e)
        {


            if (fuWorkingHouse.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuWorkingHouse);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuWorkingHouse);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuWorkingHouse, hypWorkerHousing, "CredentialsIndustryEnterpriseinfrastructureWorkerHousing", Session["IncentiveID"].ToString(), "15", "151003", Session["uid"].ToString(), "USER");

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

        protected void btnCACertificate_Click(object sender, EventArgs e)
        {


            if (fuCACertificate.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuCACertificate);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuCACertificate);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuCACertificate, hypCACertificate, "CertificateCAinvestments", Session["IncentiveID"].ToString(), "15", "151004", Session["uid"].ToString(), "USER");

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

        protected void btnChartedCertificate_Click(object sender, EventArgs e)
        {

            if (fuChartedCertificate.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuChartedCertificate);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuChartedCertificate);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuChartedCertificate, hypChartedCertificate, "CertificateCharteredEngineer", Session["IncentiveID"].ToString(), "15", "151005", Session["uid"].ToString(), "USER");

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

                    string errormsgAttach = ObjCAFClass.ValidateMandatoryAttachments(Session["IncentiveID"].ToString(), "15");
                    if (errormsgAttach.Trim().TrimStart() != "")
                    {
                        string message = "alert('" + errormsgAttach + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }

                    WorkerHousing objworker = new WorkerHousing();

                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    objworker.IncentiveId = Session["IncentiveID"].ToString();

                    objworker.DateofEstablishmentofUnit = GetFromatedDateDDMMYYYY(txtDateofEstablishmentofUnit.Text.Trim().TrimStart());
                    objworker.WorkerHousingLocation = txtWorkerHousingLocation.Text.Trim().TrimStart();
                    objworker.Landpurchased = GetDecimalNullValue(txtLandpurchased.Text.Trim().TrimStart());
                    objworker.BuildingPlinthArea = GetDecimalNullValue(txtBuildingPlinthArea.Text.Trim().TrimStart());
                    objworker.BuildingAreaRequired = GetDecimalNullValue(txtBuildingAreaRequired.Text.Trim().TrimStart());
                    objworker.LandInvestment = GetDecimalNullValue(txtLandInvestment.Text.Trim().TrimStart());
                    objworker.LandConversionCharges = GetDecimalNullValue(txtLandConversionCharges.Text.Trim().TrimStart());
                    objworker.PurchasedLandCost = GetDecimalNullValue(txtPurchasedLandCost.Text.Trim().TrimStart());
                    objworker.HousingOccupantsLoad = GetDecimalNullValue(txtHousingOccupantsLoad.Text.Trim().TrimStart());
                    objworker.OccupancyRate = GetDecimalNullValue(txtOccupancyRate.Text.Trim().TrimStart());
                    objworker.QuartersStartDate = GetFromatedDateDDMMYYYY(txtQuartersStartDate.Text.Trim().TrimStart());
                    objworker.QuartersEndDate = GetFromatedDateDDMMYYYY(txtQuartersEndDate.Text.Trim().TrimStart());
                    objworker.CurrentClaim = GetDecimalNullValue(txtCurrentClaim.Text.Trim().TrimStart());


                    objworker.TextileOrApparelArea = RbtnTextileOrApparelArea.SelectedValue;
                    objworker.TotalLandUsedForWorker = GetDecimalNullValue(txtTotallandusedworker.Text.Trim().TrimStart());
                    objworker.Landpurchasedrateper = GetDecimalNullValue(txtLandpurchasedrateper.Text.Trim().TrimStart());

                    objworker.CreatedBy = ObjLoginNewvo.uid;
                    string Validstatus = ObjCAFClass.InsertingOfDevelopmentWorkerHousingDtls(objworker);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        Response.Redirect("frmTraningSubsidy.aspx?next=" + "N");
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
            Response.Redirect("frmRebateCharges.aspx?Previous=" + "P");
        }

        protected void btnWorkersDetails_Click(object sender, EventArgs e)
        {
            if (fuWorkersDetails.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuWorkersDetails);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuWorkersDetails);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuWorkersDetails, hyWorkersDetails, "WorkersDetails", Session["IncentiveID"].ToString(), "15", "151006", Session["uid"].ToString(), "USER");

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