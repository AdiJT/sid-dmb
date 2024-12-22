namespace SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;

public interface IRepostoriKolaboratorEvent
{
    Task<KolaboratorEvent?> Get(int id);
    Task<List<KolaboratorEvent>> GetAll();

    void Add(KolaboratorEvent kolaboratorEvent);
    void Update(KolaboratorEvent kolaboratorEvent);
    void Delete(KolaboratorEvent kolaboratorEvent);
}