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
    public partial class frmRptDistWiseAbstract : System.Web.UI.Page
    {
        CAFClass Objret = new CAFClass();

        int TOTAL_RAISED, TOTAL_PENDING, TOTAL_CLOSED, PENDING_AT_DRP, CLOSED_BY_DRP, FWD_TO_TECH_TEAM, PENDING_AT_TECH_TEAM, CLOSED_BY_TECH_TEAM, FWD_TO_DEPT_APPR, PENDING_AT_DEPT, TOTAL_ACTION_TAKEN_DEPT;
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

                DataSet ds = new DataSet();

                ds = GetapplicationDtls(ObjLoginvo.DistrictID, ObjLoginvo.uid, ObjLoginvo.Role_Code);
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

        public DataSet GetapplicationDtls(string DistrictID, string UserName, string RoleCode)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
                new SqlParameter("@DistrictID",SqlDbType.VarChar),
               new SqlParameter("@USERID",SqlDbType.VarChar),
               new SqlParameter("@RoleCode",SqlDbType.VarChar),

           };
            pp[0].Value = DistrictID;
            pp[1].Value = UserName;
            pp[2].Value = RoleCode;

            Dsnew = Objret.GenericFillDs("USP_GET_DISTRICTWISE_REPORT", pp);
            return Dsnew;
        }

        protected void gvdetailsnew_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                int TOTAL_RAISED1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TOTAL_RAISED"));
                TOTAL_RAISED = TOTAL_RAISED1 + TOTAL_RAISED;

                int TOTAL_PENDING1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TOTAL_PENDING"));
                TOTAL_PENDING = TOTAL_PENDING1 + TOTAL_PENDING;

                int TOTAL_CLOSED1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TOTAL_CLOSED"));
                TOTAL_CLOSED = TOTAL_CLOSED1 + TOTAL_CLOSED;

                int PENDING_AT_DRP1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PENDING_AT_DRP"));
                PENDING_AT_DRP = PENDING_AT_DRP1 + PENDING_AT_DRP;

                int CLOSED_BY_DRP1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CLOSED_BY_DRP"));
                CLOSED_BY_DRP = CLOSED_BY_DRP1 + CLOSED_BY_DRP;

                int FWD_TO_TECH_TEAM1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FWD_TO_TECH_TEAM"));
                FWD_TO_TECH_TEAM = FWD_TO_TECH_TEAM1 + FWD_TO_TECH_TEAM;

                int PENDING_AT_TECH_TEAM1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PENDING_AT_TECH_TEAM"));
                PENDING_AT_TECH_TEAM = PENDING_AT_TECH_TEAM1 + PENDING_AT_TECH_TEAM;

                int CLOSED_BY_TECH_TEAM1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CLOSED_BY_TECH_TEAM"));
                CLOSED_BY_TECH_TEAM = CLOSED_BY_TECH_TEAM1 + CLOSED_BY_TECH_TEAM;

                int FWD_TO_DEPT_APPR1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FWD_TO_DEPT_APPR"));
                FWD_TO_DEPT_APPR = FWD_TO_DEPT_APPR1 + FWD_TO_DEPT_APPR;

                int PENDING_AT_DEPT1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PENDING_AT_DEPT"));
                PENDING_AT_DEPT = PENDING_AT_DEPT1 + PENDING_AT_DEPT;

                int TOTAL_ACTION_TAKEN_DEPT1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TOTAL_ACTION_TAKEN_DEPT"));
                TOTAL_ACTION_TAKEN_DEPT = TOTAL_ACTION_TAKEN_DEPT1 + TOTAL_ACTION_TAKEN_DEPT;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[2].Text = TOTAL_RAISED.ToString();
                e.Row.Cells[3].Text = TOTAL_PENDING.ToString();
                e.Row.Cells[4].Text = TOTAL_CLOSED.ToString();
                e.Row.Cells[5].Text = PENDING_AT_DRP.ToString();
                e.Row.Cells[6].Text = CLOSED_BY_DRP.ToString();
                e.Row.Cells[7].Text = FWD_TO_TECH_TEAM.ToString();
                e.Row.Cells[8].Text = PENDING_AT_TECH_TEAM.ToString();
                e.Row.Cells[9].Text = CLOSED_BY_TECH_TEAM.ToString();
                e.Row.Cells[10].Text = FWD_TO_DEPT_APPR.ToString();
                e.Row.Cells[11].Text = PENDING_AT_DEPT.ToString();
                e.Row.Cells[12].Text = TOTAL_ACTION_TAKEN_DEPT.ToString();
            }
        }
    }
}