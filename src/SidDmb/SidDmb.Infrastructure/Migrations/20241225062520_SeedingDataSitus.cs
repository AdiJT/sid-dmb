using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataSitus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SitusBudaya",
                columns: new[] { "Id", "Alamat", "DaftarFasilitas", "Dekripsi", "FotoPromosi", "HargaTiketMasuk", "JamOperasional", "Kategori", "KontakInformasi", "KoordinatLokasi", "Nama", "PengelolaSitus", "PeraturanKhusus", "Status", "TanggalDiinputkan", "TanggalPembaruanData" },
                values: new object[,]
                {
                    { "SB001", "Jl. Candi Sambisari, Purwomartani, Kalasan, Sleman, Yogyakarta", new[] { "Panggung Utama", "Tempat Duduk Penonton", "Sistem Audio" }, "Candi Sambisari adalah situs sejarah yang terletak di Yogyakarta, berasal dari abad ke-9 dan merupakan peninggalan kerajaan Mataram Kuno.", "/assets/Situs_Budaya/Situs_Candi_Sambisari.jpg", 20000.0, "08:00 - 17:00", 0, "+62 812-3456-7890", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (110.356384 -7.726992)"), "Candi Sambisari", "Balai Pelestarian Cagar Budaya Yogyakarta", "Dilarang membawa makanan dan minuman ke area candi.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "SB002", "Dusun Tritis, Purworejo, Yogyakarta", new[] { "Tempat Doa", "Area Parkir", "Toilet Umum" }, "Gua Maria Tritis adalah situs ziarah yang terletak di Gunung Tritis, Yogyakarta, dikenal dengan kesan spiritual dan pemandangan alamnya.", "/assets/Situs_Budaya/Situs_Gua_Maria_Tritis.jpg", 10000.0, "06:00 - 18:00", 1, "+62 878-2123-4567", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (110.552711 -8.082159)"), "Gua Maria Tritis", "Paroki Setempat", "Dilarang merokok dan membawa makanan di area ziarah.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "SB003", "Dusun Rancang Kencono, Nglanggeran, Yogyakarta", new[] { "Jalur Pendakian", "Area Istirahat", "Pemandu Wisata" }, "Gua Rancang Kencono adalah situs alami yang dikenal dengan keindahan formasi batuan stalaktit dan stalagmit serta keasrian alam sekitar.", "/assets/Situs_Budaya/Situs_Gua_Rancang_kencono.jpg", 15000.0, "08:00 - 16:00", 2, "+62 811-6347-897", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (110.492699 -7.9495)"), "Gua Rancang Kencono", "Dinas Pariwisata Kabupaten Gunungkidul", "Tidak diperbolehkan memasuki gua tanpa pemandu.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "SB004", "Gunung Wukir, Sleman, Yogyakarta", new[] { "Area Parkir", "Tempat Istirahat", "Papan Informasi" }, "Situs Gunung Wukir adalah peninggalan budaya Hindu-Buddha yang ditemukan di kawasan Gunung Wukir, Yogyakarta, dengan berbagai prasasti kuno.", "/assets/Situs_Budaya/Situs_Gunung_Wukir.jpg", 25000.0, "08:00 - 17:00", 0, "+62 858-3423-6237", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (110.34993 -7.784865)"), "Situs Gunung Wukir", "Balai Pelestarian Cagar Budaya Yogyakarta", "Dilarang membawa tas besar dan makanan ke area situs.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "SB005", "Desa Mangir, Bantul, Yogyakarta", new[] { "Tempat Duduk", "Toilet Umum", "Papan Penunjuk Arah" }, "Situs Mangir adalah situs sejarah yang menyimpan artefak-artefak penting dari era kerajaan Mataram Kuno, terletak di Kabupaten Bantul.", "/assets/Situs_Budaya/Situs_Mangir.jpg", 20000.0, "07:00 - 17:00", 0, "+62 821-4321-8765", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (110.319917 -7.877201)"), "Situs Mangir", "Dinas Kebudayaan Yogyakarta", "Dilarang membawa benda tajam dan minuman keras.", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Komentar",
                columns: new[] { "Id", "ArtefakBudayaId", "Isi", "Nama", "Rating", "SeniBudayaId", "SitusBudayaId", "UpacaraBudayaId" },
                values: new object[,]
                {
                    { 31, null, "Candi Sambisari adalah situs yang sangat memukau dan penuh sejarah. Saya sangat menghargai upaya pelestariannya.", "Budi Santoso", 5.0, null, "SB001", null },
                    { 32, null, "Gua Maria Tritis memberikan pengalaman spiritual yang mendalam, pemandangan alamnya juga luar biasa.", "Dewi Lestari", 4.7999999999999998, null, "SB002", null },
                    { 33, null, "Gua Rancang Kencono menawarkan pengalaman petualangan yang luar biasa. Formasi gua sangat indah dan mempesona.", "Rina Sari", 4.9000000000000004, null, "SB003", null },
                    { 34, null, "Situs Gunung Wukir adalah situs yang sangat kaya akan nilai sejarah. Keindahan alamnya juga tidak kalah menarik.", "Eko Yulianto", 4.9000000000000004, null, "SB004", null },
                    { 35, null, "Situs Mangir memberikan wawasan baru tentang kerajaan Mataram Kuno, sangat mendalam dan penuh informasi.", "Maya Widya", 4.7000000000000002, null, "SB005", null },
                    { 36, null, "Candi Sambisari adalah tempat yang sangat mengesankan. Saya menikmati setiap detil arsitekturnya.", "Andi Wijaya", 4.7999999999999998, null, "SB001", null },
                    { 37, null, "Gua Maria Tritis sangat tenang dan damai. Tempat yang cocok untuk merenung dan berdoa.", "Siti Khadijah", 5.0, null, "SB002", null },
                    { 38, null, "Gua Rancang Kencono sangat menantang. Pemandangannya menakjubkan dan cocok bagi pecinta alam.", "Haris Setiawan", 4.5999999999999996, null, "SB003", null },
                    { 39, null, "Situs Gunung Wukir memberikan nuansa sejarah yang kuat, tempat yang sangat bersejarah dan penuh nilai budaya.", "Lina Hartini", 4.9000000000000004, null, "SB004", null },
                    { 40, null, "Situs Mangir benar-benar menarik, ada banyak cerita yang bisa dipelajari dari sini.", "Anton Dwi", 4.7000000000000002, null, "SB005", null },
                    { 41, null, "Saya sangat menikmati kunjungan saya ke Candi Sambisari. Tempat yang sangat historis dan penuh pesona.", "Rudi Hartono", 5.0, null, "SB001", null },
                    { 42, null, "Gua Maria Tritis adalah tempat yang sangat spiritual. Sangat menenangkan untuk berdoa di sana.", "Indah Sari", 5.0, null, "SB002", null },
                    { 43, null, "Gua Rancang Kencono adalah tempat yang cocok untuk berpetualang. Keindahan gua dan alamnya luar biasa.", "Joko Prasetyo", 4.7000000000000002, null, "SB003", null },
                    { 44, null, "Situs Gunung Wukir penuh dengan keindahan alam dan sejarah. Benar-benar menarik untuk dipelajari.", "Eka Rizki", 4.7999999999999998, null, "SB004", null },
                    { 45, null, "Situs Mangir adalah destinasi yang harus dikunjungi bagi penggemar sejarah. Banyak hal yang bisa dipelajari di sini.", "Nina Ayu", 4.9000000000000004, null, "SB005", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "SitusBudaya",
                keyColumn: "Id",
                keyValue: "SB001");

            migrationBuilder.DeleteData(
                table: "SitusBudaya",
                keyColumn: "Id",
                keyValue: "SB002");

            migrationBuilder.DeleteData(
                table: "SitusBudaya",
                keyColumn: "Id",
                keyValue: "SB003");

            migrationBuilder.DeleteData(
                table: "SitusBudaya",
                keyColumn: "Id",
                keyValue: "SB004");

            migrationBuilder.DeleteData(
                table: "SitusBudaya",
                keyColumn: "Id",
                keyValue: "SB005");
        }
    }
}
