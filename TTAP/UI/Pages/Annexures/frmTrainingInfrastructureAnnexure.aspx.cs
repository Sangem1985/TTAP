using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using TTAP.Classfiles;

namespace TTAP.UI.Pages.Annexures
{
    public partial class frmTrainingInfrastructureAnnexure : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        CAFClass ObjCAFClass = new CAFClass();
        General Gen = new General();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IncentiveID"] != null)
            {
                string IncentiveID = Request.QueryString["IncentiveID"].ToString();
                GetTrainingInfrastructure("", IncentiveID);
                GetIncetiveAttachements(IncentiveID, "N", "17");
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
        
      
        public void GetTrainingInfrastructure(string uid, string incentiveid)
        {
            try
            {

                DataSet dsnew = new DataSet();
                dsnew = GetapplicationDtls(uid, incentiveid);
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
                p[1].Value = incentiveid;

                ds = Gen.GenericFillDs("USP_GET_Training_Infrastructure_Apparel_Design_Development", p);


                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows.ToString() != "" && ds.Tables[0].Rows.ToString() != null)
                {
                    txtNameofTrainingCentre.InnerHtml = ds.Tables[0].Rows[0]["NameofTrainingCentre"].ToString();
                    txtEmpanelledDHT.InnerHtml = ds.Tables[0].Rows[0]["EmpanelledDHT"].ToString();
                    txtLocationofTrainingCentre.InnerHtml = ds.Tables[0].Rows[0]["LocationofTrainingCentre"].ToString();
                    txtCoursesoffered.InnerHtml = ds.Tables[0].Rows[0]["Coursesoffered"].ToString();
                    txtBuilding.InnerHtml = ds.Tables[0].Rows[0]["Building"].ToString();
                    txtPlantMachinery.InnerHtml = ds.Tables[0].Rows[0]["PlantMachinery"].ToString();
                    txtInstallationCharges.InnerHtml = ds.Tables[0].Rows[0]["InstallationCharges"].ToString();
                    txtElectrification.InnerHtml = ds.Tables[0].Rows[0]["Electrification"].ToString();
                    txtTrainingAids.InnerHtml = ds.Tables[0].Rows[0]["TrainingAids"].ToString();
                    txtFurniture.InnerHtml = ds.Tables[0].Rows[0]["Furniture"].ToString();
                    lblTotalInvestment.InnerHtml = ds.Tables[0].Rows[0]["TotalInvestment"].ToString();
                    txtCurrentClaim.InnerHtml = ds.Tables[0].Rows[0]["CurrentClaim"].ToString();
                    ddlTypeofTrainingCentre.InnerHtml = ds.Tables[0].Rows[0]["TypeofTrainingCentreText"].ToString();
                    ddlPurpose.InnerHtml = ds.Tables[0].Rows[0]["TrainingCentrePurposeText"].ToString();

                    BindTraineeDtls(incentiveid);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void BindTraineeDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetTraineeDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    GvTraineeDtls.DataSource = dsnew.Tables[0];
                    GvTraineeDtls.DataBind();
                }
                else
                {
                    GvTraineeDtls.DataSource = null;
                    GvTraineeDtls.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetTraineeDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_Trainee_DTLS", pp);
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