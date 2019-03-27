using pdv.Models;
using System.Threading;
using System.Threading.Tasks;

namespace pdv.Repositories
{
    public interface IPdvRepository
    {
        Task<Pdv> CreatePdv(Pdv pdv, CancellationToken cancellationToken);
        Task<Pdv> GetPdvById(string id, CancellationToken cancellationToken);
        Task<Pdv> SearchPdv(double lng, double lat, CancellationToken cancellationToken);
    }
}
