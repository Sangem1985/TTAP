using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BusinessLogic;
using TTAP.Classfiles;

namespace TTAP.UI.Pages
{
    public partial class InscentiveView_AttachmentsNewIncType : System.Web.UI.Page
    {
        comFunctions obcmf = new comFunctions();
        Fetch objFetch = new Fetch();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session.Count <= 0)
                {
                    Response.Redirect("~/LoginReg.aspx", false);
                    return;
                }
                if (!Page.IsPostBack)
                {
                    obcmf.FillGrid(objFetch.FetchIncentiveTypesView_NewIncType(Convert.ToInt32(Request.QueryString["EntrpId"].ToString())), gvIncetiveTypes, false);
                }
                
                Fetch obj = new Fetch();
                DataTable dt = obj.FetchIncentiveDtlsbyIncentiveID_NewIncType(Request.QueryString["EntrpId"].ToString());
                lblEmNo.Text = dt.Rows[0]["EIN_IEM_IL_Number"].ToString();
                lblUnitName.Text = dt.Rows[0]["UnitName"].ToString();
                lblApplicantname.Text = dt.Rows[0]["ApplciantName"].ToString();
                lblMobileNumber.Text = dt.Rows[0]["MobileNo"].ToString();
                lblCategory.Text = dt.Rows[0]["Category"].ToString();
                lblapplicationnumber.Text = dt.Rows[0]["ApplicationNumber"].ToString();
                lblDateofAppln.Text = dt.Rows[0]["lblDateofAppln"].ToString();
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                // Errors.ErrorLog(ex);
            }
        }

        protected void lbtIncentive_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow gr = (((LinkButton)sender).Parent.Parent as GridViewRow);
                obcmf.FillGrid(objFetch.FetchIncentiveTypesView_NewIncType(Convert.ToInt32((gr.FindControl("lblEntrpId") as Label).Text)), gvIncetiveTypes, false);
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                //Errors.ErrorLog(ex);
            }
        }
    }
}