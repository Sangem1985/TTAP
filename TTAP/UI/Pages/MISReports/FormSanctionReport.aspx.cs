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
    public partial class FormSanctionReport : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();
        GridView Gvlist = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindDistricts();
                    GetUnits();
                    BindApplicationData();
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
        public void BindApplicationData()
        {
            string DistId = ddlDistrict.SelectedValue.ToString();
            string UnitId = ddlUnits.SelectedValue.ToString();
            if (ddlDistrict.SelectedIndex == 0) { DistId = "0"; }
            if (ddlUnits.SelectedIndex == 0) { UnitId = "0"; }
            dss = GetSubmittedIncentiveList(DistId, UnitId);
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
            string Header = "";
            DateTime dateTime = DateTime.UtcNow.Date;
            if (ddlDistrict.SelectedIndex == 0 && ddlUnits.SelectedIndex == 0)
            {
                Header = "Details of Subsidies Claimed,Sanctioned & Released as on " + dateTime.ToString("dd/MM/yyyy");
            }
            if (ddlDistrict.SelectedIndex != 0 && ddlUnits.SelectedIndex == 0)
            {
                string DistName = ddlDistrict.SelectedItem.ToString();
                Header = "Details of Subsidies Claimed,Sanctioned & Released to "+ DistName + " District as on " + dateTime.ToString("dd/MM/yyyy");
            }
            if (ddlUnits.SelectedIndex != 0)
            {
                string UnitName = ddlUnits.SelectedItem.ToString();
                Header = "Details of Subsidies Claimed,Sanctioned & Released to " + UnitName + " as on " + dateTime.ToString("dd/MM/yyyy");
            }
            lblHeader.Text = Header;
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
        public void GetUnits()
        {
            dss = GetUnitsList();
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                ddlUnits.DataSource = dss;
                ddlUnits.DataTextField = "Unit_Name";
                ddlUnits.DataValueField = "UnitCode";
                ddlUnits.DataBind();
                ddlUnits.Items.Insert(0, "--Select--");

            }
            else
            {
                ddlUnits.Items.Insert(0, "--Select--");
            }
        }
        public DataSet GetDistrictsList()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = caf.GenericFillDs("GetDistrictsHYD");
            return Dsnew;
        }
        public DataSet GetUnitsList()
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@Flag",SqlDbType.VarChar)
           };
            pp[0].Value = "S";
            Dsnew = caf.GenericFillDs("USP_Get_TTAPUnits", pp);

            return Dsnew;
        }
        public DataSet GetSubmittedIncentiveList(string DistId, string UnitId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UserId",SqlDbType.VarChar),
               new SqlParameter("@Flag",SqlDbType.VarChar),
               new SqlParameter("@DistrictId",SqlDbType.VarChar),
               new SqlParameter("@UnitId",SqlDbType.VarChar)
           };
            pp[0].Value = "";
            pp[1].Value = "";
            pp[2].Value = DistId;
            pp[3].Value = UnitId;
            Dsnew = caf.GenericFillDs("USP_GETALL_SANCTIONED_UNITS", pp);

            return Dsnew;
        }
        public DataSet GetIncentiveList(string IncentiveID, string Flag)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@CreateBy",SqlDbType.VarChar),
               new SqlParameter("@Flag",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveID;
            pp[1].Value = Flag;
            Dsnew = caf.GenericFillDs("[USP_GETALL_SANCTIONED_UNITS_INCENTIVES]", pp);

            return Dsnew;
        }
        protected void gvdetailsnew_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Gvlist = (GridView)e.Row.FindControl("gvIncentives");
                    DataSet dsnew = new DataSet();

                    string UnitId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UnitId"));
                    string Flag = "B";

                    dsnew = GetIncentiveList(UnitId, Flag);

                    if (dsnew.Tables.Count > 0)
                    {
                        if (dsnew.Tables[0].Rows.Count > 0)
                        {
                            Gvlist.DataSource = dsnew;
                            Gvlist.DataBind();
                            if (e.Row.RowIndex == 0)
                            {
                                Gvlist.ShowHeader = true;
                            }
                            else
                            {
                                Gvlist.ShowHeader = false;
                            }
                        }
                        for (int i = Gvlist.Rows.Count - 1; i > 0; i--)
                        {
                            {
                                GridViewRow row = Gvlist.Rows[i];
                                GridViewRow previousRow = Gvlist.Rows[i - 1];
                                for (int j = 0; j < row.Cells.Count; j++)
                                {
                                    if (j == 0 || j == 1)
                                    {
                                        if (row.Cells[j].Text == previousRow.Cells[j].Text)
                                        {
                                            if (previousRow.Cells[j].RowSpan == 0)
                                            {
                                                if (row.Cells[j].RowSpan == 0)
                                                {
                                                    previousRow.Cells[j].RowSpan += 2;
                                                }
                                                else
                                                {
                                                    previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
                                                }
                                                row.Cells[j].Visible = false;
                                            }
                                        }
                                    }
                                }
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
        protected void gvIncentives_PreRender(object sender, EventArgs e)
        {
            
            MergeRows(Gvlist, 0);
        }
        public static void MergeRows(GridView gvIncentives, int ColNumber)
        {
            for (int rowIndex = gvIncentives.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = gvIncentives.Rows[rowIndex];
                GridViewRow previousRow = gvIncentives.Rows[rowIndex + 1];

                for (int i = 0; i < ColNumber; i++)
                {
                    if (row.Cells[i].Text == previousRow.Cells[i].Text)
                    {
                        row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 : previousRow.Cells[i].RowSpan + 1;
                        previousRow.Cells[i].Visible = false;
                        row.Cells[0].Attributes.Add("vertical-align", "middle");
                    }
                }
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
                Response.AddHeader("content-disposition", "attachment;filename=R13Report.xls");
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
                    DateTime dateTime = DateTime.UtcNow.Date;
                    if (ddlDistrict.SelectedIndex == 0 && ddlUnits.SelectedIndex == 0)
                    {
                        Header = "Details of Subsidies Claimed,Sanctioned & Released as on " + dateTime.ToString("dd/MM/yyyy");
                    }
                    if (ddlDistrict.SelectedIndex != 0 && ddlUnits.SelectedIndex == 0)
                    {
                        string DistName = ddlDistrict.SelectedItem.ToString();
                        Header = "Details of Subsidies Claimed,Sanctioned & Released to " + DistName + " District as on " + dateTime.ToString("dd/MM/yyyy");
                    }
                    if (ddlUnits.SelectedIndex != 0)
                    {
                        string UnitName = ddlUnits.SelectedItem.ToString();
                        Header = "Details of Subsidies Claimed,Sanctioned & Released to " + UnitName + " as on " + dateTime.ToString("dd/MM/yyyy");
                    }
                    label1text = Header;
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

        protected void gvIncentives_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Visible = false;
            }
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindApplicationData();
        }
    }
}