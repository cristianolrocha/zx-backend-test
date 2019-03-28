using Microsoft.Extensions.Options;
using MongoDB.Driver;
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

        public Pdv Create(Pdv pdv)
        {
            Pdvs.InsertOne(pdv);

            return pdv;
        }

        public Pdv GetPdvById(string id)
        {
            return Pdvs.Find(x => x.id.Equals(id)).FirstOrDefault();
        }

        public IEnumerable<Pdv> SearchPdv(FilterDefinition<Pdv> locationQuery, int limitItems)
        {
            try
            {
                var pdvs = Pdvs.Find(locationQuery).Limit(limitItems);

                if (pdvs == null)
                {
                    return Enumerable.Empty<Pdv>();
                }

                return pdvs.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

