using GroupmeBot.Data.Constants;
using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.GroupMe
{
    public class GroupmeImageModel : GroupmeAttachmentModel

    {
        [JsonPropertyName("type")]
        public override GroupmeAttachmentTypes AttachmentType { get => GroupmeAttachmentTypes.Image; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
