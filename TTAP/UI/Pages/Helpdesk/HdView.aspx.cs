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

namespace eTicketingSystem.UI.Pages.Helpdesk
{
    public partial class HdView : System.Web.UI.Page
    {
        CAFClass Objret = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/LoginReg.aspx");
            }
            if (!IsPostBack)
            {
                HdClassVoDepartment Objdepartment = new HdClassVoDepartment();
                //UserLoginVo ObjLoginvo = new UserLoginVo();
                //ObjLoginvo = (UserLoginVo)Session["ObjLoginvo"];

                UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
                ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

                BindDistricts();
                BindApplications();
                BindMainModule();


                BindGrid();
            }
        }

        public void BindGrid()
        {
            UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
            ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

            string STATUS = Request.QueryString["STATUS"].ToString();
            string USERTYPE = ObjLoginvo.userlevel;
            string UserId = ObjLoginvo.uid;

            if (STATUS == "2")
            {
                acurrentpage.InnerText = "Total HD's CLosed";
            }
            else if (STATUS == "3")
            {
                acurrentpage.InnerText = "Total HD's Registered";
            }
            else if (STATUS == "1")
            {
                acurrentpage.InnerText = "Total HD's Pending";
            }
            else if (STATUS == "4")
            {
                acurrentpage.InnerText = "Total HD's Rejected";
            }

            if (STATUS == "2" || STATUS == "102")
            {
                if (ObjLoginvo.Role_Code == "DEPT" && STATUS == "2")
                {

                }
                else
                {
                    gvdetailsnew.Columns[11].Visible = true;
                    gvdetailsnew.Columns[12].Visible = true;
                }
            }

            if (STATUS == "1" || STATUS == "11" || STATUS == "21" || STATUS == "22" || STATUS == "103" || STATUS == "104" || STATUS == "105")
            {
                gvdetailsnew.Columns[10].Visible = true;
            }

            if (ObjLoginvo.Role_Code != "DEPT" || ObjLoginvo.Role_Code != "")
            {
                if (ddlDistrict.Items.FindByValue(ObjLoginvo.DistrictID) != null)
                {
                    //ddlDistrict.SelectedIndex = ddlDistrict.Items.IndexOf(ddlDistrict.Items.FindByText(ObjLoginvo.Application_Name));
                    ddlDistrict.SelectedIndex = ddlDistrict.Items.IndexOf(ddlDistrict.Items.FindByValue(ObjLoginvo.DistrictID));
                    ddlDistrict.Enabled = false;
                }
            }
            DataSet ds = new DataSet();
            ds = GetapplicationDtls(UserId, STATUS, USERTYPE, ddlDistrict.SelectedValue, ObjLoginvo.Mandal_Id,ddlApplication.SelectedValue,ddlModule.SelectedValue,ddlSubModule.SelectedValue,ddlPriorityInput.SelectedValue);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = ds.Tables[0];
                gvdetailsnew.DataBind();

                lblMsg.Text = "Total Records : " + ds.Tables[0].Rows.Count.ToString();
            }
            else
            {
                lblMsg.Text = "No Records Found ";
            }
        }
        public DataSet GetapplicationDtls(string UserName, string STATUS, string USERTYPE, string DistrictID, string Mandal_Id, string Application, string Module, string SubModule, string PriorityInput)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
               new SqlParameter("@STATUS",SqlDbType.VarChar),
               new SqlParameter("@USERTYPE",SqlDbType.VarChar),
               new SqlParameter("@DistrictID",SqlDbType.VarChar),
               new SqlParameter("@Mandal_Id",SqlDbType.VarChar),

               new SqlParameter("@Application",SqlDbType.VarChar),
               new SqlParameter("@Module",SqlDbType.VarChar),
               new SqlParameter("@SubModule",SqlDbType.VarChar),
               new SqlParameter("@PriorityInput",SqlDbType.VarChar)
           };
            pp[0].Value = UserName;
            pp[1].Value = STATUS;
            pp[2].Value = USERTYPE;
            pp[3].Value = DistrictID;
            pp[4].Value = Mandal_Id;

            pp[5].Value = Application;
            pp[6].Value = Module;
            pp[7].Value = SubModule;
            pp[8].Value = PriorityInput;

            Dsnew = Objret.GenericFillDs("USP_GET_RAISED_HD_USER", pp);
            return Dsnew;
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            ddlDistrict.SelectedValue = "0";
            ddlApplication.SelectedValue = "0";
            ddlModule.SelectedValue = "0";
            ddlModule_SelectedIndexChanged(sender, e);
            ddlPriorityInput.SelectedValue = "0";
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