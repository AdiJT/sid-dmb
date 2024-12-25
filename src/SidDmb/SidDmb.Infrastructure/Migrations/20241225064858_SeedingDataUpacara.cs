using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataUpacara : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UpacaraBudaya",
                columns: new[] { "Id", "Dekripsi", "Durasi", "FasilitasPendukung", "JumlahUpacara", "Kategori", "LokasiPelaksanaan", "MediaPromosi", "Nama", "PeraturanKhusus", "PihakTerlibat", "RangkaianAcara", "TanggalDiinputkan", "TanggalPembaruanData", "WaktuPelaksanaan" },
                values: new object[,]
                {
                    { "UB001", "Upacara Labuhan Glagah adalah tradisi masyarakat Yogyakarta sebagai bentuk penghormatan terhadap alam dan leluhur.", new TimeSpan(0, 2, 0, 0, 0), new[] { "Panggung Utama", "Tempat Duduk Penonton", "Sistem Audio" }, 200, 1, "Pantai Glagah, Kulon Progo", "/assets/Upacara_Budaya/Upacara_Labuhan_Glagah.jpg", "Labuhan Glagah", "Dilarang membawa benda terlarang saat prosesi.", "Masyarakat lokal, Dinas Kebudayaan Yogyakarta, Pekerja Seni", "Pembukaan, prosesi labuhan, doa bersama, penutupan.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "UB002", "Labuhan Merapi adalah upacara adat untuk menghormati gunung Merapi sebagai simbol kehidupan dan kemakmuran.", new TimeSpan(0, 3, 0, 0, 0), new[] { "Tempat Parkir", "Panggung Budaya", "Sistem Keamanan" }, 150, 1, "Kawasan Gunung Merapi, Sleman", "/assets/Upacara_Budaya/Upacara_Labuhan_Merapi.jpg", "Labuhan Merapi", "Hanya warga sekitar yang boleh ikut serta dalam prosesi utama.", "Masyarakat sekitar, Pemerintah Daerah, Dinas Kebudayaan Yogyakarta", "Doa bersama, persembahan sesaji, parade budaya.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "UB003", "Upacara Labuhan Parangkusumo dilaksanakan untuk memohon keselamatan dan kesejahteraan bagi masyarakat pesisir.", new TimeSpan(0, 3, 0, 0, 0), new[] { "Tempat Ibadah", "Area Parkir", "Panggung Hiburan" }, 250, 1, "Pantai Parangkusumo, Bantul", "/assets/Upacara_Budaya/Upacara_Labuhan_Parangkusumo.jpg", "Labuhan Parangkusumo", "Dilarang membawa alat elektronik selama prosesi.", "Pemerintah Daerah, Masyarakat Pesisir, Budayawan", "Prosesi Labuhan, doa keselamatan, pelarungan sesaji.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "UB004", "Upacara Ngalap Berkah di Pantai Ngobaran adalah tradisi untuk memohon keberkahan hidup melalui alam.", new TimeSpan(0, 4, 0, 0, 0), new[] { "Tempat Ibadah", "Area Panggung", "Tempat Parkir" }, 300, 1, "Pantai Ngobaran, Gunungkidul", "/assets/Upacara_Budaya/Upacara_Ngalap_Berkah_Pantai_Ngobaran.jpg", "Ngalap Berkah Pantai Ngobaran", "Dilarang merusak alam selama prosesi.", "Masyarakat Gunungkidul, Dinas Pariwisata, Budayawan", "Doa bersama, pelarungan sesaji ke laut, tarian budaya.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "UB005", "Sekaten Sleman adalah perayaan budaya yang digelar untuk merayakan hari jadi Kabupaten Sleman.", new TimeSpan(0, 5, 0, 0, 0), new[] { "Tempat Duduk Penonton", "Area Stand Makanan", "Panggung Hiburan" }, 400, 1, "Alun-Alun Sleman", "/assets/Upacara_Budaya/Upacara_Sekaten_Sleman.jpg", "Sekaten Sleman", "Patuhi aturan keamanan dan kebersihan selama acara berlangsung.", "Pemerintah Daerah Sleman, Masyarakat Sleman, Pengusaha Lokal", "Pawai budaya, pertunjukan seni, pasar rakyat.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Komentar",
                columns: new[] { "Id", "ArtefakBudayaId", "Isi", "Nama", "Rating", "SeniBudayaId", "SitusBudayaId", "UpacaraBudayaId" },
                values: new object[,]
                {
                    { 46, null, "Labuhan Glagah adalah upacara yang penuh dengan nilai sejarah dan budaya. Sangat mengesankan.", "Agus Subekti", 5.0, null, null, "UB001" },
                    { 47, null, "Labuhan Merapi memberikan pengalaman spiritual yang luar biasa. Prosesi sangat terhormat.", "Dian Purnama", 4.7999999999999998, null, null, "UB002" },
                    { 48, null, "Labuhan Parangkusumo selalu menyentuh hati, suasananya sangat tenang dan penuh makna.", "Rina Santosa", 5.0, null, null, "UB003" },
                    { 49, null, "Ngalap Berkah di Pantai Ngobaran adalah acara yang sangat mendalam, penuh dengan doa dan harapan.", "Haris Iskandar", 4.9000000000000004, null, null, "UB004" },
                    { 50, null, "Sekaten Sleman adalah pesta budaya yang sangat meriah dan menyenangkan. Sangat layak untuk dikunjungi.", "Maya Sekar", 4.7000000000000002, null, null, "UB005" },
                    { 51, null, "Labuhan Glagah memberikan nuansa yang sangat khas Yogyakarta. Sangat berkesan dan mendalam.", "Budi Prasetyo", 4.7999999999999998, null, null, "UB001" },
                    { 52, null, "Labuhan Merapi adalah upacara yang mempesona dan sangat penuh dengan makna spiritual.", "Siti Aisyah", 5.0, null, null, "UB002" },
                    { 53, null, "Labuhan Parangkusumo menawarkan kedamaian dan sangat cocok untuk meditasi.", "Rudi Hartono", 4.9000000000000004, null, null, "UB003" },
                    { 54, null, "Ngalap Berkah adalah pengalaman spiritual yang sangat berharga bagi saya. Sangat menyentuh hati.", "Dewi Yuliana", 5.0, null, null, "UB004" },
                    { 55, null, "Sekaten Sleman adalah acara yang penuh warna dan sangat memikat. Terbaik untuk wisata budaya.", "Agus Wijaya", 4.7999999999999998, null, null, "UB005" },
                    { 56, null, "Labuhan Glagah sangat menarik. Saya akan datang lagi untuk menyaksikan upacara ini.", "Lina Kurnia", 5.0, null, null, "UB001" },
                    { 57, null, "Labuhan Merapi adalah acara yang memberikan kedamaian, sangat menghargai budaya lokal.", "Anton Subroto", 4.7000000000000002, null, null, "UB002" },
                    { 58, null, "Labuhan Parangkusumo adalah tempat yang sangat cocok untuk berdoa dan merenung.", "Mira Oktaviani", 5.0, null, null, "UB003" },
                    { 59, null, "Ngalap Berkah Pantai Ngobaran adalah upacara yang penuh kesakralan dan kedamaian. Sangat menyentuh.", "Hadi Pranata", 5.0, null, null, "UB004" },
                    { 60, null, "Sekaten Sleman adalah perayaan yang luar biasa, penuh dengan acara menarik dan penuh semangat.", "Sari Lestari", 4.9000000000000004, null, null, "UB005" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "UpacaraBudaya",
                keyColumn: "Id",
                keyValue: "UB001");

            migrationBuilder.DeleteData(
                table: "UpacaraBudaya",
                keyColumn: "Id",
                keyValue: "UB002");

            migrationBuilder.DeleteData(
                table: "UpacaraBudaya",
                keyColumn: "Id",
                keyValue: "UB003");

            migrationBuilder.DeleteData(
                table: "UpacaraBudaya",
                keyColumn: "Id",
                keyValue: "UB004");

            migrationBuilder.DeleteData(
                table: "UpacaraBudaya",
                keyColumn: "Id",
                keyValue: "UB005");
        }
    }
}
