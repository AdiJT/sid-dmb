namespace SidDmb.Domain.MasterDataFunction.ModulBudaya.SitusBudayas;

public interface IRepositoriFasilitasSitusBudaya
{
    Task<FasilitasSitusBudaya?> Get(int id);
    Task<List<FasilitasSitusBudaya>> GetAll();

    void Add(FasilitasSitusBudaya fasilitasSitusBudaya);
    void Update(FasilitasSitusBudaya fasilitasSitusBudaya);
    void Delete(FasilitasSitusBudaya fasilitasSitusBudaya);
}
