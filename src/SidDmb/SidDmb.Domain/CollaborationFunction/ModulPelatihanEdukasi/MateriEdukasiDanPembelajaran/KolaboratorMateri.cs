using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasiDanPembelajaran;

public class KolaboratorMateri : JoinEntity<Materi, Kolaborator, IdMateri, int>
{
    public string RekomendasiPembaruanMateri { get; set; } = string.Empty;
}