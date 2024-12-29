using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;
using SidDmb.Domain.MasterDataFunction.ModulWisata.LaporanKunjungans;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulWisata.LaporanKunjungans;

internal class LaporanKunjunganConfiguration : IEntityTypeConfiguration<LaporanKunjungan>
{
    public void Configure(EntityTypeBuilder<LaporanKunjungan> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdKunjungan.Create(s).Value);

        builder.HasOne(x => x.DestinasiWisata).WithMany(x => x.DaftarLaporanKunjungan);

        builder.HasData(
            new
            {
                Id = IdKunjungan.Create("LK001").Value,
                TanggalKunjungan = new DateOnly(2024, 1, 1),
                JumlahWisatawanDomestik = 75,
                JumlahWisatawanInternasional = 75,
                DurasiKunjungan = TimeSpan.FromHours(6),
                TiketTerjual = 150,
                RatingPengunjung = 4.7,
                KomentarPengunjung = "Mantap",
                DestinasiWisataId = IdDestinasi.Create("DW001").Value,
                TanggalDiinputkan = new DateTime(2024, 12, 29),
                TanggalPembaruanData = new DateTime(2024, 12, 29),
            },
            new
            {
                Id = IdKunjungan.Create("LK002").Value,
                TanggalKunjungan = new DateOnly(2024, 2, 1),
                JumlahWisatawanDomestik = 100,
                JumlahWisatawanInternasional = 100,
                DurasiKunjungan = TimeSpan.FromHours(6),
                TiketTerjual = 200,
                RatingPengunjung = 4.7,
                KomentarPengunjung = "Mantap",
                DestinasiWisataId = IdDestinasi.Create("DW002").Value,
                TanggalDiinputkan = new DateTime(2024, 12, 29),
                TanggalPembaruanData = new DateTime(2024, 12, 29),
            },
            new
            {
                Id = IdKunjungan.Create("LK003").Value,
                TanggalKunjungan = new DateOnly(2024, 3, 1),
                JumlahWisatawanDomestik = 60,
                JumlahWisatawanInternasional = 60,
                DurasiKunjungan = TimeSpan.FromHours(6),
                TiketTerjual = 200,
                RatingPengunjung = 4.7,
                KomentarPengunjung = "Mantap",
                DestinasiWisataId = IdDestinasi.Create("DW003").Value,
                TanggalDiinputkan = new DateTime(2024, 12, 29),
                TanggalPembaruanData = new DateTime(2024, 12, 29),
            },
            new
            {
                Id = IdKunjungan.Create("LK004").Value,
                TanggalKunjungan = new DateOnly(2024, 4, 1),
                JumlahWisatawanDomestik = 125,
                JumlahWisatawanInternasional = 125,
                DurasiKunjungan = TimeSpan.FromHours(6),
                TiketTerjual = 200,
                RatingPengunjung = 4.7,
                KomentarPengunjung = "Mantap",
                DestinasiWisataId = IdDestinasi.Create("DW004").Value,
                TanggalDiinputkan = new DateTime(2024, 12, 29),
                TanggalPembaruanData = new DateTime(2024, 12, 29),
            },
            new
            {
                Id = IdKunjungan.Create("LK005").Value,
                TanggalKunjungan = new DateOnly(2024, 5, 1),
                JumlahWisatawanDomestik = 150,
                JumlahWisatawanInternasional = 150,
                DurasiKunjungan = TimeSpan.FromHours(6),
                TiketTerjual = 200,
                RatingPengunjung = 4.7,
                KomentarPengunjung = "Mantap",
                DestinasiWisataId = IdDestinasi.Create("DW005").Value,
                TanggalDiinputkan = new DateTime(2024, 12, 29),
                TanggalPembaruanData = new DateTime(2024, 12, 29),
            },
            new
            {
                Id = IdKunjungan.Create("LK006").Value,
                TanggalKunjungan = new DateOnly(2024, 6, 1),
                JumlahWisatawanDomestik = 200,
                JumlahWisatawanInternasional = 200,
                DurasiKunjungan = TimeSpan.FromHours(6),
                TiketTerjual = 200,
                RatingPengunjung = 4.7,
                KomentarPengunjung = "Mantap",
                DestinasiWisataId = IdDestinasi.Create("DW001").Value,
                TanggalDiinputkan = new DateTime(2024, 12, 29),
                TanggalPembaruanData = new DateTime(2024, 12, 29),
            },
            new
            {
                Id = IdKunjungan.Create("LK007").Value,
                TanggalKunjungan = new DateOnly(2024, 7, 1),
                JumlahWisatawanDomestik = 125,
                JumlahWisatawanInternasional = 125,
                DurasiKunjungan = TimeSpan.FromHours(6),
                TiketTerjual = 200,
                RatingPengunjung = 4.7,
                KomentarPengunjung = "Mantap",
                DestinasiWisataId = IdDestinasi.Create("DW002").Value,
                TanggalDiinputkan = new DateTime(2024, 12, 29),
                TanggalPembaruanData = new DateTime(2024, 12, 29),
            },
            new
            {
                Id = IdKunjungan.Create("LK008").Value,
                TanggalKunjungan = new DateOnly(2024, 8, 1),
                JumlahWisatawanDomestik = 65,
                JumlahWisatawanInternasional = 65,
                DurasiKunjungan = TimeSpan.FromHours(6),
                TiketTerjual = 200,
                RatingPengunjung = 4.7,
                KomentarPengunjung = "Mantap",
                DestinasiWisataId = IdDestinasi.Create("DW003").Value,
                TanggalDiinputkan = new DateTime(2024, 12, 29),
                TanggalPembaruanData = new DateTime(2024, 12, 29),
            },
            new
            {
                Id = IdKunjungan.Create("LK009").Value,
                TanggalKunjungan = new DateOnly(2024, 9, 1),
                JumlahWisatawanDomestik = 100,
                JumlahWisatawanInternasional = 100,
                DurasiKunjungan = TimeSpan.FromHours(6),
                TiketTerjual = 200,
                RatingPengunjung = 4.7,
                KomentarPengunjung = "Mantap",
                DestinasiWisataId = IdDestinasi.Create("DW004").Value,
                TanggalDiinputkan = new DateTime(2024, 12, 29),
                TanggalPembaruanData = new DateTime(2024, 12, 29),
            },
            new
            {
                Id = IdKunjungan.Create("LK010").Value,
                TanggalKunjungan = new DateOnly(2024, 10, 1),
                JumlahWisatawanDomestik = 75,
                JumlahWisatawanInternasional = 75,
                DurasiKunjungan = TimeSpan.FromHours(6),
                TiketTerjual = 200,
                RatingPengunjung = 4.7,
                KomentarPengunjung = "Mantap",
                DestinasiWisataId = IdDestinasi.Create("DW005").Value,
                TanggalDiinputkan = new DateTime(2024, 12, 29),
                TanggalPembaruanData = new DateTime(2024, 12, 29),
            },
            new
            {
                Id = IdKunjungan.Create("LK011").Value,
                TanggalKunjungan = new DateOnly(2024, 11, 1),
                JumlahWisatawanDomestik = 100,
                JumlahWisatawanInternasional = 45,
                DurasiKunjungan = TimeSpan.FromHours(6),
                TiketTerjual = 200,
                RatingPengunjung = 4.7,
                KomentarPengunjung = "Mantap",
                DestinasiWisataId = IdDestinasi.Create("DW001").Value,
                TanggalDiinputkan = new DateTime(2024, 12, 29),
                TanggalPembaruanData = new DateTime(2024, 12, 29),
            },
            new
            {
                Id = IdKunjungan.Create("LK012").Value,
                TanggalKunjungan = new DateOnly(2024, 12, 1),
                JumlahWisatawanDomestik = 75,
                JumlahWisatawanInternasional = 75,
                DurasiKunjungan = TimeSpan.FromHours(6),
                TiketTerjual = 200,
                RatingPengunjung = 4.7,
                KomentarPengunjung = "Mantap",
                DestinasiWisataId = IdDestinasi.Create("DW002").Value,
                TanggalDiinputkan = new DateTime(2024, 12, 29),
                TanggalPembaruanData = new DateTime(2024, 12, 29),
            }
        );
    }
}