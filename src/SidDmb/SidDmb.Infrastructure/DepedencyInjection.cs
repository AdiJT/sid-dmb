using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SidDmb.Domain.Abstracts;
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
        services.AddScoped<IRepositoriFasilitas, RepositoriFasilitas>();
        services.AddScoped<IRepositoriArtefakBudaya, RepositoriArtefakBudaya>();
        services.AddScoped<IRepositoriSeniBudaya, RepositoriSeniBudaya>();
        services.AddScoped<IRepositoriSitusBudaya, RepositorSitusBudaya>();
        services.AddScoped<IRepositoriUpacaraBudaya, RepositoriUpacaBudaya>();
        services.AddScoped<IRepositoriProdukLokal, RepositoriProdukLokal>();
        services.AddScoped<IRepositoriUnitUsaha, RepositoriUnitUsaha>();
        services.AddScoped<IRepositoriKegiatanPrima, RepositoriKegiatanPrima>();
        services.AddScoped<IRepositoriKolaboratorKegiatanPrima, RepositoriKolaboratorKegiatanPrima>();
        services.AddScoped<IRepositoriKelompokPrima, RepositoriKelompokPrima>();
        services.AddScoped<IRepositoriDestinasiWisata, RepositoriDestinasiWisata>();
        services.AddScoped<IRepositoriAktivitasDestinasiWisata, RepositoriAktivitasDestinasiWisata>();
        services.AddScoped<IRepositoriFasilitasDestinasiWisata, RepositoriFasilitasDestinasiWisata>();
        services.AddScoped<IRepositoriKalenderAcara, RepositoriKalenderAcara>();
        services.AddScoped<IRepositoriLaporanKunjungan, RepositoriLaporanKunjungan>();

        return services;
    }
}
