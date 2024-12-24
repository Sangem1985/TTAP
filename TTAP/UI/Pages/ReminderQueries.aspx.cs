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
    public partial class ReminderQueries : System.Web.UI.Page
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
                        if (Request.QueryString["UserType"] != null)
                        {
                            trUnitName.Visible = false;
                            trIncentive.Visible = false;
                            divSave.Visible = false;
                            BindReminderDetails(hdnIncentiveId.Value, "0", Request.QueryString["UserType"].ToString());

                        }
                        else
                        {
                            hdnSubIncentiveId.Value = Request.QueryString["SubIncentiveId"].ToString();
                            BindReminderDetails(hdnIncentiveId.Value, hdnSubIncentiveId.Value,"");
                            if (hdnRolecode.Value != "DLO")
                            {
                                divSave.Visible = false;
                            }
                        }
                    }
                }
            }
        }
        protected void BindReminderDetails(string IncentiveId,string SubIncentiveId,string user)
        {
            try
            {
                DataSet dsnew = new DataSet();
                dsnew = GetReminderDetails(IncentiveId, SubIncentiveId, user);

                if (dsnew != null && dsnew.Tables.Count > 0 && dsnew.Tables[0].Rows.Count > 0)
                {
                    txtUnitName.Text= dsnew.Tables[0].Rows[0]["UnitName"].ToString();
                    txtApplicationNo.Text= dsnew.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                    txtIncentiveName.Text= dsnew.Tables[0].Rows[0]["IncentiveName"].ToString();
                    hdnUnitId.Value= dsnew.Tables[0].Rows[0]["UnitId"].ToString();
                    txtQueryDate.Text= dsnew.Tables[0].Rows[0]["QueryRaisedDate"].ToString();
                    int DayCount= Convert.ToInt32(dsnew.Tables[0].Rows[0]["DayCount"].ToString());
                    gvGridReminders.DataSource = dsnew.Tables[1];
                    gvGridReminders.DataBind();
                    GVUserReminder.DataSource = dsnew.Tables[2];
                    GVUserReminder.DataBind();
                    if (Request.QueryString["UserType"] != null)
                    {
                        divUserReminderGrid.Visible = true;
                        divGridReminder.Visible = false;
                    }
                    else
                    {
                        divGridReminder.Visible = true;
                        divUserReminderGrid.Visible = false;
                        if (DayCount > 35)
                        {
                            if (gvGridReminders.Rows.Count > 2)
                            {
                                string Msg = "It has been " + DayCount + " days since you raised the Query but the unit holder has not given any response, you can reject this incentive application if you sent two reminders already.";
                                lblInfo.Text = Msg;
                                divReject.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    gvGridReminders.DataSource = null;
                    gvGridReminders.DataBind();
                    GVUserReminder.DataSource = null;
                    GVUserReminder.DataBind();
                    divGridReminder.Visible = false;
                    divUserReminderGrid.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet GetReminderDetails(string IncentiveId, string SubIncentiveId,string User)
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
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {  
                if (txtDesc.Text == "")
                {
                    string message = "alert('Please enter Reminder Description/Remarks')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                string UnitName = txtUnitName.Text; ;
                string UnitId = hdnUnitId.Value.ToString();
                int IncentiveId = Convert.ToInt32(hdnIncentiveId.Value.ToString());
                int SubIncentiveId= Convert.ToInt32(hdnSubIncentiveId.Value.ToString());
                string Reminder = txtDesc.Text.ToString();
                int CreatedBy= Convert.ToInt32(hdnUserId.Value.ToString());

                string Validstatus = InsertReminderDetails(IncentiveId, SubIncentiveId, UnitId, UnitName, Reminder, CreatedBy);
                if (Validstatus != null && Validstatus != "" && Validstatus != "0")
                {
                    try
                    {
                        ClsSMSandMail ClsSMSandMailobj = new ClsSMSandMail();
                        ClsSMSandMailobj.SendSmsEmail(hdnIncentiveId.Value.ToString(), hdnSubIncentiveId.Value.ToString(), "USER", "QUERYREMINDER", "Incentives");
                    }
                    catch (Exception ex)
                    {
                        string errorMsg = ex.Message;
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Reminder Sent successfully');", true);
                    txtDesc.Text = "";
                    BindReminderDetails(hdnIncentiveId.Value, hdnSubIncentiveId.Value,"");

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Failed');", true);
                    BindReminderDetails(hdnIncentiveId.Value, hdnSubIncentiveId.Value,"");
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
        public string InsertReminderDetails(int IncentiveId,int SubIncentiveId,string UnitId,string UnitName,string Reminder,int CreatedBy)
        {
            string valid = "";
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                SqlCommand com = new SqlCommand();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "USP_INS_QUERY_REMINDERS";

                com.Transaction = transaction;
                com.Connection = connection;

                com.Parameters.AddWithValue("@IncentiveId", IncentiveId);
                com.Parameters.AddWithValue("@SubIncentiveId", SubIncentiveId);
                com.Parameters.AddWithValue("@UnitId", UnitId);
                com.Parameters.AddWithValue("@Reminder", Reminder);
                com.Parameters.AddWithValue("@CreatedBy", CreatedBy);
               
                com.Parameters.Add("@Valid", SqlDbType.VarChar, 500);
                com.Parameters["@Valid"].Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();

                valid = com.Parameters["@Valid"].Value.ToString();

                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
            return valid;
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                string errormsg = "Please enter Rejection Remarks";
                if (gvGridReminders.Rows.Count < 2)
                {
                    string message = "alert('You cannot Reject the Application if you not sent atleast two Reminders')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                if (txtRejectRemarks.Text=="")
                {
                    string message = "alert('" + errormsg + "')";
                    ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    return;
                }
                else
                {
                    ApplicationStatus ObjApplicationStatus = new ApplicationStatus();
                    UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                    ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                    int IncentiveId = Convert.ToInt32(hdnIncentiveId.Value.ToString());
                    int SubIncentiveId = Convert.ToInt32(hdnSubIncentiveId.Value.ToString());

                    ObjApplicationStatus.IncentiveId = hdnIncentiveId.Value.ToString();
                    ObjApplicationStatus.SubIncentiveId = hdnSubIncentiveId.Value.ToString();
                    ObjApplicationStatus.CreatedBy = hdnUserId.Value.ToString();
                    ObjApplicationStatus.TransType = "3"; /*Reject*/
                    
                    ObjApplicationStatus.Remarks = txtRejectRemarks.Text.Trim().TrimStart();
                    

                    string Status = caf.UpdateApplicationStatusDLOStage1(ObjApplicationStatus);

                    if (Convert.ToInt32(Status) > 0)
                    {
                        string Successmsg = "Application Rejected Successfully";
                        txtRejectRemarks.Text = "";
                        string message = "alert('" + Successmsg + "')";
                        ScriptManager.RegisterClientScriptBlock((sender as Control), this.GetType(), "alert", message, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Errors.ErrorLog(ex);
                LogErrorFile.LogerrorDB(ex, HttpContext.Current.Request.Url.AbsoluteUri, Session["uid"].ToString());
            }
        }
    }
}