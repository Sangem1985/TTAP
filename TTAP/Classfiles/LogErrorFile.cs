using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace TTAP.Classfiles
{
    public class LogErrorFile
    {
        public static void LogError(Exception ex)
        {
            string filename = "ErrorLog_" + DateTime.Now.ToString("dd") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("yyyy");

            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = System.Web.HttpContext.Current.Server.MapPath("~/ErrorLog/" + filename + ".txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        public static void LogData(string strData)
        {
            string filename = "LogData_" + DateTime.Now.ToString("dd") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("yyyy");

            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", strData);

            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = System.Web.HttpContext.Current.Server.MapPath("~/ErrorLog/" + filename + ".txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }

        public static void LogerrorDB(Exception ex, string path, string CreatedBy)
        {
            string constr = ConfigurationManager.ConnectionStrings["TTAPDB"].ConnectionString;
            try
            {
                DataSet dsdata = new DataSet();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmdsrc = new SqlCommand("INS_ErrorLog", con);
                    cmdsrc.Parameters.AddWithValue("@Message", ex.Message);
                    cmdsrc.Parameters.AddWithValue("@StackTrace", ex.StackTrace);
                    cmdsrc.Parameters.AddWithValue("@Source", ex.Source);
                    cmdsrc.Parameters.AddWithValue("@TargetSite", ex.TargetSite.ToString());
                    cmdsrc.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                    cmdsrc.Parameters.AddWithValue("@path", path);
                    cmdsrc.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmdsrc.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ee)
            {
                LogError(ee);
                LogError(ex);
            }
        }
    }
}