using pdv.Models;
using pdv.Repositories.Base;
using System;
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

        public async Task<Pdv> SearchPdv(double lng, double lat, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
