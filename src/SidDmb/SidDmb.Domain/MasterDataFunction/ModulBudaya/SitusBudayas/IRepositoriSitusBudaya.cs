namespace SidDmb.Domain.MasterDataFunction.ModulBudaya.SitusBudayas;

public interface IRepositoriSitusBudaya
{
    Task<SitusBudaya?> Get(IdSitus id);
    Task<List<SitusBudaya>> GetAll();

    void Add(SitusBudaya situsBudaya);
    void Update(SitusBudaya situsBudaya);
    void Delete(SitusBudaya situsBudaya);
}