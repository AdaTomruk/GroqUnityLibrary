using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace GroqApiLibrary
{
    public class GroqApiClient : IDisposable
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.groq.com/openai/v1/chat/completions";

        public GroqApiClient(string apiKey)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        }

        public async Task<JObject?> CreateChatCompletionAsync(JObject request)
        {
            try
            {
                var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(BaseUrl, content);
                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<JObject>(jsonResponse);
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error in CreateChatCompletionAsync: {ex}");
                return null;
            }
        }

        public async IAsyncEnumerable<JObject?> CreateChatCompletionStreamAsync(JObject request)
        {
            request["stream"] = true;
            var content = new StringContent(request.ToString(), Encoding.UTF8, "application/json");

            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, BaseUrl) { Content = content };
            using var response = await _httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();
            using var reader = new StreamReader(stream);

            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                if (line.StartsWith("data: "))
                {
                    var data = line.Substring("data: ".Length);
                    if (data != "[DONE]")
                    {
                        yield return JsonConvert.DeserializeObject<JObject>(data);
                    }
                }
            }
        }

        public void Dispose()
        {
            _httpClient.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
