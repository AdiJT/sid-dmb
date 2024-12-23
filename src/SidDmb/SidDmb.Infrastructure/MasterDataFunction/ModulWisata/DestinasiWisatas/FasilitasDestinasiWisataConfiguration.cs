using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulWisata.DestinasiWisatas;

internal class FasilitasDestinasiWisataConfiguration : IEntityTypeConfiguration<FasilitasDestinasiWisata>
{
    public void Configure(EntityTypeBuilder<FasilitasDestinasiWisata> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.DaftarDestinasiWisata).WithMany(x => x.DaftarFasilitas);
    }
}
