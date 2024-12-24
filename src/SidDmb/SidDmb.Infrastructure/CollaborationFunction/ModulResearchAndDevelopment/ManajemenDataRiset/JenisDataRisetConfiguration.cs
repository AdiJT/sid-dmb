using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;

internal class JenisDataRisetConfiguration : IEntityTypeConfiguration<JenisDataRiset>
{
    public void Configure(EntityTypeBuilder<JenisDataRiset> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.DaftarDataRiset).WithMany(x => x.DaftarJenisDataRiset);
    }
}
