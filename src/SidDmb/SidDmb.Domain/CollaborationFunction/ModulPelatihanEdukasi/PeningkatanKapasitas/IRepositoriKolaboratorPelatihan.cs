namespace SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.PeningkatanKapasitas;

public interface IRepositoriKolaboratorPelatihan
{
    Task<KolaboratorPelatihan?> Get(int id);
    Task<List<KolaboratorPelatihan>> GetAll();

    void Add(KolaboratorPelatihan kolaboratorPelatihan);
    void Update(KolaboratorPelatihan kolaboratorPelatihan);
    void Delete(KolaboratorPelatihan kolaboratorPelatihan);
}