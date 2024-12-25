using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetTopologySuite.Geometries;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SitusBudayas;
using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulBudaya.SitusBudayas;

internal class SitusBudayaConfiguration : IEntityTypeConfiguration<SitusBudaya>
{
    public void Configure(EntityTypeBuilder<SitusBudaya> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(x => x.Value, s => IdSitus.Create(s).Value);

        builder.HasMany(x => x.DaftarKomentar).WithOne(x => x.SitusBudaya);

        builder.HasData(
            new SitusBudaya
            {
                Id = IdSitus.Create("SB001").Value,
                Nama = "Candi Sambisari",
                Dekripsi = "Candi Sambisari adalah situs sejarah yang terletak di Yogyakarta, berasal dari abad ke-9 dan merupakan peninggalan kerajaan Mataram Kuno.",
                Kategori = KategoriSitus.Sejarah,
                Alamat = "Jl. Candi Sambisari, Purwomartani, Kalasan, Sleman, Yogyakarta",
                KoordinatLokasi = new Point(110.356384, -7.726992),
                DaftarFasilitas = [
                    "Panggung Utama",
                    "Tempat Duduk Penonton",
                    "Sistem Audio"
                ],
                PengelolaSitus = "Balai Pelestarian Cagar Budaya Yogyakarta",
                Status = StatusOperasional.Buka,
                JamOperasional = "08:00 - 17:00",
                KontakInformasi = "+62 812-3456-7890",
                HargaTiketMasuk = 20000,
                PeraturanKhusus = "Dilarang membawa makanan dan minuman ke area candi.",
                FotoPromosi = new Uri("/assets/Situs_Budaya/Situs_Candi_Sambisari.jpg", UriKind.Relative),
            },
             new SitusBudaya
             {
                 Id = IdSitus.Create("SB002").Value,
                 Nama = "Gua Maria Tritis",
                 Dekripsi = "Gua Maria Tritis adalah situs ziarah yang terletak di Gunung Tritis, Yogyakarta, dikenal dengan kesan spiritual dan pemandangan alamnya.",
                 Kategori = KategoriSitus.Religi,
                 Alamat = "Dusun Tritis, Purworejo, Yogyakarta",
                 KoordinatLokasi = new Point(110.552711, -8.082159),
                 DaftarFasilitas = [
                    "Tempat Doa",
                    "Area Parkir",
                    "Toilet Umum"
                 ],
                 PengelolaSitus = "Paroki Setempat",
                 Status = StatusOperasional.Buka,
                 JamOperasional = "06:00 - 18:00",
                 KontakInformasi = "+62 878-2123-4567",
                 HargaTiketMasuk = 10000,
                 PeraturanKhusus = "Dilarang merokok dan membawa makanan di area ziarah.",
                 FotoPromosi = new Uri("/assets/Situs_Budaya/Situs_Gua_Maria_Tritis.jpg", UriKind.Relative),
             },
             new SitusBudaya
             {
                 Id = IdSitus.Create("SB003").Value,
                 Nama = "Gua Rancang Kencono",
                 Dekripsi = "Gua Rancang Kencono adalah situs alami yang dikenal dengan keindahan formasi batuan stalaktit dan stalagmit serta keasrian alam sekitar.",
                 Kategori = KategoriSitus.Arkeologi,
                 Alamat = "Dusun Rancang Kencono, Nglanggeran, Yogyakarta",
                 KoordinatLokasi = new Point(110.492699, -7.949500),
                 DaftarFasilitas = [
                    "Jalur Pendakian",
                    "Area Istirahat",
                    "Pemandu Wisata"
                 ],
                 PengelolaSitus = "Dinas Pariwisata Kabupaten Gunungkidul",
                 Status = StatusOperasional.Buka,
                 JamOperasional = "08:00 - 16:00",
                 KontakInformasi = "+62 811-6347-897",
                 HargaTiketMasuk = 15000,
                 PeraturanKhusus = "Tidak diperbolehkan memasuki gua tanpa pemandu.",
                 FotoPromosi = new Uri("/assets/Situs_Budaya/Situs_Gua_Rancang_kencono.jpg", UriKind.Relative),
             },
             new SitusBudaya
             {
                 Id = IdSitus.Create("SB004").Value,
                 Nama = "Situs Gunung Wukir",
                 Dekripsi = "Situs Gunung Wukir adalah peninggalan budaya Hindu-Buddha yang ditemukan di kawasan Gunung Wukir, Yogyakarta, dengan berbagai prasasti kuno.",
                 Kategori = KategoriSitus.Sejarah,
                 Alamat = "Gunung Wukir, Sleman, Yogyakarta",
                 KoordinatLokasi = new Point(110.349930, -7.784865),
                 DaftarFasilitas = [
                    "Area Parkir",
                    "Tempat Istirahat",
                    "Papan Informasi"
                 ],
                 PengelolaSitus = "Balai Pelestarian Cagar Budaya Yogyakarta",
                 Status = StatusOperasional.Buka,
                 JamOperasional = "08:00 - 17:00",
                 KontakInformasi = "+62 858-3423-6237",
                 HargaTiketMasuk = 25000,
                 PeraturanKhusus = "Dilarang membawa tas besar dan makanan ke area situs.",
                 FotoPromosi = new Uri("/assets/Situs_Budaya/Situs_Gunung_Wukir.jpg", UriKind.Relative),
             },
             new SitusBudaya
             {
                 Id = IdSitus.Create("SB005").Value,
                 Nama = "Situs Mangir",
                 Dekripsi = "Situs Mangir adalah situs sejarah yang menyimpan artefak-artefak penting dari era kerajaan Mataram Kuno, terletak di Kabupaten Bantul.",
                 Kategori = KategoriSitus.Sejarah,
                 Alamat = "Desa Mangir, Bantul, Yogyakarta",
                 KoordinatLokasi = new Point(110.319917, -7.877201),
                 DaftarFasilitas = [
                    "Tempat Duduk",
                    "Toilet Umum",
                    "Papan Penunjuk Arah"
                 ],
                 PengelolaSitus = "Dinas Kebudayaan Yogyakarta",
                 Status = StatusOperasional.Buka,
                 JamOperasional = "07:00 - 17:00",
                 KontakInformasi = "+62 821-4321-8765",
                 HargaTiketMasuk = 20000,
                 PeraturanKhusus = "Dilarang membawa benda tajam dan minuman keras.",
                 FotoPromosi = new Uri("/assets/Situs_Budaya/Situs_Mangir.jpg", UriKind.Relative),
             }
        );
    }
}