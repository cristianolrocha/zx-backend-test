using MongoDB.Driver;
using bot.Models;
using System;

namespace bot.Repositories.Base
{
    public interface IBotContext
    {
        IMongoDatabase Database { get; }

        Bot Create(Bot pdv);
        Bot GetBotById(Guid id);
        void Update(Bot pdv);
        void Delete(Guid id);
    }
}
