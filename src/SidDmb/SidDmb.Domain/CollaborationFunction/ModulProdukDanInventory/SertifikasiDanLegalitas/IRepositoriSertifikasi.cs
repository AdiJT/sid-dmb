namespace SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;

public interface IRepositoriSertifikasi
{
    Task<Sertifikasi?> Get(IdSertifikasi id);
    Task<List<Sertifikasi>> GetAll();

    void Add(Sertifikasi sertifikasi);
    void Update(Sertifikasi sertifikasi);
    void Delete(Sertifikasi sertifikasi);
}
