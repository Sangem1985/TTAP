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

namespace TTAP.UI.Pages.SLC
{
    public partial class frmIssueSanctionedLetter : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        General Gen = new General();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                string distid = "";
                distid = Session["DistrictId"].ToString();

                string IncentiveId = Request.QueryString["IncentiveId"].ToString();
                string SubIncentiveId = Request.QueryString["SubIncentiveId"].ToString();
                
                
                DataSet ds = new DataSet();
                ds = ObjCAFClass.GetSLCGeneratedIssueList(IncentiveId, SubIncentiveId, distid);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {   
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
        protected void btnDownloadPdf_Click(object sender, EventArgs e)
        {
            PrintPdf();
        }

        
       

        protected void btnSanctionLetter_Click(object sender, EventArgs e)
        {
            ClsFileUpload objClsFileUpload = new ClsFileUpload();
            if (fuSanctionLetter.HasFile)
            {
                string Mimetype = objClsFileUpload.getmimetype(fuSanctionLetter);
                if (Mimetype == "application/pdf")
                {
                    string Investmentid = Request.QueryString["SubIncentiveId"].ToString();
                    string Incentiveid = Request.QueryString["IncentiveId"].ToString();
                    string Filesavepath = "~";// ConfigurationManager.AppSettings["IncentiveUploads"].ToString();
                    Filesavepath = Filesavepath + "\\SLCSanctionOrder";

                    string ServerFlag = "N";//ConfigurationManager.AppSettings["FTPFlag"].ToString();
                    string FilesavepathNew = Filesavepath;
                    if (ServerFlag == "N")
                    {
                        FilesavepathNew = Server.MapPath(Filesavepath);
                    }
                    string SanctionLetter_SavedFileLocation = "";

                    string OutPut = objClsFileUpload.IncentiveSanctionLetterFileUploading(Filesavepath, FilesavepathNew, fuSanctionLetter, lblSanctionLetter, "SLCSanctionOrder", Incentiveid, Investmentid, "911131", Session["uid"].ToString(), "ADDL", "", "", out SanctionLetter_SavedFileLocation);
                    lbtnSanctionLetterDelete.Visible = true;
                    ViewState["SanctionLetter_SavedFileLocation"] = SanctionLetter_SavedFileLocation;
                    if (OutPut == "1")
                    {

                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
            fuSanctionLetter.Focus();
        }


        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        public string GetDecimalNullValue(string Input)
        {
            string InputValue = "";

            InputValue = (Input != "") ? Input : "0";

            return InputValue;
        }
        public string GetFromatedDateDDMMYYYY(string Date)
        {
            string Dateformat = "";
            string[] Ld6 = null;
            string ConvertedDt56 = "";
            if (Date != "")
            {
                Ld6 = Date.Split('/');
                ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();
                Dateformat = ConvertedDt56;
            }
            else
            {
                Dateformat = null;
            }
            return Dateformat;
        }

        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if (lblSanctionLetter.Text.Trim().TrimStart() == "")
            {
                string message = "alert('Please Upload Sanction Letter')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

            string valid = "0";
            List<ApplicationStatus> lstApplicationStatus = new List<ApplicationStatus>();
            foreach (GridViewRow gvrow in gvdetailsnew.Rows)
            {
               
                    ApplicationStatus objApplicationStatus = new ApplicationStatus();
                    int rowIndex = gvrow.RowIndex;
                    objApplicationStatus.IncentiveId = ((Label)gvrow.FindControl("lblIncentiveID")).Text.ToString();
                    objApplicationStatus.SubIncentiveId = ((Label)gvrow.FindControl("lblSubIncentiveID")).Text.ToString();
                    objApplicationStatus.SanctionedLetterFilePath = ViewState["SanctionLetter_SavedFileLocation"].ToString();
                    objApplicationStatus.CreatedBy = Session["uid"].ToString();
                    objApplicationStatus.TransType = "UPDATE";
                    lstApplicationStatus.Add(objApplicationStatus);
                
            }
            valid = ObjCAFClass.IssueSanctuionedLetter(lstApplicationStatus);
            if (valid == "1")
            {
                btnSubmit.Enabled = false;
                string message = "alert('Sanctioned Letter Issued Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                btnDownloadPdf.Visible = false;
                btnprint.Visible = true;
            }

        }
        protected void lbtnSanctionLetterDelete_Click(object sender, EventArgs e)
        {
            string Result = "1";
            if (Result == "1")
            {
                lblSanctionLetter.NavigateUrl = "";
                lblSanctionLetter.Text = "";
                lbtnSanctionLetterDelete.Visible = false;
                ViewState["SanctionLetter_SavedFileLocation"] = "";
                MessageBox("Attachment Deleted Successfully..!");
            }
        }
    }
}