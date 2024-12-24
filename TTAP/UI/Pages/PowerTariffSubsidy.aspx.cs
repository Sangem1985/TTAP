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
    public partial class PowerTariffSubsidy : System.Web.UI.Page
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
                        if (Session["uid"] != null)
                        {
                            if (Session["incentivedata"] != null)
                            {
                                string userid = Session["uid"].ToString();
                                string IncentveID = Session["IncentiveID"].ToString();
                                DataSet ds = new DataSet();
                                ds = (DataSet)Session["incentivedata"];
                                DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 4);
                                if (drs.Length > 0)
                                {
                                    DataSet dsnew = new DataSet();


                                    BindBeforeDCPFinancialYears(ddlFinYearPower, "3", Session["IncentiveID"].ToString());
                                    BindFinancialYears(ddlFinYearEnergy, "10", Session["IncentiveID"].ToString());

                                    GetPowerTariffSubsidy(userid, IncentveID);

                                    BindPowerTariffUtilizationDtls(Session["IncentiveID"].ToString());
                                    BindEnergyconsumedDtls(Session["IncentiveID"].ToString());

                                }
                                else
                                {
                                    if (Request.QueryString[0].ToString() == "N")
                                    {
                                        Response.Redirect("frmStampDuty.aspx?next=" + "N");
                                    }
                                    else
                                    {
                                        Response.Redirect("InterestSubsidy.aspx?Previous=" + "P");
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
        public DataSet GetDCPBeforeFinancialYearIncentives(string Count, string incentiveid)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@YEARS",SqlDbType.VarChar),
                new SqlParameter("@incentiveid",SqlDbType.VarChar)
           };
            pp[0].Value = Count;
            pp[1].Value = incentiveid;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_FINANCIALYEARS_BEFOREDCP", pp);
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
        private void BindBeforeDCPFinancialYears(DropDownList ddl, string Count, string incentiveid)
        {
            comFunctions cmf = new comFunctions();
            General Gen = new General();
            DataSet dsYears = new DataSet();
            ddl.Items.Clear();
            dsYears = GetDCPBeforeFinancialYearIncentives(Count, incentiveid);
            if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = dsYears.Tables[0];
                ddl.DataTextField = "FinancialYear";
                ddl.DataValueField = "SlNo";
                ddl.DataBind();
            }
            AddSelect(ddl);
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
        #region Power utilized during previous three financial years before this expansion/ diversification project
        public string ValidatePowerDtls(string Type)
        {
            int slno = 1;
            string ErrorMsg = "";
            if (Type == "1")
            {
                if (ddlFinYearPower.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Financial Year \\n";
                    slno = slno + 1;
                }

                if (txtTotalUnits.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Eneter Total Untis Consumed \\n";
                    slno = slno + 1;
                }
                if (txtTotalAmount.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Eneter Total Amount Paid(In Rupees) \\n";
                    slno = slno + 1;
                }
            }
            else if (Type == "2")
            {
                if (ddlFinYearEnergy.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Financial Year \\n";
                    slno = slno + 1;
                }
                if (ddlFin1stOr2ndHalfyear.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Financial Half Year \\n";
                    slno = slno + 1;
                }

                if (txtPurposeofConnection.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Eneter Purpose of Connection \\n";
                    slno = slno + 1;
                }
                if (txtServiceNo.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Eneter Service No/Meter No \\n";
                    slno = slno + 1;
                }
                if (txtReadingNumberFrom.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Eneter From Reading Number \\n";
                    slno = slno + 1;
                }
                if (txtReadingNumberTo.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Eneter To Reading Number \\n";
                    slno = slno + 1;
                }
                if (txtNoofUnits.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Eneter Total Untis Consumed \\n";
                    slno = slno + 1;
                }

                if (txtRateofUnit.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Eneter Rate of Unit (In Rupees) \\n";
                    slno = slno + 1;
                }
                if (txtOtherCharges.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please EneterOther Charges (In Rupees) \\n";
                    slno = slno + 1;
                }

                if (txtAmountPaid.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Eneter Total Amount Paid(In Rupees) \\n";
                    slno = slno + 1;
                }
            }
            else if (Type == "3")
            {
                if (txtExistingPower.Text.Trim().TrimStart() == "" && ViewState["TypeOfIndustry"] != null && ViewState["TypeOfIndustry"].ToString() != "1")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Eneter Existing Power Connection in HP (base) \\n";
                    slno = slno + 1;
                }
                if (txtNewPower.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Eneter New Power Connection in HP \\n";
                    slno = slno + 1;
                }
                if (txtDateofNewpower.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Date of New Power Connection Released \\n";
                    slno = slno + 1;
                }
                if (txtTotalPowerconnections.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Total No. of Power connections including Industry, colonies, Residential & street/parks etc \\n";
                    slno = slno + 1;
                }
                if (txtIndustryPowerconnections.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter No. of Power connections exclusively for Industry use \\n";
                    slno = slno + 1;
                }


                if (txtCurrentClaimPeriodfrom.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Current Claim Period From date \\n";
                    slno = slno + 1;
                }
                if (txtCurrentClaimPeriodto.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Current Claim Period To date \\n";
                    slno = slno + 1;
                }
                if (txtCurrentClaimAmount.Text.Trim().TrimStart() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Eneter Current Claim Amount \\n";
                    slno = slno + 1;
                }


                if (grdPowerutilized.Rows.Count < 1)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Add Power utilized during previous three financial years before this expansion / diversification project \\n";
                    slno = slno + 1;
                }
                if (grdEnergyConsumed.Rows.Count < 1)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Add Details of Energy consumed from the date of commencement of production and amount claimed for the Half year \\n";
                    slno = slno + 1;
                }
            }
            return ErrorMsg;
        }


        protected void BindPowerTariffUtilizationDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetPowerTariffUtilizationDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    grdPowerutilized.DataSource = dsnew.Tables[0];
                    grdPowerutilized.DataBind();
                }
                else
                {
                    grdPowerutilized.DataSource = null;
                    grdPowerutilized.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetPowerTariffUtilizationDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_PowerTariffUtilization_DTLS", pp);
            return Dsnew;
        }


        protected void BindEnergyconsumedDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetEnergyconsumedDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    grdEnergyConsumed.DataSource = dsnew.Tables[0];
                    grdEnergyConsumed.DataBind();
                }
                else
                {
                    grdEnergyConsumed.DataSource = null;
                    grdEnergyConsumed.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetEnergyconsumedDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_Energyconsumed_DTLS", pp);
            return Dsnew;
        }
        #endregion

        public void Clear()
        {
            txtExistingPower.Text = string.Empty;
            txtNewPower.Text = string.Empty;
            txtDateofNewpower.Text = string.Empty;
            //txtCurrentClaimPeriod.Text = string.Empty;
            txtCurrentClaimAmount.Text = string.Empty;

            grdPowerutilized.DataSource = null;
            grdPowerutilized.DataBind();

            grdEnergyConsumed.DataSource = null;
            grdEnergyConsumed.DataBind();
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
        public void GetPowerTariffSubsidy(string uid, string IncentiveID)
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
                    string TypeOfIndustry = dsnew.Tables[0].Rows[0]["TypeOfIndustry"].ToString();
                    ViewState["TypeOfIndustry"] = TypeOfIndustry;
                    if (TypeOfIndustry == "1")
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCP"].ToString();
                        txtDateofNewpower.Text = dsnew.Tables[0].Rows[0]["NewPowerReleaseDate"].ToString();
                        try
                        {
                            // txtNewPower.Text = ((Convert.ToDouble(GetDecimalNullValue(dsnew.Tables[0].Rows[0]["NewConnectedLoad"].ToString())) * 0.95) / 0.75).ToString("#.##");
                            txtNewPower.Text = GetDecimalNullValue(dsnew.Tables[0].Rows[0]["NewConnectedLoad"].ToString()).ToString();
                        }
                        catch (Exception ex)
                        {
                            string errorMsg = ex.Message;
                        }
                        //txtContractedMaximumDemandinKVA.Text = ((Convert.ToDouble(txtConnectedLoadHP.Text.Trim()) * 0.75) / 0.95).ToString();
                    }
                    else
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCPExp"].ToString();
                        txtDateofNewpower.Text = dsnew.Tables[0].Rows[0]["ExistingPowerReleaseDate"].ToString();
                        try
                        {
                            //txtExistingPower.Text = Math.Round(((Convert.ToDouble(GetDecimalNullValue(dsnew.Tables[0].Rows[0]["ExistingConnectedLoad"].ToString())) * 0.95) / 0.75)).ToString();
                            //txtNewPower.Text = Math.Round(((Convert.ToDouble(GetDecimalNullValue(dsnew.Tables[0].Rows[0]["ExpanDiverConnectedLoad"].ToString())) * 0.95) / 0.75)).ToString();

                            txtExistingPower.Text = GetDecimalNullValue(dsnew.Tables[0].Rows[0]["ExistingConnectedLoad"].ToString()).ToString();
                            txtNewPower.Text = GetDecimalNullValue(dsnew.Tables[0].Rows[0]["ExpanDiverConnectedLoad"].ToString()).ToString();
                        }
                        catch (Exception ex)
                        {
                            string errorMsg = ex.Message;
                        }
                    }
                    if (txtDateofNewpower.Text != "")
                    {
                        txtDateofNewpower.Enabled = false;
                    }

                    lblCategoryofUnit.InnerText = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    lblActivityoftheUnit.InnerText = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();
                    lblTextileType.InnerText = dsnew.Tables[0].Rows[0]["TypeofTexttileText"].ToString();

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
                            DivEnergyconsumed.Visible = false;

                            grdPowerutilized.Columns[5].Visible = false;
                            grdPowerutilized.Columns[4].Visible = false;


                            grdEnergyConsumed.Columns[12].Visible = false;
                            grdEnergyConsumed.Columns[11].Visible = false;

                            btnPowerrelease.Enabled = false;
                            btnPowerBill.Enabled = false;
                            btnValidConsent.Enabled = false;
                            btnPowerutilization.Enabled = false;
                            btnrelevantelectricity.Enabled = false;
                            btnCopyofRent.Enabled = false;
                            btnCACertificate.Enabled = false;
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
                ds = Gen.GenericFillDs("USP_GET_POWERTARIFF_DTLS", p);
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.ToString() != "" && ds.Tables[0].Rows.ToString() != null)
                {
                    txtExistingPower.Text = ds.Tables[0].Rows[0]["ExistingPower"].ToString();
                    txtNewPower.Text = ds.Tables[0].Rows[0]["NewPower"].ToString();
                    txtDateofNewpower.Text = ds.Tables[0].Rows[0]["DateofNewpower"].ToString();

                    txtCurrentClaimAmount.Text = ds.Tables[0].Rows[0]["CurrentClaimAmount"].ToString();

                    txtCurrentClaimPeriodfrom.Text = ds.Tables[0].Rows[0]["CurrentClaimPeriodFrom"].ToString();
                    txtCurrentClaimPeriodto.Text = ds.Tables[0].Rows[0]["CurrentClaimPeriodTo"].ToString();
                    txtTotalPowerconnections.Text = ds.Tables[0].Rows[0]["TotalPowerconnections"].ToString();
                    txtIndustryPowerconnections.Text = ds.Tables[0].Rows[0]["IndustryPowerconnections"].ToString();

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
                                    if (Docid == "41001")
                                    {
                                        objClsFileUpload.AssignPath(hyPowerrelease, Path);
                                    }
                                    else if (Docid == "41002")
                                    {
                                        objClsFileUpload.AssignPath(hyPowerBill, Path);
                                    }
                                    else if (Docid == "41003")
                                    {
                                        objClsFileUpload.AssignPath(hyValidConsent, Path);
                                    }
                                    else if (Docid == "41004")
                                    {
                                        objClsFileUpload.AssignPath(hyPowerutilization, Path);
                                    }
                                    else if (Docid == "41005")
                                    {
                                        objClsFileUpload.AssignPath(hyrelevantelectricity, Path);
                                    }
                                    else if (Docid == "41006")
                                    {
                                        objClsFileUpload.AssignPath(hyCopyofRent, Path);
                                    }
                                    else if (Docid == "41007")
                                    {
                                        objClsFileUpload.AssignPath(HyCACertificate, Path);
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
            }
            catch (Exception ex)
            {

                throw ex;
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

        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("InterestSubsidy.aspx?Previous=" + "P");
        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        protected void btnPowerrelease_Click(object sender, EventArgs e)
        {
            if (fuPowerrelease.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuPowerrelease);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuPowerrelease);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuPowerrelease, hyPowerrelease, "PowerreleasecertificateissuedbyDISCOM", Session["IncentiveID"].ToString(), "4", "41001", Session["uid"].ToString(), "USER");

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



        protected void btnPowerBill_Click(object sender, EventArgs e)
        {

            if (fuPowerBill.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuPowerBill);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuPowerBill);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuPowerBill, hyPowerBill, "PowerBillandPaymentProof", Session["IncentiveID"].ToString(), "4", "41002", Session["uid"].ToString(), "USER");

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

        protected void btnValidConsent_Click(object sender, EventArgs e)
        {
            if (fuValidConsent.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuValidConsent);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuValidConsent);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuValidConsent, hyValidConsent, "ValidConsentforOperationCFOfromTSPCB", Session["IncentiveID"].ToString(), "4", "41003", Session["uid"].ToString(), "USER");

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

        protected void btnPowerutilization_Click(object sender, EventArgs e)
        {
            if (fuPowerutilization.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuPowerutilization);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuPowerutilization);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuPowerutilization, hyPowerutilization, "PowerutilizationParticularsforthelast3years", Session["IncentiveID"].ToString(), "4", "41004", Session["uid"].ToString(), "USER");

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


        protected void btnrelevantelectricity_Click(object sender, EventArgs e)
        {


            if (furelevantelectricity.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(furelevantelectricity);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(furelevantelectricity);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), furelevantelectricity, hyrelevantelectricity, "Copiesofallrelevantelectricitybills", Session["IncentiveID"].ToString(), "4", "41005", Session["uid"].ToString(), "USER");

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

        protected void btnCopyofRent_Click(object sender, EventArgs e)
        {
            if (fuCopyofRent.HasFile)
            {

                string errormsg = objClsFileUpload.CheckFileSize(fuCopyofRent);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuCopyofRent);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuCopyofRent, hyCopyofRent, "RentLeaseDeed", Session["IncentiveID"].ToString(), "4", "41006", Session["uid"].ToString(), "USER");

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
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuCACertificate, HyCACertificate, "CACertificatewithdetailsofproducts", Session["IncentiveID"].ToString(), "4", "41007", Session["uid"].ToString(), "USER");

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
        protected void btnPowerutilizedadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["Powerutilized_ID"] == null)
                {
                    ViewState["Powerutilized_ID"] = "0";
                }

                string errormsg = ValidatePowerDtls("1");
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

                    PowerUtilizedBO objPowerUtilizedBO = new PowerUtilizedBO();

                    objPowerUtilizedBO.Powerutilized_ID = ViewState["Powerutilized_ID"].ToString();
                    objPowerUtilizedBO.TransType = "INS";
                    objPowerUtilizedBO.IncentiveId = Session["IncentiveID"].ToString();
                    objPowerUtilizedBO.Created_by = ObjLoginNewvo.uid;

                    objPowerUtilizedBO.FinancialYear = ddlFinYearPower.SelectedValue;
                    objPowerUtilizedBO.FinancialYearText = ddlFinYearPower.SelectedItem.Text;
                    objPowerUtilizedBO.TotalUnits = (txtTotalUnits.Text.Trim().TrimStart() != "") ? txtTotalUnits.Text.Trim().TrimStart() : null;
                    objPowerUtilizedBO.TotalAmount = (txtTotalAmount.Text.Trim().TrimStart() != "") ? txtTotalAmount.Text.Trim().TrimStart() : null;


                    string Validstatus = ObjCAFClass.InsertPowerTariffLastThreeYearsDetails(objPowerUtilizedBO);
                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        btnPowerutilizedadd.Text = "Add New";
                        ViewState["Powerutilized_ID"] = "0";

                        ddlFinYearPower.SelectedValue = "0";
                        txtTotalUnits.Text = "";
                        txtTotalAmount.Text = "";

                        BindPowerTariffUtilizationDtls(Session["IncentiveID"].ToString());
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
        protected void grdPowerutilized_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                ddlFinYearPower.SelectedValue = ((Label)(gr.FindControl("lblFinancialYearID"))).Text;
                txtTotalUnits.Text = ((Label)(gr.FindControl("lblTotalUnits"))).Text;
                txtTotalAmount.Text = ((Label)(gr.FindControl("lblTotalAmount"))).Text;

                ViewState["Powerutilized_ID"] = ((Label)(gr.FindControl("lblPowerutilizedID"))).Text;
                btnPowerutilizedadd.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];


                PowerUtilizedBO objPowerUtilizedBO = new PowerUtilizedBO();

                objPowerUtilizedBO.Powerutilized_ID = ((Label)(gr.FindControl("lblPowerutilizedID"))).Text;
                objPowerUtilizedBO.TransType = "DLT";
                objPowerUtilizedBO.IncentiveId = Session["IncentiveID"].ToString();
                objPowerUtilizedBO.Created_by = ObjLoginNewvo.uid;


                string Validstatus = ObjCAFClass.InsertPowerTariffLastThreeYearsDetails(objPowerUtilizedBO);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnPowerutilizedadd.Text = "Add New";
                    ViewState["Powerutilized_ID"] = "0";

                    ddlFinYearPower.SelectedValue = "0";
                    txtTotalUnits.Text = "";
                    txtTotalAmount.Text = "";

                    BindPowerTariffUtilizationDtls(Session["IncentiveID"].ToString());
                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }

        protected void btnEnergyConsumedAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["EnergyConsumed_ID"] == null)
                {
                    ViewState["EnergyConsumed_ID"] = "0";
                }
                if (grdEnergyConsumed.Rows.Count > 0)
                {
                    string errormsg1 = "Only one Half Year allowed";
                    string message = "alert('" + errormsg1 + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string errormsg = ValidatePowerDtls("2");
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

                    EnergyConsumedBO objEnergyConsumedBO = new EnergyConsumedBO();

                    objEnergyConsumedBO.EnergyConsumed_ID = ViewState["EnergyConsumed_ID"].ToString();
                    objEnergyConsumedBO.TransType = "INS";
                    objEnergyConsumedBO.IncentiveId = Session["IncentiveID"].ToString();
                    objEnergyConsumedBO.Created_by = ObjLoginNewvo.uid;

                    objEnergyConsumedBO.FinancialYear = ddlFinYearEnergy.SelectedValue;
                    objEnergyConsumedBO.FinancialYearText = ddlFinYearEnergy.SelectedItem.Text;

                    objEnergyConsumedBO.TypeOfFinancialYear = ddlFin1stOr2ndHalfyear.SelectedValue;
                    objEnergyConsumedBO.TypeOfFinancialYearText = ddlFin1stOr2ndHalfyear.SelectedItem.Text;
                    objEnergyConsumedBO.ServiceNo = txtServiceNo.Text.Trim().TrimStart();
                    objEnergyConsumedBO.TotalUnits = (txtNoofUnits.Text.Trim().TrimStart() != "") ? txtNoofUnits.Text.Trim().TrimStart() : null;
                    objEnergyConsumedBO.TotalAmount = (txtAmountPaid.Text.Trim().TrimStart() != "") ? txtAmountPaid.Text.Trim().TrimStart() : null;

                    objEnergyConsumedBO.PurposeofConnection = txtPurposeofConnection.Text.Trim().TrimStart();
                    objEnergyConsumedBO.RateofUnit = GetDecimalNullValue(txtRateofUnit.Text.Trim().TrimStart());
                    objEnergyConsumedBO.OtherCharges = GetDecimalNullValue(txtOtherCharges.Text.Trim().TrimStart());

                    objEnergyConsumedBO.FromReadingNumber = txtReadingNumberFrom.Text.Trim().TrimStart();
                    objEnergyConsumedBO.ToReadingNumber = txtReadingNumberTo.Text.Trim().TrimStart();

                    string Validstatus = ObjCAFClass.InsertEnergyconsumedDetails(objEnergyConsumedBO);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        btnEnergyConsumedAdd.Text = "Add New";
                        ViewState["EnergyConsumed_ID"] = "0";

                        ddlFinYearEnergy.SelectedValue = "0";
                        ddlFin1stOr2ndHalfyear.SelectedValue = "0";
                        txtNoofUnits.Text = "";
                        txtAmountPaid.Text = "";
                        txtServiceNo.Text = "";
                        txtPurposeofConnection.Text = "";
                        txtRateofUnit.Text = "";
                        txtOtherCharges.Text = "";
                        BindEnergyconsumedDtls(Session["IncentiveID"].ToString());
                        lblmsg.Text = "Saved Successfully";
                        Failure.Visible = false;
                        success.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        protected void grdEnergyConsumed_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                ddlFinYearEnergy.SelectedValue = ((Label)(gr.FindControl("lblEnergyFinancialYearID"))).Text;
                ddlFin1stOr2ndHalfyear.SelectedValue = ((Label)(gr.FindControl("lblTypeOfFinancialYear"))).Text;

                txtServiceNo.Text = ((Label)(gr.FindControl("lblServiceNo"))).Text;

                txtNoofUnits.Text = ((Label)(gr.FindControl("lblEnergyConsumedNoofUnits"))).Text;
                txtAmountPaid.Text = ((Label)(gr.FindControl("lblEnergyConsumedAmountPaid"))).Text;

                txtPurposeofConnection.Text = ((Label)(gr.FindControl("lblPurposeofConnection"))).Text;
                txtRateofUnit.Text = ((Label)(gr.FindControl("lblRateofUnit"))).Text;
                txtOtherCharges.Text = ((Label)(gr.FindControl("lblOtherCharges"))).Text;

                txtReadingNumberFrom.Text = ((Label)(gr.FindControl("lblFromReadingNumber"))).Text;
                txtReadingNumberTo.Text = ((Label)(gr.FindControl("lblToReadingNumber"))).Text;


                ViewState["EnergyConsumed_ID"] = ((Label)(gr.FindControl("lblEnergyconsumedID"))).Text;
                btnEnergyConsumedAdd.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];


                EnergyConsumedBO objEnergyConsumedBO = new EnergyConsumedBO();

                objEnergyConsumedBO.EnergyConsumed_ID = ((Label)(gr.FindControl("lblEnergyconsumedID"))).Text;
                objEnergyConsumedBO.TransType = "DLT";
                objEnergyConsumedBO.IncentiveId = Session["IncentiveID"].ToString();
                objEnergyConsumedBO.Created_by = ObjLoginNewvo.uid;


                string Validstatus = ObjCAFClass.InsertEnergyconsumedDetails(objEnergyConsumedBO);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnEnergyConsumedAdd.Text = "Add New";
                    ViewState["EnergyConsumed_ID"] = "0";

                    ddlFinYearEnergy.SelectedValue = "0";
                    ddlFin1stOr2ndHalfyear.SelectedValue = "0";
                    txtNoofUnits.Text = "";
                    txtAmountPaid.Text = "";
                    txtPurposeofConnection.Text = "";
                    txtRateofUnit.Text = "";
                    txtOtherCharges.Text = "";

                    BindEnergyconsumedDtls(Session["IncentiveID"].ToString());

                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            try
            {
                string errormsg = ValidatePowerDtls("3");
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    string errormsgAttach = ObjCAFClass.ValidateMandatoryAttachments(Session["IncentiveID"].ToString(), "4");
                    if (errormsgAttach.Trim().TrimStart() != "")
                    {
                        string message = "alert('" + errormsgAttach + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }

                    PowerTariffSubsidyBO objBO = new PowerTariffSubsidyBO();
                    objBO.IncentiveID = Session["IncentiveID"].ToString();

                    objBO.ExistingPower = (txtExistingPower.Text.Trim().TrimStart() != "") ? txtExistingPower.Text.Trim().TrimStart() : "0";
                    objBO.NewPower = (txtNewPower.Text.Trim().TrimStart() != "") ? txtNewPower.Text.Trim().TrimStart() : "0";

                    objBO.TotalPowerconnections = GetDecimalNullValue(txtTotalPowerconnections.Text.Trim().TrimStart());
                    objBO.IndustryPowerconnections = GetDecimalNullValue(txtIndustryPowerconnections.Text.Trim().TrimStart());

                    string[] Ld6 = null;
                    string ConvertedDt56 = "";

                    Ld6 = null;
                    ConvertedDt56 = "";

                    if (txtDateofNewpower.Text.Trim().TrimStart() != "")
                    {
                        Ld6 = txtDateofNewpower.Text.Trim().TrimStart().Split('/');
                        ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();
                        objBO.DateofNewpower = ConvertedDt56;
                    }
                    else
                    {
                        objBO.DateofNewpower = null;
                    }




                    Ld6 = null;
                    ConvertedDt56 = "";

                    if (txtCurrentClaimPeriodfrom.Text.Trim().TrimStart() != "")
                    {
                        Ld6 = txtCurrentClaimPeriodfrom.Text.Trim().TrimStart().Split('/');
                        ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();
                        objBO.CurrentClaimPeriodFrom = ConvertedDt56;
                    }
                    else
                    {
                        objBO.CurrentClaimPeriodFrom = null;
                    }

                    Ld6 = null;
                    ConvertedDt56 = "";

                    if (txtCurrentClaimPeriodto.Text.Trim().TrimStart() != "")
                    {
                        Ld6 = txtCurrentClaimPeriodto.Text.Trim().TrimStart().Split('/');
                        ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();
                        objBO.CurrentClaimPeriodTo = ConvertedDt56;
                    }
                    else
                    {
                        objBO.CurrentClaimPeriodTo = null;
                    }

                    objBO.CurrentClaimAmount = (txtCurrentClaimAmount.Text.Trim().TrimStart() != "") ? txtCurrentClaimAmount.Text.Trim().TrimStart() : "0";

                    objBO.CreatedBy = Session["uid"].ToString();

                    string Validstatus = ObjCAFClass.InsertingOfPowerTariffdetails(objBO);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        Response.Redirect("frmStampDuty.aspx?next=" + "N");
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
    }
}