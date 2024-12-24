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

namespace TTAP.UI.Pages.Annexures
{
    public partial class frmRevisedInspectionRptViewaspx : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        CAFClass ObjCAFClass = new CAFClass();
        decimal AMachineCost = 0, NAMachineCost = 0;
        string Role = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["uid"] != null)
                {
                    if (Request.QueryString.Count > 1)
                    {
                        UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                        ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                        Role = ObjLoginNewvo.Role_Code;
                        string IncentiveID = Request.QueryString["IncentiveID"].ToString();
                        string SubIncentiveId = Request.QueryString["SubIncentiveId"].ToString();
                        BindBesicdata(IncentiveID, SubIncentiveId, ObjLoginNewvo.DistrictID);
                        bool strKey = Convert.ToBoolean(ConfigurationManager.AppSettings["SysCalamount"].ToString());
                        bool strKeyDLO = Convert.ToBoolean(ConfigurationManager.AppSettings["DLOSysCalamount"].ToString());
                        /*tdsysSubsidy.Visible = false;
                        tdsysSubsidy1.Visible = false;
                        trcapitalsubsidy.Visible = false;*/
                        if (Role == "DLO")
                        {   /*tdsysSubsidy.Visible = strKeyDLO;
                            tdsysSubsidy1.Visible = strKeyDLO;
                            trcapitalsubsidy.Visible = strKeyDLO;*/
                            chkShow.Visible = false;
                        }
                    }
                }
            }

        }

        public void BindBesicdata(string IncentiveID, string SubIncentiveId, string DistrictID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetapplicationDtls("0", IncentiveID);
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    txtUnitName.InnerHtml = dsnew.Tables[0].Rows[0]["UnitName"].ToString();
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
                    lblReceiptDate.InnerHtml = dsnew.Tables[0].Rows[0]["ApplicationFiledDate"].ToString();
                    lblcategory.InnerText = dsnew.Tables[0].Rows[0]["SocialStatusText"].ToString();
                    lblCategoryofUnit.InnerText = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    lblActivityoftheUnit.InnerText = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();

                    TypeofTexttile.InnerText = dsnew.Tables[0].Rows[0]["TypeofTexttileText"].ToString();

                    DataSet dsnew1 = new DataSet();
                    dsnew1 = GetSubsidyApplicationDeatils(IncentiveID, SubIncentiveId, DistrictID);
                    if (dsnew1 != null && dsnew1.Tables.Count > 0 && dsnew1.Tables[0].Rows.Count > 0)
                    {
                        HMainheading.InnerHtml = "PART  B <br/> " + dsnew1.Tables[0].Rows[0]["IncentiveName"].ToString() + "<br/> Inspecting Officer Report(Revised)";
                        if (SubIncentiveId == "1" || SubIncentiveId == "19")
                        {
                            Capitalsub.Visible = true;
                            lblIndustryPersonName.Visible = true;
                            divplantmachinary.Visible = true;
                            BindPandMGrid(0, Convert.ToInt32(IncentiveID), TypeOfIndustry);
                            if (SubIncentiveId == "1")
                            {
                                trcapitalsubsidy.Visible = true;

                                lblSystemTotal.InnerHtml = dsnew1.Tables[0].Rows[0]["SystemRecommendedAmount"].ToString();
                                lblSystemSubsidy.InnerHtml = dsnew1.Tables[0].Rows[0]["SystemCapitalSubsidyAmount"].ToString();
                                lblSystemAdditionalCapitalSubsidy.InnerHtml = dsnew1.Tables[0].Rows[0]["SystemAdditionalCapitalSubsidyAmount"].ToString();

                                txtInspectingOfficerSubsidy.InnerHtml = dsnew1.Tables[0].Rows[0]["CapitalSubsidyAmount"].ToString();
                                txtInspectingOfficerAdditionalCapitalSubsidy.InnerHtml = dsnew1.Tables[0].Rows[0]["AdditionalCapitalSubsidyAmount"].ToString();
                                lblInspectingOfficerTotal.InnerHtml = dsnew1.Tables[0].Rows[0]["OfficerRecommendedAmount"].ToString();
                                GetCapitalSubsidyBuildingDtls(IncentiveID, SubIncentiveId);
                                trBuildingDetails.Visible = true;
                                trLandDetails.Visible = true;
                            }
                            else
                            {
                                trcapitalsubsidy.Visible = false;
                            }
                        }
                        if (SubIncentiveId == "5")
                        {
                            trStampDuty.Visible = true;
                            lblNatureofAsset.InnerHtml = dsnew1.Tables[0].Rows[0]["NatureofAsset_Stampduty"].ToString();
                            lblavailedamount.InnerHtml = dsnew1.Tables[0].Rows[0]["Availedamount_Stampduty"].ToString();
                        }
                        if (SubIncentiveId == "7")
                        {
                            trAssistanceforEnergyWaterEnvironmental.Visible = true;
                            trAssistanceforEnergyWaterEnvironmental1.Visible = true;

                            string TypeofInfrastructure = dsnew1.Tables[0].Rows[0]["AssistanceRequired_AssistanceEnergy"].ToString();
                            if (TypeofInfrastructure != "")
                            {
                                string[] TypeofInfrastructureVal = TypeofInfrastructure.Split(',');

                                foreach (string Value in TypeofInfrastructureVal)
                                {
                                    int Index = chkAssistanceRequired.Items.IndexOf(chkAssistanceRequired.Items.FindByValue(Value));
                                    chkAssistanceRequired.Items[Index].Selected = true;
                                }
                            }

                            RbtnCommercialProduction.InnerText = dsnew1.Tables[0].Rows[0]["CommercialProductionText_AssistanceEnergy"].ToString();
                            txtReimbursementReceived.InnerHtml = dsnew1.Tables[0].Rows[0]["ReimbursementReceived_AssistanceEnergy"].ToString();
                        }

                        if (SubIncentiveId == "16")
                        {
                            trTrainingSubsidy.Visible = true;
                            trTrainingSubsidy1.Visible = true;

                            txtNumberofEmployees.InnerHtml = dsnew1.Tables[0].Rows[0]["NumberofEmployees_Training_Subsidy"].ToString();
                            txtNumberofEmployeesTrained.InnerHtml = dsnew1.Tables[0].Rows[0]["NumberofEmployeesTrained_Training_Subsidy"].ToString();
                            txtExpenditureIncurredTraining.InnerHtml = dsnew1.Tables[0].Rows[0]["ExpenditureIncurredTraining_Training_Subsidy"].ToString();
                        }
                        if (SubIncentiveId == "17")
                        {
                            trTrainingInfrastructureSubsidy1.Visible = true;
                            trTrainingInfrastructureSubsidy2.Visible = true;
                            trTrainingInfrastructureSubsidy3.Visible = true;
                            trTrainingInfrastructureSubsidy4.Visible = true;
                            trTrainingInfrastructureSubsidy5.Visible = true;

                            txtBuilding.InnerHtml = dsnew1.Tables[0].Rows[0]["Building_TrainingInfrastructure"].ToString();
                            txtPlantMachinery.InnerHtml = dsnew1.Tables[0].Rows[0]["PlantMachinery_TrainingInfrastructure"].ToString();
                            txtInstallationCharges.InnerHtml = dsnew1.Tables[0].Rows[0]["InstallationCharges_TrainingInfrastructure"].ToString();
                            txtElectrification.InnerHtml = dsnew1.Tables[0].Rows[0]["Electrification_TrainingInfrastructure"].ToString();
                            txtTrainingAids.InnerHtml = dsnew1.Tables[0].Rows[0]["TrainingAids_TrainingInfrastructure"].ToString();
                            txtFurniture.InnerHtml = dsnew1.Tables[0].Rows[0]["Furniture_TrainingInfrastructure"].ToString();
                            lblTotalInvestment.InnerHtml = dsnew1.Tables[0].Rows[0]["TotalInvestment_TrainingInfrastructure"].ToString();
                        }

                        lblInspectingOfficerName.InnerHtml = dsnew1.Tables[0].Rows[0]["Name"].ToString();
                        lblInspectionSchduledDate.InnerHtml = dsnew1.Tables[0].Rows[0]["SchduledDate"].ToString();

                        lblquerydate.InnerHtml = dsnew1.Tables[0].Rows[0]["QueryDate"].ToString();
                        lblresponsedate.InnerHtml = dsnew1.Tables[0].Rows[0]["QueryResponseDare"].ToString();

                        lblSubsidyClaimedUnit.InnerHtml = dsnew1.Tables[0].Rows[0]["UnitClaimedAmount"].ToString();
                        SubsidySystemRecommended.InnerHtml = dsnew1.Tables[0].Rows[0]["SystemRecommendedAmount"].ToString();

                        txtAmountSubsidyRecommended.InnerHtml = dsnew1.Tables[0].Rows[0]["OfficerRecommendedAmount"].ToString();
                        txtAppDateofInspection.InnerHtml = dsnew1.Tables[0].Rows[0]["InspectionDoneOn"].ToString();
                        txtRemarks.InnerHtml = dsnew1.Tables[0].Rows[0]["Remarks"].ToString();

                        lblIndustryPersonName.InnerHtml = dsnew1.Tables[0].Rows[0]["IndustryPersonName"].ToString();
                        lblRevisedCategory.InnerHtml = dsnew1.Tables[0].Rows[0]["Ins_Category"].ToString();
                        lblRevisedTypeTextile.InnerHtml = dsnew1.Tables[0].Rows[0]["Ins_TypeOfTextile"].ToString();
                        lblInsAmount.InnerHtml = dsnew1.Tables[0].Rows[0]["Actual_SystemRecommended"].ToString();

                        string DIPCFlag = dsnew1.Tables[0].Rows[0]["DIPC_FLAG"].ToString();
                        string INSFlag = dsnew1.Tables[0].Rows[0]["Ins_Flag"].ToString();
                        if (INSFlag == "Y")
                        {
                            trInsFlag.Visible = true;
                            trInsAmount.Visible = false;
                        }
                        if (DIPCFlag != "Y")
                        {
                            spnRDD.Visible = true;
                            spnRDDname.Visible = false;
                            divSLCFIle.Visible = true;
                        }
                        else
                        {
                            spnRDD.Visible = false;
                            divSLCFIle.Visible = false;
                            spnDLO.Style.Clear();
                            //spnDLO.Style.Remove("padding-left");
                            spnDLO.Style.Add("font-weight", "bold");

                        }

                        GetIncetiveAttachements(IncentiveID, SubIncentiveId);
                        GetSnos();
                    }
                }
                else
                {

                }

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                DataSet Dsofficer = new DataSet();
                Dsofficer = GetInspectionOfficerDtls(IncentiveID, SubIncentiveId, ObjLoginNewvo.uid, ObjLoginNewvo.Role_Code, "INSPECTION");
                if (Dsofficer != null && Dsofficer.Tables.Count > 0 && Dsofficer.Tables[0].Rows.Count > 0)
                {
                    lblGMname.Text = Dsofficer.Tables[0].Rows[0]["OfficerName"].ToString() + "</br>" + Dsofficer.Tables[0].Rows[0]["Designation"].ToString() + "</br>" + "" + Dsofficer.Tables[0].Rows[0]["WorkingDistrict"].ToString();
                    lblplace.Text = "Date : " + Dsofficer.Tables[0].Rows[0]["CurrentDate"].ToString() + "</br> Location : " + Dsofficer.Tables[0].Rows[0]["Place"].ToString();

                    lblRDDname.Text = Dsofficer.Tables[0].Rows[0]["RDDOfficerName"].ToString() + "</br>" + Dsofficer.Tables[0].Rows[0]["RDDDesignation"].ToString() + "</br>" + "" + Dsofficer.Tables[0].Rows[0]["RDDWorkingDistrict"].ToString();

                    lblDLORDOName.Text = "<b>" + Dsofficer.Tables[0].Rows[0]["OfficerName"].ToString() + "</b>," + Dsofficer.Tables[0].Rows[0]["Designation"].ToString() + "," + "" + Dsofficer.Tables[0].Rows[0]["WorkingDistrict"].ToString() + " and " +
                    "<b>" + Dsofficer.Tables[0].Rows[0]["RDDOfficerName"].ToString() + "</b>," + Dsofficer.Tables[0].Rows[0]["RDDDesignation"].ToString() + "," + "" + Dsofficer.Tables[0].Rows[0]["RDDWorkingDistrict"].ToString();
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
        public void GetCapitalSubsidyBuildingDtls(string IncentiveId, string SubIncentiveId)
        {
            DataSet dsnew1 = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentveID",SqlDbType.VarChar),
              new SqlParameter("@SubIncentiveId",SqlDbType.VarChar),
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = SubIncentiveId;
            dsnew1 = ObjCAFClass.GenericFillDs("[USP_GET_CAPITAL_SUBSIDY_INPSECTIONBUILDINGDTLS]", pp);

            if (dsnew1 != null && dsnew1.Tables.Count > 0 && dsnew1.Tables[0].Rows.Count > 0)
            {
                GvBuildingDetails.DataSource = dsnew1.Tables[0];
                GvBuildingDetails.DataBind();
            }
            else
            {
                GvBuildingDetails.DataSource = null;
                GvBuildingDetails.DataBind();
            }
            if (dsnew1.Tables[1].Rows.Count > 0)
            {

                txtPLExtent.Text = dsnew1.Tables[1].Rows[0]["PurchasedLandExtent"].ToString();
                txtPLValue.Text = dsnew1.Tables[1].Rows[0]["PurchasedLandValue"].ToString();
                txtLLExtent.Text = dsnew1.Tables[1].Rows[0]["LeasedLandExtent"].ToString();
                txtLLValue.Text = dsnew1.Tables[1].Rows[0]["LeasedLandValue"].ToString();
                txtILExtent.Text = dsnew1.Tables[1].Rows[0]["InheritedLandExtent"].ToString();
                txtILValue.Text = dsnew1.Tables[1].Rows[0]["InheritedLandValue"].ToString();
                txtGLExtent.Text = dsnew1.Tables[1].Rows[0]["GovtLandExtent"].ToString();
                txtGLValue.Text = dsnew1.Tables[1].Rows[0]["GovtLandValue"].ToString();

                BindTotalLandValue("1");
                BindTotalLandValue("2");
                BindTotalLandValue("3");
                BindTotalLandValue("4");
            }
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
        public string GetDecimalNullValue(string Input)
        {
            string InputValue = "";

            InputValue = (Input != "") ? Input : "0";

            return InputValue;
        }
        public DataSet GetSubsidyApplicationDeatils(string INCENTIVEID, string SubIncentiveId, string DistID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar),
               new SqlParameter("@SubIncentiveId",SqlDbType.VarChar),
               new SqlParameter("@DistID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            pp[1].Value = SubIncentiveId;
            pp[2].Value = DistID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_INSPECTION_DTLS_VIEW_REVISED_INSP", pp);
            return Dsnew;
        }

        public void GetIncetiveAttachements(string IncentiveId, string SubIncentiveId)
        {
            DataSet dsnew1 = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentveID",SqlDbType.VarChar),
              new SqlParameter("@SubIncentiveId",SqlDbType.VarChar),
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = SubIncentiveId;
            dsnew1 = ObjCAFClass.GenericFillDs("[USP_GET_ATTACHMENTS_SUBSIDY_REVISED_INSP]", pp);

            if (dsnew1 != null && dsnew1.Tables.Count > 0 && dsnew1.Tables[0].Rows.Count > 0)
            {
                gvSubsidy.DataSource = dsnew1.Tables[0];
                gvSubsidy.DataBind();
            }
        }
        public void GetSnos()
        {
            int slno = 0;
            foreach (GridViewRow row in gvSubsidy.Rows)
            {
                string Date = (row.FindControl("lblverified") as Label).Text;
                if (Date != "")
                {
                    slno = slno + 1;
                    row.Cells[0].Text = Convert.ToString(slno);
                }
                else
                {
                    row.Cells[0].Text = "";
                }
            }
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

                    if (HyperLinkSubsidy.NavigateUrl == "")
                    {
                        HyperLinkSubsidy.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                //lblmsg0.Text = "Internal error has occured. Please try after some time";
                //lblmsg0.Text = ex.Message;
                //Failure.Visible = true;
                // LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        public DataSet GetInspectionOfficerDtls(string incentiveid, string SubIncentiveID, string createdby, string RoleCode, string TYPEOFTRANSACTION)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@Incentiveid",SqlDbType.VarChar),
               new SqlParameter("@SubIncentiveID",SqlDbType.VarChar),
               new SqlParameter("@Created_by",SqlDbType.VarChar),
               new SqlParameter("@RoleCode",SqlDbType.VarChar),
               new SqlParameter("@TYPEOFTRANSACTION",SqlDbType.VarChar)
           };
            pp[0].Value = incentiveid;
            pp[1].Value = SubIncentiveID;
            pp[2].Value = createdby;
            pp[3].Value = RoleCode;
            pp[4].Value = TYPEOFTRANSACTION;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_OFFICER_NAME", pp);
            return Dsnew;
        }

        public void BindPandMGrid(int PMId, int IncentiveId, string IndusType)
        {
            DataSet ds = new DataSet();
            try
            {

                ds = GetPandM(PMId, IncentiveId, IndusType);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdPandM.DataSource = ds.Tables[0];
                    grdPandM.DataBind();
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                //lblmsg0.Text = ex.Message;
                //Failure.Visible = true;
                //success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
        public DataSet GetPandM(int PMId, int IncentiveId, string IndusType)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@PMId",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = PMId;
            string ProcName = "";
            if (IndusType == "1")
            {
                ProcName = "USP_GET_PLANTANDMACHINERY";
            }
            else
            {
                ProcName = "USP_GET_PLANTANDMACHINERY_ExistingUnit";
            }
            Dsnew = ObjCAFClass.GenericFillDs(ProcName, pp);
            return Dsnew;
        }

        protected void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow.Checked == true)
            {
                tdsysSubsidy.Visible = true;
                tdsysSubsidy1.Visible = true;
                trcapitalsubsidy.Visible = true;
            }
            else
            {
                tdsysSubsidy.Visible = false;
                tdsysSubsidy1.Visible = false;
                trcapitalsubsidy.Visible = false;
            }
        }

        protected void grdPandM_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    string Actiontaken = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MachineAvailability_ReInsp"));
                    string MachineCost = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DLOFinalRecommendedMachineCost_ReInsp"));

                    if (Actiontaken == "A")
                    {
                        e.Row.Style.Add("background-color", "darkseagreen");
                    }
                    if (Actiontaken == "Y" || Actiontaken == "A")
                    {
                        AMachineCost = AMachineCost + Convert.ToDecimal(MachineCost);
                    }
                    else
                    {
                        e.Row.Style.Add("background-color", "darkkhaki");
                        NAMachineCost = NAMachineCost + Convert.ToDecimal(MachineCost);
                    }
                }

                lblTotalValueofAvailabile.InnerText = AMachineCost.ToString();
                lblTotalValueofNonAvailabile.InnerText = NAMachineCost.ToString();

                lblTotalValueMachinery.InnerText = (AMachineCost + NAMachineCost).ToString();
            }
            catch (Exception ex)
            {

            }
        }
    }
}