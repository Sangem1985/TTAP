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
    public partial class DraftfrmInspectionRptView : System.Web.UI.Page
    {

        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        CAFClass ObjCAFClass = new CAFClass();
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

                        string IncentiveID = Request.QueryString["IncentiveID"].ToString();
                        string SubIncentiveId = Request.QueryString["SubIncentiveId"].ToString();
                        BindBesicdata(IncentiveID, SubIncentiveId, ObjLoginNewvo.DistrictID);

                        if (SubIncentiveId == "1")
                        {
                            DivIncentiveID_1.Visible = true;
                        }
                        else if (SubIncentiveId == "2")
                        {
                            DivIncentiveID_2.Visible = true;
                        }
                        else if (SubIncentiveId == "3")
                        {
                            DivIncentiveID_3.Visible = true;
                        }
                        else if (SubIncentiveId == "4")
                        {
                            DivIncentiveID_4.Visible = true;
                        }
                        else if (SubIncentiveId == "5")
                        {
                            DivIncentiveID_5.Visible = true;
                        }
                        else if (SubIncentiveId == "6")
                        {
                            DivIncentiveID_6.Visible = true;
                        }
                        else if (SubIncentiveId == "7")
                        {
                            DivIncentiveID_7.Visible = true;
                        }
                        else if (SubIncentiveId == "8")
                        {
                            DivIncentiveID_8.Visible = true;
                        }
                        else if (SubIncentiveId == "9")
                        {
                            DivIncentiveID_9.Visible = true;
                        }
                        else if (SubIncentiveId == "10")
                        {
                            DivIncentiveID_10.Visible = true;
                        }
                        else if (SubIncentiveId == "11")
                        {
                            DivIncentiveID_11.Visible = true;
                        }
                        else if (SubIncentiveId == "12")
                        {
                            DivIncentiveID_12.Visible = true;
                        }
                        else if (SubIncentiveId == "13")
                        {
                            DivIncentiveID_13.Visible = true;
                        }
                        else if (SubIncentiveId == "14")
                        {
                            DivIncentiveID_14.Visible = true;
                        }
                        else if (SubIncentiveId == "15")
                        {
                            DivIncentiveID_15.Visible = true;
                        }
                        else if (SubIncentiveId == "16")
                        {
                            DivIncentiveID_16.Visible = true;
                        }
                        else if (SubIncentiveId == "17")
                        {
                            DivIncentiveID_17.Visible = true;
                        }
                        else if (SubIncentiveId == "18")
                        {
                            DivIncentiveID_18.Visible = true;
                        }
                        else if (SubIncentiveId == "19")
                        {
                            DivIncentiveID_19.Visible = true;
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
                        HMainheading.InnerHtml = "PART  B <br/> " + dsnew1.Tables[0].Rows[0]["IncentiveName"].ToString() + "<br/> Inspecting Officer Report";
                        HCalHeading.InnerHtml = "PART  B <br/> " + dsnew1.Tables[0].Rows[0]["IncentiveName"].ToString(); // + "<br/> Calculation Part";
                        if (SubIncentiveId == "1" || SubIncentiveId == "19")
                        {
                            Capitalsub.Visible = true;
                            lblIndustryPersonName.Visible = true;
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
                        //SubsidySystemRecommended.InnerHtml = dsnew1.Tables[0].Rows[0]["SystemRecommendedAmount"].ToString();

                        //txtAmountSubsidyRecommended.InnerHtml = dsnew1.Tables[0].Rows[0]["OfficerRecommendedAmount"].ToString();
                        //txtAppDateofInspection.InnerHtml = dsnew1.Tables[0].Rows[0]["InspectionDoneOn"].ToString();
                        //txtRemarks.InnerHtml = dsnew1.Tables[0].Rows[0]["Remarks"].ToString();

                        // lblIndustryPersonName.InnerHtml = dsnew1.Tables[0].Rows[0]["IndustryPersonName"].ToString();
                        string DIPCFlag = dsnew1.Tables[0].Rows[0]["DIPC_FLAG"].ToString();
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

                    lblDLORDOName.Text = "<b>"+Dsofficer.Tables[0].Rows[0]["OfficerName"].ToString() + "</b>," + Dsofficer.Tables[0].Rows[0]["Designation"].ToString() + "," + "" + Dsofficer.Tables[0].Rows[0]["WorkingDistrict"].ToString() + " and " +
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
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_INSPECTION_DTLS", pp);
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
            dsnew1 = ObjCAFClass.GenericFillDs("[USP_GET_ATTACHMENTS_SUBSIDY]", pp);

            if (dsnew1 != null && dsnew1.Tables.Count > 0 && dsnew1.Tables[0].Rows.Count > 0)
            {
                gvSubsidy.DataSource = dsnew1.Tables[0];
                gvSubsidy.DataBind();
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
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_OFFICER_NAME_DRAFT", pp);
            return Dsnew;
        }

    }
}