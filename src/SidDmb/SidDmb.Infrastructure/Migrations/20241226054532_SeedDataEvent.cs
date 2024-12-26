using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "KalenderAcara",
                columns: new[] { "Id", "BatasKuotaPeserta", "DekripsiAcara", "HargaTiketAcara", "Kategori", "KontakInformasi", "LokasiAcara", "MediaPromosi", "NamaAcara", "PenanggungJawab", "RatingAcara", "SponsorAcara", "StatusPendaftaran", "TanggalDanWaktu", "TanggalDiinputkan", "TanggalPembaruanData", "TargetPesertaAcara", "TautanPendaftaran" },
                values: new object[,]
                {
                    { "AC001", 2000, "Festival Kesenian Bantul menampilkan berbagai seni tradisional, seperti tari, musik, dan pameran kerajinan.", 15000.0, 0, "+62 813-4567-8910", "Pendopo Parasamya Bantul, Yogyakarta", "/assets/Event/Festival_Kesenian_Bantul.jpg", "Festival Kesenian Bantul", "Dinas Kebudayaan Bantul", 4.7999999999999998, "PT Seni Nusantara", 0, new DateTime(2025, 3, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://bantulkab.go.id/event.html" },
                    { "AC002", 1500, "Acara tahunan ini menampilkan seni budaya khas Sleman dengan fokus pada musik dan tari.", 20000.0, 0, "+62 812-3456-7890", "Taman Tebing Breksi, Sleman, Yogyakarta", "/assets/Event/Festival_Kesenian_Sleman.jpg", "Festival Kesenian Sleman", "Dinas Pariwisata Sleman", 4.7000000000000002, "Bank Sleman", 0, new DateTime(2025, 4, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://slemankab.go.id/" },
                    { "AC003", 2500, "Festival ini merayakan keindahan alam Pegunungan Menoreh melalui seni dan budaya.", 10000.0, 0, "+62 813-9876-5432", "Bukit Menoreh, Kulon Progo, Yogyakarta", "/assets/Event/Festival_Menoreh_Kulon_Progo.jpg", "Festival Menoreh Kulon Progo", "Komunitas Seni Kulon Progo", 4.5999999999999996, "PT Menoreh Lestari", 0, new DateTime(2025, 5, 10, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://kulonprogokab.go.id/v31/" },
                    { "AC004", 3000, "Perayaan seni dan budaya di kompleks Candi Ratu Boko dengan pertunjukan tari dan teater.", 50000.0, 2, "+62 812-7654-3210", "Candi Ratu Boko, Sleman, Yogyakarta", "/assets/Event/Festival_Seribu_Candi_Ratu_Boko.jpg", "Festival Seribu Candi Ratu Boko", "Dinas Pariwisata Yogyakarta", 4.9000000000000004, "Candi Foundation", 0, new DateTime(2025, 6, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://gunungkidulkab.go.id/" },
                    { "AC005", 500, "Pertunjukan Tari Angguk khas Yogyakarta yang mengangkat cerita rakyat melalui gerakan unik.", 30000.0, 0, "+62 813-1111-2222", "Gedung Kesenian Yogyakarta", "/assets/Event/Tari_Angguk.jpg", "Tari Angguk", "Sanggar Tari Tradisional", 4.5, "Kementerian Kebudayaan", 0, new DateTime(2025, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://kulonprogokab.go.id/v31/" },
                    { "AC006", 800, "Tari Jathilan adalah tarian tradisional yang memadukan unsur mistis dan seni.", 20000.0, 0, "+62 814-2222-3333", "Alun-Alun Wonosari, Gunungkidul", "/assets/Event/Tari_Jathilan.jpg", "Tari Jathilan", "Paguyuban Jathilan Gunungkidul", 4.7000000000000002, "Bank Gunungkidul", 0, new DateTime(2025, 8, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://slemankab.go.id/" },
                    { "AC007", 1000, "Upacara adat tahunan untuk membersihkan desa secara simbolis dan spiritual.", 0.0, 3, "+62 815-3333-4444", "Desa Sambisari, Sleman, Yogyakarta", "/assets/Event/Upacara_Adat_Bersih_Desa.jpg", "Upacara Adat Bersih Desa", "Kepala Desa", 4.5999999999999996, "Koperasi Desa", 0, new DateTime(2025, 9, 10, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://gunungkidulkab.go.id/" },
                    { "AC008", 5000, "Labuhan Parangtritis adalah upacara adat persembahan kepada Ratu Pantai Selatan.", 0.0, 0, "+62 816-4444-5555", "Pantai Parangtritis, Bantul, Yogyakarta", "/assets/Event/Upacara_Adat_Labuhan_Parangtritis.jpg", "Labuhan Parangtritis", "Keraton Yogyakarta", 4.7999999999999998, "Pemda Bantul", 0, new DateTime(2025, 10, 15, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "https://bantulkab.go.id/event.html" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KalenderAcara",
                keyColumn: "Id",
                keyValue: "AC001");

            migrationBuilder.DeleteData(
                table: "KalenderAcara",
                keyColumn: "Id",
                keyValue: "AC002");

            migrationBuilder.DeleteData(
                table: "KalenderAcara",
                keyColumn: "Id",
                keyValue: "AC003");

            migrationBuilder.DeleteData(
                table: "KalenderAcara",
                keyColumn: "Id",
                keyValue: "AC004");

            migrationBuilder.DeleteData(
                table: "KalenderAcara",
                keyColumn: "Id",
                keyValue: "AC005");

            migrationBuilder.DeleteData(
                table: "KalenderAcara",
                keyColumn: "Id",
                keyValue: "AC006");

            migrationBuilder.DeleteData(
                table: "KalenderAcara",
                keyColumn: "Id",
                keyValue: "AC007");

            migrationBuilder.DeleteData(
                table: "KalenderAcara",
                keyColumn: "Id",
                keyValue: "AC008");
        }
    }
}
