using System;
using System.Net.Http;
using System.Text;
using System.Timers;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Data;

namespace TTAP.UI
{
    public partial class PIAnte : System.Web.UI.Page
    {
        private string userName = "Chanikya";
        private string password = "Chanikya123";

        private string token = null;
        private string JsonData = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*token = GetToken(userName, password);
            GetData();*/
            token = GetJwtToken();
            UpdateData(token);
        }


        public static string GetJwtToken()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301/");
                var credentials = new
                {
                    ClientId = "V204mtm9",
                    ClientSecret = "e2BHkN7Z"
                };

                var content = new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(credentials),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = client.PostAsync("api/token/generatetoken", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var resultContent = response.Content.ReadAsStringAsync().Result;
                    dynamic tokenResponse = JsonConvert.DeserializeObject(resultContent);
                    return tokenResponse["token"]?.ToString();
                }

                throw new Exception("Failed to retrieve JWT token: " + response.StatusCode);
            }
        }

        public static string UpdateData(string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44301/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var requestBody = new
                {
                    VisitorId = "1",
                    VisitorCity = "L.B.Cherla",
                    MobileNumber="9949968368",
                    Email="ChanikyaGopal@gmail.com"
                };

                var content = new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(requestBody),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = client.PostAsync("api/data/update", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }

                throw new Exception("API call failed: " + response.StatusCode);
            }
        }


        private string GetToken(string userName, string password)
        {
            
            
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            using (var client = new HttpClient())
            {
                var url = "https://localhost:44318/api/User/login";
                var requestData = new { userName = userName, password = password };
                var json = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var resultContent = response.Content.ReadAsStringAsync().Result;
                    dynamic tokenResponse = JsonConvert.DeserializeObject(resultContent);
                    return tokenResponse["token"]?.ToString();
                    //return resultContent;
                }

                throw new Exception("Failed to retrieve refresh token: " + response.StatusCode);
            }
        }
        private void GetData()
        {
            using (var client = new HttpClient())
            {
                var url = "https://localhost:44318/api/Data/getdata";
                client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

                var response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var resultContent = response.Content.ReadAsStringAsync().Result;

                    JsonData = resultContent;
                    DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(JsonData);
                    gvAPIData.DataSource = dataTable;
                    gvAPIData.DataBind();
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
        }
    }
}