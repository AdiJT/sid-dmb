using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.MasterDataFunction.ModulBudaya;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulBudaya;

internal class RepositoriKomentar : IRepositoriKomentar
{
    private readonly AppDbContext _appDbContext;

    public RepositoriKomentar(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Komentar?> Get(int id) => await _appDbContext.Komentar
        .Include(x => x.SeniBudaya)
        .Include(x => x.UpacaraBudaya)
        .Include(x => x.SitusBudaya)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<Komentar>> GetAll() => await _appDbContext.Komentar
        .Include(x => x.SeniBudaya)
        .Include(x => x.UpacaraBudaya)
        .Include(x => x.SitusBudaya)
        .ToListAsync();

    public void Add(Komentar komentar) => _appDbContext.Komentar.Add(komentar);

    public void Update(Komentar komentar) => _appDbContext.Komentar.Update(komentar);

    public void Delete(Komentar komentar) => _appDbContext.Komentar.Remove(komentar);
}
