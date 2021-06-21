using GroupmeBot.Data.Constants;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GroupmeBot.Data.Commands
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IServiceProvider _provider;

        public CommandFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public Command GetCommand(string messageText)
        {
            var allCommands = GetAllAvailableCommands();
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

            return null;
        }

        private List<Command> GetAllAvailableCommands()
        {
            var results = new List<Command>();
            var allInheritedClasses = Assembly.GetAssembly(typeof(Command)).GetTypes().Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(typeof(Command)));
            foreach (Type type in allInheritedClasses)
            {
                results.Add((Command)ActivatorUtilities.CreateInstance(_provider, type));
            }

            return results;
        }
    }
}
