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
    public partial class frmUserPaymentDetails : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] != null)
            {
                if (!IsPostBack)
                {
                    string IncentiveID = Request.QueryString["Id"].ToString();
                    DataSet ds = new DataSet();
                    ds = GetAllIncentives(IncentiveID);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        grdDetails.DataSource = ds;
                        grdDetails.DataBind();
                        
                        double TotalValue = 0;
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            double Value = Convert.ToDouble(row["TotalAmount"].ToString());
                            TotalValue = TotalValue + Value;
                        }
                        lblTotalAmount.InnerHtml = TotalValue.ToString();

                        if (ds != null && ds.Tables.Count > 1 && ds.Tables[1].Rows.Count > 0)
                        {
                            gvPaymentDetails.DataSource = ds.Tables[1];
                            gvPaymentDetails.DataBind();
                            divrtgspayment.Visible = true;
                        }
                    }
                }
            }
            else
            {

            }
        }
        public DataSet GetAllIncentives(string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("[USP_GET_PAYMENT_DTLS_INCENTIVES_USER]", pp);
            return Dsnew;
        }
    }
}