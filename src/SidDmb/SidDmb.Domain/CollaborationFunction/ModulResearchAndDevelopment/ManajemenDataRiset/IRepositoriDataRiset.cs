namespace SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;

public interface IRepositoriDataRiset
{
    Task<DataRiset?> Get(IdDataRiset id);
    Task<List<DataRiset>> GetAll();

    void Add(DataRiset dataRiset);
    void Update(DataRiset dataRiset);
    void Delete(DataRiset dataRiset);
}
