namespace SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenDistribusi;

public interface IRepositoriKolaboratorDistribusi
{
    Task<KolaboratorDistribusi?> Get(int id);
    Task<List<KolaboratorDistribusi>> GetAll();

    void Add(KolaboratorDistribusi kolaboratorDistribusi);
    void Update(KolaboratorDistribusi kolaboratorDistribusi);
    void Delete(KolaboratorDistribusi kolaboratorDistribusi);
}