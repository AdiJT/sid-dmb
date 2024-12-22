namespace SidDmb.Domain.MasterDataFunction.ModulPrima.KelompokPrimas;

public interface IRepositoriKelompokPrima
{
    Task<KelompokPrima?> Get(IdKelompok id);
    Task<List<KelompokPrima>> GetAll();

    void Add(KelompokPrima kelompokPrima);
    void Update(KelompokPrima kelompokPrima);
    void Delete(KelompokPrima kelompokPrima);
}