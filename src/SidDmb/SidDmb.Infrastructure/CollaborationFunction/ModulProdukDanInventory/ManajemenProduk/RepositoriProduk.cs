using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;

internal class RepositoriProduk : IRepositoriProduk
{
    private readonly AppDbContext _appDbContext;

    public RepositoriProduk(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Produk?> Get(IdProduk id) => await _appDbContext.Produk
        .Include(p => p.DaftarDistribusi).ThenInclude(d => d.DaftarKolaborator)
        .Include(p => p.DaftarSertifikasi).ThenInclude(x => x.DaftarKolaborator)
        .Include(p => p.DaftarKolaborator)
        .FirstOrDefaultAsync(p => p.Id == id);

    public async Task<List<Produk>> GetAll() => await _appDbContext.Produk
        .Include(p => p.DaftarDistribusi).ThenInclude(d => d.DaftarKolaborator)
        .Include(p => p.DaftarSertifikasi).ThenInclude(x => x.DaftarKolaborator)
        .Include(p => p.DaftarKolaborator)
        .ToListAsync();

    public void Add(Produk produk) => _appDbContext.Produk.Add(produk);

    public void Update(Produk produk) => _appDbContext.Produk.Update(produk);

    public void Delete(Produk produk) => _appDbContext.Produk.Remove(produk);
}