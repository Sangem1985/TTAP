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
    public partial class FormIncentivesReportView : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();
        int TotalIncentivesCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {
                        
                        if (Request.QueryString["Flag"] != null)
                        {
                            hdnFlag.Value = Request.QueryString["Flag"].ToString();
                        }

                        if (Request.QueryString["DistrictId"] != null)
                        {
                            hdnDistId.Value = Request.QueryString["DistrictId"].ToString();
                        }
                        if (Request.QueryString.Count > 5) {
                            hdnDateFlag.Value = Request.QueryString["DateFlag"].ToString();
                            hdnFromDate.Value = Request.QueryString["FromDt"].ToString();
                            hdnToDate.Value = Request.QueryString["ToDt"].ToString();
                        }
                       
                        if (hdnFlag.Value == "R") {
                            hdnFlagDesc.Value = "Rejected Incentives";
                        }
                        if (hdnFlag.Value == "H")
                        {
                            hdnFlagDesc.Value = "Incentives Pending at Head Office";
                        }
                        if (hdnFlag.Value == "A")
                        {
                            hdnFlagDesc.Value = "Incentives Pending with Applicant";
                        }
                        if (hdnFlag.Value == "D")
                        {
                            hdnFlagDesc.Value = "Incentives Pending at DLO";
                        }
                        if (hdnFlag.Value == "DLCP")
                        {
                            hdnFlagDesc.Value = "Incentives Pending at DLO (DLC)";
                        }
                        if (hdnFlag.Value == "SLC")
                        {
                            hdnFlagDesc.Value = "Incentives Pending at DLO (SLC)";
                        }
                        if (hdnFlag.Value == "DLC")
                        {
                            hdnFlagDesc.Value = "Incentives Pending at DL-SVC & DLC";
                        }
                        if (hdnFlag.Value == "P")
                        {
                            hdnFlagDesc.Value = "Incentives Pending at Payment Verification";
                        }
                        if (hdnFlag.Value == "T")
                        {
                            hdnFlagDesc.Value = "Total Incentives";
                            divList.Visible = true;
                            TotalGrid.Visible = false;
                            lblDesc.Visible = false;
                            BindApplicationDataList();
                            GetSnos();
                            chklistView.Visible = true;

                        }
                        if (hdnFlag.Value == "S")
                        {
                            hdnFlagDesc.Value = "Sanctioned Incentives";
                        }
                        if (hdnFlag.Value == "RL")
                        {
                            hdnFlagDesc.Value = "Released Incentives";
                        }

                        lbtnback.PostBackUrl = "~/UI/Pages/MISReports/frmIncentiveReports.aspx";
                        BindDistricts();
                        ddlDistrict.SelectedValue = hdnDistId.Value;
                        if (hdnDistId.Value == "0")
                        {
                            ddlDistrict.SelectedIndex = 0;
                        }
                        BindApplicationData();
                        lbldistrict.InnerHtml = "District - " + ddlDistrict.SelectedItem;
                        if (ddlDistrict.SelectedIndex == 0) {
                            lbldistrict.InnerHtml = "District - All Districts";
                        }
                        Header.InnerHtml = hdnFlagDesc.Value;
                        /*if (hdnFlag.Value == "S")
                        {
                            gvdetailsnew.Columns[10].Visible = false;
                            gvdetailsnew.Columns[15].Visible = true;
                            gvdetailsnew.Columns[16].Visible = true;
                            gvdetailsnew.Columns[17].Visible = true;
                            gvdetailsnew.Columns[18].Visible = true;
                            gvdetailsnew.Columns[19].Visible = false;
                            gvdetailsnew.Columns[21].Visible = false;
                            gvdetailsnew.Columns[22].Visible = false;
                        }
                        else if (hdnFlag.Value == "RL")
                        {
                            gvdetailsnew.Columns[10].Visible = false;
                            gvdetailsnew.Columns[15].Visible = true;
                            gvdetailsnew.Columns[16].Visible = true;
                            gvdetailsnew.Columns[17].Visible = true;
                            gvdetailsnew.Columns[18].Visible = true;
                            gvdetailsnew.Columns[20].Visible = true;
                            gvdetailsnew.Columns[21].Visible = true;
                            gvdetailsnew.Columns[22].Visible = true;
                            gvdetailsnew.Columns[19].Visible = false;
                        }
                        else if (hdnFlag.Value == "D")
                        {
                            gvdetailsnew.Columns[10].Visible = true;
                            gvdetailsnew.Columns[15].Visible = false;
                            gvdetailsnew.Columns[16].Visible = false;
                            gvdetailsnew.Columns[17].Visible = false;
                            gvdetailsnew.Columns[18].Visible = false;
                            gvdetailsnew.Columns[21].Visible = false;
                            gvdetailsnew.Columns[22].Visible = false;
                            gvdetailsnew.Columns[19].Visible = true;
                        }
                        else if (hdnFlag.Value == "R")
                        {
                            gvdetailsnew.Columns[10].Visible = false;
                            gvdetailsnew.Columns[15].Visible = false;
                            gvdetailsnew.Columns[16].Visible = false;
                            gvdetailsnew.Columns[17].Visible = false;
                            gvdetailsnew.Columns[18].Visible = false;
                            gvdetailsnew.Columns[21].Visible = false;
                            gvdetailsnew.Columns[22].Visible = false;
                            gvdetailsnew.Columns[23].Visible = true;
                            gvdetailsnew.Columns[24].Visible = true;
                            gvdetailsnew.Columns[19].Visible = true;
                        }
                        else
                        {
                            gvdetailsnew.Columns[10].Visible = false;
                            gvdetailsnew.Columns[15].Visible = false;
                            gvdetailsnew.Columns[16].Visible = false;
                            gvdetailsnew.Columns[17].Visible = false;
                            gvdetailsnew.Columns[18].Visible = false;
                            gvdetailsnew.Columns[21].Visible = false;
                            gvdetailsnew.Columns[22].Visible = false;
                            gvdetailsnew.Columns[19].Visible = true;
                        }*/
                        
                    }
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindApplicationData();
        }
        public void BindApplicationData()
        {
            string District = "", Flag = "";
            District=hdnDistId.Value;
            Flag = hdnFlag.Value;
            if (District == "0") {
                District = "";
            }
            dss = GetSubmittedIncentiveList(District, txtsearch.Text.Trim().TrimStart(), Flag,hdnDateFlag.Value,hdnFromDate.Value,hdnToDate.Value);
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = dss;
                gvdetailsnew.DataBind();
                hdnDistName.Value = dss.Tables[0].Rows[0]["DistrictName"].ToString();
                if (ddlDistrict.SelectedIndex == 0)
                {
                    hdnDistName.Value = "All Distrcits";
                }
            }
            else
            {
                gvdetailsnew.DataSource = dss;
                gvdetailsnew.DataBind();
            }
        }
        public void BindApplicationDataList()
        {
            string District = "", Flag = "";
            District = hdnDistId.Value;
            Flag = hdnFlag.Value;
            if (District == "0")
            {
                District = "";
            }
            dss = GetSubmittedIncentiveListWithIncentive("1",District);
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvListView.DataSource = dss;
                gvListView.DataBind();
                hdnDistName.Value = dss.Tables[0].Rows[0]["DistrictName"].ToString();
                if (ddlDistrict.SelectedIndex == 0)
                {
                    hdnDistName.Value = "All Distrcits";
                }
            }
            else
            {
                gvListView.DataSource = dss;
                gvListView.DataBind();
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
        protected void chkActiveList_CheckedChanged(object sender, EventArgs e)
        {
            BindApplicationData();
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
        public DataSet GetSubmittedIncentiveList(string DistrictId, string UnitName, string OrderFlag,string DateFlag,string FDt,string TDt)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DistrictId",SqlDbType.VarChar),
               new SqlParameter("@UnitName",SqlDbType.VarChar),
               new SqlParameter("@FLAG",SqlDbType.VarChar),
               new SqlParameter("@FromDate",SqlDbType.VarChar),
               new SqlParameter("@ToDate",SqlDbType.VarChar),
               new SqlParameter("@DateFlag",SqlDbType.VarChar)
           };
            pp[0].Value = DistrictId;
            pp[1].Value = UnitName;
            pp[2].Value = OrderFlag;
            pp[3].Value = FDt;
            pp[4].Value = TDt;
            pp[5].Value = DateFlag;
            Dsnew = caf.GenericFillDs("USP_GET_DETAILED_SUBMITTED_INCENTIVES_LIST", pp);

            return Dsnew;
        }
        public DataSet GetSubmittedIncentiveListWithIncentive(string UserId,string DistrictId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
               new SqlParameter("@DISTID",SqlDbType.VarChar)
           };
            pp[0].Value = UserId;
            pp[1].Value = DistrictId;
            Dsnew = caf.GenericFillDs("USP_GET_INCENTIVEWISE_UINTWISE_LIST", pp);

            return Dsnew;
        }
        public DataSet GetDistrictsList()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = caf.GenericFillDs("GetDistrictsHYD");
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
                Response.AddHeader("content-disposition", "attachment;filename=R4(B)-IncentiveReport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                //divPMprint.Style["width"] = "680px";

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    if (hdnFlag.Value == "T" && chklistView.Checked==false)
                    {
                        gvListView.AllowPaging = false;
                        //this.fillgrid();

                        gvListView.HeaderRow.BackColor = System.Drawing.Color.White;
                        foreach (TableCell cell in gvListView.HeaderRow.Cells)
                        {
                            cell.BackColor = gvListView.HeaderStyle.BackColor;
                            cell.ForeColor = System.Drawing.Color.Black;
                        }
                        foreach (TableCell cell in gvListView.FooterRow.Cells)
                        {
                            cell.BackColor = System.Drawing.Color.Black;
                            cell.ForeColor = System.Drawing.Color.Black;
                            // cell.
                        }

                        foreach (GridViewRow row in gvListView.Rows)
                        {
                            row.BackColor = System.Drawing.Color.White;
                            foreach (TableCell cell in row.Cells)
                            {
                                if (row.RowIndex % 2 == 0)
                                {
                                    cell.BackColor = gvListView.AlternatingRowStyle.BackColor;
                                }
                                else
                                {
                                    cell.BackColor = gvListView.RowStyle.BackColor;
                                }
                                cell.CssClass = "textmode";
                            }
                        }

                        gvListView.RenderControl(hw);
                    }
                    else
                    {
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
                    }

                    string label1text = "R4(B). "+ hdnFlagDesc.Value + " - " + hdnDistName.Value;
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
        public void GetSnos()
        {
            int slno = 0;string Roman = "";
            foreach (GridViewRow row in gvListView.Rows)
            {
                string UnitName = (row.FindControl("lblUnitName") as Label).Text;
                if (UnitName == "")
                {
                    slno = slno + 1;
                    if (slno == 1) { Roman = "I"; }if (slno == 2) { Roman = "II"; }if (slno == 3) { Roman = "III"; }
                    if (slno == 4) { Roman = "IV"; }if (slno == 5) { Roman = "V"; }if (slno == 6) { Roman = "VI"; }
                    if (slno == 7) { Roman = "VII"; }if (slno == 8) { Roman = "VIII"; }if (slno == 9) { Roman = "IX"; }
                    if (slno == 10) { Roman = "X"; }if (slno == 11) { Roman = "XI"; }if (slno == 12) { Roman = "XII"; }
                    if (slno == 13) { Roman = "XIII"; }if (slno == 14) { Roman = "XIV"; }if (slno == 15) { Roman = "XV"; }
                    if (slno == 16) { Roman = "XVI"; }if (slno == 17) { Roman = "XVII"; }if (slno == 18) { Roman = "XVIII"; }
                    if (slno == 19) { Roman = "XXIX"; }
                    row.Cells[0].Text = Convert.ToString(Roman);
                }
            }
        }

        protected void gvListView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                /*if (DataBinder.Eval(e.Row.DataItem, "UnitName").ToString() == "")
                {
                    e.Row.Cells[1].ColumnSpan = 19;
                    e.Row.Cells[2].Visible = false; e.Row.Cells[3].Visible = false; e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false; e.Row.Cells[6].Visible = false; e.Row.Cells[7].Visible = false;
                    e.Row.Cells[8].Visible = false; e.Row.Cells[9].Visible = false; e.Row.Cells[10].Visible = false;
                    e.Row.Cells[11].Visible = false; e.Row.Cells[12].Visible = false; e.Row.Cells[13].Visible = false;
                    e.Row.Cells[14].Visible = false; e.Row.Cells[15].Visible = false; e.Row.Cells[16].Visible = false;
                    e.Row.Cells[17].Visible = false; e.Row.Cells[18].Visible = false; e.Row.Cells[19].Visible = false;
                }*/
                string UnitId = DataBinder.Eval(e.Row.DataItem, "CreateBy").ToString();
                string DistId = hdnDistId.Value.ToString();
                string SubIncId = DataBinder.Eval(e.Row.DataItem, "SubIncentiveID").ToString();
                if (DataBinder.Eval(e.Row.DataItem, "UnitName").ToString() == "")
                {   
                    e.Row.Font.Bold = true;
                    HyperLink h1 = (HyperLink)e.Row.Cells[1].Controls[0];
                    h1.Style.Add("color", "black");
                    h1.NavigateUrl = "frmIncentiveWiseRpt.aspx?IncentiveId="+ SubIncId+ "&DistrictId=" + DistId;
                    e.Row.Style.Add("background", "aquamarine");
                    e.Row.Cells[1].ColumnSpan = 6;
                    e.Row.Cells[2].Visible = false; e.Row.Cells[3].Visible = false; e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = false; e.Row.Cells[6].Visible = false;
                    
                }
                else
                {
                    HyperLink h2 = (HyperLink)e.Row.Cells[1].Controls[0];
                    h2.Style.Add("color", "black");
                    h2.NavigateUrl = "~/UI/Pages/FormIncentiveTracker.aspx?IncentiveId=" + SubIncId + "&UnitId=" + UnitId;
                }
            }
        }

        protected void chklistView_CheckedChanged(object sender, EventArgs e)
        {
            if (chklistView.Checked == true)
            {
                divList.Visible = false;
                TotalGrid.Visible = true;
                lblDesc.Visible = true;
            }
            else
            {
                divList.Visible = true;
                TotalGrid.Visible = false;
                lblDesc.Visible = false;
                GetSnos();
            }
        }
    }
}