using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GroupmeLikeIconTypes
    {
        [EnumMember(Value = "emoji")]
        Emoji,
    }
}
