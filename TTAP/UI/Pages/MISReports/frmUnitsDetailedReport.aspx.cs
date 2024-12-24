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
    public partial class frmUnitsDetailedReport : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();
        string DistName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {
                        string Level = "", DistrictId = "";
                        if (Request.QueryString["Level"] != null)
                        {
                            Level = Request.QueryString["Level"].ToString();
                        }

                        if (Request.QueryString["DistrictId"] != null)
                        {
                            DistrictId = Request.QueryString["DistrictId"].ToString();
                        }
                        lbtnback.PostBackUrl = "~/UI/Pages/MISReports/frmIncentiveReports.aspx";
                        /*BindDistricts();*/
                        BindApplicationData();
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
            string Level = "", DistrictId = "", OrderFlag = "",Flag = "";
            if (Request.QueryString["Level"] != null)
            {
                Level = Request.QueryString["Level"].ToString();
            }

            if (Request.QueryString["DistrictId"] != null)
            {
                DistrictId = Request.QueryString["DistrictId"].ToString();
            }
            if (Request.QueryString["Flag"] != null)
            {
                Flag = Request.QueryString["Flag"].ToString();
            }
            dss = GetSubmittedIncentiveList(DistrictId, txtsearch.Text.Trim().TrimStart(), Flag);
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = dss;
                gvdetailsnew.DataBind();
                hdnDistName.Value= dss.Tables[0].Rows[0]["District_Name"].ToString();
                if (Flag == "R")
                {
                    if (Level == "2")
                    {
                        hdnDistName.Value = "All Districts";
                        head.InnerHtml = "Rejected Units Report-All Districts";
                    }
                    else
                    {
                        head.InnerHtml = "Rejected Units Report" + " - " + hdnDistName.Value;
                    }
                }
                else
                {
                    if (Level == "2")
                    {
                        hdnDistName.Value = "All Districts";
                        head.InnerHtml = "Unit Wise Report-All Districts";
                    }
                    else
                    {
                        head.InnerHtml = "Unit Wise Report" + " - " + hdnDistName.Value;
                    }
                }
            }
            else
            {
                gvdetailsnew.DataSource = dss;
                gvdetailsnew.DataBind();
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
                ddlDistrict.Items.Insert(0, "--Select--");
            }
            else
            {
                ddlDistrict.Items.Insert(0, "--Select--");
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindApplicationData();
        }
        protected void Order_Changed(object sender, EventArgs e)
        {
            BindApplicationData();
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtsearch.Text = "";
            BindApplicationData();
        }
        public DataSet GetSubmittedIncentiveList(string DistrictId, string UnitName, string Flag)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UnitName",SqlDbType.VarChar),
               new SqlParameter("@DistrictId",SqlDbType.VarChar),
               new SqlParameter("@FLAG",SqlDbType.VarChar)
           };
            pp[0].Value = UnitName;
            pp[1].Value = DistrictId;
            pp[2].Value = Flag;
            Dsnew = caf.GenericFillDs("USP_GET_DETAILED_SUBMITTED_UNITS", pp);

            return Dsnew;
        }
        public DataSet GetDistrictsList()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = caf.GenericFillDs("GetDistrictsHYD");
            return Dsnew;
        }
        public DataSet GetIncentiveList(string CreatBy)
        {
            string Flags = "";
            if (Request.QueryString["Flag"] != null)
            {
                 Flags = Request.QueryString["Flag"].ToString();
            }
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@CreateBy",SqlDbType.VarChar),
               new SqlParameter("@Flag",SqlDbType.VarChar)
           };
            pp[0].Value = CreatBy;
            pp[1].Value = Flags;
            Dsnew = caf.GenericFillDs("[USP_GET_INCENTIVES_LIST_BY_UNIT]", pp);

            return Dsnew;
        }
        protected void gvdetailsnew_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    GridView Gvlist = (GridView)e.Row.FindControl("gvIncentives");
                    DataSet dsnew = new DataSet();

                    string CreatBy = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CreatedBy"));
                    dsnew = GetIncentiveList(CreatBy);

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
            ExportToExcel();
        }
        protected void ExportToExcel()
        {

            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=R4(A)-UnitWiseReport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
               

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

                    string label1text = "R4(A).UnitWiseReport - "+ hdnDistName.Value;
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

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindApplicationData();
        }
    }
}