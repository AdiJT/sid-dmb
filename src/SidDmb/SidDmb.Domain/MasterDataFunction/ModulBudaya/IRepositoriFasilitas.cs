namespace SidDmb.Domain.MasterDataFunction.ModulBudaya;

public interface IRepositoriFasilitas
{
    Task<Fasilitas?> Get(int id);
    Task<List<Fasilitas>> GetAll();

    void Add(Fasilitas fasilitas);
    void Update(Fasilitas fasilitas);
    void Delete(Fasilitas fasilitas);
}