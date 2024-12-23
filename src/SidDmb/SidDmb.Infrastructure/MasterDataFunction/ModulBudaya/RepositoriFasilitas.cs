using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.MasterDataFunction.ModulBudaya;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulBudaya;

internal class RepositoriFasilitas : IRepositoriFasilitas
{
    private readonly AppDbContext _appDbContext;

    public RepositoriFasilitas(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Fasilitas?> Get(int id) => await _appDbContext.Fasilitas
        .Include(f => f.DaftarSitusBudaya)
        .Include(f => f.DaftarUpacaraBudaya)
        .Include(f => f.DaftarSeniBudaya)
        .FirstOrDefaultAsync(f => f.Id == id);

    public async Task<List<Fasilitas>> GetAll() => await _appDbContext.Fasilitas
        .Include(f => f.DaftarSitusBudaya)
        .Include(f => f.DaftarUpacaraBudaya)
        .Include(f => f.DaftarSeniBudaya)
        .ToListAsync();

    public void Add(Fasilitas fasilitas) => _appDbContext.Fasilitas.Add(fasilitas);
    
    public void Update(Fasilitas fasilitas) => _appDbContext.Fasilitas.Update(fasilitas);

    public void Delete(Fasilitas fasilitas) => _appDbContext.Fasilitas.Remove(fasilitas);
}
