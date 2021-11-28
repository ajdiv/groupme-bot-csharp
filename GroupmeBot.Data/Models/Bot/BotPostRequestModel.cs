using GroupmeBot.Data.Constants;
using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.GroupMe
{
    /// <summary>
    /// Custom POST request sent from external areas
    /// </summary>
    public class BotPostRequestModel
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("eventType")]
        public ExternalEventTypes? EventType { get; set; }
    }
}
