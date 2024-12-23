using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;

public class KolaboratorSertifikasi : Entity<int>
{
    public required string Nama { get; set; }

    public List<Sertifikasi> DaftarSertifikasi { get; set; } = [];
}
