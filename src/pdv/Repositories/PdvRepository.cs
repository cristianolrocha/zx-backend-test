using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;
using pdv.Models;
using pdv.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace pdv.Repositories
{
    public class PdvRepository : IPdvRepository
    {
        private readonly IPdvContext _context;

        public PdvRepository(IPdvContext context)
        {
            _context = context;
        }

        public async Task<Pdv> CreatePdv(Pdv pdv, CancellationToken cancellationToken)
        {
            return _context.Create(pdv);
        }

        public async Task<Pdv> GetPdvById(string id, CancellationToken cancellationToken)
        {
            return _context.GetPdvById(id);
        }

        public async Task<IEnumerable<Pdv>> SearchPdv(double lng, double lat, CancellationToken cancellationToken)
        {
            var point = GeoJson.Point(GeoJson.Geographic(lng, lat));
            var locationQuery = new FilterDefinitionBuilder<Pdv>().Near(tag => tag.address.coordinates, point, 100000); //fetch results that are within a 50 metre radius of the point we're searching.
            return _context.SearchPdv(locationQuery); //Limit the query to return only the top 10 results.
        }
    }
}
