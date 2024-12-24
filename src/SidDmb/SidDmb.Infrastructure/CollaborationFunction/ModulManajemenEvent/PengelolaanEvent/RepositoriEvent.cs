using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;

internal class RepositoriEvent : IRepostoriEvent
{
    private readonly AppDbContext _appDbContext;

    public RepositoriEvent(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Event?> Get(IdEvent id) => await _appDbContext.Event
        .Include(x => x.DaftarKolaborator)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<Event>> GetAll() => await _appDbContext.Event
        .Include(x => x.DaftarKolaborator)
        .ToListAsync();

    public void Add(Event @event) => _appDbContext.Event.Add(@event);

    public void Update(Event @event) => _appDbContext.Event.Update(@event);

    public void Delete(Event @event) => _appDbContext.Event.Remove(@event);
}