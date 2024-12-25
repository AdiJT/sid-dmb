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

        builder.HasData(
            new
            {
                Id = 2,
                Nama = "Dinas Pariwisata",
                AppUserId = 2
            },
            new
            {
                Id = 3,
                Nama = "Dinas Kebudayaan",
                AppUserId = 3
            },
            new
            {
                Id = 4,
                Nama = "Dinas Koperasi UMKM",
                AppUserId = 4
            },
            new
            {
                Id = 5,
                Nama = "DP3AP2",
                AppUserId = 5
            },
            new
            {
                Id = 6,
                Nama = "Assosiacation",
                AppUserId = 6
            },
            new
            {
                Id = 7,
                Nama = "BPOM",
                AppUserId = 7
            },
            new
            {
                Id = 8,
                Nama = "Academics",
                AppUserId = 8
            },
            new
            {
                Id = 9,
                Nama = "Media",
                AppUserId = 9
            }
        );
    }
}