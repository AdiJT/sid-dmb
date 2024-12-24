using SidDmb.Domain.MasterDataFunction.ModulBudaya.UpacaraBudayas;

namespace SidDmb.Domain.MasterDataFunction.ModulBudaya;

public interface IRepositoriKomentar
{
    Task<Komentar?> Get(int id);
    Task<List<Komentar>> GetAll();

    void Add(Komentar komentar);
    void Update(Komentar komentar);
    void Delete(Komentar komentar);
}