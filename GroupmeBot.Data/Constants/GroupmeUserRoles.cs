using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Constants
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum GroupmeUserRoles
    {
        Admin,
        Owner,
        User
    }
}
