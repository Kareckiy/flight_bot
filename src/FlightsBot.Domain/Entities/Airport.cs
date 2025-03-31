using FlightsBot.Domain.Abstractions;

namespace FlightsBot.Domain.Entities;

public class Airport: TimeTrackableEntity
{
    public Guid Id { get; set; }

    public string IataCode { get; set; } = String.Empty;

    public string CountryCode { get; set; } = String.Empty;

    public string City { get; set; } = String.Empty;
}
