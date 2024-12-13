using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace TFB_BackEnd_Margaux.Services
{
    public class OpenAiService : IOpenAiService
    {
        private readonly HttpClient _httpClient;
        private readonly int _maxRetries = 3;
        private readonly int _retryDelay = 1000; // 1 second

        public OpenAiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("OpenAI");
        }

        public async Task<string> GetResponseAsync(string prompt)
        {
            int attempts = 0;
            while (attempts < _maxRetries)
            {
                try
                {
                    Console.WriteLine(
                        $"Attempt {attempts + 1} - Sending request to OpenAI with prompt: {prompt}"
                    );

                    var requestBody = new
                    {
                        model = "gpt-3.5-turbo",
                        messages = new[] { new { role = "user", content = prompt } },
                    };

                    var response = await _httpClient.PostAsJsonAsync(
                        "chat/completions",
                        requestBody
                    );

                    Console.WriteLine(
                        $"Attempt {attempts + 1} - Response status code: {response.StatusCode}"
                    );

                    if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                    {
                        // Get retry-after header if available
                        var retryAfter =
                            response.Headers.RetryAfter?.Delta?.TotalMilliseconds ?? _retryDelay;
                        Console.WriteLine($"Rate limited. Waiting {retryAfter}ms before retry.");
                        await Task.Delay((int)retryAfter);
                        attempts++;
                        continue;
                    }

                    response.EnsureSuccessStatusCode();

                    var result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("OpenAI response content: " + result);

                    var jsonResponse = JsonSerializer.Deserialize<JsonElement>(result);
                    return jsonResponse
                            .GetProperty("choices")[0]
                            .GetProperty("message")
                            .GetProperty("content")
                            .GetString() ?? "";
                }
                catch (HttpRequestException ex) when (attempts < _maxRetries - 1)
                {
                    Console.WriteLine($"Attempt {attempts + 1} failed: {ex.Message}");
                    await Task.Delay(_retryDelay * (attempts + 1)); // Exponential backoff
                    attempts++;
                }
            }

            throw new Exception($"Failed to get response from OpenAI after {_maxRetries} attempts");
        }
    }
}
