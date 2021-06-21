using GroupmeBot.Data.Constants;
using GroupmeBot.WebHelpers.Converters;
using System;
using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.GroupMe
{
    public class GroupmeRequestModel
    {
        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("group_id")]
        public string GroupId { get; set; }

        [JsonPropertyName("system")]
        public bool IsSystemMessage { get; set; }

        [JsonPropertyName("name")]
        public string Nickname { get; set; }

        [JsonPropertyName("id")]
        public string RequestId { get; set; }

        [JsonPropertyName("sender_id")]
        public string SenderId { get; set; }

        [JsonPropertyName("sender_type")]
        public GroupmeSenderType SenderType { get; set; }

        [JsonPropertyName("source_guid")]
        public string SourceGuid { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}
