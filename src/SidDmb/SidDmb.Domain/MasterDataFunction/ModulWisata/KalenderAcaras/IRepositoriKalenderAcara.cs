namespace SidDmb.Domain.MasterDataFunction.ModulWisata.KalenderAcaras;

public interface IRepositoriKalenderAcara
{
    Task<KalenderAcara?> Get(IdAcara id);
    Task<List<KalenderAcara>> GetAll();

    void Add(KalenderAcara kalenderAcara);
    void Update(KalenderAcara kalenderAcara);
    void Delete(KalenderAcara kalenderAcara);
}