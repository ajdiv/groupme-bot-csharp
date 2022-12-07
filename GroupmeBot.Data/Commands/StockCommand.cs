using GroupmeBot.Data.Constants;
using GroupmeBot.Data.Models.GroupMe;
using GroupmeBot.Data.Tools;
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

            var tickerExists = await _stockTool.IsSymbolValid(ticker);
            if (!tickerExists) return null;

            var stockData = await _stockTool.GetDailyStatus(ticker);
            var resultText = $"Stock data for ${ticker}:\n    " +
                $"Current Price: ${stockData.CurrentPrice:F}\n    " +
                $"Open: ${stockData.PriceAtOpen:F}\n    " +
                $"Change: {stockData.PercentChangeFromOpen}%";

            var results = new GroupmeBotResponseModel() { Text = resultText };
            return results;
        }
    }
}
