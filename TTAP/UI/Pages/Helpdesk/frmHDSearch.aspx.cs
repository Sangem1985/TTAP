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
    public partial class frmHDSearch : System.Web.UI.Page
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
                    BindDistricts();
                    BindApplications();
                    BindMainModule();

                    if (ObjLoginvo.Role_Code == "CO")
                    {
                        ddlDistrict.SelectedValue = ObjLoginvo.DistrictID;
                        ddlDistrict.Enabled = false;
                        if (ddlApplication.Items.FindByText(ObjLoginvo.Application_Name) != null)
                        {
                            ddlApplication.SelectedIndex = ddlApplication.Items.IndexOf(ddlApplication.Items.FindByText(ObjLoginvo.Application_Name));
                            ddlApplication.Enabled = false;
                        }
                    }
                    if (ObjLoginvo.Role_Code == "DO")
                    {
                        ddlDistrict.SelectedValue = ObjLoginvo.DistrictID;
                        ddlDistrict.Enabled = false;

                    }
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

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
                ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

                ds = GetapplicationDtls(ddlDistrict.SelectedValue, ddlApplication.SelectedValue, ddlStatus.SelectedValue, txtHdId.Text.Trim().TrimStart(), txtSubHdId.Text.Trim().TrimStart(), ObjLoginvo.uid, ObjLoginvo.Role_Code, ddlModule.SelectedValue, ddlSubModule.SelectedValue, ddlPriorityInput.SelectedValue);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvdetailsnew.DataSource = ds.Tables[0];
                    gvdetailsnew.DataBind();

                    lblMsg.Text = "Total Records : " + ds.Tables[0].Rows.Count.ToString();
                }
                else
                {
                    gvdetailsnew.DataSource = null;
                    gvdetailsnew.DataBind();

                    lblMsg.Text = "No Records Found";
                }
            }
            catch (Exception ex)
            {
                //Errors.ErrorLog(ex);
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
        public DataSet GetapplicationDtls(string Dist_Id, string Application, string Status, string Hd_Id, string SubHDID, string UserName, string RoleCode, string Module, string SubModule, string PriorityInput)
        {
            DataSet Dsnew = new DataSet();

            try
            {

                SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DistrictID",SqlDbType.VarChar),
               new SqlParameter("@Application",SqlDbType.VarChar),
               new SqlParameter("@Status",SqlDbType.VarChar),
               new SqlParameter("@Hd_Id",SqlDbType.VarChar),
               new SqlParameter("@SubHDID",SqlDbType.VarChar),
               new SqlParameter("@USERID",SqlDbType.VarChar),
               new SqlParameter("@RoleCode",SqlDbType.VarChar),
               new SqlParameter("@Module",SqlDbType.VarChar),
               new SqlParameter("@SubModule",SqlDbType.VarChar),
               new SqlParameter("@PriorityInput",SqlDbType.VarChar)
           };
                pp[0].Value = Dist_Id;
                pp[1].Value = Application;
                pp[2].Value = Status;
                pp[3].Value = Hd_Id;
                pp[4].Value = SubHDID;
                pp[5].Value = UserName;
                pp[6].Value = RoleCode;
                pp[7].Value = Module;
                pp[8].Value = SubModule;
                pp[9].Value = PriorityInput;

                Dsnew = Objret.GenericFillDs("[USP_GET_HD_SEARCH]", pp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Dsnew;
        }

        private void BindDistricts()
        {
            try
            {
                DataSet dsYears = new DataSet();
                ddlDistrict.Items.Clear();
                dsYears = Objret.GenericFillDs("USP_GET_DISTRICTS");
                if (dsYears != null && dsYears.Tables.Count > 0 && dsYears.Tables[0].Rows.Count > 0)
                {
                    ddlDistrict.DataSource = dsYears.Tables[0];
                    ddlDistrict.DataTextField = "District_Name";
                    ddlDistrict.DataValueField = "District_Id";
                    ddlDistrict.DataBind();
                }
                AddSelect(ddlDistrict);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void BindApplications()
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
                    ddlApplication.DataValueField = "Application_code";
                    ddlApplication.DataBind();
                }
                AddSelect(ddlApplication);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                throw ex;
            }
        }
        private void BindMainModule()
        {
            DataSet dsYears = new DataSet();
            try
            {
                ddlModule.Items.Clear();
                SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@ApplicationID",SqlDbType.VarChar) };

                pp[0].Value = ddlApplication.SelectedValue;

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


                dsYears = Objret.GenericFillDs("USP_GET_Module_Master", pp);
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

        protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindSubMainModule(ddlModule.SelectedValue);
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

        protected void ddlApplication_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindMainModule();
        }
    }
}