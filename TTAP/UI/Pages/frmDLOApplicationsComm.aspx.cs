﻿using System;
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
    public partial class frmDLOApplicationsComm : System.Web.UI.Page
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
                        
                        int Stg = 0; 
                        if (Request.QueryString["Stg"] != null)
                        {
                            Stg = Convert.ToInt32(Request.QueryString["Stg"].ToString());
                            hdnDistrictId.Value = Request.QueryString["DistId"].ToString();
                        }
                        if (Session["Search"] != null)
                        {
                            txtsearch.Text = Session["Search"].ToString();
                        }
                        lbtnback.PostBackUrl = "~/UI/Pages/frmDLODashboard.aspx";
                        BindApplicationData();
                        Session["Search"] = null;
                    }
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }

        public void BindApplicationData()
        {
            int Stg = 0;
            if (Request.QueryString["Stg"] != null)
            {
                Stg = Convert.ToInt32(Request.QueryString["Stg"].ToString());
            }

            dss = GetDLOApplications(Convert.ToInt32(hdnDistrictId.Value.ToString()), Stg, txtsearch.Text.Trim().TrimStart());
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = dss;
                gvdetailsnew.DataBind();
                string DistName = dss.Tables[0].Rows[0]["District_Name"].ToString();
                if (hdnDistrictId.Value == "0") { DistName = "All Distrcits"; }
                if (Stg == 0)
                {
                    gvdetailsnew.Columns[11].Visible = false;
                    gvdetailsnew.Columns[12].Visible = false;
                    Header.InnerText = "Total Incentives DLO Received - " + DistName;
                }
                if (Stg == 1)
                {
                    gvdetailsnew.Columns[11].Visible = false;
                    gvdetailsnew.Columns[12].Visible = false;
                    Header.InnerText = "Incentives not acted upon within 7 days of receipt of application - " + DistName;
                }
                if (Stg == 2)
                {
                    gvdetailsnew.Columns[9].Visible = false;
                    gvdetailsnew.Columns[10].Visible = false;
                    Header.InnerText = "Incentives not acted upon within 7 days of Inspection Scheduled - " + DistName;
                }
            }
            else
            {
                gvdetailsnew.DataSource = dss;
                gvdetailsnew.DataBind();
            }
        }
        public DataSet GetDLOApplications(int DistId, int StageId, string UnitName)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DistrictId",SqlDbType.Int),
               new SqlParameter("@StageId",SqlDbType.Int),
               new SqlParameter("@UnitName",SqlDbType.VarChar)
           };
            pp[0].Value = DistId;
            pp[1].Value = StageId;
            pp[2].Value = UnitName;

            Dsnew = caf.GenericFillDs("USP_GET_DLOAPPLICATIONS_DTLS_COMM", pp);

            return Dsnew;
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            Button ddlDeptnameFnl2 = (Button)sender;
            GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
            Label lblIncentiveID = (Label)row.FindControl("lblIncentiveID");
            Button Button1 = (Button)row.FindControl("btnProcess");

            int Stg = 0;
            if (Request.QueryString["Stg"] != null)
            {
                Stg = Convert.ToInt32(Request.QueryString["Stg"].ToString());
            }
            if (txtsearch.Text.Trim().TrimStart() != "")
            {
                Session["Search"] = txtsearch.Text.Trim().TrimStart();
            }
            string newurl = "~/UI/frmDLOApplicationDetailsNew.aspx?Id=" + lblIncentiveID.Text.Trim() + "&Sts=" + Stg;
            Response.Redirect(newurl);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindApplicationData();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtsearch.Text = "";
            BindApplicationData();
        }
    }
}