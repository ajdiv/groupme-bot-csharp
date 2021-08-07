using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GroupmeAttachmentTypes
    {
        [EnumMember(Value = "image")]
        Image,
        [EnumMember(Value = "mentions")]
        Mentions
    }
}
