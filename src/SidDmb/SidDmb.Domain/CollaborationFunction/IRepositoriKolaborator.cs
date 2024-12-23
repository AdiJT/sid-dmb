namespace SidDmb.Domain.CollaborationFunction;

public interface IRepositoriKolaborator
{
    Task<Kolaborator> Get(int id);
    Task<List<Kolaborator>> GetAll();
    
    void Add(Kolaborator kolaborator);
    void Update(Kolaborator kolaborator);
    void Delete(Kolaborator kolaborator);
}