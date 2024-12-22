using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.PeningkatanKapasitas;

public class KolaboratorPelatihan : Entity<int>
{
    public required string Nama { get; set; }

    public List<Pelatihan> DaftarPelatihan { get; set; } = [];
}
