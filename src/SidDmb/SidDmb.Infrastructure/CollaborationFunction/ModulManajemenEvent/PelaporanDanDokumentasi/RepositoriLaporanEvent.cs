using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PelaporanDanDokumentasi;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulManajemenEvent.PelaporanDanDokumentasi;

internal class RepositoriLaporanEvent : IRepositoriLaporanEvent
{
    private readonly AppDbContext _appDbContext;

    public RepositoriLaporanEvent(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<LaporanEvent?> Get(IdLaporanEvent id) => await _appDbContext.LaporanEvent
        .Include(x => x.Event).ThenInclude(e => e.DaftarKolaborator)
        .Include(x => x.Event).ThenInclude(e => e.DaftarKolaboratorEvent).ThenInclude(x => x.Entity2)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<LaporanEvent>> GetAll() => await _appDbContext.LaporanEvent
        .Include(x => x.Event).ThenInclude(e => e.DaftarKolaborator)
        .Include(x => x.Event).ThenInclude(e => e.DaftarKolaboratorEvent).ThenInclude(x => x.Entity2)
        .ToListAsync();

    public void Add(LaporanEvent laporanEvent) => _appDbContext.LaporanEvent.Add(laporanEvent);

    public void Update(LaporanEvent laporanEvent) => _appDbContext.LaporanEvent.Update(laporanEvent);

    public void Delete(LaporanEvent laporanEvent) => _appDbContext.LaporanEvent.Remove(laporanEvent);
}