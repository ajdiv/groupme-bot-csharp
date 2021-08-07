using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.GroupMe
{
    /// <summary>
    /// Model that comes after making a request to the Groupme API
    /// </summary>
    public class GroupmeApiResponseModel<T>
    {
        [JsonPropertyName("response")]
        public T Response { get; set; }

    }
}
