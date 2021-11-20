using MicroservicePFR.Domain.Models;
using MicroservicePFR.Infraestructure;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MicroservicePFR.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private static HttpClient httpClient;

        public AuthService(IHttpClientFactory httpClientFactory) {
            this.httpClientFactory = httpClientFactory;
            httpClient = httpClientFactory.CreateClient("Auth");
        }
        public User GetCurrentUser() {
            httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("bearer", Auth.bearerToken);
            var response =  httpClient.GetAsync("/v1/users/current?" + Auth.bearerToken).GetAwaiter().GetResult();
            string responseBody =  response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var user = JsonConvert.DeserializeObject<User>(responseBody);
            return user;
        }

        public bool IsAuthorized() {
            return !string.IsNullOrEmpty(Auth.bearerToken);
        }
    }
}
