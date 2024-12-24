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

namespace TTAP.UI.Pages
{
    public partial class FormWorkingStatusUpdate : System.Web.UI.Page
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
                if (Request.QueryString["IncentiveId"] != null)
                {
                    if (Request.QueryString["SubIncentiveId"] != null && Request.QueryString["Type"] != null)
                    {
                        if (Request.QueryString["Type"].ToString() == "S")
                        {
                            cmf.BindCtlto(true, ddlBank, objFetch.FetchBankMst(), 1, 0, false);
                            BindBankAccountType();
                            txtApplication.Text = Request.QueryString["Application"].ToString();
                            txtIncentive.Text = Request.QueryString["Incentive"].ToString();
                            divGridDtls.Visible = false;
                            divUpdateBank.Visible = false;
                            divUpdate.Visible = true;
                        }
                        else
                        {
                            cmf.BindCtlto(true, ddlBank, objFetch.FetchBankMst(), 1, 0, false);
                            BindBankAccountType();
                            txtApplication.Text = Request.QueryString["Application"].ToString();
                            txtIncentive.Text = Request.QueryString["Incentive"].ToString();
                            ViewBankDetails(Request.QueryString["IncentiveId"].ToString(), Request.QueryString["SubIncentiveId"].ToString());
                            divGridDtls.Visible = false;
                            divUpdateBank.Visible = false;
                            divUpdate.Visible = true;
                            EnableDisableForm(divUpdate.Controls, false);
                            btnSave.Visible = false;
                        }
                    }
                    else
                    {
                        ds = GetApplicantWorkingStatus(Request.QueryString["IncentiveId"].ToString());
                        try
                        {
                            if (ds != null && ds.Tables.Count > 0)
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    gvGridDtls.DataSource = ds.Tables[0];
                                    gvGridDtls.DataBind();
                                    divGridDtls.Visible = true;
                                }
                                if (ds.Tables[1].Rows.Count > 0)
                                {
                                    gvBank.DataSource = ds.Tables[1];
                                    gvBank.DataBind();
                                    divUpdateBank.Visible = true;
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
            }

        }
        public void EnableDisableForm(ControlCollection ctrls, bool status)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Enabled = status;
                else if (ctrl is DropDownList)
                    ((DropDownList)ctrl).Enabled = status;
                else if (ctrl is CheckBox)
                    ((CheckBox)ctrl).Enabled = status;
                else if (ctrl is RadioButton)
                    ((RadioButton)ctrl).Enabled = status;
                else if (ctrl is RadioButtonList)
                    ((RadioButtonList)ctrl).Enabled = status;
                else if (ctrl is CheckBoxList)
                    ((CheckBoxList)ctrl).Enabled = status;

                EnableDisableForm(ctrl.Controls, status);

            }
        }
        public DataSet GetApplicantWorkingStatus(string IncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveID",SqlDbType.VarChar)

           };
            pp[0].Value = IncentiveId;

            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_APPLICANT_INCENTIVES_WORKING_STATUS", pp);
            return Dsnew;
        }
        public DataSet GetBankAccountDetails(string IncentiveId, string SubIncentiveId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveID",SqlDbType.VarChar),
               new SqlParameter("@SubIncentiveID",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = SubIncentiveId;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_UNITS_NEW_BANK_DETAILS", pp);
            return Dsnew;
        }
        public void BindBankAccountType()
        {
            DataSet ds = new DataSet();
            ds = Objgeneral.getBankAccountTypeMaster();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddlAccountType.DataSource = ds.Tables[0];
                ddlAccountType.DataTextField = "AccountTypeName";
                ddlAccountType.DataValueField = "AccountTypeID";
                ddlAccountType.DataBind();
            }
        }
        public void ViewBankDetails(string IncentiveId,string SubIncentiveId)
        {
            DataSet DsView = new DataSet();
            DsView = GetBankAccountDetails(IncentiveId, SubIncentiveId);
            if (DsView != null && DsView.Tables.Count > 0)
            {
                txtAccNumber.Text = DsView.Tables[0].Rows[0]["AccNo"].ToString();
                ddlBank.SelectedValue= DsView.Tables[0].Rows[0]["BankId"].ToString();
                txtBranchName.Text= DsView.Tables[0].Rows[0]["BranchName"].ToString();
                ddlAccountType.SelectedValue = DsView.Tables[0].Rows[0]["BankAccType"].ToString();
                txtIfscCode.Text = DsView.Tables[0].Rows[0]["IFSCCode"].ToString();
                txtaccountauthorizedPerson.Text = DsView.Tables[0].Rows[0]["AccountauthorizedPerson"].ToString();
                txtaccountauthorizedPersonDesignation.Text = DsView.Tables[0].Rows[0]["Designation"].ToString();
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            Button btnclick = (Button)sender;
            GridViewRow row = (GridViewRow)btnclick.NamingContainer;
            Label lblIncentiveID = (Label)row.FindControl("lblIncentiveID");
            Label lblSubIncentiveID = (Label)row.FindControl("lblSubIncentiveID");
            TextBox txtResponse = (TextBox)row.FindControl("txtResponse");
            string Response = txtResponse.Text;
            Button btnProcess = (Button)row.FindControl("btnProcess");
            if (Response == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter Response')", true);
                return;
            }
            string Status = ObjCAFClass.UpdateWorkingStatus(lblIncentiveID.Text, lblSubIncentiveID.Text, "", "", Response, "UNIT", "");
            if (Status != "0" || Status != null || Status != "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Response Submitted')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed to Submit')", true);
            }
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
            if (lblBankDetailsUpdStatus.Text == "Y")
            {   
                Response.Redirect("~/UI/Pages/FormWorkingStatusUpdate.aspx?IncentiveId=" + lblIncentiveID.Text.Trim() + "&SubIncentiveId=" + lblSubIncentiveID.Text.Trim() + "&Application=" + lblApplication.Text + "&Incentive=" + lblIncentive.Text + "&Type=V");
            }
            else
            {
                Response.Redirect("~/UI/Pages/FormWorkingStatusUpdate.aspx?IncentiveId=" + lblIncentiveID.Text.Trim() + "&SubIncentiveId=" + lblSubIncentiveID.Text.Trim() + "&Application=" + lblApplication.Text + "&Incentive=" + lblIncentive.Text + "&Type=S");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            int IncentiveId = Convert.ToInt32(Request.QueryString["IncentiveId"].ToString());
            int SubIncentiveId = Convert.ToInt32(Request.QueryString["SubIncentiveId"].ToString());
            int BankId = Convert.ToInt32(ddlBank.SelectedValue.ToString());
            string Branch = txtBranchName.Text;
            string AccType = ddlAccountType.SelectedValue.ToString();
            string AccNo = txtAccNumber.Text.ToString();
            string IFSC = txtIfscCode.Text.ToString();
            string AuthPerson = txtaccountauthorizedPerson.Text.ToString();
            string Designation = txtaccountauthorizedPersonDesignation.Text.ToString();
            int CreateBy = Convert.ToInt32(hdnUnitId.Value);
            if (BankId == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Bank')", true);
                return;
            }
            if (Branch == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter Branch Name')", true);
                return;
            }
            if (AccType == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Account Type')", true);
                return;
            }
            if (AccNo == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter Account Number')", true);
                return;
            }
            if (IFSC == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter IFSC Code')", true);
                return;
            }
            if (AuthPerson == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter Authorised Person Name')", true);
                return;
            }
            if (Designation == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter Authorised Person's Designation')", true);
                return;
            }
            string Status = ObjCAFClass.InsertNewBankDetails(IncentiveId, SubIncentiveId, BankId, Branch, AccType, AccNo, IFSC, AuthPerson,
                Designation, CreateBy);
            if (Status == "0" || Status == null || Status == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed to Save')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Details Saved Succesfully')", true);
                btnSave.Visible = false;
                EnableDisableForm(divUpdate.Controls, false);
            }
        }

        protected void gvBank_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblBankDetailsUpdStatus = (e.Row.FindControl("lblBankDetailsUpdStatus") as Label);
                Button btnUpdate = (e.Row.FindControl("btnUpdate") as Button);
                if (lblBankDetailsUpdStatus.Text == "Y")
                {
                    btnUpdate.Text = "View Saved Details";
                }
            }
        }
    }
}