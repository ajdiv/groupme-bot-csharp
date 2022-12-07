using GroupmeBot.Data.Models.GroupMe;
using System;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Commands
{
    public abstract class Command
    {
        public virtual Task<GroupmeBotResponseModel> Execute(string message) { return Execute(); }

        public virtual Task<GroupmeBotResponseModel> Execute() { throw new NotImplementedException(); }
    }
}
