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
    public partial class FrmSLCDeatailedReport : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            try
            {
                if (!IsPostBack)
                {
                  
                    if (Session["uid"] != null)
                    {
                        string Incentive_Id = "";
                        lbtnback.PostBackUrl = "~/UI/Pages/MISReports/frmIncentiveReports.aspx";
                        if (Request.QueryString["IncentiveId"] != null)
                        {
                            tblDateSelect.Visible = true;
                            Incentive_Id = Request.QueryString["IncentiveId"].ToString();
                            hfnflag.Value = "Y";
                            BindData(Incentive_Id);
                            DivUnit.Visible = false;
                            DivIncentive.Visible = true;
                        }
                        else
                        {
                            BindSLCData();
                            DivUnit.Visible = true;
                            DivIncentive.Visible = false;
                        }
                        DateTime dateTime = DateTime.UtcNow.Date;
                        Header.InnerHtml = "Report as on " + dateTime.ToString("dd/MM/yyyy");
                    }
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
        public void BindSLCData()
        {  
            dss = GetSLCDetails();
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = dss;
                gvdetailsnew.DataBind();
            }
            else
            {
                gvdetailsnew.DataSource = dss;
                gvdetailsnew.DataBind();
            }
        }
        public void BindData(string Incentive_Id)
        {
            string DateFlag = "N", FromDate = "", ToDate = "";
            if (chkDate.Checked == true)
            {
                DateFlag = "Y"; FromDate = Fromdate.Value; ToDate = Todate.Value;
                Header.InnerHtml = "Report as on " + Fromdate.Value + " to " + Todate.Value;
            }
            dss = GetIncentiveDetails(Incentive_Id, DateFlag, FromDate, ToDate);
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvIncentive.DataSource = dss;
                gvIncentive.DataBind();
            }
            else
            {
                gvIncentive.DataSource = dss;
                gvIncentive.DataBind();
            }
        }

        public DataSet GetSLCDetails()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = caf.GenericFillDs("USP_Get_Slc_List_Details");
            return Dsnew;
        }
        public DataSet GetIncentiveDetails(string Incentive_Id, string DateFlag, string FromDate, string ToDate)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@SubIncentiveId",SqlDbType.VarChar),
               new SqlParameter("@DateFlag",SqlDbType.VarChar),
               new SqlParameter("@FromDate",SqlDbType.VarChar),
               new SqlParameter("@ToDate",SqlDbType.VarChar)
           };
            pp[0].Value = Incentive_Id;
            pp[1].Value = DateFlag;
            pp[2].Value = FromDate;
            pp[3].Value = ToDate;
            Dsnew = caf.GenericFillDs("[USP_Get_Slc_Incentive_Details_Report]", pp);

            return Dsnew;
        }
        public DataSet GetSLCDataList(string SlcId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@SlcNo",SqlDbType.VarChar)
           };
            pp[0].Value = SlcId;
            Dsnew = caf.GenericFillDs("[USP_Get_Slc_Unit_Details_Report]", pp);

            return Dsnew;
        }
        protected void gvdetailsnew_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    GridView Gvlist = (GridView)e.Row.FindControl("gvList");
                    DataSet dsnew = new DataSet();

                    string SlcId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SlcId"));
                    dsnew = GetSLCDataList(SlcId);

                    if (dsnew.Tables.Count > 0)
                    {
                        if (dsnew.Tables[0].Rows.Count > 0)
                        {
                            Gvlist.DataSource = dsnew;
                            Gvlist.DataBind();
                        }
                    }
                }
            }
            catch
            {

            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        protected void BtnExportExcel_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["IncentiveId"] != null)
            {
                ExportToExcel_Incentive();
            }
            else
            {
                ExportToExcel();
            }
        }
        protected void ExportToExcel()
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=R10SLCDetailedReport.xls");
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

                    string label1text = "R10. SLC Detailed Report";
                    string DateText = Header.InnerHtml;
                    string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='13'><h4>" + label1text + "</h4></td></tr><tr><td align='center' colspan='13'><h4>" + DateText + "</h4></td></tr></table>";
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
        protected void ExportToExcel_Incentive()
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=SLCDetailedReport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                //divPMprint.Style["width"] = "680px";

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    gvIncentive.AllowPaging = false;
                    //this.fillgrid();

                    gvIncentive.HeaderRow.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in gvIncentive.HeaderRow.Cells)
                    {
                        cell.BackColor = gvIncentive.HeaderStyle.BackColor;
                        cell.ForeColor = System.Drawing.Color.Black;
                    }
                    foreach (TableCell cell in gvIncentive.FooterRow.Cells)
                    {
                        cell.BackColor = System.Drawing.Color.Black;
                        cell.ForeColor = System.Drawing.Color.Black;
                        // cell.
                    }

                    foreach (GridViewRow row in gvIncentive.Rows)
                    {
                        row.BackColor = System.Drawing.Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = gvIncentive.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = gvIncentive.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }

                    gvIncentive.RenderControl(hw);

                    string label1text = "SLC Detailed Report";
                    string DateText = Header.InnerHtml;
                    string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='13'><h4>" + label1text + "</h4></td></tr><tr><td align='center' colspan='13'><h4>" + DateText + "</h4></td></tr></table>";
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
           string Incentive_Id = Request.QueryString["IncentiveId"].ToString();
            BindData(Incentive_Id);
        }
    }
}