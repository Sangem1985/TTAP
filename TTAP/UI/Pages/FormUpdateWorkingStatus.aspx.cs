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
using System.IO;

namespace TTAP.UI.Pages
{
    public partial class FormUpdateWorkingStatus : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
            if (Session["ObjLoginvo"] == null)
            {
                Response.Redirect("~/LoginReg.aspx");
            }
            ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];
            hdndist.Value = ObjLoginvo.DistrictID;
            hdnUserId.Value = ObjLoginvo.uid.ToString();
            if (!IsPostBack)
            {   
                GetData();
            }
        }
        public void GetData()
        {
            DataSet ds = new DataSet();
            string IsPartial = "N";

            SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@DistId",SqlDbType.VarChar),
                new SqlParameter("@PartialSanction", SqlDbType.VarChar)
            };

            pp[0].Value = hdndist.Value;
            pp[1].Value = IsPartial;
            ds = ObjCAFClass.GenericFillDs("USP_GET_GET_SANTIONED_INCENTIVES_FOR_WORKINGSTATUS", pp);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = ds.Tables[0];
                gvdetailsnew.DataBind();
                divNoData.Visible = false;

            }
            else
            {
                gvdetailsnew.DataSource = null;
                gvdetailsnew.DataBind();
                divNoData.Visible = true;
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            string IsPartial = "N";
            Button btnclick = (Button)sender;
            GridViewRow row = (GridViewRow)btnclick.NamingContainer;
            Label lblIncentiveID = (Label)row.FindControl("lblIncentiveID");
            Label lblSubIncentiveID = (Label)row.FindControl("lblSubIncentiveID");
            Label lblTISId = (Label)row.FindControl("lblTISId");
            Label lblIsPartial = (Label)row.FindControl("lblIsPartial");
            TextBox txtremarks = (TextBox)row.FindControl("txtremarks");
            string Remarks = txtremarks.Text;
            string UpdType = "DLO";
            RadioButtonList rbtnStatus = (RadioButtonList)row.FindControl("rbtnStatus");
            Button btnProcess = (Button)row.FindControl("btnProcess");
            string WorkingStatus = rbtnStatus.SelectedValue.ToString();
            if (Remarks == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter remarks');", true);
                return;
            }
            string Status = ObjCAFClass.UpdateWorkingStatus(lblIncentiveID.Text, lblSubIncentiveID.Text, WorkingStatus, lblTISId.Text, Remarks, UpdType, hdnUserId.Value.ToString());

            if (Status != "0" || Status != null || Status != "")
            {
                string TransactionId = "";
                if (WorkingStatus == "Y") { TransactionId = "17"; } else { TransactionId = "18"; }
                string msg = ""; string SubModule = "WORKINGSTATUS"; 
                try
                {
                    ClsSMSandMail ClsSMSandMailobj = new ClsSMSandMail();
                    msg = ClsSMSandMailobj.SendSmsWebService(lblIncentiveID.Text, lblSubIncentiveID.Text, "Incentives", TransactionId, SubModule);
                }
                catch (Exception ex)
                {
                    string errorMsg = ex.Message;
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Unit Working status Updated');", true);
                btnProcess.Enabled = false;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed to Update');", true);
            }
        }
    }
}