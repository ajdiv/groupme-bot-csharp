namespace GroupmeBot.Data.Models.GroupMe
{
    /// <summary>
    /// Holds all secrets pertaining to the Groupme Bot
    /// </summary>
    public class GroupmeBotAccountDetails
    {
        public string AccessToken { get; set; }
        public string BotApiKey { get; set; }
        public string GroupId { get; set; }
    }
}
