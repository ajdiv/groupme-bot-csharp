using System.Threading.Tasks;

namespace GroupmeBot.Data.Commands
{
    public interface ICommandFactory
    {
        Task<Command> GetCommand(string messageText);
    }
}
