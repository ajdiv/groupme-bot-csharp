using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.GroupMe
{
    /// <summary>
    /// Model that gets sent to Groupme servers to be parsed into a message
    /// </summary>
    public class GroupmeBotResponseModel
    {
        [JsonPropertyName("attachments")]
        public IList<GroupmeMentionsModel> Attachments { get; set; }

        [JsonPropertyName("bot_id")]
        public string BotId { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        public GroupmeBotResponseModel()
        {
            Attachments = new List<GroupmeMentionsModel>();
        }
    }
}
