using GroupmeBot.Data.Models.GroupMe;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Tools
{
    public interface IGroupmeTool
    {
        Task<List<GroupmeUserModel>> GetGroupMembers();
        public Task<IList<GroupmeMessageModel>> GetMessages(int limit, string beforeId, string afterId);
        public Task<(string, List<int[]>, List<string>)> TagAllMembersInGroup();
    }
}
