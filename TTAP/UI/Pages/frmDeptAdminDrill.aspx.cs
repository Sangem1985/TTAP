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
using System.IO;


namespace TTAP.UI.Pages
{
    public partial class frmDeptAdminDrill : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
                    ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    if (Session["uid"] != null)
                    {
                        int Stg = 0;
                        if (Request.QueryString["Stg"] != null)
                        {
                            Stg = Convert.ToInt32(Request.QueryString["Stg"].ToString());
                        }
                        if (Session["Search"] != null)
                        {
                            txtsearch.Text = Session["Search"].ToString();
                        }
                        if (Stg == 11 || Stg == 12 || Stg == 13 || Stg == 14 || Stg == 15 || Stg == 16 || Stg == 17)
                        {
                            lbtnback.PostBackUrl = "~/UI/Pages/frmCommissionerDashboard.aspx";
                        }
                        if (ObjLoginvo.Role_Code == "ADMN")
                        {
                            lbtnback.PostBackUrl = "~/UI/Pages/frmDeptAdminDashBoard.aspx";
                        }

                        if (Stg == 11)
                        {
                            pageheader.InnerHtml = "Applications - Total Received";
                        }
                        else if (Stg == 12)
                        {
                            pageheader.InnerHtml = "Applications - Yet to Verify";
                        }
                        else if (Stg == 13)
                        {
                            pageheader.InnerHtml = "Applications - Total Verified & Forwarded To DLO";
                        }
                        else if (Stg == 14)
                        {
                            pageheader.InnerHtml = "Applications -  Total Query Raised";
                        }
                        else if (Stg == 15)
                        {
                            pageheader.InnerHtml = "Applications -  Awaiting for Response";
                        }
                        else if (Stg == 16)
                        {
                            pageheader.InnerHtml = "Applications -  Queries Responded";
                        }
                        else if (Stg == 17)
                        {
                            pageheader.InnerHtml = "Applications -  Total Rejected";
                        }
                        
                        BindApplicationData();
                        Session["Search"] = null;
                    }
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
        public void BindApplicationData()
        {
            int Stg = 0;
            if (Request.QueryString["Stg"] != null)
            {
                Stg = Convert.ToInt32(Request.QueryString["Stg"].ToString());
            }

            dss = GetNEFTRTGSApplications(Session["uid"].ToString(), Stg, txtsearch.Text.Trim().TrimStart());
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = dss;
                gvdetailsnew.DataBind();

                if (Stg == 11 || Stg == 12 || Stg == 13 || Stg == 14 || Stg == 15 || Stg == 16 || Stg == 17)
                {
                    gvdetailsnew.HeaderRow.Cells[8].Text = "Application Date";
                }
                else
                {
                    gvdetailsnew.HeaderRow.Cells[8].Text = "Submitted Date";
                }
            }
            else
            {
                gvdetailsnew.DataSource = dss;
                gvdetailsnew.DataBind();
            }
        }
        public DataSet GetNEFTRTGSApplications(string UserID, int StageId, string UnitName)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UserID",SqlDbType.VarChar),
               new SqlParameter("@StageId",SqlDbType.Int),
               new SqlParameter("@UnitName",SqlDbType.VarChar)
           };
            pp[0].Value = UserID;
            pp[1].Value = StageId;
            pp[2].Value = UnitName;
            // Dsnew = caf.GenericFillDs("USP_GET_DLOAPPLICATIONS", pp);
            Dsnew = caf.GenericFillDs("USP_GET_ADMINAPPLICATIONS_DTLS", pp);

            return Dsnew;
        }
        public DataSet GetIncentiveInfo(string IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveId;
            
            Dsnew = caf.GenericFillDs("USP_GET_ADMINAPPLICATIONS_DTLS", pp);

            return Dsnew;
        }
        protected void btnProcess_Click(object sender, EventArgs e)
        {
            Button ddlDeptnameFnl2 = (Button)sender;
            GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
            Label lblIncentiveID = (Label)row.FindControl("lblIncentiveID");
            Button Button1 = (Button)row.FindControl("btnProcess");

            int Stg = 0;
            if (Request.QueryString["Stg"] != null)
            {
                Stg = Convert.ToInt32(Request.QueryString["Stg"].ToString());
            }
            if (txtsearch.Text.Trim().TrimStart() != "")
            {
                Session["Search"] = txtsearch.Text.Trim().TrimStart();
                //newurl = newurl + "&Search=" + txtsearch.Text.Trim().TrimStart();
            }
            //string newurl = "~/UI/Pages/frmDeptPaymentApproval.aspx?Id=" + lblIncentiveID.Text.Trim() + "&Sts=" + Stg;
            //Response.Redirect(newurl);

            string newurl = "~/UI/frmDLOApplicationDetailsNew.aspx?Id=" + lblIncentiveID.Text.Trim() + "&Sts=" + Stg;
            Response.Redirect(newurl);
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        protected void BtnExportExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        protected void ExportToExcel()
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=R4(B)-IncentiveReport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                //divPMprint.Style["width"] = "680px";

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                  
                        gvdetailsnew.AllowPaging = false;
                        //this.fillgrid();

                        gvdetailsnew.HeaderRow.BackColor = System.Drawing.Color.White;
                        foreach (TableCell cell in gvdetailsnew.HeaderRow.Cells)
                        {
                            cell.BackColor = gvdetailsnew.HeaderStyle.BackColor;
                            cell.ForeColor = System.Drawing.Color.Black;
                        }
                        foreach (TableCell cell in gvdetailsnew.FooterRow.Cells)
                        {
                            cell.BackColor = System.Drawing.Color.Black;
                            cell.ForeColor = System.Drawing.Color.Black;
                            // cell.
                        }

                        foreach (GridViewRow row in gvdetailsnew.Rows)
                        {
                            row.BackColor = System.Drawing.Color.White;
                            foreach (TableCell cell in row.Cells)
                            {
                                if (row.RowIndex % 2 == 0)
                                {
                                    cell.BackColor = gvdetailsnew.AlternatingRowStyle.BackColor;
                                }
                                else
                                {
                                    cell.BackColor = gvdetailsnew.RowStyle.BackColor;
                                }
                                cell.CssClass = "textmode";
                            }
                        }

                        gvdetailsnew.RenderControl(hw);


                    string label1text = "TTAP-Applications";
                    string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='13'><h4>" + label1text + "</h4></td></td></tr></table>";
                    HttpContext.Current.Response.Write(headerTable);
                    HttpContext.Current.Response.Write(sw.ToString());
                    HttpContext.Current.Response.End();

                    //style to format numbers to string
                    string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }

            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindApplicationData();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtsearch.Text = "";
            BindApplicationData();
        }
        [WebMethod]
        public static string GetIncentives(string IncentiveId)
        {
            List<Incentive> listIncentive = new List<Incentive>();
            string CS = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("USP_GET_INCENTIVES_CLAIMPERIOD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@IncentiveId",
                    Value = IncentiveId
                });
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Incentive incentive = new Incentive();
                    incentive.IncentiveName = rdr["IncentiveName"].ToString();
                    incentive.ClaimPeriod = rdr["ClaimPeriod"].ToString();
                    incentive.UnitName = rdr["UnitName"].ToString();
                    incentive.ApplicationNumber = rdr["ApplicationNumber"].ToString();
                    listIncentive.Add(incentive);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(listIncentive);
        }
        [WebMethod]
        public static string GetIncentivesDta(string IncentiveId)
        {

            CAFClass caf = new CAFClass();
            DataSet Dsnew = new DataSet();
            
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_INCENTIVES_CLAIMPERIOD", pp);
            //return Dsnew;
            return Dsnew.GetXml();
        }
        public class Incentive
        {
            public string UnitName { get; set; }
            public string IncentiveName { get; set; }
            public string ClaimPeriod { get; set; }
            public string ApplicationNumber { get; set; }
        }
    }
   
}