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
    public partial class CapitalSubsidyDetailedReport : System.Web.UI.Page
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
                        lbtnback.PostBackUrl = "~/UI/Pages/MISReports/frmIncentiveReports.aspx";
                        BindDistricts();
                        string Status = "";

                        if (Request.QueryString["Status"] != null)
                        {
                            Status = Request.QueryString["Status"].ToString();
                            hdnStatus.Value = Status;
                            if (Request.QueryString["DistId"].ToString() == "")
                            {
                                ddlDistrict.SelectedValue = "0";
                            }
                            else
                            {
                                ddlDistrict.SelectedValue = Request.QueryString["DistId"].ToString();
                            }
                            lbtnback.PostBackUrl = "~/UI/Pages/MISReports/CapitalSubsiyReportAbstract.aspx";
                            BindData();
                        }
                    }
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
        public void BindData()
        {
            string Distid = "";
            if (ddlDistrict.SelectedValue == "0") { Distid = ""; }
            else { Distid = ddlDistrict.SelectedValue.ToString(); }
            dss = GetSubmittedUnitList(hdnStatus.Value, Distid);
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = dss;
                gvdetailsnew.DataBind();
                A2.Visible = true;
            }
            else
            {
                A2.Visible = false;
                gvdetailsnew.DataSource = dss;
                gvdetailsnew.DataBind();
            }
        }
        public DataSet GetSubmittedUnitList(string Status,string Distid)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@Status",SqlDbType.VarChar),
               new SqlParameter("@DistrictId",SqlDbType.VarChar)
           };
            pp[0].Value = Status;
            pp[1].Value = Distid;
            Dsnew = caf.GenericFillDs("USP_GET_CAPITALSUBSIDY_STATUSWISE_REPORT", pp);

            return Dsnew;
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
                Response.AddHeader("content-disposition", "attachment;filename=R12Report.xls");
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

                    string label1text = "";
                    string Header = "";
                    string STAT = hdnStatus.Value.ToString();
                    if (STAT == "1")
                    {
                        Header = "Total No of Units Applied for Capital Subsidy";
                    }
                    if (STAT == "2")
                    {
                        Header = "No of Units Pending at Payment Verification";
                    }
                    if (STAT == "3")
                    {
                        Header = "No of Units Pending at DLO";
                    }
                    if (STAT == "4")
                    {
                        Header = "No of Units Pending at Applicant";
                    }
                    if (STAT == "5")
                    {
                        Header = "No of Units Pending at Head Office";
                    }
                    if (STAT == "6")
                    {
                        Header = "No of Units Rejected";
                    }
                    if (STAT == "7")
                    {
                        Header = "No of Units Pending at DLO for Revised Inspection";
                    }
                    if (STAT == "8")
                    {
                        Header = "No of Units Sanctioned";
                    }
                    if (STAT == "9")
                    {
                        Header = "No of Units Released";
                    }
                    DateTime dateTime = DateTime.UtcNow.Date;

                    if (ddlDistrict.SelectedValue == "0")
                    {
                        label1text = Header;
                    }
                    else
                    {
                        label1text = ddlDistrict.SelectedItem.ToString() + " - " + Header;
                    }
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
        public void BindDistricts()
        {
            dss = GetDistrictsList();
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                ddlDistrict.DataSource = dss;
                ddlDistrict.DataTextField = "District_Name";
                ddlDistrict.DataValueField = "District_Id";
                ddlDistrict.DataBind();
                AddSelect(ddlDistrict);
            }
            else
            {
                AddSelect(ddlDistrict);
            }
        }
        public DataSet GetDistrictsList()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = caf.GenericFillDs("GetDistrictsHYD");
            return Dsnew;
        }
        public void AddSelect(DropDownList ddl)
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
    }
}