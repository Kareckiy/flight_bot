using FlightsBot.Domain.Abstractions;

namespace FlightsBot.Domain.Entities;

public class Airplane: TimeTrackableEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = String.Empty;

    public int? PassengersMaxCount { get; set; } = null;

    public Airplane(string name, int? passengersMaxCount)
    {
        Name = name;
        PassengersMaxCount = passengersMaxCount;
    }
}
