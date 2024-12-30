using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.RekomendasiDanPengembanganProduk;

public class KolaboratorRekomendasi : JoinEntity<Rekomendasi, Kolaborator, IdRekomendasi, int>
{
    public string FeedbackKolaborator { get; set; } = string.Empty;
}