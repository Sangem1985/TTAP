using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TTAP.Classfiles;

namespace TTAP.UI.Pages.COI
{
    public partial class ADRTGSDashboardDrilldown : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet(); int totalclaims;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                if (!IsPostBack)
                {
                    if (Session["uid"] != null && Request.QueryString.Count > 0)
                    {
                        GetDashboard();
                    }

                }
            }
            catch (Exception ex)

            {

                throw ex;
            }



        }
        public void GetDashboard()
        {
            string status = Convert.ToString(Request.QueryString["status"]);
            string Type = Convert.ToString(Request.QueryString["Type"]);

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@StatusType",SqlDbType.VarChar),
               new SqlParameter("@Type",SqlDbType.VarChar),
                };
            pp[0].Value = status;
            pp[1].Value = Type;

            dss = caf.GenericFillDs("USP_ADRTGSDASHBOARD_DRILLDOWN_CASTEWISE", pp);
            if (dss != null && dss.Tables.Count > 0 && dss.Tables[0].Rows.Count > 0)
            {
                gvdetails.DataSource = dss.Tables[0];
                gvdetails.DataBind();

                if (status == "SLC_Approved") { }
                else if (status == "SLC_ReleaseProcCompleted") { }
                else if (status == "SLC_UCUpdated") { }
                else if (status == "SLC_UCNotUpdated") { }
                else if (status == "SLC_ToGenerateCheque") { }
                else if (status == "SLC_GeneratedCheque") { }
                else if (status == "SLC_GeneratedCheque") { }
                else if (status == "SLC_Cheque_withNo") { }
                else if (status == "SLC_Cheque_withUTR") { }

                else if (status == "DIPC_Approved") { }
                else if (status == "DIPC_ReleaseProcCompleted") { }
                else if (status == "DIPC_UCUpdated") { }
                else if (status == "DIPC_UCNotUpdated") { }
                else if (status == "DIPC_ToGenerateCheque") { }
                else if (status == "DIPC_GeneratedCheque") { }
                else if (status == "DIPC_ChequeNotUploaded") { }
                else if (status == "DIPC_Cheque_withNo") { }
                else if (status == "DIPC_Cheque_withUTR") { }

            }


        }


        protected void gvdetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblNoClaims = (Label)e.Row.FindControl("lblNoClaims");
                Button btnProcess = (Button)e.Row.FindControl("btnProcess");

                if (lblNoClaims.Text != "")
                {

                    totalclaims = totalclaims + Convert.ToInt32(lblNoClaims.Text);
                }
                else
                { btnProcess.Visible = false; }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalClaims = (Label)e.Row.FindControl("lblTotalClaims");
                lblTotalClaims.Text = Convert.ToString(totalclaims);
            }
        }
        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                GridViewRow row = (GridViewRow)btn.NamingContainer;
                Label lblCategoryid = (Label)row.FindControl("lblCategoryid");
                Label lblSubIncentiveID = (Label)row.FindControl("lblSubIncentiveID");
                Label lblIncentiveID = (Label)row.FindControl("lblIncentiveID");
                Label lblDipcFlag = (Label)row.FindControl("lblDipcFlag");           


                Response.Redirect("~/UI/Pages/CheckDetailsPrint.aspx?Cast=" + lblCategoryid.Text + "&IncentiveId=" + lblIncentiveID.Text + "&SubIncTypeId=" + lblSubIncentiveID.Text + "&DIPC=" + lblDipcFlag.Text);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}