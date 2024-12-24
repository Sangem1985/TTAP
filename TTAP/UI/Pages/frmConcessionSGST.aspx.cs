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
    public partial class frmConcessionSGST : System.Web.UI.Page
    {
        General Gen = new General();
        //static DataTable dtMyTableCertificate2;
        //static DataTable dtMyTableCertificate4;

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
                            DataRow[] drs = ds.Tables[0].Select("IncentiveID = " + 6);
                            if (drs.Length > 0)
                            {
                                //DataSet dsnew = new DataSet();
                                //dsnew =
                                BindUnitMasterData();
                                BindFinancialYears(ddlFinYear, "7", Session["IncentiveID"].ToString());
                                GetConcessionSGSTDetails(userid, IncentveID);
                                BindSGSTReimbursementAvailedDtls(Session["IncentiveID"].ToString());
                                BindSGSTSaleDtls(Session["IncentiveID"].ToString());
                                //dsnew = Gen.GetIncentivesISdata(IncentveID, "6");
                                //Filldata(dsnew);
                            }
                            else
                            {
                                if (Request.QueryString[0].ToString() == "N")
                                {
                                    Response.Redirect("frmAssistanceEnergy.aspx?next=" + "N");
                                }
                                else
                                {
                                    Response.Redirect("frmStampDuty.aspx?Previous=" + "P");
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

        public string GeneralInformationcheck()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (txtGSTIdentificationNumber.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter GST Identification Number \\n";
                slno = slno + 1;
            }
            if (txtDateofEstablishmentofUnit.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Date Of Incorporation of Unit \\n";
                slno = slno + 1;
            }
            if (txtInstalledcapacity.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Installed Capacity of the existing Enterprise as certified by the financial institution/ chartered accountant\\n";
                slno = slno + 1;
            }

            if (txtYear1.Text.TrimStart().Trim() == "" || txtYear2.Text.TrimStart().Trim() == "" || txtYear3.Text.TrimStart().Trim() == "" ||
                txtEnterprises1.Text.TrimStart().Trim() == "" || txtEnterprises2.Text.TrimStart().Trim() == "" || txtEnterprises3.Text.TrimStart().Trim() == "" ||
                txtTotalProduction1.Text.TrimStart().Trim() == "" || txtTotalProduction2.Text.TrimStart().Trim() == "" || txtTotalProduction3.Text.TrimStart().Trim() == "" ||
                txtTaxPaid1.Text.TrimStart().Trim() == "" || txtTaxPaid2.Text.TrimStart().Trim() == "" || txtTaxPaid3.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Production & Sales details preceding three years before expansion / diversification project as certified by the financial institution/ chartered accountant  \\n";
                slno = slno + 1;
            }

            if (txtTaxpaid.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Tax paid by the Enterprise during the 1st Half Year/2nd half year as certified by the Commercial Tax Department (In Rs)  \\n";
                slno = slno + 1;
            }
            if (txtCurrentClaim.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Current Claim Amount \\n";
                slno = slno + 1;
            }

            if (gvsalesDetails.Rows.Count < 1)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Add Product Sale(s) Details \\n";
                slno = slno + 1;
            }

            return ErrorMsg;
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
                string errormsgAttach = ObjCAFClass.ValidateMandatoryAttachments(Session["IncentiveID"].ToString(), "6");
                if (errormsgAttach.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsgAttach + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                ConcessionSGST objConcessionSGST = new ConcessionSGST();

                objConcessionSGST.IncentiveId = Session["IncentiveID"].ToString();
                objConcessionSGST.CreatedBy = ObjLoginNewvo.uid;

                objConcessionSGST.GSTIdentificationNumber = txtGSTIdentificationNumber.Text.Trim().TrimStart();

                string[] Ld6 = null;
                string ConvertedDt56 = "";

                Ld6 = null;
                ConvertedDt56 = "";

                if (txtDateofEstablishmentofUnit.Text.Trim().TrimStart() != "")
                {
                    Ld6 = txtDateofEstablishmentofUnit.Text.Trim().TrimStart().Split('/');
                    ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();
                    objConcessionSGST.DateofEstablishmentofUnit = ConvertedDt56;
                }
                else
                {
                    objConcessionSGST.DateofEstablishmentofUnit = null;
                }


                objConcessionSGST.Installedcapacity = txtInstalledcapacity.Text.Trim().TrimStart();
                objConcessionSGST.Year1 = txtYear1.Text.Trim().TrimStart();
                objConcessionSGST.Enterprises1 = txtEnterprises1.Text.Trim().TrimStart();
                objConcessionSGST.TotalProduction1 = txtTotalProduction1.Text.Trim().TrimStart();
                objConcessionSGST.TaxPaid1 = txtTaxPaid1.Text.Trim().TrimStart();

                objConcessionSGST.Year2 = txtYear2.Text.Trim().TrimStart();
                objConcessionSGST.Enterprises2 = txtEnterprises2.Text.Trim().TrimStart();
                objConcessionSGST.TotalProduction2 = txtTotalProduction2.Text.Trim().TrimStart();
                objConcessionSGST.TaxPaid2 = txtTaxPaid2.Text.Trim().TrimStart();

                objConcessionSGST.Year3 = txtYear3.Text.Trim().TrimStart();
                objConcessionSGST.Enterprises3 = txtEnterprises3.Text.Trim().TrimStart();
                objConcessionSGST.TotalProduction3 = txtTotalProduction3.Text.Trim().TrimStart();
                objConcessionSGST.TaxPaid3 = txtTaxPaid3.Text.Trim().TrimStart();

                objConcessionSGST.ClaimApplicationsubmitted = txtClaimApplicationsubmitted.Text.Trim().TrimStart();
                objConcessionSGST.Taxpaid = GetDecimalNullValue(txtTaxpaid.Text.Trim().TrimStart());
                objConcessionSGST.CurrentClaimAmountRs = GetDecimalNullValue(txtCurrentClaim.Text.Trim().TrimStart());

                objConcessionSGST.MoratoriumFrom = GetFromatedDateDDMMYYYY(txtMoratoriumFrom.Text.Trim().TrimStart());
                objConcessionSGST.MoratoriumTo = GetFromatedDateDDMMYYYY(txtMoratoriumTo.Text.Trim().TrimStart());
                objConcessionSGST.MoratoriumInvestmentAmount = GetDecimalNullValue(txtMoratoriumInvestmentAmount.Text.Trim().TrimStart());

                string Validstatus = ObjCAFClass.InsertingOfConcessiononSGSTDtls(objConcessionSGST);

                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    Response.Redirect("frmAssistanceEnergy.aspx?next=" + "N");
                }
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
        public string GetDecimalNullValue(string Input)
        {
            string InputValue = "";

            InputValue = (Input != "") ? Input : "0";

            return InputValue;
        }
        protected void btnclear_Click(object sender, EventArgs e)
        {

        }

        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmStampDuty.aspx?Previous=" + "P");
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
        public void GetConcessionSGSTDetails(string uid, string IncentiveID)
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
                    txtGSTIdentificationNumber.Text = dsnew.Tables[0].Rows[0]["TinNO"].ToString();

                    if (txtGSTIdentificationNumber.Text != "")
                    {
                        txtGSTIdentificationNumber.Enabled = false;
                    }

                    txtDateofEstablishmentofUnit.Text = dsnew.Tables[0].Rows[0]["DateOfIncorporation"].ToString();
                    if (txtDateofEstablishmentofUnit.Text != "")
                    {
                        txtDateofEstablishmentofUnit.Enabled = false;
                    }

                    string TypeOfIndustry = dsnew.Tables[0].Rows[0]["TypeOfIndustry"].ToString();
                    if (TypeOfIndustry == "1")
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCP"].ToString();
                        GetFinancialYears(GetFromatedDateDDMMYYYY(dsnew.Tables[0].Rows[0]["DCP"].ToString()));
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
                        GetFinancialYears(GetFromatedDateDDMMYYYY(dsnew.Tables[0].Rows[0]["DCPExp"].ToString()));

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

                    lblApprovedProjectCostLand.Text = dsnew.Tables[0].Rows[0]["LandAssetsValuebyCA"].ToString();
                    lblApprovedProjectCostBuilding.Text = dsnew.Tables[0].Rows[0]["BuildingAssetsValuebyCA"].ToString();
                    lblApprovedProjectCostPlantMachinery.Text = dsnew.Tables[0].Rows[0]["PlantMachineryAssetsValuebyCA"].ToString();

                    CalculatationEnterprise1("1");
                    CalculatationEnterprise1("2");
                    CalculatationEnterprise1("3");
                    CalculatationEnterprise1("4");

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

                            DivSalesDetails.Visible = false;
                            gvsalesDetails.Columns[7].Visible = false;
                            gvsalesDetails.Columns[6].Visible = false;

                            btnSaleInvoice.Enabled = false;
                            btnconcernedCTo.Enabled = false;
                            btnproductionParticulars.Enabled = false;
                            btnTSPCBOperation.Enabled = false;
                            btnFormACommercialTaxDept.Enabled = false;
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
                ds = Gen.GenericFillDs("USP_GET_ConcessionSGST_DTLS", p);
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.ToString() != "" && ds.Tables[0].Rows.ToString() != null)
                {

                    txtTaxpaid.Text = ds.Tables[0].Rows[0]["Taxpaid"].ToString();

                    txtGSTIdentificationNumber.Text = ds.Tables[0].Rows[0]["GSTIdentificationNumber"].ToString();
                    txtDateofEstablishmentofUnit.Text = ds.Tables[0].Rows[0]["DateofEstablishmentofUnit"].ToString();

                    txtInstalledcapacity.Text = ds.Tables[0].Rows[0]["Installedcapacity"].ToString();
                    if (txtYear1.Text.Trim().TrimStart() != "")
                    {
                        txtYear1.Text = ds.Tables[0].Rows[0]["Year1"].ToString();
                    }

                    txtEnterprises1.Text = ds.Tables[0].Rows[0]["Enterprises1"].ToString();
                    txtTotalProduction1.Text = ds.Tables[0].Rows[0]["TotalProduction1"].ToString();
                    if (txtYear2.Text.Trim().TrimStart() != "")
                    {
                        txtYear2.Text = ds.Tables[0].Rows[0]["Year2"].ToString();
                    }
                        
                    txtEnterprises2.Text = ds.Tables[0].Rows[0]["Enterprises2"].ToString();
                    txtTotalProduction2.Text = ds.Tables[0].Rows[0]["TotalProduction2"].ToString();
                    if (txtYear3.Text.Trim().TrimStart() != "")
                    {
                        txtYear3.Text = ds.Tables[0].Rows[0]["Year3"].ToString();
                    }
                        
                    txtEnterprises3.Text = ds.Tables[0].Rows[0]["Enterprises3"].ToString();
                    txtTotalProduction3.Text = ds.Tables[0].Rows[0]["TotalProduction3"].ToString();
                    txtClaimApplicationsubmitted.Text = ds.Tables[0].Rows[0]["ClaimApplicationsubmitted"].ToString();
                    txtTaxpaid.Text = ds.Tables[0].Rows[0]["Taxpaid"].ToString();
                    txtCurrentClaim.Text = ds.Tables[0].Rows[0]["CurrentClaimAmountRs"].ToString();

                    txtMoratoriumFrom.Text = ds.Tables[0].Rows[0]["MoratoriumFrom"].ToString();
                    txtMoratoriumTo.Text = ds.Tables[0].Rows[0]["MoratoriumTo"].ToString();
                    txtMoratoriumInvestmentAmount.Text = ds.Tables[0].Rows[0]["MoratoriumInvestmentAmount"].ToString();

                    txtTaxPaid1.Text = ds.Tables[0].Rows[0]["TaxPaid1"].ToString();
                    txtTaxPaid2.Text = ds.Tables[0].Rows[0]["TaxPaid2"].ToString();
                    txtTaxPaid3.Text = ds.Tables[0].Rows[0]["TaxPaid3"].ToString();
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
                                if (Docid == "61001")
                                {
                                    objClsFileUpload.AssignPath(hySaleInvoice, Path);
                                }
                                else if (Docid == "61002")
                                {
                                    objClsFileUpload.AssignPath(hypconcernedCTo, Path);
                                }
                                else if (Docid == "61003")
                                {
                                    objClsFileUpload.AssignPath(hyroductionParticulars, Path);
                                }
                                else if (Docid == "61004")
                                {
                                    objClsFileUpload.AssignPath(hyTSPCBOperation, Path);
                                }
                                else if (Docid == "61005")
                                {
                                    objClsFileUpload.AssignPath(hyFormACommercialTaxDept, Path);
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

            //return ds;
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
                else if (Step == "4")
                {
                    lblApprovedProjectCostTotal.Text = (Convert.ToDecimal(GetDecimalNullValue(lblApprovedProjectCostLand.Text)) +
                                                        Convert.ToDecimal(GetDecimalNullValue(lblApprovedProjectCostBuilding.Text)) +
                                                        Convert.ToDecimal(GetDecimalNullValue(lblApprovedProjectCostPlantMachinery.Text))).ToString();
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
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
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuSaleInvoice, hySaleInvoice, "FirstSaleInvoice", Session["IncentiveID"].ToString(), "6", "61001", Session["uid"].ToString(), "USER");

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

        protected void btnconcernedCTo_Click(object sender, EventArgs e)
        {
            if (fuconcernedCTo.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuconcernedCTo);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuconcernedCTo);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuconcernedCTo, hypconcernedCTo, "CertificatefromconcernedCTOFormNoA", Session["IncentiveID"].ToString(), "6", "61002", Session["uid"].ToString(), "USER");

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

        protected void btnproductionParticulars_Click(object sender, EventArgs e)
        {

            if (fuProductionParticulars.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuProductionParticulars);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuProductionParticulars);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuProductionParticulars, hyroductionParticulars, "ProductionParticularslast3years", Session["IncentiveID"].ToString(), "6", "61003", Session["uid"].ToString(), "USER");

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

        protected void btnTSPCBOperation_Click(object sender, EventArgs e)
        {
            if (fuTSPCBOperation.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuTSPCBOperation);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuTSPCBOperation);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuTSPCBOperation, hyTSPCBOperation, "CFOfromSPCBAcknowledgement", Session["IncentiveID"].ToString(), "6", "61004", Session["uid"].ToString(), "USER");

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
                if (ViewState["SGSTReimbursement_ID"] == null)
                {
                    ViewState["SGSTReimbursement_ID"] = "0";
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

                    objEnergyConsumedBO.EnergyConsumed_ID = ViewState["SGSTReimbursement_ID"].ToString();
                    objEnergyConsumedBO.TransType = "INS";
                    objEnergyConsumedBO.IncentiveId = Session["IncentiveID"].ToString();
                    objEnergyConsumedBO.Created_by = ObjLoginNewvo.uid;

                    objEnergyConsumedBO.FinancialYear = ddlFinYear.SelectedValue;
                    objEnergyConsumedBO.FinancialYearText = ddlFinYear.SelectedItem.Text;

                    objEnergyConsumedBO.TypeOfFinancialYear = ddlFin1stOr2ndHalfyear.SelectedValue;
                    objEnergyConsumedBO.TypeOfFinancialYearText = ddlFin1stOr2ndHalfyear.SelectedItem.Text;

                    objEnergyConsumedBO.TotalAmount = (txtAmountPaid.Text.Trim().TrimStart() != "") ? txtAmountPaid.Text.Trim().TrimStart() : null;

                    string Validstatus = ObjCAFClass.InsertConcessiononSGSTDetails(objEnergyConsumedBO);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        btnSGSTReimbursementAdd.Text = "Add New";
                        ViewState["SGSTReimbursement_ID"] = "0";

                        ddlFinYear.SelectedValue = "0";
                        ddlFin1stOr2ndHalfyear.SelectedValue = "0";
                        txtAmountPaid.Text = "";

                        BindSGSTReimbursementAvailedDtls(Session["IncentiveID"].ToString());
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

                ViewState["SGSTReimbursement_ID"] = ((Label)(gr.FindControl("lblEnergyconsumedID"))).Text;
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


                string Validstatus = ObjCAFClass.InsertConcessiononSGSTDetails(objEnergyConsumedBO);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnSGSTReimbursementAdd.Text = "Add New";
                    ViewState["SGSTReimbursement_ID"] = "0";

                    ddlFinYear.SelectedValue = "0";
                    ddlFin1stOr2ndHalfyear.SelectedValue = "0";
                    txtAmountPaid.Text = "";

                    BindSGSTReimbursementAvailedDtls(Session["IncentiveID"].ToString());

                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }

        protected void BindSGSTReimbursementAvailedDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetSGSTReimbursementAvailedDtls(INCENTIVEID);

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

        public DataSet GetSGSTReimbursementAvailedDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_SGST_Reimbursement_AvailedDTLS", pp);
            return Dsnew;
        }

        protected void btnFormACommercialTaxDept_Click(object sender, EventArgs e)
        {
            if (fuFormACommercialTaxDept.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuFormACommercialTaxDept);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuFormACommercialTaxDept);
                if (Mimetype == "application/pdf")
                {
                    //string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuLandregistration, hyLandregistration, "DulyFilledApplicationForm", Session["IncentiveID"].ToString(), "2", "21001", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuFormACommercialTaxDept, hyFormACommercialTaxDept, "FormACommercialTaxDept", Session["IncentiveID"].ToString(), "6", "61005", Session["uid"].ToString(), "USER");

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

        public void BindUnitMasterData()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = ObjCAFClass.GenericFillDs("USP_INCENTIVE_UNIT_MASTER");
            if (Dsnew != null && Dsnew.Tables.Count > 0 && Dsnew.Tables[0].Rows.Count > 0)
            {
                ddlSaleUnit.DataSource = Dsnew.Tables[0];
                ddlSaleUnit.DataTextField = "Unit";
                ddlSaleUnit.DataValueField = "UnitID";
                ddlSaleUnit.DataBind();
            }
            AddSelect(ddlSaleUnit);
        }

        public string ValidateSaleDtls()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (txtSaleYear.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Year Of The Sale of Product \\n";
                slno = slno + 1;
            }
            if (txtNameoftheproduct.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Name of the product \\n";
                slno = slno + 1;
            }
            if (txtSaleQuantity.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter The Qunatity of Saled product \\n";
                slno = slno + 1;
            }
            if (ddlSaleUnit.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select The Unit of of Saled product \\n";
                slno = slno + 1;
            }
            if (txtTotalSaleValue.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Total Value Of Saled product (In Rupees) \\n";
                slno = slno + 1;
            }

            return ErrorMsg;
        }
        protected void btnSGSTSalesAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["SaleID"] == null)
                {
                    ViewState["SaleID"] = "0";
                }

                string errormsg = ValidateSaleDtls();
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

                    ProductSaleDetailsBO objProductSaleDetailsBO = new ProductSaleDetailsBO();

                    objProductSaleDetailsBO.SaleID = ViewState["SaleID"].ToString();
                    objProductSaleDetailsBO.TransType = "INS";
                    objProductSaleDetailsBO.IncentiveId = Session["IncentiveID"].ToString();
                    objProductSaleDetailsBO.Created_by = ObjLoginNewvo.uid;

                    objProductSaleDetailsBO.SaleYear = txtSaleYear.Text.Trim().TrimStart().TrimEnd();
                    objProductSaleDetailsBO.NameoftheProduct = txtNameoftheproduct.Text.Trim().TrimStart();
                    objProductSaleDetailsBO.SaleQuantity = GetDecimalNullValue(txtSaleQuantity.Text.Trim().TrimStart());
                    objProductSaleDetailsBO.SaleUnit = ddlSaleUnit.SelectedValue;
                    objProductSaleDetailsBO.TotalSaleValue = GetDecimalNullValue(txtTotalSaleValue.Text.Trim().TrimStart());

                    string Validstatus = ObjCAFClass.InsertSGSTSaleDetails(objProductSaleDetailsBO);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        btnSGSTSalesAdd.Text = "Add New";
                        ViewState["SaleID"] = "0";

                        ddlSaleUnit.SelectedValue = "0";
                        txtSaleYear.Text = "";
                        txtNameoftheproduct.Text = "";
                        txtSaleQuantity.Text = "";
                        txtTotalSaleValue.Text = "";

                        BindSGSTSaleDtls(Session["IncentiveID"].ToString());
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

        protected void BindSGSTSaleDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetSGSTSaleDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    gvsalesDetails.DataSource = dsnew.Tables[0];
                    gvsalesDetails.DataBind();
                }
                else
                {
                    gvsalesDetails.DataSource = null;
                    gvsalesDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetSGSTSaleDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_SALE_DTLS", pp);
            return Dsnew;
        }

        protected void gvsalesDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                ddlSaleUnit.SelectedValue = ((Label)(gr.FindControl("lblSaleUnit"))).Text;

                txtSaleYear.Text = ((Label)(gr.FindControl("lblSaleYear"))).Text;
                txtNameoftheproduct.Text = ((Label)(gr.FindControl("lblNameoftheproduct"))).Text;
                txtSaleQuantity.Text = ((Label)(gr.FindControl("lblSaleQuantity"))).Text;
                txtTotalSaleValue.Text = ((Label)(gr.FindControl("lblTotalSaleValue"))).Text;

                ViewState["SaleID"] = ((Label)(gr.FindControl("lblSaleID"))).Text;
                btnSGSTSalesAdd.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];


                ProductSaleDetailsBO objProductSaleDetailsBO = new ProductSaleDetailsBO();

                objProductSaleDetailsBO.SaleID = ((Label)(gr.FindControl("lblSaleID"))).Text;
                objProductSaleDetailsBO.TransType = "DLT";
                objProductSaleDetailsBO.IncentiveId = Session["IncentiveID"].ToString();
                objProductSaleDetailsBO.Created_by = ObjLoginNewvo.uid;


                string Validstatus = ObjCAFClass.InsertSGSTSaleDetails(objProductSaleDetailsBO);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnSGSTSalesAdd.Text = "Add New";
                    ViewState["SaleID"] = "0";

                    ddlSaleUnit.SelectedValue = "0";
                    txtSaleYear.Text = "";
                    txtNameoftheproduct.Text = "";
                    txtSaleQuantity.Text = "";
                    txtTotalSaleValue.Text = "";

                    BindSGSTSaleDtls(Session["IncentiveID"].ToString());

                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }

        public void GetFinancialYears(string Date)
        {
            DataSet dsFinancialYears = new DataSet();
            dsFinancialYears = ObjCAFClass.GetFinancialYears(Date);

            if (dsFinancialYears != null && dsFinancialYears.Tables.Count > 0 && dsFinancialYears.Tables[0].Rows.Count > 2)
            {
                txtYear1.Text = dsFinancialYears.Tables[0].Rows[0]["FinancialYear"].ToString();
                txtYear2.Text = dsFinancialYears.Tables[0].Rows[1]["FinancialYear"].ToString();
                txtYear3.Text = dsFinancialYears.Tables[0].Rows[2]["FinancialYear"].ToString();

                txtYear1.Enabled = false;
                txtYear2.Enabled = false;
                txtYear3.Enabled = false;
            }
        }
    }
}