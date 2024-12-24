using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;

internal class DataRisetConfiguration : IEntityTypeConfiguration<DataRiset>
{
    public void Configure(EntityTypeBuilder<DataRiset> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdDataRiset.Create(s).Value);

        builder.HasMany(x => x.DaftarJenisDataRiset).WithMany(x => x.DaftarDataRiset);
        builder.HasMany(x => x.DaftarKolaboratorPenelitian).WithMany(x => x.DaftarDataRiset);
    }
}