using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;

public class KolaboratorDataRiset : JoinEntity<DataRiset, Kolaborator, IdDataRiset, int>
{
    public string FeedbackKolaborator { get; set; } = string.Empty;
}