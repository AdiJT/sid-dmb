namespace SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasiDanPembelajaran;

public interface IRepositoriMateri
{
    Task<Materi?> Get(IdMateri id);
    Task<List<Materi>> GetAll();

    void Add(Materi materiEdukasiDanPembelajaran);
    void Update(Materi materiEdukasiDanPembelajaran);
    void Delete(Materi materiEdukasiDanPembelajaran);
}
