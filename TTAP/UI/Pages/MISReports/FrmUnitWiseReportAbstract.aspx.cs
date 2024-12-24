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
    public partial class FrmUnitWiseReportAbstract : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();

        int NoOfUnits;
        int NoOfRejectedUnits;
        int NoOfUnitsSanctioned;
        int NoOfUnitsatApplicant;
        int NoOfUnitsatDLO;
        int NoOfUnitsatHO;
        int NoOfUnitsatPayment;
        
        int NoOfRejectedUnitsInc;
        int NoOfUnitsSanctionedInc;
        int NoOfUnitsatApplicantInc;
        int NoOfUnitsatDLOInc;
        int NoOfUnitsatHOInc;
        int NoOfUnitsatPaymentInc;

        int NoOfUnitsInc;
        int TotalNoOfIncentives;
        int NoOfIncentivesatPayment;
        int NoOfIncentivesatDLO;
        int NoOfIncentivesatApplicant;
        int NoOfIncentivesatHO;
        int NoOfIncentivesRejected;
        int NooFIncentivesSanctioned;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {
                        lbtnback.PostBackUrl = "~/UI/Pages/MISReports/frmIncentiveReports.aspx";
                        rdbOrderby_SelectedIndexChanged(sender, e);
                        /*dss = GetIncentiveAbstract(Session["uid"].ToString());
                        if (dss.Tables.Count > 0)
                        {
                            if (dss.Tables[0].Rows.Count > 0)
                            {
                                gvdetailsnew.DataSource = dss;
                                gvdetailsnew.DataBind();
                            }
                        }*/
                    }
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
        public DataSet GetIncentiveAbstract(string UserID)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar)
           };
            pp[0].Value = UserID;

            Dsnew = caf.GenericFillDs("USP_GET_UNIT_ABSTRACT", pp);

            return Dsnew;
        }

        protected void gvdetailsnew_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int NoOfUnits1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfUnits"));
                NoOfUnits = NoOfUnits1 + NoOfUnits;

                int NoOfRejectedUnits1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfRejectedUnits"));
                NoOfRejectedUnits = NoOfRejectedUnits1 + NoOfRejectedUnits;

                int NoOfUnitsSanctioned1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfUnitsSanctioned"));
                NoOfUnitsSanctioned = NoOfUnitsSanctioned1 + NoOfUnitsSanctioned;

                int NoOfUnitsatApplicant1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfUnitsatApplicant"));
                NoOfUnitsatApplicant = NoOfUnitsatApplicant1 + NoOfUnitsatApplicant;

                int NoOfUnitsatDLO1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfUnitsatDLO"));
                NoOfUnitsatDLO = NoOfUnitsatDLO1 + NoOfUnitsatDLO;

                int NoOfUnitsatHO1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfUnitsatHO"));
                NoOfUnitsatHO = NoOfUnitsatHO1 + NoOfUnitsatHO;

                int NoOfUnitsatPayment1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfUnitsPendingatPayment"));
                NoOfUnitsatPayment = NoOfUnitsatPayment1 + NoOfUnitsatPayment;

                Label lblDistrictId = (e.Row.FindControl("lblDistrictId") as Label);

                HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
                if (h1.Text != "0")
                {
                    h1.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=1&Flag=Z&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h2 = (HyperLink)e.Row.Cells[4].Controls[0];
                if (h2.Text != "0")
                {
                    h2.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=1&Flag=R&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h3 = (HyperLink)e.Row.Cells[5].Controls[0];
                if (h3.Text != "0")
                {
                    h3.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=1&Flag=A&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h4 = (HyperLink)e.Row.Cells[6].Controls[0];
                if (h4.Text != "0")
                {
                    h4.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=1&Flag=D&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h5 = (HyperLink)e.Row.Cells[8].Controls[0];
                if (h5.Text != "0")
                {
                    h5.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=1&Flag=P&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];
                if (h6.Text != "0")
                {
                    h6.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=1&Flag=H&DistrictId=" + lblDistrictId.Text.Trim();
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[2].Text = NoOfUnits.ToString();
                e.Row.Cells[3].Text = NoOfUnitsSanctioned.ToString();
                e.Row.Cells[4].Text = NoOfRejectedUnits.ToString();
                e.Row.Cells[5].Text = NoOfUnitsatApplicant.ToString();
                e.Row.Cells[6].Text = NoOfUnitsatDLO.ToString();
                e.Row.Cells[7].Text = NoOfUnitsatHO.ToString();
                e.Row.Cells[8].Text = NoOfUnitsatPayment.ToString();

                HyperLink h1 = new HyperLink();
                h1.Text = NoOfUnits.ToString();
                if (h1.Text != "0")
                {
                    h1.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=2&Flag=Z&DistrictId=%";
                    e.Row.Cells[2].Controls.Add(h1);
                }
                HyperLink h2 = new HyperLink();
                h2.Text = NoOfRejectedUnits.ToString();
                if (h2.Text != "0")
                {
                    h2.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=2&Flag=R&DistrictId=%";
                    e.Row.Cells[4].Controls.Add(h2);
                }
                HyperLink h3 = new HyperLink();
                h3.Text = NoOfUnitsatApplicant.ToString();
                if (h3.Text != "0")
                {
                    h3.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=2&Flag=A&DistrictId=%";
                    e.Row.Cells[5].Controls.Add(h3);
                }
                HyperLink h4 = new HyperLink();
                h4.Text = NoOfUnitsatDLO.ToString();
                if (h4.Text != "0")
                {
                    h4.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=2&Flag=D&DistrictId=%";
                    e.Row.Cells[6].Controls.Add(h4);
                }
                HyperLink h5 = new HyperLink();
                h5.Text = NoOfUnitsatPayment.ToString();
                if (h5.Text != "0")
                {
                    h5.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=2&Flag=P&DistrictId=%";
                    e.Row.Cells[8].Controls.Add(h5);
                }
                HyperLink h6 = new HyperLink();
                h6.Text = NoOfUnitsatHO.ToString();
                if (h6.Text != "0")
                {
                    h6.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=2&Flag=H&DistrictId=%";
                    e.Row.Cells[7].Controls.Add(h6);
                }
            }
        }

        protected void rdbOrderby_SelectedIndexChanged(object sender, EventArgs e)
        {
            dss = GetIncentiveAbstract(Session["uid"].ToString());
            if (dss.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
                {
                    gvdetailsnew.DataSource = dss;
                    gvdetailsnew.DataBind();
                    gvdetailsInc.DataSource = dss;
                    gvdetailsInc.DataBind();
                }
            }
            if (rdbOrderby.SelectedValue == "U")
            {
                DivUnit.Visible = true;
                DivIncentive.Visible = false;
            }
            else {
                DivUnit.Visible = false;
                DivIncentive.Visible = true;
            }
        }

        protected void gvdetailsInc_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int NoOfUnits1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfUnits"));
                NoOfUnitsInc = NoOfUnits1 + NoOfUnitsInc;

                int TotalNoOfIncentives1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalNoOfIncentives"));
                TotalNoOfIncentives = TotalNoOfIncentives1 + TotalNoOfIncentives;

                int NoOfIncentivesatPayment1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfIncentivesatPayment"));
                NoOfIncentivesatPayment = NoOfIncentivesatPayment1 + NoOfIncentivesatPayment;

                int NoOfUnitsatPaymentInc1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfUnitsPendingatPayment"));
                NoOfUnitsatPaymentInc = NoOfUnitsatPaymentInc1 + NoOfUnitsatPaymentInc;

                int NoOfIncentivesatDLO1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfIncentivesatDLO"));
                NoOfIncentivesatDLO = NoOfIncentivesatDLO1 + NoOfIncentivesatDLO;

                int NoOfUnitsatDLOInc1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfUnitsatDLO"));
                NoOfUnitsatDLOInc = NoOfUnitsatDLOInc1 + NoOfUnitsatDLOInc;

                int NoOfIncentivesatApplicant1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfIncentivesatApplicant"));
                NoOfIncentivesatApplicant = NoOfIncentivesatApplicant1 + NoOfIncentivesatApplicant;

                int NoOfUnitsatApplicantInc1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfUnitsatApplicant"));
                NoOfUnitsatApplicantInc = NoOfUnitsatApplicantInc1 + NoOfUnitsatApplicantInc;

                int NoOfIncentivesatHO1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfIncentivesatHO"));
                NoOfIncentivesatHO = NoOfIncentivesatHO1 + NoOfIncentivesatHO;

                int NoOfUnitsatHOInc1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfUnitsatHO"));
                NoOfUnitsatHOInc = NoOfUnitsatHOInc1 + NoOfUnitsatHOInc;

                int NoOfIncentivesRejected1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfIncentivesRejected"));
                NoOfIncentivesRejected = NoOfIncentivesRejected1 + NoOfIncentivesRejected;

                int NoOfRejectedUnitsInc1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfRejectedUnits"));
                NoOfRejectedUnitsInc = NoOfRejectedUnitsInc1 + NoOfRejectedUnitsInc;

                int NooFIncentivesSanctioned1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalNoOfIncentivesSanctioned"));
                NooFIncentivesSanctioned = NooFIncentivesSanctioned1 + NooFIncentivesSanctioned;

                int NoOfUnitsSanctionedInc1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfUnitsSanctioned"));
                NoOfUnitsSanctionedInc = NoOfUnitsSanctionedInc1 + NoOfUnitsSanctionedInc;

                Label lblDistrictId = (e.Row.FindControl("lblDistrictId") as Label);

                HyperLink h1 = (HyperLink)e.Row.Cells[3].Controls[0];
                if (h1.Text != "0")
                {
                    h1.Style.Add("color", "black");
                    h1.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=1&Flag=Z&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h2 = (HyperLink)e.Row.Cells[2].Controls[0];
                if (h2.Text != "0")
                {
                    h2.Style.Add("color", "black");
                    h2.NavigateUrl = "FormIncentivesReportView.aspx?Level=1&Flag=T&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
                if (h3.Text != "0")
                {
                    h3.Style.Add("color", "black");
                    h3.NavigateUrl = "FormIncentivesReportView.aspx?Level=1&Flag=P&DistrictId=" + lblDistrictId.Text.Trim();
                }
               
                HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
                if (h4.Text != "0")
                {
                    h4.Style.Add("color", "black");
                    h4.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=1&Flag=P&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];
                if (h5.Text != "0")
                {
                    h5.Style.Add("color", "black");
                    h5.NavigateUrl = "FormIncentivesReportView.aspx?Level=1&Flag=D&DistrictId=" + lblDistrictId.Text.Trim();
                }
               
                HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];
                if (h6.Text != "0")
                {
                    h6.Style.Add("color", "black");
                    h6.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=1&Flag=D&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h7 = (HyperLink)e.Row.Cells[8].Controls[0];
                if (h7.Text != "0")
                {
                    h7.Style.Add("color", "black");
                    h7.NavigateUrl = "FormIncentivesReportView.aspx?Level=1&Flag=A&DistrictId=" + lblDistrictId.Text.Trim();
                }
                
                HyperLink h8 = (HyperLink)e.Row.Cells[9].Controls[0];
                if (h8.Text != "0")
                {
                    h8.Style.Add("color", "black");
                    h8.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=1&Flag=A&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h9 = (HyperLink)e.Row.Cells[10].Controls[0];
                if (h9.Text != "0")
                {
                    h9.Style.Add("color", "black");
                    h9.NavigateUrl = "FormIncentivesReportView.aspx?Level=1&Flag=H&DistrictId=" + lblDistrictId.Text.Trim();
                }
               
                HyperLink h10 = (HyperLink)e.Row.Cells[11].Controls[0];
                if (h10.Text != "0")
                {
                    h10.Style.Add("color", "black");
                    h10.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=1&Flag=H&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h11 = (HyperLink)e.Row.Cells[12].Controls[0];
                if (h11.Text != "0")
                {
                    h11.Style.Add("color", "black");
                    h11.NavigateUrl = "FormIncentivesReportView.aspx?Level=1&Flag=R&DistrictId=" + lblDistrictId.Text.Trim();
                }
               
                HyperLink h12 = (HyperLink)e.Row.Cells[13].Controls[0];
                if (h12.Text != "0")
                {
                    h12.Style.Add("color", "black");
                    h12.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=1&Flag=R&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h13 = (HyperLink)e.Row.Cells[14].Controls[0];
                if (h13.Text != "0")
                {
                    h13.Style.Add("color", "black");
                    h13.NavigateUrl = "FormIncentivesReportView.aspx?Level=1&Flag=S&DistrictId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h14 = (HyperLink)e.Row.Cells[15].Controls[0];
                if (h14.Text != "0")
                {
                    h14.Style.Add("color", "black");
                    h14.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=1&Flag=S&DistrictId=" + lblDistrictId.Text.Trim();
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[3].Text = NoOfUnitsInc.ToString();
                e.Row.Cells[2].Text = TotalNoOfIncentives.ToString();
                e.Row.Cells[4].Text = NoOfIncentivesatPayment.ToString();
                e.Row.Cells[5].Text = NoOfUnitsatPaymentInc.ToString();
                e.Row.Cells[6].Text = NoOfIncentivesatDLO.ToString();
                e.Row.Cells[7].Text = NoOfUnitsatDLOInc.ToString();
                e.Row.Cells[8].Text = NoOfIncentivesatApplicant.ToString();
                e.Row.Cells[9].Text = NoOfUnitsatApplicantInc.ToString();
                e.Row.Cells[10].Text = NoOfIncentivesatHO.ToString();
                e.Row.Cells[11].Text = NoOfUnitsatHOInc.ToString();
                e.Row.Cells[12].Text = NoOfIncentivesRejected.ToString();
                e.Row.Cells[13].Text = NoOfRejectedUnitsInc.ToString();
                e.Row.Cells[14].Text = NooFIncentivesSanctioned.ToString();
                e.Row.Cells[15].Text = NoOfUnitsSanctionedInc.ToString();

                
                e.Row.Cells[2].Style.Add("background-color", "aquamarine");
                e.Row.Cells[4].Style.Add("background-color", "aquamarine");
                e.Row.Cells[6].Style.Add("background-color", "aquamarine");
                e.Row.Cells[8].Style.Add("background-color", "aquamarine");
                e.Row.Cells[10].Style.Add("background-color", "aquamarine");
                e.Row.Cells[12].Style.Add("background-color", "aquamarine");
                e.Row.Cells[14].Style.Add("background-color", "aquamarine");

                HyperLink h1 = new HyperLink();
                h1.Text = NoOfUnitsInc.ToString();
                if (h1.Text != "0")
                {
                    h1.Style.Add("color", "black");
                    h1.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=2&Flag=Z&DistrictId=0";
                    e.Row.Cells[3].Controls.Add(h1);
                }
                HyperLink h2 = new HyperLink();
                h2.Text = TotalNoOfIncentives.ToString();
                if (h2.Text != "0")
                {
                    h2.Style.Add("color", "black");
                    h2.NavigateUrl = "FormIncentivesReportView.aspx?Level=2&Flag=T&DistrictId=0";
                    e.Row.Cells[2].Controls.Add(h2);
                }
                HyperLink h3 = new HyperLink();
                h3.Text = NoOfIncentivesatPayment.ToString();
                if (h3.Text != "0")
                {
                    h3.Style.Add("color", "black");
                    h3.NavigateUrl = "FormIncentivesReportView.aspx?Level=2&Flag=P&DistrictId=0";
                    e.Row.Cells[4].Controls.Add(h3);
                }
                
                HyperLink h4 = new HyperLink();
                h4.Text = NoOfUnitsatPaymentInc.ToString();
                if (h4.Text != "0")
                {
                    h4.Style.Add("color", "black");
                    h4.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=2&Flag=P&DistrictId=%";
                    e.Row.Cells[5].Controls.Add(h4);
                }
                HyperLink h5 = new HyperLink();
                h5.Text = NoOfIncentivesatDLO.ToString();
                if (h5.Text != "0")
                {
                    h5.Style.Add("color", "black");
                    h5.NavigateUrl = "FormIncentivesReportView.aspx?Level=2&Flag=D&DistrictId=0";
                    e.Row.Cells[6].Controls.Add(h5);
                }
               
                HyperLink h6 = new HyperLink();
                h6.Text = NoOfUnitsatDLOInc.ToString();
                if (h6.Text != "0")
                {
                    h6.Style.Add("color", "black");
                    h6.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=2&Flag=D&DistrictId=%";
                    e.Row.Cells[7].Controls.Add(h6);
                }
                HyperLink h7 = new HyperLink();
                h7.Text = NoOfIncentivesatApplicant.ToString();
                if (h7.Text != "0")
                {
                    h7.Style.Add("color", "black");
                    h7.NavigateUrl = "FormIncentivesReportView.aspx?Level=2&Flag=A&DistrictId=0";
                    e.Row.Cells[8].Controls.Add(h7);
                }
               
                HyperLink h8 = new HyperLink();
                h8.Text = NoOfUnitsatApplicantInc.ToString();
                if (h8.Text != "0")
                {
                    h8.Style.Add("color", "black");
                    h8.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=2&Flag=A&DistrictId=%";
                    e.Row.Cells[9].Controls.Add(h8);
                }
                HyperLink h9 = new HyperLink();
                h9.Text = NoOfIncentivesatHO.ToString();
                if (h9.Text != "0")
                {
                    h9.Style.Add("color", "black");
                    h9.NavigateUrl = "FormIncentivesReportView.aspx?Level=2&Flag=H&DistrictId=0";
                    e.Row.Cells[10].Controls.Add(h9);
                }
               
                HyperLink h10 = new HyperLink();
                h10.Text = NoOfUnitsatHOInc.ToString();
                if (h10.Text != "0")
                {
                    h10.Style.Add("color", "black");
                    h10.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=2&Flag=H&DistrictId=%";
                    e.Row.Cells[11].Controls.Add(h10);
                }
                HyperLink h11 = new HyperLink();
                h11.Text = NoOfIncentivesRejected.ToString();
                if (h11.Text != "0")
                {
                    h11.Style.Add("color", "black");
                    h11.NavigateUrl = "FormIncentivesReportView.aspx?Level=2&Flag=R&DistrictId=0";
                    e.Row.Cells[12].Controls.Add(h11);
                }
                HyperLink h12 = new HyperLink();
                h12.Text = NoOfRejectedUnitsInc.ToString();
                if (h12.Text != "0")
                {
                    h12.Style.Add("color", "black");
                    h12.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=2&Flag=R&DistrictId=%";
                    e.Row.Cells[13].Controls.Add(h12);
                }
                HyperLink h13 = new HyperLink();
                h13.Text = NooFIncentivesSanctioned.ToString();
                if (h13.Text != "0")
                {
                    h13.Style.Add("color", "black");
                    h13.NavigateUrl = "FormIncentivesReportView.aspx?Level=2&Flag=S&DistrictId=0";
                    e.Row.Cells[14].Controls.Add(h13);
                }
                HyperLink h14 = new HyperLink();
                h14.Text = NoOfUnitsSanctionedInc.ToString();
                if (h14.Text != "0")
                {
                    h14.Style.Add("color", "black");
                    h14.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=2&Flag=S&DistrictId=%";
                    e.Row.Cells[15].Controls.Add(h14);
                }
            }
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
                Response.AddHeader("content-disposition", "attachment;filename=R4-IncentiveAbstract.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                //divPMprint.Style["width"] = "680px";

                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    gvdetailsInc.AllowPaging = false;
                    //this.fillgrid();

                    gvdetailsInc.HeaderRow.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in gvdetailsInc.HeaderRow.Cells)
                    {
                        cell.BackColor = gvdetailsInc.HeaderStyle.BackColor;
                        cell.ForeColor = System.Drawing.Color.Black;
                    }
                    foreach (TableCell cell in gvdetailsInc.FooterRow.Cells)
                    {
                        cell.BackColor = System.Drawing.Color.White;
                        cell.ForeColor = System.Drawing.Color.Black;
                        // cell.
                    }

                    foreach (GridViewRow row in gvdetailsInc.Rows)
                    {
                        row.BackColor = System.Drawing.Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = gvdetailsInc.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = gvdetailsInc.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }

                    gvdetailsInc.RenderControl(hw);

                    string label1text = "R5. District Wise Incentive Abstract";
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