using System.Threading.Tasks;

namespace GroupmeBot.WebHelpers.Extensions
{
    public interface IHttpClientWrapper
    {
        public Task<T> Get<T>(string url, string accessToken);

        public Task Post<T>(string url, T input);
    }
}
