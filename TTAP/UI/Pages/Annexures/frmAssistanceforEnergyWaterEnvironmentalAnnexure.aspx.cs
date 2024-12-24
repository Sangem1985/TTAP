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
    public partial class frmAssistanceforEnergyWaterEnvironmentalAnnexure : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        CAFClass ObjCAFClass = new CAFClass();
        General Gen = new General();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IncentiveID"] != null)
            {
                string IncentiveID = Request.QueryString["IncentiveID"].ToString();
                GetAssistanceEnergyDetails("", IncentiveID);
                GetIncetiveAttachements(IncentiveID, "N", "7");
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

        public void GetAssistanceEnergyDetails(string uid, string IncentiveID)
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
                ds = Gen.GenericFillDs("USP_GET_AssistanceEnergyExistingUnits", p);
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.ToString() != "" && ds.Tables[0].Rows.ToString() != null)
                {
                    // rblApplicationType.SelectedValue = ds.Tables[0].Rows[0]["NatureofExpenses"].ToString();

                    txtDateofEstablishmentofUnit.InnerHtml = ds.Tables[0].Rows[0]["DateofEstablishmentofUnit"].ToString();
                    RbtnCommercialProduction.InnerText = ds.Tables[0].Rows[0]["CommercialProductionText"].ToString();


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

                    TypeofInfrastructure = ds.Tables[0].Rows[0]["AssistanceRequired"].ToString();
                    if (TypeofInfrastructure != "")
                    {
                        string[] TypeofInfrastructureVal = TypeofInfrastructure.Split(',');

                        foreach (string Value in TypeofInfrastructureVal)
                        {
                            int Index = chkAssistanceRequired.Items.IndexOf(chkAssistanceRequired.Items.FindByValue(Value));
                            chkAssistanceRequired.Items[Index].Selected = true;
                        }
                    }

                    //if (divEnergyAuditConducted.Visible)
                    //{
                    txtEnergyAuditDateofAudit.InnerHtml = ds.Tables[0].Rows[0]["EnergyAuditDateofAudit"].ToString();
                    txtEnergyAuditNameofAuditorAuditFirm.InnerHtml = ds.Tables[0].Rows[0]["EnergyAuditNameofAuditorAuditFirm"].ToString();
                    txtEnergyAuditCostIncurred.InnerHtml = ds.Tables[0].Rows[0]["EnergyAuditCostIncurred"].ToString();
                    txtEnergyAuditInvoiceNumber.InnerHtml = "Invoice : " + ds.Tables[0].Rows[0]["EnergyAuditInvoiceNumber"].ToString() + " Date :" + ds.Tables[0].Rows[0]["EnergyAuditDateofInvoice"].ToString();

                    //}
                    //if (divWaterAuditConducted.Visible)
                    //{
                    txtWaterDateofAudit.InnerHtml = ds.Tables[0].Rows[0]["WaterDateofAudit"].ToString();
                    txtWaterNameofAuditorAuditFirm.InnerHtml = ds.Tables[0].Rows[0]["WaterNameofAuditorAuditFirm"].ToString();
                    txtWaterCostIncurred.InnerHtml = ds.Tables[0].Rows[0]["WaterCostIncurred"].ToString();
                    txtWaterInvoiceNumber.InnerHtml = "Invoice : " + ds.Tables[0].Rows[0]["WaterInvoiceNumber"].ToString() + " Date : " + ds.Tables[0].Rows[0]["WaterDateofInvoice"].ToString();
                    //}
                    //if (divEnvironmentalCompliance.Visible)
                    //{
                    txtEnvironmentalComplianceDateofAudit.InnerHtml = ds.Tables[0].Rows[0]["EnvironmentalComplianceDateofAudit"].ToString();
                    txtNameofCompliance.InnerHtml = ds.Tables[0].Rows[0]["NameofCompliance"].ToString();
                    txtCertifyingAgency.InnerHtml = ds.Tables[0].Rows[0]["CertifyingAgency"].ToString();
                    txtEnvironmentalComplianceCostIncurred.InnerHtml = ds.Tables[0].Rows[0]["EnvironmentalComplianceCostIncurred"].ToString();
                    txtEnvironmentalComplianceInvoiceNumber.InnerHtml = "Invoice : " + ds.Tables[0].Rows[0]["EnvironmentalComplianceInvoiceNumber"].ToString() + " Date : " + ds.Tables[0].Rows[0]["EnvironmentalComplianceDateofInvoice"].ToString();
                    //txtEnvironmentalComplianceDateofInvoice.InnerHtml = ds.Tables[0].Rows[0]["EnvironmentalComplianceDateofInvoice"].ToString();
                    //}

                    txtDateofLastClaim.InnerHtml = ds.Tables[0].Rows[0]["DateofLastClaim"].ToString();


                    TypeofInfrastructure = ds.Tables[0].Rows[0]["NatureofExpenses"].ToString();
                    if (TypeofInfrastructure != "")
                    {
                        string[] TypeofInfrastructureVal = TypeofInfrastructure.Split(',');

                        foreach (string Value in TypeofInfrastructureVal)
                        {
                            int Index = chkNatureofExpenses.Items.IndexOf(chkNatureofExpenses.Items.FindByValue(Value));
                            chkNatureofExpenses.Items[Index].Selected = true;
                        }
                    }
                    txtClaimAmount.InnerHtml = ds.Tables[0].Rows[0]["ClaimAmount"].ToString();
                    txtReimbursementReceived.InnerHtml = ds.Tables[0].Rows[0]["ReimbursementReceived"].ToString();
                    txtGovernmentAmountAvailed.InnerHtml = ds.Tables[0].Rows[0]["GovernmentAmountAvailed"].ToString();
                    txtGovernmentDateAvailed.InnerHtml = ds.Tables[0].Rows[0]["GovernmentDateAvailed"].ToString();
                    txtCurrentClaimEnergyAudit.InnerHtml = ds.Tables[0].Rows[0]["CurrentClaimEnergyAudit"].ToString();
                    txtCurrentClaimWaterAudit.InnerHtml = ds.Tables[0].Rows[0]["CurrentClaimWaterAudit"].ToString();
                    txtCurrentClaimEnvironmentalCompliance.InnerHtml = ds.Tables[0].Rows[0]["CurrentClaimEnvironmentalCompliance"].ToString();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
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