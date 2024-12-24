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

namespace TTAP.UI.Pages.RecommendationLetters
{
    public partial class DLOCoveringLetter : System.Web.UI.Page
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
                    if (Request.QueryString.Count > 0)
                    {
                        UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                        ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                        string IncentiveID = Request.QueryString["IncentiveID"].ToString();
                        string SubIncentiveId = "";
                        // string SubIncentiveId = Request.QueryString["SubIncentiveId"].ToString();
                        BindBesicdata(IncentiveID, SubIncentiveId, ObjLoginNewvo.DistrictID);
                    }
                }
            }
        }

        public void BindBesicdata(string IncentiveID, string SubIncentiveId, string DistrictID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetSubsidyApplicationDeatils(IncentiveID,  SubIncentiveId, DistrictID);
                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    lblletterFrom.Text = dsnew.Tables[0].Rows[0]["District_Name"].ToString();
                    lblLetterNo.Text = dsnew.Tables[0].Rows[0]["LETTERNO"].ToString();
                    lblLetterDate.Text = dsnew.Tables[0].Rows[0]["LETTERNOdDate"].ToString();
                    lblEnterpreneurDetails.Text = dsnew.Tables[0].Rows[0]["UnitName"].ToString() + ", " + dsnew.Tables[0].Rows[0]["UnitAddress"].ToString();
                    lblRefApplicationNo.Text = dsnew.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                    lblRefApplnDate.Text = dsnew.Tables[0].Rows[0]["ApplicationFiledDate"].ToString();
                    lblEnterpreneurDetails1.Text = dsnew.Tables[0].Rows[0]["UnitName"].ToString();
                    lblInspectionReportdated.Text = dsnew.Tables[0].Rows[0]["InspectionDoneOn"].ToString();
                    lblEnterpreneurDetails2.Text = dsnew.Tables[0].Rows[0]["UnitName"].ToString();
                    lblincentivesCount.Text = dsnew.Tables[0].Rows[0]["APPLIEDCOUNT"].ToString();
                    lblincentivesCount1.Text = dsnew.Tables[0].Rows[0]["APPLIEDCOUNT"].ToString();
                    lblInspectionReportdated1.Text = dsnew.Tables[0].Rows[0]["InspectionDoneOn"].ToString();
                    lblincentivesCount2.Text = dsnew.Tables[0].Rows[0]["APPLIEDCOUNT"].ToString();



                    if (dsnew != null && dsnew.Tables.Count > 1 && dsnew.Tables[1].Rows.Count > 0)
                    {
                        gvappliedsubsides.DataSource = dsnew.Tables[1];
                        gvappliedsubsides.DataBind();
                    }
                }
                else
                {

                }

                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                DataSet Dsofficer = new DataSet();
                Dsofficer = GetInspectionOfficerDtls(IncentiveID, SubIncentiveId, ObjLoginNewvo.uid, ObjLoginNewvo.Role_Code, "COVERLETTER");
                if (Dsofficer != null && Dsofficer.Tables.Count > 0 && Dsofficer.Tables[0].Rows.Count > 0)
                {
                    lblGMname.Text = Dsofficer.Tables[0].Rows[0]["OfficerName"].ToString() + "</br>" + Dsofficer.Tables[0].Rows[0]["Designation"].ToString() + "</br>" + "" + Dsofficer.Tables[0].Rows[0]["WorkingDistrict"].ToString();
                    //lblplace.Text = "Date : " + Dsofficer.Tables[0].Rows[0]["CurrentDate"].ToString() + "</br> Location : " + Dsofficer.Tables[0].Rows[0]["Place"].ToString();

                    lblRDDname.Text = Dsofficer.Tables[0].Rows[0]["RDDOfficerName"].ToString() + ", " + Dsofficer.Tables[0].Rows[0]["RDDDesignation"].ToString() + ", " + "" + Dsofficer.Tables[0].Rows[0]["RDDWorkingDistrict"].ToString();

                    //lblDLORDOName.Text = "<b>" + Dsofficer.Tables[0].Rows[0]["OfficerName"].ToString() + "</b>," + Dsofficer.Tables[0].Rows[0]["Designation"].ToString() + "," + "" + Dsofficer.Tables[0].Rows[0]["WorkingDistrict"].ToString() + " and " +
                    //"<b>" + Dsofficer.Tables[0].Rows[0]["RDDOfficerName"].ToString() + "</b>," + Dsofficer.Tables[0].Rows[0]["RDDDesignation"].ToString() + "," + "" + Dsofficer.Tables[0].Rows[0]["RDDWorkingDistrict"].ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
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
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_COVERINGlETTER_DATA", pp);
            return Dsnew;
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
    }
}