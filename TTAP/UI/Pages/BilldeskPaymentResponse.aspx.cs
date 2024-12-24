using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//using com.toml.dp.util;
using System.Data.SqlClient;
using System.Collections.Generic;
using TTAP.Classfiles;
using System.Net;
using System.IO;
using System.Xml;
using System.Security.Cryptography;

namespace TTAP.UI.Pages
{
    public partial class BilldeskPaymentResponse : System.Web.UI.Page
    {
        paymentresponseVOs paymentresponseVOsobj = new paymentresponseVOs();
        CAFClass ObjCAFClass = new CAFClass();
        DataRetrivalClass Objret = new DataRetrivalClass();
        BilldeskPaymentPage BillDesk = new BilldeskPaymentPage();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Session["ObjLoginvo"] != null)
                    {
                        UserLoginNewVo ObjLoginNewvo = new UserLoginNewVo();
                        ObjLoginNewvo = (UserLoginNewVo)Session["ObjLoginvo"];
                        string msg = "";
                        if (Request.QueryString["resp"] != null)
                        {
                            string BilldeskResponse = Request.QueryString["resp"].ToString().Replace(" ", "+");
                            APTONLINEPGSERVICE.EncryptDEcrypt PGService = new APTONLINEPGSERVICE.EncryptDEcrypt();
                            ServicePointManager.Expect100Continue = true;
                            ServicePointManager.SecurityProtocol = //SecurityProtocolType.Tls12;
                            SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                            msg = PGService.Decrypt(BilldeskResponse);
                            string PipeString = Session["PipeString"].ToString();
                            string[] RESP = msg.Split('|');
                            string[] REQ = PipeString.Split('|');
                            if (RESP[0].ToUpper() != "FAIL")
                            {
                                RTGSNEFTPayment objRTGSNEFTPayment = new RTGSNEFTPayment();
                                double ApplicationFee = Convert.ToDouble(REQ[5].ToString());
                                double TaxAmount = Convert.ToDouble(REQ[6].ToString());
                                double TotalAmount = Convert.ToDouble(REQ[7].ToString());

                                objRTGSNEFTPayment.ApplicationNumber = Session["ApplicationNumber"].ToString();
                                objRTGSNEFTPayment.IncentiveID = Session["IncentiveId"].ToString();
                                objRTGSNEFTPayment.TTAPBillerID = Session["onlinetransId"].ToString();
                                objRTGSNEFTPayment.PaymentMode = REQ[4].ToString();
                                objRTGSNEFTPayment.ApplicationFee = ApplicationFee.ToString();
                                objRTGSNEFTPayment.Tax_Amount = TaxAmount.ToString();
                                objRTGSNEFTPayment.Total_Amount = TotalAmount.ToString();
                                objRTGSNEFTPayment.PGRefNo = RESP[1];
                                objRTGSNEFTPayment.CreatedBy = ObjLoginNewvo.uid;
                                int Status = ObjCAFClass.RTGSNEFTPaymentDtls_1(objRTGSNEFTPayment);
                                GetTESTVALUES(msg, Session["onlinetransId"].ToString());
                                if (Status > 0)
                                {
                                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Done Successfully');" + "window.location='FinalPage.aspx';", true);
                                }
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "alertMsg", "alert('Payment Failed at Bank');" + "window.location='FinalPage.aspx?BillId=" + Session["onlinetransId"].ToString() + "';", true);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                // LogErrorToText(ex);
            }
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
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_Builldesc_PaymentDtls_DESE", pp);
            return Dsnew;
        }
        public static void LogErrorToText1(string ex)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("********************" + " Bill Desk ONLINE Error Log - " + DateTime.Now + "*********************");
            sb.Append(Environment.NewLine);
            sb.Append("Error Message : " + ex);
            sb.Append(Environment.NewLine);
            //sb.Append(ex);
            sb.Append("********************" + " Bill Desk ONLINE END Error Log *********************");
            string filePath = HttpContext.Current.Server.MapPath("Online_Error_Log.txt");
            if (System.IO.File.Exists(filePath))
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true);
                writer.WriteLine(sb.ToString());
                writer.Flush();
                writer.Close();
            }
        }
        public static void LogErrorToText(Exception ex)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("********************" + " Bill Desk ONLINE Error Log - " + DateTime.Now + "*********************");
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append("Exception Type : " + ex.GetType().Name);
            sb.Append(Environment.NewLine);
            sb.Append("Error Message : " + ex.Message);
            sb.Append(Environment.NewLine);
            sb.Append("Error Source : " + ex.Source);
            sb.Append(Environment.NewLine);
            if (ex.StackTrace != null)
            {
                sb.Append("Error Trace : " + ex.StackTrace);
            }
            Exception innerEx = ex.InnerException;

            while (innerEx != null)
            {
                sb.Append(Environment.NewLine);
                sb.Append(Environment.NewLine);
                sb.Append("Exception Type : " + innerEx.GetType().Name);
                sb.Append(Environment.NewLine);
                sb.Append("Error Message : " + innerEx.Message);
                sb.Append(Environment.NewLine);
                sb.Append("Error Source : " + innerEx.Source);
                sb.Append(Environment.NewLine);
                if (ex.StackTrace != null)
                {
                    sb.Append("Error Trace : " + innerEx.StackTrace);
                }
                innerEx = innerEx.InnerException;
            }
            sb.Append("********************" + " BillDesk ONLINE END Error Log *********************");
            string filePath = HttpContext.Current.Server.MapPath("Online_Error_Log.txt");
            if (System.IO.File.Exists(filePath))
            {
                System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true);
                writer.WriteLine(sb.ToString());
                writer.Flush();
                writer.Close();
            }
        }
        public void GetTESTVALUES(string Responce,string BillNo)
        {
            DB.DB con = new DB.DB();
            con.OpenConnection();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("USP_UPD_TEST_WEBSERVISE", con.GetConnection);
                da.SelectCommand.Parameters.Add("@BillNo", SqlDbType.VarChar).Value = BillNo.ToString();
                da.SelectCommand.Parameters.Add("@responce", SqlDbType.VarChar).Value = Responce.ToString();
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
        public int InsertUpdatepaymentdtls(paymentresponseVOs paymentresponseVOsobj)
        {
            string str = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            int valid = 0;
            //int itemidout = 0;
            SqlConnection connection = new SqlConnection(str);
            SqlTransaction trans = null;

            connection.Open();
            trans = connection.BeginTransaction();
            SqlCommand command = new SqlCommand("[USP_UPDATE_BilldesK_PaymentDtls]", connection);
            command.CommandType = CommandType.StoredProcedure;
            //SqlCommand command1 = null;
            try
            {
                command.Parameters.AddWithValue("@CustomerID_1", paymentresponseVOsobj.CustomerID_1);
                command.Parameters.AddWithValue("@TxnReferenceNo_2", paymentresponseVOsobj.TxnReferenceNo_2);
                command.Parameters.AddWithValue("@BankReferenceNo_3", paymentresponseVOsobj.BankReferenceNo_3);
                command.Parameters.AddWithValue("@TxnAmount_4", paymentresponseVOsobj.TxnAmount_4);
                command.Parameters.AddWithValue("@BankID_5", paymentresponseVOsobj.BankID_5);
                command.Parameters.AddWithValue("@BIN_6", paymentresponseVOsobj.BIN_6);
                command.Parameters.AddWithValue("@TxnType_7", paymentresponseVOsobj.TxnType_7);
                command.Parameters.AddWithValue("@CurrencyName_8", paymentresponseVOsobj.CurrencyName_8);
                command.Parameters.AddWithValue("@ItemCode_9", paymentresponseVOsobj.ItemCode_9);
                command.Parameters.AddWithValue("@SecurityType_10", paymentresponseVOsobj.SecurityType_10);
                command.Parameters.AddWithValue("@SecurityID_11", paymentresponseVOsobj.SecurityID_11);
                command.Parameters.AddWithValue("@SecurityPassword_12", paymentresponseVOsobj.SecurityPassword_12);
                command.Parameters.AddWithValue("@TxnDate_13", paymentresponseVOsobj.TxnDate_13);
                command.Parameters.AddWithValue("@AuthStatus_14", paymentresponseVOsobj.AuthStatus_14);
                command.Parameters.AddWithValue("@SettlementType_15", paymentresponseVOsobj.SettlementType_15);
                command.Parameters.AddWithValue("@AdditionalInfo1_16", paymentresponseVOsobj.AdditionalInfo1_16);
                command.Parameters.AddWithValue("@AdditionalInfo2_17", paymentresponseVOsobj.AdditionalInfo2_17);
                command.Parameters.AddWithValue("@AdditionalInfo3_18", paymentresponseVOsobj.AdditionalInfo3_18);
                command.Parameters.AddWithValue("@AdditionalInfo4_19", paymentresponseVOsobj.AdditionalInfo4_19);
                command.Parameters.AddWithValue("@AdditionalInfo5_20", paymentresponseVOsobj.AdditionalInfo5_20);
                command.Parameters.AddWithValue("@AdditionalInfo6_21", paymentresponseVOsobj.AdditionalInfo6_21);
                command.Parameters.AddWithValue("@AdditionalInfo7_22", paymentresponseVOsobj.AdditionalInfo7_22);
                command.Parameters.AddWithValue("@ErrorStatus_23", paymentresponseVOsobj.ErrorStatus_23);
                command.Parameters.AddWithValue("@ErrorDescription_24", paymentresponseVOsobj.ErrorDescription_24);
                command.Parameters.AddWithValue("@Created_by", paymentresponseVOsobj.Createdby);
                command.Parameters.Add("@VALID", SqlDbType.Int, 500);
                command.Parameters["@VALID"].Direction = ParameterDirection.Output;

                command.Transaction = trans;
                command.ExecuteNonQuery();
                valid = (Int32)command.Parameters["@VALID"].Value;

                trans.Commit();
                connection.Close();
            }

            catch (Exception ex)
            {
                trans.Rollback();

                throw ex;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
                //command1.Dispose();
            }
            return valid;
        }
        
    }
}