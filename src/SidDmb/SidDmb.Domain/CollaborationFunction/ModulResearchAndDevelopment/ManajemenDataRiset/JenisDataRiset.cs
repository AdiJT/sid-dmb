using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;

public class JenisDataRiset : Entity<int>
{
    public required string Nama { get; set; }

    public List<DataRiset> DaftarDataRiset { get; set; } = [];
}
