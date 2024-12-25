using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SeniBudayas;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulBudaya.SeniBudayas;

internal class SeniBudayaConfiguration : IEntityTypeConfiguration<SeniBudaya>
{
    public void Configure(EntityTypeBuilder<SeniBudaya> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdSeni.Create(s).Value);

        builder.HasMany(x => x.DaftarKomentar).WithOne(x => x.SeniBudaya);

        builder.HasData(
            new SeniBudaya
            {
                Id = IdSeni.Create("SB001").Value,
                Nama = "Tari Angguk",
                Dekripsi = "Tari Angguk adalah tarian tradisional khas Yogyakarta yang menggambarkan sukacita masyarakat dalam menyambut kedatangan tamu atau acara tertentu.",
                Kategori = KategoriSeni.Tari,
                NamaPelakuSeni = "Grup Seni Angguk Yogyakarta",
                LokasiPertunjukan = "Padepokan Seni Angguk, Yogyakarta",
                WaktuPertunjukan = "Sabtu, 19:00 - 21:00",
                FasilitasPertunjukan = [
                    "Panggung Utama",
                    "Tempat Duduk Penonton",
                    "Sistem Audio"
                ],
                DurasiPentunjukan = TimeSpan.FromHours(2),
                HargaTiket = 20000,
                PeraturanKhusus = "Dilarang merekam pertunjukan tanpa izin",
                MediaPromosi = new Uri("/assets/Seni_Budaya/Seni_Tari_Angguk.jpg", UriKind.Relative)
            },
            new SeniBudaya
            {
                Id = IdSeni.Create("SB002").Value,
                Nama = "Tari Bedhaya",
                Dekripsi = "Tari Bedhaya adalah tarian tradisional yang menggambarkan kedamaian dan kebesaran kerajaan, sering kali ditampilkan dalam upacara besar di istana.",
                Kategori = KategoriSeni.Tari,
                NamaPelakuSeni = "Grup Tari Bedhaya Yogyakarta",
                LokasiPertunjukan = "Keraton Yogyakarta",
                WaktuPertunjukan = "Minggu, 18:00 - 20:00",
                FasilitasPertunjukan = [
                    "Panggung Keraton",
                    "Tempat Duduk VIP",
                    "Sistem Pencahayaan"
                ],
                DurasiPentunjukan = TimeSpan.FromHours(1.5),
                HargaTiket = 50000,
                PeraturanKhusus = "Dilarang memakai pakaian sembarangan",
                MediaPromosi = new Uri("/assets/Seni_Budaya/Seni_Tari_Bedhaya.jpg", UriKind.Relative)
            },
            new SeniBudaya
            {
                Id = IdSeni.Create("SB003").Value,
                Nama = "Tari Dolalak",
                Dekripsi = "Tari Dolalak merupakan tarian rakyat yang menceritakan kisah perjuangan para pahlawan dan keperkasaan mereka dalam melawan penjajahan.",
                Kategori = KategoriSeni.Tari,
                NamaPelakuSeni = "Grup Seni Dolalak Yogyakarta",
                LokasiPertunjukan = "Alun-alun Yogyakarta",
                WaktuPertunjukan = "Jumat, 17:30 - 19:30",
                FasilitasPertunjukan = [
                    "Panggung Terbuka",
                    "Tempat Duduk Penonton",
                    "Sistem Suara"
                ],
                DurasiPentunjukan = TimeSpan.FromHours(2),
                HargaTiket = 15000,
                PeraturanKhusus = "Tidak boleh membawa makanan atau minuman",
                MediaPromosi = new Uri("/assets/Seni_Budaya/Seni_Tari_Dolalak.jpg", UriKind.Relative)
            },
            new SeniBudaya
            {
                Id = IdSeni.Create("SB004").Value,
                Nama = "Tari Gambyong",
                Dekripsi = "Tari Gambyong adalah tarian klasik dari Yogyakarta yang menggambarkan kelembutan dan keanggunan para wanita dalam kehidupan sehari-hari.",
                Kategori = KategoriSeni.Tari,
                NamaPelakuSeni = "Grup Tari Gambyong Yogyakarta",
                LokasiPertunjukan = "Taman Sari Yogyakarta",
                WaktuPertunjukan = "Sabtu, 20:00 - 22:00",
                FasilitasPertunjukan = [
                    "Panggung Tertutup",
                    "Kursi Penonton",
                    "Sistem Pencahayaan"
                ],
                DurasiPentunjukan = TimeSpan.FromHours(1.5),
                HargaTiket = 30000,
                PeraturanKhusus = "Silakan menggunakan pakaian formal untuk acara ini",
                MediaPromosi = new Uri("/assets/Seni_Budaya/Seni_Tari_Gambyong.jpg", UriKind.Relative)
            },
            new SeniBudaya
            {
                Id = IdSeni.Create("SB005").Value,
                Nama = "Tari Kuda Lumping",
                Dekripsi = "Tari Kuda Lumping adalah tarian tradisional yang menggambarkan keberanian dan semangat juang dengan unsur kesurupan dan tarian yang dinamis.",
                Kategori = KategoriSeni.Tari,
                NamaPelakuSeni = "Grup Seni Kuda Lumping Yogyakarta",
                LokasiPertunjukan = "Padepokan Kuda Lumping Yogyakarta",
                WaktuPertunjukan = "Minggu, 20:00 - 22:00",
                FasilitasPertunjukan = [
                    "Panggung Luar Ruangan",
                    "Area Penonton Terbuka",
                    "Tempat Ganti"
                ],
                DurasiPentunjukan = TimeSpan.FromHours(2),
                HargaTiket = 25000,
                PeraturanKhusus = "Pengunjung yang sensitif terhadap suara keras disarankan tidak hadir",
                MediaPromosi = new Uri("/assets/Seni_Budaya/Seni_Tari_Kuda_Lumping.jpg", UriKind.Relative)
            }
        );
    }
}