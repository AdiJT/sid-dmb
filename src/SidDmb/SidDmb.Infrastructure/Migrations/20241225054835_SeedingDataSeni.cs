using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SidDmb.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataSeni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SeniBudaya",
                columns: new[] { "Id", "Dekripsi", "DurasiPentunjukan", "FasilitasPertunjukan", "HargaTiket", "Kategori", "LokasiPertunjukan", "MediaPromosi", "Nama", "NamaPelakuSeni", "PeraturanKhusus", "TanggalDiinputkan", "TanggalPembaruanData", "WaktuPertunjukan" },
                values: new object[,]
                {
                    { "SB001", "Tari Angguk adalah tarian tradisional khas Yogyakarta yang menggambarkan sukacita masyarakat dalam menyambut kedatangan tamu atau acara tertentu.", new TimeSpan(0, 2, 0, 0, 0), new[] { "Panggung Utama", "Tempat Duduk Penonton", "Sistem Audio" }, 20000.0, 0, "Padepokan Seni Angguk, Yogyakarta", "/assets/Seni_Budaya/Seni_Tari_Angguk.jpg", "Tari Angguk", "Grup Seni Angguk Yogyakarta", "Dilarang merekam pertunjukan tanpa izin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sabtu, 19:00 - 21:00" },
                    { "SB002", "Tari Bedhaya adalah tarian tradisional yang menggambarkan kedamaian dan kebesaran kerajaan, sering kali ditampilkan dalam upacara besar di istana.", new TimeSpan(0, 1, 30, 0, 0), new[] { "Panggung Keraton", "Tempat Duduk VIP", "Sistem Pencahayaan" }, 50000.0, 0, "Keraton Yogyakarta", "/assets/Seni_Budaya/Seni_Tari_Bedhaya.jpg", "Tari Bedhaya", "Grup Tari Bedhaya Yogyakarta", "Dilarang memakai pakaian sembarangan", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minggu, 18:00 - 20:00" },
                    { "SB003", "Tari Dolalak merupakan tarian rakyat yang menceritakan kisah perjuangan para pahlawan dan keperkasaan mereka dalam melawan penjajahan.", new TimeSpan(0, 2, 0, 0, 0), new[] { "Panggung Terbuka", "Tempat Duduk Penonton", "Sistem Suara" }, 15000.0, 0, "Alun-alun Yogyakarta", "/assets/Seni_Budaya/Seni_Tari_Dolalak.jpg", "Tari Dolalak", "Grup Seni Dolalak Yogyakarta", "Tidak boleh membawa makanan atau minuman", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jumat, 17:30 - 19:30" },
                    { "SB004", "Tari Gambyong adalah tarian klasik dari Yogyakarta yang menggambarkan kelembutan dan keanggunan para wanita dalam kehidupan sehari-hari.", new TimeSpan(0, 1, 30, 0, 0), new[] { "Panggung Tertutup", "Kursi Penonton", "Sistem Pencahayaan" }, 30000.0, 0, "Taman Sari Yogyakarta", "/assets/Seni_Budaya/Seni_Tari_Gambyong.jpg", "Tari Gambyong", "Grup Tari Gambyong Yogyakarta", "Silakan menggunakan pakaian formal untuk acara ini", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sabtu, 20:00 - 22:00" },
                    { "SB005", "Tari Kuda Lumping adalah tarian tradisional yang menggambarkan keberanian dan semangat juang dengan unsur kesurupan dan tarian yang dinamis.", new TimeSpan(0, 2, 0, 0, 0), new[] { "Panggung Luar Ruangan", "Area Penonton Terbuka", "Tempat Ganti" }, 25000.0, 0, "Padepokan Kuda Lumping Yogyakarta", "/assets/Seni_Budaya/Seni_Tari_Kuda_Lumping.jpg", "Tari Kuda Lumping", "Grup Seni Kuda Lumping Yogyakarta", "Pengunjung yang sensitif terhadap suara keras disarankan tidak hadir", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minggu, 20:00 - 22:00" }
                });

            migrationBuilder.InsertData(
                table: "Komentar",
                columns: new[] { "Id", "ArtefakBudayaId", "Isi", "Nama", "Rating", "SeniBudayaId", "SitusBudayaId", "UpacaraBudayaId" },
                values: new object[,]
                {
                    { 16, null, "Tari Angguk sangat memukau dengan energinya yang menghidupkan suasana. Saya berharap dapat melihatnya lagi.", "Siti Aisyah", 4.9000000000000004, "SB001", null, null },
                    { 17, null, "Tari Angguk sangat unik, gerakannya menggambarkan kebersamaan yang menyentuh hati.", "Joko Prasetyo", 4.7999999999999998, "SB001", null, null },
                    { 18, null, "Tari Angguk memberikan nuansa kebudayaan yang kental, sangat indah dan layak diapresiasi.", "Rina Sari", 4.7000000000000002, "SB001", null, null },
                    { 19, null, "Tari Bedhaya memberikan suasana yang damai dan khidmat, cocok untuk momen upacara besar.", "Agus Prabowo", 5.0, "SB002", null, null },
                    { 20, null, "Tari Bedhaya menunjukkan keanggunan yang luar biasa, sangat membanggakan budaya Yogyakarta.", "Dewi Lestari", 4.9000000000000004, "SB002", null, null },
                    { 21, null, "Tari Bedhaya sangat elegan, setiap gerakan sangat terkoordinasi dengan baik, membuat saya terpesona.", "Budi Santoso", 4.7999999999999998, "SB002", null, null },
                    { 22, null, "Tari Dolalak sangat menghibur dan penuh semangat. Tariannya sangat energik dan membangkitkan semangat juang.", "Maya Widya", 4.7000000000000002, "SB003", null, null },
                    { 23, null, "Tari Dolalak membawa energi yang luar biasa, sangat memotivasi dan memberikan kesan yang mendalam.", "Rudi Setiawan", 4.9000000000000004, "SB003", null, null },
                    { 24, null, "Tari Dolalak penuh dengan dinamika dan semangat yang sangat menular. Pertunjukan yang luar biasa!", "Lina Susanti", 4.7999999999999998, "SB003", null, null },
                    { 25, null, "Tari Gambyong mempesona dengan gerakan yang lembut dan sangat anggun. Saya sangat menikmati setiap detiknya.", "Eko Yulianto", 4.9000000000000004, "SB004", null, null },
                    { 26, null, "Tari Gambyong sangat memukau dengan keselarasan antara musik dan gerakan penarinya.", "Fanny Farida", 4.7999999999999998, "SB004", null, null },
                    { 27, null, "Tari Gambyong menunjukkan kebudayaan yang kaya akan nilai estetika, sangat mengagumkan!", "Rina Saraswati", 5.0, "SB004", null, null },
                    { 28, null, "Tari Kuda Lumping membawa suasana yang seru dan penuh semangat, sangat menghibur penonton.", "Mita Anggraini", 4.7000000000000002, "SB005", null, null },
                    { 29, null, "Tari Kuda Lumping sangat seru dengan gerakan yang energik dan membawa nuansa magis.", "Iwan Setiawan", 4.7999999999999998, "SB005", null, null },
                    { 30, null, "Tari Kuda Lumping memperlihatkan kekuatan dan keindahan gerakan yang sangat memikat.", "Siti Amalia", 4.9000000000000004, "SB005", null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Komentar",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "SeniBudaya",
                keyColumn: "Id",
                keyValue: "SB001");

            migrationBuilder.DeleteData(
                table: "SeniBudaya",
                keyColumn: "Id",
                keyValue: "SB002");

            migrationBuilder.DeleteData(
                table: "SeniBudaya",
                keyColumn: "Id",
                keyValue: "SB003");

            migrationBuilder.DeleteData(
                table: "SeniBudaya",
                keyColumn: "Id",
                keyValue: "SB004");

            migrationBuilder.DeleteData(
                table: "SeniBudaya",
                keyColumn: "Id",
                keyValue: "SB005");
        }
    }
}
