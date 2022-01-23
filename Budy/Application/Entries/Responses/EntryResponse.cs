using System;

namespace Budy.Application.Entries.Responses
{
    public class EntryResponse
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime OccuredAt { get; private set; }
        public string Type { get; private set; }

        public EntryResponse(int id, string name, decimal amount, DateTime occuredAt, string type)
        {
            Id = id;
            Name = name;
            Amount = amount;
            OccuredAt = occuredAt;
            Type = type;
        }
    }
}