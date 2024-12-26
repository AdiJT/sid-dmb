using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulWisata.KalenderAcaras;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulWisata.KalenderAcaras;

internal class KalenderAcaraConfiguration : IEntityTypeConfiguration<KalenderAcara>
{
    public void Configure(EntityTypeBuilder<KalenderAcara> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdAcara.Create(s).Value);
        builder.Property(x => x.TanggalDanWaktu).HasColumnType("timestamp without time zone");

        builder.HasData(
            new KalenderAcara
            {
                Id = IdAcara.Create("AC001").Value,
                NamaAcara = "Festival Kesenian Bantul",
                DekripsiAcara = "Festival Kesenian Bantul menampilkan berbagai seni tradisional, seperti tari, musik, dan pameran kerajinan.",
                Kategori = KategoriAcara.Budaya,
                TanggalDanWaktu = new DateTime(2025, 03, 15, 10, 0, 0),
                LokasiAcara = "Pendopo Parasamya Bantul, Yogyakarta",
                PenanggungJawab = "Dinas Kebudayaan Bantul",
                KontakInformasi = "+62 813-4567-8910",
                HargaTiketAcara = 15000,
                TargetPesertaAcara = TargetPesertaAcara.Umum,
                BatasKuotaPeserta = 2000,
                StatusPendaftaran = StatusPendaftaran.Dibuka,
                MediaPromosi = new Uri("/assets/Event/Festival_Kesenian_Bantul.jpg", UriKind.Relative),
                SponsorAcara = "PT Seni Nusantara",
                TautanPendaftaran = new Uri("https://bantulkab.go.id/event.html", UriKind.Absolute),
                RatingAcara = 4.8
            },
            new KalenderAcara
            {
                Id = IdAcara.Create("AC002").Value,
                NamaAcara = "Festival Kesenian Sleman",
                DekripsiAcara = "Acara tahunan ini menampilkan seni budaya khas Sleman dengan fokus pada musik dan tari.",
                Kategori = KategoriAcara.Budaya,
                TanggalDanWaktu = new DateTime(2025, 04, 20, 15, 0, 0),
                LokasiAcara = "Taman Tebing Breksi, Sleman, Yogyakarta",
                PenanggungJawab = "Dinas Pariwisata Sleman",
                KontakInformasi = "+62 812-3456-7890",
                HargaTiketAcara = 20000,
                TargetPesertaAcara = TargetPesertaAcara.Umum,
                BatasKuotaPeserta = 1500,
                StatusPendaftaran = StatusPendaftaran.Dibuka,
                MediaPromosi = new Uri("/assets/Event/Festival_Kesenian_Sleman.jpg", UriKind.Relative),
                SponsorAcara = "Bank Sleman",
                TautanPendaftaran = new Uri("https://slemankab.go.id/", UriKind.Absolute),
                RatingAcara = 4.7
            },
            new KalenderAcara
            {
                Id = IdAcara.Create("AC003").Value,
                NamaAcara = "Festival Menoreh Kulon Progo",
                DekripsiAcara = "Festival ini merayakan keindahan alam Pegunungan Menoreh melalui seni dan budaya.",
                Kategori = KategoriAcara.Budaya,
                TanggalDanWaktu = new DateTime(2025, 05, 10, 09, 0, 0),
                LokasiAcara = "Bukit Menoreh, Kulon Progo, Yogyakarta",
                PenanggungJawab = "Komunitas Seni Kulon Progo",
                KontakInformasi = "+62 813-9876-5432",
                HargaTiketAcara = 10000,
                TargetPesertaAcara = TargetPesertaAcara.Umum,
                BatasKuotaPeserta = 2500,
                StatusPendaftaran = StatusPendaftaran.Dibuka,
                MediaPromosi = new Uri("/assets/Event/Festival_Menoreh_Kulon_Progo.jpg", UriKind.Relative),
                SponsorAcara = "PT Menoreh Lestari",
                TautanPendaftaran = new Uri("https://kulonprogokab.go.id/v31/", UriKind.Absolute),
                RatingAcara = 4.6
            },
            new KalenderAcara
            {
                Id = IdAcara.Create("AC004").Value,
                NamaAcara = "Festival Seribu Candi Ratu Boko",
                DekripsiAcara = "Perayaan seni dan budaya di kompleks Candi Ratu Boko dengan pertunjukan tari dan teater.",
                Kategori = KategoriAcara.Edukasi,
                TanggalDanWaktu = new DateTime(2025, 06, 01, 17, 0, 0),
                LokasiAcara = "Candi Ratu Boko, Sleman, Yogyakarta",
                PenanggungJawab = "Dinas Pariwisata Yogyakarta",
                KontakInformasi = "+62 812-7654-3210",
                HargaTiketAcara = 50000,
                TargetPesertaAcara = TargetPesertaAcara.Umum,
                BatasKuotaPeserta = 3000,
                StatusPendaftaran = StatusPendaftaran.Dibuka,
                MediaPromosi = new Uri("/assets/Event/Festival_Seribu_Candi_Ratu_Boko.jpg", UriKind.Relative),
                SponsorAcara = "Candi Foundation",
                TautanPendaftaran = new Uri("https://gunungkidulkab.go.id/", UriKind.Absolute),
                RatingAcara = 4.9
            },
            new KalenderAcara
            {
                Id = IdAcara.Create("AC005").Value,
                NamaAcara = "Tari Angguk",
                DekripsiAcara = "Pertunjukan Tari Angguk khas Yogyakarta yang mengangkat cerita rakyat melalui gerakan unik.",
                Kategori = KategoriAcara.Budaya,
                TanggalDanWaktu = new DateTime(2025, 07, 01, 18, 0, 0),
                LokasiAcara = "Gedung Kesenian Yogyakarta",
                PenanggungJawab = "Sanggar Tari Tradisional",
                KontakInformasi = "+62 813-1111-2222",
                HargaTiketAcara = 30000,
                TargetPesertaAcara = TargetPesertaAcara.Umum,
                BatasKuotaPeserta = 500,
                StatusPendaftaran = StatusPendaftaran.Dibuka,
                MediaPromosi = new Uri("/assets/Event/Tari_Angguk.jpg", UriKind.Relative),
                SponsorAcara = "Kementerian Kebudayaan",
                TautanPendaftaran = new Uri("https://kulonprogokab.go.id/v31/", UriKind.Absolute),
                RatingAcara = 4.5
            },
            new KalenderAcara
            {
                Id = IdAcara.Create("AC006").Value,
                NamaAcara = "Tari Jathilan",
                DekripsiAcara = "Tari Jathilan adalah tarian tradisional yang memadukan unsur mistis dan seni.",
                Kategori = KategoriAcara.Budaya,
                TanggalDanWaktu = new DateTime(2025, 08, 05, 14, 0, 0),
                LokasiAcara = "Alun-Alun Wonosari, Gunungkidul",
                PenanggungJawab = "Paguyuban Jathilan Gunungkidul",
                KontakInformasi = "+62 814-2222-3333",
                HargaTiketAcara = 20000,
                TargetPesertaAcara = TargetPesertaAcara.Umum,
                BatasKuotaPeserta = 800,
                StatusPendaftaran = StatusPendaftaran.Dibuka,
                MediaPromosi = new Uri("/assets/Event/Tari_Jathilan.jpg", UriKind.Relative),
                SponsorAcara = "Bank Gunungkidul",
                TautanPendaftaran = new Uri("https://slemankab.go.id/", UriKind.Absolute),
                RatingAcara = 4.7
            },
            new KalenderAcara
            {
                Id = IdAcara.Create("AC007").Value,
                NamaAcara = "Upacara Adat Bersih Desa",
                DekripsiAcara = "Upacara adat tahunan untuk membersihkan desa secara simbolis dan spiritual.",
                Kategori = KategoriAcara.Lainnya,
                TanggalDanWaktu = new DateTime(2025, 09, 10, 08, 0, 0),
                LokasiAcara = "Desa Sambisari, Sleman, Yogyakarta",
                PenanggungJawab = "Kepala Desa",
                KontakInformasi = "+62 815-3333-4444",
                HargaTiketAcara = 0,
                TargetPesertaAcara = TargetPesertaAcara.Umum,
                BatasKuotaPeserta = 1000,
                StatusPendaftaran = StatusPendaftaran.Dibuka,
                MediaPromosi = new Uri("/assets/Event/Upacara_Adat_Bersih_Desa.jpg", UriKind.Relative),
                SponsorAcara = "Koperasi Desa",
                TautanPendaftaran = new Uri("https://gunungkidulkab.go.id/", UriKind.Absolute),
                RatingAcara = 4.6
            },
            new KalenderAcara
            {
                Id = IdAcara.Create("AC008").Value,
                NamaAcara = "Labuhan Parangtritis",
                DekripsiAcara = "Labuhan Parangtritis adalah upacara adat persembahan kepada Ratu Pantai Selatan.",
                Kategori = KategoriAcara.Budaya,
                TanggalDanWaktu = new DateTime(2025, 10, 15, 07, 0, 0),
                LokasiAcara = "Pantai Parangtritis, Bantul, Yogyakarta",
                PenanggungJawab = "Keraton Yogyakarta",
                KontakInformasi = "+62 816-4444-5555",
                HargaTiketAcara = 0,
                TargetPesertaAcara = TargetPesertaAcara.Umum,
                BatasKuotaPeserta = 5000,
                StatusPendaftaran = StatusPendaftaran.Dibuka,
                MediaPromosi = new Uri("/assets/Event/Upacara_Adat_Labuhan_Parangtritis.jpg", UriKind.Relative),
                SponsorAcara = "Pemda Bantul",
                TautanPendaftaran = new Uri("https://bantulkab.go.id/event.html", UriKind.Absolute),
                RatingAcara = 4.8
            }
        );
    }
}