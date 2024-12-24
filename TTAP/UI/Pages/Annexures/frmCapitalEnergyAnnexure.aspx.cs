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
    public partial class frmCapitalEnergyAnnexure : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        General Gen = new General();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IncentiveID"] != null)
            {
                string IncentiveID = Request.QueryString["IncentiveID"].ToString();
                GetCapitalAssistanceCreationEnergy("", IncentiveID);
                BindEquipmentDtls(IncentiveID);
                GetIncetiveAttachements(IncentiveID, "N", "2");
            }
        }

        public void GetCapitalAssistanceCreationEnergy(string uid, string IncentiveID)
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
                    string TypeOfIndustry = dsnew.Tables[0].Rows[0]["TypeOfIndustry"].ToString();
                    if (TypeOfIndustry == "1")
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCP"].ToString();
                    }
                    else
                    {
                        lblDCPdate.InnerText = dsnew.Tables[0].Rows[0]["DCPExp"].ToString();
                    }
                    lblCategoryofUnit.InnerText = dsnew.Tables[0].Rows[0]["Category"].ToString();
                    lblActivityoftheUnit.InnerText = dsnew.Tables[0].Rows[0]["TextileProcessName"].ToString();
                }

                DataSet ds = new DataSet();
                SqlParameter[] p = new SqlParameter[] {
                    new SqlParameter("@created_BY",SqlDbType.VarChar),
                    new SqlParameter("@IncentiveID",SqlDbType.VarChar)
                };
                p[0].Value = uid;
                p[1].Value = IncentiveID;
                ds = Gen.GenericFillDs("USP_GET_CAPITALASSISTANCEFORCREATIONENERGY", p);
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.ToString() != "" && ds.Tables[0].Rows.ToString() != null)
                {
                    string TypeofInfrastructure = ds.Tables[0].Rows[0]["TypeofInfrastructure"].ToString();
                    if (TypeofInfrastructure != "")
                    {
                        string[] TypeofInfrastructureVal = TypeofInfrastructure.Split(',');

                        foreach (string Value in TypeofInfrastructureVal)
                        {
                            int Index = chkTypeofInfrastructure.Items.IndexOf(chkTypeofInfrastructure.Items.FindByValue(Value));
                            chkTypeofInfrastructure.Items[Index].Selected = true;
                        }
                    }

                    RbtnCETPcreated.InnerHtml = ds.Tables[0].Rows[0]["CreatedCETPText"].ToString();
                    RbtnTextTileType.InnerHtml = ds.Tables[0].Rows[0]["TextTileTypeText"].ToString();

                    txtTotalCostCapital.InnerHtml = ds.Tables[0].Rows[0]["TotalCostCapital"].ToString();
                    txtMLDofInputWater.InnerHtml = ds.Tables[0].Rows[0]["OperationalCostMLDofInputWater"].ToString();

                    txtGOI.InnerHtml = "GOI : " + ds.Tables[0].Rows[0]["GOI"].ToString() + " <br/>StateGovt : " +
                    ds.Tables[0].Rows[0]["StateGovt"].ToString() + " <br/>Beneficiary : " +
                    ds.Tables[0].Rows[0]["Beneficiary"].ToString() + "  <br/>Bank : " +
                    ds.Tables[0].Rows[0]["Bank"].ToString();

                    txtSubsidyClaimedEnergyWaterEnvironmental.InnerHtml = ds.Tables[0].Rows[0]["AmountSubsidyClaimedEnergy"].ToString();
                    txtSubsidyClaimedforCommonEffluentTreatment.InnerHtml = ds.Tables[0].Rows[0]["AmountSubsidyClaimedEffluent"].ToString();

                    txtEnergyEquipment.InnerHtml = ds.Tables[0].Rows[0]["EnergyEquipment"].ToString();
                    txtWaterEquipment.InnerHtml = ds.Tables[0].Rows[0]["WaterEquipment"].ToString();
                    txtEnvironmentalEquipment.InnerHtml = ds.Tables[0].Rows[0]["EnvironmentalEquipment"].ToString();
                    txtEffluentTreatment.InnerHtml = ds.Tables[0].Rows[0]["EffluentTreatment"].ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void BindEquipmentDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetEquipmentDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    GvEquipmentDtls.DataSource = dsnew.Tables[0];
                    GvEquipmentDtls.DataBind();

                    GvEquipmentDtls2.DataSource = dsnew.Tables[0];
                    GvEquipmentDtls2.DataBind();

                }
                else
                {
                    GvEquipmentDtls.DataSource = null;
                    GvEquipmentDtls.DataBind();

                    GvEquipmentDtls2.DataSource = null;
                    GvEquipmentDtls2.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetEquipmentDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_Equipment_DTLS", pp);
            return Dsnew;
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