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
using System.IO;

namespace TTAP.UI.Pages
{
    public partial class FormRDDDashboard : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] != null)
            {
                int DistId = 0;
                string userid = Session["uid"].ToString();
                DistId = Convert.ToInt32(Session["RDDDistID"].ToString());
                BindDistricts(DistId);
            }
        }
        public void BindDistricts(int DistId)
        {
            dss = GetDistrictsList(DistId);
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                ddlDistrict.DataSource = dss;
                ddlDistrict.DataTextField = "District_Name";
                ddlDistrict.DataValueField = "District_Id";
                ddlDistrict.DataBind();
                AddSelect(ddlDistrict);
            }
            else
            {
                AddSelect(ddlDistrict);
            }
        }
        public DataSet GetDistrictsList1()
        {
            DataSet Dsnew = new DataSet();
            Dsnew = caf.GenericFillDs("GetDistrictsHYD");
            return Dsnew;
        }
        public DataSet GetDistrictsList(int DistId)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@DistId",SqlDbType.VarChar),
           };
            pp[0].Value = DistId.ToString();
            Dsnew = caf.GenericFillDs("GetDistrictsHYD", pp);
            return Dsnew;
        }
        public void AddSelect(DropDownList ddl)
        {
            ListItem li = new ListItem();
            li.Text = "--Select--";
            li.Value = "0";
            ddl.Items.Insert(0, li);
        }
    }
}