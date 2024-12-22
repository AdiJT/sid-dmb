namespace SidDmb.Domain.MasterDataFunction.ModulBudaya.ArtefakBudayas;

public interface IRepositoriArtefakBudaya
{
    Task<ArtefakBudaya?> Get(IdArtefak id);
    Task<List<ArtefakBudaya>> GetAll();
}
