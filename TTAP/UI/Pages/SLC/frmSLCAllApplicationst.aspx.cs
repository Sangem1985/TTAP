﻿using System;
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
    public partial class frmSLCAllApplicationst : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    string distid = "";
            //    distid = Session["DistrictId"].ToString();

            //    string Cast = Request.QueryString["Cast"].ToString();
            //    string Investmentid = Request.QueryString["SubIncentiveID"].ToString();
            //    lblProposedDLCDate.Text = Request.QueryString["ProposedDLCDate"].ToString();
            //    string Status = Request.QueryString["Status"].ToString();
            //    string TransType = Request.QueryString["TransType"].ToString().Trim();

            //    string[] datett = lblProposedDLCDate.Text.Trim().Split('/');
            //    string ProposedDLCDate = datett[2] + "/" + datett[1] + "/" + datett[0];

            //    DataSet ds = new DataSet();
            //    ds = ObjCAFClass.GetDLCGeneratedAgendaList(Cast, Investmentid, distid, Status, ProposedDLCDate, TransType);
            //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //    {
            //        tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveNameText"].ToString();
            //        h1heading.InnerHtml = ds.Tables[1].Rows[0]["SocialStatusText"].ToString() + " Category";
            //        gvdetailsnew.DataSource = ds.Tables[0];
            //        gvdetailsnew.DataBind();
            //    }
            //}
            if (!IsPostBack)
            {
                // string Slcno = Request.QueryString[0].ToString();
                string Cast = Request.QueryString["Cast"].ToString();
                string Investmentid = Request.QueryString["MstIncentiveId"].ToString();
                string SubIncId = Request.QueryString[2].ToString();
                // string Status = Request.QueryString["Status"].ToString();
                //h1heading.InnerHtml = Cast + " Category";

                string APPMODE = Request.QueryString["APPMODE"].ToString();
                string APPSTATUS = Request.QueryString["APPSTATUS"].ToString();
                string TIMELINES = Request.QueryString["TIMELINES"].ToString();
                string DIPCNumber = Request.QueryString["DIPCNumber"].ToString();


                DropDownList1.SelectedValue = TIMELINES;
                ddlworkingstatus.SelectedValue = APPSTATUS;
                if (DIPCNumber == "0")
                {
                    ddlDIPCno.Text = "ALl Meetings";
                }
                else
                {
                    ddlDIPCno.Text = DIPCNumber;
                }

                string AllApplicationstatus = "";

                if (Request.QueryString["ALLAPPSTATUS"] != null && Request.QueryString["ALLAPPSTATUS"].ToString() == "ALL")
                {
                    AllApplicationstatus = "ALL";
                }
                string PartialSanction = "N";

                if (Request.QueryString["PartialSanction"] != null)
                {
                    PartialSanction = Request.QueryString["PartialSanction"].ToString();
                }

                string Distid = "";
                if (Session["DistrictID"] != null && Session["DistrictID"].ToString().Trim() != "")
                {
                    Distid = Session["DistrictID"].ToString().Trim();
                }

                DataSet ds = new DataSet();

                SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@IncentiveTypID",SqlDbType.VarChar),
                new SqlParameter("@Cast",SqlDbType.VarChar),
                new SqlParameter("@SubIncId",SqlDbType.VarChar),
                new SqlParameter("@APPMODE",SqlDbType.VarChar),
                new SqlParameter("@APPSTATUS",SqlDbType.VarChar),
                new SqlParameter("@DISTCODE",SqlDbType.VarChar),
                new SqlParameter("@TIMELINES",SqlDbType.VarChar),
                new SqlParameter("@DIPCNumer",SqlDbType.VarChar),
                new SqlParameter("@AllApplication", SqlDbType.VarChar),
                new SqlParameter("@PartialSanction", SqlDbType.VarChar)
            };

                pp[0].Value = Investmentid;
                pp[1].Value = Cast;
                pp[2].Value = SubIncId;
                pp[3].Value = APPMODE;
                pp[4].Value = APPSTATUS;
                pp[5].Value = Distid;
                pp[6].Value = TIMELINES;
                pp[7].Value = DIPCNumber;
                pp[8].Value = AllApplicationstatus;
                pp[9].Value = PartialSanction;
                ds = ObjCAFClass.GenericFillDs("USP_GET_ABSTRACT_SLC_APPROVED_LIST", pp);  //USP_GET_UNIT_INCENTIVEWISE_DIPC_NEW_ONLINEAPPS


                //ds = gen.getReleaseProceedingsDIPC(Cast, Investmentid, Session["DistrictID"].ToString().Trim());
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveNameText"].ToString();
                    h1heading.InnerHtml = ds.Tables[1].Rows[0]["SocialStatusText"].ToString() + " Category";
                    gvdetailsnew.DataSource = ds.Tables[0];
                    gvdetailsnew.DataBind();
                    btnprint.Visible = true;
                }
                else
                {
                    btnprint.Visible = false;
                }
                if (Session["Role_Code"].ToString() == "ADDL")
                {
                    gvdetailsnew.Columns[16].Visible = true;
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

        protected void gvdetailsnew_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblIncentiveId = (e.Row.FindControl("lblIncentiveID") as Label);
                    Label lblSubIncentiveId = (e.Row.FindControl("lblSubIncentiveID") as Label);
                    Label lblSanctionStatus = (e.Row.FindControl("lblSanctionStatus") as Label);
                    HyperLink HyperLinkSubsidy = (e.Row.FindControl("hyIssueLetterPath") as HyperLink);
                    string IncentiveId = lblIncentiveId.Text.ToString();
                    string SubIncentiveId = lblSubIncentiveId.Text.ToString();
                    string SanctionStatus = lblSanctionStatus.Text.ToString();
                    if (SanctionStatus == "S")
                    {
                        HyperLinkSubsidy.Text = "View Issued Sanction Letter";
                    }
                    else
                    {
                        HyperLinkSubsidy.Target = "";
                        HyperLinkSubsidy.Text = "Issue";
                        HyperLinkSubsidy.NavigateUrl = "frmIssueSanctionedLetter.aspx?IncentiveId=" + IncentiveId + "&SubIncentiveId=" + SubIncentiveId;
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}