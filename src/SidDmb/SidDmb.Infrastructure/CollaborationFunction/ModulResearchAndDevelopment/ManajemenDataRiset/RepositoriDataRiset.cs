using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;

internal class RepositoriDataRiset : IRepositoriDataRiset
{
    private readonly AppDbContext _appDbContext;

    public RepositoriDataRiset(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<DataRiset?> Get(IdDataRiset id) => await _appDbContext.DataRiset
        .Include(x => x.DaftarKolaboratorPenelitian)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<DataRiset>> GetAll() => await _appDbContext.DataRiset
        .Include(x => x.DaftarKolaboratorPenelitian)
        .ToListAsync();

    public void Add(DataRiset dataRiset) => _appDbContext.DataRiset.Add(dataRiset);

    public void Update(DataRiset dataRiset) => _appDbContext.DataRiset.Update(dataRiset);

    public void Delete(DataRiset dataRiset) => _appDbContext.DataRiset.Remove(dataRiset);
}
