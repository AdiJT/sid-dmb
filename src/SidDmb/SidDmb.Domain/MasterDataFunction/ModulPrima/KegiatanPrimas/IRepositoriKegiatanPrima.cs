namespace SidDmb.Domain.MasterDataFunction.ModulPrima.KegiatanPrimas;

public interface IRepositoriKegiatanPrima
{
    Task<KegiatanPrima?> Get(IdKegiatanPrima id);
    Task<List<KegiatanPrima>> GetAll();

    void Add(KegiatanPrima kegiatanPrima);
    void Update(KegiatanPrima kegiatanPrima);
    void Delete(KegiatanPrima kegiatanPrima);
}