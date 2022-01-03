using GroupmeBot.Data.Mongo.Models;
using Microsoft.Extensions.Options;

namespace GroupmeBot.Data.Mongo.Repositories
{
    public class SpewRepository : MongoRepository<Spew>
    {
        public SpewRepository(IOptions<MongoSettings> mongoDbSettings)
            : base(mongoDbSettings, "spewmodels")
        { }
    }
}
