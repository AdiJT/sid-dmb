using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.MasterDataFunction.ModulPrima.KelompokPrimas;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulPrima.KelompokPrimas;

internal class RepositoriKelompokPrima : IRepositoriKelompokPrima
{
    private readonly AppDbContext _appDbContext;

    public RepositoriKelompokPrima(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<KelompokPrima?> Get(IdKelompok id) => await _appDbContext.KelompokPrima
        .Include(k => k.DaftarKegiatanPrima).ThenInclude(x => x.DaftarKolaboratorKegiatan)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<KelompokPrima>> GetAll() => await _appDbContext.KelompokPrima
        .Include(k => k.DaftarKegiatanPrima).ThenInclude(x => x.DaftarKolaboratorKegiatan)
        .ToListAsync();

    public void Add(KelompokPrima kelompokPrima) => _appDbContext.KelompokPrima.Add(kelompokPrima);

    public void Update(KelompokPrima kelompokPrima) => _appDbContext.KelompokPrima.Update(kelompokPrima);

    public void Delete(KelompokPrima kelompokPrima) => _appDbContext.KelompokPrima.Remove(kelompokPrima);
}