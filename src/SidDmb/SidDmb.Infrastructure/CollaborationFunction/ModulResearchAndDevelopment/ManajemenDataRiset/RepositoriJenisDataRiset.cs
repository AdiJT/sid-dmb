using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;

internal class RepositoriJenisDataRiset : IRepositoriJenisDataRiset
{
    private readonly AppDbContext _appDbContext;

    public RepositoriJenisDataRiset(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<JenisDataRiset?> Get(int id) => await _appDbContext.JenisDataRiset
        .Include(x => x.DaftarDataRiset)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<JenisDataRiset>> GetAll() => await _appDbContext.JenisDataRiset
        .Include(x => x.DaftarDataRiset)
        .ToListAsync();

    public void Add(JenisDataRiset jenisDataRiset) => _appDbContext.JenisDataRiset.Add(jenisDataRiset);

    public void Update(JenisDataRiset jenisDataRiset) => _appDbContext.JenisDataRiset.Update(jenisDataRiset);

    public void Delete(JenisDataRiset jenisDataRiset) => _appDbContext.JenisDataRiset.Remove(jenisDataRiset);
}