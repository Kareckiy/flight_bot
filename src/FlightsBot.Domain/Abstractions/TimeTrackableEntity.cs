using NodaTime;

namespace FlightsBot.Domain.Abstractions;

public abstract class TimeTrackableEntity
{
    public Instant CreatedAt { get; private set; }

    public void Created(Instant now)
    {
        CreatedAt = now;

    }
}
