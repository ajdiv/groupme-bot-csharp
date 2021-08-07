using GroupmeBot.Data.Constants;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.GroupMe
{
    public class GroupmeMentionsModel : GroupmeAttachmentModel

    {
        [JsonPropertyName("type")]
        public override GroupmeAttachmentTypes AttachmentType { get => GroupmeAttachmentTypes.Mentions; }

        [JsonPropertyName("loci")]
        public List<int[]> Loci { get; set; }

        [JsonPropertyName("user_ids")]
        public List<string> UserIds { get; set; }

        public GroupmeMentionsModel()
        {
            Loci = new List<int[]>();
            UserIds = new List<string>();
        }
    }
}
