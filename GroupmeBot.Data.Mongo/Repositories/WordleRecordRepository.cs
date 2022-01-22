using GroupmeBot.Data.Mongo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroupmeBot.Data.Mongo.Repositories
{
    public class WordleRecordRepository : MongoRepository<WordleRecord>
    {
        public WordleRecordRepository(IOptions<MongoSettings> mongoDbSettings)
            : base(mongoDbSettings, "wordlerecords")
        { }

        public async Task<WordleRecord> GetExistingWordleRecord(int wordleDayNum, string userId)
        {
            return await _collection.Find(x => x.DailySubmissionIdentifier == wordleDayNum && x.UserId == userId).FirstOrDefaultAsync();
        }

        public async Task<List<WordleRecord>> GetSubmissionsForToday()
        {
            return await _collection.Find(x => x.SubmissionDate == DateTime.Now.Date).ToListAsync();
        }
    }
}
