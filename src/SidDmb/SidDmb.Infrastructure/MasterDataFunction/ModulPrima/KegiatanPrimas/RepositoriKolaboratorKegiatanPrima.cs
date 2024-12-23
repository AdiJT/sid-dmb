using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.MasterDataFunction.ModulPrima.KegiatanPrimas;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulPrima.KegiatanPrimas;

internal class RepositoriKolaboratorKegiatanPrima : IRepositoriKolaboratorKegiatanPrima
{
    private readonly AppDbContext _appDbContext;

    public RepositoriKolaboratorKegiatanPrima(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<KolaboratorKegiatanPrima?> Get(int id) => await _appDbContext.KolaboratorKegiatanPrima
        .Include(x => x.DaftarKegiatanPrima)
        .FirstOrDefaultAsync(k => k.Id == id);

    public async Task<List<KolaboratorKegiatanPrima>> GetAll() => await _appDbContext.KolaboratorKegiatanPrima
        .Include(x => x.DaftarKegiatanPrima)
        .ToListAsync();

    public void Add(KolaboratorKegiatanPrima kolaboratorKegiatanPrima) => _appDbContext.KolaboratorKegiatanPrima.Add(kolaboratorKegiatanPrima);

    public void Update(KolaboratorKegiatanPrima kolaboratorKegiatanPrima) => _appDbContext.KolaboratorKegiatanPrima.Update(kolaboratorKegiatanPrima);

    public void Delete(KolaboratorKegiatanPrima kolaboratorKegiatanPrima) => _appDbContext.KolaboratorKegiatanPrima.Remove(kolaboratorKegiatanPrima);
}