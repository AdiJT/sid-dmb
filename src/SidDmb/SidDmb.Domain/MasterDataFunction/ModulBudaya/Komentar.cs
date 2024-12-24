using SidDmb.Domain.Abstracts;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.ArtefakBudayas;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SeniBudayas;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SitusBudayas;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.UpacaraBudayas;

namespace SidDmb.Domain.MasterDataFunction.ModulBudaya;

public class Komentar : Entity<int>
{
    public required string Nama { get; set; }
    public required string Isi { get; set; }
    public required double Rating { get; set; }

    public ArtefakBudaya? ArtefakBudaya { get; set; }
    public UpacaraBudaya? UpacaraBudaya { get; set; }
    public SitusBudaya? SitusBudaya { get; set; }
    public SeniBudaya? SeniBudaya { get; set; }
}
