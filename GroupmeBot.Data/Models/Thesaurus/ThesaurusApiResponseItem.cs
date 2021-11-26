using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.Thesaurus
{
    /// <summary>
    /// Model that comes after making a request to the Thesaurus API
    /// </summary>
    public class ThesaurusApiResponseItem
    {
        /// <summary>
        /// Information about the entry, as opposed to the actual content of the entry
        /// </summary>
        [JsonPropertyName("meta")]
        public ThesaurusMetadata Metadata { get; set; }

        /// <summary>
        /// Word being defined or translated in a dictionary entry
        /// </summary>
        [JsonPropertyName("hwi")]
        public HeadwordInfo HeadwordInfo { get; set; }

        /// <summary>
        /// Describes the grammatical function of a headword or undefined entry word, such as "noun" or "adjective"
        /// </summary>
        [JsonPropertyName("fl")]
        public string FunctionalLabel { get; set; }

        /// <summary>
        /// Highly abridged version of the main definition section, consisting of just the definition text for the first three senses.
        /// </summary>
        [JsonPropertyName("shortdef")]
        public List<string> ShortDefinition { get; set; }
    }
}
