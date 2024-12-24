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
    public partial class frmStateDashboard : System.Web.UI.Page
    {
        CAFClass Objret = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count <= 0)
            {
                Response.Redirect("~/LoginReg.aspx");
            }

            UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
            ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

            if (!IsPostBack)
            {
                DataSet ds = new DataSet();
                ds = GetapplicationDtls(ObjLoginvo.uid);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lbltotaliises.Text = ds.Tables[0].Rows[0]["TOTALHD"].ToString();
                    lblcompleted.Text = ds.Tables[0].Rows[0]["CLOSEDHD"].ToString();
                    // lblpending.Text = ds.Tables[0].Rows[0]["PENDINGHD"].ToString();
                    // lblrejected.Text = ds.Tables[0].Rows[0]["REJECTED"].ToString();
                    lblpending.Text = ds.Tables[0].Rows[0]["PENDINGHDCMS"].ToString();
                    lblpendingDRP.Text = ds.Tables[0].Rows[0]["PENDINGHDDRP"].ToString();
                    lblpendingDepartmnet.Text = ds.Tables[0].Rows[0]["PENDINGHDDEPT"].ToString();
                    //spanTotalhds.InnerHtml = "Total ET's Received";
                }
            }
        }

        public DataSet GetapplicationDtls(string USERID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar)
           };
            pp[0].Value = USERID;
            Dsnew = Objret.GenericFillDs("[USP_GET_STATE_ABSTRACT]", pp);
            return Dsnew;
        }
    }
}