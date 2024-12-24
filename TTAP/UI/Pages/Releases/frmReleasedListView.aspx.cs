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

namespace TTAP.UI.Pages.Releases
{
    public partial class frmReleasedListView : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                Response.Redirect("~/loginReg.aspx");
            }

            if (!IsPostBack)
            {
                string Stage = "";
                string ApplicationMode = "";
                string Category = "";
                string SubIncentiveID = "";
                string GOID = "";

                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString["ApplicationMode"] != null)
                    {
                        ApplicationMode = Request.QueryString["ApplicationMode"].ToString();
                        if (ApplicationMode.ToUpper() == "1")
                        {
                            lblTypeofApplication.InnerText = "SLC";
                        }
                        else if (ApplicationMode.ToUpper() == "2")
                        {
                            lblTypeofApplication.InnerText = "DLC";
                        }
                        else
                        {
                            lblTypeofApplication.InnerText = "SLC & DLC";
                        }
                    }
                    if (Request.QueryString["Stage"] != null)
                    {
                        Stage = Request.QueryString["Stage"].ToString();
                    }
                    if (Request.QueryString["Category"] != null)
                    {
                        Category = Request.QueryString["Category"].ToString();
                    }
                    if (Request.QueryString["GOID"] != null)
                    {
                        GOID = Request.QueryString["GOID"].ToString();
                    }
                    if (Request.QueryString["SubIncentiveID"] != null)
                    {
                        SubIncentiveID = Request.QueryString["SubIncentiveID"].ToString();
                    }

                    DataSet ds = new DataSet();
                    ds = ObjCAFClass.GetReleaseList(Stage, ApplicationMode, Category, SubIncentiveID, GOID,"");
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        //tdinvestments.InnerHtml = "--> " + ds.Tables[1].Rows[0]["IncentiveNameText"].ToString();
                        //h1heading.InnerHtml = ds.Tables[1].Rows[0]["SocialStatusText"].ToString() + " Category";
                        gvdetailsnew.DataSource = ds.Tables[0];
                        gvdetailsnew.DataBind();
                       
                        btnSubmit.Visible = true;
                        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                        {
                            lblIncentives.InnerHtml = ds.Tables[1].Rows[0]["IncentiveNameText"].ToString();
                            lblIncCategory.InnerHtml = ds.Tables[1].Rows[0]["SocialStatusText"].ToString();
                        }
                    }
                    else
                    {
                        btnSubmit.Visible = false;
                    }
                }
            }
        }
      
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
        }
    }
}