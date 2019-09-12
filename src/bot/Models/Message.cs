using System;

namespace bot.Models
{
    public class Message
    {
        public Guid id { get; set; } = new Guid();
        public Guid conversationId { get; set; }
        public DateTimeOffset timestamp { get; set; }
        public Guid from { get; set; }
        public Guid to { get; set; }
        public string text { get; set; }
    }
}
