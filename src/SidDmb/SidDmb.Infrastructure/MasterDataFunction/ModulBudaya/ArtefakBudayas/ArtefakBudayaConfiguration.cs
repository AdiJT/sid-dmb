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
                Nama = "Batu Kenong",
                Dekripsi = "Batu berbentuk kenong yang digunakan dalam ritual tradisional masyarakat Kulon Progo.",
                Kategori = KategoriArtefak.Ritual,
                LokasiPenyimpanan = "Museum Kulon Progo",
                Kondisi = KondisiArtefak.Baik,
                Usia = "Abad ke-10",
                Bahan = "Batu Andesit",
                Dimensi = "Diameter: 50 cm, Tinggi: 40 cm",
                Pengelola = "Dinas Kebudayaan Kulon Progo",
                NilaiHistoris = "Digunakan dalam upacara adat sejak masa Hindu-Buddha.",
                Foto = new Uri("/assets/Artefak_Budaya/Artefak_Batu_Kenong.jpg", UriKind.Relative),
                Ketersediaan = KetersediaanPameran.Ya,
                TanggalDiinputkan = new DateTime(2024, 12, 25),
                TanggalPembaruanData = new DateTime(2024, 12, 25)
            },
            new ArtefakBudaya
            {
                Id = IdArtefak.Create("AR002").Value,
                Nama = "Batu Prasasti Candi Ijo",
                Dekripsi = "Prasasti yang ditemukan di kawasan Candi Ijo, mencatat sejarah masa kerajaan Mataram Kuno.",
                Kategori = KategoriArtefak.Utilitas,
                LokasiPenyimpanan = "Museum Candi Ijo",
                Kondisi = KondisiArtefak.Baik,
                Usia = "Abad ke-9",
                Bahan = "Batu Andesit",
                Dimensi = "Tinggi: 1,2 m, Lebar: 70 cm",
                Pengelola = "Balai Pelestarian Cagar Budaya Yogyakarta",
                NilaiHistoris = "Prasasti ini mencatat informasi penting tentang kehidupan pada masa kerajaan Hindu.",
                Foto = new Uri("/assets/Artefak_Budaya/Artefak_Batu_Prasasti_Candi_Ijo.jpg", UriKind.Relative),
                Ketersediaan = KetersediaanPameran.Ya,
                TanggalDiinputkan = new DateTime(2024, 12, 25),
                TanggalPembaruanData = new DateTime(2024, 12, 25)
            },
            new ArtefakBudaya
            {
                Id = IdArtefak.Create("AR003").Value,
                Nama = "Patung Ganesha",
                Dekripsi = "Patung Dewa Ganesha yang ditemukan di kompleks Candi Sambisari.",
                Kategori = KategoriArtefak.Ritual,
                LokasiPenyimpanan = "Museum Candi Sambisari",
                Kondisi = KondisiArtefak.Baik,
                Usia = "Abad ke-9",
                Bahan = "Batu Andesit",
                Dimensi = "Tinggi: 60 cm, Lebar: 40 cm",
                Pengelola = "Balai Pelestarian Cagar Budaya Yogyakarta",
                NilaiHistoris = "Artefak ini mencerminkan pengaruh Hindu pada masa kerajaan Mataram.",
                Foto = new Uri("/assets/Artefak_Budaya/Artefak_Patung_Ganesha_Candi_Sambisari.jpg", UriKind.Relative),
                Ketersediaan = KetersediaanPameran.Ya,
                TanggalDiinputkan = new DateTime(2024, 12, 25),
                TanggalPembaruanData = new DateTime(2024, 12, 25)
            },
            new ArtefakBudaya
            {
                Id = IdArtefak.Create("AR004").Value,
                Nama = "Prasasti Kedu",
                Dekripsi = "Prasasti yang mencatat sejarah wilayah Kedu pada masa kerajaan Mataram Kuno.",
                Kategori = KategoriArtefak.Utilitas,
                LokasiPenyimpanan = "Museum Sejarah Kedu",
                Kondisi = KondisiArtefak.Baik,
                Usia = "Abad ke-9",
                Bahan = "Batu Andesit",
                Dimensi = "Tinggi: 1,5 m, Lebar: 80 cm",
                Pengelola = "Balai Pelestarian Cagar Budaya Jawa Tengah",
                NilaiHistoris = "Prasasti ini berisi informasi penting tentang administrasi kerajaan Mataram.",
                Foto = new Uri("/assets/Artefak_Budaya/Artefak_Prasasti_Kedu.jpg", UriKind.Relative),
                Ketersediaan = KetersediaanPameran.Ya,
                TanggalDiinputkan = new DateTime(2024, 12, 25),
                TanggalPembaruanData = new DateTime(2024, 12, 25)
            },
            new ArtefakBudaya
            {
                Id = IdArtefak.Create("AR005").Value,
                Nama = "Prasasti Munggur",
                Dekripsi = "Prasasti yang ditemukan di Gunungkidul dan mencatat kehidupan masyarakat setempat.",
                Kategori = KategoriArtefak.Utilitas,
                LokasiPenyimpanan = "Museum Gunungkidul",
                Kondisi = KondisiArtefak.Baik,
                Usia = "Abad ke-10",
                Bahan = "Batu Andesit",
                Dimensi = "Tinggi: 1,3 m, Lebar: 70 cm",
                Pengelola = "Dinas Kebudayaan Gunungkidul",
                NilaiHistoris = "Prasasti ini mencerminkan tata kehidupan masyarakat desa pada masa kerajaan Mataram.",
                Foto = new Uri("/assets/Artefak_Budaya/Artefak_Prasasti_Munggur.jpg", UriKind.Relative),
                Ketersediaan = KetersediaanPameran.Ya,
                TanggalDiinputkan = new DateTime(2024, 12, 25),
                TanggalPembaruanData = new DateTime(2024, 12, 25)
            }
        );
    }
}