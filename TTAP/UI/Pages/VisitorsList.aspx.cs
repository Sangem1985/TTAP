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
using BusinessLogic;
using System.IO;

namespace TTAP.UI.Pages
{
    public partial class VisitorsList : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
        private SqlConnection ConNew = new SqlConnection(ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString);
        CAFClass caf = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindVisitorGrid();
        }
        protected void BindVisitorGrid()
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetVisitorDetails();

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    gvVisitors.DataSource = dsnew.Tables[0];
                    gvVisitors.DataBind();
                }
                else
                {
                    gvVisitors.DataSource = null;
                    gvVisitors.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet GetVisitorDetails()
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UserId",SqlDbType.VarChar)
           };
            pp[0].Value = "1";
            Dsnew = caf.GenericFillDs("USP_GET_VISITORS", pp);
            return Dsnew;
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
        protected void BtnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=VisitorsList.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";


                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    gvVisitors.AllowPaging = false;
                    //this.fillgrid();

                    gvVisitors.HeaderRow.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in gvVisitors.HeaderRow.Cells)
                    {
                        cell.BackColor = gvVisitors.HeaderStyle.BackColor;
                        cell.ForeColor = System.Drawing.Color.Black;
                    }
                    foreach (TableCell cell in gvVisitors.FooterRow.Cells)
                    {
                        cell.BackColor = System.Drawing.Color.Black;
                        cell.ForeColor = System.Drawing.Color.Black;
                        // cell.
                    }

                    foreach (GridViewRow row in gvVisitors.Rows)
                    {
                        row.BackColor = System.Drawing.Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = gvVisitors.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = gvVisitors.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }

                    gvVisitors.RenderControl(hw);

                    string label1text = "Handloom Exhibition cum Sale Visitors List";
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