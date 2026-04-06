
using Newtonsoft.Json;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace THSDotNetCore.Shared
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T?> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            return default;
        }

        public async Task<T?> PostAsync<T>(string url, object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var contentData = new StringContent(json, Encoding.UTF8, Application.Json);
            var response = await _httpClient.PostAsync(url, contentData);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            return default;
        }

        public async Task<T?> PutAsync<T>(string url, object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var contentData = new StringContent(json, Encoding.UTF8, Application.Json);
            var response = await _httpClient.PutAsync(url, contentData);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            return default;
        }

        public async Task<T?> PatchAsync<T>(string url, object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var contentData = new StringContent(json, Encoding.UTF8, Application.Json);
            var response = await _httpClient.PatchAsync(url, contentData);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            return default;
        }

        public async Task<bool> DeleteAsync(string url)
        {
            var response = await _httpClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
    }
}
