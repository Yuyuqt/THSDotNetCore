using Newtonsoft.Json;
using RestSharp;

namespace THSDotNetCore.Shared
{
    public class RestClientService
    {
        private readonly RestClient _client;

        public RestClientService(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public async Task<T?> GetAsync<T>(string endpoint)
        {
            var request = new RestRequest(endpoint);
            var response = await _client.GetAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(response.Content!);
            }
            return default;
        }

        public async Task<T?> PostAsync<T>(string endpoint, object data)
        {
            var request = new RestRequest(endpoint, Method.Post);
            request.AddJsonBody(data);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(response.Content!);
            }
            return default;
        }

        public async Task<T?> PutAsync<T>(string endpoint, object data)
        {
            var request = new RestRequest(endpoint, Method.Put);
            request.AddJsonBody(data);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(response.Content!);
            }
            return default;
        }

        public async Task<T?> PatchAsync<T>(string endpoint, object data)
        {
            var request = new RestRequest(endpoint, Method.Patch);
            request.AddJsonBody(data);
            var response = await _client.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(response.Content!);
            }
            return default;
        }

        public async Task<bool> DeleteAsync(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Delete);
            var response = await _client.ExecuteAsync(request);
            return response.IsSuccessStatusCode;
        }
    }
}
