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
using System.Web.UI.HtmlControls;

namespace TTAP.UI.Pages.Releases
{
    public partial class ReleaseProceedingStep1 : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["ObjLoginvo"] != null && Request.QueryString.Count > 0)
                    {
                        int DistId = 0;
                        string status = Request.QueryString["Stage"].ToString().Trim();
                        GetYettoReleaseAbstract(DistId.ToString(), status);
                    }
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
                success.Visible = false;
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
        public void GetYettoReleaseAbstract(string DistId, string status)
        {
            DataSet ds = new DataSet();
            ds = ObjCAFClass.GetYetReleaseAbstract(DistId.ToString(), status);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                gvdetailsnew.DataSource = ds.Tables[0];
                gvdetailsnew.DataBind();
            }
        }
        protected void gvdetailsnew_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSubIncentiveID = (e.Row.FindControl("lblSubIncentiveID") as Label);
                Button btnProcess = (e.Row.FindControl("btnProcess") as Button);
                Label lblNoClaims = (e.Row.FindControl("lblNoClaims") as Label);
                TextBox txtGONo = (e.Row.FindControl("txtGONo") as TextBox);
                TextBox txtGODate = e.Row.FindControl("txtGODate") as TextBox;
                TextBox txtLOCNo = (e.Row.FindControl("txtLOCNo") as TextBox);
                TextBox txtLOCDate = e.Row.FindControl("txtLOCDate") as TextBox;
                TextBox txtGOAmount = (e.Row.FindControl("txtGOAmount") as TextBox);

                if (lblNoClaims.Text == "")
                {
                    btnProcess.Visible = false;
                    txtGONo.Visible = false;
                    txtGODate.Visible = false;
                    txtLOCNo.Visible = false;
                    txtLOCDate.Visible = false;
                    txtGOAmount.Visible = false;
                }
            }
        }
        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;
                string lblSubIncentiveID = ((Label)gvdetailsnew.Rows[indexing].FindControl("lblSubIncentiveID")).Text;
                string txtGOAmount = ((TextBox)gvdetailsnew.Rows[indexing].FindControl("txtGOAmount")).Text;

                string txtGONo = ((TextBox)gvdetailsnew.Rows[indexing].FindControl("txtGONo")).Text;
                string txtGODate = ((TextBox)gvdetailsnew.Rows[indexing].FindControl("txtGODate")).Text;
                string txtLOCNo = ((TextBox)gvdetailsnew.Rows[indexing].FindControl("txtLOCNo")).Text;
                string txtLOCDate = ((TextBox)gvdetailsnew.Rows[indexing].FindControl("txtLOCDate")).Text;
                string lblCategory = ((Label)gvdetailsnew.Rows[indexing].FindControl("lblCategory")).Text;
                string lblCategoryid = ((Label)gvdetailsnew.Rows[indexing].FindControl("lblCategoryid")).Text;

                if (txtGONo != "" && txtGODate != "" && txtLOCNo != "" && txtLOCDate != "" && txtGOAmount != "")
                {
                    Session["GoNo"] = txtGONo;
                    Session["Godate"] = txtGODate;
                    Session["Locno"] = txtLOCNo;
                    Session["Locdate"] = txtLOCDate;
                    Response.Redirect("ReleaseProceedingStep2.aspx?Category=" + lblCategoryid + "&SubIncentiveId=" + lblSubIncentiveID + "&GOAmount=" + txtGOAmount + "&GoNo=" + txtGONo + "&GoDate=" + txtGODate + "&LocNo=" + txtLOCNo + "&LocDate=" + txtLOCDate);
                }
                else
                {
                    string message = "alert('Please Enter Details to Process')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}