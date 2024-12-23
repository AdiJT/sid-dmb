namespace SidDmb.Domain.MasterDataFunction.ModulBudaya.ArtefakBudayas;

public interface IRepositoriArtefakBudaya
{
    Task<ArtefakBudaya?> Get(IdArtefak id);
    Task<List<ArtefakBudaya>> GetAll();

    void Add(ArtefakBudaya artefakBudaya);
    void Update(ArtefakBudaya artefakBudaya);
    void Delete(ArtefakBudaya artefakBudaya);
}
