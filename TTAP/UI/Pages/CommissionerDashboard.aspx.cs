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

namespace TTAP.UI.Pages
{
    public partial class CommissionerDashboard : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();
        int NoofIncentivesRcvd;
        int DLOPendingWithin;
        int InspectionPendingWithin;
        int ReInspectionPending;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {   
                        BindDistricts();
                        BindGrid();
                        /*BindCount();*/
                    }
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
        public void BindDistricts()
        {
            dss = GetDistrictsList();
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                ddlDistrict.DataSource = dss;
                ddlDistrict.DataTextField = "District_Name";
                ddlDistrict.DataValueField = "District_Id";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, "All");
            }
            else
            {
                ddlDistrict.Items.Insert(0, "--Select--");
            }
        }
        public void BindCount()
        {
            int DistId = 0;
            if (ddlDistrict.SelectedIndex == 0)
            {
                DistId = 0;
            }
            else
            {
                DistId = Convert.ToInt32(ddlDistrict.SelectedValue.ToString());
            }
            dss = GetDLODashboardComm(DistId);
            lblPendingIncentives.Text = dss.Tables[0].Rows[0]["DLOPendingWithin"].ToString();
            lblPendingInspections.Text = dss.Tables[0].Rows[0]["InspectionPendingWithin"].ToString();
        }
        public void BindGrid()
        {
            dss = GetIncentiveAbstract(Session["uid"].ToString());
            if (dss.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
                {
                    gvDashboard.DataSource = dss;
                    gvDashboard.DataBind();
                }
            }
        }
        public DataSet GetIncentiveAbstract(string UserID)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar)
           };
            pp[0].Value = UserID;

            Dsnew = caf.GenericFillDs("USP_GET_DLO_DASHBOARD_DTLS_COMMISSIONER", pp);

            return Dsnew;
        }
        public DataSet GetDistrictsList()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = caf.GenericFillDs("GetDistrictsHYD");
            return Dsnew;
        }
        public DataSet GetDLODashboardComm(int DistId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DistId",SqlDbType.Int),
           };
            pp[0].Value = DistId;
            Dsnew = caf.GenericFillDs("USP_GET_DLO_DASHBOARD_DTLS_COMM", pp);
            return Dsnew;
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindCount();
        }
        protected void gvDashboard_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int NoofIncentivesRcvd1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NoofIncentivesRcvd"));
                NoofIncentivesRcvd = NoofIncentivesRcvd1 + NoofIncentivesRcvd;

                int DLOPendingWithin1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DLOPendingWithin"));
                DLOPendingWithin = DLOPendingWithin1 + DLOPendingWithin;

                int InspectionPendingWithin1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "InspectionPendingWithin"));
                InspectionPendingWithin = InspectionPendingWithin1 + InspectionPendingWithin;

                int ReInspectionPending1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ReInspectionPending"));
                ReInspectionPending = ReInspectionPending1 + ReInspectionPending;

               
                Label lblDistrictId = (e.Row.FindControl("lblDistrictId") as Label);

                HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
                if (h1.Text != "0")
                {
                    h1.Style.Add("color", "black");
                    h1.NavigateUrl = "frmDLOApplicationsComm.aspx?Stg=0&DistId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
                if (h2.Text != "0")
                {
                    h2.Style.Add("color", "black");
                    h2.NavigateUrl = "frmDLOApplicationsComm.aspx?Stg=1&DistId=" + lblDistrictId.Text.Trim();
                }
                HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
                if (h3.Text != "0")
                {
                    h3.Style.Add("color", "black");
                    h3.NavigateUrl = "frmDLOApplicationsComm.aspx?Stg=2&DistId=" + lblDistrictId.Text.Trim();
                }

                /*HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
                if (h4.Text != "0")
                {
                    h4.Style.Add("color", "black");
                    h4.NavigateUrl = "frmDLOApplicationsComm.aspx?Stg=2&DistId=" + lblDistrictId.Text.Trim();
                }*/
               

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Font.Bold = true;
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[2].Text = NoofIncentivesRcvd.ToString();
                e.Row.Cells[3].Text = DLOPendingWithin.ToString();
                e.Row.Cells[4].Text = InspectionPendingWithin.ToString();
                /*e.Row.Cells[5].Text = ReInspectionPending.ToString();*/

                e.Row.Cells[2].Style.Add("background-color", "aquamarine");
                e.Row.Cells[4].Style.Add("background-color", "aquamarine");

                HyperLink h1 = new HyperLink();
                h1.Text = NoofIncentivesRcvd.ToString();
                if (h1.Text != "0")
                {
                    h1.Style.Add("color", "black");
                    h1.NavigateUrl = "frmDLOApplicationsComm.aspx?Stg=0&DistId=0";
                    e.Row.Cells[2].Controls.Add(h1);
                }
                HyperLink h2 = new HyperLink();
                h2.Text = DLOPendingWithin.ToString();
                if (h2.Text != "0")
                {
                    h2.Style.Add("color", "black");
                    h2.NavigateUrl = "frmDLOApplicationsComm.aspx?Stg=1&DistId=0";
                    e.Row.Cells[3].Controls.Add(h2);
                }
                HyperLink h3 = new HyperLink();
                h3.Text = InspectionPendingWithin.ToString();
                if (h3.Text != "0")
                {
                    h3.Style.Add("color", "black");
                    h3.NavigateUrl = "frmDLOApplicationsComm.aspx?Stg=2&DistId=0";
                    e.Row.Cells[4].Controls.Add(h3);
                }

               /* HyperLink h4 = new HyperLink();
                h4.Text = ReInspectionPending.ToString();
                if (h4.Text != "0")
                {
                    h4.Style.Add("color", "black");
                    h4.NavigateUrl = "frmDLOApplicationsComm.aspx?Stg=1&DistId=0";
                    e.Row.Cells[5].Controls.Add(h4);
                }*/
            }
        }
    }
}