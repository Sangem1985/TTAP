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
using BusinessLogic;
using System.IO;

namespace TTAP.UI.Pages
{
    public partial class InspectionDelayNotes : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
        private SqlConnection ConNew = new SqlConnection(ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString);
        CAFClass caf = new CAFClass();
        DataSet dss = new DataSet();

        Fetch objFetch = new Fetch();
        General Objgeneral = new General();
        comFunctions cmf = new comFunctions();
        ClsFileUpload objClsFileUpload = new ClsFileUpload();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ObjLoginvo"] != null)
            {
                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                hdnUserId.Value = ObjLoginNewvo.uid.ToString();
                hdnRolecode.Value = ObjLoginNewvo.Role_Code.ToString();
                if (!IsPostBack)
                {
                    if (Request.QueryString["IncentiveId"] != null)
                    {
                        hdnIncentiveId.Value = Request.QueryString["IncentiveId"].ToString();
                        hdnSubIncentiveId.Value = Request.QueryString["SubIncentiveId"].ToString();
                        hdnInspectionId.Value = Request.QueryString["InspectionId"].ToString();
                    }
                }
            }
        }
        protected void BindReminderDetails(string IncentiveId, string SubIncentiveId, string user)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetInspectionDelayDetails(IncentiveId, SubIncentiveId, user);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    txtUnitName.Text = dsnew.Tables[0].Rows[0]["UnitName"].ToString();
                    txtApplicationNo.Text = dsnew.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                    txtIncentiveName.Text = dsnew.Tables[0].Rows[0]["IncentiveName"].ToString();
                    hdnUnitId.Value = dsnew.Tables[0].Rows[0]["UnitId"].ToString();
                    txtQueryDate.Text = dsnew.Tables[0].Rows[0]["QueryRaisedDate"].ToString();
                    int DayCount = Convert.ToInt32(dsnew.Tables[0].Rows[0]["DayCount"].ToString());
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet GetInspectionDelayDetails(string IncentiveId, string SubIncentiveId, string User)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.VarChar),
               new SqlParameter("@SubIncentiveId",SqlDbType.VarChar),
               new SqlParameter("@UserType",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = SubIncentiveId;
            pp[2].Value = User;
            Dsnew = caf.GenericFillDs("USP_GET_QUERY_REMINDER_DTLS", pp);
            return Dsnew;
        }
    }
}