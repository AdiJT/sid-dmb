using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.MasterDataFunction.ModulPrima.KegiatanPrimas;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulPrima.KegiatanPrimas;

internal class RepositoriKegiatanPrima : IRepositoriKegiatanPrima
{
    private readonly AppDbContext _appDbContext;

    public RepositoriKegiatanPrima(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<KegiatanPrima?> Get(IdKegiatanPrima id) => await _appDbContext.KegiatanPrima
        .Include(k => k.KelompokPrima)
        .Include(k => k.DaftarKolabolator)
        .Include(k => k.DaftarKolaboratorKegiatan).ThenInclude(d => d.Entity2)
        .FirstOrDefaultAsync(k => k.Id == id);

    public async Task<List<KegiatanPrima>> GetAll() => await _appDbContext.KegiatanPrima
        .Include(k => k.KelompokPrima)
        .Include(k => k.DaftarKolabolator)
        .Include(k => k.DaftarKolaboratorKegiatan).ThenInclude(d => d.Entity2)
        .ToListAsync();
    
    public void Add(KegiatanPrima kegiatanPrima) => _appDbContext.KegiatanPrima.Add(kegiatanPrima);

    public void Update(KegiatanPrima kegiatanPrima) => _appDbContext.KegiatanPrima.Update(kegiatanPrima);

    public void Delete(KegiatanPrima kegiatanPrima) => _appDbContext.KegiatanPrima.Remove(kegiatanPrima);
}
