﻿using System;
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
    public partial class frmLandBuildingPMDetails : System.Web.UI.Page
    {
        General Gen = new General();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        CAFClass caf = new CAFClass();
        CAFClass ObjCAFClass = new CAFClass();
        string CheckEditCivilWorks = "N";
        string UId__No = "";

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
                        if (Session["uid"] != null)
                        {
                            string userid = Session["uid"].ToString();
                            DataSet dsnew = new DataSet();
                            BindEligibility();
                            BindForeignCurrency();
                            BindControls();
                            if (rdl_Buliding_Type.SelectedIndex == -1)
                            {
                                rdl_Buliding_Type.Enabled = true;
                                btnSave.Enabled = true;
                            }

                            if (grdPandM.Rows.Count > 0)
                            {
                                foreach (GridViewRow gvr in grdPandM.Rows)
                                {
                                    string filaname = ((HyperLink)gvr.FindControl("hyFilePathMerge2")).NavigateUrl.ToString();
                                    if (filaname == "")
                                    {
                                        grdPandM.Columns[27].Visible = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect("~/LoginReg.aspx");
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
            Dsnew = caf.GenericFillDs("USP_GET_INCENTIVES_CAF_DATA", pp);
            return Dsnew;
        }

        public void BindControls()
        {
            string TypeOfIndustry = "";
            DataSet dsnew = new DataSet();
            dsnew = GetapplicationDtls(Session["uid"].ToString(), Session["IncentiveID"].ToString());
            if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
            {
                hdnUIDNo.Value = dsnew.Tables[0].Rows[0]["Uid_NO"].ToString();
                TypeOfIndustry = dsnew.Tables[0].Rows[0]["TypeOfIndustry"].ToString();
                if (TypeOfIndustry == "1")
                {
                    divNewIndustry.Visible = true;
                    card.Visible = false;
                    divPMPaymentDetails.Visible = false;
                }
                else
                {
                    divExpIndustry.Visible = true;
                    card.Visible = true;
                    divPMPaymentDetails.Visible = true;
                }

                ViewState["DCPdate"] = "";
                if (dsnew.Tables[0].Rows[0]["Category"].ToString() != "")
                {
                    ViewState["CategoryofUnit"] = dsnew.Tables[0].Rows[0]["Category"].ToString();
                }
                else if (Session["SCategoryofUnit"] != null)
                {
                    ViewState["CategoryofUnit"] = Session["SCategoryofUnit"].ToString();
                }


                ViewState["TypeofApplicant"] = dsnew.Tables[0].Rows[0]["TypeOfIndustryText"].ToString();

                if (TypeOfIndustry == "1")
                {
                    ViewState["DCPdate"] = dsnew.Tables[0].Rows[0]["DCP"].ToString();
                }
                else
                {
                    ViewState["DCPdate"] = dsnew.Tables[0].Rows[0]["DCPExp"].ToString();
                }

                ViewState["TypeOfIndustry"] = TypeOfIndustry;

                string ENABLINGCONTRILS = dsnew.Tables[0].Rows[0]["ENABLINGCONTRILS"].ToString();
                if ((dsnew.Tables[0].Rows[0]["intStatusid"].ToString() == null || dsnew.Tables[0].Rows[0]["intStatusid"].ToString() == "") && ENABLINGCONTRILS == "N")
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
                        btnSave.Enabled = false;

                        grdPandM.Columns[28].Visible = false;
                        grdPandM.Columns[27].Visible = false;

                        GvPMPaymentDtls.Columns[11].Visible = false;
                    }
                    else
                    {
                        EnableDisableForm(Page.Controls, true);
                    }
                }
                
            }
            BindPandMGrid(0, Convert.ToInt32(Session["IncentiveID"].ToString()));
            DataSet dsData = new DataSet();
            dsData = GetCAFNewUnitData(Session["uid"].ToString(), Convert.ToInt32(Session["IncentiveID"].ToString()), TypeOfIndustry);
            if (dsData.Tables.Count > 0)
            {
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    //Bind Controls
                    //rdl_TypeofUnit.SelectedValue = dsData.Tables[0].Rows[0]["TypeofUnit"].ToString();

                    txtPLExtent.Text = dsData.Tables[0].Rows[0]["PurchasedLandExtent"].ToString();
                    txtPLValue.Text = dsData.Tables[0].Rows[0]["PurchasedLandValue"].ToString();
                    txtLLExtent.Text = dsData.Tables[0].Rows[0]["LeasedLandExtent"].ToString();
                    txtLLValue.Text = dsData.Tables[0].Rows[0]["LeasedLandValue"].ToString();
                    txtILExtent.Text = dsData.Tables[0].Rows[0]["InheritedLandExtent"].ToString();
                    txtILValue.Text = dsData.Tables[0].Rows[0]["InheritedLandValue"].ToString();
                    txtGLExtent.Text = dsData.Tables[0].Rows[0]["GovtLandExtent"].ToString();
                    txtGLValue.Text = dsData.Tables[0].Rows[0]["GovtLandValue"].ToString();

                    BindTotalLandValue("1");
                    BindTotalLandValue("2");
                    BindTotalLandValue("3");
                    BindTotalLandValue("4");

                    if (dsData.Tables[0].Rows[0]["Buliding_Type"].ToString() != "")
                    {
                        rdl_Buliding_Type.SelectedValue = dsData.Tables[0].Rows[0]["Buliding_Type"].ToString();
                    }

                    txtMFSArea.Text = dsData.Tables[0].Rows[0]["MainFactoryShedArea"].ToString();
                    txtMFSCost.Text = dsData.Tables[0].Rows[0]["MainFactoryShedCost"].ToString();
                    txtWarehouseArea.Text = dsData.Tables[0].Rows[0]["WarehouseArea"].ToString();
                    txtWarehouseCost.Text = dsData.Tables[0].Rows[0]["WarehouseCost"].ToString();
                    txtOfficeArea.Text = dsData.Tables[0].Rows[0]["OfficeRoomArea"].ToString();
                    txtOfficeCost.Text = dsData.Tables[0].Rows[0]["OfficeRoomCost"].ToString();
                    txtCWPArea.Text = dsData.Tables[0].Rows[0]["CoolingPondsArea"].ToString();
                    txtCWPCost.Text = dsData.Tables[0].Rows[0]["CoolingPondsCost"].ToString();
                    txtBoilerArea.Text = dsData.Tables[0].Rows[0]["BoilerShedArea"].ToString();
                    txtBoilerCost.Text = dsData.Tables[0].Rows[0]["BoilerShedCost"].ToString();
                    txtETPArea.Text = dsData.Tables[0].Rows[0]["EffluentPondsArea"].ToString();
                    txtETPCost.Text = dsData.Tables[0].Rows[0]["EffluentPondsCost"].ToString();
                    txtOTArea.Text = dsData.Tables[0].Rows[0]["OverHeadTankArea"].ToString();
                    txtOTACost.Text = dsData.Tables[0].Rows[0]["OverHeadTankCost"].ToString();
                    txtFGArea.Text = dsData.Tables[0].Rows[0]["FencingArea"].ToString();
                    txtFGCost.Text = dsData.Tables[0].Rows[0]["FencingCost"].ToString();
                    txtAFArea.Text = dsData.Tables[0].Rows[0]["ArchitectFeeArea"].ToString();
                    txtAFCost.Text = dsData.Tables[0].Rows[0]["ArchitectFeeCost"].ToString();
                    txtCWArea.Text = dsData.Tables[0].Rows[0]["CompoundWallArea"].ToString();
                    txtCWCost.Text = dsData.Tables[0].Rows[0]["CompoundWallCost"].ToString();
                    txtWQArea.Text = dsData.Tables[0].Rows[0]["WorksersHouseArea"].ToString();
                    txtWQCost.Text = dsData.Tables[0].Rows[0]["WorkersHouseCost"].ToString();
                    txtCanteenArea.Text = dsData.Tables[0].Rows[0]["CanteenArea"].ToString();
                    txtCanteenCost.Text = dsData.Tables[0].Rows[0]["CanteenCost"].ToString();
                    txtRHArea.Text = dsData.Tables[0].Rows[0]["RestHouseArea"].ToString();
                    txtRHCost.Text = dsData.Tables[0].Rows[0]["RestHouseCost"].ToString();
                    txtTOArea.Text = dsData.Tables[0].Rows[0]["TimeOfficeArea"].ToString();
                    txtTOCost.Text = dsData.Tables[0].Rows[0]["TimeOfficeCost"].ToString();
                    txtCSArea.Text = dsData.Tables[0].Rows[0]["VehicleStandArea"].ToString();
                    txtCSCost.Text = dsData.Tables[0].Rows[0]["VehicleStandCost"].ToString();
                    txtSSArea.Text = dsData.Tables[0].Rows[0]["SecurityShedArea"].ToString();
                    txtSSCost.Text = dsData.Tables[0].Rows[0]["SecurityShedCost"].ToString();
                    txtToiletArea.Text = dsData.Tables[0].Rows[0]["ToiletArea"].ToString();
                    txtToiletCost.Text = dsData.Tables[0].Rows[0]["ToiletCost"].ToString();
                    txtRoadsArea.Text = dsData.Tables[0].Rows[0]["RoadsArea"].ToString();
                    txtRoadsCost.Text = dsData.Tables[0].Rows[0]["RoadsCost"].ToString();
                    if (TypeOfIndustry == "1")
                    {
                        txtLaboratoriesforResearchQualityControl.Text = dsData.Tables[0].Rows[0]["LaboratoriesforResearchQualityControl"].ToString();
                        txtUtilitiesPowerWater.Text = dsData.Tables[0].Rows[0]["UtilitiesPowerWater"].ToString();
                        txtOtherFixedAssets.Text = dsData.Tables[0].Rows[0]["OtherFixedAssets"].ToString();
                        // txtTotal.Text = dsData.Tables[0].Rows[0]["Total"].ToString();

                        txtLaboratoriesforResearchQualityControl_TextChanged(this, EventArgs.Empty);
                    }
                    else
                    {
                        txtNewTechnologiesfortextileprocessing.Text = dsData.Tables[0].Rows[0]["NewTechnologiesfortextileprocessing"].ToString();
                    }
                }
                else
                {
                    EnableDisableForm(Page.Controls, true);
                }
            }
            else
            {
                EnableDisableForm(Page.Controls, true);
            }

            BindPMForPaymentProofs(Convert.ToInt32(Session["IncentiveID"].ToString()), Convert.ToInt32(2), "2");
            BindPMTransactionDtls(Convert.ToInt32(Session["IncentiveID"].ToString()), Convert.ToInt32(2), "2");
            BindPMPaymentDtls(Session["IncentiveID"].ToString(),"2");
            if (Request.QueryString.Count > 0 && Request.QueryString["IsAllowEdit"] == "Y")
            {
                EnableDisableForm(DivPMDtls.Controls, true);
                EnableDisableForm(divPMPaymentDetails.Controls, true);
                grdPandM.Columns[28].Visible = true;
                grdPandM.Columns[27].Visible = true;
                GvPMPaymentDtls.Columns[11].Visible = true;
                btnSave.Enabled = true;
                CheckEditCivilWorks = ObjCAFClass.Check_Applicant_Is_Eligible_Edit_Civil_Works(Session["IncentiveID"].ToString());
                if (CheckEditCivilWorks == "Y")
                {
                    EnableDisableForm(Div1.Controls, true);
                    EnableDisableForm(Div2.Controls, true);
                    EnableDisableForm(divNewIndustry.Controls, true);
                }
            }
        }

        public DataSet GetCAFNewUnitData(string UserId, int IncentiveId, string TypeOfIndustry)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UserId",SqlDbType.NVarChar),
               new SqlParameter("@IncentiveId",SqlDbType.Int)
           };
            pp[0].Value = UserId;
            pp[1].Value = IncentiveId;
            if (TypeOfIndustry == "1")
                Dsnew = caf.GenericFillDs("USP_GET_INCENTIVE_CAF_NEWUNIT", pp);
            else
                Dsnew = caf.GenericFillDs("USP_GET_CAPITAL_ASSISTANCE_EXISTINGUNIT", pp);
            return Dsnew;
        }

        public void BindTotalLandValue(string LandTypeSlno)
        {
            Double Extent = 0, LandValue = 0;
            if (LandTypeSlno == "1")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(txtPLExtent.Text.TrimStart().TrimEnd()));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtPLValue.Text.TrimStart().TrimEnd()));

                lblPLTotalValue.Text = (Extent * LandValue).ToString();
            }
            else if (LandTypeSlno == "2")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(txtLLExtent.Text.TrimStart().TrimEnd()));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtLLValue.Text.TrimStart().TrimEnd()));

                lblLLTotalValue.Text = (Extent * LandValue).ToString();
            }
            else if (LandTypeSlno == "3")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(txtILExtent.Text.TrimStart().TrimEnd()));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtILValue.Text.TrimStart().TrimEnd()));

                lblILTotalValue.Text = (Extent * LandValue).ToString();
            }
            else if (LandTypeSlno == "4")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(txtGLExtent.Text.TrimStart().TrimEnd()));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtGLValue.Text.TrimStart().TrimEnd()));

                lblGLTotalValue.Text = (Extent * LandValue).ToString();
            }
        }

        protected void txtPLExtent_TextChanged(object sender, EventArgs e)
        {
            BindTotalLandValue("1");
        }

        protected void txtPLValue_TextChanged(object sender, EventArgs e)
        {
            BindTotalLandValue("1");
        }

        protected void txtLLExtent_TextChanged(object sender, EventArgs e)
        {
            BindTotalLandValue("2");
        }

        protected void txtLLValue_TextChanged(object sender, EventArgs e)
        {
            BindTotalLandValue("2");
        }

        protected void txtILExtent_TextChanged(object sender, EventArgs e)
        {
            BindTotalLandValue("3");
        }

        protected void txtILValue_TextChanged(object sender, EventArgs e)
        {
            BindTotalLandValue("3");
        }

        protected void txtGLExtent_TextChanged(object sender, EventArgs e)
        {
            BindTotalLandValue("4");
        }

        protected void txtGLValue_TextChanged(object sender, EventArgs e)
        {
            BindTotalLandValue("4");
        }

        protected void txtLaboratoriesforResearchQualityControl_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = (Convert.ToDecimal(GetDecimalNullValue(txtLaboratoriesforResearchQualityControl.Text)) +
            Convert.ToDecimal(GetDecimalNullValue(txtUtilitiesPowerWater.Text)) +
                Convert.ToDecimal(GetDecimalNullValue(txtOtherFixedAssets.Text))).ToString();
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

        public string ValidateControls()
        {
            int slno = 1;
            string ErrorMsg = "";
            if (txtPLExtent.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Purchased Land Extent\\n";
                slno = slno + 1;
            }
            if (txtPLValue.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Purchased Land Value\\n";
                slno = slno + 1;
            }
            if (txtLLExtent.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Leased Land Extent\\n";
                slno = slno + 1;
            }
            if (txtLLValue.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Leased Land Value\\n";
                slno = slno + 1;
            }
            if (txtILExtent.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Inhertied Land Extent\\n";
                slno = slno + 1;
            }
            if (rdl_Buliding_Type.SelectedIndex == -1)
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Building Type(Constructed/Leased)\\n";
                slno = slno + 1;
            }
            if (txtILValue.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Inhertied Land Value\\n";
                slno = slno + 1;
            }
            if (txtGLExtent.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Govt Land (TSIIC developed IEs/IDA/Industrial Parks) Extent\\n";
                slno = slno + 1;
            }
            if (txtGLValue.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Govt Land (TSIIC developed IEs/IDA/Industrial Parks) Value\\n";
                slno = slno + 1;
            }
            if (txtMFSArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Main Factory Shed Plinth Area In Square Meters\\n";
                slno = slno + 1;
            }
            if (txtMFSCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Main Factory Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtWarehouseArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Warehouse for Raw Material and finished goods Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtWarehouseCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter  Warehouse for Raw Material and finished goods Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtOfficeArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Office room and Lab room Plinth Area In Square Meters\\n";
                slno = slno + 1;
            }
            if (txtOfficeCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Office room and Lab room Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtCWPArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Cooling water ponds  Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtCWPCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Cooling water ponds Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtBoilerArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Boiler shed and generator room  Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtBoilerCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Boiler shed and generator room Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtETPArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Effluent treatment ponds etc.  Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtETPCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Effluent treatment ponds etc. Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtOTArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Overhead Tank,bore-wells and pump house and sump  Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtOTACost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Overhead Tank,bore-wells and pump house and sump Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtFGArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Fencing and Gate Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtFGCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Fencing and Gate Cost (In Rs)\\n";
                slno = slno + 1;
            }

            if (txtAFCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Architect fee and supervision charges Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtCWArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Compound wall Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtCWCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Compound wall Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtWQArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Workers Quarters/ workers housing Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtWQCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Workers Quarters/ workers housing Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtCanteenArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Canteen Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtCanteenCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Canteen Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtRHArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Rest House Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtRHCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Rest House Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtTOArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Time Office Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtTOCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Time Office Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtCSArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Cycle/Vehicle Stand Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtCSCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Cycle/Vehicle Stand Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtSSArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Security Shed Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtSSCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Security Shed Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtToiletArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Toilet room and sanitary fittings Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtToiletCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Toilet room and sanitary fittings Cost (In Rs)\\n";
                slno = slno + 1;
            }
            if (txtRoadsArea.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Roads with in factory premises Plinth Area In Square Meters \\n";
                slno = slno + 1;
            }
            if (txtRoadsCost.Text.TrimStart().TrimEnd().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Roads with in factory premises Cost (In Rs)\\n";
                slno = slno + 1;
            }

            string TypeOfIndustry = ViewState["TypeOfIndustry"].ToString();
            if (TypeOfIndustry != "1")
            {
                if (grdPandM.Rows.Count < 1)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Add Plant and Machinary Details\\n";
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
                string Check = ObjCAFClass.Check_ApplicantData(hdnUIDNo.Value.ToString());
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
                dspm = GetCheckPMPaymentMapping(Session["IncentiveID"].ToString(), "2");

                if (dspm.Tables[0].Rows.Count > 0)
                {
                    ErrorMsg = ErrorMsg + slno + ". Please Upload newly added Plant and Machinary Payment Proofs \\n";
                    slno = slno + 1;
                }
            }
            
            return ErrorMsg;
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

        public string GetDecimalNullValue(string Input)
        {
            string InputValue = "";

            InputValue = (Input != "") ? Input : "0";

            return InputValue;
        }

        protected void btnSave_Click(object sender, EventArgs e)
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
                CapitalAssistanceforNewUnit cafnu = new CapitalAssistanceforNewUnit();
                cafnu.UserId = Session["uid"].ToString();
                cafnu.IncentiveID = Convert.ToInt32(Session["IncentiveID"].ToString());

                cafnu.PurchasedLandExtent = Convert.ToDecimal(GetDecimalNullValue(txtPLExtent.Text));
                cafnu.PurchasedLandValue = Convert.ToDecimal(GetDecimalNullValue(txtPLValue.Text));
                cafnu.LeasedLandExtent = Convert.ToDecimal(GetDecimalNullValue(txtLLExtent.Text));
                cafnu.LeasedLandValue = Convert.ToDecimal(GetDecimalNullValue(txtLLValue.Text));

                cafnu.Buliding_Type = rdl_Buliding_Type.SelectedValue;

                cafnu.InheritedLandExtent = Convert.ToDecimal(GetDecimalNullValue(txtILExtent.Text));
                cafnu.InheritedLandValue = Convert.ToDecimal(GetDecimalNullValue(txtILValue.Text));
                cafnu.GovtLandExtent = Convert.ToDecimal(GetDecimalNullValue(txtGLExtent.Text));
                cafnu.GovtLandValue = Convert.ToDecimal(GetDecimalNullValue(txtGLValue.Text));
                cafnu.MainFactoryShedArea = Convert.ToDecimal(GetDecimalNullValue(txtMFSArea.Text));
                cafnu.MainFactoryShedCost = Convert.ToDecimal(GetDecimalNullValue(txtMFSCost.Text));
                cafnu.WarehouseArea = Convert.ToDecimal(GetDecimalNullValue(txtWarehouseArea.Text));
                cafnu.WarehouseCost = Convert.ToDecimal(GetDecimalNullValue(txtWarehouseCost.Text));
                cafnu.OfficeRoomArea = Convert.ToDecimal(GetDecimalNullValue(txtOfficeArea.Text));
                cafnu.OfficeRoomCost = Convert.ToDecimal(GetDecimalNullValue(txtOfficeCost.Text));
                cafnu.CoolingPondsArea = Convert.ToDecimal(GetDecimalNullValue(txtCWPArea.Text));
                cafnu.CoolingPondsCost = Convert.ToDecimal(GetDecimalNullValue(txtCWPCost.Text));
                cafnu.BoilerShedArea = Convert.ToDecimal(GetDecimalNullValue(txtBoilerArea.Text));
                cafnu.BoilerShedCost = Convert.ToDecimal(GetDecimalNullValue(txtBoilerCost.Text));
                cafnu.EffluentPondsArea = Convert.ToDecimal(GetDecimalNullValue(txtETPArea.Text));
                cafnu.EffluentPondsCost = Convert.ToDecimal(GetDecimalNullValue(txtETPCost.Text));
                cafnu.OverHeadTankArea = Convert.ToDecimal(GetDecimalNullValue(txtOTArea.Text));
                cafnu.OverHeadTankCost = Convert.ToDecimal(GetDecimalNullValue(txtOTACost.Text));
                cafnu.FencingArea = Convert.ToDecimal(GetDecimalNullValue(txtFGArea.Text));
                cafnu.FencingCost = Convert.ToDecimal(GetDecimalNullValue(txtFGCost.Text));
                cafnu.ArchitectFeeArea = Convert.ToDecimal(GetDecimalNullValue(txtAFArea.Text));
                cafnu.ArchitectFeeCost = Convert.ToDecimal(GetDecimalNullValue(txtAFCost.Text));
                cafnu.CompoundWallArea = Convert.ToDecimal(GetDecimalNullValue(txtCWArea.Text));
                cafnu.CompoundWallCost = Convert.ToDecimal(GetDecimalNullValue(txtCWCost.Text));
                cafnu.WorksersHouseArea = Convert.ToDecimal(GetDecimalNullValue(txtWQArea.Text));
                cafnu.WorkersHouseCost = Convert.ToDecimal(GetDecimalNullValue(txtWQCost.Text));
                cafnu.CanteenArea = Convert.ToDecimal(GetDecimalNullValue(txtCanteenArea.Text));
                cafnu.CanteenCost = Convert.ToDecimal(GetDecimalNullValue(txtCanteenCost.Text));
                cafnu.RestHouseArea = Convert.ToDecimal(GetDecimalNullValue(txtRHArea.Text));
                cafnu.RestHouseCost = Convert.ToDecimal(GetDecimalNullValue(txtRHCost.Text));
                cafnu.TimeOfficeArea = Convert.ToDecimal(GetDecimalNullValue(txtTOArea.Text));
                cafnu.TimeOfficeCost = Convert.ToDecimal(GetDecimalNullValue(txtTOCost.Text));
                cafnu.VehicleStandArea = Convert.ToDecimal(GetDecimalNullValue(txtCSArea.Text));
                cafnu.VehicleStandCost = Convert.ToDecimal(GetDecimalNullValue(txtCSCost.Text));
                cafnu.SecurityShedArea = Convert.ToDecimal(GetDecimalNullValue(txtSSArea.Text));
                cafnu.SecurityShedCost = Convert.ToDecimal(GetDecimalNullValue(txtSSCost.Text));
                cafnu.ToiletArea = Convert.ToDecimal(GetDecimalNullValue(txtToiletArea.Text));
                cafnu.ToiletCost = Convert.ToDecimal(GetDecimalNullValue(txtToiletCost.Text));
                cafnu.RoadsArea = Convert.ToDecimal(GetDecimalNullValue(txtRoadsArea.Text));
                cafnu.RoadsCost = Convert.ToDecimal(GetDecimalNullValue(txtRoadsCost.Text));


                cafnu.LaboratoriesforResearchQualityControl = GetDecimalNullValue(txtLaboratoriesforResearchQualityControl.Text.Trim().TrimStart());
                cafnu.UtilitiesPowerWater = GetDecimalNullValue(txtUtilitiesPowerWater.Text.Trim().TrimStart());
                cafnu.OtherFixedAssets = GetDecimalNullValue(txtOtherFixedAssets.Text.Trim().TrimStart());
                cafnu.Total = GetDecimalNullValue(txtTotal.Text.Trim().TrimStart());

                cafnu.NewTechnologiesfortextileprocessing = GetDecimalNullValue(txtNewTechnologiesfortextileprocessing.Text.Trim().TrimStart());
                cafnu.SavingFrom = "CAF";

                string Validstatus = "";

                string TypeOfIndustry = ViewState["TypeOfIndustry"].ToString();
                if (TypeOfIndustry == "1")
                {
                    Validstatus = caf.InsertCapitalAssistanceNewUnit(cafnu);
                }
                else
                {
                    Validstatus = caf.InsertCapitalAssistanceExistingUnit(cafnu);
                }

                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    lblmsg.Text = "Details Saved Successfully";
                    lblmsg0.Text = "";
                    success.Visible = true;
                    Failure.Visible = false;
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Details Saved Successfully');", true);
                }
                else
                {
                    lblmsg.Text = "";
                    lblmsg0.Text = "Details Not Saved";
                    success.Visible = false;
                    Failure.Visible = true;
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Details Not Saved');", true);
                }
            }
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
                        if (lblClassificationofMachinery.ToUpper().Contains("TEXTILE PRODUCTS"))
                        {
                            TotalValueofTextileProducts = TotalValueofTextileProducts + Convert.ToDecimal(GetDecimalNullValue(Value));
                        }
                        else if (lblClassificationofMachinery.ToUpper().Contains("NON TEXTILE PRODUCTS"))
                        {
                            TotalValueofNonTextileProducts = TotalValueofNonTextileProducts + Convert.ToDecimal(GetDecimalNullValue(Value));
                        }
                    }

                    lblTotalValueofNewMachinery.InnerHtml = TotalValueofNewMachinery.ToString();
                    lblSecondhandmachinery.InnerHtml = Secondhandmachinery.ToString();

                    lblTotalvaluemachinery.InnerHtml = (TotalValueofNewMachinery + Secondhandmachinery).ToString();
                    txtTotal.Text = (TotalValueofNewMachinery + Secondhandmachinery).ToString();

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
                    grdPandM.DataSource = ds.Tables[0];
                    grdPandM.DataBind();
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
            Dsnew = caf.GenericFillDs("USP_GET_PLANTANDMACHINERY_ExistingUnit", pp);
            return Dsnew;
        }

        protected void grdPandM_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        protected void grdPandM_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //}
        }

        protected void btnPandMAdd_Click(object sender, EventArgs e)
        {
            //decimal costsum = 0;
            //decimal Secondhand = 0;
            txtCostofMachine.Text = hdnMachineCostN.Value.TrimStart().TrimEnd().Trim();
            string errormsg = ValidatePlantMachinaryControls();
            if (errormsg.Trim().TrimStart() != "")
            {
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
                pm.TransportCharges = Convert.ToDecimal(txtTransportCharges.Text);
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

                int result = ObjCAFClass.InsertPlantandMachineryExistUnit(pm, out DbErrorMsg);
                if (result > 0 && DbErrorMsg == "")
                {
                    //Add to Grid Method
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Details Saved Successfully');", true);
                    hdnPMCostEdit.Value = "N";
                    BindPandMGrid(0, Convert.ToInt32(Session["IncentiveID"].ToString()));
                    //clearControls();
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
            if (ViewState["CategoryofUnit"].ToString().Trim().TrimStart() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Industry Category is not Defined as per the TTAP Policy. please check Approved Incevestment & Employment details\\n";
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

        public string ValidateDates(string Level)
        {
            string ErrorMsg = "";

            DateTime DateofCommencementNew;

            DateofCommencementNew = Convert.ToDateTime(GetFromatedDateDDMMYYYY(ViewState["DCPdate"].ToString()));
            if (ViewState["CategoryofUnit"].ToString().Trim().TrimStart() == "A1" || ViewState["CategoryofUnit"].ToString() == "A2")
            {
                DateofCommencementNew = Convert.ToDateTime(DateofCommencementNew).AddMonths(12);
            }
            else if (ViewState["CategoryofUnit"].ToString() == "A3" || ViewState["CategoryofUnit"].ToString() == "A4" || ViewState["CategoryofUnit"].ToString() == "A5")
            {
                DateofCommencementNew = Convert.ToDateTime(DateofCommencementNew).AddMonths(24);
            }

            if (Level == "2")
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
                    if (DateofCommencementNew < MachineLoadingDate)
                    {
                        ErrorMsg = ". Date of Commencement of Production of " + ViewState["TypeofApplicant"].ToString() + " Industry should be greater than the Machine Landing Date\\n";
                    }
                }
            }
            else if (Level == "3")
            {
                if (DateofCommencementNew != null && txtVaivleDate.Text.TrimStart().TrimEnd().Trim() != "")
                {
                    DateTime WaybillDate = Convert.ToDateTime(GetFromatedDateDDMMYYYY(txtVaivleDate.Text.Trim()));

                    if (DateofCommencementNew < WaybillDate)
                    {
                        ErrorMsg = ". Date of Commencement of Production of " + ViewState["TypeofApplicant"].ToString() + " Industry should be greater than the Waybill Date\\n";
                    }
                }
            }

            return ErrorMsg;
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
            int result = ObjCAFClass.DeletePlantandMachineryExistUnit(Convert.ToInt32(lblPM_Id.Text), Convert.ToInt32(lblIncentive_Id.Text));
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", "Deleted Successfully", true);
                BindPandMGrid(0, Convert.ToInt32(Session["IncentiveID"].ToString()));
                btnPandMAdd.Text = "Add New";
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

        // Payment Proofs

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
                pm.Industry_Type = "2";

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
                    BindPMForPaymentProofs(Convert.ToInt32(Session["IncentiveID"].ToString()), Convert.ToInt32(2), "2");
                    BindPMTransactionDtls(Convert.ToInt32(Session["IncentiveID"].ToString()), Convert.ToInt32(2), "2");
                    BindPMPaymentDtls(Session["IncentiveID"].ToString(),"2");
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
        protected void Cost_TextChanged(object sender, EventArgs e)
        {
            Double ActualMachineCost = 0, FreightCharges = 0, TransportCharges = 0, Cgst = 0, Sgst = 0, Igst = 0;
            ActualMachineCost = Convert.ToDouble(GetDecimalNullValue(txtActMachineCost.Text.TrimStart().TrimEnd()));
            FreightCharges = Convert.ToDouble(GetDecimalNullValue(txtFreightCharges.Text.TrimStart().TrimEnd()));
            TransportCharges = Convert.ToDouble(GetDecimalNullValue(txtTransportCharges.Text.TrimStart().TrimEnd()));
            Cgst = Convert.ToDouble(GetDecimalNullValue(txtcgst.Text.TrimStart().TrimEnd()));
            Sgst = Convert.ToDouble(GetDecimalNullValue(txtsgst.Text.TrimStart().TrimEnd()));
            Igst = Convert.ToDouble(GetDecimalNullValue(txtigst.Text.TrimStart().TrimEnd()));

            txttotalGst.Text = (Cgst + Sgst + Igst).ToString();
            txtCostofMachine.Text = (ActualMachineCost + FreightCharges + TransportCharges + Cgst + Sgst + Igst).ToString();
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
                    BindPMForPaymentProofs(Convert.ToInt32(Session["IncentiveID"].ToString()), Convert.ToInt32(2), "2");
                    BindPMTransactionDtls(Convert.ToInt32(Session["IncentiveID"].ToString()), Convert.ToInt32(2), "2");
                    BindPMPaymentDtls(Session["IncentiveID"].ToString(),"2");
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
    }
}