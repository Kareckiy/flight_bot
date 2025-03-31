using FlightsBot.Domain.Abstractions;
using FlightsBot.Domain.Enums;

namespace FlightsBot.Domain.Entities;

public class Carrier: TimeTrackableEntity
{
    public Guid Id { get; set; }

    public string Code { get; set; } = String.Empty;

    public DataProvider CodeDataProvider { get; set; }

    public string Title { get; set; } = String.Empty;
}
