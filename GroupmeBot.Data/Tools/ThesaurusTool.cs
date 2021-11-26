using GroupmeBot.Data.Models.Thesaurus;
using GroupmeBot.WebHelpers.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Tools
{
    public class ThesaurusTool : IThesaurusTool
    {
        private readonly ThesaurusAccountDetails _thesaurusAccountDetails;
        private readonly IHttpClientWrapper _client;
        private readonly IGroupmeTool _gmeTool;

        private readonly List<string> ignoreWords = new List<string>() { "i", "me", "my", "myself", "we", "our", "ours", "ourselves", "you", "your", "yours", "yourself", "yourselves", "he", "him", "his", "himself", "she", "her", "hers", "herself", "it", "its", "itself", "they", "them", "their", "theirs", "themselves", "what", "which", "who", "whom", "this", "that", "these", "those", "am", "is", "are", "was", "were", "be", "been", "being", "have", "has", "had", "having", "do", "does", "did", "doing", "a", "an", "the", "and", "but", "if", "or", "because", "as", "until", "while", "of", "at", "by", "for", "with", "about", "against", "between", "into", "through", "during", "before", "after", "above", "below", "to", "from", "up", "down", "in", "out", "on", "off", "over", "under", "again", "further", "then", "once", "here", "there", "when", "where", "why", "how", "all", "any", "both", "each", "few", "more", "most", "other", "some", "such", "no", "nor", "not", "only", "own", "same", "so", "than", "too", "very", "s", "t", "can", "will", "just", "don", "should", "now" };
        private readonly string THESAURUS_URL_PREFIX = "https://www.dictionaryapi.com/api/v3/references/thesaurus/json/";

        public ThesaurusTool(IOptions<ThesaurusAccountDetails> thesaurusAccountDetails, IHttpClientWrapper client, IGroupmeTool gmeTool)
        {
            _thesaurusAccountDetails = thesaurusAccountDetails.Value ?? throw new ArgumentException(nameof(thesaurusAccountDetails));
            _client = client;
            _gmeTool = gmeTool;
        }

        public async Task<string> ThesaurizeLastMessage()
        {
            // Get last 2 messages since the most recent one was the command itself
            var lastMessages = await _gmeTool.GetMessages(2, null, null);
            var lastMessageText = lastMessages.Skip(1).First().Text;

            var scrubbedWords = ParseAndScrub(lastMessageText);

            var result = "";
            foreach (var word in scrubbedWords)
            {
                if (!WordCanHaveSynonym(word))
                {
                    result += word + " ";
                    continue;
                }
                var url = THESAURUS_URL_PREFIX + word + "?key=" + _thesaurusAccountDetails.ApiKey;

                try
                {
                    var results = await _client.Get<List<ThesaurusApiResponseItem>>(url, _thesaurusAccountDetails.ApiKey);
                    var syns = results.FirstOrDefault()?.Metadata?.Synonyms.FirstOrDefault() ?? new List<string>();
                    if (syns.Count > 0)
                    {
                        var randomNum = new Random().Next(syns.Count - 1);
                        result += results[0].Metadata.Synonyms[0][randomNum] + " ";
                    }
                }
                catch (JsonException)
                {
                    result += word + " ";
                }
            }

            return result;
        }

        private List<string> ParseAndScrub(string text)
        {
            var textArr = text.Trim().Split(" ");
            var result = new List<string>();

            if (string.IsNullOrEmpty(text)) return result;

            var pattern = @"/[^A-Za-z0-9]/g";
            foreach (var word in textArr)
            {
                var scrubbed = Regex.Replace(word, pattern, "");
                if (!string.IsNullOrWhiteSpace(scrubbed)) result.Add(scrubbed);
            }

            return result;
        }

        private string PickRandomWord(List<string> synonyms)
        {
            if (synonyms == null || synonyms.Count == 0) return "";

            var result = synonyms[(int)Math.Floor(new Random().NextDouble() * synonyms.Count)];
            return result;
        }

        private bool WordCanHaveSynonym(string word)
        {
            var isCommonWord = ignoreWords.Contains(word);
            var isProperNoun = char.IsUpper(word.First());

            return !isCommonWord && !isProperNoun;
        }
    }
}
