using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulWisata.KalenderAcaras;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulWisata.KalenderAcaras;

internal class KalenderAcaraConfiguration : IEntityTypeConfiguration<KalenderAcara>
{
    public void Configure(EntityTypeBuilder<KalenderAcara> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdAcara.Create(s).Value);
        builder.Property(x => x.TanggalDanWaktu).HasColumnType("timestamp without time zone");
    }
}