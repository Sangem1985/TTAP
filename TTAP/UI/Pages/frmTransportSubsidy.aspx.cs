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
    public partial class frmTransportSubsidy : System.Web.UI.Page
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
                            DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 9);
                            if (drs.Length > 0)
                            {
                                DataSet dsnew = new DataSet();

                                BindFinancialYears(ddlFinYear, "5", Session["IncentiveID"].ToString());
                                BindFinancialYears(ddlLast3Years, "5", Session["IncentiveID"].ToString());
                                BindFinancialYears(ddlCurrentClaimFinancialYear, "5", Session["IncentiveID"].ToString());

                                GetTransportSubsidy(userid, IncentveID);
                                BindExportIntensiveTextileDtls(Session["IncentiveID"].ToString());
                                BindExportRevenueDtls(Session["IncentiveID"].ToString());
                                BindCurrentClaimDtls(Session["IncentiveID"].ToString());
                                //dsnew = Gen.GetIncentivesISdata(IncentveID, "6");
                                //Filldata(dsnew);
                            }
                            else
                            {
                                if (Request.QueryString[0].ToString() == "N")
                                {
                                    Response.Redirect("frmProductDevelopment.aspx?next=" + "N");
                                }
                                else
                                {
                                    Response.Redirect("frmAssistanceAcquisition.aspx?Previous=" + "P");
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

        public void GetTransportSubsidy(string uid, string IncentiveID)
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

                            DivSGSTReimbursement.Visible = false;
                            grdSGSTReimbursement.Columns[5].Visible = false;
                            grdSGSTReimbursement.Columns[4].Visible = false;

                            DivExportRevenueDetails.Visible = false;
                            gvExportRevenueDetails.Columns[7].Visible = false;
                            gvExportRevenueDetails.Columns[6].Visible = false;

                            DivCurrentFinancialYear.Visible = false;
                            GvCurrentClaimPeriod.Columns[10].Visible = false;
                            GvCurrentClaimPeriod.Columns[9].Visible = false;

                            btnStatementofrawmaterialspurchased.Enabled = false;
                            btnutilizationRawMaterials.Enabled = false;
                            btnStatementFinishedProducts.Enabled = false;
                            btnIECImportIndustrialInvoice.Enabled = false;
                            btnRCvehiclestransportingrawmaterials.Enabled = false;
                            btnTrucksTransportcompanies.Enabled = false;
                            btnpaymentmadetoTransporters.Enabled = false;
                            btnBankACNoName.Enabled = false;
                            btnBillsChallanconsignment.Enabled = false;
                            btnRailwayfreightcertificate.Enabled = false;
                            btnRoaddistancecertificate.Enabled = false;
                            btnBankStatement.Enabled = false;
                            btnBillsChallanconsignmentfinishedgoods.Enabled = false;
                            btntransportersforcarryingFP.Enabled = false;
                            btnCertificatefromExciseDept.Enabled = false;
                            btnconsignmentsoldtotheparty.Enabled = false;
                            btnaddressofpurchasers.Enabled = false;
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
                ds = Gen.GenericFillDs("USP_GET_Transport_Export_Intensive_Textile", p);
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.ToString() != "" && ds.Tables[0].Rows.ToString() != null)
                {

                    string TypeofInfrastructure = ds.Tables[0].Rows[0]["NatureofBusiness"].ToString();
                    if (TypeofInfrastructure != "")
                    {
                        string[] TypeofInfrastructureVal = TypeofInfrastructure.Split(',');

                        foreach (string Value in TypeofInfrastructureVal)
                        {
                            int Index = chkNatureofBusiness.Items.IndexOf(chkNatureofBusiness.Items.FindByValue(Value));
                            chkNatureofBusiness.Items[Index].Selected = true;
                        }
                    }
                    ddlModeofTransport.SelectedValue = ds.Tables[0].Rows[0]["MOTId"].ToString();
                    txtDateofEstablishmentofUnit.Text = ds.Tables[0].Rows[0]["DateofEstablishmentofUnit"].ToString();
                    txtPercentageTotalRevenue.Text = ds.Tables[0].Rows[0]["PercentageTotalRevenue"].ToString();
                    txtNearestAirport.Text = ds.Tables[0].Rows[0]["NearestAirport"].ToString();
                    txtNearestSeaport.Text = ds.Tables[0].Rows[0]["NearestSeaport"].ToString();
                    txtNearestDryPort.Text = ds.Tables[0].Rows[0]["NearestDryPort"].ToString();
                    ddlTypeofExport.SelectedValue = ds.Tables[0].Rows[0]["TypeofExport"].ToString();
                    txtDetailsRawMaterialsImported.Text = ds.Tables[0].Rows[0]["DetailsRawMaterialsImported"].ToString();
                    txtFinishedProducts.Text = ds.Tables[0].Rows[0]["DetailsFinishedProducts"].ToString();
                    txtFinishedProductsExported.Text = ds.Tables[0].Rows[0]["FinishedProductsExported"].ToString();
                    txtCurrentClaim.Text = ds.Tables[0].Rows[0]["CurrentClaim"].ToString();
                    //txtExportRevenue.Text = ds.Tables[0].Rows[0]["ExportRevenue"].ToString();
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
                                if (Docid == "91001")
                                {
                                    objClsFileUpload.AssignPath(hyStatementofrawmaterialspurchased, Path);
                                }
                                else if (Docid == "91002")
                                {
                                    objClsFileUpload.AssignPath(hyutilizationRawMaterials, Path);
                                }
                                else if (Docid == "91003")
                                {
                                    objClsFileUpload.AssignPath(hyStatementFinishedProducts, Path);
                                }
                                else if (Docid == "91004")
                                {
                                    objClsFileUpload.AssignPath(hyIECImportIndustrialInvoice, Path);
                                }
                                else if (Docid == "91005")
                                {
                                    objClsFileUpload.AssignPath(hyRCvehiclestransportingrawmaterials, Path);
                                }
                                else if (Docid == "91006")
                                {
                                    objClsFileUpload.AssignPath(hyTrucksTransportcompanies, Path);
                                }
                                else if (Docid == "91007")
                                {
                                    objClsFileUpload.AssignPath(hypaymentmadetoTransporters, Path);
                                }
                                else if (Docid == "91008")
                                {
                                    objClsFileUpload.AssignPath(hyBankACNoName, Path);
                                }
                                else if (Docid == "91009")
                                {
                                    objClsFileUpload.AssignPath(hyBillsChallanconsignment, Path);
                                }
                                else if (Docid == "91010")
                                {
                                    objClsFileUpload.AssignPath(hyRailwayfreightcertificate, Path);
                                }
                                else if (Docid == "91011")
                                {
                                    objClsFileUpload.AssignPath(hyRoaddistancecertificate, Path);
                                }
                                else if (Docid == "91012")
                                {
                                    objClsFileUpload.AssignPath(hyBankStatement, Path);
                                }
                                else if (Docid == "91013")
                                {
                                    objClsFileUpload.AssignPath(hyBillsChallanconsignmentfinishedgoods, Path);
                                }
                                else if (Docid == "91014")
                                {
                                    objClsFileUpload.AssignPath(hytransportersforcarryingFP, Path);
                                }
                                else if (Docid == "91015")
                                {
                                    objClsFileUpload.AssignPath(hyCertificatefromExciseDept, Path);
                                }
                                else if (Docid == "91016")
                                {
                                    objClsFileUpload.AssignPath(hyconsignmentsoldtotheparty, Path);
                                }
                                else if (Docid == "91017")
                                {
                                    objClsFileUpload.AssignPath(hyaddressofpurchasers, Path);
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
                ErrorMsg = ErrorMsg + slno + ". Please Select Date Of Incorporation of Unit \\n";
                slno = slno + 1;
            }
            int selectedCount = chkNatureofBusiness.Items.Cast<ListItem>().Count(li => li.Selected);
            if (selectedCount == 0)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select at Least One Nature of Business/Business Type \\n";
                slno = slno + 1;
            }

            if (txtPercentageTotalRevenue.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Percentage of Total Revenue as Exports \\n";
                slno = slno + 1;
            }
            if (ddlTypeofExport.SelectedValue == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Type of Export \\n";
                slno = slno + 1;
            }
            if (ddlModeofTransport.SelectedValue == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Mode of Transport \\n";
                slno = slno + 1;
            }

            //if (txtExportRevenue.Text.TrimStart().Trim() == "")
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please EnterDetail of Export Revenue for last three years (3) and its average \\n";
            //    slno = slno + 1;
            //}
            if (gvExportRevenueDetails.Rows.Count < 1)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Add Export Revenue Deatils for last three years (3) and its average \\n";
                slno = slno + 1;
            }
            if (txtCurrentClaim.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Total Claim Amount (In Rs) \\n";
                slno = slno + 1;
            }
            //if (grdSGSTReimbursement.Rows.Count < 1)
            //{
            //    ErrorMsg = ErrorMsg + slno + ". Please Enter Total Claim Amount (In Rs) \\n";
            //    slno = slno + 1;
            //}

            return ErrorMsg;
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

                    string errormsgAttach = ObjCAFClass.ValidateMandatoryAttachments(Session["IncentiveID"].ToString(), "9");
                    if (errormsgAttach.Trim().TrimStart() != "")
                    {
                        string message = "alert('" + errormsgAttach + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    TransportSubsidy objTransportSubsidy = new TransportSubsidy();

                    objTransportSubsidy.IncentiveId = Session["IncentiveID"].ToString();

                    objTransportSubsidy.DateofEstablishmentofUnit = GetFromatedDateDDMMYYYY(txtDateofEstablishmentofUnit.Text.Trim().TrimStart());
                    string Typeofinfra = "";
                    foreach (ListItem li in chkNatureofBusiness.Items)
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
                    objTransportSubsidy.NatureofBusiness = Typeofinfra;
                    objTransportSubsidy.TotalRevenue = GetDecimalNullValue(txtPercentageTotalRevenue.Text.Trim().TrimStart());
                    objTransportSubsidy.NearestAirport = txtNearestAirport.Text.Trim().TrimStart();
                    objTransportSubsidy.NearestSeaport = txtNearestSeaport.Text.Trim().TrimStart();
                    objTransportSubsidy.NearestDryPort = txtNearestDryPort.Text.Trim().TrimStart();
                    objTransportSubsidy.TypeofExport = ddlTypeofExport.SelectedValue;
                    objTransportSubsidy.ModeofTransport = ddlModeofTransport.SelectedValue;
                    objTransportSubsidy.DetailsRawMaterialsImported = txtDetailsRawMaterialsImported.Text.Trim().TrimStart();
                    objTransportSubsidy.DetailsFinishedProducts = txtFinishedProducts.Text.Trim().TrimStart();
                    objTransportSubsidy.FinishedProductsExported = txtFinishedProductsExported.Text.Trim().TrimStart();
                    objTransportSubsidy.CurrentClaim = GetDecimalNullValue(txtCurrentClaim.Text.Trim().TrimStart());
                    //objTransportSubsidy.ExportRevenue = txtExportRevenue.Text.Trim().TrimStart();
                    objTransportSubsidy.CreatedBy = ObjLoginNewvo.uid;
                    string Validstatus = ObjCAFClass.InsertingOfTransportSubsidyExportIntensiveTextileDtls(objTransportSubsidy);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        Response.Redirect("frmProductDevelopment.aspx?next=" + "N");
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
            Response.Redirect("frmAssistanceAcquisition.aspx?Previous=" + "P");
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



        // Multiple Add

        public string ValidateDtls()
        {
            int slno = 1;
            string ErrorMsg = "";


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

            if (txtAmountPaid.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Total Amount(In Rupees) \\n";
                slno = slno + 1;
            }


            return ErrorMsg;
        }
        protected void btnSGSTReimbursementAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["Export_Intensive_Textile_ID"] == null)
                {
                    ViewState["Export_Intensive_Textile_ID"] = "0";
                }

                string errormsg = ValidateDtls();
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

                    objEnergyConsumedBO.EnergyConsumed_ID = ViewState["Export_Intensive_Textile_ID"].ToString();
                    objEnergyConsumedBO.TransType = "INS";
                    objEnergyConsumedBO.IncentiveId = Session["IncentiveID"].ToString();
                    objEnergyConsumedBO.Created_by = ObjLoginNewvo.uid;

                    objEnergyConsumedBO.FinancialYear = ddlFinYear.SelectedValue;
                    objEnergyConsumedBO.FinancialYearText = ddlFinYear.SelectedItem.Text;

                    objEnergyConsumedBO.TypeOfFinancialYear = ddlFin1stOr2ndHalfyear.SelectedValue;
                    objEnergyConsumedBO.TypeOfFinancialYearText = ddlFin1stOr2ndHalfyear.SelectedItem.Text;

                    objEnergyConsumedBO.TotalAmount = (txtAmountPaid.Text.Trim().TrimStart() != "") ? txtAmountPaid.Text.Trim().TrimStart() : null;

                    string Validstatus = ObjCAFClass.InsertExportIntensiveTextileDetails(objEnergyConsumedBO);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        btnSGSTReimbursementAdd.Text = "Add New";
                        ViewState["Export_Intensive_Textile_ID"] = "0";

                        ddlFinYear.SelectedValue = "0";
                        ddlFin1stOr2ndHalfyear.SelectedValue = "0";
                        txtAmountPaid.Text = "";

                        BindExportIntensiveTextileDtls(Session["IncentiveID"].ToString());
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

        protected void grdSGSTReimbursement_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                ddlFinYear.SelectedValue = ((Label)(gr.FindControl("lblEnergyFinancialYearID"))).Text;
                ddlFin1stOr2ndHalfyear.SelectedValue = ((Label)(gr.FindControl("lblTypeOfFinancialYear"))).Text;

                txtAmountPaid.Text = ((Label)(gr.FindControl("lblEnergyConsumedAmountPaid"))).Text;

                ViewState["Export_Intensive_Textile_ID"] = ((Label)(gr.FindControl("lblEnergyconsumedID"))).Text;
                btnSGSTReimbursementAdd.Text = "Update";
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


                string Validstatus = ObjCAFClass.InsertExportIntensiveTextileDetails(objEnergyConsumedBO);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnSGSTReimbursementAdd.Text = "Add New";
                    ViewState["Export_Intensive_Textile_ID"] = "0";

                    ddlFinYear.SelectedValue = "0";
                    ddlFin1stOr2ndHalfyear.SelectedValue = "0";
                    txtAmountPaid.Text = "";

                    BindExportIntensiveTextileDtls(Session["IncentiveID"].ToString());

                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }

        protected void BindExportIntensiveTextileDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetExportIntensiveTextileDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    grdSGSTReimbursement.DataSource = dsnew.Tables[0];
                    grdSGSTReimbursement.DataBind();
                }
                else
                {
                    grdSGSTReimbursement.DataSource = null;
                    grdSGSTReimbursement.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetExportIntensiveTextileDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_Export_Intensive_TextileDTLS", pp);
            return Dsnew;
        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        protected void btnStatementofrawmaterialspurchased_Click(object sender, EventArgs e)
        {
            if (fuStatementofrawmaterialspurchased.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuStatementofrawmaterialspurchased);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuStatementofrawmaterialspurchased);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuStatementofrawmaterialspurchased, hyStatementofrawmaterialspurchased, "Statementofrawmaterialspurchased", Session["IncentiveID"].ToString(), "9", "91001", Session["uid"].ToString(), "USER");

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
            else
            {
                MessageBox("Select File!");
            }
        }

        protected void btnutilizationRawMaterials_Click(object sender, EventArgs e)
        {
            if (fuutilizationRawMaterials.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuutilizationRawMaterials);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuutilizationRawMaterials);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuutilizationRawMaterials, hyutilizationRawMaterials, "UtilizationRawMaterials", Session["IncentiveID"].ToString(), "9", "91002", Session["uid"].ToString(), "USER");

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
            else
            {
                MessageBox("Select File!");

            }
        }

        protected void btnStatementFinishedProducts_Click(object sender, EventArgs e)
        {
            if (fuStatementFinishedProducts.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuStatementFinishedProducts);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuStatementFinishedProducts);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuStatementFinishedProducts, hyStatementFinishedProducts, "StatementFinishedProducts", Session["IncentiveID"].ToString(), "9", "91003", Session["uid"].ToString(), "USER");

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
            else
            {
                MessageBox("Select File!");

            }
        }

        protected void btnIECImportIndustrialInvoice_Click(object sender, EventArgs e)
        {
            if (fuIECImportIndustrialInvoice.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuIECImportIndustrialInvoice);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuIECImportIndustrialInvoice);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuIECImportIndustrialInvoice, hyIECImportIndustrialInvoice, "Detailedprojectreport", Session["IncentiveID"].ToString(), "9", "91004", Session["uid"].ToString(), "USER");

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
            else
            {
                MessageBox("Select File!");

            }
        }

        protected void btnRCvehiclestransportingrawmaterials_Click(object sender, EventArgs e)
        {
            if (fuRCvehiclestransportingrawmaterials.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuRCvehiclestransportingrawmaterials);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuRCvehiclestransportingrawmaterials);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuRCvehiclestransportingrawmaterials, hyRCvehiclestransportingrawmaterials, "RCvehiclestransportingrawmaterials", Session["IncentiveID"].ToString(), "9", "91005", Session["uid"].ToString(), "USER");

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
            else
            {
                MessageBox("Select File!");

            }
        }

        protected void btnTrucksTransportcompanies_Click(object sender, EventArgs e)
        {
            if (fuTrucksTransportcompanies.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuTrucksTransportcompanies);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuTrucksTransportcompanies);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuTrucksTransportcompanies, hyTrucksTransportcompanies, "TrucksTransportcompanies", Session["IncentiveID"].ToString(), "9", "91006", Session["uid"].ToString(), "USER");

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
            else
            {
                MessageBox("Select File!");

            }
        }

        protected void btnpaymentmadetoTransporters_Click(object sender, EventArgs e)
        {
            if (fupaymentmadetoTransporters.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fupaymentmadetoTransporters);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fupaymentmadetoTransporters);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fupaymentmadetoTransporters, hypaymentmadetoTransporters, "Detailedprojectreport", Session["IncentiveID"].ToString(), "9", "91007", Session["uid"].ToString(), "USER");

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
            else
            {
                MessageBox("Select File!");

            }
        }

        protected void btnBankACNoName_Click(object sender, EventArgs e)
        {
            if (fuBankACNoName.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuBankACNoName);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuBankACNoName);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuBankACNoName, hyBankACNoName, "BankACNoName", Session["IncentiveID"].ToString(), "9", "91008", Session["uid"].ToString(), "USER");

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
            else
            {
                MessageBox("Select File!");

            }
        }

        protected void btnBillsChallanconsignment_Click(object sender, EventArgs e)
        {
            if (fuBillsChallanconsignment.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuBillsChallanconsignment);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuBillsChallanconsignment);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuBillsChallanconsignment, hyBillsChallanconsignment, "BillsChallanconsignment", Session["IncentiveID"].ToString(), "9", "91009", Session["uid"].ToString(), "USER");

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
            else
            {
                MessageBox("Select File!");

            }
        }

        protected void btnRailwayfreightcertificate_Click(object sender, EventArgs e)
        {
            if (fuRailwayfreightcertificate.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuRailwayfreightcertificate);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuRailwayfreightcertificate);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuRailwayfreightcertificate, hyRailwayfreightcertificate, "Railwayfreightcertificate", Session["IncentiveID"].ToString(), "9", "91010", Session["uid"].ToString(), "USER");

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
            else
            {
                MessageBox("Select File!");

            }
        }

        protected void btnRoaddistancecertificate_Click(object sender, EventArgs e)
        {
            if (fuRoaddistancecertificate.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuRoaddistancecertificate);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuRoaddistancecertificate);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuRoaddistancecertificate, hyRoaddistancecertificate, "Roaddistancecertificate", Session["IncentiveID"].ToString(), "9", "91011", Session["uid"].ToString(), "USER");

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
            else
            {
                MessageBox("Select File!");

            }
        }

        protected void btnBankStatement_Click(object sender, EventArgs e)
        {
            if (fuBankStatement.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuBankStatement);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuBankStatement);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuBankStatement, hyBankStatement, "BankStatement", Session["IncentiveID"].ToString(), "9", "91012", Session["uid"].ToString(), "USER");

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
            else
            {
                MessageBox("Select File!");

            }
        }

        protected void btnBillsChallanconsignmentfinishedgoods_Click(object sender, EventArgs e)
        {
            if (fuBillsChallanconsignmentfinishedgoods.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuBillsChallanconsignmentfinishedgoods);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuBillsChallanconsignmentfinishedgoods);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuBillsChallanconsignmentfinishedgoods, hyBillsChallanconsignmentfinishedgoods, "BillsChallanconsignmentfinishedgoods", Session["IncentiveID"].ToString(), "9", "91013", Session["uid"].ToString(), "USER");

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
            else
            {
                MessageBox("Select File!");

            }
        }

        protected void btntransportersforcarryingFP_Click(object sender, EventArgs e)
        {
            if (futransportersforcarryingFP.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(futransportersforcarryingFP);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(futransportersforcarryingFP);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), futransportersforcarryingFP, hytransportersforcarryingFP, "transportersforcarryingFP", Session["IncentiveID"].ToString(), "9", "91014", Session["uid"].ToString(), "USER");

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
            else
            {
                MessageBox("Select File!");

            }
        }

        protected void btnCertificatefromExciseDept_Click(object sender, EventArgs e)
        {
            if (fuCertificatefromExciseDept.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuCertificatefromExciseDept);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuCertificatefromExciseDept);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuCertificatefromExciseDept, hyCertificatefromExciseDept, "CertificatefromExciseDept", Session["IncentiveID"].ToString(), "9", "91015", Session["uid"].ToString(), "USER");

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
            else
            {
                MessageBox("Select File!");

            }
        }

        protected void btnconsignmentsoldtotheparty_Click(object sender, EventArgs e)
        {
            if (fuconsignmentsoldtotheparty.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuconsignmentsoldtotheparty);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuconsignmentsoldtotheparty);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuconsignmentsoldtotheparty, hyconsignmentsoldtotheparty, "Consignmentsoldtotheparty", Session["IncentiveID"].ToString(), "9", "91016", Session["uid"].ToString(), "USER");

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
            else
            {
                MessageBox("Select File!");

            }
        }

        protected void btnaddressofpurchasers_Click(object sender, EventArgs e)
        {
            if (fuaddressofpurchasers.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuaddressofpurchasers);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                string Mimetype = objClsFileUpload.getmimetype(fuaddressofpurchasers);
                if (Mimetype == "application/pdf")
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuaddressofpurchasers, hyaddressofpurchasers, "addressofpurchasers", Session["IncentiveID"].ToString(), "9", "91017", Session["uid"].ToString(), "USER");

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
            else
            {
                MessageBox("Select File!");

            }
        }
        public string ExportRevenueValidateDtls()
        {
            int slno = 1;
            string ErrorMsg = "";


            if (ddlLast3Years.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Export Revenue Year \\n";
                slno = slno + 1;
            }

            if (txtProductionValue.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Production Value (in Rs.) \\n";
                slno = slno + 1;
            }
            if (txtSaleRevenue.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Sale Revenue (in Rs.) \\n";
                slno = slno + 1;
            }
            if (txtExportSalesValue.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Export Sales Value (in Rs.) \\n";
                slno = slno + 1;
            }
            if (txtFreightCharges.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Freight Charges (in Rs.) \\n";
                slno = slno + 1;
            }
            return ErrorMsg;
        }

        protected void btnExportRevenueAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["ExportRevenueID"] == null)
                {
                    ViewState["ExportRevenueID"] = "0";
                }

                string errormsg = ExportRevenueValidateDtls();
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

                    ExportRevenueBO objExportRevenueBO = new ExportRevenueBO();

                    objExportRevenueBO.ExportRevenueID = ViewState["ExportRevenueID"].ToString();
                    objExportRevenueBO.TransType = "INS";
                    objExportRevenueBO.IncentiveId = Session["IncentiveID"].ToString();
                    objExportRevenueBO.Created_by = ObjLoginNewvo.uid;

                    objExportRevenueBO.FinancialYear = ddlLast3Years.SelectedValue;
                    objExportRevenueBO.FinancialYearText = ddlLast3Years.SelectedItem.Text;

                    objExportRevenueBO.ProductionValue = GetDecimalNullValue(txtProductionValue.Text.Trim().TrimStart());
                    objExportRevenueBO.SaleRevenue = GetDecimalNullValue(txtSaleRevenue.Text.Trim().TrimStart());
                    objExportRevenueBO.ExportSalesValue = GetDecimalNullValue(txtExportSalesValue.Text.Trim().TrimStart());
                    objExportRevenueBO.FreightCharges = GetDecimalNullValue(txtFreightCharges.Text.Trim().TrimStart());

                    string Validstatus = ObjCAFClass.InsertExportRevenueTransportSubsidy(objExportRevenueBO);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        btnExportRevenueAdd.Text = "Add New";
                        ViewState["ExportRevenueID"] = "0";

                        ddlLast3Years.SelectedValue = "0";
                        txtProductionValue.Text = "0";
                        txtSaleRevenue.Text = "0";
                        txtExportSalesValue.Text = "0";
                        txtFreightCharges.Text = "0";

                        BindExportRevenueDtls(Session["IncentiveID"].ToString());
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
        protected void gvExportRevenueDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                ddlLast3Years.SelectedValue = ((Label)(gr.FindControl("lblExportRevenueYear"))).Text;
                txtProductionValue.Text = ((Label)(gr.FindControl("lblProductionValue"))).Text;
                txtSaleRevenue.Text = ((Label)(gr.FindControl("lblSaleRevenue"))).Text;
                txtExportSalesValue.Text = ((Label)(gr.FindControl("lblExportSalesValue"))).Text;
                txtFreightCharges.Text = ((Label)(gr.FindControl("lblFreightCharges"))).Text;

                ViewState["ExportRevenueID"] = ((Label)(gr.FindControl("lblExportRevenueID"))).Text;
                btnExportRevenueAdd.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];


                ExportRevenueBO objExportRevenueBO = new ExportRevenueBO();

                objExportRevenueBO.ExportRevenueID = ((Label)(gr.FindControl("lblExportRevenueID"))).Text;
                objExportRevenueBO.TransType = "DLT";
                objExportRevenueBO.IncentiveId = Session["IncentiveID"].ToString();
                objExportRevenueBO.Created_by = ObjLoginNewvo.uid;


                string Validstatus = ObjCAFClass.InsertExportRevenueTransportSubsidy(objExportRevenueBO);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnExportRevenueAdd.Text = "Add New";
                    ViewState["ExportRevenueID"] = "0";

                    ddlLast3Years.SelectedValue = "0";
                    txtProductionValue.Text = "0";
                    txtSaleRevenue.Text = "0";
                    txtExportSalesValue.Text = "0";
                    txtFreightCharges.Text = "0";

                    BindExportRevenueDtls(Session["IncentiveID"].ToString());

                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }
        protected void BindExportRevenueDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetExportRevenueDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    gvExportRevenueDetails.DataSource = dsnew.Tables[0];
                    gvExportRevenueDetails.DataBind();
                }
                else
                {
                    gvExportRevenueDetails.DataSource = null;
                    gvExportRevenueDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetExportRevenueDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GEt_ExportRevenueDTLS", pp);
            return Dsnew;
        }

        public string CurrentClaimFinancialCheck()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (ddlCurrentClaimFinancialYear.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Current Financial Year \\n";
                slno = slno + 1;
            }
            if (ddlCurrentClaimhalfYear.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Current 1st/2nd Half Year \\n";
                slno = slno + 1;
            }
            if (ddlCurrentClaimmadeYear.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Claim made for the Year \\n";
                slno = slno + 1;
            }
            if (txtCurrentTotalproduction.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Total Production (in Rs.) \\n";
                slno = slno + 1;
            }
            if (txtCurrentTotalSaleRevenue.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Total Sale Revenue (in Rs.) \\n";
                slno = slno + 1;
            }
            if (txtCurrentTotalExportRevenue.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Total Export Revenue (in Rs.) \\n";
                slno = slno + 1;
            }
            if (txtCurrentFreightPurchaseRawMaterial.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Freight Charges on Purchase of Raw Material (in Rs.) \\n";
                slno = slno + 1;
            }
            if (txtCurrentFreightExportFinishedGoods.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Freight Charges on Export of Finished Goods (in Rs.) \\n";
                slno = slno + 1;
            }
            return ErrorMsg;
        }
        protected void btnCurrentClaimadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["CurrentClaimFinancialID"] == null)
                {
                    ViewState["CurrentClaimFinancialID"] = "0";
                }

                string errormsg = CurrentClaimFinancialCheck();
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

                    CurrentClaimFinancialBo objCurrentClaimFinancialBo = new CurrentClaimFinancialBo();

                    objCurrentClaimFinancialBo.CurrentClaimFinancialID = ViewState["CurrentClaimFinancialID"].ToString();
                    objCurrentClaimFinancialBo.TransType = "INS";
                    objCurrentClaimFinancialBo.IncentiveId = Session["IncentiveID"].ToString();
                    objCurrentClaimFinancialBo.Created_by = ObjLoginNewvo.uid;

                    objCurrentClaimFinancialBo.FinancialYear = ddlCurrentClaimFinancialYear.SelectedValue;
                    objCurrentClaimFinancialBo.FinancialYearText = ddlCurrentClaimFinancialYear.SelectedItem.Text;

                    objCurrentClaimFinancialBo.TypeOfFinancialYear = ddlCurrentClaimhalfYear.SelectedValue;
                    objCurrentClaimFinancialBo.TypeOfFinancialYearText = ddlCurrentClaimhalfYear.SelectedItem.Text;

                    objCurrentClaimFinancialBo.CurrentClaimmadeYear = ddlCurrentClaimmadeYear.SelectedValue;
                    objCurrentClaimFinancialBo.CurrentClaimmadeYearText = ddlCurrentClaimmadeYear.SelectedItem.Text;

                    objCurrentClaimFinancialBo.Totalproduction = GetDecimalNullValue(txtCurrentTotalproduction.Text.Trim().TrimStart());
                    objCurrentClaimFinancialBo.TotalSaleRevenue = GetDecimalNullValue(txtCurrentTotalSaleRevenue.Text.Trim().TrimStart());
                    objCurrentClaimFinancialBo.TotalExportRevenue = GetDecimalNullValue(txtCurrentTotalExportRevenue.Text.Trim().TrimStart());
                    objCurrentClaimFinancialBo.FreightPurchaseRawMaterial = GetDecimalNullValue(txtCurrentFreightPurchaseRawMaterial.Text.Trim().TrimStart());
                    objCurrentClaimFinancialBo.FreightExportFinishedGoods = GetDecimalNullValue(txtCurrentFreightExportFinishedGoods.Text.Trim().TrimStart());

                    string Validstatus = ObjCAFClass.InsertCurrentFinancialYearTransportSubsidy(objCurrentClaimFinancialBo);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        btnCurrentClaimadd.Text = "Add New";
                        ViewState["CurrentClaimFinancialID"] = "0";

                        ddlCurrentClaimFinancialYear.SelectedValue = "0";
                        ddlCurrentClaimhalfYear.SelectedValue = "0";
                        ddlCurrentClaimmadeYear.SelectedValue = "0";

                        txtCurrentTotalproduction.Text = "0";
                        txtCurrentTotalSaleRevenue.Text = "0";
                        txtCurrentTotalExportRevenue.Text = "0";
                        txtCurrentFreightPurchaseRawMaterial.Text = "0";
                        txtCurrentFreightExportFinishedGoods.Text = "0";

                        BindCurrentClaimDtls(Session["IncentiveID"].ToString());
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

        protected void GvCurrentClaimPeriod_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                ddlCurrentClaimFinancialYear.SelectedValue = ((Label)(gr.FindControl("lblCurrentFinancialYearID"))).Text;
                ddlCurrentClaimhalfYear.SelectedValue = ((Label)(gr.FindControl("lblCurrentTypeOfFinancialYear"))).Text;
                ddlCurrentClaimmadeYear.SelectedValue = ((Label)(gr.FindControl("lblClaimMadefortheYearID"))).Text;
                txtCurrentTotalproduction.Text = ((Label)(gr.FindControl("lblTotalProductionValue"))).Text;
                txtCurrentTotalSaleRevenue.Text = ((Label)(gr.FindControl("lblTotalSaleRevenue"))).Text;
                txtCurrentTotalExportRevenue.Text = ((Label)(gr.FindControl("lblTotalExportRevenue"))).Text;
                txtCurrentFreightPurchaseRawMaterial.Text = ((Label)(gr.FindControl("lblFreightPurchaseRawMaterial"))).Text;
                txtCurrentFreightExportFinishedGoods.Text = ((Label)(gr.FindControl("lblFreightChargesFinishedGoods"))).Text;

                ViewState["CurrentClaimFinancialID"] = ((Label)(gr.FindControl("lblCurrentClaimFinanciaID"))).Text;
                btnCurrentClaimadd.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];


                CurrentClaimFinancialBo objCurrentClaimFinancialBo = new CurrentClaimFinancialBo();

                objCurrentClaimFinancialBo.CurrentClaimFinancialID = ((Label)(gr.FindControl("lblCurrentClaimFinanciaID"))).Text;
                objCurrentClaimFinancialBo.TransType = "DLT";
                objCurrentClaimFinancialBo.IncentiveId = Session["IncentiveID"].ToString();
                objCurrentClaimFinancialBo.Created_by = ObjLoginNewvo.uid;


                string Validstatus = ObjCAFClass.InsertCurrentFinancialYearTransportSubsidy(objCurrentClaimFinancialBo);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnCurrentClaimadd.Text = "Add New";
                    ViewState["CurrentClaimFinancialID"] = "0";

                    ddlCurrentClaimFinancialYear.SelectedValue = "0";
                    ddlCurrentClaimhalfYear.SelectedValue = "0";
                    ddlCurrentClaimmadeYear.SelectedValue = "0";

                    txtCurrentTotalproduction.Text = "0";
                    txtCurrentTotalSaleRevenue.Text = "0";
                    txtCurrentTotalExportRevenue.Text = "0";
                    txtCurrentFreightPurchaseRawMaterial.Text = "0";
                    txtCurrentFreightExportFinishedGoods.Text = "0";

                    BindCurrentClaimDtls(Session["IncentiveID"].ToString());
                    lblmsg.Text = "Saved Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }

        protected void BindCurrentClaimDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetCurrentClaimDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    GvCurrentClaimPeriod.DataSource = dsnew.Tables[0];
                    GvCurrentClaimPeriod.DataBind();
                }
                else
                {
                    GvCurrentClaimPeriod.DataSource = null;
                    GvCurrentClaimPeriod.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetCurrentClaimDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_CURRENTFINANCIALCLAIMDTLS", pp);
            return Dsnew;
        }
    }
}