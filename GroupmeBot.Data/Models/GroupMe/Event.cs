using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.GroupMe
{
    public class Event

    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("start_at")]
        public DateTime StartAt { get; set; }

        [JsonPropertyName("end_at")]
        public DateTime EndAt { get; set; }

        [JsonPropertyName("is_all_day")]
        public bool AllDayEvent { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("conversation_id")]
        public string ConversationId { get; set; }

        [JsonPropertyName("event_id")]
        public string EventId { get; set; }

        [JsonPropertyName("creator_id")]
        public string CreatorId { get; set; }

        [JsonPropertyName("going")]
        public IList<string> Going { get; set; } = new List<string>();

        [JsonPropertyName("not_going")]
        public IList<string> NotGoing { get; set; } = new List<string>();

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}
