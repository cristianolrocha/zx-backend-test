using pdv.Models;
using pdv.Repositories;
using pdv.Configurations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace pdv.Services
{
    public class PdvService: IPdvService
    {
        private readonly IPdvRepository _pdvRepository;
        private readonly Location _options;

        public PdvService(IPdvRepository pdvRepository, IOptions<Location> options)
        {
            _pdvRepository = pdvRepository;
            _options = options.Value;
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
            var limitItems = _options.LimitItems;
            var radius = _options.Radius;

            var response = await _pdvRepository.SearchPdv(lng, lat, limitItems, radius, cancellationToken);

            return response;
        }
    }
}
