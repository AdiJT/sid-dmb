namespace SidDmb.Domain.MasterDataFunction.ModulBudaya.SeniBudayas;

public interface IRepositoriFasilitasSeniBudaya
{
    Task<FasilitasSeniBudaya?> Get(int id);
    Task<List<FasilitasSeniBudaya>> GetAll();

    void Add(FasilitasSeniBudaya fasilitasSeniBudaya);
    void Update(FasilitasSeniBudaya fasilitasSeniBudaya);
    void Delete(FasilitasSeniBudaya fasilitasSeniBudaya);
}