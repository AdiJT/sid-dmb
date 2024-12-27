using SidDmb.Domain.Abstracts;
using SidDmb.Domain.CollaborationFunction;

namespace SidDmb.Domain.MasterDataFunction.ModulPrima.KegiatanPrimas;

public class KolaboratorKegiatanPrima : JoinEntity<KegiatanPrima, Kolaborator, IdKegiatanPrima, int>
{
    public string RekomendasiBerikutnya { get; set; } = string.Empty;
}