using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataArtefak : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArtefakBudaya",
                keyColumn: "Id",
                keyValue: "AR001",
                columns: new[] { "Bahan", "Dekripsi", "Dimensi", "Foto", "LokasiPenyimpanan", "Nama", "NilaiHistoris", "Pengelola", "TanggalDiinputkan", "TanggalPembaruanData", "Usia" },
                values: new object[] { "Batu Andesit", "Batu berbentuk kenong yang digunakan dalam ritual tradisional masyarakat Kulon Progo.", "Diameter: 50 cm, Tinggi: 40 cm", "/assets/Artefak_Budaya/Artefak_Batu_Kenong.jpg", "Museum Kulon Progo", "Batu Kenong", "Digunakan dalam upacara adat sejak masa Hindu-Buddha.", "Dinas Kebudayaan Kulon Progo", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abad ke-10" });

            migrationBuilder.InsertData(
                table: "ArtefakBudaya",
                columns: new[] { "Id", "Bahan", "Dekripsi", "Dimensi", "Foto", "Kategori", "Ketersediaan", "Kondisi", "LokasiPenyimpanan", "Nama", "NilaiHistoris", "Pengelola", "TanggalDiinputkan", "TanggalPembaruanData", "Usia" },
                values: new object[,]
                {
                    { "AR002", "Batu Andesit", "Prasasti yang ditemukan di kawasan Candi Ijo, mencatat sejarah masa kerajaan Mataram Kuno.", "Tinggi: 1,2 m, Lebar: 70 cm", "/assets/Artefak_Budaya/Artefak_Batu_Prasasti_Candi_Ijo.jpg", 2, 0, 0, "Museum Candi Ijo", "Batu Prasasti Candi Ijo", "Prasasti ini mencatat informasi penting tentang kehidupan pada masa kerajaan Hindu.", "Balai Pelestarian Cagar Budaya Yogyakarta", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abad ke-9" },
                    { "AR003", "Batu Andesit", "Patung Dewa Ganesha yang ditemukan di kompleks Candi Sambisari.", "Tinggi: 60 cm, Lebar: 40 cm", "/assets/Artefak_Budaya/Artefak_Patung_Ganesha_Candi_Sambisari.jpg", 0, 0, 0, "Museum Candi Sambisari", "Patung Ganesha", "Artefak ini mencerminkan pengaruh Hindu pada masa kerajaan Mataram.", "Balai Pelestarian Cagar Budaya Yogyakarta", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abad ke-9" },
                    { "AR004", "Batu Andesit", "Prasasti yang mencatat sejarah wilayah Kedu pada masa kerajaan Mataram Kuno.", "Tinggi: 1,5 m, Lebar: 80 cm", "/assets/Artefak_Budaya/Artefak_Prasasti_Kedu.jpg", 2, 0, 0, "Museum Sejarah Kedu", "Prasasti Kedu", "Prasasti ini berisi informasi penting tentang administrasi kerajaan Mataram.", "Balai Pelestarian Cagar Budaya Jawa Tengah", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abad ke-9" },
                    { "AR005", "Batu Andesit", "Prasasti yang ditemukan di Gunungkidul dan mencatat kehidupan masyarakat setempat.", "Tinggi: 1,3 m, Lebar: 70 cm", "/assets/Artefak_Budaya/Artefak_Prasasti_Munggur.jpg", 2, 0, 0, "Museum Gunungkidul", "Prasasti Munggur", "Prasasti ini mencerminkan tata kehidupan masyarakat desa pada masa kerajaan Mataram.", "Dinas Kebudayaan Gunungkidul", new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abad ke-10" }
                });

            migrationBuilder.UpdateData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Isi", "Nama", "Rating" },
                values: new object[] { "Batu Kenong memberikan gambaran menarik tentang budaya Hindu-Buddha di Kulon Progo.", "Fernand Putra", 4.5 });

            migrationBuilder.InsertData(
                table: "Komentar",
                columns: new[] { "Id", "ArtefakBudayaId", "Isi", "Nama", "Rating", "SeniBudayaId", "SitusBudayaId", "UpacaraBudayaId" },
                values: new object[,]
                {
                    { 2, "AR001", "Artefak ini sangat penting untuk penelitian tentang tradisi ritual masyarakat Jawa kuno.", "Peneliti Sejarah", 5.0, null, null, null },
                    { 3, "AR001", "Dimensi Batu Kenong mencerminkan simbolisme dalam adat tradisional.", "Sejarawan Muda", 4.7000000000000002, null, null, null },
                    { 4, "AR002", "Batu Prasasti Candi Ijo menyimpan banyak informasi berharga tentang sejarah Mataram.", "Pelajar Arkeologi", 4.9000000000000004, null, null, null },
                    { 5, "AR002", "Sebuah bukti kuat dari masa keemasan kerajaan Hindu di Jawa.", "Sejarawan Lokal", 5.0, null, null, null },
                    { 6, "AR002", "Lokasi penyimpanan dan pelestarian prasasti ini sudah sangat baik.", "Pengunjung Museum", 4.7999999999999998, null, null, null },
                    { 7, "AR003", "Patung Ganesha ini sangat menarik dengan detail yang terjaga.", "Pecinta Seni", 4.5999999999999996, null, null, null },
                    { 8, "AR003", "Representasi Ganesha di patung ini mencerminkan nilai budaya tinggi pada masa lalu.", "Peneliti Mitologi", 4.7000000000000002, null, null, null },
                    { 9, "AR003", "Patung ini menambah daya tarik sejarah kompleks Candi Sambisari.", "Pengunjung Sambisari", 4.9000000000000004, null, null, null },
                    { 10, "AR004", "Prasasti Kedu memberikan wawasan mendalam tentang administrasi Mataram.", "Mahasiswa Sejarah", 5.0, null, null, null },
                    { 11, "AR004", "Artefak ini sangat informatif untuk belajar tentang kerajaan Mataram.", "Pengunjung Jawa Tengah", 4.7999999999999998, null, null, null },
                    { 12, "AR004", "Dimensi besar prasasti ini membuatnya menjadi pusat perhatian.", "Pecinta Sejarah", 4.7000000000000002, null, null, null },
                    { 13, "AR005", "Prasasti Munggur adalah saksi penting kehidupan masyarakat desa Gunungkidul.", "Sejarawan Desa", 4.9000000000000004, null, null, null },
                    { 14, "AR005", "Tulisan di prasasti ini memberikan gambaran tentang tata bahasa masa lalu.", "Peneliti Bahasa Kuno", 5.0, null, null, null },
                    { 15, "AR005", "Prasasti ini adalah salah satu peninggalan budaya paling menarik di wilayah ini.", "Pengunjung Gunungkidul", 4.7999999999999998, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ArtefakBudaya",
                keyColumn: "Id",
                keyValue: "AR002");

            migrationBuilder.DeleteData(
                table: "ArtefakBudaya",
                keyColumn: "Id",
                keyValue: "AR003");

            migrationBuilder.DeleteData(
                table: "ArtefakBudaya",
                keyColumn: "Id",
                keyValue: "AR004");

            migrationBuilder.DeleteData(
                table: "ArtefakBudaya",
                keyColumn: "Id",
                keyValue: "AR005");

            migrationBuilder.UpdateData(
                table: "ArtefakBudaya",
                keyColumn: "Id",
                keyValue: "AR001",
                columns: new[] { "Bahan", "Dekripsi", "Dimensi", "Foto", "LokasiPenyimpanan", "Nama", "NilaiHistoris", "Pengelola", "TanggalDiinputkan", "TanggalPembaruanData", "Usia" },
                values: new object[] { "Besi, Perunggu", "Keris ini dipercaya sebagai pusaka warisan Ki Ageng Gilang.", "Panjang: 40 cm, Lebar: 10 cm", "/assets/artefak-test.png", "Museum Desa Gilangharjo", "Keris Ki Ageng Gilang", "Artefak ini digunakan dalam upacara adat sejak abad ke-17.", "Kelompok Budaya Desa Gilangharjo", new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abad ke-17" });

            migrationBuilder.UpdateData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Isi", "Nama", "Rating" },
                values: new object[] { "Artefak yang sangat menarik, tetapi informasi lebih detail diperlukan.", "Kometator 1", 4.7999999999999998 });
        }
    }
}
