using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.UpacaraBudayas;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulBudaya.UpacaraBudayas;

internal class RepositoriUpacaBudaya : IRepositoriUpacaraBudaya
{
    private readonly AppDbContext _appDbContext;

    public RepositoriUpacaBudaya(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<UpacaraBudaya?> Get(IdUpacara id) => await _appDbContext.UpacaraBudaya
        .Include(x => x.FasilitasPendukung)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<UpacaraBudaya>> GetAll() => await _appDbContext.UpacaraBudaya
        .Include(x => x.FasilitasPendukung)
        .ToListAsync();

    public void Add(UpacaraBudaya upacaraBudaya) => _appDbContext.UpacaraBudaya.Add(upacaraBudaya);

    public void Update(UpacaraBudaya upacaraBudaya) => _appDbContext.UpacaraBudaya.Update(upacaraBudaya);

    public void Delete(UpacaraBudaya upacaraBudaya) => _appDbContext.UpacaraBudaya.Remove(upacaraBudaya);
}