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
    public partial class ViewHDAttachments : System.Web.UI.Page
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
                DataSet ds = new DataSet();
                string HDID = Request.QueryString["Hd_Id"].ToString();
                string SubHDID = Request.QueryString["SubHDID"].ToString();
                string UserId = Request.QueryString["UserId"].ToString();
                string ViewType = Request.QueryString["ViewType"].ToString();
                ds = GetapplicationDtls(HDID, UserId, SubHDID, ViewType);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    Trqueryresponceattachemnts.Visible = true;
                    gvqueryresponse.DataSource = ds.Tables[0];
                    gvqueryresponse.DataBind();
                }
                else
                {
                    Trqueryresponceattachemnts.Visible = true;
                }
                if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                {
                    trdeptattachments.Visible = true;
                    GridView1.DataSource = ds.Tables[1];
                    GridView1.DataBind();
                }
            }
        }

        public DataSet GetapplicationDtls(string Hd_Id, string UserName, string SubHDID, string ViewType)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@Hd_Id",SqlDbType.VarChar),
               new SqlParameter("@USERID",SqlDbType.VarChar),
               new SqlParameter("@SubHDID",SqlDbType.VarChar),
               new SqlParameter("@ViewType",SqlDbType.VarChar)

           };
            pp[0].Value = Hd_Id;
            pp[1].Value = UserName;
            pp[2].Value = SubHDID;
            pp[3].Value = ViewType;
            Dsnew = Objret.GenericFillDs("USP_GET_RAISED_HD_USER_ATTACHEMNTS", pp);
            return Dsnew;
        }
    }
}