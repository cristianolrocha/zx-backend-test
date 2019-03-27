using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using pdv.Models;

namespace pdv.Repositories.Base
{
    public class PdvContext : IPdvContext
    {
        public IMongoDatabase Database { get; }

        public PdvContext(IOptions<ServerConfig> config)
        {
            var mongoConfig = config.Value.Mongo;

            var client = new MongoClient(mongoConfig.ConnectionString);
            Database = client.GetDatabase(mongoConfig.Database);
            // InitalizeBD.CreateData(_db);
        }

        public IMongoCollection<Pdv> Pdvs => Database.GetCollection<Pdv>("pdv");

        public Pdv Create(Pdv p)
        {
            Pdvs.InsertOne(p);

            return p;
        }

        public Pdv GetPdvById(string id)
        {
            return Pdvs.Find(x => x.id.Equals(id)).FirstOrDefault();
        }
    }
}

