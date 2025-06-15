using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FixerApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WhatsAppController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public WhatsAppController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpPost("send-message")]
        public async Task<IActionResult> SendMessage()
        {
            var accessToken = "EAAR4ixo34dwBOyUK6QvR5svF2hYilKMIrV4sZA0mXmLmkoTvRbXbZBkvRjNJMDjvibASKDjvp854wTBu1J2gJjE6ZAeOyu751OF4XzS8Mbq5qlu8IGaDFoOoYT4gWpXOVEgQgZC2rrhEFBDwh4JllKoZBDdCAZCERtejCLGmNivgQH4Po5geaFvJdo9s5YCkHBZAsIlNSLfZBMzkVL39rEwcpGpjCLjWQONiRujht0UZD"; 
            var phoneNumberId = "15557546295"; 

            var url = $"https://graph.facebook.com/v19.0/{phoneNumberId}/messages";

            var payload = new
            {
                messaging_product = "whatsapp",
                to = "916206496829", 
                type = "text",
                text = new { body = "Hello from WhatsApp API!" }
            };

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            request.Content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();

            return Ok(responseContent);
        }
    }
}


//105801371573180

//    15557546295


//    EAAR4ixo34dwBOyUK6QvR5svF2hYilKMIrV4sZA0mXmLmkoTvRbXbZBkvRjNJMDjvibASKDjvp854wTBu1J2gJjE6ZAeOyu751OF4XzS8Mbq5qlu8IGaDFoOoYT4gWpXOVEgQgZC2rrhEFBDwh4JllKoZBDdCAZCERtejCLGmNivgQH4Po5geaFvJdo9s5YCkHBZAsIlNSLfZBMzkVL39rEwcpGpjCLjWQONiRujht0UZD

//    : EAAR4ixo34dwBOyUK6QvR5svF2hYilKMIrV4sZA0mXmLmkoTvRbXbZBkvRjNJMDjvibASKDjvp854wTBu1J2gJjE6ZAeOyu751OF4XzS8Mbq5qlu8IGaDFoOoYT4gWpXOVEgQgZC2rrhEFBDwh4JllKoZBDdCAZCERtejCLGmNivgQH4Po5geaFvJdo9s5YCkHBZAsIlNSLfZBMzkVL39rEwcpGpjCLjWQONiRujht0UZD