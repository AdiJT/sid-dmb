using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.ArtefakBudayas;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulBudaya.ArtefakBudayas;

internal class RepositoriArtefakBudaya : IRepositoriArtefakBudaya
{
    private readonly AppDbContext _appDbContext;

    public RepositoriArtefakBudaya(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<ArtefakBudaya?> Get(IdArtefak id) => await _appDbContext.ArtefakBudaya
        .Include(x => x.DaftarKomentar)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<ArtefakBudaya>> GetAll() => await _appDbContext.ArtefakBudaya
        .Include(x => x.DaftarKomentar)
        .ToListAsync();

    public void Add(ArtefakBudaya artefakBudaya) => _appDbContext.ArtefakBudaya.Add(artefakBudaya);

    public void Update(ArtefakBudaya artefakBudaya) => _appDbContext.ArtefakBudaya.Update(artefakBudaya);

    public void Delete(ArtefakBudaya artefakBudaya) => _appDbContext.ArtefakBudaya.Remove(artefakBudaya);
}