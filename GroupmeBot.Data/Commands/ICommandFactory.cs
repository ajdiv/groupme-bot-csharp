namespace GroupmeBot.Data.Commands
{
    public interface ICommandFactory
    {
        Command GetCommand(string messageText);
    }
}
