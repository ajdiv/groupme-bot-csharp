using GroupmeBot.Data.Constants;
using GroupmeBot.Data.Tools;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Commands
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IServiceProvider _provider;
        private readonly ICustomCommandsTool _customCommandsTool;

        public CommandFactory(IServiceProvider provider, ICustomCommandsTool customCommandsTool)
        {
            _provider = provider;
            _customCommandsTool = customCommandsTool;
        }

        public async Task<Command> GetCommand(string messageText)
        {
            var allCommands = GetAllAvailableProgrammedCommands();
            foreach (var command in allCommands)
            {
                switch (command.CommandMessageLocation)
                {
                    case CommandMessageLocations.Start:
                        if (command.CommandTextTriggers.Any(x => messageText.StartsWith(x))) return command;
                        break;
                    case CommandMessageLocations.End:
                        if (command.CommandTextTriggers.Any(x => messageText.EndsWith(x))) return command;
                        break;
                    case CommandMessageLocations.Contains:
                        if (command.CommandTextTriggers.Any(x => messageText.Contains(x))) return command;
                        break;
                    default:
                        break;
                }
            }

            return await TryGetCustomCommands(messageText);    
        }

        private List<ProgrammedCommand> GetAllAvailableProgrammedCommands()
        {
            var results = new List<ProgrammedCommand>();
            var allInheritedClasses = Assembly.GetAssembly(typeof(ProgrammedCommand)).GetTypes().Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(typeof(ProgrammedCommand)));
            foreach (Type type in allInheritedClasses)
            {
                results.Add((ProgrammedCommand)ActivatorUtilities.CreateInstance(_provider, type));
            }

            return results;
        }

        private async Task<CustomCommand> TryGetCustomCommands(string text)
        {
            if (!text.StartsWith('/')) return null;

            var allCommands = await _customCommandsTool.GetAllCustomCommands();
            var matchingCommand = allCommands.Where(x => x.CommandPrompt.ToLower().Trim() == text).FirstOrDefault();

            if (matchingCommand == null) return null;

            var result = new CustomCommand(matchingCommand.CommandResponse);
            return result;
        }
    }
}
