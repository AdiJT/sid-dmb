using SidDmb.Domain.Abstracts;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SeniBudayas;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SitusBudayas;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.UpacaraBudayas;

namespace SidDmb.Domain.MasterDataFunction.ModulBudaya;

public class Fasilitas : Entity<int>
{
    public required string Nama { get; set; }

    public List<SeniBudaya> DaftarSeniBudaya { get; set; } = [];
    public List<UpacaraBudaya> DaftarUpacaraBudaya { get; set; } = [];
    public List<SitusBudaya> DaftarSitusBudaya { get; set; } = [];
}