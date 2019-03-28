using pdv.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace pdv.Services
{
    public interface IPdvService
    {
        Task<Pdv> CreatePdv(Pdv pdv, CancellationToken cancellationToken);
        Task<Pdv> GetPdvById(string id, CancellationToken cancellationToken);
        Task<IEnumerable<Pdv>> SearchPdv(double lng, double lat, CancellationToken cancellationToken);
    }
}
