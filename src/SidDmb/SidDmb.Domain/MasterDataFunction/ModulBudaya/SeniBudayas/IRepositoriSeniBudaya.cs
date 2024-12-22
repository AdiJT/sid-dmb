namespace SidDmb.Domain.MasterDataFunction.ModulBudaya.SeniBudayas;

public interface IRepositoriSeniBudaya
{
    Task<SeniBudaya?> Get(IdSeni id);
    Task<List<SeniBudaya>> GetAll();

    void Add(SeniBudaya seniBudaya);
    void Update(SeniBudaya seniBudaya);
    void Delete(SeniBudaya seniBudaya);
}
