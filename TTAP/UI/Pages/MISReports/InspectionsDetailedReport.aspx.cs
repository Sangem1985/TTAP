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
    public partial class InspectionsDetailedReport : System.Web.UI.Page
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
                        BindDistricts(); BindIncentives();
                        if (Request.QueryString["Flag"] != null)
                        {
                            hdnFlag.Value = Request.QueryString["Flag"].ToString();
                        }
                        if (Request.QueryString["DistrictId"] != null)
                        {
                            hdnDistId.Value = Request.QueryString["DistrictId"].ToString();
                        }
                        if (Request.QueryString["DistrictId"] != null)
                        {
                            hdnSubIncentiveId.Value = Request.QueryString["SubIncId"].ToString();
                        }

                        ddlDistrict.SelectedValue = hdnDistId.Value.ToString();
                        ddlIncentives.SelectedValue = hdnSubIncentiveId.Value.ToString();
                        //lbtnback.PostBackUrl = "~/UI/Pages/MISReports/frmIncentiveReports.aspx";
                        BindApplicationData();
                        string DistName = ddlDistrict.SelectedItem.ToString();
                        if (hdnDistId.Value.ToString() == "0") { DistName = "All Distrcits"; }
                        string StatusName = ""; string StatusName1 = "";
                        if (hdnFlag.Value == "A")
                        {
                            StatusName = "R14.Total Proposals Received From Applicant";
                            StatusName1 = "Total Proposals Received From Applicant";
                        }
                        if (hdnFlag.Value == "P")
                        {
                            StatusName = "R14.Yet to Process Applications(No Action Taken)";
                            StatusName1 = "Total Yet to Process Applications(No Action Taken)";
                        }
                        if (hdnFlag.Value == "IP")
                        {
                            StatusName = "R14.Yet To Update Scheduled Inspection Report Incentives";
                            StatusName1 = "Yet To Update Scheduled Inspection Report Incentives";
                            /*gvdetailsnew.Columns[15].Visible = false;
                            gvdetailsnew.Columns[16].Visible = false;
                            gvdetailsnew.Columns[17].Visible = false;
                            gvdetailsnew.Columns[18].Visible = false;*/
                        }
                        if (hdnFlag.Value == "IC")
                        {
                            StatusName = "R14.Inspection Report Uploaded Incentives";
                            StatusName1 = "Inspection Report Uploaded Incentives";
                           /* gvdetailsnew.Columns[16].Visible = false;
                            gvdetailsnew.Columns[17].Visible = false;
                            gvdetailsnew.Columns[18].Visible = false;*/
                        }
                        if (hdnFlag.Value == "RIP")
                        {
                            StatusName = "R14.Yet To Update Scheduled Revised Inspection Report Incentives";
                            StatusName1 = "Yet To Update Scheduled Revised Inspection Report Incentives";
                            /*gvdetailsnew.Columns[17].Visible = false;
                            gvdetailsnew.Columns[18].Visible = false;*/
                        }
                        if (hdnFlag.Value == "RIC")
                        {
                            StatusName = "R14.Revised Inspection Report Uploaded Incentives";
                            StatusName1 = "Revised Inspection Report Uploaded Incentives";
                            /*gvdetailsnew.Columns[18].Visible = false;*/
                        }
                        if (hdnFlag.Value == "PHO")
                        {
                            StatusName = "R14.Incentives Pending for Reference To Head Office/DLC";
                            StatusName1 = "Incentives Pending for Reference To Head Office/DLC";
                        }
                        if (hdnFlag.Value == "FHO")
                        {
                            StatusName = "R14.Incentives Forwarded to Head Office/DLC";
                            StatusName1 = "Incentives Forwarded to Head Office/DLC";
                        }
                        if (hdnFlag.Value == "SC")
                        {
                            StatusName = "R14.Scrutiny Completed Incentives";
                            StatusName1 = "Scrutiny Completed Incentives";
                        }
                        if (hdnFlag.Value == "DQ")
                        {
                            StatusName = "R14.DLO Query Raised Before Inspection Incentives";
                            StatusName1 = "DLO Query Raised Before Inspection Incentives";
                        }
                        if (hdnFlag.Value == "DQR")
                        {
                            StatusName = "R14.Query(Before Inspection) Response Incentives";
                            StatusName1 = "Query(Before Inspection) Response Incentives";
                        }
                        if (hdnFlag.Value == "DQA")
                        {
                            StatusName = "R14.Awaiting for DLO Query(Before Inspection) Response Incentives";
                            StatusName1 = "Awaiting for DLO Query(Before Inspection) Response Incentives";
                        }
                        if (hdnFlag.Value == "DQI")
                        {
                            StatusName = "R14.DLO Query Raised After Inspection Incentives";
                            StatusName1 = "DLO Query Raised After Inspection Incentives";
                        }
                        if (hdnFlag.Value == "DQIR")
                        {
                            StatusName = "R14.Query Response After Inspection Incentives";
                            StatusName1 = "Query Response After Inspection Incentives";
                        }
                        if (hdnFlag.Value == "DQIA")
                        {
                            StatusName = "R14.Awaiting for Query Response After Inspection Incentives";
                            StatusName1 = "Awaiting for Query Response After Inspection Incentives";
                        }
                        if (hdnFlag.Value == "R")
                        {
                            StatusName = "R14.DLO Rejected Before Inspection Incentives";
                            StatusName1 = "DLO Rejected Before Inspection Incentives";
                        }
                        if (hdnFlag.Value == "RI")
                        {
                            StatusName = "R14.DLO Rejected After Inspection Incentives";
                            StatusName1 = "DLO Rejected After Inspection Incentives";
                        }

                        lblDesc.InnerText = StatusName1 + " - " + gvdetailsnew.Rows.Count.ToString() + " - " + DistName;
                        lblIncName.InnerText = ddlIncentives.SelectedItem.ToString();
                        if (ddlIncentives.SelectedValue.ToString() == "0")
                        {
                            lblIncName.Visible = false;
                        }
                        hdnHeader.Value = StatusName + " - " + DistName;
                    }
                }
            }
            catch (Exception ex)

            {
                throw ex;
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
                
            }
        }
        public DataSet GetDistrictsList()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = caf.GenericFillDs("GetDistrictsHYD");
            return Dsnew;
        }
        public void BindApplicationData()
        {
            string District = "", Flag = "";
            string SubIncentiveId = ddlIncentives.SelectedValue.ToString();
            District = hdnDistId.Value;
             Flag = hdnFlag.Value;
            if (District == "0")
            {
                District = "";
            }
            if (SubIncentiveId == "0")
            {
                SubIncentiveId = "";
            }
            dss = GetSubmittedIncentiveList(District, "", Flag, SubIncentiveId);
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
        public DataSet GetSubmittedIncentiveList(string DistrictId, string UnitName, string Flag,string SubIncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DistrictId",SqlDbType.VarChar),
               new SqlParameter("@UnitName",SqlDbType.VarChar),
               new SqlParameter("@FLAG",SqlDbType.VarChar),
               new SqlParameter("@SubIncentiveId",SqlDbType.VarChar)
           };
            pp[0].Value = DistrictId;
            pp[1].Value = UnitName;
            pp[2].Value = Flag;
            pp[3].Value = SubIncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_DETAILED_INSPECTION_INCENTIVES_LIST", pp);

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
        public DataSet GetIncentives()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = caf.GenericFillDs("USP_GET_INCENTIVES");
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
                Response.AddHeader("content-disposition", "attachment;filename=R14-Report.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    gvdetailsnew.AllowPaging = false;
                    
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

                    string label1text = hdnHeader.Value.ToString();
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