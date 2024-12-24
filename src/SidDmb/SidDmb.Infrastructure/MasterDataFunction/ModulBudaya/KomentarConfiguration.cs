using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulBudaya;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.ArtefakBudayas;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulBudaya;

internal class KomentarConfiguration : IEntityTypeConfiguration<Komentar>
{
    public void Configure(EntityTypeBuilder<Komentar> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.ArtefakBudaya).WithMany(x => x.DaftarKomentar);
        builder.HasOne(x => x.UpacaraBudaya).WithMany(x => x.DaftarKomentar);
        builder.HasOne(x => x.SeniBudaya).WithMany(x => x.DaftarKomentar);
        builder.HasOne(x => x.SitusBudaya).WithMany(x => x.DaftarKomentar);

        builder.HasData(
            new
            {
                Id = 1,
                Nama = "Kometator 1",
                Isi = "Artefak yang sangat menarik, tetapi informasi lebih detail diperlukan.",
                Rating = 4.8d,
                ArtefakBudayaId = IdArtefak.Create("AR001").Value,
            }
        );
    }
}