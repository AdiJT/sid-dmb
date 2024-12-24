using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasiDanPembelajaran;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasiDanPembelajaran;

internal class MateriConfiguration : IEntityTypeConfiguration<Materi>
{
    public void Configure(EntityTypeBuilder<Materi> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdMateri.Create(s).Value);

        builder.HasMany(x => x.DaftarKolaborator).WithMany(x => x.DaftarMateri);
    }
}