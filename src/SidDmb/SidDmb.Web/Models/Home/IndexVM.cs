using SidDmb.Domain.MasterDataFunction.ModulBudaya.ArtefakBudayas;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.SitusBudayas;
using SidDmb.Domain.MasterDataFunction.ModulPreneur.ProdukLokals;
using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;
using SidDmb.Domain.MasterDataFunction.ModulWisata.KalenderAcaras;

namespace SidDmb.Web.Models.Home;

public class IndexVM
{
    public required DestinasiWisata? DestinasiWisata { get; set; }
    public required ProdukLokal? ProdukLokal { get; set; }
    public required ArtefakBudaya? ArtefakBudaya { get; set; }
    public required SitusBudaya? SitusBudaya { get; set; }
    public required List<KalenderAcara> DaftarEvent { get; set; }
}