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
    public partial class frmConcessiononSGSTAnnexure : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        CAFClass ObjCAFClass = new CAFClass();
        General Gen = new General();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IncentiveID"] != null)
            {
                string IncentiveID = Request.QueryString["IncentiveID"].ToString();
                BindSGSTReimbursementAvailedDtls(IncentiveID);
                GetConcessionSGSTDetails("", IncentiveID);
                GetIncetiveAttachements(IncentiveID, "N", "6");
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
                    txtUnitName.InnerHtml = dsnew.Tables[0].Rows[0]["UnitName"].ToString();
                    lblTSIPassUIDNumber.InnerText = dsnew.Tables[0].Rows[0]["Uid_NO"].ToString();
                    lblCommonApplicationNumber.InnerText = dsnew.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                    lblTypeofApplicant.InnerText = dsnew.Tables[0].Rows[0]["TypeOfIndustryText"].ToString();

                    lblCategoryofUnit.InnerText = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    lblActivityoftheUnit.InnerText = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();

                    string TypeOfIndustry = dsnew.Tables[0].Rows[0]["TypeOfIndustry"].ToString();
                    if (TypeOfIndustry == "1")
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCP"].ToString();
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

                    txtlandexisting.InnerHtml = dsnew.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString();
                    txtlandcapacity.InnerHtml = dsnew.Tables[0].Rows[0]["ExpansionDiversificationLand"].ToString();
                    txtlandpercentage.InnerHtml = dsnew.Tables[0].Rows[0]["LandFixedCapitalInvestPercentage"].ToString();

                    txtbuildingexisting.InnerHtml = dsnew.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString();
                    txtbuildingcapacity.InnerHtml = dsnew.Tables[0].Rows[0]["ExpDiversBuilding"].ToString();
                    txtbuildingpercentage.InnerHtml = dsnew.Tables[0].Rows[0]["BuildingFixedCapitalInvestPercentage"].ToString();

                    txtplantexisting.InnerHtml = dsnew.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString();
                    txtplantcapacity.InnerHtml = dsnew.Tables[0].Rows[0]["ExpDiversPlantMachinery"].ToString();
                    txtplantpercentage.InnerHtml = dsnew.Tables[0].Rows[0]["PlantMachFixedCapitalInvestPercentage"].ToString();

                    lblApprovedProjectCostLand.InnerHtml = dsnew.Tables[0].Rows[0]["LandAssetsValuebyCA"].ToString();
                    lblApprovedProjectCostBuilding.InnerHtml = dsnew.Tables[0].Rows[0]["BuildingAssetsValuebyCA"].ToString();
                    lblApprovedProjectCostPlantMachinery.InnerHtml = dsnew.Tables[0].Rows[0]["PlantMachineryAssetsValuebyCA"].ToString();

                    CalculatationEnterprise1("1");
                    CalculatationEnterprise1("2");
                    CalculatationEnterprise1("3");
                    CalculatationEnterprise1("4");
                }

                DataSet ds = new DataSet();
                SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@created_BY",SqlDbType.VarChar),
                    new SqlParameter("@IncentiveID",SqlDbType.VarChar)
                };
                p[0].Value = uid;
                p[1].Value = IncentiveID;
                ds = Gen.GenericFillDs("USP_GET_ConcessionSGST_DTLS", p);
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.ToString() != "" && ds.Tables[0].Rows.ToString() != null)
                {

                    txtTaxpaid.InnerHtml = ds.Tables[0].Rows[0]["Taxpaid"].ToString();

                    txtGSTIdentificationNumber.InnerHtml = ds.Tables[0].Rows[0]["GSTIdentificationNumber"].ToString();
                    txtDateofEstablishmentofUnit.InnerHtml = ds.Tables[0].Rows[0]["DateofEstablishmentofUnit"].ToString();
                    txtInstalledcapacity.InnerHtml = ds.Tables[0].Rows[0]["Installedcapacity"].ToString();

                    txtYear1.InnerHtml = ds.Tables[0].Rows[0]["Year1"].ToString();
                    txtEnterprises1.InnerHtml = ds.Tables[0].Rows[0]["Enterprises1"].ToString();
                    txtTotalProduction1.InnerHtml = ds.Tables[0].Rows[0]["TotalProduction1"].ToString();
                    txtYear2.InnerHtml = ds.Tables[0].Rows[0]["Year2"].ToString();
                    txtEnterprises2.InnerHtml = ds.Tables[0].Rows[0]["Enterprises2"].ToString();
                    txtTotalProduction2.InnerHtml = ds.Tables[0].Rows[0]["TotalProduction2"].ToString();
                    txtYear3.InnerHtml = ds.Tables[0].Rows[0]["Year3"].ToString();
                    txtEnterprises3.InnerHtml = ds.Tables[0].Rows[0]["Enterprises3"].ToString();
                    txtTotalProduction3.InnerHtml = ds.Tables[0].Rows[0]["TotalProduction3"].ToString();

                    txtTaxPaid1.InnerHtml = ds.Tables[0].Rows[0]["TaxPaid1"].ToString();
                    txtTaxPaid2.InnerHtml = ds.Tables[0].Rows[0]["TaxPaid2"].ToString();
                    txtTaxPaid3.InnerHtml = ds.Tables[0].Rows[0]["TaxPaid3"].ToString();

                    txtClaimApplicationsubmitted.InnerHtml = ds.Tables[0].Rows[0]["ClaimApplicationsubmitted"].ToString();
                    txtTaxpaid.InnerHtml = ds.Tables[0].Rows[0]["Taxpaid"].ToString();
                    txtCurrentClaim.InnerHtml = ds.Tables[0].Rows[0]["CurrentClaimAmountRs"].ToString();
                    lblMoratoriumPeriod.InnerHtml = "From Date : " + ds.Tables[0].Rows[0]["MoratoriumFrom"].ToString() + " <br/>To Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: " + ds.Tables[0].Rows[0]["MoratoriumTo"].ToString() + " <br/>Investment  Amount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: " + ds.Tables[0].Rows[0]["MoratoriumInvestmentAmount"].ToString();
                    BindSGSTSaleDtls(IncentiveID);

                    txtEnterprisesTotal.InnerHtml = (Convert.ToDecimal(GetDecimalNullValue(txtEnterprises1.InnerHtml)) +
                                                  Convert.ToDecimal(GetDecimalNullValue(txtEnterprises2.InnerHtml)) +
                                                  Convert.ToDecimal(GetDecimalNullValue(txtEnterprises3.InnerHtml))).ToString();

                    txtTotalProductionTotal.InnerHtml = (Convert.ToDecimal(GetDecimalNullValue(txtTotalProduction1.InnerHtml)) +
                                                 Convert.ToDecimal(GetDecimalNullValue(txtTotalProduction2.InnerHtml)) +
                                                 Convert.ToDecimal(GetDecimalNullValue(txtTotalProduction3.InnerHtml))).ToString();

                    txtTaxPaidTotal.InnerHtml = (Convert.ToDecimal(GetDecimalNullValue(txtTaxPaid1.InnerHtml)) +
                                                 Convert.ToDecimal(GetDecimalNullValue(txtTaxPaid2.InnerHtml)) +
                                                 Convert.ToDecimal(GetDecimalNullValue(txtTaxPaid3.InnerHtml))).ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
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
                    if (txtlandexisting.InnerHtml != null && txtlandexisting.InnerHtml != "" && txtlandexisting.InnerHtml != string.Empty)
                    {
                        landexisting = Convert.ToDecimal(txtlandexisting.InnerHtml.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        landexisting = 0;
                    }
                    if (txtbuildingexisting.InnerHtml != null && txtbuildingexisting.InnerHtml != "" && txtbuildingexisting.InnerHtml != string.Empty)
                    {
                        buildingexisting = Convert.ToDecimal(txtbuildingexisting.InnerHtml.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        buildingexisting = 0;
                    }

                    if (txtplantexisting.InnerHtml != null && txtplantexisting.InnerHtml != "" && txtplantexisting.InnerHtml != string.Empty)
                    {
                        PlantMachValexisting = Convert.ToDecimal(txtplantexisting.InnerHtml.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        PlantMachValexisting = 0;
                    }
                    //if (txtnewothers.InnerHtml != null && txtnewothers.InnerHtml != "" && txtnewothers.InnerHtml != string.Empty)
                    //{
                    //    Othernew = Convert.ToDecimal(txtnewothers.InnerHtml.Trim());  // expansion Plant Mach value   
                    //}
                    //else
                    //{
                    //    Othernew = 0;
                    //}

                    PlantMachValFinal = (PlantMachValexisting + landexisting + buildingexisting + Othernew);
                    lblnewinv.InnerHtml = PlantMachValFinal.ToString();
                }
                else if (Step == "2")
                {
                    //--------------------------------
                    if (txtlandcapacity.InnerHtml != null && txtlandcapacity.InnerHtml != "" && txtlandcapacity.InnerHtml != string.Empty)
                    {
                        landcapacity = Convert.ToDecimal(txtlandcapacity.InnerHtml.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        landcapacity = 0;
                    }
                    if (txtbuildingcapacity.InnerHtml != null && txtbuildingcapacity.InnerHtml != "" && txtbuildingcapacity.InnerHtml != string.Empty)
                    {
                        buildingcapacity = Convert.ToDecimal(txtbuildingcapacity.InnerHtml.Trim());   // exiting Plant Mach value
                    }
                    else
                    {
                        buildingcapacity = 0;
                    }

                    // -------------------------------

                    if (txtplantcapacity.InnerHtml != null && txtplantcapacity.InnerHtml != "" && txtplantcapacity.InnerHtml != string.Empty)
                    {
                        PlantMachValexpansion = Convert.ToDecimal(txtplantcapacity.InnerHtml.Trim());  // expansion Plant Mach value   
                    }
                    else
                    {
                        PlantMachValexpansion = 0;
                    }
                    //-----------------


                    //if (txtexistother.InnerHtml != null && txtexistother.InnerHtml != "" && txtexistother.InnerHtml != string.Empty)
                    //{
                    //    OtherExisting = Convert.ToDecimal(txtexistother.InnerHtml.Trim());  // expansion Plant Mach value   
                    //}
                    //else
                    //{
                    //    OtherExisting = 0;
                    //}
                    PlantMachValFinal = (PlantMachValexpansion + landcapacity + buildingcapacity + OtherExisting);
                    lblexpinv.InnerHtml = PlantMachValFinal.ToString();
                }
                else if (Step == "3")
                {
                    if (txtlandpercentage.InnerHtml != null && txtlandpercentage.InnerHtml != "" && txtlandpercentage.InnerHtml != string.Empty)
                    {
                        landcapacityPer = Convert.ToDecimal(txtlandpercentage.InnerHtml.Trim());  // expansion Plant Mach value   
                    }
                    else
                    {
                        landcapacityPer = 0;
                    }

                    if (txtbuildingpercentage.InnerHtml != null && txtbuildingpercentage.InnerHtml != "" && txtbuildingpercentage.InnerHtml != string.Empty)
                    {
                        buildingcapacityPer = Convert.ToDecimal(txtbuildingpercentage.InnerHtml.Trim());  // expansion Plant Mach value   
                    }
                    else
                    {
                        buildingcapacityPer = 0;
                    }

                    if (txtplantpercentage.InnerHtml != null && txtplantpercentage.InnerHtml != "" && txtplantpercentage.InnerHtml != string.Empty)
                    {
                        PlantMachValPer = Convert.ToDecimal(txtplantpercentage.InnerHtml.Trim());  // expansion Plant Mach value   
                    }
                    else
                    {
                        PlantMachValPer = 0;
                    }

                    //if (txtotherpersangage.InnerHtml != null && txtotherpersangage.InnerHtml != "" && txtotherpersangage.InnerHtml != string.Empty)
                    //{
                    //    OthernewPer = Convert.ToDecimal(txtotherpersangage.InnerHtml.Trim());  // expansion Plant Mach value   
                    //}
                    //else
                    //{
                    //    OthernewPer = 0;
                    //}

                    PlantMachValFinal = Convert.ToDecimal((landcapacityPer + buildingcapacityPer + PlantMachValPer + OthernewPer) / 3);

                    lbltotperinv.InnerHtml = PlantMachValFinal.ToString("#.##");
                }
                else if (Step == "4")
                {
                    lblApprovedProjectCostTotal.InnerHtml = (Convert.ToDecimal(GetDecimalNullValue(lblApprovedProjectCostLand.InnerHtml)) +
                                                        Convert.ToDecimal(GetDecimalNullValue(lblApprovedProjectCostBuilding.InnerHtml)) +
                                                        Convert.ToDecimal(GetDecimalNullValue(lblApprovedProjectCostPlantMachinery.InnerHtml))).ToString();
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                //lblmsg0.InnerHtml = ex.Message;
                //Failure.Visible = true;
                //success.Visible = false;
            }
        }
        public string GetDecimalNullValue(string Input)
        {
            string InputValue = "";

            InputValue = (Input != "") ? Input : "0";

            return InputValue;
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

        public void GetIncetiveAttachements(string IncentiveId, string CAFFLAG, string SubIncentiveId)
        {
            DataSet dsnew1 = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentveID",SqlDbType.Int),
                new SqlParameter("@CAFFLAG",SqlDbType.VarChar),
                new SqlParameter("@SubIncentiveId1",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = CAFFLAG;
            pp[2].Value = SubIncentiveId;
            dsnew1 = ObjCAFClass.GenericFillDs("[USP_GET_ALLINCENTIVES_APPLICANT_DRAFT]", pp);

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

                    string Category = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Category"));
                    if (Category.Trim().TrimStart() != "")
                    {
                        lbl.Text = Category.Trim().TrimStart();
                        e.Row.Font.Bold = true;
                    }


                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                //lblmsg0.Text = "Internal error has occured. Please try after some time";
                // lblmsg0.Text = ex.Message;
                //Failure.Visible = true;
                // LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
    }
}