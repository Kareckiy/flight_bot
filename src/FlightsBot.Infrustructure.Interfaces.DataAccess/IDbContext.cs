using Microsoft.EntityFrameworkCore;
using FlightsBot.Domain.Entities;

namespace FlightsBot.Infrustructure.Interfaces.DataAccess;

public interface IDbContext
{
    DbSet<Flight> Flights { get; }

    DbSet<Airplane> Airplanes { get; }

    DbSet<Airport> Airports { get; }

    DbSet<Carrier> Carriers { get; }

    DbSet<Notification> Notifications { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
