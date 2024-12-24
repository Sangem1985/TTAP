using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using TTAP.Classfiles;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Xml.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace TTAP.UI.Pages
{
    public partial class FormCreateAgenda : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();
        General Gen = new General();
        BusinessLogic.DML objDml = new BusinessLogic.DML();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("TermLoan");
                dt.Columns.Add("Year");dt.Columns.Add("Bank");dt.Columns.Add("LoanACNo");dt.Columns.Add("SanctionOrderNo");dt.Columns.Add("AmountSanctioned");dt.Columns.Add("RateofInterest");
                dt.Columns.Add("Disbursed");dt.Columns.Add("OutstandingBalance");dt.Columns.Add("Paidaspercertificate");
                ViewState["LoanDtls"] = dt;
                DataTable dtIS = new DataTable("IntSanction");
                dtIS.Columns.Add("Year"); dtIS.Columns.Add("HalYear"); dtIS.Columns.Add("Amount");
                ViewState["INTSanctionDtls"] = dtIS;
            }

        }
        [WebMethod]
        public static string GetData(string ApplicationNo)
        {
            List<Incentive> listIncentive = new List<Incentive>();
            string CS = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("USP_GET_INCENTIVES_CAF_DATA_FOR_AGENDA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@APPLICATIONNO",
                    Value = ApplicationNo
                });
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Incentive incentive = new Incentive();
                    incentive.UnitName = rdr["UnitName"].ToString();
                    incentive.Uid_NO = rdr["Uid_NO"].ToString();
                    incentive.Category = rdr["Category"].ToString();
                    incentive.TypeOfIndustryText = rdr["TypeOfIndustryText"].ToString();
                    listIncentive.Add(incentive);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(listIncentive);
        }

        public void GeneratePdf()
        {
            try
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                //DataSet dsIncentiveList = new DataSet();
                //dsIncentiveList = Gen.GetAllIncentives(UserID);
                //Session["incentivedata"] = dsIncentiveList;
                string LetterNumber = "1234";
                string LetterInitiationDate = "01-01-2023";
                string LetterApprovedDate = "01-12-2023";
                string ApplicationNumber = "INCTEXT123456";
                string ApplicationFiledDate = "01-02-2023";
                string UnitName = "TELANGANA TEXTILES";
                string UnitHNO = "123";
                string UnitStreet = "NAMPALLY";
                string District_Name = "RANGAREDDY";
                string Manda_lName = "RANGAREDDY";
                string Village_Name = "HYDERABAD";


                DataSet ds = new DataSet();
               // ds = GetIncentiveQuery(ViewState["IncentiveID"].ToString(), ViewState["MainQueryID"].ToString());
               /* if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    LetterNumber = ds.Tables[1].Rows[0]["LetterNo"].ToString();
                    LetterInitiationDate = ds.Tables[1].Rows[0]["LetterDate"].ToString();
                    LetterApprovedDate = ds.Tables[1].Rows[0]["LetterApprovalDate"].ToString();
                }
                if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
                {
                    ApplicationNumber = ds.Tables[2].Rows[0]["ApplicationNumber"].ToString();
                    ApplicationFiledDate = ds.Tables[2].Rows[0]["ApplicationFiledDate"].ToString();
                    UnitName = ds.Tables[2].Rows[0]["UnitName"].ToString();
                    UnitHNO = ds.Tables[2].Rows[0]["UnitHNO"].ToString();
                    UnitStreet = ds.Tables[2].Rows[0]["UnitStreet"].ToString();
                    District_Name = ds.Tables[2].Rows[0]["District_Name"].ToString();
                    Manda_lName = ds.Tables[2].Rows[0]["Manda_lName"].ToString();
                    Village_Name = ds.Tables[2].Rows[0]["Village_Name"].ToString();
                }*/

                Document document = new Document(PageSize.A4, 20f, 20f, 20f, 50f);
                Font NormalFont = FontFactory.GetFont("trebuchet ms", 12, Font.NORMAL, BaseColor.BLACK);

                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);

                    Phrase phrase = null;
                    PdfPCell cell = null;
                    PdfPTable table = null;
                    PdfPTable tablenew = null;
                    // BaseColor color = null;

                    document.Open();
                    writer.PageEvent = new Footer();
                    //Header Table
                    PdfContentByte contentBytenew = writer.DirectContent;

                    table = new PdfPTable(3);
                    table.TotalWidth = document.PageSize.Width - 60f;
                    //table.SetWidths(new float[] { 0.1f, 0.8f, 0.1f });
                    //table.LockedWidth = true;

                   /* cell = ImageCell("~/images/logo.png", 6f, PdfPCell.ALIGN_CENTER);
                    cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                    table.AddCell(cell);
                    // trebuchet ms
                    phrase = new Phrase();
                    phrase.Add(new Chunk("Department of Handlooms and Textiles\n\n".ToUpper(), FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    phrase.Add(new Chunk("GOVERNMENT OF TELANGANA", FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
                    cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.Colspan = 2;
                    table.AddCell(cell);*/

                    phrase = new Phrase();
                    phrase.Add(new Chunk("STATE LEVEL SCRUTINY/VERIFICATION COMMITTEE \n", FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    phrase.Add(new Chunk("MEETING FOR SCRUTINY AND VERIFICATION OF \n", FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    phrase.Add(new Chunk("INCENTIVE CLAIMS UNDER T-TAP POLICY \n", FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    // phrase.Add(new Chunk("\n" + tcMergePackage, FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
                    cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.Colspan = 2;
                    cell.PaddingTop = 15f;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    document.Add(table);

                    /*table = new PdfPTable(2);
                    table.TotalWidth = document.PageSize.Width - 60f;
                    table.SetWidths(new float[] { 0.5f, 0.5f });
                    table.LockedWidth = true;

                    BaseColor colorline = new BaseColor(6, 170, 26);
                    DrawLineMiddleline(writer, 2f, document.Top - 55f, document.PageSize.Width - 2f, document.Top - 55f, colorline);

                    phrase = new Phrase();
                    phrase.Add(new Chunk("File No :" + LetterNumber, FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                    cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;

                    cell.PaddingTop = 5f;
                    //cell.PaddingBottom = 20f;
                    table.AddCell(cell);


                    phrase = new Phrase();
                    phrase.Add(new Chunk("Dated :" + LetterInitiationDate, FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
                    cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    cell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;

                    cell.PaddingTop = 5f;
                    //cell.PaddingBottom = 20f;
                    table.AddCell(cell);*/

                    //phrase = new Phrase();
                    //phrase.Add(new Chunk(LetterNumber+ ", Dated: "+ LetterInitiationDate + "\n", FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    //// phrase.Add(new Chunk("\n" + tcMergePackage, FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
                    //cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                    //cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                    //cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    //cell.Colspan = 2;
                    //cell.PaddingTop = 15f;
                    //cell.PaddingBottom = 10f;
                    //table.AddCell(cell);

                    phrase = new Phrase();
                    phrase.Add(new Chunk("MEETING ON\n", FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    phrase.Add(new Chunk("21-08-2023 AT 3-00PM\n", FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    phrase.Add(new Chunk("AT CONFERENCE HALL,\n", FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    phrase.Add(new Chunk("DIRECTORATE OF INDUSTRIES,\n", FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    phrase.Add(new Chunk("CHIRAG ALI LANE,ABIDS,HYFERABAD\n", FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
                    cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.Colspan = 2;
                    cell.PaddingTop = 10f;
                    cell.PaddingBottom = 10f;
                    table.AddCell(cell);
                    //document.Add(table);


                    phrase = new Phrase();
                    phrase.Add(new Chunk("Dear Sir/Madam,\n", FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));

                    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                    cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                    cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    cell.Colspan = 2;
                    cell.PaddingTop = 15f;
                    //cell.PaddingBottom = 10f;
                    table.AddCell(cell);


                    phrase = new Phrase();
                    phrase.Add(new Chunk("       State level lication No. ", FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));
                    phrase.Add(new Chunk(ApplicationNumber + ". Dated " + ApplicationFiledDate, FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                    phrase.Add(new Chunk(", It is to Inform You That Your Incentive Claim Applications has been Verified and Found the Following Deficiencies.,\n\n", FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                    cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                    cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                    cell.Colspan = 2;
                    cell.PaddingTop = 10f;
                    //cell.PaddingBottom = 10f;
                    table.AddCell(cell);

                    document.Add(table);

                    string Slno = "";
                    //string Heading = "";
                    string QueryID = "";
                    string Query = "";
                    DataTable dtQueries = new DataTable();
                    dtQueries.Clear();
                    dtQueries.Columns.Add("SNo");
                    dtQueries.Columns.Add("QueryID");
                    dtQueries.Columns.Add("Query");

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
                        {
                            DataRow Data = dtQueries.NewRow();
                            Data["SNo"] = dr["SNo"].ToString();
                            Data["QueryID"] = dr["QueryId"].ToString();
                            Data["Query"] = dr["Query"].ToString();
                            dtQueries.Rows.Add(Data);
                        }

                        int CountColumns = dtQueries.Columns.Count;

                        tablenew = new PdfPTable(2);
                        tablenew.SetWidths(new float[] { 0.05f, 0.95f });
                        tablenew.TotalWidth = document.PageSize.Width - 60f;
                        tablenew.LockedWidth = true;
                        tablenew.SpacingBefore = 5f;
                        tablenew.HorizontalAlignment = Element.ALIGN_MIDDLE;

                        int RomanNumber = 1;

                        for (int i = 0; i < dtQueries.Rows.Count; i++)
                        {
                            Slno = dtQueries.Rows[i]["SNo"].ToString();
                            QueryID = dtQueries.Rows[i]["QueryID"].ToString();
                            Query = dtQueries.Rows[i]["Query"].ToString();

                            string cellText = "";

                            phrase = new Phrase();

                            if (Slno == "0")
                            {
                                Slno = "";
                                cellText = ToRoman(RomanNumber) + "). " + Query;
                                cellText = Server.HtmlDecode(cellText);
                                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Calibri", 10, Font.BOLD, BaseColor.BLACK)));
                                //cell.PaddingBottom = 10f;
                                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                                cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                cell.Colspan = 2;
                                cell.PaddingTop = 15f;
                                cell.PaddingBottom = 5;
                                cell.MinimumHeight = 20f;

                                //cell.BorderWidthRight = 0.5f;
                                //cell.BorderWidthLeft = 0.5f;
                                //cell.BorderWidthTop = 0.5f;
                                //cell.BorderWidthBottom = 0.5f;
                                //cell.BorderColorBottom = BaseColor.BLACK;
                                //cell.BorderColorTop = BaseColor.BLACK;
                                //cell.BorderColorLeft = BaseColor.BLACK;
                                //cell.BorderColorRight = BaseColor.BLACK;

                                tablenew.AddCell(cell);
                                RomanNumber = RomanNumber + 1;
                            }
                            else
                            {
                                phrase = new Phrase();
                                cellText = Slno + ". ";
                                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));
                                cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
                                cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                                cell.HorizontalAlignment = Element.ALIGN_RIGHT;

                                cell.PaddingBottom = 10;
                                cell.MinimumHeight = 20f;
                                tablenew.AddCell(cell);

                                phrase = new Phrase();
                                cellText = Server.HtmlDecode(Query);
                                phrase.Add(new Chunk("Query ID :" + QueryID + "\n\n", FontFactory.GetFont("Calibri", 10, Font.BOLD | Font.UNDERLINE, BaseColor.BLACK)));
                                //phrase.SetLeading(1.0f, 3.0f);
                                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));
                                cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                                cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                                cell.HorizontalAlignment = Element.ALIGN_LEFT;

                                cell.PaddingBottom = 10;
                                cell.MinimumHeight = 20f;

                                //cell.BorderWidthRight = 0.5f;
                                //cell.BorderWidthLeft = 0.5f;
                                //cell.BorderWidthTop = 0.5f;
                                //cell.BorderWidthBottom = 0.5f;
                                //cell.BorderColorBottom = BaseColor.BLACK;
                                //cell.BorderColorTop = BaseColor.BLACK;
                                //cell.BorderColorLeft = BaseColor.BLACK;
                                //cell.BorderColorRight = BaseColor.BLACK;

                                tablenew.AddCell(cell);
                            }
                        }

                        document.Add(tablenew);

                        DataSet dsattachment = new DataSet();
                        //dsattachment = GetIncetiveAttachementsView(ViewState["IncentiveID"].ToString(), ViewState["MainQueryID"].ToString());
                        if (dsattachment != null && dsattachment.Tables.Count > 0 && dsattachment.Tables[0].Rows.Count > 0)
                        {
                            int CountColumns1 = dsattachment.Tables[0].Columns.Count;
                            tablenew = new PdfPTable(CountColumns1); //3
                            tablenew.SetWidths(new float[] { 0.05f, 0.4f, 0.55f });
                            tablenew.TotalWidth = document.PageSize.Width - 60f;
                            tablenew.LockedWidth = true;
                            tablenew.SpacingBefore = 5f;
                            tablenew.HorizontalAlignment = Element.ALIGN_MIDDLE;


                            for (int i = 0; i < CountColumns1; i++)
                            {
                                string cellText = "";
                                cellText = Server.HtmlDecode(dsattachment.Tables[0].Columns[i].ColumnName);
                                phrase = new Phrase();
                                phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, BaseColor.BLACK)));
                                cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                                cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#D3D3D3"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
                                cell.PaddingBottom = 5;
                                cell.MinimumHeight = 30f;
                                cell.BorderWidthRight = 0.5f;
                                cell.BorderWidthLeft = 0.5f;
                                cell.BorderWidthTop = 0.5f;
                                cell.BorderWidthBottom = 0.5f;
                                cell.BorderColorBottom = BaseColor.BLACK;
                                cell.BorderColorTop = BaseColor.BLACK;
                                cell.BorderColorLeft = BaseColor.BLACK;
                                cell.BorderColorRight = BaseColor.BLACK;
                                tablenew.AddCell(cell);
                            }
                            for (int i = 0; i < dsattachment.Tables[0].Rows.Count; i++)
                            {
                                string Header = dsattachment.Tables[0].Rows[i]["SNO"].ToString();
                                for (int j = 0; j < CountColumns1; j++)
                                {
                                    string cellText = "";
                                    //HyperLink h4 = null;
                                    phrase = new Phrase();

                                    cellText = Server.HtmlDecode(dsattachment.Tables[0].Rows[i][j].ToString());
                                    if (j == 0 && Header == "0")
                                    {
                                        cellText = "";
                                    }
                                    else if (j == 1 && Header == "0")
                                    {
                                        phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 10, Font.BOLD, BaseColor.BLACK)));
                                    }
                                    else
                                    {
                                        phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 10, Font.NORMAL, BaseColor.BLACK)));
                                    }

                                    if (j == 0)
                                    {
                                        cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                                        cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                    }
                                    else //if (j == 1)
                                    {
                                        cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                                        cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                                        cell.HorizontalAlignment = Element.ALIGN_LEFT;
                                    }
                                    //else
                                    //{
                                    //    cell = PhraseCell(phrase, PdfPCell.ALIGN_RIGHT);
                                    //    cell.VerticalAlignment = PdfCell.ALIGN_MIDDLE;
                                    //    cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                                    //}


                                    cell.BorderWidthRight = 0.5f;
                                    cell.BorderWidthLeft = 0.5f;
                                    cell.BorderWidthTop = 0.5f;
                                    cell.BorderWidthBottom = 0.5f;

                                    cell.BorderColorBottom = BaseColor.BLACK;
                                    cell.BorderColorTop = BaseColor.BLACK;
                                    cell.BorderColorLeft = BaseColor.BLACK;
                                    cell.BorderColorRight = BaseColor.BLACK;
                                    if (j == 1 && Header == "0")
                                    {
                                        cell.Colspan = 2;
                                    }
                                    else if (j > 1 && Header == "0")
                                    {
                                        continue;
                                    }
                                    cell.PaddingBottom = 5;
                                    cell.PaddingLeft = 5;
                                    cell.MinimumHeight = 30f;
                                    tablenew.AddCell(cell);
                                }

                                var remainingPageSpace = writer.GetVerticalPosition(false) - document.BottomMargin;
                                var initialPosition = writer.GetVerticalPosition(false);
                                var tablehiht = tablenew.TotalHeight;

                                if (remainingPageSpace >= tablehiht && remainingPageSpace - 50 <= tablehiht)
                                {
                                    BaseColor Color2 = new BaseColor(6, 170, 26);
                                    contentBytenew.SetColorStroke(Color2);
                                    contentBytenew.Circle(document.PageSize.Width - 23f, document.PageSize.Bottom + 23f, 10f);
                                    contentBytenew.Stroke();

                                    ColumnText.ShowTextAligned(contentBytenew, Element.ALIGN_RIGHT, new Phrase((writer.PageNumber).ToString(), FontFactory.GetFont("Trebuchet MS", 12, Font.BOLD, BaseColor.BLACK)), document.PageSize.Width - 20f, document.PageSize.Bottom + 20f, 2);

                                    document.Add(tablenew);
                                    document.NewPage();
                                    tablenew.DeleteBodyRows();

                                    for (int k = 0; k < CountColumns1; k++)
                                    {
                                        string cellText = "";
                                        cellText = Server.HtmlDecode(dsattachment.Tables[0].Columns[k].ColumnName);
                                        phrase = new Phrase();
                                        phrase.Add(new Chunk(cellText, FontFactory.GetFont("Trebuchet MS", 11, Font.NORMAL, BaseColor.BLACK)));
                                        cell = PhraseCell(phrase, PdfPCell.ALIGN_MIDDLE);
                                        cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                                        cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#D3D3D3"));  //new Color(grdDetails.HeaderStyle.BackColor);  //#009688
                                        cell.PaddingBottom = 5;
                                        cell.MinimumHeight = 30f;
                                        cell.BorderWidthRight = 0.5f;
                                        cell.BorderWidthLeft = 0.5f;
                                        cell.BorderWidthTop = 0.5f;
                                        cell.BorderWidthBottom = 0.5f;
                                        cell.BorderColorBottom = BaseColor.BLACK;
                                        cell.BorderColorTop = BaseColor.BLACK;
                                        cell.BorderColorLeft = BaseColor.BLACK;
                                        cell.BorderColorRight = BaseColor.BLACK;
                                        tablenew.AddCell(cell);
                                    }
                                }
                            }
                            document.Add(tablenew);
                        }

                        tablenew = new PdfPTable(2);
                        tablenew.SetWidths(new float[] { 0.5f, 0.5f });
                        tablenew.TotalWidth = document.PageSize.Width - 60f;
                        tablenew.LockedWidth = true;
                        tablenew.SpacingBefore = 5f;
                        tablenew.HorizontalAlignment = Element.ALIGN_MIDDLE;


                        phrase = new Phrase();
                        phrase.Add(new Chunk("      You are requested to comply the above objections within 45 days from date of communication of this letter, failing which the application shall be rejected.\n\n", FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));

                        cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.Colspan = 2;
                        cell.PaddingTop = 15f;
                        cell.PaddingBottom = 10f;
                        tablenew.AddCell(cell);

                        phrase = new Phrase();
                        phrase.Add(new Chunk("", FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));
                        cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                        cell.PaddingTop = 15f;
                        cell.PaddingBottom = 10f;
                        tablenew.AddCell(cell);

                        phrase = new Phrase();


                        if (ObjLoginNewvo.Role_Code == "DLO")
                        {
                            phrase.Add(new Chunk("Sd/- DLO-" + District_Name + ",\n for Commissioner H&T & AEPs", FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));
                        }
                        else
                        {
                            phrase.Add(new Chunk("Sd/- Tasneem Athar Jahan,\n for Commissioner H&T & AEPs", FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));
                        }
                        cell = PhraseCell(phrase, PdfPCell.ALIGN_CENTER);
                        cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
                        cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                        //cell.Colspan = 2;
                        cell.PaddingTop = 15f;
                        cell.PaddingBottom = 10f;
                        tablenew.AddCell(cell);

                        if (ObjLoginNewvo.Role_Code != "DLO")
                        {
                            phrase = new Phrase();
                            phrase.Add(new Chunk("Assistant Director (H&T)\n", FontFactory.GetFont("Calibri", 10, Font.NORMAL, BaseColor.BLACK)));
                            // phrase.Add(new Chunk("\n" + tcMergePackage, FontFactory.GetFont("trebuchet ms", 12, Font.BOLD, Color.BLACK)));
                            cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                            cell.VerticalAlignment = PdfPCell.ALIGN_CENTER;
                            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                            cell.Colspan = 2;
                            cell.PaddingTop = 15f;
                            cell.PaddingBottom = 10f;
                            tablenew.AddCell(cell);
                        }
                        document.Add(tablenew);
                    }

                    // Page Number
                    BaseColor Color1 = new BaseColor(6, 170, 26);
                    contentBytenew.SetColorStroke(Color1);
                    contentBytenew.Circle(document.PageSize.Width - 23f, document.PageSize.Bottom + 23f, 10f);
                    contentBytenew.Stroke();
                    ColumnText.ShowTextAligned(contentBytenew, Element.ALIGN_RIGHT, new Phrase((writer.PageNumber).ToString(), FontFactory.GetFont("Trebuchet MS", 12, Font.BOLD, BaseColor.BLACK)), document.PageSize.Width - 20f, document.PageSize.Bottom + 20f, 2);
                    //document.Add(tablenew);

                    document.Close();
                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "attachment; filename=Shortfall_" + ApplicationNumber + "_" + DateTime.Now.ToString("M/d/yyyy") + ".pdf");
                    Response.ContentType = "application/pdf";
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();
                    Response.Close();
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                //LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }

        private string ToRoman(int romanNumber)
        {
            throw new NotImplementedException();
        }

        public partial class Footer : PdfPageEventHelper
        {
            //new Color(127, 127, 127)
            public override void OnEndPage(PdfWriter writer, Document doc)
            {
                Paragraph footer = new Paragraph(char.ConvertFromUtf32(169).ToString() + " Government of Telangana.", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 10, iTextSharp.text.Font.BOLD, BaseColor.BLACK));
                footer.Alignment = Element.ALIGN_LEFT;
                PdfPTable footerTbl = new PdfPTable(1);
                footerTbl.TotalWidth = 500f;
                footerTbl.HorizontalAlignment = Element.ALIGN_LEFT;
                PdfPCell cell = new PdfPCell(footer);
                cell.Border = 0;
                cell.PaddingLeft = 10;
                footerTbl.AddCell(cell);
                footerTbl.WriteSelectedRows(0, -1, 30, 40, writer.DirectContent);
            }
        }
        private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, BaseColor color)
        {
            PdfContentByte contentByte = writer.DirectContent;
            contentByte.SetColorStroke(color);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.SetLineWidth(1f);
            contentByte.Stroke();
        }
        private static void DrawLineMiddleline(PdfWriter writer, float x1, float y1, float x2, float y2, BaseColor color)
        {
            PdfContentByte contentByte = writer.DirectContent;
            contentByte.SetColorStroke(color);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.SetLineWidth(2f);
            contentByte.Stroke();
        }
        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            //added by chandrika
            //cell.Border = 0;
            //cell.BorderColorLeft = BaseColor.BLACK;
            //cell.BorderWidthLeft = .5f;
            //cell.BorderColorTop = BaseColor.BLACK;
            //cell.BorderWidthTop = .5f;
            //cell.BorderColorBottom = BaseColor.BLACK;
            //cell.BorderWidthBottom = .5f;
            //cell.BorderColorRight = BaseColor.BLACK;
            //cell.BorderWidthRight = .5f;
            //uptohere
            return cell;
        }

        private static PdfPCell PhraseCellnew(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = align;
            //cell.PaddingBottom = 5f;
            //cell.PaddingTop = 5f;
            cell.BorderWidthRight = 0.5f;
            cell.BorderWidthLeft = 0.5f;
            cell.BorderWidthTop = 0.5f;
            cell.BorderWidthBottom = 0.5f;
            cell.BorderColorBottom = BaseColor.BLACK;
            cell.BorderColorTop = BaseColor.BLACK;
            cell.BorderColorLeft = BaseColor.BLACK;
            cell.BorderColorRight = BaseColor.BLACK;
            // cell.MinimumHeight = 30f;
            cell.Padding = 5f;

            return cell;
        }
        private static PdfPCell PhraseCellData(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.BLACK;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.Colspan = 1;
            // cell.Padding = 5;
            // cell.FixedHeight = 25f;
            cell.Border = 0;
            cell.BorderColorLeft = BaseColor.BLACK;
            cell.BorderWidthLeft = .5f;
            cell.BorderColorTop = BaseColor.BLACK;
            cell.BorderWidthTop = .5f;
            cell.BorderColorBottom = BaseColor.BLACK;
            cell.BorderWidthBottom = .5f;
            cell.BorderColorRight = BaseColor.BLACK;
            cell.BorderWidthRight = .5f;
            return cell;
        }
        private static PdfPCell ImageCell(string path, float scale, int align)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
            image.ScalePercent(scale);
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 0f;
            cell.PaddingTop = 0f;

            //cell.BorderColorLeft = BaseColor.BLACK;
            //cell.BorderWidthLeft = .5f;
            //cell.BorderColorTop = BaseColor.BLACK;
            //cell.BorderWidthTop = .5f;
            //cell.BorderColorBottom = BaseColor.BLACK;
            //cell.BorderWidthBottom = .5f;
            //cell.BorderColorRight = BaseColor.BLACK;
            //cell.BorderWidthRight = .5f;

            return cell;
        }
        public string DisplayWithSuffix(int num)
        {
            if (num.ToString().EndsWith("11")) return num.ToString() + "th";
            if (num.ToString().EndsWith("12")) return num.ToString() + "th";
            if (num.ToString().EndsWith("13")) return num.ToString() + "th";
            if (num.ToString().EndsWith("1")) return num.ToString() + "st";
            if (num.ToString().EndsWith("2")) return num.ToString() + "nd";
            if (num.ToString().EndsWith("3")) return num.ToString() + "rd";
            return num.ToString() + "th";
        }
        private static PdfPCell PhraseCellForallheadings(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            cell.Border = 0;
            return cell;
        }
        private static PdfPCell PhraseCellheadings(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = BaseColor.WHITE;
            cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            return cell;
        }
        public class Incentive
        {
            public string UnitName { get; set; }
            public string Uid_NO { get; set; }
            public string Category { get; set; }
            public string TypeOfIndustryText { get; set; }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GeneratePdf();
        }

        protected void btnGetIncentives_Click(object sender, EventArgs e)
        {
            string AppNo = txtApplicationNo.Text.Trim();
            DataSet dsInc = new DataSet();
            dsInc = GetIncentives(AppNo);
            if (dsInc != null && dsInc.Tables.Count > 0 && dsInc.Tables[0].Rows.Count > 0)
            {
                ddlIncentive.DataSource = dsInc.Tables[0];
                ddlIncentive.DataValueField = "SubIncentiveID";
                ddlIncentive.DataTextField = "IncentiveName";
                ddlIncentive.DataBind();
                ddlIncentive.Items.Insert(0, "--Select--");
                hdnIncentiveId.Value = dsInc.Tables[0].Rows[0]["IncentiveID"].ToString();
                ddlIncentive.SelectedIndex = 1;
            }
            else
            {
                ddlIncentive.Items.Insert(0, "--Select--");
            }
        }

        protected void btnGetData_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = GetapplicationDtls("0", hdnIncentiveId.Value);
            string IncentiveName = ddlIncentive.SelectedItem.ToString();
            string AgendaHeaderText = "APPRAISAL NOTE FOR SANTION  OF " + IncentiveName + " UNDER T-TAP TO " + ds.Tables[0].Rows[0]["UnitName"].ToString() + ".," + ds.Tables[0].Rows[0]["Authorized_CorresponAdderess"].ToString() + ".";
            AgendaHead.InnerText = AgendaHeaderText.ToString().ToUpper();
            lblUnitName.InnerText = ds.Tables[0].Rows[0]["UnitName"].ToString();
            lblAddress.InnerText = ds.Tables[0].Rows[0]["Authorized_CorresponAdderess"].ToString();
            lblNameoftheProprietor.InnerText = ds.Tables[0].Rows[0]["AuthorisedPerson"].ToString();
            lblConstitution.InnerText = ds.Tables[0].Rows[0]["ConstitutionUnit"].ToString();
            lblGender.InnerText = ds.Tables[0].Rows[0]["GenderText"].ToString();
            lblSocialStatus.InnerText = ds.Tables[0].Rows[0]["SocialStatusText"].ToString();
            lblIncorporationNo.InnerText = ds.Tables[0].Rows[0]["IncorpRegistranNumber"].ToString() + "-" + ds.Tables[0].Rows[0]["IncorpRegistranNumber"].ToString();
            lblTypeofUnit.InnerText = ds.Tables[0].Rows[0]["TypeOfIndustryText"].ToString();
            lblCategory.InnerText = ds.Tables[0].Rows[0]["Category"].ToString();
            lblTypeofSector.InnerText = ds.Tables[0].Rows[0]["Type_Of_Sector"].ToString();
            lblTypeofTextiles.InnerText = ds.Tables[0].Rows[0]["TypeofTexttileText"].ToString();
            lblNatureofIndustry.InnerText = ds.Tables[0].Rows[0]["TextileProcessName"].ToString();
            lblTypeofProduct.InnerText = ds.Tables[0].Rows[0]["ProductDtls"].ToString();
            lblUIDNo.InnerText = ds.Tables[0].Rows[0]["Uid_NO"].ToString();
            lblApplicationNo.InnerText = ds.Tables[0].Rows[0]["ApplicationNumber"].ToString();
            lblGSTRegistrationNumber.InnerText = ds.Tables[0].Rows[0]["GST_Reg_No"].ToString();
            lblPowerConnectionDt.InnerText = ds.Tables[0].Rows[0]["NewPowerReleaseDate"].ToString();
            lblDCP.InnerText = ds.Tables[0].Rows[0]["DCP"].ToString();
            lblAppliedDt.InnerText = ds.Tables[0].Rows[0]["SubmissionDate"].ToString();
            lblDOQ.InnerText = ds.Tables[0].Rows[0]["Query_Dates"].ToString();
            lblResponse.InnerText = ds.Tables[0].Rows[0]["Response_Dates"].ToString();
            lblInspectionDt.InnerText = ds.Tables[0].Rows[0]["Inspection_Date"].ToString();
            lblBank.InnerText = ds.Tables[0].Rows[0]["Bank_Name"].ToString();
            lblDPRLand.InnerText = ds.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString();
            lblDPRBuilding.InnerText = ds.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString();
            lblDPRPM.InnerText = ds.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString();
            lblUnitInvLand.InnerText = ds.Tables[0].Rows[0]["ActualLandvalue"].ToString();
            lblUnitInvBuilding.InnerText = ds.Tables[0].Rows[0]["ActualBuildingValue"].ToString();
            lblUnitInvPM.InnerText = ds.Tables[0].Rows[0]["ActualPMValue"].ToString();

            decimal DPRTotal = 0;
            decimal DPRLand = Convert.ToDecimal(ds.Tables[0].Rows[0]["ExistEnterpriseLand"].ToString());
            decimal DPRBuilding = Convert.ToDecimal(ds.Tables[0].Rows[0]["ExistEnterpriseBuilding"].ToString());
            decimal DPRPM = Convert.ToDecimal(ds.Tables[0].Rows[0]["ExistEnterprisePlantMachinery"].ToString());
            DPRTotal = DPRLand + DPRBuilding + DPRPM;
            lblDPRTotal.InnerText = DPRTotal.ToString();
            decimal INVTotal = 0;
            decimal INVLand = Convert.ToDecimal(ds.Tables[0].Rows[0]["ActualLandvalue"].ToString());
            decimal INVBuilding = Convert.ToDecimal(ds.Tables[0].Rows[0]["ActualBuildingValue"].ToString());
            decimal INVPM = Convert.ToDecimal(ds.Tables[0].Rows[0]["ActualPMValue"].ToString());
            INVTotal = INVLand + INVBuilding + INVPM;
            lblUnitInvTotal.InnerText = INVTotal.ToString();

            if (ddlIncentive.SelectedValue == "1")
            {
                divCapital.Visible = true;
            }
            if (ddlIncentive.SelectedValue == "3")
            {
                divMainInterest.Visible = true;
            }
        }
        public DataSet GetIncentives(string ApplicationNo)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@AppNo",SqlDbType.VarChar)
           };
            pp[0].Value = ApplicationNo;
            Dsnew = caf.GenericFillDs("USP_GET_INCENTIVES_BY_APPLICATION", pp);
            return Dsnew;
        }
        public DataSet GetapplicationDtls(string USERID, string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@CREATEDBY",SqlDbType.VarChar),
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = USERID;
            pp[1].Value = INCENTIVEID;
            Dsnew = caf.GenericFillDs("USP_GET_INCENTIVES_CAF_DATA_APPRAISAL", pp);
            return Dsnew;
        }

        protected void txtDLOInvTotal_TextChanged(object sender, EventArgs e)
        {
            decimal DLOTotal = 0; decimal DLOLand = 0; decimal DLOBuilding = 0; decimal DLOPM = 0;
            if (txtDLOInvLand.Text.Trim() != "") { DLOLand = Convert.ToDecimal(txtDLOInvLand.Text.Trim().ToString()); }
            if (txtDLOInvBuilding.Text.Trim() != "") { DLOBuilding = Convert.ToDecimal(txtDLOInvBuilding.Text.Trim().ToString()); }
            if (txtDLOInvPM.Text.Trim() != "") { DLOPM = Convert.ToDecimal(txtDLOInvPM.Text.Trim().ToString()); }
            DLOTotal = DLOLand + DLOBuilding + DLOPM;
            lblDLOInvTotal.InnerText = DLOTotal.ToString();

            decimal CompTotal = 0; decimal CompLand = 0; decimal CompBuilding = 0; decimal CompPM = 0;
            if (txtCompInvLand.Text.Trim() != "") { CompLand = Convert.ToDecimal(txtCompInvLand.Text.Trim().ToString()); }
            if (txtCompInvBuilding.Text.Trim() != "") { CompBuilding = Convert.ToDecimal(txtCompInvBuilding.Text.Trim().ToString()); }
            if (txtCompInvPM.Text.Trim() != "") { CompPM = Convert.ToDecimal(txtCompInvPM.Text.Trim().ToString()); }
            CompTotal = CompLand + CompBuilding + CompPM;
            lblCompInvTotal.InnerText = CompTotal.ToString();
        }

        protected void btnCreateAppraisal_Click(object sender, EventArgs e)
        {
            HeaderFileNo.InnerText = txtFileNo.Text.Trim().ToString();
            divInputFileNo.Visible = false;
            divBindFileNo.Visible = true;

            lblDPRLandPrint.InnerText = lblDPRLand.InnerText;
            lblDPRBuildingPrint.InnerText = lblDPRBuilding.InnerText;
            lblDPRPMPrint.InnerText = lblDPRPM.InnerText;
            lblDPRTotalPrint.InnerText = lblDPRTotal.InnerText;

            lblUnitInvLandPrint.InnerText = lblUnitInvLand.InnerText;
            lblUnitInvBuildingPrint.InnerText = lblUnitInvBuilding.InnerText;
            lblUnitInvPMPrint.InnerText = lblUnitInvPM.InnerText;
            lblUnitInvTotalPrint.InnerText = lblUnitInvTotal.InnerText;

            lblDLOInvLandPrint.InnerText = txtDLOInvLand.Text;
            lblDLOInvBuildingPrint.InnerText = txtDLOInvBuilding.Text;
            lblDLOInvPMPrint.InnerText = txtDLOInvPM.Text;
            lblDLOInvTotalPrint.InnerText = lblDLOInvTotal.InnerText;

            lblDLOInvLandPrint.InnerText = txtDLOInvLand.Text;
            lblDLOInvBuildingPrint.InnerText = txtDLOInvBuilding.Text;
            lblDLOInvPMPrint.InnerText = txtDLOInvPM.Text;
            lblDLOInvTotalPrint.InnerText = lblDLOInvTotal.InnerText;

            lblCompInvLandPrint.InnerText = txtCompInvLand.Text;
            lblCompInvBuildingPrint.InnerText = txtCompInvBuilding.Text;
            lblCompInvPMPrint.InnerText = txtCompInvPM.Text;
            lblCompInvTotalPrint.InnerText = lblCompInvTotal.InnerText;

            lblRemarksLandPrint.InnerText = txtRemarksLand.Text;
            lblRemarksBuildingPrint.InnerText = txtRemarksBuilding.Text;
            lblRemarksPMPrint.InnerText = txtRemarksPM.Text;
            //BtnPrint.Visible = true;
            btnCreateAppraisal.Visible = false;

            if (ddlIncentive.SelectedValue == "1")
            {
                divCapital.Visible = true;
                lbl25Prints.InnerText = txt25.Text;
                lbl26Prints.InnerText = txt26.Text;
                lblEFCIPrint.InnerText = txtEFCI.Text;
                lbl25FCIprint.InnerText = txt25FCI.Text;
                lblAddlWE5Print.InnerText = txtAddlWE5.Text;
                lblTECSPrint.InnerText = txtTECS.Text;
                lbl27Print.InnerText = txt27.Text;
                lbl28Print.InnerText = txt28.Text;
                tblInputInvestment.Visible = false;
                tblBindInvestment.Visible = true;
                divtblInputOthers.Visible = false;
                divtblBindOthers.Visible = true;
            }
            if (ddlIncentive.SelectedValue == "3")
            {
                lblIntExtraPrint.InnerText = txtIntExtra.Text.ToString();
                divMainInterest.Visible = true;
                divInputInterest.Visible = false;
                divInputInterestGrid.Visible = true;

                divInterestSanctionInput.Visible = false;
                divInterestSanctionInputGrid.Visible = true;
            }
            if (ddlIncentive.SelectedValue == "4")
            {
                divMainPower.Visible = true;
            }
        }

       
        protected void btnAddInterest_Click(object sender, EventArgs e)
        {
            DataTable dt = ViewState["LoanDtls"] as DataTable;
            /*DataTable dt = new DataTable("TermLoan");
            dt.Columns.Add("Year");
            dt.Columns.Add("Bank");
            dt.Columns.Add("LoanACNo");
            dt.Columns.Add("SanctionOrderNo");
            dt.Columns.Add("AmountSanctioned");
            dt.Columns.Add("RateofInterest");
            dt.Columns.Add("Disbursed");
            dt.Columns.Add("OutstandingBalance");
            dt.Columns.Add("Paidaspercertificate");*/
            string Year = txtYear.Text.Trim().ToString();
            string Bank = txtBank.Text.Trim().ToString();
            string LoanACNo = txtLoanAcNo.Text.Trim().ToString();
            string SanctionOrderNo = txtSanctionOrder.Text.Trim().ToString();
            string AmountSanctioned = txtAmountSanctioned.Text.Trim().ToString();
            string RateofInterest = txtRateofInterest.Text.Trim().ToString();
            string Disbursed = txtTermLoanDisbursed.Text.Trim().ToString();
            string OutstandingBalance = txtTermLoanOutstandingBalance.Text.Trim().ToString();
            string Paidaspercertificate = txtTermLoanPaidCertificate.Text.Trim().ToString();

            dt.Rows.Add(Year, Bank, LoanACNo, SanctionOrderNo, AmountSanctioned, RateofInterest, Disbursed, OutstandingBalance, Paidaspercertificate);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            GVTermLoandtls.DataSource = null;
            GVTermLoandtls.DataSource = ds.Tables[0];
            GVTermLoandtls.DataBind();
        }

        protected void btnAddSanctionIntrest_Click(object sender, EventArgs e)
        {
            DataTable dt = ViewState["INTSanctionDtls"] as DataTable;
            string Year = txtYearSancioned.Text.Trim().ToString();
            string HalYear = txtHalf.Text.Trim().ToString();
            string Amount = txtAmount.Text.Trim().ToString();
            dt.Rows.Add(Year, HalYear, Amount);
            DataSet dsI = new DataSet();
            dsI.Tables.Add(dt);
            gvIntSanction.DataSource = null;
            gvIntSanction.DataSource = dsI.Tables[0];
            gvIntSanction.DataBind();
        }
    }
}