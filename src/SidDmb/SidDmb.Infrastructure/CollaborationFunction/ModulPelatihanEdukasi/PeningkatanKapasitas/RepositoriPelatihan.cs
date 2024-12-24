using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.PeningkatanKapasitas;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulPelatihanEdukasi.PeningkatanKapasitas;

internal class RepositoriPelatihan : IRepositoriPelatihan
{
    private readonly AppDbContext _appDbContext;

    public RepositoriPelatihan(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Pelatihan?> Get(IdPelatihan id) => await _appDbContext.Pelatihan
        .Include(x => x.DaftarKolaborator)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<Pelatihan>> GetAll() => await _appDbContext.Pelatihan
        .Include(x => x.DaftarKolaborator)
        .ToListAsync();

    public void Add(Pelatihan Pelatihan) => _appDbContext.Pelatihan.Add(Pelatihan);

    public void Delete(Pelatihan Pelatihan) => _appDbContext.Pelatihan.Update(Pelatihan);

    public void Update(Pelatihan Pelatihan) => _appDbContext.Pelatihan.Remove(Pelatihan);
}