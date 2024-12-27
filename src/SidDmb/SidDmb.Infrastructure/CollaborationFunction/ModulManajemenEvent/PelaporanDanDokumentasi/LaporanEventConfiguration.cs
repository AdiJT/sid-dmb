using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PelaporanDanDokumentasi;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulManajemenEvent.PelaporanDanDokumentasi;

internal class LaporanEventConfiguration : IEntityTypeConfiguration<LaporanEvent>
{
    public void Configure(EntityTypeBuilder<LaporanEvent> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdLaporanEvent.Create(s).Value);

        builder.HasOne(x => x.Event).WithOne(x => x.LaporanEvent).HasForeignKey<LaporanEvent>("EventId");
    }
}