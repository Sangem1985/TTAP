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
    public partial class FormUnitReport : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();
        string DistName = string.Empty;
        string DateFlag = string.Empty;
        string FromDt = string.Empty;
        string Todt= string.Empty;
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
                        lbtnback.PostBackUrl = "~/UI/Pages/MISReports/frmIncentiveReports.aspx";
                        BindDistricts();
                        string Level = "", DistrictId = "", Type = "";
                        
                        if (Request.QueryString["Level"] != null)
                        {
                            Level = Request.QueryString["Level"].ToString();
                            divCats.Visible = false;
                            btnSearch.Visible = false;
                            btnReset.Visible = false;
                            divHeader.Visible = true;
                            lbltotalcount.Style.Add("margin-left", "500px");
                            lbtnback.PostBackUrl = "~/UI/Pages/MISReports/FrmNatureWiseReportAbstract.aspx";
                        }

                        if (Request.QueryString["DistrictId"] != null)
                        {
                            DistrictId = Request.QueryString["DistrictId"].ToString();
                        }

                        ddlDistrict.SelectedValue = DistrictId;
                        lblDist.InnerText = "District - " + ddlDistrict.SelectedItem;
                        if (Request.QueryString.Count <= 3)
                        {
                            if (Request.QueryString["Flag"] != null)
                            {
                                if (Request.QueryString["Flag"].ToString() == "CAT")
                                {
                                    string Category = Request.QueryString["Level"].ToString();
                                    if (Request.QueryString["Level"].ToString() == "0")
                                    {
                                        ddlCategory.SelectedIndex = 0;
                                    }
                                    else
                                    {
                                        ddlCategory.SelectedValue = Category;
                                    }
                                    lblNature.InnerText = "Category - " + ddlCategory.SelectedItem.ToString();
                                }
                                else
                                {
                                    ddlIndustryNature.SelectedValue = Level;
                                    lblNature.InnerText = "Nature of Industry - " + ddlIndustryNature.SelectedItem.ToString();
                                }
                            }   
                           
                        }
                        if (Request.QueryString.Count > 2)
                        {
                            if (Request.QueryString["DateFlag"] == "D")
                            {
                                hdnDateFlag.Value= Request.QueryString["DateFlag"].ToString();
                                hdnFromDate.Value = Request.QueryString["FromDt"].ToString();
                                hdnToDate.Value = Request.QueryString["ToDt"].ToString();
                            }
                        }

                        if (Request.QueryString.Count > 3)
                        {
                            if (Request.QueryString["Type"] != null)
                            {
                                Type = Request.QueryString["Type"].ToString();
                                if (Level == "3")
                                {
                                    ddlTechnicalNatureOfIndustry.SelectedIndex = 0;
                                }
                                else
                                {
                                    ddlTechnicalNatureOfIndustry.SelectedValue = Level;
                                }
                                lblNature.InnerText = "Type of Textile - " + ddlTechnicalNatureOfIndustry.SelectedItem;
                            }
                           
                        }
                        if (ObjLoginNewvo.Role_Code == "DLO")
                        {
                            ddlDistrict.SelectedValue = ObjLoginNewvo.DistrictID.ToString();
                            ddlDistrict.Enabled = false;
                        }
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
            string DistrictId = "", Category = "", IndustryType = "", IndustryNature = "", TypeofTextile = "";
            DistrictId = ddlDistrict.SelectedValue;
            if (ddlDistrict.SelectedIndex == 0) {
                DistrictId = "";
            }
            Category = ddlCategory.SelectedValue;
            IndustryType = ddlIndustryType.SelectedValue;
            IndustryNature = ddlIndustryNature.SelectedValue;
            TypeofTextile = ddlTechnicalNatureOfIndustry.SelectedValue;
            if (ddlTechnicalNatureOfIndustry.SelectedIndex == 0) {
                TypeofTextile = "";
            }
            
            dss = GetSubmittedUnitList(DistrictId, Category, IndustryType, IndustryNature, TypeofTextile,hdnDateFlag.Value,hdnFromDate.Value,hdnToDate.Value);
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = dss;
                gvdetailsnew.DataBind();
                hdnDistName.Value = dss.Tables[0].Rows[0]["District_Name"].ToString();
                if (ddlDistrict.SelectedIndex == 0) {
                    hdnDistName.Value = "All Distrcits";
                }
                A2.Visible = true;
            }
            else
            {
                A2.Visible = false;
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
                ddlDistrict.Items.Insert(0, "All");
            }
            else
            {
                ddlDistrict.Items.Insert(0, "--Select--");
            }
        }
        public void BindTechnicalTexttile()
        {
            ddlTechnicalNatureOfIndustry.Items.Clear();
            DataSet dsTechnicalTexttile = new DataSet();
            dsTechnicalTexttile = caf.getTechnicalTextileList();
            if (dsTechnicalTexttile.Tables.Count > 0)
            {
                if (dsTechnicalTexttile != null && dsTechnicalTexttile.Tables.Count > 0 && dsTechnicalTexttile.Tables[0].Rows.Count > 0)
                {
                    ddlTechnicalNatureOfIndustry.DataSource = dsTechnicalTexttile;
                    ddlTechnicalNatureOfIndustry.DataTextField = "TechnicalTextile";
                    ddlTechnicalNatureOfIndustry.DataValueField = "TechnicalTextileID";
                    ddlTechnicalNatureOfIndustry.DataBind();
                    ddlTechnicalNatureOfIndustry.Items.Insert(0, "All");
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindApplicationData();
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddlDistrict.SelectedIndex = 0;
            ddlCategory.SelectedIndex = 0;
            ddlIndustryType.SelectedIndex = 0;
            ddlIndustryNature.SelectedIndex = 0;
            ddlTechnicalNatureOfIndustry.SelectedIndex = 0;
            BindEmpty();
        }
        protected void Order_Changed(object sender, EventArgs e)
        {
            BindApplicationData();
        }
       
        public DataSet GetSubmittedUnitList(string DistrictId, string Category, string IndustryType, string IndustryNature, string TypeofTextile,string DateFlag,string Fdate,string Tdate)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DistrictId",SqlDbType.VarChar),
               new SqlParameter("@Category",SqlDbType.VarChar),
               new SqlParameter("@IndustryType",SqlDbType.VarChar),
               new SqlParameter("@IndustryNature",SqlDbType.VarChar),
               new SqlParameter("@TypeofTextile",SqlDbType.VarChar),
               new SqlParameter("@FromDate",SqlDbType.VarChar),
               new SqlParameter("@ToDate",SqlDbType.VarChar),
               new SqlParameter("@Flag",SqlDbType.VarChar)
           };
            pp[0].Value = DistrictId;
            pp[1].Value = Category;
            pp[2].Value = IndustryType;
            pp[3].Value = IndustryNature;
            pp[4].Value = TypeofTextile;
            pp[5].Value = Fdate;
            pp[6].Value = Tdate;
            pp[7].Value = DateFlag;
            Dsnew = caf.GenericFillDs("USP_GETALL_SUBMITTED_UNITS", pp);

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
            if (gvdetailsnew.Rows.Count < 1)
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
                Response.AddHeader("content-disposition", "attachment;filename=UnitReport.xls");
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

                    string label1text = "R5.UnitReport - " + hdnDistName.Value;
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
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindEmpty();
        }
        protected void ddlIndustryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindEmpty();
        }
        protected void ddlIndustryNature_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindEmpty();
        }
        protected void ddlTechnicalNatureOfIndustry_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindEmpty();
        }
        public void BindEmpty()
        {
            dss = null;
            gvdetailsnew.DataSource = dss;
            gvdetailsnew.DataBind();
            A2.Visible = false;
        }
    }
}