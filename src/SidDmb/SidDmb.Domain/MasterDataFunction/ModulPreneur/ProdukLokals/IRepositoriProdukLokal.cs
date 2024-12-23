namespace SidDmb.Domain.MasterDataFunction.ModulPreneur.ProdukLokals;

public interface IRepositoriProdukLokal
{
    Task<ProdukLokal?> Get(IdProduk id);
    Task<List<ProdukLokal>> GetAll();

    void Add(ProdukLokal produkLokal);
    void Update(ProdukLokal produkLokal);
    void Delete(ProdukLokal produkLokal);
}