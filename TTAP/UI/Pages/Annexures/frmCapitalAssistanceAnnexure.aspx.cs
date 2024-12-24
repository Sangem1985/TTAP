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
    public partial class frmCapitalAssistanceAnnexure : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IncentiveID"] != null)
            {
                string IncentiveID = Request.QueryString["IncentiveID"].ToString();
                BindControls("0", IncentiveID);
                GetIncetiveAttachements(IncentiveID, "N", "1");
                if (IncentiveID == "2063")
                {
                    divPMRatio.Visible = true;
                }
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
        public void BindControls(string UserId, string IncentiveID)
        {
            DataSet dsnew = new DataSet();
            dsnew = GetapplicationDtls(UserId, IncentiveID);
            if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
            {
                txtUnitName.InnerHtml = dsnew.Tables[0].Rows[0]["UnitName"].ToString();
                lblTSIPassUIDNumber.InnerHtml = dsnew.Tables[0].Rows[0]["Uid_NO"].ToString();
                lblCommonApplicationNumber.InnerHtml = dsnew.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                lblCategoryofUnit.InnerHtml = dsnew.Tables[0].Rows[0]["Category"].ToString();
                lblTypeofUnit.InnerHtml = dsnew.Tables[0].Rows[0]["TypeOfIndustryText"].ToString();
                string TypeOfIndustry = dsnew.Tables[0].Rows[0]["TypeOfIndustry"].ToString();
                if (TypeOfIndustry == "1")
                {
                    lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCP"].ToString();
                    lblProjectCost.InnerHtml = dsnew.Tables[0].Rows[0]["TotalInvestment"].ToString();
                }
                else
                {
                    lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCPExp"].ToString();
                    lblProjectCost.InnerHtml = dsnew.Tables[0].Rows[0]["EXPInvestment"].ToString();
                }

                lblcategory.InnerHtml = dsnew.Tables[0].Rows[0]["SocialStatusText"].ToString();
                lblTypeofUnitTechnicalOrConventional.InnerHtml = dsnew.Tables[0].Rows[0]["TypeofTexttileText"].ToString();
            }

            DataSet dsData = GetCAFNewUnitData(Session["uid"].ToString(), Convert.ToInt32(IncentiveID));
            if (dsData.Tables.Count > 0)
            {
                if (dsData.Tables[0].Rows.Count > 0)
                {
                    //Bind Controls
                    lblTypeofUnitTechnicalOrConventional.InnerHtml = dsData.Tables[0].Rows[0]["TypeofUnitText"].ToString();
                    txtPLExtent.InnerHtml = dsData.Tables[0].Rows[0]["PurchasedLandExtent"].ToString();
                    txtPLValue.InnerHtml = dsData.Tables[0].Rows[0]["PurchasedLandValue"].ToString();
                    txtLLExtent.InnerHtml = dsData.Tables[0].Rows[0]["LeasedLandExtent"].ToString();
                    txtLLValue.InnerHtml = dsData.Tables[0].Rows[0]["LeasedLandValue"].ToString();
                    txtILExtent.InnerHtml = dsData.Tables[0].Rows[0]["InheritedLandExtent"].ToString();
                    txtILValue.InnerHtml = dsData.Tables[0].Rows[0]["InheritedLandValue"].ToString();
                    txtGLExtent.InnerHtml = dsData.Tables[0].Rows[0]["GovtLandExtent"].ToString();
                    txtGLValue.InnerHtml = dsData.Tables[0].Rows[0]["GovtLandValue"].ToString();

                    lblBuliding_Type.InnerHtml = dsData.Tables[0].Rows[0]["Buliding_TypeText"].ToString();

                    txtMFSArea.InnerHtml = dsData.Tables[0].Rows[0]["MainFactoryShedArea"].ToString();
                    txtMFSCost.InnerHtml = dsData.Tables[0].Rows[0]["MainFactoryShedCost"].ToString();
                    txtWarehouseArea.InnerHtml = dsData.Tables[0].Rows[0]["WarehouseArea"].ToString();
                    txtWarehouseCost.InnerHtml = dsData.Tables[0].Rows[0]["WarehouseCost"].ToString();
                    txtOfficeArea.InnerHtml = dsData.Tables[0].Rows[0]["OfficeRoomArea"].ToString();
                    txtOfficeCost.InnerHtml = dsData.Tables[0].Rows[0]["OfficeRoomCost"].ToString();
                    txtCWPArea.InnerHtml = dsData.Tables[0].Rows[0]["CoolingPondsArea"].ToString();
                    txtCWPCost.InnerHtml = dsData.Tables[0].Rows[0]["CoolingPondsCost"].ToString();
                    txtBoilerArea.InnerHtml = dsData.Tables[0].Rows[0]["BoilerShedArea"].ToString();
                    txtBoilerCost.InnerHtml = dsData.Tables[0].Rows[0]["BoilerShedCost"].ToString();
                    txtETPArea.InnerHtml = dsData.Tables[0].Rows[0]["EffluentPondsArea"].ToString();
                    txtETPCost.InnerHtml = dsData.Tables[0].Rows[0]["EffluentPondsCost"].ToString();
                    txtOTArea.InnerHtml = dsData.Tables[0].Rows[0]["OverHeadTankArea"].ToString();
                    txtOTACost.InnerHtml = dsData.Tables[0].Rows[0]["OverHeadTankCost"].ToString();



                    txtFGArea.InnerHtml = dsData.Tables[0].Rows[0]["FencingArea"].ToString();
                    txtFGCost.InnerHtml = dsData.Tables[0].Rows[0]["FencingCost"].ToString();
                    txtAFArea.InnerHtml = dsData.Tables[0].Rows[0]["ArchitectFeeArea"].ToString();
                    txtAFCost.InnerHtml = dsData.Tables[0].Rows[0]["ArchitectFeeCost"].ToString();
                    txtCWArea.InnerHtml = dsData.Tables[0].Rows[0]["CompoundWallArea"].ToString();
                    txtCWCost.InnerHtml = dsData.Tables[0].Rows[0]["CompoundWallCost"].ToString();
                    txtWQArea.InnerHtml = dsData.Tables[0].Rows[0]["WorksersHouseArea"].ToString();
                    txtWQCost.InnerHtml = dsData.Tables[0].Rows[0]["WorkersHouseCost"].ToString();
                    txtCanteenArea.InnerHtml = dsData.Tables[0].Rows[0]["CanteenArea"].ToString();
                    txtCanteenCost.InnerHtml = dsData.Tables[0].Rows[0]["CanteenCost"].ToString();
                    txtRHArea.InnerHtml = dsData.Tables[0].Rows[0]["RestHouseArea"].ToString();
                    txtRHCost.InnerHtml = dsData.Tables[0].Rows[0]["RestHouseCost"].ToString();
                    txtTOArea.InnerHtml = dsData.Tables[0].Rows[0]["TimeOfficeArea"].ToString();
                    txtTOCost.InnerHtml = dsData.Tables[0].Rows[0]["TimeOfficeCost"].ToString();
                    txtCSArea.InnerHtml = dsData.Tables[0].Rows[0]["VehicleStandArea"].ToString();
                    txtCSCost.InnerHtml = dsData.Tables[0].Rows[0]["VehicleStandCost"].ToString();
                    txtSSArea.InnerHtml = dsData.Tables[0].Rows[0]["SecurityShedArea"].ToString();
                    txtSSCost.InnerHtml = dsData.Tables[0].Rows[0]["SecurityShedCost"].ToString();
                    txtToiletArea.InnerHtml = dsData.Tables[0].Rows[0]["ToiletArea"].ToString();
                    txtToiletCost.InnerHtml = dsData.Tables[0].Rows[0]["ToiletCost"].ToString();
                    txtRoadsArea.InnerHtml = dsData.Tables[0].Rows[0]["RoadsArea"].ToString();
                    txtRoadsCost.InnerHtml = dsData.Tables[0].Rows[0]["RoadsCost"].ToString();



                    lblCurrentClaimAmount.InnerHtml = dsData.Tables[0].Rows[0]["CurrentClaimAmount"].ToString();

                    BindTotalLandValue("1");
                    BindTotalLandValue("2");
                    BindTotalLandValue("3");
                    BindTotalLandValue("4");

                    txtLaboratoriesforResearchQualityControl.InnerHtml = dsData.Tables[0].Rows[0]["LaboratoriesforResearchQualityControl"].ToString();
                    txtUtilitiesPowerWater.InnerHtml = dsData.Tables[0].Rows[0]["UtilitiesPowerWater"].ToString();
                    txtOtherFixedAssets.InnerHtml = dsData.Tables[0].Rows[0]["OtherFixedAssets"].ToString();
                    txtTotal.InnerHtml = dsData.Tables[0].Rows[0]["Total"].ToString();
                    txtAmountAvailed.InnerHtml = dsData.Tables[0].Rows[0]["AmountAvailed"].ToString();
                    txtSanctionOrderNo.InnerHtml = dsData.Tables[0].Rows[0]["SanctionOrderNo"].ToString();
                    txtDateAvailed.InnerHtml = dsData.Tables[0].Rows[0]["DateAvailedDDMMYY"].ToString();

                    BindTotalLandValue("5");
                    BindTotalLandValue("6");
                    BindTotalLandValue("7");
                }

                BindPandMGrid(0, Convert.ToInt32(IncentiveID));
            }
        }
        public DataSet GetCAFNewUnitData(string UserId, int IncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UserId",SqlDbType.VarChar),
               new SqlParameter("@IncentiveId",SqlDbType.VarChar)
           };
            pp[0].Value = UserId;
            pp[1].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_INCENTIVE_CAF_NEWUNIT", pp);
            return Dsnew;
        }

        public void BindTotalLandValue(string LandTypeSlno)
        {
            Double Extent = 0, LandValue = 0;
            if (LandTypeSlno == "1")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(txtPLExtent.InnerHtml.TrimStart().TrimEnd()));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtPLValue.InnerHtml.TrimStart().TrimEnd()));

                lblPLTotalValue.InnerHtml = (Extent * LandValue).ToString();
            }
            else if (LandTypeSlno == "2")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(txtLLExtent.InnerHtml.TrimStart().TrimEnd()));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtLLValue.InnerHtml.TrimStart().TrimEnd()));

                lblLLTotalValue.InnerHtml = (Extent * LandValue).ToString();
            }
            else if (LandTypeSlno == "3")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(txtILExtent.InnerHtml.TrimStart().TrimEnd()));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtILValue.InnerHtml.TrimStart().TrimEnd()));

                lblILTotalValue.InnerHtml = (Extent * LandValue).ToString();
            }
            else if (LandTypeSlno == "4")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(txtGLExtent.InnerHtml.TrimStart().TrimEnd()));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtGLValue.InnerHtml.TrimStart().TrimEnd()));

                lblGLTotalValue.InnerHtml = (Extent * LandValue).ToString();
            }
            else if (LandTypeSlno == "5")
            {
                Extent = Convert.ToDouble(GetDecimalNullValue(lblPLTotalValue.InnerHtml));
                LandValue = Convert.ToDouble(GetDecimalNullValue(txtGLValue.InnerHtml.TrimStart().TrimEnd()));

                lblGLTotalValue.InnerHtml = (Extent * LandValue).ToString();
            }
            else if (LandTypeSlno == "6")
            {
                totalarea1to7.InnerHtml = (Convert.ToDecimal(GetDecimalNullValue(txtMFSArea.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(txtWarehouseArea.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(txtOfficeArea.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(txtCWPArea.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(txtBoilerArea.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(txtETPArea.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(txtOTArea.InnerHtml))).ToString();

                totalcost1to7.InnerHtml = (Convert.ToDecimal(GetDecimalNullValue(txtMFSCost.InnerHtml)) +
                Convert.ToDecimal(GetDecimalNullValue(txtWarehouseCost.InnerHtml)) +
                Convert.ToDecimal(GetDecimalNullValue(txtOfficeCost.InnerHtml)) +
                Convert.ToDecimal(GetDecimalNullValue(txtCWPCost.InnerHtml)) +
                Convert.ToDecimal(GetDecimalNullValue(txtBoilerCost.InnerHtml)) +
                Convert.ToDecimal(GetDecimalNullValue(txtETPCost.InnerHtml)) +
                Convert.ToDecimal(GetDecimalNullValue(txtOTACost.InnerHtml))).ToString();

                totalarea8to18.InnerHtml = (Convert.ToDecimal(GetDecimalNullValue(txtFGArea.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(txtAFArea.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(txtCWArea.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(txtCWPArea.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(txtWQArea.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(txtCanteenArea.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(txtRHArea.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(txtTOArea.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(txtCSArea.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(txtSSArea.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(txtToiletArea.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(txtRoadsArea.InnerHtml))).ToString();

                totalcost8to18.InnerHtml = (Convert.ToDecimal(GetDecimalNullValue(txtFGCost.InnerHtml)) +
                Convert.ToDecimal(GetDecimalNullValue(txtAFCost.InnerHtml)) +
                Convert.ToDecimal(GetDecimalNullValue(txtCWCost.InnerHtml)) +
                Convert.ToDecimal(GetDecimalNullValue(txtWQCost.InnerHtml)) +
                Convert.ToDecimal(GetDecimalNullValue(txtCanteenCost.InnerHtml)) +
                Convert.ToDecimal(GetDecimalNullValue(txtRHCost.InnerHtml)) +
                Convert.ToDecimal(GetDecimalNullValue(txtTOCost.InnerHtml)) +
                Convert.ToDecimal(GetDecimalNullValue(txtCSCost.InnerHtml)) +
                Convert.ToDecimal(GetDecimalNullValue(txtSSCost.InnerHtml)) +
                Convert.ToDecimal(GetDecimalNullValue(txtToiletCost.InnerHtml)) +
                Convert.ToDecimal(GetDecimalNullValue(txtRoadsCost.InnerHtml))).ToString();


                totalarea1to18.InnerHtml = (Convert.ToDecimal(GetDecimalNullValue(totalarea1to7.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(totalarea8to18.InnerHtml))).ToString();

                totalcost1to18.InnerHtml = (Convert.ToDecimal(GetDecimalNullValue(totalcost1to7.InnerHtml)) +
                    Convert.ToDecimal(GetDecimalNullValue(totalcost8to18.InnerHtml))).ToString();
            }
            else if (LandTypeSlno == "7")
            {

                lblTotalExtentinAcre.InnerHtml = (Convert.ToDouble(GetDecimalNullValue(txtPLExtent.InnerHtml)) +
                    Convert.ToDouble(GetDecimalNullValue(txtLLExtent.InnerHtml)) +
                    Convert.ToDouble(GetDecimalNullValue(txtILExtent.InnerHtml)) +
                    Convert.ToDouble(GetDecimalNullValue(txtGLExtent.InnerHtml))).ToString();

                lblTotalValueOfLand.InnerHtml = (Convert.ToDouble(GetDecimalNullValue(lblPLTotalValue.InnerHtml)) +
                    Convert.ToDouble(GetDecimalNullValue(lblLLTotalValue.InnerHtml)) +
                    Convert.ToDouble(GetDecimalNullValue(lblILTotalValue.InnerHtml)) +
                    Convert.ToDouble(GetDecimalNullValue(lblGLTotalValue.InnerHtml))).ToString();
            }
        }
        public string GetDecimalNullValue(string Input)
        {
            string InputValue = "";

            InputValue = (Input != "") ? Input : "0";

            return InputValue;
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

                    grdPandM2.DataSource = ds.Tables[0];
                    grdPandM2.DataBind();

                    grdPandM3.DataSource = ds.Tables[0];
                    grdPandM3.DataBind();

                    decimal TotalValueofNewMachinery = 0, Secondhandmachinery = 0;
                    decimal TotalValueofTextileProducts = 0, TotalValueofNonTextileProducts = 0, TotalValueofAllTextileProducts;

                    foreach (GridViewRow gvrow in grdPandM3.Rows)
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

                        string lblClassificationofMachinery = (gvrow.FindControl("lblClassificationofMachinery") as Label).Text;
                        if (lblClassificationofMachinery.ToUpper().Contains("NON TEXTILE PRODUCTS"))
                        {
                            TotalValueofNonTextileProducts = TotalValueofNonTextileProducts + Convert.ToDecimal(GetDecimalNullValue(Value));
                        }
                        else if(lblClassificationofMachinery.ToUpper().Contains("TEXTILE PRODUCTS"))
                        {
                            TotalValueofTextileProducts = TotalValueofTextileProducts + Convert.ToDecimal(GetDecimalNullValue(Value));
                        }
                        
                    }

                    lblTotalValueofNewMachinery.InnerHtml = TotalValueofNewMachinery.ToString();
                    lblSecondhandmachinery.InnerHtml = Secondhandmachinery.ToString();

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
            Dsnew = caf.GenericFillDs("USP_GET_PLANTANDMACHINERY", pp);
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
            dsnew1 = caf.GenericFillDs("[USP_GET_ALLINCENTIVES_APPLICANT_DRAFT]", pp);

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