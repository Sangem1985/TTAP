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
    public partial class frmModuleMaster : System.Web.UI.Page
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
                    BindModuleDtls(ddlApplication.SelectedValue);
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
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ViewState["MainModule_Code"] == null)
                {
                    ViewState["MainModule_Code"] = "0";
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

                    objModuleVos.MainModule_Code = Convert.ToInt32(ViewState["MainModule_Code"].ToString());
                    objModuleVos.TransType = "INS";
                    objModuleVos.Created_by = ObjLoginvo.uid;

                    objModuleVos.ApplicationId = Convert.ToInt32(ddlApplication.SelectedValue);
                    objModuleVos.MainModule = txtMainModule.Text.Trim().TrimStart();


                    string Validstatus = Objret.InseringModuleDetails(objModuleVos);

                    if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                    {
                        BtnSave.Text = "Add New";
                        ViewState["MainModule_Code"] = "0";

                        txtMainModule.Text = "";

                        BindModuleDtls(ddlApplication.SelectedValue);
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
        public DataSet GetModuleDtls(string ApplicationID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@ApplicationID",SqlDbType.VarChar)
           };
            pp[0].Value = ApplicationID;
            Dsnew = Objret.GenericFillDs("USP_GET_MODULE_DETAILS", pp);
            return Dsnew;
        }
        protected void BindModuleDtls(string ApplicationID)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetModuleDtls(ApplicationID);

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
            
            if (txtMainModule.Text.TrimStart().Trim() == "")
            {
                ErrorMsg = ErrorMsg + slno + ". Please Enter Module \\n";
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

                txtMainModule.Text = ((Label)(gr.FindControl("lblGroupName"))).Text;
               

                ViewState["MainModule_Code"] = ((Label)(gr.FindControl("lblMainModule_Code"))).Text;
                BtnSave.Text = "Update";
            }
            else if (e.CommandName == "RowDdelete")
            {

                UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
                ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

                ModuleVos objModuleVos = new ModuleVos();

                objModuleVos.MainModule_Code =Convert.ToInt32(((Label)(gr.FindControl("lblMainModule_Code"))).Text);
                objModuleVos.TransType = "DLT";
                
                objModuleVos.Created_by = ObjLoginvo.uid;

                string Validstatus = Objret.InseringModuleDetails(objModuleVos);

                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    BtnSave.Text = "Add New";
                    ViewState["MainModule_Code"] = "0";

                    txtMainModule.Text = "";

                    BindModuleDtls(ddlApplication.SelectedValue);
                    lblmsg.Text = "Deleted Successfully";
                    Failure.Visible = false;
                    success.Visible = true;
                }
            }
        }

        protected void ddlApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindModuleDtls(ddlApplication.SelectedValue);
        }
    }
}