using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;

public class KolaboratorSertifikasi : JoinEntity<Sertifikasi, Kolaborator, IdSertifikasi, int>
{
    public string Komentar { get; set; } = string.Empty;
}