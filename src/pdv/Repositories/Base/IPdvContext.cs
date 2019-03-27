using MongoDB.Driver;
using pdv.Models;

namespace pdv.Repositories.Base
{
    public interface IPdvContext
    {
        IMongoDatabase Database { get; }

        IMongoCollection<Pdv> Pdvs { get; }
        Pdv Create(Pdv p);
        Pdv GetPdvById(string id);
    }
}
