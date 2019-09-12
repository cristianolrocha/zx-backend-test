using bot.Models;
using bot.Repositories.Base;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace bot.Repositories
{
    public class BotRepository : IBotRepository
    {
        private readonly IBotContext _context;

        public BotRepository(IBotContext context)
        {
            _context = context;
        }

        public async Task<Bot> CreateBot(Bot bot, CancellationToken cancellationToken) => _context.Create(bot);

        public async Task<Bot> GetBotById(Guid id, CancellationToken cancellationToken) => _context.GetBotById(id);

        public async Task Delete(Guid id, CancellationToken cancellationToken) => _context.Delete(id);

        public async Task Update(Bot bot, CancellationToken cancellationToken) => _context.Update(bot);
    }
}
