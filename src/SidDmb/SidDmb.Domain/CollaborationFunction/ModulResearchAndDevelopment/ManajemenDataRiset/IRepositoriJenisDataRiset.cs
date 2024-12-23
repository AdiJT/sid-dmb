namespace SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;

public interface IRepositoriJenisDataRiset
{
    Task<JenisDataRiset?> Get(int id);
    Task<List<JenisDataRiset>> GetAll();

    void Add(JenisDataRiset jenisDataRiset);
    void Update(JenisDataRiset jenisDataRiset);
    void Delete(JenisDataRiset jenisDataRiset);
}
