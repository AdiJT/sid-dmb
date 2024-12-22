namespace SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasiDanPembelajaran;

public interface IRepositoriKolabolatorMateri
{
    Task<KolabolatorMateri?> Get(int id);
    Task<List<KolabolatorMateri>> GetAll();

    void Add(KolabolatorMateri kolabolatorMateri);
    void Update(KolabolatorMateri kolabolatorMateri);
    void Delete(KolabolatorMateri kolabolatorMateri);
}