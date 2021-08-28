using GroupmeBot.Data.Constants;
using GroupmeBot.WebHelpers.Converters;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.GroupMe
{
    public class GroupmeMessageModel
    {
        public GroupmeMessageModel() { }
        [JsonPropertyName("attachments")]
        public IList<GroupmeAttachmentModel> Attachments { get; set; }


        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreatedAt { get; set; }


        [JsonPropertyName("favorited_by")]
        public IList<string> FavoritedBy { get; set; }


        [JsonPropertyName("group_id")]
        public string GroupId { get; set; }


        [JsonPropertyName("id")]
        public string Id { get; set; }


        [JsonPropertyName("name")]
        public string Name { get; set; }


        [JsonPropertyName("sender_id")]
        public string SenderId { get; set; }


        [JsonPropertyName("sender_type")]
        public GroupmeSenderType SenderType { get; set; }


        [JsonPropertyName("source_guid")]
        public string SourceGuid { get; set; }


        [JsonPropertyName("system")]
        public bool System { get; set; }


        [JsonPropertyName("text")]
        public string Text { get; set; }


        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}
