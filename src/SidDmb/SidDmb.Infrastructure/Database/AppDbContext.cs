using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Authentication;
using SidDmb.Domain.CollaborationFunction;
using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PelaporanDanDokumentasi;
using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;
using SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasiDanPembelajaran;
using SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.PeningkatanKapasitas;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenDistribusi;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;
using SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;
using SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.RekomendasiDanPengembanganProduk;
using SidDmb.Domain.MasterDataFunction.ModulBudaya;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.ArtefakBudayas;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SeniBudayas;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SitusBudayas;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.UpacaraBudayas;
using SidDmb.Domain.MasterDataFunction.ModulPreneur.ProdukLokals;
using SidDmb.Domain.MasterDataFunction.ModulPreneur.UnitUsahas;
using SidDmb.Domain.MasterDataFunction.ModulPrima.KegiatanPrimas;
using SidDmb.Domain.MasterDataFunction.ModulPrima.KelompokPrimas;
using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;
using SidDmb.Domain.MasterDataFunction.ModulWisata.KalenderAcaras;
using SidDmb.Domain.MasterDataFunction.ModulWisata.LaporanKunjungans;

namespace SidDmb.Infrastructure.Database;

internal class AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("postgis");

        foreach (var entityType in modelBuilder.Model.GetEntityTypes().ToList())
        {
            if (typeof(IAuditableEntity).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType).Property(nameof(IAuditableEntity.TanggalDiinputkan))
                    .HasColumnType("timestamp without time zone");
                modelBuilder.Entity(entityType.ClrType).Property(nameof(IAuditableEntity.TanggalPembaruanData))
                    .HasColumnType("timestamp without time zone");
            }
        }

        modelBuilder.ApplyConfigurationsFromAssembly(AssemblyReference.Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<AppUser> AppUser { get; set; }

    #region ModulWisata
    public DbSet<DestinasiWisata> DestinasiWisata { get; set; }
    public DbSet<KalenderAcara> KalenderAcara { get; set; }
    public DbSet<LaporanKunjungan> LaporanKunjungan { get; set; }
    #endregion

    #region Budaya
    public DbSet<Komentar> Komentar { get; set; }
    public DbSet<ArtefakBudaya> ArtefakBudaya { get; set; }
    public DbSet<SeniBudaya> SeniBudaya { get; set; }
    public DbSet<SitusBudaya> SitusBudaya { get; set; }
    public DbSet<UpacaraBudaya> UpacaraBudaya { get; set; }
    #endregion

    #region Prenuer
    public DbSet<UnitUsaha> UnitUsaha { get; set; }
    public DbSet<ProdukLokal> ProdukLokal { get; set; }
    #endregion

    #region Prima
    public DbSet<KelompokPrima> KelompokPrima { get; set; }
    public DbSet<KegiatanPrima> KegiatanPrima { get; set; }
    public DbSet<KolaboratorKegiatanPrima> KolaboratorKegiatanPrima { get; set; }
    #endregion

    public DbSet<Kolaborator> Kolaborator { get; set; }

    #region ManajemenEvent
    public DbSet<Event> Event { get; set; }
    public DbSet<KolaboratorEvent> KolaboratorEvent { get; set; }
    public DbSet<LaporanEvent> LaporanEvent { get; set; }
    #endregion

    #region ModulEdukasiDanPembelajaran
    public DbSet<Materi> Materi { get; set; }
    public DbSet<Pelatihan> Pelatihan { get; set; }
    #endregion

    #region ModulProdukDanInventory
    public DbSet<Produk> Produk { get; set; }
    public DbSet<Distribusi> Distribusi { get; set; }
    public DbSet<Sertifikasi> Sertifikasi { get; set; }
    #endregion

    #region ModulResearchAndDevelopment
    public DbSet<DataRiset> DataRiset { get; set; }
    public DbSet<Rekomendasi> Rekomendasi { get; set; }
    #endregion
}