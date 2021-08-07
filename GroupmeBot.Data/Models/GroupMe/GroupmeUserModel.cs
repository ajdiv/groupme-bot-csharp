using GroupmeBot.Data.Constants;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.GroupMe
{
    public class GroupmeUserModel

    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("nickname")]
        public string Nickname { get; set; }

        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("muted")]
        public bool HasChatMuted { get; set; }

        [JsonPropertyName("roles")]
        public IEnumerable<GroupmeUserRoles> Roles { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

    }
}
