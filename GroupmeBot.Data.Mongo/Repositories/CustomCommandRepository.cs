using GroupmeBot.Data.Mongo.Models;
using Microsoft.Extensions.Options;

namespace GroupmeBot.Data.Mongo.Repositories
{
    public class CustomCommandRepository : MongoRepository<CustomCommand>
    {
        public CustomCommandRepository(IOptions<MongoSettings> mongoDbSettings)
            : base(mongoDbSettings, "customcommands")
        { }
    }
}
