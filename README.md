# Groq Unity API Support Library 🚀

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Version](https://img.shields.io/badge/version-1.0.0-green.svg)

## 💡 Introduction 

This library simplifies the integration of **Groq API** functionalities into Unity projects, making it easier for developers to utilize Groq's powerful capabilities within the Unity environment. The current focus is on providing streamlined access to **Groq's Chat Completion** functionality 🗨️, with plans to support additional features in the future.

### ✅ Current Features 

- **Groq Chat Completion**: Integrate AI-driven chat functionality into your Unity projects. Perfect for dialogue systems, NPC interactions, or any scenario requiring natural language processing.

### 🔮 Upcoming Features 

We are actively working on expanding the library to support additional Groq API features, including:

- **Streaming Chat Completion**: Real-time chat completion to support dynamic conversational experiences ⏳.
- **Audio Translation**: Convert spoken language into another language directly within Unity 🌍.
- **Audio Transcription**: Transform speech into text for in-game narration, commands, or dialogue transcription 🎤📝.

## 📦 Installation

To use this library in your unity project:
- Clone this repository or download the GroqApiClient.cs file.
- Add the file to your project.
- Ensure your project has the Newtonsoft.Json library.

## 🚀 Getting Started 

Here's a simple example to get you started:

```csharp
var request = new JObject
{
    ["model"] = "llama3-8b-8192",
    ["temperature"] = 0.5,
    ["max_tokens"] = 100,
    ["top_p"] = 1,
    ["stop"] = "TERMINATE",
    ["messages"] = new JArray
    {
        new JObject
        {
            ["role"] = "system",
            ["content"] = "You are a helpful assistant."
        },
        new JObject
        {
            ["role"] = "user",
            ["content"] = "Write a haiku about life"
        }
    }
};

await GetChatCompletion(request);

private async Task GetChatCompletion(JObject request)
{
    var result = await groqApi.CreateChatCompletionAsync(request);
    var response = result?["choices"]?[0]?["message"]?["content"]?.ToString() ?? "No response found";
    responseText.text = response;
}
```


## 📄 License

This library is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
