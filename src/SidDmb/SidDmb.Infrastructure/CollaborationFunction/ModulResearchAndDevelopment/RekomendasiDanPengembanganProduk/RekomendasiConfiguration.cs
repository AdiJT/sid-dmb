using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.RekomendasiDanPengembanganProduk;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulResearchAndDevelopment.RekomendasiDanPengembanganProduk;

internal class RekomendasiConfiguration : IEntityTypeConfiguration<Rekomendasi>
{
    public void Configure(EntityTypeBuilder<Rekomendasi> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdRekomendasi.Create(s).Value);

        builder.HasOne(x => x.ProdukTerkait).WithMany();
        builder.HasMany(x => x.DaftarKolaborator).WithMany(x => x.DaftarRekomendasi).UsingEntity<KolaboratorRekomendasi>(
            l => l.HasOne(x => x.Entity2).WithMany(x => x.DaftarKolaboratorRekomendasi).HasForeignKey(x => x.Entity2Id),
            r => r.HasOne(x => x.Entity1).WithMany(x => x.DaftarKolaboratorRekomendasi).HasForeignKey(x => x.Entity1Id));
    }
}