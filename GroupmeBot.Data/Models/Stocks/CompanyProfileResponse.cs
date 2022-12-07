using System;
using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.Stocks
{
    /// <summary>
    /// https://finnhub.io/api/v1/stock/profile2
    /// </summary>
    public class CompanyProfileResponse
    {
        [JsonPropertyName("country")]
        public string CountryCode { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("exchange")]
        public string Exchange { get; set; }

        [JsonPropertyName("ipo")]
        public DateTime DateIPO { get; set; }

        [JsonPropertyName("logo")]
        public string LogoUrl { get; set; }

        [JsonPropertyName("marketCapitalization")]
        public decimal MarketCap { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("shareOutstanding")]
        public decimal NumSharesOutstanding { get; set; }

        [JsonPropertyName("ticker")]
        public string Ticker { get; set; }

        [JsonPropertyName("weburl")]
        public string Website { get; set; }
    }
}
