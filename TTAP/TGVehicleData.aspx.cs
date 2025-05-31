using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.UI;
using System.IO;

namespace TTAP
{
    public partial class TGVehicleData : System.Web.UI.Page
    {
        private string UserName = "TelRTO";
        private string Password = "QGH12#0G2&";
        private string TokenUrl = "https://pmedrive.heavyindustries.gov.in/api/getAccessToken";
        private string DataUrl = "https://pmedrive.heavyindustries.gov.in/api/vehicles";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string token = GetAccessToken();
            }
        }

        private string GetAccessToken()
        {
            try
            {

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                using (var client = new HttpClient())
                {
                    var request = new
                    {
                        username = UserName,
                        password = Password
                    };

                    var json = JsonConvert.SerializeObject(request);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = client.PostAsync(TokenUrl, content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = response.Content.ReadAsStringAsync().Result;
                        dynamic tokenResponse = JsonConvert.DeserializeObject(responseContent);
                        return tokenResponse.data.access_token;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMsg = ex.Message;
                LogError(ex);
                return null;
            }
        }
        public static void LogError(Exception ex)
        {
            string logDirectory = @"D:\ErrorLog";
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            string filename = "TGVDErrorLog_" + DateTime.Now.ToString("ddMMyyyy") + ".txt";
            string path = Path.Combine(logDirectory, filename);

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

            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(message);
            }
        }

    }
}