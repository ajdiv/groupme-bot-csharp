﻿using GroupmeBot.Data.Models.CustomCommands;
using GroupmeBot.Data.Mongo.Models;
using GroupmeBot.Data.Mongo.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Tools
{
    public class CustomCommandsTool : ICustomCommandsTool
    {
        private readonly CustomCommandRepository _customCommandRepo;

        public CustomCommandsTool(CustomCommandRepository customCommandRepo)
        {
            _customCommandRepo = customCommandRepo;
        }

        public async Task CreateCommand(CustomCommandModel model)
        {
            // TODO: ADD VALIDATION FOR MODEL NOT STARTING WITH SLASH /
            // TODO: ADD VALIDATION FOR EXISTING OR COMPLEX PRECODED COMMANDS /
            var newCommand = new CustomCommand()
            {
                CommandPrompt = model.CommandPrompt,
                CommandResponse = model.CommandResponse
            };

            await _customCommandRepo.Create(newCommand);
        }


        public async Task<List<CustomCommandModel>> GetAllCustomCommands()
        {
            var mongoResults = await _customCommandRepo.GetAll();
            var results = mongoResults.Select(x => new CustomCommandModel(x)).ToList();
            return results;
        }
    }
}
