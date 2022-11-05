using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;

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
            try
            {
                var result = await JsonSerializer.DeserializeAsync<T>(response);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<T> Get<T>(string url, string accessToken, object data)
        {
            var optionsString = ObjToQueryString(data);
            url += "?" + optionsString;

            return await Get<T>(url, accessToken);
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
            catch (Exception)
            {
                throw;
            }

        }

        private static string ObjToQueryString(object obj)
        {
            var options = new JsonSerializerOptions() { IgnoreNullValues = true };

            var serialized = JsonSerializer.Serialize(obj, options);
            var deserializedDict = JsonSerializer.Deserialize<IDictionary<string, object>>(serialized);
            var step3 = deserializedDict.Select(x => x.Key + "=" + x.Value.ToString());
            //var step3 = deserializedDict.Select(x => HttpUtility.UrlEncode(x.Key) + "=" + HttpUtility.UrlEncode(x.Value.ToString()));

            var result = string.Join("&", step3);
            return result;
        }
    }
}
