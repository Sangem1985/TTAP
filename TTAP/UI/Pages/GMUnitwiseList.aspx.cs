using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class GMUnitwiseList : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string Cast = Request.QueryString[0].ToString();
            string SubIncentiveid = Convert.ToInt32(Request.QueryString[1]).ToString();
            string Status = Request.QueryString[2].ToString();
            string Distid = Convert.ToInt64(Request.QueryString[3]).ToString();

            ds = ObjCAFClass.GetGMUnitWiseListIncentive(Cast, SubIncentiveid, Status, Distid);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                string socialStatus = ds.Tables[0].Rows[0]["StatusCategory"].ToString();
                h1heading.InnerHtml = socialStatus + " Category";

                GVDetails.DataSource = ds.Tables[0];
                GVDetails.DataBind();
            }
        }

        protected void btnSanctionlist_Click(object sender, EventArgs e)
        {
            try
            {
                int indexing = ((GridViewRow)((Control)sender).NamingContainer).RowIndex;

                string lblSubIncentiveID = ((Label)GVDetails.Rows[indexing].FindControl("lblSubIncentiveID")).Text;
                string lblIncentiveID = ((Label)GVDetails.Rows[indexing].FindControl("lblIncentiveID")).Text;
                //string lblSLCNumber = ((Label)GVDetails.Rows[indexing].FindControl("lblSLCNumber")).Text;

                Response.Redirect("GMUnitWorkingStatusUpdation.aspx?Cast=" + Request.QueryString[0].ToString() + "&Status=" + Request.QueryString[2].ToString() + "&IncentiveId=" + lblIncentiveID + "&SubIncTypeId=" + lblSubIncentiveID + "&Distid=" + Request.QueryString[3].ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void GVDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSubIncentiveID = (e.Row.FindControl("lblSubIncentiveID") as Label);
                Label lblIncentiveID = (e.Row.FindControl("lblIncentiveID") as Label);

                Button btnsanction = (e.Row.FindControl("btnSanctionlist") as Button);


            }
        }
    }
}