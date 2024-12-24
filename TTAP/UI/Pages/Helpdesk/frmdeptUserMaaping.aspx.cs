using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using TTAP.Classfiles;

namespace TTAP.UI
{
    public partial class frmdeptUserMaaping : System.Web.UI.Page
    {
        CAFClass Objret = new CAFClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session.Count <= 0)
                {
                    Response.Redirect("~/LoginReg.aspx");
                }

                UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
                ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

                if (!IsPostBack)
                {
                    BindApplicationDetails();
                    BindDeptUsers();
                    BindModuleDtls(ddlApplication.SelectedValue, ddlModule.SelectedValue,ddlSubModule.SelectedValue,ddlUsers.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                // Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                string UID = "0";
                if (Session["uid"] != null)
                {
                    UID = Session["uid"].ToString();
                }
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, UID);
            }
        }
        public void AddSelect(DropDownList ddl)
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
                //lblmsg0.Text = ex.Message;
                //Failure.Visible = true;
                //success.Visible = false;
            }
        }
        private void BindApplicationDetails()
        {
            try
            {
                DataSet dsYears = new DataSet();
                ddlApplication.Items.Clear();
                dsYears = Objret.GenericFillDs("USP_GET_Application_MST");
                if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
                {
                    ddlApplication.DataSource = dsYears.Tables[0];
                    ddlApplication.DataTextField = "Application_Name";
                    ddlApplication.DataValueField = "ApplicationId";
                    ddlApplication.DataBind();
                }
                AddSelect(ddlApplication);
            }
            catch (Exception ex)
            {
                // Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                string UID = "0";
                if (Session["uid"] != null)
                {
                    UID = Session["uid"].ToString();
                }
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, UID);
            }
        }
        private void BindDeptUsers()
        {
            try
            {
                DataSet dsYears = new DataSet();
                ddlUsers.Items.Clear();
                dsYears = Objret.GenericFillDs("[USP_GET_DEPT_USERS_LIST]");
                if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
                {
                    ddlUsers.DataSource = dsYears.Tables[0];
                    ddlUsers.DataTextField = "User_name";
                    ddlUsers.DataValueField = "intUserid";
                    ddlUsers.DataBind();
                }
                AddSelect(ddlUsers);
            }
            catch (Exception ex)
            {
                // Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                string UID = "0";
                if (Session["uid"] != null)
                {
                    UID = Session["uid"].ToString();
                }
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, UID);
            }
        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["MappingID"] == null)
                {
                    ViewState["MappingID"] = "0";
                }

                string errormsg = GeneralInformationcheck();
                if (errormsg.Trim().TrimStart() != "")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
                    ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    ModuleVos objModuleVos = new ModuleVos();

                    objModuleVos.MappingID = ViewState["MappingID"].ToString();
                    objModuleVos.TransType = "INS";
                    objModuleVos.Created_by = ObjLoginvo.uid;

                    objModuleVos.ApplicationId = Convert.ToInt32(ddlApplication.SelectedValue);
                    objModuleVos.MainModule_Code = Convert.ToInt32(ddlModule.SelectedValue);
                    objModuleVos.Module_Code = ddlSubModule.SelectedValue;
                    objModuleVos.UserID = ddlUsers.SelectedValue;

                    string Validstatus = Objret.MapSubModuleDetails(objModuleVos);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        BtnSave.Text = "Add New";
                        ViewState["MappingID"] = "0";
                        
                        BindModuleDtls(ddlApplication.SelectedValue, ddlModule.SelectedValue,ddlSubModule.SelectedValue,ddlUsers.SelectedValue);
                        lblmsg.Text = "Saved Successfully";
                        Failure.Visible = false;
                        success.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
        public DataSet GetModuleDtls(string ApplicationID, string GroupID, string SubModule, string USERID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@ApplicationID",SqlDbType.VarChar),
               new SqlParameter("@GroupID",SqlDbType.VarChar),
               new SqlParameter("@SubModule",SqlDbType.VarChar),
               new SqlParameter("@USERID",SqlDbType.VarChar)
           };
            pp[0].Value = ApplicationID;
            Dsnew = Objret.GenericFillDs("USP_GET_USER_MAPPED_DTLS", pp);
            return Dsnew;
        }
        protected void BindModuleDtls(string ApplicationID, string GroupID, string SubModule, string USERID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetModuleDtls(ApplicationID, GroupID, SubModule, USERID);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    gvDetails.DataSource = dsnew.Tables[0];
                    gvDetails.DataBind();
                }
                else
                {
                    gvDetails.DataSource = null;
                    gvDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GeneralInformationcheck()
        {
            int slno = 1;
            string ErrorMsg = "";
            if (ddlApplication.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Application Type \\n";
                slno = slno + 1;
            }
            if (ddlModule.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Module \\n";
                slno = slno + 1;
            }
            if (ddlSubModule.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select Sub Module \\n";
                slno = slno + 1;
            }
            if (ddlUsers.SelectedValue == "0")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Select User To Map \\n";
                slno = slno + 1;
            }
            return ErrorMsg;
        }
        protected void BtnClosebatchClear_Click(object sender, EventArgs e)
        {

        }
        protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gr = (GridViewRow)(((Button)e.CommandSource).NamingContainer);

            if (e.CommandName == "Rowedit")
            {
                ddlApplication.SelectedValue = ((Label)(gr.FindControl("lblApplicationId"))).Text;
                ddlModule.SelectedValue = ((Label)(gr.FindControl("lblMainModule_Code"))).Text;
                ddlSubModule.SelectedValue = ((Label)(gr.FindControl("lblModule_Code"))).Text;
                ddlUsers.SelectedValue = ((Label)(gr.FindControl("lblintUserid"))).Text;

                ViewState["MappingID"] = ((Label)(gr.FindControl("lblMappingID"))).Text;
                BtnSave.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {

                UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
                ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

                ModuleVos objModuleVos = new ModuleVos();

                objModuleVos.MappingID = ((Label)(gr.FindControl("lblMappingID"))).Text;
                objModuleVos.TransType = "DLT";

                objModuleVos.Created_by = ObjLoginvo.uid;

                string Validstatus = Objret.MapSubModuleDetails(objModuleVos);

                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    BtnSave.Text = "Add New";
                    ViewState["MappingID"] = "0";

                    BindModuleDtls(ddlApplication.SelectedValue, ddlModule.SelectedValue,ddlSubModule.SelectedValue,ddlUsers.SelectedValue);
                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }

        protected void ddlApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMainModule(ddlApplication.SelectedValue);
            BindModuleDtls(ddlApplication.SelectedValue, ddlModule.SelectedValue, ddlSubModule.SelectedValue, ddlUsers.SelectedValue);
        }

        private void BindMainModule(string ApplicationID)
        {
            DataSet dsYears = new DataSet();
            try
            {
                ddlModule.Items.Clear();

                SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@ApplicationID",SqlDbType.VarChar) };
                pp[0].Value = ApplicationID;
                dsYears = Objret.GenericFillDs("USP_GET_Main_Module_Master", pp);

                if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
                {
                    ddlModule.DataSource = dsYears.Tables[0];
                    ddlModule.DataTextField = "GroupName";
                    ddlModule.DataValueField = "GroupID";
                    ddlModule.DataBind();
                }
                AddSelect(ddlModule);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindSubMainModule(ddlModule.SelectedValue);
                BindModuleDtls(ddlApplication.SelectedValue, ddlModule.SelectedValue, ddlSubModule.SelectedValue, ddlUsers.SelectedValue);
            }
            catch (Exception ex)
            {
                // Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                string UID = "0";
                if (Session["uid"] != null)
                {
                    UID = Session["uid"].ToString();
                }
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, UID);
            }
        }
        private void BindSubMainModule(string MainModuleCode)
        {
            try
            {
                DataSet dsYears = new DataSet();
                ddlSubModule.Items.Clear();

                SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@Main_Module",SqlDbType.VarChar)
           };
                pp[0].Value = MainModuleCode;


                dsYears = Objret.GenericFillDs("[USP_GET_Module_Master_NT_MAPPED]", pp);
                if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
                {
                    ddlSubModule.DataSource = dsYears.Tables[0];
                    ddlSubModule.DataTextField = "Module_Desc";
                    ddlSubModule.DataValueField = "Module_Code";
                    ddlSubModule.DataBind();
                }
                AddSelect(ddlSubModule);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}