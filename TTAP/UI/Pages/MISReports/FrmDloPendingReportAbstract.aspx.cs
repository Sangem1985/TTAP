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

namespace TTAP.UI.Pages.MISReports
{
    public partial class FrmDloPendingReportAbstract : System.Web.UI.Page
    {

        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();

        int NoOfIncentives;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {
                        lbtnback.PostBackUrl = "~/UI/Pages/MISReports/frmIncentiveReports.aspx";

                        dss = GetIncentiveAbstract(Session["uid"].ToString());
                        if (dss.Tables.Count > 0)
                        {
                            if (dss.Tables[0].Rows.Count > 0)
                            {
                                gvdetailsnew.DataSource = dss;
                                gvdetailsnew.DataBind();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
        public DataSet GetIncentiveAbstract(string UserID)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar)
           };
            pp[0].Value = UserID;
            Dsnew = caf.GenericFillDs("USP_GET_DLO_PENDING_ABSTRACT", pp);
            return Dsnew;
        }

        protected void gvdetailsnew_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int NoOfIncentives1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoofIncentivesDLO"));
                NoOfIncentives = NoOfIncentives1 + NoOfIncentives;

                
                Label lblDistrictId = (e.Row.FindControl("lblDistrictId") as Label);

                HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
                if (h1.Text != "0")
                {
                    h1.NavigateUrl = "FormIncentivesReportView.aspx?Level=1&Flag=D&DistrictId=" + lblDistrictId.Text.Trim();
                }
                
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[2].Text = NoOfIncentives.ToString();
               

                HyperLink h1 = new HyperLink();
                h1.Text = NoOfIncentives.ToString();
                if (h1.Text != "0")
                {
                    h1.NavigateUrl = "FormIncentivesReportView.aspx?Level=2&Flag=D&DistrictId=0";
                    e.Row.Cells[2].Controls.Add(h1);
                }
            }
        }
    }
}