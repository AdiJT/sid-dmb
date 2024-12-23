using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.MasterDataFunction.ModulPreneur.UnitUsahas;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulPrenuer.UnitUsahas;

internal class RepositoriUnitUsaha : IRepositoriUnitUsaha
{
    private readonly AppDbContext _appDbContext;

    public RepositoriUnitUsaha(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<UnitUsaha?> Get(IdUnitUsaha id) => await _appDbContext.UnitUsaha
        .Include(u => u.DaftarProduk)
        .FirstOrDefaultAsync(u => u.Id == id);

    public async Task<List<UnitUsaha>> GetAll() => await _appDbContext.UnitUsaha
        .Include(u => u.DaftarProduk)
        .ToListAsync();

    public void Add(UnitUsaha unitUsaha) => _appDbContext.UnitUsaha.Add(unitUsaha);

    public void Update(UnitUsaha unitUsaha) => _appDbContext.UnitUsaha.Update(unitUsaha);

    public void Delete(UnitUsaha unitUsaha) => _appDbContext.UnitUsaha.Remove(unitUsaha);
}