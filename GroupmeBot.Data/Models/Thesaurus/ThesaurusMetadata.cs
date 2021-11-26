using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.Thesaurus
{
    /// <summary>
    /// Information about the entry, as opposed to the actual content of the entry
    /// </summary>
    public class ThesaurusMetadata
    {
        /// <summary>
        /// Unique entry identifier within a particular dictionary data set, used in cross-references pointing to the entry
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// All of the entry's headwords, variants, inflections, undefined entry words, and defined run-on phrases. 
        /// Each stem string is a valid search term that should match this entry
        /// </summary>
        [JsonPropertyName("stems")]
        public List<string> Stems { get; set; }

        [JsonPropertyName("syns")]
        public List<List<string>> Synonyms { get; set; }

        /// <summary>
        /// True if there is a label containing "offensive" in the entry; otherwise, false.
        /// </summary>
        [JsonPropertyName("offensive")]
        public bool Offensive { get; set; }
    }
}
