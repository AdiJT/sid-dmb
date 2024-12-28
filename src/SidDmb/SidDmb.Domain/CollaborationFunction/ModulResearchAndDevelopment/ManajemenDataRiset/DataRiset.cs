using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;

public class DataRiset : Entity<IdDataRiset>, IAuditableEntity
{
    public required string JudulPenelitian { get; set; }
    public required string DekripsiPenelitian { get; set; }
    public required KategoriPenelitian KategoriPenelitian { get; set; }
    public required string EntitasPenelitian { get; set; }
    public required DateOnly TanggalMulaiPenelitian { get; set; }
    public required DateOnly TanggalSelesaiPenelitian { get; set; }
    public required string MetodePengumpulanData { get; set; }
    public required string HasilPenelitian { get; set; }
    public required Uri DokumenPenelitian { get; set; }
    public required string ManfaatPenelitian { get; set; }
    public required StatusPenelitian StatusPenelitian { get; set; }
    public required string[] DaftarJenisDataRiset { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public List<Kolaborator> DaftarKolaboratorPenelitian { get; set; } = [];
    public List<KolaboratorDataRiset> DaftarKolaboratorDataRiset { get; set; } = [];
}

public class KolaboratorDataRiset : JoinEntity<DataRiset, Kolaborator, IdDataRiset, int>
{
    public string FeedbackKolaborator { get; set; } = string.Empty;
}