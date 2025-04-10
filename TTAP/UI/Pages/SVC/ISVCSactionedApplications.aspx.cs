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

namespace TTAP.UI.Pages.SVC
{
    public partial class ISVCSactionedApplications : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("~/loginReg.aspx");
            }
            if (!IsPostBack)
            {
                getallapprovedSVCno();
                ddlApplicationMode.SelectedValue = "1";
                ddlApplicationMode.Enabled = false;

                if (Request.QueryString["Stg"].ToString() == "5")
                {
                    DropDownList1.SelectedValue = "1";
                    ddlworkingstatus.SelectedValue = "1";
                }
                else if (Request.QueryString["Stg"].ToString() == "6")
                {
                    DropDownList1.SelectedValue = "2";
                    ddlworkingstatus.SelectedValue = "1";
                }
                else if (Request.QueryString["Stg"].ToString() == "8")
                {
                    DropDownList1.SelectedValue = "0";
                    ddlworkingstatus.SelectedValue = "1";
                }
                else if (Request.QueryString["Stg"].ToString() == "7")
                {
                    DropDownList1.SelectedValue = "0";
                    ddlworkingstatus.SelectedValue = "3";
                }
                else if (Request.QueryString["Stg"].ToString() == "9")
                {
                    DropDownList1.SelectedValue = "0";
                    ddlworkingstatus.SelectedValue = "0";
                }

                Button2_Click(sender, e);
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

                //string lblMstIncentiveId = ((Label)gvdetailsnew.Rows[indexing].FindControl("Label3")).Text;
                //string lblCategory1 = ((Label)gvdetailsnew.Rows[indexing].FindControl("lblCategory1")).Text;
                string lblSubIncType = "0";//((Label)grdDetailsPavallavaddiSC.Rows[indexing].FindControl("lblSubIncType")).Text;

                string AllApplicationstatus = "";

                if (Request.QueryString["ALLAPPSTATUS"] != null && Request.QueryString["ALLAPPSTATUS"].ToString() == "ALL")
                {
                    AllApplicationstatus = "ALL";
                }
                Response.Redirect("ISVCAllApplicationsList.aspx?Cast=" + lblCategory1 + "&MstIncentiveId=" + lblMstIncentiveId + "&SubIncId=" + lblSubIncType +
                "&APPMODE=" + ddlApplicationMode.SelectedValue + "&APPSTATUS=" + ddlworkingstatus.SelectedValue + "&TIMELINES=" + DropDownList1.SelectedValue +
                "&DIPCNumber=" + ddlDIPCno.SelectedValue + "&ALLAPPSTATUS=" + AllApplicationstatus);
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }
        public void getallapprovedSVCno()
        {
            DataSet ds = new DataSet();
            string Distid = "";
            if (Session["DistrictId"] != null && Session["DistrictId"].ToString().Trim() != "")
            {
                Distid = Session["DistrictId"].ToString().Trim();
            }
            SqlParameter[] pp = new SqlParameter[] {

             new SqlParameter("@DISTCODE", SqlDbType.VarChar)
            };
            pp[0].Value = Distid;
            ds = ObjCAFClass.GenericFillDs("USP_GET_LIST_INCENTIVE_SL_SVCSanctionNO_I", pp);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlDIPCno.DataSource = ds.Tables[0];
                ddlDIPCno.DataValueField = "Meeting_No";
                ddlDIPCno.DataTextField = "Meeting_No";
                ddlDIPCno.DataBind();
                ListItem li = new ListItem();
                li.Value = "0";
                li.Text = "--ALL--";
                ddlDIPCno.Items.Insert(0, li);
            }
            else
            {
                ListItem li = new ListItem();
                li.Value = "0";
                li.Text = "--ALL--";
                ddlDIPCno.Items.Insert(0, li);
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string Distid = "";
            if (Session["DistrictId"] != null && Session["DistrictId"].ToString().Trim() != "")
            {
                Distid = Session["DistrictId"].ToString().Trim();
            }
            string AllApplicationstatus = "";

            if (Request.QueryString["ALLAPPSTATUS"] != null && Request.QueryString["ALLAPPSTATUS"].ToString() == "ALL")
            {
                AllApplicationstatus = "ALL";
                DropDownList1.SelectedValue = "0";
                ddlworkingstatus.SelectedValue = "0";
                ddlDIPCno.SelectedValue = "0";
            }

            SqlParameter[] pp = new SqlParameter[] {
             new SqlParameter("@APPMODE",SqlDbType.VarChar),
             new SqlParameter("@APPSTATUS", SqlDbType.VarChar),
             new SqlParameter("@slcno", SqlDbType.VarChar),
             new SqlParameter("@DISTCODE", SqlDbType.VarChar),
             new SqlParameter("@DIPCNumer", SqlDbType.VarChar),
             new SqlParameter("@AllApplication", SqlDbType.VarChar),
            };

            pp[0].Value = ddlApplicationMode.SelectedValue;
            pp[1].Value = ddlworkingstatus.SelectedValue;
            pp[2].Value = DropDownList1.SelectedValue;
            pp[3].Value = Distid;
            pp[4].Value = ddlDIPCno.SelectedValue;
            pp[5].Value = AllApplicationstatus;
            //ds = ObjCAFClass.GenericFillDs("USP_GET_LIST_INCENTIVEWISE_ABSTRACT_DIPC_DIPC_APPROVEDLIST", pp);
            ds = ObjCAFClass.GenericFillDs("USP_GET_ABSTRACT_SVC_APPROVED_I", pp);
            //ds = gen.getincentiveDIPClist(Session["DistrictID"].ToString().Trim());

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = ds.Tables[0];
                gvdetailsnew.DataBind();

            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            ddlApplicationMode.SelectedValue = "0";
            ddlworkingstatus.SelectedValue = "0";
            gvdetailsnew.DataSource = null;
            gvdetailsnew.DataBind();
        }

        protected void chkPartial_CheckedChanged(object sender, EventArgs e)
        {
            getallapprovedSVCno();
            Button2_Click(sender, e);
        }
    }
}