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
using System.IO;

namespace TTAP.UI.Pages.MISReports
{
    public partial class DashboardReport : System.Web.UI.Page
    {
        DataSet dss = new DataSet();
        CAFClass caf = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {
                        BindData();
                    }
                    else
                    {
                        Response.Redirect("~/LoginReg.aspx");
                    }
                }
                else
                {
                   
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {   
            BindData();
        }
        public void BindData()
        {
            string FromDate = "";string ToDates = "";string Flag = "N";
            if (chkDate.Checked == true)
            {
                Flag = "D";
                if (Fromdate.Value == "")
                {
                    Response.Write("<script>alert('Please select From Date');</script>");
                    return;
                }
                if (Todate.Value == "")
                {
                    Response.Write("<script>alert('Please select To Date');</script>");
                    return;
                }
                FromDate = Fromdate.Value;
                ToDates = Todate.Value;
                Header.InnerHtml = "T-TAP - Total Status Report from " + Fromdate.Value + " to " + Todate.Value;
                Header.Style.Add("margin", "0px 0px 0px 286px");
               /* trSanctionedInc.Visible = false;
                trSanctionedAmount.Visible = false;*/
            }
            else
            {
                DateTime dateTime = DateTime.UtcNow.Date;
                Header.InnerHtml = "T-TAP - Total Status Report as on " + dateTime.ToString("dd/MM/yyyy");
            }
            dss = GetData(Session["uid"].ToString(), FromDate, ToDates, Flag);
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {   
                tdTotalUnitss.Text= dss.Tables[0].Rows[0]["TotalUnits"].ToString();
                tdTotalIncentives.Text = dss.Tables[0].Rows[0]["TotalIncentives"].ToString();
                tdTotalEmployment.Text = dss.Tables[0].Rows[0]["DirectEmployees_Local"].ToString();
                tdNonlocalEmployement.Text = dss.Tables[0].Rows[0]["DirectEmployees_Nonlocal"].ToString();
                tdTotalInvestment.Text = dss.Tables[0].Rows[0]["TotalInvestment"].ToString() + "  Cr.";
                tdTotalSubsidyClaimed.Text = dss.Tables[0].Rows[0]["TotalSubsidyClaimed"].ToString() + "  Cr.";
                tdTotalSubsidySanctioned.Text = dss.Tables[0].Rows[0]["TotalSanctionedAmount"].ToString() + "  Cr.";
                tdTotalSanctionedInc.Text = dss.Tables[0].Rows[0]["TotalSanctionedIncentives"].ToString();
            }
        }
        public DataSet GetData(string UserId,string FromDate, string ToDates,string Flag)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
               new SqlParameter("@FromDate",SqlDbType.VarChar),
               new SqlParameter("@ToDate",SqlDbType.VarChar),
               new SqlParameter("@Flag",SqlDbType.VarChar)
           };
            pp[0].Value = UserId;
            pp[1].Value = FromDate;
            pp[2].Value = ToDates;
            pp[3].Value = Flag;
            Dsnew = caf.GenericFillDs("USP_GET_TOTAL_INCENTIVE_STATUS", pp);

            return Dsnew;
        }
    }
}