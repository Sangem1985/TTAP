using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class frmIncentiveCAFDetails : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["ObjLoginvo"] != null)
                {
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];

                    if (hdnUserID.Value == "")
                    {
                        hdnUserID.Value = ObjLoginNewvo.uid;
                    }
                    else
                    {
                        PageName pageName = new PageName();
                        string Valid = pageName.ValidateUser(hdnUserID.Value, ObjLoginNewvo.uid);
                        if (Valid == "1")
                        {
                            Session.RemoveAll();
                            Session.Clear();
                            Session.Abandon();
                            Response.Redirect("~/LoginReg.aspx");
                        }
                    }

                    if (!IsPostBack)
                    {

                        DataSet ds = new DataSet();
                        ds = GetAllIncentives(Session["uid"].ToString(), Session["IncentiveID"].ToString());
                        Session["incentivedata"] = ds;
                        grdDetails.DataSource = ds;
                        grdDetails.DataBind();
                    }
                    string Check = ObjCAFClass.Check_Applicant_Is_Eligible_PM_Dtls(Session["IncentiveID"].ToString());
                    if (Check == "Y")
                    {
                        divNewExpInvDetails.Visible = true;
                    }
                    else
                    {
                        divNewExpInvDetails.Visible = false;
                    }
                }
                else
                {
                    Response.Redirect("~/LoginReg.aspx");
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                string uid = "0";
                if (Session["uid"] != null)
                {
                    uid = Session["uid"].ToString();
                }

                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, uid);
            }
        }

        public DataSet GetAllIncentives(string USERID, string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@CREATEDBY",SqlDbType.VarChar),
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = USERID;
            pp[1].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("FetchIncentives_CAF", pp);
            return Dsnew;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Response.Redirect("CapitalAssistanceNewUnit.aspx?next=" + "N");
        }
        protected void BtnClear0_Click(object sender, EventArgs e)
        {

        }
        protected void BtnClear_Click(object sender, EventArgs e)
        {

        }
    }
}