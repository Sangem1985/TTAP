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

namespace TTAP.UI.Pages.Annexures
{
    public partial class frmRentalLeaseSubsidyAnnexure : System.Web.UI.Page
    {
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        CAFClass ObjCAFClass = new CAFClass();
        General Gen = new General();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["IncentiveID"] != null)
            {
                string IncentiveID = Request.QueryString["IncentiveID"].ToString();
                GetRentalSubsidyDetails("", IncentiveID);
                BindRentalReimbursementAvailedDtls(IncentiveID);
                BindRentalReimbursementCurrentClaimDtls(IncentiveID);
                GetIncetiveAttachements(IncentiveID, "N", "12");
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
        public void GetRentalSubsidyDetails(string uid, string incentiveid)
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

                ds = Gen.GenericFillDs("USP_GET_Rental_Lease_Subsidy_Built_Space_Dtls", p);


                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0] != null && ds.Tables[0].ToString() != "")
                {
                    txtDateofEstablishmentofUnit.InnerHtml = ds.Tables[0].Rows[0]["DateofEstablishmentofUnit"].ToString();
                    RbtnTextileOrApparelArea.InnerHtml = ds.Tables[0].Rows[0]["TextileOrApparelAreaText"].ToString();

                    RbtnRentalLeasedeed.InnerHtml = ds.Tables[0].Rows[0]["RentalLeaseRegText"].ToString();
                    txtDeedNumber.InnerHtml = ds.Tables[0].Rows[0]["DeedNumber"].ToString();
                    txtDeedDate.InnerHtml = ds.Tables[0].Rows[0]["Deeddate"].ToString();

                    ddlTypeOfUse.InnerHtml = ds.Tables[0].Rows[0]["TypeOfUseText"].ToString();

                    string TypeOfUse = ds.Tables[0].Rows[0]["TypeOfUse"].ToString();
                    if (TypeOfUse == "1")
                    {
                        lblProductionPersonsTrained.InnerHtml = "Annual Production in Rs.";
                    }
                    else if (TypeOfUse == "2")
                    {
                        lblProductionPersonsTrained.InnerHtml = "Persons Trained";
                    }
                    else
                    {
                        lblProductionPersonsTrained.InnerHtml = "Annual Production in Rs./Persons Trained";
                    }

                    txtProductionPersonsTrained.InnerHtml = ds.Tables[0].Rows[0]["ProductionPersonsTrained"].ToString();

                    string TypeofInfrastructure = ds.Tables[0].Rows[0]["RentalInformationType"].ToString();
                    if (TypeofInfrastructure != "")
                    {
                        string[] TypeofInfrastructureVal = TypeofInfrastructure.Split(',');

                        foreach (string Value in TypeofInfrastructureVal)
                        {
                            int Index = chkRentalInformationType.Items.IndexOf(chkRentalInformationType.Items.FindByValue(Value));
                            chkRentalInformationType.Items[Index].Selected = true;
                            if (Value == "2")
                            {
                                txtOtherLeasingArrangement.InnerHtml = ds.Tables[0].Rows[0]["OtherLeasingArrangement"].ToString();
                            }
                        }
                    }



                    txtBuiltUpSpaceOccupied.InnerHtml = ds.Tables[0].Rows[0]["BuiltUpSpaceOccupied"].ToString();
                    txtRentLeaseAmountPerSqMtr.InnerHtml = ds.Tables[0].Rows[0]["RentLeaseAmountPerSqMtr"].ToString();
                    txtTotalMonthlyNetRent.InnerHtml = ds.Tables[0].Rows[0]["TotalMonthlyNetRent"].ToString();
                    txtPeriodofLeaseFromDate.InnerHtml = ds.Tables[0].Rows[0]["PeriodofLeaseFromDate"].ToString();
                    txtPeriodofLeaseToDate.InnerHtml = ds.Tables[0].Rows[0]["PeriodofLeaseToDate"].ToString();
                    RbtnIsAnyothersubsidy.InnerHtml = ds.Tables[0].Rows[0]["IsAnyothersubsidyText"].ToString();
                    if (ds.Tables[0].Rows[0]["IsAnyothersubsidy"].ToString() == "Y")
                    {
                        othersubsidy1.Visible = true;
                        othersubsidy2.Visible = true;
                    }
                    txtSubsidySource.InnerHtml = ds.Tables[0].Rows[0]["SubsidySource"].ToString();
                    txtSubsidySourceAmount.InnerHtml = ds.Tables[0].Rows[0]["SubsidySourceAmount"].ToString();
                    txtClaimApplicationsubmitted.InnerHtml = ds.Tables[0].Rows[0]["ClaimApplicationsubmitted"].ToString();
                    //txtFromDateOfClaimAmount.InnerHtml = "From Date : " + ds.Tables[0].Rows[0]["FromDateOfClaimAmount"].ToString() + "  To Date : " + ds.Tables[0].Rows[0]["ToDateOfClaimAmount"].ToString();
                    txtReimbursementAmountClaimed.InnerHtml = ds.Tables[0].Rows[0]["ReimbursementAmountClaimed"].ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        protected void BindRentalReimbursementCurrentClaimDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetRentalReimbursementCurrentClaimDtls(INCENTIVEID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    grdSGSTReimbursementClaim.DataSource = dsnew.Tables[0];
                    grdSGSTReimbursementClaim.DataBind();
                }
                else
                {
                    grdSGSTReimbursementClaim.DataSource = null;
                    grdSGSTReimbursementClaim.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetRentalReimbursementCurrentClaimDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_RentalSubsidy_Reimbursement_CurrentClaim", pp);
            return Dsnew;
        }
        protected void BindRentalReimbursementAvailedDtls(string INCENTIVEID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetRentalReimbursementAvailedDtls(INCENTIVEID);

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

        public DataSet GetRentalReimbursementAvailedDtls(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_RentalSubsidy_Reimbursement_AvailedDTLS", pp);
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