using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql;

namespace FlightsBot.Infrustructure.Implementation.DataAccess;

internal class DbDesignFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    private const string ConnectionStringStub = 
        "Host=localhost;Port=5432;Database=flight_bot;Username=admin;Password=password";

    public AppDbContext CreateDbContext(string[] args)
    {
        string connectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRINGS__DBCONNECTION") ?? ConnectionStringStub;

        DbContextOptions<AppDbContext> options = ConfigureDbContextOptions(connectionString);

        return new AppDbContext(options, NodaTime.SystemClock.Instance);
    }

    private static DbContextOptions<AppDbContext> ConfigureDbContextOptions(string connectionString)
    {
        DbContextOptionsBuilder<AppDbContext> optionsBuilder = new ();

        optionsBuilder
            .UseNpgsql(
                connectionString,
                builder =>
                {
                    NpgsqlConnectionStringBuilder connectionStringBuilder = new(connectionString);

                    builder.UseNodaTime().MigrationsHistoryTable(
                        HistoryRepository.DefaultTableName,
                        connectionStringBuilder.SearchPath
                    );
                }
            );

        return optionsBuilder.Options;
    }
}
