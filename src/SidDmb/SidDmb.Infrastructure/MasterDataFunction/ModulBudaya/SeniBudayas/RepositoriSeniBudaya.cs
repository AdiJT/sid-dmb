using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SeniBudayas;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulBudaya.SeniBudayas;

internal class RepositoriSeniBudaya : IRepositoriSeniBudaya
{
    private readonly AppDbContext _appDbContext;

    public RepositoriSeniBudaya(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<SeniBudaya?> Get(IdSeni id) => await _appDbContext.SeniBudaya
        .Include(x => x.FasilitasPertunjukan)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<SeniBudaya>> GetAll() => await _appDbContext.SeniBudaya
        .Include(x => x.FasilitasPertunjukan)
        .ToListAsync();

    public void Add(SeniBudaya seniBudaya) => _appDbContext.SeniBudaya.Add(seniBudaya);

    public void Update(SeniBudaya seniBudaya) => _appDbContext.SeniBudaya.Update(seniBudaya);

    public void Delete(SeniBudaya seniBudaya) => _appDbContext.SeniBudaya.Remove(seniBudaya);
}