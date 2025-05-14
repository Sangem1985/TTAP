using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TTAP
{
    public partial class HEPC_API_Integration : System.Web.UI.Page
    {
        private static readonly HttpClient client = new HttpClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public async Task<string> GetRefreshToken()
        {
            var client = new HttpClient();
            var requestBody = new
            {
                clientId = "V204mtm9",
                clientSecret = "e2BHkN7Z"
            };
            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://staging.investharyana.in/api/getrefresh-token", content);
            var result = await response.Content.ReadAsStringAsync();
            dynamic json = JsonConvert.DeserializeObject(result);
            return json.refresh_token;
            //GetAccessToken(json.refresh_token);
        }
        public async Task<string> GetAccessToken(string refreshToken)
        {
            var client = new HttpClient();
            var requestBody = new { refresh_token = refreshToken };
            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://staging.investharyana.in/api/getaccess-token", content);
            var result = await response.Content.ReadAsStringAsync();
            dynamic json = JsonConvert.DeserializeObject(result);
            return json.access_token;
        }
        public async Task<HttpResponseMessage> UpdateApplicationStatus(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var requestBody = new
            {
                actionTaken = "Cleared",
                commentByUserLogin = "Officer Name",
                commentDate = "2017-08-29T09:43:42.335Z", // application approved date
                comments = "Application approved.",
                id = "",
                projectid = "project_id",
                serviceid = "service_id"
            };

            var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
            return await client.PostAsync("https://staging.investharyana.in/api/project-service-logs-external_UHBVN", content);
        }
        private async Task UpdateApplicationStatusBtnClick()
        {
            string refreshToken = await GetRefreshToken();
            string accessToken = await GetAccessToken(refreshToken);
            HttpResponseMessage response = await UpdateApplicationStatus(accessToken);

            if (response.IsSuccessStatusCode)
            {
                lblMessage.Text = "Status updated successfully.";
            }
            else
            {
                lblMessage.Text = "Failed to update status: " + await response.Content.ReadAsStringAsync();
            }
        }

        public async Task ProcessApplication()
        {
            string refreshToken = await GetRefreshToken();    
            string accessToken = await GetAccessToken(refreshToken);

            HttpResponseMessage response = await UpdateApplicationStatus(accessToken);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Status updated successfully.");
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Failed: " + error);
            }
        }
        protected void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            var task = UpdateApplicationStatusBtnClick();
            task.Wait();
        }
        protected void btn_Click(object sender, EventArgs e)
        {
            RunProcess();
        }
        private async void RunProcess()
        {
            await ProcessApplication();
        }

    }
}