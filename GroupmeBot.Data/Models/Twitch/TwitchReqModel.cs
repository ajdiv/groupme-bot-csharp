using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.Twitch
{
    /// <summary>
    /// Custom JSON req model for Twitch actions
    /// </summary>
    public class TwitchReqModel
    {
        [JsonPropertyName("channelName")]
        public string ChannelName { get; set; }

        [JsonPropertyName("channelUrl")]
        public string ChannelUrl { get; set; }

        [JsonPropertyName("currentViewers")]
        public int CurrentViewers { get; set; }

        [JsonPropertyName("game")]
        public string Game { get; set; }

        [JsonPropertyName("streamPreviewImg")]
        public string StreamPreviewImg { get; set; }

    }
}
