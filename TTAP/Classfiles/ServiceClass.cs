using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTAP.Classfiles
{
    public class ServiceClass
    {
        public string InterestPaid { get; set; }
        public string UnitName { get; set; }
        public string IncentiveName { get; set; }
        public string ClaimPeriod { get; set; }
        public string ApplicationNumber { get; set; }
    }
    public class Payment
    {
        public string RequestId { get; set; }
        public string PGrefNo { get; set; }
        public string Deptid { get; set; }
        public string ServiceID { get; set; }
        public string TransactionsAmount { get; set; }
        public string TrnasactionDate { get; set; }
        public string PaymentMode { get; set; }
       
    }
    public class PaymentStatus
    {
        public string Status { get; set; }
    }
}