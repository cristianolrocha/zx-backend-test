using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pdv.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace pdv.Repositories.Base
{
    public static class InitalizeBD
    {
        public static async System.Threading.Tasks.Task CreateDataAsync(IMongoDatabase db)
        {
            var exists = CollectionExists(db, "pdv");

            if (exists)
                return;

            var pdvsCollection = db.GetCollection<Pdv>("pdv");

            var pdvs = LoadJson();
            
            pdvsCollection.InsertMany(pdvs);

            CreateIndexAsync(pdvsCollection);
        }

        private static async Task CreateIndexAsync(IMongoCollection<Pdv> pdvsCollection)
        {
            var builder = Builders<Pdv>.IndexKeys;
            var keys = builder.Geo2DSphere(tag => tag.address.coordinates);
            await pdvsCollection.Indexes.CreateOneAsync(keys);
        }

        private static bool CollectionExists(IMongoDatabase db, string collectionName)
        {
            using (var collections = db.ListCollectionNames())
            {
                while (collections.MoveNext())
                {
                    foreach (var name in collections.Current)
                        if (name == collectionName)
                        {
                            return true;
                        }
                }
            }

            return false;
        }

        private static List<Pdv> LoadJson()
        {
            var jsonFile = File.ReadAllText("Pdvs.json");
            var jsonArray = JObject.Parse(jsonFile).SelectToken("pdvs").ToString();

            return JsonConvert.DeserializeObject<List<Pdv>>(jsonArray);
        }
    }
}
