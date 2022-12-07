using System;
using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.Stocks
{
    /// <summary>
    /// https://finnhub.io/api/v1/stock/profile2
    /// Note this is only a partial of what's available. See Postman
    /// </summary>
    public class Metric
    {
        [JsonPropertyName("52WeekHigh")]
        public decimal High52Weeks { get; set; }

        [JsonPropertyName("52WeekHighDate")]
        public DateTime High52WeeksDate { get; set; }

        [JsonPropertyName("52WeekLow")]
        public decimal Low52Weeks { get; set; }

        [JsonPropertyName("52WeekLowDate")]
        public DateTime Low52WeeksDate { get; set; }
    }
}
