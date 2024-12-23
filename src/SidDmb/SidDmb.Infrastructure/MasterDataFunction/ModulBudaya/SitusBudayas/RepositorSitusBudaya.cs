using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SitusBudayas;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulBudaya.SitusBudayas;

internal class RepositorSitusBudaya : IRepositoriSitusBudaya
{
    private readonly AppDbContext _appDbContext;

    public RepositorSitusBudaya(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<SitusBudaya?> Get(IdSitus id) => await _appDbContext.SitusBudaya
        .Include(x => x.DaftarFasilitas)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<SitusBudaya>> GetAll() => await _appDbContext.SitusBudaya
        .Include(x => x.DaftarFasilitas)
        .ToListAsync();

    public void Add(SitusBudaya situsBudaya) => _appDbContext.SitusBudaya.Add(situsBudaya);

    public void Update(SitusBudaya situsBudaya) => _appDbContext.SitusBudaya.Update(situsBudaya);

    public void Delete(SitusBudaya situsBudaya) => _appDbContext.SitusBudaya.Remove(situsBudaya);
}