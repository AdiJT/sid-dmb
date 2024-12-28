using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PelaporanDanDokumentasi;
using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;

internal class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(x => x.Value, s => IdEvent.Create(s).Value);
        builder.Property(x => x.TanggalWaktu).HasColumnType("timestamp without time zone");

        builder.HasOne(x => x.LaporanEvent).WithOne(x => x.Event).HasForeignKey<LaporanEvent>("EventId");

        builder.HasMany(x => x.DaftarKolaborator).WithMany(x => x.DaftarEvent).UsingEntity<KolaboratorEvent>(
            l => l.HasOne(x => x.Entity2).WithMany(x => x.DaftarKolaboratorEvent).HasForeignKey(x => x.Entity2Id),
            r => r.HasOne(x => x.Entity1).WithMany(x => x.DaftarKolaboratorEvent).HasForeignKey(x => x.Entity1Id));

        builder.HasData(
            new Event
            {
                Id = IdEvent.Create("EV001").Value,
                Nama = "Festival Seni dan Budaya Gilang",
                Dekripsi = "Festival tahunan yang menampilkan seni tari dan musik tradisional.",
                Kategori = KategoriEvent.Budaya,
                TanggalWaktu = new DateTime(2024, 12, 20),
                Lokasi = "Balai Desa Gilangharjo",
                Penyelenggara = "Pokdarwis Desa Gilangharjo",
                KontakInformasi = "+62 813-4567-8910",
                TargetPeserta = TargetPeserta.Umum,
                JumlahPesertaMaksimal = 150,
                StatusPendaftaran = StatusPendaftaran.Buka,
                Sponsor = "Bank Gilang, Warung Gilang Sejahtera",
                Anggaran = 12_000_000d,
                MediaPromosi = new Uri("/assets/event2-test.png", UriKind.Relative),
            }    
        );
    }
}