using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.MasterDataFunction.ModulWisata.KalenderAcaras;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulWisata.KalenderAcaras;

internal class RepositoriKalenderAcara : IRepositoriKalenderAcara
{
    private readonly AppDbContext _appDbContext;

    public RepositoriKalenderAcara(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<KalenderAcara?> Get(IdAcara id) => await _appDbContext.KalenderAcara.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<KalenderAcara>> GetAll() => await _appDbContext.KalenderAcara.ToListAsync();

    public void Add(KalenderAcara kalenderAcara) => _appDbContext.KalenderAcara.Add(kalenderAcara);

    public void Update(KalenderAcara kalenderAcara) => _appDbContext.KalenderAcara.Update(kalenderAcara);

    public void Delete(KalenderAcara kalenderAcara) => _appDbContext.KalenderAcara.Remove(kalenderAcara);
}