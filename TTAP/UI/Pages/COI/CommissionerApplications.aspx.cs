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


namespace TTAP.UI.Pages.COI
{
    public partial class CommissionerApplications : System.Web.UI.Page
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
                        lbtnback.PostBackUrl = "~/UI/Pages/frmDLODashboard.aspx";
                        BindApplicationData();
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
            string Stg = "";
            if (Request.QueryString["Stg"] != null)
            {
                Stg = Request.QueryString["Stg"].ToString();
            }
            dss = GetApplications(Stg, Session["uid"].ToString());
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = dss;
                gvdetailsnew.DataBind();
            }
            else
            {
                gvdetailsnew.DataSource = dss;
                gvdetailsnew.DataBind();
            }
            if (Stg == "A") 
            {
                gvdetailsnew.Columns[9].Visible = false;
                gvdetailsnew.Columns[10].Visible = false;
                gvdetailsnew.Columns[11].Visible = false;
                gvdetailsnew.Columns[12].Visible = true;
                gvdetailsnew.Columns[13].Visible = false;
            }
            if (Stg == "R")
            {
                gvdetailsnew.Columns[9].Visible = false;
                gvdetailsnew.Columns[10].Visible = false;
                gvdetailsnew.Columns[11].Visible = false;
                gvdetailsnew.Columns[12].Visible = false;
                gvdetailsnew.Columns[13].Visible = true;
            }
        }
        public DataSet GetApplications(string StageId, string UserId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@Stage",SqlDbType.VarChar),
               new SqlParameter("@UserId",SqlDbType.VarChar)
           };
            pp[0].Value = StageId;
            pp[1].Value = UserId;

            Dsnew = caf.GenericFillDs("USP_GET_CM_APPLICATIONS", pp);

            return Dsnew;
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationStatus ObjApplicationStatus = new ApplicationStatus();
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                Button Gv = (Button)sender;
                GridViewRow row = (GridViewRow)Gv.NamingContainer;
                Label lblIncentiveID = (Label)row.FindControl("lblIncentiveID");
                Label lblSubIncentiveID = (Label)row.FindControl("lblSubIncentiveID");
                TextBox txtRemarks = (TextBox)row.FindControl("txtRemarks");
                RadioButtonList rdbVerify = (RadioButtonList)row.FindControl("rdbVerify");
                string ActionType = rdbVerify.SelectedValue.ToString();

                ObjApplicationStatus.IncentiveId = lblIncentiveID.Text.ToString();
                ObjApplicationStatus.SubIncentiveId = lblSubIncentiveID.Text.ToString();
                ObjApplicationStatus.CreatedBy = ObjLoginNewvo.uid;
                ObjApplicationStatus.TransType = ActionType;
                ObjApplicationStatus.Remarks = txtRemarks.Text.ToString();

                if (ObjApplicationStatus.TransType == "" || ObjApplicationStatus.TransType == "0" || ObjApplicationStatus.TransType == null)
                {
                    string info = "Please select Verification Type";
                    string message = "alert('" + info + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string Status = caf.CommissionerAction(ObjApplicationStatus);
                if (Convert.ToInt32(Status) > 0)
                {
                    string Successmsg = "";
                    if (ActionType == "1") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Application Approved');", true); }
                    if (ActionType == "2") { ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Application Returned');", true); }
                    BindApplicationData();
                    return;

                }
                else
                {
                    string msg = "Action Failed";
                    string message = "alert('" + msg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
    }
}