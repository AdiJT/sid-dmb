using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.MasterDataFunction.ModulPrima.KegiatanPrimas;

public class KolaboratorKegiatanPrima : Entity<int>
{
    public required string Nama { get; set; }

    public List<KegiatanPrima> DaftarKegiatanPrima { get; set; } = [];
}
