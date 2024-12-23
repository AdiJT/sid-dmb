using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.MasterDataFunction.ModulPreneur.ProdukLokals;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulPrenuer.ProdukLokals;

internal class RepositoriProdukLokal : IRepositoriProdukLokal
{
    private readonly AppDbContext _appDbContext;

    public RepositoriProdukLokal(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<ProdukLokal?> Get(IdProduk id) => await _appDbContext.ProdukLokal
        .Include(p => p.UnitUsaha)
        .FirstOrDefaultAsync(p => p.Id == id);

    public async Task<List<ProdukLokal>> GetAll() => await _appDbContext.ProdukLokal
        .Include(p => p.UnitUsaha)
        .ToListAsync();

    public void Add(ProdukLokal produkLokal) => _appDbContext.ProdukLokal.Add(produkLokal);

    public void Update(ProdukLokal produkLokal) => _appDbContext.ProdukLokal.Update(produkLokal);

    public void Delete(ProdukLokal produkLokal) => _appDbContext.ProdukLokal.Remove (produkLokal);
}