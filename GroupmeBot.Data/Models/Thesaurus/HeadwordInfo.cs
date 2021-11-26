using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.Thesaurus
{
    /// <summary>
    /// Word being defined or translated in a dictionary entry
    /// </summary>
    public class HeadwordInfo
    {
        /// <summary>
        /// Top-level member of the dictionary entry
        /// </summary>
        [JsonPropertyName("hw")]
        public string Headword { get; set; }
    }
}
