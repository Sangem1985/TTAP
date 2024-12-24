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
    public partial class CapitalSubsiyReportAbstract : System.Web.UI.Page
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
                        UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                        ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                        BindDistricts();
                        lbtnback.PostBackUrl = "~/UI/Pages/MISReports/frmIncentiveReports.aspx";
                        DateTime dateTime = DateTime.UtcNow.Date;
                        lblHeader.Text = "T-TAP - Capital Subsidy Applied Units Status Abstract as on " + dateTime.ToString("dd/MM/yyyy");
                        if (ObjLoginNewvo.Role_Code == "DLO")
                        {
                            ddlDistrict.SelectedValue = ObjLoginNewvo.DistrictID.ToString();
                            ddlDistrict.Enabled = false;
                        }
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
            string DistId = "";
            if (ddlDistrict.SelectedValue == "0") { DistId = ""; }
            else { DistId = ddlDistrict.SelectedValue.ToString(); }
            dss = GetIncentiveAbstract(Session["uid"].ToString(), DistId);

            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = dss;
                gvdetailsnew.DataBind();
                tdTotalUnits.Text = dss.Tables[0].Rows[0]["TotalUnits"].ToString();
                tdTotalClaims.Text = dss.Tables[0].Rows[0]["NoofClaims"].ToString();
                tdPendingPayment.Text = dss.Tables[0].Rows[0]["NoOfIncentivesatPayment"].ToString();
                tdPendingDLO.Text = dss.Tables[0].Rows[0]["NoOfIncentivesatDLO"].ToString();
                tdPendingApplicant.Text = dss.Tables[0].Rows[0]["NoOfIncentivesatApplicant"].ToString();
                tdPendingHO.Text = dss.Tables[0].Rows[0]["NoOfIncentivesatHO"].ToString();
                tdReject.Text = dss.Tables[0].Rows[0]["NoOfIncentivesRejected"].ToString();
                tdRevisedInspection.Text = dss.Tables[0].Rows[0]["PendingRevisedInspectionIncentives"].ToString();
                tdSanctionioned.Text = dss.Tables[0].Rows[0]["TotalNoOfIncentivesSanctioned"].ToString();
                tdReleased.Text = dss.Tables[0].Rows[0]["TotalNoOfIncentivesReleased"].ToString();
            }
            else
            {
                gvdetailsnew.DataSource = null;
                gvdetailsnew.DataBind();
                tdTotalUnits.Text = "0";
                tdTotalClaims.Text = "0";
                tdPendingPayment.Text = "0";
                tdPendingDLO.Text = "0";
                tdPendingApplicant.Text = "0";
                tdPendingHO.Text = "0";
                tdReject.Text = "0";
                tdRevisedInspection.Text = "0";
                tdSanctionioned.Text = "0";
                tdReleased.Text = "0";
            }
            DateTime dateTime = DateTime.UtcNow.Date;
            if (ddlDistrict.SelectedValue == "0")
            {
                lblHeader.Text = "T-TAP - Capital Subsidy Applied Units Status Abstract as on " + dateTime.ToString("dd/MM/yyyy");
                lblHeader2.Text = "T-TAP - Capital Subsidy Applied Units Status Abstract as on " + dateTime.ToString("dd/MM/yyyy");
            }
            else
            {
                string Dist = ddlDistrict.SelectedItem.ToString();
                lblHeader.Text = Dist + " - T-TAP - Capital Subsidy Applied Units Status Abstract as on " + dateTime.ToString("dd/MM/yyyy");
                lblHeader2.Text = Dist + " - T-TAP - Capital Subsidy Applied Units Status Abstract as on " + dateTime.ToString("dd/MM/yyyy");
            }
        }
        public DataSet GetIncentiveAbstract(string UserID,string DistId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
               new SqlParameter("@DistrictId",SqlDbType.VarChar)
           };
            pp[0].Value = UserID;
            pp[1].Value = DistId;
            Dsnew = caf.GenericFillDs("USP_GET_INCENTIVE_WISE_STATUS_ABSTRACT", pp);

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
                Response.AddHeader("content-disposition", "attachment;filename=R12-IncentiveStatusAbstract.xls");
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

                    string label1text = "R12. Incentive Status Abstract";
                    if (ddlDistrict.SelectedValue == "0") { label1text = "R12. Incentive Status Abstract"; }
                    else { label1text = "R12. Incentive Status Abstract - " + ddlDistrict.SelectedItem.ToString(); }
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

        protected void chkView_CheckedChanged(object sender, EventArgs e)
        {
            if (chkView.Checked == true)
            {
                DivGridView.Visible = true;
                divNormalView.Visible = false;
                trExcel.Visible = true;
                divGridHead.Visible = true;
                divNormalHead.Visible = false;
            }
            else
            {
                DivGridView.Visible = false;
                divNormalView.Visible = true;
                trExcel.Visible = false;
                divGridHead.Visible = false;
                divNormalHead.Visible = true;
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

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
        public void AddSelect(DropDownList ddl)
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }

        protected void gvdetailsnew_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string DistId = ddlDistrict.SelectedValue.ToString();
            if (ddlDistrict.SelectedValue == "0") { DistId = ""; }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HyperLink h0 = (HyperLink)e.Row.Cells[0].Controls[0];
                if (h0.Text != "0")
                {   
                    h0.NavigateUrl = "FormUnitReport.aspx?Level=0&Flag=Z&DistrictId=" + DistId;
                    
                }
                HyperLink h1 = (HyperLink)e.Row.Cells[1].Controls[0];
                if (h1.Text != "0")
                {
                    h1.NavigateUrl = "CapitalSubsidyDetailedReport.aspx?Status=1&DistId=" + DistId;
                }
                HyperLink h2 = (HyperLink)e.Row.Cells[2].Controls[0];
                if (h2.Text != "0")
                {   
                    h2.NavigateUrl = "CapitalSubsidyDetailedReport.aspx?Status=2&DistId=" + DistId;
                }
                HyperLink h3 = (HyperLink)e.Row.Cells[3].Controls[0];
                if (h3.Text != "0")
                {
                    h3.NavigateUrl = "CapitalSubsidyDetailedReport.aspx?Status=3&DistId=" + DistId;
                }
                HyperLink h4 = (HyperLink)e.Row.Cells[4].Controls[0];
                if (h4.Text != "0")
                {
                    h4.NavigateUrl = "CapitalSubsidyDetailedReport.aspx?Status=4&DistId=" + DistId;
                }
                HyperLink h5 = (HyperLink)e.Row.Cells[5].Controls[0];
                if (h5.Text != "0")
                {
                    h5.NavigateUrl = "CapitalSubsidyDetailedReport.aspx?Status=5&DistId=" + DistId;
                }
                HyperLink h6 = (HyperLink)e.Row.Cells[6].Controls[0];
                if (h6.Text != "0")
                {
                    h6.NavigateUrl = "CapitalSubsidyDetailedReport.aspx?Status=6&DistId=" + DistId;
                }
                HyperLink h7 = (HyperLink)e.Row.Cells[7].Controls[0];
                if (h7.Text != "0")
                {
                    h7.NavigateUrl = "CapitalSubsidyDetailedReport.aspx?Status=7&DistId=" + DistId;
                }
                HyperLink h8 = (HyperLink)e.Row.Cells[8].Controls[0];
                if (h8.Text != "0")
                {
                    h8.NavigateUrl = "CapitalSubsidyDetailedReport.aspx?Status=8&DistId=" + DistId;
                }
                HyperLink h9 = (HyperLink)e.Row.Cells[9].Controls[0];
                if (h9.Text != "0")
                {
                    h9.NavigateUrl = "CapitalSubsidyDetailedReport.aspx?Status=9&DistId=" + DistId;
                }
            }
        }
    }
}