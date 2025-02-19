using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataAccessLayer;
using TTAP.Classfiles;
using System;


namespace TTAP.UI.Pages
{
    public partial class CapitalSubsidy : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString);
        General Gen = new General();
        CAFClass ObjCAFClass = new CAFClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            string IncentiveId = Request.QueryString["incid"].ToString();
            string MasterIncentiveId = Request.QueryString["mstid"].ToString();
            getDetails();
            // string incid = Request.QueryString["incid"].ToString();
            //string Type = "New";
            //getLOAData(incid, Type);
        }

        public void getLOAData(string incid, string Type)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetLineofActivityDtls(incid, Type);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    if (Type == "New")
                    {
                        GvLineOfactivityDetails.DataSource = dsnew.Tables[0];
                        GvLineOfactivityDetails.DataBind();
                        divLineNew.Visible = true;

                    }
                    else
                    {
                        GvLineOfactivityExpnsionDetails.DataSource = dsnew.Tables[0];
                        GvLineOfactivityExpnsionDetails.DataBind();
                        divLineExp.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void getDetails()
        {
            string IncentiveId = Request.QueryString["incid"];
            int INC_QDID = 4;

            if (string.IsNullOrEmpty(IncentiveId))
            {
                // Handle missing parameters
                return;
            }

            using (SqlConnection osqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString))
            {
                osqlConnection.Open();
                using (SqlDataAdapter da = new SqlDataAdapter("USP_APPRAISAL_CAPITALSUBSIDYNOTE", osqlConnection))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    //da.SelectCommand.Parameters.Add("@INC_QDID", SqlDbType.Int).Value = INC_QDID;  // Required parameter
                    da.SelectCommand.Parameters.Add("@INC_INCENTIVEID", SqlDbType.Int).Value = Convert.ToInt32(IncentiveId);

                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        DataRow row = ds.Tables[0].Rows[0];

                        // Binding fields to labels

                        lblApplication_no.Text = row["APPLICATION_NO"].ToString();
                        lblUnitname.Text = row["INC_NAMEOFINDUSTRIAL"].ToString();
                        lblLocaddress.Text = row["INC_LOCATIONOFINDUSTRIAL"].ToString();
                        lblPromoterName.Text = row["INC_NAMEOFPROMOTER"].ToString();
                        lblConstitutionOfIndustrial.Text = row["INC_ConstitutionOFINDUSTRIAL"].ToString();
                        lblSocialStatus.Text = row["INC_SOCIALSTATUS"].ToString();
                        lblEntrprName.Text = row["INC_WOMENENTERPRENEUR"].ToString();
                        lblwomen.Text = row["INC_WOMENENTERPRENEUR"].ToString();
                        lblSSIRegn.Text = row["INC_PMTSSIREGISTRATIONNO"].ToString();
                        lblNewExpnDiver.Text = row["INC_NED_UNIT"].ToString();

                        lblCommencmentOfCommrclProdcn_Date.Text = row["INC_DATEOFPRODUCTION"].ToString();


                        lblApplicationDateDIC.Text = row["INC_DICFILLINGDATE"].ToString();
                        lblFinInstn.Text = row["INC_NAMEFINANCINGUNIT"].ToString();
                        lblclaimperiod.Text = row["DATEOFCOMMENCEMENTOFACTIVITY"].ToString();  //claim period
                        lblCaste.Text = row["INC_CASTE"].ToString();
                        lblGender.Text = row["INC_GENDER"].ToString();
                        lblCategory.Text = row["INC_CATEGORY"].ToString();
                        lblCatCaste.Text = row["INC_SECTOR"].ToString();


                        lblLand.Text = row["LAND_APPROVED_COST"].ToString();
                        lblBuilding.Text = row["BUILDING_APPROVED_COST"].ToString();
                        lblPlantMachinery.Text = row["PM_APPROVED_COST"].ToString();
                        lblTechnicalKnowhow.Text = row["KEY_APPROVED_CHARGES"].ToString();
                        lbltotal.Text = row["TOTAL_APPROVED_COST"].ToString();

                        lblLandValue.Text = row["LAND_COMP_COST"].ToString();
                        lblBuildingValue.Text = row["BUILDING_COMP_COST"].ToString();
                        lblPlantMachineryValue.Text = row["PM_COMP_COST"].ToString();
                        lblTechnicalKnowhowValue.Text = row["KEY_COMP_CHARGES"].ToString();
                        lbltotalValue.Text = row["TOTAL_COMP_COST"].ToString();

                        lblIndustryStatus.Text = row["INDUSTRY_STATUS_INS"].ToString();
                        lblConventionalTech.Text = row["TYPE_OF_TEXTILE_INS"].ToString();
                        lblTextileProcessType.Text = row["NATURE_INDUSTRY_INS"].ToString();
                        lblCategory.Text = row["CATEGORY_INDUSTRY_INS"].ToString();
                        lblCaste.Text = row["SOCIAL_STATUS_INS"].ToString();
                        lblGender.Text = row["GENDER_INS"].ToString();
                        lblEligibility.Text = row["TYPE"].ToString();
                        lblEligibilitySub.Text = row["ELIGIBLE_PER_SUBSIDY"].ToString();
                        lblSubsidyAmount.Text = row["ELIGIBLE_SUBSIDY_AMOUNT"].ToString();
                        lblAddSubAmount.Text = row["ADDITIONAL_SUBSIDY_AMOUNT"].ToString();
                        lblTotalSubAmt.Text = row["TOTAL_SUBSIDY_AMOUNT"].ToString();
                        lblRemarks.Text = row["REMARKS"].ToString();
                        lblDepartment.Text = row["FORWARD_TO"].ToString(); //forwardedto
                                                                           // hylinkattachment.Text = row["WORKSHEET_PATH"].ToString();
                        string worksheetPath = row["WORKSHEET_PATH"].ToString().Trim();

                        lblDetailsConfirmed.Text = string.IsNullOrEmpty(row["REMARKS"].ToString()) ? "NA" : row["REMARKS"].ToString();

                        // Handling attachment download link
                        //if (!string.IsNullOrEmpty(row["WORKSHEET_PATH"].ToString()))
                        //{
                        //    clerkattachment.Visible = true;
                        //    hylinkattachment.Visible = true;
                        //    string encpassword = Gen.Encrypt(row["WORKSHEET_PATH"].ToString(), "SYSTIME");
                        //    hylinkattachment.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                        //}
                        //else
                        //{
                        //    clerkattachment.Visible = false;
                        //    hylinkattachment.Visible = false;
                        //}




                        if (string.IsNullOrEmpty(worksheetPath))
                        {
                            clerkattachment.Visible = false;
                            hylinkattachment.Visible = false;
                        }
                        else
                        {
                            clerkattachment.Visible = true;
                            hylinkattachment.NavigateUrl = worksheetPath;
                            hylinkattachment.Visible = true;
                        }
                    }
                }
            }


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
    }
}