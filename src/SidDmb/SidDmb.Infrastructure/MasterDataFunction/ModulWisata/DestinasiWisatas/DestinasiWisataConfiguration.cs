using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulWisata.DestinasiWisatas;

internal class DestinasiWisataConfiguration : IEntityTypeConfiguration<DestinasiWisata>
{
    public void Configure(EntityTypeBuilder<DestinasiWisata> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdDestinasi.Create(s).Value);
        builder.Property(x => x.TitikKoordinat).HasColumnType("geography (point)");

        builder.HasMany(x => x.DaftarLaporanKunjungan).WithOne(x => x.DestinasiWisata);
        builder.HasMany(x => x.DaftarAktivitas).WithMany(x => x.DaftarDestinasiWisata);
        builder.HasMany(x => x.DaftarFasilitas).WithMany(x => x.DaftarDestinasiWisata);
    }
}