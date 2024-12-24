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
    public partial class frmeTicketAbstractDrill : System.Web.UI.Page
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

                UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
                ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

                string SEARCH = "";
                string SEARCHID = "";
                string FROMDATE = "";
                string TODATE = "";
                string STATUS = "";
                string NEEDAPPROVAL = "";
                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString["SEARCH"] != null)
                        SEARCH = Request.QueryString["SEARCH"].ToString();
                    if (Request.QueryString["SEARCHID"] != null)
                        SEARCHID = Request.QueryString["SEARCHID"].ToString();
                    if (Request.QueryString["FROMDATE"] != null)
                        FROMDATE = Request.QueryString["FROMDATE"].ToString();
                    if (Request.QueryString["TODATE"] != null)
                        TODATE = Request.QueryString["TODATE"].ToString();
                    if (Request.QueryString["STATUS"] != null)
                        STATUS = Request.QueryString["STATUS"].ToString();

                    if (Request.QueryString["NEEDAPPROVAL"] != null)
                        NEEDAPPROVAL = Request.QueryString["NEEDAPPROVAL"].ToString();
                }

                string UserId = ObjLoginvo.uid;

                if (SEARCH=="EMP" || (SEARCH == "ApplicationHistory" && STATUS=="CLOSED"))
                {
                    gvdetailsnew.Columns[10].Visible = true;
                    gvdetailsnew.Columns[11].Visible = true;
                }

                DataSet ds = new DataSet();
                ds = GetapplicationDtls(UserId, SEARCH, SEARCHID, FROMDATE, TODATE, STATUS, NEEDAPPROVAL);
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
        }

        public DataSet GetapplicationDtls(string UserId, string SEARCH, string SEARCHID, string FROMDATE, string TODATE, string STATUS, string NEEDAPPROVAL)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UserId",SqlDbType.VarChar),
               new SqlParameter("@SEARCH",SqlDbType.VarChar),
                new SqlParameter("@SEARCHID",SqlDbType.VarChar),
                 new SqlParameter("@FROMDATE",SqlDbType.VarChar),
                  new SqlParameter("@TODATE",SqlDbType.VarChar),
                  new SqlParameter("@STATUS",SqlDbType.VarChar),
                   new SqlParameter("@NEEDAPPROVAL",SqlDbType.VarChar)
           };
            pp[0].Value = UserId;
            pp[1].Value = SEARCH;
            pp[2].Value = SEARCHID;
            pp[3].Value = FROMDATE;
            pp[4].Value = TODATE;
            pp[5].Value = STATUS;
            pp[6].Value = NEEDAPPROVAL;
            Dsnew = Objret.GenericFillDs("[USP_GET_ETRACKE_ABSTRACT_DRILL]", pp);
            return Dsnew;
        }
    }
}