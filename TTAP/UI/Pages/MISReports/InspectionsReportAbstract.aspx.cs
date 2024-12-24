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
    public partial class InspectionsReportAbstract : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();

        int NoofIncentivesRcvd;
        int NoOfIncentivesPending;
        int DLOQueryResponseWithin;
        int DLOQueryAwaiting;
        int NoofInspectionScheduled;
        int NoofInspectionCompleted;
        int NoofRevisedInspectionScheduled;
        int NoofRevisedInspectionCompleted;
        int NoofIncentivesPendingforReferenceToHO;
        int NoofIncentivesForwardedtoHO;

        int NoofIncentivesRcvd_All;
        int NoOfIncentivesPending_All;
        int ScrutinyCompleted_All;
        int DLOQueryRaised_All;
        int DLOQueryResponseWithin_All;
        int DLOQueryAwaiting_All;
        int NoofInspectionScheduled_All;
        int NoofInspectionCompleted_All;
        int DLOQueryRaisedAfterInspection_All;
        int QueryResponseWithinAfterInspection_All;
        int DLOQueryAwaitingAfterInspection_All;
        int NoofRevisedInspectionScheduled_All;
        int NoofRevisedInspectionCompleted_All;
        int NoofIncentivesPendingforReferenceToHO_All;
        int NoofIncentivesForwardedtoHO_All;
        int DLORejectedBeforeInspection_All;
        int DLORejectedAfterInspection_All;
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
                        BindIncentives();
                        BindGrid();
                        if (ObjLoginNewvo.Role_Code == "DLO")
                        {   
                            gvdetailsInc.FooterRow.Visible = false;
                        }
                        DateTime dateTime = DateTime.UtcNow.Date;
                        Header.InnerHtml = "Report as on " + dateTime.ToString("dd/MM/yyyy");
                    }
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
        public void BindGrid()
        {
            dss = GetIncentiveInspectionAbstract(Session["uid"].ToString(),ddlIncentives.SelectedValue.ToString());
            if (dss.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
                {
                    gvdetailsInc.DataSource = dss;
                    gvdetailsInc.DataBind();
                    GvAllStages.DataSource = dss;
                    GvAllStages.DataBind();
                }
                else
                {
                    gvdetailsInc.DataSource = null;
                    gvdetailsInc.DataBind();
                    GvAllStages.DataSource = null;
                    GvAllStages.DataBind();
                }
            }
        }
        public DataSet GetIncentiveInspectionAbstract(string UserID,string IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
               new SqlParameter("@SubIncentiveId",SqlDbType.VarChar)
           };
            pp[0].Value = UserID;
            pp[1].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_INSPECTION_ABSTRACT", pp);

            return Dsnew;
        }

        protected void gvdetailsInc_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string SubIncId = ddlIncentives.SelectedValue.ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int NoofIncentivesRcvd1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoofIncentivesRcvd"));
                NoofIncentivesRcvd = NoofIncentivesRcvd1 + NoofIncentivesRcvd;

                int NoOfIncentivesPending1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfIncentivesPending"));
                NoOfIncentivesPending = NoOfIncentivesPending1 + NoOfIncentivesPending;

                int NoofInspectionScheduled1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoofInspectionScheduled"));
                NoofInspectionScheduled = NoofInspectionScheduled1 + NoofInspectionScheduled;

                int DLOQueryResponseWithin1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DLOQueryResponseWithin"));
                DLOQueryResponseWithin = DLOQueryResponseWithin1 + DLOQueryResponseWithin;

                int DLOQueryAwaiting1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DLOQueryAwaiting"));
                DLOQueryAwaiting = DLOQueryAwaiting1 + DLOQueryAwaiting;

                int NoofInspectionCompleted1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoofInspectionCompleted"));
                NoofInspectionCompleted = NoofInspectionCompleted1 + NoofInspectionCompleted;

                int NoofRevisedInspectionScheduled1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoofRevisedInspectionScheduled"));
                NoofRevisedInspectionScheduled = NoofRevisedInspectionScheduled1 + NoofRevisedInspectionScheduled;

                int NoofRevisedInspectionCompleted1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoofRevisedInspectionCompleted"));
                NoofRevisedInspectionCompleted = NoofRevisedInspectionCompleted1 + NoofRevisedInspectionCompleted;

                int NoofIncentivesPendingforReferenceToHO1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoofIncentivesPendingforReferenceToHO"));
                NoofIncentivesPendingforReferenceToHO = NoofIncentivesPendingforReferenceToHO1 + NoofIncentivesPendingforReferenceToHO;

                int NoofIncentivesForwardedtoHO1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoofIncentivesForwardedtoHO"));
                NoofIncentivesForwardedtoHO = NoofIncentivesForwardedtoHO1 + NoofIncentivesForwardedtoHO;

                

                Label lblDistrictId = (e.Row.FindControl("lblDistrictId") as Label);
                
                HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
                if (h1.Text != "0")
                {
                    h1.Style.Add("color", "black");
                    h1.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=A&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }
                HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
                if (h2.Text != "0")
                {
                    h2.Style.Add("color", "black");
                    h2.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=P&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }
                HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
                if (h3.Text != "0")
                {
                    h3.Style.Add("color", "black");
                    h3.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=IP&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }
                HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
                if (h4.Text != "0")
                {
                    h4.Style.Add("color", "black");
                    h4.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=RIP&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }

                HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];
                if (h5.Text != "0")
                {
                    h5.Style.Add("color", "black");
                    h5.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=RIP&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }
                HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];
                if (h6.Text != "0")
                {
                    h6.Style.Add("color", "black");
                    h6.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=PHO&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }
                
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[2].Text = NoofIncentivesRcvd.ToString();
                e.Row.Cells[3].Text = NoOfIncentivesPending.ToString();
                e.Row.Cells[4].Text = DLOQueryAwaiting.ToString();
                e.Row.Cells[5].Text = NoofInspectionScheduled.ToString();
                e.Row.Cells[6].Text = NoofRevisedInspectionScheduled.ToString();
                e.Row.Cells[7].Text = NoofIncentivesPendingforReferenceToHO.ToString();

                e.Row.Cells[2].Style.Add("background-color", "aquamarine");
                e.Row.Cells[4].Style.Add("background-color", "aquamarine");
                e.Row.Cells[6].Style.Add("background-color", "aquamarine");
                //e.Row.Cells[8].Style.Add("background-color", "aquamarine");

                HyperLink h1 = new HyperLink();
                h1.Text = NoofIncentivesRcvd.ToString();
                if (h1.Text != "0")
                {
                    h1.Style.Add("color", "black");
                    h1.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=A&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[2].Controls.Add(h1);
                }
                HyperLink h2 = new HyperLink();
                h2.Text = NoOfIncentivesPending.ToString();
                if (h2.Text != "0")
                {
                    h2.Style.Add("color", "black");
                    h2.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=P&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[3].Controls.Add(h2);
                }
                HyperLink h3 = new HyperLink();
                h3.Text = DLOQueryAwaiting.ToString();
                if (h3.Text != "0")
                {
                    h3.Style.Add("color", "black");
                    h3.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=DQA&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[4].Controls.Add(h3);
                }
                HyperLink h4 = new HyperLink();
                h4.Text = NoofInspectionScheduled.ToString();
                if (h4.Text != "0")
                {
                    h4.Style.Add("color", "black");
                    h4.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=IP&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[5].Controls.Add(h4);
                }

                HyperLink h5 = new HyperLink();
                h5.Text = NoofRevisedInspectionScheduled.ToString();
                if (h5.Text != "0")
                {
                    h5.Style.Add("color", "black");
                    h5.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=RIP&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[6].Controls.Add(h5);
                }
                HyperLink h6 = new HyperLink();
                h6.Text = NoofIncentivesPendingforReferenceToHO.ToString();
                if (h6.Text != "0")
                {
                    h6.Style.Add("color", "black");
                    h6.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=PHO&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[7].Controls.Add(h6);
                }
            }
        }
        public void BindIncentives()
        {
            try
            {
                DataSet ApprovedIncentives = new DataSet();
                ddlIncentives.Items.Clear();
                ApprovedIncentives = GetIncentives();
                if (ApprovedIncentives != null && ApprovedIncentives.Tables.Count > 0 && ApprovedIncentives.Tables[0].Rows.Count > 0)
                {
                    ddlIncentives.DataSource = ApprovedIncentives.Tables[0];
                    ddlIncentives.DataValueField = "IncentiveID";
                    ddlIncentives.DataTextField = "IncentiveName";
                    ddlIncentives.DataBind();
                    AddSelect(ddlIncentives);
                }
                else
                {
                    AddSelect(ddlIncentives);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AddSelect(DropDownList ddl)
        {
            try
            {
                ListItem li = new ListItem();
                li.Text = "--Select--";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                //lblmsg0.Text = ex.Message;
                //Failure.Visible = true;
                //success.Visible = false;
            }
        }
        public DataSet GetIncentives()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = caf.GenericFillDs("USP_GET_INCENTIVES");
            return Dsnew;
        }

        protected void ddlIncentives_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
            NameHeader.InnerText = ddlIncentives.SelectedItem.ToString();
            if (ddlIncentives.SelectedValue == "0")
            {
                NameHeader.InnerText = "All Incentives";
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "ChangeDiv()", true);
        }

        protected void rdbOrderby_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdbOrderby.SelectedValue == "P")
            {
                DivPending.Visible = true;
                DivAll.Visible = false;
            }
            else
            {
                DivPending.Visible = false;
                DivAll.Visible = true;
            }
        }

        protected void GvAllStages_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string SubIncId = ddlIncentives.SelectedValue.ToString();
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int NoofIncentivesRcvd_All1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoofIncentivesRcvd"));
                NoofIncentivesRcvd_All = NoofIncentivesRcvd_All1 + NoofIncentivesRcvd_All;

                int NoOfIncentivesPending_All1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoOfIncentivesPending"));
                NoOfIncentivesPending_All = NoOfIncentivesPending_All1 + NoOfIncentivesPending_All;

                int ScrutinyCompleted_All1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ScrutinyCompleted"));
                ScrutinyCompleted_All = ScrutinyCompleted_All1 + ScrutinyCompleted_All;

                int DLOQueryRaised_All1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DLOQueryRaised"));
                DLOQueryRaised_All = DLOQueryRaised_All1 + DLOQueryRaised_All;

                int DLOQueryResponseWithin_All1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DLOQueryResponseWithin"));
                DLOQueryResponseWithin_All = DLOQueryResponseWithin_All1 + DLOQueryResponseWithin_All;

                int DLOQueryAwaiting_All1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DLOQueryAwaiting"));
                DLOQueryAwaiting_All = DLOQueryAwaiting_All1 + DLOQueryAwaiting_All;

                int NoofInspectionScheduled_All1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoofInspectionScheduled"));
                NoofInspectionScheduled_All = NoofInspectionScheduled_All1 + NoofInspectionScheduled_All;

                int NoofInspectionCompleted_All1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoofInspectionCompleted"));
                NoofInspectionCompleted_All = NoofInspectionCompleted_All1 + NoofInspectionCompleted_All;

                int DLOQueryRaisedAfterInspection_All1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DLOQueryRaisedAfterInspection"));
                DLOQueryRaisedAfterInspection_All = DLOQueryRaisedAfterInspection_All1 + DLOQueryRaisedAfterInspection_All;

                int QueryResponseWithinAfterInspection_All1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "QueryResponseWithinAfterInspection"));
                QueryResponseWithinAfterInspection_All = QueryResponseWithinAfterInspection_All1 + QueryResponseWithinAfterInspection_All;

                int DLOQueryAwaitingAfterInspection_All1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DLOQueryAwaitingAfterInspection"));
                DLOQueryAwaitingAfterInspection_All = DLOQueryAwaitingAfterInspection_All1 + DLOQueryAwaitingAfterInspection_All;

                int NoofRevisedInspectionScheduled_All1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoofRevisedInspectionScheduled"));
                NoofRevisedInspectionScheduled_All = NoofRevisedInspectionScheduled_All1 + NoofRevisedInspectionScheduled_All;

                int NoofRevisedInspectionCompleted_All1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoofRevisedInspectionCompleted"));
                NoofRevisedInspectionCompleted_All = NoofRevisedInspectionCompleted_All1 + NoofRevisedInspectionCompleted_All;

                int NoofIncentivesPendingforReferenceToHO_All1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoofIncentivesPendingforReferenceToHO"));
                NoofIncentivesPendingforReferenceToHO_All = NoofIncentivesPendingforReferenceToHO_All1 + NoofIncentivesPendingforReferenceToHO_All;

                int NoofIncentivesForwardedtoHO_All1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoofIncentivesForwardedtoHO"));
                NoofIncentivesForwardedtoHO_All = NoofIncentivesForwardedtoHO_All1 + NoofIncentivesForwardedtoHO_All;

                int DLORejectedBeforeInspection_All1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DLORejectedBeforeInspection"));
                DLORejectedBeforeInspection_All = DLORejectedBeforeInspection_All1 + DLORejectedBeforeInspection_All;

                int DLORejectedAfterInspection_All1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DLORejectedAfterInspection"));
                DLORejectedAfterInspection_All = DLORejectedAfterInspection_All1 + DLORejectedAfterInspection_All;

                Label lblDistrictId = (e.Row.FindControl("lblDistrictId") as Label);

                HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
                if (h1.Text != "0")
                {
                    h1.Style.Add("color", "black");
                    h1.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=A&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }
                HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
                if (h2.Text != "0")
                {
                    h2.Style.Add("color", "black");
                    h2.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=P&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }
                HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
                if (h3.Text != "0")
                {
                    h3.Style.Add("color", "black");
                    h3.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=SC&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }
                HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
                if (h4.Text != "0")
                {
                    h4.Style.Add("color", "black");
                    h4.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=DQ&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }

                HyperLink h5 = (HyperLink)e.Row.Cells[6].Controls[0];
                if (h5.Text != "0")
                {
                    h5.Style.Add("color", "black");
                    h5.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=DQR&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }
                HyperLink h6 = (HyperLink)e.Row.Cells[7].Controls[0];
                if (h6.Text != "0")
                {
                    h6.Style.Add("color", "black");
                    h6.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=DQA&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }

                HyperLink h7 = (HyperLink)e.Row.Cells[8].Controls[0];
                if (h7.Text != "0")
                {
                    h7.Style.Add("color", "black");
                    h7.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=IP&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }
                HyperLink h8 = (HyperLink)e.Row.Cells[9].Controls[0];
                if (h8.Text != "0")
                {
                    h8.Style.Add("color", "black");
                    h8.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=IC&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }
                //
                HyperLink h9 = (HyperLink)e.Row.Cells[10].Controls[0];
                if (h9.Text != "0")
                {
                    h9.Style.Add("color", "black");
                    h9.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=DQI&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }
                HyperLink h10 = (HyperLink)e.Row.Cells[11].Controls[0];
                if (h10.Text != "0")
                {
                    h10.Style.Add("color", "black");
                    h10.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=DQIR&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }
                HyperLink h11 = (HyperLink)e.Row.Cells[12].Controls[0];
                if (h11.Text != "0")
                {
                    h11.Style.Add("color", "black");
                    h11.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=DQIA&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }
                HyperLink h12 = (HyperLink)e.Row.Cells[13].Controls[0];
                if (h12.Text != "0")
                {
                    h12.Style.Add("color", "black");
                    h12.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=RIP&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }

                HyperLink h13 = (HyperLink)e.Row.Cells[14].Controls[0];
                if (h13.Text != "0")
                {
                    h13.Style.Add("color", "black");
                    h13.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=RIC&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }
                HyperLink h14 = (HyperLink)e.Row.Cells[15].Controls[0];
                if (h14.Text != "0")
                {
                    h14.Style.Add("color", "black");
                    h14.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=PHO&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }

                HyperLink h15 = (HyperLink)e.Row.Cells[16].Controls[0];
                if (h15.Text != "0")
                {
                    h15.Style.Add("color", "black");
                    h15.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=FHO&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }
                HyperLink h16 = (HyperLink)e.Row.Cells[17].Controls[0];
                if (h16.Text != "0")
                {
                    h16.Style.Add("color", "black");
                    h16.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=R&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }
                HyperLink h17 = (HyperLink)e.Row.Cells[18].Controls[0];
                if (h17.Text != "0")
                {
                    h17.Style.Add("color", "black");
                    h17.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=RI&DistrictId=" + lblDistrictId.Text.Trim() + "&SubIncId=" + SubIncId;
                }

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[2].Text = NoofIncentivesRcvd_All.ToString();
                e.Row.Cells[3].Text = NoOfIncentivesPending_All.ToString();
                e.Row.Cells[4].Text = ScrutinyCompleted_All.ToString();
                e.Row.Cells[5].Text = DLOQueryRaised_All.ToString();
                e.Row.Cells[6].Text = DLOQueryResponseWithin_All.ToString();
                e.Row.Cells[7].Text = DLOQueryAwaiting_All.ToString();
                e.Row.Cells[8].Text = NoofInspectionScheduled_All.ToString();
                e.Row.Cells[9].Text = NoofInspectionCompleted_All.ToString();
                e.Row.Cells[10].Text = DLOQueryRaisedAfterInspection_All.ToString();
                e.Row.Cells[11].Text = QueryResponseWithinAfterInspection_All.ToString();
                e.Row.Cells[12].Text = DLOQueryAwaitingAfterInspection_All.ToString();
                e.Row.Cells[13].Text = NoofRevisedInspectionScheduled_All.ToString();
                e.Row.Cells[14].Text = NoofRevisedInspectionCompleted_All.ToString();
                e.Row.Cells[15].Text = NoofIncentivesPendingforReferenceToHO_All.ToString();
                e.Row.Cells[16].Text = NoofIncentivesForwardedtoHO_All.ToString();
                e.Row.Cells[17].Text = DLORejectedBeforeInspection_All.ToString();
                e.Row.Cells[18].Text = DLORejectedAfterInspection_All.ToString();


                e.Row.Cells[2].Style.Add("background-color", "aquamarine");
                e.Row.Cells[4].Style.Add("background-color", "aquamarine");
                e.Row.Cells[6].Style.Add("background-color", "aquamarine");
                e.Row.Cells[8].Style.Add("background-color", "aquamarine");
                e.Row.Cells[10].Style.Add("background-color", "aquamarine");
                e.Row.Cells[12].Style.Add("background-color", "aquamarine");
                e.Row.Cells[14].Style.Add("background-color", "aquamarine");
                e.Row.Cells[16].Style.Add("background-color", "aquamarine");
                e.Row.Cells[18].Style.Add("background-color", "aquamarine");

                HyperLink h1 = new HyperLink();
                h1.Text = NoofIncentivesRcvd_All.ToString();
                if (h1.Text != "0")
                {
                    h1.Style.Add("color", "black");
                    h1.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=A&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[2].Controls.Add(h1);
                }
                HyperLink h2 = new HyperLink();
                h2.Text = NoOfIncentivesPending_All.ToString();
                if (h2.Text != "0")
                {
                    h2.Style.Add("color", "black");
                    h2.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=P&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[3].Controls.Add(h2);
                }
                HyperLink h3 = new HyperLink();
                h3.Text = ScrutinyCompleted_All.ToString();
                if (h3.Text != "0")
                {
                    h3.Style.Add("color", "black");
                    h3.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=SC&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[4].Controls.Add(h3);
                }
                HyperLink h4 = new HyperLink();
                h4.Text = DLOQueryRaised_All.ToString();
                if (h4.Text != "0")
                {
                    h4.Style.Add("color", "black");
                    h4.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=DQ&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[5].Controls.Add(h4);
                }

                HyperLink h5 = new HyperLink();
                h5.Text = DLOQueryResponseWithin_All.ToString();
                if (h5.Text != "0")
                {
                    h5.Style.Add("color", "black");
                    h5.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=DQR&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[6].Controls.Add(h5);
                }
                HyperLink h6 = new HyperLink();
                h6.Text = DLOQueryAwaiting_All.ToString();
                if (h6.Text != "0")
                {
                    h6.Style.Add("color", "black");
                    h6.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=DQA&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[7].Controls.Add(h6);
                }

                HyperLink h7 = new HyperLink();
                h7.Text = NoofInspectionScheduled_All.ToString();
                if (h7.Text != "0")
                {
                    h7.Style.Add("color", "black");
                    h7.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=IP&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[8].Controls.Add(h7);
                }
                HyperLink h8 = new HyperLink();
                h8.Text = NoofInspectionCompleted_All.ToString();
                if (h8.Text != "0")
                {
                    h8.Style.Add("color", "black");
                    h8.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=IC&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[9].Controls.Add(h8);
                }

                //
                HyperLink h9 = new HyperLink();
                h9.Text = DLOQueryRaisedAfterInspection_All.ToString();
                if (h9.Text != "0")
                {
                    h9.Style.Add("color", "black");
                    h9.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=DQI&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[10].Controls.Add(h9);
                }
                HyperLink h10 = new HyperLink();
                h10.Text = QueryResponseWithinAfterInspection_All.ToString();
                if (h10.Text != "0")
                {
                    h10.Style.Add("color", "black");
                    h10.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=DQIR&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[11].Controls.Add(h10);
                }
                HyperLink h11 = new HyperLink();
                h11.Text = DLOQueryAwaitingAfterInspection_All.ToString();
                if (h11.Text != "0")
                {
                    h11.Style.Add("color", "black");
                    h11.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=DQIA&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[12].Controls.Add(h11);
                }
                HyperLink h12 = new HyperLink();
                h12.Text = NoofRevisedInspectionScheduled_All.ToString();
                if (h12.Text != "0")
                {
                    h12.Style.Add("color", "black");
                    h12.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=RIP&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[13].Controls.Add(h12);
                }

                HyperLink h13 = new HyperLink();
                h13.Text = NoofRevisedInspectionCompleted_All.ToString();
                if (h13.Text != "0")
                {
                    h13.Style.Add("color", "black");
                    h13.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=RIC&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[14].Controls.Add(h13);
                }
                HyperLink h14 = new HyperLink();
                h14.Text = NoofIncentivesPendingforReferenceToHO_All.ToString();
                if (h14.Text != "0")
                {
                    h14.Style.Add("color", "black");
                    h14.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=PHO&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[15].Controls.Add(h14);
                }

                HyperLink h15 = new HyperLink();
                h15.Text = NoofIncentivesForwardedtoHO_All.ToString();
                if (h15.Text != "0")
                {
                    h15.Style.Add("color", "black");
                    h15.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=FHO&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[16].Controls.Add(h15);
                }
                HyperLink h16 = new HyperLink();
                h16.Text = DLORejectedBeforeInspection_All.ToString();
                if (h16.Text != "0")
                {
                    h16.Style.Add("color", "black");
                    h16.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=R&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[17].Controls.Add(h16);
                }

                HyperLink h17 = new HyperLink();
                h17.Text = DLORejectedAfterInspection_All.ToString();
                if (h17.Text != "0")
                {
                    h17.Style.Add("color", "black");
                    h17.NavigateUrl = "InspectionsDetailedReport.aspx?Flag=RI&DistrictId=0" + "&SubIncId=" + SubIncId;
                    e.Row.Cells[18].Controls.Add(h17);
                }
            }
        }
    }
}