using GroupmeBot.WebHelpers.Converters;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GroupmeBot.Data.Models.GroupMe
{
    public class GroupmeGroupModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("creator_user_id")]
        public string CreatedByUserId { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("group_id")]
        public string GroupId { get; set; }

        [JsonPropertyName("office_mode")]
        public bool IsOfficeMode { get; set; }

        [JsonPropertyName("join_question")]
        public string JoinQuestion { get; set; }

        [JsonPropertyName("like_icon")]
        public GroupmeLikeIcon LikeIcon { get; set; }

        [JsonPropertyName("max_members")]
        public int MaxMembers { get; set; }

        [JsonPropertyName("members")]
        public IEnumerable<GroupmeUserModel> Members { get; set; }

        [JsonPropertyName("message_deletion_period")]
        public int MessageDeletePeriodDays { get; set; }

        [JsonPropertyName("messages")]
        public GroupmeMessageSummaryModel MessageSummary { get; set; }

        [JsonPropertyName("muted_until")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime MutedUntil { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("phone_number")]
        public string Phone { get; set; }

        [JsonPropertyName("requires_approval")]
        public bool RequiresApprovalToJoin { get; set; }

        [JsonPropertyName("share_qr_code_url")]
        public string ShareQrCodeUrl { get; set; }

        [JsonPropertyName("share_url")]
        public string ShareUrl { get; set; }

        [JsonPropertyName("show_join_question")]
        public bool ShowQuestionBeforeJoin { get; set; }

        [JsonPropertyName("theme_name")]
        public string ThemeName { get; set; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime UpdatedAt { get; set; }
    }
}
