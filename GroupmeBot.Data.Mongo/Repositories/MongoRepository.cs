using GroupmeBot.Data.Mongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Mongo.Repositories
{
    public abstract class MongoRepository<T> where T : MongoModel
    {
        protected readonly IMongoCollection<T> _collection;

        public MongoRepository(IOptions<MongoSettings> mongoDbSettings, string collectionName)
        {
            var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<T>(collectionName);
        }

        public async Task<List<T>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<T> GetById(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(T newT)
        {
            await _collection.InsertOneAsync(newT);
        }

        public async Task Update(string id, T updatedT)
        {
            await _collection.ReplaceOneAsync(x => x.Id == id, updatedT);
        }

        public async Task Delete(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
