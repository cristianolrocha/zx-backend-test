using bot.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace bot.Services
{
    public interface IBotService
    {
        Task<Bot> CreateBot(Bot bot, CancellationToken cancellationToken);
        Task<Bot> GetBotById(Guid id, CancellationToken cancellationToken);
        Task Delete(Guid id, CancellationToken cancellationToken);
        Task Update(Bot bot, CancellationToken cancellationToken);
    }
}
