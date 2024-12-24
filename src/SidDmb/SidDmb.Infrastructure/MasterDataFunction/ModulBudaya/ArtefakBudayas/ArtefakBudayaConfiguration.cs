using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.ArtefakBudayas;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulBudaya.ArtefakBudayas;

internal class ArtefakBudayaConfiguration : IEntityTypeConfiguration<ArtefakBudaya>
{
    public void Configure(EntityTypeBuilder<ArtefakBudaya> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdArtefak.Create(s).Value);

        builder.HasMany(x => x.DaftarKomentar).WithOne(x => x.ArtefakBudaya);

        builder.HasData(
            new ArtefakBudaya
            {
                Id = IdArtefak.Create("AR001").Value,
                Nama = "Keris Ki Ageng Gilang",
                Dekripsi = "Keris ini dipercaya sebagai pusaka warisan Ki Ageng Gilang.",
                Kategori = KategoriArtefak.Ritual,
                LokasiPenyimpanan = "Museum Desa Gilangharjo",
                Kondisi = KondisiArtefak.Baik,
                Usia = "Abad ke-17",
                Bahan = "Besi, Perunggu",
                Dimensi = "Panjang: 40 cm, Lebar: 10 cm",
                Pengelola = "Kelompok Budaya Desa Gilangharjo",
                NilaiHistoris = "Artefak ini digunakan dalam upacara adat sejak abad ke-17.",
                Foto = new Uri("/assets/artefak-test.png", UriKind.Relative),
                Ketersediaan = KetersediaanPameran.Ya,
                TanggalDiinputkan = new DateTime(2024, 12, 24),
                TanggalPembaruanData = new DateTime(2024, 12, 24)
            }
        );
    }
}