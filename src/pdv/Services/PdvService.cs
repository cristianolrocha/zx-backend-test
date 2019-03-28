using pdv.Models;
using pdv.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace pdv.Services
{
    public class PdvService
    {
        private readonly IPdvRepository _pdvRepository;

        public PdvService(IPdvRepository pdvRepository)
        {
            _pdvRepository = pdvRepository;
        }

        public async Task<Pdv> CreatePdv(Pdv pdv, CancellationToken cancellationToken)
        {
            var response = await _pdvRepository.CreatePdv(pdv, cancellationToken);

            return response;
        }

        public async Task<Pdv> GetPdvById(string id, CancellationToken cancellationToken)
        {
            var response = await _pdvRepository.GetPdvById(id, cancellationToken);

            return response;
        }

        public async Task<IEnumerable<Pdv>> SearchPdv(double lng, double lat, CancellationToken cancellationToken)
        {
            var response = await _pdvRepository.SearchPdv(lng, lat, cancellationToken);

            return response;
        }
    }
}
