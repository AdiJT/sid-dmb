namespace SidDmb.Domain.MasterDataFunction.ModulBudaya.UpacaraBudayas;

public interface IRepositoriUpacaraBudaya
{
    Task<UpacaraBudaya?> Get(IdUpacara id);
    Task<List<UpacaraBudaya>> GetAll();

    void Add(UpacaraBudaya upacaraBudaya);
    void Update(UpacaraBudaya upacaraBudaya);
    void Delete(UpacaraBudaya upacaraBudaya);
}
