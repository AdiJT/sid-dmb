using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;

internal class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(x => x.Value, s => IdEvent.Create(s).Value);
        builder.Property(x => x.TanggalWaktu).HasColumnType("timestamp without time zone");

        builder.HasMany(x => x.DaftarKolaborator).WithMany(x => x.DaftarEvent);
    }
}