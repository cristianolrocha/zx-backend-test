using MongoDB.Driver;
using pdv.Models;
using System.Collections.Generic;

namespace pdv.Repositories.Base
{
    public interface IPdvContext
    {
        IMongoDatabase Database { get; }

        IMongoCollection<Pdv> Pdvs { get; }
        Pdv Create(Pdv pdv);
        Pdv GetPdvById(string id);
        IEnumerable<Pdv> SearchPdv(FilterDefinition<Pdv> locationQuery, int limitItems);
    }
}
