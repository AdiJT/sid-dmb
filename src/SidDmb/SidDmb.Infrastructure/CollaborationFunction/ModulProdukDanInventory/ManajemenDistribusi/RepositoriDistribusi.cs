using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenDistribusi;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulProdukDanInventory.ManajemenDistribusi;

internal class RepositoriDistribusi : IRepositoriDistribusi
{
    private readonly AppDbContext _appDbContext;

    public RepositoriDistribusi(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Distribusi?> Get(IdDistribusi id) => await _appDbContext.Distribusi
        .Include(d => d.Produk).ThenInclude(p => p.DaftarKolaborator)
        .Include(d => d.DaftarKolaborator)
        .FirstOrDefaultAsync(d => d.Id == id);

    public async Task<List<Distribusi>> GetAll() => await _appDbContext.Distribusi
        .Include(d => d.Produk).ThenInclude(p => p.DaftarKolaborator)
        .Include(d => d.DaftarKolaborator)
        .ToListAsync();

    public void Add(Distribusi distribusi) => _appDbContext.Distribusi.Add(distribusi);

    public void Update(Distribusi distribusi) => _appDbContext.Distribusi.Update(distribusi);

    public void Delete(Distribusi distribusi) => _appDbContext.Distribusi.Remove(distribusi);
}