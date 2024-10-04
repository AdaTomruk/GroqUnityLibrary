using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace GroqApiLibrary
{
    public interface IGroqApiClient
    {
        Task<JObject?> CreateChatCompletionAsync(JObject request);
        IAsyncEnumerable<JObject?> CreateChatCompletionStreamAsync(JObject request);
    }
}
