using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Globalization;
using System.IO;
using System.Configuration;

namespace TTAP.Classfiles
{
    public class IncentivesDataRetrivalClass
    {
        string connStrTSIPASS = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
        //string connStrTTAP = ConfigurationManager.ConnectionStrings["TTAP"].ConnectionString;

        public DataSet GetIALAParks_Incentives(int IALACode, int DistrictCd)
        {
            SqlConnection con = new SqlConnection(connStrTSIPASS);
            con.Open();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter("USP_GET_IALA_INDUSTRIALPARKS_INCENTIVES", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                if ( IALACode != 0)
                    da.SelectCommand.Parameters.AddWithValue("@IALA_Cd", IALACode);
                if (DistrictCd != 0)
                    da.SelectCommand.Parameters.AddWithValue("@DISTRICTCD", DistrictCd);

                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }
}