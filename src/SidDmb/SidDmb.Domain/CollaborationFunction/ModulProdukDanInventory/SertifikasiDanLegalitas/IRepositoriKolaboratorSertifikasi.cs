namespace SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;

public interface IRepositoriKolaboratorSertifikasi
{
    Task<KolaboratorSertifikasi?> Get(int id);
    Task<List<KolaboratorSertifikasi>> GetAll();

    void Add(KolaboratorSertifikasi kolaboratorSertifikasi);
    void Update(KolaboratorSertifikasi kolaboratorSertifikasi);
    void Delete(KolaboratorSertifikasi kolaboratorSertifikasi);
}