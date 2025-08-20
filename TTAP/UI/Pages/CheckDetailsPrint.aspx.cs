using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTAP.Classfiles;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data.SqlClient;
using System.Globalization;

namespace TTAP.UI.Pages
{
    public partial class CheckDetailsPrint : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Cast = "1"; //Request.QueryString[0].ToString();
                string DIPCFLAG = "Y"; //Request.QueryString[1].ToString();
                string IncentiveId = "1036"; //Request.QueryString[2].ToString();
                string SubIncentiveid = null; //Convert.ToInt32(Request.QueryString[3]).ToString();


                ds = ObjCAFClass.GetCheckDetailsPrint(Cast, DIPCFLAG, IncentiveId, SubIncentiveid);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    tdinvestments.InnerHtml = "--> " + ds.Tables[0].Rows[0]["IncentiveName"].ToString();
                    Label lblSocialStatus = FindControl("lblSocialStatus") as Label;
                    h1heading.InnerHtml = lblSocialStatus + " Category";
                    GVDetails.DataSource = ds.Tables[0];
                    GVDetails.DataBind();
                }


            }
        }

        protected void chkRow_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                foreach (GridViewRow row in GVDetails.Rows)
                {
                    CheckBox chkRow = (CheckBox)row.FindControl("chkRow");

                    if (chkRow != null && chkRow.Checked)
                    {
                        divForward.Visible = true;
                        return;
                    }
                }

                divForward.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GVDetails_RowCreated(object sender, GridViewRowEventArgs e)
        {
            foreach (TableCell cell in e.Row.Cells)
            {
                cell.Style.Add("mso-style-parent", "style0");
                cell.Style.Add("mso-number-format", "\\@");
            }
        }

        protected void btnChequeList_Click(object sender, EventArgs e)
        {
            try
            {
               // int valid = 0;
                string DIPCFLAG = Request.QueryString[1].ToString();
                foreach (GridViewRow gvrow in GVDetails.Rows)
                {
                    var checkbox = gvrow.FindControl("chkRow") as CheckBox;
                    if (checkbox.Checked)
                    {
                        int rowIndex = gvrow.RowIndex;

                        string lblSubIncentiveID = ((Label)gvrow.FindControl("lblSubIncentiveID")).Text.ToString();
                        string lblIncentiveID = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();

                        string ProposedDate = "";
                        if (TXTCHEQUEGENERATEPRINTDATE.Text.Trim().Contains('/'))
                        {
                            string[] datett = TXTCHEQUEGENERATEPRINTDATE.Text.Trim().Split('/');
                            ProposedDate = datett[2] + "/" + datett[1] + "/" + datett[0];
                        }
                        else if (TXTCHEQUEGENERATEPRINTDATE.Text.Trim().Contains('-'))
                        {
                            string[] datett1 = TXTCHEQUEGENERATEPRINTDATE.Text.Trim().Split('-');
                            ProposedDate = datett1[2] + "/" + datett1[1] + "/" + datett1[0];
                        }
                        string CreatedByid = Session["uid"].ToString();

                        int Result = ObjCAFClass.InsCheckListPrintDetails(DIPCFLAG, lblIncentiveID, lblSubIncentiveID, ProposedDate, CreatedByid);

                        if (Result != 0)
                        {
                            string message = "alert('Check DetaislPrint Successfully')";
                            ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnDownloadPDF_Click(object sender, EventArgs e)
        {
            try
            {
                PrintPdf();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void PrintPdf()
        {
            try
            {
                bool isAnyRowSelected = false;

                foreach (GridViewRow row in GVDetails.Rows)
                {
                    CheckBox chk = (CheckBox)row.FindControl("chkRow");
                    if (chk != null && chk.Checked)
                    {
                        isAnyRowSelected = true;
                        break;
                    }
                }

                if (!isAnyRowSelected)
                {
                    lblmsg0.Text = "Please select at least one row to download the PDF.";
                    Failure.Visible = true;
                    return;
                }

                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {
                        foreach (GridViewRow row in GVDetails.Rows)
                        {
                            CheckBox chk = (CheckBox)row.FindControl("chkRow");
                            if (chk != null && !chk.Checked)
                            {
                                row.Visible = false;
                            }
                        }

                        GVDetails.HeaderRow.ForeColor = System.Drawing.Color.Black;
                        GVDetails.HeaderStyle.ForeColor = System.Drawing.Color.Black;

                        GVDetails.RenderControl(hw);
                        StringReader sr = new StringReader(sw.ToString());

                        using (MemoryStream ms = new MemoryStream())
                        {
                            Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 0f);
                            PdfWriter writer = PdfWriter.GetInstance(pdfDoc, ms);
                            pdfDoc.Open();

                            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                            htmlparser.Parse(sr);

                            pdfDoc.Close();

                            byte[] file = ms.ToArray();
                            Response.Clear();
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-disposition", "attachment;filename=CheckPrintDetails.pdf");
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            Response.BinaryWrite(file);
                            Response.End();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }
    }
}