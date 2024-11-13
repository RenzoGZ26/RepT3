using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace T3_Grupo1.Services
{
    public class GoogleBooksService
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public GoogleBooksService(IConfiguration configuration)
        {
            _apiKey = configuration["GoogleBooksApiKey"];
            _httpClient = new HttpClient();
        }

        public async Task<JArray> GetRecommendedBooksAsync(string query)
        {
            var url = $"https://www.googleapis.com/books/v1/volumes?q={query}&key={_apiKey}&maxResults=5";
            var response = await _httpClient.GetStringAsync(url);
            var data = JObject.Parse(response);
            return (JArray)data["items"];
        }
    }
}
