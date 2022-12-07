using GroupmeBot.Data.Models.Stocks;
using GroupmeBot.WebHelpers.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Tools
{
    public class StockTool
    {
        private readonly string _finnhubUrl = "https://finnhub.io/api/v1/";

        private readonly IHttpClientWrapper _client;
        private readonly StockSettings _settings;

        public StockTool(IOptions<StockSettings> settings, IHttpClientWrapper client)
        {
            _settings = settings.Value ?? throw new ArgumentException("No stock settings provided in environment config");
            _client = client;
        }


        public async Task<Metric> GetBasicFinancials(string ticker)
        {
            var url = $"{_finnhubUrl}stock/metric?symbol={ticker}&metric=all&token={_settings.ApiKey}";
            var results = await _client.Get<BasicFinancialsApiResponse>(url);
            return results?.Data;
        }

        public async Task<CompanyProfileApiResponse> GetCompanyData(string ticker)
        {
            var url = $"{_finnhubUrl}stock/profile2?symbol={ticker}&token={_settings.ApiKey}";

            var results = await _client.Get<CompanyProfileApiResponse>(url);
            return results;
        }

        public async Task<QuoteApiResponse> GetDailyStatus(string ticker)
        {
            var url = $"{_finnhubUrl}quote?symbol={ticker}&token={_settings.ApiKey}";

            var results = await _client.Get<QuoteApiResponse>(url);
            return results;
        }

    }
}
