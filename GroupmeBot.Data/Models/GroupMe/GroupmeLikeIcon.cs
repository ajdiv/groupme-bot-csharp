using GroupmeBot.Data.Constants;
using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.GroupMe
{
    public class GroupmeLikeIcon
    {
        [JsonPropertyName("type")]
        public GroupmeLikeIconTypes Type { get; set; }

        [JsonPropertyName("pack_id")]
        public int PackId { get; set; }

        [JsonPropertyName("pack_index")]
        public int PackIndex { get; set; }
    }
}
