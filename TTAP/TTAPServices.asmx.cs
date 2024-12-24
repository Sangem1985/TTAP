using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using TTAP.Classfiles;
using System.Web.Script.Serialization;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace TTAP
{
    /// <summary>
    /// Summary description for TTAPServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class TTAPServices : System.Web.Services.WebService
    {
        CAFClass caf = new CAFClass();

      /*  [WebMethod]
        public  string GetIncentives(string IncentiveId)
        {
            List<ServiceClass> listIncentive = new List<ServiceClass>();
            string CS = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("USP_GET_INCENTIVES_CLAIMPERIOD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@IncentiveId",
                    Value = IncentiveId
                });
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ServiceClass incentive = new ServiceClass();
                    incentive.IncentiveName = rdr["IncentiveName"].ToString();
                    incentive.ClaimPeriod = rdr["ClaimPeriod"].ToString();
                    incentive.UnitName = rdr["UnitName"].ToString();
                    incentive.ApplicationNumber = rdr["ApplicationNumber"].ToString();
                    listIncentive.Add(incentive);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(listIncentive);
        }*/
        [WebMethod]
        public string TTAPPGData(string FromDate,string ToDate)
        {
            List<Payment> listPayment = new List<Payment>();
            string CS = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("USP_GET_PAYMENTGATEWAY_TRANSACTIONS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@FromDate",
                    Value = FromDate
                });
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@ToDate",
                    Value = ToDate
                });
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Payment payment = new Payment();
                    payment.RequestId = rdr["BillNo"].ToString();
                    payment.PGrefNo = rdr["PGRefNo"].ToString();
                    payment.Deptid = rdr["DeptId"].ToString();
                    payment.ServiceID = rdr["ServiceId"].ToString();
                    payment.TransactionsAmount = rdr["TransactionsAmount"].ToString();
                    payment.TrnasactionDate = rdr["TrnasactionDate"].ToString();
                    payment.PaymentMode = rdr["PaymentMode"].ToString();
                    listPayment.Add(payment);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(listPayment);
        }
        [WebMethod]
        public string CheckPaymentStatus(string RequestID)
        {
            List<PaymentStatus> listPayment = new List<PaymentStatus>();
            string CS = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("USP_GET_PAYMENT_STATUS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@RequestID",
                    Value = RequestID
                });
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PaymentStatus payment = new PaymentStatus();
                    payment.Status = rdr["Status"].ToString();
                    listPayment.Add(payment);
                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(listPayment);
        }
    }
}
