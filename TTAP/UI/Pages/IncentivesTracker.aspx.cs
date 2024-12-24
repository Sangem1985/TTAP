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

namespace TTAP.UI.Pages
{
    public partial class IncentivesTracker : System.Web.UI.Page
    {
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["uid"] != null)
                    {
                        string Enterid = "";
                        if (Request.QueryString["Enterid"] != null)
                        {
                            Enterid = Request.QueryString["Enterid"].ToString();
                        }
                        dss = GetApplicationsstatus(Enterid);
                        if (dss.Tables.Count > 0)
                        {
                            if (dss.Tables[0].Rows.Count > 0)
                            {
                                gvdetailsnew.DataSource = dss;
                                gvdetailsnew.DataBind();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }

        public DataSet GetApplicationsstatus(string Enterid)
        {
            DataSet Dsnew = new DataSet();
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveID",SqlDbType.VarChar)
              
           };
            pp[0].Value = Enterid;
           
            // Dsnew = caf.GenericFillDs("USP_GET_DLOAPPLICATIONS", pp);
            Dsnew = caf.GenericFillDs("USP_GET_APPLICATION_STATUS", pp);

            return Dsnew;
        }
    }
}