using FlightsBot.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightsBot.Infrustructure.Implementation.DataAccess.Configurations;

internal class AirPlaneConfiguration: TimeTrackableConfiguration<Airport>
{
    public override void Configure(EntityTypeBuilder<Airport> builder)
    {
        builder.HasIndex(a => a.IataCode).IsUnique();
    }
}
