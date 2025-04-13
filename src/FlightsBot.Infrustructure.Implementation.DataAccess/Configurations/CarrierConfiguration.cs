using FlightsBot.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightsBot.Infrustructure.Implementation.DataAccess.Configurations;

internal class CarrierConfiguration: TimeTrackableConfiguration<Carrier>
{
    public override void Configure(EntityTypeBuilder<Carrier> builder)
    {
        builder.HasIndex(c => c.Code).IsUnique();

        builder.Property(c => c.Id).ValueGeneratedOnAdd();
    }
}
