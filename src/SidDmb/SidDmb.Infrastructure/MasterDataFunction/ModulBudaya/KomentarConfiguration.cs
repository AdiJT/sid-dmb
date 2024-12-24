using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulBudaya;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulBudaya;

internal class KomentarConfiguration : IEntityTypeConfiguration<Komentar>
{
    public void Configure(EntityTypeBuilder<Komentar> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.UpacaraBudaya).WithMany(x => x.DaftarKomentar);
        builder.HasOne(x => x.SeniBudaya).WithMany(x => x.DaftarKomentar);
        builder.HasOne(x => x.SitusBudaya).WithMany(x => x.DaftarKomentar);
    }
}