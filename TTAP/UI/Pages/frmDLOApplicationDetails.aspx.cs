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

namespace TTAP.UI.Pages
{
    public partial class frmDLOApplicationDetails : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {
                        if (Request.QueryString["Id"] != null)
                        {
                            BindSubIncentives();
                            BindQueries();
                            BindInspections();
                        }
                       
                       
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BindSubIncentives()
        {
            dss = GetSubIncentivesById(Convert.ToInt32(Request.QueryString["Id"].ToString()), Convert.ToInt32(Request.QueryString["sts"].ToString()));
            if (dss.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
                {
                    grdIncentives.DataSource = dss;
                    grdIncentives.DataBind();
                }
            }
        }
        public void BindQueries()
        {
            dss = GetQueriesById(Convert.ToInt32(Request.QueryString["Id"].ToString()));
            if (dss.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
                {
                    grdQueries.DataSource = dss;
                    grdQueries.DataBind();
                }
            }
        }
        public void BindInspections()
        {
            dss = GetInspectionsById(Convert.ToInt32(Request.QueryString["Id"].ToString()));
            if (dss.Tables.Count > 0)
            {
                if (dss.Tables[0].Rows.Count > 0)
                {
                    grdInspections.DataSource = dss;
                    grdInspections.DataBind();
                }
            }
        }

        public DataSet GetQueriesById(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
           };
            pp[0].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_QUERIES", pp);
            return Dsnew;
        }
        public DataSet GetSubIncentivesById(int IncentiveId,int status)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@Status",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = status;
            Dsnew = caf.GenericFillDs("USP_GET_SUBINCENTIVEDETAILS", pp);
            return Dsnew;
        }

        public DataSet GetInspectionsById(int IncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
           };
            pp[0].Value = IncentiveId;
            Dsnew = caf.GenericFillDs("USP_GET_INSPECTIONS", pp);
            return Dsnew;
        }

        protected void ddlAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList lb = (DropDownList)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            TextBox txtRemarks = (TextBox)gvRow.FindControl("txtQuery");
            TextBox txtInsDate = (TextBox)gvRow.FindControl("txtDateofInspection");
            string a = lb.SelectedValue.ToString();

            if(a=="1")
            {
                txtRemarks.Visible = true;
                txtInsDate.Visible = false;
            }
            else if(a=="2")
            {
                txtRemarks.Visible = false;
                txtInsDate.Visible = true;
            }
            else
            {
                txtRemarks.Visible = false;
                txtInsDate.Visible = false;

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Button ddlDeptnameFnl2 = (Button)sender;
            GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
            DropDownList ddl1 = (DropDownList)row.FindControl("ddlAction");
            TextBox txtRemarks = (TextBox)row.FindControl("txtQuery");
            TextBox txtInspectionDate = (TextBox)row.FindControl("txtDateofInspection");
            Label lblIncentiveID = (Label)row.FindControl("lblSubIncentiveId");
            Button Button1 = (Button)row.FindControl("btnSubmit");
            //string status = Request.QueryString["Stg"].ToString().Trim();
            if(ddl1.SelectedValue=="1")
            {
                SendQuery(Convert.ToInt32(Request.QueryString["Id"].ToString()), Convert.ToInt32(lblIncentiveID.Text), txtRemarks.Text);
            }
            else if(ddl1.SelectedValue == "2")
            {
                ScheduleInspection(Convert.ToInt32(Request.QueryString["Id"].ToString()), Convert.ToInt32(lblIncentiveID.Text), txtInspectionDate.Text);
            }
          
        }
        public void SendQuery(int IncentiveId,int SubIncentiveId,string Query)
        {

            try
            {
                int result = caf.InsertOfficerQuery(IncentiveId, SubIncentiveId,Convert.ToInt32(Session["uid"]),Query);
                if (result > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Query Sent Successfully');", true);

                    BindSubIncentives();
                    BindQueries();

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }
        public void ScheduleInspection(int IncentiveId, int SubIncentiveId, string InspectionDate)
        {
            try
            {
                int result = caf.ScheduleInspection(IncentiveId, SubIncentiveId, Convert.ToInt32(Session["uid"]), InspectionDate);
                if (result > 0)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Inspection Scheduled Successfully');", true);

                    BindInspections();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}