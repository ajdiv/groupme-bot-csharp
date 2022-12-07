using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.Stocks
{
    /// <summary>
    /// https://finnhub.io/api/v1/stock/metric
    /// </summary>
    public class BasicFinancialsApiResponse
    {
        [JsonPropertyName("metric")]
        public Metric Data { get; set; }
    }
}
