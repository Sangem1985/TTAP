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
    public partial class FormIncentiveWiseAbstract : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();

        int NoofClaims;
        decimal TotalAmountClaimed;

        int TotalSanctioned;
        decimal TotalAmountSanctioned;

        int NoofIncentivesRejected;
        decimal TotalRejectedAmount;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {
                        lbtnback.PostBackUrl = "~/UI/Pages/MISReports/frmIncentiveReports.aspx";
                        DateTime dateTime = DateTime.UtcNow.Date;
                        Header.InnerHtml = "T-TAP - Total Incentive Wise Report as on " + dateTime.ToString("dd/MM/yyyy");
                        BindGrid();
                    }
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
        public void BindGrid()
        {
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
        public DataSet GetIncentiveAbstract(string UserID)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar)
           };
            pp[0].Value = UserID;

            Dsnew = caf.GenericFillDs("USP_GET_INCENTIVE_WISE_ABSTRACT", pp);

            return Dsnew;
        }

        protected void gvdetailsnew_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int NoofClaims1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoofClaims"));
                NoofClaims = NoofClaims1 + NoofClaims;

                decimal TotalAmountClaimed1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalAmountClaimed"));
                TotalAmountClaimed = TotalAmountClaimed1 + TotalAmountClaimed;

                int TotalSanctioned1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalSanctioned"));
                TotalSanctioned = TotalSanctioned1 + TotalSanctioned;

                decimal TotalAmountSanctioned1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalAmountSanctioned"));
                TotalAmountSanctioned = TotalAmountSanctioned1 + TotalAmountSanctioned;

                int NoofIncentivesRejected1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoofIncentivesRejected"));
                NoofIncentivesRejected = NoofIncentivesRejected1 + NoofIncentivesRejected;

                decimal TotalRejectedAmount1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalRejectedAmount"));
                TotalRejectedAmount = TotalRejectedAmount1 + TotalRejectedAmount;

                Label lblIncentiveId = (e.Row.FindControl("lblIncentiveId") as Label);

                HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
                if (h1.Text != "0")
                {
                    h1.NavigateUrl = "frmIncentiveWiseRpt.aspx?IncentiveId=" + lblIncentiveId.Text.Trim();
                }
                HyperLink h2 = (HyperLink)e.Row.Cells[6].Controls[0];
                if (h2.Text != "0")
                {
                    h2.NavigateUrl = "FrmSLCDeatailedReport.aspx?IncentiveId=" + lblIncentiveId.Text.Trim();
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[2].Text = NoofClaims.ToString();
                e.Row.Cells[3].Text = TotalAmountClaimed.ToString();
                e.Row.Cells[4].Text = NoofIncentivesRejected.ToString();
                e.Row.Cells[5].Text = TotalRejectedAmount.ToString();
                e.Row.Cells[6].Text = TotalSanctioned.ToString();
                e.Row.Cells[7].Text = TotalAmountSanctioned.ToString();

                HyperLink h1 = new HyperLink();
                h1.Text = NoofClaims.ToString();
                if (h1.Text != "0")
                {
                    h1.NavigateUrl = "frmIncentiveWiseRpt.aspx?IncentiveId=0";
                    e.Row.Cells[2].Controls.Add(h1);
                }
                HyperLink h2 = new HyperLink();
                h2.Text = TotalSanctioned.ToString();
                if (h2.Text != "0")
                {
                    h2.NavigateUrl = "FrmSLCDeatailedReport.aspx?IncentiveId=0";
                    e.Row.Cells[6].Controls.Add(h2);
                }
                /* HyperLink h2 = new HyperLink();
                 h2.Text = TotalAmountClaimed.ToString();
                 if (h2.Text != "0")
                 {
                     h2.NavigateUrl = "frmIncentiveWiseRpt.aspx?Level=2&Flag=R&DistrictId=%";
                     e.Row.Cells[3].Controls.Add(h2);
                 }*/
            }
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
                Response.AddHeader("content-disposition", "attachment;filename=R3-IncentiveWiseAbstract.xls");
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
                        cell.BackColor = System.Drawing.Color.White;
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

                    string label1text = "R3. Incentive Wise Abstract";
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
    }
}