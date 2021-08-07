using GroupmeBot.WebHelpers.Converters;
using System;
using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.GroupMe
{
    public class GroupmeMessageSummaryModel
    {
        [JsonPropertyName("count")]
        public int MessageCount { get; set; }

        [JsonPropertyName("last_message_id")]
        public string LastMessageId { get; set; }

        [JsonPropertyName("last_message_created_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastMessageCreatedAt { get; set; }

    }
}
