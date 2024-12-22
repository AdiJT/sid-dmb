using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.MasterDataFunction.ModulBudaya.SeniBudayas;

public class FasilitasSeniBudaya : Entity<int>
{
    public required string Nama { get; set; }

    public List<SeniBudaya> DaftarSeniBudaya { get; set; } = [];
}
