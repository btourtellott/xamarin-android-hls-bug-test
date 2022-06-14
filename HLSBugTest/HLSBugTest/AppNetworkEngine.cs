using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HLSBugTest
{
    public static class AppNetworkEngine
    {
        public static BasicNetworkingEngine Instance => InstanceFactory(); 
        public static Func<BasicNetworkingEngine> InstanceFactory { get; set; } 
    }
    
    public class BasicApiClient
    {
        private Uri _baseUri;
        private HttpClient _httpClient;

        public static Func<HttpClientHandler> HandlerFactory { get; set; }
        public BasicApiClient(Uri baseUri)
        {
            _baseUri = baseUri;
            _httpClient = new HttpClient(HandlerFactory());
        }

        public async Task<TResponse> PostAsync<TResponse>(string pathAndQuery, object requestBody)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, new Uri(_baseUri, pathAndQuery))
            {
                Content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json")
            };
            var response = await _httpClient.SendAsync(message);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<TResponse>(content);
        }
        public async Task<TResponse> GetAsync<TResponse>(string pathAndQuery)
        {
            return JsonConvert.DeserializeObject<TResponse>(await GetStringAsync(pathAndQuery));
        }

        public async Task<String> GetStringAsync(string pathAndQuery)
        {
            var message = new HttpRequestMessage(HttpMethod.Get, new Uri(_baseUri, pathAndQuery));
            var response = await _httpClient.SendAsync(message);
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }
    }

    public class NetworkEngineConfiguration
    {
        public Uri ApiUri { get; set; }
        public Uri WwwUri { get; set; }
    }
    
    public class BasicNetworkingEngine
    {
        public BasicNetworkingEngine(NetworkEngineConfiguration networkEngineConfiguration)
        {
            Api = new BasicApiClient(networkEngineConfiguration.ApiUri);
            Www = new BasicApiClient(networkEngineConfiguration.WwwUri);
        }

        public BasicApiClient Www { get; set; }

        public BasicApiClient Api { get; }
    }
}
