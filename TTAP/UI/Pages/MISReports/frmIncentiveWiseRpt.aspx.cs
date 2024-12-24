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
    public partial class frmIncentiveWiseRpt : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        DataSet dss = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {
                        string DistrictId = ""; string Incentive_Id = "";
                        BindIncentives();
                        BindDistricts();
                        if (Request.QueryString["IncentiveId"] != null)
                        {
                            Incentive_Id = Request.QueryString["IncentiveId"].ToString();
                        }
                        if (Request.QueryString.Count > 1)
                        {
                            if (Request.QueryString["DistrictId"] != null)
                            {
                                hdnDistId.Value = Request.QueryString["DistrictId"].ToString();
                                ddlDistrict.SelectedValue= Request.QueryString["DistrictId"].ToString();
                            }
                        }
                        ddlIncentives.SelectedValue = Incentive_Id;
                        ddlIncentives_SelectedIndexChanged(this, EventArgs.Empty);
                        lbtnback.PostBackUrl = "~/UI/Pages/MISReports/FormIncentiveWiseAbstract.aspx";
                        //BindApplications(DistrictId, ddlIncentives.SelectedValue);
                    }
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
        public void BindApplications(string DistrictId, string SubIncentiveID)
        {
            dss = GetSubmittedIncentiveList(DistrictId, SubIncentiveID);
            if (dss.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
                {
                    gvdetailsnew.DataSource = dss;
                    gvdetailsnew.DataBind();
                    divPMprint.Visible = true;
                }
                else
                {
                    divPMprint.Visible = false;
                }
            }
            else
            {
                divPMprint.Visible = false;
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
                ddlDistrict.Items.Insert(0, "All");
            }
            else
            {
                ddlDistrict.Items.Insert(0, "--Select--");
            }
        }
        public DataSet GetDistrictsList()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = ObjCAFClass.GenericFillDs("GetDistrictsHYD");
            return Dsnew;
        }
        public void BindIncentives()
        {
            try
            {
                DataSet ApprovedIncentives = new DataSet();
                ddlIncentives.Items.Clear();
                ApprovedIncentives = GetIncentives();
                if (ApprovedIncentives != null && ApprovedIncentives.Tables.Count > 0 && ApprovedIncentives.Tables[0].Rows.Count > 0)
                {
                    ddlIncentives.DataSource = ApprovedIncentives.Tables[0];
                    ddlIncentives.DataValueField = "IncentiveID";
                    ddlIncentives.DataTextField = "IncentiveName";
                    ddlIncentives.DataBind();
                    AddSelect(ddlIncentives);
                }
                else
                {
                    AddSelect(ddlIncentives);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddSelect(DropDownList ddl)
        {
            try
            {
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                //lblmsg0.Text = ex.Message;
                //Failure.Visible = true;
                //success.Visible = false;
            }
        }
        public DataSet GetIncentives()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_INCENTIVES");
            return Dsnew;
        }

        public DataSet GetSubmittedIncentiveList(string DistrictId, string SubIncentiveID)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DistrictId",SqlDbType.VarChar),
                new SqlParameter("@SubIncentiveID",SqlDbType.VarChar)
           };
            pp[0].Value = DistrictId;
            pp[1].Value = SubIncentiveID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_SUBSIDYWISE_REPORT", pp);

            return Dsnew;
        }

        protected void ddlIncentives_SelectedIndexChanged(object sender, EventArgs e)
        {   
           
            if (ddlIncentives.SelectedValue == "0")
            {
                hincentiveName.InnerHtml = "All Incentives";
            }
            string DistrictId = "";
            DistrictId = hdnDistId.Value.ToString();
            if (DistrictId == "") {
                hincentiveName.InnerHtml = ddlIncentives.SelectedItem.Text;
            }
            else
            {
                hincentiveName.InnerHtml = ddlIncentives.SelectedItem.Text + " - " + ddlDistrict.SelectedItem.ToString();
            }
            
            BindApplications(DistrictId, ddlIncentives.SelectedValue);
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
                Response.AddHeader("content-disposition", "attachment;filename=R3-IncentiveWiseReport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                divPMprint.Style["width"] = "680px";

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

                    string label1text = hincentiveName.InnerHtml;
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
        public void ExportAv(string fileName, GridView[] gvs)
        {
            try
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
                HttpContext.Current.Response.ContentType = "application/ms-excel";
                System.IO.StringWriter sw = new System.IO.StringWriter();
                HtmlTextWriter htw = new HtmlTextWriter(sw);

                //Label1.Text = "";

                foreach (GridView gv in gvs)
                {
                    gv.AllowPaging = false;

                    //   Create a form to contain the grid
                    System.Web.UI.WebControls.Table table = new System.Web.UI.WebControls.Table();

                    table.GridLines = gv.GridLines;
                    //   add the header row to the table
                    if (!(gv.Caption == null))
                    {

                        TableCell cell = new TableCell();
                        cell.Text = gv.Caption;
                        cell.ColumnSpan = 6;
                        TableRow tr = new TableRow();
                        tr.Controls.Add(cell);
                        table.Rows.Add(tr);
                    }
                    // table.Rows.Add(
                    if (gv.ID == "gvdetailsnew")
                    {

                        TableCell cell = new TableCell();
                        cell.Text = "PRESCRUTINY STAGE : STATUS";
                        cell.ColumnSpan = 6;
                        cell.Height = 20;
                        // cell. = 20;

                        cell.VerticalAlign = VerticalAlign.Middle;
                        TableRow tr = new TableRow();
                        tr.Controls.Add(cell);
                        table.Rows.Add(tr);

                    }
                    
                    if (!(gv.HeaderRow == null))
                    {
                        table.Rows.Add(gv.HeaderRow);
                    }
                    //   add each of the data rows to the table
                    foreach (GridViewRow row in gv.Rows)
                    {
                        table.Rows.Add(row);
                    }
                    
                    table.RenderControl(htw);
                }
                //   render the htmlwriter into the response

                string label1text = hincentiveName.InnerHtml;
                string headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='6'><h4>" + "" + "</h4></td></td></tr><tr><td align='center' colspan='6'><h4>" + label1text + "</h4></td></td></tr></table>";
                HttpContext.Current.Response.Write(headerTable);
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
               // lblmsg0.Text = "Internal error has occured. Please try after some time";
              //  Failure.Visible = true;
            }
        }
    }
}