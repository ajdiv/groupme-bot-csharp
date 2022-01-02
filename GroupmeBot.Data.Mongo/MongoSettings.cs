namespace GroupmeBot.Data.Mongo
{
    public class MongoSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public string SpewCollectionName { get; set; }
    }
}
