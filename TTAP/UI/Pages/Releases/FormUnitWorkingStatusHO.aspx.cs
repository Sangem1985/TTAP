using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TTAP.Classfiles;
using BusinessLogic;
using System.Data.SqlClient;

namespace TTAP.UI.Pages.Releases
{
    public partial class FormUnitWorkingStatusHO : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        Fetch objFetch = new Fetch();
        General Objgeneral = new General();
        comFunctions cmf = new comFunctions();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (Session["uid"] == null)
            {
                Response.Redirect("~/loginReg.aspx");
            }
            else
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                if (hdnUnitId.Value == "")
                {
                    hdnUnitId.Value = ObjLoginNewvo.uid;
                }
            }
            if (!IsPostBack)
            {
                ds = GetWorkingStatusData(Request.QueryString["Flag"].ToString());
                try
                {
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        if (Request.QueryString["Flag"].ToString() == "DLO")
                        {
                            gvDLO.DataSource = ds.Tables[0];
                            gvDLO.DataBind();
                            divDLO.Visible = true;
                        }
                        else
                        {
                            gvUnit.DataSource = ds.Tables[0];
                            gvUnit.DataBind();
                            divUnit.Visible = true;
                        }
                        
                    }
                    else
                    {

                    }
                }
                catch (Exception ex)
                {
                    string errorMsg = ex.Message;
                }
            }
        }
        public DataSet GetWorkingStatusData(string Flag)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@Flag",SqlDbType.VarChar)

           };
            pp[0].Value = Flag;

            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_DLO_UPDATED_UNIT_WORKING_STATUS", pp);
            return Dsnew;
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Button btnUpdate = (Button)sender;
            GridViewRow row = (GridViewRow)btnUpdate.NamingContainer;
            Label lblIncentiveID = (Label)row.FindControl("lblIncentiveID");
            Label lblSubIncentiveID = (Label)row.FindControl("lblSubIncentiveID");
            Label lblApplication = (Label)row.FindControl("lblApplication");
            Label lblIncentive = (Label)row.FindControl("lblIncentive");
            Label lblBankDetailsUpdStatus = (Label)row.FindControl("lblBankDetailsUpdStatus");
            Response.Redirect("~/UI/Pages/FormWorkingStatusUpdate.aspx?IncentiveId=" + lblIncentiveID.Text.Trim() + "&SubIncentiveId=" + lblSubIncentiveID.Text.Trim() + "&Application=" + lblApplication.Text + "&Incentive=" + lblIncentive.Text + "&Type=V");
        }
        protected void gvBank_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblBankDetailsUpdStatus = (e.Row.FindControl("lblBankDetailsUpdStatus") as Label);
                Button btnView = (e.Row.FindControl("btnView") as Button);
                if (lblBankDetailsUpdStatus.Text == "Y")
                {
                    btnView.Text = "View Saved Details";
                }
                else
                {
                    btnView.Visible = false;
                }
            }
        }
    }
}