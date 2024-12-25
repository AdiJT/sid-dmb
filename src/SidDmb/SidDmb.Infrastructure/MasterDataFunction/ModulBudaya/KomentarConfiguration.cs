using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulBudaya;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.ArtefakBudayas;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SeniBudayas;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SitusBudayas;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulBudaya;

internal class KomentarConfiguration : IEntityTypeConfiguration<Komentar>
{
    public void Configure(EntityTypeBuilder<Komentar> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.ArtefakBudaya).WithMany(x => x.DaftarKomentar);
        builder.HasOne(x => x.UpacaraBudaya).WithMany(x => x.DaftarKomentar);
        builder.HasOne(x => x.SeniBudaya).WithMany(x => x.DaftarKomentar);
        builder.HasOne(x => x.SitusBudaya).WithMany(x => x.DaftarKomentar);

        builder.HasData(
            new
            {
                Id = 1,
                Nama = "Fernand Putra",
                Isi = "Batu Kenong memberikan gambaran menarik tentang budaya Hindu-Buddha di Kulon Progo.",
                Rating = 4.5d,
                ArtefakBudayaId = IdArtefak.Create("AR001").Value,
            },
            new
            {
                Id = 2,
                Nama = "Peneliti Sejarah",
                Isi = "Artefak ini sangat penting untuk penelitian tentang tradisi ritual masyarakat Jawa kuno.",
                Rating = 5.0d,
                ArtefakBudayaId = IdArtefak.Create("AR001").Value,
            },
            new
            {
                Id = 3,
                Nama = "Sejarawan Muda",
                Isi = "Dimensi Batu Kenong mencerminkan simbolisme dalam adat tradisional.",
                Rating = 4.7d,
                ArtefakBudayaId = IdArtefak.Create("AR001").Value,
            },
            new
            {
                Id = 4,
                Nama = "Pelajar Arkeologi",
                Isi = "Batu Prasasti Candi Ijo menyimpan banyak informasi berharga tentang sejarah Mataram.",
                Rating = 4.9d,
                ArtefakBudayaId = IdArtefak.Create("AR002").Value,
            },
            new
            {
                Id = 5,
                Nama = "Sejarawan Lokal",
                Isi = "Sebuah bukti kuat dari masa keemasan kerajaan Hindu di Jawa.",
                Rating = 5.0d,
                ArtefakBudayaId = IdArtefak.Create("AR002").Value,
            },
            new
            {
                Id = 6,
                Nama = "Pengunjung Museum",
                Isi = "Lokasi penyimpanan dan pelestarian prasasti ini sudah sangat baik.",
                Rating = 4.8d,
                ArtefakBudayaId = IdArtefak.Create("AR002").Value,
            },
            new
            {
                Id = 7,
                Nama = "Pecinta Seni",
                Isi = "Patung Ganesha ini sangat menarik dengan detail yang terjaga.",
                Rating = 4.6d,
                ArtefakBudayaId = IdArtefak.Create("AR003").Value,
            },
            new
            {
                Id = 8,
                Nama = "Peneliti Mitologi",
                Isi = "Representasi Ganesha di patung ini mencerminkan nilai budaya tinggi pada masa lalu.",
                Rating = 4.7d,
                ArtefakBudayaId = IdArtefak.Create("AR003").Value,
            },
            new
            {
                Id = 9,
                Nama = "Pengunjung Sambisari",
                Isi = "Patung ini menambah daya tarik sejarah kompleks Candi Sambisari.",
                Rating = 4.9d,
                ArtefakBudayaId = IdArtefak.Create("AR003").Value,
            },
            new
            {
                Id = 10,
                Nama = "Mahasiswa Sejarah",
                Isi = "Prasasti Kedu memberikan wawasan mendalam tentang administrasi Mataram.",
                Rating = 5.0d,
                ArtefakBudayaId = IdArtefak.Create("AR004").Value,
            },
            new
            {
                Id = 11,
                Nama = "Pengunjung Jawa Tengah",
                Isi = "Artefak ini sangat informatif untuk belajar tentang kerajaan Mataram.",
                Rating = 4.8d,
                ArtefakBudayaId = IdArtefak.Create("AR004").Value,
            },
            new
            {
                Id = 12,
                Nama = "Pecinta Sejarah",
                Isi = "Dimensi besar prasasti ini membuatnya menjadi pusat perhatian.",
                Rating = 4.7d,
                ArtefakBudayaId = IdArtefak.Create("AR004").Value,
            },
            new
            {
                Id = 13,
                Nama = "Sejarawan Desa",
                Isi = "Prasasti Munggur adalah saksi penting kehidupan masyarakat desa Gunungkidul.",
                Rating = 4.9d,
                ArtefakBudayaId = IdArtefak.Create("AR005").Value,
            },
            new
            {
                Id = 14,
                Nama = "Peneliti Bahasa Kuno",
                Isi = "Tulisan di prasasti ini memberikan gambaran tentang tata bahasa masa lalu.",
                Rating = 5.0d,
                ArtefakBudayaId = IdArtefak.Create("AR005").Value,
            },
            new
            {
                Id = 15,
                Nama = "Pengunjung Gunungkidul",
                Isi = "Prasasti ini adalah salah satu peninggalan budaya paling menarik di wilayah ini.",
                Rating = 4.8d,
                ArtefakBudayaId = IdArtefak.Create("AR005").Value,
            },
            new
            {
                Id = 16,
                Nama = "Siti Aisyah",
                Isi = "Tari Angguk sangat memukau dengan energinya yang menghidupkan suasana. Saya berharap dapat melihatnya lagi.",
                Rating = 4.9d,
                SeniBudayaId = IdSeni.Create("SB001").Value
            },
            new
            {
                Id = 17,
                Nama = "Joko Prasetyo",
                Isi = "Tari Angguk sangat unik, gerakannya menggambarkan kebersamaan yang menyentuh hati.",
                Rating = 4.8d,
                SeniBudayaId = IdSeni.Create("SB001").Value
            },
            new
            {
                Id = 18,
                Nama = "Rina Sari",
                Isi = "Tari Angguk memberikan nuansa kebudayaan yang kental, sangat indah dan layak diapresiasi.",
                Rating = 4.7d,
                SeniBudayaId = IdSeni.Create("SB001").Value
            },
            new
            {
                Id = 19,
                Nama = "Agus Prabowo",
                Isi = "Tari Bedhaya memberikan suasana yang damai dan khidmat, cocok untuk momen upacara besar.",
                Rating = 5.0d,
                SeniBudayaId = IdSeni.Create("SB002").Value
            },
            new
            {
                Id = 20,
                Nama = "Dewi Lestari",
                Isi = "Tari Bedhaya menunjukkan keanggunan yang luar biasa, sangat membanggakan budaya Yogyakarta.",
                Rating = 4.9d,
                SeniBudayaId = IdSeni.Create("SB002").Value
            },
            new
            {
                Id = 21,
                Nama = "Budi Santoso",
                Isi = "Tari Bedhaya sangat elegan, setiap gerakan sangat terkoordinasi dengan baik, membuat saya terpesona.",
                Rating = 4.8d,
                SeniBudayaId = IdSeni.Create("SB002").Value
            },
            new
            {
                Id = 22,
                Nama = "Maya Widya",
                Isi = "Tari Dolalak sangat menghibur dan penuh semangat. Tariannya sangat energik dan membangkitkan semangat juang.",
                Rating = 4.7d,
                SeniBudayaId = IdSeni.Create("SB003").Value
            },
            new
            {
                Id = 23,
                Nama = "Rudi Setiawan",
                Isi = "Tari Dolalak membawa energi yang luar biasa, sangat memotivasi dan memberikan kesan yang mendalam.",
                Rating = 4.9d,
                SeniBudayaId = IdSeni.Create("SB003").Value
            },
            new
            {
                Id = 24,
                Nama = "Lina Susanti",
                Isi = "Tari Dolalak penuh dengan dinamika dan semangat yang sangat menular. Pertunjukan yang luar biasa!",
                Rating = 4.8d,
                SeniBudayaId = IdSeni.Create("SB003").Value
            },
            new
            {
                Id = 25,
                Nama = "Eko Yulianto",
                Isi = "Tari Gambyong mempesona dengan gerakan yang lembut dan sangat anggun. Saya sangat menikmati setiap detiknya.",
                Rating = 4.9d,
                SeniBudayaId = IdSeni.Create("SB004").Value
            },
            new
            {
                Id = 26,
                Nama = "Fanny Farida",
                Isi = "Tari Gambyong sangat memukau dengan keselarasan antara musik dan gerakan penarinya.",
                Rating = 4.8d,
                SeniBudayaId = IdSeni.Create("SB004").Value
            },
            new
            {
                Id = 27,
                Nama = "Rina Saraswati",
                Isi = "Tari Gambyong menunjukkan kebudayaan yang kaya akan nilai estetika, sangat mengagumkan!",
                Rating = 5.0d,
                SeniBudayaId = IdSeni.Create("SB004").Value
            },
            new
            {
                Id = 28,
                Nama = "Mita Anggraini",
                Isi = "Tari Kuda Lumping membawa suasana yang seru dan penuh semangat, sangat menghibur penonton.",
                Rating = 4.7d,
                SeniBudayaId = IdSeni.Create("SB005").Value
            },
            new
            {
                Id = 29,
                Nama = "Iwan Setiawan",
                Isi = "Tari Kuda Lumping sangat seru dengan gerakan yang energik dan membawa nuansa magis.",
                Rating = 4.8d,
                SeniBudayaId = IdSeni.Create("SB005").Value
            },
            new
            {
                Id = 30,
                Nama = "Siti Amalia",
                Isi = "Tari Kuda Lumping memperlihatkan kekuatan dan keindahan gerakan yang sangat memikat.",
                Rating = 4.9d,
                SeniBudayaId = IdSeni.Create("SB005").Value
            },
            new
            {
                Id = 31,
                Nama = "Budi Santoso",
                Isi = "Candi Sambisari adalah situs yang sangat memukau dan penuh sejarah. Saya sangat menghargai upaya pelestariannya.",
                Rating = 5.0d,
                SitusBudayaId = IdSitus.Create("SB001").Value
            },
            new
            {
                Id = 32,
                Nama = "Dewi Lestari",
                Isi = "Gua Maria Tritis memberikan pengalaman spiritual yang mendalam, pemandangan alamnya juga luar biasa.",
                Rating = 4.8d,
                SitusBudayaId = IdSitus.Create("SB002").Value
            },
            new
            {
                Id = 33,
                Nama = "Rina Sari",
                Isi = "Gua Rancang Kencono menawarkan pengalaman petualangan yang luar biasa. Formasi gua sangat indah dan mempesona.",
                Rating = 4.9d,
                SitusBudayaId = IdSitus.Create("SB003").Value
            },
            new
            {
                Id = 34,
                Nama = "Eko Yulianto",
                Isi = "Situs Gunung Wukir adalah situs yang sangat kaya akan nilai sejarah. Keindahan alamnya juga tidak kalah menarik.",
                Rating = 4.9d,
                SitusBudayaId = IdSitus.Create("SB004").Value
            },
            new
            {
                Id = 35,
                Nama = "Maya Widya",
                Isi = "Situs Mangir memberikan wawasan baru tentang kerajaan Mataram Kuno, sangat mendalam dan penuh informasi.",
                Rating = 4.7d,
                SitusBudayaId = IdSitus.Create("SB005").Value
            },
            new
            {
                Id = 36,
                Nama = "Andi Wijaya",
                Isi = "Candi Sambisari adalah tempat yang sangat mengesankan. Saya menikmati setiap detil arsitekturnya.",
                Rating = 4.8d,
                SitusBudayaId = IdSitus.Create("SB001").Value
            },
            new
            {
                Id = 37,
                Nama = "Siti Khadijah",
                Isi = "Gua Maria Tritis sangat tenang dan damai. Tempat yang cocok untuk merenung dan berdoa.",
                Rating = 5.0d,
                SitusBudayaId = IdSitus.Create("SB002").Value
            },
            new
            {
                Id = 38,
                Nama = "Haris Setiawan",
                Isi = "Gua Rancang Kencono sangat menantang. Pemandangannya menakjubkan dan cocok bagi pecinta alam.",
                Rating = 4.6d,
                SitusBudayaId = IdSitus.Create("SB003").Value
            },
            new
            {
                Id = 39,
                Nama = "Lina Hartini",
                Isi = "Situs Gunung Wukir memberikan nuansa sejarah yang kuat, tempat yang sangat bersejarah dan penuh nilai budaya.",
                Rating = 4.9d,
                SitusBudayaId = IdSitus.Create("SB004").Value
            },
            new
            {
                Id = 40,
                Nama = "Anton Dwi",
                Isi = "Situs Mangir benar-benar menarik, ada banyak cerita yang bisa dipelajari dari sini.",
                Rating = 4.7d,
                SitusBudayaId = IdSitus.Create("SB005").Value
            },
            new
            {
                Id = 41,
                Nama = "Rudi Hartono",
                Isi = "Saya sangat menikmati kunjungan saya ke Candi Sambisari. Tempat yang sangat historis dan penuh pesona.",
                Rating = 5.0d,
                SitusBudayaId = IdSitus.Create("SB001").Value
            },
            new
            {
                Id = 42,
                Nama = "Indah Sari",
                Isi = "Gua Maria Tritis adalah tempat yang sangat spiritual. Sangat menenangkan untuk berdoa di sana.",
                Rating = 5.0d,
                SitusBudayaId = IdSitus.Create("SB002").Value
            },
            new
            {
                Id = 43,
                Nama = "Joko Prasetyo",
                Isi = "Gua Rancang Kencono adalah tempat yang cocok untuk berpetualang. Keindahan gua dan alamnya luar biasa.",
                Rating = 4.7d,
                SitusBudayaId = IdSitus.Create("SB003").Value
            },
            new
            {
                Id = 44,
                Nama = "Eka Rizki",
                Isi = "Situs Gunung Wukir penuh dengan keindahan alam dan sejarah. Benar-benar menarik untuk dipelajari.",
                Rating = 4.8d,
                SitusBudayaId = IdSitus.Create("SB004").Value
            },
            new
            {
                Id = 45,
                Nama = "Nina Ayu",
                Isi = "Situs Mangir adalah destinasi yang harus dikunjungi bagi penggemar sejarah. Banyak hal yang bisa dipelajari di sini.",
                Rating = 4.9d,
                SitusBudayaId = IdSitus.Create("SB005").Value
            }
        );
    }
}