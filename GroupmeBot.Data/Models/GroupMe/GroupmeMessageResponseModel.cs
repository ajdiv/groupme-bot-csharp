using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.GroupMe
{
    public class GroupmeMessageResponseModel
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }


        [JsonPropertyName("messages")]
        public List<GroupmeMessageModel> Messages { get; set; }
    }
}
