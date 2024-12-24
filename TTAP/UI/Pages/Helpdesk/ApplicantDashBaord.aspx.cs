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
    public partial class ApplicantDashBaord : System.Web.UI.Page
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
                //if (ObjLoginvo.Fillflag != "Y")
                //{
                //    Response.Redirect("ApplicantDashBaord.aspx");
                //}
                DataSet ds = new DataSet();
                ds = GetapplicationDtls(ObjLoginvo.uid, ObjLoginvo.userlevel);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    lbltotaliises.Text = ds.Tables[0].Rows[0]["TOTALHD"].ToString();
                    lblcompleted.Text = ds.Tables[0].Rows[0]["CLOSEDHD"].ToString();
                    lblpending.Text = ds.Tables[0].Rows[0]["PENDINGHD"].ToString();
                    lblrejected.Text = ds.Tables[0].Rows[0]["REJECTED"].ToString();
                }
            }
        }

        public DataSet GetapplicationDtls(string USERID, string USERTYPE)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
               new SqlParameter("@USERTYPE",SqlDbType.VarChar)
           };
            pp[0].Value = USERID;
            pp[1].Value = USERTYPE;
            Dsnew = Objret.GenericFillDs("USP_GET_HDDASHBOARD", pp);
            return Dsnew;
        }
    }
}