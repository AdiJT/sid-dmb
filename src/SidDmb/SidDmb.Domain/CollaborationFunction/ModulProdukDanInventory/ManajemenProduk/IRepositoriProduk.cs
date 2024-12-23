namespace SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;

public interface IRepositoriProduk
{
    Task<Produk?> Get(IdProduk id);
    Task<List<Produk>> GetAll();

    void Add(Produk produk);
    void Update(Produk produk);
    void Delete(Produk produk);
}
