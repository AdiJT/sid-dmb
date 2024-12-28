using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.CollaborationFunction;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.CollaborationFunction;

internal class RepositoriKolaborator : IRepositoriKolaborator
{
    private readonly AppDbContext _appDbContext;

    public RepositoriKolaborator(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Kolaborator?> Get(int id) => await _appDbContext.Kolaborator
        .Include(x => x.DaftarMateri)
        .Include(x => x.DaftarDistribusi)
        .Include(x => x.DaftarDataRiset)
        .Include(x => x.DaftarEvent)
        .Include(x => x.DaftarPelatihan)
        .Include(x => x.DaftarProduk)
        .Include(x => x.DaftarRekomendasi)
        .Include(x => x.DaftarSertifikasi)
        .Include(x => x.DaftarKolaboratorKegiatanPrima).ThenInclude(k => k.Entity1)
        .Include(x => x.DaftarKolaboratorEvent).ThenInclude(k => k.Entity1)
        .Include(x => x.DaftarKolaboratorMateri).ThenInclude(k => k.Entity1)
        .Include(x => x.DaftarKolaboratorPelatihan).ThenInclude(k => k.Entity1)
        .Include(x => x.AppUser)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<Kolaborator>> GetAll() => await _appDbContext.Kolaborator
        .Include(x => x.DaftarMateri)
        .Include(x => x.DaftarDistribusi)
        .Include(x => x.DaftarDataRiset)
        .Include(x => x.DaftarEvent)
        .Include(x => x.DaftarPelatihan)
        .Include(x => x.DaftarProduk)
        .Include(x => x.DaftarRekomendasi)
        .Include(x => x.DaftarSertifikasi)
        .Include(x => x.DaftarKolaboratorKegiatanPrima).ThenInclude(k => k.Entity1)
        .Include(x => x.DaftarKolaboratorEvent).ThenInclude(k => k.Entity1)
        .Include(x => x.DaftarKolaboratorPelatihan).ThenInclude(k => k.Entity1)
        .Include(x => x.AppUser)
        .ToListAsync();

    public void Add(Kolaborator kolaborator) => _appDbContext.Kolaborator.Add(kolaborator);

    public void Update(Kolaborator kolaborator) => _appDbContext.Kolaborator.Update(kolaborator);

    public void Delete(Kolaborator kolaborator) => _appDbContext.Kolaborator.Remove(kolaborator);
}