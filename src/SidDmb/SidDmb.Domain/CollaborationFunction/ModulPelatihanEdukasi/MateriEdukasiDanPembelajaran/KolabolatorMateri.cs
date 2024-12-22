using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasiDanPembelajaran;

public class KolabolatorMateri : Entity<int>
{
    public required string Nama { get; set; }

    public List<Materi> DaftarMateri { get; set; } = [];
}
