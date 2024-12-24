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
    public partial class frmeTicketAbstract : System.Web.UI.Page
    {
        CAFClass Objret = new CAFClass();

        int TOTAL_RAISED, TOTAL_PENDING, TOTAL_CLOSED, PENDING_AT_DEPT;
        int TOTAL_RAISED_Application;
        int TOTAL_RAISED_Category;
        int TOTAL_RAISED_Module;
        int TOTAL_RAISED_UserWise;





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

                txtFromDate.Text = System.DateTime.Now.Day.ToString() + "/" + System.DateTime.Now.Month.ToString() + "/" + System.DateTime.Now.Year.ToString();
                txtToDate.Text = System.DateTime.Now.Day.ToString() + "/" + System.DateTime.Now.Month.ToString() + "/" + System.DateTime.Now.Year.ToString();

                string FromDate = GetFromatedDateDDMMYYYY(txtFromDate.Text.Trim().TrimStart());
                string Todate = GetFromatedDateDDMMYYYY(txtToDate.Text.Trim().TrimStart());

                
                BindGrids(ObjLoginvo.uid, FromDate, Todate);
            }
        }
        protected void Button8_Click(object sender, EventArgs e)
        {
            UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
            ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

            string FromDate = GetFromatedDateDDMMYYYY(txtFromDate.Text.Trim().TrimStart());
            string Todate = GetFromatedDateDDMMYYYY(txtToDate.Text.Trim().TrimStart());

            BindGrids(ObjLoginvo.uid, FromDate, Todate);
        }
        public string GetFromatedDateDDMMYYYY(string Date)
        {
            string Dateformat = "";
            string[] Ld6 = null;
            string ConvertedDt56 = "";
            if (Date != "")
            {
                Ld6 = Date.Split('/');
                ConvertedDt56 = Ld6[2].ToString() + "/" + Ld6[1].ToString() + "/" + Ld6[0].ToString();
                Dateformat = ConvertedDt56;
            }
            else
            {
                Dateformat = null;
            }
            return Dateformat;
        }
        public void BindGrids(string UserName, string FromDate, string Todate)
        {
            divuserHeading.InnerHtml = "Total Issues Addressed - User Wise ( " + txtFromDate.Text + " To " + txtToDate.Text + " )";
            divTicketsHistoryHeading.InnerHtml = "Total Tickets History  ( " + txtFromDate.Text + " To " + txtToDate.Text + " )";

            DataSet ds = new DataSet();
            ds = GetapplicationDtls(UserName, FromDate, Todate);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = ds.Tables[0];
                gvdetailsnew.DataBind();
            }
            else
            {
                gvdetailsnew.DataSource = null;
                gvdetailsnew.DataBind();
            }

            if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
            {
                gvdetailsCategory.DataSource = ds.Tables[1];
                gvdetailsCategory.DataBind();
            }
            else
            {
                gvdetailsCategory.DataSource = null;
                gvdetailsCategory.DataBind();
            }

            if (ds != null && ds.Tables.Count > 2 && ds.Tables[2].Rows.Count > 0)
            {
                gvdetailsModule.DataSource = ds.Tables[2];
                gvdetailsModule.DataBind();
            }
            else
            {
                gvdetailsModule.DataSource = null;
                gvdetailsModule.DataBind();
            }

            if (ds != null && ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
            {
                gvUserWise.DataSource = ds.Tables[3];
                gvUserWise.DataBind();
            }
            else
            {
                gvUserWise.DataSource = null;
                gvUserWise.DataBind();
            }


            if (ds != null && ds.Tables.Count > 4 && ds.Tables[4].Rows.Count > 0)
            {
                gvTicketsHistory.DataSource = ds.Tables[4];
                gvTicketsHistory.DataBind();
            }
            else
            {
                gvTicketsHistory.DataSource = null;
                gvTicketsHistory.DataBind();
            }
        }
        public DataSet GetapplicationDtls(string UserName, string FromDate, string ToDate)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@USERID",SqlDbType.VarChar),
               new SqlParameter("@FROMDATE",SqlDbType.VarChar),
               new SqlParameter("@TODATE",SqlDbType.VarChar),
           };
            pp[0].Value = UserName;
            pp[1].Value = FromDate;
            pp[2].Value = ToDate;

            Dsnew = Objret.GenericFillDs("[USP_GET_E_TICKET_ABSTRACT]", pp);
            return Dsnew;
        }


        protected void gvdetailsnew_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int TOTAL_RAISED1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PENDING"));
                TOTAL_RAISED_Application = TOTAL_RAISED1 + TOTAL_RAISED_Application;


                Label lblApplication_code = (e.Row.FindControl("lblApplication_code") as Label);
                HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
                if (h1.Text != "0")
                {
                    h1.NavigateUrl = "frmeTicketAbstractDrill.aspx?SEARCH=Application&SEARCHID=" + lblApplication_code.Text.Trim() + "&STATUS=OPEN";
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[2].Text = TOTAL_RAISED_Application.ToString();

                HyperLink h1 = new HyperLink();
                h1.ForeColor = System.Drawing.Color.Blue;
                h1.NavigateUrl = "frmeTicketAbstractDrill.aspx?SEARCH=Application&SEARCHID=" + "%" + "&STATUS=OPEN";
                h1.Text = TOTAL_RAISED_Application.ToString();
                e.Row.Cells[2].Controls.Add(h1);
            }
        }
        protected void gvdetailsCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int TOTAL_RAISED1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PENDING"));
                TOTAL_RAISED_Category = TOTAL_RAISED1 + TOTAL_RAISED_Category;

                Label lblintfb_id = (e.Row.FindControl("lblintfb_id") as Label);
                HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
                if (h1.Text != "0")
                {
                    h1.NavigateUrl = "frmeTicketAbstractDrill.aspx?SEARCH=Category&SEARCHID=" + lblintfb_id.Text.Trim() + "&STATUS=OPEN";
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[2].Text = TOTAL_RAISED_Category.ToString();

                HyperLink h1 = new HyperLink();
                h1.ForeColor = System.Drawing.Color.Blue;
                h1.NavigateUrl = "frmeTicketAbstractDrill.aspx?SEARCH=Category&SEARCHID=" + "%" + "&STATUS=OPEN";
                h1.Text = TOTAL_RAISED_Category.ToString();
                e.Row.Cells[2].Controls.Add(h1);
            }
        }



        protected void gvdetailsModule_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int TOTAL_RAISED1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PENDING"));
                TOTAL_RAISED_Module = TOTAL_RAISED1 + TOTAL_RAISED_Module;

                Label lblGroupID = (e.Row.FindControl("lblGroupID") as Label);
                HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
                if (h1.Text != "0")
                {
                    h1.NavigateUrl = "frmeTicketAbstractDrill.aspx?SEARCH=Module&SEARCHID=" + lblGroupID.Text.Trim() + "&STATUS=OPEN";
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[2].Text = TOTAL_RAISED_Module.ToString();

                HyperLink h1 = new HyperLink();
                h1.ForeColor = System.Drawing.Color.Blue;
                h1.NavigateUrl = "frmeTicketAbstractDrill.aspx?SEARCH=Module&SEARCHID=" + "%" + "&STATUS=OPEN";
                h1.Text = TOTAL_RAISED_Module.ToString();
                e.Row.Cells[2].Controls.Add(h1);
            }
        }

        protected void gvUserWise_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string FromDate = GetFromatedDateDDMMYYYY(txtFromDate.Text.Trim().TrimStart());
            string Todate = GetFromatedDateDDMMYYYY(txtToDate.Text.Trim().TrimStart());

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int TOTAL_RAISED1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SOLCOUNT"));
                TOTAL_RAISED_UserWise = TOTAL_RAISED1 + TOTAL_RAISED_UserWise;

                Label lblUser_id = (e.Row.FindControl("lblUser_id") as Label);
                HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
                if (h1.Text != "0")
                {
                    h1.NavigateUrl = "frmeTicketAbstractDrill.aspx?SEARCH=EMP&SEARCHID=" + lblUser_id.Text.Trim() + "&STATUS=CLOSED" + "&FROMDATE=" + FromDate + "&TODATE=" + Todate;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[2].Text = TOTAL_RAISED_UserWise.ToString();

                HyperLink h1 = new HyperLink();
                h1.ForeColor = System.Drawing.Color.Blue;
                h1.NavigateUrl = "frmeTicketAbstractDrill.aspx?SEARCH=EMP&SEARCHID=" + "%" + "&STATUS=CLOSED" + "&FROMDATE=" + FromDate + "&TODATE=" + Todate;
                h1.Text = TOTAL_RAISED_UserWise.ToString();
                e.Row.Cells[2].Controls.Add(h1);
            }
        }

        protected void gvTicketsHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string FromDate = GetFromatedDateDDMMYYYY(txtFromDate.Text.Trim().TrimStart());
            string Todate = GetFromatedDateDDMMYYYY(txtToDate.Text.Trim().TrimStart());

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                int TOTAL_RAISED1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TOTAL_RAISED"));
                TOTAL_RAISED = TOTAL_RAISED1 + TOTAL_RAISED;

                int TOTAL_CLOSED1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TOTAL_CLOSED"));
                TOTAL_CLOSED = TOTAL_CLOSED1 + TOTAL_CLOSED;

                int TOTAL_PENDING1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TOTAL_PENDING"));
                TOTAL_PENDING = TOTAL_PENDING1 + TOTAL_PENDING;

                int PENDING_AT_DRP1 = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NEEDAPPROVAL"));
                PENDING_AT_DEPT = PENDING_AT_DRP1 + PENDING_AT_DEPT;

                Label lblApplication_code = (e.Row.FindControl("lblApplication_codeHistory") as Label);
                HyperLink h1 = (HyperLink)e.Row.Cells[2].Controls[0];
                if (h1.Text != "0")
                {
                    h1.NavigateUrl = "frmeTicketAbstractDrill.aspx?SEARCH=ApplicationHistory&SEARCHID=" + lblApplication_code.Text.Trim() + "&STATUS=%" + "&NEEDAPPROVAL=%" + "&FROMDATE=" + FromDate + "&TODATE=" + Todate;
                }

                HyperLink h2 = (HyperLink)e.Row.Cells[3].Controls[0];
                if (h2.Text != "0")
                {
                    h2.NavigateUrl = "frmeTicketAbstractDrill.aspx?SEARCH=ApplicationHistory&SEARCHID=" + lblApplication_code.Text.Trim() + "&STATUS=CLOSED" + "&NEEDAPPROVAL=N" + "&FROMDATE=" + FromDate + "&TODATE=" + Todate;
                }

                HyperLink h3 = (HyperLink)e.Row.Cells[4].Controls[0];
                if (h3.Text != "0")
                {
                    h3.NavigateUrl = "frmeTicketAbstractDrill.aspx?SEARCH=ApplicationHistory&SEARCHID=" + lblApplication_code.Text.Trim() + "&STATUS=OPEN" + "&NEEDAPPROVAL=N" + "&FROMDATE=" + FromDate + "&TODATE=" + Todate;
                }

                HyperLink h4 = (HyperLink)e.Row.Cells[5].Controls[0];
                if (h4.Text != "0")
                {
                    h4.NavigateUrl = "frmeTicketAbstractDrill.aspx?SEARCH=ApplicationHistory&SEARCHID=" + lblApplication_code.Text.Trim() + "&STATUS=OPEN" + "&NEEDAPPROVAL=Y" + "&FROMDATE=" + FromDate + "&TODATE=" + Todate;
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[1].Text = "Total";
                e.Row.Cells[2].Text = TOTAL_RAISED.ToString();
                e.Row.Cells[3].Text = TOTAL_CLOSED.ToString();
                e.Row.Cells[4].Text = TOTAL_PENDING.ToString();
                e.Row.Cells[5].Text = PENDING_AT_DEPT.ToString();


                HyperLink h1 = new HyperLink();
                h1.ForeColor = System.Drawing.Color.Blue;
                h1.NavigateUrl = "frmeTicketAbstractDrill.aspx?SEARCH=ApplicationHistory&SEARCHID=" + "%" + "&STATUS=%" + "&NEEDAPPROVAL=%" + "&FROMDATE=" + FromDate + "&TODATE=" + Todate;
                h1.Text = TOTAL_RAISED.ToString();
                e.Row.Cells[2].Controls.Add(h1);

                h1 = new HyperLink();
                h1.ForeColor = System.Drawing.Color.Blue;
                h1.NavigateUrl = "frmeTicketAbstractDrill.aspx?SEARCH=ApplicationHistory&SEARCHID=" + "%" + "&STATUS=CLOSED" + "&NEEDAPPROVAL=N" + "&FROMDATE=" + FromDate + "&TODATE=" + Todate;
                h1.Text = TOTAL_CLOSED.ToString();
                e.Row.Cells[3].Controls.Add(h1);

                h1 = new HyperLink();
                h1.ForeColor = System.Drawing.Color.Blue;
                h1.NavigateUrl = "frmeTicketAbstractDrill.aspx?SEARCH=ApplicationHistory&SEARCHID=" + "%" + "&STATUS=OPEN" + "&NEEDAPPROVAL=N" + "&FROMDATE=" + FromDate + "&TODATE=" + Todate;
                h1.Text = TOTAL_PENDING.ToString();
                e.Row.Cells[4].Controls.Add(h1);

                h1 = new HyperLink();
                h1.ForeColor = System.Drawing.Color.Blue;
                h1.NavigateUrl = "frmeTicketAbstractDrill.aspx?SEARCH=ApplicationHistory&SEARCHID=" + "%" + "&STATUS=OPEN" + "&NEEDAPPROVAL=Y" + "&FROMDATE=" + FromDate + "&TODATE=" + Todate;
                h1.Text = PENDING_AT_DEPT.ToString();
                e.Row.Cells[5].Controls.Add(h1);
            }
        }
    }
}