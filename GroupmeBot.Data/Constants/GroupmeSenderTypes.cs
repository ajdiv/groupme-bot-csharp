using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GroupmeSenderType
    {
        [EnumMember(Value = "user")]
        User,
        [EnumMember(Value = "bot")]
        Bot,
        [EnumMember(Value = "system")]
        System
    }
}
