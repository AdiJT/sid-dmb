using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetTopologySuite.Geometries;
using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulWisata.DestinasiWisatas;

internal class DestinasiWisataConfiguration : IEntityTypeConfiguration<DestinasiWisata>
{
    public void Configure(EntityTypeBuilder<DestinasiWisata> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdDestinasi.Create(s).Value);
        builder.Property(x => x.TitikKoordinat).HasColumnType("geography (point)");

        builder.HasMany(x => x.DaftarLaporanKunjungan).WithOne(x => x.DestinasiWisata);

        builder.HasData(
            new DestinasiWisata
            {
                Id = IdDestinasi.Create("DW001").Value,
                Nama = "Candi Prambanan",
                Deskripsi = "Candi Prambanan adalah kompleks candi Hindu terbesar di Indonesia dan merupakan salah satu situs warisan dunia UNESCO.",
                Kategori = KategoriDestinasi.Sejarah,
                Alamat = "Jl. Raya Prambanan, Klaten, Jawa Tengah",
                TitikKoordinat = new Point(110.489273, -7.756137),
                DaftarFasilitas = [
                    "Panggung Hiburan",
                    "Toilet Umum",
                    "Taman Parkir"
                ],
                HargaTiketMasuk = 35000,
                JamOperasional = "08:00 - 18:00",
                InformasiKontak = "+62 812-3456-7890",
                PengelolaDestinasi = "Dinas Kebudayaan Yogyakarta",
                StatusOperasional = StatusOperasional.Buka,
                DaftarAktivitas = [
                    "Tur Sejarah",
                    "Fotografi",
                    "Tari Barong"
                ],
                Foto = new Uri("/assets/Destinasi_Candi_Prambanan.jpg", UriKind.Relative)
            },
            new DestinasiWisata
            {
                Id = IdDestinasi.Create("DW002").Value,
                Nama = "Gua Pindul",
                Deskripsi = "Gua Pindul adalah gua alami yang terkenal dengan wisata cave tubing di Yogyakarta.",
                Kategori = KategoriDestinasi.Alam,
                Alamat = "Desa Bejiharjo, Karangmojo, Gunungkidul, Yogyakarta",
                TitikKoordinat = new Point(110.648987, -7.930843),
                DaftarFasilitas = [
                    "Sewa Perahu",
                    "Toilet Umum",
                    "Area Parkir"
                ],
                HargaTiketMasuk = 25000,
                JamOperasional = "08:00 - 17:00",
                InformasiKontak = "+62 812-3456-7890",
                PengelolaDestinasi = "PT. Pindul Adventure",
                StatusOperasional = StatusOperasional.Buka,
                DaftarAktivitas = [
                    "Cave Tubing",
                    "Jelajah Gua",
                    "Trekking"
                ],
                Foto = new Uri("/assets/Destinasi_Gua_Pindul.jpg", UriKind.Relative)
            },
            new DestinasiWisata
            {
                Id = IdDestinasi.Create("DW003").Value,
                Nama = "Gunung Merapi",
                Deskripsi = "Gunung Merapi adalah gunung berapi aktif yang terkenal dengan pendakian dan pemandangan alam yang mempesona.",
                Kategori = KategoriDestinasi.Alam,
                Alamat = "Sleman, Yogyakarta",
                TitikKoordinat = new Point(110.446100, -7.541389),
                DaftarFasilitas = [
                    "Pusat Informasi",
                    "Area Parkir",
                    "Pemandu Gunung"
                ],
                HargaTiketMasuk = 50000,
                JamOperasional = "24 Jam",
                InformasiKontak = "+62 812-3456-7890",
                PengelolaDestinasi = "Dinas Pariwisata Yogyakarta",
                StatusOperasional = StatusOperasional.Buka,
                DaftarAktivitas = [
                    "Pendakian",
                    "Fotografi Alam",
                    "Trekking Gunung"
                ],
                Foto = new Uri("/assets/Destinasi_Gunung_Merapi.jpg", UriKind.Relative)
            },
            new DestinasiWisata
            {
                Id = IdDestinasi.Create("DW004").Value,
                Nama = "Hutan Pinus Mangunan",
                Deskripsi = "Hutan Pinus Mangunan menawarkan keindahan alam yang asri dengan pemandangan spektakuler dan udara yang sejuk.",
                Kategori = KategoriDestinasi.Alam ,
                Alamat = "Dlingo, Bantul, Yogyakarta",
                TitikKoordinat = new Point(110.431801, -7.925800),
                DaftarFasilitas = [
                    "Jalan Setapak",
                    "Tempat Duduk",
                    "Area Parkir"
                ],          
                HargaTiketMasuk = 15000,
                JamOperasional = "07:00 - 18:00",
                InformasiKontak = "+62 812-3456-7890",
                PengelolaDestinasi = "Dinas Pariwisata Bantul",
                StatusOperasional = StatusOperasional.Buka,
                DaftarAktivitas = [
                    "Fotografi Alam",
                    "Jalan-jalan",
                    "Wisata Alam"
                ],
                Foto = new Uri("/assets/Destinasi_Hutan_Pinus_Mangunan.jpg", UriKind.Relative)
            },
            new DestinasiWisata
            {
                Id = IdDestinasi.Create("DW005").Value,
                Nama = "Pantai Parangtritis",
                Deskripsi = "Pantai Parangtritis terkenal dengan pasir pantainya yang luas dan pemandangan matahari terbenam yang menakjubkan.",
                Kategori = KategoriDestinasi.Alam,
                Alamat = "Jl. Parangtritis, Yogyakarta",
                TitikKoordinat = new Point(110.332870, -8.024295),
                DaftarFasilitas = [
                    "Panggung Hiburan",
                    "Tempat Duduk",
                    "Area Parkir"
                ],
                HargaTiketMasuk = 20000,
                JamOperasional = "24 Jam",
                InformasiKontak = "+62 812-3456-7890",
                PengelolaDestinasi = "Dinas Pariwisata Yogyakarta",
                StatusOperasional = StatusOperasional.Buka,
                DaftarAktivitas = [
                    "Bermain Pasir",
                    "Fotografi",
                    "Pemandangan Matahari Terbenam"
                ],
                Foto = new Uri("/assets/Destinasi_Pantai_Parangtritis.jpg", UriKind.Relative)
            }
        );
    }
}