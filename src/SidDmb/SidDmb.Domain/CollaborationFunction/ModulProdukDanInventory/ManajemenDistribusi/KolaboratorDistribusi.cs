using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenDistribusi;

public class KolaboratorDistribusi : Entity<int>
{
    public required string Nama { get; set; }

    public List<Distribusi> DaftarDistribusi { get; set; } = [];
}
