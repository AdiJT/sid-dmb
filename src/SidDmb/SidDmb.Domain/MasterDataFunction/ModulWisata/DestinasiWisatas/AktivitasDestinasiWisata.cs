using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;

public class AktivitasDestinasiWisata : Entity<int>
{
    public required string Nama { get; set; }

    public List<DestinasiWisata> DaftarDestinasiWisata { get; set; } = [];
}
