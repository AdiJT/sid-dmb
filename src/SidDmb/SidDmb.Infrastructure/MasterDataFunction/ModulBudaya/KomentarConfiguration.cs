using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulBudaya;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.ArtefakBudayas;

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
            }
        );
    }
}