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
    public partial class frmViewAttachemnts : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
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
                        string IncentiveId = "0";
                        string SubIncentiveId = "0";
                        string QueryID = "0";
                        if (Request.QueryString.Count > 2)
                        {
                            if (Request.QueryString["IncentiveID"] != null)
                            {
                                IncentiveId = Request.QueryString["IncentiveID"].ToString();
                            }
                            if (Request.QueryString["SubIncentiveID"] != null)
                            {
                                SubIncentiveId = Request.QueryString["SubIncentiveID"].ToString();
                            }
                            if (Request.QueryString["QueryId"] != null)
                            {
                                QueryID = Request.QueryString["QueryId"].ToString();
                            }

                            GetIncetiveAttachements(IncentiveId, SubIncentiveId, QueryID);
                        }
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


        public void GetIncetiveAttachements(string IncentiveId, string SubIncentiveId, string QueryID)
        {
            DataSet dsnew1 = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentveID",SqlDbType.Int),
                new SqlParameter("@SubIncentiveIdIP",SqlDbType.Int),
                 new SqlParameter("@QueryID",SqlDbType.Int)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = SubIncentiveId;
            pp[2].Value = QueryID;

            dsnew1 = ObjCAFClass.GenericFillDs("[USP_GET_QUERY_ATTACHEMNTS]", pp);


            if (dsnew1 != null && dsnew1.Tables.Count > 0 && dsnew1.Tables[0].Rows.Count > 0)  // Query Responce Uploads
            {
                gvQueryUploads.DataSource = dsnew1.Tables[0];
                gvQueryUploads.DataBind();
                divQueryUploads.Visible = true;
            }
        }

        protected void QueryUploads_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lbl = (e.Row.FindControl("lbl") as Label);
                    HyperLink HyperLinkSubsidy = (e.Row.FindControl("HyQueryUploads") as HyperLink);

                    string Category = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Category"));
                    if (Category.Trim().TrimStart() != "")
                    {
                        lbl.Text = Category.Trim().TrimStart();
                        e.Row.Font.Bold = true;
                        HyperLinkSubsidy.Visible = false;
                    }

                    if (HyperLinkSubsidy.NavigateUrl == "")
                    {
                        HyperLinkSubsidy.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                //lblmsg0.Text = "Internal error has occured. Please try after some time";
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                // LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
    }
}