using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TTAP.Classfiles;
using BusinessLogic;
using System.Data.SqlClient;

namespace TTAP.UI.Pages
{
    public partial class EnterQueryResponse : System.Web.UI.Page
    {
        General Gen = new General();
        comFunctions cmf = new comFunctions();
        comFunctions obcmf = new comFunctions();
        Fetch objFetch = new Fetch();
        CAFClass ObjCAFClass = new CAFClass();


        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string incentiveid = "";
            string QueryRaisedAt = "";
            if (Request.QueryString.Count > 0 && Request.QueryString[0].ToString() != null && Request.QueryString[0].ToString() != "")
            {
                incentiveid = Request.QueryString[0].ToString();
            }
            if (Request.QueryString.Count > 1 && Request.QueryString["COMM"] != null && Request.QueryString["COMM"].ToString() != "")
            {
                QueryRaisedAt = Request.QueryString["COMM"].ToString();
            }
            /*if (Request.QueryString.Count > 1 && Request.QueryString["ViewType"].ToString() != null && Request.QueryString["ViewType"].ToString() != "")
            {
                hdnQuery.Value = Request.QueryString["ViewType"].ToString();
            }*/
            //ds = Gen.GetQueryDetailsdept(Session["uid"].ToString(),"","","ALL","");
            ds = Gen.GetQueryDetailsdept(Session["uid"].ToString(), incentiveid, "", "ALL", QueryRaisedAt);
            try
            {
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdDetails.DataSource = ds.Tables[0];
                    grdDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }
        protected void grdDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label enterid = (e.Row.FindControl("lblIncentiveID") as Label);
                Label MstIncentiveId = (e.Row.FindControl("lblMstIncentiveId") as Label);
                Label lblJdOrGMflag = (e.Row.FindControl("lblJdOrGMflag") as Label);
                

                (e.Row.FindControl("anchortaglink") as HyperLink).NavigateUrl = "frmResptoIncQry.aspx?EntrpId=" + enterid.Text.Trim() + "&Inctypeid=" + MstIncentiveId.Text + "&JdOrGMflag=" + lblJdOrGMflag.Text;
            }
        }
    }
}