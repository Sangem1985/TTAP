using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TTAP.Classfiles;
using BusinessLogic;
using System.Data.SqlClient;
using System.IO;

namespace TTAP.UI.Pages
{
    public partial class FormIncentiveTracker : System.Web.UI.Page
    {
        General Gen = new General();
        comFunctions cmf = new comFunctions();
        comFunctions obcmf = new comFunctions();
        Fetch objFetch = new Fetch();
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
                        GetUnits();
                        BindIncentives();
                        if (Request.QueryString["UnitId"] != null) {
                            ddlUnits.SelectedValue = Request.QueryString["UnitId"].ToString();
                            ddlIncentives.SelectedValue = Request.QueryString["IncentiveId"].ToString();
                            ddlIncentives.Enabled = false; ddlUnits.Enabled = false;
                            btnSearch_Click(sender, e);
                        }
                    }
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlUnits.SelectedIndex == 0) {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Unit to get the Report')", true);
                return;
            }
            grdDetails.DataSource = null;
            grdDetails.DataBind();
            divnodata.Visible = false; ;
            DataSet ds = new DataSet();
            string Flag = "A";
            if (ddlIncentives.SelectedIndex > 0)
            {
                Flag = "I";
            }
            ds = GetApplicantIncentivesHistory(ddlUnits.SelectedValue.ToString(), ddlIncentives.SelectedValue.ToString(), Flag);
            try
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();
                    if (Flag == "A")
                    {
                        GetSnos();
                    }
                    string DCP = "";
                    if (ddlIncentives.SelectedIndex > 0)
                    {
                        DCP = ds.Tables[0].Rows[0]["DCP"].ToString();
                        hdndcp.Value = DCP;
                        Flag = "I";
                        lblIncentiveHeader.Text = ddlIncentives.SelectedItem.ToString();
                        lblUnitHeader.Text = ddlUnits.SelectedItem.ToString() + " - DCP - " + DCP;
                    }
                    else
                    {
                        DCP = ds.Tables[0].Rows[1]["DCP"].ToString();
                        lblIncentiveHeader.Text = ddlUnits.SelectedItem.ToString() + " - DCP - " + DCP;
                        hdndcp.Value = DCP;
                    }
                    A2.Visible = true;
                    DateTime dateTime = DateTime.UtcNow.Date;
                    lbldate.Text= "Report as on " + dateTime.ToString("dd/MM/yyyy");
                }
                else
                {
                    divnodata.Visible = true;
                    A2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
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
        public void GetUnits()
        {
            dss = GetUnitsList();
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                ddlUnits.DataSource = dss;
                ddlUnits.DataTextField = "Unit_Name";
                ddlUnits.DataValueField = "UnitCode";
                ddlUnits.DataBind();
                AddSelect(ddlUnits);
            }
            else
            {
                AddSelect(ddlUnits);
            }
        }
        public DataSet GetUnitsList()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = ObjCAFClass.GenericFillDs("USP_Get_TTAPUnits");
            return Dsnew;
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
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddlUnits.SelectedValue = "0";
            ddlIncentives.SelectedValue = "0";
            DataSet ds = new DataSet();
            ds = null;
            grdDetails.DataSource = ds;
            grdDetails.DataBind();
            lblIncentiveHeader.Text = "";
            lblUnitHeader.Text = "";
        }
        protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string IncId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "IncentiveId"));
                    string SubIncId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SubIncentiveID"));
                    if (IncId.Trim().TrimStart() == "")
                    {  
                        e.Row.Font.Bold = true;
                        e.Row.Style.Add("color", "black");
                        e.Row.Style.Add("background", "aquamarine");
                        e.Row.Cells[1].Attributes.Add("colspan", "12");
                        e.Row.Cells[2].Visible = false;
                        e.Row.Cells[3].Visible = false;
                        e.Row.Cells[4].Visible = false;
                        e.Row.Cells[5].Visible = false;
                        e.Row.Cells[6].Visible = false;
                        e.Row.Cells[7].Visible = false;
                        e.Row.Cells[8].Visible = false;
                        e.Row.Cells[9].Visible = false;
                        e.Row.Cells[10].Visible = false;
                        e.Row.Cells[11].Visible = false;
                        e.Row.Cells[12].Visible = false;

                    }
                    if (IncId != "" || IncId != null)
                    {
                        e.Row.Cells[1].Style.Add("color", "blue");
                        GridView gvClaim = (GridView)e.Row.FindControl("gvClaim");
                        DataSet dsnew = new DataSet();
                        dsnew = GetClaimDtls(IncId, SubIncId);
                        if (dsnew.Tables.Count > 0)
                        {
                            if (dsnew.Tables[0].Rows.Count > 0)
                            {
                                gvClaim.DataSource = dsnew;
                                gvClaim.DataBind();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
        protected void gvClaim_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string SubIncentiveId = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "SubIncentiveId"));
                    if (SubIncentiveId != "3" || SubIncentiveId != "4" || SubIncentiveId != "6" || SubIncentiveId != "9" || SubIncentiveId != "14")
                    {
                        GridView gvClaim = (GridView)e.Row.FindControl("gvClaim");
                        gvClaim.Columns[1].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        public DataSet GetClaimDtls(string IncentiveID, string SubIncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.VarChar),
               new SqlParameter("@SubIncentiveId",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveID;
            pp[1].Value = SubIncentiveId;
            Dsnew = ObjCAFClass.GenericFillDs("[USP_GET_INCENTIVE_CLAIM_DETAILS]", pp);

            return Dsnew;
        }
        public void GetSnos()
        {
            int slno = 0;
            foreach (GridViewRow row in grdDetails.Rows)
            {
                string Date = (row.FindControl("lblAcknowledgeDate") as Label).Text;
                if (Date != "")
                {
                    slno = slno + 1;
                    row.Cells[0].Text = Convert.ToString(slno);
                }
                else
                {
                    row.Cells[0].Text = "";
                }
            }
        }

        public DataSet GetApplicantIncentivesHistory(string UnidId,string IncentiveId, string Flag)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UnitId",SqlDbType.VarChar),
               new SqlParameter("@IncentiveId",SqlDbType.VarChar),
               new SqlParameter("@FLAG",SqlDbType.VarChar)

           };
            pp[0].Value = UnidId;
            pp[1].Value = IncentiveId;
            pp[2].Value = Flag;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_APPLICANT_INCENTIVE_WISE_TRACKER", pp);
            return Dsnew;
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        protected void BtnExportExcel_Click(object sender, EventArgs e)
        {
            if (grdDetails.Rows.Count < 1)
            {
                return;
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
                Response.AddHeader("content-disposition", "attachment;filename=IncentiveDetailedReport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";


                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    grdDetails.AllowPaging = false;
                    //this.fillgrid();

                    grdDetails.HeaderRow.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in grdDetails.HeaderRow.Cells)
                    {
                        cell.BackColor = grdDetails.HeaderStyle.BackColor;
                        cell.ForeColor = System.Drawing.Color.Black;
                    }
                    foreach (TableCell cell in grdDetails.FooterRow.Cells)
                    {
                        cell.BackColor = System.Drawing.Color.Black;
                        cell.ForeColor = System.Drawing.Color.Black;
                        // cell.
                    }

                    foreach (GridViewRow row in grdDetails.Rows)
                    {
                        row.BackColor = System.Drawing.Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = grdDetails.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = grdDetails.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }

                    grdDetails.RenderControl(hw);

                    string Incentive = ddlIncentives.SelectedItem.ToString();
                    string UnitName = ddlUnits.SelectedItem.ToString() + " - DCP - " + hdndcp.Value;
                    string headerTable = "";
                    DateTime dateTime = DateTime.UtcNow.Date;
                    string date = "Report as on " + dateTime.ToString("dd/MM/yyyy");
                    if (ddlIncentives.SelectedIndex > 0)
                    {
                       headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='13'><h4>" + UnitName + "</h4></td></tr><tr><td align='center' colspan='13'><h4>" + Incentive + "</h4></td></tr><tr><td align='center' colspan='13'><h4>" + date + "</h4></td></tr></table>";
                    }
                    else
                    {
                        headerTable = @"<table width='100%' class='TestCssStyle'><tr><td align='center' colspan='13'><h4>" + UnitName + "</h4></td></tr><tr><td align='center' colspan='13'><h4>" + date + "</h4></td></tr></table>";
                    }
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