using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.ArtefakBudayas;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SeniBudayas;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SitusBudayas;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.UpacaraBudayas;
using SidDmb.Domain.MasterDataFunction.ModulPreneur.ProdukLokals;
using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;

namespace SidDmb.Web.Models.Home;

public class IndexVM
{
    public required DestinasiWisata? DestinasiWisata { get; set; }
    public required ProdukLokal? ProdukLokal { get; set; }
    public required ArtefakBudaya? ArtefakBudaya { get; set; }
    public required SitusBudaya? SitusBudaya { get; set; }
    public required SeniBudaya? SeniBudaya { get; set; }
    public required UpacaraBudaya? UpacaraBudaya { get; set; }
    public required List<Event> DaftarEvent { get; set; }
}