using System;
using MongoDB.Driver;

namespace bot.Models
{
    public class Bot
    {
        public Guid id { get; set; }
        public string name { get; set; }
    }
}
