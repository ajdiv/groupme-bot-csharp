using GroupmeBot.Data.Mongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Mongo.Repositories
{
    public class SpewRepository
    {
        private readonly IMongoCollection<Spew> _spewCollection;

        public SpewRepository(IOptions<MongoSettings> mongoDbSettings)
        {
            var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);

            _spewCollection = mongoDatabase.GetCollection<Spew>(mongoDbSettings.Value.SpewCollectionName);
        }

        public async Task<List<Spew>> GetAll()
        {
            return await _spewCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Spew> GetById(string id)
        {
            return await _spewCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Spew newSpew)
        {
            await _spewCollection.InsertOneAsync(newSpew);
        }

        public async Task Update(string id, Spew updatedSpew)
        {
            await _spewCollection.ReplaceOneAsync(x => x.Id == id, updatedSpew);
        }

        public async Task Delete(string id)
        {
            await _spewCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
