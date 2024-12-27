using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PelaporanDanDokumentasi;
using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;

internal class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(x => x.Value, s => IdEvent.Create(s).Value);
        builder.Property(x => x.TanggalWaktu).HasColumnType("timestamp without time zone");

        builder.HasOne(x => x.LaporanEvent).WithOne(x => x.Event).HasForeignKey<LaporanEvent>("EventId");

        builder.HasMany(x => x.DaftarKolaborator).WithMany(x => x.DaftarEvent).UsingEntity<KolaboratorEvent>(
            l => l.HasOne(x => x.Entity2).WithMany(x => x.DaftarKolaboratorEvent).HasForeignKey(x => x.Entity2Id),
            r => r.HasOne(x => x.Entity1).WithMany(x => x.DaftarKolaboratorEvent).HasForeignKey(x => x.Entity1Id));
    }
}