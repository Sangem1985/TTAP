using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using TTAP.Classfiles;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace TTAP
{
    public partial class loginReg : System.Web.UI.Page
    {
        UserRegistrationOldVo objcommon = new UserRegistrationOldVo();
        DataRetrivalClass Objret = new DataRetrivalClass();
        UserLoginVo ObjLoginvo = new UserLoginVo();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Response.Redirect("https://ipass.telangana.gov.in/IpassLogin.aspx");
                if (!IsPostBack)
                {
                    string encpassword1 = Objret.Decrypt("6QfQ4MssPzLsabg+d54SsufL+/5DUq+paSIh0pt/iTU=", "SYSTIME");
                    ViewState["IPASSFlg"] = "";
                    if (Request.QueryString["UserId"] != null && Request.QueryString["UserCode"] != null && Request.QueryString["Flg"] != null)
                    {
                        string UserId = Request.QueryString["UserId"].ToString();
                        string UserCode = Request.QueryString["UserCode"].ToString();
                        string Flg = Request.QueryString["Flg"].ToString();
                        if (Flg.Trim().TrimStart() == "Y")
                        {
                            ViewState["IPASSFlg"] = "Y";
                            Session["IPASSFlag"] = "Y";
                            /*string Decrypt = Objret.Decrypt(UserCode.Replace(" ", "+"), "SYSTIME");*/
                            string Decrypt = UserCode;
                            txtpsw.TextMode = TextBoxMode.SingleLine;
                            txtuname.Text = UserId;
                            txtpsw.Text = Decrypt;
                            lnkbtnLogin_Click(sender, e);
                        }
                        else
                        {
                            ViewState["IPASSFlg"] = "Y";
                            //txtpsw.TextMode = TextBoxMode.SingleLine;
                            txtpsw.TextMode = TextBoxMode.Password;
                            txtuname.Text = UserId;
                            txtpsw.Text = UserCode;
                            lnkbtnLogin_Click(sender, e);
                        }
                    }
                }
                txtuname.Focus();
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;
            }
        }
        protected void lnkbtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string CreateBy = "";
                string Role = "";
                string User_level= "";
                string User_Type = "";
                string Fromname = "";
                string DistrictID= "";
                if (String.IsNullOrEmpty(txtuname.Text) || String.IsNullOrEmpty(txtpsw.Text))
                {
                    lblmsg0.Text = "Please provide User Name and Password";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
                    Failure.Visible = true;
                }
                else
                {
                    success.Visible = false;
                    Failure.Visible = false;
                    string UserID = "", Password = "";
                    //string Dept = "";
                    UserID = txtuname.Text;
                    Password = txtpsw.Text;
                    //Dept = "%";

                    bool CaptchaResult = true;
                    string CErrormsg = "";
                    /*if (ViewState["IPASSFlg"] != null && ViewState["IPASSFlg"].ToString() != "" && ViewState["IPASSFlg"].ToString() == "Y")
                    {
                        CaptchaResult = true;
                    }
                    if (System.Configuration.ConfigurationManager.AppSettings["IsServer"].ToString() == "false") 
                    {
                        CaptchaResult = true;
                    }
                    else
                    {
                        CaptchaResult = ValidateCaptcha(out CErrormsg);
                    }*/
                     string encpassword1 = Objret.Decrypt("4qVgJQDe+uOrnltk568zv4aTNkIhpP8TKUqSR8wyfc0=", "SYSTIME");
                    if (CaptchaResult)
                    {
                        string encpassword = Objret.Encrypt(Password, "SYSTIME");
                        if (Request.QueryString.Count > 3) {
                            if (Request.QueryString["CreateBy"] != null) {
                                CreateBy = Request.QueryString["CreateBy"].ToString();
                                Role = Request.QueryString["Role"].ToString();
                                User_level = Request.QueryString["User_level"].ToString();
                                Fromname = Request.QueryString["Fromname"].ToString();
                                DistrictID = Request.QueryString["DistrictID"].ToString();
                                User_Type= Request.QueryString["User_type"].ToString();
                            }
                        }
                        DataSet ds = Objret.ValidateLoginNew(UserID, Password, encpassword, CreateBy, Role, User_level,
                            Fromname, DistrictID, User_Type);//,Dept
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            DataView dv = ds.Tables[0].DefaultView;
                            DataSet dsnew = new DataSet();

                            if (dv.Table.Rows.Count > 0)
                            {
                                UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();

                                Session["uid"] = ObjLoginNewvo.uid = dv.Table.Rows[0]["intUserid"].ToString();
                                Session["username"] = ObjLoginNewvo.username = dv.Table.Rows[0]["User_name"].ToString();
                                Session["user_id"] = ObjLoginNewvo.user_id = dv.Table.Rows[0]["User_id"].ToString();
                                Session["password"] = ObjLoginNewvo.password = dv.Table.Rows[0]["password"].ToString();
                                Session["userlevel"] = ObjLoginNewvo.userlevel = dv.Table.Rows[0]["User_level"].ToString();
                                Session["user_type"] = ObjLoginNewvo.user_type = dv.Table.Rows[0]["User_type"].ToString();
                                Session["Type"] = ObjLoginNewvo.Type = dv.Table.Rows[0]["Fromname"].ToString();
                                Session["MobileNumber"] = ObjLoginNewvo.MobileNumber = dv.Table.Rows[0]["MobileNumber"].ToString();
                                Session["Email"] = ObjLoginNewvo.Email = dv.Table.Rows[0]["EmailE"].ToString();
                                Session["Role_Code"] = ObjLoginNewvo.Role_Code = dv.Table.Rows[0]["Role_Code"].ToString();
                                Session["DistrictID"] = ObjLoginNewvo.DistrictID = dv.Table.Rows[0]["DistrictID"].ToString();
                                Session["RDDDistID"] = ObjLoginNewvo.RDD_Dist = dv.Table.Rows[0]["DistrictID"].ToString();
                                Session["User_Code"] = ObjLoginNewvo.User_Code = dv.Table.Rows[0]["User_code"].ToString();
                                Session["intDeptid"] = ObjLoginNewvo.intDeptid = dv.Table.Rows[0]["intDeptid"].ToString();
                                Session["Visibleflag"] = ObjLoginNewvo.Visibleflag = dv.Table.Rows[0]["Visibleflag"].ToString();
                                Session["DummyLogin"] = ObjLoginNewvo.DummyLogin = dv.Table.Rows[0]["DummyLogin"].ToString();
                                Session["DefaultPwd"] = ObjLoginNewvo.DefaultPwd = dv.Table.Rows[0]["DefaultPwd"].ToString();
                                Session["PwdEncryflag"] = ObjLoginNewvo.PwdEncryflag = dv.Table.Rows[0]["PwdEncryflag"].ToString();
                                Session["ECAF"] = ObjLoginNewvo.ECAF = "N";
                                //ObjLoginNewvo.DigiLockerID = dv.Table.Rows[0]["DigilockerID"].ToString();
                                //Session["RoleId"] = ObjLoginNewvo.RoleId = dv.Table.Rows[0]["RoleId"].ToString();

                                //Session["DistrictId"] = GetDistrictIdofDLO(ObjLoginNewvo.uid);
                                if (Session["DistrictId"].ToString() != "")
                                {
                                    ObjLoginNewvo.DistrictID = Session["DistrictId"].ToString();
                                }
                                else 
                                {
                                    Session["DistrictId"] = GetDistrictIdofDLO(ObjLoginNewvo.uid);
                                }

                                ObjLoginNewvo.FirstName = dv.Table.Rows[0]["Firstname"].ToString();
                                ObjLoginNewvo.LastName = dv.Table.Rows[0]["Lastname"].ToString();
                                Session["Encpassword"] = ObjLoginNewvo.Encpassword = dv.Table.Rows[0]["Encpassword"].ToString();

                                Session["ObjLoginvo"] = ObjLoginNewvo;
                                Response.Redirect("UI/UserDashBoard.aspx");
                                //Response.Redirect("UI/preaproval/ca_home.aspx");

                            }
                            else
                            {
                                lblmsg0.Text = "Invalid UserName or Password";
                                txtpsw.Text = "";
                                Failure.Visible = true;
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
                            }
                        }
                        else
                        {
                            lblmsg0.Text = "Invalid UserName or Password";
                            txtpsw.Text = "";
                            Failure.Visible = true;
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
                        }
                    }
                    else
                    {
                        lblmsg0.Text = CErrormsg;
                        Failure.Visible = true;
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "AnotherFunction();", true);
                    }
                }
            }
            catch (SqlException ex)
            {
                string errorMsg = ex.Message;
                lblmsg0.Text = "Internal error has occured. Please try after some time";
                //lblmsg.Text = ex.Message;
                Failure.Visible = true;
            }
            catch (Exception ex)
            {
                lblmsg0.Text = ex.Message;
                Failure.Visible = true;

                //lblmsg0.Text = "Internal error has occured. Please try after some time";
                //lblmsg.Text = ex.Message;
            }
        }
        public static string getclientIP()
        {
            string result = string.Empty;
            string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ip))
            {
                string[] ipRange = ip.Split(',');
                int le = ipRange.Length - 1;
                result = ipRange[0];
            }
            else
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return result;
        }
        public string LoginHistory(string Userid, string ip)
        {
            string str = ConfigurationManager.ConnectionStrings["Kumdb"].ConnectionString;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction transaction = null;
            string validup = "";
            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                SqlCommand cmdEnj = new SqlCommand("USP_INS_LOGININFO", connection);
                cmdEnj.CommandType = CommandType.StoredProcedure;
                cmdEnj.Transaction = transaction;
                cmdEnj.Connection = connection;

                //SqlDataAdapter da1 = new SqlDataAdapter(cmdEnj);
                cmdEnj.Parameters.AddWithValue("@USERID", Userid);
                cmdEnj.Parameters.AddWithValue("@SysIp", ip);
                cmdEnj.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return validup;
        }
        public int GetDistrictIdofDLO(string UserId)
        {
            CAFClass caf = new CAFClass();
            DataSet Dsnew = new DataSet();
            int distid = 0;
            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@UserId",SqlDbType.NVarChar),
           };
            pp[0].Value = UserId;

            Dsnew = caf.GenericFillDs("getDistrictIdbyUserId", pp);
            if (Dsnew.Tables.Count > 0)
            {
                if (Dsnew.Tables[0].Rows.Count > 0)
                {
                    distid = Convert.ToInt32(Dsnew.Tables[0].Rows[0]["DistId"].ToString());
                }
            }
            return distid;
        }

        // Captcha

        private bool ValidateCaptcha(out string ErrorMsg)
        {
            ErrorMsg = "";
            bool recaptcharesult = false;
            //start building recaptch api call
            var sb = new StringBuilder();
            sb.Append("https://www.google.com/recaptcha/api/siteverify?secret=");

            //our secret key
            var secretKey = ConfigurationManager.AppSettings["GCaptchSecretKey"].ToString(); //"6Lc2Dj4cAAAAAHZ__w-FBtWw9gDXHXteSfp7OMgl";
            sb.Append(secretKey);

            //response from recaptch control
            sb.Append("&");
            sb.Append("response=");
            var reCaptchaResponse = Request["g-recaptcha-response"];
            sb.Append(reCaptchaResponse);

            //client ip address
            //---- This Ip address part is optional. If you donot want to send IP address you can
            //---- Skip(Remove below 4 lines)
            sb.Append("&");
            sb.Append("remoteip=");
            var clientIpAddress = GetUserIp();
            sb.Append(clientIpAddress);

            //make the api call and determine validity
            using (var client = new WebClient())
            {
                var uri = sb.ToString();
                var json = client.DownloadString(uri);
                var serializer = new DataContractJsonSerializer(typeof(RecaptchaApiResponse));
                var ms = new MemoryStream(Encoding.Unicode.GetBytes(json));
                var result = serializer.ReadObject(ms) as RecaptchaApiResponse;

                //--- Check if we are able to call api or not.
                if (result == null)
                {
                    ErrorMsg = "Captcha was unable to make the api call";
                }
                else // If Yes
                {
                    //api call contains errors
                    recaptcharesult = result.Success;
                    if (result.ErrorCodes != null)
                    {
                        if (result.ErrorCodes.Count > 0)
                        {
                            foreach (var error in result.ErrorCodes)
                            {
                                ErrorMsg = "reCAPTCHA Error: " + error;
                            }
                        }
                    }
                    else //api does not contain errors
                    {
                        if (!result.Success) //captcha was unsuccessful for some reason
                        {
                            ErrorMsg = "Captcha did not pass, please try again.";
                        }
                        else //---- If successfully verified. Do your rest of logic.
                        {
                            ErrorMsg = "Captcha cleared ";
                        }
                    }
                }
            }
            return recaptcharesult;
        }

        [DataContract]
        public class RecaptchaApiResponse
        {
            [DataMember(Name = "success")]
            public bool Success;

            [DataMember(Name = "error-codes")]
            public List<string> ErrorCodes;
        }

        //--- To get user IP(Optional)
        private string GetUserIp()
        {
            var visitorsIpAddr = string.Empty;

            if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                visitorsIpAddr = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            else if (!string.IsNullOrEmpty(Request.UserHostAddress))
            {
                visitorsIpAddr = Request.UserHostAddress;
            }

            return visitorsIpAddr;
        }
    }
}