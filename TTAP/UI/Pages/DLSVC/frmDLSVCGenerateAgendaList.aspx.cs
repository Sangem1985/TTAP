using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TTAP.Classfiles;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace TTAP.UI.Pages.DLSVC
{
    public partial class frmDLSVCGenerateAgendaList : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string distid = "";
                distid = Session["DistrictId"].ToString();

                string Cast = Request.QueryString["Cast"].ToString();
                string Investmentid = Request.QueryString["SubIncentiveID"].ToString();
                lblProposedDLCDate.Text = Request.QueryString["ProposedDLCDate"].ToString();
                string Status = Request.QueryString["Status"].ToString();


                DataSet ds = new DataSet();
                ds = ObjCAFClass.GetDLSVCYetGenerateAgendaList(Cast, Investmentid, distid, Status);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveNameText"].ToString();
                    h1heading.InnerHtml = ds.Tables[1].Rows[0]["SocialStatusText"].ToString() + " Category";
                    gvdetailsnew.DataSource = ds.Tables[0];
                    gvdetailsnew.DataBind();
                }
            }
        }

        protected void PrintPdf()
        {
            try
            {
                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {

                        gvdetailsnew.HeaderRow.ForeColor = System.Drawing.Color.Black;
                        gvdetailsnew.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                        gvdetailsnew.FooterRow.ForeColor = System.Drawing.Color.Black;
                        gvdetailsnew.FooterStyle.ForeColor = System.Drawing.Color.Black;

                        // grdExport.Columns[1].Visible = false;
                        gvdetailsnew.RenderControl(hw);
                        StringReader sr = new StringReader(sw.ToString());
                        Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();


                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename= DLCAgenda.pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.Write(pdfDoc);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }

        protected void btnGenerateProposedAgenda_Click(object sender, EventArgs e)
        {
            if (lblProposedDLCDate.Text.Trim() == "")
            {
                string message = "alert('Please Select Proposed DLC Date')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            string valid = "0";
            List<ApplicationStatus> lstApplicationStatus = new List<ApplicationStatus>();
            foreach (GridViewRow gvrow in gvdetailsnew.Rows)
            {
                CheckBox chkcheck = ((CheckBox)gvrow.FindControl("chkRow"));
                if (chkcheck.Checked == true)
                {
                    ApplicationStatus objApplicationStatus = new ApplicationStatus();
                    int rowIndex = gvrow.RowIndex;
                    objApplicationStatus.IncentiveId = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
                    objApplicationStatus.SubIncentiveId = ((Label)gvrow.FindControl("lblSubIncentiveID")).Text.ToString();

                    string[] datett = lblProposedDLCDate.Text.Trim().Split('/');
                    objApplicationStatus.ProposedDLCDate = datett[2] + "/" + datett[1] + "/" + datett[0];
                    objApplicationStatus.CreatedBy = Session["uid"].ToString();
                    objApplicationStatus.TransType = "DLCAGENDA";
                    lstApplicationStatus.Add(objApplicationStatus);
                }
            }
            valid = ObjCAFClass.GenerateDLSVCProposedAgenda(lstApplicationStatus);
            if (valid == "1")
            {
                btnGenerateProposedAgenda.Enabled = false;
                string message = "alert('Proposed DL-SVC Agenda Generated Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                btnDownloadPdf.Visible = false;
                btnprint.Visible = true;
            }
        }
        protected void btnDownloadPdf_Click(object sender, EventArgs e)
        {
            PrintPdf();
        }
    }
}