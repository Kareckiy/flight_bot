using FlightsBot.Domain.Abstractions;
using FlightsBot.Domain.Entities;
using FlightsBot.Domain.Enums;
using FlightsBot.Infrustructure.Interfaces.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NodaTime;

namespace FlightsBot.Infrustructure.Implementation.DataAccess;

internal class AppDbContext(DbContextOptions<AppDbContext> options, IClock clock) : DbContext(options), IDbContext
{
    private readonly IClock _clock = clock;

    public DbSet<Flight> Flights { get; set; }

    public DbSet<Airplane> Airplanes { get; set; }

    public DbSet<Airport> Airports{ get; set; }

    public DbSet<Carrier> Carriers { get; set; }

    public DbSet<Notification> Notifications { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateTimeTrackableEntities();

        return base.SaveChangesAsync(cancellationToken);
    }

    // TODO: перенести параметры подключения в файл конфигов
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=flight_bot;Username=admin;Password=password");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DbSettings.SchemaName);

        // создаем enum из кода в бд
        modelBuilder.HasPostgresEnum("data_provider", Enum.GetNames<DataProvider>());
        modelBuilder.HasPostgresEnum("flight_status", Enum.GetNames<FlighStatus>());

        // применяем все конфигурации из сборки вместо вызова применения конфигурации каждой сущности
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    private void UpdateTimeTrackableEntities()
    {
        Instant now = _clock.GetCurrentInstant();

        foreach (EntityEntry<TimeTrackableEntity> entry in ChangeTracker.Entries<TimeTrackableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Created(now);
                    break;
            }
        }
    }
}
