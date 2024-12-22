namespace SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.PeningkatanKapasitas;

public interface IRepositoriPelatihan
{
    Task<Pelatihan?> Get(IdPelatihan id);
    Task<List<Pelatihan>> GetAll();

    void Add(Pelatihan Pelatihan);
    void Update(Pelatihan Pelatihan);
    void Delete(Pelatihan Pelatihan);
}
