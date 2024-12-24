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
    public partial class fmUserHdView : System.Web.UI.Page
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

                //if (ObjLoginvo.User_level == "1")
                //{
                //    ehome.HRef = "ApplicantDashBaord.aspx";

                //}
                //else if (ObjLoginvo.User_level == "2")
                //{
                //    ehome.HRef = "HdDashBoard.aspx";

                //}

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
                    gvdetailsnew.Columns[10].Visible = true;
                }
                else if (STATUS == "4")
                {
                    acurrentpage.InnerText = "Total HD's Rejected";
                }

                if (STATUS == "2")
                {
                    gvdetailsnew.Columns[11].Visible = true;
                    gvdetailsnew.Columns[12].Visible = true;
                }

                if (STATUS == "1")
                {
                    gvdetailsnew.Columns[10].Visible = true;
                }
                DataSet ds = new DataSet();

                ds = GetapplicationDtls(UserId, STATUS, USERTYPE, ObjLoginvo.DistrictID, ObjLoginvo.Mandal_Id);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    gvdetailsnew.DataSource = ds.Tables[0];
                    gvdetailsnew.DataBind();

                    lblMsg.Text = "Total Records : " + ds.Tables[0].Rows.Count.ToString();

                    //if (ObjLoginvo.userlevel != "13")
                    //{
                    //    gvdetailsnew.HeaderRow.Cells[2].Text = "District";
                    //}
                    //else if (ObjLoginvo.userlevel == "2")
                    //{
                    //    gvdetailsnew.HeaderRow.Cells[2].Text = "Unit Name/District";
                    //}
                }
                else
                {
                    lblMsg.Text = "No Records Found ";
                }
            }
        }

        public DataSet GetapplicationDtls(string UserName, string STATUS, string USERTYPE, string DistrictID, string Mandal_Id)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
               new SqlParameter("@STATUS",SqlDbType.VarChar),
                new SqlParameter("@USERTYPE",SqlDbType.VarChar),
                 new SqlParameter("@DistrictID",SqlDbType.VarChar),
                  new SqlParameter("@Mandal_Id",SqlDbType.VarChar)
           };
            pp[0].Value = UserName;
            pp[1].Value = STATUS;
            pp[2].Value = USERTYPE;
            pp[3].Value = DistrictID;
            pp[4].Value = Mandal_Id;
            Dsnew = Objret.GenericFillDs("[USP_GET_RAISED_HD_USER_VIEW]", pp);
            return Dsnew;
        }
    }
}