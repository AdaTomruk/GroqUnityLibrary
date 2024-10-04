using UnityEngine;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using GroqApiLibrary;

public class GroqApiUnity : MonoBehaviour
{
    private string apiKey = "YOUR_API_KEY";  
    private GroqApiClient groqApi;

    void Start()
    {
        groqApi = new GroqApiClient(apiKey);

        string exampleMessage = "Hello, how are you?";
        OnSubmit(exampleMessage);  
    }

    public async void OnSubmit(string userMessage)
    {
        if (!string.IsNullOrEmpty(userMessage))
        {
            var request = new JObject
            {
                ["model"] = "llama3-8b-8192",
                ["temperature"] = 0.5,
                ["max_tokens"] = 100,
                ["top_p"] = 1,
                ["messages"] = new JArray
                {
                    new JObject { ["role"] = "user", ["content"] = userMessage }
                }
            };

            await GetChatCompletion(request);
        }
    }

    private async Task GetChatCompletion(JObject request)
    {
        var result = await groqApi.CreateChatCompletionAsync(request);
        var response = result?["choices"]?[0]?["message"]?["content"]?.ToString() ?? "No response found";

        Debug.Log(response);
    }
}
