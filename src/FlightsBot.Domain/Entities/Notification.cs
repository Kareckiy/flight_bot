using FlightsBot.Domain.Abstractions;

namespace FlightsBot.Domain.Entities;

public class Notification: TimeTrackableEntity
{
    public Guid Id { get; set; }

    public Guid FlightId { get; set; }

    public Flight Flight { get; set; } = null!;
}
