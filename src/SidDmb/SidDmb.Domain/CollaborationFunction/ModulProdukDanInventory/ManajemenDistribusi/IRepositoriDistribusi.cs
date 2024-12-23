namespace SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenDistribusi;

public interface IRepositoriDistribusi
{
    Task<Distribusi?> Get(IdDistribusi id);
    Task<List<Distribusi>> GetAll();

    void Add(Distribusi distribusi);
    void Update(Distribusi distribusi);
    void Delete(Distribusi distribusi);
}
