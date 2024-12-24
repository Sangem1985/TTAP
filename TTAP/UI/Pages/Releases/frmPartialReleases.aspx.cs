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

namespace TTAP.UI.Pages.Releases
{
    public partial class frmPartialReleases : System.Web.UI.Page
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
                string ApplicationLevel = "", Stage = "";

                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString["ApplicationLevel"] != null)
                    {
                        ApplicationLevel = Request.QueryString["ApplicationLevel"].ToString();
                        if (ApplicationLevel.ToUpper() == "SLC")
                        {
                            ddlApplicationMode.SelectedValue = "1";
                        }
                        else if (ApplicationLevel.ToUpper() == "DLC")
                        {
                            ddlApplicationMode.SelectedValue = "2";
                        }
                        else
                        {
                            ddlApplicationMode.SelectedValue = "0";
                        }
                    }
                    if (Request.QueryString["Stage"] != null)
                    {
                        Stage = Request.QueryString["Stage"].ToString();
                    }
                }

                ddlApplicationMode_SelectedIndexChanged(sender, e);

                DataSet dsgos = new DataSet();
                dsgos = GetFundGos();
                ViewState["dsgos"] = dsgos;

                btnget_Click(sender, e);
            }
        }

        public void BindApprovedIncentives(string ApplicationLevel, string Stage)
        {
            try
            {
                DataSet ApprovedIncentives = new DataSet();
                ddlIncentives.Items.Clear();
                ApprovedIncentives = GetApprovedIncentives(ApplicationLevel, Stage);
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
        public DataSet GetApprovedIncentives(string ApplicationLevel, string Stage)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@ApplicationLevel",SqlDbType.VarChar),
               new SqlParameter("@Stage",SqlDbType.VarChar)
           };
            pp[0].Value = ApplicationLevel;
            pp[1].Value = Stage;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_APPROVED_INCENTIVES", pp);
            return Dsnew;
        }
        public void AddSelect(DropDownList ddl)
        {
            try
            {
                ListItem li = new ListItem();
                li.Text = "--All--";
                li.Value = "0";
                ddl.Items.Insert(0, li);
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }
        }
        public void AddSelectNew(DropDownList ddl)
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
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
            }
        }

        protected void ddlApplicationMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Stage = "";

            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["Stage"] != null)
                {
                    Stage = Request.QueryString["Stage"].ToString();
                }
            }

            BindApprovedIncentives(ddlApplicationMode.SelectedValue, Stage);
        }

        protected void gvdetailsnew_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSubIncentiveID = (e.Row.FindControl("lblSubIncentiveID") as Label);
                Button btnGenerate = (e.Row.FindControl("btnGenerate") as Button);
                DropDownList ddlgos = (e.Row.FindControl("ddlgos") as DropDownList);

                if (lblSubIncentiveID.Text == "")
                {
                    btnGenerate.Visible = false;
                    ddlgos.Visible = false;
                }

                DataSet ds = new DataSet();
                ds = (DataSet)ViewState["dsgos"];

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ddlgos.DataSource = ds.Tables[0];
                    ddlgos.DataValueField = "GOID";
                    ddlgos.DataTextField = "GONodate";
                    ddlgos.DataBind();
                    AddSelectNew(ddlgos);
                }
            }
        }
        public DataSet GetFundGos()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_GO_Fund_Dtls");
            return Dsnew;
        }
        protected void btnget_Click(object sender, EventArgs e)
        {
            gvdetailsnew.DataSource = null;
            gvdetailsnew.DataBind();
            DataSet Dsnew = new DataSet();

            string ApplicationMode = ddlApplicationMode.SelectedValue;
            string Category = ddlCategory.SelectedValue;
            string Incentives = ddlIncentives.SelectedValue;
            string Stage = "";

            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["Stage"] != null)
                {
                    Stage = Request.QueryString["Stage"].ToString();
                }
            }

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@ApplicationLevel",SqlDbType.VarChar),
               new SqlParameter("@Category",SqlDbType.VarChar),
               new SqlParameter("@Incentives",SqlDbType.VarChar),
               new SqlParameter("@Stage",SqlDbType.VarChar)
           };

            pp[0].Value = ApplicationMode;
            pp[1].Value = Category;
            pp[2].Value = Incentives;
            pp[3].Value = Stage;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_RELEASE_ABSTRACT", pp);

            if (Dsnew != null && Dsnew.Tables.Count > 0 && Dsnew.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = Dsnew.Tables[0];
                gvdetailsnew.DataBind();
            }
        }

        protected void ddlgos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            DropDownList ddlgos = ((DropDownList)gvdetailsnew.Rows[indexing].FindControl("ddlgos"));
            Label lblbalanceamt = ((Label)gvdetailsnew.Rows[indexing].FindControl("lblbalanceamt"));
            Label lblRecommendedAmount = ((Label)gvdetailsnew.Rows[indexing].FindControl("lblPendingReleaseAmount"));

            Button btnGenerate = ((Button)gvdetailsnew.Rows[indexing].FindControl("btnGenerate") as Button);

            if (ddlgos.SelectedValue != "0")
            {
                DataSet ds = new DataSet();
                ds = (DataSet)ViewState["dsgos"];
                DataRow[] drs = ds.Tables[0].Select("GOID = " + ddlgos.SelectedValue);
                if (drs.Length > 0)
                {
                    string AmountReleased = drs[0]["AmountReleased"].ToString();
                    string BalanceAmont = drs[0]["BalanceAmont"].ToString();

                    lblbalanceamt.Text = ("Total Amount : Rs." + AmountReleased + "<br> Balance Amount : Rs." + BalanceAmont).ToString().Replace(Environment.NewLine, "<br>");
                    if (Convert.ToDecimal(BalanceAmont) < Convert.ToDecimal(lblRecommendedAmount.Text.Trim()))
                    {
                        btnGenerate.Enabled = false;
                    }
                    else
                    {
                        btnGenerate.Enabled = true;
                    }
                }
            }
        }
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
            /*DropDownList ddlgos = ((DropDownList)gvdetailsnew.Rows[indexing].FindControl("ddlgos"));*/
            Label lblSubIncentiveID = ((Label)gvdetailsnew.Rows[indexing].FindControl("lblSubIncentiveID"));
            Label lblCategoryid = ((Label)gvdetailsnew.Rows[indexing].FindControl("lblCategoryid"));
            
            string Stage = "4";
            string ApplicationMode = ddlApplicationMode.SelectedValue;
            string Category = lblCategoryid.Text;
            string SubIncentiveID = lblSubIncentiveID.Text;
            string GOID = "";

            Response.Redirect("frmPartialReleasesList.aspx?Stage=" + Stage + "&ApplicationMode=" + ApplicationMode +
                "&Category=" + Category + "&GOID=" + GOID + "&SubIncentiveID=" + SubIncentiveID);

            //Response.Redirect("Test.aspx");
        }
    }
}