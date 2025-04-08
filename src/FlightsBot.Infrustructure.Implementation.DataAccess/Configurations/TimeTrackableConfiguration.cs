using FlightsBot.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlightsBot.Infrustructure.Implementation.DataAccess.Configurations;

internal abstract class TimeTrackableConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : TimeTrackableEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(x => x.CreatedAt)
            .HasColumnType("Date")
            .HasComment("Дата создания записи");
    }
}
