using GroupmeBot.Data.Models.GroupMe;
using GroupmeBot.WebHelpers.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Tools
{
    public class GroupmeTool : IGroupmeTool
    {
        private readonly GroupmeBotAccountDetails _botDetails;
        private readonly IHttpClientWrapper _client;

        private readonly string _apiUrl = "https://api.groupme.com/v3/groups/";

        public GroupmeTool(IOptions<GroupmeBotAccountDetails> botDetails, IHttpClientWrapper client)
        {
            _botDetails = botDetails.Value ?? throw new ArgumentException(nameof(botDetails));
            _client = client;
        }

        public async Task<(string, List<int[]>, List<string>)> TagAllMembersInGroup()
        {
            var url = _apiUrl + _botDetails.GroupId;
            var apiResults = await _client.Get<GroupmeApiResponseModel<GroupmeGroupModel>>(url, _botDetails.AccessToken);
            var groupDetails = apiResults.Response;

            var results = BuildMentionModel(groupDetails.Members);

            return results;
        }

        private (string, List<int[]>, List<string>) BuildMentionModel(IEnumerable<GroupmeUserModel> members)
        {
            var loci = new List<int[]>();
            var userIds = new List<string>();
            var currentLocusIndex = 0;
            var resultText = string.Empty;

            foreach (var member in members)
            {
                var locus = new int[] { currentLocusIndex, member.Nickname.Length + 1 }; // + 1 to account for the "@"

                resultText += loci.Count == 0 ? "@" + member.Nickname : " @" + member.Nickname;
                currentLocusIndex = resultText.Length + 1; // to account for the space

                userIds.Add(member.UserId);
                loci.Add(locus);
            }

            return (resultText, loci, userIds);
        }
    }
}
