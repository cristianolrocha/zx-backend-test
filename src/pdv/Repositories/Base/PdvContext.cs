using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using pdv.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Pdv> SearchPdv(FilterDefinition<Pdv> locationQuery)
        {
            try
            {
                var pdvs = Pdvs.Find(locationQuery).Limit(10);

                if (pdvs != null)
                {
                    // var abc = pdvs.FirstOrDefault();
                    return pdvs.ToList(); // Enumerable.Empty<Pdv>();
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

