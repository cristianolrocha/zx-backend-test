using Moq;
using bot.Models;
using bot.Repositories;
using bot.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace pdvTests
{
    public class BotTests
    {
        private Mock<IBotRepository> _repository;
        private Mock<IBotService> _service;
        private Bot _bot;
        private IEnumerable<Bot> _bots;

        public BotTests()
        {
            _repository = new Mock<IBotRepository>();
            _service = new Mock<IBotService>();

            _bot = new Bot()
            {
                id = new Guid("83eb6280-61db-43c3-9851-911d154a3817"),
                name = "Mary"
            };
            _bots = new List<Bot>()
            {
                new Bot() {
                    id = new Guid("83eb6280-61db-43c3-9851-911d154a3817"),
                    name = "Mary"
                },
                new Bot() {
                    id = new Guid("b69e2129-5c5f-450c-b29a-bf0d3a30d967"),
                    name = "Albert"
                }
            };
        }

        [Fact]
        public async Task GetByIdTest()
        {
            var botRepository = _repository.Setup(x => x.GetBotById(new Guid("83eb6280-61db-43c3-9851-911d154a3817"), CancellationToken.None)).ReturnsAsync(_bot);
            Assert.NotNull(botRepository);

            var service = new BotService(_repository.Object);

            var bot = await service.GetBotById(new Guid("83eb6280-61db-43c3-9851-911d154a3817"), CancellationToken.None);

            Assert.Equal("Mary", bot.name);
        }

    }
}
