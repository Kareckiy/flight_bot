using FlightsBot.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightsBot.Infrustructure.Implementation.DataAccess.Configurations;

internal class FlightConfiguration: TimeTrackableConfiguration<Flight>
{
    public override void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.HasIndex(f => f.Number).IsUnique();
    }
}
