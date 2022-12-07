namespace GroupmeBot.Data.Models.Stocks
{
    public class StockSummary
    {
        public string Ticker { get; set; }
        public decimal CurrentPrice { get; set; }
        public decimal DailyHigh { get; set; }
        public decimal DailyLow { get; set; }
        public decimal YesterdayClose { get; set; }
    }
}
