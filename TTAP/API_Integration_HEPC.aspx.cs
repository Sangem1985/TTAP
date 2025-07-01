using System;
using System.Net.Http;
using System.Text;
using System.Timers;
using System.Web.Script.Serialization;
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SubmitNewConnectionRequest();
        }
        private async void SubmitNewConnectionRequest()
        {
            var requestBody = new
            {
                Subdivisonname = "NONGSTOIN",
                Subdivison = 1132,
                District = 1,
                DistrictName = "WEST KHASI HILLS",
                Applicationfor = 1,
                Applicationtype = 2,
                PinCode = 0,
                state = 0,
                Address_of_inst = "INSTALLADRESS",
                Owner_type = 3,
                Purpose = 4,
                AppliedLoad = 0,
                Applicatent_Name = "SHREERAM",
                Father_name = "DASARATHA",
                MotherName = "KOUSALYA",
                Mobile_number = "9898989898",
                Phone = "9797979797",
                Email = "test@example.com",
                Door_no = 0,
                Perm_Address = "CONSADDRESS",
                Cast = "IKSHAVAHU",
                IdentityProof = "AADHAR",
                CreatedBy = 136,
                lstDocuments = new[]
                {
                new {
                    documantId = 2,
                    documentName = "Proof of ownership/occupancy",
                    document_path = "https://example.com/doc1.pdf"
                },
                new {
                    documantId = 3,
                    documentName = "Proof of Identification",
                    document_path = "https://example.com/doc2.pdf"
                }
                }
            };

            var jsonData = new JavaScriptSerializer().Serialize(requestBody);

            using (HttpClient client = new HttpClient())
            {
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await client.PostAsync("https://uat.mepdcl.trm.ieasybill.com/api/registration/new", content);
                    string result = await response.Content.ReadAsStringAsync();

                  
                }
                catch (Exception ex)
                {
                   
                }
            }
        }
        private string Post()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

            using (var client = new HttpClient())
            {
                var url = "https://uat.mepdcl.trm.ieasybill.com/api/registration/new";
                var requestBody = new
                {
                    Subdivisonname = "NONGSTOIN",
                    Subdivison = 1132,
                    District = 1,
                    DistrictName = "WEST KHASI HILLS",
                    Applicationfor = 1,
                    Applicationtype = 2,
                    PinCode = 0,
                    state = 0,
                    Address_of_inst = "INSTALLADRESS",
                    Owner_type = 3,
                    Purpose = 4,
                    AppliedLoad = 0,
                    Applicatent_Name = "SHREERAM",
                    Father_name = "DASARATHA",
                    MotherName = "KOUSALYA",
                    Mobile_number = "9898989898",
                    Phone = "9797979797",
                    Email = "test@example.com",
                    Door_no = 0,
                    Perm_Address = "CONSADDRESS",
                    Cast = "IKSHAVAHU",
                    IdentityProof = "AADHAR",
                    CreatedBy = 136,
                    lstDocuments = new[]
                {
                new {
                    documantId = 2,
                    documentName = "Proof of ownership/occupancy",
                    document_path = "doc1.pdf"
                },
                new {
                    documantId = 3,
                    documentName = "Proof of Identification",
                    document_path = "doc2.pdf"
                }
                }
                };
                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var resultContent = response.Content.ReadAsStringAsync().Result;
                    //dynamic tokenResponse = JsonConvert.DeserializeObject(resultContent);
                    
                }

                throw new Exception("Failed  " + response.StatusCode);
            }
        }
    }
}