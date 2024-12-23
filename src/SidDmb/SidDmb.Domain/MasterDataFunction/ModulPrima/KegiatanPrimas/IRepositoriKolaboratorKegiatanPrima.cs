namespace SidDmb.Domain.MasterDataFunction.ModulPrima.KegiatanPrimas;

public interface IRepositoriKolaboratorKegiatanPrima
{
    Task<KolaboratorKegiatanPrima?> Get(int id);
    Task<List<KolaboratorKegiatanPrima>> GetAll();

    void Add(KolaboratorKegiatanPrima kolaboratorKegiatanPrima);
    void Update(KolaboratorKegiatanPrima kolaboratorKegiatanPrima);
    void Delete(KolaboratorKegiatanPrima kolaboratorKegiatanPrima);
}