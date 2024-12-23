using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulWisata.DestinasiWisatas;

internal class AktivitasDestinasiWisataConfiguration : IEntityTypeConfiguration<AktivitasDestinasiWisata>
{
    public void Configure(EntityTypeBuilder<AktivitasDestinasiWisata> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.DaftarDestinasiWisata).WithMany(x => x.DaftarAktivitas);
    }
}
