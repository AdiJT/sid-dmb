using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.PeningkatanKapasitas;

public class KolaboratorPelatihan : JoinEntity<Pelatihan, Kolaborator, IdPelatihan, int>
{
    public string RekomendasiUntukPelatihanBerikutnya { get; set; } = string.Empty;
}