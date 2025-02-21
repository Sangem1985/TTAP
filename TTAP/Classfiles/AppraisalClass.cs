using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DataAccessLayer;

namespace TTAP.Classfiles
{
    public class AppraisalClass
    {
        CAFClass ObjCAFClass = new CAFClass();
        string str = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
        private SqlConnection ConNew = new SqlConnection(ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString);
        public DataSet GetapplicationDtls(string USERID, string INCENTIVEID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@CREATEDBY",SqlDbType.VarChar),
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = USERID;
            pp[1].Value = INCENTIVEID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_INCENTIVES_CAF_DATA", pp);
            return Dsnew;
        }
        public DataSet GetSubsidyApplicationDeatils(string INCENTIVEID, string SubIncentiveId, string DistID)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar),
               new SqlParameter("@SubIncentiveId",SqlDbType.VarChar),
               new SqlParameter("@DistID",SqlDbType.VarChar)
           };
            pp[0].Value = INCENTIVEID;
            pp[1].Value = SubIncentiveId;
            pp[2].Value = DistID;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_INSPECTION_DTLS_VIEW", pp);
            return Dsnew;
        }

        public DataSet GetPandM(int PMId, int IncentiveId, string IndusType, string Role)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@IncentiveId",SqlDbType.Int),
               new SqlParameter("@PMId",SqlDbType.Int),
               new SqlParameter("@Role",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = PMId;
            pp[2].Value = Role;
            string ProcName = "";
            if (IndusType == "1")
            {
                ProcName = "USP_GET_PLANTANDMACHINERY";
            }
            else
            {
                ProcName = "USP_GET_PLANTANDMACHINERY_ExistingUnit";
            }
            Dsnew = ObjCAFClass.GenericFillDs(ProcName, pp);
            return Dsnew;
        }
        public DataSet GetCliamPeroid(string IncentiveId, string SubIncentiveId)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar),
               new SqlParameter("@SUBINCENTIVEID",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = SubIncentiveId;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_CURRENT_CLAIMPERIOD", pp);
            return Dsnew;
        }
        public DataSet GetCliamPeroidNew(string IncentiveId, string SubIncentiveId,string Flag)
        {
            DataSet Dsnew = new DataSet();

            SqlParameter[] pp = new SqlParameter[] {
               new SqlParameter("@INCENTIVEID",SqlDbType.VarChar),
               new SqlParameter("@SUBINCENTIVEID",SqlDbType.VarChar),
               new SqlParameter("@FLAG",SqlDbType.VarChar)
           };
            pp[0].Value = IncentiveId;
            pp[1].Value = SubIncentiveId;
            pp[2].Value = Flag;
            Dsnew = ObjCAFClass.GenericFillDs("USP_GET_CURRENT_CLAIMPERIOD", pp);
            return Dsnew;
        }
    }
}