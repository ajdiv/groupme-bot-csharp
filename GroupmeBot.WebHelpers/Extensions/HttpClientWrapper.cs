using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GroupmeBot.WebHelpers.Extensions
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientWrapper(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        public async Task<T> Get<T>(string url, string accessToken)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("X-Access-Token", accessToken);

            var response = await client.GetStreamAsync(url);
            var result = await JsonSerializer.DeserializeAsync<T>(response);

            return result;
        }

        public async Task Post<T>(string url, T input)
        {
            var client = _httpClientFactory.CreateClient();
            var options = new JsonSerializerOptions
            {
                Converters = {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
            };

            try
            {
                var resultJson = JsonSerializer.Serialize(input, options);
                var results = new StringContent(resultJson, System.Text.Encoding.UTF8, "application/json");

                await client.PostAsync(url, results);
            }
            catch (Exception e)
            {
                var hi = 2;
            }

        }
    }
}
