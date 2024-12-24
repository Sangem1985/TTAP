using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using TTAP.Classfiles;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace TTAP.UI.Pages.Releases
{
    public partial class frmPartialReleasedListView : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("~/loginReg.aspx");
            }

            if (!IsPostBack)
            {
                string Stage = "";
                string ApplicationMode = "";
                string Category = "";
                string SubIncentiveID = "";
                string GOID = "";

                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString["ApplicationMode"] != null)
                    {
                        ApplicationMode = Request.QueryString["ApplicationMode"].ToString();
                        if (ApplicationMode.ToUpper() == "1")
                        {
                            lblTypeofApplication.InnerText = "SLC";
                        }
                        else if (ApplicationMode.ToUpper() == "2")
                        {
                            lblTypeofApplication.InnerText = "DLC";
                        }
                        else
                        {
                            lblTypeofApplication.InnerText = "SLC & DLC";
                        }
                    }
                    if (Request.QueryString["Stage"] != null)
                    {
                        Stage = Request.QueryString["Stage"].ToString();
                    }
                    DataSet ds = new DataSet();
                    ds = ObjCAFClass.GetPartialReleaseListView(Stage, ApplicationMode, "0", "0", "0");
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        //tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveNameText"].ToString();
                        //h1heading.InnerHtml = ds.Tables[1].Rows[0]["SocialStatusText"].ToString() + " Category";
                        gvdetailsnew.DataSource = ds.Tables[0];
                        gvdetailsnew.DataBind();

                        btnSubmit.Visible = true;
                    }
                    else
                    {
                        btnSubmit.Visible = false;
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
        protected void App_ServerClick(object sender, EventArgs e)
        {
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            Label lblIncentiveID = ((Label)gvdetailsnew.Rows[indexing].FindControl("lblIncentiveID"));
            Label lblSubIncentiveID = ((Label)gvdetailsnew.Rows[indexing].FindControl("lblSubIncentiveID"));
            DataSet ds = new DataSet();
            ds = ObjCAFClass.GetNoOfPartialIncentivesReleases(lblIncentiveID.Text, lblSubIncentiveID.Text);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                GvDetails.DataSource = ds.Tables[0];
                GvDetails.DataBind();
            }
           // centreDetPopup.Style.Add("display", "block");
        }
        [WebMethod]
        public static string GetIncentives(string IncentiveId,string SubIncentiveId)
        {   
            List<Incentive> listIncentive = new List<Incentive>();
            string CS = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("USP_GET_INCENTIVES_PARTAIL_RELEASE_DTLS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@IncentiveId",
                    Value = IncentiveId
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@SubIncentiveId",
                    Value = SubIncentiveId
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@TIPRID",
                    Value = 0
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@FLAG",
                    Value = "A"
                });
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Incentive incentive = new Incentive();
                    incentive.IncentiveID = rdr["IncentiveID"].ToString();
                    incentive.SubIncentiveID = rdr["SubIncentiveID"].ToString();
                    incentive.GOID = rdr["GOID"].ToString();
                    incentive.SanctionedAmount = rdr["SanctionedAmount"].ToString();
                    incentive.PreviousBalanceAmount = rdr["PreviousBalanceAmount"].ToString();
                    incentive.ReleasedAmount = rdr["ReleasedAmount"].ToString();
                    incentive.CurrentBalanceAmount = rdr["CurrentBalanceAmount"].ToString();
                    incentive.ReleaseProcedingNo = rdr["ReleaseProcedingNo"].ToString();
                    incentive.ReleaseProcedingDate = rdr["ReleaseProcedingDate"].ToString();
                    incentive.ReleaseProcedingFilePath = rdr["ReleaseProcedingFilePath"].ToString();
                    incentive.Released_By = rdr["Released_By"].ToString();
                    incentive.Released_Date = rdr["Released_Date"].ToString();
                    incentive.IncentiveName = rdr["IncentiveName"].ToString();
                    incentive.GONo = rdr["GONo"].ToString();
                    incentive.UnitName = rdr["UnitName"].ToString();
                    incentive.ApplicationNumber = rdr["ApplicationNumber"].ToString();
                    incentive.TIPRID = rdr["TIPRID"].ToString();
                    listIncentive.Add(incentive);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(listIncentive);
        }
        [WebMethod]
        public static string GetPath(string TIPRID)
        {
            List<Incentive> listIncentive = new List<Incentive>();
            string CS = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("USP_GET_INCENTIVES_PARTAIL_RELEASE_DTLS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@IncentiveId",
                    Value = "0"
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@SubIncentiveId",
                    Value = "0"
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@TIPRID",
                    Value = TIPRID
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@FLAG",
                    Value = "P"
                });
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Incentive incentive = new Incentive();
                    incentive.ReleaseProcedingFilePath = rdr["ReleaseProcedingFilePath"].ToString();
                    listIncentive.Add(incentive);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(listIncentive);
        }
        public class Incentive
        {
            public string IncentiveID { get; set; }
            public string SubIncentiveID { get; set; }
            public string GOID { get; set; }
            public string SanctionedAmount { get; set; }
            public string PreviousBalanceAmount { get; set; }
            public string ReleasedAmount { get; set; }
            public string CurrentBalanceAmount { get; set; }
            public string ReleaseProcedingNo { get; set; }
            public string ReleaseProcedingDate { get; set; }
            public string ReleaseProcedingFilePath { get; set; }
            public string Released_By { get; set; }
            public string Released_Date { get; set; }
            public string GONo { get; set; }
            public string IncentiveName { get; set; }
            public string UnitName { get; set; }
            public string ApplicationNumber { get; set; }
            public string TIPRID { get; set; }
        }
    }
}