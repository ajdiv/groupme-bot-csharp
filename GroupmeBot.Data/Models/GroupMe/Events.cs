using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.GroupMe
{
    public class Events

    {
        [JsonPropertyName("events")]
        public IList<Event> EventList { get; set; } = new List<Event>();
    }
}
