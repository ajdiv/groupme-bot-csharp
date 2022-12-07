using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.Stocks
{
    /// <summary>
    /// https://finnhub.io/docs/api/quote
    /// </summary>
    public class QuoteApiResponse
    {
        [JsonPropertyName("c")]
        public decimal CurrentPrice { get; set; }

        [JsonPropertyName("o")]
        public decimal PriceAtOpen { get; set; }

        [JsonPropertyName("d")]
        public decimal ChangeFromOpen { get; set; }

        [JsonPropertyName("dp")]
        public decimal PercentChangeFromOpen { get; set; }

        [JsonPropertyName("h")]
        public decimal DailyHigh { get; set; }

        [JsonPropertyName("l")]
        public decimal DailyLow { get; set; }
    }
}
