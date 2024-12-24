using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.CollaborationFunction;

namespace SidDmb.Infrastructure.CollaborationFunction;

internal class KolaboratorConfiguration : IEntityTypeConfiguration<Kolaborator>
{
    public void Configure(EntityTypeBuilder<Kolaborator> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.AppUser).WithOne(x => x.Kolaborator).HasForeignKey<Kolaborator>("AppUserId");
        builder.HasMany(x => x.DaftarMateri).WithMany(x => x.DaftarKolaborator);
        builder.HasMany(x => x.DaftarDistribusi).WithMany(x => x.DaftarKolaborator);
        builder.HasMany(x => x.DaftarDataRiset).WithMany(x => x.DaftarKolaboratorPenelitian);
        builder.HasMany(x => x.DaftarEvent).WithMany(x => x.DaftarKolaborator);
        builder.HasMany(x => x.DaftarPelatihan).WithMany(x => x.DaftarKolaborator);
        builder.HasMany(x => x.DaftarProduk).WithMany(x => x.DaftarKolaborator);
        builder.HasMany(x => x.DaftarRekomendasi).WithMany(x => x.DaftarKolaborator);
        builder.HasMany(x => x.DaftarSertifikasi).WithMany(x => x.DaftarKolaborator);
        builder.HasMany(x => x.DaftarKegiatanPrima).WithMany(x => x.KolaboratorKegiatan);
    }
}