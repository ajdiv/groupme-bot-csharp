using GroupmeBot.Data.Constants;
using GroupmeBot.Data.Models.GroupMe;
using GroupmeBot.Data.Tools;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Commands
{
    public class StockCommand : ProgrammedCommand
    {
        private readonly StockTool _stockTool;

        public override string[] CommandTextTriggers { get => new string[] { "$" }; }

        public override CommandMessageLocations CommandMessageLocation { get => CommandMessageLocations.Contains; }

        public override string HelpText { get => "retrieves stock information for the provided ticker"; }

        public StockCommand(StockTool stockTool)
        {
            _stockTool = stockTool;
        }

        public override async Task<GroupmeBotResponseModel> Execute(string message)
        {
            var ticker = message?.Split(' ')?.Where(x => x.Contains('$')).FirstOrDefault()?.Replace("$", string.Empty);
            if (ticker == null) return null;

            var companyData = await _stockTool.GetCompanyData(ticker);
            if (companyData.Ticker == null) return null;

            var dailyData = await _stockTool.GetDailyStatus(ticker);
            var basicFinancials = await _stockTool.GetBasicFinancials(ticker);

            var resultText = $"Stock data for {companyData.Name} (${companyData.Ticker}):\n    " +
                $"Current Price: ${dailyData.CurrentPrice:F}\n    " +
                $"Open: ${dailyData.PriceAtOpen:F}\n    " +
                $"Change: {dailyData.PercentChangeFromOpen:F}%\n    " +
                $"Market Cap: ${GetMarketCapString(companyData.MarketCap)}\n    " +
                $"52 Week High: ${basicFinancials.High52Weeks:F} on {basicFinancials.High52WeeksDate.ToShortDateString()}\n    " +
                $"52 Week Low: ${basicFinancials.Low52Weeks:F} on {basicFinancials.Low52WeeksDate.ToShortDateString()}";

            var results = new GroupmeBotResponseModel() { Text = resultText };
            return results;
        }

        private string GetMarketCapString(decimal mktCapMillions)
        {
            decimal num = mktCapMillions * 1000000;

            if (num > 999999999 || num < -999999999)
            {
                return num.ToString("0,,,.###B", CultureInfo.InvariantCulture);
            }
            else if (num > 999999 || num < -999999)
            {
                return num.ToString("0,,.##M", CultureInfo.InvariantCulture);
            }
            else if (num > 999 || num < -999)
            {
                return num.ToString("0,.#K", CultureInfo.InvariantCulture);
            }
            else
            {
                return num.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}
