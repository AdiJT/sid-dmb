namespace SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;

public interface IRepositoriKolaboratorProduk
{
    Task<KolaboratorProduk?> Get(int id);
    Task<List<KolaboratorProduk>> GetAll();

    void Add(KolaboratorProduk kolaboratorProduk);
    void Update(KolaboratorProduk kolaboratorProduk);
    void Delete(KolaboratorProduk kolaboratorProduk);
}