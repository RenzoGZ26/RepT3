using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class BookRecommendationService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public BookRecommendationService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["GoogleBooksApiKey"];
    }

    public async Task<string> GetBookRecommendationsAsync(string bookTitle)
    {
        var url = $"https://www.googleapis.com/books/v1/volumes?q={bookTitle}&key={_apiKey}";
        for (int i = 0; i < 3; i++)  // Intentos hasta 3 veces
        {
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else if ((int)response.StatusCode == 429)
            {
                // Espera 2 segundos antes de intentar nuevamente
                await Task.Delay(2000);
            }
            else
            {
                response.EnsureSuccessStatusCode();
            }
        }

        throw new HttpRequestException("Se alcanzó el límite de solicitudes. Inténtalo de nuevo más tarde.");
    }
}
