using System.Threading.Tasks;

namespace GroupmeBot.WebHelpers.Extensions
{
    public interface IHttpClientWrapper
    {
        public Task<T> Get<T>(string url);
        public Task<T> Get<T>(string url, string accessToken);
        public Task<T> Get<T>(string url, string accessToken, object data);

        public Task Post<T>(string url, T input);

    }
}
