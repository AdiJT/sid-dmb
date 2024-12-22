namespace SidDmb.Domain.MasterDataFunction.ModulBudaya.UpacaraBudayas;

public class FasilitasUpacaraBudaya
{
    public required string Nama { get; set; }

    public List<UpacaraBudaya> DaftarUpacaraBudaya { get; set; } = [];
}
