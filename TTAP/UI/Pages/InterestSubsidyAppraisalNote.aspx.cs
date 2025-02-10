using System;
using System.Collections.Generic;
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

namespace TTAP.UI.Pages
{
    public partial class InterestSubsidyAppraisalNote : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString);
        General Gen = new General();


        protected void Page_Load(object sender, EventArgs e)
        {
            getDetails();
            string incid = Request.QueryString["incid"].ToString();
        }
        public void getLOAData(DataSet ds1)
        {
            if (ds1 != null && ds1.Tables.Count > 1 && ds1.Tables[1].Rows.Count > 0)
            {
                gvInstalledCap.DataSource = ds1.Tables[1];
                gvInstalledCap.DataBind();
            }

        }
        public void getDetails()
        {
            string IncentiveId = Request.QueryString["incid"].ToString();
            string MasterIncentiveId = Request.QueryString["mstid"].ToString();
            DataSet ds2 = new DataSet();
            ds2 = Gen.GetBasicUnitDetails_Proforma_lettersPSR(IncentiveId, MasterIncentiveId);
            if (MasterIncentiveId == "1" || MasterIncentiveId == "3" || MasterIncentiveId == "5")
            {
                TRCLAIMPERIOD.Visible = true;
                lblclaimperiod.Text = ds2.Tables[1].Rows[0]["GMclaimedfinyear"].ToString();

            }
            SqlConnection osqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString);
            osqlConnection.Open();
            SqlDataAdapter da;
            da = new SqlDataAdapter("USP_GETDETAILSFORSECTION_Appraisal", osqlConnection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = IncentiveId;
            da.SelectCommand.Parameters.Add("@mstincentiveid", SqlDbType.VarChar).Value = MasterIncentiveId;
            da.Fill(ds);

            getLOAData(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Downloadlink"].ToString() != null && ds.Tables[0].Rows[0]["Downloadlink"].ToString() != "")
                {
                    clerkattachment.Visible = true;
                    hylinkattachment.Visible = true;
                    //hylinkattachment.NavigateUrl = ds.Tables[0].Rows[0]["Downloadlink"].ToString();
                    string encpassword = Gen.Encrypt(ds.Tables[0].Rows[0]["Downloadlink"].ToString(), "SYSTIME");
                    hylinkattachment.NavigateUrl = "CS.aspx?filepathnew=" + encpassword;
                }
                else
                {
                    clerkattachment.Visible = false;
                    hylinkattachment.Visible = false;
                }

                if (MasterIncentiveId == "3" || MasterIncentiveId == "5")
                {
                    TRSCHEME.Visible = true;
                    LBLSCHEME.Text = ds.Tables[0].Rows[0]["Scheme"].ToString();

                }
          
                if (ds.Tables[0].Rows[0]["DetailsGm"].ToString() != "")
                    lblDetailsConfirmed.Text = ds.Tables[0].Rows[0]["DetailsGm"].ToString();
                else
                    lblDetailsConfirmed.Text = "NA";
                lblApplication_no.Text = ds.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                lblUnitname.Text = ds.Tables[0].Rows[0]["UnitName"].ToString();
                lblLocaddress.Text = ds.Tables[0].Rows[0]["txtLocofUnit"].ToString();
                lblConstitutionOfIndustrial.Text = ds.Tables[0].Rows[0]["ConstitutionUnit"].ToString();
                lblSocialStatus.Text = ds.Tables[0].Rows[0]["CASTE"].ToString();
                lblPromoterName.Text = ds.Tables[0].Rows[0]["ApplicantName"].ToString();
                lblEntrprName.Text = ds.Tables[0].Rows[0]["ApplicantName"].ToString();
                lblSSIRegn.Text = ds.Tables[0].Rows[0]["EIN_IEM_IL_Number"].ToString();
                lblNewExpnDiver.Text = ds.Tables[0].Rows[0]["TypeOfIndustryText"].ToString();
                lblCommencmentOfCommrclProdcn_Date.Text = ds.Tables[0].Rows[0]["DCP"].ToString();
                //lblApplicationDateDIC.Text = ds.Tables[0].Rows[0]["txtcompdate_dic"].ToString();
                //lblApplicationDateDIC.Text = ds.Tables[0].Rows[0]["txtcompdate_coi"].ToString(); commented on 21.01.2020
                lblApplicationDateDIC.Text = ds.Tables[0].Rows[0]["ApplicationFiledDate"].ToString();
                lblFinInstn.Text = ds.Tables[0].Rows[0]["TBMBankName"].ToString();

                //lblTotal_ProjectCost.Text = ds.Tables[0].Rows[0]["txtWC2"].ToString();
                //string A;
                //string B;
                //string C;
                //if (ds.Tables[0].Rows[0]["txtLand2"].ToString() == "" || ds.Tables[0].Rows[0]["txtLand2"].ToString() == null)
                //{
                //    A = "0";
                //}
                //else
                //{
                //    A = ds.Tables[0].Rows[0]["txtLand2"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["txtBuilding2"].ToString() == "" || ds.Tables[0].Rows[0]["txtBuilding2"].ToString() == null)
                //{
                //    B = "0";
                //}
                //else
                //{
                //    B = ds.Tables[0].Rows[0]["txtBuilding2"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["txtPM2"].ToString() == "" || ds.Tables[0].Rows[0]["txtPM2"].ToString() == null)
                //{
                //    C = "0";
                //}
                //else
                //{
                //    C = ds.Tables[0].Rows[0]["txtPM2"].ToString();
                //}

                //lblTotal_ProjectCost.Text = (Convert.ToDecimal(A) + Convert.ToDecimal(B) + Convert.ToDecimal(C)).ToString();

                ////lblTotal_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["txtWC7"].ToString();
                //string D;
                //string E;
                //string F;
                //if (ds.Tables[0].Rows[0]["txtLand7"].ToString() == "" || ds.Tables[0].Rows[0]["txtLand7"].ToString() == null)
                //{
                //    D = "0";
                //}
                //else
                //{
                //    D = ds.Tables[0].Rows[0]["txtLand7"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["txtBuilding7"].ToString() == "" || ds.Tables[0].Rows[0]["txtBuilding7"].ToString() == null)
                //{
                //    E = "0";
                //}
                //else
                //{
                //    E = ds.Tables[0].Rows[0]["txtBuilding7"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["txtPM7"].ToString() == "" || ds.Tables[0].Rows[0]["txtPM7"].ToString() == null)
                //{
                //    F = "0";
                //}
                //else
                //{
                //    F = ds.Tables[0].Rows[0]["txtPM7"].ToString();
                //}
                //lblTotal_ValueRecommendedByGM.Text = (Convert.ToDecimal(D) + Convert.ToDecimal(E) + Convert.ToDecimal(F)).ToString();

                ////lblTotalComputed.Text = ds.Tables[0].Rows[0]["TextBox2"].ToString();
                //string G;
                //string H;
                //string I;
                //if (ds.Tables[0].Rows[0]["TextBox56"].ToString() == "" || ds.Tables[0].Rows[0]["TextBox56"].ToString() == null)
                //{
                //    G = "0";
                //}
                //else
                //{
                //    G = ds.Tables[0].Rows[0]["TextBox56"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["TextBox57"].ToString() == "" || ds.Tables[0].Rows[0]["TextBox57"].ToString() == null)
                //{
                //    H = "0";
                //}
                //else
                //{
                //    H = ds.Tables[0].Rows[0]["TextBox57"].ToString();
                //}
                //if (ds.Tables[0].Rows[0]["TextBox58"].ToString() == "" || ds.Tables[0].Rows[0]["TextBox58"].ToString() == null)
                //{
                //    I = "0";
                //}
                //else
                //{
                //    I = ds.Tables[0].Rows[0]["TextBox58"].ToString();
                //}
                //lblTotalComputed.Text = (Convert.ToDecimal(G) + Convert.ToDecimal(H) + Convert.ToDecimal(I)).ToString();

                //lblLand_ProjectCost.Text = ds.Tables[0].Rows[0]["txtLandcostCompc"].ToString();

                //lblPlantMachry_ProjectCost.Text = ds.Tables[0].Rows[0]["TextBox30"].ToString();
                //lblFeasibilityStudyCharges_ProjectCost.Text = ds.Tables[0].Rows[0]["TextBox32"].ToString();

                //lblVehicles_ProjectCost.Text = ds.Tables[0].Rows[0]["txtErec2"].ToString();
                //lblVehicles_ValueRecommendedByGM.Text = "-";
                //lblVehiclesComputed.Text = "-";
                //lblVehicles_GMRec.Text = "-";


                //lblOthersEligible_ProjectCost.Text = ds.Tables[0].Rows[0]["txtTFS2"].ToString();
                //lblOthersEligible_ValueRecommendedByGM.Text = "-";
                //lblOthersEligibleComputed.Text = "-";
                //lblOthersEligible_GMRec.Text = "-";

                //lblFeasibilityStudyCharges_ProjectCost.Text = ds.Tables[0].Rows[0]["TextBox44"].ToString();
                //lblFeasibilityStudyCharges_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["TextBox45"].ToString();
                //lblFeasibilityStudyChargesComputed.Text = "-";
                //lblFeasibilityStudyCharges_GMRec.Text = "-";

                //lblPlantMachry_ProjectCost.Text = ds.Tables[0].Rows[0]["txtPM2"].ToString();
                ////lblPlantMachry_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["TextBox58"].ToString();
                //////lblPlantMachryComputed.Text = ds.Tables[0].Rows[0]["TextBox58"].ToString();
                //////lblPlantMachry_GMRec.Text = "-";
                ////lblPlantMachryComputed.Text = ds.Tables[0].Rows[0]["TextBox42"].ToString();
                //lblPlantMachry_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["txtPM7"].ToString();
                //lblPlantMachryComputed.Text = ds.Tables[0].Rows[0]["TextBox58"].ToString();
                //lblPlantMachry_GMRec.Text = ds.Tables[0].Rows[0]["TextBox47"].ToString();

                //lblBuilding_ProjectCost.Text = ds.Tables[0].Rows[0]["txtBuilding2"].ToString();
                ////lblBuilding_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["TextBox57"].ToString();
                //////lblBuildingComputed.Text = "-";
                //////lblBuilding_GMRec.Text = "-";
                ////lblBuildingComputed.Text = ds.Tables[0].Rows[0]["txtCompvalCompc"].ToString();
                //lblBuilding_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["txtBuilding7"].ToString();
                //lblBuildingComputed.Text = ds.Tables[0].Rows[0]["TextBox57"].ToString();
                //lblBuilding_GMRec.Text = ds.Tables[0].Rows[0]["txtrsnCompc"].ToString();

                //lblLand_ProjectCost.Text = ds.Tables[0].Rows[0]["txtLand2"].ToString();
                ////lblLand_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["TextBox56"].ToString();
                //////lblLandComputed.Text = "-";
                //////lblLand_GMRec.Text = "-";
                ////lblLandComputed.Text = ds.Tables[0].Rows[0]["txtvalCompc1"].ToString();
                //lblLand_ValueRecommendedByGM.Text = ds.Tables[0].Rows[0]["txtLand7"].ToString();
                //lblLandComputed.Text = ds.Tables[0].Rows[0]["TextBox56"].ToString();
                //lblLand_GMRec.Text = ds.Tables[0].Rows[0]["txtresonsCompc"].ToString();


                //lblPercent.Text = ds.Tables[0].Rows[0]["TextBox59"].ToString();
                //lblStateInvesSubsidy.Text = ds.Tables[0].Rows[0]["txt423guideline"].ToString();
                //lblAddlSubWomen.Text = ds.Tables[0].Rows[0]["txtTSSFCnorms423"].ToString();
                //lblEligi_TotalSubsidy.Text = ds.Tables[0].Rows[0]["txtvalue424"].ToString();

               
                //
                lblFinalSchemeName.Text = ds.Tables[0].Rows[0]["Scheme"].ToString();
                //distName
                LblDICName.Text = ds.Tables[0].Rows[0]["District_Name"].ToString();
                if (ds.Tables[0].Rows[0]["Remarks"].ToString() != "" && ds.Tables[0].Rows[0]["Remarks"].ToString() != null)
                {
                    LBLREMARKS.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();//UNCOMMENTED BY MADHURI ON 26/09/2022 don't commented again
                }

                if (MasterIncentiveId == "3")
                {
                    //Pallavaddi 
                    div_pallavaddi.Visible = true;
                    Div3.Visible = false;
                    USP_GETDETAILSFORSECTION(Convert.ToString(Request.QueryString["incid"]));
                    //string incid = Request.QueryString["incid"].ToString();
                    lblSancIncentiveName.Text = "Sanction of Pavala Vaddi";
                }
            }

          
        }


        public void USP_GETDETAILSFORSECTION(string IncentiveId)
        {
            DataSet ds = DB_apprasialnote2pallavaddi(IncentiveId, "");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //MstIncentiveId = "1";

                        //txt_eglsacamountinterestreimbursement.Text = Convert.ToString(ds.Tables[0].Rows[0]["ELIGIBLESANCTIONEDAMOUNT"]);
                        //ddl_ClaimPeriod.Text = Convert.ToString(ds.Tables[0].Rows[0]["CLAIMPERIOD"]);
                        //txt_DateofCommencementofactivity.Text = Convert.ToString(ds.Tables[0].Rows[0]["DATEOFCOMMENCEMENTOFACTIVITY"]);
                        //txt_Eligibleperiodinmonths.Text = Convert.ToString(ds.Tables[0].Rows[0]["INSTALMENTPERIOD"]);
                        //txt_noofinstallment.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOOFINSTALMENTS"]);
                        //txt_Installmentamount.Text = Convert.ToString(ds.Tables[0].Rows[0]["INSTALMENTAMOUNT"]);
                        //txt_installmentstartdate.Text = Convert.ToString(ds.Tables[0].Rows[0]["INSTALMENTSTARTMONTHYEAR_ID"]);
                        //txt_RateofInterest.Text = Convert.ToString(ds.Tables[0].Rows[0]["RATEOFINTEREST"]);
                        //txt_Eligiblerateofreimbursement.Text = Convert.ToString(ds.Tables[0].Rows[0]["ELIGIBLERATEOFREUMBERSEMENT"]);
                        //txt_Noofinstallmentscompleted.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOOFINSTALMENTS_COMPLETED"]);
                        //txt_PrincipalamountbecomeDUEbeforethisHALFYEAR.Text = Convert.ToString(ds.Tables[0].Rows[0]["PRINCIPALAMOUNTBECOMEDUE_BEFORETHISHALFYEAR"]);
                        //txt_Insertamounttobepaidaspercalculations.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTAMOUNT_TOBEPAIDASPERCALCULATIONS"]);
                        //txt_Actualinterestamountpaid.Text = Convert.ToString(ds.Tables[0].Rows[0]["ACTUALINTERESTAMOUNT_PAID"]);
                        //txt_Insertreimbursementcalculated.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTREIMBURSEMENTCALCULATED"]);
                        //txt_Insertreimbursementcalculated.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTREIMBURSEMENTCALCULATED_FINAL"]);
                        //txt_GMrecommendedamount.Text = Convert.ToString(ds.Tables[0].Rows[0]["GMRECOMMENDEDAMOUNT"]);
                        //txt_Eligibleamount.Text = Convert.ToString(ds.Tables[0].Rows[0]["FINALELIGIBLEAMOUNT"]);
                        ////rbtgrd_isbelated.Text = Convert.ToString(ds.Tables[0].Rows[0]["EglibleTypeName"]);
                        //txt_eglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTREIMBURSEMENTCALCULATEDaftereglibletype"]);
                        ////ddl_periodofinstallment.Text = Convert.ToString(ds.Tables[0].Rows[0]["PERIODOFINSTALMENTName"]);


                        txt_Insertamounttobepaidaspercalculations.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTAMOUNT_TOBEPAIDASPERCALCULATIONS"]);
                        txt_Actualinterestamountpaid.Text = Convert.ToString(ds.Tables[0].Rows[0]["ACTUALINTERESTAMOUNT_PAID"]);
                        txt_ConsideredAmountofInterest.Text = Convert.ToString(ds.Tables[0].Rows[0]["Conreburismentamount"]);
                        txt_Insertreimbursementcalculated.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTREIMBURSEMENTCALCULATED"]);
                        txt_Insertreimbursementcalculated.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTREIMBURSEMENTCALCULATED_FINAL"]);
                        txt_GMrecommendedamount.Text = Convert.ToString(ds.Tables[0].Rows[0]["GMRECOMMENDEDAMOUNT"]);
                        txt_Eligibleamount.Text = Convert.ToString(ds.Tables[0].Rows[0]["FINALELIGIBLEAMOUNT"]);

                        txt_eglibleamountofreimbursementbyeglibletype.Text = Convert.ToString(ds.Tables[0].Rows[0]["INTERESTREIMBURSEMENTCALCULATEDaftereglibletype"]);
                        lbl_pavallavaddiremarksbyclerk.Text = Convert.ToString(ds.Tables[0].Rows[0]["Remarks"]);
                    }

                    if (ds.Tables.Count >= 1)
                    {
                        if (ds.Tables[1].Rows.Count > 0)
                        {
                            //grd_financalyeargrid.DataSource = ds.Tables[1];
                            //grd_financalyeargrid.DataBind();
                        }

                    }

                    grd_claimperiodofloanadd.Visible = false;
                    if (ds.Tables.Count >= 3)
                    {
                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            grd_claimperiodofloanadd.DataSource = ds.Tables[3];
                            grd_claimperiodofloanadd.DataBind();
                            grd_claimperiodofloanadd.Visible = true;
                        }

                    }
                    grd_eglibilepallavaddi.Visible = false;
                    if (ds.Tables.Count >= 4)
                    {
                        if (ds.Tables[4].Rows.Count > 0)
                        {
                            grd_eglibilepallavaddi.Visible = true;
                            grd_eglibilepallavaddi.DataSource = ds.Tables[4];
                            grd_eglibilepallavaddi.DataBind();
                        }

                    }
                }
            }
        }
        protected void grd_financalyeargrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string CLAIMPERIOD_Grid = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CLAIMPERIOD_Grid"));
                // string CLAIMPERIOD_Grid = grd_financalyeargrid.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView grd_Addclaimperiod = e.Row.FindControl("grd_Addclaimperiod") as GridView;
                DataSet ds_data = DB_apprasialnote2pallavaddi(Convert.ToString(Request.QueryString["incid"]), CLAIMPERIOD_Grid);
                if (ds_data != null)
                {
                    if (ds_data.Tables.Count > 0)
                    {
                        if (ds_data.Tables.Count >= 2)
                        {
                            if (ds_data.Tables[2].Rows.Count > 0)
                            {
                                grd_Addclaimperiod.DataSource = ds_data.Tables[2];
                                grd_Addclaimperiod.DataBind();
                            }

                        }
                    }
                }
            }
        }

        public DataSet DB_apprasialnote2pallavaddi(string IncentiveId, string CLAIMPERIOD_Grid)
        {
            try
            {
                SqlConnection osqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString);
                osqlConnection.Open();
                SqlDataAdapter da;
                da = new SqlDataAdapter("pv_apprasialnote2pallavaddi", osqlConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                if (IncentiveId.Trim() == "" || IncentiveId.Trim() == null)
                    da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    da.SelectCommand.Parameters.Add("@incentiveid", SqlDbType.VarChar).Value = IncentiveId.ToString();
                if (CLAIMPERIOD_Grid.Trim() == "" || CLAIMPERIOD_Grid.Trim() == null)
                    da.SelectCommand.Parameters.Add("@CLAIMPERIOD_Grid", SqlDbType.VarChar).Value = DBNull.Value;
                else
                    da.SelectCommand.Parameters.Add("@CLAIMPERIOD_Grid", SqlDbType.VarChar).Value = CLAIMPERIOD_Grid.ToString();


                da.Fill(ds);
                return ds;



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }
}