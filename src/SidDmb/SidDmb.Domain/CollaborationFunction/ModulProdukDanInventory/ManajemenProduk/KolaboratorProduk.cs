using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenProduk;

public class KolaboratorProduk : Entity<int>
{
    public required string Nama { get; set; }

    public List<Produk> DaftarProduk { get; set; } = [];
}
