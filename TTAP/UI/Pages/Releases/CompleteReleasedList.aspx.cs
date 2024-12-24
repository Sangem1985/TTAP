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
using System.Web.Script.Serialization;
using System.Web.Services;

namespace TTAP.UI.Pages.Releases
{
    public partial class CompleteReleasedList : System.Web.UI.Page
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
                string Stage = "1";
                string ApplicationMode = "1";
                string Category = "";
                string SubIncentiveID = "";
                string GOID = "";

                    DataSet ds = new DataSet();
                    ds = ObjCAFClass.GetCompleteReleasedIncentivesList(Stage);
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {   
                        gvdetailsnew.DataSource = ds.Tables[0];
                        gvdetailsnew.DataBind();
                        btnSubmit.Visible = true;
                    }
                    else
                    {
                        btnSubmit.Visible = false;
                    }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
        }
       
        public class Incentive
        {
            public string IncentiveID { get; set; }
            public string SubIncentiveID { get; set; }
            public string GOID { get; set; }
            public string SanctionedAmount { get; set; }
            public string PreviousBalanceAmount { get; set; }
            public string ReleasedAmount { get; set; }
            public string CurrentBalanceAmount { get; set; }
            public string ReleaseProcedingNo { get; set; }
            public string ReleaseProcedingDate { get; set; }
            public string ReleaseProcedingFilePath { get; set; }
            public string Released_By { get; set; }
            public string Released_Date { get; set; }
            public string GONo { get; set; }
            public string IncentiveName { get; set; }
            public string UnitName { get; set; }
            public string ApplicationNumber { get; set; }
            public string TIPRID { get; set; }
        }
    }
}