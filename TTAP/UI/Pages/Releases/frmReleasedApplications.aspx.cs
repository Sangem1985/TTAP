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
    public partial class frmReleasedApplications : System.Web.UI.Page
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
        
        protected void btnget_Click(object sender, EventArgs e)
        {
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
               new SqlParameter("@Stage",SqlDbType.VarChar)
           };

            pp[0].Value = ApplicationMode;
            pp[1].Value = Category;
            pp[2].Value = Stage;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_RELEASED_FIRST_INCENTIVE_LIST", pp);

            if (Dsnew != null && Dsnew.Tables.Count > 0 && Dsnew.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = Dsnew.Tables[0];
                gvdetailsnew.DataBind();
            }
            else
            {
                gvdetailsnew.DataSource = null;
                gvdetailsnew.DataBind();
            }
        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
    }
}