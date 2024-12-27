namespace SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;

public interface IRepositoriEvent
{
    Task<Event?> Get(IdEvent id);
    Task<List<Event>> GetAll();

    void Add(Event @event);
    void Update(Event @event);
    void Delete(Event @event);
}
