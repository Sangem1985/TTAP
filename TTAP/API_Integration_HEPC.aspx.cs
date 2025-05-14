using System;
using System.Net.Http;
using System.Text;
using System.Timers;
using Newtonsoft.Json;

namespace TTAP
{
    public partial class API_Integration_HEPC : System.Web.UI.Page
    {
        private string clientId = "V204mtm9";
        private string clientSecret = "e2BHkN7Z";

        private string refreshToken = null;
        private string accessToken = null;
        private Timer refreshTimer;
        protected void Page_Load(object sender, EventArgs e)
        {
            refreshToken = GetRefreshToken(clientId, clientSecret);

            // Start access token refresh loop
            RefreshAccessToken();

            /*
            refreshTimer = new Timer(25000);
            refreshTimer.Elapsed += (s, e) => RefreshAccessToken();
            refreshTimer.Start();*/
        }
        
        private string GetRefreshToken(string clientId, string clientSecret)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            using (var client = new HttpClient())
            {
                var url = "https://staging.investharyana.in/api/getrefresh-token";
                var requestData = new { clientId = clientId, clientSecret = clientSecret };
                var json = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var resultContent = response.Content.ReadAsStringAsync().Result;
                    dynamic tokenResponse = JsonConvert.DeserializeObject(resultContent);
                    return tokenResponse["token"]?.ToString();
                }

                throw new Exception("Failed to retrieve refresh token: " + response.StatusCode);
            }
        }
        private void RefreshAccessToken()
        {
            using (var client = new HttpClient())
            {
                var url = "https://staging.investharyana.in/api/getaccess-token";
                var requestData = new { refresh_token = refreshToken };
                var json = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var resultContent = response.Content.ReadAsStringAsync().Result;
                    dynamic tokenResponse = JsonConvert.DeserializeObject(resultContent);
                    accessToken = tokenResponse["token"]?.ToString();
                }
                else
                {
                    
                }
            }
        }
        public string GetAccessToken()
        {
            return accessToken;
        }
        public static void SendServiceStatusToHEPC(string projectId, string serviceId, string actionTaken, string commentByUser)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            var url = "https://staging.investharyana.in/api/project-service-logs-external_UHBVN";

            var requestBody = new
            {
                actionTaken = actionTaken,
                commentByUserLogin = commentByUser,
                commentDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                comments = actionTaken,
                id = "",
                projectid = projectId,
                serviceid = serviceId
            };

            var json = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = client.PostAsync(url, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    
                }
                else
                {
                    var error = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Failed to send status. Response: " + error);
                }
            }
        }


        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            try
            {   
                string projectId = "";
                string serviceId = "";
                string actionTaken = "ServiceFormEdited";
                string commentByUser = "";

                SendServiceStatusToHEPC(projectId, serviceId, actionTaken, commentByUser);

                
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Status sent successfully!');", true);
            }
            catch (Exception ex)
            {
                
                ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('Error: {ex.Message}');", true);
            }
        }
    }
}