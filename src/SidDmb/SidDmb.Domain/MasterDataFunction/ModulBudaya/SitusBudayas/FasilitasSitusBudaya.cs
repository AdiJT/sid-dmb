using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.MasterDataFunction.ModulBudaya.SitusBudayas;

public class FasilitasSitusBudaya : Entity<int>
{
    public required string Nama { get; set; }

    public List<SitusBudaya> DaftarSitusBudaya { get; set; } = [];
}
