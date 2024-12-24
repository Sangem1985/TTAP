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
    public partial class frmDeprApprovalDrill : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    UserLoginNewVo ObjLoginvo = new UserLoginNewVo();
                    ObjLoginvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    if (Session["uid"] != null)
                    {
                        int Stg = 0;
                        if (Request.QueryString["Stg"] != null)
                        {
                            Stg = Convert.ToInt32(Request.QueryString["Stg"].ToString());
                        }
                        if (Session["Search"] != null)
                        {
                            txtsearch.Text = Session["Search"].ToString();
                        }

                        if (ObjLoginvo.Role_Code == "ADMN")
                        {
                            lbtnback.PostBackUrl = "~/UI/Pages/frmDeptAdminDashBoard.aspx";
                        }
                        else
                        {
                            lbtnback.PostBackUrl = "~/UI/Pages/frmDeptApprovalDashBoard.aspx";
                        }   
                        
                        BindApplicationData();
                        Session["Search"] = null;
                    }
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
        public void BindApplicationData()
        {
            DataSet dss = new DataSet();

            int Stg = 0;
            if (Request.QueryString["Stg"] != null)
            {
                Stg = Convert.ToInt32(Request.QueryString["Stg"].ToString());
            }
            dss = GetNEFTRTGSApplications(Session["uid"].ToString(), Stg, txtsearch.Text.Trim().TrimStart());
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = dss;
                gvdetailsnew.DataBind();
                if (Stg == 3)
                {
                    gvdetailsnew.HeaderRow.Cells[8].Text = "Application Date";
                }
                else
                {
                    gvdetailsnew.HeaderRow.Cells[8].Text = "Submitted Date";
                }
            }
            else
            {
                gvdetailsnew.DataSource = dss;
                gvdetailsnew.DataBind();
            }
        }
        public DataSet GetNEFTRTGSApplications(string UserID, int StageId, string UnitName)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UserID",SqlDbType.VarChar),
               new SqlParameter("@StageId",SqlDbType.Int),
               new SqlParameter("@UnitName",SqlDbType.VarChar)
           };
            pp[0].Value = UserID;
            pp[1].Value = StageId;
            pp[2].Value = UnitName;
            // Dsnew = caf.GenericFillDs("USP_GET_DLOAPPLICATIONS", pp);
            Dsnew = caf.GenericFillDs("USP_GET_NEFTRTGSAPPLICATIONS_DTLS", pp);

            return Dsnew;
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            Button ddlDeptnameFnl2 = (Button)sender;
            GridViewRow row = (GridViewRow)ddlDeptnameFnl2.NamingContainer;
            Label lblIncentiveID = (Label)row.FindControl("lblIncentiveID");
            Button Button1 = (Button)row.FindControl("btnProcess");

            int Stg = 0;
            if (Request.QueryString["Stg"] != null)
            {
                Stg = Convert.ToInt32(Request.QueryString["Stg"].ToString());
            }

            string newurl = "~/UI/Pages/frmDeptPaymentApproval.aspx?Id=" + lblIncentiveID.Text.Trim() + "&Sts=" + Stg;
            if (txtsearch.Text.Trim().TrimStart() != "")
            {
                Session["Search"] = txtsearch.Text.Trim().TrimStart();
                //newurl = newurl + "&Search=" + txtsearch.Text.Trim().TrimStart();
            }
            Response.Redirect(newurl);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindApplicationData();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtsearch.Text = "";
            BindApplicationData();
        }
        
    }
}