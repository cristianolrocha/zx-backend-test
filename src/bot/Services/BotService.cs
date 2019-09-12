using bot.Models;
using bot.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace bot.Services
{
    public class BotService : IBotService
    {
        private readonly IBotRepository _botRepository;

        public BotService(IBotRepository botRepository)
        {
            _botRepository = botRepository;
        }

        public async Task<Bot> CreateBot(Bot bot, CancellationToken cancellationToken) => await _botRepository.CreateBot(bot, cancellationToken);

        public async Task<Bot> GetBotById(Guid id, CancellationToken cancellationToken) => await _botRepository.GetBotById(id, cancellationToken);

        public async Task Delete(Guid id, CancellationToken cancellationToken) => await _botRepository.Delete(id, cancellationToken);

        public async Task Update(Bot bot, CancellationToken cancellationToken) => await _botRepository.Update(bot, cancellationToken);
    }
}
