namespace bot.Repositories.Base
{
    public class ServerConfig
    {
        public MongoDBConfig Mongo { get; set; } = new MongoDBConfig();
    }
}
