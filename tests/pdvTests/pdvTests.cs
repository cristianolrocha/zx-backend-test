using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using pdv.Controllers;
using pdv.Models;
using pdv.Repositories;
using pdv.Services;
using pdv.Configurations;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace pdvTests
{
    public class PdvTests
    {
        private Mock<IPdvRepository> _repository;
        private Mock<IPdvService> _service;
        private IOptions<Location> _options;
        private Pdv _pdv;
        private IEnumerable<Pdv> _pdvs;

        public PdvTests()
        {
            _repository = new Mock<IPdvRepository>();
            _service = new Mock<IPdvService>();
            _options = Options.Create(new Location
            {
                LimitItems = 10,
                Radius = 1000
            });
            _pdv = new Pdv()
            {
                id = "1",
                tradingName = "Bebidas Teste",
                ownerName = "Teste Bebidas",
                coverageArea = new CoverageArea()
                {
                    type = "MultiPolygon",
                    coordinates = new List<List<List<List<double>>>> {
                        new List<List<List<double>>>(){ new List<List<double>> {
                            new List<double>(){ -43.45645, -23.54545 },
                                new List<double>(){ -43.45645, -23.54545 },
                                new List<double>(){ -43.45645, -23.54545 },
                                new List<double>(){ -43.45645, -23.54545 },
                                new List<double>(){ -43.45645, -23.54545 },
                                new List<double>(){ -43.45645, -23.54545 }
                            }
                        }
                    }
                },
                address = new Address
                {
                    type = "Point",
                    coordinates = new List<double>() { -43.45645, -23.54545 }
                }
            };
            _pdvs = new List<Pdv>()
            {
                new Pdv() {
                    id = "1",
                    tradingName = "Bebidas Teste",
                    ownerName = "Teste Bebidas",
                    coverageArea = new CoverageArea()
                    {
                        type = "MultiPolygon",
                        coordinates = new List<List<List<List<double>>>> {
                            new List<List<List<double>>>(){ new List<List<double>> {
                                new List<double>(){ -43.45645, -23.54545 },
                                new List<double>(){ -43.45645, -23.54545 },
                                new List<double>(){ -43.45645, -23.54545 },
                                new List<double>(){ -43.45645, -23.54545 },
                                new List<double>(){ -43.45645, -23.54545 },
                                new List<double>(){ -43.45645, -23.54545 }
                                }
                            }
                        }
                    },
                    address = new Address {
                        type = "Point",
                        coordinates = new List<double>() { -43.45645, -23.54545 }
                    }
                },
                new Pdv() {
                    id = "2",
                    tradingName = "Bebidas Novas Teste",
                    ownerName = "Teste Bebidas Novas",
                    coverageArea = new CoverageArea()
                    {
                        type = "MultiPolygon",
                        coordinates = new List<List<List<List<double>>>> {
                            new List<List<List<double>>>(){ new List<List<double>> {
                                new List<double>(){ -43.45645, -23.54545 },
                                new List<double>(){ -43.45645, -23.54545 },
                                new List<double>(){ -43.45645, -23.54545 },
                                new List<double>(){ -43.45645, -23.54545 },
                                new List<double>(){ -43.45645, -23.54545 },
                                new List<double>(){ -43.45645, -23.54545 }
                                }
                            }
                        }
                    },
                    address = new Address {
                        type = "Point",
                        coordinates = new List<double>() { -43.45645, -23.54545 }
                    }
                },
            };
        }

        [Fact]
        public async Task GetByIdTest()
        {
            var pdvRepository = _repository.Setup(x => x.GetPdvById("1", CancellationToken.None)).ReturnsAsync(_pdv);
            Assert.NotNull(pdvRepository);

            var service = new PdvService(_repository.Object, _options);

            var pdv = await service.GetPdvById("1", CancellationToken.None);

            Assert.Equal("Teste Bebidas", pdv.ownerName);
        }

        [Fact]
        public async Task SearchPdvTest()
        {
            const double lng = -43.45678;
            const double lat = -23.12345;

            var pdvRepository = _repository.Setup(x => x.SearchPdv(lng, lat, 10, 1000, CancellationToken.None)).ReturnsAsync(_pdvs);
            Assert.NotNull(pdvRepository);

            var service = new PdvService(_repository.Object, _options);

            var pdvs = await service.SearchPdv(lng, lat, CancellationToken.None);

            Assert.Equal(2, pdvs.Count());
        }

        [Fact]
        public async Task CreatePdvTest()
        {
            var pdvRepository = _repository.Setup(x => x.CreatePdv(_pdv, CancellationToken.None)).ReturnsAsync(_pdv);
            Assert.NotNull(pdvRepository);

            var service = new PdvService(_repository.Object, _options);

            var pdv = await service.CreatePdv(_pdv, CancellationToken.None);

            Assert.Equal("1", pdv.id);
        }
    }
}
