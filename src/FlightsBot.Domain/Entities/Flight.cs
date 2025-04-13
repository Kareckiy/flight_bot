namespace FlightsBot.Domain.Entities;

using FlightsBot.Domain.Abstractions;
using FlightsBot.Domain.Enums;
using NodaTime;

public class Flight: TimeTrackableEntity
{
    public Flight(string number)
    {

    }

    public Guid Id { get; set; }

    public string Number { get; set; } = String.Empty;

    public Instant StartedAt { get; private set; }

    public Instant? FinishedAt { get; private set; } = null;

    public Guid AirportFromId { get; set; } // TODO: конфигурация и указать явно на какое поле ссылаемся

    public Airport AirportFrom { get; private set; } = null!;

    public Guid AirportToId { get; set; } // TODO: конфигурация и указать явно на какое поле ссылаемся

    public Airport AirportTo { get; private set; } = null!;

    public FlighStatus Status { get; set; }

    public int PassengersCount { get; set; }

    public Guid AirplaneId { get; set; }

    public Airplane Airplane { get; private init; } = null!;

    public Guid CarrierId { get; set; }

    public Carrier Carrier { get; set; } = null!;
}
