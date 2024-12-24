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
using System.Collections;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace TTAP.UI.Pages.MISReports
{
    public partial class AdoDistrictWiseAbstract : System.Web.UI.Page
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
        int NooFIncentivesReleased;
        int PendingRevisedInspectionIncentives;
        int PendingAtDLSVCDLC;
        int PendingatDLODLC;
        int PendingatDLOSLC;

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
                        hdnDistId.Value = ObjLoginNewvo.DistrictID.ToString();
                        string Role = ObjLoginNewvo.Role_Code.ToString();
                        lbtnback.PostBackUrl = "~/UI/Pages/MISReports/frmIncentiveReports.aspx";
                        DateTime dateTime = DateTime.UtcNow.Date;
                        header.InnerHtml = "R11. AD Wise Incentive Abstract as on " + dateTime.ToString("dd/MM/yyyy");
                        rdbOrderby_SelectedIndexChanged(sender, e);
                        if (Role == "DLO")
                        {
                            gvdetailsInc.FooterRow.Visible = false;
                        }
                        if (ObjLoginNewvo.user_id == "RDD-Hyderabad" || ObjLoginNewvo.user_id == "RDD-Warangal")
                        {
                            gvdetailsInc.FooterRow.Enabled = false;
                        }
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
        public DataSet GetIncentiveAbstract(string UserID,string Flag)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
               new SqlParameter("@FLAG",SqlDbType.VarChar)
           };
            pp[0].Value = UserID;
            pp[1].Value = Flag;
            Dsnew = caf.GenericFillDs("USP_GET_UNIT_ABSTRACT_ADO", pp);

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
            string Flag = "N";
            if (ckhActive.Checked == true) {
                Flag = "A";
            }
            dss = GetIncentiveAbstract(Session["uid"].ToString(), Flag);
            if (dss.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
                {
                    gvdetailsnew.DataSource = dss;
                    gvdetailsnew.DataBind();
                    gvdetailsInc.DataSource = dss;
                    gvdetailsInc.DataBind();
                    //GetSnos();
                }
            }
            if (rdbOrderby.SelectedValue == "U")
            {
                DivUnit.Visible = true;
                DivIncentive.Visible = false;
            }
            else
            {
                DivUnit.Visible = false;
                DivIncentive.Visible = true;
            }
            foreach (GridViewRow row in gvdetailsInc.Rows)
            {
                row.Cells[0].Attributes.Add("vertical-align", "middle");
            }
        }

        protected void gvdetailsInc_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "NoOfUnits").ToString() != "")
                {
                    int NoOfUnits1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfUnits"));
                    NoOfUnitsInc = NoOfUnits1 + NoOfUnitsInc;

                    int TotalNoOfIncentives1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalNoOfIncentives"));
                    TotalNoOfIncentives = TotalNoOfIncentives1 + TotalNoOfIncentives;

                    int NoOfIncentivesatPayment1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfIncentivesatPayment"));
                    NoOfIncentivesatPayment = NoOfIncentivesatPayment1 + NoOfIncentivesatPayment;

                    int NoOfIncentivesatDLO1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfIncentivesatDLO"));
                    NoOfIncentivesatDLO = NoOfIncentivesatDLO1 + NoOfIncentivesatDLO;

                    int NoOfIncentivesatApplicant1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfIncentivesatApplicant"));
                    NoOfIncentivesatApplicant = NoOfIncentivesatApplicant1 + NoOfIncentivesatApplicant;

                    int NoOfIncentivesatHO1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfIncentivesatHO"));
                    NoOfIncentivesatHO = NoOfIncentivesatHO1 + NoOfIncentivesatHO;

                    int NoOfIncentivesRejected1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfIncentivesRejected"));
                    NoOfIncentivesRejected = NoOfIncentivesRejected1 + NoOfIncentivesRejected;

                    int NooFIncentivesSanctioned1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalNoOfIncentivesSanctioned"));
                    NooFIncentivesSanctioned = NooFIncentivesSanctioned1 + NooFIncentivesSanctioned;

                    int NooFIncentivesReleased1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalNoOfIncentivesReleased"));
                    NooFIncentivesReleased = NooFIncentivesReleased1 + NooFIncentivesReleased;

                    int PendingRevisedInspectionIncentives1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PendingRevisedInspectionIncentives"));
                    PendingRevisedInspectionIncentives = PendingRevisedInspectionIncentives1 + PendingRevisedInspectionIncentives;

                    int PendingAtDLSVCDLC1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PendingAtDLSVCDLC"));
                    PendingAtDLSVCDLC = PendingAtDLSVCDLC1 + PendingAtDLSVCDLC;

                    int PendingatDLODLC1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PendingatDLODLC"));
                    PendingatDLODLC = PendingatDLODLC1 + PendingatDLODLC;

                    int PendingatDLOSLC1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PendingatDLOSLC"));
                    PendingatDLOSLC = PendingatDLOSLC1 + PendingatDLOSLC;

                    Label lblDistrictId = (e.Row.FindControl("lblDistrictId") as Label);

                    HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
                    
                    if (h1.Text != "0")
                    {
                        h1.Style.Add("color", "black");
                        h1.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=1&Flag=Z&DistrictId=" + lblDistrictId.Text.Trim();
                    }
                    HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
                    
                    if (h2.Text != "0")
                    {
                        h2.Style.Add("color", "black");
                        h2.NavigateUrl = "FormIncentivesReportView.aspx?Level=1&Flag=T&DistrictId=" + lblDistrictId.Text.Trim();
                    }

                    HyperLink h8 = (HyperLink)e.Row.Cells[4].Controls[0];

                    if (h8.Text != "0")
                    {
                        h8.Style.Add("color", "black");
                        h8.NavigateUrl = "FormIncentivesReportView.aspx?Level=1&Flag=S&DistrictId=" + lblDistrictId.Text.Trim();
                    }

                    HyperLink h11 = (HyperLink)e.Row.Cells[5].Controls[0];

                    if (h11.Text != "0")
                    {
                        h11.Style.Add("color", "black");
                        h11.NavigateUrl = "FormIncentivesReportView.aspx?Level=1&Flag=DLCP&DistrictId=" + lblDistrictId.Text.Trim();
                    }

                    HyperLink h12 = (HyperLink)e.Row.Cells[6].Controls[0];

                    if (h12.Text != "0")
                    {
                        h12.Style.Add("color", "black");
                        h12.NavigateUrl = "FormIncentivesReportView.aspx?Level=1&Flag=SLC&DistrictId=" + lblDistrictId.Text.Trim();
                    }

                    /*HyperLink h3 = (HyperLink)e.Row.Cells[5].Controls[0];
                    
                    if (h3.Text != "0")
                    {
                        h3.Style.Add("color", "black");
                        h3.NavigateUrl = "FormIncentivesReportView.aspx?Level=1&Flag=P&DistrictId=" + lblDistrictId.Text.Trim();
                    }*/

                    HyperLink h4 = (HyperLink)e.Row.Cells[7].Controls[0];
                    
                    if (h4.Text != "0")
                    {
                        h4.Style.Add("color", "black");
                        h4.NavigateUrl = "FormIncentivesReportView.aspx?Level=1&Flag=D&DistrictId=" + lblDistrictId.Text.Trim();
                    }
                    HyperLink h10 = (HyperLink)e.Row.Cells[8].Controls[0];

                    if (h10.Text != "0")
                    {
                        h10.Style.Add("color", "black");
                        h10.NavigateUrl = "FormIncentivesReportView.aspx?Level=1&Flag=DLC&DistrictId=" + lblDistrictId.Text.Trim();
                    }
                    HyperLink h6a = (HyperLink)e.Row.Cells[9].Controls[0];

                    if (h6a.Text != "0")
                    {
                        h6a.Style.Add("color", "black");
                        h6a.NavigateUrl = "FormIncentivesReportView.aspx?Level=1&Flag=H&DistrictId=" + lblDistrictId.Text.Trim();
                    }
                    HyperLink h5 = (HyperLink)e.Row.Cells[10].Controls[0];
                    
                    if (h5.Text != "0")
                    {
                        h5.Style.Add("color", "black");
                        h5.NavigateUrl = "FormIncentivesReportView.aspx?Level=1&Flag=A&DistrictId=" + lblDistrictId.Text.Trim();
                    }
                    
                    HyperLink h6 = (HyperLink)e.Row.Cells[11].Controls[0];
                    
                    if (h6.Text != "0")
                    {
                        h6.Style.Add("color", "black");
                        h6.NavigateUrl = "FormIncentivesReportView.aspx?Level=1&Flag=IN&DistrictId=" + lblDistrictId.Text.Trim();
                    }
                    HyperLink h7 = (HyperLink)e.Row.Cells[12].Controls[0];
                    
                    if (h7.Text != "0")
                    {
                        h7.Style.Add("color", "black");
                        h7.NavigateUrl = "FormIncentivesReportView.aspx?Level=1&Flag=R&DistrictId=" + lblDistrictId.Text.Trim();
                    }
                   
                    HyperLink h9 = (HyperLink)e.Row.Cells[13].Controls[0];
                    
                    if (h9.Text != "0")
                    {
                        h9.Style.Add("color", "black");
                        h9.NavigateUrl = "FormIncentivesReportView.aspx?Level=1&Flag=RL&DistrictId=" + lblDistrictId.Text.Trim();
                    }
                }
                
                e.Row.Cells[2].Style.Add("color", "black");
                e.Row.Cells[3].Style.Add("color", "black");
                e.Row.Cells[4].Style.Add("color", "black");
                e.Row.Cells[5].Style.Add("color", "black");
                e.Row.Cells[6].Style.Add("color", "black");
                e.Row.Cells[7].Style.Add("color", "black");
                e.Row.Cells[8].Style.Add("color", "black");
                e.Row.Cells[9].Style.Add("color", "black");
                e.Row.Cells[10].Style.Add("color", "black");
                e.Row.Cells[11].Style.Add("color", "black");
                e.Row.Cells[12].Style.Add("color", "black");
                e.Row.Cells[13].Style.Add("color", "black");
                if (e.Row.RowState == DataControlRowState.Alternate)
                {
                    /*e.Row.Cells[1].Style.Add("background", "#007bff");
                    e.Row.Cells[2].Style.Add("background", "#007bff");
                    e.Row.Cells[3].Style.Add("background", "#007bff");
                    e.Row.Cells[4].Style.Add("background", "#007bff");
                    e.Row.Cells[5].Style.Add("background", "#007bff");
                    e.Row.Cells[6].Style.Add("background", "#007bff");
                    e.Row.Cells[7].Style.Add("background", "#007bff");
                    e.Row.Cells[8].Style.Add("background", "#007bff");
                    e.Row.Cells[9].Style.Add("background", "#007bff");
                    e.Row.Cells[10].Style.Add("background", "#007bff");
                    e.Row.Cells[11].Style.Add("background", "#007bff");
                    e.Row.Cells[12].Style.Add("background", "#007bff");*/
                }
                else
                {
                    e.Row.Cells[1].Style.Add("background", "aquamarine");
                    e.Row.Cells[2].Style.Add("background", "aquamarine");
                    e.Row.Cells[3].Style.Add("background", "aquamarine");
                    e.Row.Cells[4].Style.Add("background", "aquamarine");
                    e.Row.Cells[5].Style.Add("background", "aquamarine");
                    e.Row.Cells[6].Style.Add("background", "aquamarine");
                    e.Row.Cells[7].Style.Add("background", "aquamarine");
                    e.Row.Cells[8].Style.Add("background", "aquamarine");
                    e.Row.Cells[9].Style.Add("background", "aquamarine");
                    e.Row.Cells[10].Style.Add("background", "aquamarine");
                    e.Row.Cells[11].Style.Add("background", "aquamarine");
                    e.Row.Cells[12].Style.Add("background", "aquamarine");
                    e.Row.Cells[13].Style.Add("background", "aquamarine");
                }
            }

             if (e.Row.RowType == DataControlRowType.Footer)
             {
                  e.Row.Font.Bold = true;
                  e.Row.Cells[1].Text = "Total";
                  e.Row.Cells[2].Text = NoOfUnitsInc.ToString();
                  e.Row.Cells[3].Text = TotalNoOfIncentives.ToString();
                  e.Row.Cells[4].Text = NooFIncentivesSanctioned.ToString();
                  e.Row.Cells[5].Text = "( " + PendingatDLODLC.ToString();
                  e.Row.Cells[6].Text = PendingatDLOSLC.ToString() + " )";
                  e.Row.Cells[7].Text = " = " + NoOfIncentivesatDLO.ToString();
                  e.Row.Cells[8].Text = PendingAtDLSVCDLC.ToString();
                  e.Row.Cells[9].Text = NoOfIncentivesatHO.ToString();
                  e.Row.Cells[10].Text = NoOfIncentivesatApplicant.ToString();
                  e.Row.Cells[11].Text = PendingRevisedInspectionIncentives.ToString();
                  e.Row.Cells[12].Text = NoOfIncentivesRejected.ToString();
                  e.Row.Cells[13].Text = NooFIncentivesReleased.ToString();

                  
                  e.Row.Cells[1].Style.Add("background-color", "#dee9f5");
                  e.Row.Cells[2].Style.Add("background-color", "#dee9f5");
                  e.Row.Cells[3].Style.Add("background-color", "#dee9f5");
                  e.Row.Cells[4].Style.Add("background-color", "#dee9f5");
                  e.Row.Cells[5].Style.Add("background-color", "#dee9f5");
                  e.Row.Cells[6].Style.Add("background-color", "#dee9f5");
                  e.Row.Cells[7].Style.Add("background-color", "#dee9f5");
                  e.Row.Cells[8].Style.Add("background-color", "#dee9f5");
                  e.Row.Cells[9].Style.Add("background-color", "#dee9f5");
                  e.Row.Cells[10].Style.Add("background-color", "#dee9f5");
                  e.Row.Cells[11].Style.Add("background-color", "#dee9f5");
                  e.Row.Cells[12].Style.Add("background-color", "#dee9f5");
                  e.Row.Cells[13].Style.Add("background-color", "#dee9f5");

                 

                HyperLink h1 = new HyperLink();
                
                h1.Text = NoOfUnitsInc.ToString();
                if (h1.Text != "0")
                {
                    h1.Style.Add("color", "black");
                    h1.NavigateUrl = "frmUnitsDetailedReport.aspx?Level=2&Flag=Z&DistrictId=0";
                    e.Row.Cells[2].Controls.Add(h1);
                }
                  HyperLink h2 = new HyperLink();
                
                h2.Text = TotalNoOfIncentives.ToString();
                if (h2.Text != "0")
                {
                    h2.Style.Add("color", "black");
                    h2.NavigateUrl = "FormIncentivesReportView.aspx?Level=2&Flag=T&DistrictId=0";
                    e.Row.Cells[3].Controls.Add(h2);
                }
                HyperLink h8 = new HyperLink();

                h8.Text = NooFIncentivesSanctioned.ToString();
                if (h8.Text != "0")
                {
                    h8.Style.Add("color", "black");
                    h8.NavigateUrl = "FormIncentivesReportView.aspx?Level=2&Flag=S&DistrictId=0";
                    e.Row.Cells[4].Controls.Add(h8);
                }

                HyperLink h11 = new HyperLink();

                h11.Text = "( " + PendingatDLODLC.ToString();
                if (h11.Text != "0")
                {
                    h11.Style.Add("color", "red");
                    h11.NavigateUrl = "FormIncentivesReportView.aspx?Level=2&Flag=DLCP&DistrictId=0";
                    e.Row.Cells[5].Controls.Add(h11);
                }
                HyperLink h12 = new HyperLink();

                h12.Text = PendingatDLOSLC.ToString() + " )";
                if (h12.Text != "0")
                {
                    h12.Style.Add("color", "red");
                    h12.NavigateUrl = "FormIncentivesReportView.aspx?Level=2&Flag=SLC&DistrictId=0";
                    e.Row.Cells[6].Controls.Add(h12);
                }
                /*HyperLink h3 = new HyperLink();
                
                h3.Text = NoOfIncentivesatPayment.ToString();
                if (h3.Text != "0")
                {
                    h3.Style.Add("color", "black");
                    h3.NavigateUrl = "FormIncentivesReportView.aspx?Level=2&Flag=P&DistrictId=0";
                    e.Row.Cells[5].Controls.Add(h3);
                }*/

                HyperLink h4 = new HyperLink();
                
                h4.Text = " = " + NoOfIncentivesatDLO.ToString();
                if (h4.Text != "0")
                {
                    h4.Style.Add("color", "black");
                    h4.NavigateUrl = "FormIncentivesReportView.aspx?Level=2&Flag=D&DistrictId=0";
                    e.Row.Cells[7].Controls.Add(h4);
                }
                HyperLink h10 = new HyperLink();

                h10.Text = PendingAtDLSVCDLC.ToString();
                if (h10.Text != "0")
                {
                    h10.Style.Add("color", "black");
                    h10.NavigateUrl = "FormIncentivesReportView.aspx?Level=2&Flag=DLC&DistrictId=0";
                    e.Row.Cells[8].Controls.Add(h10);
                }
                HyperLink h6 = new HyperLink();

                h6.Text = NoOfIncentivesatHO.ToString();
                if (h6.Text != "0")
                {
                    h6.Style.Add("color", "black");
                    h6.NavigateUrl = "FormIncentivesReportView.aspx?Level=2&Flag=H&DistrictId=0";
                    e.Row.Cells[9].Controls.Add(h6);
                }
                HyperLink h5 = new HyperLink();
                
                h5.Text = NoOfIncentivesatApplicant.ToString();
                if (h5.Text != "0")
                {
                    h5.Style.Add("color", "black");
                    h5.NavigateUrl = "FormIncentivesReportView.aspx?Level=2&Flag=A&DistrictId=0";
                    e.Row.Cells[10].Controls.Add(h5);
                }
                  
                 HyperLink h6a = new HyperLink();
                
                h6a.Text = PendingRevisedInspectionIncentives.ToString();
                if (h6a.Text != "0")
                {
                    h6a.Style.Add("color", "black");
                    h6a.NavigateUrl = "FormIncentivesReportView.aspx?Level=2&Flag=IN&DistrictId=0";
                    e.Row.Cells[11].Controls.Add(h6a);
                }
                 HyperLink h7 = new HyperLink();
                
                h7.Text = NoOfIncentivesRejected.ToString();
                if (h7.Text != "0")
                {
                    h7.Style.Add("color", "black");
                    h7.NavigateUrl = "FormIncentivesReportView.aspx?Level=2&Flag=R&DistrictId=0";
                    e.Row.Cells[12].Controls.Add(h7);
                }
                 
                  HyperLink h9 = new HyperLink();
                
                h9.Text = NooFIncentivesReleased.ToString();
                if (h9.Text != "0")
                {
                    h9.Style.Add("color", "black");
                    h9.NavigateUrl = "FormIncentivesReportView.aspx?Level=2&Flag=RL&DistrictId=0";
                    e.Row.Cells[13].Controls.Add(h9);
                }
            }
        }
       
        public void GetSnos()
        {
            int slno = 0;
            foreach (GridViewRow row in gvdetailsInc.Rows)
            {
                string DistId = (row.FindControl("lblDistrictId") as Label).Text;
                if (DistId != "")
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
        [WebMethod]
        public static string GetIncentives(string DistId)
        {
            List<Incentive> listIncentive = new List<Incentive>();
            string CS = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("USP_GET_INCENTIVE_WISE_ABSTRACT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@DISTRICTFLAG",
                    Value = DistId
                });
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Incentive incentive = new Incentive();
                    incentive.IncentiveName = rdr["IncentiveName"].ToString();
                    incentive.IncentiveId = rdr["IncentiveId"].ToString();
                    incentive.NoofClaims = rdr["NoofClaims"].ToString();
                    incentive.TotalAmountClaimed = rdr["TotalAmountClaimed"].ToString();
                    listIncentive.Add(incentive);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(listIncentive);
        }
        public class Incentive
        {
            public string UnitName { get; set; }
            public string IncentiveName { get; set; }
            public string ClaimPeriod { get; set; }
            public string ApplicationNumber { get; set; }
            public string IncentiveId { get; set; }
            public string NoofClaims { get; set; }
            public string TotalAmountClaimed { get; set; }
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
                Response.AddHeader("content-disposition", "attachment;filename=R11-ADO_Wise_Incentive_Abstract.xls");
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
                    DateTime date = DateTime.UtcNow.Date;
                    string label1text = "R11. AD Wise Incentive Abstract as on " + date.ToString("dd/MM/yyyy");
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

        protected void ckhActive_CheckedChanged(object sender, EventArgs e)
        {
            rdbOrderby_SelectedIndexChanged(sender, e);
        }

        protected void gvdetailsInc_PreRender(object sender, EventArgs e)
        {
            MergeRows(gvdetailsInc,1);
            //MergeGridViewColumn(gvdetailsInc, 0);
        }
        public static void MergeRows(GridView gridView, int ColNumber)
        {
            for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = gridView.Rows[rowIndex];
                GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                for (int i = 0; i < ColNumber; i++)
                {
                    if (row.Cells[i].Text == previousRow.Cells[i].Text)
                    {
                        row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 : previousRow.Cells[i].RowSpan + 1;
                        previousRow.Cells[i].Visible = false;
                        row.Cells[0].Attributes.Add("vertical-align", "middle");
                    }
                }
            }
        }
        static public void MergeGridViewColumn(GridView gridView, int position)
        {
            string text = string.Empty;
            int count = 0;
            Hashtable ht = new Hashtable();
            // loop through all rows to get row conts

            foreach (GridViewRow gvr in gridView.Rows)
            {
                if (gvr.RowType == DataControlRowType.DataRow)
                {
                    if (gvr.Cells[position].Text == text)
                    {
                        count++;
                    }
                    else
                    {
                        if (count > 0)
                        {
                            ht.Add(text, count);
                        }
                        text = gvr.Cells[position].Text;
                        count = 1;
                    }
                }
            } //end foreach

            if (count > 1)
            {

                ht.Add(text, count);

            }
            // loop through all rows again to set rowspan

            text = string.Empty; foreach (GridViewRow gvr in gridView.Rows)
            {
                if (gvr.RowType == DataControlRowType.DataRow)
                {
                    if (gvr.Cells[position].Text == text)
                    {
                        gvr.Cells.Remove(gvr.Cells[position]);
                    }
                    else
                    {
                        text = gvr.Cells[position].Text;
                        gvr.Cells[position].RowSpan = Convert.ToInt32(ht[text]);
                        gvr.Cells[position].VerticalAlign = VerticalAlign.Middle;
                    }
                }
            }
        }
    }
}