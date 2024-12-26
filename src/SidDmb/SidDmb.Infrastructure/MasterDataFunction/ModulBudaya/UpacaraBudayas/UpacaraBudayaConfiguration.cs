using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.UpacaraBudayas;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulBudaya.UpacaraBudayas;

internal class UpacaraBudayaConfiguration : IEntityTypeConfiguration<UpacaraBudaya>
{
    public void Configure(EntityTypeBuilder<UpacaraBudaya> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdUpacara.Create(s).Value);
        builder.Property(x => x.WaktuPelaksanaan).HasColumnType("timestamp without time zone");

        builder.HasMany(x => x.DaftarKomentar).WithOne(x => x.UpacaraBudaya);

        builder.HasData(
            new UpacaraBudaya
            {
                Id = IdUpacara.Create("UB001").Value,
                Nama = "Labuhan Glagah",
                Dekripsi = "Upacara Labuhan Glagah adalah tradisi masyarakat Yogyakarta sebagai bentuk penghormatan terhadap alam dan leluhur.",
                Kategori = KategoriUpacara.Adat,
                LokasiPelaksanaan = "Pantai Glagah, Kulon Progo",
                WaktuPelaksanaan = new DateTime(2025, 01, 01),
                Durasi = TimeSpan.FromHours(2),
                PihakTerlibat = "Masyarakat lokal, Dinas Kebudayaan Yogyakarta, Pekerja Seni",
                RangkaianAcara = "Pembukaan, prosesi labuhan, doa bersama, penutupan.",
                JumlahPeserta = 200,
                FasilitasPendukung = [
                    "Panggung Utama",
                    "Tempat Duduk Penonton",
                    "Sistem Audio"
                ],
                MediaPromosi = new Uri("/assets/Upacara_Budaya/Upacara_Labuhan_Glagah.jpg", UriKind.Relative),
                PeraturanKhusus = "Dilarang membawa benda terlarang saat prosesi."
            },
            new UpacaraBudaya
            {
                Id = IdUpacara.Create("UB002").Value,
                Nama = "Labuhan Merapi",
                Dekripsi = "Labuhan Merapi adalah upacara adat untuk menghormati gunung Merapi sebagai simbol kehidupan dan kemakmuran.",
                Kategori = KategoriUpacara.Adat,
                LokasiPelaksanaan = "Kawasan Gunung Merapi, Sleman",
                WaktuPelaksanaan = new DateTime(2025, 02, 01),
                Durasi = TimeSpan.FromHours(3),
                PihakTerlibat = "Masyarakat sekitar, Pemerintah Daerah, Dinas Kebudayaan Yogyakarta",
                RangkaianAcara = "Doa bersama, persembahan sesaji, parade budaya.",
                JumlahPeserta = 150,
                FasilitasPendukung = [
                    "Tempat Parkir",
                    "Panggung Budaya",
                    "Sistem Keamanan"
                ],
                MediaPromosi = new Uri("/assets/Upacara_Budaya/Upacara_Labuhan_Merapi.jpg", UriKind.Relative),
                PeraturanKhusus = "Hanya warga sekitar yang boleh ikut serta dalam prosesi utama."
            },
            new UpacaraBudaya
            {
                Id = IdUpacara.Create("UB003").Value,
                Nama = "Labuhan Parangkusumo",
                Dekripsi = "Upacara Labuhan Parangkusumo dilaksanakan untuk memohon keselamatan dan kesejahteraan bagi masyarakat pesisir.",
                Kategori = KategoriUpacara.Adat,
                LokasiPelaksanaan = "Pantai Parangkusumo, Bantul",
                WaktuPelaksanaan = new DateTime(2025, 03, 01),
                Durasi = TimeSpan.FromHours(3),
                PihakTerlibat = "Pemerintah Daerah, Masyarakat Pesisir, Budayawan",
                RangkaianAcara = "Prosesi Labuhan, doa keselamatan, pelarungan sesaji.",
                JumlahPeserta = 250,
                FasilitasPendukung = [
                    "Tempat Ibadah",
                    "Area Parkir",
                    "Panggung Hiburan"
                ],
                MediaPromosi = new Uri("/assets/Upacara_Budaya/Upacara_Labuhan_Parangkusumo.jpg", UriKind.Relative),
                PeraturanKhusus = "Dilarang membawa alat elektronik selama prosesi."
            },
            new UpacaraBudaya
            {
                Id = IdUpacara.Create("UB004").Value,
                Nama = "Ngalap Berkah Pantai Ngobaran",
                Dekripsi = "Upacara Ngalap Berkah di Pantai Ngobaran adalah tradisi untuk memohon keberkahan hidup melalui alam.",
                Kategori = KategoriUpacara.Adat,
                LokasiPelaksanaan = "Pantai Ngobaran, Gunungkidul",
                WaktuPelaksanaan = new DateTime(2025, 04, 01),
                Durasi = TimeSpan.FromHours(4),
                PihakTerlibat = "Masyarakat Gunungkidul, Dinas Pariwisata, Budayawan",
                RangkaianAcara = "Doa bersama, pelarungan sesaji ke laut, tarian budaya.",
                JumlahPeserta = 300,
                FasilitasPendukung = [
                    "Tempat Ibadah",
                    "Area Panggung",
                    "Tempat Parkir"
                ],
                MediaPromosi = new Uri("/assets/Upacara_Budaya/Upacara_Ngalap_Berkah_Pantai_Ngobaran.jpg", UriKind.Relative),
                PeraturanKhusus = "Dilarang merusak alam selama prosesi."
            },
            new UpacaraBudaya
            {
                Id = IdUpacara.Create("UB005").Value,
                Nama = "Sekaten Sleman",
                Dekripsi = "Sekaten Sleman adalah perayaan budaya yang digelar untuk merayakan hari jadi Kabupaten Sleman.",
                Kategori = KategoriUpacara.Adat,
                LokasiPelaksanaan = "Alun-Alun Sleman",
                WaktuPelaksanaan = new DateTime(2025, 05, 01),
                Durasi = TimeSpan.FromHours(5),
                PihakTerlibat = "Pemerintah Daerah Sleman, Masyarakat Sleman, Pengusaha Lokal",
                RangkaianAcara = "Pawai budaya, pertunjukan seni, pasar rakyat.",
                JumlahPeserta = 400,
                FasilitasPendukung = [
                    "Tempat Duduk Penonton",
                    "Area Stand Makanan",
                    "Panggung Hiburan"
                ],
                MediaPromosi = new Uri("/assets/Upacara_Budaya/Upacara_Sekaten_Sleman.jpg", UriKind.Relative),
                PeraturanKhusus = "Patuhi aturan keamanan dan kebersihan selama acara berlangsung."
            }
        );
    }
}