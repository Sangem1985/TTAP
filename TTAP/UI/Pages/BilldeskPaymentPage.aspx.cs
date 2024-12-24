using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using TTAP.Classfiles;
using System.Xml;
using System.Net;
using System.IO;

namespace TTAP.UI.Pages
{
    public partial class BilldeskPaymentPage : System.Web.UI.Page
    {
        CAFClass ObjCAFClass = new CAFClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["BillerID"] != null)
                    {
                        Session["ApplicationNumber"] = "";
                        Session["PipeString"] = "";
                        Session["PMode"] = Request.QueryString["PMode"].ToString();
                        Session["onlinetransId"] = Request.QueryString["BillerID"].ToString();
                        Session["IncentiveID"] = Request.QueryString["IncentiveId"].ToString();
                        if (Session["PMode"] != null && Session["onlinetransId"].ToString() != null)
                        {
                            string msg = "";
                            DataSet dspaydtls = new DataSet();
                            Session["BuildDeskNewUrl"] = System.Configuration.ConfigurationManager.AppSettings["APTPGURL"];

                            string RequestID = Session["onlinetransId"].ToString();
                            string Client_ID = "149"; 
                            string CustomerID = Session["ApplicationNumber"].ToString();
                            string DeptId = "1158";
                            string ServiceId = "6850";
                            string PaymentMode = Request.QueryString["PMode"].ToString();
                            double BaseAmount = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings["PGBaseAmount"].ToString());
                            decimal Charges = 0;
                            if (PaymentMode == "NB" || PaymentMode == "NBS" || PaymentMode == "NBH" || PaymentMode == "NBI")
                            {
                                Charges = Convert.ToDecimal(15.00 + 2.70);
                            }
                            if (PaymentMode == "CC")
                            {
                                Charges = Convert.ToDecimal(12.50 + 2.25);
                            }
                            if (PaymentMode == "DC")
                            {
                                Charges = Convert.ToDecimal(6.50 + 0.97);
                            }

                            string ServiceCharge = Charges.ToString();
                            double Total = (Convert.ToDouble(BaseAmount)) + Convert.ToDouble(Charges);
                            string Totalamount = Total.ToString();
                            string additionalPayment = "";
                            string CheckSumKey = "1212751612";
                            if (Session["AdditionalPayment"] != null)
                            {
                                additionalPayment = Session["AdditionalPayment"].ToString().Trim();
                            }
                            if (additionalPayment == "")
                            {
                                additionalPayment = "NA";
                            }
                            dspaydtls = GetEnterprinerpaymentDtls(Session["IncentiveID"].ToString(), RequestID);
                            string IncentiveID = Session["IncentiveID"].ToString();
                            string MobileNo = "";
                            string Email = "";
                            string CustomerName = "";
                            string Address = "", City = "", State = "TS", Pincode = "500082";
                            if (dspaydtls != null && dspaydtls.Tables.Count > 0 && dspaydtls.Tables[0].Rows.Count > 0)
                            {
                                MobileNo = dspaydtls.Tables[0].Rows[0]["UnitMObileNo"].ToString();
                                Email = dspaydtls.Tables[0].Rows[0]["UnitEmail"].ToString();
                                CustomerName= dspaydtls.Tables[0].Rows[0]["ApplicantName"].ToString();
                                Address = dspaydtls.Tables[0].Rows[0]["Village_Name"].ToString();
                                City = dspaydtls.Tables[0].Rows[0]["District_Name"].ToString();
                                Session["ApplicationNumber"] = dspaydtls.Tables[0].Rows[0]["ApplicationNumber"].ToString();
                            }

                            string ReturnURL = System.Configuration.ConfigurationManager.AppSettings["APTPGReturnURL"];
                            string CheckSum = "";
                            APTONLINEPGSERVICE.EncryptDEcrypt PGService = new APTONLINEPGSERVICE.EncryptDEcrypt();
                            ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
                            SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                            CheckSum = PGService.CheckSumforRequest(RequestID, Client_ID, ServiceId, PaymentMode, BaseAmount, CheckSumKey);

                            string datetoday = DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString() + " 11:04:39";

                            String data = RequestID + "|" + Client_ID + "|" + DeptId + "|" + ServiceId + "|" + PaymentMode + "|" + BaseAmount + "|" + ServiceCharge +
                                "|" + Totalamount + "|" + ReturnURL + "|" + CustomerName + "|" + Address + "|" + City + "|" + State + "|" + Pincode + "|" + Email + "|" + MobileNo +
                                "|" + CheckSum + "|" + Session["IncentiveID"].ToString() + "|" + Session["ApplicationNumber"].ToString() + "|NA|NA|NA|NA";

                            Session["PipeString"] = data;
                            msg = PGService.Encrypt(data);

                            /*String commonkey = "1212751612";
                            String hash = String.Empty;
                            hash = GetHMACSHA256(data, commonkey);
                            hash = hash.ToUpper();
                            msg = data + "|" + hash;*/
                            Session["msg"] = msg;

                            Session["BuildDeskNewUrl"] = System.Configuration.ConfigurationManager.AppSettings["APTPGURL"] + msg;
                            try
                            {
                                GetTESTVALUES(Session["PipeString"].ToString(), Session["onlinetransId"].ToString(), Session["IncentiveID"].ToString());
                            }
                            catch (Exception ex)
                            {
                                string errorMsg = ex.Message;
                            }
                        }
                        else
                        {
                            Response.Redirect("~/loginreg.aspx");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                //lblmsg0.Text = "Internal error has occured. Please try after some time";
                //lblMsg.Text = ex.Message;
                //Failure.Visible = true;
            }
        }
       
        public string GetHMACSHA256(string text, string key)
        {
            UTF8Encoding encoder = new UTF8Encoding();

            byte[] hashValue;
            byte[] keybyt = encoder.GetBytes(key);
            byte[] message = encoder.GetBytes(text);

            HMACSHA256 hashString = new HMACSHA256(keybyt);
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
        public DataSet GetEnterprinerpaymentDtls(string IncentiveID, string Orderno)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveID",SqlDbType.VarChar),
               new SqlParameter("@OnlineOrderNo",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveID;
            pp[1].Value = Orderno;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_UNIT_DETAILS_PG", pp);
            return Dsnew;
        }

        public void GetTESTVALUES(string Request,string BillNo,string IncentiveId)
        {
            DB.DB con = new DB.DB();
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("USP_TEST_WEBSERVISE", con.GetConnection);
                da.SelectCommand.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = BillNo.ToString();
                da.SelectCommand.Parameters.Add("@request", SqlDbType.VarChar).Value = Request.ToString();
                da.SelectCommand.Parameters.Add("@Online", SqlDbType.VarChar).Value = "Online";
                da.SelectCommand.Parameters.Add("@IncentiveId", SqlDbType.VarChar).Value = IncentiveId;

                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(ds);
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
    }
}