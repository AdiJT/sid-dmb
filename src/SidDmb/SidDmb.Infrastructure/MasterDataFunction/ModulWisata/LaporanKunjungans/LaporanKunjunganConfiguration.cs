using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulWisata.LaporanKunjungans;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulWisata.LaporanKunjungans;

internal class LaporanKunjunganConfiguration : IEntityTypeConfiguration<LaporanKunjungan>
{
    public void Configure(EntityTypeBuilder<LaporanKunjungan> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdKunjungan.Create(s).Value);

        builder.HasOne(x => x.DestinasiWisata).WithMany(x => x.DaftarLaporanKunjungan);
    }
}