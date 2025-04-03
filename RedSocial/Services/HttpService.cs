using Newtonsoft.Json;

namespace RedSocial.Services;

public class HttpService : IHttpService
{
    private readonly HttpClient _httpClient;

    public HttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T?> GetAsync<T>()
    {
        var response = await _httpClient.GetAsync("2");
        
        if (!response.IsSuccessStatusCode)
        {
            return default;
        }

        var json = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(json);
    }
}