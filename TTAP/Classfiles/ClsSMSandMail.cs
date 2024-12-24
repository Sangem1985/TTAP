using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Configuration;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace TTAP.Classfiles
{
    public class ClsSMSandMail
    {
        DB.DB con = new DB.DB();
        public string SendSMS(string strTo, string strMessage, string Module, string SubModule)
        {
            // "3fd03678-b243-496c-bbe1-a2e8cf220b23", "KUMGOK",
            string strKey = ConfigurationManager.AppSettings["SmsKey"].ToString();
            string strFrom = ConfigurationManager.AppSettings["SmsUserID"].ToString();
            string strsmsUrl = ConfigurationManager.AppSettings["SmsURL"].ToString();

            string str2 = string.Empty;
            try
            {
                string s = "{\"outboundSMSMessageRequest\":{\"address\":[\"tel:!address!\"],\"senderAddress\":\"tel:!sendername!\",\"outboundSMSTextMessage\":{\"message\":\"!message!\"},\"clientCorrelator\":\"\",\"receiptRequest\": {\"notifyURL\":\"\",\"callbackData\":\"$(callbackData)\"} ,\"messageType\":\"4\",\"senderName\":\"\"}}".Replace("!address!", strTo).Replace("!sendername!", HttpUtility.UrlEncode(strFrom)).Replace("!key!", strKey).Replace("!message!", strMessage);
                // HttpWebRequest request = WebRequest.Create("http://smspush.openhouseplatform.com/smsmessaging/1/outbound/tel%3A%2BDETGOV/requests") as HttpWebRequest;
                HttpWebRequest request = WebRequest.Create(strsmsUrl) as HttpWebRequest;

                request.Method = "POST";
                request.Timeout = 0xc350;
                request.ContentType = "application/json";
                byte[] bytes = Encoding.UTF8.GetBytes(s);
                request.ContentLength = bytes.Length;
                request.Headers.Add("key", strKey);
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    str2 = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    try
                    {
                        SMSANDMAILDetails(strTo, strMessage, Module, SubModule, "SMS");
                    }
                    catch (Exception ex)
                    {
                        string errorMsg = ex.Message;
                    }
                }
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
            return str2;
        }

        public void SMSANDMAILDetails(string MobileNo, string SMSText, string Module, string SubModule, string Mode)
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("USP_INS_SMS_MAIL_DTLS", con.GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@MobileNo", Convert.ToString(MobileNo));
                cmd.Parameters.AddWithValue("@SMSText", Convert.ToString(SMSText));
                cmd.Parameters.AddWithValue("@Module", Convert.ToString(Module));
                cmd.Parameters.AddWithValue("@SubModule", Convert.ToString(SubModule));
                cmd.Parameters.AddWithValue("@Mode", Convert.ToString(Mode));
                cmd.ExecuteNonQuery();
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                con.CloseConnection();
            }
        }
        public void SaveOTPDetails(string MobileNo, string OTP, string Module, string SubModule, string Mode)
        {
            con.OpenConnection();
            SqlCommand cmd = new SqlCommand("USP_INS_OTP_DTLS", con.GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@MobileNo", Convert.ToString(MobileNo));
                cmd.Parameters.AddWithValue("@OTP", Convert.ToString(OTP));
                cmd.Parameters.AddWithValue("@Module", Convert.ToString(Module));
                cmd.Parameters.AddWithValue("@SubModule", Convert.ToString(SubModule));
                cmd.Parameters.AddWithValue("@Mode", Convert.ToString(Mode));
                cmd.ExecuteNonQuery();
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                con.CloseConnection();
            }
        }

        //public void SendEmail(string strTo, string CCmails, string strMessage, string Module, string SubModule)
        //{
        //    try
        //    {
        //        string FromEmailId = Convert.ToString(ConfigurationManager.AppSettings["FromMail"]);
        //        string Password = Convert.ToString(ConfigurationManager.AppSettings["FromMailPwd"]);
        //    }
        //    catch (Exception exception1)
        //    {
        //        throw exception1;
        //    }
        //}
        public void SendEmail(string strTo, string CCmails, string EmailSubject, string EmailText, string AttachmentPath, string Module, string SubModule)
        {
            // string path = "";
            string EmailSend = "";
            string FromEmailId;
            string Password;

            try
            {
                try
                {
                    FromEmailId = Convert.ToString(ConfigurationManager.AppSettings["FromMail"]);
                    Password = Convert.ToString(ConfigurationManager.AppSettings["FromMailPwd"]);


                    MailMessage message = new MailMessage(FromEmailId, strTo)
                    {
                        Subject = EmailSubject,
                        Body = EmailText
                    };
                    if ((Convert.ToString(ConfigurationManager.AppSettings["IsAttchmentsAllowed"]) == "true") && (Convert.ToString(AttachmentPath) != ""))
                    {
                        message.Attachments.Add(new Attachment(Convert.ToString(AttachmentPath)));
                    }
                    if (Convert.ToString(CCmails) != "")
                    {
                        foreach (string str4 in Convert.ToString(CCmails).Split(new char[] { ',' }))
                        {
                            message.CC.Add(new MailAddress(str4 ?? ""));
                        }
                    }
                    message.IsBodyHtml = Convert.ToString(ConfigurationManager.AppSettings["IsBodyHtml"]) == "true";
                    SmtpClient client = new SmtpClient
                    {
                        Host = Convert.ToString(ConfigurationManager.AppSettings["Host"]),
                        Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]),
                        UseDefaultCredentials = (Convert.ToString(ConfigurationManager.AppSettings["UseDefaultCredentials"]) != "true") ? false : true
                    };
                    if (!client.UseDefaultCredentials)
                    {
                        client.Credentials = new NetworkCredential(FromEmailId, Password);
                    }
                    client.EnableSsl = Convert.ToString(ConfigurationManager.AppSettings["EnableSsl"]) == "true";

                    client.Send(message);
                    EmailSend = "Y";

                    try
                    {
                        SMSANDMAILDetails(strTo, EmailText, Module, SubModule, "Email");
                    }
                    catch (Exception ex)
                    {
                        string errorMsg = ex.Message;
                    }
                }
                catch (Exception exception1)
                {
                    EmailSend = "N";
                    Errors.ErrorLog(exception1);
                    LogErrorFile.LogerrorDB(exception1, HttpContext.Current.Request.Url.AbsoluteUri, "0");
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
            }
        }

        public void SendSmsEmail(string incentiveid, string Mstincentiveid, string Role, string transaction, string Module)
        {
            General Gen = new General();
            DataSet ds = new DataSet();
            ds = GetSMSandMaildata(incentiveid, Mstincentiveid, Role, transaction);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                bool ServerFlag = Convert.ToBoolean(ConfigurationManager.AppSettings["IsServer"].ToString());
                if (ServerFlag == true)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string SmsOrMailflag = ds.Tables[0].Rows[i]["SmsOrMailflag"].ToString();
                        if (SmsOrMailflag == "SMS")
                        {
                            try
                            {
                                SendSMS(ds.Tables[0].Rows[i]["MOBILENUMBERS"].ToString(), ds.Tables[0].Rows[i]["BODY"].ToString(), Module, transaction);
                            }
                            catch (Exception ex)
                            {
                                string errorMsg = ex.Message;
                            }
                        }
                        else if (SmsOrMailflag == "MAIL")
                        {
                            //string sFileDir = Server.MapPath(ds.Tables[0].Rows[i]["Attachementpath"].ToString());
                            // string uploadPath = sFileDir + "\\" + ds.Tables[0].Rows[i]["Attachementpath"].ToString();
                            string NewAttachemntpath = "";
                            //if (File.Exists(sFileDir))
                            //{
                            //    NewAttachemntpath = sFileDir;
                            //}
                            try
                            {
                                SendEmail(ds.Tables[0].Rows[i]["TOMAILID"].ToString(), ds.Tables[0].Rows[i]["CCMAILIDS"].ToString(), ds.Tables[0].Rows[i]["MSUBJECT"].ToString(), ds.Tables[0].Rows[i]["BODY"].ToString(), NewAttachemntpath, Module, transaction);
                            }
                            catch (Exception ex)
                            {
                                string errorMsg = ex.Message;
                            }
                        }
                    }
                }
            }
        }
        public string SendSms(string incentiveid, string Mstincentiveid, string TemplateId, string transaction, string Module)
        {
            General Gen = new General();
            DataSet ds = new DataSet();
            string msg = "";
            ds = GetSMSData(incentiveid, Mstincentiveid, "", transaction);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                //bool ServerFlag = Convert.ToBoolean(ConfigurationManager.AppSettings["IsServer"].ToString());
                bool ServerFlag = true;
                if (ServerFlag == true)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        try
                        {
                            msg = SendSingleSMSnew(ds.Tables[0].Rows[i]["MOBILENUMBER"].ToString(), ds.Tables[0].Rows[i]["SMSText"].ToString(), TemplateId);
                        }
                        catch (Exception ex)
                        {
                            string errorMsg = ex.Message;
                        }
                    }
                }
            }
            return msg;
        }
        public string SendSmsWebService(string incentiveid, string Mstincentiveid, string Module, string transaction, string SubModule)
        {
            General Gen = new General();
            DataSet ds = new DataSet();
            string msg = "";
            ds = GetSMSData(incentiveid, Mstincentiveid, "", transaction);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                string Username = System.Configuration.ConfigurationManager.AppSettings["APTUsername"];
                string Password = System.Configuration.ConfigurationManager.AppSettings["APTPassword"];
                string ClientID = System.Configuration.ConfigurationManager.AppSettings["APTUsername"];

                bool ServerFlag = Convert.ToBoolean(ConfigurationManager.AppSettings["IsServer"].ToString());
                if (ServerFlag == true)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        APTONLINESMSGATEWAY.SMSService ObjSMSService = new APTONLINESMSGATEWAY.SMSService();
                        ServicePointManager.Expect100Continue = true;
                        ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
                        SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;

                        APTONLINESMSGATEWAY.AuthHeader auth = new APTONLINESMSGATEWAY.AuthHeader();
                        auth.Username = Username;
                        auth.Password = Password;
                        ObjSMSService.AuthHeaderValue = auth;
                        msg = ObjSMSService.SendSMS(ds.Tables[0].Rows[i]["SMSText"].ToString(), ds.Tables[0].Rows[i]["MOBILENUMBER"].ToString(), ClientID);
                        if (msg == "SUCCESS")
                        {
                            string strTo = ds.Tables[0].Rows[i]["MOBILENUMBER"].ToString();
                            string strMessage = ds.Tables[0].Rows[i]["SMSText"].ToString();
                            SMSANDMAILDetails(strTo, strMessage, Module, SubModule, "SMS");
                        }
                    }
                }
            }  
            return msg;
        }
       
        public DataSet GetSMSandMaildata(string IncentiveID, string MstIncentiveId, string Role, string transaction)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("USP_GET_SMSMAILDATA", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@IncentiveID", SqlDbType.VarChar).Value = IncentiveID;
                da.SelectCommand.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = MstIncentiveId;
                da.SelectCommand.Parameters.Add("@Role", SqlDbType.VarChar).Value = Role;
                da.SelectCommand.Parameters.Add("@transaction", SqlDbType.VarChar).Value = transaction;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }
        public DataSet GetSMSData(string IncentiveID, string MstIncentiveId, string Role, string transaction)
        {
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("USP_GET_SMSText", con.GetConnection);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@IncentiveID", SqlDbType.VarChar).Value = IncentiveID;
                da.SelectCommand.Parameters.Add("@MstIncentiveId", SqlDbType.VarChar).Value = MstIncentiveId;
                da.SelectCommand.Parameters.Add("@Role", SqlDbType.VarChar).Value = Role;
                da.SelectCommand.Parameters.Add("@transaction", SqlDbType.VarChar).Value = transaction;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.CloseConnection();
            }
        }

        protected String encryptedPasswod(String password)
        {
            byte[] encPwd = Encoding.UTF8.GetBytes(password);
            //static byte[] pwd = new byte[encPwd.Length];
            HashAlgorithm sha1 = HashAlgorithm.Create("SHA1");
            byte[] pp = sha1.ComputeHash(encPwd);
            // static string result = System.Text.Encoding.UTF8.GetString(pp);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in pp)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }

        /// <summary>

        /// Method to Generate hash code 

        /// </summary>

        /// <param name="secure_key">your last generated Secure_key

        protected String hashGenerator(String Username, String sender_id, String message, String secure_key)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Username).Append(sender_id).Append(message).Append(secure_key);
            byte[] genkey = Encoding.UTF8.GetBytes(sb.ToString());
            //static byte[] pwd = new byte[encPwd.Length];
            HashAlgorithm sha1 = HashAlgorithm.Create("SHA512");
            byte[] sec_key = sha1.ComputeHash(genkey);
            StringBuilder sb1 = new StringBuilder();
            for (int i = 0; i < sec_key.Length; i++)
            {
                sb1.Append(sec_key[i].ToString("x2"));
            }
            return sb1.ToString();
        }

        public String SendSingleSMSnew(String mobileNo, String message, string templID)
        {
            String username = "TTAP";
            String password = "Tshandtex@1722";
            String senderid = "TSHTEX";
            String secureKey = "fb835d58-910c-400b-87b8-3cd1230cee22";
            string strSMSAPIURL = System.Configuration.ConfigurationManager.AppSettings["SmsURL"];
            /*Latest Generated Secure Key*/

            Stream dataStream;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            /*HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://msdgweb.mgov.gov.in/esms/sendsmsrequestDLT");*/
            HttpWebRequest request = WebRequest.Create(strSMSAPIURL) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;
            request.KeepAlive = false;
            request.ServicePoint.ConnectionLimit = 1;
            /*((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";*/
            ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.0; Windows 98; DigExt)";
            request.Method = "POST";
            /*System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
            System.Net.ServicePointManager.CertificatePolicy= new */
            String encryptedPassword = encryptedPasswod(password);
            String NewsecureKey = hashGenerator(username.Trim(), senderid.Trim(), message.Trim(), secureKey.Trim());
            String smsservicetype = "singlemsg"; //For single message.
            String query = "username=" + HttpUtility.UrlEncode(username.Trim()) +
                "&password=" + HttpUtility.UrlEncode(encryptedPassword) +
                "&smsservicetype=" + HttpUtility.UrlEncode(smsservicetype) +
                "&content=" + HttpUtility.UrlEncode(message.Trim()) +
                "&mobileno=" + HttpUtility.UrlEncode(mobileNo) +
                "&senderid=" + HttpUtility.UrlEncode(senderid.Trim()) +
                "&key=" + HttpUtility.UrlEncode(NewsecureKey.Trim()) +
                "&templateid=" + HttpUtility.UrlEncode(templID.Trim());

            byte[] byteArray = Encoding.ASCII.GetBytes(query);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            String Status = ((HttpWebResponse)response).StatusDescription;
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
    }
}