using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
using SidDmb.Infrastructure.Authentication;
using SidDmb.Infrastructure.CollaborationFunction;
using SidDmb.Infrastructure.CollaborationFunction.ModulManajemenEvent.PelaporanDanDokumentasi;
using SidDmb.Infrastructure.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;
using SidDmb.Infrastructure.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasiDanPembelajaran;
using SidDmb.Infrastructure.CollaborationFunction.ModulPelatihanEdukasi.PeningkatanKapasitas;
using SidDmb.Infrastructure.CollaborationFunction.ModulProdukDanInventory.ManajemenDistribusi;
using SidDmb.Infrastructure.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;
using SidDmb.Infrastructure.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;
using SidDmb.Infrastructure.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;
using SidDmb.Infrastructure.CollaborationFunction.ModulResearchAndDevelopment.RekomendasiDanPengembanganProduk;
using SidDmb.Infrastructure.Database;
using SidDmb.Infrastructure.MasterDataFunction.ModulBudaya;
using SidDmb.Infrastructure.MasterDataFunction.ModulBudaya.ArtefakBudayas;
using SidDmb.Infrastructure.MasterDataFunction.ModulBudaya.SeniBudayas;
using SidDmb.Infrastructure.MasterDataFunction.ModulBudaya.SitusBudayas;
using SidDmb.Infrastructure.MasterDataFunction.ModulBudaya.UpacaraBudayas;
using SidDmb.Infrastructure.MasterDataFunction.ModulPrenuer.ProdukLokals;
using SidDmb.Infrastructure.MasterDataFunction.ModulPrenuer.UnitUsahas;
using SidDmb.Infrastructure.MasterDataFunction.ModulPrima.KegiatanPrimas;
using SidDmb.Infrastructure.MasterDataFunction.ModulPrima.KelompokPrimas;
using SidDmb.Infrastructure.MasterDataFunction.ModulWisata.DestinasiWisatas;
using SidDmb.Infrastructure.MasterDataFunction.ModulWisata.KalenderAcaras;
using SidDmb.Infrastructure.MasterDataFunction.ModulWisata.LaporanKunjungans;

namespace SidDmb.Infrastructure;

public static class DepedencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default") ?? throw new NullReferenceException("connection string 'default' is null");

        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
            connectionString,
            o => o.UseNetTopologySuite()).EnableSensitiveDataLogging());

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IRepositoriAppUser, RepositoriAppUser>();
        services.AddScoped<IRepositoriKomentar, RepositoriKomentar>();
        services.AddScoped<IRepositoriArtefakBudaya, RepositoriArtefakBudaya>();
        services.AddScoped<IRepositoriSeniBudaya, RepositoriSeniBudaya>();
        services.AddScoped<IRepositoriSitusBudaya, RepositorSitusBudaya>();
        services.AddScoped<IRepositoriUpacaraBudaya, RepositoriUpacaBudaya>();
        services.AddScoped<IRepositoriProdukLokal, RepositoriProdukLokal>();
        services.AddScoped<IRepositoriUnitUsaha, RepositoriUnitUsaha>();
        services.AddScoped<IRepositoriKegiatanPrima, RepositoriKegiatanPrima>();
        services.AddScoped<IRepositoriKelompokPrima, RepositoriKelompokPrima>();
        services.AddScoped<IRepositoriDestinasiWisata, RepositoriDestinasiWisata>();
        services.AddScoped<IRepositoriKalenderAcara, RepositoriKalenderAcara>();
        services.AddScoped<IRepositoriLaporanKunjungan, RepositoriLaporanKunjungan>();
        services.AddScoped<IRepositoriKolaborator, RepositoriKolaborator>();
        services.AddScoped<IRepostoriLaporanEvent, RepositoriLaporanEvent>();
        services.AddScoped<IRepostoriEvent, RepositoriEvent>();
        services.AddScoped<IRepositoriMateri, RepositoriMateri>();
        services.AddScoped<IRepositoriPelatihan, RepositoriPelatihan>();
        services.AddScoped<IRepositoriDistribusi, RepositoriDistribusi>();
        services.AddScoped<IRepositoriProduk, RepositoriProduk>();
        services.AddScoped<IRepositoriSertifikasi, RepositoriSertifikasi>();
        services.AddScoped<IRepositoriDataRiset, RepositoriDataRiset>();
        services.AddScoped<IRepositoriRekomendasi, RepositoriRekomendasi>();

        return services;
    }
}
