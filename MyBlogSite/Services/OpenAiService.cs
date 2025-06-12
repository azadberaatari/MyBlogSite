using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

public class OpenAiService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public OpenAiService(IConfiguration configuration)
    {
        _apiKey = configuration["OpenAI:ApiKey"];
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        _httpClient.Timeout = TimeSpan.FromSeconds(30); // Timeout süresi ekle
    }

    public async Task<string> GenerateBlogContentAsync(string topic, string promptTemplate = null)
    {
        var defaultPrompt = $"Aşağıdaki konu hakkında detaylı bir blog yazısı oluştur:\n\n**Konu:** {topic}\n\n**Yazı:**";
        var finalPrompt = promptTemplate ?? defaultPrompt;

        var requestBody = new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
                new { role = "system", content = "Sen bir blog yazma asistanısın. Kullanıcıların girdiği konular hakkında profesyonelce blog yazıları oluştur." },
                new { role = "user", content = finalPrompt }
            },
            max_tokens = 1000,
            temperature = 0.7
        };

        try
        {
            var response = await _httpClient.PostAsync(
                "https://api.openai.com/v1/chat/completions",
                new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json")
            );

            if (!response.IsSuccessStatusCode)
            {
                return $"Hata: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}";
            }

            var responseJson = await response.Content.ReadAsStringAsync();
            var jsonDoc = JsonDocument.Parse(responseJson);
            return jsonDoc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
        }
        catch (Exception ex)
        {
            return $"Hata: {ex.Message}";
        }
    }
}