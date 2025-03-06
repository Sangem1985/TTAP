using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TTAP.Classfiles;
using System.Net;

namespace TTAP.UI.Pages
{
    public partial class frmNewIncentive : System.Web.UI.Page
    {
        Fetch objFetch = new Fetch();
        General Objgeneral = new General();
        CAFClass ObjCAFClass = new CAFClass();
        comFunctions cmf = new comFunctions();
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        ClsSMSandMail ClsSMSandMailobj = new ClsSMSandMail();
        string UID = "";
        string UnitEditAllow = "N";
        string CheckEdit = "N";
        string SessionIncentiveId = "0";
        string CheckEligibility = "N";
        string IsFirstTime = "N";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                Page.Form.Enctype = "multipart/form-data";
                //return;
                if (Request.QueryString.Count > 0 && Request.QueryString["IsAllowModify"] != null && Request.QueryString["IsAllowModify"].ToString() != "")
                {
                    UnitEditAllow = "Y";

                    irm1.Attributes.Add("src", "frmLandBuildingPMDetails.aspx?IsAllowEdit=Y");
                }
                else
                {
                    UnitEditAllow = "N";
                }
                if (Session["ObjLoginvo"] != null)
                {
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                    UID = ObjLoginNewvo.uid;
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


                    txtadhar1.Attributes.Add("onKeyPress", "javascript:return ValidateNumberWithoutSpaceAdhar(event);");
                    txtadhar2.Attributes.Add("onKeyPress", "javascript:return ValidateNumberWithoutSpaceAdhar(event);");
                    txtadhar3.Attributes.Add("onKeyPress", "javascript:return ValidateNumberWithoutSpaceAdhar(event);");

                    txtadhar1.Attributes.Add("onKeyUp", "javascript:return Adharcontrol(event,this,'" + txtadhar1.ClientID + "','" + txtadhar2.ClientID + "','" + txtadhar3.ClientID + "');");
                    txtadhar2.Attributes.Add("onKeyUp", "javascript:return Adharcontrol(event,this,'" + txtadhar1.ClientID + "','" + txtadhar2.ClientID + "','" + txtadhar3.ClientID + "');");

                    txtadhar3.Attributes.Add("onblur", "javascript:return validateVerhoeff();");



                    if (ObjLoginNewvo.userlevel == "13")
                    {
                        anchbreadgrrom.HRef = "~/UI/UserDashBoard.aspx";
                    }
                    string IncentiveId = "";

                    AnchTab1.ServerClick += new EventHandler(AnchTab1_Click);
                    AnchTab2.ServerClick += new EventHandler(AnchTab2_Click);
                    AnchTab3.ServerClick += new EventHandler(AnchTab3_Click);
                    AnchTab4.ServerClick += new EventHandler(AnchTab4_Click);
                    AnchTab5.ServerClick += new EventHandler(AnchTab5_Click);
                    AnchTab6.ServerClick += new EventHandler(AnchTab6_Click);


                    AnchTab1.HRef = "";
                    AnchTab2.HRef = "";
                    AnchTab3.HRef = "";
                    AnchTab4.HRef = "";
                    AnchTab5.HRef = "";
                    AnchTab6.HRef = "";


                    if (!IsPostBack)
                    {
                        CheckEligibility = ObjCAFClass.Check_Applicant_Eligibility(hdnUserID.Value.ToString());
                        if (CheckEligibility == "N")
                        {
                            Response.Redirect("~/UI/UserDashBoard.aspx");
                        }
                        if (Request.QueryString.Count > 0 && Request.QueryString["IncentveID"] != null && Request.QueryString["IncentveID"].ToString() != "")
                        {
                            IncentiveId = Request.QueryString["IncentveID"].ToString();
                            Session["IncentiveID"] = IncentiveId;
                            SessionIncentiveId = IncentiveId;
                        }
                        else
                        {
                            Session["IncentiveID"] = "0";
                        }


                        BindConstitutionUnit();
                        BindUnitAddressStates();
                        BindOfficeAddressStates();
                        BindEligibility();
                        BindQualification();
                        // Tab 2 control Bindings
                        BindUnitMasterData();

                        BindTextTyleProcessType();
                        BindForeignCurrency();
                        BindTechnicalTexttile();
                        cmf.BindCtlto(true, ddlBank, objFetch.FetchBankMst(), 1, 0, false);
                        cmf.BindCtlto(true, ddltermloanbank, objFetch.FetchBankMst(), 1, 0, false);
                        BindBankAccountType();
                        MainView.ActiveViewIndex = 0;

                        ddlUnitstate.SelectedValue = "31";

                        ddlUnitstate_SelectedIndexChanged(sender, e);

                        BindSavedApplicationDtls(ObjLoginNewvo.uid, IncentiveId);

                        BindDocumentsList(Session["IncentiveID"].ToString());

                        DisableTSIPASSInputs(false);
                        ddlUnitstate.Enabled = false;

                        if (ddlOrgType.SelectedValue == "0")
                        {
                            ddlOrgType.Enabled = true;
                        }
                        if (rblCaste.SelectedValue == "0")
                        {
                            rblCaste.Enabled = true;
                        }

                        if (txtEINIEMILDate.Text == "")
                        {
                            txtEINIEMILDate.Enabled = true;
                        }
                        if (txtEINIEMILNumber.Text == "")
                        {
                            txtEINIEMILNumber.Enabled = true;
                        }

                        //if (ObjLoginNewvo.uid == "40949" && IncentiveId == "1035")
                        //{
                        //    divPMunitType.Visible = true;
                        //    divPMunitType1.Visible = true;
                        //    divPMRatio.Visible = true;

                        //    grdPandM.Columns[28].Visible = true;
                        //    grdPandM.Columns[27].Visible = true;

                        //    DivMachineryDetails.Visible = true;

                        //    txtMachineName.Enabled = true;
                        //    txtVendorName.Enabled = true;
                        //    rdlMachineType.Enabled = true;
                        //    txtManufacturerName.Enabled = true;
                        //    RdlMachinaryParts.Enabled = true;
                        //    txtCustomCountryName.Enabled = true;
                        //    txtCustomPaid.Enabled = true;
                        //    txtImportduty.Enabled = true;
                        //    txtportcharges.Enabled = true;
                        //    txtstatutorytaxesetc.Enabled = true;
                        //    txtCostoftheMachineforeign.Enabled = true;
                        //    ddlForeignCurrency.Enabled = true;
                        //    RbtnInstalledMachinery.Enabled = true;
                        //    rbtnInstalledMachinerytype.Enabled = true;
                        //    txtInvoiceNo.Enabled = true;
                        //    txtInvoiceDate.Enabled = true;
                        //    txtInitiationDate.Enabled = true;
                        //    txtMachineLoadingDate.Enabled = true;
                        //    txtVaivleNo.Enabled = true;
                        //    txtVaivleDate.Enabled = true;
                        //    txtCostofMachine.Enabled = true;
                        //    ddlEligibility.Enabled = true;
                        //    ddlpmtype.Enabled = true;
                        //    fuInvoiceBills.Enabled = true;
                        //}

                        if (grdPandM.Rows.Count > 0)
                        {
                            foreach (GridViewRow gvr in grdPandM.Rows)
                            {
                                string filaname = ((HyperLink)gvr.FindControl("hyFilePathMerge2")).NavigateUrl.ToString();
                                if (filaname == "")
                                {
                                    //grdPandM.Columns[33].Visible = true;
                                }
                            }
                        }
                        DataSet dsQueries = new DataSet();
                        dsQueries = GetApplicantIncentivesHistory(Session["uid"].ToString());
                        if (dsQueries != null && dsQueries.Tables.Count > 1 && dsQueries.Tables[1].Rows.Count > 0 && ObjLoginNewvo.uid == "70312")
                        {
                            ddltypeofDocuments.Enabled = true;
                            fuDocuments1.Enabled = true;
                            btnUpload1.Enabled = true;
                        }
                        /*IsFirstTime = ObjCAFClass.Check_IsFirstTime(hdnUserID.Value.ToString());
                        if (IsFirstTime == "Y")
                        {
                            divOtp.Visible = true;
                            txtOTP.Enabled = false;
                            hdnIsFirstTime.Value = "Y";
                        }*/
                    }


                    if (ddlIndustryStatus.SelectedValue != "1")
                    {
                        if (gvGrossblockPandM.Rows.Count > 0)
                        {
                            rbtnInvoiceTypes.Enabled = false;
                            rbtnInvoiceTypes.SelectedValue = "2";
                            rbtnInvoiceTypes_SelectedIndexChanged(sender, e);
                        }
                        else if (grdPandM.Rows.Count > 0)
                        {
                            rbtnInvoiceTypes.Enabled = false;
                        }
                    }
                    else
                    {
                        //chanikya

                        DivInvoiceTypes.Visible = false;
                        rbtnInvoiceTypes.Enabled = false;

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
        protected void AnchTab1_Click(object sender, EventArgs e)
        {
            int Tab1Index = 0;
            string errormsg = string.Empty;
            if (Tab1Index < MainView.ActiveViewIndex)
            {
                Tab1.Attributes.Add("class", "active");
                Tab2.Attributes.Add("class", "");
                Tab3.Attributes.Add("class", "");
                Tab4.Attributes.Add("class", "");
                Tab5.Attributes.Add("class", "");
                Tab6.Attributes.Add("class", "");
                MainView.ActiveViewIndex = 0;
            }
            else if (MainView.ActiveViewIndex == 0)
            {
                errormsg = ValidateControls("1");
            }
            else if (MainView.ActiveViewIndex == 1)
            {
                errormsg = ValidateControls("2");
            }
            else if (MainView.ActiveViewIndex == 2)
            {
                errormsg = ValidateControls("3");
            }
            else if (MainView.ActiveViewIndex == 3)
            {
                errormsg = ValidateControls("4");
            }
            else if (MainView.ActiveViewIndex == 4)
            {
                errormsg = ValidateControls("5");
            }
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            Tab1.Attributes.Add("class", "active");
            Tab2.Attributes.Add("class", "");
            Tab3.Attributes.Add("class", "");
            Tab4.Attributes.Add("class", "");
            Tab5.Attributes.Add("class", "");
            Tab6.Attributes.Add("class", "");
            MainView.ActiveViewIndex = 0;
        }
        protected void AnchTab2_Click(object sender, EventArgs e)
        {
            int Tab1Index = 1;
            string errormsg = string.Empty;
            if (Tab1Index < MainView.ActiveViewIndex)
            {
                Tab1.Attributes.Add("class", "");
                Tab2.Attributes.Add("class", "active");
                Tab3.Attributes.Add("class", "");
                Tab4.Attributes.Add("class", "");
                Tab5.Attributes.Add("class", "");
                Tab6.Attributes.Add("class", "");
                MainView.ActiveViewIndex = 1;
            }
            else if (MainView.ActiveViewIndex == 0)
            {
                errormsg = ValidateControls("1");
            }
            else if (MainView.ActiveViewIndex == 1)
            {
                errormsg = ValidateControls("2");
            }
            else if (MainView.ActiveViewIndex == 2)
            {
                errormsg = ValidateControls("3");
            }
            else if (MainView.ActiveViewIndex == 3)
            {
                errormsg = ValidateControls("4");
            }
            else if (MainView.ActiveViewIndex == 4)
            {
                errormsg = ValidateControls("5");
            }
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            Tab1.Attributes.Add("class", "");
            Tab2.Attributes.Add("class", "active");
            Tab3.Attributes.Add("class", "");
            Tab4.Attributes.Add("class", "");
            Tab5.Attributes.Add("class", "");
            Tab6.Attributes.Add("class", "");
            MainView.ActiveViewIndex = 1;
        }
        protected void AnchTab3_Click(object sender, EventArgs e)
        {
            int Tab1Index = 2;
            string errormsg = string.Empty;
            if (Tab1Index < MainView.ActiveViewIndex)
            {
                Tab1.Attributes.Add("class", "");
                Tab2.Attributes.Add("class", "");
                Tab3.Attributes.Add("class", "active");
                Tab4.Attributes.Add("class", "");
                Tab5.Attributes.Add("class", "");
                Tab6.Attributes.Add("class", "");
                MainView.ActiveViewIndex = 2;
            }
            else if (MainView.ActiveViewIndex == 0)
            {
                errormsg = ValidateControls("1");
            }
            else if (MainView.ActiveViewIndex == 1)
            {
                errormsg = ValidateControls("2");
            }
            else if (MainView.ActiveViewIndex == 2)
            {
                errormsg = ValidateControls("3");
            }
            else if (MainView.ActiveViewIndex == 3)
            {
                errormsg = ValidateControls("4");
            }
            else if (MainView.ActiveViewIndex == 4)
            {
                errormsg = ValidateControls("5");
            }
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            Tab1.Attributes.Add("class", "");
            Tab2.Attributes.Add("class", "");
            Tab3.Attributes.Add("class", "active");
            Tab4.Attributes.Add("class", "");
            Tab5.Attributes.Add("class", "");
            Tab6.Attributes.Add("class", "");
            MainView.ActiveViewIndex = 2;
        }
        protected void AnchTab4_Click(object sender, EventArgs e)
        {
            int Tab1Index = 3;
            string errormsg = string.Empty;
            if (Tab1Index < MainView.ActiveViewIndex)
            {
                Tab1.Attributes.Add("class", "");
                Tab2.Attributes.Add("class", "");
                Tab3.Attributes.Add("class", "");
                Tab4.Attributes.Add("class", "active");
                Tab5.Attributes.Add("class", "");
                Tab6.Attributes.Add("class", "");
                MainView.ActiveViewIndex = 3;
            }
            else if (MainView.ActiveViewIndex == 0)
            {
                errormsg = ValidateControls("1");
            }
            else if (MainView.ActiveViewIndex == 1)
            {
                errormsg = ValidateControls("2");
            }
            else if (MainView.ActiveViewIndex == 2)
            {
                errormsg = ValidateControls("3");
            }
            else if (MainView.ActiveViewIndex == 3)
            {
                errormsg = ValidateControls("4");
            }
            else if (MainView.ActiveViewIndex == 4)
            {
                errormsg = ValidateControls("5");
            }
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            Tab1.Attributes.Add("class", "");
            Tab2.Attributes.Add("class", "");
            Tab3.Attributes.Add("class", "");
            Tab4.Attributes.Add("class", "active");
            Tab5.Attributes.Add("class", "");
            Tab6.Attributes.Add("class", "");
            MainView.ActiveViewIndex = 3;
        }
        protected void AnchTab5_Click(object sender, EventArgs e)
        {
            int Tab1Index = 4;
            string errormsg = string.Empty;
            if (Tab1Index < MainView.ActiveViewIndex)
            {
                Tab1.Attributes.Add("class", "");
                Tab2.Attributes.Add("class", "");
                Tab3.Attributes.Add("class", "");
                Tab4.Attributes.Add("class", "");
                Tab5.Attributes.Add("class", "active");
                Tab6.Attributes.Add("class", "");
                MainView.ActiveViewIndex = 4;
            }
            else if (MainView.ActiveViewIndex == 0)
            {
                errormsg = ValidateControls("1");
            }
            else if (MainView.ActiveViewIndex == 1)
            {
                errormsg = ValidateControls("2");
            }
            else if (MainView.ActiveViewIndex == 2)
            {
                errormsg = ValidateControls("3");
            }
            else if (MainView.ActiveViewIndex == 3)
            {
                errormsg = ValidateControls("4");
            }
            else if (MainView.ActiveViewIndex == 4)
            {
                errormsg = ValidateControls("5");
            }
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            Tab1.Attributes.Add("class", "");
            Tab2.Attributes.Add("class", "");
            Tab3.Attributes.Add("class", "");
            Tab4.Attributes.Add("class", "");
            Tab5.Attributes.Add("class", "active");
            Tab6.Attributes.Add("class", "");
            MainView.ActiveViewIndex = 4;
        }
        protected void AnchTab6_Click(object sender, EventArgs e)
        {
            int Tab1Index = 5;
            string errormsg = string.Empty;
            if (Tab1Index < MainView.ActiveViewIndex)
            {
                Tab1.Attributes.Add("class", "");
                Tab2.Attributes.Add("class", "");
                Tab3.Attributes.Add("class", "");
                Tab4.Attributes.Add("class", "");
                Tab5.Attributes.Add("class", "");
                Tab6.Attributes.Add("class", "active");
                MainView.ActiveViewIndex = 5;
            }
            else if (MainView.ActiveViewIndex == 0)
            {
                errormsg = ValidateControls("1");
            }
            else if (MainView.ActiveViewIndex == 1)
            {
                errormsg = ValidateControls("2");
            }
            else if (MainView.ActiveViewIndex == 2)
            {
                errormsg = ValidateControls("3");
            }
            else if (MainView.ActiveViewIndex == 3)
            {
                errormsg = ValidateControls("4");
            }
            else if (MainView.ActiveViewIndex == 4)
            {
                errormsg = ValidateControls("5");
            }
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            Tab1.Attributes.Add("class", "");
            Tab2.Attributes.Add("class", "");
            Tab3.Attributes.Add("class", "");
            Tab4.Attributes.Add("class", "");
            Tab5.Attributes.Add("class", "");
            Tab6.Attributes.Add("class", "active");
            MainView.ActiveViewIndex = 5;

            BindDocumentsList(Session["IncentiveID"].ToString());
        }
        protected void btntab1next_Click(object sender, EventArgs e)
        {
            try
            {
                
                string errormsg = ValidateControls("1");
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    AssignValuestoVosFromcontrols("1");
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
        public void AssignValuestoVosFromcontrols(string step)
        {
            try
            {
                IncentivesVOs objvo = new IncentivesVOs();

                objvo.AppsLevel = step;
                if (Session["IncentiveID"] != null)
                {
                    objvo.IncentveID = Session["IncentiveID"].ToString();
                }
                if (objvo.IncentveID == null || objvo.IncentveID == "")
                {
                    objvo.IncentveID = "0";
                }
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                objvo.User_Id = ObjLoginNewvo.uid;

                if (step == "1")
                {
                    objvo.Uid_NO = TxtUidNumber.Text;
                    objvo.sector = rblSector.SelectedValue;
                    objvo.UnitName = txtUnitName.Text.Trim().TrimStart();
                    objvo.CountryOrigin = txtCountryofOrigin.Text.Trim().TrimStart();
                    string[] Ld6 = null;
                    string ConvertedDt56 = "";

                    if (txtDateOfIncorporation.Text != "")
                    {
                        Ld6 = txtDateOfIncorporation.Text.Split('/');
                        ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();
                        objvo.DateOfIncorporation = ConvertedDt56;
                    }
                    else
                    {
                        objvo.DateOfIncorporation = null;
                    }
                    objvo.IncorpRegistranNumber = txtIncorpRegistranNumber.Text;
                    objvo.TinNO = txtTinNO.Text.Trim().TrimStart();
                    objvo.PanNo = txtPanNo.Text.Trim().TrimStart();

                    objvo.EMiUdyogAadhar = txtEINIEMILNumber.Text.Trim().TrimStart();
                    string[] Ld2 = null;
                    string ConvertedDt5 = "";

                    if (txtEINIEMILDate.Text != "")
                    {
                        Ld2 = txtEINIEMILDate.Text.Split('/');
                        ConvertedDt5 = Ld2[2].ToString() + "/" + Ld2[1].ToString() + "/" + Ld2[0].ToString();

                        objvo.UdyogAadharRegdDate = ConvertedDt5;
                    }
                    else
                    {
                        objvo.UdyogAadharRegdDate = null;
                    }

                    objvo.TypeofOrg = ddlOrgType.SelectedValue;
                    objvo.SocialStatus = rblCaste.SelectedValue;
                    if (ddlsubcaste.SelectedItem.Text.ToUpper() != "SELECT")
                    {
                        objvo.SubCaste = ddlsubcaste.SelectedValue;
                    }
                    else
                    {
                        objvo.SubCaste = null;
                    }
                    objvo.ApplciantName = txtApplciantName.Text.Trim().TrimStart();
                    objvo.Gender = ddlgender.SelectedValue.ToString();
                    objvo.YearsOfExpinTexttile = txtYearsOfExpinTexttile.Text;
                    objvo.IsDifferentlyAbled = ddlDifferentlyabled.SelectedValue;
                    objvo.TypeofTexttile = rdl_TypeofUnit.SelectedValue;
                    // Unit Address

                    objvo.UnitState = ddlUnitstate.SelectedValue;
                    objvo.UnitDIst = ddlUnitDIst.SelectedValue;
                    objvo.UnitMandal = ddlUnitMandal.SelectedValue;
                    objvo.UnitVill = ddlVillageunit.SelectedValue;
                    objvo.UnitStreet = txtUnitStreet.Text.Trim().TrimStart();
                    objvo.UnitHNO = txtUnitHNO.Text.Trim().TrimStart();
                    objvo.UnitMObileNo = txtunitmobileno.Text.Trim().TrimStart();
                    objvo.UnitEmail = txtunitemailid.Text.Trim().TrimStart();
                    if (txtadhar1.Text.Trim().TrimStart() != "" && txtadhar2.Text.Trim().TrimStart() != "" && txtadhar3.Text.Trim().TrimStart() != "")
                    {
                        objvo.AadharNumber = txtadhar1.Text.Trim().TrimStart() + txtadhar2.Text.Trim().TrimStart() + txtadhar3.Text.Trim().TrimStart();
                    }

                    //Office Address
                    objvo.OffcState = ddloffcstate.SelectedValue;
                    if (ddloffcstate.SelectedValue.ToString() != "31")
                    {
                        objvo.OffcOtherDist = txtofficedist.Text.Trim().TrimStart();
                        objvo.OffcOtherMandal = txtoffcicemandal.Text.Trim().TrimStart();
                        objvo.OffcOtherVillage = txtofficeviiage.Text.Trim().TrimStart();
                    }
                    else
                    {
                        objvo.OffcDIst = ddlOffcDIst.SelectedValue;
                        objvo.OffcMandal = ddlOffcMandal.SelectedValue;
                        objvo.OffcVil = ddlOffcVil.SelectedValue;
                    }
                    objvo.OffcHNO = txtOffSurveyNo.Text.Trim().TrimStart();
                    objvo.OffcStreet = txtOffcStreet.Text.Trim().TrimStart();
                    objvo.OffcEmail = txtOffcEmail.Text.Trim().TrimStart();
                    objvo.OffcMobileNO = txtOffcMobileNO.Text.Trim().TrimStart();


                    // Tsipass //chanikya
                    objvo.IdsustryStatus = ddlIndustryStatus.SelectedValue;

                    objvo.ExistEnterpriseLand = (txtlandexisting.Text != "") ? txtlandexisting.Text.Trim().TrimStart() : null;
                    objvo.ExpansionDiversificationLand = (txtlandcapacity.Text != "") ? txtlandcapacity.Text.Trim().TrimStart() : null;


                    objvo.ExistEnterpriseBuilding = (txtbuildingexisting.Text != "") ? txtbuildingexisting.Text.Trim().TrimStart() : null;
                    objvo.ExpDiversBuilding = (txtbuildingcapacity.Text != "") ? txtbuildingcapacity.Text.Trim().TrimStart() : null;


                    objvo.ExistEnterprisePlantMachinery = (txtplantexisting.Text != "") ? txtplantexisting.Text.Trim().TrimStart() : null;
                    objvo.ExpDiversPlantMachinery = (txtplantcapacity.Text != "") ? txtplantcapacity.Text.Trim().TrimStart() : null;

                    objvo.IpassLand = (txtIpassLand.Text != "") ? txtIpassLand.Text.Trim().TrimStart() : null;
                    objvo.IpassLandExp = (txtIpassLandExp.Text != "") ? txtIpassLandExp.Text.Trim().TrimStart() : null;

                    objvo.IpassBuilding = (txtIpassBuilding.Text != "") ? txtIpassBuilding.Text.Trim().TrimStart() : null;
                    objvo.IpassBuildingExp = (txtIpassBuildingExp.Text != "") ? txtIpassBuildingExp.Text.Trim().TrimStart() : null;

                    objvo.IpassPlantMachine = (txtIpassPlantMachine.Text != "") ? txtIpassPlantMachine.Text.Trim().TrimStart() : null;
                    objvo.IpassPlantMachineExp = (txtIpassPlantMachineExp.Text != "") ? txtIpassPlantMachineExp.Text.Trim().TrimStart() : null;

                    objvo.ManagementStaffMale = (txtstaffMale.Text != "") ? Convert.ToInt32(txtstaffMale.Text.Trim().TrimStart()) : Convert.ToInt32("0");
                    objvo.ManagementStaffFemale = (txtfemale.Text != "") ? Convert.ToInt32(txtfemale.Text.Trim().TrimStart()) : Convert.ToInt32("0");


                    //objvo.ManagementStaffMaleindirect = Convert.ToInt32(GetDecimalNullValue(txtstaffMaleInDirect.Text.Trim().TrimStart()));
                    //objvo.ManagementStaffFemaleindirect = Convert.ToInt32(GetDecimalNullValue(txtfemaleInDirect.Text.Trim().TrimStart()));
                    try
                    {
                        string Validstatus = ObjCAFClass.InsertIncentivCommonDataTAB1(objvo);
                        if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                        {
                            txtAccountName.Text = txtUnitName.Text.Trim().TrimStart();
                            objvo.IncentveID = Validstatus;
                            Session["IncentiveID"] = objvo.IncentveID;
                            AnchTab2_Click(this, EventArgs.Empty);
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
                else if (step == "2")
                {
                    objvo.IdsustryStatus = ddlIndustryStatus.SelectedValue;
                    if (ddlIndustryStatus.SelectedValue == "2")
                    {
                        objvo.IndustryExpansionType = ddlInustryExpansionType.SelectedValue;
                    }
                    string[] Ld2 = null;
                    string ConvertedDt5 = "";

                    if (txtDateofCommencement.Text != "")
                    {
                        Ld2 = txtDateofCommencement.Text.Split('/');
                        ConvertedDt5 = Ld2[2].ToString() + "/" + Ld2[1].ToString() + "/" + Ld2[0].ToString();

                        objvo.DateOfComm = ConvertedDt5;
                    }
                    else
                    {
                        objvo.DateOfComm = null;
                    }

                    objvo.SpecialIncentiveYN = ddlSpecialIncentive.SelectedValue;
                    if (objvo.SpecialIncentiveYN == "Y")
                    {
                        objvo.GovermentOrderNumber = txtGovermentOrderNumber.Text.Trim();
                        objvo.GovermentOrderDate = GetFromatedDateDDMMYYYY(txtGovermentOrderDate.Text.Trim());
                    }

                    objvo.TextileProcessType = ddlTextileProcessType.SelectedValue.ToString();
                    if (rdl_TypeofUnit.SelectedValue == "1")
                    {
                        objvo.TechnicalTextileType = ddlTechnicalNatureOfIndustry.SelectedValue.ToString();
                    }

                    if (ddlTextileProcessType.SelectedValue == "18")
                    {
                        objvo.NewOtherTextileProcessType = txtNewOtherTextileProcessType.Text.Trim().TrimStart();
                    }

                    if (ddlIndustryStatus.SelectedValue != "1")
                    {
                        if (txtDateofCommencementExp.Text != "")
                        {
                            Ld2 = txtDateofCommencementExp.Text.Split('/');
                            ConvertedDt5 = Ld2[2].ToString() + "/" + Ld2[1].ToString() + "/" + Ld2[0].ToString();

                            objvo.DateOfCommExp = ConvertedDt5;
                        }
                        else
                        {
                            objvo.DateOfCommExp = null;
                        }

                        objvo.TextileProcessTypeExp = ddlTextileProcessTypeExp.SelectedValue.ToString();
                        if (ddlTextileProcessTypeExp.SelectedValue == "18")
                        {
                            objvo.ExistOtherTextileProcessType = txtExistOtherTextileProcessType.Text.Trim().TrimStart();
                        }
                    }

                    objvo.AuthorisedSignatory = txtAuthorisedPerson.Text.Trim();
                    objvo.AuthorisedSignatoryDesignationValue = ddlAuthorisedSignDesignation.SelectedValue;
                    objvo.Authorized_PAN_NO = txtPanNoAuthorised.Text.Trim();
                    objvo.Authorized_EmailId = txtemailAuthorised.Text.Trim();
                    objvo.Authorized_MobileNo = txtMobileNumberAuthorised.Text.Trim();
                    objvo.Authorized_CorresponAdderess = txtCorrespondenceAddress.Text.Trim();

                    try
                    {
                        string ValidateData = ObjCAFClass.Check_CafDataValidation(objvo);
                        if (ValidateData == "")
                        {
                            string Validstatus = ObjCAFClass.InsertIncentivCommonDataTAB2(objvo);
                            if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                            {
                                //objvo.IncentveID = Validstatus;
                                //Session["IncentiveID"] = objvo.IncentveID;
                                AnchTab3_Click(this, EventArgs.Empty);
                            }
                        }
                        else
                        {
                            string message = "alert('" + ValidateData + "')";
                            ScriptManager.RegisterClientScriptBlock((this as Control), this.GetType(), "alert", message, true);
                            return;
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
                else if (step == "3")
                {
                    objvo.ManagementStaffMale = (txtstaffMale.Text != "") ? Convert.ToInt32(txtstaffMale.Text.Trim().TrimStart()) : Convert.ToInt32("0");
                    objvo.ManagementStaffFemale = (txtfemale.Text != "") ? Convert.ToInt32(txtfemale.Text.Trim().TrimStart()) : Convert.ToInt32("0");
                    objvo.SupervisoryMale = (txtsupermalecount.Text != "") ? Convert.ToInt32(txtsupermalecount.Text.Trim().TrimStart()) : Convert.ToInt32("0");
                    objvo.SupervisoryFemale = (txtsuperfemalecount.Text != "") ? Convert.ToInt32(txtsuperfemalecount.Text.Trim().TrimStart()) : Convert.ToInt32("0");
                    objvo.SkilledWorkersMale = (txtSkilledWorkersMale.Text != "") ? Convert.ToInt32(txtSkilledWorkersMale.Text.Trim().TrimStart()) : Convert.ToInt32("0");
                    objvo.SkilledWorkersFemale = (txtSkilledWorkersFemale.Text != "") ? Convert.ToInt32(txtSkilledWorkersFemale.Text.Trim().TrimStart()) : Convert.ToInt32("0");
                    objvo.SemiSkilledWorkersMale = (txtSemiSkilledWorkersMale.Text != "") ? Convert.ToInt32(txtSemiSkilledWorkersMale.Text.Trim().TrimStart()) : Convert.ToInt32("0");
                    objvo.SemiSkilledWorkersFemale = (txtSemiSkilledWorkersFemale.Text != "") ? Convert.ToInt32(txtSemiSkilledWorkersFemale.Text.Trim().TrimStart()) : Convert.ToInt32("0");

                    objvo.ManagementStaffMaleNonLocal = (txtstaffMaleNonLocal.Text != "") ? Convert.ToInt32(txtstaffMaleNonLocal.Text.Trim().TrimStart()) : Convert.ToInt32("0");
                    objvo.ManagementStaffFemaleNonLocal = (txtfemaleNonLocal.Text != "") ? Convert.ToInt32(txtfemaleNonLocal.Text.Trim().TrimStart()) : Convert.ToInt32("0");
                    objvo.SupervisoryMaleNonLocal = (txtsupermalecountNonLocal.Text != "") ? Convert.ToInt32(txtsupermalecountNonLocal.Text.Trim().TrimStart()) : Convert.ToInt32("0");
                    objvo.SupervisoryFemaleNonLocal = (txtsuperfemalecountNonLocal.Text != "") ? Convert.ToInt32(txtsuperfemalecountNonLocal.Text.Trim().TrimStart()) : Convert.ToInt32("0");
                    objvo.SkilledWorkersMaleNonLocal = (txtSkilledWorkersMaleNonLocal.Text != "") ? Convert.ToInt32(txtSkilledWorkersMaleNonLocal.Text.Trim().TrimStart()) : Convert.ToInt32("0");
                    objvo.SkilledWorkersFemaleNonLocal = (txtSkilledWorkersFemaleNonLocal.Text != "") ? Convert.ToInt32(txtSkilledWorkersFemaleNonLocal.Text.Trim().TrimStart()) : Convert.ToInt32("0");
                    objvo.SemiSkilledWorkersMaleNonLocal = (txtSemiSkilledWorkersMaleNonLocal.Text != "") ? Convert.ToInt32(txtSemiSkilledWorkersMaleNonLocal.Text.Trim().TrimStart()) : Convert.ToInt32("0");
                    objvo.SemiSkilledWorkersFemaleNonLocal = (txtSemiSkilledWorkersFemaleNonLocal.Text != "") ? Convert.ToInt32(txtSemiSkilledWorkersFemaleNonLocal.Text.Trim().TrimStart()) : Convert.ToInt32("0");

                    //objvo.ManagementStaffMaleindirect = Convert.ToInt32(GetDecimalNullValue(txtstaffMaleInDirect.Text.Trim().TrimStart()));
                    //objvo.SupervisoryMaleindirect = Convert.ToInt32(GetDecimalNullValue(txtsupermalecountInDirect.Text.Trim().TrimStart()));
                    //objvo.SkilledWorkersMaleindirect = Convert.ToInt32(GetDecimalNullValue(txtSkilledWorkersMaleInDirect.Text.Trim().TrimStart()));
                    //objvo.SemiSkilledWorkersFemaleindirect = Convert.ToInt32(GetDecimalNullValue(txtSemiSkilledWorkersMaleIndirect.Text.Trim().TrimStart()));

                    //objvo.ManagementStaffFemaleindirect = Convert.ToInt32(GetDecimalNullValue(txtfemaleInDirect.Text.Trim().TrimStart()));
                    //objvo.SupervisoryFemaleindirect = Convert.ToInt32(GetDecimalNullValue(txtsuperfemalecountInDirect.Text.Trim().TrimStart()));
                    //objvo.SkilledWorkersFemaleindirect = Convert.ToInt32(GetDecimalNullValue(txtSkilledWorkersFemaleInDirect.Text.Trim().TrimStart()));
                    //objvo.SemiSkilledWorkersMaleindirect = Convert.ToInt32(GetDecimalNullValue(txtSemiSkilledWorkersFemaleIndirect.Text.Trim().TrimStart()));


                    objvo.EmpDirectLocalMaleOther = Convert.ToInt32(GetDecimalNullValue(txtEmpDirectLocalMaleOther.Text.Trim().TrimStart()));
                    objvo.EmpDirectLocalFemaleOther = Convert.ToInt32(GetDecimalNullValue(txtEmpDirectLocalFemaleOther.Text.Trim().TrimStart()));
                    objvo.EmpDirectNonLocalMaleOther = Convert.ToInt32(GetDecimalNullValue(txtEmpDirectNonLocalMaleOther.Text.Trim().TrimStart()));
                    objvo.EmpDirectNonLocalFemaleOther = Convert.ToInt32(GetDecimalNullValue(txtEmpDirectNonLocalFemaleOther.Text.Trim().TrimStart()));
                    //objvo.EmpIndirectMaleOther=Convert.ToInt32(GetDecimalNullValue(txtEmpIndirectMaleOther.Text.Trim().TrimStart()));
                    //objvo.EmpIndirectFemaleOther=Convert.ToInt32(GetDecimalNullValue(txtEmpIndirectFemaleOther.Text.Trim().TrimStart()));


                    objvo.ExistEnterpriseLand = (txtlandexisting.Text != "") ? txtlandexisting.Text.Trim().TrimStart() : null;
                    objvo.ExpansionDiversificationLand = (txtlandcapacity.Text != "") ? txtlandcapacity.Text.Trim().TrimStart() : null;
                    objvo.LandFixedCapitalInvestPercentage = (txtlandpercentage.Text != "") ? txtlandpercentage.Text.Trim().TrimStart() : null;
                    objvo.IpassLand = (txtIpassLand.Text != "") ? txtIpassLand.Text.Trim().TrimStart() : null;
                    objvo.IpassLandExp = (txtIpassLandExp.Text != "") ? txtIpassLandExp.Text.Trim().TrimStart() : null;

                    objvo.ExistEnterpriseBuilding = (txtbuildingexisting.Text != "") ? txtbuildingexisting.Text.Trim().TrimStart() : null;
                    objvo.ExpDiversBuilding = (txtbuildingcapacity.Text != "") ? txtbuildingcapacity.Text.Trim().TrimStart() : null;
                    objvo.BuildingFixedCapitalInvestPercentage = (txtbuildingpercentage.Text != "") ? txtbuildingpercentage.Text.Trim().TrimStart() : null;
                    objvo.IpassBuilding = (txtIpassBuilding.Text != "") ? txtIpassBuilding.Text.Trim().TrimStart() : null;
                    objvo.IpassBuildingExp = (txtIpassBuildingExp.Text != "") ? txtIpassBuildingExp.Text.Trim().TrimStart() : null;

                    objvo.ExistEnterprisePlantMachinery = (txtplantexisting.Text != "") ? txtplantexisting.Text.Trim().TrimStart() : null;
                    objvo.ExpDiversPlantMachinery = (txtplantcapacity.Text != "") ? txtplantcapacity.Text.Trim().TrimStart() : null;
                    objvo.PlantMachFixedCapitalInvestPercentage = (txtplantpercentage.Text != "") ? txtplantpercentage.Text.Trim().TrimStart() : null;
                    objvo.IpassPlantMachine = (txtIpassPlantMachine.Text != "") ? txtIpassPlantMachine.Text.Trim().TrimStart() : null;
                    objvo.IpassPlantMachineExp = (txtIpassPlantMachineExp.Text != "") ? txtIpassPlantMachineExp.Text.Trim().TrimStart() : null;

                    objvo.CurrentInvestmentLandvalue = (txtcurrInvLandValue.Text != "") ? txtcurrInvLandValue.Text.Trim().TrimStart() : null;
                    objvo.CurrentInvestmentBuildingvalue = (txtcurrInvBuldvalue.Text != "") ? txtcurrInvBuldvalue.Text.Trim().TrimStart() : null;
                    objvo.CurrentInvestmentplantMechValue = (txtcurrInvplantMechValue.Text != "") ? txtcurrInvplantMechValue.Text.Trim().TrimStart() : null;
                    objvo.CurrentInvestmentOtherValue = GetDecimalNullValue(txtcurrentInvothers.Text.Trim());

                    if (DivInvoiceTypes.Visible && rbtnInvoiceTypes.SelectedValue == "2")
                    {
                        decimal Grossblock = 0;
                        foreach (GridViewRow gvrow in gvGrossblockPandM.Rows)
                        {
                            Grossblock = Grossblock + Convert.ToDecimal(GetDecimalNullValue((gvrow.FindControl("lblAmountGrossBlock") as Label).Text));
                        }

                        decimal PMValue = Grossblock - (Convert.ToDecimal(GetDecimalNullValue(objvo.CurrentInvestmentLandvalue)) + Convert.ToDecimal(GetDecimalNullValue(objvo.CurrentInvestmentBuildingvalue))
                            + Convert.ToDecimal(GetDecimalNullValue(objvo.CurrentInvestmentOtherValue)));

                        if (PMValue > 0)
                        {
                            objvo.CurrentInvestmentplantMechValue = PMValue.ToString();
                            txtcurrInvplantMechValue.Text = PMValue.ToString();
                            txtcurrInvLandValue_TextChanged(this, EventArgs.Empty);
                        }
                    }
                    else
                    {
                        objvo.CurrentInvestmentplantMechValue = GetDecimalNullValue(lblTotalvaluemachinery.InnerText);
                    }


                    //objvo.OtherFixedCapital = GetDecimalNullValue(txtnewothers.Text);
                    //objvo.OtherFixedCapitalExp = GetDecimalNullValue(txtexistother.Text);
                    //objvo.OtherFixedCapitalPercentage = GetDecimalNullValue(txtotherpersangage.Text);

                    objvo.Category = HiddenFieldEnterpriseCategory.Value;

                    objvo.IsPowerApplicable = ddlIspowApplicable.SelectedItem.Text;
                    objvo.IsPowerApplicableValues = ddlIspowApplicable.SelectedValue;

                    objvo.IsWaterSourceApplicable = ddlWaterSource.SelectedItem.Text;
                    objvo.IsWaterSourceApplicableValues = ddlWaterSource.SelectedValue;

                    if (ddlIspowApplicable.SelectedValue == "1")
                    {
                        if (ddlIndustryStatus.SelectedValue == "1")
                        {
                            objvo.NewPowerUniqueID = txtNewPowerUniqueID.Text.Trim().TrimStart();
                            objvo.NewPowerCompany = txtNewPowerCompany.Text.Trim().TrimStart();

                            string[] rd1 = null;
                            string ConvertedDt1 = "";

                            if (txtNewPowerReleaseDate.Text != "")
                            {
                                rd1 = txtNewPowerReleaseDate.Text.Split('/');
                                ConvertedDt1 = rd1[2].ToString() + "/" + rd1[1].ToString() + "/" + rd1[0].ToString();

                                objvo.NewPowerReleaseDate = ConvertedDt1;
                            }
                            else
                            {
                                objvo.NewPowerReleaseDate = null;
                            }

                            objvo.NewConnectedLoad = txtPowerConnectedLoad.Text.Trim().TrimStart();
                            objvo.NewContractedLoad = txtNewContractedLoad.Text.Trim().TrimStart();
                            objvo.NewServiceRateUnit = txtServiceRateUnit.Text.Trim().TrimStart();
                        }
                        else
                        {

                            objvo.ExistingPowerUniqueID = txtExistingPowerUniqueID.Text.Trim().TrimStart();
                            objvo.ExistingPowerCompany = txtExistingPowerCompany.Text.Trim().TrimStart();

                            string[] rd2 = null;
                            string ConvertedDt2 = "";

                            if (txtExistingPowerReleaseDate.Text != "")
                            {
                                rd2 = txtExistingPowerReleaseDate.Text.Split('/');
                                ConvertedDt2 = rd2[2].ToString() + "/" + rd2[1].ToString() + "/" + rd2[0].ToString();
                                objvo.ExistingPowerReleaseDate = ConvertedDt2;
                            }
                            else
                            {
                                objvo.ExistingPowerReleaseDate = null;
                            }

                            objvo.ExistingConnectedLoad = txtExistingPowerConnectedLoad.Text.Trim().TrimStart();
                            objvo.ExistingContractedLoad = txtExistingContractedLoad.Text.Trim().TrimStart();
                            objvo.ExistingServiceRateUnit = txtExistingRateUnit.Text.Trim().TrimStart();

                            objvo.ExpanDiverPowerUniqueID = txtExpanDiverPowerUniqueID.Text.Trim().TrimStart();
                            objvo.ExpanDiverPowerCompany = txtExpanDiverPowerCompany.Text.Trim().TrimStart();

                            string[] rd3 = null;
                            string ConvertedDt3 = "";

                            if (txtExpanDiverPowerReleaseDate.Text != "")
                            {
                                rd3 = txtExpanDiverPowerReleaseDate.Text.Split('/');
                                ConvertedDt3 = rd3[2].ToString() + "/" + rd3[1].ToString() + "/" + rd3[0].ToString();
                                objvo.ExpanDiverPowerReleaseDate = ConvertedDt3;
                            }
                            else
                            {
                                objvo.ExpanDiverPowerReleaseDate = null;
                            }

                            objvo.ExpanDiverConnectedLoad = txtExpanDiverPowerConnectedLoad.Text.Trim().TrimStart();
                            objvo.ExpanDiverContractedLoad = txtExpanDiverContractedLoad.Text.Trim().TrimStart();
                            objvo.ExpanServiceRateUnit = txtExpanDiverRateUnit.Text.Trim().TrimStart();
                        }
                    }
                    if (ddlWaterSource.SelectedValue == "1")
                    {
                        objvo.waterSource = (txtwaterSource.Text.Trim().TrimStart() != "") ? txtwaterSource.Text.Trim().TrimStart() : null;
                        objvo.waterRequirement = (txtwaterRequirement.Text.Trim().TrimStart() != "") ? txtwaterRequirement.Text.Trim().TrimStart() : null;
                        objvo.waterRateperunit = (txtwaterRateperunit.Text.Trim().TrimStart() != "") ? txtwaterRateperunit.Text.Trim().TrimStart() : null;
                    }

                    try
                    {
                        string Validstatus = ObjCAFClass.InsertIncentivCommonDataTAB3(objvo);
                        if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                        {
                            // objvo.IncentveID = Validstatus;
                            // Session["IncentiveID"] = objvo.IncentveID;
                            AnchTab4_Click(this, EventArgs.Empty);
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
                else if (step == "4")
                {
                    objvo.TurnOver_1stYear = (txtTurnoverYear1.Text.Trim().TrimStart() != "") ? txtTurnoverYear1.Text.Trim().TrimStart() : null;
                    objvo.TurnOver_2ndYear = (txtTurnoverYear2.Text.Trim().TrimStart() != "") ? txtTurnoverYear2.Text.Trim().TrimStart() : null;
                    objvo.TurnOver_3rdYear = (txtTurnoverYear3.Text.Trim().TrimStart() != "") ? txtTurnoverYear3.Text.Trim().TrimStart() : null;

                    objvo.EBITDA_1stYear = (txtEBITDAYear1.Text.Trim().TrimStart() != "") ? txtEBITDAYear1.Text.Trim().TrimStart() : null;
                    objvo.EBITDA_2ndYear = (txtEBITDAYear2.Text.Trim().TrimStart() != "") ? txtEBITDAYear2.Text.Trim().TrimStart() : null;
                    objvo.EBITDA_3rdYear = (txtEBITDAYear3.Text.Trim().TrimStart() != "") ? txtEBITDAYear3.Text.Trim().TrimStart() : null;

                    objvo.Networth_1stYear = (txtNetworthYear1.Text.Trim().TrimStart() != "") ? txtNetworthYear1.Text.Trim().TrimStart() : null;
                    objvo.Networth_2ndYear = (txtNetworthYear2.Text.Trim().TrimStart() != "") ? txtNetworthYear2.Text.Trim().TrimStart() : null;
                    objvo.Networth_3rdYear = (txtNetworthYear3.Text.Trim().TrimStart() != "") ? txtNetworthYear3.Text.Trim().TrimStart() : null;

                    objvo.ReservesSurplus_1stYear = (txtReservesYear1.Text.Trim().TrimStart() != "") ? txtReservesYear1.Text.Trim().TrimStart() : null;
                    objvo.ReservesSurplus_2ndYear = (txtReservesYear2.Text.Trim().TrimStart() != "") ? txtReservesYear2.Text.Trim().TrimStart() : null;
                    objvo.ReservesSurplus_3rdYear = (txtReservesYear3.Text.Trim().TrimStart() != "") ? txtReservesYear3.Text.Trim().TrimStart() : null;

                    objvo.Share_Capital_1stYear = (txtShareCapitalYear1.Text.Trim().TrimStart() != "") ? txtShareCapitalYear1.Text.Trim().TrimStart() : null;
                    objvo.Share_Capital_2ndYear = (txtShareCapitalYear2.Text.Trim().TrimStart() != "") ? txtShareCapitalYear2.Text.Trim().TrimStart() : null;
                    objvo.Share_Capital_3rdYear = (txtShareCapitalYear3.Text.Trim().TrimStart() != "") ? txtShareCapitalYear3.Text.Trim().TrimStart() : null;


                    objvo.ProductionYear1 = lblProductionYear1.Text.Trim().TrimStart();
                    objvo.ProductionQuantity1 = GetDecimalNullValue(txtProductionQuantity1.Text.Trim().TrimStart());
                    objvo.ProductionValue1 = GetDecimalNullValue(txtProductionValue1.Text.Trim().TrimStart());

                    objvo.ProductionYear2 = lblProductionYear2.Text.Trim().TrimStart();
                    objvo.ProductionQuantity2 = GetDecimalNullValue(txtProductionQuantity2.Text.Trim().TrimStart());
                    objvo.ProductionValue2 = GetDecimalNullValue(txtProductionValue2.Text.Trim().TrimStart());

                    objvo.ProductionYear3 = lblProductionYear3.Text.Trim().TrimStart();
                    objvo.ProductionQuantity3 = GetDecimalNullValue(txtProductionQuantity3.Text.Trim().TrimStart());
                    objvo.ProductionValue3 = GetDecimalNullValue(txtProductionValue3.Text.Trim().TrimStart());

                    objvo.PromotersEquity_MF = (txtPromoterEquity.Text.Trim().TrimStart() != "") ? txtPromoterEquity.Text.Trim().TrimStart() : null;
                    objvo.InstitutionEquity_MF = (txtInstitutionsEquity.Text.Trim().TrimStart() != "") ? txtInstitutionsEquity.Text.Trim().TrimStart() : null;
                    objvo.TermsLoans_MF = (txtTearmLoans.Text.Trim().TrimStart() != "") ? txtTearmLoans.Text.Trim().TrimStart() : null;
                    objvo.Others_MF = (txtMeansFinanceOthers.Text.Trim().TrimStart() != "") ? txtMeansFinanceOthers.Text.Trim().TrimStart() : null;
                    objvo.SeedCapital_MF = (txtSeedCapital.Text.Trim().TrimStart() != "") ? txtSeedCapital.Text.Trim().TrimStart() : null;
                    objvo.SubsidyGrantsAgencies_MF = (txtSubsidyagencies.Text.Trim().TrimStart() != "") ? txtSubsidyagencies.Text.Trim().TrimStart() : null;

                    objvo.IsTermLoanAvailed = ddlIsTermLoanAvailed.SelectedValue;

                    objvo.LandApprovedProjectCost = (txtLand2.Text.Trim().TrimStart() != "") ? txtLand2.Text.Trim().TrimStart() : null;
                    objvo.LandLoanSactioned = (txtLand3.Text.Trim().TrimStart() != "") ? txtLand3.Text.Trim().TrimStart() : null;
                    objvo.LandPromotersEquity = (txtLand4.Text.Trim().TrimStart() != "") ? txtLand4.Text.Trim().TrimStart() : null;
                    objvo.LandLoanAmountReleased = (txtLand5.Text.Trim().TrimStart() != "") ? txtLand5.Text.Trim().TrimStart() : null;
                    objvo.LandAssetsValuebyFinInstitution = (txtLand6.Text.Trim().TrimStart() != "") ? txtLand6.Text.Trim().TrimStart() : null;
                    objvo.LandAssetsValuebyCA = (txtLand7.Text.Trim().TrimStart() != "") ? txtLand7.Text.Trim().TrimStart() : null;//txtLand7

                    objvo.BuildingApprovedProjectCost = (txtBuilding2.Text.Trim().TrimStart() != "") ? txtBuilding2.Text.Trim().TrimStart() : null;
                    objvo.BuildingLoanSactioned = (txtBuilding3.Text.Trim().TrimStart() != "") ? txtBuilding3.Text.Trim().TrimStart() : null;
                    objvo.BuildingPromotersEquity = (txtBuilding4.Text.Trim().TrimStart() != "") ? txtBuilding4.Text.Trim().TrimStart() : null;
                    objvo.BuildingLoanAmountReleased = (txtBuilding5.Text.Trim().TrimStart() != "") ? txtBuilding5.Text.Trim().TrimStart() : null;
                    objvo.BuildingAssetsValuebyFinInstitution = (txtBuilding6.Text.Trim().TrimStart() != "") ? txtBuilding6.Text.Trim().TrimStart() : null;
                    objvo.BuildingAssetsValuebyCA = (txtBuilding7.Text.Trim().TrimStart() != "") ? txtBuilding7.Text.Trim().TrimStart() : null;

                    objvo.PlantMachineryApprovedProjectCost = (txtPM2.Text.Trim().TrimStart() != "") ? txtPM2.Text.Trim().TrimStart() : null;
                    objvo.PlantMachineryLoanSactioned = (txtPM3.Text.Trim().TrimStart() != "") ? txtPM3.Text.Trim().TrimStart() : null;
                    objvo.PlantMachineryPromotersEquity = (txtPM4.Text.Trim().TrimStart() != "") ? txtPM4.Text.Trim().TrimStart() : null;
                    objvo.PlantMachineryLoanAmountReleased = (txtPM5.Text.Trim().TrimStart() != "") ? txtPM5.Text.Trim().TrimStart() : null;
                    objvo.PlantMachineryAssetsValuebyFinInstitution = (txtPM6.Text.Trim().TrimStart() != "") ? txtPM6.Text.Trim().TrimStart() : null;
                    objvo.PlantMachineryAssetsValuebyCA = (txtPM7.Text.Trim().TrimStart() != "") ? txtPM7.Text.Trim().TrimStart() : null;

                    objvo.MachineryContingenciesApprovedProjectCost = (txtMCont2.Text.Trim().TrimStart() != "") ? txtMCont2.Text.Trim().TrimStart() : null;
                    objvo.MachineryContingenciesLoanSactioned = (txtMCont3.Text.Trim().TrimStart() != "") ? txtMCont3.Text.Trim().TrimStart() : null;
                    objvo.MachineryContingenciesPromotersEquity = (txtMCont4.Text.Trim().TrimStart() != "") ? txtMCont4.Text.Trim().TrimStart() : null;
                    objvo.MachineryContingenciesLoanAmountReleased = (txtMCont5.Text.Trim().TrimStart() != "") ? txtMCont5.Text.Trim().TrimStart() : null;
                    objvo.MachineryContingenciesAssetsValuebyFinInstitution = (txtMCont6.Text.Trim().TrimStart() != "") ? txtMCont6.Text.Trim().TrimStart() : null;
                    objvo.MachineryContingenciesAssetsValuebyCA = (txtMCont7.Text.Trim().TrimStart() != "") ? txtMCont7.Text.Trim().TrimStart() : null;

                    objvo.ErectionApprovedProjectCost = (txtErec2.Text.Trim().TrimStart() != "") ? txtErec2.Text.Trim().TrimStart() : null;
                    objvo.ErectionLoanSactioned = (txtErec3.Text.Trim().TrimStart() != "") ? txtErec3.Text.Trim().TrimStart() : null;
                    objvo.ErectionPromotersEquity = (txtErec4.Text.Trim().TrimStart() != "") ? txtErec4.Text.Trim().TrimStart() : null;
                    objvo.ErectionLoanAmountReleased = (txtErec5.Text.Trim().TrimStart() != "") ? txtErec5.Text.Trim().TrimStart() : null;
                    objvo.ErectionAssetsValuebyFinInstitution = (txtErec6.Text.Trim().TrimStart() != "") ? txtErec6.Text.Trim().TrimStart() : null;
                    objvo.ErectionAssetsValuebyCA = (txtErec7.Text.Trim().TrimStart() != "") ? txtErec7.Text.Trim().TrimStart() : null;

                    objvo.TechnicalfeasibilityApprovedProjectCost = (txtTFS2.Text.Trim().TrimStart() != "") ? txtTFS2.Text.Trim().TrimStart() : null;
                    objvo.TechnicalfeasibilityLoanSactioned = (txtTFS3.Text.Trim().TrimStart() != "") ? txtTFS3.Text.Trim().TrimStart() : null;
                    objvo.TechnicalfeasibilityPromotersEquity = (txtTFS4.Text.Trim().TrimStart() != "") ? txtTFS4.Text.Trim().TrimStart() : null;
                    objvo.TechnicalfeasibilityLoanAmountReleased = (txtTFS5.Text.Trim().TrimStart() != "") ? txtTFS5.Text.Trim().TrimStart() : null;
                    objvo.TechnicalfeasibilityAssetsValuebyFinInstitution = (txtTFS6.Text.Trim().TrimStart() != "") ? txtTFS6.Text.Trim().TrimStart() : null;
                    objvo.TechnicalfeasibilityAssetsValuebyCA = (txtTFS7.Text.Trim().TrimStart() != "") ? txtTFS7.Text.Trim().TrimStart() : null;

                    objvo.WorkingCapitalApprovedProjectCost = (txtWC2.Text.Trim().TrimStart() != "") ? txtWC2.Text.Trim().TrimStart() : null;
                    objvo.WorkingCapitalLoanSactioned = (txtWC3.Text.Trim().TrimStart() != "") ? txtWC3.Text.Trim().TrimStart() : null;
                    objvo.WorkingCapitalPromotersEquity = (txtWC4.Text.Trim().TrimStart() != "") ? txtWC4.Text.Trim().TrimStart() : null;
                    objvo.WorkingCapitalLoanAmountReleased = (txtWC5.Text.Trim().TrimStart() != "") ? txtWC5.Text.Trim().TrimStart() : null;
                    objvo.WorkingCapitalAssetsValuebyFinInstitution = (txtWC6.Text.Trim().TrimStart() != "") ? txtWC6.Text.Trim().TrimStart() : null;
                    objvo.WorkingCapitalAssetsValuebyCA = (txtWC7.Text.Trim().TrimStart() != "") ? txtWC7.Text.Trim().TrimStart() : null;

                    try
                    {
                        string Validstatus = ObjCAFClass.InsertIncentivCommonDataTAB4(objvo);
                        if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                        {
                            AnchTab5_Click(this, EventArgs.Empty);
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
                else if (step == "5")
                {
                    objvo.BankName = ddlBank.SelectedValue;
                    objvo.BranchName = (txtBranchName.Text.Trim().TrimStart() != "") ? txtBranchName.Text.Trim().TrimStart() : null;
                    objvo.BankAccType = ddlAccountType.SelectedValue;
                    objvo.BankAccName = txtAccountName.Text.Trim().TrimStart();
                    objvo.AccNo = txtAccNumber.Text.Trim().TrimStart();
                    objvo.IFSCCode = (txtIfscCode.Text.Trim().TrimStart() != "") ? txtIfscCode.Text.Trim().TrimStart() : null;
                    objvo.OtherBankName = txtBankName.Text.Trim().TrimStart();
                    objvo.AccountauthorizedPerson = (txtaccountauthorizedPerson.Text.Trim().TrimStart() != "") ? txtaccountauthorizedPerson.Text.Trim().TrimStart() : null;
                    objvo.DesignationOfAccountauthorizedPerson = (txtaccountauthorizedPersonDesignation.Text.Trim().TrimStart() != "") ? txtaccountauthorizedPersonDesignation.Text.Trim().TrimStart() : null;
                    try
                    {
                        string Validstatus = ObjCAFClass.InsertIncentivCommonDataTAB5(objvo);
                        if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                        {
                            AnchTab6_Click(this, EventArgs.Empty);
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
        protected void rblCaste_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rblCaste.SelectedValue == "2")
                {
                    divsubcaste.Visible = true;
                }
                else
                {
                    divsubcaste.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
            }
        }

        protected void ddlUnitstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlUnitstate.SelectedValue.ToString() != "--Select--")
                {
                    getdistrictsUnit();

                    ddlUnitDIst.Visible = true;
                    ddlUnitMandal.Visible = true;
                    ddlVillageunit.Visible = true;
                }
                else
                {
                    ddlUnitstate.Items.Clear();
                    ddlUnitstate.Items.Insert(0, "--Select--");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddloffcstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddloffcstate.SelectedValue.ToString() != "--Select--")
                {
                    if (ddloffcstate.SelectedValue.ToString() == "31")
                    {
                        //getdistrictsOffc();
                        BindDistricts1();

                        txtofficedist.Visible = false;
                        txtoffcicemandal.Visible = false;
                        txtofficeviiage.Visible = false;

                        ddlOffcDIst.Visible = true;
                        ddlOffcMandal.Visible = true;
                        ddlOffcVil.Visible = true;
                    }
                    else
                    {
                        txtofficedist.Visible = true;
                        txtoffcicemandal.Visible = true;
                        txtofficeviiage.Visible = true;

                        ddlOffcDIst.Visible = false;
                        ddlOffcMandal.Visible = false;
                        ddlOffcVil.Visible = false;
                    }
                }
                else
                {
                    ddlUnitstate.Items.Clear();
                    AddSelect(ddlUnitstate);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddldistrictunit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUnitDIst.SelectedIndex == 0)
            {
                ddlUnitMandal.Items.Clear();
                // ddlUnitMandal.Items.Insert(0, "--Mandal--");
                AddSelect(ddlUnitMandal);
            }
            else
            {
                ddlUnitMandal.Items.Clear();
                DataSet dsm = new DataSet();
                // added newly for testing only

                //if (ddlUnitDIst.SelectedValue == "Medchal")
                //{
                //    ddlUnitDIst.SelectedValue = "20";
                //}

                dsm = Objgeneral.GetMandals(ddlUnitDIst.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlUnitMandal.DataSource = dsm.Tables[0];
                    ddlUnitMandal.DataValueField = "Mandal_Id";
                    ddlUnitMandal.DataTextField = "Manda_lName";
                    ddlUnitMandal.DataBind();
                    // ddlUnitMandal.Items.Insert(0, "--Mandal--");
                    AddSelect(ddlUnitMandal);
                }
                else
                {
                    ddlUnitMandal.Items.Clear();
                    //ddlUnitMandal.Items.Insert(0, "--Mandal--");
                    AddSelect(ddlUnitMandal);
                }
            }
        }
        protected void ddlUnitMandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUnitMandal.SelectedIndex == 0)
            {

                ddlVillageunit.Items.Clear();
                // ddlVillageunit.Items.Insert(0, "--Village--");
                AddSelect(ddlVillageunit);
            }
            else
            {
                ddlVillageunit.Items.Clear();
                DataSet dsv = new DataSet();
                dsv = Objgeneral.GetVillages(ddlUnitMandal.SelectedValue);
                if (dsv.Tables[0].Rows.Count > 0)
                {
                    ddlVillageunit.DataSource = dsv.Tables[0];
                    ddlVillageunit.DataValueField = "Village_Id";
                    ddlVillageunit.DataTextField = "Village_Name";
                    ddlVillageunit.DataBind();
                    AddSelect(ddlVillageunit);
                    //  ddlVillageunit.Items.Insert(0, "--Village--");
                }
                else
                {
                    ddlVillageunit.Items.Clear();
                    // ddlVillageunit.Items.Insert(0, "--Village--");
                    AddSelect(ddlVillageunit);
                }
            }
        }
        protected void ddldistrictoffc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOffcDIst.SelectedIndex == 0)
            {
                ddlOffcMandal.Items.Clear();
                // ddlOffcMandal.Items.Insert(0, "--Mandal--");
                AddSelect(ddlOffcMandal);
                //ChkWater_reg_from.Items.Clear();
                //ChkWater_reg_from.Items.Insert(0, new ListItem("New Bore well", "New Bore well"));
                //ChkWater_reg_from.Items.Insert(1, new ListItem("HMWS & SB", "HMWS & SB"));
                //ChkWater_reg_from.Items.Insert(2, new ListItem("Rivers/Canals", "Rivers/Canals"));
            }
            else
            {
                ddlOffcMandal.Items.Clear();
                DataSet dsm = new DataSet();
                dsm = Objgeneral.GetMandals(ddlOffcDIst.SelectedValue);
                if (dsm.Tables[0].Rows.Count > 0)
                {
                    ddlOffcMandal.DataSource = dsm.Tables[0];
                    ddlOffcMandal.DataValueField = "Mandal_Id";
                    ddlOffcMandal.DataTextField = "Manda_lName";
                    ddlOffcMandal.DataBind();
                    //ddlOffcMandal.Items.Insert(0, "--Mandal--");
                    AddSelect(ddlOffcMandal);
                }
                else
                {
                    ddlOffcMandal.Items.Clear();
                    //ddlOffcMandal.Items.Insert(0, "--Mandal--");
                    AddSelect(ddlOffcMandal);
                }
            }
        }
        protected void ddloffcmandal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOffcMandal.SelectedIndex == 0)
            {

                ddlOffcVil.Items.Clear();
                // ddlOffcMandal.Items.Insert(0, "--Village--");
                AddSelect(ddlOffcVil);
            }
            else
            {
                ddlOffcVil.Items.Clear();
                DataSet dsv = new DataSet();
                dsv = Objgeneral.GetVillages(ddlOffcMandal.SelectedValue);
                if (dsv.Tables[0].Rows.Count > 0)
                {
                    ddlOffcVil.DataSource = dsv.Tables[0];
                    ddlOffcVil.DataValueField = "Village_Id";
                    ddlOffcVil.DataTextField = "Village_Name";
                    ddlOffcVil.DataBind();
                    //ddlOffcVil.Items.Insert(0, "--Village--");
                    AddSelect(ddlOffcVil);
                }
                else
                {
                    ddlOffcVil.Items.Clear();
                    //ddlOffcVil.Items.Insert(0, "--Village--");
                    AddSelect(ddlOffcVil);
                }
            }
        }

        protected void ddlOrgType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlOrgType.SelectedValue == "1")
            {
                lblDetailsofPatners.Text = "Details of the Proprietor :";

                txtshare.Text = "100";
                txtshare.Enabled = false;

            }
            else if (ddlOrgType.SelectedValue == "2")
            {
                lblDetailsofPatners.Text = "Details of the Partner(s) :";
            }
            else if (ddlOrgType.SelectedValue == "3")
            {
                lblDetailsofPatners.Text = "Details of the Pvt Ltd :";

            }
            else if (ddlOrgType.SelectedValue == "4")
            {
                lblDetailsofPatners.Text = "Details of the Public Limited :";
            }
            else if (ddlOrgType.SelectedValue == "5")
            {
                lblDetailsofPatners.Text = "Details of the 	Co-Operative Limited :";
            }
            else if (ddlOrgType.SelectedValue == "6")
            {
                lblDetailsofPatners.Text = "Details of the LLP :";
            }
            else if (ddlOrgType.SelectedValue == "7")
            {
                lblDetailsofPatners.Text = "Details of the Trust :";
            }
            //1	Proprietary
            //2	Partnership
            //3	Pvt Ltd
            //4	Public Limited
            //5	Co-Operative
            //6	LLP
            //7	Trust
            if (ddlOrgType.SelectedValue != "0")
            {
                ddlDirectorDesignation.Items.Clear();

                txtshare.Enabled = true;
                DataSet ds = new DataSet();
                ds = Objgeneral.GetAuthorisedSignatory(ddlOrgType.SelectedValue);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlDirectorDesignation.DataSource = ds.Tables[0];
                    ddlDirectorDesignation.DataTextField = "Disignation";
                    ddlDirectorDesignation.DataValueField = "ID";
                    ddlDirectorDesignation.DataBind();
                }
                AddSelect(ddlDirectorDesignation);
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    ddlAuthorisedSignDesignation.DataSource = ds.Tables[1];
                    ddlAuthorisedSignDesignation.DataTextField = "Disignation";
                    ddlAuthorisedSignDesignation.DataValueField = "ID";
                    ddlAuthorisedSignDesignation.DataBind();
                }
                AddSelect(ddlAuthorisedSignDesignation);
            }
            lblDetailsofPatners.Text = "Details of Proprietor/Managing Partner/ Managing Director";
        }

        protected void ddlindustryStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                trFixedcap.Visible = true;
                if (ddlIndustryStatus.SelectedValue == "1")
                {
                    Div_CurrentInvestment1.Visible = false;
                    Div_CurrentInvestment.Visible = false;

                    divpmnote.Visible = false;
                    lblIndustryHeading.Text = "New Enterprise Product Details : ";

                    trNewIndustry.Visible = true;
                    trexpansionnew.Visible = false;
                    trIndustryExpansionType.Visible = false;

                    DivNewIndustry.Visible = true;
                    DivExpIndustry.Visible = false;
                    headingNewIndustry.InnerHtml = "New Enterprise";
                    headingExpIndustry.InnerHtml = "Expansion of Enterprise";
                    lblindustryTypeHeader.InnerHtml = "New Enterprise";
                    // Investment 

                    trFixedCapitalexpansion.Visible = false;
                    trFixedCapitalland.Visible = false;
                    trFixedCapitalBuilding.Visible = false;
                    trFixedCapitalMach.Visible = false;


                    Td3.Visible = false;
                    Td4.Visible = false;
                    tdIpassLandExp.Visible = false;
                    tdIpassBuildingExp.Visible = false;
                    tdIpassPlantMachineExp.Visible = false;
                    tdtotIpassExp.Visible = false;
                    thIpassExp.Visible = false;

                    trFixedCapitalexpnPercent.Visible = false;
                    txtbuildcapacityPercet.Visible = false;
                    trFixedCapitMachPercent.Visible = false;
                    trFixedCapitBuildPercent.Visible = false;


                    thApprovedProjectCost.InnerHtml = "New Enterprise Value (in Rs.)";
                    //Td1.Visible = false;
                    //Td2.Visible = false;
                    // Power
                    ddlIspowApplicable_SelectedIndexChanged(sender, e);

                    HplNewExpInvDetails.Text = "Click Here to Fill New Enterprise Actual Land & Building Investment Details";
                    DivInvoiceTypes.Visible = false;
                    rbtnInvoiceTypes_SelectedIndexChanged(sender, e);
                }
                else if (ddlIndustryStatus.SelectedValue == "2")
                {
                    DivIndsStatusNote.Visible = true;

                    Div_CurrentInvestment1.Visible = true;
                    Div_CurrentInvestment.Visible = true;

                    divpmnote.Visible = true;
                    lblIndustryHeading.Text = "Existing of Enterprise Product Details : ";
                    lblexpansionnewHeading.Text = "Expansion of Enterprise Product Details";

                    thApprovedProjectCost.InnerHtml = "Existing of Enterprise Value (in Rs.)";
                    trFixedCapitalexpansion.InnerHtml = "Expansion of Enterprise Value (in Rs.)";
                    trFixedCapitalexpnPercent.InnerHtml = "% of Increase Under " + ddlIndustryStatus.SelectedItem.Text;
                    lblindustryTypeHeader.InnerHtml = "Expansion of Enterprise";

                    hAbstractheader.InnerHtml = "Abstract - " + ddlIndustryStatus.SelectedItem.Text + "of Enterprise Plant and Machinery Details";

                    trNewIndustry.Visible = true;
                    trexpansionnew.Visible = true;
                    trIndustryExpansionType.Visible = true;

                    DivNewIndustry.Visible = true;
                    DivExpIndustry.Visible = true;
                    headingNewIndustry.InnerHtml = "Existing of Enterprise";
                    headingExpIndustry.InnerHtml = "Expansion of Enterprise";

                    trFixedCapitalexpansion.Visible = true;
                    trFixedCapitalland.Visible = true;
                    trFixedCapitalBuilding.Visible = true;
                    trFixedCapitalMach.Visible = true;

                    Td3.Visible = true;
                    Td4.Visible = true;
                    tdIpassLandExp.Visible = true;
                    tdIpassBuildingExp.Visible = true;
                    tdIpassPlantMachineExp.Visible = true;
                    tdtotIpassExp.Visible = true;
                    thIpassExp.Visible = true;

                    trFixedCapitalexpnPercent.Visible = true;
                    txtbuildcapacityPercet.Visible = true;
                    trFixedCapitMachPercent.Visible = true;
                    trFixedCapitBuildPercent.Visible = true;

                    //Td1.Visible = true;
                    //Td2.Visible = true;
                    // Power
                    ddlIspowApplicable_SelectedIndexChanged(sender, e);
                    lblexistingpower.Text = "Existing of Enterprise production details";
                    lblexpandiverpower.Text = ddlIndustryStatus.SelectedItem.Text + " details";

                    HplNewExpInvDetails.Text = "Click Here to Fill " + ddlIndustryStatus.SelectedItem.Text + " of Enterprise Actual Land, Building & Plant and Machinary Investment Details";
                    DivInvoiceTypes.Visible = true;
                    rbtnInvoiceTypes_SelectedIndexChanged(sender, e);
                }
                else if (ddlIndustryStatus.SelectedValue == "3" || ddlIndustryStatus.SelectedValue == "4")
                {
                    Div_CurrentInvestment1.Visible = true;
                    Div_CurrentInvestment.Visible = true;

                    lblIndustryHeading.Text = "Existing of Enterprise Product Details : ";
                    lblexpansionnewHeading.Text = ddlIndustryStatus.SelectedItem.Text + " of Enterprise Product Details";

                    thApprovedProjectCost.InnerHtml = "Existing of Enterprise Value (in Rs.)";
                    trFixedCapitalexpansion.InnerHtml = ddlIndustryStatus.SelectedItem.Text + " of Enterprise Value (in Rs.)";
                    trFixedCapitalexpnPercent.InnerHtml = "% of Increase Under " + ddlIndustryStatus.SelectedItem.Text;
                    lblindustryTypeHeader.InnerHtml = ddlIndustryStatus.SelectedItem.Text + " of Enterprise";

                    hAbstractheader.InnerHtml = "Abstract - " + ddlIndustryStatus.SelectedItem.Text + "of Enterprise Plant and Machinery Details";

                    trNewIndustry.Visible = true;
                    trIndustryExpansionType.Visible = false;
                    trexpansionnew.Visible = true;

                    DivNewIndustry.Visible = true;
                    DivExpIndustry.Visible = true;
                    headingNewIndustry.InnerHtml = "Existing of Enterprise";
                    headingExpIndustry.InnerHtml = ddlIndustryStatus.SelectedItem.Text + "of Enterprise";

                    trFixedCapitalexpansion.Visible = true;
                    trFixedCapitalland.Visible = true;
                    trFixedCapitalBuilding.Visible = true;
                    trFixedCapitalMach.Visible = true;

                    Td3.Visible = true;
                    Td4.Visible = true;
                    tdIpassLandExp.Visible = true;
                    tdIpassBuildingExp.Visible = true;
                    tdIpassPlantMachineExp.Visible = true;
                    tdtotIpassExp.Visible = true;
                    thIpassExp.Visible = true;

                    trFixedCapitalexpnPercent.Visible = true;
                    txtbuildcapacityPercet.Visible = true;
                    trFixedCapitMachPercent.Visible = true;
                    trFixedCapitBuildPercent.Visible = true;

                    //Td1.Visible = true;
                    //Td2.Visible = true;
                    // Power
                    ddlIspowApplicable_SelectedIndexChanged(sender, e);
                    lblexistingpower.Text = "Existing of Enterprise production details";
                    lblexpandiverpower.Text = ddlIndustryStatus.SelectedItem.Text + " details";

                    HplNewExpInvDetails.Text = "Click Here to Fill " + ddlIndustryStatus.SelectedItem.Text + " of Enterprise Land, Building & Plant and Machinary Details";
                    DivInvoiceTypes.Visible = true;
                    rbtnInvoiceTypes_SelectedIndexChanged(sender, e);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void ddlIspowApplicable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlIspowApplicable.SelectedItem.Text.ToUpper() == "NO")
            {
                trpower.Visible = false;
                tblpower1.Visible = false;
                tblpower2.Visible = false;
            }
            if (ddlIspowApplicable.SelectedItem.Text.ToUpper() == "YES")
            {
                trpower.Visible = true;
                if (ddlIndustryStatus.SelectedValue == "1")
                {
                    tblpower1.Visible = true;
                    tblpower2.Visible = false;
                }
                if (ddlIndustryStatus.SelectedValue == "2" || ddlIndustryStatus.SelectedValue == "3" || ddlIndustryStatus.SelectedValue == "4")
                {
                    tblpower1.Visible = false;
                    tblpower2.Visible = true;
                }

            }
        }
        protected void ddlWaterSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlWaterSource.SelectedItem.Text.ToUpper() == "NO")
            {
                DivWater.Visible = false;
                DivWater1.Visible = false;
            }
            if (ddlWaterSource.SelectedItem.Text.ToUpper() == "YES")
            {
                DivWater.Visible = true;
                DivWater1.Visible = true;
            }
        }
        protected void ddlquantityin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlquantityin.SelectedValue.ToString() == "Others")
            {
                txtunit.Visible = true;
                ddlquantityin.Visible = true;
            }
            else
            {
                txtunit.Visible = false;
                ddlquantityin.Visible = true;
            }

        }

        protected void ddlquantityinExpan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlquantityinExpan.SelectedValue.ToString() == "Others")
            {
                txtunitExpan.Visible = true;
                ddlquantityinExpan.Visible = true;
            }
            else
            {
                txtunitExpan.Visible = false;
                ddlquantityinExpan.Visible = true;
            }

        }
        protected void ddlIsTermLoanAvailed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlIsTermLoanAvailed.SelectedValue == "1")
            {
                tblTermLoanDtls.Visible = true;
            }
            else
            {
                tblTermLoanDtls.Visible = false;
            }
        }

        protected void txtLand2_TextChanged(object sender, EventArgs e)
        {
            CalculateInvSanctionTermloan("1");
        }

        protected void txtLand3_TextChanged(object sender, EventArgs e)
        {
            CalculateInvSanctionTermloan("2");
        }

        protected void txtLand4_TextChanged(object sender, EventArgs e)
        {
            CalculateInvSanctionTermloan("3");
        }

        protected void txtLand5_TextChanged(object sender, EventArgs e)
        {
            CalculateInvSanctionTermloan("4");
        }

        protected void txtLand6_TextChanged(object sender, EventArgs e)
        {
            CalculateInvSanctionTermloan("5");
        }

        protected void txtLand7_TextChanged1(object sender, EventArgs e)
        {
            CalculateInvSanctionTermloan("6");
        }

        #region Methods
        public void CalculateInvSanctionTermloan(string Step)
        {
            try
            {
                decimal FinalTotal = 0;
                decimal Land2 = 0, Building2 = 0, PM2 = 0, MCont2 = 0, Erec2 = 0, TFS2 = 0, WC2 = 0;
                if (Step == "1")
                {
                    if (txtLand2.Text != "") { Land2 = Convert.ToDecimal(txtLand2.Text.Trim()); } else { Land2 = 0; }
                    if (txtBuilding2.Text != "") { Building2 = Convert.ToDecimal(txtBuilding2.Text.Trim()); } else { Building2 = 0; }
                    if (txtPM2.Text != "") { PM2 = Convert.ToDecimal(txtPM2.Text.Trim()); } else { PM2 = 0; }
                    if (txtMCont2.Text != "") { MCont2 = Convert.ToDecimal(txtMCont2.Text.Trim()); } else { MCont2 = 0; }
                    if (txtErec2.Text != "") { Erec2 = Convert.ToDecimal(txtErec2.Text.Trim()); } else { Erec2 = 0; }
                    if (txtTFS2.Text != "") { TFS2 = Convert.ToDecimal(txtTFS2.Text.Trim()); } else { TFS2 = 0; }
                    if (txtWC2.Text != "") { WC2 = Convert.ToDecimal(txtWC2.Text.Trim()); } else { WC2 = 0; }
                    FinalTotal = Land2 + Building2 + PM2 + MCont2 + Erec2 + TFS2 + WC2;
                    lbltotal2.Text = FinalTotal.ToString();
                }
                else if (Step == "2")
                {
                    decimal Land3 = 0, Building3 = 0, PM3 = 0, MCont3 = 0, Erec3 = 0, TFS3 = 0, WC3 = 0;
                    if (txtLand3.Text != "") { Land3 = Convert.ToDecimal(txtLand3.Text.Trim()); } else { Land3 = 0; }
                    if (txtBuilding3.Text != "") { Building3 = Convert.ToDecimal(txtBuilding3.Text.Trim()); } else { Building3 = 0; }
                    if (txtPM3.Text != "") { PM3 = Convert.ToDecimal(txtPM3.Text.Trim()); } else { PM3 = 0; }
                    if (txtMCont3.Text != "") { MCont3 = Convert.ToDecimal(txtMCont3.Text.Trim()); } else { MCont3 = 0; }
                    if (txtErec3.Text != "") { Erec3 = Convert.ToDecimal(txtErec3.Text.Trim()); } else { Erec3 = 0; }
                    if (txtTFS3.Text != "") { TFS3 = Convert.ToDecimal(txtTFS3.Text.Trim()); } else { TFS3 = 0; }
                    if (txtWC3.Text != "") { WC3 = Convert.ToDecimal(txtWC3.Text.Trim()); } else { WC3 = 0; }
                    FinalTotal = Land3 + Building3 + PM3 + MCont3 + Erec3 + TFS3 + WC3;
                    lbltotal3.Text = FinalTotal.ToString();
                }
                else if (Step == "3")
                {
                    decimal Land4 = 0, Building4 = 0, PM4 = 0, MCont4 = 0, Erec4 = 0, TFS4 = 0, WC4 = 0;
                    if (txtLand4.Text != "") { Land4 = Convert.ToDecimal(txtLand4.Text.Trim()); } else { Land4 = 0; }
                    if (txtBuilding4.Text != "") { Building4 = Convert.ToDecimal(txtBuilding4.Text.Trim()); } else { Building4 = 0; }
                    if (txtPM4.Text != "") { PM4 = Convert.ToDecimal(txtPM4.Text.Trim()); } else { PM4 = 0; }
                    if (txtMCont4.Text != "") { MCont4 = Convert.ToDecimal(txtMCont4.Text.Trim()); } else { MCont4 = 0; }
                    if (txtErec4.Text != "") { Erec4 = Convert.ToDecimal(txtErec4.Text.Trim()); } else { Erec4 = 0; }
                    if (txtTFS4.Text != "") { TFS4 = Convert.ToDecimal(txtTFS4.Text.Trim()); } else { TFS4 = 0; }
                    if (txtWC4.Text != "") { WC4 = Convert.ToDecimal(txtWC4.Text.Trim()); } else { WC4 = 0; }
                    FinalTotal = Land4 + Building4 + PM4 + MCont4 + Erec4 + TFS4 + WC4;
                    lbltotal4.Text = FinalTotal.ToString();
                }
                else if (Step == "4")
                {
                    decimal Land5 = 0, Building5 = 0, PM5 = 0, MCont5 = 0, Erec5 = 0, TFS5 = 0, WC5 = 0;
                    if (txtLand5.Text != "") { Land5 = Convert.ToDecimal(txtLand5.Text.Trim()); } else { Land5 = 0; }
                    if (txtBuilding5.Text != "") { Building5 = Convert.ToDecimal(txtBuilding5.Text.Trim()); } else { Building5 = 0; }
                    if (txtPM5.Text != "") { PM5 = Convert.ToDecimal(txtPM5.Text.Trim()); } else { PM5 = 0; }
                    if (txtMCont5.Text != "") { MCont5 = Convert.ToDecimal(txtMCont5.Text.Trim()); } else { MCont5 = 0; }
                    if (txtErec5.Text != "") { Erec5 = Convert.ToDecimal(txtErec5.Text.Trim()); } else { Erec5 = 0; }
                    if (txtTFS5.Text != "") { TFS5 = Convert.ToDecimal(txtTFS5.Text.Trim()); } else { TFS5 = 0; }
                    if (txtWC5.Text != "") { WC5 = Convert.ToDecimal(txtWC5.Text.Trim()); } else { WC5 = 0; }
                    FinalTotal = Land5 + Building5 + PM5 + MCont5 + Erec5 + TFS5 + WC5;
                    lbltotal5.Text = FinalTotal.ToString();
                }
                else if (Step == "5")
                {
                    decimal Land6 = 0, Building6 = 0, PM6 = 0, MCont6 = 0, Erec6 = 0, TFS6 = 0, WC6 = 0;
                    if (txtLand6.Text != "") { Land6 = Convert.ToDecimal(txtLand6.Text.Trim()); } else { Land6 = 0; }
                    if (txtBuilding6.Text != "") { Building6 = Convert.ToDecimal(txtBuilding6.Text.Trim()); } else { Building6 = 0; }
                    if (txtPM6.Text != "") { PM6 = Convert.ToDecimal(txtPM6.Text.Trim()); } else { PM6 = 0; }
                    if (txtMCont6.Text != "") { MCont6 = Convert.ToDecimal(txtMCont6.Text.Trim()); } else { MCont6 = 0; }
                    if (txtErec6.Text != "") { Erec6 = Convert.ToDecimal(txtErec6.Text.Trim()); } else { Erec6 = 0; }
                    if (txtTFS6.Text != "") { TFS6 = Convert.ToDecimal(txtTFS6.Text.Trim()); } else { TFS6 = 0; }
                    if (txtWC6.Text != "") { WC6 = Convert.ToDecimal(txtWC6.Text.Trim()); } else { WC6 = 0; }
                    FinalTotal = Land6 + Building6 + PM6 + MCont6 + Erec6 + TFS6 + WC6;
                    lbltotal6.Text = FinalTotal.ToString();
                }
                else if (Step == "6")
                {
                    decimal Land7 = 0, Building7 = 0, PM7 = 0, MCont7 = 0, Erec7 = 0, TFS7 = 0, WC7 = 0;
                    if (txtLand7.Text != "") { Land7 = Convert.ToDecimal(txtLand7.Text.Trim()); } else { Land7 = 0; }
                    if (txtBuilding7.Text != "") { Building7 = Convert.ToDecimal(txtBuilding7.Text.Trim()); } else { Building7 = 0; }
                    if (txtPM7.Text != "") { PM7 = Convert.ToDecimal(txtPM7.Text.Trim()); } else { PM7 = 0; }
                    if (txtMCont7.Text != "") { MCont7 = Convert.ToDecimal(txtMCont7.Text.Trim()); } else { MCont7 = 0; }
                    if (txtErec7.Text != "") { Erec7 = Convert.ToDecimal(txtErec7.Text.Trim()); } else { Erec7 = 0; }
                    if (txtTFS7.Text != "") { TFS7 = Convert.ToDecimal(txtTFS7.Text.Trim()); } else { TFS7 = 0; }
                    if (txtWC7.Text != "") { WC7 = Convert.ToDecimal(txtWC7.Text.Trim()); } else { WC7 = 0; }
                    FinalTotal = Land7 + Building7 + PM7 + MCont7 + Erec7 + TFS7 + WC7;
                    lbltotal7.Text = FinalTotal.ToString();
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }

        }
        public void BindConstitutionUnit()
        {
            try
            {
                DataSet dsdorg = new DataSet();
                dsdorg = objFetch.FetchConstitutionUnit();
                if (dsdorg != null && dsdorg.Tables.Count > 0 && dsdorg.Tables[0].Rows.Count > 0)
                {
                    ddlOrgType.DataSource = dsdorg.Tables[0];
                    ddlOrgType.DataValueField = "CunitId";
                    ddlOrgType.DataTextField = "ConstitutionUnit";
                    ddlOrgType.DataBind();
                    ddlOrgType.Items.Insert(0, "--Select--");
                }
                else
                {
                    ddlOrgType.Items.Insert(0, "--Select--");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void BindQualification()
        {
            try
            {
                ddlEducationalQualificationPatners.Items.Clear();
                DataSet dsdorg = new DataSet();
                dsdorg = Objgeneral.GetEducationQualification();
                if (dsdorg != null && dsdorg.Tables.Count > 0 && dsdorg.Tables[0].Rows.Count > 0)
                {
                    ddlEducationalQualificationPatners.DataSource = dsdorg.Tables[0];
                    ddlEducationalQualificationPatners.DataValueField = "ID";
                    ddlEducationalQualificationPatners.DataTextField = "Qualification";
                    ddlEducationalQualificationPatners.DataBind();
                }
                AddSelect(ddlEducationalQualificationPatners);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void BindUnitAddressStates()
        {
            try
            {
                ddlUnitstate.Items.Clear();
                DataSet ds = new DataSet();
                ds = Objgeneral.getStates();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlUnitstate.DataSource = ds.Tables[0];
                    ddlUnitstate.DataTextField = "State_Name";
                    ddlUnitstate.DataValueField = "State_id";
                    ddlUnitstate.DataBind();
                }

                AddSelect(ddlUnitstate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void BindOfficeAddressStates()
        {
            try
            {
                ddloffcstate.Items.Clear();
                DataSet ds = new DataSet();
                ds = Objgeneral.getStates();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddloffcstate.DataSource = ds.Tables[0];
                    ddloffcstate.DataTextField = "State_Name";
                    ddloffcstate.DataValueField = "State_id";
                    ddloffcstate.DataBind();
                }
                AddSelect(ddloffcstate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void getdistrictsUnit()
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = Objgeneral.GetDistrictsbystate(ddlUnitstate.SelectedValue.ToString());
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    ddlUnitDIst.DataSource = dsnew.Tables[0];
                    ddlUnitDIst.DataTextField = "District_Name";
                    ddlUnitDIst.DataValueField = "District_Id";
                    ddlUnitDIst.DataBind();
                }
                AddSelect(ddlUnitDIst);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void getdistrictsOffc()
        {
            try
            {
                DataSet dsnew = new DataSet();

                dsnew = Objgeneral.GetDistrictsbystate(ddlOffcDIst.SelectedValue.ToString());
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    ddlOffcDIst.DataSource = dsnew.Tables[0];
                    ddlOffcDIst.DataTextField = "District_Name";
                    ddlOffcDIst.DataValueField = "District_Id";
                    ddlOffcDIst.DataBind();
                }
                AddSelect(ddlOffcDIst);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void BindDistricts1()
        {
            try
            {
                DataSet dsd = new DataSet();
                ddlOffcDIst.Items.Clear();
                dsd = Objgeneral.GetDistrictsWithoutHYD();
                if (dsd != null && dsd.Tables.Count > 0 && dsd.Tables[0].Rows.Count > 0)
                {
                    ddlOffcDIst.DataSource = dsd.Tables[0];
                    ddlOffcDIst.DataValueField = "District_Id";
                    ddlOffcDIst.DataTextField = "District_Name";
                    ddlOffcDIst.DataBind();
                    AddSelect(ddlOffcDIst);
                }
                else
                {
                    AddSelect(ddlOffcDIst);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindBankAccountType()
        {
            DataSet ds = new DataSet();
            ds = Objgeneral.getBankAccountTypeMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlAccountType.DataSource = ds.Tables[0];
                ddlAccountType.DataTextField = "AccountTypeName";
                ddlAccountType.DataValueField = "AccountTypeID";
                ddlAccountType.DataBind();
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

        public string ValidateDates(string Level)
        {
            string ErrorMsg = "";
            DataSet ds = new DataSet(); string IsDcp = "N"; string DCPDate = "";
            ds = GetDcpCondition(Session["IncentiveID"].ToString());
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                IsDcp = ds.Tables[0].Rows[0]["Allow_DCP_Condition"].ToString();
                DCPDate = ds.Tables[0].Rows[0]["Allow_DCP_Date"].ToString();
            }

            DateTime? DateofCommencement;
            DateTime? DateofCommencementNew;
            if (ddlIndustryStatus.SelectedValue == "1")
            {
                if (txtDateofCommencement.Text != "")
                {
                    DateofCommencement = Convert.ToDateTime(GetFromatedDateDDMMYYYY(txtDateofCommencement.Text.Trim()));
                }
                else
                {
                    DateofCommencement = null;
                }
            }
            else
            {
                if (txtDateofCommencementExp.Text != "")
                {
                    DateofCommencement = Convert.ToDateTime(GetFromatedDateDDMMYYYY(txtDateofCommencementExp.Text.Trim()));
                }
                else
                {
                    DateofCommencement = null;
                }
            }

            DateofCommencementNew = Convert.ToDateTime(GetFromatedDateDDMMYYYY(txtDateofCommencement.Text.Trim()));

            if (HiddenFieldEnterpriseCategory.Value.ToUpper().Trim() == "A1" || HiddenFieldEnterpriseCategory.Value.ToUpper().Trim() == "A2")
            {
                DateofCommencementNew = Convert.ToDateTime(DateofCommencementNew).AddMonths(12);
            }
            else if (HiddenFieldEnterpriseCategory.Value.ToUpper().Trim() == "A3" || HiddenFieldEnterpriseCategory.Value.ToUpper().Trim() == "A4" || HiddenFieldEnterpriseCategory.Value.ToUpper().Trim() == "A5")
            {
                DateofCommencementNew = Convert.ToDateTime(DateofCommencementNew).AddMonths(24);
            }
            if (Level == "1")
            {
                if (DateofCommencement != null && txtDateOfIncorporation.Text.TrimStart().TrimEnd().Trim() != "")
                {
                    DateTime? DateOfIncorporation;
                    if (txtDateOfIncorporation.Text != "")
                    {
                        DateOfIncorporation = Convert.ToDateTime(GetFromatedDateDDMMYYYY(txtDateOfIncorporation.Text.Trim()));
                    }
                    else
                    {
                        DateOfIncorporation = null;
                    }
                    string DCP = System.Configuration.ConfigurationManager.AppSettings["DCPDateValidity"];
                    DateTime Date1 = Convert.ToDateTime("2017/08/18");
                    DateTime Date2 = Convert.ToDateTime(DCP);
                    /*DateTime Date2 = Convert.ToDateTime("2023/08/31");*/

                    if (DateofCommencement >= Date1 && DateofCommencement <= Date2)
                    {
                        if (DateofCommencement < DateOfIncorporation)
                        {
                            ErrorMsg = ". Date of Commencement of Production of " + ddlIndustryStatus.SelectedItem.Text + " should be greater than Date of Incorporation\\n";
                        }
                    }
                    else
                    {
                        ErrorMsg = ". The Date of Commencement of Production of" + ddlIndustryStatus.SelectedItem.Text + " Should Between 18/08/2017 and 31/08/2024\\n";
                    }
                }
            }
            else if (Level == "2")
            {
                if (DateofCommencementNew != null && txtMachineLoadingDate.Text.TrimStart().TrimEnd().Trim() != "")
                {
                    DateTime? MachineLoadingDate;
                    if (txtMachineLoadingDate.Text != "")
                    {
                        MachineLoadingDate = Convert.ToDateTime(GetFromatedDateDDMMYYYY(txtMachineLoadingDate.Text.Trim()));
                    }
                    else
                    {
                        MachineLoadingDate = null;
                    }
                    if ((IsDcp == "Y") && (DateTime.Now.Date <= Convert.ToDateTime(DCPDate)))
                    {

                    }
                    else
                    {
                        if (DateofCommencementNew < MachineLoadingDate)
                        {
                            ErrorMsg = ". Date of Commencement of Production of New/Existing Industry should be greater than the Machine Landing Date\\n";
                        }
                    }

                }
            }
            else if (Level == "3")
            {
                if ((IsDcp == "Y") && (DateTime.Now.Date <= Convert.ToDateTime(DCPDate)))
                {

                }
                else
                {
                    if (DateofCommencementNew != null && txtVaivleDate.Text.TrimStart().TrimEnd().Trim() != "")
                    {
                        DateTime WaybillDate = Convert.ToDateTime(GetFromatedDateDDMMYYYY(txtVaivleDate.Text.Trim()));

                        if (DateofCommencementNew < WaybillDate)
                        {
                            ErrorMsg = ". Date of Commencement of Production of New/Existing Industry should be greater than the Waybill Date\\n";
                        }
                    }
                }
            }
            else if (Level == "4")
            {
                if (DateofCommencementNew != null && txtNewPowerReleaseDate.Text.TrimStart().TrimEnd().Trim() != "")
                {
                    DateTime NewPowerReleaseDate = Convert.ToDateTime(GetFromatedDateDDMMYYYY(txtNewPowerReleaseDate.Text.Trim()));

                    if (DateofCommencementNew < NewPowerReleaseDate)
                    {
                        ErrorMsg = ". Date of Commencement of Production of New Industry should be greater than the Power Release Date\\n";
                    }
                }
            }
            else if (Level == "5")
            {
                if (DateofCommencementNew != null && txtExistingPowerReleaseDate.Text.TrimStart().TrimEnd().Trim() != "")
                {
                    DateTime ExistingPowerReleaseDate = Convert.ToDateTime(GetFromatedDateDDMMYYYY(txtExistingPowerReleaseDate.Text.Trim()));

                    if (DateofCommencementNew < ExistingPowerReleaseDate)
                    {
                        ErrorMsg = ". Date of Commencement of Production of Existing Industry should be greater than the Exsting Power Release Date\\n";
                    }
                }
                if (DateofCommencement != null && txtExpanDiverPowerReleaseDate.Text.TrimStart().TrimEnd().Trim() != "")
                {
                    DateTime ExpanDiverPowerReleaseDate = Convert.ToDateTime(GetFromatedDateDDMMYYYY(txtExpanDiverPowerReleaseDate.Text.Trim()));

                    if (DateofCommencement < ExpanDiverPowerReleaseDate)
                    {
                        ErrorMsg = ". Date of Commencement of Production of " + ddlIndustryStatus.SelectedItem.Text + " Industry should be greater than the New Power Release Date\\n";
                    }
                }
            }
            return ErrorMsg;
        }

        public string ValidateControls(string Step)
        {
            int slno = 1;
            string ErrorMsg = "";
            if (Step == "1")
            {
                if (TxtUidNumber.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter TS-Ipass UID Number \\n";
                    slno = slno + 1;
                }
                if (rblSector.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Type of Sector \\n";
                    slno = slno + 1;

                }

                if (txtUnitName.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Unit Name \\n";
                    slno = slno + 1;
                }

                if (txtDateOfIncorporation.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Date Of Incorporation \\n";
                    slno = slno + 1;
                }
                else
                {
                    string[] Date = txtDateOfIncorporation.Text.Trim().Split('/');
                    DateTime Todate = Convert.ToDateTime(Date[2] + "/" + Date[1] + "/" + Date[0]);
                    DateTime fromdate = DateTime.Now;
                    if (Todate > fromdate)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Date of Incorporation cannot be Future Date\\n";
                        slno = slno + 1;
                    }
                    else
                    {
                        string ErrorMsg1 = ValidateDates("1");
                        if (ErrorMsg1 != "")
                        {
                            ErrorMsg = ErrorMsg + slno + ErrorMsg1;
                            slno = slno + 1;
                        }
                    }
                }
                if (txtIncorpRegistranNumber.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Incorporation Registration No \\n";
                    slno = slno + 1;
                }
                if (txtTinNO.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter TIN Number \\n";
                    slno = slno + 1;
                }
                if (txtPanNo.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter PAN Number \\n";
                    slno = slno + 1;
                }
                if (txtEINIEMILDate.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select EIN/IEM/IL Date \\n";
                    slno = slno + 1;
                }
                else
                {
                    string[] Date = txtEINIEMILDate.Text.Trim().Split('/');
                    DateTime Todate = Convert.ToDateTime(Date[2] + "/" + Date[1] + "/" + Date[0]);
                    DateTime fromdate = DateTime.Now;
                    if (Todate > fromdate)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Date of EIN/IEM/IL cannot be Future Date\\n";
                        slno = slno + 1;
                    }
                }
                if (txtEINIEMILNumber.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select EIN/IEM/IL Number \\n";
                    slno = slno + 1;
                }

                if (ddlOrgType.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Type of Organization\\n";
                    slno = slno + 1;
                }
                if (rblCaste.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Caste \\n";
                    slno = slno + 1;
                }

                if (ddlsubcaste.SelectedValue == "0" && divsubcaste.Visible == true)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Sub Caste \\n";
                    slno = slno + 1;
                }

                if (txtApplciantName.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Applicant Name \\n";
                    slno = slno + 1;
                }
                if (ddlgender.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Gender \\n";
                    slno = slno + 1;
                }



                // Address
                if (ddlUnitstate.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select State Under Unit Address\\n";
                    slno = slno + 1;
                }
                if (ddlUnitDIst.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select District Under Unit Address\\n";
                    slno = slno + 1;
                }


                if (ddlUnitMandal.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Mandal Under Unit Address\\n";
                    slno = slno + 1;
                }

                if (ddlVillageunit.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Village Under Unit Address\\n";
                    slno = slno + 1;
                }
                if (txtUnitStreet.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Grampanchayat/IE/IDA Under Unit Address\\n";
                    slno = slno + 1;
                }
                if (txtUnitHNO.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Survey/Plot Number  Under Unit Address\\n";
                    slno = slno + 1;
                }
                if (txtunitmobileno.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Mobile Number Under Unit Address\\n";
                    slno = slno + 1;
                }
                if (txtunitemailid.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Email ID Under Unit Address\\n";
                    slno = slno + 1;
                }

                if (ddloffcstate.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select State Under Office Address\\n";
                    slno = slno + 1;
                }
                else if (ddloffcstate.SelectedValue == "31")
                {
                    if (ddlOffcDIst.SelectedValue == "0")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Select District Under Office Address\\n";
                        slno = slno + 1;
                    }
                    if (ddlOffcMandal.SelectedValue == "0")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Select Mandal Under Office Address\\n";
                        slno = slno + 1;
                    }
                    if (ddlOffcVil.SelectedValue == "0")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Select Village Under Office Address\\n";
                        slno = slno + 1;
                    }
                }
                else
                {
                    if (txtofficedist.Text.TrimStart().TrimEnd().Trim() == "" && txtofficedist.Visible == true)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter District Name  Under Office Address\\n";
                        slno = slno + 1;
                    }

                    if (txtoffcicemandal.Text.TrimStart().TrimEnd().Trim() == "" && txtoffcicemandal.Visible == true)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Mandal Name  Under Office Address\\n";
                        slno = slno + 1;
                    }

                    if (txtofficeviiage.Text.TrimStart().TrimEnd().Trim() == "" && txtofficeviiage.Visible == true)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Village Name  Under Office Address\\n";
                        slno = slno + 1;
                    }
                }
                if (txtOffcStreet.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Street Name  Under Office Address\\n";
                    slno = slno + 1;
                }
                if (txtOffSurveyNo.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Survey/Plot Number Under Office Address\\n";
                    slno = slno + 1;
                }
                if (txtOffcMobileNO.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Mobile Number Under Office Address\\n";
                    slno = slno + 1;
                }
                if (txtOffcEmail.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Email ID Under Office Address\\n";
                    slno = slno + 1;
                }
                /*if (hdnIsFirstTime.Value == "Y" && (hdnVerified.Value == "" || hdnVerified.Value == null || hdnVerified.Value == "N"))
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Verify Authorised Person Mobile Number with OTP\\n";
                    slno = slno + 1;
                }*/

                //if (rdIaLa_Lst.SelectedIndex <= -1 && divIsIALA.Visible == true)
                //{
                //    ErrorMsg = ErrorMsg + slno + ". Please select whether the unit is located in TSIIC or not \\n";
                //    slno = slno + 1;
                //    rdIaLa_Lst.Enabled = true;
                //}
                //if (ddlIndustrialParkName.SelectedValue == "0" && divIndusParkList.Visible == true)
                //{
                //    ErrorMsg = ErrorMsg + slno + ". Please select Industrial Park \\n";
                //    slno = slno + 1;
                //    ddlIndustrialParkName.Enabled = true;
                //}
            }
            else if (Step == "2")
            {
                if (ddlIndustryStatus.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please select Industry Status \\n";
                    slno = slno + 1;
                }
                else
                {
                    if (ddlIndustryStatus.SelectedValue == "1")
                    {
                        if (txtDateofCommencement.Text.TrimStart().TrimEnd().Trim() == "")
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Select Commenecement Date \\n";
                            slno = slno + 1;
                        }
                        else
                        {
                            string[] Date = txtDateofCommencement.Text.Trim().Split('/');
                            DateTime Todate = Convert.ToDateTime(Date[2] + "/" + Date[1] + "/" + Date[0]);
                            DateTime fromdate = DateTime.Now;
                            if (Todate > fromdate)
                            {
                                ErrorMsg = ErrorMsg + slno + ". Date of Commencement cannot be Future Date\\n";
                                slno = slno + 1;
                            }
                        }
                        if (ddlTextileProcessType.SelectedValue == "0")
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Select Textile Nature Of Industry \\n";
                            slno = slno + 1;
                        }
                        else if (ddlTextileProcessType.SelectedValue == "18" && txtNewOtherTextileProcessType.Text.Trim() == "")
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Enter Textile Nature Of Industry \\n";
                            slno = slno + 1;
                        }
                    }
                    else
                    {
                        if (txtDateofCommencement.Text.TrimStart().TrimEnd().Trim() == "")
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Select Existing Unit Commenecement Date \\n";
                            slno = slno + 1;
                        }
                        else
                        {
                            string[] Date = txtDateofCommencement.Text.Trim().Split('/');
                            DateTime Todate = Convert.ToDateTime(Date[2] + "/" + Date[1] + "/" + Date[0]);
                            DateTime fromdate = DateTime.Now;
                            if (Todate > fromdate)
                            {
                                ErrorMsg = ErrorMsg + slno + ". Date of Existing Unit Commencement cannot be Future Date\\n";
                                slno = slno + 1;
                            }
                        }
                        if (ddlTextileProcessType.SelectedValue == "0")
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Select Existing Unit Textile Process Type \\n";
                            slno = slno + 1;
                        }
                        else if (ddlTextileProcessType.SelectedValue == "18" && txtNewOtherTextileProcessType.Text.Trim() == "")
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Enter Existing Unit Textile Nature Of Industry \\n";
                            slno = slno + 1;
                        }

                        if (txtDateofCommencementExp.Text.TrimStart().TrimEnd().Trim() == "")
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Select " + ddlIndustryStatus.SelectedItem.Text + " Unit Commenecement Date \\n";
                            slno = slno + 1;
                        }
                        else
                        {
                            string[] Date = txtDateofCommencementExp.Text.Trim().Split('/');
                            DateTime Todate = Convert.ToDateTime(Date[2] + "/" + Date[1] + "/" + Date[0]);
                            DateTime fromdate = DateTime.Now;
                            if (Todate > fromdate)
                            {
                                ErrorMsg = ErrorMsg + slno + ". Date of " + ddlIndustryStatus.SelectedItem.Text + " Unit Commencement cannot be Future Date\\n";
                                slno = slno + 1;
                            }
                        }
                        if (ddlTextileProcessTypeExp.SelectedValue == "0")
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Select " + ddlIndustryStatus.SelectedItem.Text + " Unit Textile Process Type \\n";
                            slno = slno + 1;
                        }
                        else if (ddlTextileProcessTypeExp.SelectedValue == "18" && txtExistOtherTextileProcessType.Text.Trim() == "")
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Enter " + ddlIndustryStatus.SelectedItem.Text + " Unit Textile Nature Of Industry \\n";
                            slno = slno + 1;
                        }
                    }


                    string ErrorMsg1 = ValidateDates("1");
                    if (ErrorMsg1 != "")
                    {
                        ErrorMsg = ErrorMsg + slno + ErrorMsg1;
                        slno = slno + 1;
                    }

                    if (trIndustryExpansionType.Visible == true && ddlInustryExpansionType.SelectedValue == "0")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please select Industry Expansion Type \\n";
                        slno = slno + 1;
                    }
                    if (ddlSpecialIncentive.SelectedValue == "Y")
                    {
                        if (txtGovermentOrderNumber.Text == "")
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Enter Goverment Order Number \\n";
                            slno = slno + 1;
                        }
                        if (txtGovermentOrderDate.Text == "")
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Select Goverment Order Date \\n";
                            slno = slno + 1;
                        }
                        if (hyGovermentOrder.NavigateUrl == "")
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Upload Goverment Order Copy \\n";
                            slno = slno + 1;
                        }
                    }
                    if (rdl_TypeofUnit.SelectedValue == "1" && divTechnicalNatureOfIndustry.Visible && ddlTechnicalNatureOfIndustry.SelectedValue == "0")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Select Technical Textile Type \\n";
                        slno = slno + 1;
                    }
                    if (ddlIndustryStatus.SelectedValue == "1" && GvLineOfactivityDetails.Rows.Count < 1)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Add New Enterprise Product Details \\n";
                        slno = slno + 1;
                    }
                    if (ddlIndustryStatus.SelectedValue != "1" && GvLineOfactivityDetails.Rows.Count < 1)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Add Existing Enterprise Product Details \\n";
                        slno = slno + 1;
                    }
                    if (ddlIndustryStatus.SelectedValue != "1" && GvLineOfactivityExpnsionDetails.Rows.Count < 1)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Add Expansion Enterprise Product Details \\n";
                        slno = slno + 1;
                    }
                    if (GvPartnerDetails.Rows.Count < 1)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Add Proprietor/Managing Director/Managing Partner Details \\n";
                        slno = slno + 1;
                    }
                    else
                    {
                        decimal TotalShare = 0;
                        foreach (GridViewRow gvrow in GvPartnerDetails.Rows)
                        {
                            TotalShare = TotalShare + Convert.ToDecimal(GetDecimalNullValue((gvrow.FindControl("lblShare") as Label).Text));
                        }
                        if (TotalShare != 100)
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Enter 100 Percent share of Proprietor/Managing Director/Managing Partner Details \\n";
                            slno = slno + 1;
                        }
                    }

                    if (txtAuthorisedPerson.Text.TrimStart().TrimEnd().Trim() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Authorised Person Name\\n";
                        slno = slno + 1;
                    }
                    if (ddlAuthorisedSignDesignation.SelectedValue == "0")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Select Authorised Person Designation \\n";
                        slno = slno + 1;
                    }
                    if (txtPanNoAuthorised.Text.TrimStart().TrimEnd().Trim() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Authorised Person Pan No\\n";
                        slno = slno + 1;
                    }
                    if (txtMobileNumberAuthorised.Text.TrimStart().TrimEnd().Trim() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Authorised Person Mobile Number\\n";
                        slno = slno + 1;
                    }
                    if (txtemailAuthorised.Text.TrimStart().TrimEnd().Trim() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Authorised Person email \\n";
                        slno = slno + 1;
                    }
                    if (txtCorrespondenceAddress.Text.TrimStart().TrimEnd().Trim() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Authorised Person Correspondence Address\\n";
                        slno = slno + 1;
                    }
                }
                
            }
            else if (Step == "3")
            {
                if (txtstaffMale.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Male Management & Staff\\n";
                    slno = slno + 1;
                }
                if (txtfemale.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Female Management & Staff\\n";
                    slno = slno + 1;
                }
                if (txtsupermalecount.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Male Supervisory\\n";
                    slno = slno + 1;
                }
                if (txtsuperfemalecount.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Female Supervisory\\n";
                    slno = slno + 1;
                }
                if (txtSkilledWorkersMale.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Male Skilled workers\\n";
                    slno = slno + 1;
                }
                if (txtSkilledWorkersFemale.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Female Skilled workers\\n";
                    slno = slno + 1;
                }
                if (txtSemiSkilledWorkersMale.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Male Semi-skilled workers\\n";
                    slno = slno + 1;
                }
                if (txtSemiSkilledWorkersFemale.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Female Semi-skilled  workers\\n";
                    slno = slno + 1;
                }
                if (txtlandexisting.Text == "" && ddlIndustryStatus.SelectedValue == "1")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Investment of New Enterprise Land Value\\n";
                    slno = slno + 1;
                }
                if (txtlandcapacity.Text == "" && ddlIndustryStatus.SelectedValue != "1" && ddlIndustryStatus.SelectedValue != "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Land Value Of Under Expansion / Diversification Project \\n";
                    slno = slno + 1;
                }
                if (txtlandpercentage.Text == "" && ddlIndustryStatus.SelectedValue != "1" && ddlIndustryStatus.SelectedValue != "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Land Value Of % of increase Under Expansion / Diversification \\n";
                    slno = slno + 1;
                }
                if (txtbuildingexisting.Text == "" && ddlIndustryStatus.SelectedValue == "1")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Investment of New Enterprise Building Value\\n";
                    slno = slno + 1;
                }
                if (txtbuildingcapacity.Text == "" && ddlIndustryStatus.SelectedValue != "1" && ddlIndustryStatus.SelectedValue != "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Building Value Of Under Expansion / Diversification Project \\n";
                    slno = slno + 1;
                }
                if (txtbuildingpercentage.Text == "" && ddlIndustryStatus.SelectedValue != "1" && ddlIndustryStatus.SelectedValue != "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Building Value Of % of increase Under Expansion / Diversification \\n";
                    slno = slno + 1;
                }
                if (txtplantexisting.Text == "" && ddlIndustryStatus.SelectedValue == "1")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Investment of New Enterprise Plant & Machinery Value\\n";
                    slno = slno + 1;
                }
                if (txtplantcapacity.Text == "" && ddlIndustryStatus.SelectedValue != "1" && ddlIndustryStatus.SelectedValue != "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Plant & Machinery Value Of Under Expansion / Diversification Project \\n";
                    slno = slno + 1;
                }
                if (txtplantpercentage.Text == "" && ddlIndustryStatus.SelectedValue != "1" && ddlIndustryStatus.SelectedValue != "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Plant & Machinery Value Of % of increase Under Expansion / Diversification \\n";
                    slno = slno + 1;
                }
                // Current Investment Validations
                if (ddlIndustryStatus.SelectedValue != "1")
                {
                    if (txtcurrInvLandValue.Text.Trim().TrimStart() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Land Value Under Existing Actual Investemnt Category\\n";
                        slno = slno + 1;
                    }
                    if (txtcurrInvBuldvalue.Text.Trim().TrimStart() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Building Value Under Existing Actual Investemnt Category\\n";
                        slno = slno + 1;
                    }
                    if (txtcurrInvplantMechValue.Text.Trim().TrimStart() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Plant & Machinary Value Under Existing Actual Investemnt Category\\n";
                        slno = slno + 1;
                    }
                }
                if (HiddenFieldEnterpriseCategory.Value.ToUpper().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Industry Category is not Defined as per the TTAP Policy. please check Incevestment & Employment details\\n";
                    slno = slno + 1;
                }

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                string Valid = ObjCAFClass.Check_LandAndBuildingDetailsEntry(Session["IncentiveID"].ToString(), ddlIndustryStatus.SelectedValue, ObjLoginNewvo.uid);
                if (Valid != "Y")
                {
                    if (ddlIndustryStatus.SelectedValue != "1")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter " + ddlIndustryStatus.SelectedItem.Text + " Enterprise Actual Land, Building & Plant and Machinary Investment Details\\n";
                    }
                    else
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter New Enterprise Actual Land & building Investment Details\\n";
                    }

                    slno = slno + 1;
                }


                if (lblEnterpriseCategory.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Industry Category is Not Defined. Please Enter Employment & Investment Details to Arrive the Category of the Industry\\n";
                    slno = slno + 1;
                }
                if (ddlIspowApplicable.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Is power applicable Or Not\\n";
                    slno = slno + 1;
                }
                else
                {
                    if (ddlIspowApplicable.SelectedValue == "1")
                    {
                        if (ddlIndustryStatus.SelectedValue == "1")
                        {
                            if (txtNewPowerUniqueID.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter New Enterprise Power Connection Unique ID\\n";
                                slno = slno + 1;
                            }
                            if (txtNewPowerCompany.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter New Enterprise Power Company Name\\n";
                                slno = slno + 1;
                            }

                            if (txtNewPowerReleaseDate.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter New Enterprise Power Released Date\\n";
                                slno = slno + 1;
                            }
                            else
                            {
                                string ErrorMsg1 = ValidateDates("4");
                                if (ErrorMsg1 != "")
                                {
                                    ErrorMsg = ErrorMsg + slno + ErrorMsg1;
                                    slno = slno + 1;
                                }
                            }
                            if (txtPowerConnectedLoad.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter New Enterprise Connected Load (in KVA)\\n";
                                slno = slno + 1;
                            }
                            if (txtNewContractedLoad.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter New Enterprise Contracted load (in KVA)\\n";
                                slno = slno + 1;
                            }

                            if (txtPowerConnectedLoad.Text.TrimStart().Trim() != "" && txtNewContractedLoad.Text.TrimStart().Trim() != "")
                            {
                                decimal ConnectedLoad = Convert.ToDecimal(txtPowerConnectedLoad.Text.TrimStart().Trim());
                                decimal ContractedLoad = Convert.ToDecimal(txtPowerConnectedLoad.Text.TrimStart().Trim());
                                if (ConnectedLoad > ContractedLoad)
                                {
                                    ErrorMsg = ErrorMsg + slno + ". Connected Load (in KVA) Should Not be Greater than Contracted load (in KVA)\\n";
                                    slno = slno + 1;
                                }
                            }

                            if (txtServiceRateUnit.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter New Enterprise Rate per unit (in Rs)\\n";
                                slno = slno + 1;
                            }
                        }
                        else if (ddlIndustryStatus.SelectedValue == "2" || ddlIndustryStatus.SelectedValue == "3" || ddlIndustryStatus.SelectedValue == "4")
                        {
                            if (txtExistingPowerUniqueID.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter Existing Enterprise Power Connection Unique ID\\n";
                                slno = slno + 1;
                            }
                            if (txtExistingPowerCompany.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter Existing Enterprise Power Company Name\\n";
                                slno = slno + 1;
                            }
                            if (txtExistingPowerReleaseDate.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter Existing Enterprise Power Released Date\\n";
                                slno = slno + 1;
                            }
                            if (txtExistingPowerConnectedLoad.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter Existing Enterprise Power Connected Load (in KVA)\\n";
                                slno = slno + 1;
                            }
                            if (txtExistingContractedLoad.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter Existing  Enterprise Power Contracted load (in KVA)\\n";
                                slno = slno + 1;
                            }
                            if (txtExistingPowerConnectedLoad.Text.TrimStart().Trim() != "" && txtExistingContractedLoad.Text.TrimStart().Trim() != "")
                            {
                                decimal ConnectedLoad = Convert.ToDecimal(txtExistingPowerConnectedLoad.Text.TrimStart().Trim());
                                decimal ContractedLoad = Convert.ToDecimal(txtExistingContractedLoad.Text.TrimStart().Trim());
                                if (ConnectedLoad > ContractedLoad)
                                {
                                    ErrorMsg = ErrorMsg + slno + ". Connected Load (in KVA) Should Not be Greater than Contracted load (in KVA) of Existing Unit\\n";
                                    slno = slno + 1;
                                }
                            }

                            if (txtExistingRateUnit.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter Existing Enterprise Rate per unit (in Rs)\\n";
                                slno = slno + 1;
                            }

                            if (txtExpanDiverPowerUniqueID.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter Expansion / Diversification / Modification Enterprise Power Connection Unique ID\\n";
                                slno = slno + 1;
                            }
                            if (txtExpanDiverPowerCompany.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter Expansion / Diversification / Modification Enterprise Power Company Name\\n";
                                slno = slno + 1;
                            }

                            if (txtExpanDiverPowerReleaseDate.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ".Please Enter Expansion / Diversification / Modification Enterprise Power Released Date\\n";
                                slno = slno + 1;
                            }
                            else
                            {
                                string ErrorMsg1 = ValidateDates("5");
                                if (ErrorMsg1 != "")
                                {
                                    ErrorMsg = ErrorMsg + slno + ErrorMsg1;
                                    slno = slno + 1;
                                }
                            }
                            if (txtExpanDiverPowerConnectedLoad.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ".Please Enter Expansion / Diversification / Modification Enterprise Power Connected Load (in KVA)\\n";
                                slno = slno + 1;
                            }
                            if (txtExpanDiverContractedLoad.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter Expansion / Diversification / Modification Enterprise Contracted load (in KVA)\\n";
                                slno = slno + 1;
                            }

                            if (txtExpanDiverPowerConnectedLoad.Text.TrimStart().Trim() != "" && txtExpanDiverContractedLoad.Text.TrimStart().Trim() != "")
                            {
                                decimal ConnectedLoad = Convert.ToDecimal(txtExpanDiverPowerConnectedLoad.Text.TrimStart().Trim());
                                decimal ContractedLoad = Convert.ToDecimal(txtExpanDiverContractedLoad.Text.TrimStart().Trim());
                                if (ConnectedLoad > ContractedLoad)
                                {
                                    ErrorMsg = ErrorMsg + slno + ". Connected Load (in KVA) Should Not be Greater than Contracted load (in KVA) of Expansion / Diversification / Modification Unit\\n";
                                    slno = slno + 1;
                                }
                            }

                            if (txtExpanDiverRateUnit.Text.TrimStart().Trim() == "")
                            {
                                ErrorMsg = ErrorMsg + slno + ". Please Enter Expansion / Diversification / Modification Enterprise Rate per unit (in Rs)\\n";
                                slno = slno + 1;
                            }
                        }
                    }
                }

                if (ddlWaterSource.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Is Water applicable Or Not\\n";
                    slno = slno + 1;
                }
                else
                {
                    if (ddlWaterSource.SelectedValue == "1")
                    {
                        if (txtwaterSource.Text == "")
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Enter Water Source\\n";
                            slno = slno + 1;
                        }
                        if (txtwaterRequirement.Text == "")
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Enter Please Enter Water Requirement\\n";
                            slno = slno + 1;
                        }
                        if (txtwaterRateperunit.Text == "")
                        {
                            ErrorMsg = ErrorMsg + slno + ". Please Enter Rate Per Unit(in Rs)\\n";
                            slno = slno + 1;
                        }
                    }
                }

                if (gvPMAbstract.Rows.Count < 1)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Add Machinary Abstract Details \\n";
                    slno = slno + 1;
                }
                if (hdnShowGrid.Value == "Y")
                {
                    if (grdPandM.Rows.Count < 1 && ddlIndustryStatus.SelectedValue == "1")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Add Machinary Details \\n";
                        slno = slno + 1;
                    }
                }
                else
                {
                    DataSet ds = new DataSet();
                   /* ds = GetPandM(0, Convert.ToInt32(Session["IncentiveID"].ToString()));*/
                    ds = GetPandMAlter(0, Convert.ToInt32(Session["IncentiveID"].ToString()));//CHANIKYAGOPAL
                    if (ds.Tables[0].Rows.Count < 1 && ddlIndustryStatus.SelectedValue == "1")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Add Machinary Details \\n";
                        slno = slno + 1;
                    }
                }
                if (ddlIndustryStatus.SelectedValue != "1" && (gvGrossblockPandM.Rows.Count < 1 && grdPandM.Rows.Count < 1))
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Add Plant and Machinary Details either Invoices Wise or Gross Block Wise \\n";
                    slno = slno + 1;
                }
                if (grdPandM.Rows.Count > 0)
                {
                    foreach (GridViewRow gvr in grdPandM.Rows)
                    {
                        string filaname = ((HyperLink)gvr.FindControl("hyFilePathMerge2")).NavigateUrl.ToString();
                        if (filaname == "")
                        {
                            //grdPandM.Columns[27].Visible = true;
                            ErrorMsg = ErrorMsg + slno + ". Please Upload All Plant and Machinary Invoices \\n";
                            slno = slno + 1;
                            break;
                        }
                    }
                }

                string Check = ObjCAFClass.Check_ApplicantData(TxtUidNumber.Text.Trim());
                if (Check != "N")
                {
                    if (ddlPlantMachinaryPayment.Items.Count > 1)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Upload All Plant and Machinary Payment Proofs \\n";
                        slno = slno + 1;
                    }
                }
                /*Chanikya*/
                DataSet dspm = new DataSet();
                dspm = GetCheckPMPaymentMapping(Session["IncentiveID"].ToString(), "1");

                if (dspm.Tables[0].Rows.Count > 0)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Upload newly added Plant and Machinary Payment Proofs \\n";
                    slno = slno + 1;
                }
                DataSet dspm1 = new DataSet();
                dspm1 = GetCheckPMPaymentMapping(Session["IncentiveID"].ToString(), "2");

                if (dspm1.Tables[0].Rows.Count > 0)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Upload newly added Plant and Machinary Payment Proofs \\n";
                    slno = slno + 1;
                }
                if (ddlIndustryStatus.SelectedValue != "1")
                {
                    DataSet dspp = new DataSet();
                    dspm = GetCheckPMPaymentMapping_ExistingUnit(Session["IncentiveID"].ToString(), "2");

                    if (dspm.Tables[0].Rows.Count > 0)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Upload Plant and Machinary Payment Proofs of Expansion Machines \\n";
                        slno = slno + 1;
                    }
                }
            }
            else if (Step == "4")
            {
                if (txtTurnoverYear1.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Turnover for Year 1\\n";
                    slno = slno + 1;
                }
                if (txtTurnoverYear2.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Turnover for Year 2\\n";
                    slno = slno + 1;
                }
                if (txtTurnoverYear3.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Turnover for Year 3\\n";
                    slno = slno + 1;
                }

                if (txtEBITDAYear1.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter EBITDA for Year 1\\n";
                    slno = slno + 1;
                }
                if (txtEBITDAYear2.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter EBITDA for Year 2\\n";
                    slno = slno + 1;
                }
                if (txtEBITDAYear3.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter EBITDA for Year 3\\n";
                    slno = slno + 1;
                }

                if (txtNetworthYear1.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Net worth for Year 1\\n";
                    slno = slno + 1;
                }
                if (txtNetworthYear2.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Net worth for Year 2\\n";
                    slno = slno + 1;
                }
                if (txtNetworthYear3.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Net worth for Year 3\\n";
                    slno = slno + 1;
                }

                if (txtReservesYear1.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Reserves & Surplus for Year 1\\n";
                    slno = slno + 1;
                }
                if (txtReservesYear2.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Reserves & Surplus for Year 2\\n";
                    slno = slno + 1;
                }
                if (txtReservesYear3.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Reserves & Surplus for Year 3\\n";
                    slno = slno + 1;
                }

                if (txtShareCapitalYear1.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Share Capital for Year 1\\n";
                    slno = slno + 1;
                }
                if (txtShareCapitalYear2.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Share Capital for Year 2\\n";
                    slno = slno + 1;
                }
                if (txtShareCapitalYear3.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Share Capital for Year 3\\n";
                    slno = slno + 1;
                }
                if (ddlIndustryStatus.SelectedValue != "1")
                {
                    if (txtProductionQuantity1.Text.Trim().TrimStart() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Quantity for " + lblProductionYear1.Text + " Under Production Details\\n";
                        slno = slno + 1;
                    }
                    if (txtProductionValue1.Text.Trim().TrimStart() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Value for " + lblProductionYear1.Text + " Under Production Details\\n";
                        slno = slno + 1;
                    }

                    if (txtProductionQuantity2.Text.Trim().TrimStart() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Quantity for " + lblProductionYear2.Text + " Under Production Details\\n";
                        slno = slno + 1;
                    }
                    if (txtProductionValue2.Text.Trim().TrimStart() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Value for " + lblProductionYear2.Text + " Under Production Details\\n";
                        slno = slno + 1;
                    }

                    if (txtProductionQuantity3.Text.Trim().TrimStart() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Quantity for " + lblProductionYear3.Text + " Under Production Details\\n";
                        slno = slno + 1;
                    }
                    if (txtProductionValue3.Text.Trim().TrimStart() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Value for " + lblProductionYear3.Text + " Under Production Details\\n";
                        slno = slno + 1;
                    }
                }

                if (txtPromoterEquity.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Promoters Equity\\n";
                    slno = slno + 1;
                }
                if (txtInstitutionsEquity.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Institutions Equity\\n";
                    slno = slno + 1;
                }
                if (txtTearmLoans.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Tearm Loans\\n";
                    slno = slno + 1;
                }
                if (txtSubsidyagencies.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Subsidy/Grants through other agencies\\n";
                    slno = slno + 1;
                }


                if (ddlIsTermLoanAvailed.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Have you availed Term Loan Or Not \\n";
                    slno = slno + 1;
                    ddlIsTermLoanAvailed.Enabled = true;
                }
                else if (ddlIsTermLoanAvailed.SelectedValue == "1")
                {
                    if (GVTermLoandtls.Rows.Count < 1)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Add Term Loan details \\n";
                        slno = slno + 1;
                    }
                }
            }
            else if (Step == "5")
            {
                if (ddlBank.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Name of the Bank \\n";
                    slno = slno + 1;
                    ddlBank.Enabled = true;
                    ddlAccountType.Enabled = true;
                }
                if (ddlBank.SelectedValue == "999") 
                {
                    if (txtBankName.Text.TrimStart().Trim() == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Name of The Bank \\n";
                        slno = slno + 1;
                        txtBankName.Focus();
                    }
                }
                if (txtBranchName.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Name of The Branch \\n";
                    slno = slno + 1;
                    txtBranchName.Enabled = true;
                }
                if (ddlAccountType.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Account Type \\n";
                    slno = slno + 1;
                    ddlAccountType.Enabled = true;
                }
                if (txtAccountName.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Name of The Account Holder \\n";
                    slno = slno + 1;
                    txtAccountName.Enabled = true;
                }
                if (txtAccNumber.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Account Number \\n";
                    slno = slno + 1;
                    txtAccNumber.Enabled = true;
                }
                if (txtIfscCode.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter IFSC Code \\n";
                    slno = slno + 1;
                    txtIfscCode.Enabled = true;
                }

                if (txtaccountauthorizedPerson.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Name of the authorized Person for operating the account \\n";
                    slno = slno + 1;
                    txtaccountauthorizedPerson.Enabled = true;
                }
                if (txtaccountauthorizedPersonDesignation.Text.TrimStart().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Designation of authorized Person\\n";
                    slno = slno + 1;
                    txtaccountauthorizedPersonDesignation.Enabled = true;
                }
            }
            else if (Step == "6")
            {
                string errormsgAttach = ObjCAFClass.ValidateMandatoryAttachments(Session["IncentiveID"].ToString(), "0");
                if (errormsgAttach.Trim().TrimStart() != "")
                {
                    ErrorMsg = errormsgAttach + " \\n";
                    //slno = slno + 1;
                    btnUpload1.Enabled = true;
                    fuDocuments1.Enabled = true;
                    ddltypeofDocuments.Enabled = true;
                    BindDocumentsList(Session["IncentiveID"].ToString());
                }
            }
            return ErrorMsg;
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
        public DataSet GetRejectedApplicationStatus(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };

            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_USERAPPLICATIONS_STATUS", pp);
            return Dsnew;
        }
        public DataSet GetBankStatus(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };

            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_BANKENABLE_STATUS", pp);
            return Dsnew;
        }
        public DataSet GetDcpCondition(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };

            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_CHECK_APPLICANT_ELIGIBILITY_FOR_DCP", pp);
            return Dsnew;
        }
        public void BindUnitMasterData()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = ObjCAFClass.GenericFillDs("USP_INCENTIVE_UNIT_MASTER");
            if (Dsnew != null && Dsnew.Tables.Count > 0 && Dsnew.Tables[0].Rows.Count > 0)
            {
                ddlquantityin.DataSource = Dsnew.Tables[0];
                ddlquantityin.DataTextField = "Unit";
                ddlquantityin.DataValueField = "UnitID";
                ddlquantityin.DataBind();

                ddlquantityinExpan.DataSource = Dsnew.Tables[0];
                ddlquantityinExpan.DataTextField = "Unit";
                ddlquantityinExpan.DataValueField = "UnitID";
                ddlquantityinExpan.DataBind();
            }
            AddSelect(ddlquantityin);
            AddSelect(ddlquantityinExpan);
        }

        public void BindTextTyleProcessType()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = ObjCAFClass.GenericFillDs("USP_INCENTIVE_TextileProcessType_MASTER");
            if (Dsnew != null && Dsnew.Tables.Count > 0 && Dsnew.Tables[0].Rows.Count > 0)
            {
                ddlTextileProcessType.DataSource = Dsnew.Tables[0];
                ddlTextileProcessType.DataTextField = "TextileProcessName";
                ddlTextileProcessType.DataValueField = "TextileProcessTypeValue";
                ddlTextileProcessType.DataBind();

                ddlTextileProcessTypeExp.DataSource = Dsnew.Tables[0];
                ddlTextileProcessTypeExp.DataTextField = "TextileProcessName";
                ddlTextileProcessTypeExp.DataValueField = "TextileProcessTypeValue";
                ddlTextileProcessTypeExp.DataBind();
            }
            AddSelect(ddlTextileProcessType);
            AddSelect(ddlTextileProcessTypeExp);
        }

        public DataSet GetLineofActivityDtls(string INCENTIVEID, string LOAType)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@LOAType",SqlDbType.VarChar),
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = LOAType;
            pp[1].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_INCENTIVE_LOA_DTLS", pp);
            return Dsnew;
        }
        public DataSet GetApplicationTrackerDetailed_CFE(string UIDNO)
        {
            DataRetrivalClass dataRetrivalClass = new DataRetrivalClass();
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UIDNOTTAP",SqlDbType.VarChar)
           };
            pp[0].Value = UIDNO;
            Dsnew = dataRetrivalClass.GenericFillDs("[USP_GET_CFETRACKER_DTLS_TTAP]", pp);
            return Dsnew;
        }


        protected void BindLineofActivityDtls(string INCENTIVEID, string LOAType)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetLineofActivityDtls(INCENTIVEID, LOAType);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    if (LOAType == "New")
                    {
                        GvLineOfactivityDetails.DataSource = dsnew.Tables[0];
                        GvLineOfactivityDetails.DataBind();
                    }
                    else
                    {
                        GvLineOfactivityExpnsionDetails.DataSource = dsnew.Tables[0];
                        GvLineOfactivityExpnsionDetails.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void BindSavedApplicationDtls(string userid, string incentiveid)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = GetapplicationDtls(userid, incentiveid);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Session["IncentiveID"] = ds.Tables[0].Rows[0]["IncentiveID"].ToString();

                    // Uploaded Attachemnts Binding
                    GetIncetiveAttachements(Session["IncentiveID"].ToString(), "Y");

                    string applicationStatus1 = "";
                    applicationStatus1 = ds.Tables[0].Rows[0]["intStatusid"].ToString();

                    // step1
                    if (ds.Tables[0].Rows[0]["Uid_NO"].ToString() != "")
                    {
                        TxtUidNumber.Text = ds.Tables[0].Rows[0]["Uid_NO"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["SectorID"].ToString() != "")
                    {
                        rblSector.SelectedValue = ds.Tables[0].Rows[0]["SectorID"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["UnitName"].ToString() != "")
                    {
                        txtUnitName.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                        txtAccountName.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                    }
                    txtCountryofOrigin.Text = ds.Tables[0].Rows[0]["CountryOrigin"].ToString();
                    txtDateOfIncorporation.Text = ds.Tables[0].Rows[0]["DateOfIncorporation"].ToString();
                    txtIncorpRegistranNumber.Text = ds.Tables[0].Rows[0]["IncorpRegistranNumber"].ToString();
                    if (ds.Tables[0].Rows[0]["TinNO"].ToString() != "")
                    {
                        txtTinNO.Text = ds.Tables[0].Rows[0]["TinNO"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["PanNo"].ToString() != "")
                    {
                        txtPanNo.Text = ds.Tables[0].Rows[0]["PanNo"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["EIN_IEM_IL_Number"].ToString() != "")
                    {
                        txtEINIEMILNumber.Text = ds.Tables[0].Rows[0]["EIN_IEM_IL_Number"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["EIN_IEM_IL_REG_DATE"].ToString() != "")
                    {
                        txtEINIEMILDate.Text = ds.Tables[0].Rows[0]["EIN_IEM_IL_REG_DATE"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["OrgType"].ToString() != "")
                    {
                        ddlOrgType.SelectedValue = ds.Tables[0].Rows[0]["OrgType"].ToString();
                        ddlOrgType_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (ds.Tables[0].Rows[0]["SocialStatus"].ToString() != "")
                    {
                        rblCaste.SelectedValue = ds.Tables[0].Rows[0]["SocialStatus"].ToString();
                        if (rblCaste.SelectedValue == "2")
                        {
                            rblCaste_SelectedIndexChanged(this, EventArgs.Empty);
                            if (ds.Tables[0].Rows[0]["SubCaste"] != null && ds.Tables[0].Rows[0]["SubCaste"].ToString() != "--Select--")
                            {
                                ddlsubcaste.SelectedValue = ds.Tables[0].Rows[0]["SubCaste"].ToString();
                            }
                        }
                    }
                    if (ds.Tables[0].Rows[0]["ApplicantName"].ToString() != "")
                    {
                        txtApplciantName.Text = ds.Tables[0].Rows[0]["ApplicantName"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Gender"].ToString() != "")
                    {
                        ddlgender.SelectedValue = ds.Tables[0].Rows[0]["Gender"].ToString();
                    }
                    txtYearsOfExpinTexttile.Text = ds.Tables[0].Rows[0]["YearsOfExpinTexttile"].ToString();

                    if (ds.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString() != "")
                    {
                        ddlDifferentlyabled.SelectedValue = ds.Tables[0].Rows[0]["IsDifferentlyAbled"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["TypeofTexttile"].ToString() != "")
                    {
                        rdl_TypeofUnit.SelectedValue = ds.Tables[0].Rows[0]["TypeofTexttile"].ToString();
                        if (rdl_TypeofUnit.SelectedValue == "1")
                        {
                            rdl_TypeofUnit_SelectedIndexChanged(this, EventArgs.Empty);
                            if (ds.Tables[0].Rows[0]["TechnicalTextileID"].ToString() != "")
                            {
                                ddlTechnicalNatureOfIndustry.SelectedValue = ds.Tables[0].Rows[0]["TechnicalTextileID"].ToString();
                            }
                        }
                    }

                    if (ds.Tables[0].Rows[0]["UnitState"].ToString() != "")
                    {
                        ddlUnitstate.SelectedValue = ds.Tables[0].Rows[0]["UnitState"].ToString();
                        ddlUnitstate.Enabled = false;
                        ddlUnitstate_SelectedIndexChanged(this, EventArgs.Empty);
                    }

                    if (ds.Tables[0].Rows[0]["UnitDIst"].ToString() != "")
                    {
                        ddlUnitDIst.SelectedValue = ds.Tables[0].Rows[0]["UnitDIst"].ToString();
                        ddldistrictunit_SelectedIndexChanged(this, EventArgs.Empty);
                    }

                    if (ds.Tables[0].Rows[0]["UnitMandal"].ToString() != "")
                    {
                        ddlUnitMandal.SelectedValue = ds.Tables[0].Rows[0]["UnitMandal"].ToString();
                        ddlUnitMandal_SelectedIndexChanged(this, EventArgs.Empty);
                    }

                    if (ds.Tables[0].Rows[0]["UnitVill"].ToString() != "")
                    {
                        ddlVillageunit.SelectedValue = ds.Tables[0].Rows[0]["UnitVill"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["UnitHNO"].ToString() != "")
                    {
                        txtUnitHNO.Text = ds.Tables[0].Rows[0]["UnitHNO"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["UnitStreet"].ToString() != "")
                    {
                        txtUnitStreet.Text = ds.Tables[0].Rows[0]["UnitStreet"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["UnitMObileNo"].ToString() != "")
                    {
                        txtunitmobileno.Text = ds.Tables[0].Rows[0]["UnitMObileNo"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["UnitEmail"].ToString() != "")
                    {
                        txtunitemailid.Text = ds.Tables[0].Rows[0]["UnitEmail"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["OffcState"].ToString() != "")
                    {
                        ddloffcstate.SelectedValue = ds.Tables[0].Rows[0]["OffcState"].ToString();
                    }
                    string AdharNumber = ds.Tables[0].Rows[0]["AadharNumber"].ToString();
                    if (AdharNumber != "" && AdharNumber.Length == 12)
                    {
                        txtadhar1.Text = AdharNumber.Substring(0, 4);
                        txtadhar2.Text = AdharNumber.Substring(4, 4);
                        txtadhar3.Text = AdharNumber.Substring(8, 4);
                    }
                    //Office District Binding 
                    if (ds.Tables[0].Rows[0]["OffcState"].ToString() == "31")
                    {
                        ddloffcstate_SelectedIndexChanged(this, EventArgs.Empty);
                        if (ds.Tables[0].Rows[0]["OffcDIst"].ToString() != "")
                        {
                            ddlOffcDIst.SelectedValue = ds.Tables[0].Rows[0]["OffcDIst"].ToString();
                            ddldistrictoffc_SelectedIndexChanged(this, EventArgs.Empty);
                        }


                        if (ds.Tables[0].Rows[0]["OffcMandal"].ToString() != "")
                        {
                            ddlOffcMandal.SelectedValue = ds.Tables[0].Rows[0]["OffcMandal"].ToString();
                            ddloffcmandal_SelectedIndexChanged(this, EventArgs.Empty);
                        }
                        if (ds.Tables[0].Rows[0]["OffcVill"].ToString() != "")
                        {
                            ddlOffcVil.SelectedValue = ds.Tables[0].Rows[0]["OffcVill"].ToString();
                        }
                    }
                    else
                    {
                        ddloffcstate_SelectedIndexChanged(this, EventArgs.Empty);
                        if (ds.Tables[0].Rows[0]["OffcOtherDist"].ToString() != "")
                        {
                            txtofficedist.Text = ds.Tables[0].Rows[0]["OffcOtherDist"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["OffcOtherMandal"].ToString() != "")
                        {
                            txtoffcicemandal.Text = ds.Tables[0].Rows[0]["OffcOtherMandal"].ToString();
                        }
                        if (ds.Tables[0].Rows[0]["OffcOtherVillage"].ToString() != "")
                        {
                            txtofficeviiage.Text = ds.Tables[0].Rows[0]["OffcOtherVillage"].ToString();
                        }
                    }
                    if (ds.Tables[0].Rows[0]["OffcHNO"].ToString() != "")
                    {
                        txtOffSurveyNo.Text = ds.Tables[0].Rows[0]["OffcHNO"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["OffcStreet"].ToString() != "")
                    {
                        txtOffcStreet.Text = ds.Tables[0].Rows[0]["OffcStreet"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["OffcMobileNO"].ToString() != "")
                    {
                        txtOffcMobileNO.Text = ds.Tables[0].Rows[0]["OffcMobileNO"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["OffcEmail"].ToString() != "")
                    {
                        txtOffcEmail.Text = ds.Tables[0].Rows[0]["OffcEmail"].ToString();
                    }

                    //  Tab 2 Bindings
                    if (ds.Tables[0].Rows[0]["TypeOfIndustryOldText"].ToString() != "")
                    {
                        divIndustryTSIPASS.Visible = true;
                        lblIndustryStatusTsipassOld.InnerHtml = ds.Tables[0].Rows[0]["TypeOfIndustryOldText"].ToString();
                    }

                    if (ds.Tables[0].Rows[0]["TypeOfIndustry"].ToString() != "")
                    {
                        ddlIndustryStatus.SelectedValue = ds.Tables[0].Rows[0]["TypeOfIndustry"].ToString();
                        ddlindustryStatus_SelectedIndexChanged(this, EventArgs.Empty);
                    }
                    if (ds.Tables[0].Rows[0]["IndustryExpansionType"].ToString() != "")
                    {
                        ddlInustryExpansionType.SelectedValue = ds.Tables[0].Rows[0]["IndustryExpansionType"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["SpecialIncentiveYN"].ToString() != "")
                    {
                        ddlSpecialIncentive.SelectedValue = ds.Tables[0].Rows[0]["SpecialIncentiveYN"].ToString();
                        ddlSpecialIncentive_SelectedIndexChanged(this, EventArgs.Empty);
                        if (ddlSpecialIncentive.SelectedValue == "Y")
                        {
                            txtGovermentOrderNumber.Text = ds.Tables[0].Rows[0]["GovermentOrderNumber"].ToString();
                            txtGovermentOrderDate.Text = ds.Tables[0].Rows[0]["GovermentOrderDate"].ToString();
                        }
                    }

                    BindLineofActivityDtls(Session["IncentiveID"].ToString(), "New");
                    BindLineofActivityDtls(Session["IncentiveID"].ToString(), "Exp");
                    BindDirectorDtls(Session["IncentiveID"].ToString());


                    if (ds.Tables[0].Rows[0]["DCP"].ToString() != "")
                    {
                        txtDateofCommencement.Text = ds.Tables[0].Rows[0]["DCP"].ToString();
                        GetFinancialYears(GetFromatedDateDDMMYYYY(ds.Tables[0].Rows[0]["DCP"].ToString()));
                    }
                    if (ds.Tables[0].Rows[0]["DCPExp"].ToString() != "")
                    {
                        txtDateofCommencementExp.Text = ds.Tables[0].Rows[0]["DCPExp"].ToString();
                        GetFinancialYears(GetFromatedDateDDMMYYYY(ds.Tables[0].Rows[0]["DCPExp"].ToString()));
                    }

                    if (ds.Tables[0].Rows[0]["TextileProcessType"].ToString() != "")
                    {
                        ddlTextileProcessType.SelectedValue = ds.Tables[0].Rows[0]["TextileProcessType"].ToString();
                        ddlTextileProcessType_SelectedIndexChanged(this, EventArgs.Empty);
                        txtNewOtherTextileProcessType.Text = ds.Tables[0].Rows[0]["NewOtherTextileProcessType"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["TextileProcessTypeExp"].ToString() != "")
                    {
                        ddlTextileProcessTypeExp.Text = ds.Tables[0].Rows[0]["TextileProcessTypeExp"].ToString();
                        ddlTextileProcessTypeExp_SelectedIndexChanged(this, EventArgs.Empty);
                        txtExistOtherTextileProcessType.Text = ds.Tables[0].Rows[0]["ExistOtherTextileProcessType"].ToString();
                    }

                    txtAuthorisedPerson.Text = ds.Tables[0].Rows[0]["AuthorisedPerson"].ToString();
                    if (ds.Tables[0].Rows[0]["AuthorisedSignatoryDesignation"].ToString() != "")
                    {
                        ddlAuthorisedSignDesignation.SelectedValue = ds.Tables[0].Rows[0]["AuthorisedSignatoryDesignation"].ToString();
                    }

                    txtPanNoAuthorised.Text = ds.Tables[0].Rows[0]["Authorized_PAN_NO"].ToString();
                    txtemailAuthorised.Text = ds.Tables[0].Rows[0]["Authorized_EmailId"].ToString();
                    txtMobileNumberAuthorised.Text = ds.Tables[0].Rows[0]["Authorized_MobileNo"].ToString();
                    txtCorrespondenceAddress.Text = ds.Tables[0].Rows[0]["Authorized_CorresponAdderess"].ToString();


                    // TAB 3
                    txtstaffMale.Text = ds.Tables[0].Rows[0]["ManagementStaffMale"].ToString();
                    txtfemale.Text = ds.Tables[0].Rows[0]["ManagementStaffFemale"].ToString();
                    txtsupermalecount.Text = ds.Tables[0].Rows[0]["SupervisoryMale"].ToString();
                    txtsuperfemalecount.Text = ds.Tables[0].Rows[0]["SupervisoryFemale"].ToString();
                    txtSkilledWorkersMale.Text = ds.Tables[0].Rows[0]["SkilledWorkersMale"].ToString();
                    txtSkilledWorkersFemale.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemale"].ToString();
                    txtSemiSkilledWorkersMale.Text = ds.Tables[0].Rows[0]["SemiSkilledWorkersMale"].ToString();
                    txtSemiSkilledWorkersFemale.Text = ds.Tables[0].Rows[0]["SemiSkilledWorkersFemale"].ToString();

                    txtstaffMaleNonLocal.Text = ds.Tables[0].Rows[0]["ManagementStaffMaleNonLocal"].ToString();
                    txtfemaleNonLocal.Text = ds.Tables[0].Rows[0]["ManagementStaffFemaleNonLocal"].ToString();
                    txtsupermalecountNonLocal.Text = ds.Tables[0].Rows[0]["SupervisoryMaleNonLocal"].ToString();
                    txtsuperfemalecountNonLocal.Text = ds.Tables[0].Rows[0]["SupervisoryFemaleNonLocal"].ToString();
                    txtSkilledWorkersMaleNonLocal.Text = ds.Tables[0].Rows[0]["SkilledWorkersMaleNonLocal"].ToString();
                    txtSkilledWorkersFemaleNonLocal.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemaleNonLocal"].ToString();
                    txtSemiSkilledWorkersMaleNonLocal.Text = ds.Tables[0].Rows[0]["SemiSkilledWorkersMaleNonLocal"].ToString();
                    txtSemiSkilledWorkersFemaleNonLocal.Text = ds.Tables[0].Rows[0]["SemiSkilledWorkersFemaleNonLocal"].ToString();

                    //txtstaffMaleInDirect.Text = ds.Tables[0].Rows[0]["ManagementStaffMaleindirect"].ToString();
                    //txtsupermalecountInDirect.Text = ds.Tables[0].Rows[0]["SupervisoryMaleindirect"].ToString();
                    //txtSkilledWorkersMaleInDirect.Text = ds.Tables[0].Rows[0]["SkilledWorkersMaleindirect"].ToString();
                    //txtSemiSkilledWorkersMaleIndirect.Text = ds.Tables[0].Rows[0]["SemiSkilledWorkersFemaleindirect"].ToString();

                    //txtfemaleInDirect.Text = ds.Tables[0].Rows[0]["ManagementStaffFemaleindirect"].ToString();
                    //txtsuperfemalecountInDirect.Text = ds.Tables[0].Rows[0]["SupervisoryFemaleindirect"].ToString();
                    //txtSkilledWorkersFemaleInDirect.Text = ds.Tables[0].Rows[0]["SkilledWorkersFemaleindirect"].ToString();
                    //txtSemiSkilledWorkersFemaleIndirect.Text = ds.Tables[0].Rows[0]["SemiSkilledWorkersMaleindirect"].ToString();

                    txtEmpDirectLocalMaleOther.Text = ds.Tables[0].Rows[0]["EmpDirectLocalMaleOther"].ToString();
                    txtEmpDirectLocalFemaleOther.Text = ds.Tables[0].Rows[0]["EmpDirectLocalFemaleOther"].ToString();
                    txtEmpDirectNonLocalMaleOther.Text = ds.Tables[0].Rows[0]["EmpDirectNonLocalMaleOther"].ToString();
                    txtEmpDirectNonLocalFemaleOther.Text = ds.Tables[0].Rows[0]["EmpDirectNonLocalFemaleOther"].ToString();
                    //txtEmpIndirectMaleOther.Text = ds.Tables[0].Rows[0]["EmpIndirectMaleOther"].ToString();
                    //txtEmpIndirectFemaleOther.Text = ds.Tables[0].Rows[0]["EmpIndirectFemaleOther"].ToString();

                    CalculatationofEmployemnt("1");
                    CalculatationofEmployemnt("2");
                    CalculatationofEmployemnt("3");
                    CalculatationofEmployemnt("4");
                    CalculatationofEmployemnt("5");
                    CalculatationofEmployemnt("6");

                    BindIndirectEmploymentDtls(Session["IncentiveID"].ToString());

                    txtlandexisting.Text = ds.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString();
                    txtlandcapacity.Text = ds.Tables[0].Rows[0]["ExpansionDiversificationLand"].ToString();
                    txtIpassLand.Text = ds.Tables[0].Rows[0]["IpassLand_Cost"].ToString();
                    txtIpassLandExp.Text = ds.Tables[0].Rows[0]["IpassLandExp_Cost"].ToString();
                    // txtlandpercentage.Text = ds.Tables[0].Rows[0]["LandFixedCapitalInvestPercentage"].ToString();

                    txtbuildingexisting.Text = ds.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString();
                    txtbuildingcapacity.Text = ds.Tables[0].Rows[0]["ExpDiversBuilding"].ToString();
                    txtIpassBuilding.Text = ds.Tables[0].Rows[0]["IpassBuilding_Cost"].ToString();
                    txtIpassBuildingExp.Text = ds.Tables[0].Rows[0]["IpassBuildingExp_Cost"].ToString();
                    // txtbuildingpercentage.Text = ds.Tables[0].Rows[0]["BuildingFixedCapitalInvestPercentage"].ToString();

                    txtplantexisting.Text = ds.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString();
                    txtplantcapacity.Text = ds.Tables[0].Rows[0]["ExpDiversPlantMachinery"].ToString();
                    txtIpassPlantMachine.Text = ds.Tables[0].Rows[0]["IpassPlantMachine_Cost"].ToString();
                    txtIpassPlantMachineExp.Text = ds.Tables[0].Rows[0]["IpassPlantMachineExp_Cost"].ToString();
                    // txtplantpercentage.Text = ds.Tables[0].Rows[0]["PlantMachFixedCapitalInvestPercentage"].ToString();

                    //txtnewothers.Text = ds.Tables[0].Rows[0]["OtherFixedCapital"].ToString();
                    //txtexistother.Text = ds.Tables[0].Rows[0]["OtherFixedCapitalExp"].ToString();
                    //txtotherpersangage.Text = ds.Tables[0].Rows[0]["OtherFixedCapitalPercentage"].ToString();

                    CalculatationEnterprise1("1");
                    CalculatationEnterprise1("2");
                    CalculatationEnterprise1("3");

                    GetApprovedProjectPercentage("1");
                    GetApprovedProjectPercentage("2");
                    GetApprovedProjectPercentage("3");
                    GetApprovedProjectPercentage("4");

                    ddlIspowApplicable.SelectedValue = ds.Tables[0].Rows[0]["IsPowerApplicableValues"].ToString();
                    ddlIspowApplicable_SelectedIndexChanged(this, EventArgs.Empty);
                    ddlWaterSource.SelectedValue = ds.Tables[0].Rows[0]["IsWaterSourceApplicableValues"].ToString();
                    ddlWaterSource_SelectedIndexChanged(this, EventArgs.Empty);

                    BindPMabstractDtls(Session["IncentiveID"].ToString());
                    BindGrossBlockPandMGrid(0, Convert.ToInt32(Session["IncentiveID"].ToString()));


                    /* BindPandMGrid(0, Convert.ToInt32(Session["IncentiveID"].ToString())); */
                    if (ddlIspowApplicable.SelectedValue == "1")
                    {
                        if (ddlIndustryStatus.SelectedValue == "1")
                        {
                            txtNewPowerUniqueID.Text = ds.Tables[0].Rows[0]["NewPowerUniqueID"].ToString();
                            txtNewPowerCompany.Text = ds.Tables[0].Rows[0]["NewPowerCompany"].ToString();

                            txtNewPowerReleaseDate.Text = ds.Tables[0].Rows[0]["NewPowerReleaseDate"].ToString();
                            txtPowerConnectedLoad.Text = ds.Tables[0].Rows[0]["NewConnectedLoad"].ToString();
                            txtNewContractedLoad.Text = ds.Tables[0].Rows[0]["NewContractedLoad"].ToString();
                            txtServiceRateUnit.Text = ds.Tables[0].Rows[0]["NewServiceRateUnit"].ToString();
                        }
                        else
                        {
                            txtExistingPowerUniqueID.Text = ds.Tables[0].Rows[0]["ExistingPowerUniqueID"].ToString();
                            txtExistingPowerCompany.Text = ds.Tables[0].Rows[0]["ExistingPowerCompany"].ToString();

                            txtExistingPowerReleaseDate.Text = ds.Tables[0].Rows[0]["ExistingPowerReleaseDate"].ToString();
                            txtExistingPowerConnectedLoad.Text = ds.Tables[0].Rows[0]["ExistingConnectedLoad"].ToString();
                            txtExistingContractedLoad.Text = ds.Tables[0].Rows[0]["ExistingContractedLoad"].ToString();
                            txtExistingRateUnit.Text = ds.Tables[0].Rows[0]["ExistingServiceRateUnit"].ToString();

                            txtExpanDiverPowerUniqueID.Text = ds.Tables[0].Rows[0]["ExpanDiverPowerUniqueID"].ToString();
                            txtExpanDiverPowerCompany.Text = ds.Tables[0].Rows[0]["ExpanDiverPowerCompany"].ToString();

                            txtExpanDiverPowerReleaseDate.Text = ds.Tables[0].Rows[0]["ExpanDiverPowerReleaseDate"].ToString();
                            txtExpanDiverPowerConnectedLoad.Text = ds.Tables[0].Rows[0]["ExpanDiverConnectedLoad"].ToString();
                            txtExpanDiverContractedLoad.Text = ds.Tables[0].Rows[0]["ExpanDiverContractedLoad"].ToString();
                            txtExpanDiverRateUnit.Text = ds.Tables[0].Rows[0]["ExpanServiceRateUnit"].ToString();
                        }
                    }



                    txtcurrInvLandValue.Text = ds.Tables[0].Rows[0]["CurrentInvestmentLandvalue"].ToString();
                    txtcurrInvBuldvalue.Text = ds.Tables[0].Rows[0]["CurrentInvestmentBuildingvalue"].ToString();
                    txtcurrInvplantMechValue.Text = ds.Tables[0].Rows[0]["CurrentInvestmentplantMechValue"].ToString();
                    txtcurrentInvothers.Text = ds.Tables[0].Rows[0]["CurrentInvestmentOtherValue"].ToString();
                    calculateCurrInvTot();

                    txtwaterSource.Text = ds.Tables[0].Rows[0]["waterSource"].ToString();
                    txtwaterRequirement.Text = ds.Tables[0].Rows[0]["waterRequirement"].ToString();
                    txtwaterRateperunit.Text = ds.Tables[0].Rows[0]["waterRateperunit"].ToString();

                    // TAB 4

                    txtTurnoverYear1.Text = ds.Tables[0].Rows[0]["TurnOver_1stYear"].ToString();
                    txtTurnoverYear2.Text = ds.Tables[0].Rows[0]["TurnOver_2ndYear"].ToString();
                    txtTurnoverYear3.Text = ds.Tables[0].Rows[0]["TurnOver_3rdYear"].ToString();
                    txtEBITDAYear1.Text = ds.Tables[0].Rows[0]["EBITDA_1stYear"].ToString();
                    txtEBITDAYear2.Text = ds.Tables[0].Rows[0]["EBITDA_2ndYear"].ToString();
                    txtEBITDAYear3.Text = ds.Tables[0].Rows[0]["EBITDA_3rdYear"].ToString();
                    txtNetworthYear1.Text = ds.Tables[0].Rows[0]["Networth_1stYear"].ToString();
                    txtNetworthYear2.Text = ds.Tables[0].Rows[0]["Networth_2ndYear"].ToString();
                    txtNetworthYear3.Text = ds.Tables[0].Rows[0]["Networth_3rdYear"].ToString();
                    txtReservesYear1.Text = ds.Tables[0].Rows[0]["ReservesSurplus_1stYear"].ToString();
                    txtReservesYear2.Text = ds.Tables[0].Rows[0]["ReservesSurplus_2ndYear"].ToString();
                    txtReservesYear3.Text = ds.Tables[0].Rows[0]["ReservesSurplus_3rdYear"].ToString();
                    txtShareCapitalYear1.Text = ds.Tables[0].Rows[0]["Share_Capital_1stYear"].ToString();
                    txtShareCapitalYear2.Text = ds.Tables[0].Rows[0]["Share_Capital_2ndYear"].ToString();
                    txtShareCapitalYear3.Text = ds.Tables[0].Rows[0]["Share_Capital_3rdYear"].ToString();
                    if (ds.Tables[0].Rows[0]["ProductionYear1"].ToString() == "N")
                    {
                        lblProductionYear1.Text = ds.Tables[0].Rows[0]["ProductionYear1"].ToString();
                        lblProductionYear2.Text = ds.Tables[0].Rows[0]["ProductionYear2"].ToString();
                        lblProductionYear3.Text = ds.Tables[0].Rows[0]["ProductionYear3"].ToString();
                    }

                    txtProductionQuantity1.Text = ds.Tables[0].Rows[0]["ProductionQuantity1"].ToString();
                    txtProductionValue1.Text = ds.Tables[0].Rows[0]["ProductionValue1"].ToString();

                    txtProductionQuantity2.Text = ds.Tables[0].Rows[0]["ProductionQuantity2"].ToString();
                    txtProductionValue2.Text = ds.Tables[0].Rows[0]["ProductionValue2"].ToString();

                    txtProductionQuantity3.Text = ds.Tables[0].Rows[0]["ProductionQuantity3"].ToString();
                    txtProductionValue3.Text = ds.Tables[0].Rows[0]["ProductionValue3"].ToString();

                    txtPromoterEquity.Text = ds.Tables[0].Rows[0]["PromotersEquity_MF"].ToString();
                    txtInstitutionsEquity.Text = ds.Tables[0].Rows[0]["InstitutionEquity_MF"].ToString();
                    txtTearmLoans.Text = ds.Tables[0].Rows[0]["TermsLoans_M"].ToString();
                    txtMeansFinanceOthers.Text = ds.Tables[0].Rows[0]["Others_MF"].ToString();
                    txtSeedCapital.Text = ds.Tables[0].Rows[0]["SeedCapital_MF"].ToString();
                    txtSubsidyagencies.Text = ds.Tables[0].Rows[0]["SubsidyGrantsAgencies_MF"].ToString();
                    ddlIsTermLoanAvailed.SelectedValue = ds.Tables[0].Rows[0]["IsTermLoanAvailed"].ToString();
                    ddlIsTermLoanAvailed_SelectedIndexChanged(this, EventArgs.Empty);
                    BindTearmLoanDtls(Session["IncentiveID"].ToString());  // Method Call

                    txtLand2.Text = ds.Tables[0].Rows[0]["LandApprovedProjectCost"].ToString();
                    txtLand3.Text = ds.Tables[0].Rows[0]["LandLoanSactioned"].ToString();
                    txtLand4.Text = ds.Tables[0].Rows[0]["LandPromotersEquity"].ToString();
                    txtLand5.Text = ds.Tables[0].Rows[0]["LandLoanAmountReleased"].ToString();
                    txtLand6.Text = ds.Tables[0].Rows[0]["LandAssetsValuebyFinInstitution"].ToString();
                    txtLand7.Text = ds.Tables[0].Rows[0]["LandAssetsValuebyCA"].ToString();
                    txtBuilding2.Text = ds.Tables[0].Rows[0]["BuildingApprovedProjectCost"].ToString();
                    txtBuilding3.Text = ds.Tables[0].Rows[0]["BuildingLoanSactioned"].ToString();
                    txtBuilding4.Text = ds.Tables[0].Rows[0]["BuildingPromotersEquity"].ToString();
                    txtBuilding5.Text = ds.Tables[0].Rows[0]["BuildingLoanAmountReleased"].ToString();
                    txtBuilding6.Text = ds.Tables[0].Rows[0]["BuildingAssetsValuebyFinInstitution"].ToString();
                    txtBuilding7.Text = ds.Tables[0].Rows[0]["BuildingAssetsValuebyCA"].ToString();
                    txtPM2.Text = ds.Tables[0].Rows[0]["PlantMachineryApprovedProjectCost"].ToString();
                    txtPM3.Text = ds.Tables[0].Rows[0]["PlantMachineryLoanSactioned"].ToString();
                    txtPM4.Text = ds.Tables[0].Rows[0]["PlantMachineryPromotersEquity"].ToString();
                    txtPM5.Text = ds.Tables[0].Rows[0]["PlantMachineryLoanAmountReleased"].ToString();
                    txtPM6.Text = ds.Tables[0].Rows[0]["PlantMachineryAssetsValuebyFinInstitution"].ToString();
                    txtPM7.Text = ds.Tables[0].Rows[0]["PlantMachineryAssetsValuebyCA"].ToString();
                    txtMCont2.Text = ds.Tables[0].Rows[0]["MachineryContingenciesApprovedProjectCost"].ToString();
                    txtMCont3.Text = ds.Tables[0].Rows[0]["MachineryContingenciesLoanSactioned"].ToString();
                    txtMCont4.Text = ds.Tables[0].Rows[0]["MachineryContingenciesPromotersEquity"].ToString();
                    txtMCont5.Text = ds.Tables[0].Rows[0]["MachineryContingenciesLoanAmountReleased"].ToString();
                    txtMCont6.Text = ds.Tables[0].Rows[0]["MachineryContingenciesAssetsValuebyFinInstitution"].ToString();
                    txtMCont7.Text = ds.Tables[0].Rows[0]["MachineryContingenciesAssetsValuebyCA"].ToString();
                    txtErec2.Text = ds.Tables[0].Rows[0]["ErectionApprovedProjectCost"].ToString();
                    txtErec3.Text = ds.Tables[0].Rows[0]["ErectionLoanSactioned"].ToString();
                    txtErec4.Text = ds.Tables[0].Rows[0]["ErectionPromotersEquity"].ToString();
                    txtErec5.Text = ds.Tables[0].Rows[0]["ErectionLoanAmountReleased"].ToString();
                    txtErec6.Text = ds.Tables[0].Rows[0]["ErectionAssetsValuebyFinInstitution"].ToString();
                    txtErec7.Text = ds.Tables[0].Rows[0]["ErectionAssetsValuebyCA"].ToString();
                    txtTFS2.Text = ds.Tables[0].Rows[0]["TechnicalfeasibilityApprovedProjectCost"].ToString();
                    txtTFS3.Text = ds.Tables[0].Rows[0]["TechnicalfeasibilityLoanSactioned"].ToString();
                    txtTFS4.Text = ds.Tables[0].Rows[0]["TechnicalfeasibilityPromotersEquity"].ToString();
                    txtTFS5.Text = ds.Tables[0].Rows[0]["TechnicalfeasibilityLoanAmountReleased"].ToString();
                    txtTFS6.Text = ds.Tables[0].Rows[0]["TechnicalfeasibilityAssetsValuebyFinInstitution"].ToString();
                    txtTFS7.Text = ds.Tables[0].Rows[0]["TechnicalfeasibilityAssetsValuebyCA"].ToString();
                    txtWC2.Text = ds.Tables[0].Rows[0]["WorkingCapitalApprovedProjectCost"].ToString();
                    txtWC3.Text = ds.Tables[0].Rows[0]["WorkingCapitalLoanSactioned"].ToString();
                    txtWC4.Text = ds.Tables[0].Rows[0]["WorkingCapitalPromotersEquity"].ToString();
                    txtWC5.Text = ds.Tables[0].Rows[0]["WorkingCapitalLoanAmountReleased"].ToString();
                    txtWC6.Text = ds.Tables[0].Rows[0]["WorkingCapitalAssetsValuebyFinInstitution"].ToString();
                    txtWC7.Text = ds.Tables[0].Rows[0]["WorkingCapitalAssetsValuebyCA"].ToString();

                    CalculateInvSanctionTermloan("1");
                    CalculateInvSanctionTermloan("2");
                    CalculateInvSanctionTermloan("3");
                    CalculateInvSanctionTermloan("4");
                    CalculateInvSanctionTermloan("5");
                    CalculateInvSanctionTermloan("6");
                    // TAB 5

                    if (ds.Tables[0].Rows[0]["BankName"].ToString() != "")
                    {
                        ddlBank.SelectedValue = ds.Tables[0].Rows[0]["BankName"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["BankName"].ToString() != "") 
                    {
                        if (ds.Tables[0].Rows[0]["BankName"].ToString() == "999") 
                        {
                            txtBankName.Text = ds.Tables[0].Rows[0]["OtherBankName"].ToString();
                            divBankName.Visible = true;
                        }
                    }
                    if (ds.Tables[0].Rows[0]["BranchName"].ToString() != "")
                    {
                        txtBranchName.Text = ds.Tables[0].Rows[0]["BranchName"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["AccNo"].ToString() != "")
                    {
                        txtAccNumber.Text = ds.Tables[0].Rows[0]["AccNo"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["IFSCCode"].ToString() != "")
                    {
                        txtIfscCode.Text = ds.Tables[0].Rows[0]["IFSCCode"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["BankAccountName"].ToString() != "")
                    {
                        txtAccountName.Text = ds.Tables[0].Rows[0]["BankAccountName"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["BankAccType"].ToString() != "")
                    {
                        ddlAccountType.SelectedValue = ds.Tables[0].Rows[0]["BankAccType"].ToString();
                    }


                    if (ds.Tables[0].Rows[0]["AccountauthorizedPerson"].ToString() != "")
                    {
                        txtaccountauthorizedPerson.Text = ds.Tables[0].Rows[0]["AccountauthorizedPerson"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["DesignationOfAccountauthorizedPerson"].ToString() != "")
                    {
                        txtaccountauthorizedPersonDesignation.Text = ds.Tables[0].Rows[0]["DesignationOfAccountauthorizedPerson"].ToString();
                    }
                    TTAPCategory();
                    //Session["applicationStatus"] = ds.Tables[0].Rows[0]["intStatusid"].ToString();
                    string ENABLINGCONTRILS = ds.Tables[0].Rows[0]["ENABLINGCONTRILS"].ToString();
                    if ((ds.Tables[0].Rows[0]["intStatusid"].ToString() == null || ds.Tables[0].Rows[0]["intStatusid"].ToString() == "") && ENABLINGCONTRILS == "N")
                    {
                        EnableDisableForm(Page.Controls, true);
                    }
                    else
                    {
                        string applicationStatus = "";
                        applicationStatus = ds.Tables[0].Rows[0]["intStatusid"].ToString();
                        if (applicationStatus == "")
                        {
                            applicationStatus = "0";
                        }
                        if (Convert.ToInt32(applicationStatus) >= 2 || ENABLINGCONTRILS == "Y")  //3  changed on 17.11.2017 
                        {
                            DataSet dsappstatus = new DataSet();

                            dsappstatus = GetRejectedApplicationStatus(Session["IncentiveID"].ToString());
                            if (dsappstatus != null && dsappstatus.Tables.Count > 0 && dsappstatus.Tables[0].Rows.Count > 0 && dsappstatus.Tables[0].Rows[0]["ENABLEDFLAG"].ToString() == "N")
                            {
                                EnableDisableForm(Page.Controls, true);
                            }
                            else
                            {
                                EnableDisableForm(Page.Controls, false);
                                DivMachineryDetails.Visible = false;
                                gvPMAbstract.Columns[5].Visible = false;
                                gvPMAbstract.Columns[4].Visible = false;
                                grdPandM.Columns[33].Visible = false;
                                grdPandM.Columns[34].Visible = false;
                                /*Chanikya*/

                                if (UnitEditAllow == "Y")
                                {
                                    CheckEdit = ObjCAFClass.Check_Applicant_Is_Eligible_PM_Dtls(Session["IncentiveID"].ToString());
                                    if (CheckEdit == "Y")
                                    {
                                        EnableDisableForm(Div5.Controls, true);
                                        EnableDisableForm(card_PMD.Controls, true);
                                        gvPMAbstract.Columns[5].Visible = true;
                                        gvPMAbstract.Columns[4].Visible = true;
                                        grdPandM.Columns[33].Visible = true;
                                        grdPandM.Columns[34].Visible = true;
                                        rbtnInvoiceTypes_SelectedIndexChanged(null, null);
                                        AnchTab3_Click(this, EventArgs.Empty);
                                        txtTypeOfMachinery.Focus();
                                    }
                                }
                                else
                                {
                                    CheckEdit = ObjCAFClass.Check_Applicant_Is_Eligible_PM_Dtls(Session["IncentiveID"].ToString());
                                    if (CheckEdit == "A")
                                    {
                                        EnableDisableForm(Div5.Controls, true);
                                        EnableDisableForm(card_PMD.Controls, true);
                                        gvPMAbstract.Columns[5].Visible = true;
                                        gvPMAbstract.Columns[4].Visible = true;
                                        grdPandM.Columns[33].Visible = true;
                                        grdPandM.Columns[34].Visible = true;
                                        rbtnInvoiceTypes_SelectedIndexChanged(null, null);
                                        AnchTab3_Click(this, EventArgs.Empty);
                                        txtTypeOfMachinery.Focus();
                                    }
                                }
                                string CheckPMEdit = ObjCAFClass.Check_Edit_PlantandMachinary(Session["IncentiveID"].ToString());
                                if (CheckPMEdit == "Y")
                                {
                                    DivMachineryDetails.Visible = true;
                                    grdPandM.Columns[35].Visible = true;
                                    
                                }
                                DataSet dsBank = new DataSet();
                                dsBank = GetBankStatus(Session["IncentiveID"].ToString());
                                if (dsBank != null && dsBank.Tables.Count > 0 && dsBank.Tables[0].Rows.Count > 0)
                                {
                                    string BankEnable = dsBank.Tables[0].Rows[0]["EditBankDetails"].ToString();
                                    string BankDate = dsBank.Tables[0].Rows[0]["BankDetailsDate"].ToString();
                                    if ((BankEnable == "Y") && (DateTime.Now.Date <= Convert.ToDateTime(BankDate)))
                                    {
                                        EnableDisableForm(divbank.Controls, true);
                                    }
                                }
                                trlineofactivityNew.Visible = false;
                                trlineofactivityexpansion.Visible = false;
                                DivDirectorDetails.Visible = false;
                                tblTermLoanDtls.Visible = false;


                                GvLineOfactivityDetails.Columns[8].Visible = false;
                                GvLineOfactivityDetails.Columns[7].Visible = false;

                                GvLineOfactivityExpnsionDetails.Columns[8].Visible = false;
                                GvLineOfactivityExpnsionDetails.Columns[7].Visible = false;

                                GvPartnerDetails.Columns[11].Visible = false;
                                GvPartnerDetails.Columns[10].Visible = false;

                                GVTermLoandtls.Columns[14].Visible = false;
                                GVTermLoandtls.Columns[13].Visible = false;



                                gvGrossblockPandM.Columns[8].Visible = false;
                                gvGrossblockPandM.Columns[7].Visible = false;

                                GvPMPaymentDtls.Columns[11].Visible = false;

                                DivIndirectEmployment.Visible = false;
                                gvIndirectEmployment.Columns[6].Visible = false;
                                gvIndirectEmployment.Columns[5].Visible = false;

                                divPMPaymentDetails1.Visible = false;


                                btnUpload.Enabled = false;
                                btnUpload1.Enabled = false;
                            }
                        }
                        else
                        {
                            EnableDisableForm(Page.Controls, true);
                        }
                    }

                    // Tab 3 for enableing input fields
                    BindPMForPaymentProofs(Convert.ToInt32(Session["IncentiveID"].ToString()), Convert.ToInt32(ddlIndustryStatus.SelectedValue), "1");
                    BindPMTransactionDtls(Convert.ToInt32(Session["IncentiveID"].ToString()), Convert.ToInt32(ddlIndustryStatus.SelectedValue), "1");
                    /*BindPMPaymentDtls(Session["IncentiveID"].ToString(), "1");*/
                }
                else
                {
                    ds = null;
                    TSIPASSSERVICE.DepartmentApprovalSystem IpassData = new TSIPASSSERVICE.DepartmentApprovalSystem();
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
                    SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                    /* XmlElement pcboutput = IpassData.GetTSIPASSdataonUIDnumber("","");*/
                    string pcboutput = IpassData.GetTSIPASSdataonUIDnumber(TxtUidNumber.Text.Trim().TrimStart(), Session["uid"].ToString());

                    string xml = "<NewDataSet>" + ' ' + pcboutput + ' ' + "</NewDataSet>";
                    StringReader theReader = new StringReader(xml);
                    DataSet theDataSet = new DataSet();
                    theDataSet.ReadXml(theReader);
                    ds = theDataSet;

                    //ds = GetTSIpassUnitDtls(TxtUidNumber.Text.Trim().TrimStart(), Session["uid"].ToString());// ChanikyaIpass
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[1].Rows.Count > 0)
                    {
                        txtUnitName.Text = ds.Tables[1].Rows[0]["NameofIndustrialUnder"].ToString();
                        TxtUidNumber.Text = ds.Tables[1].Rows[0]["UID_No"].ToString();
                        txtApplciantName.Text = ds.Tables[1].Rows[0]["NameofthePromoter"].ToString();
                        txtPanNo.Text = ds.Tables[1].Rows[0]["PANcardno"].ToString();

                        if (ds.Tables[1].Rows[0]["Const_of_unit"].ToString() != "")
                        {
                            ddlOrgType.SelectedValue = ds.Tables[1].Rows[0]["Const_of_unit"].ToString();
                            ddlOrgType_SelectedIndexChanged(this, EventArgs.Empty);
                        }

                        if (ds.Tables[1].Rows[0]["Reg_No"].ToString() != "" && ds.Tables[1].Rows[0]["Reg_No"].ToString() != null)
                        {
                            txtEINIEMILNumber.Text = ds.Tables[1].Rows[0]["Reg_No"].ToString();
                        }
                        if (ds.Tables[1].Rows[0]["Reg_Date"].ToString() != "" && ds.Tables[1].Rows[0]["Reg_Date"].ToString() != null)
                        {
                            txtEINIEMILDate.Text = ds.Tables[1].Rows[0]["Reg_Date"].ToString();
                        }
                        if (txtEINIEMILDate.Text == "")
                        {
                            txtEINIEMILDate.Enabled = true;
                        }
                        if (txtEINIEMILNumber.Text == "")
                        {
                            txtEINIEMILNumber.Enabled = true;
                        }
                        rblCaste.SelectedValue = ds.Tables[1].Rows[0]["caste"].ToString();
                        if (rblCaste.SelectedValue == "2")
                        {
                            rblCaste_SelectedIndexChanged(this, EventArgs.Empty);
                        }
                        if (rblCaste.SelectedIndex == -1)
                        {
                            rblCaste.Enabled = true;
                        }
                        if (ds.Tables[1].Rows[0]["WomenEnterprenuer"].ToString() != "" && ds.Tables[1].Rows[0]["WomenEnterprenuer"].ToString() != "Yes")
                        {
                            ddlgender.SelectedValue = "M";
                        }
                        else
                        {
                            ddlgender.SelectedValue = "F";
                        }

                        if (ddlgender.SelectedIndex == -1)
                        {
                            ddlgender.Enabled = true;
                        }

                        if (ds.Tables[1].Rows[0]["diffabled"].ToString() != "" && ds.Tables[1].Rows[0]["diffabled"].ToString() != "Yes")
                        {
                            ddlDifferentlyabled.SelectedValue = "N";
                        }
                        else
                        {
                            ddlDifferentlyabled.SelectedValue = "Y";
                        }
                        if (ddlUnitstate.SelectedValue == "31")
                        {
                            if (ds.Tables[1].Rows[0]["District_Id"].ToString() != "")
                            {
                                ddlUnitDIst.SelectedValue = ds.Tables[1].Rows[0]["District_Id"].ToString();
                                ddldistrictunit_SelectedIndexChanged(this, EventArgs.Empty);
                            }

                            if (ds.Tables[1].Rows[0]["Mandal_Id"].ToString() != "")
                            {
                                ddlUnitMandal.SelectedValue = ds.Tables[1].Rows[0]["Mandal_Id"].ToString();
                                ddlUnitMandal_SelectedIndexChanged(this, EventArgs.Empty);
                            }

                            if (ds.Tables[1].Rows[0]["Village_Id"].ToString() != "")
                            {
                                ddlVillageunit.SelectedValue = ds.Tables[1].Rows[0]["Village_Id"].ToString();
                            }
                        }

                        txtUnitStreet.Text = ds.Tables[1].Rows[0]["Name_Gramapachayat"].ToString();
                        txtUnitHNO.Text = ds.Tables[1].Rows[0]["SurveyNo"].ToString();
                        txtunitemailid.Text = ds.Tables[1].Rows[0]["Land_Email"].ToString();
                        //txtunitmobileno.Text = ds.Tables[1].Rows[0]["Land_TelephoneNumber"].ToString();

                        if (ds.Tables[1].Rows[0]["intStateid"].ToString() != "")
                        {
                            ddloffcstate.SelectedValue = ds.Tables[1].Rows[0]["intStateid"].ToString();
                        }
                        //Office District Binding 
                        if (ds.Tables[1].Rows[0]["intStateid"].ToString() == "31")
                        {
                            ddloffcstate_SelectedIndexChanged(this, EventArgs.Empty);
                            if (ds.Tables[1].Rows[0]["distid"].ToString() != "")
                            {
                                ddlOffcDIst.SelectedValue = ds.Tables[1].Rows[0]["distid"].ToString();
                                ddldistrictoffc_SelectedIndexChanged(this, EventArgs.Empty);
                            }
                            if (ds.Tables[1].Rows[0]["mandid"].ToString() != "")
                            {
                                ddlOffcMandal.SelectedValue = ds.Tables[1].Rows[0]["mandid"].ToString();
                                ddloffcmandal_SelectedIndexChanged(this, EventArgs.Empty);
                            }
                            if (ds.Tables[1].Rows[0]["villid"].ToString() != "")
                            {
                                ddlOffcVil.SelectedValue = ds.Tables[1].Rows[0]["villid"].ToString();
                            }
                        }
                        else
                        {
                            ddloffcstate_SelectedIndexChanged(this, EventArgs.Empty);
                            if (ds.Tables[1].Rows[0]["distname"].ToString() != "")
                            {
                                txtofficedist.Text = ds.Tables[1].Rows[0]["distname"].ToString();
                            }
                            if (ds.Tables[1].Rows[0]["MName"].ToString() != "")
                            {
                                txtoffcicemandal.Text = ds.Tables[1].Rows[0]["MName"].ToString();
                            }
                            if (ds.Tables[1].Rows[0]["VillName"].ToString() != "")
                            {
                                txtofficeviiage.Text = ds.Tables[1].Rows[0]["VillName"].ToString();
                            }
                        }

                        txtOffcStreet.Text = ds.Tables[1].Rows[0]["StreetName"].ToString();
                        txtOffSurveyNo.Text = ds.Tables[1].Rows[0]["Door_No"].ToString();
                        if (ds.Tables[1].Rows[0]["MobileNumber"].ToString() != "")
                        {
                            txtOffcMobileNO.Text = ds.Tables[1].Rows[0]["MobileNumber"].ToString();
                            if (txtunitmobileno.Text.Trim().TrimStart() == "")
                            {
                                txtunitmobileno.Text = ds.Tables[1].Rows[0]["MobileNumber"].ToString();
                            }
                        }
                        txtOffcEmail.Text = ds.Tables[1].Rows[0]["Email"].ToString();

                        if (ds.Tables[1].Rows[0]["TypeofFactory"].ToString() != "")
                        {
                            ddlIndustryStatus.SelectedValue = ds.Tables[1].Rows[0]["TypeofFactory"].ToString();
                            ddlindustryStatus_SelectedIndexChanged(this, EventArgs.Empty);
                        }

                        //txtlandexisting.Text = ds.Tables[0].Rows[0]["Land_Value"].ToString();
                        //txtbuildingexisting.Text = ds.Tables[0].Rows[0]["Building_value"].ToString();
                        //txtplantexisting.Text = ds.Tables[0].Rows[0]["plant_value"].ToString();

                        txtlandexisting.Text = ds.Tables[1].Rows[0]["Val_Land"].ToString();
                        txtbuildingexisting.Text = ds.Tables[1].Rows[0]["Val_Build"].ToString();
                        txtplantexisting.Text = ds.Tables[1].Rows[0]["Val_Plant"].ToString();

                        txtIpassLand.Text = ds.Tables[1].Rows[0]["Val_Land"].ToString();
                        txtIpassBuilding.Text = ds.Tables[1].Rows[0]["Val_Build"].ToString();
                        txtIpassPlantMachine.Text = ds.Tables[1].Rows[0]["Val_Plant"].ToString();

                        if (ddlIndustryStatus.SelectedValue != "1")
                        {
                            if (ds.Tables[1].Rows[0]["Val_LandExpansion"].ToString() != " " && ds.Tables[1].Rows[0]["Val_LandExpansion"].ToString() == null)
                            {
                                txtlandcapacity.Text = ds.Tables[1].Rows[0]["Val_LandExpansion"].ToString();
                                txtIpassLandExp.Text = ds.Tables[1].Rows[0]["Val_LandExpansion"].ToString();
                            }
                            if (ds.Tables[1].Rows[0]["Val_BuildExpansion"].ToString() != "" && ds.Tables[1].Rows[0]["Val_BuildExpansion"].ToString() == null)
                            {
                                txtbuildingcapacity.Text = ds.Tables[1].Rows[0]["Val_BuildExpansion"].ToString();
                                txtIpassBuildingExp.Text = ds.Tables[1].Rows[0]["Val_BuildExpansion"].ToString();
                            }
                            if (ds.Tables[1].Rows[0]["Val_PlantExpansion"].ToString() != "" && ds.Tables[1].Rows[0]["Val_PlantExpansion"].ToString() == null)
                            {
                                txtplantcapacity.Text = ds.Tables[1].Rows[0]["Val_PlantExpansion"].ToString();
                                txtIpassPlantMachineExp.Text = ds.Tables[1].Rows[0]["Val_PlantExpansion"].ToString();
                            }
                        }

                        txtstaffMale.Text = ds.Tables[1].Rows[0]["DirectMale"].ToString();
                        txtfemale.Text = ds.Tables[1].Rows[0]["DirectFemale"].ToString();

                        //txtstaffMaleInDirect.Text = ds.Tables[0].Rows[0]["InDirectMale"].ToString();
                        //txtfemaleInDirect.Text = ds.Tables[0].Rows[0]["InDirectFemale"].ToString();


                        CalculatationofEmployemnt("1");
                        CalculatationofEmployemnt("2");
                        CalculatationofEmployemnt("3");
                        CalculatationofEmployemnt("4");

                        CalculatationEnterprise1("1");
                        CalculatationEnterprise1("2");
                        CalculatationEnterprise1("3");
                    }
                    else
                    {
                        Response.Redirect("~/LoginReg.aspx");
                    }
                }
                DataSet dsapprovals = new DataSet();
                TSIPASSSERVICE.DepartmentApprovalSystem IpassDataCFE = new TSIPASSSERVICE.DepartmentApprovalSystem();
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
                SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                string outputCFE = IpassDataCFE.GetTSIPASSTrackeronUIDnumber(TxtUidNumber.Text, "");
                DataSet theDataSetCFE = new DataSet();
                if (outputCFE != "<NewDataSet />")
                {
                    string xmlCFE = "<NewDataSet>" + ' ' + outputCFE + ' ' + "</NewDataSet>";
                    StringReader Reader = new StringReader(xmlCFE);
                    theDataSetCFE.ReadXml(Reader);
                    dsapprovals = theDataSetCFE;
                }

                /*dsapprovals = GetApplicationTrackerDetailed_CFE(TxtUidNumber.Text);*/

                if (dsapprovals != null && dsapprovals.Tables.Count > 0 && dsapprovals.Tables[1].Rows.Count > 0)
                {
                    grdDetails.DataSource = dsapprovals.Tables[1];
                    grdDetails.DataBind();
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

        public void DisableTSIPASSInputs(Boolean TrueFalse)
        {
            Boolean BoolTrue = false;
            TxtUidNumber.Enabled = TrueFalse;
            if (txtUnitName.Text.Trim().TrimStart() != "")
            {
                txtUnitName.Enabled = TrueFalse;
            }
            else
            {
                txtUnitName.Enabled = BoolTrue;
            }
            if (txtUnitName.Text.Trim().TrimStart() != "")
            {
                txtApplciantName.Enabled = TrueFalse;
            }
            else
            {
                txtApplciantName.Enabled = BoolTrue;
            }
            if (txtPanNo.Text.Trim().TrimStart() != "")
            {
                txtPanNo.Enabled = TrueFalse;
            }
            else
            {
                txtPanNo.Enabled = BoolTrue;
            }
            if (ddlOrgType.SelectedValue == "0")
            {
                ddlOrgType.Enabled = TrueFalse;
            }
            else
            {
                ddlOrgType.Enabled = BoolTrue;
            }
            if (txtEINIEMILNumber.Text.Trim().TrimStart() != "")
            {
                txtEINIEMILNumber.Enabled = TrueFalse;
            }
            else
            {
                txtEINIEMILNumber.Enabled = BoolTrue;
            }
            if (txtEINIEMILDate.Text.Trim().TrimStart() != "")
            {
                txtEINIEMILDate.Enabled = TrueFalse;
            }
            else
            {
                txtEINIEMILDate.Enabled = BoolTrue;
            }
            if (rblCaste.SelectedValue == "0")
            {
                rblCaste.Enabled = TrueFalse;
            }
            else
            {
                rblCaste.Enabled = BoolTrue;
            }
            if (ddlgender.SelectedValue == "0")
            {
                ddlgender.Enabled = TrueFalse;
            }
            else
            {
                ddlgender.Enabled = BoolTrue;
            }
            if (ddlDifferentlyabled.SelectedValue == "0")
            {
                ddlDifferentlyabled.Enabled = TrueFalse;
            }
            else
            {
                ddlDifferentlyabled.Enabled = BoolTrue;
            }
            if (ddlUnitstate.SelectedValue == "0")
            {
                ddlUnitstate.Enabled = TrueFalse;
            }
            else
            {
                ddlUnitstate.Enabled = BoolTrue;
            }
            if (ddlUnitMandal.SelectedValue == "0")
            {
                ddlUnitMandal.Enabled = TrueFalse;
            }
            else
            {
                ddlUnitMandal.Enabled = BoolTrue;
            }
            if (ddlVillageunit.SelectedValue == "0")
            {
                ddlVillageunit.Enabled = TrueFalse;
            }
            else
            {
                ddlVillageunit.Enabled = BoolTrue;
            }
            if (txtUnitStreet.Text.Trim().TrimStart() != "")
            {
                txtUnitStreet.Enabled = TrueFalse;
            }
            else
            {
                txtUnitStreet.Enabled = BoolTrue;
            }
            if (txtUnitHNO.Text.Trim().TrimStart() != "")
            {
                txtUnitHNO.Enabled = TrueFalse;
            }
            else
            {
                txtUnitHNO.Enabled = BoolTrue;
            }
            if (txtunitemailid.Text.Trim().TrimStart() != "")
            {
                txtunitemailid.Enabled = TrueFalse;
            }
            else
            {
                txtunitemailid.Enabled = BoolTrue;
            }

            if (txtunitmobileno.Text.Trim().TrimStart() != "")
            {
                txtunitmobileno.Enabled = TrueFalse;
            }
            else
            {
                txtunitmobileno.Enabled = BoolTrue;
            }
            if (ddlIndustryStatus.SelectedValue == "0")
            {
                ddlIndustryStatus.Enabled = TrueFalse;
            }
            else
            {
                ddlIndustryStatus.Enabled = BoolTrue;
            }
            if (txtlandexisting.Text.Trim().TrimStart() != "")
            {
                txtlandexisting.Enabled = TrueFalse;
            }
            else
            {
                txtlandexisting.Enabled = BoolTrue;
            }
            if (txtbuildingexisting.Text.Trim().TrimStart() != "")
            {
                txtbuildingexisting.Enabled = TrueFalse;
            }
            else
            {
                txtbuildingexisting.Enabled = BoolTrue;
            }
            if (txtplantexisting.Text.Trim().TrimStart() != "")
            {
                txtplantexisting.Enabled = TrueFalse;
            }
            else
            {
                txtplantexisting.Enabled = BoolTrue;
            }
            if (txtlandcapacity.Text.Trim().TrimStart() != "")
            {
                txtlandcapacity.Enabled = TrueFalse;
            }
            else
            {
                txtlandcapacity.Enabled = BoolTrue;
            }
            if (txtbuildingcapacity.Text.Trim().TrimStart() != "")
            {
                txtbuildingcapacity.Enabled = TrueFalse;
            }
            else
            {
                txtbuildingcapacity.Enabled = BoolTrue;
            }
            if (txtplantcapacity.Text.Trim().TrimStart() != "")
            {
                txtplantcapacity.Enabled = TrueFalse;
            }
            else
            {
                txtplantcapacity.Enabled = BoolTrue;
            }
            if (txtIpassLand.Text.Trim().TrimStart() != "")
            {
                txtIpassLand.Enabled = TrueFalse;
            }
            else
            {
                txtIpassLand.Enabled = BoolTrue;
            }
            if (txtIpassLandExp.Text.Trim().TrimStart() != "")
            {
                txtIpassLandExp.Enabled = TrueFalse;
            }
            else
            {
                txtIpassLandExp.Enabled = BoolTrue;
            }
            if (txtIpassBuilding.Text.Trim().TrimStart() != "")
            {
                txtIpassBuilding.Enabled = TrueFalse;
            }
            else
            {
                txtIpassBuilding.Enabled = BoolTrue;
            }
            if (txtIpassBuildingExp.Text.Trim().TrimStart() != "")
            {
                txtIpassBuildingExp.Enabled = TrueFalse;
            }
            else
            {
                txtIpassBuildingExp.Enabled = BoolTrue;
            }
            if (txtIpassPlantMachine.Text.Trim().TrimStart() != "")
            {
                txtIpassPlantMachine.Enabled = TrueFalse;
            }
            else
            {
                txtIpassPlantMachine.Enabled = BoolTrue;
            }
            if (txtIpassPlantMachineExp.Text.Trim().TrimStart() != "")
            {
                txtIpassPlantMachineExp.Enabled = TrueFalse;
            }
            else
            {
                txtIpassPlantMachineExp.Enabled = BoolTrue;
            }

            txtplantpercentage.Enabled = TrueFalse;
            txtbuildingpercentage.Enabled = TrueFalse;
            txtlandpercentage.Enabled = TrueFalse;
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
        public void TTAPCategory()
        {
            int TotalEmployement = 0;
            double totalinvestment = 0.00;

            if (lblDirectMale.Text.Trim() != "")
            {
                TotalEmployement = TotalEmployement + Convert.ToInt32(lblDirectMale.Text.Trim());
            }
            if (lblDirectFeMale.Text.Trim() != "")
            {
                TotalEmployement = TotalEmployement + Convert.ToInt32(lblDirectFeMale.Text.Trim());
            }
            if (lblDirectMaleNonLocal.Text.Trim() != "")
            {
                TotalEmployement = TotalEmployement + Convert.ToInt32(lblDirectMaleNonLocal.Text.Trim());
            }
            if (lblDirectFeMaleNonLocal.Text.Trim() != "")
            {
                TotalEmployement = TotalEmployement + Convert.ToInt32(lblDirectFeMaleNonLocal.Text.Trim());
            }


            if (ddlIndustryStatus.SelectedValue == "1")
            {
                if (lblnewinv.Text.Trim() != "")
                {
                    totalinvestment = totalinvestment + Convert.ToDouble(lblnewinv.Text.Trim());
                }
            }
            else
            {
                //if (lblnewinv.Text.Trim() != "")
                //{
                //    totalinvestment = totalinvestment + Convert.ToDouble(lblnewinv.Text.Trim());
                //}
                if (lblexpinv.Text.Trim() != "")
                {
                    totalinvestment = totalinvestment + Convert.ToDouble(lblexpinv.Text.Trim());
                }
            }


            if (totalinvestment > 0)
            {
                totalinvestment = ((totalinvestment + 0.00) / 10000000);
            }

            string NatureOfIndustry = "";
            string Category = "";
            if (ddlIndustryStatus.SelectedValue == "1")
            {
                NatureOfIndustry = ddlTextileProcessType.SelectedValue;
            }
            else
            {
                NatureOfIndustry = ddlTextileProcessTypeExp.SelectedValue;
            }

            if (totalinvestment > 200 || TotalEmployement >= 1000)
            {
                Category = "A5";
            }
            else if ((totalinvestment > 100 && totalinvestment <= 200) || TotalEmployement >= 500)
            {
                Category = "A4";
            }
            else if ((totalinvestment > 50 && totalinvestment <= 100) || TotalEmployement >= 300)
            {
                Category = "A3";
            }
            else if ((totalinvestment > 10 && totalinvestment <= 50) && (TotalEmployement > 50) && NatureOfIndustry != "3")
            {
                Category = "A2";
            }
            else if (((totalinvestment > 10 && totalinvestment <= 50) || (TotalEmployement > 50)) && NatureOfIndustry == "3")
            {
                Category = "A2";
            }
            else if (totalinvestment <= 10 && TotalEmployement >= 50 && NatureOfIndustry != "3")
            {
                Category = "A1";
            }
            else if ((totalinvestment <= 10 || TotalEmployement >= 50) && NatureOfIndustry == "3")
            {
                Category = "A1";
            }

            lblEnterpriseCategory.Text = Category;
            HiddenFieldEnterpriseCategory.Value = Category;
            Session["SCategoryofUnit"] = Category;
        }


        public DataSet GetDirectorDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_DIRECTOR_PARTNER_DTLS", pp);
            return Dsnew;
        }
        public void BindDocumentsList(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;

            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_INCENTIVE_DOCSLIST", pp);
            if (Dsnew != null && Dsnew.Tables.Count > 0 && Dsnew.Tables[0].Rows.Count > 0)
            {
                ddltypeofDocuments.DataSource = Dsnew.Tables[0];
                ddltypeofDocuments.DataValueField = "TypeOfDcoumentID";
                ddltypeofDocuments.DataTextField = "TypeOfDcoument";
                ddltypeofDocuments.DataBind();
                AddSelect(ddltypeofDocuments);

                ViewState["DOCSLIST"] = Dsnew;

                foreach (ListItem li in ddltypeofDocuments.Items)
                {
                    string TypeOfDcoumentID = li.Value;

                    DataRow[] drs = Dsnew.Tables[0].Select("TypeOfDcoumentID = " + TypeOfDcoumentID);
                    if (drs.Length > 0)
                    {
                        if (drs[0]["UPLOADFLAG"].ToString() == "Y")
                        {
                            ddltypeofDocuments.Items[ddltypeofDocuments.Items.IndexOf(ddltypeofDocuments.Items.FindByValue(li.Value))].Attributes.Add("style", "color: #00cc00 !important;");
                        }
                        if (drs[0]["UPLOADFLAG"].ToString() == "N" && drs[0]["MandatoryFlag"].ToString() == "Y")
                        {
                            ddltypeofDocuments.Items[ddltypeofDocuments.Items.IndexOf(ddltypeofDocuments.Items.FindByValue(li.Value))].Attributes.Add("style", "color: #ff3300 !important;");
                        }
                    }
                }
            }
        }
        protected void BindDirectorDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetDirectorDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    GvPartnerDetails.DataSource = dsnew.Tables[0];
                    GvPartnerDetails.DataBind();
                }
                else
                {
                    GvPartnerDetails.DataSource = null;
                    GvPartnerDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetTermLoanDtlsDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_TERMLOAN_DTLS", pp);
            return Dsnew;
        }

        protected void BindTearmLoanDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetTermLoanDtlsDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    GVTermLoandtls.DataSource = dsnew.Tables[0];
                    GVTermLoandtls.DataBind();
                }
                else
                {
                    GVTermLoandtls.DataSource = null;
                    GVTermLoandtls.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        protected void btnInstalledcap_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["LineofActivityId"] == null)
                {
                    ViewState["LineofActivityId"] = "0";
                }

                string errormsg = ValidateLoA("1");
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

                    IndustryLineofActivities objNewInds = new IndustryLineofActivities();
                    objNewInds.slno = ViewState["LineofActivityId"].ToString();
                    objNewInds.LineOfActivity = txtLOActivity.Text.Trim().TrimStart();
                    objNewInds.InstalledCapacity = txtinstalledccap.Text.Trim().TrimStart();
                    objNewInds.Unit = ddlquantityin.SelectedValue;
                    objNewInds.ValuePerUnitRs = txtValuePerUnit.Text.Trim().TrimStart();
                    objNewInds.ValueRs = txtvalue.Text.Trim();
                    objNewInds.Created_by = ObjLoginNewvo.uid;
                    objNewInds.LOAType = "New";
                    objNewInds.TransType = "INS";
                    objNewInds.IncentiveId = Session["IncentiveID"].ToString();

                    string Validstatus = ObjCAFClass.InsertLineOfActivityDtlsTAB2(objNewInds);
                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        btnInstalledcap.Text = "Add New";
                        ViewState["LineofActivityId"] = "0";
                        txtLOActivity.Text = "";
                        txtinstalledccap.Text = "";
                        ddlquantityin.SelectedValue = "0";
                        txtValuePerUnit.Text = "";
                        txtvalue.Text = "";
                        BindLineofActivityDtls(Session["IncentiveID"].ToString(), "New");
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
        public string IndirectEmpValidation()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (txtCategory.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Indirect Employment Category" + "\\n";
                slno = slno + 1;
            }
            if (txtIndirectMale.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Indirect Male Employment" + "\\n";
                slno = slno + 1;
            }
            if (txtIndirectFemale.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Indirect Female Employment" + "\\n";
                slno = slno + 1;
            }

            return ErrorMsg;
        }
        public string ValidateLoA(string Type)
        {
            int slno = 1;
            string ErrorMsg = "";
            if (Type == "1")
            {
                if (txtLOActivity.Text == "" || txtLOActivity.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Product Cannot be blank" + "\\n";
                    slno = slno + 1;
                }
                if (ddlquantityin.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Unit" + "\\n";
                    slno = slno + 1;
                }
                else if (ddlquantityin.SelectedItem.Text == "Others")
                {
                    if (txtunit.Text == "" || txtunit.Text == null)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Unit Cannot be blank" + "\\n";
                        slno = slno + 1;
                    }
                }
                if (txtinstalledccap.Text == "" || txtinstalledccap.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Installed Capacity Cannot be blank" + "\\n";
                    slno = slno + 1;
                }
                if (txtValuePerUnit.Text == "" || txtValuePerUnit.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Value Per Unit Cannot be blank" + "\\n";
                    slno = slno + 1;
                }
                if (txtvalue.Text == "" || txtvalue.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Value Cannot be blank" + "\\n";
                    slno = slno + 1;
                }
            }
            else if (Type == "2")
            {
                if (txtLOActivityExpan.Text == "" || txtLOActivityExpan.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Product Cannot be blank" + "\\n";
                    slno = slno + 1;
                }
                if (ddlquantityinExpan.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Unit" + "\\n";
                    slno = slno + 1;
                }
                else if (ddlquantityinExpan.SelectedItem.Text == "Others")
                {
                    if (txtunit.Text == "" || txtunit.Text == null)
                    {
                        ErrorMsg = ErrorMsg + slno + ". Unit Cannot be blank" + "\\n";
                        slno = slno + 1;
                    }
                }
                if (txtinstalledccapExpan.Text == "" || txtinstalledccap.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Installed Capacity Cannot be blank" + "\\n";
                    slno = slno + 1;
                }
                if (txtvalueExpanPerUnit.Text == "" || txtvalueExpanPerUnit.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Value Per Unit Cannot be blank" + "\\n";
                    slno = slno + 1;
                }
                if (txtvalueExpan.Text == "" || txtvalue.Text == null)
                {
                    ErrorMsg = ErrorMsg + slno + ". Value Cannot be blank" + "\\n";
                    slno = slno + 1;
                }
            }
            else if (Type == "3")
            {
                if (txtNameofDirector.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Name" + "\\n";
                    slno = slno + 1;
                }
                if (ddlDirectorDesignation.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Authorised Person designation" + "\\n";
                    slno = slno + 1;
                }
                if (ddlEducationalQualificationPatners.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Educational Qualification" + "\\n";
                    slno = slno + 1;
                }
                else if (ddlEducationalQualificationPatners.SelectedValue == "22")
                {
                    if (txtEducationalQual.Text == "")
                    {
                        ErrorMsg = ErrorMsg + slno + ". Please Enter Educational Qualification" + "\\n";
                        slno = slno + 1;
                    }
                }
                if (txtYearsOfExpinTexttileDirector.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Years of Experience in Textiles" + "\\n";
                    slno = slno + 1;
                }
                if (txtshare.Text.Trim().TrimStart() == "" || txtshare.Text.Trim().TrimStart() == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Share %" + "\\n";
                    slno = slno + 1;
                }
                else if (Convert.ToDecimal(txtshare.Text) > 100)
                {
                    ErrorMsg = ErrorMsg + slno + ". Share % Should Not be More than 100%" + "\\n";
                    slno = slno + 1;
                }
                else
                {
                    decimal SharePercentage = 0;

                    if (GvPartnerDetails.Rows.Count > 0)
                    {
                        foreach (GridViewRow Gvrow in GvPartnerDetails.Rows)
                        {
                            string Share_Per = (Gvrow.FindControl("lblShare") as Label).Text;
                            string DirectorPartnerID = (Gvrow.FindControl("lblDirectorPartnerID") as Label).Text;
                            string EditDirectorPartnerID = "";
                            if (ViewState["Director_Partner_ID"] != null)
                            {
                                EditDirectorPartnerID = ViewState["Director_Partner_ID"].ToString();
                            }
                            if (DirectorPartnerID != EditDirectorPartnerID)
                            {
                                if (Share_Per != "" && Share_Per != "0")
                                {
                                    SharePercentage = SharePercentage + Convert.ToDecimal(Share_Per);
                                }
                            }
                        }
                        SharePercentage = SharePercentage + Convert.ToDecimal(txtshare.Text.Trim().TrimStart());
                        if (SharePercentage > 100)
                        {
                            ErrorMsg = ErrorMsg + slno + ".Total Share % Should Not be More than 100%" + "\\n";
                            slno = slno + 1;
                        }
                    }
                }
                if (txtPanNoDirector.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Pan Number" + "\\n";
                    slno = slno + 1;
                }
                if (txtunitmobilenoDirector.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Mobile Number" + "\\n";
                    slno = slno + 1;
                }
                if (txtunitemailidDirector.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Email" + "\\n";
                    slno = slno + 1;
                }
                if (ddlOrgType.SelectedValue == "1" && GvPartnerDetails.Rows.Count == 1)
                {
                    ErrorMsg = ErrorMsg + slno + ". You can not add more Proprietors" + "\\n";
                    slno = slno + 1;
                }
            }
            else if (Type == "4")
            {
                string TermLoanApplicationDate = "";
                string TeamloanSanctionedDate = "";
                string TermLoanReleasedDatea = "";
                string TermLoanPeriodFromDate = "";
                string TermLoanPeriodToDate = "";


                if (ddlTermLoanNo.SelectedValue == "--Select--" || ddlTermLoanNo.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ".Please Select Term Loan No" + "\\n";
                    slno = slno + 1;
                }
                if (txtTermLoanDate.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ".Please enter term loan application date " + "\\n";
                    slno = slno + 1;
                }
                else
                {
                    TermLoanApplicationDate = GetFromatedDateDDMMYYYY(txtTermLoanDate.Text.Trim().TrimStart());
                }
                if (ddltermloanbank.SelectedValue == "--Select--" || ddltermloanbank.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ".Please select Name of the Institution" + "\\n";
                    slno = slno + 1;
                }
                if (ddltermloanbank.SelectedValue == "999") 
                {
                    if (txtInstitution.Text == "") 
                    {
                        ErrorMsg = ErrorMsg + slno + ".Please Enter Name of the Institution" + "\\n";
                        slno = slno + 1;
                    }
                }
                if (txtsactionedloanreferenceNo.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ".Please enter term loan sanctioned reference no" + "\\n";
                    slno = slno + 1;
                }
                if (txtTeamloanSanctionedDate.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ".Please enter term loan sanctioned date" + "\\n";
                    slno = slno + 1;
                }
                else
                {
                    TeamloanSanctionedDate = GetFromatedDateDDMMYYYY(txtTeamloanSanctionedDate.Text.Trim().TrimStart());
                }
                if (txtTermLoanReleasedDatea.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ".Please enter term loan Released date" + "\\n";
                    slno = slno + 1;
                }
                else
                {
                    TermLoanReleasedDatea = GetFromatedDateDDMMYYYY(txtTermLoanReleasedDatea.Text.Trim().TrimStart());
                }
                if (txtInstallments.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter No.of installments" + "\\n";
                    slno = slno + 1;
                }
                if (txttermloanRateOfInterest.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Rate Of Interest of Termloan" + "\\n";
                    slno = slno + 1;
                }
                if (txtSanctionedAmount.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Amount Sanctioned (Rs.)" + "\\n";
                    slno = slno + 1;
                }
                if (txtTermLoanPeriodFromDate.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Term Loan Period - From Date" + "\\n";
                    slno = slno + 1;
                }
                else
                {
                    TermLoanPeriodFromDate = GetFromatedDateDDMMYYYY(txtTermLoanPeriodFromDate.Text.Trim().TrimStart());
                }

                if (txtTermLoanPeriodToDate.Text == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Term Loan Period - To Date" + "\\n";
                    slno = slno + 1;
                }
                else
                {
                    TermLoanPeriodToDate = GetFromatedDateDDMMYYYY(txtTermLoanPeriodToDate.Text.Trim().TrimStart());
                }

                if (TermLoanApplicationDate != "" && TeamloanSanctionedDate != "")
                {
                    if (Convert.ToDateTime(TermLoanApplicationDate) <= Convert.ToDateTime((TeamloanSanctionedDate)))
                    {
                        if (TeamloanSanctionedDate != "" && TermLoanReleasedDatea != "")
                        {
                            if (Convert.ToDateTime(TeamloanSanctionedDate) <= Convert.ToDateTime((TermLoanReleasedDatea)))
                            {
                                if (TermLoanReleasedDatea != "" && TermLoanPeriodFromDate != "")
                                {
                                    if (Convert.ToDateTime(TermLoanReleasedDatea) <= Convert.ToDateTime((TermLoanPeriodFromDate)))
                                    {
                                        if (TermLoanPeriodFromDate != "" && TermLoanPeriodToDate != "")
                                        {
                                            if (Convert.ToDateTime(TermLoanPeriodFromDate) > Convert.ToDateTime((TermLoanPeriodToDate)))
                                            {
                                                ErrorMsg = ErrorMsg + slno + ". TermLoan Period - From Date Should Not be Greater than TermLoan Period - To Date" + "\\n";
                                                slno = slno + 1;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        ErrorMsg = ErrorMsg + slno + ". TermLoan Released Date Should Not be Greater than TermLoan Period - From Date" + "\\n";
                                        slno = slno + 1;
                                    }
                                }
                            }
                            else
                            {
                                ErrorMsg = ErrorMsg + slno + ". TermLoan Sanctioned Date Should Not be Greater than Teamloan Released Date" + "\\n";
                                slno = slno + 1;
                            }
                        }
                    }
                    else
                    {
                        ErrorMsg = ErrorMsg + slno + ". TermLoan Application Date Should Not be Greater than Teamloan Sanctioned Date" + "\\n";
                        slno = slno + 1;
                    }
                }
            }
            return ErrorMsg;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            btnInstalledcap.Text = "Add New";
            ViewState["LineofActivityId"] = "0";
            txtLOActivity.Text = "";
            txtinstalledccap.Text = "";
            ddlquantityin.SelectedValue = "0";
            txtvalue.Text = "";
        }

        protected void btnInstalledcapExpan_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["ExpLineofActivityId"] == null)
                {
                    ViewState["ExpLineofActivityId"] = "0";
                }

                string errormsg = ValidateLoA("2");
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

                    IndustryLineofActivities objNewInds = new IndustryLineofActivities();
                    objNewInds.slno = ViewState["ExpLineofActivityId"].ToString();
                    objNewInds.LineOfActivity = txtLOActivityExpan.Text.Trim().TrimStart();
                    objNewInds.InstalledCapacity = txtinstalledccapExpan.Text.Trim().TrimStart();
                    objNewInds.Unit = ddlquantityinExpan.SelectedValue;
                    objNewInds.ValuePerUnitRs = txtvalueExpanPerUnit.Text.Trim();
                    objNewInds.ValueRs = txtvalueExpan.Text.Trim();
                    objNewInds.Created_by = ObjLoginNewvo.uid;
                    objNewInds.LOAType = "Exp";
                    objNewInds.TransType = "INS";
                    objNewInds.IncentiveId = Session["IncentiveID"].ToString();

                    string Validstatus = ObjCAFClass.InsertLineOfActivityDtlsTAB2(objNewInds);
                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        btnInstalledcapExpan.Text = "Add New";
                        ViewState["ExpLineofActivityId"] = "0";
                        txtLOActivityExpan.Text = "";
                        txtinstalledccapExpan.Text = "";
                        ddlquantityinExpan.SelectedValue = "0";
                        txtvalueExpanPerUnit.Text = "";
                        txtvalueExpan.Text = "";
                        BindLineofActivityDtls(Session["IncentiveID"].ToString(), "Exp");
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

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void GvLineOfactivityDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                txtLOActivity.Text = ((Label)(gr.FindControl("lblLineofActivity"))).Text;
                txtinstalledccap.Text = ((Label)(gr.FindControl("lblInstalledCapacity"))).Text;
                ddlquantityin.SelectedValue = ((Label)(gr.FindControl("lblLineUnitID"))).Text;
                txtValuePerUnit.Text = ((Label)(gr.FindControl("lblValuePerUnitRs"))).Text;
                txtvalue.Text = ((Label)(gr.FindControl("lblValueRs"))).Text;
                ViewState["LineofActivityId"] = ((Label)(gr.FindControl("lblLineofActivityId"))).Text;
                btnInstalledcap.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                IndustryLineofActivities objNewInds = new IndustryLineofActivities();
                objNewInds.slno = ((Label)(gr.FindControl("lblLineofActivityId"))).Text;
                objNewInds.Created_by = ObjLoginNewvo.uid;
                objNewInds.LOAType = "New";
                objNewInds.TransType = "DLT";
                objNewInds.IncentiveId = Session["IncentiveID"].ToString();

                string Validstatus = ObjCAFClass.InsertLineOfActivityDtlsTAB2(objNewInds);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnInstalledcap.Text = "Add New";
                    ViewState["LineofActivityId"] = "0";
                    BindLineofActivityDtls(Session["IncentiveID"].ToString(), "New");
                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }

        protected void GvLineOfactivityExpnsionDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                txtLOActivityExpan.Text = ((Label)(gr.FindControl("lblLineofActivity"))).Text;
                txtinstalledccapExpan.Text = ((Label)(gr.FindControl("lblInstalledCapacity"))).Text;
                ddlquantityinExpan.SelectedValue = ((Label)(gr.FindControl("lblLineUnitID"))).Text;
                txtvalueExpanPerUnit.Text = ((Label)(gr.FindControl("lblExpValuePerUnitRs"))).Text;
                txtvalueExpan.Text = ((Label)(gr.FindControl("lblValueRs"))).Text;
                ViewState["ExpLineofActivityId"] = ((Label)(gr.FindControl("lblLineofActivityId"))).Text;
                btnInstalledcapExpan.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                IndustryLineofActivities objNewInds = new IndustryLineofActivities();
                objNewInds.slno = ((Label)(gr.FindControl("lblLineofActivityId"))).Text;
                objNewInds.Created_by = ObjLoginNewvo.uid;
                objNewInds.LOAType = "Exp";
                objNewInds.TransType = "DLT";
                objNewInds.IncentiveId = Session["IncentiveID"].ToString();

                string Validstatus = ObjCAFClass.InsertLineOfActivityDtlsTAB2(objNewInds);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnInstalledcapExpan.Text = "Add New";
                    ViewState["ExpLineofActivityId"] = "0";
                    BindLineofActivityDtls(Session["IncentiveID"].ToString(), "Exp");
                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }
        protected void btnPrevious2_Click(object sender, EventArgs e)
        {
            AnchTab1_Click(sender, e);
        }

        protected void btnSaveDirectorDtls_Click(object sender, EventArgs e)
        {

            try
            {
                if (ViewState["Director_Partner_ID"] == null)
                {
                    ViewState["Director_Partner_ID"] = "0";
                }

                string errormsg = ValidateLoA("3");
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

                    IndustryPartnerDtls VosPartner = new IndustryPartnerDtls();

                    VosPartner.Slno = ViewState["Director_Partner_ID"].ToString();
                    VosPartner.Name = txtNameofDirector.Text.Trim().TrimStart();
                    VosPartner.Designation = ddlDirectorDesignation.SelectedValue;
                    VosPartner.EducationalQual = ddlEducationalQualificationPatners.SelectedValue;
                    VosPartner.EducationalQualOther = txtEducationalQual.Text.Trim().TrimStart();
                    VosPartner.YearsOfExpinTexttileDirector = txtYearsOfExpinTexttileDirector.Text.Trim().TrimStart();
                    VosPartner.Share = txtshare.Text.Trim().TrimStart();
                    VosPartner.PanNO = txtPanNoDirector.Text.Trim().TrimStart();
                    VosPartner.MobileNo = txtunitmobilenoDirector.Text.Trim().TrimStart();
                    VosPartner.Email = txtunitemailidDirector.Text.Trim().TrimStart();
                    VosPartner.TransType = "INS";
                    VosPartner.IncentiveId = Session["IncentiveID"].ToString();
                    VosPartner.Created_by = ObjLoginNewvo.uid;

                    string Validstatus = ObjCAFClass.InsertDirectorDetailsTAB2(VosPartner);
                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        btnSaveDirectorDtls.Text = "Add New";
                        ViewState["Director_Partner_ID"] = "0";

                        txtNameofDirector.Text = "";
                        ddlDirectorDesignation.SelectedValue = "0";
                        ddlEducationalQualificationPatners.SelectedValue = "0";
                        txtEducationalQual.Text = "";
                        txtYearsOfExpinTexttileDirector.Text = "";
                        txtshare.Text = "";
                        txtPanNoDirector.Text = "";
                        txtunitmobilenoDirector.Text = "";
                        txtunitemailidDirector.Text = "";
                        BindDirectorDtls(Session["IncentiveID"].ToString());
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

        protected void GvPartnerDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                txtNameofDirector.Text = ((Label)(gr.FindControl("lblDirectorName"))).Text;
                ddlDirectorDesignation.SelectedValue = ((Label)(gr.FindControl("lblDesignationid"))).Text;

                string EducationalQual = ((Label)(gr.FindControl("lblQualificationID"))).Text;
                if (ddlEducationalQualificationPatners.Items.FindByValue(EducationalQual) != null)
                {
                    ddlEducationalQualificationPatners.SelectedValue = EducationalQual;
                    ddlEducationalQualificationPatners_SelectedIndexChanged(this, EventArgs.Empty);
                    if (EducationalQual == "22")
                    {
                        txtEducationalQual.Text = ((Label)(gr.FindControl("lblQualification"))).Text;
                    }
                }

                txtYearsOfExpinTexttileDirector.Text = ((Label)(gr.FindControl("lblYearsofExperience"))).Text;
                txtshare.Text = ((Label)(gr.FindControl("lblShare"))).Text;
                txtPanNoDirector.Text = ((Label)(gr.FindControl("lblPANNumber"))).Text;
                txtunitmobilenoDirector.Text = ((Label)(gr.FindControl("lblMobileNumber"))).Text;
                txtunitemailidDirector.Text = ((Label)(gr.FindControl("lblEmailId"))).Text;

                ViewState["Director_Partner_ID"] = ((Label)(gr.FindControl("lblDirectorPartnerID"))).Text;
                btnSaveDirectorDtls.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                IndustryPartnerDtls VosPartner = new IndustryPartnerDtls();

                VosPartner.Slno = ((Label)(gr.FindControl("lblDirectorPartnerID"))).Text;
                VosPartner.Created_by = ObjLoginNewvo.uid;
                VosPartner.TransType = "DLT";
                VosPartner.IncentiveId = Session["IncentiveID"].ToString();

                string Validstatus = ObjCAFClass.InsertDirectorDetailsTAB2(VosPartner);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnSaveDirectorDtls.Text = "Add New";
                    ViewState["Director_Partner_ID"] = "0";
                    BindDirectorDtls(Session["IncentiveID"].ToString());
                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }

        protected void btnNext2_Click(object sender, EventArgs e)
        {
            try
            {
                
                string errormsg = ValidateControls("2");
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    if (ddlIndustryStatus.SelectedValue == "1")
                    {
                        GetFinancialYears(GetFromatedDateDDMMYYYY(txtDateofCommencement.Text));
                    }
                    else
                    {
                        GetFinancialYears(GetFromatedDateDDMMYYYY(txtDateofCommencementExp.Text));
                    }
                    AssignValuestoVosFromcontrols("2");
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

        protected void txtlandexisting_TextChanged(object sender, EventArgs e)
        {
            CalculatationEnterprise1("1");
            GetApprovedProjectPercentage("1");
            GetApprovedProjectPercentage("4");
        }
        protected void txtlandcapacity_TextChanged(object sender, EventArgs e)
        {
            CalculatationEnterprise1("2");
            GetApprovedProjectPercentage("1");
            GetApprovedProjectPercentage("4");
        }
        protected void txtlandpercentage_TextChanged(object sender, EventArgs e)
        {
            //CalculatationEnterprise1("3");
            //GetApprovedProjectPercentage("4");
        }

        protected void txtbuildingexisting_TextChanged(object sender, EventArgs e)
        {
            CalculatationEnterprise1("1");
            GetApprovedProjectPercentage("2");
            GetApprovedProjectPercentage("4");
        }
        protected void txtbuildingcapacity_TextChanged(object sender, EventArgs e)
        {
            CalculatationEnterprise1("2");
            GetApprovedProjectPercentage("2");
            GetApprovedProjectPercentage("4");
        }
        protected void txtbuildingpercentage_TextChanged(object sender, EventArgs e)
        {
            //CalculatationEnterprise1("3");
            //GetApprovedProjectPercentage("4");
        }
        protected void txtplantexisting_TextChanged(object sender, EventArgs e)
        {

            CalculatationEnterprise1("1");
            GetApprovedProjectPercentage("3");
            GetApprovedProjectPercentage("4");
        }
        protected void txtplantcapacity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // txtplantexisting_TextChanged(sender, e);
                CalculatationEnterprise1("2");
                GetApprovedProjectPercentage("3");
                GetApprovedProjectPercentage("4");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void txtplantpercentage_TextChanged(object sender, EventArgs e)
        {
            //CalculatationEnterprise1("3");
            //GetApprovedProjectPercentage("4");
        }

        protected void txtnewothers_TextChanged(object sender, EventArgs e)
        {
            CalculatationEnterprise1("1");
        }

        protected void txtexistother_TextChanged(object sender, EventArgs e)
        {
            CalculatationEnterprise1("2");
        }

        protected void txtotherpersangage_TextChanged(object sender, EventArgs e)
        {
            CalculatationEnterprise1("3");
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

                decimal IpassLand = 0, IpassBuilding = 0, IpassPlantMachine = 0;
                decimal IpassLandExp = 0, IpassBuildingExp = 0, IpassPlantMachineExp = 0;
                decimal IpassTotalValue = 0, IpassTotalValueExp = 0;

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

                    if (txtIpassLand.Text != null && txtIpassLand.Text != "" && txtIpassLand.Text != string.Empty)
                    {
                        IpassLand = Convert.ToDecimal(txtIpassLand.Text.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        IpassLand = 0;
                    }
                    if (txtIpassBuilding.Text != null && txtIpassBuilding.Text != "" && txtIpassBuilding.Text != string.Empty)
                    {
                        IpassBuilding = Convert.ToDecimal(txtIpassBuilding.Text.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        IpassBuilding = 0;
                    }

                    if (txtIpassPlantMachine.Text != null && txtIpassPlantMachine.Text != "" && txtIpassPlantMachine.Text != string.Empty)
                    {
                        IpassPlantMachine = Convert.ToDecimal(txtIpassPlantMachine.Text.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        IpassPlantMachine = 0;
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
                    IpassTotalValue = (IpassLand + IpassBuilding + IpassPlantMachine);
                    lbltotIpass.Text = IpassTotalValue.ToString();
                    if (IpassTotalValue == 0)
                    {
                        lbltotIpass.Text = "";
                    }
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
                    if (txtIpassLandExp.Text != null && txtIpassLandExp.Text != "" && txtIpassLandExp.Text != string.Empty)
                    {
                        IpassLandExp = Convert.ToDecimal(txtIpassLandExp.Text.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        IpassLandExp = 0;
                    }
                    if (txtIpassBuildingExp.Text != null && txtIpassBuildingExp.Text != "" && txtIpassBuildingExp.Text != string.Empty)
                    {
                        IpassBuildingExp = Convert.ToDecimal(txtIpassBuildingExp.Text.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        IpassBuildingExp = 0;
                    }

                    if (txtIpassPlantMachineExp.Text != null && txtIpassPlantMachineExp.Text != "" && txtIpassPlantMachineExp.Text != string.Empty)
                    {
                        IpassPlantMachineExp = Convert.ToDecimal(txtIpassPlantMachineExp.Text.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        IpassPlantMachineExp = 0;
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
                    IpassTotalValueExp = (IpassLandExp + IpassBuildingExp + IpassPlantMachineExp);
                    lbltotIpassExp.Text = IpassTotalValueExp.ToString();
                    if (IpassTotalValueExp == 0)
                    {
                        lbltotIpassExp.Text = "";
                    }
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

                TTAPCategory();
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }
        }

        protected void txtstaffMale_TextChanged(object sender, EventArgs e)
        {
            CalculatationofEmployemnt("1");
        }
        protected void txtfemale_TextChanged(object sender, EventArgs e)
        {
            CalculatationofEmployemnt("2");
        }
        protected void txtstaffMaleInDirect_TextChanged(object sender, EventArgs e)
        {
            CalculatationofEmployemnt("3");
        }

        protected void txtfemaleInDirect_TextChanged(object sender, EventArgs e)
        {
            CalculatationofEmployemnt("4");
        }
        public void CalculatationofEmployemnt(string Step)
        {
            try
            {
                decimal ManagementStaffDirectMale = 0, SupervisoryDirectMale = 0, SkilledworkersDirectMale = 0, SemiskilledworkersDirectMale = 0, EmpDirectLocalMaleOther = 0;
                decimal ManagementStaffDirectMaleNonLocal = 0, SupervisoryDirectMaleNonLocal = 0, SkilledworkersDirectMaleNonLocal = 0, SemiskilledworkersDirectMaleNonLocal = 0, EmpDirectNonLocalMaleOther = 0;
                //decimal ManagementStaffDirectMaleST = 0, SupervisoryDirectMaleST = 0, SkilledworkersDirectMaleST = 0, SemiskilledworkersDirectMaleST = 0;
                //decimal ManagementStaffDirectMaleGEN = 0, SupervisoryDirectMaleGEN = 0, SkilledworkersDirectMaleGEN = 0, SemiskilledworkersDirectMaleGEN = 0;

                decimal ManagementStaffDirectFeMale = 0, SupervisoryDirectFeMale = 0, SkilledworkersDirectFeMale = 0, SemiskilledworkersDirectFeMale = 0, EmpDirectLocalFemaleOther = 0;
                decimal ManagementStaffDirectFeMaleNonLocal = 0, SupervisoryDirectFeMaleNonLocal = 0, SkilledworkersDirectFeMaleNonLocal = 0, SemiskilledworkersDirectFeMaleNonLocal = 0, EmpDirectNonLocalFemaleOther = 0;
                //decimal ManagementStaffDirectFeMaleST = 0, SupervisoryDirectFeMaleST = 0, SkilledworkersDirectFeMaleST = 0, SemiskilledworkersDirectFeMaleST = 0;
                //decimal ManagementStaffDirectFeMaleGEN = 0, SupervisoryDirectFeMaleGEN = 0, SkilledworkersDirectFeMaleGEN = 0, SemiskilledworkersDirectFeMaleGEN = 0;

                //decimal ManagementStaffInDirectMale = 0, SupervisoryInDirectMale = 0, SkilledworkersInDirectMale = 0, SemiskilledworkersInDirectMale = 0, EmpIndirectMaleOther = 0;
                //decimal ManagementStaffInDirectMaleST = 0, SupervisoryInDirectMaleST = 0, SkilledworkersInDirectMaleST = 0, SemiskilledworkersInDirectMaleST = 0;
                //decimal ManagementStaffInDirectMaleGEN = 0, SupervisoryInDirectMaleGEN = 0, SkilledworkersInDirectMaleGEN = 0, SemiskilledworkersInDirectMaleGEN = 0;

                //decimal ManagementStaffInDirectFeMale = 0, SupervisoryInDirectFeMale = 0, SkilledworkersInDirectFeMale = 0, SemiskilledworkersInDirectFeMale = 0, EmpIndirectFemaleOther = 0;
                //decimal ManagementStaffInDirectFeMaleST = 0, SupervisoryInDirectFeMaleST = 0, SkilledworkersInDirectFeMaleST = 0, SemiskilledworkersInDirectFeMaleST = 0;
                //decimal ManagementStaffInDirectFeMaleGEN = 0, SupervisoryInDirectFeMaleGEN = 0, SkilledworkersInDirectFeMaleGEN = 0, SemiskilledworkersInDirectFeMaleGEN = 0;

                decimal FinalTotal = 0;
                if (Step == "1")
                {
                    if (txtstaffMale.Text != "")
                    {
                        ManagementStaffDirectMale = Convert.ToDecimal(txtstaffMale.Text.Trim());
                    }
                    else
                    {
                        ManagementStaffDirectMale = 0;
                    }

                    if (txtsupermalecount.Text != "")
                    {
                        SupervisoryDirectMale = Convert.ToDecimal(txtsupermalecount.Text.Trim());
                    }
                    else
                    {
                        SupervisoryDirectMale = 0;
                    }

                    if (txtSkilledWorkersMale.Text != "")
                    {
                        SkilledworkersDirectMale = Convert.ToDecimal(txtSkilledWorkersMale.Text.Trim());
                    }
                    else
                    {
                        SkilledworkersDirectMale = 0;
                    }

                    if (txtSemiSkilledWorkersMale.Text != "")
                    {
                        SemiskilledworkersDirectMale = Convert.ToDecimal(txtSemiSkilledWorkersMale.Text.Trim());
                    }
                    else
                    {
                        SemiskilledworkersDirectMale = 0;
                    }

                    if (txtEmpDirectLocalMaleOther.Text != "")
                    {
                        EmpDirectLocalMaleOther = Convert.ToDecimal(txtEmpDirectLocalMaleOther.Text.Trim());
                    }
                    else
                    {
                        EmpDirectLocalMaleOther = 0;
                    }

                    FinalTotal = ManagementStaffDirectMale + SupervisoryDirectMale + SkilledworkersDirectMale + SemiskilledworkersDirectMale + EmpDirectLocalMaleOther;
                    lblDirectMale.Text = FinalTotal.ToString();
                }
                else if (Step == "2")
                {
                    if (txtfemale.Text != "")
                    {
                        ManagementStaffDirectFeMale = Convert.ToDecimal(txtfemale.Text.Trim());
                    }
                    else
                    {
                        ManagementStaffDirectFeMale = 0;
                    }
                    if (txtsuperfemalecount.Text != "")
                    {
                        SupervisoryDirectFeMale = Convert.ToDecimal(txtsuperfemalecount.Text.Trim());
                    }
                    else
                    {
                        SupervisoryDirectFeMale = 0;
                    }
                    if (txtSkilledWorkersFemale.Text != "")
                    {
                        SkilledworkersDirectFeMale = Convert.ToDecimal(txtSkilledWorkersFemale.Text.Trim());
                    }
                    else
                    {
                        SkilledworkersDirectFeMale = 0;
                    }
                    if (txtSemiSkilledWorkersFemale.Text != "")
                    {
                        SemiskilledworkersDirectFeMale = Convert.ToDecimal(txtSemiSkilledWorkersFemale.Text.Trim());
                    }
                    else
                    {
                        SemiskilledworkersDirectFeMale = 0;
                    }

                    if (txtEmpDirectLocalFemaleOther.Text != "")
                    {
                        EmpDirectLocalFemaleOther = Convert.ToDecimal(txtEmpDirectLocalFemaleOther.Text.Trim());
                    }
                    else
                    {
                        EmpDirectLocalFemaleOther = 0;
                    }

                    FinalTotal = ManagementStaffDirectFeMale + SupervisoryDirectFeMale + SkilledworkersDirectFeMale + SemiskilledworkersDirectFeMale + EmpDirectLocalFemaleOther;
                    lblDirectFeMale.Text = FinalTotal.ToString();
                }
                //else if (Step == "3")
                //{
                //    if (txtstaffMaleInDirect.Text != "")
                //    {
                //        ManagementStaffInDirectMale = Convert.ToDecimal(txtstaffMaleInDirect.Text.Trim());
                //    }
                //    else
                //    {
                //        ManagementStaffInDirectMale = 0;
                //    }
                //    if (txtsupermalecountInDirect.Text != "")
                //    {
                //        SupervisoryInDirectMale = Convert.ToDecimal(txtsupermalecountInDirect.Text.Trim());
                //    }
                //    else
                //    {
                //        SupervisoryInDirectMale = 0;
                //    }
                //    if (txtSkilledWorkersMaleInDirect.Text != "")
                //    {
                //        SkilledworkersInDirectMale = Convert.ToDecimal(txtSkilledWorkersMaleInDirect.Text.Trim());
                //    }
                //    else
                //    {
                //        SkilledworkersInDirectMale = 0;
                //    }
                //    if (txtSemiSkilledWorkersMaleIndirect.Text != "")
                //    {
                //        SemiskilledworkersInDirectMale = Convert.ToDecimal(txtSemiSkilledWorkersMaleIndirect.Text.Trim());
                //    }
                //    else
                //    {
                //        SemiskilledworkersInDirectMale = 0;
                //    }

                //    if (txtEmpIndirectMaleOther.Text != "")
                //    {
                //        EmpIndirectMaleOther = Convert.ToDecimal(txtEmpIndirectMaleOther.Text.Trim());
                //    }
                //    else
                //    {
                //        EmpIndirectMaleOther = 0;
                //    }

                //    FinalTotal = ManagementStaffInDirectMale + SupervisoryInDirectMale + SkilledworkersInDirectMale + SemiskilledworkersInDirectMale + EmpIndirectMaleOther;
                //    lblInDirectMale.Text = FinalTotal.ToString();
                //}
                //else if (Step == "4")
                //{
                //    if (txtfemaleInDirect.Text != "")
                //    {
                //        ManagementStaffInDirectFeMale = Convert.ToDecimal(txtfemaleInDirect.Text.Trim());
                //    }
                //    else
                //    {
                //        ManagementStaffInDirectFeMale = 0;
                //    }
                //    if (txtsuperfemalecountInDirect.Text != "")
                //    {
                //        SupervisoryInDirectFeMale = Convert.ToDecimal(txtsuperfemalecountInDirect.Text.Trim());
                //    }
                //    else
                //    {
                //        SupervisoryInDirectFeMale = 0;
                //    }
                //    if (txtSkilledWorkersFemaleInDirect.Text != "")
                //    {
                //        SkilledworkersInDirectFeMale = Convert.ToDecimal(txtSkilledWorkersFemaleInDirect.Text.Trim());
                //    }
                //    else
                //    {
                //        SkilledworkersInDirectFeMale = 0;
                //    }
                //    if (txtSemiSkilledWorkersFemaleIndirect.Text != "")
                //    {
                //        SemiskilledworkersInDirectFeMale = Convert.ToDecimal(txtSemiSkilledWorkersFemaleIndirect.Text.Trim());
                //    }
                //    else
                //    {
                //        SemiskilledworkersInDirectFeMale = 0;
                //    }

                //    if (txtEmpIndirectFemaleOther.Text != "")
                //    {
                //        EmpIndirectFemaleOther = Convert.ToDecimal(txtEmpIndirectFemaleOther.Text.Trim());
                //    }
                //    else
                //    {
                //        EmpIndirectFemaleOther = 0;
                //    }
                //    FinalTotal = ManagementStaffInDirectFeMale + SupervisoryInDirectFeMale + SkilledworkersInDirectFeMale + SemiskilledworkersInDirectFeMale + EmpIndirectFemaleOther;
                //    lblInDirectFeMale.Text = FinalTotal.ToString();
                //}

                else if (Step == "5")
                {
                    if (txtstaffMaleNonLocal.Text != "")
                    {
                        ManagementStaffDirectMaleNonLocal = Convert.ToDecimal(txtstaffMaleNonLocal.Text.Trim());
                    }
                    else
                    {
                        ManagementStaffDirectMaleNonLocal = 0;
                    }
                    if (txtsupermalecountNonLocal.Text != "")
                    {
                        SupervisoryDirectMaleNonLocal = Convert.ToDecimal(txtsupermalecountNonLocal.Text.Trim());
                    }
                    else
                    {
                        SupervisoryDirectMaleNonLocal = 0;
                    }
                    if (txtSkilledWorkersMaleNonLocal.Text != "")
                    {
                        SkilledworkersDirectMaleNonLocal = Convert.ToDecimal(txtSkilledWorkersMaleNonLocal.Text.Trim());
                    }
                    else
                    {
                        SkilledworkersDirectMaleNonLocal = 0;
                    }
                    if (txtSemiSkilledWorkersMaleNonLocal.Text != "")
                    {
                        SemiskilledworkersDirectMaleNonLocal = Convert.ToDecimal(txtSemiSkilledWorkersMaleNonLocal.Text.Trim());
                    }
                    else
                    {
                        SemiskilledworkersDirectMaleNonLocal = 0;
                    }

                    if (txtEmpDirectNonLocalMaleOther.Text != "")
                    {
                        EmpDirectNonLocalMaleOther = Convert.ToDecimal(txtEmpDirectNonLocalMaleOther.Text.Trim());
                    }
                    else
                    {
                        EmpDirectNonLocalMaleOther = 0;
                    }

                    FinalTotal = ManagementStaffDirectMaleNonLocal + SupervisoryDirectMaleNonLocal + SkilledworkersDirectMaleNonLocal + SemiskilledworkersDirectMaleNonLocal + EmpDirectNonLocalMaleOther;
                    lblDirectMaleNonLocal.Text = FinalTotal.ToString();

                }
                else if (Step == "6")
                {
                    if (txtfemaleNonLocal.Text != "")
                    {
                        ManagementStaffDirectFeMaleNonLocal = Convert.ToDecimal(txtfemaleNonLocal.Text.Trim());
                    }
                    else
                    {
                        ManagementStaffDirectFeMaleNonLocal = 0;
                    }
                    if (txtsuperfemalecountNonLocal.Text != "")
                    {
                        SupervisoryDirectFeMaleNonLocal = Convert.ToDecimal(txtsuperfemalecountNonLocal.Text.Trim());
                    }
                    else
                    {
                        SupervisoryDirectFeMaleNonLocal = 0;
                    }
                    if (txtSkilledWorkersFemaleNonLocal.Text != "")
                    {
                        SkilledworkersDirectFeMaleNonLocal = Convert.ToDecimal(txtSkilledWorkersFemaleNonLocal.Text.Trim());
                    }
                    else
                    {
                        SkilledworkersDirectFeMaleNonLocal = 0;
                    }

                    if (txtSemiSkilledWorkersFemaleNonLocal.Text != "")
                    {
                        SemiskilledworkersDirectFeMaleNonLocal = Convert.ToDecimal(txtSemiSkilledWorkersFemaleNonLocal.Text.Trim());
                    }
                    else
                    {
                        SemiskilledworkersDirectFeMaleNonLocal = 0;
                    }

                    if (txtEmpDirectNonLocalFemaleOther.Text != "")
                    {
                        EmpDirectNonLocalFemaleOther = Convert.ToDecimal(txtEmpDirectNonLocalFemaleOther.Text.Trim());
                    }
                    else
                    {
                        EmpDirectNonLocalFemaleOther = 0;
                    }

                    FinalTotal = ManagementStaffDirectFeMaleNonLocal + SupervisoryDirectFeMaleNonLocal + SkilledworkersDirectFeMaleNonLocal + SemiskilledworkersDirectFeMaleNonLocal + EmpDirectNonLocalFemaleOther;
                    lblDirectFeMaleNonLocal.Text = FinalTotal.ToString();
                }

                TTAPCategory();

            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }
        }

        protected void btnPrevious3_Click(object sender, EventArgs e)
        {
            AnchTab2_Click(sender, e);
        }

        protected void btnNext3_Click(object sender, EventArgs e)
        {
            try
            {
                string errormsg = ValidateControls("3");
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    AssignValuestoVosFromcontrols("3");
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

        protected void btnTermloanAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["TermLoanId"] == null)
                {
                    ViewState["TermLoanId"] = "0";
                }

                string errormsg = ValidateLoA("4");
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

                    IndustryTermLoanDtls VoTermLoandtls = new IndustryTermLoanDtls();

                    VoTermLoandtls.Created_by = ObjLoginNewvo.uid;
                    VoTermLoandtls.TermLoanId = ViewState["TermLoanId"].ToString();
                    VoTermLoandtls.AvailedTermLoan = ddlTermLoanNo.SelectedValue;

                    string[] Ld6 = null;
                    string ConvertedDt56 = "";
                    if (txtTermLoanDate.Text != "")
                    {
                        Ld6 = txtTermLoanDate.Text.Split('/');
                        ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();
                        VoTermLoandtls.TermLoanApplDate = ConvertedDt56;
                    }
                    else
                    {
                        VoTermLoandtls.TermLoanApplDate = null;
                    }

                    VoTermLoandtls.InstitutionName = ddltermloanbank.SelectedValue;
                    VoTermLoandtls.BankName = txtInstitution.Text.ToString();
                    VoTermLoandtls.TermLoanSancRefNo = txtsactionedloanreferenceNo.Text.Trim().TrimStart();

                    Ld6 = null;
                    ConvertedDt56 = "";
                    if (txtTeamloanSanctionedDate.Text != "")
                    {
                        Ld6 = txtTeamloanSanctionedDate.Text.Split('/');
                        ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();
                        VoTermLoandtls.TermloanSandate = ConvertedDt56;
                    }
                    else
                    {
                        VoTermLoandtls.TermloanSandate = null;
                    }

                    Ld6 = null;
                    ConvertedDt56 = "";
                    if (txtTermLoanReleasedDatea.Text != "")
                    {
                        Ld6 = txtTermLoanReleasedDatea.Text.Split('/');
                        ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();
                        VoTermLoandtls.TermLoanReleaseddate = ConvertedDt56;
                    }
                    else
                    {
                        VoTermLoandtls.TermLoanReleaseddate = null;
                    }

                    VoTermLoandtls.Installments = GetDecimalNullValue(txtInstallments.Text.Trim().TrimStart());
                    VoTermLoandtls.RateOfInterest = GetDecimalNullValue(txttermloanRateOfInterest.Text.Trim().TrimStart());
                    VoTermLoandtls.SanctionedAmount = GetDecimalNullValue(txtSanctionedAmount.Text.Trim().TrimStart());
                    VoTermLoandtls.TermLoanPeriodFromDate = GetFromatedDateDDMMYYYY(txtTermLoanPeriodFromDate.Text.Trim().TrimStart());
                    VoTermLoandtls.TermLoanPeriodToDate = GetFromatedDateDDMMYYYY(txtTermLoanPeriodToDate.Text.Trim().TrimStart());

                    VoTermLoandtls.TransType = "INS";
                    VoTermLoandtls.IncentiveId = Session["IncentiveID"].ToString();

                    string Validstatus = ObjCAFClass.InsertTearmLoanDtlsTAB3(VoTermLoandtls);
                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        btnTermloanAdd.Text = "Add New";
                        ViewState["TermLoanId"] = "0";
                        ddlTermLoanNo.SelectedValue = "0";
                        txtTermLoanDate.Text = "";
                        ddltermloanbank.SelectedValue = "0";
                        txtInstitution.Text = "";
                        txtInstitution.Visible = false;
                        txtsactionedloanreferenceNo.Text = "";
                        txtTeamloanSanctionedDate.Text = "";
                        txtTermLoanReleasedDatea.Text = "";
                        txttermloanRateOfInterest.Text = "";
                        txtSanctionedAmount.Text = "";
                        txtInstallments.Text = "";
                        txtTermLoanPeriodFromDate.Text = "";
                        txtTermLoanPeriodToDate.Text = "";

                        BindTearmLoanDtls(Session["IncentiveID"].ToString());
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

        protected void btnTermLoanClear_Click(object sender, EventArgs e)
        {

        }

        protected void GVTermLoandtls_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {

                ddlTermLoanNo.SelectedValue = ((Label)(gr.FindControl("lblAvailedTermLoan"))).Text;
                txtTermLoanDate.Text = ((Label)(gr.FindControl("lblTermLoanApplDate"))).Text;
                ddltermloanbank.SelectedValue = ((Label)(gr.FindControl("lblInstitutionNameid"))).Text;
                if (((Label)(gr.FindControl("lblInstitutionNameid"))).Text == "999")
                {
                    txtInstitution.Text = ((Label)(gr.FindControl("lblInstitutionName"))).Text;
                    txtInstitution.Visible = true;
                }
                txtsactionedloanreferenceNo.Text = ((Label)(gr.FindControl("lblTermLoanSancRefNo"))).Text;
                txtTeamloanSanctionedDate.Text = ((Label)(gr.FindControl("lblTermloanSandate"))).Text;
                txtTermLoanReleasedDatea.Text = ((Label)(gr.FindControl("lblTermLoanReleaseddate"))).Text;

                txtInstallments.Text = ((Label)(gr.FindControl("lblTermLoanInstallments"))).Text;

                txttermloanRateOfInterest.Text = ((Label)(gr.FindControl("lblRateOfInterest"))).Text;
                txtSanctionedAmount.Text = ((Label)(gr.FindControl("lblSanctionedAmount"))).Text;

                txtTermLoanPeriodFromDate.Text = ((Label)(gr.FindControl("lblTermLoanPeriodFromDate"))).Text;
                txtTermLoanPeriodToDate.Text = ((Label)(gr.FindControl("lblTermLoanPeriodToDate"))).Text;

                ViewState["TermLoanId"] = ((Label)(gr.FindControl("lblTermLoanId"))).Text;
                btnTermloanAdd.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                IndustryTermLoanDtls VoTermLoandtls = new IndustryTermLoanDtls();

                VoTermLoandtls.TermLoanId = ((Label)(gr.FindControl("lblTermLoanId"))).Text;
                VoTermLoandtls.Created_by = ObjLoginNewvo.uid;
                VoTermLoandtls.TransType = "DLT";
                VoTermLoandtls.IncentiveId = Session["IncentiveID"].ToString();

                string Validstatus = ObjCAFClass.InsertTearmLoanDtlsTAB3(VoTermLoandtls);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnTermloanAdd.Text = "Add New";
                    ViewState["TermLoanId"] = "0";
                    BindTearmLoanDtls(Session["IncentiveID"].ToString());
                    lblmsg.Text = "Deleted Successfully";

                    ddlTermLoanNo.SelectedValue = "0";
                    txtTermLoanDate.Text = "";
                    ddltermloanbank.SelectedValue = "0";
                    txtsactionedloanreferenceNo.Text = "";
                    txtTeamloanSanctionedDate.Text = "";
                    txtTermLoanReleasedDatea.Text = "";

                    txtInstallments.Text = "";
                    txtTermLoanPeriodFromDate.Text = "";
                    txtTermLoanPeriodToDate.Text = "";

                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }

        protected void btnNext4_Click(object sender, EventArgs e)
        {
            try
            {
                string errormsg = ValidateControls("4");
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    AssignValuestoVosFromcontrols("4");
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

        protected void btnPrevious4_Click(object sender, EventArgs e)
        {
            AnchTab3_Click(sender, e);
        }

        protected void btnPrevious5_Click(object sender, EventArgs e)
        {
            AnchTab4_Click(sender, e);
        }

        protected void btnNext5_Click(object sender, EventArgs e)
        {
            try
            {
                string errormsg = ValidateControls("5");
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    AssignValuestoVosFromcontrols("5");
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

        // Plant & mahinary Details

        protected void RegisterPostBackControl()
        {
            foreach (GridViewRow row in grdPandM.Rows)
            {
                Button lnkFull = row.FindControl("btnDelete") as Button;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull);
            }
        }

        public void BindEligibility()
        {
            DataSet dsEligibility = new DataSet();

            dsEligibility = ObjCAFClass.getEligibilityList();
            if (dsEligibility.Tables.Count > 0)
            {
                if (dsEligibility.Tables[0].Rows.Count > 0)
                {
                    ddlEligibility.DataSource = dsEligibility;
                    ddlEligibility.DataTextField = "EligibilityType";
                    ddlEligibility.DataValueField = "EligibilityId";
                    ddlEligibility.DataBind();
                    ddlEligibility.Items.Insert(0, new ListItem("--Select--", "0"));

                }
            }
        }
        public void BindForeignCurrency()
        {
            ddlForeignCurrency.Items.Clear();
            DataSet dsForeignCurrency = new DataSet();
            dsForeignCurrency = ObjCAFClass.getCurrencyList();
            if (dsForeignCurrency.Tables.Count > 0)
            {
                if (dsForeignCurrency != null && dsForeignCurrency.Tables.Count > 0 && dsForeignCurrency.Tables[0].Rows.Count > 0)
                {
                    ddlForeignCurrency.DataSource = dsForeignCurrency;
                    ddlForeignCurrency.DataTextField = "ForeignCurrency";
                    ddlForeignCurrency.DataValueField = "ForeignCurrencyID";
                    ddlForeignCurrency.DataBind();
                }
            }
            AddSelect(ddlForeignCurrency);
        }

        public void BindTechnicalTexttile()
        {
            ddlTechnicalNatureOfIndustry.Items.Clear();
            DataSet dsTechnicalTexttile = new DataSet();
            dsTechnicalTexttile = ObjCAFClass.getTechnicalTextileList();
            if (dsTechnicalTexttile.Tables.Count > 0)
            {
                if (dsTechnicalTexttile != null && dsTechnicalTexttile.Tables.Count > 0 && dsTechnicalTexttile.Tables[0].Rows.Count > 0)
                {
                    ddlTechnicalNatureOfIndustry.DataSource = dsTechnicalTexttile;
                    ddlTechnicalNatureOfIndustry.DataTextField = "TechnicalTextile";
                    ddlTechnicalNatureOfIndustry.DataValueField = "TechnicalTextileID";
                    ddlTechnicalNatureOfIndustry.DataBind();
                }
            }
            AddSelect(ddlTechnicalNatureOfIndustry);
        }
        protected void btnPandMAdd_Click(object sender, EventArgs e)
        {
            try
            {
                txtCostofMachine.Text = hdnMachineCostN.Value.TrimStart().TrimEnd().Trim();
                decimal costsum = 0;
                decimal Secondhand = 0;
                string errormsg = ValidatePlantMachinaryControls();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    decimal PlantMachValexisting = 0;
                    decimal PlantMachValexpansion = 0;
                    decimal PlantMachValTotal = 0;
                    decimal PlantMachValTotal25per = 0;

                    if (txtplantexisting.Text != null && txtplantexisting.Text != "" && txtplantexisting.Text != string.Empty)
                    {
                        PlantMachValexisting = Convert.ToDecimal(txtplantexisting.Text.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        PlantMachValexisting = 0;
                    }
                    if (txtplantcapacity.Text != null && txtplantcapacity.Text != "" && txtplantcapacity.Text != string.Empty)
                    {
                        PlantMachValexpansion = Convert.ToDecimal(txtplantcapacity.Text.Trim());  // expansion Plant Mach value   
                    }
                    else
                    {
                        PlantMachValexpansion = 0;
                    }
                    if (ddlIndustryStatus.SelectedValue == "1")
                    {
                        PlantMachValTotal = PlantMachValexisting;
                    }
                    else
                    {
                        PlantMachValTotal = PlantMachValexpansion;
                    }


                    PlantMachValTotal25per = Convert.ToDecimal(PlantMachValTotal * Convert.ToDecimal(0.25));


                    for (int i = 0; i < grdPandM.Rows.Count; i++)
                    {
                        Label lblMachineCost = grdPandM.Rows[i].FindControl("lblMachineCost") as Label;
                        Label lblInstalledMachineryText = grdPandM.Rows[i].FindControl("lblInstalledMachineryText") as Label;
                        Label lblPMId = grdPandM.Rows[i].FindControl("lblPMId") as Label;
                        string EditPMId = "";
                        if (ViewState["PMID"] != null)
                        {
                            EditPMId = ViewState["PMID"].ToString();
                        }
                        if (lblPMId.Text != EditPMId)
                        {
                            if (lblMachineCost.Text.Trim().TrimStart() != "")
                            {
                                costsum = costsum + Convert.ToDecimal(lblMachineCost.Text.Trim().TrimStart());
                            }
                            if (lblInstalledMachineryText.Text.Trim().TrimStart().ToUpper() != "NEW")
                            {
                                Secondhand = Secondhand + Convert.ToDecimal(lblMachineCost.Text.Trim().TrimStart());
                            }
                        }
                    }

                    if (txtCostofMachine.Text != "" && RbtnInstalledMachinery.SelectedValue == "2")
                    {
                        Secondhand = Secondhand + Convert.ToDecimal(txtCostofMachine.Text);
                    }

                    if (txtCostofMachine.Text != "")
                    {
                        costsum = costsum + Convert.ToDecimal(txtCostofMachine.Text);
                    }

                    //if (Session["MachineCostSum"] != null)
                    //{
                    //    costsum = Convert.ToDecimal(txtCostofMachine.Text) + Convert.ToDecimal(Session["MachineCostSum"].ToString());
                    //}
                    //else
                    //{
                    //    costsum = Convert.ToDecimal(txtCostofMachine.Text);
                    //}
                    if (Secondhand > PlantMachValTotal25per)
                    {
                        errormsg = "Cost of Second hand Machinery Should not Exceed 25% of the Total Cost of Plant & Machinery";
                        string message = "alert('" + errormsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                    else if (costsum > Convert.ToDecimal(PlantMachValTotal))
                    {
                        errormsg = "Machinary Cost Should Not Exceed the Total Cost of Plant & Machinery";
                        string message = "alert('" + errormsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        return;
                    }
                    else
                    {
                        PlantandMachinery pm = new PlantandMachinery();
                        if (ViewState["PMID"] != null)
                            pm.PMId = Convert.ToInt32(ViewState["PMID"].ToString());
                        else
                            pm.PMId = 0;
                        pm.IncentiveID = Convert.ToInt32(Session["IncentiveID"].ToString());
                        pm.MachineName = txtMachineName.Text;
                        pm.VendorName = txtVendorName.Text;
                        pm.TypeofMachineId = Convert.ToInt32(rdlMachineType.SelectedItem.Value);
                        pm.InstalledMachinery = RbtnInstalledMachinery.SelectedValue;
                        if (pm.InstalledMachinery == "1")
                        {
                            pm.InstalledMachinerytype = rbtnInstalledMachinerytype.SelectedValue;
                        }
                        pm.ManufacturerName = txtManufacturerName.Text;
                        pm.InvoiceNo = txtInvoiceNo.Text;
                        pm.InvoiceDate = GetFromatedDateDDMMYYYY(txtInvoiceDate.Text);
                        pm.MachineLandingDate = GetFromatedDateDDMMYYYY(txtMachineLoadingDate.Text);
                        pm.VaivleNo = txtVaivleNo.Text;
                        pm.VaivleDate = GetFromatedDateDDMMYYYY(txtVaivleDate.Text);

                        if (pm.TypeofMachineId == 1)
                        {
                            pm.MachinaryParts = RdlMachinaryParts.SelectedValue;
                            pm.CustomCountry = (txtCustomCountryName.Text != "") ? txtCustomCountryName.Text.Trim().TrimStart() : null;
                            pm.CustomPaid = (txtCustomPaid.Text != "") ? Convert.ToDecimal(txtCustomPaid.Text) : 0;
                            pm.Importduty = (txtImportduty.Text != "") ? Convert.ToDecimal(txtImportduty.Text) : 0;
                            pm.portcharges = (txtportcharges.Text != "") ? Convert.ToDecimal(txtportcharges.Text) : 0;
                            pm.statutorytaxes = (txtstatutorytaxesetc.Text != "") ? Convert.ToDecimal(txtstatutorytaxesetc.Text) : 0;
                            pm.ForeignMachineCost = Convert.ToDecimal(GetDecimalNullValue(txtCostoftheMachineforeign.Text.Trim().TrimStart()));
                            pm.ForeignCurrency = ddlForeignCurrency.SelectedValue;
                        }

                        pm.IntiationDate = GetFromatedDateDDMMYYYY(txtInitiationDate.Text);
                        pm.MachineCost = Convert.ToDecimal(txtCostofMachine.Text);
                        pm.EligilbiltyId = Convert.ToInt32(ddlEligibility.SelectedItem.Value);

                        pm.ClassificationMachinery = ddlpmtype.SelectedItem.Value;

                        pm.ActualMachineCost = Convert.ToDecimal(txtActMachineCost.Text);
                        pm.FreightCharges = Convert.ToDecimal(txtFreightCharges.Text);
                        pm.TransportCharges= Convert.ToDecimal(txtTransportCharges.Text);
                        pm.Cgst = Convert.ToDecimal(txtcgst.Text);
                        pm.Sgst = Convert.ToDecimal(txtsgst.Text);
                        pm.Igst = Convert.ToDecimal(txtigst.Text);
                        pm.Remarks = txtReqRemarks.Text.ToString();

                        HyperLink hyperLinkNew1 = new HyperLink();
                        if (fuInvoiceBills.HasFile)
                        {
                            string OutPut = objClsFileUpload.IncentiveFileUploadingPM("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuInvoiceBills, hyperLinkNew1, "CAFUploads", Session["IncentiveID"].ToString(), "8", "49", Session["uid"].ToString(), "USER");
                            pm.AttachmentId2 = OutPut;
                        }
                        string DbErrorMsg = "";
                        int result = ObjCAFClass.InsertPlantandMachinery(pm, out DbErrorMsg);
                        if (result > 0 && DbErrorMsg == "")
                        {
                            //Add to Grid Method
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Updated Successfully');", true);
                            hdnPMCostEdit.Value = "N";
                            BindPandMGrid(0, Convert.ToInt32(Session["IncentiveID"].ToString()));
                            BindPMForPaymentProofs(Convert.ToInt32(Session["IncentiveID"].ToString()), Convert.ToInt32(ddlIndustryStatus.SelectedValue), "1");
                            clearControls();
                            btnPandMAdd.Text = "Add New";
                        }
                        else
                        {
                            if (DbErrorMsg.Trim().TrimStart() != "")
                            {
                                string dbmessage = "alert('" + DbErrorMsg + "')";
                                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", dbmessage, true);
                                return;
                            }
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
        public string CheckFuturedate(string SelectedDate, string InputFeild)
        {
            string ErrorMsg = "";
            DateTime Todate = Convert.ToDateTime(SelectedDate);
            DateTime fromdate = DateTime.Now;
            if (Todate > fromdate)
            {
                ErrorMsg = "Date of " + InputFeild + " cannot be Future Date\\n";
                // slno = slno + 1;
            }

            return ErrorMsg;
        }
        public string ValidatePlantMachinaryControls()
        {
            string InvoiceDate = "";
            string MachineLoadingDate = "";
            string WaybillDate = "";
            string InitiationDate = "";  // Nothing but Shipping Date

            int slno = 1;
            string ErrorMsg = "";
            if (hdnPMCostEdit.Value == "Y")
            {
                if (hdnMachineCostN.Value.TrimStart().TrimEnd().Trim() != txtPrvCostOftheMachine.Text.TrimStart().TrimEnd().Trim())
                {
                    ErrorMsg = ErrorMsg + slno + ". Machine Cost(Including GST,Frieght,Transport Charges) should be same as the Machine Prevoius cost\\n";
                    slno = slno + 1;
                    txtCostofMachine.Text = hdnMachineCostN.Value.TrimStart().TrimEnd().Trim();
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Calculate()", true);
                }
            }
            if (HiddenFieldEnterpriseCategory.Value.ToUpper().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Industry Category is not Defined as per the TTAP Policy. please check Incevest & Employment details\\n";
                slno = slno + 1;
            }
            if (txtMachineName.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Machine Name\\n";
                slno = slno + 1;
            }
            if (txtVendorName.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Vendor Name\\n";
                slno = slno + 1;
            }
            if (rdlMachineType.SelectedValue == "1")
            {
                if (txtCustomCountryName.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Country Name of Imported Machinary\\n";
                    slno = slno + 1;
                }
                if (txtCustomPaid.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter Custom duty/charges of Imported Machinary\\n";
                    slno = slno + 1;
                }

                if (txtCostoftheMachineforeign.Text.TrimStart().TrimEnd().Trim() == "")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Enter the Imported Machinary Cost (in foreign currency) \\n";
                    slno = slno + 1;
                }
                if (ddlForeignCurrency.SelectedValue == "0")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Select Soreign Currency \\n";
                    slno = slno + 1;
                }
            }
            if (txtManufacturerName.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Manufacturer Name\\n";
                slno = slno + 1;
            }
            if (txtInvoiceNo.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Invoice Number\\n";
                slno = slno + 1;
            }
            if (txtInvoiceDate.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Invoice Date Date\\n";
                slno = slno + 1;
            }
            else
            {
                InvoiceDate = GetFromatedDateDDMMYYYY(txtInvoiceDate.Text.TrimStart().TrimEnd().Trim());
                string Msg = CheckFuturedate(InvoiceDate, "Invoice");
                if (Msg != "")
                {
                    ErrorMsg = ErrorMsg + slno + ". " + Msg;
                }
            }

            if (txtInitiationDate.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Shipping Date\\n";
                slno = slno + 1;
            }
            else
            {
                InitiationDate = GetFromatedDateDDMMYYYY(txtInitiationDate.Text.TrimStart().TrimEnd().Trim());
                string Msg = CheckFuturedate(InitiationDate, "Shipping");
                if (Msg != "")
                {
                    ErrorMsg = ErrorMsg + slno + ". " + Msg;
                }
            }

            if (txtMachineLoadingDate.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Machine Landing Date\\n";
                slno = slno + 1;
            }
            else
            {
                MachineLoadingDate = GetFromatedDateDDMMYYYY(txtMachineLoadingDate.Text.TrimStart().TrimEnd().Trim());
                string Msg = CheckFuturedate(InitiationDate, "Machine Landing");
                if (Msg != "")
                {
                    ErrorMsg = ErrorMsg + slno + ". " + Msg;
                }
            }
            if (txtVaivleNo.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Way Bill Number\\n";
                slno = slno + 1;
            }
            if (txtVaivleDate.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Way Bill Date\\n";
                slno = slno + 1;
            }
            else
            {
                WaybillDate = GetFromatedDateDDMMYYYY(txtVaivleDate.Text.TrimStart().TrimEnd().Trim());
                string Msg = CheckFuturedate(WaybillDate, "Way Bill");
                if (Msg != "")
                {
                    ErrorMsg = ErrorMsg + slno + ". " + Msg;
                }
            }
            //chanikya
            if (txtActMachineCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Actual Cost of the Machine\\n";
                slno = slno + 1;
            }
            if (txtFreightCharges.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Freight Charges\\n";
                slno = slno + 1;
            }
            if (txtTransportCharges.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Transport Charges\\n";
                slno = slno + 1;
            }
            if (txtcgst.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter CGST Amount\\n";
                slno = slno + 1;
            }
            if (txtsgst.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter SGST Amount\\n";
                slno = slno + 1;
            }
            if (txtigst.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter IGST Amount\\n";
                slno = slno + 1;
            }

            if (txtCostofMachine.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Cost of the Machine\\n";
                slno = slno + 1;
            }
            if (ddlEligibility.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please select Eligibilty Type\\n";
                slno = slno + 1;
            }

            if (InvoiceDate != "" && InitiationDate != "")
            {
                if (Convert.ToDateTime(InvoiceDate) > Convert.ToDateTime(InitiationDate))
                {
                    ErrorMsg = ErrorMsg + slno + ". Machine Invoice Date Should Not be Greater than the Shipping Date \\n";
                    slno = slno + 1;
                }
            }

            //if (InitiationDate != "" && MachineLoadingDate != "")
            //{
            //    if (Convert.ToDateTime(InitiationDate) > Convert.ToDateTime(MachineLoadingDate))
            //    {
            //        ErrorMsg = ErrorMsg + slno + ". Shipping Date Should Not be Greater than the Machine Landing Date \\n";
            //        slno = slno + 1;
            //    }
            //}
            if (InitiationDate != "" && WaybillDate != "")
            {
                if (Convert.ToDateTime(InitiationDate) > Convert.ToDateTime(WaybillDate))
                {
                    ErrorMsg = ErrorMsg + slno + ". Shipping Date Should Not be Greater than the Way Bill Date \\n";
                    slno = slno + 1;
                }
            }
            if (MachineLoadingDate != "" && WaybillDate != "")
            {
                if (Convert.ToDateTime(MachineLoadingDate) < Convert.ToDateTime(WaybillDate))
                {
                    ErrorMsg = ErrorMsg + slno + ".Way Bill Date Should Not be Greater than the Machine Landing Date \\n";
                    slno = slno + 1;
                }
            }
            if (WaybillDate != "")
            {
                string ErrorMsg1 = ValidateDates("3");
                if (ErrorMsg1 != "")
                {
                    ErrorMsg = ErrorMsg + slno + ErrorMsg1;
                    slno = slno + 1;
                }
            }
            if (MachineLoadingDate != "")
            {
                string ErrorMsg1 = ValidateDates("2");
                if (ErrorMsg1 != "")
                {
                    ErrorMsg = ErrorMsg + slno + ErrorMsg1;
                    slno = slno + 1;
                }
            }

            if (!fuInvoiceBills.HasFile && hyInvoiceBills.NavigateUrl == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Upload Plant and Machinary invoices (Pdf Only)" + "\\n";
                slno = slno + 1;
            }
            else if (fuInvoiceBills.HasFile)
            {
                string Mimetype = objClsFileUpload.getmimetype(fuInvoiceBills);
                if (Mimetype != "application/pdf")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Upload Pdf Files Only" + "\\n";
                    slno = slno + 1;
                }
            }
            if (divPMunitType1.Visible && ddlpmtype.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select classification of machinery purchased" + "\\n";
                slno = slno + 1;
            }
            return ErrorMsg;
        }
        public void BindPandMGrid(int PMId, int IncentiveId)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = GetPandM(PMId, IncentiveId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdPandM.DataSource = ds.Tables[0];
                    grdPandM.DataBind();
                    Session["MachineCostSum"] = ds.Tables[1].Rows[0]["MachineCostSum"].ToString();

                    decimal TotalValueofNewMachinery = 0, Secondhandmachinery = 0;
                    decimal TotalValueofTextileProducts = 0, TotalValueofNonTextileProducts = 0, TotalValueofAllTextileProducts;

                    foreach (GridViewRow gvrow in grdPandM.Rows)
                    {
                        string Value = (gvrow.FindControl("lblMachineCost") as Label).Text;
                        string lblInstalledMachineryText = (gvrow.FindControl("lblInstalledMachineryText") as Label).Text;
                        if (lblInstalledMachineryText.ToUpper() == "NEW")
                        {
                            TotalValueofNewMachinery = TotalValueofNewMachinery + Convert.ToDecimal(GetDecimalNullValue(Value));
                        }
                        else
                        {
                            Secondhandmachinery = Secondhandmachinery + Convert.ToDecimal(GetDecimalNullValue(Value));
                        }

                        //

                        string lblClassificationofMachinery = (gvrow.FindControl("lblClassificationofMachinery") as Label).Text;

                        if (lblClassificationofMachinery.ToUpper().Contains("NON TEXTILE PRODUCTS"))
                        {
                            TotalValueofNonTextileProducts = TotalValueofNonTextileProducts + Convert.ToDecimal(GetDecimalNullValue(Value));
                        }
                        else if (lblClassificationofMachinery.ToUpper().Contains("TEXTILE PRODUCTS"))
                        {
                            TotalValueofTextileProducts = TotalValueofTextileProducts + Convert.ToDecimal(GetDecimalNullValue(Value));
                        }
                    }

                    lblTotalValueofNewMachinery.InnerHtml = TotalValueofNewMachinery.ToString();
                    lblSecondhandmachinery.InnerHtml = Secondhandmachinery.ToString();
                    lblTotalvaluemachinery.InnerHtml = (TotalValueofNewMachinery + Secondhandmachinery).ToString();

                    decimal PlantMachValexisting = 0;
                    decimal PlantMachValexpansion = 0;
                    decimal PlantMachValTotal = 0;
                    decimal PlantMachValTotal25per = 0;

                    if (txtplantexisting.Text != null && txtplantexisting.Text != "" && txtplantexisting.Text != string.Empty)
                    {
                        PlantMachValexisting = Convert.ToDecimal(txtplantexisting.Text.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        PlantMachValexisting = 0;
                    }

                    if (txtplantcapacity.Text != null && txtplantcapacity.Text != "" && txtplantcapacity.Text != string.Empty)
                    {
                        PlantMachValexpansion = Convert.ToDecimal(txtplantcapacity.Text.Trim());  // expansion Plant Mach value   
                    }
                    else
                    {
                        PlantMachValexpansion = 0;
                    }

                    PlantMachValTotal = PlantMachValexisting + PlantMachValexpansion;

                    if (PlantMachValTotal != 0 && Secondhandmachinery != 0)
                    {
                        PlantMachValTotal25per = Convert.ToDecimal(Convert.ToDecimal(Secondhandmachinery / PlantMachValTotal) * Convert.ToDecimal(100.00));
                        lblsechandmachineryPer.InnerText = PlantMachValTotal25per.ToString("#.##");
                    }

                    lblTotalValueofTextileProducts.InnerHtml = TotalValueofTextileProducts.ToString();
                    lblTotalValueofNonTextileProducts.InnerHtml = TotalValueofNonTextileProducts.ToString();

                    lblTotalValueofAllTextileProducts.InnerHtml = (TotalValueofTextileProducts + TotalValueofNonTextileProducts).ToString();
                    TotalValueofAllTextileProducts = (TotalValueofTextileProducts + TotalValueofNonTextileProducts);

                    if (TotalValueofTextileProducts > 0)
                    {
                        lblValueofTextileProductsPercentage.InnerHtml = (Convert.ToDecimal(Convert.ToDecimal(TotalValueofTextileProducts / TotalValueofAllTextileProducts) * Convert.ToDecimal(100.00))).ToString("#.##");
                    }
                    else
                    {
                        lblValueofTextileProductsPercentage.InnerHtml = "0";
                    }
                    if (TotalValueofNonTextileProducts > 0)
                    {
                        lblValueofNonTextileProductsPercentage.InnerHtml = (Convert.ToDecimal(Convert.ToDecimal(TotalValueofNonTextileProducts / TotalValueofAllTextileProducts) * Convert.ToDecimal(100.00))).ToString("#.##");
                    }
                    else
                    {
                        lblValueofNonTextileProductsPercentage.InnerHtml = "0";
                    }
                }
                else
                {
                    Session["MachineCostSum"] = null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetPandM(int PMId, int IncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@PMId",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = PMId;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_PLANTANDMACHINERY", pp);
            return Dsnew;
        }
        public DataSet GetPandMAlter(int PMId, int IncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@PMId",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = PMId;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_PLANTANDMACHINERY_ALTER", pp);
            return Dsnew;
        }
        public DataSet GetTSIpassUnitDtls(string UIDNO, string UserID)
        {
            DataRetrivalClass dataRetrivalClass = new DataRetrivalClass();
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@uidno",SqlDbType.VarChar),
               new SqlParameter("@Createdby",SqlDbType.VarChar)
           };
            pp[0].Value = UIDNO;
            pp[1].Value = UserID;
            //Dsnew = dataRetrivalClass.GenericFillDs("[GetCFEEnterprenuerDetailsNew_Service]", pp);
            Dsnew = dataRetrivalClass.GenericFillDs("[USP_GET_TSIPASSDATA_TTAP]", pp);
            return Dsnew;
        }
        public void GetIncetiveAttachements(string IncentiveId, string CAFFLAG)
        {
            DataSet dsnew1 = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentveID",SqlDbType.Int),
                new SqlParameter("@CAFFLAG",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = CAFFLAG;
            dsnew1 = ObjCAFClass.GenericFillDs("[USP_GET_ALLINCENTIVES_APPLICANT]", pp);

            if (dsnew1 != null && dsnew1.Tables.Count > 0 && dsnew1.Tables[0].Rows.Count > 0)
            {
                gvSubsidy.DataSource = dsnew1.Tables[0];
                gvSubsidy.DataBind();


                try
                {
                    int RowsCount = dsnew1.Tables[0].Rows.Count;
                    string Path, Docid;
                    for (int i = 0; i < RowsCount; i++)
                    {
                        Path = dsnew1.Tables[0].Rows[i]["FilePathMerge"].ToString();
                        Docid = dsnew1.Tables[0].Rows[i]["AttachmentId"].ToString();
                        if (!string.IsNullOrEmpty(Path))
                        {
                            if (Docid == "42")
                            {
                                objClsFileUpload.AssignPath(hySpecimenproject, Path);
                            }
                            if (Docid == "46")
                            {
                                objClsFileUpload.AssignPath(hySpecimenSignatureOperation, Path);
                            }
                            if (Docid == "47")
                            {
                                objClsFileUpload.AssignPath(hyGovermentOrder, Path);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void grdPandM_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }


        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Button ddlDeptnameFnl2 = (Button)sender;
            GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
            Label lblPM_Id = (Label)row.FindControl("lblPMId");
            Label lblIncentive_Id = (Label)row.FindControl("lblIncentiveId");
            Button btnEdit = (Button)row.FindControl("btnEdit");

            EditDetails(Convert.ToInt32(lblIncentive_Id.Text), Convert.ToInt32(lblPM_Id.Text));

            btnPandMAdd.Text = "Update";

            txtInvoiceDate.Enabled = true;
            txtInitiationDate.Enabled = true;
            txtMachineLoadingDate.Enabled = true;
            txtVaivleDate.Enabled = true;
        }
        protected void btnEditTextile_Click(object sender, EventArgs e)
        {
            Button ddlDeptnameFnl2 = (Button)sender;
            GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
            Label lblPM_Id = (Label)row.FindControl("lblPMId");
            Label lblIncentive_Id = (Label)row.FindControl("lblIncentiveId");
            Button btnEdit = (Button)row.FindControl("btnEdit");

            EditDetails(Convert.ToInt32(lblIncentive_Id.Text), Convert.ToInt32(lblPM_Id.Text));

            ddlpmtype.Enabled = true;
            btnPandMAdd.Text = "Update";
            
        }
        protected void btnEditCost_Click(object sender, EventArgs e)
        {
            Button ddlDeptnameFnl2 = (Button)sender;
            GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
            Label lblPM_Id = (Label)row.FindControl("lblPMId");
            Label lblIncentive_Id = (Label)row.FindControl("lblIncentiveId");
            Button btnEdit = (Button)row.FindControl("btnEdit");

            EditDetails(Convert.ToInt32(lblIncentive_Id.Text), Convert.ToInt32(lblPM_Id.Text));

            txtActMachineCost.Enabled = true;
            txtFreightCharges.Enabled = true;
            txtTransportCharges.Enabled = true;
            txtcgst.Enabled = true;
            txtsgst.Enabled = true;
            txtigst.Enabled = true;
            txtReqRemarks.Enabled = true;
            hdnPMCostEdit.Value = "Y";
            btnPandMAdd.Text = "Update";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button ddlDeptnameFnl2 = (Button)sender;
            GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
            Label lblPM_Id = (Label)row.FindControl("lblPMId");
            Label lblIncentive_Id = (Label)row.FindControl("lblIncentiveId");
            Button btnDelete = (Button)row.FindControl("btnDelete");
            int result = ObjCAFClass.DeletePlantandMachinery(Convert.ToInt32(lblPM_Id.Text), Convert.ToInt32(lblIncentive_Id.Text));
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "Deleted Successfully", true);
                BindPandMGrid(0, Convert.ToInt32(Session["IncentiveID"].ToString()));
                BindPMForPaymentProofs(Convert.ToInt32(Session["IncentiveID"].ToString()), Convert.ToInt32(ddlIndustryStatus.SelectedValue), "1");
                btnPandMAdd.Text = "Add New";
            }
        }

        protected void grdPandM_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //}
        }
        public void EditDetails(int IncentiveId, int PMId)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = GetPandM(PMId, IncentiveId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DivMachineryDetails.Visible = true;
                    ViewState["PMID"] = ds.Tables[0].Rows[0]["PMId"].ToString();
                    txtMachineName.Text = ds.Tables[0].Rows[0]["MachineName"].ToString();
                    txtVendorName.Text = ds.Tables[0].Rows[0]["VendorName"].ToString();
                    rdlMachineType.SelectedValue = ds.Tables[0].Rows[0]["TypeofMachineId"].ToString();
                    rdlMachineType_SelectedIndexChanged(this, EventArgs.Empty);
                    if (rdlMachineType.SelectedValue == "1")
                    {
                        if (ds.Tables[0].Rows[0]["MachinaryParts"].ToString() != "")
                        {
                            RdlMachinaryParts.SelectedValue = ds.Tables[0].Rows[0]["MachinaryParts"].ToString();
                        }

                        txtCustomCountryName.Text = ds.Tables[0].Rows[0]["CustomCountry"].ToString();
                        txtCustomPaid.Text = ds.Tables[0].Rows[0]["CustomPaid"].ToString();

                        txtImportduty.Text = ds.Tables[0].Rows[0]["Importduty"].ToString();
                        txtportcharges.Text = ds.Tables[0].Rows[0]["Portcharges"].ToString();
                        txtstatutorytaxesetc.Text = ds.Tables[0].Rows[0]["Statutorytaxes"].ToString();
                        txtCostoftheMachineforeign.Text = ds.Tables[0].Rows[0]["ForeignMachineCost"].ToString();
                        if (ds.Tables[0].Rows[0]["ForeignCurrency"].ToString() != "")
                        {
                            ddlForeignCurrency.SelectedValue = ds.Tables[0].Rows[0]["ForeignCurrency"].ToString();
                        }
                    }
                    txtManufacturerName.Text = ds.Tables[0].Rows[0]["ManufacturerName"].ToString();
                    txtInvoiceNo.Text = ds.Tables[0].Rows[0]["InvoiceNo"].ToString();
                    txtInvoiceDate.Text = ds.Tables[0].Rows[0]["InvoiceDate"].ToString();
                    txtMachineLoadingDate.Text = ds.Tables[0].Rows[0]["MahineLandingDate"].ToString();
                    txtVaivleNo.Text = ds.Tables[0].Rows[0]["VaivleNo"].ToString();
                    txtVaivleDate.Text = ds.Tables[0].Rows[0]["VaivleDate"].ToString();
                    txtInitiationDate.Text = ds.Tables[0].Rows[0]["IntiationDate"].ToString();
                    txtCostofMachine.Text = ds.Tables[0].Rows[0]["MachineCost"].ToString();
                    txtPrvCostOftheMachine.Text = ds.Tables[0].Rows[0]["MachineCost"].ToString();
                    ddlEligibility.SelectedValue = ds.Tables[0].Rows[0]["EligibilityId"].ToString();

                    RbtnInstalledMachinery.SelectedValue = ds.Tables[0].Rows[0]["InstalledMachinery"].ToString();

                    if (RbtnInstalledMachinery.SelectedValue == "1")
                    {
                        if (ds.Tables[0].Rows[0]["InstalledMachinerytype"].ToString() != "")
                        {
                            rbtnInstalledMachinerytype.SelectedValue = ds.Tables[0].Rows[0]["InstalledMachinerytype"].ToString();
                        }
                    }

                    hyInvoiceBills.Text = "View";
                    hyInvoiceBills.NavigateUrl = ds.Tables[0].Rows[0]["FilePathMerge2"].ToString();  //((HyperLink)(gr.FindControl("hyFilePathMerge2"))).NavigateUrl;
                    hyInvoiceBills.Visible = true;

                    if (ddlpmtype.Items.FindByValue(ds.Tables[0].Rows[0]["ClassificationMachinery"].ToString()) != null)
                    {
                        ddlpmtype.SelectedValue = ds.Tables[0].Rows[0]["ClassificationMachinery"].ToString();
                    }
                    txtActMachineCost.Text = ds.Tables[0].Rows[0]["ActualMachineCost"].ToString();
                    txtFreightCharges.Text = ds.Tables[0].Rows[0]["FreightCharges"].ToString();
                    txtTransportCharges.Text = ds.Tables[0].Rows[0]["TransportCharges"].ToString();
                    txtcgst.Text = ds.Tables[0].Rows[0]["Cgst"].ToString();
                    txtsgst.Text = ds.Tables[0].Rows[0]["Sgst"].ToString();
                    txtigst.Text = ds.Tables[0].Rows[0]["Igst"].ToString();
                    Double Cgstcost = 0, Sgstcost = 0, Igstcost = 0;
                    Cgstcost = Convert.ToDouble(GetDecimalNullValue(ds.Tables[0].Rows[0]["Cgst"].ToString()));
                    Sgstcost = Convert.ToDouble(GetDecimalNullValue(ds.Tables[0].Rows[0]["Sgst"].ToString()));
                    Igstcost = Convert.ToDouble(GetDecimalNullValue(ds.Tables[0].Rows[0]["Igst"].ToString()));
                    txttotalGst.Text = (Cgstcost + Sgstcost + Igstcost).ToString();
                    txtReqRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void clearControls()
        {
            ViewState["PMID"] = null;
            txtMachineName.Text = "";
            txtVendorName.Text = "";
            rdlMachineType.SelectedValue = "2";
            rdlMachineType_SelectedIndexChanged(this, EventArgs.Empty);
            txtManufacturerName.Text = "";
            txtInvoiceNo.Text = "";
            txtInvoiceDate.Text = "";
            txtMachineLoadingDate.Text = "";
            txtVaivleNo.Text = "";
            txtVaivleDate.Text = "";
            txtInitiationDate.Text = "";
            txtCostofMachine.Text = "";
            ddlEligibility.SelectedValue = "0";

            txtCustomCountryName.Text = "";
            txtCustomPaid.Text = "";
            txtImportduty.Text = "";
            txtportcharges.Text = "";
            txtstatutorytaxesetc.Text = "";
            txtCostoftheMachineforeign.Text = "";
            ddlForeignCurrency.SelectedValue = "0";
            RdlMachinaryParts.SelectedValue = "1";
            rbtnInstalledMachinerytype.SelectedValue = "1";
            hyInvoiceBills.NavigateUrl = "";
            hyInvoiceBills.Text = "";

            txtActMachineCost.Text = "";
            txtFreightCharges.Text = "";
            txtTransportCharges.Text = "";
            txtcgst.Text = "";
            txtsgst.Text = "";
            txtigst.Text = "";
            txttotalGst.Text = "";
            txtReqRemarks.Text = "";
        }

        protected void btnPrevious6_Click(object sender, EventArgs e)
        {
            AnchTab5_Click(sender, e);
        }

        protected void btnNext6_Click(object sender, EventArgs e)
        {
            string errormsg = "";
            if (errormsg == "")
            {
                errormsg = ValidateControls("1");
            }
            if (errormsg == "")
            {
                errormsg = ValidateControls("2");
            }
            if (errormsg == "")
            {
                errormsg = ValidateControls("3");
            }
            if (errormsg == "")
            {
                errormsg = ValidateControls("4");
            }
            if (errormsg == "")
            {
                errormsg = ValidateControls("5");
            }
            if (errormsg == "")
            {
                errormsg = ValidateControls("6");
            }
            if (errormsg.Trim().TrimStart() != "")
            {
                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

            string Url = "TypeOfIncentivesNew1.aspx"; string Flag = "Y";
            if (Request.QueryString.Count > 0 && Request.QueryString["ViewType"] != null && Request.QueryString["ViewType"].ToString() != "")
            {
                Url = Url + "?ViewType=" + Request.QueryString["ViewType"].ToString() + "&NFlag=" + Flag;
            }
            else
            {
                Url = Url + "?NFlag=" + Flag;
            }
            Response.Redirect(Url);
            //Response.Redirect("frmacknowledgement.aspx");
        }

        protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string Statusid = DataBinder.Eval(e.Row.DataItem, "intStageid").ToString();
                    if (Statusid != "")
                    {
                        int Statusidnew = Convert.ToInt32(Statusid);
                        if (Statusidnew == 13 || Statusidnew == 14 || Statusidnew == 15 || Statusidnew == 16 || Statusidnew == 22 || Statusidnew == 11)
                        {
                            e.Row.FindControl("lblverified").Visible = false;
                            e.Row.FindControl("HyperLinkSubsidy").Visible = true;
                        }
                        else
                        {
                            e.Row.FindControl("lblverified").Visible = true;
                            e.Row.FindControl("HyperLinkSubsidy").Visible = false;
                        }
                        if (((HyperLink)e.Row.FindControl("HyperLinkSubsidy")).NavigateUrl == "")
                        {
                            e.Row.FindControl("lblverified").Visible = true;
                            e.Row.FindControl("HyperLinkSubsidy").Visible = false;
                        }
                    }
                    if ((Session["uid"].ToString() == "1222" || Session["uid"].ToString() == "1238" || Session["uid"].ToString() == "3377"))
                    {
                        string intApprovalid = DataBinder.Eval(e.Row.DataItem, "intApprovalid").ToString();
                        if ((intApprovalid == "6" || intApprovalid == "45") && Statusid != "22" && Statusid != "2" && Statusid != "1")
                        {
                            e.Row.FindControl("lblapprovalname").Visible = false;
                            e.Row.FindControl("hplkapprovalsname").Visible = true;
                        }
                        else
                        {
                            e.Row.FindControl("lblapprovalname").Visible = true;
                            e.Row.FindControl("hplkapprovalsname").Visible = false;
                        }
                    }
                    else
                    {
                        e.Row.FindControl("lblapprovalname").Visible = true;
                        e.Row.FindControl("hplkapprovalsname").Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnUpload1_Click(object sender, EventArgs e)
        {
            HyperLink lblUpload1 = new HyperLink();
            string CategoryID = string.Empty;
            if (ddltypeofDocuments.SelectedValue == "0")
            {
                string errormsg = "Please Select Type of Document";

                string message = "alert('" + errormsg + "')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            else if (fuDocuments1.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuDocuments1);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                //if (fuDocuments1.PostedFile.ContentLength > (1024 * 1024))
                //{
                //    string errormsg = "The File Size Should Not Exceed 1MB";

                //    string message = "alert('" + errormsg + "')";
                //    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                //    return;

                //}
                string Mimetype = objClsFileUpload.getmimetype(fuDocuments1);
                if (Mimetype == "application/pdf")
                {
                    DataSet ds = new DataSet();
                    ds = (DataSet)ViewState["DOCSLIST"];
                    DataRow[] drs = ds.Tables[0].Select("TypeOfDcoumentID = " + ddltypeofDocuments.SelectedValue);
                    if (drs.Length > 0)
                    {
                        CategoryID = drs[0]["Document_Category_ID"].ToString();
                    }
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuDocuments1, lblUpload1, "CAFUploads", Session["IncentiveID"].ToString(), CategoryID, ddltypeofDocuments.SelectedValue, Session["uid"].ToString(), "USER");
                    if (OutPut != "0")
                    {
                        // Uploaded Attachemnts Binding
                        GetIncetiveAttachements(Session["IncentiveID"].ToString(), "Y");
                        success.Visible = true;
                        Failure.Visible = false;
                        lblmsg.Text = "Attachment Successfully Added..!";
                        BindDocumentsList(Session["IncentiveID"].ToString());
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed !");
                }
            }
        }
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        protected void gvSubsidy_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbl = (e.Row.FindControl("lbl") as Label);
                    HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyperLinkSubsidy") as HyperLink);

                    string Category = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Category"));
                    if (Category.Trim().TrimStart() != "")
                    {
                        lbl.Text = Category.Trim().TrimStart();
                        e.Row.Font.Bold = true;
                        HyperLinkSubsidy.Visible = false;
                    }

                    //Label enterid = (e.Row.FindControl("lblverified") as Label);
                    //if (lbl.Text == "")
                    //{
                    //    e.Row.Cells[1].ColumnSpan = 2;
                    //    e.Row.Cells.RemoveAt(2);
                    //    HyperLinkSubsidy.Visible = false;
                    //    e.Row.Font.Bold = true;
                    //}
                    //if (enterid.Text.ToString() == "")
                    //{
                    //    HyperLinkSubsidy.Visible = false;
                    //}
                    //if (lbl.Text == "")
                    //{
                    //    e.Row.Cells[1].ColumnSpan = 2;
                    //    e.Row.Cells.RemoveAt(2);
                    //    HyperLinkSubsidy.Visible = false;
                    //    e.Row.Font.Bold = true;
                    //}
                    //if (lbl.Text != "")
                    //{
                    //    e.Row.Cells[2].ColumnSpan = 2;
                    //    e.Row.Cells.RemoveAt(1);
                    //}
                    if (HyperLinkSubsidy.NavigateUrl == "")
                    {
                        HyperLinkSubsidy.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                //lblmsg0.Text = "Internal error has occured. Please try after some time";
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                // LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        protected void rdlMachineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdlMachineType.SelectedValue == "1")
            {
                divImported.Visible = true;
            }
            else
            {
                divImported.Visible = false;
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Calculate()", true);
        }



        protected void txtstaffMaleNonLocal_TextChanged(object sender, EventArgs e)
        {
            CalculatationofEmployemnt("5");
        }

        protected void txtfemaleNonLocal_TextChanged(object sender, EventArgs e)
        {
            CalculatationofEmployemnt("6");
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string CategoryID = string.Empty;

            if (fpdSpecimen.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fpdSpecimen);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fpdSpecimen);
                if (Mimetype == "application/pdf")
                {
                    CategoryID = "2";
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fpdSpecimen, hySpecimenproject, "CAFUploads", Session["IncentiveID"].ToString(), CategoryID, "42", Session["uid"].ToString(), "USER");
                    if (OutPut != "0")
                    {
                        // Uploaded Attachemnts Binding
                        GetIncetiveAttachements(Session["IncentiveID"].ToString(), "Y");
                        success.Visible = true;
                        Failure.Visible = false;
                        hySpecimenproject.Visible = true;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed !");
                }
            }
        }

        protected void ddlTextileProcessType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTextileProcessType.SelectedValue == "18")
            {
                divNewOtherTextileProcessType.Visible = true;
            }
            else
            {
                divNewOtherTextileProcessType.Visible = false;
            }
        }

        protected void ddlTextileProcessTypeExp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTextileProcessTypeExp.SelectedValue == "18")
            {
                divExistOtherTextileProcessType.Visible = true;
            }
            else
            {
                divExistOtherTextileProcessType.Visible = false;
            }
        }

        protected void btnIndirectEmploymentadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["IndirectEmploymentID"] == null)
                {
                    ViewState["IndirectEmploymentID"] = "0";
                }

                string errormsg = IndirectEmpValidation();
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

                    IndirectEmploymentVo objIndirectEmploymentVo = new IndirectEmploymentVo();
                    objIndirectEmploymentVo.IndirectEmploymentID = ViewState["IndirectEmploymentID"].ToString();

                    objIndirectEmploymentVo.Category = txtCategory.Text.Trim().TrimStart();
                    objIndirectEmploymentVo.IndirectMale = txtIndirectMale.Text.Trim().TrimStart();
                    objIndirectEmploymentVo.IndirectFemale = txtIndirectFemale.Text.Trim().TrimStart();

                    objIndirectEmploymentVo.Created_by = ObjLoginNewvo.uid;
                    objIndirectEmploymentVo.TransType = "INS";
                    objIndirectEmploymentVo.IncentiveId = Session["IncentiveID"].ToString();

                    string Validstatus = ObjCAFClass.InsertIndirectEmployment(objIndirectEmploymentVo);
                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        btnIndirectEmploymentadd.Text = "Add New";
                        ViewState["IndirectEmploymentID"] = "0";

                        txtCategory.Text = "";
                        txtIndirectMale.Text = "";
                        txtIndirectFemale.Text = "";

                        BindIndirectEmploymentDtls(Session["IncentiveID"].ToString());
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

        protected void btnIndirectEmploymentclear_Click(object sender, EventArgs e)
        {

        }

        protected void gvIndirectEmployment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                txtCategory.Text = ((Label)(gr.FindControl("lblCategory"))).Text;
                txtIndirectMale.Text = ((Label)(gr.FindControl("lblMale"))).Text;
                txtIndirectFemale.Text = ((Label)(gr.FindControl("lblFemale"))).Text;

                ViewState["IndirectEmploymentID"] = ((Label)(gr.FindControl("lblIndirectEmploymentID"))).Text;
                btnIndirectEmploymentadd.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                IndirectEmploymentVo objIndirectEmploymentVo = new IndirectEmploymentVo();

                objIndirectEmploymentVo.IndirectEmploymentID = ((Label)(gr.FindControl("lblIndirectEmploymentID"))).Text;
                objIndirectEmploymentVo.Created_by = ObjLoginNewvo.uid;
                objIndirectEmploymentVo.TransType = "DLT";
                objIndirectEmploymentVo.IncentiveId = Session["IncentiveID"].ToString();

                string Validstatus = ObjCAFClass.InsertIndirectEmployment(objIndirectEmploymentVo);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnIndirectEmploymentadd.Text = "Add New";
                    ViewState["IndirectEmploymentID"] = "0";
                    BindIndirectEmploymentDtls(Session["IncentiveID"].ToString());
                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                    txtCategory.Text = "";
                    txtIndirectMale.Text = "";
                    txtIndirectFemale.Text = "";
                }
            }
        }
        public DataSet GetIndirectEmploymentDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_INCENTIVE_INDIRECTEMP_DTLS", pp);
            return Dsnew;
        }
        protected void BindIndirectEmploymentDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetIndirectEmploymentDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    gvIndirectEmployment.DataSource = dsnew.Tables[0];
                    gvIndirectEmployment.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void txtinstalledccap_TextChanged(object sender, EventArgs e)
        {
            ProductLOACal("1");
        }

        protected void txtValuePerUnit_TextChanged(object sender, EventArgs e)
        {
            ProductLOACal("1");
        }

        public void ProductLOACal(string LOA)
        {
            decimal Value1 = 0, Value2 = 0, Value3 = 0;
            if (LOA == "1")
            {
                if (txtinstalledccap.Text.Trim().TrimStart().TrimEnd() != "")
                {
                    Value1 = Convert.ToDecimal(txtinstalledccap.Text.Trim().TrimStart().TrimEnd());
                }
                if (txtValuePerUnit.Text.Trim().TrimStart().TrimEnd() != "")
                {
                    Value2 = Convert.ToDecimal(txtValuePerUnit.Text.Trim().TrimStart().TrimEnd());
                }

                Value3 = Value1 * Value2;

                txtvalue.Text = Value3.ToString();
            }
            else if (LOA == "2")
            {
                if (txtinstalledccapExpan.Text.Trim().TrimStart().TrimEnd() != "")
                {
                    Value1 = Convert.ToDecimal(txtinstalledccapExpan.Text.Trim().TrimStart().TrimEnd());
                }
                if (txtvalueExpanPerUnit.Text.Trim().TrimStart().TrimEnd() != "")
                {
                    Value2 = Convert.ToDecimal(txtvalueExpanPerUnit.Text.Trim().TrimStart().TrimEnd());
                }

                Value3 = Value1 * Value2;

                txtvalueExpan.Text = Value3.ToString();
            }
        }

        protected void txtinstalledccapExpan_TextChanged(object sender, EventArgs e)
        {
            ProductLOACal("2");
        }

        protected void txtvalueExpanPerUnit_TextChanged(object sender, EventArgs e)
        {
            ProductLOACal("2");
        }

        protected void ddlEducationalQualificationPatners_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEducationalQualificationPatners.SelectedValue == "22")
            {
                txtEducationalQual.Visible = true;
            }
            else
            {
                txtEducationalQual.Visible = false;
            }
        }

        protected void btnSpecimenSignatureOperation_Click(object sender, EventArgs e)
        {
            string CategoryID = string.Empty;

            if (FuSpecimenSignatureOperation.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(FuSpecimenSignatureOperation);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(FuSpecimenSignatureOperation);
                if (Mimetype == "application/pdf")
                {
                    CategoryID = "7";
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), FuSpecimenSignatureOperation, hySpecimenSignatureOperation, "CAFUploads", Session["IncentiveID"].ToString(), CategoryID, "46", Session["uid"].ToString(), "USER");
                    if (OutPut != "0")
                    {
                        // Uploaded Attachemnts Binding
                        GetIncetiveAttachements(Session["IncentiveID"].ToString(), "Y");
                        success.Visible = true;
                        Failure.Visible = false;
                        hySpecimenSignatureOperation.Visible = true;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed !");
                }
            }
        }

        protected void ddlSpecialIncentive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSpecialIncentive.SelectedValue == "Y")
            {
                DivSpecialIncentive.Visible = true;
            }
            else
            {
                DivSpecialIncentive.Visible = false;
            }
        }

        protected void btnGovermentOrder_Click(object sender, EventArgs e)
        {
            string CategoryID = string.Empty;

            if (fuGovermentOrder.HasFile)
            {
                string errormsg = objClsFileUpload.CheckFileSize(fuGovermentOrder);
                if (errormsg != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuGovermentOrder);
                if (Mimetype == "application/pdf")
                {
                    CategoryID = "1";
                    string OutPut = objClsFileUpload.IncentiveFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuGovermentOrder, hyGovermentOrder, "CAFUploads", Session["IncentiveID"].ToString(), CategoryID, "47", Session["uid"].ToString(), "USER");
                    if (OutPut != "0")
                    {
                        // Uploaded Attachemnts Binding
                        GetIncetiveAttachements(Session["IncentiveID"].ToString(), "Y");
                        success.Visible = true;
                        Failure.Visible = false;
                        hyGovermentOrder.Visible = true;
                        lblmsg.Text = "Attachment Successfully Added..!";
                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed !");
                }
            }
        }

        protected void rdl_TypeofUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdl_TypeofUnit.SelectedValue == "1")
            {
                divTechnicalNatureOfIndustry.Visible = true;
            }
            else
            {
                divTechnicalNatureOfIndustry.Visible = false;
            }
        }

        protected void RbtnInstalledMachinery_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RbtnInstalledMachinery.SelectedValue == "1")
            {
                divInstalledMachinerytype.Visible = true;
                divInstalledMachinerytype1.Visible = true;
            }
            else
            {
                divInstalledMachinerytype.Visible = false;
                divInstalledMachinerytype1.Visible = false;
            }
        }
        public void GetFinancialYears(string Date)
        {
            DataSet dsFinancialYears = new DataSet();
            dsFinancialYears = ObjCAFClass.GetFinancialYears(Date);

            if (dsFinancialYears != null && dsFinancialYears.Tables.Count > 0 && dsFinancialYears.Tables[0].Rows.Count > 2)
            {
                thYear1.InnerHtml = dsFinancialYears.Tables[0].Rows[0]["FinancialYear"].ToString();
                thYear2.InnerHtml = dsFinancialYears.Tables[0].Rows[1]["FinancialYear"].ToString();
                thYear3.InnerHtml = dsFinancialYears.Tables[0].Rows[2]["FinancialYear"].ToString();

                lblProductionYear1.Text = dsFinancialYears.Tables[0].Rows[0]["FinancialYear"].ToString();
                lblProductionYear2.Text = dsFinancialYears.Tables[0].Rows[1]["FinancialYear"].ToString();
                lblProductionYear3.Text = dsFinancialYears.Tables[0].Rows[2]["FinancialYear"].ToString();
            }
        }
        public string PMAbstractValidations()
        {
            int slno = 1;
            string ErrorMsg = "";

            if (txtTypeOfMachinery.Text.Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Type Of Machinery" + "\\n";
                slno = slno + 1;
            }
            if (txtNoofmachines.Text == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter No of Machines" + "\\n";
                slno = slno + 1;
            }
            if (!fuPhotographMachinary.HasFile && hyPmAbstractLink.NavigateUrl == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Photograph of Machinary & its Products (Pdf Only)" + "\\n";
                slno = slno + 1;
            }
            else if (hyPmAbstractLink.NavigateUrl == "" && fuPhotographMachinary.HasFile)
            {
                string errormsg1 = objClsFileUpload.CheckFileSize(fuPhotographMachinary);
                if (errormsg1 != "")
                {
                    ErrorMsg = ErrorMsg + slno + ". " + errormsg1;
                    slno = slno + 1;
                }
                string Mimetype = objClsFileUpload.getmimetype(fuPhotographMachinary);
                if (Mimetype != "application/pdf")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Upload Pdf Files Only" + "\\n";
                    slno = slno + 1;
                }
            }


            return ErrorMsg;

        }
        protected void btnabstractadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["PMAbstractID"] == null)
                {
                    ViewState["PMAbstractID"] = "0";
                }

                string errormsg = PMAbstractValidations();
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

                    PMAbstractVo objPMAbstractVo = new PMAbstractVo();
                    objPMAbstractVo.PMAbstractID = ViewState["PMAbstractID"].ToString();

                    objPMAbstractVo.TypeOfMachinery = txtTypeOfMachinery.Text.Trim().TrimStart();
                    objPMAbstractVo.Noofmachines = txtNoofmachines.Text.Trim().TrimStart();

                    HyperLink hyperLinkNew = new HyperLink();
                    if (fuPhotographMachinary.HasFile)
                    {
                        string OutPut = objClsFileUpload.IncentiveFileUploadingPM("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuPhotographMachinary, hyperLinkNew, "CAFUploads", Session["IncentiveID"].ToString(), "8", "48", Session["uid"].ToString(), "USER");
                        objPMAbstractVo.AttachmentId = OutPut;
                    }

                    objPMAbstractVo.Created_by = ObjLoginNewvo.uid;
                    objPMAbstractVo.TransType = "INS";
                    objPMAbstractVo.IncentiveId = Session["IncentiveID"].ToString();

                    string Validstatus = ObjCAFClass.InsertPMAbstract(objPMAbstractVo);
                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        btnabstractadd.Text = "Add New";
                        ViewState["PMAbstractID"] = "0";

                        txtTypeOfMachinery.Text = "";
                        txtNoofmachines.Text = "";

                        hyPmAbstractLink.Text = "";
                        hyPmAbstractLink.NavigateUrl = "";
                        hyPmAbstractLink.Visible = false;

                        BindPMabstractDtls(Session["IncentiveID"].ToString());
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

        public DataSet GetPMabstractDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_INCENTIVE_PMAbstract_DTLS", pp);
            return Dsnew;
        }
        protected void BindPMabstractDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetPMabstractDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    gvPMAbstract.DataSource = dsnew.Tables[0];
                    gvPMAbstract.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void gvPMAbstract_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
            if (e.CommandName == "Rowedit")
            {
                txtTypeOfMachinery.Text = ((Label)(gr.FindControl("lblTypeOfMachinery"))).Text;
                txtNoofmachines.Text = ((Label)(gr.FindControl("lblNoofmachines"))).Text;
                hyPmAbstractLink.Text = "View";
                hyPmAbstractLink.NavigateUrl = ((HyperLink)(gr.FindControl("hyFilePathMerge"))).NavigateUrl;
                hyPmAbstractLink.Visible = true;

                //hyInvoiceBills.Text = "View";
                //hyInvoiceBills.NavigateUrl = ((HyperLink)(gr.FindControl("hyFilePathMerge2"))).NavigateUrl;
                //hyInvoiceBills.Visible = true;

                ViewState["PMAbstractID"] = ((Label)(gr.FindControl("lblPMAbstractID"))).Text;
                btnabstractadd.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                PMAbstractVo objPMAbstractVo = new PMAbstractVo();

                objPMAbstractVo.PMAbstractID = ((Label)(gr.FindControl("lblPMAbstractID"))).Text;
                objPMAbstractVo.Created_by = ObjLoginNewvo.uid;
                objPMAbstractVo.TransType = "DLT";
                objPMAbstractVo.IncentiveId = Session["IncentiveID"].ToString();

                string Validstatus = ObjCAFClass.InsertPMAbstract(objPMAbstractVo);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    btnabstractadd.Text = "Add New";
                    ViewState["PMAbstractID"] = "0";
                    BindPMabstractDtls(Session["IncentiveID"].ToString());
                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                    txtTypeOfMachinery.Text = "";
                    txtNoofmachines.Text = "";
                    hyPmAbstractLink.Text = "";
                    hyPmAbstractLink.NavigateUrl = "";
                    hyPmAbstractLink.Visible = false;
                }
            }
        }

        protected void txtcurrInvLandValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                calculateCurrInvTot();
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
        public void calculateCurrInvTot()
        {
            try
            {
                decimal currInvLandValue = Convert.ToDecimal(GetDecimalNullValue(txtcurrInvLandValue.Text.Trim().TrimStart()));
                decimal currInvBuldvalue = Convert.ToDecimal(GetDecimalNullValue(txtcurrInvBuldvalue.Text.Trim().TrimStart()));
                decimal currInvplantMechValue = Convert.ToDecimal(GetDecimalNullValue(txtcurrInvplantMechValue.Text.Trim().TrimStart()));
                decimal currInvOtherValue = Convert.ToDecimal(GetDecimalNullValue(txtcurrentInvothers.Text.Trim().TrimStart()));

                lblCurrInvTot.Text = (currInvLandValue + currInvBuldvalue + currInvplantMechValue + currInvOtherValue).ToString();
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

        public DataSet GetApplicantIncentivesHistory(string USERID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UserID",SqlDbType.VarChar)

           };
            pp[0].Value = USERID;

            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_APPLICANT_INCENTIVES_HISTORY", pp);
            return Dsnew;
        }

        public void GetApprovedProjectPercentage(string Step)
        {
            if (ddlIndustryStatus.SelectedValue == "2" || ddlIndustryStatus.SelectedValue == "3" || ddlIndustryStatus.SelectedValue == "4")
            {
                try
                {
                    decimal PlantMachValexisting = 0;
                    decimal PlantMachValexpansion = 0;
                    //decimal PlantMachValFinal = 0;


                    decimal landexisting = 0, landcapacity = 0;

                    decimal buildingexisting = 0, buildingcapacity = 0;

                    //decimal Othernew = 0, OtherExisting = 0;

                    //decimal PlantMachValPer = 0;
                    //decimal landcapacityPer = 0;
                    //decimal buildingcapacityPer = 0;
                    //decimal OthernewPer = 0;

                    decimal TotalExisting = 0;
                    decimal TotalExpDivMod = 0;

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

                        if (txtlandcapacity.Text != null && txtlandcapacity.Text != "" && txtlandcapacity.Text != string.Empty)
                        {
                            landcapacity = Convert.ToDecimal(txtlandcapacity.Text.Trim());   // exiting Plant Mach value
                        }
                        else
                        {
                            landcapacity = 0;
                        }

                        try
                        {
                            //PlantMachValFinal = (landcapacity / landexisting) * 100;
                            //txtlandpercentage.Text = PlantMachValFinal.ToString("#.##");
                            txtlandpercentage.Text = ((float)System.Math.Round(((landcapacity / landexisting) * 100), 2)).ToString();//("#.##");
                            if (txtlandpercentage.Text == "∞" || txtlandpercentage.Text == "0")
                            {
                                txtlandpercentage.Text = "0";
                            }

                        }
                        catch (Exception ex)
                        {

                            txtlandpercentage.Text = "0";
                            string errorMsg = ex.Message;
                        }
                    }
                    else if (Step == "2")
                    {
                        //--------------------------------

                        if (txtbuildingcapacity.Text != null && txtbuildingcapacity.Text != "" && txtbuildingcapacity.Text != string.Empty)
                        {
                            buildingcapacity = Convert.ToDecimal(txtbuildingcapacity.Text.Trim());   // exiting Plant Mach value
                        }
                        else
                        {
                            buildingcapacity = 0;
                        }

                        if (txtbuildingexisting.Text != null && txtbuildingexisting.Text != "" && txtbuildingexisting.Text != string.Empty)
                        {
                            buildingexisting = Convert.ToDecimal(txtbuildingexisting.Text.Trim());   // exiting Plant Mach value
                        }
                        else
                        {
                            buildingexisting = 0;
                        }
                        try
                        {
                            //PlantMachValFinal = (buildingcapacity / buildingexisting) * 100;
                            //txtbuildingpercentage.Text = PlantMachValFinal.ToString("#.##");

                            txtbuildingpercentage.Text = ((float)System.Math.Round(((buildingcapacity / buildingexisting) * 100), 2)).ToString();//("#.##");
                            if (txtbuildingpercentage.Text == "∞" || txtbuildingpercentage.Text == "0")
                            {
                                txtbuildingpercentage.Text = "0";
                            }
                        }
                        catch (Exception ex)
                        {
                            string errorMsg = ex.Message;
                            txtbuildingpercentage.Text = "0";
                        }
                        // -------------------------------
                    }
                    else if (Step == "3")
                    {
                        if (txtplantcapacity.Text != null && txtplantcapacity.Text != "" && txtplantcapacity.Text != string.Empty)
                        {
                            PlantMachValexpansion = Convert.ToDecimal(txtplantcapacity.Text.Trim());  // expansion Plant Mach value   
                        }
                        else
                        {
                            PlantMachValexpansion = 0;
                        }

                        if (txtplantexisting.Text != null && txtplantexisting.Text != "" && txtplantexisting.Text != string.Empty)
                        {
                            PlantMachValexisting = Convert.ToDecimal(txtplantexisting.Text.Trim());   // exiting Plant Mach value
                        }
                        else
                        {
                            PlantMachValexisting = 0;
                        }
                        try
                        {
                            //PlantMachValFinal = (PlantMachValexpansion / PlantMachValexisting) * 100;
                            //txtplantpercentage.Text = PlantMachValFinal.ToString("#.##");

                            txtplantpercentage.Text = ((float)System.Math.Round(((PlantMachValexpansion / PlantMachValexisting) * 100), 2)).ToString();//("#.##");
                            if (txtplantpercentage.Text == "∞" || txtplantpercentage.Text == "0")
                            {
                                txtplantpercentage.Text = "0";
                            }
                        }
                        catch (Exception ex)
                        {
                            string errorMsg = ex.Message;
                            txtplantpercentage.Text = "0";
                        }
                    }
                    else if (Step == "4")
                    {
                        //if (txtlandpercentage.Text != null && txtlandpercentage.Text != "" && txtlandpercentage.Text != string.Empty)
                        //{
                        //    landcapacityPer = Convert.ToDecimal(txtlandpercentage.Text.Trim());  // expansion Plant Mach value   
                        //}
                        //else
                        //{
                        //    landcapacityPer = 0;
                        //}

                        //if (txtbuildingpercentage.Text != null && txtbuildingpercentage.Text != "" && txtbuildingpercentage.Text != string.Empty)
                        //{
                        //    buildingcapacityPer = Convert.ToDecimal(txtbuildingpercentage.Text.Trim());  // expansion Plant Mach value   
                        //}
                        //else
                        //{
                        //    buildingcapacityPer = 0;
                        //}

                        //if (txtplantpercentage.Text != null && txtplantpercentage.Text != "" && txtplantpercentage.Text != string.Empty)
                        //{
                        //    PlantMachValPer = Convert.ToDecimal(txtplantpercentage.Text.Trim());  // expansion Plant Mach value   
                        //}
                        //else
                        //{
                        //    PlantMachValPer = 0;
                        //}

                        //if (txtlandpercentage.Text != null && txtlandpercentage.Text != "" && txtlandpercentage.Text != string.Empty)
                        //{
                        //    landcapacityPer = Convert.ToDecimal(txtlandpercentage.Text.Trim());  // expansion Plant Mach value   
                        //}
                        //else
                        //{
                        //    landcapacityPer = 0;
                        //}
                        //try
                        //{
                        //    PlantMachValFinal = Convert.ToDecimal((landcapacityPer + buildingcapacityPer + PlantMachValPer) / 3);
                        //    lbltotperinv.Text = ((float)System.Math.Round(PlantMachValFinal, 2)).ToString();
                        //}
                        //catch (Exception ex)
                        //{
                        //    txtplantpercentage.Text = "0";
                        //}

                        if (lblnewinv.Text != null && lblnewinv.Text != "" && lblnewinv.Text != string.Empty)
                        {
                            TotalExisting = Convert.ToDecimal(lblnewinv.Text.Trim());  // expansion Plant Mach value   
                        }
                        else
                        {
                            TotalExisting = 0;
                        }
                        if (lblexpinv.Text != null && lblexpinv.Text != "" && lblexpinv.Text != string.Empty)
                        {
                            TotalExpDivMod = Convert.ToDecimal(lblexpinv.Text.Trim());  // expansion Plant Mach value   
                        }
                        else
                        {
                            TotalExpDivMod = 0;
                        }


                        try
                        {
                            lbltotperinv.Text = ((float)System.Math.Round(((TotalExpDivMod / TotalExisting) * 100), 2)).ToString();//("#.##");
                            if (lbltotperinv.Text == "∞" || lbltotperinv.Text == "0")
                            {
                                lbltotperinv.Text = "0";
                            }
                        }
                        catch (Exception ex)
                        {
                            string errorMsg = ex.Message;
                            lbltotperinv.Text = "0";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblmsg0.Text = ex.Message;
                    Failure.Visible = true;
                    success.Visible = false;
                }
            }
        }

        protected void rbtnInvoiceTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtnInvoiceTypes.SelectedValue == "1")
            {
                DivMachineryDetails.Visible = true;
                DivMachineryDetails1.Visible = true;
                DivMachineryDetails2.Visible = true;
                // divPMRatio.Visible = true; // this is only for Welspun
                DivGrossMachineryDetails.Visible = false;
                DivGrossblockMachineryDetails1.Visible = false;
                divPMPaymentDetails.Visible = true;
            }
            else
            {
                DivMachineryDetails.Visible = false;
                DivMachineryDetails1.Visible = false;
                DivMachineryDetails2.Visible = false;
                DivGrossMachineryDetails.Visible = true;
                DivGrossblockMachineryDetails1.Visible = true;
                divPMPaymentDetails.Visible = false;
            }
        }
        public string ValidateGrossBlock()
        {
            string CertifiedDate = "";

            int slno = 1;
            string ErrorMsg = "";

            if (txtAuditedBalanceYear.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Audited Balance Year\\n";
                slno = slno + 1;
            }
            if (txtAmountGrossBlock.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter  Amount Gross Block in Rs\\n";
                slno = slno + 1;
            }

            if (txtCertifiedBy.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Certified By\\n";
                slno = slno + 1;
            }

            if (txtCertifiedDate.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Certified Date\\n";
                slno = slno + 1;
            }
            else
            {
                CertifiedDate = GetFromatedDateDDMMYYYY(txtCertifiedDate.Text.TrimStart().TrimEnd().Trim());
                string Msg = CheckFuturedate(CertifiedDate, "CertifiedDate");
                if (Msg != "")
                {
                    ErrorMsg = ErrorMsg + slno + ". " + Msg;
                }
            }
            if (!fuGrossBlock.HasFile && HyGrossBlock.NavigateUrl == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Upload Audited Balance Sheet (Pdf Only)" + "\\n";
                slno = slno + 1;
            }
            else if (fuGrossBlock.HasFile)
            {
                string Mimetype = objClsFileUpload.getmimetype(fuGrossBlock);
                if (Mimetype != "application/pdf")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Upload Pdf Files Only" + "\\n";
                    slno = slno + 1;
                }
            }

            return ErrorMsg;
        }

        protected void btnGrossPandMAdd_Click(object sender, EventArgs e)
        {
            string errormsg = ValidateGrossBlock();
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

                PlantandMachineryGrossBlock pm = new PlantandMachineryGrossBlock();
                if (ViewState["GBId"] != null)
                    pm.GBId = Convert.ToInt32(ViewState["GBId"].ToString());
                else
                    pm.GBId = 0;
                pm.Created_by = ObjLoginNewvo.uid;
                pm.TransType = "INS";

                pm.IncentiveID = Convert.ToInt32(Session["IncentiveID"].ToString());

                pm.AuditedBalanceSheetYear = txtAuditedBalanceYear.Text;
                pm.AmountGrossBlock = txtAmountGrossBlock.Text;
                pm.CertifiedBy = txtCertifiedBy.Text;
                pm.CertifiedDate = GetFromatedDateDDMMYYYY(txtCertifiedDate.Text);

                HyperLink hyperLinkNew1 = new HyperLink();
                if (fuGrossBlock.HasFile)
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploadingPM("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuGrossBlock, hyperLinkNew1, "CAFUploads", Session["IncentiveID"].ToString(), "9", "50", Session["uid"].ToString(), "USER");
                    pm.AttachmentId2 = OutPut;
                }
                string DbErrorMsg = "";
                int result = ObjCAFClass.InsertGrossBlackPlantandMachinery(pm, out DbErrorMsg);
                if (result > 0 && DbErrorMsg == "")
                {
                    //Add to Grid Method
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Updated Successfully');", true);
                    BindGrossBlockPandMGrid(0, Convert.ToInt32(Session["IncentiveID"].ToString()));
                    ClearControlsGrossBlock();
                    btnGrossPandMAdd.Text = "Add New";
                }
                else
                {
                    if (DbErrorMsg.Trim().TrimStart() != "")
                    {
                        string dbmessage = "alert('" + DbErrorMsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", dbmessage, true);
                        return;
                    }
                }
            }
        }

        protected void gvGrossblockPandM_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                txtAuditedBalanceYear.Text = ((Label)(gr.FindControl("lblAuditedBalanceSheetYear"))).Text;
                txtAmountGrossBlock.Text = ((Label)(gr.FindControl("lblAmountGrossBlock"))).Text;
                txtCertifiedBy.Text = ((Label)(gr.FindControl("lblCertifiedBy"))).Text;
                txtCertifiedDate.Text = ((Label)(gr.FindControl("lblCertifiedDate"))).Text;

                HyGrossBlock.Text = "View";
                HyGrossBlock.NavigateUrl = ((HyperLink)(gr.FindControl("hyFilePathMerge2"))).NavigateUrl;
                HyGrossBlock.Visible = true;

                ViewState["GBId"] = ((Label)(gr.FindControl("lblGBId"))).Text;
                btnGrossPandMAdd.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];


                PlantandMachineryGrossBlock pm = new PlantandMachineryGrossBlock();

                pm.GBId = Convert.ToInt32(((Label)(gr.FindControl("lblGBId"))).Text);
                pm.TransType = "DLT";
                pm.IncentiveID = Convert.ToInt32(Session["IncentiveID"].ToString());
                pm.Created_by = ObjLoginNewvo.uid;


                string DbErrorMsg = "";
                int result = ObjCAFClass.InsertGrossBlackPlantandMachinery(pm, out DbErrorMsg);
                if (result > 0 && DbErrorMsg == "")
                {
                    //Add to Grid Method
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Deleted Successfully');", true);
                    BindGrossBlockPandMGrid(0, Convert.ToInt32(Session["IncentiveID"].ToString()));
                    ClearControlsGrossBlock();
                    btnGrossPandMAdd.Text = "Add New";
                    ViewState["GBId"] = "0";

                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
                else
                {
                    if (DbErrorMsg.Trim().TrimStart() != "")
                    {
                        string dbmessage = "alert('" + DbErrorMsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", dbmessage, true);
                        return;
                    }
                }
            }
        }

        public void BindGrossBlockPandMGrid(int GBId, int IncentiveId)
        {
            DataSet ds = new DataSet();
            try
            {
                ds = GetGrossBlockPandM(GBId, IncentiveId);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvGrossblockPandM.DataSource = ds.Tables[0];
                    gvGrossblockPandM.DataBind();
                }
                else
                {
                    gvGrossblockPandM.DataSource = ds.Tables[0];
                    gvGrossblockPandM.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetGrossBlockPandM(int GBId, int IncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@GBId",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = GBId;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_PM_GROSSBLOCK_DTLS", pp);
            return Dsnew;
        }
        public void ClearControlsGrossBlock()
        {
            ViewState["GBId"] = null;
            txtAuditedBalanceYear.Text = "";
            txtAmountGrossBlock.Text = "";
            txtCertifiedBy.Text = "";
            txtCertifiedDate.Text = "";
            HyGrossBlock.NavigateUrl = "";
            HyGrossBlock.Visible = false;
            HyGrossBlock.Text = "";
        }
        public DataSet GetPMForPaymentProofs(int IncentiveId, int TypeOfIndustry, string TransType)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@TypeOfIndustry",SqlDbType.Int),
               new SqlParameter("@TransType",SqlDbType.VarChar),
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = TypeOfIndustry;
            pp[2].Value = TransType;

            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_PM_PAYMENT_DTLS", pp);
            return Dsnew;
        }
        public DataSet GetPMTransactionDtls(int IncentiveId, int TypeOfIndustry, string TransType)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@TypeOfIndustry",SqlDbType.Int),
               new SqlParameter("@TransType",SqlDbType.VarChar),
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = TypeOfIndustry;
            pp[2].Value = TransType;

            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_PM_TRANSACTION_IDS", pp);
            return Dsnew;
        }
        public void AddNewTransaction(DropDownList ddl)
        {
            try
            {
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "S";
                ddl.Items.Insert(0, li);

                ListItem li1 = new ListItem();
                li1.Text = "Add New Transaction";
                li1.Value = "0";
                ddl.Items.Insert(1, li1);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }
        }
        public void BindPMTransactionDtls(int IncentiveId, int TypeOfIndustry, string TransType)
        {
            ViewState["PMTransactionDtls"] = null;
            try
            {
                ddlPMTrnsactionIDPayment.Items.Clear();
                DataSet dsdorg = new DataSet();
                dsdorg = GetPMTransactionDtls(IncentiveId, TypeOfIndustry, TransType);
                if (dsdorg != null && dsdorg.Tables.Count > 0 && dsdorg.Tables[0].Rows.Count > 0)
                {
                    ddlPMTrnsactionIDPayment.DataSource = dsdorg.Tables[0];
                    ddlPMTrnsactionIDPayment.DataValueField = "PMPFId";
                    ddlPMTrnsactionIDPayment.DataTextField = "TransactionId";
                    ddlPMTrnsactionIDPayment.DataBind();
                    AddNewTransaction(ddlPMTrnsactionIDPayment);
                    divRegistredTrnsactionID.Visible = true;
                    divRegistredTrnsactionID1.Visible = true;
                    divRegistredTrnsactionID2.Visible = true;
                    FUPMPaymentProof.Visible = false;
                    ViewState["PMTransactionDtls"] = dsdorg;
                }
                else
                {
                    FUPMPaymentProof.Visible = true;
                    divRegistredTrnsactionID.Visible = false;
                    divRegistredTrnsactionID1.Visible = false;
                    divRegistredTrnsactionID2.Visible = false;
                    AddNewTransaction(ddlPMTrnsactionIDPayment);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindPMForPaymentProofs(int IncentiveId, int TypeOfIndustry, string TransType)
        {
            ViewState["PMForPaymentProofs"] = null;
            ddlPlantMachinaryPayment.Items.Clear();
            try
            {
                DataSet dsdorg = new DataSet();
                dsdorg = GetPMForPaymentProofs(IncentiveId, TypeOfIndustry, TransType);
                if (dsdorg != null && dsdorg.Tables.Count > 0 && dsdorg.Tables[0].Rows.Count > 0)
                {
                    ddlPlantMachinaryPayment.DataSource = dsdorg.Tables[0];
                    ddlPlantMachinaryPayment.DataValueField = "PMId";
                    ddlPlantMachinaryPayment.DataTextField = "MachineName";
                    ddlPlantMachinaryPayment.DataBind();
                    AddSelect(ddlPlantMachinaryPayment);
                    ViewState["PMForPaymentProofs"] = dsdorg;
                    EnablePMTransactiondtls();
                }
                else
                {
                    AddSelect(ddlPlantMachinaryPayment);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ValidatePMPaymentproof()
        {
            string CertifiedDate = "";

            int slno = 1;
            string ErrorMsg = "";
            if (ddlPlantMachinaryPayment.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Plant & Machinary\\n";
                slno = slno + 1;
            }
            if (divRegistredTrnsactionID.Visible == true && ddlPMTrnsactionIDPayment.SelectedValue == "S")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Transaction Id for Mapping Machinary\\n";
                slno = slno + 1;
            }
            if (txtTrnsactionID.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Trnsaction ID\\n";
                slno = slno + 1;
            }
            if (txtPMPaymentTrnsactionDate.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Trnsaction Date\\n";
                slno = slno + 1;
            }
            else
            {
                CertifiedDate = GetFromatedDateDDMMYYYY(txtPMPaymentTrnsactionDate.Text.TrimStart().TrimEnd().Trim());
                string Msg = CheckFuturedate(CertifiedDate, "Trnsaction Date");
                if (Msg != "")
                {
                    ErrorMsg = ErrorMsg + slno + ". " + Msg;
                }
            }
            if (txtremittingbank.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Remitting bank\\n";
                slno = slno + 1;
            }

            if (txtbeneficiarybank.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Beneficiary bank\\n";
                slno = slno + 1;
            }
            if (txtPmtransactionAmount.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Trnsaction Amount (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtPMMachinaryCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Cost of Machinary Included in the selected transaction amount Amount (In Rs)\\n";
                slno = slno + 1;
            }
            else
            {
                decimal PMMachinaryCost = Convert.ToDecimal(txtPMMachinaryCost.Text.TrimStart().TrimEnd().Trim());


                decimal YetPMCostUpdate = Convert.ToDecimal(ViewState["YetPMCostUpdate"].ToString());
                decimal PendingTransactionAmount = 0;
                if (divRegistredTrnsactionID.Visible && ddlPMTrnsactionIDPayment.SelectedValue != "0" && ddlPMTrnsactionIDPayment.SelectedValue != "S")
                {
                    PendingTransactionAmount = Convert.ToDecimal(ViewState["PendingTransactionAmount"].ToString());
                }
                else
                {
                    PendingTransactionAmount = Convert.ToDecimal(txtPmtransactionAmount.Text.TrimStart().TrimEnd().Trim());
                }

                if (YetPMCostUpdate < PMMachinaryCost)
                {
                    ErrorMsg = ErrorMsg + slno + ". The Machinary transaction amount sholud not exceed the original machinary cost\\n";
                    slno = slno + 1;
                }
                else if (PendingTransactionAmount < PMMachinaryCost)
                {
                    ErrorMsg = ErrorMsg + slno + ". The Pending Transaction Amount " + PendingTransactionAmount + " sholud not exceed the Machinary Transaction Amount\\n";
                    slno = slno + 1;
                }
            }
            if (!FUPMPaymentProof.HasFile && HypmPaymentProof.NavigateUrl == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Upload Payment Proof (Pdf Only)" + "\\n";
                slno = slno + 1;
            }
            else if (FUPMPaymentProof.HasFile)
            {
                string Mimetype = objClsFileUpload.getmimetype(FUPMPaymentProof);
                if (Mimetype != "application/pdf")
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Upload Pdf Files Only" + "\\n";
                    slno = slno + 1;
                }
            }

            return ErrorMsg;
        }
        protected void btnpmpaymentAdd_Click(object sender, EventArgs e)
        {
            string errormsg = ValidatePMPaymentproof();
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

                PMPaymentProofs pm = new PMPaymentProofs();
                if (ViewState["PMPFId"] != null && ViewState["PMPFId"].ToString() != "")
                    pm.PMPFId = Convert.ToInt32(ViewState["PMPFId"].ToString());
                else
                    pm.PMPFId = 0;

                if (ViewState["PMTMId"] != null && ViewState["PMTMId"].ToString() != "")
                    pm.PMTMId = Convert.ToInt32(ViewState["PMTMId"].ToString());
                else
                    pm.PMTMId = 0;

                pm.Created_by = ObjLoginNewvo.uid;
                pm.TransType = "INS";
                pm.Industry_Type = "1";
                pm.IncentiveID = Convert.ToInt32(Session["IncentiveID"].ToString());

                pm.PMId = Convert.ToInt32(ddlPlantMachinaryPayment.SelectedValue);
                if (divRegistredTrnsactionID.Visible == true && ddlPMTrnsactionIDPayment.SelectedValue != "S" && ddlPMTrnsactionIDPayment.SelectedValue != "0")
                {
                    pm.PMRegTrnsactionID = Convert.ToInt32(ddlPMTrnsactionIDPayment.SelectedValue);
                }
                pm.PMTrnsactionID = txtTrnsactionID.Text.Trim().TrimStart().ToUpper();
                pm.TrnsactionDate = GetFromatedDateDDMMYYYY(txtPMPaymentTrnsactionDate.Text.Trim().TrimStart());

                pm.Remittingbank = txtremittingbank.Text.Trim().TrimStart();
                pm.Beneficiarybank = txtbeneficiarybank.Text.Trim().TrimStart();
                pm.TrnsactionAmount = GetDecimalNullValue(txtPmtransactionAmount.Text.Trim().TrimStart());
                pm.PMTrnsactionMachinaryCost = GetDecimalNullValue(txtPMMachinaryCost.Text.Trim().TrimStart());

                HyperLink hyperLinkNew1 = new HyperLink();
                if (FUPMPaymentProof.HasFile)
                {
                    string OutPut = objClsFileUpload.IncentiveFileUploadingPM("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), FUPMPaymentProof, hyperLinkNew1, "CAFUploads", Session["IncentiveID"].ToString(), "8", "51", Session["uid"].ToString(), "USER");
                    pm.AttachmentId = OutPut;
                }

                string DbErrorMsg = "";
                int result = ObjCAFClass.InsertPMPaymentDetails(pm, out DbErrorMsg);
                if (result > 0 && DbErrorMsg == "")
                {
                    //Add to Grid Method
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Updated Successfully');", true);
                    BindPMForPaymentProofs(Convert.ToInt32(Session["IncentiveID"].ToString()), Convert.ToInt32(ddlIndustryStatus.SelectedValue), "1");
                    BindPMTransactionDtls(Convert.ToInt32(Session["IncentiveID"].ToString()), Convert.ToInt32(ddlIndustryStatus.SelectedValue), "1");
                    BindPMPaymentDtls(Session["IncentiveID"].ToString(), "1");
                    ClearPMTransactiondtls();
                    btnpmpaymentAdd.Text = "Add New";
                }
                else
                {
                    if (DbErrorMsg.Trim().TrimStart() != "")
                    {
                        string dbmessage = "alert('" + DbErrorMsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", dbmessage, true);
                        return;
                    }
                }
            }
        }

        protected void btnpmpaymentclear_Click(object sender, EventArgs e)
        {
            ClearPMTransactiondtls();
        }

        public void ClearPMTransactiondtls()
        {
            ViewState["PMPFId"] = "";
            ViewState["PMTMId"] = "";
            ViewState["PendingTransactionAmount"] = "";
            ViewState["YetPMCostUpdate"] = "";

            ddlPlantMachinaryPayment.SelectedIndex = -1;
            ddlPMTrnsactionIDPayment.SelectedIndex = -1;
            txtTrnsactionID.Text = "";
            txtPMPaymentTrnsactionDate.Text = "";
            txtremittingbank.Text = "";
            txtbeneficiarybank.Text = "";
            txtPmtransactionAmount.Text = "";
            txtPMMachinaryCost.Text = "";

            lblPMMachinaryCost.InnerHtml = "";
            lblPMCostUpdated.InnerHtml = "";
            lblYetPMCostUpdate.InnerHtml = "";
            lblUsedTransactionAmount.InnerHtml = "";
            lblPendingTransactionAmount.InnerHtml = "";
            HypmPaymentProof.Text = "";
            HypmPaymentProof.NavigateUrl = "";
        }

        public void EnablePMTransactiondtls()
        {
            divPMPaymentDetails1.Visible = true;
            ddlPlantMachinaryPayment.Enabled = true;
            ddlPMTrnsactionIDPayment.Enabled = true;
            txtTrnsactionID.Enabled = true;
            txtPMPaymentTrnsactionDate.Enabled = true;
            txtremittingbank.Enabled = true;
            txtbeneficiarybank.Enabled = true;
            txtPmtransactionAmount.Enabled = true;
            txtPMMachinaryCost.Enabled = true;
            GvPMPaymentDtls.Columns[11].Visible = true;
        }

        protected void ddlPlantMachinaryPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = (DataSet)ViewState["PMForPaymentProofs"];
            DataRow[] drs = ds.Tables[0].Select("PMId = " + ddlPlantMachinaryPayment.SelectedValue);
            if (drs.Length > 0)
            {
                lblPMMachinaryCost.InnerHtml = drs[0]["MachineCost"].ToString();
                lblPMCostUpdated.InnerHtml = drs[0]["MachineCostPaid"].ToString();
                lblYetPMCostUpdate.InnerHtml = drs[0]["BalanceMachineCost"].ToString();

                ViewState["YetPMCostUpdate"] = drs[0]["BalanceMachineCost"].ToString();
            }
        }

        protected void ddlPMTrnsactionIDPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (ddlPMTrnsactionIDPayment.SelectedValue != "0" && ddlPMTrnsactionIDPayment.SelectedValue != "S")
            {
                ds = (DataSet)ViewState["PMTransactionDtls"];
                DataRow[] drs = ds.Tables[0].Select("PMPFId = " + ddlPMTrnsactionIDPayment.SelectedValue);
                if (drs.Length > 0)
                {
                    txtTrnsactionID.Text = drs[0]["PMTrnsactionID"].ToString();
                    txtPMPaymentTrnsactionDate.Text = drs[0]["TrnsactionDate"].ToString();
                    txtremittingbank.Text = drs[0]["Remittingbank"].ToString();
                    txtbeneficiarybank.Text = drs[0]["Beneficiarybank"].ToString();
                    txtPmtransactionAmount.Text = drs[0]["TrnsactionAmount"].ToString();
                    HypmPaymentProof.NavigateUrl = drs[0]["ProofLink"].ToString();
                    HypmPaymentProof.Text = "View";
                    lblUsedTransactionAmount.InnerHtml = drs[0]["UtilisedCost"].ToString();
                    lblPendingTransactionAmount.InnerHtml = drs[0]["RemainingCost"].ToString();

                    ViewState["PendingTransactionAmount"] = drs[0]["RemainingCost"].ToString();

                    HypmPaymentProof.Visible = true;
                    txtTrnsactionID.Enabled = false;
                    txtPMPaymentTrnsactionDate.Enabled = false;
                    txtremittingbank.Enabled = false;
                    txtbeneficiarybank.Enabled = false;
                    txtPmtransactionAmount.Enabled = false;
                    FUPMPaymentProof.Visible = false;
                }
            }
            else
            {
                HypmPaymentProof.NavigateUrl = "";
                HypmPaymentProof.Visible = false;
                txtTrnsactionID.Enabled = true;
                txtPMPaymentTrnsactionDate.Enabled = true;
                txtremittingbank.Enabled = true;
                txtbeneficiarybank.Enabled = true;
                txtPmtransactionAmount.Enabled = true;
                FUPMPaymentProof.Visible = true;
                txtTrnsactionID.Text = "";
                txtPMPaymentTrnsactionDate.Text = "";
                txtremittingbank.Text = "";
                txtbeneficiarybank.Text = "";
                txtPmtransactionAmount.Text = "";
                txtPMMachinaryCost.Text = "";
            }
        }

        public DataSet GetPMPaymentDtls(string INCENTIVEID, string TransType)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar),
               new SqlParameter("@TransType",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            pp[1].Value = TransType;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_PMPAYMENT_DTLS", pp);
            return Dsnew;
        }

        public DataSet GetCheckPMPaymentMapping(string INCENTIVEID, string TransType)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar),
               new SqlParameter("@TransType",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            pp[1].Value = TransType;
            Dsnew = ObjCAFClass.GenericFillDs("USP_CHECK_PMPAYMENT_MAPPING", pp);
            return Dsnew;
        }
        public DataSet GetCheckPMPaymentMapping_ExistingUnit(string INCENTIVEID, string TransType)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar),
               new SqlParameter("@TransType",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            pp[1].Value = TransType;
            Dsnew = ObjCAFClass.GenericFillDs("USP_CHECK_PMPAYMENT_MAPPING_EXISTING", pp);
            return Dsnew;
        }

        protected void BindPMPaymentDtls(string INCENTIVEID, string TransType)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetPMPaymentDtls(INCENTIVEID, TransType);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    GvPMPaymentDtls.DataSource = dsnew.Tables[0];
                    GvPMPaymentDtls.DataBind();
                }
                else
                {
                    GvPMPaymentDtls.DataSource = null;
                    GvPMPaymentDtls.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GvPMPaymentDtls_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "RowDdelete")
            {

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];


                PMPaymentProofs pm = new PMPaymentProofs();

                pm.PMTMId = Convert.ToInt32(((Label)(gr.FindControl("lblPMTMIdNew"))).Text);
                pm.PMPFId = Convert.ToInt32(((Label)(gr.FindControl("lblPMPFIdNew"))).Text);

                pm.TransType = "DLT";
                pm.IncentiveID = Convert.ToInt32(Session["IncentiveID"].ToString());
                pm.Created_by = ObjLoginNewvo.uid;


                string DbErrorMsg = "";
                int result = ObjCAFClass.InsertPMPaymentDetails(pm, out DbErrorMsg);
                if (result > 0 && DbErrorMsg == "")
                {
                    //Add to Grid Method
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Updated Successfully');", true);
                    BindPMForPaymentProofs(Convert.ToInt32(Session["IncentiveID"].ToString()), Convert.ToInt32(ddlIndustryStatus.SelectedValue), "1");
                    BindPMTransactionDtls(Convert.ToInt32(Session["IncentiveID"].ToString()), Convert.ToInt32(ddlIndustryStatus.SelectedValue), "1");
                    BindPMPaymentDtls(Session["IncentiveID"].ToString(), "1");
                    ClearPMTransactiondtls();
                    btnpmpaymentAdd.Text = "Add New";
                }
                else
                {
                    if (DbErrorMsg.Trim().TrimStart() != "")
                    {
                        string dbmessage = "alert('" + DbErrorMsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", dbmessage, true);
                        return;
                    }
                }
            }
        }
        protected void chkApproveCost_CheckedChanged(object sender, EventArgs e)
        {
            if (chkApproveCost.Checked == true)
            {
                if (ddlIndustryStatus.SelectedValue == "1")
                {
                    txtlandexisting.Enabled = true;
                    txtlandcapacity.Enabled = true;
                    txtbuildingexisting.Enabled = true;
                }
                txtbuildingcapacity.Enabled = true;
                txtplantexisting.Enabled = true;
                txtplantcapacity.Enabled = true;
            }
            else
            {
                txtlandexisting.Enabled = false;
                txtlandcapacity.Enabled = false;
                txtbuildingexisting.Enabled = false;
                txtbuildingcapacity.Enabled = false;
                txtplantexisting.Enabled = false;
                txtplantcapacity.Enabled = false;
            }
        }
        protected void btnShowPlantMachine_Click(object sender, EventArgs e)
        {
            hdnShowGrid.Value = "Y";
            BindPandMGrid(0, Convert.ToInt32(Session["IncentiveID"].ToString()));
            btnShowPlantMachine.Visible = false;
            A2.Visible = true;
        }
        protected void btnShowPayments_Click(object sender, EventArgs e)
        {
            BindPMPaymentDtls(Session["IncentiveID"].ToString(), "1");
            btnShowPayments.Visible = false;
        }
       /* public override void VerifyRenderingInServerForm(Control control)
        {
             
        }*/
        protected void BtnExportExcel_Click(object sender, EventArgs e)
        {
            ExportGridToExcel();
        }
        protected void Cost_TextChanged(object sender, EventArgs e)
        {
            Double ActualMachineCost = 0, FreightCharges = 0, TransportCharges = 0, Cgst = 0, Sgst = 0, Igst = 0;
            ActualMachineCost= Convert.ToDouble(GetDecimalNullValue(txtActMachineCost.Text.TrimStart().TrimEnd()));
            FreightCharges = Convert.ToDouble(GetDecimalNullValue(txtFreightCharges.Text.TrimStart().TrimEnd()));
            TransportCharges = Convert.ToDouble(GetDecimalNullValue(txtTransportCharges.Text.TrimStart().TrimEnd()));
            Cgst = Convert.ToDouble(GetDecimalNullValue(txtcgst.Text.TrimStart().TrimEnd()));
            Sgst = Convert.ToDouble(GetDecimalNullValue(txtsgst.Text.TrimStart().TrimEnd()));
            Igst = Convert.ToDouble(GetDecimalNullValue(txtigst.Text.TrimStart().TrimEnd()));

            txttotalGst.Text = (Cgst + Sgst + Igst).ToString();
            txtCostofMachine.Text = (ActualMachineCost + FreightCharges + TransportCharges + Cgst + Sgst + Igst).ToString();
        }
        private void ExportGridToExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "PlantandMachineryList.xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            grdPandM.GridLines = GridLines.Both;
            grdPandM.HeaderStyle.Font.Bold = true;
            grdPandM.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }

        protected void btnSendOTP_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtVerifiedMobile.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please enter Valid Mobile Number');", true);
                    return;
                }
                Random oRandom = new Random();
                int noOfChar = 6;
                string strOTPMobile = string.Empty;

                char[] charArr = "0123456789".ToCharArray();

                for (int cnt = 0; cnt < noOfChar; cnt++)
                {
                    int OTPNo = oRandom.Next(1, charArr.Length);
                    if (!strOTPMobile.Contains(charArr.GetValue(OTPNo).ToString()))
                    {
                        strOTPMobile += charArr.GetValue(OTPNo);
                    }
                    else
                    {
                        cnt--;
                    }
                }
                string MobileNo = txtVerifiedMobile.Text.Trim();
                string Responce = ClsSMSandMailobj.SendSmsWebService(strOTPMobile, MobileNo, "Incentives", "17", "OTP");
                ViewState["OTP"] = strOTPMobile;
                if (Responce.Contains("SUCCESS"))
                {
                    btnSendOTP.Text = "Resend OTP";
                    txtOTP.Enabled = true;
                    divVerifyOtpBtn.Visible = true;
                    ClsSMSandMailobj.SaveOTPDetails(MobileNo, strOTPMobile, "Incentives", "MobileNumberVerification", "WEB");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error Occured');", true);
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void btnVerifyOTP_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtOTP.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error Occured');", true);
                return;
            }
            else if (txtOTP.Text.Trim().TrimStart() != ViewState["OTP"].ToString())
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please Enter Valid OTP');", true);
                return;
            }
            else
            {
                lblOTPVerified.InnerText = "Mobile Number Verified";
                hdnVerified.Value = "Y";
                divOTPTBox.Visible = false;
                divVerifiedLabel.Visible = true;
                divVerifyOtpBtn.Visible = false;
                btnVerifyOTP.Enabled = false;
                divSendOTPBtn.Visible = false;
                txtMobileNumberAuthorised.Text = txtVerifiedMobile.Text;
                txtMobileNumberAuthorised.Enabled = false;
            }
        }

        protected void txtMobileNumberAuthorised_TextChanged(object sender, EventArgs e)
        {
            txtVerifiedMobile.Text = txtMobileNumberAuthorised.Text;
        }

        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBank.SelectedValue == "999") { divBankName.Visible = true; }
        }

        protected void ddltermloanbank_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtInstitution.Text = "";
            if (ddltermloanbank.SelectedValue == "999")
            {
                divBankName1.Visible = true;
            }
            else 
            {
                txtInstitution.Text = ddltermloanbank.SelectedItem.Text.ToString();
            }
        }
    }
}