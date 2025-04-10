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

namespace TTAP.UI.Pages.SVC
{
    public partial class frmSVCGeneratedAgendaUpdate : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        General Gen = new General();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDLCno.Attributes.Add("onKeyPress", "javascript:return ValidateNumberWithoutSpaceAdhar(event);");
            if (!IsPostBack)
            {
                string distid = "";
                distid = Session["DistrictId"].ToString();

                string Cast = Request.QueryString["Cast"].ToString();
                string Investmentid = Request.QueryString["SubIncentiveID"].ToString();
                lblProposedDLCDate.Text = Request.QueryString["ProposedDLCDate"].ToString();
                txtDLCdate.Text = Request.QueryString["ProposedDLCDate"].ToString();
                string Status = Request.QueryString["Status"].ToString();
                string TransType = Request.QueryString["TransType"].ToString().Trim();
                string PartialSanction = "N";
                if (Request.QueryString["PartialSanction"] != null) {
                    PartialSanction = Request.QueryString["PartialSanction"].ToString().Trim();
                }

                string[] datett = lblProposedDLCDate.Text.Trim().Split('/');
                string ProposedDLCDate = datett[2] + "/" + datett[1] + "/" + datett[0];

                DataSet ds = new DataSet();
                ds = ObjCAFClass.GetSVCGeneratedAgendaList(Cast, Investmentid, distid, Status, ProposedDLCDate, TransType, PartialSanction);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (PartialSanction == "Y")
                    {
                        tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveNameText"].ToString()+" - Partial Sanctions";
                    }
                    else
                    {
                        tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveNameText"].ToString();
                    }
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
                        //iTextSharp.tool.xml.XMLWorkerHelper objworker = new iTextSharp.tool.xml.XMLWorkerHelper();
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

        protected void rbtnLstApprove_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioButtonList ddlDeptnameFnl2 = (RadioButtonList)sender;

            GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
            TextBox txtIncQuery = (TextBox)row.FindControl("txtIncQueryFnl2");
            if (ddlDeptnameFnl2.SelectedValue == "Y")
            {
                txtIncQuery.Visible = false;
            }
            else
            {
                txtIncQuery.Visible = true;
            }
        }
        protected void btnDLCProceedings_Click(object sender, EventArgs e)
        {
            if (txtDLCdate.Text.Trim() == null || txtDLCdate.Text.Trim() == "")
            {
                string message = "alert('Please Enter SVC Date')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            if (txtDLCno.Text.Trim().TrimStart() == null || txtDLCno.Text.Trim().TrimStart() == "")
            {
                string message = "alert('Please Enter SVC Number')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }

            ClsFileUpload objClsFileUpload = new ClsFileUpload();
            if (fuDLCProceedings.HasFile)
            {
                string Mimetype = objClsFileUpload.getmimetype(fuDLCProceedings);
                if (Mimetype == "application/pdf")
                {
                    string Investmentid = Request.QueryString[1].ToString();
                    string Filesavepath = "~";// ConfigurationManager.AppSettings["IncentiveUploads"].ToString();
                    Filesavepath = Filesavepath + "\\DLSVCProceedings";

                    string ServerFlag = "N";//ConfigurationManager.AppSettings["FTPFlag"].ToString();
                    string FilesavepathNew = Filesavepath;
                    if (ServerFlag == "N")
                    {
                        FilesavepathNew = Server.MapPath(Filesavepath);
                    }
                    string SavedFileLocation = "";
                    // string OutPut = objClsFileUpload.IncentiveCAFFileUploading("~\\IncentivesAttachmentsNew", Server.MapPath("~\\IncentivesAttachmentsNew"), fuDocuments1, lblUpload1, "CommCharteredEngineersArchitectsCertificate", Session["EntprIncentive"].ToString(), "53", "200053", Session["uid"].ToString(), "USER");
                    string OutPut = objClsFileUpload.IncentiveProceedingsFileUploading(Filesavepath, FilesavepathNew, fuDLCProceedings, lblDLCProceedings, "DLSVCProceedings", "0", Investmentid, "911122", Session["uid"].ToString(), "DLO", txtDLCno.Text, GetFromatedDateDDMMYYYY(txtDLCdate.Text.Trim()), out SavedFileLocation);
                    lbtnDLCProceedingsDelete.Visible = true;
                    ViewState["SavedFileLocation"] = SavedFileLocation;
                    if (OutPut == "1")
                    {

                    }
                }
                else
                {
                    MessageBox("Only pdf files allowed!");
                }
            }
            fuDLCProceedings.Focus();
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

        protected void lbtnDLCProceedingsDelete_Click(object sender, EventArgs e)
        {
            string Result = "";
            //string Result = Gen.DeleteFilefromDB("101", "911122", Session["uid"].ToString());

            if (Result == "1")
            {
                lblDLCProceedings.NavigateUrl = "";
                lblDLCProceedings.Text = "";
                lbtnDLCProceedingsDelete.Visible = false;
                ViewState["SavedFileLocation"] = "";
                MessageBox("Attachment Deleted Successfully..!");
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtDLCdate.Text.Trim() == null || txtDLCdate.Text.Trim() == "")
            {
                string message = "alert('Please Select SVC Date')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            if (txtDLCno.Text.Trim().TrimStart() == null || txtDLCno.Text.Trim().TrimStart() == "")
            {
                string message = "alert('Please Enter SVC Number')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                return;
            }
            if (lblDLCProceedings.Text.Trim().TrimStart() == "")
            {
                string message = "alert('Please Upload SVC Proceeding')";
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
                    objApplicationStatus.ApproveStatus = ((RadioButtonList)gvrow.FindControl("rbtnLstApprove")).SelectedValue;
                    string SactionnedAmount = ((TextBox)gvrow.FindControl("txtsactionnedAmount")).Text.Trim();

                    //objApplicationStatus.PartialSanction = ((Label)gvrow.FindControl("lblPartialSanction")).Text.ToString();
                    //objApplicationStatus.TISId = ((Label)gvrow.FindControl("lblTISId")).Text.ToString();
                    //string TextileSanctionedAmount= ((TextBox)gvrow.FindControl("txtsactionnedAmountHand")).Text.Trim();
                    //string IndustriesSanctionedAmount = ((TextBox)gvrow.FindControl("txtsactionnedAmountInd")).Text.Trim();

                    string rejectedRemarks = ((TextBox)gvrow.FindControl("txtIncQueryFnl2")).Text.Trim();

                    if (objApplicationStatus.ApproveStatus.Trim() == "Y")
                    {

                        objApplicationStatus.Remarks = SactionnedAmount;
                    }
                    else if (objApplicationStatus.ApproveStatus.Trim() == "N")
                    {
                        objApplicationStatus.Remarks = rejectedRemarks;
                    }

                    objApplicationStatus.RecommendedAmount = SactionnedAmount;
                    objApplicationStatus.TextileSanctionedAmount = "";
                    objApplicationStatus.IndustriesSanctionedAmount = "";

                    objApplicationStatus.FilePath = ViewState["SavedFileLocation"].ToString();

                    string[] datett = txtDLCdate.Text.Trim().Split('/');
                    objApplicationStatus.ProposedDLCDate = datett[2] + "/" + datett[1] + "/" + datett[0];
                    objApplicationStatus.DLCNo = txtDLCno.Text.Trim().TrimStart();

                    objApplicationStatus.CreatedBy = Session["uid"].ToString();
                    objApplicationStatus.TransType = "UPDATE";
                    lstApplicationStatus.Add(objApplicationStatus);
                }
            }
            valid = ObjCAFClass.UpdateGeneratedSVCProposedAgenda(lstApplicationStatus);
            if (valid == "1")
            {
                btnSubmit.Visible = false;
                string message = "alert('SVC Application Details Updated Successfully')";
                ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                btnDownloadPdf.Visible = false;
                btnprint.Visible = true;
            }

        }

        protected void gvdetailsnew_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    TextBox txtsactionnedAmountHand = (e.Row.FindControl("txtsactionnedAmountHand") as TextBox);
                    TextBox txtsactionnedAmountInd = (e.Row.FindControl("txtsactionnedAmountInd") as TextBox);
                    TextBox txtsactionnedAmount = (e.Row.FindControl("txtsactionnedAmount") as TextBox);
                    decimal TTAPAmount = 0;
                    decimal IndustriesAmount = 0;
                    if (txtsactionnedAmountHand.Text != "")
                    {
                        TTAPAmount = Convert.ToDecimal(txtsactionnedAmountHand.Text.ToString());
                    }
                    if (txtsactionnedAmountInd.Text != "")
                    {
                        IndustriesAmount = Convert.ToDecimal(txtsactionnedAmountInd.Text.ToString());
                    }
                    txtsactionnedAmount.Text = (TTAPAmount + IndustriesAmount).ToString();
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }

        protected void txtsactionnedAmountInd_TextChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in gvdetailsnew.Rows)
            {
                TextBox txtsactionnedAmountHand = ((TextBox)gvrow.FindControl("txtsactionnedAmountHand"));
                TextBox txtsactionnedAmountInd = ((TextBox)gvrow.FindControl("txtsactionnedAmountInd"));
                TextBox txtsactionnedAmount = ((TextBox)gvrow.FindControl("txtsactionnedAmount"));
                decimal TTAPAmount = 0;
                decimal IndustriesAmount = 0;
                if (txtsactionnedAmountHand.Text != "")
                {
                    TTAPAmount = Convert.ToDecimal(txtsactionnedAmountHand.Text.ToString());
                }
                if (txtsactionnedAmountInd.Text != "")
                {
                    IndustriesAmount = Convert.ToDecimal(txtsactionnedAmountInd.Text.ToString());
                }
                txtsactionnedAmount.Text = (TTAPAmount + IndustriesAmount).ToString();
                txtsactionnedAmount.Focus();
            }
        }
    }
}