using GroupmeBot.Data.Models.CustomCommands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Tools
{
    public interface ICustomCommandsTool
    {
        public Task CreateCommand(CustomCommandModel model);
        public Task DeleteCommand(string id);
        public Task<List<CustomCommandModel>> GetAllCustomCommands();
    }
}
