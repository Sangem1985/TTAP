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

namespace TTAP.UI.Pages.SVC
{
    public partial class frmSVCGeneratedAgendaAbstract : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["ObjLoginvo"] != null && Request.QueryString.Count > 0)
                    {
                        GetSvcDates();
                    }
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
        public void GetSvcDates()
        {
            int DistId = 0;
            DataSet ds = new DataSet();
            string status = Request.QueryString["Stage"].ToString().Trim();
            DistId = Convert.ToInt32(Session["DistrictId"].ToString());
            string TransType = Request.QueryString["TransType"].ToString().Trim();
            string PartialSanction = "N";
            if (chkPartial.Checked == true)
            {
                PartialSanction = "Y";
            }

            ds = ObjCAFClass.GetSVCGenerateDAgendaProposedDates(DistId.ToString().Trim(), status, TransType, PartialSanction);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlProposedDLCs.DataSource = ds.Tables[0];
                ddlProposedDLCs.DataValueField = "ProposedDLCDATEVALUE";
                ddlProposedDLCs.DataTextField = "ProposedDLCDATE";
                ddlProposedDLCs.DataBind();

                GetAbstract(DistId.ToString(), status, ddlProposedDLCs.SelectedValue, TransType);
            }
            else
            {
                ddlProposedDLCs.DataSource = ds.Tables[0];
                ddlProposedDLCs.DataValueField = "ProposedDLCDATEVALUE";
                ddlProposedDLCs.DataTextField = "ProposedDLCDATE";
                ddlProposedDLCs.DataBind();
                gvdetailsnew.DataSource = ds.Tables[0];
                gvdetailsnew.DataBind();
            }
        }
        public void GetAbstract(string DistId, string status, string Date, string TransType)
        {
            DataSet ds = new DataSet();
            string PartialSanction = "N";
            if (chkPartial.Checked == true)
            {
                PartialSanction = "Y";
            }
            ds = ObjCAFClass.GetSVCGeneratedAgenda(DistId.ToString(), status, Date, TransType, PartialSanction);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = ds.Tables[0];
                gvdetailsnew.DataBind();
            }
        }
        protected void gvdetailsnew_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSubIncentiveID = (e.Row.FindControl("lblSubIncentiveID") as Label);
                Button btnGenerate = (e.Row.FindControl("btnGenerate") as Button);
                if (lblSubIncentiveID.Text == "")
                {
                    btnGenerate.Visible = false;
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
                string lblMstIncentiveId = ((Label)gvdetailsnew.Rows[indexing].FindControl("lblSubIncentiveID")).Text;
                string lblCategory1 = ((Label)gvdetailsnew.Rows[indexing].FindControl("lblCategoryid")).Text;
                string Status = Request.QueryString["Stage"].ToString();
                string TransType = Request.QueryString["TransType"].ToString().Trim();
                string PartialSanction = "N";
                if (chkPartial.Checked == true)
                {
                    PartialSanction = "Y";
                }
                if (TransType == "PRINTAGENDA")
                {
                    Response.Redirect("frmSVCGeneratedAgendaPrint.aspx?Cast=" + lblCategory1 + "&SubIncentiveID=" + lblMstIncentiveId + "&ProposedDLCDate=" + ddlProposedDLCs.SelectedItem.Text + "&Status=" + Status + "&TransType=" + TransType + "&PartialSanction=" + PartialSanction);
                }
                else if (TransType == "AGENDAUPDATE")
                {
                    Response.Redirect("frmSVCGeneratedAgendaUpdate.aspx?Cast=" + lblCategory1 + "&SubIncentiveID=" + lblMstIncentiveId + "&ProposedDLCDate=" + ddlProposedDLCs.SelectedItem.Text + "&Status=" + Status + "&TransType=" + TransType + "&PartialSanction=" + PartialSanction);
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }

        protected void btnGetDLClist_Click(object sender, EventArgs e)
        {
            int DistId = 0;
            DataSet ds = new DataSet();
            string status = Request.QueryString["Stage"].ToString().Trim();
            DistId = Convert.ToInt32(Session["DistrictId"].ToString());
            string TransType = Request.QueryString["TransType"].ToString().Trim();
            GetAbstract(DistId.ToString(), status, ddlProposedDLCs.SelectedValue, TransType);
        }
        protected void chkPartial_CheckedChanged(object sender, EventArgs e)
        {
            GetSvcDates();
        }
    }
}