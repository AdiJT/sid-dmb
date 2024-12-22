namespace SidDmb.Domain.MasterDataFunction.ModulBudaya.UpacaraBudayas;

public interface IRepositoriFasilitasUpacaraBudaya
{
    Task<FasilitasUpacaraBudaya?> Get(int id);
    Task<List<FasilitasUpacaraBudaya>> GetAll();

    void Add(FasilitasUpacaraBudaya fasilitasUpacaraBudaya);
    void Update(FasilitasUpacaraBudaya fasilitasUpacaraBudaya);
    void Delete(FasilitasUpacaraBudaya fasilitasUpacaraBudaya);
}